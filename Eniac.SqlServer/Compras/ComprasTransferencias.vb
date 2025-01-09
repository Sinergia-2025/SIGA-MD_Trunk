Public Class ComprasTransferencias
   Inherits Comunes

   Private _defaultOrderBy As String = " ORDER BY CT.IdSucursal, CT.IdTipoComprobante, CT.Letra, CT.CentroEmisor, CT.NumeroComprobante, CT.IdProveedor, CT.Orden"
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ComprasTransferencias_I(idSucursal As Integer, idTipoComprobante As String, letra As String,
                                      centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long, orden As Integer,
                                     importe As Decimal, idCuentaBancaria As Integer,
                                     idSucursalLibroBanco As Integer?, idCuentaBancariaLibroBanco As Integer?, numeroMovimientoLibroBanco As Integer?)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO ComprasTransferencias (")
         .AppendFormatLine("     IdSucursal")
         .AppendFormatLine("   , IdTipoComprobante")
         .AppendFormatLine("   , Letra")
         .AppendFormatLine("   , CentroEmisor")
         .AppendFormatLine("   , NumeroComprobante")
         .AppendFormatLine("   , idProveedor")
         .AppendFormatLine("   , Orden")
         .AppendFormatLine("   , Importe")
         .AppendFormatLine("   , IdCuentaBancaria")
         .AppendFormatLine("   , IdSucursalLibroBanco")
         .AppendFormatLine("   , IdCuentaBancariaLibroBanco")
         .AppendFormatLine("   , NumeroMovimientoLibroBanco")
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   , '{0}'", idTipoComprobante)
         .AppendFormatLine("   , '{0}'", letra)
         .AppendFormatLine("   ,  {0} ", centroEmisor)
         .AppendFormatLine("   ,  {0} ", numeroComprobante)
         .AppendFormatLine("   ,  {0} ", idProveedor)
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   ,  {0} ", importe)
         .AppendFormatLine("   ,  {0} ", idCuentaBancaria)
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idSucursalLibroBanco))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idCuentaBancariaLibroBanco))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(numeroMovimientoLibroBanco))
         .AppendFormatLine(")")
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "ComprasTransferencias")
   End Sub
   Public Sub ComprasTransferencias_U(idSucursal As Integer, idTipoComprobante As String, letra As String,
                                      centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long, orden As Integer,
                                     importe As Decimal, idCuentaBancaria As Integer,
                                     idSucursalLibroBanco As Integer?, idCuentaBancariaLibroBanco As Integer?, numeroMovimientoLibroBanco As Integer?)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ComprasTransferencias")
         .AppendFormatLine("   SET Importe = {0}", importe)
         .AppendFormatLine("     , IdCuentaBancaria = {0}", idCuentaBancaria)
         .AppendFormatLine("     , IdSucursalLibroBanco = {0}", GetStringFromNumber(idSucursalLibroBanco))
         .AppendFormatLine("     , IdCuentaBancariaLibroBanco = {0}", GetStringFromNumber(idCuentaBancariaLibroBanco))
         .AppendFormatLine("     , NumeroMovimientoLibroBanco = {0}", GetStringFromNumber(numeroMovimientoLibroBanco))
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND IdProveedor = {0}", idProveedor)
         .AppendFormatLine("   AND Orden = {0}", orden)
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "ComprasTransferencias")
   End Sub
   Public Sub ComprasTransferencias_D(idSucursal As Integer, idTipoComprobante As String, letra As String,
                                      centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long, orden As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ComprasTransferencias ")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND IdProveedor = {0}", idProveedor)
         If orden <> 0 Then
            .AppendFormatLine("   AND Orden = {0}", orden)
         End If
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "ComprasTransferencias")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CT.*")
         .AppendFormatLine("     , CB.CodigoBancario")
         .AppendFormatLine("     , CB.NombreCuenta")
         .AppendFormatLine("  FROM ComprasTransferencias CT")
         .AppendFormatLine(" INNER JOIN CuentasBancarias CB ON CB.IdCuentaBancaria = CT.IdCuentaBancaria")
      End With
   End Sub
   Public Function ComprasTransferencias_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As DataTable
      Return ComprasTransferencias_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, orden:=0)
   End Function
   Private Function ComprasTransferencias_G(idSucursal As Integer, idTipoComprobante As String, letra As String,
                                            centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long, orden As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE CT.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND CT.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CT.Letra = '{0}'", letra)
         .AppendFormatLine("   AND CT.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND CT.NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND CT.IdProveedor = {0}", idProveedor)

         If orden <> 0 Then
            .AppendFormatLine("   AND CT.Orden = {0}", orden)
         End If
         .AppendFormatLine(_defaultOrderBy)
      End With

      Return GetDataTable(stb)
   End Function
   Public Function ComprasTransferencias_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long, orden As Integer) As DataTable
      Return ComprasTransferencias_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, orden)
   End Function

   Public Function GetOrdenMaximo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As Integer
      Return GetCodigoMaximo(Entidades.CompraTransferencia.Columnas.Orden.ToString(), Entidades.CompraTransferencia.NombreTabla,
                             String.Format("CT.IdSucursal = {0} AND CT.IdTipoComprobante = '{1}' AND CT.Letra = '{2}' AND CT.CentroEmisor = {3} AND CT.NumeroComprobante = {4} AND CT.IdProveedor = {5}",
                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)).ToInteger()
   End Function

End Class