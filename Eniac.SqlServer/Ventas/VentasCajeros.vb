Public Class VentasCajeros
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasCajeros_I(idSucursal As Integer,
                              idTipoComprobante As String,
                              letra As String,
                              centroEmisor As Integer,
                              numeroComprobante As Long,
                              idCliente As Long,
                              codigoCliente As Long,
                              nombreCliente As String,
                              IdVendedor As Integer,
                              nombreVendedor As String,
                              fecha As Date,
                              idFormasPago As Integer,
                              descripcionFormasPago As String,
                              importeTotal As Decimal,
                              descuentoRecargoPorc As Decimal,
                              idCategoria As Integer,
                              idCategoriaFiscal As Short,
                              nombreCategoriaFiscal As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO VentasCajeros ({0}, {1}, {2},{3}, {4}, {5},{6}, {7}, {8},{9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17})",
                       Entidades.VentaCajero.Columnas.IdSucursal.ToString(),
                       Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString(),
                       Entidades.VentaCajero.Columnas.Letra.ToString(),
                       Entidades.VentaCajero.Columnas.CentroEmisor.ToString(),
                       Entidades.VentaCajero.Columnas.NumeroComprobante.ToString(),
                       Entidades.VentaCajero.Columnas.IdCliente.ToString(),
                       Entidades.VentaCajero.Columnas.CodigoCliente.ToString(),
                       Entidades.VentaCajero.Columnas.NombreCliente.ToString(),
                       Entidades.VentaCajero.Columnas.IdVendedor.ToString(),
                       Entidades.VentaCajero.Columnas.NombreVendedor.ToString(),
                       Entidades.VentaCajero.Columnas.Fecha.ToString(),
                       Entidades.VentaCajero.Columnas.IdFormasPago.ToString(),
                       Entidades.VentaCajero.Columnas.DescripcionFormasPago.ToString(),
                       Entidades.VentaCajero.Columnas.ImporteTotal.ToString(),
                       Entidades.VentaCajero.Columnas.DescuentoRecargoPorc.ToString(),
                       Entidades.VentaCajero.Columnas.IdCategoria.ToString(),
                       Entidades.VentaCajero.Columnas.IdCategoriaFiscal.ToString(),
                       Entidades.VentaCajero.Columnas.NombreCategoriaFiscal.ToString()
                       ).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', '{2}', {3}, {4}, {5}, {6}, '{7}', {8}, '{9}', '{10}', {11}, '{12}', {13}, {14}, {15}, {16}, '{17}')",
                       idSucursal,
                       idTipoComprobante,
                       letra,
                       centroEmisor,
                       numeroComprobante,
                       idCliente,
                       codigoCliente,
                       nombreCliente,
                       IdVendedor,
                       nombreVendedor,
                       ObtenerFecha(fecha, True),
                       idFormasPago,
                       descripcionFormasPago,
                       importeTotal,
                       descuentoRecargoPorc,
                       idCategoria,
                       idCategoriaFiscal,
                       nombreCategoriaFiscal
                       )
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasCajeros_U(idSucursal As Integer,
                              idTipoComprobante As String,
                              letra As String,
                              centroEmisor As Integer,
                              numeroComprobante As Long,
                              idCliente As Long,
                              codigoCliente As Long,
                              nombreCliente As String,
                              IdVendedor As Integer,
                              nombreVendedor As String,
                              fecha As Date,
                              idFormasPago As Integer,
                              descripcionFormasPago As String,
                              importeTotal As Decimal,
                              descuentoRecargoPorc As Decimal,
                              idCategoria As Integer,
                              idCategoriaFiscal As Short,
                              nombreCategoriaFiscal As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE VentasCajeros ").AppendLine()
         .AppendFormatLine("   SET {0} = {1}", Entidades.VentaCajero.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("      ,{0} = {1}", Entidades.VentaCajero.Columnas.CodigoCliente.ToString(), codigoCliente)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.VentaCajero.Columnas.NombreCliente.ToString(), nombreCliente)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.VentaCajero.Columnas.IdVendedor.ToString(), IdVendedor)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.VentaCajero.Columnas.NombreVendedor.ToString(), nombreVendedor)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.VentaCajero.Columnas.Fecha.ToString(), ObtenerFecha(fecha, True))
         .AppendFormatLine("      ,{0} = {1}", Entidades.VentaCajero.Columnas.IdFormasPago.ToString(), idFormasPago)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.VentaCajero.Columnas.DescripcionFormasPago.ToString(), descripcionFormasPago)
         .AppendFormatLine("      ,{0} = {1}", Entidades.VentaCajero.Columnas.ImporteTotal.ToString(), importeTotal)
         .AppendFormatLine("      ,{0} = {1}", Entidades.VentaCajero.Columnas.DescuentoRecargoPorc.ToString(), descuentoRecargoPorc)
         .AppendFormatLine("      ,{0} = {1}", Entidades.VentaCajero.Columnas.IdCategoria.ToString(), idCategoria)
         .AppendFormatLine("      ,{0} = {1}", Entidades.VentaCajero.Columnas.IdCategoriaFiscal.ToString(), idCategoriaFiscal)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.VentaCajero.Columnas.NombreCategoriaFiscal.ToString(), nombreCategoriaFiscal)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.VentaCajero.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaCajero.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} = {1}", Entidades.VentaCajero.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} = {1}", Entidades.VentaCajero.Columnas.NumeroComprobante.ToString(), numeroComprobante)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasCajeros_D(idSucursal As Integer,
                              idTipoComprobante As String,
                              letra As String,
                              centroEmisor As Integer,
                              numeroComprobante As Long)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM VentasCajeros ")
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.VentaCajero.Columnas.IdSucursal.ToString(), IdSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString(), IdTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaCajero.Columnas.Letra.ToString(), Letra)
         .AppendFormatLine("   AND {0} = {1}", Entidades.VentaCajero.Columnas.CentroEmisor.ToString(), CentroEmisor)
         .AppendFormatLine("   AND {0} = {1}", Entidades.VentaCajero.Columnas.NumeroComprobante.ToString(), NumeroComprobante)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT VC.*")
         .AppendFormatLine("      ,V.ImporteTarjetas")   'TODO: Queda pendiente pasar este dato a la tabla Cajero para poder quitar el Join
         .AppendFormatLine("      ,V.IdCaja")   'TODO: Queda pendiente pasar este dato a la tabla Cajero para poder quitar el Join
         .AppendFormatLine("      ,C.NombreCaja")   'TODO: Queda pendiente pasar este dato a la tabla Cajero para poder quitar el Join
         .AppendFormatLine("      ,FP.DescripcionFormasPago")   'TODO: Queda pendiente pasar este dato a la tabla Cajero para poder quitar el Join
         .AppendFormatLine("      ,FP.Dias")   'TODO: Queda pendiente pasar este dato a la tabla Cajero para poder quitar el Join
         .AppendFormatLine("      ,TC.Descripcion AS DescripcionTipoComprobante")   'TODO: Queda pendiente pasar este dato a la tabla Cajero para poder quitar el Join
         .AppendFormatLine("      ,TC.AfectaCaja")   'TODO: Queda pendiente pasar este dato a la tabla Cajero para poder quitar el Join
         .AppendFormatLine("      ,TC.EsFiscal")   'TODO: Queda pendiente pasar este dato a la tabla Cajero para poder quitar el Join
         .AppendFormatLine("      ,TC.EsElectronico")   'TODO: Queda pendiente pasar este dato a la tabla Cajero para poder quitar el Join
         .AppendFormatLine("      ,TC.EsPreElectronico")   'TODO: Queda pendiente pasar este dato a la tabla Cajero para poder quitar el Join
         .AppendFormatLine("  FROM VentasCajeros AS VC")
         .AppendFormatLine("  LEFT JOIN Ventas AS V")
         .AppendFormatLine("         ON V.IdSucursal = VC.IdSucursal")
         .AppendFormatLine("        AND V.IdTipoComprobante = VC.IdTipoComprobante")
         .AppendFormatLine("        AND V.Letra = VC.Letra")
         .AppendFormatLine("        AND V.CentroEmisor = VC.CentroEmisor")
         .AppendFormatLine("        AND V.NumeroComprobante = VC.NumeroComprobante")
         .AppendFormatLine("  LEFT JOIN CajasNombres AS C")
         .AppendFormatLine("         ON C.IdSucursal = VC.IdSucursal")
         .AppendFormatLine("        AND C.IdCaja = V.IdCaja")
         .AppendFormatLine("  LEFT JOIN VentasFormasPago AS FP")
         .AppendFormatLine("         ON FP.IdFormasPago = V.IdFormasPago")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes AS TC")
         .AppendFormatLine("         ON TC.IdTipoComprobante = V.IdTipoComprobante")
      End With
   End Sub

   Public Function VentasCajeros_GA(idSucursal As Integer) As DataTable
      Return VentasCajeros_G(idSucursal, idTipoComprobante:=String.Empty, letra:=String.Empty, centroEmisor:=0, numeroComprobante:=0)
   End Function

   Private Function VentasCajeros_G(idSucursal As Integer,
                                    idTipoComprobante As String,
                                    letra As String,
                                    centroEmisor As Integer,
                                    numeroComprobante As Long) As DataTable
      If idSucursal <= 0 Then Throw New ArgumentOutOfRangeException("idSucursal", "El IdSucursal debe ser un número positivo. (VentasCajeros_G)")
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE VC.{0} =  {1} ", Entidades.VentaCajero.Columnas.IdSucursal.ToString(), idSucursal)
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   And VC.{0} = '{1}'", Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND VC.{0} = '{1}'", Entidades.VentaCajero.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND VC.{0} =  {1} ", Entidades.VentaCajero.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If numeroComprobante > 0 Then
            .AppendFormatLine("   AND VC.{0} =  {1} ", Entidades.VentaCajero.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         End If

         .AppendLine(" ORDER BY VC.IdSucursal, VC.IdTipoComprobante, VC.Letra, VC.CentroEmisor, VC.NumeroComprobante")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function VentasCajeros_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return VentasCajeros_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "VC." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class