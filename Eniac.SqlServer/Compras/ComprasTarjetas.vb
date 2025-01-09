Public Class ComprasTarjetas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ComprasTarjetas_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                                idTarjetaCupon As Long, idEstadoTarjeta As Entidades.TarjetaCupon.Estados, idEstadoTarjetaAnt As Entidades.TarjetaCupon.Estados)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CompraTarjeta.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CompraTarjeta.Columnas.IdSucursal.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraTarjeta.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraTarjeta.Columnas.Letra.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraTarjeta.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraTarjeta.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraTarjeta.Columnas.IdProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraTarjeta.Columnas.IdTarjetaCupon.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraTarjeta.Columnas.IdEstadoTarjeta.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraTarjeta.Columnas.IdEstadoTarjetaAnt.ToString())
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   , '{0}'", idTipoComprobante)
         .AppendFormatLine("   , '{0}'", letra)
         .AppendFormatLine("   ,  {0} ", centroEmisor)
         .AppendFormatLine("   ,  {0} ", numeroComprobante)
         .AppendFormatLine("   ,  {0} ", idProveedor)
         .AppendFormatLine("   ,  {0} ", idTarjetaCupon)
         .AppendFormatLine("   , '{0}'", idEstadoTarjeta)
         .AppendFormatLine("   , '{0}'", idEstadoTarjetaAnt)
         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
   End Sub
   Public Sub ComprasTarjetas_U(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                                idTarjetaCupon As Long, idEstadoTarjeta As Entidades.TarjetaCupon.Estados, idEstadoTarjetaAnt As Entidades.TarjetaCupon.Estados)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CompraTarjeta.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CompraTarjeta.Columnas.IdEstadoTarjeta.ToString(), idEstadoTarjeta)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CompraTarjeta.Columnas.IdEstadoTarjetaAnt.ToString(), idEstadoTarjetaAnt)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CompraTarjeta.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CompraTarjeta.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CompraTarjeta.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraTarjeta.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraTarjeta.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraTarjeta.Columnas.IdProveedor.ToString(), idProveedor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraTarjeta.Columnas.IdTarjetaCupon.ToString(), idTarjetaCupon)
      End With
      Execute(myQuery)
   End Sub
   Public Sub ComprasTarjetas_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                                idTarjetaCupon As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CompraTarjeta.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CompraTarjeta.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CompraTarjeta.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CompraTarjeta.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraTarjeta.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraTarjeta.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraTarjeta.Columnas.IdProveedor.ToString(), idProveedor)
         If idTarjetaCupon <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraTarjeta.Columnas.IdTarjetaCupon.ToString(), idTarjetaCupon)
         End If
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ComprasTarjetas")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Append("SELECT CT.*")
         .Append("  FROM ComprasTarjetas CT")
      End With
   End Sub

   Public Function ComprasTarjetas_GA() As DataTable
      Return ComprasTarjetas_G(idSucursal:=0, idTipoComprobante:=String.Empty, letra:=String.Empty, centroEmisor:=0, numeroComprobante:=0, idProveedor:=0, idTarjetaCupon:=0)
   End Function
   Public Function ComprasTarjetas_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As DataTable
      Return ComprasTarjetas_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, idTarjetaCupon:=0)
   End Function
   Public Function ComprasTarjetas_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                                      idTarjetaCupon As Long) As DataTable
      Return ComprasTarjetas_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, idTarjetaCupon)
   End Function
   Private Function ComprasTarjetas_G(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                                      idTarjetaCupon As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND CT.{0} =  {1} ", Entidades.CompraTarjeta.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND CT.{0} = '{1}'", Entidades.CompraTarjeta.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND CT.{0} = '{1}'", Entidades.CompraTarjeta.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor <> 0 Then
            .AppendFormatLine("   AND CT.{0} =  {1} ", Entidades.CompraTarjeta.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If numeroComprobante <> 0 Then
            .AppendFormatLine("   AND CT.{0} =  {1} ", Entidades.CompraTarjeta.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         End If
         If idProveedor <> 0 Then
            .AppendFormatLine("   AND CT.{0} =  {1} ", Entidades.CompraTarjeta.Columnas.IdProveedor.ToString(), idProveedor)
         End If
         If idTarjetaCupon <> 0 Then
            .AppendFormatLine("   AND CT.{0} =  {1} ", Entidades.CompraTarjeta.Columnas.IdTarjetaCupon.ToString(), idTarjetaCupon)
         End If
      End With

      Return GetDataTable(stb)
   End Function

End Class