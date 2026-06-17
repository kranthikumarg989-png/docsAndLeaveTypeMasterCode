Imports System.io
Imports System.IO.FileInfo
Partial Public Class printmanual
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsPostBack = False Then
        Dim str As String
        str = Session("ht")
        HtmlEditor1.Text = str
        HtmlEditor1.Enabled = False
        HtmlEditor1.DesignModeEditable = False
        'Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Print", "javascript:window.print();", True)
        'Session("ht") = ""
        'End If
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        Dim objSW As StreamWriter
        Dim objFS As FileStream
        Dim fn, fn1 As String
        fn1 = Session("ddlname")
        fn1 = fn1 + ".html"
        fn = "C:\" & fn1
        objFS = New FileStream(fn, FileMode.Create)
        objSW = New StreamWriter(objFS)
        objSW.Write(HtmlEditor1.Text)
        objSW.Close()
        objFS.Close()
        MessageBox("Letter Saved to" & fn)
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class