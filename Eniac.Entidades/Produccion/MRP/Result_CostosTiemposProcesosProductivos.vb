Public Class Result_CostosTiemposProcesosProductivos
   Public Sub New()
      CostoManoObraInterna = 0
      CostoManoObraExterna = 0
      CostoMateriaPrima = 0
      CostosTotalProceso = 0
      TiempoTotalProceso = 0
   End Sub

   Public Property CostoManoObraInterna As Decimal
   Public Property CostoManoObraExterna As Decimal
   Public Property CostoMateriaPrima As Decimal
   Public Property CostosTotalProceso As Decimal
   Public Property TiempoTotalProceso As Decimal

End Class
