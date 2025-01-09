Public Class MFLocalidades

   Public Const TipoFiltroKey As String = "LOCALIDADES"

#Region "Campos"

   Private _filtros As List(Of Entidades.Localidad)
   Public ReadOnly Property Filtros() As List(Of Entidades.Localidad)
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
      _filtros = New List(Of Entidades.Localidad)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdLocalidad")
      _columnasAMostrar.Add("NombreLocalidad")

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Me.dgvDatos.DataSource = Me._filtros.ToArray()

      With dgvDatos.DisplayLayout.Bands(0)
         For Each col In .Columns.OfType(Of UltraGridColumn)
            col.Hidden = True
         Next

         Dim pos = 0I
         .Columns("IdLocalidad").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreLocalidad").FormatearColumna("Nombre", pos, 340)

      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      _filtros = GetTodas()
      RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas() As List(Of Entidades.Localidad)
      Dim reg As Reglas.Localidades = New Reglas.Localidades()
      Return reg.GetTodas()
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.Localidad
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While col.Count > 0
         ma = New Entidades.Localidad()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdLocalidad"
                  ma.IdLocalidad = Integer.Parse(c.Valor)
               Case "NombreLocalidad"
                  ma.NombreLocalidad = c.Valor
            End Select
         Next
         Me.Filtros.Add(ma)
         i += 1
         col = From filt In filtros Where filt.IdRegistro = i
      End While
   End Sub

   Protected Overrides Sub LimpiarFiltros()
      _filtros.Clear()
      RefrescoDatosGrilla()
   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaLocalidades(bscCodigo)
            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.Localidades().GetPorCodigo(cod)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaLocalidades(bscNombre)
            bscNombre.Datos = New Reglas.Localidades().GetPorNombre(bscNombre.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarLocalidad(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.Localidad = New Entidades.Localidad()
         ep.IdLocalidad = Int32.Parse(Me.bscCodigo.Text)
         ep.NombreLocalidad = Me.bscNombre.Text
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

         For Each pr As Entidades.Localidad In Me._filtros
            If pr.IdLocalidad = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdLocalidad").Value.ToString()) Then
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

   Private Sub CargarLocalidad(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreLocalidad").Value.ToString()
         bscCodigo.Text = dr.Cells("IdLocalidad").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class