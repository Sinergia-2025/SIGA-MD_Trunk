Partial Class Ventas

#Region "Get Utilidades"
   Public Function GetUtilidadesPorCliente(sucursales As Entidades.Sucursal(),
                                           desde As Date, Hasta As Date,
                                           idCliente As Long, idVendedor As Integer,
                                           idZonaGeografica As String, idLocalidad As Integer,
                                           esComercial As Entidades.Publicos.SiNoTodos) As DataTable
      Return GetUtilidadesPor(Entidades.Venta.TipoUtilidad.CLIENTE, sucursales, desde, Hasta, idVendedor, False, 0, 0, idCliente, "", idZonaGeografica, idLocalidad,
                              idListaDePrecios:=-1, idMarca:=0, mostrarProveedorHabitual:=False, idProveedorHabitual:=0, esComercial:=esComercial,
                              listaComprobantes:=Nothing, grabaLibro:="TODOS", grupo:=Nothing)
   End Function

   Public Function GetUtilidadesPor(xTipo As Entidades.Venta.TipoUtilidad,
                                    sucursales As Entidades.Sucursal(),
                                    desde As Date,
                                    hasta As Date,
                                    idVendedor As Integer,
                                    agruparSucursales As Boolean,
                                    idRubro As Integer,
                                    idSubrubro As Integer,
                                    idCliente As Long,
                                    idProducto As String,
                                    idZonaGeografica As String,
                                    idLocalidad As Integer,
                                    idListaDePrecios As Integer,
                                    idMarca As Integer,
                                    mostrarProveedorHabitual As Boolean,
                                    idProveedorHabitual As Long,
                                    esComercial As Entidades.Publicos.SiNoTodos,
                                    listaComprobantes As List(Of Entidades.TipoComprobante),
                                    grabaLibro As String,
                                    grupo As Entidades.Grupo()) As DataTable

      Dim dt = New SqlServer.Ventas(da).GetUtilidadesPor(xTipo, sucursales, agruparSucursales, desde, hasta, actual.NivelAutorizacion,
                                                         idVendedor, idRubro, idSubrubro, idCliente, idProducto,
                                                         idZonaGeografica, idLocalidad, idListaDePrecios, idMarca, mostrarProveedorHabitual,
                                                         idProveedorHabitual, esComercial, listaComprobantes, grabaLibro, grupo)

      Dim oSumaUtilidad As Object = dt.Compute("SUM(Utilidad)", "")
      Dim oSumaUtilidadConImpuestos As Object = dt.Compute("SUM(UtilidadConImpuestos)", "")

      Dim sumaUtilidad As Decimal = If(IsNumeric(oSumaUtilidad), Decimal.Parse(oSumaUtilidad.ToString()), 0)
      Dim sumaUtilidadConImpuestos As Decimal = If(IsNumeric(oSumaUtilidadConImpuestos), Decimal.Parse(oSumaUtilidadConImpuestos.ToString()), 0)

      dt.Columns.Add("Margen", GetType(Decimal), "Utilidad /  IIF(Total = 0, 1, Total) * 100")
      dt.Columns.Add("MargenConImpuestos", GetType(Decimal), "UtilidadConImpuestos / IIF(TotalConImpuestos = 0, 1, TotalConImpuestos) * 100")

      dt.Columns.Add("MargenGlobal", GetType(Decimal), String.Format("Utilidad / {0} * 100", If(sumaUtilidad = 0, 1, sumaUtilidad)))
      dt.Columns.Add("MargenGlobalConImpuestos", GetType(Decimal), String.Format("UtilidadConImpuestos / {0} * 100", If(sumaUtilidadConImpuestos = 0, 1, sumaUtilidadConImpuestos)))

      Return dt

   End Function

   Public Function GetUtilidadesPorProducto(sucursales As Entidades.Sucursal(),
                                            desde As Date,
                                            hasta As Date,
                                            idVendedor As Integer,
                                            idMarca As Integer,
                                            idRubro As Integer,
                                            idSubrubro As Integer,
                                            idProducto As String,
                                            esComercial As Entidades.Publicos.SiNoTodos) As DataTable
      Return GetUtilidadesPor(Entidades.Venta.TipoUtilidad.PRODUCTO, sucursales, desde, hasta, idVendedor, False, idRubro, idSubrubro, 0, idProducto, "", 0,
                              idListaDePrecios:=-1, idMarca:=idMarca, mostrarProveedorHabitual:=False, idProveedorHabitual:=0, esComercial:=esComercial,
                              listaComprobantes:=Nothing, grabaLibro:="TODOS", grupo:=Nothing)
   End Function
#End Region

#Region "Get Comisiones"
   Public Function GetComisionesTotalesPorVendedor(sucursales As Entidades.Sucursal(),
                                                   desde As Date,
                                                   hasta As Date,
                                                   conComision As String,
                                                   idCliente As Long,
                                                   idZonaGeografica As String,
                                                   afectaCaja As String,
                                                   conIVA As Boolean,
                                                   unificarComisiones As Boolean,
                                                   activaObjetivo As Boolean,
                                                   listaComprobantes As IEnumerable(Of Entidades.TipoComprobante),
                                                   grabaLibro As String,
                                                   grupos As Entidades.Grupo(),
                                                   IdVendedor As Integer,
                                                   tipoVendedor As Entidades.OrigenFK) As DataTable

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Return New SqlServer.Ventas(da).GetComisionesTotalesPorVendedor(sucursales,
                                                                      desde, hasta,
                                                                      conComision,
                                                                      idCliente,
                                                                      idZonaGeografica,
                                                                      afectaCaja,
                                                                      conIVA,
                                                                      unificarComisiones,
                                                                      oCategoriaFiscalEmpresa.IvaDiscriminado,
                                                                      Publicos.CalculoComisionVendedor,
                                                                      Publicos.ComisionVendedor,
                                                                      activaObjetivo,
                                                                      listaComprobantes,
                                                                      grabaLibro,
                                                                      grupos,
                                                                      IdVendedor,
                                                                      tipoVendedor)
   End Function

   Public Function GetComprobantesTotalesClientesPorVendedor(sucursales As Entidades.Sucursal(),
                                                             fechaDesde As DateTime,
                                                             fechaHasta As DateTime,
                                                             idVendedor As Integer,
                                                             conIva As Boolean,
                                                             conComision As String,
                                                             idCliente As Long,
                                                             idMarca As Integer,
                                                             idRubro As Integer,
                                                             idSubRubro As Integer,
                                                             idZonaGeografica As String,
                                                             listaComprobantes As List(Of Entidades.TipoComprobante),
                                                             grabaLibro As String,
                                                             grupo As String) As DataTable

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim strCalculoComisionVendedor As String = Publicos.CalculoComisionVendedor
      Dim comisionVendedor As String = Reglas.Publicos.ComisionVendedor

      Return New SqlServer.Ventas(da).GetComprobantesTotalesClientesPorVendedor(sucursales,
                                                                                fechaDesde,
                                                                                fechaHasta,
                                                                                idVendedor,
                                                                                oCategoriaFiscalEmpresa,
                                                                                conIva,
                                                                                strCalculoComisionVendedor,
                                                                                comisionVendedor,
                                                                                conComision,
                                                                                idCliente,
                                                                                idMarca,
                                                                                idRubro,
                                                                                idSubRubro,
                                                                                idZonaGeografica,
                                                                                listaComprobantes,
                                                                                grabaLibro,
                                                                                grupo)

   End Function

   Public Function GetComisionesTotalesMarcasPorVendedor(sucursales As Entidades.Sucursal(),
                                                         desde As Date,
                                                         hasta As Date,
                                                         conComision As String,
                                                         unificarMarcas As Boolean,
                                                         idVendedor As Integer,
                                                         idCliente As Long,
                                                         marcas As Entidades.Marca(),
                                                         rubros As Entidades.Rubro(),
                                                         subrubros As Entidades.SubRubro(),
                                                         idZonaGeografica As String,
                                                         conIva As Boolean,
                                                         listaComprobantes As List(Of Entidades.TipoComprobante),
                                                         grabaLibro As String,
                                                         grupo As String,
                                                         IdFormaPago As Integer,
                                                         IdListaPrecios As Integer) As DataTable

      Dim oCategoriaFiscalEmpresa = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim strCalculoComisionVendedor = Publicos.CalculoComisionVendedor

      Dim sql = New SqlServer.Ventas(da)
      Return sql.GetComisionesTotalesMarcasPorVendedor(sucursales,
                                                       desde,
                                                       hasta,
                                                       oCategoriaFiscalEmpresa,
                                                       strCalculoComisionVendedor,
                                                       Publicos.ComisionVendedor,
                                                       conComision,
                                                       unificarMarcas,
                                                       idVendedor,
                                                       idCliente,
                                                       marcas,
                                                       rubros,
                                                       subrubros,
                                                       idZonaGeografica,
                                                       conIva,
                                                       listaComprobantes,
                                                       grabaLibro,
                                                       grupo,
                                                       IdFormaPago,
                                                       IdListaPrecios)

   End Function

   Public Function GetComisionesDetalladoPorProductos(idSucursal As Integer,
                                                      desde As Date,
                                                      hasta As Date,
                                                      conComision As String,
                                                      idVendedor As Integer,
                                                      idCliente As Long,
                                                      idMarca As Integer,
                                                      idRubro As Integer,
                                                      idSubRubro As Integer,
                                                      idProducto As String,
                                                      idZonaGeografica As String,
                                                      conIva As Boolean) As DataTable
      Dim oCategoriaFiscalEmpresa = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim strCalculoComisionVendedor As String = Publicos.CalculoComisionVendedor

      Dim sql = New SqlServer.Ventas(da)
      Return sql.GetComisionesDetalladoPorProductos(idSucursal,
                                                    desde,
                                                    hasta,
                                                    oCategoriaFiscalEmpresa,
                                                    strCalculoComisionVendedor,
                                                    Publicos.ComisionVendedor,
                                                    conComision,
                                                    idVendedor,
                                                    idCliente,
                                                    idMarca,
                                                    idRubro,
                                                    idSubRubro,
                                                    idProducto,
                                                    idZonaGeografica,
                                                    conIva)

   End Function

   Public Function GetComisionesTotalesClientesPorVendedor(sucursales As Entidades.Sucursal(),
                                                           desde As Date,
                                                           hasta As Date,
                                                           conComision As String,
                                                           unificarMarcas As Boolean,
                                                           idVendedor As Integer,
                                                           idCliente As Long,
                                                           idMarca As Integer,
                                                           idRubro As Integer,
                                                           idSubrubro As Integer,
                                                           idZonaGeografica As String,
                                                           conIva As Boolean,
                                                           listaComprobantes As List(Of Entidades.TipoComprobante),
                                                           grabaLibro As String,
                                                           grupo As String) As DataTable

      Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim strCalculoComisionVendedor As String = Publicos.CalculoComisionVendedor

      Dim sql = New SqlServer.Ventas(da)
      Return sql.GetComisionesTotalesClientesPorVendedor(sucursales,
                                                         desde,
                                                         hasta,
                                                         conComision,
                                                         unificarMarcas,
                                                         oCategoriaFiscalEmpresa,
                                                         strCalculoComisionVendedor,
                                                         Publicos.ComisionVendedor,
                                                         idVendedor,
                                                         idCliente,
                                                         idMarca,
                                                         idRubro,
                                                         idSubrubro,
                                                         idZonaGeografica,
                                                         conIva,
                                                         listaComprobantes,
                                                         grabaLibro,
                                                         grupo)
   End Function

#End Region

End Class