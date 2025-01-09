Public Class TiposSociedadesABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      MyBase.OnLoad(e)
      'es necesario esto?
      dgvDatos.AgregarFiltroEnLinea({Entidades.TipoSociedad.Columnas.NombreTipoSociedad.ToString()})
   End Sub

   'GET DETALLE
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposSociedadesDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoSociedad))
      End If
      Return New TiposSociedadesDetalle(New Entidades.TipoSociedad)
   End Function
   'GET REGLAS
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposSociedades()
   End Function
   'GET ENTIDAD
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With Me.dgvDatos.ActiveRow
         Return New Reglas.TiposSociedades().GetUno(Integer.Parse(.Cells(Entidades.TipoSociedad.Columnas.IdTipoSociedad.ToString()).Value.ToString()))
      End With
   End Function
   'IMPRIMIR
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
   End Sub
   'FORMATEAR GRILLA
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.TipoSociedad.Columnas.IdTipoSociedad.ToString()).FormatearColumna("Código", col, 80, HAlign.Center)
         .Columns(Entidades.TipoSociedad.Columnas.NombreTipoSociedad.ToString()).FormatearColumna("Nombre", col, 250, HAlign.Left)
      End With
   End Sub
#End Region
End Class