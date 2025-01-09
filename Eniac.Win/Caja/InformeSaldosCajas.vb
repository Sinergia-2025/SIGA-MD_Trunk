Public Class InformeSaldosCajas
#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         cmbSucursal.Initializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, IdFuncion)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         ugDetalle.AgregarTotalesSuma({"ImportePesos", "ImporteDolares", "ImporteEuros",
                                       "ImporteCheques", "ImporteTarjetas", "ImporteTickets",
                                       "ImporteBancos", "ImporteRetenciones", "ImporteBancosDolares"})

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         InicializaCajas()

         ugDetalle.DisplayLayout.Bands(0).Columns("NombreSucursal").Hidden = Not cmbSucursal.Enabled
         ugDetalle.AgregarFiltroEnLinea({})

         RefrescarDatosGrilla()
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
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
      TryCatched(
      Sub()
         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub
#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()
      cmbSucursal.Refrescar()
      cmbCajas.Refrescar()
      chbSoloConSaldos.Checked = True

      'Limpio la Grilla.
      ugDetalle.ClearFilas()

      cmbSucursal.Focus()
   End Sub
   Private Sub CargaGrillaDetalle()
      Dim rCajas = New Reglas.Cajas()
      Dim dtDetalle = rCajas.GetConsultaSaldosDeCaja(cmbSucursal.GetSucursales(), cmbCajas.GetCajas(True), Me.chbSoloConSaldos.Checked)
      ugDetalle.DataSource = dtDetalle
   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=True, muestraNombre:=False)
         cmbCajas.CargarFiltrosImpresionCajaNombres(filtro, muestraId:=False, muestraNombre:=True)
      End With
      Return filtro.ToString()
   End Function
   Private Sub InicializaCajas()
      cmbCajas.Inicializar(cmbSucursal.GetSucursales(), blnMiraUsuario:=False, blnMiraPC:=False, blnCajasModificables:=False)
   End Sub
#End Region
End Class