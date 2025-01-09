Public Class SituacionCheques
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
   'INSERT
   Public Sub SituacionCheques_I(idSituacionCheque As Integer, nombreSituacionCheque As String, porDefecto As Boolean)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3})",
               Entidades.SituacionCheque.NombreTabla,
               Entidades.SituacionCheque.Columnas.IdSituacionCheque.ToString(),
               Entidades.SituacionCheque.Columnas.NombreSituacionCheque.ToString(),
               Entidades.SituacionCheque.Columnas.PorDefecto.ToString())

         .AppendFormatLine("  VALUES ({1}, '{2}', {3})",
               Entidades.SituacionCheque.NombreTabla,
               idSituacionCheque,
               nombreSituacionCheque,
               GetStringFromBoolean(porDefecto))
      End With
      Me.Execute(query.ToString())
   End Sub
   'UPDATE
   Public Sub SituacionCheques_U(idSituacionCheque As Integer, nombreSituacionCheque As String, porDefecto As Boolean)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("UPDATE {0}", Entidades.SituacionCheque.NombreTabla)
         .AppendFormatLine("  SET {0} = '{1}'", Entidades.SituacionCheque.Columnas.NombreSituacionCheque.ToString(), nombreSituacionCheque)
         .AppendFormatLine("    , {0} =  {1} ", Entidades.SituacionCheque.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto))
         .AppendFormatLine("  WHERE {0} = {1}", Entidades.SituacionCheque.Columnas.IdSituacionCheque.ToString(), idSituacionCheque)
      End With
      Me.Execute(query.ToString())
   End Sub
   'DELETE
   Public Sub SituacionCheques_D(idSituacionCheque As Integer)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("DELETE FROM {0} WHERE {1} = {2}", Entidades.SituacionCheque.NombreTabla, Entidades.SituacionCheque.Columnas.IdSituacionCheque.ToString(), idSituacionCheque)
      End With
      Me.Execute(query.ToString())
   End Sub
   'SELECT TEXT
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT SC.* FROM {0} AS SC", Entidades.SituacionCheque.NombreTabla)
      End With
   End Sub

   Public Function SituacionCheques_G(idSituacionCheque As Integer, nombreSituacionCheque As String, nombreExacto As Boolean,
                                      porDefecto As Boolean?) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         .AppendLine(" WHERE 1 = 1")
         If idSituacionCheque <> 0 Then
            .AppendFormatLine("   AND SC.IdSituacionCheque = {0}", idSituacionCheque)
         End If
         If Not String.IsNullOrWhiteSpace(nombreSituacionCheque) Then
            If nombreExacto Then
               .AppendFormatLine("  AND SC.NombreSituacionCheque = '{0}'", nombreSituacionCheque)
            Else
               .AppendFormatLine("  AND SC.NombreSituacionCheque LIKE '%{0}%'", nombreSituacionCheque)
            End If
         End If
         If porDefecto.HasValue Then
            .AppendFormatLine("   AND SC.PorDefecto = {0}", GetStringFromBoolean(porDefecto.Value))
         End If
         .AppendFormatLine(" ORDER BY SC.NombreSituacionCheque")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function
   'GA
   Public Function SituacionCheques_GA() As DataTable
      Return SituacionCheques_G(idSituacionCheque:=0, nombreSituacionCheque:=String.Empty, nombreExacto:=False, porDefecto:=Nothing)
   End Function

   Public Function SituacionCheques_GA(nombreSituacionCheque As String, nombreExacto As Boolean) As DataTable
      Return SituacionCheques_G(idSituacionCheque:=0, nombreSituacionCheque:=nombreSituacionCheque, nombreExacto:=nombreExacto, porDefecto:=Nothing)
   End Function
   'G1
   Public Function SituacionCheques_G1(idSituacionCheque As Integer) As DataTable
      Return SituacionCheques_G(idSituacionCheque:=idSituacionCheque, nombreSituacionCheque:=String.Empty, nombreExacto:=False, porDefecto:=Nothing)
   End Function
   'G1
   Public Function SituacionCheques_G_PorDfecto() As DataTable
      Return SituacionCheques_G(idSituacionCheque:=0, nombreSituacionCheque:=String.Empty, nombreExacto:=False, porDefecto:=True)
   End Function
   'BUSCAR
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "SC." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   'GET CODMAX
   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.SituacionCheque.Columnas.IdSituacionCheque.ToString(), "SituacionCheques"))
   End Function
End Class
