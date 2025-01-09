Imports Eniac.Entidades.JSonEntidades
Imports Eniac.Entidades.JSonEntidades.Extensions
Partial Class Productos

#Region "RestService & Json"
   Public Event AvanceValidarDatosProductos(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceValidarDatos
   Public Event AvanceImportarDatosProductos(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceImportarDatos

   Protected Overrides Sub OnAvanceImportarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceImportarDatosProductos(Me, eventArgs)
      MyBase.OnAvanceImportarDatos(eventArgs)
   End Sub
   Protected Overrides Sub OnAvanceValidarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceValidarDatosProductos(Me, eventArgs)
      MyBase.OnAvanceValidarDatos(eventArgs)
   End Sub

   Public Overrides Function Convertir(transporte As List(Of Archivos.ProductoJSonTransporte)) As List(Of Archivos.ProductoJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.ProductoJSon)(dato.DatosProducto))
   End Function

   Public Function GetProductosJSon(fechaActualizacionDesde As DateTime?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As List(Of Entidades.JSonEntidades.Archivos.ProductoJSon)
      Dim lst As List(Of Entidades.JSonEntidades.Archivos.ProductoJSon) = New List(Of Entidades.JSonEntidades.Archivos.ProductoJSon)()

      Dim dt As DataTable = New SqlServer.Productos(da).Productos_GA(fechaActualizacionDesde, publicarEn)

      ' Obtengo una lista de los productos asociados que tiene cada producto
      Dim dt1 As DataTable = New SqlServer.ProductosIdentificaciones(da).ProductosIdentificaciones_GA(fechaActualizacionDesde, publicarEn)

      ' Obtengo una lista de las Formuals de los Productos
      Dim dt2 As DataTable = New SqlServer.ProductosFormulas(da).ProductosFormulas_GA(fechaActualizacionDesde, publicarEn)

      ' Obtengo una lista de los Componentes de los Productos 
      Dim dt3 As DataTable = New SqlServer.ProductosComponentes(da).ProductosComponentes_GA(fechaActualizacionDesde, publicarEn)

      Dim o As Entidades.JSonEntidades.Archivos.ProductoJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.ProductoJSon()
         CargarUno(o, dr, cuitEmpresa, dt1.Select(String.Format("IdProducto = '{0}'", dr("IdProducto").ToString().Trim())),
                                       dt2.Select(String.Format("IdProducto = '{0}'", dr("IdProducto").ToString().Trim())),
                                       dt3.Select(String.Format("IdProducto = '{0}'", dr("IdProducto").ToString().Trim())))
         lst.Add(o)
      Next

      Return lst
   End Function

   Private Function GetTodosIdentificacionesJSon(drIdentficaciones As DataRow()) As List(Of Entidades.JSonEntidades.Archivos.ProductoIdentificacionJson)
      Dim result = New List(Of Entidades.JSonEntidades.Archivos.ProductoIdentificacionJson)()
      If drIdentficaciones.Length > 0 Then
         result = New List(Of Entidades.JSonEntidades.Archivos.ProductoIdentificacionJson)()
         Dim o As Entidades.JSonEntidades.Archivos.ProductoIdentificacionJson
         For Each dr As DataRow In drIdentficaciones
            o = New Entidades.JSonEntidades.Archivos.ProductoIdentificacionJson()
            CargarUno(o, dr)
            result.Add(o)
         Next
      End If
      Return result
   End Function

   Private Function GetTodosFormulasJSon(drFormulas As DataRow()) As List(Of Entidades.JSonEntidades.Archivos.ProductoFormulaJson)
      Dim result = New List(Of Entidades.JSonEntidades.Archivos.ProductoFormulaJson)()
      If drFormulas.Length > 0 Then
         result = New List(Of Entidades.JSonEntidades.Archivos.ProductoFormulaJson)()
         Dim o As Entidades.JSonEntidades.Archivos.ProductoFormulaJson
         For Each dr As DataRow In drFormulas
            o = New Entidades.JSonEntidades.Archivos.ProductoFormulaJson()
            CargarUno(o, dr)
            result.Add(o)
         Next
      End If
      Return result
   End Function

   Private Function GetTodosComponentesJson(drComponente As DataRow()) As List(Of Entidades.JSonEntidades.Archivos.ProductoComponenteJson)
      Dim result = New List(Of Entidades.JSonEntidades.Archivos.ProductoComponenteJson)()
      If drComponente.Length > 0 Then
         result = New List(Of Entidades.JSonEntidades.Archivos.ProductoComponenteJson)()
         Dim o As Entidades.JSonEntidades.Archivos.ProductoComponenteJson
         For Each dr As DataRow In drComponente
            o = New Entidades.JSonEntidades.Archivos.ProductoComponenteJson()
            CargarUno(o, dr)
            result.Add(o)
         Next
      End If
      Return result
   End Function


   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.ProductoIdentificacionJson, dr As DataRow)
      With o
         .IdProducto = dr("idProducto").ToString()
         .Identificacion = dr("Identificacion").ToString()
      End With
   End Sub

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.ProductoFormulaJson, dr As DataRow)
      With o
         .IdProducto = dr("idProducto").ToString()
         .IdFormula = Integer.Parse(dr("idFormula").ToString())
         .NombreFormula = dr.Field(Of String)("NombreFormula")
      End With
   End Sub

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.ProductoComponenteJson, dr As DataRow)
      With o
         .IdProducto = dr.Field(Of String)("idProducto")
         .IdProductoComponente = dr.Field(Of String)("idProductoComponente")
         .Cantidad = dr.Field(Of Decimal)("cantidad")
         .IdFormula = dr.Field(Of Integer)("idFormula")
         .SegunCalculoForma = dr.Field(Of Boolean)("segunCalculoForma")
      End With
   End Sub

   Private Sub CargarUno(o As Entidades.JSonEntidades.Archivos.ProductoJSon, dr As DataRow, cuitEmpresa As String,
                         drIdentficaciones As DataRow(),
                         drFormula As DataRow(),
                         drComponente As DataRow())
      With o
         .CuitEmpresa = cuitEmpresa

         .IdProducto = dr(Entidades.Producto.Columnas.IdProducto.ToString()).ToString().Trim()
         .NombreProducto = dr(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString().SacarCaracteresEspeciales()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.Tamano.ToString()).ToString()) Then
            .Tamano = Decimal.Parse(dr(Entidades.Producto.Columnas.Tamano.ToString()).ToString())
         End If
         .IdUnidadDeMedida = dr(Entidades.Producto.Columnas.IdUnidadDeMedida.ToString()).ToString()
         .IdMarca = Integer.Parse(dr(Entidades.Producto.Columnas.IdMarca.ToString()).ToString())
         .IdRubro = Integer.Parse(dr(Entidades.Producto.Columnas.IdRubro.ToString()).ToString())
         .MesesGarantia = Integer.Parse(dr(Entidades.Producto.Columnas.MesesGarantia.ToString()).ToString())
         .Activo = Boolean.Parse(dr(Entidades.Producto.Columnas.Activo.ToString()).ToString())
         .AfectaStock = Boolean.Parse(dr(Entidades.Producto.Columnas.AfectaStock.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.IdModelo.ToString()).ToString()) Then
            .IdModelo = Integer.Parse(dr(Entidades.Producto.Columnas.IdModelo.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.IdSubRubro.ToString()).ToString()) Then
            .IdSubRubro = Integer.Parse(dr(Entidades.Producto.Columnas.IdSubRubro.ToString()).ToString())
         End If
         .Lote = Boolean.Parse(dr(Entidades.Producto.Columnas.Lote.ToString()).ToString())
         .NroSerie = Boolean.Parse(dr(Entidades.Producto.Columnas.NroSerie.ToString()).ToString())
         .IdTipoImpuesto = dr(Entidades.Producto.Columnas.IdTipoImpuesto.ToString()).ToString()
         .Alicuota = Decimal.Parse(dr(Entidades.Producto.Columnas.Alicuota.ToString()).ToString())
         .CodigoDeBarras = dr(Entidades.Producto.Columnas.CodigoDeBarras.ToString()).ToString()
         .EsServicio = Boolean.Parse(dr(Entidades.Producto.Columnas.EsServicio.ToString()).ToString())
         .Observacion = dr(Entidades.Producto.Columnas.Observacion.ToString()).ToString().SacarCaracteresEspeciales()
         .PublicarEnWeb = Boolean.Parse(dr(Entidades.Producto.Columnas.PublicarEnWeb.ToString()).ToString())
         .PublicarListaDePreciosClientes = Boolean.Parse(dr(Entidades.Producto.Columnas.PublicarListaDePreciosClientes.ToString()).ToString())

         .PublicarEnTiendaNube = Boolean.Parse(dr(Entidades.Producto.Columnas.PublicarEnTiendaNube.ToString()).ToString())
         .PublicarEnMercadoLibre = Boolean.Parse(dr(Entidades.Producto.Columnas.PublicarEnMercadoLibre.ToString()).ToString())
         .PublicarEnArborea = Boolean.Parse(dr(Entidades.Producto.Columnas.PublicarEnArborea.ToString()).ToString())
         .PublicarEnGestion = Boolean.Parse(dr(Entidades.Producto.Columnas.PublicarEnGestion.ToString()).ToString())
         .PublicarEnEmpresarial = Boolean.Parse(dr(Entidades.Producto.Columnas.PublicarEnEmpresarial.ToString()).ToString())
         .PublicarEnBalanza = Boolean.Parse(dr(Entidades.Producto.Columnas.PublicarEnBalanza.ToString()).ToString())
         .PublicarEnSincronizacionSucursal = Boolean.Parse(dr(Entidades.Producto.Columnas.PublicarEnSincronizacionSucursal.ToString()).ToString())


         .EsDeCompras = Boolean.Parse(dr(Entidades.Producto.Columnas.EsDeCompras.ToString()).ToString())
         .EsDeVentas = Boolean.Parse(dr(Entidades.Producto.Columnas.EsDeVentas.ToString()).ToString())
         .DescontarStockComponentes = Boolean.Parse(dr(Entidades.Producto.Columnas.DescontarStockComponentes.ToString()).ToString())
         .IdMoneda = Integer.Parse(dr(Entidades.Producto.Columnas.IdMoneda.ToString()).ToString())
         .EsCompuesto = Boolean.Parse(dr(Entidades.Producto.Columnas.EsCompuesto.ToString()).ToString())
         .CodigoDeBarrasConPrecio = Boolean.Parse(dr(Entidades.Producto.Columnas.CodigoDeBarrasConPrecio.ToString()).ToString())
         .EsAlquilable = Boolean.Parse(dr(Entidades.Producto.Columnas.EsAlquilable.ToString()).ToString())
         .EquipoMarca = dr(Entidades.Producto.Columnas.EquipoMarca.ToString()).ToString()
         .EquipoModelo = dr(Entidades.Producto.Columnas.EquipoModelo.ToString()).ToString()
         .NumeroSerie = dr(Entidades.Producto.Columnas.NumeroSerie.ToString()).ToString()
         .CaractSII = dr(Entidades.Producto.Columnas.CaractSII.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.Anio.ToString()).ToString()) Then
            .Anio = Integer.Parse(dr(Entidades.Producto.Columnas.Anio.ToString()).ToString())
         End If
         .PermiteModificarDescripcion = Boolean.Parse(dr(Entidades.Producto.Columnas.PermiteModificarDescripcion.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.Alicuota2.ToString()).ToString()) Then
            .Alicuota2 = Decimal.Parse(dr(Entidades.Producto.Columnas.Alicuota2.ToString()).ToString())
         End If
         .PagaIngresosBrutos = Boolean.Parse(dr(Entidades.Producto.Columnas.PagaIngresosBrutos.ToString()).ToString())
         .Embalaje = Integer.Parse(dr(Entidades.Producto.Columnas.Embalaje.ToString()).ToString())
         .Kilos = Decimal.Parse(dr(Entidades.Producto.Columnas.Kilos.ToString()).ToString())
         .KilosEsUMCompras = dr.Field(Of Boolean)(Entidades.Producto.Columnas.KilosEsUMCompras.ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.IdFormula.ToString()).ToString()) Then
            .IdFormula = Integer.Parse(dr(Entidades.Producto.Columnas.IdFormula.ToString()).ToString())
         End If
         .IdProductoMercosur = dr(Entidades.Producto.Columnas.IdProductoMercosur.ToString()).ToString()
         .IdProductoSecretaria = dr(Entidades.Producto.Columnas.IdProductoSecretaria.ToString()).ToString()
         .FacturacionCantidadNegativa = Boolean.Parse(dr(Entidades.Producto.Columnas.FacturacionCantidadNegativa.ToString()).ToString())
         .SolicitaEnvase = Boolean.Parse(dr(Entidades.Producto.Columnas.SolicitaEnvase.ToString()).ToString())
         .AlertaDeCaja = Boolean.Parse(dr(Entidades.Producto.Columnas.AlertaDeCaja.ToString()).ToString())
         .NombreCorto = dr(Entidades.Producto.Columnas.NombreCorto.ToString()).ToString()
         .EsRetornable = Boolean.Parse(dr(Entidades.Producto.Columnas.EsRetornable.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.Orden.ToString()).ToString()) Then
            .Orden = Integer.Parse(dr(Entidades.Producto.Columnas.Orden.ToString()).ToString())
         End If
         .ModalidadCodigoDeBarras = dr(Entidades.Producto.Columnas.ModalidadCodigoDeBarras.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.IdProveedor.ToString()).ToString()) Then
            .IdProveedor = Long.Parse(dr(Entidades.Producto.Columnas.IdProveedor.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CodigoLargoProducto.ToString()).ToString()) Then
            .CodigoLargoProducto = dr(Entidades.Producto.Columnas.CodigoLargoProducto.ToString()).ToString()
         End If
         .EsObservacion = Boolean.Parse(dr(Entidades.Producto.Columnas.EsObservacion.ToString()).ToString())
         .PrecioPorEmbalaje = Boolean.Parse(dr(Entidades.Producto.Columnas.PrecioPorEmbalaje.ToString()).ToString())
         .UnidHasta1 = Decimal.Parse(dr(Entidades.Producto.Columnas.UnidHasta1.ToString()).ToString())
         .UnidHasta2 = Decimal.Parse(dr(Entidades.Producto.Columnas.UnidHasta2.ToString()).ToString())
         .UnidHasta3 = Decimal.Parse(dr(Entidades.Producto.Columnas.UnidHasta3.ToString()).ToString())
         .UHPorc1 = Decimal.Parse(dr(Entidades.Producto.Columnas.UHPorc1.ToString()).ToString())
         .UHPorc2 = Decimal.Parse(dr(Entidades.Producto.Columnas.UHPorc2.ToString()).ToString())
         .UHPorc3 = Decimal.Parse(dr(Entidades.Producto.Columnas.UHPorc3.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.IdCuentaCompras.ToString()).ToString()) Then
            .IdCuentaCompras = Long.Parse(dr(Entidades.Producto.Columnas.IdCuentaCompras.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.IdCuentaVentas.ToString()).ToString()) Then
            .IdCuentaVentas = Long.Parse(dr(Entidades.Producto.Columnas.IdCuentaVentas.ToString()).ToString())
         End If
         .ImporteImpuestoInterno = Decimal.Parse(dr(Entidades.Producto.Columnas.ImporteImpuestoInterno.ToString()).ToString())
         .EsOferta = dr(Entidades.Producto.Columnas.EsOferta.ToString()).ToString()
         .IncluirExpensas = Boolean.Parse(dr(Entidades.Producto.Columnas.IncluirExpensas.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.IdCuentaComprasSecundaria.ToString()).ToString()) Then
            .IdCuentaComprasSecundaria = Long.Parse(dr(Entidades.Producto.Columnas.IdCuentaComprasSecundaria.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.IdCentroCosto.ToString()).ToString()) Then
            .IdCentroCosto = Integer.Parse(dr(Entidades.Producto.Columnas.IdCentroCosto.ToString()).ToString())
         End If
         .UnidHasta4 = Decimal.Parse(dr(Entidades.Producto.Columnas.UnidHasta4.ToString()).ToString())
         .UnidHasta5 = Decimal.Parse(dr(Entidades.Producto.Columnas.UnidHasta5.ToString()).ToString())
         .UHPorc4 = Decimal.Parse(dr(Entidades.Producto.Columnas.UHPorc4.ToString()).ToString())
         .UHPorc5 = Decimal.Parse(dr(Entidades.Producto.Columnas.UHPorc5.ToString()).ToString())
         .ObservacionCompras = dr(Entidades.Producto.Columnas.ObservacionCompras.ToString()).ToString().SacarCaracteresEspeciales()
         .SolicitaPrecioVentaPorTamano = Boolean.Parse(dr(Entidades.Producto.Columnas.SolicitaPrecioVentaPorTamano.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.IdProduccionProceso.ToString()).ToString()) Then
            .IdProduccionProceso = Integer.Parse(dr(Entidades.Producto.Columnas.IdProduccionProceso.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.IdProduccionForma.ToString()).ToString()) Then
            .IdProduccionForma = Integer.Parse(dr(Entidades.Producto.Columnas.IdProduccionForma.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.Espmm.ToString()).ToString()) Then
            .Espmm = Decimal.Parse(dr(Entidades.Producto.Columnas.Espmm.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CodigoSAE.ToString()).ToString()) Then
            .CodigoSAE = dr(Entidades.Producto.Columnas.CodigoSAE.ToString()).ToString()
         End If
         .EspPulgadas = dr(Entidades.Producto.Columnas.EspPulgadas.ToString()).ToString()

         .CalculaPreciosSegunFormula = Boolean.Parse(dr(Entidades.Producto.Columnas.CalculaPreciosSegunFormula.ToString()).ToString())
         If IsNumeric(dr(Entidades.Producto.Columnas.IdSubSubRubro.ToString()).ToString()) Then
            .IdSubSubRubro = Integer.Parse(dr(Entidades.Producto.Columnas.IdSubSubRubro.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Producto.Columnas.PorcImpuestoInterno.ToString()).ToString()) Then
            .PorcImpuestoInterno = Decimal.Parse(dr(Entidades.Producto.Columnas.PorcImpuestoInterno.ToString()).ToString())
         End If

         .OrigenPorcImpInt = DirectCast([Enum].Parse(GetType(Entidades.OrigenesPorcImpInt), dr(Entidades.Producto.Columnas.OrigenPorcImpInt.ToString()).ToString()), Entidades.OrigenesPorcImpInt)

         .FechaActualizacionWeb = dr.Field(Of DateTime?)(Entidades.Producto.Columnas.FechaActualizacionWeb.ToString()).IfNull().ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechasMilisegundos)

         .EsCambiable = Boolean.Parse(dr(Entidades.Producto.Columnas.EsCambiable.ToString()).ToString())
         .EsBonificable = Boolean.Parse(dr(Entidades.Producto.Columnas.EsBonificable.ToString()).ToString())

         .DescRecProducto = Decimal.Parse(dr(Entidades.Producto.Columnas.DescRecProducto.ToString()).ToString())
         .ActualizaPreciosSucursalesAsociadas = Boolean.Parse(dr(Entidades.Producto.Columnas.ActualizaPreciosSucursalesAsociadas.ToString()).ToString())

         .CalidadStatusLiberado = Boolean.Parse(dr(Entidades.Producto.Columnas.CalidadStatusLiberado.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaLiberado.ToString()).ToString()) Then
            .CalidadFechaLiberado = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaLiberado.ToString()).ToString()).ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadUserLiberado.ToString()).ToString()) Then
            .CalidadUserLiberado = dr(Entidades.Producto.Columnas.CalidadUserLiberado.ToString()).ToString()
         End If

         .CalidadStatusEntregado = Boolean.Parse(dr(Entidades.Producto.Columnas.CalidadStatusEntregado.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaEntregado.ToString()).ToString()) Then
            .CalidadFechaEntregado = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaEntregado.ToString()).ToString()).ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadUserEntregado.ToString()).ToString()) Then
            .CalidadUserEntregado = dr(Entidades.Producto.Columnas.CalidadUserEntregado.ToString()).ToString()
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaIngreso.ToString()).ToString()) Then
            .CalidadFechaIngreso = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaIngreso.ToString()).ToString()).ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaEgreso.ToString()).ToString()) Then
            .CalidadFechaEgreso = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaEgreso.ToString()).ToString()).ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)
         End If

         If IsNumeric(dr(Entidades.Producto.Columnas.CalidadNroCertificado.ToString()).ToString()) Then
            .CalidadNroCertificado = Integer.Parse(dr(Entidades.Producto.Columnas.CalidadNroCertificado.ToString()).ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFecCertificado.ToString()).ToString()) Then
            .CalidadFecCertificado = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFecCertificado.ToString()).ToString()).ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadUsrCertificado.ToString()).ToString()) Then
            .CalidadUsrCertificado = dr(Entidades.Producto.Columnas.CalidadUsrCertificado.ToString()).ToString()
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadObservaciones.ToString()).ToString()) Then
            .CalidadObservaciones = dr(Entidades.Producto.Columnas.CalidadObservaciones.ToString()).ToString()
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaPreEnt.ToString()).ToString()) Then
            .CalidadFechaPreEnt = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaPreEnt.ToString()).ToString()).ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadFechaEntProg.ToString()).ToString()) Then
            .CalidadFechaEntProg = DateTime.Parse(dr(Entidades.Producto.Columnas.CalidadFechaEntProg.ToString()).ToString()).ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)
         End If

         .EsComercial = Boolean.Parse(dr(Entidades.Producto.Columnas.EsComercial.ToString()).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.Producto.Columnas.CalidadNumeroChasis.ToString()).ToString()) Then
            .CalidadNumeroChasis = dr(Entidades.Producto.Columnas.CalidadNumeroChasis.ToString()).ToString()
         End If

         If IsNumeric(dr(Entidades.Producto.Columnas.CalidadNroCarroceria.ToString()).ToString()) Then
            .CalidadNroCarroceria = Integer.Parse(dr(Entidades.Producto.Columnas.CalidadNroCarroceria.ToString()).ToString())
         End If

         .Alto = dr.Field(Of Decimal)(Entidades.Producto.Columnas.Alto.ToString())
         .Ancho = dr.Field(Of Decimal)(Entidades.Producto.Columnas.Ancho.ToString())
         .Largo = dr.Field(Of Decimal)(Entidades.Producto.Columnas.Largo.ToString())

         ' Transportes de Identificaciones y Formulas/Componentes
         .ProductoIdentificacion = GetTodosIdentificacionesJSon(drIdentficaciones)
         .ProductoFormula = GetTodosFormulasJSon(drFormula)
         .ProductoComponente = GetTodosComponentesJson(drComponente)

         .IdUnidadDeMedida2 = dr.Field(Of String)(Entidades.Producto.Columnas.IdUnidadDeMedida2.ToString())
         .Conversion = dr.Field(Of Decimal)(Entidades.Producto.Columnas.Conversion.ToString())

         .IdUnidadDeMedidaCompra = dr.Field(Of String)(Entidades.Producto.Columnas.IdUnidadDeMedidaCompra.ToString())
         .FactorConversionCompra = dr.Field(Of Decimal)(Entidades.Producto.Columnas.FactorConversionCompra.ToString())
         .IdUnidadDeMedidaProduccion = dr.Field(Of String)(Entidades.Producto.Columnas.IdUnidadDeMedidaProduccion.ToString())
         .FactorConversionProduccion = dr.Field(Of Decimal)(Entidades.Producto.Columnas.FactorConversionProduccion.ToString())

         .IdProductoNumerico = dr.Field(Of Long?)(Entidades.Producto.Columnas.IdProductoNumerico.ToString())
         .EnviarSinCargo = dr.Field(Of Boolean)(Entidades.Producto.Columnas.EnviarSinCargo.ToString())
         .CodigoProductoTiendaNube = dr.Field(Of String)(Entidades.Producto.Columnas.CodigoProductoTiendaNube.ToString())
         .CodigoProductoMercadoLibre = dr.Field(Of String)(Entidades.Producto.Columnas.CodigoProductoMercadoLibre.ToString())
         .IdVarianteProducto = dr.Field(Of String)(Entidades.Producto.Columnas.IdVarianteProducto.ToString())
         .TipoBonificacion = DirectCast([Enum].Parse(GetType(Entidades.Producto.TiposBonificacionesProductos), dr(Entidades.Producto.Columnas.TipoBonificacion.ToString()).ToString()), Entidades.Producto.TiposBonificacionesProductos)
         If IsNumeric(dr(Entidades.Producto.Columnas.IdProductoTipoServicio.ToString()).ToString()) Then
            .IdProductoTipoServicio = Integer.Parse(dr(Entidades.Producto.Columnas.IdProductoTipoServicio.ToString()).ToString())
         End If
         .EsPerceptibleIVARes53292023 = dr.Field(Of Boolean)("EsPerceptibleIVARes53292023")
      End With
   End Sub

   Public Sub CargarJSonEnDataTable(productosJson As List(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte), dt As DataTable)
      Dim dr As DataRow
      For Each transporte As Entidades.JSonEntidades.Archivos.ProductoJSonTransporte In productosJson
         Dim productoJson As Entidades.JSonEntidades.Archivos.ProductoJSon
         Try
            productoJson = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.ProductoJSon)(transporte.DatosProducto)
         Catch ex As Exception
            Throw ex
         End Try

         dr = dt.NewRow()
         Clientes.SeteaValor(dr, "CuitEmpresa", productoJson.CuitEmpresa, GetType(String))
         Clientes.SeteaValor(dr, "IdProducto", productoJson.IdProducto, GetType(String))

         Clientes.SeteaValor(dr, "NombreProducto", productoJson.NombreProducto.RecuperarCaracteresEspeciales(), GetType(String))
         Clientes.SeteaValor(dr, "Tamano", productoJson.Tamano, GetType(Decimal))
         Clientes.SeteaValor(dr, "IdUnidadDeMedida", productoJson.IdUnidadDeMedida, GetType(String))
         Clientes.SeteaValor(dr, "IdMarca", productoJson.IdMarca, GetType(Integer))
         Clientes.SeteaValor(dr, "IdRubro", productoJson.IdRubro, GetType(Integer))
         Clientes.SeteaValor(dr, "MesesGarantia", productoJson.MesesGarantia, GetType(Integer))
         Clientes.SeteaValor(dr, "Activo", productoJson.Activo, GetType(Boolean))
         Clientes.SeteaValor(dr, "AfectaStock", productoJson.AfectaStock, GetType(Boolean))
         Clientes.SeteaValor(dr, "IdModelo", productoJson.IdModelo, GetType(Integer))
         Clientes.SeteaValor(dr, "IdSubRubro", productoJson.IdSubRubro, GetType(Integer))
         Clientes.SeteaValor(dr, "Lote", productoJson.Lote, GetType(Boolean))
         Clientes.SeteaValor(dr, "NroSerie", productoJson.NroSerie, GetType(Boolean))
         Clientes.SeteaValor(dr, "IdTipoImpuesto", productoJson.IdTipoImpuesto, GetType(String))
         Clientes.SeteaValor(dr, "Alicuota", productoJson.Alicuota, GetType(Decimal))
         Clientes.SeteaValor(dr, "CodigoDeBarras", productoJson.CodigoDeBarras, GetType(String))
         Clientes.SeteaValor(dr, "EsServicio", productoJson.EsServicio, GetType(Boolean))
         Clientes.SeteaValor(dr, "Observacion", productoJson.Observacion.RecuperarCaracteresEspeciales(), GetType(String))
         Clientes.SeteaValor(dr, "PublicarEnWeb", productoJson.PublicarEnWeb, GetType(Boolean))
         Clientes.SeteaValor(dr, "PublicarListaDePreciosClientes", productoJson.PublicarListaDePreciosClientes, GetType(Boolean))

         Clientes.SeteaValor(dr, "PublicarEnTiendaNube", productoJson.PublicarEnTiendaNube, GetType(Boolean))
         Clientes.SeteaValor(dr, "PublicarEnMercadoLibre", productoJson.PublicarEnMercadoLibre, GetType(Boolean))
         Clientes.SeteaValor(dr, "PublicarEnArborea", productoJson.PublicarEnArborea, GetType(Boolean))
         Clientes.SeteaValor(dr, "PublicarEnGestion", productoJson.PublicarEnGestion, GetType(Boolean))
         Clientes.SeteaValor(dr, "PublicarEnEmpresarial", productoJson.PublicarEnEmpresarial, GetType(Boolean))
         Clientes.SeteaValor(dr, "PublicarEnBalanza", productoJson.PublicarEnBalanza, GetType(Boolean))
         Clientes.SeteaValor(dr, "PublicarEnSincronizacionSucursal", productoJson.PublicarEnSincronizacionSucursal, GetType(Boolean))

         Clientes.SeteaValor(dr, "EsDeCompras", productoJson.EsDeCompras, GetType(Boolean))
         Clientes.SeteaValor(dr, "EsDeVentas", productoJson.EsDeVentas, GetType(Boolean))
         Clientes.SeteaValor(dr, "DescontarStockComponentes", productoJson.DescontarStockComponentes, GetType(Boolean))
         Clientes.SeteaValor(dr, "IdMoneda", productoJson.IdMoneda, GetType(Integer))
         Clientes.SeteaValor(dr, "EsCompuesto", productoJson.EsCompuesto, GetType(Boolean))
         Clientes.SeteaValor(dr, "CodigoDeBarrasConPrecio", productoJson.CodigoDeBarrasConPrecio, GetType(Boolean))
         Clientes.SeteaValor(dr, "EsAlquilable", productoJson.EsAlquilable, GetType(Boolean))
         Clientes.SeteaValor(dr, "EquipoMarca", productoJson.EquipoMarca, GetType(String))
         Clientes.SeteaValor(dr, "EquipoModelo", productoJson.EquipoModelo, GetType(String))
         Clientes.SeteaValor(dr, "NumeroSerie", productoJson.NumeroSerie, GetType(String))
         Clientes.SeteaValor(dr, "CaractSII", productoJson.CaractSII, GetType(String))
         Clientes.SeteaValor(dr, "Anio", productoJson.Anio, GetType(Integer))
         Clientes.SeteaValor(dr, "PermiteModificarDescripcion", productoJson.PermiteModificarDescripcion, GetType(Boolean))
         Clientes.SeteaValor(dr, "Alicuota2", productoJson.Alicuota2, GetType(Decimal))
         Clientes.SeteaValor(dr, "PagaIngresosBrutos", productoJson.PagaIngresosBrutos, GetType(Boolean))
         Clientes.SeteaValor(dr, "Embalaje", productoJson.Embalaje, GetType(Integer))
         Clientes.SeteaValor(dr, "Kilos", productoJson.Kilos, GetType(Decimal))
         Clientes.SeteaValor(dr, "KilosEsUMCompras", productoJson.KilosEsUMCompras, GetType(Boolean))
         Clientes.SeteaValor(dr, "IdFormula", productoJson.IdFormula, GetType(Integer))
         Clientes.SeteaValor(dr, "IdProductoMercosur", productoJson.IdProductoMercosur, GetType(String))
         Clientes.SeteaValor(dr, "IdProductoSecretaria", productoJson.IdProductoSecretaria, GetType(String))
         Clientes.SeteaValor(dr, "FacturacionCantidadNegativa", productoJson.FacturacionCantidadNegativa, GetType(Boolean))
         Clientes.SeteaValor(dr, "SolicitaEnvase", productoJson.SolicitaEnvase, GetType(Boolean))
         Clientes.SeteaValor(dr, "AlertaDeCaja", productoJson.AlertaDeCaja, GetType(Boolean))
         Clientes.SeteaValor(dr, "NombreCorto", productoJson.NombreCorto, GetType(String))
         Clientes.SeteaValor(dr, "EsRetornable", productoJson.EsRetornable, GetType(Boolean))
         Clientes.SeteaValor(dr, "Orden", productoJson.Orden, GetType(Integer))
         Clientes.SeteaValor(dr, "ModalidadCodigoDeBarras", productoJson.ModalidadCodigoDeBarras, GetType(String))
         Clientes.SeteaValor(dr, "IdProveedor", productoJson.IdProveedor, GetType(Long))
         Clientes.SeteaValor(dr, "CodigoLargoProducto", productoJson.CodigoLargoProducto, GetType(String))
         Clientes.SeteaValor(dr, "EsObservacion", productoJson.EsObservacion, GetType(String))
         Clientes.SeteaValor(dr, "PrecioPorEmbalaje", productoJson.PrecioPorEmbalaje, GetType(Boolean))
         Clientes.SeteaValor(dr, "UnidHasta1", productoJson.UnidHasta1, GetType(Decimal))
         Clientes.SeteaValor(dr, "UnidHasta2", productoJson.UnidHasta2, GetType(Decimal))
         Clientes.SeteaValor(dr, "UnidHasta3", productoJson.UnidHasta3, GetType(Decimal))
         Clientes.SeteaValor(dr, "UHPorc1", productoJson.UHPorc1, GetType(Decimal))
         Clientes.SeteaValor(dr, "UHPorc2", productoJson.UHPorc2, GetType(Decimal))
         Clientes.SeteaValor(dr, "UHPorc3", productoJson.UHPorc3, GetType(Decimal))
         Clientes.SeteaValor(dr, "IdCuentaCompras", productoJson.IdCuentaCompras, GetType(Long))
         Clientes.SeteaValor(dr, "IdCuentaVentas", productoJson.IdCuentaVentas, GetType(Long))
         Clientes.SeteaValor(dr, "ImporteImpuestoInterno", productoJson.ImporteImpuestoInterno, GetType(Decimal))
         Clientes.SeteaValor(dr, "EsOferta", productoJson.EsOferta, GetType(String))
         Clientes.SeteaValor(dr, "IncluirExpensas", productoJson.IncluirExpensas, GetType(Boolean))
         Clientes.SeteaValor(dr, "IdCuentaComprasSecundaria", productoJson.IdCuentaComprasSecundaria, GetType(Long))
         Clientes.SeteaValor(dr, "IdCentroCosto", productoJson.IdCentroCosto, GetType(Integer))
         Clientes.SeteaValor(dr, "UnidHasta4", productoJson.UnidHasta4, GetType(Decimal))
         Clientes.SeteaValor(dr, "UnidHasta5", productoJson.UnidHasta5, GetType(Decimal))
         Clientes.SeteaValor(dr, "UHPorc4", productoJson.UHPorc4, GetType(Decimal))
         Clientes.SeteaValor(dr, "UHPorc5", productoJson.UHPorc5, GetType(Decimal))
         Clientes.SeteaValor(dr, "ObservacionCompras", productoJson.ObservacionCompras.RecuperarCaracteresEspeciales(), GetType(String))
         Clientes.SeteaValor(dr, "SolicitaPrecioVentaPorTamano", productoJson.SolicitaPrecioVentaPorTamano, GetType(Boolean))
         Clientes.SeteaValor(dr, "IdProduccionProceso", productoJson.IdProduccionProceso, GetType(Integer))
         Clientes.SeteaValor(dr, "IdProduccionForma", productoJson.IdProduccionForma, GetType(Integer))
         Clientes.SeteaValor(dr, "Espmm", productoJson.Espmm, GetType(Decimal))
         Clientes.SeteaValor(dr, "CodigoSAE", productoJson.CodigoSAE, GetType(String))
         Clientes.SeteaValor(dr, "EspPulgadas", productoJson.EspPulgadas, GetType(String))

         Clientes.SeteaValor(dr, "CalculaPreciosSegunFormula", productoJson.CalculaPreciosSegunFormula, GetType(Boolean))
         Clientes.SeteaValor(dr, "IdSubSubRubro", productoJson.IdSubSubRubro, GetType(Integer))
         Clientes.SeteaValor(dr, "PorcImpuestoInterno", productoJson.PorcImpuestoInterno, GetType(Decimal))
         Clientes.SeteaValor(dr, "OrigenPorcImpInt", productoJson.OrigenPorcImpInt, GetType(Decimal))
         Clientes.SeteaValor(dr, "FechaActualizacionWeb", productoJson.FechaActualizacionWeb, GetType(String))
         Clientes.SeteaValor(dr, "EsCambiable", productoJson.EsCambiable, GetType(Boolean))
         Clientes.SeteaValor(dr, "EsBonificable", productoJson.EsBonificable, GetType(Boolean))
         Clientes.SeteaValor(dr, "DescRecProducto", productoJson.DescRecProducto, GetType(Decimal))
         Clientes.SeteaValor(dr, "ActualizaPreciosSucursalesAsociadas", productoJson.ActualizaPreciosSucursalesAsociadas, GetType(Boolean))

         Clientes.SeteaValor(dr, "CalidadStatusLiberado", productoJson.CalidadStatusLiberado, GetType(Boolean))
         Clientes.SeteaValor(dr, "CalidadFechaLiberado", productoJson.CalidadFechaLiberado, GetType(String))
         Clientes.SeteaValor(dr, "CalidadUserLiberado", productoJson.CalidadUserLiberado, GetType(String))
         Clientes.SeteaValor(dr, "CalidadStatusEntregado", productoJson.CalidadStatusEntregado, GetType(Boolean))
         Clientes.SeteaValor(dr, "CalidadFechaEntregado", productoJson.CalidadFechaEntregado, GetType(String))
         Clientes.SeteaValor(dr, "CalidadUserEntregado", productoJson.CalidadUserEntregado, GetType(String))
         Clientes.SeteaValor(dr, "CalidadFechaIngreso", productoJson.CalidadFechaIngreso, GetType(String))
         Clientes.SeteaValor(dr, "CalidadFechaEgreso", productoJson.CalidadFechaEgreso, GetType(String))
         Clientes.SeteaValor(dr, "CalidadNroCertificado", productoJson.CalidadNroCertificado, GetType(Integer))
         Clientes.SeteaValor(dr, "CalidadFecCertificado", productoJson.CalidadFecCertificado, GetType(String))
         Clientes.SeteaValor(dr, "CalidadUsrCertificado", productoJson.CalidadUsrCertificado, GetType(String))
         Clientes.SeteaValor(dr, "CalidadObservaciones", productoJson.CalidadObservaciones, GetType(String))
         Clientes.SeteaValor(dr, "CalidadFechaPreEnt", productoJson.CalidadFechaPreEnt, GetType(String))
         Clientes.SeteaValor(dr, "CalidadFechaEntProg", productoJson.CalidadFechaEntProg, GetType(String))
         Clientes.SeteaValor(dr, "EsComercial", productoJson.EsComercial, GetType(Boolean))

         Clientes.SeteaValor(dr, "EnviarSinCargo", productoJson.EnviarSinCargo, GetType(Boolean))
         Clientes.SeteaValor(dr, "CodigoProductoTiendaNube", productoJson.CodigoProductoTiendaNube, GetType(String))
         Clientes.SeteaValor(dr, "CodigoProductoMercadoLibre", productoJson.CodigoProductoMercadoLibre, GetType(String))

         Clientes.SeteaValor(dr, "TipoBonificacion", productoJson.TipoBonificacion, GetType(String))
         Clientes.SeteaValor(dr, "EsPerceptibleIVARes53292023", productoJson, GetType(Boolean))

         ' Para Transporte de Identificaciones y Formulas/Componentes
         Clientes.SeteaValor(dr, "IdentificacionProducto", productoJson.ProductoIdentificacion, GetType(Object))
         Clientes.SeteaValor(dr, "ProductoFormula", productoJson.ProductoFormula, GetType(Object))
         Clientes.SeteaValor(dr, "ProductoComponente", productoJson.ProductoComponente, GetType(Object))

         Clientes.SeteaValor(dr, "DatosSyncronizados", productoJson, GetType(Object))
         Clientes.SeteaValor(dr, "CalidadNumeroChasis", productoJson.CalidadNumeroChasis, GetType(String))
         Clientes.SeteaValor(dr, "CalidadNroCarroceria", productoJson.CalidadNroCarroceria, GetType(Integer))
         Clientes.SeteaValor(dr, "IdProductoTipoServicio", productoJson.IdProductoTipoServicio, GetType(Integer))

         productoJson.drOrigen = dr

         dt.Rows.Add(dr)
      Next
   End Sub

   Public Overrides Function ValidarDatos(col As List(Of Archivos.ProductoJSon), syncs As ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Productos")
      Dim cache = New BusquedasCacheadas()

      eventArgs.TotalRegistros = col.Count
      For Each en As Archivos.ProductoJSon In col
         Dim stbMensajeError = New StringBuilder()

         eventArgs.RegistroActual += 1
         OnAvanceValidarDatos(eventArgs)
         en.IdProducto = en.IdProducto.Trim()
         If en.IdCentroCosto > 0 AndAlso Not cache.ExisteCentrosCostos(en.IdCentroCosto) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Centro de Costos con IdCentroCosto = {0}.", en.IdCentroCosto), "IdCentroCosto")
         End If

         If en.IdCuentaCompras > 0 AndAlso Not cache.ExisteCuentaContablePorIdRapido(en.IdCuentaCompras) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Cuenta de Compras con IdCuentaCompras = {0}.", en.IdCuentaCompras), "IdCuentaCompras")
         End If

         If en.IdCuentaVentas > 0 AndAlso Not cache.ExisteCuentaContablePorIdRapido(en.IdCuentaVentas) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Cuenta de Ventas con IdCuentaVentas = {0}.", en.IdCuentaVentas), "IdCuentaVentas")
         End If

         If en.IdCuentaComprasSecundaria > 0 AndAlso Not cache.ExisteCuentaContablePorIdRapido(en.IdCuentaComprasSecundaria) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Cuenta de Compras Secundaria con IdCuentaComprasSecundaria = {0}.", en.IdCuentaComprasSecundaria), "IdCuentaComprasSecundaria")
         End If

         If Not cache.ExisteImpuesto(en.IdTipoImpuesto, en.Alicuota) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Impuesto con IdImpuesto = {0} y Alicuota {1}.", en.IdTipoImpuesto, en.Alicuota), Entidades.Producto.Columnas.Alicuota.ToString())
         End If

         If Not cache.ExisteImpuesto(en.IdTipoImpuesto, en.Alicuota2) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Impuesto con IdImpuesto = {0} y Alicuota2 {1}.", en.IdTipoImpuesto, en.Alicuota2), Entidades.Producto.Columnas.Alicuota2.ToString())
         End If

         If Not cache.ExisteMarca(en.IdMarca) Then
            If Not GetCollection(Of Entidades.JSonEntidades.Archivos.MarcaJSon)(syncs).Any(Function(x) x.IdMarca = en.IdMarca) Then
               en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Marca con IdMarca = {0}.", en.IdMarca), Entidades.Producto.Columnas.IdMarca.ToString())
            End If
         End If

         If en.IdModelo > 0 And Not cache.ExisteModelo(en.IdModelo) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Modelo con IdModelo = {0}.", en.IdModelo), Entidades.Producto.Columnas.IdModelo.ToString())
         End If

         If Not cache.ExisteMoneda(en.IdMoneda) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Moneda con IdMoneda = {0}.", en.IdMoneda), Entidades.Producto.Columnas.IdMoneda.ToString())
         End If

         If en.IdProduccionForma > 0 And Not cache.ExisteProduccionForma(en.IdProduccionForma) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe la Forma de Produccción con IdProduccionForma = {0}.", en.IdProduccionForma), Entidades.Producto.Columnas.IdProduccionForma.ToString())
         End If

         If en.IdProduccionProceso > 0 And Not cache.ExisteProduccionProceso(en.IdProduccionProceso) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Proceso de Produccción con IdProduccionProceso = {0}.", en.IdProduccionProceso), Entidades.Producto.Columnas.IdProduccionProceso.ToString())
         End If

         If en.IdProveedor > 0 And Not cache.ExisteProveedorPorIdRapido(en.IdProveedor) Then
            en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Proveedor con IdProveedor = {0}.", en.IdProveedor), Entidades.Producto.Columnas.IdProveedor.ToString())
         End If

         If Not cache.ExisteRubro(en.IdRubro) Then
            'Rubro en ALTA
            If Not GetCollection(Of Entidades.JSonEntidades.Archivos.RubroJSon)(syncs).Any(Function(x) x.IdRubro = en.IdRubro) Then
               en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Rubro con IdRubro = {0}.", en.IdRubro), Entidades.Producto.Columnas.IdRubro.ToString())
            End If
         End If

         If en.IdSubRubro > 0 And Not cache.ExisteSubRubro(en.IdSubRubro) Then
            'SubRubro en ALTA
            If Not GetCollection(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)(syncs).Any(Function(x) x.IdSubRubro = en.IdSubRubro) Then
               en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el SubRubro con IdSubRubro = {0}.", en.IdSubRubro), Entidades.Producto.Columnas.IdSubRubro.ToString())
            End If
         End If

         If en.IdSubSubRubro.HasValue AndAlso en.IdSubSubRubro.Value > 0 AndAlso Not cache.ExisteSubSubRubro(en.IdSubSubRubro.Value) Then
            'SubSubRubro en ALTA
            If Not GetCollection(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)(syncs).Any(Function(x) x.IdSubSubRubro = en.IdSubSubRubro.Value) Then
               en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el SubSubRubro con IdSubSubRubro = {0}.", en.IdSubSubRubro), Entidades.Producto.Columnas.IdSubSubRubro.ToString())
            End If
         End If

         'If en.IdMarca > 0 And Not cache.ExisteMarca(en.IdMarca) Then
         '   'Marca en ALTA
         '   If Not GetCollection(Of Entidades.JSonEntidades.Archivos.MarcaJSon)(syncs).Any(Function(x) x.IdMarca = en.IdMarca) Then
         '      en.ConErrores = SetErrorMessage(stbMensajeError, en, String.Format("No existe el Marca con IdMarca = {0}.", en.IdMarca), Entidades.Producto.Columnas.IdMarca.ToString())
         '   End If
         'End If

         SetEstadoRow(en, stbMensajeError, Function(x) cache.ExisteProductoPorIdRapido(x.IdProducto))

         OnAvanceValidarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)

   End Function

   Public Sub ValidarDatosProductos(dt As DataTable, cache As BusquedasCacheadas,
                                    dtRubros As DataTable,
                                    dtSubRubros As DataTable,
                                    dtSubSubRubros As DataTable,
                                    dtMarcas As List(Of Archivos.MarcaJSonTransporte))

      Dim serializer = New System.Web.Script.Serialization.JavaScriptSerializer()

      ValidarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.ProductoJSon)("DatosSyncronizados")),
                   New ServiciosRest.Sincronizacion.SyncBaseCollection().
                        AgregarDatosRecibidosCustom(GetType(Entidades.JSonEntidades.Archivos.RubroJSon),
                                                    dtRubros.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.RubroJSon)("DatosSyncronizados"))).
                        AgregarDatosRecibidosCustom(GetType(Entidades.JSonEntidades.Archivos.SubRubroJSon),
                                                    dtSubRubros.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)("DatosSyncronizados"))).
                        AgregarDatosRecibidosCustom(GetType(Entidades.JSonEntidades.Archivos.SubSubRubroJSon),
                                                    dtSubSubRubros.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)("DatosSyncronizados"))).
                        AgregarDatosRecibidosCustom(GetType(Entidades.JSonEntidades.Archivos.MarcaJSon), dtMarcas.
                                                         ConvertAll(Function(x) serializer.Deserialize(Of Entidades.JSonEntidades.Archivos.MarcaJSon)(x.DatosMarca)))
                        )

   End Sub

   Public Overrides Function ImportarDatos(transporte As List(Of Archivos.ProductoJSon)) As Boolean
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()

         Dim reIdentificacionProducto As Reglas.ProductosIdentificaciones = New Reglas.ProductosIdentificaciones(da)
         Dim reFormulaProducto As Reglas.ProductosFormulas = New Reglas.ProductosFormulas(da)
         Dim reProductoComponente As Reglas.ProductosComponentes = New Reglas.ProductosComponentes(da)
         Dim idFormulaOriginal As Integer = Nothing
         Dim idProductoOriginal As String = String.Empty
         Dim esCompuestoOriginal As Boolean? = Nothing

         Dim sProductos As SqlServer.Productos = New SqlServer.Productos(da)
         Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Productos")
         eventArgs.TotalRegistros = transporte.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing

         For Each dr As Archivos.ProductoJSon In transporte
            eventArgs.RegistroActual += 1
            eventArgs.Datos = dr
            Dim origenPorcImpInt As Entidades.OrigenesPorcImpInt = dr.OrigenPorcImpInt

            OnAvanceImportarDatos(eventArgs)

            '###########################################################################
            '# Almaceno el valor de IdFormula que viene con el producto temporalmente. #
            '###########################################################################
            idFormulaOriginal = dr.IdFormula
            idProductoOriginal = dr.IdProducto
            esCompuestoOriginal = dr.EsCompuesto

            Const esCompuestoParam = False
            Const idFormulaParam = 0I

            If dr.___Estado = "A" Then

               sProductos.Productos_I(dr.IdProducto.Trim(),
                                      dr.NombreProducto.RecuperarCaracteresEspeciales(),
                                      dr.Tamano,
                                      dr.IdUnidadDeMedida,
                                      dr.IdMarca,
                                      dr.IdModelo,
                                      dr.IdRubro,
                                      dr.IdSubRubro,
                                      dr.MesesGarantia,
                                      dr.IdTipoImpuesto,
                                      dr.Alicuota,
                                      dr.Alicuota2,
                                      dr.AfectaStock,
                                      dr.Activo,
                                      dr.Lote,
                                      dr.NroSerie,
                                      dr.CodigoDeBarras,
                                      dr.EsServicio,
                                      dr.PublicarEnWeb,
                                      dr.Observacion.RecuperarCaracteresEspeciales(),
                                      esCompuestoParam,
                                      dr.DescontarStockComponentes,
                                      dr.EsDeCompras,
                                      dr.EsDeVentas,
                                      dr.IdMoneda,
                                      dr.CodigoDeBarrasConPrecio,
                                      dr.PermiteModificarDescripcion,
                                      dr.EsAlquilable,
                                      dr.EquipoMarca,
                                      dr.EquipoModelo,
                                      dr.CaractSII,
                                      dr.NumeroSerie,
                                      dr.Anio,
                                      dr.PagaIngresosBrutos,
                                      dr.Embalaje,
                                      dr.Kilos, dr.KilosEsUMCompras,
                                      idFormulaParam,
                                      dr.IdProductoMercosur,
                                      dr.IdProductoSecretaria,
                                      dr.PublicarListaDePreciosClientes,
                                      dr.FacturacionCantidadNegativa,
                                      dr.SolicitaEnvase,
                                      dr.AlertaDeCaja,
                                      dr.NombreCorto,
                                      dr.EsRetornable,
                                      dr.Orden,
                                      dr.IdProveedor,
                                      dr.CodigoLargoProducto,
                                      dr.ModalidadCodigoDeBarras,
                                      dr.EsObservacion,
                                      dr.UnidHasta1, dr.UnidHasta2, dr.UnidHasta3, dr.UnidHasta4, dr.UnidHasta5,
                                      dr.UHPorc1, dr.UHPorc2, dr.UHPorc3, dr.UHPorc4, dr.UHPorc5,
                                      dr.UHListaPrecios1,
                                      dr.UHListaPrecios2,
                                      dr.UHListaPrecios3,
                                      dr.UHListaPrecios4,
                                      dr.UHListaPrecios5,
                                      dr.PrecioPorEmbalaje,
                                      dr.IdCuentaCompras,
                                      dr.IdCuentaVentas,
                                      dr.ImporteImpuestoInterno,
                                      dr.EsOferta,
                                      dr.IdCuentaComprasSecundaria,
                                      dr.IncluirExpensas,
                                      dr.IdCentroCosto,
                                      dr.ObservacionCompras.RecuperarCaracteresEspeciales(),
                                      dr.SolicitaPrecioVentaPorTamano,
                                      dr.Espmm,
                                      dr.EspPulgadas,
                                      dr.CodigoSAE,
                                      dr.IdProduccionProceso,
                                      dr.IdProduccionForma,
                                      dr.CalculaPreciosSegunFormula,
                                      dr.IdSubSubRubro.IfNull(),
                                      dr.PorcImpuestoInterno,
                                      origenPorcImpInt,
                                      dr.EsCambiable,
                                      dr.EsBonificable,
                                      dr.Alto, dr.Ancho, dr.Largo,
                                      dr.DescRecProducto,
                                      dr.ActualizaPreciosSucursalesAsociadas,
                                      dr.CalidadStatusLiberado,
                                      dr.CalidadFechaLiberado.ToDateTime().IfNull(),
                                      dr.CalidadUserLiberado,
                                      dr.CalidadStatusEntregado,
                                      dr.CalidadFechaEntregado.ToDateTime().IfNull(),
                                      dr.CalidadUserEntregado,
                                      dr.CalidadFechaIngreso.ToDateTime().IfNull(),
                                      dr.CalidadFechaEgreso.ToDateTime().IfNull(),
                                      dr.CalidadNroCertificado,
                                      dr.CalidadFecCertificado.ToDateTime().IfNull(),
                                      dr.CalidadUsrCertificado,
                                      dr.CalidadObservaciones,
                                      dr.CalidadFechaPreEnt.ToDateTime().IfNull(),
                                      dr.CalidadFechaEntProg.ToDateTime().IfNull(),
                                      dr.EsComercial,
                                      dr.PublicarEnTiendaNube,
                                      dr.PublicarEnMercadoLibre,
                                      dr.PublicarEnArborea,
                                      dr.PublicarEnGestion,
                                      dr.PublicarEnEmpresarial,
                                      dr.PublicarEnBalanza,
                                      dr.PublicarEnSincronizacionSucursal,
                                      dr.CalidadNumeroChasis,
                                      dr.CalidadNroCarroceria,
                                      dr.IdUnidadDeMedida2,
                                      dr.Conversion,
                                      dr.IdProductoNumerico,
                                      dr.EnviarSinCargo,
                                      dr.CodigoProductoTiendaNube,
                                      dr.CodigoProductoMercadoLibre,
                                      dr.CodigoProductoArborea,
                                      dr.IdVarianteProducto,
                                      dr.IdProductoTipoServicio,
                                      dr.CalidadNroDeMotor,
                                      dr.CalidadFechaEntReProg.ToDateTime().IfNull(),
                                      dr.IdProductoModelo,
                                      dr.CalidadNroCertEntregado,
                                      dr.CalidadFecCertEntregado.ToDateTime().IfNull(),
                                      dr.CalidadUsrCertEntregado,
                                      dr.CalidadStatusLiberadoPDI,
                                      dr.CalidadFechaLiberadoPDI.ToDateTime().IfNull(),
                                      dr.CalidadUserLiberadoPDI,
                                      dr.CalidadNroCertEObs,
                                      dr.CalidadNroRemito,
                                      dr.TipoBonificacion,
                                      Nothing, Nothing,
                                      dr.EsPerceptibleIVARes53292023, Nothing, String.Empty, False, 0, False, String.Empty,
                                      dr.IdUnidadDeMedidaCompra, dr.FactorConversionCompra, dr.IdUnidadDeMedidaProduccion,
                                      dr.FactorConversionProduccion,
                                      dr.ComisionPorVenta, dr.EsDevuelto)

               ' ------------------------------------------------------
               ' Identificaciones
               If dr.ProductoIdentificacion IsNot Nothing Then
                  For Each pi As Entidades.JSonEntidades.Archivos.ProductoIdentificacionJson In dr.ProductoIdentificacion
                     reIdentificacionProducto.Inserta(New Entidades.ProductoIdentificacion(pi.IdProducto, pi.Identificacion))
                  Next
               End If

               ' ------------------------------------------------------
               ' Fórmulas
               If dr.ProductoFormula IsNot Nothing Then
                  For Each pf As Entidades.JSonEntidades.Archivos.ProductoFormulaJson In dr.ProductoFormula
                     reFormulaProducto._Merge(New Entidades.ProductoFormula() _
                                                      With {.IdProducto = pf.IdProducto,
                                                            .IdFormula = pf.IdFormula,
                                                            .NombreFormula = pf.NombreFormula})
                  Next
               Else
                  idFormulaOriginal = 0
               End If

               '############################################################################################
               '# Actualizo el idFormula del producto, asegurandome que ya está en el sistema el IdFormula #
               '############################################################################################
               If idFormulaOriginal <> 0 AndAlso esCompuestoOriginal Then
                  sProductos.Productos_U_FormulaDefecto(idProductoOriginal, idFormulaOriginal, esCompuestoOriginal)
               End If

               ' ------------------------------------------------------
               ' Componentes
               'If dr.ProductoComponente IsNot Nothing Then
               '   For Each pc As Entidades.JSonEntidades.Archivos.ProductoComponenteJson In dr.ProductoComponente

               '      reProductoComponente._Insertar(New Entidades.ProductoComponente() _
               '                                       With {.IdProducto = pc.IdProducto,
               '                                             .IdProductoComponente = pc.IdProductoComponente,
               '                                             .Cantidad = pc.Cantidad,
               '                                             .IdFormula = pc.IdFormula,
               '                                             .SegunCalculoForma = pc.SegunCalculoForma})
               '   Next
               'End If

            ElseIf dr.___Estado = "M" Then
               'Dim i As Object = Clientes.ObtieneValor(Of Integer?)(dr, Entidades.Producto.Columnas.IdCentroCosto.ToString(), Nothing)

               Dim ActualizaPreciosSucursalesAsociadas As Boolean = dr.ActualizaPreciosSucursalesAsociadas
               sProductos.Productos_U(dr.IdProducto.Trim(),
                                      dr.NombreProducto.RecuperarCaracteresEspeciales(),
                                      dr.Tamano,
                                      dr.IdUnidadDeMedida,
                                      dr.IdMarca,
                                      dr.IdModelo,
                                      dr.IdRubro,
                                      dr.IdSubRubro,
                                      dr.MesesGarantia,
                                      dr.IdTipoImpuesto,
                                      dr.Alicuota,
                                      dr.Alicuota2,
                                      dr.AfectaStock,
                                      dr.Activo,
                                      dr.Lote,
                                      dr.NroSerie,
                                      dr.CodigoDeBarras,
                                      dr.EsServicio,
                                      dr.PublicarEnWeb,
                                      dr.Observacion.RecuperarCaracteresEspeciales(),
                                      esCompuestoParam,
                                      dr.DescontarStockComponentes,
                                      dr.EsDeCompras,
                                      dr.EsDeVentas,
                                      dr.IdMoneda,
                                      dr.CodigoDeBarrasConPrecio,
                                      dr.PermiteModificarDescripcion,
                                      dr.EsAlquilable,
                                      dr.EquipoMarca,
                                      dr.EquipoModelo,
                                      dr.CaractSII,
                                      dr.NumeroSerie,
                                      dr.Anio,
                                      dr.PagaIngresosBrutos,
                                      dr.Embalaje,
                                      dr.Kilos, dr.KilosEsUMCompras,
                                      idFormulaParam,
                                      dr.IdProductoMercosur,
                                      dr.IdProductoSecretaria,
                                      dr.PublicarListaDePreciosClientes,
                                      dr.FacturacionCantidadNegativa,
                                      dr.SolicitaEnvase,
                                      dr.AlertaDeCaja,
                                      dr.NombreCorto,
                                      dr.EsRetornable,
                                      dr.Orden,
                                      dr.IdProveedor,
                                      dr.CodigoLargoProducto,
                                      dr.ModalidadCodigoDeBarras,
                                      dr.EsObservacion,
                                      New Entidades.Modificable(Of Decimal)(dr.UnidHasta1, ActualizaPreciosSucursalesAsociadas),
                                      New Entidades.Modificable(Of Decimal)(dr.UnidHasta2, ActualizaPreciosSucursalesAsociadas),
                                      New Entidades.Modificable(Of Decimal)(dr.UnidHasta3, ActualizaPreciosSucursalesAsociadas),
                                      New Entidades.Modificable(Of Decimal)(dr.UnidHasta4, ActualizaPreciosSucursalesAsociadas),
                                      New Entidades.Modificable(Of Decimal)(dr.UnidHasta5, ActualizaPreciosSucursalesAsociadas),
                                      New Entidades.Modificable(Of Decimal)(dr.UHPorc1, ActualizaPreciosSucursalesAsociadas),
                                      New Entidades.Modificable(Of Decimal)(dr.UHPorc2, ActualizaPreciosSucursalesAsociadas),
                                      New Entidades.Modificable(Of Decimal)(dr.UHPorc3, ActualizaPreciosSucursalesAsociadas),
                                      New Entidades.Modificable(Of Decimal)(dr.UHPorc4, ActualizaPreciosSucursalesAsociadas),
                                      New Entidades.Modificable(Of Decimal)(dr.UHPorc5, ActualizaPreciosSucursalesAsociadas),
                                      dr.UHListaPrecios1,
                                      dr.UHListaPrecios2,
                                      dr.UHListaPrecios3,
                                      dr.UHListaPrecios4,
                                      dr.UHListaPrecios5,
                                      dr.PrecioPorEmbalaje,
                                      dr.IdCuentaCompras,
                                      dr.IdCuentaVentas,
                                      dr.ImporteImpuestoInterno,
                                      dr.EsOferta,
                                      dr.IdCuentaComprasSecundaria,
                                      dr.IncluirExpensas,
                                      dr.IdCentroCosto,
                                      dr.ObservacionCompras.RecuperarCaracteresEspeciales(),
                                      dr.SolicitaPrecioVentaPorTamano,
                                      dr.Espmm,
                                      dr.EspPulgadas,
                                      dr.CodigoSAE,
                                      dr.IdProduccionProceso,
                                      dr.IdProduccionForma,
                                      dr.CalculaPreciosSegunFormula,
                                      dr.IdSubSubRubro.IfNull(),
                                      dr.PorcImpuestoInterno,
                                      origenPorcImpInt,
                                      dr.EsCambiable,
                                      dr.EsBonificable,
                                      dr.Alto, dr.Ancho, dr.Largo,
                                      New Entidades.Modificable(Of Decimal)(dr.DescRecProducto, ActualizaPreciosSucursalesAsociadas),
                                      dr.ActualizaPreciosSucursalesAsociadas,
                                      dr.CalidadStatusLiberado,
                                      dr.CalidadFechaLiberado.ToDateTime().IfNull(),
                                      dr.CalidadUserLiberado,
                                      dr.CalidadStatusEntregado,
                                      dr.CalidadFechaEntregado.ToDateTime().IfNull(),
                                      dr.CalidadUserEntregado,
                                      dr.CalidadFechaIngreso.ToDateTime().IfNull(),
                                      dr.CalidadFechaEgreso.ToDateTime().IfNull(),
                                      dr.CalidadNroCertificado,
                                      dr.CalidadFecCertificado.ToDateTime().IfNull(),
                                      dr.CalidadUsrCertificado,
                                      dr.CalidadObservaciones,
                                      dr.CalidadFechaPreEnt.ToDateTime().IfNull(),
                                      dr.CalidadFechaEntProg.ToDateTime().IfNull(),
                                      dr.EsComercial,
                                      dr.PublicarEnTiendaNube,
                                      dr.PublicarEnMercadoLibre,
                                      dr.PublicarEnArborea,
                                      dr.PublicarEnGestion,
                                      dr.PublicarEnEmpresarial,
                                      dr.PublicarEnBalanza,
                                      dr.PublicarEnSincronizacionSucursal,
                                      dr.CalidadNumeroChasis,
                                      dr.CalidadNroCarroceria,
                                      dr.IdUnidadDeMedida2,
                                      dr.Conversion,
                                      dr.IdProductoNumerico,
                                      dr.EnviarSinCargo,
                                      dr.CodigoProductoTiendaNube,
                                      dr.CodigoProductoMercadoLibre,
                                      dr.CodigoProductoArborea,
                                      dr.IdVarianteProducto,
                                      dr.IdProductoTipoServicio,
                                      dr.CalidadNroDeMotor,
                                      dr.CalidadFechaEntReProg.ToDateTime().IfNull(),
                                      dr.IdProductoModelo,
                                      dr.CalidadNroCertEntregado,
                                      dr.CalidadFecCertEntregado.ToDateTime().IfNull(),
                                      dr.CalidadUsrCertEntregado,
                                      dr.CalidadStatusLiberadoPDI,
                                      dr.CalidadFechaLiberadoPDI.ToDateTime().IfNull(),
                                      dr.CalidadUserLiberadoPDI,
                                      dr.CalidadNroCertEObs,
                                      dr.CalidadNroRemito,
                                      dr.TipoBonificacion,
                                      Nothing, Nothing,
                                      dr.EsPerceptibleIVARes53292023, Nothing, String.Empty, False, 0, False, String.Empty,
                                      dr.IdUnidadDeMedidaCompra, dr.FactorConversionCompra, dr.IdUnidadDeMedidaProduccion,
                                      dr.FactorConversionProduccion, dr.ComisionPorVenta, dr.EsDevuelto)

               'Identificaciones
               If dr.ProductoIdentificacion IsNot Nothing Then
                  ' Primero elimino todos las Identificaciones que tenga ese Producto
                  reIdentificacionProducto.Borra(New Entidades.ProductoIdentificacion() With {.IdProducto = idProductoOriginal})
                  For Each pi As Entidades.JSonEntidades.Archivos.ProductoIdentificacionJson In dr.ProductoIdentificacion
                     ' Después hago un Insert
                     reIdentificacionProducto.Inserta(New Entidades.ProductoIdentificacion(pi.IdProducto, pi.Identificacion))
                  Next
               End If

               ' ------------------------------------------------------
               ' Fórmulas
               If dr.ProductoFormula IsNot Nothing Then
                  For Each pf As Entidades.JSonEntidades.Archivos.ProductoFormulaJson In dr.ProductoFormula
                     reFormulaProducto._Merge(New Entidades.ProductoFormula() _
                                                      With {.IdProducto = pf.IdProducto,
                                                            .IdFormula = pf.IdFormula,
                                                            .NombreFormula = pf.NombreFormula})
                  Next
               Else
                  idFormulaOriginal = 0
               End If


               '############################################################################################
               '# Actualizo el idFormula del producto, asegurandome que ya está en el sistema el IdFormula #
               '############################################################################################
               If idFormulaOriginal <> 0 AndAlso esCompuestoOriginal Then
                  sProductos.Productos_U_FormulaDefecto(idProductoOriginal, idFormulaOriginal, esCompuestoOriginal)
               End If


               ' ------------------------------------------------------
               ' Componentes
               'If dr.ProductoComponente IsNot Nothing Then
               '   ' Primero Borro los Componentes del Producto
               '   reProductoComponente._Borrar(New Entidades.ProductoComponente() With {.IdProducto = idProductoOriginal})

               '   For Each pc As Entidades.JSonEntidades.Archivos.ProductoComponenteJson In dr.ProductoComponente
               '      reProductoComponente._Insertar(New Entidades.ProductoComponente() _
               '                                       With {.IdProducto = pc.IdProducto,
               '                                             .IdProductoComponente = pc.IdProductoComponente,
               '                                             .Cantidad = pc.Cantidad,
               '                                             .IdFormula = pc.IdFormula,
               '                                             .SegunCalculoForma = pc.SegunCalculoForma})
               '   Next
               'End If
            End If


            dr.___Estado = "I"

            Dim fechaActualizacion = dr.FechaActualizacionWeb
            If IsDate(fechaActualizacion) Then
               Dim fecha = Date.Parse(fechaActualizacion)
               If Not maximoFechaActualizacion.HasValue Then
                  maximoFechaActualizacion = fecha
               End If

               If fecha > maximoFechaActualizacion Then
                  maximoFechaActualizacion = fecha
               End If
            End If

            OnAvanceImportarDatos(eventArgs)

         Next

         For Each dr In transporte.Where(Function(dr1) dr1.___Estado = "I" And dr1.ProductoComponente IsNot Nothing)
            idProductoOriginal = dr.IdProducto
            ' Primero Borro los Componentes del Producto
            reProductoComponente._Borrar(New Entidades.ProductoComponente() With {.IdProducto = idProductoOriginal})
            For Each pc In dr.ProductoComponente
               If Existe(pc.IdProducto, Entidades.Publicos.SiNoTodos.TODOS) And
                  Existe(pc.IdProductoComponente, Entidades.Publicos.SiNoTodos.TODOS) Then
                  reProductoComponente._Insertar(New Entidades.ProductoComponente() With
                                                {
                                                   .IdProducto = pc.IdProducto,
                                                   .IdProductoComponente = pc.IdProductoComponente,
                                                   .Cantidad = pc.Cantidad,
                                                   .IdFormula = pc.IdFormula,
                                                   .SegunCalculoForma = pc.SegunCalculoForma
                                                })
               End If
            Next
         Next

         If maximoFechaActualizacion.HasValue Then
            Publicos.WebArchivos.Productos.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
      Return True
   End Function

   Public Sub ImportarProductosDesdeWebSiga(dt As DataTable) Implements IRestServices.ImportarDesdeWebSiga
      ImportarDatos(dt.Select().ToList().ConvertAll(Function(x) x.Field(Of Entidades.JSonEntidades.Archivos.ProductoJSon)("DatosSyncronizados")))
   End Sub

   Public Sub ImportarDesdeWebSiga(Of T)(dtClientes As List(Of T)) Implements IRestServices.ImportarDesdeWebSiga
      Throw New NotImplementedException()
   End Sub

   Public Function GetProductosJSonTransporte(fechaActualizacionDesde As DateTime?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As List(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte)
      Dim datos As List(Of Entidades.JSonEntidades.Archivos.ProductoJSon) = GetProductosJSon(fechaActualizacionDesde, publicarEn)
      Dim result As List(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte) = New List(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad As Entidades.JSonEntidades.Archivos.ProductoJSon In datos
         Dim tProducto As Entidades.JSonEntidades.Archivos.ProductoJSonTransporte
         tProducto = New Entidades.JSonEntidades.Archivos.ProductoJSonTransporte(jEntidad.CuitEmpresa, jEntidad.IdProducto, jEntidad.FechaActualizacionWeb) 'Now.ToString(AyudanteJson.FormatoFechas))
         tProducto.DatosProducto = serializer.Serialize(jEntidad)
         result.Add(tProducto)
      Next

      Return result
   End Function

#End Region

End Class