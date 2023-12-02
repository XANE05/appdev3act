Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.IO

Public Class Form1
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        regform.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Please complete required fields!!!", vbExclamation)
        Else
            Dim SQLSTATEMENT As String = "SELECT * FROM `user` WHERE Username = '" & TextBox1.Text & "' and Password = '" & TextBox2.Text & "'"
            searchrecord(SQLSTATEMENT)
            Main.searchrec(SQLSTATEMENT)
            Me.Hide()
        End If
    End Sub


End Class
