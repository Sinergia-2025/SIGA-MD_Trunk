Public Class ConcesionarioOperacionesVehiculosPagos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
   'INSERT
   Public Sub ConcesionarioOperacionesVehiculosPagos_I(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                       patenteVehiculo As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO {0}", Entidades.ConcesionarioOperacionVehiculoPago.NombreTabla)
         .AppendFormatLine("     ( {0}", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.IdMarca.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.AnioOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.NumeroOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.SecuenciaOperacion.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.PatenteVehiculo.ToString())

         .AppendFormatLine("     ) VALUES ( ")
         .AppendFormatLine("        {0} ", idMarca)
         .AppendFormatLine("     ,  {0} ", anioOperacion)
         .AppendFormatLine("     ,  {0} ", numeroOperacion)
         .AppendFormatLine("     ,  {0} ", secuenciaOperacion)
         .AppendFormatLine("     , '{0}'", patenteVehiculo)

         .AppendFormatLine("     )")
      End With
      Execute(query)
   End Sub
   'UPDATE
   Public Sub ConcesionarioOperacionesVehiculosPagos_U(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                       patenteVehiculo As String)
      Throw New NotImplementedException("ConcesionarioOperacionesVehiculosPagos_U no fue implementado por no tener atritubos la tabla (solo PK)")
      ''''Dim query = New StringBuilder()
      ''''With query
      ''''   .AppendFormatLine("UPDATE {0}", Entidades.ConcesionarioOperacionVehiculoPago.NombreTabla)
      ''''   '.AppendFormatLine("   SET {0} =  {1} ", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.Monto.ToString(), monto)
      ''''   '.AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.Cuotas.ToString(), cuotas)
      ''''   '.AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.NumeroCupon.ToString(), numeroCupon)
      ''''   '.AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.NumeroLote.ToString(), numeroLote)
      ''''   .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.IdMarca.ToString(), idMarca)
      ''''   .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.AnioOperacion.ToString(), anioOperacion)
      ''''   .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.NumeroOperacion.ToString(), numeroOperacion)
      ''''   .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.SecuenciaOperacion.ToString(), secuenciaOperacion)
      ''''   .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.IdCheque.ToString(), idCheque)
      ''''End With
      ''''Execute(query)
   End Sub
   'MERGE
   Public Sub ConcesionarioOperacionesVehiculosPagos_M(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                       patenteVehiculo As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("MERGE INTO {0} AS D", Entidades.ConcesionarioOperacionVehiculoPago.NombreTabla)
         .AppendFormatLine("        USING (SELECT {0} IdMarca, {1} AnioOperacion, {2} NumeroOperacion, {3} SecuenciaOperacion, '{4}' PatenteVehiculo) AS O ",
                           idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, patenteVehiculo)
         .AppendFormatLine("           ON D.IdMarca = O.IdMarca AND D.AnioOperacion = O.AnioOperacion AND D.NumeroOperacion = O.NumeroOperacion AND D.SecuenciaOperacion = O.SecuenciaOperacion AND D.PatenteVehiculo = O.PatenteVehiculo")
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT (  IdMarca,   AnioOperacion,   NumeroOperacion,   SecuenciaOperacion,   PatenteVehiculo) ")
         .AppendFormatLine("        VALUES (O.IdMarca, O.AnioOperacion, O.NumeroOperacion, O.SecuenciaOperacion, O.PatenteVehiculo)")
         .AppendFormatLine(";")
      End With
      Execute(query)
   End Sub
   'DELETE
   Public Sub ConcesionarioOperacionesVehiculosPagos_D(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                       patenteVehiculo As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("DELETE FROM {0}", Entidades.ConcesionarioOperacionVehiculoPago.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.IdMarca.ToString(), idMarca)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.AnioOperacion.ToString(), anioOperacion)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.NumeroOperacion.ToString(), numeroOperacion)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.SecuenciaOperacion.ToString(), secuenciaOperacion)
         If Not String.IsNullOrWhiteSpace(patenteVehiculo) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ConcesionarioOperacionVehiculoPago.Columnas.PatenteVehiculo.ToString(), patenteVehiculo)
         End If
      End With
      Execute(query)
   End Sub
   'SELECT TXT
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT COV.*, V.*")

         .AppendFormatLine("     , M.NombreMarcaVehiculo")
         .AppendFormatLine("     , D.NombreModeloVehiculo")
         .AppendFormatLine("     , P.NombreProducto")
         .AppendFormatLine("     , CTU.NombreTipoUnidad")
         .AppendFormatLine("     , EV.NombreEstadoVehiculo")
         .AppendFormatLine("     , (SELECT C.NombreCliente + ' / '")
         .AppendFormatLine("          FROM Clientes C")
         .AppendFormatLine("         INNER JOIN VehiculosClientes VC ON VC.IdCliente = C.IdCliente")
         .AppendFormatLine("         WHERE VC.PatenteVehiculo = V.PatenteVehiculo")
         .AppendFormatLine("         FOR XML PATH('')) AS NombreCliente")
         .AppendFormatLine("     , CO.CodigoOperacion CodigoOperacionIngreso")

         .AppendFormatLine("  FROM {0} AS COV", Entidades.ConcesionarioOperacionVehiculoPago.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} V ON V.{1} = COV.{2}", Entidades.Vehiculo.NombreTabla, Entidades.Vehiculo.Columnas.PatenteVehiculo, Entidades.ConcesionarioOperacionVehiculoPago.Columnas.PatenteVehiculo)

         .AppendFormatLine("  LEFT JOIN ConcesionarioOperaciones CO")
         .AppendFormatLine("         ON CO.IdMarca             = V.IdMarcaOperacionIngreso")
         .AppendFormatLine("        AND CO.AnioOperacion       = V.AnioOperacionIngreso")
         .AppendFormatLine("        AND CO.NumeroOperacion     = V.NumeroOperacionIngreso")
         .AppendFormatLine("        AND CO.SecuenciaOperacion  = V.SecuenciaOperacionIngreso")

         .AppendFormatLine(" INNER JOIN MarcasVehiculos M ON v.IdMarcaVehiculo = M.IdMarcaVehiculo ")
         .AppendFormatLine(" INNER JOIN ModelosVehiculos D ON v.IdModeloVehiculo = d.IdModeloVehiculo ")
         .AppendFormatLine("  LEFT JOIN Productos P ON P.IdProducto = V.IdProductoReferencia")
         .AppendFormatLine("  LEFT JOIN ConcesionarioTiposUnidades CTU ON CTU.IdTipoUnidad = V.IdTipoUnidad")
         .AppendFormatLine("  LEFT JOIN EstadosVehiculos EV ON EV.IdEstadoVehiculo = V.IdEstadoVehiculo")
      End With
   End Sub

   'G
   Private Function ConcesionarioOperacionesVehiculosPagos_G(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                             patenteVehiculo As String) As DataTable
      Dim query = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendLine(" WHERE 1 = 1")
         If idMarca > 0 Then
            .AppendFormatLine("   AND COV.IdMarca = {0}", idMarca)
         End If
         If anioOperacion > 0 Then
            .AppendFormatLine("   AND COV.AnioOperacion = {0}", anioOperacion)
         End If
         If numeroOperacion > 0 Then
            .AppendFormatLine("   AND COV.NumeroOperacion = {0}", numeroOperacion)
         End If
         If secuenciaOperacion > 0 Then
            .AppendFormatLine("   AND COV.SecuenciaOperacion = {0}", secuenciaOperacion)
         End If
         If Not String.IsNullOrWhiteSpace(patenteVehiculo) Then
            .AppendFormatLine("   AND COV.patenteVehiculo = '{0}'", patenteVehiculo)
         End If

      End With
      Return GetDataTable(query)
   End Function

   'GA
   Public Function ConcesionarioOperacionesVehiculosPagos_GA() As DataTable
      Return ConcesionarioOperacionesVehiculosPagos_G(idMarca:=0, anioOperacion:=0, numeroOperacion:=0, secuenciaOperacion:=0,
                                                      patenteVehiculo:=String.Empty)
   End Function
   Public Function ConcesionarioOperacionesVehiculosPagos_GA(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As DataTable
      Return ConcesionarioOperacionesVehiculosPagos_G(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion,
                                                      patenteVehiculo:=String.Empty)
   End Function

   'G1
   Public Function ConcesionarioOperacionesVehiculosPagos_G1(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                             patenteVehiculo As String) As DataTable
      Return ConcesionarioOperacionesVehiculosPagos_G(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, patenteVehiculo)
   End Function

   'BUSCAR
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "COV.")
   End Function

End Class