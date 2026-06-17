Imports System.io
Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Public Class WebForm4
    Inherits System.Web.UI.Page

    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("empcode") = "014543"
        '  Label3.Text = "testletter"
        If Not Page.PreviousPage Is Nothing Then
            Dim SourceTextBox1 As TextBox
   
            Dim SourceLabel As Label
            'SourceDropDownListBox = CType(PreviousPage.FindControl("DropDownList1"), DropDownList)
            SourceLabel = CType(PreviousPage.FindControl("Label1"), Label)
            SourceTextBox1 = CType(PreviousPage.FindControl("TextBox1"), TextBox)
         
            If Not SourceTextBox1 Is Nothing Then

                Label1.Text = SourceLabel.Text
                Label3.Text = SourceTextBox1.Text
           
                con = New SqlConnection("Data Source=NB09;Initial Catalog=hrmis;uid = sa;Pwd=;")
                con.Open()
                cmd = New SqlCommand("select field_name from HRMIS_ER_LETTER_WIZARD where lettername='" & (Label3.Text) & "' ", con)
                dr = cmd.ExecuteReader()
                While (dr.Read())
                    DropDownList1.Items.Add(dr(0).ToString())
                End While
                cmd.Dispose()

            End If
        End If

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim fn, fn1 As String

        fn1 = Me.Label3.Text & "REV0"
        fn1 = fn1 + ".html"
        fn = "F:\E-Management\CMGLetter\" & fn1

        SqlDataSource1.InsertParameters.Add("lettername", Me.Label3.Text)
        SqlDataSource1.InsertParameters.Add("createdby", Session("empcode"))
        SqlDataSource1.InsertParameters.Add("time", DateTime.Now)
        SqlDataSource1.InsertParameters.Add("letterlink", fn1)
        SqlDataSource1.Insert()

        Dim objSW As StreamWriter
        Dim objFS As FileStream
    

        objFS = New FileStream(fn, FileMode.Create)
        objSW = New StreamWriter(objFS)

        objSW.Write(HtmlEditor1.Text)

        MessageBox("Letter Created Successfully")
        HtmlEditor1.Text = ""

        objSW.Close()
        objFS.Close()

        ' Server.Transfer("Letterpage.aspx")
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        
    End Sub

   

    
    Protected Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'If Not Page.IsPostBack Then
        '    HtmlEditor1.Text = DropDownList1.Text

        'End If
        HtmlEditor1.Text = HtmlEditor1.Text & DropDownList1.SelectedItem.Text
        'Dim strr As StringCollection

    End Sub
End Class