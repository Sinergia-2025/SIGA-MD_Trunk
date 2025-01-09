Imports System.Data
Public Class AFIPTiposDocumentos
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub


   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Append("SELECT ATD.IdAFIPTipoDocumento")
         .Append("      ,ATD.NombreAFIPTipoDocumento")
         .Append("      ,ATD.TipoDocumento")
         .Append("  FROM AFIPTiposDocumentos ATD ")
      End With
   End Sub

   Public Function AFIPTiposComprobantes_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetIdTipoDocparaAFIP(idTipoDocumento As String) As Integer?
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ATD.TipoDocumento = '{0}'", idTipoDocumento)
      End With

      Dim dt = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         Return dt.Rows(0).Field(Of Integer)("IdAFIPTipoDocumento")
      Else
         Return Nothing
      End If

   End Function

   Public Function GetIdTipoDoc(idAFIPTipoDocumento As Integer) As String
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ATD.IdAFIPTipoDocumento = {0}", idAFIPTipoDocumento)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         Return dt.Rows(0)("TipoDocumento").ToString()
      Else
         Throw New Exception("Falta cargar el Tipo de Documento en las tablas del AFIP.")
      End If

   End Function

End Class
