Public Class TiposDirecciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposDirecciones_I(idTipoDireccion As Integer,
                                 nombreTipoDireccion As String,
                                 nombreAbrevTipoDireccion As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO TiposDirecciones (")
         .AppendFormatLine("       IdTipoDireccion")
         .AppendFormatLine("     , NombreTipoDireccion")
         .AppendFormatLine("     , NombreAbrevTipoDireccion")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("        {0} ", idTipoDireccion)
         .AppendFormatLine("     , '{0}'", nombreTipoDireccion)
         .AppendFormatLine("     , '{0}'", nombreAbrevTipoDireccion)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "TiposDirecciones")
   End Sub

   Public Sub TiposDirecciones_U(idTipoDireccion As Integer,
                                 nombreTipoDireccion As String,
                                 nombreAbrevTipoDireccion As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE TiposDirecciones")
         .AppendFormatLine("   SET NombreTipoDireccion = '{0}'", nombreTipoDireccion)
         .AppendFormatLine("     , NombreAbrevTipoDireccion = '{0}'", nombreAbrevTipoDireccion)

         .AppendFormatLine(" WHERE IdTipoDireccion = {0}", idTipoDireccion)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "TiposDirecciones")
   End Sub

   Public Sub TiposDirecciones_D(IdTipoDireccion As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM TiposDirecciones  ")
         .AppendFormatLine(" WHERE IdTipoDireccion = {0}", IdTipoDireccion)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "TiposDirecciones")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT TD.*")
         .AppendLine("  FROM TiposDirecciones TD ")
      End With
   End Sub

   Public Function TiposDirecciones_GA() As DataTable
      Return TiposDirecciones_G(idTipoDireccion:=0, nombreTipoDireccion:=String.Empty, nombreTipoDireccionExacto:=False)
   End Function
   Public Function TiposDirecciones_G1(idTipoDireccion As Integer) As DataTable
      Return TiposDirecciones_G(idTipoDireccion, nombreTipoDireccion:=String.Empty, nombreTipoDireccionExacto:=False)
   End Function
   Public Function TiposDirecciones_GA_PorNombre(nombreTipoDireccion As String, nombreTipoDireccionExacto As Boolean) As DataTable
      Return TiposDirecciones_G(idTipoDireccion:=0, nombreTipoDireccion, nombreTipoDireccionExacto)
   End Function

   Public Function TiposDirecciones_G(idTipoDireccion As Integer, nombreTipoDireccion As String, nombreTipoDireccionExacto As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If idTipoDireccion > 0 Then
            .AppendFormatLine("   AND TD.IdTipoDireccion = {0}", idTipoDireccion)
         End If
         If Not String.IsNullOrWhiteSpace(nombreTipoDireccion) Then
            If nombreTipoDireccionExacto Then
               .AppendFormatLine("   AND TD.NombreTipoDireccion = '{0}'", nombreTipoDireccion)
            Else
               .AppendFormatLine("   AND TD.NombreTipoDireccion LIKE '%{0}%'", nombreTipoDireccion)
            End If
         End If
         .AppendLine(" ORDER BY TD.NombreTipoDireccion")
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "TD.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.TipoDireccion.Columnas.IdTipoDireccion.ToString(), Entidades.TipoDireccion.NombreTabla).ToInteger()
   End Function

End Class