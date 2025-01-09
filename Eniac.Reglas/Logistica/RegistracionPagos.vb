Option Strict On
Option Explicit On
Public Class RegistracionPagos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      da = accesoDatos
   End Sub

#End Region



#Region "Metodos Publicos"

   Public Function getMotivos() As DataTable
      Try
         Me.da.OpenConection()

         Dim dt As DataTable

         dt = New SqlServer.RegistracionPagos(Me.da).GetMotivos

         Return dt

      Catch ex As Exception

         Throw ex
      Finally
         Me.da.CloseConection()
      End Try
   End Function



   Public Sub ActualizarDatosCC(ByVal comprobantes As Eniac.Entidades.Venta _
                                , CC As Eniac.Entidades.CuentaCorriente _
                                , CCP As Eniac.Entidades.CuentaCorrientePago)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.RegistracionPagos = New SqlServer.RegistracionPagos(da)

         sql.ActualizarDatosCC(comprobantes.IdSucursal, comprobantes.TipoComprobante.IdTipoComprobante, comprobantes.LetraComprobante, _
                                                 comprobantes.CentroEmisor, comprobantes.NumeroComprobante _
                                                 , CC.FormaPago.IdFormasPago, CC.FechaVencimiento _
                                                 , CCP.FechaVencimiento)


         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try


   End Sub


   Public Function GetPedidos(idSucursal As Integer, distribucion As Integer, localidad As Integer,
                              numeroReparto As Integer, fechaHasta As DateTime, soloPendientesRendir As Boolean,
                              modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                              IdEmpleado As Integer, idRuta As Integer, dia As Entidades.Publicos.Dias?) As DataTable
      Try
         Me.da.OpenConection()
         Return _GetPedidos(idSucursal, distribucion, localidad, numeroReparto, fechaHasta, soloPendientesRendir, modoConsultarComprobantes, IdEmpleado, idRuta, dia)
      Finally
         Me.da.CloseConection()
      End Try
   End Function


   Public Function _GetPedidos(idSucursal As Integer, distribucion As Integer, localidad As Integer,
                               numeroReparto As Integer, fechaHasta As DateTime, soloPendientesRendir As Boolean,
                               modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                               IdEmpleado As Integer, idRuta As Integer, dia As Entidades.Publicos.Dias?) As DataTable
      Return New SqlServer.RegistracionPagos(Me.da).GetPedidos(idSucursal, distribucion, localidad, numeroReparto, fechaHasta, soloPendientesRendir, modoConsultarComprobantes, IdEmpleado, idRuta, dia)
   End Function

   Public Function GetPedidosProductos(idSucursal As Integer, distribucion As Integer, localidad As Integer,
                                       numeroReparto As Integer, fechaHasta As DateTime, soloPendientesRendir As Boolean,
                                       modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                                       IdEmpleado As Integer, idRuta As Integer, dia As Entidades.Publicos.Dias?) As DataTable
      Try
         Me.da.OpenConection()
         Return New SqlServer.RegistracionPagos(Me.da).GetPedidosProductos(idSucursal, distribucion, localidad, numeroReparto, fechaHasta, soloPendientesRendir, modoConsultarComprobantes, IdEmpleado, idRuta, dia)
      Finally
         Me.da.CloseConection()
      End Try
   End Function
#End Region

End Class
