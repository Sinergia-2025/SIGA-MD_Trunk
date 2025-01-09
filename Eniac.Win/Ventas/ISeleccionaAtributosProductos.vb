Public Interface ISeleccionaAtributosProductos
   Inherits IDisposable

   Property Atributo01 As Entidades.AtributoProducto
   Property Atributo02 As Entidades.AtributoProducto
   Property Atributo03 As Entidades.AtributoProducto
   Property Atributo04 As Entidades.AtributoProducto

   Property idSucursal As Integer
   Property idProducto As String

   Function ShowDialog(owner As IWin32Window) As DialogResult

End Interface
Public Class SeleccionaAtributosProductosFactory
   Public Shared Function Create(tpComp As Entidades.TipoComprobante) As ISeleccionaAtributosProductos
      If tpComp.CoeficienteStock > 0 Then
         Return New SeleccionaAtributosProductos()
      Else
         Return New ObtenerAtributosProductos()
      End If
   End Function
End Class