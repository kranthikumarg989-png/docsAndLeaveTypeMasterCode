Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class replacementgridreport
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim rdr As SqlDataReader
    Dim con As New SqlConnection(constr)
    Dim cmd As New SqlCommand
    Dim sqltext, sests, s1, s2, s3, s4, s5, s6 As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        con = New SqlConnection(constr)
        con.Open()
        sests = Session("sts")
        s1 = Session("common")
        s2 = Session("allfromd")
        s3 = Session("alltod")
        s4 = Session("rb")
        s5 = Session("stscommon")
        s6 = Session("desigu")
        If sests <> "" Then
            sqltext = "select Requisitionno as ReqNo,Requestdate as Dateapplied,Requireddate,Requestorempcode as ReqEmpcode,resignedempcode as Resignedempcode ,Gender,rdesignation as Reqdesignation,equalification as Qualification,pqualification as professionalqualification,experiencedetails as Exp,Otherskills,Jobdescription,Noofmonth,Status,Newempcode,Datehired from man_replace where status='" & sests & "' order by Requisitionno"
        Else
            If s1 = "a" And s5 = "-1" Then
                sqltext = "select Requisitionno as ReqNo,Requestdate as Dateapplied,Requireddate,Requestorempcode as ReqEmpcode,resignedempcode as Resignedempcode ,Gender,rdesignation as Reqdesignation,equalification as Qualification,pqualification as professionalqualification,experiencedetails as Exp,Otherskills,Jobdescription,Noofmonth,Status,Newempcode,Datehired from man_replace where requestdate>='" & s2 & "' and requestdate<='" & s3 & "' order by Requisitionno"
            ElseIf s1 = "a" And s5 <> "-1" Then
                sqltext = "select Requisitionno as ReqNo,Requestdate as Dateapplied,Requireddate,Requestorempcode as ReqEmpcode,resignedempcode as Resignedempcode ,Gender,rdesignation as Reqdesignation,equalification as Qualification,pqualification as professionalqualification,experiencedetails as Exp,Otherskills,Jobdescription,Noofmonth,Status,Newempcode,Datehired from man_replace where requestdate>='" & s2 & "' and requestdate<='" & s3 & "' and status='" & s5 & "' order by Requisitionno"
            ElseIf s4 = "Dept" And s5 = "-1" Then
                sqltext = "select empmaster.Departmentcode as Dept,man_replace.Requisitionno as ReqNo, man_replace.Requestdate as Dateapplied, man_replace.Requireddate, man_replace.Requestorempcode as ReqEmpcode, man_replace.resignedempcode as Resignedempcode , man_replace.Gender, man_replace.rdesignation as Reqdesignation, man_replace.equalification as Qualification, man_replace.pqualification as professionalqualification, man_replace.experiencedetails as Exp, man_replace.Otherskills, man_replace.Jobdescription, man_replace.Noofmonth, man_replace.Status, man_replace.Newempcode, man_replace.Datehired FROM man_replace INNER JOIN empmaster ON man_replace.resignedempcode = empmaster.empcode WHERE (empmaster.departmentcode = '" & s1 & "') and (man_replace.requestdate >= '" & s2 & "' and man_replace.requestdate <='" & s3 & "')"
            ElseIf s4 = "Dept" And s5 <> "-1" Then
                sqltext = "select empmaster.Departmentcode as Dept,man_replace.Requisitionno as ReqNo, man_replace.Requestdate as Dateapplied, man_replace.Requireddate, man_replace.Requestorempcode as ReqEmpcode, man_replace.resignedempcode as Resignedempcode , man_replace.Gender, man_replace.rdesignation as Reqdesignation, man_replace.equalification as Qualification, man_replace.pqualification as professionalqualification, man_replace.experiencedetails as Exp, man_replace.Otherskills, man_replace.Jobdescription, man_replace.Noofmonth, man_replace.Status, man_replace.Newempcode, man_replace.Datehired FROM man_replace INNER JOIN empmaster ON man_replace.resignedempcode = empmaster.empcode WHERE (empmaster.departmentcode = '" & s1 & "') and (man_replace.requestdate >= '" & s2 & "' and man_replace.requestdate <='" & s3 & "') and (man_replace.status='" & s5 & "')"
            ElseIf s4 = "Sect" And s5 = "-1" Then
                sqltext = "select empmaster.Sectioncode as Sect,man_replace.Requisitionno as ReqNo, man_replace.Requestdate as Dateapplied, man_replace.Requireddate, man_replace.Requestorempcode as ReqEmpcode, man_replace.resignedempcode as Resignedempcode , man_replace.Gender, man_replace.rdesignation as Reqdesignation, man_replace.equalification as Qualification, man_replace.pqualification as professionalqualification, man_replace.experiencedetails as Exp, man_replace.Otherskills, man_replace.Jobdescription, man_replace.Noofmonth, man_replace.Status, man_replace.Newempcode, man_replace.Datehired FROM man_replace INNER JOIN empmaster ON man_replace.resignedempcode = empmaster.empcode WHERE (empmaster.sectioncode = '" & s1 & "') and (man_replace.requestdate >= '" & s2 & "' and man_replace.requestdate <='" & s3 & "')"
            ElseIf s4 = "Sect" And s5 <> "-1" Then
                sqltext = "select empmaster.Sectioncode as Sect,man_replace.Requisitionno as ReqNo, man_replace.Requestdate as Dateapplied, man_replace.Requireddate, man_replace.Requestorempcode as ReqEmpcode, man_replace.resignedempcode as Resignedempcode , man_replace.Gender, man_replace.rdesignation as Reqdesignation, man_replace.equalification as Qualification, man_replace.pqualification as professionalqualification, man_replace.experiencedetails as Exp, man_replace.Otherskills, man_replace.Jobdescription, man_replace.Noofmonth, man_replace.Status, man_replace.Newempcode, man_replace.Datehired FROM man_replace INNER JOIN empmaster ON man_replace.resignedempcode = empmaster.empcode WHERE (empmaster.sectioncode = '" & s1 & "') and (man_replace.requestdate >= '" & s2 & "' and man_replace.requestdate <='" & s3 & "') and (man_replace.status='" & s5 & "')"
            ElseIf s4 = "Desig" And s5 = "-1" Then
                'sqltext = "select empmaster.Designation,man_replace.Requisitionno as ReqNo, man_replace.Requestdate as Dateapplied, man_replace.Requireddate, man_replace.Requestorempcode as ReqEmpcode, man_replace.resignedempcode as Resignedempcode , man_replace.Gender, man_replace.rdesignation as Reqdesignation, man_replace.equalification as Qualification, man_replace.pqualification as professionalqualification, man_replace.experiencedetails, man_replace.Otherskills, man_replace.Jobdescription, man_replace.Noofmonth, man_replace.Status, man_replace.Newempcode, man_replace.Datehired FROM man_replace INNER JOIN empmaster ON man_replace.resignedempcode = empmaster.empcode WHERE (empmaster.designation = '" & s1 & "') and (man_replace.requestdate >= '" & s2 & "' and man_replace.requestdate <='" & s3 & "')"
                sqltext = "select empmaster.Designation as Desig,man_replace.Requisitionno as ReqNo, man_replace.Requestdate as Dateapplied, man_replace.Requireddate, man_replace.Requestorempcode as ReqEmpcode, man_replace.resignedempcode as Resignedempcode , man_replace.Gender,man_replace.equalification as Qualification, man_replace.pqualification as professionalqualification, man_replace.experiencedetails as Exp, man_replace.Otherskills, man_replace.Jobdescription, man_replace.Noofmonth, man_replace.Status, man_replace.Newempcode, man_replace.Datehired FROM man_replace INNER JOIN empmaster ON man_replace.resignedempcode = empmaster.empcode WHERE (empmaster.designation = '" & s1 & "') and (man_replace.requestdate >= '" & s2 & "' and man_replace.requestdate <='" & s3 & "')"
            ElseIf s4 = "Desig" And s5 <> "-1" Then
                'sqltext = "select empmaster.Designation,man_replace.Requisitionno as ReqNo, man_replace.Requestdate as Dateapplied, man_replace.Requireddate, man_replace.Requestorempcode as ReqEmpcode, man_replace.resignedempcode as Resignedempcode , man_replace.Gender, man_replace.rdesignation as Reqdesignation, man_replace.equalification as Qualification, man_replace.pqualification as professionalqualification, man_replace.experiencedetails, man_replace.Otherskills, man_replace.Jobdescription, man_replace.Noofmonth, man_replace.Status, man_replace.Newempcode, man_replace.Datehired FROM man_replace INNER JOIN empmaster ON man_replace.resignedempcode = empmaster.empcode WHERE (empmaster.designation = '" & s1 & "') and (man_replace.requestdate >= '" & s2 & "' and man_replace.requestdate <='" & s3 & "') and (man_replace.status='" & s5 & "')"
                sqltext = "select empmaster.Designation as Desig,man_replace.Requisitionno as ReqNo, man_replace.Requestdate as Dateapplied, man_replace.Requireddate, man_replace.Requestorempcode as ReqEmpcode, man_replace.resignedempcode as Resignedempcode , man_replace.Gender,man_replace.equalification as Qualification, man_replace.pqualification as professionalqualification, man_replace.experiencedetails as Exp, man_replace.Otherskills, man_replace.Jobdescription, man_replace.Noofmonth, man_replace.Status, man_replace.Newempcode, man_replace.Datehired FROM man_replace INNER JOIN empmaster ON man_replace.resignedempcode = empmaster.empcode WHERE (empmaster.designation = '" & s1 & "') and (man_replace.requestdate >= '" & s2 & "' and man_replace.requestdate <='" & s3 & "') and (man_replace.status='" & s5 & "')"
            ElseIf s4 = "DD" And s5 = "-1" Then
                sqltext = "select empmaster.Departmentcode as Dept,man_replace.Rdesignation as Reqdesignation,man_replace.Requisitionno as ReqNo, man_replace.Requestdate as Dateapplied, man_replace.Requireddate, man_replace.Requestorempcode as ReqEmpcode, man_replace.resignedempcode as Resignedempcode , man_replace.Gender,man_replace.equalification as Qualification, man_replace.pqualification as professionalqualification, man_replace.experiencedetails as Exp, man_replace.Otherskills, man_replace.Jobdescription, man_replace.Noofmonth, man_replace.Status, man_replace.Newempcode, man_replace.Datehired FROM man_replace INNER JOIN empmaster ON man_replace.resignedempcode = empmaster.empcode WHERE (empmaster.departmentcode= '" & s1 & "')and (man_replace.rdesignation = '" & s6 & "') and (man_replace.requestdate >= '" & s2 & "' and man_replace.requestdate <='" & s3 & "')"
            ElseIf s4 = "DD" And s5 <> "-1" Then
                sqltext = "select empmaster.Departmentcode as Dept,man_replace.Rdesignation as Reqdesignation,man_replace.Requisitionno as ReqNo, man_replace.Requestdate as Dateapplied, man_replace.Requireddate, man_replace.Requestorempcode as ReqEmpcode, man_replace.resignedempcode as Resignedempcode , man_replace.Gender,man_replace.equalification as Qualification, man_replace.pqualification as professionalqualification, man_replace.experiencedetails as Exp, man_replace.Otherskills, man_replace.Jobdescription, man_replace.Noofmonth, man_replace.Status, man_replace.Newempcode, man_replace.Datehired FROM man_replace INNER JOIN empmaster ON man_replace.resignedempcode = empmaster.empcode WHERE (empmaster.departmentcode= '" & s1 & "')and (man_replace.rdesignation = '" & s6 & "') and (man_replace.requestdate >= '" & s2 & "' and man_replace.requestdate <='" & s3 & "') and (man_replace.status='" & s5 & "')"
            End If
        End If
        If IsPostBack = False Then
            Session("page") = sqltext
        End If
        If IsPostBack = True Then
            sqltext = Session("page")
        End If
        DS = GetappCharactersetting(sqltext)
        GridView1.DataSource = DS
        GridView1.DataBind()
        Session("sts") = ""
        Session("common") = ""
        Session("allfromd") = ""
        Session("alltod") = ""
        Session("rb") = ""
        Session("stscommon") = ""
        Session("desigu") = ""
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim r As Integer
        r = e.Row.Cells.Count - 1
        For i As Integer = 0 To GridView1.Rows.Count - 1
            If GridView1.Rows(i).Cells(1).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(1).Text = GridView1.Rows(i).Cells(1).Text.Replace("12:00:00 AM", "")
            ElseIf GridView1.Rows(i).Cells(2).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(2).Text = GridView1.Rows(i).Cells(2).Text.Replace("12:00:00 AM", "")
            ElseIf GridView1.Rows(i).Cells(3).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(3).Text = GridView1.Rows(i).Cells(3).Text.Replace("12:00:00 AM", "")
            ElseIf GridView1.Rows(i).Cells(4).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(4).Text = GridView1.Rows(i).Cells(4).Text.Replace("12:00:00 AM", "")
            ElseIf GridView1.Rows(i).Cells(r).Text.Contains("12:00:00 AM") = True Then
                GridView1.Rows(i).Cells(r).Text = GridView1.Rows(i).Cells(r).Text.Replace("12:00:00 AM", "")
            ElseIf GridView1.Rows(i).Cells(r).Text.Contains("1/1/1900") = True Then
                GridView1.Rows(i).Cells(r).Text = GridView1.Rows(i).Cells(r).Text.Replace("1/1/1900", "")
            End If
        Next
    End Sub
    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
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
End Class