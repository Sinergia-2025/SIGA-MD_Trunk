Imports Eniac.Win

Public Class TiposClientesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposClientesDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoCliente))
      End If
      Return New TiposClientesDetalle(New Entidades.TipoCliente())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposClientes()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim TipoCliente As Entidades.TipoCliente = New Entidades.TipoCliente()
      With Me.dgvDatos.ActiveCell.Row
         TipoCliente.IdTipoCliente = Integer.Parse(.Cells(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()).Value.ToString())
         TipoCliente.NombreTipoCliente = .Cells(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString()).Value.ToString()
      End With
      Return TipoCliente
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()).Header.Caption = "Código"
         .Columns(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()).Width = 100
         .Columns(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

         .Columns(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.TipoCliente.Columnas.NombreTipoCliente.ToString()).Width = 300
      End With
   End Sub

#End Region

End Class