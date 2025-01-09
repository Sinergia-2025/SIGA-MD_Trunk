Public Class MFFormasDePago

   Public Const TipoFiltroKey As String = "FORMASDEPAGO"

#Region "Campos"
   Private _filtros As List(Of Entidades.VentaFormaPago)
   Public ReadOnly Property Filtros() As List(Of Entidades.VentaFormaPago)
      Get
         Return _filtros
      End Get
   End Property

   Private _tipo As String
   Private _esContado As Boolean?

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(permiteSinSeleccion:=True)
   End Sub
   Public Sub New(permiteSinSeleccion As Boolean)
      Me.New(permiteSinSeleccion, tipo:=String.Empty, esContado:=Nothing)
   End Sub
   Public Sub New(permiteSinSeleccion As Boolean, tipo As String, Optional esContado As Boolean? = Nothing)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.VentaFormaPago)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdFormasPago")
      _columnasAMostrar.Add("DescripcionFormasPago")

      _tipo = tipo
      _esContado = esContado
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

         .Columns("IdFormasPago").Hidden = False
         .Columns("IdFormasPago").Header.Caption = "Código"
         .Columns("IdFormasPago").Width = 80
         .Columns("IdFormasPago").CellAppearance.TextHAlign = HAlign.Right

         .Columns("DescripcionFormasPago").Hidden = False
         .Columns("DescripcionFormasPago").Header.Caption = "Nombre"
         .Columns("DescripcionFormasPago").Width = 300

      End With
   End Sub

   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodos(_tipo, _esContado)
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodos(tipo As String, Optional esContado As Boolean? = Nothing) As List(Of Entidades.VentaFormaPago)
      Dim reg As Reglas.VentasFormasPago = New Reglas.VentasFormasPago()
      Return reg.GetTodas(tipo, esContado)
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.VentaFormaPago
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As System.Collections.Generic.IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.VentaFormaPago()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdFormasPago"
                  ma.IdFormasPago = Integer.Parse(c.Valor)
               Case "DescripcionFormasPago"
                  ma.DescripcionFormasPago = c.Valor
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
            _publicos.PreparaGrillaFormasDePago(bscCodigo)
            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.VentasFormasPago().GetPorCodigo(cod, _tipo, _esContado)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaFormasDePago(bscNombre)
            bscNombre.Datos = New Reglas.VentasFormasPago().GetPorDescripcion(bscNombre.Text.Trim(), _tipo, _esContado)
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarFormaDePago(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.VentaFormaPago = New Entidades.VentaFormaPago()
         If IsNumeric(Me.bscCodigo.Text) Then
            ep.IdFormasPago = Integer.Parse(Me.bscCodigo.Text)
         End If
         ep.DescripcionFormasPago = Me.bscNombre.Text
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

         For Each pr As Entidades.VentaFormaPago In Me._filtros
            If pr.IdFormasPago = Integer.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdFormasPago").Value.ToString()) Then
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

   Private Sub CargarFormaDePago(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("DescripcionFormasPago").Value.ToString()
         bscCodigo.Text = dr.Cells("IdFormasPago").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

End Class