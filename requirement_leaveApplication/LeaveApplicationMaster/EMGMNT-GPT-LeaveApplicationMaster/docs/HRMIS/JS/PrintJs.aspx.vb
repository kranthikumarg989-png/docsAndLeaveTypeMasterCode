Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class PrintJs
    Inherits System.Web.UI.Page

    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Dim revno As Integer
    Dim jpurpose As String
    Dim rno, recno, sno As Integer
    Dim pending As String
    Dim tech, techval, behval As String
    Dim behavior, key As String
    Dim i, j, k, l, m, n As Integer
    Dim txtrevno
    Dim owner As Char

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (134)
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
        lbprint.Visible = True
        'Session("empcode") = "014543"
        'empcode = Session("empcode")

        If Session("Jsowner") = "" Then
            empcode = Session("empcode")
        Else
            empcode = Session("Jsemp")
        End If
        If empcode = "" Then
            MessageBox("Please provide employee code!!!")
            Exit Sub
        End If

       
        MyApp.GetfiscalYear()
        GetEmpVehino(empcode)
        lblemp.Text = empcode
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblename.Text = dr("empname").ToString
                lblsect.Text = dr("sectioncode").ToString + "-" + dr("sectionname").ToString
                lbldept.Text = dr("departmentcode").ToString + "-" + dr("departmentname").ToString
                lbldesig.Text = dr("designation").ToString
            Else
                MessageBox("EmployeeCode doesnot Exist!!")
                Exit Sub
            End If
        End If

        GetJobPurpose(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblpurpose.ForeColor = Drawing.Color.DarkRed
                lblpurpose.Text = dr("jobpurpose").ToString
            Else
                lblpurpose.ForeColor = Drawing.Color.DarkRed
                lblpurpose.Text = "Not Allocated"
            End If
        Else
            lblpurpose.ForeColor = Drawing.Color.DarkRed
            lblpurpose.Text = MyerrorMsg & " Not Allocated"
        End If

        GetJobcode(empcode)

        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblcode.ForeColor = Drawing.Color.DarkRed
                lblcode.Text = dr("jobcode").ToString
            Else
                lblcode.ForeColor = Drawing.Color.DarkRed
                lblcode.Text = MyerrorMsg & " Not Allocated"
            End If
        Else
            lblcode.ForeColor = Drawing.Color.DarkRed
            lblcode.Text = "Not Allocated"
        End If

        If lbldesig.Text.Trim = "EA" Then
            lblcode.Text = "EA"
        ElseIf lbldesig.Text.Trim = "MD" Then
            lblcode.Text = "MD"
        End If

        GetRevno(empcode)
        txtrevno = posid - 1
        If txtrevno < "0" Then
            MessageBox("JS Not Specified!!Pls.Enter Js ")
            Exit Sub
        End If

        '''''''''''''''''''''''' CODE TO POPULATE TEXT BOX AND CHECKBOXLIST
        GetJS(empcode, txtrevno)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                TXTITEM.Text = "* " + dr("itempending").ToString
                tech = dr("technical").ToString
                behavior = dr("behaviour").ToString
                recno = dr("recordno").ToString
                lblrecno.Text = recno
                '''''''''CHKBOXLIST ARE STORED WITH COMMA INSIDE DATABASE
                '''''''''REMOVE , AND STORE IT IN ARRAY TO STORE BACK VALUE IN CHK BOX LIST
                Dim strtech() As String = tech.Split(",")
                For k = 0 To strtech.Length - 1
                    For j = 0 To cbtechnical.Items.Count - 1
                        If cbtechnical.Items(j).Text = (strtech(k)) Then
                            cbtechnical.Items(j).Selected = True
                        End If
                    Next
                Next
                Dim strbeha() As String = behavior.Split(",")
                For l = 0 To strbeha.Length - 1
                    For m = 0 To cbbehavior.Items.Count - 1
                        If cbbehavior.Items(m).Text = (strbeha(l)) Then
                            cbbehavior.Items(m).Selected = True
                        End If
                    Next
                Next
            End If
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Private Sub PrintJs_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Session("Jsemp") = ""
        Session("Jsowner") = ""
    End Sub


    Private Sub cbtechnical_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbtechnical.DataBound
        '''''''''''''''''''''''' CODE TO POPULATE TEXT BOX AND CHECKBOXLIST
        'If Session("Jsowner") = "" Then
        '    empcode = Session("empcode")
        'Else
        '    empcode = Session("Jsemp")
        'End If

        'If empcode = "" Then
        '    Exit Sub
        'End If
        ''''''''''CHKBOXLIST ARE STORED WITH COMMA INSIDE DATABASE
        ''''''''''REMOVE , AND STORE IT IN ARRAY TO STORE BACK VALUE IN CHK BOX LIST
        'Dim strtech() As String = tech.Split(",")
        'For k = 0 To strtech.Length - 1
        '    For j = 0 To cbtechnical.Items.Count - 1
        '        If cbtechnical.Items(j).Text = (strtech(k)) Then
        '            cbtechnical.Items(j).Selected = True
        '        End If
        '    Next
        'Next
        GetRevno(empcode)
        txtrevno = posid - 1
        GetJS(empcode, txtrevno)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                tech = dr("technical").ToString
                behavior = dr("behaviour").ToString
                Dim strtech() As String = tech.Split(",")
                For k = 0 To strtech.Length - 1
                    For j = 0 To cbtechnical.Items.Count - 1
                        If cbtechnical.Items(j).Text = (strtech(k)) Then
                            cbtechnical.Items(j).Selected = True
                        End If
                    Next
                Next
                Dim strbeha() As String = behavior.Split(",")
                For l = 0 To strbeha.Length - 1
                    For m = 0 To cbbehavior.Items.Count - 1
                        If cbbehavior.Items(m).Text = (strbeha(l)) Then
                            cbbehavior.Items(m).Selected = True
                        End If
                    Next
                Next
            End If
        End If
    End Sub

    Private Sub cbbehavior_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbbehavior.DataBound
        GetRevno(empcode)
        txtrevno = posid - 1
        GetJS(empcode, txtrevno)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                tech = dr("technical").ToString
                behavior = dr("behaviour").ToString
                Dim strtech() As String = tech.Split(",")
                For k = 0 To strtech.Length - 1
                    For j = 0 To cbtechnical.Items.Count - 1
                        If cbtechnical.Items(j).Text = (strtech(k)) Then
                            cbtechnical.Items(j).Selected = True
                        End If
                    Next
                Next
                Dim strbeha() As String = behavior.Split(",")
                For l = 0 To strbeha.Length - 1
                    For m = 0 To cbbehavior.Items.Count - 1
                        If cbbehavior.Items(m).Text = (strbeha(l)) Then
                            cbbehavior.Items(m).Selected = True
                        End If
                    Next
                Next
            End If
        End If
    End Sub

    Protected Sub lbprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbprint.Click
        lbprint.Visible = False
        ClientScript.RegisterStartupScript(Me.GetType(), "onclick", "<script language=javascript>window.print('Printjs.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>")
    End Sub
End Class