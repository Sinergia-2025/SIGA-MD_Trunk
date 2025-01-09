Public Class CRMTiposComentariosNovedades
   Inherits Comunes

   Private _camposOrderBy__Default As String() = {"TN.NombreTipoNovedad", "TCN.NombreTipoComentarioNovedad"}
   Private _camposOrderBy__PorPosicion As String() = {"TN.NombreTipoNovedad", "TCN.Posicion"}

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMTiposComentariosNovedades_I(idTipoComentarioNovedad As Integer,
                                             nombreTipoComentarioNovedad As String,
                                             posicion As Integer,
                                             idTipoNovedad As String,
                                             porDefecto As Boolean,
                                             color As Integer?,
                                             visibleParaCliente As Boolean,
                                             visibleParaRepresentante As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO {0} ", Entidades.CRMTipoComentarioNovedad.NombreTabla)
         .AppendFormatLine("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                           Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoComentarioNovedad.ToString(),
                           Entidades.CRMTipoComentarioNovedad.Columnas.NombreTipoComentarioNovedad.ToString(),
                           Entidades.CRMTipoComentarioNovedad.Columnas.Posicion.ToString(),
                           Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoNovedad.ToString(),
                           Entidades.CRMTipoComentarioNovedad.Columnas.PorDefecto.ToString(),
                           Entidades.CRMTipoComentarioNovedad.Columnas.Color.ToString(),
                           Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaCliente.ToString(),
                           Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaRepresentante.ToString())
         .AppendFormatLine("     VALUES ({0}, '{1}', {2}, '{3}', {4}, {5}, {6}, {7}",
                           idTipoComentarioNovedad,
                           nombreTipoComentarioNovedad,
                           posicion,
                           idTipoNovedad,
                           GetStringFromBoolean(porDefecto),
                           GetStringFromNumber(color),
                           GetStringFromBoolean(visibleParaCliente),
                           GetStringFromBoolean(visibleParaRepresentante))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMTiposComentariosNovedades_U(idTipoComentarioNovedad As Integer,
                                             nombreTipoComentarioNovedad As String,
                                             posicion As Integer,
                                             idTipoNovedad As String,
                                             porDefecto As Boolean,
                                             color As Integer?,
                                             visibleParaCliente As Boolean,
                                             visibleParaRepresentante As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.CRMTipoComentarioNovedad.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMTipoComentarioNovedad.Columnas.NombreTipoComentarioNovedad.ToString(), nombreTipoComentarioNovedad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoComentarioNovedad.Columnas.Posicion.ToString(), posicion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoComentarioNovedad.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoComentarioNovedad.Columnas.Color.ToString(), GetStringFromNumber(color))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaCliente.ToString(), GetStringFromBoolean(visibleParaCliente))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaRepresentante.ToString(), GetStringFromBoolean(visibleParaRepresentante))
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoComentarioNovedad.ToString(), idTipoComentarioNovedad)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMTiposComentariosNovedades_D(idTipoComentarioNovedad As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM CRMTiposComentariosNovedades WHERE {0} = '{1}'", Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoComentarioNovedad.ToString(), idTipoComentarioNovedad)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT TCN.*, TN.NombreTipoNovedad")
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("TCN", Entidades.CRMTipoComentarioNovedad.Columnas.PorDefecto.ToString()))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("TCN", Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaCliente.ToString()))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("TCN", Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaRepresentante.ToString()))

         .AppendFormatLine("  FROM {0} AS TCN", Entidades.CRMTipoComentarioNovedad.NombreTabla)
         .AppendFormatLine("  INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = TCN.IdTipoNovedad")
      End With
   End Sub

   Public Function CRMTiposComentariosNovedades_GA() As DataTable
      Return CRMTiposComentariosNovedades_G(idTipoComentarioNovedad:=0, idTipoNovedad:=String.Empty, porDefecto:=Nothing, camposOrderBy:=_camposOrderBy__Default)
   End Function
   Public Function CRMTiposComentariosNovedades_GA(idTipoNovedad As String, ordenarPosicion As Boolean) As DataTable
      Return CRMTiposComentariosNovedades_G(idTipoComentarioNovedad:=0, idTipoNovedad:=idTipoNovedad, porDefecto:=Nothing,
                                             camposOrderBy:=If(ordenarPosicion, _camposOrderBy__PorPosicion, _camposOrderBy__Default))
   End Function
   Private Function CRMTiposComentariosNovedades_G(idTipoComentarioNovedad As Integer, idTipoNovedad As String, porDefecto As Boolean?, camposOrderBy As String()) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")

         If idTipoComentarioNovedad <> 0 Then
            .AppendFormatLine("   AND TCN.{0} = {1}", Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoComentarioNovedad.ToString(), idTipoComentarioNovedad)
         End If

         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine("   AND TCN.{0} = '{1}'", Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         End If

         If porDefecto.HasValue Then
            .AppendFormatLine("   AND TCN.{0} = {1}", Entidades.CRMTipoComentarioNovedad.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto.Value))
         End If

         ArmarOrderBy(myQuery, camposOrderBy)
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CRMTiposComentariosNovedades_G1(idTipoComentarioNovedad As Integer) As DataTable
      Return CRMTiposComentariosNovedades_G(idTipoComentarioNovedad, idTipoNovedad:=String.Empty, porDefecto:=Nothing, camposOrderBy:=_camposOrderBy__Default)
   End Function

   Public Function CRMTiposComentariosNovedades_G_Default(idTipoNovedad As String) As DataTable
      Return CRMTiposComentariosNovedades_G(idTipoComentarioNovedad:=0, idTipoNovedad:=idTipoNovedad, porDefecto:=True, camposOrderBy:=_camposOrderBy__Default)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      If columna = "NombreTipoNovedad" Then
         columna = "TN." + columna
      ElseIf columna = "PorDefecto_SN" Then
         columna = "CASE WHEN TCN.PorDefecto = 0 THEN 'NO' ELSE 'SI' END"
      ElseIf columna = "VisibleParaCliente_SN" Then
         columna = "CASE WHEN TCN.VisibleParaCliente = 0 THEN 'NO' ELSE 'SI' END"
      ElseIf columna = "VisibleParaRepresentante_SN" Then
         columna = "CASE WHEN TCN.VisibleParaRepresentante = 0 THEN 'NO' ELSE 'SI' END"
      Else
         columna = "TCN." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoComentarioNovedad.ToString(), Entidades.CRMTipoComentarioNovedad.NombreTabla))
   End Function
   Public Overloads Function GetPosicionMaxima(idTipoNovedad As String) As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.CRMTipoComentarioNovedad.Columnas.Posicion.ToString(), Entidades.CRMTipoComentarioNovedad.NombreTabla,
                                                    String.Format("{0} = '{1}'", Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)))
   End Function

End Class