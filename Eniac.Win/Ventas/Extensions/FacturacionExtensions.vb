Imports System.Runtime.CompilerServices

Namespace Extensiones
   Public Module FacturacionExtensions
      <Extension()>
      Public Sub SeteaColorGroupboxCliente(frm As IFacturacion,
                                           cmbCajas As Controles.ComboBox, cmbVendedor As Controles.ComboBox, cmbTiposComprobantes As Controles.ComboBox,
                                           grbCliente As GroupBox)
         'Dim facturacionOrdenDeColor As String = Reglas.Publicos.Facturacion.FacturacionOrdenDeColor

         Dim caja As Entidades.CajaNombre = Nothing
         If cmbCajas.SelectedIndex > -1 Then
            caja = New Reglas.CajasNombres().GetUna(actual.Sucursal.IdSucursal, cmbCajas.ValorSeleccionado(Of Integer))
         End If
         Dim vendedor = cmbVendedor.ItemSeleccionado(Of Entidades.Empleado)
         Dim tipoComprobante = cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante)

         Dim color As Color? = Nothing
         For Each ordenColor In {Reglas.Publicos.Facturacion.FacturacionOrdenDeColor1,
                                 Reglas.Publicos.Facturacion.FacturacionOrdenDeColor2,
                                 Reglas.Publicos.Facturacion.FacturacionOrdenDeColor3}
            If ordenColor = Entidades.Publicos.FacturacionOrdenesDeColor.VENDEDOR AndAlso
               vendedor IsNot Nothing AndAlso vendedor.Color.HasValue Then
               color = Drawing.Color.FromArgb(vendedor.Color.Value)
               Exit For
            End If
            If ordenColor = Entidades.Publicos.FacturacionOrdenesDeColor.CAJA AndAlso
               caja IsNot Nothing AndAlso caja.Color.HasValue Then
               color = Drawing.Color.FromArgb(caja.Color.Value)
               Exit For
            End If
            If ordenColor = Entidades.Publicos.FacturacionOrdenesDeColor.TIPOCOMPROBANTE AndAlso
               tipoComprobante IsNot Nothing AndAlso tipoComprobante.Color.HasValue Then
               color = Drawing.Color.FromArgb(tipoComprobante.Color.Value)
               Exit For
            End If
         Next

         If color.HasValue Then
            grbCliente.BackColor = color.Value
         Else
            grbCliente.BackColor = Nothing
         End If
      End Sub
   End Module
End Namespace
Public Interface IFacturacion

End Interface