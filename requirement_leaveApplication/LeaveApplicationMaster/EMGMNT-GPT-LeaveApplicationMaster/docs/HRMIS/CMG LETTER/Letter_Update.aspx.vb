Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class Letter_Update
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand

    Dim da As SqlDataAdapter
    Dim rdr As SqlDataReader
    Dim Str, lnames As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Dim strcontent As String
        ' Button2.Enabled = False
        ' HtmlEditor1.DesignModeEditable = False
        'lnames = Request.QueryString("letternam").ToString()
        constr = "Data Source=NB09;Initial Catalog=hrmis;uid=sa;Pwd="";"
        con = New SqlConnection(constr)
        con.Open()
        Str = "select lettername,revision from HRMIS_ER_MASTER_LETTER where lettername='" & (DropDownList1.SelectedItem.Text) & "'"
        cmd = New SqlCommand(Str, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Label3.Text = (rdr(1))
        End While
        Dim n As Integer
        If Label3.Text <> "" Then
            n = Val(Label3.Text) + 1
        End If
        rdr.Close()
        con.Close()

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged


        Dim dr As SqlDataReader
        Dim strcontent As String
        Dim n As Integer
        'Dim oldvalue, newvalue
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        constr = "Data Source=NB09;Initial Catalog=hrmis;uid=sa;Pwd="";"
        con = New SqlConnection(constr)
        con.Open()
        HtmlEditor1.DesignModeEditable = True
        cmd = New SqlCommand("select lettercontents,revision from HRMIS_ER_MASTER_LETTER where lettername='" & (DropDownList1.SelectedItem.Text) & "' ", con)
        'cmd.Parameters.AddWithValue("@lettercontents", HtmlEditor1.Text)
        dr = cmd.ExecuteReader()
        While (dr.Read())
            strcontent = dr("lettercontents").ToString()
            HtmlEditor1.Text = strcontent
            If Label3.Text <> "" Then
                n = Val(Label3.Text) + 1
                MessageBox(n)
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

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim updstr As String

        Dim n As Integer
        If Label3.Text <> "" Then
            n = Val(Label3.Text) + 1
            ' MsgBox(n)
        End If
        Dim con As New SqlConnection(constr)
        constr = "Data Source=NB09;Initial Catalog=hrmis;uid=sa;Pwd="";"
        con = New SqlConnection(constr)
        con.Open()
        updstr = HtmlEditor1.Text
        'MsgBox(updstr)

        Str = "update HRMIS_ER_MASTER_LETTER set lettercontents='" & updstr & "',revision= " & n & " where lettername='" & (DropDownList1.SelectedItem.Text) & "'"
        cmd = New SqlCommand(Str, con)

        MessageBox("record saved sucessfully")


        HtmlEditor1.Text = ""

        If (HtmlEditor1.Text = "") Then
            DropDownList1.SelectedValue = -1
            Label3.Text = ""
        End If
        cmd.ExecuteNonQuery()
        con.Close()
        cmd.Dispose()

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        HtmlEditor1.Text = ""

        If (HtmlEditor1.Text = "") Then
            DropDownList1.SelectedValue = -1
            Label3.Text = ""
        End If
    End Sub
End Class