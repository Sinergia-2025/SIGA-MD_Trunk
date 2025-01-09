<Serializable()>
Public Class Empleado
   Inherits Entidad

   Public Const NombreTabla As String = "Empleados"

   Public Enum Columnas
      TipoDocEmpleado
      NroDocEmpleado
      NombreEmpleado
      TelefonoEmpleado
      CelularEmpleado
      EsVendedor
      EsComprador
      IdUsuario
      ComisionPorVenta
      Direccion
      IdLocalidad
      GeoLocalizacionLat
      GeoLocalizacionLng
      IdEmpleado
      Color
      NivelAutorizacion
      Clave
      DebitoDirecto
      IdBanco
      NombreBanco
      IdDispositivo
      EsCobrador
      IdUsuarioMovil
      '-.PE-31509.-
      DebitoTarjeta
      IdTarjeta
      NombreTarjeta
      '-- REQ-33530.- --
      EsChofer
      IdTransportista
      '-- REQ-37326.- --
      EsRespProd
      '-- REQ-38946.- --
      IdCategoriaEmpleado
      ValorHoraProduccion
      '-- REQ-42860.- --
      CobraPremioCobranza
      '-- REQ-43851.- --
      EntidadCobranza
      '-----------------

   End Enum
   Public Enum Tipo
      <Description("Vendedor")> Vendedor
      <Description("Cobrador")> Cobrador
   End Enum

   Public Sub New()
      Comisiones = New DataSet()

      Dim dt = New DataTable(ComisionesMarcasTableName)
      dt.Columns.Add("IdMarca", GetType(Integer))
      dt.Columns.Add("NombreMarca", GetType(String))
      dt.Columns.Add("Comision", GetType(Decimal))
      dt.Columns.Add("IdEmpleado", GetType(Integer))
      Comisiones.Tables.Add(dt)
      dt = New DataTable(ComisionesProductosTableName)
      dt.Columns.Add("IdProducto", GetType(String))
      dt.Columns.Add("NombreProducto", GetType(String))
      dt.Columns.Add("Comision", GetType(Decimal))
      dt.Columns.Add("IdEmpleado", GetType(Integer))
      Comisiones.Tables.Add(dt)
      dt = New DataTable(ComisionesRubrosTableName)
      dt.Columns.Add("IdRubro", GetType(Integer))
      dt.Columns.Add("NombreRubro", GetType(String))
      dt.Columns.Add("Comision", GetType(Decimal))
      dt.Columns.Add("IdEmpleado", GetType(Integer))
      Comisiones.Tables.Add(dt)
      dt = New DataTable(ComisionesSubRubrosTableName)
      dt.Columns.Add("IdRubro", GetType(Integer))
      dt.Columns.Add("NombreRubro", GetType(String))
      dt.Columns.Add("IdSubRubro", GetType(Integer))
      dt.Columns.Add("NombreSubRubro", GetType(String))
      dt.Columns.Add("Comision", GetType(Decimal))
      dt.Columns.Add("IdEmpleado", GetType(Integer))
      Comisiones.Tables.Add(dt)
      dt = New DataTable(ComisionesSubSubRubrosTableName)
      dt.Columns.Add("IdRubro", GetType(Integer))
      dt.Columns.Add("IdSubRubro", GetType(Integer))
      dt.Columns.Add("IdSubSubRubro", GetType(Integer))
      dt.Columns.Add("NombreSubSubRubro", GetType(String))
      dt.Columns.Add("Comision", GetType(Decimal))
      dt.Columns.Add("IdEmpleado", GetType(Integer))
      Comisiones.Tables.Add(dt)
   End Sub

#Region "Campos"

   Public Const ComisionesRubrosTableName As String = "ComisionesRubros"
   Public Const ComisionesMarcasTableName As String = "ComisionesMarcas"
   Public Const ComisionesProductosTableName As String = "ComisionesProductos"

   Public Const ComisionesSubRubrosTableName As String = "ComisionesSubRubros"
   Public Const ComisionesSubSubRubrosTableName As String = "ComisionesSubSubRubros"

#End Region

#Region "Propiedades"

   Public Property TipoDocEmpleado As String = ""
   Public Property NroDocEmpleado As String = ""
   Private _nombreEmpleado As String = ""
   Public Property NombreEmpleado() As String
      Get
         Return Me._nombreEmpleado
      End Get
      Set(ByVal value As String)
         If value.Length > 100 Then
            Throw New Exception("El ancho del nombre del Empleado no puede exceder los 100 caracteres")
         Else
            Me._nombreEmpleado = value
         End If
      End Set
   End Property
   Private _telefonoEmpleado As String = ""
   Public Property TelefonoEmpleado() As String
      Get
         Return Me._telefonoEmpleado
      End Get
      Set(ByVal value As String)
         If value.Length > 100 Then
            Throw New Exception("El ancho del telefono del Empleado no puede exceder los 100 caracteres")
         Else
            Me._telefonoEmpleado = value
         End If
      End Set
   End Property
   Public Property CelularEmpleado As String = ""
   Public Property EsVendedor As Boolean = False
   Public Property EsComprador As Boolean = False
   Public Property EsCobrador As Boolean
   Public Property EsChofer As Boolean
   Public Property EsRespProd As Boolean
   Public Property IdTransportista As Integer = 0
   Public Property EntidadCobranza As String

   Public Property IdUsuario As String = ""
   Public Property IdUsuarioMovil As String = ""
   Public Property ComisionPorVenta As Decimal
   Private _direccion As String = ""
   Public Property Direccion() As String
      Get
         Return Me._direccion
      End Get
      Set(ByVal value As String)
         If value.Length > 100 Then
            System.Windows.Forms.MessageBox.Show("El ancho de la dirección no puede exceder los 100 caracteres")
            Throw New Exception("El ancho de la dirección no puede exceder los 100 caracteres")
         Else
            Me._direccion = value.Trim()
         End If
      End Set
   End Property
   Public Property IdLocalidad As Integer = 0
   Public Property GeoLocalizacionLat As Double
   Public Property GeoLocalizacionLng As Double

   Public Property Comisiones As DataSet

   Public Property IdEmpleado As Integer
   Public Property Color As Integer?
   Public Property NivelAutorizacion As Short = 1

   Public Property Clave As String

   Private _EmpleadoObjetivo As List(Of EmpleadoObjetivo)
   Public Property EmpleadoObjetivo As List(Of EmpleadoObjetivo)
      Get
         If _EmpleadoObjetivo Is Nothing Then _EmpleadoObjetivo = New List(Of EmpleadoObjetivo)()
         Return _EmpleadoObjetivo
      End Get
      Set(value As List(Of EmpleadoObjetivo))
         _EmpleadoObjetivo = value
      End Set
   End Property

   Public Property DebitoDirecto As Boolean
   Public Property IdBanco As Integer
   Public Property NombreBanco As String
   Public Property IdDispositivo As String

   '-.PE-31509.-
   Public Property DebitoTarjeta As Boolean
   Public Property IdTarjeta As Integer
   Public Property NombreTarjeta As String

   Private _EmpleadoSucursal As Eniac.Entidades.EmpleadoSucursal
   Public Property EmpleadoSucursal As EmpleadoSucursal
      Get
         If Me._EmpleadoSucursal Is Nothing Then
            Me._EmpleadoSucursal = New Eniac.Entidades.EmpleadoSucursal()
         End If
         Return _EmpleadoSucursal
      End Get
      Set(ByVal value As EmpleadoSucursal)
         _EmpleadoSucursal = value
      End Set
   End Property

   Public Property IdCategoriaEmpleado As Integer
   Public Property ValorHoraProduccion As Decimal

   '-- REQ-42860.- ------------------------------
   Public Property CobraPremioCobranza As Boolean
   '---------------------------------------------
#Region "Propiedades EmpleadoSucursal"
   Public Property IdCaja() As Integer?
      Get
         Return EmpleadoSucursal.IdCaja
      End Get
      Set(ByVal value As Integer?)
         EmpleadoSucursal.IdCaja = value
      End Set
   End Property

   Public Property Observacion() As String
      Get
         Return EmpleadoSucursal.Observacion
      End Get
      Set(ByVal value As String)
         EmpleadoSucursal.Observacion = value
      End Set
   End Property

#End Region


#End Region

   Public Enum TipoEntidadCobranza
      <Description("NINGUNO")> NINGUNO
      <Description("ROELA")> ROELA
      <Description("SIRPLUS")> SIRPLUS
   End Enum
End Class