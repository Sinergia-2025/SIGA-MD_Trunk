Imports System.Globalization
Imports Eniac.Reglas.ProductosSucursales
Public Class CuentasCorrientesPagos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "CuentasCorrientesPagos"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

   Public Function GetProximoNumero(IdSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Integer) As Integer
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .Append("SELECT (Numero + 1) Numero ")
         .Append(" FROM VentasNumeros")
         .Append(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .Append(" AND LetraFiscal = '" & letraFiscal & "'")
         .Append(" AND CentroEmisor = " & emisor.ToString())
         .Append(" AND IdSucursal = " & IdSucursal.ToString())
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stbQuery.ToString())
      If dt.Rows.Count > 0 Then
         Return Integer.Parse(dt.Rows(0)("Numero").ToString())
      Else
         Return 1
      End If
   End Function

   Friend Sub GrabaCuentaCorrientePagos(ent As Entidades.CuentaCorrientePago, cuota As Integer)

      Dim ajuste As Decimal = ent.CuentaCorriente.TipoComprobante.CoeficienteValores
      Dim saldo As Decimal = 0
      Dim importeCuota As Decimal = 0

      Dim tipo2 As String = Nothing
      Dim letra2 As String = Nothing
      Dim cuota2 As Integer = 0
      Dim comprobante2 As Long = 0
      Dim emisor2 As Integer = 0

      If ent.CuentaCorriente.TipoComprobante.EsRecibo = False Then

         tipo2 = ent.CuentaCorriente.TipoComprobante.IdTipoComprobante
         letra2 = ent.CuentaCorriente.Letra
         emisor2 = ent.CuentaCorriente.CentroEmisor
         comprobante2 = ent.CuentaCorriente.NumeroComprobante
         cuota2 = cuota

         saldo = ent.SaldoCuota
         importeCuota = ent.SaldoCuota
      Else

         importeCuota = ent.Paga

      End If

      Dim sql As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)

      'En caso de que venga desde un subsistema y no se haya grabado el ImporteCapital o ImporteInteres lo corrijo
      If ent.ImporteCuota <> ent.ImporteCapital + ent.ImporteInteres Then
         If ent.ImporteCapital = 0 Then
            ent.ImporteCapital = ent.ImporteCuota
         ElseIf ent.ImporteCapital <> 0 And ent.ImporteInteres = 0 Then
            ent.ImporteInteres = ent.ImporteCuota - ent.ImporteCapital
         End If
      End If

      sql.CuentasCorrientesPagos_I(ent.CuentaCorriente.IdSucursal, ent.CuentaCorriente.TipoComprobante.IdTipoComprobante,
                                    ent.CuentaCorriente.Letra, ent.CuentaCorriente.CentroEmisor,
                                    ent.CuentaCorriente.NumeroComprobante, cuota,
                                    ent.CuentaCorriente.Fecha, ent.FechaVencimiento,
                                    importeCuota * ajuste, saldo * ajuste,
                                    ent.CuentaCorriente.FormaPago.IdFormasPago, ent.CuentaCorriente.Observacion,
                                    tipo2, comprobante2,
                                    emisor2, cuota2,
                                    letra2, ent.DescuentoRecargoPorc,
                                    ent.DescuentoRecargo,
                                    ent.ImporteCapital, ent.ImporteInteres, ent.FechaVencimiento2, ent.ImporteCuota2,
                                    ent.FechaVencimiento3, ent.ImporteCuota3, ent.FechaVencimiento4, ent.ImporteCuota4,
                                    ent.FechaVencimiento5, ent.ImporteCuota5, ent.CodigoDeBarra, ent.ReferenciaCuota,
                                    ent.IdEmbarcacion, ent.IdCama, ent.CodigoDeBarraSirplus, ent.FechaPromedioCobro, ent.PromedioDiasCobro, ent.CantidadDiasCobro)

   End Sub

   Friend Sub Eliminar(ent As Entidades.CuentaCorrientePago)

      Dim sql As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)

      sql.CuentasCorrientesPagos_D(ent.CuentaCorriente.IdSucursal,
                                    ent.CuentaCorriente.TipoComprobante.IdTipoComprobante,
                                    ent.CuentaCorriente.Letra,
                                    ent.CuentaCorriente.CentroEmisor,
                                    ent.CuentaCorriente.NumeroComprobante)

   End Sub

   Friend Sub ActualizaSaldo(ent As Entidades.CuentaCorrientePago, importeAplicar As Decimal)
      Dim sql As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)
      sql.CuentasCorrientesPagos_USaldo(ent.IdSucursal,
                                        ent.IdTipoComprobante,
                                        ent.Letra,
                                        ent.CentroEmisor,
                                        ent.NumeroComprobante,
                                        ent.Cuota,
                                        importeAplicar)
   End Sub

   '# Este método actualiza Fecha de Comprobante y de Vencimiento
   Public Sub ActualizaFechas(eCCP As List(Of Entidades.CuentaCorrientePago), actualizarVencimiento As Boolean)

      Dim sCCP As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)
      For Each CCP As Entidades.CuentaCorrientePago In eCCP
         sCCP.ActualizaFechas(CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, Convert.ToInt16(CCP.CentroEmisor), CCP.NumeroComprobante, CCP.FechaEmision, CCP.FechaVencimiento,
                              actualizarVencimiento)
      Next

   End Sub

   Public Sub ActualizaFechasVencimiento(fechas As DataTable)
      EjecutaConTransaccion(
         Sub()
            _ActualizaFechasVencimiento(fechas)
         End Sub)
   End Sub

   Private Sub _ActualizaFechasVencimiento(fechas As DataTable)

      Dim sql = New SqlServer.CuentasCorrientesPagos(da)
      Dim sql2 = New SqlServer.CuentasCorrientes(da)

      Dim dr0 = fechas(0)
      sql2.CuentasCorrientes_LimpiaFechaExportacion(dr0.Field(Of Integer)("IdSucursal"),
                                                    dr0.Field(Of String)("IdTipoComprobante"),
                                                    dr0.Field(Of String)("Letra"),
                                                    Convert.ToInt16(dr0.Field(Of Integer)("CentroEmisor")),
                                                    dr0.Field(Of Long)("NumeroComprobante"))

      For Each drFecha As DataRow In fechas.Rows
         sql.CuentasCorrientesPagos_UVencimiento(drFecha.Field(Of Integer)("IdSucursal"),
                                                 drFecha.Field(Of String)("IdTipoComprobante"),
                                                 drFecha.Field(Of String)("Letra"),
                                                 Convert.ToInt16(drFecha.Field(Of Integer)("CentroEmisor")),
                                                 drFecha.Field(Of Long)("NumeroComprobante"),
                                                 drFecha.Field(Of Integer)("Cuota"),
                                                 drFecha.Field(Of Date)("FechaAPagar"),
                                                 drFecha.Field(Of Long)("ReferenciaCuota"))
      Next
   End Sub

   Friend Sub ActualizaComprobantes(ent As Entidades.CuentaCorrientePago, cuota As Integer)

      Dim sql As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)

      sql.CuentasCorrientesPagos_UComprobante(ent.CuentaCorriente.IdSucursal, ent.CuentaCorriente.TipoComprobante.IdTipoComprobante,
                           ent.CuentaCorriente.Letra, ent.CuentaCorriente.CentroEmisor, ent.CuentaCorriente.NumeroComprobante,
                           cuota, ent.TipoComprobante.IdTipoComprobante, ent.NumeroComprobante, ent.CentroEmisor, ent.Cuota, ent.Letra)

   End Sub
   Public Sub ActualizaComprobantes(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Short,
                                     numeroComprobante As Long,
                                     cuotaNumero As Integer,
                                     idTipoComprobante2 As String,
                                     numeroComprobante2 As Long,
                                     centroEmisor2 As Integer,
                                     cuotaNumero2 As Integer,
                                     letra2 As String)

      EjecutaConTransaccion(Sub()
                               Dim sql As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)

                               sql.CuentasCorrientesPagos_UComprobante(idSucursal, idTipoComprobante,
                                                    letra, centroEmisor, numeroComprobante,
                                                    cuotaNumero, idTipoComprobante2, numeroComprobante2, centroEmisor2, cuotaNumero2, letra2)
                            End Sub)
   End Sub
   Public Function GetPorCliente(sucursales As Entidades.Sucursal(),
                                 idCliente As Long,
                                 fechaUtilizada As String,
                                 desde As Date,
                                 hasta As Date,
                                 grabaLibro As String,
                                 grupo As String,
                                 excluirMinutas As String,
                                 soloConSaldo As Boolean,
                                 fechaInteres As Date,
                                 idMoneda As Integer,
                                 tipoConversion As Entidades.Moneda_TipoConversion,
                                 cotizDolar As Decimal,
                                 excluirPreComprobantes As Boolean,
                                 IdEmbarcacion As Long, idCama As Long) As DataTable

      Return New SqlServer.CuentasCorrientesPagos(da).GetPorCliente(sucursales,
                                                                    idCliente,
                                                                    fechaUtilizada,
                                                                    desde, hasta,
                                                                    grabaLibro,
                                                                    grupo,
                                                                    excluirMinutas,
                                                                    soloConSaldo,
                                                                    fechaInteres,
                                                                    idMoneda,
                                                                    tipoConversion,
                                                                    cotizDolar,
                                                                    actual.NivelAutorizacion,
                                                                    excluirPreComprobantes,
                                                                    IdEmbarcacion,
                                                                    Publicos.CtaCteEmbarcacion,
                                                                    idCama)
   End Function

   Public Function GetKardexComprobante(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        emisor As Integer,
                                        numero As Long) As DataTable

      Return New SqlServer.CuentasCorrientesPagos(da).GetKardexComprobante(idSucursal, idTipoComprobante, letra, emisor, numero)

      'Dim stb As StringBuilder = New StringBuilder("")

      'With stb
      '   .Length = 0
      '   .Append("SELECT CC.IdSucursal, ")
      '   .Append("	CC.IdTipoComprobante, ")
      '   .Append("	CC.Letra, ")
      '   .Append("	CC.CentroEmisor, ")
      '   .Append("	CC.NumeroComprobante, ")
      '   .Append("	CC.CuotaNumero, ")
      '   .Append("	CC.Fecha, ")
      '   .Append("	CC.FechaVencimiento, ")
      '   .Append("	CC.ImporteCuota, ")
      '   .Append("	CC.Observacion ")
      '   .Append("	FROM CuentasCorrientesPagos CC")

      '   .Append("  WHERE CC.IdSucursal = " & Sucursal.ToString())

      '   .Append("	 AND (")
      '   .Append("	 (CC.IdTipoComprobante = '" & TipoComprobante & "'")
      '   .Append("	 AND CC.Letra = '" & Letra & "'")
      '   .Append("	 AND CC.CentroEmisor = " & Emisor)
      '   .Append("	 AND CC.NumeroComprobante = " & Numero & ")")

      '   .Append("	 OR (CC.IdTipoComprobante2 = '" & TipoComprobante & "'")
      '   .Append("	 AND CC.Letra2 = '" & Letra & "'")
      '   .Append("	 AND CC.CentroEmisor2 = " & Emisor)
      '   .Append("	 AND CC.NumeroComprobante2 = " & Numero & ")")
      '   .Append("	 ) ")

      '   .Append("	ORDER BY CC.Fecha")
      '   .Append("	,CC.IdTipoComprobante")
      '   .Append("	,CC.Letra")
      '   .Append("	,CC.CentroEmisor")
      '   .Append("	,CC.NumeroComprobante")
      '   .Append("	,CC.CuotaNumero")

      'End With

      'Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorCuentaCorriente(ctacte As Entidades.CuentaCorriente) As List(Of Entidades.CuentaCorrientePago)
      Dim sql As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)
      Dim dt As DataTable = sql.GetPorCuentaCorriente(ctacte.IdSucursal, ctacte.TipoComprobante.IdTipoComprobante, ctacte.Letra, ctacte.CentroEmisor, ctacte.NumeroComprobante)
      Dim o As Entidades.CuentaCorrientePago
      Dim oLis As List(Of Entidades.CuentaCorrientePago) = New List(Of Entidades.CuentaCorrientePago)()
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CuentaCorrientePago()
         Me.CargarUna(dr, o)
         o.ImporteCapital *= ctacte.TipoComprobante.CoeficienteValores
         o.ImporteInteres *= ctacte.TipoComprobante.CoeficienteValores
         o.ImporteCuota *= ctacte.TipoComprobante.CoeficienteValores
         o.Paga *= ctacte.TipoComprobante.CoeficienteValores
         o.SaldoCuota *= ctacte.TipoComprobante.CoeficienteValores
         If ctacte.TipoComprobante.IdTipoComprobante <> o.TipoComprobante.IdTipoComprobante Then
            o.ImporteCuota = sql.GetImporteCuota(o.IdSucursal, o.TipoComprobante.IdTipoComprobante, o.Letra, o.CentroEmisor, o.NumeroComprobante, o.Cuota)
            'Se calcula el saldo a 1 segundo antes del recibo, es decir el que tenia al momento de hacerlo.
            'No se utiliza el de la base porque podria hacer los recibos en momentos distintos cronologricamente.
            o.SaldoCuota = sql.GetSaldoCuota(o.IdSucursal, o.TipoComprobante.IdTipoComprobante, o.Letra, o.CentroEmisor, o.NumeroComprobante, o.Cuota, ctacte.Fecha.AddSeconds(-1))
            'If o.TipoComprobante.EsAnticipo = False Then
            o.FechaVencimiento = sql.GetFechaVencimiento(o.IdSucursal, o.TipoComprobante.IdTipoComprobante, o.Letra, o.CentroEmisor, o.NumeroComprobante, o.Cuota)
            o.FechaEmision = sql.GetFechaEmision(o.IdSucursal, o.TipoComprobante.IdTipoComprobante, o.Letra, o.CentroEmisor, o.NumeroComprobante, o.Cuota)
            'End If
         End If
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Private Sub CargarUna(dr As DataRow, o As Entidades.CuentaCorrientePago)
      If Not String.IsNullOrEmpty(dr("IdTipoComprobante2").ToString()) Then
         With o
            .IdSucursal = dr.Field(Of Integer)("IdSucursal")
            .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr.Field(Of String)("IdTipoComprobante2"))
            .Letra = dr.Field(Of String)("Letra2")
            .CentroEmisor = dr.Field(Of Integer)("CentroEmisor2")
            .NumeroComprobante = dr.Field(Of Long)("NumeroComprobante2")
            .Cuota = dr.Field(Of Integer)("CuotaNumero2")
            .FechaEmision = dr.Field(Of Date)("Fecha")
            .FechaVencimiento = dr.Field(Of Date)("FechaVencimiento")
            .ImporteCapital = dr.Field(Of Decimal)("ImporteCapital")
            .ImporteInteres = dr.Field(Of Decimal)("ImporteInteres")
            .ImporteCuota = dr.Field(Of Decimal)("ImporteCuota")
            .FechaVencimiento2 = dr.Field(Of Date?)("FechaVencimiento2")
            .ImporteCuota2 = dr.Field(Of Decimal?)("ImporteVencimiento2")
            .FechaVencimiento3 = dr.Field(Of Date?)("FechaVencimiento3")
            .ImporteCuota3 = dr.Field(Of Decimal?)("ImporteVencimiento3")
            .CodigoDeBarra = dr.Field(Of String)("CodigoDeBarra")
            .ReferenciaCuota = dr.Field(Of Long)(Entidades.CuentaCorrientePago.Columnas.ReferenciaCuota.ToString())
            .SaldoCuota = dr.Field(Of Decimal)("SaldoCuota")
            .FormaPago.DescripcionFormasPago = New Reglas.VentasFormasPago().GetUna(dr.Field(Of Integer)("IdFormasPago")).DescripcionFormasPago
            .Paga = dr.Field(Of Decimal)("ImporteCuota")
            .DescuentoRecargoPorc = dr.Field(Of Decimal)("DescuentoRecargoPorc")
            .DescuentoRecargo = dr.Field(Of Decimal)("DescuentoRecargo")
            .NombreProductos = dr.Field(Of String)("NombreProductos")
            '-- REQ-33289.- -------------------------------------------------------------------------------------------------------
            If New Reglas.Generales().ExisteTabla("Embarcaciones") Then
               .IdEmbarcacion = dr.Field(Of Long?)(Entidades.CuentaCorrientePago.Columnas.IdEmbarcacion.ToString()).IfNull()
            End If
            '----------------------------------------------------------------------------------------------------------------------
            .CodigoDeBarraSirplus = dr.Field(Of String)("CodigoDeBarraSirplus")

            .PromedioDiasCobro = dr.Field(Of Decimal?)("PromedioDiasCobro")
            .CantidadDiasCobro = dr.Field(Of Decimal?)("CantidadDiasCobro")

         End With
      End If
   End Sub

   Public Function GetDetalleCobranzas(sucursal As Integer,
                                       desde As Date,
                                       hasta As Date,
                                       idVendedor As Integer) As DataTable
      Dim sql As SqlServer.CuentasCorrientesPagos
      Dim dt As DataTable
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.CuentasCorrientesPagos(da)
         dt = sql.GetDetalleDeCobranzas(sucursal, desde, hasta, idVendedor)

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetSaldoClientes(desde As Date, hasta As Date) As DataTable

      Dim sql As SqlServer.CuentasCorrientesPagos
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.CuentasCorrientesPagos(da)
         dt = sql.GetSaldoClientes(desde, hasta)

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetSaldosCtaCte(sucursales As Entidades.Sucursal(),
                                   idCliente As Long,
                                   cliente As Entidades.Cliente.ClienteVinculado,
                                   idEmbarcacion As Long) As DataTable
      Return EjecutaConConexion(Function() _GetSaldosCtaCte(sucursales, idCliente, cliente, idEmbarcacion))
   End Function

   Public Function _GetSaldosCtaCte(sucursales As Entidades.Sucursal(),
                                    idCliente As Long,
                                    cliente As Entidades.Cliente.ClienteVinculado,
                                    idEmbarcacion As Long) As DataTable
      Dim dt As DataTable
      dt = _GetSaldosCtaCte(sucursales,
                            Nothing, 0,
                            idCliente,
                            idZonaGeografica:=String.Empty,
                            excluirSaldosNegativos:="NO", idCategoria:=0,
                            grabaLibro:="TODOS", grupo:=String.Empty, excluirAnticipos:="NO",
                            excluirPreComprobantes:="NO", idProvincia:=String.Empty, categoria:="ACTUAL",
                            vendedor:="ACTUAL", usaClienteCtaCte:=False, idEstadoCliente:=0,
                            idCobrador:=0, cobrador:=Entidades.OrigenFK.Actual, grupoCategoria:="",
                            idFormaDePago:=0, cliente, idEmbarcacion, activo:=Entidades.Publicos.SiNoTodos.TODOS)
      Dim dtResult As DataTable = dt.Clone()
      For Each dr As DataRow In dt.Rows
         Dim drResultCol As DataRow() = dtResult.Select(String.Format("IdCliente = {0}", dr("IdCliente")))
         Dim drResult As DataRow
         If drResultCol.Length = 0 Then
            drResult = dtResult.NewRow()
            drResult("IdCliente") = dr("IdCliente")
            drResult("Saldo") = 0
            drResult("IMPORTE2") = 0
            drResult("SaldoVencido") = 0
            drResult("CodVin") = dr("CodVin")
            drResult("NombreVin") = dr("NombreVin")
            dtResult.Rows.Add(drResult)
         Else
            drResult = drResultCol(0)
         End If
         If IsNumeric(dr("Saldo")) Then
            drResult("Saldo") = Decimal.Parse(drResult("Saldo").ToString()) + Decimal.Parse(dr("Saldo").ToString())
         End If
         If IsNumeric(dr("IMPORTE2")) Then
            drResult("IMPORTE2") = Decimal.Parse(drResult("IMPORTE2").ToString()) + Decimal.Parse(dr("IMPORTE2").ToString())
         End If
         If IsNumeric(dr("SaldoVencido")) Then
            drResult("SaldoVencido") = Decimal.Parse(drResult("SaldoVencido").ToString()) + Decimal.Parse(dr("SaldoVencido").ToString())
         End If
      Next
      Return dtResult
   End Function

   Public Function GetSaldosCtaCte(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                   idVendedor As Integer, idCliente As Long, idZonaGeografica As String,
                                   excluirSaldosNegativos As String, idCategoria As Integer,
                                   grabaLibro As String, grupo As String,
                                   excluirAnticipos As String, excluirPreComprobantes As String,
                                   idProvincia As String, categoria As String, vendedor As String,
                                   usaClienteCtaCte As Boolean, idEstadoCliente As Integer,
                                   idCobrador As Integer, cobrador As Entidades.OrigenFK, grupoCategoria As String,
                                   idFormaDePago As Integer, cliente As Entidades.Cliente.ClienteVinculado,
                                   activo As Entidades.Publicos.SiNoTodos) As DataTable
      Return EjecutaConConexion(Function()
                                   Return _GetSaldosCtaCte(sucursales, fechaHasta,
                                                   idVendedor, idCliente, idZonaGeografica,
                                                   excluirSaldosNegativos, idCategoria,
                                                   grabaLibro, grupo,
                                                   excluirAnticipos, excluirPreComprobantes,
                                                   idProvincia, categoria, vendedor,
                                                   usaClienteCtaCte, idEstadoCliente,
                                                   idCobrador, cobrador, grupoCategoria,
                                                   idFormaDePago, cliente, idEmbarcacion:=0,
                                                   activo)
                                End Function)
   End Function

   Public Function _GetSaldosCtaCte(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                    idVendedor As Integer, idCliente As Long, idZonaGeografica As String,
                                    excluirSaldosNegativos As String, idCategoria As Integer,
                                    grabaLibro As String, grupo As String,
                                    excluirAnticipos As String, excluirPreComprobantes As String,
                                    idProvincia As String, categoria As String, vendedor As String,
                                    usaClienteCtaCte As Boolean, idEstadoCliente As Integer,
                                    idCobrador As Integer, cobrador As Entidades.OrigenFK, grupoCategoria As String,
                                    idFormaDePago As Integer, cliente As Entidades.Cliente.ClienteVinculado, idEmbarcacion As Long,
                                    activo As Entidades.Publicos.SiNoTodos) As DataTable
      Dim blnCalcularPromedios = Publicos.CtaCte.CtaCteClientesCalcularPromedios

      Dim sql = New SqlServer.CuentasCorrientesPagos(da)
      Return sql.GetSaldosCtaCte(sucursales, fechaHasta,
                                 idVendedor, idCliente, idZonaGeografica,
                                 excluirSaldosNegativos, idCategoria,
                                 grabaLibro, grupo,
                                 excluirAnticipos, blnCalcularPromedios, excluirPreComprobantes,
                                 idProvincia, categoria, vendedor,
                                 usaClienteCtaCte, idEstadoCliente,
                                 idCobrador, cobrador, actual.NivelAutorizacion, grupoCategoria,
                                 idFormaDePago, cliente, idEmbarcacion,
                                 activo)
   End Function

   Public Function GetInformeSituacionCrediticia(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                   idVendedor As Integer, idCliente As Long,
                                   excluirSaldosNegativos As String, idCategoria As Integer,
                                   grabaLibro As String,
                                   excluirAnticipos As String, excluirPreComprobantes As String,
                                   categoria As String, vendedor As String,
                                   idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                   cliente As Entidades.Cliente.ClienteVinculado,
                                   activo As Entidades.Publicos.SiNoTodos, FechaCobro As Date) As DataTable
      Return EjecutaConConexion(Function()
                                   Return _GetInformeSituacionCrediticia(sucursales, fechaHasta,
                                                   idVendedor, idCliente,
                                                   excluirSaldosNegativos, idCategoria,
                                                   grabaLibro,
                                                   excluirAnticipos, excluirPreComprobantes,
                                                   categoria, vendedor,
                                                   idCobrador, cobrador,
                                                   cliente,
                                                   activo, FechaCobro)
                                End Function)
   End Function

   Public Function _GetInformeSituacionCrediticia(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                    idVendedor As Integer, idCliente As Long,
                                    excluirSaldosNegativos As String, idCategoria As Integer,
                                    grabaLibro As String,
                                    excluirAnticipos As String, excluirPreComprobantes As String,
                                    categoria As String, vendedor As String,
                                    idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                   cliente As Entidades.Cliente.ClienteVinculado,
                                    activo As Entidades.Publicos.SiNoTodos, FechaCobro As Date) As DataTable
      Dim blnCalcularPromedios = Publicos.CtaCte.CtaCteClientesCalcularPromedios

      Dim sql = New SqlServer.CuentasCorrientesPagos(da)
      Return sql.GetInformeSituacionCrediticia(sucursales, fechaHasta,
                                 idVendedor, idCliente,
                                 excluirSaldosNegativos, idCategoria,
                                 grabaLibro,
                                 excluirAnticipos, blnCalcularPromedios, excluirPreComprobantes,
                                  categoria, vendedor,
                                 idCobrador, cobrador, actual.NivelAutorizacion,
                                 cliente,
                                 activo, FechaCobro)
   End Function

   Public Function GetInformeSituacionCrediticiaPIVOT(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                   idVendedor As Integer, idCliente As Long,
                                   excluirSaldosNegativos As String, idCategoria As Integer,
                                   grabaLibro As String,
                                   excluirAnticipos As String, excluirPreComprobantes As String,
                                   categoria As String, vendedor As String,
                                   idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                   cliente As Entidades.Cliente.ClienteVinculado,
                                   activo As Entidades.Publicos.SiNoTodos, FechaCobro As Date,
                                   pivotcolName As String, sumPivot As String, dtcolumnas As DataTable) As GetInformeSituacionCrediticiaPivotInfo

      Dim blnCalcularPromedios = Publicos.CtaCte.CtaCteClientesCalcularPromedios
      Dim sql = New SqlServer.CuentasCorrientesPagos(da)

      Return New GetInformeSituacionCrediticiaPivotInfo() _
                                                      With {.dtcolumnas = dtcolumnas,
                                                            .dtResult = sql.GetInformeSituacionCrediticiaPIVOT(sucursales, fechaHasta,
                                                                           idVendedor, idCliente,
                                                                           excluirSaldosNegativos, idCategoria,
                                                                           grabaLibro,
                                                                           excluirAnticipos, blnCalcularPromedios, excluirPreComprobantes,
                                                                            categoria, vendedor,
                                                                           idCobrador, cobrador, actual.NivelAutorizacion,
                                                                           cliente,
                                                                           activo, FechaCobro, pivotcolName, sumPivot)}


   End Function
   Public Function GetControlInconsistenciasCtaCteVsCtaCtePagos(idSucursal As Integer) As DataTable

      Dim sql As SqlServer.CuentasCorrientesPagos
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.CuentasCorrientesPagos(da)

         dt = sql.GetControlInconsistenciasCtaCtevsCtaCtePagos(idSucursal)

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetInformeSituacionCrediticiaSinSaldos(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                              idVendedor As Integer, idCliente As Long,
                                              excluirSaldosNegativos As String, idCategoria As Integer, grabaLibro As String, excluirAnticipos As String, excluirPreComprobantes As String,
                                              categoria As String, agregarSinSaldo As String, vendedor As String, idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                              cliente As Entidades.Cliente.ClienteVinculado,
                                              activo As Entidades.Publicos.SiNoTodos, FechaCobro As Date) As DataTable


      Return EjecutaConConexion(Function() _
             _GetInformeSituacionCrediticiaSinSaldos(sucursales, fechaHasta,
                                         idVendedor, idCliente, excluirSaldosNegativos, idCategoria, grabaLibro, excluirAnticipos, excluirPreComprobantes,
                                         categoria, agregarSinSaldo, vendedor, idCobrador, cobrador,
                                         cliente, activo, FechaCobro))


   End Function

   Public Function GetInformeSituacionCrediticiaSinSaldosPIVOT(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                              idVendedor As Integer, idCliente As Long,
                                              excluirSaldosNegativos As String, idCategoria As Integer, grabaLibro As String, excluirAnticipos As String, excluirPreComprobantes As String,
                                              categoria As String, agregarSinSaldo As String, vendedor As String, idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                              cliente As Entidades.Cliente.ClienteVinculado,
                                              activo As Entidades.Publicos.SiNoTodos, FechaCobro As Date,
                                              pivotcolName As String, sumPivot As String, dtcolumnas As DataTable) As GetInformeSituacionCrediticiaPivotInfo

      Dim blnCalcularPromedios = Publicos.CtaCte.CtaCteClientesCalcularPromedios

      Dim sql = New SqlServer.CuentasCorrientesPagos(da)

      Return New GetInformeSituacionCrediticiaPivotInfo() _
                                                      With {.dtcolumnas = dtcolumnas,
                                                            .dtResult = sql.GetInformeSituacionCrediticiaSinSaldoPIVOT(sucursales, fechaHasta,
                                                            idVendedor, idCliente,
                                                            excluirSaldosNegativos, idCategoria, grabaLibro, excluirAnticipos, blnCalcularPromedios, excluirPreComprobantes,
                                                            categoria, agregarSinSaldo, vendedor, idCobrador, cobrador,
                                                            actual.NivelAutorizacion, cliente,
                                                            activo, FechaCobro, pivotcolName.ToString(), sumPivot.ToString())}

   End Function

   Public Function _GetInformeSituacionCrediticiaSinSaldos(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                               idVendedor As Integer, idCliente As Long,
                                               excluirSaldosNegativos As String, idCategoria As Integer,
                                               grabaLibro As String, excluirAnticipos As String, excluirPreComprobantes As String,
                                               categoria As String, agregarSinSaldo As String, vendedor As String, idCobrador As Integer,
                                               cobrador As Entidades.OrigenFK,
                                               cliente As Entidades.Cliente.ClienteVinculado,
                                               activo As Entidades.Publicos.SiNoTodos, FechaCobro As Date) As DataTable
      Dim blnCalcularPromedios = Publicos.CtaCte.CtaCteClientesCalcularPromedios

      Dim sql = New SqlServer.CuentasCorrientesPagos(da)
      Return sql.GetInformeSituacionCrediticiaSinSaldo(sucursales, fechaHasta,
                                            idVendedor, idCliente,
                                            excluirSaldosNegativos, idCategoria, grabaLibro, excluirAnticipos, blnCalcularPromedios, excluirPreComprobantes,
                                            categoria, agregarSinSaldo, vendedor, idCobrador, cobrador,
                                            actual.NivelAutorizacion, cliente,
                                            activo, FechaCobro)
   End Function
   Public Function GetEstadoCuentasCorrientes(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                              idVendedor As Integer, idCliente As Long, idZonaGeografica As String,
                                              excluirSaldosNegativos As String, idCategoria As Integer, grabaLibro As String, grupo As String, excluirAnticipos As String, excluirPreComprobantes As String,
                                              idProvincia As String, categoria As String, agregarSinSaldo As String, vendedor As String, idEstadoCliente As Integer, idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                              grupoCategoria As String, cliente As Entidades.Cliente.ClienteVinculado,
                                              activo As Entidades.Publicos.SiNoTodos) As DataTable
      Return EjecutaConConexion(Function() _
             _GetEstadoCuentasCorrientes(sucursales, fechaHasta,
                                         idVendedor, idCliente, idZonaGeografica,
                                         excluirSaldosNegativos, idCategoria, grabaLibro, grupo, excluirAnticipos, excluirPreComprobantes,
                                         idProvincia, categoria, agregarSinSaldo, vendedor, idEstadoCliente, idCobrador, cobrador,
                                         grupoCategoria, cliente,
                                         activo))
   End Function

   Public Function _GetEstadoCuentasCorrientes(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                               idVendedor As Integer, idCliente As Long, idZonaGeografica As String,
                                               excluirSaldosNegativos As String, idCategoria As Integer, grabaLibro As String, grupo As String, excluirAnticipos As String, excluirPreComprobantes As String,
                                               idProvincia As String, categoria As String, agregarSinSaldo As String, vendedor As String, idEstadoCliente As Integer, idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                               grupoCategoria As String, cliente As Entidades.Cliente.ClienteVinculado,
                                               activo As Entidades.Publicos.SiNoTodos) As DataTable
      Dim blnCalcularPromedios = Publicos.CtaCte.CtaCteClientesCalcularPromedios

      Dim sql = New SqlServer.CuentasCorrientesPagos(da)
      Return sql.GetEstadoCuentasCorrientes(sucursales, fechaHasta,
                                            idVendedor, idCliente, idZonaGeografica,
                                            excluirSaldosNegativos, idCategoria, grabaLibro, grupo, excluirAnticipos, blnCalcularPromedios, excluirPreComprobantes,
                                            idProvincia, categoria, agregarSinSaldo, vendedor, idEstadoCliente, idCobrador, cobrador,
                                            actual.NivelAutorizacion, grupoCategoria, cliente,
                                            activo)
   End Function

   'Public Function GetSaldosPorVencimientos(sucursales As Entidades.Sucursal(),
   '                                         fechaHasta As String,
   '                                         IdVendedor As Integer,
   '                                         idCliente As Long,
   '                                         idZonaGeografica As String,
   '                                         excluirSaldosNegativos As String,
   '                                         idCategoria As Integer,
   '                                         grabaLibro As String,
   '                                         grupo As String,
   '                                         excluirAnticipos As String,
   '                                         excluirPreComprobantes As String,
   '                                         idProvincia As String,
   '                                         categoria As String,
   '                                         usaClienteCtaCte As Boolean,
   '                                         idEstadoCliente As Integer,
   '                                         idCobrador As Integer,
   '                                         cobrador As Entidades.OrigenFK,
   '                                         grupoCategoria As String) As DataTable

   '   Dim sql As SqlServer.CuentasCorrientesPagos
   '   Dim dt As DataTable

   '   Dim blnCalcularPromedios As Boolean = Reglas.Publicos.CtaCte.CtaCteClientesCalcularPromedios

   '   Try
   '      Me.da.OpenConection()

   '      sql = New SqlServer.CuentasCorrientesPagos(da)

   '      dt = sql.GetSaldosPorVencimientos(sucursales,
   '                                 fechaHasta,
   '                                 IdVendedor,
   '                                 idCliente,
   '                                 idZonaGeografica,
   '                                 excluirSaldosNegativos,
   '                                 idCategoria,
   '                                 grabaLibro,
   '                                 grupo,
   '                                 excluirAnticipos,
   '                                 blnCalcularPromedios,
   '                                 excluirPreComprobantes,
   '                                 idProvincia, categoria,
   '                                 usaClienteCtaCte,
   '                                 idEstadoCliente,
   '                                 idCobrador, cobrador,
   '                                 actual.NivelAutorizacion,
   '                                 grupoCategoria)

   '      Return dt
   '   Finally
   '      Me.da.CloseConection()
   '   End Try
   'End Function
   Public Function GetSaldosPorVencimientos(sucursales As Entidades.Sucursal(), fechaCalculo As Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme,
                                            idCliente As Long, usaClienteCtaCte As Boolean, idVendedor As Integer,
                                            idCategoria As Integer, origenCategoria As Entidades.OrigenFK, grupoCategoria As String,
                                            idCobrador As Integer, origenCobrador As Entidades.OrigenFK,
                                            idZonaGeografica As String, grabaLibro As Entidades.Publicos.SiNoTodos, grupo As String,
                                            idProvincia As String, idEstadoCliente As Integer,
                                            rangosDias As Entidades.CuentaCorrienteAntiguedadSaldoConfig, sinRegistros As Boolean,
                                            excluirAnticipos As Entidades.Publicos.SiNo, excluirPreComprobantes As Entidades.Publicos.SiNo, excluirSaldosNegativos As Entidades.Publicos.SiNo) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.CuentasCorrientesPagos(da)
            Return sql.GetSaldosPorVencimientos(
                                           sucursales, fechaCalculo,
                                           idCliente, usaClienteCtaCte, idVendedor,
                                           idCategoria, origenCategoria, grupoCategoria,
                                           idCobrador, origenCobrador,
                                           idZonaGeografica, grabaLibro, grupo,
                                           idProvincia, idEstadoCliente,
                                           rangosDias, sinRegistros,
                                           excluirAnticipos, excluirPreComprobantes, excluirSaldosNegativos,
                                           Publicos.CtaCte.CtaCteClientesCalcularPromedios, actual.NivelAutorizacion)
         End Function)
   End Function

   Public Function GetDetalle(sucursales As Entidades.Sucursal(),
                              desde As Date,
                              hasta As Date,
                              IdVendedor As Integer,
                              idCliente As Long,
                              listaComprobantes As List(Of Entidades.TipoComprobante),
                              tipoSaldo As String,
                              vencimiento As String,
                              idZonaGeografica As String,
                              IdCategoria As Integer,
                              grabaLibro As String,
                              grupos As Entidades.Grupo(),
                              excluirSaldosNegativos As String,
                              excluirAnticipos As String,
                              excluirPreComprobantes As String,
                              idProvincia As String,
                              categoria As Entidades.OrigenFK,
                              vendedor As Entidades.OrigenFK,
                              cliente As Entidades.Cliente.ClienteVinculado,
                              excluirMinutas As String,
                              agrupaClienteCuentaCorriente As Boolean,
                              idCobrador As Integer,
                              cobrador As Entidades.OrigenFK,
                              fechaInteres As Date,
                              idMoneda As Integer,
                              tipoConversion As Entidades.Moneda_TipoConversion,
                              cotizDolar As Decimal,
                              grupoCategoria As String,
                              idFormaDePago As Integer,
                              IdEmbarcacion As Long,
                              idLocalidad As Integer,
                              muestraDetalle As Boolean,
                              idCama As Long) As DataTable

      Return New SqlServer.CuentasCorrientesPagos(da).GetDetalle(sucursales,
                                                                 desde,
                                                                 hasta,
                                                                 IdVendedor,
                                                                 idCliente,
                                                                 listaComprobantes,
                                                                 tipoSaldo,
                                                                 vencimiento,
                                                                 idZonaGeografica,
                                                                 IdCategoria,
                                                                 grabaLibro,
                                                                 grupos,
                                                                 excluirSaldosNegativos,
                                                                 excluirAnticipos,
                                                                 excluirPreComprobantes,
                                                                 idProvincia,
                                                                 categoria,
                                                                 vendedor,
                                                                 cliente,
                                                                 excluirMinutas,
                                                                 agrupaClienteCuentaCorriente,
                                                                 idCobrador,
                                                                 cobrador,
                                                                 fechaInteres,
                                                                 idMoneda,
                                                                 tipoConversion,
                                                                 cotizDolar,
                                                                 actual.NivelAutorizacion,
                                                                 grupoCategoria,
                                                                 idFormaDePago,
                                                                 IdEmbarcacion,
                                                                 Publicos.CtaCteEmbarcacion,
                                                                 idLocalidad,
                                                                 muestraDetalle,
                                                                 idCama)
   End Function

   Public Function GetDetalleProximoPago(sucursales As Entidades.Sucursal(),
                                         desde As Date,
                                         hasta As Date?,
                                         IdVendedor As Integer,
                                         idCliente As Long,
                                         idTipoComprobante As String,
                                         saldo As String,
                                         vencimiento As String,
                                         idZonaGeografica As String,
                                         idCategoria As Integer,
                                         grabaLibro As String,
                                         grupo As String,
                                         excluirSaldosNegativos As String,
                                         excluirAnticipos As String,
                                         excluirPreComprobantes As String,
                                         idProvincia As String,
                                         categoria As String,
                                         vendedor As String,
                                         excluirMinutas As String,
                                         muestraDeudaAnterior As Boolean,
                                         agrupadoPorClienteCtaCte As Boolean,
                                         grupoCategoria As String) As DataTable

      Return New SqlServer.CuentasCorrientesPagos(da).GetDetalleProximoPago(sucursales,
                                                                            desde,
                                                                            hasta,
                                                                            IdVendedor,
                                                                            idCliente,
                                                                            idTipoComprobante,
                                                                            saldo,
                                                                            vencimiento,
                                                                            idZonaGeografica,
                                                                            idCategoria,
                                                                            grabaLibro,
                                                                            grupo,
                                                                            excluirSaldosNegativos,
                                                                            excluirAnticipos,
                                                                            excluirPreComprobantes,
                                                                            idProvincia,
                                                                            categoria,
                                                                            vendedor,
                                                                            excluirMinutas,
                                                                            muestraDeudaAnterior,
                                                                            agrupadoPorClienteCtaCte,
                                                                            grupoCategoria)

   End Function

   Public Function GetCobranzasDetalladas(idSucursal As Integer,
                                          desde As Date, hasta As Date,
                                          vendedor As String,
                                          idVendedor As Integer,
                                          idCliente As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("Select CCP.IdSucursal ")
         .AppendLine("      ,CCP.Fecha ")
         .AppendLine("      ,CCP.IdTipoComprobante ")
         .AppendLine("      ,CCP.Letra ")
         .AppendLine("      ,CCP.CentroEmisor ")
         .AppendLine("      ,CCP.NumeroComprobante ")
         .AppendLine("      ,CCP.IdTipoComprobante2 ")
         .AppendLine("      ,CCP.Letra2 ")
         .AppendLine("      ,CCP.CentroEmisor2 ")
         .AppendLine("      ,CCP.NumeroComprobante2 ")
         .AppendLine("      ,CCP.CuotaNumero2 ")
         .AppendLine("      ,CCP.ImporteCuota * (-1) As ImporteCuota ")
         .AppendLine("      ,CC.IdCliente ")
         .AppendLine("      ,C.CodigoCliente ")
         .AppendLine("      ,C.NombreCliente ")
         .AppendLine("      ,CC.IdVendedor ")
         .AppendLine("      ,E1.NombreEmpleado As NombreVendedor ")
         .AppendLine("      ,C.IdVendedor As IdVendedorClie ")
         .AppendLine("      ,E2.NombreEmpleado As NombreVendedorClie ")
         .AppendLine("   FROM CuentasCorrientesPagos CCP ")
         .AppendLine("  LEFT JOIN Ventas V On CCP.IdSucursal = V.IdSucursal  ")
         .AppendLine("                              And CCP.IdTipoComprobante2 = V.IdTipoComprobante ")
         .AppendLine("                              And CCP.Letra2 = V.Letra ")
         .AppendLine("                              And CCP.CentroEmisor2 = V.CentroEmisor ")
         .AppendLine("                              And CCP.NumeroComprobante2 = V.NumeroComprobante ")
         .AppendLine("  INNER JOIN CuentasCorrientes CC On CCP.IdSucursal = CC.IdSucursal ")
         .AppendLine("                                 And CCP.IdTipoComprobante = CC.IdTipoComprobante ")
         .AppendLine("                                 And CCP.Letra = CC.Letra  ")
         .AppendLine("                                 And CCP.CentroEmisor = CC.CentroEmisor ")
         .AppendLine("                                 And CCP.NumeroComprobante = CC.NumeroComprobante ")
         .AppendLine("  INNER JOIN Empleados E1 On CC.IdVendedor = E1.IdEmpleado ")
         .AppendLine("  INNER JOIN Clientes C On CC.IdCliente = C.IdCliente ")
         .AppendLine("  INNER JOIN Empleados E2 On C.IdVendedor = E2.IdEmpleado ")
         .AppendLine("  INNER JOIN CategoriasFiscales CF On C.IdCategoriaFiscal = CF.IdCategoriaFiscal ")
         .AppendLine(" INNER JOIN TiposComprobantes tp On CCP.IdTipoComprobante = tp.IdTipoComprobante")

         .AppendLine("  WHERE tp.EsRecibo = 'True' AND tp.EsAnticipo = 'True'")
         .AppendLine("   AND CCP.IdSucursal = " & idSucursal.ToString())
         .AppendLine("	 AND CONVERT(varchar(11), CCP.fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("	 AND CONVERT(varchar(11), CCP.fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")

         If idVendedor > 0 Then
            If vendedor = "MOVIMIENTO" Then
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND C.IdVendedor = '" & idVendedor)
            End If
         End If

         If idCliente > 0 Then
            .AppendLine("	AND CC.IdCliente = " & idCliente.ToString())
         End If

         .AppendLine(" ORDER BY CCP.IdSucursal ")
         If vendedor = "MOVIMIENTO" Then
            .AppendLine("         ,E1.NombreEmpleado")
            .AppendLine("         ,CC.IdVendedor ")

         Else
            .AppendLine("         ,E2.NombreEmpleado")
            .AppendLine("         ,C.IdVendedor ")

         End If
         .AppendLine("         ,CCP.Fecha ")

      End With

      Return da.GetDataTable(stb.ToString())
   End Function

   Public Function GetUna(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          numeroComprobante As Long,
                          cuotaNumero As Integer) As Entidades.CuentaCorrientePago
      Dim sql As SqlServer.CuentasCorrientesPagos = New SqlServer.CuentasCorrientesPagos(da)
      Dim dt As DataTable = sql.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, cuotaNumero)
      Dim o As Entidades.CuentaCorrientePago = New Entidades.CuentaCorrientePago()
      For Each dr As DataRow In dt.Rows
         Me.CargarUna(dr, o)
      Next
      Return o

   End Function

   Public Function GetPagos(idSucursal As Integer, periodo As Integer, tipo As Entidades.Liquidacion.TipoLiquidacion?) As DataTable
      Return New SqlServer.CuentasCorrientesPagos(da).GetPagos(idSucursal, periodo, tipo)
   End Function

   Public Function GetRecibosDeUnComprobante(idSucursal As Integer,
                                             idTipoComprobante As String,
                                             letra As String,
                                             centroEmisor As Short,
                                             numeroComprobante As Long,
                                             cuotaNumero As Integer?) As DataTable
      Return New SqlServer.CuentasCorrientesPagos(da).GetRecibosDeUnComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, cuotaNumero)
   End Function

   Public Function GetInfoParaPagoQR(idEmpresa As Integer,
                                     codigoCliente As Long,
                                     idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Short,
                                     numeroComprobante As Long,
                                     cuotaNumero As Integer,
                                     fechaVen1 As Date,
                                     importeVen1 As Decimal,
                                     fechaVen2 As Date?,
                                     importeVen2 As Decimal?,
                                     fechaVen3 As Date?,
                                     importeVen3 As Decimal?) As String

      Dim fechaVencimiento1 As String = fechaVen1.ToString("yyyy-MM-dd")
      Dim fechaVencimiento2 As String = Nothing
      Dim fechaVencimiento3 As String = Nothing
      Dim importeVencimiento2 As Decimal? = Nothing
      Dim importeVencimiento3 As Decimal? = Nothing

      ' # Si utiliza Fecha de Vencimiento 2
      fechaVencimiento2 = If(fechaVen2.HasValue, fechaVen2.Value.ToString("yyyy-MM-dd"), Nothing)
      importeVencimiento2 = If(importeVen2.HasValue, importeVen2.Value, Nothing)

      ' # Si utiliza Fecha de Vencimiento 3
      fechaVencimiento3 = If(fechaVen3.HasValue, fechaVen3.Value.ToString("yyyy-MM-dd"), Nothing)
      importeVencimiento3 = If(importeVen3.HasValue, importeVen3.Value, Nothing)

      Dim info = New With {.idEmpresa = idEmpresa,
                           .codigoCliente = codigoCliente,
                           .idSucursal = idSucursal,
                           .idTipoComprobante = idTipoComprobante,
                           .letra = letra,
                           .centroEmisor = centroEmisor,
                           .numeroComprobante = numeroComprobante,
                           .cuotaNumero = cuotaNumero,
                           .fechaVencimiento1 = fechaVencimiento1,
                           .importeVencimiento1 = importeVen1,
                           .fechaVencimiento2 = fechaVencimiento2,
                           .importeVencimiento2 = importeVencimiento2,
                           .fechaVencimiento3 = fechaVencimiento3,
                           .importeVencimiento3 = importeVencimiento3}

      Return New Web.Script.Serialization.JavaScriptSerializer().Serialize(info)
   End Function

   Public Function CalculaCuotasSegunFormaPago(ctaCte As Entidades.CuentaCorriente, decimales As Integer) As List(Of Entidades.CuentaCorrientePago)
      Return CalculaCuotasSegunFormaPago(ctaCte, Function(v) Decimal.Round(v, decimales), AccionDiferenciaRedondeo.AgregarAUltimaCuota)
   End Function

   Public Enum AccionDiferenciaRedondeo
      AgregarAPrimerCuota
      AgregarAUltimaCuota
      Excepcion
      Ignorar
   End Enum

   Private Function CalculaCuotasSegunFormaPago(ctaCte As Entidades.CuentaCorriente,
                                                metodoRedondeo As Func(Of Decimal, Decimal),
                                                accionRedondeo As AccionDiferenciaRedondeo) As List(Of Entidades.CuentaCorrientePago)
      If ctaCte Is Nothing Then Throw New ArgumentNullException(NameOf(ctaCte))
      If ctaCte.Pagos Is Nothing Then Throw New ArgumentNullException(NameOf(ctaCte.Pagos))
      If ctaCte.FormaPago Is Nothing Then Throw New ArgumentNullException(NameOf(ctaCte.FormaPago))

      Dim result = New List(Of Entidades.CuentaCorrientePago)()

      If ctaCte.FormaPago.CantidadCuotas = 0 Then
         Throw New Exception(String.Format("La forma de pago {0} tiene configurado Cantidad de cuotas en cero. No es posible calcular cuotas.", ctaCte.FormaPago.DescripcionFormasPago))
      End If
      Dim importeCuota = metodoRedondeo(ctaCte.ImporteTotal / ctaCte.FormaPago.CantidadCuotas)

      For i = 1 To ctaCte.FormaPago.CantidadCuotas
         Dim ccp = New Entidades.CuentaCorrientePago With {
            .Cuota = i,
            .ImporteCuota = importeCuota,
            .SaldoCuota = importeCuota,
            .FechaVencimiento = ctaCte.Fecha.Date.AddDays(ctaCte.FormaPago.DiasPrimerCuota +
                                                          (ctaCte.FormaPago.Dias * Math.Max(i - 1, 0)))
         }
         result.Add(ccp)
      Next

      If accionRedondeo <> AccionDiferenciaRedondeo.Ignorar Then
         If result.Any() Then
            Dim totalCuotas = result.Sum(Function(p) p.ImporteCuota)
            Dim resto = ctaCte.ImporteTotal - totalCuotas
            If resto <> 0 Then
               If accionRedondeo = AccionDiferenciaRedondeo.Excepcion Then
                  Throw New Exception(String.Format("El calculo de cuotas dio un error de redondeo de {0}. El importe a cuenta corriente es de {1} siendo el total de cuotas de {2} ({3} cada una)",
                                                    resto, ctaCte.ImporteTotal, totalCuotas, importeCuota))
               End If
               Dim ajuste = If(accionRedondeo = AccionDiferenciaRedondeo.AgregarAPrimerCuota,
                               result.First(), result.Last())
               ajuste.ImporteCuota += resto
               ajuste.SaldoCuota += resto
            End If
         End If
      End If
      Return result
   End Function

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entd As Eniac.Entidades.Entidad)
      Dim ent As Entidades.CuentaCorrientePago = DirectCast(entd, Entidades.CuentaCorrientePago)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.GrabaCuentaCorrientePagos(ent, ent.Cuota)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

   Public Sub ActualizarPagosComprobantes(ventaAnterior As Entidades.Venta, ventaNueva As Entidades.Venta)
      ActualizarPagosComprobantes(ventaAnterior.IdSucursal, ventaAnterior.IdTipoComprobante, ventaAnterior.LetraComprobante, ventaAnterior.CentroEmisor, ventaAnterior.NumeroComprobante,
                                  ventaNueva.IdSucursal, ventaNueva.IdTipoComprobante, ventaNueva.LetraComprobante, ventaNueva.CentroEmisor, ventaNueva.NumeroComprobante)
   End Sub

   Public Sub ActualizarPagosComprobantes(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                          idSucursalNuevo As Integer, idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Short, numeroComprobanteNuevo As Long)
      Dim sql = New SqlServer.CuentasCorrientesPagos(da)
      sql.ActualizarPagosComprobantes(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                      idSucursalNuevo, idTipoComprobanteNuevo, letraNuevo, centroEmisorNuevo, numeroComprobanteNuevo)
   End Sub
   Private Function CalculaLetra(letra As String) As Integer
      Select Case letra
         Case "A"
            Return 1
         Case "B"
            Return 2
         Case "X"
            Return 3
         Case "C"
            Return 4
         Case Else
            Return 5
      End Select
   End Function

   Public Sub ActualizaCodigoDeBarraSirplus(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      Dim sql = New SqlServer.CuentasCorrientesPagos(da)
      Using dt = sql.GetPorCuentaCorriente(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
         For Each dr In dt.AsEnumerable()
            Dim NroLetra = CalculaLetra(letra) * 10000000000
            Dim identificacion = Long.Parse(NroLetra + dr.Field(Of Long)(Entidades.CuentaCorrientePago.Columnas.NumeroComprobante.ToString()) &
                                            dr.Field(Of Integer)(Entidades.CuentaCorrientePago.Columnas.CuotaNumero.ToString()))
            Dim codigoDeBarraSirplus = Banco.DebitosDirectos.SIRPLUS.ArmarCodigoBarras(
                                             identificacion,
                                             Publicos.TurismoRoelaIdentificadorConcepto,
                                             dr.Field(Of Date)(Entidades.CuentaCorrientePago.Columnas.FechaVencimiento.ToString()),
                                             dr.Field(Of Decimal)(Entidades.CuentaCorrientePago.Columnas.ImporteCuota.ToString()),
                                             dr.Field(Of Date?)(Entidades.CuentaCorrientePago.Columnas.FechaVencimiento2.ToString()),
                                             dr.Field(Of Decimal?)("ImporteVencimiento2"),
                                             dr.Field(Of Date?)(Entidades.CuentaCorrientePago.Columnas.FechaVencimiento3.ToString()),
                                             dr.Field(Of Decimal?)("ImporteVencimiento3"),
                                             Publicos.TurismoSIRPLUSIdentifCuenta)
            sql.ActualizaCodigoDeBarraSirplus(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                              dr.Field(Of Integer)(Entidades.CuentaCorrientePago.Columnas.CuotaNumero.ToString()),
                                              codigoDeBarraSirplus)
         Next
      End Using
   End Sub
   Public Class GetInformeSituacionCrediticiaPivotInfo
      Public Property dtColumnas As DataTable
      Public Property dtResult As DataTable
   End Class
End Class