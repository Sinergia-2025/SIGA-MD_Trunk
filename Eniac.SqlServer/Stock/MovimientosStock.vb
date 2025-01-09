Public Class MovimientosStock
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovimientosStock_I(idSucursal As Integer,
                                 idTipoMovimiento As String,
                                 numeroMovimiento As Long,
                                 fechaMovimiento As DateTime,
                                 neto As Double,
                                 total As Double,
                                 porcentajeIVA As Double,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroComprobante As Long,
                                 idCategoriaFiscal As Short,
                                 usuario As String,
                                 observacion As String,
                                 totalImpuestos As Decimal,
                                 idSucursal2 As Integer,
                                 percepcionIVA As Decimal,
                                 percepcionIB As Decimal,
                                 percepcionGanancias As Decimal,
                                 percepcionVarias As Decimal,
                                 idProduccion As Integer,
                                 IdCliente As Long,
                                 IdProveedor As Long,
                                 IdEmpleado As Integer,
                                 impuestosInternos As Decimal)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.MovimientoStock.NombreTabla)
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.IdSucursal.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.IdTipoMovimiento.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.NumeroMovimiento.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.FechaMovimiento.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.Neto.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.Total.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.PorcentajeIVA.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.IdCategoriaFiscal.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.Letra.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.Usuario.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.Observacion.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.TotalImpuestos.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.IdCliente.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.IdSucursal2.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.PercepcionIVA.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.PercepcionIB.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.PercepcionGanancias.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.PercepcionVarias.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.IdProduccion.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.IdProveedor.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStock.Columnas.IdEmpleado.ToString())
         .AppendFormatLine("            {0}  ", Entidades.MovimientoStock.Columnas.ImpuestosInternos.ToString())
         '------------------------------------------------------------------------------
         .AppendLine("  ) VALUES ( ")
         '------------------------------------------------------------------------------
         .AppendFormatLine("            {0} ,", idSucursal)
         .AppendFormatLine("           '{0}',", idTipoMovimiento)
         .AppendFormatLine("            {0} ,", numeroMovimiento)
         .AppendFormatLine("           '{0}',", ObtenerFecha(fechaMovimiento, True))
         .AppendFormatLine("            {0} ,", neto)
         .AppendFormatLine("            {0} ,", total)
         .AppendFormatLine("            {0} ,", porcentajeIVA)
         '------------------------------------------------------------------------------
         If idCategoriaFiscal = 0 Then
            .AppendLine("  NULL,")
         Else
            .AppendFormatLine("            {0} ,", idCategoriaFiscal)
         End If
         If String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("  NULL, ")
         Else
            .AppendFormatLine("          '{0}' ,", idTipoComprobante)
         End If
         If String.IsNullOrEmpty(letra) Then
            .AppendLine("  NULL, ")
         Else
            .AppendFormatLine("          '{0}' ,", letra)
         End If
         If centroEmisor = 0 Then
            .AppendLine("  NULL, ")
         Else
            .AppendFormatLine("            {0} ,", centroEmisor)
         End If
         If numeroComprobante = 0 Then
            .AppendLine("  NULL, ")
         Else
            .AppendFormatLine("            {0} ,", numeroComprobante)
         End If
         '------------------------------------------------------------------------------
         .AppendFormatLine("           '{0}',", usuario)
         '------------------------------------------------------------------------------
         If String.IsNullOrEmpty(observacion) Then
            .AppendLine("  NULL, ")
         Else
            .AppendFormatLine("           '{0}',", observacion)
         End If
         .AppendFormatLine("            {0} ,", totalImpuestos)
         If IdCliente = 0 Then
            .AppendLine("  NULL, ")
         Else
            .AppendFormatLine("            {0} ,", IdCliente)
         End If
         If idSucursal2 = 0 Then
            .AppendLine("  NULL, ")
         Else
            .AppendFormatLine("            {0} ,", idSucursal2)
         End If
         '------------------------------------------------------------------------------
         .AppendFormatLine("            {0} ,", percepcionIVA)
         .AppendFormatLine("            {0} ,", percepcionIB)
         .AppendFormatLine("            {0} ,", percepcionGanancias)
         .AppendFormatLine("            {0} ,", percepcionVarias)
         '------------------------------------------------------------------------------
         If idProduccion = 0 Then
            .AppendLine("  NULL, ")
         Else
            .AppendFormatLine("            {0} ,", idProduccion)
         End If
         If IdProveedor = 0 Then
            .AppendLine("  NULL, ")
         Else
            .AppendFormatLine("            {0} ,", IdProveedor)
         End If
         If IdEmpleado = 0 Then
            .AppendLine("  NULL, ")
         Else
            .AppendFormatLine("            {0} ,", IdEmpleado)
         End If
         .AppendFormatLine("            {0}", impuestosInternos)
         '------------------------------------------------------------------------------
         .AppendLine("  ) ")
      End With
      Execute(myQuery.ToString())
   End Sub
   Public Sub MovimientosStock_D(idSucursal As Integer,
                                 idTipoMovimiento As String,
                                 numeroMovimiento As Long)
      Dim myQuery = New StringBuilder("")
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.MovimientoStock.NombreTabla)
         .AppendFormatLine(" WHERE  {0} =  {1} ", Entidades.MovimientoStock.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND  {0} = '{1}'", Entidades.MovimientoStock.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("   AND  {0} =  {1} ", Entidades.MovimientoStock.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT MC.* ")
         .AppendFormatLine("  FROM {0} AS MC", Entidades.MovimientoStock.NombreTabla)
      End With
   End Sub

   Public Function MovimientosStock_G1(idSucursal As Integer, idTipoMovimiento As String, numeroMovimiento As Long) As DataTable
      Return MovimientosStock_G(idSucursal, idTipoMovimiento, numeroMovimiento)
   End Function

   Private Function MovimientosStock_G(idSucursal As Integer, idTipoMovimiento As String, numeroMovimiento As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         '-- Sucursal.- --
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND MC.IdSucursal = {0}", idSucursal)
         End If
         '-- Tipo Movimiento.- --
         If Not String.IsNullOrWhiteSpace(idTipoMovimiento) Then
            .AppendFormatLine("   AND MC.IdTipoMovimiento = '{0}'", idTipoMovimiento)
         End If
         '-- Numero Movimiento.- --
         If numeroMovimiento <> 0 Then
            .AppendFormatLine("   AND MC.NumeroMovimiento = {0}", numeroMovimiento)
         End If
         .AppendLine(" ORDER BY MC.FechaMovimiento")
      End With
      Return GetDataTable(myQuery.ToString())
   End Function

   Public Function GetUnoPorComprobante(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        centroEmisor As Short,
                                        numeroComprobante As Long,
                                        IdProveedor As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.IdSucursal.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.IdTipoMovimiento.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.NumeroMovimiento.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.FechaMovimiento.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.IdProveedor.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.Letra.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.Usuario.ToString())
         .AppendFormatLine("     {0}  ", Entidades.MovimientoStock.Columnas.Observacion.ToString())
         .AppendFormatLine("FROM {0}  ", Entidades.MovimientoStock.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1}  ", Entidades.MovimientoStock.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}' ", Entidades.MovimientoStock.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}' ", Entidades.MovimientoStock.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1}  ", Entidades.MovimientoStock.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1}  ", Entidades.MovimientoStock.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         If IdProveedor > 0 Then
            .AppendFormatLine("   AND {0} =  {1}  ", Entidades.MovimientoStock.Columnas.IdProveedor.ToString(), IdProveedor)
         End If
      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetMovimientosStock(idSucursal As Integer,
                                       idProduccion As Integer,
                                       idTipoMovimiento As String,
                                       NumeroMovimiento As Long) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.IdSucursal.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.IdTipoMovimiento.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.NumeroMovimiento.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.FechaMovimiento.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.IdProveedor.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.Letra.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("     {0}, ", Entidades.MovimientoStock.Columnas.Usuario.ToString())
         .AppendFormatLine("     {0} ", Entidades.MovimientoStock.Columnas.Observacion.ToString())
         .AppendFormatLine("FROM {0}  ", Entidades.MovimientoStock.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1}  ", Entidades.MovimientoStock.Columnas.IdSucursal.ToString(), idSucursal)
         If Not String.IsNullOrWhiteSpace(idTipoMovimiento) Then
            .AppendFormatLine("   AND {0} = '{1}' ", Entidades.MovimientoStock.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         End If
         If NumeroMovimiento <> 0 Then
            .AppendFormatLine("   AND {0} =  {1}  ", Entidades.MovimientoStock.Columnas.NumeroMovimiento.ToString(), NumeroMovimiento)
         End If
         If idProduccion > 0 Then
            .AppendFormatLine("   AND {0} = '{1}' ", Entidades.MovimientoStock.Columnas.IdProduccion.ToString(), idProduccion)
         End If
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Sub ActualizoFechaMovimientoStock(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                           fecha As Date?)
      Dim stb = New StringBuilder()
      With stb
         .Append("UPDATE MovimientosStock")
         If fecha.HasValue Then
            .AppendFormatLine("     SET FechaMovimiento = '{0}'", ObtenerFecha(fecha.Value, True))
         End If
         .AppendFormatLine(" WHERE {0} =  {1}  ", Entidades.MovimientoStock.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}' ", Entidades.MovimientoStock.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}' ", Entidades.MovimientoStock.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1}  ", Entidades.MovimientoStock.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1}  ", Entidades.MovimientoStock.Columnas.NumeroComprobante.ToString(), numeroComprobante)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "MovimientosStock")

   End Sub
End Class
