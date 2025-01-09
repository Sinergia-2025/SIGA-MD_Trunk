
Public Class MFDepositos
   Public Const TipoFiltroKey As String = "SUCURSALESDEPOSITOS"

#Region "Campos"
   Private _filtros As List(Of Entidades.SucursalDeposito)
   Public ReadOnly Property Filtros() As List(Of Entidades.SucursalDeposito)
      Get
         Return _filtros
      End Get
   End Property
   Public Property Sucursales As Entidades.Sucursal()
   Public Property ConcatenarNombreDeposito As Boolean = False

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(concatenarNombreDeposito:=False)
   End Sub
   Public Sub New(concatenarNombreDeposito As Boolean)
      Me.New(permiteSinSeleccion:=True, concatenarNombreDeposito:=concatenarNombreDeposito)
   End Sub
   Public Sub New(permiteSinSeleccion As Boolean, concatenarNombreDeposito As Boolean)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      _ConcatenarNombreDeposito = concatenarNombreDeposito
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.SucursalDeposito)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdDeposito")
      _columnasAMostrar.Add("NombreDeposito")
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
         .Columns("IdDeposito").FormatearColumna("Código Depósito", pos, 120, HAlign.Right)
         .Columns("NombreDeposito").FormatearColumna("Nombre Depósito", pos, 340, HAlign.Left)
      End With
   End Sub
   Protected Overrides Sub AgregarTodos()
      Me._filtros = GetTodos(Sucursales)
      Me.RefrescoDatosGrilla()
   End Sub
   Public Shared Function GetTodos(sucursales As Entidades.Sucursal()) As List(Of Entidades.SucursalDeposito)
      Dim reg = New Reglas.SucursalesDepositos()
      Return reg.GetTodos(sucursales)
   End Function
   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub
   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim ma As Entidades.SucursalDeposito
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col = From filt In filtros Where filt.IdRegistro = i
      While System.Linq.Enumerable.Count(col) > 0
         ma = New Entidades.SucursalDeposito()
         For Each c As Entidades.FiltroValor In col
            If c.IdColumna = "IdDeposito" Then
               ma.IdDeposito = c.Valor.ToInt32().IfNull()
            ElseIf c.IdColumna = "NombreDeposito" Then
               ma.NombreDeposito = c.Valor
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

   Private Sub CargarDeposito(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreDeposito").Value.ToString()
         bscCodigo.Text = dr.Cells("IdDeposito").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaDeposito2(bscCodigo)
            Dim cod As Integer = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.SucursalesDepositos().GetTodosDeposito(cod)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaDeposito2(bscNombre)
            bscNombre.Datos = New Reglas.SucursalesDepositos().GetDepositoNombres(bscNombre.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarDeposito(e.FilaDevuelta))
   End Sub
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep = New Entidades.SucursalDeposito()
         ep.IdDeposito = Int32.Parse(Me.bscCodigo.Text)
         ep.NombreDeposito = Me.bscNombre.Text
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

         For Each pr As Entidades.SucursalDeposito In Me._filtros
            If pr.IdDeposito = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdDeposito").Value.ToString()) Then
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
End Class