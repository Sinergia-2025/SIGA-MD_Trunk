Option Strict On
Option Explicit On
#Region "Option/Imports"
Imports Eniac.Entidades
#End Region
Public Class ProductosLinks
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ProductosLinks"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ProductosLinks"
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

   Public Function GetCodigoMaximo(ByVal IdProducto As String) As Integer
      Return New SqlServer.ProductosLinks(da).GetCodigoMaximo(IdProducto)
   End Function

   Public Overrides Function GetAll(ByVal IdProducto As String) As System.Data.DataTable
      Return New SqlServer.ProductosLinks(Me.da).ProductosLinks_GA(IdProducto)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.ProductoLinks = DirectCast(entidad, Entidades.ProductoLinks)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ProductosLinks = New SqlServer.ProductosLinks(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.ProductosLinks_I(en.IdProducto, en.ItemLink, en.Descripcion, en.Link, en.IdTipoAdjunto)
            Case TipoSP._U
               sqlC.ProductosLinks_U(en.IdProducto, en.ItemLink, en.Descripcion, en.Link, en.IdTipoAdjunto)
            Case TipoSP._D
               sqlC.ProductosLinks_D(en.IdProducto, en.ItemLink)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ProductoLinks, ByVal dr As DataRow)
      With o
         .IdProducto = dr(Entidades.ProductoLinks.Columnas.IdProducto.ToString()).ToString()
         .ItemLink = Integer.Parse(dr(Entidades.ProductoLinks.Columnas.ItemLink.ToString()).ToString())
         .Descripcion = dr(Entidades.ProductoLinks.Columnas.Descripcion.ToString()).ToString()
         .Link = dr(Entidades.ProductoLinks.Columnas.Link.ToString()).ToString()
         .IdTipoAdjunto = Integer.Parse(dr(Entidades.ProductoLinks.Columnas.IdTipoAdjunto.ToString()).ToString())
         .NombreTipoAdjunto = dr(Entidades.ProductoLinks.Columnas.NombreTipoAdjunto.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Overloads Sub Borrar(IdProducto As String, itemLink As Integer)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ProductosLinks = New SqlServer.ProductosLinks(da)
         sqlC.ProductosLinks_D(IdProducto, itemLink)

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Overloads Sub Insertar(ProductosLinks As List(Of Entidades.ProductoLinks))
      For Each Item As Entidades.ProductoLinks In ProductosLinks
         Me.EjecutaSP(Item, TipoSP._I)
      Next
   End Sub

   Public Sub ActualizaDesdeProducto(entidad As Eniac.Entidades.Producto)
      If entidad.ArchivosAdjuntos IsNot Nothing Then
         For Each ent As Entidades.ProductoLinks In entidad.ArchivosAdjuntos
            If ent.ItemLink > 0 Then
               Actualizar(ent)
            Else
               ent.ItemLink = GetCodigoMaximo(ent.IdProducto) + 1
               Insertar(ent)
            End If
         Next
         For Each ent As Entidades.ProductoLinks In entidad.ArchivosAdjuntos.Borrados
            If ent.ItemLink > 0 Then
               Borrar(ent)
            End If
         Next
      End If
   End Sub

   Public Function GetUno(IdProducto As String, ByVal ItemLink As Integer) As Entidades.ProductoLinks
      Dim dt As DataTable = New SqlServer.ProductosLinks(Me.da).ProductosLinks_G1(IdProducto, ItemLink)
      Dim o As Entidades.ProductoLinks = New Entidades.ProductoLinks()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas(IdProducto As String) As List(Of Entidades.ProductoLinks)
      Dim dt As DataTable = New SqlServer.ProductosLinks(da).ProductosLinks_GA(IdProducto)
      Dim o As Entidades.ProductoLinks
      Dim oLis As List(Of Entidades.ProductoLinks) = New List(Of Entidades.ProductoLinks)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ProductoLinks()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function _GetTodas(IdProducto As String) As ListConBorrados(Of Entidades.ProductoLinks)
      Dim dt As DataTable = New SqlServer.ProductosLinks(da).ProductosLinks_GA(IdProducto)
      Dim o As Entidades.ProductoLinks
      Dim oLis = New ListConBorrados(Of Entidades.ProductoLinks)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ProductoLinks()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
#End Region

End Class