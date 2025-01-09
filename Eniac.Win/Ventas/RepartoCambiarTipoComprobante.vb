Option Explicit On
Option Strict Off

Public Class RepartoCambiarTipoComprobante

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Propiedades"

   Private _idTipoComprobante As String
   Public Property IdTipoComprobante() As String
      Get
         Return _idTipoComprobante
      End Get
      Set(ByVal value As String)
         _idTipoComprobante = value
      End Set
   End Property
 
   Private _nombreCliente As String
   Public Property NombreCliente() As String
      Get
         Return _nombreCliente
      End Get
      Set(ByVal value As String)
         _nombreCliente = value
      End Set
   End Property
   Private _direccion As String
   Public Property Direccion() As String
      Get
         Return _direccion
      End Get
      Set(ByVal value As String)
         _direccion = value
      End Set
   End Property

   Private _descripcionComprobante As String
   Public Property DescripcionComprobante() As String
      Get
         Return _descripcionComprobante
      End Get
      Set(ByVal value As String)
         _descripcionComprobante = value
      End Set
   End Property

   Private _idCategoria As Int32
   Public Property IdCategoria() As Int32
      Get
         Return _idCategoria
      End Get
      Set(ByVal value As Int32)
         _idCategoria = value
      End Set
   End Property

   Private _nombreCategoria As String
   Public Property NombreCategoria() As String
      Get
         Return _nombreCategoria
      End Get
      Set(ByVal value As String)
         _nombreCategoria = value
      End Set
   End Property

   Public Property ModificaTipoComprobante() As Boolean
   Public Property CambioMasivoReparto() As RegistrarReparto.ModoCambioMasivoReparto

   Public Property ModificaCategoria() As Boolean
   Public Property CambioMasivoRepartoCat() As RegistrarReparto.ModoCambioMasivoReparto


#End Region

#Region "Overrides"



   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos = New Publicos()

         Me.txtTipoComprobanteActual.Text = Me._descripcionComprobante
         Me.txtCategoriaActual.Text = Me._nombreCategoria


         'Me._publicos.CargaComboTiposComprobantes(Me.cmbtComprNuevo, False, "VENTAS")
         Me._publicos.CargaComboTiposComprobantes(Me.cmbtComprNuevo, True, "VENTAS", , , , True)
         Me._publicos.CargaComboCategorias(Me.cmbCategoriaNueva)
         Me.cmbtComprNuevo.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbCambioMasivo, GetType(RegistrarReparto.ModoCambioMasivoReparto))
         _publicos.CargaComboDesdeEnum(cmbCambioMasivoCategoria, GetType(RegistrarReparto.ModoCambioMasivoReparto))

         Me.txtCliente.Text = NombreCliente

         Me.txtDireccion.Text = Direccion

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub Cerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         If Me.chbCambiarTipoComprobante.Checked And Me.cmbtComprNuevo.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione Tipo de Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
         End If

         If Me.chbCambiarCategoria.Checked And Me.cmbCategoriaNueva.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione Categoría.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
         End If

         Me.ModificarTComp()

         DialogResult = Windows.Forms.DialogResult.OK

         Me.Close()


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos"

   Public Sub ModificarTComp()


      If Me.chbCambiarTipoComprobante.Checked Then

         Me.IdTipoComprobante = Me.cmbtComprNuevo.SelectedValue.ToString()
         Me.DescripcionComprobante = Me.cmbtComprNuevo.Text
         Me.CambioMasivoReparto = DirectCast(cmbCambioMasivo.SelectedValue, RegistrarReparto.ModoCambioMasivoReparto)

      End If

      Me.ModificaTipoComprobante = Me.chbCambiarTipoComprobante.Checked


      If Me.chbCambiarCategoria.Checked Then

         Me.IdCategoria = Me.cmbCategoriaNueva.SelectedValue
         Me.NombreCategoria = Me.cmbCategoriaNueva.Text
         Me.CambioMasivoRepartoCat = DirectCast(cmbCambioMasivoCategoria.SelectedValue, RegistrarReparto.ModoCambioMasivoReparto)

      End If

      Me.ModificaCategoria = Me.chbCambiarCategoria.Checked

   End Sub

#End Region

   Private Sub chbCambiarTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbCambiarTipoComprobante.CheckedChanged
      Me.cmbtComprNuevo.Enabled = Me.chbCambiarTipoComprobante.Checked
      If Not Me.chbCambiarTipoComprobante.Checked Then
         Me.cmbtComprNuevo.SelectedIndex = -1
      End If
   End Sub

   Private Sub chbCambiarCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCambiarCategoria.CheckedChanged
      Me.cmbCategoriaNueva.Enabled = Me.chbCambiarCategoria.Checked
      If Not Me.chbCambiarCategoria.Checked Then
         Me.cmbCategoriaNueva.SelectedIndex = -1
      End If
   End Sub
End Class