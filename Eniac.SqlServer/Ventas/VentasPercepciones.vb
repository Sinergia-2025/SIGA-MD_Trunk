Public Class VentasPercepciones
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub VentasPercepciones_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                   idTipoImpuesto As Entidades.TipoImpuesto.Tipos, emisorPercepcion As Integer, numeroPercepcion As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO VentasPercepciones (")
         .AppendFormatLine("       IdSucursal")
         .AppendFormatLine("     , IdTipoComprobante")
         .AppendFormatLine("     , Letra")
         .AppendFormatLine("     , CentroEmisor")
         .AppendFormatLine("     , NumeroComprobante")
         .AppendFormatLine("     , IdTipoImpuesto")
         .AppendFormatLine("     , EmisorPercepcion")
         .AppendFormatLine("     , NumeroPercepcion")
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("        {0} ", idSucursal)
         .AppendFormatLine("     , '{0}'", idTipoComprobante)
         .AppendFormatLine("     , '{0}'", letra)
         .AppendFormatLine("     ,  {0} ", centroEmisor)
         .AppendFormatLine("     ,  {0} ", numeroComprobante)
         .AppendFormatLine("     , '{0}'", idTipoImpuesto.ToString())
         .AppendFormatLine("     ,  {0} ", emisorPercepcion)
         .AppendFormatLine("     ,  {0} ", numeroPercepcion)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasPercepciones")
   End Sub
   Public Sub VentasPercepciones_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE VentasPercepciones")
         .AppendLine(" WHERE ")
         .AppendFormatLine(" IdSucursal = {0}", idSucursal)
         .AppendFormatLine(" AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine(" AND Letra = '{0}'", letra)
         .AppendFormatLine(" AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine(" AND NumeroComprobante = {0}", numeroComprobante)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasPercepciones")
   End Sub
End Class