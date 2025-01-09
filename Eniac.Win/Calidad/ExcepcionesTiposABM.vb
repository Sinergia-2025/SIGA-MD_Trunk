Public Class ExcepcionesTiposABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False

      AgregarFiltroEnLinea(dgvDatos, {})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ExcepcionesTiposDetalle(DirectCast(Me.GetEntidad(), Entidades.ExcepcionTipo))
      End If
      Return New ExcepcionesTiposDetalle(New Entidades.ExcepcionTipo())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ExcepcionesTipos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim en As Entidades.ExcepcionTipo = New Entidades.ExcepcionTipo()
      With Me.dgvDatos.ActiveCell.Row
         en.IdExcepcionTipo = Integer.Parse(.Cells(Entidades.ExcepcionTipo.Columnas.IdExcepcionTipo.ToString()).Value.ToString())
         en = New Reglas.ExcepcionesTipos().GetUno(en.IdExcepcionTipo)
      End With
      Return en
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.ExcepcionTipo.Columnas.IdExcepcionTipo.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.ExcepcionTipo.Columnas.NombreExcepcionTipo.ToString()).FormatearColumna("Descripción", pos, 250, HAlign.Left)

      End With
   End Sub
#End Region

End Class