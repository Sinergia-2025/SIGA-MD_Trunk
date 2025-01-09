Public Class CuentasCorrientesRetenciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientesRetenciones_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                             idRetencion As Integer,
                                             idTipoImpuesto As Entidades.TipoImpuesto.Tipos, emisorRetencion As Integer, numeroRetencion As Long, idCliente As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO CuentasCorrientesRetenciones (")
         .AppendFormatLine("     IdSucursal")
         .AppendFormatLine("   , IdTipoComprobante")
         .AppendFormatLine("   , Letra")
         .AppendFormatLine("   , CentroEmisor")
         .AppendFormatLine("   , NumeroComprobante")
         .AppendFormatLine("   , IdRetencion")
         .AppendFormatLine("   , IdTipoImpuesto")
         .AppendFormatLine("   , EmisorRetencion")
         .AppendFormatLine("   , NumeroRetencion")
         .AppendFormatLine("   , IdCLiente")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   , '{0}'", idTipoComprobante)
         .AppendFormatLine("   , '{0}'", letra)
         .AppendFormatLine("   ,  {0} ", centroEmisor)
         .AppendFormatLine("   ,  {0} ", numeroComprobante)
         .AppendFormatLine("   ,  {0} ", idRetencion)
         .AppendFormatLine("   , '{0}'", idTipoImpuesto.ToString())
         .AppendFormatLine("   ,  {0} ", emisorRetencion)
         .AppendFormatLine("   ,  {0} ", numeroRetencion)
         .AppendFormatLine("   ,  {0} ", idCliente)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesRetenciones")

   End Sub

   Public Sub CuentasCorrientesRetenciones_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idCliente As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE CuentasCorrientesRetenciones")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND IdCliente = {0}", idCliente)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesRetenciones")

   End Sub

End Class