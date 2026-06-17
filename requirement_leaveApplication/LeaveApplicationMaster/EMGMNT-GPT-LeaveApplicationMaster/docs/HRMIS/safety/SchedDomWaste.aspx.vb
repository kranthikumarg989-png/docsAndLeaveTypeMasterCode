Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports System.Web.Security
Partial Public Class SchedDomWaste
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        'Session("empcode") = "014543"
    End Sub

    Protected Sub view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles view.Click
       
        GridView1.Visible = "True"

        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            GetSDWdata(desc.SelectedValue.Trim)
            If recstatus = True Then
                Dim rcount As Integer
                Dim item As String
                Dim code As String
                '   Dim desc As String
                Dim dr As DataRow
                Dim i As Integer = 0
                If dsdata.Tables(0).Rows.Count > 0 Then
                    rcount = dsdata.Tables(0).Rows.Count
                    For i = 0 To rcount - 1
                        dr = dsdata.Tables(0).Rows(i)
                        item = dr("item").ToString
                        code = dr("code").ToString
                        Call MyGlobal.dbSp_open("h_Pv_safetytemp")
                        Cmd.Parameters.AddWithValue("@item", item)
                        Cmd.Parameters.AddWithValue("@code", code)
                        Cmd.Parameters.AddWithValue("@empcode", Session("empcode"))
                        Cmd.Parameters.AddWithValue("@desc", desc.selectedvalue)
                        Cmd.ExecuteNonQuery()
                    Next
                    'DelDEdata(Session("empcode"))
                End If
            End If

            
        Catch ex As SqlException
            messagebox(ex.Message)
            LblMsg.Text = ex.Message
            LblMsg.ForeColor = Drawing.Color.Red

        End Try
        'Else

        'messagebox("Please select a value for Major")

        'End If
        MyGlobal.db_close()
        GridView1.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub saveSDW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveSDW.Click
        GridView1.Visible = "True"
        Dim rno

        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            GetSDWsave(desc.SelectedValue.Trim, Session("empcode"))
            If recstatus = True Then
                GetRno()
                rno = posid
                messagebox(rno)

                ''''insert in to safety-domesticwasteconsignmenttable
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()

                    Call MyGlobal.dbSp_open("safety_ins_DWC")
                    Cmd.Parameters.AddWithValue("@recordno", posid)
                    Cmd.Parameters.AddWithValue("@dept", Session("_edept"))
                    Cmd.Parameters.AddWithValue("@empcode", Session("empcode"))
                    Cmd.Parameters.AddWithValue("@sect", Session("_esect"))
                    Cmd.Parameters.AddWithValue("@majortype", desc.SelectedValue.Trim)
                    Cmd.Parameters.AddWithValue("@status", "S")
                    Cmd.ExecuteNonQuery()
                    GetsafetytempRec(desc.SelectedValue.Trim, Session("empcode"))

                    If recstatus = True Then
                        Dim rcount1 As Integer
                        Dim item1 As String
                        Dim code1 As String
                        Dim weight As String
                        Dim UOM As String
                        Dim dr1 As DataRow
                        Dim i1 As Integer = 0
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            rcount1 = dsdata.Tables(0).Rows.Count
                            For i1 = 0 To rcount1 - 1
                                dr1 = dsdata.Tables(0).Rows(i1)
                                'recno = dr("recordno").ToString
                                item1 = dr1("item").ToString
                                code1 = dr1("code").ToString
                                weight = dr1("stdmeasurement").ToString
                                UOM = dr1("oum").ToString

                                If desc.SelectedValue.Trim = "Schedule Waste" Then
                                    '''' INSERT RECORD TO SWCD TABLE
                                    Call MyGlobal.dbSp_open("safety_ins_SWCD")
                                    Cmd.Parameters.AddWithValue("@item", item1)
                                    Cmd.Parameters.AddWithValue("@code", code1)
                                    Cmd.Parameters.AddWithValue("@WEIGHT", weight)
                                    Cmd.Parameters.AddWithValue("@uom", UOM)
                                    Cmd.Parameters.AddWithValue("@recordno", posid)

                                ElseIf desc.SelectedValue.Trim = "Domestic Waste" Then

                                    '''' INSERT RECORD TO dWCD TABLE
                                    Call MyGlobal.dbSp_open("safety_ins_dWCD")
                                    Cmd.Parameters.AddWithValue("@item", item1)
                                    Cmd.Parameters.AddWithValue("@code", code1)
                                    Cmd.Parameters.AddWithValue("@WEIGHT", weight)
                                    Cmd.Parameters.AddWithValue("@recordno", posid)
                                End If
                                Cmd.ExecuteNonQuery()

                            Next
                        DelDEdata_desc(Session("empcode"), desc.SelectedValue.Trim)
                    End If
                    End If



        Catch ex As SqlException
                    messagebox(ex.Message)
        End Try

                
            End If


        Catch ex As SqlException
            messagebox(ex.Message)
            LblMsg.Text = ex.Message
            LblMsg.ForeColor = Drawing.Color.Red

        End Try
     
        MyGlobal.db_close()
        GridView1.DataBind()
    End Sub
End Class