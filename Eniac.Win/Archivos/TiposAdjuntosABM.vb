Option Strict On
Option Explicit On
Public Class TiposAdjuntosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False

      Ayudante.Grilla.AgregarFiltroEnLinea(dgvDatos, {Entidades.TipoAdjunto.Columnas.NombreTipoAdjunto.ToString()})
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposAdjuntosDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoAdjunto))
      End If
      Return New TiposAdjuntosDetalle(New Eniac.Entidades.TipoAdjunto())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.TiposAdjuntos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.TiposAdjuntos().GetUno(Integer.Parse(.Cells(Entidades.TipoAdjunto.Columnas.IdTipoAdjunto.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoAdjunto.Columnas.IdTipoAdjunto.ToString()),
                                          "Código", col, 100, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoAdjunto.Columnas.NombreTipoAdjunto.ToString()),
                                          "Nombre", col, 400)
      End With
   End Sub

#End Region
End Class