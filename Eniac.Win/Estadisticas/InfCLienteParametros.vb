Public Class InfCLienteParametros

#Region "Campos"

   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         ugDetalle.AgregarFiltroEnLinea({"IdParametro", "NombreCliente", "NombreDeFantasia", "ValorParametro", "DescripcionParametro"})
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         _tit = GetColumnasVisiblesGrilla(ugDetalle)
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
      TryCatched(
      Sub()
         PreferenciasCargar(ugDetalle, tsbPreferencias)
         _tit = GetColumnasVisiblesGrilla(ugDetalle)
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region
#Region "Eventos Buscador Parametros"
   'PE-31248 -jc- -
   Private Sub chbParametro_CheckedChanged(sender As Object, e As EventArgs) Handles chbParametro.CheckedChanged
      TryCatched(Sub() chbParametro.FiltroCheckedChanged(usaPermitido:=True, bscCodParametro, bscParametro))
   End Sub

   Private Sub bscCodParametro_BuscadorClick() Handles bscCodParametro.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaParametros2(bscCodParametro)
         bscCodParametro.Datos = New Reglas.Parametros().GetPorCodigo(actual.Sucursal.IdEmpresa, bscCodParametro.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscParametro_BuscadorClick() Handles bscParametro.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaParametros2(bscParametro)
         bscParametro.Datos = New Reglas.Parametros().GetPorCodigo(actual.Sucursal.IdEmpresa, bscParametro.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodParametro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodParametro.BuscadorSeleccion, bscParametro.BuscadorSeleccion
      TryCatched(Sub() CargarDatosParametro(e.FilaDevuelta))
   End Sub
#End Region

#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()

         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         'PE-31248
         If chbParametro.Checked And Not bscParametro.Selecciono And Not bscCodParametro.Selecciono Then
            MessageBox.Show("ATENCION: No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            bscParametro.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)

   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()
      chbCliente.Checked = False
      chbParametro.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idCliente = If(chbCliente.Checked, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), 0L)
      Dim idParametro = If(chbParametro.Checked, bscCodParametro.Tag.ToString(), String.Empty)

      Dim rClientes = New Reglas.ClientesParametros()
      Dim dtDetalle = rClientes.GetInfClienteParametros(idCliente, idParametro)

      ugDetalle.DataSource = dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         If chbCliente.Checked Then
            .AppendFormat("Cliente: {0} - {1} - ", bscCodigoCliente.Text, bscCliente.Text)
         End If
         If chbParametro.Checked Then
            .AppendFormat("Parametro: {0} - {1} - ", bscCodParametro.Text, bscParametro.Text)
         End If
      End With
      Return filtro.ToString.Trim().Trim("-"c).Trim()
   End Function

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

   'PE-31248 -jc- -
   Private Sub CargarDatosParametro(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscParametro.Text = dr.Cells("DescripcionParametro").Value.ToString()
         bscCodParametro.Text = dr.Cells("IdParametro").Value.ToString()
         bscCodParametro.Tag = dr.Cells("IdParametro").Value.ToString()
         bscParametro.Permitido = False
         bscCodParametro.Permitido = False
         btnConsultar.Focus()
      End If
   End Sub

#End Region

End Class