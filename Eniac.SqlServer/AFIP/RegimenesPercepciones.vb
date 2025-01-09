Public Class RegimenesPercepciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RegimenesPercepciones_I(idTipoImpuesto As String, idRegimenPercepcion As Integer,
                                      nombreRegimenPercepcion As String, codigoAFIP As Integer,
                                      importeNetoMinimo As Decimal, impuestoMinimo As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO RegimenesPercepciones (")
         .AppendFormatLine("          {0}", Entidades.RegimenPercepcion.Columnas.IdTipoImpuesto.ToString())
         .AppendFormatLine("        , {0}", Entidades.RegimenPercepcion.Columnas.IdRegimenPercepcion.ToString())
         .AppendFormatLine("        , {0}", Entidades.RegimenPercepcion.Columnas.NombreRegimenPercepcion.ToString())
         .AppendFormatLine("        , {0}", Entidades.RegimenPercepcion.Columnas.CodigoAFIP.ToString())
         .AppendFormatLine("        , {0}", Entidades.RegimenPercepcion.Columnas.ImporteNetoMinimo.ToString())
         .AppendFormatLine("        , {0}", Entidades.RegimenPercepcion.Columnas.ImpuestoMinimo.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("          '{0}'", idTipoImpuesto)
         .AppendFormatLine("        ,  {0} ", idRegimenPercepcion)
         .AppendFormatLine("        , '{0}'", nombreRegimenPercepcion)
         .AppendFormatLine("        ,  {0} ", codigoAFIP)
         .AppendFormatLine("        ,  {0} ", importeNetoMinimo)
         .AppendFormatLine("        ,  {0} ", impuestoMinimo)
         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RegimenesPercepciones")
   End Sub
   Public Sub RegimenesPercepciones_U(idTipoImpuesto As String, idRegimenPercepcion As Integer,
                                      nombreRegimenPercepcion As String, codigoAFIP As Integer,
                                      importeNetoMinimo As Decimal, impuestoMinimo As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE RegimenesPercepciones ")
         .AppendFormatLine("   SET NombreRegimenPercepcion = '{0}'", nombreRegimenPercepcion)
         .AppendFormatLine("     , CodigoAFIP = {0}", codigoAFIP)
         .AppendFormatLine("     , ImporteNetoMinimo = {0}", importeNetoMinimo)
         .AppendFormatLine("     , ImpuestoMinimo = {0}", impuestoMinimo)
         .AppendFormatLine(" WHERE IdTipoImpuesto = '{0}'", idTipoImpuesto)
         .AppendFormatLine("   AND IdRegimenPercepcion = {0}", idRegimenPercepcion)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RegimenesPercepciones")
   End Sub
   Public Sub RegimenesPercepciones_D(idTipoImpuesto As String, idRegimenPercepcion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM RegimenesPercepciones")
         .AppendFormatLine(" WHERE IdTipoImpuesto = '{0}'", idTipoImpuesto)
         .AppendFormatLine("   AND IdRegimenPercepcion = {0}", idRegimenPercepcion)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RegimenesPercepciones")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RP.*")
         .AppendFormatLine("     , TI.NombreTipoImpuesto")
         .AppendFormatLine("  FROM RegimenesPercepciones RP")
         .AppendFormatLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = RP.IdTipoImpuesto")
      End With
   End Sub

   Public Function RegimenesPercepciones_GA() As DataTable
      Return RegimenesPercepciones_G(idTipoImpuesto:=String.Empty, idRegimenPercepcion:=0)
   End Function
   Public Function RegimenesPercepciones_GA(idTipoImpuesto As String) As DataTable
      Return RegimenesPercepciones_G(idTipoImpuesto, idRegimenPercepcion:=0)
   End Function
   Public Function RegimenesPercepciones_G(idTipoImpuesto As String, idRegimenPercepcion As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoImpuesto) Then
            .AppendFormatLine("  AND RP.IdTipoImpuesto = '{0}'", idTipoImpuesto)
         End If
         If idRegimenPercepcion <> 0 Then
            .AppendFormatLine("   AND RP.IdRegimenPercepcion = {0}", idRegimenPercepcion)
         End If
         .AppendFormatLine(" ORDER BY TI.NombreTipoImpuesto, RP.NombreRegimenPercepcion")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function RegimenesPercepciones_G1(idTipoImpuesto As String, idRegimenPercepcion As Integer) As DataTable
      Return RegimenesPercepciones_G(idTipoImpuesto, idRegimenPercepcion)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "I.",
                    New Dictionary(Of String, String) From {{"NombreTipoImpuesto", "TI.NombreTipoImpuesto"}})
   End Function
End Class