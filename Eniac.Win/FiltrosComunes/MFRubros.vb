Public Class MFRubros

   Public Const TipoFiltroKey As String = "RUBROS"

#Region "Campos"

   Private _filtros As List(Of Entidades.Rubro)
   Public ReadOnly Property Filtros() As List(Of Entidades.Rubro)
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
      _filtros = New List(Of Entidades.Rubro)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdRubro")
      _columnasAMostrar.Add("NombreRubro")
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
         .Columns("IdRubro").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreRubro").FormatearColumna("Nombre", pos, 340)
      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodos()
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodos() As List(Of Entidades.Rubro)
      Dim reg As Reglas.Rubros = New Reglas.Rubros()
      Return reg.GetTodos()
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.Rubro
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While col.Count > 0
         ma = New Entidades.Rubro()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdRubro"
                  ma.IdRubro = Integer.Parse(c.Valor)
               Case "NombreRubro"
                  ma.NombreRubro = c.Valor
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
            _publicos.PreparaGrillaRubros2(bscCodigo)
            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.Rubros().GetPorCodigo(cod)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaRubros2(bscNombre)
            bscNombre.Datos = New Reglas.Rubros().GetPorNombre(bscNombre.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarRubro(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.Rubro = New Entidades.Rubro()
         ep.IdRubro = Int32.Parse(Me.bscCodigo.Text)
         ep.NombreRubro = Me.bscNombre.Text
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

         For Each pr As Entidades.Rubro In Me._filtros
            If pr.IdRubro = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdRubro").Value.ToString()) Then
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

   Private Sub CargarRubro(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreRubro").Value.ToString()
         bscCodigo.Text = dr.Cells("IdRubro").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class