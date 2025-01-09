Imports System.Runtime.CompilerServices
Namespace Extensiones
   Module BuscadorExtensions
      <Extension>
      Public Function TagNumericoPorDefecto(Of T)(txt As Controles.Buscador, porDefecto As T) As T
         Return ObjectExtensions.ValorNumericoPorDefecto(txt.Tag, porDefecto)
      End Function

   End Module
End Namespace