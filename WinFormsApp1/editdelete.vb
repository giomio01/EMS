Imports MySql.Data.MySqlClient


Public Class editdelete
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Dim command2 As MySqlCommand
    Dim command3 As MySqlCommand
    Dim command4 As MySqlCommand


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")



        Dim query As String
        query = ("select * from `emp_masterlist` where `EMP_NO` = '" & TextBox6.Text & "'")
        command = New MySqlCommand(query, connection)


        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()

        If reader.Read() Then


            TextBox7.Text = reader(1)
            TextBox2.Text = reader(2)
            TextBox3.Text = reader(3)
            TextBox4.Text = reader(4)
            TextBox5.Text = reader(5)
            TextBox1.Text = reader.GetValue(6)
            TextBox8.Text = reader(7)
            ComboBox1.Text = reader(8)


            MessageBox.Show("employee succesfully loaded")

        Else
            MessageBox.Show("Employee number does not exist")

        End If
        connection.Close()
        Dim query2 As String
        query2 = ("select * from `approvers` where `EMP_NO` = '" & TextBox6.Text & "'")
        command2 = New MySqlCommand(query2, connection)



        command2 = New MySqlCommand(query2, connection)
        Dim reader1 As MySqlDataReader
        connection.Open()
        reader1 = command2.ExecuteReader()

        If reader1.Read() Then


            TextBox9.Text = reader1.GetString(0)
            Me.Refresh()

        Else

        End If
        connection.Close()


    End Sub

    Private Sub editdelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        TextBox7.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox1.Enabled = False
        Button2.Enabled = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            TextBox7.Enabled = True
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = False
            Button1.Enabled = False
            If TextBox1.Text = "Unavailable" Then
                TextBox1.Enabled = False
                MessageBox.Show("This Employee doesn't have an email if you wish to add an email address on this account DELETE this account first then ADD a new one to generate email ID or you can edit existing details only")
            End If


        Else

            TextBox7.Enabled = False
            TextBox2.Enabled = False
            TextBox1.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = True
            Button1.Enabled = True


        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox6.Text = "" Then
            MessageBox.Show("please input employee number")
        ElseIf TextBox7.Text = "" Then
            MessageBox.Show("please input employee's Fullname")
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("please input employee's Team")
        ElseIf TextBox3.Text = "" Then
            MessageBox.Show("please input employee's Department")
        ElseIf TextBox4.Text = "" Then
            MessageBox.Show("please input employee's Station")
        ElseIf TextBox5.Text = "" Then
            MessageBox.Show("please input employee's Productline")
        Else
            connection = New MySqlConnection
            connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")

            Dim query As String
            Dim query1 As String
            query = "UPDATE `emp_masterlist`
                     SET `EMP_NAME` = '" & TextBox7.Text & "' , `TEAM` = '" & TextBox2.Text & "', `DEPARTMENT` = '" & TextBox3.Text & "'
                     , `STATION` = '" & TextBox4.Text & "', `PRODUCT_LINE` = '" & TextBox5.Text & "'
                     , `emp_email` = '" & TextBox1.Text & "' , `email_id` = '" & TextBox8.Text & "' , `designation` = '" & ComboBox1.Text & "'
                     WHERE `EMP_NO` = '" & TextBox6.Text & "'"

            query1 = "UPDATE `emails`
                       SET `emailscol`= '" & TextBox1.Text & "'
                      WHERE `id` = '" & TextBox8.Text & "'"

            command = New MySqlCommand(query, connection)

            command2 = New MySqlCommand(query1, connection)



            connection.Open()
            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("succesfully updated")

            Else
                MessageBox.Show("Error")
            End If
            connection.Close()
            TextBox7.Text = ""
            TextBox6.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox7.Text = ""
            TextBox1.Text = ""
            ComboBox1.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""


            command2 = New MySqlCommand(query1, connection)



            connection.Open()
            If command2.ExecuteNonQuery() = 1 Then
                MessageBox.Show("email succesfully updated")

            ElseIf command2.ExecuteNonQuery() = 0 Then
                MessageBox.Show("no email added")
            Else
                MessageBox.Show("Error")
            End If
            connection.Close()
            TextBox1.Text = ""
            TextBox7.Text = ""
            TextBox6.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            ComboBox1.Text = ""

        End If

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")
        If TextBox6.Text = "" Then
            MessageBox.Show("please input employee number")
        ElseIf TextBox7.Text = "" Then
            MessageBox.Show("please click search button")

        Else
            Dim query As String
            Dim query1 As String
            Dim query2 As String




            query = "delete from `emp_masterlist` WHERE `EMP_NO` = '" & TextBox6.Text & "'"
            query1 = "delete from `emails` WHERE `id` = (SELECT `email_id` FROM `emp_masterlist` WHERE `EMP_NO` = '" & TextBox6.Text & "')"
            query2 = "delete from `approvers` WHERE `emails_id` = (SELECT `email_id` FROM `emp_masterlist` WHERE `EMP_NO` = '" & TextBox6.Text & "')"


            command = New MySqlCommand(query, connection)
            command2 = New MySqlCommand(query1, connection)
            command3 = New MySqlCommand(query2, connection)




            connection.Open()
            Dim rslt As New System.Windows.Forms.DialogResult
            rslt = MessageBox.Show("Are you sure you want to delete this information?", "WARNING!", MessageBoxButtons.YesNo)
            If rslt = Windows.Forms.DialogResult.Yes Then

                If ComboBox1.Text = "Choose One" Then
                ElseIf ComboBox1.Text = "Equipment Engineering" Then
                    Dim query3 As String
                    query3 = "delete from `auth_ee` WHERE `approvers_id` = '" & TextBox9.Text & "'"
                    command4 = New MySqlCommand(query3, connection)
                    If command4.ExecuteNonQuery() = 1 Then
                    End If
                ElseIf ComboBox1.Text = "Process Engineering" Then
                    Dim query3 As String
                    query3 = "delete from `auth_pe` WHERE `approvers_id` = '" & TextBox9.Text & "'"
                    command4 = New MySqlCommand(query3, connection)
                    If command4.ExecuteNonQuery() = 1 Then
                    End If
                ElseIf ComboBox1.Text = "Quality Assurance" Then
                    Dim query3 As String
                    query3 = "delete from `auth_qa` WHERE `approvers_id` = '" & TextBox9.Text & "'"
                    command4 = New MySqlCommand(query3, connection)
                    If command4.ExecuteNonQuery() = 1 Then
                    End If
                ElseIf ComboBox1.Text = "Production" Then
                    Dim query3 As String
                    query3 = "delete from `auth_prod` WHERE `approvers_id` = '" & TextBox9.Text & "'"
                    command4 = New MySqlCommand(query3, connection)
                    If command4.ExecuteNonQuery() = 1 Then
                    End If
                ElseIf ComboBox1.Text = "Other" Then
                    Dim query3 As String
                    query3 = "delete from `auth_others` WHERE `approvers_id` = '" & TextBox9.Text & "'"
                    command4 = New MySqlCommand(query3, connection)
                    If command4.ExecuteNonQuery() = 1 Then

                    End If
                End If

                If command3.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Not an approver!")
                End If

                If command2.ExecuteNonQuery() = 1 Then
                End If

                If command.ExecuteNonQuery() = 1 Then

                    MessageBox.Show("DATA DELETED!")

                Else
                    MessageBox.Show("Error")
                End If


            Else

            End If


            TextBox7.Text = ""
            TextBox2.Text = ""
            TextBox1.Text = ""
            TextBox6.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            ComboBox1.Text = ""

            connection.Close()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim rslt As New System.Windows.Forms.DialogResult
        rslt = MessageBox.Show("Are you sure you want to exit?", "WARNING!", MessageBoxButtons.YesNo)
        If rslt = Windows.Forms.DialogResult.Yes Then
            Me.Hide()
            Form2.Show()
            TextBox7.Text = ""
            TextBox6.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox7.Text = ""
            TextBox1.Text = ""
            ComboBox1.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
        Else

        End If
    End Sub


    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress



        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then

            e.Handled = True
        End If

    End Sub
End Class