Imports MySql.Data.MySqlClient
Imports System.Configuration
Public Class Main

    Public Sub searchrec(ByRef SQLSTATEMENT As String)
        SQLCONN.ConnectionString = con
        If SQLCONN.State = ConnectionState.Closed Then

            SQLCONN.Open()

            Dim dt As New DataTable
            Dim MyCommand As New MySqlCommand(SQLSTATEMENT, SQLCONN)
            Dim myDataAdapter As New MySqlDataAdapter(SQLSTATEMENT, SQLCONN)
            myDataAdapter.Fill(dt)
            Dim sqlrdr As MySqlDataReader

            sqlrdr = MyCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            While sqlrdr.Read()
                Label3.Text = sqlrdr("id")
                Label8.Text = sqlrdr("Fullname")
                TextBox1.Text = sqlrdr("Fullname")
                TextBox2.Text = sqlrdr("Email")
                TextBox3.Text = sqlrdr("Username")
                TextBox4.Text = sqlrdr("Password")

            End While
        End If
        SQLCONN.Close()
        SQLCONN.Dispose()

    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SQLSTATEMENT As String = "UPDATE `user` SET `Fullname`='" & TextBox1.Text & "', `Email` ='" & TextBox2.Text & "', `Username`='" & TextBox3.Text & "', `Password` = '" & TextBox4.Text & "' WHERE `id` ='" & Label3.Text & "'"
        save(SQLSTATEMENT)
        MsgBox("Data updated succesfully", vbInformation)
        'searchrecord(SQLSTATEMENT)
        'Me.searchrec(SQLSTATEMENT)
        'Me.Hide()
    End Sub
End Class
