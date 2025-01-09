Public Class CuentasCorrientesProvTransferencias
   Inherits Comunes

#Region "Constructores"

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub CuentasCorrientesProvTransferencias_I(idSucursal As Integer,
                                                idProveedor As Long,
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
         .AppendFormatLine("INSERT INTO CuentasCorrientesProvTransferencias(")
         .AppendFormatLine("	IdSucursal,")
         .AppendFormatLine("	IdProveedor,")
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
         .AppendFormatLine("	 {0},", idProveedor)
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

   Public Sub CuentasCorrientesProvTransferencias_U(idSucursal As Integer,
                                                idProveedor As Long,
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
         .AppendFormatLine("FROM CuentasCorrientesProvTransferencias CCT")
         .AppendFormatLine("	WHERE CCT.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("	  AND CCT.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	  AND CCT.Letra = '{0}'", letra)
         .AppendFormatLine("	  AND CCT.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	  AND CCT.NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("	  AND CCT.Orden = {0}", orden)
      End With
      Execute(query)
   End Sub

   Public Sub CuentasCorrientesProvTransferencias_D(idSucursal As Integer,
                                                idProveedor As Long,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Integer,
                                                numeroComprobante As Long,
                                                orden As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("DELETE CuentasCorrientesProvTransferencias")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND idProveedor = {0}", idProveedor)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         If orden > 0 Then .AppendFormatLine("	  AND Orden = {0}", orden)
      End With
      Execute(query)
   End Sub

   Public Function CuentasCorrientesProvTransferencias_GA() As DataTable
      Dim query = New StringBuilder()
      SelectTexto(query)
      Return GetDataTable(query)
   End Function

   Public Function CuentasCorrientesProvTransferencias_G1(idSucursal As Integer,
                                                        idProveedor As Long,
                                                      idTipoComprobante As String,
                                                      letra As String,
                                                      centroEmisor As Integer,
                                                      numeroComprobante As Long) As DataTable
      Return CuentasCorrientesProvTransferencias_G1(idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden:=0)
   End Function

   Public Function CuentasCorrientesProvTransferencias_G1(idSucursal As Integer,
                                                        idProveedor As Long,
                                                      idTipoComprobante As String,
                                                      letra As String,
                                                      centroEmisor As Integer,
                                                      numeroComprobante As Long,
                                                      orden As Integer) As DataTable
      Dim query = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendFormatLine("	WHERE CCT.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("	  AND CCT.IdProveedor = {0}", idProveedor)
         .AppendFormatLine("	  AND CCT.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	  AND CCT.Letra = '{0}'", letra)
         .AppendFormatLine("	  AND CCT.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	  AND CCT.NumeroComprobante = {0}", numeroComprobante)
         If orden > 0 Then .AppendFormatLine("	  AND CCT.Orden = {0}", orden)
      End With
      Return GetDataTable(query)
   End Function

   Public Sub ActualizarCuentaBancaria(nuevoIdCCTransf As Integer, pago As Entidades.CuentaCorrienteProv)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE CCT SET ")
         .AppendFormatLine("	CCT.IdCuentaBancaria = {0}", nuevoIdCCTransf)
         .AppendFormatLine("FROM CuentasCorrientesProvTransferencias CCT ")
         .AppendFormatLine("WHERE 1 = 1")
         .AppendFormatLine("  AND CCT.IdSucursal = {0}", pago.IdSucursal)
         .AppendFormatLine("  AND CCT.IdProveedor = {0}", pago.Proveedor.IdProveedor)
         .AppendFormatLine("  AND CCT.IdTipoComprobante = '{0}'", pago.TipoComprobante.IdTipoComprobante)
         .AppendFormatLine("  AND CCT.Letra = '{0}'", pago.Letra)
         .AppendFormatLine("  AND CCT.CentroEmisor = {0}", pago.CentroEmisor)
         .AppendFormatLine("  AND CCT.NumeroComprobante = {0}", pago.NumeroComprobante)
      End With
      Execute(query)
   End Sub

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT CCT.*")
         .AppendFormatLine("	   , CB.NombreCuenta")
         .AppendFormatLine("  FROM CuentasCorrientesProvTransferencias CCT")
         .AppendFormatLine(" INNER JOIN CuentasBancarias CB ON CCT.IdCuentaBancaria = CB.IdCuentaBancaria")
      End With
   End Sub
End Class