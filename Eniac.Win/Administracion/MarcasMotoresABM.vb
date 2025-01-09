Public Class MarcasMotoresABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MarcasMotoresDetalle(DirectCast(GetEntidad(), Entidades.MarcaMotor))
      End If
      Return New MarcasMotoresDetalle(New Entidades.MarcaMotor())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MarcasMotores()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.MarcasMotores().GetUno(dr.Field(Of Integer)(Entidades.MarcaMotor.Columnas.IdMarcaMotor.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.MarcaMotor.Columnas.IdMarcaMotor.ToString()).FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns(Entidades.MarcaMotor.Columnas.NombreMarcaMotor.ToString()).FormatearColumna("Nombre", pos, 250)
      End With
   End Sub

#End Region

End Class