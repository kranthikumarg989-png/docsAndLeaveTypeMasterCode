Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class EditJS
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Dim revno As Integer
    Dim jpurpose As String
    Dim rno, recno, sno As Integer
    Dim pending As String
    Dim tech, techval, behval As String
    Dim behavior, key As String
    Dim i, j, k, l, m, n As Integer

    Private Sub EditJS_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (130)
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
            MyScreenId = (130)
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
        '  cbtechnical.DataBind()
        '  cbbehavior.DataBind()
    End Sub
    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

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
        n = 0
        Dim sb2 As StringBuilder = New StringBuilder()
        For n = 0 To cbbehavior.Items.Count - 1
            If cbbehavior.Items(n).Selected Then
                sb2.Append(cbbehavior.Items(n).Value & ",")
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

        InsertJS(lblrecno.Text.Trim, txtrevno.Text.Trim, fd, td, lblempcode.Text.Trim, lblcode.Text.Trim, lblpurpose.Text.Trim, pending, tech, behavior)
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
            '  cbtechnical.DataBind()
            '  cbbehavior.DataBind()
            'grdkey.DataBind()
            lstgoal.DataBind()
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    '  Protected Sub txtempcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempcode.TextChanged
    Private Sub getdetails()
        empcode = lblempcode.Text.Trim

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
                Exit Sub

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
        txtrevno.Text = posid - 1
        If txtrevno.Text = "0" Then
            MessageBox("Please Enter JS first using NEW JS link")
            Exit Sub
        End If

        '''''''''''''''''''''''' CODE TO POPULATE TEXT BOX AND CHECKBOXLIST
        GetJS(empcode, txtrevno.Text.Trim)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                txtitem.Text = dr("itempending").ToString
                tech = dr("technical").ToString
                behavior = dr("behaviour").ToString
                recno = dr("recordno").ToString
                txtfrom.Text = Format(Convert.ToDateTime(dr("fromdate")), "dd/MM/yy")
                txtto.Text = Format(Convert.ToDateTime(dr("todate")), "dd/MM/yy")
                lblrecno.Text = recno
                '''''''''CHKBOXLIST ARE STORED WITH COMMA INSIDE DATABASE
                '''''''''REMOVE , AND STORE IT IN ARRAY TO STORE BACK VALUE IN CHK BOX LIST
                Dim strtech() As String = tech.Split(",")

                'For k = 0 To strtech.Length - 1
                '    For j = 0 To cbtechnical.Items.Count - 1
                '        If cbtechnical.Items(j).Text = (strtech(k)) Then
                '            cbtechnical.Items(j).Selected = True
                '        End If
                '    Next
                'Next
                'Dim strbeha() As String = behavior.Split(",")
                'For l = 0 To strbeha.Length - 1
                '    For m = 0 To cbbehavior.Items.Count - 1
                '        If cbbehavior.Items(m).Text = (strbeha(l)) Then
                '            cbbehavior.Items(m).Selected = True
                '        End If
                '    Next
                'Next
            End If
        End If
        GetEmpTempGoal(empcode, recno)
        Dim rcount As Integer = 0
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                rcount = dsdata.Tables(0).Rows.Count
                For i = 0 To rcount - 1
                    dr = dsdata.Tables(0).Rows(i)
                    sno = dr("sno").ToString
                    key = dr("man_keyresult").ToString
                    InsertKeyskilltemp(sno, lblempcode.Text.Trim, key)
                Next
            End If
        End If
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
        Dim a As String
        empcode = lblempcode.Text.Trim
        a = txtkey.Text.Trim
        Getsno(empcode)
        rno = posid
        InserttoJS(rno, lblempcode.Text.Trim, a)
        txtkey.Text = ""
        ' grdkey.DataBind()
        lstgoal.DataBind()
    End Sub

    Private Sub EditJS_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        '  cbbehavior.Items(0).Selected = True
    End Sub

    Private Sub cbtechnical_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbtechnical.DataBound
        '''''''''''''''''''''''' CODE TO POPULATE TEXT BOX AND CHECKBOXLIST
        empcode = lblempcode.Text.Trim
        If empcode = "" Then
            Exit Sub
        End If
        '''''''''CHKBOXLIST ARE STORED WITH COMMA INSIDE DATABASE
        '''''''''REMOVE , AND STORE IT IN ARRAY TO STORE BACK VALUE IN CHK BOX LIST
        Dim strtech() As String = tech.Split(",")
        For k = 0 To strtech.Length - 1
            For j = 0 To cbtechnical.Items.Count - 1
                If cbtechnical.Items(j).Text = (strtech(k)) Then
                    cbtechnical.Items(j).Selected = True
                End If
            Next
        Next
    End Sub

    Private Sub cbbehavior_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbehavior.DataBound
        '''''''''''''''''''''''' CODE TO POPULATE TEXT BOX AND CHECKBOXLIST
        empcode = lblempcode.Text.Trim
        If empcode = "" Then
            Exit Sub
        End If
        '''''''''CHKBOXLIST ARE STORED WITH COMMA INSIDE DATABASE
        '''''''''REMOVE , AND STORE IT IN ARRAY TO STORE BACK VALUE IN CHK BOX LIST
        Dim strbeha() As String = behavior.Split(",")
        For l = 0 To strbeha.Length - 1
            For m = 0 To cbbehavior.Items.Count - 1
                If cbbehavior.Items(m).Text = (strbeha(l)) Then
                    cbbehavior.Items(m).Selected = True
                End If
            Next
        Next
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