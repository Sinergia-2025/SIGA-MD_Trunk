Public Class Aplicaciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Aplicaciones_I(idAplicacion As String,
                             nombreAplicacion As String,
                             idAplicacionBase As String,
                             propietarioAplicacion As Entidades.AplicacionPropietario)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Aplicaciones")
         .AppendFormatLine("    (IdAplicacion")
         .AppendFormatLine("   , NombreAplicacion")
         .AppendFormatLine("   , IdAplicacionBase")
         .AppendFormatLine("   , PropietarioAplicacion")
         .AppendFormatLine(" ) VALUES ( ")

         .AppendFormatLine("     '{0}'", idAplicacion)
         .AppendFormatLine("   , '{0}'", nombreAplicacion)
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idAplicacionBase))
         .AppendFormatLine("   , '{0}'", propietarioAplicacion.ToString())
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub Aplicaciones_U(idAplicacion As String,
                             nombreAplicacion As String,
                             idAplicacionBase As String,
                             propietarioAplicacion As Entidades.AplicacionPropietario)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Aplicaciones")
         .AppendFormatLine("   SET NombreAplicacion = '{0}'", nombreAplicacion)
         .AppendFormatLine("     , IdAplicacionBase = '{0}'", GetStringParaQueryConComillas(idAplicacionBase))
         .AppendFormatLine("     , PropietarioAplicacion = '{0}'", propietarioAplicacion.ToString())
         .AppendFormatLine(" WHERE IdAplicacion = '{0}'", idAplicacion)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Aplicaciones_D(idAplicacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM Aplicaciones WHERE {0} = '{1}'", Entidades.Aplicacion.Columnas.IdAplicacion.ToString(), idAplicacion)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Append("SELECT P.*")
         .Append("  FROM Aplicaciones P ")
      End With
   End Sub

   Public Function Aplicaciones_GA(propietarioAplicacion As Entidades.AplicacionPropietario?) As DataTable
      Return Aplicaciones_GA(idAplicacion:=String.Empty, nombreAplicacion:=String.Empty, idExacto:=True, nombreExacto:=True, propietarioAplicacion)
   End Function
   Public Function Aplicaciones_GA(idAplicacion As String, nombreAplicacion As String, idExacto As Boolean, nombreExacto As Boolean, propietarioAplicacion As Entidades.AplicacionPropietario?) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idAplicacion) Then
            If idExacto Then
               .AppendFormatLine("   AND P.{0} = '{1}'", Entidades.Aplicacion.Columnas.IdAplicacion.ToString(), idAplicacion)
            Else
               .AppendFormatLine("   AND P.{0} LIKE '%{1}%'", Entidades.Aplicacion.Columnas.IdAplicacion.ToString(), idAplicacion)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(nombreAplicacion) Then
            If nombreExacto Then
               .AppendFormatLine("   AND P.{0} = '{1}'", Entidades.Aplicacion.Columnas.NombreAplicacion.ToString(), nombreAplicacion)
            Else
               .AppendFormatLine("   AND P.{0} LIKE '%{1}%'", Entidades.Aplicacion.Columnas.NombreAplicacion.ToString(), nombreAplicacion)
            End If
         End If
         If propietarioAplicacion.HasValue Then
            .AppendFormatLine("   AND P.{0} = '{1}'", Entidades.Aplicacion.Columnas.PropietarioAplicacion.ToString(), propietarioAplicacion.Value.ToString())
         End If
         .AppendLine(" ORDER BY P.NombreAplicacion")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function Aplicaciones_G1(idAplicacion As String) As DataTable
      Return Aplicaciones_GA(idAplicacion, nombreAplicacion:=String.Empty, idExacto:=True, nombreExacto:=True, propietarioAplicacion:=Nothing)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "P")
   End Function
End Class
