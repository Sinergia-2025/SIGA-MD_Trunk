Option Explicit On
Option Strict On

Imports System.Text

Public Class AlquileresTarifasProductos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "AlquileresTarifasProductos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As System.Data.DataTable
      Dim sql As SqlServer.AlquileresTarifasProductos = New SqlServer.AlquileresTarifasProductos(Me.da)
      Return sql.Buscar(entidad.IdSucursal, entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.AlquileresTarifasProductos(Me.da).TarifaProducto_GA(1)
   End Function

   Public Function GetAll2(ByVal idSucursal As Integer) As System.Data.DataTable
      Return New SqlServer.AlquileresTarifasProductos(Me.da).TarifaProducto_GA(idSucursal)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.AlquilerTarifaProducto = DirectCast(entidad, Entidades.AlquilerTarifaProducto)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.AlquileresTarifasProductos = New SqlServer.AlquileresTarifasProductos(Me.da)

         Select Case tipo

            Case TipoSP._I
               sql.Tarifa_I(en.IdSucursal, en.IdProducto, en.dtdetalles)

            Case TipoSP._U
               sql.Tarifa_U(en.IdSucursal, en.IdProducto, en.dtdetalles)


            Case TipoSP._D
               sql.Tarifa_D(en.IdSucursal, en.IdProducto)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUna(ByVal o As Entidades.AlquilerTarifaProducto, ByVal dr As DataRow, ByVal dtDetalle As DataTable)
      With o
         '.IdSucursal = Integer.Parse(dr(Entidades.AlquilerTarifaProducto.Columnas.IdSucursal.ToString()).ToString())
         .IdProducto = dr(Entidades.AlquilerTarifaProducto.Columnas.IdProducto.ToString()).ToString()
         .NombreProducto = dr(Entidades.AlquilerTarifaProducto.Columnas.NombreProducto.ToString()).ToString()
         .dtdetalles = dtDetalle
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.AlquilerTarifaProducto)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.AlquilerTarifaProducto
      Dim dtDetalle As DataTable = Nothing ' no cargo los detalles del asiento cuando muestro la grilla de busqueda
      Dim oLis As List(Of Entidades.AlquilerTarifaProducto) = New List(Of Entidades.AlquilerTarifaProducto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.AlquilerTarifaProducto()
         Me.CargarUna(o, dr, dtDetalle)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUna(ByVal idSucursal As Integer, ByVal IdProducto As String) As Entidades.AlquilerTarifaProducto
      Dim sql As SqlServer.AlquileresTarifasProductos = New SqlServer.AlquileresTarifasProductos(Me.da)
      Dim dt As DataTable = sql.TarifaProducto_G1(idSucursal, IdProducto)
      Dim dtDetalle As DataTable = sql.Tarifa_GetDetalle(idSucursal, IdProducto)
      Dim o As Entidades.AlquilerTarifaProducto = New Entidades.AlquilerTarifaProducto()
      If dt.Rows.Count > 0 Then
         Me.CargarUna(o, dt.Rows(0), dtDetalle)
      Else
         Throw New Exception("No existe la tarifa")
      End If
      Return o
   End Function

   Public Function Get1(ByVal idSucursal As Integer, ByVal IdProducto As String) As DataTable
      Dim sql As SqlServer.AlquileresTarifasProductos = New SqlServer.AlquileresTarifasProductos(Me.da)
      Return sql.TarifaProducto_G1(idSucursal, IdProducto)
   End Function

   'Public Function GetIdMaximo() As Integer

   '    Dim sql As SqlServer.Tarifas = New SqlServer.Tarifas(Me.da)
   '    Dim dt As DataTable = sql.Tarifa_GetIdMaximo()
   '    Dim val As Integer = 0

   '    If dt.Rows.Count > 0 Then
   '        If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
   '            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
   '        End If
   '    End If

   '    Return val

   'End Function

#End Region

End Class
