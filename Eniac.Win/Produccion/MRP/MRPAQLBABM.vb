Public Class MRPAQLBABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MRPAQLBDetalle(DirectCast(GetEntidad(), Entidades.MRPAQLB))
      End If
      Return New MRPAQLBDetalle(New Entidades.MRPAQLB())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPAQLB()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.MRPAQLB().GetUno(dr.Field(Of Decimal)(Entidades.MRPAQLB.Columnas.LimiteCalidadAceptable.ToString()),
                                         dr.Field(Of String)(Entidades.MRPAQLB.Columnas.CodigoNivel.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()
         Dim col As Integer = 0
         .Columns(Entidades.MRPAQLB.Columnas.LimiteCalidadAceptable.ToString()).FormatearColumna("Límite Calidad Aceptable", col, 100, HAlign.Right, , "N4")
         .Columns(Entidades.MRPAQLB.Columnas.CodigoNivel.ToString()).FormatearColumna("Código", col, 80, HAlign.Center)
         .Columns(Entidades.MRPAQLB.Columnas.TamanoMuestreo.ToString()).FormatearColumna("Tamaño Muestreo", col, 100, HAlign.Right, , "N0")
         .Columns(Entidades.MRPAQLB.Columnas.CantidadAceptacion.ToString()).FormatearColumna("Aceptable", col, 80, HAlign.Right, , "N0")
         .Columns(Entidades.MRPAQLB.Columnas.CantidadRechazo.ToString()).FormatearColumna("Rechazo", col, 80, HAlign.Right, , "N0")
      End With
      dgvDatos.AgregarFiltroEnLinea({})
   End Sub
#End Region
End Class