Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class newrecruitmentrgridreport
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rdr As SqlDataReader
    Dim con As New SqlConnection(constr)
    Dim cmd As New SqlCommand
    Dim sqltext, sts, s1, s2, s3, s4, s5, s6 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        con = New SqlConnection(constr)
        con.Open()
        sts = Session("sts")
        s1 = Session("common")
        s2 = Session("allfromd")
        s3 = Session("alltod")
        s4 = Session("rb")
        s5 = Session("stscommon")
        s6 = Session("desigu")
        If sts <> "" Then
            sqltext = "select requisitionno as ReqNo,requestdate as DateApplied,requireddate as Daterequired,Requestorempcode as ReqEmpcode,Gender,equalification as Qualification,pqualification as ProfQualification,experiencedetails as Experience,Otherskills,Designation,Vacancies,postvacant as Reasonforvacancies,Responsibilites,JobDescription,Status from man_request where status='" & sts & "' order by  requisitionno"
        Else
            If s1 = "a" And s5 = "-1" Then
                sqltext = "select requisitionno as ReqNo,Requestorempcode as Empcode,Gender,requestdate as DateApplied,requireddate as Daterequired,equalification as Qualification,pqualification as ProfQualification,experiencedetails as Experience,Otherskills,Designation,Vacancies,postvacant as Reasonforvacancies,Responsibilites,JobDescription,Status from man_request where requestdate>='" & s2 & "' and requestdate<='" & s3 & "' order by  requisitionno"
            ElseIf s1 = "a" And s5 <> "-1" Then
                sqltext = "select requisitionno as ReqNo,Requestorempcode as Empcode,Gender,requestdate as DateApplied,requireddate as Daterequired,equalification as Qualification,pqualification as ProfQualification,experiencedetails as Experience,Otherskills,Designation,Vacancies,postvacant as Reasonforvacancies,Responsibilites,JobDescription,Status from man_request where (requestdate>='" & s2 & "' and requestdate<='" & s3 & "') and (status='" & s5 & "') order by  requisitionno"
            ElseIf s4 = "Dept" And s5 = "-1" Then
                sqltext = "select man_request.requisitionno as ReqNo,man_request.requestorempcode as Empcode,man_request.Gender,empmaster.Departmentcode as Dept,man_request.requestdate as DateApplied,man_request.requireddate as Daterequired,man_request.equalification as Qualification,man_request.pqualification as ProfQualification,man_request.experiencedetails as Experience,man_request.Otherskills,man_request.Designation as Desig,man_request.Vacancies,man_request.postvacant as Reasonforvacancies,man_request.Responsibilites,man_request.JobDescription,man_request.Status from man_request inner join empmaster on empmaster.empcode=man_request.requestorempcode where (empmaster.departmentcode='" & s1 & "') and (requestdate>='" & s2 & "' and requestdate<='" & s3 & "') order by  requisitionno "
            ElseIf s4 = "Dept" And s5 <> "-1" Then
                sqltext = "select man_request.requisitionno as ReqNo,man_request.requestorempcode as Empcode,man_request.Gender,empmaster.Departmentcode as Dept,man_request.requestdate as DateApplied,man_request.requireddate as Daterequired,man_request.equalification as Qualification,man_request.pqualification as ProfQualification,man_request.experiencedetails as Experience,man_request.Otherskills,man_request.Designation as Desig,man_request.Vacancies,man_request.postvacant as Reasonforvacancies,man_request.Responsibilites,man_request.JobDescription,man_request.Status from man_request inner join empmaster on empmaster.empcode=man_request.requestorempcode where (empmaster.departmentcode='" & s1 & "') and (requestdate>='" & s2 & "' and requestdate<='" & s3 & "') and status='" & s5 & "' order by  requisitionno "
            ElseIf s4 = "Desig" And s5 = "-1" Then
                sqltext = "select requisitionno as ReqNo,Requestorempcode as Empcode,Gender,requestdate as DateApplied,requireddate as Daterequired,equalification as Qualification,pqualification as ProfQualification,experiencedetails as Experience,Otherskills,Designation,Vacancies,postvacant as Reasonforvacancies,Responsibilites,JobDescription,Status from man_request where (requestdate>='" & s2 & "' and requestdate<='" & s3 & "') and designation='" & s1 & "' order by  requisitionno"
            ElseIf s4 = "Desig" And s5 <> "-1" Then
                sqltext = "select requisitionno as ReqNo,Requestorempcode as Empcode,Gender,requestdate as DateApplied,requireddate as Daterequired,equalification as Qualification,pqualification as ProfQualification,experiencedetails as Experience,Otherskills,Designation,Vacancies,postvacant as Reasonforvacancies,Responsibilites,JobDescription,Status from man_request where (requestdate>='" & s2 & "' and requestdate<='" & s3 & "') and designation='" & s1 & "' and status='" & s5 & "' order by  requisitionno"
            ElseIf s4 = "DD" And s5 = "-1" Then
                sqltext = "select man_request.requisitionno as ReqNo,empmaster.Departmentcode as Dept,man_request.Designation,man_request.requestdate as DateApplied,man_request.requireddate as Daterequired,man_request.requestorempcode as ReqEmpcode,man_request.Gender,man_request.equalification as Qualification,man_request.pqualification as ProfQualification,man_request.experiencedetails as Experience,man_request.Otherskills,man_request.Vacancies,man_request.postvacant as Reasonforvacancies,man_request.Responsibilites,man_request.JobDescription,man_request.Status from man_request inner join empmaster on empmaster.empcode=man_request.requestorempcode where empmaster.departmentcode='" & s1 & "' and (requestdate>='" & s2 & "' and requestdate<='" & s3 & "') and (man_request.designation='" & s6 & "') order by  requisitionno"
            ElseIf s4 = "DD" And s5 <> "-1" Then
                sqltext = "select man_request.requisitionno as ReqNo,empmaster.Departmentcode as Dept,man_request.Designation,man_request.requestdate as DateApplied,man_request.requireddate as Daterequired,man_request.requestorempcode as ReqEmpcode,man_request.Gender,man_request.equalification as Qualification,man_request.pqualification as ProfQualification,man_request.experiencedetails as Experience,man_request.Otherskills,man_request.Vacancies,man_request.postvacant as Reasonforvacancies,man_request.Responsibilites,man_request.JobDescription,man_request.Status from man_request inner join empmaster on empmaster.empcode=man_request.requestorempcode where empmaster.departmentcode='" & s1 & "' and (requestdate>='" & s2 & "' and requestdate<='" & s3 & "') and (man_request.designation='" & s6 & "')  and (man_request.status='" & s5 & "') order by  requisitionno"
            End If
        End If
        If IsPostBack = True Then
            sqltext = Session("page")
        End If
        DS = GetappCharactersetting(sqltext)
        GridView1.DataSource = DS
        GridView1.DataBind()
        If IsPostBack = False Then
            Session("page") = sqltext
        End If
        Session("sts") = ""
        Session("common") = ""
        Session("allfromd") = ""
        Session("alltod") = ""
        Session("rb") = ""
        Session("stscommon") = ""
        Session("desigu") = ""
    End Sub
    Function GetappCharactersetting(ByVal sqltext As String) As DataSet
        Dim ds As New DataSet()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "character")
        con.Close()
        Return ds
    End Function
    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim r As Integer
        r = e.Row.Cells.Count - 1
        For i As Integer = 0 To GridView1.Rows.Count - 1
            If GridView1.Rows(i).Cells(3).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(3).Text = GridView1.Rows(i).Cells(3).Text.Replace("12:00:00 AM", "")
            ElseIf GridView1.Rows(i).Cells(4).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(4).Text = GridView1.Rows(i).Cells(4).Text.Replace("12:00:00 AM", "")
            ElseIf GridView1.Rows(i).Cells(5).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(5).Text = GridView1.Rows(i).Cells(5).Text.Replace("12:00:00 AM", "")
            ElseIf GridView1.Rows(i).Cells(6).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(6).Text = GridView1.Rows(i).Cells(6).Text.Replace("12:00:00 AM", "")
            ElseIf GridView1.Rows(i).Cells(1).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(1).Text = GridView1.Rows(i).Cells(1).Text.Replace("12:00:00 AM", "")
            ElseIf GridView1.Rows(i).Cells(2).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(2).Text = GridView1.Rows(i).Cells(2).Text.Replace("12:00:00 AM", "")
            End If
            GridView1.Rows(i).Cells(r).Text = GridView1.Rows(i).Cells(r).Text & "."
            If GridView1.Rows(i).Cells(r).Text.Contains("A.") = True Then
                GridView1.Rows(i).Cells(r).Text = GridView1.Rows(i).Cells(r).Text.Replace("A.", "Pending")
            ElseIf GridView1.Rows(i).Cells(r).Text.Contains("H.") = True Then
                GridView1.Rows(i).Cells(r).Text = GridView1.Rows(i).Cells(r).Text.Replace("H.", "Hired")
            ElseIf GridView1.Rows(i).Cells(r).Text.Contains("O.") = True Then
                GridView1.Rows(i).Cells(r).Text = GridView1.Rows(i).Cells(r).Text.Replace("O.", "OnHold")
            ElseIf GridView1.Rows(i).Cells(r).Text.Contains("S.") = True Then
                GridView1.Rows(i).Cells(r).Text = GridView1.Rows(i).Cells(r).Text.Replace("S.", "Scheduled")
            ElseIf GridView1.Rows(i).Cells(r).Text.Contains("C.") = True Then
                GridView1.Rows(i).Cells(r).Text = GridView1.Rows(i).Cells(r).Text.Replace("C.", "Cancelled")
            ElseIf GridView1.Rows(i).Cells(r).Text.Contains(".") = True Then
                GridView1.Rows(i).Cells(r).Text = GridView1.Rows(i).Cells(r).Text.Replace(".", "")
            End If
        Next
    End Sub
    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If Session("page").ToString.Contains("desc") = True Then
            Session("page") = Session("page").ToString.Replace("desc", "")
        Else
            Session("page") = Session("page") & " desc"
        End If
    End Sub
End Class