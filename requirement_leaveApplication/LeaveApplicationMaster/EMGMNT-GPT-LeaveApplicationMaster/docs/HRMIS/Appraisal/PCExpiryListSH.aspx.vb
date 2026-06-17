Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class PCExpiryListSH
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode
    Dim thisdate As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        ' Session("empcode") = "014543"
        ' Session("sect") = "9000"
        thisdate = Date.Now
    End Sub


    Public Sub Printappraisal(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim empcode
        empcode = e.CommandArgument
        'Session("leaveeditnum") = appno
        'Response.Redirect("leaveform.aspx")
    End Sub
   
    Protected Sub Appraisal_view(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("optempapp") = e.CommandArgument
        Response.Redirect("Operatorappraisal.aspx")
    End Sub
   
End Class