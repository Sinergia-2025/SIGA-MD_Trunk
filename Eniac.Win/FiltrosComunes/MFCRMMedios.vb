Public Class MFCRMMedios

   Public Const TipoFiltroKey As String = "MEDIOS"
   Private _idTipoNovedad As String
#Region "Campos"

   Private _filtros As List(Of Entidades.CRMMedioComunicacionNovedad)
   Public ReadOnly Property Filtros() As List(Of Entidades.CRMMedioComunicacionNovedad)
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
      _filtros = New List(Of Entidades.CRMMedioComunicacionNovedad)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdMedioComunicacionNovedad")
      _columnasAMostrar.Add("NombreMedioComunicacionNovedad")
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
         .Columns("IdMedioComunicacionNovedad").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreMedioComunicacionNovedad").FormatearColumna("Nombre", pos, 340)
      End With
   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodas(idTipoNovedad:=_idTipoNovedad, ordenarPosicion:=False)
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas(idTipoNovedad As String, Optional ordenarPosicion As Boolean = False) As List(Of Entidades.CRMMedioComunicacionNovedad)
      Dim reg As Reglas.CRMMediosComunicacionesNovedades = New Reglas.CRMMediosComunicacionesNovedades()
      Return reg.GetTodos(idTipoNovedad:=idTipoNovedad, ordenarPosicion:=False)
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.CRMMedioComunicacionNovedad
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While col.Count > 0
         ma = New Entidades.CRMMedioComunicacionNovedad()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdMedioComunicacionNovedad"
                  ma.IdMedioComunicacionNovedad = Integer.Parse(c.Valor)
               Case "NombreMedioComunicacionNovedad"
                  ma.NombreMedioComunicacionNovedad = c.Valor
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
            _publicos.PreparaGrillaCRMMedios(bscCodigo)
            Dim cod As Integer = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.CRMMediosComunicacionesNovedades().GetPorCodigo(cod, _idTipoNovedad)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCRMMedios(bscNombre)
            bscNombre.Datos = New Reglas.CRMMediosComunicacionesNovedades().GetPorNombre(bscNombre.Text.Trim(), _idTipoNovedad)
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarCategorias(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.CRMMedioComunicacionNovedad = New Entidades.CRMMedioComunicacionNovedad()
         ep.IdMedioComunicacionNovedad = Int32.Parse(Me.bscCodigo.Text)
         ep.NombreMedioComunicacionNovedad = Me.bscNombre.Text
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

         For Each pr As Entidades.CRMMedioComunicacionNovedad In Me._filtros
            If pr.IdMedioComunicacionNovedad = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdMedioComunicacionNovedad").Value.ToString()) Then
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

   Private Sub CargarCategorias(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreMedioComunicacionNovedad").Value.ToString()
         bscCodigo.Text = dr.Cells("IdMedioComunicacionNovedad").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class