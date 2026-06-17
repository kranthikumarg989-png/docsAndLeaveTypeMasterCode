Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class OperatorAppraisalViewaspx
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

   
        Dim rno
        If Session("optempapp") <> "" Then
            rno = Session("optempapp")
        End If
        GetAppraisalData(rno)

    End Sub
    Function GetEmp(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from app_operatorappraisal where rno = '" & passno & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "leaveabs")
        con.Close()
        Return ds
    End Function
    Private Sub GetAppraisalData(ByVal rno As String)

        '''' Get written 
        Dim dsw12 As DataSet
        Dim dra1 As DataRow
        dsw12 = GetEMp(rno)
        If dsw12.Tables(0).Rows.Count <> 0 Then
            dra1 = dsw12.Tables(0).Rows(0)
            lblemp.Text = dra1("empcode").ToString
            If Not dra1("periodofevoluation") Is System.DBNull.Value Then
                ddlhalf.SelectedValue = dra1("periodofevoluation")
            End If
            lblcomment.Text = dra1("remarks").ToString
            '   rddh.SelectedValue = dra1("senddh").ToString

            DirectCast(GrdOpt.Rows(0).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("job").ToString
            DirectCast(GrdOpt.Rows(1).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("quality").ToString
            DirectCast(GrdOpt.Rows(2).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("quantity").ToString
            DirectCast(GrdOpt.Rows(3).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("coattitude").ToString
            DirectCast(GrdOpt.Rows(4).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("coworkersrelation").ToString
            DirectCast(GrdOpt.Rows(5).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("companyloyalty").ToString
            DirectCast(GrdOpt.Rows(6).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("attendancepunctuality").ToString
            DirectCast(GrdOpt.Rows(7).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("depend").ToString
            DirectCast(GrdOpt.Rows(8).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("safetyhabit").ToString
            DirectCast(GrdOpt.Rows(9).FindControl("rdprating"), RadioButtonList).SelectedValue = dra1("ability").ToString
            DirectCast(GrdOpt.FooterRow.FindControl("lbltotal"), Label).Text = dra1("total").ToString
            DirectCast(GrdOpt.FooterRow.FindControl("lblgrade"), Label).Text = dra1("grade").ToString


            Label1.Text = Format(Convert.ToDateTime(dra1("dateofappraisal")), "dd/MM/yy")
            lblempcode.Text = dra1("ratedbyempno").ToString
            Dim contract
            Dim confirm
            Dim probation

            If Not dra1("contract") Is System.DBNull.Value Then
                contract = dra1("contract").ToString
            Else
                contract = ""
            End If
            If Not dra1("confirmd") Is System.DBNull.Value Then
                confirm = dra1("confirmd").ToString
            Else
                confirm = ""
            End If
            If Not dra1("probation") Is System.DBNull.Value Then
                probation = dra1("probation").ToString
            Else
                probation = ""
            End If

            If contract = "Y" Then
                rdconfirm.SelectedValue = "N"
            ElseIf confirm = "Y" Then
                rdconfirm.SelectedValue = "C"
            ElseIf probation = "Y" Then
                rdconfirm.SelectedValue = "E"
            End If
        End If

        empcode = lblemp.Text
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblename.Text = dr("empname").ToString
                lblsect.Text = dr("sectioncode").ToString
                lbldept.Text = dr("departmentcode").ToString
                '  lbldesig.Text = dr("designation").ToString
                lblstatus.Text = dr("emptype").ToString
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
                Exit Sub
            End If
        End If
        '''' Get Key skills of employee
        GetRevno(empcode)
        Dim revno, recno
        revno = posid - 1
        Dim i

        ''''''''''''''''''''''''''''''''''' Find emp history 
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Dim dsmc As DataSet
        Dim drmc As DataRow
        dsmc = GetMedical(lblemp.Text.Trim)
        If dsmc.Tables(0).Rows.Count <> 0 Then
            drmc = dsmc.Tables(0).Rows(0)
            lblmedical.Text = drmc("mc").ToString
        Else
            lblmedical.Text = 0
        End If

        ''''''''''''''''''''''''''''' GET ABSENTISM 
        Dim dsabs As DataSet
        Dim drabs As DataRow
        Dim abs, days
        Dim from As Date
        Dim tod As Date
        Dim l

        dsabs = GetAbscent(lblemp.Text.Trim)
        If dsabs.Tables(0).Rows.Count <> 0 Then
            l = dsabs.Tables(0).Rows.Count
            For i = 0 To l - 1
                drabs = dsabs.Tables(0).Rows(i)
                from = drabs("abfromdate")
                tod = drabs("abtodate")
                abs = from.Subtract(tod).Days
                If abs = 0 Then
                    abs = 1
                End If
                days = days + abs
            Next
            lblabs.Text = abs
        Else
            lblabs.Text = 0
        End If

        '''''''''''''''''''''''''''''' GET LATE
        Dim dslate As DataSet
        Dim drlate As DataRow
        dslate = GetLAte(lblemp.Text.Trim)
        If dslate.Tables(0).Rows.Count <> 0 Then
            drlate = dslate.Tables(0).Rows(0)
            lbllate.Text = drlate("late").ToString
        Else
            lbllate.Text = 0
        End If

        ''''''''''' GET COUNSELLING
        Dim dscou As DataSet
        Dim drcou As DataRow
        dscou = GetcOUNSELLING(lblemp.Text.Trim)
        If dscou.Tables(0).Rows.Count <> 0 Then
            drcou = dscou.Tables(0).Rows(0)
            lblcoun.Text = drcou("expr2").ToString
        Else
            lblcoun.Text = 0
        End If

        '''' Get Explanation
        Dim dsexp As DataSet
        Dim drexp As DataRow
        dsexp = GetExplanation(lblemp.Text.Trim)
        If dsexp.Tables(0).Rows.Count <> 0 Then
            drexp = dsexp.Tables(0).Rows(0)
            lblexpl.Text = drexp("expr2").ToString
        Else
            lblexpl.Text = 0
        End If
        '''' Get verbal
        Dim dsv As DataSet
        Dim drv As DataRow
        dsv = Getverbal(lblemp.Text.Trim)
        If dsv.Tables(0).Rows.Count <> 0 Then
            drv = dsv.Tables(0).Rows(0)
            lblvw.Text = drv("expr2").ToString
        Else
            lblvw.Text = 0
        End If

        '''' Get written 
        Dim dsw As DataSet
        Dim drw As DataRow
        dsw = Getwritten(lblemp.Text.Trim)
        If dsw.Tables(0).Rows.Count <> 0 Then
            drw = dsw.Tables(0).Rows(0)
            lblww.Text = drw("expr2").ToString
        Else
            lblww.Text = 0
        End If

        '''' Get first
        Dim dsf As DataSet
        Dim drf As DataRow
        dsf = Getfirst(lblemp.Text.Trim)
        If dsf.Tables(0).Rows.Count <> 0 Then
            drf = dsf.Tables(0).Rows(0)
            lblfw.Text = drf("expr2").ToString
        Else
            lblfw.Text = 0
        End If

        '''' Get final
        Dim dsfi As DataSet
        Dim drfi As DataRow
        dsfi = Getfinal(lblemp.Text.Trim)
        If dsfi.Tables(0).Rows.Count <> 0 Then
            drfi = dsfi.Tables(0).Rows(0)
            lblfinw.Text = drfi("expr2").ToString
        Else
            lblfinw.Text = 0
        End If

        '''' Get suspension
        Dim dsfs As DataSet
        Dim drfs As DataRow
        dsfs = Getsuspension(lblemp.Text.Trim)
        If dsfs.Tables(0).Rows.Count <> 0 Then
            drfs = dsfs.Tables(0).Rows(0)
            lblsus.Text = drfs("expr2").ToString
        Else
            lblsus.Text = 0
        End If

        '''' Get show cause
        Dim dssc As DataSet
        Dim drsc As DataRow
        dssc = Getshowcase(lblemp.Text.Trim)
        If dssc.Tables(0).Rows.Count <> 0 Then
            drsc = dssc.Tables(0).Rows(0)
            lblsc.Text = drsc("expr2").ToString
        Else
            lblsc.Text = 0
        End If
        '''' Get Misconduct reports
        Dim dsr As DataSet
        Dim drr As DataRow
        dsr = GetMisRpt(lblemp.Text.Trim)
        If dsr.Tables(0).Rows.Count <> 0 Then
            drr = dsr.Tables(0).Rows(0)
            lblrpt.Text = drr("expr2").ToString
        Else
            lblrpt.Text = 0
        End If

        ''''' check appraisal done by self 

        'Dim cmd1 As New SqlCommand
        'Dim dra, dra1 As SqlDataReader
        'Dim da As SqlDataAdapter
        'Dim fd
        'MyGlobal.Con_Str()
        'Dim con As New SqlConnection(constr)
        'con.Open()
        'cmd1 = New SqlCommand("select max(CONVERT(varchar(10), dateofappraisal, 101)) as dt from app_operatorappraisal where empcode = '" & lblemp.Text & "' and status = 'AS'", con)
        'dra = cmd1.ExecuteReader()
        ''  Label1.Text = Day(Date.Now) & "/" & Month(Date.Now) & "/" & Year(Date.Now)
        'While (dra.Read())
        '    fd = dra("dt").ToString()
        'End While

        'con.Close()
        'cmd1.Dispose()

        'MyGlobal.Con_Str()

        'con.Open()
        'cmd1 = New SqlCommand("select * from app_operatorappraisal where empcode = '" & lblemp.Text & "' and dateofappraisal = '" & fd & "'", con)
        'dra1 = cmd1.ExecuteReader()
        'Dim len
        '  Label1.Text = Day(Date.Now) & "/" & Month(Date.Now) & "/" & Year(Date.Now)
       


    End Sub

    Protected Sub txtbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbutton.Click
       

        If rdconfirm.SelectedValue = "" Then
            MessageBox("Please Select any Remarks/Recommendations")
            rdconfirm.Focus()
            Exit Sub
        End If

        If txtdh.Text = "" Then
            MessageBox("Please Key in your comments")
            txtdh.Focus()
            Exit Sub
        End If

        Dim probation, confirm, contract, probmth

        probation = "N"
        confirm = "N"
        contract = "N"
        probmth = "0"


        If rdconfirm.SelectedValue = "C" Then
            confirm = "Y"
        ElseIf rdconfirm.SelectedValue = "E" Then
            probation = "Y"
            probmth = "1"
        ElseIf rdconfirm.SelectedValue = "EC" Then
            contract = "Y"
        End If



        Dim fd1 As String
        fd1 = Label1.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Dim status

        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            Call MyGlobal.dbSp_open("Hrmis_insOptappraisal_dh")

            Cmd.Parameters.AddWithValue("@empcode", lblemp.Text.Trim)
            Cmd.Parameters.AddWithValue("@purposeofappraisal", "1/2Year")
            Cmd.Parameters.AddWithValue("@status", "AD")
            Cmd.Parameters.AddWithValue("@periodofevoluation", ddlhalf.SelectedValue)

            Cmd.Parameters.AddWithValue("@contract", contract)
            Cmd.Parameters.AddWithValue("@confirmd", confirm)
            Cmd.Parameters.AddWithValue("@probation", probation)
            Cmd.Parameters.AddWithValue("@probmonths", probmth)
            Cmd.Parameters.AddWithValue("@periodofmonths", probmth)
            ' Cmd.Parameters.AddWithValue("@department", )
            Cmd.Parameters.AddWithValue("@remarks", lblcomment.Text)
            Cmd.Parameters.AddWithValue("@reviewby", Session("empcode"))
            Cmd.Parameters.AddWithValue("@remarksdh", txtdh.Text)



            Dim job = DirectCast(GrdOpt.Rows(0).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim quality = DirectCast(GrdOpt.Rows(1).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim quantity = DirectCast(GrdOpt.Rows(2).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim coattitude = DirectCast(GrdOpt.Rows(3).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim coworkersrelation = DirectCast(GrdOpt.Rows(4).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim companyloyalty = DirectCast(GrdOpt.Rows(5).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim attendancepunctuality = DirectCast(GrdOpt.Rows(6).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim depend = DirectCast(GrdOpt.Rows(7).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim safetyhabit = DirectCast(GrdOpt.Rows(8).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim ability = DirectCast(GrdOpt.Rows(9).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim total = DirectCast(GrdOpt.FooterRow.FindControl("lbltotal"), Label).Text
            Dim grade = DirectCast(GrdOpt.FooterRow.FindControl("lblgrade"), Label).Text

            Cmd.Parameters.AddWithValue("@job", job)
            Cmd.Parameters.AddWithValue("@quality", quality)
            Cmd.Parameters.AddWithValue("@quantity", quantity)
            Cmd.Parameters.AddWithValue("@coattitude", coattitude)

            Cmd.Parameters.AddWithValue("@coworkersrelation", coworkersrelation)
            Cmd.Parameters.AddWithValue("@companyloyalty", companyloyalty)
            Cmd.Parameters.AddWithValue("@attendancepunctuality", attendancepunctuality)
            Cmd.Parameters.AddWithValue("@depend", depend)
            Cmd.Parameters.AddWithValue("@safetyhabit", safetyhabit)
            Cmd.Parameters.AddWithValue("@ability", ability)
            Cmd.Parameters.AddWithValue("@total", total)
            Cmd.Parameters.AddWithValue("@grade", grade)

            Cmd.Parameters.AddWithValue("@dateofappraisal", fd)

            Cmd.ExecuteNonQuery()
            MessageBox("Appraisal Saved Successfully")

            Call MyGlobal.dbSp_open("insert_appraisal_hod_opt")
            Cmd.Parameters.AddWithValue("@empcode", lblemp.Text.Trim)
            Cmd.Parameters.AddWithValue("@appraisal", "Y")
            Cmd.Parameters.AddWithValue("@status", "AD")

            Cmd.ExecuteNonQuery()

            Session("optempapp") = ""
            Response.Redirect("OptAppraisalDH.aspx")

        Catch ex As Exception
            MessageBox(ex.Message)
            Exit Sub
        End Try

    End Sub
    Function GetappCharactersetting(ByVal sqltext As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "character")
        con.Close()
        Return ds
    End Function
    Function GetMedical(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select leavetype,sum(grantedleave) as mc from leaveform where (leavetype = 'Medical') and empno ='" & passno & "' and (status='APPROVED') and (fromdate between '" & _fisyrStart & "' and '" & _fisyrEnd & "') group by leavetype ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetAbscent(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from leaveabsentism where (leavetype = 'Absent') and empcode ='" & passno & "' and (abfromdate between '" & _fisyrStart & "' and '" & _fisyrEnd & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "leaveabs")
        con.Close()
        Return ds
    End Function
    Function GetLAte(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select count(*) as late from leaveabsentism where (leavetype = 'Latecoming') and empcode ='" & passno & "' and (latedate between '" & _fisyrStart & "' and '" & _fisyrEnd & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "late")
        con.Close()
        Return ds
    End Function
    Function GetcOUNSELLING(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_employeecounseling GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "counseling")
        con.Close()
        Return ds
    End Function
    Function GetExplanation(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM  er_explanation GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "Explanation")
        con.Close()
        Return ds
    End Function
    Function Getverbal(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM  er_verbalwarning GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "varbal")
        con.Close()
        Return ds
    End Function
    Function Getwritten(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM  er_writtenwarning GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "written")
        con.Close()
        Return ds
    End Function
    Function Getfirst(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_misfirstwarning GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "first")
        con.Close()
        Return ds
    End Function
    Function Getfinal(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_misfinalwarning  GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "final")
        con.Close()
        Return ds
    End Function
    Function Getsuspension(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_suspension GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "suspension")
        con.Close()
        Return ds
    End Function
    Function Getshowcase(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_showcauseletter GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "showcase")
        con.Close()
        Return ds
    End Function
    Function GetMisRpt(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT COUNT(*) AS Expr2, empcode AS Expr1 FROM er_misconductreport GROUP BY empcode HAVING (empcode ='" & passno & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "report")
        con.Close()
        Return ds
    End Function
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub chkDynamic_CheckedChanged(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim points
        Dim total As Double
        Dim totpts As Double
        Dim totgrade As Double
        Dim tgrade As Double
        Dim grades
        '  Dim RB As RadioButtonList = CType(Sender, RadioButtonList)
        For i As Integer = 0 To GrdOpt.Rows.Count - 1
            Dim passno As String = GrdOpt.Rows(i).Cells(0).Text
            Dim grade As String = DirectCast(GrdOpt.Rows(i).FindControl("rdprating"), RadioButtonList).SelectedValue
            Dim grade1 As RadioButtonList = DirectCast(GrdOpt.Rows(i).FindControl("rdprating"), RadioButtonList)


            Dim x = grade1.SelectedValue
            If (x = "") Then
                x = 0
            End If
            tgrade = Double.Parse(x)
            totgrade = Double.Parse(totgrade)
            totgrade += tgrade

            '' just for focus
            DirectCast(GrdOpt.Rows(i).FindControl("rdprating"), RadioButtonList).Focus()
        Next

        Dim pts As Integer
        pts = totgrade
        If pts >= 50 And pts <= 45 Then
            grades = "A"
        ElseIf pts >= 40 And pts <= 44 Then
            grades = "B"
        ElseIf pts >= 35 And pts <= 39 Then
            grades = "C"
        ElseIf pts >= 30 And pts <= 34 Then
            grades = "D"
        ElseIf pts <= 29 Then
            grades = "E"
        End If
        DirectCast(GrdOpt.FooterRow.FindControl("Lbltotal"), Label).Text = totgrade
        DirectCast(GrdOpt.FooterRow.FindControl("Lblgrade"), Label).Text = grades
        'calculateGrade(totgrade)
    End Sub

End Class