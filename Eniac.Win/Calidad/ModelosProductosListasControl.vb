Imports Infragistics.Win.UltraWinGrid

Public Class ModelosProductosListasControl

#Region "Campos"

   Private _dtListasControl As DataTable
   Private _dtModelosListasControl As Entidades.ListConBorrados(Of Entidades.ListaControlModelo)
   'Private _dtProductosListasControl As DataTable
   Private _publicos As Publicos
   Private _cargandoPantalla As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._cargandoPantalla = True
         _publicos = New Publicos()

         Me._cargandoPantalla = False

         '  Me.CargarListasControl(True)
         '  RefrescarGrilla()

         spcDatos.Enabled = True

         LeerPreferencias()

         spcDatos.Enabled = False

         tsbPreferencias.Enabled = True
         tsbGrabar.Enabled = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me._cargandoPantalla = False
      End Try

   End Sub

   Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
      MyBase.OnClosing(e)
      Try
         '  Me.ControlaCambios()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarListasControl(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then
         _dtListasControl = New Reglas.ListasControl()._GetTodos()
         bdsListasControl.DataSource = _dtListasControl
         Me.FormateaGrillaListasControl()
      End If
   End Sub

   Private Sub CargarProductosListasControl(tablaVacia As Boolean)
      If Me.bscModelo2.Selecciono Then

         Dim lista As List(Of Entidades.ListaControlModelo) = New Reglas.ListasControlModelos().GetTodas(Integer.Parse(Me.bscModelo2.Tag.ToString().Trim()))

         _dtModelosListasControl = New Entidades.ListConBorrados(Of Entidades.ListaControlModelo)(lista)

         bdsProductosListasControl.Filter = String.Empty
         bdsProductosListasControl.DataSource = _dtModelosListasControl
         FormateaGrillaListasControlModelos()

         If _dtModelosListasControl.Count = 0 Then
            Me.chbCopiarModelo.Enabled = True
         End If
      End If
   End Sub

   Private Sub CargarProductosListasControlCopia(tablaVacia As Boolean)
      If Me.bscModelo2Copiar.Selecciono Then

         Dim lista As List(Of Entidades.ListaControlModelo) = New Reglas.ListasControlModelos().GetTodas(Integer.Parse(Me.bscModelo2Copiar.Tag.ToString().Trim()))

         _dtModelosListasControl = New Entidades.ListConBorrados(Of Entidades.ListaControlModelo)(lista)

         For Each lis As Entidades.ListaControlModelo In _dtModelosListasControl
            lis.IdProductoModelo = Integer.Parse(Me.bscModelo2.Tag.ToString())
            lis.IdUsuario = actual.Nombre
            lis.fecha = Date.Now
         Next

         bdsProductosListasControl.Filter = String.Empty
         bdsProductosListasControl.DataSource = _dtModelosListasControl
         FormateaGrillaListasControlModelos()

      End If
   End Sub


   Private Sub ControlaCambios()
      If Me.tsbGrabar.Enabled Then
         If ShowPregunta("¿Desea grabar los cambios?") = Windows.Forms.DialogResult.Yes Then
            Me.Grabar()
         End If
      End If
   End Sub

   Private Sub AgregarListaAProducto()
      Me.Cursor = Cursors.WaitCursor

      If ugListasControl.Selected.Rows.Count = 0 And ugListasControl.ActiveRow IsNot Nothing Then
         ugListasControl.ActiveRow.Selected = True
      End If

      Try
         Dim _Iniciado As Boolean = False
         For Each drLista As Entidades.ListaControlModelo In _dtModelosListasControl
            'If drLista.FecIngreso <> Nothing Then
            '   _Iniciado = True
            '   Exit For
            'End If
         Next

         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         If Not _Iniciado Or (_Iniciado And oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdListControl_ElimAgregList")) Then

            Dim drListaCol As List(Of DataRow) = New List(Of DataRow)()
            For Each dgLista As UltraGridRow In ugListasControl.Selected.Rows
               If dgLista.ListObject IsNot Nothing AndAlso
                  TypeOf (dgLista.ListObject) Is DataRowView AndAlso
                  DirectCast(dgLista.ListObject, DataRowView).Row IsNot Nothing Then

                  For Each item As Entidades.ListaControlModelo In _dtModelosListasControl
                     If item.IdListaControl = Integer.Parse(dgLista.Cells("IdListaControl").Value.ToString()) Then
                        Throw New Exception("Ya existe la lista de control: " & dgLista.Cells("NombreListaControl").Value.ToString())
                     End If
                  Next

                  drListaCol.Add(DirectCast(dgLista.ListObject, DataRowView).Row)


               End If
            Next

            Dim Lista As Entidades.ListaControlModelo

            For Each drLista As DataRow In drListaCol

               Lista = New Entidades.ListaControlModelo()

               Lista.NombreListaControl = drLista.Field(Of String)("NombreListaControl")
               Lista.IdListaControl = drLista.Field(Of Integer)("IdListaControl")
               Lista.Orden = drLista.Field(Of Integer)("Orden")
               Lista.IdUsuario = actual.Nombre
               Lista.fecha = Date.Now()
               Lista.IdProductoModelo = Integer.Parse(Me.bscModelo2.Tag.ToString())
               'Lista.Aplica = True
               'Lista.IdEstadoCalidad = New Reglas.EstadosListasControl().GetEstadoPorDefecto()

               _dtModelosListasControl.Add(Lista)
               ugProductoListasControl.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
               ugProductoListasControl.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

               _dtListasControl.AcceptChanges()

            Next

            tsbGrabar.Enabled = True
         Else
            If Not oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdListControl_ElimAgregList") Then
               MessageBox.Show("No puede agregar la lista de Control porque el Producto tiene listas iniciadas. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
               Exit Sub
            End If
         End If

      Catch
         ' _dtProductosListasControl.RejectChanges()
         _dtListasControl.RejectChanges()
         Throw
      End Try

   End Sub

   Private Sub SacarListaDeProducto()
      If ugProductoListasControl.Selected.Rows.Count = 0 And ugProductoListasControl.ActiveRow IsNot Nothing Then
         ugProductoListasControl.ActiveRow.Selected = True
      End If



      Try
         Dim drModeloListaControl As List(Of Entidades.ListaControlModelo) = New List(Of Entidades.ListaControlModelo)()
         For Each dgRow As UltraGridRow In ugProductoListasControl.Selected.Rows
            If dgRow.ListObject IsNot Nothing AndAlso
               TypeOf (dgRow.ListObject) Is Entidades.ListaControlModelo AndAlso
               DirectCast(dgRow.ListObject, Entidades.ListaControlModelo) IsNot Nothing Then

               Dim Lista As Entidades.ListaControlModelo = GetCurrentLista()

               drModeloListaControl.Add(Lista)

            End If
         Next
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

         Dim _Iniciado As Boolean = False
         For Each drLista As Entidades.ListaControlModelo In drModeloListaControl
            'If drLista.FecIngreso <> Nothing Then
            '   _Iniciado = True
            '   Exit For
            'End If
         Next

         If Not _Iniciado Or (_Iniciado And oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdListControl_ElimAgregList")) Then

            For Each drLista As Entidades.ListaControlModelo In drModeloListaControl

               _dtModelosListasControl.Remove(drLista)
               ugProductoListasControl.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

               _dtListasControl.AcceptChanges()

               tsbGrabar.Enabled = True

            Next
         Else
            If Not oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ProdListControl_ElimAgregList") Then
               MessageBox.Show("No puede eliminar la lista de Control porque el Producto tiene listas iniciadas. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
               Exit Sub
            End If
         End If

      Catch
         '   _dtProductosListasControl.RejectChanges()
         _dtListasControl.RejectChanges()
         Throw
      End Try
   End Sub

   Private Sub Grabar()

      '   Me._dtProductosListasControl.AcceptChanges()

      Dim rListasControlModelos As Reglas.ListasControlModelos = New Reglas.ListasControlModelos()

      rListasControlModelos.Guardar(Me._dtModelosListasControl)

      Me.Cursor = Cursors.Default
      MessageBox.Show("Lista/s de Control grabada/s exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      RefrescarGrilla()
   End Sub

   Private Sub RefrescarGrilla()
      Me.bdsProductosListasControl.DataSource = Nothing
      Me.bdsListasControl.DataSource = Nothing
      Me.tsbGrabar.Enabled = False
      spcDatos.Enabled = False
      Me.bscModelo2.Enabled = True
      Me.bscModelo2.Enabled = True
      Me.bscModelo2.Text = ""
      Me.bscModelo2.Text = ""
      Me.chbCopiarModelo.Checked = False
      Me.chbCopiarModelo.Enabled = False
   End Sub

   Private Sub FormateaGrillaListasControl()
      FormateaGrillaListasControl(Me.ugListasControl)
   End Sub

   Private Sub FormateaGrillaListasControlModelos()
      FormateaGrillaListasControlProductoModelo(Me.ugProductoListasControl)
   End Sub

   Private Sub FormateaGrillaListasControl(grilla As UltraGrid)
      Dim col As Integer = 0
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"NombreListaControl"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         ' Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdListaControl"), "Código", col, 70)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreListaControl"), "Nombre", col, 250)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Orden"), "Orden", col, 70, HAlign.Right)

      End With
   End Sub

   Private Sub FormateaGrillaListasControlProductoModelo(grilla As UltraGrid)
      Dim col As Integer = 0
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"NombreListaControl"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next
         '.Columns("Aplica").Style = ColumnStyle.CheckBox

         '     Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Aplica"), "Aplica", col, 60, , , , , Activation.AllowEdit)
         'Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdListaControl"), "Código", col, 70)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreListaControl"), "Nombre", col, 250)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Orden"), "Orden", col, 70, HAlign.Right)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdUsuario"), "Usuario", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Fecha"), "Fecha Alta", col, 80)
         'Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("FecIngreso"), "Fecha Ingreso", col, 80)



      End With
   End Sub

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugListasControl.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugListasControl.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarDatosModelo(ByVal dr As DataGridViewRow, buscador As Eniac.Controles.Buscador2)
      buscador.Text = dr.Cells("NombreProductoModelo").Value.ToString()
      buscador.Tag = dr.Cells("IdProductoModelo").Value.ToString.Trim()

      Me.tsbGrabar.Enabled = True

      Me.CargaGrillas()

   End Sub

   Private Function ValidaLinea() As Boolean
      If Me._dtModelosListasControl IsNot Nothing Then
         'For Each item As DataRow In _dtProductosListasControl.Rows
         '   If item("IdListaControl") = Integer.Parse(ugListasControl.ActiveRow.Cells("IdListaControl").Value.ToString()) Then
         '      Throw New Exception("Ya existe la lista de control.")
         '   End If
         'Next
      End If
      Return True
   End Function

   Private Function GetCurrentLista() As Entidades.ListaControlModelo
      If ugProductoListasControl.ActiveRow IsNot Nothing AndAlso
         ugProductoListasControl.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugProductoListasControl.ActiveRow.ListObject) Is Entidades.ListaControlModelo Then
         Return DirectCast(ugProductoListasControl.ActiveRow.ListObject, Entidades.ListaControlModelo)
      End If
      Return Nothing
   End Function

   Private Sub CargaGrillas()
      Try

         Me.Cursor = Cursors.WaitCursor

         Me.bscModelo2.Enabled = False

         CargarListasControl(False)

         If Me.bscModelo2Copiar.Enabled Then
            CargarProductosListasControlCopia(False)
         Else
            CargarProductosListasControl(False)
         End If

         spcDatos.Enabled = True

         Me.tssProductosListaControl.Text = ugProductoListasControl.Rows.Count.ToString() & " Registros"
         Me.tssListasControlAsignar.Text = ugListasControl.Rows.Count.ToString() & " Registros"

         If _dtListasControl.Rows.Count > 0 Then
            ugListasControl.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub


#End Region

#Region "Eventos"

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub dgvClientes_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugListasControl.MouseDoubleClick
      Me.btnAgregar_Click(sender, e)
   End Sub

   Private Sub dgvRutas_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugProductoListasControl.MouseDoubleClick
      Me.btnSacar_Click(sender, e)
   End Sub

   Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
      Try
         AgregarListaAProducto()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvRutas_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ugProductoListasControl.DragEnter
      e.Effect = DragDropEffects.Copy
   End Sub

   Private Sub btnSacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacar.Click
      Try
         Me.SacarListaDeProducto()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.Grabar()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try

         '' '' '' ''Dim sFecha As String
         '' '' '' ''Dim sVendedor As String
         '' '' '' ''Dim ru As Reglas.RutasClientes = New Reglas.RutasClientes()
         '' '' '' ''Dim idRuta As Integer = DirectCast(Me.cmbRutas.SelectedItem, Entidades.Ruta).IdRuta
         '' '' '' ''Dim dt As DataTable

         '' '' '' ''Me.Cursor = Cursors.WaitCursor

         '' '' '' ''sFecha = "Fecha : " & DateTime.Now().ToString("dd/MM/yyyy hh:mm tt")
         '' '' '' ''sVendedor = DirectCast(Me.cmbRutas.SelectedItem, Entidades.Ruta).Vendedor.NombreEmpleado
         '' '' '' ''Me._ruta = ru.GetPorVendedor(idRuta)
         '' '' '' ''dt = DirectCast(Me._ruta, DataTable)

         '' '' '' ''Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresa))
         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Vendedor", sVendedor))

         ' '' '' '' ''GAR: 02/10/2017 - Esta Parametro se quito del reporte porque esta la fecha de impresion. Tal vez alguna vez tenia la fecha de actualizado.
         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", sFecha))

         '' '' '' ''Dim frmImprime As VisorReportes = New VisorReportes("Eniac.SiLIVE.Win.ListadoRutaClientes.rdlc", "DataSet_log", dt, parm, True)
         '' '' '' ''frmImprime.Text = Me.Text
         '' '' '' ''frmImprime.WindowState = FormWindowState.Maximized
         '' '' '' ''frmImprime.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chbAlineacionPaneles_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlineacionPaneles.CheckedChanged
      If Me.chbAlineacionPaneles.Checked Then
         Me.spcDatos.Orientation = Orientation.Horizontal
      Else
         Me.spcDatos.Orientation = Orientation.Vertical
      End If
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try

         If Not Me.bscModelo2.Selecciono Then
            ShowMessage("ATENCION: Debe seleccionar un Producto")
            Me.bscModelo2.Focus()
            Exit Sub
         End If

         If Me.bscModelo2.Text = Me.bscModelo2Copiar.Text Then
            ShowMessage("ATENCION: No puede copiar del mismo Modelo.")
            Me.bscModelo2Copiar.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.bscModelo2.Enabled = False

         CargarListasControl(False)
         CargarProductosListasControl(False)

         spcDatos.Enabled = True

         Me.tssProductosListaControl.Text = ugProductoListasControl.Rows.Count.ToString() & " Registros"
         Me.tssListasControlAsignar.Text = ugListasControl.Rows.Count.ToString() & " Registros"

         If _dtListasControl.Rows.Count > 0 Then
            ugListasControl.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugListasControl, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscModelo2_BuscadorClick() Handles bscModelo2.BuscadorClick
      Try
         Dim oModelos As Reglas.ProductosModelos = New Reglas.ProductosModelos
         Me._publicos.PreparaGrillaModelosProductos(Me.bscModelo2)
         Me.bscModelo2.Datos = oModelos.GetPorNombre(Me.bscModelo2.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscModelo2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscModelo2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosModelo(e.FilaDevuelta, Me.bscModelo2)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscModelo2Copiar_BuscadorClick() Handles bscModelo2Copiar.BuscadorClick
      Try
         Dim oModelos As Reglas.ProductosModelos = New Reglas.ProductosModelos
         Me._publicos.PreparaGrillaModelosProductos(Me.bscModelo2Copiar)
         Me.bscModelo2Copiar.Datos = oModelos.GetPorNombre(Me.bscModelo2Copiar.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscModelo2Copiar_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscModelo2Copiar.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosModelo(e.FilaDevuelta, Me.bscModelo2Copiar)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub ugUsuarios_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugListasControl.AfterRowFilterChanged
      Me.tssProductosListaControl.Text = Me.ugListasControl.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub ugListasControlUsuarios_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugProductoListasControl.AfterRowFilterChanged
      Me.tssListasControlAsignar.Text = Me.ugProductoListasControl.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ProductosListasControl_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F5
            Me.tsbRefrescar.PerformClick()
         Case Keys.F4
            Me.tsbGrabar.PerformClick()
         Case Else
      End Select
   End Sub

   Private Sub chbCopiarModelo_CheckedChanged(sender As Object, e As EventArgs) Handles chbCopiarModelo.CheckedChanged
      Try
         Me.bscModelo2Copiar.Enabled = Me.chbCopiarModelo.Checked
         If Not Me.chbCopiarModelo.Checked Then
            Me.bscModelo2Copiar.Text = ""
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#End Region


End Class