Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ER_letter_CreatePage
    Inherits System.Web.UI.Page
    Dim myglobal As New Emanagement.globalinfo
    Dim myapp As New Emanagement.EMSapplications
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myglobal.Open_Con()
        myglobal.Con_Str()
        Label1.Text = Session("lab1")
        Label3.Text = Session("tb1")
        'MsgBox(Label1.Text)
        con = New SqlConnection(constr)
        con.Open()
        cmd = New SqlCommand("select field_name from HRMIS_ER_LETTER_WIZARD where lettername='" & (Label3.Text) & "' ", con)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            If IsPostBack = False Then
                DropDownList1.Items.Add(dr(0).ToString())
            End If
        End While
        cmd.Dispose()
        'End If
        'End If
    End Sub
    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim it As String
        Dim dt
        it = "IT"
        dt = DateTime.Now
        SqlDataSource1.InsertParameters.Add("lettercontents", Me.HtmlEditor1.Text)
        SqlDataSource1.InsertParameters.Add("lettername", Me.Label3.Text)
        SqlDataSource1.InsertParameters.Add("createdby", it)
        SqlDataSource1.InsertParameters.Add("createdtime", dt)
        SqlDataSource1.Insert()
        MessageBox(Label3.Text & " saved")
        Response.Redirect("ERletterstatus.aspx")
        'Response.Redirect("ER_letter_IssuePage.aspx")
        Session("lab1") = ""
        Session("tb1") = ""
    End Sub
    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        HtmlEditor1.Text = HtmlEditor1.Text & DropDownList1.SelectedItem.Text
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class