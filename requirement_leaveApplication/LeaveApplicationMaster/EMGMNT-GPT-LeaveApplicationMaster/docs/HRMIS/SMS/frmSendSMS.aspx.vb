Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Partial Public Class frmSendSMS
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim mynet As New Emanagement.netglobal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (126)
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

    'Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
    '    TxtBoxGrpName.Text = DropDownList1.SelectedValue
    '    Session("groupname") = DropDownList1.SelectedValue
    '    GridView2.DataSource = GetMenuData()
    '    GridView2.DataBind()

    'End Sub
    Function GetMenuData() As DataSet
        'MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(conSMSstr)
        Dim dadCats As New _
        SqlDataAdapter("SELECT * FROM tbl_group_sms where groupname = '" & Session("groupname") & "'", con)
        Dim dst As New DataSet()
        dadCats.Fill(dst, "tbl_group_sms")
        Return dst
    End Function
    Function GetGridData() As DataSet
        'MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(conSMSstr)
        Dim dadCats As New _
        SqlDataAdapter("SELECT distinct(groupname) as groupname FROM tbl_group_sms order by groupname", con)
        Dim dst As New DataSet()
        dadCats.Fill(dst, "tbl_group_smss")
        Return dst
    End Function
    'Function GetempData() As DataSet
    '    'MyGlobal.Open_Con()
    '    MyGlobal.Con_Str()
    '    Dim con As New SqlConnection(constr)
    '    Dim dadCats As New _
    '    SqlDataAdapter("SELECT empname FROM empmaster where empcode='" & TxtEmpCode.Text & "'", con)
    '    Dim dst As New DataSet()
    '    dadCats.Fill(dst, "empmaster")
    '    Return dst
    'End Function

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'If Len(Trim(TxtBoxMessage.Text)) <> 0 Then
        '    Dim row As GridViewRow
        '    For Each row In GridView2.Rows
        '        Dim ChkBoxCell As CheckBox = row.FindControl("checkbox1")
        '        If ChkBoxCell.Checked Then
        '            Dim RoleId As String = CType(row.Cells(0).Text, String)
        '            Session("groupname") = RoleId
        '            Dim dss As DataSet
        '            dss = GetMenuData()
        '            Dim drr As DataRow
        '            Dim mobileno As String
        '            If dss.Tables(0).Rows.Count <> 0 Then
        '                Dim i
        '                For i = 0 To dss.Tables(0).Rows.Count - 1
        '                    drr = dss.Tables(0).Rows(i)
        '                    mobileno = drr("mobileno") & ""
        '                    If Len(Trim(mobileno)) <> 0 Then
        '                        Try
        '                            mynet.db_cn()
        '                            mynet.dbSMS_open()
        '                            Call mynet.dbSpSMS_open("insert_outgoing_1")
        '                            command.Parameters.AddWithValue("@number_2", mobileno)
        '                            command.Parameters.AddWithValue("@message_3", Trim(TxtBoxMessage.Text))
        '                            command.Parameters.AddWithValue("@starttime_4", CStr(Now))
        '                            command.Parameters.AddWithValue("@endtime_5", CStr(Now))
        '                            command.Parameters.AddWithValue("@fkey_6", "1")
        '                            command.ExecuteNonQuery()
        '                            mynet.dbSMS_close()
        '                            LblMsg.Text = "Congratulations! You have Saved successfully. "
        '                            LblMsg.ForeColor = Drawing.Color.DarkGreen
        '                        Catch ex As Exception
        '                            LblMsg.Text = ex.Message
        '                            LblMsg.ForeColor = Drawing.Color.Red
        '                        End Try
        '                    End If
        '                Next
        '            End If
        '        End If
        '    Next
        'Else
        '    LblMsg.Text = "Please select or enter a group name"
        '    LblMsg.ForeColor = Drawing.Color.Red
        'End If

        ' '' commented on 17/07/2012
        ' ''If Len(Trim(TxtBoxMessage.Text)) <> 0 Then
        ' ''    Dim row As GridViewRow
        ' ''    For Each row In GridView2.Rows
        ' ''        Dim ChkBoxCell As CheckBox = row.FindControl("checkbox1")
        ' ''        If ChkBoxCell.Checked Then
        ' ''            Dim RoleId As String = CType(row.Cells(0).Text, String)
        ' ''            Session("groupname") = RoleId
        ' ''            If RoleId <> "" Then
        ' ''                Try
        ' ''                    mynet.db_cn()
        ' ''                    mynet.dbSMS_open()
        ' ''                    Call mynet.dbSpSMS_open("NewSMS_Ins_tbl_sms_group")
        ' ''                    command.Parameters.AddWithValue("@groupname", RoleId)
        ' ''                    command.Parameters.AddWithValue("@message", Trim(TxtBoxMessage.Text))
        ' ''                    command.Parameters.AddWithValue("@senddate", Date.Now)
        ' ''                    command.Parameters.AddWithValue("@keyinby", Session("empcode"))
        ' ''                    command.Parameters.AddWithValue("@ccode", "MMSB")
        ' ''                    command.ExecuteNonQuery()
        ' ''                    mynet.dbSMS_close()
        ' ''                    LblMsg.Text = "Congratulations! You have Saved successfully. "
        ' ''                    LblMsg.ForeColor = Drawing.Color.DarkGreen
        ' ''                Catch ex As Exception
        ' ''                    LblMsg.Text = ex.Message
        ' ''                    LblMsg.ForeColor = Drawing.Color.Red
        ' ''                End Try
        ' ''            End If
        ' ''        End If
        ' ''    Next
        ' ''Else
        ' ''    LblMsg.Text = "Please enter your message"
        ' ''    LblMsg.ForeColor = Drawing.Color.Red
        ' ''End If  If Len(Trim(TxtBoxMessage.Text)) <> 0 Then
        If Len(Trim(TxtBoxMessage.Text)) <> 0 Then
            Dim row As GridViewRow
            For Each row In GridView2.Rows
                Dim ChkBoxCell As CheckBox = row.FindControl("checkbox1")
                If ChkBoxCell.Checked Then
                    Dim RoleId As String = CType(row.Cells(0).Text.Trim, String)
                    Session("groupname") = RoleId
                    If RoleId <> "" Then
                        '''SEND SMS OUT IMMEDIATELY IF IT IS EMERGENCY SMS
                        If RoleId = "ERT & SHC MEMBERS" Or RoleId = "Emergency SMS" Or RoleId = "ERT &amp; SHC MEMBERS" Then
                            If RoleId = "ERT &amp; SHC MEMBERS" Then
                                RoleId = "ERT & SHC MEMBERS"
                                Session("groupname") = RoleId
                            End If
                            Try
                                mynet.db_cn()
                                mynet.dbSMS_open()
                                Call mynet.dbSpSMS_open("NewSMS_Instbl_sms_group_FOR GM")
                                command.Parameters.AddWithValue("@groupname", RoleId)
                                command.Parameters.AddWithValue("@message", Trim(TxtBoxMessage.Text))
                                command.Parameters.AddWithValue("@senddate", Date.Now)
                                command.Parameters.AddWithValue("@keyinby", Session("empcode"))
                                command.Parameters.AddWithValue("@ccode", "MMSB")
                                command.ExecuteNonQuery()
                                mynet.dbSMS_close()
                            Catch ex As Exception
                                LblMsg.Text = ex.Message
                                LblMsg.ForeColor = Drawing.Color.Red
                            End Try
                            Dim dss As DataSet
                            dss = GetMenuData()
                            Dim drr As DataRow
                            Dim mobileno As String
                            If dss.Tables(0).Rows.Count <> 0 Then
                                Dim i
                                For i = 0 To dss.Tables(0).Rows.Count - 1
                                    drr = dss.Tables(0).Rows(i)
                                    mobileno = drr("mobileno") & ""
                                    If Len(Trim(mobileno)) <> 0 Then
                                        Try
                                            mynet.db_cn()
                                            mynet.dbSMS_open()
                                            Call mynet.dbSpSMS_open("insert_outgoing_2")
                                            command.Parameters.AddWithValue("@number_2", mobileno)
                                            command.Parameters.AddWithValue("@message_3", Trim(TxtBoxMessage.Text))
                                            command.Parameters.AddWithValue("@starttime_4", CStr(Now))
                                            command.Parameters.AddWithValue("@endtime_5", CStr(Now))
                                            command.Parameters.AddWithValue("@fkey_6", " ")
                                            command.Parameters.AddWithValue("@priority", "15")
                                            command.ExecuteNonQuery()
                                            mynet.dbSMS_close()
                                            LblMsg.Text = "Congratulations! You have Saved successfully. "
                                            LblMsg.ForeColor = Drawing.Color.DarkGreen
                                        Catch ex As Exception
                                            LblMsg.Text = ex.Message
                                            LblMsg.ForeColor = Drawing.Color.Red
                                        End Try
                                    End If
                                Next
                            End If
                            ''SENT SMS AS PER SCHEDULED IF IT IS NOT EMERGENCY SMS
                        Else
                            Try
                                mynet.db_cn()
                                mynet.dbSMS_open()
                                Call mynet.dbSpSMS_open("NewSMS_Ins_tbl_sms_group")
                                command.Parameters.AddWithValue("@groupname", RoleId)
                                command.Parameters.AddWithValue("@message", Trim(TxtBoxMessage.Text))
                                command.Parameters.AddWithValue("@senddate", Date.Now)
                                command.Parameters.AddWithValue("@keyinby", Session("empcode"))
                                command.Parameters.AddWithValue("@ccode", "MMSB")
                                command.ExecuteNonQuery()
                                mynet.dbSMS_close()
                                LblMsg.Text = "Congratulations! You have Saved successfully. "
                                LblMsg.ForeColor = Drawing.Color.DarkGreen
                            Catch ex As Exception
                                LblMsg.Text = ex.Message
                                LblMsg.ForeColor = Drawing.Color.Red
                            End Try
                        End If
                    End If
                End If
            Next '
        Else
            LblMsg.Text = "Please enter your message"
            LblMsg.ForeColor = Drawing.Color.Red
        End If
    End Sub

    'Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim row As GridViewRow

    '    For Each row In GridView2.Rows

    '        Dim ChkBoxCell As CheckBox = row.FindControl("checkbox1")

    '        If ChkBoxCell.Checked Then

    '            Dim RoleId As String = CType(row.Cells(0).Text, String)

    '            'Dim row2 As GridViewRow
    '            'Dim SystemId, ModuleId
    '            'For Each row2 In GridView2.Rows
    '            '    Dim chkboxCell2 As CheckBox = row2.FindControl("checkbox1")
    '            '    If chkboxCell2.Checked Then
    '            '        SystemId = CType(row2.Cells(0).Text, String)
    '            '        ModuleId = CType(row2.Cells(2).Text, String)
    '            '    End If

    '            '    Dim ScrTypeId
    '            '    Dim status

    '            Try
    '                mynet.db_cn()
    '                mynet.dbSMS_open()
    '                Call mynet.dbSpSMS_open("Sp_del_smsGroups")
    '                command.Parameters.AddWithValue("@id", RoleId)
    '                command.ExecuteNonQuery()
    '                mynet.dbSMS_close()
    '                LblMsg.Text = "Congratulations! You have removed the records successfully. "
    '                LblMsg.ForeColor = Drawing.Color.DarkGreen
    '                GridView2.DataSource = GetGridData()
    '                GridView2.DataBind()
    '            Catch ex As Exception
    '                LblMsg.Text = ex.Message
    '                LblMsg.ForeColor = Drawing.Color.Red
    '            End Try
    '            'Next

    '            'Next

    '            'SqlDataSource2.Update()

    '        End If

    '    Next
    'End Sub
End Class