Imports System.Data
Imports System
Imports System.io
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class CMG_LetterModify
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim da As SqlDataAdapter
    Dim rdr, rdr1 As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
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
        Label3.Text = n

        rdr.Close()
        con.Close()

        Dim strcontent As String
        Dim oldvalue, newvalue

        Dim dr As SqlDataReader
        Dim da As SqlDataAdapter

        con.Open()
        Cmd = New SqlCommand("hrmis_CMG_GetLetterRevNo_preview", con)
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@ln", DropDownList1.SelectedValue)
        DR = Cmd.ExecuteReader()
        While (DR.Read())
            strcontent = DR("letterlink").ToString()
            Dim fn As String
            fn = "F:\E-Management\CMGLetter\" & strcontent
            Dim filePath As String = fn
            Dim objStreamReader As StreamReader
            objStreamReader = File.OpenText(filePath)
            Dim contents As String = objStreamReader.ReadToEnd()
            HtmlEditor1.Text = contents
        End While

        con.Close()
        Cmd.Dispose()
      
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        LoadEditor()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim fn, fn1 As String

        fn1 = DropDownList1.SelectedItem.Text & "REV" & Me.Label3.Text
        fn1 = fn1 + ".html"

        fn = "F:\E-Management\CMGLetter\" & fn1

        SqlDataSource2.UpdateParameters.Add("lettername", DropDownList1.SelectedItem.Text)
        SqlDataSource2.UpdateParameters.Add("createdby", Session("empcode"))
        SqlDataSource2.UpdateParameters.Add("time", DateTime.Now)
        SqlDataSource2.UpdateParameters.Add("letterlink", fn1)
        SqlDataSource2.UpdateParameters.Add("rev", Me.Label3.Text)
        SqlDataSource2.UpdateParameters.Add("status", "ES")

        SqlDataSource2.Update()

        Dim objSW As StreamWriter
        Dim objFS As FileStream


        objFS = New FileStream(fn, FileMode.Create)
        objSW = New StreamWriter(objFS)

        objSW.Write(HtmlEditor1.Text)

        MessageBox("Letter Updated Successfully")
        HtmlEditor1.Text = ""
        DropDownList1.SelectedValue = "-1"
        Label3.Text = ""

        objSW.Close()
        objFS.Close()
    End Sub
End Class