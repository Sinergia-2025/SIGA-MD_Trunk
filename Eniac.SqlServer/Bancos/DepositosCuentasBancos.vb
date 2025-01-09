Public Class DepositosCuentasBancos
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub DepositosCuentasBancos_I(en As Entidades.DepositosCuentasBancos)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("INSERT INTO {0} (", Entidades.DepositosCuentasBancos.NombreTabla)
         .AppendFormatLine("   {0}", Entidades.DepositosCuentasBancos.Columnas.IdSucursal.ToString())
         .AppendFormatLine("   ,{0}", Entidades.DepositosCuentasBancos.Columnas.NumeroDeposito.ToString())
         .AppendFormatLine("   ,{0}", Entidades.DepositosCuentasBancos.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("   ,{0}", Entidades.DepositosCuentasBancos.Columnas.IdCuentaBanco.ToString())
         .AppendFormatLine("   ,{0}", Entidades.DepositosCuentasBancos.Columnas.IdTipoCuenta.ToString())
         .AppendFormatLine("   ,{0}", Entidades.DepositosCuentasBancos.Columnas.Importe.ToString())
         .AppendFormatLine("   ,{0}", Entidades.DepositosCuentasBancos.Columnas.Observacion.ToString())
         .AppendLine(") VALUES (")
         .AppendFormatLine("   {0}", en.IdSucursal)
         .AppendFormatLine("   ,{0}", en.NumeroDeposito)
         .AppendFormatLine("   ,'{0}'", en.IdTipoComprobante)
         .AppendFormatLine("   ,{0}", en.IdCuentaBanco)
         .AppendFormatLine("   ,'{0}'", en.IdTipoCuenta)
         .AppendFormatLine("   ,{0}", en.Importe)
         .AppendFormatLine("   ,'{0}'", en.Observacion)
         .AppendLine(")")
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Sub DepositosCuentasBancos_U(en As Entidades.DepositosCuentasBancos)
      Dim query As StringBuilder = New StringBuilder
      With query

         .AppendFormatLine("UPDATE {0} SET", Entidades.DepositosCuentasBancos.NombreTabla)
         .AppendFormatLine("     {0} = '{1}'", Entidades.DepositosCuentasBancos.Columnas.IdTipoCuenta.ToString(), en.IdTipoCuenta)
         .AppendFormatLine("     ,{0} = {1}", Entidades.DepositosCuentasBancos.Columnas.Importe.ToString(), en.Importe)
         .AppendFormatLine("     ,{0} = '{1}'", Entidades.DepositosCuentasBancos.Columnas.Observacion.ToString(), en.Observacion)
         .AppendFormatLine("  WHERE")
         .AppendFormatLine("   {0} = {1}", Entidades.DepositosCuentasBancos.Columnas.IdSucursal.ToString(), en.IdSucursal)
         .AppendFormatLine("   AND {0} = {1}", Entidades.DepositosCuentasBancos.Columnas.NumeroDeposito.ToString(), en.NumeroDeposito)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.DepositosCuentasBancos.Columnas.IdTipoComprobante.ToString(), en.IdTipoComprobante)
         .AppendFormatLine("   AND {0} = {1}", Entidades.DepositosCuentasBancos.Columnas.IdCuentaBanco.ToString(), en.IdCuentaBanco)

      End With
      Me.Execute(query.ToString())
   End Sub

   Public Sub DepositosCuentasBancos_D(en As Entidades.DepositosCuentasBancos)
      Dim query As StringBuilder = New StringBuilder
      With query

         .AppendFormatLine("DELETE {0}", Entidades.DepositosCuentasBancos.NombreTabla)
         .AppendFormatLine("  WHERE")
         .AppendFormatLine("   {0} = {1}", Entidades.DepositosCuentasBancos.Columnas.IdSucursal.ToString(), en.IdSucursal)
         .AppendFormatLine("   AND {0} = {1}", Entidades.DepositosCuentasBancos.Columnas.NumeroDeposito.ToString(), en.NumeroDeposito)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.DepositosCuentasBancos.Columnas.IdTipoComprobante.ToString(), en.IdTipoComprobante)
         .AppendFormatLine("   AND {0} = {1}", Entidades.DepositosCuentasBancos.Columnas.IdCuentaBanco.ToString(), en.IdCuentaBanco)

      End With
      Me.Execute(query.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("      DCB.IdSucursal")
         .AppendFormatLine("      ,DCB.NumeroDeposito")
         .AppendFormatLine("      ,DCB.IdTipoComprobante")
         .AppendFormatLine("      ,DCB.IdCuentaBanco	")
         .AppendFormatLine("      ,CB.NombreCuentaBanco")
         .AppendFormatLine("      ,CB.IdTipoCuenta")
         .AppendFormatLine("      ,DCB.Importe")
         .AppendFormatLine("      ,DCB.Observacion")
         .AppendFormatLine("FROM DepositosCuentasBancos DCB")
         .AppendFormatLine("INNER JOIN CuentasBancos CB ON DCB.IdCuentaBanco = CB.IdCuentaBanco")
      End With
   End Sub

   Public Function DepositosCuentasBancos_GA(idSucursal As Integer?,
                                             NumeroDeposito As Long?,
                                             IdTipoComprobante As String,
                                             IdCuentaBanco As Integer?) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendLine(" WHERE 1=1")

         If idSucursal.HasValue Then
            If idSucursal.Value > 0 Then
               .AppendFormatLine(" AND DCB.{0} = {1}", Entidades.DepositosCuentasBancos.Columnas.IdSucursal.ToString(), idSucursal.Value)
            End If
         End If
         If NumeroDeposito.HasValue Then
            If NumeroDeposito.Value > 0 Then
               .AppendFormatLine(" AND DCB.{0} = {1}", Entidades.DepositosCuentasBancos.Columnas.NumeroDeposito.ToString(), NumeroDeposito.Value)
            End If
         End If
         If Not String.IsNullOrEmpty(IdTipoComprobante) Then
            .AppendFormatLine(" AND DCB.{0} = '{1}'", Entidades.DepositosCuentasBancos.Columnas.IdTipoComprobante.ToString(), IdTipoComprobante)
         End If
         If IdCuentaBanco.HasValue Then
            If IdCuentaBanco.Value > 0 Then
               .AppendFormatLine(" AND DCB.{0} = {1}", Entidades.DepositosCuentasBancos.Columnas.IdCuentaBanco.ToString(), IdCuentaBanco.Value)
            End If
         End If
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub BorrarTodas(idSucursal As Integer, numeroDeposito As Long, idTipoComprobante As String)
      Dim query As StringBuilder = New StringBuilder
      With query

         .AppendFormatLine("DELETE {0}", Entidades.DepositosCuentasBancos.NombreTabla)
         .AppendFormatLine("  WHERE")
         .AppendFormatLine("   {0} = {1}", Entidades.DepositosCuentasBancos.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = {1}", Entidades.DepositosCuentasBancos.Columnas.NumeroDeposito.ToString(), numeroDeposito)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.DepositosCuentasBancos.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)

      End With
      Me.Execute(query.ToString())
   End Sub

End Class
