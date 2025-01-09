Public Class FiltroMultipleLocalidades

   Public Sub New(ByVal nombrePantalla As String)
      InitializeComponent()
      Me._filtros = New List(Of Entidades.Localidad)()
      Me._columnasAMostrar = New List(Of String)()
      Me._columnasAMostrar.Add("IdLocalidad")
      Me._columnasAMostrar.Add("NombreLocalidad")
      Me._pathArchivo += "Localidades"
      Me._pathArchivo = Me._pathArchivo.Replace("{0}", nombrePantalla)
   End Sub

   Private _filtros As List(Of Entidades.Localidad)
   Public ReadOnly Property Filtros() As List(Of Entidades.Localidad)
      Get
         Return _filtros
      End Get
   End Property

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      Try
         Dim oRegla As Reglas.Localidades = New Reglas.Localidades()
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigo)
         Dim cod As Integer = 0
         Int32.TryParse(Me.bscCodigo.Text.ToString(), cod)
         Me.bscCodigo.Datos = oRegla.GetPorCodigo(cod)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigo_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      Try
         Dim oCli As Reglas.Localidades = New Reglas.Localidades()
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombre)
         Me.bscNombre.Datos = oCli.GetPorNombre(Me.bscNombre.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombre_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombre.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)
      Me.bscNombre.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.bscCodigo.Text = dr.Cells("IdLocalidad").Value.ToString.Trim()
   End Sub

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.Localidad = New Entidades.Localidad()
         ep.IdLocalidad = Int32.Parse(Me.bscCodigo.Text)
         ep.NombreLocalidad = Me.bscNombre.Text
         Me._filtros.Add(ep)
         Me.RefrescoDatosGrilla()
         Me.bscCodigo.Text = ""
         Me.bscNombre.Text = ""
         Me.bscCodigo.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvDatos.ActiveCell Is Nothing And Me.dgvDatos.ActiveRow Is Nothing Then
            Exit Sub
         End If

         If Me.dgvDatos.ActiveCell Is Nothing Then
            Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
         End If

         For Each pr As Entidades.Localidad In Me._filtros
            If pr.IdLocalidad = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdLocalidad").Value.ToString()) Then
               Me._filtros.Remove(pr)
               Exit For
            End If
         Next
         Me.RefrescoDatosGrilla()
         Me.bscCodigo.Text = ""
         Me.bscNombre.Text = ""
         Me.bscCodigo.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()

      For Each cl As UltraWinGrid.UltraGridColumn In Me.dgvDatos.DisplayLayout.Bands(0).Columns
         If Not Me._columnasAMostrar.Contains(cl.Key) Then
            cl.Hidden = True
         End If
      Next

      Me.dgvDatos.DisplayLayout.Bands(0).Columns("IdLocalidad").Header.Caption = "Código"
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("IdLocalidad").Width = 115
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("NombreLocalidad").Header.Caption = "Localidad"
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("NombreLocalidad").Width = 275

   End Sub

   Private Sub lnkRecuperarUltimo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRecuperarUltimo.LinkClicked
      Try
         'Deserialized
         Dim fs2 As System.IO.FileStream
         Dim fila As FiltrosAdmin = New FiltrosAdmin(Me._pathArchivo, FiltrosAdmin.Estados.Recuperar)
         fila.ShowDialog()
         Dim arch As String = fila.txtNombreArchivo.Text
         If Not String.IsNullOrEmpty(arch) Then
            fs2 = New System.IO.FileStream(Me._pathArchivo + "\" + arch + ".bin", System.IO.FileMode.Open)
            Dim bf2 As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Me._filtros = CType(bf2.Deserialize(fs2), List(Of Entidades.Localidad))
            fs2.Close()
            Me.RefrescoDatosGrilla()
         End If
      Catch ex As Exception
         MessageBox.Show(Me.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkGrabarFiltro_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkGrabarFiltro.LinkClicked
      Try
         'Serialized
         Dim fila As FiltrosAdmin = New FiltrosAdmin(Me._pathArchivo, FiltrosAdmin.Estados.Grabar)
         fila.ShowDialog()
         Dim arch As String = fila.txtNombreArchivo.Text
         If Not String.IsNullOrEmpty(arch) Then
            Dim fs As System.IO.FileStream = New System.IO.FileStream(Me._pathArchivo + "\" + arch + ".bin", System.IO.FileMode.Create)
            Dim bf As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            bf.Serialize(fs, Me._filtros)
            fs.Close()
            MessageBox.Show("Filtro guardado satisfactoriamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(Me.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkLimpiarFiltros_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLimpiarFiltros.LinkClicked
      Try
         Me._filtros.Clear()
         Me.RefrescoDatosGrilla()
      Catch ex As Exception
         MessageBox.Show(Me.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


End Class