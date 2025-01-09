Public Class LiquidacionesCargos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub LiquidacionesCargos_I(periodo As Integer,
                                    idLiquidacionCargo As Integer,
                                    idSucursal As Integer,
                                    idCliente As Long,
                                    nombreCategoria As String,
                                    importeExpensas As Decimal,
                                    importeAlquiler As Decimal,
                                    importeServicios As Decimal,
                                    importeGastosAdmin As Decimal,
                                    importeTotal As Decimal,
                                    primerVto As Date,
                                    importePrimerVto As Decimal,
                                    segundoVto As Date,
                                    importeSegundoVto As Decimal,
                                    saldoAnterior As Decimal,
                                    importeTotalAdicionales As Decimal,
                                    idTipoLiquidacion As Integer,
                                    cantidadDePCs As Integer,
                                    selecciono As String)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO LiquidacionesCargos ")
         .AppendLine(" (IdLiquidacionCargo")
         .AppendLine(" ,PeriodoLiquidacion")
         .AppendLine(" ,IdSucursal")
         .AppendLine(" ,IdCliente")
         .AppendLine(" ,importeExpensas")
         .AppendLine(" ,importeAlquiler")
         .AppendLine(" ,importeServicios")
         .AppendLine(" ,ImporteGastosAdmin")
         .AppendLine(" ,importeTotal")
         .AppendLine(" ,PrimerVto")
         .AppendLine(" ,ImportePrimerVto")
         .AppendLine(" ,SegundoVto")
         .AppendLine(" ,ImporteSegundoVto")
         .AppendLine(" ,SaldoAnterior")
         .AppendLine(" ,NombreCategoria")
         .AppendLine(" ,ImporteTotalAdicionales")
         .AppendLine(" ,IdTipoLiquidacion")
         .AppendLine(" ,CantidadDePCs")
         .AppendLine(" ,Selecciono")
         .AppendLine(" ) VALUES (")
         .AppendFormat(" {0} ", idLiquidacionCargo).AppendLine()
         .AppendFormat(" ,{0} ", periodo.ToString).AppendLine()
         .AppendFormat(" ,{0} ", idSucursal.ToString).AppendLine()
         .AppendFormat(" ,{0} ", idCliente.ToString).AppendLine()

         '# En caso de que no se haya seleccionado, todos los campos de tipo Importe se van a grabar en $0
         If selecciono = "SI" Then
            .AppendFormatLine(" ,{0} ", importeExpensas.ToString)
            .AppendFormatLine(" ,{0} ", importeAlquiler.ToString)
            .AppendFormatLine(" ,{0} ", importeServicios.ToString)
            .AppendFormatLine(" ,{0} ", importeGastosAdmin.ToString)
            .AppendFormatLine(" ,{0} ", importeTotal.ToString)
         Else
            .AppendLine(" ,0")
            .AppendLine(" ,0")
            .AppendLine(" ,0")
            .AppendLine(" ,0")
            .AppendLine(" ,0")
         End If

         .AppendFormatLine(" ,'{0}' ", Me.ObtenerFecha(primerVto, False))
         .AppendFormatLine(" ,{0} ", If(selecciono = "SI", importePrimerVto.ToString, "0"))
         .AppendFormatLine(" ,'{0}' ", Me.ObtenerFecha(segundoVto, False))
         .AppendFormatLine(" ,{0} ", If(selecciono = "SI", importeSegundoVto.ToString, "0"))
         .AppendFormatLine(" ,{0} ", saldoAnterior.ToString)
         .AppendFormatLine(" ,'{0}' ", nombreCategoria.ToString())
         .AppendFormatLine("  ,{0}", If(selecciono = "SI", importeTotalAdicionales.ToString(), "0"))
         .AppendFormatLine("  ,{0}", idTipoLiquidacion)
         .AppendFormatLine("  ,{0}", cantidadDePCs)
         .AppendFormatLine("  ,'{0}'", selecciono)
         .AppendLine(")")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "LiquidacionesCargos")
   End Sub

   Public Sub LiquidacionesCargos_D(periodo As Integer, idTipoLiquidacion As Integer, idSucursal As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM LiquidacionesCargos ")
         .AppendLine(" WHERE PeriodoLiquidacion = " & periodo)
         .AppendLine(" AND IdSucursal = " & idSucursal)
         'If tipo.HasValue Then
         '   If tipo.Value = Entidades.Liquidacion.TipoLiquidacion.Alquiler Then
         .AppendLine("   AND IdTipoLiquidacion = " & idTipoLiquidacion)
         '   ElseIf tipo.Value = Entidades.Liquidacion.TipoLiquidacion.Expensas Then
         '.AppendLine("   AND TipoLiquidacion = 'E'")
         '   End If
         'End If
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "LiquidacionesCargos")
   End Sub

   Public Function GetProximoCodigoCargos(IdSucursal As Integer, IdTipoLiquidacion As Integer) As Long
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT MAX(" & Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString & ") AS Maximo FROM LiquidacionesCargos")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal)
         .AppendLine(" AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())
      End With

      Dim dt = _da.GetDataTable(stb.ToString())
      Dim val As Long = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Long.Parse(dt.Rows(0)("Maximo").ToString()) + 1
         Else
            val = 1
         End If
      End If

      Return val

   End Function

   Public Sub LiquidacionesCargos_D_Ultimo(IdSucursal As Integer, IdTipoLiquidacion As Integer)

      Dim Periodo As Integer = GetUltimoPeriodoLiquidacionEnLiquidacionesCargos(IdTipoLiquidacion)

      If Not (IsNothing(Periodo)) Then
         Dim myQuery = New StringBuilder()

         With myQuery
            .AppendLine("DELETE FROM LiquidacionesCargos ")
            .AppendLine(" WHERE PeriodoLiquidacion = " & Periodo.ToString())
            .Append(" AND IdSucursal = " & IdSucursal)
         End With

         Execute(myQuery)
         Sincroniza_I(myQuery.ToString(), "LiquidacionesCargos")
      End If
   End Sub

   Public Function GetUltimoPeriodoLiquidacionEnLiquidacionesCargos(IdTipoLiquidacion As Integer) As Integer

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT MAX(PeriodoLiquidacion) maximo FROM LiquidacionesCargos")
         .AppendLine(" WHERE IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())

      End With

      Dim dt = GetDataTable(stb.ToString())

      If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
         Return Integer.Parse(dt.Rows(0)("maximo").ToString())
      Else
         Return Nothing
      End If
   End Function

   Public Sub ActualizarComprobante(IdLiquidacionCargo As Integer, Periodo As Integer, IdCliente As Long,
                                    idSucursal As Integer, idTipoComprobante As String,
                                    letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                    ImporteTotal As Decimal, IdTipoLiquidacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE LiquidacionesCargos")
         If numeroComprobante > 0 Then
            .AppendLine("   SET IdSucursal = " & idSucursal.ToString())
            .AppendLine("      ,IdTipoComprobante = '" & idTipoComprobante & "'")
            .AppendLine("      ,Letra = '" & letra & "'")
            .AppendLine("      ,CentroEmisor = " & centroEmisor.ToString())
            .AppendLine("      ,NumeroComprobante = " & numeroComprobante.ToString())
            .AppendLine("      ,ImporteTotalAdicionales = " & ImporteTotal.ToString())
         Else
            .AppendLine("   SET IdTipoComprobante = NULL")
            .AppendLine("      ,Letra = NULL")
            .AppendLine("      ,CentroEmisor = NULL")
            .AppendLine("      ,NumeroComprobante = NULL")
            .AppendLine("      ,ImporteTotalAdicionales = 0")
         End If
         .AppendLine(" WHERE PeriodoLiquidacion = " & Periodo.ToString())
         .AppendLine("  AND IdSucursal = " & idSucursal.ToString())
         'El Cliente no hace falta cuando es embarcacion (porque no se puede repetir) pero si en el caso de ser un inversionista
         .AppendLine("   AND IdCliente = " & IdCliente.ToString())

         'Hay que hacerlo porque puede ser que un inversionista tenga embarcacion y pisa ambos cargos.
         If IdLiquidacionCargo > 0 Then
            .AppendLine("   AND IdLiquidacionCargo = " & IdLiquidacionCargo.ToString())
         End If
         .AppendLine("   AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())

      End With

      Execute(myQuery)
   End Sub

   Public Sub ActualizarComprobantePorComprobante(idSucursal As Integer,
                                                  idTipoComprobanteActual As String,
                                                  letraActual As String,
                                                  centroEmisorActual As Integer,
                                                  numeroComprobanteActual As Long,
                                                  idTipoComprobanteNuevo As String,
                                                  letraNuevo As String,
                                                  centroEmisorNuevo As Integer,
                                                  numeroComprobanteNuevo As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE LiquidacionesCargos")
         .AppendLine("   SET IdTipoComprobante = '" & idTipoComprobanteNuevo & "'")
         .AppendLine("      ,Letra = '" & letraNuevo & "'")
         .AppendLine("      ,CentroEmisor = " & centroEmisorNuevo.ToString())
         .AppendLine("      ,NumeroComprobante = " & numeroComprobanteNuevo.ToString())
         .AppendLine("   WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("     AND IdTipoComprobante = '" & idTipoComprobanteActual & "'")
         .AppendLine("     AND Letra = '" & letraActual & "'")
         .AppendLine("     AND CentroEmisor = " & centroEmisorActual.ToString())
         .AppendLine("     AND NumeroComprobante = " & numeroComprobanteActual.ToString())
      End With

      Execute(myQuery)
   End Sub

   Public Function GetInforme(sucursales As Entidades.Sucursal(),
                              periodoDesde As Integer, periodoHasta As Integer,
                              nombreCategoria As String, codigoCliente As Long,
                              idTipoLiquidacion As Integer,
                              numeroComprobante As Long,
                              letraFiscal As String,
                              centroEmisor As Integer,
                              listaComprobantes As List(Of Entidades.TipoComprobante),
                              liquidado As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         '.AppendLine("SELECT L.IdCargo")
         .AppendLine("SELECT L.Selecciono")
         .AppendLine("       ,L.PeriodoLiquidacion ")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,L.NombreCategoria")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         '.AppendLine("      ,L.CantAcciones")
         '.AppendLine("      ,L.FechaFirmaMandato")
         .AppendLine("      ,L.ImporteExpensas")
         '.AppendLine("      ,L.ImporteExpensaAdicionalEslora")
         '.AppendLine("      ,L.ImporteExpensaAdicionalAlturaTotal")
         .AppendLine("      ,L.ImporteAlquiler")
         .AppendLine("      ,L.ImporteServicios")
         .AppendLine("      ,L.ImporteGastosAdmin")
         '.AppendLine("      ,L.ImporteGastosIntermAlq")
         .AppendLine("      ,L.ImporteTotalAdicionales")
         .AppendLine("      ,L.ImporteTotal")
         '.AppendLine("      ,L.PrimerVto")
         '.AppendLine("      ,L.ImportePrimerVto")
         '.AppendLine("      ,L.SegundoVto")
         '.AppendLine("      ,L.ImporteSegundoVto")
         '.AppendLine("      ,L.SaldoAnterior")
         .AppendLine("      ,L.IdTipoComprobante	")
         .AppendLine("      ,L.Letra	")
         .AppendLine("      ,L.CentroEmisor	")
         .AppendLine("      ,L.NumeroComprobante")
         .AppendLine("  FROM LiquidacionesCargos L")
         .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = L.IdCliente")
         .AppendLine("  INNER JOIN Categorias CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica")
         .AppendLine(" WHERE L.PeriodoLiquidacion >= " & periodoDesde.ToString())
         .AppendLine("   AND L.PeriodoLiquidacion <= " & periodoHasta.ToString())
         GetListaSucursalesMultiples(stb, sucursales, "L")
         If Not String.IsNullOrEmpty(nombreCategoria) Then
            .AppendLine("   AND L.NombreCategoria = '" & nombreCategoria.ToString() & "'")
         End If

         If codigoCliente > 0 Then
            .AppendLine("   AND C.CodigoCliente = " & codigoCliente.ToString())
         End If
         .AppendLine("  AND IdTipoLiquidacion = " & idTipoLiquidacion)


         If listaComprobantes.Count > 0 Then
            .Append(" AND L.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComprobantes
               If tc IsNot Nothing Then
                  .AppendFormat(" '{0}',", tc.IdTipoComprobante)
               End If
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If letraFiscal <> "" Then
            .AppendLine("	 AND L.Letra = '" & letraFiscal.ToString() & "'")
         End If

         If centroEmisor > 0 Then
            .AppendLine("	 AND L.CentroEmisor = " & centroEmisor.ToString())
         End If

         If numeroComprobante > 0 Then
            .AppendLine("	 AND L.NumeroComprobante = " & numeroComprobante.ToString())
         End If

         If liquidado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("    AND L.Selecciono = '{0}'", If(liquidado = Entidades.Publicos.SiNoTodos.SI, "SI", "NO"))
         End If

         .AppendLine(" ORDER BY L.PeriodoLiquidacion, C.NombreCliente")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetInformeDetalle(sucursales As Entidades.Sucursal(),
                                     periodoDesde As Integer, periodoHasta As Integer,
                                     codigoCliente As Long,
                                     idTipoLiquidacion As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT L.PeriodoLiquidacion")
         .AppendLine("     , C.CodigoCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , C.NombreDeFantasia")
         .AppendLine("     , L.NombreCategoria")
         .AppendLine("     , ZG.NombreZonaGeografica")
         .AppendLine("     , L.ImporteExpensas")
         .AppendLine("     , L.ImporteAlquiler")
         .AppendLine("     , L.ImporteServicios")
         .AppendLine("     , L.ImporteGastosAdmin")
         .AppendLine("     , L.ImporteTotalAdicionales")
         .AppendLine("     , LDC.NombreCargo")
         .AppendLine("     , LDC.PrecioLista")
         .AppendLine("     , LDC.PrecioLista / 1.21 as PrecioListaSinIVA ")
         .AppendLine("     , LDC.DescuentoRecargoPorc1")
         .AppendLine("     , LDC.DescuentoRecargoPorcGral")
         .AppendLine("     , LDC.Importe")
         .AppendLine("  	, LDC.Importe / 1.21 as ImporteSinIVA")
         .AppendLine("  FROM LiquidacionesCargos L")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = L.IdCliente")
         .AppendLine(" INNER JOIN Categorias CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica")
         .AppendLine(" INNER JOIN LiquidacionesDetallesClientes LDC")
         .AppendLine("         ON LDC.PeriodoLiquidacion = L.PeriodoLiquidacion")
         .AppendLine("        AND LDC.IdLiquidacionCargo = L.IdLiquidacionCargo")
         .AppendLine("        AND LDC.IdSucursal = l.IdSucursal ")
         .AppendLine("        AND LDC.IdTipoLiquidacion = l.IdTipoLiquidacion ")
         .AppendLine(" WHERE L.PeriodoLiquidacion >= " & periodoDesde.ToString())
         .AppendLine("   AND L.PeriodoLiquidacion <= " & periodoHasta.ToString())
         GetListaSucursalesMultiples(stb, sucursales, "L")

         If codigoCliente > 0 Then
            .AppendFormatLine("   AND C.CodigoCliente = {0}", codigoCliente)
         End If

         .AppendFormatLine("   AND L.IdTipoLiquidacion = {0}", idTipoLiquidacion)
         .AppendFormatLine("   AND L.IdTipoComprobante IS NOT NULL")
         .AppendFormatLine(" ORDER BY L.PeriodoLiquidacion DESC, C.NombreCliente")
      End With

      Return GetDataTable(stb)
   End Function

End Class