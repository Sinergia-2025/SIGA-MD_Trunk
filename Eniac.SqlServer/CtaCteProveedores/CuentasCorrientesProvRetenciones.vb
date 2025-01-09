Public Class CuentasCorrientesProvRetenciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientesProvRetenciones_I(idSucursal As Integer,
                                                 IdProveedor As Long,
                                                 idTipoComprobante As String,
                                                 letra As String,
                                                 centroEmisor As Integer,
                                                 numeroComprobante As Long,
                                                 IdTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                                 EmisorRetencion As Integer,
                                                 NumeroRetencion As Long,
                                                 SecuenciaRetencion As Integer?)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO CuentasCorrientesProvRetenciones")
         .Append("           (IdSucursal")
         .Append("           ,IdProveedor")
         .Append("           ,IdTipoComprobante")
         .Append("           ,Letra")
         .Append("           ,CentroEmisor")
         .Append("           ,NumeroComprobante")
         .Append("           ,IdTipoImpuesto")
         .Append("           ,EmisorRetencion")
         .Append("           ,NumeroRetencion")
         .Append("           ,SecuenciaRetencion")
         .Append(")")
         .Append("     VALUES")
         .AppendFormat("           ({0}", idSucursal)
         .AppendFormat("           ,{0}", IdProveedor)
         .AppendFormat("           ,'{0}'", idTipoComprobante)
         .AppendFormat("           ,'{0}'", letra)
         .AppendFormat("           ,{0}", centroEmisor)
         .AppendFormat("           ,{0}", numeroComprobante)
         .AppendFormat("           ,'{0}'", IdTipoImpuesto.ToString())
         .AppendFormat("           ,{0}", EmisorRetencion)
         .AppendFormat("           ,{0}", NumeroRetencion)
         If SecuenciaRetencion > 0 Then
            .AppendFormat("           ,{0}", SecuenciaRetencion)
         Else
            .AppendFormat("           ,NULL")
         End If

         .Append("           )")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProvRetenciones")

   End Sub

   Public Sub CuentasCorrientesProvRetenciones_D(ByVal idSucursal As Integer, _
                                                 ByVal IdProveedor As Long, _
                                                 ByVal idTipoComprobante As String, _
                                                 ByVal letra As String, _
                                                 ByVal centroEmisor As Integer, _
                                                 ByVal numeroComprobante As Long)
      'ByVal IdTipoImpuesto As Entidades.TipoImpuesto.Tipos, _
      'ByVal EmisorRetencion As Integer, _
      'ByVal NumeroRetencion As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE CuentasCorrientesProvRetenciones")
         .AppendLine(" WHERE ")
         .AppendFormat(" IdSucursal = {0}", idSucursal)
         .AppendFormat(" AND IdProveedor = {0}", IdProveedor)
         .AppendFormat(" AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat(" AND Letra = '{0}'", letra)
         .AppendFormat(" AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat(" AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProvRetenciones")

   End Sub

   Public Function GetRetencionesPorFechaProveedor(ByVal fechaDesde As DateTime, _
                                          ByVal fechaHasta As DateTime, _
                                          ByVal IdProveedor As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT * FROM cuentascorrientesprovretenciones CCPR")
         .AppendLine(" LEFT JOIN RetencionesCompras R ON CCPR.IdSucursal = R.IdSucursal")
         .AppendLine("		AND CCPR.IdTipoImpuesto = R.IdTipoImpuesto ")
         .AppendLine("		AND CCPR.EmisorRetencion = R.EmisorRetencion")
         .AppendLine("		AND CCPR.NumeroRetencion = R.NumeroRetencion")
         .AppendLine("		AND CCPR.IdProveedor = R.IdProveedor")
         .AppendFormat(" WHERE R.FechaEmision BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'	", fechaDesde.ToString("yyyyMMdd"), fechaHasta.ToString("yyyyMMdd"))
         .AppendFormat("   AND CCPR.IdProveedor = {0}", IdProveedor)
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
