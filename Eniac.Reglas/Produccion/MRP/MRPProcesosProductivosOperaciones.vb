#Region "Option"
Option Strict On
Option Explicit On
#End Region
Imports Eniac.Entidades

Public Class MRPProcesosProductivosOperaciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = MRPProcesoProductivoOperacion.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- -----------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoOperacion), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoOperacion), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoOperacion), TipoSP._D))
   End Sub
   '-- Sin transacciones.- ---------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoOperacion), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoOperacion), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoOperacion), TipoSP._D)
   End Sub
   Public Sub _ActualizaOperEnvioRecepcion(idOperacion As Integer, idProcesoProductivo As Long, idOperacionVinculada As Integer)
      Dim sqlC = New SqlServer.MRPProcesosProductivosOperaciones(da)
      sqlC.ProcesosProductivosOperaciones_UOperacionesVinculadas(idOperacion, idProcesoProductivo, idOperacionVinculada)
   End Sub
   '-------------------------------------------------------------------------------------------------
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MRPProcesosProductivosOperaciones(Me.da).ProcesosProductivosOperaciones_GA()
   End Function

   Public Function _GetAll(idProcesoProductivo As Long) As System.Data.DataTable
      Return New SqlServer.MRPProcesosProductivosOperaciones(Me.da).ProcesosProductivosOperaciones_GA(idProcesoProductivo)
   End Function

   Public Function Get1(idProcesoProductivo As Long, idOperacion As Integer) As System.Data.DataTable
      Return New SqlServer.MRPProcesosProductivosOperaciones(Me.da).ProcesosProductivosOperaciones_G1(idProcesoProductivo, idOperacion)
   End Function
   Public Function Get1Anterior(idProcesoProductivo As Long, codigoOperacion As String) As System.Data.DataTable
      Return New SqlServer.MRPProcesosProductivosOperaciones(Me.da).ProcesosProductivosOperaciones_G1_Ant(idProcesoProductivo, codigoOperacion)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPProcesoProductivoOperacion, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPProcesosProductivosOperaciones(da)
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Procesos Productivos Operaciones.- --------
            sqlC.ProcesosProductivosOperaciones_I(en.IdOperacion, en.IdProcesoProductivo, en.CodigoProcProdOperacion, en.DescripcionOperacion, en.IdCodigoTarea, en.SucursalOperacion,
                                                  en.DepositoOperacion, en.UbicacionOperacion, en.CentroProductorOperacion, en.PAPTiemposMaquina, en.PAPTiemposHHombre,
                                                  en.ProdTiemposMaquina, en.ProdTiemposHHombre, en.Proveedor, en.CostoExterno, en.UnidadesHora,
                                                  en.NormasDispositivos, en.NormasMetodos, en.NormasSeguridad, en.NormasControlCalidad,
                                                  en.TipoOperacionExterna, en.IdOperacionExternaVinculada)
            '-- Actualiza Categorias Empleados.- ---------------------------------
            Dim rCategoriasPP = New MRPProcesosProductivosCategoriasEmpleados(da)
            rCategoriasPP.ActualizaDesdeProcesosProductivosOperaciones(en)
            '-- Actualiza Productos.- --------------------------------------------
            Dim rProductosPP = New MRPProcesosProductivosProductos(da)
            rProductosPP.ActualizaProcesosProductivosProductos(en)

         Case TipoSP._U
            '-- Actualiza Categorias Empleados.- ---------------------------------
            Dim rCategoriasPP = New MRPProcesosProductivosCategoriasEmpleados(da)
            rCategoriasPP.ActualizaDesdeProcesosProductivosOperaciones(en)
            '-- Actualiza Productos.- --------------------------------------------
            Dim rProductosPP = New MRPProcesosProductivosProductos(da)
            rProductosPP.ActualizaProcesosProductivosProductos(en)
            '-- Actualiza Procesos Productivos Operaciones.- --------
            sqlC.ProcesosProductivosOperaciones_U(en.IdOperacion, en.IdProcesoProductivo, en.CodigoProcProdOperacion, en.DescripcionOperacion.Replace("-E", "").Replace("-R", ""), en.IdCodigoTarea, en.SucursalOperacion,
                                                  en.DepositoOperacion, en.UbicacionOperacion, en.CentroProductorOperacion, en.PAPTiemposMaquina, en.PAPTiemposHHombre,
                                                  en.ProdTiemposMaquina, en.ProdTiemposHHombre, en.Proveedor, en.CostoExterno, en.UnidadesHora,
                                                  en.NormasDispositivos, en.NormasMetodos, en.NormasSeguridad, en.NormasControlCalidad,
                                                  en.TipoOperacionExterna, en.IdOperacionExternaVinculada)
         Case TipoSP._D
            '-- Borra Categoria Empleados.- ---------------------------------------------
            Dim rCategoriaEmp = New Reglas.MRPProcesosProductivosCategoriasEmpleados(da)
            For Each eCatEmp In en.CategoriasEmpleados
               rCategoriaEmp._Borrar(eCatEmp)
            Next
            '-- Borra Productos Necesarios.- --------------------------------------------
            Dim rProductoNecesario = New Reglas.MRPProcesosProductivosProductos(da)
            For Each eProductosNecesarios In en.ProductosNecesario
               rProductoNecesario._Borrar(eProductosNecesarios)
            Next
            '-- Borra Productos Resultantes.- -------------------------------------------
            Dim rProductoResultantes = New Reglas.MRPProcesosProductivosProductos(da)
            For Each eProductosResultantes In en.ProductosResultantes
               rProductoResultantes._Borrar(eProductosResultantes)
            Next
            '-- Elimina Procesos Productivos.- --------------------
            sqlC.ProcesosProductivosOperaciones_D(en.IdOperacion, en.IdProcesoProductivo)
      End Select
   End Sub
   Private Sub CargarUno(o As MRPProcesoProductivoOperacion, dr As DataRow)
      With o
         .IdOperacion = dr.Field(Of Integer)(MRPProcesoProductivoOperacion.Columnas.IdOperacion.ToString())
         .IdProcesoProductivo = dr.Field(Of Long)(MRPProcesoProductivoOperacion.Columnas.IdProcesoProductivo.ToString())
         .CodigoProcProdOperacion = dr.Field(Of String)(MRPProcesoProductivoOperacion.Columnas.CodigoProcProdOperacion.ToString())
         .DescripcionOperacion = dr.Field(Of String)(MRPProcesoProductivoOperacion.Columnas.DescripcionOperacion.ToString())

         .IdProductoPrincipal = dr.Field(Of String)("IdProductoPrincipal")
         .DescripcionProductoPrincipal = dr.Field(Of String)("DescripcionProductoPrincipal")

         .IdCodigoTarea = dr.Field(Of Integer?)(MRPProcesoProductivoOperacion.Columnas.IdCodigoTarea.ToString()).IfNull()
         .SucursalOperacion = dr.Field(Of Integer)(MRPProcesoProductivoOperacion.Columnas.SucursalOperacion.ToString())
         .DepositoOperacion = dr.Field(Of Integer)(MRPProcesoProductivoOperacion.Columnas.DepositoOperacion.ToString())
         .NombreDeposito = New Reglas.SucursalesDepositos().GetUno(.DepositoOperacion, .SucursalOperacion).NombreDeposito
         .UbicacionOperacion = dr.Field(Of Integer)(MRPProcesoProductivoOperacion.Columnas.UbicacionOperacion.ToString())
         .NombreUbicacion = New Reglas.SucursalesUbicaciones().GetUno(.DepositoOperacion, .SucursalOperacion, .UbicacionOperacion).NombreUbicacion
         If String.IsNullOrEmpty(dr(MRPProcesoProductivoOperacion.Columnas.CentroProductorOperacion.ToString()).ToString()) Then
            .CentroProductorOperacion = 0
            .DotacionCentroProductor = 0
         Else
            .CentroProductorOperacion = dr.Field(Of Integer)(MRPProcesoProductivoOperacion.Columnas.CentroProductorOperacion.ToString())
            Dim eCP = New Reglas.MRPCentrosProductores().GetUno(dr.Field(Of Integer)(MRPProcesoProductivoOperacion.Columnas.CentroProductorOperacion.ToString()))
            .DotacionCentroProductor = eCP.Dotacion
            .ClaseCentroProductor = eCP.ClaseCentroProductor
            '-- REQ-41936.- -----------------------------------------------------------------
            If .ClaseCentroProductor = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT Then
               .TipoOperacionExterna = DirectCast([Enum].Parse(GetType(Entidades.MRPProcesoProductivoOperacion.OperacionesExternas), dr(Entidades.MRPProcesoProductivoOperacion.Columnas.TipoOperacionExterna.ToString()).ToString()), Entidades.MRPProcesoProductivoOperacion.OperacionesExternas)
               .DescripcionOperacion = String.Format("{0}-{1}", .DescripcionOperacion, .TipoOperacionExterna.ToString.FirstOrDefault())
            End If
            '--------------------------------------------------------------------------------
         End If
         .UnidadesHora = dr.Field(Of Decimal)(MRPProcesoProductivoOperacion.Columnas.UnidadesHora.ToString())

         .PAPTiemposMaquina = dr.Field(Of Decimal)(MRPProcesoProductivoOperacion.Columnas.PAPTiemposMaquina.ToString())
         .PAPTiemposHHombre = dr.Field(Of Decimal)(MRPProcesoProductivoOperacion.Columnas.PAPTiemposHHombre.ToString())
         .ProdTiemposMaquina = dr.Field(Of Decimal)(MRPProcesoProductivoOperacion.Columnas.ProdTiemposMaquina.ToString())
         .ProdTiemposHHombre = dr.Field(Of Decimal)(MRPProcesoProductivoOperacion.Columnas.ProdTiemposHHombre.ToString())

         If String.IsNullOrEmpty(dr(MRPProcesoProductivoOperacion.Columnas.Proveedor.ToString()).ToString()) Then
            .Proveedor = 0
            .CostoExterno = 0
         Else
            .Proveedor = dr.Field(Of Long)(MRPProcesoProductivoOperacion.Columnas.Proveedor.ToString())
            .CostoExterno = dr.Field(Of Decimal)(MRPProcesoProductivoOperacion.Columnas.CostoExterno.ToString())
         End If

         .NormasDispositivos = dr.Field(Of String)(MRPProcesoProductivoOperacion.Columnas.NormasDispositivos.ToString())
         .NormasMetodos = dr.Field(Of String)(MRPProcesoProductivoOperacion.Columnas.NormasMetodos.ToString())
         .NormasSeguridad = dr.Field(Of String)(MRPProcesoProductivoOperacion.Columnas.NormasSeguridad.ToString())
         .NormasControlCalidad = dr.Field(Of String)(MRPProcesoProductivoOperacion.Columnas.NormasControlCalidad.ToString())


         .IdOperacionExternaVinculada = dr.Field(Of Integer?)(MRPProcesoProductivoOperacion.Columnas.IdOperacionExternaVinculada.ToString())

         .CategoriasEmpleados = New MRPProcesosProductivosCategoriasEmpleados(da).GetTodas(dr.Field(Of Long)(MRPProcesoProductivoOperacion.Columnas.IdProcesoProductivo.ToString()),
                                                                                                dr.Field(Of Integer)(MRPProcesoProductivoOperacion.Columnas.IdOperacion.ToString()))

         .ProductosNecesario = New MRPProcesosProductivosProductos(da).GetTodos(dr.Field(Of Long)(MRPProcesoProductivoOperacion.Columnas.IdProcesoProductivo.ToString()),
                                                                                     dr.Field(Of Integer)(MRPProcesoProductivoOperacion.Columnas.IdOperacion.ToString()),
                                                                                     Entidades.Publicos.SiNoTodos.SI)
         .ProductosResultantes = New MRPProcesosProductivosProductos(da).GetTodos(dr.Field(Of Long)(MRPProcesoProductivoOperacion.Columnas.IdProcesoProductivo.ToString()),
                                                                                     dr.Field(Of Integer)(MRPProcesoProductivoOperacion.Columnas.IdOperacion.ToString()),
                                                                                     Entidades.Publicos.SiNoTodos.NO)
      End With
   End Sub
#End Region


#Region "Metodos publicos"
   '--
   Public Function GetUna(IdProcesoProductivo As Long, idOperacion As Integer) As MRPProcesoProductivoOperacion
      Return GetUna(IdProcesoProductivo, idOperacion, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(IdProcesoProductivo As Long, idOperacion As Integer, accion As AccionesSiNoExisteRegistro) As MRPProcesoProductivoOperacion
      Return CargaEntidad(Get1(IdProcesoProductivo, idOperacion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MRPProcesoProductivoOperacion(),
                          accion, Function() String.Format("No existe la Operacion ´{0}´ del Proceso Productivo {1}.", idOperacion, IdProcesoProductivo))
   End Function
   '--
   Public Function GetUnaAnterior(IdProcesoProductivo As Long, codigoOperacion As String) As MRPProcesoProductivoOperacion
      Return GetUnaAnterior(IdProcesoProductivo, codigoOperacion, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUnaAnterior(IdProcesoProductivo As Long, codigoOperacion As String, accion As AccionesSiNoExisteRegistro) As MRPProcesoProductivoOperacion
      Return CargaEntidad(Get1Anterior(IdProcesoProductivo, codigoOperacion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MRPProcesoProductivoOperacion(),
                          accion, Function() String.Format("No existe la Operacion ´{0}´ del Proceso Productivo {1}.", codigoOperacion, IdProcesoProductivo))
   End Function
   '--
   Public Function GetTodas(IdProcesoProductivo As Long) As ListConBorrados(Of MRPProcesoProductivoOperacion)
      Dim dt = _GetAll(IdProcesoProductivo)
      Dim o As MRPProcesoProductivoOperacion
      Dim oLis = New ListConBorrados(Of MRPProcesoProductivoOperacion)
      For Each dr As DataRow In dt.Rows
         o = New MRPProcesoProductivoOperacion
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Sub ActualizaDesdeProcesosProductivos(entidad As MRPProcesoProductivo)
      If entidad.Operaciones IsNot Nothing Then
         '-- Elimina los Borrados.- --------------------------------------------------
         For Each ent In entidad.Operaciones.Borrados.OrderBy(Function(x) x.TipoOperacionExterna)
            If ent.IdOperacion > 0 Then
               If ent.TipoOperacionExterna = Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.ENVIO Then
                  '-- Actualiza Envio.-
                  _ActualizaOperEnvioRecepcion(ent.IdOperacion, ent.IdProcesoProductivo, 0)
                  '-- Actualiza Recepcion.-
                  _ActualizaOperEnvioRecepcion(ent.IdOperacionExternaVinculada.IfNull(), ent.IdProcesoProductivo, 0)
               End If
               _Borrar(ent)
            End If
         Next
         '----------------------------------------------------------------------------
         For Each oPP In entidad.Operaciones
            If oPP.IdOperacion > 0 Then
               If oPP.TipoOperacionExterna = Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.RECEPCION AndAlso oPP.IdOperacionExternaVinculada.HasValue Then
                  Dim ePrevia = entidad.Operaciones.Where(Function(x) x.IdOperacion = oPP.IdOperacionExternaVinculada.IfNull())
                  With oPP
                     .CentroProductorOperacion = ePrevia(0).CentroProductorOperacion
                     .Proveedor = ePrevia(0).Proveedor
                  End With
               End If
               _Actualizar(oPP)
            Else
               oPP.IdOperacion = GetCodigoMaximo(entidad.IdProcesoProductivo) + 1
               oPP.IdProcesoProductivo = entidad.IdProcesoProductivo
               If oPP.TipoOperacionExterna = Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.ENVIO Then
                  '-- Inserta Envio.-
                  _Insertar(oPP)
                  '-- Crea Recepcion.
                  CreaOperacionExternaRecepcion(oPP)
                  '-- Inserta Recepcion.-
                  _Insertar(oPP)
                  '-- Actualiza Envio-Recepcion.-
                  _ActualizaOperEnvioRecepcion(oPP.IdOperacionExternaVinculada.IfNull(), oPP.IdProcesoProductivo, oPP.IdOperacion)
               Else
                  _Insertar(oPP)
               End If
            End If
         Next
         '----------------------------------------------------------------------------
      End If
   End Sub

   Public Sub CreaOperacionExternaRecepcion(operacion As MRPProcesoProductivoOperacion)
      With operacion
         .IdOperacionExternaVinculada = .IdOperacion
         .IdOperacion = .IdOperacion + 1
         .CodigoProcProdOperacion = (Integer.Parse(.CodigoProcProdOperacion.ToString()) + 1).ToString("000")
         .TipoOperacionExterna = Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.RECEPCION
         .CostoExterno = 0
         For Each ce In .CategoriasEmpleados
            ce.IdOperacion = 0
            ce.IdProcesoProductivo = 0
         Next
         For Each pn In .ProductosNecesario
            pn.IdOperacion = 0
            pn.IdProcesoProductivo = 0
         Next
         For Each pr In .ProductosResultantes
            pr.IdOperacion = 0
            pr.IdProcesoProductivo = 0
         Next
      End With
   End Sub

   Public Function GetCodigoMaximo(idProcesoProductivo As Long) As Integer
      Return New SqlServer.MRPProcesosProductivosOperaciones(Me.da).GetCodigoMaximo(idProcesoProductivo)
   End Function
   ''' <summary>
   ''' Calcula los costos y Tiempos de las Operaciones en la carga de PP.-
   ''' </summary>
   ''' <param name="operaciones">Listado de Operaciones.</param>
   ''' <returns></returns>
   Public Function CalculaCostosTiempos(operaciones As ListConBorrados(Of Entidades.MRPProcesoProductivoOperacion),
                                        recalcula As Boolean,
                                        cotizaPadre As Decimal) As Entidades.Result_CostosTiemposProcesosProductivos
      Dim resultCostoTiempo = New Entidades.Result_CostosTiemposProcesosProductivos
      If operaciones IsNot Nothing Then
         With resultCostoTiempo
            .TiempoTotalProceso = operaciones.Sum(Function(x) x.PAPTiemposHHombre + x.ProdTiemposHHombre + x.ProdTiemposMaquina)
            For Each oOP In operaciones.OrderBy(Function(x) x.CodigoProcProdOperacion)
               Dim horasHombre = oOP.PAPTiemposHHombre + oOP.ProdTiemposHHombre
               .CostoManoObraExterna += oOP.CostoExterno / cotizaPadre
               If recalcula Then
                  '-- Productos Necesarios.- ------------------------------------------------------
                  For Each oPN In oOP.ProductosNecesario
                     Dim eProd = New Reglas.Productos().GetUno(oPN.IdProductoProceso, False, True)
                     Dim cotiza = New Reglas.Monedas().GetUna(eProd.Moneda.IdMoneda).FactorConversion
                     Dim oOperAnt = operaciones.Where(Function(x) x.CodigoProcProdOperacion < oOP.CodigoProcProdOperacion).OrderByDescending(Function(a) a.CodigoProcProdOperacion)
                     If oOperAnt.Count = 0 Then
                        oPN.NewPrecioCostoProducto = eProd.PrecioCosto
                        oPN.NewCostosProducto = (eProd.PrecioCosto * oPN.CantidadSolicitada)
                     Else
                        Dim oProdAnt = oOperAnt.ElementAt(0).ProductosResultantes.Where(Function(x) x.IdProductoProceso = oPN.IdProductoProceso)
                        If oProdAnt.Count = 0 Then
                           oPN.NewPrecioCostoProducto = eProd.PrecioCosto * cotiza
                           oPN.NewCostosProducto = (eProd.PrecioCosto * oPN.CantidadSolicitada) * cotiza
                        Else
                           oPN.NewPrecioCostoProducto = 0
                           oPN.NewCostosProducto = 0
                        End If
                     End If
                     oPN.IdMonedaProducto = eProd.Moneda.IdMoneda
                     oPN.NombreMonedaProducto = eProd.Moneda.NombreMoneda
                     oPN.CotizaProductoMoneda = cotiza
                  Next
                  '-- Categoria Empleados.---------------------------------------------------------
                  For Each oCE In oOP.CategoriasEmpleados
                     oCE.NewValorHoraCategoria = New Reglas.MRPCategoriasEmpleados().GetUno(oCE.IdCategoriaEmpleado).ValorHoraProduccion
                  Next
                  .CostoManoObraInterna += (oOP.CategoriasEmpleados.Sum(Function(x) x.CantidadCategoria * x.NewValorHoraCategoria) * horasHombre) / cotizaPadre
                  .CostoMateriaPrima += oOP.ProductosNecesario.Sum(Function(x) (x.CantidadSolicitada * x.NewPrecioCostoProducto) * x.CotizaProductoMoneda) / cotizaPadre
               Else
                  .CostoManoObraInterna += (oOP.CategoriasEmpleados.Sum(Function(x) x.CantidadCategoria * x.ValorHoraCategoria) * horasHombre) / cotizaPadre
                  .CostoMateriaPrima += oOP.ProductosNecesario.Sum(Function(x) x.CantidadSolicitada * x.CostosProductoMoneda) / cotizaPadre
               End If
               '-----------------------------------------------------------------------------------
               .CostosTotalProceso = (.CostoManoObraExterna + .CostoManoObraInterna + .CostoMateriaPrima)
            Next
         End With
      End If
      Return resultCostoTiempo
   End Function

   Public Function TiempoTotalesPAP(IdProcesoProductivo As Long) As Decimal
      Dim tiempoFinalPAP As Decimal = 0
      Dim sqlC = New SqlServer.MRPProcesosProductivosOperaciones(da)
      tiempoFinalPAP = sqlC.TiempoTotalesPAP(IdProcesoProductivo)

      Return tiempoFinalPAP
   End Function

   Public Function ValidaMRPProcesosProductosOperaciones(idSucursal As Integer, IdDeposito As Integer) As Boolean
      Dim dt = New SqlServer.MRPProcesosProductivosOperaciones(da).GetCantidadSucursalesDepositos(idSucursal, IdDeposito)
      Return dt.Rows(0).Field(Of Integer)("Cantidad") > 0
   End Function
#End Region
End Class
