Imports Eniac.Entidades

Public Class OrdenesProduccion
   Inherits Base

   Private _cache As BusquedasCacheadas

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "OrdenProduccion"
      da = accesoDatos
      _categoriaFiscalEmpresa = New Eniac.Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)
      _cache = New BusquedasCacheadas()
   End Sub

#End Region

   Private _categoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal

#Region "Overrides"

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      Dim oOrdenProduccion As Entidades.OrdenProduccion = DirectCast(entidad, Entidades.OrdenProduccion)

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Me.Actualiza(oOrdenProduccion)

         Me.da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)

      Dim oOrdenProduccion As Entidades.OrdenProduccion = DirectCast(entidad, Entidades.OrdenProduccion)

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Me.Inserta(oOrdenProduccion)

         Me.da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)

      Dim oOrdenProduccion As Entidades.OrdenProduccion = DirectCast(entidad, Entidades.OrdenProduccion)
      Try
         da.OpenConection()
         da.BeginTransaction()

         ' Me.EjecutaSP(oOrdenesProduccion, TipoSP._D)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

#End Region

#Region "metodos privates"

   Private Function Actualiza(oOrdenProduccion As Entidades.OrdenProduccion) As Entidades.OrdenProduccion

      VerificaOrdenProduccionModificable(oOrdenProduccion)
      Borra(oOrdenProduccion, True)
      Return Inserta(oOrdenProduccion)

   End Function

   Private Sub Borra(oOrdenProduccion As Entidades.OrdenProduccion, deleteParaReInsertar As Boolean)

      Me.EjecutaSP(oOrdenProduccion, TipoSP._D, deleteParaReInsertar)

   End Sub

   Public Function Inserta(oOrdenesProduccion As Entidades.OrdenProduccion) As Entidades.OrdenProduccion

      'Si el Estado de Visita no adminte lineas y el OrdenProduccion viene con lineas, no puedo guardar el OrdenProduccion.
      If Not oOrdenesProduccion.EstadoVisita.AdmintePedidoConLineas And oOrdenesProduccion.OrdenesProduccionProductos.Count > 0 Then
         Throw New Exception(String.Format("El estado de visita '{0}' del '{1} {2} {3:0000}-{4:00000000}' no adminte lineas. Verifique el estado de visita indicado en el OrdenProduccion.'",
                                           oOrdenesProduccion.NombreEstadoVisita, oOrdenesProduccion.IdTipoComprobante, oOrdenesProduccion.LetraComprobante, oOrdenesProduccion.CentroEmisor, oOrdenesProduccion.NumeroOrdenProduccion))
      End If

      'Si el Estado de Visita no adminte sin lineas y el OrdenProduccion viene sin lineas, no puedo guardar el OrdenProduccion.
      If Not oOrdenesProduccion.EstadoVisita.AdmitePedidoSinLineas And oOrdenesProduccion.OrdenesProduccionProductos.Count = 0 Then
         Throw New Exception(String.Format("El estado de visita '{0}' del '{1} {2} {3:0000}-{4:00000000}' requiere al menos una linea. Verifique el estado de visita indicado en el OrdenProduccion.'",
                                           oOrdenesProduccion.NombreEstadoVisita, oOrdenesProduccion.IdTipoComprobante, oOrdenesProduccion.LetraComprobante, oOrdenesProduccion.CentroEmisor, oOrdenesProduccion.NumeroOrdenProduccion))
      End If

      If oOrdenesProduccion.NumeroOrdenProduccion > 0 Then
         'SPC: OrdenesProduccion - PENDIENTE DEFINIR SI EXISTE
         'If Me.Existe(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, _
         '               oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor, _
         '               oVentas.NumeroComprobante) Then
         '   Throw New Exception("El Numero de Comprobante " & oVentas.NumeroComprobante.ToString() & " YA Existe.")
         'End If
      End If

      oOrdenesProduccion.CentroEmisor = oOrdenesProduccion.Impresora.CentroEmisor

      Dim oVentasNumeros As Reglas.VentasNumeros = New Reglas.VentasNumeros(da)
      Dim NumeroComprob As Long = oVentasNumeros.GetProximoNumero(_cache.BuscaSucursal(oOrdenesProduccion.IdSucursal), oOrdenesProduccion.IdTipoComprobante,
                                                                  oOrdenesProduccion.LetraComprobante, oOrdenesProduccion.CentroEmisor)
      'Tiene que ser NO fiscal y NO haberlo digitado en la pantalla.A
      If oOrdenesProduccion.NumeroOrdenProduccion = 0 Then
         oOrdenesProduccion.NumeroOrdenProduccion = NumeroComprob
      End If

      'actualizo el numero de venta en las tablas solo si el numero se calculo
      If oOrdenesProduccion.NumeroOrdenProduccion >= NumeroComprob Then
         Dim rVta As Ventas = New Ventas(da)
         rVta.ActualizarNumerosVentas(oOrdenesProduccion.IdSucursal, oOrdenesProduccion.IdTipoComprobante,
                                      oOrdenesProduccion.LetraComprobante, oOrdenesProduccion.CentroEmisor,
                                      oOrdenesProduccion.NumeroOrdenProduccion, oOrdenesProduccion.Fecha)
      End If


      Me.EjecutaSP(oOrdenesProduccion, TipoSP._I, False)

      Dim rPedProd As OrdenesProduccionProductos = New OrdenesProduccionProductos(da)
      rPedProd.InsertaDetalleDesdeOrdenProduccion(oOrdenesProduccion)

      Dim rPedObs As OrdenesProduccionObservaciones = New OrdenesProduccionObservaciones(da)
      rPedObs.InsertaObservacionesDesdeOrdenProduccion(oOrdenesProduccion)

      Return oOrdenesProduccion
   End Function

   Public Sub EjecutaSP(oOrdenesProduccion As Eniac.Entidades.OrdenProduccion, tipo As TipoSP, deleteParaReInsertar As Boolean)

      Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)

      Select Case tipo

         Case TipoSP._I
            sql.OrdenesProduccion_I(oOrdenesProduccion.IdSucursal,
                          oOrdenesProduccion.IdTipoComprobante,
                          oOrdenesProduccion.LetraComprobante,
                          oOrdenesProduccion.CentroEmisor,
                          oOrdenesProduccion.NumeroOrdenProduccion,
                          oOrdenesProduccion.Fecha,
                          oOrdenesProduccion.Observacion,
                          actual.Nombre,
                          oOrdenesProduccion.DescuentoRecargo,
                          oOrdenesProduccion.DescuentoRecargoPorc,
                          oOrdenesProduccion.Cliente.IdCliente,
                          oOrdenesProduccion.IdEmpleado,
                          oOrdenesProduccion.IdFormaPago,
                          oOrdenesProduccion.IdTransportista,
                          oOrdenesProduccion.CotizacionDolar,
                          oOrdenesProduccion.IdTipoComprobanteFact,
                          oOrdenesProduccion.ImporteBruto,
                          oOrdenesProduccion.SubTotal,
                          oOrdenesProduccion.TotalImpuestos,
                          oOrdenesProduccion.TotalImpuestoInterno,
                          oOrdenesProduccion.ImporteTotal,
                          oOrdenesProduccion.IdEstadoVisita,
                          oOrdenesProduccion.NumeroOrdenCompra)

         Case TipoSP._U

         Case TipoSP._D

            If deleteParaReInsertar Then
               Dim sqlPeP As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)
               sqlPeP.PedidosEstados_U_Libera_Produccion(oOrdenesProduccion.IdSucursal, oOrdenesProduccion.IdTipoComprobante, oOrdenesProduccion.LetraComprobante,
                                                         oOrdenesProduccion.CentroEmisor, oOrdenesProduccion.NumeroOrdenProduccion, idproductoProduccion:=String.Empty, ordenProduccion:=0)
            End If

            Dim rOpMrp = New OrdenesProduccionMRP(da)
            rOpMrp._Borrar(rOpMrp.GetTodas(oOrdenesProduccion.IdSucursal, oOrdenesProduccion.IdTipoComprobante, oOrdenesProduccion.LetraComprobante,
                                           oOrdenesProduccion.CentroEmisor, oOrdenesProduccion.NumeroOrdenProduccion, orden:=0, idProducto:=String.Empty))

            Dim sqlPE As SqlServer.OrdenesProduccionEstados = New SqlServer.OrdenesProduccionEstados(da)
            sqlPE.OrdenesProduccionEstados_D(oOrdenesProduccion.IdSucursal, oOrdenesProduccion.IdTipoComprobante, oOrdenesProduccion.LetraComprobante, oOrdenesProduccion.CentroEmisor, oOrdenesProduccion.NumeroOrdenProduccion, Nothing, String.Empty, Nothing)
            Dim sqlPPF = New SqlServer.OrdenesProduccionProductosFormulas(da)
            sqlPPF.OrdenesProduccionProductosFormulas_D(oOrdenesProduccion.IdSucursal, oOrdenesProduccion.IdTipoComprobante, oOrdenesProduccion.LetraComprobante, oOrdenesProduccion.CentroEmisor, oOrdenesProduccion.NumeroOrdenProduccion)
            Dim sqlPP As SqlServer.OrdenesProduccionProductos = New SqlServer.OrdenesProduccionProductos(da)
            sqlPP.OrdenesProduccionProductos_D(oOrdenesProduccion.IdSucursal, oOrdenesProduccion.IdTipoComprobante, oOrdenesProduccion.LetraComprobante, oOrdenesProduccion.CentroEmisor, oOrdenesProduccion.NumeroOrdenProduccion, Nothing, String.Empty)
            Dim sqlPO As SqlServer.OrdenesProduccionObservaciones = New SqlServer.OrdenesProduccionObservaciones(da)
            sqlPO.OrdenesProduccionObservaciones_D(oOrdenesProduccion.IdSucursal, oOrdenesProduccion.IdTipoComprobante, oOrdenesProduccion.LetraComprobante, oOrdenesProduccion.CentroEmisor, oOrdenesProduccion.NumeroOrdenProduccion, Nothing)

            sql.OrdenesProduccion_D(oOrdenesProduccion.IdSucursal, oOrdenesProduccion.IdTipoComprobante, oOrdenesProduccion.LetraComprobante, oOrdenesProduccion.CentroEmisor, oOrdenesProduccion.NumeroOrdenProduccion)
      End Select

   End Sub


   Private Sub CargarUna(o As Entidades.OrdenProduccion, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.OrdenProduccion.Columnas.IdSucursal.ToString()).ToString())
         .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr(Entidades.OrdenProduccion.Columnas.IdTipoComprobante.ToString()).ToString())
         .LetraComprobante = dr(Entidades.OrdenProduccion.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.OrdenProduccion.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroOrdenProduccion = Long.Parse(dr(Entidades.OrdenProduccion.Columnas.NumeroOrdenProduccion.ToString()).ToString())
         .Fecha = Date.Parse(dr(Entidades.OrdenProduccion.Columnas.FechaOrdenProduccion.ToString()).ToString())

         .Cliente = New Reglas.Clientes(da)._GetUno(Long.Parse(dr(Entidades.OrdenProduccion.Columnas.IdCliente.ToString()).ToString()))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.OrdenProduccion.Columnas.IdVendedor.ToString()).ToString()) Then
            .Vendedor = New Reglas.Empleados(da).GetUno(Integer.Parse(dr(Entidades.OrdenProduccion.Columnas.IdVendedor.ToString()).ToString()))
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.OrdenProduccion.Columnas.IdTransportista.ToString()).ToString()) Then
            .Transportista = New Reglas.Transportistas(da).GetUno(Long.Parse(dr(Entidades.OrdenProduccion.Columnas.IdTransportista.ToString()).ToString()))
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.OrdenProduccion.Columnas.IdFormasPago.ToString()).ToString()) Then
            .FormaPago = New Reglas.VentasFormasPago(da).GetUna(Integer.Parse(dr(Entidades.OrdenProduccion.Columnas.IdFormasPago.ToString()).ToString()))
         End If

         .DescuentoRecargo = Decimal.Parse(dr(Entidades.OrdenProduccion.Columnas.DescuentoRecargo.ToString()).ToString())
         .DescuentoRecargoPorc = Decimal.Parse(dr(Entidades.OrdenProduccion.Columnas.DescuentoRecargoPorc.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.OrdenProduccion.Columnas.CotizacionDolar.ToString()).ToString()) Then
            .CotizacionDolar = Decimal.Parse(dr(Entidades.OrdenProduccion.Columnas.CotizacionDolar.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.OrdenProduccion.Columnas.IdTipoComprobanteFact.ToString()).ToString()) Then
            .TipoComprobanteFact = New Reglas.TiposComprobantes(da).GetUno(dr(Entidades.OrdenProduccion.Columnas.IdTipoComprobanteFact.ToString()).ToString())
         End If

         .Observacion = dr(Entidades.OrdenProduccion.Columnas.Observacion.ToString()).ToString()

         .IdUsuario = dr(Entidades.OrdenProduccion.Columnas.IdUsuario.ToString()).ToString()


         .OrdenesProduccionProductos = New OrdenesProduccionProductos(da).GetTodos(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroOrdenProduccion)
         .OrdenesProduccionObservaciones = New OrdenesProduccionObservaciones(da).GetTodos(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroOrdenProduccion)

         If Not .CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
            For Each vp In .OrdenesProduccionProductos
               vp.Precio = Math.Round(vp.Precio * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), 2)
               vp.PrecioLista = Math.Round(vp.PrecioLista * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), 2)
               vp.PrecioNeto = Math.Round(vp.PrecioNeto * (1 + (vp.AlicuotaImpuesto / 100)) + (vp.ImporteImpuestoInterno / vp.Cantidad), 2)
               vp.ImporteTotal = Math.Round(vp.ImporteTotal * (1 + (vp.AlicuotaImpuesto / 100)) + vp.ImporteImpuestoInterno, 2)
               vp.ImporteTotalNeto = Math.Round(vp.ImporteTotalNeto * (1 + (vp.AlicuotaImpuesto / 100)) + vp.ImporteImpuestoInterno, 2)
            Next
         End If

         .ImporteBruto = Decimal.Parse(dr(Entidades.OrdenProduccion.Columnas.ImporteBruto.ToString()).ToString())
         .SubTotal = Decimal.Parse(dr(Entidades.OrdenProduccion.Columnas.SubTotal.ToString()).ToString())
         .TotalImpuestos = Decimal.Parse(dr(Entidades.OrdenProduccion.Columnas.TotalImpuestos.ToString()).ToString())
         .TotalImpuestoInterno = Decimal.Parse(dr(Entidades.OrdenProduccion.Columnas.TotalImpuestoInterno.ToString()).ToString())
         .ImporteTotal = Decimal.Parse(dr(Entidades.OrdenProduccion.Columnas.ImporteTotal.ToString()).ToString())

         .EstadoVisita = New EstadosVisitas(da).GetUno(Integer.Parse(dr(Entidades.OrdenProduccion.Columnas.IdEstadoVisita.ToString()).ToString()))

         If Not String.IsNullOrWhiteSpace(dr(Entidades.OrdenProduccion.Columnas.NumeroOrdenCompra.ToString()).ToString()) Then
            .NumeroOrdenCompra = Long.Parse(dr(Entidades.OrdenProduccion.Columnas.NumeroOrdenCompra.ToString()).ToString())
         End If
      End With
   End Sub

#End Region

#Region "metodos publicos"
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long) As Entidades.OrdenProduccion
      Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)
      Dim dt As DataTable = sql.OrdenesProduccion_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion)
      Dim o As Entidades.OrdenProduccion = New Entidades.OrdenProduccion()
      If dt.Rows.Count > 0 Then
         Me.CargarUna(o, dt.Rows(0))
      Else
         Throw New Exception(String.Format("No existe el OrdenProduccion {0}-{1:00000000}.", idSucursal, numeroOrdenProduccion))
      End If
      Return o
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sql As SqlServer.EstadosOrdenesProduccion = New SqlServer.EstadosOrdenesProduccion(da)
      Return sql.EstadosOrdenesProduccion_GA()
   End Function

   Public Sub AnulacionOrdenesProduccionPlanMaestro(tablaAnular As DataTable, idFuncion As String)
      EjecutaConTransaccion(Sub() _AnulacionOrdenesProduccionPlanMaestro(tablaAnular, idFuncion))
   End Sub
   Public Sub _AnulacionOrdenesProduccionPlanMaestro(tablaAnular As DataTable, idFuncion As String)
      '-- Paso todas las ordenes del Plan a Estado PENDIENTE. Solo se permite anular Ordenes En estado Pendiente.-
      '-- Recupera Estado Final de la OP.- --------------
      Dim estadoNuevo As String = Entidades.EstadoOrdenProduccion.TipoEstado.PENDIENTE
      '--------------------------------------------------
      Dim tblAnuladas = tablaAnular.Clone()

      Dim rOP = New OrdenesProduccion(da)
      Dim rOPE = New OrdenesProduccionEstados(da)
      '-- Actualiza Estado Padres.-
      For Each dr As DataRow In tablaAnular.Rows
         If VerificaOrdenProduccionParaAnular(dr) Then
            Dim lst = rOPE.GetParaAdmin(dr.Field(Of Integer)("IdSucursal"), dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"), dr.Field(Of Integer)("CentroEmisor"), dr.Field(Of Integer)("NumeroOrdenProduccion"),
                                     dr.Field(Of Integer)("Orden"), dr.Field(Of String)("IdProducto"), dr.Field(Of DateTime)("FechaEstado"))
            Dim cambio = New Entidades.OrdenesProduccionAdminCambioEstado(_cache.BuscaEstadosOrdenesProduccion(estadoNuevo))
            cambio.Pedidos = lst.ConvertAll(Function(op) op.SetPlanMaestro(Nothing, Nothing))
            rOPE._ActualizarEstadoOrdenProduccionMasivo(cambio, idFuncion)
            If New Reglas.OrdenesProduccionMRPProductos(da).ValidaOrdenProduccionSeaHija(dr.Field(Of Integer)("IdSucursal"), dr.Field(Of String)("IdTipoComprobante"),
                                                                                      dr.Field(Of String)("Letra"), dr.Field(Of Integer)("CentroEmisor"),
                                                                                      dr.Field(Of Integer)("NumeroOrdenProduccion"),
                                                                                      dr.Field(Of Integer)("Orden"), dr.Field(Of String)("IdProducto")) Then

               tblAnuladas.AddCopy(dr)
            End If
         Else
            Exit Sub
         End If
      Next
      If tblAnuladas.Rows.Count > 0 Then
         '-- Anula las Ordenes de Produccion Hijas.-
         rOP._AnularOrdenesProduccion(tblAnuladas)
      End If
   End Sub

   Private Function VerificaOrdenProduccionParaAnular(dr As DataRow) As Boolean
      Dim respVerifica As Boolean = False
      Dim dtAsig As DataTable = New SqlServer.OrdenesProduccion(da).VerificaOrdenProduccionParaAnularAsignacion(dr.Field(Of Integer)("IdSucursal"),
                                                                                                            dr.Field(Of String)("IdTipoComprobante"),
                                                                                                            dr.Field(Of String)("Letra"),
                                                                                                            dr.Field(Of Integer)("CentroEmisor"),
                                                                                                            dr.Field(Of Integer)("NumeroOrdenProduccion"))
      If dtAsig.Rows.Count = 0 Then
         Dim dtNov As DataTable = New SqlServer.OrdenesProduccion(da).VerificaOrdenProduccionParaAnularNovedades(dr.Field(Of Integer)("IdSucursal"),
                                                                                                            dr.Field(Of String)("IdTipoComprobante"),
                                                                                                            dr.Field(Of String)("Letra"),
                                                                                                            dr.Field(Of Integer)("CentroEmisor"),
                                                                                                            dr.Field(Of Integer)("NumeroOrdenProduccion"))
         If dtNov.Rows.Count = 0 Then
            Return True
         Else
            Throw New Exception(String.Format("La {0} {1} {2:0000}-{3:00000000} no se puede Anular.{4}Posee Declaraciones de Producción",
                    dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"),
                    dr.Field(Of Integer)("CentroEmisor"), dr.Field(Of Integer)("NumeroOrdenProduccion"), Environment.NewLine))
         End If
      Else
         Throw New Exception(String.Format("La {0} {1} {2:0000}-{3:00000000} no se puede Anular.{4}Posee Asignaciones de Actividades",
                    dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"),
                    dr.Field(Of Integer)("CentroEmisor"), dr.Field(Of Integer)("NumeroOrdenProduccion"), Environment.NewLine))
      End If
      Return respVerifica
   End Function

   Public Sub AnularOrdenesProduccion(tablaAnular As DataTable)
      EjecutaConTransaccion(Sub() _AnularOrdenesProduccion(tablaAnular))
   End Sub



   Public Sub _AnularOrdenesProduccion(tablaAnular As DataTable)
      Dim rPP = New OrdenesProduccionProductos(da)
      Dim rPE = New OrdenesProduccionEstados(da)
      Dim sqlPE = New SqlServer.OrdenesProduccionEstados(da)

      Dim idTipoEstadoAnterior = Entidades.EstadoOrdenProduccion.TipoEstado.PENDIENTE ' SOLO SE PERMITE ANULAR OrdenesProduccion CON TIPO ESTADO 'PENDIENTE', SI ESTÁ EN 'EN PROCESO' DEBE CAMBIARSE DE ESTADO POR EL ADMIN Y LUEGO ANULARSE.
      Dim idEstadoNuevo = Entidades.EstadoOrdenProduccion.ESTADO_ANULADO '' "ANULADO"
      Dim idTipoEstadoNuevo = New EstadosOrdenesProduccion(da).GetUno(idEstadoNuevo).IdTipoEstado

      For Each filaAnula In tablaAnular.AsEnumerable()
         Dim dtAux = sqlPE.OrdenesProduccionEstados_GA(Integer.Parse(filaAnula(Entidades.OrdenProduccion.Columnas.IdSucursal.ToString()).ToString),
                                            filaAnula(Entidades.OrdenProduccion.Columnas.IdTipoComprobante.ToString()).ToString(),
                                            filaAnula(Entidades.OrdenProduccion.Columnas.Letra.ToString()).ToString(),
                                            Integer.Parse(filaAnula(Entidades.OrdenProduccion.Columnas.CentroEmisor.ToString()).ToString()),
                                            Long.Parse(filaAnula(Entidades.OrdenProduccion.Columnas.NumeroOrdenProduccion.ToString()).ToString()),
                                            idTipoEstadoAnterior)
         For Each filaPendiente In dtAux.AsEnumerable()
            sqlPE.OrdenesProduccionEstados_U_Estado(Integer.Parse(filaPendiente(Entidades.OrdenProduccionEstado.Columnas.IdSucursal.ToString()).ToString()),
                                             filaPendiente(Entidades.OrdenProduccionEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                                             filaPendiente(Entidades.OrdenProduccionEstado.Columnas.Letra.ToString()).ToString(),
                                             Integer.Parse(filaPendiente(Entidades.OrdenProduccionEstado.Columnas.CentroEmisor.ToString()).ToString()),
                                             Long.Parse(filaPendiente(Entidades.OrdenProduccionEstado.Columnas.NumeroOrdenProduccion.ToString()).ToString()),
                                             filaPendiente(Entidades.OrdenProduccionEstado.Columnas.IdProducto.ToString()).ToString(),
                                             Date.Parse(filaPendiente(Entidades.OrdenProduccionEstado.Columnas.FechaEstado.ToString()).ToString),
                                             idEstadoNuevo,
                                             Decimal.Parse(filaPendiente(Entidades.OrdenProduccionEstado.Columnas.CantEstado.ToString()).ToString),
                                             Date.Now,
                                             "OrdenProduccion Anulado",
                                             Integer.Parse(filaPendiente("Orden").ToString),
                                             filaPendiente("IdCriticidad").ToString(),
                                             Date.Parse(filaPendiente("FechaEntrega").ToString),
                                             0,
                                             Integer.Parse(filaPendiente("IdResponsable").ToString()), Nothing, Nothing)
            rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(Integer.Parse(filaPendiente(Entidades.OrdenProduccionEstado.Columnas.IdSucursal.ToString()).ToString()),
                                                            filaPendiente(Entidades.OrdenProduccionEstado.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                            filaPendiente(Entidades.OrdenProduccionEstado.Columnas.Letra.ToString()).ToString(),
                                                            Integer.Parse(filaPendiente(Entidades.OrdenProduccionEstado.Columnas.CentroEmisor.ToString()).ToString()),
                                                            Long.Parse(filaPendiente(Entidades.OrdenProduccionEstado.Columnas.NumeroOrdenProduccion.ToString()).ToString()),
                                                            filaPendiente(Entidades.OrdenProduccionEstado.Columnas.IdProducto.ToString()).ToString(),
                                                            Integer.Parse(filaPendiente("Orden").ToString),
                                                            idTipoEstadoAnterior, idTipoEstadoNuevo,
                                                            Decimal.Parse(filaPendiente(Entidades.OrdenProduccionEstado.Columnas.CantEstado.ToString()).ToString()))

            rPE.ReservaMateriaPrima(filaPendiente.Field(Of Integer)(Entidades.OrdenProduccionEstado.Columnas.IdSucursal.ToString()),
                                    filaPendiente.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.IdTipoComprobante.ToString()),
                                    filaPendiente.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.Letra.ToString()),
                                    filaPendiente.Field(Of Integer)(Entidades.OrdenProduccionEstado.Columnas.CentroEmisor.ToString()),
                                    filaPendiente.Field(Of Integer)(Entidades.OrdenProduccionEstado.Columnas.NumeroOrdenProduccion.ToString()),
                                    filaPendiente.Field(Of String)(Entidades.OrdenProduccionEstado.Columnas.IdProducto.ToString()),
                                    filaPendiente.Field(Of Integer)("Orden"),
                                    idTipoEstadoAnterior, idTipoEstadoNuevo,
                                    filaPendiente.Field(Of Decimal)(Entidades.OrdenProduccionEstado.Columnas.CantEstado.ToString()),
                                    espmm:=0, largoExtAlto:=0, anchoIntBase:=0,
                                    Entidades.Entidad.MetodoGrabacion.Automatico, "OrdenesDeProduccion")
         Next
         ' Ver si elimina Ordenes Compras OrdenesProduccion
      Next
   End Sub

   Public Function GetOrdenesProduccion(idSucursal As Integer, idEstado As String,
                              fechaDesde As Date, fechaHasta As Date, numeroOrdenProduccion As Long,
                              idProducto As String, idCliente As Long, tamanio As Decimal,
                              idMarca As Integer, idRubro As Integer, idSubRubro As Integer,
                              OrdenCompra As Long, idResponsable As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer,
                              idPlanMaestro As Integer, fechaDesdePlan As Date?, fechaHastaPlan As Date?) As DataTable
      Return GetOrdenesProduccion(idSucursal, {}, idEstado,
                              fechaDesde, fechaHasta, numeroOrdenProduccion,
                              idProducto, idCliente, tamanio,
                              If(idMarca <> 0, {_cache.BuscaMarca(idMarca)}, {}), {},
                              If(idRubro <> 0, {_cache.BuscaRubro(idRubro)}, {}), If(idSubRubro <> 0, {_cache.BuscaSubRubroEntidad(idSubRubro)}, {}), {},
                              OrdenCompra, idResponsable, idTipoComprobante, letra, centroEmisor, idPlanMaestro, fechaDesdePlan, fechaHastaPlan)
   End Function

   Public Function GetOrdenesProduccion(idSucursal As Integer, tiposComprobantes As Entidades.TipoComprobante(), idEstado As String,
                              fechaDesde As Date, fechaHasta As Date, numeroOrdenProduccion As Long,
                              idProducto As String, idCliente As Long, tamanio As Decimal,
                              marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                              rubros As Entidades.Rubro(), subRubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro(),
                              ordenCompra As Long, idResponsable As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer,
                              idPlanMaestro As Integer, fechaDesdePlan As Date?, fechaHastaPlan As Date?) As DataTable
      Dim sql = New SqlServer.OrdenesProduccion(da)
      Return sql.GetOrdenesProduccion(idSucursal, tiposComprobantes, idEstado,
                              fechaDesde, fechaHasta, numeroOrdenProduccion,
                              idProducto, idCliente, tamanio,
                              marcas, modelos, rubros, subRubros, subSubRubros,
                              ordenCompra, idResponsable, idTipoComprobante, letra,
                              centroEmisor, idPlanMaestro, fechaDesdePlan, fechaHastaPlan)
   End Function

   Public Function GetOrdenesProduccionTareas(idSucursal As Integer, idEstado As String,
                                              fechaDesde As Date, fechaHasta As Date, numeroOrdenProduccion As Long,
                                              idProducto As String, idCliente As Long, tamanio As Decimal,
                                              idMarca As Integer, idRubro As Integer, ordenCompra As Long, idResponsable As Integer,
                                              idTipoComprobante As String, seccion As Integer, tarea As Integer,
                                              idPedido As Integer, linea As Integer) As DataTable
      Dim sql = New SqlServer.OrdenesProduccion(da)
      Return sql.GetOrdenesProduccionTareas(idSucursal, idEstado,
                                            fechaDesde, fechaHasta, numeroOrdenProduccion,
                                            idProducto, idCliente, tamanio, idMarca, idRubro, ordenCompra, idResponsable,
                                            idTipoComprobante, seccion, tarea, idPedido, linea)
   End Function

   Public Function GetOrdenesProduccionDeclaracion(idSucursal As Integer, fechaDesde As Date?, fechaHasta As Date?, numeroOrdenProduccion As Long,
                                                   idProducto As String, idCliente As Long, idTipoComprobante As String,
                                                   idPedido As Integer, linea As Integer) As DataTable
      Dim sql = New SqlServer.OrdenesProduccion(da)
      Return sql.GetOrdenesProduccionDeclaracion(idSucursal, fechaDesde, fechaHasta, numeroOrdenProduccion,
                                                 idProducto, idCliente, idTipoComprobante, idPedido, linea)
   End Function

   Public Function GetOrdenesProduccion(idSucursal As Integer, eTipoComprobate As Entidades.TipoComprobante, numeroOrdenCompra As Long) As List(Of Entidades.OrdenProduccion)
      Dim result = New List(Of Entidades.OrdenProduccion)()
      For Each dr As DataRow In New SqlServer.OrdenesProduccion(da).OrdenesProduccion_GA(idSucursal, numeroOrdenCompra).Rows
         Dim o = New Entidades.OrdenProduccion()
         CargarUna(o, dr)
         result.Add(o)
      Next
      Return result
   End Function

   Public Sub VerificaOrdenProduccionModificable(OrdenProduccion As Entidades.OrdenProduccion)
      Dim dt As DataTable = New SqlServer.OrdenesProduccion(da).VerificaOrdenProduccionModificable(OrdenProduccion.IdSucursal,
                                                                                OrdenProduccion.IdTipoComprobante, OrdenProduccion.LetraComprobante,
                                                                                OrdenProduccion.CentroEmisor, OrdenProduccion.NumeroOrdenProduccion)
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Dim OrdenesProduccionProductos As Integer
         Dim OrdenesProduccionEstados As Integer
         Dim OrdenesProduccionEstadosNoPendientes As Integer

         If dt.Columns.Contains("OrdenesProduccionProductos") AndAlso Not String.IsNullOrWhiteSpace(dr("OrdenesProduccionProductos").ToString()) Then
            OrdenesProduccionProductos = Integer.Parse(dr("OrdenesProduccionProductos").ToString())
         End If
         If dt.Columns.Contains("OrdenesProduccionEstados") AndAlso Not String.IsNullOrWhiteSpace(dr("OrdenesProduccionEstados").ToString()) Then
            OrdenesProduccionEstados = Integer.Parse(dr("OrdenesProduccionEstados").ToString())
         End If
         If dt.Columns.Contains("OrdenesProduccionEstadosNoPendientes") AndAlso Not String.IsNullOrWhiteSpace(dr("OrdenesProduccionEstadosNoPendientes").ToString()) Then
            OrdenesProduccionEstadosNoPendientes = Integer.Parse(dr("OrdenesProduccionEstadosNoPendientes").ToString())
         End If

         'Si la cantidad de lineas en OrdenesProduccionProductos y la cantidad de lineas de OrdenesProduccionEstados significa que el OrdenProduccion ya se empezó a usar, entonces no permito modificar
         'En caso de que las cantidades de lineas coincidan me fijo también si hay alguna linea con estado distinto de PENDIENTE para estar seguro.
         If OrdenesProduccionProductos <> OrdenesProduccionEstados Or OrdenesProduccionEstadosNoPendientes <> 0 Then
            Throw New Exception(String.Format("El {0} {1} {2:0000}-{3:00000000} no se puede modificar.",
                                              OrdenProduccion.IdTipoComprobante, OrdenProduccion.LetraComprobante, OrdenProduccion.CentroEmisor, OrdenProduccion.NumeroOrdenProduccion))
         End If
      End If
   End Sub

   Public Function ExisteOrdenProduccion(IdCliente As Long, fechaPed As DateTime) As Boolean
      Return New SqlServer.OrdenesProduccion(da).ExisteOrdenProduccion(IdCliente, fechaPed)
   End Function

   Public Function ExisteOrdenProduccion(NumeroOrdenProduccion As Long) As Boolean
      Return New SqlServer.OrdenesProduccion(da).ExisteOrdenProduccion(NumeroOrdenProduccion)
   End Function

   Public Function ExisteOrdenProduccion(idTipoComprobante As String, numeroOrdenProduccion As Long) As Boolean
      Return New SqlServer.OrdenesProduccion(da).ExisteOrdenProduccion(idTipoComprobante, numeroOrdenProduccion)
   End Function

   Public Function ExisteOrdenProduccion(idTipoComprobante As String, idCliente As Long, ordenCompra As Long) As Boolean
      Return New SqlServer.OrdenesProduccion(da).ExisteOrdenProduccion(idTipoComprobante, idCliente, ordenCompra)
   End Function
#End Region

#Region "REPORTE"

   'Public Function GetOrdenesProduccionDetalladoXEstados(idSucursal As Integer, _
   '                                          IdEstado As String, _
   '                                          dtpDesde As Date, _
   '                                          dtpHasta As Date, _
   '                                          numeroOrdenProduccion As Long, _
   '                                          idProducto As String, _
   '                                          IdMarca As Integer, _
   '                                          IdRubro As Integer, _
   '                                          lote As String, _
   '                                          IdCliente As Long, _
   '                                          IdUsuario As String, _
   '                                          Tamanio As Decimal, _
   '                                          TipoDocVendedor As String, _
   '                                          NroDocVendedor As String, _
   '                                          OrdenCompra As Long) As DataTable


   '   Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)

   '   Return sql.GetOrdenesProduccionDetalladoXEstados(idSucursal, _
   '                                          IdEstado, _
   '                                          dtpDesde, dtpHasta, _
   '                                          numeroOrdenProduccion, _
   '                                          idProducto, _
   '                                          IdMarca, _
   '                                          IdRubro, _
   '                                          lote, _
   '                                          IdCliente, _
   '                                          IdUsuario, _
   '                                          Tamanio, _
   '                                          TipoDocVendedor, NroDocVendedor, _
   '                                          OrdenCompra)

   'End Function

   Public Function GetOrdenesProduccionDetalladoXEstadosTodos(idSucursal As Integer,
                                                              IdEstado As String,
                                                              FechaDesde As Date,
                                                              FechaHasta As Date,
                                                              numeroOrdenProduccion As Long,
                                                              idProducto As String,
                                                              IdMarca As Integer,
                                                              IdRubro As Integer,
                                                              lote As String,
                                                              IdCliente As Long,
                                                              IdUsuario As String,
                                                              Tamanio As Decimal,
                                                              IdVendedor As Integer,
                                                              OrdenCompra As Long,
                                                              idPlanMaestro As Integer,
                                                              fechaDesdePlan As Date?,
                                                              fechaHastaPlan As Date?) As DataTable

      Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)

      Return sql.GetOrdenesProduccionDetalladoXEstadosTodos(idSucursal,
                                                  IdEstado,
                                                  FechaDesde, FechaHasta,
                                                  numeroOrdenProduccion,
                                                  idProducto,
                                                  IdMarca,
                                                  IdRubro,
                                                  lote,
                                                  IdCliente,
                                                  IdUsuario,
                                                  Tamanio,
                                                  IdVendedor,
                                                  OrdenCompra,
                                                  idPlanMaestro,
                                                  fechaDesdePlan,
                                                  fechaHastaPlan)

   End Function

   Public Function GetOrdenesProduccionDetalleComprobante(idSucursal As Integer,
                                                IdEstado As String,
                                                FechaDesde As Date,
                                                FechaHasta As Date,
                                                numeroOrdenProduccion As Long,
                                                idProducto As String,
                                                IdMarca As Integer,
                                                IdRubro As Integer,
                                                lote As String,
                                                IdCliente As Long,
                                                IdUsuario As String,
                                                Tamanio As Decimal,
                                                IdVendedor As Integer,
                                                OrdenCompra As Long) As DataTable

      Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)

      Return sql.GetOrdenesProduccionDetalleComprobante(idSucursal,
                                              IdEstado,
                                              FechaDesde, FechaHasta,
                                              numeroOrdenProduccion,
                                              idProducto,
                                              IdMarca,
                                              IdRubro,
                                              lote,
                                              IdCliente,
                                              IdUsuario,
                                              Tamanio,
                                              IdVendedor,
                                              OrdenCompra)

   End Function

   Public Function GetOrdenesProduccionDetalleComprobante(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Short,
                                                numeroComprobante As Long) As DataTable

      Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)

      Return sql.GetOrdenesProduccionDetalleComprobante(idSucursal,
                                             idTipoComprobante,
                                             letra,
                                             centroEmisor,
                                             numeroComprobante)
   End Function
   Public Function GetOrdenesProduccionxComprobante(idSucursal As Integer,
                                               idTipoComprobante As String,
                                               letra As String,
                                               centroEmisor As Short,
                                               numeroComprobante As Long) As DataTable

      Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)

      Return sql.GetOrdenesProduccionxComprobante(idSucursal,
                                             idTipoComprobante,
                                             letra,
                                             centroEmisor,
                                             numeroComprobante)
   End Function

   Public Function GetOrdenesProduccionDetalleComprobante_estructura() As DataTable
      Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)

      Return sql.GetOrdenesProduccionDetalleComprobante_estructura()
   End Function

   Public Function OrdenesProduccionCabecera(idSucursal As Integer,
                                             IdEstado As String,
                                             dtpDesde As Date,
                                             dtpHasta As Date,
                                             numeroOrdenProduccion As Long,
                                             idProducto As String,
                                             IdMarca As Integer,
                                             IdRubro As Integer,
                                             lote As String,
                                             IdCliente As Long,
                                             IdUsuario As String,
                                             Tamanio As Decimal,
                                             IdVendedor As Integer,
                                             OrdenCompra As Long,
                                             idPlanMaestro As Integer,
                                             fechaDesdePlan As Date?,
                                             fechaHastaPlan As Date?) As DataTable


      Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)

      Return sql.OrdenesProduccionCabecera(idSucursal,
                                           IdEstado,
                                           dtpDesde, dtpHasta,
                                           numeroOrdenProduccion,
                                           IdCliente,
                                           IdUsuario,
                                           IdVendedor,
                                           OrdenCompra,
                                           idPlanMaestro,
                                           fechaDesdePlan,
                                           fechaHastaPlan)

   End Function

   Public Function GetOrdenesProduccionSumaPorProductos(idSucursal As Integer,
                                                IdEstado As String,
                                                dtpDesde As Date,
                                                dtpHasta As Date,
                                                IdCliente As Long,
                                                IdVendedor As Integer,
                                                IdMarca As Integer,
                                                IdRubro As Integer,
                                                IdSubRubro As Integer,
                                                IdProducto As String,
                                                Tamanio As Decimal,
                                                OrdenCompra As Long) As DataTable


      Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)

      Return sql.GetOrdenesProduccionSumaPorProductos(idSucursal,
                                             IdEstado,
                                             dtpDesde, dtpHasta,
                                             IdCliente,
                                             IdVendedor,
                                             IdMarca,
                                             IdRubro,
                                             IdSubRubro,
                                             IdProducto,
                                             Tamanio,
                                             OrdenCompra)

   End Function

   Public Function GetOrdenesProduccionDetalladoXEstados(idSucursal As Integer,
                                                 IdEstado As String,
                                                 dtpDesde As Date,
                                                 dtpHasta As Date,
                                                 dtpDesdeEntrega As Date?,
                                                 dtpHastaEntrega As Date?,
                                                 numeroPedido As Long,
                                                 idProducto As String,
                                                 IdMarca As Integer,
                                                 IdRubro As Integer,
                                                 lote As String,
                                                 IdCliente As Long,
                                                 IdUsuario As String,
                                                 Tamanio As Decimal,
                                                 IdVendedor As Integer,
                                                 OrdenCompra As Long,
                                                 tipoTipoComprobante As String,
                                                 tiposComprobante As Entidades.TipoComprobante(),
                                                 espPulgadas As String,
                                                 espmm As Decimal?,
                                                 sae As Integer?,
                                                 idProceso As Integer,
                                                 Idproveedor As Long) As DataTable

      Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)

      Return sql.GetOrdenesProduccionDetalladoXEstados(idSucursal,
                                             IdEstado,
                                             dtpDesde, dtpHasta,
                                             dtpDesdeEntrega, dtpHastaEntrega,
                                             numeroPedido,
                                             idProducto,
                                             IdMarca,
                                             IdRubro,
                                             lote,
                                             IdCliente,
                                             IdUsuario,
                                             Tamanio,
                                             IdVendedor,
                                             OrdenCompra,
                                             tipoTipoComprobante,
                                             tiposComprobante,
                                             espPulgadas,
                                             espmm,
                                             sae,
                                             idProceso,
                                             Idproveedor)

   End Function
#End Region

#Region "CrearComprobanteAutomatico"
   'Public Overridable Function ConvertirFormulaPedidoEnOP(ppf As List(Of Entidades.PedidoProductoFormula)) As List(Of Entidades.OrdenProduccionProductoFormula)
   '   Return ppf.ConvertAll(Function(f) ConvertirFormulaPedidoEnOP(f))
   'End Function
   'Public Overridable Function ConvertirFormulaPedidoEnOP(ppf As Entidades.PedidoProductoFormula) As Entidades.OrdenProduccionProductoFormula
   '   Dim ser = New JavaScriptSerializer()
   '   Dim oppf = ser.Deserialize(Of Entidades.OrdenProduccionProductoFormula)(ser.Serialize(ppf))
   '   oppf.NumeroOrdenProduccion = ppf.NumeroPedido
   '   Return oppf
   'End Function
   Public Overridable Function AgregarFormula(opProducto As Entidades.OrdenProduccionProducto, oppFormula As Entidades.OrdenProduccionProductoFormula) As List(Of Entidades.OrdenProduccionProductoFormula)
      opProducto.OrdenesProduccionProductosFormulas.Add(oppFormula)
      Return opProducto.OrdenesProduccionProductosFormulas
   End Function
   Public Overridable Function AgregarFormula(opProducto As Entidades.OrdenProduccionProducto, oppFormula As List(Of Entidades.OrdenProduccionProductoFormula)) As List(Of Entidades.OrdenProduccionProductoFormula)
      oppFormula.ForEach(Function(oppf) AgregarFormula(opProducto, oppf))
      Return opProducto.OrdenesProduccionProductosFormulas
   End Function
   Public Overridable Function CrearOrdenProduccionProducto(producto As Entidades.Producto,
                                                            productoDescripcion As String,
                                                            descuentoRecargoPorc1 As Decimal,
                                                            descuentoRecargoPorc2 As Decimal,
                                                            precio As Decimal,
                                                            cantidad As Decimal,
                                                            tipoImpuesto As Entidades.TipoImpuesto,
                                                            porcentajeIva As Decimal?,
                                                            idListaDePrecios As Integer,
                                                            IdCriticidad As String,
                                                            fechaEntrega As Date?,
                                                            OrdenProduccion As Entidades.OrdenProduccion,
                                                            redondeoEnCalculo As Integer,
                                                            espmm As Decimal,
                                                            espPulgadas As String,
                                                            codigoSAE As String,
                                                            produccionProceso As Entidades.ProduccionProceso,
                                                            produccionForma As Entidades.ProduccionForma,
                                                            largoExtAlto As Decimal,
                                                            anchoIntBase As Decimal,
                                                            architrave As Decimal,
                                                            modelo As Entidades.ProduccionModeloForma,
                                                            urlPlano As String,
                                                            idFormula As Integer,
                                                            idResponsable As Integer,
                                                            idProcesoProductivo As Long,
                                                            idSucursalPedido As Integer,
                                                            idTipoComprobantePedido As String,
                                                            letraPedido As String,
                                                            centroEmisorPedido As Integer,
                                                            numeroPedido As Integer,
                                                            idProductoPedido As String,
                                                            ordenPedido As Integer) As Entidades.OrdenProduccionProducto

      Dim listaDePrecios As Eniac.Entidades.ListaDePrecios = New Reglas.ListasDePrecios(da).GetUno(idListaDePrecios)

      Dim oOrdenProduccionProducto As Eniac.Entidades.OrdenProduccionProducto = New Eniac.Entidades.OrdenProduccionProducto()
      Dim proSuc As Eniac.Entidades.ProductoSucursal
      proSuc = New Eniac.Reglas.ProductosSucursales(da).GetUno(actual.Sucursal.IdSucursal,
                                                               producto.IdProducto,
                                                               listaDePrecios.IdListaPrecios)

      Dim kilos As Decimal = 0
      If producto.UnidadDeMedida IsNot Nothing Then
         kilos = Decimal.Round(cantidad * producto.Tamano, 3)
      End If

      If Not porcentajeIva.HasValue Then
         porcentajeIva = producto.Alicuota
      End If

      Dim precioProducto As Decimal
      If Not OrdenProduccion.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         If OrdenProduccion.TipoComprobante.GrabaLibro Or OrdenProduccion.TipoComprobante.EsPreElectronico Then
            precioProducto = precio - producto.ImporteImpuestoInterno
         Else
            precioProducto = precio
         End If
      Else
         precioProducto = precio
      End If
      Dim impuestoInterno As Decimal = producto.ImporteImpuestoInterno * cantidad

      Dim descRec1 As Decimal = Decimal.Round(precioProducto * descuentoRecargoPorc1 / 100, redondeoEnCalculo)
      Dim descRec2 As Decimal = Decimal.Round((precioProducto + descRec1) * descuentoRecargoPorc2 / 100, redondeoEnCalculo)
      Dim descRecG As Decimal = Decimal.Round((precioProducto + descRec1 + descRec2) * OrdenProduccion.DescuentoRecargoPorc / 100, redondeoEnCalculo)

      Dim precioNeto As Decimal = precio + descRec1 + descRec2 + descRecG
      Dim importeIVA As Decimal

      If Not OrdenProduccion.Cliente.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
         importeIVA = Decimal.Round(((precioNeto * cantidad) - impuestoInterno) - ((precioNeto * cantidad) - impuestoInterno) / (1 + porcentajeIva.Value / 100), redondeoEnCalculo)
      Else
         importeIVA = Decimal.Round((precioNeto * cantidad) * porcentajeIva.Value / 100, redondeoEnCalculo)
      End If

      With oOrdenProduccionProducto
         .IdSucursal = actual.Sucursal.Id
         .Usuario = actual.Nombre
         .Producto = producto
         If producto.PermiteModificarDescripcion Then
            .Producto.NombreProducto = productoDescripcion   'Piso la descripcion si tiene habilitado la posibilidad de cambiarlas.
         End If
         .DescuentoRecargoPorc = descuentoRecargoPorc1
         .DescuentoRecargoPorc2 = descuentoRecargoPorc2
         ''.DescuentoRecargo = descuentoRecargo
         .Precio = precio
         .Cantidad = cantidad
         .ImporteTotal = (precio + descRec1 + descRec2) * cantidad
         .ImporteImpuesto = importeIVA
         .AlicuotaImpuesto = porcentajeIva.Value
         .TipoImpuesto = tipoImpuesto

         .Stock = proSuc.Stock
         .Costo = proSuc.PrecioCosto
         .PrecioLista = proSuc.GetPrecioVentaDeLista(Publicos.ListaPreciosPredeterminada)
         .Kilos = kilos
         .PrecioNeto = precioNeto
         .ImporteTotalNeto = .PrecioNeto * cantidad
         .IdCriticidad = IdCriticidad
         If fechaEntrega.HasValue Then
            .FechaEntrega = fechaEntrega.Value
         End If
         .IdListaPrecios = listaDePrecios.IdListaPrecios
         .NombreListaPrecios = listaDePrecios.NombreListaPrecios
         .FechaActualizacion = Now
         .ImporteImpuestoInterno = producto.ImporteImpuestoInterno * cantidad

         .Espmm = espmm
         .EspPies = espPulgadas
         .CodigoSAE = codigoSAE
         If produccionProceso IsNot Nothing Then
            .IdProduccionProceso = produccionProceso.IdProduccionProceso
         End If
         If produccionForma IsNot Nothing Then
            .IdProduccionForma = produccionForma.IdProduccionForma
         End If
         .LargoExtAlto = largoExtAlto
         .AnchoIntBase = anchoIntBase
         .Architrave = architrave
         .ProduccionModeloForma = modelo
         .UrlPlano = urlPlano
         .IdFormula = idFormula

         .IdProcesoProductivo = idProcesoProductivo
         '-- REQ-41642.- -------------------------------------------------------------
         .IdSucursalPedido = idSucursalPedido
         .IdTipoComprobantePedido = idTipoComprobantePedido
         .LetraPedido = letraPedido
         .CentroEmisorPedido = centroEmisorPedido
         .NumeroPedido = numeroPedido
         .IdProductoPedido = idProductoPedido
         .OrdenPedido = ordenPedido
         '----------------------------------------------------------------------------
         .IdResponsable = idResponsable
         If idProcesoProductivo > 0 Then
            .OrdenesProduccionMRP = New Reglas.OrdenesProduccionMRP(da).CargaOrdenProduccionMRP(producto.IdProducto, idProcesoProductivo, cantidad)
         End If
      End With

      Return oOrdenProduccionProducto
   End Function

   Public Overridable Sub AgregarLinea(OrdenProduccion As Eniac.Entidades.OrdenProduccion, OrdenProduccionProducto As Eniac.Entidades.OrdenProduccionProducto)
      Dim bruto As Decimal = 0
      Dim neto As Decimal = 0
      Dim iva As Decimal = 0
      Dim impint As Decimal = 0
      Dim total As Decimal = 0

      'Si el Estado de Visita no adminte lineas, no puedo agregar lineas al OrdenProduccion.
      If Not OrdenProduccion.EstadoVisita.AdmintePedidoConLineas Then
         Throw New Exception(String.Format("El estado de visita '{0}' del '{1} {2} {3:0000}-{4:00000000} no adminte lineas. Verifique el estado de visita indicado en el OrdenProduccion.'",
                                           OrdenProduccion.NombreEstadoVisita, OrdenProduccion.IdTipoComprobante, OrdenProduccion.LetraComprobante, OrdenProduccion.CentroEmisor, OrdenProduccion.NumeroOrdenProduccion))
      End If

      OrdenProduccionProducto.Orden = OrdenProduccion.OrdenesProduccionProductos.Count

      OrdenProduccion.OrdenesProduccionProductos.Add(OrdenProduccionProducto)

      For Each vp As Eniac.Entidades.OrdenProduccionProducto In OrdenProduccion.OrdenesProduccionProductos
         If Not OrdenProduccion.Cliente.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            bruto += Math.Round((vp.ImporteTotal / ((100 + vp.AlicuotaImpuesto) / 100)), 2)
            neto += Math.Round((vp.ImporteTotalNeto / ((100 + vp.AlicuotaImpuesto) / 100)), 2)
            iva += vp.ImporteImpuesto
            impint += vp.ImporteImpuestoInterno

            total += vp.ImporteTotalNeto
         Else
            bruto += vp.ImporteTotal
            neto += vp.ImporteTotalNeto
            iva += vp.ImporteImpuesto
            impint += vp.ImporteImpuestoInterno

            total += vp.ImporteTotalNeto + vp.ImporteImpuesto + vp.ImporteImpuestoInterno
         End If

      Next

      OrdenProduccion.ImporteBruto = bruto
      OrdenProduccion.DescuentoRecargo = neto - bruto
      OrdenProduccion.SubTotal = neto
      OrdenProduccion.TotalImpuestos = iva
      OrdenProduccion.TotalImpuestoInterno = impint
      OrdenProduccion.ImporteTotal = total
   End Sub

   Public Overridable Function CrearOrdenProduccion(tipoComprobante As Eniac.Entidades.TipoComprobante,
                               cliente As Eniac.Entidades.Cliente,
                               letra As String,
                               centroEmisor As Short?,
                               numeroComprobante As Long?,
                               fecha As DateTime,
                               vendedor As Eniac.Entidades.Empleado,
                               transportista As Eniac.Entidades.Transportista,
                               formaPago As Eniac.Entidades.VentaFormaPago,
                               tipoComprobanteFact As Eniac.Entidades.TipoComprobante,
                               observaciones As String,
                               estadoVisita As Eniac.Entidades.EstadoVisita,
                               ordenCompra As Long) As Eniac.Entidades.OrdenProduccion
      Dim blnAbreConeccion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      If blnAbreConeccion Then da.OpenConection()

      Try
         Dim oOrdenProduccion As Eniac.Entidades.OrdenProduccion = New Eniac.Entidades.OrdenProduccion()

         With oOrdenProduccion
            'cargo el comprobante
            .TipoComprobante = tipoComprobante

            'cargo el cliente
            .Cliente = cliente
            'cargo la Categoria Fiscal
            .CategoriaFiscal = cliente.CategoriaFiscal

            .Impresora = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)

            If tipoComprobante.LetrasHabilitadas.Length = 1 Then
               .LetraComprobante = tipoComprobante.LetrasHabilitadas
            Else
               .LetraComprobante = .CategoriaFiscal.LetraFiscal
            End If

            If numeroComprobante.HasValue Then
               .NumeroOrdenProduccion = numeroComprobante.Value
            End If

            'cargo datos generales del comprobante
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre

            'Pudo levantar la pantalla y grabar despues. Vuelvo a asignarlo para que tome la hora.
            If fecha.Date = New Eniac.Reglas.Generales().GetServerDBFechaHora.Date Then
               fecha = New Eniac.Reglas.Generales().GetServerDBFechaHora
            End If
            .Fecha = fecha

            .NumeroOrdenCompra = ordenCompra

            .Vendedor = vendedor

            .EstadoVisita = estadoVisita

            .Transportista = transportista
            .FormaPago = formaPago
            .TipoComprobanteFact = tipoComprobanteFact

            .Observacion = observaciones

            .CotizacionDolar = New Eniac.Reglas.Monedas(da).GetUna(Entidades.Moneda.Dolar).FactorConversion
            .DescuentoRecargoPorc = New CalculosDescuentosRecargos(_cache).DescuentoRecargo(.Cliente, .TipoComprobante.GrabaLibro, .TipoComprobante.EsPreElectronico, .FormaPago, cantidadLineasVenta:=0)   'NO APLICA EL CALCULO DE % GRAL EN PRODUCCION
         End With

         Return oOrdenProduccion
      Finally
         If blnAbreConeccion Then da.CloseConection()
      End Try
   End Function
#End Region

   Public Function Dividir(origen As Eniac.Entidades.OrdenProduccion, destinos As List(Of Eniac.Entidades.OrdenProduccion)) As List(Of Eniac.Entidades.OrdenProduccion)
      Dim result As List(Of Eniac.Entidades.OrdenProduccion) = New List(Of Eniac.Entidades.OrdenProduccion)()
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      If blnAbreConexion Then da.OpenConection()
      Try
         If blnAbreConexion Then da.BeginTransaction()

         Dim regla As Eniac.Reglas.OrdenesProduccion = New Eniac.Reglas.OrdenesProduccion(da)
         Dim sql As SqlServer.OrdenesProduccion = New SqlServer.OrdenesProduccion(da)
         Dim sqlVP As Eniac.SqlServer.VentasProductos = New Eniac.SqlServer.VentasProductos(da)

         Borra(origen, False)
         'result.Add(Actualiza(origen))

         For Each destino As Eniac.Entidades.OrdenProduccion In destinos
            result.Add(Inserta(destino))
         Next

         If blnAbreConexion Then da.CommitTransaction()

      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return result
   End Function

   Public Function ConvertirOrdenProduccionEnVenta(OrdenProduccion As Entidades.OrdenProduccion, idCaja As Integer, reparto As Integer) As Entidades.Venta
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim redondeoEnCalculo As Integer = Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
         Dim rVenta As Ventas = New Ventas(da)

         Dim fechaEnvio As Date = Today
         If OrdenProduccion IsNot Nothing AndAlso OrdenProduccion.OrdenesProduccionProductos IsNot Nothing AndAlso OrdenProduccion.OrdenesProduccionProductos.Count > 0 Then
            fechaEnvio = OrdenProduccion.OrdenesProduccionProductos(0).FechaEntrega
         End If

         Dim venta = rVenta.CreaVenta(actual.Sucursal.Id, OrdenProduccion.TipoComprobanteFact, "", 0,
                                      Nothing,
                                      OrdenProduccion.Cliente,
                                      Nothing,
                                      Now,
                                      OrdenProduccion.Vendedor,
                                      OrdenProduccion.Transportista,
                                      OrdenProduccion.FormaPago,
                                      Nothing,
                                      idCaja,
                                      OrdenProduccion.CotizacionDolar,
                                      True,
                                      reparto,
                                      fechaEnvio,
                                      Nothing,
                                      OrdenProduccion.Observacion,
                                      cobrador:=Nothing,
                                      clienteVinculado:=Nothing,
                                      nroOrdenCompra:=0)



         For Each vp In OrdenProduccion.OrdenesProduccionProductos
            If vp.CantPendiente <> 0 Then
               rVenta.AgregarVentaProducto(venta,
                                    rVenta.CreaVentaProducto(vp.Producto, vp.Producto.NombreProducto,
                                                      vp.DescuentoRecargoPorc, vp.DescuentoRecargoPorc2,
                                                      Nothing, vp.CantPendiente,
                                                      vp.TipoImpuesto, vp.AlicuotaImpuesto,
                                                      _cache.BuscaListaDePrecios(vp.IdListaPrecios), vp.FechaEntrega,
                                                      Entidades.Producto.TiposOperaciones.NORMAL, String.Empty, Nothing,
                                                      venta, redondeoEnCalculo),
                                    redondeoEnCalculo)
               'Cargo los Comprobantes Facturados (tal vez ninguno)
            End If
         Next

         '    rVenta.AgregarFacturable(venta, OrdenProduccion)

         Return venta
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Function

   Public Sub GrabaOrdenProduccionNecesidad(nPlanMaestro As Integer, lNecesidades As List(Of Entidades.MRPProductosNecesarios), lOrdenProduc As DataTable, idFuncion As String)

      EjecutaConTransaccion(
      Sub()
         '-- Recupera Estado Final de la OP.- --------------
         Dim estadoNuevo As String = Reglas.Publicos.EstadoOrdenProduccionPlanificacion
         '-- Graba las Ordenes de Produccion de Necesarios.-
         Dim lOrdProd As List(Of Entidades.OrdenProduccion) = GrabaOrdenesProduccionNecesidad(lNecesidades, lOrdenProduc)
         '--------------------------------------------------
         Dim rOP = New OrdenesProduccion(da)
         Dim rOPE = New OrdenesProduccionEstados(da)
         '-- Actualiza Estado Padres.-
         For Each dr As DataRow In lOrdenProduc.Rows
            Dim lst = rOPE.GetParaAdmin(dr.Field(Of Integer)("IdSucursal"), dr.Field(Of String)("IdTipoComprobante"), dr.Field(Of String)("Letra"), dr.Field(Of Integer)("CentroEmisor"), dr.Field(Of Integer)("NumeroOrdenProduccion"),
                                        dr.Field(Of Integer)("Orden"), dr.Field(Of String)("IdProducto"), dr.Field(Of DateTime)("FechaEstado"))
            Dim cambio = New Entidades.OrdenesProduccionAdminCambioEstado(_cache.BuscaEstadosOrdenesProduccion(estadoNuevo))
            cambio.Pedidos = lst.ConvertAll(Function(op) op.SetPlanMaestro(nPlanMaestro, Now))    '-- Adjunta plan Maestro Numero.--
            rOPE._ActualizarEstadoOrdenProduccionMasivo(cambio, idFuncion)
         Next

         For Each ordProd In lOrdProd
            For Each eOrdNec In ordProd.OrdenesProduccionProductos
               Dim lst = rOPE.GetParaAdmin(eOrdNec.IdSucursal, eOrdNec.IdTipoComprobante, eOrdNec.Letra, eOrdNec.CentroEmisor, eOrdNec.NumeroOrdenProduccion,
                                           eOrdNec.Orden, eOrdNec.IdProducto, Nothing)
               Dim cambio = New Entidades.OrdenesProduccionAdminCambioEstado(_cache.BuscaEstadosOrdenesProduccion(estadoNuevo))
               cambio.Pedidos = lst.ConvertAll(Function(op) op.SetPlanMaestro(nPlanMaestro, Now))    '-- Adjunta plan Maestro Numero.--
               rOPE._ActualizarEstadoOrdenProduccionMasivo(cambio, idFuncion)
            Next
         Next

         '-- Vincula Padres con Hijos.-
         Dim rOrdenProdPro = New Reglas.OrdenesProduccionMRPProductos(da)
         For Each eNecesidad In lNecesidades
            If eNecesidad.nodoPadre = 0 Then
               If eNecesidad.IdSucursalNodo <> 0 Then
                  '-- vincula con Padre General.- 
                  rOrdenProdPro.VinculaOrdenProduccion(eNecesidad.IdSucursal,
                                                    eNecesidad.IdTipoComprobante,
                                                    eNecesidad.LetraComprobante,
                                                    eNecesidad.CentroEmisor,
                                                    eNecesidad.NumeroOrdenProduccion,
                                                    eNecesidad.Orden,
                                                    esNecesario:=True,
                                                    eNecesidad.IdProductoProceso,
                                                    eNecesidad.IdSucursalNodo,
                                                    eNecesidad.IdTipoComprobanteNodo,
                                                    eNecesidad.LetraNodo,
                                                    eNecesidad.CentroEmisorNodo,
                                                    eNecesidad.NumeroOrdenProduccionNodo,
                                                    eNecesidad.OrdenNodo)
               End If
               rOrdenProdPro.ActualizarEstadoOrdenProdMRPPro(eNecesidad.IdSucursal,
                                                             eNecesidad.IdTipoComprobante,
                                                             eNecesidad.LetraComprobante,
                                                             eNecesidad.CentroEmisor,
                                                             eNecesidad.NumeroOrdenProduccion,
                                                             eNecesidad.Orden,
                                                             esNecesario:=True,
                                                             eNecesidad.IdProductoProceso,
                                                             If(eNecesidad.CantidadFabricar > 0, "ORDENPRODUCCION", "CUBIERTOSTOCK"))
            Else
               For Each ePadre In lNecesidades.Where(Function(x) x.nodo = eNecesidad.nodoPadre).ToList()
                  If eNecesidad.IdSucursalNodo <> 0 Then
                     rOrdenProdPro.VinculaOrdenProduccion(ePadre.IdSucursalNodo,
                                                       ePadre.IdTipoComprobanteNodo,
                                                       ePadre.LetraNodo,
                                                       ePadre.CentroEmisorNodo,
                                                       ePadre.NumeroOrdenProduccionNodo,
                                                       ePadre.OrdenNodo,
                                                       esNecesario:=True,
                                                       eNecesidad.IdProductoProceso,
                                                       eNecesidad.IdSucursalNodo,
                                                       eNecesidad.IdTipoComprobanteNodo,
                                                       eNecesidad.LetraNodo,
                                                       eNecesidad.CentroEmisorNodo,
                                                       eNecesidad.NumeroOrdenProduccionNodo,
                                                       eNecesidad.OrdenNodo)
                  End If
               Next
            End If
            For Each ePadre In lNecesidades.Where(Function(x) x.nodo = eNecesidad.nodoPadre).ToList()
               rOrdenProdPro.ActualizarEstadoOrdenProdMRPPro(ePadre.IdSucursalNodo,
                                                             ePadre.IdTipoComprobanteNodo,
                                                             ePadre.LetraNodo,
                                                             ePadre.CentroEmisor,
                                                             ePadre.NumeroOrdenProduccionNodo,
                                                             ePadre.OrdenNodo,
                                                             esNecesario:=True,
                                                             eNecesidad.IdProductoProceso,
                                                             If(eNecesidad.CantidadFabricar > 0, "ORDENPRODUCCION", "CUBIERTOSTOCK"))
            Next
         Next

      End Sub)
   End Sub

   Public Sub GrabaOrdenProduccionNecesidadRQ(lNecesidades As List(Of Entidades.MRPProductosNecesarios), lOrdenProduc As DataTable, idFuncion As String)

      EjecutaConTransaccion(
      Sub()
         '-- Define nuevo Estado.
         Dim estadoNuevo As String = Reglas.Publicos.EstadoOrdenProduccionPlanificacionRQ

         Dim rOP = New OrdenesProduccion(da)
         Dim rOPE = New OrdenesProduccionEstados(da)

         '-- Graba Requerimientos de Compras.-
         Dim lReqProd As Entidades.RequerimientoCompra = GrabaRequerimientoNecesidad(lNecesidades.Where(Function(x) x.CantidadFabricar > 0).ToList())
         '-- Actualiza Estado de las Ordenes.-
         Dim rOrdenProdPro = New Reglas.OrdenesProduccionMRPProductos(da)
         '-- Actualiza Estado Padres.-
         For Each dr As DataRow In lOrdenProduc.Rows
            Dim lst = rOPE.GetParaAdmin(dr.Field(Of Integer)("IdSucursal"),
                                        dr.Field(Of String)("IdTipoComprobante"),
                                        dr.Field(Of String)("Letra"),
                                        dr.Field(Of Integer)("CentroEmisor"),
                                        dr.Field(Of Integer)("NumeroOrdenProduccion"),
                                        dr.Field(Of Integer)("Orden"),
                                        dr.Field(Of String)("IdProducto"),
                                        dr.Field(Of DateTime)("FechaEstado"))
            Dim cambio = New Entidades.OrdenesProduccionAdminCambioEstado(_cache.BuscaEstadosOrdenesProduccion(estadoNuevo))
            cambio.Pedidos = lst.ConvertAll(Function(op) DirectCast(op, Entidades.AdminCambioEstadoDetalle(Of Entidades.EstadoOrdenProduccion)))
            '-- Adjunta plan Maestro Numero.- ------------------
            rOPE._ActualizarEstadoOrdenProduccionMasivo(cambio, idFuncion)
         Next

         For Each eOrdNec In lNecesidades
            rOrdenProdPro.ActualizarEstadoOrdenProdMRPPro(eOrdNec.IdSucursal,
                                                          eOrdNec.IdTipoComprobante,
                                                          eOrdNec.LetraComprobante,
                                                          eOrdNec.CentroEmisor,
                                                          eOrdNec.NumeroOrdenProduccion,
                                                          eOrdNec.Orden,
                                                          esNecesario:=True,
                                                          eOrdNec.IdProductoProceso, If(eOrdNec.CantidadFabricar > 0, "REQUERIDO", "CUBIERTOSTOCK"))
            If eOrdNec.CantidadFabricar > 0 Then
               rOrdenProdPro.VinculaRequerimientosCompra(eOrdNec.IdSucursal,
                                                         eOrdNec.IdTipoComprobante,
                                                         eOrdNec.LetraComprobante,
                                                         eOrdNec.CentroEmisor,
                                                         eOrdNec.NumeroOrdenProduccion,
                                                         eOrdNec.Orden,
                                                         1,
                                                         eOrdNec.IdProductoProceso,
                                                         lReqProd.IdRequerimientoCompra,
                                                         lReqProd.Productos.Where(Function(x) x.IdProducto = eOrdNec.IdProductoProceso And x.IdRequerimientoCompra = lReqProd.IdRequerimientoCompra).First().Orden)
            End If
         Next

      End Sub)
   End Sub
   Public Function GrabaOrdenesProduccionNecesidad(lNecesidades As List(Of Entidades.MRPProductosNecesarios), ordenPadre As DataTable) As List(Of Entidades.OrdenProduccion)

      Dim lOrdProd = New List(Of Entidades.OrdenProduccion)
      Dim rOrdProd = New OrdenesProduccion(da)
      Dim eOrdProd As Entidades.OrdenProduccion
      Dim oProducto As Entidades.Producto
      Dim tipoImpuesto As Entidades.TipoImpuesto = New TiposImpuestos(da).GetUno(Entidades.TipoImpuesto.Tipos.IVA)

      Dim rOPE = New OrdenesProduccionEstados(da)

      Dim tipoComprobante = _cache.BuscaTipoComprobante(Reglas.Publicos.TipoComprobanteOrdenProduccionPlanificacion)

      '-- Inserta.-
      For Each oNs As Entidades.MRPProductosNecesarios In lNecesidades.Where(Function(x) x.CantidadFabricar > 0)
         eOrdProd = rOrdProd.CrearOrdenProduccion(tipoComprobante,
                                                  oNs.Cliente,
                                                  String.Empty, Nothing,
                                                  Nothing,
                                                  Today,
                                                  oNs.Cliente.Vendedor,
                                                  oNs.Transportista,
                                                  oNs.FormaPago,
                                                  oNs.TipoComprobanteFact,
                                                  String.Empty,
                                                  oNs.EstadoVisita,
                                                  0)

         oProducto = New Reglas.Productos(da).GetUno(oNs.IdProductoProceso)
         Dim ordProdProd As Entidades.OrdenProduccionProducto
         '-- REQ-41643.- -------------------------------------------------
         ordProdProd = rOrdProd.CrearOrdenProduccionProducto(oProducto,
                                                             oProducto.NombreProducto,
                                                             descuentoRecargoPorc1:=0, descuentoRecargoPorc2:=0,
                                                             precio:=0,
                                                             oNs.CantidadFabricar,
                                                             tipoImpuesto,
                                                             oProducto.Alicuota,
                                                             Publicos.ListaPreciosPredeterminada,
                                                             "Normal",
                                                             oNs.FechaEntrega,
                                                             eOrdProd,
                                                             redondeoEnCalculo:=2, espmm:=0, espPulgadas:=String.Empty, codigoSAE:=String.Empty, produccionProceso:=Nothing, produccionForma:=Nothing, largoExtAlto:=0, anchoIntBase:=0, architrave:=0,
                                                             modelo:=Nothing, urlPlano:=String.Empty, idFormula:=Nothing, idResponsable:=1, idProcesoProductivo:=oNs.IdProcesoProductivo,
                                                             ordenPadre.Rows(0).Field(Of Integer?)("IdSucursalPedido").IfNull(),
                                                             ordenPadre.Rows(0).Field(Of String)("IdTipoComprobantePedido"),
                                                             ordenPadre.Rows(0).Field(Of String)("LetraPedido"),
                                                             ordenPadre.Rows(0).Field(Of Integer?)("CentroEmisorPedido").IfNull(),
                                                             ordenPadre.Rows(0).Field(Of Integer?)("NumeroPedido").IfNull(),
                                                             ordenPadre.Rows(0).Field(Of String)("IdProductoPedido"),
                                                             ordenPadre.Rows(0).Field(Of Integer?)("OrdenPedido").IfNull())
         '-----------------------------------------------------------------
         rOrdProd.AgregarLinea(eOrdProd, ordProdProd)
         lOrdProd.Add(rOrdProd.Inserta(eOrdProd))

         With oNs
            .IdSucursalNodo = ordProdProd.IdSucursal
            .IdTipoComprobanteNodo = ordProdProd.IdTipoComprobante
            .LetraNodo = ordProdProd.Letra
            .CentroEmisorNodo = ordProdProd.CentroEmisor
            .NumeroOrdenProduccionNodo = ordProdProd.NumeroOrdenProduccion
            .OrdenNodo = ordProdProd.Orden
         End With
      Next
      Return lOrdProd
   End Function

   Public Function GrabaRequerimientoNecesidad(lNecesidades As List(Of Entidades.MRPProductosNecesarios)) As Entidades.RequerimientoCompra
      Dim Requerimiento = New Entidades.RequerimientoCompra()

      Requerimiento.IdTipoComprobante = Reglas.Publicos.TipoComprobanteOrdenProduccionRequerimiento
      Requerimiento.Observacion = "Generado desde Planificación de Producción.-"
      Dim oOrden As Integer = 1


      Dim leOrdNec = From row In lNecesidades
                     Group row By dateGroup = New With {
                                                         Key .IdSucursal = row.IdSucursal,
                                                         Key .IdTipoComprobante = row.IdTipoComprobante,
                                                         Key .LetraComprobante = row.LetraComprobante,
                                                         Key .CentroEmisor = row.CentroEmisor,
                                                         Key .IdProductoProceso = row.IdProductoProceso,
                                                         Key .NombreProductoProceso = row.NombreProductoProceso,
                                                         Key .FechaEntrega = row.FechaEntrega,
                                                         Key .Orden = row.Orden,
                                                         Key .FactorConversionCompra = row.FactorConversionCompra
                                                      } Into Group
                     Select New With {
                               Key .IdProductoProceso = dateGroup.IdProductoProceso,
                                   .NombreProductoProceso = dateGroup.NombreProductoProceso,
                                   .FechaEntrega = dateGroup.FechaEntrega,
                                   .IdSucursal = dateGroup.IdSucursal,
                                   .IdTipoComprobante = dateGroup.IdTipoComprobante,
                                   .LetraComprobante = dateGroup.LetraComprobante,
                                   .CentroEmisor = dateGroup.CentroEmisor,
                                   .Orden = dateGroup.Orden,
                                   .FactorConversionCompra = dateGroup.FactorConversionCompra,
                                   .NumeroOperacion = Group.Max(Function(x) x.NumeroOrdenProduccion),
                                   .SumaFabricar = Group.Sum(Function(x) x.CantidadFabricar)}


      For Each eOrdNec In leOrdNec
         Dim rqProd = New Entidades.RequerimientoCompraProducto()

         rqProd.IdProducto = eOrdNec.IdProductoProceso
         rqProd.NombreProducto = eOrdNec.NombreProductoProceso
         rqProd.Orden = oOrden
         eOrdNec.Orden = oOrden
         rqProd.Cantidad = eOrdNec.SumaFabricar
         rqProd.FactorConversionCompra = eOrdNec.FactorConversionCompra
         rqProd.CantidadUMCompra = rqProd.Cantidad * rqProd.FactorConversionCompra
         'rqProd.Kilos = eOrdNec
         rqProd.FechaEntrega = eOrdNec.FechaEntrega
         rqProd.Observacion = String.Format("{0}-{1}-{2}-{3}", eOrdNec.IdTipoComprobante, eOrdNec.LetraComprobante, eOrdNec.CentroEmisor, eOrdNec.NumeroOperacion)

         Requerimiento.Productos.Add(rqProd)
         oOrden += 1
      Next
      '-- Inserta Requerimiento.-
      Dim rRequerProd = New Reglas.RequerimientosCompras(da)
      rRequerProd._Insertar(Requerimiento)

      Return Requerimiento
   End Function
End Class
