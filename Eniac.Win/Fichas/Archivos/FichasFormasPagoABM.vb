Option Strict Off
Public Class FichasFormasPagoABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New FichasFormasPagoDetalle(Me.GetEntidad())
      End If
      Return New FichasFormasPagoDetalle(New Eniac.Entidades.FichaFormaPago)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.FichasFormasPago()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes(My.Application.Info.AssemblyName & ".FichasFormasPago.rdlc", "SistemaDataSet_Localidades", Me.dtDatos, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Formas de pago"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim forma As Eniac.Entidades.FichaFormaPago = New Eniac.Entidades.FichaFormaPago
      With Me.dgvDatos.SelectedCells(0).OwningRow
         forma.IdFormasPago = Int32.Parse(.Cells("IdFormasPago").Value.ToString())
         forma.DescripcionFormasPago = .Cells("DescripcionFormasPago").Value.ToString()
         forma.Dias = Int32.Parse(.Cells("Dias").Value.ToString())
      End With
      Return forma
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns("IdFormasPago").HeaderText = "Id"
         .Columns("IdFormasPago").Width = 50
         .Columns("DescripcionFormasPago").HeaderText = "Descripción"
         .Columns("DescripcionFormasPago").Width = 240
         .Columns("Dias").HeaderText = "Días"
         .Columns("Dias").Width = 120
         .Columns("Dias").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      End With
   End Sub

#End Region

End Class

