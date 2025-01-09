Public Class TiposComprobantes
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("TiposComprobantes", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT")
         .Append(" T.*")
         .Append(" FROM  ")
         .Append("TiposComprobantes T ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposComprobantes(da).TiposComprobantes_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)
      Dim tipoDoc As Entidades.TipoComprobante = DirectCast(entidad, Entidades.TipoComprobante)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql = New SqlServer.TiposComprobantes(da)

         Dim reglaTipoProducto = New TiposComprobantesProductos(da)

         Select Case tipo
            Case TipoSP._I
               sql.TiposComprobantes_I(tipoDoc.IdTipoComprobante, tipoDoc.Descripcion, tipoDoc.EsFiscal, tipoDoc.Tipo, tipoDoc.CoeficienteStock,
                                       tipoDoc.GrabaLibro, tipoDoc.InformaLibroIVA, tipoDoc.EsFacturable, tipoDoc.LetrasHabilitadas, tipoDoc.CantidadMaximaItems,
                                       tipoDoc.Imprime, tipoDoc.CoeficienteValores, tipoDoc.ModificaAlFacturar, tipoDoc.EsFacturador, tipoDoc.AfectaCaja,
                                       tipoDoc.CargaPrecioActual, tipoDoc.ActualizaCtaCte, tipoDoc.DescripcionAbrev, tipoDoc.PuedeSerBorrado,
                                       tipoDoc.CantidadCopias, tipoDoc.ComprobantesAsociados, tipoDoc.EsRemitoTransportista, tipoDoc.EsComercial,
                                       tipoDoc.CantidadMaximaItemsObserv, tipoDoc.IdTipoComprobanteSecundario, tipoDoc.ImporteTope, tipoDoc.IdTipoComprobanteEpson,
                                       tipoDoc.UsaFacturacionRapida, tipoDoc.ImporteMinimo, tipoDoc.EsElectronico, tipoDoc.UsaFacturacion, tipoDoc.UtilizaImpuestos,
                                       tipoDoc.NumeracionAutomatica, tipoDoc.GeneraObservConInvocados, tipoDoc.ImportaObservDeInvocados, tipoDoc.ImportaObservGrales, tipoDoc.IdPlanCuenta,
                                       tipoDoc.EsAnticipo, tipoDoc.EsRecibo, tipoDoc.Grupo, tipoDoc.EsPreElectronico, tipoDoc.GeneraContabilidad,
                                       tipoDoc.UtilizaCtaSecundariaProd, tipoDoc.UtilizaCtaSecundariaCateg, tipoDoc.IncluirEnExpensas,
                                       tipoDoc.IdTipoComprobanteNCred, tipoDoc.IdTipoComprobanteNDeb, tipoDoc.IdProductoNCred, tipoDoc.IdProductoNDeb,
                                       tipoDoc.ConsumePedidos, tipoDoc.EsPreFiscal, tipoDoc.CodigoComprobanteSifere, tipoDoc.EsDespachoImportacion,
                                       tipoDoc.CargaDescRecActual, tipoDoc.IdTipoComprobanteContraMovInvocar,
                                       tipoDoc.AlInvocarPedidoAfectaFactura, tipoDoc.AlInvocarPedidoAfectaRemito, tipoDoc.InvocarPedidosConEstadoEspecifico,
                                       tipoDoc.InvocaCompras, tipoDoc.LargoMaximoNumero, tipoDoc.NivelAutorizacion, tipoDoc.RequiereReferenciaCtaCte,
                                       tipoDoc.ControlaTopeConsumidorFinal, tipoDoc.CargaDescRecGralActual, tipoDoc.EsReciboClienteVinculado,
                                       tipoDoc.AFIPWSIncluyeFechaVencimiento, tipoDoc.AFIPWSEsFEC, tipoDoc.AFIPWSRequiereReferenciaComercial, tipoDoc.AFIPWSRequiereComprobanteAsociado,
                                       tipoDoc.AFIPWSRequiereCBU, tipoDoc.AFIPWSCodigoAnulacion, tipoDoc.AFIPWSRequiereReferenciaTransferencia, tipoDoc.Orden, tipoDoc.MarcaInvocado, tipoDoc.PermiteSeleccionarAlicuotaIVA,
                                       tipoDoc.DescripcionImpresion, tipoDoc.ActivaTildeMercDespacha, tipoDoc.SolicitaFechaDevolucion, tipoDoc.Color, tipoDoc.CodigoRoela,
                                       tipoDoc.ClaseComprobante, tipoDoc.SolicitaInformeCalidad)


               For Each Row As Entidades.TipoComprobanteProducto In tipoDoc.Productos
                  Row.IdTipoComprobante = tipoDoc.IdTipoComprobante
                  reglaTipoProducto.Inserta(Row)
               Next


               'Grabo en bitácora la creación del registro
               Dim rBitacora As Bitacora = New Bitacora(da)
               rBitacora.InsertarNuevoRegistro("TiposComprobantesABM", String.Format("{0}: {1}", Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString(), tipoDoc.IdTipoComprobante))

            Case TipoSP._U

               Dim dtTipoDocAnterior As DataTable = sql.TiposComprobantes_G1(tipoDoc.IdTipoComprobante)

               sql.TiposComprobantes_U(tipoDoc.IdTipoComprobante, tipoDoc.Descripcion, tipoDoc.EsFiscal, tipoDoc.Tipo, tipoDoc.CoeficienteStock,
                                       tipoDoc.GrabaLibro, tipoDoc.InformaLibroIVA, tipoDoc.EsFacturable, tipoDoc.LetrasHabilitadas, tipoDoc.CantidadMaximaItems,
                                       tipoDoc.Imprime, tipoDoc.CoeficienteValores, tipoDoc.ModificaAlFacturar, tipoDoc.EsFacturador, tipoDoc.AfectaCaja,
                                       tipoDoc.CargaPrecioActual, tipoDoc.ActualizaCtaCte, tipoDoc.DescripcionAbrev, tipoDoc.PuedeSerBorrado,
                                       tipoDoc.CantidadCopias, tipoDoc.ComprobantesAsociados, tipoDoc.EsRemitoTransportista, tipoDoc.EsComercial,
                                       tipoDoc.CantidadMaximaItemsObserv, tipoDoc.IdTipoComprobanteSecundario, tipoDoc.ImporteTope, tipoDoc.IdTipoComprobanteEpson,
                                       tipoDoc.UsaFacturacionRapida, tipoDoc.ImporteMinimo, tipoDoc.EsElectronico, tipoDoc.UsaFacturacion, tipoDoc.UtilizaImpuestos,
                                       tipoDoc.NumeracionAutomatica, tipoDoc.GeneraObservConInvocados, tipoDoc.ImportaObservDeInvocados, tipoDoc.ImportaObservGrales, tipoDoc.IdPlanCuenta,
                                       tipoDoc.EsAnticipo, tipoDoc.EsRecibo, tipoDoc.Grupo, tipoDoc.EsPreElectronico, tipoDoc.GeneraContabilidad,
                                       tipoDoc.UtilizaCtaSecundariaProd, tipoDoc.UtilizaCtaSecundariaCateg, tipoDoc.IncluirEnExpensas,
                                       tipoDoc.IdTipoComprobanteNCred, tipoDoc.IdTipoComprobanteNDeb, tipoDoc.IdProductoNCred, tipoDoc.IdProductoNDeb,
                                       tipoDoc.ConsumePedidos, tipoDoc.EsPreFiscal, tipoDoc.CodigoComprobanteSifere, tipoDoc.EsDespachoImportacion,
                                       tipoDoc.CargaDescRecActual, tipoDoc.IdTipoComprobanteContraMovInvocar,
                                       tipoDoc.AlInvocarPedidoAfectaFactura, tipoDoc.AlInvocarPedidoAfectaRemito, tipoDoc.InvocarPedidosConEstadoEspecifico,
                                       tipoDoc.InvocaCompras, tipoDoc.LargoMaximoNumero, tipoDoc.NivelAutorizacion, tipoDoc.RequiereReferenciaCtaCte,
                                       tipoDoc.ControlaTopeConsumidorFinal, tipoDoc.CargaDescRecGralActual, tipoDoc.EsReciboClienteVinculado,
                                       tipoDoc.AFIPWSIncluyeFechaVencimiento, tipoDoc.AFIPWSEsFEC, tipoDoc.AFIPWSRequiereReferenciaComercial, tipoDoc.AFIPWSRequiereComprobanteAsociado,
                                       tipoDoc.AFIPWSRequiereCBU, tipoDoc.AFIPWSCodigoAnulacion, tipoDoc.AFIPWSRequiereReferenciaTransferencia, tipoDoc.Orden, tipoDoc.MarcaInvocado, tipoDoc.PermiteSeleccionarAlicuotaIVA,
                                       tipoDoc.DescripcionImpresion, tipoDoc.ActivaTildeMercDespacha, tipoDoc.SolicitaFechaDevolucion, tipoDoc.Color, tipoDoc.CodigoRoela,
                                       tipoDoc.ClaseComprobante, tipoDoc.SolicitaInformeCalidad)

               Dim dtTipoDocNuevo As DataTable = sql.TiposComprobantes_G1(tipoDoc.IdTipoComprobante)

               If dtTipoDocAnterior.Rows.Count > 0 AndAlso dtTipoDocNuevo.Rows.Count > 0 Then
                  'Grabo en bitácora la actualizacion del registro
                  Dim rBitacora As Bitacora = New Bitacora(da)
                  rBitacora.InsertarActualizacion("TiposComprobantesABM",
                                                  String.Format("{0}: {1}", Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString(), tipoDoc.IdTipoComprobante),
                                                  dtTipoDocAnterior.Rows(0),
                                                  dtTipoDocNuevo.Rows(0))
               End If
               reglaTipoProducto.Borra(New Entidades.TipoComprobanteProducto With {.IdTipoComprobante = tipoDoc.IdTipoComprobante})

               For Each Row As Entidades.TipoComprobanteProducto In tipoDoc.Productos
                  Row.IdTipoComprobante = tipoDoc.IdTipoComprobante
                  reglaTipoProducto.Inserta(Row)
               Next

            Case TipoSP._D
               reglaTipoProducto.Borra(New Entidades.TipoComprobanteProducto With {.IdTipoComprobante = tipoDoc.IdTipoComprobante})

               sql.TiposComprobantes_D(tipoDoc.IdTipoComprobante)

               'Grabo en bitácora el borrado del registro
               Dim rBitacora As Bitacora = New Bitacora(da)
               rBitacora.InsertarBorrado("TiposComprobantesABM", String.Format("{0}: {1}", Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString(), tipoDoc.IdTipoComprobante))
         End Select

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT TC.*")
         .AppendLine(" FROM TiposComprobantes TC")
      End With

   End Sub

   Private Sub CargarUno(dr As DataRow, o As Entidades.TipoComprobante)

      With o
         .IdTipoComprobante = dr("IdTipoComprobante").ToString()
         .EsFiscal = Boolean.Parse(dr("EsFiscal").ToString())
         .Descripcion = dr("Descripcion").ToString()
         .Tipo = dr("Tipo").ToString()
         .CoeficienteStock = Integer.Parse(dr("CoeficienteStock").ToString())
         .GrabaLibro = Boolean.Parse(dr("GrabaLibro").ToString())
         .InformaLibroIVA = Boolean.Parse(dr("InformaLibroIVA").ToString())
         .EsFacturable = Boolean.Parse(dr("EsFacturable").ToString())
         If Not String.IsNullOrEmpty(dr("LetrasHabilitadas").ToString()) Then
            .LetrasHabilitadas = dr("LetrasHabilitadas").ToString()
         End If
         .CantidadMaximaItems = Integer.Parse(dr("CantidadMaximaItems").ToString())
         .Imprime = Boolean.Parse(dr("Imprime").ToString())
         .CoeficienteValores = Integer.Parse(dr("CoeficienteValores").ToString())
         If Not String.IsNullOrEmpty(dr("ModificaAlFacturar").ToString()) Then
            .ModificaAlFacturar = dr("ModificaAlFacturar").ToString()
         End If
         .EsFacturador = Boolean.Parse(dr("EsFacturador").ToString())
         .AfectaCaja = Boolean.Parse(dr("AfectaCaja").ToString())
         .CargaPrecioActual = Boolean.Parse(dr("CargaPrecioActual").ToString())
         .CargaDescRecActual = Boolean.Parse(dr("CargaDescRecActual").ToString())
         .ActualizaCtaCte = Boolean.Parse(dr("ActualizaCtaCte").ToString())
         .DescripcionAbrev = dr("DescripcionAbrev").ToString()
         .PuedeSerBorrado = Boolean.Parse(dr("PuedeSerBorrado").ToString())
         .CantidadCopias = Integer.Parse(dr("CantidadCopias").ToString())
         If Not String.IsNullOrEmpty(dr("ComprobantesAsociados").ToString()) Then
            .ComprobantesAsociados = dr("ComprobantesAsociados").ToString()
         End If
         .EsComercial = Boolean.Parse(dr("EsComercial").ToString())
         .EsRemitoTransportista = Boolean.Parse(dr("EsRemitoTransportista").ToString())
         .CantidadMaximaItemsObserv = Integer.Parse(dr("CantidadMaximaItemsObserv").ToString())

         If Not String.IsNullOrEmpty(dr("IdTipoComprobanteSecundario").ToString()) Then
            .IdTipoComprobanteSecundario = dr("IdTipoComprobanteSecundario").ToString()
         End If

         .ImporteTope = Decimal.Parse(dr("ImporteTope").ToString())
         .IdTipoComprobanteEpson = dr("IdTipoComprobanteEpson").ToString()
         .UsaFacturacionRapida = Boolean.Parse(dr("UsaFacturacionRapida").ToString())
         .ImporteMinimo = Decimal.Parse(dr("ImporteMinimo").ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.TipoComprobante.Columnas.EsElectronico.ToString()).ToString()) Then
            .EsElectronico = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.EsElectronico.ToString()).ToString())
         End If
         .UtilizaImpuestos = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.UtilizaImpuestos.ToString()).ToString())
         .NumeracionAutomatica = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.NumeracionAutomatica.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.TipoComprobante.Columnas.GeneraObservConInvocados.ToString()).ToString()) Then
            .GeneraObservConInvocados = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.GeneraObservConInvocados.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.TipoComprobante.Columnas.IdPlanCuenta.ToString()).ToString()) Then
            .IdPlanCuenta = Int32.Parse(dr(Entidades.TipoComprobante.Columnas.IdPlanCuenta.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.TipoComprobante.Columnas.ImportaObservDeInvocados.ToString()).ToString()) Then
            .ImportaObservDeInvocados = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.ImportaObservDeInvocados.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.TipoComprobante.Columnas.ImportaObservGrales.ToString()).ToString()) Then
            .ImportaObservGrales = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.ImportaObservGrales.ToString()).ToString())
         End If
         .EsRecibo = Boolean.Parse(dr("EsRecibo").ToString())
         .EsAnticipo = Boolean.Parse(dr("EsAnticipo").ToString())
         .EsPreElectronico = Boolean.Parse(dr("EsPreElectronico").ToString())
         .GeneraContabilidad = Boolean.Parse(dr("GeneraContabilidad").ToString())
         .UsaFacturacion = Boolean.Parse(dr("UsaFacturacion").ToString())
         .Grupo = dr("Grupo").ToString()
         .UtilizaCtaSecundariaProd = Boolean.Parse(dr("UtilizaCtaSecundariaProd").ToString())
         .UtilizaCtaSecundariaCateg = Boolean.Parse(dr("UtilizaCtaSecundariaCateg").ToString())

         .IncluirEnExpensas = Boolean.Parse(dr("IncluirEnExpensas").ToString())

         .IdTipoComprobanteNCred = dr("IdTipoComprobanteNCred").ToString()
         .IdTipoComprobanteNDeb = dr("IdTipoComprobanteNDeb").ToString()
         .IdProductoNCred = dr("IdProductoNCred").ToString()
         .IdProductoNDeb = dr("IdProductoNDeb").ToString()
         .ConsumePedidos = Boolean.Parse(dr("ConsumePedidos").ToString())
         .EsPreFiscal = Boolean.Parse(dr("EsPreFiscal").ToString())
         .CodigoComprobanteSifere = dr("CodigoComprobanteSifere").ToString()
         .EsDespachoImportacion = Boolean.Parse(dr("EsDespachoImportacion").ToString())
         .IdTipoComprobanteContraMovInvocar = dr("IdTipoComprobanteContraMovInvocar").ToString()

         .AlInvocarPedidoAfectaFactura = Boolean.Parse(dr("AlInvocarPedidoAfectaFactura").ToString())
         .AlInvocarPedidoAfectaRemito = Boolean.Parse(dr("AlInvocarPedidoAfectaRemito").ToString())
         .InvocarPedidosConEstadoEspecifico = Boolean.Parse(dr("InvocarPedidosConEstadoEspecifico").ToString())
         .InvocaCompras = Boolean.Parse(dr("InvocaCompras").ToString())
         .LargoMaximoNumero = Short.Parse(dr("LargoMaximoNumero").ToString())
         .NivelAutorizacion = Short.Parse(dr("NivelAutorizacion").ToString())
         .RequiereReferenciaCtaCte = Boolean.Parse(dr("RequiereReferenciaCtaCte").ToString())
         .ControlaTopeConsumidorFinal = Boolean.Parse(dr("ControlaTopeConsumidorFinal").ToString())
         .CargaDescRecGralActual = Boolean.Parse(dr("CargaDescRecGralActual").ToString())

         .EsReciboClienteVinculado = Boolean.Parse(dr("EsReciboClienteVinculado").ToString())

         If Not String.IsNullOrWhiteSpace(dr("AFIPWSIncluyeFechaVencimiento").ToString()) Then
            .AFIPWSIncluyeFechaVencimiento = Boolean.Parse(dr("AFIPWSIncluyeFechaVencimiento").ToString())
         Else
            .AFIPWSIncluyeFechaVencimiento = Nothing
         End If
         .AFIPWSEsFEC = Boolean.Parse(dr("AFIPWSEsFEC").ToString())
         .AFIPWSRequiereReferenciaComercial = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.AFIPWSRequiereReferenciaComercial.ToString()).ToString())
         .AFIPWSRequiereComprobanteAsociado = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.AFIPWSRequiereComprobanteAsociado.ToString()).ToString())
         .AFIPWSRequiereCBU = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.AFIPWSRequiereCBU.ToString()).ToString())
         .AFIPWSCodigoAnulacion = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.AFIPWSCodigoAnulacion.ToString()).ToString())
         .AFIPWSRequiereReferenciaTransferencia = dr.Field(Of Boolean)(Entidades.TipoComprobante.Columnas.AFIPWSRequiereReferenciaTransferencia.ToString())
         .Orden = Integer.Parse(dr("Orden").ToString())
         .Productos = New Reglas.TiposComprobantesProductos(da).GetTodos(.IdTipoComprobante)
         .MarcaInvocado = Boolean.Parse(dr("MarcaInvocado").ToString())
         .PermiteSeleccionarAlicuotaIVA = Boolean.Parse(dr(Entidades.TipoComprobante.Columnas.PermiteSeleccionarAlicuotaIVA.ToString()).ToString())
         .DescripcionImpresion = dr(Entidades.TipoComprobante.Columnas.DescripcionImpresion.ToString()).ToString()
         .SolicitaFechaDevolucion = dr.Field(Of Boolean)(Entidades.TipoComprobante.Columnas.SolicitaFechaDevolucion.ToString())

         '-- REQ-30773.- ----------------------------------------------------------------------
         .ActivaTildeMercDespacha = Boolean.Parse(dr("ActivaTildeMercDespacha").ToString())
         .Color = dr.Field(Of Integer?)(Entidades.TipoComprobante.Columnas.Color.ToString())
         '-- REQ-35059.- ----------------------------------------------------------------------
         .CodigoRoela = dr("CodigoRoela").ToString()
         '-------------------------------------------------------------------------------------
         .ClaseComprobante = dr.Field(Of String)("ClaseComprobante").StringToEnum(Entidades.TipoComprobante.ClasesComprobante.SinDefinir)
         '-- REQ-30773.- ----------------------------------------------------------------------
         .SolicitaInformeCalidad = Boolean.Parse(dr("SolicitaInformeCalidad").ToString())
         '-------------------------------------------------------------------------------------
      End With

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetHabilitados(idSucursal As Integer,
                                  nombrePC As String,
                                  Tipo1 As String,
                                  Tipo2 As String,
                                  AfectaCaja As String,
                                  UsaFacturacionRapida As String,
                                  UsaFacturacion As Boolean,
                                  IgnoraSucursal As Boolean,
                                  esRecibo As Boolean?,
                                  coeficionesStock As Integer?,
                                  grabaLibro As Boolean?,
                                  esReciboClienteVinculado As Boolean?,
                                  coeficienteValor As Integer?, importeComprobante As Decimal?,
                                  esElectronico As Boolean?,
                                  clase As String) As List(Of Entidades.TipoComprobante)

      'Tipo2 As String = "", _
      'AfectaCaja As String = "", _
      'UsaFacturacionRapida As String = "", _
      'UsaFacturacion As Boolean = False, _
      'IgnoraSucursal As Boolean = False,
      'esRecibo As Boolean? = Nothing,
      'coeficionesStock As Integer? = Nothing) As List(Of Entidades.TipoComprobante)

      Dim tc As Entidades.TipoComprobante
      Dim tcs As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)
      Dim stb As StringBuilder = New StringBuilder("")
      Dim com() As String = {}
      Dim coms As List(Of String()) = New List(Of String())

      'Si viene vacio es que NO debe controlar la PC
      With stb
         .Length = 0
         .AppendLine("SELECT DISTINCT I.ComprobantesHabilitados ")
         .AppendLine(" FROM Impresoras I ")
         .AppendLine(" INNER JOIN ImpresorasPCs IP ON I.IdSucursal = IP.IdSucursal ")
         .AppendLine("							        AND I.IdImpresora = IP.IdImpresora")
         If IgnoraSucursal Then
            .AppendLine(" WHERE I.IdSucursal > 0 ")
         Else
            .AppendLine(" WHERE I.IdSucursal = " & idSucursal.ToString())
         End If
         If Not String.IsNullOrEmpty(nombrePC) Then
            .AppendLine("   AND IP.NombrePC = '" & nombrePC & "'")
         End If
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      'si no existe ningun registro, significa que no se cargo el nombre de la PC y tiene que salir
      If dt.Rows.Count = 0 Then
         Return tcs
      End If
      For Each dr As DataRow In dt.Rows
         com = dr(0).ToString().Split(","c)
         coms.Add(com)
      Next

      Me.SelectTexto(stb)

      With stb

         If Tipo1 = "TODOS" Then
            .AppendLine(" WHERE TC.Tipo <> '' ")
         ElseIf Tipo2 <> "" Then
            .AppendLine(" WHERE (TC.Tipo = '" & Tipo1 & "'")
            .Append("    OR TC.Tipo = '" & Tipo2 & "') ")
         Else
            .AppendLine(" WHERE TC.Tipo = '" & Tipo1 & "'")
         End If

         For i1 As Integer = 0 To coms.Count - 1
            com = coms(i1)
            For i As Integer = 0 To com.Length - 1
               If i1 = 0 And i = 0 Then   'Si es la primera vez que entra
                  .Append(" AND (TC.IdTipoComprobante = '")
               Else
                  .Append("  OR TC.IdTipoComprobante = '")
               End If
               .Append(com(i))
               .Append("' ")
            Next

            If i1 = coms.Count - 1 Then
               .AppendLine(") ")
            End If

         Next

         If AfectaCaja = "SI" Then
            .AppendLine("  AND TC.AfectaCaja = 'True'")
         ElseIf AfectaCaja = "NO" Then
            .AppendLine("  AND TC.AfectaCaja = 'False'")
         End If

         If UsaFacturacionRapida = "SI" Then
            .AppendLine("   AND TC.UsaFacturacionRapida = 'True'")
         End If

         'Asi solo filtra en Facturacion, en el resto de las pantallas debe mostrar todo.
         If UsaFacturacion Then
            .AppendLine("   AND TC.UsaFacturacion = 1")
         End If

         If esRecibo.HasValue Then
            .AppendFormatLine("   AND TC.EsRecibo = '{0}'", esRecibo.ToString())
         End If

         If coeficionesStock.HasValue Then
            .AppendFormatLine("   AND TC.CoeficienteStock = {0}", coeficionesStock.Value)
         End If

         If coeficienteValor.HasValue Then
            .AppendFormatLine("   AND TC.CoeficienteValores = {0}", coeficienteValor.Value)
         End If
         '-- REQ-36082.- ------------------------------------------------------------------
         If importeComprobante.HasValue Then
            .AppendFormatLine("   AND TC.ImporteMinimo <= {0}", importeComprobante.Value)
            .AppendFormatLine("   AND TC.ImporteTope >= {0}", importeComprobante.Value)
         End If
         'If importeTope.HasValue Then
         '   .AppendFormatLine("   AND TC.ImporteTope = {0}", importeTope.Value)
         'End If
         'If importeMinimo.HasValue Then
         '   .AppendFormatLine("   AND TC.ImporteMinimo = {0}", importeMinimo.Value)
         'End If
         '---------------------------------------------------------------------------------
         If grabaLibro.HasValue Then
            .AppendFormatLine("   AND TC.GrabaLibro = {0}", If(grabaLibro.Value, 1, 0))
         End If

         If esReciboClienteVinculado.HasValue Then
            .AppendFormatLine("   AND TC.EsReciboClienteVinculado = {0}", If(esReciboClienteVinculado.Value, 1, 0))
         End If

         If esElectronico.HasValue Then
            .AppendFormatLine("   AND TC.EsElectronico = {0}", If(esElectronico.Value, 1, 0))
         End If
         If Not String.IsNullOrEmpty(clase.ToString()) Then
            .AppendLine(" AND TC.ClaseComprobante = '" & clase & "'")
         End If

         .AppendLine(" ORDER BY TC.Orden, TC.Descripcion  ")

      End With

      dt = Me.da.GetDataTable(stb.ToString())

      For Each dr As DataRow In dt.Rows
         tc = New Entidades.TipoComprobante()
         Me.CargarUno(dr, tc)
         tcs.Add(tc)
      Next

      Return tcs

   End Function

   Public Function GetHabilitadosPorPc(idSucursal As Integer,
                                     nombrePC As String,
                                     Tipo1 As String,
                                    Optional Tipo2 As String = "",
                                    Optional AfectaCaja As String = "",
                                    Optional UsaFacturacionRapida As String = "",
                                    Optional UsaFacturacion As Boolean = False) As DataTable

      ' Dim tc As Entidades.TipoComprobante
      Dim tcs As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)
      Dim stb As StringBuilder = New StringBuilder("")
      Dim com() As String = {}
      Dim coms As List(Of String()) = New List(Of String())

      'Si viene vacio es que NO debe controlar la PC
      With stb
         .Length = 0
         .AppendLine("Select DISTINCT I.ComprobantesHabilitados ")
         .AppendLine(" FROM Impresoras I ")
         .AppendLine(" INNER JOIN ImpresorasPCs IP On I.IdSucursal = IP.IdSucursal ")
         .AppendLine("							        And I.IdImpresora = IP.IdImpresora")
         .AppendLine(" WHERE I.IdSucursal = " & idSucursal.ToString())
         If Not String.IsNullOrEmpty(nombrePC) Then
            .AppendLine("   And IP.NombrePC = '" & nombrePC & "'")
         End If
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      'si no existe ningun registro, significa que no se cargo el nombre de la PC y tiene que salir
      Return dt


   End Function

   Public Function GetElectronicos(UsaFacturacion As String) As List(Of Entidades.TipoComprobante)
      Try
         Me.da.OpenConection()
         Dim tc As Entidades.TipoComprobante
         Dim tcs As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)

         Dim dt As DataTable = New SqlServer.TiposComprobantes(da).GetElectronicos(UsaFacturacion)

         For Each dr As DataRow In dt.Rows
            tc = New Entidades.TipoComprobante()
            Me.CargarUno(dr, tc)
            tcs.Add(tc)
         Next

         Return tcs
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetPorCodigoRoela(codigoRoela As String) As Entidades.TipoComprobante
      Return EjecutaConConexion(Function() _GetPorCodigoRoela(codigoRoela))
   End Function
   Public Function _GetPorCodigoRoela(codigoRoela As String) As Entidades.TipoComprobante
      Using dt = New SqlServer.TiposComprobantes(da).GetPorCodigoRoela(codigoRoela)
         Dim tc As Entidades.TipoComprobante = Nothing
         For Each dr As DataRow In dt.Rows
            tc = New Entidades.TipoComprobante()
            CargarUno(dr, tc)
         Next
         Return tc
      End Using
   End Function

   Public Function GetSegunLibro(grabaLibro As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT IdTipoComprobante")
         .AppendFormatLine("  FROM TiposComprobantes")
         .AppendFormatLine(" WHERE GrabaLibro = {0}", If(grabaLibro = "SI", 1, 0))
      End With
      Return da.GetDataTable(stb.ToString())
   End Function

   Public Function GetFacturables(comprobantesAsociados As String, miraPC As Boolean) As DataTable
      'Dim tcs As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)

      Dim tcs = GetHabilitados(actual.Sucursal.Id, If(miraPC, My.Computer.Name, String.Empty),
                               Entidades.ContabilidadProceso.Procesos.VENTAS.ToString(),
                               Tipo2:=String.Empty, AfectaCaja:=String.Empty, UsaFacturacionRapida:=String.Empty, UsaFacturacion:=False,
                               IgnoraSucursal:=False, esRecibo:=Nothing, coeficionesStock:=Nothing, grabaLibro:=Nothing,
                               esReciboClienteVinculado:=Nothing, coeficienteValor:=Nothing, importeComprobante:=Nothing,
                               esElectronico:=Nothing, clase:=String.Empty)

      Return New SqlServer.TiposComprobantes(da).GetFacturables(comprobantesAsociados, miraPC, tcs)
   End Function

   Public Function GetFacturablesCom(Optional ComprobantesAsociados As String = "") As DataTable

      Dim tcs As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)

      tcs = Me.GetHabilitados(Eniac.Entidades.Usuario.Actual.Sucursal.Id, My.Computer.Name, "COMPRAS",
                              Tipo2:="", AfectaCaja:="", UsaFacturacionRapida:="", UsaFacturacion:=False,
                              IgnoraSucursal:=False, esRecibo:=Nothing, coeficionesStock:=Nothing, grabaLibro:=Nothing,
                              esReciboClienteVinculado:=Nothing, coeficienteValor:=Nothing, importeComprobante:=Nothing,
                              esElectronico:=Nothing, clase:=String.Empty)

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT IdTipoComprobante, Descripcion ")
         .AppendLine("  FROM TiposComprobantes ")
         .AppendLine(" WHERE EsFacturable = 1 ")
         If ComprobantesAsociados <> "" Then
            .AppendLine("  AND IdTipoComprobante IN (" & ComprobantesAsociados & ")")
         End If
         'Los habilitados en esta PC.
         .Append("  AND IdTipoComprobante IN (''")
         For Each tc As Eniac.Entidades.TipoComprobante In tcs
            .Append(" , '" & tc.IdTipoComprobante & "'")
         Next
         .AppendLine(")")
         .Append(" ORDER BY Descripcion ")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetFacturablesPedidos(Optional ComprobantesAsociados As String = "") As DataTable

      'Dim tcs As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)

      'tcs = Me.GetHabilitados(Eniac.Entidades.Usuario.Actual.Sucursal.Id, My.Computer.Name, "VENTAS")

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT IdTipoComprobante, Descripcion ")
         .AppendLine("  FROM TiposComprobantes ")
         .AppendLine(" WHERE EsFacturable = 1 ")
         If ComprobantesAsociados <> "" Then
            .AppendLine("  AND IdTipoComprobante IN (" & ComprobantesAsociados & ")")
         End If
         'Los habilitados en esta PC.
         '.Append("  AND IdTipoComprobante IN (''")
         'For Each tc As Eniac.Entidades.TipoComprobante In tcs
         '   .Append(" , '" & tc.IdTipoComprobante & "'")
         'Next
         '.AppendLine(")")
         .AppendLine(" AND  Tipo = 'PEDIDOSCLIE'")

         .Append(" ORDER BY Descripcion ")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetComprobantesCompras(Optional ComprobantesAsociados As String = "") As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT IdTipoComprobante, Descripcion ")
         .AppendLine("  FROM TiposComprobantes ")
         .AppendLine("  WHERE EsFacturable = 0 AND CoeficienteStock = 1  AND  Tipo = 'COMPRAS'")

         .Append(" ORDER BY Descripcion ")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetFacturablesPedidosProveedores(comprobantesAsociados As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT IdTipoComprobante, Descripcion ")
         .AppendFormatLine("  FROM TiposComprobantes ")
         .AppendFormatLine(" WHERE EsFacturable = 1 ")
         If comprobantesAsociados <> "" Then
            .AppendFormatLine("  AND IdTipoComprobante IN ({0})", comprobantesAsociados)
         End If
         .AppendFormatLine("   AND Tipo IN (SELECT DISTINCT TipoEstadoPedido FROM EstadosPedidosProveedores WHERE IdEstadoFacturado IS NOT NULL)")
         '.AppendFormatLine(" AND  Tipo IN ('{0}', '{1}')",
         '                  Entidades.TipoComprobante.Tipos.PEDIDOSPROV.ToString(),
         '                  Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString())

         .AppendFormatLine(" ORDER BY Descripcion ")
      End With
      Return da.GetDataTable(stb.ToString())
   End Function

   Public Function GetCodigoRoelaComprobantes(codigoRoela As String, TipoComprobante As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT * ")
         .AppendLine("  FROM TiposComprobantes ")
         .AppendFormat("  WHERE CodigoRoela = '{0}'", codigoRoela.ToUpper)
         .AppendFormat("  AND IdTipoComprobante <> '{0}'", TipoComprobante)
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetFacturablesReales(IdSucursal As Integer,
                                           NombrePC As String,
                                           Tipo1 As String,
                                          Optional Tipo2 As String = "") As List(Of Entidades.TipoComprobante)

      Dim tc As Entidades.TipoComprobante
      Dim tcs As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)
      Dim stb As StringBuilder = New StringBuilder("")
      Dim com() As String = {}
      Dim coms As List(Of String()) = New List(Of String())

      'Si viene vacio es que NO debe controlar la PC
      With stb
         .Length = 0
         .AppendLine("SELECT DISTINCT I.ComprobantesHabilitados ")
         .AppendLine(" FROM Impresoras I ")
         .AppendLine(" INNER JOIN ImpresorasPCs IP ON I.IdSucursal = IP.IdSucursal ")
         .AppendLine("							        AND I.IdImpresora = IP.IdImpresora")
         .AppendLine(" WHERE I.IdSucursal = " & IdSucursal.ToString())
         If Not String.IsNullOrEmpty(NombrePC) Then
            .AppendLine("   AND IP.NombrePC = '" & NombrePC & "'")
         End If
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      'si no existe ningun registro, significa que no se cargo el nombre de la PC y tiene que salir
      If dt.Rows.Count = 0 Then
         Return tcs
      End If
      For Each dr As DataRow In dt.Rows
         com = dr(0).ToString().Split(","c)
         coms.Add(com)
      Next

      Me.SelectTexto(stb)

      With stb

         .AppendLine(" WHERE TC.EsFacturable = 'True' AND TC.AfectaCaja = 'False'")

         If Tipo2 <> "" Then
            .AppendLine(" AND (TC.Tipo = '" & Tipo1 & "'")
            .Append("    OR TC.Tipo = '" & Tipo2 & "') ")
         Else
            .AppendLine(" AND TC.Tipo = '" & Tipo1 & "'")
         End If

         For i1 As Integer = 0 To coms.Count - 1
            com = coms(i1)
            For i As Integer = 0 To com.Length - 1
               If i1 = 0 And i = 0 Then   'Si es la primera vez que entra
                  .Append(" AND (TC.IdTipoComprobante = '")
               Else
                  .Append("  OR TC.IdTipoComprobante = '")
               End If
               .Append(com(i))
               .Append("' ")
            Next

            If i1 = coms.Count - 1 Then
               .AppendLine(") ")
            End If

         Next

         .AppendLine(" ORDER BY TC.Descripcion  ")

      End With

      dt = Me.da.GetDataTable(stb.ToString())

      For Each dr As DataRow In dt.Rows
         tc = New Entidades.TipoComprobante()
         Me.CargarUno(dr, tc)
         tcs.Add(tc)
      Next

      Return tcs

   End Function

   Public Function GetUsadosCtaCteClientes() As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      Dim oCtaCteCliente As New Reglas.CuentasCorrientes(da)

      With stb
         .Append("SELECT IdTipoComprobante, Descripcion ")
         .Append(" FROM TiposComprobantes ")

         'El XX es para que tener 1 y que no afecte
         .Append(" WHERE IdTipoComprobante IN ( 'xx'")

         Dim dt As DataTable = oCtaCteCliente.GetComprobantesCtaCte()

         If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
               .Append(", '" & dr("IdTipoComprobante").ToString() & "'")
            Next
         End If

         .Append(" ) ")

         .Append(" ORDER BY Descripcion ")
      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function GetParaReemplazar(idSucursal As Integer,
                                     nombrePC As String,
                                     tipo1 As String,
                                     tipo2 As String,
                                     afectaCaja As String,
                                     usaFacturacion As Boolean,
                                     permiteElectronicos As Boolean,
                                     permiteFiscales As Boolean,
                                     grabaLibro As Boolean?,
                                     esComercial As Boolean?,
                                     coeficienteValor As Integer?,
                                     incluyePreElectronicas As Boolean?) As List(Of Entidades.TipoComprobante)

      Dim tc As Entidades.TipoComprobante
      Dim tcs As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)
      Dim stb As StringBuilder = New StringBuilder("")
      Dim com() As String = {}
      Dim coms As List(Of String()) = New List(Of String())

      'Si viene vacio es que NO debe controlar la PC
      With stb
         .Length = 0
         .AppendLine("SELECT DISTINCT I.ComprobantesHabilitados ")
         .AppendLine(" FROM Impresoras I ")
         .AppendLine(" INNER JOIN ImpresorasPCs IP ON I.IdSucursal = IP.IdSucursal ")
         .AppendLine("							        AND I.IdImpresora = IP.IdImpresora")
         .AppendLine(" WHERE I.IdSucursal = " & idSucursal.ToString())
         If Not String.IsNullOrEmpty(nombrePC) Then
            .AppendLine("   AND IP.NombrePC = '" & nombrePC & "'")
         End If
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      'si no existe ningun registro, significa que no se cargo el nombre de la PC y tiene que salir
      If dt.Rows.Count = 0 Then
         Return tcs
      End If
      For Each dr As DataRow In dt.Rows
         com = dr(0).ToString().Split(","c)
         coms.Add(com)
      Next

      Me.SelectTexto(stb)

      With stb

         If tipo1 = "TODOS" Then
            .AppendLine(" WHERE TC.Tipo <> '' ")
         ElseIf tipo2 <> "" Then
            .AppendLine(" WHERE (TC.Tipo = '" & tipo1 & "'")
            .Append("    OR TC.Tipo = '" & tipo2 & "') ")
         Else
            .AppendLine(" WHERE TC.Tipo = '" & tipo1 & "'")
         End If

         For i1 As Integer = 0 To coms.Count - 1
            com = coms(i1)
            For i As Integer = 0 To com.Length - 1
               If i1 = 0 And i = 0 Then   'Si es la primera vez que entra
                  .Append(" AND (TC.IdTipoComprobante = '")
               Else
                  .Append("  OR TC.IdTipoComprobante = '")
               End If
               .Append(com(i))
               .Append("' ")
            Next

            If i1 = coms.Count - 1 Then
               .AppendLine(") ")
            End If

         Next

         If afectaCaja = "SI" Then
            .AppendLine("  AND TC.AfectaCaja = 'True'")
         ElseIf afectaCaja = "NO" Then
            .AppendLine("  AND TC.AfectaCaja = 'False'")
         End If

         If usaFacturacion Then
            .AppendLine("   AND (TC.UsaFacturacion = 'True' OR TC.UsaFacturacionRapida = 'True')")
         End If

         If Not permiteElectronicos Then
            .AppendLine("   AND (TC.EsElectronico = 'False' OR TC.EsPreElectronico = 'True')")
         End If

         If Not permiteFiscales Then
            .AppendLine("   AND TC.EsFiscal = 'False'")
         End If

         If grabaLibro.HasValue Then
            If incluyePreElectronicas.HasValue Then
               .AppendFormatLine("   AND (TC.GrabaLibro = '{0}' OR TC.EsPreElectronico = '{1}')", grabaLibro.Value, incluyePreElectronicas.Value)
            Else
               .AppendFormatLine("   AND (TC.GrabaLibro = '{0}')", grabaLibro.Value)
            End If
         End If

         If esComercial.HasValue Then
            If incluyePreElectronicas.HasValue Then
               .AppendFormatLine("   AND (TC.EsComercial = '{0}' OR TC.EsPreElectronico = '{1}')", esComercial.Value, incluyePreElectronicas.Value)
            Else
               .AppendFormatLine("   AND (TC.EsComercial = '{0}')", esComercial.Value)
            End If
         End If

         If coeficienteValor.HasValue Then
            .AppendFormatLine("   AND (TC.CoeficienteValores = {0})", coeficienteValor.Value)
         End If

         .AppendLine(" ORDER BY TC.Descripcion")

      End With

      dt = Me.da.GetDataTable(stb.ToString())

      For Each dr As DataRow In dt.Rows
         tc = New Entidades.TipoComprobante()
         Me.CargarUno(dr, tc)
         tcs.Add(tc)
      Next

      Return tcs

   End Function

   Public Function GetCtaCteProveedoresPag() As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT IdTipoComprobante, Descripcion ")
         .Append(" FROM TiposComprobantes ")
         .Append(" WHERE Tipo = 'CTACTEPROV' ")
         .Append(" ORDER BY Descripcion")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetUsadosCtaCteProveedores() As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Dim oCtaCteProveedor As New Reglas.CuentasCorrientesProv

      With stb
         .Length = 0
         .Append("SELECT IdTipoComprobante, Descripcion ")
         .Append(" FROM TiposComprobantes ")

         'El XX es para que tener 1 y que no afecte
         .Append(" WHERE IdTipoComprobante IN ( 'xx'")

         Dim dt As DataTable = oCtaCteProveedor.GetComprobantesCtaCte()

         If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
               .Append(", '" & dr("IdTipoComprobante").ToString() & "'")
            Next
         End If

         .Append(" ) ")

         .Append(" ORDER BY Descripcion ")
      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function GetBorrables(Tipo As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT IdTipoComprobante, Descripcion ")
         .Append("  FROM TiposComprobantes ")
         .Append(" WHERE PuedeSerBorrado = 'True' ")
         .Append("   AND Tipo = '" & Tipo & "'")
         .Append(" ORDER BY Descripcion ")
      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function LetraHabilitada(idTipoComprobante As String, Letra As String) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT LetrasHabilitadas ")
         .Append(" FROM TiposComprobantes ")
         .Append(" WHERE IdTipoComprobante = '")
         .Append(idTipoComprobante)
         .Append("'")
      End With

      Dim dt As DataTable = da.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         'si existen registros
         If Not String.IsNullOrEmpty(dt.Rows(0)("LetrasHabilitadas").ToString()) Then
            'si el valor no es nulo hago un split de las letras
            Dim letras() As String = dt.Rows(0)("LetrasHabilitadas").ToString().Split(","c)
            For Each letr As String In letras
               If letr = Letra Then
                  'encontro la letra, retorno verdadero
                  Return True
               End If
            Next
            'retorn falso porque no encontro la letra
            Return False
         Else
            'si el valor es nulo retorno verdadero para validar que tome todas las letras
            Return True
         End If
      Else
         'si no existen registro
         Return False
      End If

   End Function

   Public Function GetTodos() As List(Of Entidades.TipoComprobante)
      Return GetTodos(tipo1:=String.Empty, tipo2:=String.Empty, grupo:=String.Empty)
   End Function
   Public Function GetTodos(tipo1 As String, tipo2 As String) As List(Of Entidades.TipoComprobante)
      Return GetTodos(tipo1, tipo2, grupo:=String.Empty)
   End Function
   Public Function GetTodos(tipo1 As String, tipo2 As String, grupo As String) As List(Of Entidades.TipoComprobante)
      Dim dt As DataTable = New SqlServer.TiposComprobantes(da).TiposComprobantes_G(String.Empty, tipo1, tipo2, grupo)
      Dim o As Entidades.TipoComprobante
      Dim oLis As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)()
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoComprobante()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetAsociadosPorMovimientos(idSucursal As Integer, nombrePC As String, idTipoMovimiento As String) As List(Of Entidades.TipoComprobante)

      'Busco los activos para esta PC.
      Dim tcs1 As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)
      Dim stb1 As StringBuilder = New StringBuilder("")
      Dim com1() As String = {}
      Dim coms1 As List(Of String()) = New List(Of String())
      With stb1
         .Length = 0
         .AppendLine("SELECT I.ComprobantesHabilitados ")
         .AppendLine(" FROM Impresoras I ")
         .AppendLine(" INNER JOIN ImpresorasPCs IP ON I.IdSucursal = IP.IdSucursal ")
         .AppendLine("							        AND I.IdImpresora = IP.IdImpresora")
         .AppendLine(" WHERE I.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IP.NombrePC = '" & nombrePC & "'")
      End With
      Dim dt1 As DataTable = da.GetDataTable(stb1.ToString())
      'si no existe ningun registro, significa que no se cargo el nombre de la PC y tiene que salir
      If dt1.Rows.Count = 0 Then
         Return tcs1
      End If
      For Each dr As DataRow In dt1.Rows
         com1 = dr(0).ToString().Split(","c)
         coms1.Add(com1)
      Next

      'Busco los relacionados para este tipo de movimiento

      Dim stb As StringBuilder = New StringBuilder("")
      Dim com() As String = {}
      Dim coms As List(Of String()) = New List(Of String())
      With stb
         .Length = 0
         .AppendLine("SELECT TM.ComprobantesAsociados ")
         .AppendLine("  FROM TiposMovimientos TM ")
         .AppendLine(" WHERE TM.IdTipoMovimiento = '" & idTipoMovimiento & "'")
      End With
      Dim dt As DataTable = da.GetDataTable(stb.ToString())
      For Each dr As DataRow In dt.Rows
         If Not String.IsNullOrEmpty(dr(0).ToString()) Then
            com = dr(0).ToString().Split(","c)
            coms.Add(com)
         End If
      Next

      Me.SelectTexto(stb)

      With stb

         If coms.Count > 0 Then

            'Aquellos asociados al movimiento
            For i1 As Integer = 0 To coms.Count - 1
               com = coms(i1)
               For i As Integer = 0 To com.Length - 1
                  If i1 = 0 And i = 0 Then   'Si es la primera vez que entra
                     .Append(" WHERE ( TC.IdTipoComprobante = '")
                  Else
                     .Append("  OR TC.IdTipoComprobante = '")
                  End If
                  .Append(com(i) & "' ")
               Next
               .Append(" )")
            Next

            'Aquellos asociados a la sucursal.
            For i1 As Integer = 0 To coms1.Count - 1
               com1 = coms1(i1)
               For i As Integer = 0 To com1.Length - 1
                  If i1 = 0 And i = 0 Then   'Si es la primera vez que entra
                     .Append(" AND ( TC.IdTipoComprobante = '")
                  Else
                     .Append("  OR TC.IdTipoComprobante = '")
                  End If
                  .Append(com1(i) & "' ")
               Next

               'Cierro solo si estoy en el ultimo
               If i1 = coms1.Count - 1 Then
                  .Append(") ")
               End If
            Next

         Else
            .AppendLine(" WHERE 1 = 2")   'Para forzar que NO devuelva Registros

         End If

         .AppendLine(" ORDER BY TC.Descripcion  ")

      End With

      dt = Me.da.GetDataTable(stb.ToString())
      Dim o As Entidades.TipoComprobante
      Dim oLis As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)

      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoComprobante()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next

      Return oLis

   End Function

   Public Function GetUno(idTipoComprobante As String) As Entidades.TipoComprobante
      Return GetUno(idTipoComprobante, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTipoComprobante As String, accion As AccionesSiNoExisteRegistro) As Entidades.TipoComprobante
      Dim stb As StringBuilder = New StringBuilder("")

      Me.SelectTexto(stb)

      With stb
         .AppendLine(" WHERE TC.IdTipoComprobante = '" & idTipoComprobante & "'")
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      Dim o As Entidades.TipoComprobante = New Entidades.TipoComprobante()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(dr, o)
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No existe el tipo de comprobante: {0}", idTipoComprobante))
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If

      Return o

   End Function

   Public Function GetComprobanteSecundario(idTipoComprobante As String) As Entidades.TipoComprobante
      Dim stb As StringBuilder = New StringBuilder("")

      Me.SelectTexto(stb)

      With stb
         .AppendLine(" WHERE TC.IdTipoComprobanteSecundario = '" & idTipoComprobante & "'")
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      Dim o As Entidades.TipoComprobante = New Entidades.TipoComprobante()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(dr, o)
      Else
         Throw New Exception("No existe el tipo de comprobante")
      End If

      Return o

   End Function

   Public Function GetPorCodigo(idTipoComprobante As String, tipo1 As String, tipo2 As String) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.TiposComprobantes = New SqlServer.TiposComprobantes(da)
         Return sql.GetPorCodigo(idTipoComprobante:=idTipoComprobante, descripcion:=String.Empty, tipo1:=tipo1, tipo2:=tipo2)
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetPorDescripcion(descripcion As String, tipo1 As String, tipo2 As String) As DataTable
      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.TiposComprobantes = New SqlServer.TiposComprobantes(da)

         Return sql.GetPorCodigo(idTipoComprobante:=String.Empty, descripcion:=descripcion, tipo1:=tipo1, tipo2:=tipo2)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   <Obsolete("Usar GetMinutas(Integer, String, String, String(), Boolean?)", True)>
   Public Function GetMinutas(idSucursal As Integer, tipo1 As String, tipo2 As String, idTipoComprobante As String, minutaReciboTodos As Boolean?) As List(Of Entidades.TipoComprobante)
      Throw New NotImplementedException("Usar GetMinutas(Integer, String, String, String(), Boolean?)")
   End Function

   Public Function GetMinutas(idSucursal As Integer,
                              tipo1 As String,
                              tipo2 As String,
                              idTipoComprobante As String(),
                              minutaReciboTodos As Boolean?) As List(Of Entidades.TipoComprobante)
      'Dim com() As String = {}
      'Dim coms As List(Of String()) = New List(Of String())

      Dim stb As StringBuilder = New StringBuilder()
      Me.SelectTexto(stb)

      With stb

         If tipo1 = "TODOS" Then
            .AppendLine(" WHERE TC.Tipo <> '' ")
         ElseIf tipo2 <> "" Then
            .AppendLine(" WHERE (TC.Tipo = '" & tipo1 & "'")
            .Append("    OR TC.Tipo = '" & tipo2 & "') ")
         Else
            .AppendLine(" WHERE TC.Tipo = '" & tipo1 & "'")
         End If
         If idTipoComprobante IsNot Nothing AndAlso idTipoComprobante.Length > 0 Then
            If Not String.IsNullOrWhiteSpace(idTipoComprobante(0)) Then
               .AppendFormat("      AND (TC.ComprobantesAsociados LIKE '%''{0}''%'", idTipoComprobante(0))
               For i As Integer = 1 To idTipoComprobante.Length - 1
                  .AppendFormat("     AND TC.ComprobantesAsociados LIKE '%''{0}''%'", idTipoComprobante(i))
               Next
               .AppendLine(")")
            End If
         End If
         If minutaReciboTodos.HasValue Then
            If minutaReciboTodos.Value Then
               .AppendLine("   AND TC.ImporteTope = 0")     'MINUTAS
            Else
               .AppendLine("   AND TC.ImporteTope <> 0")    'RECIBOS
            End If
         End If
         .AppendLine("   AND TC.EsRecibo = 1")

         '##########################################################################################################################
         '# PE 26251                                                                                                               #
         '# Se agrega este filtro para evitar de traer los comprobantes que no están habilitados.                                  #  
         '# Con esto se soluciona el problema de que no se estaban trayendo correctamente los Saldos Actuales de Cta Cte.          #  
         '# Al consultar una eFACT, el saldo mostraba solo la sumatoria de saldos de las eFACT y no del resto de los comprobantes. #
         '##########################################################################################################################

         .AppendLine("    AND EXISTS (SELECT * FROM Impresoras I ")
         .AppendLine("WHERE (I.ComprobantesHabilitados LIKE ''   + TC.IdTipoComprobante + ',%' OR")
         .AppendLine("I.ComprobantesHabilitados LIKE '%,' + TC.IdTipoComprobante + ',%' OR")
         .AppendLine("I.ComprobantesHabilitados LIKE '%,' + TC.IdTipoComprobante + ''   OR")
         .AppendLine("I.ComprobantesHabilitados    = ''   + TC.IdTipoComprobante + ''))")

         '###########################################################################################################################

         .AppendLine(" ORDER BY TC.Descripcion  ")

      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      Dim tcs As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)
      Dim tc As Entidades.TipoComprobante
      For Each dr As DataRow In dt.Rows
         tc = New Entidades.TipoComprobante()
         Me.CargarUno(dr, tc)
         tcs.Add(tc)
      Next

      Return tcs

   End Function

   Public Function GetGrupos(idGrupo As String, nombreGrupo As String) As DataTable
      Return New SqlServer.TiposComprobantes(da).GetGrupos(idGrupo, nombreGrupo)
   End Function
   Public Function GetGruposPorCodigo(idGrupo As String) As DataTable
      Return New SqlServer.TiposComprobantes(da).GetGrupos(idGrupo, String.Empty)
   End Function
   Public Function GetGruposPorNombre(nombreGrupo As String) As DataTable
      Return New SqlServer.TiposComprobantes(da).GetGrupos(String.Empty, nombreGrupo)
   End Function
   Public Function GetGruposTodos() As List(Of Entidades.Grupo)
      Return GetGruposTodos(String.Empty, String.Empty)
   End Function
   Public Function GetGruposTodos(idGrupo As String, nombreGrupo As String) As List(Of Entidades.Grupo)
      Dim dt As DataTable = New SqlServer.TiposComprobantes(da).GetGrupos(idGrupo, nombreGrupo)
      Dim o As Entidades.Grupo
      Dim oLis As List(Of Entidades.Grupo) = New List(Of Entidades.Grupo)()
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Grupo()
         Me.CargarUnoGrupo(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Private Sub CargarUnoGrupo(dr As DataRow, o As Entidades.Grupo)
      With o
         .IdGrupo = dr("IdGrupo").ToString()
         .NombreGrupo = dr("NombreGrupo").ToString()
      End With
   End Sub

   Public Function GetTipoComprobanteRecibo(tipoComprobante As Entidades.TipoComprobante, importe As Decimal) As Entidades.TipoComprobante
      Return GetTipoComprobanteRecibo(tipoComprobante.IdTipoComprobante, importe)
   End Function

   Public Function GetTipoComprobanteRecibo(tipoComprobante As String, importe As Decimal) As Entidades.TipoComprobante
      Try
         da.OpenConection()
         Return _GetTipoComprobanteRecibo(tipoComprobante, importe, AccionesSiNoExisteRegistro.Excepcion)
      Finally
         da.CloseConection()
      End Try
   End Function

   Public Function _GetTipoComprobanteRecibo(tipoComprobante As String, importe As Decimal, accion As AccionesSiNoExisteRegistro) As Entidades.TipoComprobante
      Dim dt As DataTable = New SqlServer.TiposComprobantes(da).GetTipoComprobanteRecibo(importe)

      For Each dr As DataRow In dt.Rows
         For Each comprobantesAsociados As String In dr(Entidades.TipoComprobante.Columnas.ComprobantesAsociados.ToString()).ToString().Split(","c)
            If tipoComprobante = comprobantesAsociados.Trim("'"c).Trim() Then
               Dim o As Entidades.TipoComprobante = New Entidades.TipoComprobante()
               CargarUno(dr, o)
               Return o
            End If
         Next
      Next

      If accion = AccionesSiNoExisteRegistro.Excepcion Then
         Throw New Exception(String.Format("El tipo de comprobante '{0}' no tiene un recibo asociado que permita emitir un recibo con importe {1:N2}. Por favor verifique.",
                                           tipoComprobante, importe))
      ElseIf accion = AccionesSiNoExisteRegistro.Vacio Then
         Return New Entidades.TipoComprobante()
      End If
      Return Nothing
   End Function

#End Region

End Class