Option Strict On
Option Explicit On
Public Class NumeradoresABM
#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New NumeradoresDetalle(DirectCast(Me.GetEntidad(), Entidades.Numerador))
      End If
      Return New NumeradoresDetalle(New Eniac.Entidades.Numerador())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.Numeradores()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.Numeradores().GetUno(.Cells(Entidades.Numerador.Columnas.IdNumerador.ToString()).Value.ToString())
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.Numerador.Columnas.IdNumerador.ToString()).FormatearColumna("Numerador", pos, 100)
         .Columns(Entidades.Numerador.Columnas.Numero.ToString()).FormatearColumna("Últimno Número", pos, 70, HAlign.Right, , "N0")
         .Columns(Entidades.Numerador.Columnas.Descripcion.ToString()).FormatearColumna("Descripción", pos, 250)

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.Numerador.Columnas.Descripcion.ToString()})
   End Sub

#End Region

End Class
