#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class MRPSeccionesABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MRPSeccionesDetalle(DirectCast(Me.GetEntidad(), Entidades.MRPSeccion))
      End If
      Return New MRPSeccionesDetalle(New Entidades.MRPSeccion)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPSecciones()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim eSeccion = New Entidades.MRPSeccion
      With Me.dgvDatos.ActiveRow
         eSeccion = New Reglas.MRPSecciones().GetUno(Integer.Parse(.Cells("IdSeccion").Value.ToString()))
      End With
      Return eSeccion
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.MRPSeccion.Columnas.IdSeccion.ToString()).FormatearColumna("idCódigo", col, 80,, True)
         .Columns(Entidades.MRPSeccion.Columnas.CodigoSeccion.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.MRPSeccion.Columnas.Descripcion.ToString()).FormatearColumna("Descripcion", col, 400)
         .Columns(Entidades.MRPSeccion.Columnas.ClaseSeccion.ToString()).FormatearColumna("Clase", col, 80)
         .Columns(Entidades.MRPSeccion.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 60)
      End With
      '-- Agrega Filtros.- ---
      dgvDatos.AgregarFiltroEnLinea({Entidades.MRPSeccion.Columnas.CodigoSeccion.ToString(), Entidades.MRPSeccion.Columnas.Descripcion.ToString()})
   End Sub
#End Region
End Class