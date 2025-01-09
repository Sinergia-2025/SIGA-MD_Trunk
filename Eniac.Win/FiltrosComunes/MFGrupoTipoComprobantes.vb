Public Class MFGrupoTipoComprobantes

   Public Const TipoFiltroKey As String = "GRUPOTIPOCOMPROBANTES"

#Region "Campos"
   Private _filtros As List(Of Entidades.Grupo)
   Public ReadOnly Property Filtros() As List(Of Entidades.Grupo)
      Get
         Return _filtros
      End Get
   End Property

   Private _idGrupo As String
   Private _nombreGrupo As String

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(permiteSinSeleccion:=True, idGrupo:=String.Empty, nombreGrupo:=String.Empty)
   End Sub
   Public Sub New(permiteSinSeleccion As Boolean)
      Me.New(permiteSinSeleccion, idGrupo:=String.Empty, nombreGrupo:=String.Empty)
   End Sub
   Public Sub New(permiteSinSeleccion As Boolean, idGrupo As String, nombreGrupo As String)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.Grupo)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdGrupo")
      _columnasAMostrar.Add("NombreGrupo")
      _idGrupo = idGrupo
      _nombreGrupo = nombreGrupo
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Me.dgvDatos.DataSource = Me._filtros.ToArray()

      With dgvDatos.DisplayLayout.Bands(0)
         For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In .Columns
            col.Hidden = True
         Next

         .Columns("IdGrupo").Hidden = False
         .Columns("IdGrupo").Header.Caption = "Código"
         .Columns("IdGrupo").Width = 125
         .Columns("IdGrupo").CellAppearance.TextHAlign = HAlign.Left

         .Columns("NombreGrupo").Hidden = False
         .Columns("NombreGrupo").Header.Caption = "Nombre"
         .Columns("NombreGrupo").Width = 275

      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodas()
      Me.RefrescoDatosGrilla()
   End Sub
   Public Shared Function GetTodas() As List(Of Entidades.Grupo)
      Dim reg As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      Return reg.GetGruposTodos(String.Empty, String.Empty)
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.Grupo
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As System.Collections.Generic.IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.Grupo()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdGrupo"
                  ma.IdGrupo = c.Valor
               Case "NombreGrupo"
                  ma.NombreGrupo = c.Valor
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

   'Protected Overrides Function ValidaSeleccion() As Boolean
   '   Dim result As Boolean = MyBase.ValidaSeleccion()
   '   If Not _permiteSinSeleccion AndAlso _filtros.Count = 0 Then
   '      MessageBox.Show("Debe seleccionar al menos un Tipo de Comprobante.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Return False
   '   End If
   '   Return result
   'End Function

#End Region

#Region "Eventos"

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaGrupoTiposComprobantes(bscCodigo)
            bscCodigo.Datos = New Reglas.TiposComprobantes().GetGruposPorCodigo(bscCodigo.Text)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaGrupoTiposComprobantes(bscNombre)
            bscNombre.Datos = New Reglas.TiposComprobantes().GetGruposPorNombre(bscNombre.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarGrupo(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.Grupo = New Entidades.Grupo()
         ep.IdGrupo = Me.bscCodigo.Text
         ep.NombreGrupo = Me.bscNombre.Text
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

         For Each pr As Entidades.Grupo In Me._filtros
            If pr.IdGrupo = Me.dgvDatos.ActiveCell.Row.Cells("IdGrupo").Value.ToString() Then
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

   Private Sub CargarGrupo(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreGrupo").Value.ToString()
         bscCodigo.Text = dr.Cells("IdGrupo").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class