Public Class MFModelos

   Public Const TipoFiltroKey As String = "MODELOS"

#Region "Campos"

   Private _filtros As List(Of Entidades.Modelo)
   Public ReadOnly Property Filtros() As List(Of Entidades.Modelo)
      Get
         Return _filtros
      End Get
   End Property

   Public Property Marcas As Entidades.Marca()
   Public Property ConcatenarNombreMarca As Boolean = False

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(permiteSinSeleccion:=True, concatenarNombreMarca:=False)
   End Sub
   Public Sub New(permiteSinSeleccion As Boolean, concatenarNombreMarca As Boolean)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      Me.ConcatenarNombreMarca = concatenarNombreMarca
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.Modelo)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdModelo")
      If Me.ConcatenarNombreMarca Then
         _columnasAMostrar.Add("NombreMarcaModelo")
      Else
         _columnasAMostrar.Add("NombreModelo")
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

         .Columns("IdModelo").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreModelo").FormatearColumna("Nombre", pos, 340, , ConcatenarNombreMarca)
         .Columns("NombreMarcaModelo").FormatearColumna("Nombre", pos, 340, , Not ConcatenarNombreMarca)
      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      _filtros = GetTodos(Marcas)
      RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodos(marcas As Entidades.Marca()) As List(Of Entidades.Modelo)
      Dim reg = New Reglas.Modelos()
      Return reg.GetTodos(marcas)
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.Modelo
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.Modelo()
         For Each c As Entidades.FiltroValor In col
            If c.IdColumna = "IdModelo" Then
               ma.IdModelo = c.Valor.ToInt32().IfNull()
            ElseIf c.IdColumna = "NombreModelo" Then
               ma.NombreModelo = c.Valor
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
            _publicos.PreparaGrillaModelos(bscCodigo)
            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.Modelos().GetPorCodigo(Marcas, cod)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaModelos(bscNombre)
            bscNombre.Datos = New Reglas.Modelos().GetPorNombre(Marcas, bscNombre.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarModelo(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.Modelo = New Entidades.Modelo()
         ep.IdModelo = Int32.Parse(Me.bscCodigo.Text)
         ep.NombreModelo = Me.bscNombre.Text
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

         For Each pr As Entidades.Modelo In Me._filtros
            If pr.IdModelo = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdModelo").Value.ToString()) Then
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

   Private Sub CargarModelo(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreModelo").Value.ToString()
         bscCodigo.Text = dr.Cells("IdModelo").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class