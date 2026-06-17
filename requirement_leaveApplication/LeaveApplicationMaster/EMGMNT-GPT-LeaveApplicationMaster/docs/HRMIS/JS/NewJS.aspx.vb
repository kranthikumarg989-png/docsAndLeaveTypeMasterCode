Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class NewJS
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Dim revno As Integer
    Dim jpurpose As String
    Dim rno, recno, sno As Integer
    Dim pending As String
    Dim tech As String
    Dim behavior, key As String

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (129)
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
        MyApp.GetfiscalYear()

        '  Session("empcode") = "014543"
        lblempcode.Text = Session("empcode")
        GetDetails()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (129)
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
        If Not IsPostBack Then
            ' gridjobresult.DataBind()
        End If
    End Sub

    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        GetRecno()
        recno = posid
        pending = txtitem.Text.Trim
        If pending.Length > "500" Then
            MessageBox("Sorry can not enter more than 500 Characters for item pending..!!! Please Retype!!!")
            Exit Sub
        End If

        If pending.Length <= 0 Then
            pending = ""
        Else
            pending = Replace(pending, "'", " ")
        End If

        ''# this is to get all selected items from 
        ''# a checkboxlist tech skills and add it to a string 
        Dim i As Integer = 0
        Dim sb As StringBuilder = New StringBuilder()
        For i = 0 To cbtechnical.Items.Count - 1
            If cbtechnical.Items(i).Selected Then
                sb.Append(cbtechnical.Items(i).Value & ",")
            End If
        Next
        ''# now I want to save the string to the database 
        ''# so I first have to strip the comma at the end 
        Dim tech As String = sb.ToString.Trim(",")

        ''# this is to get all selected items from 
        ''# a checkboxlist behaviour and add it to a string 
        Dim j As Integer = 0
        Dim sb2 As StringBuilder = New StringBuilder()
        For j = 0 To cbbehavior.Items.Count - 1
            If cbbehavior.Items(j).Selected Then
                sb2.Append(cbbehavior.Items(j).Value & ",")
            End If
        Next
        ''# now I want to save the string to the database 
        ''# so I first have to strip the comma at the end 
        Dim behavior As String = sb2.ToString.Trim(",")

        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)

        Dim rcount As Integer
        InsertJS(recno, txtrevno.Text.Trim, fd, td, lblempcode.Text.Trim, lblcode.Text.Trim, lblpurpose.Text.Trim, pending, tech, behavior)
        If recstatus = True Then
            MessageBox("JS added Successfully")
            GetKeyskill(lblempcode.Text.Trim)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    rcount = dsdata.Tables(0).Rows.Count
                    For i = 0 To rcount - 1
                        dr = dsdata.Tables(0).Rows(i)
                        sno = dr("sno").ToString
                        key = dr("man_keyresult").ToString
                        InsertKeyskill(sno, lblempcode.Text.Trim, key, recno)
                    Next
                    DelKeyTemp(lblempcode.Text.Trim)
                End If
            End If
            txtitem.Text = ""
            txtfrom.Text = ""
            txtto.Text = ""
            txtrevno.Text = ""
            cbtechnical.DataBind()
            cbbehavior.DataBind()
            ' grdkey.DataBind()
            lstgoal.DataBind()
            ' lstgoal.Visible = False
            ' ImageButton1.Visible = False
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    ' Protected Sub txtempcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempcode.TextChanged
    'empcode = txtempcode.Text.Trim
    'GetEmpVehino(empcode)
    'If recstatus = True Then
    '    Dim dr As DataRow
    '    If dsdata.Tables(0).Rows.Count > 0 Then
    '        dr = dsdata.Tables(0).Rows(0)
    '        lblename.Text = dr("empname").ToString
    '        lblsect.Text = dr("sectioncode").ToString
    '        lbldept.Text = dr("departmentcode").ToString
    '        lbldesig.Text = dr("designation").ToString
    '    Else
    '        ClearControls()
    '        MessageBox("EmployeeCode doesnot Exist!!")
    '    End If
    'End If
    'GetJobPurpose(empcode)
    'If recstatus = True Then
    '    Dim dr As DataRow
    '    If dsdata.Tables(0).Rows.Count > 0 Then
    '        dr = dsdata.Tables(0).Rows(0)
    '        lblpurpose.ForeColor = Drawing.Color.DarkRed
    '        lblpurpose.Text = dr("jobpurpose").ToString
    '    Else
    '        lblpurpose.ForeColor = Drawing.Color.DarkRed
    '        lblpurpose.Text = "Not Allocated"
    '    End If
    'Else
    '    lblpurpose.ForeColor = Drawing.Color.DarkRed
    '    lblpurpose.Text = "Not Allocated"
    'End If
    'GetJobcode(empcode)
    'If recstatus = True Then
    '    Dim dr As DataRow
    '    If dsdata.Tables(0).Rows.Count > 0 Then
    '        dr = dsdata.Tables(0).Rows(0)
    '        lblcode.ForeColor = Drawing.Color.DarkRed
    '        lblcode.Text = dr("jobcode").ToString
    '    Else
    '        lblcode.ForeColor = Drawing.Color.DarkRed
    '        lblcode.Text = "Not Allocated"
    '    End If
    'Else
    '    lblcode.ForeColor = Drawing.Color.DarkRed
    '    lblcode.Text = "Not Allocated"
    'End If

    'If lbldesig.Text.Trim = "EA" Then
    '    lblcode.Text = "EA"
    'ElseIf lbldesig.Text.Trim = "MD" Then
    '    lblcode.Text = "MD"
    'End If

    'GetRevno(empcode)
    'txtrevno.ForeColor = Drawing.Color.DarkRed
    'txtrevno.Text = posid
    'grdkey.DataBind()
    'End Sub

    Public Sub GetDetails()
        empcode = Session("empcode")
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblename.Text = dr("empname").ToString
                lblsect.Text = dr("sectioncode").ToString
                lbldept.Text = dr("departmentcode").ToString
                lbldesig.Text = dr("designation").ToString
            Else
                ClearControls()
                MessageBox("EmployeeCode doesnot Exist!!")
            End If
        End If
        GetJobPurpose(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblpurpose.ForeColor = Drawing.Color.DarkRed
                lblpurpose.Text = dr("jobpurpose").ToString
            Else
                lblpurpose.ForeColor = Drawing.Color.DarkRed
                lblpurpose.Text = "Not Allocated"
            End If
        Else
            lblpurpose.ForeColor = Drawing.Color.DarkRed
            lblpurpose.Text = "Not Allocated"
        End If
        GetJobcode(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblcode.ForeColor = Drawing.Color.DarkRed
                lblcode.Text = dr("jobcode").ToString
            Else
                lblcode.ForeColor = Drawing.Color.DarkRed
                lblcode.Text = "Not Allocated"
            End If
        Else
            lblcode.ForeColor = Drawing.Color.DarkRed
            lblcode.Text = "Not Allocated"
        End If

        If lbldesig.Text.Trim = "EA" Then
            lblcode.Text = "EA"
        ElseIf lbldesig.Text.Trim = "MD" Then
            lblcode.Text = "MD"
        End If

        GetRevno(empcode)
        txtrevno.ForeColor = Drawing.Color.DarkRed
        txtrevno.Text = posid
        ' grdkey.DataBind()
        lstgoal.DataBind()
    End Sub
    Private Sub ClearControls()
        lblename.Text = ""
        lbldept.Text = ""
        lblsect.Text = ""
        lbldesig.Text = ""
        lblcode.Text = ""
        lblpurpose.Text = ""
        ' txtpurpose.Text = ""
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'lstgoal.Visible = True
        'ImageButton1.Visible = True

        Dim a As String
        empcode = lblempcode.Text.Trim
        a = txtkey.Text.Trim
        Getsno(empcode)
        rno = posid
        InserttoJS(rno, lblempcode.Text.Trim, a)
        txtkey.Text = ""
        lstgoal.DataBind()
        ' grdkey.DataBind()

    End Sub
    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim i
        Dim SelVal
        Dim myarray
        Dim USDCalc, RMcalc
        If lstgoal.SelectedIndex = -1 Then
            Exit Sub
        End If
        For i = 0 To lstgoal.Items.Count - 1
            If lstgoal.Items(i).Selected = True Then
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Dim con As New SqlConnection(constr)
                con.Open()
                SelVal = lstgoal.Items(i).Value
                Cmd = New SqlCommand("delete from [man_temp_keygoal] where rno = '" & SelVal & "'", Con)
                Cmd.ExecuteNonQuery()
            End If
        Next
        ' lstgoal.Items.Remove(SelVal)
        ' lstgoal.Focus()
        lstgoal.DataBind()
    End Sub
End Class