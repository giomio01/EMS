
Imports MySql.Data.MySqlClient




Public Class add
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Dim command1 As MySqlCommand
    Dim command2 As MySqlCommand
    Dim command3 As MySqlCommand



    Private Sub add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        TextBox7.Enabled = False
        ComboBox1.Enabled = False


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox6.Text = "" Then
            MessageBox.Show("please input employee number")
        ElseIf TextBox1.Text = "" Then
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
            Dim query2 As String
            Dim query3 As String
            query = ("Insert into `emp_masterlist`(`EMP_NO` , `EMP_NAME` , `TEAM` , `DEPARTMENT` , `STATION` , `PRODUCT_LINE` , `emp_email` , `email_id` , `designation`) 
                                        VALUES ('" & TextBox6.Text & "', '" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & TextBox7.Text & "',  '" & Label10.Text & "', '" & ComboBox1.Text & "')")
            query1 = ("Insert into `emails`(`emailscol`) VALUES ('" & TextBox7.Text & "')")
            query2 = ("select * from `emails` where `emailscol` = '" & TextBox7.Text & "'")
            query3 = "UPDATE `emp_masterlist`
                     SET `EMP_NAME` = '" & TextBox1.Text & "' , `TEAM` = '" & TextBox2.Text & "', `DEPARTMENT` = '" & TextBox3.Text & "'
                     , `STATION` = '" & TextBox4.Text & "', `PRODUCT_LINE` = '" & TextBox5.Text & "'
                     , `emp_email` = '" & TextBox7.Text & "' , `email_id` = '' , `designation` = '" & ComboBox1.Text & "'
                     WHERE `EMP_NO` = '" & TextBox6.Text & "'"
            command = New MySqlCommand(query, connection)
            command1 = New MySqlCommand(query1, connection)
            command2 = New MySqlCommand(query2, connection)
            command3 = New MySqlCommand(query3, connection)


            connection.Open()
            command.ExecuteReader()
            MessageBox.Show("employee succesfully added")
            connection.Close()

            Dim rslt As New System.Windows.Forms.DialogResult
            rslt = MessageBox.Show("Is this employee an approver?", "WARNING!", MessageBoxButtons.YesNo)
            If rslt = Windows.Forms.DialogResult.Yes Then
                Me.Hide()
                approver.Show()
            Else
                TextBox6.Text = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox7.Text = ""
                Label10.Text = ""

                Exit Sub
            End If

            TextBox6.Text = ""
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox7.Text = ""
            Label10.Text = ""


        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Label10.Text = "NO ID GENERATED" Then
            Dim rslt As New System.Windows.Forms.DialogResult
            rslt = MessageBox.Show("Are you sure you want to exit?", "WARNING!", MessageBoxButtons.YesNo)
            If rslt = Windows.Forms.DialogResult.Yes Then
                Me.Hide()
                Form2.Show()
            Else
                Exit Sub
            End If
        ElseIf Label10.Text = "" Then
            Dim rslt As New System.Windows.Forms.DialogResult
            rslt = MessageBox.Show("Are you sure you want to exit?", "WARNING!", MessageBoxButtons.YesNo)
            If rslt = Windows.Forms.DialogResult.Yes Then
                Me.Hide()
                Form2.Show()
            Else
                Exit Sub
            End If
        Else
            MessageBox.Show("You have to add the employee because email ID is already generated")
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click




        If TextBox7.Text = "" Then
            MessageBox.Show("please input email address")
        Else
            connection = New MySqlConnection
            connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")



            Dim query As String
            Dim query1 As String
            Dim query2 As String
            Dim query3 As String
            query = ("Insert into `emp_masterlist`(`EMP_NO` , `EMP_NAME` , `TEAM` , `DEPARTMENT` , `STATION` , `PRODUCT_LINE` , `emp_email` , `email_id` , `designation`) 
                                        VALUES ('" & TextBox6.Text & "', '" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & TextBox7.Text & "',  '""', '" & ComboBox1.Text & "')")
            query1 = ("Insert into `emails`(`emailscol`) VALUES ('" & TextBox7.Text & "')")
            query2 = ("select * from `emails` where `emailscol` = '" & TextBox7.Text & "'")
            query3 = "UPDATE `emp_masterlist`
                     SET `EMP_NAME` = '" & TextBox1.Text & "' , `TEAM` = '" & TextBox2.Text & "', `DEPARTMENT` = '" & TextBox3.Text & "'
                     , `STATION` = '" & TextBox4.Text & "', `PRODUCT_LINE` = '" & TextBox5.Text & "'
                     , `emp_email` = '" & TextBox7.Text & "' , `email_id` = '' , `designation` = '" & ComboBox1.Text & "'
                     WHERE `EMP_NO` = '" & TextBox6.Text & "'"
            command = New MySqlCommand(query, connection)
            command1 = New MySqlCommand(query1, connection)
            command2 = New MySqlCommand(query2, connection)
            command3 = New MySqlCommand(query3, connection)




            command1 = New MySqlCommand(query1, connection)
            connection.Open()
            command1.ExecuteReader()
            MessageBox.Show("email succesfully added")
            connection.Close()

            command2 = New MySqlCommand(query2, connection)
            Dim reader As MySqlDataReader
            connection.Open()
            reader = command2.ExecuteReader()

            If reader.Read() Then


                Label10.Text = reader.GetString(0)
                MessageBox.Show("email id successfully generated")
                Me.Refresh()

            Else

            End If
            connection.Close()


        End If

    End Sub
    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress



        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then

            e.Handled = True
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox7.Enabled = True
            ComboBox1.Enabled = True
            ComboBox1.Text = "Choose One"

        Else
            TextBox7.Enabled = False
            ComboBox1.Enabled = False
            ComboBox1.Text = "Unavailable"


        End If
    End Sub
End Class