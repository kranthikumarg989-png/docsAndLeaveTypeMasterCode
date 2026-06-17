Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class ApptForIndonesian
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
            MyScreenId = (196)
            If GlobalDsRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDsRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
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
        ppdetails()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Private Sub Appdetails()
        Dim doj

        Dim dr1 As DataRow
        ecode = empno.Text
        Getcedata(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                empname.Text = dr1("empname").ToString
                dept.Text = dr1("departmentcode").ToString
                desig.Text = dr1("designation").ToString
                sect.Text = dr1("sectioncode").ToString
                addr1.Text = dr1("address1").ToString
                addr2.Text = dr1("address2").ToString
                addr3.Text = dr1("address3").ToString
                doj = Format(Convert.ToDateTime(dr1("dateofjoin")), "dd/MM/yy")
                Dim dob = Format(Convert.ToDateTime(dr1("dateofbirth")), "dd/MM/yy")
                txtBirthDate.Text = Format(Convert.ToDateTime(dr1("dateofbirth")), "MM/dd/yyyy")
                Session("deptname") = dr1("departmentname").ToString
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
            End If
        End If

        Dim CurrentDate As DateTime = DateTime.Today()

        Dim BirthDate As DateTime
        ' Makes sure the text input is converted to a Date:
        BirthDate = txtBirthDate.Text

        Dim diff As TimeSpan = CurrentDate.Subtract(BirthDate)
        '    'Cint' Converts the output to an Integer (no decimal places)
        LblShowAge.Text = CInt(diff.Days / 365)

        Session("dept") = dept.Text
        Session("desig") = desig.Text
        Session("sect") = sect.Text
        Session("add1") = addr1.Text
        Session("add2") = addr2.Text
        Session("add3") = addr3.Text
        Session("age") = LblShowAge.Text
        Session("doj") = doj

        Session("ename") = empname.Text

    End Sub
    Private Sub ppdetails()

        Dim drs As DataRow
        ecode = empno.Text
        Getppdata(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                drs = dsdata.Tables(0).Rows(0)
                ppno.Text = drs("passportno").ToString

            Else
                MessageBox("Employee Passport Details doesnot Exist!!")
            End If
        End If
        Session("pp") = ppno.Text
    End Sub

    Private Sub chkval1()

        ecode = empno.Text
        getchkval1(ecode)

    End Sub

    Protected Sub Saveaptindo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Saveaptindo.Click
        Dim ft As String
        ft = DateTime.Now.ToString("dd/MM/yyyy")

        Session("letdt") = ft

        Dim xxd1, xxd
        xxd1 = ft
        Dim strdate5() As String = xxd1.Split("/"c)
        xxd1 = strdate5(0) & strdate5(1)

        xxd = xxd1 & "/" & empno.Text

        Dim refno = xxd

        Session("refno") = refno

        chkval1()
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    MyGlobal.Con_Str()
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update emp_modified set letterdate='" & ft & "' where empcode='" & empno.Text & "'", conn)
                    Cmd.ExecuteNonQuery()
                    labelmsg.Text = "Details updated"
                Catch ex As SqlException
                    labelmsg.Text = ex.Message
                    labelmsg.ForeColor = Drawing.Color.Green
                End Try
            Else
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    MyGlobal.Con_Str()
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("insert into emp_modified (empcode,letterdate,appointmentletter) values('" & empno.Text & "','" & ft & "','Y')", conn)
                    Cmd.ExecuteNonQuery()
                    labelmsg.Text = "Details Added"
                Catch ex As SqlException
                    labelmsg.Text = ex.Message
                    labelmsg.ForeColor = Drawing.Color.Green
                End Try
            End If
        End If

        Session("ecode") = empno.Text.Trim

        MyGlobal.db_close()

        Response.Redirect("AptLetIndoRpt.aspx")
    End Sub
End Class