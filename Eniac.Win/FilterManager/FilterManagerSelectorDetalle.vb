#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Public Class FilterManagerSelectorDetalle
      Implements IFilterManagerSelectorDetalle
      Private _panelFiltro As Controles.IPanel

      Private _listaFiltros As List(Of SeleccionableFilterControl)
      Friend Property ListaFiltros As List(Of SeleccionableFilterControl)
         Get
            Return _listaFiltros
         End Get
         Private Set(value As List(Of SeleccionableFilterControl))
            _listaFiltros = value
         End Set
      End Property

#Region "IFilterManagerSelectorDetalle Members"
      Public ReadOnly Property ListaFiltrosSeleccionados As List(Of Controles.IFilterControl) Implements IFilterManagerSelectorDetalle.ListaFiltrosSeleccionados
         Get
            Return ListaFiltros.Where(Function(x) x.Seleccionado).ToList().ConvertAll(Function(x) DirectCast(x, Controles.IFilterControl))
         End Get
      End Property
      Friend ReadOnly Property Nombre As String Implements IFilterManagerSelectorDetalle.Nombre
         Get
            Return txtNombre.Text
         End Get
      End Property
      Friend ReadOnly Property Usuario As UsuarioActualTodos Implements IFilterManagerSelectorDetalle.Usuario
         Get
            Return cmbUsuario.ValorSeleccionado(Of UsuarioActualTodos)()
         End Get
      End Property
      Friend ReadOnly Property Sucursal As SucursalActualTodas Implements IFilterManagerSelectorDetalle.Sucursal
         Get
            Return cmbSucursal.ValorSeleccionado(Of SucursalActualTodas)()
         End Get
      End Property
#End Region

      Public Sub New()
         ' This call is required by the designer.
         InitializeComponent()
         ' Add any initialization after the InitializeComponent() call.
         ListaFiltros = New List(Of SeleccionableFilterControl)()
      End Sub
      Public Sub New(panelFiltro As Controles.IPanel, idFuncion As String)
         Me.New()
         Me._panelFiltro = panelFiltro
         Me.IdFuncion = idFuncion
      End Sub

      Protected Overrides Sub OnShown(e As EventArgs)
         Try
            Dim publicos = New Publicos()
            publicos.CargaComboDesdeEnum(cmbUsuario, GetType(UsuarioActualTodos))
            publicos.CargaComboDesdeEnum(cmbSucursal, GetType(SucursalActualTodas))
         Catch ex As Exception
            ShowError(ex)
         End Try
         MyBase.OnShown(e)
         Try
            InicializaControlesFiltros()
         Catch ex As Exception
            ShowError(ex)
         End Try
      End Sub
      Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
         Select Case keyData
            Case Keys.Escape
               btnCancelar.PerformClick()
               Return True
            Case Keys.F4
               btnAceptar.PerformClick()
               Return True

         End Select

         Return MyBase.ProcessCmdKey(msg, keyData)
      End Function

      Private Sub InicializaControlesFiltros()
         If _panelFiltro IsNot Nothing Then
            InicializaControlesFiltros(_panelFiltro)
            ugFiltros.DataSource = ListaFiltros
         End If
      End Sub
      Private Sub InicializaControlesFiltros(panel As Controles.IPanel)
         InicializaControlesFiltros(panel.Controls)
      End Sub
      Private Sub InicializaControlesFiltros(controls As Control.ControlCollection)
         For Each ctrl As Control In controls
            If TypeOf (ctrl) Is Controles.IFilterControl Then
               Dim filtro = DirectCast(ctrl, Controles.IFilterControl)
               ListaFiltros.Add(New SeleccionableFilterControl(filtro))
            End If
            If TypeOf (ctrl) Is Controles.IPanel Then
               InicializaControlesFiltros(DirectCast(ctrl, Controles.IPanel))
            End If
         Next
      End Sub

      Private Function ValidarAceptar() As Boolean
         Dim result = New ValidacionResultado()
         If String.IsNullOrWhiteSpace(txtNombre.Text) Then
            result.NuevoError("El Nombre del filtro es requerido", txtNombre)
         End If
         If cmbUsuario.SelectedIndex < 0 Then
            result.NuevoError("Debe seleccionar un valor para Usuario", cmbUsuario)
         End If
         If cmbSucursal.SelectedIndex < 0 Then
            result.NuevoError("Debe seleccionar un valor para Sucursal", cmbSucursal)
         End If
         If ListaFiltrosSeleccionados.Count = 0 Then
            result.NuevoError("Debe seleccionar algún campo para el filtro", ugFiltros)
         End If
         If result.AlgunError Then
            result.ControlParaFoco.Focus()
         End If
         Return Not result.AlgunError
      End Function

      Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
         Try
            If ValidarAceptar() Then
               FilterManagerHandler.Instancia.Guardar(IdFuncion, Me)

               DialogResult = Windows.Forms.DialogResult.OK
               Close()
            End If
         Catch ex As Exception
            ShowError(ex)
         End Try
      End Sub

      Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
         Try
            DialogResult = Windows.Forms.DialogResult.Cancel
            Close()
         Catch ex As Exception
            ShowError(ex)
         End Try
      End Sub

   End Class
End Namespace