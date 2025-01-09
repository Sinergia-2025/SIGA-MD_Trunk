#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Public Class FilterManagerSelector
      Private _tit As Dictionary(Of String, String)
      Private _panelFiltro As Controles.IPanel
      Private _filtroSeleccionado As Entidades.FilterManager.FuncionFiltro
      Public ReadOnly Property FiltroSeleccionado As Entidades.FilterManager.FuncionFiltro
         Get
            Return _filtroSeleccionado
         End Get
      End Property

      Public Sub New()
         ' This call is required by the designer.
         InitializeComponent()
         ' Add any initialization after the InitializeComponent() call.
      End Sub
      Public Sub New(idFuncion As String, filtroSeleccionado As Entidades.FilterManager.FuncionFiltro, panelFiltro As Controles.IPanel)
         Me.New()
         Me.IdFuncion = idFuncion
         Me._filtroSeleccionado = filtroSeleccionado
         Me._panelFiltro = panelFiltro
      End Sub

      Protected Overrides Sub OnShown(e As EventArgs)
         Try
            _tit = GetColumnasVisiblesGrilla(ugFiltros)
         Catch ex As Exception
            ShowError(ex)
         End Try
         MyBase.OnShown(e)
         Try
            CargaGrillaDetalle()
         Catch ex As Exception
            ShowError(ex)
         End Try
      End Sub

      Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
         Select Case keyData
            Case Keys.Escape
               btnCancelar.PerformClick()
               Return True
            Case Keys.F4
               btnAceptar.PerformClick()
               Return True

         End Select

         Return MyBase.ProcessCmdKey(msg, keyData)
      End Function

      Private Sub CargaGrillaDetalle()
         Dim ds = FilterManagerHandler.Instancia.GetTodos(IdFuncion)
         ugFiltros.DataSource = ds
         AjustarColumnasGrilla(ugFiltros, _tit)

         Dim bm = ugFiltros.BindingContext(ugFiltros.DataSource, ugFiltros.DataMember)
         bm.Position = ds.IndexOf(_filtroSeleccionado)

         btnAceptar.Enabled = ugFiltros.ActiveRow IsNot Nothing
      End Sub



      Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
         TryCatched(
         Sub()
            Dim dr = ugFiltros.FilaSeleccionada(Of Entidades.FilterManager.FuncionFiltro)()
            If dr IsNot Nothing Then
               _filtroSeleccionado = dr
               Close(DialogResult.OK)
            Else
               ShowMessage("No seleccionó ningún filtro para aplicar")
            End If
         End Sub)
      End Sub

      Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
         TryCatched(Sub() Close(DialogResult.Cancel))
      End Sub

      Private Sub ugFiltros_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugFiltros.InitializeRow
         TryCatched(
         Sub()
            Dim dr = ugFiltros.FilaSeleccionada(Of Entidades.FilterManager.FuncionFiltro)(e.Row)
            If dr IsNot Nothing Then
               If dr.PorDefecto Then
                  e.Row.Cells("PorDefectoResuelto").Appearance.BackColor = Color.LightGreen
                  e.Row.Cells("PorDefectoResuelto").ActiveAppearance.BackColor = Color.LightGreen
                  e.Row.Cells("PorDefectoResuelto").Appearance.ForeColor = Color.Black
                  e.Row.Cells("PorDefectoResuelto").ActiveAppearance.ForeColor = Color.Black
               Else
                  e.Row.Cells("PorDefectoResuelto").Appearance.BackColor = Nothing
                  e.Row.Cells("PorDefectoResuelto").ActiveAppearance.BackColor = Nothing
                  e.Row.Cells("PorDefectoResuelto").Appearance.ForeColor = Nothing
                  e.Row.Cells("PorDefectoResuelto").ActiveAppearance.ForeColor = Nothing
               End If
            End If
         End Sub)
      End Sub
      Private Sub ugFiltros_AfterRowActivate(sender As Object, e As EventArgs) Handles ugFiltros.AfterRowActivate
         TryCatched(Sub() btnAceptar.Enabled = ugFiltros.ActiveRow IsNot Nothing)
      End Sub
      Private Sub ugFiltros_DoubleClickRow(sender As Object, e As UltraWinGrid.DoubleClickRowEventArgs) Handles ugFiltros.DoubleClickRow
         TryCatched(Sub() btnAceptar.PerformClick())
      End Sub

      Private Sub mnuRefrescar_Click(sender As Object, e As EventArgs) Handles mnuRefrescar.Click
         TryCatched(Sub() CargaGrillaDetalle())
      End Sub
      Private Sub mnuNuevo_Click(sender As Object, e As EventArgs) Handles mnuNuevo.Click
         TryCatched(
         Sub()
            Using frm = New FilterManagerSelectorDetalle(_panelFiltro, IdFuncion)
               If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                  CargaGrillaDetalle()
               End If
            End Using
         End Sub)
      End Sub
      Private Sub mnuEliminar_Click(sender As Object, e As EventArgs) Handles mnuEliminar.Click
         TryCatched(
         Sub()
            Dim dr = ugFiltros.FilaSeleccionada(Of Entidades.FilterManager.FuncionFiltro)()
            If dr IsNot Nothing Then
               If ShowPregunta(String.Format("¿Desea eliminar el filtro {0}?", dr.NombreFiltro)) = Windows.Forms.DialogResult.Yes Then
                  FilterManagerHandler.Instancia.Eliminar(dr)
                  CargaGrillaDetalle()
               End If
            End If
         End Sub)
      End Sub
      Private Sub mnuCambiarSoloUsuario_Click(sender As Object, e As EventArgs) Handles mnuCambiarSoloUsuario.Click
         TryCatched(Sub() FilterManagerHandler.Instancia.CambiarSoloUsuario(ugFiltros.FilaSeleccionada(Of Entidades.FilterManager.FuncionFiltro)(), AddressOf CargaGrillaDetalle))
      End Sub
      Private Sub mnuCambiarTodosLosUsuario_Click(sender As Object, e As EventArgs) Handles mnuCambiarTodosLosUsuario.Click
         TryCatched(Sub() FilterManagerHandler.Instancia.CambiarTodosLosUsuario(ugFiltros.FilaSeleccionada(Of Entidades.FilterManager.FuncionFiltro)(), AddressOf CargaGrillaDetalle))
      End Sub
      Private Sub mnuEliminarFiltroDefectoUsuario_Click(sender As Object, e As EventArgs) Handles mnuEliminarFiltroDefectoUsuario.Click
         TryCatched(
         Sub()
            If ShowPregunta(String.Format("Esta acción elimina la configuración de filtro por defecto del usuario ({1}).{0}{0}¿Desea continuar?",
                                          Environment.NewLine, actual.Nombre)) = Windows.Forms.DialogResult.Yes Then
               FilterManagerHandler.Instancia.EliminarFiltroDefectoUsuario(ugFiltros.FilaSeleccionada(Of Entidades.FilterManager.FuncionFiltro)(), AddressOf CargaGrillaDetalle)
            End If
         End Sub)
      End Sub
   End Class
End Namespace