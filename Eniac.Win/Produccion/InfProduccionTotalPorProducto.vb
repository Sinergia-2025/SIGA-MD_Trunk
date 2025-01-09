Public Class InfProduccionTotalPorProducto

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            cmbMarcas.Inicializar()
            cmbRubros.Inicializar()

            Refrescar()

            ugDetalle.AgregarTotalesSuma({"Cantidad"})
            ugDetalle.AgregarFiltroEnLinea({"NombreProducto"})
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

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() Refrescar())
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

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2))
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
            bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
         End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscProducto2)
            bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
         End Sub)
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbProducto.Checked And Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
               bscCodigoProducto2.Focus()
               Exit Sub
            End If

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               chkExpandAll.Checked = True
               btnConsultar.Focus()
            Else
               ShowMessage("NO hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#End Region

#Region "Metodos"

   Private Sub Refrescar()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbProducto.Checked = False

      cmbMarcas.Refrescar()
      cmbRubros.Refrescar()

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      dtpDesde.Focus()

   End Sub

   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Permitido = False
         bscCodigoProducto2.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text.Trim(), String.Empty)

      Dim regla = New Reglas.ProduccionProductos()
      Dim dtDetalle = regla.GetTotalPorProducto(actual.Sucursal.IdSucursal, dtpDesde.Value, dtpHasta.Value,
                                                idProducto, cmbMarcas.GetMarcas(), cmbRubros.GetRubros())

      ugDetalle.DataSource = dtDetalle
   End Sub


   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", dtpDesde.Text, dtpHasta.Text)

         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If

         cmbMarcas.CargarFiltrosImpresionMarcas(filtro, muestraId:=False, muestraNombre:=True)
         cmbRubros.CargarFiltrosImpresionRubros(filtro, muestraId:=False, muestraNombre:=True)
      End With

      Return filtro.ToString()

   End Function

#End Region

End Class