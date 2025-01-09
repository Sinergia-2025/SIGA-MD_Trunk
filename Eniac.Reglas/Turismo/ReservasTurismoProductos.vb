Public Class ReservasTurismoProductos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ReservasTurismoProductos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ReservasTurismo = New SqlServer.ReservasTurismo(Me.da)
      '   Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ReservasTurismo(Me.da).ReservasTurismo_GA()
   End Function

   'Public Overloads Function GetAll(TipoNovedad As Entidades.CRMTipoNovedad) As System.Data.DataTable
   '   If TipoNovedad Is Nothing Then
   '      Return GetAll()
   '   Else
   '      Return GetAll(TipoNovedad.IdTipoNovedad, False)
   '   End If
   'End Function
   'Public Overloads Function GetAll(idTipoNovedad As String, ordenarPosicion As Boolean) As System.Data.DataTable
   '   Return New SqlServer.Reservas(Me.da).Reservas_GA()
   'End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.ReservaTurismo = DirectCast(entidad, Entidades.ReservaTurismo)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.ReservasTurismo = New SqlServer.ReservasTurismo(da)
         Select Case tipo
            Case TipoSP._I
               'sqlC.Reservas_I(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor,
               '                           en.NumeroReserva, en.Fecha, en.IdEstablecimiento, en.IdCurso, en.Division,
               '                           en.IdTurno, en.IdResponsable, en.IdPrograma, en.Mes, en.QuincenaSemana,
               '                           en.Dia, en.IdTipoVehiculo, en.CapacidadMax, en.LugarSalida, en.CantidadAlumnos,
               '                           en.Costo, en.BaseAlumnos, en.IdFormaPago, en.Liberados, en.Seguimiento,
               '                           en.CDDigital, en.IdEstadoTurismo, en.IdUsuarioAlta, en.IdUsuarioEstadoTurismo,
               '                           en.FechaEstadoTurismo, en.BanderaColor)
            Case TipoSP._U
               'sqlC.Reservas_U(en.IdEstadoNovedad, en.NombreEstadoNovedad, en.Posicion, en.SolicitaUsuario,
               '                           en.Finalizado, en.IdTipoNovedad, en.PorDefecto, en.Color,
               '                           en.DiasProximoContacto, en.ActualizaUsuarioResponsable, en.SolicitaProveedorService,
               '                           en.Imprime, en.Reporte, en.Embebido)
            Case TipoSP._D
               ' sqlC.Reservas_D(en.IdEstadoNovedad)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ReservaTurismoProducto, ByVal dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.ReservaTurismoProducto.Columnas.IdSucursal.ToString())
         .IdTipoReserva = dr.Field(Of String)(Entidades.ReservaTurismoProducto.Columnas.IdTipoReserva.ToString())
         .Letra = dr.Field(Of String)(Entidades.ReservaTurismoProducto.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.ReservaTurismoProducto.Columnas.CentroEmisor.ToString())
         .NumeroReserva = dr.Field(Of Long)(Entidades.ReservaTurismoProducto.Columnas.NumeroReserva.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.ReservaTurismoProducto.Columnas.IdProducto.ToString())
         .IdProductoComponente = dr.Field(Of String)(Entidades.ReservaTurismoProducto.Columnas.IdProductoComponente.ToString())
         .IdFormula = dr.Field(Of Integer)(Entidades.ReservaTurismoProducto.Columnas.IdFormula.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.ReservaTurismoProducto.Columnas.Orden.ToString())
         .NombreProducto = dr.Field(Of String)(Entidades.ReservaTurismoProducto.Columnas.NombreProducto.ToString())
         .NombreProducto1 = dr.Field(Of String)(Entidades.ReservaTurismoProducto.Columnas.NombreProducto1.ToString())
         .NombreSubRubro = dr.Field(Of String)(Entidades.ReservaTurismoProducto.Columnas.NombreSubRubro.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, Numero As Long, accion As AccionesSiNoExisteRegistro) As Entidades.ReservaTurismoProducto
      Return CargaEntidad(New SqlServer.ReservasTurismoProductos(Me.da).ReservasTurismoProductos_G1(idSucursal, idTipoReserva, letra, centroEmisor, Numero),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ReservaTurismoProducto(),
                          accion, Function() String.Format("No existe la Reserva Numero: {0}", Numero))
   End Function

   Public Function GetTodos(Optional ordenarPosicion As Boolean = False) As List(Of Entidades.ReservaTurismoProducto)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.ReservaTurismoProducto), dr),
                        Function() New Entidades.ReservaTurismoProducto())
   End Function

   Public Function GetCodigoMaximo() As Integer
      '  Return New SqlServer.Reservas(Me.da).GetCodigoMaximo()
   End Function

   'Public Function GetPosicionMaxima(idTipoNovedad As String) As Integer
   '   Return Convert.ToInt32(New SqlServer.Reservas(Me.da).
   '                                    GetCodigoMaximo(Entidades.Reserva.Columnas.Posicion.ToString(),
   '                                                    "Reservas",
   '                                                    String.Format("{0} = '{1}'", Entidades.Reserva.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)))
   'End Function

   Public Function GetReservasProductos(idsucursal As Integer, idTipoReserva As String, letra As String,
                                          centroemisor As Short, NumeroReserva As Long, IdFormula As Integer) As DataTable

      Return New SqlServer.ReservasTurismoProductos(Me.da).GetReservaProductos(idsucursal, idTipoReserva, letra, centroemisor,
                                                       NumeroReserva, IdFormula)

   End Function

   Public Function GetReservaProducto2(idsucursal As Integer, idTipoReserva As String, letra As String,
                                          centroemisor As Short, NumeroReserva As Long, IdFormula As Integer) As List(Of Entidades.ReservaTurismoProducto)
      Return CargaLista(Me.GetReservasProductos(idsucursal, idTipoReserva, letra, centroemisor, NumeroReserva, IdFormula),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.ReservaTurismoProducto), dr),
                        Function() New Entidades.ReservaTurismoProducto())
   End Function


#End Region
End Class