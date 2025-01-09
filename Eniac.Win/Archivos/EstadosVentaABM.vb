Option Strict On
Option Explicit On
Public Class EstadosVentaABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New EstadosVentaDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.EstadoVenta))
      End If
      Return New EstadosVentaDetalle(New Entidades.EstadoVenta())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.EstadosVenta()
   End Function
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      With dgvDatos.ActiveCell.Row
         Return New Reglas.EstadosVenta().GetUno(Integer.Parse(.Cells(Entidades.EstadoVenta.Columnas.IdEstadoVenta.ToString()).Value.ToString()),
                                                 Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.EstadoVenta.Columnas.IdEstadoVenta.ToString()).FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns(Entidades.EstadoVenta.Columnas.NombreEstadoVenta.ToString()).FormatearColumna("Nombre", pos, 250)
         .Columns(Entidades.EstadoVenta.Columnas.IdTipoMovimiento.ToString()).FormatearColumna("Tipo Movimiento NC", pos, 100)

      End With
   End Sub
#End Region
End Class