Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class RptLeaveEntitilement
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (34)
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


        _eid = Session("empcode")
        _ename = Session("_ename")
        _edept = Session("_edept")
        ' Session("_edept") = "9000"

        thisdate = DateTime.Now

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (34)
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
    End Sub

    Protected Sub btnentrpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnentrpt.Click

        Dim rptselection As String = rdoentby.SelectedValue.Trim
        Dim seldept As String = ddlentdept.SelectedValue.Trim
        Dim seldesig As String = ddlentdesig.SelectedValue.Trim
        Dim i As Integer = 0
        Dim selemp As String
        Dim lintRowCount As Integer = 0
        If rptselection = "dept" Then
            DeleteTempTab()
            GetEmpByDept(seldept)
            If recstatus = True Then
                Dim dr1 As DataRow
                If dsdata1.Tables(0).Rows.Count > 0 Then
                    lintRowCount = dsdata1.Tables(0).Rows.Count
                    For i = 0 To lintRowCount - 1
                        DR = dsdata1.Tables(0).Rows(i)
                        selemp = DR("empcode").ToString
                        leavecalculation2(selemp)
                        InsertTempTable(selemp, Session("myannual"), Session("myannbal"), Session("mymedical"), Session("mymedbal"), Session("myprorate"))
                    Next
                End If
            Else
                MessageBox("No Records Found")
            End If
            Response.Redirect("~/hrmis/leave/reports/leaveentitilement.aspx")
        ElseIf rptselection = "Desig" Then
            DeleteTempTab()
            GetEmpByDesig(seldesig)
            If recstatus = True Then
                Dim dr1 As DataRow
                If dsdata1.Tables(0).Rows.Count > 0 Then
                    lintRowCount = dsdata1.Tables(0).Rows.Count
                    For i = 0 To lintRowCount - 1
                        DR = dsdata1.Tables(0).Rows(i)
                        selemp = DR("empcode").ToString
                        leavecalculation2(selemp)
                        InsertTempTable(selemp, Session("myannual"), Session("myannbal"), Session("mymedical"), Session("mymedbal"), Session("myprorate"))
                    Next
                End If
            Else
                MessageBox("No Records Found")
            End If
            Response.Redirect("~/hrmis/leave/reports/leaveentitilement.aspx")
        ElseIf rptselection = "emp" Then
            DeleteTempTab()
            leavecalculation2(txtempcode.Text)
            InsertTempTable(txtempcode.Text, Session("myannual"), Session("myannbal"), Session("mymedical"), Session("mymedbal"), Session("myprorate"))

            Response.Redirect("~/hrmis/leave/reports/leaveentitilement.aspx")
        End If
    End Sub

    Protected Sub rdoentby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoentby.SelectedIndexChanged
       
        If rdoentby.SelectedValue.Trim = "dept" Then
            ddlentdesig.Enabled = False
            ddlentdept.Enabled = True
            txtempcode.Enabled = False
        ElseIf rdoentby.SelectedValue.Trim = "Desig" Then
            ddlentdesig.Enabled = True
            ddlentdept.Enabled = False
            txtempcode.Enabled = False
        ElseIf rdoentby.SelectedValue.Trim = "emp" Then
            ddlentdesig.Enabled = False
            ddlentdept.Enabled = False
            txtempcode.Enabled = True
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Public Sub leavecalculation2(ByVal empid As String)
        GetEmpVehino(empid)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                doj = dr("dateofjoin").ToString
            End If
        Else
            lblmsg.Text = myerrormsg & " Record not saved..Try again"
            lblmsg.ForeColor = Drawing.Color.Red
        End If
        ' find the experience of employee
        Dim exp As String
        Dim ann As Decimal
        Dim med As Decimal
        Dim probation As Decimal
        Dim expr As Integer
        Dim expmth As Integer
        expr = 0
        ann = 0
        med = 0
        probation = 0

        exp = thisdate.Subtract(doj).Days
        expmth = exp / 30
        exp = Math.Round(expmth / 12, 1)

        If exp < 2 Then
            expr = 2
        ElseIf exp >= 2 And exp < 5 Then
            expr = 3
        ElseIf exp >= 5 Then
            expr = 5
        End If

        ' Get the leave entitilement of the employee
        GetLeaveLevel(empid, expr)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                'doj = dr("dateofjoin").ToString
                ann = dr("annual").ToString
                med = dr("medical").ToString
                probation = dr("probation").ToString
            End If
        Else
            lblmsg.Text = myerrormsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
        ' Get the balance annual and Medical leave
        Dim leavetaken As Decimal
        leavetaken = 0
        Dim mLeavetaken As Decimal
        mLeavetaken = 0
        Dim balAleave As Decimal
        balAleave = 0
        Dim balMleave As Decimal
        balMleave = 0

        CountAnnualLeaveTaken(empid, _fisyrStart, _fisyrEnd)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("annual") Is System.DBNull.Value Then
                    leavetaken = 0
                Else
                    leavetaken = dr("annual").ToString
                End If
            End If
        Else
            lblmsg.Text = myerrormsg & " Record not saved..Try again"
            lblmsg.ForeColor = Drawing.Color.Red
        End If


        CountMedicalLeaveTaken(empid, _fisyrStart, _fisyrEnd)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("medical") Is System.DBNull.Value Then
                    mLeavetaken = 0
                Else
                    mLeavetaken = dr("medical").ToString
                End If
            End If
        Else
            lblmsg.Text = myerrormsg & " Record not saved..Try again"
            lblmsg.ForeColor = Drawing.Color.Red
        End If

        balMleave = med - mLeavetaken
        balAleave = ann - leavetaken

        Session("myannual") = ann
        Session("myannbal") = balAleave
        Session("mymedical") = med
        Session("mymedbal") = balMleave

        'prorate calculation
        Dim prorate As Decimal
        Dim workeddays As Decimal

        prorate = 0
        workeddays = 0
        If expmth > probation Then
            If doj > _fisyrStart Then
                workeddays = thisdate.Subtract(doj).Days
                prorate = (workeddays / 365) * ann
            Else
                workeddays = thisdate.Subtract(_fisyrStart).Days
                prorate = (workeddays / 365) * ann
                'prorate = Math.Round(prorate, 1)
                prorate = Math.Round(prorate - leavetaken, 1)
            End If
        Else
            prorate = 0
        End If
        Session("myprorate") = prorate
        'lbltxtempid.Text = empID
    End Sub

    Protected Sub txtempcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempcode.TextChanged
        Dim empcode
        empcode = txtempcode.Text.Trim
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
            End If
        End If
    End Sub
End Class