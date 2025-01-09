Imports Eniac.Entidades

Public Class CRMTiposEstadosNovedades
   Inherits Comunes
#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub CRMTiposEstadosNovedades_I(idTipoEstadoNovedad As Integer,
                                            nombreTipoEstadoNovedad As String,
                                            posicion As Integer,
                                            idTipoNovedad As String)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO CRMTiposEstadosNovedades (")
         .AppendFormatLine("	IdTipoEstadoNovedad,")
         .AppendFormatLine("	NombreTipoEstadoNovedad,")
         .AppendFormatLine("	Posicion,")
         .AppendFormatLine("	IdTipoNovedad")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	{0}", idTipoEstadoNovedad)
         .AppendFormatLine("	,'{0}'", nombreTipoEstadoNovedad)
         .AppendFormatLine("	,{0}", posicion)
         .AppendFormatLine("	,'{0}'", idTipoNovedad)
         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub CRMTiposEstadosNovedades_U(idTipoEstadoNovedad As Integer,
                                            nombreTipoEstadoNovedad As String,
                                            posicion As Integer,
                                            idTipoNovedad As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE CRMTiposEstadosNovedades SET")
         .AppendFormatLine("	NombreTipoEstadoNovedad = '{0}'", nombreTipoEstadoNovedad)
         .AppendFormatLine("	,Posicion = {0}", posicion)
         .AppendFormatLine("	,IdTipoNovedad = '{0}'", idTipoNovedad)
         .AppendFormatLine("WHERE IdTipoEstadoNovedad = {0}", idTipoEstadoNovedad)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub CRMTiposEstadosNovedades_D(idTipoEstadoNovedad As Integer)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE CRMTiposEstadosNovedades WHERE IdTipoEstadoNovedad = {0}", idTipoEstadoNovedad)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function CRMTiposEstadosNovedades_GA(idTipoNovedad As String) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         If Not String.IsNullOrEmpty(idTipoNovedad) Then
            .AppendFormatLine(" WHERE TEN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function CRMTiposEstadosNovedades_GA() As DataTable
      Return Me.CRMTiposEstadosNovedades_GA(Nothing)
   End Function

   Public Function CRMTiposEstadosNovedades_G1(idTipoEstadoNovedad As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         .AppendFormatLine("WHERE TEN.IdTipoEstadoNovedad = {0}", idTipoEstadoNovedad)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	TEN.IdTipoEstadoNovedad,")
         .AppendFormatLine("	TEN.NombreTipoEstadoNovedad,")
         .AppendFormatLine("	TEN.Posicion,")
         .AppendFormatLine("	TEN.IdTipoNovedad,")
         .AppendFormatLine("	TN.NombreTipoNovedad")
         .AppendFormatLine("FROM CRMTiposEstadosNovedades TEN")
         .AppendFormatLine("INNER JOIN CRMTiposNovedades TN ON TEN.IdTipoNovedad = TN.IdTipoNovedad")
      End With
   End Sub

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      If columna = "NombreTipoNovedad" Then
         columna = "TN." + columna
      Else
         columna = "TEN." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(CRMTipoEstadoNovedad.Columnas.IdTipoEstadoNovedad.ToString(), "CRMTiposEstadosNovedades"))
   End Function
End Class
