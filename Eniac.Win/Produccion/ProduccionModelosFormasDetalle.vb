Public Class ProduccionModelosFormasDetalle
#Region "Campos"
   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
   Private _decimalesValores As Integer
   Private _formatoValores As String
   Private _maskInputValores As String
   Private _ceroValores As String
#End Region

   Private ReadOnly Property Modelo As Entidades.ProduccionModeloForma
      Get
         Return DirectCast(_entidad, Entidades.ProduccionModeloForma)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.ProduccionModeloForma)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(
      Sub()
         _publicos.CargaComboProduccionModeloFormaVariable(cmbCodigoVariable)

         _decimalesValores = Reglas.Publicos.ProduccionDecimalesVariablesModeloForma
         _formatoValores = Formatos.Format.CustomDecimales(_decimalesValores)
         _maskInputValores = Formatos.MaskInput.CustomMaskInput(18 - _decimalesValores, _decimalesValores)
         _ceroValores = 0.ToString(_formatoValores)

         txtValorDecimalVariable.Text = _ceroValores
         txtValorDecimalVariable.Formato = _formatoValores
         ugVariables.DisplayLayout.Bands(0).Columns("ValorDecimalVariable").Format = _formatoValores
         ugVariables.DisplayLayout.Bands(0).Columns("ValorDecimalVariable").MaskInput = _maskInputValores

         BindearControles(_entidad)
         If StateForm = Eniac.Win.StateForm.Insertar Then
            CargarProximoCodigo()
         End If
         _tit = GetColumnasVisiblesGrilla(ugVariables)
         ugVariables.DataSource = Modelo.Variables
         AjustarColumnasGrilla(ugVariables, _tit)

      End Sub)
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ProduccionModelosFormas()
   End Function
   Protected Overrides Sub Aceptar()
      ugVariables.UpdateData()
      MyBase.Aceptar()
   End Sub
#End Region

#Region "Eventos"
   Private Sub cmbCodigoVariable_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown, txtNombre.KeyDown, cmbCodigoVariable.KeyDown, txtValorDecimalVariable.KeyDown
      PresionarTab(e)
   End Sub
   Private Sub btnInsertarComentario_Click(sender As Object, e As EventArgs) Handles btnInsertarComentario.Click
      TryCatched(Sub() InsertarVariable())
   End Sub
   Private Sub ugVariables_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles ugVariables.InitializeLayout
      TryCatched(Sub() EditarVariable())
   End Sub
   Private Sub btnEliminarComentario_Click(sender As Object, e As EventArgs) Handles btnEliminarComentario.Click
      TryCatched(Sub() EliminarVariable())
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarProximoCodigo()
      Dim rProduccionModelosFormasDetalle = New Reglas.ProduccionModelosFormas()
      Dim proximo = rProduccionModelosFormasDetalle.GetCodigoMaximo() + 1
      txtCodigo.SetValor(proximo)
   End Sub
   Private Sub InsertarVariable()
      If String.IsNullOrWhiteSpace(cmbCodigoVariable.Text) Then
         Throw New Exception("Debe ingresar un nombre de variable")
      End If
      Dim lst = ugVariables.DataSource(Of List(Of Entidades.ProduccionModeloFormaVariable))
      If lst.Any(Function(v) v.CodigoVariable = cmbCodigoVariable.Text) Then
         Throw New Exception(String.Format("La variable {0} ya existe. Verifique", cmbCodigoVariable.Text))
      End If

      If Not cmbCodigoVariable.ExistsItem(cmbCodigoVariable.Text) Then
         If ShowPregunta("La variable {1} no existe{0}{0}¿Desea agregar la misma?", Environment.NewLine, cmbCodigoVariable.Text) = DialogResult.Yes Then
            cmbCodigoVariable.Items.Add(cmbCodigoVariable.Text)
         Else
            Exit Sub
         End If
      End If

      lst.Add(New Entidades.ProduccionModeloFormaVariable() With
               {
                  .CodigoVariable = cmbCodigoVariable.Text,
                  .ValorDecimalVariable = txtValorDecimalVariable.ValorNumericoPorDefecto(0D)
               })
      ugVariables.Rows.Refresh(RefreshRow.FireInitializeRow)
   End Sub
   Private Sub EditarVariable()
      Dim dr = ugVariables.FilaSeleccionada(Of Entidades.ProduccionModeloFormaVariable)
      If dr IsNot Nothing Then
         cmbCodigoVariable.Text = dr.CodigoVariable
         txtValorDecimalVariable.SetValor(dr.ValorDecimalVariable)
         Dim lst = ugVariables.DataSource(Of List(Of Entidades.ProduccionModeloFormaVariable))
         lst.Remove(dr)
         ugVariables.Rows.Refresh(RefreshRow.FireInitializeRow)

         cmbCodigoVariable.Focus()
      End If
   End Sub
   Private Sub EliminarVariable()
      Dim dr = ugVariables.FilaSeleccionada(Of Entidades.ProduccionModeloFormaVariable)
      If dr IsNot Nothing Then
         If dr IsNot Nothing Then
            If ShowPregunta(String.Format("¿Desea eliminar la variable {0}?", dr.CodigoVariable)) = DialogResult.Yes Then
               Dim lst = ugVariables.DataSource(Of List(Of Entidades.ProduccionModeloFormaVariable))
               lst.Remove(dr)
               ugVariables.Rows.Refresh(RefreshRow.FireInitializeRow)
            End If
         End If
      End If
   End Sub


#End Region

End Class