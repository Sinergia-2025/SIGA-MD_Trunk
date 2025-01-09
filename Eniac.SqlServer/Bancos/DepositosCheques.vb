Public Class DepositosCheques
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub DepositosCheques_I(ByVal idSucursal As Integer,
                                 ByVal numeroDeposito As Long,
                                 idCheque As Long,
                                 ByVal idTipoComprobante As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO DepositosCheques")
         .Append("           (IdSucursal")
         .Append("           ,NumeroDeposito")
         .Append("           ,IdCheque")
         .Append("            ,IdtipoComprobante)")
         .Append("     VALUES")
         .AppendFormat("           ({0}", idSucursal)
         .AppendFormat("           ,{0}", numeroDeposito)
         .AppendFormat("           ,{0}", idCheque)
         .AppendFormat("           ,'{0}'", idTipoComprobante)
         .Append(")")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub DepositosCheques_D(ByVal idSucursal As Integer,
                               ByVal numeroDeposito As Long,
                               idCheque As Long,
                                 ByVal idTipoComprobante As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM DepositosCheques")
         .Append("     WHERE ")
         .AppendFormat(" IdSucursal = {0}", idSucursal)
         .AppendFormat(" AND NumeroDeposito = {0}", numeroDeposito)
         .AppendFormat(" AND IdCheque = {0}", idCheque)
         .AppendFormat(" AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .Append("")
      End With

      Me.Execute(myQuery.ToString())
   End Sub
End Class
