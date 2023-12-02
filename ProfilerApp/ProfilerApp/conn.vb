Imports MySql.Data.MySqlClient
Imports System.Configuration
Module conn
    Public con As String = ConfigurationManager.ConnectionStrings("myconnection").ConnectionString
    Public SQLCONN As MySqlConnection = New MySqlConnection

    Public Sub save(ByRef SQLSTATEMENT As String)
        SQLCONN.ConnectionString = con
        Try
            If SQLCONN.State = ConnectionState.Closed Then

                SQLCONN.Open()

                Dim cmd As MySqlCommand = New MySqlCommand

                With cmd

                    .CommandText = SQLSTATEMENT
                    .CommandType = CommandType.Text
                    .Connection = SQLCONN
                    .ExecuteNonQuery()
                End With

                SQLCONN.Close()
                SQLCONN.Dispose()

            Else
                Dim cmd As MySqlCommand = New MySqlCommand

                With cmd

                    .CommandText = SQLSTATEMENT
                    .CommandType = CommandType.Text
                    .Connection = SQLCONN
                    .ExecuteNonQuery()
                End With

                SQLCONN.Close()
                SQLCONN.Dispose()


                SQLCONN.Close()
                SQLCONN.Dispose()


            End If
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub

    Public Sub searchrecord(ByRef SQLSTATEMENT As String)
        SQLCONN.ConnectionString = con
        SQLCONN.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        Dim MyCommand As New MySqlCommand(SQLSTATEMENT, SQLCONN)
        Dim myDataAdapter As New MySqlDataAdapter(SQLSTATEMENT, SQLCONN)
        myDataAdapter.Fill(dt)
        Dim count As Integer = dt.Rows.Count
        If count = 0 Then
            MsgBox("Incorrect Credentials!", vbExclamation, "Invalid")
            SQLCONN.Close()
            SQLCONN.Dispose()

            Exit Sub
        Else
            Dim sqlrdr As MySqlDataReader
            sqlrdr = MyCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            While sqlrdr.Read()
                Main.Show()
            End While
            SQLCONN.Close()
            SQLCONN.Dispose()

            myDataAdapter.Fill(ds)
            Form1.Visible = False
            SQLCONN.Close()
            SQLCONN.Dispose()

        End If

        SQLCONN.Close()
        SQLCONN.Dispose()

    End Sub

End Module
