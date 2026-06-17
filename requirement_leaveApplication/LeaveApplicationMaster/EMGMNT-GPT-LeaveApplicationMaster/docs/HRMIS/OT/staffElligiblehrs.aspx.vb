Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class staffElligiblehrs
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        ' Session("empcode") = "014543"
        LblMsg.Text = ""
    End Sub
    Protected Sub rb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.SelectedIndexChanged
        GridView1.Visible = False
        If rb1.SelectedValue = "Dept" Then
            Deptddl.Visible = True
            Secddl.Visible = False
            depart.Visible = True
            section.Visible = False
            Cbsect.Visible = False
            cbdept.Visible = True
        ElseIf rb1.SelectedValue = "sect" Then
            Deptddl.Visible = False
            Secddl.Visible = True
            depart.Visible = False
            section.Visible = True
            Cbsect.Visible = True
            cbdept.Visible = False
        End If

    End Sub
    Protected Sub Submitelig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitElig.Click

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        bindOTGrid()
        GridView1.Visible = True
    End Sub

    Private Sub bindOTGrid()

        Dim opn
        Dim Dept As String
        Dept = Deptddl.SelectedValue
        Dim sect As String
        sect = Secddl.SelectedValue
        Dim myval
        Dim sqltext

        If rb1.SelectedValue = "Dept" And Deptddl.SelectedValue = "-1" And cbdept.Checked = False Then
            LblMsg.Text = "Select Department"
            Exit Sub
        ElseIf rb1.SelectedValue = "sect" And Secddl.SelectedValue = "-1" And Cbsect.Checked = False Then
            LblMsg.Text = "Select Section"
            Exit Sub
        End If

        If rb1.SelectedValue = "Dept" And Deptddl.SelectedValue <> "-1" And cbdept.Checked = False Then
            myval = Dept
            sqltext = "SELECT empmaster.Empname, empmaster.Empcode, empmaster.Sectioncode , empmaster.Departmentcode, OT_ElligibleStaff.Recno, OT_ElligibleStaff.Maxhrs FROM OT_ElligibleStaff INNER JOIN empmaster ON OT_ElligibleStaff.empcode = empmaster.empcode WHERE (OT_ElligibleStaff.Elligible = '-1') and empmaster.resigned='N' and empmaster.departmentcode='" & myval & "'"
        ElseIf rb1.SelectedValue = "sect" And Secddl.SelectedValue <> "-1" And Cbsect.Checked = False Then
            myval = sect
            sqltext = "SELECT empmaster.Empname, empmaster.Empcode, empmaster.Sectioncode , empmaster.Departmentcode, OT_ElligibleStaff.Recno, OT_ElligibleStaff.Maxhrs FROM OT_ElligibleStaff INNER JOIN empmaster ON OT_ElligibleStaff.empcode = empmaster.empcode WHERE (OT_ElligibleStaff.Elligible = '-1') and empmaster.resigned='N' and empmaster.sectioncode='" & myval & "'"
            'ElseIf rb1.SelectedValue = "ecode" And code.Text <> "" Then
            '    myval = ecode
            '    sqltext = "SELECT empmaster.Empname, empmaster.Empcode, empmaster.Sectioncode , empmaster.Departmentcode, OT_ElligibleStaff.Recno, OT_ElligibleStaff.Maxhrs FROM OT_ElligibleStaff INNER JOIN empmaster ON OT_ElligibleStaff.empcode = empmaster.empcode WHERE (OT_ElligibleStaff.Elligible = '-1') and empmaster.resigned='N' and empmaster.empcode='" & myval & "'"
        ElseIf rb1.SelectedValue = "Dept" And cbdept.Checked = True Then
            myval = Dept
            sqltext = "SELECT empmaster.Empname, empmaster.Empcode, empmaster.Sectioncode , empmaster.Departmentcode, OT_ElligibleStaff.Recno, OT_ElligibleStaff.Maxhrs FROM OT_ElligibleStaff INNER JOIN empmaster ON OT_ElligibleStaff.empcode = empmaster.empcode WHERE (OT_ElligibleStaff.Elligible = '-1') and empmaster.resigned='N'"
        ElseIf rb1.SelectedValue = "sect" And Cbsect.Checked = True Then
            myval = sect
            sqltext = "SELECT empmaster.Empname, empmaster.Empcode, empmaster.Sectioncode , empmaster.Departmentcode, OT_ElligibleStaff.Recno, OT_ElligibleStaff.Maxhrs FROM OT_ElligibleStaff INNER JOIN empmaster ON OT_ElligibleStaff.empcode = empmaster.empcode WHERE (OT_ElligibleStaff.Elligible = '-1') and empmaster.resigned='N'"

        End If


        'Bind Grid view

        MyGlobal.Con_Str()
        Dim ds1 As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds1, "OTRec")
        GridView1.DataSource = ds1
        GridView1.DataBind()
        con.Close()


    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub


    Public Sub Hodapproval(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim maxihrs As Decimal
        Dim tMAXHRS As Decimal
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim val As Integer
            Dim rno As String = DirectCast(GridView1.Rows(i).FindControl("label2"), Label).Text
            Dim maxhrs As TextBox = DirectCast(GridView1.Rows(i).FindControl("txthrs"), TextBox)
            Dim sect As String = GridView1.Rows(i).Cells(3).Text
            '''' Get Maxxhrs alloted for that section
            ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED FOR THAT SECTION
            Dim keyinhrs As Decimal
            If maxhrs.Text = "" Then
                keyinhrs = "0"
            Else
                keyinhrs = maxhrs.Text
            End If


            Dim STARTDATE, ENDDATE
            Dim Takenhrs
            Dim dsmc1, dsmh As DataSet
            Dim drmc1, drmh As DataRow
            dsmc1 = GetmAXoThRSbYSECT(sect)
            If dsmc1.Tables(0).Rows.Count <> 0 Then
                drmc1 = dsmc1.Tables(0).Rows(0)
                STARTDATE = Format(Convert.ToDateTime(drmc1("startdate")), "MM/dd/yy")
                ENDDATE = Format(Convert.ToDateTime(drmc1("enddate")), "MM/dd/yy")
                tMAXHRS = drmc1("maxhours")
            Else
                tMAXHRS = "0"
            End If
            maxihrs = maxihrs + keyinhrs
        Next

        If maxihrs > tMAXHRS Then
            LblMsg.Text = "Hours Key in is more than the budget alloted for the section"
            LblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim val As Integer
            Dim rno As String = DirectCast(GridView1.Rows(i).FindControl("label2"), Label).Text
            Dim maxhrs As TextBox = DirectCast(GridView1.Rows(i).FindControl("txthrs"), TextBox)

            MyGlobal.Open_Con()
            MyGlobal.Con_Str()

            Try
                DS = Open_OTeligible(Con, DAP, 2, "update OT_ElligibleStaff set maxhrs  = '" & maxhrs.Text & "' where recno = '" & rno & "'")
            Catch ex As Exception
                MessageBox(ex.Message)
            End Try

            MyGlobal.db_close()
        Next
        bindOTGrid()
        GridView1.DataBind()
    End Sub

    Private Sub Deptddl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Deptddl.SelectedIndexChanged
        bindOTGrid()
    End Sub

    Private Sub Secddl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Secddl.SelectedIndexChanged
        bindOTGrid()
    End Sub

    Function GetmAXoThRSbYSECT(ByVal myval As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select maxhours,startdate,enddate from tbl_maxotsetting where id = (select max(id) as id from tbl_maxotsetting where sect ='" & myval & "' and category='staff') and status ='A'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
End Class

