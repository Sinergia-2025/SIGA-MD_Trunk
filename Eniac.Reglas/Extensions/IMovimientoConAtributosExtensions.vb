Imports System.Runtime.CompilerServices

Namespace Extensions
   Public Module IMovimientoConAtributosExtensions
      <Extension>
      Public Function ConcatenaAtributos(movConAtr As Entidades.IMovimientoConAtributos) As String
         Dim atr = New List(Of String)()
         atr.Add(New Reglas.AtributosProductos().GetUnoIDA(movConAtr.IdaAtributoProducto01).Descripcion)
         atr.Add(New Reglas.AtributosProductos().GetUnoIDA(movConAtr.IdaAtributoProducto02).Descripcion)
         atr.Add(New Reglas.AtributosProductos().GetUnoIDA(movConAtr.IdaAtributoProducto03).Descripcion)
         atr.Add(New Reglas.AtributosProductos().GetUnoIDA(movConAtr.IdaAtributoProducto04).Descripcion)
         atr = atr.Where(Function(a) Not String.IsNullOrWhiteSpace(a)).ToList()
         If atr.Count > 0 Then
            Return String.Join(" / ", atr)
         End If
         Return String.Empty
      End Function

   End Module
End Namespace