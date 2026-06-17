Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class ER_letter_EditPage
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim da As SqlDataAdapter
    Dim rdr, rdr1 As SqlDataReader
    Dim Str, lnames As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        ' Dim strcontent As String
        ' Button2.Enabled = False
        ' HtmlEditor1.DesignModeEditable = False
        'lnames = Request.QueryString("letternam").ToString()
        HtmlEditor1.DesignModeEditable = False
        Button2.Enabled = False
        con = New SqlConnection(constr)
        con.Open()
        Dim app, sch, ed, str0 As String
        app = "Approved"
        sch = "Scheduled"
        ed = "ES"
        str0 = "SELECT DISTINCT lettername FROM HRMIS_ER_MASTER_LETTER where status='" & app & "'or status='" & sch & "' or status='" & ed & "'"
        cmd = New SqlCommand(str0, con)
        rdr1 = cmd.ExecuteReader
        While rdr1.Read
            If IsPostBack = False Then
                DropDownList1.Items.Add(rdr1(0).ToString)
            End If
        End While
        rdr1.Close()
        Str = "select lettername,revision from HRMIS_ER_MASTER_LETTER where lettername='" & (DropDownList1.SelectedItem.Text) & "'"
        cmd = New SqlCommand(Str, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            'strcontent = (rdr(0)).ToString
            Label3.Text = (rdr(1))
        End While
        Dim n As Integer
        'If Label3.Text <> "" Then
        '    n = Val(Label3.Text) + 1
        '    ' MsgBox(n)
        'End If
        rdr.Close()
        con.Close()
        ' If IsPostBack = False Then
        ' HtmlEditor1.Text = strcontent
        'End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        HtmlEditor1.Text = ""
        If (HtmlEditor1.Text = "") Then
            DropDownList1.SelectedValue = -1
            Label3.Text = ""
        End If
    End Sub
    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim updstr, ES As String
        Dim n As Integer
        If Label3.Text <> "" Then
            n = Val(Label3.Text) + 1
            ' MsgBox(n)
        End If
        Dim con As New SqlConnection(constr)
        'constr = "Data Source=NB01\SQLEXPRESS;Initial Catalog=hrmis;Integrated Security=True"
        con = New SqlConnection(constr)
        con.Open()
        updstr = HtmlEditor1.Text
        'MsgBox(updstr)
        ES = "ES"
        Str = "update HRMIS_ER_MASTER_LETTER set lettercontents='" & updstr & "',revision= " & n & ",status= '" & ES & "' where lettername='" & (DropDownList1.SelectedItem.Text) & "'"
        cmd = New SqlCommand(Str, con)
        MessageBox("Record saved sucessfully")
        HtmlEditor1.Text = ""
        If (HtmlEditor1.Text = "") Then
            DropDownList1.SelectedValue = -1
            Label3.Text = ""
        End If
        cmd.ExecuteNonQuery()
        con.Close()
        cmd.Dispose()
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        HtmlEditor1.DesignModeEditable = True
        Button2.Enabled = True
        Dim dr As SqlDataReader
        Dim strcontent As String
        Dim n As Integer
        'Dim oldvalue, newvalue
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        'constr = "Data Source=NB01\SQLEXPRESS;Initial Catalog=hrmis;Integrated Security=True"
        con = New SqlConnection(constr)
        con.Open()
        HtmlEditor1.DesignModeEditable = True
        cmd = New SqlCommand("select lettercontents,revision from HRMIS_ER_MASTER_LETTER where lettername='" & (DropDownList1.SelectedItem.Text) & "' ", con)
        'cmd.Parameters.AddWithValue("@lettercontents", HtmlEditor1.Text)
        dr = cmd.ExecuteReader()
        While dr.Read
            strcontent = dr("lettercontents").ToString()
            HtmlEditor1.Text = strcontent
            If Label3.Text <> "" Then
                n = Val(Label3.Text) + 1
                'MsgBox(n)
            End If
            rdr.Close()
        End While
        con.Close()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class