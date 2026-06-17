Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ER_letter_WizardPage
    Inherits System.Web.UI.Page
    Dim myglobal As New Emanagement.globalinfo
    Dim myapp As New Emanagement.EMSapplications
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim str, rb, rb1, rb2, rb3, rb4, rb5, rb6, rb7, rb8, rb9, rb10, lb, txt, nul As String
    Dim i As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myglobal.Open_Con()
        myglobal.Con_Str()
        If IsPostBack = False Then
            ListBox1.Items.Add("empname")
            ListBox1.Items.Add("empcode")
            ListBox1.Items.Add("departmentcode")
            ListBox1.Items.Add("designation")
            ListBox1.Items.Add("emptype")
            ListBox1.Items.Add("companyname")
            ListBox1.Items.Item(0).Selected = True
            ListBox1.Items.Item(1).Selected = True
            ListBox1.Items.Item(2).Selected = True
            ListBox1.Items.Item(3).Selected = True
        End If
        'constr = "Data Source=NB01\SQLEXPRESS;Initial Catalog=hrmis;Integrated Security=True"
        con = New SqlConnection(constr)
        con.Open()
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim f2, f3, f4, f5, f6, f7, f8, f9, f10, f11 As String
        'f2 = TextBox2.Text
        'f3 = TextBox3.Text
        'f4 = TextBox4.Text
        'f5 = TextBox5.Text
        'f6 = TextBox6.Text
        'f7 = TextBox7.Text
        'f8 = TextBox8.Text
        'f9 = TextBox9.Text
        'f10 = TextBox10.Text
        'f11 = TextBox11.Text
        'If TextBox2.Text <> "" Then
        '    If f2 <> f3 And f2 <> f4 And f2 <> f5 And f2 <> f6 And f2 <> f7 And f2 <> f8 And f2 <> f9 And f2 <> f10 And f2 <> f11 Then
        '    Else
        '        MsgBox(TextBox2.Text & " is match with below textbox field")
        '    End If
        'ElseIf TextBox3.Text <> "" Then
        '    If f3 <> f4 And f3 <> f5 And f3 <> f6 And f3 <> f7 And f3 <> f8 And f3 <> f9 And f3 <> f10 And f3 <> f11 Then
        '    Else
        '        MsgBox(TextBox3.Text & " is match with below textbox field")
        '    End If
        'ElseIf TextBox4.Text <> "" Then
        '    If f4 <> f5 And f4 <> f6 And f4 <> f7 And f4 <> f8 And f4 <> f9 And f4 <> f10 And f4 <> f11 Then
        '    Else
        '        MsgBox(TextBox4.Text & " is match with below textbox field")
        '    End If
        'ElseIf TextBox5.Text <> "" Then
        '    If f5 <> f6 And f5 <> f7 And f5 <> f8 And f5 <> f9 And f5 <> f10 And f5 <> f11 Then
        '    Else
        '        MsgBox(TextBox5.Text & " is match with below textbox field")
        '    End If
        'ElseIf TextBox6.Text <> "" Then
        '    If f6 <> f7 And f6 <> f8 And f6 <> f9 And f6 <> f10 And f6 <> f11 Then
        '    Else
        '        MsgBox(TextBox6.Text & " is match with below textbox field")
        '    End If
        'ElseIf TextBox7.Text <> "" Then
        '    If f7 <> f8 And f7 <> f9 And f7 <> f10 And f7 <> f11 Then
        '    Else
        '        MsgBox(TextBox7.Text & " is match with below textbox field")
        '    End If
        'ElseIf TextBox8.Text <> "" Then
        '    If f8 <> f9 And f8 <> f10 And f8 <> f11 Then
        '    Else
        '        MsgBox(TextBox8.Text & " is match with below textbox field")
        '    End If
        'ElseIf TextBox9.Text <> "" Then
        '    If f9 <> f10 And f9 <> f11 Then
        '    Else
        '        MsgBox(TextBox9.Text & " is match with below textbox field")
        '    End If
        'ElseIf TextBox10.Text <> "" Then
        '    If f10 <> f11 Then
        '    Else
        '        MsgBox(TextBox10.Text & " is match with below textbox field")
        '    End If
        'End If
        Call insert()
    End Sub
    Private Sub RadioButtonLists_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged, RadioButtonList2.SelectedIndexChanged, RadioButtonList3.SelectedIndexChanged, RadioButtonList4.SelectedIndexChanged, RadioButtonList5.SelectedIndexChanged, RadioButtonList6.SelectedIndexChanged, RadioButtonList7.SelectedIndexChanged, RadioButtonList8.SelectedIndexChanged, RadioButtonList9.SelectedIndexChanged, RadioButtonList10.SelectedIndexChanged
        rb1 = RadioButtonList1.Text
        rb2 = RadioButtonList2.Text
        rb3 = RadioButtonList3.Text
        rb4 = RadioButtonList4.Text
        rb5 = RadioButtonList5.Text
        rb6 = RadioButtonList6.Text
        rb7 = RadioButtonList7.Text
        rb8 = RadioButtonList8.Text
        rb9 = RadioButtonList9.Text
        rb10 = RadioButtonList10.Text
    End Sub
    Protected Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim i As Integer
        str = "select count(distinct lettername) from HRMIS_ER_LETTER_WIZARD where lettername='" & (TextBox1.Text) & "'"
        'str = "select count(*) from HRMIS_ER_LETTER_WIZARD where lettername='" & (TextBox1.Text) & "'"
        cmd = New SqlCommand(str, con)
        i = cmd.ExecuteScalar
        If i = 1 Then
            MsgBox(TextBox1.Text & " was already exist in the database please try other name")
            TextBox1.Text = ""
            TextBox1.Focus()
        Else
            TextBox2.Focus()
        End If
    End Sub
    Sub rbselect()
        If TextBox2.Text <> "" And RadioButtonList1.Items.Item(0).Selected = False And RadioButtonList1.Items.Item(1).Selected = False Then
            rb1 = "Text Box"
        ElseIf TextBox2.Text <> "" And RadioButtonList1.Items.Item(1).Selected = True Then
            rb1 = "Text Area"
        End If
        If TextBox3.Text <> "" And RadioButtonList2.Items.Item(0).Selected = False And RadioButtonList2.Items.Item(1).Selected = False Then
            rb2 = "Text Box"
        ElseIf TextBox3.Text <> "" And RadioButtonList2.Items.Item(1).Selected = True Then
            rb2 = "Text Area"
        End If
        If TextBox4.Text <> "" And RadioButtonList3.Items.Item(0).Selected = False And RadioButtonList3.Items.Item(1).Selected = False Then
            rb3 = "Text Box"
        ElseIf TextBox4.Text <> "" And RadioButtonList3.Items.Item(1).Selected = True Then
            rb3 = "Text Area"
        End If
        If TextBox5.Text <> "" And RadioButtonList4.Items.Item(0).Selected = False And RadioButtonList4.Items.Item(1).Selected = False Then
            rb4 = "Text Box"
        ElseIf TextBox5.Text <> "" And RadioButtonList4.Items.Item(1).Selected = True Then
            rb4 = "Text Area"
        End If
        If TextBox6.Text <> "" And RadioButtonList5.Items.Item(0).Selected = False And RadioButtonList5.Items.Item(1).Selected = False Then
            rb5 = "Text Box"
        ElseIf TextBox6.Text <> "" And RadioButtonList5.Items.Item(1).Selected = True Then
            rb5 = "Text Area"
        End If
        If TextBox7.Text <> "" And RadioButtonList6.Items.Item(0).Selected = False And RadioButtonList6.Items.Item(1).Selected = False Then
            rb6 = "Text Box"
        ElseIf TextBox7.Text <> "" And RadioButtonList6.Items.Item(1).Selected = True Then
            rb6 = "Text Area"
        End If
        If TextBox8.Text <> "" And RadioButtonList7.Items.Item(0).Selected = False And RadioButtonList7.Items.Item(1).Selected = False Then
            rb7 = "Text Box"
        ElseIf TextBox8.Text <> "" And RadioButtonList7.Items.Item(1).Selected = True Then
            rb7 = "Text Area"
        End If
        If TextBox9.Text <> "" And RadioButtonList8.Items.Item(0).Selected = False And RadioButtonList8.Items.Item(1).Selected = False Then
            rb8 = "Text Box"
        ElseIf TextBox9.Text <> "" And RadioButtonList8.Items.Item(1).Selected = True Then
            rb8 = "Text Area"
        End If
        If TextBox10.Text <> "" And RadioButtonList9.Items.Item(0).Selected = False And RadioButtonList9.Items.Item(1).Selected = False Then
            rb9 = "Text Box"
        ElseIf TextBox10.Text <> "" And RadioButtonList9.Items.Item(1).Selected = True Then
            rb9 = "Text Area"
        End If
        If TextBox11.Text <> "" And RadioButtonList10.Items.Item(0).Selected = False And RadioButtonList10.Items.Item(1).Selected = False Then
            rb10 = "Text Box"
        ElseIf TextBox11.Text <> "" And RadioButtonList10.Items.Item(1).Selected = True Then
            rb10 = "Text Area"
        End If
    End Sub
    Sub insert()
        Dim l1 As String = TextBox1.Text
        Dim substring1 As String = l1.Substring(0, 1)
        Dim sur As String = Label1.Text & substring1
        nul = "NULL"
        Session("lab1") = Label1.Text
        Session("tb1") = TextBox1.Text
        For i = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(i).Selected = True Then
                lb = ListBox1.Items(i).Text
                Dim j As String = sur & lb
                str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & j & "','" & nul & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',0)"
                cmd = New SqlCommand(str, con)
                cmd.ExecuteNonQuery()
            End If
        Next
        Dim txt
        For n As Integer = 1 To 10
            If n = 1 And TextBox2.Text <> "" Then
                txt = sur & TextBox2.Text
                rbselect()
                rb = rb1
            End If
            If n = 2 And TextBox3.Text <> "" Then
                txt = sur & TextBox3.Text
                rbselect()
                rb = rb2
            End If
            If n = 3 And TextBox4.Text <> "" Then
                txt = sur & TextBox4.Text
                rbselect()
                rb = rb3
            End If
            If n = 4 And TextBox5.Text <> "" Then
                txt = sur & TextBox5.Text
                rbselect()
                rb = rb4
            End If
            If n = 5 And TextBox6.Text <> "" Then
                txt = sur & TextBox6.Text
                rbselect()
                rb = rb5
            End If
            If n = 6 And TextBox7.Text <> "" Then
                txt = sur & TextBox7.Text
                rbselect()
                rb = rb6
            End If
            If n = 7 And TextBox8.Text <> "" Then
                txt = sur & TextBox8.Text
                rbselect()
                rb = rb7
            End If
            If n = 8 And TextBox9.Text <> "" Then
                txt = sur & TextBox9.Text
                rbselect()
                rb = rb8
            End If
            If n = 9 And TextBox10.Text <> "" Then
                txt = sur & TextBox10.Text
                rbselect()
                rb = rb9
            End If
            If n = 10 And TextBox11.Text <> "" Then
                txt = sur & TextBox11.Text
                rbselect()
                rb = rb10
            End If
            If n = 1 And TextBox2.Text <> "" Or n = 2 And TextBox3.Text <> "" Or n = 3 And TextBox4.Text <> "" Or n = 4 And TextBox5.Text <> "" Or n = 5 And TextBox6.Text <> "" Or n = 6 And TextBox7.Text <> "" Or n = 7 And TextBox8.Text <> "" Or n = 8 And TextBox9.Text <> "" Or n = 9 And TextBox10.Text <> "" Or n = 10 And TextBox11.Text <> "" Then
                str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & txt & "','" & rb & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',1)"
                cmd = New SqlCommand(str, con)
                cmd.ExecuteNonQuery()
            End If
        Next
        Server.Transfer("ER_letter_CreatePage.aspx")
    End Sub
End Class