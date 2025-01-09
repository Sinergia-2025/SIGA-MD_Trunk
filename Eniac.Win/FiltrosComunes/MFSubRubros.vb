Public Class MFSubRubros

   Public Const TipoFiltroKey As String = "SUBRUBROS"

#Region "Campos"

   Private _filtros As List(Of Entidades.SubRubro)
   Public ReadOnly Property Filtros() As List(Of Entidades.SubRubro)
      Get
         Return _filtros
      End Get
   End Property

   Public Property Rubros As Entidades.Rubro()
   Public Property ConcatenarNombreRubro As Boolean = False

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(permiteSinSeleccion:=True, concatenarNombreRubro:=False)
   End Sub
   Public Sub New(permiteSinSeleccion As Boolean, concatenarNombreRubro As Boolean)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      Me.ConcatenarNombreRubro = concatenarNombreRubro
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.SubRubro)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdSubRubro")
      If Me.ConcatenarNombreRubro Then
         _columnasAMostrar.Add("NombreRubroSubRubro")
      Else
         _columnasAMostrar.Add("NombreSubRubro")
      End If
      _permiteSinSeleccion = permiteSinSeleccion
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Me.dgvDatos.DataSource = Me._filtros.ToArray()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next
         Dim pos As Integer = 0

         .Columns("IdSubRubro").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreSubRubro").FormatearColumna("Nombre", pos, 340, , ConcatenarNombreRubro)
         .Columns("NombreRubroSubRubro").FormatearColumna("Nombre", pos, 340, , Not ConcatenarNombreRubro)
      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodos(Rubros)
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodos(rubros As Entidades.Rubro()) As List(Of Entidades.SubRubro)
      Dim reg As Reglas.SubRubros = New Reglas.SubRubros()
      Return reg.GetTodos(rubros)
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.SubRubro
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.SubRubro()
         For Each c As Entidades.FiltroValor In col
            If c.IdColumna = "IdSubRubro" Then
               ma.IdSubRubro = c.Valor.ToInt32().IfNull()
            ElseIf c.IdColumna = "NombreSubRubro" Then
               ma.NombreSubRubro = c.Valor
            End If
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
            _publicos.PreparaGrillaSubRubros2(bscCodigo)
            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.SubRubros().GetPorCodigo(Rubros, cod)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaSubRubros2(bscNombre)
            bscNombre.Datos = New Reglas.SubRubros().GetPorNombre(Rubros, bscNombre.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarSubRubro(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.SubRubro = New Entidades.SubRubro()
         ep.IdSubRubro = Int32.Parse(Me.bscCodigo.Text)
         ep.NombreSubRubro = Me.bscNombre.Text
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

         For Each pr As Entidades.SubRubro In Me._filtros
            If pr.IdSubRubro = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdSubRubro").Value.ToString()) Then
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

   Private Sub CargarSubRubro(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreSubRubro").Value.ToString()
         bscCodigo.Text = dr.Cells("IdSubRubro").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class