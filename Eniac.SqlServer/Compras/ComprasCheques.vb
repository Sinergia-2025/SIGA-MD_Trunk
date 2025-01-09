Public Class ComprasCheques
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ComprasCheques_I(ByVal IdSucursal As Integer,
                        ByVal IdTipoComprobante As String,
                        ByVal Letra As String,
                        ByVal CentroEmisor As Integer,
                        ByVal NumeroComprobante As Long,
                        ByVal IdProveedor As Long,
                        ByVal NumeroCheque As Integer,
                        ByVal IdBanco As Integer,
                        ByVal IdBancoSucursal As Integer,
                        ByVal IdLocalidad As Integer,
                               IdCheque As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO ComprasCheques ")
         .Append("           (IdSucursal")
         .Append("           ,IdTipoComprobante")
         .Append("           ,Letra")
         .Append("           ,CentroEmisor")
         .Append("           ,NumeroComprobante")
         .Append("           ,IdProveedor")
         .Append("           ,IdCheque")
         .Append(") VALUES ")
         .Append(" ( " & IdSucursal & "")
         .Append(" , '" & IdTipoComprobante & "'")
         .Append(" , '" & Letra & "'")
         .Append(" , " & CentroEmisor)
         .Append(" , " & NumeroComprobante)
         .Append(" , " & IdProveedor.ToString())
         .AppendFormat("           ,{0}", IdCheque)
         .Append(")")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ComprasCheques_U(ByVal IdSucursal As Integer,
                        ByVal IdTipoComprobante As String,
                        ByVal Letra As String,
                        ByVal CentroEmisor As Integer,
                        ByVal NumeroComprobante As Long,
                        ByVal IdProveedor As Long,
                               idCheque As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ComprasCheques_D(ByVal IdSucursal As Integer, _
                        ByVal IdTipoComprobante As String, _
                        ByVal Letra As String, _
                        ByVal CentroEmisor As Integer, _
                        ByVal NumeroComprobante As Long, _
                        ByVal IdProveedor As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE FROM ComprasCheques")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal & "")
         .AppendLine("   AND IdTipoComprobante = '" & IdTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & Letra & "'")
         .AppendLine("   AND CentroEmisor = " & CentroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & NumeroComprobante.ToString())
         .AppendLine("   AND IdProveedor = " & IdProveedor.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ComprasCheques")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT CC.IdSucursal")
         .Append("      ,CC.IdTipoComprobante")
         .Append("      ,CC.Letra")
         .Append("      ,CC.CentroEmisor")
         .Append("      ,CC.NumeroComprobante")
         .Append("      ,CC.IdProveedor")
         .Append("      ,CC.NumeroChequeAnterior")
         .Append("      ,CC.IdBancoAnterior")
         .Append("      ,CC.IdBancoSucursalAnterior")
         .Append("      ,CC.IdLocalidadAnterior")
         .Append("      ,CC.IdCheque")
         .Append("  FROM ComprasCheques CC")
      End With
   End Sub

   Public Function ComprasCheques_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         '.Append("  ORDER BY VP.")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ComprasCheques_G1(ByVal IdSucursal As Integer,
                              ByVal IdTipoComprobante As String,
                              ByVal Letra As String,
                              ByVal CentroEmisor As Integer,
                              ByVal NumeroComprobante As Long,
                              ByVal IdProveedor As Long,
                              idCheque As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append(" WHERE ")
         .AppendFormat("  CC.IdSucursal = {0}", IdSucursal)
         .AppendFormat("   and CC.IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("   and CC.Letra = '{0}'", Letra)
         .AppendFormat("   and CC.CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("   and CC.NumeroComprobante = {0}", NumeroComprobante)
         .AppendFormat("   and CC.IdProveedor = {0}", IdProveedor)
         .AppendFormat("   and CC.IdCheque = {0}", idCheque)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "CC." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function


End Class
