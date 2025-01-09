#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports Eniac.Win
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class ConceptosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ConceptosDetalle(DirectCast(Me.GetEntidad(), Entidades.Concepto))
      End If
      Return New ConceptosDetalle(New Entidades.Concepto)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Conceptos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      With Me.dgvDatos.ActiveCell.Row
         Return New Reglas.Conceptos().GetUno(Integer.Parse(.Cells("IdConcepto").Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.Concepto.Columnas.IdConcepto.ToString()).FormatearColumna("Código", pos, 70, HAlign.Right)
         .Columns(Entidades.Concepto.Columnas.NombreConcepto.ToString()).FormatearColumna("Nombre", pos, 280)
         .Columns(Entidades.Concepto.Columnas.IdRubroConcepto.ToString()).FormatearColumna("Rubro", pos, 50, HAlign.Right)
         .Columns(Entidades.Concepto.Columnas.NombreRubroConcepto.ToString()).FormatearColumna("Nombre Rubro", pos, 200)
         .Columns(Entidades.Concepto.Columnas.GrupoGastos.ToString()).FormatearColumna("Grupo", pos, 60, HAlign.Center)
         .Columns(Entidades.Concepto.Columnas.IdProducto.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.Producto.Columnas.NombreProducto.ToString()).FormatearColumna("Nombre Producto", pos, 200)
         .Columns(Entidades.Concepto.Columnas.EsNoGravado.ToString()).FormatearColumna("No Gravado", pos, 70)
         .Columns(Entidades.Concepto.Columnas.ImprimeProveedor.ToString()).FormatearColumna("Imprime Proveedor", pos, 60)
         .Columns(Entidades.Concepto.Columnas.ImprimeDetalleComprobante.ToString()).FormatearColumna("Imprime Detalle Comprobante", pos, 60)
         .Columns(Entidades.Concepto.Columnas.Activo.ToString()).FormatearColumna("Activo", pos, 60)
      End With
   End Sub

#End Region

End Class