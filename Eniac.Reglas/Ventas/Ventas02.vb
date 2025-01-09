Partial Class Ventas
   Private ComprobanteAnt As Entidades.Venta

   ''GET PRINCIPALES

#Region "Metodos Publicos"
   Public Function GetConsultarVentas(idSucursal As Integer,
                                      desde As Date,
                                      hasta As Date,
                                      IdVendedor As Integer,
                                      grabaLibro As String,
                                      idCliente As Long,
                                      afectaCaja As String,
                                      tipoComprobante As String,
                                      numeroComprobante As Long,
                                      idFormasPago As Integer,
                                      idUsuario As String,
                                      mercDespachada As String,
                                      comercial As String,
                                      idCategoria As Integer,
                                      idLocalidad As Integer,
                                      idProvincia As String,
                                      letraFiscal As String,
                                      centroEmisor As Integer,
                                      idZonaGeografica As String) As DataTable
      Return New SqlServer.Ventas(da).GetConsultarVentas(idSucursal, desde, hasta, IdVendedor, grabaLibro,
                                                         idCliente, afectaCaja, tipoComprobante, numeroComprobante, idFormasPago, idUsuario, mercDespachada,
                                                         comercial, idCategoria, idLocalidad, idProvincia, letraFiscal, centroEmisor,
                                                         idZonaGeografica)
   End Function
   Public Function GetInformeDeVentas(sucursales As Entidades.Sucursal(),
                                      desde As Date, hasta As Date,
                                      idZonaGeografica As String,
                                      IdVendedor As Integer,
                                      vendedor As Entidades.OrigenFK,
                                      idCliente As Long,
                                      grabaLibro As Entidades.Publicos.SiNoTodos,
                                      afectaCaja As Entidades.Publicos.SiNoTodos,
                                      idFormaDePago As Integer,
                                      idUsuario As String,
                                      idLocalidad As Integer,
                                      idProvincia As String,
                                      numeroComprobanteDesde As Long,
                                      numeroComprobanteHasta As Long,
                                      letraFiscal As String,
                                      centroEmisor As Integer,
                                      mercDespachada As Entidades.Publicos.SiNoTodos,
                                      comercial As Entidades.Publicos.SiNoTodos,
                                      idCategoria As Integer,
                                      categoria As Entidades.OrigenFK,
                                      numeroRepartoDesde As Integer?,
                                      numeroRepartoHasta As Integer?,
                                      listaComprobantes As List(Of Entidades.TipoComprobante),
                                      coeficienteStock As Integer?,
                                      esRemitoTransportista As Boolean?,
                                      incluirAnulados As Boolean,
                                      idCentroCosto As Integer,
                                      correoEnviado As Entidades.Publicos.SiNoTodos,
                                      idPaciente As Long?,
                                      idDoctor As Long?,
                                      fechaCirugia As Date?,
                                      idTransportista As Integer) As DataTable
      Dim oCategoriaFiscalEmpresa = New CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)
      Dim IvaDiscriminado = oCategoriaFiscalEmpresa.IvaDiscriminado
      Return EjecutaConConexion(
               Function()
                  Dim sql = New SqlServer.Ventas(da)
                  Return sql.GetInformeDeVentas(
                                 sucursales,
                                 desde, hasta,
                                 idZonaGeografica,
                                 IdVendedor,
                                 vendedor,
                                 idCliente,
                                 grabaLibro,
                                 afectaCaja,
                                 idFormaDePago,
                                 idUsuario,
                                 IvaDiscriminado, idLocalidad, idProvincia, numeroComprobanteDesde, numeroComprobanteHasta, letraFiscal,
                                 centroEmisor, mercDespachada, comercial, idCategoria, categoria,
                                 numeroRepartoDesde, numeroRepartoHasta, listaComprobantes,
                                 coeficienteStock, esRemitoTransportista, incluirAnulados, idCentroCosto, ContabilidadPublicos.UtilizaCentroCostos,
                                 actual.NivelAutorizacion, correoEnviado, idPaciente, idDoctor, fechaCirugia,
                                 idTransportista)
               End Function)
   End Function

   Friend Function GetVentasTarjetas(IdSucursal As Integer,
                                IdTipoComprobante As String,
                                Letra As String,
                                CentroEmisor As Integer,
                                NumeroComprobante As Long) As List(Of Entidades.VentaTarjeta)
      Dim ls As List(Of Entidades.VentaTarjeta) = New List(Of Entidades.VentaTarjeta)()
      Dim vt As Entidades.VentaTarjeta

      Dim sqlVe As SqlServer.VentasTarjetas = New SqlServer.VentasTarjetas(da)

      Dim dt As DataTable = sqlVe.VentasTarjetas_GxVenta(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante)

      For Each dr As DataRow In dt.Rows
         vt = New Entidades.VentaTarjeta()

         vt.IdTarjetaCupon = Integer.Parse(dr("IdTarjetaCupon").ToString())
         vt.Banco = New Reglas.Bancos(da).GetUno(Int32.Parse(dr("IdBanco").ToString()))
         vt.Cuotas = Int32.Parse(dr("Cuotas").ToString())
         vt.IdSucursal = Int32.Parse(dr("IdSucursal").ToString())
         vt.Orden = Integer.Parse(dr("Orden").ToString())
         vt.Monto = Decimal.Parse(dr("Monto").ToString())
         vt.NumeroCupon = Int32.Parse(dr("NumeroCupon").ToString())
         '-- REQ-31150.- -Se agrega Campo a la lista del Select-
         vt.NumeroLote = dr.Field(Of Integer?)("NumeroLote").IfNull()
         vt.Tarjeta = New Reglas.Tarjetas(da)._GetUno(Int32.Parse(dr("IdTarjeta").ToString()))
         ls.Add(vt)
      Next

      Return ls

   End Function

   Friend Function GetVentasDespachos(IdSucursal As Integer,
                                      IdTipoComprobante As String,
                                      Letra As String,
                                      CentroEmisor As Integer,
                                      NumeroComprobante As Long) As List(Of Entidades.VentaExportacionEmbarques)

      Dim ls = New List(Of Entidades.VentaExportacionEmbarques)()
      Dim sqlVe = New SqlServer.VentasExportacionEmbarques(da)

      Dim dt As DataTable = sqlVe.VentasExportacionEmbarque_C(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante)

      For Each dr As DataRow In dt.Rows
         Dim vex = New Entidades.VentaExportacionEmbarques()

         vex.IdSucursal = Int32.Parse(dr("IdSucursal").ToString())
         vex.IdTipoComprobante = dr("IdTipoComprobante").ToString()
         vex.LetraComprobante = dr("LetraComprobante").ToString()
         vex.CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
         vex.NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
         vex.IdPermisoEmbarque = dr("IdPermisoEmbarque").ToString()
         vex.IdDestinoDespacho = dr("IdDestinoDespacho").ToString()
         ls.Add(vex)
      Next

      Return ls

   End Function

   <Obsolete("Usar el nuevo método sin Optional")>
   Public Function GetPorRangoFechas(sucursales As Entidades.Sucursal(),
                                     desde As Date,
                                     hasta As Date,
                                     Optional idVendedor As Integer = 0,
                                     Optional origenVendedor As Entidades.OrigenFK = Entidades.OrigenFK.Movimiento,
                                     Optional grabaLibro As String = "TODOS",
                                     Optional idCliente As Long = 0,
                                     Optional afectaCaja As String = "TODOS",
                                     Optional tipoComprobante As String = "",
                                     Optional numeroComprobante As Long = 0,
                                     Optional idFormasPago As Integer = 0,
                                     Optional idUsuario As String = "",
                                     Optional idEstadoComprobante As String = "",
                                     Optional porcUtilidadDesde As Decimal = -1,
                                     Optional porcUtilidadHasta As Decimal = -1,
                                     Optional mercDespachada As String = "TODOS",
                                     Optional comercial As String = "TODOS",
                                     Optional idCategoria As Integer = 0,
                                     Optional numeroReparto As Integer = 0,
                                     Optional ctaCte As Boolean = False,
                                     Optional exclurirComprobanteFiscal As Boolean = False,
                                     Optional exclurirComprobanteElectronico As Boolean = False,
                                     Optional letra As String = "",
                                     Optional emisor As Integer? = Nothing,
                                     Optional ncomprobantedesde As Long? = Nothing,
                                     Optional ncomprobantehasta As Long? = Nothing) As DataTable
      Return GetPorRangoFechas(agregarSelec:=False, agregarVer:=False,
                               sucursales, desde, hasta,
                               idVendedor, origenVendedor, grabaLibro.StringToEnum(Entidades.Publicos.SiNoTodos.TODOS), idCliente,
                               afectaCaja.StringToEnum(Entidades.Publicos.SiNoTodos.TODOS), tipoComprobante, numeroComprobante, idFormasPago, idUsuario,
                               idEstadoComprobante, porcUtilidadDesde, porcUtilidadHasta,
                               mercDespachada, comercial, idCategoria, numeroReparto,
                               ctaCte, exclurirComprobanteFiscal, exclurirComprobanteElectronico,
                               letra, emisor, ncomprobantedesde, ncomprobantehasta)
   End Function

   Public Function GetPorRangoFechas(agregarSelec As Boolean, agregarVer As Boolean,
                                     Sucursales As Entidades.Sucursal(),
                                     desde As Date, hasta As Date,
                                     idVendedor As Integer, origenVendedor As Entidades.OrigenFK,
                                     grabaLibro As Entidades.Publicos.SiNoTodos, idCliente As Long,
                                     afectaCaja As Entidades.Publicos.SiNoTodos, tipoComprobante As String, numeroComprobante As Long,
                                     idFormasPago As Integer, idUsuario As String, idEstadoComprobante As String,
                                     porcUtilidadDesde As Decimal, porcUtilidadHasta As Decimal,
                                     mercDespachada As String, comercial As String,
                                     idCategoria As Integer, numeroReparto As Integer, ctaCte As Boolean,
                                     exclurirComprobanteFiscal As Boolean, exclurirComprobanteElectronico As Boolean,
                                     letra As String, emisor As Integer?, ncomprobantedesde As Long?, ncomprobantehasta As Long?) As DataTable
      Return New SqlServer.Ventas(da).
               GetPorRangoFechas(agregarSelec, agregarVer,
                                 _categoriaFiscalEmpresa,
                                 Sucursales, desde, hasta,
                                 idVendedor, origenVendedor, grabaLibro, idCliente,
                                 afectaCaja, tipoComprobante, numeroComprobante, idFormasPago, idUsuario,
                                 idEstadoComprobante, porcUtilidadDesde, porcUtilidadHasta,
                                 mercDespachada, comercial, idCategoria, numeroReparto,
                                 ctaCte, exclurirComprobanteFiscal, exclurirComprobanteElectronico,
                                 letra, emisor, ncomprobantedesde, ncomprobantehasta)
   End Function

   Public Function GetInfVentasEnCtaCtePorCaja(IdSucursal As Integer, IdCaja As Integer, NumeroPlanilla As Integer) As DataTable

      Dim sql As SqlServer.Ventas
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Ventas(da)
         dt = sql.GetInfVentasEnCtaCtePorCaja(IdSucursal, IdCaja, NumeroPlanilla)
         Me.da.CommitTransaction()
         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetClientesConFacturables(idSucursal As Integer,
                                             fechaDesde As Date,
                                             fechaHasta As Date,
                                             nombreProducto As String,
                                             idVendedor As Integer,
                                             idCategoria As Integer) As DataTable
      Return New SqlServer.Ventas(da).GetClientesConFacturables(idSucursal, fechaDesde, fechaHasta, nombreProducto, idVendedor, idCategoria)
   End Function

   Public Function GetInfFacturables(idSucursal As Integer,
                                     desde As Date, hasta As Date,
                                     idCliente As Long,
                                     idEstadoComprobante As String,
                                     idUsuario As String,
                                     idVendedor As Integer,
                                     idTipoComprobante As String,
                                     idCategoria As Integer,
                                     idCategoriaFiscal As Integer) As DataSet
      Dim ds = New DataSet()

      Dim dtC = New SqlServer.Ventas(da).GetInfFacturables(idSucursal, desde, hasta, idCliente, idEstadoComprobante, idUsuario, idVendedor, idTipoComprobante, idCategoria, idCategoriaFiscal)
      Dim dtD = New SqlServer.Ventas(da).GetInfFacturablesDetalle(idSucursal, desde, hasta, idCliente, idEstadoComprobante, idUsuario, idVendedor, idTipoComprobante, idCategoria, idCategoriaFiscal)

      dtC.TableName = "Cabecera"
      dtD.TableName = "Detalle"

      ds.Tables.Add(dtC)
      ds.Tables.Add(dtD)

      ds.Relations.Add(New DataRelation("Cabecera_Detalle",
                                        {dtC.Columns("IdSucursal"), dtC.Columns("IdTipoComprobante"), dtC.Columns("Letra"), dtC.Columns("CentroEmisor"), dtC.Columns("NumeroComprobante")},
                                        {dtD.Columns("IdSucursalInvocado"), dtD.Columns("IdTipoComprobanteInvocado"), dtD.Columns("LetraInvocado"), dtD.Columns("CentroEmisorInvocado"), dtD.Columns("NumeroComprobanteInvocado")}))

      Return ds
   End Function



   Public Function GetPorSucursalCliente(idSucursal As Integer, IdCLiente As Long, Optional Desde As Date = #1/1/1981#, Optional Hasta As Date = #1/1/2099#) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .Append(" SELECT V.*, E.NombreEmpleado NombreVendedor " & Chr(13))
         .Append(" FROM Ventas V " & Chr(13))
         .Append(" LEFT JOIN Empleados E ON V.IdVendedor = E.IdEmpleado" & Chr(13))
         .Append(" WHERE V.IdSucursal = " & idSucursal.ToString() & Chr(13))
         .Append("   AND V.IdCliente = " & IdCLiente)
         .Append("   AND CONVERT(varchar(11), V.Fecha, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'" & Chr(13))
         .Append("   AND CONVERT(varchar(11), V.Fecha, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")

         'Se creo el IX_Ventas_Fecha para mejorar (notablemente) el tiempo de la consulta
         ''Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         '.Append(" ORDER BY CONVERT(varchar(11), V.fecha, 120), V.IdTipoComprobante, V.Letra, V.CentroEmisor, V.NumeroComprobante")
         .AppendLine("	ORDER BY V.Fecha")
      End With

      Return da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetPorRangoPlanillas(IdSucursal As Integer,
                                          IdCaja As Integer,
                                          NroPlanillaDesde As Long,
                                          NroPlanillaHasta As Long,
                                          Optional Desde As Date = Nothing,
                                          Optional Hasta As Date = Nothing,
                                          Optional IdVendedor As Integer = 0,
                                          Optional GrabaLibro As String = "TODOS",
                                          Optional IdCliente As Long = 0,
                                          Optional AfectaCaja As String = "TODOS",
                                          Optional IdTipoComprobante As String = "",
                                          Optional NumeroComprobante As Long = 0,
                                          Optional IdUsuario As String = "") As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT V.IdTipoComprobante ")
         .Append("	,TC.DescripcionAbrev ")
         .Append("	,V.Letra ")
         .Append("	,V.CentroEmisor ")
         .Append("	,V.NumeroComprobante ")
         .Append("	,V.Fecha ")
         .Append("	,V.IdVendedor ")
         .Append("	,V.IdCliente ")
         .Append("	,C.CodigoCliente ")
         .Append("	,C.NombreCliente ")
         .Append("	,V.NumeroPlanilla ")
         .Append("	,V.NumeroMovimiento ")
         .Append("	,V.ImporteTotal ")
         .Append("	,V.ImportePesos ")
         .Append("	,V.ImporteCheques ")
         .Append("	,V.ImporteTarjetas ")
         .Append("	,V.ImporteTickets ")
         .Append("	,V.ImporteTransfBancaria ")
         .Append("	,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal ")
         .Append("   ,I.IdImpresora")
         .Append("   ,I.TipoImpresora")
         .Append("   ,V.IdEstadoComprobante")
         .Append("   ,V.Usuario")
         .Append("	FROM Ventas V, Clientes C, CategoriasFiscales CF, Impresoras I, TiposComprobantes TC ")
         .Append("  WHERE V.IdCLiente = C.IdCliente ")
         .Append("    AND V.IdCategoriaFiscal = CF.IdCategoriaFiscal")
         .Append("    AND V.IdSucursal = I.IdSucursal")
         .Append("    AND V.CentroEmisor = I.CentroEmisor")
         .Append("	 AND V.IdTipoComprobante = TC.IdTipoComprobante ")
         .Append("	 AND V.IdSucursal = " & IdSucursal.ToString())
         .Append("    AND V.IdCaja = " & IdCaja.ToString())

         .AppendFormat("	 AND V.NumeroPlanilla >= {0}", NroPlanillaDesde.ToString())
         .AppendFormat("	 AND V.NumeroPlanilla <= {0}", NroPlanillaHasta.ToString())
         '.Append("    AND V.IdFormasPago = 1")
         .AppendFormat("	 AND V.NumeroMovimiento IS NOT NULL")

         If Desde > Date.Parse("01/01/1990") Then
            .AppendFormat("	 AND V.fecha >= '{0}'", Desde.ToString("yyyyMMdd HH:mm:ss"))
            .AppendFormat("	 AND V.fecha <= '{0}'", Hasta.ToString("yyyyMMdd HH:mm:ss"))
         End If

         If IdVendedor > 0 Then
            .Append("	AND V.IdVendedor = " & IdVendedor)
         End If

         If IdCliente <> 0 Then
            .Append("	AND C.IdCliente = " & IdCliente)
         End If

         If GrabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(GrabaLibro = "SI", "1", "0").ToString())
         End If

         If AfectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(AfectaCaja = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(IdTipoComprobante) Then
            .AppendLine("	 AND V.IdTipoComprobante = '" & IdTipoComprobante & "'")
         End If

         If NumeroComprobante > 0 Then
            .AppendLine("	 AND V.NumeroComprobante = " & NumeroComprobante.ToString())
         End If

         If Not String.IsNullOrEmpty(IdUsuario) Then
            .AppendLine("	 AND V.Usuario = '" & IdUsuario & "'")
         End If

         'Se creo el IX_Ventas_Fecha para mejorar (notablemente) el tiempo de la consulta
         ''Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         '.Append("	ORDER BY CONVERT(varchar(11), V.fecha, 120)")
         '.Append("	,V.IdTipoComprobante")
         '.Append("	,V.Letra")
         '.Append("	,V.CentroEmisor")
         '.Append("	,V.NumeroComprobante")

         .AppendLine("	ORDER BY V.Fecha")
      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function GetTarjetasVentas(idSucursal As Integer, desde As Date, hasta As Date, numeroCupon As Long,
                                     idCaja As Integer, idBanco As Integer, idCuentaBancaria As Integer,
                                     idCliente As Long, idVendedor As Integer,
                                     idTipoComprobante As String, grabaLibro As Entidades.Publicos.SiNoTodos,
                                     idUsuario As String) As DataTable
      Return New SqlServer.Ventas(da).GetTarjetasVentas(idSucursal, desde, hasta,
                                                        numeroCupon,
                                                        idCaja, idBanco, idCuentaBancaria,
                                                        idCliente, idVendedor,
                                                        idTipoComprobante, grabaLibro,
                                                        idUsuario,
                                                        actual.NivelAutorizacion)
   End Function

   Public Function GetEstadVentasClientes(suc As List(Of Integer),
                                          cantidad As Integer,
                                          Desde As Date,
                                          Hasta As Date,
                                          idMarca As Integer,
                                          idModelo As Integer,
                                          idRubro As Integer,
                                          idSubRubro As Integer,
                                          IdProducto As String,
                                          discIVA As Boolean,
                                          IdVendedor As Integer) As DataTable

      Dim sql As SqlServer.Ventas
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Ventas(da)

         dt = sql.GetEstadVentasClientes(suc, cantidad, Desde, Hasta, idMarca, idModelo, idRubro, idSubRubro, IdProducto, discIVA, IdVendedor)

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

   Public Function GetCobranzasDetalladas(IdSucursal As Integer,
                                          Desde As Date, Hasta As Date,
                                          Vendedor As String,
                                          Optional IdVendedor As Integer = 0,
                                          Optional IdCliente As Long = 0) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT V.IdSucursal ")
         .AppendLine("      ,V.Fecha ")
         .AppendLine("      ,V.IdTipoComprobante ")
         .AppendLine("      ,V.Letra ")
         .AppendLine("      ,V.CentroEmisor ")
         .AppendLine("      ,V.NumeroComprobante ")
         .AppendLine("      ,V.SubTotal ")
         .AppendLine("      ,V.ImporteTotal ")
         .AppendLine("      ,V.IdCliente ")
         .AppendLine("      ,C.NombreCliente ")
         .AppendLine("      ,V.IdVendedor ")
         .AppendLine("      ,E1.NombreEmpleado AS NombreVendedor ")
         .AppendLine("      ,C.IdVendedor AS IdVendedorClie ")
         .AppendLine("      ,E2.NombreEmpleado as NombreVendedorClie ")
         .AppendLine(" FROM VentasFormasPago VFP, TiposComprobantes TC, Ventas V ")
         .AppendLine("  INNER JOIN Empleados E1 ON V.IdVendedor = E1.IdEmpleado ")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("  INNER JOIN Empleados E2 ON C.IdVendedor = E2.IdEmpleado ")
         .AppendLine("  WHERE V.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("   AND V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine("   AND (V.IdEstadoComprobante<>'ANULADO' OR V.IdEstadoComprobante IS NULL)")
         .AppendLine("   AND VFP.Dias=0 ")   'Contado
         .AppendLine("   AND TC.AfectaCaja = 'True' ")    'Contemplo solo aquellos comprobantes que manejan dinero
         .AppendLine("   AND TC.EsComercial = 'True' ")   'Contemplo solo aquellos comprobantes que reales (excluyo la ND por Cheq. Rechazado)
         .AppendLine("   AND V.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("	 AND CONVERT(varchar(11), V.fecha, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("	 AND CONVERT(varchar(11), V.fecha, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")

         If IdVendedor > 0 Then
            If Vendedor = "MOVIMIENTO" Then
               .AppendLine("	AND V.IdVendedor = " & IdVendedor)
            Else
               .AppendLine("	AND C.IdVendedor = " & IdVendedor)
            End If
         End If

         If IdCliente > 0 Then
            .AppendLine("	AND V.IdCliente = " & IdCliente)
         End If

         .AppendLine(" ORDER BY V.IdSucursal ")
         If Vendedor = "MOVIMIENTO" Then
            .AppendLine("         ,E1.NombreEmpleado")
            .AppendLine("         ,V.IdVendedor ")
         Else
            .AppendLine("         ,E2.NombreEmpleado")
            .AppendLine("         ,C.IdVendedor ")
         End If
         .AppendLine("         ,V.Fecha ")

      End With

      Return da.GetDataTable(stb.ToString())

   End Function

#End Region

End Class