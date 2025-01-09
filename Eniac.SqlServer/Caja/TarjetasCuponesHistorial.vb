Public Class TarjetasCuponesHistorial
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT TCH.*")
         .AppendLine("      ,B.NombreBanco")
         .AppendLine("      ,Cl.NombreCliente")
         .AppendLine("      ,CNI.NombreCaja NombreCajaIngreso")
         .AppendLine("      ,CNe.NombreCaja NombreCajaEgreso")

         .AppendLine("  FROM TarjetasCuponesHistorial TCH")

         .AppendLine("  INNER JOIN Bancos B ON TCH.IdBanco = B.IdBanco ")
         .AppendLine("  LEFT OUTER JOIN Clientes Cl ON TCH.IdCliente = Cl.IdCliente ")
         .AppendLine("  LEFT OUTER JOIN Proveedores P ON TCH.IdProveedor = P.IdProveedor ")
         .AppendLine("  LEFT JOIN CajasDetalle CI ON TCH.NroPlanillaIngreso = CI.NumeroPlanilla AND TCH.NroMovimientoIngreso = CI.NumeroMovimiento  AND TCH.IdCajaIngreso = CI.IdCaja AND CI.IdSucursal =TCH.IdSucursal ")
         .AppendLine("  LEFT JOIN CajasDetalle CE ON TCH.NroPlanillaEgreso = CE.NumeroPlanilla AND TCH.NroMovimientoEgreso = CE.NumeroMovimiento AND TCH.IdCajaEgreso = CE.IdCaja AND CE.IdSucursal =TCH.IdSucursal  ")
         .AppendLine("  LEFT JOIN CajasNombres CNI ON TCH.IdSucursal = CNI.IdSucursal AND TCH.IdCajaIngreso = CNI.IdCaja")
         .AppendLine("  LEFT JOIN CajasNombres CNE ON TCH.IdSucursal = CNE.IdSucursal AND TCH.IdCajaEgreso = CNE.IdCaja")
      End With
   End Sub

   Public Function Buscar(columna As String, valor As String) As DataTable

      columna = "TCH." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function


   Public Function TarjetasCupones_G1(idSucursal As Integer, idTarjetasCupon As Integer) As DataTable
      Return TarjetasCupones_GA(idSucursal:=idSucursal, IdTarjetaCupon:=idTarjetasCupon, fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing, idEstadoTarjeta:=Entidades.TarjetaCupon.Estados.NINGUNO.ToString(),
                                 fechaLiquidacionDesde:=Nothing, fechaLiquidacionHasta:=Nothing, numeroCupon:=0, numeroLote:=0, fechaEnCarteraAl:=Nothing,
                                  idCaja:=0, idBanco:=0, idCliente:=0, orden:=String.Empty)
   End Function
   Public Function TarjetasCupones_GA() As DataTable
      Return TarjetasCupones_GA(idSucursal:=0, IdTarjetaCupon:=0, fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing, idEstadoTarjeta:=Entidades.TarjetaCupon.Estados.NINGUNO.ToString(),
                                 fechaLiquidacionDesde:=Nothing, fechaLiquidacionHasta:=Nothing, numeroCupon:=0, numeroLote:=0, fechaEnCarteraAl:=Nothing,
                                  idCaja:=0, idBanco:=0, idCliente:=0, orden:=String.Empty)
   End Function

   Public Function TarjetasCupones_GA(idSucursal As Integer,
                                       IdTarjetaCupon As Integer,
                                       fechaIngresoDesde As Date?, _
                                       fechaIngresoHasta As Date?,
                                       idEstadoTarjeta As String,
                                       fechaLiquidacionDesde As Date?, _
                                       fechaLiquidacionHasta As Date?,
                                       numeroCupon As Integer,
                                       numeroLote As Integer,
                                       fechaEnCarteraAl As Date?,
                                       idCaja As Integer,
                                       idBanco As Integer,
                                       idCliente As Long,
                                       orden As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)


         .AppendFormatLine(" WHERE 1 = 1")

         If idSucursal > 0 Then
            .AppendFormatLine("   AND TCH.{0} = {1}", Entidades.TarjetaCupon.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If IdTarjetaCupon > 0 Then
            .AppendFormatLine("   AND TCH.{0} = {1}", Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString(), IdTarjetaCupon)
         End If

         If fechaIngresoDesde.HasValue And fechaIngresoHasta.HasValue Then
            .AppendFormatLine("	AND TCH.FechaEmision Between '{0}' AND '{1}'", ObtenerFecha(fechaIngresoDesde.Value.Date, False), ObtenerFecha(fechaIngresoHasta.Value.Date.AddDays(1).AddSeconds(-1), True))
         End If

         If idEstadoTarjeta <> Entidades.TarjetaCupon.Estados.NINGUNO.ToString() Then
            .AppendFormatLine("   AND TCH.{0} = '{1}'", Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString(), idEstadoTarjeta)
         End If

         If fechaLiquidacionDesde.HasValue And fechaLiquidacionHasta.HasValue Then
            .AppendFormatLine("	AND TCH.FechaActualizacion Between '{0}' AND '{1}'", ObtenerFecha(fechaLiquidacionDesde.Value.Date, False), ObtenerFecha(fechaLiquidacionHasta.Value.Date.AddDays(1).AddSeconds(-1), True))
         End If

         If numeroCupon > 0 Then
            .AppendFormatLine("   AND TCH.{0} = {1}", Entidades.TarjetaCupon.Columnas.NumeroCupon.ToString(), numeroCupon)
         End If

         If numeroLote > 0 Then
            .AppendFormatLine("   AND TCH.{0} = {1}", Entidades.TarjetaCupon.Columnas.NumeroLote.ToString(), numeroLote)
         End If

         If fechaEnCarteraAl.HasValue Then
            .AppendFormatLine("	AND TCH.FechaEmision <= '{0}'", ObtenerFecha(fechaEnCarteraAl.Value.Date.AddDays(1).AddSeconds(-1), True))
         End If
         If idBanco > 0 Then
            .AppendFormatLine("   AND TCH.{0} = {1}", Entidades.TarjetaCupon.Columnas.IdBanco.ToString(), idBanco)
         End If

         If idCaja > 0 Then
            .AppendFormatLine("   AND TCH.{0} = {1}", Entidades.TarjetaCupon.Columnas.IdCajaIngreso.ToString(), idCaja)
         End If

         If idCliente > 0 Then
            .AppendFormatLine("	AND TCH.IdCliente = {0}", idCliente)
         End If

         If orden = Entidades.TarjetaCupon.Ordenamiento.FECHAACTUALIZACION.ToString() Then
            .AppendLine("   ORDER BY TCH.FechaActualizacion")
         ElseIf orden = Entidades.TarjetaCupon.Ordenamiento.NOMBREYFECHAACTUALIZACION.ToString() Then
            .AppendLine("   ORDER BY CL.NombreCliente, TCH.FechaActualizacion")
         End If

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class
