Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinGrid

Public Class ProduccionProcesosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProduccionProcesosDetalle(DirectCast(Me.GetEntidad(), Entidades.ProduccionProceso))
      End If
      Return New ProduccionProcesosDetalle(New Entidades.ProduccionProceso())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.ProduccionProcesos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      With Me.dgvDatos.ActiveRow
         Return New Reglas.ProduccionProcesos().GetUno(Int32.Parse(.Cells("IdProduccionProceso").Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next
         Dim col As Integer = 0
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ProduccionProceso.Columnas.IdProduccionProceso.ToString()),
                                          "Código", col, 70, HAlign.Right)

         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ProduccionProceso.Columnas.NombreProduccionProceso.ToString()),
                                          "Nombre Proceso", col, 300)

      End With
   End Sub

#End Region

End Class