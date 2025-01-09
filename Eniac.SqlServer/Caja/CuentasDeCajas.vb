Public Class CuentasDeCajas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasDeCajas_I(idCuentaCaja As Integer,
                               nombreCuentaCaja As String,
                               idTipoCuenta As String,
                               esPosdatado As Boolean,
                               pideCheque As Boolean,
                               idGrupoCuenta As String,
                               idCuentaContable As Long,
                               idCentroCosto As Integer?,
                               generaContabilidad As Boolean,
                               idConceptoCM05 As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO CuentasDeCajas ")
         .AppendFormatLine("     (IdCuentaCaja ")
         .AppendFormatLine("     ,NombreCuentaCaja")
         .AppendFormatLine("     ,IdTipoCuenta")
         .AppendFormatLine("     ,EsPosdatado")
         .AppendFormatLine("     ,PideCheque")
         .AppendFormatLine("     ,IdGrupoCuenta")
         .AppendFormatLine("     ,IdcuentaContable")
         .AppendFormatLine("     ,IdCentroCosto")
         .AppendFormatLine("     ,GeneraContabilidad")
         .AppendFormatLine("     ,IdConceptoCM05")
         .AppendFormatLine("  ) VALUES (")
         .AppendFormatLine("       {0} ", idCuentaCaja)
         .AppendFormatLine("     ,'{0}'", nombreCuentaCaja)
         .AppendFormatLine("     ,'{0}'", idTipoCuenta)
         .AppendFormatLine("     , {0} ", GetStringFromBoolean(esPosdatado))
         .AppendFormatLine("     , {0} ", GetStringFromBoolean(pideCheque))
         .AppendFormatLine("     ,'{0}'", idGrupoCuenta)
         .AppendFormatLine("     , {0} ", If(idCuentaContable > 0, idCuentaContable.ToString(), "NULL"))
         .AppendFormatLine("     , {0} ", If(idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0, idCentroCosto.ToString(), "NULL"))
         .AppendFormatLine("     , {0} ", GetStringFromBoolean(generaContabilidad))
         .AppendFormatLine("     , {0} ", GetStringFromNumber(idConceptoCM05))
         .Append(")")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasDeCajas")
   End Sub

   Public Sub CuentasDeCajas_U(idCuentaCaja As Integer,
                               nombreCuentaCaja As String,
                               idTipoCuenta As String,
                               esPosdatado As Boolean,
                               pideCheque As Boolean,
                               idGrupoCuenta As String,
                               idCuentaContable As Long,
                               idCentroCosto As Integer?,
                               generaContabilidad As Boolean,
                               idConceptoCM05 As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasDeCajas ")
         .AppendFormatLine("   SET NombreCuentaCaja = '{0}'", nombreCuentaCaja)
         .AppendFormatLine("      ,IdTipoCuenta = '{0}'", idTipoCuenta)
         .AppendFormatLine("      ,EsPosdatado = {0}", GetStringFromBoolean(esPosdatado))
         .AppendFormatLine("      ,PideCheque = {0}", GetStringFromBoolean(pideCheque))
         .AppendFormatLine("      ,IdGrupoCuenta = '{0}'", idGrupoCuenta)
         .AppendFormatLine("      ,IdCuentaContable = {0}", If(idCuentaContable > 0, idCuentaContable.ToString(), "NULL"))
         .AppendFormatLine("      ,IdCentroCosto = {0}", If(idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0, idCentroCosto.ToString(), "NULL"))
         .AppendFormatLine("      ,GeneraContabilidad = {0}", GetStringFromBoolean(generaContabilidad))
         .AppendFormatLine("      ,IdConceptoCM05 = {0}", GetStringFromNumber(idConceptoCM05))
         .AppendFormatLine(" WHERE IdCuentaCaja = {0}", idCuentaCaja)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasDeCajas")
   End Sub

   Public Sub CuentasDeCajas_D(idCuentaCaja As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM CuentasDeCajas ")
         .AppendFormatLine(" WHERE IdCuentaCaja = {0}", idCuentaCaja)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasDeCajas")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT C.* ")
         .AppendLine("      ,CC.NombreCuenta AS NombreCuentaContable")
         .AppendLine("      ,CCC.NombreCentroCosto")
         .AppendFormatLine("      ,{0}", ConvertirBitSiNo("C", "GeneraContabilidad"))
         .AppendFormatLine("     , CM05.DescripcionConceptoCM05")
         .AppendFormatLine("     , CM05.TipoConceptoCM05")
         .AppendLine("  FROM CuentasDeCajas C ")
         .AppendLine("  LEFT JOIN ContabilidadCuentas CC ON CC.IdCuenta = C.IdCuentaContable")
         .AppendLine("  LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = C.IdCentroCosto")
         .AppendFormatLine("  LEFT JOIN AFIPConceptosCM05 CM05 ON CM05.IdConceptoCM05 = C.IdConceptoCM05")
      End With
   End Sub

   Public Function CuentasDeCajas_GA() As DataTable
      Return CuentasDeCajas_G(idCuentaCaja:=0, nombreCuentaCaja:=String.Empty, nombreExacto:=True)
   End Function
   Public Function CuentasDeCajas_GA(nombreCuentaCaja As String, nombreExacto As Boolean) As DataTable
      Return CuentasDeCajas_G(idCuentaCaja:=0, nombreCuentaCaja:=nombreCuentaCaja, nombreExacto:=nombreExacto)
   End Function
   Private Function CuentasDeCajas_G(idCuentaCaja As Integer, nombreCuentaCaja As String, nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCuentaCaja > 0 Then
            .AppendFormatLine("   AND C.IdCuentaCaja = {0}", idCuentaCaja)
         End If

         If Not String.IsNullOrEmpty(nombreCuentaCaja) Then
            If nombreExacto Then
               .AppendFormatLine(" AND C.NombreCuentaCaja = '{0}'", nombreCuentaCaja)
            Else
               Dim palabras() As String = nombreCuentaCaja.Split(" "c)
               For Each palabra As String In palabras
                  .AppendFormatLine(" AND UPPER(C.NombreCuentaCaja) LIKE '%{0}%'", palabra.ToUpper())
               Next
            End If
         End If

         .AppendLine(" ORDER BY C.NombreCuentaCaja")
      End With

      Return GetDataTable(myQuery)
   End Function
   Public Function CuentasDeCajas_G1(idCuentaCaja As Integer) As DataTable
      Return CuentasDeCajas_G(idCuentaCaja, nombreCuentaCaja:=String.Empty, nombreExacto:=True)
   End Function

   Public Function CuentasDeCajas_GetGruposDeCuentas() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT DISTINCT IdGrupoCuenta")
         .AppendLine(" FROM CuentasDeCajas")
         .AppendLine(" ORDER BY 1")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      If columna = "NombreCuentaContable" Then
         columna = "CC.NombreCuenta"
      ElseIf columna = "NombreCentroCosto" Then
         columna = "CCC.NombreCentroCosto"
      Else
         columna = "C." + columna
      End If

      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo() As Long
      Return GetCodigoMaximo("IdCuentaCaja", "CuentasDeCajas")
   End Function

End Class