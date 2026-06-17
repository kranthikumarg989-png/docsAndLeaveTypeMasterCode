Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO.Path
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class CVview
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim btno As String
    Dim rptname


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empcode") = "" Then
            Response.Redirect("~\logout.aspx")
        End If
        If Request.QueryString("btno") <> "" Then
            btno = Request.QueryString("btno")
            GetBtInfo(btno)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    rptname = dr("rptname").ToString
                    LinkButton1.Text = rptname
                End If
            Else
                lblmsg.Text = myerrormsg
                lblmsg.ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click

    End Sub
End Class