Public Class InfAuditoriaProductos

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() PreferenciasLeer(ugDetalle, tsbPreferencias))
      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(Sub() RefrescarDatos())

      CargaGrillaDetalle()

      FormatearGrilla()

      PreferenciasLeer()

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
      TryCatched(Sub() RefrescarDatos())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
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

#Region "Eventos Filtros"
   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

#Region "Eventos Buscador Producto"

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2))
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProducto.Checked And Not (bscCodigoProducto2.Selecciono Or bscProducto2.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If

         ugDetalle.ResetearExpandirTodos()

         CargaGrillaDetalle()

         AnalizaCambiosGrilla()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      TryCatched(
      Sub()
         e.Layout.SelectionOverlayColor = SystemColors.Highlight
         With e.Layout.Bands(0)
            .Override.SelectedAppearancesEnabled = DefaultableBoolean.False
            .Override.ActiveAppearancesEnabled = DefaultableBoolean.False
         End With
      End Sub)
   End Sub
   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            Dim color As Color
            Select Case dr.Field(Of String)("OperacionAuditoria")
               Case "A"
                  color = Color.Green
               Case "M"
                  color = Color.Yellow
               Case "B"
                  color = Color.Red
            End Select
            e.Row.Cells("Modificado").Color(color, color)
         End If
      End Sub)
   End Sub

#End Region


#End Region

#Region "Metodos"

   Private Sub RefrescarDatos()
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbMesCompleto.Checked = False
      chbProducto.Checked = False

      ugDetalle.ResetearExpandirTodos()

      ugDetalle.ClearFilas()

      btnConsultar.Focus()
   End Sub

   Private Sub AnalizaCambiosGrilla()
      Dim rowBase As UltraGridRow = Nothing
      Dim i = 0I
      For Each row In ugDetalle.Rows.OfType(Of UltraGridRow)
         If i = 0 Then
            i = 1
            rowBase = row
         Else
            If row.Cells("IdProducto").Value.ToString() = rowBase.Cells("IdProducto").Value.ToString() Then
               For Each col In rowBase.Cells.OfType(Of UltraGridCell)
                  If col.Column.Key <> "FechaAuditoria" AndAlso col.Column.Key <> "OperacionAuditoria" AndAlso col.Column.Key <> "UsuarioAuditoria" Then
                     If rowBase.Cells(col.Column).Value.ToString() <> row.Cells(col.Column).Value.ToString() Then
                        row.Cells(col.Column).Appearance.BackColor = Color.SkyBlue
                     End If
                  End If
               Next
            End If
            rowBase = row
         End If
      Next row
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty)

      Dim rProducto = New Reglas.Productos()
      Dim dtDetalle = rProducto.GetAuditoriaProductos(dtpDesde.Value, dtpHasta.Value, idProducto)

      ugDetalle.DataSource = dtDetalle

      '  FormatearGrilla()
   End Sub

   Private Sub FormatearGrilla()
      ProductosABM.FormatearGrilla(ugDetalle, auditoria:=True)
   End Sub
   Private Overloads Sub PreferenciasLeer()
      TryCatched(Sub() PreferenciasLeer(ugDetalle, tsbPreferencias))
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

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)
         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto2.Text, bscProducto2.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

#End Region

End Class