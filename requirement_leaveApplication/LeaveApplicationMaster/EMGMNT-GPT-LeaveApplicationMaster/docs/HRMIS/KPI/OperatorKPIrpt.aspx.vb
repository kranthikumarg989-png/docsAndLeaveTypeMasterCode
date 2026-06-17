Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class OperatorKPIrpt
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

        ElseIf rdoptions.SelectedValue = "Sect" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = True
            txtempidr.Enabled = False

        ElseIf rdoptions.SelectedValue = "Emp" Then
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
        Stat = LTrim(RTrim(Session("Otstat")))
        Session("kpiemp") = Trim(txtempidr.Text)
        Session("kpisect") = Trim(ddlsectrpt.SelectedValue)
        Session("kpidept") = ddldeptr.SelectedValue.Trim
        Session("kpiyear") = kpiyear.SelectedValue.Trim
        Session("kpioption") = Qoption.SelectedValue.Trim
        Session("kpiemptype") = emptype.SelectedValue.Trim

        If Qoption.SelectedValue = "1stHalf" Then

            If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
                Session("otstat") = "D"
            ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
                Session("otstat") = "S"
            ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
                Session("otstat") = "E"
            ElseIf rdvalue = "O" Then
                Session("otstat") = "O"
            ElseIf rdvalue = "ONS" Then
                Session("otstat") = "ONS"
            End If

            Response.Redirect("KPIreportsbyselection1.aspx")


        ElseIf Qoption.SelectedValue = "2ndHalf" Then

            If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
                Session("otstat") = "D"
            ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
                Session("otstat") = "S"
            ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
                Session("otstat") = "E"
            ElseIf rdvalue = "O" Then
                Session("otstat") = "O"
            ElseIf rdvalue = "ONS" Then
                Session("otstat") = "ONS"
            End If

            Response.Redirect("KPIreportsbyselection.aspx")
        End If

    End Sub
End Class