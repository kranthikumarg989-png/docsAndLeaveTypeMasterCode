Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports E_Management.Emanagement.netglobal
Partial Public Class memoapproval
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim mynet As New emanagement.netglobal
    Dim cmd As New SqlCommand
    Dim str, apby, apdt, aptm As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (117)
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
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        apby = Session("_ecode")
        apdt = Date.Now.ToShortDateString
        aptm = Date.Now.ToShortTimeString
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        MyGlobal.Open_Con()
        con.Open()
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim slno = GridView1.Rows(i).Cells(0).Text
            Dim emp = GridView1.Rows(i).Cells(1).Text
            Dim sts = DirectCast(GridView1.Rows(i).FindControl("radiobuttonlist1"), RadioButtonList).SelectedValue

            If sts = "F" Then
                sts = "F"
            ElseIf sts = "R" Then
                sts = "R"
            ElseIf sts = "P" Or sts = "" Then
                sts = "P"
            End If
            str = "update memo set status='" & sts & "',approvedby='" & apby & "',approved_date='" & apdt & "',approved_time='" & aptm & "' where serialno='" & slno & "'"
            cmd = New SqlCommand(str, con)
            cmd.ExecuteNonQuery()

            If sts = "F" Then
                Try
                    mynet.db_cn()
                    mynet.dbSMS_open()

                    Call mynet.dbSpSMS_open("sp_ins_sMsLink")
                    Command.Parameters.AddWithValue("@number", Trim(slno))
                    Command.Parameters.AddWithValue("@createdby", Trim(emp))

                    Command.ExecuteNonQuery()
                    '  mynet.db_close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        Next
        GridView1.DataBind()
    End Sub

End Class