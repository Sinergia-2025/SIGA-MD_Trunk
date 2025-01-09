Public Class MFTipoComprobantes

   Public Const TipoFiltroKey As String = "TIPOCOMPROBANTES"

#Region "Campos"

   Private _filtros As List(Of Entidades.TipoComprobante)
   Public ReadOnly Property Filtros() As List(Of Entidades.TipoComprobante)
      Get
         Return _filtros
      End Get
   End Property

   Private _tipo1 As String
   Private _tipo2 As String

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(permiteSinSeleccion:=True, Tipo1:=String.Empty, Tipo2:=String.Empty)
   End Sub

   Public Sub New(permiteSinSeleccion As Boolean, Tipo1 As String, Tipo2 As String)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.TipoComprobante)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdTipoComprobante")
      _columnasAMostrar.Add("Descripcion")
      _tipo1 = Tipo1
      _tipo2 = Tipo2
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
         .Columns("IdTipoComprobante").FormatearColumna("Código", pos, 125)
         .Columns("Descripcion").FormatearColumna("Nombre", pos, 275)

      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodos(_tipo1, _tipo2)
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodos(tipo1 As String, tipo2 As String) As List(Of Entidades.TipoComprobante)
      Dim reg = New Reglas.TiposComprobantes()
      Return reg.GetTodos(tipo1, tipo2)
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.TipoComprobante
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As System.Collections.Generic.IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.TipoComprobante()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdTipoComprobante"
                  ma.IdTipoComprobante = c.Valor
               Case "Descripcion"
                  ma.Descripcion = c.Valor
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
      Try
         Dim oRegla As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
         Me._publicos.PreparaGrillaTiposComprobantes(Me.bscCodigo)

         Dim cod As String = ""
         If Not String.IsNullOrEmpty(Me.bscCodigo.Text) Then
            cod = Me.bscCodigo.Text
         End If

         Me.bscCodigo.Datos = oRegla.GetPorCodigo(cod, _tipo1, _tipo2)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarTipoComprobante(e.FilaDevuelta)
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      Try
         Dim oCli As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
         Me._publicos.PreparaGrillaTiposComprobantes(Me.bscNombre)
         Me.bscNombre.Datos = oCli.GetPorDescripcion(Me.bscNombre.Text.Trim(), _tipo1, _tipo2)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombre_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombre.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarTipoComprobante(e.FilaDevuelta)
            Me.btnInsertar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.TipoComprobante = New Entidades.TipoComprobante()
         ep.IdTipoComprobante = Me.bscCodigo.Text
         ep.Descripcion = Me.bscNombre.Text
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

         For Each pr As Entidades.TipoComprobante In Me._filtros
            If pr.IdTipoComprobante = Me.dgvDatos.ActiveCell.Row.Cells("IdTipoComprobante").Value.ToString() Then
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

   Private Sub CargarTipoComprobante(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("Descripcion").Value.ToString()
         bscCodigo.Text = dr.Cells("IdTipoComprobante").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class