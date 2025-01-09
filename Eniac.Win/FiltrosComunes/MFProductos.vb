Public Class MFProductos

#Region "Campos"

   Private _filtros As List(Of Entidades.Producto)
   Public ReadOnly Property Filtros() As List(Of Entidades.Producto)
      Get
         Return _filtros
      End Get
   End Property

#End Region

#Region "Constructores"

   Public Sub New()
      MyBase.New(permiteSinSeleccion:=True)
      InitializeComponent()
      _tipoFiltro = "PRODUCTOS"
      _filtros = New List(Of Entidades.Producto)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdProducto")
      _columnasAMostrar.Add("NombreProducto")

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      dgvDatos.DataSource = _filtros.ToArray()

      With dgvDatos.DisplayLayout.Bands(0)
         For Each col In .Columns.OfType(Of UltraGridColumn)
            col.Hidden = True
         Next

         Dim pos = 0I
         .Columns("IdProducto").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Nombre", pos, 340)
      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      Dim reg As Reglas.Productos = New Reglas.Productos()
      Me._filtros = reg.GetTodos()
      Me.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.Producto
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.Producto()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdProducto"
                  ma.IdProducto = c.Valor
               Case "NombreProducto"
                  ma.NombreProducto = c.Valor
            End Select
         Next
         Me.Filtros.Add(ma)
         i += 1
         col = From filt In filtros Where filt.IdRegistro = i
      End While
   End Sub

   Protected Overrides Sub LimpiarFiltros()
      Me._filtros.Clear()
      Me.RefrescoDatosGrilla()
   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscCodigo)
            bscCodigo.Datos = New Reglas.Productos().GetPorCodigo(bscCodigo.Text.ToString(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProductos2(bscNombre)
            bscNombre.Datos = New Reglas.Productos().GetPorNombre(bscNombre.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarProducto(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.Producto = New Entidades.Producto()
         ep.IdProducto = bscCodigo.Text
         ep.NombreProducto = Me.bscNombre.Text
         Me._filtros.Add(ep)
         Me.RefrescoDatosGrilla()
         Me.bscCodigo.Text = ""
         Me.bscNombre.Text = ""
         Me.bscCodigo.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvDatos.ActiveCell Is Nothing And Me.dgvDatos.ActiveRow Is Nothing Then
            Exit Sub
         End If

         If Me.dgvDatos.ActiveCell Is Nothing Then
            Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
         End If

         For Each pr As Entidades.Producto In Me._filtros
            If pr.IdProducto = dgvDatos.ActiveCell.Row.Cells("IdProducto").Value.ToString() Then
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

#End Region

#Region "Metodos"

   Private Sub CargarProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigo.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class