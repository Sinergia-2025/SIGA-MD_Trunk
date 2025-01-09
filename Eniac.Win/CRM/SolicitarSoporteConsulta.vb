Public Class SolicitarSoporteConsulta


#Region "Campos"

   Private _publicos As Publicos
   Private _cargando As Boolean = True

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         ugDetalle.AgregarFiltroEnLinea({"Descripcion", "Comentarios"})

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
      TryCatched(Sub() ugDetalle.Imprimir(String.Empty, New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, String.Empty))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, String.Empty))
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
         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         PreferenciasLeer(ugDetalle, tsbPreferencias)
         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of Entidades.JSonEntidades.Gestion.Soporte.Ticket)()
         If dr IsNot Nothing Then
            If dr.ColorCategoriaNovedad.HasValue Then
               e.Row.Cells("NombreCategoriaNovedad").Color(Nothing, dr.ColorCategoriaNovedad.ToArgbColor())
            End If
            If dr.ColorEstadoNovedad.HasValue Then
               e.Row.Cells("NombreEstadoNovedad").Color(Nothing, dr.ColorEstadoNovedad.ToArgbColor())
            End If
         End If
      End Sub)
   End Sub


#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()
      chkExpandAll.Checked = False
      ugDetalle.ClearFilas()
      ugDetalle.Rows.Refresh(RefreshRow.ReloadData)
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim dt = New Reglas.ServiciosRest.Gestion.SincronizarGestion().GetNovedads(String.Empty)

      ugDetalle.DataSource = dt

   End Sub

#End Region




End Class