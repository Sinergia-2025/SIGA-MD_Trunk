Imports actual = Eniac.Entidades.Usuario.Actual

Public Class FiltroMultipleProductos

   Protected _publicos As Publicos
   Protected _columnasAMostrar As List(Of String)
   Protected _pathArchivo As String = "C:\Eniac\Filtros\{0}\"

   Public Sub New(nombrePantalla As String)
      InitializeComponent()
      Me._productosFiltrados = New List(Of Entidades.Producto)()
      Me._columnasAMostrar = New List(Of String)()
      Me._columnasAMostrar.Add("IdProducto")
      Me._columnasAMostrar.Add("NombreProducto")
      Me._pathArchivo += "Productos\"
      Me._pathArchivo = Me._pathArchivo.Replace("{0}", nombrePantalla)
   End Sub

   Private _productosFiltrados As List(Of Entidades.Producto)
   Public ReadOnly Property ProductosFiltrados() As List(Of Entidades.Producto)
      Get
         Return _productosFiltrados
      End Get
   End Property

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

   End Sub

   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos()
         Me._publicos.PreparaGrillaProductos(Me.bscCodigoProducto)
         Me.bscCodigoProducto.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, 0, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos(Me.bscProducto)
         Me.bscProducto.Datos = oProductos.GetPorNombre(Me.bscProducto.Text.Trim(), actual.Sucursal.Id, 0, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
   End Sub

   Private Sub btnInsertar_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigoProducto.Selecciono Or Me.bscProducto.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.Producto = New Entidades.Producto()
         ep.IdProducto = Me.bscCodigoProducto.Text
         ep.NombreProducto = Me.bscProducto.Text
         Me._productosFiltrados.Add(ep)
         Me.RefrescoDatosGrilla()
         Me.bscCodigoProducto.Text = ""
         Me.bscProducto.Text = ""
         Me.bscCodigoProducto.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
      Me.Close()
   End Sub

   Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvProductos.ActiveCell Is Nothing And Me.dgvProductos.ActiveRow Is Nothing Then
            Exit Sub
         End If

         If Me.dgvProductos.ActiveCell Is Nothing Then
            Me.dgvProductos.ActiveCell = Me.dgvProductos.ActiveRow.Cells(0)
         End If

         For Each pr As Entidades.Producto In Me._productosFiltrados
            If pr.IdProducto = Me.dgvProductos.ActiveCell.Row.Cells("idproducto").Value.ToString() Then
               Me._productosFiltrados.Remove(pr)
               Exit For
            End If
         Next
         Me.RefrescoDatosGrilla()
         Me.bscCodigoProducto.Text = ""
         Me.bscProducto.Text = ""
         Me.bscCodigoProducto.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Sub RefrescoDatosGrilla()
      Me.dgvProductos.DataSource = Me._productosFiltrados.ToArray()

      For Each cl As UltraWinGrid.UltraGridColumn In Me.dgvProductos.DisplayLayout.Bands(0).Columns
         If Not Me._columnasAMostrar.Contains(cl.Key) Then
            cl.Hidden = True
         End If
      Next

      Me.dgvProductos.DisplayLayout.Bands(0).Columns("IdProducto").Header.Caption = "Código"
      Me.dgvProductos.DisplayLayout.Bands(0).Columns("IdProducto").Width = 115
      Me.dgvProductos.DisplayLayout.Bands(0).Columns("NombreProducto").Header.Caption = "Producto"
      Me.dgvProductos.DisplayLayout.Bands(0).Columns("NombreProducto").Width = 275

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
            Me._productosFiltrados = CType(bf2.Deserialize(fs2), List(Of Entidades.Producto))
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
            bf.Serialize(fs, Me._productosFiltrados)
            fs.Close()
            MessageBox.Show("Filtro guardado satisfactoriamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(Me.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkLimpiarFiltros_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLimpiarFiltros.LinkClicked
      Try
         Me._productosFiltrados.Clear()
         Me.RefrescoDatosGrilla()
      Catch ex As Exception
         MessageBox.Show(Me.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class