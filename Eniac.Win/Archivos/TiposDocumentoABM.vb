Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class TiposDocumentoABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposDocumentoDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoDocumento))
      End If
      Return New TiposDocumentoDetalle(New Entidades.TipoDocumento)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposDocumento
   End Function
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim TipoDoc As Entidades.TipoDocumento = New Entidades.TipoDocumento
      With Me.dgvDatos.SelectedCells(0).OwningRow
         TipoDoc.TipoDocumento = .Cells("TipoDocumento").Value.ToString()
         TipoDoc.NombreTipoDocumento = .Cells("NombreTipoDocumento").Value.ToString()
         If Not String.IsNullOrEmpty(.Cells("EsAutoincremental").Value.ToString()) Then
            TipoDoc.EsAutoincremental = Boolean.Parse(.Cells("EsAutoincremental").Value.ToString())
         End If
      End With
      Return TipoDoc
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns("TipoDocumento").HeaderText = "Tipo"
         .Columns("TipoDocumento").Width = 50
         .Columns("NombreTipoDocumento").HeaderText = "Localidad"
         .Columns("NombreTipoDocumento").Width = 120
         .Columns("NombreTipoDocumento").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
         .Columns("EsAutoincremental").HeaderText = "Auto"
         .Columns("EsAutoincremental").Width = 50
      End With
   End Sub

#End Region

End Class
