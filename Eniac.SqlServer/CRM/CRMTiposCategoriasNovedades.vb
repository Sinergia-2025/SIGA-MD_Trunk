Public Class CRMTiposCategoriasNovedades
   Inherits Comunes
#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub CRMTiposCategoriasNovedades_I(idTipoCategoriaNovedad As Integer,
                                            nombreTipoCategoriaNovedad As String,
                                            posicion As Integer,
                                            idTipoNovedad As String)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO CRMTiposCategoriasNovedades (")
         .AppendFormatLine("	IdTipoCategoriaNovedad,")
         .AppendFormatLine("	NombreTipoCategoriaNovedad,")
         .AppendFormatLine("	Posicion,")
         .AppendFormatLine("	IdTipoNovedad")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	{0}", idTipoCategoriaNovedad)
         .AppendFormatLine("	,'{0}'", nombreTipoCategoriaNovedad)
         .AppendFormatLine("	,{0}", posicion)
         .AppendFormatLine("	,'{0}'", idTipoNovedad)
         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub CRMTiposCategoriasNovedades_U(idTipoCategoriaNovedad As Integer,
                                            nombreTipoCategoriaNovedad As String,
                                            posicion As Integer,
                                            idTipoNovedad As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE CRMTiposCategoriasNovedades SET")
         .AppendFormatLine("	NombreTipoCategoriaNovedad = '{0}'", nombreTipoCategoriaNovedad)
         .AppendFormatLine("	,Posicion = {0}", posicion)
         .AppendFormatLine("	,IdTipoNovedad = '{0}'", idTipoNovedad)
         .AppendFormatLine("WHERE IdTipoCategoriaNovedad = {0}", idTipoCategoriaNovedad)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub CRMTiposCategoriasNovedades_D(idTipoCategoriaNovedad As Integer)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE CRMTiposCategoriasNovedades WHERE IdTipoCategoriaNovedad = {0}", idTipoCategoriaNovedad)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function CRMTiposCategoriasNovedades_GA(idTipoNovedad As String) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormatLine(" WHERE IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function CRMTiposCategoriasNovedades_G1(idTipoCategoriaNovedad As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         .AppendFormatLine("WHERE TCN.IdTipoCategoriaNovedad = {0}", idTipoCategoriaNovedad)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	TCN.IdTipoCategoriaNovedad,")
         .AppendFormatLine("	TCN.NombreTipoCategoriaNovedad,")
         .AppendFormatLine("	TCN.Posicion,")
         .AppendFormatLine("	TCN.IdTipoNovedad")
         .AppendFormatLine("FROM CRMTiposCategoriasNovedades TCN")
      End With
   End Sub

End Class
