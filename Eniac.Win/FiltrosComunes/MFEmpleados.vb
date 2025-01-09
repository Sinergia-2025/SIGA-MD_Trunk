Public Class MFEmpleados
   Public Const TipoFiltroKey As String = "EMPLEADOS"

#Region "Campos"
   Private _filtros As List(Of Entidades.Empleado)
   Public ReadOnly Property Filtros() As List(Of Entidades.Empleado)
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
      _filtros = New List(Of Entidades.Empleado)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdEmpleado")
      _columnasAMostrar.Add("NombreEmpleado")
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
         .Columns("IdEmpleado").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreEmpleado").FormatearColumna("Nombre", pos, 300)
      End With

   End Sub
   Protected Overrides Sub AgregarTodos()
      _filtros = GetTodas()
      RefrescoDatosGrilla()
   End Sub
   Public Shared Function GetTodas() As List(Of Entidades.Empleado)
      Return New Reglas.Empleados().GetTodos(False)
   End Function
   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub
   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim emp As Entidades.Empleado
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While col.Count > 0
         emp = New Entidades.Empleado()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdEmpleado"
                  emp.IdEmpleado = Integer.Parse(c.Valor)
               Case "NombreEmpleado"
                  emp.NombreEmpleado = c.Valor
            End Select
         Next
         Me.Filtros.Add(emp)
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
            _publicos.PreparaGrillaEmpleados(bscCodigo)
            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = New Reglas.Empleados().GetFiltradoPorCodigo(cod)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaEmpleados(bscNombre)
            bscNombre.Datos = New Reglas.Empleados().GetFiltradoPorNombre(bscNombre.Text)
         End Sub)
   End Sub
   Private Sub bscCodigoNombre_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarMarca(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim emp = New Entidades.Empleado()
         emp.IdEmpleado = Int32.Parse(Me.bscCodigo.Text)
         emp.NombreEmpleado = Me.bscNombre.Text
         Me._filtros.Add(emp)
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

         For Each pr As Entidades.Empleado In Me._filtros
            If pr.IdEmpleado = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdEmpleado").Value.ToString()) Then
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
   Private Sub CargarMarca(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreEmpleado").Value.ToString()
         bscCodigo.Text = dr.Cells("IdEmpleado").Value.ToString.Trim()
         btnInsertar.PerformClick()
      End If
   End Sub
#End Region
End Class