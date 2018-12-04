Public Class MssgSsCls
    Private Sub Cls_ss_Click(sender As Object, e As RoutedEventArgs) Handles Cls_ss.Click
        Dim ventana As New Login
        ventana.Show()
        My.Windows.Administrador.Close()
    End Sub
End Class
