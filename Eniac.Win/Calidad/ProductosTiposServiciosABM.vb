Public Class ProductosTiposServiciosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False

      AgregarFiltroEnLinea(dgvDatos, {})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProductosTiposServiciosDetalle(DirectCast(Me.GetEntidad(), Entidades.ProductoTipoServicio))
      End If
      Return New ProductosTiposServiciosDetalle(New Entidades.ProductoTipoServicio())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ProductosTiposServicios()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim en As Entidades.ProductoTipoServicio = New Entidades.ProductoTipoServicio()
      With Me.dgvDatos.ActiveCell.Row
         en.IdProductoTipoServicio = Integer.Parse(.Cells(Entidades.ProductoTipoServicio.Columnas.IdProductoTipoServicio.ToString()).Value.ToString())
         en = New Reglas.ProductosTiposServicios().GetUno(en.IdProductoTipoServicio)
      End With
      Return en
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.ProductoTipoServicio.Columnas.IdProductoTipoServicio.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.ProductoTipoServicio.Columnas.NombreProductoTipoServicio.ToString()).FormatearColumna("Descripción", pos, 150, HAlign.Left)
         .Columns(Entidades.ProductoTipoServicio.Columnas.Prefijo.ToString()).FormatearColumna("Prefijo", pos, 80, HAlign.Left)

      End With
   End Sub
#End Region

End Class