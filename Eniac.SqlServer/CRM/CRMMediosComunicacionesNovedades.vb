Public Class CRMMediosComunicacionesNovedades
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMMediosComunicacionesNovedades_I(idMedioComunicacionNovedad As Integer,
                                                 nombreMedioComunicacionNovedad As String,
                                                 posicion As Integer,
                                                 idTipoNovedad As String,
                                                 porDefecto As Boolean,
                                                 color As Integer?)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO CRMMediosComunicacionesNovedades ({0}, {1}, {2}, {3}, {4}, {5})",
                           Entidades.CRMMedioComunicacionNovedad.Columnas.IdMedioComunicacionNovedad.ToString(),
                           Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString(),
                           Entidades.CRMMedioComunicacionNovedad.Columnas.Posicion.ToString(),
                           Entidades.CRMMedioComunicacionNovedad.Columnas.IdTipoNovedad.ToString(),
                           Entidades.CRMMedioComunicacionNovedad.Columnas.PorDefecto.ToString(),
                           Entidades.CRMMedioComunicacionNovedad.Columnas.Color.ToString())
         .AppendFormatLine("     VALUES ({0}, '{1}', {2}, '{3}', {4}, {5})",
                           idMedioComunicacionNovedad, nombreMedioComunicacionNovedad, posicion, idTipoNovedad, GetStringFromBoolean(porDefecto),
                           GetStringFromNumber(color))
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMMediosComunicacionesNovedades_U(idMedioComunicacionNovedad As Integer,
                                                 nombreMedioComunicacionNovedad As String,
                                                 posicion As Integer,
                                                 idTipoNovedad As String,
                                                 porDefecto As Boolean,
                                                 color As Integer?)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CRMMediosComunicacionesNovedades ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString(), nombreMedioComunicacionNovedad).AppendLine()
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMMedioComunicacionNovedad.Columnas.Posicion.ToString(), posicion).AppendLine()
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMMedioComunicacionNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad).AppendLine()
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMMedioComunicacionNovedad.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto)).AppendLine()
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMMedioComunicacionNovedad.Columnas.Color.ToString(), GetStringFromNumber(color))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CRMMedioComunicacionNovedad.Columnas.IdMedioComunicacionNovedad.ToString(), idMedioComunicacionNovedad)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMMediosComunicacionesNovedades_D(idMedioComunicacionNovedad As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM CRMMediosComunicacionesNovedades WHERE {0} = {1}", Entidades.CRMMedioComunicacionNovedad.Columnas.IdMedioComunicacionNovedad.ToString(), idMedioComunicacionNovedad)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT MN.*, TN.NombreTipoNovedad FROM CRMMediosComunicacionesNovedades AS MN")
         .AppendFormatLine("  INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = MN.IdTipoNovedad")
      End With
   End Sub

   Public Function CRMMediosComunicacionesNovedades_GA() As DataTable
      Return CRMMediosComunicacionesNovedades_GA(String.Empty, False)
   End Function
   Public Function CRMMediosComunicacionesNovedades_GA(idTipoNovedad As String, ordenarPosicion As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine(" WHERE MN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If ordenarPosicion Then
            .AppendFormatLine(" ORDER BY TN.NombreTipoNovedad, MN.Posicion")
         Else
            .AppendFormatLine(" ORDER BY TN.NombreTipoNovedad, MN.NombreMedioComunicacionNovedad")
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CRMMediosComunicacionesNovedades_G1(idMedioComunicacionNovedad As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE MN.{0} = {1}", Entidades.CRMMedioComunicacionNovedad.Columnas.IdMedioComunicacionNovedad.ToString(), idMedioComunicacionNovedad)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable

      If columna = "NombreTipoNovedad" Then
         columna = "TN." + columna
      Else
         columna = "MN." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.CRMMedioComunicacionNovedad.Columnas.IdMedioComunicacionNovedad.ToString(), "CRMMediosComunicacionesNovedades"))
   End Function

   Public Function CRMMediosComunicacionNovedades_GxCodigo(IdMedioNovedad As Integer, idTipoNovedad As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE 1=1 ")
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormat(" and TN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If IdMedioNovedad <> 0 Then
            .AppendFormat(" and EN.{0} = {1}", Entidades.CRMMedioComunicacionNovedad.Columnas.IdMedioComunicacionNovedad.ToString(), IdMedioNovedad)
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function CRMMediosComunicacionNovedades_PorNombre(nombreMedio As String, nombreExacto As Boolean, idTipoNovedad As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE 1=1 ")
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormat(" and TN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If nombreExacto Then
            .AppendFormatLine(" and MN.NombreMedioComunicacionNovedad = '{0}'", nombreMedio)
         Else
            .AppendFormatLine(" and MN.NombreMedioComunicacionNovedad LIKE '%{0}%'", nombreMedio)
         End If
      End With
      Return GetDataTable(stb)
   End Function
End Class