Public Class OrdenesProduccionMRP
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.OrdenProduccionMRP.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- --------------------------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.OrdenProduccionMRP)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.OrdenProduccionMRP)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.OrdenProduccionMRP)))
   End Sub
   '-- Sin transacciones.- ------------------------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Entidades.OrdenProduccionMRP)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.OrdenProduccionMRP)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.OrdenProduccionMRP)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Borrar(enCol As IEnumerable(Of Entidades.OrdenProduccionMRP))
      enCol.ForEachSecure(Sub(entidad) _Borrar(entidad))
   End Sub

   Public Sub _Borrar(entidad As Entidades.OrdenProduccionProducto)
      _Borrar(New Entidades.OrdenProduccionMRP() With {
                     .IdSucursal = entidad.IdSucursal,
                     .IdTipoComprobante = entidad.IdTipoComprobante,
                     .LetraComprobante = entidad.Letra,
                     .CentroEmisor = entidad.CentroEmisor,
                     .NumeroOrdenProduccion = entidad.NumeroOrdenProduccion,
                     .Orden = entidad.Orden,
                     .IdProducto = entidad.IdProducto
              })
   End Sub
   '-----------------------------------------------------------------------------------------------------------------
   Public Function GetTodas(idSucursal As Integer,
                            idTipoComprobante As String,
                            letra As String,
                            centroEmisor As Integer,
                            numeroOrdenProduccion As Long,
                            orden As Integer,
                            idProducto As String) As Entidades.OrdenProduccionMRP

      Dim dt = New SqlServer.OrdenesProduccionMRP(da).OrdenesProduccionMRP_GA(idSucursal:=idSucursal,
                                                                               idTipoComprobante:=idTipoComprobante,
                                                                               letra:=letra,
                                                                               centroEmisor:=centroEmisor,
                                                                               numeroOrdenProduccion:=numeroOrdenProduccion,
                                                                               orden:=orden,
                                                                               idProducto:=idProducto)
      Dim o = New Entidades.OrdenProduccionMRP()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o

   End Function

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.OrdenProduccionMRP, tipo As TipoSP)
      Dim sqlC = New SqlServer.OrdenesProduccionMRP(da)
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Orden de Produccion MRP Productos.- --------
            sqlC.OrdenesProduccionMRP_I(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto,
                                        en.IdProcesoProductivo, en.CodigoProcesoProductivo, en.DescripcionProceso, en.CostoManoObraInterna, en.CostoManoObraExterna,
                                        en.CostoMateriaPrima, en.CostoTotalProceso, en.FechaAltaProceso, en.FechaModificaProceso, en.FechaActualizaCostos,
                                        en.TiempoTotalProceso, en.IdArchivoAdjunto, en.RespetaOrden, en.Activo)
            '-- Actualiza Operaciones.- ---------------------------------
            Dim rOperacionesOP = New Reglas.OrdenesProduccionMRPOperaciones(da)
            rOperacionesOP.ActualizaDesdeOrdenesProduccionMRP(en)
         Case TipoSP._U
            '-- Modifica Orden de Produccion MRP Productos.- --------
            sqlC.OrdenesProduccionMRP_U(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto,
                                        en.IdProcesoProductivo, en.CodigoProcesoProductivo, en.DescripcionProceso, en.CostoManoObraInterna, en.CostoManoObraExterna,
                                        en.CostoMateriaPrima, en.CostoTotalProceso, en.FechaAltaProceso, en.FechaModificaProceso, en.FechaActualizaCostos,
                                        en.TiempoTotalProceso, en.IdArchivoAdjunto, en.RespetaOrden, en.Activo)
            '-- Actualiza Operaciones.- ---------------------------------
            Dim rOperacionesOP = New Reglas.OrdenesProduccionMRPOperaciones(da)
            rOperacionesOP.ActualizaDesdeOrdenesProduccionMRP(en)
         Case TipoSP._D
            '-- Elimina Ordenes Produccion - Operaciones.- ------
            Dim rOperaciones = New Reglas.OrdenesProduccionMRPOperaciones(da)
            For Each eOperac In en.Operaciones
               rOperaciones._Borrar(eOperac)
            Next
            '-- Elimina Orden de Produccion MRP Productos.- --------------------
            sqlC.OrdenesProduccionMRP_D(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden,
                                        en.IdProducto, en.IdProcesoProductivo)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.OrdenProduccionMRP, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.OrdenProduccionMRP.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.OrdenProduccionMRP.Columnas.IdTipoComprobante.ToString())
         .LetraComprobante = dr.Field(Of String)(Entidades.OrdenProduccionMRP.Columnas.LetraComprobante.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.OrdenProduccionMRP.Columnas.CentroEmisor.ToString())
         .NumeroOrdenProduccion = dr.Field(Of Integer)(Entidades.OrdenProduccionMRP.Columnas.NumeroOrdenProduccion.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.OrdenProduccionMRP.Columnas.Orden.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.OrdenProduccionMRP.Columnas.IdProducto.ToString())

         .IdProcesoProductivo = dr.Field(Of Long)(Entidades.OrdenProduccionMRP.Columnas.IdProcesoProductivo.ToString())
         .CodigoProcesoProductivo = dr.Field(Of String)(Entidades.OrdenProduccionMRP.Columnas.CodigoProcesoProductivo.ToString())
         .DescripcionProceso = dr.Field(Of String)(Entidades.OrdenProduccionMRP.Columnas.DescripcionProceso.ToString())

         .CostoManoObraInterna = dr.Field(Of Decimal)(Entidades.OrdenProduccionMRP.Columnas.CostoManoObraInterna.ToString())
         .CostoManoObraExterna = dr.Field(Of Decimal)(Entidades.OrdenProduccionMRP.Columnas.CostoManoObraExterna.ToString())
         .CostoMateriaPrima = dr.Field(Of Decimal)(Entidades.OrdenProduccionMRP.Columnas.CostoMateriaPrima.ToString())
         .CostoTotalProceso = dr.Field(Of Decimal)(Entidades.OrdenProduccionMRP.Columnas.CostoTotalProceso.ToString())

         .FechaAltaProceso = dr.Field(Of Date)(Entidades.OrdenProduccionMRP.Columnas.FechaAltaProceso.ToString())
         .FechaModificaProceso = dr.Field(Of Date)(Entidades.OrdenProduccionMRP.Columnas.FechaModificaProceso.ToString())
         .FechaActualizaCostos = dr.Field(Of Date)(Entidades.OrdenProduccionMRP.Columnas.FechaActualizaCostos.ToString())

         .TiempoTotalProceso = dr.Field(Of Decimal)(Entidades.OrdenProduccionMRP.Columnas.TiempoTotalProceso.ToString())

         .IdArchivoAdjunto = dr.Field(Of Integer?)(Entidades.MRPProcesoProductivo.Columnas.IdArchivoAdjunto.ToString())

         .RespetaOrden = dr.Field(Of Boolean)(Entidades.MRPProcesoProductivo.Columnas.RespetaOrden.ToString())
         .Activo = dr.Field(Of Boolean)(Entidades.MRPProcesoProductivo.Columnas.Activo.ToString())

         .Operaciones = New Reglas.OrdenesProduccionMRPOperaciones(da).GetTodas(dr.Field(Of Integer)(Entidades.OrdenProduccionMRP.Columnas.IdSucursal.ToString()),
                                                                              dr.Field(Of String)(Entidades.OrdenProduccionMRP.Columnas.IdTipoComprobante.ToString()),
                                                                              dr.Field(Of String)(Entidades.OrdenProduccionMRP.Columnas.LetraComprobante.ToString()),
                                                                              dr.Field(Of Integer)(Entidades.OrdenProduccionMRP.Columnas.CentroEmisor.ToString()),
                                                                              dr.Field(Of Integer)(Entidades.OrdenProduccionMRP.Columnas.NumeroOrdenProduccion.ToString()),
                                                                              dr.Field(Of Integer)(Entidades.OrdenProduccionMRP.Columnas.Orden.ToString()),
                                                                              dr.Field(Of String)(Entidades.OrdenProduccionMRP.Columnas.IdProducto.ToString()),
                                                                              dr.Field(Of Long)(Entidades.OrdenProduccionMRP.Columnas.IdProcesoProductivo.ToString()))
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function CargaOrdenProduccionMRP(idproducto As String, idProcesoProd As Long, cantidad As Decimal) As Entidades.OrdenProduccionMRP
      Dim eOPMrp As New Entidades.OrdenProduccionMRP
      Dim eProcProd = New MRPProcesosProductivos(da).GetUno(idProcesoProd, String.Empty)
      With eOPMrp
         .IdSucursal = actual.Sucursal.Id
         .IdProducto = eProcProd.IdProductoProceso

         .IdProcesoProductivo = eProcProd.IdProcesoProductivo
         .CodigoProcesoProductivo = eProcProd.CodigoProcesoProductivo
         .DescripcionProceso = eProcProd.DescripcionProceso
         .CostoManoObraInterna = (eProcProd.CostoManoObraInterna * cantidad)
         .CostoManoObraExterna = (eProcProd.CostoManoObraExterna * cantidad)
         .CostoMateriaPrima = (eProcProd.CostoMateriaPrima * cantidad)
         .CostoTotalProceso = (eProcProd.CostoTotalProceso * cantidad)
         .FechaAltaProceso = eProcProd.FechaAltaProceso
         .FechaModificaProceso = eProcProd.FechaModificaProceso
         .FechaActualizaCostos = eProcProd.FechaActualizaCostos
         '-- Obtiene una sola vez el tiempo de Puesta a Punto.-
         Dim tiempoPAPTotal = New Reglas.MRPProcesosProductivosOperaciones(da).TiempoTotalesPAP(eProcProd.IdProcesoProductivo)
         .TiempoTotalProceso = ((eProcProd.TiempoTotalProceso - tiempoPAPTotal) * cantidad) + tiempoPAPTotal
         '-----------------------------------------------------
         .IdArchivoAdjunto = eProcProd.IdArchivoAdjunto
         .RespetaOrden = eProcProd.RespetaOrden
         .Activo = eProcProd.Activo
         .Operaciones = New Reglas.OrdenesProduccionMRPOperaciones(da).CopiaOrdenProduccionMRPOperaciones(eProcProd, cantidad)
      End With
      Return eOPMrp
   End Function

   Public Sub InsertarDesdeOrdenProduccionProductos(prod As Entidades.OrdenProduccionProducto)
      Dim eOPMRP = New Entidades.OrdenProduccionMRP()

      With eOPMRP
         .IdSucursal = prod.IdSucursal
         .IdTipoComprobante = prod.IdTipoComprobante
         .LetraComprobante = prod.Letra
         .CentroEmisor = prod.CentroEmisor
         .NumeroOrdenProduccion = prod.NumeroOrdenProduccion
         .IdProducto = prod.IdProducto
         .Orden = prod.Orden
         .IdProducto = prod.OrdenesProduccionMRP.IdProducto
         .IdProcesoProductivo = Math.Max(prod.OrdenesProduccionMRP.IdProcesoProductivo, prod.IdProcesoProductivo)
         .CodigoProcesoProductivo = prod.OrdenesProduccionMRP.CodigoProcesoProductivo
         .DescripcionProceso = prod.OrdenesProduccionMRP.DescripcionProceso
         .CostoManoObraInterna = prod.OrdenesProduccionMRP.CostoManoObraInterna
         .CostoManoObraExterna = prod.OrdenesProduccionMRP.CostoManoObraExterna
         .CostoMateriaPrima = prod.OrdenesProduccionMRP.CostoMateriaPrima
         .CostoTotalProceso = prod.OrdenesProduccionMRP.CostoTotalProceso
         .FechaAltaProceso = prod.OrdenesProduccionMRP.FechaAltaProceso
         .FechaModificaProceso = prod.OrdenesProduccionMRP.FechaModificaProceso
         .FechaActualizaCostos = prod.OrdenesProduccionMRP.FechaActualizaCostos
         .TiempoTotalProceso = prod.OrdenesProduccionMRP.TiempoTotalProceso
         .IdArchivoAdjunto = prod.OrdenesProduccionMRP.IdArchivoAdjunto
         .RespetaOrden = prod.OrdenesProduccionMRP.RespetaOrden
         .Activo = prod.OrdenesProduccionMRP.Activo

         .Operaciones = prod.OrdenesProduccionMRP.Operaciones
      End With
      _Insertar(eOPMRP)
   End Sub

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                          orden As Integer, idProducto As String, idProcesoProductivo As Long) As Entidades.OrdenProduccionMRP
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, orden, idProducto, idProcesoProductivo, AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                          orden As Integer, idProducto As String, idProcesoProductivo As Long, accion As AccionesSiNoExisteRegistro) As Entidades.OrdenProduccionMRP
      Using dt = New SqlServer.OrdenesProduccionMRP(da).OrdenesProduccionMRP_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                                                orden, idProducto, idProcesoProductivo)
         Return CargaEntidad(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.OrdenProduccionMRP(),
                             accion, Function() String.Format("No existe MRP para la orden {0}/{1} {2} {3:0000}-{4:00000000} - Ord: {5} - Prod: '{6}' / Proc. Prod.: {7}",
                                                              idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, orden, idProducto, idProcesoProductivo))
      End Using
   End Function

   Public Function GetOrdenesProduccionImpresionMasiva(idSucursal As Integer,
                                                       idEstado As String,
                                                       idResponsable As Integer,
                                                       idCliente As Long,
                                                       idProducto As String,
                                                       idSeccion As Integer,
                                                       idTarea As Integer,
                                                       idCentroProductor As Integer,
                                                       fechaDesde As Date,
                                                       fechaHasta As Date,
                                                       fechaDesdeEstado As Date?,
                                                       fechaHastaEstado As Date?,
                                                       idNroPedido As Integer,
                                                       lineaNroPedido As Integer,
                                                       idTipoComprobantePedido As String,
                                                       IdOrdenProduccion As Integer,
                                                       idTipoComprobanteOP As String,
                                                       nroPlanMaestro As Integer,
                                                       fechaDesdePlan As Date?,
                                                       fechaHastaPlan As Date?,
                                                       tipoImpresion As Integer) As DataTable
      Dim sql = New SqlServer.OrdenesProduccionMRP(da)
      Return sql.GetOrdenesProduccionImpresionMasiva(idSucursal,
                                                     idEstado,
                                                     idResponsable,
                                                     idCliente,
                                                     idProducto,
                                                     idSeccion,
                                                     idTarea,
                                                     idCentroProductor,
                                                     fechaDesde,
                                                     fechaHasta,
                                                     fechaDesdeEstado,
                                                     fechaHastaEstado,
                                                     idNroPedido,
                                                     lineaNroPedido,
                                                     idTipoComprobantePedido,
                                                     IdOrdenProduccion,
                                                     idTipoComprobanteOP,
                                                     nroPlanMaestro,
                                                     fechaDesdePlan,
                                                     fechaHastaPlan,
                                                     tipoImpresion)
   End Function
#End Region
End Class
