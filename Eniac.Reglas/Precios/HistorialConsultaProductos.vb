Option Strict On
Option Explicit On

#Region "Imports"

Imports System.Text

#End Region

Public Class HistorialConsultaProductos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "HistorialConsultaProductos"
      da = New Datos.DataAccess()
   End Sub
   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub Grabar(ByVal idProducto As String, _
                                 ByVal idSucursal As Integer, _
                                 ByVal fechaHora As Date, _
                                 ByVal usuario As String)

      Try
         da.OpenConection()
         da.BeginTransaction()
         Dim sql As SqlServer.HistorialConsultaProductos = New SqlServer.HistorialConsultaProductos(Me.da)

         sql.HistorialConsultaProductos_I(idProducto, idSucursal, fechaHora, usuario)
         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos Privados"

#End Region

#Region "Metodos Publicos"

   Public Function GetHistorialConsultaProductos(ByVal idSucursales As Integer(), _
                                       ByVal fechaDesde As Date, _
                                       ByVal fechaHasta As Date, _
                                       ByVal idProducto As String, _
                                       ByVal idMarca As Integer, _
                                       ByVal idRubro As Integer, _
                                       ByVal usuario As String) As DataTable

      Try
         Me.da.OpenConection()

         Dim OcultarProdNoStock As Boolean
         OcultarProdNoStock = Publicos.ConsultarPreciosOcultarProdNoAfectanStock

         Dim sql As SqlServer.HistorialConsultaProductos = New SqlServer.HistorialConsultaProductos(Me.da)
         Return sql.GetHistorialConsultaProductos(idSucursales, fechaDesde, fechaHasta, idProducto, idMarca, idRubro, usuario, OcultarProdNoStock)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function



#End Region

End Class
