Public Class BaseFiltrosAdmin

   Private _tieneArchivos As Boolean = False
   Private _tipoFiltro As String

   Public Enum Estados
      Recuperar
      Grabar
   End Enum

   Public Sub New(ByVal tipoFiltro As String, ByVal estado As Estados)
      InitializeComponent()

      _tipoFiltro = tipoFiltro

      CargaLista()

      If estado = Estados.Grabar Then
         Me._tieneArchivos = True
         Me.Text = "Grabar Filtros"
         Me.btnOk.Text = "Grabar"
         Me.txtNombreArchivo.Focus()
      Else
         Me._tieneArchivos = (Me.lsvFiltros.Items.Count > 0)
         Me.txtNombreArchivo.Enabled = False
         Me.Text = "Recuperar Filtros"
         Me.btnOk.Text = "Recuperar"
         Me.lsvFiltros.Focus()
      End If


   End Sub

   Private Sub CargaLista()
      Dim regFV As Reglas.FiltrosValores = New Reglas.FiltrosValores()
      Dim archivos() As String = regFV.GetNombreFiltros(_tipoFiltro)

      lsvFiltros.Items.Clear()
      For Each arc As String In archivos
         Me.lsvFiltros.Items.Add(New ListViewItem(arc))
      Next
      Me.lsvFiltros.View = View.List
   End Sub

   Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
      Me.Close()
   End Sub

   Private Sub FiltrosAdmin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
      If Not Me._tieneArchivos Then
         Me.Close()
      End If
   End Sub

   Private Sub lsvFiltros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvFiltros.SelectedIndexChanged
      If Me.lsvFiltros.SelectedItems.Count > 0 Then
         Me.txtNombreArchivo.Text = Me.lsvFiltros.SelectedItems(0).Text
      End If
   End Sub

   Private Sub FiltrosAdmin_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Escape Then
         Me.txtNombreArchivo.Text = ""
         Me.Close()
      End If
   End Sub

   Private Sub lsvFiltros_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvFiltros.ItemActivate
      Me.btnOk.PerformClick()
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.lsvFiltros.SelectedItems.Count > 0 Then
            If ShowPregunta("¿Desea eliminar el filtro seleccionado?") = Windows.Forms.DialogResult.Yes Then
               Dim reg As Reglas.FiltrosValores = New Reglas.FiltrosValores()
               reg.BorraFiltros(Me._tipoFiltro, Me.lsvFiltros.SelectedItems(0).Text)
               CargaLista()
               txtNombreArchivo.Text = String.Empty
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class