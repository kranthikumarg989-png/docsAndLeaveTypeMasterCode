Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class CategoryMaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim code As Integer
        Gettrcatcode()
        code = posid
        lbl.Text = posid
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        _eid = Session("empcode")
        Label1.Text = ""
        lbl.Text = posid

    End Sub
    Protected Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            Dim code As Integer
            MyGlobal.Con_Str()
            Dim con As New SqlConnection(constr)
            con.Open()
            Cmd = New SqlCommand("insert into td_categorymaster (categorycode,description) values('" & lbl.Text & "', '" & description.Text & "' ) ", con)
            Cmd.ExecuteNonQuery()
            Label1.Text = "Training Category Code Saved successfully"
            Gettrcatcode()
            code = posid
            description.Text = ""

        Catch ex As Exception
            messagebox(ex.Message)
            Label1.Text = ex.Message
        End Try
        GridView1.DataBind()

    End Sub

  
End Class