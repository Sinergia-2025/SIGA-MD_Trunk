Public Class PercepcionVentas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Eniac.Datos.DataAccess)
      MyBase.New(Entidades.PercepcionVenta.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.PercepcionVenta), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.PercepcionVenta), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.PercepcionVenta), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.PercepcionVentas(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.PercepcionVentas(da).PercepcionVentas_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Friend Sub EjecutaSP(en As Entidades.PercepcionVenta, tipo As TipoSP)
      Dim sql = New SqlServer.PercepcionVentas(da)
      Select Case tipo
         Case TipoSP._I
            sql.PercepcionVentas_I(en.IdSucursal, en.TipoImpuesto.IdTipoImpuesto.ToString(), en.EmisorPercepcion, en.NumeroPercepcion,
                                   en.FechaEmision,
                                   en.BaseImponible, en.Alicuota, en.ImporteTotal,
                                   en.Caja.IdCaja, en.NroPlanillaIngreso, en.NroMovimientoIngreso,
                                   en.IdEstado,
                                   en.IdActividad, en.IdProvincia, en.Cliente.IdCliente,
                                   en.IdRegimenPercepcion)
         Case TipoSP._U
            sql.PercepcionVentas_U(en.IdSucursal, en.TipoImpuesto.IdTipoImpuesto.ToString(), en.EmisorPercepcion, en.NumeroPercepcion,
                                   en.FechaEmision,
                                   en.BaseImponible, en.Alicuota, en.ImporteTotal,
                                   en.Caja.IdCaja, en.NroPlanillaIngreso, en.NroMovimientoIngreso,
                                   en.IdEstado,
                                   en.IdActividad,
                                   en.Cliente.IdCliente,
                                   en.IdRegimenPercepcion)
         Case TipoSP._D
            sql.PercepcionVentas_D(en.IdSucursal, en.TipoImpuesto.IdTipoImpuesto.ToString(), en.EmisorPercepcion, en.NumeroPercepcion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.PercepcionVenta, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)("IdSucursal")

         .TipoImpuesto = New TiposImpuestos(da)._GetUno(dr.Field(Of String)("IdTipoImpuesto").StringToEnum(Entidades.TipoImpuesto.Tipos.IVA))
         .EmisorPercepcion = dr.Field(Of Integer)("EmisorPercepcion")
         .NumeroPercepcion = dr.Field(Of Long)("NumeroPercepcion")
         .FechaEmision = dr.Field(Of Date)("FechaEmision")

         .BaseImponible = dr.Field(Of Decimal)("BaseImponible")
         .Alicuota = dr.Field(Of Decimal)("Alicuota")
         .ImporteTotal = dr.Field(Of Decimal)("ImporteTotal")

         .NroPlanillaIngreso = dr.Field(Of Integer?)("NroPlanillaIngreso").IfNull()
         .NroMovimientoIngreso = dr.Field(Of Integer?)("NroMovimientoIngreso").IfNull()

         .Cliente = New Clientes(da)._GetUno(dr.Field(Of Long)("IdCliente"), False)

         .IdEstado = dr.Field(Of String)("IdEstado").StringToEnum(Entidades.Retencion.Estados.APLICADO)

         .IdActividad = dr.Field(Of Integer)("IdActividad")
         .IdProvincia = dr.Field(Of String)("IdProvincia")

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.PercepcionVenta)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PercepcionVenta())
   End Function

   Public Function GetUno(idSucursal As Integer, idTipoImpuesto As String, emisorPercepcion As Integer, numeroPercepcion As Long) As Entidades.PercepcionVenta
      Return EjecutaConConexion(Function() _GetUno(idSucursal, idTipoImpuesto, emisorPercepcion, numeroPercepcion))
   End Function

   Friend Function _GetUno(idSucursal As Integer, idTipoImpuesto As String, emisorPercepcion As Integer, numeroPercepcion As Long) As Entidades.PercepcionVenta
      Return _GetUno(idSucursal, idTipoImpuesto, emisorPercepcion, numeroPercepcion, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Friend Function _GetUno(idSucursal As Integer, idTipoImpuesto As String, emisorPercepcion As Integer, numeroPercepcion As Long,
                           accion As AccionesSiNoExisteRegistro) As Entidades.PercepcionVenta
      Return CargaEntidad(New SqlServer.PercepcionVentas(da).PercepcionVentas_G1(idSucursal, idTipoImpuesto, emisorPercepcion, numeroPercepcion),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PercepcionVenta(),
                          accion, Function() "No existe la Percepcion Venta.")
   End Function

   Public Function GetPorVentasPercepciones(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                            idCliente As Long) As List(Of Entidades.PercepcionVenta)
      Return CargaLista(New SqlServer.PercepcionVentas(da).GetPorVentasPercepciones(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PercepcionVenta())
   End Function

   Public Function GetProximoNumero(idSucursal As Integer, idTipoImpuesto As Entidades.TipoImpuesto.Tipos, emisorRetencion As Integer) As Integer
      Return New SqlServer.PercepcionVentas(da).GetCodigoMaximo(idSucursal, idTipoImpuesto, emisorRetencion) + 1
   End Function

   Public Function GetTodos(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date,
                            idTipoImpuesto As String, idCliente As Long, idProvincia As String) As DataTable
      Return New SqlServer.PercepcionVentas(da).
                     GetTodos(idSucursal, fechaDesde, fechaHasta,
                              idTipoImpuesto, idCliente, idProvincia)
   End Function

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As List(Of Entidades.PercepcionVenta)
      Using dt = New SqlServer.PercepcionVentas(da).GetTodos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
         Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PercepcionVenta())
      End Using
   End Function

#End Region

End Class