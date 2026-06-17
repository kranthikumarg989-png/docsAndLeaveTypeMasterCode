Imports System.Data
Imports System.Web.Security
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class BtForm2
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (47)
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
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Public Sub UpdateCustVisit(ByVal sender As Object, ByVal e As EventArgs)

        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim ih, imin, iam, oh, omin, oam
            Dim chkin As String
            Dim chkout As String
            Dim fd2 As Date
            Dim st2 As Date
            Dim sf1 As String
            Dim st1 As String
            Dim fd1 As String
            Dim fd As Date
            Dim td1 As String
            Dim td As Date

            Dim stay = DirectCast(GridView1.Rows(i).FindControl("rb1"), RadioButtonList).SelectedValue

            fd1 = DirectCast(GridView1.Rows(i).FindControl("txtfrom"), TextBox).Text
            td1 = DirectCast(GridView1.Rows(i).FindControl("txtto"), TextBox).Text
            ''''''''''''CHECK WHETHER THE DATE IS ENTERED

            If fd1.Trim <> "" And td1.Trim <> "" Then

                Dim strdate() As String = fd1.Split("/"c)
                fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
                '''' CHECK WHETHER THE DATE IS VALID
                If IsDate(fd1) = True Then
                    fd = CDate(fd1)
                Else
                    lblmsg.Text = "Invald date"
                    GridView1.Rows(i).FindControl("txtfrom").Focus()
                    Exit Sub
                End If


                Dim strdate2() As String = td1.Split("/"c)
                td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)
                If IsDate(td1) = True Then
                    td = CDate(td1)
                Else
                    lblmsg.Text = "Invald date"
                    GridView1.Rows(i).FindControl("txtto").Focus()
                    Exit Sub
                End If
            End If

            Dim purpose = DirectCast(GridView1.Rows(i).FindControl("txtpurpose"), TextBox).Text
            If purpose = "" Then
                purpose = "-"
            End If

            If stay = "Y" Then
                sf1 = DirectCast(GridView1.Rows(i).FindControl("txtstayfrom"), TextBox).Text
                If sf1.Trim <> "" Then
                    Dim strdate3() As String = sf1.Split("/"c)
                    sf1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)
                    If IsDate(sf1) = True Then
                        fd2 = CDate(sf1)
                    Else
                        lblmsg.Text = "Invald date"
                        GridView1.Rows(i).FindControl("txtstayfrom").Focus()
                        Exit Sub
                    End If
                Else
                    lblmsg.Text = "Enter CheckIn and Checkout details for selected Accomadation"
                    Exit Sub
                End If

                st1 = DirectCast(GridView1.Rows(i).FindControl("txtstaytill"), TextBox).Text
                If st1.Trim <> "" Then
                    Dim strdate4() As String = st1.Split("/"c)
                    st1 = strdate4(1) & "/" & strdate4(0) & "/" & strdate4(2)

                    If IsDate(st1) = True Then
                        st2 = CDate(st1)
                    Else
                        lblmsg.Text = "Invald date"
                        GridView1.Rows(i).FindControl("txtstaytill").Focus()
                        Exit Sub
                    End If
                Else
                    lblmsg.Text = "Enter CheckIn and Checkout details for selected Accomadation"
                    Exit Sub
                End If

                ih = DirectCast(GridView1.Rows(i).FindControl("ddlchkinhr"), DropDownList).SelectedValue
                imin = DirectCast(GridView1.Rows(i).FindControl("ddlchkinmin"), DropDownList).SelectedValue
                iam = DirectCast(GridView1.Rows(i).FindControl("ddlchkinam"), DropDownList).SelectedValue
                oh = DirectCast(GridView1.Rows(i).FindControl("ddlchkohr"), DropDownList).SelectedValue
                omin = DirectCast(GridView1.Rows(i).FindControl("ddlchkomin"), DropDownList).SelectedValue
                oam = DirectCast(GridView1.Rows(i).FindControl("ddlchkoam"), DropDownList).SelectedValue

                chkin = ih & ":" & imin & ":" & iam
                chkout = oh & ":" & omin & ":" & oam
            Else
                ih = "0"
                imin = "0"
                iam = DirectCast(GridView1.Rows(i).FindControl("ddlchkinam"), DropDownList).SelectedValue
                oh = "0"
                omin = "0"
                oam = DirectCast(GridView1.Rows(i).FindControl("ddlchkoam"), DropDownList).SelectedValue
                chkin = ih & ":" & imin & " " & iam
                chkout = oh & ":" & omin & " " & oam
            End If

            Dim rno = GridView1.Rows(i).Cells(0).Text
            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("HRMIS_BT_custvist")
                If fd1 = "" Or td1 = "" Then
                    Cmd.Parameters.AddWithValue("@vfrom", DBNull.Value)
                    Cmd.Parameters.AddWithValue("@vto", DBNull.Value)
                Else
                    Cmd.Parameters.AddWithValue("@vfrom", fd)
                    Cmd.Parameters.AddWithValue("@vto", td)
                End If

                Cmd.Parameters.AddWithValue("@purpose", purpose)
                Cmd.Parameters.AddWithValue("@stay", stay)
                If stay = "Y" Then
                    Cmd.Parameters.AddWithValue("@chkin", chkin)
                    Cmd.Parameters.AddWithValue("@chkout", chkout)
                ElseIf stay = "N" Then
                    Cmd.Parameters.AddWithValue("@chkin", DBNull.Value)
                    Cmd.Parameters.AddWithValue("@chkout", DBNull.Value)
                End If
                Cmd.Parameters.AddWithValue("@chr", ih)
                Cmd.Parameters.AddWithValue("@cmin", imin)
                Cmd.Parameters.AddWithValue("@cam", iam)
                Cmd.Parameters.AddWithValue("@cohr", oh)
                Cmd.Parameters.AddWithValue("@comin", omin)
                Cmd.Parameters.AddWithValue("@coam", oam)
            
                If stay = "N" Then
                    Cmd.Parameters.AddWithValue("@stayfrom", DBNull.Value)
                    Cmd.Parameters.AddWithValue("@staytill", DBNull.Value)
                Else
                    Cmd.Parameters.AddWithValue("@stayfrom", fd2)
                    Cmd.Parameters.AddWithValue("@staytill", st2)
                End If

                Cmd.Parameters.AddWithValue("@rno", rno)
                Cmd.ExecuteNonQuery()
                Call MyGlobal.db_close()
            Catch ex As Exception
                MessageBox(ex.Message)
                Exit Sub
            End Try
        Next

        updateBT(Session("btnum"))

        If recstatus = True Then
            lblmsg.Text = "Business Trip Scheduled"
            lblmsg.ForeColor = Drawing.Color.Red
            Response.Redirect("~/hrmis/business trip/reports/btprintform.aspx?rno=" & Session("btnum") & "")

            ' Response.Redirect("btselfstatus.aspx")
        Else
            lblmsg.Text = myerrormsg

        End If
        Session("btnum") = ""

    End Sub

End Class