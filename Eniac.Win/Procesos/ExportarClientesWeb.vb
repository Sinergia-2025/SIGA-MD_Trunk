Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ExportarClientesWeb

#Region "Campos"

   Private _publicos As Publicos
   Private _Clientes As List(Of Entidades.Cliente)
   Private _ClienteWeb As ClientesWeb

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      Try

         MyBase.OnLoad(e)

         Me._publicos = New Publicos()
         Me._Clientes = New List(Of Entidades.Cliente)


         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)

         Me._publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios)
         Me.cmbListaDePrecios.SelectedIndex = -1

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me.cmbFormaPago.SelectedIndex = -1

         Me.cmbActivo.Items.Insert(0, "TODOS")
         Me.cmbActivo.Items.Insert(1, "SI")
         Me.cmbActivo.Items.Insert(2, "NO")
         Me.cmbActivo.SelectedIndex = 0

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ActualizacionMasivaClientesVendedores_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbZonaGeografica.CheckedChanged

      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If

         Me.cmbZonaGeografica.Focus()

      End If

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing

      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub chbCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCategoria.CheckedChanged

      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub

   Private Sub chbListaDePrecios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbListaDePrecios.CheckedChanged

      Me.cmbListaDePrecios.Enabled = Me.chbListaDePrecios.Checked

      If Not Me.chbListaDePrecios.Checked Then
         Me.cmbListaDePrecios.SelectedIndex = -1
      Else
         If Me.cmbListaDePrecios.Items.Count > 0 Then
            Me.cmbListaDePrecios.SelectedIndex = 0
         End If

         Me.cmbListaDePrecios.Focus()

      End If

   End Sub

   Private Sub chbFormaPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFormaPago.CheckedChanged
      Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked
      If Not Me.chbFormaPago.Checked Then
         Me.cmbFormaPago.SelectedIndex = -1
      Else
         If Me.cmbFormaPago.Items.Count > 0 Then
            Me.cmbFormaPago.SelectedIndex = 0
         End If
         Me.cmbFormaPago.Focus()
      End If
   End Sub

   Private Sub chbDescuentoRecargo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDescuentoRecargo.CheckedChanged
      Me.txtDescuentoRecargoPorc.Enabled = Me.chbDescuentoRecargo.Checked
      If Not Me.chbDescuentoRecargo.Checked Then
         Me.txtDescuentoRecargoPorc.Text = "0.00"
      Else
         Me.txtDescuentoRecargoPorc.Focus()
      End If
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.chbTodos.Checked = False
         Me.tsbExportar.Enabled = True

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged

      Me.Cursor = Cursors.WaitCursor

      For Each dr As ultraGridRow In Me.ugDetalle.Rows
         dr.Cells("Check").Value = Me.chbTodos.Checked
      Next

      Me.Cursor = Cursors.Default

   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      Dim DialogoGuardarArchivo As New SaveFileDialog()

      DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoGuardarArchivo.Filter = "Archivos de Texto (*.csv)|*.csv|Todos los Archivos (*.*)|*.*"
      DialogoGuardarArchivo.FilterIndex = 1
      DialogoGuardarArchivo.RestoreDirectory = True

      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            If DialogoGuardarArchivo.FileName <> "" Then

               Me.txtArchivoDestino.Text = DialogoGuardarArchivo.FileName

            End If

         Catch Ex As Exception
            MessageBox.Show(Ex.Message)
         End Try
      End If
   End Sub

   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Me.Cursor = Cursors.WaitCursor

         Me.ExportarDatos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      Try
         Me.ugDetalle.PerformAction(UltraGridAction.ExitEditMode)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chbCliente.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbZonaGeografica.Checked = False
      Me.chbCategoria.Checked = False
      Me.chbListaDePrecios.Checked = False
      Me.cmbActivo.SelectedIndex = 0
      Me.chbFormaPago.Checked = False
      Me.chbDescuentoRecargo.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.chbTodos.Checked = False

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oRegClientes As Reglas.Clientes = New Reglas.Clientes()

         Dim Total1 As Decimal = 0
         Dim Total2 As Decimal = 0

         Dim IdVendedor As Integer = 0

         Dim idZonaGeografica As String = String.Empty

         Dim Desde As Date = Nothing
         Dim Hasta As Date = Nothing

         Dim IdCliente As Long = 0

         Dim idFormaPago As Integer = 0
         Dim descPorRecargo As Decimal? = Nothing

         Dim IdCategoria As Integer = 0

         Dim idListaDePrecios As Integer = -1

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbZonaGeografica.Enabled Then
            idZonaGeografica = Me.cmbZonaGeografica.SelectedValue.ToString()
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.cmbListaDePrecios.Enabled Then
            idListaDePrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
         End If

         If Me.cmbFormaPago.Enabled Then
            idFormaPago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
         End If

         If Me.txtDescuentoRecargoPorc.Enabled Then
            descPorRecargo = Decimal.Parse(Me.txtDescuentoRecargoPorc.Text)
         End If

         Dim dtDetalle As DataTable

         dtDetalle = oRegClientes.GetPorFiltrosVarios(IdVendedor,
                                                      IdCliente,
                                                      idZonaGeografica,
                                                      IdCategoria,
                                                      idListaDePrecios,
                                                      idFormaPago,
                                                      descPorRecargo,
                                                      cmbActivo.Text, "", 0, 0, "TODOS", Nothing,
                                                      String.Empty, tiposCliente:=Nothing, publicarEnWeb:="TODOS",
                                                      idCategoriaFiscal:=0)
         ugDetalle.DataSource = dtDetalle

         txtArchivoDestino.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & Publicos.CuitEmpresa & "_ClientesWeb_" & Date.Today().ToString("yyyyMMdd") & ".csv"

         tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ExportarDatos()

      Try
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()
         Dim cant As Integer = 0

         For Each dr As UltraGridRow In Me.ugDetalle.Rows
            If Boolean.Parse(dr.Cells("Check").Value.ToString()) Then
               cant += 1
            End If
         Next

         If cant = 0 Then
            MessageBox.Show("No selecciono ningún Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
         End If

         stb.AppendFormat("Realmente desea generar el archivo para los {0} Clientes?", cant)

         If MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.CrearClientesWeb()
            Me._ClienteWeb.GrabarArchivo(Me.txtArchivoDestino.Text)
            MessageBox.Show("Se Exportaron " & cant.ToString() & " Clientes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Else
            MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         Throw
      End Try

   End Sub

   Private Sub CrearClientesWeb()
      Try
         Me._ClienteWeb = New ClientesWeb()

         Dim linea As ClientesWebLinea

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = ugDetalle.Rows.Count
         Me.tspBarra.Value = 0

         For Each dr As UltraGridRow In ugDetalle.Rows
            Me.tspBarra.Value += 1
            If Boolean.Parse(dr.Cells("Check").Value.ToString()) Then

               linea = New ClientesWebLinea()

               ''01 - cuitempresa
               'linea.CuitEmpresa = Publicos.CuitEmpresa

               '02 - cuitcliente
               linea.Cuit = dr.Cells("CUIT").Value.ToString()
               '03 - codigo
               linea.CodigoCliente = Long.Parse(dr.Cells("CodigoCliente").Value.ToString())
               '05 - nombre
               linea.NombreCliente = dr.Cells("NombreCliente").Value.ToString()
               '06 - direccion
               linea.Direccion = dr.Cells("Direccion").Value.ToString()
               '07 - cp
               linea.Localidad.IdLocalidad = Integer.Parse(dr.Cells("IdLocalidad").Value.ToString())
               '08 - telefono
               linea.Telefono = dr.Cells("Telefono").Value.ToString()
               '09 - celular
               linea.Celular = dr.Cells("Celular").Value.ToString()
               '10 - email
               linea.CorreoElectronico = dr.Cells("CorreoElectronico").Value.ToString()
               '11 - categoria
               linea.NombreCategoria = dr.Cells("NombreCategoria").Value.ToString()
               '12 - categoriafiscal
               linea.CategoriaFiscal.NombreCategoriaFiscal = dr.Cells("NombreCategoriaFiscal").Value.ToString()
               '13 - vendedor
               linea.Vendedor.NombreEmpleado = dr.Cells("NombreVendedor").Value.ToString()
               '14 - listadeprecios
               linea.NombreListaPrecios = dr.Cells("NombreListaPrecios").Value.ToString()
               '15 - zona
               linea.ZonaGeografica.NombreZonaGeografica = dr.Cells("NombreZonaGeografica").Value.ToString()
               '16 - doc
               linea.TipoDocCliente = dr.Cells("TipoDocCliente").Value.ToString()
               '17 - numerodoc
               If Not String.IsNullOrEmpty(dr.Cells("NroDocCliente").Value.ToString()) Then
                  linea.NroDocCliente = Long.Parse(dr.Cells("NroDocCliente").Value.ToString())
               Else
                  linea.NroDocCliente = 0
               End If
               '18 - observacion
               If Not String.IsNullOrEmpty(dr.Cells("Observacion").Value.ToString()) Then
                  linea.Observacion = Replace(dr.Cells("Observacion").Value.ToString().Trim(), vbCrLf, "").ToString()
               Else
                  linea.Observacion = dr.Cells("Observacion").Value.ToString().Trim()
               End If

               linea.IdVendedor = Integer.Parse(dr.Cells("IdVendedor").Value.ToString())

               Me._ClienteWeb.Lineas.Add(linea)

            End If

         Next


      Catch ex As Exception
         Throw
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try

   End Sub

#End Region

End Class