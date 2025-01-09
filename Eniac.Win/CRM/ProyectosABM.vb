Public Class ProyectosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProyectosDetalle(DirectCast(Me.GetEntidad(), Entidades.Proyecto))
      End If
      Return New ProyectosDetalle(New Eniac.Entidades.Proyecto())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.Proyectos()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.Proyectos().GetUno(Integer.Parse(.Cells(Entidades.Proyecto.Columnas.IdProyecto.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         '#Prioridades
         .Columns(Entidades.Proyecto.Columnas.IdPrioridadProyecto.ToString()).FormatearColumna("Prioridad Proyecto", pos, 60, HAlign.Right)
         .Columns(Entidades.Proyecto.Columnas.IdProyecto.ToString()).FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns(Entidades.Proyecto.Columnas.NombreProyecto.ToString()).FormatearColumna("Proyecto", pos, 200)
         .Columns(Entidades.Proyecto.Columnas.IdCliente.ToString()).OcultoPosicion(True, pos)
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FormatearColumna("Cliente", pos, 200)
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).FormatearColumna("Nombre de Fantasía", pos, 200)

         .Columns(Entidades.Proyecto.Columnas.IdEstado.ToString()).OcultoPosicion(True, pos)
         .Columns(Entidades.ProyectoEstado.Columnas.NombreEstado.ToString()).FormatearColumna("Estado", pos, 100)
         .Columns(Entidades.Proyecto.Columnas.IdClasificacion.ToString()).FormatearColumna("Id Clasificacion", pos, 60, HAlign.Right, True)
         .Columns(Entidades.Clasificacion.Columnas.NombreClasificacion.ToString()).FormatearColumna("Clasificación", pos, 80, HAlign.Left, False)

         .Columns(Entidades.Proyecto.Columnas.FechaInicio.ToString()).FormatearColumna("Inicio", pos, 80, HAlign.Center)
         .Columns(Entidades.Proyecto.Columnas.FechaFin.ToString()).FormatearColumna("Fin", pos, 80, HAlign.Center)
         .Columns(Entidades.Proyecto.Columnas.FechaFinReal.ToString()).FormatearColumna("Fin Real", pos, 80, HAlign.Center)

         .Columns(Entidades.Proyecto.Columnas.HsRealEstimadas.ToString()).FormatearColumna("HS Estimadas", pos, 80, HAlign.Right, , "N0")
         .Columns(Entidades.Proyecto.Columnas.Estimado.ToString()).FormatearColumna("HS Cobradas", pos, 80, HAlign.Right, , "N0")
         .Columns(Entidades.Proyecto.Columnas.HsInformadas.ToString()).FormatearColumna("HS Informadas", pos, 80, HAlign.Right, , "N0")
         .Columns("CantidadHorasHijos").FormatearColumna("Horas Insumidas", pos, 80, HAlign.Right, , "N2")
         .Columns("DifHSCobradas").FormatearColumna("Dif. HS Cobradas", pos, 80, HAlign.Right, , "N2")
         .Columns("DifHSInformadas").FormatearColumna("Dif. HS Informadas", pos, 80, HAlign.Right, , "N2")
         .Columns(Entidades.Proyecto.Columnas.Presupuestado.ToString()).FormatearColumna("Presup.", pos, 90, HAlign.Right, , "N2")

         .Columns(Entidades.Proyecto.Columnas.IdPrioridadImporte.ToString()).FormatearColumna("P. Importe", pos, 80, HAlign.Right)
         .Columns(Entidades.Proyecto.Columnas.IdPrioridadEstrategico.ToString()).FormatearColumna("P. Estratégico", pos, 80, HAlign.Right)
         .Columns(Entidades.Proyecto.Columnas.IdPrioridadComplejidad.ToString()).FormatearColumna("P. Complejidad", pos, 80, HAlign.Right)
         .Columns(Entidades.Proyecto.Columnas.IdPrioridadReplicabilidad.ToString()).FormatearColumna("P. Replicabilidad", pos, 80, HAlign.Right)

         .Columns("IdPrioridadCalculada").FormatearColumna("P. Calculada", pos, 80, HAlign.Right)

         .Columns("EstimadoRequerimientos").FormatearColumna("Estimado Requerimientos", pos, 90, HAlign.Right)
         .Columns("EstimadoPendientes").FormatearColumna("Estimado Pendientes", pos, 90, HAlign.Right)
      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.Proyecto.Columnas.NombreProyecto.ToString(),
                                     Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                     Entidades.Cliente.Columnas.NombreDeFantasia.ToString()})

   End Sub

#End Region

End Class