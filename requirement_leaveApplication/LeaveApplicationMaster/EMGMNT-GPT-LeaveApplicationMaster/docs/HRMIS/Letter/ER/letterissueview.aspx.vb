Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class letterissueview
    Inherits System.Web.UI.Page
    Dim myglobal As New Emanagement.globalinfo
    Dim myapp As New Emanagement.EMSapplications
    Dim str As String
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim strcontent As String
    Dim lnames
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HtmlEditor1.Enabled = False
        HtmlEditor1.DesignModeEditable = False
        myglobal.Open_Con()
        myglobal.Con_Str()
        If IsPostBack = False Then
            If Session("letterprint") = "print" Then
                'labpnt.Text = lnames.ToString
                con = New SqlConnection(constr)
                con.Open()
                lnames = Session("Lettername")
                str = "select lettercontents from HRMIS_ER_MASTER_LETTER_SAVE where sno='" & lnames & "' "
                cmd = New SqlCommand(str, con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    strcontent = (rdr(0)).ToString
                End While
                rdr.Close()
                con.Close()
                HtmlEditor1.Text = strcontent
                'Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Print", "javascript:window.print();", True)
            ElseIf Session("letterprint") = "show" Then
                HtmlEditor1.Enabled = False
                HtmlEditor1.DesignModeEditable = False

                'lnames = Request.QueryString("letternam").ToString()
                lnames = Session("Lettername")
                'MsgBox(lnames)
                'constr = "Data Source=NB01\SQLEXPRESS;Initial Catalog=hrmis;Integrated Security=True"
                con = New SqlConnection(constr)
                con.Open()
                str = "select lettercontents from HRMIS_ER_MASTER_LETTER_SAVE where sno='" & lnames & "' "
                cmd = New SqlCommand(str, con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    strcontent = (rdr(0)).ToString
                End While
                rdr.Close()
                con.Close()
                HtmlEditor1.Text = strcontent
            End If
        End If
    End Sub
    'Private Sub letterissueview_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
    '    Dim pausetime As Integer
    '    pausetime = 5000
    '    System.Threading.Thread.Sleep(pausetime)
    '    Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Print", "javascript:window.print();", True)
    'End Sub
End Class