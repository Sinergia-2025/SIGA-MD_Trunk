Public Class ProductosModelosTiposABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False

      AgregarFiltroEnLinea(dgvDatos, {})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProductosModelosTiposDetalle(DirectCast(Me.GetEntidad(), Entidades.ProductoModeloTipo))
      End If
      Return New ProductosModelosTiposDetalle(New Entidades.ProductoModeloTipo())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ProductosModelosTipos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim en As Entidades.ProductoModeloTipo = New Entidades.ProductoModeloTipo()
      With Me.dgvDatos.ActiveCell.Row
         en.IdProductoModeloTipo = Integer.Parse(.Cells(Entidades.ProductoModeloTipo.Columnas.IdProductoModeloTipo.ToString()).Value.ToString())
         en = New Reglas.ProductosModelosTipos().GetUno(en.IdProductoModeloTipo)
      End With
      Return en
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.ProductoModeloTipo.Columnas.IdProductoModeloTipo.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.ProductoModeloTipo.Columnas.NombreProductoModeloTipo.ToString()).FormatearColumna("Descripción", pos, 250, HAlign.Left)

      End With
   End Sub
#End Region

End Class