Option Strict Off
Public Class CategoriasImagenes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CategoriasImagenes"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CategoriasImagenes"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CategoriasImagenes = New SqlServer.CategoriasImagenes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CategoriasImagenes(Me.da).CategoriasImagenes_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(idCategoriaImagen) AS Maximo")
         .Append(" FROM CategoriasImagenes")
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("Maximo").ToString())
         End If
      End If

      Return val

   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.CategoriaImagen = DirectCast(entidad, Entidades.CategoriaImagen)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.CategoriasImagenes = New SqlServer.CategoriasImagenes(da)

         Select Case tipo
            Case TipoSP._I

               sqlC.CategoriasImagenes_I(en)

               sqlC.GrabarFoto(Eniac.Entidades.Publicos.GetFotoFromBites(en.Foto), en.IdCategoriaImagen)

               sqlC.GrabarFotoReverso(Eniac.Entidades.Publicos.GetFotoFromBites(en.FotoReverso), en.IdCategoriaImagen)

            Case TipoSP._U
               sqlC.CategoriasImagenes_U(en)

               sqlC.GrabarFoto(Eniac.Entidades.Publicos.GetFotoFromBites(en.Foto), en.IdCategoriaImagen)

               sqlC.GrabarFotoReverso(Eniac.Entidades.Publicos.GetFotoFromBites(en.FotoReverso), en.IdCategoriaImagen)

            Case TipoSP._D
               sqlC.CategoriasImagenes_D(en.IdCategoriaImagen)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CategoriaImagen, ByVal dr As DataRow)
      With o
         .IdCategoriaImagen = Integer.Parse(dr(Entidades.CategoriaImagen.Columnas.IdCategoriaImagen.ToString()).ToString())
         .Categoria = New Reglas.Categorias().GetUno(Integer.Parse(dr(Entidades.CategoriaImagen.Columnas.IdCategoria.ToString())).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.CategoriaImagen.Columnas.IdTipoNave.ToString()).ToString()) Then
            .IdTipoNave = Integer.Parse(dr(Entidades.CategoriaImagen.Columnas.IdTipoNave.ToString())).ToString()
         End If

         If dr.Table.Columns.Contains(Entidades.CategoriaImagen.Columnas.Foto.ToString()) Then
            If Not String.IsNullOrEmpty(dr(Entidades.CategoriaImagen.Columnas.Foto.ToString()).ToString()) Then
               Dim content() As Byte = CType(dr("Foto"), Byte())
               Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
               .Foto = content
            End If
         End If

         If dr.Table.Columns.Contains(Entidades.CategoriaImagen.Columnas.FotoReverso.ToString()) Then
            If Not String.IsNullOrEmpty(dr(Entidades.CategoriaImagen.Columnas.FotoReverso.ToString()).ToString()) Then
               Dim content() As Byte = CType(dr("FotoReverso"), Byte())
               Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
               .FotoReverso = content
            End If
         End If

         If Not String.IsNullOrEmpty(dr(Entidades.CategoriaImagen.Columnas.ColorFuente.ToString()).ToString()) Then
            .ColorFuente = dr(Entidades.CategoriaImagen.Columnas.ColorFuente.ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.CategoriaImagen.Columnas.ColorFuenteVto.ToString()).ToString()) Then
            .ColorFuenteVto = dr(Entidades.CategoriaImagen.Columnas.ColorFuenteVto.ToString())
         End If

      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal idCategoriaImagen As Integer) As Entidades.CategoriaImagen
      Dim dt As DataTable = New SqlServer.CategoriasImagenes(Me.da).CategoriasImagenes_G1(idCategoriaImagen)
      Dim o As Entidades.CategoriaImagen = New Entidades.CategoriaImagen()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas() As List(Of Entidades.CategoriaImagen)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.CategoriaImagen
      Dim oLis As List(Of Entidades.CategoriaImagen) = New List(Of Entidades.CategoriaImagen)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CategoriaImagen()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUnoxCategoria(ByVal idCategoriaImagen As Integer, ByVal IdTipoNave As Short?) As Entidades.CategoriaImagen
      Dim dt As DataTable = New SqlServer.CategoriasImagenes(Me.da).GetImagenCategoria(idCategoriaImagen, IdTipoNave)
      Dim o As Entidades.CategoriaImagen = New Entidades.CategoriaImagen()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

#End Region

End Class

