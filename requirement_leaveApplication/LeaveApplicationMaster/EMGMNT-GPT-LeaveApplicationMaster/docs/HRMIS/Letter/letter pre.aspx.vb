Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class letter_pre
    Inherits System.Web.UI.Page
    Dim myglobal As New Emanagement.globalinfo
    Dim myapp As New Emanagement.EMSapplications
    Dim constr, str As String
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim strcontent As String
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HtmlEditor1.Enabled = False

        'Dim lnames
        'lnames = Request.QueryString("letternam").ToString()
        'session=("_edept")="9000"
        'myglobal.Open_Con()
        'myglobal.Con_Str()
        'Con.Open()
        'Cmd = New SqlCommand("select lettercontents from HRMIS_ER_MASTER_LETTER where lettername='" & lnames & "'", Con)
        'Cmd.ExecuteReader()
        'While rdr.Read()
        '    strcontent = (rdr(0))
        'End While
        'rdr.Close()
        'Con.Close()
        'myglobal.db_close()
        Dim lnames
        '  lnames = Request.QueryString("letternam").ToString()
        lnames = Session("Lettername")
        constr = "Data Source=NB01\SQLEXPRESS;Initial Catalog=hrmis;Integrated Security=True"
        Con = New SqlConnection(constr)
        Con.Open()
        str = "select lettercontents from HRMIS_ER_MASTER_LETTER where lettername='" & lnames & "'"
        Cmd = New SqlCommand(Str, Con)
        rdr = Cmd.ExecuteReader
        While rdr.Read
            strcontent = (rdr(0)).ToString
        End While
        rdr.Close()
        Con.Close()
        HtmlEditor1.Text = strcontent
        messagebox("ok")
    End Sub
End Class