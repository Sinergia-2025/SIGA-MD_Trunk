'Imports Eniac.Entidades
Imports System.Web
Imports System.Web.Script.Serialization
Imports Eniac.Entidades
Imports Eniac.Reglas.Publicos
Imports Microsoft.FSharp.Data.UnitSystems.SI.UnitNames
Public Class Ventas
   Inherits Base
   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _cache As BusquedasCacheadas

   ''INSERTAR/ACTUALIZAR/BORRAR/EJECUTASP/GET UNA/EXISTE/SOLICITAR CAE

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.New(accesoDatos, New BusquedasCacheadas())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess, cache As BusquedasCacheadas)
      MyBase.New(Entidades.Venta.NombreTabla, accesoDatos)
      _categoriaFiscalEmpresa = New CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)
      _cache = cache
   End Sub

#End Region

#Region "Overrides"
   <Obsolete("No usar este método, usar Insertar(Entidad, MetodoGrabacion, String)", True)>
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
   End Sub
   Public Overloads Sub Insertar(entidad As Eniac.Entidades.Entidad, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      Dim oVentas As Entidades.Venta = DirectCast(entidad, Entidades.Venta)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Me.Inserta(oVentas, MetodoGrabacion, IdFuncion)

         Me.da.CommitTransaction()

      Catch ex As Exception
         Dim erro As Entidades.EniacException = New Entidades.EniacException(ex.Message)
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

      'LA SOLICITUD DE CAE LA DEBEMOS HACER FUERA DE LA TRANSACCION
      '  - SI TODO OK: SE CREA EL COMPROBANTE FINAL Y SE ELIMINA EL PRE-COMPROBANTE
      '  - SI ERROR:   DEBE QUEDAR EL PRE-COMPROBANTE PARA SOLICITAR EL CAE A TRAVES
      '                DE LA PANTALLA DE SOLICITAR CAE
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()


         If Publicos.Facturacion.FacturacionElectronica.FacturacionElectronicaSincronica And
            oVentas.TipoComprobante.EsPreElectronico And oVentas.TipoComprobante.EsElectronico Then

            Dim oVentasAnterior = oVentas

            oVentas = GetUna(oVentas.IdSucursal, oVentas.IdTipoComprobante, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante)

            oVentas.Usuario = Entidades.Usuario.Actual.Nombre
            oVentas.IdCaja = oVentasAnterior.IdCaja
            oVentas.Fecha = oVentasAnterior.Fecha


            If Not Publicos.HayInternet() Then
               Throw New Exception("No tiene internet para realizar esta acción.")
               Exit Sub
            End If

            'Actualizo la Fecha de Transmision al AFIP porque Si tiene la Fecha.. no podra anularlo.

            Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
            sql.U_FechaTransmisionAFIP(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante,
                                                oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor,
                                                oVentas.NumeroComprobante, Date.Now)

            Me.ActualizaCAE(oVentas, Entidades.AFIPCAE.Secuencia.PrimeraVez, MetodoGrabacion, IdFuncion)

            oVentasAnterior.TipoComprobante = oVentas.TipoComprobante
            oVentasAnterior.LetraComprobante = oVentas.LetraComprobante
            oVentasAnterior.CentroEmisor = oVentas.CentroEmisor
            oVentasAnterior.NumeroComprobante = oVentas.NumeroComprobante
         End If

         Me.da.CommitTransaction()

      Catch ex As Exception
         Dim erro As Entidades.EniacException = New Entidades.EniacException(ex.Message)
         If ComprobanteAnt IsNot Nothing Then
            With ComprobanteAnt
               oVentas.IdSucursal = ComprobanteAnt.IdSucursal
               oVentas.TipoComprobante = ComprobanteAnt.TipoComprobante
               oVentas.LetraComprobante = ComprobanteAnt.LetraComprobante
               oVentas.CentroEmisor = ComprobanteAnt.CentroEmisor
               oVentas.NumeroComprobante = ComprobanteAnt.NumeroComprobante
            End With
         End If
         da.RollbakTransaction()
         Throw New ActualizaCAEException(ex, oVentas)
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Class ActualizaCAEException
      Inherits Exception
      Public Property Comprobante As Entidades.Venta
      Public Sub New(ex As Exception, venta As Entidades.Venta)
         MyBase.New("Error solicitando CAE. Verifique el comprobante en Solicitar CAE. ERROR: " + ex.Message, ex)
         Me.Comprobante = venta
      End Sub
   End Class

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)

      Dim oVentas As Entidades.Venta = DirectCast(entidad, Entidades.Venta)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(oVentas, TipoSP._D, Entidades.Entidad.MetodoGrabacion.Manual, "")

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

#End Region

#Region "Metodos Privados"


   Public Sub EjecutaSP(cpbVenta As Eniac.Entidades.Venta, tipo As TipoSP, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)

      'Dim cpbVenta As Eniac.Entidades.Venta = DirectCast(entidad, Eniac.Entidades.Venta)

      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

      Select Case tipo

         Case TipoSP._I

            Publicos.GetSistema().ControlaValidezDeFecha(cpbVenta.Fecha)
            Reglas.Publicos.VerificaFechaUltimoLogin()

            'venta.Impresora.CentroEmisor, venta.NumeroComprobante, venta.Fecha, _
            Dim tipoComp As Entidades.TipoComprobante = cpbVenta.TipoComprobante
            Dim cliente As Entidades.Cliente = cpbVenta.Cliente
            Dim vendedor As Entidades.Empleado = cpbVenta.Vendedor
            Dim cateFiscal As Entidades.CategoriaFiscal = cpbVenta.CategoriaFiscal
            Dim forPago As Entidades.VentaFormaPago = cpbVenta.FormaPago
            Dim transportista As Entidades.Transportista = cpbVenta.Transportista
            Dim letra As String = cpbVenta.LetraComprobante
            Dim fecha As String = cpbVenta.Fecha.ToString()

            cpbVenta.FechaActualizacion = DateTime.Now()

            cpbVenta.NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)

            sql.Ventas_I(cpbVenta.IdSucursal, tipoComp.IdTipoComprobante, letra,
                         cpbVenta.CentroEmisor, cpbVenta.NumeroComprobante, DateTime.Parse(fecha),
                         vendedor.IdEmpleado,
                         cpbVenta.Subtotal, cpbVenta.TotalImpuestos, cpbVenta.ImporteTotal,
                         cpbVenta.DescuentoRecargo, cpbVenta.ImporteBruto, cpbVenta.DescuentoRecargoPorc,
                         cateFiscal.IdCategoriaFiscal, forPago.IdFormasPago,
                         cpbVenta.Observacion, cpbVenta.IdEstadoComprobante,
                         cpbVenta.ImportePesos, cpbVenta.ImporteDolares, cpbVenta.ImporteTickets, cpbVenta.ImporteTarjetas,
                         cpbVenta.ImporteCheques, cpbVenta.Kilos, cpbVenta.Bultos, cpbVenta.ValorDeclarado,
                         transportista.idTransportista, cpbVenta.NumeroLote, cpbVenta.CantidadInvocados, cpbVenta.CantidadLotes,
                         cpbVenta.Usuario, cpbVenta.Utilidad, cpbVenta.CotizacionDolar, cpbVenta.ComisionVendedor, cpbVenta.MercDespachada,
                         cpbVenta.ImporteTransfBancaria, cpbVenta.CuentaBancariaTransfBanc.IdCuentaBancaria, cpbVenta.IdActividad,
                         cpbVenta.Proveedor.IdProveedor, cpbVenta.EsCtaOrden, cpbVenta.FechaEnvio,
                         cpbVenta.NumeroReparto, cpbVenta.FechaRendicion, cpbVenta.Cliente.IdCliente, cpbVenta.FechaActualizacion, cpbVenta.Direccion,
                         cpbVenta.IdLocalidad, cpbVenta.IdCategoria, cpbVenta.TotalImpuestoInterno, MetodoGrabacion, IdFuncion, cpbVenta.SaldoActualCtaCte, cpbVenta.SaldoActualCtaCteUnificado, cpbVenta.NumeroOrdenCompra,
                         cpbVenta.IdMoneda, cpbVenta.IdClienteVinculado, cpbVenta.NombreCliente,
                         cpbVenta.Cuit, cpbVenta.TipoDocCliente, cpbVenta.NroDocCliente, cpbVenta.FechaTransferencia, cpbVenta.Palets, cpbVenta.Cbu, cpbVenta.CbuAlias,
                         cpbVenta.ReferenciaComercial, cpbVenta.AnulacionFCE, cpbVenta.NroVersionAplicacion, cpbVenta.Cobrador.IdEmpleado, cpbVenta.DescuentoRecargoPorcManual,
                         cpbVenta.IdPaciente, cpbVenta.IdDoctor, cpbVenta.FechaCirugia, cpbVenta.IdAFIPReferenciaTransferencia,
                         cpbVenta.IdIcotermExportacion, cpbVenta.IdDestinoExportacion, cpbVenta.EsFacturaExportacion, cpbVenta.FechaPagoExportacion,
                         cpbVenta.IdEmbarcacion, cpbVenta.CodigoEmbarcacion, cpbVenta.NombreEmbarcacion, cpbVenta.IdCategoriaEmbarcacion, cpbVenta.NombreCategoriaEmbarcacion,
                         cpbVenta.IdTransportistaTransporte, cpbVenta.IdChoferTransporte, cpbVenta.VehiculoTransporte.PatenteVehiculo,
                         cpbVenta.IdConceptoCM05, cpbVenta.NroFacturaProveedor, cpbVenta.NroRemitoProveedor, cpbVenta.NroRepartoInvocacionMasiva,
                         cpbVenta.IdCama, cpbVenta.CodigoCama, cpbVenta.IdNave, cpbVenta.NombreNave, cpbVenta.IdCategoriaCama, cpbVenta.NombreCategoriaCama, cpbVenta.IdDomicilio,
                         cpbVenta.FechaVencimiento, cpbVenta.ImporteCuota, cpbVenta.FechaVencimiento2, cpbVenta.ImporteVencimiento2, cpbVenta.FechaVencimiento3, cpbVenta.ImporteVencimiento3,
                         cpbVenta.CodigoDeBarra, cpbVenta.CodigoDeBarraSirplus)

         Case TipoSP._U

            sql.Ventas_U(cpbVenta.IdSucursal, cpbVenta.TipoComprobante.IdTipoComprobante, cpbVenta.LetraComprobante,
                           cpbVenta.CentroEmisor, cpbVenta.NumeroComprobante, cpbVenta.Fecha, cpbVenta.Vendedor.IdEmpleado,
                           cpbVenta.ImporteBruto, cpbVenta.DescuentoRecargo, cpbVenta.DescuentoRecargoPorc, cpbVenta.Subtotal, cpbVenta.TotalImpuestos,
                           cpbVenta.ImporteTotal, cpbVenta.CategoriaFiscal.IdCategoriaFiscal,
                           cpbVenta.FormaPago.IdFormasPago, cpbVenta.Observacion, cpbVenta.IdEstadoComprobante,
                           cpbVenta.ImportePesos, cpbVenta.ImporteDolares, cpbVenta.ImporteTickets, cpbVenta.ImporteTarjetas, cpbVenta.ImporteCheques, cpbVenta.ImporteTransfBancaria,
                           cpbVenta.Kilos,
                           cpbVenta.Bultos, cpbVenta.ValorDeclarado, cpbVenta.Transportista.idTransportista, cpbVenta.NumeroLote, cpbVenta.CantidadInvocados,
                           cpbVenta.CantidadLotes, cpbVenta.Usuario, cpbVenta.Utilidad, cpbVenta.CotizacionDolar, cpbVenta.Cliente.IdCliente, cpbVenta.TotalImpuestoInterno,
                           cpbVenta.SaldoActualCtaCte, cpbVenta.SaldoActualCtaCteUnificado, cpbVenta.NumeroOrdenCompra,
                           cpbVenta.IdMoneda, cpbVenta.IdClienteVinculado, cpbVenta.NombreCliente,
                           cpbVenta.Cuit, cpbVenta.TipoDocCliente, cpbVenta.NroDocCliente, cpbVenta.Cbu, cpbVenta.CbuAlias,
                           cpbVenta.ReferenciaComercial, cpbVenta.AnulacionFCE, cpbVenta.Cobrador.IdEmpleado, Date.Now, cpbVenta.DescuentoRecargoPorcManual,
                           cpbVenta.IdPaciente, cpbVenta.IdDoctor, cpbVenta.FechaCirugia, cpbVenta.IdAFIPReferenciaTransferencia)


         Case TipoSP._D

            Dim sqlVPF As SqlServer.VentasProductosFormulas = New SqlServer.VentasProductosFormulas(da)
            Dim sql2 As SqlServer.VentasProductos = New SqlServer.VentasProductos(da)
            Dim sql3 As SqlServer.VentasCheques = New SqlServer.VentasCheques(da)
            Dim sql4 As SqlServer.VentasObservaciones = New SqlServer.VentasObservaciones(da)
            Dim sql5 As SqlServer.VentasImpuestos = New SqlServer.VentasImpuestos(da)
            Dim sql6 As SqlServer.VentasProductosLotes = New SqlServer.VentasProductosLotes(da)
            Dim sqlVpNroSerie = New SqlServer.VentasProductosNrosSerie(da)
            Dim sql7 As SqlServer.VentasPercepciones = New SqlServer.VentasPercepciones(da)
            Dim sql8 As SqlServer.PercepcionVentas = New SqlServer.PercepcionVentas(da)
            Dim sql9 As Reglas.PercepcionVentas = New Reglas.PercepcionVentas(da)
            Dim sql10 As SqlServer.VentasTarjetas = New SqlServer.VentasTarjetas(da)
            Dim sql11 As SqlServer.VentasChequesRechazados = New SqlServer.VentasChequesRechazados(da)

            Dim sql12 = New SqlServer.VentasTransferencias(da)



            'Elimino la Cuenta Corriente
            Dim oCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes(da)
            If oCtaCte.Existe(cpbVenta.IdSucursal,
               cpbVenta.TipoComprobante.IdTipoComprobante,
               cpbVenta.LetraComprobante,
               cpbVenta.CentroEmisor,
               cpbVenta.NumeroComprobante) Then
               cpbVenta.CuentaCorriente = oCtaCte._GetUna(cpbVenta.IdSucursal,
               cpbVenta.TipoComprobante.IdTipoComprobante,
               cpbVenta.LetraComprobante,
               cpbVenta.CentroEmisor,
               cpbVenta.NumeroComprobante)

               oCtaCte.EliminarCuentaCorriente(cpbVenta.CuentaCorriente)
            End If


            'Elimino los Lotes
            sql6.VentasProductosLotes_D2(cpbVenta.IdSucursal,
            cpbVenta.TipoComprobante.IdTipoComprobante,
            cpbVenta.LetraComprobante,
            cpbVenta.CentroEmisor,
            cpbVenta.NumeroComprobante)

            sqlVpNroSerie.VentasProductosNrosSerie_D(cpbVenta.IdSucursal,
            cpbVenta.TipoComprobante.IdTipoComprobante,
            cpbVenta.LetraComprobante,
            cpbVenta.CentroEmisor,
            cpbVenta.NumeroComprobante)

            'Elimino los totales de Impuestos
            sql5.VentasImpuestos_D2(cpbVenta.IdSucursal, cpbVenta.TipoComprobante.IdTipoComprobante, cpbVenta.LetraComprobante, cpbVenta.CentroEmisor, cpbVenta.NumeroComprobante)

            'Elimino las Observaciones
            sql4.VentasObservaciones_D2(cpbVenta.IdSucursal, cpbVenta.TipoComprobante.IdTipoComprobante, cpbVenta.LetraComprobante, cpbVenta.CentroEmisor, cpbVenta.NumeroComprobante)

            'Elimino Los Cheques
            sql3.VentasCheques_D2(cpbVenta.IdSucursal, cpbVenta.TipoComprobante.IdTipoComprobante, cpbVenta.LetraComprobante, cpbVenta.CentroEmisor, cpbVenta.NumeroComprobante)

            sqlVPF.VentasProductosFormulas_D(cpbVenta.IdSucursal, cpbVenta.TipoComprobante.IdTipoComprobante, cpbVenta.LetraComprobante, cpbVenta.CentroEmisor, cpbVenta.NumeroComprobante,
            idProducto:=String.Empty, orden:=Nothing, idProductoComponente:=String.Empty, idFormula:=0)

            'Elimino el detalle
            sql2.VentasProductos_D2(cpbVenta.IdSucursal, cpbVenta.TipoComprobante.IdTipoComprobante, cpbVenta.LetraComprobante, cpbVenta.CentroEmisor, cpbVenta.NumeroComprobante)

            'Obtengo las percepciones para luego eliminarlas
            Dim lpv As List(Of Entidades.PercepcionVenta) = sql9.GetPorVentasPercepciones(cpbVenta.IdSucursal,
            cpbVenta.TipoComprobante.IdTipoComprobante,
            cpbVenta.LetraComprobante,
            cpbVenta.CentroEmisor,
            cpbVenta.NumeroComprobante,
            cpbVenta.Cliente.IdCliente)
            'Elimino las percepciones de Ventas
            sql7.VentasPercepciones_D(cpbVenta.IdSucursal, cpbVenta.TipoComprobante.IdTipoComprobante, cpbVenta.LetraComprobante, cpbVenta.CentroEmisor, cpbVenta.NumeroComprobante)

            For Each pv As Entidades.PercepcionVenta In lpv
               'Elimino las percepciones propiamente
               sql8.PercepcionVentas_D(cpbVenta.IdSucursal, pv.TipoImpuesto.IdTipoImpuesto.ToString(), pv.EmisorPercepcion, pv.NumeroPercepcion)
            Next

            'elimino las tarjetas de credito
            sql10.VentasTarjetas_D(cpbVenta.IdSucursal, cpbVenta.TipoComprobante.IdTipoComprobante.ToString(), cpbVenta.LetraComprobante, cpbVenta.CentroEmisor, cpbVenta.NumeroComprobante, 0, 0, 0)

            'elimino cheques rechazados
            sql11.VentasChequesRechazados_D2(cpbVenta.IdSucursal, cpbVenta.TipoComprobante.IdTipoComprobante.ToString(), cpbVenta.LetraComprobante, cpbVenta.CentroEmisor, cpbVenta.NumeroComprobante)

            Dim rVV = New VentasInvocados(da)
            rVV._Borrar(cpbVenta)

            'Desaplico este comprobante de todos aquellos facturable que cancele (ejemplo Remito)
            Me.ActualizaDesaplicaFacturables(cpbVenta.IdSucursal,
                                             cpbVenta.TipoComprobante.IdTipoComprobante,
                                             cpbVenta.LetraComprobante,
                                             cpbVenta.CentroEmisor,
                                             cpbVenta.NumeroComprobante)

            'REG-41910.- Elimino los transferencia que tiene la venta si tuviera.- --
            sql12.VentasTransferencias_D(cpbVenta.IdSucursal,
                                         cpbVenta.TipoComprobante.IdTipoComprobante.ToString(),
                                         cpbVenta.LetraComprobante,
                                         cpbVenta.CentroEmisor,
                                         cpbVenta.NumeroComprobante, 0)

            'Elimino la Cabecera
            sql.Ventas_D(cpbVenta.IdSucursal, cpbVenta.TipoComprobante.IdTipoComprobante, cpbVenta.LetraComprobante, cpbVenta.CentroEmisor, cpbVenta.NumeroComprobante)

      End Select

   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub Inserta(oVentas As Entidades.Venta, metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)
      Inserta(oVentas, metodoGrabacion, idFuncion, onAfterInsertarVenta:=Nothing)
   End Sub
   Public Sub Inserta(oVentas As Entidades.Venta, metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String,
                      onAfterInsertarVenta As Action(Of Entidades.Venta))

      LogV("********** Ventas.Insert ********** ")
      LogV(" 0- Inicia Inserta")

      '-- REQ-43864.- -----------------------------------------------------
      GeneracionDatosRoelaSirplus(oVentas)
      '--------------------------------------------------------------------

      Dim oRegProductosOfertas As Reglas.ProductosOfertas = New Reglas.ProductosOfertas(da)
      For Each Prod As Entidades.VentaProducto In oVentas.VentasProductos
         If Prod.IdOferta <> 0 Then
            oRegProductosOfertas.VerificaDisponibilidadOferta(oVentas.Fecha, Prod.IdProducto, Prod.IdOferta)
         End If
      Next

      Dim NumeroComprob As Long = 0
      Dim ctbl As Contabilidad = New Contabilidad(da)

      If oVentas.TipoComprobante.AfectaCaja And Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         'Para que se ejecuten las validaciones.
         oVentas.tablaContabilidad = New ContabilidadProcesos(da).GetRubroVenta(oVentas)
         ctbl.ArmarDetalle(oVentas)
      End If

      If String.IsNullOrWhiteSpace(oVentas.Cbu) And String.IsNullOrWhiteSpace(oVentas.CbuAlias) Then
         Dim cuentasParaInformarFEC As List(Of Entidades.CuentaBancaria) = New Reglas.CuentasBancarias(da).GetParaInformarEnFEC()
         If oVentas.TipoComprobante.AFIPWSRequiereCBU And cuentasParaInformarFEC.Count = 0 Then
            Dim stb As StringBuilder = New StringBuilder()
            stb.AppendLine("AFIP requiere que las Factura de Crédito Electrónica MiPyMEs (FCE) informen CBU y/o CBU Alias.")
            stb.AppendLine()
            stb.AppendLine("No tiene ninguna Cuenta Bancaria configurada para informar en la FCE.")
            stb.AppendLine()
            stb.AppendLine("Configure una cuenta bancaria Para Factura de Crédito Electrónica MiPyMEs (FCE) y luego reintente.")
            Throw New Exception(stb.ToString())
         End If
         If cuentasParaInformarFEC.Count > 0 Then
            oVentas.Cbu = cuentasParaInformarFEC(0).Cbu
            oVentas.CbuAlias = cuentasParaInformarFEC(0).CbuAlias
         End If
      End If

      If oVentas.TipoComprobante.GrabaLibro Or oVentas.TipoComprobante.EsPreElectronico Then
         Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales(da)
         Dim dt As DataTable = oPF.Get1(actual.Sucursal.IdEmpresa, Integer.Parse(oVentas.Fecha.ToString("yyyyMM")))
         If dt.Rows.Count = 0 Then
            Throw New Exception("La Fecha del Comprobante pertenece a un Periodo Fiscal que aún NO esta habilitado.")
         ElseIf Not String.IsNullOrEmpty(dt.Rows(0)("FechaCierre").ToString()) Then
            Throw New Exception("La Fecha del Comprobante pertenece a un Periodo Fiscal Cerrado.")
         ElseIf Not Boolean.Parse(dt.Rows(0)("VentasHabilitadas").ToString()) Then
            Throw New Exception(String.Format("El Período Fiscal '{0}' no está habilitado para emitir Comprobantes de Venta.", oVentas.Fecha.ToString("yyyy/MM")))
         End If
      End If


      'entidad.PersistoValoresPropiedades()

      Dim srtCatFiscalEmp As Short = Publicos.CategoriaFiscalEmpresa ' Short.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.CATEGORIAFISCALEMPRESA))
      Dim CategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(srtCatFiscalEmp)

      Dim sucursalVenta As Entidades.Sucursal = New Reglas.Sucursales(da).GetUna(oVentas.IdSucursal, incluirLogo:=False)

      Dim oVentasNumeros As Reglas.VentasNumeros = New Reglas.VentasNumeros(da)
      NumeroComprob = oVentasNumeros.GetProximoNumero(sucursalVenta, oVentas.TipoComprobante.IdTipoComprobante,
                                                      oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor)

      'Tiene que ser NO fiscal y NO haberlo digitado en la pantalla.
      If (Not oVentas.TipoComprobante.EsFiscal Or oVentas.TipoComprobante.EsPreElectronico) And oVentas.NumeroComprobante = 0 Then
         oVentas.NumeroComprobante = NumeroComprob
      End If

      LogV(String.Format(" 1- Preparando grabación de {0} {1} {2} {3:0000}-{4:00000000}",
                         oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, oVentas.LetraComprobante,
                         oVentas.Impresora.CentroEmisor, oVentas.NumeroComprobante))

      'Se cambia de lugar esta validación y se quita la condición de control.
      'Originalmente solo validaba si era Manual, ahora validamos siempre por estas condiciones:
      '  Si el numerador se tiró para atrás, debe darme error de que se ya existe.
      '  Si es fiscal, se pudo resetear el fiscal o haber dado vuelta el numerador.
      'If Not oVentas.TipoComprobante.EsFiscal And oVentas.NumeroComprobante > 0 Then
      If Me.Existe(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante,
                     oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor,
                     oVentas.NumeroComprobante) Then
         Throw New Exception(String.Format("El Numero de Comprobante {0} {1} {2:0000}-{3:00000000} YA Existe.",
                                           oVentas.IdTipoComprobante, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante))
         'Throw New Exception("El Numero de Comprobante " & oVentas.NumeroComprobante.ToString() & " YA Existe.")
      End If
      'End If

      'actualizo el numero de venta en las tablas solo si el numero se calculo
      If oVentas.NumeroComprobante >= NumeroComprob Then
         Me.ActualizarNumerosVentas(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante,
                                    oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor,
                                    oVentas.NumeroComprobante, oVentas.Fecha)
      End If

      oVentas.CentroEmisor = oVentas.Impresora.CentroEmisor

      Dim oCtasCtes = New CuentasCorrientes(da)
      If oCtasCtes.Existe(oVentas.IdSucursal,
                         oVentas.IdTipoComprobante,
                         oVentas.LetraComprobante,
                         oVentas.CentroEmisor,
                         oVentas.NumeroComprobante) Then
         Throw New Exception("Este comprobante ya EXISTE en Cuentas Corrientes ")
      End If

      '--------------------------------------------------------------

      'Actualizo el estado a los Comprobantes Facturados (si existieron)
      GetDisponibilidadComprobanteInvocadoPorTipo(oVentas)

      '--------------------------------------------------------------

      If oVentas.Cobrador Is Nothing Then
         oVentas.Cobrador = oVentas.Cliente.Cobrador
      End If

      'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
      Dim coe As Integer = oVentas.TipoComprobante.CoeficienteValores

      oVentas.ImporteBruto = oVentas.ImporteBruto * coe
      oVentas.DescuentoRecargo = oVentas.DescuentoRecargo * coe
      'oVentas.DescuentoRecargoPorc = oVentas.DescuentoRecargoPorc * coe   'Los Porcentajes NO hay que cambiarlos.
      oVentas.Subtotal = oVentas.Subtotal * coe
      oVentas.TotalImpuestos = oVentas.TotalImpuestos * coe
      oVentas.ImporteTotal = oVentas.ImporteTotal * coe

      oVentas.ImportePesos = oVentas.ImportePesos * coe
      oVentas.ImporteDolares = oVentas.ImporteDolares * coe

      oVentas.ImporteTickets = oVentas.ImporteTickets * coe
      'oVentas.ImporteTarjetas = oVentas.ImporteTarjetas * coe
      For Each tr As Entidades.VentaTarjeta In oVentas.Tarjetas
         tr.Monto = tr.Monto * coe
      Next

      oVentas.Kilos = oVentas.Kilos * coe

      oVentas.Utilidad = oVentas.Utilidad * coe

      oVentas.ComisionVendedor = 0
      oVentas.ImporteTransfBancaria = oVentas.ImporteTransfBancaria * coe

      oVentas.CuentaBancariaTransfBanc = oVentas.CuentaBancariaTransfBanc
      oVentas.FechaActualizacion = Date.Now()

      'GAR: 16/07/2019. Porque ESTO????
      oVentas.FechaTransferencia = oVentas.FechaTransferencia

      If oVentas.ImporteTransfBancaria <> 0 And Not oVentas.FechaTransferencia.HasValue Then
         oVentas.FechaTransferencia = oVentas.Fecha
      End If


      Dim oCtaCte As CuentasCorrientes = New CuentasCorrientes(da)
      If Reglas.Publicos.CtaCte.CtaCteClientesSeparar Then
         Dim tpRecibo = New TiposComprobantes(da).GetMinutas(oVentas.IdSucursal, "VENTAS", "CTACTECLIE", {oVentas.IdTipoComprobante}, False)
         If tpRecibo.Count > 0 Then
            Dim strComprobantesAsociados As String = tpRecibo(0).ComprobantesAsociados
            oVentas.SaldoActualCtaCte = oCtaCte.GetSaldoCliente({sucursalVenta}, oVentas.Cliente.IdCliente, fechaSaldo:=Nothing, contemplaHora:=False, comprobantesAsociados:=strComprobantesAsociados, grabaLibro:=Nothing, comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:=String.Empty, excluirPreComprobantes:=True, IdCama:=0, IdEmbarcacion:=0)
         Else
            oVentas.SaldoActualCtaCte = oCtaCte.GetSaldoCliente({sucursalVenta}, oVentas.Cliente.IdCliente, fechaSaldo:=Nothing, contemplaHora:=False, comprobantesAsociados:="TODOS", grabaLibro:=Nothing, comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:=String.Empty, excluirPreComprobantes:=True, IdCama:=0, IdEmbarcacion:=0)
         End If
      Else
         oVentas.SaldoActualCtaCte = oCtaCte.GetSaldoCliente({sucursalVenta}, oVentas.Cliente.IdCliente, fechaSaldo:=Nothing, contemplaHora:=False, comprobantesAsociados:="TODOS", grabaLibro:=Nothing, comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:=String.Empty, excluirPreComprobantes:=True, IdCama:=0, IdEmbarcacion:=0)
      End If
      If (oVentas.TipoComprobante.AfectaCaja Or oVentas.TipoComprobante.EsPreElectronico) AndAlso oVentas.TipoComprobante.ActualizaCtaCte Then
         oVentas.SaldoActualCtaCte += oVentas.ImporteACtaCte
      End If

      oVentas.SaldoActualCtaCteUnificado = oCtaCte.GetSaldoCliente({sucursalVenta}, oVentas.Cliente.IdCliente, fechaSaldo:=Nothing, contemplaHora:=False, comprobantesAsociados:="TODOS", grabaLibro:=Nothing, comprobantesExcluidos:=Nothing, numeroComprobanteFinalizaCon:=String.Empty, excluirPreComprobantes:=True, IdCama:=0, IdEmbarcacion:=0)

      'ajusto los valores de los impuestos previo a insertar el comprobante por los montos todoales
      Me.AjustoValoresImpuestos(oVentas, coe)

      'En caso de que el comprobante venga de una generación automática, que no permite modificar esta información de pantalla,
      'y no le puso los datos del cliente a la venta (el nombre está en blanco), tomo los valores del cliente.

      '-- REQ-31374.- -------------------------------------------
      If String.IsNullOrWhiteSpace(oVentas.NombreCliente) Then
         oVentas.NombreCliente = oVentas.Cliente.NombreCliente
         oVentas.Cuit = oVentas.Cliente.Cuit
         oVentas.TipoDocCliente = oVentas.Cliente.TipoDocCliente
         oVentas.NroDocCliente = oVentas.Cliente.NroDocCliente
      End If

      '# Valido nuevamente, que los lotes ingresados (en caso que corresponda) sigan estando disponibles en stock.
      If oVentas.TipoComprobante.CoeficienteStock <> 0 Then
         Dim rProductoLote As Reglas.ProductosLotes = New Reglas.ProductosLotes

         '>>> Invoco un comprobante que NO AFECTÓ STOCK - No realizo ninguna validación
         'If oVentas.Facturables.Count > 0 AndAlso oVentas.Facturables(0).TipoComprobante.CoeficienteStock = 0 Then
         If oVentas.Invocados.Count > 0 AndAlso oVentas.Invocados(0).Invocado.CoeficienteStock = 0 Then
            For Each vp As Entidades.VentaProducto In oVentas.VentasProductos
               For Each vpl As Entidades.VentaProductoLote In vp.VentasProductosLotes
                  If vpl.Cantidad > rProductoLote.GetStockLote(vpl.IdSucursal, vp.IdDeposito, vp.IdUbicacion, vpl.IdProducto, vpl.IdLote) Then
                     Throw New Exception(String.Format("ATENCIÓN: No hay stock suficiente en el lote {0} del producto {1} para realizar la operación.", vpl.IdLote, vp.Producto.NombreProducto))
                  End If
               Next
            Next
         End If

         '>>> Venta Normal, SIN INVOCACiÓN - Vuelvo a realizar la validación
         'If oVentas.Facturables.Count = 0 AndAlso oVentas.TipoComprobante.CoeficienteStock < 0 Then
         If oVentas.Invocados.Count = 0 AndAlso oVentas.TipoComprobante.CoeficienteStock < 0 Then
            If oVentas.CrmInvocados.Count = 0 Then
               For Each vp As Entidades.VentaProducto In oVentas.VentasProductos
                  For Each vpl As Entidades.VentaProductoLote In vp.VentasProductosLotes
                     If vpl.Cantidad > rProductoLote.GetStockLote(vpl.IdSucursal, vp.IdDeposito, vp.IdUbicacion, vpl.IdProducto, vpl.IdLote) Then
                        Throw New Exception(String.Format("ATENCIÓN: No hay stock suficiente en el lote {0} del producto {1} para realizar la operación.", vpl.IdLote, vp.Producto.NombreProducto))
                     End If
                  Next
               Next
            End If
         End If
      End If

      If oVentas.Transferencias Is Nothing Then oVentas.Transferencias = New List(Of Entidades.VentaTransferencia)()
      If oVentas.Transferencias.Count > 0 Then
         oVentas.ImporteTransfBancaria = oVentas.Transferencias.Sum(Function(vt) vt.Importe) * coe
         If oVentas.Transferencias.Select(Function(vt) vt.IdCuentaBancaria).Distinct().Count > 1 Then
            oVentas.CuentaBancariaTransfBanc = New CuentasBancarias(da).GetUna(999)
         Else
            oVentas.CuentaBancariaTransfBanc = New CuentasBancarias(da).GetUna(oVentas.Transferencias.First().IdCuentaBancaria)
         End If
      Else
         If oVentas.Transferencias.Count = 0 AndAlso oVentas.ImporteTransfBancaria <> 0 Then
            oVentas.Transferencias.Add(New Entidades.VentaTransferencia() With
                                       {
                                          .Importe = oVentas.ImporteTransfBancaria,
                                          .Orden = 1,
                                          .IdCuentaBancaria = oVentas.CuentaBancariaTransfBanc.IdCuentaBancaria
                                       })
         End If
         oVentas.ImporteTransfBancaria = oVentas.ImporteTransfBancaria * coe
         oVentas.CuentaBancariaTransfBanc = oVentas.CuentaBancariaTransfBanc
      End If

      LogV(String.Format(" 2- Antes de EjecutaSP de {0} {1} {2} {3:0000}-{4:00000000}",
                         oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, oVentas.LetraComprobante,
                         oVentas.Impresora.CentroEmisor, oVentas.NumeroComprobante))

      'oVentas.Tarjetas.ForEachSecure(Sub(tr) tr.IdTarjetaCupon = 0)

      'Graba el comprobante de Venta (Factura, Nota de Debito, Nota de Credito, etc.)
      EjecutaSP(oVentas, TipoSP._I, metodoGrabacion, idFuncion)

      If onAfterInsertarVenta IsNot Nothing Then
         onAfterInsertarVenta(oVentas)
      End If

      '-- Actualizo Tabla de Permisos de Embarques para exportacion.- --
      If oVentas.EsFacturaExportacion And oVentas.ExportacionEmbarques.Count <> 0 Then
         GrabaPermisosEmbarquesExportacion(oVentas)
      End If
      '-----------------------------------------------------------------

      'Vuelvo a dejarlo en positivo porque cada modulo hace el manejo del coeficiente, y sobre todo caja, es llamado de varios lugares.
      oVentas.ImportePesos = oVentas.ImportePesos * coe
      oVentas.ImporteDolares = oVentas.ImporteDolares * coe
      oVentas.ImporteTickets = oVentas.ImporteTickets * coe
      'oVentas.ImporteTarjetas = oVentas.ImporteTarjetas * coe
      For Each tr As Entidades.VentaTarjeta In oVentas.Tarjetas
         tr.Monto = tr.Monto * coe
      Next

      oVentas.Transferencias.ForEach(Sub(trx)
                                        trx.IdSucursalLibroBanco = Nothing
                                        trx.IdCuentaBancariaLibroBanco = Nothing
                                        trx.NumeroMovimientoLibroBanco = Nothing
                                     End Sub)

      Dim rVTrx = New VentasTransferencias(da)
      rVTrx._Insertar(oVentas, coe)

      Dim numeroOrden As Integer = 0

      LogV(String.Format(" 3- Antes de InsertaDetalle"))
      'grabo el detalle de la factura
      Me.InsertaDetalle(oVentas, coe, CategoriaFiscalEmpresa, idFuncion)

      LogV(String.Format(" 4- Antes de ActualizaComisionVendedor"))
      'Actualiza la Comision Del Vendedor. Se calcula a partir del detalle que quitó impuestos y aplicando todos los descuentos.
      Me.ActualizaComisionVendedor(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante)

      LogV(String.Format(" 5- Antes de ActualizoInfoDeCheques"))
      Me.ActualizoInfoDeCheques(oVentas)



      LogV(String.Format(" 6- Antes de GrabaImpuestosVenta"))
      'Graba impuestos
      Me.GrabaImpuestosVenta(oVentas)

      Dim VentasObserv As Reglas.VentasObservaciones = New Reglas.VentasObservaciones(da)

      Dim observaciones = New List(Of Entidades.VentaObservacion)(oVentas.VentasObservaciones)

      'Dim algunCambio As Boolean = False
      'Dim vo As VentaObservacion
      'For Each vp As VentaProducto In oVentas.VentasProductos
      '   If vp.TipoOperacion = Producto.TiposOperaciones.CAMBIO Then
      '      If Not algunCambio Then
      '         vo = New VentaObservacion()
      '         vo.Observacion = New String("*"c, 80)
      '         observaciones.Add(vo)
      '         vo = New VentaObservacion()
      '         vo.Observacion = New String(" "c, 30) + "CAMBIOS"
      '         observaciones.Add(vo)
      '         algunCambio = True
      '      End If

      '      vo = New VentaObservacion()
      '      vo.Observacion = String.Format("{0} - {1} Cantidad: {2}", vp.IdProducto, vp.NombreProducto, vp.Cantidad)
      '      observaciones.Add(vo)
      '   End If
      'Next

      Dim idTipoObservacionDefault = New Reglas.TiposObservaciones().GetIdTipoObservacionDefecto()

      LogV(String.Format(" 7- Antes de VentasObserv.EjecutaSP"))
      Dim ContObs As Integer = 0 'Reenumero porque en algunos casos repite el numero de linea.

      For Each Observ As Entidades.VentaObservacion In observaciones
         '-- Contador.- --
         ContObs += 1
         '-- Carga Datos de Comprobante.- --
         Observ.IdSucursal = oVentas.IdSucursal
         Observ.IdTipoComprobante = oVentas.TipoComprobante.IdTipoComprobante
         Observ.Letra = oVentas.LetraComprobante
         Observ.CentroEmisor = oVentas.Impresora.CentroEmisor
         Observ.NumeroComprobante = oVentas.NumeroComprobante
         Observ.Linea = ContObs
         If Observ.IdTipoObservacion = 0 Then
            Observ.IdTipoObservacion = idTipoObservacionDefault
         End If
         '-- Grabo las observaciones del comprobante de venta
         VentasObserv.EjecutaSP(Observ, TipoSP._I)
      Next


      '-- REG-31697.- --
      If oVentas.TipoComprobante.GrabaLibro And Not oVentas.TipoComprobante.EsPreElectronico And oVentas.CategoriaFiscal.LeyendaCategoriaFiscal <> Nothing Then
         '-- Divide la Leyenda.- --
         Dim vObserva = oVentas.CategoriaFiscal.LeyendaCategoriaFiscal.DivideEnPartes(100)
         '-- Carga la Leyenda.- --
         For i As Integer = 0 To (vObserva.Count - 1)
            Dim observ = New Entidades.VentaObservacion()
            '-- Contador.- --
            ContObs += 1

            observ.IdSucursal = oVentas.IdSucursal
            observ.IdTipoComprobante = oVentas.TipoComprobante.IdTipoComprobante
            observ.Letra = oVentas.LetraComprobante
            observ.CentroEmisor = oVentas.Impresora.CentroEmisor
            observ.NumeroComprobante = oVentas.NumeroComprobante
            observ.Linea = ContObs
            observ.IdTipoObservacion = idTipoObservacionDefault
            '-- Carga la Observacion.- --
            observ.Observacion = vObserva(i)
            '-- Grabo las observaciones del comprobante de venta
            VentasObserv.EjecutaSP(observ, TipoSP._I)
         Next
      End If
      '--------------------------------------------------------------


      LogV(String.Format(" 8- Antes de InsertaContactosDesdeVenta"))
      'Grabo los contactos
      Dim rVentaCont As VentasClientesContactos = New VentasClientesContactos(da)
      rVentaCont.InsertaContactosDesdeVenta(oVentas)

      'Agrego el Saldo de la Venta.
      If oVentas.TipoComprobante.GrabaLibro Then

         Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales(da)

         Dim PeriodoFiscal As Integer = Integer.Parse(oVentas.Fecha.ToString("yyyyMM"))
         Dim Neto As Decimal = oVentas.Subtotal
         Dim IVA As Decimal = oVentas.TotalIVA

         oPF.ActualizarPosicion(actual.Sucursal.IdEmpresa, PeriodoFiscal, Neto, IVA, oVentas.ImporteTotal, 0, 0, 0, 0, 0)

      End If
      '--------------------------------------------------------------

      'Actualizo el estado a los Comprobantes Facturados (si existieron)
      Me.ActualizoEstadoComprobantesFacturados(oVentas)
      Me.GeneraContramovimientoDeInvocados(oVentas, idFuncion)

      '--------------------------------------------------------------
      Dim blnDescontoStock As Boolean = False

      LogV(String.Format(" 8- Antes de oVentas.TipoComprobante.CoeficienteStock <> 0"))
      LogV(String.Format(" 8.1- oVentas.TipoComprobante.CoeficienteStock = {0}", oVentas.TipoComprobante.CoeficienteStock))
      'pregunto si el CoeficienteStock es distinto de 0, si es asi lo multiplico por la cantidad del producto
      'los valores posibles para el coeficientestock son 0, 1 y -1
      If oVentas.TipoComprobante.CoeficienteStock <> 0 Then

         Dim oMov = New MovimientosStock(da)

         Dim yaConsumioElCRM = oVentas.CrmInvocados.Any(Function(crm) crm.ProductosNovedad.Any(Function(crmP) crmP.StockConsumidoProducto))

         If Not yaConsumioElCRM Then
            'Si NO facturo otros (ej: Factura sin Facturables).
            If oVentas.Invocados.Count = 0 Then
               oMov.GrabaMovimientoStockVenta(Me.GetMovimientoVenta(oVentas))
               'Si tiene Produccion Automatica debe devolver los componentes
               blnDescontoStock = True 'oVentas.TipoComprobante.CoeficienteStock < 0 'True  --- Solo interesa si descuenta!!

               'O Facturo y ese facturado NO desconto Stock (ej: PRESUPUESTO).
            ElseIf oVentas.Invocados.Count > 0 And oVentas.Invocados(0).Invocado.CoeficienteStock = 0 Then
               oMov.GrabaMovimientoStockVenta(Me.GetMovimientoVenta(oVentas))
               'Si tiene Produccion Automatica debe devolver los componentes
               blnDescontoStock = True 'oVentas.TipoComprobante.CoeficienteStock < 0 'True  --- Solo interesa si descuenta!!

               'O Facturo pero devuelve (Deshace Remito) y ese facturado si desconto Stock (ej: Remito)
            ElseIf oVentas.Invocados.Count > 0 And oVentas.TipoComprobante.CoeficienteStock > 0 And oVentas.Invocados(0).Invocado.CoeficienteStock < 0 Then
               oMov.GrabaMovimientoStockVenta(Me.GetMovimientoVenta(oVentas))
               'Si tiene Produccion Automatica debe devolver los componentes
               blnDescontoStock = True

            End If
         End If
      End If

      '# Si la venta trae productos con Lote, deben grabarse siempre en VentasProductosLotes
      '########################################################################################################################################################################
      '# Cuando la selección de Lotes está en AUTOMÁTICO, la grabación de VentasProductosLotes se hace dentro de la regla que graba el MovimientoVentaProducto (ver ARRIBA)   #
      '########################################################################################################################################################################
      If Publicos.Facturacion.FacturacionSeleccionManualLoteProducto Or oVentas.TipoComprobante.EsPreElectronico Then
         Dim rVentasProductosLotes = New VentasProductosLotes(da)
         For Each vp In oVentas.VentasProductos
            For Each pLote In vp.VentasProductosLotes
               rVentasProductosLotes._Inserta(New Entidades.VentaProductoLote With
                                             {
                                                .IdSucursal = oVentas.IdSucursal,
                                                .IdDeposito = vp.IdDeposito,
                                                .IdUbicacion = vp.IdUbicacion,
                                                .TipoComprobante = oVentas.TipoComprobante.IdTipoComprobante,
                                                .Letra = oVentas.LetraComprobante,
                                                .CentroEmisor = oVentas.CentroEmisor,
                                                .NumeroComprobante = oVentas.NumeroComprobante,
                                                .Producto = vp.Producto,
                                                .IdLote = pLote.IdLote,
                                                .FechaVencimiento = pLote.FechaVencimiento,
                                                .Cantidad = pLote.Cantidad * coe,
                                                .Orden = vp.Orden
                                             })
            Next
         Next
      End If

      ActualizaCantidadLotes(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante)

      If blnDescontoStock Then
         'Descuenta Stock de los Componentes de Productos
         Me.DescuentoStockComponentes(oVentas, metodoGrabacion, idFuncion)
      End If
      '-------------------------------------------------------------------------------------------

      If oVentas.TipoComprobante.GeneraContabilidad And Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         ctbl.RegistraContabilidad(oVentas)   ''CargarContabilidad2(oVentas)
      End If

      'Si el tipo de pago es cuenta corriente tengo que grabar en las tablas de Cuentas Corrientes
      If oVentas.TipoComprobante.ActualizaCtaCte Then
         Me.GrabaMovimientosDeCtasCtes(oVentas, metodoGrabacion, idFuncion)
      End If

      If oVentas.TipoComprobante.AfectaCaja And Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         ctbl.MarcarCtaCteRegistroProcesado(oVentas)   ''CargarContabilidad2(oVentas)
      End If

      'si es Contado verifico si tiene el modulo de Caja, asi grabo los movimientos
      If oVentas.FormaPago.Dias = 0 Then
         GrabaMovimientosDeCaja(oVentas)
      Else

         'Aunque sea CtaCte se graba igual Caja y Planilla para que se vea en la solapa de Venta en CtaCte.
         If Publicos.TieneModuloCaja Then ' Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCAJA)) Then

            'si el tipo de comprobante afecta la caja, porque puede suceder que no la afecte
            'ya que si es un cliente que tiene fichas y despues factura por aca se complica

            If oVentas.TipoComprobante.AfectaCaja Then

               Dim rCaja = New Cajas(da)
               Dim planillaActual = rCaja.GetPlanillaActual(oVentas.IdSucursal, oVentas.IdCaja)
               If planillaActual Is Nothing Then
                  Throw New Exception(String.Format("No se pudo encontrar una Planilla Activa para la Caja {0}", oVentas.IdCaja))
               End If

               oVentas.NumeroPlanilla = planillaActual.NumeroPlanilla

               ActualizaPlanillaCaja(oVentas)

            End If

         End If

      End If

      ActualizoInfoDeTarjetas(oVentas, oVentas.IdCaja, oVentas.NumeroPlanilla, oVentas.NumeroMovimiento)

      'Dim comprobantes As List(Of String) = New List(Of String)()
      'comprobantes.Add("ePRE-FACT")
      'comprobantes.Add("ePRE-NCRED")
      'comprobantes.Add("ePRE-NDEB")

      'SE SACA DE ESTA TRANSACCION Y SE PASA AL METODO INSERTAR
      '' ''If Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Parametro.Parametros.FACTELECTSINCRONICA)) And _
      '' ''  oVentas.TipoComprobante.EsPreElectronico Then

      '' ''   'Actualizo la Fecha de Transmision al AFIP porque Si tiene la Fecha.. no podra anularlo.

      '' ''   Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
      '' ''   sql.U_FechaTransmisionAFIP(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, _
      '' ''                                       oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor, _
      '' ''                                       oVentas.NumeroComprobante, Date.Now)

      '' ''   Me.ActualizaCAE(oVentas, AFIPCAE.Secuencia.PrimeraVez)
      '' ''End If

      'entidad.RecuperoValoresPropiedades()



      'Actualizo nros Serie 
      Dim rVentasProductosNrosSerie As Reglas.VentasProductosNrosSerie = New Reglas.VentasProductosNrosSerie(da)
      Dim eVentaProductoNroSerie As Entidades.VentaProductoNroSerie
      For Each vp As Entidades.VentaProducto In oVentas.VentasProductos
         For Each ns As Entidades.ProductoNroSerie In vp.Producto.NrosSeries
            ns.TipoComprobante = oVentas.TipoComprobante
            ns.Letra = oVentas.LetraComprobante
            ns.CentroEmisor = oVentas.CentroEmisor
            ns.NumeroComprobante = oVentas.NumeroComprobante

            '# Grabo los productos con Nro Serie en su tabla correspondiente
            eVentaProductoNroSerie = New Entidades.VentaProductoNroSerie
            eVentaProductoNroSerie.IdSucursal = vp.IdSucursal
            eVentaProductoNroSerie.IdTipoComprobante = ns.TipoComprobante.IdTipoComprobante
            eVentaProductoNroSerie.Letra = ns.Letra
            eVentaProductoNroSerie.CentroEmisor = Integer.Parse(ns.CentroEmisor.ToString())
            eVentaProductoNroSerie.NumeroComprobante = ns.NumeroComprobante
            eVentaProductoNroSerie.Orden = vp.Orden
            eVentaProductoNroSerie.IdProducto = ns.Producto.IdProducto
            eVentaProductoNroSerie.NroSerie = ns.NroSerie
            rVentasProductosNrosSerie._Inserta(eVentaProductoNroSerie)
         Next
      Next
      Dim rNrosSerie = New ProductosNrosSerie(da)
      For Each vp In oVentas.VentasProductos
         For Each dr In vp.Producto.NrosSeries
            'Si es Factura marca el nro de serie como vendido sin importar si es o no PreElectronico
            'Si es Nota de Crédito solo marco el nro de serie cuando no es PreElectronico
            'Esto es porque al vender nos importa que no se vuelva a seleccionar en una venta, pero
            'si es una PreNC no queremos limpiar la venta hasta que se confirme la misma (solicitar CAE)
            'ya que la PreNC se puede anular.
            ActualizaNroSerie(oVentas, rNrosSerie, dr.Sucursal, dr.Producto, dr.NroSerie, vp.Orden, dr.OrdenCompra, vp.FechaDevolucion)
         Next
         For Each pf In vp.VentasProductosFormulas
            If pf.SeleccionMultiple IsNot Nothing AndAlso pf.SeleccionMultiple.NrosSerie.AnySecure() Then
               For Each ns In pf.SeleccionMultiple.NrosSerie
                  ActualizaNroSerie(oVentas, rNrosSerie, _cache.BuscaSucursal(vp.IdSucursal), _cache.BuscaProductoEntidadPorId(ns.IdProducto, da), ns.NroSerie, vp.Orden, ordenCompra:=Nothing, fechaDevolucion:=Nothing)
               Next
            End If
         Next
      Next

      Dim countPedidos = oVentas.Invocados.Where(Function(i) i.Invocado.TipoTipoComprobante = "PEDIDOSCLIE").Count
      'For Each fact As Entidades.Venta In oVentas.Facturables
      '   If fact.TipoComprobante.Tipo = "PEDIDOSCLIE" Then
      '      countPedidos += 1
      '   End If
      'Next

      '******************************
      'vml 30/1/12
      ''If (((blnDescontoStock And oVentas.TipoComprobante.CoeficienteStock < 0) AndAlso
      ''     (Not oVentas.TipoComprobante.EsElectronico OrElse Not Publicos.PreFacturaConsumePedidos)) Or
      ''    (oVentas.TipoComprobante.EsPreElectronico And Publicos.PreFacturaConsumePedidos)) And
      ''   (Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.PEDIDOSFACTURARAUTOMATICO)) Or
      ''    (Publicos.FacturarPedidoSeleccionado And countPedidos > 0)) And
      ''   Not oVentas.Observacion.Contains("Generado por Cambio de Estado de pedido") Then
      If (oVentas.TipoComprobante.ConsumePedidos) And
         (Publicos.PedidosFacturarAutomatico Or (Publicos.Facturacion.FacturarPedidoSeleccionado And countPedidos > 0)) And
         Not oVentas.Observacion.Contains("Generado por Cambio de Estado de pedido") Then
         FacturarPedidos(oVentas, idFuncion)
      End If
      '****************************************************************

      '******************************
      'vml 10/9/12
      'If oVentas.TipoComprobante.AfectaCaja And Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.CONTABILIDADEJECUTARENLINEA)) Then
      '   Me.CargarContabilidad(oVentas)
      'End If
      '****************************************************************

      'si tiene modulo Bancos
      If oVentas.TipoComprobante.AfectaCaja Then
         If Publicos.TieneModuloBanco Then ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOBANCO)) Then

            My.Application.Log.WriteEntry("Actualizo los o el Banco con los datos de la Transferencia.", TraceEventType.Verbose)
            Dim oLibroBancos = New LibroBancos(da)
            Dim entLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
            Dim oLibBanco = New LibroBancos(da)

            If oVentas.ImporteTransfBancaria <> 0 And oVentas.FormaPago.Dias = 0 Then
               For Each trx In oVentas.Transferencias
                  With entLibroBanco
                     .IdSucursal = oVentas.IdSucursal
                     .IdCuentaBancaria = trx.IdCuentaBancaria
                     .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                     .IdCuentaBanco = Publicos.CtaBancoTransfBancaria ' Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTABANCOTRANSFBANCARIA))
                     If oVentas.TipoComprobante.CoeficienteValores > 0 Then
                        .IdTipoMovimiento = "I"
                     Else
                        .IdTipoMovimiento = "E"
                     End If
                     .Importe = Math.Abs(trx.Importe)
                     .FechaMovimiento = oVentas.Fecha
                     .IdCheque = Nothing
                     .FechaAplicado = oVentas.FechaTransferencia.Value
                     '.Observacion = ent.Observacion
                     .Observacion = String.Format("{0} {1} {2}-{3:00000000} - Transf. a Cuenta. {4}",
                                                  oVentas.TipoComprobante.Descripcion, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante, oVentas.Cliente.NombreCliente).Truncar(100)
                     .Conciliado = False
                  End With

                  oLibroBancos.AgregaMovimiento(entLibroBanco)

                  trx.IdSucursalLibroBanco = entLibroBanco.IdSucursal
                  trx.IdCuentaBancariaLibroBanco = entLibroBanco.IdCuentaBancaria
                  trx.NumeroMovimientoLibroBanco = entLibroBanco.NumeroMovimiento

                  rVTrx._Actualizar(trx)
               Next
            End If

            'Acredito las tarjetas en la cuenta
            Dim entLibroBancoTar As Entidades.LibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
            Dim oLibBancoTar As Eniac.Reglas.LibroBancos = New Eniac.Reglas.LibroBancos(da)
            Dim ultimoDia As Date
            Dim diaUltimo As Integer
            Dim cantdias As Integer
            Dim ultimoDiaX As Date
            Dim diaMes As Date

            For Each tr As Entidades.VentaTarjeta In oVentas.Tarjetas
               'Solo si tiene configurado el Deposito Automatico. Se analiza Individualmente.
               If tr.Tarjeta.Acreditacion Then
                  With entLibroBancoTar
                     .IdSucursal = oVentas.IdSucursal
                     .IdCuentaBancaria = tr.Tarjeta.CuentaBancaria.IdCuentaBancaria
                     .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
                     .IdCuentaBanco = Publicos.CtaBancoAcredTarjeta '  New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTABANCOACREDTARJETA))
                     .IdTipoMovimiento = If(oVentas.TipoComprobante.CoeficienteValores = -1 AndAlso oVentas.TipoComprobante.Tipo = "VENTAS", "E", "I")
                     .Importe = tr.Monto
                     .FechaMovimiento = oVentas.Fecha
                     .IdCheque = Nothing
                     If tr.Tarjeta.PagoPosVenta Then
                        .FechaAplicado = oVentas.Fecha.AddDays(tr.Tarjeta.CantDiasAcredit)
                     Else
                        If tr.Tarjeta.PagoPosCorte Then
                           ultimoDia = DateSerial(Year(oVentas.Fecha), Month(oVentas.Fecha) + 1, 0)
                           diaUltimo = ultimoDia.DayOfWeek()
                           If diaUltimo = (tr.Tarjeta.DiaCorte + 1) Then
                              ultimoDiaX = ultimoDia
                           Else
                              cantdias = (7 + diaUltimo - (tr.Tarjeta.DiaCorte + 1))
                              ultimoDiaX = ultimoDia.AddDays(-cantdias)
                           End If
                           .FechaAplicado = ultimoDiaX.AddDays(tr.Tarjeta.CantDiasAcredit)
                        Else
                           'PagoDiaMes
                           diaMes = DateSerial(Year(.FechaMovimiento), Month(.FechaMovimiento), tr.Tarjeta.DiaMes)
                           If .FechaMovimiento < diaMes Then
                              .FechaAplicado = diaMes.AddDays(tr.Tarjeta.CantDiasAcredit)
                           Else
                              .FechaAplicado = DateAdd("m", 1, diaMes).AddDays(tr.Tarjeta.CantDiasAcredit)
                           End If
                        End If

                     End If

                     '.Observacion = ent.Observacion
                     .Observacion = Strings.Left(tr.NombreTarjeta & "(" & tr.NombreBanco & ")Cup:" & tr.NumeroCupon & "-Ctas(" & tr.Cuotas & ")-" & oVentas.TipoComprobante.Descripcion & " " & oVentas.LetraComprobante & " " & oVentas.CentroEmisor.ToString() & "-" & oVentas.NumeroComprobante.ToString("00000000") & "(" & oVentas.Cliente.NombreCliente & ")", 100)
                     .Conciliado = False
                  End With
                  oLibroBancos.AgregaMovimiento(entLibroBancoTar)
               End If
            Next
         End If
      End If

      If oVentas.VentasAdjuntos IsNot Nothing Then
         Dim rAdjuntos As Reglas.VentasAdjuntos = New VentasAdjuntos(da)
         rAdjuntos._ActualizaDesdeVentas(oVentas)
      End If

      '# Turnos
      If oVentas.TurnosInvocados.Count > 0 Then
         Dim rTurnos As Reglas.TurnosCalendarios = New TurnosCalendarios(da)
         rTurnos.InvocarTurno(oVentas)
      End If

      '# CRM
      If oVentas.CrmInvocados.Count > 0 Then
         Dim rNovedades = New CRMNovedades(da)
         rNovedades.ActualizarDatosVentaCRM(oVentas, oVentas.TipoComprobante.CoeficienteValores < 0)
      End If

      'Elimino el comprobante invocado-----------------
      'Esta propiedad viene en True solo de Facturación Rápida
      If oVentas.ReemplazaComprobante Then
         'If oVentas.Facturables IsNot Nothing Then
         For Each ent In oVentas.Invocados
            AnularComprobante(ent.Invocado, oVentas.IdCaja, actual.Nombre, metodoGrabacion, idFuncion)
         Next
         'End If
      End If

      '-- REQ-43864.- -----------------------------------------------------
      If oVentas.CuentaCorriente.Pagos.Count > 0 AndAlso
            oVentas.TipoComprobante.CoeficienteStock <= 0 AndAlso
               New Reglas.Intereses(da).GetUno(New Reglas.Categorias(da).GetUno(oVentas.Cliente.IdCategoria).IdInteres).InteresesDias.Count > 0 AndAlso
               oVentas.TipoComprobante.CoeficienteValores = 1 Then
         Dim eEmple = New Reglas.Empleados().GetUno(oVentas.Cliente.Cobrador.IdEmpleado)
         If eEmple.EntidadCobranza = Entidades.Empleado.TipoEntidadCobranza.SIRPLUS.ToString() AndAlso oVentas.CuentaCorriente.Pagos(0).CodigoDeBarraSirplus Is Nothing Then
            ActualizaCodigoDeBarraSirplus(oVentas)
            Dim sql = New SqlServer.CuentasCorrientesPagos(da)
            Using dt = sql.GetPorCuentaCorriente(oVentas.IdSucursal, oVentas.IdTipoComprobante, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante)
               oVentas.CuentaCorriente.Pagos(0).CodigoDeBarraSirplus = dt(0)("CodigoDeBarraSirPlus").ToString()
            End Using
         End If
         If eEmple.EntidadCobranza <> Entidades.Empleado.TipoEntidadCobranza.NINGUNO.ToString() Then
            ActualizaDatosCodigoBarraSirplusVentas(oVentas)
         End If
      End If
      '---------------------------------------------------------------------

      '-- Actualiza Ventas Con Datos Cargos.- 
      Dim splitTipoComprobanteEnviadoCajero As String() = Publicos.TipoComprobanteEnviadoCajero.Split(";"c)
      If splitTipoComprobanteEnviadoCajero.Contains(oVentas.IdTipoComprobante) Then
         'Evaluo que va a generar cajero para ver si debo considerar alguna otra condición:
         'Si Genera VENTAS:  Directamente genero cajero
         'Si Genera RECIBOS: Solo genero si el combrobante va a Cuenta Corriente
         '' ''Dim grabaCajero As Boolean = False
         '' ''If Publicos.CajeroGenera = Entidades.VentaCajero.CajeroGenera.Ventas.ToString() Then
         '' ''   grabaCajero = True
         '' ''ElseIf Publicos.CajeroGenera = Entidades.VentaCajero.CajeroGenera.Recibos.ToString() Then
         '' ''   'TODO: Tomar esto de parámetro
         '' ''   Dim formaPagoGrabar As String = "ContadoCuentaCorriente"
         '' ''   If formaPagoGrabar = "ContadoCuentaCorriente" Then
         '' ''      grabaCajero = True
         '' ''   ElseIf formaPagoGrabar = "Contado" Then
         '' ''      If oVentas.FormaPago.Dias = 0 Then
         '' ''         grabaCajero = True
         '' ''      End If
         '' ''   ElseIf formaPagoGrabar = "CuentaCorriente" Then
         '' ''      If oVentas.FormaPago.Dias > 0 Then
         '' ''         grabaCajero = True
         '' ''      End If
         '' ''   End If
         '' ''End If
         '' ''If grabaCajero Then
         If (Publicos.CajeroGenera = Entidades.VentaCajero.CajeroGenera.Ventas.ToString()) Or
            (Publicos.CajeroGenera = Entidades.VentaCajero.CajeroGenera.Recibos.ToString() And
             oVentas.FormaPago.Dias > 0) Then

            Dim debeInsertar As Boolean = True
            'If oVentas.Invocados.Count > 0 Then
            '   For Each invocado In oVentas.Invocados
            '      If splitTipoComprobanteEnviadoCajero.Contains(invocado.IdTipoComprobanteInvocado) Then
            '         debeInsertar = False
            '         Exit For
            '      End If
            '   Next
            'End If
            If debeInsertar Then
               Dim rVentasCajeros = New VentasCajeros(da)
               Dim oVentaCajero = Entidades.VentaCajero.FromVenta(oVentas)
               oVentaCajero.NombreCliente = oVentas.NombreCliente
               rVentasCajeros._Insertar(oVentaCajero)
            End If
         End If
      End If

      If oVentas.TipoComprobante.EsPreFiscal Then
         Dim oVentaColaImpr As Entidades.VentaColaImpresion = New VentasColasImpresion(da).GetTodos()(0)
         Dim rVentasColaImprC As Reglas.VentasColasImpresionComprobantes = New VentasColasImpresionComprobantes(da)
         Dim oVentaColaImprC = Entidades.VentaColaImpresionComprobante.FromVenta(oVentaColaImpr.IdVentaColaImpresion, oVentas)
         rVentasColaImprC.Insertar(oVentaColaImprC)
      End If

      LogV(" 0.1- Finaliza Inserta")
      LogV("********** Ventas.Insert ********** ")

   End Sub

   Private Shared Sub ActualizaNroSerie(oVentas As Entidades.Venta, rNrosSerie As ProductosNrosSerie, sucursalProducto As Entidades.Sucursal, producto As Entidades.Producto,
                                        nroSerie As String, orden As Integer?, ordenCompra As Integer?, fechaDevolucion As Date?)
      If oVentas.TipoComprobante.CoeficienteValores = -1 Then
         If Not oVentas.TipoComprobante.EsPreElectronico Then
            rNrosSerie.ProductosNrosSerie_UDevolucion(producto.IdProducto, nroSerie)
         End If
      Else
         If oVentas.Cliente.IdSucursalAsociada <> 0 And oVentas.Cliente.IdSucursalAsociada <> sucursalProducto.IdSucursal Then
            rNrosSerie.ActualizaCambioSucursal(producto.IdProducto, nroSerie, oVentas.Cliente.IdSucursalAsociada)
         Else
            Dim ns = New Entidades.ProductoNroSerie With
               {
                  .Producto = producto,
                  .NroSerie = nroSerie,
                  .Sucursal = sucursalProducto,
                  .TipoComprobante = oVentas.TipoComprobante,
                  .Letra = oVentas.LetraComprobante,
                  .CentroEmisor = oVentas.CentroEmisor,
                  .NumeroComprobante = oVentas.NumeroComprobante,
                  .Vendido = True,
                  .OrdenVenta = orden,
                  .OrdenCompra = ordenCompra,
                  .FechaDevolucionVenta = fechaDevolucion
            }
            rNrosSerie._Actualiza(ns)
         End If
      End If
   End Sub

   Public Function GetUna(idSucursal As Integer,
                          idTipoComprobante As String,
                          idCliente As Long,
                          fecha As DateTime,
                          importeTotal As Decimal) As Entidades.Venta
      Dim stb = New StringBuilder()

      With stb
         .AppendFormat("SELECT V.IdSucursal, V.IdTipoComprobante, V.Letra, V.CentroEmisor, V.NumeroComprobante")
         .AppendFormat("  FROM Ventas V")
         .AppendFormat(" WHERE V.IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND V.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND V.IdCliente = {0}", idCliente)
         .AppendFormat("   AND V.Fecha >= '{0:yyyyMMdd}'", fecha)
         .AppendFormat("   AND V.ImporteTotal = {0}", importeTotal)
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Return GetUna(Integer.Parse(dr(Entidades.Venta.Columnas.IdSucursal.ToString()).ToString()),
                       dr(Entidades.Venta.Columnas.IdTipoComprobante.ToString()).ToString(),
                       dr(Entidades.Venta.Columnas.Letra.ToString()).ToString(),
                       Short.Parse(dr(Entidades.Venta.Columnas.CentroEmisor.ToString()).ToString()),
                       Long.Parse(dr(Entidades.Venta.Columnas.NumeroComprobante.ToString()).ToString()))
      Else
         Return Nothing
      End If

   End Function
   Public Function GetUna(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Short,
                          numeroComprobante As Long) As Entidades.Venta

      'Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open

      Try
         'If blnAbreConexion Then da.OpenConection()

         Dim stb = New StringBuilder()

         With stb
            .AppendLine("SELECT V.IdSucursal, ")
            .AppendLine("	V.IdTipoComprobante,")
            .AppendLine("	V.Letra,")
            .AppendLine("	V.CentroEmisor,")
            .AppendLine("	V.NumeroComprobante,")
            .AppendLine("	V.Fecha,")
            .AppendLine("   V.IdCLiente,")
            .AppendLine("	V.IdVendedor,")
            .AppendLine("	V.IdCategoriaFiscal,")
            .AppendLine("	V.IdFormasPago,")
            .AppendLine("	V.Observacion,")
            .AppendLine("	I.IdImpresora,")
            .AppendLine("	I.TipoImpresora,")
            .AppendLine("	V.ImporteBruto,")
            .AppendLine("	V.DescuentoRecargo,")
            .AppendLine("	V.DescuentoRecargoPorc,")
            .AppendLine("	V.SubTotal,")
            .AppendLine("	V.TotalImpuestos,")
            .AppendLine("  V.Usuario,")
            .AppendLine("  V.TotalImpuestoInterno,")
            .AppendLine("	V.ImporteTotal,")
            .AppendLine("	V.IdEstadoComprobante,")
            '.AppendLine("	V.IdTipoComprobanteFact,")
            '.AppendLine("	V.LetraFact,")
            '.AppendLine("	V.CentroEmisorFact,")
            '.AppendLine("	V.NumeroComprobanteFact,")
            .AppendLine("	V.IdCaja,")
            .AppendLine("	V.NumeroPlanilla,")
            .AppendLine("	V.NumeroMovimiento,")
            .AppendLine("	V.ImportePesos,")
            .AppendLine("	V.ImporteDolares,")
            .AppendLine("	V.ImporteTickets,")
            .AppendLine("	V.ImporteTarjetas,")
            .AppendLine("	V.ImporteCheques,")
            .AppendLine("	V.Kilos,")
            .AppendLine("	V.Bultos,")
            .AppendLine("	V.ValorDeclarado,")
            .AppendLine("	V.IdTransportista,")
            .AppendLine("	V.NumeroLote,")
            .AppendLine("	V.CAE,")
            .AppendLine("	V.CAEVencimiento,")
            .AppendLine("	V.Utilidad,")
            .AppendLine("	V.FechaTransmisionAFIP,")
            .AppendLine("	V.CotizacionDolar,")
            '.AppendLine("  V.IdPeriodo")
            .AppendLine("  V.IdProveedor")
            .AppendLine("  ,V.EsCtaOrden")
            .AppendLine("  ,V.IdCuentaBancaria")
            .AppendLine("  ,V.ImporteTransfBancaria")
            .AppendLine("  ,V.FechaEnvio")
            .AppendLine("  ,V.NumeroReparto")
            .AppendLine("  ,V.FechaRendicion")
            .AppendLine("  ,V.MercDespachada")
            .AppendLine("  ,V.Direccion")
            '.AppendLine("  ,V.LocalidadCliente")
            '.AppendLine("  ,V.ProvinciaCliente")
            .AppendLine("  ,V.IdLocalidad")
            .AppendLine("  ,V.IdEjercicio")
            .AppendLine("  ,V.IdPlanCuenta")
            .AppendLine("  ,V.IdAsiento")
            .AppendLine("	,V.IdCategoria")
            .AppendLine("  ,V.ComisionVendedor")
            .AppendLine("  ,V.TotalImpuestoInterno")
            .AppendLine("  ,V.SaldoActualCtaCte")
            .AppendLine("  ,V.SaldoActualCtaCteUnificado")
            .AppendLine("  ,V.CodigoErrorAfip")
            .AppendLine("  ,V.NumeroOrdenCompra")
            .AppendLine("  ,V.IdCobrador")
            .AppendLine("  ,V.IdMoneda")
            .AppendLine("  ,V.IdClienteVinculado")
            .AppendLine("  ,V.IdActividad")
            .AppendLine("  ,V.NombreCliente")
            .AppendLine("  ,V.Cuit")
            .AppendLine("  ,V.TipoDocCliente")
            .AppendLine("  ,V.NroDocCliente")
            .AppendLine("	,V.Palets")
            .AppendLine("  ,V.Cbu")
            .AppendLine("  ,V.CbuAlias")
            .AppendLine("  ,V.ReferenciaComercial")
            .AppendLine("  ,V.AnulacionFCE")
            .AppendLine("  ,V.NroVersionAplicacion")
            .AppendFormatLine("  ,V.{0}", Entidades.Venta.Columnas.DescuentoRecargoPorcManual.ToString())
            .AppendFormatLine("  ,V.FechaExportacion")
            .AppendFormatLine("  ,V.IdPaciente")
            .AppendFormatLine("  ,V.IdDoctor")
            .AppendFormatLine("  ,V.FechaCirugia")
            .AppendFormatLine("  ,V.IdAFIPReferenciaTransferencia")
            .AppendFormatLine("  ,V.FechaActualizacion") '-.PE-32964.-
            '-- REQ-31198.- -----------------------------------------
            .AppendLine("      ,V.IdIcotermExportacion")
            .AppendLine("      ,V.IdDestinoExportacion")
            .AppendLine("      ,V.EsFacturaExportacion")
            '-- REQ-31198.- -----------------------------------------
            .AppendLine("      ,V.FechaPagoExportacion")

            .AppendLine("      ,V.IdEmbarcacion")
            .AppendLine("      ,V.IdCategoriaEmbarcacion")
            .AppendLine("      ,V.NombreCategoriaEmbarcacion")
            '-- REQ-36331.- -----------------------------------------
            .AppendLine("      ,V.IdCama")
            .AppendLine("      ,V.CodigoCama")
            .AppendLine("      ,V.IdNave")
            .AppendLine("      ,V.NombreNave")
            .AppendLine("      ,V.IdCategoriaCama")
            .AppendLine("      ,V.NombreCategoriaCama")
            '--------------------------------------------------------
            .AppendLine("      ,T.NombreTransportista as NombreTransportistaTransporte")
            .AppendLine("      ,V.PatenteVehiculoTransporte")
            '--------------------------------------------------------
            .AppendLine("      ,V.NroFacturaProveedor")
            .AppendLine("      ,V.NroRemitoProveedor")
            '-- REQ-33791.- --------------------------------------------------------------------------------------------------
            .AppendLine("      ,V.IdConceptoCM05")
            .AppendFormatLine("     , CM05.DescripcionConceptoCM05")
            .AppendFormatLine("     , CM05.TipoConceptoCM05")
            .AppendFormatLine("     , V.IdTipoComprobanteInvocacionMasiva")
            .AppendFormatLine("     , V.IdDomicilio")

            .AppendLine("     , V.FechaVencimiento")
            .AppendLine("     , V.ImporteCuota")
            .AppendLine("     , V.FechaVencimiento2")
            .AppendLine("     , V.ImporteVencimiento2")
            .AppendLine("     , V.FechaVencimiento3")
            .AppendLine("     , V.ImporteVencimiento3")
            .AppendLine("     , V.CodigoDeBarra")
            .AppendLine("     , V.CodigoDeBarraSirplus")

            .AppendLine(" FROM Ventas V ")
            .AppendLine("  INNER JOIN Impresoras I ON I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")
            .AppendLine("  LEFT JOIN Transportistas T ON T.idtransportista = V.IdTransportistaTransporte")
            .AppendFormatLine("  LEFT JOIN AFIPConceptosCM05 CM05 ON CM05.IdConceptoCM05 = V.IdConceptoCM05")
            .AppendLine(" WHERE V.IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
            .AppendLine("   AND V.Letra = '" & letra & "'")
            .AppendLine("   AND V.CentroEmisor = " & centroEmisor.ToString())
            .AppendLine("   AND V.NumeroComprobante = " & numeroComprobante.ToString())
            '-----------------------------------------------------------------------------------------------------------------
         End With

         Dim dt = Me.da.GetDataTable(stb.ToString())

         Dim venta = New Entidades.Venta()

         If dt.Rows.Count > 0 Then

            Dim row As DataRow = dt.Rows(0)

            With venta
               .IdSucursal = Integer.Parse(row("IdSucursal").ToString())
               .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(row("IdTipoComprobante").ToString())
               .LetraComprobante = row("Letra").ToString()
               .CentroEmisor = Short.Parse(row("CentroEmisor").ToString())
               .NumeroComprobante = Long.Parse(row("NumeroComprobante").ToString())
               .Fecha = Date.Parse(row("Fecha").ToString())

               If Not String.IsNullOrEmpty(row("FechaVencimiento").ToString()) Then
                  .FechaVencimiento = DateTime.Parse(row("FechaVencimiento").ToString())
                  .ImporteCuota = Decimal.Parse(row("ImporteCuota").ToString())
                  .FechaVencimiento2 = DateTime.Parse(row("FechaVencimiento2").ToString())
                  .ImporteVencimiento2 = Decimal.Parse(row("ImporteVencimiento2").ToString())
                  If Not String.IsNullOrEmpty(row("FechaVencimiento3").ToString()) Then
                     .FechaVencimiento3 = DateTime.Parse(row("FechaVencimiento3").ToString())
                     .ImporteVencimiento3 = Decimal.Parse(row("ImporteVencimiento3").ToString())
                  End If
                  If Not String.IsNullOrEmpty(row("CodigoDeBarra").ToString()) Then
                     .CodigoDeBarra = row("CodigoDeBarra").ToString()
                  End If
                  If Not String.IsNullOrEmpty(row("CodigoDeBarraSirplus").ToString()) Then
                     .CodigoDeBarraSirplus = row("CodigoDeBarraSirplus").ToString()
                  End If
               End If

               Dim rCliente As Reglas.Clientes = New Reglas.Clientes(da)
               .Cliente = rCliente._GetUno(Long.Parse(row("IdCliente").ToString()), False)

               If IsNumeric(row("IdClienteVinculado")) Then
                  .ClienteVinculado = rCliente._GetUno(Long.Parse(row("IdClienteVinculado").ToString()), False)
               End If

               .Vendedor = New Reglas.Empleados(da).GetUno(Integer.Parse(row("IdVendedor").ToString()))
               .Usuario = row("Usuario").ToString() 'nuevo

               If IsNumeric(row("IdCobrador")) Then
                  .Cobrador = New Reglas.Empleados(da).GetUno(Integer.Parse(row("IdCobrador").ToString()))
               End If

               .CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Short.Parse(row("IdCategoriaFiscal").ToString()))
               .FormaPago = New Reglas.VentasFormasPago(da).GetUna(Integer.Parse(row("IdFormasPago").ToString()))
               .Observacion = row("Observacion").ToString()
               .Impresora = New Reglas.Impresoras(da)._GetUna(Integer.Parse(row("IdSucursal").ToString()), row("IdImpresora").ToString())
               .ImporteBruto = Decimal.Parse(row("ImporteBruto").ToString())
               .DescuentoRecargo = Decimal.Parse(row("DescuentoRecargo").ToString())
               .DescuentoRecargoPorc = Decimal.Parse(row("DescuentoRecargoPorc").ToString())
               .Subtotal = Decimal.Parse(row("SubTotal").ToString())
               .TotalImpuestos = Decimal.Parse(row("TotalImpuestos").ToString())
               .ImporteTotal = Decimal.Parse(row("ImporteTotal").ToString())

               If Not String.IsNullOrEmpty(row("IdEstadoComprobante").ToString()) Then
                  .IdEstadoComprobante = row("IdEstadoComprobante").ToString()
               End If

               'INVMUL: La información de invocado por sale de la colección de Invocadores
               'If Not String.IsNullOrEmpty(row("IdTipoComprobanteFact").ToString()) Then
               '   .TipoComprobanteFact = New Reglas.TiposComprobantes(da).GetUno(row("IdTipoComprobanteFact").ToString())
               '   .LetraFact = row("LetraFact").ToString()
               '   .CentroEmisorFact = Integer.Parse(row("CentroEmisorFact").ToString())
               '   .NumeroComprobanteFact = Long.Parse(row("NumeroComprobanteFact").ToString())
               'End If

               If Not String.IsNullOrEmpty(row("NumeroPlanilla").ToString()) Then
                  .IdCaja = Integer.Parse(row("IdCaja").ToString())
                  .NumeroPlanilla = Integer.Parse(row("NumeroPlanilla").ToString())
                  'Las Ventas de CtaCte tambien tiene Caja y Planilla pero no el Movimiento.
                  If Not String.IsNullOrEmpty(row("NumeroMovimiento").ToString()) Then
                     .NumeroMovimiento = Integer.Parse(row("NumeroMovimiento").ToString())
                  End If
               End If

               'agrego las tarjetas
               .Tarjetas = Me.GetVentasTarjetas(.IdSucursal,
                                                       .IdTipoComprobante,
                                                       .LetraComprobante,
                                                       .CentroEmisor,
                                                       .NumeroComprobante)

               .ImportePesos = Decimal.Parse(row("ImportePesos").ToString())
               .ImporteDolares = Decimal.Parse(row("ImporteDolares").ToString())
               .ImporteTickets = Decimal.Parse(row("ImporteTickets").ToString())
               '.ImporteTarjetas = Decimal.Parse(row(0)("ImporteTarjetas").ToString())
               '.ImporteCheques = Decimal.Parse(row(0)("ImporteCheques").ToString())
               .ImporteTransfBancaria = Decimal.Parse(row("ImporteTransfBancaria").ToString())

               If Not String.IsNullOrEmpty(row("IdCuentaBancaria").ToString()) Then
                  .CuentaBancariaTransfBanc = New Reglas.CuentasBancarias(da).GetUna(Integer.Parse(row("IdCuentaBancaria").ToString()))
               End If

               .Transferencias = New VentasTransferencias(da).GetTodos(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroComprobante)

               .Cheques = New Reglas.Cheques(da).GetPorComprobante(.IdSucursal, .TipoComprobante.IdTipoComprobante, .LetraComprobante, Short.Parse(.CentroEmisor.ToString()), numeroComprobante)

               .ChequesRechazados = New Reglas.Cheques(da).GetRechazadosPorComprobante(.IdSucursal, .TipoComprobante.IdTipoComprobante, .LetraComprobante, Short.Parse(.CentroEmisor.ToString()), numeroComprobante)

               If Not String.IsNullOrEmpty(row("Kilos").ToString()) Then
                  .Kilos = Decimal.Parse(row("Kilos").ToString())
               End If

               .Bultos = Integer.Parse(row("Bultos").ToString())
               .ValorDeclarado = Decimal.Parse(row("ValorDeclarado").ToString())

               If Not String.IsNullOrEmpty(row("IdTransportista").ToString()) Then
                  .Transportista = New Reglas.Transportistas(da).GetUno(Long.Parse(row("IdTransportista").ToString()))
               End If



               .NumeroLote = Long.Parse(row("NumeroLote").ToString())

               If .TipoComprobante.EsElectronico Then
                  .AFIPIdTipoComprobante = New SqlServer.AFIPTiposComprobantes(da).GetIdTipoComprobanteparaAFIP(.TipoComprobante.IdTipoComprobante, .LetraComprobante)
               End If

               If Not String.IsNullOrEmpty(row("CAE").ToString()) Then
                  .AFIPCAE.CAE = row("CAE").ToString()
                  .AFIPCAE.CAEVencimiento = Date.Parse(row("CAEVencimiento").ToString())
               End If

               .Utilidad = Decimal.Parse(row("Utilidad").ToString())

               If Not String.IsNullOrEmpty(row("FechaTransmisionAFIP").ToString()) Then
                  .FechaTransmisionAFIP = DateTime.Parse(row("FechaTransmisionAFIP").ToString())
               End If

               .CotizacionDolar = Decimal.Parse(row("CotizacionDolar").ToString())
               .IdMoneda = Integer.Parse(row("IdMoneda").ToString())

               If Not String.IsNullOrEmpty(row("IdProveedor").ToString()) Then
                  Dim blnIncluirFoto As Boolean = True
                  .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(row("IdProveedor").ToString()), blnIncluirFoto)
               End If

               .EsCtaOrden = row.Field(Of Boolean)("EsCtaOrden")

               'If Not String.IsNullOrEmpty(row(0)("IdPeriodo").ToString()) Then
               '   .Periodo = New Reglas.VentasPeriodos().GetUna(Integer.Parse(row(0)("IdPeriodo").ToString()))
               'End If

               '-.PE-32964.-
               If Not String.IsNullOrEmpty(row("FechaActualizacion").ToString()) Then
                  .FechaActualizacion = Date.Parse(row("FechaActualizacion").ToString())
               End If
               '-----------
               If Not String.IsNullOrEmpty(row("FechaEnvio").ToString()) Then
                  .FechaEnvio = Date.Parse(row("FechaEnvio").ToString())
               End If
               If Not String.IsNullOrEmpty(row("NumeroReparto").ToString()) Then
                  .NumeroReparto = Integer.Parse(row("NumeroReparto").ToString())
               End If
               If Not String.IsNullOrEmpty(row("FechaRendicion").ToString()) Then
                  .FechaRendicion = Date.Parse(row("FechaRendicion").ToString())
               End If

               If Not String.IsNullOrEmpty(row("MercDespachada").ToString()) Then
                  .MercDespachada = CBool(row("MercDespachada"))
               End If

               If Not String.IsNullOrEmpty(row("Direccion").ToString()) Then
                  .Direccion = row("Direccion").ToString()
                  '.LocalidadCliente = row(0)("LocalidadCliente").ToString()
                  '.ProvinciaCliente = row(0)("ProvinciaCliente").ToString()
                  .IdLocalidad = Integer.Parse(row("IdLocalidad").ToString())
                  .Localidad = New Reglas.Localidades(da).GetUna(Integer.Parse(row("IdLocalidad").ToString()))
               End If

               If Not IsDBNull(row("IdEjercicio")) Then
                  .IdEjercicio = Integer.Parse(row("IdEjercicio").ToString())
               End If

               If Not IsDBNull(row("IdPlanCuenta")) Then
                  .IdPlanCuenta = Integer.Parse(row("IdPlanCuenta").ToString())
               End If

               If Not IsDBNull(row("IdAsiento")) Then
                  .IdAsiento = Integer.Parse(row("IdAsiento").ToString())
               End If

               .IdCategoria = Integer.Parse(row("IdCategoria").ToString())
               .ComisionVendedor = Decimal.Parse(row("ComisionVendedor").ToString())

               If Not String.IsNullOrWhiteSpace(row("SaldoActualCtaCte").ToString()) Then
                  .SaldoActualCtaCte = Decimal.Parse(row("SaldoActualCtaCte").ToString())
               End If
               .SaldoActualCtaCteUnificado = row.Field(Of Decimal?)("SaldoActualCtaCteUnificado")

               If Not String.IsNullOrEmpty(row("CodigoErrorAfip").ToString()) Then
                  .CodigoErrorAfip = row("CodigoErrorAfip").ToString()
               End If

               If Not String.IsNullOrWhiteSpace(row("NumeroOrdenCompra").ToString()) Then
                  .NumeroOrdenCompra = Long.Parse(row("NumeroOrdenCompra").ToString())
               End If
               If Not String.IsNullOrWhiteSpace(row("IdActividad").ToString()) Then
                  .IdActividad = Integer.Parse(row("IdActividad").ToString())
               End If
               'Solo Lectura
               '.TotalImpuestoInterno = Decimal.Parse(row(0)("ImporteImpuestoInterno").ToString())
               .NombreCliente = row("NombreCliente").ToString()
               If Not String.IsNullOrWhiteSpace(row("Cuit").ToString()) Then
                  .Cuit = row("Cuit").ToString()
               Else
                  .Cuit = ""
               End If
               If Not String.IsNullOrWhiteSpace(row("NroDocCliente").ToString()) Then
                  .TipoDocCliente = row("TipoDocCliente").ToString()
                  .NroDocCliente = Long.Parse(row("NroDocCliente").ToString())
               Else
                  .TipoDocCliente = ""
                  .NroDocCliente = 0
               End If

               '# Tipo de Documento según AFIP (Lógica copiada de FE para tener a mano los campos en la Venta)
               '------------------------------------------------------------------------------------
               If .CategoriaFiscal.SolicitaCUIT Then
                  If .Cuit.Replace("-", "").Trim().Length <> 0 Then
                     'Código de documento identificatorio
                     .IdAFIPTipoDocCliente = New Reglas.AFIPTiposDocumentos(da).GetIdTipoDocparaAFIP(Entidades.TipoDocumento.TiposDocumentos.CUIT.ToString(), AccionesSiNoExisteRegistro.Nulo)
                     'Nro. de identificación 
                     .AFIPNroDocCliente = Long.Parse(.Cuit.Replace("-", ""))
                  ElseIf .Cliente.Cuit.Replace("-", "").Trim().Length <> 0 Then
                     'Código de documento identificatorio
                     .IdAFIPTipoDocCliente = New Reglas.AFIPTiposDocumentos(da).GetIdTipoDocparaAFIP(Entidades.TipoDocumento.TiposDocumentos.CUIT.ToString(), AccionesSiNoExisteRegistro.Nulo)
                     'Nro. de identificación 
                     .AFIPNroDocCliente = Long.Parse(.Cliente.Cuit.Replace("-", ""))
                  Else
                     'Throw New Exception("El nro. de CUIT no esta cargado")
                  End If
               Else
                  If .NroDocCliente > 0 Then
                     'Código de documento identificatorio del comprador
                     .IdAFIPTipoDocCliente = New Reglas.AFIPTiposDocumentos(da).GetIdTipoDocparaAFIP(.TipoDocCliente, AccionesSiNoExisteRegistro.Nulo)
                     'Nro. de identificación del comprador
                     .AFIPNroDocCliente = .NroDocCliente
                  ElseIf .Cliente.NroDocCliente > 0 Then
                     'Código de documento identificatorio del comprador
                     .IdAFIPTipoDocCliente = New Reglas.AFIPTiposDocumentos(da).GetIdTipoDocparaAFIP(.Cliente.TipoDocCliente, AccionesSiNoExisteRegistro.Nulo)
                     'Nro. de identificación del comprador
                     .AFIPNroDocCliente = .Cliente.NroDocCliente
                  Else
                     If .Cuit.Replace("-", "").Length > 0 Then
                        'Código de documento identificatorio del comprador
                        .IdAFIPTipoDocCliente = New Reglas.AFIPTiposDocumentos(da).GetIdTipoDocparaAFIP(Entidades.TipoDocumento.TiposDocumentos.CUIT.ToString(), AccionesSiNoExisteRegistro.Nulo)
                        'Nro. de identificación del comprador
                        .AFIPNroDocCliente = Long.Parse(.Cuit.Replace("-", ""))
                        '---------
                     ElseIf .Cliente.Cuit.Replace("-", "").Length > 0 Then
                        'Código de documento identificatorio del comprador
                        .IdAFIPTipoDocCliente = New Reglas.AFIPTiposDocumentos(da).GetIdTipoDocparaAFIP(Entidades.TipoDocumento.TiposDocumentos.CUIT.ToString(), AccionesSiNoExisteRegistro.Nulo)
                        'Nro. de identificación del comprador
                        .AFIPNroDocCliente = Long.Parse(.Cliente.Cuit.Replace("-", ""))
                        '---------
                     Else
                        'Código de documento identificatorio del comprador
                        .IdAFIPTipoDocCliente = 99
                        'Nro. de identificación del comprador
                        .AFIPNroDocCliente = 0
                     End If
                  End If
               End If
               '------------------------------------------------------------------------------------

               .Palets = Integer.Parse(row("Palets").ToString())
               .Cbu = row("Cbu").ToString()
               .CbuAlias = row("CbuAlias").ToString()
               .ReferenciaComercial = row("ReferenciaComercial").ToString()
               If Not String.IsNullOrWhiteSpace(row("AnulacionFCE").ToString()) Then
                  .AnulacionFCE = Boolean.Parse(row("AnulacionFCE").ToString())
               End If
               .NroVersionAplicacion = row("NroVersionAplicacion").ToString()
               .DescuentoRecargoPorcManual = row.Field(Of Boolean)(Entidades.Venta.Columnas.DescuentoRecargoPorcManual.ToString())
               .FechaExportacion = row.Field(Of Date?)(Entidades.Venta.Columnas.FechaExportacion.ToString())

               '# Obtener el detalle del service facturado en caso que corresponda
               .CrmInvocados = New Reglas.CRMNovedades(da).ObtenerServiciosFacturados(.IdSucursal, .IdTipoComprobante, .LetraComprobante, .CentroEmisor, .NumeroComprobante)

               '# Star Medical Historia Clínica
               .IdPaciente = row.Field(Of Long?)(Entidades.Venta.Columnas.IdPaciente.ToString())
               .IdDoctor = row.Field(Of Long?)(Entidades.Venta.Columnas.IdDoctor.ToString())
               .FechaCirugia = row.Field(Of DateTime?)(Entidades.Venta.Columnas.FechaCirugia.ToString())
               .IdAFIPReferenciaTransferencia = row.Field(Of String)(Entidades.Venta.Columnas.IdAFIPReferenciaTransferencia.ToString())
               '--------------------------------

               '-- REG-31198.- -----------------
               .IdIcotermExportacion = row.Field(Of String)(Entidades.Venta.Columnas.IdIcotermExportacion.ToString())
               .IdDestinoExportacion = row.Field(Of String)(Entidades.Venta.Columnas.IdDestinoExportacion.ToString())
               If Not String.IsNullOrWhiteSpace(row("EsFacturaExportacion").ToString()) Then
                  .EsFacturaExportacion = row.Field(Of Boolean)("EsFacturaExportacion")
               End If
               .FechaPagoExportacion = row.Field(Of Date?)("FechaPagoExportacion")

               '-- REG-32762.- -----------------
               .IdEmbarcacion = row.Field(Of Long?)("IdEmbarcacion").IfNull()
               If Not String.IsNullOrWhiteSpace(row("IdCategoriaEmbarcacion").ToString()) Then
                  .IdCategoriaEmbarcacion = row.Field(Of Integer)(Entidades.Venta.Columnas.IdCategoriaEmbarcacion.ToString())
                  .NombreCategoriaEmbarcacion = row.Field(Of String)(Entidades.Venta.Columnas.NombreCategoriaEmbarcacion.ToString())
               End If
               '-- REG-36331.- ----------------------------------------------------------------------------------------
               .IdCama = row.Field(Of Long?)(Entidades.Venta.Columnas.IdCama.ToString()).IfNull()
               .CodigoCama = row.Field(Of String)(Entidades.Venta.Columnas.CodigoCama.ToString())
               If Not String.IsNullOrWhiteSpace(row("IdNave").ToString()) Then
                  .IdNave = row.Field(Of Short)(Entidades.Venta.Columnas.IdNave.ToString())
                  .NombreNave = row.Field(Of String)(Entidades.Venta.Columnas.NombreNave.ToString())
               End If
               If Not String.IsNullOrWhiteSpace(row("IdCategoriaCama").ToString()) Then
                  .IdCategoriaCama = row.Field(Of Integer)(Entidades.Venta.Columnas.IdCategoriaCama.ToString())
                  .NombreCategoriaCama = row.Field(Of String)(Entidades.Venta.Columnas.NombreCategoriaCama.ToString())
               End If
               '-------------------------------------------------------------------------------------------------------

               '-- Agrego los Permisos de Embarques.- --
               .ExportacionEmbarques = Me.GetVentasDespachos(.IdSucursal,
                                                             .IdTipoComprobante,
                                                             .LetraComprobante,
                                                             .CentroEmisor,
                                                             .NumeroComprobante)
               '--------------------------------
               .NombreTransportistaTransporte = row.Field(Of String)("NombreTransportistaTransporte")
               .VehiculoTransporte = New Reglas.Vehiculos(da).GetUno(row.Field(Of String)(Entidades.Venta.Columnas.PatenteVehiculoTransporte.ToString()))

               .ConceptoCM05 = New AFIPConceptosCM05(da).GetUno(row.Field(Of Integer?)("IdConceptoCM05").IfNull(), AccionesSiNoExisteRegistro.Nulo)

               .IdTipoComprobanteInvocacionMasiva = row.Field(Of String)("IdTipoComprobanteInvocacionMasiva")
               '-----------------------------------------------
               If Not String.IsNullOrWhiteSpace(row("NroFacturaProveedor").ToString()) Then
                  .NroFacturaProveedor = row("NroFacturaProveedor").ToString()
               End If
               If Not String.IsNullOrWhiteSpace(row("NroRemitoProveedor").ToString()) Then
                  .NroRemitoProveedor = row("NroRemitoProveedor").ToString()
               End If
               '-----------------------------------------------
               .IdDomicilio = row.Field(Of Integer?)("IdDomicilio")
            End With

            venta.VentasProductos = New VentasProductos(da, _cache).GetTodos(venta.IdSucursal,
                                                                             venta.IdTipoComprobante,
                                                                             venta.LetraComprobante,
                                                                             venta.CentroEmisor,
                                                                             venta.NumeroComprobante)

            Dim totalKilosItems As Reglas.Ventas.TotalKilosItems = CalculaTotalKilosItems(venta.VentasProductos)
            venta.CantidadProductos = totalKilosItems.TotalProductos

            Dim rVV = New Reglas.VentasInvocados(da)
            venta.Invocadores = rVV.GetInvocadores(venta)

            venta.Invocados = rVV.GetInvocados(venta)
            venta.Invocados.VentaInvocadora = venta

            '''''Detalle de Invocados
            ''''Dim dtInvocados As DataTable
            ''''dtInvocados = Me.GetInvocados(venta.IdSucursal, venta.TipoComprobante.IdTipoComprobante,
            ''''                              venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)

            ''''If dtInvocados.Rows.Count > 0 Then

            ''''   'Dim ComprobantesInvocados As List(Of Entidades.Venta) = New List(Of Entidades.Venta)

            ''''Dim oComprobanteInvocado As Entidades.Venta

            ''''   For Each dr As DataRow In dtInvocados.Rows

            ''''oComprobanteInvocado = New Entidades.Venta

            ''''      With oComprobanteInvocado
            ''''         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
            ''''         .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr("IdTipoComprobante").ToString())
            ''''         .LetraComprobante = dr("Letra").ToString()
            ''''         .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
            ''''         .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
            ''''         .Cuit = dr("Cuit").ToString()
            ''''         .Fecha = dr.ValorDateTimePorDefecto("Fecha", Nothing)
            ''''      End With

            ''''      venta.Facturables.Add(oComprobanteInvocado)

            ''''   Next

            ''''   venta.CantidadInvocados = dtInvocados.Rows.Count

            ''''End If


            'Observaciones
            With stb
               .Length = 0
               .AppendLine("SELECT VO.IdSucursal")
               .AppendLine("      ,VO.IdTipoComprobante")
               .AppendLine("      ,VO.Letra")
               .AppendLine("      ,VO.CentroEmisor")
               .AppendLine("      ,VO.NumeroComprobante")
               .AppendLine("      ,VO.Linea")
               .AppendLine("      ,VO.Observacion")
               .AppendLine("      ,VO.IdTipoObservacion")
               .AppendLine("      ,TOB.Descripcion")
               .AppendLine("  FROM VentasObservaciones VO")
               .AppendLine("  INNER JOIN TiposObservaciones as TOB ON VO.IdTipoObservacion = TOB.IdObservaciones")
               .AppendLine(" WHERE VO.IdSucursal = " & idSucursal.ToString())
               .AppendLine("   AND VO.IdTipoComprobante = '" & idTipoComprobante & "'")
               .AppendLine("   AND VO.Letra = '" & letra & "'")
               .AppendLine("   AND VO.CentroEmisor = " & centroEmisor.ToString())
               .AppendLine("   AND VO.NumeroComprobante = " & numeroComprobante.ToString())
               .AppendLine(" ORDER BY VO.Linea")
            End With

            Dim dtObs As DataTable = Me.da.GetDataTable(stb.ToString())
            Dim oVO As Entidades.VentaObservacion

            For Each dr As DataRow In dtObs.Rows
               oVO = New Entidades.VentaObservacion()
               With oVO
                  .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
                  .IdTipoComprobante = dr("IdTipoComprobante").ToString()
                  .Letra = dr("Letra").ToString()
                  .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
                  .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
                  .Linea = Integer.Parse(dr("Linea").ToString())
                  .Observacion = dr("Observacion").ToString()
                  .IdTipoObservacion = Short.Parse(dr("IdTipoObservacion").ToString())
                  .DescripcionTipoObservacion = dr("Descripcion").ToString()
               End With
               venta.VentasObservaciones.Add(oVO)
            Next

            'Impuestos (IVA, Retenciones, otros)
            Dim vi = New VentasImpuestos(da).GetTodos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

            'IVA + Impuestos Internos
            venta.VentasImpuestos.AddRange(vi.Where(Function(x) x.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA Or x.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT))
            'Percepciones, Otros
            venta.ImpuestosVarios.AddRange(vi.Where(Function(x) Not (x.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA Or x.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT)))

            'Lotes
            With stb
               .Length = 0
               .AppendLine("SELECT VPL.IdSucursal")
               .AppendLine("      ,VPL.IdTipoComprobante")
               .AppendLine("      ,VPL.Letra")
               .AppendLine("      ,VPL.CentroEmisor")
               .AppendLine("      ,VPL.NumeroComprobante")

               .AppendLine("      ,VPL.Orden")

               .AppendLine("      ,VPL.IdProducto")
               .AppendLine("      ,VPL.IdLote")
               .AppendLine("      ,VPL.FechaVencimiento")
               .AppendLine("      ,VPL.Cantidad")
               .AppendLine("  FROM VentasProductosLotes VPL")
               .AppendLine(" WHERE VPL.IdSucursal = " & idSucursal.ToString())
               .AppendLine("   AND VPL.IdTipoComprobante = '" & idTipoComprobante & "'")
               .AppendLine("   AND VPL.Letra = '" & letra & "'")
               .AppendLine("   AND VPL.CentroEmisor = " & centroEmisor.ToString())
               .AppendLine("   AND VPL.NumeroComprobante = " & numeroComprobante.ToString())
               .AppendLine(" ORDER BY VPL.IdProducto, VPL.IdLote")
            End With

            Dim dtVPL As DataTable = Me.da.GetDataTable(stb.ToString())
            Dim oVPL As Entidades.VentaProductoLote

            For Each dr As DataRow In dtVPL.Rows
               oVPL = New Entidades.VentaProductoLote()
               With oVPL
                  .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
                  .TipoComprobante = dr("IdTipoComprobante").ToString()
                  .Letra = dr("Letra").ToString()
                  .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
                  .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
                  .Orden = Integer.Parse(dr("Orden").ToString())
                  .Producto = New Reglas.Productos(da).GetUno(dr("IdProducto").ToString())
                  .IdLote = dr("IdLote").ToString()
                  If Not String.IsNullOrWhiteSpace(dr("FechaVencimiento").ToString()) Then
                     .FechaVencimiento = Date.Parse(dr("FechaVencimiento").ToString())
                  Else
                     .FechaVencimiento = Nothing
                  End If
                  .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
               End With
               venta.VentasProductosLotes.Add(oVPL)
            Next

            'Cargo la CTACTE si son Pre-Comprobantes, que no tienen imputacion.
            'TODO: Cuando haga falta... ver la logica para todos
            'Puede estar facturado a CtaCte y No Afectar CtaCte (solo a los fines fiscales).

            If venta.FormaPago.Dias > 0 And venta.TipoComprobante.ActualizaCtaCte And venta.IdEstadoComprobante <> "ANULADO" Then
               venta.CuentaCorriente = New Reglas.CuentasCorrientes(da)._GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, AccionesSiNoExisteRegistro.Nulo)
            End If

            'Cargo las percepciones 
            'If venta.Cliente.InscriptoIBStaFe Then
            If venta.Percepciones IsNot Nothing Then
               venta.Percepciones = New Reglas.PercepcionVentas(da).GetPorVentasPercepciones(venta.IdSucursal,
                                                                              venta.TipoComprobante.IdTipoComprobante,
                                                                              venta.LetraComprobante,
                                                                              venta.CentroEmisor,
                                                                              venta.NumeroComprobante,
                                                                              venta.Cliente.IdCliente)
            End If
            'End If

            venta.VentasContactos = New Reglas.VentasClientesContactos(da).GetTodos(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)

         Else
            Throw New Exception(String.Format("No existe el Comprobante de Venta {0} {1} {2} {3:0000}-{4:00000000}.", idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante))
         End If

         Return venta
      Finally
         'If blnAbreConexion Then da.CloseConection()
      End Try

   End Function
   Public Function Get1(idSucursal As Integer,
                        idTipoComprobante As String,
                        letra As String,
                        centroEmisor As Short,
                        numeroComprobante As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormat("SELECT V.*").AppendLine()
         .AppendFormat("  FROM Ventas V").AppendLine()
         .AppendFormat(" WHERE V.IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND V.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND V.Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND V.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND V.NumeroComprobante = {0}", numeroComprobante).AppendLine()
      End With

      Return Me.da.GetDataTable(stb.ToString())
   End Function


   Public Function ClientePoseeFacturas(idCliente As Long) As Boolean
      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
      Dim existeTC As Boolean = sql.ClientePoseeFacturas(idCliente)
      Return existeTC
   End Function
   Public Function GetUltimaVentaCliente(idSucursal As Integer,
                                         desde As Date,
                                         hasta As Date,
                                         idCliente As Long,
                                         tipoComprobante As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine(" SELECT MAX(V.Fecha) AS Fecha ")
         .AppendLine("      , V.IdCliente")
         .AppendLine("      , C.NombreCliente ")
         .AppendLine("      , C.CodigoCliente")
         .AppendLine("      , C.Telefono")
         .AppendLine("      , C.Direccion")
         .AppendLine("      , C.CorreoElectronico")
         .AppendLine("      , C.CorreoAdministrativo")
         .AppendLine("      , C.Celular")
         .AppendLine("  FROM Ventas V")
         .AppendLine("  LEFT JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal=CF.IdCategoriaFiscal")
         .AppendLine("  LEFT JOIN Impresoras I ON V.CentroEmisor = I.CentroEmisor ")
         .AppendLine("  LEFT JOIN TiposComprobantes TC ON  V.IdTipoComprobante=TC.IdTipoComprobante ")
         .AppendLine("  LEFT JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("  LEFT JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("  LEFT JOIN Empleados E ON V.IdVendedor = E.IdEmpleado ")

         .AppendFormatLine(" WHERE V.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("	 AND V.Fecha >= '{0}'", desde.Date.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormatLine("	 AND V.Fecha <= '{0}'", hasta.UltimoSegundoDelDia().ToString("yyyyMMdd HH:mm:ss"))

         If idCliente <> 0 Then
            .AppendFormatLine("	 AND C.IdCliente = {0}", idCliente)
         End If

         If Not String.IsNullOrEmpty(tipoComprobante) Then
            .AppendFormatLine("	 AND V.IdTipoComprobante = '{0}'", tipoComprobante)
         End If

         .AppendLine(" GROUP BY V.IdCliente ,C.NombreCliente, C.CodigoCliente,C.Telefono,C.Direccion,C.CorreoElectronico,C.CorreoAdministrativo,C.Celular")
         .AppendLine(" ORDER BY C.NombreCliente")

      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function Existe(v As Entidades.IVentaInvocada) As Boolean
      Return Existe(v.IdSucursal, v.IdTipoComprobante, v.Letra, v.CentroEmisor.ToShort(), v.NumeroComprobante)
   End Function

   Public Function Existe(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As Boolean
      Dim sql = New SqlServer.Ventas(da)
      Dim sqlC = New SqlServer.Compras(da)
      Dim existeTC As Boolean = sql.Existe(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

      'Si no existe el comprobante a grabar
      If Not existeTC Then
         'Busco numeradores relacionados a este numerador.
         'Por ejemplo NDEBCHEQRECH puede estar relacionado a FACT,NCRED,NDEB y debería controlar que no se haya generado
         'un comprobante también con esos tipos de comprobante
         Dim dtTC As DataTable = New SqlServer.VentasNumeros(da).VentasNumeros_G1(actual.Sucursal.IdEmpresa, idTipoComprobante, letra, centroEmisor)
         If dtTC.Rows.Count > 0 Then
            For Each idTipoComprobanteRelacionado As String In dtTC(0)("IdTipoComprobanteRelacionado").ToString().Split(","c)
               'Para cada tipo de comprobante relacionado (si no está en blanco) verifico si existe o no en ventas
               If Not String.IsNullOrWhiteSpace(idTipoComprobanteRelacionado) Then
                  existeTC = sql.Existe(idSucursal, idTipoComprobanteRelacionado, letra, centroEmisor, numeroComprobante)
                  'Si lo encontré con este tipo de comprobante relacionado salgo 
                  'del FOR para que no me cambie el valor si hay otro relacionado.
                  If existeTC Then Exit For
                  'Busco con IdProveedor = 0 porque es un comprobante con numerador unificado entre ventas y compras
                  existeTC = sqlC.Existe(idSucursal, 0, idTipoComprobanteRelacionado, letra, centroEmisor, numeroComprobante)
                  If existeTC Then Exit For
               End If
            Next
         End If
      End If

      Return existeTC
   End Function

   Public Function ExisteCtaCte(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Short,
                          numeroComprobante As Long) As Boolean

      Try
         'Me.da.OpenConection()

         Dim sql As SqlServer.CuentasCorrientes = New SqlServer.CuentasCorrientes(da)

         Return sql.Existe(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

      Catch ex As Exception
         Throw
         'Finally
         'Me.da.CloseConection()
      End Try

   End Function

   Private Sub AplicarSigno(ByRef oVentas As Entidades.Venta)

      Dim srtCatFiscalEmp As Short = Publicos.CategoriaFiscalEmpresa  ' Short.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.CATEGORIAFISCALEMPRESA))
      Dim CategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(srtCatFiscalEmp)

      'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
      Dim coe As Integer = oVentas.TipoComprobante.CoeficienteValores

      oVentas.ImporteBruto = oVentas.ImporteBruto * coe
      oVentas.DescuentoRecargo = oVentas.DescuentoRecargo * coe
      'oVentas.DescuentoRecargoPorc = oVentas.DescuentoRecargoPorc * coe
      oVentas.Subtotal = oVentas.Subtotal * coe
      oVentas.TotalImpuestos = oVentas.TotalImpuestos * coe
      oVentas.ImporteTotal = oVentas.ImporteTotal * coe

      oVentas.ImportePesos = oVentas.ImportePesos * coe
      oVentas.ImporteDolares = oVentas.ImporteDolares * coe
      oVentas.ImporteTickets = oVentas.ImporteTickets * coe
      ' oVentas.ImporteTarjetas = oVentas.ImporteTarjetas * coe
      For Each tr As Entidades.VentaTarjeta In oVentas.Tarjetas
         tr.Monto = tr.Monto * coe
      Next

      oVentas.Kilos = oVentas.Kilos * coe

      oVentas.Utilidad = oVentas.Utilidad * coe


      'Ajusto el Detalle
      Dim oVenProd As Reglas.VentasProductos = New Reglas.VentasProductos(da)

      For Each Prod As Entidades.VentaProducto In oVentas.VentasProductos

         'If Not CategoriaFiscalEmpresa.IvaDiscriminado Or Not oVentas.CategoriaFiscal.IvaDiscriminado Then
         '   Prod.Precio = Decimal.Round(Prod.Precio / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
         '   Prod.DescuentoRecargo = Decimal.Round(Prod.DescuentoRecargo / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
         '   Prod.DescRecGeneral = Decimal.Round(Prod.DescRecGeneral / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
         '   Prod.ImporteTotal = Decimal.Round(Prod.ImporteTotal / (1 + (Prod.AlicuotaImpuesto / 100)), 2)
         'End If

         Prod.Cantidad = Prod.Cantidad * coe

         Prod.ImporteImpuesto = Prod.ImporteImpuesto * coe
         Prod.Utilidad = Prod.Utilidad * coe
         Prod.ImporteTotal = Prod.ImporteTotal * coe
         Prod.ImporteTotalNeto = Prod.ImporteTotalNeto * coe
         Prod.ImporteImpuestoInterno = Prod.ImporteImpuestoInterno * coe

         Prod.Kilos = Prod.Kilos * coe

         Prod.VentasProductosLotes.ForEachSecure(Sub(vpl) vpl.Cantidad *= coe)

      Next


      'Ajusto los impuestos de ventas (IVA)
      Dim ventImpu As Reglas.VentasImpuestos = New Reglas.VentasImpuestos(da)
      For Each vi As Entidades.VentaImpuesto In oVentas.VentasImpuestos
         vi.Bruto = vi.Bruto * coe
         vi.Neto = vi.Neto * coe
         vi.Importe = vi.Importe * coe
         vi.Total = vi.Total * coe
         'ventImpu._Insertar(vi)
      Next

      'Ajusto los Otros impuestos de ventas (Percepciones)
      For Each vi As Entidades.VentaImpuesto In oVentas.ImpuestosVarios
         vi.Bruto = vi.Bruto * coe
         vi.Neto = vi.Neto * coe
         vi.Importe = vi.Importe * coe
         vi.Total = vi.Total * coe
         'ventImpu._Insertar(vi)
      Next

      'Ajusto la Cuenta Corriente

      If oVentas.CuentaCorriente IsNot Nothing Then

         With oVentas.CuentaCorriente
            .ImportePesos = .ImportePesos * coe
            .ImporteTarjetas = .ImporteTarjetas * coe
            .ImporteTickets = .ImporteTickets * coe
            .ImporteTransfBancaria = .ImporteTransfBancaria * coe
            .ImporteDolares = .ImporteDolares * coe
            .ImporteCheques = .ImporteCheques * coe
            'Lamentablmente viene invertido y no es momento de 
            '.ImporteTotal = .ImporteTotal * coe
         End With

         'Viene Invertido.. ver!!!
         'For Each cc As Entidades.CuentaCorrientePago In oVentas.CuentaCorriente.Pagos
         '   cc.ImporteCuota = cc.ImporteCuota * coe
         '   cc.SaldoCuota = cc.SaldoCuota * coe
         'Next

      End If

   End Sub

   '#######################################################
   '# Información para Código QR de Facturas Electrónicas #
   '#######################################################
   Public Function GetInfoCodigoQR(fecha As DateTime,
                                   cuit As Long,
                                   centroEmisor As Short,
                                   tipoComprobanteAFIP As Integer,
                                   nroComprobante As Long,
                                   importe As Decimal,
                                   moneda As Integer,
                                   cotizacion As Decimal,
                                   tipoDocReceptor As Integer,
                                   nroDocReceptor As Long,
                                   tipoCodigoAutorizacion As String,
                                   codAutorizacion As String) As String

      '########################################################################################
      '# Link a especificaciones técnicas: https://www.afip.gob.ar/fe/qr/especificaciones.asp #
      '#                                     Versión 1 QR                                     #
      '########################################################################################

      '########################################################################################
      '# El código QR deberá codificar el siguiente texto:                                    #
      '#    {URL}?p={DATOS_CMP_BASE_64}                                                       #
      '# Donde:                                                                               #
      '#    {URL} = "https://www.afip.gob.ar/fe/qr/"                                          #
      '#    {DATOS_CMP_BASE_64} = JSON con datos del comprobante codificado en Base64         #
      '########################################################################################

      Dim versionQR As Integer = 1
      Dim url As String = Reglas.Publicos.AFIPURLCodigoQR

      Dim DATOS_CMP_BASE_64 = New With {.ver = versionQR,
                                        .fecha = fecha.ToString("yyyy-MM-dd"),
                                        .cuit = cuit,
                                        .ptoVta = centroEmisor,
                                        .tipoCmp = tipoComprobanteAFIP,
                                        .nroCmp = nroComprobante,
                                        .importe = (Math.Truncate(importe * 100) / 100),
                                        .moneda = If(moneda = Entidades.Moneda.Peso, "PES", "DOL"),
                                        .ctz = If(moneda = Entidades.Moneda.Peso, 1, cotizacion),
                                        .tipoDocRec = tipoDocReceptor,
                                        .nroDocRec = nroDocReceptor,
                                        .tipoCodAut = tipoCodigoAutorizacion,
                                        .codAut = Long.Parse(codAutorizacion)}

      Return String.Format("{0}?p={1}", url, New JavaScriptSerializer().Serialize(DATOS_CMP_BASE_64).ConvertToBase64String())
   End Function

   '# Para alerta de Remitos sin facturar
   Public Function GetRemitosSinFacturar(sucursales As List(Of Entidades.Sucursal)) As DataTable
      Return New SqlServer.Ventas(da).GetRemitosSinFacturar(sucursales)
   End Function

   Public Function ClientePoseeFacturas(idCliente As Long, grabaLibro As Boolean?) As Boolean
      Return New SqlServer.Ventas(da).ClientePoseeFacturas(idCliente)
   End Function

   '-- REQ-43864.- ----------------------------------------------------
   Public Sub GeneracionDatosRoelaSirplus(oVentas As Entidades.Venta)
      If oVentas.CuentaCorriente.Pagos.Count > 0 Then
         If oVentas.CuentaCorriente.Pagos(0).ImporteCuota2 Is Nothing Then
            Dim intereses = New Reglas.Intereses(da).GetUno(New Reglas.Categorias(da).GetUno(oVentas.Cliente.IdCategoria).IdInteres)
            Dim rFeriados = New Feriados(da)
            Dim eEmple = New Reglas.Empleados().GetUno(oVentas.Cliente.Cobrador.IdEmpleado)

            For Each ctactepag In oVentas.CuentaCorriente.Pagos
               If eEmple.EntidadCobranza <> Entidades.Empleado.TipoEntidadCobranza.NINGUNO.ToString() Then

                  ctactepag.FechaVencimiento = rFeriados.BuscaSiguienteDiaHabil(ctactepag.FechaVencimiento, intereses)

                  If intereses.InteresesDias.Count > 0 Then
                     ctactepag.FechaVencimiento2 = ctactepag.FechaVencimiento.AddDays(intereses.InteresesDias(0).DiasDesde)
                     ctactepag.FechaVencimiento2 = rFeriados.BuscaSiguienteDiaHabil(ctactepag.FechaVencimiento2, intereses)
                     ctactepag.ImporteCuota2 = ctactepag.ImporteCuota * (1 + (intereses.InteresesDias(0).Interes) / 100)

                     If intereses.InteresesDias.Count > 1 Then
                        ctactepag.FechaVencimiento3 = ctactepag.FechaVencimiento.AddDays(intereses.InteresesDias(1).DiasDesde)
                        ctactepag.FechaVencimiento3 = rFeriados.BuscaSiguienteDiaHabil(ctactepag.FechaVencimiento3, intereses)
                        ctactepag.ImporteCuota3 = ctactepag.ImporteCuota * (1 + (intereses.InteresesDias(1).Interes) / 100)
                     End If
                     If eEmple.EntidadCobranza = Entidades.Empleado.TipoEntidadCobranza.ROELA.ToString() AndAlso oVentas.CuentaCorriente.Pagos(0).CodigoDeBarra Is Nothing Then
                        ctactepag.CodigoDeBarra = Banco.DebitosDirectos.RoelaSiro.ArmarCodigoBarras(
                                          oVentas.Cliente.CodigoCliente,
                                          Publicos.TurismoRoelaIdentificadorConcepto, ctactepag.FechaVencimiento,
                                          ctactepag.ImporteCuota, ctactepag.FechaVencimiento2, ctactepag.ImporteCuota2,
                                          ctactepag.FechaVencimiento3, ctactepag.ImporteCuota3, Publicos.TurismoRoelaIdentificadorCuenta)
                     End If
                  End If
               End If
            Next
         End If
      End If
   End Sub
   Public Sub ActualizaCodigoDeBarraSirplus(oVentas As Entidades.Venta)
      Dim rCtaCtePagos = New Reglas.CuentasCorrientesPagos(da)
      rCtaCtePagos.ActualizaCodigoDeBarraSirplus(oVentas.IdSucursal, oVentas.IdTipoComprobante, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante)
   End Sub
   Public Sub ActualizaDatosCodigoBarraSirplusVentas(oVentas As Entidades.Venta)
      Dim sql = New SqlServer.Ventas(da)
      sql.U_DatosRoelaSirplusVentas(oVentas.IdSucursal,
                                    oVentas.IdTipoComprobante,
                                    oVentas.LetraComprobante,
                                    oVentas.CentroEmisor,
                                    oVentas.NumeroComprobante, oVentas.CuentaCorriente.Pagos(0))
   End Sub
   '--------------------------------------------------------------------
#End Region

#Region "Metodos Despachos"
   Public Sub ActualizaDespachoMercaderia(idSucursal As Integer,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Integer,
                                          numeroComprobante As Long,
                                          mercDespachada As Boolean?)
      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

      sql.ActualizarDespachaMercaderia(idSucursal,
                                       idTipoComprobante,
                                       letra,
                                       centroEmisor,
                                       numeroComprobante,
                                       mercDespachada)

   End Sub

#End Region

#Region "Actualizar CAE"
   Public Sub ActualizarNumerosVentas(IdSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Short, numeroAActualizar As Long, fecha As Date)
      Dim oVN As Entidades.VentaNumero = New Entidades.VentaNumero()
      Dim oVNRe As Reglas.VentasNumeros = New Reglas.VentasNumeros(da)

      With oVN
         .IdTipoComprobante = idTipoComprobante
         .LetraFiscal = letraFiscal
         .CentroEmisor = emisor
         .IdSucursal = IdSucursal
         .Numero = numeroAActualizar
         .Fecha = fecha
      End With

      oVNRe.ActualizarNumero(oVN)

   End Sub
   Public Sub ActualizarCAE(oVentas As Entidades.Venta, secuencia As Entidades.AFIPCAE.Secuencia,
                            metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)
      EjecutaConTransaccion(
      Sub()
         Dim pkComprobanteAnterior = New Entidades.PKComprobante(oVentas)
         Try
            ActualizaCAE(oVentas, secuencia, metodoGrabacion, idFuncion)
         Catch
            oVentas.IdSucursal = ComprobanteAnt.IdSucursal
            oVentas.TipoComprobante = ComprobanteAnt.TipoComprobante
            oVentas.LetraComprobante = ComprobanteAnt.LetraComprobante
            oVentas.CentroEmisor = ComprobanteAnt.CentroEmisor
            oVentas.NumeroComprobante = ComprobanteAnt.NumeroComprobante
            Throw
         End Try
      End Sub)
   End Sub
   Public Function EsCorrectoElUltimoNumeroDeAFIP(idSucursal As Integer,
                                                  idTipoComprobante As String,
                                                  letraComprobante As String,
                                                  centroEmisor As Short) As Boolean
      Dim ultimoNroLocal As Long
      Dim oVentasNumeros As New Reglas.VentasNumeros()

      'cambio el tipo de comprobante para que sea el que real y no el ficticio
      'IdTipoComprobante = IIf(IdTipoComprobante = "ePRE-FACT", "eFACT", "eNCRED").ToString()

      ' IdTipoComprobante = IIf(IdTipoComprobante = "ePRE-FACT", "eFACT", IIf(IdTipoComprobante = "ePRE-NCRED", "eNCRED", "eNDEB")).ToString()

      idTipoComprobante = New Reglas.TiposComprobantes().GetUno(idTipoComprobante).IdTipoComprobanteSecundario

      ultimoNroLocal = oVentasNumeros.GetProximoNumero(_cache.BuscaSucursal(idSucursal),
                                                       idTipoComprobante,
                                                       letraComprobante,
                                                       centroEmisor) - 1

      Dim ultimoNroAFIP As Long

      If letraComprobante <> "E" Then
         Dim impresora = New Reglas.Impresoras().GetUna(actual.Sucursal.Id, centroEmisor)
         If Not impresora.UtilizaBonosFiscalesElectronicos Then
            Dim afip = New AFIPFE(da)
            ultimoNroAFIP = afip.GetUltimoComprobanteAutorizadoV1(idTipoComprobante, letraComprobante, centroEmisor)
         Else
            Dim afip = New AFIPBFE(da)
            ultimoNroAFIP = afip.GetUltimoComprobanteAutorizado(idTipoComprobante, letraComprobante, centroEmisor)
         End If
      Else
         Dim eTipoCpte = New Reglas.AFIPTiposComprobantes().GetUno(idTipoComprobante, letraComprobante)
         '-- Recupera el Ultimo Comprobante Autorizado.- --
         Dim reg = New AFIPFEX()
         ultimoNroAFIP = reg.GetRecuperaUltCompExp(eTipoCpte.IdAFIPTipoComprobante.ToShort(), centroEmisor)

      End If

      If ultimoNroLocal = ultimoNroAFIP Then
         Return True
      Else
         Return False
      End If

   End Function

   Public Sub ActualizaCAE(oVentas As Entidades.Venta, secuencia As Entidades.AFIPCAE.Secuencia,
                           metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)

      Dim comitea As Boolean = True
      Dim errorCAE As String = String.Empty

      If oVentas.TipoComprobante.EsElectronico Then

         'Creo e instancio el objeto para luego actualizar el CAE
         Dim Afip = New Reglas.AFIPFE(da)
         Dim AfipExp = New Reglas.AFIPFEX(da)
         'Creo e instancio el objeto para luego actualizar el CAE por Bonos
         Dim AfipBono = New Reglas.AFIPBFE(da)

         If oVentas.TipoComprobante.EsPreElectronico Then
            ComprobanteAnt = New Entidades.Venta()

            With ComprobanteAnt
               .IdSucursal = oVentas.IdSucursal
               .TipoComprobante = oVentas.TipoComprobante
               .LetraComprobante = oVentas.LetraComprobante
               .CentroEmisor = oVentas.CentroEmisor
               .NumeroComprobante = oVentas.NumeroComprobante
               .ExportacionEmbarques = oVentas.ExportacionEmbarques
            End With


            'Creo el Nuevo Comprobante.
            oVentas.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(oVentas.TipoComprobante.IdTipoComprobanteSecundario)

            Dim rVentasNumeros = New Reglas.VentasNumeros()
            oVentas.NumeroComprobante = rVentasNumeros.GetProximoNumero(_cache.BuscaSucursal(oVentas.IdSucursal), oVentas.TipoComprobante.IdTipoComprobante,
                                                oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor)

            Dim CategoriaFiscalEmpresa = New CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)

            If Not CategoriaFiscalEmpresa.IvaDiscriminado Or Not oVentas.CategoriaFiscal.IvaDiscriminado Then
               For Each Prod As Entidades.VentaProducto In oVentas.VentasProductos
                  Prod.Precio = Decimal.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.Precio, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, 0, Prod.OrigenPorcImpInt), 2)
                  Prod.PrecioNeto = Decimal.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.PrecioNeto, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, 0, Prod.OrigenPorcImpInt), 2)
                  'Prod.DescuentoRecargo = Decimal.Round(Prod.DescuentoRecargo * (1 + (Prod.AlicuotaImpuesto / 100)), 2)
                  'Prod.DescRecGeneral = Decimal.Round(Prod.DescRecGeneral * (1 + (Prod.AlicuotaImpuesto / 100)), 2)
                  'Prod.ImporteTotal = Decimal.Round((Prod.ImporteTotal * (1 + (Prod.AlicuotaImpuesto / 100)) + Prod.ImporteImpuestoInterno), 2)
                  Prod.DescuentoRecargo = Decimal.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.DescuentoRecargo, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, 0, Prod.OrigenPorcImpInt), 2)
                  Prod.DescRecGeneral = Decimal.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.DescRecGeneral, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, 0, Prod.OrigenPorcImpInt), 2)
                  Prod.ImporteTotal = Decimal.Round(CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.ImporteTotal, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, 0, Prod.OrigenPorcImpInt), 2)
               Next
            End If

            'agrego las tarjetas
            oVentas.Tarjetas = Me.GetVentasTarjetas(ComprobanteAnt.IdSucursal,
                                                    ComprobanteAnt.IdTipoComprobante,
                                                    ComprobanteAnt.LetraComprobante,
                                                    ComprobanteAnt.CentroEmisor,
                                                    ComprobanteAnt.NumeroComprobante)


            'Deja el SIGNO en Positivo como si lo estuviera cargado desde Facturacion, en la base estan con el signo final.           
            'If oVentas.TipoComprobante.IdTipoComprobante = "eNCRED" Then
            If oVentas.TipoComprobante.CoeficienteValores < 0 Then
               Me.AplicarSigno(oVentas)
            End If

            oVentas.Percepciones = New Reglas.PercepcionVentas(da).GetPorVentasPercepciones(ComprobanteAnt.IdSucursal,
                                                                                               ComprobanteAnt.IdTipoComprobante,
                                                                                               ComprobanteAnt.LetraComprobante,
                                                                                               ComprobanteAnt.CentroEmisor,
                                                                                               ComprobanteAnt.NumeroComprobante,
                                                                                               ComprobanteAnt.Cliente.IdCliente)

            'Se cambio la fecha de la factura
            If oVentas.Fecha <> oVentas.CuentaCorriente.Fecha Then
               'Solo si tiene una cuota 
               If oVentas.CuentaCorriente.Pagos.Count = 1 Then
                  'Solo cambio la fecha si no fue manual
                  If oVentas.CuentaCorriente.Pagos(0).FechaVencimiento = oVentas.CuentaCorriente.Fecha.AddDays(oVentas.FormaPago.Dias) Then
                     oVentas.CuentaCorriente.Pagos(0).FechaVencimiento = oVentas.Fecha.AddDays(oVentas.FormaPago.Dias)
                  End If
               End If
            End If
            If oVentas.CuentaCorriente.Pagos.Count > 0 Then
               oVentas.CuentaCorriente.Pagos(0).CodigoDeBarraSirplus = Nothing
            End If

            Inserta(oVentas, metodoGrabacion, idFuncion,
                    onAfterInsertarVenta:=
                    Sub(vta)
                       Dim rPedidoEstado = New Reglas.PedidosEstados(da)
                       rPedidoEstado.CambiarInvocadorFact(ComprobanteAnt, oVentas)
                       rPedidoEstado.CambiarInvocadorRemito(ComprobanteAnt, oVentas)
                       vta.TipoComprobante.ConsumePedidos = False
                    End Sub)

            ActualizarCAEProceso(ComprobanteAnt, oVentas)

            If actual.Sistema = "SiGA" Then
               ActualizarComprobantesCargos(ComprobanteAnt, oVentas)
            End If

            Dim oPedido As Pedidos = New Pedidos(da)
            oPedido.ActualizarComprobantePorComprobante(ComprobanteAnt, oVentas)
            oPedido.ActualizarComprobantePorComprobanteRemito(ComprobanteAnt, oVentas)

            Dim rTurnos As TurnosCalendarios = New TurnosCalendarios(da)
            rTurnos.ActualizarComprobantePorComprobante(ComprobanteAnt, oVentas)

            Dim rReparto As RepartosComprobantes = New RepartosComprobantes(da)
            rReparto.ActualizarComprobantePorComprobante(ComprobanteAnt, oVentas)

            Dim rProductosNrosSerie As ProductosNrosSerie = New ProductosNrosSerie(da)
            rProductosNrosSerie.ActualizarComprobantePorComprobanteDeNrosSerie(ComprobanteAnt, oVentas)

            Dim rRecibos = New CuentasCorrientesPagos(da)
            rRecibos.ActualizarPagosComprobantes(ComprobanteAnt, oVentas)

            Dim rResPasajeros = New ReservasTurismoPasajeros(da)
            rResPasajeros.ActualizarComprobantePorComprobante(ComprobanteAnt, oVentas)

            'elimino la Pre-Factura de las tablas
            EjecutaSP(ComprobanteAnt, TipoSP._D, Entidades.Entidad.MetodoGrabacion.Manual, "")

            Dim sqlCC = New SqlServer.CuentasCorrientes(da)
            sqlCC.AjustaSaldoLuegoSegunPagos(oVentas.IdSucursal, oVentas.IdTipoComprobante, oVentas.LetraComprobante, oVentas.CentroEmisor, oVentas.NumeroComprobante)

         End If

         Try
            '-- Primera Vez.- --
            If secuencia = Entidades.AFIPCAE.Secuencia.PrimeraVez Then
               If Not oVentas.Impresora.UtilizaBonosFiscalesElectronicos Then
                  'If Not Boolean.Parse(New Parametros(da).GetValorPD(Entidades.Parametro.Parametros.UTILIZABONOSFISCALESELECTRONICOS, "False")) Then
                  If oVentas.FechaTransmisionAFIP > DateTime.Parse("01/01/1990") Or Not String.IsNullOrEmpty(oVentas.CodigoErrorAfip) Then

                     '-- Verifica si es Exportacion.- --
                     oVentas.AFIPCAE = If(oVentas.EsFacturaExportacion, AfipExp.RecuperarCAEExp_PreSolicitar(oVentas), Afip.RecuperarCAEv1_PreSolicitar(oVentas))
                     '----------------------------------
                     If Not String.IsNullOrEmpty(oVentas.AFIPCAE.CAE) Then
                        '-- Salida Del try.- --
                        Exit Try
                     End If
                  End If
                  '-- Verifica si es Exportacion.- --
                  oVentas.AFIPCAE = If(oVentas.EsFacturaExportacion, AfipExp.SolicitarCAEExp(oVentas), Afip.SolicitarCAEv1(oVentas))
                  '----------------------------------
               Else
                  'solo ingresa por aca si tiene en parametros seteado los bonos
                  oVentas.AFIPCAE = AfipBono.SolicitarCAE(oVentas)
               End If
            Else
               '-- Otra Vez.- --
               If Not oVentas.Impresora.UtilizaBonosFiscalesElectronicos Then
                  'If Not Boolean.Parse(New Parametros(da).GetValorPD(Entidades.Parametro.Parametros.UTILIZABONOSFISCALESELECTRONICOS, "False")) Then
                  '-- Verfica Si es Exportacion.- --
                  oVentas.AFIPCAE = If(oVentas.EsFacturaExportacion, AfipExp.RecuperarCAEExp(oVentas), Afip.RecuperarCAEv1(oVentas))
               Else
                  'solo ingresa por aca si tiene en parametros seteado los bonos
                  oVentas.AFIPCAE = AfipBono.RecuperarCAEv1(oVentas)
               End If
            End If
         Catch ex As Exception
            If String.IsNullOrEmpty(oVentas.AFIPCAE.CAE) Then
               comitea = False
               errorCAE = ex.Message
            End If
         End Try
         If comitea Then
            If Not String.IsNullOrEmpty(oVentas.AFIPCAE.CAE) Then
               Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
               sql.U_CAE(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante,
                           oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor,
                           oVentas.NumeroComprobante, oVentas.AFIPCAE.CAE, oVentas.AFIPCAE.CAEVencimiento)
            End If
         End If
      End If

      If Not comitea Then
         Throw New Exception(errorCAE)
      End If

   End Sub

   Public Sub ActualizarCAE(idSucursal As Integer,
                            idTipoComprobante As String,
                            letra As String,
                            centroEmisor As Integer,
                            numeroComprobante As Long,
                            cae As String,
                            caeVencimiento As Date)
      EjecutaConTransaccion(Sub() _ActualizarCAE(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                 cae, caeVencimiento))
   End Sub

   Friend Sub _ActualizarCAE(idSucursal As Integer,
                             idTipoComprobante As String,
                             letra As String,
                             centroEmisor As Integer,
                             numeroComprobante As Long,
                             cae As String,
                             caeVencimiento As Date)
      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
      sql.U_CAE(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                cae, caeVencimiento)
   End Sub

   Public Overridable Sub ActualizarCAEProceso(vtaActual As Eniac.Entidades.Venta, vtaNueva As Eniac.Entidades.Venta)
      'esto no hace nada, es solo para herencia.
   End Sub

   Public Sub ActualizarCodigoErrorAFIP(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Short,
                                           numeroComprobante As Long,
                                           CodigoErrorAfip As String)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         sql.U_CodigoErrorAfip(idSucursal,
                                    idTipoComprobante,
                                    letra,
                                    centroEmisor,
                                    numeroComprobante,
                                    CodigoErrorAfip)

         Me.da.CommitTransaction()
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Sub ActualizarFechaTransmisionAFIP(idSucursal As Integer,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Short,
                                          numeroComprobante As Long,
                                          fechaTransmisionAFIP As Date)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         sql.U_FechaTransmisionAFIP(idSucursal,
                                    idTipoComprobante,
                                    letra,
                                    centroEmisor,
                                    numeroComprobante,
                                    fechaTransmisionAFIP)

         Me.da.CommitTransaction()
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Comprobante Fiscal"
   Public Function ArmarComprobanteFiscal(oVentas As Entidades.Venta) As Entidades.Venta
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim RVentas As Reglas.Ventas = New Reglas.Ventas(da)
         Dim ComprobanteFiscal As Entidades.Venta = New Entidades.Venta

         ComprobanteFiscal = RVentas.GetUna(oVentas.IdSucursal, oVentas.IdTipoComprobante,
                                                             oVentas.LetraComprobante, oVentas.CentroEmisor,
                                                             oVentas.NumeroComprobante)
         ComprobanteFiscal.Usuario = Entidades.Usuario.Actual.Nombre
         ComprobanteFiscal.IdCaja = oVentas.IdCaja
         ComprobanteFiscal.Fecha = oVentas.Fecha

         '    Dim oVentasNumeros As New Reglas.VentasNumeros()

         ComprobanteFiscal.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(oVentas.TipoComprobante.IdTipoComprobanteSecundario)

         'ComprobanteFiscal.NumeroComprobante = oVentasNumeros.GetProximoNumero(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante, _
         '                                    oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor)

         If Not _categoriaFiscalEmpresa.IvaDiscriminado Or Not oVentas.CategoriaFiscal.IvaDiscriminado Then
            For Each Prod As Entidades.VentaProducto In ComprobanteFiscal.VentasProductos
               Prod.Precio = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.Precio, Prod.Producto), 2)

               Prod.PrecioNeto = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.PrecioNeto, Prod.Producto), 2)

               Prod.DescuentoRecargo = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.DescuentoRecargo, Prod.Producto), 2)
               Prod.DescRecGeneral = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.DescRecGeneral, Prod.Producto), 2)
               Prod.ImporteTotal = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.ImporteTotal, Prod.Producto), 2)

            Next
         End If

         'Deja el SIGNO en Positivo como si lo estuviera cargado desde Facturacion, en la base estan con el signo final.           
         'If oVentas.TipoComprobante.IdTipoComprobante = "eNCRED" Then
         If oVentas.TipoComprobante.CoeficienteValores < 0 Then
            Me.AplicarSigno(ComprobanteFiscal)
         End If

         'agrego las tarjetas
         ComprobanteFiscal.Tarjetas = Me.GetVentasTarjetas(oVentas.IdSucursal,
                                                 oVentas.IdTipoComprobante,
                                                 oVentas.LetraComprobante,
                                                 oVentas.CentroEmisor,
                                                 oVentas.NumeroComprobante)

         ComprobanteFiscal.Percepciones = New Reglas.PercepcionVentas(da).GetPorVentasPercepciones(oVentas.IdSucursal,
                                                                                            oVentas.IdTipoComprobante,
                                                                                            oVentas.LetraComprobante,
                                                                                            oVentas.CentroEmisor,
                                                                                            oVentas.NumeroComprobante,
                                                                                            oVentas.Cliente.IdCliente)


         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         sql.U_FechaTransmisionAFIP(oVentas.IdSucursal, oVentas.TipoComprobante.IdTipoComprobante,
                                             oVentas.LetraComprobante, oVentas.Impresora.CentroEmisor,
                                             oVentas.NumeroComprobante, Date.Now)

         Return ComprobanteFiscal

         Me.da.CommitTransaction()

      Catch ex As Exception
         Dim erro As Entidades.EniacException = New Entidades.EniacException(ex.Message)
         da.RollbakTransaction()
         Throw New ActualizaCAEException(ex, oVentas)
      Finally
         da.CloseConection()

      End Try
   End Function

   Public Sub GrabarComprobanteFiscal(ComprobanteAnterior As Entidades.Venta, ComprobanteAGrabar As Entidades.Venta,
                                       MetodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                        IdFuncion As String)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Me.Inserta(ComprobanteAGrabar, MetodoGrabacion, IdFuncion)

         If actual.Sistema = "SiGA" Then
            ActualizarComprobantesCargos(ComprobanteAnterior, ComprobanteAGrabar)
         End If

         Dim oPedido As Pedidos = New Pedidos(da)
         oPedido.ActualizarComprobantePorComprobante(ComprobanteAnterior, ComprobanteAGrabar)
         oPedido.ActualizarComprobantePorComprobanteRemito(ComprobanteAnterior, ComprobanteAGrabar)

         Dim rTurnos As TurnosCalendarios = New TurnosCalendarios(da)
         rTurnos.ActualizarComprobantePorComprobante(ComprobanteAnterior, ComprobanteAGrabar)

         Dim rReparto As RepartosComprobantes = New RepartosComprobantes(da)
         rReparto.ActualizarComprobantePorComprobante(ComprobanteAnterior, ComprobanteAGrabar)

         Dim rProductosNrosSerie As ProductosNrosSerie = New ProductosNrosSerie(da)

         rProductosNrosSerie.ActualizarComprobantePorComprobanteDeNrosSerie(ComprobanteAnterior, ComprobanteAGrabar)

         'elimino la Pre-Factura de las tablas
         Me.EjecutaSP(ComprobanteAnterior, TipoSP._D, Entidades.Entidad.MetodoGrabacion.Manual, "")

         Me.da.CommitTransaction()

      Catch ex As Exception
         Dim erro As Entidades.EniacException = New Entidades.EniacException(ex.Message)
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()

      End Try
   End Sub

   Public Sub ActualizaFechaExportacion(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        centroEmisor As Long,
                                        letra As String,
                                        numeroComprobante As Long,
                                        fechaExportacion As Date)
      Me.EjecutaConTransaccion(Sub() _ActualizaFechaExportacion(idSucursal, idTipoComprobante, centroEmisor, letra, numeroComprobante, fechaExportacion))
   End Sub

   Public Sub _ActualizaFechaExportacion(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        centroEmisor As Long,
                                        letra As String,
                                        numeroComprobante As Long,
                                        fechaExportacion As Date)
      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
      sql.ActualizaFechaExportacion(idSucursal,
                                    idTipoComprobante,
                                    centroEmisor,
                                    letra,
                                    numeroComprobante,
                                    fechaExportacion)
   End Sub

#End Region



End Class