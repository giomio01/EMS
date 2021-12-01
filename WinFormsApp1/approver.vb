Imports MySql.Data.MySqlClient


Public Class approver

    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Dim command1 As MySqlCommand
    Dim command2 As MySqlCommand
    Private Sub approver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")



        Dim query As String
        query = ("select * from `emp_masterlist` where `EMP_NO` = '" & add.TextBox6.Text & "'")
        command = New MySqlCommand(query, connection)


        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()

        If reader.Read() Then


            Label4.Text = reader(1)
            Label5.Text = reader(0)
            Label6.Text = reader(7)
            Label7.Text = reader(6)
            Label13.Text = reader(8)




            MessageBox.Show("employee succesfully loaded")
        Else
            MessageBox.Show("Employee number does not exist")

        End If
        connection.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label12.Text = " No Approvers ID" Then
            MessageBox.Show("please authenticate first!!!")
        Else
            If Label13.Text = "Choose One" Then
                MessageBox.Show("Please choose Designation")
            ElseIf label13.Text = "Equipment Engineering" Then
                connection = New MySqlConnection
                connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")
                Dim query As String
                query = ("Insert into `auth_ee`(`approvers_id`) 
                                        VALUES ('" & Label12.Text & "')")
                command = New MySqlCommand(query, connection)
                connection.Open()
                command.ExecuteReader()
                MessageBox.Show("approver succesfully added")
                connection.Close()
            ElseIf label13.Text = "Process Engineering" Then
                connection = New MySqlConnection
                connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")
                Dim query As String
                query = ("Insert into `auth_pe`(`approvers_id`) 
                                        VALUES ('" & Label12.Text & "')")
                command = New MySqlCommand(query, connection)
                connection.Open()
                command.ExecuteReader()
                MessageBox.Show("approver succesfully added")
                connection.Close()
            ElseIf label13.Text = "Quality Assurance" Then
                connection = New MySqlConnection
                connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")
                Dim query As String
                query = ("Insert into `auth_qa`(`approvers_id`) 
                                        VALUES ('" & Label12.Text & "')")
                command = New MySqlCommand(query, connection)
                connection.Open()
                command.ExecuteReader()
                MessageBox.Show("approver succesfully added")
                connection.Close()
            ElseIf label13.Text = "Production" Then
                connection = New MySqlConnection
                connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")
                Dim query As String
                query = ("Insert into `auth_prod`(`approvers_id`) 
                                        VALUES ('" & Label12.Text & "')")
                command = New MySqlCommand(query, connection)
                connection.Open()
                command.ExecuteReader()
                MessageBox.Show("approver succesfully added")
                connection.Close()
            ElseIf label13.Text = "Other" Then
                connection = New MySqlConnection
                connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")
                Dim query As String
                query = ("Insert into `auth_others`(`approvers_id`) 
                                        VALUES ('" & Label12.Text & "')")
                command = New MySqlCommand(query, connection)
                connection.Open()
                command.ExecuteReader()
                MessageBox.Show("approver succesfully added")
                connection.Close()


            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        add.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        If TextBox1.Text = "" Then
            MessageBox.Show("please input password")
        ElseIf TextBox1.Text = TextBox2.Text Then
            connection = New MySqlConnection
            connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")


            Dim query As String
            query = ("Insert into `approvers`(`password` , `EMP_NO` , `emails_id`) 
                                        VALUES ('" & TextBox2.Text & "', (SELECT `EMP_NO` FROM `emp_masterlist` WHERE `email_id` = '" & Label6.Text & "'), '" & Label6.Text & "')")
            command = New MySqlCommand(query, connection)
            connection.Open()
            command.ExecuteReader()
            MessageBox.Show("approver succesfully added")
            connection.Close()
        Else
            MessageBox.Show("password mismatch! please try again")
        End If

        Dim query2 As String
        query2 = ("select * from `approvers` where `EMP_NO` = '" & Label5.Text & "'")
        command2 = New MySqlCommand(query2, connection)



            command2 = New MySqlCommand(query2, connection)
            Dim reader As MySqlDataReader
            connection.Open()
            reader = command2.ExecuteReader()

            If reader.Read() Then


                Label12.Text = reader.GetString(0)
                MessageBox.Show("Approvers id successfully generated")
                Me.Refresh()

            Else

            End If
            connection.Close()


    End Sub
End Class