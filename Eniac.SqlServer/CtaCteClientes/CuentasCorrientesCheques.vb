Public Class CuentasCorrientesCheques
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientesCheques_I(ByVal idSucursal As Integer,
                                         ByVal idTipoComprobante As String,
                                         ByVal letra As String,
                                         ByVal centroEmisor As Int16,
                                         ByVal numeroComprobante As Int64,
                                         idCheque As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO CuentasCorrientesCheques")
         .Append("           (IdSucursal")
         .Append("           ,IdTipoComprobante")
         .Append("           ,Letra")
         .Append("           ,CentroEmisor")
         .Append("           ,NumeroComprobante")
         .Append("           ,IdCheque")
         .Append(" )    VALUES")
         .AppendFormat("           ({0}", idSucursal)
         .AppendFormat("           ,'{0}'", idTipoComprobante)
         .AppendFormat("           ,'{0}'", letra)
         .AppendFormat("           ,{0}", centroEmisor)
         .AppendFormat("           ,{0}", numeroComprobante)
         .AppendFormat("           ,{0}", idCheque)
         .Append(")")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CuentasCorrientesCheques_D(ByVal idSucursal As Integer,
                                         ByVal idTipoComprobante As String,
                                         ByVal letra As String,
                                         ByVal centroEmisor As Int16,
                                         ByVal numeroComprobante As Int64)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE CuentasCorrientesCheques")
         .AppendLine(" WHERE ")
         .AppendFormat(" IdSucursal = {0}", idSucursal)
         .AppendFormat(" AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat(" AND Letra = '{0}'", letra)
         .AppendFormat(" AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat(" AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Function RecuperaCantidadDiasCobro(idSucursal As Integer,
                                             idTipoComprobante As String,
                                             letra As String,
                                             centroEmisor As Integer,
                                             numeroComprobante As Long) As DataTable

      Dim myQuery = New StringBuilder()
      With myQuery
         .Length = 0
         .AppendLine("SELECT FechaCobro, Importe, NumeroCheque FROM CuentasCorrientesCheques CCQ ")
         .AppendLine("	INNER JOIN Cheques CHQ ON CCQ.IdCheque = CHQ.IdCheque ")
         .AppendLine(" WHERE ")
         .AppendFormat("      CCQ.IdSucursal = {0}", idSucursal)
         .AppendFormat(" AND  CCQ.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat(" AND  CCQ.Letra = '{0}'", letra)
         .AppendFormat(" AND  CCQ.CentroEmisor = {0}", centroEmisor)
         .AppendFormat(" AND  CCQ.NumeroComprobante = {0}", numeroComprobante)
         .AppendLine(" ORDER BY FechaCobro DESC ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
