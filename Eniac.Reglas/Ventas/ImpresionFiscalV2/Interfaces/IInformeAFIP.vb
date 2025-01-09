Namespace FiscalV2
   Public Interface IInformeAFIP
      Function FechaPrimerZeta() As Date?
      Sub InformeAFIP(impresora As Entidades.Impresora, fechaDesde As Date, fechaHasta As Date, directorioExportacion As String)
      ReadOnly Property MetodoExportacion As MetodoExportacionInformeAFIP
   End Interface
   Public Enum MetodoExportacionInformeAFIP
      PorArchivo
      PorDirectorio
   End Enum
End Namespace