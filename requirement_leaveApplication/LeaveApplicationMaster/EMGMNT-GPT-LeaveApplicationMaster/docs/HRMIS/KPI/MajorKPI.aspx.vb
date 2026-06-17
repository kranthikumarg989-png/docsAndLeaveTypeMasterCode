Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class MajorKPI
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rno
    Dim upd

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
       

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (74)
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

    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        Dim rd = rdoptions.SelectedValue.Trim
        txtmajorKPI.Text = ""
        KPIpercent.Text = ""
        ddldept.SelectedValue = "-1"

        If rd = "yes" Then
            lbl2.Visible = True
            txtmajorKPI.Visible = True
            lbl3.Visible = True
            lbl1.Visible = False
            ddldept.Visible = False
            '    KPIpercent.Visible = True
            lbldept.Text = Session("_edept")
            lbl3.Visible = True
            Rbupdate.Visible = True

        ElseIf rd = "no" Then
            lbl2.Visible = True
            txtmajorKPI.Visible = True
            lbl3.Visible = False
            lbl1.Visible = True
            ddldept.Visible = True
            ' KPIpercent.Visible = False
            lbldept.Text = ddldept.SelectedValue
            lbl3.Visible = False
            Rbupdate.Visible = False
        End If
        lblmsg.Text = ""

    End Sub

    Protected Sub ddldept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddldept.SelectedIndexChanged
        lbldept.Text = ddldept.SelectedValue
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim rd = rdoptions.SelectedValue.Trim
        'Dim yr = Date.Now.Year
        Dim weit
        weit = KPIpercent.Text
        If txtmajorKPI.Text = "" Then
            lblmsg.Text = "Key in Major KPI"
            Exit Sub
        End If
        If rd = "yes" And KPIpercent.Text = "" Then
            lblmsg.Text = "Key in Percentage"
            Exit Sub
        End If

        If rd = "no" And ddldept.SelectedValue = "-1" Then
            lblmsg.Text = "select Department"
            Exit Sub
        End If

        If rd = "yes" And Rbupdate.SelectedValue = "-1" Then
            lblmsg.Text = "Select Update by Option"
            Exit Sub
        End If

        'If weit > "100" Or weit < "0" Then
        '    lblmsg.Text = "Your Weightage should not exceed 100"
        '    Exit Sub
        'End If

        If rd = "yes" Then
            weit = KPIpercent.Text
            upd = Rbupdate.SelectedValue.Trim
        ElseIf rd = "no" Then
            weit = "0"
            upd = "-"
        End If

        rno = lblrno.Text

        Dim mon = Date.Now.Month
       
        Dim yr
        MyApp.GetfiscalYear()
        yr = _fisyrStart.Year

        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            Call MyGlobal.dbSp_open("hrmis_kpi_majorkpi_new")
            Cmd.Parameters.AddWithValue("@Major_kpidetails", txtmajorKPI.Text.Trim)
            Cmd.Parameters.AddWithValue("@Individual", rd)
            Cmd.Parameters.AddWithValue("@Employee_Code", Session("empcode"))
            Cmd.Parameters.AddWithValue("@Weightage", weit)
            Cmd.Parameters.AddWithValue("@Department_Code", lbldept.Text)
            Cmd.Parameters.AddWithValue("@KPI_Year", yr)
            Cmd.Parameters.AddWithValue("@mjrnumber", rno)
            Cmd.Parameters.AddWithValue("@upd", upd)
            Cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox(ex.Message)
            Exit Sub
        End Try
        txtmajorKPI.Text = ""
        KPIpercent.Text = ""
        lblrno.Text = ""

        GridView1.DataBind()

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Public Sub EditKPI(ByVal sender As Object, ByVal e As CommandEventArgs)
        rno = e.CommandArgument
        lblrno.Text = e.CommandArgument
        Dim rd
        Dim dsKPI As DataSet

        Try
            dsKPI = GetKPIRec(rno)
            Dim dr As DataRow
            If dsKPI.Tables(0).Rows.Count > 0 Then
                dr = dsKPI.Tables(0).Rows(0)
                rdoptions.SelectedValue = dr("opn").ToString
                If dr("opn") = "yes" Then
                    lbl3.Visible = True
                    lbl1.Visible = False
                    ddldept.Visible = False
                    KPIpercent.Visible = True
                    Label3.Visible = True
                    Rbupdate.Visible = True
                    KPIpercent.Text = dr("weightage").ToString
                    Rbupdate.SelectedValue = dr("updbasis").ToString
                ElseIf dr("opn") = "no" Then
                    lbl3.Visible = False
                    lbl1.Visible = True
                    ddldept.Visible = True
                    Label3.Visible = False
                    Rbupdate.Visible = False
                    KPIpercent.Visible = False
                    ddldept.SelectedValue = dr("department_code").ToString
                End If
                lbldept.Text = dr("department_code").ToString
                txtmajorKPI.Text = dr("Major_kpidetails").ToString
            End If

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
    End Sub
    Function GetKPIRec(ByVal rno As Integer) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select *,Ltrim(rtrim(individual)) as opn from dbo.KPI_MajorSetting where major_kpino= '" & rno & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function
End Class