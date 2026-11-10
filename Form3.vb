Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions

Public Class Form3

    Private Enum ModoFormulario
        Consulta
        Nuevo
        Edicion
    End Enum

    Private modo As ModoFormulario = ModoFormulario.Consulta
    Private idSeleccionado As Integer = 0
    Private cargando As Boolean = False
    Private ReadOnly cadenaConexion As String = My.Settings.SICEI

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargando = True
            ' Los controles son independientes de los enlaces automáticos.
            ConfigurarControles()
            CargarUsuarios()
            modo = ModoFormulario.Consulta
            AplicarModo()
            BeginInvoke(New MethodInvoker(Sub()
                                              If modo = ModoFormulario.Consulta AndAlso idSeleccionado = 0 Then
                                                  QuitarSeleccion()
                                                  LimpiarCampos()
                                              End If
                                          End Sub))
        Catch ex As Exception
            MessageBox.Show("Error al cargar usuarios: " & ex.Message, "SICEI", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cargando = False
        End Try
    End Sub

    Private Sub ConfigurarControles()
        ' Se retiran enlaces Text/SelectedValue para que no escriban en el DataSet.
        Id_usuarioTextBox.DataBindings.Clear()
        Nombre_usuarioTextBox.DataBindings.Clear()
        ClaveTextBox.DataBindings.Clear()
        Nombre_completoTextBox.DataBindings.Clear()
        cmbRol.DataBindings.Clear()
        cmbEstado.DataBindings.Clear()
        Fecha_registroDateTimePicker.DataBindings.Clear()

        cmbRol.DataSource = Nothing
        cmbEstado.DataSource = Nothing
        cmbRol.Items.Clear()
        cmbRol.Items.AddRange(New Object() {"ADMIN", "RECEPCIONISTA", "CAJERO", "ALMACEN", "TECNICO", "TECNICO_LIDER", "VENDEDOR"})
        cmbEstado.Items.Clear()
        cmbEstado.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        For Each combo As ComboBox In New ComboBox() {cmbRol, cmbEstado}
            combo.DropDownStyle = ComboBoxStyle.DropDownList
            combo.DrawMode = DrawMode.Normal
            combo.ForeColor = System.Drawing.Color.Black
            combo.BackColor = System.Drawing.Color.White
            combo.IntegralHeight = False
            combo.DropDownHeight = 150
            combo.DropDownWidth = Math.Max(combo.Width, 170)
        Next

        Id_usuarioTextBox.ReadOnly = True
        ClaveTextBox.UseSystemPasswordChar = True
        Nombre_usuarioTextBox.MaxLength = 50
        Nombre_completoTextBox.MaxLength = 150
        ClaveTextBox.MaxLength = 200
        Fecha_registroDateTimePicker.Format = DateTimePickerFormat.Short
        Fecha_registroDateTimePicker.Enabled = False

        ' Impide crear registros directamente en la tabla.
        USUARIODataGridView.ReadOnly = True
        USUARIODataGridView.AllowUserToAddRows = False
        USUARIODataGridView.AllowUserToDeleteRows = False
        USUARIODataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        USUARIODataGridView.MultiSelect = False
        For Each columna As DataGridViewColumn In USUARIODataGridView.Columns
            If String.Equals(columna.DataPropertyName, "clave", StringComparison.OrdinalIgnoreCase) Then
                columna.Visible = False
            End If
        Next
        USUARIOBindingNavigator.AddNewItem = Nothing
        USUARIOBindingNavigator.DeleteItem = Nothing
        USUARIOBindingNavigatorSaveItem.Enabled = False
    End Sub

    Private Sub CargarUsuarios(Optional seleccionarId As Integer = 0)
        cargando = True
        Try
            SICEIDataSet1.USUARIO.Clear()
            USUARIOTableAdapter1.Fill(SICEIDataSet1.USUARIO)

            If seleccionarId > 0 Then
                Dim posicion As Integer = USUARIOBindingSource.Find("id_usuario", seleccionarId)
                If posicion >= 0 Then
                    USUARIOBindingSource.Position = posicion
                    SeleccionarFilaPorId(seleccionarId)
                Else
                    idSeleccionado = 0
                    QuitarSeleccion()
                End If
            Else
                idSeleccionado = 0
                QuitarSeleccion()
            End If
        Finally
            cargando = False
        End Try

        If seleccionarId > 0 AndAlso idSeleccionado <> 0 Then
            MostrarUsuarioActual()
        Else
            LimpiarCampos()
            AplicarModo()
        End If
    End Sub

    Private Sub QuitarSeleccion()
        USUARIODataGridView.ClearSelection()
        USUARIODataGridView.CurrentCell = Nothing
    End Sub

    Private Sub SeleccionarFilaPorId(id As Integer)
        For Each fila As DataGridViewRow In USUARIODataGridView.Rows
            Dim registro As DataRowView = TryCast(fila.DataBoundItem, DataRowView)
            If registro IsNot Nothing AndAlso Convert.ToInt32(registro("id_usuario")) = id Then
                USUARIODataGridView.ClearSelection()
                fila.Selected = True
                If fila.Visible Then USUARIODataGridView.FirstDisplayedScrollingRowIndex = fila.Index
                idSeleccionado = id
                Exit Sub
            End If
        Next
    End Sub

    Private Sub AplicarModo()
        Dim editable As Boolean = (modo <> ModoFormulario.Consulta)
        Id_usuarioTextBox.ReadOnly = True
        Nombre_usuarioTextBox.ReadOnly = Not editable
        ClaveTextBox.ReadOnly = Not editable
        Nombre_completoTextBox.ReadOnly = Not editable
        cmbRol.Enabled = editable
        cmbEstado.Enabled = editable
        Fecha_registroDateTimePicker.Enabled = (modo = ModoFormulario.Edicion)
        btnEliminar.Enabled = (modo = ModoFormulario.Consulta AndAlso idSeleccionado > 0)
        btnGuardar.Enabled = editable
        btnEditar.Enabled = (modo = ModoFormulario.Consulta AndAlso idSeleccionado > 0)
        USUARIODataGridView.Enabled = True
        USUARIOBindingNavigator.Enabled = (modo = ModoFormulario.Consulta)
    End Sub

    Private Sub LimpiarCampos()
        Id_usuarioTextBox.Text = If(modo = ModoFormulario.Nuevo, "Automático", "")
        Nombre_usuarioTextBox.Clear()
        ClaveTextBox.Clear()
        Nombre_completoTextBox.Clear()
        cmbRol.SelectedIndex = -1
        cmbEstado.SelectedItem = "ACTIVO"
        Fecha_registroDateTimePicker.Value = DateTime.Now
    End Sub

    Private Sub MostrarUsuarioActual()
        If cargando OrElse modo <> ModoFormulario.Consulta Then Return
        If idSeleccionado <= 0 Then
            LimpiarCampos()
            AplicarModo()
            Return
        End If
        Dim posicion As Integer = USUARIOBindingSource.Find("id_usuario", idSeleccionado)
        If posicion < 0 Then
            idSeleccionado = 0
            LimpiarCampos()
            AplicarModo()
            Return
        End If
        Dim fila As DataRowView = TryCast(USUARIOBindingSource(posicion), DataRowView)
        If fila Is Nothing Then Return
        Id_usuarioTextBox.Text = idSeleccionado.ToString()
        Nombre_usuarioTextBox.Text = Convert.ToString(fila("nombre_usuario"))
        Nombre_completoTextBox.Text = Convert.ToString(fila("nombre_completo"))
        ClaveTextBox.Clear() ' No mostrar contraseñas ni hashes.
        SeleccionarCombo(cmbRol, Convert.ToString(fila("rol")))
        SeleccionarCombo(cmbEstado, Convert.ToString(fila("estado")))
        If Not IsDBNull(fila("fecha_registro")) Then
            Fecha_registroDateTimePicker.Value = Convert.ToDateTime(fila("fecha_registro"))
        End If
        AplicarModo()
    End Sub

    Private Sub SeleccionarCombo(combo As ComboBox, valor As String)
        Dim indice As Integer = combo.FindStringExact(valor.Trim())
        combo.SelectedIndex = indice
    End Sub

    ' Selección manual; no depende del nombre de las columnas visuales.
    Private Sub USUARIODataGridView_CellClick(sender As Object,
        e As DataGridViewCellEventArgs) Handles USUARIODataGridView.CellClick

        If cargando OrElse e.RowIndex < 0 Then Return
        Dim fila As DataGridViewRow = USUARIODataGridView.Rows(e.RowIndex)
        If fila.IsNewRow Then Return
        Dim registro As DataRowView = TryCast(fila.DataBoundItem, DataRowView)
        If registro Is Nothing Then Return
        Dim nuevoId As Integer = Convert.ToInt32(registro("id_usuario"))

        If modo <> ModoFormulario.Consulta Then
            If Not ConfirmarDescarte() Then Return
        End If
        modo = ModoFormulario.Consulta
        idSeleccionado = nuevoId
        Dim posicion As Integer = USUARIOBindingSource.Find("id_usuario", nuevoId)
        If posicion >= 0 Then USUARIOBindingSource.Position = posicion
        USUARIODataGridView.ClearSelection()
        fila.Selected = True
        MostrarUsuarioActual()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If Not ConfirmarDescarte() Then Return
        modo = ModoFormulario.Nuevo
        idSeleccionado = 0
        LimpiarCampos()
        AplicarModo()
        Nombre_usuarioTextBox.Focus()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If idSeleccionado <= 0 Then
            MessageBox.Show("Seleccione un usuario para editar.")
            Return
        End If
        If Not ConfirmarDescarte() Then Return
        modo = ModoFormulario.Edicion
        ClaveTextBox.Clear() ' Vacía = conservar contraseña anterior.
        AplicarModo()
        Nombre_usuarioTextBox.Focus()
    End Sub

    Private Function ValidarDatos() As Boolean
        Dim nombreUsuario As String = Nombre_usuarioTextBox.Text.Trim()
        Dim nombreCompleto As String = Nombre_completoTextBox.Text.Trim()
        If Not Regex.IsMatch(nombreUsuario, "^[\p{L}\p{N}._\s-]{3,50}$") Then
            MessageBox.Show("El nombre de usuario debe tener entre 3 y 50 caracteres: letras, números, espacios, punto, guion o guion bajo.")
            Nombre_usuarioTextBox.Focus()
            Return False
        End If
        If Not Regex.IsMatch(nombreCompleto, "^[\p{L}][\p{L}\s'-]*$") Then
            MessageBox.Show("El nombre completo solo puede contener letras, espacios, apóstrofes o guiones.")
            Nombre_completoTextBox.Focus()
            Return False
        End If
        If cmbRol.SelectedIndex < 0 OrElse cmbEstado.SelectedIndex < 0 Then
            MessageBox.Show("Seleccione el rol y el estado.")
            Return False
        End If
        If (modo = ModoFormulario.Nuevo OrElse ClaveTextBox.Text.Length > 0) AndAlso ClaveTextBox.Text.Length < 8 Then
            MessageBox.Show("La contraseña debe tener al menos 8 caracteres.")
            ClaveTextBox.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function HashClave(clave As String) As String
        Dim salt(15) As Byte
        Using rng As RandomNumberGenerator = RandomNumberGenerator.Create()
            rng.GetBytes(salt)
        End Using
        Const iteraciones As Integer = 120000
        Using derivador As New Rfc2898DeriveBytes(clave, salt, iteraciones, HashAlgorithmName.SHA256)
            Return "PBKDF2-SHA256$" & iteraciones.ToString() & "$" &
                Convert.ToBase64String(salt) & "$" & Convert.ToBase64String(derivador.GetBytes(32))
        End Using
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If modo = ModoFormulario.Consulta Then Return
        If Not ValidarDatos() Then Return
        Try
            Dim idGuardado As Integer = idSeleccionado
            Using cn As New SqlConnection(cadenaConexion)
                cn.Open()
                Using comprobar As New SqlCommand("SELECT COUNT(*) FROM dbo.USUARIO WHERE nombre_usuario = @nombre AND id_usuario <> @id", cn)
                    comprobar.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = Nombre_usuarioTextBox.Text.Trim()
                    comprobar.Parameters.Add("@id", SqlDbType.Int).Value = If(modo = ModoFormulario.Nuevo, 0, idSeleccionado)
                    If Convert.ToInt32(comprobar.ExecuteScalar()) > 0 Then
                        MessageBox.Show("Este nombre de usuario ya está registrado.")
                        Return
                    End If
                End Using

                Dim sql As String
                If modo = ModoFormulario.Nuevo Then
                    sql = "INSERT INTO dbo.USUARIO (nombre_usuario, clave, nombre_completo, rol, estado, fecha_registro) " &
                          "OUTPUT INSERTED.id_usuario VALUES (@nombre, @clave, @completo, @rol, @estado, @fecha)"
                Else
                    sql = "UPDATE dbo.USUARIO SET nombre_usuario=@nombre, nombre_completo=@completo, rol=@rol, estado=@estado"
                    If ClaveTextBox.Text.Length > 0 Then sql &= ", clave=@clave"
                    sql &= ", fecha_registro=@fecha WHERE id_usuario=@id"
                End If
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = Nombre_usuarioTextBox.Text.Trim()
                    cmd.Parameters.Add("@completo", SqlDbType.VarChar, 150).Value = Nombre_completoTextBox.Text.Trim()
                    cmd.Parameters.Add("@rol", SqlDbType.VarChar, 30).Value = cmbRol.Text
                    cmd.Parameters.Add("@estado", SqlDbType.VarChar, 10).Value = cmbEstado.Text
                    cmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Fecha_registroDateTimePicker.Value
                    If modo = ModoFormulario.Nuevo OrElse ClaveTextBox.Text.Length > 0 Then
                        cmd.Parameters.Add("@clave", SqlDbType.VarChar, 255).Value = HashClave(ClaveTextBox.Text)
                    End If
                    If modo = ModoFormulario.Nuevo Then
                        idGuardado = Convert.ToInt32(cmd.ExecuteScalar())
                    Else
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idSeleccionado
                        If cmd.ExecuteNonQuery() = 0 Then
                            MessageBox.Show("El usuario ya no existe en la base de datos.")
                            Return
                        End If
                    End If
                End Using
            End Using
            modo = ModoFormulario.Consulta
            CargarUsuarios(idGuardado)
            AplicarModo()
            MessageBox.Show("Usuario guardado correctamente. ID: " & idGuardado.ToString(), "SICEI", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As SqlException When ex.Number = 2601 OrElse ex.Number = 2627
            MessageBox.Show("El nombre de usuario ya existe o se incumplió una restricción única.")
        Catch ex As Exception
            MessageBox.Show("No se pudo guardar: " & ex.Message, "SICEI", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs)
        If Not ConfirmarDescarte() Then Return
        Dim termino As String = InputBox("Ingrese el nombre del usuario que desea buscar:", "Buscar usuario").Trim()
        If termino.Length = 0 Then Return
        Try
            Dim encontrado As Integer = 0
            Using cn As New SqlConnection(cadenaConexion)
                Using cmd As New SqlCommand(
                    "SELECT TOP (1) id_usuario FROM dbo.USUARIO " &
                    "WHERE UPPER(nombre_usuario) LIKE @patron OR UPPER(nombre_completo) LIKE @patron " &
                    "ORDER BY id_usuario", cn)
                    Dim patron As String = "%" & termino.ToUpperInvariant().Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]") & "%"
                    cmd.Parameters.Add("@patron", SqlDbType.NVarChar, 300).Value = patron
                    cn.Open()
                    Dim resultado As Object = cmd.ExecuteScalar()
                    If resultado IsNot Nothing Then encontrado = Convert.ToInt32(resultado)
                End Using
            End Using
            If encontrado = 0 Then
                MessageBox.Show("No se encontraron usuarios con ese texto.")
                Return
            End If
            modo = ModoFormulario.Consulta
            CargarUsuarios(encontrado)
            MessageBox.Show("Usuario encontrado.")
        Catch ex As Exception
            MessageBox.Show("Error al buscar: " & ex.Message)
        End Try
    End Sub


    ' Permite abandonar un registro vacío sin advertencia.
    Private Function ConfirmarDescarte() As Boolean
        If modo = ModoFormulario.Consulta Then Return True
        Dim hayCambios As Boolean
        If modo = ModoFormulario.Nuevo Then
            hayCambios = Nombre_usuarioTextBox.Text.Trim() <> "" OrElse
                         ClaveTextBox.Text <> "" OrElse
                         Nombre_completoTextBox.Text.Trim() <> "" OrElse
                         cmbRol.SelectedIndex >= 0 OrElse
                         cmbEstado.Text <> "ACTIVO"
        Else
            Dim actual As DataRowView = TryCast(USUARIOBindingSource.Current, DataRowView)
            If actual Is Nothing Then Return True
            hayCambios = Nombre_usuarioTextBox.Text.Trim() <> Convert.ToString(actual("nombre_usuario")).Trim() OrElse
                         Nombre_completoTextBox.Text.Trim() <> Convert.ToString(actual("nombre_completo")).Trim() OrElse
                         ClaveTextBox.Text.Length > 0 OrElse
                         cmbRol.Text <> Convert.ToString(actual("rol")).Trim() OrElse
                         cmbEstado.Text <> Convert.ToString(actual("estado")).Trim() OrElse
                         Fecha_registroDateTimePicker.Value.Date <> Convert.ToDateTime(actual("fecha_registro")).Date
        End If
        If hayCambios AndAlso MessageBox.Show("Hay cambios sin guardar. ¿Desea descartarlos?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return False
        End If
        modo = ModoFormulario.Consulta
        If idSeleccionado > 0 Then
            MostrarUsuarioActual()
        Else
            LimpiarCampos()
            QuitarSeleccion()
            AplicarModo()
        End If
        Return True
    End Function

    ' Eliminación física: SQL Server conserva la integridad referencial.
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If modo <> ModoFormulario.Consulta Then
            If Not ConfirmarDescarte() Then Return
        End If
        If idSeleccionado <= 0 Then
            MessageBox.Show("Seleccione un usuario de la tabla.", "SICEI")
            Return
        End If

        Dim idEliminar As Integer = idSeleccionado
        Dim nombreEliminar As String = Nombre_usuarioTextBox.Text.Trim()
        Dim respuesta As DialogResult = MessageBox.Show(
            "¿Eliminar DEFINITIVAMENTE al usuario '" & nombreEliminar & "' (ID " & idEliminar & ")?" &
            Environment.NewLine & "Esta operación no se puede deshacer.",
            "Confirmar eliminación definitiva", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2)
        If respuesta <> DialogResult.Yes Then Return

        Try
            Using cn As New SqlConnection(cadenaConexion)
                Using cmd As New SqlCommand("DELETE FROM dbo.USUARIO WHERE id_usuario=@id", cn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEliminar
                    cn.Open()
                    If cmd.ExecuteNonQuery() = 0 Then
                        MessageBox.Show("El usuario ya no existe en SQL Server.", "SICEI")
                    Else
                        MessageBox.Show("Usuario eliminado definitivamente.", "SICEI",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using
            idSeleccionado = 0
            modo = ModoFormulario.Consulta
            CargarUsuarios()
            QuitarSeleccion()
        Catch ex As SqlException When ex.Number = 547
            MessageBox.Show("No se puede eliminar este usuario porque tiene registros relacionados " &
                            "(por ejemplo, ventas, servicios o diagnósticos). " &
                            "No se borró ningún dato. No se eliminarán registros relacionados automáticamente.",
                            "Usuario con relaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message, "SICEI",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Nombre_completoTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Nombre_completoTextBox.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) AndAlso
           e.KeyChar <> " "c AndAlso e.KeyChar <> "'"c AndAlso e.KeyChar <> "-"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("¿Desea salir del módulo de usuarios?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub cmbRol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRol.SelectedIndexChanged

    End Sub

    Private Sub Fecha_registroLabel_Click(sender As Object, e As EventArgs)

    End Sub
End Class
