Imports Eniac.Entidades

Public Class OrdenesProduccionMRPOperaciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.OrdenProduccionMRPOperacion.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- --------------------------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.OrdenProduccionMRPOperacion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.OrdenProduccionMRPOperacion)))
   End Sub
   Public Sub ActualizarAsigna(entidad As Entidades.OrdenProduccionMRPOperacion)
      EjecutaConTransaccion(Sub() _ActualizarAsigna(entidad))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.OrdenProduccionMRPOperacion)))
   End Sub
   '-- Sin transacciones.- ------------------------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Entidades.OrdenProduccionMRPOperacion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.OrdenProduccionMRPOperacion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.OrdenProduccionMRPOperacion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _ActualizarAsigna(entidad As Entidades.OrdenProduccionMRPOperacion)
      ActualizaDesdeAsignacionActividades(entidad)
   End Sub
   Public Sub _ActualizaOperEnvioRecepcion(en As Entidades.OrdenProduccionMRPOperacion)
      Dim sqlC = GetSql()
      sqlC.OrdenesProduccionMRPOperaciones_U(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto,
                                             en.IdProcesoProductivo, en.IdOperacion, en.CodigoProcProdOperacion, en.DescripcionOperacion, en.SucursalOperacion, en.DepositoOperacion,
                                             en.UbicacionOperacion, en.CentroProductorOperacion, en.PAPTiemposMaquina, en.PAPTiemposHHombre, en.ProdTiemposMaquina, en.ProdTiemposHHombre,
                                             en.Proveedor, en.CostoExterno, en.UnidadesHora, en.NormasDispositivos, en.NormasMetodos, en.NormasSeguridad, en.NormasControlCalidad,
                                             en.IdEstadoTarea, en.FechaComienzo, en.IdCodigoTarea, en.TipoOperacionExterna, en.IdOperacionExternaVinculada)
   End Sub
   '-----------------------------------------------------------------------------------------------------------------
   Public Function _GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                           orden As Integer, idProducto As String, idProcesoProductivo As Long) As DataTable

      Return GetSql().OrdenesProduccionMRPOperaciones_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                         orden, idProducto, idProcesoProductivo)
   End Function
   Public Function _GetUna(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                           orden As Integer, idProducto As String, idProcesoProductivo As Long, idOperacion As Integer) As DataTable

      Return GetSql().OrdenesProduccionMRPOperaciones_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                         orden, idProducto, idProcesoProductivo, idOperacion)
   End Function

   Private Function _GetAnteriores(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                   orden As Integer, idProducto As String, idProcesoProductivo As Long, codigoOperacion As String) As DataTable

      Return GetSql().OrdenesProduccionMRPOperaciones_Ant(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                         orden, idProducto, idProcesoProductivo, codigoOperacion)
   End Function

   Private Function _GetAsignaActividad(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                        orden As Integer, idProducto As String, idProcesoProductivo As Long, codigoOperacion As String) As DataTable

      Return GetSql().OrdenesProduccionMRPOperaciones_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                         orden, idProducto, idProcesoProductivo, codigoOperacion)
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.OrdenesProduccionMRPOperaciones
      Return New SqlServer.OrdenesProduccionMRPOperaciones(da)
   End Function

   Private Sub EjecutaSP(en As Entidades.OrdenProduccionMRPOperacion, tipo As TipoSP)
      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Orden de Produccion MRP Productos.- --------
            sqlC.OrdenesProduccionMRPOperaciones_I(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto,
                                                   en.IdProcesoProductivo, en.IdOperacion, en.CodigoProcProdOperacion, en.DescripcionOperacion, en.SucursalOperacion, en.DepositoOperacion,
                                                   en.UbicacionOperacion, en.CentroProductorOperacion, en.PAPTiemposMaquina, en.PAPTiemposHHombre, en.ProdTiemposMaquina, en.ProdTiemposHHombre,
                                                   en.Proveedor, en.CostoExterno, en.UnidadesHora, en.NormasDispositivos, en.NormasMetodos, en.NormasSeguridad, en.NormasControlCalidad,
                                                   en.IdEstadoTarea, en.FechaComienzo, en.IdCodigoTarea, en.TipoOperacionExterna, en.IdOperacionExternaVinculada)
            '-- Actualiza Categorias Empleados.- ---------------------------------
            Dim rCategoriasOP = New OrdenesProduccionMRPCategoriasEmpleados(da)
            rCategoriasOP.ActualizaDesdeOrdenesProduccionMRPOperaciones(en)
            '-- Actualiza Productos.- --------------------------------------------
            Dim rProductosOP = New OrdenesProduccionMRPProductos(da)
            rProductosOP.ActualizaDesdeOrdenesProduccionMRPOperaciones(en)
         Case TipoSP._U
            '-- Modifica Orden de Produccion MRP Productos.- --------
            sqlC.OrdenesProduccionMRPOperaciones_U(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto,
                                                   en.IdProcesoProductivo, en.IdOperacion, en.CodigoProcProdOperacion, en.DescripcionOperacion, en.SucursalOperacion, en.DepositoOperacion,
                                                   en.UbicacionOperacion, en.CentroProductorOperacion, en.PAPTiemposMaquina, en.PAPTiemposHHombre, en.ProdTiemposMaquina, en.ProdTiemposHHombre,
                                                   en.Proveedor, en.CostoExterno, en.UnidadesHora, en.NormasDispositivos, en.NormasMetodos, en.NormasSeguridad, en.NormasControlCalidad,
                                                   en.IdEstadoTarea, en.FechaComienzo, en.IdCodigoTarea, en.TipoOperacionExterna, en.IdOperacionExternaVinculada)
            '-- Actualiza Categorias Empleados.- ---------------------------------
            Dim rCategoriasOP = New OrdenesProduccionMRPCategoriasEmpleados(da)
            rCategoriasOP.ActualizaDesdeOrdenesProduccionMRPOperaciones(en)
            '-- Actualiza Productos.- --------------------------------------------
            Dim rProductosOP = New OrdenesProduccionMRPProductos(da)
            rProductosOP.ActualizaDesdeOrdenesProduccionMRPOperaciones(en)
         Case TipoSP._D
            '-- Borra Categoria Empleados.- ---------------------------------------------
            Dim rCategoriaEmp = New Reglas.OrdenesProduccionMRPCategoriasEmpleados(da)
            For Each eCatEmp In en.CategoriasEmpleados
               rCategoriaEmp._Borrar(eCatEmp)
            Next
            '-- Borra Productos Necesarios.- --------------------------------------------
            Dim rProductoNecesario = New Reglas.OrdenesProduccionMRPProductos(da)
            For Each eProductosNecesarios In en.ProductosNecesarios
               rProductoNecesario._Borrar(eProductosNecesarios)
            Next
            '-- Borra Productos Resultantes.- -------------------------------------------
            Dim rProductoResultantes = New Reglas.OrdenesProduccionMRPProductos(da)
            For Each eProductosResultantes In en.ProductosResultantes
               rProductoResultantes._Borrar(eProductosResultantes)
            Next
            '-- Elimina Orden de Produccion MRP Productos.- --------------------
            sqlC.OrdenesProduccionMRPOperaciones_D(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto,
                                                   en.IdProcesoProductivo, en.IdOperacion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.OrdenProduccionMRPOperacion, dr As DataRow, incluirHijos As Boolean)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdTipoComprobante.ToString())
         .LetraComprobante = dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.LetraComprobante.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.CentroEmisor.ToString())
         .NumeroOrdenProduccion = dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.NumeroOrdenProduccion.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.Orden.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdProducto.ToString())
         .NombreProducto = dr.Field(Of String)(Entidades.Producto.Columnas.NombreProducto.ToString())

         .IdProcesoProductivo = dr.Field(Of Long)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdProcesoProductivo.ToString())
         .IdOperacion = dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdOperacion.ToString())
         .CodigoProcProdOperacion = dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.CodigoProcProdOperacion.ToString())
         .DescripcionOperacion = dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.DescripcionOperacion.ToString())
         .IdCodigoTarea = dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdCodigoTarea.ToString())
         .SucursalOperacion = dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.SucursalOperacion.ToString())
         .DepositoOperacion = dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.DepositoOperacion.ToString())
         .UbicacionOperacion = dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.UbicacionOperacion.ToString())

         .CentroProductorOperacion = dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.CentroProductorOperacion.ToString())
         .DescripcionCentro = dr.Field(Of String)("DescripcionCentro")     ' Alias de: Entidades.MRPCentroProductor.Columnas.Descripcion.ToString()    

         '-- REQ-42033.- -----------------------------------------------------------------
         Dim eCP = New Reglas.MRPCentrosProductores().GetUno(dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.CentroProductorOperacion.ToString()))
         If eCP.ClaseCentroProductor = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT Then
            .TipoOperacionExterna = DirectCast([Enum].Parse(GetType(Entidades.MRPProcesoProductivoOperacion.OperacionesExternas), dr(Entidades.OrdenProduccionMRPOperacion.Columnas.TipoOperacionExterna.ToString()).ToString()), Entidades.MRPProcesoProductivoOperacion.OperacionesExternas)
            .IdOperacionExternaVinculada = dr.Field(Of Integer?)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdOperacionExternaVinculada.ToString())
         End If

         .UnidadesHora = dr.Field(Of Decimal)(Entidades.OrdenProduccionMRPOperacion.Columnas.UnidadesHora.ToString())
         .PAPTiemposMaquina = dr.Field(Of Decimal)(Entidades.OrdenProduccionMRPOperacion.Columnas.PAPTiemposMaquina.ToString())
         .PAPTiemposHHombre = dr.Field(Of Decimal)(Entidades.OrdenProduccionMRPOperacion.Columnas.PAPTiemposHHombre.ToString())
         .ProdTiemposMaquina = dr.Field(Of Decimal)(Entidades.OrdenProduccionMRPOperacion.Columnas.ProdTiemposMaquina.ToString())
         .ProdTiemposHHombre = dr.Field(Of Decimal)(Entidades.OrdenProduccionMRPOperacion.Columnas.ProdTiemposHHombre.ToString())
         '-- REQ-41512.- ---------------------------------------------------------------------------------------------------------
         If Not String.IsNullOrEmpty(dr(Entidades.OrdenProduccionMRPOperacion.Columnas.Proveedor.ToString()).ToString()) Then
            .Proveedor = dr.Field(Of Long)(Entidades.OrdenProduccionMRPOperacion.Columnas.Proveedor.ToString())
            .CodigoProveedor = dr.Field(Of Long)(Entidades.Proveedor.Columnas.CodigoProveedor.ToString())
            .NombreProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.NombreProveedor.ToString()).IfNull()
         End If
         '------------------------------------------------------------------------------------------------------------------------
         .CostoExterno = dr.Field(Of Decimal)(Entidades.OrdenProduccionMRPOperacion.Columnas.CostoExterno.ToString())
         .NormasDispositivos = dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.NormasDispositivos.ToString())
         .NormasMetodos = dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.NormasMetodos.ToString())
         .NormasSeguridad = dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.NormasSeguridad.ToString())
         .NormasControlCalidad = dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.NormasControlCalidad.ToString())

         .IdEstadoTarea = dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdEstadoTarea.ToString())
         .FechaComienzo = dr.Field(Of Date)(Entidades.OrdenProduccionMRPOperacion.Columnas.FechaComienzo.ToString())

         .IdCliente = dr.Field(Of Long)(Entidades.OrdenProduccion.Columnas.IdCliente.ToString())
         .CodigoCliente = dr.Field(Of Long)(Entidades.Cliente.Columnas.CodigoCliente.ToString())
         .NombreCliente = dr.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.OrdenProduccionMRPOperacion.Columnas.IdEmpleado.ToString()).ToString()) Then
            .IdEmpleado = dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdEmpleado.ToString())
         End If

         If incluirHijos Then
            .CategoriasEmpleados = New OrdenesProduccionMRPCategoriasEmpleados(da).GetTodas(
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdSucursal.ToString()),
                                                   dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdTipoComprobante.ToString()),
                                                   dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.LetraComprobante.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.CentroEmisor.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.NumeroOrdenProduccion.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.Orden.ToString()),
                                                   dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdProducto.ToString()),
                                                   dr.Field(Of Long)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdProcesoProductivo.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdOperacion.ToString()))

            .ProductosNecesarios = New OrdenesProduccionMRPProductos(da).GetTodos(
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdSucursal.ToString()),
                                                   dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdTipoComprobante.ToString()),
                                                   dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.LetraComprobante.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.CentroEmisor.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.NumeroOrdenProduccion.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.Orden.ToString()),
                                                   dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdProducto.ToString()),
                                                   dr.Field(Of Long)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdProcesoProductivo.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdOperacion.ToString()),
                                                                             Entidades.Publicos.SiNoTodos.SI)

            .ProductosResultantes = New OrdenesProduccionMRPProductos(da).GetTodos(
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdSucursal.ToString()),
                                                   dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdTipoComprobante.ToString()),
                                                   dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.LetraComprobante.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.CentroEmisor.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.NumeroOrdenProduccion.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.Orden.ToString()),
                                                   dr.Field(Of String)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdProducto.ToString()),
                                                   dr.Field(Of Long)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdProcesoProductivo.ToString()),
                                                   dr.Field(Of Integer)(Entidades.OrdenProduccionMRPOperacion.Columnas.IdOperacion.ToString()),
                                                                              Entidades.Publicos.SiNoTodos.NO)
         End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetTodas(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                            orden As Integer, idProducto As String, idProcesoProductivo As Long) As Entidades.ListConBorrados(Of Entidades.OrdenProduccionMRPOperacion)
      Using dt As DataTable = _GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                      orden, idProducto, idProcesoProductivo)
         Dim lista = CargaLista(dt, Sub(o, dr) CargarUno(o, dr, incluirHijos:=True), Function() New Entidades.OrdenProduccionMRPOperacion())
         Return Entidades.ListConBorrados.From(lista)
      End Using
   End Function
   Public Function GetUna(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                          orden As Integer, idProducto As String, idProcesoProductivo As Long, idOperacion As Integer) As Entidades.OrdenProduccionMRPOperacion

      Dim o = New Entidades.OrdenProduccionMRPOperacion
      Using dt As DataTable = _GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                      orden, idProducto, idProcesoProductivo, idOperacion)
         For Each dr As DataRow In dt.Rows
            CargarUno(o, dr, incluirHijos:=True)
         Next
      End Using
      Return o
   End Function
   Public Function GetUnaAnterior(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                  orden As Integer, idProducto As String, idProcesoProductivo As Long, codigoOperacion As String) As Entidades.OrdenProduccionMRPOperacion

      Dim o = New Entidades.OrdenProduccionMRPOperacion
      Using dt As DataTable = _GetAnteriores(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                             orden, idProducto, idProcesoProductivo, codigoOperacion)
         If dt.Rows.Count > 0 Then
            CargarUno(o, dt.Rows(0), incluirHijos:=True)
         End If
      End Using
      Return o
   End Function

   Public Function GetAsignaActividad(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                      orden As Integer, idProducto As String, idProcesoProductivo As Long, codigoOperacion As String) As List(Of Entidades.OrdenProduccionMRPOperacion)
      Using dt As DataTable = _GetAsignaActividad(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                  orden, idProducto, idProcesoProductivo, codigoOperacion)
         Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr, incluirHijos:=False), Function() New Entidades.OrdenProduccionMRPOperacion())
      End Using
   End Function

   Public Sub ActualizaDesdeAsignacionActividades(en As Entidades.OrdenProduccionMRPOperacion)
      '-- Modifica Orden de Produccion MRP Productos.- --------
      GetSql().OrdenesProduccionMRPOperaciones_UA(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto,
                                              en.IdProcesoProductivo, en.IdOperacion, en.CentroProductorOperacion, en.Proveedor, en.IdEstadoTarea, en.FechaComienzo, en.IdEmpleado)
   End Sub
   Public Sub ActualizaDesdeOrdenesProduccionMRP(entidad As Entidades.OrdenProduccionMRP)
      '-------------------------------------------------------------------------------
      If entidad.Operaciones IsNot Nothing Then
         Dim eOrdProdOper As New List(Of OrdenProduccionMRPOperacion)
         For Each oOP In entidad.Operaciones
            '-- Elimina los Borrados.- --------------------------------------------------
            For Each ent In entidad.Operaciones.Borrados
               '.OrderBy(Function(x) x.TipoOperacionExterna)
               'If ent.TipoOperacionExterna = Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.ENVIO Then
               '   With ent
               '      .TipoOperacionExterna = Nothing
               '      .IdOperacionExternaVinculada = Nothing
               '   End With

               'End If
               _Borrar(ent)
            Next
            '----------------------------------------------------------------------------
            If oOP.NumeroOrdenProduccion > 0 Then
               _Actualizar(oOP)
            Else
               With oOP
                  .IdSucursal = entidad.IdSucursal
                  .IdTipoComprobante = entidad.IdTipoComprobante
                  .LetraComprobante = entidad.LetraComprobante
                  .CentroEmisor = entidad.CentroEmisor
                  .NumeroOrdenProduccion = entidad.NumeroOrdenProduccion
                  .Orden = entidad.Orden
                  .IdProducto = entidad.IdProducto
                  .IdEstadoTarea = "PENDIENTE"
                  .FechaComienzo = Now
               End With
               '----------------------------------------------------------------------------
               If oOP.TipoOperacionExterna.HasValue Then
                  eOrdProdOper.Add(oOP.Clonar(oOP))
                  With oOP
                     .TipoOperacionExterna = Nothing
                     .IdOperacionExternaVinculada = Nothing
                  End With
               End If
               _Insertar(oOP)
            End If
         Next
         If eOrdProdOper IsNot Nothing Then
            For Each eOPOper In eOrdProdOper
               _ActualizaOperEnvioRecepcion(eOPOper)
            Next
         End If
         '----------------------------------------------------------------------------
      End If
      '-------------------------------------------------------------------------------
   End Sub

   ''' <summary>
   ''' Copia las Operaciones de un MRPProcesoProductivo a una ListConBorrados(Of OrdenProduccionMRPOperacion)
   ''' </summary>
   ''' <param name="procProductivo"></param>
   ''' <param name="cantidad"></param>
   ''' <returns></returns>
   Public Function CopiaOrdenProduccionMRPOperaciones(procProductivo As Entidades.MRPProcesoProductivo, cantidad As Decimal) As Entidades.ListConBorrados(Of Entidades.OrdenProduccionMRPOperacion)
      Dim eOPMrpOs = New Entidades.ListConBorrados(Of Entidades.OrdenProduccionMRPOperacion)

      For Each eProcProdO In procProductivo.Operaciones
         Dim eOPMrpO = New Entidades.OrdenProduccionMRPOperacion()
         With eOPMrpO
            .IdSucursal = actual.Sucursal.Id
            .IdProducto = procProductivo.IdProductoProceso

            .IdOperacion = eProcProdO.IdOperacion
            .IdProcesoProductivo = eProcProdO.IdProcesoProductivo
            .CodigoProcProdOperacion = eProcProdO.CodigoProcProdOperacion
            .DescripcionOperacion = eProcProdO.DescripcionOperacion
            .IdCodigoTarea = eProcProdO.IdCodigoTarea
            .SucursalOperacion = eProcProdO.SucursalOperacion
            .DepositoOperacion = eProcProdO.DepositoOperacion
            .UbicacionOperacion = eProcProdO.UbicacionOperacion

            .CentroProductorOperacion = eProcProdO.CentroProductorOperacion

            .UnidadesHora = eProcProdO.UnidadesHora

            .PAPTiemposMaquina = eProcProdO.PAPTiemposMaquina
            .PAPTiemposHHombre = eProcProdO.PAPTiemposHHombre
            .ProdTiemposMaquina = (eProcProdO.ProdTiemposMaquina * cantidad)
            .ProdTiemposHHombre = (eProcProdO.ProdTiemposHHombre * cantidad)

            .Proveedor = eProcProdO.Proveedor
            .CostoExterno = (eProcProdO.CostoExterno * cantidad)

            .NormasDispositivos = eProcProdO.NormasDispositivos
            .NormasMetodos = eProcProdO.NormasMetodos
            .NormasSeguridad = eProcProdO.NormasSeguridad
            .NormasControlCalidad = eProcProdO.NormasControlCalidad

            '-- REQ-42033.- -----------------------------------------------------------------
            Dim eCP = New Reglas.MRPCentrosProductores().GetUno(eProcProdO.CentroProductorOperacion)
            If eCP.ClaseCentroProductor = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT Then
               .TipoOperacionExterna = DirectCast([Enum].Parse(GetType(Entidades.MRPProcesoProductivoOperacion.OperacionesExternas), eProcProdO.TipoOperacionExterna.ToString()), Entidades.MRPProcesoProductivoOperacion.OperacionesExternas)
               .IdOperacionExternaVinculada = eProcProdO.IdOperacionExternaVinculada
            End If

            .CategoriasEmpleados = New OrdenesProduccionMRPCategoriasEmpleados(da).CopiaOrdenProduccionMRPCategoriasEmpleado(eProcProdO, cantidad, actual.Sucursal.Id, procProductivo.IdProductoProceso)
            .ProductosNecesarios = New OrdenesProduccionMRPProductos(da).CopiaOrdenProduccionMRPProductos(eProcProdO, cantidad, actual.Sucursal.Id, procProductivo.IdProductoProceso, Entidades.Publicos.SiNoTodos.SI)
            .ProductosResultantes = New OrdenesProduccionMRPProductos(da).CopiaOrdenProduccionMRPProductos(eProcProdO, cantidad, actual.Sucursal.Id, procProductivo.IdProductoProceso, Entidades.Publicos.SiNoTodos.NO)
         End With
         eOPMrpOs.Add(eOPMrpO)
      Next
      Return eOPMrpOs
   End Function

   Public Function ValidaOrdenesProduccionOperacionesDepositos(idSucursal As Integer, IdDeposito As Integer) As Boolean
      Dim dt = New SqlServer.OrdenesProduccionMRPOperaciones(da).GetOrdenProduccionCantidadSucursalesDepositos(idSucursal, IdDeposito)
      Return dt.Rows(0).Field(Of Integer)("Cantidad") > 0
   End Function


   Public Function GetInformeOperaciones(idEstado As Publicos.EstadoAsignaTarea?, codigoProcProdOperacion As String, fechaDesde As Date?, fechaHasta As Date?,
                                         idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroDesde As Long, numeroHasta As Long,
                                         idProducto As String, idCliente As Long?,
                                         idTipoComprobantePedido As String, letraFiscalPedido As String, centroEmisorPedido As Integer, numeroPedidoDesde As Long, numeroPedidoHasta As Long, lineaPedido As Integer,
                                         planMaestroNumero As Integer) As DataTable
      Return GetSql().GetInformeOperaciones(If(idEstado.HasValue, idEstado.ToString(), String.Empty), codigoProcProdOperacion, fechaDesde, fechaHasta,
                                            idTipoComprobante, letraFiscal, centroEmisor, numeroDesde, numeroHasta,
                                            idProducto, idCliente,
                                            idTipoComprobantePedido, letraFiscalPedido, centroEmisorPedido, numeroPedidoDesde, numeroPedidoHasta, lineaPedido,
                                            planMaestroNumero)
   End Function

#End Region

End Class