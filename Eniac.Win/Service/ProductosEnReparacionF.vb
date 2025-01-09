Option Explicit On
Option Strict On

Imports System
Imports Eniac.Service.Reglas
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ProductosEnReparacionF

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me.CargaComboEstados()

         Me._publicos = New Eniac.Win.Publicos()

         Me.CargarValoresIniciales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ProductosEnReparacionF_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.tslRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbCambiarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCambiarEstado.Click
      Try
         If Me.dgvDetalle.SelectedRows.Count > 0 Then
            Dim nota As Eniac.Entidades.RecepcionNotaEstadoF = New Eniac.Entidades.RecepcionNotaEstadoF()
            Dim regE As Eniac.Reglas.RecepcionEstadosF = New Eniac.Reglas.RecepcionEstadosF()

            With nota
               .IdSucursal = actual.Sucursal.Id
               .Nota = New Eniac.Reglas.RecepcionNotasF().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.dgvDetalle.SelectedRows(0).Cells("NroNota").Value.ToString()))
               .FechaEstado = Now
               .Estado = regE.GetUno(Integer.Parse(Me.dgvDetalle.SelectedRows(0).Cells("IdEstado").Value.ToString()))
               .Usuario = actual.Nombre
            End With

            Dim frm As CambiarEstadoProductosF = New CambiarEstadoProductosF(nota)
            frm.ShowDialog()

            Me.btnConsultar.PerformClick()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbEnviarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEnviarProducto.Click
      Try
         If Me.dgvDetalle.SelectedRows.Count > 0 Then
            Dim nota As Eniac.Entidades.RecepcionNotaProveedorF = New Eniac.Entidades.RecepcionNotaProveedorF()
            Dim prov As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores()

            With nota
               .IdSucursal = actual.Sucursal.Id
               .Nota = New Eniac.Reglas.RecepcionNotasF().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.dgvDetalle.SelectedRows(0).Cells("NroNota").Value.ToString()))
               .FechaEntrega = Now
               .Usuario = actual.Nombre
            End With

            Dim frm As EnviarProductoF = New EnviarProductoF(nota)
            frm.ShowDialog()

            Me.btnConsultar.PerformClick()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPrestarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrestarProducto.Click
      Try
         If Me.dgvDetalle.SelectedRows.Count > 0 Then
            If Me.dgvDetalle.SelectedRows(0).Cells("IdProductoPrestado").Value.ToString() <> "" Then
               If MessageBox.Show("Usted ya presto un producto para esta nota, desea cambiarlo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
                  Exit Sub
               End If
            End If

            Dim nota As Eniac.Entidades.RecepcionNotaF = New Eniac.Entidades.RecepcionNotaF()
            Dim regE As Eniac.Reglas.RecepcionEstadosF = New Eniac.Reglas.RecepcionEstadosF()

            nota = New Eniac.Reglas.RecepcionNotasF().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.dgvDetalle.SelectedRows(0).Cells("NroNota").Value.ToString()))
            nota.Modo = Entidades.Modos.PrestarProducto
            nota.Usuario = actual.Nombre

            Dim frm As PrestarProductoF = New PrestarProductoF(nota)
            frm.ShowDialog()

            Me.btnConsultar.PerformClick()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbDevolucionProductoPrestado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDevolucionProductoPrestado.Click
      Try
         If Me.dgvDetalle.SelectedRows.Count > 0 Then
            Dim nota As Eniac.Entidades.RecepcionNotaF = New Eniac.Entidades.RecepcionNotaF()
            Dim regE As Eniac.Reglas.RecepcionEstadosF = New Eniac.Reglas.RecepcionEstadosF()

            nota = New Eniac.Reglas.RecepcionNotasF().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.dgvDetalle.SelectedRows(0).Cells("NroNota").Value.ToString()))
            nota.Modo = Entidades.Modos.DevolverProducto
            nota.Usuario = actual.Nombre

            Dim frm As PrestarProductoF = New PrestarProductoF(nota)
            frm.Text = "Devolución de producto prestado"
            frm.ShowDialog()

            Me.btnConsultar.PerformClick()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimirHistorialNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirHistorialNota.Click

      If Me.dgvDetalle.SelectedRows.Count = 0 Then Exit Sub

      Try
         Dim nota As Eniac.Entidades.RecepcionNotaF = New Eniac.Entidades.RecepcionNotaF()

         nota = New Eniac.Reglas.RecepcionNotasF().GetUno(actual.Sucursal.IdSucursal, Integer.Parse(Me.dgvDetalle.SelectedRows(0).Cells("NroNota").Value.ToString()))

         Dim dt As DataTable

         dt = New Eniac.Reglas.RecepcionNotasEstadosF().GetUna(actual.Sucursal.IdSucursal, nota.NroNota)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", nota.Cliente.NombreCliente))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDocumento", nota.Cliente.CodigoCliente.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", nota.Cliente.Direccion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", nota.Cliente.IdLocalidad.ToString())) 'Poner Nombre
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", nota.Cliente.Telefono & " " & nota.Cliente.Celular))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Email", nota.Cliente.CorreoElectronico))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroNota", nota.NroNota.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", nota.FechaNota.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CodigoProducto", nota.Producto.IdProducto))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreProducto", nota.Producto.NombreProducto))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cantidad", nota.CantidadProductos.ToString()))
         'If nota.Venta.TipoComprobante IsNot Nothing Then
         '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Comprobante", nota.Venta.Fecha.ToString("dd/MM/yyyy") & " - " & nota.Venta.TipoComprobanteDescripcion & " '" & nota.Venta.LetraComprobante & "' " & nota.Venta.CentroEmisor.ToString("0000") & "-" & nota.Venta.NumeroComprobante.ToString("00000000")))
         'Else
         '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Comprobante", "SIN FACTURA RELACIONADA"))
         'End If
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Comprobante", nota.Ficha.FechaOperacion.ToString("dd/MM/yyyy") & " - " & nota.Ficha.NroOperacion.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Costo", nota.CostoReparacion.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Defecto", nota.DefectoProducto))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Observacion", nota.Observacion))

         Dim frmImprime As VisorReportes
         frmImprime = New VisorReportes("Eniac.Win.NotaRecepcionHistorialF.rdlc", "SistemaDataSet_RecepcionNotasHistorial", dt, parm, 1) '# 1 = Cantidad de Copias
         frmImprime.Text = "Historial Nota Recepción"
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub cmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstado.SelectedIndexChanged
      Try
         If Me.dgvDetalle.DataSource IsNot Nothing Then
            DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
         End If
         Me.tsbEnviarProducto.Enabled = Me.HabilitaEnviarProducto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked

      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = ""
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
      End If

   End Sub

   Private Sub bscNroDoc_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Dim codigoCliente As Long = -1
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Dim idEstado As Integer = 0
         Dim fec1 As DateTime = Nothing
         Dim fec2 As DateTime = Nothing
         Dim IdCliente As Long = 0

         Dim prodRec As Eniac.Reglas.ProductosRecepcionF = New Eniac.Reglas.ProductosRecepcionF()

         idEstado = Integer.Parse(Me.cmbEstado.SelectedValue.ToString())

         If Me.dtpFechaEnvioDesde.Checked Then
            fec1 = Me.dtpFechaEnvioDesde.Value
         End If
         If Me.dtpFechaEnvioHasta.Checked Then
            fec2 = Me.dtpFechaEnvioHasta.Value
         End If

         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         Me.dgvDetalle.DataSource = prodRec.GetProductosEnReparacion(actual.Sucursal.Id, idEstado, fec1, fec2, IdCliente)

         Me.tslRegistros.Text = Me.dgvDetalle.RowCount.ToString() + " Registros"

         Me.dgvDetalle.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvDetalle_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetalle.SelectionChanged
      Try
         If Me.dgvDetalle.SelectedRows.Count > 0 Then
            'habilita o deshabilita el prestar y devolver si tiene o no un producto prestado

            'Al preguntar por el Estado no necesito borrar el producto que se presto. Reveer esta funcionalidad en base a comentarios.
            'If Me.dgvDetalle.SelectedRows(0).Cells("IdProductoPrestado").Value.ToString() <> "" Then
            If Me.dgvDetalle.SelectedRows(0).Cells("EstaPrestado").Value.ToString() <> "" AndAlso Boolean.Parse(Me.dgvDetalle.SelectedRows(0).Cells("EstaPrestado").Value.ToString()) Then
               Me.tsbPrestarProducto.Enabled = False
               Me.tsbDevolucionProductoPrestado.Enabled = True
            Else
               Me.tsbPrestarProducto.Enabled = True
               Me.tsbDevolucionProductoPrestado.Enabled = False
            End If
            'solo habilita el enviar producto si el estado es "Devuelto"
            If Me.dgvDetalle.SelectedRows(0).Cells("IdEstado").Value.ToString() <> "10" Then
               Me.tsbEnviarProducto.Enabled = False
            Else
               Me.tsbEnviarProducto.Enabled = True
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaComboEstados()
      Dim oEstado As Eniac.Reglas.RecepcionEstadosF = New Eniac.Reglas.RecepcionEstadosF()

      With Me.cmbEstado
         .DisplayMember = "NombreEstado"
         .ValueMember = "IdEstado"
         .DataSource = oEstado.GetTodos()
      End With
   End Sub

   Private Sub CargarValoresIniciales()

      Me.cmbEstado.SelectedValue = 10

      Me.dtpFechaEnvioDesde.Value = Date.Now
      Me.dtpFechaEnvioDesde.Checked = False

      Me.dtpFechaEnvioHasta.Value = Date.Now
      Me.dtpFechaEnvioHasta.Checked = False

      Me.chbCliente.Checked = False

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

      Me.btnConsultar.Focus()
   End Sub

   Private Function HabilitaEnviarProducto() As Boolean
      'valida que en el combo de estado diga Devuelto, para habilitar el boton
      If Int32.Parse(Me.cmbEstado.SelectedValue.ToString()) <> 10 Then
         Return False
      End If
      Return True
   End Function

#End Region

End Class