Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class TransportrouteRpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Dim rdvalue, rd2val, rd3val, rd4val As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (113)
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
        MyApp.GetfiscalYear()
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        rdvalue = RadioButtonList1.SelectedValue.Trim
        rd2val = RadioButtonList2.SelectedValue.Trim
        rd3val = RadioButtonList3.SelectedValue.Trim

        Session("tptvalue") = rdvalue
        Session("rd2sval") = rd2val
        Session("rd3sval") = rd3val


        If rdvalue = "RA" Or rdvalue = "ER" Then
            Session("route") = ddlroute.SelectedValue.Trim
        ElseIf rdvalue = "ERA" Then
            Session("route") = ddlroute.SelectedValue.Trim
            Session("area") = DropDownList1.SelectedValue.Trim
        End If

        If rd3val = "E" Then
            Session("emp") = txtemp.Text.Trim
        ElseIf rd3val = "D" Then
            Session("vehidept") = ddldept.SelectedValue.Trim
        ElseIf rd3val = "S" Then
            Session("vehisect") = ddlsect.SelectedValue.Trim
        End If

        Response.Redirect("transportreport.aspx")

    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        RadioButtonList2.SelectedValue = "None"
        RadioButtonList3.SelectedValue = "None"

        rdvalue = RadioButtonList1.SelectedValue.Trim

        If rdvalue = "R" Then
            ddlroute.Visible = False
            DropDownList1.Visible = False
            Label1.Visible = False
            Label2.Visible = False
        ElseIf rdvalue = "RA" Then
            ddlroute.Visible = True
            DropDownList1.Visible = False
            Label1.Visible = False
            Label2.Visible = True
        ElseIf rdvalue = "ER" Then
            ddlroute.Visible = True
            DropDownList1.Visible = False
            Label1.Visible = False
            Label2.Visible = True
        ElseIf rdvalue = "ERA" Then
            ddlroute.Visible = True
            DropDownList1.Visible = True
            Label1.Visible = True
            Label2.Visible = True

        End If
    End Sub

    Protected Sub RadioButtonList2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonList2.SelectedIndexChanged
        RadioButtonList1.SelectedValue = "None"
        RadioButtonList3.SelectedValue = "None"
    End Sub

    Protected Sub RadioButtonList3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonList3.SelectedIndexChanged
        RadioButtonList1.SelectedValue = "None"
        RadioButtonList2.SelectedValue = "None"

        rd3val = RadioButtonList3.SelectedValue.Trim

        If rd3val = "E" Then
            txtemp.Visible = True
            lblemp.Visible = True
            ddldept.Visible = False
            lbldept.Visible = False
            ddlsect.Visible = False
            lblsect.Visible = False

        ElseIf rd3val = "D" Then
            ddldept.Visible = True
            lbldept.Visible = True
            txtemp.Visible = False
            lblemp.Visible = False
            ddlsect.Visible = False
            lblsect.Visible = False

        ElseIf rd3val = "S" Then
            ddlsect.Visible = True
            lblsect.Visible = True
            txtemp.Visible = False
            lblemp.Visible = False
            ddldept.Visible = False
            lbldept.Visible = False
        Else
            txtemp.Visible = False
            lblemp.Visible = False
            ddldept.Visible = False
            lbldept.Visible = False
            ddlsect.Visible = False
            lblsect.Visible = False
        End If
    End Sub
End Class