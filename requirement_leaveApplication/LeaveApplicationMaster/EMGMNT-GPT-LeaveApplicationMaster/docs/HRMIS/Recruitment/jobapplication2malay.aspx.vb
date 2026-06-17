Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class jobapplication2malay
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext, keyinby As String
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Dim aplno
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        aplno = Session("applno")
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()
        If IsPostBack = False Then
            If Session("reload") <> "" Or Session("backload") <> "" Then
                'If Session("sign") = "" Then
                sqltext = "select*from jobapplication_temp where applicationno='" & aplno & "'"
                'Else
                'sqltext = "select*from jobapplication where applicationno='" & aplno & "'"
                'End If
                cmd = New SqlCommand(sqltext, Con)
                rdr = cmd.ExecuteReader
                While rdr.Read
                    sch1.Text = rdr("schoolname1")
                    highpass1.Text = rdr("highestpassed1")
                    joined1.Text = rdr("joined1")
                    left1.Text = rdr("left1")
                    sch2.Text = rdr("schoolname2")
                    highpass2.Text = rdr("highestpassed2")
                    joined2.Text = rdr("joined2")
                    left2.Text = rdr("left2")
                    sch3.Text = rdr("schoolname3")
                    highpass3.Text = rdr("highestpassed3")
                    joined3.Text = rdr("joined3")
                    left3.Text = rdr("left3")
                    sch4.Text = rdr("schoolname4")
                    highpass4.Text = rdr("highestpassed4")
                    joined4.Text = rdr("joined4")
                    left4.Text = rdr("left4")
                    sports.Text = rdr("sportsactivities")
                    cmpny1.Text = rdr("companyname1")
                    cphone1.Text = rdr("cphone1")
                    cdate1.Text = rdr("cdate1")
                    ctitle1.Text = rdr("cjobtitle1")
                    cduties1.Text = rdr("cduties1")
                    csalary1.Text = rdr("csalary1")
                    reason1.Text = rdr("reason1")
                    cmpny2.Text = rdr("companyname2")
                    cphone2.Text = rdr("cphone2")
                    cdate2.Text = rdr("cdate2")
                    ctitle2.Text = rdr("cjobtitle2")
                    cduties2.Text = rdr("cduties2")
                    csalary2.Text = rdr("csalary2")
                    reason2.Text = rdr("reason2")
                    cmpny3.Text = rdr("companyname3")
                    cphone3.Text = rdr("cphone3")
                    cdate3.Text = rdr("cdate3")
                    ctitle3.Text = rdr("cjobtitle3")
                    cduties3.Text = rdr("cduties3")
                    csalary3.Text = rdr("csalary3")
                    reason3.Text = rdr("reason3")
                    cmpny4.Text = rdr("companyname4")
                    cphone4.Text = rdr("cphone4")
                    cdate4.Text = rdr("cdate4")
                    ctitle4.Text = rdr("cjobtitle4")
                    cduties4.Text = rdr("cduties4")
                    csalary4.Text = rdr("csalary4")
                    reason4.Text = rdr("reason4")
                End While
                rdr.Close()
            End If
        End If
    End Sub
    Protected Sub savenxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savenxt.Click
        If Trim(sch1.Text) = "" Then
            sch1.Focus()
            MessageBox("Enter Your School Name First")
            Exit Sub
        End If
        If Trim(highpass1.Text) = "" Then
            highpass1.Focus()
            MessageBox("Enter Your Grade")
            Exit Sub
        End If
        If Trim(joined1.Text) = "" Then
            joined1.Focus()
            MessageBox("Pick joined Date")
            Exit Sub
        End If
        If Trim(left1.Text) = "" Then
            left1.Focus()
            MessageBox("Pick Left Date")
            Exit Sub
        End If
        'Session("lastload") = "ll"
        'If Session("sign") = "" Then
        Try
            'Else
            'sqltext = "update jobapplication set schoolname1='" & (sch1.Text) & "',highestpassed1='" & highpass1.Text & "',joined1='" & (joined1.Text) & "',left1='" & (left1.Text) & "',schoolname2='" & (sch2.Text) & "',highestpassed2='" & highpass2.Text & "',joined2='" & (joined2.Text) & "',left2='" & (left2.Text) & "',schoolname3='" & (sch3.Text) & "',highestpassed3='" & highpass3.Text & "',joined3='" & (joined3.Text) & "',left3='" & (left3.Text) & "',schoolname4='" & (sch4.Text) & "',highestpassed4='" & highpass4.Text & "',joined4='" & (joined4.Text) & "',left4='" & (left4.Text) & "',sportsactivities='" & (sports.Text) & "',companyname1='" & (cmpny1.Text) & "',cphone1='" & (cphone1.Text) & "',cdate1='" & (cdate1.Text) & "',cjobtitle1='" & (ctitle1.Text) & "',cduties1='" & (cduties1.Text) & "',csalary1='" & (csalary1.Text) & "',reason1='" & (reason1.Text) & "',companyname2='" & (cmpny2.Text) & "',cphone2='" & (cphone2.Text) & "',cdate2='" & (cdate2.Text) & "',cjobtitle2='" & (ctitle2.Text) & "',cduties2='" & (cduties2.Text) & "',csalary2='" & (csalary2.Text) & "',reason2='" & (reason2.Text) & "',companyname3='" & (cmpny3.Text) & "',cphone3='" & (cphone3.Text) & "',cdate3='" & (cdate3.Text) & "',cjobtitle3='" & (ctitle3.Text) & "',cduties3='" & (cduties3.Text) & "',csalary3='" & (csalary3.Text) & "',reason3='" & (reason3.Text) & "',companyname4='" & (cmpny4.Text) & "',cphone4='" & (cphone4.Text) & "',cdate4='" & (cdate4.Text) & "',cjobtitle4='" & (ctitle4.Text) & "',cduties4='" & (cduties4.Text) & "',csalary4='" & (csalary4.Text) & "',reason4='" & (reason4.Text) & "'  where applicationno='" & aplno & "'"
            'End If
            sqltext = "update jobapplication_temp set schoolname1='" & (sch1.Text) & "',highestpassed1='" & (highpass1.Text) & "',joined1='" & (joined1.Text) & "',left1='" & (left1.Text) & "',schoolname2='" & (sch2.Text) & "',highestpassed2='" & (highpass2.Text) & "',joined2='" & (joined2.Text) & "',left2='" & (left2.Text) & "',schoolname3='" & (sch3.Text) & "',highestpassed3='" & (highpass3.Text) & "',joined3='" & (joined3.Text) & "',left3='" & (left3.Text) & "',schoolname4='" & (sch4.Text) & "',highestpassed4='" & (highpass4.Text) & "',joined4='" & (joined4.Text) & "',left4='" & (left4.Text) & "',sportsactivities='" & (sports.Text) & "',companyname1='" & (cmpny1.Text) & "',cphone1='" & (cphone1.Text) & "',cdate1='" & (cdate1.Text) & "',cjobtitle1='" & (ctitle1.Text) & "',cduties1='" & (cduties1.Text) & "',csalary1='" & (csalary1.Text) & "',reason1='" & (reason1.Text) & "',companyname2='" & (cmpny2.Text) & "',cphone2='" & (cphone2.Text) & "',cdate2='" & (cdate2.Text) & "',cjobtitle2='" & (ctitle2.Text) & "',cduties2='" & (cduties2.Text) & "',csalary2='" & (csalary2.Text) & "',reason2='" & (reason2.Text) & "',companyname3='" & (cmpny3.Text) & "',cphone3='" & (cphone3.Text) & "',cdate3='" & (cdate3.Text) & "',cjobtitle3='" & (ctitle3.Text) & "',cduties3='" & (cduties3.Text) & "',csalary3='" & (csalary3.Text) & "',reason3='" & (reason3.Text) & "',companyname4='" & (cmpny4.Text) & "',cphone4='" & (cphone4.Text) & "',cdate4='" & (cdate4.Text) & "',cjobtitle4='" & (ctitle4.Text) & "',cduties4='" & (cduties4.Text) & "',csalary4='" & (csalary4.Text) & "',reason4='" & (reason4.Text) & "'  where applicationno='" & aplno & "'"
            cmd = New SqlCommand(sqltext, Con)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try

        'If Session("sign") = "" Then
        'MsgBox("ok")
        Server.Transfer("jobapplication3.aspx")
        'End If
    End Sub
    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Session("first") = "first"
        sqltext = "update jobapplication_temp set schoolname1='" & (sch1.Text) & "',highestpassed1='" & (highpass1.Text) & "',joined1='" & (joined1.Text) & "',left1='" & (left1.Text) & "',schoolname2='" & (sch2.Text) & "',highestpassed2='" & (highpass2.Text) & "',joined2='" & (joined2.Text) & "',left2='" & (left2.Text) & "',schoolname3='" & (sch3.Text) & "',highestpassed3='" & (highpass3.Text) & "',joined3='" & (joined3.Text) & "',left3='" & (left3.Text) & "',schoolname4='" & (sch4.Text) & "',highestpassed4='" & (highpass4.Text) & "',joined4='" & (joined4.Text) & "',left4='" & (left4.Text) & "',sportsactivities='" & (sports.Text) & "',companyname1='" & (cmpny1.Text) & "',cphone1='" & (cphone1.Text) & "',cdate1='" & (cdate1.Text) & "',cjobtitle1='" & (ctitle1.Text) & "',cduties1='" & (cduties1.Text) & "',csalary1='" & (csalary1.Text) & "',reason1='" & (reason1.Text) & "',companyname2='" & (cmpny2.Text) & "',cphone2='" & (cphone2.Text) & "',cdate2='" & (cdate2.Text) & "',cjobtitle2='" & (ctitle2.Text) & "',cduties2='" & (cduties2.Text) & "',csalary2='" & (csalary2.Text) & "',reason2='" & (reason2.Text) & "',companyname3='" & (cmpny3.Text) & "',cphone3='" & (cphone3.Text) & "',cdate3='" & (cdate3.Text) & "',cjobtitle3='" & (ctitle3.Text) & "',cduties3='" & (cduties3.Text) & "',csalary3='" & (csalary3.Text) & "',reason3='" & (reason3.Text) & "',companyname4='" & (cmpny4.Text) & "',cphone4='" & (cphone4.Text) & "',cdate4='" & (cdate4.Text) & "',cjobtitle4='" & (ctitle4.Text) & "',cduties4='" & (cduties4.Text) & "',csalary4='" & (csalary4.Text) & "',reason4='" & (reason4.Text) & "'  where applicationno='" & aplno & "'"
        cmd = New SqlCommand(sqltext, Con)
        cmd.ExecuteNonQuery()
        Response.Redirect("jobapplication.aspx")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
End Class