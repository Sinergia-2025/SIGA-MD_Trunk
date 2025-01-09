Public Class Tarjetas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Tarjetas_I(idTarjeta As Integer,
                         nombreTarjeta As String,
                         tipoTarjeta As Entidades.Tarjeta.TiposTarjetas,
                         habilitada As Boolean,
                         acreditacion As Boolean,
                         idCuentaBancaria As Integer,
                         cantDiasAcredit As Integer,
                         pagoPosVenta As Boolean,
                         pagoPosCorte As Boolean,
                         diaCorte As Integer,
                         pagoDiaMes As Boolean,
                         diaMes As Integer,
                         idCuentaContable As Long,
                         porcIntereses As Decimal,
                         cantidadCuotas As Integer,
                         idProveedor As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO Tarjetas")
         .AppendLine("           (IdTarjeta")
         .AppendLine("           ,NombreTarjeta")
         .AppendLine("           ,TipoTarjeta")
         .AppendLine("           ,Habilitada")
         .AppendLine("           ,Acreditacion")
         .AppendLine("           ,IdCuentaBancaria")
         .AppendLine("           ,CantDiasAcredit")
         .AppendLine("           ,PagoPosVenta")
         .AppendLine("           ,PagoPosCorte")
         .AppendLine("           ,DiaCorte")
         .AppendLine("           ,PagoDiaMes")
         .AppendLine("           ,DiaMes")
         .AppendLine("           ,IdCuentaContable")
         .AppendLine("           ,PorcIntereses")
         .AppendLine("           ,CantidadCuotas")
         .AppendLine("           ,IdProveedor")
         .AppendLine("    )VALUES")
         .AppendFormat("           ({0}", idTarjeta)
         .AppendFormat("           ,'{0}'", nombreTarjeta)
         If tipoTarjeta = Entidades.Tarjeta.TiposTarjetas.Debito Then
            .AppendFormat("           ,'D'")
         ElseIf tipoTarjeta = Entidades.Tarjeta.TiposTarjetas.Credito Then
            .AppendFormat("           ,'C'")
         End If
         .AppendFormat("           ,{0}", GetStringFromBoolean(habilitada))
         .AppendFormat("           ,{0}", GetStringFromBoolean(acreditacion))
         If idCuentaBancaria > 0 Then
            .Append("           ," & idCuentaBancaria)
         Else
            .AppendFormat("           ,NULL")
         End If
         If cantDiasAcredit > 0 Then
            .AppendFormat("           ,{0}", cantDiasAcredit)
         Else
            .Append("           ,NULL")
         End If
         .AppendFormat("           ,{0}", GetStringFromBoolean(pagoPosVenta).ToString())
         .AppendFormat("           ,{0}", GetStringFromBoolean(pagoPosVenta).ToString())
         If diaCorte > 0 Then
            .AppendFormat("           ,{0}", diaCorte)
         Else
            .Append("           ,NULL")
         End If
         .AppendFormat("           ,{0}", GetStringFromBoolean(pagoDiaMes).ToString())
         If diaMes > 0 Then
            .AppendFormat("           ,{0}", diaMes)
         Else
            .Append("           ,NULL")
         End If
         If idCuentaContable > 0 Then
            .AppendFormat("           ,{0}", idCuentaContable)
         Else
            .Append("           ,NULL")
         End If

         'If PorcIntereses > 0 Then
         .AppendFormat("           ,{0}", porcIntereses)
         'Else
         '   .Append("           ,NULL")
         'End If

         'If CantidadCuotas > 0 Then
         .AppendFormat("           ,{0}", cantidadCuotas)
         'Else
         '   .Append("           ,NULL")
         'End If

         If idProveedor > 0 Then
            .AppendFormat("           ,{0}", idProveedor)
         Else
            .Append("           ,NULL")
         End If

         .Append(")")
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "Tarjetas")
   End Sub

   Public Sub Tarjetas_U(idTarjeta As Integer,
                         nombreTarjeta As String,
                         tipoTarjeta As Entidades.Tarjeta.TiposTarjetas,
                         habilitada As Boolean,
                         acreditacion As Boolean,
                         idCuentaBancaria As Integer,
                         cantDiasAcredit As Integer,
                         pagoPosVenta As Boolean,
                         pagoPosCorte As Boolean,
                         diaCorte As Integer,
                         pagoDiaMes As Boolean,
                         diaMes As Integer,
                         idCuentaContable As Long,
                         porcIntereses As Decimal,
                         cantidadCuotas As Integer,
                         idProveedor As Integer)
      Dim stb = New StringBuilder()
      With stb
         .Append("UPDATE Tarjetas")
         .Append("   SET ")
         .AppendFormat("      NombreTarjeta = '{0}'", nombreTarjeta)
         If tipoTarjeta = Entidades.Tarjeta.TiposTarjetas.Debito Then
            .AppendFormat("      ,TipoTarjeta = 'D'")
         ElseIf tipoTarjeta = Entidades.Tarjeta.TiposTarjetas.Credito Then
            .AppendFormat("      ,TipoTarjeta = 'C'")
         End If
         .AppendFormat("      ,Habilitada   = {0}", GetStringFromBoolean(habilitada))
         .AppendFormat("      ,Acreditacion = {0}", GetStringFromBoolean(acreditacion))

         If idCuentaBancaria <> 0 Then
            .AppendFormat("      ,IdCuentaBancaria = {0}", idCuentaBancaria)
         Else
            .AppendFormat("      ,IdCuentaBancaria = NULL")
         End If

         If acreditacion Then
            .AppendFormat("      ,CantDiasAcredit = {0}", cantDiasAcredit)
            If pagoPosVenta Then
               .AppendFormat("      ,DiaCorte = NULL")
               .AppendFormat("      ,DiaMes = NULL")
            Else
               If pagoPosCorte Then
                  .AppendFormat("      ,DiaCorte = {0}", diaCorte)
                  .AppendFormat("      ,DiaMes = NULL")
               Else
                  .AppendFormat("      ,DiaCorte = {0}", diaCorte)
                  .AppendFormat("      ,DiaMes = {0}", diaMes)
               End If

            End If
         Else
            .AppendFormat("      ,CantDiasAcredit =  NULL")
            .AppendFormat("      ,DiaCorte = NULL")
            .AppendFormat("      ,DiaMes = NULL")
         End If
         .AppendFormat("      ,PagoPosVenta = {0}", GetStringFromBoolean(pagoPosVenta))
         .AppendFormat("      ,PagoPosCorte = {0}", GetStringFromBoolean(pagoPosCorte))
         .AppendFormat("      ,PagoDiaMes = {0}", GetStringFromBoolean(pagoDiaMes))

         If idCuentaContable > 0 Then
            .AppendFormat("      ,IdCuentaContable = {0}", idCuentaContable)
         Else
            .AppendFormat("      ,IdCuentaContable = NULL")
         End If

         'If PorcIntereses > 0 Then
         .AppendFormat("      ,PorcIntereses = {0}", porcIntereses)
         'Else
         '   .AppendFormat("      ,PorcIntereses = NULL")
         'End If

         'If CantidadCuotas > 0 Then
         .AppendFormat("      ,CantidadCuotas = {0}", cantidadCuotas)
         'Else
         '   .AppendFormat("      ,CantidadCuotas = NULL")
         'End If

         If idProveedor <> 0 Then
            .AppendFormat("      ,IdProveedor = {0}", idProveedor)
         Else
            .AppendFormat("      ,IdProveedor = NULL")
         End If

         .AppendFormat(" WHERE IdTarjeta = {0}", idTarjeta)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "Tarjetas")
   End Sub

   Public Sub Tarjetas_D(IdTarjeta As Integer)
      Dim stb = New StringBuilder()
      stb.AppendFormat("DELETE FROM Tarjetas WHERE IdTarjeta = {0}", IdTarjeta)

      Execute(stb)
      Sincroniza_I(stb.ToString(), "Tarjetas")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT T.IdTarjeta")
         .AppendLine("      ,T.NombreTarjeta")
         .AppendLine("      ,T.TipoTarjeta")
         .AppendLine("      ,T.Habilitada")
         .AppendLine("      ,T.Acreditacion")
         .AppendLine("      ,T.IdCuentaBancaria")
         .AppendLine("      ,CB.NombreCuenta")
         .AppendLine("      ,T.CantDiasAcredit")
         .AppendLine("      ,T.PagoPosVenta")
         .AppendLine("      ,T.PagoPosCorte")
         .AppendLine("      ,T.DiaCorte   ")
         .AppendLine("      ,(SELECT ")
         .AppendLine("             ( CASE WHEN T.DiaCorte = NULL THEN 'NULL' ELSE '' END ) +")
         .AppendLine("             ( CASE WHEN T.DiaCorte = 0 THEN 'Lunes' ELSE '' END ) +")
         .AppendLine("             ( CASE WHEN T.DiaCorte = 1 THEN 'Martes' ELSE '' END ) +")
         .AppendLine("             ( CASE WHEN T.DiaCorte = 2 THEN 'Miercoles' ELSE '' END ) +")
         .AppendLine("             ( CASE WHEN T.DiaCorte = 3 THEN 'Jueves' ELSE '' END ) +")
         .AppendLine("             ( CASE WHEN T.DiaCorte = 4 THEN 'Viernes' ELSE '' END )) DiaDeCorte")
         .AppendLine("      ,T.PagoDiaMes ")
         .AppendLine("      ,T.DiaMes")
         .AppendLine("      ,T.IdCuentaContable")
         .AppendLine("      ,CC.NombreCuenta AS NombreCuentaContable")
         .AppendLine("      ,T.PorcIntereses")
         .AppendLine("      ,T.CantidadCuotas")
         .AppendLine("      ,T.IdProveedor")
         .AppendLine("      ,PRV.CodigoProveedor")
         .AppendLine("      ,PRV.NombreProveedor")
         .AppendLine("  FROM Tarjetas T ")
         .AppendLine(" LEFT JOIN CuentasBancarias CB ON CB.IdCuentaBancaria = T.IdCuentaBancaria")
         .AppendLine(" LEFT JOIN ContabilidadCuentas CC ON CC.IdCuenta = T.IdCuentaContable")
         .AppendLine(" LEFT JOIN Proveedores PRV ON PRV.IdProveedor = T.IdProveedor")
      End With
   End Sub

   Public Function Tarjetas_GA(activas As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         If activas Then
            .AppendLine(" WHERE Habilitada = 1")
         End If
         .AppendLine("  ORDER BY T.NombreTarjeta, T.TipoTarjeta")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function Tarjetas_G1(IdTarjeta As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE IdTarjeta = {0}", IdTarjeta)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetProximoId() As Integer
      Return GetCodigoMaximo("IDTARJETA", "TARJETAS").ToInteger()
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      If columna = "NombreCuenta" Then
         columna = "CC." + columna
      Else
         columna = "T." + columna
      End If

      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine("  WHERE " & columna & " LIKE '%" & valor & "%'")
         .Append("  ORDER BY T.NombreTarjeta, T.TipoTarjeta")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetPorNombreExacto(nombre As String) As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendLine("SELECT T.IdTarjeta")
         .AppendLine("      ,T.NombreTarjeta")
         .AppendLine("      ,T.IdCuentaBancaria")
         .AppendLine("      ,CB.NombreCuenta")
         .AppendLine("  FROM Tarjetas T ")
         .AppendLine("LEFT JOIN CuentasBancarias CB ON T.IdCuentaBancaria = CB.IdCuentaBancaria")
         .AppendFormatLine(" WHERE T.NombreTarjeta = '{0}'", nombre)
      End With
      Return GetDataTable(query)
   End Function

End Class