Public Class ProductosModelosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False

      AgregarFiltroEnLinea(dgvDatos, {})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProductosModelosDetalle(DirectCast(Me.GetEntidad(), Entidades.ProductoModelo))
      End If
      Return New ProductosModelosDetalle(New Entidades.ProductoModelo())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ProductosModelos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim en As Entidades.ProductoModelo = New Entidades.ProductoModelo()
      With Me.dgvDatos.ActiveCell.Row
         en.IdProductoModelo = Integer.Parse(.Cells(Entidades.ProductoModelo.Columnas.IdProductoModelo.ToString()).Value.ToString())
         en = New Reglas.ProductosModelos().GetUno(en.IdProductoModelo)
      End With
      Return en
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.ProductoModelo.Columnas.IdProductoModelo.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.ProductoModelo.Columnas.NombreProductoModelo.ToString()).FormatearColumna("Descripción", pos, 250, HAlign.Left)
         .Columns(Entidades.ProductoModelo.Columnas.CodigoProductoModelo.ToString()).FormatearColumna("Código externo", pos, 120, HAlign.Left)
         .Columns(Entidades.ProductoModelo.Columnas.IdProductoModeloTipo.ToString()).FormatearColumna("", pos, 80, HAlign.Right, True)
         .Columns(Entidades.ProductoModeloTipo.Columnas.NombreProductoModeloTipo.ToString()).FormatearColumna("Tipo", pos, 200, HAlign.Left)
         .Columns(Entidades.ProductoModelo.Columnas.IdProductoModeloSubTipo.ToString()).FormatearColumna("", pos, 80, HAlign.Right, True)
         .Columns(Entidades.ProductoModeloSubTipo.Columnas.NombreProductoModeloSubTipo.ToString()).FormatearColumna("SubTipo", pos, 200, HAlign.Left)
      End With
   End Sub
#End Region

End Class