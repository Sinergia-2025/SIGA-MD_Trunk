Imports System.Windows.Forms

Public Class BuscadoresCampos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub BuscadoresCampos_I(idBuscador As Integer, idBuscadorNombreCampo As String, orden As Integer, titulo As String,
                           alineacion As DataGridViewContentAlignment, ancho As Integer, formato As String,
                           condicion As Entidades.BuscadorCampo.TipoCondicion, valorCondicion As String, colorFilaCondicion As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO BuscadoresCampos(")
         .AppendFormatLine("     IdBuscador")
         .AppendFormatLine("   , IdBuscadorNombreCampo")
         .AppendFormatLine("   , Orden")
         .AppendFormatLine("   , Titulo")
         .AppendFormatLine("   , Alineacion")
         .AppendFormatLine("   , Ancho")
         .AppendFormatLine("   , Formato")
         .AppendFormatLine("   , Condicion")
         .AppendFormatLine("   , Valor")
         .AppendFormatLine("   , ColorFila")
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("      {0} ", idBuscador)
         .AppendFormatLine("   , '{0}'", idBuscadorNombreCampo)
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   , '{0}'", titulo)
         .AppendFormatLine("   ,  {0} ", CInt(alineacion))
         .AppendFormatLine("   ,  {0} ", ancho)
         .AppendFormatLine("   , '{0}'", formato)
         .AppendFormatLine("   , '{0}'", condicion.ToString())
         .AppendFormatLine("   , '{0}'", valorCondicion)
         .AppendFormatLine("   , '{0}'", colorFilaCondicion)
         .AppendLine(")")
      End With
      Execute(query)
   End Sub
   Public Sub BuscadoresCampos_U(idBuscador As Integer, idBuscadorNombreCampo As String, orden As Integer, titulo As String,
                           alineacion As DataGridViewContentAlignment, ancho As Integer, formato As String,
                           condicion As Entidades.BuscadorCampo.TipoCondicion, valorCondicion As String, colorFilaCondicion As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE BuscadoresCampos")
         .AppendFormatLine("   SET Orden = {0}", orden)
         .AppendFormatLine("     , Titulo = '{0}'", titulo)
         .AppendFormatLine("     , Alineacion = {0}", CInt(alineacion))
         .AppendFormatLine("     , Ancho = {0}", ancho)
         .AppendFormatLine("     , Formato = '{0}'", formato)
         .AppendFormatLine("     , Condicion = '{0}'", condicion.ToString())
         .AppendFormatLine("     , Valor = '{0}'", valorCondicion)
         .AppendFormatLine("     , ColorFila = '{0}'", colorFilaCondicion)
         .AppendFormatLine(" WHERE IdBuscador = {0}", idBuscador)
         .AppendFormatLine("   AND IdBuscadorNombreCampo = '{0}'", idBuscadorNombreCampo)
      End With
      Execute(query)
   End Sub
   Public Sub BuscadoresCampos_D(idBuscador As Integer, idBuscadorNombreCampo As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("DELETE FROM BuscadoresCampos")
         .AppendFormatLine(" WHERE IdBuscador = {0}", idBuscador)
         If Not String.IsNullOrWhiteSpace(idBuscadorNombreCampo) Then
            .AppendFormatLine("   AND IdBuscadorNombreCampo = '{0}'", idBuscadorNombreCampo)
         End If
      End With
      Execute(query)
   End Sub

   Public Function GetBuscadorCampos(idBuscador As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT BC.*")
         .AppendLine("  FROM BuscadoresCampos BC")
         .AppendFormatLine(" WHERE BC.IdBuscador = {0}", idBuscador)
         .AppendLine(" ORDER BY BC.Orden")
      End With
      Return GetDataTable(stbQuery)
   End Function

End Class