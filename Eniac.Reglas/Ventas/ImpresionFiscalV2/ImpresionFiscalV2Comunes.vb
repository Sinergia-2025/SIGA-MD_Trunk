Namespace FiscalV2
   Public Class ImpresionFiscalV2Comunes

      Public Shared Function PrimerDiaSemanaFiscal(fecha As Date) As Date
         Return SemanaFiscal(fecha).Item1
      End Function
      Public Shared Function UltimoDiaSemanaFiscal(fecha As Date) As Date
         Return SemanaFiscal(fecha).Item2
      End Function

      Public Shared Function SemanaFiscal(fecha As Date) As Tuple(Of Date, Date)
         Dim [mod] As Integer
         Dim div = Math.Min(3, Math.DivRem(fecha.Day - 1, 7, [mod]))

         Dim dia1 = (div * 7) + 1
         Dim dia2 = (div * 7) + 7

         Dim fecha1 = New DateTime(fecha.Year, fecha.Month, dia1)
         Dim fecha2 = If(dia2 > 21, fecha.UltimoDiaMes(), New DateTime(fecha.Year, fecha.Month, dia2))

         Return New Tuple(Of Date, Date)(fecha1, fecha2)
      End Function

   End Class
End Namespace