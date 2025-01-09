Partial Class Ventas

   ''GET SECUNDARIOS

   Public Function GetInfComparativoDiario(sucursales As Entidades.Sucursal(),
                                           desde As Date, hasta As Date,
                                           idVendedor As Integer, idCliente As Long,
                                           idMarca As Integer, idRubro As Integer, idProducto As String, idZonaGeografica As String, idLocalidad As Integer,
                                           campoTotalizar As Entidades.Publicos.ComparativoDiario_CampoTotalizar,
                                           conIva As Boolean) As DataTable
      Return EjecutaConConexion(
         Function()
            Return New SqlServer.Ventas(da).GetInfComparativoDiario(
                              sucursales,
                              desde, hasta,
                              idVendedor, idCliente,
                              idMarca, idRubro, idProducto, idZonaGeografica, idLocalidad,
                              campoTotalizar,
                              conIva)
         End Function)
   End Function

   Public Function ClienteDeComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return New SqlServer.Ventas(da).ClienteDeComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function

   Public Function GetComprobantesElectronicos(estado As Entidades.AFIPCAE.EstadoElectronicos,
                                               fechaDesde As Date, fechaHasta As Date,
                                               idCliente As Long,
                                               numeroRepartoDesde As Integer, numeroRepartoHasta As Integer,
                                               tipoComprobantes As Entidades.TipoComprobante(), letraFiscal As String, centroEmisor As Integer, numeroComprobante As Long,
                                               idCategoria As Integer, idUsuario As String, IdVendedor As Integer, idFormasPago As Integer,
                                               nroRepartoInvocacionMasiva As Integer) As DataTable
      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
      Return sql.GetComprobantesElectronicos(estado,
                                             fechaDesde, fechaHasta,
                                             idCliente,
                                             numeroRepartoDesde, numeroRepartoHasta,
                                             tipoComprobantes, letraFiscal, centroEmisor, numeroComprobante,
                                             idCategoria, idUsuario, IdVendedor, idFormasPago,
                                             actual.Sucursal.IdEmpresa, actual.Sucursal.Id,
                                             nroRepartoInvocacionMasiva)
   End Function
   Public Function GetComprobantesFiscales(estado As Entidades.AFIPCAE.EstadoElectronicos,
                                           fechaDesde As Date, fechaHasta As Date,
                                           idCliente As Long,
                                           numeroRepartoDesde As Integer, numeroRepartoHasta As Integer,
                                           idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroComprobante As Long,
                                           idCategoria As Integer, idUsuario As String, IdVendedor As Integer, idFormasPago As Integer) As DataTable
      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
      Return sql.GetComprobantesFiscales(estado,
                                         fechaDesde, fechaHasta,
                                         idCliente,
                                         numeroRepartoDesde, numeroRepartoHasta,
                                         idTipoComprobante, letraFiscal, centroEmisor, numeroComprobante,
                                         idCategoria, idUsuario, IdVendedor, idFormasPago,
                                         actual.Sucursal.IdEmpresa, actual.Sucursal.Id)
   End Function

   Public Function GetComprobantesSinCAE(idSucursal As Integer, desde As Date, hasta As Date) As DataTable
      Return New SqlServer.Ventas(da).GetComprobantesSinCAE(idSucursal, desde, hasta)
   End Function

   Public Function GetNoCompradores(
                     desde As Date,
                     idCliente As Long, idVendedor As Integer,
                     idZonaGeografica As String, idCategoria As Integer,
                     idMarca As Integer, idRubro As Integer,
                     idLocalidad As Integer, idProvincia As String, idRuta As Integer,
                     activo As Entidades.Publicos.SiNoTodos) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.Ventas(da).
                                    GetNoCompradores(desde, idCliente, idVendedor, idZonaGeografica, idCategoria,
                                                     idMarca, idRubro, idLocalidad, idProvincia, idRuta, activo))
   End Function

   Public Function Emisor(idSucursal As Integer, centroEmisor As Short) As Boolean
      Return New SqlServer.Ventas(da).Emisor(idSucursal, centroEmisor)
   End Function

   Public Function GetUltimosNumerosComprobantes(idSucursal As Integer, tipo As String, anularComprobantesSinEmitir As Boolean) As DataTable
      Return New SqlServer.Ventas(da).GetUltimosNumerosComprobantes(idSucursal, tipo, anularComprobantesSinEmitir, Publicos.CtaCte.ReciboComparteNumeracionEntreSucursales)
   End Function

   Public Function GetProductosAlertaPorCaja(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As DataTable
      Return EjecutaConTransaccion(Function() New SqlServer.Ventas(da).GetProductosAlertaPorCaja(idSucursal, idCaja, numeroPlanilla))
   End Function

   Public Function GetVentasCobranzasMensuales(sucursales As IEnumerable(Of Entidades.Sucursal),
                                               fechaDesde As Date, fechaHasta As Date, idCliente As Long,
                                               idCategoria As Integer, origenCategoria As Entidades.OrigenFK,
                                               idVendedor As Long, origenVendedor As Entidades.OrigenFK,
                                               idUsuario As String, idZonaGeografica As String, grabaLibro As Entidades.Publicos.SiNoTodos) As DataTable
      Dim dt = New SqlServer.Ventas(da).GetVentasCobranzasMensuales(sucursales, fechaDesde, fechaHasta, idCliente,
                                                                   idCategoria, origenCategoria,
                                                                   idVendedor, origenVendedor,
                                                                   idUsuario, idZonaGeografica, grabaLibro)
      dt.Columns.Add("MesFechaLetras", GetType(String))
      dt.AsEnumerable().ToList().ForEach(Sub(dr) dr.SetField("MesFechaLetras", dr.Field(Of Integer)("MesFecha").GetMesEnEspanol()))
      Return dt
   End Function

End Class