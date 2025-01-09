Public Class VentasFormasPago
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasFormasPago_I(idFormasPago As Integer,
                                 descripcionFormasPago As String,
                                 dias As Integer,
                                 esTarjeta As Boolean,
                                 ordenVentas As Integer,
                                 ordenCompras As Integer,
                                 ordenFichas As Integer,
                                 cantidadCuotas As Integer,
                                 diasPrimerCuota As Integer,
                                 fechaBaseProximaCuota As Entidades.VentaFormaPago.ProximaCuota,
                                 excluyeSabados As Boolean,
                                 excluyeDomingos As Boolean,
                                 excluyeFeriados As Boolean,
                                 porcentaje As Decimal,
                                 requierePesos As Boolean,
                                 requiereDolares As Boolean,
                                 requiereTickets As Boolean,
                                 requiereTransferencia As Boolean,
                                 requiereCheques As Boolean,
                                 requiereTarjetaDebito As Boolean,
                                 requiereTarjetaCredito As Boolean,
                                 requiereTarjetaCredito1Pago As Boolean,
                                 idListaPrecios As Integer?,
                                 idTipoComprobante As String,
                                 idTipoComprobanteFR As String,
                                 idCuentaBancariaEfectivo As Integer?,
                                 archivoComplementario As String,
                                 archivoImprimirEmbebido As Boolean,
                                 aplicanOfertas As Boolean,
                                 descripcion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO VentasFormasPago")
         .AppendFormatLine("   ( IdFormasPago")
         .AppendFormatLine("   , DescripcionFormasPago")
         .AppendFormatLine("   , Dias")
         .AppendFormatLine("   , EsTarjeta")
         .AppendFormatLine("   , OrdenVentas")
         .AppendFormatLine("   , OrdenCompras")
         .AppendFormatLine("   , OrdenFichas")
         .AppendFormatLine("   , CantidadCuotas")
         .AppendFormatLine("   , DiasPrimerCuota")
         .AppendFormatLine("   , FechaBaseProximaCuota")
         .AppendFormatLine("   , ExcluyeSabados")
         .AppendFormatLine("   , ExcluyeDomingos")
         .AppendFormatLine("   , ExcluyeFeriados")
         .AppendFormatLine("   , Porcentaje")

         .AppendFormatLine("   , RequierePesos")
         .AppendFormatLine("   , RequiereDolares")
         .AppendFormatLine("   , RequiereTickets")
         .AppendFormatLine("   , RequiereTransferencia")
         .AppendFormatLine("   , RequiereCheques")
         .AppendFormatLine("   , RequiereTarjetaDebito")
         .AppendFormatLine("   , RequiereTarjetaCredito")
         .AppendFormatLine("   , RequiereTarjetaCredito1Pago")
         .AppendFormatLine("   , IdListaPrecios")                             '-.PE-33091.-
         .AppendFormatLine("   , IdTipoComprobantes")                          '-.REG-33317.-
         .AppendFormatLine("   , IdTipoComprobantesFR")                        '-.REG-33409.-
         .AppendFormatLine("   , IdCuentaBancariaEfectivo")
         '-- REQ-35955.- ------------------------------------
         .AppendFormatLine("   , ArchivoComplementario")
         .AppendFormatLine("   , ArchivoAImprimirEmbebido")
         '---------------------------------------------------
         .AppendFormatLine("   , AplicanOfertas")
         .AppendFormatLine("   , Descripcion")

         .AppendFormatLine("   ) VALUES ( ")
         .AppendFormatLine("     {0} ", idFormasPago)
         .AppendFormatLine("   ,'{0}'", descripcionFormasPago)
         .AppendFormatLine("   , {0} ", dias)
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(esTarjeta))
         .AppendFormatLine("   , {0} ", ordenVentas)
         .AppendFormatLine("   , {0} ", ordenCompras)
         .AppendFormatLine("   , {0} ", ordenFichas)
         .AppendFormatLine("   , {0} ", cantidadCuotas)
         .AppendFormatLine("   , {0} ", diasPrimerCuota)
         .AppendFormatLine("   ,'{0}' ", fechaBaseProximaCuota.ToString())
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(excluyeSabados))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(excluyeDomingos))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(excluyeFeriados))
         .AppendFormatLine("   , {0} ", porcentaje)

         .AppendFormatLine("   , {0} ", GetStringFromBoolean(requierePesos))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(requiereDolares))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(requiereTickets))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(requiereTransferencia))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(requiereCheques))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(requiereTarjetaDebito))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(requiereTarjetaCredito))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(requiereTarjetaCredito1Pago))
         .AppendFormatLine("   , {0} ", GetStringFromNumber(idListaPrecios))     '-.PE-33091.-

         If idTipoComprobante IsNot Nothing Then
            .AppendFormatLine("   , '{0}' ", idTipoComprobante.ToString())         '-.REQ-33317.-
         Else
            .AppendLine("   , NULL ")                                            '-.REQ-33317.-
         End If
         If idTipoComprobanteFR IsNot Nothing Then
            .AppendFormatLine("   , '{0}' ", idTipoComprobanteFR.ToString())         '-.REQ-33409.-
         Else
            .AppendLine("   , NULL ")                                            '-.REQ-33409.-
         End If
         .AppendFormatLine("   , {0} ", GetStringFromNumber(idCuentaBancariaEfectivo))

         '-- REQ-35955.- -------------------------------------------------------------
         If Not String.IsNullOrEmpty(archivoComplementario) Then
            .AppendFormatLine("   , '{0}' ", archivoComplementario)
         Else
            .AppendLine("   , NULL ")
         End If
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(archivoImprimirEmbebido))
         '----------------------------------------------------------------------------
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(aplicanOfertas))
         .AppendFormatLine("   ,'{0}'", descripcion)
         .AppendFormatLine("   )")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasFormasPago")
   End Sub

   Public Sub VentasFormasPago_U(idFormasPago As Integer,
                                 descripcionFormasPago As String,
                                 dias As Integer,
                                 esTarjeta As Boolean,
                                 ordenVentas As Integer,
                                 ordenCompras As Integer,
                                 ordenFichas As Integer,
                                 cantidadCuotas As Integer,
                                 diasPrimerCuota As Integer,
                                 fechaBaseProximaCuota As Entidades.VentaFormaPago.ProximaCuota,
                                 excluyeSabados As Boolean,
                                 excluyeDomingos As Boolean,
                                 excluyeFeriados As Boolean,
                                 porcentaje As Decimal,
                                 requierePesos As Boolean,
                                 requiereDolares As Boolean,
                                 requiereTickets As Boolean,
                                 requiereTransferencia As Boolean,
                                 requiereCheques As Boolean,
                                 requiereTarjetaDebito As Boolean,
                                 requiereTarjetaCredito As Boolean,
                                 requiereTarjetaCredito1Pago As Boolean,
                                 idListaPrecios As Integer?,
                                 idTipoComprobante As String,
                                 idTipoComprobanteFR As String,
                                 idCuentaBancariaEfectivo As Integer?,
                                 archivoComplementario As String,
                                 archivoImprimirEmbebido As Boolean,
                                 aplicanOfertas As Boolean,
                                 descripcion As String)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE VentasFormasPago")
         .AppendFormatLine(" SET DescripcionFormasPago = '{0}'", descripcionFormasPago)
         .AppendFormatLine("   , Dias = {0}", dias)
         .AppendFormatLine("   , EsTarjeta = {0}", GetStringFromBoolean(esTarjeta))
         .AppendFormatLine("   , OrdenVentas = {0}", ordenVentas)
         .AppendFormatLine("   , OrdenCompras = {0}", ordenCompras)
         .AppendFormatLine("   , OrdenFichas = {0}", ordenFichas)
         .AppendFormatLine("   , CantidadCuotas = {0}", cantidadCuotas)
         .AppendFormatLine("   , DiasPrimerCuota = {0}", diasPrimerCuota)
         .AppendFormatLine("   , FechaBaseProximaCuota = '{0}'", fechaBaseProximaCuota.ToString())
         .AppendFormatLine("   , ExcluyeSabados = {0}", GetStringFromBoolean(excluyeSabados))
         .AppendFormatLine("   , ExcluyeDomingos = {0}", GetStringFromBoolean(excluyeDomingos))
         .AppendFormatLine("   , ExcluyeFeriados = {0}", GetStringFromBoolean(excluyeFeriados))
         .AppendFormatLine("   , Porcentaje = {0}", porcentaje)

         .AppendFormatLine("   , RequierePesos = {0}", GetStringFromBoolean(requierePesos))
         .AppendFormatLine("   , RequiereDolares = {0}", GetStringFromBoolean(requiereDolares))
         .AppendFormatLine("   , RequiereTickets = {0}", GetStringFromBoolean(requiereTickets))
         .AppendFormatLine("   , RequiereTransferencia = {0}", GetStringFromBoolean(requiereTransferencia))
         .AppendFormatLine("   , RequiereCheques = {0}", GetStringFromBoolean(requiereCheques))
         .AppendFormatLine("   , RequiereTarjetaDebito = {0}", GetStringFromBoolean(requiereTarjetaDebito))
         .AppendFormatLine("   , RequiereTarjetaCredito = {0}", GetStringFromBoolean(requiereTarjetaCredito))
         .AppendFormatLine("   , RequiereTarjetaCredito1Pago = {0}", GetStringFromBoolean(requiereTarjetaCredito1Pago))
         .AppendFormatLine("   , IdListaPrecios = {0}", GetStringFromNumber(idListaPrecios)) '-.PE-33091.-
         If idTipoComprobante IsNot Nothing Then
            .AppendFormatLine("   , IdTipoComprobantes = '{0}'", idTipoComprobante.ToString())  '-- REG-33317.- --
         Else
            .AppendLine("   , IdTipoComprobantes = NULL")  '-- REG-33317.- --
         End If
         If idTipoComprobanteFR IsNot Nothing Then
            .AppendFormatLine("   , IdTipoComprobantesFR = '{0}'", idTipoComprobanteFR.ToString())  '-- REG-33409.- --
         Else
            .AppendLine("   , IdTipoComprobantesFR = NULL")  '-- REG-33409.- --
         End If
         .AppendFormatLine("   , IdCuentaBancariaEfectivo = {0}", GetStringFromNumber(idCuentaBancariaEfectivo))

         '-- REQ-35955.- -------------------------------------------------------------
         If Not String.IsNullOrEmpty(archivoComplementario) Then
            .AppendFormatLine("   , ArchivoComplementario =  '{0}' ", archivoComplementario)
         Else
            .AppendLine("   , ArchivoComplementario = NULL ")
         End If
         .AppendFormatLine("   , ArchivoAImprimirEmbebido = {0}", GetStringFromBoolean(archivoImprimirEmbebido))
         '----------------------------------------------------------------------------
         .AppendFormatLine("   , AplicanOfertas = {0}", GetStringFromBoolean(aplicanOfertas))
         .AppendFormatLine(" ,Descripcion = '{0}'", descripcion)

         .AppendFormatLine(" WHERE IdFormasPago = {0}", idFormasPago)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasFormasPago")

   End Sub

   Public Sub VentasFormasPago_D(idFormasPago As Integer)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM VentasFormasPago")
         .AppendFormatLine(" WHERE IdFormasPago = {0}", idFormasPago)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasFormasPago")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, filtrarPorSucursales As Boolean)
      With stb
         .AppendFormatLine("SELECT FP.*")
         If filtrarPorSucursales Then
            .AppendFormatLine("     , FPS.*")
         End If
         .AppendFormatLine("     , LP.NombreListaPrecios")
         .AppendFormatLine("     , CB.CodigoBancario")
         .AppendFormatLine("     , CB.NombreCuenta")
         .AppendFormatLine("  FROM VentasFormasPago FP")
         .AppendFormatLine("  LEFT JOIN ListasDePrecios LP ON LP.IdListaPrecios = FP.IdListaPrecios") '-.PE-33091.-
         .AppendFormatLine("  LEFT JOIN CuentasBancarias CB ON CB.IdCuentaBancaria = FP.IdCuentaBancariaEfectivo") '-.PE-33091.-
         If filtrarPorSucursales Then
            .AppendFormatLine("INNER JOIN {0} FPS ON FP.{1} = FPS.{1}",
                              Entidades.VentasFormasPagoSucursales.NombreTabla,
                              Entidades.VentasFormasPagoSucursales.Columnas.IdFormasPago.ToString())
            .AppendLine(" WHERE 1=1")
         End If
      End With
   End Sub

   Public Function VentasFormasPago_GA() As DataTable
      '# No hago el JOIN para que me traiga todas las FP y así poder asignarlas a la sucursal.
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, filtrarPorSucursales:=False)
         .AppendFormatLine(" ORDER BY FP.DescripcionFormasPago")
      End With

      Return GetDataTable(myQuery)
   End Function

   Public Function VentasFormasPago_G1(idFormaPago As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, filtrarPorSucursales:=True)
         .AppendFormatLine(" AND FP.IdFormasPago = {0}", idFormaPago)
         .AppendFormatLine(" ORDER BY FP.DescripcionFormasPago")
      End With

      Return GetDataTable(myQuery)
   End Function

   Public Function VentasFormasPagoTipo(tipo As String, contado As Boolean?, idSucursal As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, filtrarPorSucursales:=True)

         If tipo = "VENTAS" Then
            .AppendFormatLine("  AND FP.OrdenVentas <> 0 ")
         End If
         If tipo = "COMPRAS" Then
            .AppendFormatLine("  AND FP.OrdenCompras <> 0 ")
         End If
         If tipo = "FICHAS" Then
            .AppendFormatLine("  AND FP.OrdenFichas <> 0 ")
         End If
         If contado.HasValue Then
            If contado.Value Then
               .AppendFormatLine("   AND FP.Dias = 0")
            Else
               .AppendFormatLine("   AND FP.Dias > 0")
            End If
         End If

         ' # Formas de Pago asociadas a la Sucursal
         .AppendFormatLine("  AND FPS.{0} = {1} ", Entidades.VentasFormasPagoSucursales.Columnas.IdSucursal.ToString(), idSucursal)

         If tipo = "VENTAS" Then
            .AppendFormatLine("ORDER BY FP.OrdenVentas ")
         End If
         If tipo = "COMPRAS" Then
            .AppendFormatLine("ORDER BY FP.OrdenCompras ")
         End If
         If tipo = "FICHAS" Then
            .AppendFormatLine("ORDER BY FP.OrdenFichas ")
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdFormasPago", "VentasFormasPago"))
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb, filtrarPorSucursales:=True), "FP.",
                    New Dictionary(Of String, String) From {{"NombreListaPrecios", "LP.NombreListaPrecios"}})
   End Function
   Public Function GetPorCodigo(idFormaPago As Integer, descripcion As String, tipo As String, esContado As Boolean?, idSucursal As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery, filtrarPorSucursales:=True)

         If tipo = "VENTAS" Then
            .AppendFormatLine("  AND FP.OrdenVentas <> 0 ")
         End If
         If tipo = "COMPRAS" Then
            .AppendFormatLine("  AND FP.OrdenCompras <> 0 ")
         End If
         If tipo = "FICHAS" Then
            .AppendFormatLine("  AND FP.OrdenFichas <> 0 ")
         End If
         If esContado.HasValue Then
            If esContado.Value Then
               .AppendFormatLine("   AND FP.Dias = 0")
            Else
               .AppendFormatLine("   AND FP.Dias > 0")
            End If
         End If
         If idFormaPago > 0 Then
            .AppendFormatLine(" AND FP.IdFormasPago = {0}", idFormaPago)
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            .AppendFormatLine(" AND FP.DescripcionFormasPago LIKE '%{0}%' ", descripcion)
         End If

         ' # Formas de Pago asociadas a la Sucursal
         .AppendFormatLine("  AND FPS.{0} = {1} ", Entidades.VentasFormasPagoSucursales.Columnas.IdSucursal.ToString(), idSucursal)

         If tipo = "VENTAS" Then
            .AppendFormatLine("ORDER BY FP.OrdenVentas ")
         End If
         If tipo = "COMPRAS" Then
            .AppendFormatLine("ORDER BY FP.OrdenCompras ")
         End If
         If tipo = "FICHAS" Then
            .AppendFormatLine("ORDER BY FP.OrdenFichas ")
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

End Class