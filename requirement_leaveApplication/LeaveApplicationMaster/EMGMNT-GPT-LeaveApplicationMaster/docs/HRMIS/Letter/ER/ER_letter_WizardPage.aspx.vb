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

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (184)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                ' MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If

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
        con = New SqlConnection(constr)
        con.Open()
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tb As String
        Dim Y As Integer
        For n As Integer = 2 To 11                         'for compare field validator
            If n = 2 Then
                tb = TextBox2.Text.Trim
            ElseIf n = 3 Then
                tb = TextBox3.Text.Trim
            ElseIf n = 4 Then
                tb = TextBox4.Text.Trim
            ElseIf n = 5 Then
                tb = TextBox5.Text.Trim
            ElseIf n = 6 Then
                tb = TextBox6.Text.Trim
            ElseIf n = 7 Then
                tb = TextBox7.Text.Trim
            ElseIf n = 8 Then
                tb = TextBox8.Text.Trim
            ElseIf n = 9 Then
                tb = TextBox9.Text.Trim
            ElseIf n = 10 Then
                tb = TextBox10.Text.Trim
            ElseIf n = 11 Then
                tb = TextBox11.Text.Trim
            End If
            Y = 0
            If tb.ToString <> "" And TextBox2.Text.Trim <> "" Then
                If (tb.ToString = TextBox2.Text) = True Then
                    Y = Y + 1
                    If Y > 1 Then
                        MessageBox(TextBox2.Text & " already Entered Try Other Name")
                        TextBox2.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If tb.ToString <> "" And TextBox3.Text.Trim <> "" Then
                If (tb.ToString = TextBox3.Text) = True Then
                    Y = Y + 1
                    If Y > 1 Then
                        MessageBox(TextBox3.Text & " already Entered Try Other Name")
                        TextBox3.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If tb.ToString <> "" And TextBox4.Text.Trim <> "" Then
                If (tb.ToString = TextBox4.Text) = True Then
                    Y = Y + 1
                    If Y > 1 Then
                        MessageBox(TextBox4.Text & " already Entered Try Other Name")
                        TextBox4.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If tb.ToString <> "" And TextBox5.Text.Trim <> "" Then
                If tb.ToString = TextBox5.Text Then
                    Y = Y + 1
                    If Y > 1 Then
                        MessageBox(TextBox5.Text & " already Entered Try Other Name")
                        TextBox5.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If tb <> "" And TextBox6.Text.Trim <> "" Then
                If tb = TextBox6.Text Then
                    Y = Y + 1
                    If Y > 1 Then
                        MessageBox(TextBox6.Text & " already Entered Try Other Name")
                        TextBox6.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If tb <> "" And TextBox7.Text.Trim <> "" Then
                If tb = TextBox7.Text Then
                    Y = Y + 1
                    If Y > 1 Then
                        MessageBox(TextBox7.Text & " already Entered Try Other Name")
                        TextBox7.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If tb <> "" And TextBox8.Text.Trim <> "" Then
                If tb = TextBox8.Text Then
                    Y = Y + 1
                    If Y > 1 Then
                        MessageBox(TextBox8.Text & " already Entered Try Other Name")
                        TextBox8.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If tb <> "" And TextBox9.Text.Trim <> "" Then
                If tb = TextBox9.Text Then
                    Y = Y + 1
                    If Y > 1 Then
                        MessageBox(TextBox9.Text & " already Entered Try Other Name")
                        TextBox9.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If tb <> "" And TextBox10.Text.Trim <> "" Then
                If tb = TextBox10.Text Then
                    Y = Y + 1
                    If Y > 1 Then
                        MessageBox(TextBox10.Text & " already Entered Try Other Name")
                        TextBox10.Focus()
                        Exit Sub
                    End If
                End If
            End If
            If tb <> "" And TextBox11.Text.Trim <> "" Then
                If tb = TextBox11.Text Then
                    Y = Y + 1
                    If Y > 1 Then
                        MessageBox(TextBox11.Text & " already Entered Try Other Name")
                        TextBox11.Focus()
                        Exit Sub
                    End If
                End If
            End If
        Next
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
            MessageBox(TextBox1.Text & " was already exist in the database please try other name")
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
                If TextBox2.Text.Trim <> "" And RadioButtonList1.Items.Item(2).Selected = True Then
                    rb = "Text Date"
                End If
            End If
            If n = 2 And TextBox3.Text <> "" Then
                txt = sur & TextBox3.Text
                rbselect()
                rb = rb2
                If TextBox3.Text.Trim <> "" And RadioButtonList2.Items.Item(2).Selected = True Then
                    rb = "Text Date"
                End If
            End If
            If n = 3 And TextBox4.Text <> "" Then
                txt = sur & TextBox4.Text
                rbselect()
                rb = rb3
                If TextBox4.Text.Trim <> "" And RadioButtonList3.Items.Item(2).Selected = True Then
                    rb = "Text Date"
                End If
            End If
            If n = 4 And TextBox5.Text <> "" Then
                txt = sur & TextBox5.Text
                rbselect()
                rb = rb4
                If TextBox5.Text.Trim <> "" And RadioButtonList4.Items.Item(2).Selected = True Then
                    rb = "Text Date"
                End If
            End If
            If n = 5 And TextBox6.Text <> "" Then
                txt = sur & TextBox6.Text
                rbselect()
                rb = rb5
                If TextBox6.Text.Trim <> "" And RadioButtonList5.Items.Item(2).Selected = True Then
                    rb = "Text Date"
                End If
            End If
            If n = 6 And TextBox7.Text <> "" Then
                txt = sur & TextBox7.Text
                rbselect()
                rb = rb6
                If TextBox7.Text.Trim <> "" And RadioButtonList6.Items.Item(2).Selected = True Then
                    rb = "Text Date"
                End If
            End If
            If n = 7 And TextBox8.Text <> "" Then
                txt = sur & TextBox8.Text
                rbselect()
                rb = rb7
                If TextBox8.Text.Trim <> "" And RadioButtonList7.Items.Item(2).Selected = True Then
                    rb = "Text Date"
                End If
            End If
            If n = 8 And TextBox9.Text <> "" Then
                txt = sur & TextBox9.Text
                rbselect()
                rb = rb8
                If TextBox9.Text.Trim <> "" And RadioButtonList8.Items.Item(2).Selected = True Then
                    rb = "Text Date"
                End If
            End If
            If n = 9 And TextBox10.Text <> "" Then
                txt = sur & TextBox10.Text
                rbselect()
                rb = rb9
                If TextBox10.Text.Trim <> "" And RadioButtonList9.Items.Item(2).Selected = True Then
                    rb = "Text Date"
                End If
            End If
            If n = 10 And TextBox11.Text <> "" Then
                txt = sur & TextBox11.Text
                rbselect()
                rb = rb10
                If TextBox11.Text.Trim <> "" And RadioButtonList10.Items.Item(2).Selected = True Then
                    rb = "Text Date"
                End If
            End If
            If n = 1 And TextBox2.Text <> "" Or n = 2 And TextBox3.Text <> "" Or n = 3 And TextBox4.Text <> "" Or n = 4 And TextBox5.Text <> "" Or n = 5 And TextBox6.Text <> "" Or n = 6 And TextBox7.Text <> "" Or n = 7 And TextBox8.Text <> "" Or n = 8 And TextBox9.Text <> "" Or n = 9 And TextBox10.Text <> "" Or n = 10 And TextBox11.Text <> "" Then
                str = "insert into HRMIS_ER_LETTER_WIZARD values( '" & txt & "','" & rb & "','" & (TextBox1.Text) & "','" & (Label1.Text) & "','" & (sur) & "',1)"
                cmd = New SqlCommand(str, con)
                cmd.ExecuteNonQuery()
            End If
        Next
        Server.Transfer("ER_letter_CreatePage.aspx")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class