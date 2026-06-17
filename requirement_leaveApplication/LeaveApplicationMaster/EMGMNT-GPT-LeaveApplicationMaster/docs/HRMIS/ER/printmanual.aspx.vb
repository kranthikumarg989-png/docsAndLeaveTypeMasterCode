Imports System.io
Imports System.IO.FileInfo
Partial Public Class printmanual
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If IsPostBack = False Then
        Dim str As String
        HtmlEditor1.EditorBorderSize = 0
        str = Session("ht")
        HtmlEditor1.Text = str
        HtmlEditor1.Enabled = False
        HtmlEditor1.DesignModeEditable = False
        'Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Print", "javascript:window.print();", True)
        'Session("ht") = ""
        'End If
    End Sub
    'Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
    '    Dim objSW As StreamWriter
    '    Dim objFS As FileStream
    '    Dim fn, fn1 As String
    '    fn1 = Session("ddlname")
    '    fn1 = fn1 + ".html"
    '    fn = "C:\" & fn1
    '    objFS = New FileStream(fn, FileMode.Create)
    '    objSW = New StreamWriter(objFS)
    '    objSW.Write(HtmlEditor1.Text)
    '    objSW.Close()
    '    objFS.Close()
    '    MessageBox("Letter Saved to" & fn)
    'End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Private Sub printmanual_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = "Do you want to save letter in Your Local Machine(Print Later)?"  'Define message.
        style = MsgBoxStyle.DefaultButton2 Or _
        MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
        title = "MsgBox Demonstration" ' Define title.
        ' Display message.
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then ' User chose Yes.
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
        Else
            ' Perform some other action.
        End If
    End Sub
End Class