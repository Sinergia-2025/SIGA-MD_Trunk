Public Class MFTiposCliente

   Public Const TipoFiltroKey As String = "TIPOSCLIENTE"

#Region "Campos"

   Private _idFuncion As String
   Private _filtros As List(Of Entidades.TipoCliente)
   Public ReadOnly Property Filtros() As List(Of Entidades.TipoCliente)
      Get
         Return _filtros
      End Get
   End Property

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(permiteSinSeleccion:=True, idFuncion:=String.Empty)
   End Sub

   Public Sub New(permiteSinSeleccion As Boolean, idFuncion As String)
      MyBase.New(permiteSinSeleccion)
      _idFuncion = idFuncion
      InitializeComponent()
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.TipoCliente)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString())
      _columnasAMostrar.Add(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString())

   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Me.dgvDatos.DataSource = Me._filtros.ToArray()

      dgvDatos.DisplayLayout.AutoFitStyle = UltraWinGrid.AutoFitStyle.ExtendLastColumn
      With dgvDatos.DisplayLayout.Bands(0)
         For Each col In .Columns.OfType(Of UltraGridColumn)
            col.Hidden = True
         Next

         .Columns(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()).Hidden = False
         .Columns(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()).Header.Caption = "Código"
         .Columns(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()).Width = 50
         .Columns(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()).CellAppearance.TextHAlign = HAlign.Left

         .Columns(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString()).Hidden = False
         .Columns(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString()).Width = 275

      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodas(_idFuncion)
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas(idFuncion As String) As List(Of Entidades.TipoCliente)
      Dim reg As Reglas.TiposClientes = New Reglas.TiposClientes()
      Return reg.GetTodos()
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.TipoCliente
      Dim i As Integer = 0
      Dim tipoClientes As List(Of Entidades.TipoCliente) = GetTodas(_idFuncion)
      Me.Filtros.Clear()
      Dim col As System.Collections.Generic.IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.TipoCliente()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()
                  ma.IdTipoCliente = Integer.Parse(c.Valor)
                  ma.IdTipoCliente = ma.IdTipoCliente
               Case Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString()
                  ma.NombreTipoCliente = c.Valor
            End Select
         Next
         If tipoClientes.Exists(Function(x) x.IdTipoCliente = ma.IdTipoCliente) Then
            Me.Filtros.Add(ma)
         End If
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
            _publicos.PreparaGrillaTiposCliente(bscCodigo)
            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.TiposClientes().GetAllPorCodigo(cod)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaTiposCliente(bscNombre)
            bscNombre.Datos = New Reglas.TiposClientes().GetAllPorNombre(bscNombre.Text)
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarTipoCliente(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.TipoCliente = New Entidades.TipoCliente()
         ep.IdTipoCliente = Integer.Parse(Me.bscCodigo.Text)
         ep.NombreTipoCliente = Me.bscNombre.Text
         Me._filtros.Add(ep)
         Me.RefrescoDatosGrilla()
         Me.bscCodigo.Text = ""
         Me.bscNombre.Text = ""
         Me.bscCodigo.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If dgvDatos.ActiveRow IsNot Nothing AndAlso
            dgvDatos.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (dgvDatos.ActiveRow.ListObject) Is Entidades.TipoCliente Then

            _filtros.Remove(DirectCast(dgvDatos.ActiveRow.ListObject, Entidades.TipoCliente))

            Me.RefrescoDatosGrilla()
            Me.bscCodigo.Text = ""
            Me.bscNombre.Text = ""
            Me.bscCodigo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarTipoCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigo.Text = dr.Cells(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()).Value.ToString.Trim()
         bscNombre.Text = dr.Cells(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString()).Value.ToString()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class