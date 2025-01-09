Public Class ProductosModelos
   Inherits Comunes

#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub ProductosModelos_I(IdProductoModelo As Integer,
                                  NombreProductoModelo As String,
                                 CodigoProductoModelo As String,
                                 IdProductoModeloTipo As Integer,
                                 IdProductoModeloSubTipo As Integer)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO CalidadProductosModelos (")
         .AppendFormatLine("	IdProductoModelo,")
         .AppendFormatLine("	NombreProductoModelo,")
         .AppendFormatLine("  CodigoProductoModelo,")
         .AppendFormatLine("  IdProductoModeloTipo,")
         .AppendFormatLine("  IdProductoModeloSubTipo")

         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	{0}", IdProductoModelo)
         .AppendFormatLine("	,'{0}'", NombreProductoModelo)
         .AppendFormatLine("	,'{0}'", CodigoProductoModelo)
         If IdProductoModeloTipo > 0 Then
            .AppendFormatLine("	,{0}", IdProductoModeloTipo)
         Else
            .AppendFormatLine("	,NULL")
         End If
         If IdProductoModeloSubTipo > 0 Then
            .AppendFormatLine("	,{0}", IdProductoModeloSubTipo)
         Else
            .AppendFormatLine("	,NULL")
         End If


         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProductosModelos_U(IdProductoModelo As Integer,
                                  NombreProductoModelo As String,
                                  CodigoProductoModelo As String,
                                  IdProductoModeloTipo As Integer,
                                  IdProductoModeloSubTipo As Integer)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE CalidadProductosModelos SET")
         .AppendFormatLine("	NombreProductoModelo = '{0}'", NombreProductoModelo)
         If IdProductoModeloTipo > 0 Then
            .AppendFormatLine("	,IdProductoModeloTipo = {0}", IdProductoModeloTipo)
         Else
            .AppendFormatLine("	,IdProductoModeloTipo = NULL")
         End If
         If IdProductoModeloSubTipo > 0 Then
            .AppendFormatLine("	,IdProductoModeloSubTipo = {0}", IdProductoModeloSubTipo)
         Else
            .AppendFormatLine("	,IdProductoModeloSubTipo = NULL")
         End If
         ' .AppendFormatLine("	CodigoProductoModelo = '{0}'", CodigoProductoModelo)
         .AppendFormatLine(" WHERE IdProductoModelo = {0}", IdProductoModelo)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProductosModelos_D(IdProductoModelo As Integer)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE CalidadProductosModelos WHERE IdProductoModelo = {0}", IdProductoModelo)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function ProductosModelos_GA() As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProductosModelos_GetPorNombre(Modelo As String) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendLine(" WHERE NombreProductoModelo LIKE '%" & Modelo & "%'")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProductosModelos_G1(IdProductoModelo As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("WHERE PTS.IdProductoModelo = {0}", IdProductoModelo)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProductosModelos_G1xCodigo(CodigoProductoModelo As String) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("WHERE PTS.CodigoProductoModelo = '{0}'", CodigoProductoModelo)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	PTS.IdProductoModelo,")
         .AppendFormatLine("	PTS.NombreProductoModelo,")
         .AppendFormatLine("  PTS.CodigoProductoModelo,")
         .AppendFormatLine("	PTS.IdProductoModeloTipo,")
         .AppendFormatLine("	PMT.NombreProductoModeloTipo,")
         .AppendFormatLine("	PTS.IdProductoModeloSubTipo,")
         .AppendFormatLine("	PMST.NombreProductoModeloSubTipo")

         .AppendFormatLine(" FROM CalidadProductosModelos PTS")
         .AppendFormatLine("LEFT JOIN CalidadProductosModelosTipos PMT ON PMT.IdProductoModeloTipo = PTS.IdProductoModeloTipo")
         .AppendFormatLine("LEFT JOIN CalidadProductosModelosSubTipos PMST ON PMST.IdProductoModeloSubTipo = PTS.IdProductoModeloSubTipo")

      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ProductoModelo.Columnas.IdProductoModelo.ToString(), Entidades.ProductoModelo.NombreTabla))
   End Function

   Public Function GetModelosBejerman(ByVal Base As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder

      With stb
         .Length() = 0
         .AppendLine("SELECT art_CodGen, art_DescGen FROM " & Base & ".dbo.Vista_Articulos A")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function
End Class
