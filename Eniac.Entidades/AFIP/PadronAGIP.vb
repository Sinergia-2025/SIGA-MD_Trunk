Public Class PadronAGIP
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      PeriodoInformado
      IdPadronAGIP
      FechaPublicacion
      FechaVigenciaDesde
      FechaVigenciaHasta
      CUIT
      TipoContribuyente
      MarcaAlta
      MarcaAlicuota
      AlicuotaPercepcion
      AlicuotaRetencion
      GrupoPercepcion
      GrupoRetencion
      RazonSocial
   End Enum

   Public Property PeriodoInformado() As Integer
   Public Property IdPadronAGIP() As Long
   Public Property FechaPublicacion() As DateTime
   Public Property FechaVigenciaDesde() As DateTime
   Public Property FechaVigenciaHasta() As DateTime
   Public Property CUIT() As Long
   Public Property TipoContribuyente() As String
   Public Property MarcaAlta() As String
   Public Property MarcaAlicuota() As String
   Public Property AlicuotaPercepcion() As Decimal
   Public Property AlicuotaRetencion() As Decimal
   Public Property GrupoPercepcion() As Integer
   Public Property GrupoRetencion() As Integer
   Public Property RazonSocial() As String
End Class
