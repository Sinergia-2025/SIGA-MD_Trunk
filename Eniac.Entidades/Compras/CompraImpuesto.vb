Public Class CompraImpuesto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdProveedor
      IdTipoImpuesto
      Orden
      IdProvincia
      Emisor
      Numero
      Bruto
      BaseImponible
      Alicuota
      Importe
      EsDespacho
   End Enum

   Public Sub New()
      EsDespacho = False
   End Sub

   Public Sub New(idTipoImpuesto As String, importe As Decimal, alicuota As Decimal)
      Me.New()
      _IdTipoImpuesto = idTipoImpuesto
      _Importe = importe
      _Alicuota = alicuota
   End Sub

   Public Sub New(idTipoImpuesto As String, baseImponible As Decimal, importe As Decimal, alicuota As Decimal)
      Me.New(idTipoImpuesto, importe, alicuota)
      _BaseImponible = baseImponible
   End Sub

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property IdProveedor As Long
   Public Property IdTipoImpuesto As String
   Public Property Orden As Integer
   Public Property IdProvincia As String
   Public Property NombreProvincia As String
   Public Property Emisor As Integer
   Public Property Numero As Long

   Public Property Bruto As Decimal
   Public Property BaseImponible As Decimal
   Public Property Alicuota As Decimal
   Public Property Importe As Decimal
   Public Property Importe_Calculado As Decimal
   Public ReadOnly Property ImporteTotal As Decimal   'De momento no lo persisto, veo más adelante
      Get
         Return BaseImponible + Importe
      End Get
   End Property

   Public Property NombreProveedor As String
   Public Property NombreTipoImpuesto As String
   Public Property TipoTipoImpuesto As String

   Public Property EsDespacho As Boolean

End Class