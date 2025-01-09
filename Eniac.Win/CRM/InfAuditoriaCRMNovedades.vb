Public Class InfAuditoriaCRMNovedades
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Private Property TipoNovedad As Entidades.CRMTipoNovedad = Nothing
   Private _cacheSemaforo As List(Of Entidades.SemaforoVentaUtilidad)

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         _cacheSemaforo = New Reglas.SemaforoVentasUtilidades().GetTodos(Entidades.SemaforoVentaUtilidad.TiposSemaforos.ESTRELLAS)

         '# Cargar Combos
         _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad)
         If TipoNovedad IsNot Nothing Then cmbTipoNovedad.SelectedValue = TipoNovedad.IdTipoNovedad

         RefrescarDatos()

         CargaGrillaDetalle()

         _publicos.CargaComboDesdeEnum(cmbTipoOperacion, GetType(Entidades.OperacionesAuditorias))
         cmbTipoOperacion.SelectedIndex = -1
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
#Region "Eventos Toolbox"
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

#Region "Eventos Eventos"
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(Sub() chbFecha.FiltroCheckedChanged(chbMesCompleto, dtpDesde, dtpHasta))
   End Sub
   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbTipoOperacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoOperacion.CheckedChanged
      TryCatched(Sub() chbTipoOperacion.FiltroCheckedChanged(cmbTipoOperacion))
   End Sub
   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(Sub() chbNumero.FiltroCheckedChanged(txtNumero))
   End Sub
#End Region
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbNumero.Checked And txtNumero.Text = "0" Then
            ShowMessage("ATENCION: No ingreso un número de Novedad aunque activó ese Filtro.")
            Exit Sub
         End If

         CargaGrillaDetalle()
         AnalizaCambiosGrilla()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub
   'Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
   '   TryCatched(Sub() CRMNovedadesABM.InitializeRow(e.Row, TipoNovedad, _cacheSemaforo))
   'End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatos()
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbMesCompleto.Checked = False
      ugDetalle.ClearFilas()
      btnConsultar.Focus()
   End Sub
   Private Sub CargaGrillaDetalle()
      Dim idNovedad = If(chbNumero.Checked, txtNumero.ValorNumericoPorDefecto(0L), 0L)

      Dim rNovedades = New Reglas.CRMNovedades()
      Dim dt = rNovedades.GetAuditoriaCRMNovedades(dtpDesde.Valor(chbFecha), dtpHasta.Valor(chbFecha), TipoNovedad.IdTipoNovedad, idNovedad, cmbTipoOperacion.Text)

      ugDetalle.DataSource = dt
      FormatearGrilla()
   End Sub
   Private Sub AnalizaCambiosGrilla()
      Dim row As UltraGridRow
      Dim rowBase As UltraGridRow = Nothing
      Dim i As Integer = 0

      For Each row In Me.ugDetalle.Rows.GetRowEnumerator(GridRowType.DataRow, Nothing, Nothing)
         If i = 0 Then
            i = 1
            rowBase = row
         Else
            If row.Cells("IdTipoNovedad").Value.ToString() = rowBase.Cells("IdTipoNovedad").Value.ToString() AndAlso
               row.Cells("Letra").Value.ToString() = rowBase.Cells("Letra").Value.ToString() AndAlso
               Long.Parse(row.Cells("CentroEmisor").Value.ToString()) = Long.Parse(rowBase.Cells("CentroEmisor").Value.ToString()) AndAlso
               Long.Parse(row.Cells("IdNovedad").Value.ToString()) = Long.Parse(rowBase.Cells("IdNovedad").Value.ToString()) Then
               For Each col As UltraGridCell In rowBase.Cells
                  Try
                     If col.Column.Key <> "FechaAuditoria" AndAlso col.Column.Key <> "OperacionAuditoria" AndAlso col.Column.Key <> "UsuarioAuditoria" Then
                        row.Cells(col.Column).Tag = Nothing
                        If rowBase.Cells(col.Column).Value Is Nothing And row.Cells(col.Column).Value IsNot Nothing Then
                           row.Cells(col.Column).Color(Nothing, Color.SkyBlue)
                           row.Cells(col.Column).Tag = Color.SkyBlue
                        ElseIf rowBase.Cells(col.Column).Value IsNot Nothing And row.Cells(col.Column).Value Is Nothing Then
                           row.Cells(col.Column).Color(Nothing, Color.SkyBlue)
                           row.Cells(col.Column).Tag = Color.SkyBlue
                        ElseIf rowBase.Cells(col.Column).Value IsNot Nothing And row.Cells(col.Column).Value IsNot Nothing Then
                           If rowBase.Cells(col.Column).Value.ToString() <> row.Cells(col.Column).Value.ToString() Then
                              row.Cells(col.Column).Color(Nothing, Color.SkyBlue)
                              row.Cells(col.Column).Tag = Color.SkyBlue
                           End If
                        End If
                     End If
                  Catch ex As Exception
                     Throw
                  End Try
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
   Private Sub FormatearGrilla()
      Dim pos As Integer = 0

      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("FechaAuditoria").FormatearColumna("Fecha/Hora Auditoría", pos, 100, HAlign.Center, hidden:=True, Formatos.Format.FechaCompleta)
         .Columns("FechaAuditoria_Fecha").FormatearColumna("Fecha Auditoría", pos, 100, HAlign.Center, , Formatos.Format.FechaSinHora)
         .Columns("FechaAuditoria_Hora").FormatearColumna("Hora Auditoría", pos, 100, HAlign.Center, , Formatos.Format.HoraSinFecha)
         .Columns("OperacionAuditoria").FormatearColumna("Operación Auditoría", pos, 50, HAlign.Center)
         .Columns("UsuarioAuditoria").FormatearColumna("Usuario Auditoría", pos, 120, HAlign.Left)
      End With

      CRMNovedadesABM.FormatearGrilla(ugDetalle, TipoNovedad, pos)

   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Novedad: {0}", cmbTipoNovedad.Text)
         If chbFecha.Checked Then
            .AppendFormat(" - Fecha: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)
         End If
         If chbTipoOperacion.Checked Then
            .AppendFormat(" - Tipo Operación: {0}", cmbTipoOperacion.Text)
         End If
         If chbNumero.Checked Then
            .AppendFormat(" - Número: {0}", txtNumero.Text)
         End If
      End With
      Return filtro.ToString()
   End Function
#End Region

#Region "IConParametros"
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      If String.IsNullOrEmpty(parametros) Then Throw New Exception("No se ha especificado un Tipo de Novedad para la función.")
      Dim rNovedad = New Reglas.CRMTiposNovedades()
      TipoNovedad = rNovedad.GetUno(parametros)
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function
#End Region

End Class