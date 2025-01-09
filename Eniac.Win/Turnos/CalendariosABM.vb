Public Class CalendariosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CalendariosDetalle(DirectCast(Me.GetEntidad(), Entidades.Calendario))
      End If
      Return New CalendariosDetalle(New Eniac.Entidades.Calendario())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.Calendarios()
   End Function
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.Calendarios().GetUno(Integer.Parse(.Cells(Entidades.Calendario.Columnas.IdCalendario.ToString()).Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.Calendario.Columnas.IdCalendario.ToString()).FormatearColumna("Id", col, 70, HAlign.Right)
         .Columns(Entidades.Calendario.Columnas.NombreCalendario.ToString()).FormatearColumna("Nombre", col, 200)

         .Columns(Entidades.Calendario.Columnas.IdTipoCalendario.ToString()).OcultoPosicion(True, col)
         .Columns(Entidades.TipoCalendario.Columnas.NombreTipoCalendario.ToString()).FormatearColumna("Tipo", col, 120)

         .Columns(Entidades.Calendario.Columnas.IdSucursal.ToString()).FormatearColumna("Id Suc.", col, 70, HAlign.Right, True)
         .Columns("NombreSucursal").FormatearColumna("Sucursal", col, 150)
         .Columns(Entidades.Calendario.Columnas.LapsoPorDefecto.ToString()).FormatearColumna("Lapso", col, 80, HAlign.Right)
         .Columns(Entidades.Calendario.Columnas.LapsoPorDefectoFijo.ToString()).FormatearColumna("Fijo", col, 80, HAlign.Center)
         .Columns(Entidades.Calendario.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 80, HAlign.Center)
         .Columns(Entidades.Calendario.Columnas.PublicarEnWeb.ToString()).FormatearColumna("Publicar En Web", col, 80, HAlign.Center)
         .Columns(Entidades.Calendario.Columnas.DiasDesde.ToString()).FormatearColumna("Dias Desde", col, 80, HAlign.Right)
         .Columns(Entidades.Calendario.Columnas.DiasHasta.ToString()).FormatearColumna("Dias Hasta", col, 80, HAlign.Right)
         .Columns(Entidades.Calendario.Columnas.DiasHabilitacionReserva.ToString()).FormatearColumna("Dias Hab. Reserva", col, 80, HAlign.Right)
         .Columns(Entidades.Calendario.Columnas.Cupo.ToString()).FormatearColumna("Cupo", col, 80, HAlign.Right)

         .Columns(Entidades.Calendario.Columnas.IdProducto.ToString()).FormatearColumna("Id Producto", col, 100, HAlign.Right, Not Reglas.Publicos.TurnosPermiteFacturarDesdeCalendario)
         .Columns(Entidades.Producto.Columnas.NombreProducto.ToString()).FormatearColumna("Producto", col, 180, , Not Reglas.Publicos.TurnosPermiteFacturarDesdeCalendario)
         .Columns(Entidades.Calendario.Columnas.IdUsuario.ToString()).FormatearColumna("Usuario", col, 100)
         .Columns(Entidades.Calendario.Columnas.IdCaja.ToString()).OcultoPosicion(True, 100)
         .Columns("NombreCaja").FormatearColumna("Caja", col, 100)
         .Columns(Entidades.Calendario.Columnas.UtilizaSesion.ToString()).FormatearColumna("Utiliza Sesión", col, 80, HAlign.Center)
         .Columns(Entidades.Calendario.Columnas.UtilizaZonas.ToString()).FormatearColumna("Utiliza Zona", col, 80, HAlign.Center)

         .Columns(Entidades.Calendario.Columnas.SolicitaEmbarcacion.ToString()).FormatearColumna("Solicita Embarcación", col, 80, HAlign.Center)
         .Columns(Entidades.Calendario.Columnas.SolicitaBotado.ToString()).FormatearColumna("Solicita Botado", col, 80, HAlign.Center)
         '-- REQ-33401.- -------------------------------------------------------------------------------------------------------------
         .Columns(Entidades.Calendario.Columnas.SolicitaVehiculo.ToString()).FormatearColumna("Solicita Vehiculo", col, 80, HAlign.Center)
         '-- REQ-33330.- -------------------------------------------------------------------------------------------------------------
         .Columns(Entidades.Calendario.Columnas.PermiteImpresion.ToString()).FormatearColumna("Permite Impresion", col, 80, HAlign.Center)
         '----------------------------------------------------------------------------------------------------------------------------
         .Columns(Entidades.Calendario.Columnas.IdNave.ToString()).OcultoPosicion(True, col)
      End With
   End Sub

#End Region

End Class