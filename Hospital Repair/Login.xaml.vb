﻿Imports MySql.Data.MySqlClient
Imports MaterialDesignThemes.Wpf
Imports System.Data
Public Class Login

    Public Secretaria As New Secretarias
    Public administrador As New Administrador
    Public Doctores As New Doctores
    Dim conexion As New MySqlConnection("host=127.0.0.1; user=root; database=dbturnos")
    Dim consulta As String = String.Empty
    Dim comando As MySqlCommand
    Dim adaptador As MySqlDataAdapter
    Dim tabla As DataTable

    Private Sub Window_mov_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles Window_mov.MouseLeftButtonDown
        DragMove()
    End Sub

    Private Sub btn_sig_Click(sender As Object, e As RoutedEventArgs) Handles btn_sig.Click
        Try
            conexion.Open()
            consulta = "SELECT tipo_usuario, docnom, idusuario FROM usuarios WHERE user='" & Txt_user.Text & "' AND pass='" & Txt_pass.Password & "'"
            comando = New MySqlCommand(consulta, conexion)
            adaptador = New MySqlDataAdapter(comando)
            tabla = New DataTable
            adaptador.Fill(tabla)
            If tabla.Rows.Count = 1 Then
                If tabla.Rows(0)(0).ToString = "Administrador" Then
                    administrador.Admin_Title.Text = tabla.Rows(0)(1).ToString
                    administrador.IDadmin.Text = tabla.Rows(0)(2).ToString
                    administrador.Show()
                    conexion.Close()
                    Me.Close()
                ElseIf tabla.Rows(0)(0).ToString = "Doctor" Then
                    Doctores.Dr_Title.Text = tabla.Rows(0)(1).ToString
                    Doctores.idDr.Text = tabla.Rows(0)(2).ToString
                    Doctores.Show()
                    conexion.Close()
                    Me.Close()
                ElseIf tabla.Rows(0)(0).ToString = "Secretaria" Then
                    Secretaria.Secretaria_Nom.Text = tabla.Rows(0)(1).ToString
                    Secretaria.IDscr.Text = tabla.Rows(0)(2).ToString
                    Secretaria.Show()
                    conexion.Close()
                    Me.Close()
                End If
            ElseIf tabla.Rows.Count > 1 Then
                Dim dlgshw = New MessageDialog
                dlgshw.Message.Text = "El usuario está duplicado, por favor verifique sus credenciales."
                DialogHost.Show(dlgshw, "RootDialog")
            Else
                Dim dlgshw = New MessageDialog
                dlgshw.Message.Text = "Usuario o Contraseña incorrecta"
                DialogHost.Show(dlgshw, "RootDialog")
            End If
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub bnt_close_Click(sender As Object, e As RoutedEventArgs) Handles bnt_close.Click
        Dim dlgclshw = New MessageClsDlg
        dlgclshw.Message.Text = "¿Quieres cerrar el programa?"
        DialogHost.Show(dlgclshw, "RootDialog")
    End Sub

    Private Sub Login_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

    End Sub
End Class
