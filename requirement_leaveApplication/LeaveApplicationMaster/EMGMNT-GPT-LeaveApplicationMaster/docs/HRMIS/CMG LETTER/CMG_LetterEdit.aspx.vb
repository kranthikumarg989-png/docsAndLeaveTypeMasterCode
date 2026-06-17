Imports System.Data
Imports System.io
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class CMG_LetterEdit
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim da As SqlDataAdapter
    Dim rdr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
   
        'If DropDownList1.SelectedValue <> "-1" Then
        '    LoadEditor()
        'End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Private Sub LoadEditor()
        Dim strtext, Letterlnk
        strtext = "select * from HRMIS_CMG_MASTER_LETTER where lettername='" & (DropDownList1.SelectedItem.Text) & "'"
        Dim con As New SqlConnection(constr)
        con.Open()
        Cmd = New SqlCommand(strtext, con)
        rdr = Cmd.ExecuteReader
        While rdr.Read
            Label3.Text = rdr("revision").ToString
            Letterlnk = rdr("letterlink").ToString
        End While
        Dim n As Integer
        If Label3.Text <> "" Then
            n = Val(Label3.Text) + 1
        End If
        rdr.Close()
        con.Close()
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        ' LoadEditor()
        MessageBox("hi")
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
       
    End Sub
End Class