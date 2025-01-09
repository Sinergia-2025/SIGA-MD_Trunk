<Serializable()> _
Public Class TipoImpuesto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoImpuesto
      NombreTipoImpuesto
      Tipo
      IdCuentaCaja
      IdCuentaDebe
      IdCuentaHaber
      AplicativoAfip
      CodigoArticuloInciso
      ArticuloInciso
   End Enum

   Public Enum Tipos
      Ninguno
      IIBB
      IVA
      PGANA
      PIIBB
      PIVA
      PVAR
      RDREI
      RGANA
      RIIBB
      RIIBC
      RIVA
      RSIJP
      RSUSS
      RSELL
      RVAR
      IMINT
   End Enum

#Region "Propiedades"

   Private _idTipoImpuesto As Tipos
   Public Property IdTipoImpuesto() As Tipos
      Get
         Return Me._idTipoImpuesto
      End Get
      Set(ByVal value As Tipos)
         Me._idTipoImpuesto = value
      End Set
   End Property

   Private _nombreTipoImpuesto As String
   Public Property NombreTipoImpuesto() As String
      Get
         Return Me._nombreTipoImpuesto
      End Get
      Set(ByVal value As String)
         Me._nombreTipoImpuesto = value
      End Set
   End Property

   Private _tipo As String
   Public Property Tipo() As String
      Get
         Return Me._tipo
      End Get
      Set(ByVal value As String)
         Me._tipo = value
      End Set
   End Property

   '' ''Private _entidadCuentas As List(Of Entidades.ucCuentaDHvb)
   '' ''Public Property entidadCuentas() As List(Of Entidades.ucCuentaDHvb)
   '' ''   Get
   '' ''      If Me._entidadCuentas Is Nothing Then
   '' ''         Me._entidadCuentas = New List(Of Entidades.ucCuentaDHvb)()
   '' ''      End If
   '' ''      Return _entidadCuentas
   '' ''   End Get
   '' ''   Set(ByVal value As List(Of Entidades.ucCuentaDHvb))
   '' ''      _entidadCuentas = value
   '' ''   End Set
   '' ''End Property

   'vml 10/06/13 - contabilidad
   '' ''Private _idCuentaDebe As Long
   '' ''Public Property IdCuentaDebe() As Long
   '' ''   Get
   '' ''      Return CuentaCompras.IdCuenta
   '' ''   End Get
   '' ''   Set(ByVal value As Long)
   '' ''      CuentaCompras.IdCuenta = value
   '' ''   End Set
   '' ''End Property

   Private _cuentaCompras As ContabilidadCuenta
   Public Property CuentaCompras() As ContabilidadCuenta
      Get
         If _cuentaCompras Is Nothing Then _cuentaCompras = New ContabilidadCuenta()
         Return _cuentaCompras
      End Get
      Set(ByVal value As ContabilidadCuenta)
         _cuentaCompras = value
      End Set
   End Property


   'vml 10/06/13  - contabilidad
   '' ''Private _idCuentaHaber As Integer
   '' ''Public Property idCuentaHaber() As Integer
   '' ''   Get
   '' ''      Return CuentaVentas.IdCuenta
   '' ''   End Get
   '' ''   Set(ByVal value As Integer)
   '' ''      CuentaVentas.IdCuenta = value
   '' ''   End Set
   '' ''End Property

   Private _cuentaVentas As ContabilidadCuenta
   Public Property CuentaVentas() As ContabilidadCuenta
      Get
         If _cuentaVentas Is Nothing Then _cuentaVentas = New ContabilidadCuenta()
         Return _cuentaVentas
      End Get
      Set(ByVal value As ContabilidadCuenta)
         _cuentaVentas = value
      End Set
   End Property


   Private _idCuentaCaja As Integer
   Public Property IdCuentaCaja() As Integer
      Get
         Return _idCuentaCaja
      End Get
      Set(ByVal value As Integer)
         _idCuentaCaja = value
      End Set
   End Property

   Private _aplicativoAfip As String
   Public Property AplicativoAfip() As String
      Get
         Return Me._aplicativoAfip
      End Get
      Set(ByVal value As String)
         Me._aplicativoAfip = value
      End Set
   End Property

   Private _codigoArticuloInciso As String
   Public Property CodigoArticuloInciso() As String
      Get
         Return Me._codigoArticuloInciso
      End Get
      Set(ByVal value As String)
         Me._codigoArticuloInciso = value
      End Set
   End Property

   Private _articuloInciso As String
   Public Property ArticuloInciso() As String
      Get
         Return Me._articuloInciso
      End Get
      Set(ByVal value As String)
         Me._articuloInciso = value
      End Set
   End Property
#End Region

   Public Function GetCopia() As Entidades.TipoImpuesto
      Dim copia As Entidades.TipoImpuesto = New Entidades.TipoImpuesto()
      With copia
         .IdSucursal = Me.IdSucursal
         .IdTipoImpuesto = Me._idTipoImpuesto
         .NombreTipoImpuesto = Me._nombreTipoImpuesto
         .Password = Me.Password
         .Tipo = Me._tipo
         .Usuario = Me.Usuario


         'vml 10/06/13
         '' ''.IdCuentaDebe = Me._idCuentaDebe
         '' ''.idCuentaHaber = Me._idCuentaHaber
         .CuentaVentas = Me._cuentaVentas
         .CuentaCompras = Me.CuentaCompras
         .IdCuentaCaja = Me._idCuentaCaja
      End With
      Return copia
   End Function

End Class
