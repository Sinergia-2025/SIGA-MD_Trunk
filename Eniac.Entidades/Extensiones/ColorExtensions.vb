Namespace Extensiones
   Public Module ColorExtensions
      <Extension>
      Public Function ToTuple(valor As Drawing.Color) As Tuple(Of Integer, Integer, Integer)
         Return New Tuple(Of Integer, Integer, Integer)(valor.R, valor.G, valor.B)
      End Function
   End Module
End Namespace