Public Class MFMovilRutas

   Public Const TipoFiltroKey As String = "MOVILRUTAS"

#Region "Campos"

   Private _filtros As List(Of Entidades.MovilRuta)
   Public ReadOnly Property Filtros() As List(Of Entidades.MovilRuta)
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
      _filtros = New List(Of Entidades.MovilRuta)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdRuta")
      _columnasAMostrar.Add("NombreRuta")
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
         .Columns("IdRuta").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreRuta").FormatearColumna("Nombre", pos, 340)
      End With
   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodas()
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas() As List(Of Entidades.MovilRuta)
      Dim reg As Reglas.MovilRutas = New Reglas.MovilRutas()
      Return reg.GetTodos()
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.MovilRuta
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While col.Count > 0
         ma = New Entidades.MovilRuta()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdRuta"
                  ma.IdRuta = Integer.Parse(c.Valor)
               Case "NombreRuta"
                  ma.NombreRuta = c.Valor
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

   Private Sub MFMovilRutas_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F4 Then
         Me.btnCerrar.PerformClick()
      End If
   End Sub

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMovilRutas(bscCodigo)
            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.MovilRutas().GetPorCodigo(cod)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaMovilRutas(bscNombre)
            bscNombre.Datos = New Reglas.MovilRutas().GetPorNombre(bscNombre.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarMovilRuta(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.MovilRuta = New Entidades.MovilRuta()
         ep.IdRuta = Int32.Parse(Me.bscCodigo.Text)
         ep.NombreRuta = Me.bscNombre.Text
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

         For Each pr As Entidades.MovilRuta In Me._filtros
            If pr.IdRuta = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdRuta").Value.ToString()) Then
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

   Private Sub CargarMovilRuta(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreRuta").Value.ToString()
         bscCodigo.Text = dr.Cells("IdRuta").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class