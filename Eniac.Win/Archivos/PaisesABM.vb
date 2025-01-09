Option Strict On
Option Explicit On
Public Class PaisesABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New PaisesDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.Pais))
      End If
      Return New PaisesDetalle(New Eniac.Entidades.Pais)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Paises()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim Pais As Eniac.Entidades.Pais = New Eniac.Entidades.Pais
      With Me.dgvDatos.ActiveRow
         Pais = New Eniac.Reglas.Paises().GetUno(.Cells("IdPais").Value.ToString())
      End With
      Return Pais
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Eniac.Entidades.Pais.Columnas.IdPais.ToString()).FormatearColumna("Código", col, 80)
         .Columns(Eniac.Entidades.Pais.Columnas.NombrePais.ToString()).FormatearColumna("País", col, 200)
         .Columns(Eniac.Entidades.Pais.Columnas.IdAfipPais.ToString()).FormatearColumna("Código AFIP", col, 100)
      End With
   End Sub
#End Region
End Class