<Serializable()>
Public Class Impuesto
   Inherits Entidad

   Public Enum Columnas
      IdTipoImpuesto
      Alicuota
      Activo
      IdCuentaCompras
      IdCuentaVentas
      IdTipoImpuestoPIVA
      AlicuotaPIVA
   End Enum

   Public Enum ColumnasDescripcion
      NombreCuentaCompras
      NombreCuentaVentas
   End Enum

#Region "Constructores"
   Public Sub New()
      CuentaCompras = New ContabilidadCuenta()
      CuentaVentas = New ContabilidadCuenta()
      PIVAAgregarSiNoExiste = False
   End Sub
   Public Sub New(idTipoImpuesto As String, alicuota As Decimal)
      Me.New(idTipoImpuesto, alicuota, activo:=True)
   End Sub
   Public Sub New(idTipoImpuesto As String, alicuota As Decimal, activo As Boolean)
      Me.New()
      Me.IdTipoImpuesto = idTipoImpuesto
      Me.Alicuota = alicuota
      Me.Activo = activo
   End Sub
#End Region

#Region "Propiedades"

   Public Property IdTipoImpuesto As String
   Public Property Alicuota As Decimal
   Public Property Activo As Boolean

   Public Property IdTipoImpuestoPIVA As String
   Public Property AlicuotaPIVA As Decimal?
   Public Property PIVAAgregarSiNoExiste As Boolean

   Public Property CuentaCompras As ContabilidadCuenta
   Public Property CuentaVentas As ContabilidadCuenta

#End Region

   Public ReadOnly Property IdCuentaCompras As Long?
      Get
         If CuentaCompras IsNot Nothing AndAlso CuentaCompras.IdCuenta > 0 Then
            Return CuentaCompras.IdCuenta
         End If
         Return Nothing
      End Get
   End Property
   Public ReadOnly Property IdCuentaVentas As Long?
      Get
         If CuentaVentas IsNot Nothing AndAlso CuentaVentas.IdCuenta > 0 Then
            Return CuentaVentas.IdCuenta
         End If
         Return Nothing
      End Get
   End Property

End Class