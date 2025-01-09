Option Strict On
Option Explicit On
Public Class FormatosEtiquetasABM
#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New FormatosEtiquetasDetalle(DirectCast(Me.GetEntidad(), Entidades.FormatoEtiqueta))
      End If
      Return New FormatosEtiquetasDetalle(New Eniac.Entidades.FormatoEtiqueta())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.FormatosEtiquetas()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.FormatosEtiquetas().GetUno(Integer.Parse(.Cells(Entidades.FormatoEtiqueta.Columnas.IdFormatoEtiqueta.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         .Columns(Entidades.FormatoEtiqueta.Columnas.IdFormatoEtiqueta.ToString()).FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns(Entidades.FormatoEtiqueta.Columnas.NombreFormatoEtiqueta.ToString()).FormatearColumna("Nombre", pos, 180)
         .Columns(Entidades.FormatoEtiqueta.Columnas.Tipo.ToString()).FormatearColumna("Tipo", pos, 120)
         .Columns(Entidades.FormatoEtiqueta.Columnas.ArchivoAImprimir.ToString()).FormatearColumna("Archivo A Imprimir", pos, 260)
         .Columns(Entidades.FormatoEtiqueta.Columnas.ArchivoAImprimirEmbebido.ToString()).FormatearColumna("Embebido", pos, 60, HAlign.Center)
         .Columns(Entidades.FormatoEtiqueta.Columnas.NombreImpresora.ToString()).FormatearColumna("Nombre Impresora", pos, 100)
         .Columns(Entidades.FormatoEtiqueta.Columnas.ImprimeLote.ToString()).FormatearColumna("Imprime Lote", pos, 60, HAlign.Center)
         .Columns(Entidades.FormatoEtiqueta.Columnas.MaximoColumnas.ToString()).FormatearColumna("Máximo Columnas", pos, 60, HAlign.Center)
         .Columns(Entidades.FormatoEtiqueta.Columnas.Activo.ToString()).FormatearColumna("Activo", pos, 60, HAlign.Center)

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.FormatoEtiqueta.Columnas.NombreFormatoEtiqueta.ToString(),
                                     Entidades.FormatoEtiqueta.Columnas.ArchivoAImprimir.ToString(),
                                     Entidades.FormatoEtiqueta.Columnas.NombreImpresora.ToString()})
   End Sub

#End Region

End Class