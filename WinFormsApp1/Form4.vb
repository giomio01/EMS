Imports MySql.Data.MySqlClient

Public Class Form4
    Dim connection As MySqlConnection
    Dim command As MySqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")



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
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")



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
        reader = command.ExecuteReader()
        ListBox1.Items.Clear()
        While reader.Read
            ListBox1.Items.Add(reader.Item(0).ToString & "    " & reader.Item(1).ToString & "    " & reader.Item(2).ToString & "    " & reader.Item(3).ToString)
        End While
        Dim a As String
        a = reader.Item(1)
        MessageBox.Show(a)



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connection = New MySqlConnection
        connection.ConnectionString = ("server='localhost';port='3306';username='root';password='giomio01';database='telford_db'")



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
        reader = command.ExecuteReader()
        ListBox1.Items.Clear()
        While reader.Read
            ListBox1.Items.Add(reader.Item(0).ToString & "    " & reader.Item(1).ToString & "    " & reader.Item(2).ToString & "    " & reader.Item(3).ToString)
        End While
        Dim a As String
        a = reader.Item(1)
        MessageBox.Show(a)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form2.Show()
    End Sub
End Class