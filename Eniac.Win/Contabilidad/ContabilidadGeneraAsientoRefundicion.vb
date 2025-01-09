Public Class ContabilidadGeneraAsientoRefundicion

#Region "Campos"

   Private _publicosContabilidad As ContabilidadPublicos
   Private _publicos As Publicos
   Private _utilizaCentroCostos As Boolean = False

#End Region


#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         _publicosContabilidad = New ContabilidadPublicos()
         _publicos = New Publicos()

         _publicosContabilidad.CargaComboContabilidadEjerciciosAbiertos(cmbEjercicio)
         _publicosContabilidad.CargaComboPlanes(cmbPlan, False)
         _publicosContabilidad.CargarSucursalesACheckListBox(clbSucursales)
         _publicos.CargaComboCentroCostos(cmbCentroCosto)

         _utilizaCentroCostos = Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos

         cmbCentroCosto.Visible = _utilizaCentroCostos
         cmbCentroCosto.LabelAsoc.Visible = _utilizaCentroCostos

         If cmbEjercicio.Items.Count = 0 Then
            MessageBox.Show("No existen Ejercicios abiertos!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Question)
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugAsientoRef, tsbPreferencias))
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(Sub() ConsultarAsientos())
   End Sub

   Private Sub bscCodCuenta_BuscadorClick() Handles bscCodCuenta.BuscadorClick
      TryCatched(
        Sub()
           _publicosContabilidad.PreparaGrillaCuentas(bscCodCuenta)
           bscCodCuenta.Datos = New Reglas.ContabilidadCuentas().GetCuentasImputablesXTipo(Entidades.ContabilidadCuenta.TipoCuentaContable.PATRIMONIO, bscCodCuenta.Text.ValorNumericoPorDefecto(0L))
        End Sub)
   End Sub

   Private Sub bscCodCuenta_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodCuenta.BuscadorSeleccion
      TryCatched(
        Sub()
           If Not e.FilaDevuelta Is Nothing Then
              bscDescripcion.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
              bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()
           End If
        End Sub)
   End Sub

   Private Sub bscDescripcion_BuscadorClick() Handles bscDescripcion.BuscadorClick
      TryCatched(
        Sub()
           _publicosContabilidad.PreparaGrillaCuentas(bscDescripcion)
           bscDescripcion.Datos = New Reglas.ContabilidadCuentas().GetCuentasImputablesXTipo(Entidades.ContabilidadCuenta.TipoCuentaContable.PATRIMONIO, bscDescripcion.Text.Trim())
        End Sub)
   End Sub

   Private Sub bscDescripcion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscDescripcion.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               bscDescripcion.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
               bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()
            End If
         End Sub)
   End Sub

   Private Sub btnGenerarAsiento_Click(sender As Object, e As EventArgs) Handles btnGenerarAsiento.Click
      TryCatched(
         Sub()

            If Not String.IsNullOrEmpty(bscCodCuenta.Text) Then
               _cta.IdCuenta = Int32.Parse(bscCodCuenta.Text)
            Else
               MessageBox.Show("Debe seleccionar una cuenta.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               bscCodCuenta.Focus()
               Return
            End If

            If cmbCentroCosto.SelectedValue Is Nothing Then
               MessageBox.Show("Debe seleccionar un Centro de Costo.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               cmbCentroCosto.Focus()
               Return
            End If

            If MessageBox.Show(String.Format("¿Esta seguro de generar el Asiento de Refundición de Resultado con fecha {0}?", dtpFecha.Value.ToString("dd/MM/yyyy")), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
               Return
            End If

            'ARMO el asiento para luego enviar a generarlo

            Dim asiento As Entidades.ContabilidadAsiento
            Dim rgAsiento As Reglas.ContabilidadAsientos
            rgAsiento = New Reglas.ContabilidadAsientos()

            asiento = New Entidades.ContabilidadAsiento()
            asiento.FechaAsiento = dtpFecha.Value
            asiento.NombreAsiento = txtConcepto.Text
            asiento.IdEjercicio = Int32.Parse(cmbEjercicio.SelectedValue.ToString())
            asiento.IdPlanCuenta = Int32.Parse(cmbPlan.SelectedValue.ToString())
            asiento.IdSucursal = actual.Sucursal.Id
            asiento.SubsiAsiento = Entidades.ContabilidadProceso.Procesos.MANUALES.ToString()
            asiento.EsManual = False
            asiento.IdEstadoAsiento = 1
            asiento.TipoAsiento = Entidades.ContabilidadAsiento.TiposAsiento.REFUNDICIONDERESULTADOS.ToString()
            asiento.IdAsiento = rgAsiento.GetIdMaximo(asiento.IdEjercicio, asiento.IdPlanCuenta) + 1

            Dim dtAsientoCuentas As DataTable = DirectCast(ugAsientoRef.DataSource, DataTable)

            asiento.DetallesAsiento = GetDtAsiento(dtAsientoCuentas)

            rgAsiento.Insertar(asiento)

            MessageBox.Show("Se ha generado el Asiento por Refundición de Resultados!!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            tsbRefrescar.PerformClick()

         End Sub)
   End Sub

   Private Function GetDtAsiento(dt As DataTable) As DataTable

      Dim dr As DataRow = dt.NewRow()
      dr("IdCentroCosto") = cmbCentroCosto.SelectedValue.ToString()
      If _cta.EnHaber Then
         dr("Haber") = _cta.ValorDiferencia
         dr("Debe") = 0
      Else
         dr("Haber") = 0
         dr("Debe") = _cta.ValorDiferencia
      End If
      dr("IdCuenta") = _cta.IdCuenta
      dt.Rows.Add(dr)

      Return dt
   End Function

   Private Sub cmbEjercicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEjercicio.SelectedIndexChanged
      TryCatched(
         Sub()
            dtpFecha.Value = DirectCast(cmbEjercicio.SelectedItem, Entidades.ContabilidadEjercicio).FechaHasta
            txtConcepto.Text = String.Format("Refundición de Resultados del ejercicio <{0}>", cmbEjercicio.Text.Replace("- Abierto", ""))
         End Sub)
   End Sub

#End Region

   Private Sub RefrescarDatosGrilla()
      ugAsientoRef.ClearFilas()
      lblMonto.Text = ""
      btnGenerarAsiento.Enabled = False

   End Sub

   Private Sub ConsultarAsientos()
      Dim reg As Reglas.ContabilidadProcesos
      reg = New Reglas.ContabilidadProcesos()

      Dim idEjercicio = Int32.Parse(cmbEjercicio.SelectedValue.ToString())
      Dim idPlanCuenta = Int32.Parse(cmbPlan.SelectedValue.ToString())
      Dim sucursales As List(Of Integer) = New List(Of Integer)()

      For Each s As Entidades.Sucursal In clbSucursales.CheckedItems
         sucursales.Add(s.Id)
      Next

      Dim dt As DataTable

      dt = reg.GetAsientoRefundicion(idEjercicio, sucursales, idPlanCuenta)

      'cargo la grilla con los datos obtenidos
      ugAsientoRef.DataSource = dt
      If dt.Count > 0 Then
         ConfiguroGrillaPeriodos()
      End If

      _cta = New Cta()

      'saco valor del Monto para la cuenta de resultados
      For Each dr As DataRow In dt.Rows
         _cta.Debe += Decimal.Parse(dr("Debe").ToString())
         _cta.Haber += Decimal.Parse(dr("Haber").ToString())
      Next
      If _cta.Debe = _cta.Haber Then
         MessageBox.Show("El debe coincide con el haber.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         btnGenerarAsiento.Enabled = False
      Else
         btnGenerarAsiento.Enabled = True
      End If
      lblMonto.Text = _cta.ToString()

   End Sub

   Private _cta As Cta

   Private Sub ConfiguroGrillaPeriodos()
      For Each band As Infragistics.Win.UltraWinGrid.UltraGridBand In ugAsientoRef.DisplayLayout.Bands
         For Each column As Infragistics.Win.UltraWinGrid.UltraGridColumn In band.Columns
            column.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
         Next
      Next

      ugAsientoRef.Column("IdCuenta").Header.Caption = "Id Cuenta"
      ugAsientoRef.Column("IdCuenta").Width = 90

      ugAsientoRef.Column("NombreCuenta").Header.Caption = "Cuenta"
      ugAsientoRef.Column("NombreCuenta").Width = 200

      ugAsientoRef.Column("IdCentroCosto").Hidden = True
      ugAsientoRef.Column("IdTipoReferencia").Hidden = True
      ugAsientoRef.Column("Referencia").Hidden = True

      ugAsientoRef.Column("NombreCentroCosto").Header.Caption = "Centro de Costo"

      ugAsientoRef.Column("Debe").FormatearColumna("Debe", 6, 130, HAlign.Right, False, "#,##0.00")
      ugAsientoRef.Column("Haber").FormatearColumna("Haber", 7, 130, HAlign.Right, False, "#,##0.00")

      Dim band2 As Infragistics.Win.UltraWinGrid.UltraGridBand = ugAsientoRef.DisplayLayout.Bands(0)
      If Not band2.Summaries.Exists("TotalDebe") Then
         Dim totalDebe As SummarySettings = band2.Summaries.Add("TotalDebe", Infragistics.Win.UltraWinGrid.SummaryType.Sum, band2.Columns("Debe"))
         totalDebe.DisplayFormat = "Debe: {0:#,##0.00}"
         totalDebe.Appearance.TextHAlign = Infragistics.Win.HAlign.Right

         Dim totalHaber As SummarySettings = band2.Summaries.Add("TotalHaber", Infragistics.Win.UltraWinGrid.SummaryType.Sum, band2.Columns("Haber"))
         totalHaber.DisplayFormat = "Haber: {0:#,##0.00}"
         totalHaber.Appearance.TextHAlign = Infragistics.Win.HAlign.Right

         ' Mostrar sumario en la parte inferior del grid
         band2.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False
         band2.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      End If

      ugAsientoRef.Refresh()
   End Sub

   Private Class Cta
      Private _debe As Decimal
      Public Property Debe() As Decimal
         Get
            Return _debe
         End Get
         Set(ByVal value As Decimal)
            _debe = value
         End Set
      End Property
      Private _haber As Decimal
      Public Property Haber() As Decimal
         Get
            Return _haber
         End Get
         Set(ByVal value As Decimal)
            _haber = value
         End Set
      End Property

      Public ReadOnly Property EnHaber() As Boolean
         Get
            Return (Debe > Haber)
         End Get
      End Property

      Public ReadOnly Property ValorDiferencia As Decimal
         Get
            If EnHaber Then
               Return Debe - Haber
            Else
               Return Haber - Debe
            End If
         End Get
      End Property

      Private _idCuenta As Integer
      Public Property IdCuenta() As Integer
         Get
            Return _idCuenta
         End Get
         Set(ByVal value As Integer)
            _idCuenta = value
         End Set
      End Property

      Public Overrides Function ToString() As String
         If EnHaber Then
            Return String.Format("Haber: {0:###,##0.00}", ValorDiferencia)
         Else
            Return String.Format("Debe: {0:###,##0.00}", ValorDiferencia)
         End If
      End Function
   End Class

   Private Sub tsmiExportarExcel_Click(sender As Object, e As EventArgs) Handles tsmiExportarExcel.Click
      TryCatched(Sub() ugAsientoRef.Exportar(UltraGridExcelExporter1, ""))
   End Sub
End Class