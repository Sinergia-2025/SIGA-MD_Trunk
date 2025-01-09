Option Strict Off

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

'Imports Eniac.Win
'Imports Eniac.Entidades
'Imports Eniac.Reglas

Imports System.Data
Imports System.IO

#End Region

Public Class SueldosConceptosPersonal

#Region "Campos"

   'Private ComprobantePago As Eniac.Reglas.TiposComprobantes = New Eniac.Reglas.TiposComprobantes
   'Private PagoNumero As Long
   Private TabGrillaConceptosSueldo As New DataSetSueldos.ConceptosPersonalDataTable, Linea As DataSetSueldos.ConceptosPersonalRow
   Private TabGrillaConceptosAguinaldo As New DataSetSueldos.ConceptosPersonalDataTable, LineaOri As DataSetSueldos.ConceptosPersonalRow

   'Private TabPagos As DataTable
   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me._publicos.CargaComboSueldosTiposRecibos(Me.cmbTipoRecibo)

      Me.CargarValoresIniciales()

      Me.tsbImprimir.Visible = False

   End Sub

#End Region

#Region "Eventos"

   Private Sub cmbTipoRecibo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoRecibo.SelectedIndexChanged
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.lblPeriodoActual.Text = DirectCast(Me.cmbTipoRecibo.SelectedItem, Entidades.SueldosTipoRecibo).PeriodoLiquidacion.ToString()
         Me.CargaGrillasConceptos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub SueldosConceptosPersonal_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.tssRegistros.Text = "" 'Me.dgvDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.dgvConceptosAguinaldo.RowCount = 0 Then Exit Sub

         Dim Filtros As String = ""

         Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         '       Filtros = "Planilla: " & Me.lblPagoNumero.Text


         dt = DirectCast(Me.dgvConceptosAguinaldo.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes

         frmImprime = New VisorReportes("Eniac.SiClub.Win.InfPagoRecibos.rdlc", "DataSetSueldos_InfPagoRecibos", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click

      Try

         'If Me.dgvConceptosSueldo.RowCount = 0 Then
         '   MessageBox.Show("No hay Conceptos de Sueldos para procesar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.bscCodigoConcepto.Focus()
         '   Exit Sub
         'End If

         If MessageBox.Show("Confirma la actualización de los datos ingresados?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Dim oMovimientos As New Reglas.SueldosPersonalCodigos

         Dim ListaDatos As New List(Of Entidades.SueldosPersonaConcepto)

         For Each Linea As DataSetSueldos.ConceptosPersonalRow In Me.TabGrillaConceptosSueldo.Rows

            Dim ObjConcepto As New Entidades.SueldosPersonaConcepto

            With ObjConcepto
               .idLegajo = Linea.idLegajo
               .idConcepto = Linea.idConcepto
               .Aguinaldo = "N"
               .idTipoConcepto = Linea.idTipoConcepto
               .Valor = Linea.Valor
               .Periodos = Linea.Periodos
               .TipoRecibo.IdTipoRecibo = Linea.IdTipoRecibo
            End With

            ListaDatos.Add(ObjConcepto)

         Next



         For Each Linea As DataSetSueldos.ConceptosPersonalRow In Me.TabGrillaConceptosAguinaldo.Rows

            Dim ObjConcepto As New Entidades.SueldosPersonaConcepto

            With ObjConcepto
               .idLegajo = Linea.idLegajo
               .idConcepto = Linea.idConcepto
               .Aguinaldo = "S"
               .idTipoConcepto = Linea.idTipoConcepto
               .Valor = Linea.Valor
               .Periodos = Linea.Periodos
               .TipoRecibo.IdTipoRecibo = Linea.IdTipoRecibo
            End With

            ListaDatos.Add(ObjConcepto)

         Next





         'TODO ESTEBAN CONTINUAR ACA
         Dim idLegajo As Integer
         idLegajo = Integer.Parse(Me.bscNroLegajo.Text)

         Dim idTipoRecibo As Integer = Int32.Parse(Me.cmbTipoRecibo.SelectedValue.ToString())

         oMovimientos.ActualizarConceptosPersonal(idLegajo, ListaDatos, idTipoRecibo)


         'For Each Linea As DataRow In Me.TabPagos.Rows

         '    ' agregar movimiento
         '    Dim RegMov As New Entidades.CuentaCorrienteSocios

         '    With RegMov
         '        .TipoComprobante = New Eniac.Entidades.TipoComprobante
         '        .TipoComprobante.IdTipoComprobante = Linea("IdTipoComprobante").ToString
         '        .NumeroComprobante = Long.Parse(Linea("NumeroComprobante").ToString)
         '        .Periodo = Integer.Parse(Linea("Periodo").ToString)
         '        .Socio = New Eniac.SiClub.Entidades.Socio
         '        .Socio.TipoDocSocio = New Eniac.Entidades.TipoDocumento
         '        .Socio.TipoDocSocio.TipoDocumento = Linea("TipoDocSocio").ToString
         '        .Socio.NroDocSocio = Long.Parse(Linea("NroDocSocio").ToString)
         '        .Fecha = Linea("Fecha")

         '        .FechaVencimiento = Linea("FechaVencimiento")
         '        .idCategoria = Integer.Parse(Linea("IdCategoria").ToString)
         '        .ImporteTotal = Decimal.Parse(Linea("ImporteTotal").ToString) * -1
         '        .Saldo = Decimal.Parse(Linea("Saldo").ToString)
         '        .Periodo2 = Integer.Parse(Linea("Periodo2").ToString)
         '        .TipoComprobante2 = Linea("IdTipoComprobante2").ToString
         '        .NumeroComprobante2 = Long.Parse(Linea("NumeroComprobante2").ToString)

         '        .Observacion = Linea("Observacion").ToString
         '        If .TipoComprobante2 = "RECIBO" Then
         '            '      .Observacion = "ALTA ANTICIPO"
         '            .Saldo = .ImporteTotal
         '        End If
         '    End With




         'actualizar saldo del movimiento (CUOTA) imputado
         'If RegMov.TipoComprobante2 = "CUOTA" Then
         '    Dim RegSaldo As New Entidades.CuentaCorrienteSocios
         '    With RegSaldo
         '        .TipoComprobante = New Eniac.Entidades.TipoComprobante
         '        .TipoComprobante.IdTipoComprobante = RegMov.TipoComprobante2
         '        .NumeroComprobante = RegMov.NumeroComprobante2
         '        .Periodo = RegMov.Periodo2
         '        .Socio = RegMov.Socio
         '        .Saldo = RegMov.Saldo
         '        .Periodo2 = .Periodo
         '        .TipoComprobante2 = .TipoComprobante.IdTipoComprobante
         '        .NumeroComprobante2 = .NumeroComprobante
         '    End With

         '    oMovimientos.ActualizaSaldo(RegSaldo)
         'End If


         'If RegMov.TipoComprobante2 <> "RECIBO" Then
         '    'si es un anticipio aplica sobre si mismo, caso contrario aplica sobre una cuota y el saldo del recibo debe ser cero
         '    RegMov.Saldo = 0
         'End If

         'oMovimientos.Insertar(RegMov)

         'Next

         'borrar arhivo transitorio
         ' Me.BorrarConceptosGrilla()
         Me.CargarValoresIniciales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub bscNroLegajo_BuscadorClick() Handles bscNroLegajo.BuscadorClick

      Dim NroDoc As Integer = -1

      Try
         Me._publicos.PreparaGrillaPersonal(Me.bscNroLegajo)
         Dim oLegajos As Reglas.SueldosPersonal = New Reglas.SueldosPersonal
         If Me.bscNroLegajo.Text.Trim.Length > 0 Then
            NroDoc = Long.Parse(Me.bscNroLegajo.Text.Trim())
         End If
         ' Me.bscNroDoc.Datos = oSocios.GetUno(NroDoc)
         Me.bscNroLegajo.Datos = oLegajos.GetFiltradoPorLegajo(NroDoc)

         ' Me.bscNroDoc.Datos = oSocios.GetUno(NroDoc)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscNroLegajo_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNroLegajo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPersonal(e.FilaDevuelta)
            Me.CargaGrillasConceptos()
            Me.bscCodigoConcepto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombrePersonal_BuscadorClick() Handles bscNombrePersonal.BuscadorClick
      Try
         Me._publicos.PreparaGrillaPersonal(Me.bscNombrePersonal)
         Dim oLegajos As Reglas.SueldosPersonal = New Reglas.SueldosPersonal

         Me.bscNombrePersonal.Datos = oLegajos.GetFiltradoPorNombre(Me.bscNombrePersonal.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombrePersonal_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombrePersonal.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosPersonal(e.FilaDevuelta)
            Me.CargaGrillasConceptos()
            Me.bscCodigoConcepto.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtImporteAPagar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorConcepto.LostFocus

      If Decimal.Parse(Me.txtValorConcepto.Text) <= 0 Or Me.bscNroLegajo.Text = "" Then Exit Sub


      'Dim Ano As Integer = Integer.Parse(Mid(Me.lblPeriodoActual.Text, 1, 4))
      'Dim Mes As Integer = Integer.Parse(Mid(Me.lblPeriodoActual.Text, 5, 2))
      'Dim FechaGen As New Date(Ano, Mes, 1)
      'Dim Periodo As Integer = FechaGen.ToString("yyyyMM")
      '' Dim Periodo As Integer = FechaGen.Year * 100 + FechaGen.Month


      '      Me.TabGrilla.Rows.Clear()

      'For Each Me.LineaOri In Me.TabGrillaLeidos.Rows

      '    Linea = TabGrilla.NewGrillaPagosRecibosRow

      '    Linea.Periodo = LineaOri.Periodo
      '    Linea.IdTipoComprobante = LineaOri.IdTipoComprobante
      '    Linea.NumeroComprobante = LineaOri.NumeroComprobante
      '    Linea.IdCategoria = LineaOri.IdCategoria
      '    Linea.NombreCategoriaSocio = LineaOri.NombreCategoriaSocio
      '    Linea.Fecha = LineaOri.Fecha
      '    Linea.FechaVencimiento = LineaOri.FechaVencimiento
      '    Linea.Importe = LineaOri.Importe
      '    Linea.Saldo = LineaOri.Saldo
      '    Linea.Paga = LineaOri.Paga

      '    TabGrilla.AddGrillaPagosRecibosRow(Linea)

      'Next

      'distribuye el pago en anticipos
      '    Dim Pago As Decimal = Decimal.Parse(Me.txtValorConcepto.Text)
      'For Each Linea As DataSetSueldos.ConceptosPersonalDataTable In Me.TabGrilla.Rows

      '    If Linea.Saldo >= Pago Then
      '        Linea.Saldo = Linea.Saldo - Pago
      '        Linea.Paga = Pago
      '        Pago = 0
      '    Else
      '        Pago = Pago - Linea.Saldo
      '        Linea.Paga = Linea.Saldo
      '        Linea.Saldo = 0

      '    End If

      '    If Pago = 0 Then Exit For
      'Next

      'If Pago > 0 Then
      '    'genera anticipo

      '    'ESTEBAN,
      '    'TOMAR EL IPORTE DE LA CUOTA Y HACER UN DO /LOOP
      '    'GENERAR UN ANTICIPO POR IMPORTE DE CUOTA
      '    'ACUMULAR EL PERIODO.
      '    'AGREGAR EL COMENTARIO AL ANTICIPO "ANTICIPO CANCELA CUOTA"
      '    Dim ImporteCuota As Decimal = Decimal.Parse(Me.lblImporteCuota.Text)
      '    Dim Linea As sue.GrillaPagosRecibosRow
      '    Dim ImporteRecibo As Decimal

      '    Do

      '        If Pago <= ImporteCuota Then
      '            ImporteRecibo = Pago
      '            Pago = 0
      '        Else
      '            ImporteRecibo = ImporteCuota
      '            Pago = Pago - ImporteCuota
      '        End If




      '        Linea = Me.TabGrilla.NewGrillaPagosRecibosRow
      '        Linea.Fecha = Today
      '        Linea.FechaVencimiento = Today
      '        Linea.IdCategoria = Me.lblCategoriaSocio.Tag
      '        Linea.NombreCategoriaSocio = Me.lblCategoriaSocio.Text
      '        Linea.IdTipoComprobante = "RECIBO"
      '        Linea.NumeroComprobante = Me.lblPagoNumero.Text
      '        Linea.Periodo = Integer.Parse(FechaGen.ToString("yyyyMM"))
      '        Linea.Importe = ImporteRecibo
      '        Linea.Saldo = ImporteRecibo
      '        Linea.Paga = ImporteRecibo
      '        If ImporteRecibo = ImporteCuota Then
      '            Linea.Observacion = "ANTICIPO CUOTA COMPLETA"
      '        Else
      '            Linea.Observacion = "ANTICIPO"
      '        End If


      '        Me.TabGrilla.AddGrillaPagosRecibosRow(Linea)

      'If Pago = 0 Then Exit Do

      'FechaGen = FechaGen.AddMonths(1)

      '   Loop




      '    End If

      '   Me.dgvDetalle.DataSource = Me.TabGrilla


   End Sub

   Private Sub btnAsgnarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarConcepto.Click

      If Not Me.bscCodigoConcepto.Selecciono And Not Me.bscNombreConcepto.Selecciono Then
         MessageBox.Show("Debe ingresar el Concepto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Me.bscCodigoConcepto.Focus()
         Exit Sub
      End If

      If Me.txtValorConcepto.Enabled = True Then
         If Decimal.Parse(Me.txtValorConcepto.Text) = 0 Then
            MessageBox.Show("Debe ingresar el valor del Concepto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtValorConcepto.Focus()
            Exit Sub
         End If
      End If

      If Decimal.Parse(Me.txtValorConcepto.Text) < 0 Then
         MessageBox.Show("El valor ingresado no puede ser negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Me.txtValorConcepto.Focus()
         Exit Sub
      End If


      ' Dim oCtaCte As New SiClub.Reglas.CuentasCorrientesSocios ', Tabla As DataTable

      ' TabGrillaConceptosSueldo

      Dim Linea As DataSetSueldos.ConceptosPersonalRow

      If RadioModoNormal.Checked Then
         Linea = TabGrillaConceptosSueldo.NewRow()
      Else
         Linea = TabGrillaConceptosAguinaldo.NewRow()
      End If


      Linea.idConcepto = Me.bscCodigoConcepto.Tag
      Linea.CodigoConcepto = Me.bscCodigoConcepto.Text
      Linea.idLegajo = bscNroLegajo.Text
      Linea.idQuePide = Me.lblModalidad.Tag
      Linea.NombreConcepto = Me.bscNombreConcepto.Text
      Linea.NombreTipoConcepto = Me.lblTipoConcepto.Text
      Linea.Valor = Me.txtValorConcepto.Text
      Linea.NombreQuePide = Me.lblModalidad.Text
      Linea.idTipoConcepto = Me.lblTipoConcepto.Tag
      Linea.Periodos = Val(Me.txtPeriodosLiquidar.Text)
      Linea.IdTipoRecibo = Int32.Parse(Me.cmbTipoRecibo.SelectedValue.ToString())
      Linea.NombreTipoRecibo = Me.cmbTipoRecibo.Text

      If RadioModoNormal.Checked Then
         TabGrillaConceptosSueldo.Rows.Add(Linea)
         dgvConceptosSueldo.DataSource = TabGrillaConceptosSueldo
         Me.btnBorrarConceptoSueldo.Enabled = True
      Else
         TabGrillaConceptosAguinaldo.Rows.Add(Linea)
         dgvConceptosAguinaldo.DataSource = TabGrillaConceptosAguinaldo
         Me.btnBorrarConceptoAguinaldo.Enabled = True
      End If

      ''graba el pago en archivos transitorios
      'For Each Linea As DataSetSueldos.GrillaPagosRecibosRow In Me.TabGrilla.Rows

      '    'agregar asignacion de datos de linea a ent
      '    If Linea.Paga = 0 Then Continue For

      '    Dim RegMov As New Entidades.CuentaCorrienteSocios
      '    RegMov.TipoComprobante = New Eniac.Entidades.TipoComprobante
      '    RegMov.TipoComprobante.IdTipoComprobante = "RECIBO"
      '    RegMov.NumeroComprobante = Me.lblPagoNumero.Text
      '    RegMov.Socio = New Entidades.Socio
      '    RegMov.Socio.TipoDocSocio = New Eniac.Entidades.TipoDocumento
      '    RegMov.Socio.TipoDocSocio.TipoDocumento = Me.cmbTipoDoc.Text
      '    RegMov.Socio.NroDocSocio = Long.Parse(Me.bscNroDoc.Text)

      '    RegMov.Periodo = Linea.Periodo
      '    RegMov.Fecha = Date.Today
      '    RegMov.FechaVencimiento = Date.Today
      '    RegMov.idCategoria = Linea.IdCategoria

      '    RegMov.ImporteTotal = Linea.Paga
      '    RegMov.Saldo = Linea.Saldo
      '    RegMov.TipoComprobante2 = Linea.IdTipoComprobante
      '    RegMov.NumeroComprobante2 = Linea.NumeroComprobante
      '    RegMov.Periodo2 = Linea.Periodo
      '    RegMov.Observacion = Linea.Observacion

      '    oCtaCte.InsertarAuxiliar(RegMov)

      'Next

      Me.LimpiarDatosConcepto()

      'Muesra la grilla de pagos grabados
      '   Me.CargarGrillaPlanillaPagos()

   End Sub

   Private Sub btnBorrarConceptoAguinaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarConceptoAguinaldo.Click

      If Me.dgvConceptosAguinaldo.RowCount = 0 Then
         MessageBox.Show("No hay conceptos para eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      If Me.dgvConceptosAguinaldo.SelectedRows.Count = 0 Then
         MessageBox.Show("No hay conceptos seleccionados para eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      Dim Eliminar As Integer
      Eliminar = Me.dgvConceptosAguinaldo.SelectedRows(0).Index
      Me.TabGrillaConceptosAguinaldo.Rows(Eliminar).Delete()

      dgvConceptosAguinaldo.DataSource = TabGrillaConceptosAguinaldo

      If Me.TabGrillaConceptosAguinaldo.Rows.Count = 0 Then
         Me.btnBorrarConceptoAguinaldo.Enabled = False
      End If

   End Sub

   Private Sub btnBorrarConceptoSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarConceptoSueldo.Click

      If Me.dgvConceptosSueldo.RowCount = 0 Then
         MessageBox.Show("No hay conceptos para eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      If Me.dgvConceptosSueldo.SelectedRows.Count = 0 Then
         MessageBox.Show("No hay conceptos seleccionados para eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      Dim Eliminar As Integer
      Eliminar = Me.dgvConceptosSueldo.SelectedRows(0).Index
      Me.TabGrillaConceptosSueldo.Rows(Eliminar).Delete()

      dgvConceptosSueldo.DataSource = TabGrillaConceptosSueldo

      If Me.TabGrillaConceptosSueldo.Rows.Count = 0 Then
         Me.btnBorrarConceptoSueldo.Enabled = False
      End If

   End Sub

   Private Sub bscCodigoConcepto_BuscadorClick() Handles bscCodigoConcepto.BuscadorClick

      Dim NroDoc As Integer = -1

      Try
         Me._publicos.PreparaGrillaSueldosConceptos(Me.bscCodigoConcepto)
         Dim oConceptos As Reglas.SueldosConceptos = New Reglas.SueldosConceptos
         If Me.bscCodigoConcepto.Text.Trim.Length > 0 Then
            NroDoc = Long.Parse(Me.bscCodigoConcepto.Text.Trim())
         End If
         ' Me.bscNroDoc.Datos = oSocios.GetUno(NroDoc)

         Dim Aguinaldo As Boolean = False
         If Me.RadioModoAguinaldo.Checked = True Then
            Aguinaldo = True
         End If

         Me.bscCodigoConcepto.Datos = oConceptos.GetPorCodigo(NroDoc, Aguinaldo)

         ' Me.bscNroDoc.Datos = oSocios.GetUno(NroDoc)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoConcepto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosConcepto(e.FilaDevuelta)
            'Me.CargaGrillasConceptos()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreConcepto_BuscadorClick() Handles bscNombreConcepto.BuscadorClick
      Try
         Me._publicos.PreparaGrillaSueldosConceptos(Me.bscNombreConcepto)
         Dim oClientes As Reglas.SueldosConceptos = New Reglas.SueldosConceptos

         Dim Aguinaldo As Boolean = False
         If Me.RadioModoAguinaldo.Checked = True Then
            Aguinaldo = True
         End If

         Me.bscNombreConcepto.Datos = oClientes.GetPorNombre(Me.bscNombreConcepto.Text.Trim(), Aguinaldo)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreConcepto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosConcepto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
      Me.LimpiarDatosConcepto()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      Me.bscNroLegajo.Text = ""
      Me.bscNroLegajo.Enabled = True
      Me.bscNombrePersonal.Text = ""
      Me.bscNombrePersonal.Enabled = True
      Me.lblCategoriaSocio.Text = ""
      Me.lblCategoriaSocio.Tag = ""
      Me.lblEstadoCivil.Text = ""

      Me.bscCodigoConcepto.Enabled = False
      Me.bscNombreConcepto.Enabled = False
      Me.txtValorConcepto.Enabled = False

      Me.TabGrillaConceptosSueldo.Rows.Clear()
      Me.TabGrillaConceptosAguinaldo.Rows.Clear()

      'Me.LimpiarDatosConcepto()

      '  Me.CargarGrillaPlanillaPagos()

      Me.bscNroLegajo.Focus()

   End Sub

   Private Sub CargarDatosPersonal(ByVal dr As DataGridViewRow)

      Me.bscNombrePersonal.Text = dr.Cells("NombrePersonal").Value.ToString()
      Me.bscNroLegajo.Text = dr.Cells("idLegajo").Value.ToString()
      Me.lblCategoriaSocio.Text = dr.Cells("NombreCategoria").Value.ToString
      Me.lblCategoriaSocio.Tag = dr.Cells("IdCategoria").Value.ToString
      Me.lblEstadoCivil.Text = dr.Cells("NombreEstadoCivil").Value.ToString
      Me.bscNombrePersonal.Enabled = False
      Me.bscNroLegajo.Enabled = False

   End Sub

   Private Sub CargarDatosConcepto(ByVal dr As DataGridViewRow)

      Me.bscNombreConcepto.Text = dr.Cells("NombreConcepto").Value.ToString()
      Me.bscNombreConcepto.Enabled = False
      Me.bscCodigoConcepto.Text = dr.Cells("CodigoConcepto").Value.ToString()
      Me.bscCodigoConcepto.Tag = dr.Cells("idConcepto").Value.ToString()

      Me.bscCodigoConcepto.Enabled = False

      Me.lblTipoConcepto.Text = dr.Cells("NombreTipoConcepto").Value.ToString
      Me.lblTipoConcepto.Tag = dr.Cells("idTipoConcepto").Value.ToString

      Me.lblModalidad.Text = dr.Cells("NombreQuePide").Value.ToString
      Me.lblModalidad.Tag = dr.Cells("idQuePide").Value.ToString
      If lblModalidad.Tag > "0" Then
         Me.txtValorConcepto.Enabled = True
         If dr.Cells("Formula").Value.ToString().Contains("CODVALOR") Then
            Me.txtValorConcepto.Text = dr.Cells("Valor").Value.ToString
         End If
      Else
         Me.txtValorConcepto.Enabled = False
      End If

      If dr.Cells("TIPO").Value.ToString = "U" Then
         Me.txtPeriodosLiquidar.Enabled = True
         Me.txtPeriodosLiquidar.Text = "1"
      Else
         Me.txtPeriodosLiquidar.Enabled = False
         Me.txtPeriodosLiquidar.Text = "0"

      End If


      Me.lblNormal_o_Aguianaldo.Tag = dr.Cells("Aguinaldo").Value.ToString
      If Me.lblNormal_o_Aguianaldo.Tag = "N" Then
         Me.lblNormal_o_Aguianaldo.Text = "NORMAL"
      Else
         Me.lblNormal_o_Aguianaldo.Text = "AGUINALDO"
      End If

      If Me.txtValorConcepto.Enabled Then
         Me.txtValorConcepto.Focus()
         Me.txtValorConcepto.SelectAll()
      Else
         Me.btnAsignarConcepto.Focus()
      End If

   End Sub

   Private Sub CargaGrillasConceptos()

      If String.IsNullOrEmpty(Me.bscNroLegajo.Text) Or Me.cmbTipoRecibo.SelectedIndex = -1 Then
         Exit Sub
      End If

      Me.bscCodigoConcepto.Enabled = True
      Me.bscNombreConcepto.Enabled = True
      Me.txtValorConcepto.Enabled = True

      Dim oSueldosConceptos As Reglas.SueldosConceptos = New Reglas.SueldosConceptos()

      Dim Tabla As DataTable

      TabGrillaConceptosSueldo.Rows.Clear()
      TabGrillaConceptosAguinaldo.Rows.Clear()

      Dim idLegajo As Integer = Integer.Parse(Me.bscNroLegajo.Text)

      Dim idTipoRecibo As Integer = Int32.Parse(Me.cmbTipoRecibo.SelectedValue.ToString())

      Tabla = oSueldosConceptos.GetConceptosPersona(idLegajo, idTipoRecibo)

      For Each Dato As DataRow In Tabla.Rows

         If Dato.Item("Aguinaldo").ToString() = "S" Then
            Linea = TabGrillaConceptosAguinaldo.NewConceptosPersonalRow
         Else
            Linea = TabGrillaConceptosSueldo.NewConceptosPersonalRow
         End If

         Linea.idLegajo = Dato.Item("idLegajo")
         Linea.CodigoConcepto = Dato.Item("CodigoConcepto")
         Linea.idConcepto = Dato.Item("idConcepto")
         Linea.NombreConcepto = Dato.Item("NombreConcepto")
         Linea.NombreTipoConcepto = Dato.Item("NombreTipoConcepto")
         Linea.idTipoConcepto = Dato.Item("IdTipoConcepto")
         Linea.idQuePide = Dato.Item("idQuePide")
         Linea.NombreQuePide = Dato.Item("NombreQuePide")
         Linea.Valor = Dato.Item("Valor")
         Linea.Periodos = Integer.Parse(Dato.Item("Periodos").ToString)
         Linea.IdTipoRecibo = Dato.Item("IdTipoRecibo").ToString()
         Linea.NombreTipoRecibo = Dato.Item("NombreTipoRecibo")

         If Dato.Item("Aguinaldo").ToString = "S" Then
            TabGrillaConceptosAguinaldo.AddConceptosPersonalRow(Linea)
         Else
            TabGrillaConceptosSueldo.AddConceptosPersonalRow(Linea)
         End If

      Next

      Me.dgvConceptosAguinaldo.DataSource = TabGrillaConceptosAguinaldo
      Me.dgvConceptosSueldo.DataSource = TabGrillaConceptosSueldo

      Me.btnBorrarConceptoSueldo.Enabled = (Me.TabGrillaConceptosSueldo.Rows.Count > 0)

      Me.btnBorrarConceptoAguinaldo.Enabled = (Me.TabGrillaConceptosAguinaldo.Rows.Count > 0)

      Me.txtValorConcepto.Focus()
      Me.txtValorConcepto.SelectAll()

      'busca el pago entre los transitorios y configura los botones.

      'Tabla = oCtaCte.GetPorRangoFechas(0, DateAdd(DateInterval.Year, -1, DateTime.Today), DateTime.Today, Me.cmbTipoDoc.Text, _
      '                                  Long.Parse(Me.bscNroDoc.Text), , , , , , , , True)

      'If Tabla.Rows.Count > 0 Then
      '    Me.txtValorConcepto.Enabled = False
      '    Me.btnAsgnarConcepto.Enabled = False
      '    Me.btnBorrarConceptoSueldo.Enabled = True
      '    MessageBox.Show("El Socio Tiene Pagos Asignados en este Recibo, solo puede eliminarlos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      'Else
      '    Me.txtValorConcepto.Enabled = True
      '    Me.btnAsgnarConcepto.Enabled = True
      '    Me.btnBorrarConceptoSueldo.Enabled = False
      'End If

      Me.LimpiarDatosConcepto()

   End Sub

   Private Sub LimpiarDatosConcepto()
      Me.bscCodigoConcepto.Text = ""
      Me.bscCodigoConcepto.Enabled = True
      Me.bscNombreConcepto.Text = ""
      Me.bscNombreConcepto.Tag = ""
      Me.bscNombreConcepto.Enabled = True
      Me.lblTipoConcepto.Text = ""
      Me.lblModalidad.Text = ""
      Me.txtPeriodosLiquidar.Text = ""
      Me.txtValorConcepto.Text = "0.00"
      Me.lblNormal_o_Aguianaldo.Text = ""
      Me.txtValorConcepto.Enabled = True
      Me.btnAsignarConcepto.Enabled = True
      ' Me.btnBorrarConceptoSueldo.Enabled = False
      Me.bscCodigoConcepto.Focus()
   End Sub

#End Region

   Private Sub PresionarTab(ByVal e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then
         Me.ProcessTabKey(True)
      End If
   End Sub

   'Private Sub txtValorConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValorConcepto.KeyPress
   '   If Keys.Enter Then
   '      Me.btnAsignarConcepto.Focus()
   '   End If
   'End Sub

   Private Sub txtValorConcepto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValorConcepto.KeyDown
      If e.KeyCode = Keys.Enter Then
         Me.btnAsignarConcepto.Focus()
      End If
   End Sub

   Private Sub dgvConceptosSueldo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConceptosSueldo.CellContentClick
      Me.CargarConceptoCompleto(Me.dgvConceptosSueldo.Rows(e.RowIndex))

      Dim Eliminar As Integer
      Eliminar = Me.dgvConceptosSueldo.SelectedRows(0).Index
      Me.TabGrillaConceptosSueldo.Rows(Eliminar).Delete()

      dgvConceptosSueldo.DataSource = TabGrillaConceptosSueldo
   End Sub

   Private Sub CargarConceptoCompleto(ByVal dr As DataGridViewRow)
      Me.bscCodigoConcepto.Text = dr.Cells("CodigoConcepto").Value.ToString()
      Me.bscNombreConcepto.Text = dr.Cells("grsNombreConcepto").Value.ToString()
      Me.bscCodigoConcepto.PresionarBoton()
      Me.txtValorConcepto.Text = dr.Cells("grsValor").Value.ToString()

   End Sub
End Class