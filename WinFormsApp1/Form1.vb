
Imports MySql.Data.MySqlClient




Public Class Form1
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property
    Dim connection As MySqlConnection
    Dim command As MySqlCommand


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='telford_db'")
        Dim reader As MySqlDataReader


        Try
            connection.Open()
            Dim query As String
            query = "SELECT * from log_in where BINARY User ='" & TextBox1.Text & "' and BINARY Pass = '" & TextBox2.Text & "' "
            command = New MySqlCommand(query, connection)
            reader = command.ExecuteReader
            Dim count As Integer
            count = 0

            While reader.Read
                count = count + 1

            End While

            If count = 1 Then
                MessageBox.Show("Login Successful")
                TextBox1.Text = ""
                TextBox2.Text = ""
                Form2.Show()
                Me.Hide()
            ElseIf count > 1 Then
                MessageBox.Show("Duplicated Account")
                TextBox1.Text = ""
                TextBox2.Text = ""
            Else
                MessageBox.Show("Username or Password is invalid")
                TextBox1.Text = ""
                TextBox2.Text = ""
            End If
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        connection.Dispose()




    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Are you sure want to exit now?", MsgBoxStyle.YesNo, "closing warning") = MsgBoxResult.Yes Then ' If you select yes in the MsgBox then it will close the window
            Me.Close() ' Close the window
        Else
            ' Will not close the application
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='telford_db'")

        Try
            connection.Open()
            MessageBox.Show("yey!")
            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        connection.Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
End Class
