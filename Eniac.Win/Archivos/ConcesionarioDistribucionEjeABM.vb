Imports Eniac.Entidades
Imports Eniac.Reglas

Public Class ConcesionarioDistribucionEjeABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.dgvDatos.AgregarFiltroEnLinea({"NombreEje"})
   End Sub

   'GET DETALLE
   Protected Overrides Function GetDetalle(estado As StateForm) As Win.BaseDetalle
      Dim eje As Entidades.ConcesionarioDistribucionEje = DirectCast(Me.GetEntidad(), Entidades.ConcesionarioDistribucionEje)
      Dim idUnidad As Integer = 0
      If eje IsNot Nothing Then idUnidad = eje.IdTipoUnidad
      If estado = StateForm.Actualizar Then
         If eje Is Nothing Then Throw New Exception("Seleccione un Eje a modificar.")
         Return New ConcesionarioDistribucionEjesDetalle(idUnidad, eje)
      End If
      Return New ConcesionarioDistribucionEjesDetalle(idUnidad, New Entidades.ConcesionarioDistribucionEje())
   End Function
   'GET REGLAS
   Protected Overrides Function GetReglas() As Base
      Return New Reglas.ConcesionarioDistribucionEjes()
   End Function

   'GET ENTIDAD
   Protected Overrides Function GetEntidad() As Entidad
      MyBase.GetEntidad()
      Dim eDistribEjes As Entidades.ConcesionarioDistribucionEje = New Entidades.ConcesionarioDistribucionEje

      If dgvDatos.ActiveRow IsNot Nothing Then
         With Me.dgvDatos.ActiveRow
            If Not IsNumeric(.Cells("IdTipoUnidad").Value) Then Return Nothing
            eDistribEjes.IdTipoUnidad = Integer.Parse(.Cells("IdTipoUnidad").Value.ToString())
            eDistribEjes.IdEje = Integer.Parse(.Cells("IdEje").Value.ToString())
            eDistribEjes = New Reglas.ConcesionarioDistribucionEjes().GetUno(eDistribEjes.IdEje)
         End With
      End If
      Return eDistribEjes
   End Function

   'IMPRIMIR no hay rdlc por el momento
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
   End Sub

   'FORMATEAR GRILLAS
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.ConcesionarioDistribucionEje.columnas.IdEje.ToString()).FormatearColumna("Código Eje", col, 80)
         .Columns(Entidades.ConcesionarioDistribucionEje.columnas.NombreEje.ToString()).FormatearColumna("Nombre Eje", col, 150)
         .Columns(Entidades.ConcesionarioDistribucionEje.columnas.DescripcionEje.ToString()).FormatearColumna("Descripcion", col, 250)
         .Columns(Entidades.ConcesionarioDistribucionEje.columnas.IdTipoUnidad.ToString()).FormatearColumna("Código Unidad", col, 80)
         .Columns(Entidades.ConcesionarioTipoUnidad.columnas.NombreTipoUnidad.ToString()).FormatearColumna("Nombre Unidad", col, 150)
      End With
   End Sub
#End Region
End Class