<Serializable()>
Public Class Retencion
   Inherits Entidad

   Public Const NombreTabla As String = "Retenciones"

   Public Enum Estados
      APLICADO
   End Enum

   Public Enum Columnas
      IdRetencion
      IdSucursal
      IdTipoImpuesto
      NombreTipoImpuesto
      EmisorRetencion
      NumeroRetencion
      FechaEmision
      BaseImponible
      Alicuota
      ImporteTotal
      IdCajaIngreso
      NroPlanillaIngreso
      NroMovimientoIngreso
      IdEstado
      IdCliente
      IdProvincia
      IdLocalidad
   End Enum

   Public Sub New()
      TipoImpuesto = New TipoImpuesto()
      CajaIngreso = New Caja()
      Cliente = New Cliente()
      Provincia = New Provincia()
      Localidad = New Localidad()
   End Sub

   Public Property IdRetencion As Integer
   Public Property TipoImpuesto As TipoImpuesto
   Public Property EmisorRetencion As Integer
   Public Property NumeroRetencion As Long
   Public Property FechaEmision As Date
   Public Property BaseImponible As Decimal
   Public Property Alicuota As Decimal
   Public Property ImporteTotal As Decimal

   Public Property CajaIngreso As Caja
   Public Property NroPlanillaIngreso As Integer
   Public Property NroMovimientoIngreso As Integer

   Public Property Cliente As Cliente

   Public Property IdEstado() As Estados

   Public Property Provincia As Provincia
   Public Property Localidad() As Localidad


#Region "Propiedades Readonly"

   Public ReadOnly Property IdTipoImpuesto() As TipoImpuesto.Tipos
      Get
         Return TipoImpuesto.IdTipoImpuesto
      End Get
   End Property

   Public ReadOnly Property NombreTipoImpuesto() As String
      Get
         Return TipoImpuesto.NombreTipoImpuesto
      End Get
   End Property

   Public ReadOnly Property IdProvincia As String
      Get
         Return If(Provincia IsNot Nothing, Provincia.IdProvincia, String.Empty)
      End Get
   End Property

   Public ReadOnly Property NombreProvincia As String
      Get
         Return If(Provincia IsNot Nothing, Provincia.NombreProvincia, String.Empty)
      End Get
   End Property

   Public ReadOnly Property IdLocalidad As Integer
      Get
         Return Localidad.IdLocalidad
      End Get
   End Property

   Public ReadOnly Property NombreLocalidad As String
      Get
         Return Localidad.NombreLocalidad
      End Get
   End Property

#End Region

End Class