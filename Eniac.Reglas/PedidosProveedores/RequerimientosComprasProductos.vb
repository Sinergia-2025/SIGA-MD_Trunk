Public Class RequerimientosComprasProductos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.RequerimientoCompraProducto.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.RequerimientoCompraProducto)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.RequerimientoCompraProducto)))
   End Sub

   Public Sub Merge(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Merge(DirectCast(entidad, Entidades.RequerimientoCompraProducto)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.RequerimientoCompraProducto)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.RequerimientosComprasProductos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.RequerimientosComprasProductos(da).RequerimientosComprasProductos_GA()
   End Function
   Public Overloads Function GetAll(idRequerimientoCompra As Long) As DataTable
      Return New SqlServer.RequerimientosComprasProductos(da).RequerimientosComprasProductos_GA(idRequerimientoCompra)
   End Function

#End Region

#Region "Metodos Privados"
   Private Sub ValidaGrabacion(en As Entidades.RequerimientoCompraProducto, tipo As TipoSP)
      If {TipoSP._I, TipoSP._U, TipoSP._M}.Contains(tipo) Then
         If String.IsNullOrWhiteSpace(en.IdUnidadDeMedida) Or String.IsNullOrWhiteSpace(en.IdUnidadDeMedidaCompra) Then
            Dim producto = New Productos(da).GetUno(en.IdProducto)
            en.UnidadDeMedida = producto.UnidadDeMedida
            en.UnidadDeMedidaCompra = producto.UnidadDeMedidaCompra
            en.FactorConversionCompra = producto.FactorConversionCompra
         End If

         If en.FactorConversionCompra = 0 Then
            If en.IdUnidadDeMedida = en.IdUnidadDeMedidaCompra Then
               en.FactorConversionCompra = 1
            Else
               Throw New Exception("No se cargó Factor de Conversión para la Unidad de Medida de Compra")
            End If
         End If
      End If
   End Sub

   Private Sub EjecutaSP(en As Entidades.RequerimientoCompraProducto, tipo As TipoSP)
      Dim sql = New SqlServer.RequerimientosComprasProductos(da)
      Dim rRqAsignaciones = New RequerimientosComprasProductosAsignaciones(da)
      If (tipo <> TipoSP._D) AndAlso en.Orden = 0 Then
         en.Orden = GetOrdenMaximo(en.IdRequerimientoCompra) + 1
      End If

      ValidaGrabacion(en, tipo)

      Select Case tipo
         Case TipoSP._I
            sql.RequerimientosComprasProductos_I(en.IdRequerimientoCompra, en.IdProducto, en.Orden,
                                                 en.NombreProducto, en.Cantidad, en.CantidadUMCompra, en.FactorConversionCompra,
                                                 en.IdUnidadDeMedida, en.IdUnidadDeMedidaCompra,
                                                 en.FechaEntrega, en.Observacion,
                                                 en.FechaAnulacion, en.IdUsuarioAnulacion)
            rRqAsignaciones._Insertar(en)
         Case TipoSP._U
            sql.RequerimientosComprasProductos_U(en.IdRequerimientoCompra, en.IdProducto, en.Orden,
                                                 en.NombreProducto, en.Cantidad, en.CantidadUMCompra, en.FactorConversionCompra,
                                                 en.IdUnidadDeMedida, en.IdUnidadDeMedidaCompra,
                                                 en.FechaEntrega, en.Observacion,
                                                 en.FechaAnulacion, en.IdUsuarioAnulacion)
            rRqAsignaciones._Actualizar(en)
         Case TipoSP._M
            sql.RequerimientosComprasProductos_M(en.IdRequerimientoCompra, en.IdProducto, en.Orden,
                                                 en.NombreProducto, en.Cantidad, en.CantidadUMCompra, en.FactorConversionCompra,
                                                 en.IdUnidadDeMedida, en.IdUnidadDeMedidaCompra,
                                                 en.FechaEntrega, en.Observacion,
                                                 en.FechaAnulacion, en.IdUsuarioAnulacion)
            rRqAsignaciones._Actualizar(en)
         Case TipoSP._D
            rRqAsignaciones._Borrar(en)
            sql.RequerimientosComprasProductos_D(en.IdRequerimientoCompra, en.IdProducto, en.Orden)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.RequerimientoCompraProducto, dr As DataRow)
      With o
         .IdRequerimientoCompra = dr.Field(Of Long)(Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.RequerimientoCompraProducto.Columnas.IdProducto.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.RequerimientoCompraProducto.Columnas.Orden.ToString())

         .NombreProducto = dr.Field(Of String)(Entidades.RequerimientoCompraProducto.Columnas.NombreProducto.ToString())
         .Cantidad = dr.Field(Of Decimal)(Entidades.RequerimientoCompraProducto.Columnas.Cantidad.ToString())
         .CantidadUMCompra = dr.Field(Of Decimal)(Entidades.RequerimientoCompraProducto.Columnas.CantidadUMCompra.ToString())

         .UnidadDeMedida = New UnidadesDeMedidas(da).GetUno(dr.Field(Of String)(Entidades.RequerimientoCompraProducto.Columnas.IdUnidadDeMedida.ToString()))
         .UnidadDeMedidaCompra = New UnidadesDeMedidas(da).GetUno(dr.Field(Of String)(Entidades.RequerimientoCompraProducto.Columnas.IdUnidadDeMedidaCompra.ToString()))

         .FactorConversionCompra = dr.Field(Of Decimal)(Entidades.RequerimientoCompraProducto.Columnas.FactorConversionCompra.ToString())
         .FechaEntrega = dr.Field(Of Date)(Entidades.RequerimientoCompraProducto.Columnas.FechaEntrega.ToString())
         .Observacion = dr.Field(Of String)(Entidades.RequerimientoCompraProducto.Columnas.Observacion.ToString())
         .FechaAnulacion = dr.Field(Of Date?)(Entidades.RequerimientoCompraProducto.Columnas.FechaAnulacion.ToString())
         .IdUsuarioAnulacion = dr.Field(Of String)(Entidades.RequerimientoCompraProducto.Columnas.IdUsuarioAnulacion.ToString()).IfNull()

         .Asignaciones = New RequerimientosComprasProductosAsignaciones(da).GetTodos(.IdRequerimientoCompra, .IdProducto, .Orden).ToConBorrados()

      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.RequerimientoCompraProducto)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.RequerimientoCompraProducto)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Merge(entidad As Entidades.RequerimientoCompraProducto)
      EjecutaSP(entidad, TipoSP._M)
   End Sub
   Public Sub _Borrar(entidad As Entidades.RequerimientoCompraProducto)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _AnularRequerimientoProducto(rqProds As List(Of Entidades.RequerimientoCompraProducto))
      If rqProds IsNot Nothing Then
         rqProds.Where(Function(dr) dr.Selec).ToList().ForEach(Sub(dr) _AnularRequerimientoProducto(dr))
      End If
   End Sub

   Public Sub _AnularRequerimientoProducto(rqProd As Entidades.RequerimientoCompraProducto)
      Dim rRqAsig = New RequerimientosComprasProductosAsignaciones(da)
      If rRqAsig.GetAll(rqProd.IdRequerimientoCompra, rqProd.IdProducto, rqProd.Orden).Any() Then
         Throw New Exception(String.Format("No es posible anular el producto {0} porque el mismo tiene asignaciones", rqProd.IdProducto))
      End If
      '-- Devincula OrdenProduccionProducto de Requerimiento.- -------------------------------------------------------------
      Dim sqlOP = New SqlServer.OrdenesProduccionMRPProductos(da)
      sqlOP.OrdenesProduccionProductos_Requerimiento_U_Anular(rqProd.IdRequerimientoCompra, rqProd.IdProducto, rqProd.Orden)
      '---------------------------------------------------------------------------------------------------------------------
      Dim sql = New SqlServer.RequerimientosComprasProductos(da)
      sql.RequerimientosComprasProductos_U_Anular(rqProd.IdRequerimientoCompra, rqProd.IdProducto, rqProd.Orden,
      cantidad:=0, fechaAnulacion:=Date.Now, idUsuarioAnulacion:=actual.Nombre)

   End Sub


   Public Sub _Insertar(entidad As Entidades.RequerimientoCompra)
      entidad.Productos.ForEach(
      Sub(en)
         en.IdRequerimientoCompra = entidad.IdRequerimientoCompra
         _Insertar(en)
      End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.RequerimientoCompra)
      entidad.Productos.Borrados.ForEach(Sub(en) _Borrar(en))
      entidad.Productos.ForEach(
      Sub(en)
         en.IdRequerimientoCompra = entidad.IdRequerimientoCompra
         _Merge(en)
      End Sub)
   End Sub
   Public Sub _Borrar(entidad As Entidades.RequerimientoCompra)
      _Borrar(New Entidades.RequerimientoCompraProducto() With {.IdRequerimientoCompra = entidad.IdRequerimientoCompra})
   End Sub

   Public Function Get1(idRequerimientoCompraProducto As Long, idProducto As String, orden As Integer) As DataTable
      Return New SqlServer.RequerimientosComprasProductos(da).RequerimientosComprasProductos_G1(idRequerimientoCompraProducto, idProducto, orden)
   End Function
   Public Function GetUno(idRequerimientoCompraProducto As Integer, idProducto As String, orden As Integer) As Entidades.RequerimientoCompraProducto
      Return GetUno(idRequerimientoCompraProducto, idProducto, orden, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idRequerimientoCompraProducto As Long, idProducto As String, orden As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.RequerimientoCompraProducto
      Return CargaEntidad(Get1(idRequerimientoCompraProducto, idProducto, orden), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RequerimientoCompraProducto(),
                          accion, Function() String.Format("No existe el Requerimiento de Compra Producto con Id {0} Producto {1} y Orden {2}.", idRequerimientoCompraProducto, idProducto, orden))
   End Function

   Public Function GetTodos(idRequerimientoCompra As Long) As List(Of Entidades.RequerimientoCompraProducto)
      Return CargaLista(GetAll(idRequerimientoCompra), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RequerimientoCompraProducto())
   End Function

   Public Function GetOrdenMaximo(idRequerimientoCompra As Long) As Integer
      Return New SqlServer.RequerimientosComprasProductos(da).GetCodigoMaximo(idRequerimientoCompra).ToInteger()
   End Function

#End Region

End Class