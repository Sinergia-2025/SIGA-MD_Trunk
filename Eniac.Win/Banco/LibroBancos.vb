Public Class LibroBancos

#Region "Propiedades"

   Private _idActualCuentaBancaria As Integer = 0
   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New Eniac.Win.Publicos()

            ugDetalle.AgregarTotalesSuma({"Importe"})
            SetearFechas()
            OrdenarGrillaDetalle()

            _publicos.CargaComboDesdeEnum(cmbConciliado, GetType(Entidades.Publicos.SiNoTodos))
            cmbConciliado.SelectedIndex = 0

            '-.PE-31500.-
            _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))

            ugDetalle.AgregarFiltroEnLinea({"NombreCuentaBanco", "Observacion"})

            If Publicos.UnificaLibrosDeBanco Then
               ugDetalle.DisplayLayout.Bands(0).Columns(Entidades.LibroBanco.Columnas.IdSucursal.ToString()).Hidden = False
            End If

            PreferenciasLeer(ugDetalle, tsbPreferencias)
         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      ElseIf keyData = Keys.F4 Then
         btnMostrar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            RefrescarDatosGrilla()
            tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
            bscCuentaBancaria.Focus()
         End Sub)
   End Sub

   Private Sub tsbNuevoMovimiento_Click(sender As Object, e As EventArgs) Handles tsbNuevoMovimiento.Click
      TryCatched(
         Sub()
            If bscCuentaBancaria.FilaDevuelta Is Nothing Then
               ShowMessage("Por favor seleccione el cuenta bancaria.")
            Else
               Using fLibroBancosDetalles = New LibroBancosDetalles()
                  fLibroBancosDetalles.Operacion = Reglas.CuentasBancos.TipoOperacion.Nuevo
                  fLibroBancosDetalles.IdCuentaBancaria = Integer.Parse(bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString())

                  fLibroBancosDetalles.ShowDialog()
                  CargarMovimientos()
               End Using

            End If
         End Sub)
   End Sub

   Private Sub bscCuentaBancaria_BuscadorClick() Handles bscCuentaBancaria.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancaria)
            Dim oCBancarias = New Reglas.CuentasBancarias()
            bscCuentaBancaria.Datos = oCBancarias.GetFiltradoPorNombre(bscCuentaBancaria.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCuentaBancaria_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancaria.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not bscCuentaBancaria.FilaDevuelta Is Nothing Then
               bscCuentaBancaria.Text = bscCuentaBancaria.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
               _idActualCuentaBancaria = Integer.Parse(Me.bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString())
               bscCuentaBancaria.Enabled = False

               CargarMovimientos()
            End If
         End Sub)
   End Sub

   Private Sub dpFechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles dpFechaHasta.ValueChanged
      TryCatched(Sub() dpSaldoAl.Value = dpFechaHasta.Value)
   End Sub

   Private Sub tsbEditarMovimiento_Click(sender As Object, e As EventArgs) Handles tsbEditarMovimiento.Click
      TryCatched(
         Sub()
            If bscCuentaBancaria.FilaDevuelta Is Nothing Then
               ShowMessage("Por favor seleccione el cuenta bancaria.")
            ElseIf ugDetalle.ActiveRow Is Nothing Then
               ShowMessage("Por favor seleccione el movimiento a editar.")
            Else
               Using fLibroBancosDetalles = New LibroBancosDetalles()

                  fLibroBancosDetalles.Operacion = Reglas.CuentasBancos.TipoOperacion.Modificacion
                  fLibroBancosDetalles.IdSucursal = Integer.Parse(Me.ugDetalle.ActiveRow.Cells("IdSucursal").Value.ToString())
                  fLibroBancosDetalles.NumeroMovimiento = Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroMovimiento").Value.ToString())
                  fLibroBancosDetalles.IdCuentaBancaria = Integer.Parse(Me.bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString())
                  fLibroBancosDetalles.ShowDialog()

                  CargarMovimientos()
               End Using

            End If
         End Sub)
   End Sub

   Private Sub tsbEliminarMovimiento_Click(sender As Object, e As EventArgs) Handles tsbEliminarMovimiento.Click
      TryCatched(
         Sub()
            If bscCuentaBancaria.FilaDevuelta Is Nothing Then
               MessageBox.Show("Por favor seleccione el cuenta bancaria.", "Cuenta Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.ugDetalle.ActiveRow Is Nothing Then
               MessageBox.Show("Por favor seleccione el movimiento a eliminar.", "Eliminar movimiento", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else

               If Not Boolean.Parse(Me.ugDetalle.ActiveRow.Cells("EsModificable").Value.ToString()) Then
                  MessageBox.Show("Este movimiento no se puede Eliminar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If

               If Reglas.Publicos.ContabilidadEjecutarEnLinea Then
                  Dim oEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios

                  Dim codEjeVigente As Integer
                  Dim idPeriodoActual As String
                  codEjeVigente = oEjercicio.GetEjercicioVigente(CDate(Me.ugDetalle.ActiveRow.Cells("fechaMovimiento").Value))  'obtengo el ejercicio vigente

                  If codEjeVigente = 0 Then
                     Dim strMensaje As String
                     strMensaje = "No puede eliminar el movimiento, el periódo contable esta cerrado"
                     MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                     Exit Sub
                  End If
                  idPeriodoActual = oEjercicio.GetPeriodoActual(codEjeVigente, CDate(Me.ugDetalle.ActiveRow.Cells("fechaMovimiento").Value))

                  If (oEjercicio.EstaPeriodoCerrado(codEjeVigente, idPeriodoActual)) Then 'valido que el periodo no este cerrado
                     Dim strMensaje As String
                     strMensaje = "No puede eliminar el movimiento, el periódo contable esta cerrado"
                     MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                     Exit Sub
                  Else

                  End If
               End If

               If Reglas.Publicos.TieneModuloContabilidad Then
                  Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos
                  Dim eLibroBanco As Entidades.LibroBanco '= New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
                  Dim oContabilidad As Reglas.ContabilidadProcesos = New Reglas.ContabilidadProcesos

                  Dim idSucursal As Integer = Integer.Parse(Me.ugDetalle.ActiveRow.Cells(Entidades.LibroBanco.Columnas.IdSucursal.ToString()).Value.ToString())
                  eLibroBanco = oLibroBancos.GetUno(idSucursal, Integer.Parse(Me.bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()),
                                          Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroMovimiento").Value.ToString()))

                  Dim ctbl = New Reglas.Contabilidad()
                  If ctbl.AsientoProcesadoComoDefinitivo(eLibroBanco.IdEjercicio, eLibroBanco.IdPlanCuenta, eLibroBanco.IdAsiento) Then
                     Throw New Exception("No es posible Eliminar el movimiento porque el asiento contable asociado ya fue procesado como DEFINITIVO.")
                  End If
               End If

               Dim Message As String = "Realmente desea eliminar el movimiento seleccionado?"
               Dim res As DialogResult = MessageBox.Show(Message, "Eliminar  movimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

               If res = Windows.Forms.DialogResult.Yes Then

                  Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos()
                  Dim eLibroBanco As Entidades.LibroBanco
                  Dim idSucursal As Integer = Integer.Parse(Me.ugDetalle.ActiveRow.Cells(Entidades.LibroBanco.Columnas.IdSucursal.ToString()).Value.ToString())
                  eLibroBanco = oLibroBancos.GetUno(idSucursal, Integer.Parse(Me.bscCuentaBancaria.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()),
                                                    Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroMovimiento").Value.ToString()))

                  oLibroBancos.EliminarMovimiento(eLibroBanco)

                  MessageBox.Show("El movimiento ha sido eliminado con exito.", "Eliminar movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)

                  CargarMovimientos()

               End If

            End If
         End Sub)

   End Sub

   ''COPIA
   'Private Sub tsbConciliar_Click(sender As Object, e As EventArgs) Handles tsbConciliar.Click

   '   Try

   '      If Me.ugDetalle.ActiveRow IsNot Nothing Then

   '         Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos
   '         Dim idSucursal As Integer = Integer.Parse(Me.ugDetalle.ActiveRow.Cells(Entidades.LibroBanco.Columnas.IdSucursal.ToString()).Value.ToString())
   '         Dim conciliadoResult As Boolean
   '         If Me.ugDetalle.ActiveRow.Cells("Conciliado").Value.ToString() = "Si" Then
   '            Dim DR As DialogResult = MessageBox.Show("Realmente desea desconciliar el movimiento?", "Desconciliar Movimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
   '            If DR = Windows.Forms.DialogResult.Yes Then
   '               conciliadoResult = oLibroBancos.ConciliarMovimiento(idSucursal,
   '                                                Me._IdActualCuentaBancaria,
   '                                                Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroMovimiento").Value.ToString()),
   '                                                False)
   '            End If
   '         Else
   '            Dim DR As DialogResult = MessageBox.Show("Realmente desea conciliar el movimiento?", "Conciliar Movimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
   '            If DR = Windows.Forms.DialogResult.Yes Then
   '               conciliadoResult = oLibroBancos.ConciliarMovimiento(idSucursal,
   '                                                Me._IdActualCuentaBancaria,
   '                                                Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroMovimiento").Value.ToString()),
   '                                                True)
   '            End If
   '         End If

   '         If conciliadoResult Then
   '            Me.ugDetalle.ActiveRow.Cells("Conciliado").Value = "Si"
   '         Else
   '            Me.ugDetalle.ActiveRow.Cells("Conciliado").Value = "No"
   '         End If
   '         ugDetalle_AfterRowActivate(ugDetalle, Nothing)
   '         ugDetalle.PerformAction(UltraGridAction.BelowCell, False, False)

   '         Me.CargarSaldos()

   '         'No se cargan los movimientos porque se pierde la posicion.
   '         'Me.CargarMovimientos()

   '      Else
   '         MessageBox.Show("Seleccione el movimiento a conciliar.", "Conciliar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Stop)
   '      End If


   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

   '-.PE-31500.-
   Private Sub tsbConciliar_Click(sender As Object, e As EventArgs) Handles tsbConciliar.Click
      TryCatched(
         Sub()
            Dim oLibroBancos = New Reglas.LibroBancos()
            Dim conciliadoResult As Boolean

            Dim DR2 = ShowPregunta("¿Realmente desea conciliar el/los movimiento/s?")
            If DR2 = Windows.Forms.DialogResult.Yes Then

               Dim sinSelec As Boolean = False
               ugDetalle.DataBind()

               Dim flack As Boolean = True

               For Each dr As UltraGridRow In Me.ugDetalle.Rows
                  If Boolean.Parse(dr.Cells("Selec").Value.ToString()) And dr.Cells("Conciliado").Value.ToString() = "No" Then
                     flack = False
                  End If

               Next

               If flack Then
                  '-- proceso viejo ActiveRow.
                  If Me.ugDetalle.ActiveRow.Cells("Conciliado").Value.ToString() = "No" Then
                     Dim idSucursal = Integer.Parse(Me.ugDetalle.ActiveRow.Cells(Entidades.LibroBanco.Columnas.IdSucursal.ToString()).Value.ToString())
                     conciliadoResult = oLibroBancos.ConciliarMovimiento(idSucursal,
                                                                      Me._idActualCuentaBancaria,
                                                                      Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroMovimiento").Value.ToString()),
                                                                      True)
                  End If

                  If conciliadoResult Then
                     Me.ugDetalle.ActiveRow.Cells("Conciliado").Value = "Si"
                  End If

                  ugDetalle_AfterRowActivate(ugDetalle, Nothing)
                  ugDetalle.PerformAction(UltraGridAction.BelowCell, False, False)

                  Me.CargarSaldos()

               Else
                  'PROCESO NUEVO
                  For Each dr As UltraGridRow In Me.ugDetalle.Rows
                     If dr.Cells("Selec").Value IsNot Nothing Then
                        If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then

                           Dim idSucursal = CInt(dr.Cells("IdSucursal").Value.ToString())

                           If dr.Cells("Conciliado").Value.ToString() = "No" Then
                              conciliadoResult = oLibroBancos.ConciliarMovimiento(idSucursal,
                                                               Me._idActualCuentaBancaria,
                                                               Integer.Parse(dr.Cells("NumeroMovimiento").Value.ToString()),
                                                               True)
                           End If

                           If conciliadoResult Then
                              dr.Cells("Conciliado").Value = "Si"
                           End If

                           Me.CargarSaldos()
                        End If

                     Else
                        sinSelec = True
                     End If

                  Next

               End If

               If sinSelec Then
                  MessageBox.Show("Seleccione el movimiento a conciliar.", "Conciliar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  sinSelec = False
               End If
            End If
         End Sub)
   End Sub


   '-.PE-31500.-
   Private Sub tsbDesconciliar_Click(sender As Object, e As EventArgs) Handles tsbDesconciliar.Click
      TryCatched(
         Sub()
            Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos
            Dim idSucursal As Integer = Integer.Parse(Me.ugDetalle.ActiveRow.Cells(Entidades.LibroBanco.Columnas.IdSucursal.ToString()).Value.ToString())
            Dim conciliadoResult As Boolean

            Dim DR2 = MessageBox.Show("Realmente desea desconciliar el/los movimiento/s?", "Desconciliar Movimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If DR2 = Windows.Forms.DialogResult.Yes Then

               Dim sinSelec As Boolean = False
               Me.ugDetalle.DataBind()

               Dim flack As Boolean = True

               For Each dr As UltraGridRow In Me.ugDetalle.Rows
                  If Boolean.Parse(dr.Cells("Selec").Value.ToString()) And dr.Cells("Conciliado").Value.ToString() = "Si" Then
                     flack = False
                  End If

               Next

               If flack Then
                  '-- proceso viejo ActiveRow.
                  If Me.ugDetalle.ActiveRow.Cells("Conciliado").Value.ToString() = "Si" Then
                     idSucursal = Integer.Parse(Me.ugDetalle.ActiveRow.Cells(Entidades.LibroBanco.Columnas.IdSucursal.ToString()).Value.ToString())
                     conciliadoResult = oLibroBancos.ConciliarMovimiento(idSucursal,
                                                                         Me._idActualCuentaBancaria,
                                                                         Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroMovimiento").Value.ToString()),
                                                                         False)
                  End If

                  If Not conciliadoResult Then
                     Me.ugDetalle.ActiveRow.Cells("Conciliado").Value = "No"
                  End If

                  ugDetalle_AfterRowActivate(ugDetalle, Nothing)
                  ugDetalle.PerformAction(UltraGridAction.BelowCell, False, False)

                  Me.CargarSaldos()

               Else
                  'PROCESO NUEVO
                  For Each dr As UltraGridRow In Me.ugDetalle.Rows

                     If dr.Cells("Selec").Value IsNot Nothing Then
                        If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then

                           idSucursal = CInt(dr.Cells("IdSucursal").Value.ToString())

                           If dr.Cells("Conciliado").Value.ToString() = "Si" Then
                              conciliadoResult = oLibroBancos.ConciliarMovimiento(idSucursal,
                                                                  Me._idActualCuentaBancaria,
                                                                  Integer.Parse(dr.Cells("NumeroMovimiento").Value.ToString()),
                                                                  False)
                           End If

                           If Not conciliadoResult Then
                              dr.Cells("Conciliado").Value = "No"
                           End If

                           Me.CargarSaldos()
                        End If
                     Else
                        sinSelec = True
                     End If
                  Next

               End If

               If sinSelec Then
                  MessageBox.Show("Seleccione el movimiento a conciliar.", "Conciliar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  sinSelec = False
               End If
            End If
         End Sub)
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbImprimirPred_Click(sender As Object, e As EventArgs) Handles tsbImprimirPred.Click
      TryCatched(
         Sub()
            If Not bscCuentaBancaria.FilaDevuelta Is Nothing Then
               Dim dtMov As DataTable = DirectCast(ugDetalle.DataSource, DataTable)

               Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

               parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
               parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
               parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Titulo", Me.Text))
               parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", CargarFiltrosImpresion()))

               Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.LibroBancos.rdlc", "DSReportes_LibrosBancos", dtMov, parm, True, 1) '# 1 = Cantidad Copias

               frmImprime.Text = Text
               frmImprime.WindowState = FormWindowState.Maximized
               frmImprime.Show()

            Else
               MessageBox.Show("Por favor seleccione una cuenta bancaria", Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
         End Sub)
   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat(" Cuenta Bancaria: {0} ", bscCuentaBancaria.Text)
         .AppendFormat(" - Rango de Fechas: Desde: {0:dd/MM/yyyy} Hasta: {1:dd/MM/yyyy}", dpFechaDesde.Value, dpFechaHasta.Value)
         .AppendFormat(" - {0} Conciliado", If(optGeneral.Checked, "No", ""))
      End With
      Return filtro.ToString().Trim()
   End Function
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim Titulo As String

            Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

            'Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
            'Me.UltraPrintPreviewDialog1.Name = Me.Text
            Dim UltraPrintPreviewD As Printing.UltraPrintPreviewDialog
            UltraPrintPreviewD = New Printing.UltraPrintPreviewDialog(components)
            UltraPrintPreviewD.AutoSizeMode = AutoSizeMode.GrowAndShrink
            UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

            UltraPrintPreviewD.Document = UltraGridPrintDocument1
            UltraPrintPreviewD.Name = Text

            UltraGridPrintDocument1.Header.TextCenter = Titulo
            UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
            UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
            UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
            UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
            UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
            UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

            ' Me.UltraPrintPreviewDialog1.ShowDialog()
            UltraPrintPreviewD.MdiParent = Me.MdiParent
            UltraPrintPreviewD.Show()
            UltraPrintPreviewD.Focus()
         End Sub)

   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub
            ugDetalle.Exportar(Name & ".xls", Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
         End Sub)
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count = 0 Then Exit Sub
            ugDetalle.Exportar(Name & ".pdf", Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
         End Sub)
   End Sub

   Private Sub tsbCerrar_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      Close()
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      UltraGridPrintDocument1.Footer.TextRight = "Página: " + UltraGridPrintDocument1.PageNumber.ToString()
   End Sub
   Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
      TryCatched(
         Sub()
            '-.PE-31500.-
            cmbTodos.SelectedIndex = 0

            If ugDetalle.ActiveRow IsNot Nothing Then
               If Not ugDetalle.ActiveCell Is Nothing Then
                  txtBuscar.Tag = Me.ugDetalle.ActiveCell.Column.Key
               End If

            End If

            CargarMovimientos()

            If ugDetalle.Rows.Count > 0 Then
               ugDetalle.Focus()
            Else
               Cursor = Cursors.Default
               ShowMessage("NO hay registros que cumplan con la selección !!!")
               Exit Sub
            End If

         End Sub)
   End Sub

   Private Sub dpSaldoAl_ValueChanged(sender As Object, e As EventArgs) Handles dpSaldoAl.ValueChanged
      TryCatched(Sub() CargarSaldos())
   End Sub

   '-.PE-31500.-
   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
      TryCatched(
         Sub()
            Dim flack As Boolean = True
            For Each dr In ugDetalle.Rows.GetAllNonGroupByRows()
               If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then
                  flack = False
               End If

            Next
            If flack Then
               If ugDetalle.ActiveRow IsNot Nothing AndAlso ugDetalle.ActiveRow.ListObject IsNot Nothing Then
                  If ugDetalle.ActiveRow.Cells("Conciliado").Value.ToString() = "Si" Then
                     tsbConciliar.Visible = False
                     tsbDesconciliar.Visible = True
                     ToolStripSeparator10.Visible = False
                  Else
                     tsbConciliar.Visible = True
                     tsbDesconciliar.Visible = False
                     ToolStripSeparator10.Visible = False
                  End If
               End If
            End If
         End Sub)

   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
         Sub()
            If e.Row IsNot Nothing And e.Row.Cells.Exists("Conciliado") Then
               Dim color As Color = Drawing.Color.White

               If (e.Row.Cells("Conciliado").Value.ToString() = "Si") Then
                  color = Reglas.Publicos.LibroBancoColorConciliado
               ElseIf (e.Row.Cells("Conciliado").Value.ToString() = "No") Then
                  color = Reglas.Publicos.LibroBancoColorNoConciliado
               End If
               e.Row.Cells("Conciliado").Appearance.BackColor = color
               e.Row.Cells("Conciliado").ActiveAppearance.BackColor = color
               e.Row.Cells("Conciliado").ActiveAppearance.ForeColor = Drawing.Color.Black
            End If
         End Sub)
   End Sub
   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      TryCatched(Sub() tsbEditarMovimiento.PerformClick())
   End Sub

#End Region

#Region "Metodos"

   Private Sub OrdenarGrillaDetalle()

      With Me.ugDetalle.DisplayLayout.Bands(0)
         .Columns("Selec").Header.VisiblePosition = 0
         .Columns("IdCuentaBancaria").Header.VisiblePosition = 1
         .Columns("DescCuentaBancaria").Header.VisiblePosition = 2
         .Columns("NumeroMovimiento").Header.VisiblePosition = 3
         .Columns("IdCuentaBanco").Header.VisiblePosition = 4
         .Columns("NombreCuentaBanco").Header.VisiblePosition = 5
         .Columns("IdTipoMovimiento").Header.VisiblePosition = 6
         .Columns("Importe").Header.VisiblePosition = 7
         .Columns("Saldo").Header.VisiblePosition = 8
         .Columns("FechaMovimiento").Header.VisiblePosition = 9
         .Columns("FechaAplicado").Header.VisiblePosition = 10
         .Columns("Conciliado").Header.VisiblePosition = 11
         .Columns("NumeroCheque").Header.VisiblePosition = 12
         .Columns("IdBanco").Header.VisiblePosition = 13
         .Columns("DescCheque").Header.VisiblePosition = 14
         .Columns("FechaCobro").Header.VisiblePosition = 15
         .Columns("Observacion").Header.VisiblePosition = 16

         .Columns("EsModificable").Header.VisiblePosition = 17

         .Columns("DescripcionConceptoCM05").Header.VisiblePosition = 18
         .Columns("TipoConceptoCM05").Header.VisiblePosition = 19

         .Columns(Entidades.LibroBanco.Columnas.GeneraContabilidad.ToString()).Header.VisiblePosition = 20
         .Columns("IdPlanCuenta").Header.VisiblePosition = 21

         .Columns(Entidades.LibroBanco.Columnas.IdAsiento.ToString()).Hidden = True
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).Hidden = True
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Hidden = True

         .Columns(Entidades.LibroBanco.Columnas.IdAsiento.ToString()).Header.VisiblePosition = 22
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).Header.VisiblePosition = 23
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Header.VisiblePosition = 24

         If Reglas.Publicos.TieneModuloContabilidad Then
            .Columns(Entidades.LibroBanco.Columnas.IdAsiento.ToString()).Hidden = False
            If Reglas.ContabilidadPublicos.UtilizaCentroCostos Then
               .Columns(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()).Hidden = False
               .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Hidden = False
            End If
            .Columns(Entidades.LibroBanco.Columnas.GeneraContabilidad.ToString()).Hidden = False
         End If
         .Columns(Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString()).Header.VisiblePosition = 25
         .Columns(Entidades.LibroBanco.Columnas.NumeroDeposito.ToString()).Header.VisiblePosition = 26
      End With

   End Sub

   Private Sub RefrescarDatosGrilla()

      bscCuentaBancaria.FilaDevuelta = Nothing
      bscCuentaBancaria.Text = String.Empty
      bscCuentaBancaria.Enabled = True

      _idActualCuentaBancaria = 0

      txtSaldoGeneral.Text = String.Empty
      txtSaldoConciliado.Text = String.Empty

      SetearFechas()

      txtBuscar.Text = String.Empty
      txtBuscar.Tag = Nothing

      optGeneral.Checked = True

      'Me.OrdenarGrillaDetalle()

      '-.PE-31500.-
      cmbTodos.SelectedIndex = 0

      ugDetalle.ClearFilas()

      cmbConciliado.SelectedIndex = 0

      txtSaldoGeneral.Text = "0.00"
      txtSaldoConciliado.Text = "0.00"

   End Sub

   Public Sub CargarMovimientos()

      If _idActualCuentaBancaria > 0 Then

         Dim oLibroBancos = New Reglas.LibroBancos()
         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         If Not Me.txtBuscar.Tag Is Nothing And Me.txtBuscar.Text <> "" Then
            Dim bus As Entidades.Buscar = New Entidades.Buscar
            bus.Columna = Me.txtBuscar.Tag.ToString()
            bus.Valor = Me.txtBuscar.Text.Trim()
            dtDetalle = oLibroBancos.BuscarV2(bus, actual.Sucursal.Id, Me._idActualCuentaBancaria, Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, DirectCast(Me.cmbConciliado.SelectedValue, Entidades.Publicos.SiNoTodos))
         Else
            dtDetalle = oLibroBancos.GetTodos(actual.Sucursal.Id, Me._idActualCuentaBancaria, Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, Nothing, DirectCast(Me.cmbConciliado.SelectedValue, Entidades.Publicos.SiNoTodos))
         End If

         dt = Me.CrearDT()

         Dim decSaldo As Decimal = 0

         decSaldo = oLibroBancos.GetSaldo(actual.Sucursal.Id, Me._idActualCuentaBancaria, Me.dpFechaDesde.Value.AddDays(-1), IIf(Me.optGeneral.Checked, "GENERAL", "CONCILIADO").ToString())

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()
            drCl("Selec") = False
            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            drCl("IdCuentaBancaria") = Integer.Parse(dr("IdCuentaBancaria").ToString())
            drCl("DescCuentaBancaria") = dr("DescCuentaBancaria").ToString()
            drCl("NumeroMovimiento") = Integer.Parse(dr("NumeroMovimiento").ToString())
            drCl("IdCuentaBanco") = Integer.Parse(dr("IdCuentaBanco").ToString())
            drCl("NombreCuentaBanco") = dr("NombreCuentaBanco").ToString()
            drCl("IdTipoMovimiento") = dr("IdTipoMovimiento").ToString()
            drCl("Importe") = Decimal.Parse(dr("Importe").ToString())
            If Me.optGeneral.Checked Or (Me.optConciliado.Checked And dr("Conciliado").ToString.ToUpper() = "SI") Then
               decSaldo += Decimal.Parse(dr("Importe").ToString())
               drCl("Saldo") = decSaldo
            Else
               drCl("Saldo") = 0
            End If
            drCl("FechaMovimiento") = Date.Parse(dr("FechaMovimiento").ToString())
            drCl("FechaAplicado") = Date.Parse(dr("FechaAplicado").ToString())
            drCl("Conciliado") = dr("Conciliado").ToString()

            If Not String.IsNullOrEmpty(dr("NumeroCheque").ToString()) Then
               drCl(Entidades.Cheque.Columnas.IdCheque.ToString()) = dr.Field(Of Long)(Entidades.Cheque.Columnas.IdCheque.ToString())
               drCl("NumeroCheque") = Integer.Parse(dr("NumeroCheque").ToString())
               drCl("IdBanco") = Integer.Parse(dr("IdBanco").ToString())
               drCl("DescCheque") = dr("DescCheque").ToString()
               drCl("FechaCobro") = Date.Parse(dr("FechaCobro").ToString())
            End If

            'If Not String.IsNullOrEmpty(dr("IdBanco").ToString()) Then
            '   drCl("IdBanco") = Integer.Parse(dr("IdBanco").ToString())
            'End If

            drCl("Observacion") = dr("Observacion").ToString()
            'drCl("Usuario") = dr("Usuario").ToString()

            drCl("EsModificable") = dr("EsModificable")
            drCl("GeneraContabilidad") = dr("GeneraContabilidad")
            drCl("IdPlanCuenta") = dr("IdPlanCuenta")
            drCl("IdAsiento") = dr("IdAsiento")

            drCl("FechaActualizacionAsiento") = dr("FechaActualizacionAsiento")

            drCl(Entidades.LibroBanco.Columnas.IdCentroCosto.ToString()) = dr(Entidades.LibroBanco.Columnas.IdCentroCosto.ToString())
            drCl(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()) = dr(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString())

            '# Tipo de COmprobante y Nro de Deposito
            If Not IsDBNull(dr(Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString())) Then
               drCl(Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString()) = dr.Field(Of String)(Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString())
            End If
            If Not IsDBNull(dr(Entidades.LibroBanco.Columnas.NumeroDeposito.ToString())) Then
               drCl(Entidades.LibroBanco.Columnas.NumeroDeposito.ToString()) = dr.Field(Of Long?)(Entidades.LibroBanco.Columnas.NumeroDeposito.ToString())
            End If

            drCl(Entidades.LibroBanco.Columnas.IdConceptoCM05.ToString()) = dr(Entidades.LibroBanco.Columnas.IdConceptoCM05.ToString())
            drCl(Entidades.AFIPConceptoCM05.Columnas.DescripcionConceptoCM05.ToString()) = dr(Entidades.AFIPConceptoCM05.Columnas.DescripcionConceptoCM05.ToString())
            drCl(Entidades.AFIPConceptoCM05.Columnas.TipoConceptoCM05.ToString()) = dr(Entidades.AFIPConceptoCM05.Columnas.TipoConceptoCM05.ToString())

            dt.Rows.Add(drCl)

         Next

         ugDetalle.DataSource = dt

         tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

         CargarSaldos()
      End If

   End Sub
   Private Sub CargarSaldos()

      Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos
      Dim Saldo As Decimal

      Saldo = oLibroBancos.GetSaldo(actual.Sucursal.Id, Me._idActualCuentaBancaria, Me.dpSaldoAl.Value, "GENERAL")
      Me.txtSaldoGeneral.Text = Saldo.ToString("##,##0.00")

      'Saldo = oLibroBancos.GetSaldoConciliado(Me._IdActualCuentaBancaria)
      Saldo = oLibroBancos.GetSaldo(actual.Sucursal.Id, Me._idActualCuentaBancaria, Me.dpSaldoAl.Value, "CONCILIADO")
      Me.txtSaldoConciliado.Text = Saldo.ToString("##,##0.00")

   End Sub

   Private Sub SetearFechas()

      Me.dpSaldoAl.Value = Date.Now

      Me.dpFechaDesde.Value = Date.Now.AddDays(-Reglas.Publicos.DiasVisualizacionLibroBanco)
      Me.dpFechaHasta.Value = Date.Now

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Selec", GetType(Boolean))
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdCuentaBancaria", GetType(Integer))
         .Columns.Add("DescCuentaBancaria", GetType(String))
         .Columns.Add("NumeroMovimiento", GetType(Integer))
         .Columns.Add("IdCuentaBanco", GetType(Integer))
         .Columns.Add("NombreCuentaBanco", GetType(String))
         .Columns.Add("IdTipoMovimiento", GetType(String))
         .Columns.Add("Importe", GetType(Decimal))
         .Columns.Add("Saldo", GetType(Decimal))
         .Columns.Add("FechaMovimiento", GetType(Date))
         .Columns.Add("FechaAplicado", GetType(Date))
         .Columns.Add("Conciliado", GetType(String))
         .Columns.Add("IdCheque", GetType(Long))
         .Columns.Add("NumeroCheque", GetType(Integer))
         .Columns.Add("IdBanco", GetType(Integer))
         .Columns.Add("DescCheque", GetType(String))
         .Columns.Add("FechaCobro", GetType(Date))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("EsModificable", GetType(Boolean))
         .Columns.Add("GeneraContabilidad", GetType(Boolean))
         .Columns.Add("IdPlanCuenta", GetType(Integer))
         .Columns.Add("IdAsiento", GetType(Integer))
         .Columns.Add(Entidades.LibroBanco.Columnas.IdCentroCosto.ToString(), GetType(Integer))
         .Columns.Add(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString(), GetType(String))
         .Columns.Add(Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString(), GetType(String))
         .Columns.Add(Entidades.LibroBanco.Columnas.NumeroDeposito.ToString(), GetType(Long))
         .Columns.Add(Entidades.LibroBanco.Columnas.FechaActualizacionAsiento.ToString(), GetType(Date))

         .Columns.Add(Entidades.LibroBanco.Columnas.IdConceptoCM05.ToString(), GetType(Integer))
         .Columns.Add(Entidades.AFIPConceptoCM05.Columnas.DescripcionConceptoCM05.ToString(), GetType(String))
         .Columns.Add(Entidades.AFIPConceptoCM05.Columnas.TipoConceptoCM05.ToString(), GetType(String))
         '.Columns.Add("Usuario", GetType(String))
      End With

      Return dtTemp

   End Function

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(
         Sub()
            If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnum Then
               Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnum)
                  Case Reglas.Publicos.TodosEnum.MararTodos
                     MarcarDesmarcar(True, ugDetalle.Rows.ToArray())
                     cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarTodos
                     VisibilidadBotones() '-.PE-31500.- 
                  Case Reglas.Publicos.TodosEnum.DesmarcarTodos
                     MarcarDesmarcar(False, ugDetalle.Rows.ToArray())
                     cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos
                     VisibilidadBotones()
                  Case Reglas.Publicos.TodosEnum.MarcarFiltrados
                     MarcarDesmarcar(True, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                     cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarFiltrados
                     VisibilidadBotones()
                  Case Reglas.Publicos.TodosEnum.DesmarcarFiltrados
                     MarcarDesmarcar(False, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                     cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MarcarFiltrados
                     VisibilidadBotones()
                  Case Reglas.Publicos.TodosEnum.InvertirMarcasTodos
                     MarcarDesmarcar(Nothing, ugDetalle.Rows.ToArray())
                     VisibilidadBotones()
                  Case Reglas.Publicos.TodosEnum.InvertirMarcasFiltrados
                     MarcarDesmarcar(Nothing, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                     VisibilidadBotones()
                  Case Else

               End Select
            End If
         End Sub)
      ugDetalle.UpdateData()
   End Sub

   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
         If marcar.HasValue Then
            dr.Cells("Selec").Value = marcar.Value
         Else
            dr.Cells("Selec").Value = Not CBool(dr.Cells("Selec").Value)
         End If
      Next
   End Sub

   Private Sub VisibilidadBotones()
      '-.PE-31500.- 
      tsbDesconciliar.Visible = False
      tsbConciliar.Visible = False
      ugDetalle_AfterRowActivate(ugDetalle, Nothing)
      ugDetalle.DataBind()
      'Dependiendo de los registros que cargaMovimientos traiga se muestran o no los botones. Si trae registros con y sin conciliados se muestran ambos botones.
      For Each dr As UltraGridRow In Me.ugDetalle.Rows
         If Boolean.Parse(dr.Cells("Selec").Value.ToString()) Then
            If dr.Cells("Conciliado").Value.ToString() = "Si" Then
               Me.tsbDesconciliar.Visible = True
            Else
               Me.tsbConciliar.Visible = True
            End If
         End If
      Next
      ugDetalle_AfterRowActivate(ugDetalle, Nothing)
   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      TryCatched(
         Sub()
            If ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row) IsNot Nothing Then
               VisibilidadBotones()
            End If
         End Sub)
   End Sub

#End Region
End Class