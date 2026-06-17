Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class letterapprovalpreview
    Inherits System.Web.UI.Page
    Dim myglobal As New Emanagement.globalinfo
    Dim myapp As New Emanagement.EMSapplications
    Dim constr, str As String
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim strcontent As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myglobal.Open_Con()
        myglobal.Con_Str()
        HtmlEditor1.Enabled = False
        HtmlEditor1.DesignModeEditable = False
        Dim sno
        sno = Request.QueryString("slno").ToString()
        'lnames = Session("Lettername")
        'constr = "Data Source=NB01\SQLEXPRESS;Initial Catalog=hrmis;Integrated Security=True"
        con = New SqlConnection(constr)
        con.Open()
        str = "select lettercontents from HRMIS_ER_MASTER_LETTER_SAVE where sno='" & sno & "' "
        cmd = New SqlCommand(str, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            strcontent = (rdr(0)).ToString
        End While
        rdr.Close()
        con.Close()
        HtmlEditor1.Text = strcontent
        If IsPostBack = False Then
            If Session("letterprint") = "ok" Then
                'labpnt.Text = lnames.ToString
                Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Print", "javascript:window.print();", True)
            End If
        End If
    End Sub

End Class