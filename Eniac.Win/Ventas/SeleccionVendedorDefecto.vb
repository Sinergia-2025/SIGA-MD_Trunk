Option Explicit On
Option Strict On
Public Class SeleccionVendedorDefecto
   Private _publicos As Publicos

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Dim blnCajasModificables As Boolean = True
      Dim blnMiraUsuario As Boolean = True
      Dim blnMiraPC As Boolean = Not Publicos.FacturacionIgnorarPCdeCaja

      Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
      Me._publicos.CargaComboCajas(Me.cmbCajas, Entidades.Usuario.Actual.Sucursal.Id, blnMiraUsuario, blnMiraPC, blnCajasModificables)

      cmbVendedor.Enabled = Reglas.Publicos.Facturacion.FacturacionSolicitaVendedorAlAbrir
      cmbCajas.Enabled = Reglas.Publicos.Facturacion.FacturacionSolicitaCajaAlAbrir

   End Sub

   Public ReadOnly Property Vendedor() As Entidades.Empleado
      Get
         If cmbVendedor.Enabled Then
            Return DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado)
         Else
            Return Nothing
         End If
      End Get
   End Property

   Public ReadOnly Property IdCaja As Integer?
      Get
         If cmbCajas.Enabled AndAlso IsNumeric(cmbCajas.SelectedValue) Then
            Return Integer.Parse(cmbCajas.SelectedValue.ToString())
         Else
            Return Nothing
         End If
      End Get
   End Property

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         If Reglas.Publicos.Facturacion.FacturacionSolicitaVendedorAlAbrir Then
            If cmbVendedor.SelectedIndex < 0 Then
               ShowMessage("Debe seleccionar un vendedor.")
               Exit Sub
            End If
         End If
         If Reglas.Publicos.Facturacion.FacturacionSolicitaCajaAlAbrir Then
            If cmbCajas.SelectedIndex < 0 Then
               ShowMessage("Debe seleccionar una caja.")
               Exit Sub
            End If
         End If
         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class