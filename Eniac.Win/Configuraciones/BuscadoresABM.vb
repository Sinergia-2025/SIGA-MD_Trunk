Public Class BuscadoresABM

#Region "Overrides"
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New BuscadoresDetalle(DirectCast(GetEntidad(), Entidades.Buscador))
      End If
      Return New ParametrosDetalle(New Entidades.Parametro())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Buscadores()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.ActiveRow.FilaSeleccionada(Of DataRow)()
      Return New Reglas.Buscadores().GetUno(dr.Field(Of Integer)("IdBuscador"))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         dgvDatos.OcultaTodasLasColumnas()
         Dim pos = 0I
         .Columns("IdBuscador").FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns("Titulo").FormatearColumna("Título", pos, 300)
         .Columns("AnchoAyuda").FormatearColumna("Ancho ayuda", pos, 80, HAlign.Right)
         .Columns("IniciaConFocoEn").FormatearColumna("Inicia con foco en", pos, 100)
         .Columns("ColumaBusquedaInicial").FormatearColumna("Columna inicial", pos, 120)
         .Columns("CantidadColumnas").FormatearColumna("Columnas", pos, 80, HAlign.Right)
      End With
      dgvDatos.AgregarFiltroEnLinea({"Titulo", "ColumaBusquedaInicial"})
   End Sub
#End Region

End Class