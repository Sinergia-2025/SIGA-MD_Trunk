

Public Class VentasCheques
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasCheques_I(ByVal IdSucursal As Integer,
                              ByVal IdTipoComprobante As String,
                              ByVal Letra As String,
                              ByVal CentroEmisor As Integer,
                              ByVal NumeroComprobante As Long,
                              idCheque As Long)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("INSERT INTO VentasCheques (")
         .Append("           IdSucursal")
         .Append("           ,IdTipoComprobante")
         .Append("           ,Letra")
         .Append("           ,CentroEmisor")
         .Append("           ,NumeroComprobante")
         .Append("           ,IdCheque")
         .Append(")     VALUES (")
         .AppendFormat("           {0}", IdSucursal)
         .AppendFormat("           ,'{0}'", IdTipoComprobante)
         .AppendFormat("           ,'{0}'", Letra)
         .AppendFormat("           ,{0}", CentroEmisor)
         .AppendFormat("           ,{0}", NumeroComprobante)
         .AppendFormat("           ,{0}", idCheque)
         .Append(")")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub VentasCheques_U()
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         'agregar el query de UPDATE
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub VentasCheques_D(ByVal IdSucursal As Integer,
                              ByVal IdTipoComprobante As String,
                              ByVal Letra As String,
                              ByVal CentroEmisor As Integer,
                              ByVal NumeroComprobante As Long,
                              idCheque As Long)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM VentasCheques ")
         .Append(" WHERE ")
         .AppendFormat("   IdSucursal = {0}", IdSucursal)
         .AppendFormat("   and IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("   and Letra = '{0}'", Letra)
         .AppendFormat("   and CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("   and NumeroComprobante = {0}", NumeroComprobante)
         .AppendFormat("   and IdCheque = {0}", idCheque)
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub VentasCheques_D2(ByVal IdSucursal As Integer,
                               ByVal IdTipoComprobante As String,
                               ByVal Letra As String,
                               ByVal CentroEmisor As Integer,
                               ByVal NumeroComprobante As Long)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM VentasCheques ")
         .Append(" WHERE ")
         .AppendFormat("   IdSucursal = {0}", IdSucursal)
         .AppendFormat("   AND IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", Letra)
         .AppendFormat("   AND CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("   AND NumeroComprobante = {0}", NumeroComprobante)
      End With

      Me.Execute(stb.ToString())
   End Sub


   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT VC.IdSucursal")
         .Append("      ,VC.IdTipoComprobante")
         .Append("      ,VC.Letra")
         .Append("      ,VC.CentroEmisor")
         .Append("      ,VC.NumeroComprobante")
         .Append("      ,VC.IdCheque")
         .Append("  FROM VentasCheques VC")
      End With
   End Sub

   Public Function VentasCheques_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         '.Append("  ORDER BY VP.")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function VentasCheques_G1(ByVal IdSucursal As Integer,
                              ByVal IdTipoComprobante As String,
                              ByVal Letra As String,
                              ByVal CentroEmisor As Integer,
                              ByVal NumeroComprobante As Long,
                                    idCheque As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append(" WHERE ")
         .AppendFormat("   VC.IdSucursal = {0}", IdSucursal)
         .AppendFormat("   and VC.IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("   and VC.Letra = '{0}'", Letra)
         .AppendFormat("   and VC.CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("   and VC.NumeroComprobante = {0}", NumeroComprobante)
         .AppendFormat("   and VC.IdCheque = {0}", idCheque)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "VC." + columna
      'If columna = "D.NombreLocalidad" Then columna = columna.Replace("D.", "L.")
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

