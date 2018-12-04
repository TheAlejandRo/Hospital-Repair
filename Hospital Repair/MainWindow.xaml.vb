Imports System.ComponentModel
Imports MaterialDesignThemes.Wpf
Class MainWindow

    Private Sub win_mov_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles win_mov.MouseLeftButtonDown
        DragMove()
    End Sub

    Private Sub btn_close_IsEnabledChanged(sender As Object, e As RoutedEventArgs) Handles btn_close.Selected
        Me.Close()
    End Sub

    Private Sub MainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Finalize()
    End Sub
End Class