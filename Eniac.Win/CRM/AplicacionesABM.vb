Public Class AplicacionesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         dgvDatos.AgregarFiltroEnLinea({"NombreAplicacion"}, {})
      End Sub)
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AplicacionesDetalle(DirectCast(GetEntidad(), Entidades.Aplicacion))
      End If
      Return New AplicacionesDetalle(New Entidades.Aplicacion())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Aplicaciones()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
      Sub()
         Dim frmImprime = New VisorReportes("Eniac.Win.Aplicaciones.rdlc", "DSReportes_Aplicaciones", dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Aplicaciones"
         frmImprime.Show()
      End Sub)
   End Sub
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      With dgvDatos.ActiveRow
         Return New Reglas.Aplicaciones().GetUno(dr.Field(Of String)("IdAplicacion"))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.Aplicacion.Columnas.IdAplicacion.ToString()).FormatearColumna("Aplicación", pos, 100)
         .Columns(Entidades.Aplicacion.Columnas.NombreAplicacion.ToString()).FormatearColumna("Nombre", pos, 200)
         .Columns(Entidades.Aplicacion.Columnas.IdAplicacionBase.ToString()).FormatearColumna("Ap. Base", pos, 120)
         .Columns(Entidades.Aplicacion.Columnas.PropietarioAplicacion.ToString()).FormatearColumna("Propietario", pos, 100)
      End With
   End Sub
#End Region

End Class