Public Class ResumenAnualDeCaja

#Region "Propiedades"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         cmbSucursal.Initializar(False, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         LoadComboAnio()
         InicializaCajas()

         ugDetalle.AgregarTotalesSuma({"Total", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
         ugDetalle.AgregarFiltroEnLinea({"NombreCuentaCaja"})

         RefrescarDatosGrilla()

         PreferenciasLeer(ugDetalle, tsbPreferencias)

      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimirPrediseñado_Click(sender As Object, e As EventArgs) Handles tsbImprimirPrediseñado.Click
      TryCatched(
      Sub()
         If ugDetalle.Count = 0 Then
            Exit Sub
         End If

         Dim dt = ugDetalle.DataSource(Of DataTable)

         Dim parm = New ReportParameterCollection()
         parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresa)
         parm.Add("NombreSucursal", actual.Sucursal.Nombre)
         parm.Add("Filtros", CargarFiltrosImpresion())

         Dim frmImprime = New VisorReportes("Eniac.Win.ResumenAnualDeCaja.rdlc", "DataSetCaja_ResumenCorporativoDeCaja", dt, parm, True, 1) '# 1 = Cantidad de Copias

         frmImprime.Text = Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      End Sub)
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      TryCatched(Sub() InicializaCajas())
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(Sub() CargaGrillaDetalle())
   End Sub

#End Region

#Region "Metodos"

   Private Sub LoadComboAnio()
      Dim oCajas = New Reglas.Cajas()
      cmbAnios.DataSource = oCajas.GetAniosDePlanillas(actual.Sucursal.Id)
      cmbAnios.ValueMember = "Anio"
      cmbAnios.DisplayMember = "Anio"

      cmbAnios.SelectedValue = -1
   End Sub

   Private Sub InicializaCajas()
      cmbCajas.Inicializar(cmbSucursal.GetSucursales(), blnMiraUsuario:=True, blnMiraPC:=False, blnCajasModificables:=False, permiteSinSeleccion:=False)
   End Sub
   Private Sub RefrescarDatosGrilla()
      cmbSucursal.Refrescar()
      cmbAnios.SelectedIndex = -1
      cmbCajas.Refrescar()
      rdbFechaMovimiento.Checked = True
      optPesosDolares.Checked = True
      cmbSucursal.Focus()
      ugDetalle.ClearFilas()

   End Sub
   Private Sub CargaGrillaDetalle()
      If cmbAnios.SelectedIndex = -1 Then
         ShowMessage("ATENCION: NO seleccionó un Año")
         cmbAnios.Focus()
         Exit Sub
      End If

      If cmbCajas.SelectedIndex = -1 Then
         ShowMessage("ATENCION: NO seleccionó una Caja")
         cmbCajas.Focus()
         Exit Sub
      End If

      Dim tipoMoneda = If(optPesosDolares.Checked, "PESOSYDOLARES", If(optPesos.Checked, "PESOS", "DOLARES"))

      Dim rCajaDetalles = New Reglas.CajaDetalles()
      Dim dt = rCajaDetalles.ResumenAnual(cmbSucursal.GetSucursales(), cmbCajas.GetCajas(), Integer.Parse(cmbAnios.Text), rdbFechaMovimiento.Checked, tipoMoneda)

      ugDetalle.DataSource = dt
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, False, True)

         .AppendFormat(" - Año: {0}", cmbAnios.Text)
         .AppendFormat(" - Fecha de: {0} - ", If(rdbFechaMovimiento.Checked, "Movimiento", "Planilla"))

         cmbCajas.CargarFiltrosImpresionCajaNombres(filtro, False, True)

         If optPesosDolares.Checked Then
            .AppendFormat(" - Monedas: Pesos y Dolares Convertidos")
         ElseIf optPesos.Checked Then
            .AppendFormat(" - Monedas: Solo Pesos")
         ElseIf optDolares.Checked Then
            .AppendFormat(" - Monedas: Solo Dolares")
         End If
      End With

      Return filtro.ToString()
   End Function
#End Region

End Class