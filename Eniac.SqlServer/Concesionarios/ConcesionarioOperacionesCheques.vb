Public Class ConcesionarioOperacionesCheques
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
   'INSERT
   Public Sub ConcesionarioOperacionesCheques_I(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                idCheque As Long)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO {0}", Entidades.ConcesionarioOperacionCheque.NombreTabla)
         .AppendFormatLine("     ( {0}", Entidades.ConcesionarioOperacionCheque.Columnas.IdMarca.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionCheque.Columnas.AnioOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionCheque.Columnas.NumeroOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionCheque.Columnas.SecuenciaOperacion.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacionCheque.Columnas.IdCheque.ToString())

         .AppendFormatLine("     ) VALUES ( ")
         .AppendFormatLine("        {0} ", idMarca)
         .AppendFormatLine("     ,  {0} ", anioOperacion)
         .AppendFormatLine("     ,  {0} ", numeroOperacion)
         .AppendFormatLine("     ,  {0} ", secuenciaOperacion)
         .AppendFormatLine("     ,  {0} ", idCheque)

         .AppendFormatLine("     )")
      End With
      Execute(query)
   End Sub
   'UPDATE
   Public Sub ConcesionarioOperacionesCheques_U(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                idCheque As Long)
      Throw New NotImplementedException("ConcesionarioOperacionesCheques_U no fue implementado por no tener atritubos la tabla (solo PK)")
      ''''Dim query As StringBuilder = New StringBuilder()
      ''''With query
      ''''   .AppendFormatLine("UPDATE {0}", Entidades.ConcesionarioOperacionCheque.NombreTabla)
      ''''   '.AppendFormatLine("   SET {0} =  {1} ", Entidades.ConcesionarioOperacionCheque.Columnas.Monto.ToString(), monto)
      ''''   '.AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacionCheque.Columnas.Cuotas.ToString(), cuotas)
      ''''   '.AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacionCheque.Columnas.NumeroCupon.ToString(), numeroCupon)
      ''''   '.AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacionCheque.Columnas.NumeroLote.ToString(), numeroLote)
      ''''   .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ConcesionarioOperacionCheque.Columnas.IdMarca.ToString(), idMarca)
      ''''   .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionCheque.Columnas.AnioOperacion.ToString(), anioOperacion)
      ''''   .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionCheque.Columnas.NumeroOperacion.ToString(), numeroOperacion)
      ''''   .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionCheque.Columnas.SecuenciaOperacion.ToString(), secuenciaOperacion)
      ''''   .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacionCheque.Columnas.IdCheque.ToString(), idCheque)
      ''''End With
      ''''Execute(query)
   End Sub
   'DELETE
   Public Sub ConcesionarioOperacionesCheques_D(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                idCheque As Long)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("DELETE FROM {0}", Entidades.ConcesionarioOperacionCheque.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ConcesionarioOperacionCheque.Columnas.IdMarca.ToString(), idMarca)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionCheque.Columnas.AnioOperacion.ToString(), anioOperacion)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionCheque.Columnas.NumeroOperacion.ToString(), numeroOperacion)
         .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionCheque.Columnas.SecuenciaOperacion.ToString(), secuenciaOperacion)
         If idCheque <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.ConcesionarioOperacionCheque.Columnas.IdCheque.ToString(), idCheque)
         End If
      End With
      Execute(query)
   End Sub
   'SELECT TXT
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT COC.*, CH.*")
         .AppendFormatLine("  FROM {0} AS COC", Entidades.ConcesionarioOperacionCheque.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} CH ON CH.{1} = COC.{2}", Entidades.Cheque.NombreTabla, Entidades.Cheque.Columnas.IdCheque, Entidades.ConcesionarioOperacionCheque.Columnas.IdCheque)
      End With
   End Sub

   'G
   Private Function ConcesionarioOperacionesCheques_G(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                      idCheque As Long) As DataTable
      Dim query = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendLine(" WHERE 1 = 1")
         If idMarca > 0 Then
            .AppendFormatLine("   AND COC.IdMarca = {0}", idMarca)
         End If
         If anioOperacion > 0 Then
            .AppendFormatLine("   AND COC.AnioOperacion = {0}", anioOperacion)
         End If
         If numeroOperacion > 0 Then
            .AppendFormatLine("   AND COC.NumeroOperacion = {0}", numeroOperacion)
         End If
         If secuenciaOperacion > 0 Then
            .AppendFormatLine("   AND COC.SecuenciaOperacion = {0}", secuenciaOperacion)
         End If
         If idCheque > 0 Then
            .AppendFormatLine("   AND COC.idCheque = {0}", idCheque)
         End If

      End With
      Return GetDataTable(query)
   End Function

   'GA
   Public Function ConcesionarioOperacionesCheques_GA() As DataTable
      Return ConcesionarioOperacionesCheques_G(idMarca:=0, anioOperacion:=0, numeroOperacion:=0, secuenciaOperacion:=0,
                                               idCheque:=0)
   End Function
   Public Function ConcesionarioOperacionesCheques_GA(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As DataTable
      Return ConcesionarioOperacionesCheques_G(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion,
                                               idCheque:=0)
   End Function

   'G1
   Public Function ConcesionarioOperacionesCheques_G1(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer,
                                                      idCheque As Long) As DataTable
      Return ConcesionarioOperacionesCheques_G(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion, idCheque)
   End Function

   'BUSCAR
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "COC.")
   End Function

End Class