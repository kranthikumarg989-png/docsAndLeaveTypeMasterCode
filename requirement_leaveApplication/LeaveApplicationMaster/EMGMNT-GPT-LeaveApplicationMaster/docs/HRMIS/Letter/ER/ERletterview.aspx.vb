Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ERletterview
    Inherits System.Web.UI.Page
    Dim myglobal As New Emanagement.globalinfo
    Dim myapp As New Emanagement.EMSapplications
    Dim str As String
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Dim strcontent As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        myglobal.Open_Con()
        myglobal.Con_Str()
        HtmlEditor1.Enabled = False
        HtmlEditor1.DesignModeEditable = False
        Dim lnames
        lnames = Request.QueryString("letternam").ToString()
        'lnames = Session("Lettername")
        con = New SqlConnection(constr)
        con.Open()
        str = "select lettercontents from HRMIS_ER_MASTER_LETTER where lettername='" & lnames & "' "
        cmd = New SqlCommand(str, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            strcontent = (rdr(0)).ToString
        End While
        rdr.Close()
        con.Close()
        HtmlEditor1.Text = strcontent
    End Sub
End Class