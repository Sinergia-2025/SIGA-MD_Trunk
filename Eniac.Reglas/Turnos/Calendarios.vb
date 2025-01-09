Public Class Calendarios
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Calendarios"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Calendarios"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Calendarios = New SqlServer.Calendarios(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Calendarios(Me.da).Calendarios_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)
      Try
         Dim en As Entidades.Calendario = DirectCast(entidad, Entidades.Calendario)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.Calendarios = New SqlServer.Calendarios(da)
         Dim sqlCS As SqlServer.CalendariosSucursales = New SqlServer.CalendariosSucursales(da)
         Dim rHorarios As Reglas.CalendariosHorarios = New CalendariosHorarios(da)
         Dim rUsuarios As SqlServer.CalendariosUsuarios = New SqlServer.CalendariosUsuarios(da)
         'Dim idSucursal As Integer = actual.Sucursal.IdSucursal ' Por defecto la Sucursal Principal

         Select Case tipo
            Case TipoSP._I

               sqlC.Calendarios_I(en.IdCalendario, en.IdTipoCalendario, en.NombreCalendario, en.Activo, en.IdSucursal, en.LapsoPorDefecto, en.LapsoPorDefectoFijo,
                                  en.DiasDesde, en.DiasHasta, en.Cupo, en.IdUsuario, en.DiasHabilitacionReserva, en.IdProducto, en.UtilizaSesion, en.UtilizaZonas,
                                  en.PublicarEnWeb, en.IdNave, en.SolicitaEmbarcacion, en.SolicitaBotado, en.SolicitaVehiculo, en.PermiteImpresion)

               ' Hago el Insert también en la tabla intermedia
               Dim Sucursales As List(Of Entidades.Sucursal) = New Reglas.Sucursales(da).GetTodas(False)
               For Each suc As Entidades.Sucursal In Sucursales
                  If suc.IdSucursal = actual.Sucursal.Id Then
                     sqlCS.CalendariosSucursales_I(suc.IdSucursal, en.IdCalendario, en.CalendarioSucursal.IdCaja)
                  Else
                     sqlCS.CalendariosSucursales_I(suc.IdSucursal, en.IdCalendario, 0)
                  End If
               Next

               rHorarios.BorrarDesdeCalendario(en)
               rHorarios.InsertaDesdeCalendario(en)

               rUsuarios.CalendariosUsuarios_D(en.IdSucursal, en.IdCalendario)
               For Each usuario As DataRow In en.Usuarios.Rows
                  rUsuarios.CalendariosUsuarios_I(Integer.Parse(usuario("IdSucursal").ToString()), en.IdCalendario, usuario("IdUsuario").ToString(), Boolean.Parse(usuario("PermitirEscritura").ToString()))
                  'rUsuarios.CalendariosUsuarios_I(idSucursal, en.IdCalendario, usuario("IdUsuario").ToString(), Boolean.Parse(usuario("PermitirEscritura").ToString()))
               Next


            Case TipoSP._U

               sqlC.Calendarios_U(en.IdCalendario, en.IdTipoCalendario, en.NombreCalendario, en.Activo, en.IdSucursal, en.LapsoPorDefecto, en.LapsoPorDefectoFijo,
                                  en.DiasDesde, en.DiasHasta, en.Cupo, en.IdUsuario, en.DiasHabilitacionReserva, en.IdProducto, en.UtilizaSesion, en.UtilizaZonas,
                                  en.PublicarEnWeb, en.IdNave, en.SolicitaEmbarcacion, en.SolicitaBotado, en.SolicitaVehiculo, en.PermiteImpresion)

               ' Hago el delete y luego el insert en la tabla intermedia
               'sqlCS.CalendariosSucursales_D(en.CalendarioSucursal.IdSucursal, en.IdCalendario)
               'sqlCS.CalendariosSucursales_I(en.CalendarioSucursal.IdSucursal, en.IdCalendario, en.CalendarioSucursal.IdCaja)
               sqlCS.CalendariosSucursales_U(en.CalendarioSucursal.IdSucursal, en.IdCalendario, en.CalendarioSucursal.IdCaja)


               rHorarios.BorrarDesdeCalendario(en)
               rHorarios.InsertaDesdeCalendario(en)

               rUsuarios.CalendariosUsuarios_D(en.IdSucursal, en.IdCalendario)
               For Each usuario As DataRow In en.Usuarios.Rows
                  rUsuarios.CalendariosUsuarios_I(Integer.Parse(usuario("IdSucursal").ToString()), en.IdCalendario, usuario("IdUsuario").ToString(), Boolean.Parse(usuario("PermitirEscritura").ToString()))
               Next

            Case TipoSP._D

               sqlCS.CalendariosSucursales_D(0, en.IdCalendario)
               rUsuarios.CalendariosUsuarios_D(en.IdSucursal, en.IdCalendario)
               rHorarios.BorrarDesdeCalendario(en)
               sqlC.Calendarios_D(en.IdCalendario)

         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(o As Entidades.Calendario, dr As DataRow)
      With o
         .IdCalendario = Integer.Parse(dr(Entidades.Calendario.Columnas.IdCalendario.ToString()).ToString())
         .IdTipoCalendario = dr.Field(Of Short)(Entidades.Calendario.Columnas.IdTipoCalendario.ToString())
         .NombreCalendario = dr(Entidades.Calendario.Columnas.NombreCalendario.ToString()).ToString()
         .Activo = Boolean.Parse(dr(Entidades.Calendario.Columnas.Activo.ToString()).ToString())
         If IsNumeric(dr(Entidades.Calendario.Columnas.IdSucursal.ToString())) Then
            .IdSucursal = Integer.Parse(dr(Entidades.Calendario.Columnas.IdSucursal.ToString()).ToString())
         End If
         .LapsoPorDefecto = Integer.Parse(dr(Entidades.Calendario.Columnas.LapsoPorDefecto.ToString()).ToString())
         .LapsoPorDefectoFijo = Boolean.Parse(dr(Entidades.Calendario.Columnas.LapsoPorDefectoFijo.ToString()).ToString())

         .Horarios = New CalendariosHorarios(da).GetTodos(.IdCalendario)

         If IsNumeric(dr(Entidades.Calendario.Columnas.DiasDesde.ToString())) Then
            .DiasDesde = Integer.Parse(dr(Entidades.Calendario.Columnas.DiasDesde.ToString()).ToString())
         End If

         If IsNumeric(dr(Entidades.Calendario.Columnas.DiasHasta.ToString())) Then
            .DiasHasta = Integer.Parse(dr(Entidades.Calendario.Columnas.DiasHasta.ToString()).ToString())
         End If

         If IsNumeric(dr(Entidades.Calendario.Columnas.Cupo.ToString())) Then
            .Cupo = Integer.Parse(dr(Entidades.Calendario.Columnas.Cupo.ToString()).ToString())
         End If

         .IdUsuario = dr(Entidades.Calendario.Columnas.IdUsuario.ToString()).ToString()

         .DiasHabilitacionReserva = Integer.Parse(dr(Entidades.Calendario.Columnas.DiasHabilitacionReserva.ToString()).ToString())

         .IdProducto = dr(Entidades.Calendario.Columnas.IdProducto.ToString()).ToString()

         .CalendarioSucursal = New CalendariosSucursales(da).GetUno(actual.Sucursal.IdSucursal, .IdCalendario)

         .UtilizaSesion = Boolean.Parse(dr(Entidades.Calendario.Columnas.UtilizaSesion.ToString()).ToString())

         .UtilizaZonas = Boolean.Parse(dr(Entidades.Calendario.Columnas.UtilizaZonas.ToString()).ToString())

         .PublicarEnWeb = dr.Field(Of Boolean)(Entidades.Calendario.Columnas.PublicarEnWeb.ToString())
         .IdNave = dr.Field(Of Short?)(Entidades.Calendario.Columnas.IdNave.ToString())

         .SolicitaEmbarcacion = dr.Field(Of Boolean)(Entidades.Calendario.Columnas.SolicitaEmbarcacion.ToString())
         .SolicitaBotado = dr.Field(Of Boolean)(Entidades.Calendario.Columnas.SolicitaBotado.ToString())

         '-- REQ-33401.- ---------------------------
         .SolicitaVehiculo = dr.Field(Of Boolean)(Entidades.Calendario.Columnas.SolicitaVehiculo.ToString())
         '-- REQ-33330.- ---------------------------
         .PermiteImpresion = dr.Field(Of Boolean)(Entidades.Calendario.Columnas.PermiteImpresion.ToString())
         '------------------------------------------
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idCalendario As Integer) As Entidades.Calendario
      Return GetUno(idCalendario, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idCalendario As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Calendario
      Return CargaEntidad(New SqlServer.Calendarios(Me.da).Calendarios_G1(idCalendario),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Calendario,
                          accion, Function() String.Format("No existe calendario con id {0}", idCalendario))
   End Function

   Public Function GetTodos() As List(Of Entidades.Calendario)
      Return GetTodos(idSucursal:=0)
   End Function
   Public Function GetTodos(idSucursal As Integer) As List(Of Entidades.Calendario)
      Return CargaLista(New SqlServer.Calendarios(Me.da).Calendarios_GA(idSucursal, Nothing),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Calendario)
   End Function

   Public Function GetTodosActivos(idSucursal As Integer, idUsuario As String) As List(Of Entidades.Calendario)
      Return CargaLista(Me.GetCalendarioPorUsuario(0, idSucursal, idUsuario),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Calendario())
   End Function

   Public Function GetTodos(activo As Boolean?, publicarEnWeb As Entidades.Publicos.SiNoTodos) As List(Of Entidades.Calendario)
      Return CargaLista(New SqlServer.Calendarios(da).GetCalendarios(activo, publicarEnWeb),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Calendario)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Calendarios(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetUsuariosPorCalendario(IdCalendario As String, sucursal As Integer) As DataTable
      Return EjecutaConConexion(Function()
                                   Dim stb As StringBuilder = New StringBuilder()
                                   With stb
                                      .Append(" SELECT CU.IdSucursal, CU.IdCalendario, CU.IdUsuario, U.Nombre, CU.PermitirEscritura  ")
                                      .Append(" FROM CalendariosUsuarios CU  ")
                                      .AppendLine(" INNER JOIN Usuarios U ON U.Id = CU.IdUsuario")
                                      .Append(" WHERE IdCalendario = " & IdCalendario)
                                      If sucursal <> 0 Then
                                         .Append(" AND IdSucursal = " & sucursal)
                                      End If

                                      .Append(" ORDER BY IdCalendario")
                                   End With

                                   Return Me.da.GetDataTable(stb.ToString())
                                End Function)
   End Function

   'GAR: 07/06/2018 - Moverlo a SQLServer !!
   Public Function GetCalendarioPorUsuario(idCalendario As Integer, idSucursal As Integer, idUsuario As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine(" SELECT CU.IdSucursal, CU.IdCalendario, CU.IdUsuario, U.Nombre, CU.PermitirEscritura, IdCaja ,C.*")
         .AppendFormatLine(" FROM CalendariosUsuarios CU  ")
         .AppendFormatLine(" INNER JOIN Usuarios U ON U.Id = CU.IdUsuario")
         .AppendFormatLine(" INNER JOIN Calendarios C ON C.IdCalendario = CU.IdCalendario")
         .AppendFormatLine(" LEFT JOIN CalendariosSucursales CS ON C.IdCalendario = CS.IdCalendario AND CS.IdSucursal = {0}", actual.Sucursal.Id)
         .AppendFormatLine(" WHERE CU.IdSucursal = {0}", idSucursal)
         If idCalendario > 0 Then
            .AppendFormatLine("  AND CU.IdCalendario = {0}", idCalendario)
         End If
         .AppendFormatLine("  AND CU.IdUsuario = '{0}'", idUsuario)
         .AppendFormatLine(" ORDER BY C.NombreCalendario")
      End With

      Return Me.da.GetDataTable(stb.ToString())
   End Function


   Public Function GetCalendariosxUsuario(sucursal As Integer, idUsuario As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine(" SELECT CU.*, C.NombreCalendario from CalendariosUsuarios CU ")
         .AppendFormatLine(" INNER JOIN Calendarios C ON C.IdCalendario = CU.IdCalendario ")
         .AppendFormatLine(" INNER JOIN Sucursales S ON S.IdSucursal = CU.IdSucursal")
         .AppendFormatLine(" WHERE CU.IdSucursal = {0}", sucursal)
         .AppendFormatLine(" AND CU.IdUsuario = '{0}'", idUsuario)
         .AppendFormatLine(" AND C.Activo = 'True'")
         .AppendFormatLine("  UNION ")
         .AppendFormatLine("  SELECT IdSucursal,IdCalendario,IdUsuario, '', NombreCalendario FROM Calendarios ")
         .AppendFormatLine("  WHERE IdUsuario = '{0}'", idUsuario)
         ' .AppendLine(" ORDER BY C.NombreCalendario")
      End With

      Return Me.da.GetDataTable(stb.ToString())
   End Function

#End Region
End Class