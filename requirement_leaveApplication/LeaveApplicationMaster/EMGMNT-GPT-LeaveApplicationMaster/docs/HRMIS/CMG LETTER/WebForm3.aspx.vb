Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class WebForm3
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim constr, str, str1, rb1, rb2, rb3, rb4, rb5, rb6, rb7, rb8, rb9, rb10, lb, equ, nul As String
    Dim i As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If IsPostBack = False Then
            'DropDownList1.Items.Add("--Select--")
            'DropDownList1.Items.Add("ER")
            'DropDownList1.Items.Add("CMG")

            ListBox1.Items.Add("empcode")
            ListBox1.Items.Add("empname")
            ListBox1.Items.Add("departmentcode")
            ListBox1.Items.Add("emptype")
            ListBox1.Items.Add("designation")
        End If
        constr = "Data Source=NB09;Initial Catalog=hrmis;uid = sa;"
        con = New SqlConnection(constr)
        con.Open()
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim l1 As String = TextBox1.Text
        Dim substring1 As String = l1.Substring(0, 1)
        ' Dim sur As String = DropDownList1.Text & substring1
        Dim sur As String = Label1.Text & substring1
        nul = "NULL"
        sur = "CMG"
        For i = 0 To ListBox1.Items.Count - 1
            If ListBox1.Items(i).Selected = True Then
                lb = ListBox1.Items(i).Text
                Dim j As String = sur & lb
                str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & j & "','" & nul & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',0)"
                cmd = New SqlCommand(str, con)
                cmd.ExecuteNonQuery()
            End If
        Next
        'If TextBox1.Text = "" Or ListBox1.SelectedItem.Selected = False Or DropDownList1.SelectedItem.Selected = False Then
        '    MessageBox("pls select dropdown item and listbox item first then type letter name")
        '    TextBox1.Focus()
        'Else
        'If TextBox1.Text <> "" Then
        '    str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & lb & "','" & nul & "','" & (TextBox1.Text) & "','" & (DropDownList1.Text) & "')"
        '    cmd = New SqlCommand(str, con)
        '    cmd.ExecuteNonQuery()
        'End If
        sur = "CMG"
        If TextBox2.Text = "" Then
        Else
            'Dim i As String = sur & TextBox2.Text
            Dim i As String = sur & TextBox2.Text
            str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & (i) & "','" & rb1 & "','" & (TextBox1.Text) & "', '" & (Label1.Text) & "','" & (sur) & "',1)"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
        End If

        If TextBox3.Text = "" Then
        Else
            'Dim i1 As String = sur & TextBox3.Text
            Dim i1 As String = sur & TextBox3.Text
            ' str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & (i1) & "','" & rb2 & "','" & (TextBox1.Text) & "','" & (DropDownList1.Text) & "','" & (sur) & "',1)"
            str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & (i1) & "','" & rb2 & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',1)"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
        End If

        If TextBox4.Text = "" Then
        Else
            'Dim i2 As String = sur & TextBox4.Text
            Dim i2 As String = sur & TextBox4.Text
            str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & (i2) & "','" & rb3 & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',1)"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
        End If

        If TextBox5.Text = "" Then
        Else
            Dim i3 As String = sur & TextBox5.Text
            ' Dim i3 As String = TextBox5.Text
            str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & (i3) & "','" & rb4 & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',1)"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
        End If

        If TextBox6.Text = "" Then
        Else
            Dim i4 As String = sur & TextBox6.Text
            'Dim i4 As String = TextBox6.Text
            str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & (i4) & "','" & rb5 & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',1)"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
        End If

        If TextBox7.Text = "" Then
        Else
            Dim i5 As String = sur & TextBox7.Text
            ' Dim i5 As String = TextBox7.Text
            str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & (i5) & "','" & rb6 & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',1)"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
        End If

        If TextBox8.Text = "" Then
        Else
            Dim i6 As String = sur & TextBox8.Text
            ' Dim i6 As String = TextBox8.Text
            str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & (i6) & "','" & rb7 & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',1)"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
        End If

        If TextBox9.Text = "" Then
        Else
            Dim i7 As String = sur & TextBox9.Text
            ' Dim i7 As String = TextBox9.Text
            str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & (i7) & "','" & rb8 & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',1)"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
        End If

        If TextBox10.Text = "" Then
        Else
            Dim i8 As String = sur & TextBox10.Text
            'Dim i8 As String = TextBox10.Text
            ' Dim j4 As String = sur & DropDownList1.Text
            'Dim j4 As String = sur & Label1.Text
            str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & (i8) & "','" & rb9 & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',1)"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
        End If

        If TextBox11.Text = "" Then
        Else
            Dim i9 As String = sur & TextBox11.Text
            ' Dim i9 As String = TextBox11.Text
            ' Dim j4 As String = sur & DropDownList1.Text
            'Dim j4 As String = sur & Label1.Text
            str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & (i9) & "','" & rb10 & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',1)"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()
        End If

        ' MessageBox("Record saved")
        Server.Transfer("WebForm4.aspx")
        ' Response.Redirect("WebForm4.aspx")
        'For i = 0 To RadioButtonList1.Items.Count - 1
        '    If RadioButtonList1.Enabled = True Then
        '        RadioButtonList1.Items(i).Selected = False
        '        RadioButtonList2.Items(i).Selected = False
        '        RadioButtonList3.Items(i).Selected = False
        '        RadioButtonList4.Items(i).Selected = False
        '        RadioButtonList5.Items(i).Selected = False
        '        DropDownList1.Focus()
        '    End If
        'Next
        'End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub RadioButtonLists_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged, RadioButtonList2.SelectedIndexChanged, RadioButtonList3.SelectedIndexChanged, RadioButtonList4.SelectedIndexChanged
        'If RadioButtonList1.SelectedItem.Selected = False Or RadioButtonList2.SelectedItem.Selected = False Or RadioButtonList3.SelectedItem.Selected = False Or RadioButtonList4.SelectedItem.Selected = False Then
        '    MessageBox("select text or textarea")
        'Else
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

        'End If
    End Sub
    Protected Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        'If TextBox1.Text = "" Or ListBox1.SelectedItem.Selected = False Or DropDownList1.SelectedItem.Selected = False Then
        '    MessageBox("pls select dropdown item and listbox item first then type letter name")
        '    TextBox1.Focus()
        'End If

        If TextBox1.Text = "" Or ListBox1.SelectedItem.Selected = False Then
            MessageBox("pls select dropdown item and listbox item first then type letter name")
            TextBox1.Focus()
        End If



    End Sub

    
End Class
