Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class Increment
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim ecode
    Dim appno


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (209)
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
        'Session("empcode") = "014543"
        labelmsg.Text = ""
    End Sub

    Protected Sub empno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empno.TextChanged
        Appdetails()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Private Sub Appdetails()

        Dim dr1 As DataRow
        ecode = empno.Text
        Getcedata(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                name.Text = dr1("empname").ToString
                dept.Text = dr1("departmentcode").ToString
                desig.Text = dr1("designation").ToString

                Session("empname") = name.Text
                Session("deptcode") = dept.Text
                Session("desig") = desig.Text
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
            End If
        End If
    End Sub
   

    Protected Sub Incsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Incsave.Click

        Dim ft As String
        ft = DateTime.Now.ToString("dd/MM/yyyy")

        Dim ft1 As String
        ft1 = DateTime.Now.ToString("MM/dd/yyyy")


        Dim td1 As String
        td1 = effdt.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("effdt") = td

        Dim ad1 As String
        Dim ad As String

        ad1 = ltdt.Text.Trim
        Dim strdate() As String = ad1.Split("/"c)
        ad1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        ad = CDate(ad1)
        Session("letdt") = ad


        Dim dki
        dki = DateTime.Now


        Session("today") = ft

        Dim xxd1 As String
        Dim xxd As String
        Dim refno

        xxd1 = dki
        Dim strdate5() As String = xxd1.Split("/"c)
        xxd1 = strdate5(1) & strdate5(0)

        xxd = xxd1 & "/" & empno.Text


        If pall.Text = "" Or pall.Text = "0" Then
            Session("pall") = ""
            Session("posallow") = ""
            Session("curr") = ""
        Else
            Session("pall") = pall.Text
            Session("posallow") = "Position Allowance"
            Session("curr") = "RM"
        End If

        If pfpall.Text = "" Or pfpall.Text = "0" Then
            Session("pfpall") = ""
            Session("pfpallow") = ""
            Session("curr1") = ""
        Else
            Session("pfpall") = pfpall.Text
            Session("pfpallow") = "PFP Allowance"
            Session("curr1") = "RM"
        End If


        refno = xxd
        Session("refno") = refno
        Session("bsa") = bsa.Text
        Session("splinc") = splinc.Text
        Session("nbsa") = nbsa.Text
        'Session("pall") = pall.Text
        'Session("pfpall") = pfpall.Text
        Session("empcode") = empno.Text


        getchkval13(ecode, ft1)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    Cmd = New SqlCommand("update hr_increment set cbasicsalary = '" & bsa.Text & "', incamount = '" & splinc.Text & "', nbasicsalary = '" & nbsa.Text & "', poallowance = '" & pall.Text & "', pfpallowance = '" & pfpall.Text & "', vdate = '" & ft & "',edate = '" & td & "' where empcode='" & empno.Text & "'", con)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    labelmsg.Text = ex.Message
                    labelmsg.ForeColor = Drawing.Color.Green
                End Try

            Else

                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    Cmd = New SqlCommand("insert into hr_increment (empcode,cbasicsalary,incamount,nbasicsalary,poallowance,pfpallowance,vdate,edate) values('" & empno.Text & "','" & bsa.Text & "','" & splinc.Text & "','" & nbsa.Text & "','" & pall.Text & "','" & pfpall.Text & "','" & ft & "','" & td & "')", con)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    labelmsg.Text = ex.Message
                    labelmsg.ForeColor = Drawing.Color.Green
                End Try
            End If
        End If

        Response.Redirect("IncrementLetter.aspx")
    End Sub

End Class