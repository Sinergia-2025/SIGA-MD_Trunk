#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class ClasificacionesABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ClasificacionesDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.Clasificacion))
      End If
      Return New ClasificacionesDetalle(New Eniac.Entidades.Clasificacion)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Clasificaciones()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim Clasificacion As Eniac.Entidades.Clasificacion = New Eniac.Entidades.Clasificacion
      With Me.dgvDatos.ActiveRow
         Clasificacion = New Eniac.Reglas.Clasificaciones().GetUno(Integer.Parse(.Cells("IdClasificacion").Value.ToString()))
      End With
      Return Clasificacion
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Eniac.Entidades.Clasificacion.Columnas.IdClasificacion.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Eniac.Entidades.Clasificacion.Columnas.NombreClasificacion.ToString()).FormatearColumna("Nombre", col, 400)
      End With
   End Sub
#End Region
End Class