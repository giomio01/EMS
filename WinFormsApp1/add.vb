
Imports MySql.Data.MySqlClient




Public Class add
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Dim command1 As MySqlCommand
    Dim command2 As MySqlCommand
    Dim command3 As MySqlCommand
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property



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
        ElseIf TextBox7.Text <> "Unavailable" And Label10.Text = "NO ID GENERATED" Or Label10.Text = "" Then
            MessageBox.Show("please finish email id generation")
        ElseIf TextBox7.Text = "Unavailable" And combobox1.Text = "Choose One" Or Label10.Text = "" Then
            MessageBox.Show("please finish email id generation")
        ElseIf TextBox7.Text = "" Then
            MessageBox.Show("please input employee's email")
        Else
            connection = New MySqlConnection
            connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='telford_db'")

            Dim query As String
            query = ("Insert into `emp_masterlist`(`EMP_NO` , `EMP_NAME` , `TEAM` , `DEPARTMENT` , `STATION` , `PRODUCT_LINE` , `emp_email` , `email_id` , `designation`) 
                                        VALUES ('" & TextBox6.Text & "', '" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & TextBox7.Text & "',  '" & Label10.Text & "', '" & ComboBox1.Text & "')")

            command = New MySqlCommand(query, connection)


            connection.Open()
            command.ExecuteReader()
            MessageBox.Show("employee succesfully added")
            connection.Close()
            If Label10.Text = "NO ID GENERATED" Or Label10.Text = "" Then

            Else
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
                    TextBox7.Text = "Unavailable"
                    Label10.Text = "NO ID GENERATED"
                    ComboBox1.Text = "Unavailable"

                    Exit Sub
                End If

                TextBox6.Text = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox7.Text = "Unavailable"
                Label10.Text = "NO ID GENERATED"
                ComboBox1.Text = "Unavailable"


            End If
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Label10.Text = "NO ID GENERATED" Then
            Dim rslt As New System.Windows.Forms.DialogResult
            rslt = MessageBox.Show("Are you sure you want to exit?", "WARNING!", MessageBoxButtons.YesNo)
            If rslt = Windows.Forms.DialogResult.Yes Then
                TextBox6.Text = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox7.Text = ""
                Label10.Text = ""
                Me.Hide()
                Form2.Show()
            Else
                Exit Sub
            End If
        ElseIf Label10.Text = "" Then
            Dim rslt As New System.Windows.Forms.DialogResult
            rslt = MessageBox.Show("Are you sure you want to exit?", "WARNING!", MessageBoxButtons.YesNo)
            If rslt = Windows.Forms.DialogResult.Yes Then
                TextBox6.Text = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox7.Text = ""
                Label10.Text = ""
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
        ElseIf TextBox7.Text = "Unavailable" Then
            MessageBox.Show("no email address inputed")
        ElseIf combobox1.Text = "Choose One" Then
            MessageBox.Show("no designation inputed")
        Else
            connection = New MySqlConnection
            connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='telford_db'")



            Dim query1 As String
            Dim query2 As String
            query1 = ("Insert into `emails`(`emailscol`) VALUES ('" & TextBox7.Text & "')")
            query2 = ("select * from `emails` where `emailscol` = '" & TextBox7.Text & "'")
            command2 = New MySqlCommand(query2, connection)
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

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub
End Class