Public Class ProductosModelosTipos
   Inherits Comunes

#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub ProductosModelosTipos_I(IdProductoModeloTipo As Integer,
                                  NombreProductoModeloTipo As String)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO CalidadProductosModelosTipos (")
         .AppendFormatLine("	IdProductoModeloTipo,")
         .AppendFormatLine("	NombreProductoModeloTipo")

         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	{0}", IdProductoModeloTipo)
         .AppendFormatLine("	,'{0}'", NombreProductoModeloTipo)

         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProductosModelosTipos_U(IdProductoModeloTipo As Integer,
                                  NombreProductoModeloTipo As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE CalidadProductosModelosTipos SET")
         .AppendFormatLine("	NombreProductoModeloTipo = '{0}'", NombreProductoModeloTipo)
         .AppendFormatLine(" WHERE IdProductoModeloTipo = {0}", IdProductoModeloTipo)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProductosModelosTipos_D(IdProductoModeloTipo As Integer)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE CalidadProductosModelosTipos WHERE IdProductoModeloTipo = {0}", IdProductoModeloTipo)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function ProductosModelosTipos_GA() As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProductosModelosTipos_GetPorNombre(ModeloTipo As String) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendLine(" WHERE NombreProductoModeloTipo LIKE '%" & ModeloTipo & "%'")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProductosModelosTipos_G1(IdProductoModeloTipo As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine(" WHERE PMT.IdProductoModeloTipo = {0}", IdProductoModeloTipo)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	PMT.IdProductoModeloTipo,")
         .AppendFormatLine("	PMT.NombreProductoModeloTipo")

         .AppendFormatLine("FROM CalidadProductosModelosTipos PMT")
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
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ProductoModeloTipo.Columnas.IdProductoModeloTipo.ToString(), Entidades.ProductoModeloTipo.NombreTabla))
   End Function

End Class
