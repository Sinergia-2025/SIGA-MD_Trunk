Public Class ProduccionFormasDetalle

   Private _publicos As Publicos
   Private ReadOnly Property ProduccionForma() As Entidades.ProduccionForma
      Get
         Return DirectCast(Me._entidad, Entidades.ProduccionForma)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.ProduccionForma)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
      Sub()
         _publicos = New Publicos()

         CargarVariables()

         BindearControles(_entidad)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            txtIdProduccionForma.Text = (DirectCast(GetReglas(), Reglas.ProduccionFormas).GetCodigoMaximo() + 1).ToString()
         Else

         End If
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ProduccionFormas()
   End Function
   Protected Overrides Function ValidarDetalle() As String

      MyBase.ValidarDetalle()

      Return String.Empty
   End Function
   Protected Overrides Sub Aceptar()

      MyBase.Aceptar()

      If Not HayError And StateForm = Eniac.Win.StateForm.Insertar Then
         Close()
      End If
   End Sub
#End Region

#Region "Eventos"

   Private Sub txtIdProduccionForma_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdProduccionForma.KeyDown, txtNombreProduccionForma.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub lblFormulaAnchoIntBase_DoubleClick(sender As Object, e As EventArgs)
      TryCatched(Sub() If TypeOf (sender) Is Control Then AgregarVariable(DirectCast(sender, Control).Text))
   End Sub

   Private Sub ugVariables_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugVariables.DoubleClickCell
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of Entidades.ProduccionFormasVariables)
         If dr IsNot Nothing Then
            AgregarVariable(dr.Key)
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Public Sub CargarVariables()
      ugVariables.DataSource = Reglas.ProduccionFormas.GetTodasLasValores()
   End Sub

   Public Sub AgregarVariable(variable As String)
      Dim textoAInsertar As String = variable.Split(","c)(0)
      Dim posicionAInsertar As Integer = txtFormulaCalculoKilaje.SelectionStart
      txtFormulaCalculoKilaje.Text = txtFormulaCalculoKilaje.Text.Insert(posicionAInsertar, textoAInsertar)
      txtFormulaCalculoKilaje.SelectionStart = posicionAInsertar + textoAInsertar.Length
   End Sub

#End Region

End Class