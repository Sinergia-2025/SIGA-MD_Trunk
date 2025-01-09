Public Class SituacionCupones
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
   'INSERT
   Public Sub SituacionCupones_I(idSituacionCupon As Integer, nombreSituacionCupon As String, porDefecto As Boolean)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3})",
               Entidades.SituacionCupon.NombreTabla,
               Entidades.SituacionCupon.Columnas.IdSituacionCupon.ToString(),
               Entidades.SituacionCupon.Columnas.NombreSituacionCupon.ToString(),
               Entidades.SituacionCupon.Columnas.PorDefecto.ToString())

         .AppendFormatLine("  VALUES ({1}, '{2}', {3})",
               Entidades.SituacionCupon.NombreTabla,
               idSituacionCupon,
               nombreSituacionCupon,
               GetStringFromBoolean(porDefecto))
      End With
      Me.Execute(query.ToString())
   End Sub
   'UPDATE
   Public Sub SituacionCupones_U(idSituacionCupon As Integer, nombreSituacionCupon As String, porDefecto As Boolean)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("UPDATE {0}", Entidades.SituacionCupon.NombreTabla)
         .AppendFormatLine("  SET {0} = '{1}'", Entidades.SituacionCupon.Columnas.NombreSituacionCupon.ToString(), nombreSituacionCupon)
         .AppendFormatLine("    , {0} =  {1} ", Entidades.SituacionCupon.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto))
         .AppendFormatLine("  WHERE {0} = {1}", Entidades.SituacionCupon.Columnas.IdSituacionCupon.ToString(), idSituacionCupon)
      End With
      Me.Execute(query.ToString())
   End Sub
   'DELETE
   Public Sub SituacionCupones_D(idSituacionCupon As Integer)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("DELETE FROM {0} WHERE {1} = {2}", Entidades.SituacionCupon.NombreTabla, Entidades.SituacionCupon.Columnas.IdSituacionCupon.ToString(), idSituacionCupon)
      End With
      Me.Execute(query.ToString())
   End Sub
   'SELECT TEXT
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT SC.* FROM {0} AS SC", Entidades.SituacionCupon.NombreTabla)
      End With
   End Sub

   Public Function SituacionCupones_G(idSituacionCupon As Integer, nombreSituacionCupon As String, nombreExacto As Boolean,
                                      porDefecto As Boolean?) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         .AppendLine(" WHERE 1 = 1")
         If idSituacionCupon <> 0 Then
            .AppendFormatLine("   AND SC.IdSituacionCupon = {0}", idSituacionCupon)
         End If
         If Not String.IsNullOrWhiteSpace(nombreSituacionCupon) Then
            If nombreExacto Then
               .AppendFormatLine("  AND SC.NombreSituacionCupon = '{0}'", nombreSituacionCupon)
            Else
               .AppendFormatLine("  AND SC.NombreSituacionCupon LIKE '%{0}%'", nombreSituacionCupon)
            End If
         End If
         If porDefecto.HasValue Then
            .AppendFormatLine("   AND SC.PorDefecto = {0}", GetStringFromBoolean(porDefecto.Value))
         End If
         .AppendFormatLine(" ORDER BY SC.NombreSituacionCupon")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function
   'GA
   Public Function SituacionCupones_GA() As DataTable
      Return SituacionCupones_G(idSituacionCupon:=0, nombreSituacionCupon:=String.Empty, nombreExacto:=False, porDefecto:=Nothing)
   End Function

   Public Function SituacionCupones_GA(nombreSituacionCupon As String, nombreExacto As Boolean) As DataTable
      Return SituacionCupones_G(idSituacionCupon:=0, nombreSituacionCupon:=nombreSituacionCupon, nombreExacto:=nombreExacto, porDefecto:=Nothing)
   End Function
   'G1
   Public Function SituacionCupones_G1(idSituacionCupon As Integer) As DataTable
      Return SituacionCupones_G(idSituacionCupon:=idSituacionCupon, nombreSituacionCupon:=String.Empty, nombreExacto:=False, porDefecto:=Nothing)
   End Function
   'G1
   Public Function SituacionCupones_G_PorDfecto() As DataTable
      Return SituacionCupones_G(idSituacionCupon:=0, nombreSituacionCupon:=String.Empty, nombreExacto:=False, porDefecto:=True)
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
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.SituacionCupon.Columnas.IdSituacionCupon.ToString(), "SituacionCupones"))
   End Function
End Class
