Public Class MFTipoModelo

   Public Const TipoFiltroKey As String = "TIPOCOMPROBANTES"

#Region "Campos"
   Private _filtros As List(Of Entidades.ProductoModeloTipo)
   Public ReadOnly Property Filtros() As List(Of Entidades.ProductoModeloTipo)
      Get
         Return _filtros
      End Get
   End Property


#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(permiteSinSeleccion:=True)
   End Sub

   Public Sub New(permiteSinSeleccion As Boolean)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.ProductoModeloTipo)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdTipoComprobante")
      _columnasAMostrar.Add("Descripcion")
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Me.dgvDatos.DataSource = Me._filtros.ToArray()

      With dgvDatos.DisplayLayout.Bands(0)
         For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In .Columns
            col.Hidden = True
         Next

         .Columns("IdProductoModeloTipo").Hidden = False
         .Columns("IdProductoModeloTipo").Header.Caption = "Código"
         .Columns("IdProductoModeloTipo").Width = 125
         .Columns("IdProductoModeloTipo").CellAppearance.TextHAlign = HAlign.Left

         .Columns("NombreProductoModeloTipo").Hidden = False
         .Columns("NombreProductoModeloTipo").Header.Caption = "Nombre"
         .Columns("NombreProductoModeloTipo").Width = 275

      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodos()
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodos() As List(Of Entidades.ProductoModeloTipo)
      Dim reg As Reglas.ProductosModelosTipos = New Reglas.ProductosModelosTipos()
      Return reg.GetTodos()
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.ProductoModeloTipo
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As System.Collections.Generic.IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.ProductoModeloTipo()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdProductoModeloTipo"
                  ma.IdProductoModeloTipo = Integer.Parse(c.Valor.ToString())
               Case "NombreProductoModeloTipo"
                  ma.NombreProductoModeloTipo = c.Valor
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
            _publicos.PreparaGrillaTiposComprobantes(bscCodigo)
            'Me.bscCodigo.Datos = New Reglas.ProductosModelosTipos().GetPorCodigo(bscCodigo.Text)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaTiposComprobantes(bscNombre)
            bscNombre.Datos = New Reglas.ProductosModelosTipos().GetPorNombre(bscNombre.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarTipoComprobante(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.ProductoModeloTipo = New Entidades.ProductoModeloTipo()
         ep.IdProductoModeloTipo = Integer.Parse(Me.bscCodigo.Text.ToString())
         ep.NombreProductoModeloTipo = Me.bscNombre.Text
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

         For Each pr As Entidades.ProductoModeloTipo In Me._filtros
            If pr.IdProductoModeloTipo = Integer.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdTipoComprobante").Value.ToString()) Then
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

   Private Sub CargarTipoComprobante(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("Descripcion").Value.ToString()
         bscCodigo.Text = dr.Cells("IdTipoComprobante").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class