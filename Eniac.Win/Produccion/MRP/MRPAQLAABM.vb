Public Class MRPAQLAABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MRPAQLADetalle(DirectCast(GetEntidad(), Entidades.MRPAQLA))
      End If
      Return New MRPAQLADetalle(New Entidades.MRPAQLA())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPAQLA()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.MRPAQLA().GetUno(dr.Field(Of Integer)(Entidades.MRPAQLA.Columnas.IdMRPAQLA))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()
         Dim col As Integer = 0
         .Columns(Entidades.MRPAQLA.Columnas.IdMRPAQLA.ToString()).FormatearColumna("Id", col, 80, HAlign.Right, True)
         .Columns(Entidades.MRPAQLA.Columnas.TamanoLoteDesde.ToString()).FormatearColumna("Tamaño Lote Desde", col, 80, HAlign.Right)
         .Columns(Entidades.MRPAQLA.Columnas.TamanoLoteHasta.ToString()).FormatearColumna("Tamaño Lote Hasta", col, 80, HAlign.Right)
         .Columns(Entidades.MRPAQLA.Columnas.NivelGeneral1.ToString()).FormatearColumna("Nivel General I", col, 80)
         .Columns(Entidades.MRPAQLA.Columnas.NivelGeneral2.ToString()).FormatearColumna("Nivel General II", col, 80)
         .Columns(Entidades.MRPAQLA.Columnas.NivelGeneral3.ToString()).FormatearColumna("Nivel General III", col, 80)
         .Columns(Entidades.MRPAQLA.Columnas.NivelEspecialS1.ToString()).FormatearColumna("Nivel Especial S1", col, 80)
         .Columns(Entidades.MRPAQLA.Columnas.NivelEspecialS2.ToString()).FormatearColumna("Nivel Especial S2", col, 80)
         .Columns(Entidades.MRPAQLA.Columnas.NivelEspecialS3.ToString()).FormatearColumna("Nivel Especial S3", col, 80)
         .Columns(Entidades.MRPAQLA.Columnas.NivelEspecialS4.ToString()).FormatearColumna("Nivel Especial S4", col, 80)
      End With
      dgvDatos.AgregarFiltroEnLinea({})
   End Sub
#End Region
End Class