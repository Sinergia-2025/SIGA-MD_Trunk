Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text
Imports Eniac.Datos
Imports actual = Eniac.Entidades.Usuario.Actual

#End Region

Public Class Contactos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Contactos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Contactos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)

      Me.EjecutaSP(entidad, TipoSP._I)

   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)

      Me.EjecutaSP(entidad, TipoSP._U)

   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      entidad.Columna = "C." & entidad.Columna

      Select Case entidad.Columna
         Case "C.NombreLocalidad"
            entidad.Columna = "L." + entidad.Columna.Replace("C.", "")

         Case "C.NombreZonaGeografica"
            entidad.Columna = "Z." + entidad.Columna.Replace("C.", "")

         Case "C.NombreLocalidadTrabajo"
            entidad.Columna = "L1.NombreLocalidad"

         Case "C.NombreGarante"
            entidad.Columna = "C1.NombreContacto"

         Case "C.NombreCategoria"
            entidad.Columna = "Ca." + entidad.Columna.Replace("C.", "")

         Case "C.NombreCategoriaFiscal"
            entidad.Columna = "Cf." + entidad.Columna.Replace("C.", "")

         Case "C.NombreVendedor"
            entidad.Columna = "E.NombreEmpleado"

         Case "C.NombreListaPrecios"
            entidad.Columna = "LdP.NombreListaPrecios"

         Case "C.NombreSucursalAsociada"
            entidad.Columna = "SA.Nombre"

         Case "C.NombreCaja"
            entidad.Columna = entidad.Columna.Replace("C.", "CN.")

         Case "C.DescripcionFormasPago"
            entidad.Columna = "FP.DescripcionFormasPago"

         Case "C.NombreTransportista"
            entidad.Columna = "T.NombreTransportista"

         Case "C.NombreProvincia"
            entidad.Columna = "P.NombreProvincia"

         Case "C.NombreContactoCtaCte"
            entidad.Columna = "C2.NombreContacto"

         Case "C.CodigoContactoCtaCte"
            entidad.Columna = "C2.CodigoContacto"

      End Select

      Dim blnIncluirFoto As Boolean = False
      Dim espaciosID As Boolean = True

      Me.SelectFiltrado(stbQuery, blnIncluirFoto, espaciosID)

      With stbQuery
         '.AppendLine(" WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")

         .AppendLine("  WHERE 1=1 ")

         Dim Palabras() As String = entidad.Valor.ToString.Split(" "c)

         For Each Palabra As String In Palabras
            .AppendLine("   AND " & entidad.Columna & " LIKE '%" & Palabra & "%'")
         Next

         .AppendLine(" ORDER BY C.NombreContacto")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Contactos(Me.da).Contactos_GA(Publicos.ContactosAgendaPrivada)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub SelectFiltrado(ByRef stb As StringBuilder, ByVal incluirFoto As Boolean, ByVal espaciosID As Boolean)

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

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.Contacto = DirectCast(entidad, Entidades.Contacto)
      Dim blnConexionAbierta As Boolean = Me.da.Connection.State = ConnectionState.Open

      Try

         If Not blnConexionAbierta Then
            da.OpenConection()
            da.BeginTransaction()
         End If

         Dim sql As SqlServer.Contactos = New SqlServer.Contactos(da)
         Dim sqlConDirecciones As SqlServer.ContactosDirecciones = New SqlServer.ContactosDirecciones(da)
         Select Case tipo

            Case TipoSP._I

               en.IdContacto = Me.GetCodigoMaximo(Entidades.Contacto.Columnas.IdContacto.ToString()) + 1

               sql.Contactos_I(en.IdContacto, en.NombreContacto, en.Direccion, _
                           en.IdLocalidad, en.Telefono, en.FechaNacimiento, en.CorreoElectronico, _
                           en.Celular, en.FechaAlta, en.CategoriaFiscal.IdCategoriaFiscal, en.Cuit, en.Observacion, en.ZonaGeografica.IdZonaGeografica,
                           en.Activo, en.GeoLocalizacionLat, en.GeoLocalizacionLng, _
                           en.TipoDocContacto, en.NroDocContacto, en.PaginaWeb, en.Usuario, en.IdTipoContacto, en.Privado)

               sql.GrabarFoto(en.Foto, en.IdContacto)

               'Elimino y grabo las direcciones
               sqlConDirecciones.ContactosDirecciones_D(en.IdContacto)
               Dim codigo As Integer = 1
               If en.Direcciones IsNot Nothing Then
                  For Each dr As DataRow In en.Direcciones.Rows
                     If dr.RowState <> DataRowState.Deleted Then

                        sqlConDirecciones.ContactosDirecciones_I(en.IdContacto, _
                                                codigo, dr("Direccion").ToString(), _
                                                Integer.Parse(dr("IdLocalidad").ToString()), Integer.Parse(dr("IdTipoDireccion").ToString()),
                                                 dr("Telefono").ToString(), dr("Celular").ToString(), dr("CorreoElectronico").ToString())
                        codigo += 1
                     End If
                  Next
               End If

            Case TipoSP._U
               sql.Contactos_U(en.IdContacto, en.NombreContacto, en.Direccion, _
                           en.IdLocalidad, en.Telefono, en.FechaNacimiento, en.CorreoElectronico, _
                           en.Celular, en.FechaAlta, en.CategoriaFiscal.IdCategoriaFiscal, en.Cuit, en.Observacion, en.ZonaGeografica.IdZonaGeografica,
                           en.Activo, en.GeoLocalizacionLat, en.GeoLocalizacionLng, _
                           en.TipoDocContacto, en.NroDocContacto, en.PaginaWeb, en.Usuario, en.IdTipoContacto, en.Privado)

               sql.GrabarFoto(en.Foto, en.IdContacto)

               'Elimino y grabo las direcciones
               sqlConDirecciones.ContactosDirecciones_D(en.IdContacto)
               Dim codigo As Integer = 1
               If en.Direcciones IsNot Nothing Then

                  For Each dr As DataRow In en.Direcciones.Rows
                     If dr.RowState <> DataRowState.Deleted Then

                        sqlConDirecciones.ContactosDirecciones_I(en.IdContacto, _
                                                codigo, dr("Direccion").ToString(), _
                                                Integer.Parse(dr("IdLocalidad").ToString()), Integer.Parse(dr("IdTipoDireccion").ToString()),
                                                 dr("Telefono").ToString(), dr("Celular").ToString(), dr("CorreoElectronico").ToString())
                        codigo += 1
                     End If
                  Next
               End If

            Case TipoSP._D

               sqlConDirecciones.ContactosDirecciones_D(en.IdContacto)

               sql.Contactos_D(en.IdContacto)

         End Select

         If Not blnConexionAbierta Then
            da.CommitTransaction()
         End If

      Catch ex As Exception

         If Not blnConexionAbierta Then
            da.RollbakTransaction()
         End If

         Throw ex

      Finally

         If Not blnConexionAbierta Then
            da.CloseConection()
         End If

      End Try

   End Sub

   Public Sub ActualizarGeolocalizacion(ByVal idContacto As Long, ByVal Lat As Double, ByVal lng As Double)

      Dim stbQuery As StringBuilder = New StringBuilder("")
      Try
         da.OpenConection()
         da.BeginTransaction()
         da.Command.Connection = da.Connection
         da.Command.Transaction = da.Transaction
         da.Command.CommandType = CommandType.Text

         With stbQuery
            .Length = 0
            .Append("UPDATE Contactos  SET ")
            .Append("  GeoLocalizacionLat = " & Lat & ", ")
            .Append("  GeoLocalizacionLng = " & lng & " ")
            .Append(" WHERE idContacto = " & idContacto.ToString())
         End With
         da.Command.CommandText = stbQuery.ToString

         da.Command.ExecuteNonQuery()

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Contacto, ByVal dr As DataRow)
      With o
         .FechaAlta = Date.Parse(dr("FechaAlta").ToString())
         .IdContacto = Long.Parse(dr("IdContacto").ToString())
         If Not String.IsNullOrEmpty(dr("NroDocContacto").ToString()) Then
            .TipoDocContacto = dr("TipoDocContacto").ToString()
            .NroDocContacto = Long.Parse(dr("NroDocContacto").ToString())
         End If
         .NombreContacto = dr("NombreContacto").ToString()
         .Direccion = dr("Direccion").ToString()
         .Localidad = New Reglas.Localidades(da).GetUna(Integer.Parse(dr("IdLocalidad").ToString()))
         .Telefono = dr("Telefono").ToString()
         .Celular = dr("Celular").ToString()
         .CorreoElectronico = dr("CorreoElectronico").ToString()
         .FechaNacimiento = Date.Parse(dr("FechaNacimiento").ToString())

         Dim cf As Reglas.CategoriasFiscales = New Reglas.CategoriasFiscales(da)
         .CategoriaFiscal = cf._GetUno(Short.Parse(dr("IdCategoriaFiscal").ToString()))

         .Cuit = dr("Cuit").ToString()

         Dim Vend As Reglas.Empleados = New Reglas.Empleados(da)

         .Observacion = dr("Observacion").ToString()

         .ZonaGeografica = New Reglas.ZonasGeograficas(Me.da).GetUno(dr("IdZonaGeografica").ToString())


         If dr.Table.Columns.Contains("Foto") Then
            If Not String.IsNullOrEmpty(dr("Foto").ToString()) Then
               Dim content() As Byte = CType(dr("Foto"), Byte())
               Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
               .Foto = New System.Drawing.Bitmap(stream)
            End If
         End If

         .Activo = Boolean.Parse(dr("Activo").ToString())
         If Not String.IsNullOrEmpty(dr("GeoLocalizacionLat").ToString()) Then
            .GeoLocalizacionLat = Double.Parse(dr("GeoLocalizacionLat").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("GeoLocalizacionLng").ToString()) Then
            .GeoLocalizacionLng = Double.Parse(dr("GeoLocalizacionLng").ToString())
         End If

         .PaginaWeb = dr("PaginaWeb").ToString()
         .Usuario = dr("IdUsuario").ToString()
         .IdTipoContacto = Integer.Parse(dr("IdTipoContacto").ToString())
         .Privado = Boolean.Parse(dr("Privado").ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetCodigoMaximo(ByVal Campo As String) As Long

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(" & Campo & ") AS Maximo")
         .Append(" FROM Contactos")
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Dim val As Long = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Long.Parse(dt.Rows(0)("Maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Function GetUno(ByVal idContacto As Long, Optional ByVal incluirFoto As Boolean = False) As Entidades.Contacto
      Try
         Me.da.OpenConection()

         Return Me._GetUno(idContacto, incluirFoto)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function _GetUno(ByVal idContacto As Long, Optional ByVal incluirFoto As Boolean = False) As Entidades.Contacto
      Dim sql As SqlServer.Contactos = New SqlServer.Contactos(Me.da)
      Dim dt As DataTable = sql.Contactos_G1(idContacto, incluirFoto)
      Dim oCli As Entidades.Contacto = New Entidades.Contacto()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(oCli, dt.Rows(0))
      End If
      Return oCli
   End Function

   Public Function GetUnoPorTipoYNroDocumento(ByVal tipoDocContacto As String, ByVal nroDocContacto As Long) As Entidades.Contacto
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Contactos = New SqlServer.Contactos(Me.da)
         Dim dt As DataTable = sql.GetUnoPorTipoYNroDocumento(tipoDocContacto, nroDocContacto)
         Dim oCli As Entidades.Contacto = New Entidades.Contacto()
         If dt.Rows.Count > 0 Then
            Me.CargarUno(oCli, dt.Rows(0))
         Else
            oCli = Nothing
         End If
         Return oCli
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetUnoPorCUIT(ByVal cuit As String) As Entidades.Contacto
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Contactos = New SqlServer.Contactos(Me.da)
         Dim dt As DataTable = sql.GetUnoPorCUIT(cuit)
         Dim oCli As Entidades.Contacto = New Entidades.Contacto()
         If dt.Rows.Count > 0 Then
            Me.CargarUno(oCli, dt.Rows(0))
         Else
            oCli = Nothing
         End If
         Return oCli
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCodigoContactoMaximo(ByVal IdContacto As String) As Long

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT ")
         .Append(" MAX(CAST(IdContacto as bigint)) AS maximo ")
         .Append(" FROM Contactos")
         .Append(" WHERE IdContacto = " & IdContacto)
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Dim val As Long = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Long.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Function Existe(ByVal IdContacto As Long) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT COUNT(IdContacto) AS Existe")
         .AppendLine("  FROM Contactos")
         .AppendFormat(" WHERE IdContacto = {0}", IdContacto)
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

   Public Function ExisteCodigo(ByVal codigoContacto As Long) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT COUNT(CodigoContacto) AS Existe")
         .AppendLine("  FROM Contactos")
         .AppendFormat(" WHERE CodigoContacto = {0}", codigoContacto)
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

#End Region

End Class
