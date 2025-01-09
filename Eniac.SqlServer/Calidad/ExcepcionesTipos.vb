Public Class ExcepcionesTipos
   Inherits Comunes

#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub ExcepcionesTipos_I(IdExcepcionTipo As Integer,
                                  NombreExcepcionTipo As String)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO CalidadExcepcionesTipos (")
         .AppendFormatLine("	IdExcepcionTipo,")
         .AppendFormatLine("	NombreExcepcionTipo")

         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	{0}", IdExcepcionTipo)
         .AppendFormatLine("	,'{0}'", NombreExcepcionTipo)
         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ExcepcionesTipos_U(IdExcepcionTipo As Integer,
                                  NombreExcepcionTipo As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE CalidadExcepcionesTipos SET")
         .AppendFormatLine("	NombreExcepcionTipo = '{0}'", NombreExcepcionTipo)

         .AppendFormatLine("WHERE IdExcepcionTipo = {0}", IdExcepcionTipo)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ExcepcionesTipos_D(IdExcepcionTipo As Integer)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE CalidadExcepcionesTipos WHERE IdExcepcionTipo = {0}", IdExcepcionTipo)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function ExcepcionesTipos_GA() As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function


   Public Function ExcepcionesTipos_G1(IdExcepcionTipo As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("WHERE CET.IdExcepcionTipo = {0}", IdExcepcionTipo)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	CET.IdExcepcionTipo,")
         .AppendFormatLine("	CET.NombreExcepcionTipo")

         .AppendFormatLine("FROM CalidadExcepcionesTipos CET")
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
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ExcepcionTipo.Columnas.IdExcepcionTipo.ToString(), Entidades.ExcepcionTipo.NombreTabla))
   End Function

End Class
