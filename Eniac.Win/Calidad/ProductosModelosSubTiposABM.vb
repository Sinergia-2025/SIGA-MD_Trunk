Public Class ProductosModelosSubTiposABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False

      AgregarFiltroEnLinea(dgvDatos, {})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProductosModelosSubTiposDetalle(DirectCast(Me.GetEntidad(), Entidades.ProductoModeloSubTipo))
      End If
      Return New ProductosModelosSubTiposDetalle(New Entidades.ProductoModeloSubTipo())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ProductosModelosSubTipos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim en As Entidades.ProductoModeloSubTipo = New Entidades.ProductoModeloSubTipo()
      With Me.dgvDatos.ActiveCell.Row
         en.IdProductoModeloSubTipo = Integer.Parse(.Cells(Entidades.ProductoModeloSubTipo.Columnas.IdProductoModeloSubTipo.ToString()).Value.ToString())
         en = New Reglas.ProductosModelosSubTipos().GetUno(en.IdProductoModeloSubTipo)
      End With
      Return en
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.ProductoModeloSubTipo.Columnas.IdProductoModeloSubTipo.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.ProductoModeloSubTipo.Columnas.NombreProductoModeloSubTipo.ToString()).FormatearColumna("Descripción", pos, 250, HAlign.Left)
         .Columns(Entidades.ProductoModeloTipo.Columnas.IdProductoModeloTipo.ToString()).FormatearColumna("Código Tipo", pos, 80, HAlign.Right)
         .Columns(Entidades.ProductoModeloTipo.Columnas.NombreProductoModeloTipo.ToString()).FormatearColumna("Descripción Tipo", pos, 250, HAlign.Left)

      End With
   End Sub
#End Region

End Class