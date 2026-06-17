Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class frmFristWelcome
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal
    Dim MyGlobal As New emanagement.globalinfo

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub
    Function getEmpRolesnRights(ByVal empcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Sp_GetEmpRolesNrights", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@empcode", empcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empmaster")
        con.Close()
        Return ds
    End Function

    Private Sub frmFristWelcome_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If Not IsPostBack Then
            Dim noroles As Boolean
            Dim RightsSaved As Boolean
            Dim EmpCode
            Dim SystemId
            Dim ModuleId
            Dim ScrTypeId
            Dim ScrId
            Dim ScrStatus
            Dim SystemIdV
            Dim ModuleIdV
            Dim ScrTypeIdV
            Dim ScrIdV
            Dim ScrStatusV
            Dim ds As New DataSet
            ds = getEmpRolesnRights(Session("empcode"))
            If ds.Tables(0).Rows.Count <> 0 Then
                Dim dr As DataRow
                Dim i
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    dr = ds.Tables(0).Rows(i)
                    SystemId = dr("systemid") & ""
                    If Len(Trim(SystemId)) <> 0 Then
                        EmpCode = Session("empcode")
                        SystemId = dr("systemid") & ""
                        ModuleId = dr("moduleid") & ""
                        ScrTypeId = dr("scrtypeid") & ""
                        ScrId = dr("scrid") & ""
                        ScrStatus = dr("scrstatus") & ""
                        SystemIdV = Val(SystemId)
                        ModuleIdV = Val(ModuleId)
                        ScrTypeIdV = Val(ScrTypeId)
                        ScrIdV = Val(ScrId)
                        ScrStatusV = Val(ScrStatus)
                        Try
                            mynet.db_cn()
                            mynet.db_open()
                            Call mynet.dbSp_open("Sp_InsUpdEmpRights")
                            command.Parameters.AddWithValue("@empcode", EmpCode)
                            command.Parameters.AddWithValue("@Systemid", SystemIdV)
                            command.Parameters.AddWithValue("@moduleid", ModuleIdV)
                            command.Parameters.AddWithValue("@scrtypeid", ScrTypeIdV)
                            command.Parameters.AddWithValue("@scrid", ScrIdV)
                            command.Parameters.AddWithValue("@scrstatus", ScrStatusV)
                            command.ExecuteNonQuery()
                            mynet.db_close()
                            'LblMsg.Text = "Congratulations! You have Saved successfully. "
                            'LblMsg.ForeColor = Drawing.Color.DarkGreen
                            'TxtBoxEmpCode.Text = ""
                            RightsSaved = True
                        Catch ex As Exception
                            RightsSaved = False
                            'LblMsg.Text = ex.Message
                            'LblMsg.ForeColor = Drawing.Color.Red
                            Response.Redirect("login.aspx")
                        End Try
                    Else
                        noroles = True
                        Exit For
                    End If
                Next
                If noroles = True Then
                    Response.Redirect("login.aspx")
                End If
                If RightsSaved = True Then
                    Try
                        mynet.db_cn()
                        mynet.db_open()
                        Call mynet.dbSp_open("Sp_InsUpdNoflogins")
                        command.Parameters.AddWithValue("@empcode", Session("EmpCode").ToString)
                        command.ExecuteNonQuery()
                        mynet.db_close()
                    Catch ex As Exception
                        RightsSaved = False
                        Response.Redirect("login.aspx")
                    End Try
                    Response.Redirect("default.aspx")
                End If
            Else
                Response.Redirect("login.aspx")
            End If

        End If
    End Sub
End Class