
Imports System.Drawing.Drawing2D
Public Class frm1

    Private Sub lblMinimizar_Click(sender As Object, e As EventArgs)
        ' Minimiza la ventana principal
        Me.WindowState = FormWindowState.Minimized
    End Sub


    Private Sub lblMaximizar_Click(sender As Object, e As EventArgs)
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub lblCerrar_Click(sender As Object, e As EventArgs)
        Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que deseas salir del sistema SICEI?", "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            Application.Exit() ' Cierra completamente la aplicación 
        End If
    End Sub


    Private Sub picCampana_Click(sender As Object, e As EventArgs)
        MessageBox.Show("No hay notificaciones nuevas en el sistema.", "Notificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub picCandado_Click(sender As Object, e As EventArgs)
        Dim resultado As DialogResult = MessageBox.Show("¿Deseas bloquear la sesión actual?", "Bloquear Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resultado = DialogResult.Yes Then
            ' Oculta el formulario principal y muestra el login (Form2)
            Me.Hide()
            Dim login As New Form2()
            login.Show()
        End If
    End Sub

    Private Sub lblUsuario_Click(sender As Object, e As EventArgs)

        MessageBox.Show("Sesión iniciada como: Administrador" & vbCrLf & "Sistema SICEI - MACK PC", "Información de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


End Class