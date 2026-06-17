Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class UpdatedKPIindividual
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rno
    Dim mon
    Dim yr
    Dim i, j, k, l
    Dim ecode
    Dim mth

    Private Sub IndividualSetting_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Session("emp") = "014543"
        'Session("mth") = "8"
        'Session("yr") = "2011"
        getDetails()
    End Sub
    Protected Sub getDetails()
        ecode = Session("emp")
        mth = Session("mth")
        GetEmpVehino(ecode)
        If recstatus = True Then
            Dim dr1 As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                lblename.Text = dr1("empname").ToString
                lblsect.Text = dr1("sectioncode").ToString + "-" + dr1("sectionname").ToString
                lbldept.Text = dr1("departmentcode").ToString + "-" + dr1("departmentname").ToString
                lbldesig.Text = dr1("designation").ToString
                lblempcode.Text = ecode
                lblmonth.Text = mth
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
                Exit Sub
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"01454
        ecode = Session("emp")
        mth = Session("mth")
        yr = Session("yr")
        lblyr.Text = yr
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (76)
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

        lblmon.Text = mth

        'MsgBox(lblmon.Text)
        'MsgBox(lblyr.Text)
        'MsgBox(lblempcode.Text)

        If Not IsPostBack Then

            Dim dsrev As DataSet
            Dim drrev As DataRow

            dsrev = GetRevno()

            If dsrev.Tables(0).Rows.Count > 0 Then
                drrev = dsrev.Tables(0).Rows(0)
                If Not drrev("revi") Is System.DBNull.Value Then
                    lblrev.Text = drrev("revi").ToString
                    lblrev1.Text = drrev("revi").ToString

                Else
                    lblrev.Text = "-1"
                    lblrev1.Text = "0"

                End If
            End If
            If lblrev.Text = "-1" Then

            End If

            Dim ds As DataSet
            Dim dr As DataRow
            Dim status

            GettotGrade()
            ds = GettotGrade()

            If ds.Tables(0).Rows.Count > 0 Then
                dr = ds.Tables(0).Rows(0)
                If Not dr("total").ToString Is System.DBNull.Value Then
                    LBLTOT.Text = dr("total").ToString
                Else
                    LBLTOT.Text = 0
                End If
                If Not dr("grade").ToString Is System.DBNull.Value Then
                    LBLGRADE.Text = dr("grade").ToString
                Else
                    LBLGRADE.Text = 0
                End If
              
            End If

            GridView1.DataBind()
            GridView2.DataBind()
            GridView3.DataBind()

            GridView1.Visible = True
            GridView2.Visible = True
            GridView3.Visible = True



        End If

    End Sub
    Function GettotGrade() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT * FROM kpi_grade_result WHERE empcode = '" & Session("emp") & "' and yr = '" & lblyr.Text & "' and  mnth = '" & Session("mth") & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIlvl")
        con.Close()
        Return ds
    End Function
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Function Getdlevel() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select dlevel from designation where designationname=(select designation from empmaster where empcode='" & ecode & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIlvl")
        con.Close()
        Return ds
    End Function
   
    Function GetRevno() As DataSet
        yr = lblyr.Text
        ' yr = Date.Now.Year
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select max(revision) as revi from KPI_IndividualSetting where employee_code='" & ecode & "' and quarter='" & Session("rqr") & "' and kpi_year='" & yr & "' and checked='-1'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function
End Class