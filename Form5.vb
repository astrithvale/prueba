Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Form5

    Private ReadOnly cadenaConexion As String =
        "Data Source=DESKTOP-JUFFJEL\SQLEXPRESS;Initial Catalog=SICEI;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"

    Private idSeleccionado As Integer = 0
    Private modoEdicion As Boolean = False
    Private cargando As Boolean = False
    Private txtBusquedaRapida As TextBox
    Private lblBusquedaRapida As Label
    Private vistaClientes As DataView
    Private modoNuevo As Boolean = False

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtIdCliente.ReadOnly = True
        txtDocumento.MaxLength = 11
        txtTelefono.MaxLength = 9
        txtNombre.MaxLength = 100
        txtApellido.MaxLength = 100
        txtRazonSocial.MaxLength = 150
        txtEmail.MaxLength = 100
        txtDireccion.MaxLength = 200
        cmbTipoCliente.DropDownStyle = ComboBoxStyle.DropDownList
        cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTipoCliente.Items.Clear()
        cmbTipoCliente.Items.AddRange(New Object() {"NATURAL", "EMPRESA"})
        cmbEstado.Items.Clear()
        cmbEstado.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        CLIENTEDataGridView.ReadOnly = True
        CLIENTEDataGridView.AllowUserToAddRows = False
        CLIENTEDataGridView.AllowUserToDeleteRows = False
        CLIENTEDataGridView.MultiSelect = False
        CLIENTEDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ' Se conserva Eliminar y la búsqueda rápida; no existen botones Buscar ni Salir.
        ConfigurarColumnasClientes()
        CrearBusquedaRapida()
        CargarClientes()
        LimpiarFormulario()
    End Sub

    Private Sub ConfigurarColumnasClientes()
        ' Mantiene el diseño existente y corrige los enlaces y el orden.
        Dim campos As String() = {"id_cliente", "tipo_cliente", "nombre", "apellido", "razon_social", "documento", "telefono", "email", "direccion", "fecha_registro", "estado"}
        Dim titulos As String() = {"ID", "Tipo de cliente", "Nombre", "Apellido", "Razón social", "Documento", "Teléfono", "Correo electrónico", "Dirección", "Fecha de registro", "Estado"}

        CLIENTEDataGridView.AutoGenerateColumns = False

        ' Eliminar columnas duplicadas (por ejemplo, dos columnas Estado).
        Dim vistas As New System.Collections.Generic.Dictionary(Of String, DataGridViewColumn)(StringComparer.OrdinalIgnoreCase)
        For i As Integer = CLIENTEDataGridView.Columns.Count - 1 To 0 Step -1
            Dim columna As DataGridViewColumn = CLIENTEDataGridView.Columns(i)
            Dim campo As String = columna.DataPropertyName.Trim()
            If campo = "" OrElse Array.IndexOf(campos, campo.ToLowerInvariant()) < 0 OrElse vistas.ContainsKey(campo) Then
                CLIENTEDataGridView.Columns.RemoveAt(i)
            Else
                vistas.Add(campo, columna)
            End If
        Next

        For i As Integer = 0 To campos.Length - 1
            Dim columna As DataGridViewColumn = Nothing
            If vistas.ContainsKey(campos(i)) Then
                columna = vistas(campos(i))
            Else
                columna = New DataGridViewTextBoxColumn()
                columna.Name = "colCliente_" & campos(i)
                columna.DataPropertyName = campos(i)
                CLIENTEDataGridView.Columns.Add(columna)
            End If
            columna.HeaderText = titulos(i)
            columna.DataPropertyName = campos(i)
            columna.Visible = True
            columna.ReadOnly = True
            columna.DisplayIndex = i
            columna.MinimumWidth = 85
            If campos(i) = "fecha_registro" AndAlso TypeOf columna Is DataGridViewTextBoxColumn Then
                CType(columna, DataGridViewTextBoxColumn).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            End If
        Next
    End Sub

    Private Sub CrearBusquedaRapida()
        ' Se crean en tiempo de ejecución: no es necesario agregar controles al diseñador.
        lblBusquedaRapida = New Label() With {
            .Name = "lblBusquedaRapida",
            .Text = "Buscar cliente:",
            .AutoSize = True,
            .ForeColor = System.Drawing.Color.White,
            .BackColor = System.Drawing.Color.FromArgb(20, 49, 78),
            .Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        }
        txtBusquedaRapida = New TextBox() With {
            .Name = "txtBusquedaRapida",
            .Width = 320,
            .Font = New System.Drawing.Font("Segoe UI", 10.0!)
        }
        ' Se ubican sobre la tabla sin alterar los controles del diseñador.
        Dim contenedor As Control = CLIENTEDataGridView.Parent
        contenedor.Controls.Add(lblBusquedaRapida)
        contenedor.Controls.Add(txtBusquedaRapida)
        AddHandler txtBusquedaRapida.TextChanged, AddressOf BusquedaRapida_TextChanged
        AddHandler contenedor.Resize, AddressOf ReubicarBusqueda
        ReubicarBusqueda(Nothing, EventArgs.Empty)
        lblBusquedaRapida.BringToFront()
        txtBusquedaRapida.BringToFront()
    End Sub

    Private Sub ReubicarBusqueda(sender As Object, e As EventArgs)
        If txtBusquedaRapida Is Nothing Then Return
        Dim y As Integer = Math.Max(4, CLIENTEDataGridView.Top - 34)
        lblBusquedaRapida.Location = New System.Drawing.Point(CLIENTEDataGridView.Left, y + 4)
        txtBusquedaRapida.Location = New System.Drawing.Point(CLIENTEDataGridView.Left + 125, y)
    End Sub

    Private Sub BusquedaRapida_TextChanged(sender As Object, e As EventArgs)
        If vistaClientes Is Nothing Then Return
        Dim valor As String = txtBusquedaRapida.Text.Trim().Replace("'", "''").
            Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]")
        vistaClientes.RowFilter =
            "Convert(id_cliente, 'System.String') LIKE '%" & valor & "%' OR " &
            "IsNull(nombre, '') LIKE '%" & valor & "%' OR " &
            "IsNull(apellido, '') LIKE '%" & valor & "%' OR " &
            "IsNull(razon_social, '') LIKE '%" & valor & "%' OR " &
            "IsNull(documento, '') LIKE '%" & valor & "%'"
        CLIENTEDataGridView.ClearSelection()
        CLIENTEDataGridView.CurrentCell = Nothing
        idSeleccionado = 0
        If Not modoNuevo Then
            modoEdicion = False
            BloquearCampos(True)
        End If
    End Sub

    Private Sub CargarClientes()
        cargando = True
        Try
            ' Desenlazar temporalmente evita que el BindingSource seleccione una fila.
            Me.CLIENTETableAdapter.Fill(Me.SICEIDataSet.CLIENTE)
            vistaClientes = New DataView(Me.SICEIDataSet.CLIENTE)
            CLIENTEDataGridView.DataSource = vistaClientes
            If txtBusquedaRapida IsNot Nothing Then
                BusquedaRapida_TextChanged(Nothing, EventArgs.Empty)
            End If
            CLIENTEDataGridView.ClearSelection()
            CLIENTEDataGridView.CurrentCell = Nothing
        Finally
            cargando = False
        End Try
    End Sub

    Private Sub BloquearCampos(bloquear As Boolean)
        cmbTipoCliente.Enabled = Not bloquear
        txtNombre.ReadOnly = bloquear
        txtApellido.ReadOnly = bloquear
        txtRazonSocial.ReadOnly = bloquear
        txtDocumento.ReadOnly = bloquear
        txtTelefono.ReadOnly = bloquear
        txtEmail.ReadOnly = bloquear
        txtDireccion.ReadOnly = bloquear
        cmbEstado.Enabled = Not bloquear
        dtpFechaRegistro.Enabled = Not bloquear
    End Sub

    Private Sub LimpiarFormulario()
        cargando = True
        Try
            idSeleccionado = 0
            modoEdicion = False
            modoNuevo = False
            txtIdCliente.Clear()
            cmbTipoCliente.SelectedIndex = -1
            txtNombre.Clear()
            txtApellido.Clear()
            txtRazonSocial.Clear()
            txtDocumento.Clear()
            txtTelefono.Clear()
            txtEmail.Clear()
            txtDireccion.Clear()
            cmbEstado.SelectedItem = "ACTIVO"
            dtpFechaRegistro.Value = DateTime.Now
            CLIENTEDataGridView.ClearSelection()
            CLIENTEDataGridView.CurrentCell = Nothing
        Finally
            cargando = False
        End Try
        BloquearCampos(True)
        AplicarTipoCliente()
    End Sub

    Private Sub AplicarTipoCliente()
        Dim tipo As String = cmbTipoCliente.Text.Trim().ToUpperInvariant()
        txtNombre.ReadOnly = Not ((modoNuevo OrElse modoEdicion) AndAlso tipo = "NATURAL")
        txtApellido.ReadOnly = Not ((modoNuevo OrElse modoEdicion) AndAlso tipo = "NATURAL")
        txtRazonSocial.ReadOnly = Not ((modoNuevo OrElse modoEdicion) AndAlso tipo = "EMPRESA")
        txtDocumento.MaxLength = If(tipo = "NATURAL", 8, 11)
    End Sub

    Private Sub cmbTipoCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCliente.SelectedIndexChanged
        If cargando Then Return
        If cmbTipoCliente.Text = "NATURAL" Then
            txtRazonSocial.Clear()
        ElseIf cmbTipoCliente.Text = "EMPRESA" Then
            txtNombre.Clear()
            txtApellido.Clear()
        End If
        txtDocumento.Clear()
        AplicarTipoCliente()
    End Sub

    Private Sub txtNumeros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress, txtDocumento.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not (e.KeyChar >= "0"c AndAlso e.KeyChar <= "9"c) Then
            e.Handled = True
        End If
    End Sub

    Private Function ValidarCliente() As Boolean
        Dim tipo As String = cmbTipoCliente.Text.Trim().ToUpperInvariant()
        Dim documento As String = txtDocumento.Text.Trim()
        Dim telefono As String = txtTelefono.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()

        If tipo <> "NATURAL" AndAlso tipo <> "EMPRESA" Then
            MessageBox.Show("Seleccione NATURAL o EMPRESA.")
            cmbTipoCliente.Focus()
            Return False
        End If
        If tipo = "NATURAL" Then
            If Not Regex.IsMatch(txtNombre.Text.Trim(), "^[\p{L}]+(?:[ '\-][\p{L}]+)*$") OrElse
               Not Regex.IsMatch(txtApellido.Text.Trim(), "^[\p{L}]+(?:[ '\-][\p{L}]+)*$") Then
                MessageBox.Show("Ingrese nombre y apellido válidos (solo letras y espacios).")
                Return False
            End If
        Else
            If String.IsNullOrWhiteSpace(txtRazonSocial.Text) Then
                MessageBox.Show("La razón social es obligatoria para EMPRESA.")
                txtRazonSocial.Focus()
                Return False
            End If
        End If
        Dim longitud As Integer = If(tipo = "NATURAL", 8, 11)
        If Not Regex.IsMatch(documento, "^[0-9]{" & longitud.ToString() & "}$") Then
            MessageBox.Show(If(tipo = "NATURAL", "El DNI", "El RUC") & " debe tener exactamente " & longitud.ToString() & " dígitos.")
            txtDocumento.Focus()
            Return False
        End If
        If Not Regex.IsMatch(telefono, "^9[0-9]{8}$") Then
            MessageBox.Show("El teléfono debe tener 9 dígitos y comenzar con 9.")
            txtTelefono.Focus()
            Return False
        End If
        If email <> "" AndAlso Not Regex.IsMatch(email, "^[^\s@]+@[^\s@]+\.[^\s@]+$") Then
            MessageBox.Show("Ingrese un correo electrónico válido.")
            txtEmail.Focus()
            Return False
        End If
        If cmbEstado.Text <> "ACTIVO" AndAlso cmbEstado.Text <> "INACTIVO" Then
            MessageBox.Show("Seleccione un estado válido.")
            Return False
        End If
        Return True
    End Function

    Private Sub AgregarParametros(cmd As SqlCommand)
        Dim tipo As String = cmbTipoCliente.Text.Trim().ToUpperInvariant()
        cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 10).Value = tipo
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = If(tipo = "NATURAL", CType(txtNombre.Text.Trim(), Object), DBNull.Value)
        cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 100).Value = If(tipo = "NATURAL", CType(txtApellido.Text.Trim(), Object), DBNull.Value)
        cmd.Parameters.Add("@razon", SqlDbType.VarChar, 150).Value = If(tipo = "EMPRESA", CType(txtRazonSocial.Text.Trim(), Object), DBNull.Value)
        cmd.Parameters.Add("@documento", SqlDbType.VarChar, 20).Value = txtDocumento.Text.Trim()
        cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 15).Value = ValorOpcional(txtTelefono.Text)
        cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = ValorOpcional(txtEmail.Text)
        cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 200).Value = ValorOpcional(txtDireccion.Text)
        cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = dtpFechaRegistro.Value
        cmd.Parameters.Add("@estado", SqlDbType.VarChar, 10).Value = cmbEstado.Text.Trim().ToUpperInvariant()
    End Sub

    Private Function ValorOpcional(valor As String) As Object
        If String.IsNullOrWhiteSpace(valor) Then Return DBNull.Value
        Return valor.Trim()
    End Function

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarFormulario()
        modoNuevo = True
        BloquearCampos(False)
        AplicarTipoCliente()
        cmbTipoCliente.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not modoNuevo AndAlso Not modoEdicion Then
            MessageBox.Show("Presione Nuevo para registrar o seleccione un cliente y presione Editar.")
            Return
        End If
        If Not ValidarCliente() Then Return
        Try
            Using cn As New SqlConnection(cadenaConexion)
                cn.Open()
                ' Verificación previa de documento repetido, también al editar.
                Using verificar As New SqlCommand(
                    "SELECT COUNT(*) FROM dbo.CLIENTE WHERE documento=@documento AND id_cliente<>@id", cn)
                    verificar.Parameters.Add("@documento", SqlDbType.VarChar, 20).Value = txtDocumento.Text.Trim()
                    verificar.Parameters.Add("@id", SqlDbType.Int).Value = If(modoEdicion, idSeleccionado, -1)
                    If Convert.ToInt32(verificar.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Este DNI o RUC ya pertenece a otro cliente.", "Documento duplicado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtDocumento.Focus()
                        Return
                    End If
                End Using
                If modoEdicion Then
                    If idSeleccionado <= 0 Then
                        MessageBox.Show("Seleccione primero un cliente.")
                        Return
                    End If
                    Dim sql As String = "UPDATE dbo.CLIENTE SET tipo_cliente=@tipo,nombre=@nombre,apellido=@apellido,razon_social=@razon,documento=@documento,telefono=@telefono,email=@email,direccion=@direccion,fecha_registro=@fecha,estado=@estado WHERE id_cliente=@id"
                    Using cmd As New SqlCommand(sql, cn)
                        AgregarParametros(cmd)
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idSeleccionado
                        If cmd.ExecuteNonQuery() <> 1 Then
                            MessageBox.Show("El cliente ya no existe. Actualice la tabla.")
                            Return
                        End If
                    End Using
                    MessageBox.Show("Cliente modificado correctamente.", "SICEI")
                Else
                    Dim sql As String = "INSERT INTO dbo.CLIENTE (tipo_cliente,nombre,apellido,razon_social,documento,telefono,email,direccion,fecha_registro,estado) OUTPUT INSERTED.id_cliente VALUES (@tipo,@nombre,@apellido,@razon,@documento,@telefono,@email,@direccion,@fecha,@estado)"
                    Using cmd As New SqlCommand(sql, cn)
                        AgregarParametros(cmd)
                        Dim nuevoId As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        MessageBox.Show("Cliente registrado correctamente. ID: " & nuevoId.ToString(), "SICEI")
                    End Using
                End If
            End Using
            CargarClientes()
            LimpiarFormulario()
        Catch ex As SqlException
            If ex.Number = 2627 OrElse ex.Number = 2601 Then
                MessageBox.Show("Ya existe un cliente con un dato que debe ser único: " & ex.Message)
            Else
                MessageBox.Show("Error de SQL Server: " & ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al guardar: " & ex.Message)
        End Try
    End Sub

    Private Function CampoFila(fila As DataGridViewRow, nombreCampo As String) As String
        ' Leer desde la fila de datos, no desde el orden visual de columnas.
        Dim registro As DataRowView = TryCast(fila.DataBoundItem, DataRowView)
        If registro IsNot Nothing AndAlso registro.DataView.Table.Columns.Contains(nombreCampo) Then
            Dim valor As Object = registro(nombreCampo)
            If valor Is Nothing OrElse Convert.IsDBNull(valor) Then Return ""
            Return Convert.ToString(valor)
        End If
        For Each columna As DataGridViewColumn In CLIENTEDataGridView.Columns
            If String.Equals(columna.DataPropertyName, nombreCampo, StringComparison.OrdinalIgnoreCase) Then
                Dim valor As Object = fila.Cells(columna.Index).Value
                If valor Is Nothing OrElse Convert.IsDBNull(valor) Then Return ""
                Return Convert.ToString(valor)
            End If
        Next
        Return ""
    End Function

    Private Sub CLIENTEDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles CLIENTEDataGridView.CellClick
        If cargando OrElse e.RowIndex < 0 Then Return
        Dim fila As DataGridViewRow = CLIENTEDataGridView.Rows(e.RowIndex)
        Dim id As Integer
        If Not Integer.TryParse(CampoFila(fila, "id_cliente"), id) Then
            MessageBox.Show("No se encontró la columna id_cliente. Revise DataPropertyName de la columna ID.")
            Return
        End If
        cargando = True
        Try
            idSeleccionado = id
            modoEdicion = False
            txtIdCliente.Text = id.ToString()
            cmbTipoCliente.SelectedItem = CampoFila(fila, "tipo_cliente").ToUpperInvariant()
            txtNombre.Text = CampoFila(fila, "nombre")
            txtApellido.Text = CampoFila(fila, "apellido")
            txtRazonSocial.Text = CampoFila(fila, "razon_social")
            txtDocumento.Text = CampoFila(fila, "documento")
            txtTelefono.Text = CampoFila(fila, "telefono")
            txtEmail.Text = CampoFila(fila, "email")
            txtDireccion.Text = CampoFila(fila, "direccion")
            cmbEstado.SelectedItem = CampoFila(fila, "estado").ToUpperInvariant()
            Dim fecha As DateTime
            If DateTime.TryParse(CampoFila(fila, "fecha_registro"), fecha) Then dtpFechaRegistro.Value = fecha
        Finally
            cargando = False
        End Try
        BloquearCampos(True)
        AplicarTipoCliente()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If idSeleccionado <= 0 Then
            MessageBox.Show("Haga clic en un cliente de la tabla antes de editar.")
            Return
        End If
        modoNuevo = False
        modoEdicion = True
        BloquearCampos(False)
        AplicarTipoCliente()
        MessageBox.Show("Modifique los campos y presione Guardar para confirmar los cambios.", "Modo edición")
        cmbTipoCliente.Focus()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            CargarClientes()
            LimpiarFormulario()
        Catch ex As Exception
            MessageBox.Show("No se pudo actualizar la tabla: " & ex.Message)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If idSeleccionado <= 0 Then
            MessageBox.Show("Seleccione manualmente el cliente que desea eliminar.")
            Return
        End If
        Dim identificacion As String = If(cmbTipoCliente.Text = "EMPRESA",
                                          txtRazonSocial.Text.Trim(),
                                          (txtNombre.Text & " " & txtApellido.Text).Trim())
        If MessageBox.Show("¿Eliminar DEFINITIVAMENTE a " & identificacion &
                           " (ID " & idSeleccionado.ToString() & ")?" &
                           Environment.NewLine & "Esta acción no se puede deshacer.", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
        Try
            Using cn As New SqlConnection(cadenaConexion)
                cn.Open()
                Using cmd As New SqlCommand("DELETE FROM dbo.CLIENTE WHERE id_cliente=@id", cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idSeleccionado
                    If cmd.ExecuteNonQuery() = 0 Then
                        MessageBox.Show("El cliente ya no existe.")
                    Else
                        MessageBox.Show("Cliente eliminado definitivamente.")
                    End If
                End Using
            End Using
            CargarClientes()
            LimpiarFormulario()
        Catch ex As SqlException When ex.Number = 547
            MessageBox.Show("No se puede eliminar definitivamente este cliente porque existen registros que dependen de él (por ejemplo, ventas o servicios)." & Environment.NewLine & Environment.NewLine &
                            "Para conservar el historial, SQL Server impide el borrado. El cliente permanece sin cambios." & Environment.NewLine &
                            "Si necesita retirarlo de uso, selecciónelo, presione Editar, cambie Estado a INACTIVO y guarde." & Environment.NewLine &
                            "No se eliminarán automáticamente registros relacionados.",
                            "Cliente relacionado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message)
        End Try
    End Sub

    Private Sub CLIENTEDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CLIENTEDataGridView.CellContentClick

    End Sub

    Private Sub grpDatosCliente_Enter(sender As Object, e As EventArgs) Handles grpDatosCliente.Enter

    End Sub
End Class
