Public Class MFSubSubRubros
   Public Const TipoFiltroKey As String = "SUBSUBRUBROS"
#Region "Campos"

   Private _filtros As List(Of Entidades.SubSubRubro)
   Public ReadOnly Property Filtros() As List(Of Entidades.SubSubRubro)
      Get
         Return _filtros
      End Get
   End Property

   Public Property SubRubro As Entidades.SubRubro()
   Public Property ConcatenarNombreSubRubro As Boolean = False

#End Region

#Region "Constructores"

   Public Sub New()
      Me.New(permiteSinSeleccion:=True, concatenarNombreSubRubro:=False)
   End Sub
   Public Sub New(permiteSinSeleccion As Boolean, concatenarNombreSubRubro As Boolean)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      Me.ConcatenarNombreSubRubro = concatenarNombreSubRubro
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.SubSubRubro)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdSubSubRubro")
      If Me.ConcatenarNombreSubRubro Then
         _columnasAMostrar.Add("NombreConcatenado")
      Else
         _columnasAMostrar.Add("NombreSubSubRubro")
      End If
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
         Dim pos = 0I
         .Columns("IdSubSubRubro").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreSubSubRubro").FormatearColumna("Nombre", pos, 340, , ConcatenarNombreSubRubro)
         .Columns("NombreConcatenado").FormatearColumna("Nombre", pos, 340, , Not ConcatenarNombreSubRubro)
      End With
   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodos(SubRubro)
      Me.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.SubSubRubro
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.SubSubRubro()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdSubSubRubro"
                  ma.IdSubSubRubro = c.Valor.ToInt32().IfNull()
               Case "NombreSubSubRubro"
                  ma.NombreSubSubRubro = c.Valor
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

   Public Shared Function GetTodos(subrubros As Entidades.SubRubro()) As List(Of Entidades.SubSubRubro)
      Dim reg As Reglas.SubSubRubros = New Reglas.SubSubRubros()
      Return reg.GetTodos(subrubros)
   End Function

#End Region

#Region "Eventos"

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaSubSubRubros2(bscCodigo)
            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.SubSubRubros().GetPorCodigo(0, cod, String.Empty, SubRubro)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaSubSubRubros2(bscNombre)
            bscNombre.Datos = New Reglas.SubSubRubros().GetPorNombre(0, 0, bscNombre.Text.Trim(), SubRubro)
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
         Dim ep As Entidades.SubSubRubro = New Entidades.SubSubRubro()
         ep.IdSubSubRubro = Int32.Parse(Me.bscCodigo.Text)
         ep.NombreSubSubRubro = Me.bscNombre.Text
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

         For Each pr As Entidades.SubSubRubro In Me._filtros
            If pr.IdSubSubRubro = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdSubSubRubro").Value.ToString()) Then
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
         bscNombre.Text = dr.Cells("NombreSubSubRubro").Value.ToString()
         bscCodigo.Text = dr.Cells("IdSubSubRubro").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class