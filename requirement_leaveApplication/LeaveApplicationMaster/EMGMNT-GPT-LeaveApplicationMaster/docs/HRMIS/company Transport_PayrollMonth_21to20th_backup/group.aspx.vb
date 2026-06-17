Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class group
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (92)
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
        _eid = Session("empcode")
        Label1.Text = ""
    End Sub

    Protected Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        GetGroupCode()
        ' Label1.Text = posid
        Inserttgroup(posid, TextBox1.Text.Trim, TextBox2.Text.Trim, _eid)
        If recstatus = True Then
            Label1.Text = "Group Saved successfully"
            TextBox1.Text = ""
            TextBox2.Text = ""
        Else
            Label1.Text = MyerrorMsg & "Error!!! Cannot save Data"
        End If
        GridView1.DataBind()
    End Sub
End Class