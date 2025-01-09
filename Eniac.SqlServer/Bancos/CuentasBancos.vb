Public Class CuentasBancos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasBancos_I(idCuentaBancos As Integer,
                              nombreCuentaBancos As String,
                              idTipoCuenta As String,
                              posdatado As Boolean,
                              pideCheque As Boolean,
                              idCuentaContable As Integer,
                              idGrupoCuenta As String,
                              idCentroCosto As Integer?,
                              idConceptoCM05 As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO CuentasBancos(")
         .AppendLine("       IdCuentaBanco")
         .AppendLine("     , NombreCuentaBanco")
         .AppendLine("     , IdTipoCuenta")
         .AppendLine("     , EsPosdatado")
         .AppendLine("     , PideCheque")
         .AppendLine("     , IdCuentaContable")
         .AppendLine("     , IdGrupoCuenta")
         .AppendLine("     , IdCentroCosto")
         .AppendLine("     , IdConceptoCM05")
         .AppendLine(") VALUES (")
         .AppendFormatLine("        {0} ", idCuentaBancos)
         .AppendFormatLine("     , '{0}'", nombreCuentaBancos)
         .AppendFormatLine("     , '{0}'", idTipoCuenta)
         .AppendFormatLine("     , '{0}'", posdatado)
         .AppendFormatLine("     , '{0}'", pideCheque)
         .AppendFormatLine("     ,  {0} ", GetStringFromNumber(idCuentaContable))
         .AppendFormatLine("     , '{0}'", idGrupoCuenta)
         .AppendFormatLine("     ,  {0} ", GetStringFromNumber(idCentroCosto))
         .AppendFormatLine("     ,  {0} ", GetStringFromNumber(idConceptoCM05))
         .AppendLine(") ")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasBancos")
   End Sub

   Public Sub CuentasBancos_U(idCuentaBancos As Integer,
                              nombreCuentaBancos As String,
                              idTipoCuenta As String,
                              posdatado As Boolean,
                              pideCheque As Boolean,
                              idCuentaContable As Integer,
                              idGrupoCuenta As String,
                              idCentroCosto As Integer?,
                              idConceptoCM05 As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasBancos")
         .AppendFormatLine("   SET NombreCuentaBanco = '{0}'", nombreCuentaBancos)
         .AppendFormatLine("     , IdTipoCuenta = '{0}'", idTipoCuenta)
         .AppendFormatLine("     , EsPosdatado = '{0}'", posdatado)
         .AppendFormatLine("     , PideCheque = '{0}'", pideCheque)
         .AppendFormatLine("     , IdCuentaContable = {0} ", GetStringFromNumber(idCuentaContable))
         .AppendFormatLine("     , IdGrupoCuenta = '{0}'", idGrupoCuenta)
         .AppendFormatLine("     , IdCentroCosto = {0} ", GetStringFromNumber(idCentroCosto))
         .AppendFormatLine("     , IdConceptoCM05 = {0} ", GetStringFromNumber(idConceptoCM05))
         .AppendFormatLine(" WHERE IdCuentaBanco = {0}", idCuentaBancos)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasBancos")
   End Sub

   Public Sub CuentasBancos_D(idCuentaBancos As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM CuentasBancos ")
         .AppendFormatLine(" WHERE IdCuentaBanco = {0}", idCuentaBancos)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasBancos")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT C.* ")

         '>>> Para las búsquedas foraneas
         .AppendFormatLine("     , CASE IdTipoCuenta ")
         .AppendFormatLine("            WHEN 'E' THEN 'Egreso'")
         .AppendFormatLine("            WHEN 'I' THEN 'Ingreso'")
         .AppendFormatLine("       END DescripcionTipoCuenta")
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("C", "EsPosdatado"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("C", "PideCheque"))
         '<<< Para las búsquedas foraneas

         .AppendFormatLine("     , CC.NombreCuenta AS NombreCuentaContable")
         .AppendFormatLine("     , CCC.NombreCentroCosto")
         .AppendFormatLine("     , CM05.DescripcionConceptoCM05")
         .AppendFormatLine("     , CM05.TipoConceptoCM05")
         .AppendFormatLine("  FROM CuentasBancos C")
         .AppendFormatLine("  LEFT JOIN ContabilidadCuentas CC ON CC.IdCuenta = C.IdCuentaContable")
         .AppendFormatLine("  LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = C.IdCentroCosto")
         .AppendFormatLine("  LEFT JOIN AFIPConceptosCM05 CM05 ON CM05.IdConceptoCM05 = C.IdConceptoCM05")

      End With
   End Sub

   Public Function CuentasBancos_GA() As DataTable
      Return CuentasBancos_G(idCuentaBanco:=0, idCuentaBancoCeroTodos:=True, nombreCuentaBanco:=String.Empty, nombreCuentaBancoExacto:=False)
   End Function
   Public Function CuentasBancos_G1(idCuentaBanco As Integer) As DataTable
      Return CuentasBancos_G(idCuentaBanco, idCuentaBancoCeroTodos:=False, nombreCuentaBanco:=String.Empty, nombreCuentaBancoExacto:=False)
   End Function
   Public Function CuentasBancos_GA(idCuentaBanco As Integer) As DataTable
      Return CuentasBancos_G(idCuentaBanco, idCuentaBancoCeroTodos:=True, nombreCuentaBanco:=String.Empty, nombreCuentaBancoExacto:=False)
   End Function
   Public Function CuentasBancos_GA(nombreCuentaBanco As String) As DataTable
      Return CuentasBancos_G(idCuentaBanco:=0, idCuentaBancoCeroTodos:=True, nombreCuentaBanco, nombreCuentaBancoExacto:=False)
   End Function

   Private Function CuentasBancos_G(idCuentaBanco As Integer, idCuentaBancoCeroTodos As Boolean, nombreCuentaBanco As String, nombreCuentaBancoExacto As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCuentaBanco <> 0 OrElse Not idCuentaBancoCeroTodos Then
            .AppendFormatLine("   AND C.IdCuentaBanco = {0}", idCuentaBanco)
         End If
         If Not String.IsNullOrWhiteSpace(nombreCuentaBanco) Then
            If nombreCuentaBancoExacto Then
               .AppendFormatLine("   AND C.NombreCuentaBanco = '{0}'", nombreCuentaBanco)
            Else
               .AppendFormatLine("   AND C.NombreCuentaBanco LIKE '%{0}%'", nombreCuentaBanco)
            End If
         End If
         .AppendLine(" ORDER BY C.NombreCuentaBanco")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "C.",
                    New Dictionary(Of String, String)() From
                    {{"NombreCuentaContable", "CC.NombreCuenta"},
                     {"NombreCentroCosto", "CCC.NombreCentroCosto"},
                     {"DescripcionConceptoCM05", "CM05.DescripcionConceptoCM05"},
                     {"TipoConceptoCM05", "CM05.TipoConceptoCM05"}})
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo("IdCuentaBanco", "CuentasBancos").ToInteger()
   End Function

End Class