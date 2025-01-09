Public Class MFEstadosCheques

   Public Const TipoFiltroKey As String = "ESTADOS"

#Region "Campos"

   Private _filtros As List(Of Entidades.EstadoCheque)
   Public ReadOnly Property Filtros() As List(Of Entidades.EstadoCheque)
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
      _filtros = New List(Of Entidades.EstadoCheque)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdEstadoCheque")
      _columnasAMostrar.Add("NombreEstadoCheque")
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      dgvDatos.DataSource = _filtros.ToArray()

      With dgvDatos.DisplayLayout.Bands(0)
         For Each col In .Columns
            col.Hidden = True
         Next
         Dim pos = 0I
         .Columns("IdEstadoCheque").FormatearColumna("Estado", pos, 100)
         .Columns("NombreEstadoCheque").FormatearColumna("Nombre", pos, 300)
      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodas()
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas() As List(Of Entidades.EstadoCheque)
      Dim reg As Reglas.EstadosCheques = New Reglas.EstadosCheques()
      Return reg.GetTodos()
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.EstadoCheque
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While col.Count > 0
         ma = New Entidades.EstadoCheque
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdEstadoCheque"
                  ma.IdEstadoCheque = c.Valor
               Case "NombreEstadoCheque"
                  ma.NombreEstadoCheque = c.Valor
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

   Private Sub MFMarcas_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F4 Then
         Me.btnCerrar.PerformClick()
      End If
   End Sub

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaEstadosCheques(bscCodigo)
            bscCodigo.Datos = New Reglas.EstadosCheques().GetPorCodigo(bscCodigo.Text)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaEstadosCheques(bscNombre)
            bscNombre.Datos = New Reglas.EstadosCheques().GetPorNombre(bscNombre.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarEstado(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.EstadoCheque = New Entidades.EstadoCheque()
         ep.IdEstadoCheque = Me.bscCodigo.Text
         ep.NombreEstadoCheque = Me.bscNombre.Text
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

         For Each pr As Entidades.EstadoCheque In Me._filtros
            If pr.IdEstadoCheque = Me.dgvDatos.ActiveCell.Row.Cells("IdEstadoCheque").Value.ToString() Then
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

   Private Sub CargarEstado(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreEstadoCheque").Value.ToString()
         bscCodigo.Text = dr.Cells("IdEstadoCheque").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class