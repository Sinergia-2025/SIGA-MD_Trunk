<Serializable()>
Public Class PercepcionVenta
   Inherits Entidad

   Public Const NombreTabla As String = "PercepcionVentas"

   Public Enum Columnas
      IdSucursal
      IdTipoImpuesto
      EmisorPercepcion
      NumeroPercepcion
      FechaEmision
      BaseImponible
      Alicuota
      ImporteTotal
      IdCajaIngreso
      NroPlanillaIngreso
      NroMovimientoIngreso
      IdEstado
      IdActividad
      IdProvincia
      IdRegimenPercepcion

   End Enum

   Public Sub New()
      TipoImpuesto = New TipoImpuesto()
      Caja = New Caja()
      Cliente = New Cliente()
      RegimenPercepcion = New RegimenPercepcion()
   End Sub

#Region "Propiedades"

   Public Property TipoImpuesto As TipoImpuesto
   Public Property EmisorPercepcion As Integer
   Public Property NumeroPercepcion As Long
   Public Property FechaEmision As Date
   Public Property BaseImponible As Decimal
   Public Property Alicuota As Decimal
   Public Property ImporteTotal As Decimal
   Public Property NroPlanillaIngreso As Integer
   Public Property Caja As Caja
   Public Property NroMovimientoIngreso As Integer
   Public Property IdEstado As Retencion.Estados
   Public Property Cliente As Cliente
   Public Property IdActividad As Integer
   Public Property IdProvincia As String
   Public Property RegimenPercepcion As RegimenPercepcion

#End Region

#Region "Propiedades Readonly"

   Public ReadOnly Property IdTipoImpuesto() As String
      Get
         Return TipoImpuesto.IdTipoImpuesto.ToString()
      End Get
   End Property
   Public ReadOnly Property NombreTipoImpuesto() As String
      Get
         Return TipoImpuesto.NombreTipoImpuesto
      End Get
   End Property
   Public ReadOnly Property IdRegimenPercepcion() As Integer
      Get
         Return RegimenPercepcion.IdRegimenPercepcion
      End Get
   End Property
   Public ReadOnly Property NombreRegimenPercepcion() As String
      Get
         Return RegimenPercepcion.NombreRegimenPercepcion
      End Get
   End Property

#End Region

End Class