Public Class DepositosTarjetasCupones
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub DepositosTarjetasCupones_I(en As Entidades.DepositosTarjetasCupones)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("INSERT INTO {0} (", Entidades.DepositosTarjetasCupones.NombreTabla)
         .AppendFormatLine("   {0}", Entidades.DepositosTarjetasCupones.Columnas.IdSucursal.ToString())
         .AppendFormatLine("   ,{0}", Entidades.DepositosTarjetasCupones.Columnas.NumeroDeposito.ToString())
         .AppendFormatLine("   ,{0}", Entidades.DepositosTarjetasCupones.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("   ,{0}", Entidades.DepositosTarjetasCupones.Columnas.IdTarjetaCupon.ToString())
         .AppendLine(") VALUES (")
         .AppendFormatLine("   {0}", en.IdSucursal)
         .AppendFormatLine("   ,{0}", en.NumeroDeposito)
         .AppendFormatLine("   ,'{0}'", en.IdTipoComprobante)
         .AppendFormatLine("   ,{0}", en.IdTarjetaCupon)
         .AppendLine(")")
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Sub DepositosTarjetasCupones_U(en As Entidades.DepositosTarjetasCupones)

      '#############################################
      '# Éste método por ahora no se va a utilizar #
      '#############################################

   End Sub

   Public Sub DepositosTarjetasCupones_D(en As Entidades.DepositosTarjetasCupones)
      Dim query As StringBuilder = New StringBuilder
      With query

         .AppendFormatLine("DELETE {0}", Entidades.DepositosTarjetasCupones.NombreTabla)
         .AppendFormatLine("  WHERE")
         .AppendFormatLine("     {0} = {1}", Entidades.DepositosTarjetasCupones.Columnas.IdSucursal.ToString(), en.IdSucursal)
         .AppendFormatLine("     AND {0} = {1}", Entidades.DepositosTarjetasCupones.Columnas.NumeroDeposito.ToString(), en.NumeroDeposito)
         .AppendFormatLine("     AND {0} = '{1}'", Entidades.DepositosTarjetasCupones.Columnas.IdTipoComprobante.ToString(), en.IdTipoComprobante)
         .AppendFormatLine("     AND {0} = {1}", Entidades.DepositosTarjetasCupones.Columnas.IdTarjetaCupon.ToString(), en.IdTarjetaCupon)

      End With
      Me.Execute(query.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("  SELECT")
         .AppendLine("	       DTC.IdSucursal")
         .AppendLine("	      ,DTC.NumeroDeposito")
         .AppendLine("	      ,DTC.IdTipoComprobantE")
         .AppendLine("	      ,DTC.IdTarjetaCupon")
         .AppendLine("	      ,T.NombreTarjeta")
         .AppendLine("	      ,B.NombreBanco")
         .AppendLine("	      ,TC.Monto")
         .AppendLine("	      ,TC.FechaEmision")
         .AppendLine("	      ,TC.NumeroCupon")
         .AppendLine("	      ,TC.NumeroLote")
         .AppendLine("	      ,TC.Cuotas")
         .AppendLine("	      ,C.NombreCliente")
         .AppendLine("FROM DepositosTarjetasCupones DTC")
         .AppendLine("INNER JOIN TarjetasCupones TC ON DTC.IdTarjetaCupon = TC.IdTarjetaCupon")
         .AppendLine("INNER JOIN Tarjetas T ON TC.IdTarjeta = T.IdTarjeta")
         .AppendLine("INNER JOIN Bancos B ON TC.IdBanco = B.IdBanco")
         .AppendLine("LEFT JOIN Clientes C ON TC.IdCliente = C.IdCliente")
      End With
   End Sub

   Public Function DepositosTarjetasCupones_GA(idSucursal As Integer?,
                                             numeroDeposito As Long?,
                                             idTipoComprobante As String,
                                             idTarjetaCupon As Integer?) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendLine(" WHERE 1=1")

         If idSucursal.HasValue Then
            If idSucursal.Value > 0 Then
               .AppendFormatLine(" AND DTC.{0} = {1}", Entidades.DepositosTarjetasCupones.Columnas.IdSucursal.ToString(), idSucursal.Value)
            End If
         End If
         If numeroDeposito.HasValue Then
            If numeroDeposito.Value > 0 Then
               .AppendFormatLine(" AND DTC.{0} = {1}", Entidades.DepositosTarjetasCupones.Columnas.NumeroDeposito.ToString(), numeroDeposito.Value)
            End If
         End If
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine(" AND DTC.{0} = '{1}'", Entidades.DepositosTarjetasCupones.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If idTarjetaCupon.HasValue Then
            If idTarjetaCupon.Value > 0 Then
               .AppendFormatLine(" AND DTC.{0} = {1}", Entidades.DepositosTarjetasCupones.Columnas.IdTarjetaCupon.ToString(), idTarjetaCupon.Value)
            End If
         End If
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub BorrarTodos(idSucursal As Integer, numeroDeposito As Long, idTipoComprobante As String)
      Dim query As StringBuilder = New StringBuilder
      With query

         .AppendFormatLine("DELETE {0}", Entidades.DepositosTarjetasCupones.NombreTabla)
         .AppendFormatLine("  WHERE")
         .AppendFormatLine("     {0} = {1}", Entidades.DepositosTarjetasCupones.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("     AND {0} = {1}", Entidades.DepositosTarjetasCupones.Columnas.NumeroDeposito.ToString(), numeroDeposito)
         .AppendFormatLine("     AND {0} = '{1}'", Entidades.DepositosTarjetasCupones.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)

      End With
      Me.Execute(query.ToString())
   End Sub

End Class