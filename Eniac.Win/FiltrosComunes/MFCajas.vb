Public Class MFCajas
   Public Const TipoFiltroKey As String = "CAJASNOMBRES"

#Region "Campos"
   Private _filtros As List(Of Entidades.CajaNombre)
   Public ReadOnly Property Filtros() As List(Of Entidades.CajaNombre)
      Get
         Return _filtros
      End Get
   End Property

   Private _blnMiraUsuario As Boolean
   Private _blnMiraPC As Boolean
   Private _blnCajasModificables As Boolean

   Public Property SucursalesSeleccionadas As Entidades.Sucursal()
#End Region

#Region "Constructores"
   Public Sub New(blnMiraUsuario As Boolean, blnMiraPC As Boolean, blnCajasModificables As Boolean)
      Me.New(blnMiraUsuario, blnMiraPC, blnCajasModificables, permiteSinSeleccion:=False)
   End Sub
   Public Sub New(blnMiraUsuario As Boolean, blnMiraPC As Boolean, blnCajasModificables As Boolean, permiteSinSeleccion As Boolean)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.CajaNombre)()
      _columnasAMostrar = New List(Of String)()
      _columnasAMostrar.Add("IdCaja")
      _columnasAMostrar.Add("NombreCaja")
      _blnMiraUsuario = blnMiraUsuario
      _blnMiraPC = blnMiraPC
      _blnCajasModificables = blnCajasModificables
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      If SucursalesSeleccionadas Is Nothing Then SucursalesSeleccionadas = {actual.Sucursal}

      dgvDatos.DataSource = _filtros.ToArray()

      MyBase.RefrescoDatosGrilla()

      dgvDatos.DisplayLayout.Bands(0).Columns("IdSucursal").Header.Caption = "Suc."
      dgvDatos.DisplayLayout.Bands(0).Columns("IdSucursal").Width = 50
      dgvDatos.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = SucursalesSeleccionadas.Count < 2

      If SucursalesSeleccionadas.Count > 1 Then
         If Not _columnasAMostrar.Contains("IdSucursal") Then
            Me._columnasAMostrar.Add("IdSucursal")
         End If
      Else
         If _columnasAMostrar.Contains("IdSucursal") Then
            Me._columnasAMostrar.Remove("IdSucursal")
         End If
      End If

      dgvDatos.DisplayLayout.Bands(0).Columns("IdCaja").Header.Caption = "Código"
      dgvDatos.DisplayLayout.Bands(0).Columns("IdCaja").Width = 100

      dgvDatos.DisplayLayout.Bands(0).Columns("NombreCaja").Header.Caption = "Caja"
      dgvDatos.DisplayLayout.Bands(0).Columns("NombreCaja").Width = 240

   End Sub

   Protected Overrides Sub AgregarTodos()
      _filtros = GetTodas(SucursalesSeleccionadas, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)
      Me.RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas(sucursales As Entidades.Sucursal(), blnMiraUsuario As Boolean, blnMiraPC As Boolean, blnCajasModificables As Boolean) As List(Of Entidades.CajaNombre)
      Return GetTodas(sucursales, If(blnMiraUsuario, Eniac.Entidades.Usuario.Actual.Nombre, ""), If(blnMiraPC, My.Computer.Name, ""), blnCajasModificables)
   End Function
   Public Shared Function GetTodas(sucursales As Entidades.Sucursal(), usuario As String, nombrePC As String, cajasModificables As Boolean) As List(Of Entidades.CajaNombre)
      Dim reg As Reglas.CajasUsuarios = New Reglas.CajasUsuarios()
      If sucursales Is Nothing Then sucursales = {Entidades.Usuario.Actual.Sucursal}
      Return reg.GetCajasTodas(sucursales, usuario, nombrePC, cajasModificables)
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      Me.dgvDatos.DataSource = Me._filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros As List(Of Entidades.FiltroValor) = New Reglas.FiltrosValores().GetTodosPorTipoNombre(Me._tipoFiltro, Me._nombreFiltro)
      Dim en As Entidades.CajaNombre
      Dim i As Integer = 0
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While col.Count > 0
         en = New Entidades.CajaNombre()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case "IdCaja"
                  en.IdCaja = Integer.Parse(c.Valor)
               Case "NombreCaja"
                  en.NombreCaja = c.Valor
            End Select
         Next
         Me.Filtros.Add(en)
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
      Try
         Dim oRegla As Reglas.CajasUsuarios = New Reglas.CajasUsuarios()
         _publicos.PreparaGrillaCajasUsuarios(bscCodigo, SucursalesSeleccionadas.Count > 1)
         Dim cod As Integer = 0
         Integer.TryParse(Me.bscCodigo.Text.ToString(), cod)

         Dim sucs As Entidades.Sucursal()
         If SucursalesSeleccionadas IsNot Nothing Then
            sucs = SucursalesSeleccionadas
         Else
            sucs = {actual.Sucursal}
         End If

         Me.bscCodigo.Datos = oRegla.GetCajas(sucs, If(_blnMiraUsuario, Eniac.Entidades.Usuario.Actual.Nombre, ""), If(_blnMiraPC, My.Computer.Name, ""), _blnCajasModificables)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      Try
         Dim oCaj As Reglas.CajasUsuarios = New Reglas.CajasUsuarios()
         'If bscNombre._ayudaSeleccion.dgvDatos.Columns.Contains("IdSucursal") Then
         '   bscNombre._ayudaSeleccion.dgvDatos.Columns("IdSucursal").Visible = True
         'End If
         Me._publicos.PreparaGrillaCajasUsuarios(bscNombre, SucursalesSeleccionadas.Count > 1)

         Dim sucs As Entidades.Sucursal()
         If SucursalesSeleccionadas IsNot Nothing Then
            sucs = SucursalesSeleccionadas
         Else
            sucs = {Entidades.Usuario.Actual.Sucursal}
         End If

         Me.bscNombre.Datos = oCaj.GetCajasxNombre(Me.bscNombre.Text.Trim(), sucs, If(_blnMiraUsuario, actual.Nombre, ""), If(_blnMiraPC, My.Computer.Name, ""), _blnCajasModificables)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarCaja(e.FilaDevuelta))
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If Not (Me.bscCodigo.Selecciono Or Me.bscNombre.Selecciono) Then
            Exit Sub
         End If
         Dim ep As Entidades.CajaNombre = New Entidades.CajaNombre()
         ep.IdCaja = Int32.Parse(Me.bscCodigo.Text)
         ep.NombreCaja = Me.bscNombre.Text
         If bscCodigo.Tag IsNot Nothing AndAlso TypeOf (bscCodigo.Tag) Is DataGridViewRow Then
            ep.IdSucursal = Integer.Parse(DirectCast(bscCodigo.Tag, DataGridViewRow).Cells("IdSucursal").Value.ToString())
         End If
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

         For Each pr As Entidades.CajaNombre In Me._filtros
            If pr.IdCaja = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells("IdCaja").Value.ToString()) Then
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
   Private Sub CargarCaja(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombre.Text = dr.Cells("NombreCaja").Value.ToString()
         bscCodigo.Text = dr.Cells("IdCaja").Value.ToString.Trim()
         bscCodigo.Tag = dr
         btnInsertar.PerformClick()
      End If
   End Sub
#End Region

End Class