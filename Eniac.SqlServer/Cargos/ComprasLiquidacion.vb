Public Class ComprasLiquidacion
   Inherits Eniac.SqlServer.Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ComprasLiquidaciones_I(ByVal IdSucursal As Integer, _
                                        ByVal IdTipoComprobante As String, _
                                        ByVal Letra As String, _
                                        ByVal CentroEmisor As Integer, _
                                        ByVal NumeroComprobante As Long, _
                                        ByVal idProveedor As Long, _
                                        ByVal IdConcepto As Integer, _
                                        ByVal Orden As Long, _
                                        ByVal ImporteALiquidar As Decimal, _
                                        ByVal Liquidado As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("INSERT INTO ComprasLiquidaciones ")
         .AppendLine("           (IdSucursal")
         .AppendLine("           ,IdTipoComprobante")
         .AppendLine("           ,Letra")
         .AppendLine("           ,CentroEmisor")
         .AppendLine("           ,NumeroComprobante")
         .AppendLine("           ,idProveedor")
         .AppendLine("           ,Orden")
         .AppendLine("           ,IdConcepto")
         .AppendLine("           ,ImporteALiquidar")
         .AppendLine("           ,FechaLiquidacion")
         .AppendLine("           ,Liquidado")
         .AppendLine("           ,PeriodoLiquidacion")
         .AppendLine(") VALUES ")
         .Append(" ( " & IdSucursal & "")
         .Append(" , '" & IdTipoComprobante & "'")
         .Append(" , '" & Letra & "'")
         .Append(" , " & CentroEmisor)
         .Append(" , " & NumeroComprobante)
         .Append(" , " & idProveedor)
         .Append(" , " & Orden)
         .Append(" , " & IdConcepto.ToString())
         .Append(" , " & ImporteALiquidar.ToString())
         .AppendLine(", NULL ")  'FechaLiquidacion
         .AppendFormat(" ,{0}", Me.GetStringFromBoolean(Liquidado))
         .Append(" , NULL")   'PeriodoLiquidacion
         .Append(")")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ComprasLiquidaciones_D(IdSucursal As Integer,
                                     IdTipoComprobante As String,
                                     Letra As String,
                                     CentroEmisor As Integer,
                                     NumeroComprobante As Long,
                                     idProveedor As Long,
                                     IdConcepto As Integer,
                                     Orden As Long,
                                     OrdenLiquidacion As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM ComprasLiquidaciones ")
         .AppendFormat("    WHERE IdSucursal = {0}", IdSucursal).AppendLine()
         .AppendFormat("      AND IdTipoComprobante = '{0}'", IdTipoComprobante).AppendLine()
         .AppendFormat("      AND Letra = '{0}'", Letra).AppendLine()
         .AppendFormat("      AND CentroEmisor = {0}", CentroEmisor).AppendLine()
         .AppendFormat("      AND NumeroComprobante = {0}", NumeroComprobante).AppendLine()
         .AppendFormat("      AND idProveedor = {0}", idProveedor).AppendLine()
         .AppendFormat("      AND Orden = {0}", Orden).AppendLine()
         .AppendFormat("      AND IdConcepto = {0}", IdConcepto).AppendLine()
         .AppendFormat("      AND OrdenLiquidacion = {0}", OrdenLiquidacion).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Function GetLiquidacionDetallada(PeriodoLiquidacion As Integer,
                                           IdConcepto As Integer,
                                           IdProveedor As Long,
                                           IdTipoComprobante As String,
                                           Letra As String,
                                           EmisorComprobante As Integer,
                                           NumeroComprobante As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT ML.IdSucursal")
         .AppendLine("      ,R.IdRubroConcepto ")
         .AppendLine("      ,R.NombreRubroConcepto")
         .AppendLine("      ,ML.IdConcepto")
         .AppendLine("      ,C.NombreConcepto")
         .AppendLine("      ,P.NombreProveedor")
         .AppendLine("      ,ML.IdTipoComprobante")
         .AppendLine("      ,TC.DescripcionAbrev AS NombreTipoComprobante")
         .AppendLine("      ,ML.Letra")
         .AppendLine("      ,ML.CentroEmisor")
         .AppendLine("      ,ML.NumeroComprobante")
         .AppendLine("      ,ML.Orden")
         .AppendLine("      ,ML.OrdenLiquidacion")
         .AppendLine("      ,ML.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,CO.Fecha")
         .AppendLine("      ,ML.ImporteALiquidar")
         .AppendLine("      ,ML.PeriodoLiquidacion")
         .AppendLine("  FROM ComprasLiquidaciones ML ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = ML.IdTipoComprobante ")
         .AppendLine(" INNER JOIN Proveedores P ON ML.IdProveedor = P.IdProveedor ")
         .AppendLine(" INNER JOIN Conceptos C ON ML.IdConcepto = C.IdConcepto ")
         .AppendLine(" INNER JOIN RubrosConceptos R ON C.IdRubroConcepto = R.IdRubroConcepto ")
         .AppendLine("  LEFT JOIN Compras CO ON CO.IdSucursal = ML.IdSucursal ")
         .AppendLine("     AND CO.IdTipoComprobante = ML.IdTipoComprobante ")
         .AppendLine("     AND CO.Letra = ML.Letra ")
         .AppendLine("     AND CO.CentroEmisor = ML.CentroEmisor ")
         .AppendLine("     AND CO.NumeroComprobante = ML.NumeroComprobante ")
         .AppendLine("     AND CO.IdProveedor = ML.IdProveedor ")

         If PeriodoLiquidacion > 0 Then
            .AppendLine(" WHERE ML.PeriodoLiquidacion = " & PeriodoLiquidacion.ToString())
         Else
            .AppendLine(" WHERE ML.PeriodoLiquidacion IS NULL")
         End If
         If IdConcepto > 0 Then
            .AppendLine("   AND ML.IdConcepto = " & IdConcepto.ToString())
         End If
         If IdProveedor > 0 Then
            .AppendLine("	AND ML.IdProveedor = " & IdProveedor)
         End If
         If Not String.IsNullOrEmpty(IdTipoComprobante) Then
            .AppendLine("	 AND ML.IdTipoComprobante = '" & IdTipoComprobante & "'")
         End If
         If Not String.IsNullOrEmpty(Letra) Then
            .AppendLine("	 AND ML.Letra = '" & Letra & "'")
         End If
         If EmisorComprobante > 0 Then
            .AppendLine("   AND ML.CentroEmisor = " & EmisorComprobante.ToString())
         End If
         If NumeroComprobante > 0 Then
            .AppendLine("   AND ML.NumeroComprobante = " & NumeroComprobante.ToString())
         End If

         .AppendLine(" ORDER BY R.NombreRubroConcepto, C.NombreConcepto, P.NombreProveedor, ML.IdTipoComprobante, TC.DescripcionAbrev, ML.Letra, ML.CentroEmisor, ML.NumeroComprobante")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
