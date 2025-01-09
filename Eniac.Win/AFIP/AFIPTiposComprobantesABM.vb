#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports Infragistics.Win.UltraWinGrid
#End Region
Public Class AFIPTiposComprobantesABM
#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(dgvDatos, {Entidades.AFIPTipoComprobante.Columnas.NombreAFIPTipoComprobante.ToString()})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AFIPTiposComprobantesDetalle(DirectCast(Me.GetEntidad(), Entidades.AFIPTipoComprobante))
      End If
      Return New AFIPTiposComprobantesDetalle(New Entidades.AFIPTipoComprobante())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AFIPTiposComprobantes()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim Ruta As Entidades.AFIPTipoComprobante = New Entidades.AFIPTipoComprobante()
      With Me.dgvDatos.ActiveCell.Row
         Ruta = DirectCast(GetReglas(), Reglas.AFIPTiposComprobantes).GetUno(Integer.Parse(.Cells(Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoComprobante.ToString()).Value.ToString()))
      End With
      Return Ruta
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next

         Dim col As Integer = 0

         .Columns(Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoComprobante.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.AFIPTipoComprobante.Columnas.NombreAFIPTipoComprobante.ToString()).FormatearColumna("Tipo Comprobante", col, 300)

         .Columns(Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoDocumento.ToString()).FormatearColumna("Tipo Doc.", col, 80, HAlign.Right)
         .Columns(Entidades.AFIPTipoDocumento.Columnas.NombreAFIPTipoDocumento.ToString()).FormatearColumna("Tipo Documento", col, 200)
         .Columns("IncluyeFechaVencimientoAsString").FormatearColumna("Incluye Venc.", col, 80, HAlign.Center)

      End With
   End Sub

#End Region

End Class