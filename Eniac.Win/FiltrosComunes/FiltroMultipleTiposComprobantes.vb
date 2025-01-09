Public Class FiltroMultipleTiposComprobantes

   Private _tipo As Entidades.TipoComprobante.Tipos

   Public Sub New(nombrePantalla As String, tipo As Entidades.TipoComprobante.Tipos)
      InitializeComponent()
      Me._filtros = New List(Of Entidades.TipoComprobante)()
      Me._columnasAMostrar = New List(Of String)()
      Me._columnasAMostrar.Add("IdTipoComprobante")
      Me._columnasAMostrar.Add("Descripcion")
      Me._pathArchivo += "TiposComprobantes"
      Me._pathArchivo = Me._pathArchivo.Replace("{0}", nombrePantalla)
      Me._tipo = tipo
   End Sub

   Private _filtros As List(Of Entidades.TipoComprobante)
   Public ReadOnly Property Filtros() As List(Of Entidades.TipoComprobante)
      Get
         Return _filtros
      End Get
   End Property

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      Try
         Dim oRegla As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
         Me._publicos.PreparaGrillaTiposComprobantes(Me.bscCodigo)
         Me.bscCodigo.Datos = oRegla.GetPorCodigo(Me.bscCodigo.Text.ToString(), Me._tipo)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigo_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarTipoComprobante(e.FilaDevuelta)
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      Try
         Dim oCli As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
         Me._publicos.PreparaGrillaTiposComprobantes(Me.bscNombre)
         Me.bscNombre.Datos = oCli.GetPorDescripcion(Me.bscNombre.Text.Trim(), Me._tipo)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombre_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombre.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarTipoComprobante(e.FilaDevuelta)
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarTipoComprobante(ByVal dr As DataGridViewRow)
      Me.bscNombre.Text = dr.Cells("Descripcion").Value.ToString()
      Me.bscCodigo.Text = dr.Cells("IdTipoComprobante").Value.ToString.Trim()
   End Sub

   Private Sub btnInsertar_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.TipoComprobante = New Entidades.TipoComprobante()
         ep.IdTipoComprobante = Me.bscCodigo.Text
         ep.Descripcion = Me.bscNombre.Text
         Me._filtros.Add(ep)
         Me.RefrescoDatosGrilla()
         Me.bscCodigo.Text = ""
         Me.bscNombre.Text = ""
         Me.bscCodigo.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvDatos.ActiveCell Is Nothing And Me.dgvDatos.ActiveRow Is Nothing Then
            Exit Sub
         End If

         If Me.dgvDatos.ActiveCell Is Nothing Then
            Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
         End If

         For Each pr As Entidades.TipoComprobante In Me._filtros
            If pr.IdTipoComprobante = Me.dgvDatos.ActiveCell.Row.Cells("IdTipoComprobante").Value.ToString() Then
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

      Me.dgvDatos.DisplayLayout.Bands(0).Columns("IdTipoComprobante").Header.Caption = "Tipo Comp."
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("IdTipoComprobante").Width = 115
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción"
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("Descripcion").Width = 275

   End Sub

   Private Sub lnkRecuperarUltimo_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRecuperarUltimo.LinkClicked
      Try
         'Deserialized
         Dim fs2 As System.IO.FileStream
         Dim fila As FiltrosAdmin = New FiltrosAdmin(Me._pathArchivo, FiltrosAdmin.Estados.Recuperar)
         fila.ShowDialog()
         Dim arch As String = fila.txtNombreArchivo.Text
         If Not String.IsNullOrEmpty(arch) Then
            fs2 = New System.IO.FileStream(Me._pathArchivo + "\" + arch + ".bin", System.IO.FileMode.Open)
            Dim bf2 As System.Runtime.Serialization.Formatters.Binary.BinaryFormatter = New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Me._filtros = CType(bf2.Deserialize(fs2), List(Of Entidades.TipoComprobante))
            fs2.Close()
            Me.RefrescoDatosGrilla()
         End If
      Catch ex As Exception
         MessageBox.Show(Me.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkGrabarFiltro_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkGrabarFiltro.LinkClicked
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

   Private Sub lnkLimpiarFiltros_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLimpiarFiltros.LinkClicked
      Try
         Me._filtros.Clear()
         Me.RefrescoDatosGrilla()
      Catch ex As Exception
         MessageBox.Show(Me.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


End Class