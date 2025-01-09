Public Class ContabilidadEjeciciosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ContabilidadEjerciciosDetalle(DirectCast(GetEntidad(), Entidades.ContabilidadEjercicio))
      End If
      Return New ContabilidadEjerciciosDetalle(New Entidades.ContabilidadEjercicio())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ContabilidadEjercicios()
   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return DirectCast(rg, Reglas.ContabilidadEjercicios).GetAllABM()
   End Function

   Protected Overrides Sub Borrar()

      If CBool(dgvDatos.ActiveRow.Cells("cerrado").Value) = False Then
         ShowMessage("El Ejercicio Contable está abierto. No se puede eliminar")
      ElseIf TieneAsientosAsociados(Integer.Parse(dgvDatos.ActiveRow.Cells(Entidades.ContabilidadEjercicio.Columnas.IdEjercicio.ToString()).Value.ToString())) Then
         ShowMessage("El Ejercicio Contable Tiene asientos contables asociados. No se puede eliminar")
      Else
         MyBase.Borrar()
      End If

   End Sub

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.ActiveRow
         Dim rEjercicios = New Reglas.ContabilidadEjercicios()
         Dim ejercicio = rEjercicios.GetUna(Integer.Parse(.Cells(Entidades.ContabilidadEjercicio.Columnas.IdEjercicio.ToString()).Value.ToString()))
         Return ejercicio
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)

         Dim pos = 0I

         .Columns(Entidades.ContabilidadEjercicio.Columnas.IdEjercicio.ToString() + "1").OcultoPosicion(hidden:=True, pos)

         .Columns(Entidades.ContabilidadEjercicio.Columnas.IdEjercicio.ToString()).FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns(Entidades.ContabilidadEjercicio.Columnas.FechaDesde.ToString()).FormatearColumna("Fecha Desde", pos, 100, HAlign.Center)
         .Columns(Entidades.ContabilidadEjercicio.Columnas.FechaHasta.ToString()).FormatearColumna("Fecha Hasta", pos, 100, HAlign.Center)
         .Columns(Entidades.ContabilidadEjercicio.Columnas.Cerrado.ToString()).FormatearColumna("Cerrado", pos, 60, HAlign.Center)
         .Columns("CantPeriodos").FormatearColumna("Periodos", pos, 70, HAlign.Right)

         For Each c In .Columns.OfType(Of UltraGridColumn).Where(Function(c1) c1.Key.StartsWith("P___") Or c1.Key.StartsWith("E___"))
            If c.Key.StartsWith("P___") Then
               Dim periodo = c.Key.Replace("P___", "").ToInt32().IfNull()
               c.FormatearColumna(String.Format("Periodo {0}", periodo), pos, 80, HAlign.Center)
            ElseIf c.Key.StartsWith("E___") Then
               c.OcultoPosicion(hidden:=True, pos)
            End If
         Next

      End With

      dgvDatos.AgregarFiltroEnLinea({})

   End Sub

#End Region

#Region "Eventos"

   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      TryCatched(
         Sub()
            Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)(e.Row)
            If dr IsNot Nothing Then
               With dgvDatos.DisplayLayout.Bands(0)
                  .Columns.OfType(Of UltraGridColumn).Where(Function(c1) c1.Key.StartsWith("E___")).ToList().
                     ForEach(
                     Sub(c)
                        Dim periodo = c.Key.Replace("E___", "P___")
                        If .Columns.Exists(periodo) Then
                           If dr.Field(Of Integer?)(c.Key).IfNull() = 0 Then
                              If dr.Field(Of Date)("FechaDesde") <= Date.Today AndAlso
                                 dr.Field(Of Date)("FechaHasta") >= Date.Today AndAlso
                                 dr.Field(Of String)(periodo) = Date.Today.ToString("MM/yyyy") Then
                                 e.Row.Cells(periodo).Color(Nothing, Color.Yellow)
                              Else
                                 e.Row.Cells(periodo).Color(Nothing, Color.LightGreen)
                              End If
                           Else
                              e.Row.Cells(periodo).Color(Nothing, Color.Coral)
                           End If
                        End If
                     End Sub)
               End With
            End If
         End Sub)
   End Sub

#End Region

#Region "privados"

   Private Function TieneAsientosAsociados(idEjercicio As Integer) As Boolean
      Return New Reglas.ContabilidadEjercicios().TieneAsientosAsociados(idEjercicio)
   End Function

#End Region

End Class