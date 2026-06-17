Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class OperatorKPI
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode
    Dim grade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (80)
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
        MyApp.GetfiscalYear()
        If Not IsPostBack Then
            LoadOptKPI()
        End If
    End Sub
    Function LoadOptKPI()
        DS = LoadDataInput()
        If DS.Tables(0).Rows.Count > 0 Then
            DR = DS.Tables(0).Rows(0)
            If Not DR("point1") Is System.DBNull.Value Then
                papril.Text = DR("point1").ToString
            Else
                papril.Text = ""
            End If
            If Not DR("point2") Is System.DBNull.Value Then
                pmay.Text = DR("point2").ToString
            Else
                pmay.Text = ""
            End If
            If Not DR("point3") Is System.DBNull.Value Then
                pjune.Text = DR("point3").ToString
            Else
                pjune.Text = ""
            End If
            If Not DR("point4") Is System.DBNull.Value Then
                pjuly.Text = DR("point4").ToString
            Else
                pjuly.Text = ""
            End If
            If Not DR("point5") Is System.DBNull.Value Then
                paug.Text = DR("point5").ToString
            Else
                paug.Text = ""
            End If
            If Not DR("point6") Is System.DBNull.Value Then
                psep.Text = DR("point6").ToString
            Else
                psep.Text = ""
            End If
         

            ''grade
            If Not DR("grade1") Is System.DBNull.Value Then
                Gapril.Text = DR("grade1").ToString
            Else
                Gapril.Text = ""
            End If
            If Not DR("grade2") Is System.DBNull.Value Then
                gmay.Text = DR("grade2").ToString
            Else
                gmay.Text = ""
            End If
            If Not DR("grade3") Is System.DBNull.Value Then
                Gjune.Text = DR("grade3").ToString
            Else
                Gjune.Text = ""
            End If
            If Not DR("grade4") Is System.DBNull.Value Then
                Gjuly.Text = DR("grade4").ToString
            Else
                Gjuly.Text = ""
            End If
            If Not DR("grade5") Is System.DBNull.Value Then
                Gaug.Text = DR("grade5").ToString
            Else
                Gaug.Text = ""
            End If
            If Not DR("grade6") Is System.DBNull.Value Then
                Gsep.Text = DR("grade6").ToString
            Else
                Gsep.Text = ""
            End If
         
            '' average
            If Not DR("avg1") Is System.DBNull.Value Then
                pavg1.Text = DR("avg1").ToString
            Else
                pavg1.Text = ""
            End If

        
            If Not DR("avg1grade") Is System.DBNull.Value Then
                gavg1.Text = DR("avg1grade").ToString
            Else
                gavg1.Text = ""
            End If
           
        Else
            papril.Text = ""
            pmay.Text = ""
            pjune.Text = ""
            pjuly.Text = ""
            paug.Text = ""
            psep.Text = ""
          

            Gapril.Text = ""
            gmay.Text = ""
            Gjune.Text = ""
            Gjuly.Text = ""
            Gaug.Text = ""
            Gsep.Text = ""
        

            pavg1.Text = ""

            gavg1.Text = ""


        End If
        Dim ds1 As DataSet
        Dim dr1 As DataRow
        ds1 = LoadDataInput1()
        If ds1.Tables(0).Rows.Count > 0 Then
            dr1 = ds1.Tables(0).Rows(0)
            If Not dr1("point7") Is System.DBNull.Value Then
                poct.Text = dr1("point7").ToString
            Else
                poct.Text = ""
            End If
            If Not dr1("point8") Is System.DBNull.Value Then
                pnov.Text = dr1("point8").ToString
            Else
                pnov.Text = ""
            End If
            If Not dr1("point9") Is System.DBNull.Value Then
                pdec.Text = dr1("point9").ToString
            Else
                pdec.Text = ""
            End If
            If Not dr1("point10") Is System.DBNull.Value Then
                pjan.Text = dr1("point10").ToString
            Else
                pjan.Text = ""
            End If

            If Not dr1("point11") Is System.DBNull.Value Then
                pfeb.Text = dr1("point11").ToString
            Else
                pfeb.Text = ""
            End If
            If Not dr1("point12") Is System.DBNull.Value Then
                pmar.Text = dr1("point12").ToString
            Else
                pmar.Text = ""
            End If

            If Not dr1("grade7") Is System.DBNull.Value Then
                Goct.Text = dr1("grade7").ToString
            Else
                Goct.Text = ""
            End If
            If Not dr1("grade8") Is System.DBNull.Value Then
                gnov.Text = dr1("grade8").ToString
            Else
                gnov.Text = ""
            End If
            If Not dr1("grade9") Is System.DBNull.Value Then
                gdec.Text = dr1("grade9").ToString
            Else
                gdec.Text = ""
            End If
            If Not dr1("grade10") Is System.DBNull.Value Then
                gjan.Text = dr1("grade10").ToString
            Else
                gjan.Text = ""
            End If

            If Not dr1("grade11") Is System.DBNull.Value Then
                gfeb.Text = dr1("grade11").ToString
            Else
                gfeb.Text = ""
            End If
            If Not dr1("grade12") Is System.DBNull.Value Then
                gmar.Text = dr1("grade12").ToString
            Else
                gmar.Text = ""
            End If


            If Not dr1("avg2") Is System.DBNull.Value Then
                pavg2.Text = dr1("avg2").ToString
            Else
                pavg2.Text = ""
            End If

            If Not dr1("avg2grade") Is System.DBNull.Value Then
                gavg2.Text = dr1("avg2grade").ToString
            Else
                gavg2.Text = ""
            End If
        Else
            poct.Text = ""
            pnov.Text = ""
            pdec.Text = ""
            pjan.Text = ""
            pfeb.Text = ""
            pmar.Text = ""
            Goct.Text = ""
            gnov.Text = ""
            gdec.Text = ""
            gjan.Text = ""
            gfeb.Text = ""
            gmar.Text = ""
            pavg2.Text = ""
            gavg2.Text = ""
        End If

    End Function
    Function LoadDataInput() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from performancedatainput where empcode='" & txtempcode.Text.Trim & "' and year1= '" & ddlyr.SelectedValue & "' and option1='1stHalf'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIlvl")
        con.Close()
        Return ds
    End Function
    Function LoadDataInput1() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from performancedatainput where empcode='" & txtempcode.Text.Trim & "' and year1= '" & ddlyr.SelectedValue & "' and option1='2ndHalf'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIlvl")
        con.Close()
        Return ds
    End Function
    Protected Sub txtempcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtempcode.TextChanged
        empcode = txtempcode.Text
        '   GetEmpVehino_opt(empcode)
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblename.Text = dr("empname").ToString
                lblsect.Text = dr("sectioncode").ToString
                lbldept.Text = dr("departmentcode").ToString
            Else
                ' MessageBox("EmployeeCode doesnot Exist/Employee is not Operator!!")
                lblmsg.Text = MyerrorMsg
                lblmsg.ForeColor = Drawing.Color.Red
                MessageBox("EmployeeCode doesnot Exist/Employee is not Operator!!")
                lblename.Text = ""
                lblsect.Text = ""
                lbldept.Text = ""
                Exit Sub
            End If
        End If

        papril.Text = ""
        pmay.text = ""
        pjune.text = ""
        pjuly.text = ""
        paug.Text = ""
        psep.Text = ""
        poct.text = ""
        pnov.text = ""
        pdec.Text = ""
        pjan.Text = ""
        pfeb.Text = ""
        pmar.Text = ""
        pavg1.Text = ""
        pavg2.Text = ""
        gavg1.Text = ""
        gavg2.Text = ""
        LoadOptKPI()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            Call MyGlobal.dbSp_open("HRMIS_CTQ_OPERATOR_INSERT_new")
            Cmd.Parameters.AddWithValue("@empcode", txtempcode.Text.Trim)
            Cmd.Parameters.AddWithValue("@year1", ddlyr.SelectedValue)
            Cmd.Parameters.AddWithValue("@option1", ddlmon.SelectedValue)
            Cmd.Parameters.AddWithValue("@department", lbldept.Text)
            Cmd.Parameters.AddWithValue("@section1 ", lblsect.Text)

            Cmd.Parameters.AddWithValue("@point1", papril.Text.Trim)
            Cmd.Parameters.AddWithValue("@point2", pmay.Text.Trim)
            Cmd.Parameters.AddWithValue("@point3", pjune.Text.Trim)
            Cmd.Parameters.AddWithValue("@point4 ", pjuly.Text.Trim)
            Cmd.Parameters.AddWithValue("@point5", paug.Text.Trim)
            Cmd.Parameters.AddWithValue("@point6", psep.Text.Trim)
            Cmd.Parameters.AddWithValue("@point7", poct.Text.Trim)
            Cmd.Parameters.AddWithValue("@point8 ", pnov.Text.Trim)
            Cmd.Parameters.AddWithValue("@point9", pdec.Text.Trim)
            Cmd.Parameters.AddWithValue("@point10", pjan.Text.Trim)
            Cmd.Parameters.AddWithValue("@point11", pfeb.Text.Trim)
            Cmd.Parameters.AddWithValue("@point12", pmar.Text.Trim)

            Cmd.Parameters.AddWithValue("@grade1", Gapril.Text.Trim)
            Cmd.Parameters.AddWithValue("@grade2", gmay.Text.Trim)
            Cmd.Parameters.AddWithValue("@grade3", Gjune.Text.Trim)
            Cmd.Parameters.AddWithValue("@grade4 ", Gjuly.Text.Trim)
            Cmd.Parameters.AddWithValue("@grade5", Gaug.Text.Trim)
            Cmd.Parameters.AddWithValue("@grade6", Gsep.Text.Trim)
            Cmd.Parameters.AddWithValue("@grade7", Goct.Text.Trim)
            Cmd.Parameters.AddWithValue("@grade8 ", gnov.Text.Trim)
            Cmd.Parameters.AddWithValue("@grade9", gdec.Text.Trim)
            Cmd.Parameters.AddWithValue("@grade10", gjan.Text.Trim)
            Cmd.Parameters.AddWithValue("@grade11", gfeb.Text.Trim)
            Cmd.Parameters.AddWithValue("@grade12", gmar.Text.Trim)

            Cmd.Parameters.AddWithValue("@avg1", pavg1.Text.Trim)
            Cmd.Parameters.AddWithValue("@avg2", pavg2.Text.Trim)
            Cmd.Parameters.AddWithValue("@avg1grade", gavg1.Text.Trim)
            Cmd.Parameters.AddWithValue("@avg2grade", gavg2.Text.Trim)

            Cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Protected Sub calculateTotal1(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = papril.Text.Trim
        totval = Double.Parse(total)
        Gapril.Text = getgrade(totval)
    End Sub
    Protected Sub calculateTotal2(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = pmay.Text.Trim
        totval = Double.Parse(total)
        gmay.Text = getgrade(totval)
    End Sub
    Protected Sub calculateTotal3(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = pjune.Text.Trim
        totval = Double.Parse(total)
        Gjune.Text = getgrade(totval)
    End Sub
    Protected Sub calculateTotal4(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = pjuly.Text.Trim
        totval = Double.Parse(total)
        Gjuly.Text = getgrade(totval)
    End Sub
    Protected Sub calculateTotal5(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = paug.Text.Trim
        totval = Double.Parse(total)
        Gaug.Text = getgrade(totval)
    End Sub
    Protected Sub calculateTotal6(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = psep.Text.Trim
        totval = Double.Parse(total)
        Gsep.Text = getgrade(totval)
    End Sub
    Protected Sub calculateTotal7(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = poct.Text.Trim
        totval = Double.Parse(total)
        Goct.Text = getgrade1(totval)
    End Sub
    Protected Sub calculateTotal8(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = pnov.Text.Trim
        totval = Double.Parse(total)
        gnov.Text = getgrade1(totval)
    End Sub
    Protected Sub calculateTotal9(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = pdec.Text.Trim
        totval = Double.Parse(total)
        gdec.Text = getgrade1(totval)
    End Sub
    Protected Sub calculateTotal10(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = pjan.Text.Trim
        totval = Double.Parse(total)
        gjan.Text = getgrade1(totval)
    End Sub
    Protected Sub calculateTotal11(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = pfeb.Text.Trim
        totval = Double.Parse(total)
        gfeb.Text = getgrade1(totval)
    End Sub
    Protected Sub calculateTotal12(ByVal Sender As Object, ByVal e As System.EventArgs)
        Dim totval
        Dim total = pmar.Text.Trim
        totval = Double.Parse(total)
        gmar.Text = getgrade1(totval)
    End Sub
    Function getgrade(ByVal totval As Decimal)

        If totval >= 100 Then
            grade = "A"
        ElseIf totval <= 0 Then
            grade = "E"
        ElseIf totval > 0 And totval < 51 Then
            grade = "E"
        ElseIf totval > 50 And totval < 61 Then
            grade = "D"
        ElseIf totval > 60 And totval < 71 Then
            grade = "C"
        ElseIf totval > 70 And totval < 86 Then
            grade = "B"
        ElseIf totval > 85 And totval < 101 Then
            grade = "A"
        End If

        
        If papril.Text = "" Then
            papril.Text = 0
        End If

        If pmay.Text = "" Then
            pmay.Text = 0
        End If

        If pjune.Text = "" Then
            pjune.Text = 0
        End If

        If pjuly.Text = "" Then
            pjuly.Text = 0
        End If

        If paug.Text = "" Then
            paug.Text = 0
        End If

        If psep.Text = "" Then
            psep.Text = 0
        End If

        Dim total As Double
        total = Double.Parse(papril.Text) + Double.Parse(pmay.Text) + Double.Parse(pjune.Text) + Double.Parse(pjuly.Text) + Double.Parse(paug.Text) + Double.Parse(psep.Text)
        total = total / 6
        pavg1.Text = Math.Round(Double.Parse(total), 1)

        If pavg1.Text >= 100 Then
            gavg1.Text = "A"
        ElseIf pavg1.Text <= 0 Then
            gavg1.Text = "E"
        ElseIf pavg1.Text > 0 And pavg1.Text < 51 Then
            gavg1.Text = "E"
        ElseIf pavg1.Text > 50 And pavg1.Text < 61 Then
            gavg1.Text = "D"
        ElseIf pavg1.Text > 60 And pavg1.Text < 71 Then
            gavg1.Text = "C"
        ElseIf pavg1.Text > 70 And pavg1.Text < 86 Then
            gavg1.Text = "B"
        ElseIf pavg1.Text > 85 And pavg1.Text < 101 Then
            gavg1.Text = "A"
        End If
        Return grade

    End Function
    Function getgrade1(ByVal totval As Decimal)

        If totval >= 100 Then
            grade = "A"
        ElseIf totval <= 0 Then
            grade = "E"
        ElseIf totval > 0 And totval < 51 Then
            grade = "E"
        ElseIf totval > 50 And totval < 61 Then
            grade = "D"
        ElseIf totval > 60 And totval < 71 Then
            grade = "C"
        ElseIf totval > 70 And totval < 86 Then
            grade = "B"
        ElseIf totval > 85 And totval < 101 Then
            grade = "A"
        End If


        If poct.Text = "" Then
            poct.Text = 0
        End If

        If pnov.Text = "" Then
            pnov.Text = 0
        End If

        If pdec.Text = "" Then
            pdec.Text = 0
        End If

        If pjan.Text = "" Then
            pjan.Text = 0
        End If

        If pfeb.Text = "" Then
            pfeb.Text = 0
        End If

        If pmar.Text = "" Then
            pmar.Text = 0
        End If

        Dim total As Double
        total = Double.Parse(poct.Text) + Double.Parse(pnov.Text) + Double.Parse(pdec.Text) + Double.Parse(pjan.Text) + Double.Parse(pfeb.Text) + Double.Parse(pmar.Text)
        total = total / 6
        pavg2.Text = Math.Round(Double.Parse(total), 1)

        If pavg2.Text >= 100 Then
            gavg2.Text = "A"
        ElseIf pavg2.Text <= 0 Then
            gavg2.Text = "E"
        ElseIf pavg2.Text > 0 And pavg2.Text < 51 Then
            gavg2.Text = "E"
        ElseIf pavg2.Text > 50 And pavg2.Text < 61 Then
            gavg2.Text = "D"
        ElseIf pavg2.Text > 60 And pavg2.Text < 71 Then
            gavg2.Text = "C"
        ElseIf pavg2.Text > 70 And pavg2.Text < 86 Then
            gavg2.Text = "B"
        ElseIf pavg2.Text > 85 And pavg2.Text < 101 Then
            gavg2.Text = "A"
        End If
        Return grade

    End Function

    Protected Sub ddlmon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlmon.SelectedIndexChanged
        Dim options
        options = ddlmon.SelectedValue.Trim
        If options = "1stHalf" Then

            papril.Enabled = True
            pmay.Enabled = True
            pjune.Enabled = True
            pjuly.Enabled = True
            paug.Enabled = True
            psep.Enabled = True
            poct.Enabled = False
            pnov.Enabled = False
            pdec.Enabled = False
            pjan.Enabled = False
            pfeb.Enabled = False
            pmar.Enabled = False

        ElseIf options = "2ndHalf" Then

            papril.Enabled = False
            pmay.Enabled = False
            pjune.Enabled = False
            pjuly.Enabled = False
            paug.Enabled = False
            psep.Enabled = False
            poct.Enabled = True
            pnov.Enabled = True
            pdec.Enabled = True
            pjan.Enabled = True
            pfeb.Enabled = True
            pmar.Enabled = True

        End If
        LoadOptKPI()
    End Sub

    Protected Sub ddlyr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlyr.SelectedIndexChanged
        LoadOptKPI()
    End Sub
End Class