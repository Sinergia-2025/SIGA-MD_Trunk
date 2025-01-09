<Serializable()>
Public Class VentaImpuesto
   Inherits Entidad

   Public Sub New()
      Venta = New Venta()
      TipoComprobante = New TipoComprobante()
      TipoImpuesto = New TipoImpuesto()
   End Sub
   Public Sub New(tipoImpuesto As TipoImpuesto, importe As Decimal, alicuota As Decimal)
      Me.New()
      _TipoImpuesto = tipoImpuesto
      _Importe = importe
      _Alicuota = alicuota
   End Sub
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdTipoImpuesto
      Alicuota
      Bruto
      Neto
      Importe
      Total
      IdProvincia
      IdRegimenPercepcion
   End Enum

#Region "Propiedades"

   Public Property Venta As Venta
   Public Property TipoComprobante As TipoComprobante
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property TipoImpuesto As TipoImpuesto
   Public Property Alicuota As Decimal
   Public Property Bruto As Decimal
   Public Property Neto As Decimal
   Public Property Importe As Decimal
   Public Property Total As Decimal
   Public Property IdProvincia As String
   Public Property IdRegimenPercepcion As Integer

   Public Property IdActividad As Integer             'No se guarda en BD, solo para poder guardar al final la percepcion.

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdTipoImpuesto() As TipoImpuesto.Tipos
      Get
         Return _TipoImpuesto.IdTipoImpuesto
      End Get
   End Property
#End Region

#End Region

End Class