Public Class Calles
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Calles_I(idCalle As Integer, nombreCalle As String, idLocalidad As Integer)
      Dim stb = New StringBuilder()
      With stb
         .Append("INSERT INTO Calles")
         .Append("           (IdCalle")
         .Append("           ,NombreCalle")
         .Append("           ,IdLocalidad)")
         .Append("     VALUES (")
         .AppendFormat("           {0}", idCalle)
         .AppendFormat("           ,'{0}'", nombreCalle)
         .AppendFormat("           ,{0}", idLocalidad)
         .Append(")")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub Calles_U(idCalle As Integer, nombreCalle As String, idLocalidad As Integer)
      Dim stb = New StringBuilder()
      With stb
         .Append("UPDATE Calles")
         .Append("   SET ")
         .AppendFormat("      NombreCalle = '{0}'", nombreCalle)
         .AppendFormat("      ,IdLocalidad = {0}", idLocalidad)
         .AppendFormat(" WHERE IdCalle = {0}", idCalle)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub Calles_D(idCalle As Integer)
      Dim stb = New StringBuilder()

      With stb
         .Append("DELETE FROM Calles ")
         .AppendFormat(" WHERE IdCalle = {0}", idCalle)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Append("SELECT C.*")
         .Append("     , L.NombreLocalidad")
         .Append("  FROM Calles C")
         .Append("  LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
      End With
   End Sub

   Public Function Calles_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY C.IdLocalidad, C.NombreCalle")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Calles_G1(idCalle As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE C.IdCalle = {0}", idCalle)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      columna = "C." + columna
      If columna = "C.NombreLocalidad" Then columna = columna.Replace("C.", "L.")
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorLocalidad(idLocalidad As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE C.IdLocalidad = {0}", idLocalidad)
         .AppendFormat(" ORDER BY C.NombreCalle")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorLocalidadYNombre(idLocalidad As Integer, nombreCalle As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE C.IdLocalidad = {0}", idLocalidad)
         .AppendFormat(" AND C.NombreCalle LIKE '%{0}%'", nombreCalle)
         .AppendFormat(" ORDER BY C.NombreCalle")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorId(idCalle As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE C.IdCalle = {0}", idCalle)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorNombre(nombreCalle As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" Where C.NombreCalle LIKE '%{0}%'", nombreCalle)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdCalle", "Calles"))
   End Function

End Class