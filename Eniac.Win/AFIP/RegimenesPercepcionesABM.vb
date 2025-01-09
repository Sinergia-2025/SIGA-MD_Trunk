Public Class RegimenesPercepcionesABM

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() tsbImprimir.Visible = False)
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New RegimenesPercepcionesDetalle(DirectCast(GetEntidad(), Entidades.RegimenPercepcion))
      End If
      Return New RegimenesPercepcionesDetalle(New Entidades.RegimenPercepcion())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.RegimenesPercepciones()
   End Function
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      Return DirectCast(GetReglas(), Reglas.RegimenesPercepciones).GetUno(dr.Field(Of String)("IdTipoImpuesto"), dr.Field(Of Integer)("IdRegimenPercepcion"))
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns("IdTipoImpuesto").FormatearColumna("Tipo", pos, 90, , hidden:=True)
         .Columns("NombreTipoImpuesto").FormatearColumna("Tipo Impuesto", pos, 150)
         .Columns("IdRegimenPercepcion").FormatearColumna("Código", pos, 90, HAlign.Right)
         .Columns("NombreRegimenPercepcion").FormatearColumna("Nombre", pos, 250)
         .Columns("CodigoAFIP").FormatearColumna("Código AFIP", pos, 90, HAlign.Right)
         .Columns("ImporteNetoMinimo").FormatearColumna("Importe Neto Mínimo", pos, 90, HAlign.Right, , "N2")
         .Columns("ImpuestoMinimo").FormatearColumna("Impuesto Mínimo", pos, 90, HAlign.Right, , "N2")

         dgvDatos.AgregarFiltroEnLinea({"NombreTipoImpuesto", "NombreRegimenPercepcion"})
      End With
   End Sub
#End Region

End Class