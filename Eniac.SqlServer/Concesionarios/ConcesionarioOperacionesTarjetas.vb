Public Class ConcesionarioOperacionesTarjetas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
   'INSERT
   Public Sub ConcesionarioOperacionesTarjetas_I(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                 orden As Integer, idTarjeta As Integer, idBanco As Integer,
                                                 monto As Decimal, cuotas As Integer, numeroCupon As Integer, numeroLote As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO {0}", Entidades.ConcesionarioOperacionTarjeta.NombreTabla)
         .AppendFormatLine("     ( {0}", Entidades.ConcesionarioOperacionTarjeta.Columnas.IdMarca.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionTarjeta.Columnas.AnioOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionTarjeta.Columnas.NumeroOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionTarjeta.Columnas.SecuenciaOperacion.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionTarjeta.Columnas.Orden.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionTarjeta.Columnas.IdTarjeta.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionTarjeta.Columnas.IdBanco.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionTarjeta.Columnas.Monto.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionTarjeta.Columnas.Cuotas.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionTarjeta.Columnas.NumeroCupon.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionTarjeta.Columnas.NumeroLote.ToString())

         .AppendFormatLine("     ) VALUES ( ")
         .AppendFormatLine("        {0} ", idMarca)
         .AppendFormatLine("     ,  {0} ", anioOperacion)
         .AppendFormatLine("     ,  {0} ", numeroOperacion)
         .AppendFormatLine("     ,  {0} ", secuenciaOperacion)
         .AppendFormatLine("     ,  {0} ", orden)
         .AppendFormatLine("     ,  {0} ", idTarjeta)
         .AppendFormatLine("     ,  {0} ", idBanco)

         .AppendFormatLine("     ,  {0} ", monto)
         .AppendFormatLine("     ,  {0} ", cuotas)
         .AppendFormatLine("     ,  {0} ", numeroCupon)
         .AppendFormatLine("     ,  {0} ", numeroLote)

         .AppendFormatLine("     )")
      End With
      Execute(query)
   End Sub
   'UPDATE
   Public Sub ConcesionarioOperacionesTarjetas_U(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                 orden As Integer, idTarjeta As Integer, idBanco As Integer,
                                                 monto As Decimal, cuotas As Integer, numeroCupon As Integer, numeroLote As Integer)
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE {0}", Entidades.ConcesionarioOperacionTarjeta.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.ConcesionarioOperacionTarjeta.Columnas.Monto.ToString(), monto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacionTarjeta.Columnas.Cuotas.ToString(), cuotas)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacionTarjeta.Columnas.NumeroCupon.ToString(), numeroCupon)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacionTarjeta.Columnas.NumeroLote.ToString(), numeroLote)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ConcesionarioOperacionTarjeta.Columnas.IdMarca.ToString(), idMarca)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionTarjeta.Columnas.AnioOperacion.ToString(), anioOperacion)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionTarjeta.Columnas.NumeroOperacion.ToString(), numeroOperacion)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionTarjeta.Columnas.SecuenciaOperacion.ToString(), secuenciaOperacion)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionTarjeta.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionTarjeta.Columnas.IdTarjeta.ToString(), idTarjeta)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionTarjeta.Columnas.IdBanco.ToString(), idBanco)
      End With
      Execute(query)
   End Sub
   'DELETE
   Public Sub ConcesionarioOperacionesTarjetas_D(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                 orden As Integer, idTarjeta As Integer, idBanco As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("DELETE FROM {0}", Entidades.ConcesionarioOperacionTarjeta.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ConcesionarioOperacionTarjeta.Columnas.IdMarca.ToString(), idMarca)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionTarjeta.Columnas.AnioOperacion.ToString(), anioOperacion)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionTarjeta.Columnas.NumeroOperacion.ToString(), numeroOperacion)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionTarjeta.Columnas.SecuenciaOperacion.ToString(), secuenciaOperacion)
         If orden <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionTarjeta.Columnas.Orden.ToString(), orden)
         End If
         If idTarjeta <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionTarjeta.Columnas.IdTarjeta.ToString(), idTarjeta)
         End If
         If idBanco <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionTarjeta.Columnas.IdBanco.ToString(), idBanco)
         End If
      End With
      Execute(query)
   End Sub
   'SELECT TXT
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT COT.*, T.NombreTarjeta, B.NombreBanco")
         .AppendFormatLine("  FROM {0} AS COT", Entidades.ConcesionarioOperacionTarjeta.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} T ON T.{1} = COT.{2}", Entidades.Tarjeta.NombreTabla, Entidades.Tarjeta.Columnas.IdTarjeta, Entidades.ConcesionarioOperacionTarjeta.Columnas.IdTarjeta)
         .AppendFormatLine(" INNER JOIN {0} B ON B.{1} = COT.{2}", "bancos", "IdBanco", Entidades.ConcesionarioOperacionTarjeta.Columnas.IdBanco)
      End With
   End Sub

   'G
   Private Function ConcesionarioOperacionesTarjetas_G(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                       orden As Integer, idTarjeta As Integer, idBanco As Integer) As DataTable
      Dim query = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendLine(" WHERE 1 = 1")
         If idMarca > 0 Then
            .AppendFormatLine("   AND COT.IdMarca = {0}", idMarca)
         End If
         If anioOperacion > 0 Then
            .AppendFormatLine("   AND COT.AnioOperacion = {0}", anioOperacion)
         End If
         If numeroOperacion > 0 Then
            .AppendFormatLine("   AND COT.NumeroOperacion = {0}", numeroOperacion)
         End If
         If secuenciaOperacion > 0 Then
            .AppendFormatLine("   AND COT.SecuenciaOperacion = {0}", secuenciaOperacion)
         End If
         If orden > 0 Then
            .AppendFormatLine("   AND COT.Orden = {0}", orden)
         End If
         If idTarjeta > 0 Then
            .AppendFormatLine("   AND COT.IdTarjeta = {0}", idTarjeta)
         End If
         If idBanco > 0 Then
            .AppendFormatLine("   AND COT.IdBanco = {0}", idBanco)
         End If

      End With
      Return GetDataTable(query)
   End Function

   'GA
   Public Function ConcesionarioOperacionesTarjetas_GA() As DataTable
      Return ConcesionarioOperacionesTarjetas_G(idMarca:=0, anioOperacion:=0, numeroOperacion:=0, secuenciaOperacion:=0,
                                                orden:=0, idTarjeta:=0, idBanco:=0)
   End Function
   Public Function ConcesionarioOperacionesTarjetas_GA(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As DataTable
      Return ConcesionarioOperacionesTarjetas_G(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion,
                                                orden:=0, idTarjeta:=0, idBanco:=0)
   End Function

   'G1
   Public Function ConcesionarioOperacionesTarjetas_G1(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                       orden As Integer, idTarjeta As Integer, idBanco As Integer) As DataTable
      Return ConcesionarioOperacionesTarjetas_G(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, orden, idTarjeta, idBanco)
   End Function

   'BUSCAR
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "COT.")
   End Function

End Class