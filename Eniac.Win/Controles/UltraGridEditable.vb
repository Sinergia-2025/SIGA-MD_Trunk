Imports System.ComponentModel
Public Class UltraGridEditable
   Inherits UltraGridSiga

   Private PrimerColumnaVisible As UltraGridColumn

   Private _enterMueveACeldaDeAbajo As Boolean
   <DefaultValue(False), Category("Eniac")>
   Public Property EnterMueveACeldaDeAbajo() As Boolean
      Get
         Return _enterMueveACeldaDeAbajo
      End Get
      Set(ByVal value As Boolean)
         _enterMueveACeldaDeAbajo = value
      End Set
   End Property


   Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
      Try
         'If Me.EnterMueveACeldaDeAbajo Then
         BuscarPrimerColumnaVisible()

         If ActiveCell IsNot Nothing AndAlso
            (ActiveCell.IsInEditMode Or
             (e.KeyCode = Keys.Home And e.Control = True And Not e.Alt And Not e.Shift) Or
             (e.KeyCode = Keys.End And e.Control = True And Not e.Alt And Not e.Shift)) Then
            ''If the pressed key is not valid for movement, we cancel the execution on the method.
            If e.KeyCode = System.Windows.Forms.Keys.Up Or e.KeyCode = System.Windows.Forms.Keys.Down Or
               e.KeyCode = System.Windows.Forms.Keys.Right Or e.KeyCode = System.Windows.Forms.Keys.Left Or
               e.KeyCode = System.Windows.Forms.Keys.Enter Or
               e.KeyCode = Keys.Home Or e.KeyCode = Keys.End Then

               PerformAction(UltraGridAction.ExitEditMode, False, False)

               If e.KeyCode = System.Windows.Forms.Keys.Up And Not e.Alt And Not e.Control And Not e.Shift Then
                  PerformAction(UltraGridAction.AboveCell, False, False)
               ElseIf e.KeyCode = System.Windows.Forms.Keys.Down And Not e.Alt And Not e.Control And Not e.Shift Then
                  PerformAction(UltraGridAction.BelowCell, False, False)
               ElseIf e.KeyCode = System.Windows.Forms.Keys.Right And Not e.Alt And Not e.Control And Not e.Shift Then
                  PerformAction(UltraGridAction.NextCellByTab, False, False)
               ElseIf e.KeyCode = System.Windows.Forms.Keys.Left And Not e.Alt And Not e.Control And Not e.Shift Then
                  PerformAction(UltraGridAction.PrevCellByTab, False, False)
               ElseIf e.KeyCode = System.Windows.Forms.Keys.Enter And Not e.Alt And Not e.Control And Not e.Shift Then
                  If Me.EnterMueveACeldaDeAbajo Then
                     Me.IrACeldaDeAbajo()
                  Else
                     MoverSiguienteCeldaEditable(False)
                  End If
               ElseIf e.KeyCode = Keys.Home And e.Control = True And Not e.Alt And Not e.Shift Then
                  IrPrimerCeldaEditable()
               ElseIf e.KeyCode = Keys.End And e.Control = True And Not e.Alt And Not e.Shift Then
                  MoverSiguienteCeldaEditable(True)
               End If

               PerformAction(UltraGridAction.EnterEditMode, False, False)
               e.Handled = True
            End If
         End If
         'Else

         'End If

      Catch ex As Exception
         FindForm().ShowError(ex)
      End Try

      MyBase.OnKeyDown(e)
   End Sub

   Public Sub IrPrimerCeldaEditable()
      BuscarPrimerColumnaVisible()
      ActiveCell = Rows(0).Cells(PrimerColumnaVisible.Key)
      If (Not ActiveCell.CanEnterEditMode Or (ActiveCell.Activation <> Activation.AllowEdit Or ActiveCell.Column.CellActivation <> Activation.AllowEdit)) Then
         MoverSiguienteCeldaEditable(False)
      End If
      PerformAction(UltraGridAction.EnterEditMode, False, False)
   End Sub

   Public Sub IrACeldaDeAbajo()
      PerformAction(UltraGridAction.BelowCell, False, False)
   End Sub

   Public Sub MoverSiguienteCeldaEditable(hastaElFinal As Boolean)

      Dim celda As UltraGridCell = ActiveCell
      '' find the next editable cell
      PerformAction(UltraGridAction.NextCell)

      If ActiveCell IsNot Nothing Then
         While (Not ActiveCell.CanEnterEditMode Or (ActiveCell.Activation <> Activation.AllowEdit Or ActiveCell.Column.CellActivation <> Activation.AllowEdit) Or hastaElFinal)
            PerformAction(UltraGridAction.NextCell)

            '' have we reached the end?
            '' give up
            If ActiveCell Is Nothing Then Return

            '' we aren't going anywhere, give up
            If ActiveCell.Equals(celda) Then Return

            If PrimerColumnaVisible Is Nothing Then BuscarPrimerColumnaVisible()
            '' looped around, so give up
            If (ActiveCell.Row.Index = 0) And (PrimerColumnaVisible Is Nothing OrElse ActiveCell.Column.Key = PrimerColumnaVisible.Key) Then Return

            celda = ActiveCell
         End While

         If (celda.CanEnterEditMode) Then
            PerformAction(UltraGridAction.EnterEditMode)
            ActiveRowScrollRegion.ScrollCellIntoView(ActiveCell, DisplayLayout.ColScrollRegions(0))
         End If
      End If
   End Sub

   Private Sub BuscarPrimerColumnaVisible()
      If ActiveCell Is Nothing Then
         If ActiveRow Is Nothing Then
            If Rows.Count = 0 Then
               '' empty grid, so no way to give a cell focus
               Return
            End If
            ActiveRow = Rows(0)
         End If
         '' make the leftmost cell the active cell -- will find the first editable cell below
         PrimerColumnaVisible = ActiveRow.Cells(0).Column.GetRelatedVisibleColumn(VisibleRelation.First)
         ActiveCell = ActiveRow.Cells(PrimerColumnaVisible)
      Else
         PrimerColumnaVisible = ActiveCell.Column.GetRelatedVisibleColumn(VisibleRelation.First)
      End If
   End Sub

End Class