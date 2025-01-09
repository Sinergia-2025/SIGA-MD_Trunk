Option Strict On
Option Explicit On
Public Class Clasificaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Clasificaciones_I(idClasificacion As Integer, nombreClasificacion As String)
      Dim query As StringBuilder = New StringBuilder()
      With query

         .AppendLine("INSERT INTO Clasificaciones(")
         .AppendLine("            IdClasificacion")
         .AppendLine("           ,NombreClasificacion")
         .AppendLine(") VALUES (")

         .AppendFormatLine("  {0}", idClasificacion)
         .AppendFormatLine(",'{0}'", nombreClasificacion)
         .AppendLine(")")

      End With
      Me.Execute(query.ToString())
   End Sub

   Public Sub Clasificaciones_U(idClasificacion As Integer, nombreClasificacion As String)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .Append("UPDATE Clasificaciones SET")
         .AppendFormatLine("       NombreClasificacion = '{0}'", nombreClasificacion)
         
         .AppendFormatLine(" WHERE IdClasificacion = {0}", idClasificacion)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub Clasificaciones_D(idClasificacion As Integer)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormat("DELETE FROM Clasificaciones WHERE IdClasificacion = {0}", idClasificacion)
      End With

      Me.Execute(query.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT ")
         .AppendLine("    C.IdClasificacion")
         .AppendLine("   ,C.NombreClasificacion")
         .AppendLine("FROM Clasificaciones C")
      End With
   End Sub

   Public Function Clasificaciones_GA() As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendLine("  ORDER BY C.NombreClasificacion")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function Clasificaciones_G1(idClasificacion As Integer) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendFormat(" WHERE IdClasificacion = {0}", idClasificacion)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      'columna = "TND." + columna

      Dim query As StringBuilder = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Integer.Parse(MyBase.GetCodigoMaximo("IdClasificacion", "Clasificaciones").ToString())
   End Function

End Class
