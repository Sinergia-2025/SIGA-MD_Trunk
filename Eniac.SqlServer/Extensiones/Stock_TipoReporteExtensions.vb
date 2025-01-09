Namespace Extensiones
   Public Module Stock_TipoReporteExtensions
      <Extension>
      Public Function ToQuery(valor As Entidades.EnumSql.Stock_TipoReporte?) As String
         If valor.HasValue Then
            Select Case valor.Value
               Case Entidades.EnumSql.Stock_TipoReporte.General
                  Return String.Empty
               Case Entidades.EnumSql.Stock_TipoReporte.MayorIgualCero
                  Return " > = 0"
               Case Entidades.EnumSql.Stock_TipoReporte.MayorCero
                  Return " > 0"
               Case Entidades.EnumSql.Stock_TipoReporte.IgualCero
                  Return " = 0"
               Case Entidades.EnumSql.Stock_TipoReporte.Negativo
                  Return " < 0"
            End Select
         End If
         Return String.Empty
      End Function

   End Module
End Namespace