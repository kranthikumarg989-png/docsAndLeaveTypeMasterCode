Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ReportHODKPI
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' _eid = "014543"
        ' _ename = "Sathya Vamshi Anigalla"
        ' _edept = "9000"
        ' Session("_edept") = "9000"

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
    End Sub
    Protected Sub hodbtnrpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hodbtnrpt.Click

        '''' Delete from Temp table before entering new record
        MyGlobal.Con_Str()

        Dim con As New SqlConnection(constr)
        con.Open()
        Cmd = New SqlCommand("delete from kpi_tempreport_hod", con)
        Cmd.ExecuteNonQuery()


        Dim sqltext
        Session("kpiRptbyh") = hodrdorpt.SelectedValue.Trim
        Session("kpiemph") = hodtxtemp.Text.Trim
        Session("kpisecth") = hodddlsect.SelectedValue.Trim
        Session("kpidepth") = Session("_edept")
        Session("kpiopnh") = RadioButtonList1.SelectedValue.Trim
        Session("kpiyrh") = ddlyr.SelectedValue.Trim
        Session("kpimonh") = ddlmon.SelectedValue.Trim

        Dim rdvalue As String = Session("kpiRptbyh")
        Dim empid As String = Session("kpiemph")
        Dim status As String = Session("kpiopnh")




        If Session("kpiopnh") = "qr" Then
            If rdvalue = "Sect" And hodddlsect.SelectedValue <> "" Then
                Session("kpiRptbyh") = "S"
                sqltext = "select *,sectioncode from kpi_individualsetting,empmaster where kpi_individualsetting.employee_code = empmaster.empcode and quarter = '" & ddlmon.SelectedValue.Trim & "' and kpi_year = '" & ddlyr.SelectedValue.Trim & "' and empmaster.sectioncode ='" & hodddlsect.SelectedValue & "'"
            ElseIf rdvalue = "Emp" And empid <> "" Then
                CheckEmpDetails(_edept, empid)
                If dsdata1.Tables(0).Rows.Count <> 0 Then
                    If recstatus = "true" Then
                        Session("kpiRptbyh") = "E"
                    Else
                        MessageBox("Employee Does not belongs to your department")
                    End If
                Else
                    MessageBox("Employee Does not belongs to your department")
                End If
                sqltext = "select *,empcode from kpi_individualsetting,empmaster where kpi_individualsetting.employee_code = empmaster.empcode and quarter = '" & ddlmon.SelectedValue.Trim & "' and kpi_year = '" & ddlyr.SelectedValue.Trim & "' and empmaster.empcode ='" & empid & "'"
            Else
                Session("kpiRptbyh") = "O"
                sqltext = "select *,departmentcode from kpi_individualsetting,empmaster where kpi_individualsetting.employee_code = empmaster.empcode and quarter = '" & ddlmon.SelectedValue.Trim & "' and kpi_year = '" & ddlyr.SelectedValue.Trim & "' and empmaster.departmentcode ='" & Session("_edept") & "'"
            End If
            Response.Redirect("RptKPIhod.aspx")
            Dim ds1 As DataSet
            Dim dr, dr1 As DataRow
            Dim i
            Dim emp
            DS = GetEmpList(sqltext)
            If DS.Tables(0).Rows.Count <> 0 Then
                For i = 0 To DS.Tables(0).Rows.Count - 1
                    dr = DS.Tables(0).Rows(i)
                    emp = dr("empcode").ToString
                    ds1 = chkRevno(emp)
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        dr1 = ds1.Tables(0).Rows(0)
                        Try
                            MyGlobal.Open_Con()
                            MyGlobal.Con_Str()
                            Call MyGlobal.dbSp_open("hrmis_kpi_tempreport_hod")
                            Cmd.Parameters.AddWithValue("@empcode", emp)
                            Cmd.Parameters.AddWithValue("@rev", dr1("revi").ToString)
                            Cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MessageBox(ex.Message)
                            Exit Sub
                        End Try
                    End If
                Next
            End If
        ElseIf Session("kpiopnh") = "yr" Then
            If rdvalue = "Sect" And hodddlsect.SelectedValue <> "" Then
                Session("kpiRptbyh") = "S"
                sqltext = "select *,sectioncode from kpi_individualsetting,empmaster where kpi_individualsetting.employee_code = empmaster.empcode and quarter = '" & ddlmon.SelectedValue.Trim & "' and kpi_year = '" & ddlyr.SelectedValue.Trim & "' and empmaster.sectioncode ='" & hodddlsect.SelectedValue & "'"
            ElseIf rdvalue = "Emp" And empid <> "" Then
                CheckEmpDetails(_edept, empid)
                If dsdata1.Tables(0).Rows.Count <> 0 Then
                    If recstatus = "true" Then
                        Session("kpiRptbyh") = "E"
                    Else
                        MessageBox("Employee Does not belongs to your department")
                    End If
                Else
                    MessageBox("Employee Does not belongs to your department")
                End If
                sqltext = "select *,empcode from kpi_individualsetting,empmaster where kpi_individualsetting.employee_code = empmaster.empcode and quarter = '" & ddlmon.SelectedValue.Trim & "' and kpi_year = '" & ddlyr.SelectedValue.Trim & "' and empmaster.empcode ='" & empid & "'"
            Else
                Session("kpiRptbyh") = "O"
                sqltext = "select *,departmentcode from kpi_individualsetting,empmaster where kpi_individualsetting.employee_code = empmaster.empcode and quarter = '" & ddlmon.SelectedValue.Trim & "' and kpi_year = '" & ddlyr.SelectedValue.Trim & "' and empmaster.departmentcode ='" & Session("_edept") & "'"
            End If
            Response.Redirect("RptKPIhod.aspx")
            Dim ds1 As DataSet
            Dim dr, dr1 As DataRow
            Dim i
            Dim emp
            DS = GetEmpList(sqltext)
            If DS.Tables(0).Rows.Count <> 0 Then
                For i = 0 To DS.Tables(0).Rows.Count - 1
                    dr = DS.Tables(0).Rows(i)
                    emp = dr("empcode").ToString
                    ds1 = chkRevno(emp)
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        dr1 = ds1.Tables(0).Rows(0)
                        Try
                            MyGlobal.Open_Con()
                            MyGlobal.Con_Str()
                            Call MyGlobal.dbSp_open("hrmis_kpi_tempreport_hod")
                            Cmd.Parameters.AddWithValue("@empcode", emp)
                            Cmd.Parameters.AddWithValue("@rev", dr1("revi").ToString)
                            Cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MessageBox(ex.Message)
                            Exit Sub
                        End Try
                    End If
                Next
            End If
            Response.Redirect("RptKPIhodall.aspx")
        End If

    End Sub
    Function GetEmpList(ByVal sqltext As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "emp")
        con.Close()
        Return ds
    End Function
    Function chkRevno(ByVal emp As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select isnull(max(revision),0) as revi from KPI_IndividualSetting where employee_code='" & emp & "' and quarter='" & ddlmon.SelectedValue.Trim & "' and kpi_year='" & ddlyr.SelectedValue.Trim & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "emp")
        con.Close()
        Return ds
    End Function
    Protected Sub hodrdorpt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hodrdorpt.SelectedIndexChanged
        If hodrdorpt.SelectedValue = "Sect" Then
            hodddlsect.Enabled = True
            hodtxtemp.Text = ""
            hodtxtemp.Enabled = False
        ElseIf hodrdorpt.SelectedValue = "Emp" Then
            hodtxtemp.Enabled = True
            hodddlsect.Enabled = False
        Else
            hodtxtemp.Enabled = False
            hodddlsect.Enabled = False
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim opt
        opt = RadioButtonList1.SelectedValue
        If opt = "qr" Then
            ddlmon.Enabled = True
            ddlyr.Enabled = True

        ElseIf opt = "yr" Then
            ddlmon.Enabled = False
            ddlyr.Enabled = True

        End If
    End Sub

End Class