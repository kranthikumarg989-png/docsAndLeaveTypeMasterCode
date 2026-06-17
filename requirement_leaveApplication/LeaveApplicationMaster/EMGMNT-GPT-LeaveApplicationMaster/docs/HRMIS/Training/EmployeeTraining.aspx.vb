Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class EmployeeTraining
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim ecode
    Dim appno
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

        If LblType1.Text = "" Then
            lblmsg.Text = "Please Assign Type!"
            Exit Sub
        End If

        Dim filename As String = trainingattachment.PostedFile.FileName
        Dim ext As String = System.IO.Path.GetExtension(trainingattachment.PostedFile.FileName)
        Dim Myfile As String = labelfile.Text.Trim & ext

        Dim fd1 As String
        fd1 = td_dateattended.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
        Dim fd As Date
        fd = CDate(fd1)

        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()

            Call MyGlobal.dbSp_open("td_emptraining")
            Cmd.Parameters.AddWithValue("@empcode", empcode.Text)
            Cmd.Parameters.AddWithValue("@td_trainingattended", td_trainingattended.SelectedValue)
            Cmd.Parameters.AddWithValue("@td_programme", LblProgramme.Text)
            Cmd.Parameters.AddWithValue("@td_remarks", td_remarks.Text)
            Cmd.Parameters.AddWithValue("@td_hrs", td_hrs.Text)
            Cmd.Parameters.AddWithValue("@td_markscored", td_markscored.Text)
            Cmd.Parameters.AddWithValue("@td_dateattended", fd)
            Cmd.Parameters.AddWithValue("@trainingattachment", Myfile)

            Cmd.Parameters.AddWithValue("@Method", LblMethod.Text)
            Cmd.Parameters.AddWithValue("@Type", LblType1.Text)
            Cmd.Parameters.AddWithValue("@TrainerCode", CmbTrainer.SelectedValue)
            Cmd.Parameters.AddWithValue("@TrainerName", CmbTrainer.SelectedItem.Text)

            Cmd.ExecuteNonQuery()

            lblmsg.Text = "Employee Training Details Added"

            empcode.Text = ""
            td_trainingattended.SelectedValue = "-1"
            LblProgramme.Text = ""
            LblMethod.Text = ""
            LblType1.Text = ""
            td_remarks.Text = ""
            td_hrs.Text = ""
            td_markscored.Text = ""
            td_dateattended.Text = ""

        Catch ex As SqlException
            lblmsg.Text = ex.Message
            lblmsg.ForeColor = Drawing.Color.Red
        End Try
        MyGlobal.db_close()
        GridView1.DataBind()


    End Sub

    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        Appdetails()
    End Sub

    Private Sub Appdetails()
        
        Dim dr1 As DataRow
        ecode = empcode.Text
        Getedata(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                Label11.Text = dr1("empname").ToString
                Label13.Text = dr1("departmentcode").ToString
                Label10.Text = dr1("sectioncode").ToString
                Label18.Text = dr1("dateofjoin").ToString

            Else
                messagebox("EmployeeCode doesnot Exist!!")
            End If
        End If
    End Sub

    Public Sub Edit_ET(ByVal sender As Object, ByVal e As CommandEventArgs)
        appno = e.CommandArgument
        Dim ds As New DataSet
        Dim dr1 As DataRow
        ds = getETDetails(appno)
        If ds.Tables(0).Rows.Count <> 0 Then
            dr1 = ds.Tables(0).Rows(0)
            empcode.Text = dr1("empcode").ToString
            td_trainingattended.SelectedValue = dr1("td_trainingattended").ToString
            LblProgramme.Text = dr1("td_programme").ToString
            td_remarks.Text = dr1("td_remarks").ToString
            td_hrs.Text = dr1("td_hrs").ToString
            td_markscored.Text = dr1("td_markscored").ToString
            td_dateattended.Text = Format(Convert.ToDateTime(dr1("td_dateattended")), "dd/MM/yyyy")
            labelfile.Text = dr1("trainingattachment").ToString

        End If
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
        Command = New SqlCommand("select * from td_employeetraining where empcode = '" & empcode & "' and td_dateattended = '" & fd & "' and td_hours = '" & td_hrs.Text & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "OT")
        con.Close()
        Return ds
    End Function

     

    Protected Sub td_trainingattended_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles td_trainingattended.SelectedIndexChanged
        Try
            Dim Ad As New SqlDataAdapter
            Dim NewDs As New DataSet

            Dim code As Integer
            MyGlobal.Con_Str()
            Dim con As New SqlConnection(constr)
            con.Open()
            'Label1.Text = "SELECT td_programme, Method, Type FROM td_traininglist WHERE (td_title = '" & td_trainingattended.SelectedItem.Text & "')"
            Cmd = New SqlCommand("SELECT td_programme, Method, Type FROM td_traininglist WHERE (td_title = '" & td_trainingattended.SelectedItem.Text & "')", con)
            Cmd.CommandType = CommandType.Text
            Ad = New SqlDataAdapter(Cmd)
            Ad.Fill(NewDs, "Table")

            LblProgramme.Text = ""
            LblMethod.Text = ""
            LblType1.Text = ""
            
            LblProgramme.Text = NewDs.Tables(0).Rows(0).Item(0).ToString()
            LblMethod.Text = NewDs.Tables(0).Rows(0).Item(1).ToString()
            LblType1.Text = NewDs.Tables(0).Rows(0).Item(2).ToString()

            CmbTrainer.DataSource = Nothing
            CmbTrainer.DataBind()

            CmbTrainer.DataTextField = "EmpName"
            CmbTrainer.DataValueField = "EmpCode"

            If LblType1.Text = "INTERNAL" Then
                CmbTrainer.DataSource = SqlDataSource4
                CmbTrainer.DataBind()
            Else
                CmbTrainer.DataSource = SqlDataSource5
                CmbTrainer.DataBind()
            End If

        Catch ex As Exception
            Label1.Text = ex.ToString
        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("http://192.168.0.245/app/newhrmis")
    End Sub
End Class