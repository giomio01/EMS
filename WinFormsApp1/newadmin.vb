Imports MySql.Data.MySqlClient


Public Class newadmin
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim rslt As New System.Windows.Forms.DialogResult
        rslt = MessageBox.Show("Are you sure you want to exit?", "WARNING!", MessageBoxButtons.YesNo)
        If rslt = Windows.Forms.DialogResult.Yes Then
            Me.Hide()
            Form2.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then
            MessageBox.Show("Please input Username")
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("Please input Password")
        Else
            connection = New MySqlConnection
            connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='telford_db'")
            Dim reader As MySqlDataReader
            Try

                connection.Open()
                Dim query As String
                query = ("Insert into `log_in`(`User` , `Pass`) 
                                        VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "')")
                command = New MySqlCommand(query, connection)
                reader = command.ExecuteReader
                MessageBox.Show("Admin succesfully added")
                connection.Close()

            Catch ex As MySqlException

                MessageBox.Show(ex.Message)
            Finally
                connection.Dispose()


            End Try

            TextBox1.Text = ""
            TextBox2.Text = ""

        End If
    End Sub

    Private Sub newadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Show()
        Me.Hide()
    End Sub
End Class