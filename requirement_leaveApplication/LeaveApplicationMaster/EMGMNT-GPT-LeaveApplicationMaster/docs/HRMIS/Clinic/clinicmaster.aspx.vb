Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class clinicmaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim sqltext, dt, res, ecode As String
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (234)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                ' MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If
    End Sub
    Protected Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles save.Click
        dt = DateTime.Now.ToString
        ecode = Session("empcode")
        If cn.Text <> "" And dn.Text <> "" And ad.Text <> "" And pon.Text <> "" Then
        Else
            MessageBox("Textbox Shouldbe fill")
            Exit Sub
        End If
        If save.Text = "Update" Then
            sqltext = "update clinicmaster set clinicname='" & (cn.Text) & "',doctorname='" & (dn.Text) & "',address='" & (ad.Text) & "',phoneno='" & (pon.Text) & "',modifiedby='" & ecode & "',modifiedtime='" & dt & "' where cliniccode='" & Session("code") & "'"
            cmd = New SqlCommand(sqltext, Con)
            cmd.ExecuteNonQuery()
            save.Text = "Save"
            MessageBox("Record Updated sucessfully")
            cn.Text = ""
            dn.Text = ""
            ad.Text = ""
            pon.Text = ""
            sqltext = "select*from clinicmaster where cliniccode='" & Session("code") & "'"
        Else
            sqltext = "select max(cliniccode) from clinicmaster"
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                res = rdr(0)
            End While
            rdr.Close()
            res = Right(res, Len(res) - 1)
            res = res + 1
            If res < 10 Then
                res = "C00" & res
            ElseIf res > 9 And res < 100 Then
                res = "C0" & res
            ElseIf res > 99 Then
                res = "C" & res
            End If
            sqltext = "insert into clinicmaster values('" & res & "','" & (cn.Text.Trim) & "','" & (dn.Text.Trim) & "','" & (ad.Text.Trim) & "','" & (pon.Text.Trim) & "','" & ecode & "','" & dt & "','','','')"
            cmd = New SqlCommand(sqltext, Con)
            cmd.ExecuteNonQuery()
            MessageBox("Record Saved")
            cn.Text = ""
            dn.Text = ""
            ad.Text = ""
            pon.Text = ""
            sqltext = "select*from clinicmaster where cliniccode='" & res & "'"
            cmd = New SqlCommand(sqltext, Con)
           
        End If
        DS = GetappCharactersetting(sqltext)
        GridView1.DataSource = DS
        GridView1.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Public Sub edi(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim code As String
        code = e.CommandArgument
        Session("code") = code
        sqltext = "select clinicname,doctorname,address,phoneno from clinicmaster where cliniccode='" & code & "'"
        cmd = New SqlCommand(sqltext, Con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            cn.Text = rdr(0)
            dn.Text = rdr(1)
            ad.Text = rdr(2)
            pon.Text = rdr(3)
        End While
        rdr.Close()
        save.Text = "Update"
    End Sub
    Public Sub del(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim del As String
        del = e.CommandArgument
        sqltext = "delete clinicmaster where cliniccode='" & del & "'"
        cmd = New SqlCommand(sqltext, Con)
        cmd.ExecuteNonQuery()
        MessageBox(del & "Record deleted")
        GridView1.DataBind()
        cn.Text = ""
        dn.Text = ""
        ad.Text = ""
        pon.Text = ""
    End Sub
    Function GetappCharactersetting(ByVal sqltext As String) As DataSet
        Dim ds As New DataSet()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, Con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "character")
        Con.Close()
        Return ds
    End Function
End Class