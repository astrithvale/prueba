Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Form4
    Private esNuevo As Boolean = False
    Private Enum ModoFormulario
        Consulta
        Nuevo
        Edicion
    End Enum

    Private modo As ModoFormulario = ModoFormulario.Consulta
    Private idSeleccionado As Integer = 0
    Private cargando As Boolean = False
    Private ReadOnly cadenaConexion As String = My.Settings.SICEI

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargando = True
            cboEstado.DataBindings.Clear()
            cboEstado.Items.Clear()
            cboEstado.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList
            cboEstado.BackColor = Color.White
            cboEstado.ForeColor = Color.Black
            cboEstado.IntegralHeight = False
            cboEstado.DropDownHeight = 110
            cboEstado.DropDownWidth = Math.Max(cboEstado.Width, 160)

            For Each control As Control In New Control() {txtIdVendedor, txtNombre, txtApellido, txtTelefono, txtEmail}
                control.DataBindings.Clear()
            Next
            txtIdVendedor.ReadOnly = True
            txtTelefono.MaxLength = 9
            VENDEDORDataGridView.ReadOnly = True
            VENDEDORDataGridView.AllowUserToAddRows = False
            VENDEDORDataGridView.AllowUserToDeleteRows = False
            VENDEDORDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            VENDEDORDataGridView.MultiSelect = False
            VENDEDORBindingNavigator.BindingSource = VENDEDORBindingSource
            VENDEDORBindingNavigator.AddNewItem = Nothing
            VENDEDORBindingNavigator.DeleteItem = Nothing
            CargarVendedores()
            modo = ModoFormulario.Consulta
            MostrarSeleccionActual()
        Catch ex As Exception
            MessageBox.Show("No se pudieron cargar los vendedores: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cargando = False
        End Try
    End Sub

    Private Sub CargarVendedores()
        ' Quitar selección automática al iniciar
        VENDEDORDataGridView.ClearSelection()

        ' Limpiar los campos
        LimpiarCampos()

        ' No tener vendedor seleccionado
        idSeleccionado = 0
        SICEIDataSet.VENDEDOR.Clear()
        VENDEDORTableAdapter.Fill(SICEIDataSet.VENDEDOR)
    End Sub

    Private Sub MostrarSeleccionActual()
        If cargando OrElse modo <> ModoFormulario.Consulta Then Return
        Dim vista As DataRowView = TryCast(VENDEDORBindingSource.Current, DataRowView)
        If vista Is Nothing Then
            idSeleccionado = 0
            LimpiarCampos()
            Return
        End If
        idSeleccionado = Convert.ToInt32(vista("id_vendedor"))
        txtIdVendedor.Text = idSeleccionado.ToString()
        txtNombre.Text = Convert.ToString(vista("nombre"))
        txtApellido.Text = Convert.ToString(vista("apellido"))
        txtTelefono.Text = Convert.ToString(vista("telefono"))
        txtEmail.Text = Convert.ToString(vista("email"))
        Dim estado As String = Convert.ToString(vista("estado")).Trim().ToUpperInvariant()
        cboEstado.SelectedIndex = cboEstado.FindStringExact(estado)
    End Sub

    Private Sub VENDEDORBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles VENDEDORBindingSource.CurrentChanged
        MostrarSeleccionActual()
    End Sub

    Private Sub LimpiarCampos()
        txtIdVendedor.Clear()
        txtNombre.Clear()
        txtApellido.Clear()
        txtTelefono.Clear()
        txtEmail.Clear()
        If cboEstado.Items.Count > 0 Then cboEstado.SelectedIndex = 0
    End Sub

    Private Function TieneDatosNuevos() As Boolean
        Return txtNombre.Text.Trim() <> "" OrElse
               txtApellido.Text.Trim() <> "" OrElse
               txtTelefono.Text.Trim() <> "" OrElse
               txtEmail.Text.Trim() <> "" OrElse
               cboEstado.Text <> "ACTIVO"
    End Function

    Private Function PuedeAbandonarCambios() As Boolean
        If modo = ModoFormulario.Nuevo Then
            If Not TieneDatosNuevos() Then Return True
        ElseIf modo = ModoFormulario.Edicion Then
            Dim vista As DataRowView = TryCast(VENDEDORBindingSource.Current, DataRowView)
            If vista IsNot Nothing AndAlso
               txtNombre.Text = Convert.ToString(vista("nombre")) AndAlso
               txtApellido.Text = Convert.ToString(vista("apellido")) AndAlso
               txtTelefono.Text = Convert.ToString(vista("telefono")) AndAlso
               txtEmail.Text = Convert.ToString(vista("email")) AndAlso
               cboEstado.Text = Convert.ToString(vista("estado")).Trim().ToUpperInvariant() Then Return True
        Else
            Return True
        End If
        Return MessageBox.Show("Hay datos sin guardar. ¿Desea descartarlos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
    End Function

    Private Sub VolverAConsulta()
        modo = ModoFormulario.Consulta
        txtIdVendedor.ReadOnly = True
        MostrarSeleccionActual()
    End Sub

    Private Function ValidarDatos() As Boolean
        If Not Regex.IsMatch(txtNombre.Text.Trim(), "^[\p{L}\s'-]+$") Then
            MessageBox.Show("Ingrese un nombre válido, solo con letras.")
            txtNombre.Focus()
            Return False
        End If
        If Not Regex.IsMatch(txtApellido.Text.Trim(), "^[\p{L}\s'-]+$") Then
            MessageBox.Show("Ingrese un apellido válido, solo con letras.")
            txtApellido.Focus()
            Return False
        End If
        If Not Regex.IsMatch(txtTelefono.Text.Trim(), "^9[0-9]{8}$") Then
            MessageBox.Show("El celular debe tener 9 dígitos y empezar con 9.")
            txtTelefono.Focus()
            Return False
        End If
        If Not Regex.IsMatch(txtEmail.Text.Trim(), "^[^@\s]+@[^@\s]+\.[^@\s]+$") Then
            MessageBox.Show("Ingrese un correo electrónico válido.")
            txtEmail.Focus()
            Return False
        End If
        If cboEstado.SelectedIndex < 0 Then
            MessageBox.Show("Seleccione ACTIVO o INACTIVO.")
            cboEstado.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SeleccionarPorID(id As Integer)
        Dim posicion As Integer = VENDEDORBindingSource.Find("id_vendedor", id)
        If posicion >= 0 Then VENDEDORBindingSource.Position = posicion
        MostrarSeleccionActual()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If Not PuedeAbandonarCambios() Then Return
        modo = ModoFormulario.Nuevo
        LimpiarCampos()
        txtIdVendedor.Text = "Automático"
        txtIdVendedor.ReadOnly = True
        txtNombre.Focus()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If modo = ModoFormulario.Edicion Then
            GuardarEdicion()
            Return
        End If
        If modo <> ModoFormulario.Nuevo Then
            MessageBox.Show("Presione Nuevo para registrar un vendedor, o Editar para modificarlo.")
            Return
        End If
        If Not ValidarDatos() Then Return
        Try
            Dim nuevoID As Integer
            Using cn As New SqlConnection(cadenaConexion)
                Dim sql As String = "INSERT INTO dbo.VENDEDOR (nombre, apellido, telefono, email, estado) " &
                                    "OUTPUT INSERTED.id_vendedor VALUES (@nombre, @apellido, @telefono, @email, @estado)"
                Using cmd As New SqlCommand(sql, cn)
                    AgregarParametros(cmd)
                    cn.Open()
                    nuevoID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
            modo = ModoFormulario.Consulta
            CargarVendedores()
            SeleccionarPorID(nuevoID)
            MessageBox.Show("Vendedor registrado correctamente. ID: " & nuevoID, "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al registrar vendedor: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AgregarParametros(cmd As SqlCommand)
        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = txtNombre.Text.Trim()
        cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 100).Value = txtApellido.Text.Trim()
        cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 9).Value = txtTelefono.Text.Trim()
        cmd.Parameters.Add("@email", SqlDbType.VarChar, 150).Value = txtEmail.Text.Trim()
        cmd.Parameters.Add("@estado", SqlDbType.VarChar, 10).Value = cboEstado.Text
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If modo = ModoFormulario.Nuevo Then
            If Not PuedeAbandonarCambios() Then Return
            VolverAConsulta()
        End If
        If idSeleccionado <= 0 Then
            MessageBox.Show("Seleccione primero un vendedor de la tabla.")
            Return
        End If
        If modo = ModoFormulario.Edicion Then
            GuardarEdicion()
        Else
            modo = ModoFormulario.Edicion
            txtIdVendedor.ReadOnly = True
            txtNombre.Focus()
            MessageBox.Show("Modifique los datos y presione Guardar o Editar para actualizar.")
        End If
    End Sub

    Private Sub GuardarEdicion()
        If modo <> ModoFormulario.Edicion OrElse idSeleccionado <= 0 Then Return
        If Not ValidarDatos() Then Return
        If MessageBox.Show("¿Desea guardar los cambios del vendedor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Dim filas As Integer
            Using cn As New SqlConnection(cadenaConexion)
                Dim sql As String = "UPDATE dbo.VENDEDOR SET nombre=@nombre, apellido=@apellido, telefono=@telefono, email=@email, estado=@estado WHERE id_vendedor=@id"
                Using cmd As New SqlCommand(sql, cn)
                    AgregarParametros(cmd)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idSeleccionado
                    cn.Open()
                    filas = cmd.ExecuteNonQuery()
                End Using
            End Using
            If filas = 0 Then
                MessageBox.Show("No se encontró el vendedor en SQL Server.")
                VolverAConsulta()
                Return
            End If
            Dim id As Integer = idSeleccionado
            modo = ModoFormulario.Consulta
            CargarVendedores()
            SeleccionarPorID(id)
            MessageBox.Show("Vendedor actualizado correctamente.")
        Catch ex As Exception
            MessageBox.Show("Error al editar: " & ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs)
        If Not PuedeAbandonarCambios() Then Return
        Dim valor As String = InputBox("Ingrese el ID, nombre o apellido del vendedor:", "Buscar vendedor").Trim()
        If valor = "" Then Return
        Try
            modo = ModoFormulario.Consulta
            CargarVendedores()
            Dim coincidencias As New List(Of Integer)
            For i As Integer = 0 To VENDEDORBindingSource.Count - 1
                Dim vista As DataRowView = TryCast(VENDEDORBindingSource(i), DataRowView)
                If vista IsNot Nothing Then
                    Dim idTexto As String = Convert.ToString(vista("id_vendedor"))
                    Dim nombre As String = Convert.ToString(vista("nombre"))
                    Dim apellido As String = Convert.ToString(vista("apellido"))
                    If idTexto = valor OrElse nombre.IndexOf(valor, StringComparison.OrdinalIgnoreCase) >= 0 OrElse apellido.IndexOf(valor, StringComparison.OrdinalIgnoreCase) >= 0 OrElse (nombre & " " & apellido).IndexOf(valor, StringComparison.OrdinalIgnoreCase) >= 0 Then
                        coincidencias.Add(i)
                    End If
                End If
            Next
            If coincidencias.Count = 0 Then
                MostrarSeleccionActual()
                MessageBox.Show("No se encontraron vendedores con ese criterio.")
            Else
                VENDEDORBindingSource.Position = coincidencias(0)
                MostrarSeleccionActual()
                If coincidencias.Count > 1 Then MessageBox.Show("Se encontraron " & coincidencias.Count.ToString() & " coincidencias. Se muestra la primera.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar: " & ex.Message)
        End Try
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        If Not PuedeAbandonarCambios() Then Return
        If MessageBox.Show("¿Desea salir del formulario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then Me.Close()
    End Sub


    ' ==========================================
    ' BOTÓN ELIMINAR - ELIMINACIÓN DEFINITIVA
    ' ==========================================
    Private Sub btnEliminar_Click(sender As Object,
                              e As EventArgs) Handles btnEliminar.Click

        If esNuevo Then
            MessageBox.Show(
            "Primero cancele el registro nuevo.",
            "Aviso",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
            Exit Sub
        End If

        If idSeleccionado <= 0 Then
            MessageBox.Show("Seleccione un vendedor para eliminar.")
            Exit Sub
        End If

        Dim idEliminar As Integer = idSeleccionado

        Dim respuesta As DialogResult =
        MessageBox.Show(
            "¿Está seguro de eliminar DEFINITIVAMENTE al vendedor " &
            txtNombre.Text.Trim() & " " &
            txtApellido.Text.Trim() & " (ID: " &
            idEliminar.ToString() & ")?" &
            vbCrLf & vbCrLf &
            "Esta acción no se puede deshacer.",
            "Confirmar eliminación definitiva",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2)

        If respuesta <> DialogResult.Yes Then Exit Sub

        Try
            Using cn As New SqlConnection(cadenaConexion)

                Dim sql As String =
                "DELETE FROM dbo.VENDEDOR " &
                "WHERE id_vendedor = @id"

                Using cmd As New SqlCommand(sql, cn)

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value =
                    idEliminar

                    cn.Open()

                    Dim filas As Integer = cmd.ExecuteNonQuery()

                    If filas = 0 Then
                        MessageBox.Show(
                        "El vendedor ya no existe.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                        CargarVendedores()
                        Exit Sub
                    End If

                End Using
            End Using

            idSeleccionado = 0
            esNuevo = False

            CargarVendedores()

            MessageBox.Show(
            "Vendedor eliminado definitivamente.",
            "Eliminación exitosa",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)

        Catch ex As SqlException When ex.Number = 547

            MessageBox.Show(
            "No se puede eliminar este vendedor porque " &
            "tiene registros relacionados en la base de datos." &
            vbCrLf &
            "No se ha eliminado ningún registro.",
            "Eliminación bloqueada",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

        Catch ex As Exception

            MessageBox.Show(
            "Error al eliminar: " & ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)

        End Try

    End Sub


    ' ==========================================
    ' SELECCIONAR VENDEDOR MANUALMENTE
    ' ==========================================
    Private Sub VENDEDORDataGridView_CellClick(
    sender As Object,
    e As DataGridViewCellEventArgs
) Handles VENDEDORDataGridView.CellClick

        If e.RowIndex < 0 Then Exit Sub

        If esNuevo Then Exit Sub

        Try

            Dim fila As DataGridViewRow =
                VENDEDORDataGridView.Rows(e.RowIndex)

            If fila.IsNewRow Then Exit Sub

            ' Obtener el registro vinculado a la fila
            Dim vista As DataRowView =
                TryCast(fila.DataBoundItem, DataRowView)

            If vista Is Nothing Then Exit Sub

            ' Obtener el ID directamente del DataSet
            idSeleccionado =
                Convert.ToInt32(vista("id_vendedor"))

            ' Mostrar los datos del vendedor
            txtIdVendedor.Text = idSeleccionado.ToString()

            txtNombre.Text =
                Convert.ToString(vista("nombre"))

            txtApellido.Text =
                Convert.ToString(vista("apellido"))

            txtTelefono.Text =
                Convert.ToString(vista("telefono"))

            txtEmail.Text =
                Convert.ToString(vista("email"))

            cboEstado.SelectedItem =
                Convert.ToString(vista("estado")).Trim().ToUpper()

            ' Mantener el ID bloqueado
            txtIdVendedor.ReadOnly = True

        Catch ex As Exception

            MessageBox.Show(
                "Error al seleccionar vendedor: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        End Try

    End Sub

    ' ==========================================
    ' QUITAR SELECCIÓN AL MOSTRAR EL FORMULARIO
    ' ==========================================
    Private Sub Form4_Shown(sender As Object,
                    e As EventArgs) Handles MyBase.Shown

        VENDEDORDataGridView.ClearSelection()
        VENDEDORDataGridView.CurrentCell = Nothing

        idSeleccionado = 0
        esNuevo = False

        LimpiarCampos()
        txtIdVendedor.ReadOnly = True

    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged

    End Sub
End Class
