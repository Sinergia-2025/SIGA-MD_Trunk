Public Class MFSucursales

   Public Const TipoFiltroKey As String = "SUCURSALES"

#Region "Campos"
   Private _idEmpresa As Integer?
   Private _idFuncion As String
   Private _filtros As List(Of Entidades.Sucursal)
   Public ReadOnly Property Filtros() As List(Of Entidades.Sucursal)
      Get
         Return _filtros
      End Get
   End Property

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(String.Empty, idEmpresa:=Nothing)
   End Sub
   Public Sub New(idFuncion As String, idEmpresa As Integer?)
      Me.New(permiteSinSeleccion:=True, idFuncion, idEmpresa)
   End Sub

   Public Sub New(permiteSinSeleccion As Boolean, idFuncion As String, idEmpresa As Integer?)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      _idFuncion = idFuncion
      _idEmpresa = idEmpresa
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.Sucursal)()
      _columnasAMostrar = New List(Of String) From {
         Entidades.Sucursal.Columnas.Id.ToString(),
         Entidades.Sucursal.Columnas.Nombre.ToString()
      }
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

            Dim pos = 0I
            .Columns(Entidades.Sucursal.Columnas.Id.ToString()).FormatearColumna("Código", pos, 50, HAlign.Right)
            .Columns(Entidades.Sucursal.Columnas.Nombre.ToString()).FormatearColumna("Nombre", pos, 275)

         End With
      End Sub)

   End Sub

   Protected Overrides Sub AgregarTodos()
      _filtros = GetTodas(_idFuncion, _idEmpresa)
      RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas(idFuncion As String, idEmpresa As Integer?) As List(Of Entidades.Sucursal)
      Dim rSuc = New Reglas.Sucursales()
      Return rSuc.GetTodas(idFuncion, idEmpresa, incluirLogo:=False)
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(_tipoFiltro, _nombreFiltro)
      Dim ma As Entidades.Sucursal
      Dim i As Integer = 0
      Dim sucursales As List(Of Entidades.Sucursal) = GetTodas(_idFuncion, _idEmpresa)
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While Enumerable.Count(col) > 0
         ma = New Entidades.Sucursal()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case Entidades.Sucursal.Columnas.Id.ToString()
                  ma.Id = Integer.Parse(c.Valor)
                  ma.IdSucursal = ma.Id
               Case Entidades.Sucursal.Columnas.Nombre.ToString()
                  ma.Nombre = c.Valor
            End Select
         Next
         If sucursales.Exists(Function(x) x.IdSucursal = ma.IdSucursal) Then
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

   Private Sub MFSucursals_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F4 Then
         btnCerrar.PerformClick()
      End If
   End Sub

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSucursales(bscCodigo)
         Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
         bscCodigo.Datos = New Reglas.Sucursales().GetPorCodigo(cod, _idFuncion)
      End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaSucursales(bscNombre)
         bscNombre.Datos = New Reglas.Sucursales().GetPorNombre(bscNombre.Text.Trim(), _idFuncion)
      End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarSucursal(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(
      Sub()
         If Not (bscCodigo.Selecciono Or bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep = New Entidades.Sucursal With {
            .Id = Integer.Parse(bscCodigo.Text),
            .Nombre = bscNombre.Text
         }
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
         Dim dr = dgvDatos.FilaSeleccionada(Of Entidades.Sucursal)()
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

   Private Sub CargarSucursal(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells(Entidades.Sucursal.Columnas.Nombre.ToString()).Value.ToString()
         bscCodigo.Text = dr.Cells(Entidades.Sucursal.Columnas.IdSucursal.ToString()).Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region
End Class