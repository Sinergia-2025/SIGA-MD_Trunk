Imports System.Text

Public Class Observaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Observaciones_I(ByVal idObservacion As Integer, _
                              ByVal DetalleObservacion As String, _
                              ByVal Tipo As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO Observaciones (")
         .AppendLine("   IdObservacion")
         .AppendLine("  ,DetalleObservacion")
         .AppendLine("  ,Tipo")
         .AppendLine(" ) VALUES (")
         .AppendLine("   " & idObservacion.ToString())
         .AppendLine("  ,'" & DetalleObservacion & "'")
         .AppendLine("  ,'" & Tipo & "'")
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Observaciones")

   End Sub

   Public Sub Observaciones_U(ByVal idObservacion As Integer, _
                              ByVal DetalleObservacion As String, _
                              ByVal Tipo As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Observaciones SET ")
         .AppendLine("    DetalleObservacion = '" & DetalleObservacion & "'")
         .AppendLine("   ,Tipo = '" & Tipo & "'")
         .AppendLine("  WHERE idObservacion = " & idObservacion.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Observaciones")

   End Sub

   Public Sub Observaciones_D(ByVal idObservacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE FROM Observaciones ")
         .AppendLine(" WHERE idObservacion = " & idObservacion.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Observaciones")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT O.IdObservacion")
         .AppendLine("      ,O.DetalleObservacion")
         .AppendLine("      ,O.Tipo")
         .AppendLine("  FROM Observaciones O")
      End With
   End Sub

   Public Function Observaciones_GA(tipo As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If Not String.IsNullOrWhiteSpace(tipo) Then
            .AppendFormat("   AND O.Tipo = '{0}'", tipo).AppendLine()
         End If
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function Observaciones_G1(ByVal idObservacion As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE O.IdObservacion = " & idObservacion.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function Observaciones_GetCodigoMaximo() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT MAX(IdObservacion) AS maximo ")
         .AppendLine(" FROM Observaciones")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "O." + columna
      'If columna = "CF.IdCategoriaFiscal" Then columna = columna.Replace("CF.", "MaV.")
      'If columna = "CF.NombreCategoriaFiscal" Then columna = columna.Replace("CF.", "MoV.")

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Observaciones_GPorNombre(ByVal detalleObservacion As String, ByVal Tipo As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE O.DetalleObservacion LIKE '%" & detalleObservacion & "%'")
         .AppendLine("   AND O.Tipo = '" & Tipo & "'")
         .AppendLine("  ORDER BY O.DetalleObservacion")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class