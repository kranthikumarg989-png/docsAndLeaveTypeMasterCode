Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class ER_ReportsOther
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim tempstr As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        ' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (289)
            If GlobalDsRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDsRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
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
            lettername.Items.Add(New ListItem("---Select Letter Name---", "-1"))
            lettername.Items.Add(New ListItem("Directfinalwarning", "1"))
            lettername.Items.Add(New ListItem("Dismissalletter", "2"))
            lettername.Items.Add(New ListItem("Employeecounseling", "3"))
            lettername.Items.Add(New ListItem("Explanationletter", "4"))
            lettername.Items.Add(New ListItem("Finalwarningletter", "5"))
            lettername.Items.Add(New ListItem("Firstwarning", "6"))
            lettername.Items.Add(New ListItem("Grievance", "7"))
            lettername.Items.Add(New ListItem("Inquiry/chargeletter", "8"))
            lettername.Items.Add(New ListItem("Misconductreport", "9"))
            lettername.Items.Add(New ListItem("Misfinalwarning", "10"))
            lettername.Items.Add(New ListItem("Misfirstwarning letter", "11"))
            lettername.Items.Add(New ListItem("Missing from workplace", "12"))
            lettername.Items.Add(New ListItem("Reporting Late For Work", "13"))
            lettername.Items.Add(New ListItem("Showcausewarning", "14"))
            lettername.Items.Add(New ListItem("SuspensionLetter", "15"))
            lettername.Items.Add(New ListItem("Terminationletter", "16"))
            lettername.Items.Add(New ListItem("Verbalwarningletter", "17"))
            lettername.Items.Add(New ListItem("Writtenwarningletter", "18"))
            ''lettername.Items.Add(New ListItem("ShowCausePoorPerformance", "19"))
        End If
    End Sub
    Protected Sub rb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.SelectedIndexChanged
        If rb1.SelectedValue = "emp" Then
            empcode.Text = ""
            empcode.Enabled = True
            empcode.Focus()
            dept.Enabled = False
            sect.Enabled = False
            ' Session("empcode") = empcode.Text.Trim
        ElseIf rb1.SelectedValue = "dpt" Then
            empcode.Enabled = False
            dept.Enabled = True
            dept.Focus()
            sect.Enabled = False
            '  Session("dept") = dept.SelectedValue.Trim
        ElseIf rb1.SelectedValue = "sec" Then
            empcode.Enabled = False
            dept.Enabled = False
            sect.Enabled = True
            sect.Focus()
            empcode.Enabled = False
            ' Session("sect") = sect.SelectedValue.Trim
        ElseIf rb1.SelectedValue = "all" Then
            empcode.Enabled = False
            dept.Enabled = False
            sect.Enabled = False
            lettername.Focus()
            empcode.Enabled = False
            ' Session("all") = lettername.SelectedValue.Trim
        Else
        End If
    End Sub
    Protected Sub showrepOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrepOT.Click
        If txtfrom.Text.Trim <> "" And txtto.Text.Trim <> "" Then
        Else
            MessageBox("Enter Date Field")
            Exit Sub
        End If
        If lettername.SelectedValue = "-1" Then
            MessageBox("Select Letter Type")
            lettername.Focus()
            Exit Sub
        End If
        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        'Session("allfromd") = fd

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        'Session("alltod") = td
        Call ddlsql()
        If rb1.SelectedValue = "emp" Then
            Session("ec") = empcode.Text.Trim

            If lettername.SelectedValue.Trim = "1" Then
                tempstr = "SELECT er_directfinalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_directfinalwarning.vdate as LetterDate,er_directfinalwarning.reference as Reference,er_directfinalwarning.desmisconduct as MisConduct FROM er_directfinalwarning INNER JOIN  empmaster ON er_directfinalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_directfinalwarning.empcode = '" & Session("ec") & "' and er_directfinalwarning.vdate >= '" & fd & "' AND er_directfinalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "2" Then
                tempstr = "SELECT er_dismissal.empcode as EmpCode,empmaster.empname as EmpName,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_dismissal.er_letterdate as LetterDate,er_dismissal.er_icdate as InquiryDate,er_dismissal.er_ictime as InquiryTime, er_dismissal.er_icplace as InquiryPlace, er_dismissal.er_incidentdate as IncidentDate, er_dismissal.er_listofproperties as ListOfProperties FROM er_dismissal INNER JOIN  empmaster ON er_dismissal.empcode = empmaster.empcode WHERE er_dismissal.empcode = '" & Session("ec") & "' and er_dismissal.er_letterdate >= '" & fd & "' AND er_dismissal.er_letterdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "3" Then
                tempstr = "SELECT er_employeecounseling.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_employeecounseling.cudate as LetterDate,er_employeecounseling.ctime as CounsellingTime, er_employeecounseling.present as present, er_employeecounseling.discussion as Discussion, er_employeecounseling.recomments as Recomments, er_employeecounseling.atfollowup as ACTfollowup, er_employeecounseling.ersection as ERsection, er_employeecounseling.cname as Superior FROM er_employeecounseling INNER JOIN  empmaster ON er_employeecounseling.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_employeecounseling.empcode = '" & Session("ec") & "' and er_employeecounseling.cudate >= '" & fd & "' AND er_employeecounseling.cudate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "4" Then
                tempstr = "SELECT er_explanation.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_explanation.vdate as LetterDate,er_explanation.subjectrefer as Explanation, er_explanation.fdate as FollowingDates FROM er_explanation INNER JOIN  empmaster ON er_explanation.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_explanation.empcode = '" & Session("ec") & "' and er_explanation.vdate >= '" & fd & "' AND er_explanation.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "5" Then
                tempstr = "SELECT er_finalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_finalwarning.vdate as LetterDate,er_finalwarning.performanceperiod as PerformancePeriod FROM er_finalwarning INNER JOIN  empmaster ON er_finalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_finalwarning.empcode ='" & Session("ec") & "' and er_finalwarning.vdate >= '" & fd & "' AND er_finalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "6" Then
                tempstr = "SELECT er_firstwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_firstwarning.vdate as LetterDate,er_firstwarning.counseling as Counselling,er_firstwarning.counselingdate as CounsellingDate FROM er_firstwarning INNER JOIN  empmaster ON er_firstwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_firstwarning.empcode = '" & Session("ec") & "' and er_firstwarning.vdate >= '" & fd & "' AND er_firstwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "7" Then
                tempstr = "SELECT er_grievance.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_grievance.vdate as LetterDate,er_grievance.typeofgrievance as TypeofGrievance, er_grievance.briefgrievance as BriefGrievance FROM er_grievance INNER JOIN  empmaster ON er_grievance.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_grievance.empcode = '" & Session("ec") & "' and er_grievance.vdate >= '" & fd & "' AND er_grievance.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "8" Then
                tempstr = "SELECT er_inquiry.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_inquiry.letterdated as LetterDate,er_inquiry.explanationdated as ExplanationDated, er_inquiry.titlecharges as TitleCharges, er_inquiry.othercharges as OtherCharges, er_inquiry.inquiryhelddate as InquiryHeldOn, er_inquiry.itime as InquiryTime, er_inquiry.iplace as InquiryPlace FROM er_inquiry INNER JOIN  empmaster ON er_inquiry.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_inquiry.empcode='" & Session("ec") & "' and er_inquiry.letterdated >= '" & fd & "' AND er_inquiry.letterdated <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "9" Then
                tempstr = "SELECT er_misconductreport.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misconductreport.vdate as LetterDate,er_misconductreport.rptdescription as RptDescription, er_misconductreport.reportedby as ReportedBy, er_misconductreport.witness as WitnessPerson, er_misconductreport.placelocation as PlaceLocation, er_misconductreport.reasondesc as ReasonDescription, er_misconductreport.dhremarks as Remarks, er_misconductreport.acttakenby as ACTtakenBy, er_misconductreport.erdremarks as ERremarks FROM er_misconductreport INNER JOIN  empmaster ON er_misconductreport.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_misconductreport.empcode = '" & Session("ec") & "' and er_misconductreport.vdate >= '" & fd & "' AND er_misconductreport.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "10" Then
                tempstr = "SELECT er_misfinalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misfinalwarning.vdate as LetterDate,er_misfinalwarning.timedateoffence as TimeDateOffence, er_misfinalwarning.verbalwdate as VerbalWarningDate, er_misfinalwarning.finalwdate as FinalWarning, er_misfinalwarning.misconduct as Misconduct FROM er_misfinalwarning INNER JOIN  empmaster ON er_misfinalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_misfinalwarning.empcode = '" & Session("ec") & "' and er_misfinalwarning.vdate >= '" & fd & "' AND er_misfinalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "11" Then
                tempstr = "SELECT er_misfirstwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misfirstwarning.vdate as LetterDate,er_misfirstwarning.timedateoffence as TimeDateOffence, er_misfirstwarning.verbalwdate as VerbalWarningDate, er_misfirstwarning.sempcode as Superior, er_misfirstwarning.desmisconduct as DescriptionMisconduct FROM er_misfirstwarning INNER JOIN  empmaster ON er_misfirstwarning.empcode = empmaster.empcode  WHERE er_misfirstwarning.empcode= '" & Session("ec") & "' and er_misfirstwarning.vdate >= '" & fd & "' AND er_misfirstwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "12" Then
                tempstr = "SELECT er_missingworkplace.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_missingworkplace.wdate as LetterDate,er_missingworkplace.midate as MissingDate,er_missingworkplace.mitime as MissingTime,er_missingworkplace.mactiontaken as ActionTaken,er_missingworkplace.missuancefrom as LetterIssueFrom, er_missingworkplace.missuanceto as LetterIssueTo FROM er_missingworkplace INNER JOIN  empmaster ON er_missingworkplace.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_missingworkplace.empcode = '" & Session("ec") & "' and er_missingworkplace.wdate >= '" & fd & "' AND er_missingworkplace.wdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "13" Then
                tempstr = "SELECT er_lateforwork.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_lateforwork.warningdate as WarningLetterDate,er_lateforwork.latedate as LateDate,er_lateforwork.timeofwork as LateTime,er_lateforwork.reportactiontaken as ActionTaken,er_lateforwork.issuancefrom as LetterIssueFrom, er_lateforwork.issuanceto as LetterIssueTo FROM er_lateforwork INNER JOIN  empmaster ON er_lateforwork.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_lateforwork.empcode = '" & Session("ec") & "' and er_lateforwork.warningdate >= '" & fd & "' AND er_lateforwork.warningdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "14" Then
                tempstr = "SELECT er_showcauseletter.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_showcauseletter.vdate as LetterDate,er_showcauseletter.reportdate as RptDate, er_showcauseletter.reporthours as RptHours, er_showcauseletter.mdate as MisconductDate, er_showcauseletter.sempname as Superior, er_showcauseletter.misconduct as MisconductDetails FROM er_showcauseletter INNER JOIN  empmaster ON er_showcauseletter.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_showcauseletter.empcode ='" & Session("ec") & "' and er_showcauseletter.vdate >= '" & fd & "' AND er_showcauseletter.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "15" Then
                tempstr = "SELECT er_suspension.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_suspension.vdate as LetterDate,er_suspension.sfromdate as SuspensionFrom,er_suspension.stodate as SuspensionTo FROM er_suspension INNER JOIN  empmaster ON er_suspension.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_suspension.empcode = '" & Session("ec") & "' and er_suspension.vdate >= '" & fd & "' AND er_suspension.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "16" Then
                tempstr = "SELECT er_termination.empcode as EmpCode,empmaster.empname as EmpName,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_termination.designation as Designation,er_termination.tletterdate as LetterDate,er_termination.tappdate as FromDate,er_termination.tdate as ToDate   FROM er_termination INNER JOIN  empmaster ON er_termination.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_termination.empcode = '" & Session("ec") & "' and er_termination.tletterdate >= '" & fd & "' AND er_termination.tletterdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "17" Then
                tempstr = "SELECT er_verbalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_verbalwarning.vdate as LetterDate,er_verbalwarning.desmisconduct as Descriptions,er_verbalwarning.actiontaken as ActionTaken ,er_verbalwarning.reason as Reason  FROM er_verbalwarning INNER JOIN  empmaster ON er_verbalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_verbalwarning.empcode = '" & Session("ec") & "' and er_verbalwarning.vdate >= '" & fd & "' AND er_verbalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "18" Then
                tempstr = "SELECT er_writtenwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_writtenwarning.wwdate as LetterDate,er_writtenwarning.warningdetails as WarningDetails, er_writtenwarning.sempcode as Superior FROM er_writtenwarning INNER JOIN  empmaster ON er_writtenwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_writtenwarning.empcode = '" & Session("ec") & "' and er_writtenwarning.wwdate >= '" & fd & "' AND er_writtenwarning.wwdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "19" Then
                tempstr = "SELECT er_showcausepoor.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_showcausepoor.vdate as LetterDate,er_showcausepoor.letterservedate as LetterServedDate, er_showcausepoor.finalwarningdate as FinalWarning, er_showcausepoor.sempcode as Superior FROM er_showcausepoor INNER JOIN  empmaster ON er_showcausepoor.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_showcausepoor.empcode = '" & Session("ec") & "' and er_showcausepoor.vdate >= '" & fd & "' AND er_showcausepoor.vdate <= '" & td & "'"
                Session("sql") = tempstr

            End If

        ElseIf rb1.SelectedValue = "dpt" Then
            Session("dept") = dept.SelectedValue.Trim

            If lettername.SelectedValue.Trim = "1" Then
                tempstr = "SELECT er_directfinalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_directfinalwarning.vdate as LetterDate,er_directfinalwarning.reference as Reference,er_directfinalwarning.desmisconduct as MisConduct FROM er_directfinalwarning INNER JOIN  empmaster ON er_directfinalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_directfinalwarning.vdate >= '" & fd & "' AND er_directfinalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "2" Then
                tempstr = "SELECT er_dismissal.empcode as EmpCode,empmaster.empname as EmpName,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_dismissal.er_letterdate as LetterDate,er_dismissal.er_icdate as InquiryDate,er_dismissal.er_ictime as InquiryTime, er_dismissal.er_icplace as InquiryPlace, er_dismissal.er_incidentdate as IncidentDate, er_dismissal.er_listofproperties as ListOfProperties FROM er_dismissal INNER JOIN  empmaster ON er_dismissal.empcode = empmaster.empcode  WHERE empmaster.departmentcode = '" & Session("dept") & "' and er_dismissal.er_letterdate >= '" & fd & "' AND er_dismissal.er_letterdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "3" Then
                tempstr = "SELECT er_employeecounseling.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_employeecounseling.cudate as LetterDate,er_employeecounseling.ctime as CounsellingTime, er_employeecounseling.present as present, er_employeecounseling.discussion as Discussion, er_employeecounseling.recomments as Recomments, er_employeecounseling.atfollowup as ACTfollowup, er_employeecounseling.ersection as ERsection, er_employeecounseling.cname as Superior FROM er_employeecounseling INNER JOIN  empmaster ON er_employeecounseling.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_employeecounseling.cudate >= '" & fd & "' AND er_employeecounseling.cudate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "4" Then
                tempstr = "SELECT er_explanation.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_explanation.vdate as LetterDate,er_explanation.subjectrefer as Explanation, er_explanation.fdate as FollowingDates FROM er_explanation INNER JOIN  empmaster ON er_explanation.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_explanation.vdate >= '" & fd & "' AND er_explanation.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "5" Then
                tempstr = "SELECT er_finalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_finalwarning.vdate as LetterDate,er_finalwarning.performanceperiod as PerformancePeriod FROM er_finalwarning INNER JOIN  empmaster ON er_finalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "'and er_finalwarning.vdate >= '" & fd & "' AND er_finalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "6" Then
                tempstr = "SELECT er_firstwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_firstwarning.vdate as LetterDate,er_firstwarning.counseling as Counselling,er_firstwarning.counselingdate as CounsellingDate FROM er_firstwarning INNER JOIN  empmaster ON er_firstwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_firstwarning.vdate >= '" & fd & "' AND er_firstwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "7" Then
                tempstr = "SELECT er_grievance.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_grievance.vdate as LetterDate,er_grievance.typeofgrievance as TypeofGrievance, er_grievance.briefgrievance as BriefGrievance FROM er_grievance INNER JOIN  empmaster ON er_grievance.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_grievance.vdate >= '" & fd & "' AND er_grievance.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "8" Then
                tempstr = "SELECT er_inquiry.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_inquiry.letterdated as LetterDate,er_inquiry.explanationdated as ExplanationDated, er_inquiry.titlecharges as TitleCharges, er_inquiry.othercharges as OtherCharges, er_inquiry.inquiryhelddate as InquiryHeldOn, er_inquiry.itime as InquiryTime, er_inquiry.iplace as InquiryPlace FROM er_inquiry INNER JOIN  empmaster ON er_inquiry.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_inquiry.letterdated >= '" & fd & "' AND er_inquiry.letterdated <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "9" Then
                tempstr = "SELECT er_misconductreport.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misconductreport.vdate as LetterDate,er_misconductreport.rptdescription as RptDescription, er_misconductreport.reportedby as ReportedBy, er_misconductreport.witness as WitnessPerson, er_misconductreport.placelocation as PlaceLocation, er_misconductreport.reasondesc as ReasonDescription, er_misconductreport.dhremarks as Remarks, er_misconductreport.acttakenby as ACTtakenBy, er_misconductreport.erdremarks as ERremarks FROM er_misconductreport INNER JOIN  empmaster ON er_misconductreport.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_misconductreport.vdate >= '" & fd & "' AND er_misconductreport.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "10" Then
                tempstr = "SELECT er_misfinalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misfinalwarning.vdate as LetterDate,er_misfinalwarning.timedateoffence as TimeDateOffence, er_misfinalwarning.verbalwdate as VerbalWarningDate, er_misfinalwarning.finalwdate as FinalWarning, er_misfinalwarning.misconduct as Misconduct FROM er_misfinalwarning INNER JOIN  empmaster ON er_misfinalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_misfinalwarning.vdate >= '" & fd & "' AND er_misfinalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "11" Then
                tempstr = "SELECT er_misfirstwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misfirstwarning.vdate as LetterDate,er_misfirstwarning.timedateoffence as TimeDateOffence, er_misfirstwarning.verbalwdate as VerbalWarningDate, er_misfirstwarning.sempcode as Superior, er_misfirstwarning.desmisconduct as DescriptionMisconduct FROM er_misfirstwarning INNER JOIN  empmaster ON er_misfirstwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_misfirstwarning.vdate >= '" & fd & "' AND er_misfirstwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "12" Then
                tempstr = "SELECT er_missingworkplace.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_missingworkplace.wdate as LetterDate,er_missingworkplace.midate as MissingDate,er_missingworkplace.mitime as MissingTime,er_missingworkplace.mactiontaken as ActionTaken,er_missingworkplace.missuancefrom as LetterIssueFrom, er_missingworkplace.missuanceto as LetterIssueTo FROM er_missingworkplace INNER JOIN  empmaster ON er_missingworkplace.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_missingworkplace.wdate >= '" & fd & "' AND er_missingworkplace.wdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "13" Then
                tempstr = "SELECT er_lateforwork.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_lateforwork.warningdate as WarningLetterDate,er_lateforwork.latedate as LateDate,er_lateforwork.timeofwork as LateTime,er_lateforwork.reportactiontaken as ActionTaken,er_lateforwork.issuancefrom as LetterIssueFrom, er_lateforwork.issuanceto as LetterIssueTo FROM er_lateforwork INNER JOIN  empmaster ON er_lateforwork.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_lateforwork.warningdate >= '" & fd & "' AND er_lateforwork.warningdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "14" Then
                tempstr = "SELECT er_showcauseletter.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_showcauseletter.vdate as LetterDate,er_showcauseletter.reportdate as RptDate, er_showcauseletter.reporthours as RptHours, er_showcauseletter.mdate as MisconductDate, er_showcauseletter.sempname as Superior, er_showcauseletter.misconduct as MisconductDetails FROM er_showcauseletter INNER JOIN  empmaster ON er_showcauseletter.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_showcauseletter.vdate >= '" & fd & "' AND er_showcauseletter.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "15" Then
                tempstr = "SELECT er_suspension.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_suspension.vdate as LetterDate,er_suspension.sfromdate as SuspensionFrom,er_suspension.stodate as SuspensionTo FROM er_suspension INNER JOIN  empmaster ON er_suspension.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_suspension.vdate >= '" & fd & "' AND er_suspension.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "16" Then
                tempstr = "SELECT er_termination.empcode as EmpCode,empmaster.empname as EmpName,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_termination.designation as Designation,er_termination.tletterdate as LetterDate,er_termination.tappdate as FromDate,er_termination.tdate as ToDate   FROM er_termination INNER JOIN  empmaster ON er_termination.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_termination.tletterdate >= '" & fd & "' AND er_termination.tletterdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "17" Then
                tempstr = "SELECT er_verbalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_verbalwarning.vdate as LetterDate,er_verbalwarning.desmisconduct as Descriptions,er_verbalwarning.actiontaken as ActionTaken ,er_verbalwarning.reason as Reason  FROM er_verbalwarning INNER JOIN  empmaster ON er_verbalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_verbalwarning.vdate >= '" & fd & "' AND er_verbalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "18" Then
                tempstr = "SELECT er_writtenwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_writtenwarning.wwdate as LetterDate,er_writtenwarning.warningdetails as WarningDetails, er_writtenwarning.sempcode as Superior FROM er_writtenwarning INNER JOIN  empmaster ON er_writtenwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_writtenwarning.wwdate >= '" & fd & "' AND er_writtenwarning.wwdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "19" Then
                tempstr = "SELECT er_showcausepoor.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_showcausepoor.vdate as LetterDate,er_showcausepoor.letterservedate as LetterServedDate, er_showcausepoor.finalwarningdate as FinalWarning, er_showcausepoor.sempcode as Superior FROM er_showcausepoor INNER JOIN  empmaster ON er_showcausepoor.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.departmentcode = '" & Session("dept") & "' and er_showcausepoor.vdate >= '" & fd & "' AND er_showcausepoor.vdate <= '" & td & "'"
                Session("sql") = tempstr

            End If
        ElseIf rb1.SelectedValue = "sec" Then
            Session("sect") = sect.SelectedValue.Trim

            If lettername.SelectedValue.Trim = "1" Then
                tempstr = "SELECT er_directfinalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_directfinalwarning.vdate as LetterDate,er_directfinalwarning.reference as Reference,er_directfinalwarning.desmisconduct as MisConduct FROM er_directfinalwarning INNER JOIN  empmaster ON er_directfinalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_directfinalwarning.vdate >= '" & fd & "' AND er_directfinalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "2" Then
                tempstr = "SELECT er_dismissal.empcode as EmpCode,empmaster.empname as EmpName,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_dismissal.er_letterdate as LetterDate,er_dismissal.er_icdate as InquiryDate,er_dismissal.er_ictime as InquiryTime, er_dismissal.er_icplace as InquiryPlace, er_dismissal.er_incidentdate as IncidentDate, er_dismissal.er_listofproperties as ListOfProperties FROM er_dismissal INNER JOIN  empmaster ON er_dismissal.empcode = empmaster.empcode  WHERE empmaster.sectioncode = '" & Session("sect") & "' and er_dismissal.er_letterdate >= '" & fd & "' AND er_dismissal.er_letterdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "3" Then
                tempstr = "SELECT er_employeecounseling.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_employeecounseling.cudate as LetterDate,er_employeecounseling.ctime as CounsellingTime, er_employeecounseling.present as present, er_employeecounseling.discussion as Discussion, er_employeecounseling.recomments as Recomments, er_employeecounseling.atfollowup as ACTfollowup, er_employeecounseling.ersection as ERsection, er_employeecounseling.cname as Superior FROM er_employeecounseling INNER JOIN  empmaster ON er_employeecounseling.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_employeecounseling.cudate >= '" & fd & "' AND er_employeecounseling.cudate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "4" Then
                tempstr = "SELECT er_explanation.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_explanation.vdate as LetterDate,er_explanation.subjectrefer as Explanation, er_explanation.fdate as FollowingDates FROM er_explanation INNER JOIN  empmaster ON er_explanation.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_explanation.vdate >= '" & fd & "' AND er_explanation.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "5" Then
                tempstr = "SELECT er_finalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_finalwarning.vdate as LetterDate,er_finalwarning.performanceperiod as PerformancePeriod FROM er_finalwarning INNER JOIN  empmaster ON er_finalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_finalwarning.vdate >= '" & fd & "' AND er_finalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "6" Then
                tempstr = "SELECT er_firstwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_firstwarning.vdate as LetterDate,er_firstwarning.counseling as Counselling,er_firstwarning.counselingdate as CounsellingDate FROM er_firstwarning INNER JOIN  empmaster ON er_firstwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_firstwarning.vdate >= '" & fd & "' AND er_firstwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "7" Then
                tempstr = "SELECT er_grievance.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_grievance.vdate as LetterDate,er_grievance.typeofgrievance as TypeofGrievance, er_grievance.briefgrievance as BriefGrievance FROM er_grievance INNER JOIN  empmaster ON er_grievance.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_grievance.vdate >= '" & fd & "' AND er_grievance.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "8" Then
                tempstr = "SELECT er_inquiry.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_inquiry.letterdated as LetterDate,er_inquiry.explanationdated as ExplanationDated, er_inquiry.titlecharges as TitleCharges, er_inquiry.othercharges as OtherCharges, er_inquiry.inquiryhelddate as InquiryHeldOn, er_inquiry.itime as InquiryTime, er_inquiry.iplace as InquiryPlace FROM er_inquiry INNER JOIN  empmaster ON er_inquiry.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_inquiry.letterdated >= '" & fd & "' AND er_inquiry.letterdated <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "9" Then
                tempstr = "SELECT er_misconductreport.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misconductreport.vdate as LetterDate,er_misconductreport.rptdescription as RptDescription, er_misconductreport.reportedby as ReportedBy, er_misconductreport.witness as WitnessPerson, er_misconductreport.placelocation as PlaceLocation, er_misconductreport.reasondesc as ReasonDescription, er_misconductreport.dhremarks as Remarks, er_misconductreport.acttakenby as ACTtakenBy, er_misconductreport.erdremarks as ERremarks FROM er_misconductreport INNER JOIN  empmaster ON er_misconductreport.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_misconductreport.vdate >= '" & fd & "' AND er_misconductreport.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "10" Then
                tempstr = "SELECT er_misfinalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misfinalwarning.vdate as LetterDate,er_misfinalwarning.timedateoffence as TimeDateOffence, er_misfinalwarning.verbalwdate as VerbalWarningDate, er_misfinalwarning.finalwdate as FinalWarning, er_misfinalwarning.misconduct as Misconduct FROM er_misfinalwarning INNER JOIN  empmaster ON er_misfinalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_misfinalwarning.vdate >= '" & fd & "' AND er_misfinalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "11" Then
                tempstr = "SELECT er_misfirstwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misfirstwarning.vdate as LetterDate,er_misfirstwarning.timedateoffence as TimeDateOffence, er_misfirstwarning.verbalwdate as VerbalWarningDate, er_misfirstwarning.sempcode as Superior, er_misfirstwarning.desmisconduct as DescriptionMisconduct FROM er_misfirstwarning INNER JOIN  empmaster ON er_misfirstwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_misfirstwarning.vdate >= '" & fd & "' AND er_misfirstwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "12" Then
                tempstr = "SELECT er_missingworkplace.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_missingworkplace.wdate as LetterDate,er_missingworkplace.midate as MissingDate,er_missingworkplace.mitime as MissingTime,er_missingworkplace.mactiontaken as ActionTaken,er_missingworkplace.missuancefrom as LetterIssueFrom, er_missingworkplace.missuanceto as LetterIssueTo FROM er_missingworkplace INNER JOIN  empmaster ON er_missingworkplace.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_missingworkplace.wdate >= '" & fd & "' AND er_missingworkplace.wdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "13" Then
                tempstr = "SELECT er_lateforwork.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_lateforwork.warningdate as WarningLetterDate,er_lateforwork.latedate as LateDate,er_lateforwork.timeofwork as LateTime,er_lateforwork.reportactiontaken as ActionTaken,er_lateforwork.issuancefrom as LetterIssueFrom, er_lateforwork.issuanceto as LetterIssueTo FROM er_lateforwork INNER JOIN  empmaster ON er_lateforwork.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_lateforwork.warningdate >= '" & fd & "' AND er_lateforwork.warningdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "14" Then
                tempstr = "SELECT er_showcauseletter.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_showcauseletter.vdate as LetterDate,er_showcauseletter.reportdate as RptDate, er_showcauseletter.reporthours as RptHours, er_showcauseletter.mdate as MisconductDate, er_showcauseletter.sempname as Superior, er_showcauseletter.misconduct as MisconductDetails FROM er_showcauseletter INNER JOIN  empmaster ON er_showcauseletter.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_showcauseletter.vdate >= '" & fd & "' AND er_showcauseletter.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "15" Then
                tempstr = "SELECT er_suspension.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_suspension.vdate as LetterDate,er_suspension.sfromdate as SuspensionFrom,er_suspension.stodate as SuspensionTo FROM er_suspension INNER JOIN  empmaster ON er_suspension.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_suspension.vdate >= '" & fd & "' AND er_suspension.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "16" Then
                tempstr = "SELECT er_termination.empcode as EmpCode,empmaster.empname as EmpName,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_termination.designation as Designation,er_termination.tletterdate as LetterDate,er_termination.tappdate as FromDate,er_termination.tdate as ToDate   FROM er_termination INNER JOIN  empmaster ON er_termination.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_termination.tletterdate >= '" & fd & "' AND er_termination.tletterdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "17" Then
                tempstr = "SELECT er_verbalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_verbalwarning.vdate as LetterDate,er_verbalwarning.desmisconduct as Descriptions,er_verbalwarning.actiontaken as ActionTaken ,er_verbalwarning.reason as Reason  FROM er_verbalwarning INNER JOIN  empmaster ON er_verbalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_verbalwarning.vdate >= '" & fd & "' AND er_verbalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "18" Then
                tempstr = "SELECT er_writtenwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_writtenwarning.wwdate as LetterDate,er_writtenwarning.warningdetails as WarningDetails, er_writtenwarning.sempcode as Superior FROM er_writtenwarning INNER JOIN  empmaster ON er_writtenwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_writtenwarning.wwdate >= '" & fd & "' AND er_writtenwarning.wwdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "19" Then
                tempstr = "SELECT er_showcausepoor.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_showcausepoor.vdate as LetterDate,er_showcausepoor.letterservedate as LetterServedDate, er_showcausepoor.finalwarningdate as FinalWarning, er_showcausepoor.sempcode as Superior FROM er_showcausepoor INNER JOIN  empmaster ON er_showcausepoor.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.sectioncode = '" & Session("sect") & "' and er_showcausepoor.vdate >= '" & fd & "' AND er_showcausepoor.vdate <= '" & td & "'"
                Session("sql") = tempstr

            End If

        ElseIf rb1.SelectedValue = "all" Then
            Session("all") = lettername.SelectedValue.Trim

            If lettername.SelectedValue.Trim = "1" Then
                tempstr = "SELECT er_directfinalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_directfinalwarning.vdate as LetterDate,er_directfinalwarning.reference as Reference,er_directfinalwarning.desmisconduct as MisConduct FROM er_directfinalwarning INNER JOIN  empmaster ON er_directfinalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_directfinalwarning.vdate >= '" & fd & "' AND er_directfinalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "2" Then
                tempstr = "SELECT er_dismissal.empcode as EmpCode,empmaster.empname as EmpName,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_dismissal.er_letterdate as LetterDate,er_dismissal.er_icdate as InquiryDate,er_dismissal.er_ictime as InquiryTime, er_dismissal.er_icplace as InquiryPlace, er_dismissal.er_incidentdate as IncidentDate, er_dismissal.er_listofproperties as ListOfProperties FROM er_dismissal INNER JOIN  empmaster ON er_dismissal.empcode = empmaster.empcode WHERE er_dismissal.er_letterdate >= '" & fd & "' AND er_dismissal.er_letterdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "3" Then
                tempstr = "SELECT er_employeecounseling.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_employeecounseling.cudate as LetterDate,er_employeecounseling.ctime as CounsellingTime, er_employeecounseling.present as present, er_employeecounseling.discussion as Discussion, er_employeecounseling.recomments as Recomments, er_employeecounseling.atfollowup as ACTfollowup, er_employeecounseling.ersection as ERsection, er_employeecounseling.cname as Superior FROM er_employeecounseling INNER JOIN  empmaster ON er_employeecounseling.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_employeecounseling.cudate >= '" & fd & "' AND er_employeecounseling.cudate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "4" Then
                tempstr = "SELECT er_explanation.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_explanation.vdate as LetterDate,er_explanation.subjectrefer as Explanation, er_explanation.fdate as FollowingDates FROM er_explanation INNER JOIN  empmaster ON er_explanation.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_explanation.vdate >= '" & fd & "' AND er_explanation.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "5" Then
                tempstr = "SELECT er_finalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_finalwarning.vdate as LetterDate,er_finalwarning.performanceperiod as PerformancePeriod FROM er_finalwarning INNER JOIN  empmaster ON er_finalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_finalwarning.vdate >= '" & fd & "' AND er_finalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "6" Then
                tempstr = "SELECT er_firstwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_firstwarning.vdate as LetterDate,er_firstwarning.counseling as Counselling,er_firstwarning.counselingdate as CounsellingDate FROM er_firstwarning INNER JOIN  empmaster ON er_firstwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_firstwarning.vdate >= '" & fd & "' AND er_firstwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "7" Then
                tempstr = "SELECT er_grievance.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_grievance.vdate as LetterDate,er_grievance.typeofgrievance as TypeofGrievance, er_grievance.briefgrievance as BriefGrievance FROM er_grievance INNER JOIN  empmaster ON er_grievance.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_grievance.vdate >= '" & fd & "' AND er_grievance.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "8" Then
                tempstr = "SELECT er_inquiry.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_inquiry.letterdated as LetterDate,er_inquiry.explanationdated as ExplanationDated, er_inquiry.titlecharges as TitleCharges, er_inquiry.othercharges as OtherCharges, er_inquiry.inquiryhelddate as InquiryHeldOn, er_inquiry.itime as InquiryTime, er_inquiry.iplace as InquiryPlace FROM er_inquiry INNER JOIN  empmaster ON er_inquiry.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_inquiry.letterdated >= '" & fd & "' AND er_inquiry.letterdated <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "9" Then
                tempstr = "SELECT er_misconductreport.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misconductreport.vdate as LetterDate,er_misconductreport.rptdescription as RptDescription, er_misconductreport.reportedby as ReportedBy, er_misconductreport.witness as WitnessPerson, er_misconductreport.placelocation as PlaceLocation, er_misconductreport.reasondesc as ReasonDescription, er_misconductreport.dhremarks as Remarks, er_misconductreport.acttakenby as ACTtakenBy, er_misconductreport.erdremarks as ERremarks FROM er_misconductreport INNER JOIN  empmaster ON er_misconductreport.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_misconductreport.vdate >= '" & fd & "' AND er_misconductreport.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "10" Then
                tempstr = "SELECT er_misfinalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misfinalwarning.vdate as LetterDate,er_misfinalwarning.timedateoffence as TimeDateOffence, er_misfinalwarning.verbalwdate as VerbalWarningDate, er_misfinalwarning.finalwdate as FinalWarning, er_misfinalwarning.misconduct as Misconduct FROM er_misfinalwarning INNER JOIN  empmaster ON er_misfinalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_misfinalwarning.vdate >= '" & fd & "' AND er_misfinalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "11" Then
                tempstr = "SELECT er_misfirstwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_misfirstwarning.vdate as LetterDate,er_misfirstwarning.timedateoffence as TimeDateOffence, er_misfirstwarning.verbalwdate as VerbalWarningDate, er_misfirstwarning.sempcode as Superior, er_misfirstwarning.desmisconduct as DescriptionMisconduct FROM er_misfirstwarning INNER JOIN  empmaster ON er_misfirstwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_misfirstwarning.vdate >= '" & fd & "' AND er_misfirstwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "12" Then
                tempstr = "SELECT er_missingworkplace.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_missingworkplace.wdate as LetterDate,er_missingworkplace.midate as MissingDate,er_missingworkplace.mitime as MissingTime,er_missingworkplace.mactiontaken as ActionTaken,er_missingworkplace.missuancefrom as LetterIssueFrom, er_missingworkplace.missuanceto as LetterIssueTo FROM er_missingworkplace INNER JOIN  empmaster ON er_missingworkplace.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and empmaster.resigned <> 'Y' and er_missingworkplace.wdate >= '" & fd & "' AND er_missingworkplace.wdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "13" Then
                tempstr = "SELECT er_lateforwork.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_lateforwork.warningdate as WarningLetterDate,er_lateforwork.latedate as LateDate,er_lateforwork.timeofwork as LateTime,er_lateforwork.reportactiontaken as ActionTaken,er_lateforwork.issuancefrom as LetterIssueFrom, er_lateforwork.issuanceto as LetterIssueTo FROM er_lateforwork INNER JOIN  empmaster ON er_lateforwork.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_lateforwork.warningdate >= '" & fd & "' AND er_lateforwork.warningdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "14" Then
                tempstr = "SELECT er_showcauseletter.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_showcauseletter.vdate as LetterDate,er_showcauseletter.reportdate as RptDate, er_showcauseletter.reporthours as RptHours, er_showcauseletter.mdate as MisconductDate, er_showcauseletter.sempname as Superior, er_showcauseletter.misconduct as MisconductDetails FROM er_showcauseletter INNER JOIN  empmaster ON er_showcauseletter.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_showcauseletter.vdate >= '" & fd & "' AND er_showcauseletter.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "15" Then
                tempstr = "SELECT er_suspension.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_suspension.vdate as LetterDate,er_suspension.sfromdate as SuspensionFrom,er_suspension.stodate as SuspensionTo FROM er_suspension INNER JOIN  empmaster ON er_suspension.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_suspension.vdate >= '" & fd & "' AND er_suspension.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "16" Then
                tempstr = "SELECT er_termination.empcode as EmpCode,empmaster.empname as EmpName,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_termination.designation as Designation,er_termination.tletterdate as LetterDate,er_termination.tappdate as FromDate,er_termination.tdate as ToDate   FROM er_termination INNER JOIN  empmaster ON er_termination.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and and er_termination.tletterdate >= '" & fd & "' AND er_termination.tletterdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "17" Then
                tempstr = "SELECT er_verbalwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_verbalwarning.vdate as LetterDate,er_verbalwarning.desmisconduct as Descriptions,er_verbalwarning.actiontaken as ActionTaken ,er_verbalwarning.reason as Reason  FROM er_verbalwarning INNER JOIN  empmaster ON er_verbalwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_verbalwarning.vdate >= '" & fd & "' AND er_verbalwarning.vdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "18" Then
                tempstr = "SELECT er_writtenwarning.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_writtenwarning.wwdate as LetterDate,er_writtenwarning.warningdetails as WarningDetails, er_writtenwarning.sempcode as Superior FROM er_writtenwarning INNER JOIN  empmaster ON er_writtenwarning.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_writtenwarning.wwdate >= '" & fd & "' AND er_writtenwarning.wwdate <= '" & td & "'"
                Session("sql") = tempstr

            ElseIf lettername.SelectedValue.Trim = "19" Then
                tempstr = "SELECT er_showcausepoor.empcode,empmaster.empname,empmaster.departmentcode as Dept,empmaster.sectioncode as Sect, er_showcausepoor.vdate as LetterDate,er_showcausepoor.letterservedate as LetterServedDate, er_showcausepoor.finalwarningdate as FinalWarning, er_showcausepoor.sempcode as Superior FROM er_showcausepoor INNER JOIN  empmaster ON er_showcausepoor.empcode = empmaster.empcode  WHERE empmaster.resigned <> 'Y' and er_showcausepoor.vdate >= '" & fd & "' AND er_showcausepoor.vdate <= '" & td & "'"
                Session("sql") = tempstr
            End If
        End If
        Response.Redirect("ER_OtherReportsGrid.aspx")
    End Sub
    Sub ddlsql()

        If lettername.SelectedValue = 1 Then
            Session("tblname") = "er_misfinalwarning"
            Session("lname") = "Direct Final Warning"
        ElseIf lettername.SelectedValue = 2 Then
            Session("tblname") = "er_dismissal"
            Session("lname") = "Dismissal Letter"
        ElseIf lettername.SelectedValue = 3 Then
            Session("tblname") = "er_employeecounseling"
            Session("lname") = "Employee Counseling"
        ElseIf lettername.SelectedValue = 4 Then
            Session("tblname") = "er_explanation"
            Session("lname") = "Explanationletter"
        ElseIf lettername.SelectedValue = 5 Then
            Session("tblname") = "er_misfinalwarning"
            Session("lname") = "Final Warning Letter"
        ElseIf lettername.SelectedValue = 6 Then
            Session("tblname") = "er_misfirstwarning"
            Session("lname") = "Firstwarning"
        ElseIf lettername.SelectedValue = 7 Then
            Session("tblname") = "er_grievance"
            Session("lname") = "Grievance"
        ElseIf lettername.SelectedValue = 8 Then
            Session("tblname") = "er_inquiry"
            Session("lname") = "Inquiry/charge Letter"
        ElseIf lettername.SelectedValue = 9 Then
            Session("tblname") = "er_misconductreport"
            Session("lname") = "Misconduct Report"
        ElseIf lettername.SelectedValue = 10 Then
            Session("tblname") = "er_misfinalwarning"
            Session("lname") = "Misfinalwarning"
        ElseIf lettername.SelectedValue = 11 Then
            Session("tblname") = "er_misfirstwarning"
            Session("lname") = "Misfirstwarning Letter"
        ElseIf lettername.SelectedValue = 12 Then
            Session("tblname") = "er_missingworkplace"
            Session("lname") = "Missing from workplace"
        ElseIf lettername.SelectedValue = 13 Then
            Session("tblname") = "er_lateforwork"
            Session("lname") = "Reporting Late For Work"
        ElseIf lettername.SelectedValue = 14 Then
            Session("tblname") = "er_showcauseletter"
            Session("lname") = "Showcause Warning"
        ElseIf lettername.SelectedValue = 15 Then
            Session("tblname") = "er_suspension"
            Session("lname") = "Suspension Letter"
        ElseIf lettername.SelectedValue = 16 Then
            Session("tblname") = "er_termination"
            Session("lname") = "Termination Letter"
        ElseIf lettername.SelectedValue = 17 Then
            Session("tblname") = "er_verbalwarning"
            Session("lname") = "Verbal Warning Letter"
        ElseIf lettername.SelectedValue = 18 Then
            Session("tblname") = "er_writtenwarning"
            Session("lname") = "Written Warning Letter"
        ElseIf lettername.SelectedValue = 19 Then
            Session("tblname") = "er_showcausepoor"
            Session("lname") = "ShowCause Poor Performance"

        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class