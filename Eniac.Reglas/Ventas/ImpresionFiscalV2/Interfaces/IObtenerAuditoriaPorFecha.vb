Namespace FiscalV2
   Public Interface IObtenerAuditoriaPorFecha
      ''' <summary>
      ''' Extracción por fechas de Auditoria de Fiscal.
      ''' </summary>
      ''' <param name="fechaDesde">Fecha de inicio de extracción</param>
      ''' <param name="fechaHasta">Fecha de fin de extracción</param>
      ''' <param name="archivoSalida">Archivo de salida</param>
      Sub ObtenerAuditoria(fechaDesde As Date, fechaHasta As Date, archivoSalida As String)
   End Interface
End Namespace