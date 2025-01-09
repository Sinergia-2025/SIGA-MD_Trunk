Public Class CuentaCorrienteProvRetencion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdProveedor
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdTipoImpuesto
      EmisorRetencion
      NumeroRetencion
      TipoRetencion
      SecuenciaRetencion
   End Enum

#Region "Propiedades"

   Private _cuentaCorrienteProv As Entidades.CuentaCorrienteProv
   Public Property CuentaCorrienteProv() As Entidades.CuentaCorrienteProv
      Get
         Return _cuentaCorrienteProv
      End Get
      Set(ByVal value As Entidades.CuentaCorrienteProv)
         _cuentaCorrienteProv = value
      End Set
   End Property

   Private _retencion As Entidades.Retencion
   Public Property Retencion() As Entidades.Retencion
      Get
         Return _retencion
      End Get
      Set(ByVal value As Entidades.Retencion)
         _retencion = value
      End Set
   End Property

#End Region

End Class
