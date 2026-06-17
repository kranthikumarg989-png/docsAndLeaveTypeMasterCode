Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class GroupTraining
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim ecode
    Dim appno

    Dim Con1 As New SqlConnection
    Dim Cmd1 As New SqlCommand
    Dim Ad1 As New SqlDataAdapter
    Dim Ds1 As New DataSet

    Dim TmpDs As New DataSet
    Dim Tmpi As Integer
    Dim GlblDs As New DataSet

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (152)
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
    Private Sub messagebox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub SAVEET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEET.Click

        If td_programme.SelectedIndex = -1 Or td_trainingattended.SelectedIndex = -1 Or CmbDepartment.SelectedIndex = -1 Or CmbSection.SelectedIndex = -1 Then
            lblmsg.Text = "Please Select All the Values"
            Exit Sub
        End If

        If CmbType.SelectedItem.Text = "-SELECT-" Then
            lblmsg.Text = "Please select type!"
            Exit Sub
        End If

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        For Tmpj As Integer = 0 To GView1.Rows.Count - 1
            Dim ChkBx = DirectCast(GView1.Rows(Tmpj).FindControl("ChkBxSelect"), CheckBox)

            If ChkBx.Checked = True Then

                Dim TxtBx = DirectCast(GView1.Rows(Tmpj).FindControl("TxtIndRemarks"), TextBox)

                Dim TxtBx1 = DirectCast(GView1.Rows(Tmpj).FindControl("TxtMarkScored"), TextBox)

                Dim fd1 As String
                fd1 = td_dateattended.Text.Trim
                Dim strdate() As String = fd1.Split("/"c)
                fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
                Dim fd As Date
                fd = CDate(fd1)

                Try


                    Call MyGlobal.dbSp_open("td_emptraining")
                    Cmd.Parameters.AddWithValue("@empcode", GView1.Rows(Tmpj).Cells(1).Text)
                    Cmd.Parameters.AddWithValue("@td_trainingattended", td_trainingattended.SelectedValue)
                    Cmd.Parameters.AddWithValue("@td_programme", td_programme.SelectedValue)
                    Cmd.Parameters.AddWithValue("@td_remarks", TxtBx.Text)
                    Cmd.Parameters.AddWithValue("@td_hrs", td_hrs.Text)
                    Cmd.Parameters.AddWithValue("@td_markscored", TxtBx1.Text)
                    Cmd.Parameters.AddWithValue("@td_dateattended", fd)
                    Cmd.Parameters.AddWithValue("@trainingattachment", "")
                    Cmd.Parameters.AddWithValue("@SectionCode", CmbSection.SelectedValue)
                    Cmd.Parameters.AddWithValue("@Method", CmbMethod.SelectedValue)
                    Cmd.Parameters.AddWithValue("@Type", CmbType.SelectedValue)
                    Cmd.Parameters.AddWithValue("@TrainerCode", CmbTrainer.SelectedValue)
                    Cmd.Parameters.AddWithValue("@TrainerName", CmbTrainer.SelectedItem.Text)
                    Cmd.ExecuteNonQuery()






                Catch ex As SqlException
                    lblmsg.Text = ex.Message
                    lblmsg.ForeColor = Drawing.Color.Red
                End Try


            End If
        Next

        lblmsg.Text = "Employee Training Details Added"

        td_trainingattended.SelectedValue = "-1"
        td_programme.SelectedValue = "-1"

        td_dateattended.Text = ""

        MyGlobal.db_close()
        GridView1.DataBind()

        GView1.DataSource = Nothing
        GView1.DataBind()

        CmbDepartment.SelectedIndex = -1
        CmbSection.SelectedIndex = -1
        td_hrs.Text = ""
    End Sub

    

    'Private Sub Appdetails()

    'Dim dr1 As DataRow
    'ecode = empcode.Text
    'Getedata(ecode)
    'If recstatus = True Then
    '    If dsdata.Tables(0).Rows.Count > 0 Then
    '        dr1 = dsdata.Tables(0).Rows(0)
    '        Label11.Text = dr1("empname").ToString
    '        Label13.Text = dr1("departmentcode").ToString
    '        Label10.Text = dr1("sectioncode").ToString
    '        Label18.Text = dr1("dateofjoin").ToString

    '    Else
    '        messagebox("EmployeeCode doesnot Exist!!")
    '    End If
    'End If
    'End Sub

    Public Sub Edit_ET(ByVal sender As Object, ByVal e As CommandEventArgs)
        'appno = e.CommandArgument
        'Dim ds As New DataSet
        'Dim dr1 As DataRow
        'ds = getETDetails(appno)
        'If ds.Tables(0).Rows.Count <> 0 Then
        '    dr1 = ds.Tables(0).Rows(0)
        '    empcode.Text = dr1("empcode").ToString
        '    td_trainingattended.SelectedValue = dr1("td_trainingattended").ToString
        '    td_programme.SelectedValue = dr1("td_programme").ToString
        '    td_remarks.Text = dr1("td_remarks").ToString
        '    td_hrs.Text = dr1("td_hrs").ToString
        '    td_markscored.Text = dr1("td_markscored").ToString
        '    td_dateattended.Text = Format(Convert.ToDateTime(dr1("td_dateattended")), "dd/MM/yyyy")
        '    labelfile.Text = dr1("trainingattachment").ToString

        'End If
    End Sub

    Function getETDetails(ByVal empcode As String) As DataSet

        MyGlobal.Con_Str()
        Dim fd1 As String
        fd1 = td_dateattended.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
        Dim fd As Date
        fd = CDate(fd1)

        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from td_employeetraining where empcode = '" & empcode & "' and td_dateattended = '" & fd & "' and td_hours = '" & "Time" & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "OT")
        con.Close()
        Return ds
    End Function

    Protected Sub td_trainingattended_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles td_trainingattended.SelectedIndexChanged
        CmbDepartment.SelectedIndex = -1
        CmbSection.SelectedIndex = -1
        td_dateattended.Text = ""
        td_hrs.Text = ""
        td_programme.SelectedIndex = -1

    End Sub

    
    Protected Sub CmbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDepartment.SelectedIndexChanged

        GView1.DataSource = Nothing
        GView1.DataBind()

        CmbSection.Items.Clear()
        CmbSection.Items.Add("---Select---")

        CmbSection.DataBind()

    End Sub

    Protected Sub CmbSection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSection.SelectedIndexChanged
        Call DispMeetingInfo()

    End Sub

    Private Function DispMeetingInfo()

        Dim fd1 As String
        fd1 = td_dateattended.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
        Dim fd As Date
        fd = CDate(fd1)

        GView1.DataSource = Nothing
        GView1.DataBind()

        GlblDs = New DataSet
        GlblDs = GetTrainingParticipantsInfo(CmbSection.SelectedValue, DateTime.Now)
        GView1.DataSource = GlblDs.Tables(0)
        GView1.DataBind()

        TmpDs = New DataSet

        TmpDs = GetTrainingData(td_trainingattended.SelectedValue, td_programme.SelectedValue, CmbSection.SelectedValue, fd1)

     
        If TmpDs.Tables(0).Rows.Count >= 1 Then
            For Tmpi = 0 To TmpDs.Tables(0).Rows.Count - 1
                For Tmpj As Integer = 0 To GView1.Rows.Count - 1
                    If TmpDs.Tables(0).Rows(Tmpi).Item(0) = GView1.Rows(Tmpj).Cells(1).Text Then

                        Dim ChkBx = DirectCast(GView1.Rows(Tmpj).FindControl("ChkBxSelect"), CheckBox)
                        ChkBx.Checked = True

                        Dim TxtBx = DirectCast(GView1.Rows(Tmpj).FindControl("TxtIndRemarks"), TextBox)
                        TxtBx.Text = TmpDs.Tables(0).Rows(Tmpi).Item(3)

                        Dim TxtBx1 = DirectCast(GView1.Rows(Tmpj).FindControl("TxtMarkScored"), TextBox)
                        TxtBx1.Text = TmpDs.Tables(0).Rows(Tmpi).Item(4)

                        td_dateattended.Text = Convert.ToDateTime(TmpDs.Tables(0).Rows(Tmpi).Item(5)).ToString("dd/MM/yyyy")
                        td_hrs.Text = TmpDs.Tables(0).Rows(Tmpi).Item(6)
                    End If
                Next
            Next
        End If





    End Function

   


    Public Function GetTrainingParticipantsInfo(ByVal SectionCode As String, ByVal Date1 As DateTime) As DataSet
        Try

            Dim con As New SqlConnection(constr)
            con.Open()

            Ds1 = New DataSet


            Cmd1.CommandType = CommandType.StoredProcedure
            Cmd1.CommandText = "SP_GroupTraining_Participants"
            Cmd1.Parameters.Clear()
            Cmd1.Parameters.AddWithValue("@SectionCode", SectionCode)
            Cmd1.Parameters.AddWithValue("@Date1", Date1)

            Cmd1.Connection = con
            Ad1 = New SqlDataAdapter(Cmd1)

            Ad1.Fill(Ds1, "Details")
            Con1.Close()
            Return Ds1

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function


    Public Function GetTrainingData(ByVal Training As String, ByVal Program As String, ByVal SectionCode As String, ByVal Date1 As DateTime) As DataSet
        Try

            Dim con As New SqlConnection(constr)
            con.Open()

            Ds1 = New DataSet


            Cmd1.CommandType = CommandType.StoredProcedure
            Cmd1.CommandText = "SP_GroupTraining_Data"
            Cmd1.Parameters.Clear()

            Cmd1.Parameters.AddWithValue("@TD_TrainingAttended", Training)
            Cmd1.Parameters.AddWithValue("@TD_Programme", Program)
            Cmd1.Parameters.AddWithValue("@SectionCode", SectionCode)
            Cmd1.Parameters.AddWithValue("@Date1", Date1)
            Cmd1.Connection = con
            Ad1 = New SqlDataAdapter(Cmd1)

            Ad1.Fill(Ds1, "Details")
            Con1.Close()
            Return Ds1

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Protected Sub td_dateattended_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles td_dateattended.TextChanged

        CmbDepartment.SelectedIndex = -1
        CmbSection.SelectedIndex = -1
        GView1.DataSource = Nothing
        GView1.DataBind()

    End Sub

    Protected Sub CmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbType.SelectedIndexChanged
        CmbTrainer.DataSource = Nothing
        CmbTrainer.DataBind()

        CmbTrainer.DataTextField = "EmpName"
        CmbTrainer.DataValueField = "EmpCode"

        If CmbType.SelectedItem.Text = "INTERNAL" Then
            CmbTrainer.DataSource = SqlDataSource6
            CmbTrainer.DataBind()
        Else
            
            CmbTrainer.DataSource = SqlDataSource7
            CmbTrainer.DataBind()
        End If
    End Sub
End Class