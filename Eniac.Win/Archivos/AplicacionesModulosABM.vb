Option Strict On
Option Explicit On
Public Class AplicacionesModulosABM

#Region "Overrides"


   Protected Overrides Sub Nuevo()
      MyBase.Nuevo()
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AplicacionesModulosDetalle(DirectCast(Me.GetEntidad(), Entidades.AplicacionModulo))
      End If
      Return New AplicacionesModulosDetalle(New Entidades.AplicacionModulo)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AplicacionesModulos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr As DataRow = dgvDatos.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         Return New Reglas.AplicacionesModulos().GetUno(Integer.Parse(dr(Entidades.AplicacionModulo.Columnas.IdModulo.ToString()).ToString()))
      End If
      Return Nothing
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.AplicacionModulo.Columnas.IdModulo.ToString()).FormatearColumna("Código", pos, 70, HAlign.Right)
         .Columns(Entidades.AplicacionModulo.Columnas.NombreModulo.ToString()).FormatearColumna("Nombre", pos, 300)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.AplicacionModulo.Columnas.NombreModulo.ToString()})
   End Sub

#End Region

End Class