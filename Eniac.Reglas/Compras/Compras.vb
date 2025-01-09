Imports Eniac.Entidades

Public Class Compras
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "Compras"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Privados"

   Private Function ObtenerProductosConNroSerie(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Integer,
                                                numeroComprobante As Long,
                                                orden As Integer?,
                                                idProveedor As Long,
                                                idProducto As String) As List(Of Entidades.ProductoNroSerie)

      Dim productosNrosSerie = New List(Of Entidades.ProductoNroSerie)
      Dim rCPNS As Reglas.ComprasProductosNrosSerie = New Reglas.ComprasProductosNrosSerie(da)
      Dim ePNS As Entidades.ProductoNroSerie
      For Each eVPNS As Entidades.CompraProductoNroSerie In rCPNS.GetTodosPorComprobante(idSucursal,
                                                                                         idTipoComprobante,
                                                                                         letra,
                                                                                         centroEmisor,
                                                                                         numeroComprobante,
                                                                                         orden,
                                                                                         idProveedor,
                                                                                         idProducto)
         ePNS = New Entidades.ProductoNroSerie
         ePNS.IdSucursal = eVPNS.IdSucursal
         ePNS.TipoComprobante.IdTipoComprobante = eVPNS.IdTipoComprobante
         ePNS.Letra = eVPNS.Letra
         ePNS.CentroEmisor = Short.Parse(eVPNS.CentroEmisor.ToString())
         ePNS.NumeroComprobante = eVPNS.NumeroComprobante
         ePNS.NroSerie = eVPNS.NroSerie
         ePNS.Producto.IdProducto = eVPNS.IdProducto
         ePNS.OrdenVenta = eVPNS.Orden
         productosNrosSerie.Add(ePNS)
      Next

      Return productosNrosSerie

   End Function

   Private Sub Graba(ent As Entidades.Compra, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      Try

         Publicos.GetSistema().ControlaValidezDeFecha(ent.Fecha)
         Publicos.VerificaFechaUltimoLogin()

         Dim sql = New SqlServer.Compras(da)

         If MetodoGrabacion = Entidades.Entidad.MetodoGrabacion.Automatico Then
            ent.NumeroComprobante = New Compras(da).GetProximoNumero(ent.IdSucursal, ent.Proveedor.IdProveedor,
                                                                     ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor)
         End If

         Dim rVentasNumeros = New VentasNumeros(da)
         Dim ventaNumero = rVentasNumeros.GetUno(ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, AccionesSiNoExisteRegistro.Nulo)
         If ventaNumero IsNot Nothing Then
            ventaNumero.Numero = ent.NumeroComprobante
            rVentasNumeros.ActualizarNumero(ventaNumero)
         End If

         sql.Compras_I(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Fecha,
                       ent.Comprador.IdEmpleado,
                       ent.DescuentoRecargo, ent.DescuentoRecargoPorc, ent.ImporteTotal, ent.Proveedor.IdProveedor,
                       ent.IdcategoriaFiscal, ent.FormaPago.IdFormasPago, ent.Observacion, ent.PorcentajeIVA,
                       ent.Rubro.IdRubro, ent.PercepcionIVA, ent.PercepcionIB, ent.PercepcionGanancias, ent.PercepcionVarias, ent.IdEmpresa, ent.PeriodoFiscal,
                       ent.ImportePesos, ent.ImporteTarjetas, ent.ImporteCheques, ent.ImporteTransfBancaria, ent.CuentaBancariaTransfBanc.IdCuentaBancaria,
                       ent.IdEstadoComprobante, ent.CantidadInvocados, ent.Usuario, ent.FechaActualizacion, ent.CotizacionDolar,
                       ent.FechaOficializacionDespacho, ent.IdAduana, ent.IdDestinacion, ent.NumeroDespacho, ent.DigitoVerificadorDespacho,
                       ent.IdDespachante, ent.IdAgenteTransporte, ent.DerechoAduanero, ent.BienCapitalDespacho, ent.NumeroManifiestoDespacho,
                       ent.Bultos, ent.ValorDeclarado, ent.IdTransportista, ent.NumeroLote,
                       ent.IVAModificadoManual, ent.TotalBruto, ent.TotalNeto, ent.TotalIVA, ent.TotalPercepciones,
                       MetodoGrabacion, IdFuncion, ent.NombreProveedor, ent.CuitProveedor, ent.ImpuestosInternos, ent.ExcluirDePasaje, ent.MercEnviada,
                       ent.IdConceptoCM05, ent.NumeroOrdenCompra)

      Catch ex As Exception
         If ex.Message.IndexOf("Cannot insert duplicate key in object") > -1 Then
            Throw New Exception("El Comprobante ya existe y no lo puede volver a cargar.")
         Else
            Throw ex
         End If
      End Try
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetProximoNumero(idSucursal As Integer,
                                    idProveedor As Long,
                                    idTipoComprobante As String,
                                    letraFiscal As String,
                                    emisor As Short) As Long

      Dim stbQuery As StringBuilder = New StringBuilder()

      With stbQuery
         .AppendLine("SELECT MAX(NumeroComprobante) AS maximo ")
         .AppendLine("  FROM Compras C")
         .AppendLine("   INNER JOIN Proveedores P ON C.IdProveedor = P.IdProveedor")
         .AppendLine(" WHERE P.IdProveedor = " & idProveedor.ToString())
         .AppendLine("   AND C.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND C.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND C.Letra = '" & letraFiscal & "'")
         .AppendLine("   AND C.CentroEmisor = " & emisor.ToString())
      End With

      Dim dt As DataTable = da.GetDataTable(stbQuery.ToString())
      Dim val As Long = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Long.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return (val + 1)

   End Function

   Public Sub ModificaCompra(compra As Entidades.Compra)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim compraAnt As Entidades.Compra = Me.GetUna(compra.IdSucursal, compra.TipoComprobante.IdTipoComprobante, compra.Letra, compra.CentroEmisor, compra.NumeroComprobante, compra.Proveedor.IdProveedor)

         If DirectCast(compra, Entidades.IComprobanteComprasModificable).DebeRenumerar Then
            If compraAnt.IdAsiento.HasValue Then
               Throw New ApplicationException(String.Format("El comprobante {0} {1} {2:0000}-{3:00000000} del proveedor {4}-{5} ya fue registrada contablemente en el asiento {6}. No es posible modifcar su número",
                                                            compraAnt.TipoComprobante.Descripcion,
                                                            compraAnt.Letra,
                                                            compraAnt.CentroEmisor,
                                                            compraAnt.NumeroComprobante,
                                                            compraAnt.Proveedor.CodigoProveedor,
                                                            compraAnt.Proveedor.NombreProveedor,
                                                            compraAnt.IdAsiento))
            End If
         End If

         If compra.TipoComprobante.GrabaLibro And compra.Proveedor.CategoriaFiscal.IvaDiscriminado Then

            Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales(da)

            'Quito el Saldo de la compra almacenada, podria ser de un periodo distinto.
            Dim Neto As Decimal = compraAnt.TotalNeto
            Dim IVA As Decimal = compraAnt.TotalIVA

            oPF.ActualizarPosicion(compraAnt.IdEmpresa, compraAnt.PeriodoFiscal, 0, 0, 0, Neto * (-1), IVA * (-1), compraAnt.ImporteTotal * (-1), 0, compraAnt.PercepcionIVA * (-1))


            'Ajusto la Compra Modificada
            Neto = compra.TotalNeto
            IVA = compra.TotalIVA

            oPF.ActualizarPosicion(compra.IdEmpresa, compra.PeriodoFiscal, 0, 0, 0, Neto, IVA, compra.ImporteTotal, 0, compra.PercepcionIVA)
         End If

         Dim sqlCompra As SqlServer.Compras = New SqlServer.Compras(da)

         'Modifica la caja si es distinta y FP Contado 
         '-- REQ 31039 --
         If compraAnt.IdCaja <> compra.IdCaja And compraAnt.FormaPago.Dias = 0 Then
            If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOCAJA)) Then
               Me.InsertarMovimientosCajaNueva(compra)
            End If
         End If

         sqlCompra.Compras_U(compra.IdSucursal, compra.TipoComprobante.IdTipoComprobante, compra.Letra, compra.CentroEmisor,
                             compra.NumeroComprobante, compra.Proveedor.IdProveedor, compra.Fecha,
                             compra.Comprador.IdEmpleado, compra.Rubro.IdRubro, compra.Observacion,
                             compra.IdEmpresa, compra.PeriodoFiscal, compra.IdCaja, compra.MercEnviada)


         Dim DiasAjuste As Integer = Integer.Parse(DateDiff(DateInterval.Day, compraAnt.Fecha, compra.Fecha).ToString())

         Dim sqlCtaCte As SqlServer.CuentasCorrientesProv = New SqlServer.CuentasCorrientesProv(da)

         sqlCtaCte.CuentasCorrientesProv_UFecha(compra.IdSucursal, compra.Proveedor.IdProveedor,
                                                compra.TipoComprobante.IdTipoComprobante, compra.Letra, compra.CentroEmisor, compra.NumeroComprobante,
                                                DiasAjuste, compra.Observacion)

         Dim sqlCtaCtePagos As SqlServer.CuentasCorrientesProvPagos = New SqlServer.CuentasCorrientesProvPagos(da)

         sqlCtaCtePagos.CuentasCorrientesProvPagos_UFecha(compra.IdSucursal, compra.Proveedor.IdProveedor,
                                                          compra.TipoComprobante.IdTipoComprobante, compra.Letra, compra.CentroEmisor, compra.NumeroComprobante,
                                                          DiasAjuste, compra.Observacion)

         'Modifica la caja si es distinta y FP Contado 
         '-- REQ 31039 --
         If compraAnt.IdCaja <> compra.IdCaja And compraAnt.FormaPago.Dias = 0 Then
            If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOCAJA)) Then
               Me.EliminarMovimientosCajaAnterior(compraAnt)
            End If
         End If

         If DirectCast(compra, Entidades.IComprobanteComprasModificable).DebeRenumerar Then
            _RenumerarCompra(compra)
         End If

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub RenumerarCompra(compra As Entidades.Compra)
      Try
         da.OpenConection()
         da.BeginTransaction()
         _RenumerarCompra(compra)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub _RenumerarCompra(compra As Entidades.Compra)
      _RenumerarCompra(compra, DirectCast(compra, Entidades.IComprobanteComprasModificable))
   End Sub
   Private Sub _RenumerarCompra(compra As Entidades.Compra, compraNueva As Entidades.IComprobanteComprasModificable)
      _RenumerarCompra(compra.IdSucursal, compra.TipoComprobante.IdTipoComprobante, compra.Letra, compra.CentroEmisor, compra.NumeroComprobante, compra.Proveedor.IdProveedor,
                       compraNueva.IdSucursalNuevo, compraNueva.IdTipoComprobanteNuevo, compraNueva.LetraNuevo, compraNueva.CentroEmisorNuevo, compraNueva.NumeroComprobanteNuevo, compraNueva.IdProveedorNuevo)
   End Sub
   Private Sub _RenumerarCompra(idSucursalActual As Integer, idTipoComprobanteActual As String, letraActual As String, centroEmisorActual As Short, numeroComprobanteActual As Long, idProveedorActual As Long,
                                idSucursalNuevo As Integer, idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Short, numeroComprobanteNuevo As Long, idProveedorNuevo As Long)
      Dim sql As SqlServer.Compras = New SqlServer.Compras(da)
      'Condición para todas las tablas de compras y PK de CtaCteProv
      Dim whereClauseCompra As String
      whereClauseCompra = String.Format(" WHERE {0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9} AND {10} = {11}",
                                        Entidades.Compra.Columnas.IdSucursal.ToString(), idSucursalActual,
                                        Entidades.Compra.Columnas.IdTipoComprobante.ToString(), idTipoComprobanteActual,
                                        Entidades.Compra.Columnas.Letra.ToString(), letraActual,
                                        Entidades.Compra.Columnas.CentroEmisor.ToString(), centroEmisorActual,
                                        Entidades.Compra.Columnas.NumeroComprobante.ToString(), numeroComprobanteActual,
                                        Entidades.Compra.Columnas.IdProveedor.ToString(), idProveedorActual)

      'Campos a cambiar en todas las tablas de compras y PK de CtaCteProv
      Dim camposCambio As Dictionary(Of String, String) = New Dictionary(Of String, String)() _
                                                                  From {{Entidades.Compra.Columnas.IdSucursal.ToString(), idSucursalNuevo.ToString()},
                                                                        {Entidades.Compra.Columnas.IdTipoComprobante.ToString(), idTipoComprobanteNuevo},
                                                                        {Entidades.Compra.Columnas.Letra.ToString(), letraNuevo},
                                                                        {Entidades.Compra.Columnas.CentroEmisor.ToString(), centroEmisorNuevo.ToString()},
                                                                        {Entidades.Compra.Columnas.NumeroComprobante.ToString(), numeroComprobanteNuevo.ToString()},
                                                                        {Entidades.Compra.Columnas.IdProveedor.ToString(), idProveedorNuevo.ToString()}}

      sql.InsertSelect("Compras", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("ComprasProductos", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("ComprasObservaciones", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("ComprasImpuestos", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("ComprasCheques", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("ComprasCheques", camposCambio, whereClauseCompra)

      sql.InsertSelect("CuentasCorrientesProv", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("CuentasCorrientesProvPagos", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("CuentasCorrientesProvCheques", camposCambio, whereClauseCompra)
      sql.UpdatePrimaryKey("CuentasCorrientesProvRetenciones", camposCambio, whereClauseCompra)

      sql.UpdatePrimaryKey("MovimientosStock", camposCambio, whereClauseCompra)

      'Condición para CuentaCorrienteProvPago usando Comprobante2
      Dim whereClauseCtaCte2 As String
      whereClauseCtaCte2 = String.Format(" WHERE {0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9} AND {10} = {11}",
                                         Entidades.CuentaCorrienteProvPago.Columnas.IdSucursal.ToString(), idSucursalActual,
                                         Entidades.CuentaCorrienteProvPago.Columnas.IdTipoComprobante2.ToString(), idTipoComprobanteActual,
                                         Entidades.CuentaCorrienteProvPago.Columnas.Letra2.ToString(), letraActual,
                                         Entidades.CuentaCorrienteProvPago.Columnas.CentroEmisor2.ToString(), centroEmisorActual,
                                         Entidades.CuentaCorrienteProvPago.Columnas.NumeroComprobante2.ToString(), numeroComprobanteActual,
                                         Entidades.CuentaCorrienteProvPago.Columnas.IdProveedor.ToString(), idProveedorActual)
      'Campos de Comprobante2 a cambiar en CuentaCorrienteProvPago
      Dim camposCambio2 As Dictionary(Of String, String) = New Dictionary(Of String, String)() _
                                                                   From {{Entidades.CuentaCorrienteProvPago.Columnas.IdSucursal.ToString(), idSucursalNuevo.ToString()},
                                                                         {Entidades.CuentaCorrienteProvPago.Columnas.IdTipoComprobante2.ToString(), idTipoComprobanteNuevo},
                                                                         {Entidades.CuentaCorrienteProvPago.Columnas.Letra2.ToString(), letraNuevo},
                                                                         {Entidades.CuentaCorrienteProvPago.Columnas.CentroEmisor2.ToString(), centroEmisorNuevo.ToString()},
                                                                         {Entidades.CuentaCorrienteProvPago.Columnas.NumeroComprobante2.ToString(), numeroComprobanteNuevo.ToString()},
                                                                         {Entidades.CuentaCorrienteProvPago.Columnas.IdProveedor.ToString(), idProveedorNuevo.ToString()}}
      sql.UpdatePrimaryKey("CuentasCorrientesProvPagos", camposCambio2, whereClauseCtaCte2)

      'Condición para PedidoEstadoProveedor usando Fact
      Dim whereClausePedProF As String
      whereClausePedProF = String.Format(" WHERE {0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9} AND {10} = {11}",
                                         Entidades.PedidoEstadoProveedor.Columnas.IdSucursal.ToString(), idSucursalActual,
                                         Entidades.PedidoEstadoProveedor.Columnas.IdTipoComprobanteFact.ToString(), idTipoComprobanteActual,
                                         Entidades.PedidoEstadoProveedor.Columnas.LetraFact.ToString(), letraActual,
                                         Entidades.PedidoEstadoProveedor.Columnas.CentroEmisorFact.ToString(), centroEmisorActual,
                                         Entidades.PedidoEstadoProveedor.Columnas.NumeroComprobanteFact.ToString(), numeroComprobanteActual,
                                         Entidades.PedidoEstadoProveedor.Columnas.IdProveedor.ToString(), idProveedorActual)
      'Campos de Fact a cambiar en PedidoEstadoProveedor
      Dim camposCambioF As Dictionary(Of String, String) = New Dictionary(Of String, String)() _
                                                                   From {{Entidades.PedidoEstadoProveedor.Columnas.IdSucursal.ToString(), idSucursalNuevo.ToString()},
                                                                         {Entidades.PedidoEstadoProveedor.Columnas.IdTipoComprobanteFact.ToString(), idTipoComprobanteNuevo},
                                                                         {Entidades.PedidoEstadoProveedor.Columnas.LetraFact.ToString(), letraNuevo},
                                                                         {Entidades.PedidoEstadoProveedor.Columnas.CentroEmisorFact.ToString(), centroEmisorNuevo.ToString()},
                                                                         {Entidades.PedidoEstadoProveedor.Columnas.NumeroComprobanteFact.ToString(), numeroComprobanteNuevo.ToString()},
                                                                         {Entidades.PedidoEstadoProveedor.Columnas.IdProveedor.ToString(), idProveedorNuevo.ToString()}}
      sql.UpdatePrimaryKey("PedidosEstadosProveedores", camposCambioF, whereClausePedProF)

      'Condición para PedidoEstadoProveedor usando Remito
      Dim whereClausePedProR As String
      whereClausePedProR = String.Format(" WHERE {0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9} AND {10} = {11}",
                                         Entidades.PedidoEstadoProveedor.Columnas.IdSucursalRemito.ToString(), idSucursalActual,
                                         Entidades.PedidoEstadoProveedor.Columnas.IdTipoComprobanteRemito.ToString(), idTipoComprobanteActual,
                                         Entidades.PedidoEstadoProveedor.Columnas.LetraRemito.ToString(), letraActual,
                                         Entidades.PedidoEstadoProveedor.Columnas.CentroEmisorRemito.ToString(), centroEmisorActual,
                                         Entidades.PedidoEstadoProveedor.Columnas.NumeroComprobanteRemito.ToString(), numeroComprobanteActual,
                                         Entidades.PedidoEstadoProveedor.Columnas.IdProveedor.ToString(), idProveedorActual)
      'Campos de Remito a cambiar en PedidoEstadoProveedor
      Dim camposCambioR As Dictionary(Of String, String) = New Dictionary(Of String, String)() _
                                                                   From {{Entidades.PedidoEstadoProveedor.Columnas.IdSucursalRemito.ToString(), idSucursalNuevo.ToString()},
                                                                         {Entidades.PedidoEstadoProveedor.Columnas.IdTipoComprobanteRemito.ToString(), idTipoComprobanteNuevo},
                                                                         {Entidades.PedidoEstadoProveedor.Columnas.LetraRemito.ToString(), letraNuevo},
                                                                         {Entidades.PedidoEstadoProveedor.Columnas.CentroEmisorRemito.ToString(), centroEmisorNuevo.ToString()},
                                                                         {Entidades.PedidoEstadoProveedor.Columnas.NumeroComprobanteRemito.ToString(), numeroComprobanteNuevo.ToString()},
                                                                         {Entidades.PedidoEstadoProveedor.Columnas.IdProveedor.ToString(), idProveedorNuevo.ToString()}}
      sql.UpdatePrimaryKey("PedidosEstadosProveedores", camposCambioR, whereClausePedProR)

      sql.DeleteGenerico("CuentasCorrientesProv", camposCambio, whereClauseCompra)
      sql.DeleteGenerico("Compras", camposCambio, whereClauseCompra)

   End Sub

   Public Sub EliminarMovimientosCajaAnterior(compra As Entidades.Compra)


      Dim oCheques As List(Of Entidades.Cheque)

      oCheques = New Cheques(da).GetPorComprobanteCompraCH(compra.IdSucursal, compra.Proveedor.IdProveedor,
                         compra.TipoComprobante.IdTipoComprobante, compra.Letra, compra.CentroEmisor, compra.NumeroComprobante, esPropio:=Nothing)

      Dim Cont As Integer = 0

      For Cont = 1 To oCheques.Count
         If oCheques.Item(Cont - 1).NroMovimientoEgreso = 0 Then
            Dim Mensaje As String
            Mensaje = "ATENCION: el Pago tiene al menos este cheque re-ingresado, NO puede ANULARLO..."
            Mensaje = Mensaje & Chr(13) & Chr(13)
            Mensaje = Mensaje & "Banco: " & oCheques.Item(Cont - 1).Banco.NombreBanco & " / "
            Mensaje = Mensaje & "Suc. Bco: " & oCheques.Item(Cont - 1).IdBancoSucursal.ToString() & " / "
            Mensaje = Mensaje & "Loc. Bco: " & oCheques.Item(Cont - 1).Localidad.NombreLocalidad & " / "
            Mensaje = Mensaje & "Numero Cheq.: " & oCheques.Item(Cont - 1).NumeroCheque.ToString()

            Throw New Exception(Mensaje)
         End If
      Next


      Dim ocheque As Reglas.Cheques = New Reglas.Cheques(da)
      Dim sqlCheq As SqlServer.Cheques = New SqlServer.Cheques(da)
      Dim compraCheque As Reglas.ComprasCheques = New Reglas.ComprasCheques(da)


      ''  VER de modificar CAJA
      '  compraCheque.EliminarCompraCheque(compra)

      Dim sqlLibroBancos As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)

      Dim decTotalCheqPropio As Decimal = 0

      For Each cheq As Entidades.Cheque In compra.ChequesPropios

         '   cheq.IdSucursal = compra.IdSucursal

         '   sqlLibroBancos.LibroBancos_DPorCheque(cheq.IdSucursal, cheq.CuentaBancaria.IdCuentaBancaria, cheq.Banco.IdBanco, cheq.IdBancoSucursal, cheq.Localidad.IdLocalidad, cheq.NumeroCheque)

         '   ocheque.EjecutaSP(cheq, TipoSP._D)
         decTotalCheqPropio = decTotalCheqPropio + cheq.Importe
      Next

      Dim decTotalCheqTerc As Decimal = 0

      For Each cheq As Entidades.Cheque In compra.ChequesTerceros
         cheq.IdSucursal = compra.IdSucursal

         'Lo vuelvo a dejar en Cartera
         cheq.NroPlanillaEgreso = 0
         cheq.NroMovimientoEgreso = 0

         '    ocheque.EjecutaSP(cheq, TipoSP._U)

         'Para que lo tome el asiento de Caja que se hace posteriormente.
         cheq.IdEstadoCheque = cheq.IdEstadoChequeAnt

         '   sqlCheq.Cheques_VuelveEstadoAnt(cheq.IdSucursal, cheq.Banco.IdBanco, cheq.IdBancoSucursal, cheq.Localidad.IdLocalidad, cheq.NumeroCheque, actual.Nombre)

         decTotalCheqTerc = decTotalCheqTerc + cheq.Importe

      Next

      'si el cliente compro el modulo de caja registro el movimiento de efectivo y/o cheques entregados
      If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOCAJA)) Then

         Dim deta As Eniac.Entidades.CajaDetalles = New Eniac.Entidades.CajaDetalles(compra.IdSucursal, compra.Usuario, compra.Password)
         Dim caj As Eniac.Reglas.Cajas = New Eniac.Reglas.Cajas(da)
         Dim cajaDet As Eniac.Reglas.CajaDetalles = New Eniac.Reglas.CajaDetalles(da)

         With deta
            .FechaMovimiento = compra.Fecha  'DateTime.Now
            .IdSucursal = compra.IdSucursal
            .IdCaja = compra.IdCaja
            .IdTipoMovimiento = "I"c
            .NumeroPlanilla = caj.GetPlanillaActual(compra.IdSucursal, compra.IdCaja).NumeroPlanilla
            .NumeroMovimiento = cajaDet.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCaja, .NumeroPlanilla)
            .ImportePesos = compra.ImportePesos
            .ImporteBancos = compra.ImporteTransfBancaria + decTotalCheqPropio
            .ImporteCheques = decTotalCheqTerc
            .ImporteTickets = 0
            .ImporteTarjetas = compra.ImporteTarjetas
            .Observacion = Strings.Left("ANULA " & compra.TipoComprobante.Descripcion & " " & compra.Letra & " " & compra.CentroEmisor.ToString() & "-" & compra.NumeroComprobante.ToString("00000000") & IIf(compra.ChequesTerceros.Count > 0, " - Cantidad Cheq. Tercero: " + compra.ChequesTerceros.Count.ToString(), "").ToString() & " - Transf. desde: " & compra.CuentaBancariaTransfBanc.NombreCuenta & ". " & compra.Proveedor.NombreProveedor, 100)
            '.IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAPAGO"))
            .IdCuentaCaja = compra.Proveedor.CuentaDeCaja.IdCuentaCaja
            .EsModificable = False
            .GeneraContabilidad = False
            .Usuario = actual.Nombre
         End With

         'Por ahora marco los cheques con el movimiento, aunque en realidad no lo sume en el movimiento de Caja.
         cajaDet.InsertarNuevoMovimiento(deta)

      End If


      'si el Cliente compro el modulo de Banco registro el movimiento de Cheques Propios entregados

      'If Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOBANCO)) Then

      '   Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos(da)
      '   Dim entLibroBanco As Entidades.LibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
      '   Dim oLibBanco As Eniac.Reglas.LibroBancos = New Eniac.Reglas.LibroBancos(da)

      '   'For Each cheq As Entidades.Cheque In compra.ChequesPropios

      '   '   oLibBanco.EliminarMovimientoPorCheque(cheq.IdSucursal, _
      '   '                                         cheq.CuentaBancaria.IdCuentaBancaria, _
      '   '                                         cheq.Banco.IdBanco, _
      '   '                                         cheq.IdBancoSucursal, _
      '   '                                         cheq.Localidad.IdLocalidad, _
      '   '                                        cheq.NumeroCheque)

      '   'Next


      '   'Si Pagó parte con Transfencia Bancaria
      '   If compra.ImporteTransfBancaria > 0 Then

      '      With entLibroBanco
      '         .IdSucursal = compra.IdSucursal
      '         .IdCuentaBancaria = compra.CuentaBancariaTransfBanc.IdCuentaBancaria
      '         .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

      '         If compra.Proveedor.CuentaBanco.IdCuentaBanco > 0 Then
      '            .IdCuentaBanco = compra.Proveedor.CuentaBanco.IdCuentaBanco
      '         Else
      '            .IdCuentaBanco = Integer.Parse(Reglas.Publicos.CtaBancoTransfBancaria)
      '         End If

      '         .IdTipoMovimiento = "I"
      '         .Importe = compra.ImporteTransfBancaria
      '         .FechaMovimiento = compra.Fecha
      '         .NumeroCheque = 0
      '         .IdBancoCheque = 0
      '         .IdBancoSucursalCheque = 0
      '         .IdLocalidadCheque = 0
      '         .FechaAplicado = compra.Fecha
      '         '.Observacion = ent.Observacion
      '         .Observacion = Strings.Left("ANULA " & compra.TipoComprobante.Descripcion & " " & compra.Letra & " " & compra.CentroEmisor.ToString() & "-" & compra.NumeroComprobante.ToString("00000000") & " - Transf. a Caja" & ". " & compra.Proveedor.NombreProveedor, 100)
      '         .Conciliado = False
      '      End With

      '      oLibroBancos.AgregaMovimiento(entLibroBanco)

      '   End If

      'End If

   End Sub

   Public Sub InsertarMovimientosCajaNueva(compra As Entidades.Compra)

      Dim OmovComp = New MovimientosStock(da)

      'si el cliente compro el modulo de caja
      Dim idPlanilla As Integer = 0
      Dim NroPlanilla As Integer = 0
      Dim NroMovimiento As Integer = 0

      If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Reglas.Parametros().GetValor(Parametro.Parametros.MODULOCAJA)) Then
         'si el tipo de comprobante afecta la caja, porque puede suceder que no la afecte
         'ya que si es un cliente que tiene fichas y despues factura por aca se complica
         If compra.TipoComprobante.AfectaCaja Then
            Dim deta As Entidades.CajaDetalles = New Entidades.CajaDetalles(compra.IdSucursal, compra.Usuario, compra.Password)
            Dim caj As Reglas.Cajas = New Reglas.Cajas(da)
            Dim ctaCaj As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas(da)
            Dim cajaDet As Reglas.CajaDetalles = New Reglas.CajaDetalles(da)

            With deta
               .FechaMovimiento = compra.Fecha      'DateTime.Now
               .IdSucursal = compra.IdSucursal
               .IdCaja = compra.IdCaja
               .IdTipoMovimiento = "E"c
               .NumeroPlanilla = caj.GetPlanillaActual(compra.IdSucursal, compra.IdCaja).NumeroPlanilla
               .Observacion = Strings.Left(compra.TipoComprobante.Descripcion & " " & compra.Letra & " " & compra.CentroEmisor.ToString() &
                         "-" & compra.NumeroComprobante.ToString("00000000") &
                         IIf(compra.ChequesTerceros.Count > 0, " - Cant.Cheq.Terc.: " + compra.ChequesTerceros.Count.ToString(), "").ToString() &
                         IIf(compra.ChequesPropios.Count > 0, " - Cant.Cheq.Prop.: " + compra.ChequesPropios.Count.ToString(), "").ToString() &
                         IIf(compra.ImporteTransfBancaria > 0, " - Transf.Desde: " & compra.CuentaBancariaTransfBanc.NombreCuenta, "").ToString() &
                         ". " & compra.Proveedor.NombreProveedor, 100)
               '.IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor(Parametro.Parametros.CTACAJACOMPRAS))
               .IdCuentaCaja = compra.Proveedor.CuentaDeCaja.IdCuentaCaja
               .ImporteCheques = compra.ImporteChequesTerceros
               .ImporteTarjetas = compra.ImporteTarjetas
               .ImportePesos = compra.ImportePesos
               .ImporteBancos = compra.ImporteTransfBancaria + compra.ImporteChequesPropios
               .EsModificable = False
               .GeneraContabilidad = False
               .Usuario = actual.Nombre
            End With

            cajaDet.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(compra.ChequesTerceros), Publicos.ConvierteChequesPropiosEnArray(compra.ChequesPropios))

            idPlanilla = deta.IdCaja
            NroPlanilla = deta.NumeroPlanilla
            NroMovimiento = deta.NumeroMovimiento


            compra.NumeroPlanilla = NroPlanilla
            compra.NumeroMovimiento = NroMovimiento

            OmovComp.ActualizaMovimientoCaja(compra)

            Me.ActualizoCajaDeCheques(compra)


            'si tiene modulo Bancos
            'If Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOBANCO)) Then

            '   My.Application.Log.WriteEntry("Actualizo los o el Banco con los datos de la Transferencia.", TraceEventType.Verbose)
            '   Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos(da)
            '   Dim entLibroBanco As Entidades.LibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
            '   Dim oLibBanco As Eniac.Reglas.LibroBancos = New Eniac.Reglas.LibroBancos(da)

            '   For Each cheq As Entidades.Cheque In compra.ChequesPropios

            '      With entLibroBanco
            '         .IdSucursal = cheq.IdSucursal
            '         .IdCuentaBancaria = cheq.CuentaBancaria.IdCuentaBancaria
            '         .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)
            '         .IdCuentaBanco = Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTABANCOPAGO))
            '         .IdTipoMovimiento = "E"
            '         .Importe = cheq.Importe
            '         .FechaMovimiento = compra.Fecha
            '         .NumeroCheque = cheq.NumeroCheque
            '         .IdBancoCheque = cheq.Banco.IdBanco
            '         .IdBancoSucursalCheque = cheq.IdBancoSucursal
            '         .IdLocalidadCheque = cheq.CuentaBancaria.Localidad.IdLocalidad
            '         .FechaAplicado = cheq.FechaCobro
            '         .Observacion = Strings.Left(compra.TipoComprobante.Descripcion & " " & compra.Letra & " " & compra.CentroEmisor.ToString() & "-" & compra.NumeroComprobante.ToString("00000000") & ". " & compra.Proveedor.NombreProveedor, 100)
            '         .Conciliado = False
            '      End With

            '      oLibroBancos.AgregaMovimiento(entLibroBanco)

            '   Next

            '   If compra.ImporteTransfBancaria > 0 Then

            '      With entLibroBanco
            '         .IdSucursal = compra.IdSucursal
            '         .IdCuentaBancaria = compra.CuentaBancariaTransfBanc.IdCuentaBancaria
            '         .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

            '         If compra.Proveedor.CuentaBanco.IdCuentaBanco > 0 Then
            '            .IdCuentaBanco = compra.Proveedor.CuentaBanco.IdCuentaBanco
            '         Else
            '            .IdCuentaBanco = Integer.Parse(Reglas.Publicos.CtaBancoTransfBancaria)
            '         End If

            '         .IdTipoMovimiento = "E"
            '         .Importe = compra.ImporteTransfBancaria
            '         .FechaMovimiento = compra.Fecha
            '         .NumeroCheque = 0
            '         .IdBancoCheque = 0
            '         .IdBancoSucursalCheque = 0
            '         .IdLocalidadCheque = 0
            '         .FechaAplicado = compra.Fecha
            '         .Observacion = Strings.Left(compra.TipoComprobante.Descripcion & " " & compra.Letra & " " & compra.CentroEmisor.ToString() & "-" & compra.NumeroComprobante.ToString("00000000") & " - Transf. desde: " & ". " & compra.Proveedor.NombreProveedor, 100)
            '         .Conciliado = False
            '      End With

            '      oLibroBancos.AgregaMovimiento(entLibroBanco)

            '   End If

            'End If
         End If
      End If


   End Sub
   Private Sub ActualizoCajaDeCheques(compra As Entidades.Compra)

      Dim sqlCheques As SqlServer.Cheques = New SqlServer.Cheques(da)

      For Each ch As Entidades.Cheque In compra.ChequesPropios
         '-- REQ-32653.- --
         sqlCheques.Cheques_UAsociarNroMovimientoIngreso(ch.IdSucursal, compra.IdCaja, compra.NumeroPlanilla,
                                                         compra.NumeroMovimiento, ch.Banco.IdBanco, ch.IdBancoSucursal,
                                                         ch.Localidad.IdLocalidad, ch.NumeroCheque, ch.IdEstadoCheque,
                                                          ch.Cliente.IdCliente, actual.Nombre, ch.Cuit) ', ch.IdCheque)


      Next

      For Each cheq As Entidades.Cheque In compra.ChequesTerceros

         cheq.IdEstadoCheque = Entidades.Cheque.Estados.ENCARTERA
         '-- REQ-32653.- --
         sqlCheques.Cheques_UAsociarNroMovimientoIngreso(cheq.IdSucursal, compra.IdCaja, compra.NumeroPlanilla,
                                                        compra.NumeroMovimiento, cheq.Banco.IdBanco, cheq.IdBancoSucursal,
                                                        cheq.Localidad.IdLocalidad, cheq.NumeroCheque, cheq.IdEstadoCheque,
                                                         cheq.Cliente.IdCliente, actual.Nombre, cheq.Cuit) ', cheq.IdCheque)
      Next

   End Sub

   Public Sub EliminarCompra(compra As Entidades.Compra)

      Dim oCompra As Entidades.Compra = DirectCast(compra, Entidades.Compra)

      Try
         da.OpenConection()
         da.BeginTransaction()

         'Si el tipo de pago es cta cte tengo que eliminar la cta cte

         If Publicos.TieneModuloContabilidad Then
            Dim ctblEjercicio As ContabilidadEjercicios = New ContabilidadEjercicios(da)
            If compra.TipoComprobante.GeneraContabilidad Then
               ctblEjercicio.EstaPeriodoCerrado(oCompra.Fecha)
            End If
         End If

         'Controlo el periodo fiscal
         If oCompra.TipoComprobante.GeneraContabilidad Then
            If oCompra.TipoComprobante.GrabaLibro Then
               Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
               Dim dt As DataTable = oPF.Get1(oCompra.IdEmpresa, oCompra.PeriodoFiscal)
               If dt.Rows.Count = 0 Then
                  Throw New Exception("El Período Fiscal del Comprobante NO esta habilitado.")
               ElseIf Not String.IsNullOrEmpty(dt.Rows(0)("FechaCierre").ToString()) Then
                  Throw New Exception("El Período Fiscal del Comprobante se encuentra Cerrado.")
               End If
            End If
         End If

         If compra.NumeroComprobanteVenta > 0 Then
            Throw New Exception(String.Format("El comprobante fué invocado por la {0} {1} {2:0000} {3:00000000}. Por favor anule la misma y vuelva a intentar.",
                                              compra.IdTipoComprobanteVenta, compra.LetraVenta, compra.CentroEmisorVenta, compra.NumeroComprobanteVenta))
         End If

         If oCompra.TipoComprobante.ActualizaCtaCte Then
            If oCompra.FormaPago.Dias > 0 Then
               If Publicos.TieneModuloCuentaCorrienteProveedores Then

                  'Chequeo si el comprobante tiene algun pago aplicado.

                  Dim oCtaCte As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv(da)
                  Dim ComprobCtaCte As Entidades.CuentaCorrienteProv

                  ComprobCtaCte = oCtaCte.GetUna(oCompra.IdSucursal, oCompra.Proveedor.IdProveedor, oCompra.TipoComprobante.IdTipoComprobante,
                                                 oCompra.Letra, oCompra.CentroEmisor, oCompra.NumeroComprobante)

                  'Si es NCRED viene dado vuelta, tengo que volver a cambiarlo.
                  If ComprobCtaCte.ImporteTotal * oCompra.TipoComprobante.CoeficienteValores <> ComprobCtaCte.Saldo Then
                     Throw New Exception("El Comprobante tiene algun(os) pago(s) relacionado(s), primero debe Anularlo(s).")
                  End If

               End If
            End If
         End If

         'elimino la cta cta proveedores
         If oCompra.TipoComprobante.ActualizaCtaCte Then
            If oCompra.FormaPago.Dias > 0 Then
               If Publicos.TieneModuloCuentaCorrienteProveedores Then  ' Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCUENTACORRIENTEPROVEEDORES)) Then

                  Dim oCtaCte As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv(da)

                  oCompra.CuentaCorrienteProv = oCtaCte.GetUna(oCompra.IdSucursal, oCompra.Proveedor.IdProveedor, oCompra.TipoComprobante.IdTipoComprobante,
                                                 oCompra.Letra, oCompra.CentroEmisor, oCompra.NumeroComprobante)

                  oCtaCte.EliminarCuentaCorrienteProv(oCompra.CuentaCorrienteProv)

               End If
            End If
         End If

         'Elimino Nros de Serie.
         Dim reglaCDE = New SqlServer.ComprasDistribucionExpensas(da)
         Dim reglaCDG = New SqlServer.ComprasDistribucionPorGrupo(da)
         reglaCDE.ComprasDistribucionExpensas_D(compra.IdSucursal,
                                                compra.TipoComprobante.IdTipoComprobante,
                                                compra.Letra,
                                                compra.CentroEmisor,
                                                compra.NumeroComprobante,
                                                compra.Proveedor.IdProveedor,
                                                String.Empty)
         reglaCDG.ComprasDistribucionPorGrupo_D(compra.IdSucursal,
                                                compra.TipoComprobante.IdTipoComprobante,
                                                compra.Letra,
                                                compra.CentroEmisor,
                                                compra.NumeroComprobante,
                                                compra.Proveedor.IdProveedor,
                                                0)

         EliminarCompraAdicionales(compra)

         Dim nrosSerie As Reglas.ProductosNrosSerie = New Reglas.ProductosNrosSerie(da)
         Dim vendidos As DataTable

         vendidos = nrosSerie.GetVendidos(oCompra.IdSucursal, oCompra.TipoComprobante.IdTipoComprobante, oCompra.Letra, oCompra.CentroEmisor,
                                     oCompra.NumeroComprobante, oCompra.Proveedor.IdProveedor)

         For Each dr As DataRow In vendidos.Rows
            If Boolean.Parse(dr("Vendido").ToString()) Then
               Throw New Exception(String.Format("El producto {0} Serie: {1} no se encuentra en stock. No es posible anular la compra.",
                                                 dr.Field(Of String)(Entidades.Producto.Columnas.NombreProducto.ToString()),
                                                 dr.Field(Of String)(Entidades.ProductoNroSerie.Columnas.NroSerie.ToString())))
            End If
         Next

         '# Si el tipo de comprobante tiene coef. Stock negativo(por ej: una devolución de compra) ->
         Dim esDevolucion As Boolean = oCompra.TipoComprobante.CoeficienteStock < 0
         Dim dtNrosSerie As DataTable

         For Each cp As Entidades.CompraProducto In oCompra.ComprasProductos
            For Each p As Entidades.ProductoNroSerie In cp.Producto.NrosSeries

               '# 1) Inserto en los campos de compra los valores del comprobante anterior a la devolución.
               If esDevolucion Then
                  dtNrosSerie = nrosSerie.GetEstadoComprobanteAnteriorAFecha(oCompra.IdSucursal, oCompra.TipoComprobante.IdTipoComprobante,
                                                                    p.Producto.IdProducto, p.NroSerie, oCompra.Fecha, esDeVenta:=False) '# esDeVenta = FALSE > Es de Compra.-

                  If dtNrosSerie.Rows.Count > 0 Then
                     Dim dr As DataRow = dtNrosSerie.Rows(0)
                     nrosSerie._Inserta(New Entidades.ProductoNroSerie With {.Sucursal = New Entidades.Sucursal With {.IdSucursal = dr.Field(Of Integer)(Entidades.ProductoNroSerie.Columnas.IdSucursal.ToString())},
                                                                               .TipoComprobante = New Entidades.TipoComprobante With {.IdTipoComprobante = dr.Field(Of String)(Entidades.MovimientoStock.Columnas.IdTipoComprobante.ToString())},
                                                                               .Letra = dr.Field(Of String)(Entidades.MovimientoStock.Columnas.Letra.ToString()),
                                                                               .CentroEmisor = Convert.ToInt16(dr.Field(Of Integer)(Entidades.MovimientoStock.Columnas.CentroEmisor.ToString())),
                                                                               .NumeroComprobante = dr.Field(Of Long)(Entidades.MovimientoStock.Columnas.NumeroComprobante.ToString()),
                                                                               .Vendido = False,
                                                                               .Producto = cp.Producto,
                                                                               .NroSerie = p.NroSerie,
                                                                               .OrdenCompra = dr.Field(Of Integer)(Entidades.CompraProducto.Columnas.Orden.ToString()),
                                                                               .Proveedor = New Entidades.Proveedor With {.IdProveedor = dr.Field(Of Long)(Entidades.Proveedor.Columnas.IdProveedor.ToString())}})
                  End If

               Else
                  '# 2) Valido que todos los productos c/Nro. Serie que compré, existan y no hayan sido devueltos por algún otro movimiento
                  If Not nrosSerie.Existe(p.Producto.IdProducto, p.NroSerie) Then
                     Throw New Exception(String.Format("El producto {0} Serie: {1} no se encuentra registrado en el sistema. No es posible realizar la devolución.",
                                                  cp.Producto.NombreProducto, p.NroSerie))
                  End If

               End If

            Next
         Next

         nrosSerie.EliminarNrosSerie(oCompra.IdSucursal, oCompra.TipoComprobante.IdTipoComprobante, oCompra.Letra, oCompra.CentroEmisor,
                                     oCompra.NumeroComprobante, oCompra.Proveedor.IdProveedor)

         ' Compra contado 

         If oCompra.FormaPago.Dias = 0 Then

            Dim oCheques As List(Of Entidades.Cheque)

            oCheques = New Cheques(da).GetPorComprobanteCompraCH(oCompra.IdSucursal, oCompra.Proveedor.IdProveedor,
                               oCompra.TipoComprobante.IdTipoComprobante, oCompra.Letra, oCompra.CentroEmisor, oCompra.NumeroComprobante, esPropio:=Nothing)

            Dim Cont As Integer = 0

            For Cont = 1 To oCheques.Count
               If oCheques.Item(Cont - 1).NroMovimientoEgreso = 0 Then
                  Dim Mensaje As String
                  Mensaje = "ATENCION: el Pago tiene al menos este cheque re-ingresado, NO puede ANULARLO..."
                  Mensaje = Mensaje & Chr(13) & Chr(13)
                  Mensaje = Mensaje & "Banco: " & oCheques.Item(Cont - 1).Banco.NombreBanco & " / "
                  Mensaje = Mensaje & "Suc. Bco: " & oCheques.Item(Cont - 1).IdBancoSucursal.ToString() & " / "
                  Mensaje = Mensaje & "Loc. Bco: " & oCheques.Item(Cont - 1).Localidad.NombreLocalidad & " / "
                  Mensaje = Mensaje & "Numero Cheq.: " & oCheques.Item(Cont - 1).NumeroCheque.ToString()

                  Throw New Exception(Mensaje)
               End If
            Next


            Dim ocheque As Reglas.Cheques = New Reglas.Cheques(da)
            Dim sqlCheq As SqlServer.Cheques = New SqlServer.Cheques(da)
            Dim compraCheque As Reglas.ComprasCheques = New Reglas.ComprasCheques(da)

            compraCheque.EliminarCompraCheque(compra)

            Dim sqlLibroBancos As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)

            For Each cheq As Entidades.Cheque In compra.ChequesPropios

               cheq.IdSucursal = compra.IdSucursal

               sqlLibroBancos.LibroBancos_DPorCheque(cheq.IdCheque)

               ocheque.EjecutaSP(cheq, TipoSP._D)
            Next

            Dim decTotalCheqTerc As Decimal = 0

            For Each cheq As Entidades.Cheque In compra.ChequesTerceros
               cheq.IdSucursal = compra.IdSucursal

               'Lo vuelvo a dejar en Cartera
               cheq.NroPlanillaEgreso = 0
               cheq.NroMovimientoEgreso = 0

               ocheque.EjecutaSP(cheq, TipoSP._U)

               '-- REQ-28359 --
               '# Recupero los estados de los cheques anteriores
               Dim eCheque As Entidades.Cheque = ocheque.RecuperarEstadosChequeAnteriores(cheq.IdCheque)

               sqlCheq.Cheques_VuelveEstadoAnt(cheq.IdSucursal,
                                               cheq.Banco.IdBanco,
                                               cheq.IdBancoSucursal,
                                               cheq.Localidad.IdLocalidad,
                                               cheq.NumeroCheque,
                                               actual.Nombre,
                                               eCheque.IdEstadoCheque.ToString(),
                                               eCheque.IdEstadoChequeAnt.ToString(),
                                               cheq.IdCheque,
                                               limpiaPlanillaCaja:=False)

               decTotalCheqTerc = decTotalCheqTerc + cheq.Importe

            Next

            'si el cliente compro el modulo de caja registro el movimiento de efectivo y/o cheques entregados
            If Publicos.TieneModuloCaja Then  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOCAJA)) Then

               Dim deta = New Entidades.CajaDetalles(compra.IdSucursal, compra.Usuario, compra.Password)
               Dim rCaja = New Cajas(da)
               Dim rCajaDetalle = New CajaDetalles(da)

               With deta
                  .FechaMovimiento = compra.Fecha  'DateTime.Now
                  .IdSucursal = compra.IdSucursal
                  .IdCaja = compra.IdCaja
                  .IdTipoMovimiento = "I"c
                  .NumeroPlanilla = rCaja.GetPlanillaActual(compra.IdSucursal, compra.IdCaja).NumeroPlanilla
                  .NumeroMovimiento = rCajaDetalle.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCaja, .NumeroPlanilla)
                  .ImportePesos = compra.ImportePesos
                  .ImporteBancos = compra.ImporteTransfBancaria
                  .ImporteCheques = decTotalCheqTerc
                  .ImporteTickets = 0
                  .ImporteTarjetas = compra.ImporteTarjetas

                  .IdMonedaImporteBancos = compra.CuentaBancariaTransfBanc.Moneda.IdMoneda
                  If .IdMonedaImporteBancos = 0 Then
                     .IdMonedaImporteBancos = Entidades.Moneda.Peso
                  End If

                  .ImporteRetenciones = compra.Retenciones.SumSecure(Function(r) r.Retencion.ImporteTotal).IfNull() * compra.TipoComprobante.CoeficienteValores
                  .ImporteTarjetas += compra.CuponesTarjetasLiquidacion.SumSecure(Function(c) c.TarjetaCupon.Monto).IfNull()

                  .Observacion = Strings.Left("ANULA " & compra.TipoComprobante.Descripcion & " " & compra.Letra & " " & compra.CentroEmisor.ToString() & "-" & compra.NumeroComprobante.ToString("00000000") & IIf(compra.ChequesTerceros.Count > 0, " - Cantidad Cheq. Tercero: " + compra.ChequesTerceros.Count.ToString(), "").ToString() & " - Transf. desde: " & compra.CuentaBancariaTransfBanc.NombreCuenta & ". " & compra.Proveedor.NombreProveedor, 100)
                  '.IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAPAGO"))
                  .IdCuentaCaja = compra.Proveedor.CuentaDeCaja.IdCuentaCaja
                  .EsModificable = False
                  .GeneraContabilidad = False
                  .Usuario = actual.Nombre
               End With

               'Por ahora marco los cheques con el movimiento, aunque en realidad no lo sume en el movimiento de Caja.
               rCajaDetalle.InsertarNuevoMovimiento(deta)


               Dim totalAcreditado = compra.CuponesTarjetasLiquidacion.Where(Function(c) c.IdEstadoTarjeta = Entidades.TarjetaCupon.Estados.ACREDITADO).SumSecure(Function(c) c.TarjetaCupon.Monto).IfNull()
               If totalAcreditado <> 0 Then
                  deta = New Entidades.CajaDetalles(compra.IdSucursal, compra.Usuario, compra.Password)

                  With deta
                     .FechaMovimiento = compra.Fecha      'DateTime.Now
                     .IdSucursal = compra.IdSucursal
                     .IdCaja = compra.IdCaja
                     .IdTipoMovimiento = "E"c
                     .NumeroPlanilla = rCaja.GetPlanillaActual(compra.IdSucursal, compra.IdCaja).NumeroPlanilla
                     .Observacion = String.Format("ANUL {0} {1} {2}-{3:00000000}. {4}",
                                                     compra.TipoComprobante.Descripcion, compra.Letra, compra.CentroEmisor.ToString(), compra.NumeroComprobante,
                                                     compra.Proveedor.NombreProveedor).Truncar(100)
                     '.IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor(Parametro.Parametros.CTACAJACOMPRAS))
                     .IdCuentaCaja = Publicos.CtaCajaDeposito
                     .ImporteTarjetas = totalAcreditado
                     .ImporteBancos = totalAcreditado * -1
                     .IdMonedaImporteBancos = compra.CuentaBancariaTransfBanc.Moneda.IdMoneda
                     If .IdMonedaImporteBancos = 0 Then
                        .IdMonedaImporteBancos = Entidades.Moneda.Peso
                     End If
                     .ImporteCheques = 0
                     .ImportePesos = 0
                     .ImporteRetenciones = 0
                     .ImporteDolares = 0
                     .CotizacionDolar = compra.CotizacionDolar
                     .EsModificable = False
                     .GeneraContabilidad = False
                     .Usuario = actual.Nombre
                  End With

                  rCajaDetalle.AgregaMovimiento(deta, Publicos.ConvierteChequesTercerosEnArray(compra.ChequesTerceros), Publicos.ConvierteChequesPropiosEnArray(compra.ChequesPropios))

                  Dim rLibroBancos = New LibroBancos(da)
                  Dim rTarjetas = New Tarjetas(da)
                  For Each cupon In compra.CuponesTarjetasLiquidacion
                     Dim tarj = rTarjetas._GetUno(cupon.TarjetaCupon.IdTarjeta)
                     Dim entLibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd) With {
                           .IdSucursal = cupon.IdSucursal,
                           .IdCuentaBancaria = tarj.CuentaBancaria.IdCuentaBancaria,
                           .NumeroMovimiento = rLibroBancos.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria),
                           .IdCuentaBanco = Publicos.CtaBancoDeposito,
                           .IdTipoMovimiento = "I",
                           .Importe = cupon.TarjetaCupon.Monto,
                           .FechaMovimiento = compra.Fecha,
                           .FechaAplicado = cupon.TarjetaCupon.FechaEmision,
                           .Observacion = String.Format("ANUL {0} {1} {2}-{3:00000000}. {0}",
                                                        compra.TipoComprobante.Descripcion, compra.Letra, compra.CentroEmisor, compra.NumeroComprobante,
                                                        compra.Proveedor.NombreProveedor).Truncar(100),
                           .Conciliado = False
                        }

                     rLibroBancos.AgregaMovimiento(entLibroBanco)
                  Next
               End If


               'Si Pagó parte con Transfencia Bancaria
               'If compra.ImporteTransfBancaria > 0 Then

               '   With deta
               '      .FechaMovimiento = compra.Fecha     'DateTime.Now
               '      .IdSucursal = compra.IdSucursal
               '      .IdTipoMovimiento = "E"c
               '      .NumeroPlanilla = caj.GetPlanillaActual(compra.IdSucursal, compra.IdCaja).NumeroPlanilla
               '      .ImportePesos = compra.ImporteTransfBancaria
               '      .ImporteCheques = 0
               '      .ImporteTickets = 0
               '      .ImporteTarjetas = 0
               '      .Observacion = Strings.Left("ANULA " & compra.TipoComprobante.Descripcion & " " & compra.Letra & " " & compra.CentroEmisor.ToString() & "-" & compra.NumeroComprobante.ToString("00000000") & " - Transf. desde: " & compra.CuentaBancariaTransfBanc.NombreCuenta & ". " & compra.Proveedor.NombreProveedor, 100)
               '      .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.CTACAJATRANSFBANCARIA))
               '      .EsModificable = False
               '      .Usuario = actual.Nombre
               '   End With

               '   cajaDet.AgregaMovimiento(deta, Nothing, Nothing)

               'End If

            End If


            'si el Cliente compro el modulo de Banco registro el movimiento de Cheques Propios entregados

            If Publicos.TieneModuloBanco Then  ' Boolean.Parse(New Eniac.Reglas.Parametros(da)._GetValor(Entidades.Parametro.Parametros.MODULOBANCO)) Then

               Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos(da)
               Dim entLibroBanco As Entidades.LibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
               Dim oLibBanco As Eniac.Reglas.LibroBancos = New Eniac.Reglas.LibroBancos(da)

               For Each cheq As Entidades.Cheque In compra.ChequesPropios

                  oLibBanco.EliminarMovimientoPorCheque(cheq.IdCheque)

               Next


               'Si Pagó parte con Transfencia Bancaria
               If compra.ImporteTransfBancaria <> 0 Then

                  With entLibroBanco
                     .IdSucursal = compra.IdSucursal
                     .IdCuentaBancaria = compra.CuentaBancariaTransfBanc.IdCuentaBancaria
                     .NumeroMovimiento = oLibBanco.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCuentaBancaria)

                     If compra.Proveedor.CuentaBanco.IdCuentaBanco > 0 Then
                        .IdCuentaBanco = compra.Proveedor.CuentaBanco.IdCuentaBanco
                     Else
                        .IdCuentaBanco = Reglas.Publicos.CtaBancoTransfBancaria
                     End If

                     .IdTipoMovimiento = If(compra.ImporteTransfBancaria > 0, "I", "E")
                     .Importe = compra.ImporteTransfBancaria
                     .FechaMovimiento = compra.Fecha
                     .IdCheque = Nothing
                     .FechaAplicado = compra.Fecha
                     '.Observacion = ent.Observacion
                     .Observacion = Strings.Left("ANULA " & compra.TipoComprobante.Descripcion & " " & compra.Letra & " " & compra.CentroEmisor.ToString() & "-" & compra.NumeroComprobante.ToString("00000000") & " - Transf. a Caja" & ". " & compra.Proveedor.NombreProveedor, 100)
                     .Conciliado = False
                  End With

                  oLibroBancos.AgregaMovimiento(entLibroBanco)

               End If

            End If

         End If







         'Si es Contado verifico si tiene el modulo de Caja, hago un contrasiento
         'If oCompra.FormaPago.Dias = 0 Then
         '   'si el cliente compro el modulo de caja
         '   If Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.MODULOCAJA)) Then
         '      'si el tipo de comprobante afecta la caja, porque puede suceder que no la afecte
         '      'ya que si es un cliente que tiene fichas y despues factura por aca se complica
         '      If oCompra.TipoComprobante.AfectaCaja Then
         '         Dim deta As Entidades.CajaDetalles = New Entidades.CajaDetalles(oCompra.IdSucursal, oCompra.Usuario, oCompra.Password)
         '         Dim caj As Reglas.Cajas = New Reglas.Cajas(da)
         '         Dim ctaCaj As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas(da)
         '         Dim cajaDet As Reglas.CajaDetalles = New Reglas.CajaDetalles(da)

         '         With deta
         '            .FechaMovimiento = oCompra.Fecha     'Date.Now
         '            .IdSucursal = oCompra.IdSucursal
         '            .IdCaja = oCompra.IdCaja
         '            'Invierto el tipo de movimiento.
         '            If oCompra.TipoComprobante.CoeficienteValores = 1 Then
         '               .IdTipoMovimiento = "I"c
         '            Else
         '               .IdTipoMovimiento = "E"c
         '            End If

         '            .NumeroPlanilla = caj.GetPlanillaActual(oCompra.IdSucursal, oCompra.IdCaja).NumeroPlanilla
         '            .NumeroMovimiento = cajaDet.GetProximoNumeroDeMovimiento(.IdSucursal, .IdCaja, .NumeroPlanilla)
         '            .Observacion = Strings.Left("ANULA " & oCompra.TipoComprobante.DescripcionAbrev & " " & oCompra.Letra & " " & oCompra.CentroEmisor.ToString() & "-" & oCompra.NumeroComprobante.ToString("00000000") & ". " & oCompra.Proveedor.NombreProveedor, 100)
         '            '.IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJACOMPRAS"))
         '            .IdCuentaCaja = oCompra.Proveedor.CuentaDeCaja.IdCuentaCaja

         '            'me fijo si es Efectivo o Tarjeta para cargar el tipo de cuenta en la caja
         '            .ImportePesos = oCompra.ImporteTotal * oCompra.TipoComprobante.CoeficienteValores
         '            .EsModificable = False
         '            .Usuario = actual.Nombre
         '         End With

         'cajaDet.InsertarNuevoMovimiento(deta)

         '      End If
         '   End If
         'End If

         'eliminar Movimientos compras productos
         'eliminar Movimientos compras
         Dim movcom = New Reglas.MovimientosStock(da)
         Dim movicom As Entidades.MovimientoStock

         movicom = movcom.GetUnoPorComprobante(oCompra.IdSucursal, oCompra.TipoComprobante.IdTipoComprobante, oCompra.Letra, oCompra.CentroEmisor,
                                               oCompra.NumeroComprobante, oCompra.Proveedor.IdProveedor)
         Dim movicomprod = New MovimientosStockProductos(da)


         ' # Descontar stock actual del lote y de la 'Cantidad Inicial/Comprada/Fabricada'
         Dim rProductoLote As Reglas.ProductosLotes = New Reglas.ProductosLotes(da)
         Dim lotes = New List(Of Entidades.ProductoLote)
         Dim eProductoLote As Entidades.ProductoLote

         Dim idLote As String = String.Empty
         Dim idProducto As String = String.Empty
         Dim idSucursal As Integer = 0
         Dim cantidad As Decimal = 0
         Dim aDescontar As Decimal = 0

         If movicom.Productos.Count > 0 Then
            For Each item In movicom.Productos
               idLote = item.IdLote
               idProducto = item.IdProducto
               idSucursal = item.IdSucursal
               cantidad = item.Cantidad

               If Not String.IsNullOrEmpty(idLote) Then
                  eProductoLote = rProductoLote._GetUno(idProducto, idLote, idSucursal, item.IdDeposito, item.IdUbicacion)
                  aDescontar = cantidad 'eProductoLote.CantidadActual - cantidad

                  ' # Si el stock actual del lote es menor a la cantidad a descontar, se arroja una exception para no permitir eliminar la compra.
                  If aDescontar < 0 Then Throw New Exception("El stock actual del lote es MENOR a la cantidad que se debe descontar. No se puede eliminar la compra.")

                  ' # Seteo los valores a descontar
                  eProductoLote.CantidadActual = aDescontar * -1
                  eProductoLote.CantidadInicial = aDescontar * -1
                  lotes.Add(eProductoLote)

               End If
            Next

            ' # Actualizo lotes
            rProductoLote.ActualizoLotes(lotes)

         End If

         '--------------------------------------------------

         '# Elimino los movimientos de productos con Nro. Serie asociados
         Dim rMovimientosComprasProductosNrosSerie = New MovimientosStockProductosNrosSerie(da)
         rMovimientosComprasProductosNrosSerie._Borra(New Entidades.MovimientoStockProductoNrosSerie With {.IdSucursal = movicom.IdSucursal,
                                                                                                           .IdTipoMovimiento = movicom.TipoMovimiento.IdTipoMovimiento,
                                                                                                           .NumeroMovimiento = movicom.NumeroMovimiento})

         'En caso que el Comprobante no afecta Stock y/o sus productos, no genero los registros.
         'Pero lo importante es la utilizacion mas abajo.
         If movicom.Productos.Count > 0 Then
            movicomprod.EliminarPorComprobante(movicom)
         End If

         movcom.EliminarMovimientosStock(movicom)

         'Liberar Invocados
         Dim oInvocados As Reglas.Compras = New Reglas.Compras(da)

         Dim TotalNeto As Decimal = 0

         Dim dtDetalle As DataTable

         dtDetalle = oInvocados.GetInvocadosCom(oCompra.IdSucursal,
                                         oCompra.TipoComprobante.IdTipoComprobante,
                                         oCompra.Letra,
                                         oCompra.CentroEmisor,
                                         oCompra.NumeroComprobante,
                                         oCompra.Proveedor.IdProveedor)
         For Each dr As DataRow In dtDetalle.Rows
            oInvocados.LiberarInvocados(Integer.Parse(dr("IdSucursal").ToString()), dr("IdTipoComprobante").ToString(),
                                         dr("Letra").ToString(), Short.Parse(dr("CentroEmisor").ToString()), Long.Parse(dr("NumeroComprobante").ToString()),
                                         Long.Parse(dr("IdProveedor").ToString()))

         Next

         'Eliminar Detalle de Productos
         Dim ocom As Entidades.Compra = New Reglas.Compras(da).GetUna(oCompra.IdSucursal, oCompra.TipoComprobante.IdTipoComprobante, oCompra.Letra, oCompra.CentroEmisor, oCompra.NumeroComprobante, oCompra.Proveedor.IdProveedor)

         '# Elimino los productos que tengan Nro. Serie de la compra asociada
         Dim rComprasProductosNrosSerie As Reglas.ComprasProductosNrosSerie = New Reglas.ComprasProductosNrosSerie(da)
         rComprasProductosNrosSerie._Borra(New Entidades.CompraProductoNroSerie With {.IdSucursal = oCompra.IdSucursal,
                                                                                      .IdTipoComprobante = oCompra.IdTipoComprobante,
                                                                                      .Letra = oCompra.Letra,
                                                                                      .CentroEmisor = oCompra.CentroEmisor,
                                                                                      .NumeroComprobante = oCompra.NumeroComprobante,
                                                                                      .IdProveedor = oCompra.Proveedor.IdProveedor})

         Dim oComprasProd As Reglas.ComprasProductos = New Reglas.ComprasProductos(da)
         Dim oPro As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)
         For Each com As Entidades.CompraProducto In ocom.ComprasProductos
            oComprasProd.Eliminar(oCompra.IdSucursal, oCompra.TipoComprobante.IdTipoComprobante, oCompra.Letra,
                                  oCompra.CentroEmisor, oCompra.NumeroComprobante, oCompra.Proveedor.IdProveedor,
                                  com.Orden, com.ProductoSucursal.Producto.IdProducto)

            If movicom.Productos.Count > 0 Then
               Dim emb = 1
               If com.ProductoSucursal.Producto.PrecioPorEmbalaje Then
                  emb = com.ProductoSucursal.Producto.Embalaje
               End If
               com.Cantidad *= oCompra.TipoComprobante.CoeficienteStock
               oPro.ActualizarStock(com.IdSucursal, com.IdDeposito, com.IdUbicacion, com.ProductoSucursal.Producto.IdProducto, -com.Cantidad * emb, 0, 0, 0, 0,
                                       com.IdaAtributoProducto01, com.IdaAtributoProducto02, com.IdaAtributoProducto03, com.IdaAtributoProducto04)

            End If

         Next

         Dim sql2 As SqlServer.ComprasObservaciones = New SqlServer.ComprasObservaciones(da)
         sql2.ComprasObservaciones_D2(oCompra.IdSucursal, oCompra.TipoComprobante.IdTipoComprobante, oCompra.Letra, oCompra.CentroEmisor, oCompra.NumeroComprobante, oCompra.Proveedor.IdProveedor)

         Dim sqlCI As SqlServer.ComprasImpuestos = New SqlServer.ComprasImpuestos(da)
         sqlCI.ComprasImpuestos_D(oCompra.IdSucursal, oCompra.TipoComprobante.IdTipoComprobante, oCompra.Letra, oCompra.CentroEmisor, oCompra.NumeroComprobante, oCompra.Proveedor.IdProveedor, 0, String.Empty)



         '**** INICIO LIBERA PEDIDOS
         'Actualizo Pedidos
         Dim sqlP As SqlServer.PedidosProveedores = New SqlServer.PedidosProveedores(da)
         Dim sqlPP As SqlServer.PedidosProductosProveedores = New SqlServer.PedidosProductosProveedores(da)
         Dim rPP As Reglas.PedidosProductosProveedores = New PedidosProductosProveedores(da)
         Dim sqlPE As SqlServer.PedidosEstadosProveedores = New SqlServer.PedidosEstadosProveedores(da)
         Dim rPE As PedidosEstadosProveedores = New PedidosEstadosProveedores(da)

         Dim pedidosEstados As DataTable = sqlPE.PedidosEstadosProveedores_G_PorComprobanteFact(oCompra.IdSucursal,
                                                                 oCompra.TipoComprobante.IdTipoComprobante, oCompra.Letra,
                                                                 oCompra.CentroEmisor, oCompra.NumeroComprobante)

         'TODO: Hay que ver como parametrizar esto diferente
         'SPC: Hay que ver como parametrizar esto diferente
         Dim tipoTipoComprobante As String = "PEDIDOSPROV"
         If pedidosEstados.Rows.Count > 0 Then
            tipoTipoComprobante = New Reglas.TiposComprobantes(da).GetUno(pedidosEstados.Rows(0)("IdTipoComprobante").ToString()).Tipo
         End If

         Dim _cache As BusquedasCacheadas = New BusquedasCacheadas()

         Dim idEstadoAnterior As String
         Dim idTipoEstadoAnterior As String '= New EstadosPedidos(da).GetUno(Publicos.EstadoPedidoFacturado, tipoTipoComprobante).IdTipoEstado
         Dim estadosFacturables = _cache.BuscaEstadosPedidoProveedoresParaFacturar(tipoTipoComprobante)
         If estadosFacturables.AnySecure() Then
            Dim idEstadoNuevo As String = estadosFacturables.First().IdEstado ' Publicos.PedidoProveedorEstadoAFacturar
            Dim idTipoEstadoNuevo As String = estadosFacturables.First().IdTipoEstado ' New EstadosPedidosProveedores(da).GetUno(idEstadoNuevo, tipoTipoComprobante).IdTipoEstado
            Dim fechaNuevoEstado As DateTime = Now
            For Each dr As DataRow In pedidosEstados.Rows

               idEstadoAnterior = dr("IdEstado").ToString()
               idTipoEstadoAnterior = _cache.BuscaEstadosPedidoProveedores(idEstadoAnterior, tipoTipoComprobante).IdTipoEstado

               If oCompra.TipoComprobante.AlInvocarPedidoAfectaFactura Then
                  sqlPE.PedidosEstadosProveedores_U_Anular_Fact(Integer.Parse(dr("IdSucursal").ToString()),
                                    dr("IdTipoComprobante").ToString(),
                                    dr("Letra").ToString(),
                                    Short.Parse(dr("CentroEmisor").ToString()),
                                    Long.Parse(dr("NumeroPedido").ToString()),
                                    dr("IdProducto").ToString(),
                                    Date.Parse(dr("FechaEstado").ToString()),
                                    Integer.Parse(dr("Orden").ToString()))
               End If

               If oCompra.TipoComprobante.AlInvocarPedidoAfectaRemito Then
                  sqlPE.PedidosEstados_U_Anular_Remito(Integer.Parse(dr("IdSucursal").ToString()),
                                    dr("IdTipoComprobante").ToString(),
                                    dr("Letra").ToString(),
                                    Short.Parse(dr("CentroEmisor").ToString()),
                                    Long.Parse(dr("NumeroPedido").ToString()),
                                    dr("IdProducto").ToString(),
                                    Date.Parse(dr("FechaEstado").ToString()),
                                    Integer.Parse(dr("Orden").ToString()))
               End If

               If oCompra.TipoComprobante.InvocarPedidosConEstadoEspecifico Then
                  sqlPE.PedidosEstados_U_Anular_Estado(Integer.Parse(dr("IdSucursal").ToString()),
                                             dr("IdTipoComprobante").ToString(),
                                             dr("Letra").ToString(),
                                             Short.Parse(dr("CentroEmisor").ToString()),
                                             Long.Parse(dr("NumeroPedido").ToString()),
                                             dr("IdProducto").ToString(),
                                             Date.Parse(dr("FechaEstado").ToString()),
                                             Integer.Parse(dr("Orden").ToString()),
                                             idEstadoNuevo,
                                             tipoTipoComprobante,
                                             fechaNuevoEstado,
                                             "Factura anulada")

                  rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(Integer.Parse(dr("IdSucursal").ToString()),
                                                                  dr("IdTipoComprobante").ToString(),
                                                                  dr("Letra").ToString(),
                                                                  Short.Parse(dr("CentroEmisor").ToString()),
                                                                  Long.Parse(dr("NumeroPedido").ToString()),
                                                                  dr("IdProducto").ToString(),
                                                                  Integer.Parse(dr("Orden").ToString()),
                                                                  idTipoEstadoAnterior,
                                                                  idTipoEstadoNuevo,
                                                                  Decimal.Parse(dr("CantEntregada").ToString()))

                  '' ''rPE.ReservaProducto(Integer.Parse(dr("IdSucursal").ToString()),
                  '' ''                                      dr("IdTipoComprobante").ToString(),
                  '' ''                                      dr("Letra").ToString(),
                  '' ''                                      Short.Parse(dr("CentroEmisor").ToString()),
                  '' ''                                      Long.Parse(dr("NumeroPedido").ToString()),
                  '' ''                                      dr("IdProducto").ToString(),
                  '' ''                                      Integer.Parse(dr("Orden").ToString()),
                  '' ''                                      idEstadoAnterior, idEstadoNuevo, tipoTipoComprobante, Decimal.Parse(dr("cantEntregada").ToString()),
                  '' ''                                      Entidad.MetodoGrabacion.Automatico, IdFuncion)

                  fechaNuevoEstado = fechaNuevoEstado.AddSeconds(1)
               End If            'If oVentas.TipoComprobante.InvocarPedidosConEstadoEspecifico Then
            Next
            '**** FIN LIBERA PEDIDOS
         End If

         Dim cTransf = New ComprasTransferencias(da)
         cTransf._Borrar(oCompra)

         'Revertir Estado de tarjetas liquidadas
         Dim rCompraTarjetas = New ComprasTarjetas(da)
         Dim rCupones = New TarjetasCupones(da)
         oCompra.CuponesTarjetasLiquidacion.ForEach(Sub(c) rCupones.ActualizaEstado(c.IdTarjetaCupon, c.IdEstadoTarjeta, c.IdEstadoTarjetaAnt))
         rCompraTarjetas._Borrar(oCompra)

         'Eliminar Retenciones generadas en la Liquidación
         Dim rCompraRetenciones = New ComprasRetenciones(da)
         Dim rReten = New Retenciones(da)
         rCompraRetenciones._Borrar(oCompra)
         rReten._Borrar(oCompra.Retenciones.ConvertAll(Function(cr) cr.Retencion))

         'Eliminar Compra
         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)
         sql.Compras_D(oCompra.IdSucursal, oCompra.TipoComprobante.IdTipoComprobante, oCompra.Letra, oCompra.CentroEmisor, oCompra.NumeroComprobante, oCompra.Proveedor.IdProveedor)

         'Quito el Saldo de la compra eliminada.
         If oCompra.TipoComprobante.GrabaLibro And oCompra.Proveedor.CategoriaFiscal.IvaDiscriminado Then

            Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales(da)

            Dim Neto As Decimal = oCompra.TotalNeto
            Dim IVA As Decimal = oCompra.TotalIVA

            oPF.ActualizarPosicion(oCompra.IdEmpresa, oCompra.PeriodoFiscal, 0, 0, 0, Neto * (-1), IVA * (-1), oCompra.ImporteTotal * (-1), 0, oCompra.PercepcionIVA * (-1))

         End If

         'If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea AndAlso
         If Publicos.TieneModuloContabilidad AndAlso
            oCompra.IdEjercicio.HasValue AndAlso oCompra.IdPlanCuenta.HasValue AndAlso oCompra.IdAsiento.HasValue Then
            Dim ctbl As Contabilidad = New Contabilidad(da)
            ctbl.AnularAsiento(oCompra.IdEjercicio.Value, oCompra.IdPlanCuenta.Value, oCompra.IdAsiento.Value, Today)
         End If

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Protected Overridable Sub EliminarCompraAdicionales(compra As Entidades.Compra)

   End Sub

   Public Function GetPorRangoFechas(sucursales As Entidades.Sucursal(),
                                     idEmpresa As Integer, periodoFiscal As Integer,
                                     desde As Date, hasta As Date,
                                     idProveedor As Long, IdComprador As Integer,
                                     grabaLibro As String, afectaCaja As String, esComercial As String,
                                     tipoComprobante As String, numeroComprobante As Long,
                                     idFormasPago As Integer, idRubro As Integer,
                                     estado As String, idCategoria As Integer, idUsuario As String, idCentroCosto As Integer,
                                     idMoneda As Integer, tipoConversion As Entidades.Moneda_TipoConversion, cotizDolar As Decimal) As DataTable
      Return New SqlServer.Compras(da).GetPorRangoFechas(sucursales,
                                                         idEmpresa, periodoFiscal,
                                                         desde, hasta,
                                                         idProveedor, IdComprador,
                                                         grabaLibro, afectaCaja, esComercial,
                                                         tipoComprobante, numeroComprobante,
                                                         idFormasPago, idRubro,
                                                         estado, idCategoria, idUsuario, idCentroCosto,
                                                         idMoneda, tipoConversion, cotizDolar,
                                                         actual.NivelAutorizacion,
                                                         ContabilidadPublicos.UtilizaCentroCostos)
   End Function

   Public Function GetLibroDeIVA(idEmpresa As Integer, periodoFiscal As Integer, orden As String,
                                 IdComprador As Integer) As DataTable
      Return New SqlServer.Compras(da).GetLibroDeIVA(idEmpresa, periodoFiscal, orden, IdComprador)
   End Function
   Public Function GetLibroDeIVADinamico(idEmpresa As Integer, periodoFiscal As Integer, orden As String,
                              IdComprador As Integer, agrupa As Boolean) As DataTable
      Return New SqlServer.Compras(da).GetLibroDeIVADinamico(idEmpresa, periodoFiscal, orden, IdComprador, agrupa)
   End Function
   Public Function GetResumenDeCompras(sucursales As Entidades.Sucursal(),
                                       idEmpresa As Integer,
                                       periodoFiscalDesde As Integer,
                                       periodoFiscalhasta As Integer,
                                       grabaLibro As String,
                                       afectaCaja As String,
                                       esComercial As String,
                                       informaLibroIva As String,
                                       agrupadoPorSucursal As Boolean,
                                       separarNetos As Boolean) As DataSet
      Dim ds As DataSet = New DataSet()
      Try
         da.OpenConection()
         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)
         ds.Tables.Add(Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra.ToString(),
                       sql.GetResumenDeCompras(sucursales, idEmpresa, periodoFiscalDesde, periodoFiscalhasta, grabaLibro, afectaCaja, esComercial,
                                               informaLibroIva, agrupadoPorSucursal, Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra,
                                               separarNetos))

         ds.Tables.Add(Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal.ToString(),
                       sql.GetResumenDeCompras(sucursales, idEmpresa, periodoFiscalDesde, periodoFiscalhasta, grabaLibro, afectaCaja, esComercial,
                                               informaLibroIva, agrupadoPorSucursal, Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal,
                                               separarNetos))

         ds.Tables.Add(Entidades.ResumenDeVenta_AgrupadoPor.RubroCompra.ToString(),
                       sql.GetResumenDeCompras(sucursales, idEmpresa, periodoFiscalDesde, periodoFiscalhasta, grabaLibro, afectaCaja, esComercial,
                                               informaLibroIva, agrupadoPorSucursal, Entidades.ResumenDeVenta_AgrupadoPor.RubroCompra,
                                               separarNetos))

         ds.Tables.Add(Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto.ToString(),
                       sql.GetResumenDeCompras(sucursales, idEmpresa, periodoFiscalDesde, periodoFiscalhasta, grabaLibro, afectaCaja, esComercial,
                                               informaLibroIva, agrupadoPorSucursal, Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto,
                                               separarNetos))
      Finally
         da.CloseConection()
      End Try

      Return ds
   End Function
   Public Function GetResumenDeComprasDetalle(sucursales As Entidades.Sucursal(),
                                       idEmpresa As Integer,
                                       periodoFiscalDesde As Integer,
                                       periodoFiscalhasta As Integer,
                                       grabaLibro As String,
                                       afectaCaja As String,
                                       esComercial As String,
                                       informaLibroIva As String,
                                       agrupadoPorSucursal As Boolean,
                                       separarNetos As Boolean,
                                       tiposDeComprobantes As Entidades.TipoComprobante(),
                                       rubrosCompra As Entidades.RubroCompra(),
                                       categoriaFiscales As Entidades.CategoriaFiscal()) As DataTable
      Dim dt As DataTable
      Try
         da.OpenConection()
         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)
         dt = sql.GetResumenDeComprasDetalle(sucursales, idEmpresa, periodoFiscalDesde, periodoFiscalhasta, grabaLibro, afectaCaja, esComercial,
                                               informaLibroIva, agrupadoPorSucursal, Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra,
                                             separarNetos, tiposDeComprobantes, rubrosCompra, categoriaFiscales)
      Finally
         da.CloseConection()
      End Try

      Return dt
   End Function
   Public Function GetTotalPorProveedor(Sucursal As Integer, Desde As Date, Hasta As Date, Optional IdProveedor As Long = 0) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("Select C.IdProveedor")
         .Append("   , P.CodigoProveedor")
         .Append("   , P.NombreProveedor")
         .Append("   , SUM(CP.ImporteTotal) As Total ")
         .Append("   , SUM(CP.Utilidad) As Utilidad ")
         .Append("     FROM Compras C, ComprasProductos CP, TiposComprobantes TC, Proveedores P ")
         .Append("    WHERE C.IdSucursal = CP.IdSucursal ")
         .Append("      And C.IdTipoComprobante = CP.IdTipoComprobante ")
         .Append("      And C.Letra = CP.Letra ")
         .Append("      And C.CentroEmisor = CP.CentroEmisor ")
         .Append("      And C.NumeroComprobante = CP.NumeroComprobante ")
         .Append("      And C.IdProveedor = P.IdProveedor ")
         .Append("      And C.IdTipoComprobante = TC.IdTipoComprobante ")
         .Append("      And TC.AfectaCaja = 'True' ")    'Contemplo solo aquellos comprobantes que manejan dinero
         .Append("	   AND C.IdSucursal = " & Sucursal.ToString())
         .Append("	   AND CONVERT(varchar(11), C.fecha, 120) >= '" & Strings.Format(Desde, "yyyy-MM-dd") & "'")
         .Append("	   AND CONVERT(varchar(11), C.fecha, 120) <= '" & Strings.Format(Hasta, "yyyy-MM-dd") & "'")

         If IdProveedor > 0 Then
            .Append("	AND C.IdProveedor = " & IdProveedor.ToString())
         End If

         .Append("	GROUP BY C.IdProveedor, P.CodigoProveedor, P.NombreProveedor")
      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function GetTotalPorProducto(Sucursal As Integer, Desde As Date, Hasta As Date, Optional Marca As Integer = 0, Optional Rubro As Integer = 0, Optional IdProducto As String = "") As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Dim strFiltro As String

      With stb
         .Length = 0
         .Append("SELECT CP.IdProducto as IdProducto ")
         .Append("   ,P.NombreProducto as NombreProducto ")
         .Append("   ,SUM(CP.ImporteTotal) as Total ")
         .Append("   ,SUM(CP.Utilidad) as Utilidad ")
         .Append("     FROM Compras C, ComprasProductos CP, TiposComprobantes TC, Productos P ")
         .Append("    WHERE C.IdSucursal = CP.IdSucursal ")
         .Append("      AND C.IdTipoComprobante = CP.IdTipoComprobante ")
         .Append("      AND C.Letra = CP.Letra ")
         .Append("      AND C.CentroEmisor = CP.CentroEmisor ")
         .Append("      AND C.NumeroComprobante = CP.NumeroComprobante ")
         .Append("      AND C.IdTipoComprobante = TC.IdTipoComprobante ")
         .Append("      AND CP.IdProducto = P.IdProducto ")
         .Append("      AND TC.AfectaCaja = 'True' ")    'Contemplo solo aquellos comprobantes que manejan dinero
         .Append("	   AND C.IdSucursal = " & Sucursal.ToString())
         .Append("	   AND CONVERT(varchar(11), C.fecha, 120) >= '" & Strings.Format(Desde, "yyyy-MM-dd") & "'")
         .Append("	   AND CONVERT(varchar(11), C.fecha, 120) <= '" & Strings.Format(Hasta, "yyyy-MM-dd") & "'")

         If Not String.IsNullOrEmpty(IdProducto) Then
            .Append("	AND CP.IdProducto = '" & IdProducto & "'")
         End If

         If Marca > 0 Or Rubro > 0 Then
            .Append(" AND CP.IdProducto in ( ")
            .Append(" SELECT P.IdProducto FROM Productos P WHERE ")

            strFiltro = ""
            If Marca <> 0 Then
               strFiltro = strFiltro & " AND P.IdMarca = " & Marca.ToString()
            End If
            If Rubro <> 0 Then
               strFiltro = strFiltro & " AND P.IdRubro = " & Rubro.ToString()
            End If

            .Append(strFiltro.Substring(4) & " )")

         End If

         .Append("	GROUP BY CP.IdProducto, P.NombreProducto")
      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function Existe(idSucursal As Integer,
                          idProveedor As Long,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Short,
                          numeroComprobante As Long) As Boolean

      Try

         'No estan todos los campos, no puedo validar
         If idProveedor = 0 OrElse
            String.IsNullOrEmpty(idTipoComprobante) OrElse
            String.IsNullOrEmpty(letra) OrElse
            centroEmisor = 0 OrElse
            numeroComprobante = 0 Then

            Return False

         End If

         'Me.da.OpenConection()

         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)
         Dim existeTC As Boolean
         ''Deberia venir en 0, para que busque el comprobante en todas las sucursales
         'If idSucursal > 0 Then
         existeTC = sql.Existe(idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante)

         'Unifico la llamada porque ahora el Existe que tiene idSucursal si es 0, la ignora en el query como lo hacia la otra.
         'Else
         'existeTC = sql.Existe(idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante)
         'End If

         If Not existeTC Then
            Dim sqlV As SqlServer.Ventas = New SqlServer.Ventas(da)
            'Busco numeradores relacionados a este numerador.
            'Por ejemplo REMITOCOMTRANS puede estar relacionado a REMITOTRANS y debería controlar que no se haya generado
            'un comprobante también con esos tipos de comprobante
            Dim dtTC As DataTable = New SqlServer.VentasNumeros(da).VentasNumeros_G1(actual.Sucursal.IdEmpresa, idTipoComprobante, letra, centroEmisor)
            If dtTC.Rows.Count > 0 Then
               'Busco el comprobante sin proveedor porque al ser numerador unificado puede estar el número con otro proveedor
               existeTC = sql.Existe(idSucursal, 0, idTipoComprobante, letra, centroEmisor, numeroComprobante)
               If Not existeTC Then

                  For Each idTipoComprobanteRelacionado As String In dtTC(0)("IdTipoComprobanteRelacionado").ToString().Split(","c)
                     'Para cada tipo de comprobante relacionado (si no está en blanco) verifico si existe o no en ventas
                     If Not String.IsNullOrWhiteSpace(idTipoComprobanteRelacionado) Then
                        existeTC = sqlV.Existe(actual.Sucursal.IdSucursal, idTipoComprobanteRelacionado, letra, centroEmisor, numeroComprobante)
                        'Si lo encontré con este tipo de comprobante relacionado salgo 
                        'del FOR para que no me cambie el valor si hay otro relacionado.
                        If existeTC Then Exit For
                        'Busco con IdProveedor = 0 porque es un comprobante con numerador unificado entre ventas y compras
                        existeTC = sql.Existe(actual.Sucursal.IdSucursal, 0, idTipoComprobanteRelacionado, letra, centroEmisor, numeroComprobante)
                        If existeTC Then Exit For
                     End If   'If Not String.IsNullOrWhiteSpace(idTipoComprobanteRelacionado) Then
                  Next        'For Each idTipoComprobanteRelacionado As String In dtTC(0)("IdTipoComprobanteRelacionado").ToString().Split(","c)
               End If         'Segundo If Not existeTC Then
            End If            'If dtTC.Rows.Count > 0 Then
         End If               'Primer  If Not existeTC Then

         Return existeTC
      Catch ex As Exception
         Throw
         'Finally
         'Me.da.CloseConection()
      End Try

   End Function

   Public Function GetUna(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          numeroComprobante As Long,
                          IdProveedor As Long) As Entidades.Compra

      Dim stb = New StringBuilder()

      With stb
         .AppendLine("SELECT C.* ")
         .AppendLine("      ,P.CodigoProveedor")

         .AppendLine(" FROM Compras C")
         .AppendLine(" INNER JOIN Proveedores P ON P.IdProveedor = C.IdProveedor")
         .AppendLine(" WHERE P.IdProveedor = " & IdProveedor)
         .AppendLine("   AND C.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND C.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND C.Letra = '" & letra & "'")
         .AppendLine("   AND C.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND C.NumeroComprobante = " & numeroComprobante.ToString())

      End With


      Using dt = da.GetDataTable(stb.ToString())
         If dt.Rows.Count > 0 Then
            Dim compra = New Entidades.Compra()
            With compra

               .IdSucursal = Integer.Parse(dt.Rows(0)("IdSucursal").ToString())
               .Letra = dt.Rows(0)("Letra").ToString()
               .CentroEmisor = Short.Parse(dt.Rows(0)("CentroEmisor").ToString())
               .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dt.Rows(0)("IdTipoComprobante").ToString())
               .NumeroComprobante = Long.Parse(dt.Rows(0)("NumeroComprobante").ToString())
               .IdEstadoComprobante = dt.Rows(0).Field(Of String)(Entidades.Compra.Columnas.IdEstadoComprobante.ToString())

               .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(dt.Rows(0)("IdProveedor").ToString))
               .DescuentoRecargo = Decimal.Parse(dt.Rows(0)("DescuentoRecargo").ToString())
               .Fecha = Date.Parse(dt.Rows(0)("Fecha").ToString())
               .FormaPago = New VentasFormasPago(da).GetUna(Integer.Parse(dt.Rows(0)("IdFormasPago").ToString()))
               .ImporteTotal = Decimal.Parse(dt.Rows(0)("ImporteTotal").ToString())

               .DescuentoRecargoPorc = Decimal.Parse(dt.Rows(0)("DescuentoRecargoPorc").ToString())
               .DescuentoRecargo = Decimal.Parse(dt.Rows(0)("DescuentoRecargo").ToString())
               .CotizacionDolar = Decimal.Parse(dt.Rows(0)("CotizacionDolar").ToString())

               .IVAModificadoManual = Boolean.Parse(dt.Rows(0)("IVAModificadoManual").ToString())

               .PercepcionIVA = Decimal.Parse(dt.Rows(0)("PercepcionIVA").ToString())
               .PercepcionIB = Decimal.Parse(dt.Rows(0)("PercepcionIB").ToString())
               .PercepcionGanancias = Decimal.Parse(dt.Rows(0)("PercepcionGanancias").ToString())
               .PercepcionVarias = Decimal.Parse(dt.Rows(0)("PercepcionVarias").ToString())

               .ImportePesos = Decimal.Parse(dt.Rows(0)("ImportePesos").ToString())
               .ImporteTarjetas = Decimal.Parse(dt.Rows(0)("ImporteTarjetas").ToString())
               .ImporteTransfBancaria = Decimal.Parse(dt.Rows(0)("ImporteTransfBancaria").ToString())

               .TotalBruto = Decimal.Parse(dt.Rows(0)("TotalBruto").ToString())
               .TotalNeto = Decimal.Parse(dt.Rows(0)("TotalNeto").ToString())
               .TotalIVA = Decimal.Parse(dt.Rows(0)("TotalIVA").ToString())
               .TotalPercepciones = Decimal.Parse(dt.Rows(0)("TotalPercepciones").ToString())

               If Not String.IsNullOrEmpty(dt.Rows(0)("IdCuentaBancaria").ToString()) Then
                  .CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(dt.Rows(0)("IdCuentaBancaria").ToString()))
               End If

               .Observacion = dt.Rows(0)("Observacion").ToString()
               .PorcentajeIVA = Decimal.Parse(dt.Rows(0)("PorcentajeIVA").ToString())
               .Rubro = New Reglas.RubrosCompras().GetUno(Integer.Parse(dt.Rows(0)("IdRubro").ToString()))
               'Por ahora el Comprador no se graba. Deberiamos ??
               If Not IsDBNull(dt.Rows(0)("IdComprador")) Then
                  .Comprador = New Reglas.Empleados(da).GetUno(Integer.Parse(dt.Rows(0)("IdComprador").ToString()))
               End If

               ''EsComercial=True excluye los Tipo de SALDOINICIAL.
               'If .TipoComprobante.EsComercial And .TipoComprobante.GrabaLibro Then
               'Sacamos EsComercial porque no permitía modificar los comprobantes tipo IMPUESTOS
               If .TipoComprobante.GrabaLibro AndAlso IsNumeric(dt.Rows(0)("PeriodoFiscal")) Then
                  .IdEmpresa = Integer.Parse(dt.Rows(0)("IdEmpresa").ToString())
                  .PeriodoFiscal = Integer.Parse(dt.Rows(0)("PeriodoFiscal").ToString())
               End If

               .ChequesTerceros = New Cheques(da).GetPorComprobanteCompraCH(.IdSucursal, .Proveedor.IdProveedor,
                                          .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, False)

               .ChequesPropios = New Cheques(da).GetPorComprobanteCompraCH(.IdSucursal, .Proveedor.IdProveedor,
                                          .TipoComprobante.IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, True)

               .CuponesTarjetasLiquidacion = New ComprasTarjetas(da).GetTodos(compra)
               .Retenciones = New ComprasRetenciones(da).GetTodos(compra)

               If Not IsDBNull(dt.Rows(0)("IdEjercicio")) Then
                  .IdEjercicio = CInt(dt.Rows(0)("IdEjercicio"))
               End If

               If Not IsDBNull(dt.Rows(0)("IdPlanCuenta")) Then
                  .IdPlanCuenta = CInt(dt.Rows(0)("IdPlanCuenta"))
               End If

               If Not IsDBNull(dt.Rows(0)("IdAsiento")) Then
                  .IdAsiento = CInt(dt.Rows(0)("IdAsiento"))
               End If
               If Not IsDBNull(dt.Rows(0)("CotizacionDolar")) Then
                  .CotizacionDolar = Decimal.Parse(dt.Rows(0)("CotizacionDolar").ToString())
               End If

               If Not String.IsNullOrWhiteSpace(dt.Rows(0)("FechaOficializacionDespacho").ToString()) Then
                  .FechaOficializacionDespacho = DateTime.Parse(dt.Rows(0)("FechaOficializacionDespacho").ToString())
               End If
               If Not String.IsNullOrWhiteSpace(dt.Rows(0)("IdAduana").ToString()) Then
                  .IdAduana = Integer.Parse(dt.Rows(0)("IdAduana").ToString())
               End If
               If Not String.IsNullOrWhiteSpace(dt.Rows(0)("IdDestinacion").ToString()) Then
                  .IdDestinacion = dt.Rows(0)("IdDestinacion").ToString()
               End If
               If Not String.IsNullOrWhiteSpace(dt.Rows(0)("NumeroDespacho").ToString()) Then
                  .NumeroDespacho = Long.Parse(dt.Rows(0)("NumeroDespacho").ToString())
               End If
               If Not String.IsNullOrWhiteSpace(dt.Rows(0)("DigitoVerificadorDespacho").ToString()) Then
                  .DigitoVerificadorDespacho = dt.Rows(0)("DigitoVerificadorDespacho").ToString()
               End If
               If Not String.IsNullOrWhiteSpace(dt.Rows(0)("IdDespachante").ToString()) Then
                  .IdDespachante = Integer.Parse(dt.Rows(0)("IdDespachante").ToString())
               End If
               If Not String.IsNullOrWhiteSpace(dt.Rows(0)("IdAgenteTransporte").ToString()) Then
                  .IdAgenteTransporte = Integer.Parse(dt.Rows(0)("IdAgenteTransporte").ToString())
               End If
               If Not String.IsNullOrWhiteSpace(dt.Rows(0)("DerechoAduanero").ToString()) Then
                  .DerechoAduanero = Decimal.Parse(dt.Rows(0)("DerechoAduanero").ToString())
               End If
               If Not String.IsNullOrWhiteSpace(dt.Rows(0)("BienCapitalDespacho").ToString()) Then
                  .BienCapitalDespacho = Boolean.Parse(dt.Rows(0)("BienCapitalDespacho").ToString())
               End If
               If Not String.IsNullOrWhiteSpace(dt.Rows(0)("NumeroManifiestoDespacho").ToString()) Then
                  .NumeroManifiestoDespacho = dt.Rows(0)("NumeroManifiestoDespacho").ToString()
               End If

               .Bultos = Integer.Parse(dt.Rows(0)("Bultos").ToString())
               .ValorDeclarado = Decimal.Parse(dt.Rows(0)("ValorDeclarado").ToString())
               If IsNumeric(dt.Rows(0)("IdTransportista").ToString()) Then
                  .Transportista = New Reglas.Transportistas(da).GetUno(Long.Parse(dt.Rows(0)("IdTransportista").ToString()))
               End If
               .NumeroLote = Long.Parse(dt.Rows(0)("NumeroLote").ToString())

               If IsNumeric(dt.Rows(0)("IdSucursalVenta")) Then
                  .IdSucursalVenta = Integer.Parse(dt.Rows(0)("IdSucursalVenta").ToString())
               End If
               .IdTipoComprobanteVenta = dt.Rows(0)("IdTipoComprobanteVenta").ToString()
               .LetraVenta = dt.Rows(0)("LetraVenta").ToString()
               If IsNumeric(dt.Rows(0)("CentroEmisorVenta")) Then
                  .CentroEmisorVenta = Short.Parse(dt.Rows(0)("CentroEmisorVenta").ToString())
               End If
               If IsNumeric(dt.Rows(0)("NumeroComprobanteVenta")) Then
                  .NumeroComprobanteVenta = Long.Parse(dt.Rows(0)("NumeroComprobanteVenta").ToString())
               End If

               '# Datos del comprobante facturador
               If Not String.IsNullOrEmpty(dt.Rows(0).Field(Of String)(Entidades.Compra.Columnas.IdTipoComprobanteFact.ToString())) Then
                  .IdTipoComprobanteFact = dt.Rows(0).Field(Of String)(Entidades.Compra.Columnas.IdTipoComprobanteFact.ToString())
               End If
               If Not String.IsNullOrEmpty(dt.Rows(0).Field(Of String)(Entidades.Compra.Columnas.LetraFact.ToString())) Then
                  .LetraFact = dt.Rows(0).Field(Of String)(Entidades.Compra.Columnas.LetraFact.ToString())
               End If
               If IsNumeric(dt.Rows(0)(Entidades.Compra.Columnas.CentroEmisorFact.ToString())) Then
                  .CentroEmisorFact = CShort(dt.Rows(0)(Entidades.Compra.Columnas.CentroEmisorFact.ToString()))
               End If
               If IsNumeric(dt.Rows(0)(Entidades.Compra.Columnas.NumeroComprobanteFact.ToString())) Then
                  .NumeroComprobanteFact = CInt(dt.Rows(0)(Entidades.Compra.Columnas.NumeroComprobanteFact.ToString()))
               End If
               If IsNumeric(dt.Rows(0)(Entidades.Compra.Columnas.IdProveedorFact.ToString())) Then
                  .IdProveedorFact = CInt(dt.Rows(0)(Entidades.Compra.Columnas.IdProveedorFact.ToString()))
               End If

               .NombreProveedor = dt.Rows(0)("NombreProveedor").ToString()
               .CuitProveedor = dt.Rows(0)("CuitProveedor").ToString()
               .IdcategoriaFiscal = Integer.Parse(dt.Rows(0)("IdcategoriaFiscal").ToString())

               'GAR: 17/07/2019. Puede traer alguna consecuencia solo cargar la caja? 
               'son movimientos viejos no identificados con el scripts y modificados manualemente por el usario.
               If Not String.IsNullOrEmpty(dt.Rows(0)("IdCaja").ToString()) Then
                  .IdCaja = Integer.Parse(dt.Rows(0)("IdCaja").ToString())
               End If

               If Not String.IsNullOrEmpty(dt.Rows(0)("NumeroPlanilla").ToString()) Then
                  .NumeroPlanilla = Integer.Parse(dt.Rows(0)("NumeroPlanilla").ToString())
                  ' 'Las Ventas de CtaCte tambien tiene Caja y Planilla pero no el Movimiento.
                  If Not String.IsNullOrEmpty(dt.Rows(0)("NumeroMovimiento").ToString()) Then
                     .NumeroMovimiento = Integer.Parse(dt.Rows(0)("NumeroMovimiento").ToString())
                  End If
               End If
               .ImpuestosInternos = Decimal.Parse(dt.Rows(0)("ImpuestosInternos").ToString())
               .ExcluirDePasaje = dt.Rows(0).Field(Of Boolean)(Entidades.Compra.Columnas.ExcluirDePasaje.ToString())
               '-.PE-31849.-
               .MercEnviada = dt.Rows(0).Field(Of Boolean)(Entidades.Compra.Columnas.MercEnviada.ToString())

               .ConceptoCM05 = New AFIPConceptosCM05(da).GetUno(dt.Rows(0).Field(Of Integer?)(Entidades.Compra.Columnas.IdConceptoCM05.ToString()).IfNull(),
                                                                AccionesSiNoExisteRegistro.Nulo)
               If IsNumeric(dt.Rows(0)("NumeroOrdenCompra")) Then
                  .NumeroOrdenCompra = Long.Parse(dt.Rows(0)("NumeroOrdenCompra").ToString())
               End If
            End With

            With stb
               .Length = 0
               .AppendLine("SELECT CP.IdSucursal")
               .AppendLine("   ,CP.IdTipoComprobante")
               .AppendLine("   ,CP.Letra")
               .AppendLine("   ,CP.CentroEmisor")
               .AppendLine("   ,CP.NumeroComprobante")
               .AppendLine("   ,CP.IdProveedor")
               .AppendLine("   ,CP.Orden")
               .AppendLine("   ,CP.IdProducto")
               .AppendLine("   ,CP.NombreProducto")
               .AppendLine("   ,PS.Stock")
               .AppendLine("   ,CP.Cantidad")
               .AppendLine("   ,CP.Precio")
               .AppendLine("   ,CP.DescRecGeneral")
               .AppendLine("   ,CP.DescuentoRecargo")
               .AppendLine("   ,CP.ImporteTotal")
               .AppendLine("   ,CP.DescuentoRecargoProducto")
               .AppendLine("   ,CP.DescuentoRecargoPorc")
               .AppendLine("   ,CP.DescRecGeneralProducto")
               .AppendLine("   ,CP.PrecioNeto")
               .AppendLine("   ,CP.ImporteTotalNeto")
               .AppendLine("   ,CP.PorcentajeIVA")
               .AppendLine("   ,CP.IVA")
               .AppendLine("   ,CP.IdCentroCosto")
               'REQ-34987.- *----------------------------------------------------
               .AppendLine("   ,CP.IdaAtributoProducto01")
               .AppendLine("   ,CP.IdaAtributoProducto02")
               .AppendLine("   ,CP.IdaAtributoProducto03")
               .AppendLine("   ,CP.IdaAtributoProducto04")
               '-----------------------------------------------------------------
               .AppendLine("   ,CP.IdDeposito")
               .AppendLine("   ,CP.IdUbicacion")

               .AppendLine("   ,CP.CantidadUMCompra")
               .AppendLine("   ,CP.FactorConversionCompra")
               .AppendLine("   ,CP.PrecioPorUMCompra")
               .AppendLine("   ,CP.IdUnidadDeMedida")
               .AppendLine("   ,CP.IdUnidadDeMedidaCompra")
               .AppendLine("   ,CP.InformeCalidadNumero")

               .AppendLine("  FROM ComprasProductos CP")
               .AppendLine(" INNER JOIN Proveedores PROV ON PROV.IdProveedor = CP.IdProveedor")
               .AppendLine(" INNER JOIN Productos P ON P.IdProducto = CP.IdProducto")
               .AppendLine(" INNER JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto AND PS.IdSucursal = " & idSucursal.ToString())
               .AppendLine(" WHERE CP.IdSucursal = " & idSucursal.ToString())
               .AppendLine("   AND CP.IdTipoComprobante = '" & idTipoComprobante & "'")
               .AppendLine("   AND CP.Letra = '" & letra & "'")
               .AppendLine("   AND CP.CentroEmisor = " & centroEmisor.ToString())
               .AppendLine("   AND CP.NumeroComprobante = " & numeroComprobante.ToString())
               .AppendLine("   AND PROV.idProveedor = " & IdProveedor)
               .AppendLine(" ORDER BY CP.Orden")
            End With

            Dim dtPro As DataTable = Me.da.GetDataTable(stb.ToString())
            Dim oCP As Entidades.CompraProducto
            For Each dr As DataRow In dtPro.Rows
               oCP = New Entidades.CompraProducto()
               With oCP
                  .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
                  .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr("IdTipoComprobante").ToString())
                  .Letra = dr("Letra").ToString()
                  .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
                  .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())

                  'No estan las propiedades.
                  '.IdProveedor

                  .Orden = Integer.Parse(dr("Orden").ToString())


                  .IdDeposito = Integer.Parse(dr("IdDeposito").ToString())
                  .IdUbicacion = Integer.Parse(dr("IdUbicacion").ToString())


                  .ProductoSucursal = New Reglas.ProductosSucursales(da)._GetUno(Integer.Parse(dr("IdSucursal").ToString()), dr("IdProducto").ToString())
                  '.Producto.NombreProducto = dr("NombreProducto").ToString()
                  .Producto = New Reglas.Productos(da).GetUno(dr("IdProducto").ToString())
                  If .Producto.PermiteModificarDescripcion Then
                     .Producto.NombreProducto = dr("NombreProducto").ToString()
                  End If
                  .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
                  '.Iva = Decimal.Parse(dr("Iva").ToString())
                  .Precio = Decimal.Parse(dr("Precio").ToString())
                  'Ambos campos no se graban... deberiamos ??
                  '.Utilidad = Decimal.Parse(dr("Utilidad").ToString())
                  '.ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())
                  '-------------------------------------

                  .DescRecGeneral = Decimal.Parse(dr("DescRecGeneral").ToString())
                  .DescuentoRecargo = Decimal.Parse(dr("DescuentoRecargo").ToString())

                  .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())
                  .DescuentoRecargoProducto = Decimal.Parse(dr("DescuentoRecargoProducto").ToString())
                  .DescuentoRecargoPorc = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
                  .DescRecGeneralProducto = Decimal.Parse(dr("DescRecGeneralProducto").ToString())
                  .PrecioNeto = Decimal.Parse(dr("PrecioNeto").ToString())
                  .ImporteTotalNeto = Decimal.Parse(dr("ImporteTotalNeto").ToString())
                  .PorcentajeIVA = Decimal.Parse(dr("PorcentajeIVA").ToString())
                  .Iva = Decimal.Parse(dr("Iva").ToString())

                  '-- REQ-34987.- --------------------------------------------------------------------
                  .IdaAtributoProducto01 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto01").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto01").ToString()))
                  .IdaAtributoProducto02 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto02").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto02").ToString()))
                  .IdaAtributoProducto03 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto03").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto03").ToString()))
                  .IdaAtributoProducto04 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto04").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto04").ToString()))
                  '-----------------------------------------------------------------------------------

                  .CantidadUMCompra = dr.Field(Of Decimal)("CantidadUMCompra")
                  .FactorConversionCompra = dr.Field(Of Decimal)("FactorConversionCompra")
                  .PrecioPorUMCompra = dr.Field(Of Decimal)("PrecioPorUMCompra")
                  .IdUnidadDeMedida = dr.Field(Of String)("IdUnidadDeMedida")
                  .IdUnidadDeMedidaCompra = dr.Field(Of String)("IdUnidadDeMedidaCompra")

                  If Not String.IsNullOrWhiteSpace(dr(Entidades.CompraProducto.Columnas.IdCentroCosto.ToString()).ToString()) Then
                     .CentroCosto = New Reglas.ContabilidadCentrosCostos(da)._GetUna(Integer.Parse(dr(Entidades.CompraProducto.Columnas.IdCentroCosto.ToString()).ToString()))
                  End If

                  '# Productos con Nro. Serie
                  .Producto.NrosSeries = Me.ObtenerProductosConNroSerie(.IdSucursal, .TipoComprobante.IdTipoComprobante, .Letra, centroEmisor, .NumeroComprobante, orden:= .Orden, idProveedor:=IdProveedor, idProducto:= .Producto.IdProducto)
                  .InformeCalidadNumero = dr.Field(Of String)("InformeCalidadNumero")
               End With
               compra.ComprasProductos.Add(oCP)
            Next

            'Observaciones
            With stb
               .Length = 0
               .AppendLine("SELECT CO.IdSucursal")
               .AppendLine("      ,CO.IdTipoComprobante")
               .AppendLine("      ,CO.Letra")
               .AppendLine("      ,CO.CentroEmisor")
               .AppendLine("      ,CO.NumeroComprobante")
               .AppendLine("      ,CO.IdProveedor")
               .AppendLine("      ,CO.Linea")
               .AppendLine("      ,CO.Observacion")
               .AppendLine("  FROM ComprasObservaciones CO")
               .AppendLine(" INNER JOIN Proveedores PROV ON PROV.IdProveedor = CO.IdProveedor")
               .Append(" WHERE CO.IdSucursal = " & idSucursal.ToString())
               .Append("   AND CO.IdTipoComprobante = '" & idTipoComprobante & "'")
               .Append("   AND CO.Letra = '" & letra & "'")
               .Append("   AND CO.CentroEmisor = " & centroEmisor.ToString())
               .Append("   AND CO.NumeroComprobante = " & numeroComprobante.ToString())
               .Append("   AND CO.IdProveedor = " & IdProveedor.ToString())
               .AppendLine(" ORDER BY CO.Linea")
            End With

            Dim dtObs As DataTable = Me.da.GetDataTable(stb.ToString())
            Dim oCO As Entidades.CompraObservacion

            For Each dr As DataRow In dtObs.Rows
               oCO = New Entidades.CompraObservacion()
               With oCO
                  .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
                  .IdTipoComprobante = dr("IdTipoComprobante").ToString()
                  .Letra = dr("Letra").ToString()
                  .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
                  .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
                  .Proveedor = New Reglas.Proveedores().GetUno(Long.Parse(dr("IdProveedor").ToString()))
                  .Linea = Integer.Parse(dr("Linea").ToString())
                  .Observacion = dr("Observacion").ToString()
               End With
               compra.ComprasObservaciones.Add(oCO)
            Next

            compra.ComprasImpuestos = New ComprasImpuestos(da).GetTodos(compra.IdSucursal,
                                                                        compra.TipoComprobante.IdTipoComprobante,
                                                                        compra.Letra,
                                                                        compra.CentroEmisor,
                                                                        compra.NumeroComprobante,
                                                                        compra.Proveedor.IdProveedor)


            Return compra
         Else
            Throw New Exception("No existe este comprobante de Compra")
         End If
      End Using
   End Function

   Friend Sub GrabarCompra(comp As Entidades.Compra, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)

      'Calculo los totales de los ComprasImpuestos para tenerlos en Compras más accesibles
      comp.TotalPercepciones = 0
      comp.TotalBruto = 0
      comp.TotalNeto = 0
      comp.TotalIVA = 0
      For Each ci As Entidades.CompraImpuesto In comp.ComprasImpuestos
         If ci.TipoTipoImpuesto = "PERCEPCION" Then
            comp.TotalPercepciones += ci.Importe
         Else
            comp.TotalBruto += (ci.Bruto * comp.TipoComprobante.CoeficienteValores)
            comp.TotalNeto += (ci.BaseImponible * comp.TipoComprobante.CoeficienteValores)
            comp.TotalIVA += (ci.Importe * comp.TipoComprobante.CoeficienteValores)
         End If
      Next

      Dim coe As Integer = comp.TipoComprobante.CoeficienteValores

      If comp.Transferencias Is Nothing Then comp.Transferencias = New List(Of Entidades.CompraTransferencia)()
      If comp.Transferencias.Count > 0 Then
         comp.ImporteTransfBancaria = comp.Transferencias.Sum(Function(vt) vt.Importe) * coe
         If comp.Transferencias.Select(Function(vt) vt.IdCuentaBancaria).Distinct().Count > 1 Then
            comp.CuentaBancariaTransfBanc = New CuentasBancarias(da).GetUna(999)
         Else
            comp.CuentaBancariaTransfBanc = New CuentasBancarias(da).GetUna(comp.Transferencias.First().IdCuentaBancaria)
         End If
      Else
         If comp.Transferencias.Count = 0 AndAlso comp.ImporteTransfBancaria <> 0 Then
            comp.Transferencias.Add(New Entidades.CompraTransferencia() With
                                       {
                                          .Importe = comp.ImporteTransfBancaria,
                                          .Orden = 1,
                                          .IdCuentaBancaria = comp.CuentaBancariaTransfBanc.IdCuentaBancaria
                                       })
         End If
         comp.ImporteTransfBancaria = comp.ImporteTransfBancaria * coe
         comp.CuentaBancariaTransfBanc = comp.CuentaBancariaTransfBanc
      End If

      Me.Graba(comp, MetodoGrabacion, IdFuncion)

      comp.Transferencias.ForEach(Sub(trx)
                                     trx.IdSucursalLibroBanco = Nothing
                                     trx.IdCuentaBancariaLibroBanco = Nothing
                                     trx.NumeroMovimientoLibroBanco = Nothing
                                  End Sub)

      Dim rVTrx = New ComprasTransferencias(da)
      rVTrx._Insertar(comp, coe)

      If comp.TipoComprobante.GrabaLibro And comp.Proveedor.CategoriaFiscal.IvaDiscriminado Then
         Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales(da)
         Dim Neto As Decimal = comp.TotalNeto
         Dim IVA As Decimal = comp.TotalIVA

         oPF.ActualizarPosicion(comp.IdEmpresa, comp.PeriodoFiscal, 0, 0, 0, Neto, IVA, comp.ImporteTotal, 0, comp.PercepcionIVA)
      End If

      Dim oComProd As Reglas.ComprasProductos = New Reglas.ComprasProductos(da)
      Dim rComImp As Reglas.ComprasImpuestos = New Reglas.ComprasImpuestos(da)
      Dim pro As ProductosSucursales = New ProductosSucursales(da)

      Dim cantidad As Integer = 0
      Dim importeConceptos As Decimal = 0
      '  Dim coe As Integer = comp.TipoComprobante.CoeficienteValores

      For Each conc As Entidades.CompraProducto In comp.ComprasProductos
         cantidad = cantidad + 1
         importeConceptos = importeConceptos + ((conc.ImporteTotalNeto + Decimal.Round(conc.Iva, 2)) * coe)
      Next

      For Each prod As Entidades.CompraProducto In comp.ComprasProductos

         Dim porcProp As Decimal = 0
         prod.Compra = comp

         'prod.ImporteTotal = prod.ImporteTotal * coe
         'prod.ImporteTotalNeto = prod.ImporteTotalNeto * coe
         'prod.Iva = prod.Iva * coe
         If importeConceptos <> 0 Then
            porcProp = Math.Round((prod.ImporteTotalNeto + prod.Iva) / importeConceptos, 2)
         End If

         prod.ProporcionalImp = (Math.Abs(comp.ImporteTotal) - importeConceptos) * porcProp

         If Publicos.PasajeComprasIncluyeImpuestos Then
            prod.MontoSaldo = prod.ImporteTotalNeto + prod.Iva + prod.ProporcionalImp
         Else
            prod.MontoSaldo = prod.ImporteTotalNeto
         End If

         oComProd.GrabaDetalles(prod)

         '# Grabo los productos con Nro. Serie en su tabla correspondiente
         Dim rCPNS As Reglas.ComprasProductosNrosSerie = New Reglas.ComprasProductosNrosSerie(da)
         Dim eCPNS As Entidades.CompraProductoNroSerie
         For Each pns As Entidades.ProductoNroSerie In prod.Producto.NrosSeries
            eCPNS = New Entidades.CompraProductoNroSerie
            eCPNS.IdSucursal = comp.IdSucursal
            eCPNS.IdTipoComprobante = comp.TipoComprobante.IdTipoComprobante
            eCPNS.Letra = comp.Letra
            eCPNS.CentroEmisor = comp.CentroEmisor
            eCPNS.NumeroComprobante = comp.NumeroComprobante
            eCPNS.Orden = prod.Orden
            eCPNS.IdProveedor = comp.Proveedor.IdProveedor
            eCPNS.IdProducto = pns.Producto.IdProducto
            eCPNS.NroSerie = pns.NroSerie
            rCPNS._Inserta(eCPNS)
         Next

      Next

      Dim orden As Integer = 1
      For Each ci In comp.ComprasImpuestos
         If ci.ImporteTotal <> 0 Then
            ci.IdSucursal = comp.IdSucursal
            ci.IdTipoComprobante = comp.TipoComprobante.IdTipoComprobante
            ci.Letra = comp.Letra
            ci.CentroEmisor = comp.CentroEmisor
            ci.NumeroComprobante = comp.NumeroComprobante
            ci.IdProveedor = comp.Proveedor.IdProveedor
            ci.Orden = orden

            If ci.Numero = 0 Then
               ci.Emisor = comp.CentroEmisor
               ci.Numero = comp.NumeroComprobante
            End If

            ci.BaseImponible = ci.BaseImponible * comp.TipoComprobante.CoeficienteValores
            ci.Importe = ci.Importe * comp.TipoComprobante.CoeficienteValores
            ci.Bruto = ci.Bruto * comp.TipoComprobante.CoeficienteValores

            orden += 1

            rComImp.Inserta(ci)
         End If
      Next

      Dim rCompraTarjeta = New ComprasTarjetas(da)
      rCompraTarjeta._Insertar(comp)
      Dim rTarjetasCupones = New TarjetasCupones(da)
      For Each t In comp.CuponesTarjetasLiquidacion
         rTarjetasCupones.ActualizaEstado(t.IdTarjetaCupon, Entidades.TarjetaCupon.Estados.LIQUIDADO)
      Next

      Dim rCompraReten = New ComprasRetenciones(da)
      rCompraReten._Insertar(comp)

   End Sub

   Public Function GetPorSucursalCliente(idSucursal As Int32, IdProveedor As Long, Optional Desde As Date = #1/1/1981#, Optional Hasta As Date = #1/1/2099#) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT C.*, E.NombreEmpleado AS NombreComprador ")
         .AppendLine(" FROM Compras C ")
         .AppendLine(" LEFT JOIN Empleados E ON C.IdComprador = E.IdEmpleado ")
         '.AppendLine(" LEFT JOIN TiposComprobantes TC ON C.IdTipoComprobante = TC.IdTipoComprobante")
         '.AppendLine(" WHERE TC.AfectaCaja = 'True' ")    'Contemplo solo aquellos comprobantes que manejan dinero
         .AppendLine("  WHERE C.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND C.IdProveedor = " & IdProveedor.ToString())
         .AppendLine("   AND CONVERT(varchar(11), C.Fecha, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("   AND CONVERT(varchar(11), C.Fecha, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")
         .AppendLine(" ORDER BY C.Fecha, C.IdTipoComprobante, C.Letra, C.CentroEmisor, C.NumeroComprobante")
      End With

      Return da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetTotalComprasSucursales(suc As List(Of Integer),
                                             Desde As Date,
                                             Hasta As Date) As DataTable

      Dim sql As SqlServer.Compras

      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Compras(da)
         dt = sql.ComprasTotalSucursal(suc, Desde, Hasta)

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try


   End Function

   Public Function GetModificacionCompras(sucursal As Integer,
                                          desde As Date,
                                          hasta As Date,
                                          idProveedor As Long,
                                          tipoComprobante As String,
                                          idEmpresa As Integer,
                                          periodoFiscal As Integer) As DataTable
      Return New SqlServer.Compras(da).GetModificacionCompras(sucursal,
                                                              desde, hasta,
                                                              idProveedor, tipoComprobante,
                                                              idEmpresa,
                                                              periodoFiscal,
                                                              actual.NivelAutorizacion)
   End Function

   Public Function GetInvocadosCom(idSucursal As Integer,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Short,
                                 numeroComprobante As Long,
                                 IdProveedor As Long) As DataTable

      Try
         'Me.da.OpenConection()
         'Me.da.BeginTransaction()


         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)
         Return sql.GetInvocadosCom(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, IdProveedor)

         'Me.da.CommitTransaction()
      Catch ex As Exception
         'Me.da.RollbakTransaction()
         Throw
      Finally
         'Me.da.CloseConection()
      End Try


   End Function

   Public Sub LiberarInvocados(idSucursal As Integer,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Short,
                                 numeroComprobante As Long,
                                 IdProveedor As Long)

      Try
         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)
         sql.LiberarInvocadosCom(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, IdProveedor)

      Catch ex As Exception

      End Try

   End Sub

   Public Function GetFacturables(idSucursal As Integer,
                                  fechaDesde As Date,
                                  fechaHasta As Date,
                                  tiposComprobantes As List(Of String),
                                  idProveedor As Long,
                                  idEstadoComprobante As String,
                                  idTipoComprobanteVentaNULL As Boolean,
                                  Stock As Boolean,
                                  idCentroCosto As Integer?,
                                  fueInvocado As Entidades.Publicos.SiNoTodos) As List(Of Entidades.Compra)

      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA
      Dim srtCatFiscalEmp As Short = Publicos.CategoriaFiscalEmpresa
      Dim blnInvocarInvocador As Boolean = Publicos.Facturacion.FacturacionInvocarInvocador
      Dim utilizaCentroCostos As Boolean = ContabilidadPublicos.UtilizaCentroCostos

      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT C.IdSucursal, ")
         .AppendLine("	C.IdTipoComprobante,")
         .AppendLine("	C.Letra,")
         .AppendLine("	C.CentroEmisor,")
         .AppendLine("	C.NumeroComprobante,")
         .AppendLine("	C.Fecha,")
         .AppendLine("	C.IdComprador,")
         .AppendLine("	C.DescuentoRecargo,")
         .AppendLine("	C.DescuentoRecargoPorc,")
         .AppendLine("	C.ImporteTotal,")
         .AppendLine("	C.IdProveedor,")
         .AppendLine("	C.IdCategoriaFiscal,")
         .AppendLine("	C.IdFormasPago,")
         .AppendLine("	C.Observacion,")
         .AppendLine("	C.ImportePesos,")
         .AppendLine("	C.ImporteCheques,")
         .AppendLine("	C.CotizacionDolar")
         '.AppendLine("	I.IdImpresora,")
         '.AppendLine("	I.TipoImpresora")

         If utilizaCentroCostos Then
            .AppendLine("      ,(SELECT DISTINCT CC.NombreCentroCosto + ' / '")
            .AppendLine("          FROM ComprasProductos CP")
            .AppendLine("         INNER JOIN ContabilidadCentrosCostos CC ON CC.IdCentroCosto = CP.IdCentroCosto")
            .AppendLine("            WHERE CP.IdSucursal = C.IdSucursal And CP.IdTipoComprobante = C.IdTipoComprobante And CP.Letra = C.Letra")
            .AppendLine("           AND CP.CentroEmisor = C.CentroEmisor AND CP.NumeroComprobante = C.NumeroComprobante AND CP.IdProveedor = C.IdProveedor")
            .AppendLine("           FOR XML PATH('')) NombresCentrosCosto")
         Else
            .AppendLine("      , '' NombresCentrosCosto")
         End If

         .AppendLine(" FROM Compras C")
         .AppendLine(" INNER JOIN Proveedores P ON P.IdProveedor = C.IdProveedor ")
         '.AppendLine(" INNER JOIN Impresoras I ON I.CentroEmisor = C.CentroEmisor AND I.IdSucursal = C.IdSucursal")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante")

         If Not Stock Then
            .AppendLine(" AND TC.EsFacturable = 1")
         End If

         .AppendLine(" WHERE C.IdSucursal = " & idSucursal.ToString())

         If tiposComprobantes.Count > 0 Then
            .AppendLine("   AND C.idTipoComprobante IN (")
            For Each tipo As String In tiposComprobantes
               .AppendFormat("'{0}',", tipo)
            Next
            .Remove(.Length - 1, 1)
            .AppendFormat(")")
         Else
            If Not Stock Then
               .AppendLine("   AND TC.CoeficienteStock < 0 AND TC.EsFacturable = 1 AND TC.AfectaCaja = 0")  '---Fuerzo Remitos
            End If

         End If

         If idProveedor <> 0 Then
            .AppendLine("   AND P.iDProveedor = '" & idProveedor & "' ")
         End If

         If idEstadoComprobante <> "TODOS" Then
            'Si lo grabariamos de entrada cuando se genera el remito, sacamos el if y dejamos el filtro.
            If idEstadoComprobante = "PENDIENTE" Then
               If blnInvocarInvocador Then
                  .AppendLine("   AND (C.IdEstadoComprobante IS NULL OR C.IdEstadoComprobante = 'INVOCO')")
               Else
                  .AppendLine("   AND C.IdEstadoComprobante IS NULL")
               End If
            ElseIf idEstadoComprobante = "NO ANULADO" Then
               .AppendLine("   AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO') ")
            Else
               .AppendLine("   AND C.IdEstadoComprobante = '" & idEstadoComprobante & "' ")
            End If
         End If

         If idTipoComprobanteVentaNULL Then
            .AppendLine("   AND IdTipoComprobanteVenta IS NULL")
         End If

         .AppendLine("   AND CONVERT(varchar(11), C.Fecha, 120) >= '" & fechaDesde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("   AND CONVERT(varchar(11), C.Fecha, 120) <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")

         If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then

            .AppendLine("    AND EXISTS (SELECT idCentroCosto")
            .AppendLine("                  FROM ComprasProductos CP")
            .AppendFormatLine("          WHERE CP.idCentroCosto= {0}", idCentroCosto)
            .AppendLine("                      AND C.IdSucursal=CP.IdSucursal")
            .AppendLine("                      AND C.IdTipoComprobante=CP.IdTipoComprobante")
            .AppendLine("                      AND C.Letra=CP.Letra")
            .AppendLine("                      AND C.CentroEmisor=CP.CentroEmisor")
            .AppendLine("                      AND C.NumeroComprobante=CP.NumeroComprobante")
            .AppendLine("                      AND C.IdProveedor=CP.IdProveedor)")
         End If

         If fueInvocado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND C.NumeroComprobanteFact IS {0} NULL", If(fueInvocado = Entidades.Publicos.SiNoTodos.SI, "NOT", ""))
         End If

         .AppendLine("   ORDER BY C.Fecha")  'Tiene la hora
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      Dim oCompras As List(Of Entidades.Compra) = New List(Of Entidades.Compra)

      Dim compra As Entidades.Compra

      For Each drVen As DataRow In dt.Rows
         compra = New Entidades.Compra()

         With compra
            .IdSucursal = Integer.Parse(drVen("IdSucursal").ToString())
            .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(drVen("IdTipoComprobante").ToString())

            .Letra = drVen("Letra").ToString()
            .CentroEmisor = Short.Parse(drVen("CentroEmisor").ToString())
            .NumeroComprobante = Long.Parse(drVen("NumeroComprobante").ToString())

            .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(drVen("IdProveedor").ToString()))

            'Por ahora dejo tengo en cero para aquello que carga el precio actual (ej: REMITO)
            If compra.TipoComprobante.CargaPrecioActual Then
               .DescuentoRecargo = 0
            Else
               .DescuentoRecargo = Decimal.Parse(drVen("DescuentoRecargo").ToString())
            End If

            .DescuentoRecargoPorc = Decimal.Parse(drVen("DescuentoRecargoPorc").ToString())

            .Fecha = Date.Parse(drVen("Fecha").ToString())
            .FormaPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(drVen("IdFormasPago").ToString()))
            '.Comprador = New Reglas.Empleados(da).GetUno(drVen("TipoDocComprador").ToString(), drVen("NroDocComprador").ToString())
            '.Impresora = New Reglas.Impresoras().GetUna(Integer.Parse(drVen("IdSucursal").ToString()), drVen("IdImpresora").ToString())
            If Not String.IsNullOrEmpty(drVen("Observacion").ToString()) Then
               .Observacion = drVen("Observacion").ToString()
            End If
            '.subtotal = Decimal.Parse(drVen("SubTotal").ToString())
            '.Impuestos = Decimal.Parse(drVen("TotalImpuestos").ToString())
            .ImporteTotal = Decimal.Parse(drVen("ImporteTotal").ToString())
            .ImportePesos = Decimal.Parse(drVen("ImportePesos").ToString())
            .ComprasImpuestos = New Reglas.ComprasImpuestos(da).GetTodos(idSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, .Proveedor.IdProveedor)

            .CotizacionDolar = drVen.Field(Of Decimal)(Entidades.Compra.Columnas.CotizacionDolar.ToString())
            '.ImporteTickets = Decimal.Parse(drVen("ImporteTickets").ToString())
            '.ImporteTarjetas = Decimal.Parse(drVen("ImporteTarjetas").ToString())
            '.ImporteCheques = 'Es read only

            '.Kilos = Decimal.Parse(drVen("Kilos").ToString())
            'If Not String.IsNullOrEmpty(drVen("IdDeposito").ToString()) Then
            '   .IdDeposito = Integer.Parse(drVen("IdDeposito").ToString())
            'End If

         End With

         With stb
            .Length = 0
            .AppendLine("SELECT CP.IdSucursal")
            .AppendLine("      ,CP.IdTipoComprobante")
            .AppendLine("      ,CP.Letra")
            .AppendLine("      ,CP.CentroEmisor")
            .AppendLine("      ,CP.NumeroComprobante")
            .AppendLine("      ,CP.IdProducto")
            '.AppendLine("	   ,P.NombreProducto")
            .AppendLine("	   ,CP.NombreProducto")
            .AppendLine("	   ,PS.Stock")
            .AppendLine("      ,CP.Cantidad")
            .AppendLine("      ,CP.Precio")

            'Tengo que dejarlo sin IVA, como si lo hubiese leido de la tabla de VentasProductos
            If blnPreciosConIVA Then
               .AppendLine("	,ROUND(PS.PrecioCosto / (1+(P.Alicuota/100)),2) as Costo")
            Else
               .AppendLine("      ,PS.PrecioCosto AS Costo")
            End If

            .AppendLine("      ,CP.DescRecGeneral")
            .AppendLine("      ,CP.DescuentoRecargo")
            .AppendLine("      ,CP.DescuentoRecargoPorc")

            '.AppendLine("      ,VP.PrecioLista")


            .AppendLine("      ,CP.ImporteTotal")
            .AppendLine("      ,CP.ImporteTotalNeto")

            .AppendLine("      ,CP.PorcentajeIVA")
            .AppendLine("      ,CP.IVA")
            .AppendLine("      ,CP.IdConcepto")
            .AppendLine("      ,CP.IdCentroCosto")

            .AppendLine("      ,CP.IdaAtributoProducto01")
            .AppendLine("      ,CP.IdaAtributoProducto02")
            .AppendLine("      ,CP.IdaAtributoProducto03")
            .AppendLine("      ,CP.IdaAtributoProducto04")

            .AppendLine("      ,CP.IdDeposito")
            .AppendLine("      ,CP.IdUbicacion")

            .AppendLine("      ,CP.IdLote")
            .AppendLine("      ,CP.InformeCalidadNumero")
            .AppendLine("      ,CP.InformeCalidadLink")

            .AppendLine("      ,CP.CantidadUMCompra")
            .AppendLine("      ,CP.FactorConversionCompra")
            .AppendLine("      ,CP.PrecioPorUMCompra")
            .AppendLine("      ,CP.IdUnidadDeMedida")
            .AppendLine("      ,CP.IdUnidadDeMedidaCompra")

            .AppendLine("  FROM ComprasProductos CP")
            .AppendLine(" INNER JOIN Productos P ON P.IdProducto = CP.IdProducto")
            .AppendLine(" INNER JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto AND PS.IdSucursal = " & idSucursal.ToString())
            .AppendLine(" WHERE CP.IdSucursal = " & idSucursal.ToString())

            .AppendFormat(" AND CP.IdTipoComprobante = '{0}'", compra.TipoComprobante.IdTipoComprobante)

            .AppendLine("   AND CP.Letra = '" & drVen("Letra").ToString() & "' ")
            .AppendLine("   AND CP.CentroEmisor = " & drVen("CentroEmisor").ToString() & " ")
            .AppendLine("   AND CP.NumeroComprobante = " & drVen("NumeroComprobante").ToString() & " ")
            .AppendLine("   AND CP.IdProveedor = " & drVen("IdProveedor").ToString() & " ")

            .AppendLine(" ORDER BY CP.Orden")
         End With

         Dim dtPro As DataTable = Me.da.GetDataTable(stb.ToString())
         Dim oCP As Entidades.CompraProducto

         'Dim CotizacionDolar As Decimal = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion
         Dim CotizacionDolar As Decimal = compra.CotizacionDolar

         For Each dr As DataRow In dtPro.Rows
            oCP = New Entidades.CompraProducto()
            With oCP
               .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
               .Letra = dr("Letra").ToString()
               .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
               .NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
               .Producto = New Reglas.Productos(da).GetUno(dr("IdProducto").ToString())
               .Producto.NombreProducto = dr("NombreProducto").ToString()
               .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
               .CantidadUMCompra = dr.Field(Of Decimal)(Entidades.CompraProducto.Columnas.CantidadUMCompra.ToString())
               .FactorConversionCompra = dr.Field(Of Decimal)(Entidades.CompraProducto.Columnas.FactorConversionCompra.ToString())
               .PrecioPorUMCompra = dr.Field(Of Decimal)(Entidades.CompraProducto.Columnas.PrecioPorUMCompra.ToString())
               .IdUnidadDeMedida = dr.Field(Of String)(Entidades.CompraProducto.Columnas.IdUnidadDeMedida.ToString())
               .IdUnidadDeMedidaCompra = dr.Field(Of String)(Entidades.CompraProducto.Columnas.IdUnidadDeMedidaCompra.ToString())

               '.Costo = Decimal.Parse(dr("Costo").ToString())
               .Precio = Decimal.Parse(dr("Precio").ToString())
               .DescuentoRecargoPorc = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
               '.DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())

               'Si carga el precio actual y el mismo tiene valor. En los productos varios se deja en 0 (cero) para vender aquellos que no se detallan.
               If compra.TipoComprobante.CargaPrecioActual And Decimal.Parse(dr("Precio").ToString()) <> 0 Then

                  .Precio = Decimal.Parse(dr("Precio").ToString())
                  .DescuentoRecargo = 0   'Despues se calcula.
                  .ImporteTotal = Decimal.Round(.Cantidad * .Precio, 2)
                  .DescRecGeneral = 0

                  If .Producto.Moneda.IdMoneda = 2 Then
                     '.Costo = Decimal.Round(.Costo * CotizacionDolar, 2)
                     '.Precio = Decimal.Round(.Precio * CotizacionDolar, 2) # No se debería estar multiplicando dos veces x el dolar.
                     .Precio = Decimal.Round(.Precio * CotizacionDolar, 2)
                     .ImporteTotal = Decimal.Round(.Cantidad * .Precio, 2)
                  End If

               Else
                  .Precio = Decimal.Parse(dr("Precio").ToString())
                  .DescuentoRecargo = Decimal.Parse(dr("DescuentoRecargo").ToString())
                  .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())
                  .DescRecGeneral = Decimal.Parse(dr("DescRecGeneral").ToString())
                  .ImporteTotalNeto = Decimal.Parse(dr("ImporteTotalNeto").ToString())
               End If

               If Not String.IsNullOrEmpty(dr("Stock").ToString()) Then
                  .Stock = Decimal.Parse(dr("Stock").ToString())
               End If
               .TipoComprobante.IdTipoComprobante = dr("IdTipoComprobante").ToString()
               '.Utilidad = Decimal.Parse(dr("Utilidad").ToString())
               '.Kilos = Decimal.Parse(dr("Kilos").ToString())
               '.TipoImpuesto.IdTipoImpuesto = DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), dr("IdTipoImpuesto").ToString()), Entidades.TipoImpuesto.Tipos)
               .PorcentajeIVA = Decimal.Parse(dr("PorcentajeIVA").ToString())
               .Iva = Decimal.Parse(dr("IVA").ToString())
               If IsNumeric(dr("IdConcepto")) Then
                  .IdConcepto = Integer.Parse(dr("IdConcepto").ToString())
               End If

               If IsNumeric(dr("IdCentroCosto")) Then
                  .CentroCosto = cache.BuscaCentrosCostos(Integer.Parse(dr("IdCentroCosto").ToString()))
               End If

               '-- REQ-34986.- --------------------------------------------------------------------
               .IdaAtributoProducto01 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto01").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto01").ToString()))
               .DescripcionAtributo01 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto01").ToString()), "", New Reglas.AtributosProductos().GetUnoIDA(Integer.Parse(dr("IdaAtributoProducto01").ToString())).Descripcion)
               .IdaAtributoProducto02 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto02").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto02").ToString()))
               .DescripcionAtributo02 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto02").ToString()), "", New Reglas.AtributosProductos().GetUnoIDA(Integer.Parse(dr("IdaAtributoProducto02").ToString())).Descripcion)
               .IdaAtributoProducto03 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto03").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto03").ToString()))
               .DescripcionAtributo03 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto03").ToString()), "", New Reglas.AtributosProductos().GetUnoIDA(Integer.Parse(dr("IdaAtributoProducto03").ToString())).Descripcion)
               .IdaAtributoProducto04 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto04").ToString()), 0, Integer.Parse(dr("IdaAtributoProducto04").ToString()))
               .DescripcionAtributo04 = If(String.IsNullOrEmpty(dr("IdaAtributoProducto04").ToString()), "", New Reglas.AtributosProductos().GetUnoIDA(Integer.Parse(dr("IdaAtributoProducto04").ToString())).Descripcion)
               '-----------------------------------------------------------------------------------
               .IdDeposito = If(String.IsNullOrEmpty(dr("IdDeposito").ToString()), 0, Integer.Parse(dr("IdDeposito").ToString()))
               .IdUbicacion = If(String.IsNullOrEmpty(dr("IdUbicacion").ToString()), 0, Integer.Parse(dr("IdUbicacion").ToString()))
               '-----------------------------------------------------------------------------------
               .IdLote = If(String.IsNullOrEmpty(dr("IdLote").ToString()), String.Empty, dr("IdLote").ToString())
               .InformeCalidadNumero = If(String.IsNullOrEmpty(dr("InformeCalidadNumero").ToString()), String.Empty, dr("InformeCalidadNumero").ToString())
               .InformeCalidadLink = If(String.IsNullOrEmpty(dr("InformeCalidadLink").ToString()), String.Empty, dr("InformeCalidadLink").ToString())

            End With

            compra.ComprasProductos.Add(oCP)

         Next

         '---------------------------------------------------------------------------------------------

         oCompras.Add(compra)

      Next

      Return oCompras

   End Function

   Public Function GetFacturablesPedidos(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date,
                                         tiposComprobantes As List(Of String), idProveedor As Long,
                                         idListaPrecios As Integer, numeroOrdenCompra As Long) As List(Of Entidades.Compra)
      Dim blnPreciosConIVA = Publicos.PreciosConIVA
      Dim srtCatFiscalEmp = Publicos.CategoriaFiscalEmpresa
      Dim blnInvocarInvocador = Publicos.Facturacion.FacturacionInvocarInvocador

      Dim oPedidos = New List(Of Entidades.Compra)()

      Dim sqlCompras = New SqlServer.Compras(da)

      Using dt = sqlCompras.GetFacturablesPedidos(idSucursal, fechaDesde, fechaHasta, tiposComprobantes, idProveedor, idListaPrecios, numeroOrdenCompra)
         For Each drPed As DataRow In dt.Rows
            Dim pedido = New Entidades.Compra()

            With pedido
               .IdSucursal = Integer.Parse(drPed("IdSucursal").ToString())
               .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(drPed("IdTipoComprobante").ToString())
               .Letra = drPed("Letra").ToString()
               .CentroEmisor = Short.Parse(drPed("CentroEmisor").ToString())
               .NumeroComprobante = Integer.Parse(drPed("NumeroPedido").ToString())

               .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(drPed("IdProveedor").ToString()))

               ''Por ahora dejo tengo en cero para aquello que carga el precio actual (ej: REMITO)
               'If venta.TipoComprobante.CargaPrecioActual Then
               '   .DescuentoRecargo = 0
               'Else
               '   .DescuentoRecargo = Decimal.Parse(drVen("DescuentoRecargo").ToString())
               'End If

               .DescuentoRecargoPorc = drPed.Field(Of Decimal)(Entidades.Compra.Columnas.DescuentoRecargoPorc.ToString())

               .Fecha = Date.Parse(drPed("FechaPedido").ToString())
               .FormaPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(drPed("IdFormasPago").ToString()))
               '.Vendedor = New Reglas.Empleados(da).GetUno(drVen("TipoDocVendedor").ToString(), drVen("NroDocVendedor").ToString())
               '.Impresora = New Reglas.Impresoras().GetUna(Integer.Parse(drVen("IdSucursal").ToString()), drVen("IdImpresora").ToString())

               If Not String.IsNullOrEmpty(drPed("Observacion").ToString()) Then
                  .Observacion = drPed("Observacion").ToString()
               End If
               '.Subtotal = Decimal.Parse(drVen("SubTotal").ToString())
               '.TotalImpuestos = Decimal.Parse(drVen("TotalImpuestos").ToString())
               .ImporteTotal = Decimal.Parse(drPed("ImporteTotal").ToString())

               If Not String.IsNullOrEmpty(drPed("NumeroOrdenCompra").ToString()) Then
                  .NumeroOrdenCompra = Long.Parse(drPed("NumeroOrdenCompra").ToString())
               End If

               '.ImportePesos = Decimal.Parse(drVen("ImportePesos").ToString())
               '.ImporteTickets = Decimal.Parse(drVen("ImporteTickets").ToString())
               '.ImporteTarjetas = Decimal.Parse(drVen("ImporteTarjetas").ToString())
               ''.ImporteCheques = 'Es read only

               '.Kilos = Decimal.Parse(drVen("Kilos").ToString())

            End With


            Using dtPro = sqlCompras.GetFacturablesPedidosDetalle(idSucursal, fechaDesde, fechaHasta, tiposComprobantes, idProveedor, idListaPrecios, numeroOrdenCompra, blnPreciosConIVA, pedido)

               Dim oMCP As Entidades.CompraProducto

               Dim CotizacionDolar As Decimal = New Reglas.Monedas(da).GetUna(Entidades.Moneda.Dolar).FactorConversion

               For Each dr As DataRow In dtPro.Rows
                  oMCP = New Entidades.CompraProducto()
                  With oMCP
                     .IdSucursal = pedido.IdSucursal
                     .TipoComprobante = pedido.TipoComprobante
                     .Letra = pedido.Letra
                     .CentroEmisor = pedido.CentroEmisor
                     .Compra.NumeroComprobante = pedido.NumeroComprobante
                     .Producto = New Reglas.Productos(da).GetUno(dr("IdProducto").ToString())
                     .CodigoProductoProveedor = dr.Field(Of String)(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString())
                     '.NombreProducto = dr("NombreProducto").ToString()
                     If Not String.IsNullOrWhiteSpace(dr("NombreProducto").ToString()) Then
                        .Producto.NombreProducto = dr("NombreProducto").ToString()
                     End If
                     .Orden = Integer.Parse(dr("Orden").ToString())
                     '.Cantidad = Decimal.Parse(dr("CantPendiente").ToString())
                     '.Cantidad = Decimal.Parse(dr("Cantidad").ToString()) - Decimal.Parse(dr("CantEntregada").ToString())
                     .Cantidad = dr.Field(Of Decimal?)("CantParaFacturar").IfNull()

                     .CantidadUMCompra = dr.Field(Of Decimal?)("CantidadUMCompra").IfNull()
                     .FactorConversionCompra = dr.Field(Of Decimal?)("FactorConversionCompra").IfNull()
                     .PrecioPorUMCompra = dr.Field(Of Decimal?)("PrecioPorUMCompra").IfNull()
                     .IdUnidadDeMedida = dr.Field(Of String)("IdUnidadDeMedida")
                     .IdUnidadDeMedidaCompra = dr.Field(Of String)("IdUnidadDeMedidaCompra")

                     '.Costo = Decimal.Parse(dr("Costo").ToString())
                     '.PrecioLista = Decimal.Parse(dr("Precio").ToString())
                     '.DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
                     '.DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())

                     'Si carga el precio actual y el mismo tiene valor. En los productos varios se deja en 0 (cero) para vender aquellos que no se detallan.
                     If .Compra.TipoComprobante.CargaPrecioActual And Decimal.Parse(dr("Costo").ToString()) <> 0 Then

                        '' ''.PrecioLista = Decimal.Parse(dr("PrecioVenta").ToString())
                        .Precio = Decimal.Parse(dr("PrecioCosto").ToString())
                        '.DescuentoRecargoPorc1 = 0
                        '.DescuentoRecargoPorc2 = 0
                        '.DescuentoRecargo = 0   'Despues se calcula.

                        '' ''.ImporteImpuestoInterno = Decimal.Parse(dr("ImporteImpuestoInternoPedido").ToString())
                        '' ''.PorcImpuestoInterno = Decimal.Parse(dr("PorcImpuestoInterno").ToString())

                        If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc").ToString()) Then
                           .DescuentoRecargoPorc = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
                           .DescuentoRecargoProducto = dr.Field(Of Decimal)(Entidades.PedidoProductoProveedor.Columnas.DescuentoRecargoProducto.ToString())
                           .DescuentoRecargo = .DescuentoRecargoProducto * .Cantidad
                        End If

                        '' ''If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc2").ToString()) Then
                        '' ''   .DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
                        '' ''End If
                        '.DescRecGeneral = 0

                        If .Producto.Moneda.IdMoneda = 2 Then
                           .Precio = Decimal.Round(.Precio * CotizacionDolar, 2)
                           .ImporteTotal = Decimal.Round(.Cantidad * .Precio, 2)
                        End If

                        .ImporteTotal = Decimal.Round(.Cantidad * .Precio, 2)
                     Else
                        .Precio = Decimal.Parse(dr("Costo").ToString())
                        ' .DescuentoRecargo = Decimal.Parse(dr("DescuentoRecargo").ToString())
                        .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())
                        '  .DescRecGeneral = Decimal.Parse(dr("DescRecGeneral").ToString())
                        '.ImporteTotalNeto = Decimal.Parse(dr("ImporteTotal").ToString())

                        '' ''.PrecioLista = Decimal.Parse(dr("PrecioLista").ToString())
                        If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc").ToString()) Then
                           .DescuentoRecargoPorc = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
                           .DescuentoRecargoProducto = dr.Field(Of Decimal)(Entidades.PedidoProductoProveedor.Columnas.DescuentoRecargoProducto.ToString())
                           .DescuentoRecargo = .DescuentoRecargoProducto * .Cantidad
                        End If

                        '' ''If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc2").ToString()) Then
                        '' ''   .DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
                        '' ''End If

                        '' ''.ImporteImpuestoInterno = Decimal.Parse(dr("ImporteImpuestoInternoPedido").ToString())
                        '' ''.PorcImpuestoInterno = Decimal.Parse(dr("PorcImpuestoInterno").ToString())

                        ' .DescuentoRecargo = Decimal.Parse(dr("DescuentoRecargo").ToString())
                        .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())
                        '    .DescRecGeneral = Decimal.Parse(dr("DescRecGeneral").ToString())
                        '' ''.ImporteTotalNeto = Decimal.Parse(dr("ImporteTotal").ToString())
                        'If .Producto.Moneda.IdMoneda = 2 Then
                        '   .Precio = Decimal.Round(.Precio * CotizacionDolar, 2)
                        '   .ImporteTotal = Decimal.Round(.Cantidad * .Precio, 2)
                        'End If
                     End If
                     .Stock = New Reglas.ProductosSucursales().GetUno(.IdSucursal, dr("IdProducto").ToString()).Stock
                     .Compra.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno("PEDIDO")
                     '.Utilidad = Decimal.Parse(dr("Utilidad").ToString())
                     '.Kilos = Decimal.Parse(dr("Kilos").ToString())
                     '.TipoImpuesto.IdTipoImpuesto = DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), "IVA"), Entidades.TipoImpuesto.Tipos)
                     .PorcentajeIVA = Decimal.Parse(dr("AlicuotaPedido").ToString())
                     '.ImporteImpuesto = Decimal.Parse(dr("ImporteImpuesto").ToString())
                  End With

                  pedido.ComprasProductos.Add(oMCP)

               Next
            End Using

            '---------------------------------------------------------------------------------------------

            oPedidos.Add(pedido)

         Next
      End Using

      Return oPedidos

   End Function

   Public Function GetEstadComprasProveedores(suc As List(Of Integer),
                                        cantidad As Integer,
                                        Desde As Date,
                                        Hasta As Date,
                                        discIVA As Boolean) As DataTable

      Dim sql As SqlServer.Compras
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Compras(da)

         dt = sql.GetEstadComprasProveedores(suc, cantidad, Desde, Hasta, discIVA)

         dt.Columns.Add("PorcImporte", System.Type.GetType("System.Decimal"))

         Dim sumapesos As Decimal = 0

         For Each dr As DataRow In dt.Rows
            sumapesos += Decimal.Parse(dr("Importe").ToString())
         Next
         For Each dr As DataRow In dt.Rows
            dr("PorcImporte") = Decimal.Round(Decimal.Parse(dr("Importe").ToString()) / sumapesos * 100, 2)
         Next

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetEstadComprasProveedores(suc As List(Of Integer),
                                        cantidad As Integer,
                                        Desde As Date,
                                        Hasta As Date,
                                        idMarca As Integer,
                                        idModelo As Integer,
                                        idRubro As Integer,
                                        idSubRubro As Integer,
                                        IdProducto As String,
                                        discIVA As Boolean) As DataTable

      Dim sql As SqlServer.Compras
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Compras(da)

         dt = sql.GetEstadComprasProveedores(suc, cantidad, Desde, Hasta, idMarca, idModelo, idRubro, idSubRubro, IdProducto, discIVA)

         dt.Columns.Add("PorcImporte", System.Type.GetType("System.Decimal"))

         Dim sumapesos As Decimal = 0

         For Each dr As DataRow In dt.Rows
            sumapesos += Decimal.Parse(dr("Importe").ToString())
         Next
         For Each dr As DataRow In dt.Rows
            dr("PorcImporte") = Decimal.Round(Decimal.Parse(dr("Importe").ToString()) / sumapesos * 100, 2)
         Next

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetParaExportarAFIP(idEmpresa As Integer, periodoFiscal As Integer) As DataTable
      Try

         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)

         Return sql.GetParaExportarAFIP(idEmpresa, periodoFiscal)

      Catch ex As Exception
         Throw
      End Try
   End Function

   Public Function GetParaExportarAFIPAlicuotas(idEmpresa As Integer, periodoFiscal As Integer) As DataTable
      Try

         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)

         Return sql.GetParaExportarAFIPAlicuotas(idEmpresa, periodoFiscal)

      Catch ex As Exception
         Throw
      End Try
   End Function
   Public Function GetParaExportarAFIPDespachoImportacion(idEmpresa As Integer, periodoFiscal As Integer) As DataTable
      Try

         Dim sql As SqlServer.Compras = New SqlServer.Compras(da)

         Return sql.GetParaExportarAFIPDespachoImportacion(idEmpresa, periodoFiscal)

      Catch ex As Exception
         Throw
      End Try
   End Function
   Public Function ProveedorPoseeFacturas(idProveedor As Long, grabaLibro As Boolean?) As Boolean
      Return New SqlServer.Compras(da).ProveedorPoseeFacturas(idProveedor, grabaLibro)
   End Function


#End Region

#Region "Overrides"
   <Obsolete("No usar este método, usar Insertar(Entidad, MetodoGrabacion, String)", True)>
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)

   End Sub

   Public Overloads Sub Insertar(entidad As Eniac.Entidades.Entidad, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.GrabarCompra(DirectCast(entidad, Entidades.Compra), MetodoGrabacion, IdFuncion)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region


   Public Function GetMovimientosConceptos(IdSucursal As Integer,
                                           Desde As Date?,
                                           Hasta As Date,
                                           IdProveedor As Long,
                                           GrabaLibro As String,
                                           AfectaCaja As String,
                                           IdTipoComprobante As String,
                                           IdRubroConcepto As Integer,
                                           excluirEnPasaje As Entidades.Publicos.SiNoTodos) As DataTable

      Return New SqlServer.Compras(da).GetMovimientosConceptos(IdSucursal, Desde, Hasta, IdProveedor,
                                                               GrabaLibro, AfectaCaja, IdTipoComprobante, IdRubroConcepto,
                                                               Publicos.PasajeComprasIncluyeImpuestos, excluirEnPasaje)

   End Function

   Public Function GetDespachosPorCodigo(idSucursal As Integer, parteId As String) As DataTable
      Dim sql As SqlServer.Compras = New SqlServer.Compras(da)
      If Publicos.ClaveLoteDespachoImportacion = Publicos.ClaveLoteDespachoImportacionEnum.DESPACHO.ToString() Then
         Return sql.GetDespachosPorCodigo(idSucursal, parteId)
      Else
         Return sql.GetDespachosPorManifiesto(idSucursal, parteId)
      End If
   End Function

   Public Sub ActualizaExcluirCompraDePasaje(idSucursal As Integer,
                                             idTipoComprobante As String,
                                             letra As String,
                                             centroEmisor As Integer,
                                             numeroComprobante As Long,
                                             IdProveedor As Long,
                                             valor As Boolean)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sCompras As SqlServer.Compras = New SqlServer.Compras(da)
         sCompras.ActualizaExcluirCompraDePasaje(idSucursal,
                                                 idTipoComprobante,
                                                 letra,
                                                 centroEmisor,
                                                 numeroComprobante,
                                                 IdProveedor,
                                                 valor)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Function GetComprasHolistorAExportar(fechaDesde As Date,
                                               fechaHasta As Date,
                                               idProveedor As Long,
                                               sucursales As Entidades.Sucursal(),
                                               tiposDeComprobantes As Entidades.TipoComprobante()) As DataTable

      Return New SqlServer.Compras(da).GetComprasHolistorAExportar(fechaDesde,
                                                                   fechaHasta,
                                                                   idProveedor,
                                                                   sucursales,
                                                                   tiposDeComprobantes)
   End Function

   Public Function Excluido(idSucursal As Integer,
                            idTipoComprobante As String,
                            letra As String,
                            centroEmisor As Integer,
                            numeroComprobante As Long,
                            idProveedor As Long) As Boolean

      Return New SqlServer.Compras(da).Excluido(idSucursal,
                                                idTipoComprobante,
                                                letra,
                                                centroEmisor,
                                                numeroComprobante,
                                                idProveedor)
   End Function


   Public Function CalculoExpensasAreasComunes(dtDistribucion As DataTable) As DataTable
      Dim dtAreas = New AreasComunes(da).GetAll()
      Dim dtExpensas = CreaTablaExpensasAreaComun()

      For Each drDistribucion As DataRow In dtDistribucion.Rows
         Dim importe As Decimal = 0
         If IsDBNull(drDistribucion("importe")) Then Continue For
         If Not Decimal.TryParse(drDistribucion("importe").ToString(), importe) Then Continue For
         If importe = 0 Then Continue For

         Dim drArea As DataRow() = dtAreas.Select(String.Format("{0} = '{1}'",
                                                  Eniac.Entidades.AreaComun.Columnas.IdAreaComun.ToString(),
                                                  drDistribucion(Eniac.Entidades.AreaComun.Columnas.IdAreaComun.ToString())))
         If drArea.Length > 0 Then
            If IsDBNull(drArea(0)(Eniac.Entidades.AreaComun.Columnas.IdNave.ToString())) AndAlso
               IsDBNull(drArea(0)(Eniac.Entidades.AreaComun.Columnas.IdCliente.ToString())) Then

               Dim total As Decimal = 0

               Dim drExpensas As DataRow = Nothing
               For Each drArea1 As DataRow In dtAreas.Rows
                  drExpensas = GetDrExpensasAreaComun(dtExpensas, drDistribucion)
                  Dim coeficiente As Decimal = CDec(drArea1(Eniac.Entidades.AreaComun.Columnas.Coeficiente.ToString()))

                  drExpensas(Eniac.Entidades.AreaComun.Columnas.IdAreaComun.ToString()) = drArea1(Eniac.Entidades.AreaComun.Columnas.IdAreaComun.ToString())
                  drExpensas(Eniac.Entidades.AreaComun.Columnas.NombreAreaComun.ToString()) = drArea1(Eniac.Entidades.AreaComun.Columnas.NombreAreaComun.ToString())
                  drExpensas("importe") = CDec(drExpensas("importe")) + Math.Round(importe * coeficiente, 2)
                  drExpensas(Eniac.Entidades.AreaComun.Columnas.Coeficiente.ToString()) = coeficiente

                  drExpensas("nave") = IsDBNull(drArea(0)(Eniac.Entidades.AreaComun.Columnas.IdNave.ToString()))

                  total += Math.Round(importe * coeficiente, 2)
               Next

               If drExpensas IsNot Nothing AndAlso total <> importe Then
                  drExpensas("importe") = drExpensas.Field(Of Decimal?)("importe").IfNull() - (total - importe)
               End If

            Else
               Dim drExpensas As DataRow = GetDrExpensasAreaComun(dtExpensas, drDistribucion)

               drExpensas(Eniac.Entidades.AreaComun.Columnas.IdAreaComun.ToString()) = drArea(0)(Eniac.Entidades.AreaComun.Columnas.IdAreaComun.ToString())
               drExpensas(Eniac.Entidades.AreaComun.Columnas.NombreAreaComun.ToString()) = drArea(0)(Eniac.Entidades.AreaComun.Columnas.NombreAreaComun.ToString())
               drExpensas("importe") = CDec(drExpensas("importe")) + importe
               drExpensas(Eniac.Entidades.AreaComun.Columnas.Coeficiente.ToString()) = drArea(0)(Eniac.Entidades.AreaComun.Columnas.Coeficiente.ToString())

               drExpensas(Eniac.Entidades.AreaComun.Columnas.IdNave.ToString()) = drArea(0)(Eniac.Entidades.AreaComun.Columnas.IdNave.ToString())
               drExpensas(Entidades.Cliente.Columnas.IdCliente.ToString()) = drArea(0)(Entidades.Cliente.Columnas.IdCliente.ToString())

               drExpensas("nave") = Not IsDBNull(drArea(0)(Eniac.Entidades.AreaComun.Columnas.IdNave.ToString()))
            End If
         End If
      Next

      Return dtExpensas
   End Function
   Public Shared Function CreaTablaExpensasAreaComun() As DataTable
      Dim dt As DataTable = New DataTable()

      dt.Columns.Add(Eniac.Entidades.AreaComun.Columnas.IdAreaComun.ToString(), GetType(String))
      dt.Columns.Add(Eniac.Entidades.AreaComun.Columnas.NombreAreaComun.ToString(), GetType(String))

      dt.Columns.Add("importe", GetType(Decimal))
      dt.Columns.Add("importeTasaMunicipal", GetType(Decimal))
      dt.Columns.Add(Eniac.Entidades.AreaComun.Columnas.Coeficiente.ToString(), GetType(Decimal))
      dt.Columns.Add("nave", GetType(Boolean))
      dt.Columns.Add(Eniac.Entidades.Nave.Columnas.IdNave.ToString(), GetType(Short))
      dt.Columns.Add(Entidades.Cliente.Columnas.IdCliente.ToString(), GetType(Short))

      Return dt
   End Function
   Public Function GetDrExpensasAreaComun(dtExpensas As DataTable, drDistribucion As DataRow) As DataRow
      Dim drExpensas As DataRow
      Dim drs As DataRow() = dtExpensas.Select(String.Format("{0} = '{1}'",
                                               Eniac.Entidades.AreaComun.Columnas.IdAreaComun,
                                               drDistribucion(Eniac.Entidades.AreaComun.Columnas.IdAreaComun)))

      If (drs.Length > 0) Then
         drExpensas = drs(0)
      Else
         drExpensas = dtExpensas.NewRow()
         dtExpensas.Rows.Add(drExpensas)

         drExpensas(Eniac.Entidades.AreaComun.Columnas.IdAreaComun.ToString()) = drDistribucion(Eniac.Entidades.AreaComun.Columnas.IdAreaComun.ToString())
         drExpensas(Eniac.Entidades.AreaComun.Columnas.NombreAreaComun.ToString()) = drDistribucion(Eniac.Entidades.AreaComun.Columnas.NombreAreaComun.ToString())
         If drDistribucion.Table.Columns.Contains("nave") Then
            drExpensas("nave") = drDistribucion("nave")
         End If
         If drDistribucion.Table.Columns.Contains(Eniac.Entidades.Nave.Columnas.IdNave.ToString()) Then
            drExpensas(Eniac.Entidades.Nave.Columnas.IdNave.ToString()) = drDistribucion(Eniac.Entidades.Nave.Columnas.IdNave.ToString())
         End If
         If drDistribucion.Table.Columns.Contains(Entidades.Cliente.Columnas.IdCliente.ToString()) Then
            drExpensas(Entidades.Cliente.Columnas.IdCliente.ToString()) = drDistribucion(Entidades.Cliente.Columnas.IdCliente.ToString())
         End If


         drExpensas(Eniac.Entidades.AreaComun.Columnas.Coeficiente.ToString()) = 0
         drExpensas("importe") = 0
         drExpensas("importeTasaMunicipal") = 0
         'drExpensas("nave") = False
      End If
      Return drExpensas
   End Function
   Public Function GetExpensas(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                               idProveedor As Long) As DataTable
      If Publicos.ExpensasRegistraComprasPor = Publicos.ExpensasRegistraComprasPorEnum.AreaComun.ToString() Then
         Dim sql = New SqlServer.ComprasDistribucionExpensas(da)
         Return sql.ComprasDistribucionExpensas_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                   idProveedor)
      ElseIf Publicos.ExpensasRegistraComprasPor = Publicos.ExpensasRegistraComprasPorEnum.GrupoCama.ToString() Then
         Dim sql = New SqlServer.ComprasDistribucionPorGrupo(da)
         Return sql.ComprasDistribucionPorGrupo_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                   idProveedor)
      End If
      Return Nothing
   End Function

   Public Function GetComprasPagosMensuales(sucursales As IEnumerable(Of Entidades.Sucursal),
                                            fechaDesde As Date, fechaHasta As Date, idProveedor As Long,
                                            idCategoria As Integer,
                                            idUsuario As String, grabaLibro As Entidades.Publicos.SiNoTodos) As DataTable
      Dim dt = New SqlServer.Compras(da).GetComprasPagosMensuales(sucursales, fechaDesde, fechaHasta, idProveedor,
                                                                  idCategoria,
                                                                  idUsuario, grabaLibro)

      dt.Columns.Add("MesFechaLetras", GetType(String))
      dt.AsEnumerable().ToList().ForEach(Sub(dr) dr.SetField("MesFechaLetras", dr.Field(Of Integer)("MesFecha").GetMesEnEspanol()))
      Return dt
   End Function

   Public Function GrabarComprobante(idSucursal As Integer,
                                    idTipoComprobante As String,
                                    idProveedor As Long,
                                    idCaja As Integer,
                                    fecha As Date,
                                    comprador As Entidades.Empleado,
                                    idFormasPago As Integer,
                                    observacion As String,
                                    importeTotal As Decimal,
                                    productos As List(Of Entidades.CompraProducto),
                                    observacionDetalladas As List(Of Entidades.CompraObservacion),
                                    contactos As List(Of Entidades.VentaClienteContacto),
                                    nombreProducto As String,
                                    cobrador As Entidades.Empleado,
                                    comprobantesAsociados As IEnumerable(Of Entidades.Compra),
                                    Rubro As Integer,
                                    metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                    idFuncion As String) As Entidades.Compra
      Return EjecutaConTransaccion(Function()
                                      Return _GrabarComprobante(idSucursal,
                                                                idTipoComprobante,
                                                                idProveedor,
                                                                idCaja,
                                                                fecha,
                                                                comprador,
                                                                idFormasPago,
                                                                observacion,
                                                                importeTotal,
                                                                productos,
                                                                observacionDetalladas,
                                                                contactos,
                                                                nombreProducto,
                                                                cobrador,
                                                                comprobantesAsociados,
                                                                Rubro,
                                                                metodoGrabacion,
                                                                idFuncion)
                                   End Function)
   End Function

   Public Function _GrabarComprobante(idSucursal As Integer,
                                      idTipoComprobante As String,
                                      idProveedor As Long,
                                      idCaja As Integer,
                                      fecha As Date,
                                      comprador As Entidades.Empleado,
                                      idFormasPago As Integer,
                                      observacion As String,
                                      importeTotal As Decimal,
                                      productos As List(Of Entidades.CompraProducto),
                                      observacionDetalladas As List(Of Entidades.CompraObservacion),
                                      contactos As List(Of Entidades.VentaClienteContacto),
                                      nombreProducto As String,
                                      cobrador As Entidades.Empleado,
                                      comprobantesAsociados As IEnumerable(Of Entidades.Compra),
                                      Rubro As Integer,
                                      metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                      idFuncion As String) As Entidades.Compra


      Dim _tipoImpuestoIVA = Entidades.TipoImpuesto.Tipos.IVA
      Dim _numeroOrden As Integer


      Dim cb As Entidades.Compra
      ''Dim Comprobante As Entidades.Compra
      '----------------------------------


      Dim _subTotales = New List(Of Entidades.CompraImpuesto)()
      Dim _productos = New List(Of Entidades.MovimientoStockProducto)

      'Me._estaCargando = False

      Dim _categoriaFiscalEmpresa = New CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim _proveedorE = New Proveedores(da)._GetUno(idProveedor, False)

      '*****  GENERO EL PRODUCTO, LOS IMPUESTOS y OTROS ****

      For Each dr As Entidades.CompraProducto In productos

         Dim Producto As Entidades.Producto
         Producto = New Reglas.Productos(da).GetUno(dr.Producto.IdProducto)

         Dim oLineaImpuestos As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
         Dim importeBruto As Decimal = 0
         Dim importeNeto As Decimal = 0
         Dim importeIva As Decimal = 0
         'Dim importeTotal As Decimal = 0

         Dim precioCosto As Decimal = 0
         Dim precioLista As Decimal = 0
         Dim alicuotaIVA As Decimal = Producto.Alicuota
         Dim IdMoneda As Integer = Producto.Moneda.IdMoneda

         Dim tipoComprobante = New Reglas.TiposComprobantes().GetUno(idTipoComprobante)

         'Me._numeroOrden += 1
         'Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)

         If Not tipoComprobante.UtilizaImpuestos Then
            alicuotaIVA = 0
         End If

         'If IdMoneda = 2 Then
         '   precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
         '   precioLista = Decimal.Round(precioLista * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
         'End If

         'If Producto.UnidadDeMedida.ConversionAKilos <> 0 Then
         '   Kilos = Decimal.Round(Producto.Tamano * Producto.UnidadDeMedida.ConversionAKilos, 3)
         'End If


         Dim PrecioVentaSinIVA As Decimal = Decimal.Round(dr.Precio / (1 + alicuotaIVA / 100), 2)
         Dim PrecioVentaConIVA As Decimal = dr.Precio
         Dim precioProducto As Decimal = 0

         If (_proveedorE.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
         Not _proveedorE.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Then
            precioProducto = PrecioVentaSinIVA
         Else
            'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
            precioProducto = PrecioVentaConIVA
         End If

         Dim cantidad As Decimal = dr.Cantidad

         Dim descRecPorGeneral As Decimal = 0

         Dim precioNeto As Decimal = 0

         _numeroOrden += 1

         '--------------------------------------------------------------------------------

         Dim alicuotaIVASobre100 As Decimal = (alicuotaIVA / 100)

         precioNeto = precioProducto

         importeBruto = precioProducto

         If Not _proveedorE.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
            importeIva = Decimal.Round(precioNeto - precioNeto / (1 + alicuotaIVASobre100), 2) * cantidad
         Else
            importeIva = Decimal.Round(precioNeto * alicuotaIVASobre100, 2) * cantidad
         End If

         Dim oLineaDetalle = New Entidades.MovimientoStockProducto()
         With oLineaDetalle
            .IdProducto = dr.Producto.IdProducto
            .NombreProducto = nombreProducto
            '.DescuentoRecargoPorc = Decimal.Parse(Me.txtDescuentoRecargoPorc.Text)
            '.DescuentoRecargo = Decimal.Parse(Me.txtDescuentoRecargo.Text)
            '' '.DescRecGeneral = Decimal.Parse(Me.txtPorcDescRecargoGral.Text)

            .Precio = precioProducto

            ' Dim descRec1 As Decimal = Decimal.Round(.Precio * .DescuentoRecargoPorc / 100, Me._decimalesRedondeoEnPrecio)
            'Dim descRec As Decimal = Decimal.Round((.Precio + descRec1) * .DescRecGeneral / 100, Me._valorRedondeo)

            importeBruto = .Precio * cantidad

            .Cantidad = cantidad
            .ImporteTotal = precioProducto
            '   .PrecioCostoO = Me._PO

            ' .DescRecGeneral = Decimal.Round((.ImporteTotal * Decimal.Parse(Me.txtPorcDescRecargoGral.Text) / 100), Me._decimalesRedondeoEnPrecio)

            .PorcentajeIVA = alicuotaIVA
            .IVA = importeIva

            'Dim Prod = New Productos(da).GetUno(.IdProducto)

            .IdDeposito = dr.IdDeposito ' Prod.IdDeposito
            .IdUbicacion = dr.IdUbicacion ' Prod.IdUbicacion

            'If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or
            '      Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or
            '      Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then

            '   If Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Then
            '      .PrecioCostoNuevo = Decimal.Round(ImporteBruto / (1 + Me._IVAO / 100), Me._decimalesRedondeoEnPrecio)
            '   Else
            '      .PrecioCostoNuevo = ImporteBruto
            '   End If
            'Else
            '   .PrecioCostoNuevo = ImporteBruto
            'End If

            ''Si no tiene IVA discriminado no deberia entrar
            'If Reglas.Publicos.PreciosConIVA And Me._proveedor.CategoriaFiscal.IvaDiscriminado Then
            '   .PrecioCostoNuevo = Decimal.Round(.PrecioCostoNuevo * (1 + Me._IVAO / 100), Me._decimalesRedondeoEnPrecio)
            'End If

            'If Prod.Moneda.IdMoneda = 2 Then
            '   .PrecioCostoNuevo = .PrecioCostoNuevo / Decimal.Parse(Me.txtCotizacionDolar.Text)
            'End If

            '.PrecioVentaActual = Me._precioVenta

            Dim porcentaje As Decimal = 0

            'If .PrecioCostoO > 0 Then
            '   porcentaje = Decimal.Round(.PrecioVentaActual / .PrecioCostoO, Me._decimalesRedondeoEnPrecio)
            'End If

            'If .PrecioVentaActual <> 0 Then
            '   .PorcentRecargo = (porcentaje - 1) * 100
            'End If


            '.PrecioVentaNuevo = Decimal.Round(.PrecioCostoNuevo * porcentaje, Me._decimalesRedondeoEnPrecio)
            'NO hace falta preguntar aca porque ahora lo bloqueo arriba.
            'If Not Me._proveedor.CategoriaFiscal.UtilizaImpuestos Or Not Me._categoriaFiscalEmpresa.UtilizaImpuestos Or _
            '   Not DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).UtilizaImpuestos Or _
            '   Not Me._proveedor.CategoriaFiscal.IvaDiscriminado Or Not Me._categoriaFiscalEmpresa.IvaDiscriminado Then
            '   .PorcentajeIVA = 0
            '   .IVA = 0
            'Else

            'End If

            .TotalProducto = .ImporteTotal + .IVA

            Dim var As Decimal = 0
            var = .PrecioCostoO - .PrecioCostoNuevo
            If .PrecioCostoNuevo <> 0 Then
               .PorcVar = (var / .PrecioCostoNuevo * 100) * -1
            Else
               If .PrecioCostoNuevo = var Then
                  .PorcVar = 0
               Else
                  .PorcVar = -100
               End If
            End If

            .Stock = 0
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
            .IdLote = dr.IdLote.IfNull()
            .VtoLote = dr.FechaVencimientoLote

            If dr.NrosSeries.AnySecure() Then
               .ProductosNrosSerie = dr.NrosSeries.ConvertAll(Function(ns)
                                                                 Return New Entidades.MovimientoStockProductoNrosSerie With {
                                                                    .IdSucursal = dr.IdSucursal,
                                                                    .IdDeposito = dr.IdDeposito,
                                                                    .IdUbicacion = dr.IdUbicacion,
                                                                    .IdProducto = dr.Producto.IdProducto,
                                                                    .NroSerie = ns.NroSerie,
                                                                    .Cantidad = 1,
                                                                    .Cantidad2 = 0
                                                                 }
                                                                 'result.IdTipoMovimiento =
                                                                 'result.NumeroMovimiento =
                                                                 'result.Orden =
                                                              End Function)
               .ProductoSucursal.Producto.NrosSeries = dr.NrosSeries.ConvertAll(Function(ns)
                                                                                   Return New Entidades.ProductoNroSerie With {
                                                                                      .Producto = New Entidades.Producto() With {.IdProducto = ns.IdProducto},
                                                                                      .IdSucursal = ns.IdSucursal,
                                                                                      .Sucursal = New Entidades.Sucursal() With {.IdSucursal = ns.IdSucursal},
                                                                                      .IdDeposito = ns.IdDeposito,
                                                                                      .IdUbicacion = ns.IdUbicacion,
                                                                                      .NroSerie = ns.NroSerie
                                                                                   }
                                                                                End Function)
            End If

            ''ingreso los valores del Lote
            ''##################
            ''#     LOTES      #
            ''##################
            'If Me._productoLoteTemporal.ProductoSucursal.Producto.Lote And DirectCast(Me.cboTipoComprobante.SelectedItem, Entidades.TipoComprobante).CoeficienteStock <> 0 Then
            '   Me.SeleccionDeLotes(oLineaDetalle, Me.txtLote.Text)
            'End If

            ''ingreso los nros. de serie
            '' VER PORQUE ELIMINA LOS RENGLONES QUE NO SE EDITARON

            'oLineaDetalle.ProductoSucursal.Producto = New Reglas.Productos().GetUno(.IdProducto)

            ''# Nro. de Serie
            'If oLineaDetalle.ProductoSucursal.Producto.NroSerie Then
            '   Me.CargarNumeroDeSerieProductosCompras(oLineaDetalle)
            'End If

            'If chbConcepto.Checked Then ' Me.cmbConceptos.SelectedItem IsNot Nothing Then
            '   .IdConcepto = Integer.Parse(Me.cmbConceptos.SelectedValue.ToString())
            '   .NombreConcepto = Me.cmbConceptos.Text.ToString()
            'End If

            .FechaActualizacion = Date.Now()

            ''--REQ-34986.- ---------------------------------------------
            '.IdaAtributoProducto01 = MovAtributo01.IdaAtributoProducto
            '.DescripcionAtributo01 = MovAtributo01.Descripcion
            '.IdaAtributoProducto02 = MovAtributo02.IdaAtributoProducto
            '.DescripcionAtributo02 = MovAtributo02.Descripcion
            '.IdaAtributoProducto03 = MovAtributo03.IdaAtributoProducto
            '.DescripcionAtributo03 = MovAtributo03.Descripcion
            '.IdaAtributoProducto04 = MovAtributo04.IdaAtributoProducto
            '.DescripcionAtributo04 = MovAtributo04.Descripcion
            ''---------------------------------------------------------
         End With

         ' Me.DefinirOrden(oLineaDetalle)

         If oLineaDetalle.Orden = 0 Then
            oLineaDetalle.Orden = _numeroOrden
         End If

         'If _utilizaCentroCostos Then
         '   oLineaDetalle.CentroCosto = DirectCast(cmbCentroCosto.SelectedItem, Entidades.ContabilidadCentroCosto)
         'End If
         'oLineaDetalle.CodigoProductoProveedor = Me._CodigoProductoProveedor

         _productos.Add(oLineaDetalle)

         importeNeto = precioNeto * cantidad

         'SI el CLIENTE es CF/MO o el Emisor; el monto llega CON IVA, hay que sacarselo.
         If (Not _proveedorE.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado) Then
            importeBruto = Decimal.Round(importeBruto / (1 + alicuotaIVA / 100), 2)
            importeNeto = Decimal.Round(importeNeto / (1 + alicuotaIVA / 100), 2)
         End If

         With oLineaImpuestos
            .Alicuota = alicuotaIVA
            .IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()
            .TipoTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()
            ' .NombreTipoImpuesto =
            .Bruto = importeBruto
            .BaseImponible = 0
            .Importe = importeIva
            .Importe_Calculado = dr.ImporteTotal
         End With

         _subTotales.Add(oLineaImpuestos)

      Next


      Dim rMovimientos = New MovimientosStock(da)
      Dim oMov = New Entidades.MovimientoStock()
      Dim oCF As Entidades.CategoriaFiscal = Nothing

      With oMov
         .Sucursal = New Reglas.Sucursales(da).GetUna(actual.Sucursal.Id, False)
         .IdCaja = idCaja
         .TipoMovimiento = New Reglas.TiposMovimientos(da).GetUnoPorComprobanteAsociado(idTipoComprobante)
         .FechaMovimiento = Date.Now()

         '.DescuentoRecargo = Decimal.Parse(Me.txtPorcDescRecargoGral.Text)

         .Compra.Comprador = comprador

         .Total = importeTotal

         .Proveedor = _proveedorE
         .Compra.TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(idTipoComprobante)
         If .Compra.TipoComprobante.LetrasHabilitadas = "X" Then
            .Compra.Letra = "X"
         Else
            .Compra.Letra = .Proveedor.CategoriaFiscal.LetraFiscal
         End If
         Dim Impresora = New Impresoras(da)._GetPorSucursalPCTipoComprobante(.Sucursal.Id, My.Computer.Name, .Compra.TipoComprobante.IdTipoComprobante)

         .Compra.CentroEmisor = Impresora.CentroEmisor

         .Compra.NumeroComprobante = New VentasNumeros(da).GetProximoNumero(.Sucursal, .Compra.TipoComprobante.IdTipoComprobante, .Compra.Letra, .Compra.CentroEmisor)

         'EsComercial=True excluye los Tipo de SALDOINICIAL.
         If .Compra.TipoComprobante.EsComercial Or .Compra.TipoComprobante.GeneraContabilidad Then
            .Compra.IdEmpresa = actual.Sucursal.IdEmpresa
            'If .Compra.TipoComprobante.GrabaLibro Then
            '   .Compra.PeriodoFiscal = Integer.Parse(Me.cboPeriodoFiscal.SelectedValue.ToString())
            'Else
            .Compra.PeriodoFiscal = Integer.Parse(.FechaMovimiento.ToString("yyyyMM"))
            ' End If
         End If

         'cambio los valores a grabar por si es una nota de credito u otro tipo que necesite grabarlo en forma negativa
         Dim coe As Integer = .Compra.TipoComprobante.CoeficienteValores


         '------------------------------------------
         'If Not oCF.IvaDiscriminado Then
         '   .Compra.Bruto210 = Decimal.Round((.Compra.Bruto210 / (1 + (.PorcentajeIVA / 100))), 2)
         'End If

         .Compra.DescuentoRecargo = .DescuentoRecargo * coe
         .Compra.DescuentoRecargoPorc = 0

         .Compra.IVAModificadoManual = False

         .Compra.PorcentajeIVA = .PorcentajeIVA * coe
         .Compra.ImporteTotal = .Total * coe
         '-------------------------------------------

         .Compra.Fecha = Date.Now()
         .Compra.FormaPago = New Reglas.VentasFormasPago(da).GetUna(idFormasPago)
         .Compra.Observacion = observacion
         'TODO: Analizar
         .Compra.PorcentajeIVA = 21    'Decimal.Parse(Me.lblPorcentaje.Text)
         .Compra.IdSucursal = .Sucursal.Id
         .Compra.Rubro = New Reglas.RubrosCompras(da).GetUno(Rubro)

         '.Compra.PercepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text) * coe
         '.Compra.PercepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text) * coe
         '.Compra.PercepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text) * coe
         '.Compra.PercepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text) * coe
         '.Compra.ImpuestosInternos = Decimal.Parse(Me.txtImpuestosInternos.Text) * coe


         'If .Compra.TipoComprobante.AfectaCaja Then
         '   'controlo el pago que se realiza si no va a la cuenta corriente
         '   If .Compra.FormaPago.Dias = 0 Then
         '      If Decimal.Parse(Me.txtTotalPago.Text) = 0 Then
         '         If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
         '            If Not Reglas.Publicos.ComprasContadoEsEnPesos AndAlso MessageBox.Show("El pago se realizara totalmente en pesos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
         '               Me.tbpPagosEfectivo.Focus()
         '               Me.txtEfectivo.Focus()
         '               Exit Sub
         '            Else
         '               Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
         '            End If
         '         End If
         '      Else
         '         'si puso algo en pagos, se debe controlar que la diferencia este en cero
         '         If Decimal.Parse(Me.txtDiferencia.Text) <> 0 Then
         '            Me.tbpPagosEfectivo.Focus()
         '            Me.txtEfectivo.Focus()
         '            Throw New Exception("El pago debe ser igual al total del comprobante.")
         '         End If
         '      End If
         '   End If
         'Else
         '   Me.txtEfectivo.Text = Me.txtTotalGeneral.Text
         'End If

         '.Compra.ChequesPropios = Me._chequesPropios
         ' .Compra.ChequesTerceros = Me._chequesTerceros

         .Compra.ImportePesos = 0
         ' .Compra.ImporteTarjetas = Decimal.Parse(Me.txtTarjetas.Text) * coe
         '.Compra.ImporteCheques = (Decimal.Parse(Me.txtChequesPropios.Text) + Decimal.Parse(Me.txtChequesTerceros.Text)) * coe
         'If Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And Me.bscCuentaBancariaTransfBanc.Selecciono Then
         '   .Compra.ImporteTransfBancaria = Decimal.Parse(Me.txtTransferenciaBancaria.Text)
         '   .Compra.CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaTransfBanc._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
         'End If

         'cargo las Observaciones
         .Compra.ComprasObservaciones = observacionDetalladas

         'cargo cotizacion dolar
         .Compra.CotizacionDolar = New Eniac.Reglas.Monedas(da).GetUna(Entidades.Moneda.Dolar).FactorConversion

         '.PercepcionIVA = Decimal.Parse(Me.txtPercepcionIVA.Text)
         '.PercepcionIB = Decimal.Parse(Me.txtPercepcionIIBB.Text)
         '.PercepcionGanancias = Decimal.Parse(Me.txtPercepcionGanancias.Text)
         '.PercepcionVarias = Decimal.Parse(Me.txtPercepcionVarias.Text)
         '.ImpuestosInternos = Decimal.Parse(Me.txtImpuestosInternos.Text)
         '.Compra.ComprasImpuestos.Clear()

         ' .Compra.ConceptoCM05 = If(chbAFIPConceptoCM05.Checked, cmbAFIPConceptoCM05.ItemSeleccionado(Of Entidades.AFIPConceptoCM05)(), Nothing)

         .Compra.ComprasImpuestos = _subTotales

         'For Each ci As Entidades.CompraImpuesto In _comprasImpuestos
         '   .Compra.ComprasImpuestos.Add(ci)
         'Next

         'For Each drProvincias As DataRow In _dtProvincias.Rows
         '   Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
         '   With ci
         '      .IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIIBB.ToString()
         '      .TipoTipoImpuesto = "PERCEPCION"
         '      .IdProvincia = drProvincias("IdProvincia").ToString()
         '      .NombreProvincia = drProvincias("NombreProvincia").ToString()
         '      '.Emisor = Integer.Parse(drProvincias("Emisor").ToString())
         '      '.Numero = Long.Parse(drProvincias("Numero").ToString())
         '      .BaseImponible = Decimal.Parse(drProvincias("BaseImponible").ToString())
         '      .Alicuota = Decimal.Parse(drProvincias("Alicuota").ToString())
         '      .Importe = Decimal.Parse(drProvincias("Importe").ToString())
         '   End With
         '   .Compra.ComprasImpuestos.Add(ci)
         'Next

         'If .PercepcionGanancias <> 0 Then
         '   Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
         '   ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PGANA.ToString()
         '   ci.TipoTipoImpuesto = "PERCEPCION"
         '   ci.Importe = .PercepcionGanancias
         '   .Compra.ComprasImpuestos.Add(ci)
         'End If
         'If .PercepcionIVA <> 0 Then
         '   Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
         '   ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIVA.ToString()
         '   ci.TipoTipoImpuesto = "PERCEPCION"
         '   ci.Importe = .PercepcionIVA
         '   .Compra.ComprasImpuestos.Add(ci)
         'End If
         'If .PercepcionVarias <> 0 Then
         '   Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
         '   ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PVAR.ToString()
         '   ci.TipoTipoImpuesto = "PERCEPCION"
         '   ci.Importe = .PercepcionVarias
         '   .Compra.ComprasImpuestos.Add(ci)
         'End If

         'If .ImpuestosInternos <> 0 Then
         '   Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
         '   ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IMINT.ToString()
         '   ci.TipoTipoImpuesto = "PERCEPCION"
         '   ci.Importe = .ImpuestosInternos
         '   .Compra.ComprasImpuestos.Add(ci)
         'End If

         'If .Compra.TipoComprobante.EsDespachoImportacion Then
         '   For Each cid As Entidades.CompraImpuesto In _comprasImpuestosDespachoImportacion
         '      Dim ci As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
         '      ci.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA.ToString()
         '      ci.TipoTipoImpuesto = "PERCEPCION"
         '      ci.BaseImponible = cid.BaseImponible
         '      ci.Alicuota = cid.Alicuota
         '      ci.Importe = cid.Importe
         '      ci.EsDespacho = True
         '      .Compra.ComprasImpuestos.Add(ci)
         '   Next

         '   .Compra.FechaOficializacionDespacho = dtpFechaOficializacion.Value
         '   .Compra.IdAduana = Integer.Parse(bscCodigoAduana.Text.ToString())
         '   .Compra.IdDestinacion = bscCodigoDestinacion.Text.ToString()

         '   .Compra.NumeroDespacho = Long.Parse(txtNumeroDespacho.Text)
         '   .Compra.DigitoVerificadorDespacho = txtDigitoVerificador.Text
         '   .Compra.NumeroManifiestoDespacho = txtNumeroManifiesto.Text

         '   .Compra.IdDespachante = Integer.Parse(bscCodigoDespachante.Text.ToString())
         '   .Compra.IdAgenteTransporte = Integer.Parse(bscCodigoAgenteTransporte.Text.ToString())

         '   .Compra.DerechoAduanero = Decimal.Parse(txtDerechoAduana.Text)
         '   .Compra.BienCapitalDespacho = chbBienCapital.Checked
         'End If

         '.Comentarios = Me.bscObservacion.Text.Trim()
         .Observacion = observacion

         'If Not .Compra.TipoComprobante.EsRemitoTransportista Then
         .Productos = _productos

         For Each p In _productos
            If Not String.IsNullOrWhiteSpace(p.IdLote) Then
               .ProductosLotes.Add(New Entidades.ProductoLote() With {
                                    .IdSucursal = p.IdSucursal,
                                    .IdDeposito = p.IdDeposito,
                                    .IdUbicacion = p.IdUbicacion,
                                    .ProductoSucursal = New Entidades.ProductoSucursal() With {.Producto = New Entidades.Producto() With {.IdProducto = p.IdProducto}},
                                    .IdLote = p.IdLote,
                                    .FechaIngreso = Date.Now,
                                    .FechaVencimiento = p.VtoLote,
                                    .CantidadActual = p.Cantidad,
                                    .CantidadActualOriginal = p.Cantidad,
                                    .Habilitado = True
                                })
            End If
            For Each ns In p.ProductosNrosSerie
               .ProductosNrosSerie.Add(New Entidades.ProductoNroSerie() With {
                                       .IdSucursal = p.IdSucursal,
                                       .Sucursal = New Entidades.Sucursal() With {.IdSucursal = p.IdSucursal},
                                       .IdDeposito = p.IdDeposito,
                                       .IdUbicacion = p.IdUbicacion,
                                       .Producto = New Entidades.Producto() With {.IdProducto = p.IdProducto},
                                       .Vendido = oMov.TipoMovimiento.CoeficienteStock < 0,
                                       .NroSerie = ns.NroSerie,
                                       .TipoComprobante = oMov.Compra.TipoComprobante,
                                       .Letra = oMov.Compra.Letra,
                                       .CentroEmisor = oMov.Compra.CentroEmisor,
                                       .NumeroComprobante = oMov.Compra.NumeroComprobante,
                                       .Proveedor = oMov.Compra.Proveedor
                                    })
            Next
         Next

         oMov.Productos.ForEach(Sub(p) p.ProductoSucursal.Producto.NrosSeries.
                                   ForEach(Sub(ns)
                                              ns.TipoComprobante = oMov.Compra.TipoComprobante
                                              ns.Letra = oMov.Compra.Letra
                                              ns.CentroEmisor = oMov.Compra.CentroEmisor
                                              ns.NumeroComprobante = oMov.Compra.NumeroComprobante
                                              ns.Proveedor = oMov.Compra.Proveedor
                                           End Sub))

         'Else
         '   .Productos = Me._productosRT

         '   If IsNumeric(txtNumeroLote.Text) Then
         '      .Compra.NumeroLote = Long.Parse(txtNumeroLote.Text)
         '   End If
         '   If IsNumeric(txtValorDeclarado.Text) Then
         '      .Compra.ValorDeclarado = Decimal.Parse(txtValorDeclarado.Text)
         '   End If
         '   If IsNumeric(txtBultos.Text) Then
         '      .Compra.Bultos = Integer.Parse(txtBultos.Text)
         '   End If

         '   .Compra.Transportista = _transportistaA

         'End If

         '# Valido que de los productos ingresados, en caso de utilizar Lote, se hayan seleccionado.
         'For Each p As Entidades.MovimientoCompraProducto In .Productos
         '   If p.ProductoSucursal.Producto.Lote Then

         '      '# Si no hay registros dentro de Productos Lotes es porque no se seleccionó/seleccionaron los lotes.
         '      If _productosLotes.Count = 0 Then
         '         Throw New Exception("No se seleccionó Lote para los productos")
         '      End If

         '      '# Si hay registros, busco puntualmente si se agregaron los lotes de los productos ingresados
         '      For Each pLote As Entidades.ProductoLote In _productosLotes
         '         If _productosLotes.Any(Function(x) x.ProductoSucursal.Producto.IdProducto.Equals(p.IdProducto) And p.IdLote = Nothing) Then
         '            Throw New Exception(String.Format("ATENCIÓN: No se seleccionó Lote para el producto {0} de la linea {1}.",
         '                                p.ProductoSucursal.Producto.NombreProducto,
         '                                p.Orden))
         '         End If
         '      Next
         '   End If
         'Next

         '.ProductosLotes = Me._productosLotes
         '.ProductosNrosSerie = Me._productosNrosSeries
         .Usuario = actual.Nombre

         ''cargo los cheques emitidos (propios)
         '.Compra.CuentaCorrienteProv.ChequesPropios = Me._chequesPropios

         ''cargo los cheques de terceros
         '.Compra.CuentaCorrienteProv.ChequesTerceros = Me._chequesTerceros

         'Cargo los Comprobantes Facturados (tal vez ninguno)
         .Compra.Facturables = comprobantesAsociados.ToList()

         'Al marcar que llamo a otro/s no permito que lo elijan y hagan un ciclo. A menos que Sea un PRESUPUESTO !
         If comprobantesAsociados.AnySecure() AndAlso .Compra.TipoComprobante.CoeficienteStock <> 0 Then
            .Compra.IdEstadoComprobante = "INVOCO"
            .Compra.CantidadInvocados = comprobantesAsociados.Count
         Else
            .Compra.CantidadInvocados = 0
         End If

         .Compra.Usuario = actual.Nombre
         .Compra.FechaActualizacion = Date.Now()

         'If Not Me._proveedor.EsProveedorGenerico Then
         '   .Compra.IdcategoriaFiscal = Me._proveedor.CategoriaFiscal.IdCategoriaFiscal
         '   .Compra.NombreProveedor = Me.bscProveedor2.Text
         'Else
         .Compra.IdcategoriaFiscal = .Proveedor.CategoriaFiscal.IdCategoriaFiscal
         .Compra.NombreProveedor = .Proveedor.NombreProveedor
         'End If
         '.Compra.CuitProveedor = Me.txtCUIT.Text

         '# En principio todas las compras van incluidas
         .Compra.ExcluirDePasaje = False

         '-.PE-31849.-
         .Compra.MercEnviada = False
      End With

      If oMov.Compra.TipoComprobante.ActualizaCtaCte Then

         If oMov.Compra.FormaPago.Dias > 0 Then
            'si el cliente compro el modulo de cuenta corriente
            If Publicos.TieneModuloCuentaCorrienteProveedores Then

               Dim oCCP = New Entidades.CuentaCorrienteProvPago()
               oCCP.ImporteCuota = importeTotal
               oCCP.SaldoCuota = oCCP.ImporteCuota
               oCCP.FechaVencimiento = oMov.Compra.Fecha.AddDays(oMov.Compra.FormaPago.Dias)
               oMov.Compra.CuentaCorrienteProv.Pagos.Add(oCCP)
            End If

         End If

      End If


      ''Si el tipo de pago es cuenta corriente tengo que levantar la pantalla de Cuenta Corriente
      'If oMov.Compra.TipoComprobante.ActualizaCtaCte Then
      '   If oMov.Compra.FormaPago.Dias > 0 Then
      '      'si el cliente compro el modulo de cuenta corriente
      '      If Reglas.Publicos.TieneModuloCuentaCorrienteProveedores Then

      '         If Not Reglas.Publicos.CtaCteProv.UtilizaCuotasVencimientoCtaCteProveedores Then

      '            If MessageBox.Show("Confirma enviar el Comprobante a Cuenta Corriente?", Me.Text, MessageBoxButtons.YesNo) <> Windows.Forms.DialogResult.Yes Then
      '               Me.tsbGrabar.Enabled = True
      '               Exit Sub
      '            End If

      '            Dim oCCP As Entidades.CuentaCorrienteProvPago
      '            oCCP = New Entidades.CuentaCorrienteProvPago()
      '            oCCP.ImporteCuota = Decimal.Parse(Me.txtTotalGeneral.Text)
      '            oCCP.SaldoCuota = oCCP.ImporteCuota
      '            oCCP.FechaVencimiento = Me.dtpFecha.Value.AddDays(oMov.Compra.FormaPago.Dias)
      '            oMov.Compra.CuentaCorrienteProv.Pagos.Add(oCCP)

      '         Else

      '            Dim cc As CuentaCorrienteProveedorV2 = New CuentaCorrienteProveedorV2(Me.dtpFecha.Value, Decimal.Parse(Me.txtTotalGeneral.Text), oMov.Compra.FormaPago.IdFormasPago)
      '            If cc.ShowDialog() = Windows.Forms.DialogResult.OK Then
      '               'recuperar los datos para armar la cuenta corriente
      '               Dim oCCP As Entidades.CuentaCorrienteProvPago
      '               For Each dr As DataRow In cc.Pagos.Rows
      '                  oCCP = New Entidades.CuentaCorrienteProvPago()
      '                  oCCP.ImporteCuota = Decimal.Parse(dr("MontoAPagar").ToString())
      '                  oCCP.SaldoCuota = oCCP.ImporteCuota
      '                  oCCP.FechaVencimiento = DateTime.Parse(dr("FechaAPagar").ToString())
      '                  oMov.Compra.CuentaCorrienteProv.Pagos.Add(oCCP)
      '               Next
      '            Else
      '               Me.tsbGrabar.Enabled = True
      '               Throw New Exception("Debe ingresar la forma de pago para poder grabar e imprimir.")
      '            End If

      '         End If

      '      End If
      '   End If

      'End If

      Dim _dtExpensas = New DataTable()
      rMovimientos._Insertar(oMov, _dtExpensas, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

      'Lo asigno completo para que tenga valor en el procedimiento que lo llamo.
      cb = GetUna(oMov.Compra.IdSucursal,
               oMov.Compra.TipoComprobante.IdTipoComprobante,
               oMov.Compra.Letra,
               oMov.Compra.CentroEmisor,
               oMov.Compra.NumeroComprobante,
               oMov.Compra.Proveedor.IdProveedor)

      Return cb

   End Function

#Region "Validaciones"
   Public Sub ValidaMediosPagoSegunFormaPago(tipoComprobante As Entidades.TipoComprobante,
                                             formaPago As Entidades.VentaFormaPago,
                                             efectivo As Decimal,
                                             transferencia As Decimal,
                                             cheques As List(Of Cheque))
      If tipoComprobante IsNot Nothing Then
         If tipoComprobante.AfectaCaja Or tipoComprobante.EsPreElectronico Then

            If formaPago IsNot Nothing AndAlso formaPago.RequiereAlgo Then
               Dim algunoValido As Boolean = False
               Dim mediosPagoRequeridos As StringBuilder = New StringBuilder()
               If formaPago.RequierePesos Then
                  ValidaIndividual(mediosPagoRequeridos, algunoValido, "Pesos", Function() efectivo <> 0)
               End If

               'If formaPago.RequiereDolares Then
               '   ValidaIndividual(mediosPagoRequeridos, algunoValido, "Dolares", Function() dolares <> 0)
               'End If

               'If formaPago.RequiereTickets Then
               '   ValidaIndividual(mediosPagoRequeridos, algunoValido, "Tickets", Function() tickets <> 0)
               'End If

               If formaPago.RequiereTransferencia Then
                  ValidaIndividual(mediosPagoRequeridos, algunoValido, "Transferencia", Function() transferencia <> 0)
               End If

               If formaPago.RequiereCheques Then
                  ValidaIndividual(mediosPagoRequeridos, algunoValido, "Cheques", Function() cheques.Count > 0)
               End If

               'If formaPago.RequiereTarjetaDebito Then
               '   ValidaIndividual(mediosPagoRequeridos, algunoValido, "Tarjeta Débito", Function() Tarjetas.Where(Function(x) x.Tarjeta.TipoTarjeta = Tarjeta.TiposTarjetas.Debito).Count > 0)
               'End If

               'If formaPago.RequiereTarjetaCredito Then
               '   ValidaIndividual(mediosPagoRequeridos, algunoValido, "Tarjeta Crédito (2 o más Pagos)", Function() Tarjetas.Where(Function(x) x.Tarjeta.TipoTarjeta = Tarjeta.TiposTarjetas.Credito And x.Cuotas <> 1).Count > 0)
               'End If

               'If formaPago.RequiereTarjetaCredito1Pago Then
               '   ValidaIndividual(mediosPagoRequeridos, algunoValido, "Tarjeta Crédito (1 Pago)", Function() Tarjetas.Where(Function(x) x.Tarjeta.TipoTarjeta = Tarjeta.TiposTarjetas.Credito And x.Cuotas = 1).Count > 0)
               'End If

               If Not algunoValido Then
                  Throw New Exception(String.Format("La forma de pago seleccionada ({1}) requiere al menos alguno de los siguientes medios de pago:{0}{0}{2}{0}{0}Verifique los medios de pago seleccionados",
                                                    Environment.NewLine, formaPago.DescripcionFormasPago, mediosPagoRequeridos.ToString()))
               End If
            End If

         End If      'If formaPago IsNot Nothing AndAlso formaPago.RequiereAlgo Then
      End If         'If tipoComprobante IsNot Nothing AndAlso tipoComprobante.AfectaCaja Then
   End Sub

   Private Sub ValidaIndividual(stb As StringBuilder, ByRef algunovalido As Boolean, medioPago As String, controlaValido As Func(Of Boolean))
      stb.AppendFormatLine("    - {0}", medioPago)
      If controlaValido() Then
         algunovalido = True
      End If

   End Sub

#End Region

End Class