#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Public Class AplicacionesFuncionesABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AplicacionesFuncionesDetalle(DirectCast(Me.GetEntidad(), Entidades.AplicacionFuncion))
      End If
      Return New AplicacionesFuncionesDetalle(New Entidades.AplicacionFuncion())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AplicacionesFunciones()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.AplicacionesFunciones().GetUno(.Cells(Entidades.AplicacionFuncion.Columnas.IdAplicacion.ToString()).Value.ToString(),
                                                          .Cells(Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString()).Value.ToString())
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      dgvDatos.AgregarFiltroEnLinea({Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString(),
                                     Entidades.AplicacionFuncion.Columnas.NombreFuncion.ToString() + "Padre"})

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.AplicacionFuncion.Columnas.IdAplicacion.ToString()).FormatearColumna("Aplicación", col, 120)
         .Columns(Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString()).FormatearColumna("Código", col, 80)
         .Columns(Entidades.AplicacionFuncion.Columnas.NombreFuncion.ToString()).FormatearColumna("Nombre", col, 260)
         .Columns(Entidades.AplicacionFuncion.Columnas.IdFuncionPadre.ToString()).FormatearColumna("Código Padre", col, 80)
         .Columns(Entidades.AplicacionFuncion.Columnas.NombreFuncion.ToString() + "Padre").FormatearColumna("Nombre Padre", col, 260)

      End With
   End Sub
#End Region

End Class