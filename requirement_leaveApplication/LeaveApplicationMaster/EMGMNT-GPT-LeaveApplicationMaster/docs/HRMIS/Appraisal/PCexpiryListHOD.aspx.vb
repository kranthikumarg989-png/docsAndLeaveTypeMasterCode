Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class PCexpiryListHOD
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode
    Dim thisdate As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        'Session("empcode") = "014543"
        'Session("dept") = "9000"
        thisdate = Date.Now
        GetHeadDept()
    End Sub
    Public Sub Printappraisal(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim empcode
        empcode = e.CommandArgument
        'Session("leaveeditnum") = appno
        'Response.Redirect("leaveform.aspx")
    End Sub

    Protected Sub Appraisal_view(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("empappl") = e.CommandArgument
        Response.Redirect("staffAppraisal.aspx")
        'Dim en
        'en = e.CommandArgument
        'Session("employeecode") = en
        'Response.Redirect("StaffAppraisalFinalReport.aspx")

    End Sub

    Protected Sub Appraisal_view1(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("optempapp") = e.CommandArgument
        Response.Redirect("OptappraisalHODVIew.aspx")
    End Sub



    Private Sub GetHeadDept()
        Dim dsh As DataSet
        Dim drh As DataRow
        Dim headdept, mydept

        dsh = GetHeadAssignment()
        If dsh.Tables(0).Rows.Count > 0 Then
            drh = dsh.Tables(0).Rows(0)
            mydept = drh("ldepartmentcode").ToString
            Dim hoddepts = mydept.split(",")
            For i As Integer = 0 To hoddepts.Length - 1
                headdept = headdept & "'" & hoddepts(i) & "',"
            Next
            headdept = headdept.remove(headdept.length - 1, 1)
        Else
            headdept = "'" & Session("_edept") & "'"
        End If
        '  Label1.Text = headdept
        BindGridhod(headdept)
        BindGridopt(headdept)
    End Sub
    Function GetHeadAssignment() As DataSet

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from head_assignment_emanagement where empcode ='" & Session("empcode") & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function
    Private Sub BindGridhod(ByVal dept As String)
        Dim sqltext
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        ' Command = New SqlCommand("SELECT kpi_grade_result.empcode ,  kpi_grade_result.slno , kpi_grade_result.yr , kpi_grade_result.mnth,kpi_grade_result.grade,ltrim(rtrim(kpi_grade_result.total)) as total,kpi_grade_result.status, empmaster.departmentcode, empmaster.sectioncode, empmaster.empname, empmaster.designation, empmaster.resigned, empmaster.IsOperator FROM kpi_grade_result INNER JOIN empmaster ON kpi_grade_result.empcode = empmaster.empcode WHERE (kpi_grade_result.yr = '" & ddlyr.SelectedValue & "') AND (kpi_grade_result.mnth = '" & ddlmon.SelectedValue & "') AND (empmaster.departmentcode in (" & dept & ") ) AND (empmaster.resigned = 'N') AND (empmaster.IsOperator <> 'Y') and status = 'Scheduled'", con)
        sqltext = "SELECT *,dateadd(mm,emp_appraisalnote.probation,dateofjoin) as probationends,datediff(dd,getdate(), dateadd(mm,emp_appraisalnote.probation,dateofjoin)) as diff  from emp_appraisalnote, empmaster wHERE empmaster.empcode = emp_appraisalnote.empcode and empmaster.resigned <> 'Y' and departmentcode in (" & dept & ") and status != 'EA' and nationality <> 'JAP' AND designation <>  'Operator' and appraisaltype ='P' and datediff(dd,getdate(), dateadd(mm,emp_appraisalnote.probation,dateofjoin)) <='60' and empmaster.empcode <> '" & Session("empcode") & "' "

        Command = New SqlCommand(sqltext, con)

        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "appHod")

        GridProbation.DataSource = ds
        GridProbation.DataBind()
        con.Close()
    End Sub
    Private Sub BindGridopt(ByVal dept As String)
        Dim sqltext
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        ' Command = New SqlCommand("SELECT kpi_grade_result.empcode ,  kpi_grade_result.slno , kpi_grade_result.yr , kpi_grade_result.mnth,kpi_grade_result.grade,ltrim(rtrim(kpi_grade_result.total)) as total,kpi_grade_result.status, empmaster.departmentcode, empmaster.sectioncode, empmaster.empname, empmaster.designation, empmaster.resigned, empmaster.IsOperator FROM kpi_grade_result INNER JOIN empmaster ON kpi_grade_result.empcode = empmaster.empcode WHERE (kpi_grade_result.yr = '" & ddlyr.SelectedValue & "') AND (kpi_grade_result.mnth = '" & ddlmon.SelectedValue & "') AND (empmaster.departmentcode in (" & dept & ") ) AND (empmaster.resigned = 'N') AND (empmaster.IsOperator <> 'Y') and status = 'Scheduled'", con)
        sqltext = "SELECT *,dateadd(mm,probation,dateofjoin) as probationends ,datediff(dd,getdate(), dateadd(mm,probation,dateofjoin)) as diff  from emp_appraisalnote ,empmaster WHERE empmaster.empcode = emp_appraisalnote.empcode and empmaster.resigned <> 'Y' and departmentcode in (" & dept & ") and status != 'EA' and nationality <> 'JAP' AND  designation =  'Operator' and appraisaltype ='P' and datediff(dd,getdate(), dateadd(mm,probation,dateofjoin)) <='60'"

        Command = New SqlCommand(sqltext, con)

        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "appHod")

        GridView1.DataSource = ds
        GridView1.DataBind()
        con.Close()
    End Sub


    Private Sub GridProbation_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridProbation.PageIndexChanging
        GetHeadDept()

        GridProbation.PageIndex = e.NewPageIndex
        GridProbation.DataBind()
        GridProbation.Visible = True

    End Sub

    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GetHeadDept()

        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
        GridView1.Visible = True

    End Sub

End Class