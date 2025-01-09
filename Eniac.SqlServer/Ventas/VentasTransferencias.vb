Public Class VentasTransferencias
   Inherits Comunes

   Private _defaultOrderBy As String = " ORDER BY VT.IdSucursal, VT.IdTipoComprobante, VT.Letra, VT.CentroEmisor, VT.NumeroComprobante, VT.Orden"
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasTransferencias_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer,
                                     importe As Decimal, idCuentaBancaria As Integer,
                                     idSucursalLibroBanco As Integer?, idCuentaBancariaLibroBanco As Integer?, numeroMovimientoLibroBanco As Integer?)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO VentasTransferencias (")
         .AppendFormatLine("     IdSucursal")
         .AppendFormatLine("   , IdTipoComprobante")
         .AppendFormatLine("   , Letra")
         .AppendFormatLine("   , CentroEmisor")
         .AppendFormatLine("   , NumeroComprobante")
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
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   ,  {0} ", importe)
         .AppendFormatLine("   ,  {0} ", idCuentaBancaria)
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idSucursalLibroBanco))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idCuentaBancariaLibroBanco))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(numeroMovimientoLibroBanco))
         .AppendFormatLine(")")
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "VentasTransferencias")
   End Sub
   Public Sub VentasTransferencias_U(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer,
                                     importe As Decimal, idCuentaBancaria As Integer,
                                     idSucursalLibroBanco As Integer?, idCuentaBancariaLibroBanco As Integer?, numeroMovimientoLibroBanco As Integer?)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE VentasTransferencias")
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
         .AppendFormatLine("   AND Orden = {0}", orden)
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "VentasTransferencias")
   End Sub
   Public Sub VentasTransferencias_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM VentasTransferencias ")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         If orden <> 0 Then
            .AppendFormatLine("   AND Orden = {0}", orden)
         End If
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "VentasTransferencias")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT VT.*")
         .AppendFormatLine("     , CB.CodigoBancario")
         .AppendFormatLine("     , CB.NombreCuenta")
         .AppendFormatLine("  FROM VentasTransferencias VT")
         .AppendFormatLine(" INNER JOIN CuentasBancarias CB ON CB.IdCuentaBancaria = VT.IdCuentaBancaria")
      End With
   End Sub
   Public Function VentasTransferencias_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return VentasTransferencias_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden:=0)
   End Function
   Private Function VentasTransferencias_G(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE VT.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND VT.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND VT.Letra = '{0}'", letra)
         .AppendFormatLine("   AND VT.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND VT.NumeroComprobante = {0}", numeroComprobante)
         If orden <> 0 Then
            .AppendFormatLine("   AND VT.Orden = {0}", orden)
         End If
         .AppendFormatLine(_defaultOrderBy)
      End With

      Return GetDataTable(stb)
   End Function
   Public Function VentasTransferencias_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer) As DataTable
      Return VentasTransferencias_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden)
   End Function

   Public Function GetOrdenMaximo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Integer
      Return GetCodigoMaximo(Entidades.VentaTransferencia.Columnas.Orden.ToString(), Entidades.VentaTransferencia.NombreTabla,
                             String.Format("VT.IdSucursal = {0} AND VT.IdTipoComprobante = '{1}' AND VT.Letra = '{2}' AND VT.CentroEmisor = {3} AND VT.NumeroComprobante = {4}",
                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)).ToInteger()
   End Function

End Class