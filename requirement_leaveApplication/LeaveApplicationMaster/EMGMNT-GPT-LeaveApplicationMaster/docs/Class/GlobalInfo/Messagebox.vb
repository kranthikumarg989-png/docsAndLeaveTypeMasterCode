Public Class Messagebox
    Inherits System.Web.UI.Page
    Public Sub msg(ByVal message As String)
        RegisterClientScriptBlock(Guid.NewGuid().ToString(), "<script language=""JavaScript"">" & getalertscript(message) & "</script>")
    End Sub
    Public Function getalertscript(ByVal message As String) As String
        Return "alert(' " & message.Replace("'", "\'") & "');"
    End Function
End Class
