<Serializable()> _
Public Class RetencionCompra
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoImpuesto
      EmisorRetencion
      NumeroRetencion
      IdProveedor
      FechaEmision
      BaseImponible
      Alicuota
      ImporteTotal
      IdCajaEgreso
      NroPlanillaEgreso
      NroMovimientoEgreso
      IdEstado
      IdRegimen
      BaseImponibleCalculada
      ImporteTotalCalculado
      AjusteManual

   End Enum

#Region "Propiedades"

   Private _tipoImpuesto As Entidades.TipoImpuesto
   Public Property TipoImpuesto() As Entidades.TipoImpuesto
      Get
         If Me._tipoImpuesto Is Nothing Then
            Me._tipoImpuesto = New Entidades.TipoImpuesto()
         End If
         Return Me._tipoImpuesto
      End Get
      Set(ByVal value As Entidades.TipoImpuesto)
         Me._tipoImpuesto = value
      End Set
   End Property

   Private _emisorRetencion As Integer
   Public Property EmisorRetencion() As Integer
      Get
         Return Me._emisorRetencion
      End Get
      Set(ByVal value As Integer)
         Me._emisorRetencion = value
      End Set
   End Property

   Private _numeroRetencion As Long
   Public Property NumeroRetencion() As Long
      Get
         Return Me._numeroRetencion
      End Get
      Set(ByVal value As Long)
         Me._numeroRetencion = value
      End Set
   End Property

   Private _FechaEmision As Date
   Public Property FechaEmision() As Date
      Get
         Return Me._FechaEmision
      End Get
      Set(ByVal value As Date)
         Me._FechaEmision = value
      End Set
   End Property

   Private _baseImponible As Decimal
   Public Property BaseImponible() As Decimal
      Get
         Return Me._baseImponible
      End Get
      Set(ByVal value As Decimal)
         Me._baseImponible = value
      End Set
   End Property

   Private _alicuota As Decimal
   Public Property Alicuota() As Decimal
      Get
         Return Me._alicuota
      End Get
      Set(ByVal value As Decimal)
         Me._alicuota = value
      End Set
   End Property

   Private _importeTotal As Decimal
   Public Property ImporteTotal() As Decimal
      Get
         Return Me._importeTotal
      End Get
      Set(ByVal value As Decimal)
         Me._importeTotal = value
      End Set
   End Property

   Private _NroPlanillaEgreso As Integer
   Public Property NroPlanillaEgreso() As Integer
      Get
         Return Me._NroPlanillaEgreso
      End Get
      Set(ByVal value As Integer)
         Me._NroPlanillaEgreso = value
      End Set
   End Property

   Private _caja As Entidades.Caja
   Public Property Caja() As Entidades.Caja
      Get
         If Me._caja Is Nothing Then
            Me._caja = New Entidades.Caja()
         End If
         Return _caja
      End Get
      Set(ByVal value As Entidades.Caja)
         _caja = value
      End Set
   End Property


   Private _NroMovimientoEgreso As Integer
   Public Property NroMovimientoEgreso() As Integer
      Get
         Return Me._NroMovimientoEgreso
      End Get
      Set(ByVal value As Integer)
         Me._NroMovimientoEgreso = value
      End Set
   End Property

   Private _idEstado As Retencion.Estados
   Public Property IdEstado() As Retencion.Estados
      Get
         Return _idEstado
      End Get
      Set(ByVal value As Retencion.Estados)
         _idEstado = value
      End Set
   End Property

   Private _proveedor As Entidades.Proveedor
   Public Property Proveedor() As Entidades.Proveedor
      Get
         If Me._proveedor Is Nothing Then
            Me._proveedor = New Entidades.Proveedor()
         End If
         Return _proveedor
      End Get
      Set(ByVal value As Entidades.Proveedor)
         _proveedor = value
      End Set
   End Property

   Private _regimen As Entidades.Regimen
   Public Property Regimen() As Entidades.Regimen
      Get
         If Me._regimen Is Nothing Then
            Me._regimen = New Entidades.Regimen()
         End If
         Return _regimen
      End Get
      Set(ByVal value As Entidades.Regimen)
         _regimen = value
      End Set
   End Property

   Public Property AjusteManual As Boolean
   Public Property BaseImponibleCalculada As Decimal
   Public Property ImporteTotalCalculado As Decimal

   Public Property SecuenciaRetencion As Integer
#End Region

#Region "Propiedades Readonly"

   Public ReadOnly Property IdTipoImpuesto() As String
      Get
         Return Me._tipoImpuesto.IdTipoImpuesto.ToString()
      End Get
   End Property

   Public ReadOnly Property NombreTipoImpuesto() As String
      Get
         Return Me._tipoImpuesto.NombreTipoImpuesto
      End Get
   End Property

#End Region

End Class
