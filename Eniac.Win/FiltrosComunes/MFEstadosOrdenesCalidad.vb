Public Class MFEstadosOrdenesCalidad

   Public Const TipoFiltroKey As String = "ESTADOORDENCALIDAD"

#Region "Campos"
   Private _idFuncion As String
   Private _filtros As List(Of Entidades.EstadoOrdenCalidad)
   Public ReadOnly Property Filtros() As List(Of Entidades.EstadoOrdenCalidad)
      Get
         Return _filtros
      End Get
   End Property

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(permiteSinSeleccion:=True, String.Empty)
   End Sub

   Public Sub New(permiteSinSeleccion As Boolean, idFuncion As String)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      _idFuncion = idFuncion
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.EstadoOrdenCalidad)()
      _columnasAMostrar = {Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString(), Entidades.EstadoOrdenCalidad.Columnas.TipoEstadoCalidad.ToString()}.ToList()
      _permiteSinSeleccion = True
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      dgvDatos.DataSource = _filtros.ToArray()

      dgvDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
      With dgvDatos.DisplayLayout.Bands(0)
         For Each col In .Columns
            col.Hidden = True
         Next
         Dim pos = 0I
         .Columns(Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString()).FormatearColumna("Estado", pos, 150, HAlign.Left, False)
         .Columns(Entidades.EstadoOrdenCalidad.Columnas.TipoEstadoCalidad.ToString()).FormatearColumna("Tipo Estado", pos, 150, HAlign.Left, False)
      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      _filtros = GetTodas()
      RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas() As List(Of Entidades.EstadoOrdenCalidad)
      Dim rEstados = New Reglas.EstadosOrdenesCalidad()
      Return rEstados.GetTodos()
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      dgvDatos.DataSource = _filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros = New Reglas.FiltrosValores().GetTodosPorTipoNombre(_tipoFiltro, _nombreFiltro)
      Dim i As Integer = 0
      Dim Estados = GetTodas()
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While col.Count() > 0
         Dim ma = New Entidades.EstadoOrdenCalidad()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString()
                  ma.IdEstadoCalidad = c.Valor
               Case Entidades.EstadoOrdenCalidad.Columnas.TipoEstadoCalidad.ToString()
                  ma.TipoEstadoCalidad = c.Valor.StringToEnum(Entidades.EstadoOrdenCalidad.TiposEstadosCalidad.PENDIENTE)
            End Select
         Next
         If Estados.Exists(Function(x) x.IdEstadoCalidad = ma.IdEstadoCalidad) Then
            Me.Filtros.Add(ma)
         End If
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
            Dim rEstados = New Reglas.EstadosOrdenesCalidad()
            _publicos.PreparaGrillaEstadosOrdenCalidad(bscCodigo)

            Dim cod = bscCodigo.Text
            bscCodigo.Datos = rEstados.GetPorCodigo(cod)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            Dim rEstados = New Reglas.EstadosOrdenesCalidad()
            _publicos.PreparaGrillaEstadosOrdenCalidad(bscNombre)

            bscNombre.Datos = rEstados.GetPorNombre(bscNombre.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarEstadoOrdenCalidad(e.FilaDevuelta))
   End Sub


   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(
         Sub()
            If Not (bscCodigo.Selecciono Or bscNombre.Selecciono) Then
               Exit Sub
            End If
            Dim ep = New Entidades.EstadoOrdenCalidad()
            ep.IdEstadoCalidad = bscCodigo.Text
            ep.TipoEstadoCalidad = bscNombre.Text.StringToEnum(Entidades.EstadoOrdenCalidad.TiposEstadosCalidad.PENDIENTE)
            _filtros.Add(ep)
            RefrescoDatosGrilla()
            bscCodigo.Text = String.Empty
            bscNombre.Text = String.Empty
            bscCodigo.Focus()
         End Sub)
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(
         Sub()
            Dim dr = dgvDatos.FilaSeleccionada(Of Entidades.EstadoOrdenCalidad)()
            If dr IsNot Nothing Then
               _filtros.Remove(dr)

               RefrescoDatosGrilla()
               bscCodigo.Text = String.Empty
               bscNombre.Text = String.Empty
               bscCodigo.Focus()
            End If
         End Sub)
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarEstadoOrdenCalidad(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigo.Text = dr.Cells(Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString()).Value.ToString.Trim()
         bscNombre.Text = dr.Cells(Entidades.EstadoOrdenCalidad.Columnas.TipoEstadoCalidad.ToString()).Value.ToString()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region
End Class