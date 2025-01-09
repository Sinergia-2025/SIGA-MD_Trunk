Option Strict On
Option Explicit On

#Region "Imports"

Imports System.Text
Imports System.Linq


#End Region

Public Class ProductosConceptos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ProductosConceptos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ProductosConceptos"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Publicos"


   Public Function GetConceptos(ByVal IdProducto As String) As List(Of Entidades.ProductoConcepto)
      Try
         Dim conceptos As DataTable
         conceptos = New SqlServer.ProductosConceptos(Me.da).GetConceptos(IdProducto)
         Dim o As Entidades.ProductoConcepto
         Dim oLis As List(Of Entidades.ProductoConcepto) = New List(Of Entidades.ProductoConcepto)
         For Each dr As DataRow In conceptos.Rows
            o = New Entidades.ProductoConcepto()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next
         Return oLis

      Catch ex As Exception
         Throw
      End Try
   End Function

   Public Function GetPorProductoComponente(ByVal idSucursal As Integer, ByVal idProducto As String, ByVal idListaDePrecios As Integer) As DataTable
      Try
         Dim sql As SqlServer.ProductosConceptos = New SqlServer.ProductosConceptos(Me.da)
         Return sql.GetPorProductoComponente(idSucursal, idProducto, idListaDePrecios)
      Catch ex As Exception
         Throw
      End Try
   End Function

   Public Function GetInforme(ByVal IdSucursal As Integer, ByVal IdProducto As String, ByVal idFormula As Integer, ByVal idListaDePrecios As Integer) As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ProductosConceptos = New SqlServer.ProductosConceptos(Me.da)

         Dim dt As DataTable = sql.GetInforme(IdSucursal, IdProducto, idFormula, idListaDePrecios)

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Private Sub CargarUno(ByVal o As Entidades.ProductoConcepto, ByVal dr As DataRow)
      With o
         .IdProducto = dr("IdProducto").ToString()
         .IdConcepto = Integer.Parse(dr("IdConcepto").ToString())
         .NombreConcepto = dr("NombreConcepto").ToString()
      End With
   End Sub

#End Region


End Class