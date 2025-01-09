Imports System.Runtime.CompilerServices
Namespace Extensiones
   Partial Module FormExtensions
#Region "Navegación"
      <Extension()>
      Public Sub NavegacionConEnter(form As IFormConNavegacion, e As KeyEventArgs, controlOrigen As Control)
         form.NavegacionConEnter(e, controlOrigen, Function(ctrl) Nothing)
      End Sub
      <Extension()>
      Public Sub NavegacionConEnter(form As IFormConNavegacion, e As KeyEventArgs, controlOrigen As Control, getDatosNavegacion As Func(Of Control, IDatosNavegacion))
         If e.KeyCode = Keys.Enter Then
            form.NavegacionConEnter(controlOrigen, getDatosNavegacion(controlOrigen))
         End If
      End Sub
      <Extension()>
      Public Sub NavegacionConEnter(form As IFormConNavegacion, controlOrigen As Control)
         form.NavegacionConEnter(controlOrigen, data:=Nothing)
      End Sub

      'Private Sub NavegacionConEnter(controlOrigen As Control, data As IDatosNavegacion)
      '   'If controlOrigen.Equals(txtDescRecGralPorc) Then
      '   '   Navegar(txtTotalGeneral, data)

      '   'ElseIf controlOrigen.Equals(txtProductoObservacion) Then
      '   '   If data.Producto IsNot Nothing AndAlso data.Producto.EsObservacion Then
      '   '      Navegar(txtCantidad, data)
      '   '   Else
      '   '      Navegar(btnInsertar, data)
      '   '   End If

      '   'ElseIf controlOrigen.Equals(txtCantidad) Then
      '   '   If chbModificaPrecio.Checked Or Decimal.Parse(txtPrecio.Text) = 0 Then
      '   '      Navegar(txtPrecio, data)
      '   '   Else
      '   '      Navegar(txtDescRecPorc1, data)
      '   '   End If
      '   'ElseIf controlOrigen.Equals(cmbPorcentajeIva) Then
      '   '   Navegar(txtDescRecPorc1, data)

      '   'ElseIf controlOrigen.Equals(txtPrecio) Then
      '   '   Navegar(txtDescRecPorc1, data)
      '   'ElseIf controlOrigen.Equals(txtDescRecPorc1) Then
      '   '   Navegar(cmbCriticidad, data)
      '   'ElseIf controlOrigen.Equals(cmbCriticidad) Then
      '   '   Navegar(dtpFechaEntregaProd, data)

      '   'ElseIf controlOrigen.Equals(txtPrecioDolares) Then
      '   '   Navegar(txtPrecio, data)

      '   'ElseIf controlOrigen.Equals(txtKilos) Then
      '   '   Navegar(txtPrecioPorKilos, data)
      '   'ElseIf controlOrigen.Equals(txtPrecioPorKilos) Then
      '   '   Navegar(txtUnidadesKilos, data)
      '   'ElseIf controlOrigen.Equals(txtUnidadesKilos) Then
      '   '   Navegar(txtCantidad, data)

      '   'ElseIf controlOrigen.Equals(dtpFechaEntregaProd) Then
      '   '   Navegar(btnInsertar, data)

      '   'ElseIf controlOrigen.Equals(txtPercepcionIVA) Then
      '   '   Navegar(txtPercepcionIIBB, data)
      '   'ElseIf controlOrigen.Equals(txtPercepcionIIBB) Then
      '   '   Navegar(txtPercepcionGanancias, data)
      '   'ElseIf controlOrigen.Equals(txtPercepcionGanancias) Then
      '   '   Navegar(txtPercepcionVarias, data)
      '   'ElseIf controlOrigen.Equals(txtPercepcionVarias) Then
      '   '   Navegar(txtTotalPercepcion, data)

      '   'End If
      'End Sub
      <Extension()>
      Public Sub Navegar(form As IFormConNavegacion, controlDestino As Control)
         form.Navegar(controlDestino, data:=Nothing)
      End Sub
      <Extension()>
      Public Sub Navegar(form As IFormConNavegacion, controlDestino As Control, data As IDatosNavegacion)
         If controlDestino.EsEditable AndAlso controlDestino.Visible Then
            controlDestino.Focus()
         Else
            form.NavegacionConEnter(controlDestino, data)
         End If
      End Sub
      'Private Class DatosNavegacion
      '   Public Property Producto As Entidades.Producto
      'End Class
#End Region
   End Module
   Public Interface IDatosNavegacion

   End Interface
   Public Interface IFormConNavegacion
      Sub NavegacionConEnter(controlOrigen As Control, data As IDatosNavegacion)
   End Interface
End Namespace