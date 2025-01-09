Public Class Depositos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Depositos_I(idSucursal As Integer,
                          numeroDeposito As Long,
                          idCuentaBancaria As Integer,
                          fecha As Date,
                          fechaAplicado As Date,
                          usoFechaCheque As Boolean,
                          importeTotal As Decimal,
                          observacion As String,
                          importePesos As Decimal,
                          importeDolares As Decimal,
                          importeCheques As Decimal,
                          importeTarjetas As Decimal,
                          importeTickets As Decimal,
                          idEstado As String,
                          idCaja As Integer,
                          idEjercicio As Integer?,
                          idPlanCuenta As Integer?,
                          idAsiento As Integer?,
                          idTipoComprobante As String,
                          idCuentaBancariaDestino As Integer,
                          cotizacionDolar As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Depositos")
         .AppendFormatLine("           (IdSucursal")
         .AppendFormatLine("           ,NumeroDeposito")
         .AppendFormatLine("           ,IdCuentaBancaria")
         .AppendFormatLine("           ,Fecha")
         .AppendFormatLine("           ,FechaAplicado")
         .AppendFormatLine("           ,UsoFechaCheque")
         .AppendFormatLine("           ,ImporteTotal")
         .AppendFormatLine("           ,Observacion")
         .AppendFormatLine("           ,importePesos")
         .AppendFormatLine("           ,importeDolares")
         .AppendFormatLine("           ,importeEuros")
         .AppendFormatLine("           ,importeCheques")
         .AppendFormatLine("           ,importeTarjetas")
         .AppendFormatLine("           ,ImporteTickets")
         .AppendFormatLine("           ,IdEstado")
         .AppendFormatLine("           ,IdCaja")
         .AppendFormatLine("           ,IdEjercicio")
         .AppendFormatLine("           ,IdPlanCuenta ")
         .AppendFormatLine("           ,IdAsiento ")
         .AppendFormatLine("           ,IdTipoComprobante")
         .AppendFormatLine("           ,IdCuentaBancariaDestino")
         .AppendFormatLine("           ,CotizacionDolar")

         .AppendFormatLine(")     VALUES")

         .AppendFormatLine("           (" & idSucursal.ToString())
         .AppendFormatLine("           ," & numeroDeposito.ToString())
         .AppendFormatLine("           ," & idCuentaBancaria.ToString())
         .AppendFormatLine("           ,'" & ObtenerFecha(fecha, True) & "'")
         .AppendFormatLine("           ,'" & ObtenerFecha(fechaAplicado, False) & "'")
         .AppendFormatLine("           ," & IIf(usoFechaCheque, 1, 0).ToString())
         .AppendFormatLine("           ," & importeTotal.ToString())
         .AppendFormatLine("           ,'" & observacion & "'")
         .AppendFormatLine("           ," & importePesos.ToString())
         .AppendFormatLine("           ," & importeDolares.ToString())
         .AppendFormatLine("           ," & "0")
         .AppendFormatLine("           ," & importeCheques.ToString())
         .AppendFormatLine("           ," & importeTarjetas.ToString())
         .AppendFormatLine("           ," & importeTickets.ToString())
         .AppendFormatLine("           ,'" & idEstado & "'")
         .AppendFormatLine("           ," & idCaja.ToString())
         If idEjercicio.HasValue Then
            .AppendLine(" ," + idEjercicio.Value.ToString())
         Else
            .AppendLine(" ,NULL")
         End If
         If idPlanCuenta.HasValue Then
            .AppendLine(" ," + idPlanCuenta.Value.ToString())
         Else
            .AppendLine(" ,NULL")
         End If
         If idAsiento.HasValue Then
            .AppendLine(" ," + idAsiento.Value.ToString())
         Else
            .AppendLine(" ,NULL")
         End If
         .AppendLine("           ,'" & idTipoComprobante & "'")

         If idCuentaBancariaDestino > 0 Then
            .AppendLine("           ," & idCuentaBancariaDestino.ToString())
         Else
            .AppendLine(" ,NULL")
         End If
         .AppendFormatLine("           ,{0}", cotizacionDolar)

         .AppendLine(")")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Depositos")

   End Sub

   Public Sub AnularDeposito(idSucursal As Integer,
                             numeroDeposito As Long,
                             idTipoComprobante As String,
                             idEstado As String,
                             observacion As String)

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendFormatLine("UPDATE Depositos")
         .AppendFormatLine("   SET IdEstado = '{0}'", idEstado)
         .AppendFormatLine("     , ImporteTotal = 0")
         .AppendFormatLine("     , Observacion = '{0}'", observacion)
         .AppendFormatLine("     , ImportePesos = 0")
         .AppendFormatLine("     , ImporteDolares = 0")
         .AppendFormatLine("     , ImporteEuros = 0")
         .AppendFormatLine("     , ImporteCheques = 0")
         .AppendFormatLine("     , ImporteTarjetas = 0")
         .AppendFormatLine("     , ImporteTickets = 0")
         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND NumeroDeposito = {0}", numeroDeposito)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
      End With

      Execute(stbQuery)
   End Sub


   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT D.IdSucursal")
         .AppendLine("      ,D.NumeroDeposito")
         .AppendLine("      ,D.IdCuentaBancaria")
         .AppendLine("      ,CB.NombreCuenta")
         .AppendLine("      ,D.IdCuentaBancariaDestino")
         .AppendLine("      ,CB2.NombreCuenta NombreCuentaDestino")
         .AppendLine("      ,D.Fecha")
         .AppendLine("      ,D.FechaAplicado")
         .AppendLine("      ,D.ImportePesos")
         .AppendLine("      ,D.ImporteDolares")
         .AppendLine("      ,D.ImporteEuros")
         .AppendLine("      ,D.ImporteCheques")
         .AppendLine("      ,D.ImporteTarjetas")
         .AppendLine("      ,D.ImporteTickets")
         .AppendLine("      ,D.ImporteTotal")
         .AppendLine("      ,D.UsoFechaCheque")
         .AppendLine("      ,D.Observacion")
         .AppendLine("      ,D.IdEstado")
         .AppendLine("      ,D.IdCaja")
         .AppendLine("      ,CN.NombreCaja")
         .AppendLine("      ,D.IdEjercicio")
         .AppendLine("      ,D.IdPlanCuenta")
         .AppendLine("      ,D.IdAsiento")
         .AppendLine("      ,D.IdTipoComprobante")
         .AppendLine("      ,TC.Descripcion")
         .AppendLine("      ,D.CotizacionDolar")
         .AppendLine("	FROM Depositos D ")
         .AppendLine(" INNER JOIN CuentasBancarias CB ON D.IdCuentaBancaria = CB.IdCuentaBancaria ")
         .AppendLine(" INNER JOIN TiposComprobantes TC on D.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  LEFT JOIN CuentasBancarias CB2 on D.IdCuentaBancariaDestino = CB2.IdCuentaBancaria")
         .AppendLine("  LEFT JOIN CajasNombres CN ON CN.IdCaja = D.IdCaja AND CN.IdSucursal = D.IdSucursal")
      End With
   End Sub

   Public Function Depositos_GA() As DataTable
      Return Depositos_G(idSucursal:=0, numeroDeposito:=0, IdTipoComprobante:=String.Empty)
   End Function
   Private Function Depositos_G(idSucursal As Integer, numeroDeposito As Long, idTipoComprobante As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormatLine("   AND D.IdSucursal = {0}", idSucursal)
         End If
         If numeroDeposito > 0 Then
            .AppendFormatLine("   AND D.NumeroDeposito = {0}", numeroDeposito)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND D.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If
      End With
      Return GetDataTable(stb)
   End Function
   Public Function Depositos_G1(idSucursal As Integer, numeroDeposito As Long, idTipoComprobante As String) As DataTable
      Return Depositos_G(idSucursal, numeroDeposito, idTipoComprobante)
   End Function

   Public Function GetPorRangoFechas(idSucursal As Integer,
                                     desde As Date,
                                     hasta As Date,
                                     idCuentaBancaria As Integer,
                                     idEstado As String,
                                     idCaja As Integer,
                                     idTipoComprobante As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE D.IdSucursal = {0}", idSucursal)
         If idTipoComprobante <> "" AndAlso idTipoComprobante <> "TODOS" Then
            .AppendFormatLine(" AND D.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If
         If idCaja <> 0 Then
            .AppendFormatLine("  AND D.IdCaja = {0}", idCaja)
         End If
         If desde.Year > 1 Then
            .AppendFormatLine("   AND D.Fecha >= '{0}'", ObtenerFecha(desde, False))
            .AppendFormatLine("   AND D.Fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))
         End If

         If idCuentaBancaria > 0 Then
            .AppendFormatLine("  AND D.IdCuentaBancaria = {0}", idCuentaBancaria)
         End If

         If idEstado <> "TODOS" Then
            .AppendFormatLine(" AND D.IdEstado = '{0}'", idEstado)
         End If

         .AppendLine("	ORDER BY D.Fecha")
      End With

      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo(idSucursal As Integer, idTipoComprobante As String) As Integer
      Return GetCodigoMaximo("NumeroDeposito", "Depositos",
                             String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}'",
                                           idSucursal, idTipoComprobante)).ToInteger()
   End Function

End Class