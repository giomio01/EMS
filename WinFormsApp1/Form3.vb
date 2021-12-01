Imports MySql.Data.MySqlClient



Public Class Form3
    Dim connection As MySqlConnection
    Dim command As MySqlCommand


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")



        Dim query As String
        query = ("select * from `log_in`")
        command = New MySqlCommand(query, connection)


        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        ListBox1.Items.Clear()
        While reader.Read
            ListBox1.Items.Add(reader.GetString("User"))
        End While

        connection.Close()
        Me.CenterToScreen()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")

        Dim query As String
        query = ("DELETE from `log_in` WHERE `User` = '" & ListBox1.SelectedItem & "'")
        command = New MySqlCommand(query, connection)



        connection.Open()
        Dim rslt As New System.Windows.Forms.DialogResult
        rslt = MessageBox.Show("Are you sure you want to delete this information?", "WARNING!", MessageBoxButtons.YesNo)
        If rslt = Windows.Forms.DialogResult.Yes Then
            If command.ExecuteNonQuery() = 1 Then

                MessageBox.Show("DATA DELETED!")


            Else
                MessageBox.Show("Error")
            End If

        Else

        End If
        connection.Close()


        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")



        Dim quer As String
        quer = ("select * from `log_in`")
        command = New MySqlCommand(quer, connection)


        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        ListBox1.Items.Clear()
        While reader.Read
            ListBox1.Items.Add(reader.GetString("User"))
        End While

        connection.Close()




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")



        Dim query As String
        query = ("select * from `log_in` where `User` = '" & ListBox1.SelectedItem & "'")
        command = New MySqlCommand(query, connection)


        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()

        If reader.Read() Then


            TextBox1.Text = reader(0)
            TextBox2.Text = reader(1)

            MessageBox.Show("Admin succesfully loaded")


        End If
        connection.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim rslt As New System.Windows.Forms.DialogResult
        rslt = MessageBox.Show("Are you sure you want to exit?", "WARNING!", MessageBoxButtons.YesNo)
        If rslt = Windows.Forms.DialogResult.Yes Then
            Me.Hide()
            newadmin.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox4.Text = "" Then
            MessageBox.Show("Please input a new Password")
        Else
            Dim a As String
            Dim b As String

            a = TextBox3.Text
            b = TextBox2.Text
            If a = b Then
                connection = New MySqlConnection
                connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")

                Dim query As String
                query = "UPDATE `log_in` SET `Pass` = '" & TextBox4.Text & "' where `User` = '" & TextBox3.Text & "'"
                command = New MySqlCommand(query, connection)



                connection.Open()
                If command.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("succesfully updated")

                Else
                    MessageBox.Show("Password Mismatched! Please verify your Password again")
                End If
                connection.Close()
            Else
                MessageBox.Show("Password Mismatched! Please verify your Password again")
            End If

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class