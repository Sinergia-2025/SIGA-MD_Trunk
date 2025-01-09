Imports System.Windows.Forms
Imports Eniac.Entidades
Imports Eniac.Entidades.Entidad

Public Class ImportarWebSiExport
   Inherits Eniac.Reglas.Base

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = ""
      da = accesoDatos
   End Sub

   Public Enum Cartuchos
      TODOS
      Clientes
      Ventas
   End Enum
   Private Enum Tablas
      WClientes
      WVentas
      WVentasProductos
   End Enum

   Public Enum ColumnasWClientes
      IdEmpresa
      IdSucursal
      IdEjecucion
      EstadoEjec
      CodigoCliente
      NombreCliente
      Contacto
      Direccion
      Telefono
      CorreoElectronico
      IdCategoriaFiscal_Origen
      IdCategoriaFiscal
      Cuit_Origen
      Cuit
      FechaNacimiento
      Observacion
      Activo
      IdLocalidad_Origen
      IdLocalidad
      IdZonaGeografica
      FechaAlta
      IdCategoria
      IdListaPrecios
      LimiteDeCredito
      IdCliente
      IdCobrador
      IdTipoCliente
      FechaBaja
      Sexo
      IdEstadoCliente
      IdVendedor
      IdDadoAltaPor
      CodigoClienteLetras
      IdCalle
      IdCalle2
      MonedaCredito
   End Enum

   Public Enum ColumnasWVentas
      IdEmpresa
      IdSucursal
      IdEjecucion
      EstadoEjec
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      Fecha
      SubTotal
      DescuentoRecargo
      ImporteTotal
      IdCategoriaFiscal
      IdFormasPago
      Observacion
      ImporteBruto
      DescuentoRecargoPorc
      IdEstadoComprobante
      IdTipoComprobanteFact_Viejo
      LetraFact_Viejo
      CentroEmisorFact_Viejo
      NumeroComprobanteFact_Viejo
      IdCaja
      NumeroPlanilla
      NumeroMovimiento
      ImportePesos
      ImporteTickets
      ImporteTarjetas
      ImporteCheques
      Kilos
      Bultos
      ValorDeclarado
      IdTransportista
      NumeroLote
      TotalImpuestos
      CantidadInvocados
      CantidadLotes
      Usuario
      FechaAlta
      CAE
      CAEVencimiento
      Utilidad
      FechaTransmisionAFIP
      CotizacionDolar
      ComisionVendedor
      FechaImpresion
      IdAsiento
      MercDespachada
      ImporteTransfBancaria
      IdCuentaBancaria
      IdActividad
      IdProvincia
      FechaEnvio
      NumeroReparto
      FechaRendicion
      CodigoCliente
      IdProveedor
      FechaActualizacion
      Direccion
      IdLocalidad
      IdCategoria
      CodigoErrorAfip
      IdPlanCuenta
      TotalImpuestoerno
      MetodoGrabacion
      IdFuncion
      SaldoActualCtaCte
      NumeroOrdenCompra
      IdCobrador
      IdMoneda
      IdClienteVinculado
      FechaEnvioCorreo
      NombreCliente
      Cuit
      TipoDocCliente
      NroDocCliente
      FechaTransferencia
      Palets
      Cbu
      CbuAlias
      NumeroComprobanteFiscal
      CantidadReentosImpresion
      NroVersionAplicacion
      ReferenciaComercial
      AnulacionFCE
      IdEjercicio
      IdVendedor
      EsCtaOrden
      DescuentoRecargoPorcManual
      FechaExportacion
      IdPaciente
      IdDoctor
      FechaCirugia
      IdAFIPReferenciaTransferencia
      IdIcotermExportacion
      IdDestinoExportacion
      EsFacturaExportacion
      IdEmbarcacion
      CodigoEmbarcacion
      NombreEmbarcacion
      IdCategoriaEmbarcacion
      NombreCategoriaEmbarcacion
      IdTransportistaTransporte
      IdChoferTransporte
      PatenteVehiculoTransporte
      FechaPagoExportacion
      IdConceptoCM05
      NroFacturaProveedor
      NroRemitoProveedor
      SaldoActualCtaCteUnificado
      IdTipoComprobanteInvocacionMasiva
      NroRepartoInvocacionMasiva
      IdCama
      CodigoCama
      IdNave
      NombreNave
      IdCategoriaCama
      NombreCategoriaCama
      IdDomicilio
      ImporteDolares
   End Enum

   Public Enum ColumnasWVentasProductos
      IdEmpresa
      IdSucursal
      IdEjecucion
      EstadoEjec
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdProducto
      Cantidad
      Precio
      Costo
      DescRecGeneral
      DescuentoRecargo
      PrecioLista
      Utilidad
      ImporteTotal
      DescuentoRecargoProducto
      DescuentoRecargoPorc
      DescRecGeneralProducto
      PrecioNeto
      ImporteTotalNeto
      Kilos
      DescuentoRecargoPorc2
      NombreProducto
      IdTipoImpuesto
      AlicuotaImpuesto
      ImporteImpuesto
      Orden
      ComisionVendedorPorc
      ComisionVendedor
      IdListaPrecios
      NombreListaPrecios
      ImporteImpuestoInterno
      IdCentroCosto
      PrecioConImpuestos
      PrecioNetoConImpuestos
      ImporteTotalConImpuestos
      ImporteTotalNetoConImpuestos
      PrecioVentaPorTamano
      Tamano
      IdUnidadDeMedida
      IdMoneda
      Garantia
      FechaEntrega
      PorcImpuestoInterno
      TipoOperacion
      Nota
      NombreCortoListaPrecios
      OrigenPorcImpInt
      IdFormula
      Automatico
      IdEstadoVenta
      IdOferta
      FechaDevolucion
      Conversion
      CantidadManual
      IdaAtributoProducto
      IdaAtributoProducto2
      IdaAtributoProducto3
      IdaAtributoProducto4
      IdDeposito
      IdUbicacion
      ModificoPrecioManualmente

   End Enum
   Public Enum ColumnasWVentasImpuestos
      IdEmpresa
      IdSucursal
      IdEjecucion
      EstadoEjec
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdTipoImpuesto
      Alicuota
      Bruto
      Neto
      Importe
      Total
      IdProvincia
      IdRegimenPercepcion
   End Enum

   Public Enum ColumnasWVentasTarjetas
      IdEmpresa
      IdSucursal
      IdEjecucion
      EstadoEjec
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdTarjeta
      IdBanco
      Monto
      Cuotas
      NumeroCupon
      Orden
      NumeroLote
      IdTarjetaCupon
   End Enum

   Public Class Resultado
      Private _cantidadRegistros As Integer
      Public Property CantidadRegistros() As Integer
         Get
            Return _cantidadRegistros
         End Get
         Set(ByVal value As Integer)
            _cantidadRegistros = value
         End Set
      End Property

      Private _insertados As Integer
      Public Property Insertados() As Integer
         Get
            Return _insertados
         End Get
         Set(ByVal value As Integer)
            _insertados = value
         End Set
      End Property
      Private _conErrores As Integer
      Public Property ConErrores() As Integer
         Get
            Return _conErrores
         End Get
         Set(ByVal value As Integer)
            _conErrores = value
         End Set
      End Property
      Private _actualizados As Integer
      Public Property Actualizados() As Integer
         Get
            Return _actualizados
         End Get
         Set(ByVal value As Integer)
            _actualizados = value
         End Set
      End Property
      Private _listaErrores As List(Of String)
      Public Property ListaErrores() As List(Of String)
         Get
            Return _listaErrores
         End Get
         Set(ByVal value As List(Of String))
            _listaErrores = value
         End Set
      End Property
      Private _datos As DataTable
      Public Property Datos() As DataTable
         Get
            Return _datos
         End Get
         Set(ByVal value As DataTable)
            _datos = value
         End Set
      End Property
   End Class

   Public Function GetTodosWClientes() As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.ImportarWebSiExport = New SqlServer.ImportarWebSiExport(Me.da)
         Return sql.GetTodosWClientes()
      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function CrearDataTableCartuchos() As DataTable
      Dim dt As DataTable = New DataTable("Procesos")
      dt.Columns.Add("Proceso", GetType(String))
      dt.Columns.Add("Tabla", GetType(String))
      dt.Columns.Add("Registros", GetType(Integer))
      dt.Columns.Add("Insertados", GetType(Integer))
      dt.Columns.Add("Actualizados", GetType(Integer))
      dt.Columns.Add("ConErrores", GetType(Integer))
      Return dt
   End Function

   Private Sub CargarFila(dt As DataTable, proceso As Cartuchos, tabla As Tablas, registros As Integer, insertados As Integer, actualizados As Integer, conErrores As Integer)
      Dim fila As DataRow
      fila = dt.NewRow()
      fila("Proceso") = proceso.ToString()
      fila("Tabla") = tabla.ToString()
      fila("Registros") = registros
      fila("Insertados") = insertados
      fila("Actualizados") = actualizados
      fila("ConErrores") = conErrores
      dt.Rows.Add(fila)
   End Sub

   Public Enum TipoProceso
      Bajada
      Completo
   End Enum

   Public Function ImportarDatosCartuchos(cartucho As Cartuchos,
                                    ByRef barra As Windows.Forms.ToolStripProgressBar,
                                    ByRef tss As Windows.Forms.ToolStripStatusLabel,
                                    ByRef tss2 As Windows.Forms.ToolStripStatusLabel) As Resultado
      Dim dt As DataTable = CrearDataTableCartuchos()
      Dim resulWCli As Resultado = New Resultado()
      Dim resulWVen As Resultado = New Resultado()

      Try
         If cartucho = Cartuchos.Clientes Or cartucho = Cartuchos.TODOS Then
            tss2.Text = "<Cartucho Clientes>"
            resulWCli = Me.ProcesarWClientes(barra, tss)
            CargarFila(dt, Cartuchos.Clientes, Tablas.WClientes, resulWCli.CantidadRegistros, resulWCli.Insertados, resulWCli.Actualizados, resulWCli.ConErrores)
         End If

         If cartucho = Cartuchos.Ventas Or cartucho = Cartuchos.TODOS Then
            tss2.Text = "<Cartucho Ventas>"
            resulWVen = Me.ProcesarWVentas(barra, tss)
            CargarFila(dt, Cartuchos.Ventas, Tablas.WVentas, resulWVen.CantidadRegistros, resulWVen.Insertados, resulWVen.Actualizados, resulWVen.ConErrores)
         End If


         Dim resulCartuchos As Resultado = New Resultado()

         resulCartuchos.Datos = dt
         resulCartuchos.CantidadRegistros = resulWCli.CantidadRegistros + resulWVen.CantidadRegistros
         resulCartuchos.Insertados = resulWCli.Insertados + resulWVen.Insertados
         resulCartuchos.Actualizados = resulWCli.Actualizados + resulWVen.Actualizados
         resulCartuchos.ConErrores = resulWCli.ConErrores + resulWVen.ConErrores

         resulCartuchos.ListaErrores = New List(Of String)()
         If resulWCli.ListaErrores IsNot Nothing Then
            resulCartuchos.ListaErrores.AddRange(resulWCli.ListaErrores)
         End If
         If resulWVen.ListaErrores IsNot Nothing Then
            resulCartuchos.ListaErrores.AddRange(resulWVen.ListaErrores)
         End If

         Return resulCartuchos

      Catch ex As Exception
         Throw
      Finally
         tss2.Text = ""
      End Try

   End Function

#Region "Proceso Clientes"

   Public Function ProcesarWClientes(ByRef barra As Windows.Forms.ToolStripProgressBar,
                                     ByRef tss As Windows.Forms.ToolStripStatusLabel) As Resultado

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim resu As Resultado = New Resultado()
         resu.ListaErrores = New List(Of String)()

         Dim sql As SqlServer.ImportarWebSiExport = New SqlServer.ImportarWebSiExport(Me.da)
         Dim dt As DataTable = sql.GetTodosWClientes()
         resu.CantidadRegistros = dt.Rows.Count

         Dim regCli As Reglas.Clientes = New Reglas.Clientes(Me.da)
         Dim cl As Entidades.Cliente
         barra.Maximum = dt.Rows.Count
         barra.Value = 0
         Application.DoEvents()

         Dim total As Integer = dt.Rows.Count

         Dim codCliSucu As Long = 0

         For Each dr As DataRow In dt.Rows
            Try
               codCliSucu = GetCodigoCliente(Long.Parse(dr(ColumnasWClientes.CodigoCliente.ToString()).ToString()), Int32.Parse(dr(ColumnasWClientes.IdSucursal.ToString()).ToString()))
               'reviso que no exista el cliente con el codigo 
               cl = regCli.GetUnoPorCodigo(codCliSucu, False, False)

               If cl IsNot Nothing Then
                  cl = CargarDatosCliente(dr, cl)
                  'Trato de actualizar el registro
                  regCli.Actualizar(cl)
                  resu.Actualizados += 1
               Else
                  cl = New Cliente()
                  cl = CargarDatosCliente(dr, cl)
                  'si no existe trato de insertarlo
                  regCli.Insertar(cl)
                  resu.Insertados += 1
               End If
            Catch ex As Exception
               resu.ListaErrores.Add("Cliente - " & cl.CodigoCliente & " - " & ex.Message)
               If ex.InnerException IsNot Nothing Then
                  resu.ListaErrores.Add(ex.InnerException.Message)
                  If ex.InnerException.InnerException IsNot Nothing Then
                     resu.ListaErrores.Add(ex.InnerException.InnerException.Message)
                  End If
               End If
               resu.ConErrores += 1
            End Try
            tss.Text = barra.Value.ToString() + "/" + barra.Maximum.ToString()
            barra.Value += 1
            Application.DoEvents()
         Next

         If resu.ConErrores = 0 Then
            Me.da.CommitTransaction()
         Else
            Me.da.RollbakTransaction()
         End If

         Return resu

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Private Function GetCodigoCliente(codigoActual As Long, idSucursal As Integer) As Long
      Return codigoActual + (100000 * idSucursal)
   End Function

   Private Function CargarDatosCliente(dr As DataRow,
                                       en As Entidades.Cliente) As Entidades.Cliente
      en.Usuario = Eniac.Entidades.Usuario.Actual.Nombre
      'al codigo del cliente le sumo 100000 x el nro. de sucursal por si se repiten los codigos entre sucursales
      en.CodigoCliente = GetCodigoCliente(Long.Parse(dr(ColumnasWClientes.CodigoCliente.ToString()).ToString()), Int32.Parse(dr(ColumnasWClientes.IdSucursal.ToString()).ToString()))

      en.NombreCliente = dr(ColumnasWClientes.NombreCliente.ToString()).ToString()
      en.Contacto = dr(ColumnasWClientes.Contacto.ToString()).ToString()
      en.Direccion = dr(ColumnasWClientes.Direccion.ToString()).ToString()
      en.Telefono = dr(ColumnasWClientes.Telefono.ToString()).ToString()
      en.CorreoElectronico = dr(ColumnasWClientes.CorreoElectronico.ToString()).ToString()
      en.IdCategoriaFiscal = Int32.Parse(dr(ColumnasWClientes.IdCategoriaFiscal.ToString()).ToString())
      en.CategoriaFiscal.IdCategoriaFiscal = Int16.Parse(dr(ColumnasWClientes.IdCategoriaFiscal.ToString()).ToString())
      en.Cuit = dr(ColumnasWClientes.Cuit.ToString()).ToString()
      If Not String.IsNullOrEmpty(dr(ColumnasWClientes.FechaNacimiento.ToString()).ToString()) Then
         en.FechaNacimiento = DateTime.Parse(dr(ColumnasWClientes.FechaNacimiento.ToString()).ToString())
      End If
      en.Observacion = dr(ColumnasWClientes.Observacion.ToString()).ToString()
      en.Activo = Boolean.Parse(dr(ColumnasWClientes.Activo.ToString()).ToString())
      en.ZonaGeografica.IdZonaGeografica = dr(ColumnasWClientes.IdZonaGeografica.ToString()).ToString()
      en.Localidad.IdLocalidad = Int32.Parse(dr(ColumnasWClientes.IdLocalidad.ToString()).ToString())
      en.IdCategoria = Int32.Parse(dr(ColumnasWClientes.IdCategoria.ToString()).ToString())
      en.Cobrador.IdEmpleado = Int32.Parse(dr(ColumnasWClientes.IdCobrador.ToString()).ToString())
      en.TipoCliente.IdTipoCliente = Int32.Parse(dr(ColumnasWClientes.IdTipoCliente.ToString()).ToString())
      en.EstadoCliente.IdEstadoCliente = Int32.Parse(dr(ColumnasWClientes.IdEstadoCliente.ToString()).ToString())
      en.Vendedor.IdEmpleado = Int32.Parse(dr(ColumnasWClientes.IdVendedor.ToString()).ToString())
      en.DadoAltaPor.IdEmpleado = Int32.Parse(dr(ColumnasWClientes.IdDadoAltaPor.ToString()).ToString())
      en.CodigoClienteLetras = dr(ColumnasWClientes.CodigoClienteLetras.ToString()).ToString()
      en.Calle.IdCalle = Int32.Parse(dr(ColumnasWClientes.IdCalle.ToString()).ToString())
      en.Calle2.IdCalle = Int32.Parse(dr(ColumnasWClientes.IdCalle2.ToString()).ToString())
      en.MonedaCredito = Int32.Parse(dr(ColumnasWClientes.MonedaCredito.ToString()).ToString())
      Return en
   End Function

#End Region

#Region "Proceso Ventas"

   Public Function ProcesarWVentas(ByRef barra As Windows.Forms.ToolStripProgressBar,
                                   ByRef tss As Windows.Forms.ToolStripStatusLabel) As Resultado

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim resu As Resultado = New Resultado()
         resu.ListaErrores = New List(Of String)()
         _regCl = New Clientes(Me.da)
         _regPr = New Productos(Me.da)
         _regTC = New TiposComprobantes(Me.da)

         resu.Actualizados = 0
         resu.Insertados = 0
         resu.ConErrores = 0

         Dim sql As SqlServer.ImportarWebSiExport = New SqlServer.ImportarWebSiExport(Me.da)
         Dim dtWventas As DataTable = sql.GetTodosWVentas()
         Dim dtWventasProductos As DataTable = sql.GetTodosWVentasProductos()
         Dim dtWventasImpuestos As DataTable = sql.GetTodosWVentasImpuestos()
         Dim dtWventasTarjetas As DataTable = sql.GetTodosWVentasTarjetas()
         resu.CantidadRegistros = dtWventas.Rows.Count

         Dim regVta As Reglas.Ventas = New Reglas.Ventas(Me.da)
         Dim vt As Entidades.Venta
         barra.Maximum = dtWventas.Rows.Count
         barra.Value = 0
         Application.DoEvents()
         For Each dr As DataRow In dtWventas.Rows
            Try
               vt = Nothing
               If regVta.Existe(Int32.Parse(dr(ColumnasWVentas.IdSucursal.ToString()).ToString()),
                                   dr(ColumnasWVentas.IdTipoComprobante.ToString()).ToString(),
                                   dr(ColumnasWVentas.Letra.ToString()).ToString(),
                                   Short.Parse(dr(ColumnasWVentas.CentroEmisor.ToString()).ToString()),
                                   Long.Parse(dr(ColumnasWVentas.NumeroComprobante.ToString()).ToString())) Then
                  vt = regVta.GetUna(Int32.Parse(dr(ColumnasWVentas.IdSucursal.ToString()).ToString()),
                                  dr(ColumnasWVentas.IdTipoComprobante.ToString()).ToString(),
                                  dr(ColumnasWVentas.Letra.ToString()).ToString(),
                                  Short.Parse(dr(ColumnasWVentas.CentroEmisor.ToString()).ToString()),
                                  Long.Parse(dr(ColumnasWVentas.NumeroComprobante.ToString()).ToString()))
               End If

               If vt IsNot Nothing Then
                  'si existe tendria que eliminar la venta y volver a cargarla completa.
                  vt = CargarDatosVentas(dr, False, vt, dtWventasProductos, dtWventasImpuestos, dtWventasTarjetas)
                  'Trato de actualizar el registro
                  'regVta.ActualizaVenta(vt, False, False, "", False)
                  sql.ActualizoFechasProcesado(dr("Guid").ToString())
                  resu.Actualizados += 1
               Else
                  vt = New Entidades.Venta()
                  'si no existe trato de insertarlo
                  vt = CargarDatosVentas(dr, True, vt, dtWventasProductos, dtWventasImpuestos, dtWventasTarjetas)
                  regVta.Inserta(vt, Entidad.MetodoGrabacion.Automatico, "SiExport")
                  'si lo inserto bien tambien le actualizo
                  sql.ActualizoFechasProcesado(dr("Guid").ToString())
                  resu.Insertados += 1
               End If
            Catch ex As Exception
               resu.ListaErrores.Add(String.Format("ERROR-{0}-{1}-{2}-{3}-{4}-Cliente:{5}",
                                   dr(ColumnasWVentas.IdSucursal.ToString()).ToString(),
                                   dr(ColumnasWVentas.IdTipoComprobante.ToString()).ToString(),
                                   dr(ColumnasWVentas.Letra.ToString()).ToString(),
                                   dr(ColumnasWVentas.CentroEmisor.ToString()).ToString(),
                                   dr(ColumnasWVentas.NumeroComprobante.ToString()).ToString(),
                                    dr(ColumnasWVentas.CodigoCliente.ToString()).ToString()))
               resu.ListaErrores.Add(String.Format("{0}", ex.ToString()))
               If ex.InnerException IsNot Nothing Then
                  resu.ListaErrores.Add(ex.InnerException.Message)
               End If
               resu.ConErrores += 1
            End Try
            barra.Value += 1
            tss.Text = barra.Value.ToString() + "/" + barra.Maximum.ToString()
            Application.DoEvents()
         Next

         'siempre commiteo los registros que fueron exitosos
         Me.da.CommitTransaction()

         Return resu

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Private _regTC As Reglas.TiposComprobantes
   'Private _regCF As Reglas.CategoriasFiscales = New CategoriasFiscales(Me.da)
   'Private _regFP As Reglas.VentasFormasPago = New VentasFormasPago(Me.da)
   Private _regCl As Reglas.Clientes
   Private _regPr As Reglas.Productos
   Private _filtro As String
   Private _filas As DataRow()
   Private _vp As Entidades.VentaProducto
   Private _vi As Entidades.VentaImpuesto
   Private _vt As Entidades.VentaTarjeta

   Private Function CargarDatosVentas(drV As DataRow, esNuevo As Boolean, en As Entidades.Venta, dtVP As DataTable, dtVI As DataTable, dtVT As DataTable) As Entidades.Venta
      en.IdSucursal = Int32.Parse(drV(ColumnasWVentas.IdSucursal.ToString()).ToString())
      en.TipoComprobante = _regTC.GetUno(drV(ColumnasWVentas.IdTipoComprobante.ToString()).ToString())
      'en.TipoComprobante.IdTipoComprobante = drV(ColumnasWVentas.IdTipoComprobante.ToString()).ToString()
      en.LetraComprobante = drV(ColumnasWVentas.Letra.ToString()).ToString()
      en.CentroEmisor = Short.Parse(drV(ColumnasWVentas.CentroEmisor.ToString()).ToString())
      en.Impresora = New Entidades.Impresora()
      en.Impresora.CentroEmisor = en.CentroEmisor
      en.NumeroComprobante = Int64.Parse(drV(ColumnasWVentas.NumeroComprobante.ToString()).ToString())
      en.Fecha = DateTime.Parse(drV(ColumnasWVentas.Fecha.ToString()).ToString())
      en.Subtotal = Decimal.Parse(drV(ColumnasWVentas.SubTotal.ToString()).ToString())
      en.DescuentoRecargo = Decimal.Parse(drV(ColumnasWVentas.DescuentoRecargo.ToString()).ToString())
      en.ImporteTotal = Decimal.Parse(drV(ColumnasWVentas.ImporteTotal.ToString()).ToString())
      'en.CategoriaFiscal = _regCF.GetUno(Short.Parse(drV(ColumnasWVentas.IdCategoriaFiscal.ToString()).ToString()))
      en.CategoriaFiscal = New CategoriaFiscal()
      en.CategoriaFiscal.IdCategoriaFiscal = Short.Parse(drV(ColumnasWVentas.IdCategoriaFiscal.ToString()).ToString())
      'en.FormaPago = _regFP.GetUna(Integer.Parse(drV(ColumnasWVentas.IdFormasPago.ToString()).ToString()))
      en.FormaPago = New VentaFormaPago()
      en.FormaPago.IdFormasPago = Integer.Parse(drV(ColumnasWVentas.IdFormasPago.ToString()).ToString())
      en.Observacion = drV(ColumnasWVentas.Observacion.ToString()).ToString()
      en.ImporteBruto = Decimal.Parse(drV(ColumnasWVentas.ImporteBruto.ToString()).ToString())
      en.DescuentoRecargoPorc = Decimal.Parse(drV(ColumnasWVentas.DescuentoRecargoPorc.ToString()).ToString())
      en.IdEstadoComprobante = drV(ColumnasWVentas.IdEstadoComprobante.ToString()).ToString()
      If Not String.IsNullOrEmpty(drV(ColumnasWVentas.IdCaja.ToString()).ToString()) Then
         en.IdCaja = Int32.Parse(drV(ColumnasWVentas.IdCaja.ToString()).ToString())
      End If
      en.NumeroPlanilla = GetValor(Of Int32)(drV(ColumnasWVentas.NumeroPlanilla.ToString()).ToString())
      en.NumeroMovimiento = GetValor(Of Int32)(drV(ColumnasWVentas.NumeroMovimiento.ToString()).ToString())
      en.ImportePesos = Decimal.Parse(drV(ColumnasWVentas.ImportePesos.ToString()).ToString())
      en.ImporteTickets = Decimal.Parse(drV(ColumnasWVentas.ImporteTickets.ToString()).ToString())
      en.Kilos = Decimal.Parse(drV(ColumnasWVentas.Kilos.ToString()).ToString())
      en.Bultos = Int32.Parse(drV(ColumnasWVentas.Bultos.ToString()).ToString())
      en.ValorDeclarado = Decimal.Parse(drV(ColumnasWVentas.ValorDeclarado.ToString()).ToString())
      If Not String.IsNullOrEmpty(drV(ColumnasWVentas.IdTransportista.ToString()).ToString()) Then
         en.Transportista = New Transportista()
         en.Transportista.idTransportista = Int32.Parse(drV(ColumnasWVentas.IdTransportista.ToString()).ToString())
      End If
      en.NumeroLote = Long.Parse(drV(ColumnasWVentas.NumeroLote.ToString()).ToString())
      en.TotalImpuestos = Decimal.Parse(drV(ColumnasWVentas.TotalImpuestos.ToString()).ToString())
      en.CantidadLotes = Integer.Parse(drV(ColumnasWVentas.CantidadLotes.ToString()).ToString())
      en.Usuario = Eniac.Entidades.Usuario.Actual.Nombre
      If Not String.IsNullOrEmpty(drV(ColumnasWVentas.CAE.ToString()).ToString()) Then
         en.AFIPCAE = New AFIPCAE()
         en.AFIPCAE.CAE = drV(ColumnasWVentas.CAE.ToString()).ToString()
         en.AFIPCAE.CAEVencimiento = DateTime.Parse(drV(ColumnasWVentas.CAEVencimiento.ToString()).ToString())
      End If
      en.Utilidad = Decimal.Parse(drV(ColumnasWVentas.Utilidad.ToString()).ToString())
      en.CotizacionDolar = Decimal.Parse(drV(ColumnasWVentas.CotizacionDolar.ToString()).ToString())
      en.ComisionVendedor = Decimal.Parse(drV(ColumnasWVentas.ComisionVendedor.ToString()).ToString())
      drV(ColumnasWVentas.CodigoCliente.ToString()) = GetCodigoCliente(Long.Parse(drV(ColumnasWVentas.CodigoCliente.ToString()).ToString()), Int32.Parse(drV(ColumnasWVentas.IdSucursal.ToString()).ToString()))
      en.Cliente = _regCl.GetUnoPorCodigo(Long.Parse(drV(ColumnasWVentas.CodigoCliente.ToString()).ToString()))
      If Not String.IsNullOrEmpty(drV(ColumnasWVentas.IdProveedor.ToString()).ToString()) Then
         en.Proveedor = New Proveedor()
         en.Proveedor.IdProveedor = Int32.Parse(drV(ColumnasWVentas.IdProveedor.ToString()).ToString())
      End If
      en.FechaActualizacion = DateTime.Now
      en.Direccion = drV(ColumnasWVentas.Direccion.ToString()).ToString()
      en.IdLocalidad = GetValor(Of Int32)(drV(ColumnasWVentas.IdLocalidad.ToString()).ToString())
      en.IdCategoria = Integer.Parse(drV(ColumnasWVentas.IdCategoria.ToString()).ToString())
      en.CodigoErrorAfip = drV(ColumnasWVentas.CodigoErrorAfip.ToString()).ToString()
      en.Cobrador = New Empleado()
      en.Cobrador.IdEmpleado = Integer.Parse(drV(ColumnasWVentas.IdCobrador.ToString()).ToString())
      en.IdMoneda = Integer.Parse(drV(ColumnasWVentas.IdMoneda.ToString()).ToString())
      en.NombreCliente = drV(ColumnasWVentas.NombreCliente.ToString()).ToString()
      en.Cuit = drV(ColumnasWVentas.Cuit.ToString()).ToString()
      en.TipoDocCliente = drV(ColumnasWVentas.TipoDocCliente.ToString()).ToString()
      en.NroDocCliente = GetValor(Of Long)(drV(ColumnasWVentas.NroDocCliente.ToString()).ToString())
      If Not String.IsNullOrEmpty(drV(ColumnasWVentas.FechaTransferencia.ToString()).ToString()) Then
         en.FechaTransferencia = DateTime.Parse(drV(ColumnasWVentas.FechaTransferencia.ToString()).ToString())
      End If
      en.Palets = Integer.Parse(drV(ColumnasWVentas.Palets.ToString()).ToString())
      en.Cbu = drV(ColumnasWVentas.Cbu.ToString()).ToString()
      en.CbuAlias = drV(ColumnasWVentas.CbuAlias.ToString()).ToString()
      en.Vendedor = New Empleado()
      en.Vendedor.IdEmpleado = Integer.Parse(drV(ColumnasWVentas.IdVendedor.ToString()).ToString())
      en.EsCtaOrden = Boolean.Parse(drV(ColumnasWVentas.EsCtaOrden.ToString()).ToString())
      en.DescuentoRecargoPorcManual = Boolean.Parse(drV(ColumnasWVentas.DescuentoRecargoPorcManual.ToString()).ToString())

      'FILTRO 
      _filtro = String.Format("{0}={1} AND {2}='{3}' AND {4}='{5}' AND {6}={7} AND {8}={9}",
                                      ColumnasWVentasProductos.IdSucursal.ToString(), en.IdSucursal,
                                      ColumnasWVentasProductos.IdTipoComprobante.ToString(), en.IdTipoComprobante,
                                      ColumnasWVentasProductos.Letra.ToString(), en.LetraComprobante,
                                      ColumnasWVentasProductos.CentroEmisor.ToString(), en.CentroEmisor,
                                      ColumnasWVentasProductos.NumeroComprobante.ToString(), en.NumeroComprobante)

      'CARGO LOS PRODUCTOS
      _filas = dtVP.Select(_filtro)
      If _filas.Count > 0 Then
         en.VentasProductos = New List(Of VentaProducto)()
         For Each dr In _filas
            _vp = New VentaProducto()
            _vp = CargarDatosVentasProductos(dr, _vp)
            en.VentasProductos.Add(_vp)
         Next
      End If

      'CARGO LOS IMPUESTOS
      _filas = dtVI.Select(_filtro)
      If _filas.Count > 0 Then
         en.VentasImpuestos = New List(Of VentaImpuesto)()
         For Each dr In _filas
            _vi = New VentaImpuesto()
            _vi = CargarDatosVentasImpuestos(dr, _vi)
            en.VentasImpuestos.Add(_vi)
         Next
      End If

      'CARGO LAS TARJETAS
      _filas = dtVT.Select(_filtro)
      If _filas.Count > 0 Then
         en.Tarjetas = New List(Of VentaTarjeta)()
         For Each dr In _filas
            _vt = New VentaTarjeta()
            _vt = CargarDatosVentasTarjetas(dr, _vt)
            en.Tarjetas.Add(_vt)
         Next
      End If


      Return en
   End Function

   Private Function CargarDatosVentasProductos(dr As DataRow, en As Entidades.VentaProducto) As Entidades.VentaProducto
      en.IdSucursal = Int32.Parse(dr(ColumnasWVentasProductos.IdSucursal.ToString()).ToString())
      en.TipoComprobante = dr(ColumnasWVentasProductos.IdTipoComprobante.ToString()).ToString()
      en.Letra = dr(ColumnasWVentasProductos.Letra.ToString()).ToString()
      en.CentroEmisor = Short.Parse(dr(ColumnasWVentasProductos.CentroEmisor.ToString()).ToString())
      en.NumeroComprobante = Int64.Parse(dr(ColumnasWVentasProductos.NumeroComprobante.ToString()).ToString())

      en.Producto = _regPr.GetUno(dr(ColumnasWVentasProductos.IdProducto.ToString()).ToString())
      'en.Producto.IdProducto = dr(ColumnasWVentasProductos.IdProducto.ToString()).ToString()

      en.Cantidad = Decimal.Parse(dr(ColumnasWVentasProductos.Cantidad.ToString()).ToString())
      en.Precio = Decimal.Parse(dr(ColumnasWVentasProductos.Precio.ToString()).ToString())
      en.Costo = Decimal.Parse(dr(ColumnasWVentasProductos.Costo.ToString()).ToString())
      en.DescRecGeneral = Decimal.Parse(dr(ColumnasWVentasProductos.DescRecGeneral.ToString()).ToString())
      en.DescuentoRecargo = Decimal.Parse(dr(ColumnasWVentasProductos.DescuentoRecargo.ToString()).ToString())
      en.PrecioLista = Decimal.Parse(dr(ColumnasWVentasProductos.PrecioLista.ToString()).ToString())
      en.Utilidad = Decimal.Parse(dr(ColumnasWVentasProductos.Utilidad.ToString()).ToString())
      en.ImporteTotal = Decimal.Parse(dr(ColumnasWVentasProductos.ImporteTotal.ToString()).ToString())
      en.DescuentoRecargoProducto = Decimal.Parse(dr(ColumnasWVentasProductos.DescuentoRecargoProducto.ToString()).ToString())
      en.DescuentoRecargoPorc1 = Decimal.Parse(dr(ColumnasWVentasProductos.DescuentoRecargoPorc.ToString()).ToString())
      en.DescRecGeneralProducto = GetValor(Of Decimal)(dr(ColumnasWVentasProductos.DescRecGeneralProducto.ToString()).ToString())
      en.PrecioNeto = Decimal.Parse(dr(ColumnasWVentasProductos.PrecioNeto.ToString()).ToString())
      en.ImporteTotalNeto = Decimal.Parse(dr(ColumnasWVentasProductos.ImporteTotalNeto.ToString()).ToString())
      en.Kilos = Decimal.Parse(dr(ColumnasWVentasProductos.Kilos.ToString()).ToString())
      en.DescuentoRecargoPorc2 = Decimal.Parse(dr(ColumnasWVentasProductos.DescuentoRecargoPorc2.ToString()).ToString())
      en.NombreProducto = dr(ColumnasWVentasProductos.NombreProducto.ToString()).ToString()
      en.TipoImpuesto = New TipoImpuesto()
      en.TipoImpuesto.IdTipoImpuesto = CType([Enum].Parse(GetType(TipoImpuesto.Tipos), dr(ColumnasWVentasProductos.IdTipoImpuesto.ToString()).ToString()), TipoImpuesto.Tipos)
      en.AlicuotaImpuesto = Decimal.Parse(dr(ColumnasWVentasProductos.AlicuotaImpuesto.ToString()).ToString())
      en.ImporteImpuesto = Decimal.Parse(dr(ColumnasWVentasProductos.ImporteImpuesto.ToString()).ToString())
      en.Orden = Int32.Parse(dr(ColumnasWVentasProductos.Orden.ToString()).ToString())
      en.ComisionVendedorPorc = Decimal.Parse(dr(ColumnasWVentasProductos.ComisionVendedorPorc.ToString()).ToString())
      en.ComisionVendedor = Decimal.Parse(dr(ColumnasWVentasProductos.ComisionVendedor.ToString()).ToString())
      en.IdListaPrecios = Int32.Parse(dr(ColumnasWVentasProductos.IdListaPrecios.ToString()).ToString())
      en.NombreListaPrecios = dr(ColumnasWVentasProductos.NombreListaPrecios.ToString()).ToString()
      en.ImporteImpuestoInterno = Decimal.Parse(dr(ColumnasWVentasProductos.ImporteImpuestoInterno.ToString()).ToString())
      If Not String.IsNullOrEmpty(dr(ColumnasWVentasProductos.IdCentroCosto.ToString()).ToString()) Then
         en.CentroCosto = New ContabilidadCentroCosto()
         en.CentroCosto.IdCentroCosto = GetValor(Of Int32)(dr(ColumnasWVentasProductos.IdCentroCosto.ToString()).ToString())
      End If
      en.PrecioConImpuestos = Decimal.Parse(dr(ColumnasWVentasProductos.PrecioConImpuestos.ToString()).ToString())
      en.PrecioNetoConImpuestos = Decimal.Parse(dr(ColumnasWVentasProductos.PrecioNetoConImpuestos.ToString()).ToString())
      en.ImporteTotalConImpuestos = Decimal.Parse(dr(ColumnasWVentasProductos.ImporteTotalConImpuestos.ToString()).ToString())
      en.ImporteTotalNetoConImpuestos = Decimal.Parse(dr(ColumnasWVentasProductos.ImporteTotalNetoConImpuestos.ToString()).ToString())
      en.PrecioVentaPorTamano = Decimal.Parse(dr(ColumnasWVentasProductos.PrecioVentaPorTamano.ToString()).ToString())
      en.Tamano = Decimal.Parse(dr(ColumnasWVentasProductos.Tamano.ToString()).ToString())
      en.IdUnidadDeMedida = dr(ColumnasWVentasProductos.IdUnidadDeMedida.ToString()).ToString()
      If Not String.IsNullOrEmpty(dr(ColumnasWVentasProductos.IdMoneda.ToString()).ToString()) Then
         en.Moneda = New Moneda()
         en.Moneda.IdMoneda = Int32.Parse(dr(ColumnasWVentasProductos.IdMoneda.ToString()).ToString())
      End If
      en.Garantia = Int32.Parse(dr(ColumnasWVentasProductos.Garantia.ToString()).ToString())
      If Not String.IsNullOrEmpty(dr(ColumnasWVentasProductos.FechaEntrega.ToString()).ToString()) Then
         en.FechaEntrega = GetValor(Of DateTime)(dr(ColumnasWVentasProductos.FechaEntrega.ToString()).ToString())
      End If
      en.PorcImpuestoInterno = Decimal.Parse(dr(ColumnasWVentasProductos.PorcImpuestoInterno.ToString()).ToString())
      en.TipoOperacion = CType([Enum].Parse(GetType(Producto.TiposOperaciones), dr(ColumnasWVentasProductos.TipoOperacion.ToString()).ToString()), Producto.TiposOperaciones)
      en.Nota = dr(ColumnasWVentasProductos.Nota.ToString()).ToString()
      en.NombreCortoListaPrecios = dr(ColumnasWVentasProductos.NombreCortoListaPrecios.ToString()).ToString()
      en.OrigenPorcImpInt = CType([Enum].Parse(GetType(OrigenesPorcImpInt), dr(ColumnasWVentasProductos.OrigenPorcImpInt.ToString()).ToString()), OrigenesPorcImpInt)
      en.IdFormula = GetValor(Of Int32)(dr(ColumnasWVentasProductos.IdFormula.ToString()).ToString())
      en.Automatico = Boolean.Parse(dr(ColumnasWVentasProductos.Automatico.ToString()).ToString())
      en.IdEstadoVenta = GetValor(Of Int32)(dr(ColumnasWVentasProductos.IdEstadoVenta.ToString()).ToString())
      en.IdOferta = GetValor(Of Int32)(dr(ColumnasWVentasProductos.IdOferta.ToString()).ToString())
      en.FechaDevolucion = GetValor(Of DateTime)(dr(ColumnasWVentasProductos.FechaDevolucion.ToString()).ToString())
      en.Conversion = Decimal.Parse(dr(ColumnasWVentasProductos.Conversion.ToString()).ToString())
      en.CantidadManual = Decimal.Parse(dr(ColumnasWVentasProductos.CantidadManual.ToString()).ToString())
      en.IdDeposito = Int32.Parse(dr(ColumnasWVentasProductos.IdDeposito.ToString()).ToString())
      en.IdUbicacion = Int32.Parse(dr(ColumnasWVentasProductos.IdUbicacion.ToString()).ToString())
      en.ModificoPrecioManualmente = Boolean.Parse(dr(ColumnasWVentasProductos.ModificoPrecioManualmente.ToString()).ToString())
      Return en
   End Function

   Private Function CargarDatosVentasImpuestos(dr As DataRow, en As Entidades.VentaImpuesto) As Entidades.VentaImpuesto
      en.IdSucursal = Int32.Parse(dr(ColumnasWVentasImpuestos.IdSucursal.ToString()).ToString())
      en.TipoComprobante = New TipoComprobante()
      en.TipoComprobante.IdTipoComprobante = dr(ColumnasWVentasImpuestos.IdTipoComprobante.ToString()).ToString()
      en.Letra = dr(ColumnasWVentasImpuestos.Letra.ToString()).ToString()
      en.CentroEmisor = Short.Parse(dr(ColumnasWVentasImpuestos.CentroEmisor.ToString()).ToString())
      en.NumeroComprobante = Int64.Parse(dr(ColumnasWVentasImpuestos.NumeroComprobante.ToString()).ToString())
      en.TipoImpuesto = New TipoImpuesto()
      en.TipoImpuesto.IdTipoImpuesto = CType([Enum].Parse(GetType(TipoImpuesto.Tipos), dr(ColumnasWVentasImpuestos.IdTipoImpuesto.ToString()).ToString()), TipoImpuesto.Tipos)
      en.Alicuota = Decimal.Parse(dr(ColumnasWVentasImpuestos.Alicuota.ToString()).ToString())
      en.Bruto = Decimal.Parse(dr(ColumnasWVentasImpuestos.Bruto.ToString()).ToString())
      en.Neto = Decimal.Parse(dr(ColumnasWVentasImpuestos.Neto.ToString()).ToString())
      en.Importe = Decimal.Parse(dr(ColumnasWVentasImpuestos.Importe.ToString()).ToString())
      en.Total = Decimal.Parse(dr(ColumnasWVentasImpuestos.Total.ToString()).ToString())
      If Not String.IsNullOrEmpty(dr(ColumnasWVentasImpuestos.IdProvincia.ToString()).ToString()) Then
         en.IdProvincia = dr(ColumnasWVentasImpuestos.IdProvincia.ToString()).ToString()
      End If
      If Not String.IsNullOrEmpty(dr(ColumnasWVentasImpuestos.IdRegimenPercepcion.ToString()).ToString()) Then
         en.IdRegimenPercepcion = Int32.Parse(dr(ColumnasWVentasImpuestos.IdRegimenPercepcion.ToString()).ToString())
      End If
      Return en
   End Function
   Private Function CargarDatosVentasTarjetas(dr As DataRow, en As Entidades.VentaTarjeta) As Entidades.VentaTarjeta
      en.IdSucursal = Int32.Parse(dr(ColumnasWVentasTarjetas.IdSucursal.ToString()).ToString())
      en.IdTarjetaCupon = Int32.Parse(dr(ColumnasWVentasTarjetas.IdTarjetaCupon.ToString()).ToString())
      en.Tarjeta = New Tarjeta()
      en.Tarjeta.IdTarjeta = Int32.Parse(dr(ColumnasWVentasTarjetas.IdTarjeta.ToString()).ToString())
      If Not String.IsNullOrEmpty(dr(ColumnasWVentasTarjetas.IdBanco.ToString()).ToString()) Then
         en.Banco = New Entidades.Banco()
         en.Banco.IdBanco = Int32.Parse(dr(ColumnasWVentasTarjetas.IdBanco.ToString()).ToString())
      End If
      en.Monto = Decimal.Parse(dr(ColumnasWVentasTarjetas.Monto.ToString()).ToString())
      en.Cuotas = Int32.Parse(dr(ColumnasWVentasTarjetas.Cuotas.ToString()).ToString())
      en.NumeroCupon = Int32.Parse(dr(ColumnasWVentasTarjetas.NumeroCupon.ToString()).ToString())
      en.Orden = Int32.Parse(dr(ColumnasWVentasTarjetas.Orden.ToString()).ToString())
      en.NumeroLote = Int32.Parse(dr(ColumnasWVentasTarjetas.NumeroLote.ToString()).ToString())
      If Not String.IsNullOrEmpty(dr(ColumnasWVentasTarjetas.IdTarjetaCupon.ToString()).ToString()) Then
         en.IdTarjetaCupon = Int32.Parse(dr(ColumnasWVentasTarjetas.IdTarjetaCupon.ToString()).ToString())
      End If
      Return en
   End Function

#End Region

   Private Function GetValor(Of T)(input As String) As T
      Try
         Return CType(Convert.ChangeType(input, GetType(T)), T)
      Catch ex As Exception
         Return Nothing
      End Try
   End Function


End Class
