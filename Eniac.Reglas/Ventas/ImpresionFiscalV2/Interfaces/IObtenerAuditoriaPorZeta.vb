Namespace FiscalV2
   Public Interface IObtenerAuditoriaPorZeta
      Sub ObtenerAuditoria(zetaDesde As Integer, zetaHasta As Integer, archivoSalida As String)
      ReadOnly Property PuedeExportarPorNroZeta As Boolean

   End Interface
End Namespace