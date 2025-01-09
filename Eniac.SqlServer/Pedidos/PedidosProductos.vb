Public Class PedidosProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PedidosProductos_I(idSucursal As Integer,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroPedido As Long,
                                 idProducto As String,
                                 cantidad As Decimal,
                                 precio As Decimal,
                                 precioLista As Decimal,
                                 costo As Decimal,
                                 importeTotal As Decimal,
                                 nombreProducto As String,
                                 cantPendiente As Decimal,
                                 cantEntregada As Decimal,
                                 cantEnProceso As Decimal,
                                 cantAnulada As Decimal,
                                 descuentoRecargoProducto As Double,
                                 descuentoRecargoPorc1 As Double,
                                 descuentoRecargoPorc2 As Double,
                                 idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                 alicuotaImpuesto As Decimal,
                                 importeImpuesto As Decimal,
                                 orden As Integer,
                                 fechaActualizacion As Date,
                                 idListaPrecios As Integer,
                                 nombreListaPrecios As String,
                                 importeImpuestoInterno As Decimal,
                                 precioNeto As Decimal,
                                 importeTotalNeto As Decimal,
                                 descRecGeneral As Decimal,
                                 descRecGeneralProducto As Decimal,
                                 kilos As Decimal,
                                 idCriticidad As String,
                                 fechaEntrega As Date,
                                 precioConImpuestos As Decimal,
                                 precioNetoConImpuestos As Decimal,
                                 importeTotalConImpuestos As Decimal,
                                 importeTotalNetoConImpuestos As Decimal,
                                 precioVentaPorTamano As Decimal,
                                 tamano As Decimal,
                                 idUnidadDeMedida As String,
                                 idMoneda As Integer,
                                 espmm As Decimal,
                                 espPulgadas As String,
                                 codigoSAE As String,
                                 idProduccionProceso As Integer,
                                 idProduccionForma As Integer,
                                 largoExtAlto As Decimal,
                                 anchoIntBase As Decimal,
                                 architrave As Decimal,
                                 idProduccionModeloForma As Integer,
                                 urlPlano As String,
                                 idFormula As Integer,
                                 idProcesoProductivo As Long,
                                 porcImpuestoInterno As Decimal,
                                 origenPorcImpInt As Entidades.OrigenesPorcImpInt,
                                 tipoOperacion As String,
                                 nota As String,
                                 nombreCortoListaPrecios As String,
                                 automatico As Boolean,
                                 modificoPrecioManualmente As Boolean,
                                 cantidadManual As Decimal,
                                 conversion As Decimal,
                                 modificoDescuentos As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO PedidosProductos")
         .AppendFormatLine("           (IdSucursal")
         .AppendFormatLine("           ,IdTipoComprobante")
         .AppendFormatLine("           ,Letra")
         .AppendFormatLine("           ,CentroEmisor")
         .AppendFormatLine("           ,NumeroPedido")
         .AppendFormatLine("           ,idProducto")
         .AppendFormatLine("           ,cantidad")
         .AppendFormatLine("           ,precio")
         .AppendFormatLine("           ,precioLista")
         .AppendFormatLine("           ,costo")
         .AppendFormatLine("           ,importeTotal")
         .AppendFormatLine("           ,nombreProducto")

         .AppendFormatLine("           ,cantPendiente")
         .AppendFormatLine("           ,cantEntregada")
         .AppendFormatLine("           ,cantEnProceso")
         .AppendFormatLine("           ,cantAnulada")

         .AppendFormatLine("           ,DescuentoRecargoProducto")
         .AppendFormatLine("           ,DescuentoRecargoPorc")
         .AppendFormatLine("           ,DescuentoRecargoPorc2")
         .AppendFormatLine("           ,IdTipoImpuesto")
         .AppendFormatLine("           ,AlicuotaImpuesto")
         .AppendFormatLine("           ,ImporteImpuesto")
         .AppendFormatLine("           ,Orden")
         .AppendFormatLine("           ,FechaActualizacion")
         .AppendFormatLine("           ,IdListaPrecios")
         .AppendFormatLine("           ,NombreListaPrecios")

         .AppendFormatLine("           ,ImporteImpuestoInterno")
         .AppendFormatLine("           ,PorcImpuestoInterno")
         .AppendFormatLine("           ,OrigenPorcImpInt")
         .AppendFormatLine("           ,PrecioNeto")
         .AppendFormatLine("           ,ImporteTotalNeto")
         .AppendFormatLine("           ,DescRecGeneral")
         .AppendFormatLine("           ,DescRecGeneralProducto")
         .AppendFormatLine("           ,Kilos")
         .AppendFormatLine("           ,IdCriticidad")
         .AppendFormatLine("           ,FechaEntrega")

         .AppendFormatLine("           ,PrecioConImpuestos")
         .AppendFormatLine("           ,PrecioNetoConImpuestos")
         .AppendFormatLine("           ,ImporteTotalConImpuestos")
         .AppendFormatLine("           ,ImporteTotalNetoConImpuestos")

         .AppendFormatLine("           ,PrecioVentaPorTamano")
         .AppendFormatLine("           ,Tamano")
         .AppendFormatLine("           ,IdUnidadDeMedida")
         .AppendFormatLine("           ,IdMoneda")

         .AppendFormatLine("           ,Espmm")
         .AppendFormatLine("           ,EspPulgadas")
         .AppendFormatLine("           ,CodigoSAE")
         .AppendFormatLine("           ,IdProduccionProceso")
         .AppendFormatLine("           ,IdProduccionForma")
         .AppendFormatLine("           ,LargoExtAlto")
         .AppendFormatLine("           ,AnchoIntBase")
         .AppendFormatLine("           ,Architrave")
         .AppendFormatLine("           ,IdProduccionModeloForma")
         .AppendFormatLine("           ,UrlPlano")
         .AppendFormatLine("           ,IdFormula")
         .AppendFormatLine("           ,IdProcesoProductivo")
         .AppendFormatLine("           ,TipoOperacion")
         .AppendFormatLine("           ,Nota")
         .AppendFormatLine("           ,NombreCortoListaPrecios")
         .AppendFormatLine("           ,Automatico")
         .AppendFormatLine("           ,ModificoPrecioManualmente")
         .AppendFormatLine("           ,CantidadManual")
         .AppendFormatLine("           ,Conversion")
         .AppendFormatLine("           ,ModificoDescuentos")

         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("            {0} ", idSucursal)
         .AppendFormatLine("          ,'{0}'", idTipoComprobante)
         .AppendFormatLine("          ,'{0}'", letra)
         .AppendFormatLine("          , {0} ", centroEmisor)
         .AppendFormatLine("          , {0} ", numeroPedido)
         .AppendFormatLine("          ,'{0}'", idProducto)
         .AppendFormatLine("          , {0} ", cantidad)
         .AppendFormatLine("          , {0} ", precio)
         .AppendFormatLine("          , {0} ", precioLista)
         .AppendFormatLine("          , {0} ", costo)
         .AppendFormatLine("          , {0} ", importeTotal)
         .AppendFormatLine("          ,'{0}'", nombreProducto)

         .AppendFormatLine("          , {0} ", cantPendiente)
         .AppendFormatLine("          , {0} ", cantEntregada)
         .AppendFormatLine("          , {0} ", cantEnProceso)
         .AppendFormatLine("          , {0} ", cantAnulada)

         .AppendFormatLine("          , {0} ", descuentoRecargoProducto.ToString())
         .AppendFormatLine("          , {0} ", descuentoRecargoPorc1.ToString())
         .AppendFormatLine("          , {0} ", descuentoRecargoPorc2.ToString())
         .AppendFormatLine("          ,'{0}'", idTipoImpuesto.ToString())
         .AppendFormatLine("          , {0} ", alicuotaImpuesto)
         .AppendFormatLine("          , {0} ", importeImpuesto)
         .AppendFormatLine("          , {0} ", orden)
         .AppendFormatLine("          ,'{0}'", ObtenerFecha(fechaActualizacion, True))
         .AppendFormatLine("          , {0} ", idListaPrecios)
         .AppendFormatLine("          ,'{0}'", nombreListaPrecios)
         .AppendFormatLine("          , {0} ", importeImpuestoInterno)
         .AppendFormatLine("          , {0} ", porcImpuestoInterno)
         .AppendFormatLine("          ,'{0}'", origenPorcImpInt)
         .AppendFormatLine("          , {0} ", precioNeto)
         .AppendFormatLine("          , {0} ", importeTotalNeto)
         .AppendFormatLine("          , {0} ", descRecGeneral)
         .AppendFormatLine("          , {0} ", descRecGeneralProducto)
         .AppendFormatLine("          , {0} ", kilos)

         .AppendFormatLine("          ,'{0}'", idCriticidad)
         .AppendFormatLine("          ,'{0}'", ObtenerFecha(fechaEntrega, True))

         .AppendFormatLine("          , {0} ", precioConImpuestos)
         .AppendFormatLine("          , {0} ", precioNetoConImpuestos)
         .AppendFormatLine("          , {0} ", importeTotalConImpuestos)
         .AppendFormatLine("          , {0} ", importeTotalNetoConImpuestos)

         .AppendFormatLine("          , {0} ", precioVentaPorTamano)
         .AppendFormatLine("          , {0} ", tamano)
         If Not String.IsNullOrWhiteSpace(idUnidadDeMedida) Then
            .AppendFormatLine("          ,'{0}'", idUnidadDeMedida)
         Else
            .AppendFormatLine("          ,NULL")
         End If

         If idMoneda > 0 Then
            .AppendFormatLine("          , {0} ", idMoneda)
         Else
            .AppendFormatLine("          ,NULL")
         End If

         .AppendFormatLine(" ,{0}", espmm)
         .AppendFormatLine(" ,'{0}'", espPulgadas)
         .AppendFormatLine(" ,'{0}'", codigoSAE)

         If idProduccionProceso > 0 Then
            .AppendFormatLine(" ,{0}", idProduccionProceso)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         If idProduccionForma > 0 Then
            .AppendFormatLine(" ,{0}", idProduccionForma)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         .AppendFormatLine(" ,{0}", largoExtAlto)
         .AppendFormatLine(" ,{0}", anchoIntBase)
         .AppendFormatLine(" ,{0}", architrave)
         .AppendFormatLine(" ,{0}", GetStringFromNumber(idProduccionModeloForma))

         .AppendFormatLine(" ,'{0}'", urlPlano)

         If idFormula > 0 Then
            .AppendFormatLine(" ,{0}", idFormula)
         Else
            .AppendFormatLine(" ,NULL")
         End If
         .AppendFormatLine(" ,{0}", GetStringFromNumber(idProcesoProductivo))
         .AppendFormatLine(" ,'{0}'", tipoOperacion)
         .AppendFormatLine(" ,'{0}'", nota)
         .AppendFormatLine(" ,'{0}'", nombreCortoListaPrecios)

         .AppendFormatLine(" ,{0} ", GetStringFromBoolean(automatico))
         .AppendFormatLine(" ,{0} ", GetStringFromBoolean(modificoPrecioManualmente))
         .AppendFormatLine(" ,{0} ", cantidadManual)
         .AppendFormatLine(" ,{0} ", conversion)
         .AppendFormatLine(" ,{0} ", GetStringFromBoolean(modificoDescuentos))

         .AppendFormatLine(")")
      End With

      Execute(myQuery)
   End Sub
   Public Sub PedidosProductos_U(idSucursal As Integer,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroPedido As Long,
                                 idProducto As String,
                                 cantidad As Decimal,
                                 precio As Decimal,
                                 precioLista As Decimal,
                                 costo As Decimal,
                                 importeTotal As Decimal,
                                 nombreProducto As String,
                                 cantPendiente As Decimal,
                                 cantEntregada As Decimal,
                                 cantEnProceso As Decimal,
                                 cantAnulada As Decimal,
                                 descuentoRecargoProducto As Double,
                                 descuentoRecargoPorc1 As Double,
                                 descuentoRecargoPorc2 As Double,
                                 idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                 alicuotaImpuesto As Decimal,
                                 importeImpuesto As Decimal,
                                 orden As Integer,
                                 fechaActualizacion As Date,
                                 idListaPrecios As Integer,
                                 nombreListaPrecios As String,
                                 importeImpuestoInterno As Decimal,
                                 precioNeto As Decimal,
                                 importeTotalNeto As Decimal,
                                 descRecGeneral As Decimal,
                                 descRecGeneralProducto As Decimal,
                                 kilos As Decimal,
                                 idCriticidad As String,
                                 fechaEntrega As Date,
                                 precioConImpuestos As Decimal,
                                 precioNetoConImpuestos As Decimal,
                                 importeTotalConImpuestos As Decimal,
                                 importeTotalNetoConImpuestos As Decimal,
                                 precioVentaPorTamano As Decimal,
                                 tamano As Decimal,
                                 idUnidadDeMedida As String,
                                 idMoneda As Integer,
                                 espmm As Decimal,
                                 espPulgadas As String,
                                 codigoSAE As String,
                                 idProduccionProceso As Integer,
                                 idProduccionForma As Integer,
                                 largoExtAlto As Decimal,
                                 anchoIntBase As Decimal,
                                 architrave As Decimal,
                                 idProduccionModeloForma As Integer,
                                 urlPlano As String,
                                 idFormula As Integer,
                                 idProcesoProductivo As Long,
                                 porcImpuestoInterno As Decimal,
                                 origenPorcImpInt As Entidades.OrigenesPorcImpInt,
                                 tipoOperacion As String,
                                 nota As String,
                                 nombreCortoListaPrecios As String,
                                 automatico As Boolean,
                                 modificoPrecioManualmente As Boolean,
                                 cantidadManual As Decimal,
                                 conversion As Decimal,
                                 modificoDescuentos As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE PedidosProductos SET")

         .AppendFormatLine("       {0} =  {1} ", Entidades.PedidoProducto.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.Precio.ToString(), precio)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.PrecioLista.ToString(), precioLista)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.Costo.ToString(), costo)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.ImporteTotal.ToString(), importeTotal)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.NombreProducto.ToString(), nombreProducto)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.CantPendiente.ToString(), cantPendiente)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.CantEntregada.ToString(), cantEntregada)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.CantEnProceso.ToString(), cantEnProceso)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.CantAnulada.ToString(), cantAnulada)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.DescuentoRecargoProducto.ToString(), descuentoRecargoProducto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.DescuentoRecargoPorc.ToString(), descuentoRecargoPorc1)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.DescuentoRecargoPorc2.ToString(), descuentoRecargoPorc2)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.IdTipoImpuesto.ToString(), idTipoImpuesto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.AlicuotaImpuesto.ToString(), alicuotaImpuesto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.ImporteImpuesto.ToString(), importeImpuesto)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.FechaActualizacion.ToString(), ObtenerFecha(fechaActualizacion, True))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.IdListaPrecios.ToString(), idListaPrecios)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.NombreListaPrecios.ToString(), nombreListaPrecios)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.ImporteImpuestoInterno.ToString(), importeImpuestoInterno)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.PorcImpuestoInterno.ToString(), porcImpuestoInterno)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.OrigenPorcImpInt.ToString(), origenPorcImpInt)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.PrecioNeto.ToString(), precioNeto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.ImporteTotalNeto.ToString(), importeTotalNeto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.DescRecGeneral.ToString(), descRecGeneral)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.DescRecGeneralProducto.ToString(), descRecGeneralProducto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.Kilos.ToString(), kilos)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.IdCriticidad.ToString(), GetStringParaQueryConComillas(idCriticidad))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.FechaEntrega.ToString(), ObtenerFecha(fechaEntrega, True))

         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.PrecioConImpuestos.ToString(), precioConImpuestos)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.PrecioNetoConImpuestos.ToString(), precioNetoConImpuestos)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.ImporteTotalConImpuestos.ToString(), importeTotalConImpuestos)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.ImporteTotalNetoConImpuestos.ToString(), importeTotalNetoConImpuestos)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.PrecioVentaPorTamano.ToString(), precioVentaPorTamano)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.Tamano.ToString(), tamano)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.IdUnidadDeMedida.ToString(), GetStringParaQueryConComillas(idUnidadDeMedida))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.IdMoneda.ToString(), GetStringFromNumber(idMoneda))

         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.Espmm.ToString(), espmm)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.EspPulgadas.ToString(), espPulgadas)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.CodigoSAE.ToString(), codigoSAE)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.IdProduccionProceso.ToString(), GetStringFromNumber(idProduccionProceso))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.IdProduccionForma.ToString(), GetStringFromNumber(idProduccionForma))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.LargoExtAlto.ToString(), largoExtAlto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.AnchoIntBase.ToString(), anchoIntBase)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.Architrave.ToString(), architrave)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.IdProduccionModeloForma.ToString(), GetStringFromNumber(idProduccionModeloForma))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.UrlPlano.ToString(), urlPlano)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.IdFormula.ToString(), GetStringFromNumber(idFormula))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.IdProcesoProductivo.ToString(), GetStringFromNumber(idProcesoProductivo))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.TipoOperacion.ToString(), tipoOperacion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.Nota.ToString(), nota)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoProducto.Columnas.NombreCortoListaPrecios.ToString(), nombreCortoListaPrecios)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.Automatico.ToString(), GetStringFromBoolean(automatico))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.ModificoPrecioManualmente.ToString(), GetStringFromBoolean(modificoPrecioManualmente))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.CantidadManual.ToString(), cantidadManual)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.Conversion.ToString(), conversion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.PedidoProducto.Columnas.ModificoDescuentos.ToString(), GetStringFromBoolean(modificoDescuentos))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.PedidoProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.PedidoProducto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.PedidoProducto.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.PedidoProducto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.PedidoProducto.Columnas.NumeroPedido.ToString(), numeroPedido)

         .AppendFormatLine("   AND {0} = '{1}'", Entidades.PedidoProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.PedidoProducto.Columnas.Orden.ToString(), orden)

      End With

      Execute(myQuery)
   End Sub

   Public Sub PedidosProductos_UDescripcion(IdProducto As String, NombreProducto As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE PedidosProductos  SET ")
         .AppendLine("  NombreProducto = '" & NombreProducto.ToString() & "'")
         .AppendLine("  FROM PedidosProductos  PP ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = PP.IdTipoComprobante")
         .AppendLine(" WHERE IdProducto = '" & IdProducto & "'")
         .AppendLine(" AND (TC.EsElectronico = 'False' OR TC.EsPREElectronico = 'True' ) ")
         .AppendLine(" AND TC.EsFiscal = 'False'")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "PedidosProductos")
   End Sub
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PP.* ")
         .AppendFormatLine("      ,PS.Stock")
         .AppendFormatLine("      ,PRP.NombreProduccionProceso")
         .AppendFormatLine("      ,PRF.NombreProduccionForma")
         .AppendFormatLine("      ,PF.NombreFormula")
         .AppendFormatLine("      ,PrPr.CodigoProcesoProductivo")
         .AppendFormatLine("      ,PrPr.DescripcionProceso DescripcionProcesoProductivo")
         .AppendFormatLine("      ,M.NombreMarca")
         .AppendFormatLine("      ,PV.CodigoProductoProveedor")
         .AppendFormatLine("      ,P.Embalaje")
         .AppendFormatLine("      ,P.EsObservacion")
         .AppendFormatLine("  FROM PedidosProductos PP")
         .AppendFormatLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PP.IdProducto AND PS.IdSucursal = {0}", actual.Sucursal.IdSucursal)
         .AppendFormatLine("  LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = PP.IdProduccionForma")
         .AppendFormatLine("  LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = PP.IdProduccionProceso")
         .AppendFormatLine("  LEFT JOIN ProductosFormulas PF ON PF.IdProducto = PP.IdProducto AND PF.IdFormula = PP.IdFormula")
         .AppendFormatLine("  LEFT JOIN Productos P ON P.IdProducto = PP.IdProducto")
         .AppendFormatLine("  LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("  LEFT JOIN ProductosProveedores PV ON PV.IdProducto = PP.IdProducto AND PV.IdProveedor = P.IdProveedor")
         .AppendFormatLine("  LEFT JOIN MRPProcesosProductivos PrPr ON PrPr.IdProcesoProductivo = PP.IdProcesoProductivo")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Select Case columna
         Case "Stock"
            columna = "PS." + columna
         Case "NombreProduccionProceso"
            columna = "PRP." + columna
         Case "NombreProduccionForma"
            columna = "PRF." + columna
         Case "NombreFormula"
            columna = "PF." + columna
         Case "DescripcionProcesoProductivo"
            columna = "PrPr.DescripcionProceso"
         Case Else
            columna = "PP." + columna
      End Select

      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub PedidosProductos_D(idSucursal As Integer,
                                 idTipoComprobante As String, letra As String,
                                 centroEmisor As Integer, numeroPedido As Long,
                                 orden As Integer?, idProducto As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormat("DELETE FROM PedidosProductos").AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", letra)
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido)
         If orden.HasValue Then
            .AppendFormat("   AND Orden = {0}", orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND IdProducto = '{0}'", idProducto)
         End If
      End With
      Execute(stb)
   End Sub

   Public Function PedidosProductos_GA() As DataTable
      Return PedidosProductos_G(Nothing, String.Empty, String.Empty, Nothing, Nothing, Nothing, String.Empty)
   End Function

   Public Function PedidosProductos_GA(idSucursal As Integer,
                                       idTipoComprobante As String, letra As String,
                                       centroEmisor As Integer, numeroPedido As Long) As DataTable
      Return PedidosProductos_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, Nothing, String.Empty)
   End Function

   Public Function PedidosProductos_G1(idSucursal As Integer,
                                       idTipoComprobante As String, letra As String,
                                       centroEmisor As Integer, numeroPedido As Long,
                                       orden As Integer, idProducto As String) As DataTable
      Return PedidosProductos_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto)
   End Function

   Private Function PedidosProductos_G(idSucursal As Integer?,
                                       idTipoComprobante As String, letra As String,
                                       centroEmisor As Integer?, numeroPedido As Long?,
                                       orden As Integer?, idProducto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If idSucursal.HasValue Then
            .AppendFormat("   AND PP.IdSucursal = {0}", idSucursal.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND PP.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND PP.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor.HasValue Then
            .AppendFormat("   AND PP.CentroEmisor = {0}", centroEmisor.Value).AppendLine()
         End If
         If numeroPedido.HasValue Then
            .AppendFormat("   AND PP.NumeroPedido = {0}", numeroPedido.Value).AppendLine()
         End If
         If orden.HasValue Then
            .AppendFormat("   AND PP.Orden = {0}", orden.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND PP.IdProducto = '{0}'", idProducto).AppendLine()
         End If

         .AppendFormat(" ORDER BY PP.IdSucursal, PP.IdTipoComprobante, PP.Letra, PP.CentroEmisor, PP.NumeroPedido, PP.Orden, PP.IdProducto")
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub ReseteaCantidades(idSucursal As Integer,
                                idTipoComprobante As String,
                                letra As String,
                                centroEmisor As Integer,
                                numeroPedido As Long,
                                idProducto As String,
                                orden As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosProductos")
         .AppendLine("   SET Cantidad = Cantidad")
         .AppendFormat("     , CantPendiente = Cantidad").AppendLine()
         .AppendFormat("     , CantEnProceso = 0").AppendLine()
         .AppendFormat("     , CantEntregada = 0").AppendLine()
         .AppendFormat("     , CantAnulada   = 0").AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         .AppendFormat("   AND IdProducto = '{0}'", idProducto).AppendLine()
         .AppendFormat("   AND Orden = {0}", orden).AppendLine()
      End With
      Execute(stbQuery)
   End Sub

   Public Sub ActualizarCantidades(idSucursal As Integer,
                                   idTipoComprobante As String,
                                   letra As String,
                                   centroEmisor As Integer,
                                   numeroPedido As Long,
                                   idProducto As String,
                                   orden As Integer,
                                   deltaCantidadPendiente As Decimal,
                                   deltaCantidadEnProceso As Decimal,
                                   deltaCantidadEntregada As Decimal,
                                   deltaCantidadAnulada As Decimal)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosProductos")
         .AppendLine("   SET Cantidad = Cantidad")
         .AppendFormat("     , CantPendiente = CantPendiente + {0}", deltaCantidadPendiente).AppendLine()
         .AppendFormat("     , CantEnProceso = CantEnProceso + {0}", deltaCantidadEnProceso).AppendLine()
         .AppendFormat("     , CantEntregada = CantEntregada + {0}", deltaCantidadEntregada).AppendLine()
         .AppendFormat("     , CantAnulada   = CantAnulada   + {0}", deltaCantidadAnulada).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         .AppendFormat("   AND IdProducto = '{0}'", idProducto).AppendLine()
         .AppendFormat("   AND Orden = {0}", orden).AppendLine()
      End With
      Execute(stbQuery)
   End Sub

   Public Sub NormalizaCantidadesSegunEstado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                             idProducto As String, orden As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("UPDATE PP")
         .AppendFormatLine("   SET CantPendiente = PE.CantPendiente")
         .AppendFormatLine("     , CantEnProceso = PE.CantEnProceso")
         .AppendFormatLine("     , CantEntregada = PE.CantEntregada")
         .AppendFormatLine("     , CantAnulada   = PE.CantAnulada  ")
         .AppendFormatLine("  FROM (SELECT PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.IdProducto, PE.Orden")
         .AppendFormatLine("             , SUM(CASE WHEN  EP.IdTipoEstado = '{0}' THEN PE.CantEstado ELSE 0 END) CantPendiente", Entidades.EstadoPedido.TipoEstado.PENDIENTE.ToString())
         .AppendFormatLine("             , SUM(CASE WHEN  EP.IdTipoEstado = '{0}' THEN PE.CantEstado ELSE 0 END) CantEnProceso", Entidades.EstadoPedido.TipoEstado.ENPROCESO.ToString())
         .AppendFormatLine("             , SUM(CASE WHEN  EP.IdTipoEstado = '{0}' THEN PE.CantEstado ELSE 0 END) CantEntregada", Entidades.EstadoPedido.TipoEstado.ENTREGADO.ToString())
         .AppendFormatLine("             , SUM(CASE WHEN (EP.IdTipoEstado = '{0}' AND PE.AnulacionPorModificacion = 0)        ", Entidades.EstadoPedido.TipoEstado.ANULADO.ToString())
         .AppendFormatLine("                          OR  EP.IdTipoEstado = '{0}' THEN PE.CantEstado ELSE 0 END) CantAnulada  ", Entidades.EstadoPedido.TipoEstado.RECHAZADO.ToString())
         .AppendFormatLine("          FROM PedidosEstados PE")
         .AppendFormatLine("         INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendFormatLine("         WHERE PE.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("           AND PE.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("           AND PE.Letra = '{0}'", letra)
         .AppendFormatLine("           AND PE.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("           AND PE.NumeroPedido = {0}", numeroPedido)
         .AppendFormatLine("         GROUP BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.IdProducto, PE.Orden) PE")
         .AppendFormatLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = PE.IdSucursal")
         .AppendFormatLine("                               AND PP.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendFormatLine("                               AND PP.Letra = PE.Letra")
         .AppendFormatLine("                               AND PP.CentroEmisor = PE.CentroEmisor")
         .AppendFormatLine("                               AND PP.NumeroPedido = PE.NumeroPedido")
         .AppendFormatLine("                               AND PP.IdProducto = PE.IdProducto")
         .AppendFormatLine("                               AND PP.Orden = PE.Orden")
      End With
      Execute(stbQuery)
   End Sub

   Public Sub AnularCantidadEntregada(idSucursal As Integer,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Integer,
                                      numeroPedido As Long,
                                      idProducto As String,
                                      Cantidad As Decimal,
                                      orden As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosProductos")
         If Cantidad = 0 Then
            .AppendLine("   SET CantEntregada = " & Cantidad)
         Else
            .AppendLine("   SET CantEntregada = CantEntregada - " & Cantidad)
         End If
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)
      End With
      Execute(stbQuery)
   End Sub

   Public Function GetListasPreciosPedidosProductos() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT DISTINCT IdListaPrecios, NombreListaPrecios FROM PedidosProductos ORDER BY NombreListaPrecios ASC")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class