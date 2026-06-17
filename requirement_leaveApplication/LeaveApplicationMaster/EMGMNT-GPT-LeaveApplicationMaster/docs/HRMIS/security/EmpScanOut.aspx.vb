Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class EmpScanOut
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        If Len(Trim(textbox1.Text)) <> 0 Then
            'SqlDataSource1.SelectParameters.Add("empcode", textbox1.Text)
            'SqlDataSource1.DataBind()
            GridView1.DataBind()
        End If
    End Sub

End Class