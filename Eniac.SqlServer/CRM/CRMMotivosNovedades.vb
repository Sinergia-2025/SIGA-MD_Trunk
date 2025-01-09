Public Class CRMMotivosNovedades
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMMotivosNovedades_I(idMotivoNovedad As Integer,
                                    nombreMotivoNovedad As String,
                                    posicion As Integer,
                                    idTipoNovedad As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO CRMMotivosNovedades (", Entidades.CRMMotivoNovedad.NombreTabla)
         .AppendFormatLine("      {0} ", Entidades.CRMMotivoNovedad.Columnas.IdMotivoNovedad.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CRMMotivoNovedad.Columnas.NombreMotivoNovedad.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CRMMotivoNovedad.Columnas.Posicion.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.CRMMotivoNovedad.Columnas.IdTipoNovedad.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("      {0} ", idMotivoNovedad)
         .AppendFormatLine("   , '{0}'", nombreMotivoNovedad)
         .AppendFormatLine("   ,  {0} ", posicion)
         .AppendFormatLine("   , '{0}'", idTipoNovedad)
         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMMotivosNovedades_U(idMotivoNovedad As Integer,
                                    nombreMotivoNovedad As String,
                                    posicion As Integer,
                                    idTipoNovedad As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CRMMotivosNovedades ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMMotivoNovedad.Columnas.NombreMotivoNovedad.ToString(), nombreMotivoNovedad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMMotivoNovedad.Columnas.Posicion.ToString(), posicion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMMotivoNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CRMMotivoNovedad.Columnas.IdMotivoNovedad.ToString(), idMotivoNovedad)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMMotivosNovedades_D(idMotivoNovedad As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM CRMMotivosNovedades WHERE {0} = '{1}'", Entidades.CRMMotivoNovedad.Columnas.IdMotivoNovedad.ToString(), idMotivoNovedad)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT MN.*, TN.NombreTipoNovedad")
         .AppendFormatLine("  FROM CRMMotivosNovedades AS MN")
         .AppendFormatLine("  INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = MN.IdTipoNovedad")
      End With
   End Sub

   Public Function CRMMotivosNovedades_GA() As DataTable
      Return CRMMotivosNovedades_GA(String.Empty, False)
   End Function
   Public Function CRMMotivosNovedades_GA(idTipoNovedad As String, ordenarPosicion As Boolean) As DataTable
      Return CRMMotivosNovedades_G(idTipoNovedad, ordenarPosicion, idMotivoNovedad:=0)
   End Function
   Public Function CRMMotivosNovedades_G(idTipoNovedad As String, ordenarPosicion As Boolean, idMotivoNovedad As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine(" WHERE MN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If idMotivoNovedad <> 0 Then
            .AppendFormatLine("   AND MN.IdMotivoNovedad = {0}", idMotivoNovedad)
         End If
         If ordenarPosicion Then
            .AppendFormatLine(" ORDER BY TN.NombreTipoNovedad, MN.Posicion")
         Else
            .AppendFormatLine(" ORDER BY TN.NombreTipoNovedad, MN.NombreMotivoNovedad")
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function CRMMotivosNovedades_G1(IdMotivoNovedad As Integer) As DataTable
      Return CRMMotivosNovedades_G(idTipoNovedad:=String.Empty, ordenarPosicion:=True, IdMotivoNovedad)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), "MN.",
                    New Dictionary(Of String, String) From
                     {{"NombreTipoNovedad", "TN.NombreTipoNovedad"}})
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.CRMMotivoNovedad.Columnas.IdMotivoNovedad.ToString(), "CRMMotivosNovedades"))
   End Function

End Class