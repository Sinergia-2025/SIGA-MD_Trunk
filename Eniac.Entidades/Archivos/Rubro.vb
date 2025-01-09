<Serializable()> _
Public Class Rubro
   Inherits Entidad
   Implements IComboBoxMultipleSeleccionElement

   Public Const NombreTabla As String = "Rubros"

   Public Enum Columnas
      IdRubro
      NombreRubro
      IdProvincia
      IdActividad
      ComisionPorVenta
      UnidHasta1
      UnidHasta2
      UnidHasta3
      UnidHasta4
      UnidHasta5
      UHPorc1
      UHPorc2
      UHPorc3
      UHPorc4
      UHPorc5
      FechaActualizacionWeb
      Orden
      DescuentoRecargoPorc1
      DescuentoRecargoPorc2
      IdRubroTiendaNube
      IdRubroMercadoLibre
      idRubroArborea
      CodigoExportacion
      idCategoriaMercadoLibre


   End Enum

#Region "Propiedades"

   Public Property CodigoExportacion As String
   Public Property IdRubro() As Integer
   Public Property NombreRubro() As String

   Private _actividad As Entidades.Actividad
   Public Property Actividad() As Entidades.Actividad
      Get
         If Me._actividad Is Nothing Then
            Me._actividad = New Entidades.Actividad()
         End If
         Return _actividad
      End Get
      Set(ByVal value As Entidades.Actividad)
         _actividad = value
      End Set
   End Property

   Public Property ComisionPorVenta As Decimal
   Public Property UnidHasta1 As Decimal
   Public Property UnidHasta2 As Decimal
   Public Property UnidHasta3 As Decimal
   Public Property UnidHasta4 As Decimal
   Public Property UnidHasta5 As Decimal
   Public Property UHPorc1 As Decimal
   Public Property UHPorc2 As Decimal
   Public Property UHPorc3 As Decimal
   Public Property UHPorc4 As Decimal
   Public Property UHPorc5 As Decimal
   Public Property Orden As Integer
   Public Property DescuentoRecargoPorc1 As Decimal
   Public Property DescuentoRecargoPorc2 As Decimal
   Public Property IdRubroTiendaNube As String
   Public Property IdRubroMercadoLibre As String
   Public Property idRubroArborea As String
   Public Property idCategoriaMercadoLibre As String


#Region "Para Mostrar Comision Rubros Descuentos Recargo"
   Private _rubroComisionPorDescuento As List(Of RubroComisionPorDescuento)
   Public Property RubroComisionPorDescuento As List(Of RubroComisionPorDescuento)
      Get
         If _rubroComisionPorDescuento Is Nothing Then _rubroComisionPorDescuento = New List(Of RubroComisionPorDescuento)()
         Return _rubroComisionPorDescuento
      End Get
      Set(value As List(Of RubroComisionPorDescuento))
         _rubroComisionPorDescuento = value
      End Set
   End Property
#End Region

#End Region

#Region "Propiedades IComboBoxMultipleSeleccionElement"
   Private ReadOnly Property IComboBoxMultipleSeleccionElement_Id As String Implements IComboBoxMultipleSeleccionElement.Id
      Get
         Return IdRubro.ToString()
      End Get
   End Property

   Private ReadOnly Property IComboBoxMultipleSeleccionElement_Nombre As String Implements IComboBoxMultipleSeleccionElement.Nombre
      Get
         Return NombreRubro
      End Get
   End Property
#End Region

End Class