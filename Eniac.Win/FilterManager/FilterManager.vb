#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Public Class FilterManager
      Inherits System.ComponentModel.Component
#Region "Designer"
      <System.Diagnostics.DebuggerNonUserCode()> _
      Public Sub New(ByVal container As System.ComponentModel.IContainer)
         MyClass.New()

         'Required for Windows.Forms Class Composition Designer support
         If (container IsNot Nothing) Then
            container.Add(Me)
         End If

      End Sub

      <System.Diagnostics.DebuggerNonUserCode()> _
      Public Sub New()
         MyBase.New()

         'This call is required by the Component Designer.
         InitializeComponent()

      End Sub

      'Component overrides dispose to clean up the component list.
      <System.Diagnostics.DebuggerNonUserCode()> _
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         Try
            If disposing AndAlso components IsNot Nothing Then
               components.Dispose()
            End If
         Finally
            MyBase.Dispose(disposing)
         End Try
      End Sub

      'Required by the Component Designer
      Private components As System.ComponentModel.IContainer

      'NOTE: The following procedure is required by the Component Designer
      'It can be modified using the Component Designer.
      'Do not modify it using the code editor.
      <System.Diagnostics.DebuggerStepThrough()> _
      Private Sub InitializeComponent()
         components = New System.ComponentModel.Container()
      End Sub
#End Region

      Public Property PanelFiltro As Eniac.Controles.IPanel
      Public Property BotonRefrescar As ToolStripButton

      Private _BaseForm As BaseForm
      Private ReadOnly Property BaseForm As BaseForm
         Get
            If _BaseForm Is Nothing Then _BaseForm = GetBaseForm()
            Return _BaseForm
         End Get
      End Property
      Private Function GetBaseForm() As BaseForm
         If PanelFiltro IsNot Nothing Then
            Dim frm = PanelFiltro.FindForm()
            If frm IsNot Nothing Then
               If TypeOf (frm) Is BaseForm Then
                  Return DirectCast(frm, BaseForm)
               End If
            End If
         End If
         Return Nothing
      End Function

      Private _selectedFiltros As Entidades.FilterManager.FuncionFiltro
      Private ReadOnly Property SelectedFiltros As Entidades.FilterManager.FuncionFiltro
         Get
            If _selectedFiltros Is Nothing Then _selectedFiltros = FilterManagerHandler.Instancia.GetDefault(BaseForm.IdFuncion)
            Return _selectedFiltros
         End Get
      End Property

      Private _controles As New Dictionary(Of String, Eniac.Controles.IFilterControl)()
      Private ReadOnly Property Controles As Dictionary(Of String, Eniac.Controles.IFilterControl)
         Get
            If _controles IsNot Nothing Then _controles = FilterManagerHandler.Instancia.GetControles(PanelFiltro)
            Return _controles
         End Get
      End Property

      Public Sub Refrescar()
         FilterManagerHandler.Instancia.Refrescar(BaseForm, SelectedFiltros, Controles)
      End Sub

      Public Sub SeleccionarFiltro()
         Using frm = New FilterManagerSelector(BaseForm.IdFuncion, SelectedFiltros, PanelFiltro)
            If frm.ShowDialog(BaseForm) = DialogResult.OK Then
               _selectedFiltros = frm.FiltroSeleccionado
               If BotonRefrescar IsNot Nothing Then
                  BotonRefrescar.PerformClick()
               Else
                  Refrescar()
               End If
            End If
         End Using
      End Sub

   End Class

End Namespace