Public Class PedidosCriticidades
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PedidosCriticidades_I(idCriticidad As String,
                                    orden As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO PedidosCriticidades (")
         .AppendFormatLine("      IdCriticidad")
         .AppendFormatLine("    , Orden")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("      '{0}'", idCriticidad)
         .AppendFormatLine("    ,  {0} ", orden)
         .AppendFormatLine(")")
      End With
      Execute(stb)
   End Sub
   Public Sub PedidosCriticidades_U(idCriticidad As String,
                                    orden As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine(" UPDATE PedidosCriticidades")
         .AppendFormatLine("    SET Orden = {0}", orden)
         .AppendFormatLine(" WHERE IdCriticidad = '{0}'", idCriticidad)
      End With
      Execute(stb)
   End Sub
   Public Sub PedidosCriticidades_D(idCriticidad As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM PedidosCriticidades")
         .AppendFormatLine(" WHERE IdCriticidad = '{0}'", idCriticidad)
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT E.* ")
         .AppendLine("  FROM PedidosCriticidades E")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "E.")
   End Function
   Public Function PedidosCriticidades_GA(todos As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .Append("  ORDER BY E.IdCriticidad")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function PedidosCriticidades_G1(IdCriticidad As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE E.IdCriticidad = '{0}'", IdCriticidad)
      End With
      Return GetDataTable(stb)
   End Function
   Public Function GetTodosPorOrden() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine(" ORDER BY E.Orden")
      End With
      Return GetDataTable(stb)
   End Function
End Class