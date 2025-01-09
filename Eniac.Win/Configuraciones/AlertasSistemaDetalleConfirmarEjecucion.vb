Public Class AlertasSistemaDetalleConfirmarEjecucion

   Private _variables As Reglas.Sistema.AlertasSistema.VariablesAlerta
   Public Property Variables() As Reglas.Sistema.AlertasSistema.VariablesAlerta
      Get
         Return _variables
      End Get
      Private Set(value As Reglas.Sistema.AlertasSistema.VariablesAlerta)
         _variables = value
      End Set
   End Property

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         Dim lst = New Reglas.Sistema.AlertasSistema.VariablesAlerta().Inicializar(Reglas.Sistema.AlertasSistema.DestinoListaVariables.Consulta)
         ugVariablesConsulta.DataSource = lst
         ugVariablesConsulta.DisplayLayout.PerformAutoResizeColumns(sizeHiddenColumns:=False, PerformAutoSizeType.AllRowsInBand)
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

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()
         ugVariablesConsulta.UpdateData()
         Variables = ugVariablesConsulta.DataSource(Of Reglas.Sistema.AlertasSistema.VariablesAlerta)
         Close(DialogResult.OK)
      End Sub)
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub
End Class