Public Class ClientesHistorias
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ClientesHistorias_I(ByVal IdCliente As Long, _
                                ByVal fechaHoraItem As DateTime, _
                                ByVal item As String, _
                                ByVal usuario As String)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("INSERT INTO ClientesHistorias")
         .Append("           (IdCLiente")
         .Append("           ,FechaHoraItem")
         .Append("           ,Item")
         .Append("           ,Usuario)")
         .Append("     VALUES")
         .AppendFormat("           ({0}", IdCliente)
         .AppendFormat("           ,'{0}'", fechaHoraItem.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("           ,'{0}'", item)
         .AppendFormat("           ,'{0}')", usuario)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub ClientesHistorias_U()
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         'agregar el query de UPDATE
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub ClientesHistorias_D(ByVal IdCLiente As Long, _
                                ByVal fechaHoraItem As DateTime)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM ClientesHistorias ")
         .AppendFormat(" WHERE IdCLiente = {0} ", IdCLiente)
         .AppendFormat(" AND FechaHoraItem = '{0}' ", fechaHoraItem.ToString("yyyyMMdd HH:mm:ss"))
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         'agregar el query de SELECT incluido el FROM
      End With
   End Sub

   Public Function ClientesHistorias_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY <OrdenColumna>")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ClientesHistorias_G1(ByVal pk As Int32) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE <ColumnaPK> = {0}", pk)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'columna = "D." + columna
      'If columna = "D.NombreLocalidad" Then columna = columna.Replace("D.", "L.")
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetHistorialDeUnCliente(ByVal IdCliente As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT	SH.IdCliente,")
         .Append("				SH.FechaHoraItem,")
         .Append("				SH.Item,")
         .Append("				SH.Usuario")
         .Append(" FROM ClientesHistorias SH")
         .AppendFormat(" WHERE SH.IdCliente = {0}", IdCliente)
         .Append(" ORDER BY SH.FechaHoraItem desc")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
