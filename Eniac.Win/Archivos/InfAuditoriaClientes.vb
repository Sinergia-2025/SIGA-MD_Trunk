Public Class InfAuditoriaClientes

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _MostrarVendedor As Boolean

#End Region

   Protected Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente
   End Sub


#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         RefrescarDatos()

         'GAR: 25/12/2017 - hay que agregar todos los campos o cambiar la logica de diseño (vacio inicial?)

         CargaGrillaDetalle()

         FormatearGrilla()

         _publicos.CargaComboDesdeEnum(cmbTipoOperacion, GetType(Entidades.OperacionesAuditorias))
         cmbTipoOperacion.SelectedIndex = -1
         'CargaComboDesdeEnum(combo, enumArray, ordenar, valueAsString)

         'Seguridad del campo Vendedor
         Dim oUsuario = New Reglas.Usuarios()
         _MostrarVendedor = oUsuario.TienePermisos("Clientes-MostrarVendedor")

         If Not _MostrarVendedor Then
            ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = True
            'tsbPreferencias.Visible = False
         End If

         Text = String.Format("Informe de Auditoria de {0}s", ModoClienteProspecto.ToString())
         PreferenciasLeer()
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
      TryCatched(
      Sub()
         PreferenciasCargar(ugDetalle, tsbPreferencias)
         PreferenciasLeer()
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbTipoOperacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoOperacion.CheckedChanged
      TryCatched(Sub() chbTipoOperacion.FiltroCheckedChanged(cmbTipoOperacion))
   End Sub

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbCliente.Checked And Not (bscCodigoCliente.Selecciono Or bscCliente.Selecciono) Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
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

#End Region

#Region "Metodos"

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

   Private Sub RefrescarDatos()
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbMesCompleto.Checked = False
      chbCliente.Checked = False

      ugDetalle.ResetearExpandirTodos()

      ugDetalle.ClearFilas()

      btnConsultar.Focus()
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         filtro.AppendFormat("Rango de Fechas: desde el {0:dd/MM/yyyy HH:mm} hasta el {1:dd/MM/yyyy HH:mm}", dtpDesde, dtpHasta)
         If chbCliente.Checked Then
            filtro.AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text)
         End If
         If chbTipoOperacion.Checked Then
            filtro.AppendFormat(" - Tipo Operación: {0}", cmbTipoOperacion.Text)
         End If
      End With
      Return filtro.ToString()
   End Function


   Private Sub AnalizaCambiosGrilla()
      Dim row As UltraGridRow
      Dim rowBase As UltraGridRow = Nothing
      Dim i As Integer = 0

      For Each row In ugDetalle.Rows.GetRowEnumerator(GridRowType.DataRow, Nothing, Nothing)
         If i = 0 Then
            i = 1
            rowBase = row
         Else
            If Long.Parse(row.Cells("IdCliente").Value.ToString()) = Long.Parse(rowBase.Cells("IdCliente").Value.ToString()) Then
               For Each col As UltraGridCell In rowBase.Cells
                  If col.Column.Key <> "FechaAuditoria" AndAlso col.Column.Key <> "OperacionAuditoria" AndAlso col.Column.Key <> "UsuarioAuditoria" Then
                     If rowBase.Cells(col.Column).Value.ToString() <> row.Cells(col.Column).Value.ToString() Then
                        row.Cells(col.Column).Appearance.BackColor = Color.SkyBlue
                     End If
                  End If
               Next
            End If
            rowBase = row
         End If

         Select Case rowBase.Cells("OperacionAuditoria").Value.ToString()
            Case "A"
               rowBase.Cells("Modificado").Appearance.BackColor = Color.Green
            Case "M"
               rowBase.Cells("Modificado").Appearance.BackColor = Color.Yellow
            Case "B"
               rowBase.Cells("Modificado").Appearance.BackColor = Color.Red
         End Select

      Next row
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim oCliente = New Reglas.Clientes()
      Dim idCliente = If(bscCodigoCliente.Tag IsNot Nothing, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)

      Dim dtDetalle = oCliente.GetAuditoriaClientes(dtpDesde.Value, dtpHasta.Value, idCliente, cmbTipoOperacion.Text)

      ugDetalle.DataSource = dtDetalle
   End Sub

   Private Sub FormatearGrilla()
      ClientesABM.FormatearGrilla(ugDetalle, ModoClienteProspecto, _MostrarVendedor)
      PreferenciasLeer()
   End Sub

   Private Overloads Sub PreferenciasLeer()
      TryCatched(Sub() PreferenciasLeer(ugDetalle, tsbPreferencias))
   End Sub

#End Region

End Class