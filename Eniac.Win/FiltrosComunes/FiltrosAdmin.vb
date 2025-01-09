Public Class FiltrosAdmin

   Private _tieneArchivos As Boolean = False

   Public Enum Estados
      Recuperar
      Grabar
   End Enum

   Public Sub New(pathOrigen As String, estado As Estados)
      InitializeComponent()

      If Not System.IO.Directory.Exists(pathOrigen) Then
         System.IO.Directory.CreateDirectory(pathOrigen)
      End If

      Dim archivos() As String = System.IO.Directory.GetFiles(pathOrigen)
      Dim archi As String

      For Each arc As String In archivos
         archi = System.IO.Path.GetFileNameWithoutExtension(arc)
         Me.lsvFiltros.Items.Add(New ListViewItem(archi))
      Next
      Me.lsvFiltros.View = View.List

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

   Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
      If Me.txtNombreArchivo.Text.Contains(".") Then
         MessageBox.Show("El nombre del archivo es sin extensión.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.txtNombreArchivo.Focus()
         Exit Sub
      End If
      Me.Close()
   End Sub

   Private Sub FiltrosAdmin_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
      If Not Me._tieneArchivos Then
         Me.Close()
      End If
   End Sub

   Private Sub lsvFiltros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvFiltros.SelectedIndexChanged
      If Me.lsvFiltros.SelectedItems.Count > 0 Then
         Me.txtNombreArchivo.Text = Me.lsvFiltros.SelectedItems(0).Text
      End If
   End Sub

   Private Sub FiltrosAdmin_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.Escape Then
         Me.txtNombreArchivo.Text = ""
         Me.Close()
      End If
   End Sub

   Private Sub lsvFiltros_ItemActivate(sender As System.Object, e As System.EventArgs) Handles lsvFiltros.ItemActivate
      Me.btnOk.PerformClick()
   End Sub

End Class