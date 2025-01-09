Public Class MFCRMEstados

   Public Const TipoFiltroKey As String = "ESTADOS"
   Private _idTipoNovedad As String
#Region "Campos"

   Private _filtros As List(Of Entidades.CRMEstadoNovedad)
   Public ReadOnly Property Filtros() As List(Of Entidades.CRMEstadoNovedad)
      Get
         Return _filtros
      End Get
   End Property

#End Region

#Region "Constructores"

   Public Sub New()
      MyBase.New(permiteSinSeleccion:=True)
   End Sub
   Public Sub New(permiteSinSeleccion As Boolean, idTipoNovedad As String)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.CRMEstadoNovedad)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdEstadoNovedad")
      _columnasAMostrar.Add("NombreEstadoNovedad")
      _idTipoNovedad = idTipoNovedad
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
         .Columns("IdEstadoNovedad").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreEstadoNovedad").FormatearColumna("Nombre", pos, 340)
      End With
   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodas(idTipoNovedad:=_idTipoNovedad, ordenarPosicion:=False)
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas(idTipoNovedad As String, Optional ordenarPosicion As Boolean = False) As List(Of Entidades.CRMEstadoNovedad)
      Dim reg As Reglas.CRMEstadosNovedades = New Reglas.CRMEstadosNovedades()
      Return reg.GetTodos(idTipoNovedad:=idTipoNovedad, ordenarPosicion:=False)
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.CRMEstadoNovedad
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While col.Count > 0
         ma = New Entidades.CRMEstadoNovedad()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdEstadoNovedad"
                  ma.IdEstadoNovedad = Integer.Parse(c.Valor)
               Case "NombreEstadoNovedad"
                  ma.NombreEstadoNovedad = c.Valor
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
            _publicos.PreparaGrillaCRMEstados(bscCodigo)
            Dim cod As Integer = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.CRMEstadosNovedades().GetPorCodigo(cod, _idTipoNovedad)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCRMEstados(bscNombre)
            bscNombre.Datos = New Reglas.CRMEstadosNovedades().GetPorNombre(bscNombre.Text.Trim(), _idTipoNovedad)
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarEstados(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.CRMEstadoNovedad = New Entidades.CRMEstadoNovedad()
         ep.IdEstadoNovedad = Int32.Parse(Me.bscCodigo.Text)
         ep.NombreEstadoNovedad = Me.bscNombre.Text
         _filtros.Add(ep)
         RefrescoDatosGrilla()
         bscCodigo.Text = ""
         bscNombre.Text = ""
         bscCodigo.Focus()
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

         For Each pr As Entidades.CRMEstadoNovedad In Me._filtros
            If pr.IdEstadoNovedad = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdEstadoNovedad").Value.ToString()) Then
               Me._filtros.Remove(pr)
               Exit For
            End If
         Next
         RefrescoDatosGrilla()
         bscCodigo.Text = ""
         bscNombre.Text = ""
         bscCodigo.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarEstados(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreEstadoNovedad").Value.ToString()
         bscCodigo.Text = dr.Cells("IdEstadoNovedad").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class