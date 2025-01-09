Public Class MFZonasGeograficas

   Public Const TipoFiltroKey As String = "ZONAS"

#Region "Campos"

   Private _filtros As List(Of Entidades.ZonaGeografica)
   Public ReadOnly Property Filtros() As List(Of Entidades.ZonaGeografica)
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
      _filtros = New List(Of Entidades.ZonaGeografica)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdZonaGeografica")
      _columnasAMostrar.Add("NombreZonaGeografica")
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Me.dgvDatos.DataSource = Me._filtros.ToArray()

      Me.dgvDatos.DisplayLayout.Bands(0).Columns("IdZonaGeografica").Header.Caption = "Código"
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("IdZonaGeografica").Width = 60
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("IdZonaGeografica").CellAppearance.TextHAlign = HAlign.Right

      Me.dgvDatos.DisplayLayout.Bands(0).Columns("NombreZonaGeografica").Header.Caption = "Nombre"
      Me.dgvDatos.DisplayLayout.Bands(0).Columns("NombreZonaGeografica").Width = 340
      'Me.dgvDatos.DisplayLayout.Bands(0).Columns("NombreMarca").AutoSizeMode =

      'Me.grbCabeza.Focus()
      'Me.bscNombre.Focus()

   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodas()
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas() As List(Of Entidades.ZonaGeografica)
      Dim reg As Reglas.ZonasGeograficas = New Reglas.ZonasGeograficas()
      Return reg.GetTodas()
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.ZonaGeografica
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While col.Count > 0
         ma = New Entidades.ZonaGeografica()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdZonaGeografica"
                  ma.IdZonaGeografica = c.Valor
               Case "NombreZonaGeografica"
                  ma.NombreZonaGeografica = c.Valor
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
   '      MessageBox.Show("Debe seleccionar al menos una Zona.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Return False
   '   End If
   '   Return result
   'End Function

#End Region

#Region "Eventos"

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaZonasGeograficas2(bscCodigo)
            bscCodigo.Datos = New Reglas.ZonasGeograficas().GetPorCodigo(bscCodigo.Text)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaZonasGeograficas2(bscNombre)
            bscNombre.Datos = New Reglas.ZonasGeograficas().GetPorNombre(bscNombre.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarZonaGeografica(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.ZonaGeografica = New Entidades.ZonaGeografica()
         ep.IdZonaGeografica = Me.bscCodigo.Text
         ep.NombreZonaGeografica = Me.bscNombre.Text
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

         For Each pr As Entidades.ZonaGeografica In Me._filtros
            If pr.IdZonaGeografica = Me.dgvDatos.ActiveCell.Row.Cells("IdMarca").Value.ToString() Then
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

   Private Sub CargarZonaGeografica(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreZonaGeografica").Value.ToString()
         bscCodigo.Text = dr.Cells("IdZonaGeografica").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class