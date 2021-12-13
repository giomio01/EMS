Imports MySql.Data.MySqlClient

Public Class Form4
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Dim command1 As MySqlCommand
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim param As CreateParams = MyBase.CreateParams
            param.ClassStyle = param.ClassStyle Or &H200
            Return param
        End Get
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='telford_db'")



        Dim query As String
        query = ("SELECT 
emp_masterlist.EMP_NO,
emails.id,
emp_masterlist.EMP_NAME,
emails.emailscol
FROM 
    telford_db.emp_masterlist
LEFT JOIN 
    telford_db.emp_has_emails
ON 
    emp_masterlist.EMP_NO = emp_has_emails.emp_masterlist_EMP_NO
LEFT JOIN 
    telford_db.emails
ON 
    emp_has_emails.emails_id = emails.id
WHERE  
    emp_masterlist.EMP_NO = '" & TextBox1.Text & "'")
        command = New MySqlCommand(query, connection)


        Dim reader As MySqlDataReader

        connection.Open()
        reader = Command.ExecuteReader()
        Listbox1.Items.Clear()
        While reader.Read
            ListBox1.Items.Add(reader.Item(0).ToString & "    " & reader.Item(1).ToString & "    " & reader.Item(2).ToString & "    " & reader.Item(3).ToString)
        End While
        connection.Close()

        Button2.Enabled = True
        Button3.Enabled = True

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Button2.Enabled = False
        Button3.Enabled = False

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='telford_db'")
        If ListBox1.SelectedItem = "" Then
            MessageBox.Show("please select data")
        Else
            Dim query As String
            Dim query1 As String
            query1 = ("SELECT 
emp_masterlist.EMP_NO,
emails.id,
emp_masterlist.EMP_NAME,
emails.emailscol
FROM 
    telford_db.emp_masterlist
LEFT JOIN 
    telford_db.emp_has_emails
ON 
    emp_masterlist.EMP_NO = emp_has_emails.emp_masterlist_EMP_NO
LEFT JOIN 
    telford_db.emails
ON 
    emp_has_emails.emails_id = emails.id
WHERE  
    emp_masterlist.EMP_NO = '" & TextBox1.Text & "'")
            command1 = New MySqlCommand(query1, connection)


            Dim reader As MySqlDataReader

            connection.Open()
            reader = command1.ExecuteReader()
            ListBox1.Items.Clear()
            While reader.Read
                ListBox1.Items.Add(reader.Item(0).ToString & "    " & reader.Item(1).ToString & "    " & reader.Item(2).ToString & "    " & reader.Item(3).ToString)
            End While
            Dim a As String
            a = reader.Item(1).ToString
            query = ("DELETE from `emp_has_emails` WHERE `emails_id` = '" & a & "'")
            command = New MySqlCommand(query, connection)

            connection.Close()

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
            connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='telford_db'")



            Dim quer As String
            quer = ("SELECT 
emp_masterlist.EMP_NO,
emails.id,
emp_masterlist.EMP_NAME,
emails.emailscol
FROM 
    telford_db.emp_masterlist
LEFT JOIN 
    telford_db.emp_has_emails
ON 
    emp_masterlist.EMP_NO = emp_has_emails.emp_masterlist_EMP_NO
LEFT JOIN 
    telford_db.emails
ON 
    emp_has_emails.emails_id = emails.id
WHERE  
    emp_masterlist.EMP_NO = '" & TextBox1.Text & "'")
            command = New MySqlCommand(quer, connection)


            Dim reader1 As MySqlDataReader
            connection.Open()
            reader1 = command.ExecuteReader()
            ListBox1.Items.Clear()
            While reader1.Read
                ListBox1.Items.Add(reader1.Item(0).ToString & "    " & reader1.Item(1).ToString & "    " & reader1.Item(2).ToString & "    " & reader1.Item(3).ToString)
            End While

            connection.Close()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='telford_db'")


        Dim query As String
        Dim query1 As String
        query = ("select * from `emp_masterlist` where `EMP_NO` = '" & TextBox2.Text & "'")
        query1 = ("Insert into `emp_has_emails`(`emp_masterlist_EMP_NO` , `emails_id`) 
                                        VALUES ('" & TextBox1.Text & "', (SELECT `email_id` FROM `emp_masterlist` WHERE `EMP_NO` = '" & TextBox2.Text & "'))")
        command = New MySqlCommand(query, connection)
        command1 = New MySqlCommand(query1, connection)



        Dim reader As MySqlDataReader
        connection.Open()
        reader = command.ExecuteReader()
        If reader.Read() Then
            While reader.Read
            End While
            Dim a As String
            a = reader.Item(7).ToString
            If a = "Unavailable" Then

                MessageBox.Show("Employee has no email")
            Else
                connection.Close()

                Dim reader1 As MySqlDataReader
                connection.Open()
                reader1 = command1.ExecuteReader()
                command1 = New MySqlCommand(query1, connection)
                MessageBox.Show("Successfully added")

                TextBox2.Text = ""

                connection = New MySqlConnection
                connection.ConnectionString = ("server='localhost';port='3306';username='root';password='gieRHAAA9iSi3ULZ';database='telford_db'")



            End If
        ElseIf TextBox2.Text = "" Then
            MessageBox.Show("please insert employee ID")
        Else
            MessageBox.Show("Employee does not exist")

        End If
        connection.Close()
        Dim quer As String
        quer = ("SELECT 
emp_masterlist.EMP_NO,
emails.id,
emp_masterlist.EMP_NAME,
emails.emailscol
FROM 
    telford_db.emp_masterlist
LEFT JOIN 
    telford_db.emp_has_emails
ON 
    emp_masterlist.EMP_NO = emp_has_emails.emp_masterlist_EMP_NO
LEFT JOIN 
    telford_db.emails
ON 
    emp_has_emails.emails_id = emails.id
WHERE  
    emp_masterlist.EMP_NO = '" & TextBox1.Text & "'")
        command = New MySqlCommand(quer, connection)


        Dim reader2 As MySqlDataReader
        connection.Open()
        reader2 = command.ExecuteReader()
        ListBox1.Items.Clear()
        While reader2.Read
            ListBox1.Items.Add(reader2.Item(0).ToString & "    " & reader2.Item(1).ToString & "    " & reader2.Item(2).ToString & "    " & reader2.Item(3).ToString)
        End While

        connection.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim rslt As New System.Windows.Forms.DialogResult
        rslt = MessageBox.Show("Are you sure you want to exit?", "WARNING!", MessageBoxButtons.YesNo)
        If rslt = Windows.Forms.DialogResult.Yes Then
            Me.Hide()
            Form2.Show()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress



        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then

            e.Handled = True
        End If

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress



        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then

            e.Handled = True
        End If

    End Sub
End Class