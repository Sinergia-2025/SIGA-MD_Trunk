
#Region "Imports"

Imports System.Text
'Imports Eniac.Datos
Imports actual = Eniac.Entidades.Usuario.Actual


#End Region

Public Class Contactos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Contactos_I(ByVal IdContacto As Long, _
                        ByVal NombreContacto As String, _
                        ByVal direccion As String, _
                        ByVal idLocalidad As Integer, _
                        ByVal telefono As String, _
                        ByVal fechaNacimiento As Date, _
                        ByVal correoElectronico As String, _
                        ByVal celular As String, _
                        ByVal fechaAlta As Date, _
                        ByVal idCategoriaFiscal As Short, _
                        ByVal cuit As String, _
                        ByVal observacion As String, _
                        ByVal IdZonaGeografica As String, _
                        ByVal Activo As Boolean, _
                        ByVal GeoLocalizacionLat As Double, _
                        ByVal GeoLocalizacionLng As Double, _
                        ByVal tipoDocContacto As String, _
                        ByVal nroDocContacto As Long, _
                        ByVal paginaWeb As String, _
                        ByVal Usuario As String, _
                        ByVal IdtipoContacto As Integer, _
                        ByVal Privado As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO Contactos ")
         .Append("(IdContacto,")
         .Append("NombreContacto, ")
         .Append("Direccion, ")
         .Append("IdLocalidad, ")
         .Append("Telefono, ")
         .Append("FechaNacimiento, ")
         .Append("CorreoElectronico, ")
         .Append("Celular, ")
         .Append("FechaAlta, ")
         .Append("IdCategoriaFiscal, ")
         .Append("Cuit, ")
         .Append("Observacion, ")
         .Append("IdZonaGeografica,")
         .Append("Activo, ")
         .Append("GeoLocalizacionLat,")
         .Append("GeoLocalizacionLng,")
         .Append(" TipoDocContacto, ")
         .Append(" NroDocContacto,")
         .Append(" PaginaWeb,")
         .Append(" IdUsuario,")
         .Append(" IdTipoContacto,")
         .Append(" Privado")
         .Append(") VALUES (")

         .Append(IdContacto.ToString() & ", ")

         .Append("'" & NombreContacto & "', ")
         .Append("'" & direccion & "', ")
         .Append("" & idLocalidad & ", ")
         .Append("'" & telefono & "', ")
         If fechaNacimiento = Nothing Then
            .Append("null, ")
         Else
            .Append("'" & Me.ObtenerFecha(fechaNacimiento, False) & "', ")
         End If
         .Append("'" & correoElectronico & "', ")
         .Append("'" & celular & "', ")
         .Append("'" & Me.ObtenerFecha(fechaAlta, True) & "', ")

         .Append(" " & idCategoriaFiscal & ", ")
         .Append(" '" & cuit & "', ")

         .Append(" '" & observacion & "', ")

         .Append(" '" & IdZonaGeografica & "', ")

         .Append(" '" & Activo.ToString() & "',")

         If GeoLocalizacionLat <> 0 Then
            .Append(GeoLocalizacionLat.ToString() & ",")
         Else
            .AppendLine("NULL,")
         End If
         If GeoLocalizacionLng > 0 Then
            .Append(GeoLocalizacionLng.ToString() & ",")
         Else
            .AppendLine("NULL,")
         End If

         If nroDocContacto > 0 Then
            .Append("'" & tipoDocContacto & "',")
            .Append("" & nroDocContacto.ToString() & ",")
         Else
            .Append("null, ")
            .Append("null, ")
         End If
         .Append("'" & paginaWeb & "',")
         .Append("'" & Usuario & "',")
         .Append(IdtipoContacto & ",")
         .Append("'" & Privado & "'")
         .Append(")")
         ''.Append("	SELECT @@IDENTITY as 'id'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Contactos")

   End Sub

   Public Sub Contactos_U(ByVal IdContacto As Long, _
                        ByVal NombreContacto As String, _
                        ByVal direccion As String, _
                        ByVal idLocalidad As Integer, _
                        ByVal telefono As String, _
                        ByVal fechaNacimiento As Date, _
                        ByVal correoElectronico As String, _
                        ByVal celular As String, _
                        ByVal fechaAlta As Date, _
                        ByVal idCategoriaFiscal As Short, _
                        ByVal cuit As String, _
                        ByVal observacion As String, _
                        ByVal IdZonaGeografica As String, _
                        ByVal Activo As Boolean, _
                        ByVal GeoLocalizacionLat As Double, _
                        ByVal GeoLocalizacionLng As Double, _
                        ByVal tipoDocContacto As String, _
                        ByVal nroDocContacto As Long, _
                        ByVal paginaWeb As String, _
                        ByVal Usuario As String, _
                        ByVal IdtipoContacto As Integer, _
                        ByVal Privado As Boolean)


      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Contactos ")
         .AppendLine("   SET NombreContacto = '" & NombreContacto & "'")
         .AppendLine("     , Direccion = '" & direccion & "'")
         .AppendLine("     , IdLocalidad = " & idLocalidad & "")
         .AppendLine("     , Telefono = '" & telefono & "'")
         .AppendLine("     , FechaNacimiento = '" & Me.ObtenerFecha(fechaNacimiento, False) & "'")
         .AppendLine("     , CorreoElectronico = '" & correoElectronico & "'")
         .AppendLine("     , Celular = '" & celular & "'")
         .AppendLine("     , FechaAlta = '" & Me.ObtenerFecha(fechaAlta, True) & "'")
         .AppendLine(", IdCategoriaFiscal = " & idCategoriaFiscal.ToString())

         If cuit.Trim().Length > 0 Then
            .AppendLine(", Cuit = '" & cuit & "' ")
         Else
            .AppendLine(", Cuit = NULL ")
         End If

         If observacion.Trim().Length > 0 Then
            .AppendLine(", Observacion = '" & observacion & "' ")
         Else
            .AppendLine(", Observacion = NULL ")
         End If

         .AppendLine(", IdZonaGeografica = '" & IdZonaGeografica & "'")
         .AppendLine(", Activo = '" & Activo.ToString() & "'")


         If GeoLocalizacionLat <> 0 Then
            .AppendLine(", GeoLocalizacionLat = " & GeoLocalizacionLat.ToString())
         Else
            .AppendLine(", GeoLocalizacionLat = NULL ")
         End If

         If GeoLocalizacionLng <> 0 Then
            .AppendLine(", GeoLocalizacionLng = " & GeoLocalizacionLng.ToString())
         Else
            .AppendLine(", GeoLocalizacionLng = NULL ")
         End If

         If nroDocContacto > 0 Then
            .AppendLine(" ,TipoDocContacto = '" & tipoDocContacto & "'")
            .AppendLine(" ,NroDocContacto = " & nroDocContacto.ToString())
         Else
            .AppendLine(", TipoDocContacto = NULL ")
            .AppendLine(", NroDocContacto = NULL ")
         End If

         .AppendLine(", paginaWeb = '" + paginaWeb + "'")
         .AppendLine(", IdUsuario = '" & Usuario & "'")
         .AppendLine(", IdTipoContacto = " & IdtipoContacto)
         .AppendLine(", Privado = '" & Privado & "'")

         .AppendLine(" WHERE IdContacto = " & IdContacto.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Contactos")

   End Sub

   Public Sub Contactos_D(ByVal IdContacto As Long)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM Contactos ")
         .Append(" WHERE IdContacto = " & IdContacto.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Contactos")
   End Sub

   Public Function Contactos_G1(ByVal IdContacto As Long, Optional ByVal incluirFoto As Boolean = False) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")

      Me.SelectTexto(stbQuery, incluirFoto)

      With stbQuery
         .AppendLine(" WHERE C.IdContacto = " & IdContacto.ToString())
      End With
      Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
      Return dt
   End Function

   Public Sub GrabarFoto(ByVal imagen As System.Drawing.Image, ByVal IdContacto As Long)

      If Not System.IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      End If

      Dim path As String = Entidades.Publicos.DriverBase + "Eniac\" + IdContacto.ToString() + ".jpg"

      Dim stbQuery As StringBuilder = New StringBuilder("")

      If imagen IsNot Nothing Then
         imagen.Save(path)

         Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

         Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString())

         Dim foto(Integer.Parse(fsArchivo.Length.ToString())) As Byte

         fsArchivo.Read(foto, 0, iFileLength)

         fsArchivo.Close()

         With stbQuery
            .Append(" UPDATE Contactos ")
            .Append(" SET Foto = ")
            .Append(" @Foto ")
            .AppendFormat(" WHERE IdContacto = {0}", IdContacto.ToString())
         End With

         Me._da.Command.CommandText = stbQuery.ToString()
         Me._da.Command.CommandType = CommandType.Text
         Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@Foto"
         oParameter.DbType = DbType.Binary
         oParameter.Size = foto.Length
         oParameter.Value = foto
         Me._da.Command.Parameters.Add(oParameter)
         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)
      Else
         With stbQuery
            .Append(" UPDATE Contactos ")
            .Append(" SET Foto = ")
            .Append(" null ")
            .AppendFormat(" WHERE IdContacto = {0}", IdContacto.ToString())
         End With

         Me.Execute(stbQuery.ToString())
      End If

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder, ByVal incluirFoto As Boolean)

      With stb
         .Length = 0
         .AppendLine("SELECT C.IdTipoContacto")
         .AppendLine("      ,TC.NombreTipoContacto")
         .AppendLine("      ,C.Privado")
         .AppendLine("      ,C.IdContacto")
         .AppendLine("      ,C.NombreContacto")
         .AppendLine("      ,C.Direccion")
         .AppendLine("      ,C.IdLocalidad")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,P.NombreProvincia")
         .AppendLine("      ,C.IdCategoriaFiscal")
         .AppendLine("      ,C.Telefono")
         .AppendLine("      ,C.Celular")
         .AppendLine("      ,C.CorreoElectronico")
         .AppendLine("      ,C.TipoDocContacto")
         .AppendLine("      ,C.NroDocContacto")
         .AppendLine("      ,Cf.NombreCategoriaFiscal")
         .AppendLine("      ,C.Cuit")
         .AppendLine("      ,C.IdZonaGeografica")
         .AppendLine("      ,Z.NombreZonaGeografica")
         .AppendLine("      ,C.FechaNacimiento")
         .AppendLine("      ,C.FechaAlta")
         .AppendLine("      ,C.Observacion")

         If incluirFoto Then
            .AppendLine("      ,C.Foto")
         Else
            .AppendLine("      ,NULL AS Foto")
         End If

         .AppendLine("      ,C.Activo ")
         .AppendLine("      ,C.GeoLocalizacionLat")
         .AppendLine("      ,C.GeoLocalizacionLng")
         .AppendLine("      ,C.PaginaWeb")
         .AppendLine("      ,C.IdUsuario")
         .AppendLine(" FROM Contactos C")
         .AppendLine(" LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine(" LEFT JOIN Provincias P ON P.IdProvincia = L.IdProvincia ")
         .AppendLine(" LEFT JOIN Localidades L1 ON L1.IdLocalidad = C.IdLocalidadTrabajo ")
         .AppendLine(" LEFT JOIN ZonasGeograficas Z  ON Z.IdZonaGeografica = C.IdZonaGeografica ")
         .AppendLine(" LEFT JOIN CategoriasFiscales Cf ON C.IdCategoriaFiscal = Cf.IdCategoriaFiscal ")
         .AppendLine(" LEFT JOIN TiposContactos TC ON TC.IdTipoContacto = C.IdTipoContacto")
      End With

   End Sub

   Public Function Contactos_GA(ByVal Privada As Boolean) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      Dim blnIncluirFoto As Boolean = False

      Me.SelectTexto(myQuery, blnIncluirFoto)

      With myQuery

         If Privada Then
            .AppendLine("WHERE (C.Privado = 'True' AND C.IdUsuario = '" & actual.Nombre & "') OR C.Privado = 'False'")
         Else
            .AppendLine("WHERE C.Privado = 'False'")
         End If

         .AppendLine(" ORDER BY C.NombreContacto ")

      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetUnoPorTipoYNroDocumento(ByVal tipoDocContacto As String, ByVal nroDocContacto As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      Dim consultaFoto As Boolean = False

      Me.SelectTexto(stb, consultaFoto)

      With stb
         .AppendLine(" WHERE C.TipoDocContacto = '" & tipoDocContacto & "'")
         .AppendLine("   AND C.NroDocContacto = " & nroDocContacto.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetUnoPorCUIT(ByVal cuit As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      Dim consultaFoto As Boolean = False

      Me.SelectTexto(stb, consultaFoto)

      With stb
         .AppendFormat(" WHERE C.Cuit = '{0}'", cuit.Replace("-", ""))
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
