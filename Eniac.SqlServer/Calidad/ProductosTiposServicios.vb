Public Class ProductosTiposServicios
   Inherits Comunes

#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub ProductosTiposServicios_I(IdProductoTipoServicio As Integer,
                                  NombreProductoTipoServicio As String,
                                  Prefijo As String)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO CalidadProductosTiposServicios (")
         .AppendFormatLine("	IdProductoTipoServicio,")
         .AppendFormatLine("	NombreProductoTipoServicio,")
         .AppendFormatLine("	Prefijo")

         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	{0}", IdProductoTipoServicio)
         .AppendFormatLine("	,'{0}'", NombreProductoTipoServicio)
         .AppendFormatLine("	,'{0}'", Prefijo)

         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProductosTiposServicios_U(IdProductoTipoServicio As Integer,
                                  NombreProductoTipoServicio As String,
                                   Prefijo As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE CalidadProductosTiposServicios SET")
         .AppendFormatLine("	NombreProductoTipoServicio = '{0}'", NombreProductoTipoServicio)
         .AppendFormatLine("	,Prefijo = '{0}'", Prefijo)

         .AppendFormatLine("WHERE IdProductoTipoServicio = {0}", IdProductoTipoServicio)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProductosTiposServicios_D(IdProductoTipoServicio As Integer)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE CalidadProductosTiposServicios WHERE IdProductoTipoServicio = {0}", IdProductoTipoServicio)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function ProductosTiposServicios_GA() As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProductosTiposServicios_GABMCalidad() As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendLine("  WHERE IdProductoTipoServicio < 4 ")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProductosTiposServicios_G1(IdProductoTipoServicio As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("WHERE PTS.IdProductoTipoServicio = {0}", IdProductoTipoServicio)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	PTS.IdProductoTipoServicio,")
         .AppendFormatLine("	PTS.NombreProductoTipoServicio,")
         .AppendFormatLine("	PTS.Prefijo")

         .AppendFormatLine("FROM CalidadProductosTiposServicios PTS")
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
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ProductoTipoServicio.Columnas.IdProductoTipoServicio.ToString(), Entidades.ProductoTipoServicio.NombreTabla))
   End Function

End Class
