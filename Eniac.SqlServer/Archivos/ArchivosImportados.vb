Public Class ArchivosImportados
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ArchivosImportados_I(IdFuncion As String,
                         IdSubFuncion As String,
                         NombreArchivo As String,
                         FechaLectura As DateTime,
                         IdUsuario As String,
                         NombrePC As String, IdSucursal As Integer)

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO ArchivosImportados (")
         .AppendFormatLine("      IdFuncion")
         .AppendFormatLine("    , IdSubFuncion")
         .AppendFormatLine("    , NombreArchivo")
         .AppendFormatLine("    , FechaLectura")
         .AppendFormatLine("    , IdUsuario")
         .AppendFormatLine("    , NombrePC")
         .AppendFormatLine("    , IdSucursal")
         .AppendFormatLine("    ) VALUES (")
         .AppendFormatLine("    '{0}' ", IdFuncion)
         .AppendFormatLine("    ,'{0}' ", IdSubFuncion)
         .AppendFormatLine("    ,'{0}' ", NombreArchivo)
         .AppendFormatLine("    ,'{0}'", ObtenerFecha(FechaLectura, True, True))
         .AppendFormatLine("    ,'{0}'", IdUsuario)
         .AppendFormatLine("    ,'{0}'", NombrePC)
         .AppendFormatLine("    ,{0}", IdSucursal)
         .AppendFormatLine("    )")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub ArchivosImportados_D(IdFuncion As String,
                         IdSubFuncion As String,
                         NombreArchivo As String)
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Append("DELETE FROM ArchivosImportados")
         .AppendFormat(" WHERE IdFuncion = '{0}'", IdFuncion)
         .AppendFormat(" AND IdSubFuncion = '{0}'", IdSubFuncion)
         .AppendFormat(" AND NombreArchivo = '{0}'", NombreArchivo)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT B.*")
         .AppendLine("  FROM ArchivosImportados B")
         .AppendLine("  INNER JOIN Funciones F ON F.Id = B.IdFuncion")
      End With
   End Sub

   Public Function ArchivosImportados_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY IdFuncion")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ArchivosImportados_G1(IdFuncion As String,
                         IdSubFuncion As String,
                         NombreArchivo As String, IdSucursal As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE IdFuncion = '{0}'", IdFuncion)
         .AppendFormat(" AND IdSubFuncion = '{0}'", IdSubFuncion)
         .AppendFormat(" AND NombreArchivo = '{0}'", NombreArchivo)
         .AppendFormat(" AND IdSucursal = {0}", IdSucursal)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      columna = "B." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function


End Class