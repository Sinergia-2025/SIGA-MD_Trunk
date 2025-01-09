Public Class CuentasCorrientesTransferencias
   Inherits Comunes

#Region "Constructores"

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub CuentasCorrientesTransferencias_I(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Integer,
                                                numeroComprobante As Long,
                                                orden As Integer,
                                                importe As Decimal,
                                                IdCuentaBancaria As Integer,
                                                idSucursalLibroBanco As Integer?,
                                                idCuentaBancariaLibroBanco As Integer?,
                                                numeroMovimientoLibroBanco As Integer?)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO CuentasCorrientesTransferencias(")
         .AppendFormatLine("	IdSucursal,")
         .AppendFormatLine("	IdTipoComprobante,")
         .AppendFormatLine("	Letra,")
         .AppendFormatLine("	CentroEmisor,")
         .AppendFormatLine("	NumeroComprobante,")
         .AppendFormatLine("	Orden,")
         .AppendFormatLine("	Importe,")
         .AppendFormatLine("	IdCuentaBancaria,")
         .AppendFormatLine("	IdSucursalLibroBanco,")
         .AppendFormatLine("	IdCuentaBancariaLibroBanco,")
         .AppendFormatLine("	NumeroMovimientoLibroBanco")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	 {0},", idSucursal)
         .AppendFormatLine("	'{0}',", idTipoComprobante)
         .AppendFormatLine("	'{0}',", letra)
         .AppendFormatLine("	 {0},", centroEmisor)
         .AppendFormatLine("	 {0},", numeroComprobante)
         .AppendFormatLine("	 {0},", orden)
         .AppendFormatLine("	 {0},", importe)
         .AppendFormatLine("	 {0}", IdCuentaBancaria)

         .AppendFormatLine("	 ,{0}", GetStringFromNumber(idSucursalLibroBanco))
         .AppendFormatLine("	 ,{0}", GetStringFromNumber(idCuentaBancariaLibroBanco))
         .AppendFormatLine("	 ,{0}", GetStringFromNumber(numeroMovimientoLibroBanco))

         .AppendFormatLine(")")
      End With
      Execute(query)
   End Sub

   Public Sub CuentasCorrientesTransferencias_U(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Integer,
                                                numeroComprobante As Long,
                                                orden As Integer,
                                                importe As Decimal,
                                                idCuentaBancaria As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE CCT SET ")
         .AppendFormatLine("     CCT.Importe = {0}, ", importe)
         .AppendFormatLine("     CCT.IdCuentaBancaria = {0} ", idCuentaBancaria)
         .AppendFormatLine("FROM CuentasCorrientesTransferencias CCT")
         .AppendFormatLine("	WHERE CCT.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("	  AND CCT.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	  AND CCT.Letra = '{0}'", letra)
         .AppendFormatLine("	  AND CCT.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	  AND CCT.NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("	  AND CCT.Orden = {0}", orden)
      End With
      Execute(query)
   End Sub

   Public Sub CuentasCorrientesTransferencias_D(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Integer,
                                                numeroComprobante As Long,
                                                orden As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("DELETE CuentasCorrientesTransferencias")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         If orden > 0 Then .AppendFormatLine("	  AND Orden = {0}", orden)
      End With
      Execute(query)
   End Sub

   Public Function CuentasCorrientesTransferencias_GA() As DataTable
      Dim query = New StringBuilder()
      SelectTexto(query)
      Return GetDataTable(query)
   End Function

   Public Function CuentasCorrientesTransferencias_G1(idSucursal As Integer,
                                                      idTipoComprobante As String,
                                                      letra As String,
                                                      centroEmisor As Integer,
                                                      numeroComprobante As Long) As DataTable
      Return CuentasCorrientesTransferencias_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden:=0)
   End Function

   Public Function CuentasCorrientesTransferencias_G1(idSucursal As Integer,
                                                      idTipoComprobante As String,
                                                      letra As String,
                                                      centroEmisor As Integer,
                                                      numeroComprobante As Long,
                                                      orden As Integer) As DataTable
      Dim query = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendFormatLine("	WHERE CCT.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("	  AND CCT.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	  AND CCT.Letra = '{0}'", letra)
         .AppendFormatLine("	  AND CCT.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	  AND CCT.NumeroComprobante = {0}", numeroComprobante)
         If orden > 0 Then .AppendFormatLine("	  AND CCT.Orden = {0}", orden)
      End With
      Return GetDataTable(query)
   End Function

   Public Sub ActualizarCuentaBancaria(nuevoIdCCTransf As Integer, recibo As Entidades.CuentaCorriente)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE CCT SET ")
         .AppendFormatLine("	CCT.IdCuentaBancaria = {0}", nuevoIdCCTransf)
         .AppendFormatLine("FROM CuentasCorrientesTransferencias CCT ")
         .AppendFormatLine("WHERE 1 = 1")
         .AppendFormatLine("  AND CCT.IdSucursal = {0}", recibo.IdSucursal)
         .AppendFormatLine("  AND CCT.IdTipoComprobante = '{0}'", recibo.TipoComprobante.IdTipoComprobante)
         .AppendFormatLine("  AND CCT.Letra = '{0}'", recibo.Letra)
         .AppendFormatLine("  AND CCT.CentroEmisor = {0}", recibo.CentroEmisor)
         .AppendFormatLine("  AND CCT.NumeroComprobante = {0}", recibo.NumeroComprobante)
      End With
      Execute(query)
   End Sub

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT CCT.*")
         .AppendFormatLine("	   , CB.NombreCuenta")
         .AppendFormatLine("  FROM CuentasCorrientesTransferencias CCT")
         .AppendFormatLine(" INNER JOIN CuentasBancarias CB ON CCT.IdCuentaBancaria = CB.IdCuentaBancaria")
      End With
   End Sub
End Class