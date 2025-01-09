Public Class ConcesionarioOperacionesAdicionales

   Private Property Operacion As Entidades.ConcesionarioOperacion
   Private ReadOnly Property AdicionalesGrilla As List(Of Entidades.ConcesionarioOperacionAdicional)
      Get
         Return DirectCast(ugAdicionales.DataSource, List(Of Entidades.ConcesionarioOperacionAdicional))
      End Get
   End Property

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() CargaAdicionales())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Public Overloads Function ShowDialog(owner As IWin32Window, operacion As Entidades.ConcesionarioOperacion) As DialogResult
      Me.Operacion = operacion
      Return ShowDialog(owner)
   End Function



   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Cancelar())
   End Sub
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub

   Private Sub ugAdicionales_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugAdicionales.InitializeRow
      TryCatched(
         Sub()
            Dim dr = ugAdicionales.FilaSeleccionada(Of Entidades.ConcesionarioOperacionAdicional)(e.Row)
            e.Row.Cells("SelecAdicional").Color(Color.Black, Color.Cyan)
            If dr.SelecAdicional Then
               If dr.SolicitaDetalleAdicional Then
                  e.Row.Cells("DetalleAdicional").Activation = Activation.AllowEdit
                  e.Row.Cells("DetalleAdicional").Color(Color.Black, Color.Cyan)
               Else
                  e.Row.Cells("DetalleAdicional").Activation = Activation.ActivateOnly
                  e.Row.Cells("DetalleAdicional").Color(Color.Black, Color.White)
               End If

               e.Row.Cells("PrecioAdicional").Activation = Activation.AllowEdit
               e.Row.Cells("PrecioAdicional").Color(Color.Black, Color.Cyan)

            Else
               e.Row.Cells("DetalleAdicional").Activation = Activation.NoEdit
               e.Row.Cells("PrecioAdicional").Activation = Activation.NoEdit

               e.Row.Cells("DetalleAdicional").Color(Color.Black, Color.White)
               e.Row.Cells("PrecioAdicional").Color(Color.Black, Color.White)

            End If
         End Sub)
   End Sub
   Private Sub ugAdicionales_CellChange(sender As Object, e As CellEventArgs) Handles ugAdicionales.CellChange
      TryCatched(
         Sub()
            If e.Cell.Column.Key = "SelecAdicional" Then
               ugAdicionales.UpdateData()
            End If
         End Sub)
   End Sub
   Private Sub ugAdicionales_CellDataError(sender As Object, e As CellDataErrorEventArgs) Handles ugAdicionales.CellDataError

   End Sub

   Private Sub CargaAdicionales()
      Dim adics = New Reglas.ConcesionariosAdicionales().GetTodos()
      Dim opAdic = adics.ConvertAll(Function(a) New Entidades.ConcesionarioOperacionAdicional() With
                                                            {
                                                               .SelecAdicional = False,
                                                               .IdAdicional = a.IdAdicional,
                                                               .NombreAdicional = a.NombreAdicional,
                                                               .DetalleAdicional = String.Empty,
                                                               .PrecioAdicional = 0,
                                                               .SolicitaDetalleAdicional = a.SolicitaDetalle
                                                            })
      opAdic.ForEach(
               Sub(aGrilla)
                  Dim aSeleccionadas = Operacion.Adicionales.FirstOrDefault(Function(a1) a1.IdAdicional = aGrilla.IdAdicional)
                  If aSeleccionadas IsNot Nothing Then
                     aGrilla.DetalleAdicional = aSeleccionadas.DetalleAdicional
                     aGrilla.SelecAdicional = True
                     aGrilla.PrecioAdicional = aSeleccionadas.PrecioAdicional
                  End If
               End Sub)
      ugAdicionales.DataSource = opAdic

      ugAdicionales.AgregarFiltroEnLinea({"NombreAdicional", "DetalleAdicional"})
      ugAdicionales.AgregarTotalesSuma({"PrecioAdicional"})
   End Sub
   Private Sub Aceptar()
      Operacion.Adicionales = AdicionalesGrilla.FindAll(Function(a) a.SelecAdicional)
      DialogResult = DialogResult.OK
      Close()
   End Sub
   Private Sub Cancelar()
      DialogResult = DialogResult.Cancel
      Close()
   End Sub

   'Private Sub ugAdicionales_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugAdicionales.AfterCellUpdate
   '   TryCatched(
   '      Sub()
   '         'If e.Cell.Column.Key = "SelecAdicional" Then
   '         '   Dim dr = ugAdicionales.FilaSeleccionada(Of Entidades.ConcesionarioOperacionAdicional)(e.Cell.Row)
   '         '   If dr IsNot Nothing Then
   '         '      e.Cell.Row.Cells("PrecioAdicional").Activation = If(dr.SelecAdicional, Activation.AllowEdit, Activation.NoEdit)
   '         '      e.Cell.Row.Cells("DetalleAdicional").Activation = If(dr.SelecAdicional And dr.SolicitaDetalleAdicional, Activation.AllowEdit, Activation.NoEdit)
   '         '   End If
   '         'End If
   '      End Sub)
   'End Sub
End Class