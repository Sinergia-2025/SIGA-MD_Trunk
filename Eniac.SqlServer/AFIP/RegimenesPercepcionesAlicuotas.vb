Public Class RegimenesPercepcionesAlicuotas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RegimenesPercepcionesAlicuotas_I(idTipoImpuesto As String, idRegimenPercepcion As Integer, alicuotaPercepcion As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO RegimenesPercepcionesAlicuotas (")
         .AppendFormatLine("          {0}", Entidades.RegimenPercepcionAlicuota.Columnas.IdTipoImpuesto.ToString())
         .AppendFormatLine("        , {0}", Entidades.RegimenPercepcionAlicuota.Columnas.IdRegimenPercepcion.ToString())
         .AppendFormatLine("        , {0}", Entidades.RegimenPercepcionAlicuota.Columnas.AlicuotaPercepcion.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("          '{0}'", idTipoImpuesto)
         .AppendFormatLine("        ,  {0} ", idRegimenPercepcion)
         .AppendFormatLine("        , '{0}'", alicuotaPercepcion)
         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RegimenesPercepcionesAlicuotas")
   End Sub
   Public Sub RegimenesPercepcionesAlicuotas_U(idTipoImpuesto As String, idRegimenPercepcion As Integer, alicuotaPercepcion As Decimal)
      Throw New NotImplementedException("El método RegimenesPercepcionesAlicuotas_U no se implementa porque no hay campos donde hacer update")
      'Dim myQuery = New StringBuilder()
      'With myQuery
      '   .AppendFormatLine("UPDATE RegimenesPercepcionesAlicuotas ")
      '   '.AppendFormatLine("   SET NombreRegimenPercepcionAlicuota = '{0}'", nombreRegimenPercepcionAlicuota)
      '   '.AppendFormatLine("     , CodigoAFIP = {0}", codigoAFIP)
      '   '.AppendFormatLine("     , ImporteNetoMinimo = {0}", importeNetoMinimo)
      '   .AppendFormatLine(" WHERE IdTipoImpuesto = '{0}'", idTipoImpuesto)
      '   .AppendFormatLine("   AND IdRegimenPercepcion = {0}", idRegimenPercepcion)
      '   .AppendFormatLine("   AND AlicuotaPercepcion = {0}", alicuotaPercepcion)
      'End With
      'Execute(myQuery)
      'Sincroniza_I(myQuery.ToString(), "RegimenesPercepcionesAlicuotas")
   End Sub
   Public Sub RegimenesPercepcionesAlicuotas_D(idTipoImpuesto As String, idRegimenPercepcion As Integer, alicuotaPercepcion As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM RegimenesPercepcionesAlicuotas")
         .AppendFormatLine(" WHERE IdTipoImpuesto = '{0}'", idTipoImpuesto)
         .AppendFormatLine("   AND IdRegimenPercepcion = {0}", idRegimenPercepcion)
         If alicuotaPercepcion >= 0 Then
            .AppendFormatLine("   AND AlicuotaPercepcion = {0}", alicuotaPercepcion)
         End If
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RegimenesPercepcionesAlicuotas")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RPA.*")
         .AppendFormatLine("     , RP.NombreRegimenPercepcion")
         .AppendFormatLine("     , TI.NombreTipoImpuesto")
         .AppendFormatLine("  FROM RegimenesPercepcionesAlicuotas RPA")
         .AppendFormatLine(" INNER JOIN RegimenesPercepciones RP ON RP.IdTipoImpuesto = RPA.IdTipoImpuesto AND RP.IdRegimenPercepcion = RPA.IdRegimenPercepcion")
         .AppendFormatLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = RPA.IdTipoImpuesto")
      End With
   End Sub

   Public Function RegimenesPercepcionesAlicuotas_GA() As DataTable
      Return RegimenesPercepcionesAlicuotas_G(idTipoImpuesto:=String.Empty, idRegimenPercepcion:=0, alicuotaPercepcion:=0)
   End Function
   Public Function RegimenesPercepcionesAlicuotas_GA(idTipoImpuesto As String) As DataTable
      Return RegimenesPercepcionesAlicuotas_G(idTipoImpuesto, idRegimenPercepcion:=0, alicuotaPercepcion:=0)
   End Function
   Public Function RegimenesPercepcionesAlicuotas_GA(idTipoImpuesto As String, idRegimenPercepcion As Integer) As DataTable
      Return RegimenesPercepcionesAlicuotas_G(idTipoImpuesto, idRegimenPercepcion, alicuotaPercepcion:=0)
   End Function
   Public Function RegimenesPercepcionesAlicuotas_G(idTipoImpuesto As String, idRegimenPercepcion As Integer, alicuotaPercepcion As Decimal) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoImpuesto) Then
            .AppendFormatLine("  AND RPA.IdTipoImpuesto = '{0}'", idTipoImpuesto)
         End If
         If idRegimenPercepcion <> 0 Then
            .AppendFormatLine("   AND RPA.IdRegimenPercepcion = {0}", idRegimenPercepcion)
         End If
         If alicuotaPercepcion <> 0 Then
            .AppendFormatLine("   AND RPA.AlicuotaPercepcion = {0}", alicuotaPercepcion)
         End If
         .AppendFormatLine(" ORDER BY TI.NombreTipoImpuesto, RP.NombreRegimenPercepcion, RPA.AlicuotaPercepcion")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function RegimenesPercepcionesAlicuotas_G1(idTipoImpuesto As String, idRegimenPercepcion As Integer, alicuotaPercepcion As Decimal) As DataTable
      Return RegimenesPercepcionesAlicuotas_G(idTipoImpuesto, idRegimenPercepcion, alicuotaPercepcion)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "I.",
                    New Dictionary(Of String, String) From {{"NombreRegimenPercepcion", "RP.NombreRegimenPercepcion"},
                                                            {"NombreTipoImpuesto", "TI.NombreTipoImpuesto"}})
   End Function
End Class