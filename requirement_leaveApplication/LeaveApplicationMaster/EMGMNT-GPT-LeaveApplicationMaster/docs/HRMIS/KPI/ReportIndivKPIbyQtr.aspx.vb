Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class ReportIndivKPIbyQtr
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rno
    Dim mon
    Dim yr
    Dim i, j, k, l
    Dim ecode
    Dim qtr
    Private Sub IndividualSetting_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        getDetails()
    End Sub
    Protected Sub getDetails()
        ecode = Session("emp")
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
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
                Exit Sub
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"
        ecode = Session("emp")
        qtr = Session("qtr")
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

        'yr = Date.Now.Year
        MyApp.GetfiscalYear()

        yr = _fisyrStart.Year
        lblyr.Text = yr
        mon = Date.Now.Month

        lblyr.Text = yr
        lblmon.Text = mon
        If Not IsPostBack Then

            If qtr = "Q1" Then
                q1.Text = "true"
                Q2.Text = "false"
                q3.Text = "false"
                q4.Text = "false"
            ElseIf qtr = "Q2" Then
                q1.Text = "false"
                Q2.Text = "true"
                q3.Text = "false"
                q4.Text = "false"
            ElseIf qtr = "Q3" Then
                q1.Text = "false"
                Q2.Text = "false"
                q3.Text = "true"
                q4.Text = "false"
            ElseIf qtr = "Q4" Then
                q1.Text = "false"
                Q2.Text = "false"
                q3.Text = "false"
                q4.Text = "true"
            End If
        End If

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
            LoadGrid()
        End If

    End Sub
    Private Sub LoadGrid()
        getDetails1()
    End Sub
    Protected Sub getDetails1()
        'MsgBox(Session("emp"))
        'MsgBox(Session("qtr"))
        'MsgBox(Session("yr"))

        ecode = Session("emp")
        yr = Session("yr")
        Getkpidetails(ecode, yr)
        If recstatus = True Then
            Dim dr1 As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                Dim i
                For i = 0 To dsdata.Tables(0).Rows.Count - 1
                    dr1 = dsdata.Tables(0).Rows(i)
                    Dim basis = dr1("updbasis").ToString
                    If basis = "D" Then
                        grddaily.Visible = True
                    ElseIf basis = "W" Then
                        grdweekly.Visible = True
                    ElseIf basis = "M" Then
                        grdmonthly.Visible = True
                    End If
                Next
                grddaily.DataBind()
                grdweekly.DataBind()
                grdmonthly.DataBind()
            Else
                MessageBox("No settings available for the employee!!")
                Exit Sub
            End If

        End If
    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Function GetRevno() As DataSet
        yr = lblyr.Text
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select max(revision) as revi from KPI_IndividualSetting where employee_code='" & ecode & "' and quarter='" & qtr & "' and kpi_year='" & yr & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function

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
End Class