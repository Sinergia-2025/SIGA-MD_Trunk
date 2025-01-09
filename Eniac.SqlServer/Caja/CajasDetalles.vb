Public Class CajasDetalles
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function CajaMovimientos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .Append("SELECT *")
         .Append("  FROM CajasDetalle ")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Sub CajaDetalles_I(idSucursal As Integer,
                             idCaja As Integer,
                             numeroPlanilla As Integer,
                             numeroMovimiento As Integer,
                             idCuentaCaja As Integer,
                             idTipoMovimiento As String,
                             fechaMovimiento As Date,
                             observacion As String,
                             importePesos As Double,
                             importeDolares As Double,
                             importeTickets As Double,
                             importeCheques As Double,
                             importeTarjetas As Double,
                             importeBancos As Double,
                             importeRetenciones As Double,
                             esModificable As Boolean,
                             idUsuario As String,
                             idCentroCosto As Integer?,
                             generaContabilidad As Boolean,
                             cotizacionDolar As Decimal,
                             idTipoComprobante As String,
                             numeroDeposito As Long?,
                             idMonedaImporteBancos As Integer?,
                             idConceptoCM05 As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("   INSERT INTO CajasDetalle ")
         .AppendLine("       (IdSucursal ")
         .AppendLine("       ,IdCaja ")
         .AppendLine("       ,NumeroPlanilla ")
         .AppendLine("       ,NumeroMovimiento ")
         .AppendLine("       ,IdCuentaCaja ")
         .AppendLine("       ,IdTipoMovimiento  ")
         .AppendLine("       ,FechaMovimiento  ")
         .AppendLine("       ,Observacion ")
         .AppendLine("       ,ImportePesos ")
         .AppendLine("       ,ImporteDolares ")
         .AppendLine("       ,ImporteTickets ")
         .AppendLine("       ,ImporteCheques ")
         .AppendLine("       ,importeTarjetas ")
         .AppendLine("       ,importeEuros ")
         .AppendLine("       ,importeBancos ")
         .AppendLine("       ,importeRetenciones ")
         .AppendLine("       ,esModificable ")
         .AppendLine("       ,IdUsuario ")
         .AppendLine("       ,IdCentroCosto ")
         .AppendLine("       ,GeneraContabilidad")
         .AppendLine("       ,CotizacionDolar")
         .AppendFormatLine("       ,{0}", Entidades.CajaDetalles.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("       ,{0}", Entidades.CajaDetalles.Columnas.NumeroDeposito.ToString())
         .AppendFormatLine("       ,{0}", Entidades.CajaDetalles.Columnas.IdMonedaImporteBancos.ToString())
         .AppendFormatLine("       ,{0}", Entidades.CajaDetalles.Columnas.IdConceptoCM05.ToString())
         .AppendLine("   ) Values ")
         .AppendLine("       (" & idSucursal.ToString())
         .AppendLine("       ," & idCaja.ToString())
         .AppendLine("       ," & numeroPlanilla.ToString())
         .AppendLine("       ," & numeroMovimiento.ToString())
         .AppendLine("       ," & idCuentaCaja.ToString())
         .AppendLine("       ,'" & idTipoMovimiento & "'")
         .AppendLine("       ,'" & Me.ObtenerFecha(fechaMovimiento, True) & "'")
         .AppendLine("       ,'" & observacion & "'")
         .AppendLine("       ," & importePesos.ToString())
         .AppendLine("       ," & importeDolares.ToString())
         .AppendLine("       ," & importeTickets.ToString())
         .AppendLine("       ," & importeCheques.ToString())
         .AppendLine("       ," & importeTarjetas.ToString())
         .AppendLine("       ,0")
         .AppendLine("       ," & importeBancos.ToString())
         .AppendLine("       ," & importeRetenciones.ToString())
         .AppendLine("       , " & GetStringFromBoolean(esModificable))
         .AppendLine("       ,'" & idUsuario & "'")
         If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
            .AppendLine("       ," & idCentroCosto.Value.ToString())
         Else
            .AppendLine("       ,NULL")
         End If
         .AppendFormatLine("       ,{0}", GetStringFromBoolean(generaContabilidad))
         .AppendFormatLine("       ,{0}", cotizacionDolar)

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("       ,'{0}'", idTipoComprobante)
         Else
            .AppendLine("    , NULL")
         End If
         If numeroDeposito.HasValue Then
            .AppendFormatLine("       ,{0}", numeroDeposito.Value)
         Else
            .AppendLine("    , NULL")
         End If
         .AppendFormatLine("       ,{0}", GetStringFromNumber(idMonedaImporteBancos.IfNull()))
         .AppendFormatLine("       ,{0}", GetStringFromNumber(idConceptoCM05))
         .Append(")")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CajasDetalle")
   End Sub

   Public Sub CajaDetalles_U(idSucursal As Integer,
                             idCaja As Integer,
                             numeroPlanilla As Integer,
                             numeroMovimiento As Integer,
                             idCuentaCaja As Integer,
                             idTipoMovimiento As String,
                             fechaMovimiento As Date,
                             observacion As String,
                             importePesos As Double,
                             importeDolares As Double,
                             importeTickets As Double,
                             importeCheques As Double,
                             importeTarjetas As Double,
                             importeBancos As Double,
                             importeRetenciones As Double,
                             idUsuario As String,
                             idCentroCosto As Integer?,
                             cotizacionDolar As Decimal,
                             idTipoComprobante As String,
                             numeroDeposito As Long?,
                             idMonedaImporteBancos As Integer?,
                             idConceptoCM05 As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .Length = 0
         .AppendLine("UPDATE CajasDetalle ")
         .AppendLine("   SET IdCuentaCaja = " & idCuentaCaja.ToString())
         .AppendLine("      ,IdTipoMovimiento = '" & idTipoMovimiento.ToString() & "'")
         .AppendLine("      ,Observacion = '" & observacion & "'")
         .AppendLine("      ,ImportePesos = " & importePesos.ToString())
         .AppendLine("      ,ImporteDolares = " & importeDolares.ToString())
         .AppendLine("      ,ImporteTickets =  " & importeTickets.ToString())
         .AppendLine("      ,ImporteCheques = " & importeCheques.ToString())
         .AppendLine("      ,ImporteTarjetas = " & importeTarjetas.ToString())
         .AppendLine("      ,ImporteEuros = 0")
         .AppendLine("      ,ImporteBancos = " & importeBancos.ToString())
         .AppendLine("      ,ImporteRetenciones = " & importeRetenciones.ToString())
         .AppendLine("      ,FechaMovimiento = '" & Me.ObtenerFecha(fechaMovimiento, True) & "'")
         .AppendLine("      ,IdUsuario = '" & idUsuario & "'")
         '.Append("	    EsModificable = " & Me.GetStringFromBoolean(esModificable) & " ")

         If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
            .AppendLine("      ,IdCentroCosto = " & idCentroCosto.Value.ToString())
         Else
            .AppendLine("      ,IdCentroCosto = NULL")
         End If
         .AppendFormatLine("      ,CotizacionDolar = {0}", cotizacionDolar)

         '#Tipo de Comprobante y Nro de Deposito
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("      ,{0} = '{1}'", Entidades.CajaDetalles.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         Else
            .AppendFormatLine("      ,{0} = NULL", Entidades.CajaDetalles.Columnas.IdTipoComprobante.ToString())
         End If
         If numeroDeposito.HasValue Then
            If numeroDeposito.Value > 0 Then
               .AppendFormatLine("      ,{0} = {1}", Entidades.CajaDetalles.Columnas.NumeroDeposito.ToString(), numeroDeposito.Value)
            Else
               .AppendFormatLine("      ,{0} = NULL", Entidades.CajaDetalles.Columnas.NumeroDeposito.ToString())
            End If
         End If
         '--REQ-33939.- Se quitan las comillas de la sentencia por si viene NULL.- -------------------------------------------------------------------------- 
         .AppendFormatLine("      ,{0} = {1}", Entidades.CajaDetalles.Columnas.IdMonedaImporteBancos.ToString(), GetStringFromNumber(idMonedaImporteBancos.IfNull()))
         '---------------------------------------------------------------------------------------------------------------------------------------------------
         .AppendFormatLine("      ,{0} = {1}", Entidades.CajaDetalles.Columnas.IdConceptoCM05.ToString(), GetStringFromNumber(idConceptoCM05))

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString() & " ")
         .AppendLine("   AND IdCaja =  " & idCaja.ToString())
         .AppendLine("   AND NumeroPlanilla = " & numeroPlanilla.ToString() & " ")
         .AppendLine("   AND NumeroMovimiento = " & numeroMovimiento.ToString() & " ")

         'Quito el WHERE Del Usuario porque falla al actualizar Ventas y si alguien le ajusta el movimiento a otro (y lo paso al update).
         '.AppendFormat("   AND IdUsuario = '{0}'", idUsuario)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CajasDetalle")
   End Sub

   Public Sub CajaDetalles_D(idSucursal As Integer,
                             idCaja As Integer,
                             numeroPlanilla As Integer,
                             numeroMovimiento As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM CajasDetalle ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal)
         .AppendLine("   AND NumeroPlanilla = " & numeroPlanilla)
         .AppendLine("   AND IdCaja = " & idCaja.ToString())
         .AppendLine("   AND NumeroMovimiento = " & numeroMovimiento)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CajasDetalle")
   End Sub

   Public Function GetUltimoMovimientoDeVentas(idSucursal As Integer,
                                               idCaja As Integer,
                                               numeroPlanilla As Integer,
                                               idCuentaCaja As Integer,
                                               fecha As Date) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT * FROM CajasDetalle ")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND IdCaja = {0}", idCaja)
         .AppendFormat("   AND NumeroPlanilla = {0}", numeroPlanilla)
         .AppendFormat("   AND IdCuentaCaja = {0}", idCuentaCaja)
         .AppendFormat("   AND CONVERT(varchar(11), FechaMovimiento, 120) = '{0}'", fecha.ToString("yyyy-MM-dd"))
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetSaldosIniciales(buscar As Entidades.Buscar,
                                      sucursales As Entidades.Sucursal(), cajas As Entidades.CajaNombre(),
                                      fechaDesde As Date, fechaConsulta As Entidades.CajaDetalles.FechaConsulta,
                                      idCuentaCaja As Integer, idGrupoCuenta As String,
                                      esModificable As Entidades.Publicos.SiNoTodos,
                                      nroPlanilla As Integer) As DataTable
      If buscar Is Nothing Then buscar = New Entidades.Buscar()
      Dim columna As String = String.Empty
      If Not String.IsNullOrWhiteSpace(buscar.Columna) Then
         Select Case buscar.Columna
            Case "NombreCuentaCaja"
               columna = "Cc." + buscar.Columna
            Case "IdGrupoCuenta"
               columna = "Cc." + buscar.Columna
            Case Else
               columna = "Cd." & buscar.Columna
         End Select
      End If            'If Not String.IsNullOrWhiteSpace(entidad.Columna) Then

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT SUM(Cd.ImportePesos) as SIImportePesos")
         .AppendLine("      ,SUM(Cd.ImporteCheques) as SIImporteCheques")
         .AppendLine("      ,SUM(Cd.ImporteTarjetas) as SIImporteTarjetas")
         .AppendLine("      ,SUM(Cd.ImporteDolares) as SIImporteDolares")
         .AppendLine("      ,SUM(Cd.ImporteRetenciones) as SIImporteRetenciones")
         .AppendLine("      ,SUM(Cd.ImporteBancos) as SIImporteBancos")
         .AppendLine("      ,SUM(Cd.ImporteTickets) as SIImporteTickets")
         .AppendLine("  FROM CajasDetalle Cd ")
         .AppendLine(" INNER JOIN CuentasDeCajas Cc ON Cd.IdCuentaCaja = Cc.IdCuentaCaja ")
         .AppendLine(" INNER JOIN Cajas C ON Cd.IdSucursal = C.IdSucursal AND cd.IdCaja = c.IdCaja AND Cd.NumeroPlanilla = C.NumeroPlanilla ")
         .AppendLine("  LEFT JOIN CajasNombres CN ON C.IdSucursal = CN.IdSucursal AND C.IdCaja = CN.IdCaja")
         .AppendLine(" WHERE 1 = 1")
         GetListaSucursalesMultiples(stbQuery, sucursales, "C")
         GetListaMultiples(stbQuery, cajas, "C")
         ''''If cajas.Count > 0 Then
         ''''   .Append(" AND (")
         ''''   For Each ca As Entidades.CajaNombre In cajas
         ''''      .AppendFormat(" (C.IdCaja = {0} AND C.IdSucursal = {1}) OR ", ca.IdCaja, ca.IdSucursal)
         ''''   Next
         ''''   .Append(" 1 = 0)")
         ''''End If

         ''''If esFechaMovimiento Then
         ''''   .AppendFormatLine("   AND CD.FechaMovimiento <= '{0}'", ObtenerFecha(fechaDesde.Date.AddSeconds(-1), True))
         ''''Else
         ''''   .AppendFormatLine("   AND C.FechaPlanilla <= '{0}'", ObtenerFecha(fechaDesde.Date.AddSeconds(-1), True))
         ''''End If

         If fechaConsulta = Entidades.CajaDetalles.FechaConsulta.Movimiento Then
            .AppendFormatLine("   AND CD.FechaMovimiento < '{0}'", ObtenerFecha(fechaDesde.Date.AddSeconds(-1), True))
         Else
            .AppendFormatLine("   AND C.FechaPlanilla < '{0}'", ObtenerFecha(fechaDesde.Date.AddSeconds(-1), True))
         End If


         If idCuentaCaja > 0 Then
            .AppendLine("   AND CD.IdCuentaCaja = " & idCuentaCaja.ToString())
         End If
         If Not String.IsNullOrEmpty(idGrupoCuenta) Then
            .AppendLine("   AND Cc.IdGrupoCuenta = '" & idGrupoCuenta & "'")
         End If
         If esModificable <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND CD.EsModificable = {0}", GetStringFromBoolean(esModificable = Entidades.Publicos.SiNoTodos.SI))
         End If
         If nroPlanilla > 0 Then
            .AppendLine("   AND CD.NumeroPlanilla = " & nroPlanilla)
         End If
         If Not String.IsNullOrWhiteSpace(columna) Then
            .AppendLine("     AND " & columna & " LIKE '%" & buscar.Valor.ToString() & "%'")
         End If            'If Not String.IsNullOrWhiteSpace(entidad.Columna) Then
      End With

      Return GetDataTable(stbQuery)
   End Function

   Public Function GetSaldos(buscar As Entidades.Buscar,
                             sucursales As Entidades.Sucursal(),
                             cajas As List(Of Entidades.CajaNombre),
                             fechaDesde As Date,
                             esFechaMovimiento As Boolean,
                             idCuentaCaja As Integer,
                             idGrupoCuenta As String,
                             esModificable As String,
                             nroPlanilla As Integer) As DataTable

      If buscar Is Nothing Then buscar = New Entidades.Buscar()
      Dim columna As String = String.Empty
      If Not String.IsNullOrWhiteSpace(buscar.Columna) Then
         Select Case buscar.Columna
            Case "NombreCuentaCaja"
               columna = "Cc." + buscar.Columna
            Case "IdGrupoCuenta"
               columna = "Cc." + buscar.Columna
            Case Else
               columna = "Cd." & buscar.Columna
         End Select
      End If            'If Not String.IsNullOrWhiteSpace(entidad.Columna) Then

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine(" SELECT SUM(SIImportePesos) AS SIImportePesos")
         .AppendLine("       ,SUM(SIImporteCheques) AS SIImporteCheques")
         .AppendLine("       ,SUM(SIImporteTarjetas) AS SIImporteTarjetas")
         .AppendLine("       ,SUM(SIImporteDolares) AS SIImporteDolares")
         .AppendLine("       ,SUM(SIImporteRetenciones) AS SIImporteRetenciones")
         .AppendLine("       ,SUM(SIImporteBancos) AS SIImporteBancos")
         .AppendLine("       ,SUM(SIImporteTickets) AS SIImporteTickets")
         .AppendLine("       ,SUM(SEImportePesos) AS SEImportePesos")
         .AppendLine("       ,SUM(SEImporteCheques) AS SEImporteCheques")
         .AppendLine("       ,SUM(SEImporteTarjetas) AS SEImporteTarjetas")
         .AppendLine("       ,SUM(SEImporteDolares) AS SEImporteDolares")
         .AppendLine("       ,SUM(SEImporteRetenciones) AS SEImporteRetenciones")
         .AppendLine("       ,SUM(SEImporteBancos) AS SEImporteBancos")
         .AppendLine("       ,SUM(SEImporteTickets) AS SEImporteTickets")
         .AppendLine(" FROM (")
         .AppendLine("SELECT SUM(Cd.ImportePesos) as SIImportePesos")
         .AppendLine("      ,SUM(Cd.ImporteCheques) as SIImporteCheques")
         .AppendLine("      ,SUM(Cd.ImporteTarjetas) as SIImporteTarjetas")
         .AppendLine("      ,SUM(Cd.ImporteDolares) as SIImporteDolares")
         .AppendLine("      ,SUM(Cd.ImporteRetenciones) as SIImporteRetenciones")
         .AppendLine("      ,SUM(Cd.ImporteBancos) as SIImporteBancos")
         .AppendLine("      ,SUM(Cd.ImporteTickets) as SIImporteTickets")
         .AppendLine("      ,0 as SEImportePesos")
         .AppendLine("      ,0 as SEImporteCheques")
         .AppendLine("      ,0 as SEImporteTarjetas")
         .AppendLine("      ,0 as SEImporteDolares")
         .AppendLine("      ,0 as SEImporteRetenciones")
         .AppendLine("      ,0 as SEImporteBancos")
         .AppendLine("      ,0 as SEImporteTickets")
         .AppendLine("  FROM CajasDetalle Cd ")
         .AppendLine("     INNER JOIN CuentasDeCajas Cc ON Cd.IdCuentaCaja = Cc.IdCuentaCaja ")
         .AppendLine("     INNER JOIN Cajas C ON Cd.IdSucursal = C.IdSucursal AND cd.IdCaja = c.IdCaja AND Cd.NumeroPlanilla = C.NumeroPlanilla ")
         .AppendLine("     LEFT JOIN CajasNombres CN ON C.IdSucursal = CN.IdSucursal AND C.IdCaja = CN.IdCaja")
         .AppendLine(" WHERE 1 = 1")
         GetListaSucursalesMultiples(stbQuery, sucursales, "C")

         If cajas.Count > 0 Then
            .Append(" AND (")
            For Each ca As Entidades.CajaNombre In cajas
               .AppendFormat(" (C.IdCaja = {0} AND C.IdSucursal = {1}) OR ", ca.IdCaja, ca.IdSucursal)
            Next
            .Append(" 1 = 0)")
         End If
         If esFechaMovimiento Then
            .AppendLine("   AND CD.FechaMovimiento <= '" & fechaDesde.ToString("yyyyMMdd") & " 23:59:59'")
         Else
            .AppendLine("   AND C.FechaPlanilla <= '" & fechaDesde.ToString("yyyyMMdd") & " 23:59:59'")
         End If
         If idCuentaCaja > 0 Then
            .AppendLine("   AND CD.IdCuentaCaja = " & idCuentaCaja.ToString())
         End If
         If Not String.IsNullOrEmpty(idGrupoCuenta) Then
            .AppendLine("   AND Cc.IdGrupoCuenta = '" & idGrupoCuenta & "'")
         End If
         If esModificable <> "TODOS" Then
            .AppendLine("      AND CD.EsModificable = " & IIf(esModificable = "SI", "1", "0").ToString())
         End If
         If nroPlanilla > 0 Then
            .AppendLine("   AND CD.NumeroPlanilla = " & nroPlanilla)
         End If
         If Not String.IsNullOrWhiteSpace(columna) Then
            .AppendLine("     AND " & columna & " LIKE '%" & buscar.Valor.ToString() & "%'")
         End If
         .AppendLine("     AND CD.IdTipoMovimiento = 'I'")
         .AppendLine(" UNION")
         .AppendLine("       SELECT 0 as SIImportePesos")
         .AppendLine("       ,0 as SIImporteCheques")
         .AppendLine("       ,0 as SIImporteTarjetas")
         .AppendLine("       ,0 as SIImporteDolares")
         .AppendLine("       ,0 as SIImporteRetenciones")
         .AppendLine("       ,0 as SIImporteBancos")
         .AppendLine("       ,0 as SIImporteTickets")
         .AppendLine("       ,SUM(Cd.ImportePesos) as SEImportePesos")
         .AppendLine("       ,SUM(Cd.ImporteCheques) as SEImporteCheques")
         .AppendLine("       ,SUM(Cd.ImporteTarjetas) as SEImporteTarjetas")
         .AppendLine("       ,SUM(Cd.ImporteDolares) as SEImporteDolares")
         .AppendLine("       ,SUM(Cd.ImporteRetenciones) as SEImporteRetenciones")
         .AppendLine("       ,SUM(Cd.ImporteBancos)  as SEImporteBancos")
         .AppendLine("       ,SUM(Cd.ImporteTickets)  as SEImporteTickets")
         .AppendLine("  FROM CajasDetalle Cd ")
         .AppendLine("     INNER JOIN CuentasDeCajas Cc ON Cd.IdCuentaCaja = Cc.IdCuentaCaja ")
         .AppendLine("     INNER JOIN Cajas C ON Cd.IdSucursal = C.IdSucursal AND cd.IdCaja = c.IdCaja AND Cd.NumeroPlanilla = C.NumeroPlanilla ")
         .AppendLine("     LEFT JOIN CajasNombres CN ON C.IdSucursal = CN.IdSucursal AND C.IdCaja = CN.IdCaja")
         .AppendLine(" WHERE 1 = 1")
         GetListaSucursalesMultiples(stbQuery, sucursales, "C")

         If cajas.Count > 0 Then
            .Append(" AND (")
            For Each ca As Entidades.CajaNombre In cajas
               .AppendFormat(" (C.IdCaja = {0} AND C.IdSucursal = {1}) OR ", ca.IdCaja, ca.IdSucursal)
            Next
            .Append(" 1 = 0)")
         End If
         If esFechaMovimiento Then
            .AppendLine("   AND CD.FechaMovimiento <= '" & fechaDesde.ToString("yyyyMMdd") & " 23:59:59'")
         Else
            .AppendLine("   AND C.FechaPlanilla <= '" & fechaDesde.ToString("yyyyMMdd") & " 23:59:59'")
         End If
         If idCuentaCaja > 0 Then
            .AppendLine("   AND CD.IdCuentaCaja = " & idCuentaCaja.ToString())
         End If
         If Not String.IsNullOrEmpty(idGrupoCuenta) Then
            .AppendLine("   AND Cc.IdGrupoCuenta = '" & idGrupoCuenta & "'")
         End If
         If esModificable <> "TODOS" Then
            .AppendLine("      AND CD.EsModificable = " & IIf(esModificable = "SI", "1", "0").ToString())
         End If
         If nroPlanilla > 0 Then
            .AppendLine("   AND CD.NumeroPlanilla = " & nroPlanilla)
         End If
         If Not String.IsNullOrWhiteSpace(columna) Then
            .AppendLine("     AND " & columna & " LIKE '%" & buscar.Valor.ToString() & "%'")
         End If
         .AppendLine("     AND CD.IdTipoMovimiento = 'E'")

         .AppendLine("   ) AS Tbl")

      End With

      Return GetDataTable(stbQuery)

   End Function


   Public Function GetSaldosFinales(buscar As Entidades.Buscar,
                                    sucursales As Entidades.Sucursal(),
                                    cajas As List(Of Entidades.CajaNombre),
                                    fechaHasta As Date,
                                    esFechaMovimiento As Boolean,
                                    idCuentaCaja As Integer,
                                    idGrupoCuenta As String,
                                    esModificable As String,
                                    nroPlanilla As Integer) As DataTable
      If buscar Is Nothing Then buscar = New Entidades.Buscar()
      Dim columna As String = String.Empty
      If Not String.IsNullOrWhiteSpace(buscar.Columna) Then
         Select Case buscar.Columna
            Case "NombreCuentaCaja"
               columna = "Cc." + buscar.Columna
            Case "IdGrupoCuenta"
               columna = "Cc." + buscar.Columna
            Case Else
               columna = "Cd." & buscar.Columna
         End Select
      End If            'If Not String.IsNullOrWhiteSpace(entidad.Columna) Then

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT SUM(Cd.ImportePesos) as SFImportePesos")
         .AppendLine("      ,SUM(Cd.ImporteCheques) as SFImporteCheques")
         .AppendLine("      ,SUM(Cd.ImporteTarjetas) as SFImporteTarjetas")
         .AppendLine("      ,SUM(Cd.ImporteDolares) as SFImporteDolares")
         .AppendLine("      ,SUM(Cd.ImporteRetenciones) as SFImporteRetenciones")
         .AppendLine("      ,SUM(Cd.ImporteBancos) as SFImporteBancos")
         .AppendLine("      ,SUM(Cd.ImporteTickets) as SFImporteTickets")
         .AppendLine("  FROM CajasDetalle Cd ")
         .AppendLine(" INNER JOIN CuentasDeCajas Cc ON Cd.IdCuentaCaja = Cc.IdCuentaCaja ")
         .AppendLine(" INNER JOIN Cajas C ON Cd.IdSucursal = C.IdSucursal AND cd.IdCaja = c.IdCaja AND Cd.NumeroPlanilla = C.NumeroPlanilla ")
         .AppendLine("  LEFT JOIN CajasNombres CN ON C.IdSucursal = CN.IdSucursal AND C.IdCaja = CN.IdCaja")
         .AppendLine("  WHERE 1 = 1")
         GetListaSucursalesMultiples(stbQuery, sucursales, "C")

         If cajas.Count > 0 Then
            .Append(" AND (")
            For Each ca As Entidades.CajaNombre In cajas
               .AppendFormat(" (C.IdCaja = {0} AND C.IdSucursal = {1}) OR ", ca.IdCaja, ca.IdSucursal)
            Next
            .Append(" 1 = 0)")
         End If
         If esFechaMovimiento Then
            .AppendLine("   AND CD.FechaMovimiento <= '" & fechaHasta.ToString("yyyyMMdd") & " 23:59:59'")
         Else
            .AppendLine("   AND C.FechaPlanilla <= '" & fechaHasta.ToString("yyyyMMdd") & " 23:59:59'")
         End If
         If idCuentaCaja > 0 Then
            .AppendLine("   AND CD.IdCuentaCaja = " & idCuentaCaja.ToString())
         End If
         If Not String.IsNullOrEmpty(idGrupoCuenta) Then
            .AppendLine("   AND Cc.IdGrupoCuenta = '" & idGrupoCuenta & "'")
         End If
         If esModificable <> "TODOS" Then
            .AppendLine("      AND CD.EsModificable = " & IIf(esModificable = "SI", "1", "0").ToString())
         End If
         If nroPlanilla > 0 Then
            .AppendLine("   AND CD.NumeroPlanilla = " & nroPlanilla)
         End If
         If Not String.IsNullOrWhiteSpace(columna) Then
            .AppendLine("     AND " & columna & " LIKE '%" & buscar.Valor.ToString() & "%'")
         End If            'If Not String.IsNullOrWhiteSpace(entidad.Columna) Then
      End With

      Return GetDataTable(stbQuery)

   End Function

   Public Function GetPorRangoFechas(buscar As Entidades.Buscar,
                                     sucursales As Entidades.Sucursal(), cajas As Entidades.CajaNombre(),
                                     fechaDesde As Date, fechaHasta As Date, fechaConsulta As Entidades.CajaDetalles.FechaConsulta,
                                     idCuentaCaja As Integer, idGrupoCuenta As String,
                                     esModificable As Entidades.Publicos.SiNoTodos,
                                     nroPlanilla As Integer) As DataTable
      If buscar Is Nothing Then buscar = New Entidades.Buscar()
      Dim columna As String = String.Empty
      If Not String.IsNullOrWhiteSpace(buscar.Columna) Then
         Select Case buscar.Columna
            Case "NombreCuentaCaja"
               columna = "Cc." + buscar.Columna
            Case "IdGrupoCuenta"
               columna = "Cc." + buscar.Columna
            Case Else
               columna = "Cd." & buscar.Columna
         End Select
      End If            'If Not String.IsNullOrWhiteSpace(entidad.Columna) Then

      Dim stbQuery = New StringBuilder()
      SelectFiltrado(stbQuery)
      With stbQuery
         .AppendLine("  WHERE 1 = 1")
         GetListaSucursalesMultiples(stbQuery, sucursales, "C")
         GetListaMultiples(stbQuery, cajas, "C")

         'If cajas.Count > 0 Then
         '   .Append(" AND (")
         '   For Each ca As Entidades.CajaNombre In cajas
         '      .AppendFormat(" (C.IdCaja = {0} AND C.IdSucursal = {1}) OR ", ca.IdCaja, ca.IdSucursal)
         '   Next
         '   .Append(" 1 = 0)")
         'End If

         'If esFechaMovimiento Then
         '   .AppendLine("   AND CD.FechaMovimiento BETWEEN '" & fechaDesde.ToString("yyyyMMdd") & " 00:00:00' AND '" & fechaHasta.ToString("yyyyMMdd") & " 23:59:59'")
         'Else
         '   .AppendLine("   AND C.FechaPlanilla BETWEEN '" & fechaDesde.ToString("yyyyMMdd") & " 00:00:00' AND '" & fechaHasta.ToString("yyyyMMdd") & " 23:59:59'")
         'End If

         If fechaConsulta = Entidades.CajaDetalles.FechaConsulta.Movimiento Then
            .AppendFormatLine("   AND CD.FechaMovimiento BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))
         Else
            .AppendFormatLine("   AND C.FechaPlanilla BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))
         End If


         If idCuentaCaja > 0 Then
            .AppendLine("   AND CD.IdCuentaCaja = " & idCuentaCaja.ToString())
         End If
         If Not String.IsNullOrEmpty(idGrupoCuenta) Then
            .AppendLine("   AND Cc.IdGrupoCuenta = '" & idGrupoCuenta & "'")
         End If
         If esModificable <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND CD.EsModificable = {0}", GetStringFromBoolean(esModificable = Entidades.Publicos.SiNoTodos.SI))
         End If
         If nroPlanilla > 0 Then
            .AppendLine("      AND CD.NumeroPlanilla = " & nroPlanilla)
         End If

         If Not String.IsNullOrWhiteSpace(columna) Then
            .AppendLine("     AND " & columna & " LIKE '%" & buscar.Valor.ToString() & "%'")
         End If            'If Not String.IsNullOrWhiteSpace(entidad.Columna) Then
         .AppendLine(" ORDER BY Cd.FechaMovimiento, NumeroMovimiento ")
      End With

      Return GetDataTable(stbQuery)

   End Function

   Public Function ResumenDeCaja(sucursales As Entidades.Sucursal(),
                                 cajas As Entidades.CajaNombre(),       'IdCaja As Integer,
                                 fechaDesde As Date,
                                 fechaHasta As Date,
                                 esFechaMovimiento As Boolean) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("SELECT IdGrupoCuenta, NombreCuentaCaja, IdCuentaCaja, SUM(Ingreso) AS Ingresos, SUM(Egreso) AS Egresos ")
         .AppendLine("FROM ")
         .AppendLine("( ")
         .AppendLine("SELECT CdC.IdGrupoCuenta, CdC.NombreCuentaCaja, CdC.IdCuentaCaja,  ")
         .AppendLine("   CASE CD.IdTipoMovimiento ")
         .AppendLine("      WHEN 'I' Then SUM(CD.ImportePesos+CD.ImporteDolares+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas+CD.ImporteBancos+CD.ImporteRetenciones) ")
         .AppendLine("      WHEN 'E' Then 0 ")
         .AppendLine("   END Ingreso, ")
         .AppendLine("   CASE CD.IdTipoMovimiento ")
         .AppendLine("      WHEN 'I' Then 0 ")
         .AppendLine("      WHEN 'E' Then SUM(CD.ImportePesos+CD.ImporteDolares+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas+CD.ImporteBancos+CD.ImporteRetenciones) ")
         .AppendLine("   END Egreso ")
         .AppendLine(" FROM Cajas C ")
         .AppendLine(" INNER JOIN CajasDetalle CD ON C.IdSucursal = CD.IdSucursal AND C.IdCaja = CD.IdCaja AND C.NumeroPlanilla = CD.NumeroPlanilla")
         .AppendLine(" INNER JOIN CuentasDeCajas CdC ON CD.IdCuentaCaja = CdC.IdCuentaCaja")

         .AppendLine("  WHERE 1 = 1")

         GetListaSucursalesMultiples(stbQuery, sucursales, "C")
         GetListaMultiples(stbQuery, cajas, "C")

         'If idCaja > 0 Then
         '   .AppendFormat("   AND (C.IdCaja = {0} AND C.IdSucursal = {1})", idCaja, idSucursalCaja)
         'End If

         If esFechaMovimiento Then
            .AppendLine("   AND CD.FechaMovimiento BETWEEN '" & fechaDesde.ToString("yyyyMMdd") & " 00:00:00' AND '" & fechaHasta.ToString("yyyyMMdd") & " 23:59:59'")
         Else
            .AppendLine("   AND C.FechaPlanilla BETWEEN '" & fechaDesde.ToString("yyyyMMdd") & " 00:00:00' AND '" & fechaHasta.ToString("yyyyMMdd") & " 23:59:59'")
         End If

         .AppendLine(" GROUP BY CdC.IdGrupoCuenta, CdC.NombreCuentaCaja, CdC.IdCuentaCaja, CD.IdTipoMovimiento ")
         .AppendLine(") Detalle ")
         .AppendLine("GROUP BY IdGrupoCuenta, NombreCuentaCaja, IdCuentaCaja ")

      End With

      Return GetDataTable(stbQuery)
   End Function

   Public Sub InformeCajayBancosQueryInterno(stbQuery As StringBuilder,
                                             sucursales As Entidades.Sucursal(),
                                             cajas As Entidades.CajaNombre(),
                                             fechaDesde As Date,
                                             fechaHasta As Date,
                                             esFechaMovimiento As Boolean,
                                             idCuentaCaja As Integer,
                                             idGrupoCuenta As String,
                                             esModificable As String)
      With stbQuery
         .AppendLine("        SELECT Cd.IdSucursal ")
         .AppendLine("              ,Cd.IdCaja ")
         .AppendLine("              ,CA.NombreCaja AS Caja")
         .AppendLine("              ,Cd.NumeroPlanilla ")
         .AppendLine("              ,Cd.NumeroMovimiento ")
         .AppendLine("              ,Cd.IdCuentaCaja ")
         .AppendLine("              ,Cc.NombreCuentaCaja ")
         .AppendLine("              ,Cc.IdGrupoCuenta ")
         .AppendLine("              ,Cd.FechaMovimiento AS FechaMovimiento ")
         .AppendLine("              ,LEFT(CONVERT(TIME, Cd.FechaMovimiento),5) AS Hora ")
         .AppendLine("              ,CASE IdTipoMovimiento WHEN 'I' Then 'Ingreso' WHEN 'E' Then 'Egreso' END NombreTipoMovimiento ")
         .AppendLine("              ,Cd.IdTipoMovimiento ")
         .AppendLine("              ,Cd.ImportePesos ")
         .AppendLine("              ,Cd.ImporteCheques ")
         .AppendLine("              ,Cd.ImporteTarjetas ")
         .AppendLine("              ,Cd.ImporteDolares ")
         .AppendLine("              ,Cd.ImporteRetenciones ")
         .AppendLine("              ,0 as ImporteBancos ")
         .AppendLine("              ,Cd.IdUsuario ")
         .AppendLine("              ,Cd.EsModificable ")
         .AppendLine("              ,Cd.GeneraContabilidad ")
         .AppendLine("              ,Cd.Observacion ")
         .AppendLine("              ,Cd.ImporteTickets ")
         .AppendLine("              ,Cd.FechaMovimiento as Fec ")
         .AppendLine("              ,0 as IdCuentaBancaria")
         .AppendLine("              ,'' AS NombreCuenta")

         .AppendLine("         FROM CajasDetalle Cd ")
         .AppendLine("         LEFT JOIN CuentasDeCajas Cc ON Cd.IdCuentaCaja = Cc.IdCuentaCaja ")
         .AppendLine("         LEFT JOIN CajasNombres CA ON CA.IdCaja = CD.IdCaja AND CA.IdSucursal = Cd.IdSucursal")
         .AppendLine("        WHERE (ImporteBancos+ImporteCheques+ImporteDolares+ImporteEuros+ImportePesos+ImporteRetenciones+ImporteTarjetas+ImporteTickets)<>0  ")

         GetListaSucursalesMultiples(stbQuery, sucursales, "CD")

         GetListaMultiples(stbQuery, cajas, "CD")

         Dim campoFecha As String
         If esFechaMovimiento Then
            campoFecha = "CD.FechaMovimiento"
         Else
            campoFecha = "C.FechaPlanilla"
         End If
         .AppendFormatLine("          AND {0} BETWEEN '{1}' AND '{2}'", campoFecha, ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.Date.UltimoSegundoDelDia(), True))

         If idCuentaCaja > 0 Then
            .AppendFormatLine("          AND CD.IdCuentaCaja = {0}", idCuentaCaja)
         End If
         If Not String.IsNullOrEmpty(idGrupoCuenta) Then
            .AppendFormatLine("          AND Cc.IdGrupoCuenta = '{0}'", idGrupoCuenta)
         End If
         If esModificable <> "TODOS" Then
            .AppendFormatLine("          AND CD.EsModificable = {0}", GetStringFromBoolean(esModificable = "SI"))
         End If

         .AppendLine("        UNION ")
         .AppendLine("        SELECT LB.IdSucursal ")
         .AppendLine("              ,0 as Caja ")
         .AppendLine("              ,'Banco' as NombreCaja ")
         .AppendLine("              ,0 as NroPlanilla ")
         .AppendLine("              ,LB.NumeroMovimiento ")
         .AppendLine("              ,LB.IdCuentaBanco ")
         .AppendLine("              ,CB.NombreCuentaBanco ")
         .AppendLine("              ,CB.IdGrupoCuenta ")
         .AppendLine("              ,LB.FechaMovimiento AS FechaMovimiento ")
         .AppendLine("              ,LEFT(CONVERT(TIME, LB.FechaMovimiento),5) AS Hora ")
         .AppendLine("              ,CASE IdTipoMovimiento WHEN 'I' Then 'Ingreso' WHEN 'E' Then 'Egreso' END NombreTipoMovimiento ")
         .AppendLine("              ,LB.IdTipoMovimiento ")
         .AppendLine("              ,0")
         .AppendLine("              ,0")
         .AppendLine("              ,0")
         .AppendLine("              ,0")
         .AppendLine("              ,0")
         .AppendLine("              ,LB.Importe AS ImporteBancos")
         .AppendLine("              ,'' as Usuario ")
         .AppendLine("              ,LB.EsModificable ")
         .AppendLine("              ,LB.GeneraContabilidad ")
         .AppendLine("              ,LB.Observacion ")
         .AppendLine("              ,0 as Tic ")
         .AppendLine("              ,LB.FechaMovimiento as Fec ")
         .AppendLine("              ,LB.IdCuentaBancaria ")
         .AppendLine("              ,CUB.NombreCuenta AS NombreCuenta")
         .AppendLine("          FROM LibrosBancos LB ")
         .AppendLine("         INNER JOIN CuentasBancos CB ON CB.IdCuentaBanco = LB.IdCuentaBanco ")
         .AppendLine("         INNER JOIN CuentasBancarias CUB ON CUB.IdCuentaBancaria = LB.IdCuentaBancaria ")
         .AppendLine("         WHERE 1 = 1")
         GetListaSucursalesMultiples(stbQuery, sucursales, "LB")

         .AppendFormatLine("         AND {0} BETWEEN '{1}' AND '{2}'", "LB.FechaMovimiento", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.Date.UltimoSegundoDelDia(), True))

         If esModificable <> "TODOS" Then
            .AppendFormatLine("         AND LB.EsModificable = {0}", GetStringFromBoolean(esModificable = "SI"))
         End If

      End With
   End Sub

   Public Function InformeCajayBancos(sucursales As Entidades.Sucursal(),
                                      cajas As Entidades.CajaNombre(),
                                      fechaDesde As Date,
                                      fechaHasta As Date,
                                      esFechaMovimiento As Boolean,
                                      idCuentaCaja As Integer,
                                      idGrupoCuenta As String,
                                      esModificable As String,
                                      incluyeSaldoInicial As Boolean) As DataTable

      Dim stbQuery = New StringBuilder()
      With stbQuery
         If incluyeSaldoInicial Then
            .AppendLine("SELECT '19000101' FechaMovimiento")
            .AppendLine("      ,NULL NombreCuentaCaja")
            .AppendLine("      ,'Saldo Inicial' Observacion")
            .AppendLine("      ,NULL Caja")
            .AppendLine("      ,NULL AS TM ")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImportePesos       > 0 THEN ImportePesos        ELSE 0 END) +")
            .AppendLine("       (CASE WHEN ImporteCheques     > 0 THEN ImporteCheques      ELSE 0 END) +")
            .AppendLine("       (CASE WHEN ImporteBancos      > 0 THEN ImporteBancos       ELSE 0 END) +")
            .AppendLine("       (CASE WHEN Importetarjetas    > 0 THEN Importetarjetas     ELSE 0 END)), 0) AS INGRESOS")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImportePesos       < 0 THEN ImportePesos        ELSE 0 END) +")
            .AppendLine("       (CASE WHEN ImporteCheques     < 0 THEN ImporteCheques      ELSE 0 END) +")
            .AppendLine("       (CASE WHEN ImporteBancos      < 0 THEN ImporteBancos       ELSE 0 END) +")
            .AppendLine("       (CASE WHEN Importetarjetas    < 0 THEN Importetarjetas     ELSE 0 END)), 0) AS EGRESOS")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImportePesos       > 0 THEN ImportePesos        ELSE 0 END)), 0) AS I_Ef_$")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImportePesos       < 0 THEN ImportePesos        ELSE 0 END)), 0) AS E_Ef_$")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImporteCheques     > 0 THEN ImporteCheques      ELSE 0 END)), 0) AS I_Ch_$")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImporteCheques     < 0 THEN ImporteCheques      ELSE 0 END)), 0) AS E_Ch_$")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImporteBancos      > 0 THEN ImporteBancos       ELSE 0 END)), 0) AS I_Ba_$")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImporteBancos      < 0 THEN ImporteBancos       ELSE 0 END)), 0) AS E_Ba_$")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN Importetarjetas    > 0 THEN Importetarjetas     ELSE 0 END)), 0) AS I_Ta_$")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN Importetarjetas    < 0 THEN Importetarjetas     ELSE 0 END)), 0) AS E_Ta_$")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImporteDolares     > 0 THEN ImporteDolares      ELSE 0 END)), 0) AS I_Dol_u$s")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImporteDolares     < 0 THEN ImporteDolares      ELSE 0 END)), 0) AS E_Dol_u$s")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImporteRetenciones > 0 THEN ImporteRetenciones  ELSE 0 END)), 0) AS I_Ret_$")
            .AppendLine("      ,ISNULL(SUM((CASE WHEN ImporteRetenciones < 0 THEN -ImporteRetenciones ELSE 0 END)), 0) AS E_Ret_$")
            .AppendLine("      ,ISNULL(SUM(ImportePesos), 0) as Efectivo$")
            .AppendLine("      ,ISNULL(SUM(ImporteCheques), 0) as Cheques3ros")
            .AppendLine("      ,ISNULL(SUM(ImporteBancos), 0) as BancoCC")
            .AppendLine("      ,ISNULL(SUM(ImporteTarjetas), 0) as Tarjetas")
            .AppendLine("      ,ISNULL(SUM(ImporteDolares), 0) as Dolares")
            .AppendLine("      ,ISNULL(SUM(ImporteRetenciones), 0) as Retenciones")
            .AppendLine("      ,NULL IdUsuario ")
            .AppendLine("      ,NULL NumeroMovimiento")
            .AppendLine("      ,NULL Fec,NULL Hora")
            .AppendLine("      ,'' as Saldo_Ef_$")
            .AppendLine("      ,'' as Saldo_Ch_$")
            .AppendLine("      ,'' as Saldo_Ba_$")
            .AppendLine("      ,'' as Saldo_Ta_$ ")
            .AppendLine("      ,'' as Saldo_Dol_u$s")
            .AppendLine("      ,'' as Saldo_Ret_$")
            .AppendLine("      ,NULL NombreCuenta")
            .AppendLine("      ,'' as SaldoTotalCaja")
            .AppendLine("      ,'' as SaldoGeneral")

            .AppendLine("  FROM (")
            InformeCajayBancosQueryInterno(stbQuery,
                                           sucursales, cajas, New Date(1900, 1, 1), fechaDesde.Date.AddSeconds(-1), esFechaMovimiento, idCuentaCaja, idGrupoCuenta, esModificable)
            .AppendLine(" ) AS saldoinicial")

            .AppendLine(" UNION ALL ")
         End If

         .AppendLine("SELECT FechaMovimiento")
         .AppendLine("      ,NombreCuentaCaja")
         .AppendLine("      ,Observacion")
         .AppendLine("      ,Caja")
         .AppendLine("      ,IdTipoMovimiento as TM ")
         .AppendLine("      ,(CASE WHEN ImportePesos       > 0 THEN ImportePesos        ELSE 0 END) +")
         .AppendLine("       (CASE WHEN ImporteCheques     > 0 THEN ImporteCheques      ELSE 0 END) +")
         .AppendLine("       (CASE WHEN ImporteBancos      > 0 THEN ImporteBancos       ELSE 0 END) +")
         .AppendLine("       (CASE WHEN Importetarjetas    > 0 THEN Importetarjetas     ELSE 0 END) AS INGRESOS")
         .AppendLine("      ,(CASE WHEN ImportePesos       < 0 THEN ImportePesos        ELSE 0 END) +")
         .AppendLine("       (CASE WHEN ImporteCheques     < 0 THEN ImporteCheques      ELSE 0 END) +")
         .AppendLine("       (CASE WHEN ImporteBancos      < 0 THEN ImporteBancos       ELSE 0 END) +")
         .AppendLine("       (CASE WHEN Importetarjetas    < 0 THEN Importetarjetas     ELSE 0 END) AS EGRESOS")
         .AppendLine("      ,(CASE WHEN ImportePesos       > 0 THEN ImportePesos        ELSE 0 END) AS I_Ef_$")
         .AppendLine("      ,(CASE WHEN ImportePesos       < 0 THEN ImportePesos        ELSE 0 END) AS E_Ef_$")
         .AppendLine("      ,(CASE WHEN ImporteCheques     > 0 THEN ImporteCheques      ELSE 0 END) AS I_Ch_$")
         .AppendLine("      ,(CASE WHEN ImporteCheques     < 0 THEN ImporteCheques      ELSE 0 END) AS E_Ch_$")
         .AppendLine("      ,(CASE WHEN ImporteBancos      > 0 THEN ImporteBancos       ELSE 0 END) AS I_Ba_$")
         .AppendLine("      ,(CASE WHEN ImporteBancos      < 0 THEN ImporteBancos       ELSE 0 END) AS E_Ba_$")
         .AppendLine("      ,(CASE WHEN Importetarjetas    > 0 THEN Importetarjetas     ELSE 0 END) AS I_Ta_$")
         .AppendLine("      ,(CASE WHEN Importetarjetas    < 0 THEN Importetarjetas     ELSE 0 END) AS E_Ta_$")
         .AppendLine("      ,(CASE WHEN ImporteDolares     > 0 THEN ImporteDolares      ELSE 0 END) AS I_Dol_u$s")
         .AppendLine("      ,(CASE WHEN ImporteDolares     < 0 THEN ImporteDolares      ELSE 0 END) AS E_Dol_u$s")
         .AppendLine("      ,(CASE WHEN ImporteRetenciones > 0 THEN ImporteRetenciones  ELSE 0 END) AS I_Ret_$")
         .AppendLine("      ,(CASE WHEN ImporteRetenciones < 0 THEN -ImporteRetenciones ELSE 0 END) AS E_Ret_$")
         .AppendLine("      ,ImportePesos as Efectivo$")
         .AppendLine("      ,ImporteCheques as Cheques3ros")
         .AppendLine("      ,ImporteBancos as BancoCC")
         .AppendLine("      ,ImporteTarjetas as Tarjetas")
         .AppendLine("      ,ImporteDolares as Dolares")
         .AppendLine("      ,ImporteRetenciones as Retenciones")
         .AppendLine("      ,IdUsuario ")
         .AppendLine("      ,NumeroMovimiento")
         .AppendLine("      ,Fec,Hora")
         .AppendLine("      ,'' as Saldo_Ef_$")
         .AppendLine("      ,'' as Saldo_Ch_$")
         .AppendLine("      ,'' as Saldo_Ba_$")
         .AppendLine("      ,'' as Saldo_Ta_$ ")
         .AppendLine("      ,'' as Saldo_Dol_u$s")
         .AppendLine("      ,'' as Saldo_Ret_$")
         .AppendLine("      ,NombreCuenta")
         .AppendLine("      ,'' as SaldoTotalCaja")
         .AppendLine("      ,'' as SaldoGeneral")

         .AppendLine("  FROM (")
         InformeCajayBancosQueryInterno(stbQuery,
                                        sucursales, cajas, fechaDesde, fechaHasta, esFechaMovimiento, idCuentaCaja, idGrupoCuenta, esModificable)
         .AppendLine(" ) AS cajaBanco")

         .AppendFormatLine(" ORDER BY FechaMovimiento")

      End With

      Return GetDataTable(stbQuery)
   End Function

   Public Sub SelectFiltrado(ByRef stb As StringBuilder)
      With stb
         .AppendLine("SELECT Cd.IdSucursal")
         .AppendLine("      ,Cd.IdCaja")
         .AppendLine("      ,CN.NombreCaja")
         '.AppendLine("      ,C.FechaPlanilla")
         .AppendLine("      ,CONVERT(DATE, C.FechaPlanilla) AS FechaPlanilla")
         .AppendLine("      ,Cd.NumeroPlanilla")
         .AppendLine("      ,Cd.NumeroMovimiento")
         .AppendLine("      ,Cd.IdCuentaCaja")
         .AppendLine("      ,Cc.NombreCuentaCaja")
         .AppendLine("      ,Cc.IdGrupoCuenta")
         '.AppendLine("      ,Cd.FechaMovimiento")
         '.AppendLine("      ,Cd.FechaMovimiento as Hora")
         .AppendLine("      ,CONVERT(DATE, Cd.FechaMovimiento) AS FechaMovimiento")
         .AppendLine("      ,LEFT(CONVERT(TIME, Cd.FechaMovimiento),5) AS Hora")
         .AppendLine("      ,CASE IdTipoMovimiento")
         .AppendLine("         WHEN 'I' Then 'Ingreso'")
         .AppendLine("         WHEN 'E' Then 'Egreso'")
         .AppendLine("       END NombreTipoMovimiento")
         .AppendLine("      ,Cd.IdTipoMovimiento")
         .AppendLine("      ,Cd.ImportePesos")
         .AppendLine("      ,Cd.ImporteCheques")
         .AppendLine("      ,Cd.ImporteTarjetas")
         .AppendLine("      ,Cd.ImporteDolares")
         .AppendLine("      ,Cd.ImporteRetenciones")
         .AppendLine("      ,CASE WHEN Cd.IdMonedaImporteBancos = 1 THEN Cd.ImporteBancos ELSE 0 END ImporteBancos")
         .AppendLine("      ,CASE WHEN Cd.IdMonedaImporteBancos = 2 THEN Cd.ImporteBancos ELSE 0 END ImporteBancosDolares")

         .AppendLine("      ,Cd.ImportePesos+Cd.ImporteCheques+Cd.ImporteTarjetas+(Cd.ImporteDolares*Cd.CotizacionDolar)+Cd.ImporteRetenciones+Cd.ImporteTickets+")
         .AppendLine("       Cd.ImporteBancos * CASE WHEN Cd.IdMonedaImporteBancos = 1 THEN 1 ELSE ISNULL(NULLIF(Cd.CotizacionDolar, 0), 1) END as Total")
         .AppendLine("      ,Cd.IdMonedaImporteBancos")

         .AppendLine("      ,Cd.IdUsuario")
         .AppendLine("      ,Cd.EsModificable")
         .AppendLine("      ,Cd.GeneraContabilidad")
         .AppendLine("      ,Cd.Observacion")
         .AppendLine("      ,Cd.ImporteTickets")
         .AppendLine("      ,Cd.IdEjercicio")
         .AppendLine("      ,Cd.IdPlanCuenta")
         .AppendLine("      ,Cd.IdAsiento")
         .AppendLine("      ,Cd.IdCentroCosto")
         .AppendLine("      ,CCC.NombreCentroCosto")
         .AppendLine("      ,Cd.CotizacionDolar")
         .AppendFormatLine("      ,Cd.{0}", Entidades.CajaDetalles.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("      ,Cd.{0}", Entidades.CajaDetalles.Columnas.NumeroDeposito.ToString())

         .AppendFormatLine("     , Cd.IdConceptoCM05")
         .AppendFormatLine("     , CM05.DescripcionConceptoCM05")
         .AppendFormatLine("     , CM05.TipoConceptoCM05")

         .AppendLine(" FROM CajasDetalle Cd ")
         .AppendLine(" INNER JOIN CuentasDeCajas Cc ON Cd.IdCuentaCaja = Cc.IdCuentaCaja ")
         .AppendLine(" INNER JOIN Cajas C ON Cd.IdSucursal = C.IdSucursal AND cd.IdCaja = c.IdCaja AND Cd.NumeroPlanilla = C.NumeroPlanilla ")
         .AppendLine(" LEFT JOIN CajasNombres CN ON C.IdSucursal = CN.IdSucursal AND C.IdCaja = CN.IdCaja")
         .AppendLine(" LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = Cd.IdCentroCosto")
         .AppendFormatLine("  LEFT JOIN AFIPConceptosCM05 CM05 ON CM05.IdConceptoCM05 = Cd.IdConceptoCM05")
      End With
   End Sub

   Public Function TieneMovimientosEnCaja(idCuentaCaja As Integer) As Boolean
      Dim query = New StringBuilder
      With query
         SelectFiltrado(query)
         .AppendFormatLine("WHERE Cd.IdCuentaCaja = {0}", idCuentaCaja)
      End With

      If (GetDataTable(query.ToString())).Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If
   End Function

   Public Function CajaDetalles_G_SaldosActuales(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As DataTable
      Dim stb = New StringBuilder
      With stb
         .AppendFormatLine("SELECT ISNULL(SUM(ISNULL(ImportePesos,0)),0)        ImportePesos")
         .AppendFormatLine("     , ISNULL(SUM(ISNULL(ImporteDolares,0)),0)      ImporteDolares")
         .AppendFormatLine("     , ISNULL(SUM(ISNULL(ImporteTickets,0)),0)      ImporteTickets")
         .AppendFormatLine("     , ISNULL(SUM(ISNULL(ImporteCheques,0)),0)      ImporteCheques")
         .AppendFormatLine("     , ISNULL(SUM(ISNULL(ImporteTarjetas,0)),0)     ImporteTarjetas")
         .AppendFormatLine("     , ISNULL(SUM(ISNULL(ImporteRetenciones,0)),0)  ImporteRetenciones")
         .AppendFormatLine("     , ISNULL(SUM(ISNULL(CASE WHEN IdMonedaImporteBancos = 1 THEN ImporteBancos ELSE 0 END,0)),0)   ImporteBancos")
         .AppendFormatLine("     , ISNULL(SUM(ISNULL(CASE WHEN IdMonedaImporteBancos = 2 THEN ImporteBancos ELSE 0 END,0)),0)   ImporteBancosDolares")
         .AppendFormatLine("  FROM CajasDetalle")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdCaja = {0}", idCaja)
         .AppendFormatLine("   AND NumeroPlanilla = {0}", numeroPlanilla)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetProximoNumeroDeMovimiento(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT MAX(NumeroMovimiento) + 1 ")
         .AppendFormatLine("  FROM CajasDetalle ")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdCaja = {0}", idCaja)
         .AppendFormatLine("   AND NumeroPlanilla = {0}", numeroPlanilla)
      End With

      Return GetDataTable(stb)
   End Function


   Public Function GetMovimiento(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer, numeroMovimiento As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT Cd.*")
         .AppendFormatLine("     , Cc.NombreCuentaCaja")
         .AppendFormatLine("  FROM CajasDetalle Cd")
         .AppendFormatLine(" INNER JOIN CuentasDeCajas Cc On Cd.IdCuentaCaja = Cc.IdCuentaCaja ")
         .AppendFormatLine(" WHERE Cd.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND Cd.idCaja = {0}", idCaja)
         .AppendFormatLine("   AND Cd.NumeroPlanilla = {0}", numeroPlanilla)
         .AppendFormatLine("   AND Cd.NumeroMovimiento = {0}", numeroMovimiento)
      End With

      Return GetDataTable(stbQuery)
   End Function


   Public Function ResumenAnual(sucursales As Entidades.Sucursal(), cajas As Entidades.CajaNombre(), anio As Integer, esFechaMovimiento As Boolean, tipoValor As String) As DataTable
      Dim campoFecha = If(esFechaMovimiento, "CD.FechaMovimiento", "C.FechaPlanilla")

      Dim campoSumarizado As String
      Select Case tipoValor
         Case "PESOSYDOLARES"
            campoSumarizado = "CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas+(CASE WHEN CD.IdMonedaImporteBancos = 2 THEN CD.ImporteBancos * CD.CotizacionDolar ELSE CD.ImporteBancos END)+CD.ImporteRetenciones+ (CD.ImporteDolares * CD.CotizacionDolar)"
         Case "PESOS"
            campoSumarizado = "CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas+(CASE WHEN CD.IdMonedaImporteBancos = 1 THEN CD.ImporteBancos ELSE 0 END)+CD.ImporteRetenciones"
         Case "DOLARES"
            campoSumarizado = "CD.ImporteDolares+(CASE WHEN CD.IdMonedaImporteBancos = 2 THEN CD.ImporteBancos ELSE 0 END)"
         Case Else
            campoSumarizado = "CD.ImportePesos+CD.ImporteTickets+CD.ImporteCheques+CD.ImporteTarjetas+(CASE WHEN CD.IdMonedaImporteBancos = 2 THEN CD.ImporteBancos * CD.CotizacionDolar ELSE CD.ImporteBancos END)+CD.ImporteRetenciones+ (CD.ImporteDolares * CD.CotizacionDolar)"
      End Select

      Dim meses = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("    IdCuentaCaja, NombreCuentaCaja,")

         For Each mes In meses
            .AppendFormatLine("    SUM({0}) AS {0},", mes)
         Next
         .AppendFormatLine("    SUM({0}) AS Total", String.Join("+", meses))

         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT CdC.IdCuentaCaja, CdC.NombreCuentaCaja,")
         For i = 0 To meses.Length - 1
            .AppendFormatLine("               CASE MONTH({0}) WHEN  {2} Then SUM({1}) ELSE 0 END {3},", campoFecha, campoSumarizado, i + 1, meses(i))
         Next
         .AppendFormatLine("                NULL EOR")  'Para que no me pinche el For y no tener que controlar si es el último o no, agrego un campo adicional a la consulta que sea NULL que no lo uso para nada
         .AppendFormatLine("          FROM Cajas C")
         .AppendFormatLine("         INNER JOIN CajasDetalle CD ON C.IdSucursal = CD.IdSucursal AND C.IdCaja = CD.IdCaja AND C.NumeroPlanilla = CD.NumeroPlanilla")
         .AppendFormatLine("         INNER JOIN CuentasDeCajas CdC ON CD.IdCuentaCaja = CdC.IdCuentaCaja")

         .AppendFormatLine("          WHERE 1 = 1")
         GetListaSucursalesMultiples(stbQuery, sucursales, "C")
         GetListaMultiples(stbQuery, cajas, "C")
         .AppendFormatLine("            AND YEAR({0}) = {1}", campoFecha, anio)

         .AppendFormatLine("          GROUP BY CdC.IdCuentaCaja, CdC.NombreCuentaCaja, {0}", campoFecha)
         .AppendFormatLine("        ) Detalle")
         .AppendFormatLine(" GROUP BY IdCuentaCaja, NombreCuentaCaja")
         .AppendFormatLine(" ORDER BY NombreCuentaCaja, IdCuentaCaja")
      End With

      Return GetDataTable(stbQuery)
   End Function

End Class