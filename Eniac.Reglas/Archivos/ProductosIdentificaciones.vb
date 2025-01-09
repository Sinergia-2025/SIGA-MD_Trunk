Option Strict On
Option Explicit On
Public Class ProductosIdentificaciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ProductoIdentificacion.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Inserta(DirectCast(entidad, Entidades.ProductoIdentificacion))
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Actualiza(DirectCast(entidad, Entidades.ProductoIdentificacion))
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Borra(DirectCast(entidad, Entidades.ProductoIdentificacion))
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ProductosIdentificaciones = New SqlServer.ProductosIdentificaciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ProductosIdentificaciones(Me.da).ProductosIdentificaciones_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Eniac.Entidades.ProductoIdentificacion, ByVal tipo As TipoSP)
      Dim sqlC As SqlServer.ProductosIdentificaciones = New SqlServer.ProductosIdentificaciones(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ProductosIdentificaciones_I(en.IdProducto, en.Identificacion)
         Case TipoSP._U
            sqlC.ProductosIdentificaciones_U(en.IdProducto, en.Identificacion)
         Case TipoSP._D
            sqlC.ProductosIdentificaciones_D(en.IdProducto, en.Identificacion)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ProductoIdentificacion, ByVal dr As DataRow)
      With o
         .IdProducto = dr(Entidades.ProductoIdentificacion.Columnas.IdProducto.ToString()).ToString()
         .Identificacion = dr(Entidades.ProductoIdentificacion.Columnas.Identificacion.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.ProductoIdentificacion)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.ProductoIdentificacion)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.ProductoIdentificacion)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub Borra(en As Eniac.Entidades.Producto)
      Dim sqlC As SqlServer.ProductosIdentificaciones = New SqlServer.ProductosIdentificaciones(da)
      sqlC.ProductosIdentificaciones_D(en.IdProducto, identificacion:=String.Empty)
   End Sub

   Public Sub InsertaDesdeProducto(ByVal entidad As Eniac.Entidades.Producto)
      If entidad.Identificaciones IsNot Nothing Then
         For Each ident As Entidades.ProductoIdentificacion In entidad.Identificaciones
            ident.IdProducto = entidad.IdProducto.Trim()
            Inserta(ident)
         Next
      End If
   End Sub

   Public Function GetUno(idProducto As String, identificacion As String) As Entidades.ProductoIdentificacion
      Dim dt As DataTable = New SqlServer.ProductosIdentificaciones(Me.da).ProductosIdentificaciones_G1(idProducto, identificacion)
      Dim o As Entidades.ProductoIdentificacion = New Entidades.ProductoIdentificacion()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.ProductoIdentificacion)
      Return CargaLista(New SqlServer.ProductosIdentificaciones(Me.da).ProductosIdentificaciones_GA())
   End Function
   Public Function GetTodos(idProducto As String) As List(Of Entidades.ProductoIdentificacion)
      Return CargaLista(New SqlServer.ProductosIdentificaciones(Me.da).ProductosIdentificaciones_GA(idProducto))
   End Function

   Private Function CargaLista(dt As DataTable) As List(Of Entidades.ProductoIdentificacion)
      Dim o As Entidades.ProductoIdentificacion
      Dim oLis As List(Of Entidades.ProductoIdentificacion) = New List(Of Entidades.ProductoIdentificacion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ProductoIdentificacion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class