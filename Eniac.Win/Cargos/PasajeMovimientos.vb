Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class PasajeMovimientos

#Region "Campos"

   Private _publicos As Publicos
   'Private _publicosEniac As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "COMPRAS")
         Me._publicos.CargaComboRubrosConceptos(Me.cmbRubro)
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Me._publicos.CargaComboDesdeEnum(Me.cmbExcluirEnPasaje, GetType(Entidades.Publicos.SiNoTodos))
         Me.cmbExcluirEnPasaje.SelectedValue = Entidades.Publicos.SiNoTodos.NO

         '# Fecha desde inicial -> 1 año para atras
         Me.dtpDesde.Value = Me.FechaDesdePorDefecto()

         'Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub PasajeMovimientos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbPasaje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPasaje.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         If Me.chbTipoComprobante.Checked Or Me.chbRubro.Checked Then
            ShowMessage("No puede hacer el Pasaje de Movimientos con filtros activos")
         Else
            Me.PasajeMovimientos()
         End If
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         Me.Cursor = Cursors.Default
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Me.tsbPasaje.Enabled = True

         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro")
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged

      Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

      If Not Me.chbTipoComprobante.Checked Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
      Else
         If Me.cmbTiposComprobantes.Items.Count > 0 Then
            Me.cmbTiposComprobantes.SelectedIndex = 0
         End If
      End If

      Me.cmbTiposComprobantes.Focus()

   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged
      Me.cmbRubro.Enabled = Me.chbRubro.Checked

      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         If Me.cmbRubro.Items.Count > 0 Then
            Me.cmbRubro.SelectedIndex = 0
         End If
      End If

      Me.cmbRubro.Focus()
   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      If Not Me.chbProveedor.Checked Then
         Me.bscCodigoProveedor.Text = ""
         Me.bscCodigoProveedor.Tag = Nothing
         Me.bscProveedor.Text = ""
      Else
         Me.bscCodigoProveedor.Focus()
      End If

   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedores As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Dim oProveedores As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
      Me.Cursor = Cursors.WaitCursor

      ChequearTodos()
      
      Me.Cursor = Cursors.Default
   End Sub

   Private Sub dgvDetalle_CellClic(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick

      If e.ColumnIndex = 20 And e.RowIndex <> -1 Then
         Try
            If Me.dgvDetalle.Rows(e.RowIndex).Cells("Pasaje").Value Is Nothing Then
               ShowMessage("Para modificar el Monto a Aplicar debe seleccionar el Movimiento")
               Exit Sub
            End If
            If Not Boolean.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("Pasaje").Value.ToString()) Then
               ShowMessage("Para modificar el Monto a Aplicar debe seleccionar el Movimiento")
               Exit Sub
            End If
         Catch ex As Exception
            ShowError(ex)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If
   End Sub

   Private Sub dgvDetalle_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellLeave, dgvDetalle.CellEndEdit, dgvDetalle.CellClick

      If e.RowIndex <> -1 AndAlso Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).OwningColumn.Name = "MontoAplicar" Then

         Try

            'NO lo CAPTURA !!! la "#"#$%"#$5
            'If Me.dgvDetalle.Rows(e.RowIndex).Cells("MontoAplicar").Value Is Nothing Then
            '   Me.dgvDetalle.Rows(e.RowIndex).Cells("MontoAplicar").Value = 0
            'End If

            'If String.IsNullOrEmpty(Me.dgvDetalle.Rows(e.RowIndex).Cells("MontoAplicar").Value.ToString()) Then
            '   Me.dgvDetalle.Rows(e.RowIndex).Cells("MontoAplicar").Value = 0
            'End If

            Dim montoSaldo As Decimal = Decimal.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("MontoSaldo").Value.ToString())
            Dim montoAplicar As Decimal = Decimal.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString())

            If Math.Abs(montoSaldo) < Math.Abs(montoAplicar) Then
               ShowMessage("No puede aplicar un monto mayor al Monto Saldo")
               Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Me.dgvDetalle.Rows(e.RowIndex).Cells("MontoSaldo").Value.ToString()
            End If

            Me.CalcularTotales()


         Catch ex As Exception
            ShowError(ex)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If
   End Sub

   Private Sub dgvDetalle_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellValueChanged
      Me.CalcularTotales()
   End Sub

   Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
      If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
         Me.dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Display)
      End If

      If Reglas.Publicos.CargosPasajeMovimientoTomaComprobanteCompleto And e.RowIndex <> -1 And e.ColumnIndex = Pasaje.Index Then
         Try
            Me.Cursor = Cursors.WaitCursor
            Me.dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Display)

            Dim currentRow As DataGridViewRow = dgvDetalle.Rows(e.RowIndex)

            For Each dr As DataGridViewRow In dgvDetalle.Rows

               If Not dr.Equals(currentRow) AndAlso
                  dr.Cells("IdProveedor").Value.Equals(currentRow.Cells("IdProveedor").Value) AndAlso
                  dr.Cells("IdTipoComprobante").Value.Equals(currentRow.Cells("IdTipoComprobante").Value) AndAlso
                  dr.Cells("Letra").Value.Equals(currentRow.Cells("Letra").Value) AndAlso
                  dr.Cells("CentroEmisor").Value.Equals(currentRow.Cells("CentroEmisor").Value) AndAlso
                  dr.Cells("NroComprobante").Value.Equals(currentRow.Cells("NroComprobante").Value) Then
                  dr.Cells("Pasaje").Value = CBool(currentRow.Cells("Pasaje").Value)
               End If

               'If dr.DataBoundItem IsNot Nothing AndAlso
               '   TypeOf (dr.DataBoundItem) Is DataRowView AndAlso
               '   DirectCast(dr.DataBoundItem, DataRowView).Row IsNot Nothing Then
               'End If
            Next

         Catch ex As Exception
            ShowError(ex)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If


   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
      'Me._mailProveedor = dr.Cells("CorreoElectronico").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.dtpHasta.Value = Date.Now
      Me.chbProveedor.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.chbRubro.Checked = False
      Me.chbTodos.Checked = False
      Me.txtImporteTotalSaldo.Text = "0.00"
      Me.txtMontoAplicar.Text = "0.00"
      Me.tssRegistros.Text = ""

      Me.cmbExcluirEnPasaje.SelectedValue = Entidades.Publicos.SiNoTodos.NO

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oMovimiento As Reglas.Compras = New Reglas.Compras()

      Dim IdProveedor As Long = 0

      Dim IdTipoComprobante As String = String.Empty

      Dim IdRubroConcepto As Integer = 0

      Dim Desde As Date? = Nothing
      Dim Hasta As Date = Nothing

      Try

         If Me.chbFechaDesde.Checked Then
            Desde = Me.dtpDesde.Value
         End If
         Hasta = Me.dtpHasta.Value

         If Me.chbProveedor.Checked Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.cmbRubro.Enabled Then
            IdRubroConcepto = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If

         Dim excluirEnPasaje As Entidades.Publicos.SiNoTodos = DirectCast(Me.cmbExcluirEnPasaje.SelectedValue, Entidades.Publicos.SiNoTodos)

         'actual.Sucursal.Id
         Me.dgvDetalle.DataSource = oMovimiento.GetMovimientosConceptos(actual.Sucursal.IdSucursal,
                                                                        Desde, Hasta,
                                                                        IdProveedor,
                                                                        "TODOS",
                                                                        "TODOS",
                                                                        IdTipoComprobante,
                                                                        IdRubroConcepto,
                                                                        excluirEnPasaje)
         Me.OrdenarColumnas()

         Me.CalcularTotales()

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

         If Me.chbTodos.Checked Then
            ChequearTodos()
         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CalcularTotales()

      Dim ImporteTotalSaldo As Decimal = 0
      Dim MontoAplicar As Decimal = 0

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If dr.Cells("Pasaje").Value IsNot Nothing Then
            If Boolean.Parse(dr.Cells("Pasaje").Value.ToString()) Then
               ImporteTotalSaldo = ImporteTotalSaldo + Decimal.Parse(dr.Cells("MontoSaldo").Value.ToString())
               MontoAplicar = MontoAplicar + Decimal.Parse(dr.Cells("MontoAplicar").Value.ToString())
            End If
         End If
      Next

      txtImporteTotalSaldo.Text = ImporteTotalSaldo.ToString("#,##0.00")
      txtMontoAplicar.Text = MontoAplicar.ToString("#,##0.00")

   End Sub

   Private Sub OrdenarColumnas()
      Me.dgvDetalle.Columns("Pasaje").DisplayIndex = 1
      Me.dgvDetalle.Columns("NombreTipoComprobante").DisplayIndex = 2
      Me.dgvDetalle.Columns("Letra").DisplayIndex = 3
      Me.dgvDetalle.Columns("CentroEmisor").DisplayIndex = 4
      Me.dgvDetalle.Columns("NroComprobante").DisplayIndex = 5
      Me.dgvDetalle.Columns("Fecha").DisplayIndex = 6
      Me.dgvDetalle.Columns("NombreProveedor").DisplayIndex = 7
      Me.dgvDetalle.Columns("Concepto").DisplayIndex = 8
      Me.dgvDetalle.Columns("Precio").DisplayIndex = 9
      Me.dgvDetalle.Columns("DescuentoRecargo").DisplayIndex = 10
      Me.dgvDetalle.Columns("ImporteTotal").DisplayIndex = 11
      Me.dgvDetalle.Columns("PorcentajeIVA").DisplayIndex = 12
      Me.dgvDetalle.Columns("IVA").DisplayIndex = 13
      Me.dgvDetalle.Columns("Importe").DisplayIndex = 14
      Me.dgvDetalle.Columns("MontoSaldo").DisplayIndex = 15
      Me.dgvDetalle.Columns("MontoAplicar").DisplayIndex = 16

   End Sub

   Private Sub PasajeMovimientos()

      Dim oMovimientosLiquidacion As Reglas.ComprasLiquidacion = New Reglas.ComprasLiquidacion()
      Dim oMovimientosConceptos As Reglas.ComprasProductos = New Reglas.ComprasProductos()

      Dim oMovCon As Eniac.Entidades.CompraProducto = New Eniac.Entidades.CompraProducto()

      Dim oMovLiq As Entidades.ComprasLiquidacion

      Dim entro As Boolean = False
      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If dr.Cells("Pasaje").Value IsNot Nothing Then
            If Boolean.Parse(dr.Cells("Pasaje").Value.ToString()) Then
               entro = True
               Exit For
            End If
         End If
      Next

      If Not entro Then
         ShowMessage("No seleccionó ningún movimiento")
         Exit Sub
      End If

      Dim movimientos As List(Of Entidades.ComprasLiquidacion) = New List(Of Entidades.ComprasLiquidacion)()
      Dim mensajeError As StringBuilder = New StringBuilder
      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If dr.Cells("Pasaje").Value IsNot Nothing Then
            If Boolean.Parse(dr.Cells("Pasaje").Value.ToString()) Then

               '# Valido que los registros seleccionados NO esten excluidos
               If Boolean.Parse(dr.Cells("ExcluirDePasaje").Value.ToString()) Then
                  With mensajeError
                     Dim comprobante As String = String.Format("{0} {1} {2} {3} Proveedor: {4}",
                                          dr.Cells("IdTipoComprobante").Value.ToString(),
                                          dr.Cells("Letra").Value.ToString(),
                                          dr.Cells("CentroEmisor").Value.ToString(),
                                          dr.Cells("NroComprobante").Value.ToString(),
                                          dr.Cells("IdProveedor").Value.ToString())
                     If Not mensajeError.ToString().Contains(comprobante) Then

                        .AppendFormatLine("El comprobante {0} {1} {2} {3} Proveedor: {4} está EXCLUIDO.",
                                          dr.Cells("IdTipoComprobante").Value.ToString(),
                                          dr.Cells("Letra").Value.ToString(),
                                          dr.Cells("CentroEmisor").Value.ToString(),
                                          dr.Cells("NroComprobante").Value.ToString(),
                                          dr.Cells("IdProveedor").Value.ToString())
                     End If
                  End With
               End If

               oMovLiq = New Entidades.ComprasLiquidacion()
               With oMovLiq
                  .Sucursal = Integer.Parse(dr.Cells("Sucursal").Value.ToString())
                  .TipoComprobante = New Entidades.TipoComprobante()
                  .TipoComprobante.IdTipoComprobante = dr.Cells("IdTipoComprobante").Value.ToString()
                  .Letra = dr.Cells("Letra").Value.ToString()
                  .CentroEmisor = Short.Parse(dr.Cells("CentroEmisor").Value.ToString())
                  .NumeroComprobante = Long.Parse(dr.Cells("NroComprobante").Value.ToString())
                  '.Proveedor.TipoDocProveedor = dr.Cells("TipoDocProveedor").Value.ToString()
                  .Proveedor = New Entidades.Proveedor()
                  .Proveedor.IdProveedor = Long.Parse(dr.Cells("idProveedor").Value.ToString())
                  If Not String.IsNullOrWhiteSpace(dr.Cells("Orden").Value.ToString()) Then
                     .Orden = Long.Parse(dr.Cells("Orden").Value.ToString())
                  End If
                  If Not String.IsNullOrWhiteSpace(dr.Cells("IdConcepto").Value.ToString()) Then
                     .IdConcepto = Integer.Parse(dr.Cells("IdConcepto").Value.ToString())
                  End If

                  .ImporteALiquidar = Decimal.Parse(dr.Cells("MontoAplicar").Value.ToString()) '* Decimal.Parse(dr.Cells("CoeficienteValores").Value.ToString())
               End With
               movimientos.Add(oMovLiq)

            End If
         End If
      Next

      If Not String.IsNullOrEmpty(mensajeError.ToString()) Then
         With mensajeError
            .AppendLine()
            .AppendFormatLine("No se puede realizar el pasaje de movimientos con comprobantes Excluidos. Debe Incluirlos para poder pasarlos.")
         End With
         ShowMessage(mensajeError.ToString())
         Exit Sub
      End If

      oMovimientosLiquidacion.GrabaMovimientosLiquidaciones(movimientos)

      ShowMessage("El Pasaje de Movimientos se realizo con éxito!!")

      Me.RefrescarDatosGrilla()

   End Sub

#End Region

   Private Sub dgvDetalle_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDetalle.SelectionChanged

      Try
         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         If Me.dgvDetalle.CurrentRow IsNot Nothing Then
            Dim excluir As Boolean = Boolean.Parse(Me.dgvDetalle.CurrentRow.Cells(Entidades.Compra.Columnas.ExcluirDePasaje.ToString()).Value.ToString())
            If excluir Then
               Me.tsbIncluirEnPasaje.Visible = True
               Me.tsbExcluirDePasaje.Visible = False
            Else
               Me.tsbExcluirDePasaje.Visible = True
               Me.tsbIncluirEnPasaje.Visible = False
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbExcluirDePasaje_Click(sender As Object, e As EventArgs) Handles tsbExcluirDePasaje.Click

      Try
         ActualizarExcluirDePasaje()
         Me.CargaGrillaDetalle()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbIncluirEnPasaje_Click(sender As Object, e As EventArgs) Handles tsbIncluirEnPasaje.Click

      Try
         ActualizarExcluirDePasaje()
         Me.CargaGrillaDetalle()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Public Sub ActualizarExcluirDePasaje()

      If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

      With Me.dgvDetalle.CurrentRow

         '# Compra
         Dim idSucursal As Integer = Integer.Parse(.Cells(Entidades.Compra.Columnas.IdSucursal.ToString()).Value.ToString())
         Dim idTipoComprobante As String = .Cells(Entidades.Compra.Columnas.IdTipoComprobante.ToString()).Value.ToString()
         Dim letra As String = .Cells(Entidades.Compra.Columnas.Letra.ToString()).Value.ToString()
         Dim centroEmisor As Integer = Integer.Parse(.Cells(Entidades.Compra.Columnas.CentroEmisor.ToString()).Value.ToString())
         Dim numeroComprobante As Long = Long.Parse(.Cells("NroComprobante").Value.ToString())
         Dim idProveedor As Long = Long.Parse(.Cells(Entidades.Compra.Columnas.IdProveedor.ToString()).Value.ToString())
         Dim valor As Boolean = Me.tsbExcluirDePasaje.Visible

         Dim rCompra As Reglas.Compras = New Reglas.Compras
         rCompra.ActualizaExcluirCompraDePasaje(idSucursal,
                                                idTipoComprobante,
                                                letra,
                                                centroEmisor,
                                                numeroComprobante,
                                                idProveedor,
                                                valor)

         Dim mensaje As String = String.Format("Se {0} la compra del pasaje correctamente !!", If(valor, "excluyó", "incluyó"))
         ShowMessage(mensaje)

      End With



   End Sub

   Private Sub ChequearTodos()

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         Dim excluir As Boolean = Boolean.Parse(dr.Cells("ExcluirDePasaje").Value.ToString())
         If Not excluir Then
            dr.Cells("Pasaje").Value = Me.chbTodos.Checked
         End If
      Next

   End Sub

   Private Sub chbFechaDesde_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaDesde.CheckedChanged
      Try
         Me.dtpDesde.Enabled = Me.chbFechaDesde.Checked
         If Not Me.chbFechaDesde.Checked Then
            Me.dtpDesde.Value = Me.FechaDesdePorDefecto()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function FechaDesdePorDefecto() As Date
      Return Date.Today.AddYears(-1)
   End Function

End Class