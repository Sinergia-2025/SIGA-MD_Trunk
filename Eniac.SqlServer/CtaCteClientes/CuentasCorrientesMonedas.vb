Public Class CuentasCorrientesMonedas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientesMonedas_I(ByVal idSucursal As Integer, _
                        ByVal idTipoComprobante As String, _
                        ByVal letra As String, _
                        ByVal centroEmisor As Int16, _
                        ByVal numeroComprobante As Int64, _
                        ByVal idMoneda As String, _
                        ByVal montoMoneda As Double)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO CuentasCorrientesMonedas")
         .Append("           ([IdSucursal]")
         .Append("           ,[IdTipoComprobante]")
         .Append("           ,[Letra]")
         .Append("           ,[CentroEmisor]")
         .Append("           ,[NumeroComprobante]")
         .Append("           ,[idMoneda]")
         .Append("           ,[montoMoneda])")
         .Append("     VALUES")
         .AppendFormat("           ({0}", idSucursal)
         .AppendFormat("           ,'{0}'", idTipoComprobante)
         .AppendFormat("           ,'{0}'", letra)
         .AppendFormat("           ,{0}", centroEmisor)
         .AppendFormat("           ,{0}", numeroComprobante)
         .AppendFormat("           ,'{0}'", idMoneda)
         .AppendFormat("           ,{0})", montoMoneda.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientesMonedas")
   End Sub

End Class
