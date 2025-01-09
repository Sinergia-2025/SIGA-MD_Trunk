Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Namespace JSonEntidades.Archivos
   'Public Class OrdenCompraJSon

   'End Class
   Public Class OrdenCompraJSon
      Public Property CuitEmpresa As String
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Integer
      Public Property NumeroPedido As Long
      Public Property Fecha As String

      Public Property IdProveedor As Long
      Public Property DatosOrdenCompra As IEnumerable(Of OrdenCompraProductoJSon)
      'Public Property DatosOrdenCompra As String

      Public Property FechaActualizacion As String

      Public Sub New()
         DatosOrdenCompra = New List(Of OrdenCompraProductoJSon)()
      End Sub

      Public Sub New(cuitEmpresa As String,
                     idSucursal As Integer,
                     idTipoComprobante As String,
                     letra As String,
                     centroEmisor As Integer,
                     numeroComprobante As Long,
                     fecha As String,
                     idProveedor As Long,
                     fechaActualizacion As String)
         Me.New()
         Me.CuitEmpresa = cuitEmpresa

         Me.IdSucursal = idSucursal
         Me.IdTipoComprobante = idTipoComprobante
         Me.Letra = letra
         Me.CentroEmisor = centroEmisor
         Me.NumeroPedido = numeroComprobante

         Me.Fecha = fecha
         Me.IdProveedor = idProveedor

         Me.FechaActualizacion = fechaActualizacion
      End Sub
   End Class

   Public Class OrdenCompraProductoJSon
      Public Property CuitEmpresa As String
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Integer
      Public Property NumeroPedido As Long
      Public Property IdProducto As String
      Public Property NombreProducto As String
      Public Property Cantidad As Decimal
      Public Property Precio As Decimal
      Public Property FechaEntrega As String
      Public Property IdEstado As String

   End Class

End Namespace