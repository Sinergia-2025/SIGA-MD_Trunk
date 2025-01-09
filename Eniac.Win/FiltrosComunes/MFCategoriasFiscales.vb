Public Class MFCategoriasFiscales

   Public Const TipoFiltroKey As String = "CATEGORIAS"

#Region "Campos"
   Private _filtros As List(Of Entidades.CategoriaFiscal)
   Public ReadOnly Property Filtros() As List(Of Entidades.CategoriaFiscal)
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
      _filtros = New List(Of Entidades.CategoriaFiscal)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add(Entidades.CategoriaFiscal.Columnas.IdCategoriaFiscal.ToString())
      _columnasAMostrar.Add(Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString())
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            dgvDatos.DataSource = _filtros.ToArray()

            dgvDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
            With dgvDatos.DisplayLayout.Bands(0)
               For Each col In .Columns.OfType(Of UltraGridColumn)
                  col.Hidden = True
               Next

               .Columns(Entidades.CategoriaFiscal.Columnas.IdCategoriaFiscal.ToString()).Hidden = False
               .Columns(Entidades.CategoriaFiscal.Columnas.IdCategoriaFiscal.ToString()).Header.Caption = "Código"
               .Columns(Entidades.CategoriaFiscal.Columnas.IdCategoriaFiscal.ToString()).Width = 50
               .Columns(Entidades.CategoriaFiscal.Columnas.IdCategoriaFiscal.ToString()).CellAppearance.TextHAlign = HAlign.Left

               .Columns(Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString()).Hidden = False
               .Columns(Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString()).Header.Caption = "Nombre"
               .Columns(Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString()).Width = 275

            End With
         End Sub)
   End Sub

   Protected Overrides Sub AgregarTodos()
      _filtros = GetTodas()
      RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas() As List(Of Entidades.CategoriaFiscal)
      Return New Reglas.CategoriasFiscales().GetTodos()
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      dgvDatos.DataSource = _filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.CategoriaFiscal
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As System.Collections.Generic.IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.CategoriaFiscal()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case Entidades.CategoriaFiscal.Columnas.IdCategoriaFiscal.ToString()
                  ma.IdCategoriaFiscal = Short.Parse(c.Valor)
               Case Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString()
                  ma.NombreCategoriaFiscal = c.Valor
            End Select
         Next
         Me.Filtros.Add(ma)
         i += 1
         col = From filt In filtros Where filt.IdRegistro = i
      End While
   End Sub

   Protected Overrides Sub LimpiarFiltros()
      _filtros.Clear()
      RefrescoDatosGrilla()
   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCategoriasFiscales2(bscCodigo)
            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.CategoriasFiscales().GetPorId(cod)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCategorias(bscNombre)
            bscNombre.Datos = New Reglas.CategoriasFiscales().GetPorNombreLike(bscNombre.Text)
         End Sub)
   End Sub

   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarCategoria(e.FilaDevuelta))
   End Sub


   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(
         Sub()
            If Not (bscCodigo.Selecciono Or bscNombre.Selecciono) Then
               Exit Sub
            End If
            Dim ep = New Entidades.CategoriaFiscal()
            ep.IdCategoriaFiscal = bscCodigo.Text.ValorNumericoPorDefecto(0S)
            ep.NombreCategoriaFiscal = bscNombre.Text

            For Each ent In _filtros
               If ent.IdCategoriaFiscal = ep.IdCategoriaFiscal Then
                  Exit Sub
               End If
            Next

            _filtros.Add(ep)
            RefrescoDatosGrilla()
            bscCodigo.Text = ""
            bscNombre.Text = ""
            bscCodigo.Focus()
         End Sub)
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(
         Sub()
            Dim dr = dgvDatos.FilaSeleccionada(Of Entidades.CategoriaFiscal)()
            If dr IsNot Nothing Then

               _filtros.Remove(dr)

               RefrescoDatosGrilla()
               bscCodigo.Text = ""
               bscNombre.Text = ""
               bscCodigo.Focus()
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarCategoria(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells(Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString()).Value.ToString()
         bscCodigo.Text = dr.Cells(Entidades.CategoriaFiscal.Columnas.IdCategoriaFiscal.ToString()).Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class