Namespace ServiciosRest.CobranzasMovil
   Public Class Calendarios
      Public Function GetParaMovil(idEmpresa As Integer) As List(Of Entidades.JSonEntidades.CobranzasMovil.Calendarios)
         Dim result = New List(Of Entidades.JSonEntidades.CobranzasMovil.Calendarios)()

         Dim dbCal = New Reglas.Calendarios().GetTodos(activo:=True, publicarEnWeb:=Entidades.Publicos.SiNoTodos.SI)
         Dim tiposTurnos = New Reglas.TiposTurnos().GetTodos(idTipoCalendario:=0)

         For Each cal In dbCal
            Dim o = New Entidades.JSonEntidades.CobranzasMovil.Calendarios(idEmpresa)

            o.IdCalendario = cal.IdCalendario
            o.IdTipoCalendario = cal.IdTipoCalendario
            o.NombreCalendario = cal.NombreCalendario
            o.Activo = cal.Activo
            o.LapsoPorDefecto = cal.LapsoPorDefecto
            o.LapsoPorDefectoFijo = cal.LapsoPorDefectoFijo

            o.Cupo = cal.Cupo
            o.DiasHabilitacionReserva = cal.DiasHabilitacionReserva

            o.IdNave = cal.IdNave

            o.Horarios = cal.Horarios.ConvertAll(Function(h) New Entidades.JSonEntidades.CobranzasMovil.CalendariosHorarios(idEmpresa) _
                                                                  With {
                                                                        .IdCalendario = h.IdCalendario,
                                                                        .IdDiaSemana = h.IdDiaSemana,
                                                                        .IdHorario = h.IdHorario,
                                                                        .HoraDesde = h.HoraDesde,
                                                                        .HoraHasta = h.HoraHasta,
                                                                        .NombreDiaSemana = h.NombreDiaSemana
                                                                        })
            o.TiposServicios = tiposTurnos.Where(Function(x) x.IdTipoCalendario = cal.IdTipoCalendario).ToList() _
                                     .ConvertAll(Function(t) New Entidades.JSonEntidades.CobranzasMovil.CalendariosTiposTurnos(idEmpresa) _
                                                                  With {
                                                                        .IdCalendario = o.IdCalendario,
                                                                        .IdTipoServicio = t.IdTipoTurno,
                                                                        .NombreTipoServicio = t.NombreTipoTurno
                                                                        })

            result.Add(o)
         Next

         Return result
      End Function

   End Class
End Namespace