Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub btnAcceder_Click(sender As Object, e As EventArgs)
        ' 1. Validar que los campos no estén vacíos
        If String.IsNullOrWhiteSpace(txtUsuario.Text) OrElse String.IsNullOrWhiteSpace(txtContraseña.Text) Then
            MessageBox.Show("Por favor, ingrese el usuario y la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 2. Conexión y consulta a la base de datos SQL Server
        Try
            Dim cadenaConexion As String = "Data Source=DESKTOP-JUFFJEL\SQLEXPRESS;Initial Catalog=SICEI;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"

            Using cn As New SqlConnection(cadenaConexion)
                ' Usamos los nombres correctos de tus cajas de texto (txtUsuario y txtContraseña)
                Dim sql As String = "SELECT * FROM USUARIO WHERE nombre_usuario = @usuario AND clave = @clave"

                Using cmd As New SqlCommand(sql, cn)
                    ' Parámetros de seguridad para evitar inyección SQL
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim())
                    cmd.Parameters.AddWithValue("@clave", txtContraseña.Text.Trim())

                    cn.Open()
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            MessageBox.Show("¡Bienvenido al sistema!", "Mak Pc Enterprises", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Abrir el formulario principal (Cambia Form1 por el nombre real de tu form principal si es diferente)
                            Dim principal As New frm1()
                            principal.Show()
                            principal.BringToFront()

                            ' Ocultar la ventana de login actual
                            Me.Hide()
                        Else
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Mak Pc Enterprises", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtContraseña.Clear()
                            txtContraseña.Focus()
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error de conexión: " & ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que deseas salir del sistema?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub


    Private Sub picVer_Click(sender As Object, e As EventArgs)

        txtContraseña.UseSystemPasswordChar = Not txtContraseña.UseSystemPasswordChar
    End Sub

    Private Sub txtUsuario_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtContraseña_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub pnlDerecho_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Label4_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class

