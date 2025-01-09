Public Class CuentasCorrientesTarjetas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientesTarjetas_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                          orden As Integer, idTarjeta As Integer, idBanco As Integer,
                                          monto As Decimal, cuotas As Integer, numeroCupon As Integer, numeroLote As Integer, idTarjetaCupon As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO CuentasCorrientesTarjetas (", Entidades.CuentaCorrienteTarjeta.NombreTabla)
         .AppendFormatLine("      {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdSucursal.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.Letra.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.Orden.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdTarjeta.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdBanco.ToString())

         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdTarjetaCupon.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.Monto.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.Cuotas.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.NumeroCupon.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CuentaCorrienteTarjeta.Columnas.NumeroLote.ToString())
         .AppendFormatLine("   )  VALUES (")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   , '{0}'", idTipoComprobante)
         .AppendFormatLine("   , '{0}'", letra)
         .AppendFormatLine("   ,  {0} ", centroEmisor)
         .AppendFormatLine("   ,  {0} ", numeroComprobante)
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   ,  {0} ", idTarjeta)
         .AppendFormatLine("   ,  {0} ", idBanco)

         .AppendFormatLine("   ,  {0} ", idTarjetaCupon)
         .AppendFormatLine("   ,  {0} ", monto)
         .AppendFormatLine("   ,  {0} ", cuotas)
         .AppendFormatLine("   ,  {0} ", numeroCupon)
         .AppendFormatLine("   ,  {0} ", numeroLote)
         .AppendFormatLine("   )")
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "CuentasCorrientesTarjetas")
   End Sub
   Public Sub CuentasCorrientesTarjetas_U(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                          orden As Integer, idTarjeta As Integer, idBanco As Integer,
                                          monto As Decimal, cuotas As Integer, numeroCupon As Integer, numeroLote As Integer, idTarjetaCupon As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE {0}", Entidades.CuentaCorrienteTarjeta.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdTarjetaCupon.ToString(), idTarjetaCupon)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.Monto.ToString(), monto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.Cuotas.ToString(), cuotas)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.NumeroCupon.ToString(), numeroCupon)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.NumeroLote.ToString(), numeroLote)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CuentaCorrienteTarjeta.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CuentaCorrienteTarjeta.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdTarjeta.ToString(), idTarjeta)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdBanco.ToString(), idBanco)
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "CuentasCorrientesTarjetas")
   End Sub
   Public Sub CuentasCorrientesTarjetas_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                          orden As Integer, idTarjeta As Integer, idBanco As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM {0}", Entidades.CuentaCorrienteTarjeta.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CuentaCorrienteTarjeta.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CuentaCorrienteTarjeta.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         If orden > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.Orden.ToString(), orden)
         End If
         If idTarjeta > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdTarjeta.ToString(), idTarjeta)
         End If
         If idBanco > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteTarjeta.Columnas.IdBanco.ToString(), idBanco)
         End If
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "CuentasCorrientesTarjetas")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CCT.*")
         .AppendFormatLine("  FROM CuentasCorrientesTarjetas CCT")
      End With
   End Sub

   Public Function CuentasCorrientesTarjetas_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return CuentasCorrientesTarjetas_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden:=0, idTarjeta:=0, idBanco:=0)
   End Function

   Public Function CuentasCorrientesTarjetas_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                                orden As Integer, idTarjeta As Integer, idBanco As Integer) As DataTable
      Return CuentasCorrientesTarjetas_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden, idTarjeta, idBanco)
   End Function

   Private Function CuentasCorrientesTarjetas_G(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                                orden As Integer, idTarjeta As Integer, idBanco As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE CCT.IdSucursal = {0} ", idSucursal)
         .AppendFormatLine("   AND CCT.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CCT.Letra = '{0}'", letra)
         .AppendFormatLine("   AND CCT.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND CCT.NumeroComprobante = {0}", numeroComprobante)
         If orden > 0 Then
            .AppendFormatLine("   AND CCT.Orden = {0}", orden)
         End If
         If idTarjeta > 0 Then
            .AppendFormatLine("   AND CCT.IdTarjeta = {0}", idTarjeta)
         End If
         If idBanco > 0 Then
            .AppendFormatLine("   AND CCT.IdBanco = {0}", idBanco)
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "CCT.")
   End Function

   Public Overloads Function GetOrdenMaximo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Integer
      Dim stbWhere = New StringBuilder()
      With stbWhere
         .AppendFormatLine("       IdSucursal = {0} ", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With
      Return GetCodigoMaximo(Entidades.CuentaCorrienteTarjeta.Columnas.Orden.ToString(), Entidades.CuentaCorrienteTarjeta.NombreTabla, stbWhere.ToString()).ToInteger()
   End Function

End Class