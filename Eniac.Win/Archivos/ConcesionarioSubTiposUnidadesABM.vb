Imports Eniac.Entidades
Imports Eniac.Reglas

Public Class ConcesionarioSubTiposUnidadesABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.dgvDatos.AgregarFiltroEnLinea({"NombreSubTipoUnidad"})
   End Sub
   'GET DETALLE
   Protected Overrides Function GetDetalle(estado As StateForm) As Win.BaseDetalle
      Dim subUnidad As Entidades.ConcesionarioSubTipoUnidad = DirectCast(Me.GetEntidad(), Entidades.ConcesionarioSubTipoUnidad)
      Dim idUnidad As Integer = 0
      If subUnidad IsNot Nothing Then idUnidad = subUnidad.IdTipoUnidad
      If estado = StateForm.Actualizar Then
         If subUnidad Is Nothing Then Throw New Exception("Seleccione una SubUnidad a modificar.")
         Return New ConcesionarioSubTiposUnidadesDetalle(idUnidad, subUnidad)
      End If
      Return New ConcesionarioSubTiposUnidadesDetalle(idUnidad, New Entidades.ConcesionarioSubTipoUnidad())
   End Function

   'GET REGLAS
   Protected Overrides Function GetReglas() As Base
      Return New Reglas.ConcesionarioSubTiposUnidades()
   End Function
   'IMPRIMIR no hay rdlc por el momento
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
   End Sub
   'GET ENTIDAD
   Protected Overrides Function GetEntidad() As Entidad
      MyBase.GetEntidad()
      Dim eSubUnidad As Entidades.ConcesionarioSubTipoUnidad = New Entidades.ConcesionarioSubTipoUnidad
      If dgvDatos.ActiveRow IsNot Nothing Then
         With Me.dgvDatos.ActiveRow
            If Not IsNumeric(.Cells("IdTipoUnidad").Value) Then Return Nothing
            eSubUnidad.IdTipoUnidad = Integer.Parse(.Cells("IdTipoUnidad").Value.ToString())
            eSubUnidad.IdSubTipoUnidad = Integer.Parse(.Cells("IdSubTipoUnidad").Value.ToString())
            eSubUnidad = New Reglas.ConcesionarioSubTiposUnidades().GetUno(eSubUnidad.IdSubTipoUnidad)
         End With
      End If
      Return eSubUnidad
   End Function

   'FORMATEAR GRILLA
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.ConcesionarioSubTipoUnidad.columnas.IdSubTipoUnidad.ToString()).FormatearColumna("Código SubUnidad", col, 80)
         .Columns(Entidades.ConcesionarioSubTipoUnidad.columnas.NombreSubTipoUnidad.ToString()).FormatearColumna("Nombre SubUnidad", col, 150)
         .Columns(Entidades.ConcesionarioSubTipoUnidad.columnas.DescripcionSubTipoUnidad.ToString()).FormatearColumna("Descripcion", col, 250)
         .Columns(Entidades.ConcesionarioSubTipoUnidad.columnas.IdTipoUnidad.ToString()).FormatearColumna("Código Unidad", col, 80)
         .Columns(Entidades.ConcesionarioTipoUnidad.columnas.NombreTipoUnidad.ToString()).FormatearColumna("Nombre Unidad", col, 150)
         .Columns(Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaCantPuertasLaterales.ToString()).FormatearColumna("Solicita Puertas Laterales", col, 80)
         .Columns(Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaCantPisos.ToString()).FormatearColumna("Solicita Pisos", col, 80)
         .Columns(Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaVolumen.ToString()).FormatearColumna("Solicita Volumen", col, 80)
      End With
   End Sub

#End Region
End Class