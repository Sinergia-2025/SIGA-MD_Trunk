Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class LimpiarStock

#Region "Campos"

   Private _publicos As Publicos

   Private _cargoBienLaPantalla As Boolean
   Private _mensajeDeErrorEnCarga As String = ""

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         _publicos.CargaComboDepositos(cmbDepositos, actual.Sucursal.IdSucursal, True, True, Entidades.Publicos.SiNoTodos.TODOS)
         If cmbDepositos.Items.Count > 0 Then
            cmbDepositos.SelectedIndex = 0
            _cargoBienLaPantalla = True
         Else
            _mensajeDeErrorEnCarga = String.Format("El usuario no posee depositos autorizados para la sucursal ({0})", actual.Sucursal.Nombre)
            _cargoBienLaPantalla = False
            Exit Sub
         End If

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

         'Me.tsbBlanquear.Enabled = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         'If Not Publicos.ProductoTieneSubRubro And Me.cmbMarca.SelectedIndex = -1 And Me.cmbRubro.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: debe filtrar por Marca y/o Rubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         '   Exit Sub
         'ElseIf Publicos.ProductoTieneSubRubro And Me.cmbMarca.SelectedIndex = -1 And Me.cmbRubro.SelectedIndex = -1 And Me.cmbSubRubro.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: debe filtrar por Marca y/o Rubro y/o SubRubro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         '   Exit Sub
         'End If

         Me.RefrescarDatosGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tssRegistros.Text = "0 Registros"
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged
      Me.cmbMarca.Enabled = Me.chbMarca.Checked
      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         Me.cmbMarca.SelectedIndex = 0
      End If
   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged
      Me.cmbRubro.Enabled = Me.chbRubro.Checked
      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         Me.cmbRubro.SelectedIndex = 0
      End If
   End Sub

   Private Sub chbSubRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSubRubro.CheckedChanged
      Try
         Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

         If Not Me.chbSubRubro.Checked Then
            Me.cmbSubRubro.SelectedIndex = -1
         Else
            If Me.cmbSubRubro.Items.Count > 0 Then
               Me.cmbSubRubro.SelectedIndex = 0
            End If
         End If

         Me.cmbSubRubro.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try

         Me.chbMarca.Checked = False
         Me.chbRubro.Checked = False
         Me.chbConStock.Checked = True

         Dim oProd As Reglas.Productos = New Reglas.Productos()

         If Not Me.dgvDetalle.DataSource Is Nothing Then
            DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
         End If

         Me.chbTodos.Checked = False

         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"

         'Me.tsbBlanquear.Enabled = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbAjustar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAjustar.Click
      Me.ProcesarStock()
   End Sub

   Private Sub BlanquearStock_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged

      Me.Cursor = Cursors.WaitCursor

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         dr.Cells("chkBlanquear").Value = Me.chbTodos.Checked
      Next

      Me.Cursor = Cursors.Default

   End Sub

   Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick

      If e.ColumnIndex = 0 And e.RowIndex <> -1 Then
         Me.dgvDetalle.EndEdit()
      End If

   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Dim oProd As Reglas.Productos = New Reglas.Productos()
      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim ConStock As String = "TODOS"

      If Me.cmbMarca.SelectedIndex > -1 Then
         IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
      End If

      If Me.cmbRubro.SelectedIndex > -1 Then
         IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
      End If

      If Me.cmbSubRubro.Enabled Then
         idSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
      End If

      If Me.chbConStock.Checked Then
         ConStock = "SI"
      End If

      Me.dgvDetalle.DataSource = oProd.GetLimpiaNombreMarcaRubro(IdMarca, IdRubro, idSubRubro, "", actual.Sucursal.Id, Integer.Parse(cmbDepositos.SelectedValue.ToString()), "TODOS", ConStock)

      Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      If Me.dgvDetalle.Rows.Count > 0 Then
         Me.dgvDetalle.Focus()
      End If

      'Me.tsbBlanquear.Enabled = True

   End Sub

   Private Sub ProcesarStock()


      Dim lngTotalReg As Long = 0, strMensaje As String, lngTotalRegProcesados As Long = 0

      Try

         Me.Cursor = Cursors.WaitCursor

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows

            If Not dr.Cells("chkBlanquear").Value Is Nothing Then
               If Boolean.Parse(dr.Cells("chkBlanquear").Value.ToString()) Then
                  lngTotalReg = lngTotalReg + 1
               End If

            End If

         Next

         If lngTotalReg = 0 Then Exit Sub

         If lngTotalReg = 1 Then
            strMensaje = "¿ Procede a AJUSTAR el STOCK del Producto Seleccionado ?"
         Else
            strMensaje = "¿ Procede a AJUSTAR el STOCK de los " & lngTotalReg.ToString & " Productos Seleccionados ?"
         End If

         If MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If


         Dim oProductos As Reglas.Productos
         Dim tUbicaciones = New Reglas.SucursalesUbicaciones().GetSucursalDeposito(Integer.Parse(cmbDepositos.SelectedValue.ToString()), actual.Sucursal.IdSucursal)

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows

            If Not dr.Cells("chkBlanquear").Value Is Nothing Then

               If Boolean.Parse(dr.Cells("chkBlanquear").Value.ToString()) Then
                  oProductos = New Reglas.Productos()

                  Try

                     If Decimal.Parse(dr.Cells("Stock").Value.ToString()) <> 0 Then
                        '########################VML COMTABILIDAD
                        Dim tablaContabilidad As New DataTable
                        Dim grabaAutomatico, esMultipleRubro As Boolean

                        'vml 03/12/12  - contabilidad
                        If Reglas.Publicos.ContabilidadEjecutarEnLinea Then

                           'Dim tablaContabilidad As DataTable
                           Dim oProcesoContable As Reglas.ContabilidadProcesos = New Reglas.ContabilidadProcesos()
                           Dim idplanCuenta As Integer = oProcesoContable.getPlanCtaxMovimiento("AJUSTE")
                           Dim cantRubros As Integer = obtenerCantidadGrupos(idplanCuenta, "AJUSTE", CInt(dr.Cells("Producto").Value.ToString.Trim))

                           ' determino si muestro la pantalla de asientos o grabo automaticamente.
                           If cantRubros = 0 Then
                              Throw New Exception("El Producto no posee un rubro asociado. Debe cargar el rubro antes de procesar la compra")
                           End If

                           'grabo automaticamente, es por producto... nunca va a tener mas de un rubo un unico producto
                           If cantRubros = 1 Then
                              grabaAutomatico = True
                              esMultipleRubro = False
                              tablaContabilidad = oProcesoContable.GetRubroProducto(CInt(dr.Cells("Producto").Value.ToString.Trim), idplanCuenta, True)

                              'If tablaContabilidad.Rows.Count > 3 Then ' hay varias cuentas para imputar precio, muestro pantalla

                              '    Dim dtRubrosCompra As DataTable
                              '    dtRubrosCompra = oProcesoContable.GetRubroCompra(oMov, idplanCuenta, False)
                              '    grabaAutomatico = False
                              '    esMultipleRubro = True
                              '    tablaContabilidad = ArmarTablaMultiplesRubros(oMov, dtRubrosCompra, dgvProductos)

                              '    If tablaContabilidad.Rows.Count > 3 Then ' hay varias cuentas para imputar precio, muestro pantalla
                              '        Dim frm As New ContabilidadAsientoInterno
                              '        frm.origen = "COMPRAS"
                              '        frm.frmPadre = Me
                              '        frm.dtGrilla = dtRubrosCompra
                              '        frm.concepto = GetDscAsiento(oMov)

                              '        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                              '            tablaContabilidad = Me.tablaAsientos
                              '        Else

                              '            Throw New Exception("No se puede ingresar la Compra. Ha cancelado la grabación del asiento contable")

                              '        End If

                              '    End If
                              'End If

                              'Else ' hay mas de un tipo de grupos de cuentas, abro pantalla para que elija.


                              '    Dim dtRubrosCompra As DataTable
                              '    dtRubrosCompra = oProcesoContable.GetRubroCompra(oMov, idplanCuenta, False)
                              '    grabaAutomatico = False
                              '    esMultipleRubro = True
                              '    tablaContabilidad = ArmarTablaMultiplesRubros(oMov, dtRubrosCompra, dgvProductos)

                              '    If tablaContabilidad.Rows.Count > 6 Then ' hay varias cuentas para imputar precio, muestro pantalla
                              '        Dim frm As New ContabilidadAsientoInterno
                              '        frm.origen = "COMPRAS"
                              '        frm.frmPadre = Me
                              '        frm.dtGrilla = dtRubrosCompra
                              '        frm.concepto = GetDscAsiento(oMov)

                              '        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                              '            tablaContabilidad = Me.tablaAsientos
                              '        Else

                              '            Throw New Exception("No se puede ingresar la Compra. Ha cancelado la grabación del asiento contable")

                              '        End If

                              '    End If

                           End If

                        End If
                        '############################### FIN CONTABILIDAD
                        For Each drUbi As DataRow In tUbicaciones.Rows
                           oProductos.AjustarStock(actual.Sucursal.Id, Integer.Parse(drUbi("IdDeposito").ToString()),
                                                   Integer.Parse(drUbi("IdUbicacion").ToString()),
                                                   dr.Cells("Producto").Value.ToString.Trim(),
                                                   tablaContabilidad,
                                                   grabaAutomatico,
                                                   esMultipleRubro,
                                                   DirectCast(dr.Cells("Stock").Value, Decimal) * -1,
                                                   Entidades.Entidad.MetodoGrabacion.Manual,
                                                   IdFuncion)
                        Next
                     End If
                     lngTotalRegProcesados = lngTotalRegProcesados + 1
                  Catch ex As Exception

                     'MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                     strMensaje = "IMPOSIBLE AJUSTAR el STOCK del Producto " & dr.Cells("Producto").Value.ToString & "-" & dr.Cells("NombreProducto").Value.ToString
                     strMensaje = strMensaje & Chr(13) & Chr(13) & "¿ Continua BLANQUEANDO el STOCK del resto de los Productos Seleccionados ?"

                     If MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        Exit For
                     End If

                  End Try

               End If

            End If

         Next

         Select Case lngTotalRegProcesados
            Case 0
               strMensaje = " ATENCION!!: NO se AJUSTO el STOCK de ningún Producto !!"
            Case 1
               strMensaje = " Producto con STOCK AJUSTADO SATISFACTORIAMENTE !!"
            Case Else
               strMensaje = lngTotalRegProcesados.ToString & " productos de " & lngTotalReg.ToString & " (Seleccionados) fueron AJUSTADOS SATISFACTORIAMENTE !!"
         End Select

         MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         If lngTotalRegProcesados > 0 Then
            Me.btnBuscar_Click(Me.btnBuscar, New EventArgs())
            Me.chbTodos.Checked = False
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub LimpiarStock_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      Try
         If Not _cargoBienLaPantalla Then
            MessageBox.Show(_mensajeDeErrorEnCarga, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Function obtenerCantidadGrupos(ByVal idplanCuenta As Integer _
                                          , ByVal tipomov As String _
                                          , ByVal idProducto As Integer) As Integer

      Dim oProcesoContable As Reglas.ContabilidadProcesos = New Reglas.ContabilidadProcesos()
      Return oProcesoContable.GetCantRubrosProducto(idplanCuenta, tipomov, idProducto)

   End Function


#End Region

End Class