Public Class CRMClientesGestion

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            RefrescarDatosGrilla()
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
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
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True}))
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCliente.Checked AndAlso Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
               ShowMessage("Debe seleccionar un cliente.")
               bscCodigoCliente.Select()
               Exit Sub
            End If

            CargaGrillaDetalle()
         End Sub)
   End Sub

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, busquedaParcial:=True, soloActivos:=False)
         End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes(bscCliente)
            bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), soloActivos:=False)
         End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub
#End Region

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()
      chbCliente.Checked = False
      chkMesCompleto.Checked = False
      bscCliente.Text = String.Empty
      bscCodigoCliente.Text = String.Empty

      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today

      ugDetalle.ClearFilas()
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Public Sub CargaGrillaDetalle()
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)

      Dim rCRM = New Reglas.CRMNovedades()
      Dim result = rCRM.GetClientesGestion(idCliente, dtpDesde.Value, dtpHasta.Value)

      ugDetalle.DataSource = result.Datos

      FormatearGrilla(result)

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub FormatearGrilla(result As Reglas.CRMNovedades.GetClientesGestionResult)

      With ugDetalle.DisplayLayout.Bands(0)
         .Groups.OfType(Of UltraGridGroup).Where(Function(g) g.Key <> "General").ToList().ForEach(Sub(g) .Groups.Remove(g.Key))

         For i = 0 To result.Periodos.Count - 1
            Dim p = result.Periodos(i)
            Dim grp = New UltraGridGroup()
            grp.Key = String.Format("Mes_{0}", p)
            grp.Header.Caption = p.Insert(4, "-"c)
            grp.Header.Appearance.TextHAlign = HAlign.Center
            .Groups.Add(grp)
            grp.Columns.Add(.Columns(result.PeriodosCantidad(i)).FormatearColumna("Cantidad", 100 + (i * 2), 70, HAlign.Right, , "N0"))
            grp.Columns.Add(.Columns(result.PeriodosHoras(i)).FormatearColumna("Horas", 100 + (i * 2) + 1, 70, HAlign.Right, , "N2"))
         Next

         Dim totales = New List(Of String)()
         totales.AddRange(result.PeriodosCantidad)
         totales.AddRange(result.PeriodosHoras)
         ugDetalle.AgregarTotalesSuma(totales.ToArray())
         ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})
      End With

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)

         If chbCliente.Checked Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If

      End With
      Return filtro.ToString()
   End Function

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

      bscCliente.Permitido = False
      bscCodigoCliente.Permitido = False

      btnConsultar.Select()
   End Sub
#End Region

End Class