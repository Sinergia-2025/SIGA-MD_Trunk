Public Class ProductosModelosSubTipos
   Inherits Comunes

#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub ProductosModelosSubTipos_I(IdProductoModeloSubTipo As Integer,
                                  NombreProductoModeloSubTipo As String,
                                         IdProductoModeloTipo As Integer)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO CalidadProductosModelosSubTipos (")
         .AppendFormatLine("	IdProductoModeloSubTipo,")
         .AppendFormatLine("	NombreProductoModeloSubTipo,")
         .AppendFormatLine("	IdProductoModeloTipo")

         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	{0}", IdProductoModeloSubTipo)
         .AppendFormatLine("	,'{0}'", NombreProductoModeloSubTipo)
         .AppendFormatLine("	,{0}", IdProductoModeloTipo)

         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProductosModelosSubTipos_U(IdProductoModeloSubTipo As Integer,
                                  NombreProductoModeloSubTipo As String,
                                         IdProductoModeloTipo As Integer)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE CalidadProductosModelosSubTipos SET")
         .AppendFormatLine("	NombreProductoModeloSubTipo = '{0}'", NombreProductoModeloSubTipo)
         .AppendFormatLine("	,IdProductoModeloTipo = {0}", IdProductoModeloTipo)
         .AppendFormatLine(" WHERE IdProductoModeloSubTipo = {0}", IdProductoModeloSubTipo)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProductosModelosSubTipos_D(IdProductoModeloSubTipo As Integer)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE CalidadProductosModelosSubTipos WHERE IdProductoModeloSubTipo = {0}", IdProductoModeloSubTipo)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function ProductosModelosSubTipos_GA() As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProductosModelosSubTipos_GetPorNombre(ModeloSubTipo As String) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendLine(" WHERE NombreProductoModeloSubTipo LIKE '%" & ModeloSubTipo & "%'")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProductosModelosSubTipos_GetPorTipo(IdProductoModeloTipo As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormat(" WHERE PMT.IdProductoModeloTipo = {0} ", IdProductoModeloTipo)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProductosModelosSubTipos_G1(IdProductoModeloSubTipo As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine(" WHERE PMST.IdProductoModeloSubTipo = {0}", IdProductoModeloSubTipo)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	PMST.IdProductoModeloSubTipo,")
         .AppendFormatLine("	PMST.NombreProductoModeloSubTipo,")
         .AppendFormatLine("	PMT.IdProductoModeloTipo,")
         .AppendFormatLine("	PMT.NombreProductoModeloTipo")
         .AppendFormatLine(" FROM CalidadProductosModelosSubTipos PMST")
         .AppendFormatLine(" INNER JOIN CalidadProductosModelosTipos PMT ON PMT.IdProductoModeloTipo = PMST.IdProductoModeloTipo ")
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
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ProductoModeloSubTipo.Columnas.IdProductoModeloSubTipo.ToString(), Entidades.ProductoModeloSubTipo.NombreTabla))
   End Function

End Class
