Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class rPTlEAVEoVERALLSUMMARY
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
            MyScreenId = (30)
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
        '  Session("_edept") = "9000"

        thisdate = DateTime.Now

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (30)
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
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub rdosumby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdosumby.SelectedIndexChanged
       
        If rdosumby.SelectedValue = "Dept" Then
            ddlsumdept.Enabled = True
            ddlsumsect.Enabled = False
            ddlsumdesig.Enabled = False
            txtsumemp.Enabled = False
        ElseIf rdosumby.SelectedValue = "Sect" Then

            ddlsumdept.Enabled = True
            ddlsumsect.Enabled = True
            ddlsumdesig.Enabled = False
            txtsumemp.Enabled = False
        ElseIf rdosumby.SelectedValue = "Desig" Then

            ddlsumdept.Enabled = False
            ddlsumsect.Enabled = False
            ddlsumdesig.Enabled = True
            txtsumemp.Enabled = False
        ElseIf rdosumby.SelectedValue = "Emp" Then

            ddlsumdept.Enabled = False
            ddlsumsect.Enabled = False
            ddlsumdesig.Enabled = False
            txtsumemp.Enabled = True
        Else
            ddlsumdept.Enabled = False
            ddlsumsect.Enabled = False
            ddlsumdesig.Enabled = False
            txtsumemp.Enabled = False
        End If
    End Sub

    Protected Sub btnsumrpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsumrpt.Click

        Session("rptcategory") = DropDownList3.SelectedValue.Trim

        Dim sect As String = ddlsumsect.SelectedValue.Trim
        Dim dept As String = ddlsumdept.SelectedValue.Trim
        Dim desig As String = ddlsumdesig.SelectedValue.Trim
        Dim emp As String = txtsumemp.Text.Trim
        Dim rdvalue As String = rdosumby.SelectedValue.Trim

        Dim fd1 As String
        fd1 = txtsumfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = txtsumto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)

        Dim lintRowCount As Integer = 0
        Dim i As Integer = 0
        Dim selemp As String

        If rdvalue = "Dept" And dept <> "" Then
            DeleteTempleave()
            If Session("rptcategory").ToString().Trim.Equals("All") Then
                GetEmpByDept(dept)
            Else
                GetEmpByDeptByCategory(dept, Session("rptcategory"))
            End If

            If recstatus = True Then
                Dim dr1 As DataRow
                If dsdata1.Tables(0).Rows.Count > 0 Then
                    lintRowCount = dsdata1.Tables(0).Rows.Count
                    For i = 0 To lintRowCount - 1
                        DR = dsdata1.Tables(0).Rows(i)
                        selemp = DR("empcode").ToString
                        leavesummarycalc(selemp, fd, td)
                    Next
                End If
                Response.Redirect("~/hrmis/leave/reports/overallleavesummary.aspx")
            End If
        ElseIf rdvalue = "Sect" And sect <> "" Then
            DeleteTempleave()
            If Session("rptcategory").ToString().Trim.Equals("All") Then
                GetEmpBysect(sect)
            Else
                GetEmpBysectByCategory(sect, Session("rptcategory"))
            End If

            If recstatus = True Then
                Dim dr1 As DataRow
                If dsdata1.Tables(0).Rows.Count > 0 Then
                    lintRowCount = dsdata1.Tables(0).Rows.Count
                    For i = 0 To lintRowCount - 1
                        DR = dsdata1.Tables(0).Rows(i)
                        selemp = DR("empcode").ToString
                        leavesummarycalc(selemp, fd, td)
                    Next
                End If
                Response.Redirect("~/hrmis/leave/reports/overallleavesummary.aspx")
            End If

        ElseIf rdvalue = "Desig" And desig <> "" Then
            DeleteTempleave()
            If Session("rptcategory").ToString().Trim.Equals("All") Then
                GetEmpByDesig(desig)
            Else
                GetEmpByDesigByCategory(desig, Session("rptcategory"))
            End If

            If recstatus = True Then
                Dim dr1 As DataRow
                If dsdata1.Tables(0).Rows.Count > 0 Then
                    lintRowCount = dsdata1.Tables(0).Rows.Count
                    For i = 0 To lintRowCount - 1
                        DR = dsdata1.Tables(0).Rows(i)
                        selemp = DR("empcode").ToString
                        leavesummarycalc(selemp, fd, td)
                    Next
                End If
                Response.Redirect("~/hrmis/leave/reports/overallleavesummary.aspx")
            End If
        ElseIf rdvalue = "Emp" And emp <> "" Then
            DeleteTempleave()
            leavesummarycalc(emp, fd, td)
            Response.Redirect("~/hrmis/leave/reports/overallleavesummary.aspx")
        Else
            DeleteTempleave()

            If Session("rptcategory").ToString().Trim.Equals("All") Then
                GetEmpall()
            Else
                GetEmpallByCategory(Session("rptcategory"))
            End If

            If recstatus = True Then
                Dim dr1 As DataRow
                If dsdata1.Tables(0).Rows.Count > 0 Then
                    lintRowCount = dsdata1.Tables(0).Rows.Count
                    For i = 0 To lintRowCount - 1
                        Try
                            DR = dsdata1.Tables(0).Rows(i)
                            selemp = DR("empcode").ToString
                            leavesummarycalc(selemp, fd, td)
                        Catch ex As Exception

                        End Try

                    Next
                End If
                Response.Redirect("~/hrmis/leave/reports/overallleavesummary.aspx")
            End If
        End If

    End Sub
    Private Sub leavesummarycalc(ByVal emp As String, ByVal fd As Date, ByVal td As Date)

        GetEmpVehino(emp)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                doj = dr("dateofjoin").ToString
            End If
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
        GetLeaveLevel(emp, expr)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                'doj = dr("dateofjoin").ToString
                ann = dr("annual").ToString
                med = dr("medical").ToString
                probation = dr("probation").ToString
            End If
        End If
        ' Get the balance annual and Medical leave
        Dim leavetaken As Decimal
        leavetaken = 0
        Dim mLeavetaken As Decimal
        mLeavetaken = 0
        Dim eleavetaken As Decimal
        eleavetaken = 0
        Dim eupleavetaken As Decimal
        eupleavetaken = 0
        Dim peupleavetaken As Decimal
        peupleavetaken = 0
        Dim peleavetaken As Decimal
        peleavetaken = 0
        Dim upleavetaken As Decimal
        upleavetaken = 0
        Dim hospital As Decimal
        hospital = 0


        ' find ann leave taken
        Countallleave(emp, fd, td, "annual")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    leavetaken = 0
                Else
                    leavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find medical leave taken
        Countallleave(emp, fd, td, "medical")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    mLeavetaken = 0
                Else
                    mLeavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find emergency leave taken
        Countallleave(emp, fd, td, "emergency")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    eleavetaken = 0
                Else
                    eleavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find emergencyup leave taken
        Countallleave(emp, fd, td, "emergencyUP")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    eupleavetaken = 0
                Else
                    eupleavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find plan emergency leave taken
        Countallleave(emp, fd, td, "Planemergency")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    peleavetaken = 0
                Else
                    peleavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find plan emergencyUP leave taken
        Countallleave(emp, fd, td, "PlanemergencyUP")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    peupleavetaken = 0
                Else
                    peupleavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find plan emergencyUP leave taken
        Countallleave(emp, fd, td, "unpaid")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    upleavetaken = 0
                Else
                    upleavetaken = dr("leavetaken").ToString
                End If
            End If
        End If

        ' find plan Hospitalization leave taken
        Countallleave(emp, fd, td, "Hospitalization")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    hospital = 0
                Else
                    hospital = dr("leavetaken").ToString
                End If
            End If
        End If


        ' find compassionate leave taken
        Dim other As Integer
        other = 0
        Countotherleave(emp, fd, td)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If dr("leavetaken") Is System.DBNull.Value Then
                    other = 0
                Else
                    other = other + dr("leavetaken").ToString
                End If
            End If
        End If
        Insertallleave(emp, ann, med, leavetaken, mLeavetaken, eleavetaken, peleavetaken, eupleavetaken, peupleavetaken, upleavetaken, other, hospital)
    End Sub
End Class