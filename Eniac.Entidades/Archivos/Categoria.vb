<Serializable()>
Public Class Categoria
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCategoria
      NombreCategoria
      IdGrupoCategoria
      DescuentoRecargo
      IdCaja
      IdTipoComprobante
      IdCuenta
      IdInteres
      IdCuentaSecundaria
      IdProducto
      NombreProducto
      IdInteresCuotas
      RequiereRevisionAdministrativa
      ControlaBackup
      NivelAutorizacion
      'ActualizarVersion
      ActualizarAplicacion
      Comisiones
      'NuevosCampos SiSeN
      FirmaMandato
      AdquiereAcciones
      AdquiereCamas
      PideConyuge
      TPFisicaDatosAdicionales
      PideEmbarcacion
      PerteneceAlComplejo
      PagaExpensas
      PagaAlquiler
      ImporteGastosAdmin
      IdCategoriaInversionista
      LimiteMesesDeudaBotado
      BackColor
      ForeColor

   End Enum
   Public Sub New()
      DescuentoRecargoPorc1 = New DataSet()
      Dim dt As DataTable

      dt = New DataTable(DescuentosRubrosTableName)
      dt.Columns.Add("IdRubro", GetType(Integer))
      dt.Columns.Add("NombreRubro", GetType(String))
      dt.Columns.Add("DescuentoRecargoPorc1", GetType(Decimal))
      DescuentoRecargoPorc1.Tables.Add(dt)

      dt = New DataTable(DescuentosSubRubrosTableName)
      dt.Columns.Add("IdSubRubro", GetType(Integer))
      dt.Columns.Add("NombreSubRubro", GetType(String))
      dt.Columns.Add("IdRubro", GetType(Integer))
      dt.Columns.Add("NombreRubro", GetType(String))
      dt.Columns.Add("DescuentoRecargoPorc1", GetType(Decimal))
      DescuentoRecargoPorc1.Tables.Add(dt)

      dt = New DataTable(DescuentosSubSubRubrosTableName)
      dt.Columns.Add("IdSubSubRubro", GetType(Integer))
      dt.Columns.Add("NombreSubSubRubro", GetType(String))
      dt.Columns.Add("IdSubRubro", GetType(Integer))
      dt.Columns.Add("NombreSubRubro", GetType(String))
      dt.Columns.Add("IdRubro", GetType(Integer))
      dt.Columns.Add("NombreRubro", GetType(String))
      dt.Columns.Add("DescuentoRecargoPorc1", GetType(Decimal))
      DescuentoRecargoPorc1.Tables.Add(dt)
   End Sub
   Private _descuentoRecargoPorc1 As DataSet
   Public Const DescuentosRubrosTableName As String = "CategoriasDescuentosRubros"
   Public Const DescuentosSubRubrosTableName As String = "CategoriasDescuentosSubRubros"
   Public Const DescuentosSubSubRubrosTableName As String = "CategoriasDescuentosSubSubRubros"
#Region "Propiedades"

   Private _idCategoria As Integer
   Public Property IdCategoria() As Integer
      Get
         Return _idCategoria
      End Get
      Set(value As Integer)
         _idCategoria = value
      End Set
   End Property

   Private _nombreCategoria As String
   Public Property NombreCategoria() As String
      Get
         Return _nombreCategoria
      End Get
      Set(value As String)
         _nombreCategoria = value
      End Set
   End Property

   Private _idGrupoCategoria As String
   Public Property IdGrupoCategoria() As String
      Get
         Return _idGrupoCategoria
      End Get
      Set(value As String)
         _idGrupoCategoria = value
      End Set
   End Property

   Private _descuentoRecargo As Decimal
   Public Property DescuentoRecargo() As Decimal
      Get
         Return _descuentoRecargo
      End Get
      Set(value As Decimal)
         _descuentoRecargo = value
      End Set
   End Property

   Private _idCaja As Integer
   Public Property IdCaja() As Integer
      Get
         Return _idCaja
      End Get
      Set(value As Integer)
         _idCaja = value
      End Set
   End Property

   Private _idTipoComprobante As String
   Public Property IdTipoComprobante() As String
      Get
         Return Me._idTipoComprobante
      End Get
      Set(value As String)
         Me._idTipoComprobante = value
      End Set
   End Property

   Private _cuenta As ContabilidadCuenta
   Public Property Cuenta() As ContabilidadCuenta
      Get
         Return _cuenta
      End Get
      Set(value As ContabilidadCuenta)
         _cuenta = value
      End Set
   End Property

   Public Property CuentaSecundaria() As ContabilidadCuenta

   Public Property Interes() As Interes
   Public ReadOnly Property IdInteres() As Integer
      Get
         If Interes Is Nothing Then Return 0
         Return Interes.IdInteres
      End Get
   End Property

   Private _idProducto As String
   Public Property IdProducto() As String
      Get
         Return _idProducto
      End Get
      Set(value As String)
         _idProducto = value
      End Set
   End Property

   Private _nombreProducto As String
   Public Property NombreProducto() As String
      Get
         Return _nombreProducto
      End Get
      Set(value As String)
         _nombreProducto = value
      End Set
   End Property

   Public Property InteresCuotas() As Interes
   Public ReadOnly Property IdInteresCuotas() As Integer
      Get
         If InteresCuotas Is Nothing Then Return 0
         Return InteresCuotas.IdInteres
      End Get
   End Property

   Private _requiereRevisionAdministrativa As Boolean
   Public Property RequiereRevisionAdministrativa() As Boolean
      Get
         Return _requiereRevisionAdministrativa
      End Get
      Set(value As Boolean)
         _requiereRevisionAdministrativa = value
      End Set
   End Property
   Public Property DescuentoRecargoPorc1() As DataSet
      Get
         Return _descuentoRecargoPorc1
      End Get
      Set(value As DataSet)
         _descuentoRecargoPorc1 = value
      End Set
   End Property
   Private _controlaBackup As Boolean
   Public Property ControlaBackup() As Boolean
      Get
         Return _controlaBackup
      End Get
      Set(value As Boolean)
         _controlaBackup = value
      End Set
   End Property
   Public Property NivelAutorizacion As Short

   'Public Property ActualizarVersion As Boolean

   Public Property ActualizarAplicacion As Boolean
   Public Property Comisiones As Decimal

   'Nuevos Campos SiSeN
   Private _firmaMandato As Boolean
   Public Property FirmaMandato() As Boolean
      Get
         Return _firmaMandato
      End Get
      Set(value As Boolean)
         _firmaMandato = value
      End Set
   End Property

   Private _AdquiereAcciones As String
   Public Property AdquiereAcciones() As String
      Get
         Return _AdquiereAcciones
      End Get
      Set(value As String)
         _AdquiereAcciones = value
      End Set
   End Property

   Private _AdquiereCamas As String
   Public Property AdquiereCamas() As String
      Get
         Return _AdquiereCamas
      End Get
      Set(value As String)
         _AdquiereCamas = value
      End Set
   End Property

   Private _pideConyuge As Boolean
   Public Property PideConyuge() As Boolean
      Get
         Return _pideConyuge
      End Get
      Set(value As Boolean)
         _pideConyuge = value
      End Set
   End Property

   Private _TPFisicaDatosAdicionales As Boolean
   Public Property TPFisicaDatosAdicionales() As Boolean
      Get
         Return _TPFisicaDatosAdicionales
      End Get
      Set(value As Boolean)
         _TPFisicaDatosAdicionales = value
      End Set
   End Property

   Private _PideEmbarcacion As String
   Public Property PideEmbarcacion() As String
      Get
         Return _PideEmbarcacion
      End Get
      Set(value As String)
         _PideEmbarcacion = value
      End Set
   End Property
   Public Property PerteneceAlComplejo() As Boolean

   Private _pagaExpensas As Boolean = False
   Public Property PagaExpensas() As Boolean
      Get
         Return _pagaExpensas
      End Get
      Set(value As Boolean)
         _pagaExpensas = value
      End Set
   End Property

   Private _pagaAlquiler As Boolean = False
   Public Property PagaAlquiler() As Boolean
      Get
         Return _pagaAlquiler
      End Get
      Set(value As Boolean)
         _pagaAlquiler = value
      End Set
   End Property

   Private _ImporteGastosAdmin As Decimal
   Public Property ImporteGastosAdmin() As Decimal
      Get
         Return _ImporteGastosAdmin
      End Get
      Set(value As Decimal)
         _ImporteGastosAdmin = value
      End Set
   End Property

   Private _idCategoriaInversionista As Integer?
   Public Property IdCategoriaInversionista() As Integer?
      Get
         Return _idCategoriaInversionista
      End Get
      Set(value As Integer?)
         _idCategoriaInversionista = value
      End Set
   End Property
   Public Property LimiteMesesDeudaBotado As Integer?

   Public Property BackColor As Integer?
   Public Property ForeColor As Integer?

#End Region

End Class