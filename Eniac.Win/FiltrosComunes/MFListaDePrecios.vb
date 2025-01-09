Public Class MFListaDePrecios

   Public Const TipoFiltroKey As String = "LISTADEPRECIOS"

#Region "Campos"
   Private _filtros As List(Of Entidades.ListaDePrecios)
   Public ReadOnly Property Filtros() As List(Of Entidades.ListaDePrecios)
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
      _filtros = New List(Of Entidades.ListaDePrecios)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add(Entidades.ListaDePrecios.Columnas.IdListaPrecios.ToString())
      _columnasAMostrar.Add(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString())
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

         Dim pos = 0I
         .Columns(Entidades.ListaDePrecios.Columnas.IdListaPrecios.ToString()).FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()).FormatearColumna("Nombre", pos, 275)

      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodas()
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas() As List(Of Entidades.ListaDePrecios)
      Dim reg As Reglas.ListasDePrecios = New Reglas.ListasDePrecios()
      Return reg.GetTodos()
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.ListaDePrecios
      Dim i As Integer = 0
      Dim listaDePrecio As List(Of Entidades.ListaDePrecios) = GetTodas()
      Me.Filtros.Clear()
      Dim col As System.Collections.Generic.IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.ListaDePrecios()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case Entidades.ListaDePrecios.Columnas.IdListaPrecios.ToString()
                  ma.IdListaPrecios = Integer.Parse(c.Valor)
                  ma.IdListaPrecios = ma.IdListaPrecios
               Case Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()
                  ma.NombreListaPrecios = c.Valor
            End Select
         Next
         If listaDePrecio.Exists(Function(x) x.IdListaPrecios = ma.IdListaPrecios) Then
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
            _publicos.PreparaGrillaListaPrecios(bscCodigo)
            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.ListasDePrecios().GetPorCodigo(cod, True)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaListaPrecios(bscNombre)
            bscNombre.Datos = New Reglas.ListasDePrecios().GetPorNombre(bscNombre.Text)
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarListaDePrecio(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.ListaDePrecios = New Entidades.ListaDePrecios()
         ep.IdListaPrecios = Integer.Parse(Me.bscCodigo.Text)
         ep.NombreListaPrecios = Me.bscNombre.Text
         _filtros.Add(ep)
         RefrescoDatosGrilla()
         bscCodigo.Text = ""
         bscNombre.Text = ""
         bscCodigo.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If dgvDatos.ActiveRow IsNot Nothing AndAlso
            dgvDatos.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (dgvDatos.ActiveRow.ListObject) Is Entidades.ListaDePrecios Then

            _filtros.Remove(DirectCast(dgvDatos.ActiveRow.ListObject, Entidades.ListaDePrecios))

            RefrescoDatosGrilla()
            bscCodigo.Text = ""
            bscNombre.Text = ""
            bscCodigo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarListaDePrecio(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigo.Text = dr.Cells(Entidades.ListaDePrecios.Columnas.IdListaPrecios.ToString()).Value.ToString.Trim()
         bscNombre.Text = dr.Cells(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()).Value.ToString()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class