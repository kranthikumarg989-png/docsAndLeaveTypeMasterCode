Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Partial Public Class frmSMSgrpReg
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim mynet As New Emanagement.netglobal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (127)
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
        If Not IsPostBack Then
            GridView2.DataSource = GetGridData()
            GridView2.DataBind()
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        TxtBoxGrpName.Text = DropDownList1.SelectedValue
        Session("groupname") = DropDownList1.SelectedValue
        GridView2.DataSource = GetMenuData()
        GridView2.DataBind()

    End Sub
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
        SqlDataAdapter("SELECT * FROM tbl_group_sms order by groupname", con)
        Dim dst As New DataSet()
        dadCats.Fill(dst, "tbl_group_sms")
        Return dst
    End Function
    Function GetempData() As DataSet
        'MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        Dim dadCats As New _
        SqlDataAdapter("SELECT empname FROM empmaster where empcode='" & TxtEmpCode.Text & "' and resigned <>'Y'", con)
        Dim dst As New DataSet()
        dadCats.Fill(dst, "empmaster")
        Return dst
    End Function

    Protected Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Len(Trim(TxtBoxGrpName.Text)) <> 0 Then
            If Len(Trim(TxtBoxMobileNo.Text)) <> 0 Then
                If Len(Trim(TxtEmpCode.Text)) <> 0 Then
                    LblEmpName.Text = ""
                    Dim ds As DataSet
                    ds = GetempData()
                    If ds.Tables(0).Rows.Count <> 0 Then
                        Dim dr As DataRow
                        dr = ds.Tables(0).Rows(0)
                        Dim empname As String
                        empname = dr("empname") & ""
                        If Len(Trim(empname)) <> 0 Then
                            LblEmpName.Text = empname
                        End If
                    End If
                    If Len(Trim(LblEmpName.Text)) <> 0 Then
                        Try
                            mynet.db_cn()
                            mynet.dbSMS_open()
                            Call mynet.dbSpSMS_open("Sp_InsUpdsmsGroups")
                            command.Parameters.AddWithValue("@empcode", Trim(TxtEmpCode.Text))
                            command.Parameters.AddWithValue("@groupname", Trim(TxtBoxGrpName.Text))
                            command.Parameters.AddWithValue("@mobileno", Trim(TxtBoxMobileNo.Text))
                            command.Parameters.AddWithValue("@empname", Trim(LblEmpName.Text))
                            command.ExecuteNonQuery()
                            mynet.dbSMS_close()
                            LblMsg.Text = "Congratulations! You have Saved successfully. "
                            LblEmpName.Text = ""
                            LblMsg.ForeColor = Drawing.Color.DarkGreen
                        Catch ex As Exception
                            LblMsg.Text = ex.Message
                            LblMsg.ForeColor = Drawing.Color.Red
                        End Try
                        GridView2.DataSource = GetMenuData()
                        GridView2.DataBind()
                    Else
                        LblMsg.Text = "Please check the employee code. This employee does not exist or resigned"
                        LblMsg.ForeColor = Drawing.Color.Red
                    End If
                Else
                    LblMsg.Text = "Please enter employee code"
                    LblMsg.ForeColor = Drawing.Color.Red
                End If
            Else
                LblMsg.Text = "Please enter mobile number"
                LblMsg.ForeColor = Drawing.Color.Red
            End If
        Else
            LblMsg.Text = "Please select or enter a group name"
            LblMsg.ForeColor = Drawing.Color.Red
        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim row As GridViewRow

        For Each row In GridView2.Rows

            Dim ChkBoxCell As CheckBox = row.FindControl("checkbox1")

            If ChkBoxCell.Checked Then

                Dim RoleId As String = CType(row.Cells(0).Text, String)

                'Dim row2 As GridViewRow
                'Dim SystemId, ModuleId
                'For Each row2 In GridView2.Rows
                '    Dim chkboxCell2 As CheckBox = row2.FindControl("checkbox1")
                '    If chkboxCell2.Checked Then
                '        SystemId = CType(row2.Cells(0).Text, String)
                '        ModuleId = CType(row2.Cells(2).Text, String)
                '    End If

                '    Dim ScrTypeId
                '    Dim status

                Try
                    mynet.db_cn()
                    mynet.dbSMS_open()
                    Call mynet.dbSpSMS_open("Sp_del_smsGroups")
                    command.Parameters.AddWithValue("@id", RoleId)
                    command.ExecuteNonQuery()
                    mynet.dbSMS_close()
                    LblMsg.Text = "Congratulations! You have removed the records successfully. "
                    LblMsg.ForeColor = Drawing.Color.DarkGreen
                    GridView2.DataSource = GetGridData()
                    GridView2.DataBind()
                Catch ex As Exception
                    LblMsg.Text = ex.Message
                    LblMsg.ForeColor = Drawing.Color.Red
                End Try
                'Next

                'Next

                'SqlDataSource2.Update()

            End If

        Next
    End Sub
End Class