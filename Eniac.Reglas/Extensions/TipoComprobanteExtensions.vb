Imports System.Runtime.CompilerServices

Module TipoComprobanteExtensions
   <Extension>
   Public Function GetLetraHabilitada(tipoComprobante As Entidades.TipoComprobante, categoriaFiscal As Entidades.CategoriaFiscal) As String
      Dim splitLetrasHabilitadas = tipoComprobante.LetrasHabilitadas.Split(","c)
      If splitLetrasHabilitadas.Length = 1 Then
         Return splitLetrasHabilitadas(0)
      Else
         If splitLetrasHabilitadas.Contains(categoriaFiscal.LetraFiscal) Then
            Return categoriaFiscal.LetraFiscal
         End If
      End If
      Return String.Empty
   End Function
End Module