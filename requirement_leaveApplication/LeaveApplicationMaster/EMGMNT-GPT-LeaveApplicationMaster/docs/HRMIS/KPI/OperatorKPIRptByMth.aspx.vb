Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class OperatorKPIRptByMth
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
      
        ' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (83)
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
        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = False
            txtempidr.Enabled = False

        ElseIf rdoptions.SelectedValue = "sect" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = True
            txtempidr.Enabled = False

        ElseIf rdoptions.SelectedValue = "emp" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            txtempidr.Enabled = True
        Else
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            txtempidr.Enabled = False
        End If
    End Sub
    Protected Sub showrepKPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showrepKPI.Click
        Dim rdvalue As String
        Dim Stat As String
        rdvalue = rdoptions.SelectedValue

        If rdvalue = "Dept" Then
            If (ddldeptr.SelectedValue = "-1" And emptype.SelectedValue = "-1") Then
                lblmsg.Text = "pls select department"
                Exit Sub
            End If
        ElseIf rdvalue = "sect" Then
            If (ddlsectrpt.SelectedValue = "-1" And emptype.SelectedValue = "-1") Then
                lblmsg.Text = "pls select section"
                Exit Sub
            End If
        ElseIf rdvalue = "emp" Then
            If txtempidr.Text = "" Then
                lblmsg.Text = "Keyin empcode"
                Exit Sub
            End If
        End If
        Session("Stat") = rdvalue
        Session("kpiemp1") = Trim(txtempidr.Text)
        Session("kpisect1") = Trim(ddlsectrpt.SelectedValue)
        Session("kpidept1") = ddldeptr.SelectedValue.Trim
        Session("kpiyear1") = kpiyear.SelectedValue.Trim
        Session("kpioption1") = Qoption.SelectedValue.Trim
        Session("kpiemptype1") = emptype.SelectedValue.Trim


        Response.Redirect("optkpirptbymonview.aspx")

    End Sub
End Class
