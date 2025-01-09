Public Class ProveedoresComparar
   Inherits Comunes

#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub ProveedoresComparar_I(idProveedor As Long,
                                    idPlantilla As Integer,
                                    fechaActualizacion As Date)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO ProveedoresComparar (")
         .AppendFormatLine("     IdProveedor, ")
         .AppendFormatLine("     IdPlantilla, ")
         .AppendFormatLine("     FechaActualizacion)")
         .AppendFormatLine("VALUES (")
         .AppendFormatLine("     {0} ", idProveedor)
         .AppendFormatLine("     ,{0} ", idPlantilla)
         .AppendFormatLine("     ,'{0}'", ObtenerFecha(fechaActualizacion, True))
         .AppendLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProveedoresComparar_U(idProveedor As Long,
                                    idPlantilla As Integer,
                                    fechaActualizacion As Date)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE ProveedoresComparar SET")
         .AppendFormatLine("     {0} = {1}", Entidades.ProveedorComparar.Columnas.IdPlantilla.ToString(), idPlantilla)
         .AppendFormatLine("     ,{0} = '{1}'", Entidades.ProveedorComparar.Columnas.FechaActualizacion.ToString(), ObtenerFecha(fechaActualizacion, True))
         .AppendFormatLine("  WHERE {0} = {1}", Entidades.ProveedorComparar.Columnas.IdProveedor.ToString(), idProveedor)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProveedoresComparar_D(idProveedor As Long)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE ProveedoresComparar")
         .AppendFormatLine("  WHERE {0} = {1}", Entidades.ProveedorComparar.Columnas.IdProveedor.ToString(), idProveedor)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function ProveedoresComparar_GA() As DataTable

      Dim query As StringBuilder = New StringBuilder
      SelectTexto(query)

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProveedoresComparar_G1(idProveedor As Long) As DataTable

      Dim query As StringBuilder = New StringBuilder
      SelectTexto(query)
      With query
         .AppendFormatLine("  WHERE P.{0} = {1}", Entidades.ProveedorComparar.Columnas.IdProveedor.ToString(), idProveedor)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function Existe(idProveedor As Long) As Boolean
      Return ProveedoresComparar_G1(idProveedor).Rows.Count > 0
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendLine("SELECT ")
         .AppendLine("   PC.IdProveedor")
         .AppendLine("   ,P.NombreProveedor")
         .AppendLine("   ,PC.IdPlantilla")
         .AppendLine("   ,PL.NombrePlantilla")
         .AppendLine("   ,PC.FechaActualizacion")
         .AppendLine("FROM ProveedoresComparar PC")
         .AppendLine("INNER JOIN Proveedores P ON PC.IdProveedor = P.IdProveedor")
         .AppendLine("INNER JOIN Plantillas PL ON PC.IdPlantilla = PL.IdPlantilla")
      End With
   End Sub

End Class
