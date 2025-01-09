Public Class ConcesionarioOperacionesAdicionales
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
   'INSERT
   Public Sub ConcesionarioOperacionesAdicionales_I(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                    idAdicional As Integer, detalleAdicional As String, precioAdicional As Decimal)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO {0}", Entidades.ConcesionarioOperacionAdicional.NombreTabla)
         .AppendFormatLine("     ( {0}", Entidades.ConcesionarioOperacionAdicional.Columnas.IdMarca.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionAdicional.Columnas.AnioOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionAdicional.Columnas.NumeroOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionAdicional.Columnas.SecuenciaOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionAdicional.Columnas.IdAdicional.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionAdicional.Columnas.DetalleAdicional.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionAdicional.Columnas.PrecioAdicional.ToString())
         .AppendFormatLine("     ) VALUES ( ")
         .AppendFormatLine("        {0} ", idMarca)
         .AppendFormatLine("     ,  {0} ", anioOperacion)
         .AppendFormatLine("     ,  {0} ", numeroOperacion)
         .AppendFormatLine("     ,  {0} ", secuenciaOperacion)
         .AppendFormatLine("     ,  {0} ", idAdicional)
         .AppendFormatLine("     , '{0}'", detalleAdicional)
         .AppendFormatLine("     ,  {0} ", precioAdicional)
         .AppendFormatLine("     )")
      End With
      Execute(query)
   End Sub
   'UPDATE
   Public Sub ConcesionarioOperacionesAdicionales_U(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                    idAdicional As Integer, detalleAdicional As String, precioAdicional As Decimal)
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE {0}", Entidades.ConcesionarioOperacionAdicional.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ConcesionarioOperacionAdicional.Columnas.DetalleAdicional.ToString(), detalleAdicional)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacionAdicional.Columnas.PrecioAdicional.ToString(), precioAdicional)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ConcesionarioOperacionAdicional.Columnas.IdMarca.ToString(), idMarca)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionAdicional.Columnas.AnioOperacion.ToString(), anioOperacion)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionAdicional.Columnas.NumeroOperacion.ToString(), numeroOperacion)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionAdicional.Columnas.SecuenciaOperacion.ToString(), secuenciaOperacion)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionAdicional.Columnas.IdAdicional.ToString(), idAdicional)
      End With
      Execute(query)
   End Sub
   'DELETE
   Public Sub ConcesionarioOperacionesAdicionales_D(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                    idAdicional As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("DELETE FROM {0}", Entidades.ConcesionarioOperacionAdicional.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ConcesionarioOperacionAdicional.Columnas.IdMarca.ToString(), idMarca)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionAdicional.Columnas.AnioOperacion.ToString(), anioOperacion)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionAdicional.Columnas.NumeroOperacion.ToString(), numeroOperacion)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionAdicional.Columnas.SecuenciaOperacion.ToString(), secuenciaOperacion)
         If idAdicional <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionAdicional.Columnas.IdAdicional.ToString(), idAdicional)
         End If
      End With
      Execute(query)
   End Sub
   'SELECT TXT
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT COP.*, CA.NombreAdicional, CA.SolicitaDetalle")
         .AppendFormatLine("  FROM {0} AS COP", Entidades.ConcesionarioOperacionAdicional.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} CA ON CA.{1} = COP.{2}", Entidades.ConcesionariosAdicionales.NombreTabla,
                           Entidades.ConcesionariosAdicionales.Columnas.IdAdicional, Entidades.ConcesionarioOperacionAdicional.Columnas.IdAdicional)
      End With
   End Sub

   'G
   Private Function ConcesionarioOperacionesAdicionales_G(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                          idAdicional As Integer) As DataTable
      Dim query = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendLine(" WHERE 1 = 1")
         If idMarca > 0 Then
            .AppendFormatLine("   AND COP.IdMarca = {0}", idMarca)
         End If
         If anioOperacion > 0 Then
            .AppendFormatLine("   AND COP.AnioOperacion = {0}", anioOperacion)
         End If
         If numeroOperacion > 0 Then
            .AppendFormatLine("   AND COP.NumeroOperacion = {0}", numeroOperacion)
         End If
         If secuenciaOperacion > 0 Then
            .AppendFormatLine("   AND COP.SecuenciaOperacion = {0}", secuenciaOperacion)
         End If
         If idAdicional > 0 Then
            .AppendFormatLine("   AND COP.IdAdicional = {0}", idAdicional)
         End If

      End With
      Return GetDataTable(query)
   End Function

   'GA
   Public Function ConcesionarioOperacionesAdicionales_GA() As DataTable
      Return ConcesionarioOperacionesAdicionales_G(idMarca:=0, anioOperacion:=0, numeroOperacion:=0, secuenciaOperacion:=0, idAdicional:=0)
   End Function
   Public Function ConcesionarioOperacionesAdicionales_GA(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As DataTable
      Return ConcesionarioOperacionesAdicionales_G(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, idAdicional:=0)
   End Function

   'G1
   Public Function ConcesionarioOperacionesAdicionales_G1(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                          idAdicional As Integer) As DataTable
      Return ConcesionarioOperacionesAdicionales_G(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, idAdicional)
   End Function

   'BUSCAR
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "COP.")
   End Function

End Class
