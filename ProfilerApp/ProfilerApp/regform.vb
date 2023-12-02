Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class regform
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub regform_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SQLSTATEMENT As String = "INSERT INTO `user`(`Fullname`, `Email`, `Username`, `Password`) VALUES ('" & fname.Text & "','" & email.Text & "','" & uname.Text & "','" & pass.Text & "')"
        save(SQLSTATEMENT)
        MsgBox("User save successfully!", vbInformation)
        cleardata()
    End Sub

    Public Sub cleardata()
        fname.Text = ""
        email.Text = ""
        uname.Text = ""
        pass.Text = ""
    End Sub
End Class