Public Class TableroDeComando
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      MyBase.New()
      Me.NombreEntidad = "CuentasCorrientesProv"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

   Public Function GetClientesVersiones(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Try
         Me.da.OpenConection()
         Dim dt As DataTable = New SqlServer.TableroDeComando(da).GetClientesVersiones(filtros)
         For Each dr As DataRow In dt.Rows
            If IsDBNull(dr("DiasVersion")) Then
               dr("Color") = System.ConsoleColor.Blue
            Else
               Dim diasVersion As Integer = Integer.Parse(dr("DiasVersion").ToString())
               If diasVersion > 60 Then
                  dr("Color") = System.ConsoleColor.Red
               ElseIf diasVersion > 45 Then
                  dr("Color") = System.ConsoleColor.Yellow
               ElseIf diasVersion >= 0 Then
                  dr("Color") = System.ConsoleColor.Green
               End If
            End If
         Next
         Return dt
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetClientesPCs(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Try
         Me.da.OpenConection()
         Dim dt As DataTable = New SqlServer.TableroDeComando(da).GetClientesPCs(filtros)
         For Each dr As DataRow In dt.Rows
            If IsDBNull(dr("DeltaPC")) Then
               dr("Color") = System.ConsoleColor.Blue
            Else
               Dim deltaPC As Integer = Integer.Parse(dr("DeltaPC").ToString())
               If deltaPC < -1 Then
                  dr("Color") = System.ConsoleColor.Red
               ElseIf deltaPC < 0 Then
                  dr("Color") = System.ConsoleColor.Yellow
               ElseIf deltaPC >= 0 Then
                  dr("Color") = System.ConsoleColor.Green
               End If
            End If
         Next
         Return dt
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetFechaLargada(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Try
         Me.da.OpenConection()
         Dim dt As DataTable = New SqlServer.TableroDeComando(da).GetFechaLargada(filtros)
         For Each dr As DataRow In dt.Rows
            If Not IsDate(dr("FechaInicioReal")) Then
               If IsDate(dr("FechaInicio")) Then
                  If Date.Parse(dr("FechaInicio").ToString()).Date < Today.Date Then
                     dr("Color") = System.ConsoleColor.Red
                  ElseIf Date.Parse(dr("FechaInicio").ToString()).Date < Today.Date.AddDays(7) Then
                     dr("Color") = System.ConsoleColor.Yellow
                  Else
                     dr("Color") = System.ConsoleColor.Green
                  End If
               Else
                  dr("Color") = System.ConsoleColor.Blue
               End If
            End If
         Next
         Return dt
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetClientesBackups(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Try
         Me.da.OpenConection()
         Dim dt As DataTable = New SqlServer.TableroDeComando(da).GetClientesBackups(filtros)
         For Each dr As DataRow In dt.Rows
            If Not IsDBNull(dr("FechaInicioBackupUltimo")) Then
               If IsDBNull(dr("FechaFinBackup")) Then
                  dr("Color") = System.ConsoleColor.Red
               Else
                  Dim fechaIni As DateTime = DateTime.MinValue
                  If IsDate(dr("FechaInicioBackup")) Then
                     fechaIni = DateTime.Parse(dr("FechaInicioBackup").ToString())
                  End If
                  Dim fechaFin As DateTime = DateTime.Parse(dr("FechaFinBackup").ToString())
                  Dim diasBackup As Integer = Integer.Parse(dr("DiasBackup").ToString())
                  If diasBackup < 2 Then
                     dr("Color") = System.ConsoleColor.Green
                  ElseIf diasBackup < 3 Then
                     dr("Color") = System.ConsoleColor.Yellow
                  Else ''If diasBackup >= 3 Then
                     dr("Color") = System.ConsoleColor.Red
                  End If
                  dr("TiempoBackup") = fechaFin.Subtract(fechaIni).ToString("hh\:mm")
               End If
            End If
         Next
         Return dt
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetClientesVersionBackup(categorias As Entidades.Categoria(), actualizarAplicacion As Entidades.Publicos.SiNoTodos) As DataTable
      Try
         Me.da.OpenConection()
         Dim dt As DataTable = New SqlServer.TableroDeComando(da).GetClientesVersionBackup(categorias, actualizarAplicacion)
         Return dt
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetClientesVencimientoLicencias(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Try
         Me.da.OpenConection()
         Dim dt As DataTable = New SqlServer.TableroDeComando(da).GetClientesVencimientoLicencias(filtros)
         For Each dr As DataRow In dt.Rows
            If IsDBNull(dr("DiasVencimientoLicencia")) Then
               dr("Color") = System.ConsoleColor.Blue
            Else
               Dim diasVersion As Integer = Integer.Parse(dr("DiasVencimientoLicencia").ToString())
               Const diasRojo As Integer = 5
               Const diasAmarillo As Integer = 15
               If diasVersion < diasRojo Then
                  dr("Color") = System.ConsoleColor.Red
               ElseIf diasVersion >= diasRojo And diasVersion < diasAmarillo Then
                  dr("Color") = System.ConsoleColor.Yellow
               ElseIf diasVersion >= diasAmarillo Then
                  dr("Color") = System.ConsoleColor.Green
               End If
            End If
         Next
         Return dt
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetInfVencimientoLicencias(idCliente As Long, fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable

      Return New SqlServer.TableroDeComando(da).GetInfVencimientoLicencias(idCliente, fechaDesde, fechaHasta)

   End Function


   Public Function GetActualizadorAutomatico(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Try
         Me.da.OpenConection()
         Dim dt = New SqlServer.TableroDeComando(da).GetClientesActualizaciones(filtros)
         For Each dr As DataRow In dt.Rows
            Dim estado As String = dr.Field(Of String)("Estado")
            Dim activo As Boolean? = dr.Field(Of Boolean?)("Activo")
            If estado = Entidades.ClienteActualizacion.EstadoActualizacion.ConError.ToString() Then
               If activo.HasValue AndAlso activo.Value Then
                  dr("Color") = System.ConsoleColor.Red
               Else
                  dr("Color") = System.ConsoleColor.DarkCyan
               End If
            ElseIf estado = Entidades.ClienteActualizacion.EstadoActualizacion.Inicio.ToString() Then
               dr("Color") = System.ConsoleColor.Yellow
            ElseIf estado = Entidades.ClienteActualizacion.EstadoActualizacion.Finalizado.ToString() Then
               dr("Color") = System.ConsoleColor.Green
            End If
         Next
         Return dt
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetActualizadorAutomaticoAlerta(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim dt As DataTable = GetActualizadorAutomatico(filtros)

      Dim rows = dt.AsEnumerable().Where(Function(dr) (dr.Field(Of DateTime?)("FechaInicioActualizacion").HasValue AndAlso dr.Field(Of DateTime?)("FechaInicioActualizacion").Value.Date = Today) Or
                                                      (dr.Field(Of String)("Estado") = Entidades.ClienteActualizacion.EstadoActualizacion.ConError.ToString() And
                                                       (dr.Field(Of Boolean?)("Activo").HasValue AndAlso dr.Field(Of Boolean?)("Activo").Value)))

      If rows.Count > 0 Then
         dt = rows.CopyToDataTable()
      Else
         dt.Clear()
      End If

      Return dt
   End Function


   Public Function GetTickets() As DataTable
      Try
         Me.da.OpenConection()
         Dim dt As DataTable = New SqlServer.TableroDeComando(da).GetNovedades("TICKETS")
         Return dt
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function GetPendientes() As DataTable
      Try
         Me.da.OpenConection()
         Dim dt As DataTable = New SqlServer.TableroDeComando(da).GetNovedades("PENDIENTE")
         Return dt
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCRMSituacionPorTipoEstado(filtros As Entidades.TablerosDeComando.FiltroTableros, mostrarDetalleEstados As Boolean) As DataTable

      Dim fechaDesde = Today '.AddDays(-1)
      Dim fechaHasta = fechaDesde.UltimoSegundoDelDia()

      Dim dt = EjecutaConConexion(Function()
                                     Dim diasHabilesMes = New Reglas.Feriados(da).GetDiasHabiles(fechaDesde.ToPeriodo()).Habiles
                                     Dim diasHabilesHoy = New Reglas.Feriados(da).GetDiasHabilesAFecha(fechaDesde).Habiles

                                     Return New SqlServer.TableroDeComando(da).GetCRMSituacionPorTipoEstado(fechaDesde, fechaHasta, filtros, mostrarDetalleEstados,
                                                                                                            diasHabilesMes, diasHabilesHoy)
                                  End Function)
      Dim exp = String.Join(" + ", dt.Columns.OfType(Of DataColumn).Where(Function(dc) dc.ColumnName.StartsWith("____")).Select(Function(dc) String.Format("ISNULL([{0}], 0)", dc.ColumnName)).ToArray())
      dt.Columns.Add("Total", GetType(Integer), If(String.IsNullOrWhiteSpace(exp), "0", exp))
      Return dt
   End Function

   Public Function GetPerformanceParaCRMEntregadoMensual(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim fechaDesde = Today.PrimerDiaMes().AddMonths(Reglas.Publicos.RMACantidadMesesHistorico * -1)
      Dim fechaHasta = Today.UltimoDiaMes(True)

      Dim dt = EjecutaConConexion(Function() New SqlServer.TableroDeComando(da).GetPerformanceParaCRMEntregadoMensual(fechaDesde, fechaHasta, filtros))

      Return dt
   End Function
   Public Function GetCRMEntregadoMensual(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim fechaDesde = Today.PrimerDiaMes().AddMonths(Reglas.Publicos.RMACantidadMesesHistorico * -1)
      Dim fechaHasta = Today.UltimoDiaMes(True)

      Dim dt = EjecutaConConexion(Function() New SqlServer.TableroDeComando(da).GetCRMEntregadoMensual(fechaDesde, fechaHasta, filtros))
      Dim exp = String.Join(" + ", dt.Columns.OfType(Of DataColumn).Where(Function(dc) dc.ColumnName.StartsWith("____")).Select(Function(dc) String.Format("ISNULL([{0}], 0)", dc.ColumnName)).ToArray())
      dt.Columns.Add("Total", GetType(Integer), exp)
      Return dt
   End Function
   Public Function CRMTotalEquiposReparados(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Dim dt = EjecutaConConexion(Function() New SqlServer.TableroDeComando(da).CRMTotalEquiposReparados(filtros))

      dt.Columns("IdUsuarioAsignado").Caption = "Usuario"
      dt.Columns("Hoy").Caption = "Hoy"
      dt.Columns("mes___actual").Caption = Date.Today.GetMesEnEspanol()
      dt.Columns("mes___1").Caption = Date.Today.PrimerDiaMes().AddMonths(-1).GetMesEnEspanol()
      dt.Columns("mes___2").Caption = Date.Today.PrimerDiaMes().AddMonths(-2).GetMesEnEspanol()
      dt.Columns("mes___3").Caption = Date.Today.PrimerDiaMes().AddMonths(-3).GetMesEnEspanol()

      Return dt
   End Function

   Public Function GetEntregasMensualesPorEstado(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.TableroDeComando(da).GetEntregasMensualesPorEstado(filtros))
   End Function

   Public Function GetCRMGlobalEntrega(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.TableroDeComando(da).GetCRMGlobalEntrega(filtros, 1))
   End Function
   Public Function GetCRMGlobalEntregaHistorico(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.TableroDeComando(da).GetCRMGlobalEntrega(filtros, Reglas.Publicos.RMACantidadMesesHistorico))
   End Function

   Private Class VersionAdmin
      Public Property VersionWebMovilAdmin As String
      Public Property VersionApi As String
   End Class
   Public Function GetVersionesApi(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Try
         Me.da.OpenConection()
         Dim dt As DataTable = New SqlServer.TableroDeComando(da).GetClientesApi(filtros)
         Return dt
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Sub EliminarClientesBackups(idCliente As Long,
                                      nombreServidor As String,
                                      baseDatos As String)
      Dim sql As SqlServer.TableroDeComando = New SqlServer.TableroDeComando(da)
      Try
         da.OpenConection()
         da.BeginTransaction()

         ' # Inactivo el backup # '
         sql.EliminarClientesBackups(idCliente,
                                     nombreServidor,
                                     baseDatos)
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
End Class