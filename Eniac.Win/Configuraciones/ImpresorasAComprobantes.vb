Option Strict Off
Imports System.Drawing.Printing
Imports System.Text
Imports System.IO

Public Class ImpresorasAComprobantes

   Private printDoc As System.Drawing.Printing.PrintDocument = New System.Drawing.Printing.PrintDocument()

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.CargarImpresorasInstaladas()
      'Me.CargarComprobantes()

      Dim pub As Publicos = New Publicos()
      'pub.CargaComboTiposComprobantes(Me.cmbComprobante, False, "VENTAS", "CTACTECLIE")
      pub.CargaComboTiposComprobantes(Me.cmbComprobante, False, "TODOS", "")

      Me.txtServidor.Text = My.Computer.Name

      Me.RefrescarGrilla()

   End Sub

   Private Sub CargarComprobantes()
      Dim pub As Publicos = New Publicos()
      'pub.CargaComboTiposComprobantes(Me.cmbComprobante, "VENTAS")
      pub.CargaComboTiposComprobantes(Me.cmbComprobante, "VENTAS", "CTACTECLIE")
   End Sub

   Private Sub CargarImpresorasInstaladas()
      Dim i As Integer
      Dim pkInstalledPrinters As String

      Dim instance As PrinterSettings = New PrinterSettings()

      For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
         pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)

         Me.cmbImpresora.Items.Add(pkInstalledPrinters)
      Next

      'agrego una impresora vacia
      Me.cmbImpresora.Items.Add("")

   End Sub

   Private Sub comboInstalledPrinters_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Set the printer to a printer in the combo box when the selection changes.
      If Me.cmbImpresora.SelectedIndex <> -1 Then
         ' The combo box's Text property returns the selected item's text, which is the printer name.
         printDoc.PrinterSettings.PrinterName = Me.cmbImpresora.SelectedText
      End If
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub RefrescarGrilla()
      Dim reg As Reglas.TiposComprobantesLetras = New Reglas.TiposComprobantesLetras()
      Me.dgvImpComp.DataSource = reg.GetTodos()
   End Sub

   Private Function GetEntidadControles() As Entidades.TipoComprobanteLetra
      Dim tcl As Entidades.TipoComprobanteLetra = New Entidades.TipoComprobanteLetra()
      If Me.txtServidor.Text.Trim.Length > 0 And Me.cmbImpresora.Text <> "" Then
         tcl.NombreImpresora = "\\" & Me.txtServidor.Text & "\" & Me.cmbImpresora.Text
      Else
         tcl.NombreImpresora = Me.cmbImpresora.Text
      End If
      tcl.Letra = Me.txtLetra.Text
      tcl.ArchivoAImprimir = Me.txtArchivoAImprimir.Text
      tcl.ArchivoAImprimirEmbebido = Me.chbArchivoEmbebido.Checked
      tcl.TipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.cmbComprobante.SelectedValue.ToString())
      tcl.CantidadItemsProductos = Me.txtCantItemsProductos.Text
      tcl.CantidadItemsObservaciones = Me.txtCantItemsObservaciones.Text
      tcl.CantidadCopias = Integer.Parse(Me.txtCantidadCopias.Text.ToString())
      tcl.Imprime = Me.chbImprime.Checked
      tcl.ArchivoAImprimir2 = txtArchivoAImprimir2.Text
      tcl.ArchivoAImprimirEmbebido2 = chbArchivoEmbebido2.Checked
      tcl.ArchivoAImprimirComplementario = txtArchivoAImprimirComplementario.Text
      tcl.ArchivoAImprimirComplementarioEmbebido = chbArchivoAImprimirComplementarioEmbebido.Checked
      Return tcl
   End Function

   Private Function GetEntidadGrilla(ByVal dr As DataGridViewRow) As Entidades.TipoComprobanteLetra
      Dim tcl As Entidades.TipoComprobanteLetra = New Entidades.TipoComprobanteLetra()

      If Not String.IsNullOrEmpty(dr.Cells("NombreImpresora").Value.ToString()) Then
         tcl.NombreImpresora = dr.Cells("NombreImpresora").Value.ToString()
      End If
      tcl.Letra = dr.Cells("Letra").Value.ToString()
      tcl.ArchivoAImprimir = dr.Cells("ArchivoAImprimir").Value.ToString()
      tcl.ArchivoAImprimirEmbebido = Boolean.Parse(dr.Cells("ArchivoAImprimirEmbebido").Value.ToString())
      tcl.TipoComprobante = DirectCast(dr.Cells("TipoComprobante").Value, Entidades.TipoComprobante)
      tcl.CantidadItemsProductos = Integer.Parse(dr.Cells("CantidadItemsProductos").Value.ToString())
      tcl.CantidadItemsObservaciones = Integer.Parse(dr.Cells("CantidadItemsObservaciones").Value.ToString())
      tcl.Imprime = Boolean.Parse(dr.Cells("Imprime").Value.ToString())
      tcl.ArchivoAImprimir2 = dr.Cells(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimir2.ToString()).Value.ToString()
      tcl.ArchivoAImprimirEmbebido2 = Boolean.Parse(dr.Cells(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirEmbebido2.ToString()).Value.ToString())
      tcl.ArchivoAImprimirComplementario = dr.Cells(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirComplementario.ToString()).Value.ToString()
      tcl.ArchivoAImprimirComplementarioEmbebido = Boolean.Parse(dr.Cells(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirComplementarioEmbebido.ToString()).Value.ToString())
      Return tcl
   End Function

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click

      Try

         If Me.cmbComprobante.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe selecionar el Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbComprobante.Focus()
            Exit Sub
         End If

         If Me.txtLetra.Text.Trim.Length = 0 Then
            MessageBox.Show("ATENCION: Debe ingresar la Letra del Comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtLetra.Focus()
            Exit Sub
         End If

         If Me.txtArchivoAImprimir.Text.Trim.Length = 0 Then
            MessageBox.Show("ATENCION: Debe ingresar el Archivo a Imprimir.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtArchivoAImprimir.Focus()
            Exit Sub
         End If

         'If Me.txtServidor.Text.Trim.Length = 0 Then
         '   MessageBox.Show("ATENCION: Debe ingresar el Servidor/PC donde la Impresora se encuentra conectada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.txtServidor.Focus()
         '   Exit Sub
         'End If

         If Me.cmbImpresora.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Debe selecionar la Impresora.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbImpresora.Focus()
            Exit Sub
         End If

         If txtCantItemsProductos.Text = "" Then
            MessageBox.Show("ATENCION: Debe indicar la Cantidad de Items Permitos para Productos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCantItemsProductos.Focus()
            Exit Sub
         End If

         If txtCantItemsObservaciones.Text = "" Then
            MessageBox.Show("ATENCION: Debe indicar la Cantidad de Items Permitos para Observaciones.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCantItemsObservaciones.Focus()
            Exit Sub
         End If

         Dim tcl As Reglas.TiposComprobantesLetras = New Reglas.TiposComprobantesLetras()
         tcl.Insertar(Me.GetEntidadControles())

         Me.RefrescarGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvImpComp.SelectedCells.Count > 0 Then
            If MessageBox.Show("Realmente desea eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaConfiguracion()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvImpComp_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvImpComp.CellDoubleClick
      Try

         'limpia los textbox, y demas controles
         Me.LimpiarCampos()

         'carga la configuracion seleccionada de la grilla en los textbox 
         Me.CargarConfiguracionCompleta(Me.dgvImpComp.Rows(e.RowIndex))

         'elimina la configuracion de la grilla
         Me.EliminarLineaConfiguracion()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub LimpiarCampos()
      Me.cmbComprobante.SelectedIndex = -1
      Me.txtLetra.Text = ""
      Me.txtArchivoAImprimir.Text = ""
      Me.chbArchivoEmbebido.Checked = False
      Me.txtServidor.Text = ""
      Me.cmbImpresora.SelectedIndex = -1
      Me.txtCantItemsProductos.Text = ""
      Me.txtCantItemsObservaciones.Text = ""
      Me.txtCantidadCopias.Text = ""
      Me.chbImprime.Checked = True
      txtArchivoAImprimir2.Text = ""
      chbArchivoEmbebido2.Checked = False
      txtArchivoAImprimirComplementario.Text = ""
      chbArchivoAImprimirComplementarioEmbebido.Checked = False
   End Sub

   Private Sub CargarConfiguracionCompleta(ByVal dr As DataGridViewRow)

      Me.cmbComprobante.SelectedValue = DirectCast(dr.Cells("TipoComprobante").Value, Entidades.TipoComprobante).IdTipoComprobante
      Me.txtLetra.Text = dr.Cells("Letra").Value
      Me.txtArchivoAImprimir.Text = dr.Cells("ArchivoAImprimir").Value
      Me.chbArchivoEmbebido.Checked = dr.Cells("ArchivoAImprimirEmbebido").Value

      txtArchivoAImprimir2.Text = dr.Cells(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimir2.ToString()).Value
      chbArchivoEmbebido2.Checked = dr.Cells(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirEmbebido2.ToString()).Value

      txtArchivoAImprimirComplementario.Text = dr.Cells(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirComplementario.ToString()).Value
      chbArchivoAImprimirComplementarioEmbebido.Checked = dr.Cells(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirComplementarioEmbebido.ToString()).Value

      'Coloco la impresora o lo envio al ultimo lugar.
      If Not String.IsNullOrEmpty(dr.Cells("NombreImpresora").Value.ToString()) Then
         If dr.Cells("NombreImpresora").Value.ToString.Contains("\\") Then
            Dim Partes As String() = dr.Cells("NombreImpresora").Value.ToString.Split("\\")
            Me.txtServidor.Text = Partes(2)
            Me.cmbImpresora.SelectedItem = Partes(3)
         Else
            Me.cmbImpresora.SelectedItem = dr.Cells("NombreImpresora").Value
         End If
      Else
         Me.cmbImpresora.SelectedIndex = Me.cmbImpresora.Items.Count - 1
      End If
      Me.txtCantidadCopias.Text = dr.Cells("CantidadCopias").Value
      Me.txtCantItemsProductos.Text = dr.Cells("CantidadItemsProductos").Value
      Me.txtCantItemsObservaciones.Text = dr.Cells("CantidadItemsObservaciones").Value

      Me.chbImprime.Checked = dr.Cells("Imprime").Value

   End Sub

   Private Sub EliminarLineaConfiguracion()

      Dim tcl As Reglas.TiposComprobantesLetras = New Reglas.TiposComprobantesLetras()
      tcl.Borrar(Me.GetEntidadGrilla(Me.dgvImpComp.Rows(Me.dgvImpComp.SelectedCells(0).RowIndex)))
      Me.RefrescarGrilla()

   End Sub

End Class