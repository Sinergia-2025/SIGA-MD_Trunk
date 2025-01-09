Public Class ModelosMotoresABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ModelosMotoresDetalle(DirectCast(GetEntidad(), Entidades.ModeloMotor))
      End If
      Return New ModelosMotoresDetalle(New Entidades.ModeloMotor())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ModelosMotores()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.ModelosMotores().GetUno(dr.Field(Of Integer)(Entidades.ModeloMotor.Columnas.IdModeloMotor.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.ModeloMotor.Columnas.IdMarcaMotor.ToString()).OcultoPosicion(True, pos)
         .Columns(Entidades.MarcaMotor.Columnas.NombreMarcaMotor.ToString()).FormatearColumna("Marca", pos, 250)
         .Columns(Entidades.ModeloMotor.Columnas.IdModeloMotor.ToString()).FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns(Entidades.ModeloMotor.Columnas.NombreModeloMotor.ToString()).FormatearColumna("Nombre", pos, 250)
      End With
   End Sub

#End Region

End Class