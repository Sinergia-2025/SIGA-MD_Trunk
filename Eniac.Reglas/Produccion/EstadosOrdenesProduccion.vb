Public Class EstadosOrdenesProduccion
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("EstadosOrdenesProduccion", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoOrdenProduccion), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoOrdenProduccion), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoOrdenProduccion), TipoSP._D))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.EstadosOrdenesProduccion(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.EstadosOrdenesProduccion(da).EstadosOrdenesProduccion_GA()
   End Function

   Public Function GetEstados(agregarTODOS As Boolean, agregarSOLOPendientes As Boolean, agregarSOLOEnProceso As Boolean, agregarAnulado As Boolean, tipoEstado As String) As DataTable
      Return New SqlServer.EstadosOrdenesProduccion(da).GetEstados(agregarTODOS, agregarSOLOPendientes, agregarSOLOEnProceso, agregarAnulado, tipoEstado)
   End Function
   Public Function GetTiposEstados() As DataTable
      Return New SqlServer.EstadosOrdenesProduccion(da).GetTiposEstados()
   End Function

   Public Function GetIdEstadosXTipo(tipo As String) As DataTable
      Return New SqlServer.EstadosOrdenesProduccion(da).GetIdEstadosXTipo(tipo)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.EstadoOrdenProduccion, tipo As TipoSP)
      Dim sql = New SqlServer.EstadosOrdenesProduccion(da)
      Dim rEstOrdProdSuc = New EstadosOrdenesProduccionSucursales(da)

      Select Case tipo
         Case TipoSP._I
            sql.EstadosOrdenesProduccion_I(en.IdEstado, en.IdTipoComprobante, en.IdTipoEstado, en.Orden, en.Color, en.ReservaMateriaPrima, en.GeneraProductoTerminado,
                                           en.TipoEstadoPedido, en.IdEstadoPedido)
            rEstOrdProdSuc._Merge(en)
         Case TipoSP._U
            sql.EstadosOrdenesProduccion_U(en.IdEstado, en.IdTipoComprobante, en.IdTipoEstado, en.Orden, en.Color, en.ReservaMateriaPrima, en.GeneraProductoTerminado,
                                           en.TipoEstadoPedido, en.IdEstadoPedido)
            rEstOrdProdSuc._Merge(en)
         Case TipoSP._D
            en.IdSucursal = actual.Sucursal.Id
            rEstOrdProdSuc._Borrar(en)
            sql.EstadosOrdenesProduccion_D(en.IdEstado)
      End Select
   End Sub

   Private Sub CargarUna(o As Entidades.EstadoOrdenProduccion, dr As DataRow)
      With o
         .IdEstado = dr.Field(Of String)(Entidades.EstadoOrdenProduccion.Columnas.IdEstado.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.EstadoOrdenProduccion.Columnas.IdTipoComprobante.ToString()).IfNull()
         .IdTipoEstado = dr.Field(Of String)(Entidades.EstadoOrdenProduccion.Columnas.IdTipoEstado.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.EstadoOrdenProduccion.Columnas.Orden.ToString())

         .Color = dr.Field(Of Integer)(Entidades.EstadoOrdenProduccion.Columnas.Color.ToString())
         .ReservaMateriaPrima = dr.Field(Of Boolean)(Entidades.EstadoOrdenProduccion.Columnas.ReservaMateriaPrima.ToString())
         .GeneraProductoTerminado = dr.Field(Of Boolean)(Entidades.EstadoOrdenProduccion.Columnas.GeneraProductoTerminado.ToString())

         .TipoEstadoPedido = dr.Field(Of String)(Entidades.EstadoOrdenProduccion.Columnas.TipoEstadoPedido.ToString()).IfNull()
         .IdEstadoPedido = dr.Field(Of String)(Entidades.EstadoOrdenProduccion.Columnas.IdEstadoPedido.ToString()).IfNull()

         .IdDeposito = dr.Field(Of Integer?)(Entidades.EstadoOrdenProduccion.Columnas.IdDeposito.ToString()).IfNull()
         .IdUbicacion = dr.Field(Of Integer?)(Entidades.EstadoOrdenProduccion.Columnas.IdUbicacion.ToString()).IfNull()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.EstadoOrdenProduccion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoOrdenProduccion())
   End Function
   Public Function GetUno(idEstado As String) As Entidades.EstadoOrdenProduccion
      Return GetUno(idEstado, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idEstado As String, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoOrdenProduccion
      Return CargaEntidad(Get1(idEstado), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoOrdenProduccion(),
                          accion, Function() String.Format("No existe El Estado de Orden de Producción ´{0}´.", idEstado))
   End Function
   Public Function Get1(IdEstado As String) As DataTable
      Return New SqlServer.EstadosOrdenesProduccion(da).EstadosOrdenesProduccion_G1(IdEstado)
   End Function

   Public Function GetPorNombre(IdEstado As String) As DataTable
      Return New SqlServer.EstadosOrdenesProduccion(da).GetPorNombre(IdEstado)
   End Function

#End Region

End Class