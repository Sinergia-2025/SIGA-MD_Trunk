Public Class Productos
   Inherits Comunes

   Private Const maximoKey As String = "maximo"

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Productos_I(idProducto As String,
                          nombreProducto As String,
                          tamano As Decimal,
                          idUnidadDeMedida As String,
                          idMarca As Integer,
                          idModelo As Integer,
                          idRubro As Integer,
                          idSubRubro As Integer,
                          mesesGarantia As Integer,
                          idTipoImpuesto As String,
                          alicuota As Decimal,
                          alicuota2 As Decimal?,
                          afectaStock As Boolean,
                          activo As Boolean,
                          lote As Boolean,
                          nroSerie As Boolean,
                          codigoDeBarras As String,
                          esServicio As Boolean,
                          publicarEnWeb As Boolean,
                          observacion As String,
                          esCompuesto As Boolean,
                          descStockComp As Boolean,
                          esDeCompras As Boolean,
                          esDeVentas As Boolean,
                          idMoneda As Integer,
                          codigoDeBarrasConPrecio As Boolean,
                          permiteModificarDescripcion As Boolean,
                          esAlquilable As Boolean,
                          equipoMarca As String,
                          equipoModelo As String,
                          caractSII As String,
                          numeroSerie As String,
                          anio As Integer,
                          pagaIngresosBrutos As Boolean,
                          embalaje As Integer,
                          kilos As Decimal,
                          kilosEsUMCompras As Boolean,
                          idFormula As Integer,
                          idProductoMercosur As String,
                          idProductoSecretaria As String,
                          publicarListaDePreciosClientes As Boolean,
                          facturacionCantidadNegativa As Boolean,
                          solicitaEnvase As Boolean,
                          alertaDeCaja As Boolean,
                          nombreCorto As String,
                          esRetornable As Boolean,
                          orden As Integer,
                          idProveedor As Long,
                          codigoLargoProducto As String,
                          modalidadCodigoDeBarras As String,
                          esObservacion As Boolean,
                          unidHasta1 As Decimal,
                          unidHasta2 As Decimal,
                          unidHasta3 As Decimal,
                          unidHasta4 As Decimal,
                          unidHasta5 As Decimal,
                          uHPorc1 As Decimal,
                          uHPorc2 As Decimal,
                          uHPorc3 As Decimal,
                          uHPorc4 As Decimal,
                          uHPorc5 As Decimal,
                          uHlistaPrecios1 As Integer?,
                          uHlistaPrecios2 As Integer?,
                          uHlistaPrecios3 As Integer?,
                          uHlistaPrecios4 As Integer?,
                          uHlistaPrecios5 As Integer?,
                          precioPorEmbalaje As Boolean,
                          idCuentaCompras As Long?,
                          idCuentaVentas As Long?,
                          importeImpuestoInterno As Decimal,
                          esOferta As String,
                          idCuentaComprasSecundaria As Long?,
                          incluirExpensas As Boolean,
                          idCentroCosto As Integer?,
                          observacionCompras As String,
                          solicitaPrecioVentaPorTamano As Boolean,
                          espmm As Decimal,
                          espPulgadas As String,
                          codigoSAE As String,
                          idProduccionProceso As Integer,
                          idProduccionForma As Integer,
                          calculaPreciosSegunFormula As Boolean,
                          idSubSubRubro As Integer,
                          porcImpuestoInterno As Decimal,
                          origenPorcImpInt As Entidades.OrigenesPorcImpInt,
                          esCambiable As Boolean,
                          esBonificable As Boolean,
                          alto As Decimal,
                          ancho As Decimal,
                          largo As Decimal,
                          descRecProducto As Decimal,
                          actualizaPreciosSucursalesAsociadas As Boolean,
                          calidadStatusLiberado As Boolean,
                          calidadFechaLiberado As Date,
                          calidadUserLiberado As String,
                          calidadStatusEntregado As Boolean,
                          calidadFechaEntregado As Date,
                          calidadUserEntregado As String,
                          calidadFechaIngreso As Date,
                          calidadFechaEgreso As Date,
                          calidadNroCertificado As Integer,
                          calidadFecCertificado As Date,
                          calidadUsrCertificado As String,
                          calidadObservaciones As String,
                          calidadFechaPreEnt As Date,
                          calidadFechaEntProg As Date,
                          esComercial As Boolean,
                          publicarEnTiendaNube As Boolean,
                          publicarEnMercadoLibre As Boolean,
                          publicarEnArborea As Boolean,
                          publicarEnGestion As Boolean,
                          publicarEnEmpresarial As Boolean,
                          publicarEnBalanza As Boolean,
                          publicarEnSincronizacionSucursal As Boolean,
                          calidadNumeroChasis As String,
                          calidadNroCarroceria As Integer,
                          idUnidadDeMedida2 As String,
                          conversion As Decimal,
                          idProductoNumerico As Long?,
                          enviarSinCargo As Boolean,
                          codigoProductoTiendaNube As String,
                          codigoProductoMercadoLibre As String,
                          codigoProductoArborea As String,
                          idProductoVariante As String,
                          idProductoTipoServicio As Integer,
                          calidadNroDeMotor As String,
                          calidadFechaEntReProg As Date,
                          idProductoModelo As Integer,
                          calidadNroCertEntregado As Integer,
                          calidadFecCertEntregado As Date,
                          calidadUsrCertEntregado As String,
                          calidadStatusLiberadoPDI As Boolean,
                          calidadFechaLiberadoPDI As Date,
                          calidadUserLiberadoPDI As String,
                          calidadNroCertEObs As String,
                          calidadNroRemito As Long,
                          tipoBonificacion As Entidades.Producto.TiposBonificacionesProductos,
                          categoriaMercadoLibre As String,
                          nombreProductoWeb As String,
                          esPerceptibleIVARes53292023 As Boolean,
                          idProcesoProductivoDefecto As Long?,
                          controlaRealizar As String,
                          informeControlCalidad As Boolean,
                          valorAQL As Decimal,
                          realizaControlCalidad As Boolean,
                          nivelInspeccion As String,
                          idUnidadDeMedidaCompra As String, factorConversionCompra As Decimal, idUnidadDeMedidaProduccion As String, factorConversionProduccion As Decimal,
                          comisionPorVenta As Decimal, esDevuelto As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO Productos (")
         .AppendLine("   IdProducto")
         .AppendLine("  ,NombreProducto")
         .AppendLine("  ,Tamano")
         .AppendLine("  ,IdUnidadDeMedida")
         .AppendLine("  ,IdMarca")
         .AppendLine("  ,IdModelo")
         .AppendLine("  ,IdRubro")
         .AppendLine("  ,IdSubRubro")
         .AppendLine("  ,MesesGarantia")
         .AppendLine("  ,IdTipoImpuesto")
         .AppendLine("  ,Alicuota")
         .AppendLine("  ,Alicuota2")
         .AppendLine("  ,AfectaStock")
         .AppendLine("  ,Activo")
         .AppendLine("  ,Lote")
         .AppendLine("  ,NroSerie")
         .AppendLine("  ,CodigoDeBarras")
         .AppendLine("  ,EsServicio")
         .AppendLine("  ,PublicarEnWeb")
         .AppendLine("  ,Observacion")
         .AppendLine("  ,EsCompuesto")
         .AppendLine("  ,DescontarStockComponentes")
         .AppendLine("  ,EsDeCompras")
         .AppendLine("  ,EsDeVentas")
         .AppendLine("  ,IdMoneda")
         .AppendLine("  ,CodigoDeBarrasConPrecio")
         .AppendLine("  ,PermiteModificarDescripcion")
         .AppendLine("  ,EsAlquilable")
         .AppendLine("  ,EquipoMarca")
         .AppendLine("  ,EquipoModelo")
         .AppendLine("  ,NumeroSerie")
         .AppendLine("  ,CaractSII")
         .AppendLine("  ,Anio")
         .AppendLine("  ,PagaIngresosBrutos")
         .AppendLine("  ,Embalaje")
         .AppendLine("  ,Kilos")
         .AppendLine("  ,KilosEsUMCompras")
         .AppendLine("  ,IdFormula")
         .AppendLine("  ,IdProductoMercosur")
         .AppendLine("  ,IdProductoSecretaria")
         .AppendLine("  ,publicarListaDePreciosClientes")
         .AppendLine("  ,facturacionCantidadNegativa")
         .AppendLine("  ,solicitaEnvase")
         .AppendLine("  ,alertaDeCaja")
         .AppendLine("  ,nombreCorto")
         .AppendLine("  ,EsRetornable")
         .AppendLine("  ,Orden")
         .AppendLine("  ,IdProveedor")
         .AppendLine("  ,CodigoLargoProducto")
         .AppendLine("  ,ModalidadCodigoDeBarras")
         .AppendLine("  ,EsObservacion")
         .AppendLine(" ,UnidHasta1")
         .AppendLine(" ,UnidHasta2")
         .AppendLine(" ,UnidHasta3")
         .AppendLine(" ,UnidHasta4")
         .AppendLine(" ,UnidHasta5")
         .AppendLine(" ,UHPorc1")
         .AppendLine(" ,UHPorc2")
         .AppendLine(" ,UHPorc3")
         .AppendLine(" ,UHPorc4")
         .AppendLine(" ,UHPorc5")
         .AppendLine(" ,UHListaPrecios1")
         .AppendLine(" ,UHListaPrecios2")
         .AppendLine(" ,UHListaPrecios3")
         .AppendLine(" ,UHListaPrecios4")
         .AppendLine(" ,UHListaPrecios5")
         .AppendLine(" ,PrecioPorEmbalaje")
         .AppendLine(" ,IdCuentaCompras")
         .AppendLine(" ,IdCuentaVentas")
         .AppendLine(" ,ImporteImpuestoInterno")
         .AppendLine(" ,EsOferta")
         .AppendLine(" ,IdCuentaComprasSecundaria")
         .AppendLine(" ,IncluirExpensas")
         .AppendLine(" ," + Entidades.Producto.Columnas.IdCentroCosto.ToString())
         .AppendLine(" ,ObservacionCompras")
         .AppendLine(" ,SolicitaPrecioVentaPorTamano")
         .AppendLine(" ,Espmm")
         .AppendLine(" ,EspPulgadas")
         .AppendLine(" ,CodigoSAE")
         .AppendLine(" ,IdProduccionProceso")
         .AppendLine(" ,IdProduccionForma")
         .AppendLine(" ,CalculaPreciosSegunFormula")
         .AppendLine(" ,IdSubSubRubro")
         .AppendLine(" ,PorcImpuestoInterno")
         .AppendLine(" ,OrigenPorcImpInt")
         .AppendLine(" ,EsCambiable")
         .AppendLine(" ,EsBonificable")
         .AppendLine(" ,ALto")
         .AppendLine(" ,Ancho")
         .AppendLine(" ,Largo")
         .AppendLine(" ,DescRecProducto")
         .AppendLine(" ,ActualizaPreciosSucursalesAsociadas")
         .AppendLine(" , CalidadStatusLiberado ")
         .AppendLine(" , CalidadFechaLiberado")
         .AppendLine(" , CalidadUserLiberado ")
         .AppendLine(" , CalidadStatusEntregado")
         .AppendLine(" , CalidadFechaEntregado")
         .AppendLine(" , CalidadUserEntregado")
         .AppendLine(" , CalidadFechaIngreso")
         .AppendLine(" , CalidadFechaEgreso")
         .AppendLine(" , CalidadNroCertificado")
         .AppendLine(" , CalidadFecCertificado")
         .AppendLine(" , CalidadUsrCertificado")
         .AppendLine(" , CalidadObservaciones")
         .AppendLine(" , CalidadFechaPreEnt")
         .AppendLine(" , CalidadFechaEntProg ")
         .AppendLine(" , EsComercial ")

         .AppendLine(" , PublicarEnTiendaNube")
         .AppendLine(" , PublicarEnMercadoLibre")
         .AppendLine(" , PublicarEnArborea")
         .AppendLine(" , PublicarEnGestion")
         .AppendLine(" , PublicarEnEmpresarial")
         .AppendLine(" , PublicarEnBalanza")
         .AppendLine(" , PublicarEnSincronizacionSucursal")
         .AppendLine(" , CalidadNumeroChasis")
         .AppendLine(" , CalidadNroCarroceria")
         .AppendLine(" , IdUnidadDeMedida2")
         .AppendLine(" , Conversion")
         .AppendLine(" , IdProductoNumerico")
         .AppendLine(" , EnviarSinCargo")
         .AppendLine(" , CodigoProductoTiendaNube")
         .AppendLine(" , CodigoProductoMercadoLibre")
         .AppendLine(" , CodigoProductoArborea")
         .AppendLine(" , IdVarianteProducto")
         .AppendLine(" ,IdProductoTipoServicio")
         .AppendLine(" ,CalidadNroDeMotor")
         .AppendLine(" ,CalidadFechaEntReProg")
         .AppendLine(" ,IdProductoModelo")
         .AppendLine(" , CalidadNroCertEntregado")
         .AppendLine(" , CalidadFecCertEntregado")
         .AppendLine(" , CalidadUsrCertEntregado")
         .AppendLine(" , CalidadStatusLiberadoPDI ")
         .AppendLine(" , CalidadFechaLiberadoPDI")
         .AppendLine(" , CalidadUserLiberadoPDI ")
         .AppendLine(" , CalidadNroCertEObs")
         .AppendLine(" , CalidadNroRemito")
         .AppendLine(" ,idCategoriaMercadoLibre")
         .AppendLine(" ,NombreProductoWeb")
         .AppendLine(" ,TipoBonificacion")
         .AppendLine(" ,EsPerceptibleIVARes53292023")
         '-- REQ-38948.- ----------------------------------------
         .AppendLine(" ,IdProcesoProductivoDefecto")
         .AppendLine(" ,ControlaRealizar")
         .AppendLine(" ,InformeControlCalidad")
         .AppendLine(" ,ValorAQL")

         .AppendLine(" ,NivelInspeccion")
         .AppendLine(" ,RealizaControlCalidad")
         .AppendFormatLine(" ,IdUnidadDeMedidaCompra ,FactorConversionCompra ,IdUnidadDeMedidaProduccion ,FactorConversionProduccion")
         '-------------------------------------------------------
         .AppendLine(" ,ComisionPorVenta , EsDevuelto")
         .AppendLine(") VALUES (")
         .AppendLine("  '" & idProducto & "'")
         .AppendLine("  ,'" & nombreProducto & "'")

         If tamano > 0 And Not String.IsNullOrEmpty(idUnidadDeMedida) Then
            .AppendLine("  ," & tamano.ToString() & "")
            .AppendLine("  ,'" & idUnidadDeMedida & "'")
         Else
            .AppendLine("  ,null")
            .AppendLine("  ,null")
         End If

         .AppendLine("  ," & idMarca.ToString() & "")

         If idModelo = 0 Then
            .AppendLine("  ,null")
         Else
            .AppendLine("  ," & idModelo.ToString() & "")
         End If

         .AppendLine("  ," & idRubro.ToString() & "")

         If idSubRubro = 0 Then
            .AppendLine("  ,null")
         Else
            .AppendLine("  ," & idSubRubro.ToString())
         End If

         .AppendLine(", " & mesesGarantia.ToString())
         .AppendLine(", '" & idTipoImpuesto.ToString() & "'")
         .AppendLine(", " & alicuota.ToString())
         If alicuota2.HasValue AndAlso alicuota2.Value >= 0 AndAlso alicuota2.Value <> alicuota Then
            .AppendLine(", " & alicuota2.Value.ToString())
         Else
            .AppendLine(", NULL")
         End If
         .AppendLine(", '" & afectaStock.ToString() & "'")
         .AppendLine(", '" & activo.ToString() & "'")
         .AppendLine(", '" & lote.ToString() & "'")
         .AppendLine(", '" & nroSerie.ToString() & "'")

         If String.IsNullOrEmpty(codigoDeBarras) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & codigoDeBarras & "'")
         End If

         .AppendFormat(", {0}", GetStringFromBoolean(esServicio))
         .AppendFormat(", {0}", GetStringFromBoolean(publicarEnWeb))
         .AppendLine(", '" & observacion & "'")

         .AppendFormat(", {0}", GetStringFromBoolean(esCompuesto))
         .AppendFormat(", {0}", GetStringFromBoolean(descStockComp))
         .AppendFormat(", {0}", GetStringFromBoolean(esDeCompras))
         .AppendFormat(", {0}", GetStringFromBoolean(esDeVentas))
         .AppendLine(", " & idMoneda.ToString())
         .AppendFormat(", {0}", GetStringFromBoolean(codigoDeBarrasConPrecio))
         .AppendFormat(", {0}", GetStringFromBoolean(permiteModificarDescripcion))

         .AppendFormat(", {0}", GetStringFromBoolean(esAlquilable))

         If String.IsNullOrEmpty(equipoMarca) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & equipoMarca & "'")
         End If
         If String.IsNullOrEmpty(equipoModelo) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & equipoModelo & "'")
         End If
         If String.IsNullOrEmpty(caractSII) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & caractSII & "'")
         End If
         If String.IsNullOrEmpty(numeroSerie) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & numeroSerie & "'")
         End If
         If anio = 0 Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ," & anio.ToString())
         End If
         .AppendFormat(", {0}", GetStringFromBoolean(pagaIngresosBrutos))
         .AppendLine(", " & embalaje.ToString())
         .AppendLine(", " & kilos.ToString())
         .AppendFormatLine(" , {0}", GetStringFromBoolean(kilosEsUMCompras))
         If esCompuesto Then
            .AppendLine("  ," & idFormula)
         Else
            .AppendLine("  ,NULL")
         End If

         If String.IsNullOrEmpty(idProductoMercosur) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & idProductoMercosur & "'")
         End If
         If String.IsNullOrEmpty(idProductoSecretaria) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & idProductoSecretaria & "'")
         End If

         .AppendLine("  ," & GetStringFromBoolean(publicarListaDePreciosClientes))
         .AppendLine("  ," & GetStringFromBoolean(facturacionCantidadNegativa))
         .AppendLine("  ," & GetStringFromBoolean(solicitaEnvase))
         .AppendLine("  ," & GetStringFromBoolean(alertaDeCaja))
         .AppendLine("  ,'" & nombreCorto & "'")
         .AppendLine("  ," & GetStringFromBoolean(esRetornable))
         .AppendLine(", " & orden.ToString())
         If idProveedor > 0 Then
            .AppendLine(", " & idProveedor.ToString())
         Else
            .AppendLine(", NULL ")
         End If
         .AppendLine(", '" & codigoLargoProducto & "'")
         If String.IsNullOrWhiteSpace(modalidadCodigoDeBarras) Or Not codigoDeBarrasConPrecio Then
            .AppendLine(", NULL ")
         Else
            .AppendLine(", '" & modalidadCodigoDeBarras & "'")
         End If
         .AppendLine(" ," & GetStringFromBoolean(esObservacion) & ",")
         .Append(unidHasta1.ToString() & ",")
         .Append(unidHasta2.ToString() & ",")
         .Append(unidHasta3.ToString() & ",")
         .Append(unidHasta4.ToString() & ",")
         .Append(unidHasta5.ToString() & ",")
         .Append(uHPorc1.ToString() & ",")
         .Append(uHPorc2.ToString() & ",")
         .Append(uHPorc3.ToString() & ",")
         .Append(uHPorc4.ToString() & ",")
         .Append(uHPorc5.ToString() & ",")

         If uHlistaPrecios1.HasValue Then
            .AppendFormatLine("{0}", uHlistaPrecios1.Value)
         Else
            .AppendFormatLine("NULL")
         End If
         If uHlistaPrecios2.HasValue Then
            .AppendFormatLine(",{0}", uHlistaPrecios2.Value)
         Else
            .AppendFormatLine(",NULL")
         End If
         If uHlistaPrecios3.HasValue Then
            .AppendFormatLine(",{0}", uHlistaPrecios3.Value)
         Else
            .AppendFormatLine(",NULL")
         End If
         If uHlistaPrecios4.HasValue Then
            .AppendFormatLine(",{0}", uHlistaPrecios4.Value)
         Else
            .AppendFormatLine(",NULL")
         End If
         If uHlistaPrecios5.HasValue Then
            .AppendFormatLine(",{0}", uHlistaPrecios5.Value)
         Else
            .AppendFormatLine(",NULL")
         End If
         .AppendLine(",")
         .AppendFormatLine(GetStringFromBoolean(precioPorEmbalaje))
         If idCuentaCompras.HasValue AndAlso idCuentaCompras.Value > 0 Then
            .AppendLine(" , " & idCuentaCompras.Value.ToString())
         Else
            .AppendLine(" , NULL")
         End If
         If idCuentaVentas.HasValue AndAlso idCuentaVentas.Value > 0 Then
            .AppendLine(" , " & idCuentaVentas.Value.ToString())
         Else
            .AppendLine(" , NULL")
         End If
         .AppendLine(" ," & importeImpuestoInterno.ToString())
         .AppendLine(" ,'" & esOferta.ToString() & "'")

         If idCuentaComprasSecundaria.HasValue AndAlso idCuentaComprasSecundaria.Value > 0 Then
            .AppendLine(" , " & idCuentaComprasSecundaria.Value.ToString())
         Else
            .AppendLine(" , NULL")
         End If
         .AppendLine(" ," + GetStringFromBoolean(incluirExpensas))

         If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
            .AppendLine("  ," + idCentroCosto.ToString())
         Else
            .AppendLine(" , NULL")
         End If

         .AppendFormat(" ,'{0}'", observacionCompras).AppendLine()
         .AppendFormat(" ,{0}", GetStringFromBoolean(solicitaPrecioVentaPorTamano)).AppendLine()

         .AppendFormat(" ,{0}", espmm).AppendLine()

         .AppendFormat(" ,'{0}'", espPulgadas).AppendLine()

         .AppendFormat(" ,'{0}'", codigoSAE).AppendLine()

         If idProduccionProceso > 0 Then
            .AppendFormat(" ,{0}", idProduccionProceso).AppendLine()
         Else
            .AppendFormat(" ,NULL").AppendLine()
         End If
         If idProduccionForma > 0 Then
            .AppendFormat(" ,{0}", idProduccionForma).AppendLine()
         Else
            .AppendFormat(" ,NULL").AppendLine()
         End If

         .AppendFormat(" ,{0}", GetStringFromBoolean(calculaPreciosSegunFormula)).AppendLine()
         If idSubSubRubro > 0 Then
            .AppendFormat(" ,{0}", idSubSubRubro).AppendLine()
         Else
            .AppendFormat(" ,NULL").AppendLine()
         End If

         .AppendFormat(" ,'{0}'", porcImpuestoInterno.ToString()).AppendLine()
         .AppendFormat(",'{0}'", origenPorcImpInt.ToString()).AppendLine()

         .AppendFormat(" ,{0}", GetStringFromBoolean(esCambiable)).AppendLine()
         .AppendFormat(" ,{0}", GetStringFromBoolean(esBonificable)).AppendLine()
         .AppendLine(", " & alto.ToString())
         .AppendLine(", " & ancho.ToString())
         .AppendLine(", " & largo.ToString())
         .AppendFormat(" ,{0}", descRecProducto).AppendLine()
         .AppendFormatLine(" ,{0}", GetStringFromBoolean(actualizaPreciosSucursalesAsociadas))

         .AppendFormatLine(" ,{0}", GetStringFromBoolean(calidadStatusLiberado))

         If calidadFechaLiberado = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", calidadFechaLiberado.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(calidadUserLiberado) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & calidadUserLiberado & "'")
         End If

         .AppendFormatLine(" ,{0}", GetStringFromBoolean(calidadStatusEntregado))
         If calidadFechaEntregado = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", calidadFechaEntregado.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(calidadUserEntregado) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & calidadUserEntregado & "'")
         End If

         If calidadFechaIngreso = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", calidadFechaIngreso.ToString("yyyyMMdd HH:mm:ss"))
         End If

         If calidadFechaEgreso = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", calidadFechaEgreso.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If calidadNroCertificado > 0 Then
            .AppendFormat(" ,{0}", calidadNroCertificado).AppendLine()
         Else
            .AppendFormat(" ,NULL").AppendLine()
         End If
         If calidadFecCertificado = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", calidadFecCertificado.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(calidadUsrCertificado) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & calidadUsrCertificado & "'")
         End If
         If String.IsNullOrEmpty(calidadObservaciones) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & calidadObservaciones & "'")
         End If

         If calidadFechaPreEnt = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", calidadFechaPreEnt.ToString("yyyyMMdd HH:mm:ss"))
         End If

         If calidadFechaEntProg = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", calidadFechaEntProg.ToString("yyyyMMdd HH:mm:ss"))
         End If

         .AppendFormat(", {0}", GetStringFromBoolean(esComercial))

         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnTiendaNube))
         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnMercadoLibre))
         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnArborea))
         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnGestion))
         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnEmpresarial))
         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnBalanza))
         .AppendFormatLine(", {0}", GetStringFromBoolean(publicarEnSincronizacionSucursal))
         If String.IsNullOrEmpty(calidadNumeroChasis) Then
            .AppendFormat("  , NULL")
         Else
            .AppendFormat("  ,'{0}'", calidadNumeroChasis)
         End If
         If calidadNroCarroceria > 0 Then
            .AppendFormat(" ,{0}", calidadNroCarroceria).AppendLine()
         Else
            .AppendFormat(" ,NULL").AppendLine()
         End If

         If Not String.IsNullOrEmpty(idUnidadDeMedida2) Then
            .AppendFormatLine(" ,'{0}'", idUnidadDeMedida2)
         Else
            .AppendFormatLine(" ,NULL")
         End If

         .AppendFormatLine(" ,{0}", conversion)

         If idProductoNumerico.HasValue Then
            .AppendFormatLine(" ,{0}", idProductoNumerico.Value)
         Else
            .AppendFormatLine(" ,NULL")
         End If

         .AppendFormatLine(" ,{0}", GetStringFromBoolean(enviarSinCargo))

         If Not String.IsNullOrEmpty(codigoProductoTiendaNube) Then
            .AppendFormatLine(" ,'{0}'", codigoProductoTiendaNube)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrEmpty(codigoProductoMercadoLibre) Then
            .AppendFormatLine(" ,'{0}'", codigoProductoMercadoLibre)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrEmpty(codigoProductoArborea) Then
            .AppendFormatLine(" ,'{0}'", codigoProductoArborea)
         Else
            .AppendFormatLine(" , NULL")
         End If

         .AppendFormatLine(" ,'{0}'", idProductoVariante)

         If idProductoTipoServicio > 0 Then
            .AppendFormat(" ,{0}", idProductoTipoServicio).AppendLine()
         Else
            .AppendFormat(" ,NULL").AppendLine()
         End If
         If Not String.IsNullOrEmpty(calidadNroDeMotor) Then
            .AppendFormatLine(" ,'{0}'", calidadNroDeMotor)
         Else
            .AppendFormatLine(" , NULL")
         End If

         If calidadFechaEntReProg = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", calidadFechaEntReProg.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If idProductoModelo > 0 Then
            .AppendFormat(" ,{0}", idProductoModelo).AppendLine()
         Else
            .AppendFormat(" ,NULL").AppendLine()
         End If

         If calidadNroCertEntregado > 0 Then
            .AppendFormat(" ,{0}", calidadNroCertEntregado).AppendLine()
         Else
            .AppendFormat(" ,NULL").AppendLine()
         End If
         If calidadFecCertEntregado = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", calidadFecCertEntregado.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(calidadUsrCertEntregado) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & calidadUsrCertEntregado & "'")
         End If
         .AppendFormatLine(" ,{0}", GetStringFromBoolean(calidadStatusLiberadoPDI))

         If calidadFechaLiberadoPDI = Nothing Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", calidadFechaLiberadoPDI.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(calidadUserLiberadoPDI) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & calidadUserLiberadoPDI & "'")
         End If

         If String.IsNullOrEmpty(calidadNroCertEObs) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & calidadNroCertEObs & "'")
         End If

         If calidadNroRemito > 0 Then
            .AppendFormat(" ,{0}", calidadNroRemito).AppendLine()
         Else
            .AppendFormat(" ,NULL").AppendLine()
         End If

         '-- REQ-30521.- --
         .AppendFormatLine(" ,'{0}'", categoriaMercadoLibre)
         '-- REQ-31619.- --
         .AppendFormatLine(" ,'{0}'", nombreProductoWeb)
         .AppendFormatLine(" ,'{0}'", tipoBonificacion.ToString())
         .AppendFormatLine(" , {0} ", GetStringFromBoolean(esPerceptibleIVARes53292023))

         '-- REQ-38948.- ----------------------------------------------------------------
         If idProcesoProductivoDefecto.HasValue Then
            .AppendFormatLine(" ,{0}", idProcesoProductivoDefecto.Value)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If String.IsNullOrEmpty(controlaRealizar) Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & controlaRealizar & "'")
         End If
         .AppendFormatLine(" , {0} ", GetStringFromBoolean(informeControlCalidad))
         .AppendFormatLine(" , {0} ", valorAQL)
         '-------------------------------------------------------------------------------
         If nivelInspeccion = "-1" Then
            .AppendLine("  , NULL")
         Else
            .AppendLine("  ,'" & nivelInspeccion & "'")
         End If
         .AppendFormatLine(" , {0} ", GetStringFromBoolean(realizaControlCalidad))
         '-------------------------------------------------------------------------------

         .AppendFormatLine(" ,'{0}', {1} ,'{2}' ,{3}", idUnidadDeMedidaCompra, factorConversionCompra, idUnidadDeMedidaProduccion, factorConversionProduccion)

         .AppendFormatLine(" ,{0}", comisionPorVenta)

         .AppendFormat(", {0}", GetStringFromBoolean(esDevuelto))

         .AppendLine(") ")
      End With
      Execute(myQuery)
   End Sub

   Public Sub Productos_U(idProducto As String,
                          nombreProducto As String,
                          tamano As Decimal,
                          idUnidadDeMedida As String,
                          idMarca As Integer,
                          idModelo As Integer,
                          idRubro As Integer,
                          idSubRubro As Integer,
                          mesesGarantia As Int32,
                          idTipoImpuesto As String,
                          alicuota As Decimal,
                          alicuota2 As Decimal?,
                          afectaStock As Boolean,
                          activo As Boolean,
                          lote As Boolean,
                          nroSerie As Boolean,
                          codigoDeBarras As String,
                          esServicio As Boolean,
                          publicarEnWeb As Boolean,
                          observacion As String,
                          esCompuesto As Boolean,
                          descStockComp As Boolean,
                          esDeCompras As Boolean,
                          esDeVentas As Boolean,
                          idMoneda As Integer,
                          codigoDeBarrasConPrecio As Boolean,
                          permiteModificarDescripcion As Boolean,
                          esAlquilable As Boolean,
                          equipoMarca As String,
                          equipoModelo As String,
                          caractSII As String,
                          numeroSerie As String,
                          anio As Integer,
                          pagaIngresosBrutos As Boolean,
                          embalaje As Integer,
                          kilos As Decimal,
                          kilosEsUMCompras As Boolean,
                          idFormula As Integer,
                          idProductoMercosur As String,
                          idProductoSecretaria As String,
                          publicarListaDePreciosClientes As Boolean,
                          facturacionCantidadNegativa As Boolean,
                          solicitaEnvase As Boolean,
                          alertaDeCaja As Boolean,
                          nombreCorto As String,
                          esRetornable As Boolean,
                          orden As Integer,
                          idProveedor As Long,
                          codigoLargoProducto As String,
                          modalidadCodigoDeBarras As String,
                          esObservacion As Boolean,
                          unidHasta1 As Entidades.Modificable(Of Decimal),
                          unidHasta2 As Entidades.Modificable(Of Decimal),
                          unidHasta3 As Entidades.Modificable(Of Decimal),
                          unidHasta4 As Entidades.Modificable(Of Decimal),
                          unidHasta5 As Entidades.Modificable(Of Decimal),
                          uHPorc1 As Entidades.Modificable(Of Decimal),
                          uHPorc2 As Entidades.Modificable(Of Decimal),
                          uHPorc3 As Entidades.Modificable(Of Decimal),
                          uHPorc4 As Entidades.Modificable(Of Decimal),
                          uHPorc5 As Entidades.Modificable(Of Decimal),
                          uHListaPrecios1 As Integer?,
                          uHListaPrecios2 As Integer?,
                          uHListaPrecios3 As Integer?,
                          uHListaPrecios4 As Integer?,
                          uHListaPrecios5 As Integer?,
                          precioPorEmbalaje As Boolean,
                          idCuentaCompras As Long?,
                          idCuentaVentas As Long?,
                          importeImpuestoInterno As Decimal,
                          esOferta As String,
                          idCuentaComprasSecundaria As Long?,
                          incluirExpensas As Boolean,
                          idCentroCosto As Integer?,
                          observacionCompras As String,
                          solicitaPrecioVentaPorTamano As Boolean,
                          espmm As Decimal,
                          espPulgadas As String,
                          codigoSAE As String,
                          idProduccionProceso As Integer,
                          idProduccionForma As Integer,
                          calculaPreciosSegunFormula As Boolean,
                          idSubSubRubro As Integer,
                          porcImpuestoInterno As Decimal,
                          origenPorcImpInt As Entidades.OrigenesPorcImpInt,
                          esCambiable As Boolean,
                          esBonificable As Boolean,
                          alto As Decimal,
                          ancho As Decimal,
                          largo As Decimal,
                          descRecProducto As Entidades.Modificable(Of Decimal),
                          actualizaPreciosSucursalesAsociadas As Boolean,
                          calidadStatusLiberado As Boolean,
                          calidadFechaLiberado As Date,
                          calidadUserLiberado As String,
                          calidadStatusEntregado As Boolean,
                          calidadFechaEntregado As Date,
                          calidadUserEntregado As String,
                          calidadFechaIngreso As Date,
                          calidadFechaEgreso As Date,
                          calidadNroCertificado As Integer,
                          calidadFecCertificado As Date,
                          calidadUsrCertificado As String,
                          calidadObservaciones As String,
                          calidadFechaPreEnt As Date,
                          calidadFechaEntProg As Date,
                          esComercial As Boolean,
                          publicarEnTiendaNube As Boolean,
                          publicarEnMercadoLibre As Boolean,
                          publicarEnArborea As Boolean,
                          publicarEnGestion As Boolean,
                          publicarEnEmpresarial As Boolean,
                          publicarEnBalanza As Boolean,
                          publicarEnSincronizacionSucursal As Boolean,
                          CalidadNumeroChasis As String,
                          CalidadNroCarroceria As Integer,
                          idUnidadDeMedida2 As String,
                          conversion As Decimal,
                          idProductoNumerico As Long?,
                          enviarSinCargo As Boolean,
                          codigoProductoTiendaNube As String,
                          codigoProductoMercadoLibre As String,
                          codigoProductoArborea As String,
                          idProductoVariante As String,
                          idProductoTipoServicio As Integer,
                          calidadNroDeMotor As String,
                          calidadFechaEntReProg As Date,
                          idProductoModelo As Integer,
                          calidadNroCertEntregado As Integer,
                          calidadFecCertEntregado As Date,
                          calidadUsrCertEntregado As String,
                          calidadStatusLiberadoPDI As Boolean,
                          calidadFechaLiberadoPDI As Date,
                          calidadUserLiberadoPDI As String,
                          calidadNroCertEObs As String,
                          calidadNroRemito As Long,
                          tipoBonificacion As Entidades.Producto.TiposBonificacionesProductos,
                          categoriaMercadoLibre As String,
                          nombreProductoWeb As String,
                          esPerceptibleIVARes53292023 As Boolean,
                          idProcesoProductivoDefecto As Long?,
                          controlaRealizar As String,
                          informeControlCalidad As Boolean,
                          valorAQL As Decimal,
                          realizaControlCalidad As Boolean,
                          nivelInspeccion As String,
                          idUnidadDeMedidaCompra As String, factorConversionCompra As Decimal, idUnidadDeMedidaProduccion As String, factorConversionProduccion As Decimal,
                          comisionPorVenta As Decimal, esDevuelto As Boolean)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Productos SET ")
         .AppendLine("  NombreProducto = '" & nombreProducto & "'")
         .AppendLine(" , Nombrecorto = '" & nombreCorto & "'")

         If tamano > 0 And Not String.IsNullOrEmpty(idUnidadDeMedida) Then
            .AppendLine("  ,Tamano = " & tamano.ToString())
            .AppendLine("  ,IdUnidadDeMedida = '" & idUnidadDeMedida & "'")
         Else
            .AppendLine("  ,Tamano = NULL")
            .AppendLine("  ,IdUnidadDeMedida = null")
         End If

         .AppendLine("  ,IdMarca = " & idMarca.ToString())

         If idModelo = 0 Then
            .AppendLine("  ,idModelo = null")
         Else
            .AppendLine("  ,idModelo = " & idModelo.ToString())
         End If

         .AppendLine("  ,IdRubro = " & idRubro.ToString())

         If idSubRubro = 0 Then
            .AppendLine("  ,idSubRubro = null")
         Else
            .AppendLine("  ,idSubRubro = " & idSubRubro.ToString())
         End If

         .AppendLine(", MesesGarantia = " & mesesGarantia.ToString())
         .AppendLine(", IdTipoImpuesto = '" & idTipoImpuesto.ToString() & "'")
         .AppendLine(", Alicuota = " & alicuota.ToString())
         If alicuota2.HasValue AndAlso alicuota2.Value >= 0 AndAlso alicuota2.Value <> alicuota Then
            .AppendLine("  ,Alicuota2 = " & alicuota2.Value.ToString()).AppendLine()
         Else
            .AppendLine("  ,Alicuota2 = NULL")
         End If
         .AppendLine(", AfectaStock = '" & afectaStock.ToString() & "'")
         .AppendLine(", Activo = '" & activo.ToString() & "'")
         .AppendLine("  ,Lote = '" & lote.ToString() & "'")
         .AppendLine("  ,NroSerie = '" & nroSerie.ToString() & "'")

         If String.IsNullOrEmpty(codigoDeBarras) Then
            .AppendLine("  ,CodigoDeBarras = null")
         Else
            .AppendLine("  ,CodigoDeBarras = '" & codigoDeBarras & "'")
         End If
         .AppendLine("  ,EsServicio = " & GetStringFromBoolean(esServicio))
         .AppendLine("  ,PublicarEnWeb = " & GetStringFromBoolean(publicarEnWeb))
         .AppendLine("  ,Observacion = '" & observacion & "'")
         .AppendLine("  ,EsCompuesto = " & GetStringFromBoolean(esCompuesto))
         .AppendLine("  ,DescontarStockComponentes = " & GetStringFromBoolean(descStockComp))
         .AppendLine("  ,EsDeCompras = " & GetStringFromBoolean(esDeCompras))
         .AppendLine("  ,EsDeVentas = " & GetStringFromBoolean(esDeVentas))
         .AppendLine(", IdMoneda = " & idMoneda.ToString())

         .AppendLine("  ,CodigoDeBarrasConPrecio = " & GetStringFromBoolean(codigoDeBarrasConPrecio))

         .AppendLine("  ,PermiteModificarDescripcion = " & GetStringFromBoolean(permiteModificarDescripcion))

         .AppendLine("  ,esAlquilable = " & GetStringFromBoolean(esAlquilable))
         If String.IsNullOrEmpty(equipoMarca) Then
            .AppendLine("  ,EquipoMarca = null")
         Else
            .AppendLine("  ,EquipoMarca = '" & equipoMarca & "'")
         End If
         If String.IsNullOrEmpty(equipoModelo) Then
            .AppendLine("  ,EquipoModelo = null")
         Else
            .AppendLine("  ,EquipoModelo = '" & equipoModelo & "'")
         End If
         If String.IsNullOrEmpty(caractSII) Then
            .AppendLine("  ,caractSII = null")
         Else
            .AppendLine("  ,caractSII = '" & caractSII & "'")
         End If
         If String.IsNullOrEmpty(numeroSerie) Then
            .AppendLine("  ,numeroSerie = null")
         Else
            .AppendLine("  ,numeroSerie = '" & numeroSerie & "'")
         End If
         If anio = 0 Then
            .AppendLine("  ,anio = null")
         Else
            .AppendLine("  ,anio = " & anio.ToString())
         End If
         .AppendLine("  ,PagaIngresosBrutos = " & GetStringFromBoolean(pagaIngresosBrutos))
         .AppendLine("  ,Embalaje = " & embalaje.ToString())
         .AppendLine("  ,Kilos = " & kilos.ToString())
         .AppendFormatLine("   , KilosEsUMCompras = {0}", GetStringFromBoolean(kilosEsUMCompras))
         If esCompuesto And idFormula > 0 Then
            .AppendLine("  ,IdFormula = " & idFormula)
         Else
            .AppendLine("  ,IdFormula = null ")
         End If
         .AppendFormat("  ,IdProductoMercosur = '{0}'", idProductoMercosur).AppendLine()
         .AppendFormat("  ,IdProductoSecretaria = '{0}'", idProductoSecretaria).AppendLine()

         .AppendLine("  ,publicarListaDePreciosClientes = " & GetStringFromBoolean(publicarListaDePreciosClientes))
         .AppendLine("  ,facturacionCantidadNegativa = " & GetStringFromBoolean(facturacionCantidadNegativa))
         .AppendLine("  ,solicitaEnvase = " & GetStringFromBoolean(solicitaEnvase))
         .AppendLine("  ,alertaDeCaja = " & GetStringFromBoolean(alertaDeCaja))
         .AppendLine("  ,esRetornable = " & GetStringFromBoolean(esRetornable))
         .AppendLine("  ,Orden = " & orden.ToString())

         If idProveedor > 0 Then
            .AppendLine("  ,IdProveedor = " & idProveedor.ToString())
         Else
            .AppendLine("  ,IdProveedor = NULL")
         End If

         .AppendLine("  ,CodigoLargoProducto = '" & codigoLargoProducto & "'")

         '-- REQ30521.- --
         If categoriaMercadoLibre <> Nothing Then
            .AppendLine("  ,idCategoriaMercadoLibre = '" & categoriaMercadoLibre & "'")
         Else
            .AppendLine("  ,idCategoriaMercadoLibre = NULL")
         End If

         If String.IsNullOrWhiteSpace(modalidadCodigoDeBarras) Or Not codigoDeBarrasConPrecio Then
            .AppendLine("  ,ModalidadCodigoDeBarras = NULL")
         Else
            .AppendLine("  ,ModalidadCodigoDeBarras = '" & modalidadCodigoDeBarras & "'")
         End If
         .AppendLine("  ,EsObservacion = " & GetStringFromBoolean(esObservacion) & ",")

         ' Chequea si las bonificaciones se actualizan al momento de la sincronización
         If unidHasta1.Modificable Then
            .AppendLine("  UnidHasta1 = " & unidHasta1.Valor.ToString() & ", ")
         End If
         If unidHasta2.Modificable Then
            .AppendLine("  UnidHasta2 = " & unidHasta2.Valor.ToString() & ", ")
         End If
         If unidHasta3.Modificable Then
            .AppendLine("  UnidHasta3 = " & unidHasta3.Valor.ToString() & ", ")
         End If
         If unidHasta4.Modificable Then
            .AppendLine("  UnidHasta4 = " & unidHasta4.Valor.ToString() & ", ")
         End If
         If unidHasta5.Modificable Then
            .AppendLine("  UnidHasta5 = " & unidHasta5.Valor.ToString() & ", ")
         End If
         If uHPorc1.Modificable Then
            .AppendLine("  UHPorc1 = " & uHPorc1.Valor.ToString() & ", ")
         End If
         If uHPorc2.Modificable Then
            .AppendLine("  UHPorc2 = " & uHPorc2.Valor.ToString() & ", ")
         End If
         If uHPorc3.Modificable Then
            .AppendLine("  UHPorc3 = " & uHPorc3.Valor.ToString() & ", ")
         End If
         If uHPorc4.Modificable Then
            .AppendLine("  UHPorc4 = " & uHPorc4.Valor.ToString() & ", ")
         End If
         If uHPorc5.Modificable Then
            .AppendLine("  UHPorc5 = " & uHPorc5.Valor.ToString() & ", ")
         End If
         If uHListaPrecios1.HasValue Then
            .AppendFormatLine("  UHListaPrecios1 = {0},", uHListaPrecios1.Value)
         Else
            .AppendFormatLine("  UHListaPrecios1 = NULL,")
         End If
         If uHListaPrecios2.HasValue Then
            .AppendFormatLine("  UHListaPrecios2 = {0},", uHListaPrecios2.Value)
         Else
            .AppendFormatLine("  UHListaPrecios2 = NULL,")
         End If
         If uHListaPrecios3.HasValue Then
            .AppendFormatLine("  UHListaPrecios3 = {0},", uHListaPrecios3.Value)
         Else
            .AppendFormatLine("  UHListaPrecios3 = NULL,")
         End If
         If uHListaPrecios4.HasValue Then
            .AppendFormatLine("  UHListaPrecios4 = {0},", uHListaPrecios4.Value)
         Else
            .AppendFormatLine("  UHListaPrecios4 = NULL,")
         End If
         If uHListaPrecios5.HasValue Then
            .AppendFormatLine("  UHListaPrecios5 = {0},", uHListaPrecios5.Value)
         Else
            .AppendFormatLine("  UHListaPrecios5 = NULL,")
         End If

         .AppendLine("  PrecioPorEmbalaje = " & GetStringFromBoolean(precioPorEmbalaje))

         If idCuentaCompras.HasValue AndAlso idCuentaCompras.Value > 0 Then
            .AppendLine("  ,IdCuentaCompras = " & idCuentaCompras.Value.ToString())
         Else
            .AppendLine("  ,IdCuentaCompras = NULL")
         End If
         If idCuentaVentas.HasValue AndAlso idCuentaVentas.Value > 0 Then
            .AppendLine("  ,IdCuentaVentas = " & idCuentaVentas.Value.ToString())
         Else
            .AppendLine("  ,IdCuentaVentas = NULL")
         End If
         .AppendLine("  ,ImporteImpuestoInterno = " & importeImpuestoInterno.ToString())
         .AppendFormat("  ,EsOferta = '{0}'", esOferta)

         If idCuentaComprasSecundaria.HasValue AndAlso idCuentaComprasSecundaria.Value > 0 Then
            .AppendLine("  ,IdCuentaComprasSecundaria = " & idCuentaComprasSecundaria.Value.ToString())
         Else
            .AppendLine("  ,IdCuentaComprasSecundaria = NULL")
         End If

         .AppendLine(" ,IncluirExpensas = " + GetStringFromBoolean(incluirExpensas))

         If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
            .AppendLine("  ,idCentroCosto = " + idCentroCosto.ToString())
         Else
            .AppendLine("  ,idCentroCosto = NULL")
         End If

         .AppendFormat("  ,ObservacionCompras = '{0}'", observacionCompras).AppendLine()
         .AppendFormat("  ,SolicitaPrecioVentaPorTamano = {0}", GetStringFromBoolean(solicitaPrecioVentaPorTamano)).AppendLine()


         .AppendFormat("  ,Espmm = {0}", espmm).AppendLine()
         .AppendFormat("  ,EspPulgadas = '{0}'", espPulgadas).AppendLine()
         .AppendFormat("  ,CodigoSAE = '{0}'", codigoSAE).AppendLine()
         If idProduccionProceso > 0 Then
            .AppendFormat("  ,IdProduccionProceso = {0}", idProduccionProceso).AppendLine()
         Else
            .AppendFormat("  ,IdProduccionProceso = NULL").AppendLine()
         End If
         If idProduccionForma > 0 Then
            .AppendFormat("  ,IdProduccionForma = {0}", idProduccionForma).AppendLine()
         Else
            .AppendFormat("  ,IdProduccionForma = NULL").AppendLine()
         End If

         .AppendFormat("  ,CalculaPreciosSegunFormula = {0}", GetStringFromBoolean(calculaPreciosSegunFormula)).AppendLine()
         If idSubSubRubro > 0 Then
            .AppendLine("  ,IdSubSubRubro = " + idSubSubRubro.ToString())
         Else
            .AppendLine("  ,IdSubSubRubro = NULL")
         End If
         .AppendFormat("  ,PorcImpuestoInterno = '{0}'", porcImpuestoInterno.ToString()).AppendLine()
         .AppendFormat("  ,OrigenPorcImpInt = '{0}'", origenPorcImpInt.ToString()).AppendLine()

         .AppendFormat("  ,EsCambiable = {0}", GetStringFromBoolean(esCambiable)).AppendLine()
         .AppendFormat("  ,EsBonificable = {0}", GetStringFromBoolean(esBonificable)).AppendLine()
         .AppendLine("  ,Alto = " & alto.ToString())
         .AppendLine("  ,Ancho = " & ancho.ToString())
         .AppendLine("  ,Largo = " & largo.ToString())

         If descRecProducto.Modificable Then
            .AppendFormat("  ,DescRecProducto = {0}", descRecProducto.Valor.ToString()).AppendLine()
         End If

         .AppendFormatLine("  ,ActualizaPreciosSucursalesAsociadas = {0}", GetStringFromBoolean(actualizaPreciosSucursalesAsociadas))

         .AppendFormatLine(" ,CalidadStatusLiberado = {0}", GetStringFromBoolean(calidadStatusLiberado))
         If calidadFechaLiberado = Nothing Then
            .AppendFormat("           ,CalidadFechaLiberado = null")
         Else
            .AppendFormat("           ,CalidadFechaLiberado = '{0}'", calidadFechaLiberado.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(calidadUserLiberado) Then
            .AppendLine("  ,CalidadUserLiberado =  NULL")
         Else
            .AppendLine("  ,CalidadUserLiberado = '" & calidadUserLiberado & "'")
         End If

         .AppendFormatLine(" ,CalidadStatusEntregado = {0}", GetStringFromBoolean(calidadStatusEntregado))
         If calidadFechaEntregado = Nothing Then
            .AppendFormat("           ,CalidadFechaEntregado = null")
         Else
            .AppendFormat("           ,CalidadFechaEntregado = '{0}'", calidadFechaEntregado.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(calidadUserEntregado) Then
            .AppendLine("  ,CalidadUserEntregado = NULL")
         Else
            .AppendLine("  ,CalidadUserEntregado = '" & calidadUserEntregado & "'")
         End If

         If calidadFechaIngreso = Nothing Then
            .AppendFormat("           ,CalidadFechaIngreso = null")
         Else
            .AppendFormat("           ,CalidadFechaIngreso = '{0}'", calidadFechaIngreso.ToString("yyyyMMdd HH:mm:ss"))
         End If

         If calidadFechaEgreso = Nothing Then
            .AppendFormat("           ,CalidadFechaEgreso = null")
         Else
            .AppendFormat("           ,CalidadFechaEgreso = '{0}'", calidadFechaEgreso.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If calidadNroCertificado > 0 Then
            .AppendFormat(" ,CalidadNroCertificado = {0}", calidadNroCertificado).AppendLine()
         Else
            .AppendFormat(" ,CalidadNroCertificado = NULL").AppendLine()
         End If
         If calidadFecCertificado = Nothing Then
            .AppendFormat("           , CalidadFecCertificado = null")
         Else
            .AppendFormat("           ,CalidadFecCertificado = '{0}'", calidadFecCertificado.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(calidadUsrCertificado) Then
            .AppendLine("  ,CalidadUsrCertificado =  NULL")
         Else
            .AppendLine("  ,CalidadUsrCertificado = '" & calidadUsrCertificado & "'")
         End If
         If String.IsNullOrEmpty(calidadObservaciones) Then
            .AppendLine("  ,CalidadObservaciones =  NULL")
         Else
            .AppendLine("  ,CalidadObservaciones = '" & calidadObservaciones & "'")
         End If

         If calidadFechaPreEnt = Nothing Then
            .AppendFormat("           ,CalidadFechaPreEnt = null")
         Else
            .AppendFormat("           ,CalidadFechaPreEnt = '{0}'", calidadFechaPreEnt.ToString("yyyyMMdd HH:mm:ss"))
         End If

         If calidadFechaEntProg = Nothing Then
            .AppendFormat("           ,CalidadFechaEntProg = null")
         Else
            .AppendFormat("           ,CalidadFechaEntProg = '{0}'", calidadFechaEntProg.ToString("yyyyMMdd HH:mm:ss"))
         End If
         .AppendLine("  ,EsComercial = " & GetStringFromBoolean(esComercial))

         .AppendFormatLine("  ,PublicarEnTiendaNube = {0}", GetStringFromBoolean(publicarEnTiendaNube))
         .AppendFormatLine("  ,PublicarEnMercadoLibre = {0}", GetStringFromBoolean(publicarEnMercadoLibre))
         .AppendFormatLine("  ,PublicarEnArborea = {0}", GetStringFromBoolean(publicarEnArborea))
         .AppendFormatLine("  ,PublicarEnGestion = {0}", GetStringFromBoolean(publicarEnGestion))
         .AppendFormatLine("  ,PublicarEnEmpresarial = {0}", GetStringFromBoolean(publicarEnEmpresarial))
         .AppendFormatLine("  ,PublicarEnBalanza = {0}", GetStringFromBoolean(publicarEnBalanza))
         .AppendFormatLine("  ,PublicarEnSincronizacionSucursal = {0}", GetStringFromBoolean(publicarEnSincronizacionSucursal))
         If String.IsNullOrEmpty(CalidadNumeroChasis) Then
            .AppendFormat("  ,CalidadNumeroChasis =  NULL")
         Else
            .AppendFormat("  ,CalidadNumeroChasis = '{0}'", CalidadNumeroChasis)
         End If
         If CalidadNroCarroceria > 0 Then
            .AppendFormat(" ,CalidadNroCarroceria = {0}", CalidadNroCarroceria).AppendLine()
         Else
            .AppendFormat(" ,CalidadNroCarroceria = NULL").AppendLine()
         End If

         If Not String.IsNullOrEmpty(idUnidadDeMedida2) Then
            .AppendFormatLine(" ,IdUnidadDeMedida2 = '{0}'", idUnidadDeMedida2)
         Else
            .AppendFormatLine(" ,IdUnidadDeMedida2 = NULL")
         End If

         .AppendFormatLine(" ,Conversion = {0}", conversion)

         If idProductoNumerico.HasValue Then
            .AppendFormatLine(" ,IdProductoNumerico = {0}", idProductoNumerico.Value)
         Else
            .AppendFormatLine(" ,IdProductoNumerico = NULL")
         End If

         .AppendFormatLine(" ,EnviarSinCargo = {0}", GetStringFromBoolean(enviarSinCargo))

         If Not String.IsNullOrEmpty(codigoProductoTiendaNube) Then
            .AppendFormatLine(" ,CodigoProductoTiendaNube = '{0}'", codigoProductoTiendaNube)
         Else
            .AppendFormatLine(" ,CodigoProductoTiendaNube = NULL")
         End If

         If Not String.IsNullOrEmpty(codigoProductoMercadoLibre) Then
            .AppendFormatLine(" ,CodigoProductoMercadoLibre = '{0}'", codigoProductoMercadoLibre)
         Else
            .AppendFormatLine(" ,CodigoProductoMercadoLibre = NULL")
         End If
         If Not String.IsNullOrEmpty(codigoProductoArborea) Then
            .AppendFormatLine(" ,CodigoProductoArborea = '{0}'", codigoProductoArborea)
         Else
            .AppendFormatLine(" ,CodigoProductoArborea = NULL")
         End If


         If Not String.IsNullOrEmpty(nombreProductoWeb) Then
            .AppendFormatLine(" ,NombreProductoWeb = '{0}'", nombreProductoWeb)
         Else
            .AppendFormatLine(" ,NombreProductoWeb = NULL")
         End If

         If Not String.IsNullOrEmpty(idProductoVariante) Then
            .AppendFormatLine(" ,IdVarianteProducto = '{0}'", idProductoVariante)
         Else
            .AppendFormatLine(" ,IdVarianteProducto = NULL")
         End If

         If idProductoTipoServicio > 0 Then
            .AppendFormat(" ,IdProductoTipoServicio = {0}", idProductoTipoServicio).AppendLine()
         Else
            .AppendFormat(" ,IdProductoTipoServicio = NULL").AppendLine()
         End If

         If Not String.IsNullOrEmpty(calidadNroDeMotor) Then
            .AppendFormatLine(" ,CalidadNroDeMotor = '{0}'", calidadNroDeMotor)
         Else
            .AppendFormatLine(" ,CalidadNroDeMotor = NULL")
         End If
         If calidadFechaEntReProg = Nothing Then
            .AppendFormat("           ,CalidadFechaEntReProg = null")
         Else
            .AppendFormat("           ,CalidadFechaEntReProg = '{0}'", calidadFechaEntReProg.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If idProductoModelo > 0 Then
            .AppendFormat(" ,IdProductoModelo = {0}", idProductoModelo).AppendLine()
         Else
            .AppendFormat(" ,IdProductoModelo = NULL").AppendLine()
         End If

         If calidadNroCertEntregado > 0 Then
            .AppendFormat(" ,CalidadNroCertEntregado = {0}", calidadNroCertEntregado).AppendLine()
         Else
            .AppendFormat(" ,CalidadNroCertEntregado = NULL").AppendLine()
         End If
         If calidadFecCertEntregado = Nothing Then
            .AppendFormat("           , CalidadFecCertEntregado = null")
         Else
            .AppendFormat("           ,CalidadFecCertEntregado = '{0}'", calidadFecCertEntregado.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(calidadUsrCertEntregado) Then
            .AppendLine("  ,CalidadUsrCertEntregado =  NULL")
         Else
            .AppendLine("  ,CalidadUsrCertEntregado = '" & calidadUsrCertEntregado & "'")
         End If
         .AppendFormatLine(" ,CalidadStatusLiberadoPDI = {0}", GetStringFromBoolean(calidadStatusLiberadoPDI))
         If calidadFechaLiberadoPDI = Nothing Then
            .AppendFormat("           ,CalidadFechaLiberadoPDI = null")
         Else
            .AppendFormat("           ,CalidadFechaLiberadoPDI = '{0}'", calidadFechaLiberadoPDI.ToString("yyyyMMdd HH:mm:ss"))
         End If
         If String.IsNullOrEmpty(calidadUserLiberadoPDI) Then
            .AppendLine("  ,CalidadUserLiberadoPDI =  NULL")
         Else
            .AppendLine("  ,CalidadUserLiberadoPDI = '" & calidadUserLiberadoPDI & "'")
         End If
         If String.IsNullOrEmpty(calidadNroCertEObs) Then
            .AppendLine("  ,CalidadNroCertEObs =  NULL")
         Else
            .AppendLine("  ,CalidadNroCertEObs = '" & calidadNroCertEObs & "'")
         End If
         If calidadNroRemito > 0 Then
            .AppendFormat(" ,CalidadNroRemito = {0}", calidadNroRemito).AppendLine()
         Else
            .AppendFormat(" ,CalidadNroRemito = NULL").AppendLine()
         End If
         .AppendFormatLine(" ,TipoBonificacion = '{0}'", tipoBonificacion.ToString())

         .AppendFormatLine(" ,EsPerceptibleIVARes53292023 = {0}", GetStringFromBoolean(esPerceptibleIVARes53292023))
         '-- REQ-38948.- -------------------------------------------------------------------------------------------
         If idProcesoProductivoDefecto.HasValue Then
            .AppendFormatLine(" ,IdProcesoProductivoDefecto = {0}", idProcesoProductivoDefecto.Value)
         Else
            .AppendFormatLine(" ,IdProcesoProductivoDefecto = NULL")
         End If
         If String.IsNullOrEmpty(controlaRealizar) Then
            .AppendLine("  ,ControlaRealizar =  NULL")
         Else
            .AppendLine("  ,ControlaRealizar = '" & controlaRealizar & "'")
         End If

         .AppendFormatLine(" ,InformeControlCalidad = {0}", GetStringFromBoolean(informeControlCalidad))
         .AppendFormatLine(" ,ValorAQL = {0}", valorAQL)

         '----------------------------------------------------------------------------------------------------------
         If nivelInspeccion <> "-1" Then
            .AppendLine("  ,NivelInspeccion = '" & nivelInspeccion & "'")
         End If

         .AppendFormatLine(" ,RealizaControlCalidad = {0}", GetStringFromBoolean(realizaControlCalidad))
         '----------------------------------------------------------------------------------------------------------

         .AppendFormatLine(" ,IdUnidadDeMedidaCompra = '{0}'", idUnidadDeMedidaCompra)
         .AppendFormatLine(" ,FactorConversionCompra =  {0} ", factorConversionCompra)
         .AppendFormatLine(" ,IdUnidadDeMedidaProduccion = '{0}'", idUnidadDeMedidaProduccion)
         .AppendFormatLine(" ,FactorConversionProduccion =  {0} ", factorConversionProduccion)

         .AppendFormatLine(" ,ComisionPorVenta  = {0}", comisionPorVenta)

         .AppendLine("  ,EsDevuelto = " & GetStringFromBoolean(esDevuelto))

         .AppendFormat(" WHERE IdProducto = '{0}'", idProducto)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Productos_U_EsCompuesto(idProducto As String, esCompuesto As Boolean, FacturacionDescontarStockComp As Boolean)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Productos")
         .AppendLine("   SET EsCompuesto = " & GetStringFromBoolean(esCompuesto))
         .AppendLine("     , DescontarStockComponentes = " & GetStringFromBoolean(FacturacionDescontarStockComp))
         .AppendFormat(" WHERE IdProducto = '{0}'", idProducto)
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Function EsCompuesto(idProducto As String, condicion As Boolean) As Boolean
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT P.EsCompuesto FROM Productos P WHERE P.IdProducto = '{0}' P.EsCompuesto = {1}", idProducto, GetStringFromBoolean(condicion))
      End With
      Return Me.GetDataTable(query.ToString()).Rows.Count > 0
   End Function


   Public Function GetProductoFormulaPorDefecto(idProducto As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT IdFormula FROM Productos")
         .AppendFormatLine("	WHERE IdProducto = '{0}'", idProducto)
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Sub Productos_U_ProcesoProductivo(idProducto As String, idProcesoProductivo As Long?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Productos")
         .AppendFormatLine("   SET IdProcesoProductivoDefecto = {0}", IIf(idProcesoProductivo.HasValue, idProcesoProductivo, "NULL"))

         .AppendFormat(" WHERE IdProducto = '{0}'", idProducto)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Productos_U_FormulaDefecto(idProducto As String, idformula As Integer, esCompuesto As Boolean?)
      'esCompueso = Nothing -> Significa no cambiar la propiedad EsCompuesto

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Productos")
         .AppendFormatLine("   SET IdFormula = {0}", GetStringFromNumber(idformula))

         If esCompuesto.HasValue Then
            .AppendFormatLine("     , EsCompuesto = {0}", GetStringFromBoolean(esCompuesto))
            'Else
            '   '-- REQ-42470.- -------------------------------------------------------------------------
            '   .AppendFormatLine("     , EsCompuesto = {0}", GetStringFromBoolean(False))
            '   .AppendFormatLine("     , DescontarStockComponentes = {0}", GetStringFromBoolean(False))
            '   '----------------------------------------------------------------------------------------
         End If

         .AppendFormat(" WHERE IdProducto = '{0}'", idProducto)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Productos_UVarios(idProducto As String,
                               idMarca As Integer,
                               idRubro As Integer,
                               idSubRubro As Integer,
                               afectaStock As Boolean,
                               activo As Boolean,
                               embalaje As Integer,
                               descrecproducto As Decimal,
                               esServicio As Boolean,
                               esDeCompras As Boolean,
                               esDeVentas As Boolean,
                               esDeCambio As Boolean,
                               esDeBonificacion As Boolean,
                               codigoDeBarrasConPrecio As Boolean,
                               modalidadCodigoDeBarras As String,
                               pagaIngresosBrutos As Boolean,
                               permiteModificarDescripcion As Boolean,
                               tamano As Decimal,
                               idUnidadDeMedida As String,
                               modificoKilos As Boolean,
                               kilos As Decimal,
                               orden As Integer,
                               moneda As Integer,
                               idProveedorHabitual As Long,
                               publicarEnWeb As Boolean,
                               publicarEnTiendaNube As Boolean,
                               publicarEnMercadoLibre As Boolean,
                               publicarEnArborea As Boolean,
                               publicarEnGestion As Boolean,
                               publicarEnEmpresarial As Boolean,
                               publicarEnBalanza As Boolean,
                               publicarEnSincronizacionSucursal As Boolean,
                               publicarListaDePreciosClientes As Boolean,
                               centroDeCostos As Entidades.ContabilidadCentroCosto,
                               lote As Boolean,
                               nroSerie As Boolean,
                               idSubSubRubro As Integer,
                               alto As Decimal,
                               modificoAlto As Boolean,
                               ancho As Decimal,
                               modificoAncho As Boolean,
                               largo As Decimal,
                               modificoLargo As Boolean,
                               esOferta As String,
                               alicuota As Decimal,
                               alicuota2 As Decimal?,
                               descontarStockComponentes As Boolean,
                               esPerceptibleIVARes53292023 As Boolean)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Productos")
         .AppendLine("   SET Activo = '" & activo.ToString() & "'")
         .AppendLine("      ,AfectaStock = '" & afectaStock.ToString() & "'")

         If idMarca > 0 Then
            .AppendLine("     ,IdMarca = " & idMarca.ToString())
         End If

         If idRubro > 0 Then
            .AppendLine("     ,IdRubro = " & idRubro.ToString())
            If idSubRubro > 0 Then
               .AppendLine("     ,IdSubRubro = " & idSubRubro.ToString())
               If idSubSubRubro > 0 Then
                  .AppendLine("     ,IdSubSubRubro = " & idSubSubRubro.ToString())
               End If
            End If
         End If

         'agrego estos campos para permitir limpiar los SubRubros y SubSubRubros en forma masiva
         If idSubRubro = 0 Then
            .Append("  ,idSubRubro = null")
         End If

         If idSubSubRubro = 0 Then
            .Append("  ,idSubSubRubro = null")
         End If

         .AppendFormatLine("      ,Alicuota = {0}", alicuota)

         If alicuota2.HasValue Then
            .AppendFormatLine("      ,Alicuota2 = {0}", alicuota2.Value)
         Else
            .AppendFormatLine("      ,Alicuota2 = Null")
         End If


         .AppendLine("      ,EsServicio = '" & esServicio.ToString() & "'")
         .AppendLine("      ,EsDeCompras = '" & esDeCompras.ToString() & "'")
         .AppendLine("      ,EsDeVentas = '" & esDeVentas.ToString() & "'")
         .AppendFormatLine("      ,EsOferta = '{0}'", esOferta)
         .AppendFormatLine("      ,EsCambiable = '{0}'", esDeCambio)
         .AppendFormatLine("      ,EsBonificable = '{0}'", esDeBonificacion)
         .AppendFormatLine("      ,CodigoDeBarrasConPrecio = {0}", GetStringFromBoolean(codigoDeBarrasConPrecio))
         .AppendFormatLine("      ,ModalidadCodigoDeBarras = '{0}'", modalidadCodigoDeBarras)
         .AppendFormatLine("      ,DescRecProducto = '{0}'", descrecproducto)
         .AppendLine("      ,PagaIngresosBrutos = '" & pagaIngresosBrutos.ToString() & "'")
         .AppendLine("      ,PermiteModificarDescripcion = '" & permiteModificarDescripcion.ToString() & "'")

         If tamano > 0 Then
            .AppendLine("     ,Tamano = " & tamano.ToString())
            .AppendLine("     ,IdUnidadDeMedida = '" & idUnidadDeMedida.ToString() & "'")
         End If

         If embalaje > 0 Then
            .AppendLine("     ,Embalaje = " & embalaje.ToString())
         End If

         If modificoKilos Then
            .AppendLine("     ,Kilos = " & kilos.ToString())
         End If

         If orden > 0 Then
            .AppendLine("     ,Orden = " & orden.ToString())
         End If

         If moneda > 0 Then
            .AppendLine("     ,IdMoneda = " & moneda.ToString())
         End If

         '@@SEBA: Repasar la Logica: Deberia... Positivo: Graba // Cero: Limpia // -1 Nada
         'Pero la pantalla no tiene la funcionalidad de "Limpiar" un proveedor habitual
         If idProveedorHabitual > 0 Then
            .AppendLine("     ,IdProveedor = " & idProveedorHabitual.ToString())
            'Else
            '    .AppendLine("     ,IdProveedor = NULL")
         End If

         .AppendFormatLine("      ,PublicarEnWeb = '{0}'", publicarEnWeb)
         .AppendFormatLine("      ,PublicarEnTiendaNube = '{0}'", publicarEnTiendaNube)
         .AppendFormatLine("      ,PublicarEnMercadoLibre = '{0}'", publicarEnMercadoLibre)
         .AppendFormatLine("      ,PublicarEnArborea = '{0}'", publicarEnArborea)
         .AppendFormatLine("      ,PublicarEnGestion = '{0}'", publicarEnGestion)
         .AppendFormatLine("      ,PublicarEnEmpresarial = '{0}'", publicarEnEmpresarial)
         .AppendFormatLine("      ,PublicarEnBalanza = '{0}'", publicarEnBalanza)
         .AppendFormatLine("      ,PublicarEnSincronizacionSucursal = '{0}'", publicarEnSincronizacionSucursal)
         .AppendFormatLine("      ,PublicarListaDePreciosClientes = '{0}'", publicarListaDePreciosClientes)

         If centroDeCostos IsNot Nothing Then
            .AppendLine("     ,IdCentroCosto = " & centroDeCostos.IdCentroCosto.ToString())
         End If

         .AppendLine("      ,Lote = '" & lote.ToString() & "'")
         .AppendLine("      ,NroSerie = '" & nroSerie.ToString() & "'")
         .AppendFormatLine("      ,DescontarStockComponentes = {0}", GetStringFromBoolean(descontarStockComponentes))


         If modificoAlto Then
            .AppendFormat("      ,Alto = {0}", alto)
         End If
         If modificoAncho Then
            .AppendFormat("      ,Ancho = {0}", ancho)
         End If
         If modificoLargo Then
            .AppendFormat("      ,Largo = {0}", largo)
         End If

         .AppendFormatLine("      ,EsPerceptibleIVARes53292023 = {0}", GetStringFromBoolean(esPerceptibleIVARes53292023))

         .AppendLine(" WHERE IdProducto = '" & idProducto & "'")

      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub Productos_D(idProducto As String, idSucursal As Int32)

      'Primero Borro los Hijos que no son movimientos, pero si fue utilizado da error. Que pasaria en las sucursales!!??

      Dim sqlPP As ProductosProveedores = New ProductosProveedores(Me._da)

      sqlPP.ProductosProveedores_DPorProducto(idProducto)


      'La baja de productos deberia 
      Dim sqlHP As HistorialPrecios = New HistorialPrecios(Me._da)

      sqlHP.HistorialPrecios_D(idProducto, idSucursal)

      Dim sqlPSP As ProductosSucursalesPrecios = New ProductosSucursalesPrecios(Me._da)

      sqlPSP.ProductosSucursalesPrecios_D(idProducto, idSucursal, -1)

      Dim sqlPU = New ProductosUbicaciones(Me._da)
      sqlPU.ProductosUbicaciones_D(idProducto, idSucursal, 0, 0)

      Dim sqlPD = New ProductosDepositos(Me._da)
      sqlPD.ProductosDepositos_D(idProducto, idSucursal, 0)

      Dim sqlPS As ProductosSucursales = New ProductosSucursales(Me._da)
      sqlPS.ProductosSucursales_D(idProducto, idSucursal)

      Dim sqlPC As ProductosConceptos = New ProductosConceptos(Me._da)

      sqlPC.ProductosConceptos_D(idProducto)

      '----------------------------

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("DELETE FROM Productos ")
         .Append(" WHERE IdProducto = '" & idProducto & "'")
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Function Productos_GA_Ids(idProveedor As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT P.IdProducto")
         .AppendFormatLine("  FROM Productos P")
         If idProveedor > 0 Then
            .AppendFormatLine(" INNER JOIN ProductosProveedores PP ON PP.IdProducto = P.IdProducto")
         End If
         .AppendFormatLine(" WHERE 1 = 1")
         If idProveedor > 0 Then
            .AppendFormatLine("   AND PP.IdProveedor = {0}", idProveedor)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function Productos_GA() As DataTable

      Return Productos_GA(False)

   End Function

   Public Function Productos_GProductosCalidad() As DataTable

      Dim myQuery = New StringBuilder()
      Dim consultaFoto As Boolean = False

      Dim strAnchoIdProducto As String
      strAnchoIdProducto = Me.GetAnchoCampo("Productos", "IdProducto").ToString()

      With myQuery
         .AppendLine("SELECT RIGHT(REPLICATE(' '," & strAnchoIdProducto & ") + P.IdProducto," & strAnchoIdProducto & ") as IdProducto")
         .AppendLine(" ,P.NombreProducto")
         .AppendLine(" ,C.CodigoCliente")
         .AppendLine(" ,C.NombreCliente")
         .AppendLine(" ,C.NombreDeFantasia")
         .AppendLine(" , P.CalidadStatusLiberado ")
         .AppendLine(" , P.CalidadFechaLiberado")
         .AppendLine(" , P.CalidadUserLiberado ")
         .AppendLine(" , P.CalidadStatusEntregado")
         .AppendLine(" , P.CalidadFechaEntregado")
         .AppendLine(" , P.CalidadUserEntregado")
         .AppendLine(" , P.CalidadFechaIngreso")
         .AppendLine(" , P.CalidadFechaEgreso")
         .AppendLine(" , P.CalidadNroCertificado")
         .AppendLine(" , P.CalidadFecCertificado")
         .AppendLine(" , P.CalidadUsrCertificado")
         .AppendLine(" , P.CalidadObservaciones")
         .AppendLine(" , P.CalidadFechaPreEnt")
         .AppendLine(" , P.CalidadFechaEntProg ")
         .AppendLine(" ,PS.Ubicacion")
         .AppendLine(" ,P.CalidadNumeroChasis")
         .AppendLine(" ,P.CalidadNroCarroceria")
         .AppendLine(" ,P.IdProductoTipoServicio")
         .AppendLine(" ,CPTS.NombreProductoTipoServicio")
         .AppendLine(" ,P.CalidadNroDeMotor")
         .AppendLine(" , P.CalidadFechaEntReProg ")
         .AppendLine(" , P.IdProductoModelo ")
         .AppendLine(" , CPM.NombreProductoModelo")
         .AppendLine(" , P.CalidadNroCertEntregado")
         .AppendLine(" , P.CalidadFecCertEntregado")
         .AppendLine(" , P.CalidadUsrCertEntregado")
         .AppendLine(" , P.CalidadStatusLiberadoPDI ")
         .AppendLine(" , P.CalidadFechaLiberadoPDI")
         .AppendLine(" , P.CalidadUserLiberadoPDI ")
         .AppendLine(" , P.CalidadNroCertEObs")
         .AppendLine(" , P.CalidadNroRemito")
         .AppendLine(" FROM Productos P ")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente ")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & Entidades.Usuario.Actual.Sucursal.IdSucursal.ToString())
         .AppendLine(" LEFT JOIN CalidadProductosTiposServicios CPTS ON CPTS.IdProductoTipoServicio = P.IdProductoTipoServicio")
         .AppendLine(" LEFT JOIN CalidadProductosModelos CPM ON CPM.IdProductoModelo = P.IdProductoModelo")
         .AppendLine(" WHERE 1 = 1 ")
         .AppendLine(" AND P.IdProductoTipoServicio < 3")
         .AppendLine(" ORDER BY P.NombreProducto  ")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function Productos_GProductosCalidadSinReparaciones() As DataTable

      Dim myQuery = New StringBuilder()
      Dim consultaFoto As Boolean = False

      Dim strAnchoIdProducto As String
      strAnchoIdProducto = Me.GetAnchoCampo("Productos", "IdProducto").ToString()

      With myQuery
         .AppendLine("SELECT P.IdProducto")
         .AppendLine(" ,P.NombreProducto")
         .AppendLine(" ,C.CodigoCliente")
         .AppendLine(" ,C.NombreCliente")
         .AppendLine(" ,C.NombreDeFantasia")
         .AppendLine(" , P.CalidadStatusLiberado ")
         .AppendLine(" , P.CalidadFechaLiberado")
         .AppendLine(" , P.CalidadUserLiberado ")
         .AppendLine(" , P.CalidadStatusEntregado")
         .AppendLine(" , P.CalidadFechaEntregado")
         .AppendLine(" , P.CalidadUserEntregado")
         .AppendLine(" , P.CalidadFechaIngreso")
         .AppendLine(" , P.CalidadFechaEgreso")
         .AppendLine(" , P.CalidadNroCertificado")
         .AppendLine(" , P.CalidadFecCertificado")
         .AppendLine(" , P.CalidadUsrCertificado")
         .AppendLine(" , P.CalidadObservaciones")
         .AppendLine(" , P.CalidadFechaPreEnt")
         .AppendLine(" , P.CalidadFechaEntProg ")
         .AppendLine(" ,PS.Ubicacion")
         .AppendLine(" ,P.CalidadNumeroChasis")
         .AppendLine(" ,P.CalidadNroCarroceria")
         .AppendLine(" ,P.IdProductoTipoServicio")
         .AppendLine(" ,CPTS.NombreProductoTipoServicio")
         .AppendLine(" ,P.CalidadNroDeMotor")
         .AppendLine(" , P.CalidadFechaEntReProg ")
         .AppendLine(" , P.IdProductoModelo ")
         .AppendLine(" , CPM.NombreProductoModelo")
         .AppendLine(" , P.CalidadNroCertEntregado")
         .AppendLine(" , P.CalidadFecCertEntregado")
         .AppendLine(" , P.CalidadUsrCertEntregado")
         .AppendLine(" , P.CalidadStatusLiberadoPDI ")
         .AppendLine(" , P.CalidadFechaLiberadoPDI")
         .AppendLine(" , P.CalidadUserLiberadoPDI ")
         .AppendLine(" , P.CalidadNroCertEObs")
         .AppendLine(" , P.CalidadNroRemito")
         .AppendLine(" , M.IdProductoModeloTipo")
         .AppendLine(" , CMT.NombreProductoModeloTipo")
         .AppendLine(" FROM Productos P ")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente ")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & Entidades.Usuario.Actual.Sucursal.IdSucursal.ToString())
         .AppendLine(" LEFT JOIN CalidadProductosTiposServicios CPTS ON CPTS.IdProductoTipoServicio = P.IdProductoTipoServicio")
         .AppendLine(" LEFT JOIN CalidadProductosModelos CPM ON CPM.IdProductoModelo = P.IdProductoModelo")
         .AppendLine("  LEFT JOIN CalidadProductosModelos M ON M.IdProductoModelo = P.IdProductoModelo ")
         .AppendLine("  LEFT JOIN CalidadProductosModelosTipos CMT ON CMT.IdProductoModeloTipo = M.IdProductoModeloTipo")
         .AppendLine(" WHERE 1 = 1 ")
         .AppendLine(" AND P.IdProductoTipoServicio = 1")
         .AppendLine(" AND P.IdProducto not like '%R%'")
         .AppendLine(" ORDER BY P.NombreProducto  ")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function Productos_GChasisCalidad() As DataTable

      Dim myQuery = New StringBuilder()
      Dim consultaFoto As Boolean = False

      Dim strAnchoIdProducto As String
      strAnchoIdProducto = Me.GetAnchoCampo("Productos", "IdProducto").ToString()

      With myQuery
         .AppendLine("SELECT RIGHT(REPLICATE(' '," & strAnchoIdProducto & ") + P.IdProducto," & strAnchoIdProducto & ") as IdProducto")
         .AppendLine(" ,P.NombreProducto")
         '.AppendLine(" ,C.CodigoCliente")
         '.AppendLine(" ,C.NombreCliente")
         '.AppendLine(" ,C.NombreDeFantasia")
         '.AppendLine(" , P.CalidadStatusLiberado ")
         '.AppendLine(" , P.CalidadFechaLiberado")
         '.AppendLine(" , P.CalidadUserLiberado ")
         '.AppendLine(" , P.CalidadStatusEntregado")
         '.AppendLine(" , P.CalidadFechaEntregado")
         '.AppendLine(" , P.CalidadUserEntregado")
         '.AppendLine(" , P.CalidadFechaIngreso")
         '.AppendLine(" , P.CalidadFechaEgreso")
         '.AppendLine(" , P.CalidadNroCertificado")
         '.AppendLine(" , P.CalidadFecCertificado")
         '.AppendLine(" , P.CalidadUsrCertificado")
         .AppendLine(" , P.CalidadObservaciones")
         '.AppendLine(" , P.CalidadFechaPreEnt")
         '.AppendLine(" , P.CalidadFechaEntProg ")
         '.AppendLine(" ,PS.Ubicacion")
         .AppendLine(" ,P.CalidadNumeroChasis")
         .AppendLine(" ,P.CalidadNroCarroceria")
         .AppendLine(" ,P.IdProductoTipoServicio")
         .AppendLine(" ,CPTS.NombreProductoTipoServicio")
         .AppendLine(" ,P.CalidadNroDeMotor")
         '.AppendLine(" , P.CalidadFechaEntReProg ")
         .AppendLine(" , P.IdProductoModelo ")
         .AppendLine(" , CPM.NombreProductoModelo")
         '.AppendLine(" , P.CalidadNroCertEntregado")
         '.AppendLine(" , P.CalidadFecCertEntregado")
         '.AppendLine(" , P.CalidadUsrCertEntregado")
         '.AppendLine(" , P.CalidadStatusLiberadoPDI ")
         '.AppendLine(" , P.CalidadFechaLiberadoPDI")
         '.AppendLine(" , P.CalidadUserLiberadoPDI ")
         '.AppendLine(" , P.CalidadNroCertEObs")
         '.AppendLine(" , P.CalidadNroRemito")
         .AppendLine(" FROM Productos P ")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente ")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & Entidades.Usuario.Actual.Sucursal.IdSucursal.ToString())
         .AppendLine(" LEFT JOIN CalidadProductosTiposServicios CPTS ON CPTS.IdProductoTipoServicio = P.IdProductoTipoServicio")
         .AppendLine(" LEFT JOIN CalidadProductosModelos CPM ON CPM.IdProductoModelo = P.IdProductoModelo")
         .AppendLine(" WHERE 1 = 1 ")
         .AppendLine(" AND P.IdProductoTipoServicio = 3")
         .AppendLine(" ORDER BY P.NombreProducto  ")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function
   Public Function Productos_G1(idProducto As String, activo As Entidades.Publicos.SiNoTodos) As DataTable
      Dim myQuery = New StringBuilder()
      SelectTexto(myQuery, incluirFoto:=False, espaciosID:=True, auditoria:=False)
      With myQuery
         .AppendFormatLine(" WHERE P.IdProducto = '{0}'", idProducto)
         If activo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND P.Activo = {0}", GetStringFromBoolean(activo = Entidades.Publicos.SiNoTodos.SI))
         End If
         .AppendFormatLine(" ORDER BY P.NombreProducto  ")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function Productos_G1Calidad(idProducto As String) As DataTable

      Dim myQuery = New StringBuilder()
      Dim consultaFoto As Boolean = False

      SelectTexto(myQuery, consultaFoto, espaciosID:=True, auditoria:=False)

      With myQuery
         .AppendLine(" WHERE 1 = 1 ")
         .AppendFormat("   AND P.IdProducto = '{0}' OR P.CalidadNroCarroceria = '{0}' ", idProducto).AppendLine()
         .AppendLine(" ORDER BY P.NombreProducto  ")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function Productos_G1TiendaWeb(idProductoTiendaWeb As String, idTiendaWeb As String) As DataTable

      Dim myQuery = New StringBuilder()
      Dim consultaFoto As Boolean = False

      SelectTexto(myQuery, consultaFoto, espaciosID:=True, auditoria:=False)

      With myQuery
         .AppendLine(" WHERE 1 = 1 ")
         .AppendFormat("   AND P.CodigoProducto{1} = '{0}' ", idProductoTiendaWeb, idTiendaWeb).AppendLine()
         .AppendLine(" ORDER BY P.NombreProducto  ")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function Productos_G_PorNombre(nombreProducto As String) As DataTable

      Dim myQuery = New StringBuilder()
      Dim consultaFoto As Boolean = False

      SelectTexto(myQuery, consultaFoto, espaciosID:=True, auditoria:=False)

      With myQuery
         .AppendFormat(" WHERE P.NombreProducto = '{0}' ", nombreProducto).AppendLine()
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function Productos_G_PorCodigoBarra(CodigoBarra As String) As DataTable

      Dim myQuery = New StringBuilder()
      Dim consultaFoto As Boolean = False

      SelectTexto(myQuery, consultaFoto, espaciosID:=True, auditoria:=False)

      With myQuery
         .AppendFormat(" WHERE P.CodigoDeBarras = '{0}' ", CodigoBarra).AppendLine()
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function
   Public Function Productos_GA(soloObservacion As Boolean) As DataTable
      Return Productos_GA(activos:=Entidades.Publicos.SiNoTodos.TODOS, soloObservacion, Nothing, Nothing)
   End Function

   Public Function Productos_GA(fechaActualizacionDesde As Date?, publicarEnWeb As Entidades.Filtros.ProductosPublicarEnFiltros) As DataTable
      Return Productos_GA(activos:=Entidades.Publicos.SiNoTodos.TODOS, soloObservacion:=False, fechaActualizacionDesde, publicarEnWeb)
   End Function

   Public Function Productos_GA(activos As Entidades.Publicos.SiNoTodos) As DataTable
      Return Productos_GA(activos, soloObservacion:=False, fechaActualizacionDesde:=Nothing, publicarEn:=Nothing)
   End Function

   Public Function Productos_GA(activos As Entidades.Publicos.SiNoTodos, soloObservacion As Boolean, fechaActualizacionDesde As Date?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As DataTable

      Dim myQuery = New StringBuilder()
      Dim consultaFoto As Boolean = False

      SelectTexto(myQuery, consultaFoto, espaciosID:=True, auditoria:=False)

      With myQuery

         .AppendLine(" WHERE 1 = 1 ")
         If soloObservacion Then
            .AppendFormat("   AND P.EsObservacion = 1")
         End If
         If fechaActualizacionDesde.HasValue Then
            .AppendFormat("   AND P.{0} > '{1}'",
                            Entidades.Producto.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True, True)).AppendLine()
         End If

         ProductoPublicarEn(myQuery, publicarEn, "P")
         'If publicarEnWeb <> Entidades.Publicos.SiNoTodos.TODOS Then
         '   .AppendFormat("   AND P.{0} = {1}",
         '                   Entidades.Producto.Columnas.PublicarEnWeb.ToString(), GetStringFromBoolean(publicarEnWeb = Entidades.Publicos.SiNoTodos.SI)).AppendLine()
         'End If

         If activos <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND P.{0} = {1}", Entidades.Producto.Columnas.Activo.ToString(), GetStringFromBoolean(activos = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendLine(" ORDER BY P.NombreProducto  ")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function


   Public Sub SelectTexto(stb As StringBuilder, incluirFoto As Boolean, espaciosID As Boolean, auditoria As Boolean)
      Dim strAnchoIdProducto = GetAnchoCampo("Productos", "IdProducto")
      With stb
         If espaciosID Then
            .AppendFormatLine("SELECT RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto", strAnchoIdProducto)
         Else
            .AppendLine("SELECT P.IdProducto")
         End If

         If auditoria Then
            .AppendLine("      ,' ' AS Modificado")
            .AppendLine("      ,P.FechaAuditoria")
            .AppendLine("      ,P.OperacionAuditoria")
            .AppendLine("      ,P.UsuarioAuditoria")
         End If

         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,P.Tamano")
         .AppendLine("      ,P.IdUnidadDeMedida")
         .AppendLine("      ,P.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,P.IdModelo")
         .AppendLine("      ,MO.NombreModelo")
         .AppendLine("      ,P.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,P.IdSubRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,P.IdTipoImpuesto")
         .AppendLine("      ,P.Alicuota")
         .AppendLine("      ,P.Alicuota2")
         .AppendLine("      ,PS.Ubicacion")
         .AppendLine("      ,P.AfectaStock")

         'Solo la busco en el GET1 porque ahi puedo necesitarlo, en todo lo demas NO.
         'Lentifica terriblemente la consulta.
         .AppendLine("      ,CONVERT(BIT, (CASE WHEN P.Foto is null THEN 0 ELSE 1 END)) AS TieneFoto")
         If incluirFoto Then
            .AppendLine("      ,P.Foto")
         Else
            .AppendLine("      ,NULL AS Foto")
         End If
         .AppendLine("      ,P.MesesGarantia")
         .AppendLine("      ,P.PermiteModificarDescripcion")
         .AppendLine("      ,P.Lote")
         .AppendLine("      ,P.NroSerie")
         .AppendLine("      ,P.CodigoDeBarras")
         .AppendLine("      ,P.CodigoDeBarrasConPrecio")
         .AppendLine("      ,P.EsServicio")
         .AppendLine("      ,P.PublicarEnWeb")
         .AppendLine("      ,P.PublicarEnTiendaNube")
         .AppendLine("      ,P.PublicarEnMercadoLibre")
         .AppendLine("      ,P.PublicarEnArborea")
         .AppendLine("      ,P.PublicarListaDePreciosClientes")
         .AppendLine("      ,P.PublicarEnGestion")
         .AppendLine("      ,P.PublicarEnEmpresarial")
         .AppendLine("      ,P.PublicarEnBalanza")
         .AppendLine("      ,P.PublicarEnSincronizacionSucursal")

         .AppendLine("      ,P.Observacion")
         .AppendLine("      ,P.EsCompuesto")
         .AppendLine("      ,P.DescontarStockComponentes")
         .AppendLine("      ,P.EsDeCompras")
         .AppendLine("      ,P.EsDeVentas")
         .AppendLine("      ,P.IdMoneda")
         .AppendLine("      ,Mn.NombreMoneda")

         .AppendLine("      ,P.EsAlquilable")
         .AppendLine("      ,P.EquipoMarca")
         .AppendLine("      ,P.EquipoModelo")
         .AppendLine("      ,P.NumeroSerie")
         .AppendLine("      ,P.CaractSII")
         .AppendLine("      ,P.Anio")

         .AppendLine("      ,P.Activo")
         .AppendLine("      ,P.PagaIngresosBrutos")
         .AppendLine("      ,P.Embalaje")
         .AppendLine("      ,P.Kilos")
         .AppendLine("      ,P.KilosEsUMCompras")
         .AppendLine("      ,P.IdFormula")
         .AppendLine("      ,P.IdProductoMercosur")
         .AppendLine("      ,P.IdProductoSecretaria")
         .AppendLine("      ,P.FacturacionCantidadNegativa")
         .AppendLine("      ,P.SolicitaEnvase")
         .AppendLine("      ,P.AlertaDeCaja")
         .AppendLine("      ,P.nombreCorto")
         .AppendLine("      ,P.EsRetornable")
         .AppendLine("      ,P.Orden")
         .AppendLine("      ,P.CodigoLargoProducto")
         .AppendLine("      ,P.IdProveedor")
         .AppendLine("      ,PR.CodigoProveedor")
         .AppendLine("      ,PR.NombreProveedor")
         .AppendLine("      ,PP.CodigoProductoProveedor")
         .AppendLine("      ,P.ModalidadCodigoDeBarras")
         .AppendLine("      ,P.EsObservacion")
         .AppendLine("      ,P.UnidHasta1")
         .AppendLine("      ,P.UHPorc1")
         .AppendLine("      ,P.UnidHasta2")
         .AppendLine("      ,P.UHPorc2")
         .AppendLine("      ,P.UnidHasta3")
         .AppendLine("      ,P.UHPorc3")
         .AppendLine("      ,P.UnidHasta4")
         .AppendLine("      ,P.UHPorc4")
         .AppendLine("      ,P.UnidHasta5")
         .AppendLine("      ,P.UHPorc5")
         .AppendLine("      ,P.UHListaPrecios1")
         .AppendLine("      ,P.UHListaPrecios2")
         .AppendLine("      ,P.UHListaPrecios3")
         .AppendLine("      ,P.UHListaPrecios4")
         .AppendLine("      ,P.UHListaPrecios5")
         .AppendLine("      ,LP1.NombreListaPrecios NombreListaPrecios_1")
         .AppendLine("      ,LP2.NombreListaPrecios NombreListaPrecios_2")
         .AppendLine("      ,LP3.NombreListaPrecios NombreListaPrecios_3")
         .AppendLine("      ,LP4.NombreListaPrecios NombreListaPrecios_4")
         .AppendLine("      ,LP5.NombreListaPrecios NombreListaPrecios_5")
         .AppendLine("      ,P.PrecioPorEmbalaje")

         'Contabilidad
         .AppendLine("      ,P.IdCuentaCompras")
         .AppendLine("      ,CCC.NombreCuenta AS NombreCuentaCompras")
         .AppendLine("      ,P.IdCuentaVentas")
         .AppendLine("      ,CCV.NombreCuenta AS NombreCuentaVentas")
         .AppendLine("      ,P.IdCuentaComprasSecundaria")
         .AppendLine("      ,CCCS.NombreCuenta AS NombreCuentaComprasSecundaria")
         .AppendLine("      ,P.IdCentroCosto")
         .AppendLine("      ,CECO.NombreCentroCosto")

         .AppendLine("      ,P.ImporteImpuestoInterno")
         .AppendLine("      ,P.EsOferta")
         .AppendLine("      ,P.IncluirExpensas")
         .AppendLine("      ,PS.FechaActualizacion")

         .AppendLine("      ,PS.Stock AS StockActual")
         .AppendLine("      ,PS.StockMinimo")
         .AppendLine("      ,PS.PuntoDePedido")
         .AppendLine("      ,PS.StockMaximo")

         .AppendLine("      ,P.ObservacionCompras")
         .AppendLine("      ,P.SolicitaPrecioVentaPorTamano")

         .AppendLine("      ,P.Espmm")
         .AppendLine("      ,P.EspPulgadas")
         .AppendLine("      ,P.CodigoSAE")
         .AppendLine("      ,P.IdProduccionProceso")
         .AppendLine("      ,P.IdProduccionForma")

         .AppendLine("      ,P.NivelInspeccion")
         .AppendLine("      ,P.RealizaControlCalidad")

         .AppendLine("      ,P.IdUnidadDeMedidaCompra")
         .AppendLine("      ,P.IdUnidadDeMedidaProduccion")
         .AppendLine("      ,P.FactorConversionCompra")
         .AppendLine("      ,P.FactorConversionProduccion")

         .AppendLine("      ,P.PorcImpuestoInterno")
         .AppendLine("      ,P.OrigenPorcImpInt")

         .AppendLine("      ,PRP.NombreProduccionProceso")
         .AppendLine("      ,PRF.NombreProduccionForma")

         .AppendLine("      ,P.CalculaPreciosSegunFormula")
         .AppendLine("      ,P.IdSubSubRubro")
         .AppendLine("      ,SSR.NombreSubSubRubro")

         .AppendLine("      ,P.EsCambiable")
         .AppendLine("      ,P.EsBonificable")
         .AppendLine("      ,P.EsDevuelto")

         .AppendFormat("      ,P.{0}", Entidades.Producto.Columnas.FechaActualizacionWeb.ToString()).AppendLine()
         .AppendLine("      ,P.Alto")
         .AppendLine("      ,P.Ancho")
         .AppendLine("      ,P.Largo")
         .AppendLine("      ,P.DescRecProducto")
         .AppendLine("      ,P.ActualizaPreciosSucursalesAsociadas")
         .AppendLine(" , P.CalidadStatusLiberado ")
         .AppendLine(" , P.CalidadFechaLiberado")
         .AppendLine(" , P.CalidadUserLiberado ")
         .AppendLine(" , P.CalidadStatusEntregado")
         .AppendLine(" , P.CalidadFechaEntregado")
         .AppendLine(" , P.CalidadUserEntregado")
         .AppendLine(" , P.CalidadFechaIngreso")
         .AppendLine(" , P.CalidadFechaEgreso")
         .AppendLine(" , P.CalidadNroCertificado")
         .AppendLine(" , P.CalidadFecCertificado")
         .AppendLine(" , P.CalidadUsrCertificado")
         .AppendLine(" , P.CalidadObservaciones")
         .AppendLine(" , P.CalidadFechaPreEnt")
         .AppendLine(" , P.CalidadFechaEntProg ")
         .AppendLine(" , P.EsComercial ")
         .AppendLine(" , P.CalidadNumeroChasis")
         .AppendLine(" , P.CalidadNroCarroceria")
         .AppendLine(" , P.IdUnidadDeMedida2")
         .AppendLine(" , P.Conversion")
         .AppendLine(" , P.IdProductoNumerico")
         .AppendLine(" , P.EnviarSinCargo")
         .AppendLine(" , P.CodigoProductoTiendaNube")
         '-- REQ-30521.- --
         .AppendLine(" , P.CodigoProductoMercadoLibre")
         .AppendLine(" , P.idCategoriaMercadoLibre ")
         .AppendLine(" , CML.NombreCategoria  ")
         '-----------------
         '-- REQ-31619.- --
         .AppendLine(" , P.NombreProductoWeb")
         '-----------------
         .AppendLine(" , P.IdVarianteProducto")
         .AppendLine(" , P.IdProductoTipoServicio")
         .AppendLine(" , P.CalidadNroDeMotor")
         .AppendLine(" , P.CalidadFechaEntReProg ")
         .AppendLine(" , P.IdProductoModelo ")
         .AppendLine(" , P.TipoBonificacion ")
         .AppendLine(" , CPM.NombreProductoModelo ")
         .AppendLine(" , P.CalidadNroCertEntregado")
         .AppendLine(" , P.CalidadFecCertEntregado")
         .AppendLine(" , P.CalidadUsrCertEntregado")
         .AppendLine(" , P.CalidadStatusLiberadoPDI ")
         .AppendLine(" , P.CalidadFechaLiberadoPDI")
         .AppendLine(" , P.CalidadUserLiberadoPDI ")
         .AppendLine(" , P.CalidadNroCertEObs ")
         .AppendLine(" , P.CalidadNroRemito")
         .AppendLine(" , P.CodigoProductoArborea")
         .AppendLine(" , P.EsPerceptibleIVARes53292023")

         .AppendLine(" , P.IdProcesoProductivoDefecto")
         .AppendLine(" , P.ControlaRealizar")
         .AppendLine(" , P.InformeControlCalidad")
         .AppendLine(" , P.ValorAQL")
         .AppendLine("  ,P.ComisionPorVenta")
         .AppendFormatLine(" FROM {0}Productos P ", If(auditoria, "Auditoria", ""))
         .AppendLine(" LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .AppendLine(" LEFT JOIN Rubros R ON P.IdRubro = R.IdRubro ")
         .AppendLine(" LEFT OUTER JOIN Modelos MO ON P.IdModelo = MO.IdModelo")
         .AppendLine(" LEFT OUTER JOIN SubRubros SR ON P.IdRubro = SR.IdRubro AND P.IdSubRubro = SR.IdSubRubro")
         .AppendLine(" LEFT OUTER JOIN SubSubRubros SSR ON P.IdSubRubro = SSR.IdSubRubro AND P.IdSubSubRubro = SSR.IdSubSubRubro")
         .AppendLine(" LEFT JOIN Monedas Mn ON P.IdMoneda = Mn.IdMoneda ")
         .AppendLine(" LEFT JOIN Proveedores PR ON PR.IdProveedor = P.IdProveedor ")
         .AppendLine(" LEFT JOIN ProductosProveedores PP ON P.IdProducto = PP.IdProducto AND PP.IdProveedor = P.IdProveedor")
         .AppendLine(" LEFT JOIN ContabilidadCuentas CCC ON CCC.IdCuenta = P.IdCuentaCompras")
         .AppendLine(" LEFT JOIN ContabilidadCuentas CCV ON CCV.IdCuenta = P.IdCuentaVentas")
         .AppendLine(" LEFT JOIN ContabilidadCuentas CCCS ON CCCS.IdCuenta = P.IdCuentaComprasSecundaria")
         .AppendLine(" LEFT JOIN ContabilidadCentrosCostos CECO ON CECO.IdCentroCosto = P.IdCentroCosto")

         '-- REQ-30521.- --
         .AppendLine(" LEFT JOIN CategoriasMercadoLibre CML ON CML.IdCategoria = P.IdCategoriaMercadoLibre")
         '-----------------

         .AppendLine(" LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = P.IdProduccionForma")
         .AppendLine(" LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = P.IdProduccionProceso")

         .AppendFormatLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = {0}", actual.Sucursal.IdSucursal)
         .AppendLine(" LEFT JOIN CalidadProductosModelos CPM ON CPM.IdProductoModelo = P.IdProductoModelo")
         .AppendLine(" LEFT JOIN ListasDePrecios LP1 ON P.UHListaPrecios1 = LP1.IdListaPrecios")
         .AppendLine(" LEFT JOIN ListasDePrecios LP2 ON P.UHListaPrecios2 = LP2.IdListaPrecios")
         .AppendLine(" LEFT JOIN ListasDePrecios LP3 ON P.UHListaPrecios3 = LP3.IdListaPrecios")
         .AppendLine(" LEFT JOIN ListasDePrecios LP4 ON P.UHListaPrecios4 = LP4.IdListaPrecios")
         .AppendLine(" LEFT JOIN ListasDePrecios LP5 ON P.UHListaPrecios5 = LP5.IdListaPrecios")
      End With

   End Sub

   Public Function ProductosGrillaFiltroMarcaRubroSubRubro(idsucursal As Integer,
                                                           nombreproducto As String,
                                                           idmarca As Integer,
                                                           idrubro As Integer,
                                                           idSubRubro As Integer,
                                                           idProducto As String,
                                                           idListaDePrecios As Integer,
                                                           blnPreciosConIVA As Boolean) As DataTable

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("SELECT P.IdProducto ")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,P.Tamano")
         .AppendLine("      ,P.IdUnidadDeMedida")
         .AppendLine("      ,PS.PrecioCosto")

         If blnPreciosConIVA Then
            .AppendLine("      ,ROUND((PS.PrecioCosto - P.ImporteImpuestoInterno) / (1+(P.Alicuota/100)), 2) AS PrecioCostoSinIVA")
            .AppendLine("      ,PS.PrecioCosto AS PrecioCostoConIVA")
         Else
            .AppendLine("      ,PS.PrecioCosto AS PrecioCostoSinIVA")
            .AppendLine("      ,ROUND((PS.PrecioCosto * (1+(P.Alicuota/100))) + P.ImporteImpuestoInterno, 2) AS PrecioCostoConIVA")
         End If

         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,Mo.NombreMoneda")
         .AppendLine("      ,Mo.FactorConversion")
         .AppendLine("      ,Mo.Simbolo")

         .AppendLine("      ,PSP.PrecioVenta")

         If blnPreciosConIVA Then
            .AppendLine("      ,ROUND((PSP.PrecioVenta - P.ImporteImpuestoInterno) / (1+(P.Alicuota/100)), 2) AS PrecioVentaSinIVA")
            .AppendLine("      ,PSP.PrecioVenta AS PrecioVentaConIVA")
         Else
            .AppendLine("      ,PSP.PrecioVenta AS PrecioVentaSinIVA")
            .AppendLine("      ,ROUND((PSP.PrecioVenta * (1+(P.Alicuota/100))) + P.ImporteImpuestoInterno, 2) AS PrecioVentaConIVA")
         End If

         .AppendLine("      ,P.EsCompuesto")
         .AppendLine("      ,P.IdFormula")
         .AppendLine("      ,PF.NombreFormula")
         .AppendLine("      ,P.IdUnidadDeMedidaProduccion")
         .AppendLine("      ,P.FactorConversionProduccion")

         .AppendLine("  FROM Productos P")
         .AppendLine("  LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendLine("  LEFT JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendLine("  LEFT JOIN Monedas Mo ON P.IdMoneda = Mo.IdMoneda")
         .AppendLine("  LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto")
         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal AND PSP.IdListaPrecios = " & idListaDePrecios.ToString())
         .AppendLine("  LEFT JOIN ProductosFormulas PF ON PF.IdProducto = P.IdProducto AND PF.IdFormula = P.IdFormula")
         .AppendLine(" WHERE PS.IdSucursal = " & idsucursal.ToString())
         If Not String.IsNullOrEmpty(nombreproducto) Then
            Dim Palabras() As String = nombreproducto.Split(" "c)
            For Each Palabra As String In Palabras
               .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
            Next
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND P.IdProducto = '{0}'", idProducto)
         End If
         If idmarca > 0 Then
            .AppendLine("   AND P.IdMArca = " & idmarca.ToString())
         End If
         If idrubro > 0 Then
            .AppendLine("   AND P.IdRubro = " & idrubro.ToString())
         End If
         If idSubRubro > 0 Then
            .AppendLine("   AND P.IdSubrubro = " & idSubRubro.ToString())
         End If

         'If Rubros.Count > 0 Then
         '   .Append(" AND P.IdRubro IN (")
         '   For Each pr As Entidades.Rubro In Rubros
         '      .AppendFormat(" {0},", pr.IdRubro)
         '   Next
         '   .Remove(.Length - 1, 1)
         '   .Append(")")
         'End If


      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ProductosGrillaFiltroMultipleMarcaRubroSubRubro(idsucursal As Integer,
                                                           nombreproducto As String,
                                                            marcas As Entidades.Marca(),
                                                           rubros As Entidades.Rubro(),
                                                           idSubRubro As Integer,
                                                           idProducto As String,
                                                           idListaDePrecios As Integer,
                                                           blnPreciosConIVA As Boolean) As DataTable

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("SELECT P.IdProducto ")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,P.Tamano")
         .AppendLine("      ,P.IdUnidadDeMedida")
         .AppendLine("      ,PS.PrecioCosto")

         If blnPreciosConIVA Then
            .AppendLine("      ,ROUND((PS.PrecioCosto - P.ImporteImpuestoInterno) / (1+(P.Alicuota/100)), 2) AS PrecioCostoSinIVA")
            .AppendLine("      ,PS.PrecioCosto AS PrecioCostoConIVA")
         Else
            .AppendLine("      ,PS.PrecioCosto AS PrecioCostoSinIVA")
            .AppendLine("      ,ROUND((PS.PrecioCosto * (1+(P.Alicuota/100))) + P.ImporteImpuestoInterno, 2) AS PrecioCostoConIVA")
         End If

         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,Mo.NombreMoneda")
         .AppendLine("      ,Mo.FactorConversion")
         .AppendLine("      ,Mo.Simbolo")

         .AppendLine("      ,PSP.PrecioVenta")

         If blnPreciosConIVA Then
            .AppendLine("      ,ROUND((PSP.PrecioVenta - P.ImporteImpuestoInterno) / (1+(P.Alicuota/100)), 2) AS PrecioVentaSinIVA")
            .AppendLine("      ,PSP.PrecioVenta AS PrecioVentaConIVA")
         Else
            .AppendLine("      ,PSP.PrecioVenta AS PrecioVentaSinIVA")
            .AppendLine("      ,ROUND((PSP.PrecioVenta * (1+(P.Alicuota/100))) + P.ImporteImpuestoInterno, 2) AS PrecioVentaConIVA")
         End If

         .AppendLine("  FROM Productos P")
         .AppendLine("  LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendLine("  LEFT JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendLine("  LEFT JOIN Monedas Mo ON P.IdMoneda = Mo.IdMoneda")
         .AppendLine("  LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto")
         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal AND PSP.IdListaPrecios = " & idListaDePrecios.ToString())
         .AppendLine(" WHERE PS.IdSucursal = " & idsucursal.ToString())
         If Not String.IsNullOrEmpty(nombreproducto) Then
            Dim Palabras() As String = nombreproducto.Split(" "c)
            For Each Palabra As String In Palabras
               .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
            Next
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND P.IdProducto = '{0}'", idProducto)
         End If
         'If idmarca > 0 Then
         '   .AppendLine("   AND P.IdMArca = " & idmarca.ToString())
         'End If
         'If idrubro > 0 Then
         '   .AppendLine("   AND P.IdRubro = " & idrubro.ToString())
         'End If
         If idSubRubro > 0 Then
            .AppendLine("   AND P.IdSubrubro = " & idSubRubro.ToString())
         End If

         GetListaMarcasMultiples(myQuery, marcas, "P")
         GetListaRubrosMultiples(myQuery, rubros, "P")


      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function


   Public Sub Productos_Unificar(IdSucursal As Integer,
                                    IdProducto1 As String,
                                    idProducto2 As String,
                                    Stock As Decimal,
                                    PrecioCompra As Decimal,
                                    PrecioCosto As Decimal,
                                    Listas As DataTable,
                                    CodigoProducto As Integer,
                                    DescripcionProducto As String,
                                    Usuario As String)

      Dim myQuery = New StringBuilder()

      Dim arrTablas(0 To 21, 0 To 2) As String, Cont As Integer, strSQL As String
      Dim intRegistros As Integer
      Dim ProductoElegido As String, ProductoNoElegido As String

      If CodigoProducto = 1 Then
         ProductoElegido = IdProducto1
         ProductoNoElegido = idProducto2
      Else
         ProductoElegido = idProducto2
         ProductoNoElegido = IdProducto1
      End If

      'Campos ArrTablas
      '0: Nombre de Tabla.
      '1: Indica si tiene que actualizar o borrar el registro
      '2: Indica si la tabla tiene el campo Producto Prestado IdProductoPrestado. Es NO PK, porque si lo fuera... no andaria.

      'A futuro hay que automatizarlo.
      arrTablas(0, 0) = "Productos"
      arrTablas(0, 1) = "BORRA"

      '-.PE-33169.- Segun el pendiente hay productos que no estan "marcados" para la web. Sin embargo en la bd hay un registro del producto en la tabla ProductosWeb. Por eso se borran
      arrTablas(1, 0) = "ProductosWeb"
      arrTablas(1, 1) = "BORRA"

      arrTablas(2, 0) = "ProductosSucursales"
      arrTablas(2, 1) = "BORRA"

      arrTablas(3, 0) = "ProductosSucursalesPrecios"
      arrTablas(3, 1) = "BORRA"

      arrTablas(4, 0) = "ProductosNrosSerie"
      arrTablas(4, 1) = "ACTUALIZA"

      arrTablas(5, 0) = "ProductosLotes"
      arrTablas(5, 1) = "ACTUALIZA"

      arrTablas(6, 0) = "ProductosNrosSerie"
      arrTablas(6, 1) = "ACTUALIZA"

      arrTablas(7, 0) = "FichasProductos"
      arrTablas(7, 1) = "ACTUALIZA"

      arrTablas(8, 0) = "VentasProductos"
      arrTablas(8, 1) = "ACTUALIZA"

      arrTablas(9, 0) = "VentasProductosLotes"
      arrTablas(9, 1) = "ACTUALIZA"

      arrTablas(10, 0) = "MovimientosStockProductos"
      arrTablas(10, 1) = "ACTUALIZA"

      arrTablas(11, 0) = "ComprasProductos"
      arrTablas(11, 1) = "ACTUALIZA"

      arrTablas(12, 0) = "MovimientosStockProductos"
      arrTablas(12, 1) = "ACTUALIZA"

      arrTablas(13, 0) = "HistorialPrecios"
      arrTablas(13, 1) = "BORRA"

      arrTablas(14, 0) = "RecepcionNotas"
      arrTablas(14, 1) = "ACTUALIZA"

      arrTablas(15, 0) = "RecepcionNotasF"
      arrTablas(15, 1) = "ACTUALIZA"

      arrTablas(16, 0) = "ProductosComponentes"
      arrTablas(16, 1) = "BORRA"

      arrTablas(17, 0) = "ProduccionProductos"
      arrTablas(17, 1) = "ACTUALIZA"

      arrTablas(18, 0) = "ProduccionProductosComponentes"   'NO funciona para esta tabla !!! habria que hacer algo similar al Copiar, insertar y luego borrar.
      arrTablas(18, 1) = "ACTUALIZA"

      arrTablas(19, 0) = "ProductosProveedores"
      arrTablas(19, 1) = "ACTUALIZA"

      arrTablas(20, 0) = "AlquileresTarifasProductos"
      arrTablas(20, 1) = "ACTUALIZA"

      arrTablas(21, 0) = "Alquileres"
      arrTablas(21, 1) = "ACTUALIZA"


      'RecepcionNotas / IdProductoPrestado ( Ver Garante de CLIentes)

      For Cont = 21 To 0 Step -1

         'Consulto si la Tabla Existe.
         strSQL = "SELECT count(*) as Registros FROM INFORMATION_SCHEMA.TABLES "
         strSQL = strSQL & "WHERE TABLE_NAME='" & arrTablas(Cont, 0) & "'"

         Dim reader As System.Data.Common.DbDataReader

         reader = Me.ExecuteReadear(strSQL)
         reader.Read()

         intRegistros = reader.GetInt32(0)

         reader.Close()

         'La tabla no existe. Puede ser porque es generico para todos los clientes. Ejemplo Tabla: Fichas.
         If intRegistros > 0 Then

            'Obtengo los campos que forman esta tabla.
            strSQL = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS "
            strSQL = strSQL & "where TABLE_NAME='" & arrTablas(Cont, 0) & "'"

            reader = Me.ExecuteReadear(strSQL)

            Dim columnas As List(Of String) = New List(Of String)()

            Using reader
               Do While reader.Read()
                  columnas.Add(reader.GetString(0))
               Loop
            End Using

            For Each col As String In columnas

               'Activo la marca de que lo contiene el Campo Adicional

               If col = "IdProductoPrestado" Or col = "IdProductoComponente" Then
                  arrTablas(Cont, 2) = col
               Else
                  arrTablas(Cont, 2) = ""
               End If

            Next

            With myQuery
               .Length = 0

               If arrTablas(Cont, 1) = "BORRA" Then
                  .Append("DELETE " & arrTablas(Cont, 0))
               Else
                  .Append("UPDATE " & arrTablas(Cont, 0) & " SET ")
                  .Append(" IdProducto = '" & ProductoElegido & "' ")
               End If
               .Append(" WHERE IdProducto = '" & ProductoNoElegido & "'")

            End With

            Me.Execute(myQuery.ToString())
            Me.Sincroniza_I(myQuery.ToString(), arrTablas(Cont, 0))

            If Not String.IsNullOrEmpty(arrTablas(Cont, 2)) Then

               With myQuery
                  .Length = 0
                  If arrTablas(Cont, 1) = "BORRAR" Then
                     .Append("DELETE " & arrTablas(Cont, 0))
                  Else
                     .Append("UPDATE " & arrTablas(Cont, 0) & " SET ")
                     .Append(arrTablas(Cont, 2) & " = '" & ProductoElegido & "' ")
                  End If
                  .Append(" WHERE " & arrTablas(Cont, 2) & " = '" & ProductoNoElegido & "'")

               End With

               Me.Execute(myQuery.ToString())
               Me.Sincroniza_I(myQuery.ToString(), arrTablas(Cont, 0))

            End If

         End If

      Next

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Productos SET ")
         .AppendLine("  NombreProducto = '" & DescripcionProducto & "'")
         .AppendLine(" WHERE IdProducto = '" & ProductoElegido & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Productos")


      Dim dt As DataTable
      Dim sql As SqlServer.Sucursales = New SqlServer.Sucursales(Me._da)
      dt = sql.Sucursales_G1(IdSucursal, False)

      With myQuery
         .Length = 0
         .AppendLine("UPDATE ProductosSucursales SET ")

         .AppendLine("  PrecioFabrica = " & PrecioCompra.ToString() & ", ")
         .AppendLine("  PrecioCosto = " & PrecioCosto.ToString() & ", ")
         '.AppendLine("  PrecioVenta = " & Listas.Rows(0)("Precio").ToString() & ", ") 'PrecioVenta es de ProductosSucursalesPrecios.
         .AppendLine("  Usuario = '" & Usuario & "', ")
         .AppendLine("  FechaActualizacion = getdate(), ")
         .AppendLine("  Stock = " & Stock.ToString())

         .AppendLine(" WHERE IdProducto = '" & ProductoElegido & "'")

         If String.IsNullOrEmpty(dt.Rows(0)("IdSucursalAsociada").ToString()) OrElse Decimal.Parse(dt.Rows(0)("IdSucursalAsociada").ToString()) = 0 Then
            .AppendLine("   AND IdSucursal = " & IdSucursal.ToString())
         Else
            .AppendLine("   AND IdSucursal in (" & IdSucursal.ToString() & ", " & dt.Rows(0)("IdSucursalAsociada").ToString() & ")")
         End If

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")


      'Todo el codigo, solo soporta 2 listas... jeje
      If Listas.Rows.Count > 1 Then

         With myQuery
            .Length = 0
            .AppendLine("UPDATE ProductosSucursalesPrecios SET ")

            .AppendLine("  PrecioVenta = " & Listas.Rows(1)("Precio").ToString() & ", ")
            .AppendLine("  Usuario = '" & Usuario & "', ")
            .AppendLine("  FechaActualizacion = getdate() ")

            .AppendLine(" WHERE IdProducto = '" & ProductoElegido & "'")

            If String.IsNullOrEmpty(dt.Rows(0)("IdSucursalAsociada").ToString()) OrElse Decimal.Parse(dt.Rows(0)("IdSucursalAsociada").ToString()) = 0 Then
               .AppendLine("   AND IdSucursal = " & IdSucursal.ToString())
            Else
               .AppendLine("   AND IdSucursal in (" & IdSucursal.ToString() & ", " & dt.Rows(0)("IdSucursalAsociada").ToString() & ")")
            End If

            .AppendLine("   AND IdListaPrecios = " & Listas.Rows(1)("ID").ToString())

         End With

         Me.Execute(myQuery.ToString())
         Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursalesPrecios")

      End If

   End Sub

   Public Sub Productos_BlanquearStock(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String)
      'Solo borro los movimientos, y blanqueo el stock, por ahora otras las tablas las dejo.
      Dim sqlMSP = New MovimientosStockProductos(Me._da)
      sqlMSP.MovimientosStockProductos_DProd(idSucursal, idDeposito, idUbicacion, idProducto)

      Dim sqlPL = New ProductosLotes(Me._da)
      sqlPL.ProductosLotes_DProd(idSucursal, idProducto)

      Dim sqlPS = New ProductosSucursales(Me._da)
      sqlPS.ProductosSucursales_UStock(idSucursal, idProducto, 0, 0)
      '----------------------------
   End Sub

   Public Sub Productos_InactivarProductos(idMarca As Integer)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Productos ")
         .AppendLine("   SET Activo='False'")
         .AppendLine(" WHERE IdMarca = " & idMarca.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Productos")

   End Sub
   Public Sub Productos_UCalidad(Prod As Entidades.Producto)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Productos ")
         .AppendFormat("   SET CalidadNroCarroceria = {0}", Prod.CalidadNroCarroceria)
         .AppendFormat("   ,CalidadNumeroChasis = '{0}'", Prod.CalidadNumeroChasis)
         .AppendFormat(" WHERE IdProducto = '{0}'", Prod.IdProducto)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Productos")

   End Sub


   Public Function GetProductosDepositos(idProducto As String, idSucursal As Integer, tipoDeposito As String) As DataTable
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("SELECT  ")
         .AppendLine("	PRU.IdSucursal AS IdSucursal, ")
         .AppendLine("	SUC.Nombre AS NombreSucursal, ")
         .AppendLine("	PRU.IdDeposito AS IdDeposito, ")
         .AppendLine("	SUD.CodigoDeposito AS CodigoDeposito, ")
         .AppendLine("	SUD.NombreDeposito AS NombreDeposito, ")
         .AppendLine("	PRU.IdUbicacion AS IdUbicacion, ")
         .AppendLine("	SUU.NombreUbicacion AS NombreUbicacion, ")
         .AppendLine("	PRU.Stock as Stock, ")
         .AppendLine("	SUD.TipoDeposito as TipoDeposito ")
         .AppendLine("	FROM ProductosUbicaciones PRU ")
         .AppendLine("		INNER JOIN Sucursales SUC ON PRU.IdSucursal = SUC.IdSucursal  ")
         .AppendLine("		INNER JOIN SucursalesDepositos SUD ON PRU.IdSucursal = SUD.IdSucursal AND PRU.IdDeposito = SUD.idDeposito ")
         .AppendLine("		INNER JOIN SucursalesUbicaciones SUU ON PRU.IdSucursal = SUU.IdSucursal AND PRU.IdDeposito = SUU.idDeposito AND PRU.IdUbicacion = SUU.IdUbicacion ")
         .AppendFormat("WHERE PRU.IdProducto like '{0}' AND PRU.Stock <> 0 ", idProducto)
         If idSucursal > 0 Then
            .AppendFormat("   AND PRU.IdSucursal = {0}", idSucursal)
         End If
         If Not String.IsNullOrEmpty(tipoDeposito) Then
            .AppendFormat("   AND SUD.TipoDeposito = '{0}'", tipoDeposito)
         End If

      End With
      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetProductosProveedores() As DataTable
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("SELECT PP.CodigoProductoProveedor, PP.IdProveedor, PP.Idproducto, CONVERT(bit, CASE WHEN P.Activo IS NULL THEN 0 ELSE 1 END) Habitual")
         .AppendLine("  FROM ProductosProveedores PP")
         .AppendLine("  LEFT JOIN Productos P ON P.IdProducto = PP.IdProducto AND P.IdProveedor = PP.IdProveedor")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetProductosCant(blnPreciosConIVA As Boolean, IdSucursal As Integer,
                                idListaPrecios As Integer) As DataTable
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("SELECT P.idProducto,  PS.PrecioCosto, PSP.PrecioVenta, PS.PrecioFabrica, ")
         If blnPreciosConIVA Then
            .AppendFormat("  ROUND(({1}), {0}) AS PrecioVentaSinIVA,", 4,
                            CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta",
                                                                        "P.Alicuota",
                                                                        "P.PorcImpuestoInterno",
                                                                        "P.ImporteImpuestoInterno",
                                                                        "P.OrigenPorcImpInt")).AppendLine()
            .AppendLine("	PSP.PrecioVenta as PrecioVentaConIVA")
         Else
            .AppendLine("	PSP.PrecioVenta as PrecioVentaSinIVA,")
            .AppendFormat("  ROUND(({1}), {0}) AS PrecioVentaSinIVA", 4,
                            CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta",
                                                                        "P.Alicuota",
                                                                        "P.PorcImpuestoInterno",
                                                                        "P.ImporteImpuestoInterno",
                                                                        "P.OrigenPorcImpInt")).AppendLine()
         End If
         .AppendLine("  ,PS.Stock ")
         .AppendLine("  FROM Productos P")
         .AppendLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto")
         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
         .AppendFormat("	WHERE PS.IdSucursal = {0}", IdSucursal)
         .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Sub GrabarFoto(imagen As System.Drawing.Image, idProducto As String)



      ''If Not System.IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
      ''   System.IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      ''End If

      ''Dim path As String = Entidades.Publicos.DriverBase + "Eniac\" + idProducto.Replace("/", "_") + ".jpg"

      Dim stb = New StringBuilder()

      If imagen IsNot Nothing Then
         ''imagen.Save(path)

         ''Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

         ''Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString())

         ''Dim foto(Integer.Parse(fsArchivo.Length.ToString())) As Byte

         ''fsArchivo.Read(foto, 0, iFileLength)

         ''fsArchivo.Close()


         Dim fotoParam As Dictionary(Of String, Integer) = GetParametrosFoto()
         Dim imgHandler As ImagenHandler = New ImagenHandler()
         Dim foto As Byte() = imgHandler.Guardar(imagen, New ImagenHandler.Size(fotoParam.Item("FOTOGUARDADOANCHO"), fotoParam.Item("FOTOGUARDADOALTO")), fotoParam.Item("PORCENTAJECALIDADFOTO"))

         With stb
            .AppendFormat(" UPDATE Productos SET Foto = @Foto WHERE IdProducto = '{0}'", idProducto)
         End With

         Me._da.Command.CommandText = stb.ToString()
         Me._da.Command.CommandType = CommandType.Text
         Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@Foto"
         oParameter.DbType = DbType.Binary
         oParameter.Size = foto.Length
         oParameter.Value = foto
         Me._da.Command.Parameters.Add(oParameter)
         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)
      Else
         With stb
            .AppendFormat(" UPDATE Productos SET Foto = NULL WHERE IdProducto = '{0}'", idProducto)
         End With

         Me.Execute(stb.ToString())
      End If

   End Sub
   Public Overloads Function GetParametrosFoto() As Dictionary(Of String, Integer)
      Dim ret As New Dictionary(Of String, Integer)
      ret.Add("PORCENTAJECALIDADFOTO", Me.GetParametrosFoto("PORCENTAJECALIDADFOTO", 70))
      ret.Add("FOTOGUARDADOANCHO", Me.GetParametrosFoto("FOTOGUARDADOANCHO", 800))
      ret.Add("FOTOGUARDADOALTO", Me.GetParametrosFoto("FOTOGUARDADOALTO", 600))
      Return ret
   End Function

   Public Overloads Function GetParametrosFoto(idParametro As String, porDefecto As Integer) As Integer
      Dim stb = New StringBuilder()
      With stb
         .AppendFormat("SELECT ValorParametro FROM Parametros WHERE IdParametro = '{0}'", idParametro.ToUpper.Trim())
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return CInt(dt.Rows(0)("ValorParametro"))
      Else
         Return CInt(porDefecto)
      End If
   End Function

   Public Function GetPorFiltrosVarios(idProducto As String,
                                       nombreProducto As String,
                                       marcas As Entidades.Marca(),
                                       rubros As Entidades.Rubro(),
                                       subRubros As Entidades.SubRubro(),
                                       embalaje As Integer,
                                       descrecproducto As Decimal?,
                                       afectaStock As String,
                                       activo As String,
                                       esServicio As String,
                                       esDeCompras As String,
                                       esDeVentas As String,
                                       esDeCambio As String,
                                       esDeBonificacion As String,
                                       modalidadCodigoBarras As String,
                                       pagaIngresosBrutos As String,
                                       permiteModificarDescripcion As String,
                                       orden As Integer,
                                       moneda As Integer,
                                       publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros,
                                       centroDeCostos As Integer,
                                       utilizaLote As String,
                                       utilizaNroSerie As String,
                                       subSubRubros As List(Of Entidades.SubSubRubro),
                                       caracteristica1 As String,
                                       caracteristica2 As String,
                                       caracteristica3 As String,
                                       base As String,
                                       idProveedor As Long,
                                       esOferta As String,
                                       sinCosto As Boolean,
                                       sinVenta As Boolean,
                                       sinProveedorHabitual As Boolean,
                                       alicuotaIva As Decimal,
                                       activoFiltroAlicIva2 As Boolean,
                                       alicuotaIva2 As Decimal?,
                                       esCompuesto As Entidades.Publicos.SiNoTodos,
                                       UM As String,
                                       esPerceptibleIVARes53292023 As Entidades.Publicos.SiNoTodos) As DataTable

      Dim stb = New StringBuilder()
      Dim consultaFoto As Boolean = False

      With stb

         Dim strAnchoIdProducto As String
         strAnchoIdProducto = Me.GetAnchoCampo("Productos", "IdProducto").ToString()

         With stb
            .AppendLine("SELECT RIGHT(REPLICATE(' '," & strAnchoIdProducto & ") + P.IdProducto," & strAnchoIdProducto & ") as IdProducto")
            .AppendLine("      ,P.NombreProducto")
            .AppendLine("      ,P.Tamano")
            .AppendLine("      ,P.IdUnidadDeMedida")
            .AppendLine("      ,P.IdMarca")
            .AppendLine("      ,M.NombreMarca")
            .AppendLine("      ,P.IdModelo")
            .AppendLine("      ,MO.NombreModelo")
            .AppendLine("      ,P.IdRubro")
            .AppendLine("      ,R.NombreRubro")
            .AppendLine("      ,P.IdSubRubro")
            .AppendLine("      ,SR.NombreSubRubro")
            .AppendLine("      ,P.IdTipoImpuesto")
            .AppendLine("      ,P.Alicuota")
            .AppendLine("      ,P.Alicuota2")
            .AppendLine("      ,P.EsPerceptibleIVARes53292023")
            .AppendLine("      ,PS.Ubicacion")
            .AppendLine("      ,P.AfectaStock")
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "AfectaStock"))

            'Solo la busco en el GET1 porque ahi puedo necesitarlo, en todo lo demas NO.
            'Lentifica terriblemente la consulta.
            If consultaFoto Then
               .AppendLine("      ,P.Foto")
            Else
               .AppendLine("      ,NULL AS Foto")
            End If

            .AppendLine("      ,P.MesesGarantia")
            .AppendLine("      ,P.PermiteModificarDescripcion")
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "PermiteModificarDescripcion"))
            .AppendLine("      ,P.Lote")
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "Lote"))
            .AppendLine("      ,P.NroSerie")
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "NroSerie"))
            .AppendLine("      ,P.CodigoDeBarras")
            .AppendLine("      ,P.CodigoDeBarrasConPrecio")
            .AppendLine("      ,P.EsServicio")
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "EsServicio"))

            .AppendLine("      ,P.PublicarEnWeb")
            .AppendLine("      ,P.PublicarEnTiendaNube")
            .AppendLine("      ,P.PublicarEnMercadoLibre")
            .AppendLine("      ,P.PublicarEnArborea")
            .AppendLine("      ,P.PublicarEnGestion")
            .AppendLine("      ,P.PublicarEnEmpresarial")
            .AppendLine("      ,P.PublicarEnBalanza")
            .AppendLine("      ,P.PublicarEnSincronizacionSucursal")
            .AppendLine("      ,P.PublicarListaDePreciosClientes")

            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "PublicarEnWeb"))
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "PublicarEnTiendaNube"))
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "PublicarEnMercadoLibre"))
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "PublicarEnArborea"))
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "PublicarEnGestion"))
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "PublicarEnEmpresarial"))
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "PublicarEnBalanza"))
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "PublicarEnSincronizacionSucursal"))
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "PublicarListaDePreciosClientes"))

            .AppendLine("      ,P.Observacion")
            .AppendLine("      ,P.EsCompuesto")
            .AppendLine("      ,P.DescontarStockComponentes")
            .AppendLine("      ,P.EsDeCompras")
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "EsDeCompras"))
            .AppendLine("      ,P.EsDeVentas")
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "EsDeVentas"))
            .AppendLine("      ,P.EsCambiable")
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "EsCambiable"))
            .AppendLine("      ,P.EsBonificable")
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "EsBonificable"))

            .AppendLine("      ,P.ModalidadCodigoDeBarras")
            .AppendLine("      ,P.EsOferta")
            .AppendLine("      ,P.IdMoneda")
            .AppendLine("      ,Mn.NombreMoneda")

            .AppendLine("      ,P.EsAlquilable")
            .AppendLine("      ,P.EquipoMarca")
            .AppendLine("      ,P.EquipoModelo")
            .AppendLine("      ,P.NumeroSerie")
            .AppendLine("      ,P.CaractSII")
            .AppendLine("      ,P.Anio")

            .AppendLine("      ,P.Activo")
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "Activo"))

            .AppendLine("      ,P.PagaIngresosBrutos")
            .AppendFormatLine("      ,{0}", ConvertirBitSiNo("P", "PagaIngresosBrutos"))

            .AppendLine("      ,P.Embalaje")
            .AppendLine("      ,P.Kilos")
            .AppendLine("      ,P.IdFormula")
            .AppendLine("      ,P.IdProductoMercosur")
            .AppendLine("      ,P.IdProductoSecretaria")
            .AppendLine("      ,P.FacturacionCantidadNegativa")
            .AppendLine("      ,P.SolicitaEnvase")
            .AppendLine("      ,P.AlertaDeCaja")
            .AppendLine("      ,P.nombreCorto")
            .AppendLine("      ,P.EsRetornable")
            .AppendLine("      ,P.Orden")
            .AppendLine("      ,P.CodigoLargoProducto")
            .AppendLine("      ,P.IdProveedor")
            .AppendLine("      ,PR.CodigoProveedor")
            .AppendLine("      ,PR.NombreProveedor")
            .AppendLine("      ,P.CodigoDeBarrasConPrecio")
            .AppendLine("      ,P.ModalidadCodigoDeBarras")
            .AppendLine("      ,P.EsObservacion")
            .AppendLine("      ,P.UnidHasta1")
            .AppendLine("      ,P.UHPorc1")
            .AppendLine("      ,P.UnidHasta2")
            .AppendLine("      ,P.UHPorc2")
            .AppendLine("      ,P.UnidHasta3")
            .AppendLine("      ,P.UHPorc3")
            .AppendLine("      ,P.UnidHasta4")
            .AppendLine("      ,P.UHPorc4")
            .AppendLine("      ,P.UnidHasta5")
            .AppendLine("      ,P.UHPorc5")
            .AppendLine("      ,P.UHListaPrecios1")
            .AppendLine("      ,P.UHListaPrecios2")
            .AppendLine("      ,P.UHListaPrecios3")
            .AppendLine("      ,P.UHListaPrecios4")
            .AppendLine("      ,P.UHListaPrecios5")
            .AppendLine("      ,LP1.NombreListaPrecios NombreListaPrecios_1")
            .AppendLine("      ,LP2.NombreListaPrecios NombreListaPrecios_2")
            .AppendLine("      ,LP3.NombreListaPrecios NombreListaPrecios_3")
            .AppendLine("      ,LP4.NombreListaPrecios NombreListaPrecios_4")
            .AppendLine("      ,LP5.NombreListaPrecios NombreListaPrecios_5")
            .AppendLine("      ,P.PrecioPorEmbalaje")

            'Contabilidad
            .AppendLine("      ,P.IdCuentaCompras")
            .AppendLine("      ,CCC.NombreCuenta AS NombreCuentaCompras")
            .AppendLine("      ,P.IdCuentaVentas")
            .AppendLine("      ,CCV.NombreCuenta AS NombreCuentaVentas")
            .AppendLine("      ,P.IdCuentaComprasSecundaria")
            .AppendLine("      ,CCCS.NombreCuenta AS NombreCuentaComprasSecundaria")
            .AppendLine("      ,P.IdCentroCosto")
            .AppendLine("      ,CECO.NombreCentroCosto")

            .AppendLine("      ,P.ImporteImpuestoInterno")
            .AppendLine("      ,P.EsOferta")
            .AppendLine("      ,P.IncluirExpensas")
            .AppendLine("      ,PS.FechaActualizacion")

            .AppendLine("      ,PS.Stock AS StockActual")
            .AppendLine("      ,PS.StockMinimo")
            .AppendLine("      ,PS.PuntoDePedido")
            .AppendLine("      ,PS.StockMaximo")

            .AppendLine("      ,P.ObservacionCompras")
            .AppendLine("      ,P.SolicitaPrecioVentaPorTamano")

            .AppendLine("      ,P.Espmm")
            .AppendLine("      ,P.EspPulgadas")
            .AppendLine("      ,P.CodigoSAE")
            .AppendLine("      ,P.IdProduccionProceso")
            .AppendLine("      ,P.IdProduccionForma")

            .AppendLine("      ,P.PorcImpuestoInterno")
            .AppendLine("      ,P.OrigenPorcImpInt")

            .AppendLine("      ,PRP.NombreProduccionProceso")
            .AppendLine("      ,PRF.NombreProduccionForma")

            .AppendLine("      ,P.CalculaPreciosSegunFormula")
            .AppendLine("      ,P.IdSubSubRubro")
            .AppendLine("      ,SSR.NombreSubSubRubro")

            .AppendLine("      ,P.EsCambiable")
            .AppendLine("      ,P.EsBonificable")
            .AppendLine("      ,P.DescRecProducto")
            .AppendLine("      ,P.ActualizaPreciosSucursalesAsociadas")
            .AppendLine("      ,P.IdUnidadDeMedida2")
            .AppendLine("      ,P.Conversion")
            .AppendLine("      ,P.IdProductoNumerico")
            .AppendLine("      ,P.EnviarSinCargo")
            .AppendLine("      ,P.CodigoProductoTiendaNube")
            .AppendLine("      ,P.CodigoProductoMercadoLibre")
            .AppendLine("      ,P.IdVarianteProducto")
            .AppendLine("      ,P.TipoBonificacion")

            .AppendLine("      ,PW.Caracteristica1")
            .AppendLine("      ,PW.Caracteristica2")
            .AppendLine("      ,PW.Caracteristica3")
            .AppendLine("      ,PW.ValorCaracteristica1")
            .AppendLine("      ,PW.ValorCaracteristica2")
            .AppendLine("      ,PW.ValorCaracteristica3")
            .AppendLine(" FROM Productos P ")
            .AppendLine(" LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca ")
            .AppendLine(" LEFT JOIN Rubros R ON P.IdRubro = R.IdRubro ")
            .AppendLine(" LEFT OUTER JOIN Modelos MO ON P.IdModelo = MO.IdModelo")
            .AppendLine(" LEFT OUTER JOIN SubRubros SR ON P.IdRubro = SR.IdRubro AND P.IdSubRubro = SR.IdSubRubro")
            .AppendLine(" LEFT OUTER JOIN SubSubRubros SSR ON P.IdSubRubro = SSR.IdSubRubro AND P.IdSubSubRubro = SSR.IdSubSubRubro")
            .AppendLine(" LEFT JOIN Monedas Mn ON P.IdMoneda = Mn.IdMoneda ")
            .AppendLine(" LEFT JOIN Proveedores PR ON PR.IdProveedor = P.IdProveedor ")
            .AppendLine(" LEFT JOIN ContabilidadCuentas CCC ON CCC.IdCuenta = P.IdCuentaCompras")
            .AppendLine(" LEFT JOIN ContabilidadCuentas CCV ON CCV.IdCuenta = P.IdCuentaVentas")
            .AppendLine(" LEFT JOIN ContabilidadCuentas CCCS ON CCCS.IdCuenta = P.IdCuentaComprasSecundaria")
            .AppendLine(" LEFT JOIN ContabilidadCentrosCostos CECO ON CECO.IdCentroCosto = P.IdCentroCosto")
            .AppendLine(" LEFT JOIN ListasDePrecios LP1 ON P.UHListaPrecios1 = LP1.IdListaPrecios")
            .AppendLine(" LEFT JOIN ListasDePrecios LP2 ON P.UHListaPrecios1 = LP2.IdListaPrecios")
            .AppendLine(" LEFT JOIN ListasDePrecios LP3 ON P.UHListaPrecios1 = LP3.IdListaPrecios")
            .AppendLine(" LEFT JOIN ListasDePrecios LP4 ON P.UHListaPrecios1 = LP4.IdListaPrecios")
            .AppendLine(" LEFT JOIN ListasDePrecios LP5 ON P.UHListaPrecios1 = LP5.IdListaPrecios")

            .AppendLine(" LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = P.IdProduccionForma")
            .AppendLine(" LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = P.IdProduccionProceso")

            .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & Entidades.Usuario.Actual.Sucursal.IdSucursal.ToString())
            .AppendLine("  LEFT JOIN " & base & "ProductosWeb PW ON PW.IdProducto = P.IdProducto COLLATE Modern_Spanish_CI_AS ")

         End With

         .AppendLine("	WHERE 1 = 1")

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND (P.IdProducto LIKE '%" & idProducto & "%' OR P.CodigoDeBarras LIKE '%" & idProducto & "%')")
         End If

         If sinCosto Then
            .AppendLine("  AND PS.PrecioCosto = 0")
         End If

         If sinVenta Then
            .AppendLine("      AND NOT EXISTS (SELECT * FROM ProductosSucursalesPrecios PSP")
            .AppendLine("            WHERE PSP.IdProducto = PS.IdProducto")
            .AppendLine("                     AND PSP.IdSucursal = PS.IdSucursal")
            .AppendLine("                     AND PSP.PrecioVenta <> 0)")
         End If

         If Not String.IsNullOrEmpty(nombreProducto) Then
            Dim Palabras() As String = nombreProducto.Split(" "c)
            For Each Palabra As String In Palabras
               .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
            Next
         End If

         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subRubros, "P")
         GetListaMarcasMultiples(stb, marcas, "P")

         If subSubRubros.Count > 0 Then
            .Append(" AND P.IdSubSubRubro IN (")
            For Each pr As Entidades.SubSubRubro In subSubRubros
               .AppendFormat(" {0},", pr.IdSubSubRubro)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         'If IdSubRubro > 0 Then
         '   .AppendLine("      AND P.IdSubRubro = " & IdSubRubro.ToString())
         'End If

         If embalaje > 0 Then
            .AppendLine("      AND P.Embalaje = " & embalaje.ToString())
         End If

         If afectaStock <> "TODOS" Then
            .AppendLine("      AND P.AfectaStock = " & IIf(afectaStock = "SI", "1", "0").ToString())
         End If

         If activo <> "TODOS" Then
            .AppendLine("      AND P.Activo = " & IIf(activo = "SI", "1", "0").ToString())
         End If

         If esServicio <> "TODOS" Then
            .AppendLine("      AND P.EsServicio = " & IIf(esServicio = "SI", "1", "0").ToString())
         End If

         If esDeCompras <> "TODOS" Then
            .AppendLine("      AND P.EsDeCompras = " & IIf(esDeCompras = "SI", "1", "0").ToString())
         End If

         If esDeVentas <> "TODOS" Then
            .AppendLine("      AND P.EsDeVentas = " & IIf(esDeVentas = "SI", "1", "0").ToString())
         End If

         If esOferta <> "TODOS" Then
            .AppendFormatLine("      AND P.EsOferta = '{0}'", esOferta)
         End If

         If esDeCambio <> "TODOS" Then
            .AppendLine("      AND P.EsCambiable = " & IIf(esDeCambio = "SI", "1", "0").ToString())
         End If

         If esDeBonificacion <> "TODOS" Then
            .AppendLine("      AND P.EsBonificable = " & IIf(esDeBonificacion = "SI", "1", "0").ToString())
         End If

         If modalidadCodigoBarras <> "TODOS" Then
            If modalidadCodigoBarras = "NO" Then
               .AppendFormatLine("      AND P.CodigoDeBarrasConPrecio = 'False'")
            Else
               .AppendFormatLine("      AND P.CodigoDeBarrasConPrecio = 'True'")
               .AppendFormatLine("      AND P.ModalidadCodigoDeBarras = '{0}'", modalidadCodigoBarras)
            End If
         End If

         If pagaIngresosBrutos <> "TODOS" Then
            .AppendLine("      AND P.PagaIngresosBrutos = " & IIf(pagaIngresosBrutos = "SI", "1", "0").ToString())
         End If

         If permiteModificarDescripcion <> "TODOS" Then
            .AppendLine("      AND P.PermiteModificarDescripcion = " & IIf(permiteModificarDescripcion = "SI", "1", "0").ToString())
         End If

         If orden > 0 Then
            .AppendLine("      AND P.Orden = " & orden.ToString())
         End If

         If moneda > 0 Then
            .AppendLine("      AND P.IdMoneda = " & moneda.ToString())
         End If

         ProductoPublicarEn(stb, publicarEn, "P")

         'If publicarEnWeb <> "TODOS" Then
         '   .AppendLine("      AND P.PublicarEnWeb = " & IIf(publicarEnWeb = "SI", "1", "0").ToString())
         'End If

         'If publicarListaDePreciosClientes <> "TODOS" Then
         '   .AppendLine("      AND P.PublicarListaDePreciosClientes = " & IIf(publicarListaDePreciosClientes = "SI", "1", "0").ToString())
         'End If

         If centroDeCostos <> 0 Then
            .AppendLine("      AND P.IdCentroCosto = " & centroDeCostos.ToString())
         End If

         If utilizaLote <> "TODOS" Then
            .AppendLine("      AND P.Lote = " & IIf(utilizaLote = "SI", "1", "0").ToString())
         End If

         If utilizaNroSerie <> "TODOS" Then
            .AppendLine("      AND P.NroSerie = " & IIf(utilizaNroSerie = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(caracteristica1) Then
            .AppendLine("   AND PW.Caracteristica1 LIKE '%" & caracteristica1 & "%'")
         End If

         If Not String.IsNullOrEmpty(caracteristica2) Then
            .AppendLine("   AND PW.Caracteristica2 LIKE '%" & caracteristica2 & "%'")
         End If

         If Not String.IsNullOrEmpty(caracteristica3) Then
            .AppendLine("   AND PW.Caracteristica3 LIKE '%" & caracteristica3 & "%'")
         End If

         If idProveedor > 0 Then
            .AppendLine("      AND P.IdProveedor = " & idProveedor.ToString())
         End If

         If sinProveedorHabitual Then
            .AppendLine("      AND P.IdProveedor IS NULL")
         End If

         If alicuotaIva > -1 Then
            .AppendLine("      AND P.Alicuota = " & alicuotaIva.ToString())
         End If

         If descrecproducto.HasValue Then
            .AppendFormatLine("      AND P.DescRecProducto = {0}", descrecproducto.Value)
         End If

         If activoFiltroAlicIva2 Then
            If alicuotaIva2.HasValue Then
               .AppendLine("      AND P.Alicuota2 = " & alicuotaIva2.Value)
            Else
               .AppendLine("      AND P.Alicuota2 IS NULL")
            End If
         End If

         If esCompuesto <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND P.EsCompuesto = {0}", IIf(esCompuesto = Entidades.Publicos.SiNoTodos.SI, "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(UM) Then
            .AppendFormatLine("     AND P.IdUnidadDeMedida = '{0}'", UM)
         End If

         If esPerceptibleIVARes53292023 <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND P.EsPerceptibleIVARes53292023 = {0}", GetStringFromBoolean(esPerceptibleIVARes53292023 = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendLine(" ORDER BY P.NombreProducto")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetProductosParaExportar(idProducto As String, nombreProducto As String,
                                            marcas As List(Of Entidades.Marca), rubros As List(Of Entidades.Rubro), idSubRubro As Integer,
                                            embalaje As Integer,
                                            afectaStock As String,
                                            activo As String,
                                            esServicio As String, esDeCompras As String, esDeVentas As String,
                                            pagaIngresosBrutos As String,
                                            permiteModificarDescripcion As String,
                                            idSucursal As Integer,
                                            idListaPrecios As Integer,
                                            idMoneda As Integer,
                                            tipoCambio As Decimal,
                                            fechaActualizadoDesde As Date, fechaActualizadoHasta As Date,
                                            publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros,
                                            base As String,
                                            subRubros As List(Of Entidades.SubRubro),
                                            subSubRubros As List(Of Entidades.SubSubRubro),
                                            exportaConIVA As Boolean,
                                            preciosConIVA As Boolean,
                                            decimalesRedondeoPrecios As Integer,
                                            exportarEnviando As Entidades.Producto.ExportarEnviando,
                                            fechaEnviando As Date,
                                            consultaFoto As Boolean,
                                            formatoNombreWeb As Entidades.Producto.FormatosProductos,
                                            idListaPreciosMayorista As Integer,
                                            filtroStock As Entidades.EnumSql.Stock_TipoReporte) As DataTable
      Dim CampoFecha As String
      Dim strAnchoIdProducto = Me.GetAnchoCampo("Productos", "IdProducto").ToString()

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT RIGHT(REPLICATE(' '," & strAnchoIdProducto & ") + P.IdProducto," & strAnchoIdProducto & ") as IdProducto")
         '-.PE-31924.-
         If formatoNombreWeb = Entidades.Producto.FormatosProductos.Arborea Then
            .AppendLine("      ,CASE WHEN NombreProductoWeb IS NOT NULL THEN NombreProductoWeb ELSE NombreProducto END AS NombreProducto")
         Else
            .AppendLine("      ,P.NombreProducto")
         End If
         .AppendLine("      ,PS.IdSucursal") '-.PE-32135.-
         .AppendLine("      ,P.IdProductoNumerico") '- REQ-35886.-
         .AppendLine("      ,P.Tamano")
         .AppendLine("      ,P.IdUnidadDeMedida")
         .AppendLine("      ,P.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,P.IdModelo")
         .AppendLine("      ,MO.NombreModelo")
         .AppendLine("      ,P.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,P.IdSubRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,P.IdSubSubRubro")
         .AppendLine("      ,SSR.NombreSubSubRubro")
         .AppendLine("      ,P.MesesGarantia")
         .AppendLine("      ,P.IdTipoImpuesto")
         .AppendLine("      ,P.Alicuota")
         .AppendLine("      ,P.Alicuota2")
         .AppendLine("      ,P.AfectaStock")

         .AppendLine("      ,P.ModalidadCodigoDeBarras")



         'lo tenemos que obtener porque se necesita para WebExperto de Electrinet
         If consultaFoto Then
            .AppendLine("      ,P.Foto")
         Else
            .AppendLine("      ,NULL AS Foto")
         End If

         .AppendLine("      ,P.PermiteModificarDescripcion")
         .AppendLine("      ,P.Lote")
         .AppendLine("      ,P.NroSerie")
         .AppendLine("      ,P.CodigoDeBarras")
         .AppendLine("      ,P.CodigoDeBarrasConPrecio")
         .AppendLine("      ,P.EsServicio")
         .AppendLine("      ,P.PublicarEnWeb")
         .AppendLine("      ,P.Observacion")
         .AppendLine("      ,P.EsCompuesto")
         .AppendLine("      ,P.DescontarStockComponentes")
         .AppendLine("      ,P.EsDeCompras")
         .AppendLine("      ,P.EsDeVentas")
         .AppendLine("      ,Mn.IdMoneda")
         .AppendLine("      ,Mn.NombreMoneda")
         .AppendLine("      ,UPPER(LEFT(Mn.NombreMoneda, 1)) AS NombreMonedaCorto")

         .AppendLine("      ,P.EsAlquilable")
         .AppendLine("      ,P.EquipoMarca")
         .AppendLine("      ,P.EquipoModelo")
         .AppendLine("      ,P.NumeroSerie")
         .AppendLine("      ,P.CaractSII")
         .AppendLine("      ,P.Anio")

         .AppendLine("      ,P.Activo")
         .AppendLine("      ,P.PagaIngresosBrutos")
         .AppendLine("      ,P.Embalaje")
         .AppendLine("      ,P.Kilos")
         .AppendLine("      ,P.IdFormula")
         .AppendLine("      ,P.IdProductoMercosur")
         .AppendLine("      ,P.IdProductoSecretaria")
         .AppendLine("      ,P.PublicarListaDePreciosClientes")
         .AppendLine("      ,P.FacturacionCantidadNegativa")
         .AppendLine("      ,P.SolicitaEnvase")
         .AppendLine("      ,P.AlertaDeCaja")
         .AppendLine("      ,P.nombreCorto")
         .AppendLine("      ,P.CodigoLargoProducto")
         .AppendLine("      ,P.Alto")
         .AppendLine("      ,P.Ancho")
         .AppendLine("      ,P.Largo")
         .AppendFormatLine("      ,P.IdUnidadDeMedida2")
         .AppendFormatLine("      ,P.Conversion")
         .AppendFormatLine("      ,P.IdProductoNumerico")
         .AppendFormatLine("      ,P.TipoBonificacion")
         .AppendLine("      ,PW.Caracteristica1")
         .AppendLine("      ,PW.Caracteristica2")
         .AppendLine("      ,PW.Caracteristica3")
         .AppendLine("      ,PW.ValorCaracteristica1")
         .AppendLine("      ,PW.ValorCaracteristica2")
         .AppendLine("      ,PW.ValorCaracteristica3")
         If consultaFoto Then
            .AppendLine("      ,PW.Foto2")
            .AppendLine("      ,PW.Foto3")
         Else
            .AppendLine("      ,NULL Foto2")
            .AppendLine("      ,NULL Foto3")
         End If
         .AppendLine("      ,PW.EsParaConstructora")
         .AppendLine("      ,PW.EsParaIndustria")
         .AppendLine("      ,PW.EsParaCooperativaElectrica")
         .AppendLine("      ,PW.EsParaMayorista")
         .AppendLine("      ,PW.EsParaMinorista")

         Dim calculoCosto As String
         Dim calculoVenta As String
         Dim calculoMayorista As String

         'Si exporta igual que como está en BD, no cambio nada.
         If preciosConIVA = exportaConIVA Then
            calculoCosto = "PS.PrecioCosto"
            calculoVenta = "PSP.PrecioVenta"
            calculoMayorista = "PSP1.PrecioVenta"
         Else
            If preciosConIVA Then   'Si son diferentes y los precios están con IVA, significa que quiere exportar SIN IVA
               calculoCosto = CalculosImpositivos.ObtenerPrecioSinImpuestos("PS.PrecioCosto", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt")
               calculoVenta = CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt")
               calculoMayorista = CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP1.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt")
            Else                    'Si son diferentes y los precios están sin IVA, significa que quiere exportar CON IVA
               calculoCosto = CalculosImpositivos.ObtenerPrecioConImpuestos("PS.PrecioCosto", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt")
               calculoVenta = CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt")
               calculoMayorista = CalculosImpositivos.ObtenerPrecioConImpuestos("PSP1.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt")
            End If
         End If

         .AppendFormatLine("      ,ROUND(CASE WHEN P.IdMoneda = Mn.IdMoneda THEN {0} ELSE CASE WHEN P.IdMoneda = 1 THEN {0} / {1} ELSE {0} * {1} END END, {2}) AS PrecioCosto", calculoCosto, tipoCambio, decimalesRedondeoPrecios)
         .AppendFormatLine("      ,ROUND(CASE WHEN P.IdMoneda = Mn.IdMoneda THEN {0} ELSE CASE WHEN P.IdMoneda = 1 THEN {0} / {1} ELSE {0} * {1} END END, {2}) AS PrecioVenta", calculoVenta, tipoCambio, decimalesRedondeoPrecios)
         '-.PE-32135.-
         .AppendFormatLine("     ,ROUND(CASE WHEN P.IdMoneda = Mn.IdMoneda THEN {0} ELSE CASE WHEN P.IdMoneda = 1 THEN {0} / {1} ELSE {0} * {1} END END, {2}) AS PrecioMayorista", calculoMayorista, tipoCambio, decimalesRedondeoPrecios)

         .AppendFormatLine("      ,CONVERT(DECIMAL(14,2), CASE WHEN {1} = 0 THEN 0 ELSE ROUND(({0} / {1} * 100) - 100, 2) END) AS PORCENTAJE", calculoVenta, calculoCosto)

         CampoFecha = "PSP.FechaActualizacion"
         .AppendFormatLine("      ,{0}", CampoFecha)

         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,P.NombreCorto")
         .AppendLine("   	 ,PP.CodigoProductoProveedor")
         .AppendLine("   	 ,PP.IdProveedor")
         .AppendLine("      ,PRO.NombreProveedor")

         .AppendLine(" FROM Productos P ")
         .AppendLine(" LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .AppendLine(" LEFT JOIN Rubros R ON P.IdRubro = R.IdRubro ")
         .AppendLine(" LEFT OUTER JOIN Modelos MO ON P.IdModelo = MO.IdModelo")
         .AppendLine(" LEFT OUTER JOIN SubRubros SR ON P.IdRubro = SR.IdRubro AND P.IdSubRubro = SR.IdSubRubro")
         .AppendLine(" LEFT OUTER JOIN SubSubRubros SSR ON P.IdSubRubro = SSR.IdSubRubro AND P.IdSubSubRubro = SSR.IdSubSubRubro")
         If idMoneda > 0 Then
            .AppendLine(" LEFT JOIN Monedas Mn ON Mn.IdMoneda = " + idMoneda.ToString())
         Else
            .AppendLine(" LEFT JOIN Monedas Mn ON Mn.IdMoneda = P.IdMoneda ")
         End If
         .AppendLine("  LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto")
         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = P.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP1 ON PSP1.IdProducto = PSP.IdProducto AND PSP1.IdSucursal = PSP.IdSucursal") '-.PE-32135.-
         .AppendLine("  LEFT JOIN " & base & "ProductosWeb PW ON PW.IdProducto = P.IdProducto COLLATE Modern_Spanish_CI_AS ")
         .AppendLine("  LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.IdProducto")
         .AppendLine("  AND PP.IdProveedor = P.IdProveedor")
         .AppendLine("  LEFT JOIN Proveedores PRO ON PRO.IdProveedor = P.IdProveedor ")

         .AppendLine("  WHERE 1 = 1")

         .AppendLine("	AND PS.IdSucursal = " & idSucursal)

         .AppendLine("	  AND PSP.IdListaPrecios = " & idListaPrecios)
         .AppendLine("    AND PSP1.IdListaPrecios = " & idListaPreciosMayorista)

         If filtroStock <> Entidades.EnumSql.Stock_TipoReporte.General Then
            .AppendFormatLine("   AND PS.Stock {0}", ToQuery(filtroStock))
         End If

         'Si es TODOS no aplico filtro de FechaActualizacionWeb
         If exportarEnviando <> Entidades.Producto.ExportarEnviando.TODOS Then
            If exportarEnviando = Entidades.Producto.ExportarEnviando.PENDIENTES Then
               'Si es PENDIENTES comparo la FechaActualizacionWeb con la FechaExportacionWeb
               .AppendFormatLine("    AND (P.FechaActualizacionWeb > {0} OR PW.FechaActualizacionWeb > {0} OR PS.FechaActualizacionWeb > {0} OR PSP.FechaActualizacionWeb > {0})",
                                   "ISNULL(P.FechaExportacionWeb, CAST(0 As Date))")
            ElseIf exportarEnviando = Entidades.Producto.ExportarEnviando.FECHAENVIO Then
               'Si es FECHAENVIO comparo la FechaExportacionWeb con la fecha ingresada en pantalla
               .AppendFormatLine("    AND (P.FechaExportacionWeb IS NULL OR P.FechaExportacionWeb > '{0}')", ObtenerFecha(fechaEnviando, True))
            End If
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND (P.IdProducto LIKE '%" & idProducto & "%' OR P.CodigoDeBarras LIKE '%" & idProducto & "%')")
         End If

         If Not String.IsNullOrEmpty(nombreProducto) Then
            Dim Palabras() As String = nombreProducto.Split(" "c)
            For Each Palabra As String In Palabras
               .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
            Next
         End If

         If marcas.Count > 0 Then
            .Append(" AND P.IdMarca IN (")
            For Each pr As Entidades.Marca In marcas
               .AppendFormat(" {0},", pr.IdMarca)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If rubros.Count > 0 Then
            .Append(" AND P.IdRubro IN (")
            For Each pr As Entidades.Rubro In rubros
               .AppendFormat(" {0},", pr.IdRubro)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If subRubros.Count > 0 Then
            .Append(" AND P.IdSubRubro IN (")
            For Each pr As Entidades.SubRubro In subRubros
               .AppendFormat(" {0},", pr.IdSubRubro)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If subSubRubros.Count > 0 Then
            .Append(" AND P.IdSubSubRubro IN (")
            For Each pr As Entidades.SubSubRubro In subSubRubros
               .AppendFormat(" {0},", pr.IdSubSubRubro)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If


         'If IdSubRubro > 0 Then
         '   .AppendLine("      AND P.IdSubRubro = " & IdSubRubro.ToString())
         'End If

         If embalaje > 0 Then
            .AppendLine("      AND P.Embalaje = " & embalaje.ToString())
         End If

         If afectaStock <> "TODOS" Then
            .AppendLine("      AND P.AfectaStock = " & IIf(afectaStock = "SI", "1", "0").ToString())
         End If

         If activo <> "TODOS" Then
            .AppendLine("      AND P.Activo = " & IIf(activo = "SI", "1", "0").ToString())
         End If

         If esServicio <> "TODOS" Then
            .AppendLine("      AND P.EsServicio = " & IIf(esServicio = "SI", "1", "0").ToString())
         End If

         If esDeCompras <> "TODOS" Then
            .AppendLine("      AND P.EsDeCompras = " & IIf(esDeCompras = "SI", "1", "0").ToString())
         End If

         If esDeVentas <> "TODOS" Then
            .AppendLine("      AND P.EsDeVentas = " & IIf(esDeVentas = "SI", "1", "0").ToString())
         End If

         If pagaIngresosBrutos <> "TODOS" Then
            .AppendLine("      AND P.PagaIngresosBrutos = " & IIf(pagaIngresosBrutos = "SI", "1", "0").ToString())
         End If

         If permiteModificarDescripcion <> "TODOS" Then
            .AppendLine("      AND P.PermiteModificarDescripcion = " & IIf(permiteModificarDescripcion = "SI", "1", "0").ToString())
         End If

         ProductoPublicarEn(stb, publicarEn, "P")

         'If publicarEnWeb <> "TODOS" Then
         '   .AppendLine("      AND P.PublicarEnWeb = " & IIf(publicarEnWeb = "SI", "1", "0").ToString())
         'End If

         'If publicarListaDePreciosClientes <> "TODOS" Then
         '   .AppendLine("      AND P.PublicarListaDePreciosClientes = " & IIf(publicarListaDePreciosClientes = "SI", "1", "0").ToString())
         'End If

         If fechaActualizadoDesde > Date.Parse("01/01/1990") Then
            .AppendLine("	 AND ((" & CampoFecha & " >= '" & fechaActualizadoDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	 AND " & CampoFecha & " <= '" & fechaActualizadoHasta.ToString("yyyyMMdd HH:mm:ss") & "')")
            .AppendLine("	 OR (PS.FechaActualizacionWeb >= '" & fechaActualizadoDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	 AND PS.FechaActualizacionWeb <= '" & fechaActualizadoHasta.ToString("yyyyMMdd HH:mm:ss") & "')")
            .AppendLine("	 OR (PW.FechaActualizacionWeb >= '" & fechaActualizadoDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	 AND PW.FechaActualizacionWeb <= '" & fechaActualizadoHasta.ToString("yyyyMMdd HH:mm:ss") & "'))")
         End If

         .AppendLine(" ORDER BY P.NombreProducto")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function



   Public Sub Productos_U_FechaExportacionWeb(idProducto As String, fechaExportacionWeb As Date?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Productos")
         If fechaExportacionWeb.HasValue Then
            .AppendFormatLine("   SET FechaExportacionWeb = '{0}'", ObtenerFecha(fechaExportacionWeb.Value, True))
         Else
            .AppendFormatLine("   SET FechaExportacionWeb = NULL")
         End If
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto.Trim())
      End With
      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Productos")
   End Sub

   Public Function GetProductosXModelo(modelo As String, Optional BusquedaParcial As Boolean = True) As DataTable

      Dim stbQuery = New StringBuilder()
      Dim dt As New DataTable

      With stbQuery
         .AppendLine("SELECT * FROM Productos")
         .AppendLine(" WHERE EquipoModelo = '" & modelo & "'")
         dt = Me.GetDataTable(stbQuery.ToString())
      End With

      If (dt Is Nothing OrElse dt.Rows.Count = 0) And BusquedaParcial Then
         stbQuery.Length = 0

         With stbQuery
            .AppendLine("SELECT * FROM Productos")
            .AppendLine(" WHERE EquipoModelo LIKE '%" & modelo & "%' ")
            .AppendLine(" ORDER BY NombreProducto ")
         End With
         dt = Me.GetDataTable(stbQuery.ToString())
      End If

      Return dt

   End Function

   Public Function GetProductosXNumeroSerie(NumeroSerie As String, Optional BusquedaParcial As Boolean = True) As DataTable

      Dim stbQuery = New StringBuilder()
      Dim dt As New DataTable

      With stbQuery
         .AppendLine("SELECT * FROM Productos")
         .AppendLine(" WHERE NumeroSerie = '" & NumeroSerie & "'")
         dt = Me.GetDataTable(stbQuery.ToString())
      End With

      If (dt Is Nothing OrElse dt.Rows.Count = 0) And BusquedaParcial Then
         stbQuery.Length = 0

         With stbQuery
            .AppendLine("SELECT * FROM Productos")
            .AppendLine(" WHERE NumeroSerie LIKE '%" & NumeroSerie & "%' ")
            .AppendLine(" ORDER BY NombreProducto ")
         End With
         dt = Me.GetDataTable(stbQuery.ToString())
      End If

      Return dt

   End Function

   Public Function GetProductosXCaractSII(caractSII As String, Optional BusquedaParcial As Boolean = True) As DataTable

      Dim stbQuery = New StringBuilder()
      Dim dt As New DataTable

      With stbQuery
         .AppendLine("SELECT * FROM Productos")
         .AppendLine(" WHERE CaractSII = '" & caractSII & "'")
         dt = Me.GetDataTable(stbQuery.ToString())
      End With

      If (dt Is Nothing OrElse dt.Rows.Count = 0) And BusquedaParcial Then
         stbQuery.Length = 0

         With stbQuery
            .AppendLine("SELECT * FROM Productos")
            .AppendLine(" WHERE CaractSII LIKE '%" & caractSII & "%' ")
            .AppendLine(" ORDER BY NombreProducto ")
         End With
         dt = Me.GetDataTable(stbQuery.ToString())
      End If

      Return dt

   End Function

   Public Function GetProductosCalidad(idProducto As String, FechaDesde As Date, FechaHasta As Date,
                                                IdestadoCalidad As Integer, Liberado As Boolean,
                                                Entregado As Boolean) As DataTable

      Dim stbQuery = New StringBuilder()
      Dim dt As New DataTable

      Dim strAnchoIdProducto As String
      strAnchoIdProducto = Me.GetAnchoCampo("Productos", "IdProducto").ToString()

      With stbQuery
         .AppendLine("SELECT LCU.IdProducto, P.NombreProducto ")
         .AppendLine(" ,C.CodigoCliente ")
         .AppendLine("     ,C.NombreCliente")
         .AppendLine("     ,C.NombreDeFantasia")
         .AppendLine("  , P.CalidadStatusLiberado")
         .AppendLine("  , P.CalidadFechaLiberado")
         .AppendLine("  , P.CalidadUserLiberado           ")
         .AppendLine("  , P.CalidadStatusEntregado        ")
         .AppendLine("  , P.CalidadFechaEntregado         ")
         .AppendLine("  , P.CalidadUserEntregado          ")
         .AppendLine("  , P.CalidadFechaIngreso           ")
         .AppendLine("  , P.CalidadFechaEgreso            ")
         .AppendLine("  , P.CalidadNroCertificado         ")
         .AppendLine("  , P.CalidadFecCertificado         ")
         .AppendLine("  , P.CalidadUsrCertificado         ")
         .AppendLine("  , P.CalidadObservaciones          ")
         .AppendLine("  , P.CalidadFechaPreEnt            ")
         .AppendLine("  , P.CalidadFechaEntProg           ")
         .AppendLine("  , P.CalidadNumeroChasis")
         .AppendLine("  , P.CalidadNroCarroceria")
         .AppendLine("  , P.IdProductoTipoServicio")
         .AppendLine("  , P.CalidadNroDeMotor")
         .AppendLine("  , P.CalidadFechaEntReProg")
         .AppendLine("  , P.IdProductoModelo ")
         .AppendLine("  , P.CalidadNroCertEntregado         ")
         .AppendLine("  , P.CalidadFecCertEntregado         ")
         .AppendLine("  , P.CalidadUsrCertEntregado         ")
         .AppendLine("  , P.CalidadStatusLiberadoPDI")
         .AppendLine("  , P.CalidadFechaLiberadoPDI")
         .AppendLine("  , P.CalidadUserLiberadoPDI")
         .AppendLine("  , P.CalidadNroCertEObs")
         .AppendLine("  , P.CalidadNroRemito")

         .AppendLine(" FROM CalidadListasControlProductos AS LCU")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = LCU.IdProducto")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto  ")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente                ")
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" WHERE P.{0} = '{1}'", Entidades.Producto.Columnas.IdProducto.ToString(), idProducto)
         End If
         .AppendFormat("	  AND P.CalidadFechaIngreso >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))

         .AppendFormat("  AND P.CalidadFechaIngreso <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))

         If IdestadoCalidad <> 0 Then
            .AppendFormatLine("           AND PS.IdEstadoCalidad = '{0}'", IdestadoCalidad)
         End If
         If Liberado Then
            .AppendFormatLine("           AND P.CalidadStatusLiberado = '{0}'", Liberado)
         End If
         If Entregado Then
            .AppendFormatLine("           AND P.CalidadStatusEntregado = '{0}'", Entregado)
         End If

         .AppendLine(" GROUP BY LCU.IdProducto , P.NombreProducto   ,C.CodigoCliente     ")
         .AppendLine("     ,C.NombreCliente")
         .AppendLine("     ,C.NombreDeFantasia")
         .AppendLine("     , P.CalidadStatusLiberado")
         .AppendLine("     , P.CalidadFechaLiberado")
         .AppendLine("     , P.CalidadUserLiberado")
         .AppendLine("     , P.CalidadStatusEntregado")
         .AppendLine("     , P.CalidadFechaEntregado")
         .AppendLine("     , P.CalidadUserEntregado")
         .AppendLine("     , P.CalidadFechaIngreso")
         .AppendLine("     , P.CalidadFechaEgreso")
         .AppendLine("     , P.CalidadNroCertificado")
         .AppendLine("     , P.CalidadFecCertificado")
         .AppendLine("     , P.CalidadUsrCertificado")
         .AppendLine("     , P.CalidadObservaciones")
         .AppendLine("     , P.CalidadFechaPreEnt")
         .AppendLine("     , P.CalidadFechaEntProg  ")
         .AppendLine("     , P.CalidadNumeroChasis")
         .AppendLine("     , P.CalidadNroCarroceria")
         .AppendLine("     , P.IdProductoTipoServicio")
         .AppendLine("     , P.CalidadNroDeMotor")
         .AppendLine("     , P.CalidadFechaEntReProg  ")
         .AppendLine("     , P.IdProductoModelo ")
         .AppendLine("     , P.CalidadNroCertEntregado")
         .AppendLine("     , P.CalidadFecCertEntregado")
         .AppendLine("     , P.CalidadUsrCertEntregado")
         .AppendLine("     , P.CalidadStatusLiberadoPDI")
         .AppendLine("     , P.CalidadFechaLiberadoPDI")
         .AppendLine("     , P.CalidadUserLiberadoPDI")
         .AppendLine("     , P.CalidadNroCertEObs")
         .AppendLine("     , P.CalidadNroRemito")

         dt = Me.GetDataTable(stbQuery.ToString())
      End With

      Return dt

   End Function

   Public Function GetVistaProductosBejerman(Base As String, NroChasis As String) As DataTable

      Dim stbQuery = New StringBuilder()
      Dim dt As New DataTable

      With stbQuery
         .AppendLine("SELECT * FROM " & Base & ".dbo.Vista_ArtPartidas VP")
         .AppendLine("  WHERE NOT EXISTS (SELECT NULL FROM Productos P")
         .AppendLine("  WHERE P.CalidadNumeroChasis = VP.stp_Partida collate Modern_Spanish_CI_AS)")
         .AppendFormat(" AND VP.stpDep_Cod = 'PCH' ")
         If Not String.IsNullOrEmpty(NroChasis) Then
            .AppendFormatLine("           AND VP.stp_Partida LIKE '%{0}%'", NroChasis)
         End If
      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function
   Public Function GetInformeDeChasis(idProducto As String, fechaDesde As Date?,
                                      fechaHasta As Date?, IdCliente As Long,
                                      Chasis As List(Of String), Modelo As Integer, base As String) As DataTable

      Dim stb = New StringBuilder()
      With stb
         If idProducto = String.Empty And IdCliente = 0 And Modelo = 0 And fechaDesde Is Nothing Then
            .AppendLine("   SELECT 'NO INICIADOS' AS Chasis
             ,NULL as IdProducto, NULL as CalidadFechaIngreso, Null as CalidadFechaEgreso
            ,NULL as NombreProducto
            ,NULL as CalidadFechaLiberado, NULL as CalidadUserLiberado
            ,NULL as CalidadFechaLiberadoPDI 
            ,NULL as CalidadFechaEntregado, NULL as CalidadUserEntregado
            ,NULL as CodigoCliente, NULL as NombreCliente, NULL as NombreDeFantasia, NULL as NombreProductoModelo
            , VP.* , REPLACE( art_DescGen,'CHASIS ','') AS art_DescGen   FROM SBDAMETA.dbo.Vista_ArtPartidas VP
             WHERE NOT EXISTS (SELECT NULL FROM Productos P
             WHERE P.CalidadNumeroChasis = VP.stp_Partida collate Modern_Spanish_CI_AS AND P.IdProducto not like '%R%'  )
             AND 'NO INICIADOS' IN (")
            For Each tipo As String In Chasis
               .AppendFormat("'{0}',", tipo)
            Next
            .Remove(.Length - 1, 1)
            .AppendFormat(")")
            .AppendFormatLine(" AND VP.stpDep_Cod = 'PCH' ")
            .AppendLine(" UNION ")
         End If
         .AppendLine("		SELECT CASE WHEN P.CalidadFechaLiberado is NULL THEN 
          CASE WHEN ( SELECT MIN(CASE WHEN CLCP.CincoSFecha is null THEN CLCP.CincoSFechaC ELSE CASE WHEN CLCP.CincoSFechaC IS NULL THEN CLCP.CincoSFecha ELSE 
          CASE WHEN CLCP.CincoSFecha < CLCP.CincoSFechaC THEN CLCP.CincoSFecha ELSE CLCP.CincoSFechaC END END END)
          FROM CalidadListasControlProductos CLCP       
	       INNER JOIN CalidadListasControl CLC ON CLC.IdListaControl = CLCP.IdListaControl
          WHERE CLCP.IdProducto = P.IdProducto) is null ")
         ' AND CLC.BloqueaFechaIngreso = 'True'
         .AppendLine(" THEN 'NO INICIADOS' ELSE")
         .AppendLine(" 'EN LINEA' END ")
         .AppendLine("	ELSE 
	                     CASE WHEN P.CalidadFechaEntregado is null 
	                             THEN CASE WHEN P.CalidadFechaLiberado is null THEN 'EN LINEA' ELSE 'LIBERADOS' END 
	                     ELSE 'ENTREGADOS' 
	                     END
	                     END AS Chasis
            ,P.IdProducto, P.CalidadFechaIngreso, P.CalidadFechaEgreso
            ,P.NombreProducto
            ,P.CalidadFechaLiberado,  P.CalidadUserLiberado
            ,P.CalidadFechaLiberadoPDI
            ,P.CalidadFechaEntregado,  P.CalidadUserEntregado
            ,C.CodigoCliente, C.NombreCliente, C.NombreDeFantasia, CPM.NombreProductoModelo
            , VP.* , REPLACE( art_DescGen,'CHASIS ','') AS art_DescGen  ")

         .AppendLine(" FROM " & base & ".dbo.Vista_ArtPartidas VP")
         .AppendLine("  INNER JOIN Productos P ON P.CalidadNumeroChasis = VP.stp_Partida collate SQL_Latin1_General_CP1_CI_AS")
         .AppendLine("   LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto
                         LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente")
         .AppendLine("   LEFT JOIN CalidadProductosModelos CPM ON CPM.IdProductoModelo = P.IdProductoModelo")
         .AppendLine(" WHERE 1 = 1")
         .AppendFormat(" AND VP.stpDep_Cod = 'PCH' ")
         .AppendLine(" AND P.IdProducto not like '%R%' ")
         If fechaDesde.HasValue Then
            .AppendFormat("	   AND P.CalidadFechaIngreso >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormat("      AND P.CalidadFechaIngreso <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia, True))
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" AND P.{0} = '{1}'", Entidades.Producto.Columnas.IdProducto.ToString(), idProducto)
         End If

         .AppendLine("  AND CASE when P.IdProducto is null THEN 'NO INICIADOS' ELSE 
                         Case WHEN P.CalidadFechaLiberado is NULL THEN 
          CASE WHEN ( SELECT MIN(CASE WHEN CLCP.CincoSFecha is null THEN CLCP.CincoSFechaC ELSE CASE WHEN CLCP.CincoSFechaC IS NULL THEN CLCP.CincoSFecha ELSE 
          CASE WHEN CLCP.CincoSFecha < CLCP.CincoSFechaC THEN CLCP.CincoSFecha ELSE CLCP.CincoSFechaC END END END)
         FROM CalidadListasControlProductos CLCP       
          INNER JOIN CalidadListasControl CLC ON CLC.IdListaControl = CLCP.IdListaControl
          WHERE CLCP.IdProducto = P.IdProducto) is null")
         ' AND CLC.BloqueaFechaIngreso = 'True'
         .AppendLine(" THEN 'NO INICIADOS' ELSE  ")
         .AppendLine("  'EN LINEA' END")
         .AppendLine("ELSE 
         CASE WHEN P.CalidadFechaEntregado is null 
                 THEN CASE WHEN P.CalidadFechaLiberado is null THEN 'EN LINEA' ELSE 'LIBERADOS' END 
         ELSE 'ENTREGADOS' 
         END
         END END  IN (")
         For Each tipo As String In Chasis
            .AppendFormat("'{0}',", tipo)
         Next
         .Remove(.Length - 1, 1)
         .AppendFormat(")")

         '.AppendLine("   AND V.idTipoComprobante IN (")
         'For Each tipo As String In TiposComprobantes
         '   .AppendFormat("'{0}',", tipo)
         'Next
         '.Remove(.Length - 1, 1)
         '.AppendFormat(")")

         If Modelo <> 0 Then
            .AppendFormatLine("           AND P.IdProductoModelo = {0}", Modelo)
         End If

         'If Chasis = "LIBERADO" Then
         '   If fechaDesde.HasValue Then
         '      .AppendFormat("	   AND P.CalidadFechaLiberado >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
         '   End If
         '   If fechaHasta.HasValue Then
         '      .AppendFormat("      AND P.CalidadFechaLiberado <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia, True))
         '   End If
         'End If
         If IdCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", IdCliente)
         End If
         .AppendLine("   order by Chasis")
         'If Not String.IsNullOrEmpty(NroChasis) Then
         '   .AppendFormatLine("           AND VP.stp_Partida LIKE '%{0}%'", NroChasis)
         'End If
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetDescripcionProducto(IdProducto As String) As String

      Dim stbQuery = New StringBuilder()
      Dim dt As DataTable
      With stbQuery
         .AppendLine("SELECT NombreProducto FROM Productos")
         .AppendLine(" WHERE IdProducto = '" & IdProducto & "'")
         dt = Me.GetDataTable(stbQuery.ToString())
      End With
      Return dt.Rows(0)("NombreProducto").ToString()

   End Function

   Public Function GetStockValorizado(sucursales As Entidades.Sucursal(),
                                      depositos As Entidades.SucursalDeposito(),
                                      ubicacion As Entidades.SucursalUbicacion,
                                      idProducto As String,
                                      idMarca As Integer,
                                      idRubro As Integer,
                                      idSubRubro As Integer,
                                      anchoIdProducto As String,
                                      fechaHasta As Date?,
                                      idListaPrecios As Integer,
                                      blnPreciosConIVA As Boolean,
                                      idProveedor As Long,
                                      habitual As Boolean,
                                      cotizacionDolar As Decimal,
                                      decimalesRedondeo As Integer,
                                      activos As Entidades.Publicos.SiNoTodos) As DataTable

      'Campos a utilizar para obtener los 3 precios del sistema
      Dim campoPrecioFabrica As String = "PS.PrecioFabrica"
      Dim campoPrecioCosto As String = "PS.PrecioCosto"
      Dim campoPrecioVenta As String = "PSP.PrecioVenta"

      If fechaHasta.HasValue Then
         fechaHasta = fechaHasta.Value.UltimoSegundoDelDia()

         Dim formatoPrecioHistorico As String = "(SELECT TOP 1 {0} FROM HistorialPrecios HP WHERE HP.IdSucursal = PS.IdSucursal AND HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{1}' AND HP.IdListaPrecios = {2} ORDER BY FechaHora DESC)"

         'En caso de que lo esté ejecutando a una fecha, los campos de precios pasan a ser una subconsulta a la tabla de Historico de Precios
         campoPrecioFabrica = String.Format(formatoPrecioHistorico, "HP.PrecioFabrica", ObtenerFecha(fechaHasta.Value, True), "-1")
         campoPrecioCosto = String.Format(formatoPrecioHistorico, "HP.PrecioCosto", ObtenerFecha(fechaHasta.Value, True), "-1")
         campoPrecioVenta = String.Format(formatoPrecioHistorico, "HP.PrecioVenta", ObtenerFecha(fechaHasta.Value, True), "idListaPrecios")
      End If


      Dim formatoPrecioEmbalaje As String = "({0} / CASE WHEN P.PrecioPorEmbalaje = 'True' THEN CASE WHEN P.Embalaje = 0 THEN 1 ELSE ISNULL(P.Embalaje, 1) END ELSE 1 END)"
      Dim formatoMoneda As String = "({0} * CASE WHEN MO.IdMoneda = 1 THEN 1 ELSE {1} END)"

      'Le aplico a cada campo la lógica para calcular el PrecioPorEmbalaje (formatoPrecioEmbalaje) y luego la lógica para calcular el precio de los productos en Dolares (formatoMoneda)
      campoPrecioFabrica = String.Format(formatoMoneda, String.Format(formatoPrecioEmbalaje, campoPrecioFabrica), cotizacionDolar)
      campoPrecioCosto = String.Format(formatoMoneda, String.Format(formatoPrecioEmbalaje, campoPrecioCosto), cotizacionDolar)
      campoPrecioVenta = String.Format(formatoMoneda, String.Format(formatoPrecioEmbalaje, campoPrecioVenta), cotizacionDolar)


      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT S.IdSucursal")
         .AppendFormatLine("      ,S.Nombre as NombreSucursal")
         .AppendFormatLine("      ,RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto", anchoIdProducto)
         .AppendFormatLine("      ,P.NombreProducto")
         .AppendFormatLine("      ,P.IdUnidadDeMedida")
         .AppendFormatLine("      ,P.Tamano")
         .AppendFormatLine(" 	    ,P.IdMarca")
         .AppendFormatLine("      ,M.NombreMarca")
         .AppendFormatLine("      ,P.IdRubro")
         .AppendFormatLine("      ,R.NombreRubro")
         .AppendFormatLine("      ,MO.IdMoneda")
         .AppendFormatLine("      ,P.PrecioPorEmbalaje")
         .AppendFormatLine("      ,P.Embalaje")
         If Not fechaHasta.HasValue Then
            .AppendFormatLine("      ,ROUND(PS.Stock, {0}) AS Stock", decimalesRedondeo)
         Else
            'En caso de que lo esté a una fecha, el stock se calcula como el stock actual +/- los movimientos de stock posteriores a fecha indicada
            .AppendFormatLine("      ,ROUND(PS.Stock + ISNULL((SELECT SUM(ISNULL(mcp.Cantidad, 0)) * -1 cant")
            .AppendFormatLine("                                  FROM Productos P2")
            .AppendFormatLine("                                  LEFT JOIN MovimientosStockProductos MCP ON P2.IdProducto = MCP.IdProducto")
            .AppendFormatLine("                                  LEFT JOIN MovimientosStock MC ON MC.IdSucursal = MCP.IdSucursal AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento AND MC.NumeroMovimiento = MCP.NumeroMovimiento	")
            .AppendFormatLine("                                 WHERE P2.IdProducto = P.IdProducto")
            .AppendFormatLine("                                   AND MC.FechaMovimiento > '{0}'", ObtenerFecha(fechaHasta.Value, True))
            .AppendFormatLine("                                 GROUP BY MCP.IdProducto), 0)")
            .AppendFormatLine("                      + ISNULL((SELECT SUM(ISNULL(mvp.Cantidad, 0)) * -1 cant")
            .AppendFormatLine("                                  FROM Productos P3")
            .AppendFormatLine("                                  LEFT JOIN MovimientosStockProductos MVP ON P3.IdProducto = MVP.IdProducto")
            .AppendFormatLine("                                  LEFT JOIN MovimientosStock MV ON MV.IdSucursal = MVP.IdSucursal AND MV.IdTipoMovimiento = MVP.IdTipoMovimiento AND MV.NumeroMovimiento = MVP.NumeroMovimiento")
            .AppendFormatLine("                                 WHERE P3.IdProducto = P.IdProducto")
            .AppendFormatLine("                                   AND MV.FechaMovimiento > '{0}'", ObtenerFecha(fechaHasta.Value, True))
            .AppendFormatLine("                                 GROUP BY MVP.IdProducto), 0)")
            .AppendFormatLine("            , {0}) Stock", decimalesRedondeo)
         End If

         .AppendFormatLine("      ,ROUND(PS.StockInicial, {0}) AS StockInicial", decimalesRedondeo)
         '-- REQ-43821.- ----------------------------------------------------------------------------------------------------------------
         .AppendFormatLine("      ,P.Kilos")
         '-------------------------------------------------------------------------------------------------------------------------------
         .AppendFormatLine("      ,SD.NombreDeposito")
         .AppendFormatLine("      ,ROUND(PD.Stock, {0}) AS StockDeposito", decimalesRedondeo)
         .AppendFormatLine("      ,SU.NombreUbicacion")
         .AppendFormatLine("      ,ROUND(PU.Stock, {0}) AS StockUbicacion", decimalesRedondeo)

         '2019-11-08 -- SPC Los campos de stock valorizados se van a agregar en la Regla con Columnas con Expresión para no recargar y complejizar el query
         ' '' ''esto es por si el calculo del stock valorizado lo hizo hasta la actualidad y no hasta una fecha
         '' ''If Not fechaHasta.HasValue Then
         '' ''   If blnPreciosConIVA Then
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoFabricaConImpuestos", campoPrecioFabrica, decimalesRedondeo)
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoCostoConImpuestos", campoPrecioCosto, decimalesRedondeo)
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoVentaConImpuestos", campoPrecioVenta, decimalesRedondeo)
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoFabricaSinImpuestos", CalculosImpositivos.ObtenerPrecioSinImpuestos(campoPrecioFabrica, "P"), decimalesRedondeo)
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoCostoSinImpuestos", CalculosImpositivos.ObtenerPrecioSinImpuestos(campoPrecioCosto, "P"), decimalesRedondeo)
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoVentaSinImpuestos", CalculosImpositivos.ObtenerPrecioSinImpuestos(campoPrecioVenta, "P"), decimalesRedondeo)
         '' ''   Else
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoFabricaConImpuestos", CalculosImpositivos.ObtenerPrecioConImpuestos(campoPrecioFabrica, "P"), decimalesRedondeo)
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoCostoConImpuestos", CalculosImpositivos.ObtenerPrecioConImpuestos(campoPrecioCosto, "P"), decimalesRedondeo)
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoVentaConImpuestos", CalculosImpositivos.ObtenerPrecioConImpuestos(campoPrecioVenta, "P"), decimalesRedondeo)
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoFabricaSinImpuestos", campoPrecioFabrica, decimalesRedondeo)
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoCostoSinImpuestos", campoPrecioCosto, decimalesRedondeo)
         '' ''      .AppendFormatLine("      ,ROUND({0} * PS.Stock, {1}) AS ValorizadoVentaSinImpuestos", campoPrecioVenta, decimalesRedondeo)
         '' ''   End If
         '' ''Else
         '' ''   'SPC: Se ocultó el control de fecha en pantalla y se desactivo esta funcionalidad por dos problemas pendientes de resolver
         '' ''   '     1.- por algún motivo está devolviendo NULL en el precio cuando debería traer valor
         '' ''   '     2.- el para calcular el stock valorizado está tomando el precio histórico y lo multiplica por el stock actual
         '' ''   ' '' ''aca puso una fecha para sacar el stock hasta la misma
         '' ''   ' '' ''calcula el precio de la tabla HistorialPrecios
         '' ''   '' ''If mostrarPreciosConIVA Then
         '' ''   '' ''   If blnPreciosConIVA Then
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioFabrica FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' ORDER BY FechaHora DESC)*PS.Stock as ValorizadoFabrica", ObtenerFecha(fechaHasta.Value, True))
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioCosto FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' ORDER BY FechaHora DESC)*PS.Stock as ValorizadoCosto", ObtenerFecha(fechaHasta.Value, True))
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioVenta FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' AND IdListaPrecios = {1} ORDER BY FechaHora DESC)*PS.Stock as ValorizadoVenta", ObtenerFecha(fechaHasta.Value, True), idListaPrecios)
         '' ''   '' ''   Else
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioFabrica FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' ORDER BY FechaHora DESC)*PS.Stock * (1+(P.Alicuota/100)) as ValorizadoFabrica", ObtenerFecha(fechaHasta.Value, True))
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioCosto FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' ORDER BY FechaHora DESC)*PS.Stock* (1+(P.Alicuota/100)) as ValorizadoCosto", ObtenerFecha(fechaHasta.Value, True))
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioVenta FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' AND IdListaPrecios = {1} ORDER BY FechaHora DESC)*PS.Stock * (1+(P.Alicuota/100)) as ValorizadoVenta", ObtenerFecha(fechaHasta.Value, True), idListaPrecios)
         '' ''   '' ''   End If
         '' ''   '' ''Else
         '' ''   '' ''   If blnPreciosConIVA Then
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioFabrica FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' ORDER BY FechaHora DESC)/(1+(P.Alicuota/100))*PS.Stock as ValorizadoFabrica", ObtenerFecha(fechaHasta.Value, True))
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioCosto FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' ORDER BY FechaHora DESC)/(1+(P.Alicuota/100))*PS.Stock as ValorizadoCosto", ObtenerFecha(fechaHasta.Value, True))
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioVenta FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' AND IdListaPrecios = {1} ORDER BY FechaHora DESC)/(1+(P.Alicuota/100))*PS.Stock as ValorizadoVenta", ObtenerFecha(fechaHasta.Value, True), idListaPrecios)
         '' ''   '' ''   Else
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioFabrica FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' ORDER BY FechaHora DESC)*PS.Stock as ValorizadoFabrica", ObtenerFecha(fechaHasta.Value, True))
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioCosto FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' ORDER BY FechaHora DESC)*PS.Stock as ValorizadoCosto", ObtenerFecha(fechaHasta.Value, True))
         '' ''   '' ''      .AppendFormatLine("      ,(SELECT TOP 1 HP.PrecioVenta FROM HistorialPrecios HP WHERE HP.IdProducto = P.IdProducto AND HP.FechaHora <= '{0}' AND IdListaPrecios = {1} ORDER BY FechaHora DESC)*PS.Stock as ValorizadoVenta", ObtenerFecha(fechaHasta.Value, True), idListaPrecios)
         '' ''   '' ''   End If
         '' ''   '' ''End If

         '' ''End If
         If blnPreciosConIVA Then
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioFabricaConImpuestos", campoPrecioFabrica, decimalesRedondeo)
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioCostoConImpuestos", campoPrecioCosto, decimalesRedondeo)
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioVentaConImpuestos", campoPrecioVenta, decimalesRedondeo)
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioFabricaSinImpuestos", CalculosImpositivos.ObtenerPrecioSinImpuestos(campoPrecioFabrica, "P"), decimalesRedondeo)
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioCostoSinImpuestos", CalculosImpositivos.ObtenerPrecioSinImpuestos(campoPrecioCosto, "P"), decimalesRedondeo)
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioVentaSinImpuestos", CalculosImpositivos.ObtenerPrecioSinImpuestos(campoPrecioVenta, "P"), decimalesRedondeo)
         Else
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioFabricaConImpuestos", CalculosImpositivos.ObtenerPrecioConImpuestos(campoPrecioFabrica, "P"), decimalesRedondeo)
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioCostoConImpuestos", CalculosImpositivos.ObtenerPrecioConImpuestos(campoPrecioCosto, "P"), decimalesRedondeo)
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioVentaConImpuestos", CalculosImpositivos.ObtenerPrecioConImpuestos(campoPrecioVenta, "P"), decimalesRedondeo)
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioFabricaSinImpuestos", campoPrecioFabrica, decimalesRedondeo)
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioCostoSinImpuestos", campoPrecioCosto, decimalesRedondeo)
            .AppendFormatLine("      ,ROUND({0}, {1}) AS PrecioVentaSinImpuestos", campoPrecioVenta, decimalesRedondeo)
         End If

         .AppendFormatLine("  FROM Productos P")
         .AppendFormatLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto")

         .AppendFormatLine("	LEFT JOIN ProductosDepositos PD ON P.IdProducto = PD.IdProducto AND PD.IdSucursal = PS.IdSucursal")
         .AppendFormatLine("	LEFT JOIN SucursalesDepositos SD ON SD.IdSucursal = PD.IdSucursal AND SD.IdDeposito = PD.IdDeposito ")
         .AppendFormatLine("	LEFT JOIN ProductosUbicaciones PU ON PU.IdProducto = PD.IdProducto AND PU.IdSucursal = PD.IdSucursal AND PU.IdDeposito = PD.IdDeposito ")
         .AppendFormatLine("	LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = PU.IdSucursal AND SU.IdDeposito = PU.IdDeposito AND SU.IdUbicacion = PU.IdUbicacion")


         .AppendFormatLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = P.IdProducto")
         .AppendFormatLine("                                          AND PSP.IdSucursal = PS.IdSucursal")
         .AppendFormatLine("                                          AND PSP.IdListaPrecios = {0}", idListaPrecios)
         .AppendFormatLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendFormatLine("	LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("  LEFT JOIN Monedas MO ON MO.IdMoneda = P.IdMoneda")
         .AppendFormatLine("	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")

         If idProveedor > 0 Then
            If habitual Then
               .AppendFormatLine("	LEFT JOIN Proveedores PR ON PR.IdProveedor = P.IdProveedor")
            Else
               .AppendFormatLine("	LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.IdProducto")
               .AppendFormatLine("	LEFT JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor")
            End If
         End If

         .AppendLine(" WHERE 1 = 1")
         GetListaSucursalesMultiples(stb, sucursales, "PS")
         GetListaDepositosMultiples(stb, depositos, "PD")

         If ubicacion IsNot Nothing Then
            .AppendFormatLine("	AND SU.IdDeposito  = {0}", ubicacion.IdDeposito)
            .AppendFormatLine("	AND SU.IdUbicacion = {0}", ubicacion.IdUbicacion)
         End If

         .AppendLine("	AND P.AfectaStock = 'True'")   'Solo los productos valorizables

         'No puedo filtrar los que tienen stock porque tendría que evaluar el stock historico en caso de ejecutarlo a una fecha
         '.AppendLine("    AND PS.Stock <> 0 ")

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("	AND P.IdProducto = '{0}'", idProducto)
         End If
         If idMarca <> 0 Then
            .AppendFormatLine("	AND P.IdMarca = {0}", idMarca)
         End If
         If idRubro <> 0 Then
            .AppendFormatLine("	AND P.IdRubro = {0}", idRubro)
         End If
         If idSubRubro > 0 Then
            .AppendFormatLine("   AND P.IdSubRubro = {0}", idSubRubro)
         End If
         If idProveedor > 0 Then
            .AppendFormatLine("	AND PR.IdProveedor = {0}", idProveedor)
         End If

         ' # Activo
         If activos <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("	AND P.Activo = {0}", If(activos = Entidades.Publicos.SiNoTodos.SI, 1, 0))
         End If

         .AppendLine("	ORDER BY P.NombreProducto")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetAuditoriaProductos(fechaDesde As Date, fechaHasta As Date, idProducto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, incluirFoto:=False, espaciosID:=False, auditoria:=True)

         .AppendFormat(" WHERE P.FechaAuditoria >= '{0}'", ObtenerFecha(fechaDesde, False))
         .AppendFormat("   AND P.FechaAuditoria <= '{0}'", ObtenerFecha(fechaHasta.UltimoSegundoDelDia, True))

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND P.IdProducto = '{0}'", idProducto)
         End If
         .AppendLine(" ORDER BY P.IdProducto, P.FechaAuditoria")
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo(prefijo As String) As String
      Dim stb = New StringBuilder()

      With stb
         .AppendFormat("SELECT '{1}' + CONVERT(varchar(30), MAX(CONVERT(int,SUBSTRING(IdProducto, LEN('{1}') + 1,1000)))) AS {0} FROM Productos WHERE IdProducto LIKE '{1}%'", maximoKey, prefijo)
      End With

      Dim dt As DataTable = GetDataTable(stb.ToString())
      Dim val As String = ""

      If dt.Rows.Count > 0 AndAlso dt.Columns.Contains(maximoKey) AndAlso Not dt.Rows(0)(maximoKey).Equals(DBNull.Value) AndAlso
          Not String.IsNullOrEmpty(dt.Rows(0)(maximoKey).ToString()) Then
         val = dt.Rows(0)(maximoKey).ToString()
      End If

      Return val
   End Function

   Public Function GetPreciosProducto(idProducto As String, idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormat("SELECT PSP.IdProducto,").AppendLine()
         .AppendFormat("	  PSP.IdListaPrecios,").AppendLine()
         .AppendFormat("	  PSP.IdSucursal,").AppendLine()
         .AppendFormat("	  PSP.PrecioVenta,").AppendLine()
         .AppendFormat("	  PSP.PrecioVenta AS PrecioVentaBase,").AppendLine()
         .AppendFormat("	  0 AS PorcentajeBase,").AppendLine()
         .AppendFormat("	  PS.PrecioCosto,").AppendLine()
         .AppendFormat("	  CASE WHEN PS.PrecioCosto = 0 THEN 0 ELSE ((PSP.PrecioVenta / PS.PrecioCosto) - 1) * 100 END AS PorcentajeCosto,").AppendLine()
         .AppendFormat("	  LP.DescuentoRecargoPorc,").AppendLine()
         .AppendFormat("	  LP.NombreListaPrecios,").AppendLine()
         .AppendFormat("	  P.NombreProducto,").AppendLine()
         .AppendFormat("	  LP.Activa,").AppendLine()
         .AppendFormat("	  LP.PermiteUtilidadEnCero").AppendLine()
         .AppendFormat("  FROM ProductosSucursalesPrecios PSP").AppendLine()
         .AppendFormat(" INNER JOIN ListasDePrecios LP ON LP.IdListaPrecios = PSP.IdListaPrecios").AppendLine()
         '.AppendFormat(" INNER JOIN ProductosSucursalesPrecios PSP0 ON PSP0.IdListaPrecios = 0 AND PSP0.IdProducto = PSP.IdProducto AND PSP0.IdSucursal = PSP.IdSucursal").AppendLine()
         .AppendFormat(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PSP.IdProducto AND PS.IdSucursal = PSP.IdSucursal").AppendLine()
         .AppendFormat(" INNER JOIN Productos P ON P.IdProducto = PSP.IdProducto").AppendLine()
         '.AppendFormat("SELECT PSP.IdProducto,").AppendLine()
         '.AppendFormat("	    PSP.IdListaPrecios,").AppendLine()
         '.AppendFormat("  	    PSP.IdSucursal,").AppendLine()
         '.AppendFormat("  	    PSP.PrecioVenta,").AppendLine()
         '.AppendFormat("  	    PS.PrecioVenta AS PrecioVentaBase,").AppendLine()
         '.AppendFormat("  	    CASE WHEN PS.PrecioVenta = 0 THEN 0 ELSE ((PSP.PrecioVenta / PS.PrecioVenta)) END AS Porcentaje,").AppendLine()
         '.AppendFormat("  	    LP.NombreListaPrecios,").AppendLine()
         '.AppendFormat("       P.NombreProducto").AppendLine()
         '.AppendFormat("  FROM ProductosSucursalesPrecios PSP").AppendLine()
         '.AppendFormat(" INNER JOIN ListasDePrecios LP ON LP.IdListaPrecios = PSP.IdListaPrecios").AppendLine()
         '.AppendFormat(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PSP.IdProducto AND PS.IdSucursal = PSP.IdSucursal").AppendLine()
         '.AppendFormat(" INNER JOIN Productos P ON P.IdProducto = PSP.IdProducto").AppendLine()
         .AppendFormat(" WHERE PSP.IdProducto = '{0}'", idProducto).AppendLine()
         .AppendFormat("   AND PSP.IdSucursal = {0}", idSucursal).AppendLine()
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetPreciosListasMultiples(sucursales() As Integer,
                                             marca As Integer, rubro As Integer, subRubro As Integer, producto As String,
                                             sinCosto As Boolean, sinVenta As Boolean,
                                             listas As List(Of Entidades.ListaDePrecios),
                                             costo As Boolean, stock As Boolean,
                                             idmoneda As Integer, tipocambio As Decimal,
                                             consultarPreciosOcultarProdNoAfectanStock As Boolean, strAnchoIdProducto As String,
                                             idProveedor As Long,
                                             conIVA As Boolean, preciosConIVA As Boolean,
                                             mostrarProveedorHabitual As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT PV1.IdSucursal")
         .AppendFormatLine("      ,PV1.NombreSucursal")
         .AppendFormatLine("      ,PV1.IdProducto")
         .AppendFormatLine("      ,PV1.NombreProducto")
         .AppendFormatLine("      ,PV1.NombreCorto")
         .AppendFormatLine("      ,PV1.Tamano")
         .AppendFormatLine("      ,PV1.IdMarca")
         .AppendFormatLine("      ,PV1.NombreMarca")
         .AppendFormatLine("      ,PV1.IdRubro")
         .AppendFormatLine("      ,PV1.NombreRubro")
         .AppendFormatLine("      ,PV1.IdSubRubro")
         .AppendFormatLine("      ,PV1.NombreSubRubro")
         .AppendFormatLine("      ,PV1.IdUnidadDeMedida")
         .AppendFormatLine("      ,PV1.PrecioFabrica")
         .AppendFormatLine("      ,PV1.PrecioCosto")
         .AppendFormatLine("      ,PV1.Stock")
         .AppendFormatLine("      ,PV1.IdMoneda")
         .AppendFormatLine("      ,PV1.Simbolo")
         .AppendFormatLine("      ,PV1.FechaActualizacionCosto")
         .AppendFormatLine("      ,PV1.IdProveedor")
         .AppendFormatLine("      ,PV1.NombreProveedor")
         For Each lis As Entidades.ListaDePrecios In listas
            '-- REQ-35893.- --------------------------------------------------------------------------
            .AppendFormatLine("      ,(CASE WHEN PV1.PrecioCosto>0 THEN ((SUM(pv_{0}) / PV1.PrecioCosto) - 1) * 100 ELSE 0 END) dr_{0},(SUM(pv_{0})/{1}) pv_{0},MAX(fa_{0}) fa_{0}", lis.IdListaPrecios, If(lis.DivideCuota, lis.DivideCuotaCantidad, 1))
            '-----------------------------------------------------------------------------------------
         Next
         .AppendFormatLine("  FROM (SELECT S.IdSucursal")
         .AppendFormatLine("              ,S.Nombre NombreSucursal")
         .AppendFormatLine("              ,RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto", strAnchoIdProducto)
         .AppendFormatLine("              ,P.NombreProducto")
         .AppendFormatLine("              ,P.NombreCorto")
         .AppendFormatLine("              ,P.Tamano")
         .AppendFormatLine("              ,P.IdMarca")
         .AppendFormatLine("              ,M.NombreMarca")
         .AppendFormatLine("              ,P.IdRubro")
         .AppendFormatLine("              ,R.NombreRubro")
         .AppendFormatLine("              ,P.IdUnidadDeMedida")
         If conIVA Then
            If preciosConIVA Then
               .AppendFormatLine("              ,PS.PrecioFabrica")
               .AppendFormatLine("              ,PS.PrecioCosto")
            Else
               .AppendFormatLine("              ,{0} PrecioFabrica", CalculosImpositivos.ObtenerPrecioConImpuestos("PS.PrecioFabrica", "P"))
               .AppendFormatLine("              ,{0} PrecioCosto", CalculosImpositivos.ObtenerPrecioConImpuestos("PS.PrecioCosto", "P"))
            End If
         Else
            If preciosConIVA Then
               .AppendFormatLine("              ,{0} PrecioFabrica", CalculosImpositivos.ObtenerPrecioSinImpuestos("PS.PrecioFabrica", "P"))
               .AppendFormatLine("              ,{0} PrecioCosto", CalculosImpositivos.ObtenerPrecioSinImpuestos("PS.PrecioCosto", "P"))
            Else
               .AppendFormatLine("              ,PS.PrecioFabrica")
               .AppendFormatLine("              ,PS.PrecioCosto")
            End If
         End If
         .AppendFormatLine("              ,PS.FechaActualizacion FechaActualizacionCosto")
         .AppendFormatLine("              ,CASE WHEN P.IdMoneda = Mo.IdMoneda THEN PSP.PrecioVenta ELSE CASE WHEN P.IdMoneda = 1 THEN PSP.PrecioVenta / {0} ELSE PSP.PrecioVenta * {0} END END AS PrecioVenta", tipocambio)
         .AppendFormatLine("              ,PSP.FechaActualizacion")
         .AppendFormatLine("              ,PSP.IdListaPrecios")
         .AppendFormatLine("              ,PSP.IdListaPrecios_pv")
         .AppendFormatLine("              ,PSP.IdListaPrecios_fa")
         .AppendFormatLine("              ,P.IdMoneda")
         .AppendFormatLine("              ,Mo.Simbolo")
         .AppendFormatLine("              ,PS.Stock")
         .AppendFormatLine("              ,P.IdSubRubro")
         .AppendFormatLine("              ,SR.NombreSubRubro")
         .AppendFormatLine("              ,PR.IdProveedor")
         .AppendFormatLine("              ,PR.NombreProveedor")
         .AppendFormatLine("          FROM Productos P")
         .AppendFormatLine("          LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto")
         .AppendFormatLine("          LEFT JOIN (SELECT ")
         If conIVA Then
            If preciosConIVA Then
               .AppendFormatLine("                            PSP1.PrecioVenta")
            Else
               .AppendFormatLine("                            ({0}) AS PrecioVenta", CalculosImpositivos.ObtenerPrecioConImpuestos("PSP1.PrecioVenta", "P1"))
            End If
         Else
            If preciosConIVA Then
               .AppendFormatLine("                            ({0}) AS PrecioVenta", CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP1.PrecioVenta", "P1"))
            Else
               .AppendFormatLine("                            PSP1.PrecioVenta")
            End If
         End If
         .AppendFormatLine("                            , PSP1.IdProducto, PSP1.IdSucursal, PSP1.FechaActualizacion, PSP1.IdListaPrecios, 'pv_' + CONVERT(VARCHAR(MAX), PSP1.IdListaPrecios) AS IdListaPrecios_pv , 'fa_' + CONVERT(VARCHAR(MAX), PSP1.IdListaPrecios) AS IdListaPrecios_fa")
         .AppendFormatLine("                       FROM ProductosSucursalesPrecios PSP1")
         .AppendFormatLine("                      INNER JOIN Productos P1 ON P1.IdProducto = PSP1.IdProducto) PSP ON PSP.IdProducto = P.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
         .AppendFormatLine("          LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendFormatLine("          LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("          LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("          LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("          LEFT JOIN Proveedores PR ON P.IdProveedor = PR.IdProveedor")
         If idmoneda = -1 Then
            .AppendFormatLine("          LEFT JOIN Monedas Mo ON Mo.IdMoneda = P.IdMoneda")
         Else
            .AppendFormatLine("          LEFT JOIN Monedas Mo ON Mo.IdMoneda =  {0}", idmoneda)
         End If
         .AppendLine(" LEFT JOIN ProductosProveedores PPH ON PPH.IdProducto = P.IdProducto AND PPH.IdProveedor = P.IdProveedor")

         If idProveedor > 0 Then
            'GAR: 13/09/2016 Puede no tener compras
            If mostrarProveedorHabitual Then
               .AppendLine(" LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.Idproducto AND PP.IdProveedor = " & idProveedor.ToString())
            Else
               .AppendLine(" INNER JOIN ProductosProveedores PP ON PP.IdProducto = P.Idproducto AND PP.IdProveedor = " & idProveedor.ToString())
            End If
         End If

         .AppendFormatLine("         WHERE PS.IdSucursal in (0")
         For Each suc As Integer In sucursales
            .AppendFormatLine("," & suc.ToString())
         Next
         .AppendFormatLine(") ")


         .AppendFormatLine("	        AND P.Activo = 'True'")   'Solo permito elegir los productos Activos

         If marca <> 0 Then
            .AppendFormatLine("        AND P.IdMarca = {0}", marca)
         End If
         If rubro <> 0 Then
            .AppendFormatLine("        AND P.IdRubro = {0}", rubro)
         End If
         If subRubro <> 0 Then
            .AppendFormatLine("        AND P.IdSubRubro = {0}", subRubro)
         End If
         If Not String.IsNullOrEmpty(producto) Then
            .AppendFormatLine("        AND P.IdProducto = '{0}'", producto)
         End If

         If sinCosto Then
            .AppendFormatLine("        AND PS.PrecioCosto = 0")
         End If

         If consultarPreciosOcultarProdNoAfectanStock Then
            .AppendFormatLine("        AND P.AfectaStock = 'True'")
         End If

         'If idProveedor > 0 Then
         '   .AppendFormatLine("        AND PR.IdProveedor = {0}", idProveedor)
         'End If

         If mostrarProveedorHabitual Then
            .AppendLine("  AND  P.IdProveedor = " & idProveedor.ToString())
         End If


         .AppendFormatLine("    ) AS PS")
         .AppendFormatLine("PIVOT")
         .AppendFormatLine(" (")
         .AppendFormatLine("   SUM(PrecioVenta) FOR IdListaPrecios_pv IN (")
         Dim primero As Boolean = True
         For Each lis As Entidades.ListaDePrecios In listas
            If Not primero Then .AppendFormatLine(",")
            primero = False
            .AppendFormatLine("[pv_{0}]", lis.IdListaPrecios)
         Next
         .AppendFormatLine(")")
         .AppendFormatLine(" ) AS pv1")
         .AppendFormatLine("PIVOT")
         .AppendFormatLine(" (")
         .AppendFormatLine("   MAX(FechaActualizacion) FOR IdListaPrecios_fa IN (")
         primero = True
         For Each lis As Entidades.ListaDePrecios In listas
            If Not primero Then .AppendFormatLine(",")
            primero = False
            .AppendFormatLine("[fa_{0}]", lis.IdListaPrecios)
         Next
         .AppendFormatLine(")")
         .AppendFormatLine(" ) AS pv1")
         .AppendFormatLine(" GROUP BY PV1.IdSucursal")
         .AppendFormatLine("         ,PV1.NombreSucursal")
         .AppendFormatLine("         ,PV1.IdProducto")
         .AppendFormatLine("         ,PV1.NombreProducto")
         .AppendFormatLine("         ,PV1.NombreCorto")
         .AppendFormatLine("         ,PV1.Tamano")
         .AppendFormatLine("         ,PV1.IdMarca")
         .AppendFormatLine("         ,PV1.NombreMarca")
         .AppendFormatLine("         ,PV1.IdRubro")
         .AppendFormatLine("         ,PV1.NombreRubro")
         .AppendFormatLine("         ,PV1.IdUnidadDeMedida")
         .AppendFormatLine("         ,PV1.PrecioFabrica")
         .AppendFormatLine("         ,PV1.PrecioCosto")
         .AppendFormatLine("         ,PV1.FechaActualizacionCosto")
         .AppendFormatLine("         ,PV1.IdMoneda")
         .AppendFormatLine("         ,PV1.Simbolo")
         .AppendFormatLine("         ,PV1.Stock")
         .AppendFormatLine("         ,PV1.IdSubRubro")
         .AppendFormatLine("         ,PV1.NombreSubRubro")
         .AppendFormatLine("           ,PV1.IdProveedor")
         .AppendFormatLine("           ,PV1.NombreProveedor")
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetPreciosParaConsultaPorCuotaPorListaPrecios(idSucursal As Integer, idProducto As String,
                                                                   blnPreciosConIVA As Boolean, blnProductoUtilizaPrecioBarra As Boolean, decimales As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PSP.IdListaPrecios")
         .AppendLine("      ,LDP.NombreListaPrecios")
         .AppendLine("      ,LDP.NombreCortoListaPrecios")
         .AppendLine("      ,LDP.Orden")
         .AppendLine("      ,LDP.Activa")
         .AppendLine("      ,PSP.IdProducto")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,P.Alicuota")
         .AppendLine("      ,P.PorcImpuestoInterno")
         .AppendLine("      ,P.OrigenPorcImpInt")
         .AppendLine("      ,LDP.IdFormasPago")
         .AppendLine("      ,FP.DescripcionFormasPago")
         .AppendLine("      ,FP.CantidadCuotas")
         If blnPreciosConIVA Then
            .AppendFormat("      ,ROUND(({1}), {0}) AS PrecioVentaSinIVA", decimales,
                            CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta",
                                                                        "P.Alicuota",
                                                                        "P.PorcImpuestoInterno",
                                                                        "P.ImporteImpuestoInterno",
                                                                        "P.OrigenPorcImpInt")).AppendLine()
            .AppendFormat("      ,ROUND(PSP.PrecioVenta, {0}) as PrecioVentaConIVA", decimales).AppendLine()

            .AppendFormat("      ,ROUND(({1}) / CASE WHEN FP.CantidadCuotas = 0 THEN 1 ELSE ISNULL(FP.CantidadCuotas, 1) END, {0}) AS PrecioCuotaSinIVA", decimales,
                            CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta",
                                                                        "P.Alicuota",
                                                                        "P.PorcImpuestoInterno",
                                                                        "P.ImporteImpuestoInterno",
                                                                        "P.OrigenPorcImpInt")).AppendLine()
            .AppendFormat("      ,ROUND(PSP.PrecioVenta / CASE WHEN FP.CantidadCuotas = 0 THEN 1 ELSE ISNULL(FP.CantidadCuotas, 1) END , {0}) as PrecioCuotaConIVA", decimales).AppendLine()
         Else
            .AppendFormat("      ,ROUND(PSP.PrecioVenta, {0}) AS PrecioVentaSinIVA", decimales).AppendLine()
            .AppendFormat("      ,ROUND(({1}), {0}) AS PrecioVentaConIVA", decimales,
                            CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta",
                                                                        "P.Alicuota",
                                                                        "P.PorcImpuestoInterno",
                                                                        "P.ImporteImpuestoInterno",
                                                                        "P.OrigenPorcImpInt")).AppendLine()

            .AppendFormat("      ,ROUND(PSP.PrecioVenta / CASE WHEN FP.CantidadCuotas = 0 THEN 1 ELSE ISNULL(FP.CantidadCuotas, 1) END, {0}) as PrecioCuotaSinIVA", decimales).AppendLine()
            .AppendFormat("      ,ROUND(({1}) / CASE WHEN FP.CantidadCuotas = 0 THEN 1 ELSE ISNULL(FP.CantidadCuotas, 1) END, {0}) AS PrecioCuotaConIVA", decimales,
                            CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta",
                                                                        "P.Alicuota",
                                                                        "P.PorcImpuestoInterno",
                                                                        "P.ImporteImpuestoInterno",
                                                                        "P.OrigenPorcImpInt")).AppendLine()
         End If
         .AppendLine("      ,PSP.FechaActualizacion")

         .AppendLine("  FROM ProductosSucursalesPrecios PSP")

         .AppendLine("  LEFT JOIN Productos P ON P.IdProducto = PSP.IdProducto")
         .AppendLine("  LEFT JOIN ListasDePrecios LDP ON LDP.IdListaPrecios = PSP.IdListaPrecios")
         .AppendLine("  LEFT JOIN VentasFormasPago AS FP ON FP.IdFormasPago = LDP.IdFormasPago")

         .AppendFormat(" WHERE PSP.IdSucursal = {0}", idSucursal).AppendLine()
         If blnProductoUtilizaPrecioBarra Then
            .AppendFormat("   AND (P.IdProducto = '{0}' OR P.CodigoDeBarras = '{0}')", idProducto).AppendLine()
         Else
            .AppendFormat("   AND (P.IdProducto = '{0}')", idProducto).AppendLine()
         End If

         .AppendLine(" ORDER BY LdP.NombreListaPrecios")

      End With
      Return GetDataTable(stb.ToString())
   End Function


   Public Function GetPreciosParaConsultaPorCuotaPorFormaPago(idSucursal As Integer, idProducto As String, idListaPrecios As Integer,
                                                               blnPreciosConIVA As Boolean, blnProductoUtilizaPrecioBarra As Boolean, decimales As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PSP.IdListaPrecios")
         .AppendLine("      ,LDP.NombreListaPrecios")
         .AppendLine("      ,LDP.NombreCortoListaPrecios")
         .AppendLine("      ,PSP.IdProducto")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,P.Alicuota")
         .AppendLine("      ,P.PorcImpuestoInterno")
         .AppendLine("      ,P.OrigenPorcImpInt")
         .AppendLine("      ,FP.IdFormasPago")
         .AppendLine("      ,FP.DescripcionFormasPago")
         .AppendLine("      ,FP.CantidadCuotas")
         .AppendLine("      ,FP.OrdenFichas")
         If blnPreciosConIVA Then
            .AppendFormat("      ,ROUND(({1}), {0}) AS PrecioVentaSinIVA", decimales,
                            CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta",
                                                                        "P.Alicuota",
                                                                        "P.PorcImpuestoInterno",
                                                                        "P.ImporteImpuestoInterno",
                                                                        "P.OrigenPorcImpInt")).AppendLine()
            .AppendFormat("      ,ROUND(PSP.PrecioVenta, {0}) as PrecioVentaConIVA", decimales).AppendLine()
         Else
            .AppendFormat("      ,ROUND(PSP.PrecioVenta, {0}) AS PrecioVentaSinIVA", decimales).AppendLine()
            .AppendFormat("      ,ROUND(({1}), {0}) AS PrecioVentaConIVA", decimales,
                            CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta",
                                                                        "P.Alicuota",
                                                                        "P.PorcImpuestoInterno",
                                                                        "P.ImporteImpuestoInterno",
                                                                        "P.OrigenPorcImpInt")).AppendLine()
         End If
         .AppendFormat("      ,CONVERT(DECIMAL(9,{0}), 0) AS PrecioCuotaSinIVA", decimales).AppendLine()
         .AppendFormat("      ,CONVERT(DECIMAL(9,{0}), 0) AS PrecioCuotaConIVA", decimales).AppendLine()
         .AppendFormat("      ,CONVERT(DECIMAL(9,{0}), 0) AS PrecioFinalSinIVA", decimales).AppendLine()
         .AppendFormat("      ,CONVERT(DECIMAL(9,{0}), 0) AS PrecioFinalConIVA", decimales).AppendLine()
         .AppendLine("      ,PSP.FechaActualizacion")

         .AppendLine("  FROM ProductosSucursalesPrecios PSP")

         .AppendLine("  LEFT JOIN Productos P ON P.IdProducto = PSP.IdProducto")
         .AppendLine("  LEFT JOIN ListasDePrecios LDP ON LDP.IdListaPrecios = PSP.IdListaPrecios")
         .AppendLine(" CROSS JOIN VentasFormasPago AS FP") '' ON FP.IdFormasPago = LDP.IdFormasPago")

         .AppendFormat(" WHERE PSP.IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND FP.OrdenFichas > 0", idListaPrecios)
         If blnProductoUtilizaPrecioBarra Then
            .AppendFormat("   AND (P.IdProducto = '{0}' OR P.CodigoDeBarras = '{0}')", idProducto).AppendLine()
         Else
            .AppendFormat("   AND (P.IdProducto = '{0}')", idProducto).AppendLine()
         End If

         .AppendFormat("   AND PSP.IdListaPrecios = {0}", idListaPrecios)

         .AppendLine(" ORDER BY LdP.NombreListaPrecios")

      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetProductoParaAplicarDescuentosClientes(idCliente As Long,
                                                           Marcas As List(Of Entidades.Marca),
                                                       Rubros As List(Of Entidades.Rubro),
                                                       IdSubRubro As Integer,
                                                       IdProducto As String,
                                                       IdProveedor As Long,
                                                       Compuestos As String,
                                                       CodigoProducto As String,
                                                       NombreProducto As String,
                                                       Habitual As Boolean,
                                                       EsOferta As String,
                                                       codigoProductoProveedor As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT Cast(1 as bit) as Sel, P.idProducto")
         If IdProveedor = 0 And String.IsNullOrWhiteSpace(codigoProductoProveedor) Then
            .AppendLine("     , NULL CodigoProductoProveedor")
         Else
            .AppendLine("     , PP.CodigoProductoProveedor")
         End If
         .AppendLine("     , P.NombreProducto, M.NombreMarca, R.NombreRubro, P.EsOferta, CDP.DescuentoRecargoPorc1, CDP.DescuentoRecargoPorc2	  ")
         .AppendLine(",( SELECT TOP 1 PR.NombreProveedor  FROM ProductosProveedores PP")
         .AppendLine("   INNER JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor ")
         .AppendLine("   WHERE PP.IdProducto = P.IdProducto ")
         .AppendLine("   ORDER BY PP.UltimaFechaCompra desc) as UltimoProv ")
         .AppendLine("  FROM Productos P")
         .AppendFormat("  LEFT JOIN ClientesDescuentosProductos CDP ON P.IdProducto = CDP.IdProducto and CDP.IdCliente = {0} ", idCliente)
         .AppendLine("  LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca ")
         .AppendLine("  LEFT JOIN Rubros R On R.IdRubro = P.IdRubro")

         If Not (IdProveedor = 0 And String.IsNullOrWhiteSpace(codigoProductoProveedor)) Then
            .AppendLine("  LEFT JOIN ProductosProveedores PP ON P.IdProducto = PP.IdProducto ")
         End If

         If IdProveedor <> 0 Then
            .AppendLine("	LEFT JOIN Proveedores PV ON PP.IdProveedor = PV.IdProveedor")
         End If
         .AppendLine(" WHERE P.Activo = 1 ")

         If Marcas.Count > 0 Then
            .Append(" AND P.IdMarca IN (")
            For Each pr As Entidades.Marca In Marcas
               .AppendFormat(" {0},", pr.IdMarca)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If Rubros.Count > 0 Then
            .Append(" AND P.IdRubro IN (")
            For Each pr As Entidades.Rubro In Rubros
               .AppendFormat(" {0},", pr.IdRubro)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If IdSubRubro <> 0 Then
            .AppendLine("	AND P.IdSubRubro = " & IdSubRubro.ToString())
         End If

         If Not String.IsNullOrEmpty(IdProducto) Then
            .AppendLine("	AND P.IdProducto = '" & IdProducto & "'")
         End If

         If IdProveedor <> 0 Then
            .AppendLine("	AND PV.IdProveedor = " & IdProveedor.ToString())
         End If

         If Compuestos <> "TODOS" Then
            .AppendLine("      AND P.EsCompuesto = " & IIf(Compuestos = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(NombreProducto) Then
            'Si contiene espacio hago una busqueda por cada palabra
            If Not NombreProducto.Contains(" ") Then
               .AppendLine("   AND P.NombreProducto LIKE '%" & NombreProducto & "%'")
            Else
               Dim Palabras() As String = NombreProducto.Split(" "c)

               .Append("   AND ( 1=1 ")
               For Each Palabra As String In Palabras
                  .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
               Next

               .AppendLine("  )")
            End If
         Else
            If Not String.IsNullOrEmpty(CodigoProducto) Then
               .AppendLine("	AND P.IdProducto LIKE '%" & CodigoProducto & "%'")
            End If

         End If
         If Habitual Then
            .AppendLine("   AND P.IdProveedor = " & IdProveedor.ToString())
         End If

         If EsOferta <> "TODOS" Then
            .AppendLine(" AND P.EsOferta = '" & EsOferta & "' ")
         End If

         If Not String.IsNullOrWhiteSpace(codigoProductoProveedor) Then
            .AppendLine(" AND PP.CodigoProductoProveedor LIKE '%" & codigoProductoProveedor & "%' ")
         End If

         .AppendLine("	ORDER BY P.NombreProducto")


      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetFotos(idProductos As String()) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P.IdProducto, P.Foto, PW.Foto2, PW.Foto3")
         .AppendFormatLine("  FROM Productos P")
         .AppendFormatLine(" INNER JOIN ProductosWeb PW ON PW.IdProducto = P.IdProducto")
         .AppendFormatLine(" WHERE 1 = 1")
         GetListaMultiples(stb, idProductos, "P", "IdProducto", True)
      End With
      Return GetDataTable(stb.ToString())
   End Function
   ''' <summary>
   ''' Obtienen para un producto con atributos si tiene movimientos de compras-ventas.- 
   ''' </summary>
   ''' <param name="idProductos">Id de Producto</param>
   ''' <returns></returns>
   Public Function AtributoProductoMovimiento(idProductos As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT * FROM ")
         .AppendFormatLine("(	SELECT	MCP.IdProducto Producto, ")
         .AppendFormatLine("			PDR.IdSubRubro SubRubro")
         .AppendFormatLine("		FROM MovimientosStockProductos MCP")
         .AppendFormatLine("			INNER JOIN Productos PDR ON PDR.IdProducto = MCP.IdProducto")
         .AppendFormatLine("			LEFT JOIN SubRubros SBR ON SBR.IdSubRubro = PDR.IdSubRubro ")
         .AppendFormatLine("		WHERE MCP.IdProducto = '{0}'", idProductos.ToString())
         .AppendFormatLine("		AND   (CASE WHEN SBR.GrupoAtributo01 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo01  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine("			+ (CASE WHEN SBR.GrupoAtributo02 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo02  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine("			+ (CASE WHEN SBR.GrupoAtributo03 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo03  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine("			+ (CASE WHEN SBR.GrupoAtributo04 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo04  IS NULL THEN 0 ELSE 1 END) > 0")
         .AppendFormatLine("UNION ")
         .AppendFormatLine("	SELECT	MVP.IdProducto Producto, ")
         .AppendFormatLine("			PDR.IdSubRubro SubRubro")
         .AppendFormatLine("		FROM MovimientosStockProductos MVP")
         .AppendFormatLine("			INNER JOIN Productos PDR ON PDR.IdProducto = MVP.IdProducto ")
         .AppendFormatLine("			LEFT JOIN SubRubros SBR ON SBR.IdSubRubro = PDR.IdSubRubro ")
         .AppendFormatLine("		WHERE MVP.IdProducto = '{0}'", idProductos.ToString())
         .AppendFormatLine("		AND   (CASE WHEN SBR.GrupoAtributo01 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo01  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine("			+ (CASE WHEN SBR.GrupoAtributo02 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo02  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine("			+ (CASE WHEN SBR.GrupoAtributo03 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo03  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine("			+ (CASE WHEN SBR.GrupoAtributo04 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SBR.TipoAtributo04  IS NULL THEN 0 ELSE 1 END) > 0) AS A")
      End With
      Return GetDataTable(stb.ToString())
   End Function
   Public Function GetProductosParaActualizarPrecios2(sucursales() As Integer,
                                                       listas As List(Of Entidades.ListaDePrecios),
                                                       marcas As Entidades.Marca(),
                                                       rubros As Entidades.Rubro(),
                                                       subRubros As Entidades.SubRubro(),
                                                       subSubRubros As Entidades.SubSubRubro(),
                                                       idProducto As String,
                                                       idProveedor As Long,
                                                       sinCosto As Boolean,
                                                       sinVenta As Boolean,
                                                       compuestos As String,
                                                       fechaActualizadoDesde As Date, FechaActualizadoHasta As Date,
                                                       codigoProducto As String,
                                                       nombreProducto As String,
                                                       habitual As Boolean,
                                                       esOferta As String,
                                                       codigoProductoProveedor As String,
                                                       arrProductos As Entidades.Producto(),
                                                       strAnchoIdProducto As String,
                                                       formatoLike As String,
                                                       formatoLikeNombre As String,
                                                       idMoneda As Integer,
                                                       conStock As Entidades.Publicos.SiNoTodos) As DataTable
      'idSubRubro As Integer,
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT Cast(1 as bit) as Sel, S.IdSucursal")
         .AppendFormatLine("		,S.Nombre NombreSucursal")
         .AppendFormatLine("     ,RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto", strAnchoIdProducto)
         .AppendFormatLine("		,P.IdProducto IdProductoSinEspacios")
         .AppendFormatLine("     ,PP.CodigoProductoProveedor")
         .AppendFormatLine("		,P.NombreProducto")
         .AppendFormatLine("	   ,P.NombreCorto")
         .AppendFormatLine("		,P.Tamano")
         .AppendFormatLine("		,P.IdMarca")
         .AppendFormatLine("		,M.NombreMarca")
         .AppendFormatLine("		,P.IdRubro")
         .AppendFormatLine("		,R.NombreRubro")
         .AppendFormatLine("		,P.IdSubRubro")
         .AppendFormatLine("		,SR.NombreSubRubro")
         .AppendFormatLine("		,P.IdSubSubRubro")
         .AppendFormatLine("		,SSR.NombreSubSubRubro")
         .AppendFormatLine("		,P.IdUnidadDeMedida")
         .AppendFormatLine("		,P.Alicuota")
         .AppendFormatLine("		,Mo.Simbolo")
         .AppendFormatLine("     ,EsOferta")
         .AppendFormatLine("		,PS.PrecioFabrica")
         .AppendFormatLine("     ,CONVERT(DECIMAL(14,4), NULL) AS PrecioFabricaNuevo")
         .AppendFormatLine("     ,P.IdProveedor")
         .AppendFormatLine("   	,PRO.NombreProveedor")
         .AppendFormatLine("   	,PP.DescuentoRecargoPorc1")
         .AppendFormatLine("     ,CONVERT(DECIMAL(5,2), NULL) AS DescuentoRecargoPorcNuevo1")
         .AppendFormatLine(" 		,PP.DescuentoRecargoPorc2")
         .AppendFormatLine("     ,CONVERT(DECIMAL(5,2), NULL) AS DescuentoRecargoPorcNuevo2")
         .AppendFormatLine(" 		,PP.DescuentoRecargoPorc3")
         .AppendFormatLine("     ,CONVERT(DECIMAL(5,2), NULL) AS DescuentoRecargoPorcNuevo3")
         .AppendFormatLine(" 		,PP.DescuentoRecargoPorc4")
         .AppendFormatLine("     ,CONVERT(DECIMAL(5,2), NULL) AS DescuentoRecargoPorcNuevo4")
         .AppendFormatLine("		,PS.PrecioCosto")
         .AppendFormatLine("     ,CONVERT(DECIMAL(14,4), NULL) AS PrecioCostoNuevo")
         .AppendFormatLine("		,PS.FechaActualizacion") '# Fecha de Actualización de Costo

         If listas IsNot Nothing Then
            For Each lis As Entidades.ListaDePrecios In listas
               .AppendFormatLine("		,(CASE WHEN PS.PrecioCosto>0 THEN round((MAX(L.[IdLista_{0}])/PS.PrecioCosto-1) * 100,4) ELSE 0 END) AS Porc_{0}", lis.IdListaPrecios)
               .AppendFormatLine("     ,MAX(fecha_actualizacion_precio_{0}) fecha_actualizacion_precio_{0}", lis.IdListaPrecios)
               .AppendFormatLine("		,CONVERT(DECIMAL(5,2), NULL) AS PorcNuevo_{0}", lis.IdListaPrecios)
               .AppendFormatLine("		,MAX(L.[IdLista_{0}]) [IdLista_{0}]", lis.IdListaPrecios)
               .AppendFormatLine("		,CONVERT(DECIMAL(14,4), NULL) AS [IdListaNuevo_{0}]", lis.IdListaPrecios)
            Next
         End If

         .AppendFormatLine("		,PS.Stock  ")
         .AppendFormatLine("		,P.EsCompuesto")
         .AppendFormatLine("		,P.ActualizaPreciosSucursalesAsociadas")

         .AppendFormatLine(",( SELECT TOP 1 PR.NombreProveedor  FROM ProductosProveedores PP")
         .AppendFormatLine("   INNER JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor ")
         .AppendFormatLine("   WHERE PP.IdProducto = P.IdProducto ")
         .AppendFormatLine("   ORDER BY PP.UltimaFechaCompra desc) as UltimoProv")

         .AppendFormatLine(" FROM Productos P	")
         .AppendFormatLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto	")
         .AppendFormatLine("	LEFT JOIN Monedas Mo ON P.IdMoneda = Mo.IdMoneda")
         .AppendFormatLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal	")
         .AppendFormatLine("	LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca	")
         .AppendFormatLine("	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro	")
         .AppendFormatLine("	LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro	")
         .AppendFormatLine("	LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro	")
         .AppendFormatLine("	LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.IdProducto")
         If idProveedor > 0 Then
            .AppendFormatLine("   AND PP.IdProveedor = " + idProveedor.ToString())
         Else
            .AppendFormatLine("   AND PP.IdProveedor = P.IdProveedor")
         End If
         .AppendFormatLine(" 	LEFT JOIN Proveedores PRO ON PRO.IdProveedor = P.IdProveedor ")
         If listas IsNot Nothing AndAlso listas.Count > 0 Then
            .Append("	LEFT JOIN (SELECT IdProducto, IdSucursal,")
            For Each lis As Entidades.ListaDePrecios In listas
               .AppendFormat(" [{0}] as 'IdLista_{0}',[fecha_actualizacion_precio_{0}],", lis.IdListaPrecios)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine()
            .AppendLine(" FROM ")
            .AppendLine("(")
            .AppendLine("    SELECT psp.IdProducto, psp.IdSucursal,  psp.IdListaPrecios, psp.PrecioVenta, psp.FechaActualizacion, 'fecha_actualizacion_precio_' + CONVERT(VARCHAR(MAX), psp.IdListaPrecios) IdListaPrecios_1")
            .AppendLine("		FROM ProductosSucursalesPrecios psp")
            .AppendLine(") as t ")
            .AppendLine("pivot ")
            .AppendLine("(")
            .AppendLine("    sum(t.PrecioVenta) for IdListaPrecios in (")
            For Each lis As Entidades.ListaDePrecios In listas
               .AppendFormat("[{0}],", lis.IdListaPrecios)
            Next
            .Remove(.Length - 1, 1)
            .AppendLine(")")
            .AppendLine(") as p ")

            '# Pivot para Fecha de Actualización de cada Lista de Precios
            .AppendFormatLine("pivot ")
            .AppendFormatLine("(")
            .AppendFormatLine("    MAX(p.FechaActualizacion) for IdListaPrecios_1 in (")
            For Each lis As Entidades.ListaDePrecios In listas
               .AppendFormat("[fecha_actualizacion_precio_{0}],", lis.IdListaPrecios)
            Next
            .Remove(.Length - 1, 1)
            .AppendFormatLine(")) as x")

            .AppendLine(") AS L ON L.IdProducto = P.IdProducto And L.IdSucursal = PS.IdSucursal")
         End If

         If idProveedor > 0 And Not habitual Then
            .AppendLine("	LEFT JOIN Proveedores PV ON PP.IdProveedor = PV.IdProveedor")
         End If

         .AppendLine("	WHERE PS.IdSucursal in (0")
         For Each suc As Integer In sucursales
            If Integer.Parse(suc.ToString()) <> 0 Then
               .AppendLine("," & suc.ToString())
            End If
         Next
         .AppendLine(") ")
         .AppendLine("	And P.Activo = 'True'")   'Solo permito elegir los productos Activos

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subRubros, "P")
         GetListaSubSubRubrosMultiples(stb, subSubRubros, "P")

         'If idSubRubro <> 0 Then
         '   .AppendLine("	AND P.IdSubRubro = " & idSubRubro.ToString())
         'End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND P.IdProducto = '" & idProducto & "'")
         End If

         GetListaMultiples(stb, arrProductos, "P")

         If idProveedor > 0 And Not habitual Then
            .AppendLine("	AND PV.IdProveedor = " & idProveedor.ToString())
         End If

         If sinCosto Then
            .AppendLine("	AND PS.PrecioCosto = 0")
         End If

         If sinVenta Then
            'Controlo que alguno de los precios de venta este en cero, para eso multiplico los valores y si dan cero es porque alguna de las listas esta en cero
            .Append(" AND (")
            For Each lis As Entidades.ListaDePrecios In listas
               .AppendFormat("L.[IdLista_{0}]*", lis.IdListaPrecios)
            Next
            .Remove(.Length - 1, 1)
            .Append(") = 0")
            '---------------
         End If

         If compuestos <> "TODOS" Then
            .AppendLine("      AND P.EsCompuesto = " & IIf(compuestos = "SI", "1", "0").ToString())
         End If

         'Por ahora filtra de la lista BASE, pero deberia ser dinamico.
         If fechaActualizadoDesde.Year > 1 Then
            .AppendLine("	 AND PS.FechaActualizacion >= '" & fechaActualizadoDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	 AND PS.FechaActualizacion <= '" & FechaActualizadoHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If Not String.IsNullOrEmpty(nombreProducto) Then
            'Si contiene espacio hago una busqueda por cada palabra
            If Not nombreProducto.Contains(" ") Then
               .AppendFormatLine("   AND P.NombreProducto LIKE '{0}'", String.Format(formatoLikeNombre, nombreProducto))
            Else
               Dim Palabras() As String = nombreProducto.Split(" "c)

               .Append("   AND ( 1=1 ")
               For Each Palabra As String In Palabras
                  .AppendFormatLine("   AND P.NombreProducto LIKE '{0}'", String.Format(formatoLikeNombre, Palabra))
               Next

               .AppendLine("  )")
            End If
         End If

         If Not String.IsNullOrEmpty(codigoProducto) Then
            .AppendFormatLine("	AND P.IdProducto LIKE '{0}'", String.Format(formatoLike, codigoProducto))
         End If


         If habitual Then
            .AppendLine("   AND P.IdProveedor = " & idProveedor.ToString())
         End If

         If esOferta <> "TODOS" Then
            .AppendLine(" AND P.EsOferta = '" & esOferta & "' ")
         End If

         If Not String.IsNullOrWhiteSpace(codigoProductoProveedor) Then
            .AppendLine(" AND PP.CodigoProductoProveedor LIKE '%" & codigoProductoProveedor & "%' ")
         End If

         Select Case conStock
            Case Entidades.Publicos.SiNoTodos.SI
               .AppendFormatLine("      AND PS.Stock > 0")
            Case Entidades.Publicos.SiNoTodos.NO
               .AppendFormatLine("      AND PS.Stock <= 0")
         End Select

         If idMoneda > 0 Then
            .AppendLine("   AND Mo.IdMoneda = " & idMoneda)
         End If

         .AppendFormatLine("	GROUP by 		")
         .AppendFormatLine("		 S.IdSucursal")
         .AppendFormatLine("        ,S.Nombre")
         .AppendFormatLine("        ,RIGHT(REPLICATE(' ',15) + P.IdProducto,15)")
         .AppendFormatLine("        ,P.IdProducto")
         .AppendFormatLine("        ,PP.CodigoProductoProveedor")
         .AppendFormatLine("		,P.NombreProducto")
         .AppendFormatLine("	    ,P.NombreCorto")
         .AppendFormatLine("		,P.Tamano")
         .AppendFormatLine("		,P.IdMarca")
         .AppendFormatLine("		,M.NombreMarca")
         .AppendFormatLine("		,P.IdRubro")
         .AppendFormatLine("		,R.NombreRubro")
         .AppendFormatLine("		,P.IdSubRubro")
         .AppendFormatLine("		,SR.NombreSubRubro")
         .AppendFormatLine("		,P.IdSubSubRubro")
         .AppendFormatLine("		,SSR.NombreSubSubRubro")
         .AppendFormatLine("		,P.IdUnidadDeMedida")
         .AppendFormatLine("		,P.Alicuota")
         .AppendFormatLine("		,Mo.Simbolo")
         .AppendFormatLine("        ,EsOferta")
         .AppendFormatLine("		,PS.PrecioFabrica")
         .AppendFormatLine("        ,P.IdProveedor")
         .AppendFormatLine("   	    ,PRO.NombreProveedor")
         .AppendFormatLine("   	    ,PP.DescuentoRecargoPorc1")
         .AppendFormatLine(" 		,PP.DescuentoRecargoPorc2")
         .AppendFormatLine(" 		,PP.DescuentoRecargoPorc3")
         .AppendFormatLine(" 		,PP.DescuentoRecargoPorc4")
         .AppendFormatLine("		,PS.PrecioCosto")
         .AppendFormatLine("		,PS.FechaActualizacion")
         .AppendFormatLine("	    ,PS.Stock  ")
         .AppendFormatLine("		,P.EsCompuesto")
         .AppendFormatLine("		,P.ActualizaPreciosSucursalesAsociadas")

         .AppendLine("	ORDER BY P.NombreProducto")

      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetPorCodigoNombreParaBusquedas(idSucursal As Integer,
                                                   idListaPrecios As Integer,
                                                   idProducto As String,
                                                   idProductoExacto As Boolean,
                                                   nombreProducto As String,
                                                   nombreProductoExacto As Boolean,
                                                   condicionParaCombinarCodigoNombre As String,
                                                   modulo As String,
                                                   soloCompuestos As Boolean,
                                                   modalidad As String,
                                                   soloAlquilables As Boolean,
                                                   tipoOperacion As Entidades.Producto.TiposOperaciones,
                                                   publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros,
                                                   anchoIdProducto As String,
                                                   productoCodigoQuitarBlancos As Boolean,
                                                   productoUtilizaCodigoDeBarras As Boolean,
                                                   productoUtilizaCodigoLargoProducto As Boolean,
                                                   productoFormatoLikeBuscarPorCodigoResuelto As String,
                                                   productoFormatoLikeBuscarPorNombreResuelto As String,
                                                   BuscaProductoPorProveedorHabitual As Boolean,
                                                   preciosConIVA As Boolean,
                                                   esObservacion As Boolean?,
                                                   permiteModificarDescripcion As Boolean?,
                                                   idRubro As Integer,
                                                   idMarca As Integer,
                                                   busquedaPorCodigoProductoProveedor As Boolean,
                                                   idCliente As Long,
                                                   productosCliente As Boolean,
                                                   soloProductosConStock As Boolean,
                                                   soloBuscaPorIdProducto As Boolean,
                                                   redondeoEnPreciosVenta As Integer,
                                                   idProveedorDeCompra As Long,
                                                   soloCargaProductosDelProveedor As Boolean,
                                                   soloTipoCalidadCompras As Boolean,
                                                   cotizacionDolar As Decimal) As DataTable
      Dim stb = New StringBuilder()
      With stb
         If productoCodigoQuitarBlancos Then
            .AppendFormat("SELECT P.IdProducto as IdProducto")
         Else
            .AppendFormat("SELECT RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto", anchoIdProducto)
         End If

         .AppendLine(" ,P.NombreProducto")

         If busquedaPorCodigoProductoProveedor Then
            .AppendLine(" ,PP.CodigoProductoProveedor")
         End If

         .AppendLine(" ,P.NombreCorto")
         .AppendLine(" ,P.Tamano")
         .AppendLine(" ,P.IdUnidadDeMedida")

         .AppendLine(" ,P.Lote")
         .AppendLine(" ,P.NroSerie")

         .AppendLine(" ,P.Alicuota")
         .AppendLine(" ,P.Alicuota2")
         .AppendLine(" ,Mo.Simbolo")

         .AppendLine(" ,PS.PrecioFabrica")
         If busquedaPorCodigoProductoProveedor Then
            .AppendLine(" ,PP.UltimoPrecioCompra as PrecioCosto")
         Else
            .AppendLine(" ,PS.PrecioCosto")
         End If
         .AppendLine(" ,PSP.PrecioVenta")


         If preciosConIVA Then
            .AppendFormatLine(" ,ROUND({0}, {1}) AS PrecioVentaSinIVA",
                                CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), redondeoEnPreciosVenta)
            .AppendFormatLine(" ,ROUND({0}, {1}) as PrecioVentaConIVA", "PSP.PrecioVenta", redondeoEnPreciosVenta)

            .AppendFormatLine(" ,ROUND({0} * CASE WHEN P.IdMoneda = {3} THEN {2} ELSE 1 END, {1}) AS PrecioVentaSinIVAPesificado",
                                CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"),
                                redondeoEnPreciosVenta, cotizacionDolar, Entidades.Moneda.Dolar)
            .AppendFormatLine(" ,ROUND({0} * CASE WHEN P.IdMoneda = {3} THEN {2} ELSE 1 END, {1}) as PrecioVentaConIVAPesificado", "PSP.PrecioVenta",
                              redondeoEnPreciosVenta, cotizacionDolar, Entidades.Moneda.Dolar)
         Else
            .AppendFormatLine(" ,ROUND({0}, {1}) as PrecioVentaSinIVA", "PSP.PrecioVenta", redondeoEnPreciosVenta)
            .AppendFormatLine(" ,ROUND({0}, {1}) AS PrecioVentaConIVA",
                                CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), redondeoEnPreciosVenta)

            .AppendFormatLine(" ,ROUND({0} * CASE WHEN P.IdMoneda = {3} THEN {2} ELSE 1 END, {1}) as PrecioVentaSinIVAPesificado", "PSP.PrecioVenta",
                              redondeoEnPreciosVenta, cotizacionDolar, Entidades.Moneda.Dolar)
            .AppendFormatLine(" ,ROUND({0} * CASE WHEN P.IdMoneda = {3} THEN {2} ELSE 1 END, {1}) AS PrecioVentaConIVAPesificado",
                                CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"),
                                redondeoEnPreciosVenta, cotizacionDolar, Entidades.Moneda.Dolar)
         End If

         .AppendLine(" ,CASE WHEN PS.PrecioCosto = 0 THEN 100 ELSE ((PSP.PrecioVenta / PS.PrecioCosto) - 1) * 100 END RecargoVenta")

         .AppendLine(" ,PSP.FechaActualizacion")
         .AppendLine(" ,PS.Stock")
         .AppendLine(" ,PS.StockInicial")
         .AppendLine(" ,P.IdMarca")
         .AppendLine(" ,P.IdModelo")
         .AppendLine(" ,P.IdRubro")
         .AppendLine(" ,P.IdSubRubro")
         .AppendLine(" ,P.MesesGarantia")
         .AppendLine(" ,P.IdTipoImpuesto")
         .AppendLine(" ,P.AfectaStock")
         .AppendLine(" ,P.PermiteModificarDescripcion")
         .AppendLine(" ,P.CodigoDeBarras")
         .AppendLine(" ,P.IdMoneda")
         .AppendLine(" ,Mo.NombreMoneda")
         .AppendLine(" ,Mo.FactorConversion")
         .AppendLine(" ,P.EsServicio")
         .AppendLine(" ,P.PublicarEnWeb")
         .AppendLine(" ,P.PublicarEnTiendaNube")
         .AppendLine(" ,P.PublicarEnMercadoLibre")
         .AppendLine(" ,P.PublicarEnArborea")
         .AppendLine(" ,P.PublicarEnGestion")
         .AppendLine(" ,P.PublicarEnEmpresarial")
         .AppendLine(" ,P.PublicarEnBalanza")
         .AppendLine(" ,P.PublicarEnSincronizacionSucursal")
         .AppendLine(" ,P.PublicarListaDePreciosClientes")
         .AppendLine(" ,P.Observacion")
         .AppendLine(" ,P.EquipoMarca")
         .AppendLine(" ,P.EquipoModelo")
         .AppendLine(" ,P.NumeroSerie")
         .AppendLine(" ,P.CaractSII")
         .AppendLine(" ,P.Anio")
         .AppendLine(" ,P.Kilos")
         .AppendLine(" ,P.KilosEsUMCompras")
         .AppendLine(" ,P.IdFormula")
         .AppendLine(" ,P.FacturacionCantidadNegativa")
         .AppendLine(" ,P.SolicitaEnvase")
         .AppendLine(" ,P.AlertaDeCaja")
         .AppendLine(" ,P.DescontarStockComponentes")
         .AppendLine(" ,P.ModalidadCodigoDeBarras")
         .AppendLine(" ,P.CodigoLargoProducto")
         .AppendLine(" ,P.EsObservacion")
         .AppendLine(" ,P.PrecioPorEmbalaje")
         .AppendLine(" ,P.Embalaje")
         .AppendLine(" ,P.UnidHasta1")
         .AppendLine(" ,P.UHPorc1")
         .AppendLine(" ,P.UnidHasta2")
         .AppendLine(" ,P.UHPorc2")
         .AppendLine(" ,P.UnidHasta3")
         .AppendLine(" ,P.UHPorc3")
         .AppendLine(" ,P.UnidHasta4")
         .AppendLine(" ,P.UHPorc4")
         .AppendLine(" ,P.UnidHasta5")
         .AppendLine(" ,P.UHPorc5")
         .AppendLine("      ,P.UHListaPrecios1")
         .AppendLine("      ,P.UHListaPrecios2")
         .AppendLine("      ,P.UHListaPrecios3")
         .AppendLine("      ,P.UHListaPrecios4")
         .AppendLine("      ,P.UHListaPrecios5")
         .AppendLine("      ,LP1.NombreListaPrecios NombreListaPrecios_1")
         .AppendLine("      ,LP2.NombreListaPrecios NombreListaPrecios_2")
         .AppendLine("      ,LP3.NombreListaPrecios NombreListaPrecios_3")
         .AppendLine("      ,LP4.NombreListaPrecios NombreListaPrecios_4")
         .AppendLine("      ,LP5.NombreListaPrecios NombreListaPrecios_5")
         .AppendLine(" ,P.PrecioPorEmbalaje")
         .AppendLine(" ,P.IdCuentaCompras")
         .AppendLine(" ,CCC.NombreCuenta AS NombreCuentaCompras")
         .AppendLine(" ,P.IdCuentaVentas")
         .AppendLine(" ,CCV.NombreCuenta AS NombreCuentaVentas")
         .AppendLine(" ,P.ImporteImpuestoInterno")
         .AppendLine(" ,P.PorcImpuestoInterno")
         .AppendLine(" ,P.OrigenPorcImpInt")
         .AppendLine(" ,M.NombreMarca")
         .AppendLine(" ,MOD.NombreModelo")
         .AppendLine(" ,R.NombreRubro")
         .AppendLine(" ,P.EsOferta")
         .AppendLine(" ,P.IdCuentaComprasSecundaria")
         .AppendLine(" ,CCCS.NombreCuenta AS NombreCuentaComprasSecundaria")
         .AppendLine(" ,P.IncluirExpensas")
         .AppendLine(" ,P.IdCentroCosto")
         .AppendLine(" ,CECO.NombreCentroCosto")
         .AppendLine(" ,P.ObservacionCompras")
         .AppendLine(" ,P.SolicitaPrecioVentaPorTamano")
         .AppendLine(" ,P.Espmm")
         .AppendLine(" ,P.EspPulgadas")
         .AppendLine(" ,P.CodigoSAE")
         .AppendLine(" ,P.IdProduccionProceso")
         .AppendLine(" ,P.IdProduccionForma")
         .AppendLine(" ,P.PorcImpuestoInterno")
         .AppendLine(" ,P.OrigenPorcImpInt")
         .AppendLine(" ,PRP.NombreProduccionProceso")
         .AppendLine(" ,PRF.NombreProduccionForma")
         .AppendLine(" ,P.CalculaPreciosSegunFormula")
         .AppendLine(" ,P.IdSubSubRubro")
         .AppendLine(" ,SSR.NombreSubSubRubro")
         .AppendLine(" ,P.EsCambiable")
         .AppendLine(" ,P.EsBonificable")
         .AppendLine(" ,P.EsDevuelto")
         .AppendLine(" ,P.DescRecProducto")
         .AppendLine(" ,P.ActualizaPreciosSucursalesAsociadas")
         .AppendLine(" ,PPH.CodigoProductoProveedor")
         .AppendLine(" ,PVH.CodigoProveedor")
         .AppendLine(" ,PVH.NombreProveedor")
         .AppendLine(" , P.CalidadStatusLiberado ")
         .AppendLine(" , P.CalidadFechaLiberado")
         .AppendLine(" , P.CalidadUserLiberado ")
         .AppendLine(" , P.CalidadStatusEntregado")
         .AppendLine(" , P.CalidadFechaEntregado")
         .AppendLine(" , P.CalidadUserEntregado")
         .AppendLine(" , P.CalidadFechaIngreso")
         .AppendLine(" , P.CalidadFechaEgreso")
         .AppendLine(" , P.CalidadNroCertificado")
         .AppendLine(" , P.CalidadFecCertificado")
         .AppendLine(" , P.CalidadUsrCertificado")
         .AppendLine(" , P.CalidadObservaciones")
         .AppendLine(" , P.CalidadFechaPreEnt")
         .AppendLine(" , P.CalidadFechaEntProg ")
         .AppendFormatLine(" , P.{0}", Entidades.Producto.Columnas.CalidadNumeroChasis.ToString())
         .AppendFormatLine(" , P.{0}", Entidades.Producto.Columnas.CalidadNroCarroceria.ToString())

         If productosCliente Then
            .AppendLine("    ,C.NombreCliente")
            .AppendLine("    ,C.NombreDeFantasia")
         End If
         .AppendLine(" , PS.Ubicacion")
         .AppendFormatLine(" , P.IdUnidadDeMedida2")
         .AppendFormatLine(" , P.Conversion")
         .AppendFormatLine(" , P.IdProductoNumerico")
         .AppendFormatLine(" , P.EnviarSinCargo")
         .AppendFormatLine(" , P.CodigoProductoTiendaNube")
         .AppendFormatLine(" , P.CodigoProductoMercadoLibre")
         .AppendFormatLine(" , P.IdVarianteProducto")
         .AppendFormatLine(" , P.IdProductoTipoServicio")
         .AppendFormatLine(" , P.CalidadNroDeMotor")
         .AppendFormatLine(" , P.CalidadFechaEntReProg ")
         .AppendFormatLine(" , P.IdProductoModelo ")
         .AppendFormatLine(" , CPM.NombreProductoModelo ")
         .AppendFormatLine(" , P.CalidadNroCertEntregado")
         .AppendFormatLine(" , P.CalidadFecCertEntregado")
         .AppendFormatLine(" , P.CalidadUsrCertEntregado")
         .AppendFormatLine(" , P.CalidadStatusLiberadoPDI ")
         .AppendFormatLine(" , P.CalidadFechaLiberadoPDI")
         .AppendFormatLine(" , P.CalidadUserLiberadoPDI ")
         .AppendFormatLine(" , P.CalidadNroCertEObs")
         .AppendFormatLine(" , P.CalidadNroRemito")
         .AppendFormatLine(" , P.TipoBonificacion")
         '-- REQ-34747.- ----------------------------------------------------------
         .AppendFormatLine(" , (CASE WHEN SR.GrupoAtributo01 IS NULL THEN 0 ELSE SR.GrupoAtributo01 END) AS GrupoAtributo01")
         .AppendFormatLine(" , (CASE WHEN SR.TipoAtributo01  IS NULL THEN 0 ELSE SR.TipoAtributo01 END) AS TipoAtributo01")
         .AppendFormatLine(" , (CASE WHEN SR.GrupoAtributo02 IS NULL THEN 0 ELSE SR.GrupoAtributo02 END) AS GrupoAtributo02")
         .AppendFormatLine(" , (CASE WHEN SR.TipoAtributo02  IS NULL THEN 0 ELSE SR.TipoAtributo02 END) AS TipoAtributo02")
         .AppendFormatLine(" , (CASE WHEN SR.GrupoAtributo03 IS NULL THEN 0 ELSE SR.GrupoAtributo03 END) AS GrupoAtributo03")
         .AppendFormatLine(" , (CASE WHEN SR.TipoAtributo03  IS NULL THEN 0 ELSE SR.TipoAtributo03 END) AS TipoAtributo03")
         .AppendFormatLine(" , (CASE WHEN SR.GrupoAtributo04 IS NULL THEN 0 ELSE SR.GrupoAtributo04 END) AS GrupoAtributo04")
         .AppendFormatLine(" , (CASE WHEN SR.TipoAtributo04  IS NULL THEN 0 ELSE SR.TipoAtributo04 END) AS TipoAtributo04")

         .AppendFormatLine(" , (CASE WHEN SR.GrupoAtributo01 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo01  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine(" + (CASE WHEN SR.GrupoAtributo02 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo02  IS NULL THEN 0 ELSE 1 END) ")
         .AppendFormatLine(" + (CASE WHEN SR.GrupoAtributo03 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo03  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine(" + (CASE WHEN SR.GrupoAtributo04 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo04  IS NULL THEN 0 ELSE 1 END) AS Atributos")

         .AppendFormatLine(" , PS.IdDepositoDefecto")
         .AppendFormatLine(" , PS.IdUbicacionDefecto")

         .AppendFormatLine(" , P.EsCompuesto")
         .AppendFormatLine(" , P.IdProcesoProductivoDefecto")

         '-------------------------------------------------------------------------
         .AppendLine("  FROM Productos P")
         .AppendLine("	LEFT JOIN Monedas Mo ON P.IdMoneda = Mo.IdMoneda")
         .AppendLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto")
         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")

         If busquedaPorCodigoProductoProveedor Or (soloCargaProductosDelProveedor AndAlso idProveedorDeCompra > 0) Then
            .AppendLine("  LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.IdProducto")
            .AppendLine("  LEFT JOIN Proveedores PV ON PV.IdProveedor = PP.IdProveedor")
         End If

         .AppendLine("  LEFT JOIN Proveedores PVH ON PVH.IdProveedor = P.IdProveedor")
         .AppendLine("  LEFT JOIN ProductosProveedores PPH ON PPH.IdProveedor = P.IdProveedor AND PPH.IdProducto = P.IdProducto")

         .AppendLine("  LEFT JOIN ContabilidadCuentas CCC ON CCC.IdCuenta = P.IdCuentaCompras")
         .AppendLine("  LEFT JOIN ContabilidadCuentas CCV ON CCV.IdCuenta = P.IdCuentaVentas")
         .AppendLine("  LEFT JOIN ContabilidadCuentas CCCS ON CCCS.IdCuenta = P.IdCuentaComprasSecundaria")
         .AppendLine("  LEFT JOIN ContabilidadCentrosCostos CECO ON CECO.IdCentroCosto = P.IdCentroCosto")
         .AppendLine("  LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine("  LEFT JOIN Modelos MOD ON MOD.IdModelo = P.IdModelo")
         .AppendLine("  LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine("  LEFT OUTER JOIN SubRubros SR ON P.IdRubro = SR.IdRubro AND P.IdSubRubro = SR.IdSubRubro")
         .AppendLine("  LEFT OUTER JOIN SubSubRubros SSR ON P.IdSubRubro = SSR.IdSubRubro AND P.IdSubSubRubro = SSR.IdSubSubRubro")
         .AppendLine("  LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = P.IdProduccionForma")
         .AppendLine("  LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = P.IdProduccionProceso")
         .AppendLine("  LEFT JOIN CalidadProductosModelos CPM ON CPM.IdProductoModelo = P.IdProductoModelo")
         .AppendLine(" LEFT JOIN ListasDePrecios LP1 ON P.UHListaPrecios1 = LP1.IdListaPrecios")
         .AppendLine(" LEFT JOIN ListasDePrecios LP2 ON P.UHListaPrecios1 = LP2.IdListaPrecios")
         .AppendLine(" LEFT JOIN ListasDePrecios LP3 ON P.UHListaPrecios1 = LP3.IdListaPrecios")
         .AppendLine(" LEFT JOIN ListasDePrecios LP4 ON P.UHListaPrecios1 = LP4.IdListaPrecios")
         .AppendLine(" LEFT JOIN ListasDePrecios LP5 ON P.UHListaPrecios1 = LP5.IdListaPrecios")
         If productosCliente Then
            .AppendFormat("        LEFT JOIN ProductosClientes PC ON PC.IdProducto = P.IdProducto").AppendLine()
            .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente ")
            .AppendLine("  LEFT JOIN CalidadProductosTiposServicios CPT ON CPT.IdProductoTipoServicio = P.IdProductoTipoServicio")
         End If




         .AppendFormatLine(" WHERE 1 = 1")

         If Not String.IsNullOrWhiteSpace(idProducto) Or Not String.IsNullOrWhiteSpace(nombreProducto) Then
            .Append("   AND (")
            'End If

            If Not String.IsNullOrWhiteSpace(idProducto) Then
               Dim campoIdProducto As String = "P.IdProducto"
               If busquedaPorCodigoProductoProveedor Then
                  campoIdProducto = "PP.CodigoProductoProveedor"
               End If

               Dim formatoLike As String = String.Format("LIKE '{0}'", productoFormatoLikeBuscarPorCodigoResuelto)

               ' # Si busca por IdProductoExacto (Parámetro) o edita desde la grilla (soloBuscaPorIdProducto = True)
               ' # Cambia la condición de búsqueda de LIKE a =
               If idProductoExacto Or soloBuscaPorIdProducto Then
                  formatoLike = "= '{0}'"
               End If

               .AppendFormat(" ({0} {1}", campoIdProducto, String.Format(formatoLike, idProducto))

               '###########################################################################################################################
               '# Si el Producto se está editando desde la grilla, no accedo a esta sección para que no me agregue otros códigos al query #
               '###########################################################################################################################
               If Not soloBuscaPorIdProducto Then
                  If productoUtilizaCodigoDeBarras Then
                     .AppendFormat(" OR P.CodigoDeBarras {0}", String.Format(formatoLike, idProducto))
                     .AppendFormat(" OR EXISTS(SELECT * FROM ProductosIdentificaciones PI WHERE PI.IdProducto = P.IdProducto AND PI.Identificacion {0})", String.Format(formatoLike, idProducto))
                  End If

                  If productoUtilizaCodigoLargoProducto Then
                     .AppendFormat(" OR P.CodigoLargoProducto {0}", String.Format(formatoLike, idProducto))
                  End If
                  If BuscaProductoPorProveedorHabitual Then
                     .AppendFormat(" OR PPH.CodigoProductoProveedor {0}", String.Format(formatoLike, idProducto))
                  End If
               End If

               .AppendLine(")")
            End If

            If Not String.IsNullOrWhiteSpace(idProducto) And Not String.IsNullOrWhiteSpace(nombreProducto) Then
               If String.IsNullOrWhiteSpace(condicionParaCombinarCodigoNombre) Then condicionParaCombinarCodigoNombre = " AND "
               .Append(condicionParaCombinarCodigoNombre)
            End If

            If Not String.IsNullOrWhiteSpace(nombreProducto) Then
               Dim Palabras() As String = nombreProducto.Split(" "c)

               Dim formatoLike As String = productoFormatoLikeBuscarPorNombreResuelto
               .AppendFormat(" (P.NombreProducto LIKE '{0}'", String.Format(formatoLike, Palabras(0)))
               For i As Integer = 1 To Palabras.Length - 1 ' Each Palabra As String In Palabras
                  Dim Palabra As String = Palabras(i)
                  .AppendFormat("   AND P.NombreProducto LIKE '{0}'", String.Format(formatoLike, Palabra))
               Next
               .Append(")")
            End If
            'If Not String.IsNullOrWhiteSpace(idProducto) Or Not String.IsNullOrWhiteSpace(nombreProducto) Then
            .AppendLine("  )")
         End If

         .AppendFormatLine("   AND PS.IdSucursal = {0}", idSucursal)

         If soloProductosConStock Then
            .AppendFormatLine("   AND PS.Stock > 0")
         End If

         .AppendFormatLine("   AND P.Activo = 'True'")   'Solo permito elegir los productos Activos

         .AppendFormatLine("   AND PSP.IdListaPrecios = {0}", idListaPrecios)

         If modulo <> "TODOS" Then
            .AppendLine("   AND P.EsDe" & modulo & " = 'True'")   'De Ventas o Compras
         End If

         If soloCompuestos Then
            .AppendLine("   AND (P.EsCompuesto = 'True' OR P.IdProcesoProductivoDefecto IS NOT NULL)")   'Tiene una formula asociada
         End If

         If modalidad = "PESO" Then
            .AppendLine("   AND P.CodigoDeBarrasConPrecio = 'True'")
         End If

         If soloAlquilables Then
            .AppendLine("   AND P.EsAlquilable = 'True'")
         End If

         If tipoOperacion = Entidades.Producto.TiposOperaciones.CAMBIO Then
            .AppendLine("   AND P.EsCambiable = 'True'")
         End If

         If tipoOperacion = Entidades.Producto.TiposOperaciones.BONIFICACION Then
            .AppendLine("   AND P.EsBonificable = 'True'")
         End If

         ProductoPublicarEn(stb, publicarEn, "P")
         'If publicarEnWeb.HasValue Then
         '   .AppendFormatLine("   AND P.PublicarEnWeb = '{0}'", publicarEnWeb.Value)
         'End If

         If idRubro > 0 Then
            .AppendFormatLine("   AND P.Idrubro = {0}", idRubro)
         End If
         If idMarca > 0 Then
            .AppendFormatLine("   AND P.IdMarca = {0}", idMarca)
         End If
         If esObservacion.HasValue Then
            .AppendFormatLine("   AND P.EsObservacion = '{0}'", esObservacion.Value)
         End If
         If permiteModificarDescripcion.HasValue Then
            .AppendFormatLine("   AND P.permiteModificarDescripcion = '{0}'", permiteModificarDescripcion.Value)
         End If

         If busquedaPorCodigoProductoProveedor Then
            .AppendFormatLine("   AND PV.IdProveedor = {0}", idProveedorDeCompra)
         End If
         If idCliente > 0 And productosCliente Then
            .AppendFormat("	AND PC.IdCliente = " & idCliente.ToString).AppendLine()
         End If

         '# Parámetro: Solo carga los productos del Proveedor
         If soloCargaProductosDelProveedor AndAlso idProveedorDeCompra > 0 Then
            .AppendFormat("	AND PP.IdProveedor = {0}", idProveedorDeCompra)
         End If

         If productosCliente Then
            If soloTipoCalidadCompras Then
               .AppendLine("    AND CPT.IdProductoTipoServicio = 4 ")
            Else
               '-- REQ-36037.- --------------------------------------------------------------------------------
               .AppendLine("    AND (CPT.IdProductoTipoServicio <> 4 OR CPT.IdProductoTipoServicio IS NULL)")
               '-----------------------------------------------------------------------------------------------
            End If
         End If


         .AppendLine(" ORDER BY P.NombreProducto")
      End With

      Return GetDataTable(stb.ToString())
   End Function


   Public Class ParametrosGetPrecios
      Public Property PreciosConIVA As Boolean
      Public Property SimboloEmbalaje As String
      Public Property Redondeo As Integer
      Public Property ProductoUtilizaCodigoDeBarras As Boolean
      Public Property ProductoFormatoLikeBuscarPorCodigoResuelto As String
      Public Property ProductoFormatoLikeBuscarPorNombreResuelto As String
      Public Property ProductoUtilizaCodigoLargoProducto As Boolean
      Public Property ConsultarPreciosOcultarProdNoAfectanStock As Boolean
      Public Property ProductoCodigoNumerico As Boolean
      Public Sub New(preciosConIVA As Boolean,
                      productoEmbalajeHaciaArriba As Boolean,
                      redondeo As Integer,
                      productoUtilizaCodigoDeBarras As Boolean,
                      productoFormatoLikeBuscarPorCodigoResuelto As String,
                      productoFormatoLikeBuscarPorNombreResuelto As String,
                      productoUtilizaCodigoLargoProducto As Boolean,
                      consultarPreciosOcultarProdNoAfectanStock As Boolean,
                      productoCodigoNumerico As Boolean)
         Me.PreciosConIVA = preciosConIVA
         Me.SimboloEmbalaje = If(productoEmbalajeHaciaArriba, "*", "/")
         Me.Redondeo = redondeo
         Me.ProductoUtilizaCodigoDeBarras = productoUtilizaCodigoDeBarras
         Me.ProductoFormatoLikeBuscarPorCodigoResuelto = productoFormatoLikeBuscarPorCodigoResuelto
         Me.ProductoFormatoLikeBuscarPorNombreResuelto = productoFormatoLikeBuscarPorNombreResuelto
         Me.ProductoUtilizaCodigoLargoProducto = productoUtilizaCodigoLargoProducto
         Me.ConsultarPreciosOcultarProdNoAfectanStock = consultarPreciosOcultarProdNoAfectanStock
         Me.ProductoCodigoNumerico = productoCodigoNumerico
      End Sub
   End Class
   Public Function GetPrecios(sucursales As List(Of Entidades.Sucursal), idListaPrecios As Integer,
                              marcas As List(Of Entidades.Marca), modelos As List(Of Entidades.Modelo),
                              rubros As List(Of Entidades.Rubro), subRubros As List(Of Entidades.SubRubro), subSubRubros As List(Of Entidades.SubSubRubro),
                              idProducto As String, nombreProducto As String,
                              conPrecio As Boolean, conStock As Boolean, incluirInactivos As Boolean, embalaje As Boolean,
                              esOferta As String, esDeVentas As String, esDeCompras As String,
                              idMoneda As Integer, tipoCambio As Decimal,
                              parametros As ParametrosGetPrecios,
                           buscaProductoPorProveedorHabitual As Boolean, afectaStock As String) As DataTable

      Dim strAnchoIdProducto As Integer = GetAnchoCampo("Productos", "IdProducto")
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT ")
         .AppendLine("   S.IdSucursal,")
         .AppendLine("	S.Nombre NombreSucursal,")
         .AppendFormatLine("	RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto,", strAnchoIdProducto)
         .AppendLine("	P.NombreProducto,")
         .AppendLine("	P.NombreCorto,")
         .AppendLine("  P.Alicuota, ")
         .AppendLine("  P.EsOferta ")

         If parametros.PreciosConIVA Then
            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioCostoSinIVA",
                                CalculosImpositivos.ObtenerPrecioSinImpuestos("PS.PrecioCosto", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)
            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioCostoConIVA",
                                "PS.PrecioCosto", tipoCambio, parametros.Redondeo)

            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioListaSinIVA",
                                CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)

            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioVentaSinIVA",
                                CalculosImpositivos.ObtenerPrecioSinImpuestos("ISNULL(PO.PrecioOferta, PSP.PrecioVenta)", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)

            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioListaConIVA",
                                "PSP.PrecioVenta", tipoCambio, parametros.Redondeo)

            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioVentaConIVA",
                                "ISNULL(PO.PrecioOferta, PSP.PrecioVenta)", tipoCambio, parametros.Redondeo)


         Else
            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioCostoSinIVA",
                                "PS.PrecioCosto", tipoCambio, parametros.Redondeo)
            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioCostoConIVA",
                                CalculosImpositivos.ObtenerPrecioConImpuestos("PS.PrecioCosto", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)

            'Si tiene oferta usa ese precio
            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioListaSinIVA",
                                "PSP.PrecioVenta", tipoCambio, parametros.Redondeo)

            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioVentaSinIVA",
                                "ISNULL(PO.PrecioOferta, PSP.PrecioVenta)", tipoCambio, parametros.Redondeo)

            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioListaConIVA",
                                CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)

            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioVentaConIVA",
                                CalculosImpositivos.ObtenerPrecioConImpuestos("ISNULL(PO.PrecioOferta, PSP.PrecioVenta)", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)


         End If

         .AppendFormatLine(" ,ROUND(CASE WHEN PS.PrecioCosto = 0 THEN 0 ELSE ((ISNULL(PO.PrecioOferta, PSP.PrecioVenta) / PS.PrecioCosto) - 1) * 100 END, {0}) AS PorcRecargoCostoVSVenta", parametros.Redondeo)

         .AppendFormat("  ,")

         .AppendLine("	PS.Stock,")
         .AppendLine("	PS.StockInicial,")
         .AppendLine("  PS.StockMinimo, ")
         .AppendLine("  PS.StockMaximo, ")
         .AppendLine("  PS.PuntoDePedido, ")
         '.AppendLine("  ISNULL(PS.StockReservado, 0) StockReservado,")
         '.AppendLine("  ISNULL(PS.StockDefectuoso, 0) StockDefectuoso,")
         '.AppendLine("  ISNULL(PS.StockFuturo, 0) StockFuturo,")
         '.AppendLine("  ISNULL(PS.StockFuturoReservado, 0) StockFuturoReservado,")

         .AppendLine("	PS.Stock AS StockTotal,") '+ ISNULL(PS.StockReservado, 0) + ISNULL(PS.StockDefectuoso, 0) 

         .AppendLine("	P.IdMarca,")
         .AppendLine("	M.NombreMarca,")
         .AppendLine("  P.IdModelo,")
         .AppendLine("  Md.NombreModelo,")
         .AppendLine("	P.IdRubro,")
         .AppendLine("	R.NombreRubro,")
         .AppendLine("	P.IdSubRubro,")
         .AppendLine("	SR.NombreSubRubro, ")
         .AppendLine("  P.IdSubSubRubro,")
         .AppendLine("  SSR.NombreSubSubRubro,")
         .AppendLine("	PSP.FechaActualizacion,")
         .AppendLine("	CONVERT(Date, PSP.FechaActualizacion) AS FechaActualizacion_Fecha,")
         .AppendLine("	CONVERT(Time, PSP.FechaActualizacion) AS FechaActualizacion_Hora,")
         .AppendLine("	PS.FechaActualizacion FechaActualizacionCosto,")
         .AppendLine("	CONVERT(Date, PS.FechaActualizacion) AS FechaActualizacionCosto_Fecha,")
         .AppendLine("	CONVERT(Time, PS.FechaActualizacion) AS FechaActualizacionCosto_Hora,")
         .AppendLine("	P.CodigoDeBarras,")

         .AppendLine("	P.IdMoneda,")
         .AppendLine("  Mo.Simbolo,")

         .AppendLine("	P.Activo, ")
         .AppendLine("  P.Observacion,")
         .AppendLine("  P.DescRecProducto,")
         .AppendLine("  P.ActualizaPreciosSucursalesAsociadas,")

         .AppendLine("  CASE WHEN P.UnidHasta1 = 0 THEN R.UnidHasta1 ELSE P.UnidHasta1 END AS UnidHasta1,")
         .AppendLine("  CASE WHEN P.UnidHasta1 = 0 THEN R.UnidHasta2 ELSE P.UnidHasta2 END AS UnidHasta2,")
         .AppendLine("  CASE WHEN P.UnidHasta1 = 0 THEN R.UnidHasta3 ELSE P.UnidHasta3 END AS UnidHasta3,")
         .AppendLine("  CASE WHEN P.UnidHasta1 = 0 THEN R.UnidHasta4 ELSE P.UnidHasta4 END AS UnidHasta4,")
         .AppendLine("  CASE WHEN P.UnidHasta1 = 0 THEN R.UnidHasta5 ELSE P.UnidHasta5 END AS UnidHasta5,")

         .AppendLine("  CASE WHEN P.UnidHasta1 = 0 THEN R.UHPorc1 ELSE P.UHPorc1 END AS UHPorc1,")
         .AppendLine("  CASE WHEN P.UnidHasta1 = 0 THEN R.UHPorc2 ELSE P.UHPorc2 END AS UHPorc2,")
         .AppendLine("  CASE WHEN P.UnidHasta1 = 0 THEN R.UHPorc3 ELSE P.UHPorc3 END AS UHPorc3,")
         .AppendLine("  CASE WHEN P.UnidHasta1 = 0 THEN R.UHPorc4 ELSE P.UHPorc4 END AS UHPorc4,")
         .AppendLine("  CASE WHEN P.UnidHasta1 = 0 THEN R.UHPorc5 ELSE P.UHPorc5 END AS UHPorc5")

         If embalaje Then
            .AppendLine(" ,P.Embalaje ")

            Dim campoCostoPorEmbalaje As String = String.Format("PS.PrecioCosto {0} P.Embalaje", parametros.SimboloEmbalaje)
            Dim campoVentaPorEmbalaje As String = String.Format("PSP.PrecioVenta {0} P.Embalaje", parametros.SimboloEmbalaje)

            If parametros.PreciosConIVA Then
               .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS CostoEmbalajeSinIVA",
                                   CalculosImpositivos.ObtenerPrecioSinImpuestos(campoCostoPorEmbalaje, "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)
               .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS CostoEmbalajeConIVA",
                                   campoCostoPorEmbalaje, tipoCambio, parametros.Redondeo)

               .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS VentaEmbalajeSinIVA",
                                   CalculosImpositivos.ObtenerPrecioSinImpuestos(campoVentaPorEmbalaje, "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)
               .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS VentaEmbalajeConIVA",
                                   campoVentaPorEmbalaje, tipoCambio, parametros.Redondeo)
            Else
               .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS CostoEmbalajeSinIVA",
                                   campoCostoPorEmbalaje, tipoCambio, parametros.Redondeo)
               .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS CostoEmbalajeConIVA",
                                   CalculosImpositivos.ObtenerPrecioConImpuestos(campoCostoPorEmbalaje, "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)

               .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS VentaEmbalajeSinIVA",
                                   campoVentaPorEmbalaje, tipoCambio, parametros.Redondeo)
               .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS VentaEmbalajeConIVA",
                                   CalculosImpositivos.ObtenerPrecioConImpuestos(campoVentaPorEmbalaje, "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)
            End If
         Else
            .AppendLine(" ,NULL Embalaje ")

            .AppendFormatLine(" ,NULL CostoEmbalajeSinIVA")
            .AppendFormatLine(" ,NULL CostoEmbalajeConIVA")

            .AppendFormatLine(" ,NULL VentaEmbalajeSinIVA")
            .AppendFormatLine(" ,NULL VentaEmbalajeConIVA")
         End If

         .AppendLine(",( SELECT TOP 1 PR.NombreProveedor  FROM ProductosProveedores PP")
         .AppendLine("   INNER JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor ")
         .AppendLine("   WHERE PP.IdProducto = P.IdProducto ")
         .AppendLine("   ORDER BY PP.UltimaFechaCompra desc) as UltimoProv,")
         .AppendLine(" ( SELECT TOP 1 pp.UltimaFechaCompra  FROM ProductosProveedores PP ")
         .AppendLine("  INNER JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor ")
         .AppendLine("  WHERE PP.IdProducto = P.IdProducto ")
         .AppendLine("  ORDER BY PP.UltimaFechaCompra desc) as UltimaFechaCompra, ")
         .AppendLine(" Pro.NombreProveedor, ")
         .AppendLine(" PPR.CodigoProductoProveedor, ")
         .AppendLine(" PS.Ubicacion ")
         '-------------------------------------------------------------------------
         .AppendLine(", SR.GrupoAtributo01")
         .AppendLine(", SR.TipoAtributo01")
         .AppendLine(", SR.GrupoAtributo02")
         .AppendLine(", SR.TipoAtributo02")
         .AppendFormatLine(" , (CASE WHEN SR.GrupoAtributo01 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo01  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine(" + (CASE WHEN SR.GrupoAtributo02 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo02  IS NULL THEN 0 ELSE 1 END) ")
         .AppendFormatLine(" + (CASE WHEN SR.GrupoAtributo03 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo03  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine(" + (CASE WHEN SR.GrupoAtributo04 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo04  IS NULL THEN 0 ELSE 1 END) AS Atributos")
         '-------------------------------------------------------------------------
         .AppendLine(" FROM ProductosSucursales PS")
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendLine("	LEFT JOIN Productos P ON P.IdProducto = PS.IdProducto")

         If idMoneda > 0 Then
            .AppendFormatLine(" LEFT JOIN Monedas Mo ON Mo.IdMoneda = {0}", idMoneda)
         Else
            .AppendFormatLine(" LEFT JOIN Monedas Mo ON Mo.IdMoneda = P.IdMoneda ")
         End If

         .AppendLine(" LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendLine(" LEFT JOIN Modelos Md ON Md.IdModelo = P.IdModelo")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendLine(" LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendLine(" LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
         .AppendLine(" LEFT JOIN Proveedores Pro ON Pro.IdProveedor = P.IdProveedor ")
         .AppendLine(" LEFT JOIN ProductosProveedores PPR ON PPR.IdProveedor = Pro.IdProveedor AND PPR.IdProducto = P.IdProducto ")
         .AppendFormatLine("  LEFT JOIN ProductosOfertas PO")
         .AppendFormatLine("         ON PO.IdProducto = PS.IdProducto")
         .AppendFormatLine("        AND PO.Activa = 'True'")
         .AppendFormatLine("        AND PO.CantidadConsumida < PO.LimiteStock")
         .AppendFormatLine("        AND PO.FechaDesde <= '{0}'", ObtenerFecha(Date.Today, False))
         .AppendFormatLine("        AND PO.FechaHasta >= '{0}'", ObtenerFecha(Date.Today, False))
         .AppendFormatLine("  AND  PO.FechaDesde <= '{0}' AND  PO.FechaHasta >= '{0}'", ObtenerFecha(Date.Today, False))
         .AppendFormatLine(" INNER JOIN SucursalesDepositos SD ON SD.IdDeposito = PS.IdDepositoDefecto AND SD.IdSucursal = PS.IdSucursal
                            INNER JOIN SucursalesDepositosUsuarios SDU ON SDU.IdDeposito = SD.IdDeposito 
                            AND SDU.IdSucursal = SDU.IdSucursal ")
         .AppendFormatLine("AND SDU.IdUsuario = '{0}'", actual.Nombre)

         .AppendLine(" WHERE 1 = 1")
         '.AppendLine("  PS.IdSucursal in (0")
         'For Each suc As Object In sucursales
         '   .AppendLine("," & suc.ToString())
         'Next
         '.AppendLine(") ")

         GetListaSucursalesMultiples(stb, sucursales, "PS")

         'Filtro de Código
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            Dim formatoLike As String = parametros.ProductoFormatoLikeBuscarPorCodigoResuelto
            .AppendFormat("   AND (P.IdProducto LIKE '{0}'", String.Format(formatoLike, idProducto))
            If parametros.ProductoUtilizaCodigoDeBarras Then
               .AppendFormat(" OR P.CodigoDeBarras LIKE '{0}'", String.Format(formatoLike, idProducto))
               .AppendFormat(" OR EXISTS(SELECT * FROM ProductosIdentificaciones PI WHERE PI.IdProducto = P.IdProducto AND PI.Identificacion LIKE '{0}')", String.Format(formatoLike, idProducto))
            End If
            If parametros.ProductoUtilizaCodigoLargoProducto Then
               .AppendFormat(" OR P.CodigoLargoProducto LIKE '{0}'", String.Format(formatoLike, idProducto))
            End If

            If buscaProductoPorProveedorHabitual Then
               .AppendFormat(" OR PPR.CodigoProductoProveedor LIKE '{0}'", String.Format(formatoLike, idProducto))
            End If

            .Append("	)")
         End If            'If Not String.IsNullOrWhiteSpace(idProducto) Then





         'Filtro de Nombre
         If Not String.IsNullOrEmpty(nombreProducto) Then
            Dim formatoLike As String = parametros.ProductoFormatoLikeBuscarPorNombreResuelto
            'Si contiene espacio hago una busqueda por cada palabra
            If Not nombreProducto.Contains(" ") Then
               .AppendFormatLine("   AND P.NombreProducto LIKE '{0}'", String.Format(formatoLike, nombreProducto))
            Else
               Dim Palabras() As String = nombreProducto.Split(" "c)
               .Append("   AND ( 1=1 ")
               For Each palabra As String In Palabras
                  .AppendFormatLine("   AND P.NombreProducto LIKE '{0}'", String.Format(formatoLike, palabra))
               Next
               .AppendLine("  )")
            End If
         End If            'If Not String.IsNullOrEmpty(nombreProducto) Then

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaModelosMultiples(stb, modelos, "P")
         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subRubros, "P")
         GetListaSubSubRubrosMultiples(stb, subSubRubros, "P")

         If Not incluirInactivos Then
            .AppendLine("	AND P.Activo = 'True'")   'Solo permito elegir los productos Activos
         End If

         .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)

         If conPrecio Then
            .AppendLine("	AND PSP.PrecioVenta > 0")
         End If

         If conStock Then
            .AppendLine("	AND PS.Stock > 0 ")
         End If

         'If parametros.ConsultarPreciosOcultarProdNoAfectanStock Then
         '   .AppendLine(" AND P.AfectaStock = 'True'")
         'End If

         If esOferta <> "TODOS" Then
            .AppendLine(" AND P.EsOferta = '" & esOferta & "' ")
         End If

         If esDeVentas <> "TODOS" Then
            .AppendLine(" AND P.EsDeVentas = '" & IIf(esDeVentas = "SI", "1", "0").ToString() & "'")
         End If

         If esDeCompras <> "TODOS" Then
            .AppendLine(" AND P.EsDeCompras = '" & IIf(esDeCompras = "SI", "1", "0").ToString() & "'")
         End If

         If afectaStock <> "TODOS" Then
            .AppendLine("      AND P.AfectaStock = " & IIf(afectaStock = "SI", "1", "0").ToString())

         End If
         .AppendLine(" GROUP BY S.IdSucursal, S.Nombre, ")
         .AppendLine(" 	P.IdProducto, P.NombreProducto, P.NombreCorto, P.Alicuota, P.EsOferta, PS.Stock, PS.StockInicial, PS.StockMinimo, PS.StockMaximo, ")
         .AppendLine("     PS.PuntoDePedido, PS.Stock,	P.IdMarca, M.NombreMarca, P.IdModelo, Md.NombreModelo, P.IdRubro, R.NombreRubro, P.IdSubRubro, SR.NombreSubRubro,")
         .AppendLine("     P.IdSubSubRubro, SSR.NombreSubSubRubro, PSP.FechaActualizacion, PS.FechaActualizacion, P.CodigoDeBarras, P.IdMoneda, Mo.Simbolo, P.Activo, P.Observacion, ")
         .AppendLine(" 	P.DescRecProducto, P.ActualizaPreciosSucursalesAsociadas, Pro.NombreProveedor, PPR.CodigoProductoProveedor, PS.Ubicacion, SR.GrupoAtributo01, SR.TipoAtributo01,")
         .AppendLine(" 	SR.GrupoAtributo02, SR.TipoAtributo02, P.OrigenPorcImpInt, PS.PrecioCosto, P.ImporteImpuestoInterno, P.PorcImpuestoInterno, PS.PrecioCosto, P.ImporteImpuestoInterno, ")
         .AppendLine(" 	P.PorcImpuestoInterno, Mo.IdMoneda, PSP.PrecioVenta, PO.PrecioOferta, P.UnidHasta1, R.UnidHasta1, R.UnidHasta2, P.UnidHasta1, P.UnidHasta2, R.UnidHasta3, P.UnidHasta3,")
         .AppendLine(" 	R.UnidHasta4, P.UnidHasta4, R.UnidHasta5, P.UnidHasta5, R.UHPorc1, P.UHPorc1, R.UHPorc2, P.UHPorc2, R.UHPorc3, P.UHPorc3, R.UHPorc4, P.UHPorc4, R.UHPorc5, P.UHPorc5, ")
         .AppendLine(" 	SR.GrupoAtributo03, SR.TipoAtributo03, SR.GrupoAtributo04, SR.TipoAtributo04")

         .AppendLine(" ORDER BY P.NombreProducto")
      End With

      Return GetDataTable(stb)

   End Function

   '-- REQ-32953.- --------------------------------------------------------------------------
   Public Function GetTipoBonificacion() As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT *")
         .AppendLine("  FROM Productos P")
         .AppendFormatLine(" WHERE P.TipoBonificacion = 'LISTAPRECIO'")
      End With

      Return GetDataTable(stb.ToString())
   End Function
   '----------------------------------------------------------------------------------------

   Public Function GetStockPorProducto(idProducto As String, idSucursalAOmitir As Integer) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PS.IdSucursal, S.Nombre NombreSucursal")
         .AppendLine("	   , PS.Stock")
         .AppendLine("  FROM ProductosSucursales PS")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendFormatLine(" WHERE PS.IdSucursal <> {0}", idSucursalAOmitir)
         .AppendFormatLine("   AND PS.IdProducto = '{0}'", idProducto)
         .AppendLine(" ORDER BY NombreSucursal")
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetPreciosSoloPorCodigoLista(idSucursal As Integer,
                                               idProducto As String,
                                               idListaPrecios As Integer?,
                                               activo As Boolean?,
                                               parametros As ParametrosGetPrecios) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT PSP.IdListaPrecios")
         .AppendFormatLine("      ,LdP.NombreListaPrecios")
         .AppendFormatLine("      ,PSP.IdProducto")
         .AppendFormatLine("      ,P.Alicuota")
         .AppendFormatLine("      ,P.NombreProducto")

         If parametros.PreciosConIVA Then

            .AppendFormatLine(" ,ROUND({0}, {1}) AS PrecioVentaSinIVA",
                                CalculosImpositivos.ObtenerPrecioSinImpuestos("ISNULL(PO.PrecioOferta, PSP.PrecioVenta)", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), parametros.Redondeo)


            .AppendFormatLine(" ,ISNULL(PO.PrecioOferta, PSP.PrecioVenta) AS PrecioVentaConIVA")
         Else

            .AppendFormatLine(" ,ISNULL(PO.PrecioOferta, PSP.PrecioVenta) AS PrecioVentaSinIVA")

            .AppendFormatLine(" ,ROUND({0}, {1}) AS PrecioVentaConIVA",
                             CalculosImpositivos.ObtenerPrecioConImpuestos("ISNULL(PO.PrecioOferta, PSP.PrecioVenta)", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), parametros.Redondeo)

         End If
         .AppendFormatLine(" ,ISNULL(PO.FechaHasta, PSP.FechaActualizacion) AS FechaActualizacion ")

         .AppendFormatLine(" ,CONVERT(BIT, CASE WHEN PO.IdProducto IS NOT NULL THEN 'True' ELSE 'False' END) AS Oferta")

         .AppendFormatLine("  FROM ProductosSucursalesPrecios PSP ")
         .AppendFormatLine("	LEFT JOIN Productos P ON P.IdProducto = PSP.IdProducto")
         .AppendFormatLine("	LEFT JOIN ListasDePrecios LdP ON LdP.IdListaPrecios = PSP.IdListaPrecios")
         .AppendFormatLine("  LEFT JOIN ProductosOfertas PO")
         .AppendFormatLine("         ON PO.IdProducto = PSP.IdProducto")
         .AppendFormatLine("        AND PO.Activa = 'True'")
         .AppendFormatLine("        AND PO.CantidadConsumida < PO.LimiteStock")
         .AppendFormatLine("        AND PO.FechaDesde <= '{0}'", ObtenerFecha(Date.Today, False))
         .AppendFormatLine("        AND PO.FechaHasta >= '{0}'", ObtenerFecha(Date.Today, False))
         .AppendFormatLine(" WHERE PSP.IdSucursal = {0}", idSucursal)

         If activo.HasValue Then
            .AppendFormatLine("   AND P.Activo = {0}", GetStringFromBoolean(activo.Value))
         End If

         .AppendFormat("   AND (P.IdProducto = '{0}'", idProducto)
         If parametros.ProductoUtilizaCodigoDeBarras Then
            .AppendFormat(" OR P.CodigoDeBarras = '{0}'", idProducto)
            .AppendFormat(" OR EXISTS(SELECT * FROM ProductosIdentificaciones PI WHERE PI.IdProducto = P.IdProducto AND PI.Identificacion = '{0}')", idProducto)
         End If
         If parametros.ProductoUtilizaCodigoLargoProducto Then
            .AppendFormat(" OR P.CodigoLargoProducto = '{0}'", idProducto)
         End If
         .AppendLine("	)")

         'If parametros.ProductoUtilizaCodigoDeBarras Then
         '   .AppendFormatLine("	AND (P.IdProducto = '{0}' OR P.CodigoDeBarras = '{0}')", idProducto)
         'Else
         '   .AppendFormatLine("	AND P.IdProducto = '{0}'", idProducto)
         'End If

         If idListaPrecios.HasValue Then
            .AppendFormatLine("	AND PSP.IdListaPrecios = {0}", idListaPrecios.Value)
         End If

         .AppendFormatLine(" ORDER BY Oferta desc, FechaActualizacion, LdP.NombreListaPrecios")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetPreciosListasParaClientes(agruparPor As String,
                                               ordenarPor As String,
                                               sucursales As Entidades.Sucursal(),
                                               idListaPrecios As Integer,
                                               marcas As Entidades.Marca(),
                                               rubros As Entidades.Rubro(),
                                               subRubros As Entidades.SubRubro(),
                                               subSubRubros As Entidades.SubSubRubro(),
                                               idProducto As String,
                                               conPrecio As Boolean,
                                               conStock As Boolean,
                                               idMoneda As Integer,
                                               tipoCambio As Decimal,
                                               esOferta As String,
                                               idProductoLibre As String,
                                               nombreProductoLibre As String,
                                               parametros As ParametrosGetPrecios,
                                               FechaActualizadoDesde As Date,
                                               FechaActualizadoHasta As Date,
                                               IdCliente As Long,
                                               filtrosPublicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As DataTable

      Dim strAnchoIdProducto As Integer = GetAnchoCampo("Productos", "IdProducto")
      Dim CampoFecha As String

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT S.IdSucursal")
         .AppendLine("		,S.Nombre NombreSucursal")
         If parametros.ProductoCodigoNumerico Then
            .AppendFormat("	,RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) AS IdProducto", strAnchoIdProducto)
         Else
            .AppendFormat("	,P.IdProducto")
         End If
         .AppendLine("		,P.IdProductoNumerico")
         .AppendLine("		,P.NombreProducto")
         .AppendLine("  	,P.NombreCorto")
         .AppendLine("		,P.Tamano")
         .AppendLine("		,P.IdMarca")
         .AppendLine("		,M.NombreMarca")
         .AppendLine("		,P.IdRubro")
         .AppendLine("		,R.NombreRubro")
         .AppendLine("		,P.IdSubRubro")
         .AppendLine("		,SR.NombreSubRubro")
         .AppendLine("     ,PP.CodigoProductoProveedor")
         .AppendLine("		,P.IdUnidadDeMedida")
         .AppendLine("		,PS.PrecioFabrica")
         .AppendLine("     ,P.EsOferta")
         .AppendFormatLine(" ,CASE WHEN P.IdMoneda = Mo.IdMoneda THEN PS.PrecioCosto  ELSE CASE WHEN P.IdMoneda = 1 THEN PS.PrecioCosto  / {0} ELSE PS.PrecioCosto  * {0} END END AS PrecioCosto", tipoCambio)

         If parametros.PreciosConIVA Then
            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioVentaSinIVA",
                                CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)
            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioVentaConIVA",
                                "PSP.PrecioVenta", tipoCambio, parametros.Redondeo)
         Else
            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioVentaSinIVA",
                                "PSP.PrecioVenta", tipoCambio, parametros.Redondeo)
            .AppendFormatLine(" ,ROUND(({0}) * CASE WHEN P.IdMoneda = Mo.IdMoneda THEN 1 ELSE CASE WHEN P.IdMoneda = 1 THEN CONVERT(DECIMAL(20,10), 1 / {1}) ELSE {1} END END, {2}) AS PrecioVentaConIVA",
                                CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), tipoCambio, parametros.Redondeo)
         End If

         'Ver como incluir dolares

         .AppendFormatLine(" ,CASE WHEN P.IdMoneda = Mo.IdMoneda THEN PSP.PrecioVenta ELSE CASE WHEN P.IdMoneda = 1 THEN PSP.PrecioVenta / {0} ELSE PSP.PrecioVenta * {0} END END AS PrecioVenta", tipoCambio)

         .AppendLine("		,PS.Stock")
         .AppendLine("		,P.Embalaje")
         .AppendLine("     ,P.Foto")
         .AppendLine("     ,P.IdMoneda")
         .AppendLine("     ,Mo.Simbolo")

         .AppendLine("     ,P.DescRecProducto")
         .AppendLine("     ,P.ActualizaPreciosSucursalesAsociadas")
         .AppendLine("     ,P.UnidHasta1")
         .AppendLine("     ,P.UnidHasta2")
         .AppendLine("     ,P.UnidHasta3")
         .AppendLine("     ,P.UnidHasta4")
         .AppendLine("     ,P.UnidHasta5")
         .AppendLine("     ,P.UHPorc1")
         .AppendLine("     ,P.UHPorc2")
         .AppendLine("     ,P.UHPorc3")
         .AppendLine("     ,P.UHPorc4")
         .AppendLine("     ,P.UHPorc5")
         .AppendLine("     ,P.IdSubSubRubro")
         .AppendLine("     ,P.TipoBonificacion") ' -.PE-33059.-
         .AppendLine("     ,SSR.NombreSubSubRubro")
         CampoFecha = "    ,PSP.FechaActualizacion"
         .AppendLine("	" & CampoFecha & " ")
         .AppendFormatLine("     ,P.IdUnidadDeMedida2")
         .AppendFormatLine("     ,P.Conversion")
         .AppendFormatLine("     ,LP.FechaVigencia")
         .AppendFormatLine("     ,P.CodigoDeBarras")
         .AppendFormatLine("     ,PRO.NombreProveedor")
         .AppendLine("  FROM Productos P")
         .AppendLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto")
         If IdCliente > 0 Then
            .AppendFormat("        LEFT JOIN ProductosClientes PC ON PC.IdProducto = P.IdProducto").AppendLine()
         End If
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendLine("	LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine("	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine("  LEFT OUTER JOIN SubRubros SR ON P.IdRubro = SR.IdRubro AND P.IdSubRubro = SR.IdSubRubro")
         .AppendLine("  LEFT OUTER JOIN SubSubRubros SSR ON P.IdRubro = SR.IdRubro AND P.IdSubRubro = SSR.IdSubRubro AND P.IdSubSubRubro = SSR.IdSubSubRubro")

         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
         .AppendLine("  INNER JOIN ListasDePrecios LP ON PSP.IdListaPrecios = LP.IdListaPrecios")

         .AppendFormatLine(" AND PSP.IdListaPrecios = {0}", idListaPrecios)

         .AppendLine("  LEFT JOIN ProductosProveedores PP ON P.IdProveedor = PP.IdProveedor AND P.IdProducto = PP.IdProducto")
         .AppendLine("  LEFT JOIN Proveedores PRO ON PRO.IdProveedor = PP.IdProveedor")
         If idMoneda > 0 Then
            .AppendFormatLine(" LEFT JOIN Monedas Mo ON Mo.IdMoneda = {0}", idMoneda)
         Else
            .AppendFormatLine(" LEFT JOIN Monedas Mo ON Mo.IdMoneda = P.IdMoneda ")
         End If


         .AppendLine(" WHERE P.Activo = 'True'")

         '.AppendLine("   AND P.PublicarListaDePreciosClientes = 'True'")
         '# Productos PublicarEn..
         ProductoPublicarEn(stb, filtrosPublicarEn, "P")

         GetListaSucursalesMultiples(stb, sucursales, "PS")
         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subRubros, "P")
         GetListaSubSubRubrosMultiples(stb, subSubRubros, "P")

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("   AND P.IdProducto = '{0}'", idProducto)
         End If

         If Not String.IsNullOrWhiteSpace(idProductoLibre) Then
            .AppendFormatLine("   AND P.IdProducto LIKE '{0}'", String.Format(parametros.ProductoFormatoLikeBuscarPorCodigoResuelto, idProductoLibre))
         End If

         If Not String.IsNullOrWhiteSpace(nombreProductoLibre) Then
            For Each palabra As String In nombreProductoLibre.Split(" "c)
               .AppendFormatLine("   AND P.NombreProducto LIKE '{0}'", String.Format(parametros.ProductoFormatoLikeBuscarPorNombreResuelto, palabra))
            Next
         End If

         If IdCliente > 0 Then
            .AppendFormat("	AND PC.IdCliente = " & IdCliente.ToString).AppendLine()
         End If


         If conPrecio Then
            .AppendLine("   AND PSP.PrecioVenta > 0")
         End If

         If conStock Then
            .AppendLine("   AND PS.Stock > 0 ")
         End If

         If parametros.ConsultarPreciosOcultarProdNoAfectanStock Then
            .AppendLine(" AND P.AfectaStock = 'True'")
         End If

         If esOferta <> "TODOS" Then
            .AppendFormatLine(" AND P.EsOferta = '{0}'", esOferta)
         End If

         If FechaActualizadoDesde > Date.Parse("01/01/1990") Then
            .AppendLine("	 AND  PSP.FechaActualizacion >= '" & FechaActualizadoDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	 AND  PSP.FechaActualizacion <= '" & FechaActualizadoHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         'El Agrupamiento es en Pantalla, pero aprovecho y lo ordeno.
         Select Case agruparPor
            Case "MARCA"
               .Append("   ORDER BY M.NombreMarca")

            Case "RUBRO"
               .Append("   ORDER BY R.NombreRubro")

            Case "MARCARUBRO"
               .Append("   ORDER BY  M.NombreMarca, R.NombreRubro")

            Case "RUBROMARCA"
               .Append("   ORDER BY  R.NombreRubro, M.NombreMarca")
            Case "RUBROSUBRUBROSUBSUBRUBRO"
               .Append("   ORDER BY  R.NombreRubro, SR.NombreSubRubro, SSR.NombreSubSubRubro ")
            Case Else      '"SUBRUBRO"
               .Append("   ORDER BY SR.NombreSubRubro, R.NombreRubro")
         End Select

         If ordenarPor = "CODIGO" Then
            'Sin la "P." para que tome los espacio para el orden numerico.
            .AppendLine(", IdProducto")
         Else
            .AppendLine(", P.NombreProducto")
         End If

      End With

      Return GetDataTable(stb.ToString())

   End Function

   Public Function GetPreciosEtiquetas(
                     sucursales() As Integer,
                     idProducto As String, nombreProducto As String,
                     marcas As Entidades.Marca(), rubros As Entidades.Rubro(),
                     idFormaPago As Integer?, idListaPrecios As Integer,
                     fechaActualizadoDesde As Date, fechaActualizadoHasta As Date, stock As String,
                     idTipoComprobante As String, letra As String, emisor As Integer, numeroComprobante As Long,
                     idProveedor As Long, imprimeLote As Boolean,
                     strAnchoIdProducto As String, blnPreciosConIVA As Boolean, srtCatFiscalEmp As Short,
                     redondeo As Integer, codigoBarras As Boolean, mostrarProveedorHabitual As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT ")
         .AppendLine("   CONVERT(BIT, 0) Imprime,")
         .AppendLine("   S.IdSucursal,")
         .AppendLine("	S.Nombre NombreSucursal,")
         .AppendLine("	RIGHT(REPLICATE(' '," & strAnchoIdProducto & ") + P.IdProducto," & strAnchoIdProducto & ") as IdProducto,")
         .AppendLine("	P.NombreProducto,")
         .AppendLine("	P.NombreCorto,")
         If blnPreciosConIVA Then
            .AppendFormatLine("   ROUND((1+(ISNULL(VFP.Porcentaje, 0))/100) * {1}, {0}) as PrecioVentaSinIVA,", redondeo, CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta", "P"))
            .AppendFormatLine("   P.Alicuota, ")
            .AppendFormatLine("   ROUND((1+(ISNULL(VFP.Porcentaje, 0))/100) * PSP.PrecioVenta, {0}) as PrecioVentaConIVA,", redondeo)

            'Lista de precios estandar
            .AppendFormatLine("   CASE WHEN PSP2.IdListaPrecios = P.UHListaPrecios1 AND P.UnidHasta1 > 0 THEN ROUND((1+(ISNULL(VFP.Porcentaje, 0))/100) * PSP2.PrecioVenta, 2) ELSE 0 END AS PrecioListaDePreciosConIVA,", redondeo)
            .AppendFormatLine("   CASE WHEN PSP2.IdListaPrecios = P.UHListaPrecios1 AND P.UnidHasta1 > 0 THEN ROUND((1+(ISNULL(VFP.Porcentaje, 0))/100) * {1}, {0}) ELSE 0 END AS PrecioListaDePreciosSinIVA,", redondeo, CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP2.PrecioVenta", "P"))
         Else
            .AppendFormatLine("   ROUND((1+(ISNULL(VFP.Porcentaje, 0))/100) * PSP.PrecioVenta, {0}) as PrecioVentaSinIVA,", redondeo)
            .AppendFormatLine("   P.Alicuota, ")
            .AppendFormatLine("   ROUND((1+(ISNULL(VFP.Porcentaje, 0))/100) * {1}, {0}) as PrecioVentaConIVA,", redondeo, CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta", "P"))

            'Lista de precios estandar
            .AppendFormatLine("   CASE WHEN PSP2.IdListaPrecios = P.UHListaPrecios1 AND P.UnidHasta1 > 0 THEN ROUND((1+(ISNULL(VFP.Porcentaje, 0))/100) * PSP2.PrecioVenta, {0}) ELSE 0 END AS PrecioListaDePreciosSinIVA,", redondeo)
            .AppendFormatLine("   CASE WHEN PSP2.IdListaPrecios = P.UHListaPrecios1 AND P.UnidHasta1 > 0 THEN ROUND((1+(ISNULL(VFP.Porcentaje, 0))/100) * {1}, {0}) ELSE 0 END AS PrecioListaDePreciosConIVA,", redondeo, CalculosImpositivos.ObtenerPrecioConImpuestos("PSP2.PrecioVenta", "P"))
         End If

         .AppendLine("	PS.Stock,")
         .AppendLine("	PS.StockInicial,")
         .AppendLine("	P.IdMarca,")
         .AppendLine("	M.NombreMarca,")
         .AppendLine("	P.IdRubro,")
         .AppendLine("	R.NombreRubro,")
         .AppendLine("	P.IdSubRubro,")
         .AppendLine("	SR.NombreSubRubro,")

         .AppendLine("	SR.TipoAtributo01,")
         .AppendLine("	SR.GrupoAtributo01,")
         .AppendLine("	SR.TipoAtributo02,")
         .AppendLine("	SR.GrupoAtributo02,")
         .AppendLine("	SR.TipoAtributo03,")
         .AppendLine("	SR.GrupoAtributo03,")
         .AppendLine("	SR.TipoAtributo04,")
         .AppendLine("	SR.GrupoAtributo04,")

         Dim CampoFecha = "PSP.FechaActualizacion"

         .AppendLine("	" & CampoFecha & ", ")

         .AppendLine("	P.CodigoDeBarras")

         If imprimeLote Then
            .AppendLine("	,Pl.IdLote As Lote")
         Else
            .AppendLine("	,0 As Lote")
         End If

         '-.PE-31715.-
         .AppendLine(" ,P.UnidHasta1")
         .AppendLine(" ,P.UHPorc1")
         .AppendLine(" ,PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(P.UHPorc1)/100)) as PrecioDesc")

         .AppendLine(" ,P.UnidHasta2")
         .AppendLine(" ,P.UHPorc2")
         .AppendLine("   ,CASE WHEN P.UHPorc2 = 0 THEN 0 ELSE PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(P.UHPorc2)/100)) END as PrecioDesc2
                         ,P.UnidHasta3
                         ,P.UHPorc3
                         ,CASE WHEN P.UHPorc3 = 0 THEN 0 ELSE PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(P.UHPorc3)/100)) END as PrecioDesc3
                         ,SR.UnidHasta1 AS UnidHastaSR1 
                         ,SR.UHPorc1 AS UHPorcSR1
                         ,CASE WHEN SR.UHPorc1 = 0 THEN 0 ELSE PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(SR.UHPorc1)/100)) END as PrecioDescSR1
                         ,SR.UnidHasta2 AS UnidHastaSR2
                         ,SR.UHPorc2 AS UHPorcSR2
                         ,CASE WHEN SR.UHPorc2 = 0 THEN 0 ELSE PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(SR.UHPorc2)/100)) END as PrecioDescSR2
                         ,SR.UnidHasta3 AS UnidHastaSR3
                         ,SR.UHPorc3 AS UHPorcSR3
                         ,CASE WHEN SR.UHPorc3 = 0 THEN 0 ELSE PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(SR.UHPorc3)/100)) END as PrecioDescSR3 ")

         .AppendLine(" ,P.Alto")
         .AppendLine(" ,P.Ancho")
         .AppendLine(" ,P.Largo")
         .AppendLine(" ,PS.Ubicacion")
         .AppendLine(" ,P.Foto")
         .AppendLine(" FROM ProductosSucursales PS")
         If Not String.IsNullOrEmpty(idTipoComprobante) And Not String.IsNullOrEmpty(letra) And emisor > 0 And numeroComprobante > 0 And idProveedor > 0 Then
            .AppendFormatLine("  INNER JOIN (SELECT IdProducto")
            .AppendFormatLine("                FROM ComprasProductos CP")
            .AppendFormatLine("               WHERE CP.IdTipoComprobante = '{0}'", idTipoComprobante)
            .AppendFormatLine("                 AND CP.Letra = '{0}'", letra)
            .AppendFormatLine("                 AND CP.CentroEmisor = {0}", emisor)
            .AppendFormatLine("                 AND CP.NumeroComprobante = {0}", numeroComprobante)
            .AppendFormatLine("                 AND CP.IdProveedor = {0}", idProveedor)
            .AppendFormatLine("               GROUP BY IdProducto")
            .AppendFormatLine("              ) CP ON CP.IdProducto = PS.IdProducto")
         End If
         .AppendLine("	LEFT JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendLine("	LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendLine("	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine("	LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")

         .AppendFormatLine("  LEFT JOIN VentasFormasPago VFP ON VFP.IdFormasPago = {0}", If(idFormaPago.HasValue, idFormaPago.Value, -1)) '-1 es para que no encuentre la Forma de Pago y el ISNULL pone 0 cuando no tilda en pantalla la forma de pago.

         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")

         .AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP2 ON PSP2.IdProducto = PS.IdProducto AND PSP2.IdSucursal = PS.IdSucursal AND PSP2.IdListaPrecios = P.UHListaPrecios1")

         If imprimeLote Then
            .AppendLine("  LEFT JOIN ProductosLotes Pl ON Pl.IdProducto = PS.IdProducto AND Pl.IdSucursal = PS.IdSucursal")
         End If

         If idProveedor > 0 Then
            If mostrarProveedorHabitual Then
               .AppendLine(" LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.Idproducto AND PP.IdProveedor = " & idProveedor.ToString())
            Else
               If idTipoComprobante = String.Empty Then
                  .AppendLine(" INNER JOIN ProductosProveedores PP ON PP.IdProducto = P.Idproducto AND PP.IdProveedor = " & idProveedor.ToString())
               End If
            End If
         End If

         .AppendLine(" WHERE PS.IdSucursal in (0")

         For Each suc As Object In sucursales
            If Integer.Parse(suc.ToString()) <> 0 Then
               .AppendLine("," & suc.ToString())
            End If
         Next
         .AppendLine(") ")

         .AppendFormatLine("	AND PSP.IdListaPrecios = {0}", idListaPrecios)

         .AppendFormatLine("	AND P.Activo = 1")   'Solo permito elegir los productos Activos

         If Not String.IsNullOrEmpty(idProducto) Then

            If codigoBarras Then
               .AppendFormatLine("	AND (P.IdProducto LIKE '%{0}%' OR P.CodigoDeBarras LIKE '%{0}%' OR", idProducto)
               .AppendFormatLine("       EXISTS(SELECT * FROM ProductosIdentificaciones PI WHERE PI.IdProducto = P.IdProducto AND PI.Identificacion LIKE '%{0}%'))", idProducto)
            Else
               .AppendFormatLine("	AND P.IdProducto LIKE '%" & idProducto & "%'")
            End If

         ElseIf Not String.IsNullOrEmpty(nombreProducto) Then

            'Si contiene espacio hago una busqueda por cada palabra
            If Not nombreProducto.Contains(" ") Then
               .AppendFormatLine("   AND P.NombreProducto LIKE '%" & nombreProducto & "%'")
            Else
               Dim Palabras() As String = nombreProducto.Split(" "c)

               .AppendFormatLine("   AND ( 1=1 ")
               For Each Palabra As String In Palabras
                  .AppendFormatLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
               Next

               .AppendLine("  )")
            End If
         End If


         If marcas IsNot Nothing AndAlso marcas.Length > 0 Then
            stb.AppendFormat("   AND {0}.IdMarca IN (", "P")
            For Each ent As Entidades.Marca In marcas
               stb.AppendFormat("{0},", ent.IdMarca)
            Next
            stb.AppendFormat("{0})", marcas(0).IdMarca)
         End If

         If rubros IsNot Nothing AndAlso rubros.Length > 0 Then
            stb.AppendFormat("   AND {0}.IdRubro IN (", "P")
            For Each ent As Entidades.Rubro In rubros
               stb.AppendFormat("{0},", ent.IdRubro)
            Next
            stb.AppendFormat("{0})", rubros(0).IdRubro)
         End If


         If fechaActualizadoDesde > Date.Parse("01/01/1990") Then
            .AppendLine("	 AND " & CampoFecha & " >= '" & fechaActualizadoDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	 AND " & CampoFecha & " <= '" & fechaActualizadoHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If stock = "SOLOPOSITIVOS" Then
            .AppendLine("	AND PS.Stock > 0")
         End If

         If mostrarProveedorHabitual Then
            .AppendLine("  AND  P.IdProveedor = " & idProveedor.ToString())
         End If

         .AppendLine(" ORDER BY P.NombreProducto")
      End With

      Return GetDataTable(stb.ToString())

   End Function

   Public Function GetPreciosEtiquetas2Listas(Sucursales() As Integer,
                                    IdProducto As String,
                                    NombreProducto As String,
                                    Marcas As Entidades.Marca(),
                                    Rubros As Entidades.Rubro(),
                                    idFormaPago As Integer?,
                                    idListaPrecios As Integer,
                                    idListaPrecios2 As Integer,
                                    FechaActualizadoDesde As Date,
                                    FechaActualizadoHasta As Date,
                                    Stock As String,
                                    strAnchoIdProducto As String,
                                    blnPreciosConIVA As Boolean,
                                    srtCatFiscalEmp As Short,
                                    redondeo As Integer,
                                    codigoBarras As Boolean,
                                    imprimeLote As Boolean) As DataTable
      Dim stb = New StringBuilder()
      Dim CampoFecha As String
      With stb
         .AppendLine("SELECT ")
         .AppendLine("   CONVERT(BIT, 0) Imprime,")
         .AppendLine("   S.IdSucursal,")
         .AppendLine("	S.Nombre NombreSucursal,")
         .AppendLine("	RIGHT(REPLICATE(' '," & strAnchoIdProducto & ") + P.IdProducto," & strAnchoIdProducto & ") as IdProducto,")
         .AppendLine("	P.NombreProducto,")
         .AppendLine("	P.NombreCorto,")

         If blnPreciosConIVA Then
            If idFormaPago.HasValue Then
               .AppendLine("	(1+(VFP.Porcentaje)/100) * ROUND(PSP.PrecioVenta / (1+(P.Alicuota/100)), " & redondeo & ") as PrecioVentaSinIVA,")
               .AppendLine("	(1+(VFP.Porcentaje)/100) * ROUND(PSP1.PrecioVenta / (1+(P.Alicuota/100)), " & redondeo & ") as PrecioVentaSinIVA1,")
               .AppendLine("   P.Alicuota, ")
               .AppendLine("	(1+(VFP.Porcentaje)/100) * PSP.PrecioVenta as PrecioVentaConIVA,")
               .AppendLine("	(1+(VFP.Porcentaje)/100) * PSP1.PrecioVenta as PrecioVentaConIVA1,")
            Else
               .AppendLine("	ROUND(PSP.PrecioVenta / (1+(P.Alicuota/100)), " & redondeo & ") as PrecioVentaSinIVA,")
               .AppendLine("	ROUND(PSP1.PrecioVenta / (1+(P.Alicuota/100)), " & redondeo & ") as PrecioVentaSinIVA1,")
               .AppendLine("   P.Alicuota, ")
               .AppendLine("	PSP.PrecioVenta as PrecioVentaConIVA,")
               .AppendLine("	PSP1.PrecioVenta as PrecioVentaConIVA1,")
            End If
         Else
            If idFormaPago.HasValue Then
               .AppendLine("	(1+(VFP.Porcentaje)/100) * PSP.PrecioVenta as PrecioVentaSinIVA,")
               .AppendLine("	(1+(VFP.Porcentaje)/100) * PSP1.PrecioVenta as PrecioVentaSinIVA1,")
               .AppendLine("   P.Alicuota, ")
               .AppendLine("	(1+(VFP.Porcentaje)/100) * ROUND(PSP.PrecioVenta * (1+(P.Alicuota/100)), " & redondeo & ") as PrecioVentaConIVA,")
               .AppendLine("	(1+(VFP.Porcentaje)/100) * ROUND(PSP1.PrecioVenta * (1+(P.Alicuota/100)), " & redondeo & ") as PrecioVentaConIVA1,")
            Else
               .AppendLine("	PSP.PrecioVenta as PrecioVentaSinIVA,")
               .AppendLine("	PSP1.PrecioVenta as PrecioVentaSinIVA1,")
               .AppendLine("   P.Alicuota, ")
               .AppendLine("	ROUND(PSP.PrecioVenta * (1+(P.Alicuota/100)), " & redondeo & ") as PrecioVentaConIVA,")
               .AppendLine("	ROUND(PSP1.PrecioVenta * (1+(P.Alicuota/100)), " & redondeo & ") as PrecioVentaConIVA1,")
            End If
         End If

         .AppendLine("	0 PrecioListaDePreciosConIVA,")
         .AppendLine("	0 PrecioListaDePreciosSinIVA,")

         .AppendLine("	PS.Stock,")
         .AppendLine("	PS.StockInicial,")
         .AppendLine("	P.IdMarca,")
         .AppendLine("	M.NombreMarca,")
         .AppendLine("	P.IdRubro,")
         .AppendLine("	R.NombreRubro,")
         .AppendLine("	P.IdSubRubro,")
         .AppendLine("	SR.NombreSubRubro,")

         .AppendLine("	SR.TipoAtributo01,")
         .AppendLine("	SR.GrupoAtributo01,")
         .AppendLine("	SR.TipoAtributo02,")
         .AppendLine("	SR.GrupoAtributo02,")
         .AppendLine("	SR.TipoAtributo03,")
         .AppendLine("	SR.GrupoAtributo03,")
         .AppendLine("	SR.TipoAtributo04,")
         .AppendLine("	SR.GrupoAtributo04,")

         CampoFecha = "PSP.FechaActualizacion"
         .AppendLine("	" & CampoFecha & ", ")

         .AppendLine("	P.CodigoDeBarras,")
         .AppendLine(" LP.NombreListaPrecios as ListaPrecio,")
         .AppendLine(" LP1.NombreListaPrecios as ListaPrecio1")

         '-.PE-31715.-
         .AppendLine(" ,P.UnidHasta1")
         .AppendLine(" ,P.UHPorc1")
         .AppendLine(" ,PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(P.UHPorc1)/100)) as PrecioDesc")
         .AppendLine(" ,P.UnidHasta2")
         .AppendLine(" ,P.UHPorc2")
         .AppendLine("   ,CASE WHEN P.UHPorc2 = 0 THEN 0 ELSE PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(P.UHPorc2)/100)) END as PrecioDesc2
                         ,P.UnidHasta3
                         ,P.UHPorc3
                         ,CASE WHEN P.UHPorc3 = 0 THEN 0 ELSE PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(P.UHPorc3)/100)) END as PrecioDesc3
                         ,SR.UnidHasta1 AS UnidHastaSR1 
                         ,SR.UHPorc1 AS UHPorcSR1
                         ,CASE WHEN SR.UHPorc1 = 0 THEN 0 ELSE PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(SR.UHPorc1)/100)) END as PrecioDescSR1
                         ,SR.UnidHasta2 AS UnidHastaSR2
                         ,SR.UHPorc2 AS UHPorcSR2
                         ,CASE WHEN SR.UHPorc2 = 0 THEN 0 ELSE PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(SR.UHPorc2)/100)) END as PrecioDescSR2
                         ,SR.UnidHasta3 AS UnidHastaSR3
                         ,SR.UHPorc3 AS UHPorcSR3
                         ,CASE WHEN SR.UHPorc3 = 0 THEN 0 ELSE PSP.PrecioVenta - (PSP.PrecioVenta * (ABS(SR.UHPorc3)/100)) END as PrecioDescSR3 ")

         .AppendLine(" ,P.Alto")
         .AppendLine(" ,P.Ancho")
         .AppendLine(" ,P.Largo")
         .AppendLine(" ,PS.Ubicacion")
         '-.PE-32046.-
         If imprimeLote Then
            .AppendLine("	,Pl.IdLote As Lote")
         Else
            .AppendLine("	,0 As Lote")
         End If
         .AppendLine(" ,P.Foto")
         .AppendLine(" FROM ProductosSucursales PS")
         .AppendLine("	LEFT JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendLine("	LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendLine("	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine("   LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
         .AppendLine("   LEFT JOIN ProductosSucursalesPrecios PSP1 ON PSP1.IdProducto = PS.IdProducto AND PSP1.IdSucursal = PS.IdSucursal")
         .AppendLine("  LEFT JOIN ListasDePrecios LP ON LP.IdListaPrecios = PSP.IdListaPrecios ")
         .AppendLine("  LEFT JOIN ListasDePrecios LP1 ON LP1.IdListaPrecios = PSP1.IdListaPrecios ")

         If idFormaPago.HasValue Then
            .AppendFormat("  LEFT JOIN VentasFormasPago VFP ON VFP.IdFormasPago = {0}", idFormaPago)
         End If

         '-.PE-32046.-
         If imprimeLote Then
            .AppendLine("   LEFT JOIN ProductosLotes Pl ON Pl.IdProducto = PS.IdProducto AND Pl.IdSucursal = PS.IdSucursal")
         End If
         .AppendLine("	LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")

         .AppendFormatLine("  LEFT JOIN VentasFormasPago VFP ON VFP.IdFormasPago = {0}", If(idFormaPago.HasValue, idFormaPago.Value, -1)) '-1 es para que no encuentre la Forma de Pago y el ISNULL pone 0 cuando no tilda en pantalla la forma de pago.

         .AppendLine(" WHERE PS.IdSucursal in (0")
         For Each suc As Object In Sucursales
            If Integer.Parse(suc.ToString()) <> 0 Then
               .AppendLine("," & suc.ToString())
            End If
         Next
         .AppendLine(") ")

         .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)
         .AppendFormat("	AND PSP1.IdListaPrecios = {0}", idListaPrecios2)


         .AppendLine("	AND P.Activo = 1")   'Solo permito elegir los productos Activos

         If Not String.IsNullOrEmpty(IdProducto) Then

            If codigoBarras Then
               .AppendLine("	AND (P.IdProducto LIKE '%" & IdProducto & "%' OR P.CodigoDeBarras LIKE '%" & IdProducto & "%')")
            Else
               .AppendLine("	AND P.IdProducto LIKE '%" & IdProducto & "%'")
            End If

         ElseIf Not String.IsNullOrEmpty(NombreProducto) Then

            'Si contiene espacio hago una busqueda por cada palabra
            If Not NombreProducto.Contains(" ") Then
               .AppendLine("   AND P.NombreProducto LIKE '%" & NombreProducto & "%'")
            Else
               Dim Palabras() As String = NombreProducto.Split(" "c)

               .Append("   AND ( 1=1 ")
               For Each Palabra As String In Palabras
                  .AppendLine("   AND P.NombreProducto LIKE '%" & Palabra & "%'")
               Next

               .AppendLine("  )")
            End If
         End If

         If Marcas IsNot Nothing AndAlso Marcas.Length > 0 Then
            stb.AppendFormat("   AND {0}.IdMarca IN (", "P")
            For Each ent As Entidades.Marca In Marcas
               stb.AppendFormat("{0},", ent.IdMarca)
            Next
            stb.AppendFormat("{0})", Marcas(0).IdMarca)
         End If

         If Rubros IsNot Nothing AndAlso Rubros.Length > 0 Then
            stb.AppendFormat("   AND {0}.IdRubro IN (", "P")
            For Each ent As Entidades.Rubro In Rubros
               stb.AppendFormat("{0},", ent.IdRubro)
            Next
            stb.AppendFormat("{0})", Rubros(0).IdRubro)
         End If


         If FechaActualizadoDesde > Date.Parse("01/01/1990") Then
            .AppendLine("	 AND " & CampoFecha & " >= '" & FechaActualizadoDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	 AND " & CampoFecha & " <= '" & FechaActualizadoHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If Stock = "SOLOPOSITIVOS" Then
            .AppendLine("	AND PS.Stock > 0")
         End If

         .AppendLine(" ORDER BY P.NombreProducto")
      End With

      Return GetDataTable(stb.ToString())

   End Function

   Public Function GetProductosActualizacionCodigo(idSucursal As Integer,
                                                   marcas As Entidades.Marca(),
                                                   rubros As Entidades.Rubro(),
                                                   subrubros As Entidades.SubRubro(),
                                                   idProducto As String,
                                                   activo As Boolean) As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	P.IdProducto,")
         .AppendFormatLine("	P.IdProductoNumerico,")
         .AppendFormatLine("	P.NombreProducto,")
         .AppendFormatLine("	M.NombreMarca,")
         .AppendFormatLine("	R.NombreRubro,")
         .AppendFormatLine("	SR.NombreSubRubro,")
         .AppendFormatLine("	P.IdFormula")
         .AppendFormatLine("FROM Productos P")
         .AppendFormatLine("INNER JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto AND PS.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("INNER JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendFormatLine("INNER JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendFormatLine("LEFT JOIN SubRubros SR ON P.IdSubRubro = SR.IdSubRubro")
         .AppendFormatLine("WHERE 1=1")
         .AppendFormatLine("  AND P.Activo = {0}", GetStringFromBoolean(activo))
         .AppendFormatLine("	AND PS.IdSucursal = {0}", idSucursal)
         If idProducto <> "0" Then
            .AppendFormatLine("	AND P.IdProducto = '{0}'", idProducto)
         End If


         GetListaMarcasMultiples(query, marcas, "M")
         GetListaRubrosMultiples(query, rubros, "R")
         If subrubros IsNot Nothing Then
            GetListaSubRubrosMultiples(query, subrubros, "SR")
         End If

      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub ActualizarIdProductoNumerico(idProducto As String, idProductoNumericoNuevo As Long)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE P SET P.IdProductoNumerico = {0} FROM Productos P WHERE IdProducto = '{1}'",
                           idProductoNumericoNuevo, idProducto)
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Function GetProductosService(idProducto As String,
                                       nombreProducto As String,
                                       idSucursal As Integer,
                                       idTipoComprobante As String,
                                       letra As String,
                                       centroEmisor As Short,
                                       numeroComprobante As Long,
                                       buscaProductoExacto As Boolean) As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT P.IdProducto, P.NombreProducto, MO.idModelo, MO.NombreModelo, MA.IdMarca, MA.NombreMarca, P.PermiteModificarDescripcion")

         If numeroComprobante > 0 Then
            .AppendFormatLine(", VP.Cantidad, VP.ImporteTotal")
         End If

         .AppendFormatLine("FROM Productos P")
         .AppendFormatLine(" LEFT JOIN Marcas MA ON P.IdMarca = MA.IdMarca")
         .AppendFormatLine(" LEFT JOIN Modelos MO ON P.IdModelo = MO.IdModelo")
         If numeroComprobante > 0 Then
            .AppendFormatLine(" INNER JOIN Ventas V ON V.IdSucursal = {0}", idSucursal)
            .AppendFormatLine("                    AND V.IdTipoComprobante = '{0}'", idTipoComprobante)
            .AppendFormatLine("					AND V.Letra = '{0}'", letra)
            .AppendFormatLine("					AND V.CentroEmisor = {0}", centroEmisor)
            .AppendFormatLine("					AND V.NumeroComprobante = {0} ", numeroComprobante)
            .AppendFormatLine(" INNER JOIN VentasProductos VP ON VP.IdProducto = P.IdProducto")
            .AppendFormatLine("                              AND VP.IdSucursal = V.IdSucursal")
            .AppendFormatLine("							  AND VP.IdTipoComprobante = V.IdTipoComprobante")
            .AppendFormatLine("							  AND VP.Letra = V.Letra")
            .AppendFormatLine("							  AND VP.CentroEmisor = V.CentroEmisor")
            .AppendFormatLine("							  AND VP.NumeroComprobante = V.NumeroComprobante")
         End If
         If Not String.IsNullOrEmpty(idProducto) OrElse Not String.IsNullOrEmpty(nombreProducto) Then
            Dim key As String = If(Not String.IsNullOrEmpty(idProducto), "IdProducto", "NombreProducto")
            Dim value As String = If(Not String.IsNullOrEmpty(idProducto), idProducto, nombreProducto)
            If buscaProductoExacto Then
               .AppendFormatLine(" WHERE P.{0} = '{1}'", key, value)
            Else
               .AppendFormatLine(" WHERE P.{0} LIKE '%{1}%'", key, value)
            End If
         End If
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function GetListasPreciosArborea(idSucursal As Integer, fechaUltimaSincronizacion As Date?,
                                               idListaPrecios01 As Integer, idListaPrecios02 As Integer, idListaPrecios03 As Integer, idListaPrecios04 As Integer,
                                               preciosConIva As Boolean, preciosConIvaPV As Boolean, preciosConIvaLP1 As Boolean,
                                             preciosConIvaLP2 As Boolean, preciosConIvaLP3 As Boolean, redondeoEnPreciosVenta As Integer,
                                               tipoTienda As Entidades.TiendasWeb) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT DISTINCT P.CodigoProducto{0} idProducto", tipoTienda)
         .AppendLine("       ,CASE WHEN(PS.Stock <= 0) THEN 0 ELSE PS.Stock END AS StockProducto")
         .AppendLine("       ,P.IdProducto AS SkuProducto")
         '-- REQ-42915.- -------------------------------------------------------------------------------------------------------------------------------
         If preciosConIva Then
            If preciosConIvaPV Then
               .AppendLine("       ,CASE WHEN(PSP0.PrecioVenta is NULL) THEN 0 ELSE PSP0.PrecioVenta END AS PrecioVenta")
            Else
               .AppendLine("       ,CASE WHEN(PSP0.PrecioVenta is NULL) THEN 0 ELSE (PSP0.PrecioVenta / (1+(P.Alicuota / 100))) END AS PrecioVenta")
            End If
            If preciosConIvaLP1 Then
               .AppendLine("       ,CASE WHEN(PSP1.PrecioVenta is NULL) THEN 0 ELSE PSP1.PrecioVenta END AS PrecioMayorista1")
            Else
               .AppendLine("       ,CASE WHEN(PSP1.PrecioVenta is NULL) THEN 0 ELSE (PSP1.PrecioVenta / (1+(P.Alicuota / 100))) END AS PrecioMayorista1")
            End If
            If preciosConIvaLP2 Then
               .AppendLine("       ,CASE WHEN(PSP2.PrecioVenta is NULL) THEN 0 ELSE PSP2.PrecioVenta END AS PrecioMayorista2")
            Else
               .AppendLine("       ,CASE WHEN(PSP2.PrecioVenta is NULL) THEN 0 ELSE (PSP2.PrecioVenta / (1+(P.Alicuota / 100))) END AS PrecioMayorista2")
            End If
            If preciosConIvaLP3 Then
               .AppendLine("       ,CASE WHEN(PSP3.PrecioVenta is NULL) THEN 0 ELSE PSP3.PrecioVenta END AS PrecioMayorista3")
            Else
               .AppendLine("       ,CASE WHEN(PSP3.PrecioVenta is NULL) THEN 0 ELSE (PSP3.PrecioVenta / (1+(P.Alicuota / 100))) END AS PrecioMayorista3")
            End If
         Else
            If preciosConIvaPV Then
               .AppendLine("       ,CASE WHEN(PSP0.PrecioVenta is NULL) THEN 0 ELSE (PSP0.PrecioVenta * (1+(P.Alicuota / 100))) END AS PrecioVenta")
            Else
               .AppendLine("       ,CASE WHEN(PSP0.PrecioVenta is NULL) THEN 0 ELSE PSP0.PrecioVenta END AS PrecioVenta")
            End If
            If preciosConIvaLP1 Then
               .AppendLine("       ,CASE WHEN(PSP1.PrecioVenta is NULL) THEN 0 ELSE (PSP1.PrecioVenta * (1+(P.Alicuota / 100))) END AS PrecioMayorista1")
            Else
               .AppendLine("       ,CASE WHEN(PSP1.PrecioVenta is NULL) THEN 0 ELSE PSP1.PrecioVenta END AS PrecioMayorista1")
            End If
            If preciosConIvaLP2 Then
               .AppendLine("       ,CASE WHEN(PSP2.PrecioVenta is NULL) THEN 0 ELSE (PSP2.PrecioVenta * (1+(P.Alicuota / 100))) END AS PrecioMayorista2")
            Else
               .AppendLine("       ,CASE WHEN(PSP2.PrecioVenta is NULL) THEN 0 ELSE PSP2.PrecioVenta END AS PrecioMayorista2")
            End If
            If preciosConIvaLP3 Then
               .AppendLine("       ,CASE WHEN(PSP3.PrecioVenta is NULL) THEN 0 ELSE (PSP3.PrecioVenta * (1+(P.Alicuota / 100))) END AS PrecioMayorista3")
            Else
               .AppendLine("       ,CASE WHEN(PSP3.PrecioVenta is NULL) THEN 0 ELSE PSP3.PrecioVenta END AS PrecioMayorista3")
            End If

         End If
         '----------------------------------------------------------------------------------------------------------------------------------------------
         .AppendLine("       ,P.IdMoneda")
         If tipoTienda = Entidades.TiendasWeb.ARBOREA Then
            .AppendFormatLine("	   , (CASE WHEN P.CodigoProducto{0} IS NOT NULL THEN 
                                      (CASE WHEN (P.Activo = 'False' OR P.PublicarEn{0} = 'False') THEN 'draft' ELSE 'publish' END) 
                                       ELSE 'publish' END) as Condicion", tipoTienda)
         End If
         '--- FROM.- ---
         .AppendFormatLine("FROM Productos P")
         .AppendFormatLine("INNER JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendFormatLine("LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto AND PS.IdSucursal = {0}", idSucursal)

         .AppendFormatLine("LEFT JOIN ProductosSucursalesPrecios PSP0 ON P.IdProducto = PSP0.IdProducto AND PSP0.IdSucursal = {0} AND PSP0.IdListaPrecios = {1}", idSucursal, idListaPrecios01)
         .AppendFormatLine("LEFT JOIN ProductosSucursalesPrecios PSP1 ON P.IdProducto = PSP1.IdProducto AND PSP1.IdSucursal = {0} AND PSP1.IdListaPrecios = {1}", idSucursal, idListaPrecios02)
         .AppendFormatLine("LEFT JOIN ProductosSucursalesPrecios PSP2 ON P.IdProducto = PSP2.IdProducto AND PSP2.IdSucursal = {0} AND PSP2.IdListaPrecios = {1}", idSucursal, idListaPrecios03)
         .AppendFormatLine("LEFT JOIN ProductosSucursalesPrecios PSP3 ON P.IdProducto = PSP3.IdProducto AND PSP3.IdSucursal = {0} AND PSP3.IdListaPrecios = {1}", idSucursal, idListaPrecios04)

         .AppendFormatLine("LEFT JOIN ProductosOfertas PO ON P.IdProducto = PO.IdProducto")
         .AppendFormatLine("INNER JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendFormatLine("LEFT JOIN SubRubros SR ON P.IdSubRubro = SR.IdSubRubro")
         .AppendFormatLine("LEFT JOIN SubSubRubros SSR ON P.IdSubSubRubro = SSR.IdSubSubRubro")


         .AppendFormatLine("WHERE 1=1 ")
         .AppendFormatLine("	And ((P.Activo = 'True' AND P.PublicarEn{0} = 'True' AND P.CodigoProducto{0} IS NOT NULL) OR (P.CodigoProducto{0} IS NOT NULL AND (P.Activo = 'False' OR P.PublicarEn{0} = 'False')))", tipoTienda)

         Select Case tipoTienda
            Case <> Entidades.TiendasWeb.ARBOREA
               If fechaUltimaSincronizacion.HasValue Then .AppendFormatLine("  AND (P.FechaActualizacionWeb > {0} OR PS.FechaActualizacionWeb > {0} OR PSP0.FechaActualizacionWeb > {0})", ObtenerFecha(fechaUltimaSincronizacion, True, True))
         End Select

         .AppendFormatLine("	AND (PO.IdProducto IS NULL OR (PO.FechaDesde <= '{0}' AND PO.FechaHasta >= '{0}' AND PO.Activa = 'True'))", ObtenerFecha(Now, True))

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function GetProductosPublicaWeb(webPublicar As Boolean) As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT DISTINCT P.IdProducto ")
         .AppendFormatLine("FROM Productos P")
         .AppendFormatLine("  WHERE P.PublicarEnWeb = {0} ", GetStringFromBoolean(webPublicar))
      End With
      Return GetDataTable(query)
   End Function
   Public Function GetProductosTiendasWeb(idSucursal As Integer,
                                          idListaPrecioPredeterminada As Integer,
                                          fechaUltimaSincronizacion As Date?,
                                          preciosConIva As Boolean,
                                          redondeoEnPreciosVenta As Integer,
                                          tipoTienda As Entidades.TiendasWeb,
                                          publicarPrecioPorEmbalaje As Boolean) As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT DISTINCT P.IdProducto")
         '-- REG31619.- --
         .AppendFormatLine("    ,(CASE WHEN (P.NombreProductoWeb IS NOT NULL AND P.NombreProductoWeb <> '') THEN P.NombreProductoWeb ELSE P.NombreProducto END) AS name")
         '----------------
         Select Case tipoTienda
            Case Entidades.TiendasWeb.ARBOREA
               .AppendFormatLine("	  ,(CASE WHEN (P.NombreProductoWeb IS NOT NULL AND P.NombreProductoWeb <> '') THEN P.NombreProductoWeb ELSE P.NombreProducto END) [description]")
            Case Else
               .AppendFormatLine("	  ,P.Observacion [description]")
         End Select


         .AppendFormatLine("	  ,P.CodigoProducto{0} id", tipoTienda)

         '# Variantes
         .AppendFormatLine(" ,P.IdVarianteProducto variant_id")
         If preciosConIva Then
            If publicarPrecioPorEmbalaje Then
               .AppendFormatLine(" ,PSP.PrecioVenta variant_price")
            Else
               .AppendFormatLine("  ,(CASE WHEN P.PrecioPorEmbalaje = 1 THEN PSP.PrecioVenta / P.Embalaje ELSE PSP.PrecioVenta END) AS  variant_price")
            End If
            .AppendFormatLine(" ,(CASE WHEN (PO.Activa = 'True' AND (PO.FechaDesde <= '{0}' AND PO.FechaHasta >= '{0}') AND PO.CantidadConsumida <> PO.LimiteStock) THEN PO.PrecioOferta ELSE NULL END) as variant_promotional_price", ObtenerFecha(Now, True))
         Else
            If publicarPrecioPorEmbalaje Then
               .AppendFormatLine(" ,ROUND({0}, {1}) AS variant_price",
                                CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), redondeoEnPreciosVenta)

            Else
               .AppendFormatLine(" ,ROUND({0}, {1}) AS variant_price",
                                CalculosImpositivos.ObtenerPrecioConImpuestos("(CASE WHEN P.PrecioPorEmbalaje = 1 THEN PSP.PrecioVenta / P.Embalaje ELSE PSP.PrecioVenta END)", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), redondeoEnPreciosVenta)

            End If
            .AppendFormatLine(" ,ROUND({0}, {1}) AS variant_promotional_price",
                                CalculosImpositivos.ObtenerPrecioConImpuestos("PO.PrecioOferta", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"), redondeoEnPreciosVenta)
         End If

         Select Case tipoTienda
            Case Entidades.TiendasWeb.MERCADOLIBRE
               .AppendFormatLine("	   , (CASE WHEN P.idCategoriaMercadoLibre IS NOT NULL THEN P.idCategoriaMercadoLibre 
                                 ELSE (CASE WHEN R.IdRubroMercadoLibre IS NOT NULL THEN R.IdRubroMercadoLibre ELSE PAR.ValorParametro END) END) as Categoria")
               .AppendFormatLine("	   , (CASE WHEN P.CodigoProductoMercadoLibre IS NOT NULL THEN 
                                      (CASE WHEN (P.Activo = 'False' OR P.PublicarEn{0} = 'False') THEN 'paused' ELSE 'update' END) 
                                       ELSE 'new' END) as Condicion", tipoTienda)
               .AppendFormatLine("	   , P.CodigoProductoMercadoLibre  as CodigoMercadoLibre")
            Case Entidades.TiendasWeb.ARBOREA
               .AppendFormatLine("	   , (CASE WHEN P.CodigoProductoArborea IS NOT NULL THEN 
                                      (CASE WHEN (P.Activo = 'False' OR P.PublicarEn{0} = 'False') THEN 'paused' ELSE 'update' END) 
                                       ELSE 'new' END) as Condicion", tipoTienda)
               .AppendFormatLine("	  ,P.CodigoProducto{0}", tipoTienda)
         End Select

         .AppendFormatLine("	  ,PS.Stock variant_stock")
         .AppendFormatLine("	  ,P.Ancho variant_width")
         .AppendFormatLine("	  ,P.Alto variant_height")
         .AppendFormatLine("	  ,P.Largo variant_depth")
         .AppendFormatLine("	  ,P.IdProducto variant_sku")
         .AppendFormatLine("	  ,ISNULL(P.CodigoDeBarras,'') variant_barcode")
         .AppendFormatLine("	  ,P.Kilos variant_weight")

         .AppendFormatLine("	  ,M.NombreMarca brand")
         .AppendFormatLine("	  ,P.NombreCorto")

         .AppendFormatLine("	  ,P.EnviarSinCargo free_shipping")
         .AppendFormatLine("	  ,P.EsServicio requires_shipping")

         .AppendFormatLine("	  ,SSR.IdSubSubRubro{0}", tipoTienda)
         .AppendFormatLine("	  ,SR.IdSubRubro{0}", tipoTienda)
         .AppendFormatLine("	  ,R.IdRubro{0}", tipoTienda)

         .AppendFormatLine("	  ,P.Activo")
         .AppendFormatLine("	  ,P.PublicarEn{0} PublicarEnWeb", tipoTienda)
         .AppendFormatLine("	  ,P.IdMoneda")

         .AppendFormatLine("FROM Productos P")
         .AppendFormatLine("INNER JOIN Marcas M ON P.IdMarca = M.IdMarca")
         .AppendFormatLine("LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto AND PS.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("LEFT JOIN ProductosSucursalesPrecios PSP ON P.IdProducto = PSP.IdProducto AND PSP.IdSucursal = {0} AND PSP.IdListaPrecios = {1}", idSucursal, idListaPrecioPredeterminada)
         .AppendFormatLine("LEFT JOIN ProductosOfertas PO ON P.IdProducto = PO.IdProducto")
         .AppendFormatLine("INNER JOIN Rubros R ON P.IdRubro = R.IdRubro")
         .AppendFormatLine("LEFT JOIN SubRubros SR ON P.IdSubRubro = SR.IdSubRubro")
         .AppendFormatLine("LEFT JOIN SubSubRubros SSR ON P.IdSubSubRubro = SSR.IdSubSubRubro")

         Select Case tipoTienda
            Case Entidades.TiendasWeb.MERCADOLIBRE
               .AppendFormatLine("CROSS JOIN (SELECT ValorParametro FROM Parametros WHERE IdParametro = 'MERCADOLIBRECATEGORIADEFAULT')  PAR")
         End Select

         .AppendFormatLine("WHERE 1=1 ")
         '-- REQ-34558.- ---------------------
         Select Case tipoTienda
            Case Entidades.TiendasWeb.ARBOREA
               .AppendFormatLine("	And ((P.Activo = 'True' AND P.PublicarEn{0} = 'True'))", tipoTienda)
            Case Else
               .AppendFormatLine("	And ((P.Activo = 'True' AND P.PublicarEn{0} = 'True') OR (P.CodigoProducto{0} IS NOT NULL AND (P.Activo = 'False' OR P.PublicarEn{0} = 'False')))", tipoTienda)
         End Select
         '-------------------------------------

         If fechaUltimaSincronizacion.HasValue Then .AppendFormatLine("  AND (P.FechaActualizacionWeb > {0} OR PS.FechaActualizacionWeb > {0} OR PSP.FechaActualizacionWeb > {0})", ObtenerFecha(fechaUltimaSincronizacion, True, True))
         '-- REQ-42295.- ---------------------------
         .AppendFormatLine("	AND ((PO.FechaDesde IS NULL OR PO.FechaDesde <= '{0}') AND (PO.FechaHasta IS NULL OR PO.FechaHasta >= '{0}')) AND (PO.Activa IS NULL OR PO.Activa = 'True')", ObtenerFecha(Now, True))
         '------------------------------------------
      End With
      Return GetDataTable(query)
   End Function

   Public Function GetMaxFechaActualizacionWeb() As DataTable
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("SELECT MAX(FechaActualizacionWeb) FechaActualizacionWeb FROM Productos P")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub GuardarIdProductoTiendaNube(idProducto As String, idProductoTiendaNube As String)
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("UPDATE P SET P.CodigoProductoTiendaNube = '{0}' FROM Productos P ", idProductoTiendaNube)
         .AppendFormatLine("	WHERE P.IdProducto = '{0}'", idProducto)
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Sub GuardarIdProductoTiendaWeb(idTiendaWeb As String, idProducto As String, idProductoTiendaWeb As String)
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("UPDATE P SET P.CodigoProducto" + idTiendaWeb + " = '{0}' FROM Productos P ", idProductoTiendaWeb)
         .AppendFormatLine("	WHERE P.IdProducto = '{0}'", idProducto)
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Sub GuardarIdVarianteProducto(idProducto As String, IdVarianteProducto As String)
      Dim query As New StringBuilder
      With query
         .AppendFormatLine("UPDATE P SET P.IdVarianteProducto = '{0}' FROM Productos P ", IdVarianteProducto)
         .AppendFormatLine("	WHERE P.IdProducto = '{0}'", idProducto)
      End With
      Me.Execute(query.ToString())
   End Sub


End Class