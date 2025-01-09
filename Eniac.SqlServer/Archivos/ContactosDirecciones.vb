Imports System.Text

Public Class ContactosDirecciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ContactosDirecciones_I(ByVal IdContacto As Long, _
                                        ByVal IdDireccion As Integer, _
                                        ByVal Direccion As String, _
                                         ByVal IdLocalidad As Integer, _
                                         ByVal IdTipoDireccion As Integer, _
                                         ByVal Telefono As String, _
                                         ByVal Celular As String, _
                                         ByVal CorreoElectronico As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO ContactosDirecciones")
         .AppendLine("   (IdContacto")
         .AppendLine("   ,IdDireccion")
         .AppendLine("   ,Direccion")
         .AppendLine("   ,IdLocalidad")
         .AppendLine("   ,IdTipoDireccion")
         .AppendLine("   ,Telefono")
         .AppendLine("   ,Celular")
         .AppendLine("   ,CorreoElectronico")
         .AppendLine(" ) VALUES (")
         .AppendLine("   " & IdContacto)
         .AppendLine("   ," & IdDireccion)
         .AppendLine("  ,'" & Direccion & "'")
         .AppendLine("  ," & IdLocalidad.ToString())
         .AppendLine("  ," & IdTipoDireccion.ToString())
         .AppendLine("  ,'" & Telefono & "'")
         .AppendLine("  ,'" & Celular & "'")
         .AppendLine("  ,'" & CorreoElectronico & "'")
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ContactosDirecciones")

   End Sub

   Public Sub ContactosDirecciones_D(ByVal IdContacto As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE FROM ContactosDirecciones ")
         .AppendLine(" WHERE IdContacto = " & IdContacto)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ContactosDirecciones")

   End Sub

   Public Function GetContactosDirecciones(ByVal IdContacto As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT CD.IdContacto ")
         '    .AppendLine(" ,CD.IdDireccion")
         .AppendLine(" ,CD.Direccion       ,CD.IdLocalidad  ")
         .AppendLine(" ,L.NombreLocalidad, P.NombreProvincia ")
         .AppendLine(" ,CD.IdTipoDireccion")
         .AppendLine(" ,TD.NombreAbrevTipoDireccion")
         .AppendLine(",CD.Telefono, CD.Celular, CD.CorreoElectronico")
         .AppendLine(" FROM ContactosDirecciones CD  ")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = CD.IdLocalidad ")
         .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia  ")
         .AppendLine(" INNER JOIN TiposDirecciones TD ON TD.IdTipoDireccion = CD.IdTipoDireccion  ")
         If IdContacto <> 0 Then
            .AppendLine("	WHERE CD.IdContacto = " & IdContacto)
         End If
         .AppendLine(" ORDER BY CD.Direccion")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function GetDireccionContacto(ByVal IdContacto As Long, ByVal IdDireccion As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT CD.IdContacto ")
         .AppendLine(" ,CD.Direccion       ,CD.IdLocalidad  ")
         .AppendLine(" ,L.NombreLocalidad, P.NombreProvincia ")
         .AppendLine("  ,TD.NombreAbrevTipoDireccion")
         .AppendLine(",CD.Celular, CD.Telefono, CD.CorreoElectronico")
         .AppendLine(" FROM ContactosDirecciones CD  ")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = CD.IdLocalidad ")
         .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia  ")
         .AppendLine(" INNER JOIN TiposDirecciones TD ON TD.IdTipoDireccion = CD.IdTipoDireccion  ")
         .AppendLine("	WHERE CD.IdContacto = " & IdContacto)
         .AppendLine(" AND CD.IdDireccion = " & IdDireccion)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetDirecciones(ByVal IdContacto As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("  SELECT 0 as IdDireccion, C.Direccion  + ' - ' + L.NombreLocalidad + ' - '+ P.NombreProvincia as DireccionAMostrar ")
         .AppendLine(" FROM Contactos  C ")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad  ")
         .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia ")
         If IdContacto <> 0 Then
            .AppendLine(" WHERE C.IdContacto = " & IdContacto)
         End If
         .AppendLine("UNION ALL SELECT CD.IdDireccion, CD.Direccion  + ' - ' + L.NombreLocalidad  + ' - '+ P.NombreProvincia as DireccionAMostrar ")
         .AppendLine(" FROM ContactosDirecciones CD  ")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = CD.IdLocalidad ")
         .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia  ")
         If IdContacto <> 0 Then
            .AppendLine("	WHERE CD.IdContacto = " & IdContacto)
         End If
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function


End Class
