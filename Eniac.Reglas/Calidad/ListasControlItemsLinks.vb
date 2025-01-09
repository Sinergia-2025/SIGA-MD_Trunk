#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class ListasControlItemsLinks
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ListasControlItemsLinks"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ListasControlItemsLinks"
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
      Dim sql As SqlServer.ListasControlItemsLinks = New SqlServer.ListasControlItemsLinks(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Function GetCodigoMaximo(ByVal IdListaControl As Integer, ByVal Item As Integer) As Integer
      Return New SqlServer.ListasControlItemsLinks(da).GetCodigoMaximo(IdListaControl, Item)
   End Function
   Public Function GetAll(IdListaControl As Integer, item As Integer) As System.Data.DataTable
      Return New SqlServer.ListasControlItemsLinks(Me.da).ListasControlItemLinks_GA(IdListaControl, item)
   End Function



#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.ListaControlItemLinks = DirectCast(entidad, Entidades.ListaControlItemLinks)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ListasControlItemsLinks = New SqlServer.ListasControlItemsLinks(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.ListasControlItemLinks_I(en.IdListaControl, en.Item, en.ItemLink, en.Descripcion, en.Link)
            Case TipoSP._U
               sqlC.ListasControlItemLinks_U(en.IdListaControl, en.Item, en.ItemLink, en.Descripcion, en.Link)
            Case TipoSP._D
               sqlC.ListasControlItemLinks_D(en.IdListaControl, en.Item, en.ItemLink)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub
   Public Function GetUno(IdListaControl As Integer, Item As Integer, itemLink As Integer) As Entidades.ListaControlItemLinks
      Dim dt As DataTable = New SqlServer.ListasControlItemsLinks(Me.da).ListasControlItemLinks_G1(IdListaControl, Item, itemLink)
      Dim o As Entidades.ListaControlItemLinks = New Entidades.ListaControlItemLinks()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function
   Private Sub CargarUno(ByVal o As Entidades.ListaControlItemLinks, ByVal dr As DataRow)
      With o
         .IdListaControl = Integer.Parse(dr(Entidades.ListaControlItemLinks.Columnas.IdListaControl.ToString()).ToString())
         .Item = Integer.Parse(dr(Entidades.ListaControlItemLinks.Columnas.Item.ToString()).ToString())
         .ItemLink = Integer.Parse(dr(Entidades.ListaControlItemLinks.Columnas.ItemLink.ToString()).ToString())
         .Descripcion = dr(Entidades.ListaControlItemLinks.Columnas.Descripcion.ToString()).ToString()
         .Link = dr(Entidades.ListaControlItemLinks.Columnas.Link.ToString()).ToString()

      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Overloads Sub Borrar(IdListaControl As Integer, Item As Integer, itemLink As Integer)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ListasControlItemsLinks = New SqlServer.ListasControlItemsLinks(da)
         sqlC.ListasControlItemLinks_D(IdListaControl, Item, itemLink)

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Overloads Sub Insertar(ListasControlItemsLinks As List(Of Entidades.ListaControlItemLinks))
      For Each Item As Entidades.ListaControlItemLinks In ListasControlItemsLinks
         Me.EjecutaSP(Item, TipoSP._I)
      Next
   End Sub

   'Public Function GetUno(idEdicion As String, IdAplicacion As String, idModulo As Integer) As Entidades.ListaControlItemLinks
   '   Dim dt As DataTable = New SqlServer.ListasControlItemsLinks(Me.da).ListasControlItemsLinks_G1(idEdicion, IdAplicacion, idModulo)
   '   Dim o As Entidades.ListaControlItemLinks = New Entidades.ListaControlItemLinks()
   '   If dt.Rows.Count > 0 Then
   '      Dim dr As DataRow = dt.Rows(0)
   '      Me.CargarUno(o, dt.Rows(0))
   '   End If
   '   Return o
   'End Function

   Public Function GetTodas(IdListaControl As Integer, Item As Integer) As List(Of Entidades.ListaControlItemLinks)
      Dim dt As DataTable = New SqlServer.ListasControlItemsLinks(da).ListasControlItemLinks_GA(IdListaControl, Item)
      Dim o As Entidades.ListaControlItemLinks
      Dim oLis As List(Of Entidades.ListaControlItemLinks) = New List(Of Entidades.ListaControlItemLinks)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ListaControlItemLinks()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region

End Class