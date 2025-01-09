Option Explicit On
Option Strict On

Public Class ContabilidadPlanesCuentasPreView

#Region "Campos"

   Private _publicos As ContabilidadPublicos

#End Region

#Region "Propiedades"

   Private _IdPlanCuenta As Integer
   <Obsolete("Ver de quitar")>
   Public Property IdPlanCuenta() As Integer
      Get
         Return _IdPlanCuenta
      End Get
      Set(ByVal value As Integer)
         _IdPlanCuenta = value
      End Set
   End Property


   Private _cuenta As Entidades.ContabilidadCuenta
   Public Property Cuenta() As Entidades.ContabilidadCuenta
      Get
         Return _cuenta
      End Get
      Private Set(ByVal value As Entidades.ContabilidadCuenta)
         _cuenta = value
      End Set
   End Property

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ContabilidadPlanCuenta)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region


   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New ContabilidadPublicos()

      Me._publicos.ConfigurarArbol(Me.trvPlan)

      If Modal Then
         btnAceptar.Visible = True
         btnCancelar.Visible = True
         tsbSalir.Visible = False
         ''tstBarra.Visible = False
      Else
         btnAceptar.Visible = False
         btnCancelar.Visible = False
         tsbSalir.Visible = True
         ''tstBarra.Visible = True
      End If

      Me.Text = "Consultar Plan de Cuentas por Jerarquia"

      Me.tssRegistros.Text = Me.trvPlan.GetNodeCount(True).ToString() & " Registros"

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadPlanesCuentas
   End Function

   Private Sub trvPlan_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvPlan.AfterSelect
      If e.Node IsNot Nothing Then
         Me.lblDetalle.Text = e.Node.FullPath
      End If
   End Sub

   Private Sub trvPlan_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvPlan.DoubleClick
      Try
         Confirmar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Sub Aceptar()
      ''MyBase.Aceptar()
   End Sub

   Private Sub Confirmar()
      If Not Modal Then Exit Sub
      If trvPlan.SelectedNode IsNot Nothing AndAlso trvPlan.SelectedNode.Tag IsNot Nothing AndAlso
         TypeOf (trvPlan.SelectedNode.Tag) Is DataRow Then
         Cuenta = New Reglas.ContabilidadCuentas().GetUna(CLng(DirectCast(trvPlan.SelectedNode.Tag, DataRow)(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString())))

         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      End If
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         Confirmar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.trvPlan.Nodes.Clear()

         Me._publicos.ConfigurarArbol(Me.trvPlan)

         Me.tssRegistros.Text = Me.trvPlan.GetNodeCount(True).ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub tstBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tstBuscar.KeyUp
      If e.KeyCode = Keys.Enter Then
         Me.tsbFiltrar.PerformClick()
      End If
   End Sub

   Private Sub tsbFiltrar_Click(sender As Object, e As EventArgs) Handles tsbFiltrar.Click
      Me.Cursor = Cursors.WaitCursor
      Try
         Me.Buscar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
      Me.Cursor = Cursors.Default
   End Sub

   Private Sub Buscar()
      If Not String.IsNullOrWhiteSpace(tstBuscar.Text) Then
         If trvPlan.SelectedNode Is Nothing Then
            trvPlan.SelectedNode = trvPlan.Nodes(0)
         End If
         Dim node As TreeNode = Buscar(trvPlan.Nodes, tstBuscar.Text, False)
         If node Is Nothing AndAlso Not trvPlan.SelectedNode.Equals(trvPlan.Nodes(0)) Then
            node = Buscar(trvPlan.Nodes, tstBuscar.Text, True)
         End If
         'If node IsNot Nothing Then
         trvPlan.SelectedNode = node
         'End If
         trvPlan.Focus()
      End If
   End Sub

   Private Function Buscar(nodes As TreeNodeCollection, texto As String, ByRef startSearching As Boolean) As TreeNode
      For Each node As TreeNode In nodes
         If node.Equals(trvPlan.SelectedNode) Then
            startSearching = True
         ElseIf startSearching AndAlso node.Text.ToUpper().Contains(texto.ToUpper()) Then
            Return node
         End If
         If node.Nodes.Count > 0 Then
            Dim node1 As TreeNode = Buscar(node.Nodes, texto, startSearching)
            If node1 IsNot Nothing Then Return node1
         End If
      Next
      Return Nothing
   End Function

   Private Sub trvPlan_KeyUp(sender As Object, e As KeyEventArgs) Handles trvPlan.KeyUp
      If e.KeyCode = Keys.Enter Then
         Confirmar()
      ElseIf e.KeyCode = Keys.F3 Then
         Buscar()
      End If
   End Sub
End Class