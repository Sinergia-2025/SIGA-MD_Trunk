Public Class ContabilidadEjercicios
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ContabilidadEjercicios"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ContabilidadEjercicio), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ContabilidadEjercicio), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ContabilidadEjercicio), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ContabilidadEjercicios(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return GetAll(cantidadPeriodosPivot:=0)
   End Function

   Public Function GetEjerciciosAbiertos() As DataTable
      Return New SqlServer.ContabilidadEjercicios(da).GetEjerciciosAbiertos()
   End Function

   Public Function GetTodosAbiertos() As List(Of Entidades.ContabilidadEjercicio)
      ' no cargo los detalles del asiento cuando muestro la grilla de busqueda
      Return CargaLista(GetEjerciciosAbiertos(),
                        Sub(o, dr) CargarUna(o, dr, dtDetalle:=Nothing), Function() New Entidades.ContabilidadEjercicio())
   End Function

   Private Overloads Function GetAll(cantidadPeriodosPivot As Integer) As DataTable
      Return New SqlServer.ContabilidadEjercicios(da).Ejercicios_GA(cantidadPeriodosPivot)
   End Function
   Public Overloads Function GetAllABM() As DataTable
      Dim sql = New SqlServer.ContabilidadEjercicios(da)
      Dim cantidadPeriodosPivot = sql.GetMaximoOrdenPeriodo()
      Return sql.Ejercicios_GA(cantidadPeriodosPivot)
   End Function

#End Region

#Region "Metodos Privados"


   Public Function EstaPeriodoCerrado(fecha As Date) As Boolean 'Devuelve el estado del periodo
      Dim codEjeVigente = GetEjercicioVigente(fecha)
      Dim idPeriodoActual = GetPeriodoActual(codEjeVigente, fecha)

      Return EstaPeriodoCerrado(codEjeVigente, idPeriodoActual)
   End Function

   Public Function EstaPeriodoCerrado(idEjercicio As Integer, idPeriodo As String) As Boolean 'Devuelve el estado del periodo
      Dim cerrado = New SqlServer.ContabilidadEjercicios(da).EstaPeriodoCerrado(idEjercicio, idPeriodo)

      If Not cerrado Then
         Return cerrado
      Else
         Throw New Exception(String.Format("El Período Contable {0} se encuentra cerrado. No es posible completar la operación.", idPeriodo))
      End If
   End Function

   Public Function GetEjercicioVigente(fechaAsiento As Date) As Integer
      Dim idEjercicio = New SqlServer.ContabilidadEjercicios(da).GetEjercicioVigente(fechaAsiento, soloAbierto:=True)

      If idEjercicio > 0 Then
         Return idEjercicio
      Else
         Throw New Exception(String.Format("No Existe Ejercicio Contable Vigente para la Fecha del Movimiento ({0}), o el mismo se encuentra cerrado.", fechaAsiento.ToString("dd/MM/yyyy")))
      End If
   End Function

   Public Function GetPeriodoActual(idEjercicio As Integer, fechaAsiento As Date) As String
      Dim idPeriodo As String = New SqlServer.ContabilidadEjercicios(da).GetPeriodoActual(idEjercicio, fechaAsiento)

      If Not String.IsNullOrEmpty(idPeriodo) Then
         Return idPeriodo
      Else
         Throw New Exception("No Existe Período Contable Vigente para la Fecha del Movimiento, o el mismo se encuentra cerrado.")
      End If
   End Function

   Private Sub EjecutaSP(en As Entidades.ContabilidadEjercicio, tipo As TipoSP)
      Dim sql = New SqlServer.ContabilidadEjercicios(da)

      Select Case tipo
         Case TipoSP._I
            sql.Ejercicios_I(en.IdEjercicio, en.FechaDesde, en.FechaHasta, en.Cerrado)
            sql.Ejercicios_I_Detalle(en.IdEjercicio, en.DetallesPeriodos)

         Case TipoSP._U
            'comprobar que el ejercicio no tenga asientos temporales
            Dim stb = New StringBuilder()
            stb.AppendLine("No se puede cerrar el Ejercicio porque existen asientos temporales para los siguientes periodos:")

            Dim existenAsientosTemporalesEnAnio As Boolean = False
            Dim oContabilidadAsientosTmp As Reglas.ContabilidadAsientosTmp = New ContabilidadAsientosTmp()
            For Each dr As DataRow In en.DetallesPeriodos.Rows
               If dr.Field(Of Boolean)("Cerrado") Then
                  Dim periodoAsDate = Date.Parse(dr.Field(Of String)("IdPeriodo"))
                  Dim existeUnAsientoTemporalEnPeriodo = oContabilidadAsientosTmp.ComprobarExistenciaAsientos_Tmp(
                                                                        periodoAsDate, periodoAsDate.UltimoDiaMes())
                  If False Then
                     stb.AppendFormatLine(" - {0}", dr.Field(Of String)("IdPeriodo"))
                     existenAsientosTemporalesEnAnio = True
                  End If
               ElseIf en.Cerrado Then
                  Throw New Exception("Solo se puede cerrar un ejercicio si todos sus períodos estan cerrados.")
               End If
            Next

            If existenAsientosTemporalesEnAnio Then
               Throw New Exception(stb.ToString())
            End If

            If Not en.Fuerza_VerificaAsientosPendientes Then
               Dim algunErrorAsientosPendientes = False
               Dim stbAsientosPendientes = New StringBuilder()
               stbAsientosPendientes.AppendFormatLine("No se pueden cerrar los siguientes Períodos del Ejercicio porque existen movimientos pendientes:")

               en.DetallesPeriodos.AsEnumerable().ToList().
                     ForEach(Sub(dr)
                                If dr.Field(Of Boolean)("Cerrado") Then
                                   VerificaAsientosPendientes(dr.Field(Of String)("IdPeriodo"), stbAsientosPendientes, algunErrorAsientosPendientes)
                                End If
                             End Sub)
               If algunErrorAsientosPendientes Then
                  Throw New VerificaAsientosPendientesException(stbAsientosPendientes)
               End If
            End If


            sql.Ejercicios_U(en.IdEjercicio, en.FechaDesde, en.FechaHasta, en.Cerrado)
            sql.Ejercicios_D_Detalle(en.IdEjercicio)
            sql.Ejercicios_I_Detalle(en.IdEjercicio, en.DetallesPeriodos)

         Case TipoSP._D
            sql.Ejercicios_D_Detalle(en.IdEjercicio)
            sql.Ejercicios_D(en.IdEjercicio)

      End Select

   End Sub

   Private Sub CargarUna(o As Entidades.ContabilidadEjercicio, dr As DataRow, dtDetalle As DataTable)
      With o
         .IdEjercicio = dr.Field(Of Integer)(Entidades.ContabilidadEjercicio.Columnas.IdEjercicio.ToString())
         .FechaDesde = dr.Field(Of Date)(Entidades.ContabilidadEjercicio.Columnas.FechaDesde.ToString())
         .FechaHasta = dr.Field(Of Date)(Entidades.ContabilidadEjercicio.Columnas.FechaHasta.ToString())
         .Cerrado = dr.Field(Of Boolean)(Entidades.ContabilidadEjercicio.Columnas.Cerrado.ToString())
         .DetallesPeriodos = dtDetalle
      End With
   End Sub

   Public Class VerificaAsientosPendientesException
      Inherits Exception
      Public Sub New(mensaje As StringBuilder)
         MyBase.New(mensaje.ToString())
      End Sub
   End Class
   Private Sub VerificaAsientosPendientes(idPeriodo As String, stb As StringBuilder, ByRef algunErrorAsientosPendientes As Boolean)

      Dim rProceso = New ContabilidadProcesos()
      Dim primero = True

      Dim spltPeriodo = idPeriodo.Split("/"c)
      Dim mes = Integer.Parse(spltPeriodo(0))
      Dim anio = If(spltPeriodo.Count = 1, Today.Year, Integer.Parse(spltPeriodo(1)))

      Dim fechaDesde = New Date(anio, mes, 1)
      Dim fechaHasta = fechaDesde.UltimoDiaMes()

      Dim valida = Sub(dt As DataTable, modulo As String, ByRef algunError As Boolean)
                      If dt.Count > 0 Then
                         If primero Then
                            stb.AppendFormatLine("  - {0}", idPeriodo)
                            primero = False
                         End If
                         stb.AppendFormatLine("    - {0}", modulo)
                         algunError = True
                      End If
                   End Sub

      Using dt = rProceso.ObtenerDatosVentas(fechaDesde, fechaHasta, top:=1)
         valida(dt, "Ventas", algunErrorAsientosPendientes)
      End Using
      Using dt = rProceso.ObtenerDatosCtaCteClte(fechaDesde, fechaHasta, top:=1)
         valida(dt, "Cta. Cte. Cliente", algunErrorAsientosPendientes)
      End Using
      Using dt = rProceso.ObtenerDatosCompras(fechaDesde, fechaHasta, top:=1)
         valida(dt, "Compras", algunErrorAsientosPendientes)
      End Using
      Using dt = rProceso.ObtenerDatosCtaCteProv(fechaDesde, fechaHasta, top:=1)
         valida(dt, "Cta. Cte. Proveedores", algunErrorAsientosPendientes)
      End Using
      Using dt = rProceso.ObtenerDatosCaja(fechaDesde, fechaHasta, top:=1)
         valida(dt, "Cajas", algunErrorAsientosPendientes)
      End Using
      Using dt = rProceso.ObtenerDatosLibroBanco(fechaDesde, fechaHasta, top:=1)
         valida(dt, "Bancos", algunErrorAsientosPendientes)
      End Using
      Using dt = rProceso.ObtenerDatosDepositosBancarios(fechaDesde, fechaHasta, top:=1)
         valida(dt, "Depositos/Extracciones/Transferencias", algunErrorAsientosPendientes)
      End Using

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.ContabilidadEjercicio)
      ' no cargo los detalles del asiento cuando muestro la grilla de busqueda
      Return CargaLista(GetAll(),
                        Sub(o, dr) CargarUna(o, dr, dtDetalle:=Nothing), Function() New Entidades.ContabilidadEjercicio())
   End Function

   Public Function GetUna(idEjercicio As Integer) As Entidades.ContabilidadEjercicio
      Return GetUna(idEjercicio, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idEjercicio As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ContabilidadEjercicio
      Dim sql = New SqlServer.ContabilidadEjercicios(da)
      Return CargaEntidad(Get1(idEjercicio),
                          Sub(o, dr) CargarUna(o, dr, sql.Ejercicio_GetDetalle(idEjercicio)), Function() New Entidades.ContabilidadEjercicio(),
                          accion, Function() String.Format("No existe el ejercicio {0}", idEjercicio))
   End Function

   Public Function GetUna(fechaAsiento As Date, soloAbierto As Boolean) As Entidades.ContabilidadEjercicio
      Dim sql = New SqlServer.ContabilidadEjercicios(da)
      Dim idEjercicio = sql.GetEjercicioVigente(fechaAsiento, soloAbierto)
      If idEjercicio > 0 Then
         Return GetUna(idEjercicio)
      Else
         Throw New Exception(String.Format("No Existe Ejercicio Contable Vigente para la Fecha del Movimiento ({0:dd/MM/yyyy}), o el mismo se encuentra cerrado.", fechaAsiento))
      End If
   End Function

   Public Function Get1(IdEjercicio As Integer) As DataTable
      Return New SqlServer.ContabilidadEjercicios(da).Ejercicios_G1(IdEjercicio)
   End Function

   Public Function GetIdMaximo() As Integer
      Return New SqlServer.ContabilidadEjercicios(da).GetIdMaximo()
   End Function

   Public Function GetFechaMaxima() As Date
      Dim sql = New SqlServer.ContabilidadEjercicios(da)
      Dim val = Today.PrimerDiaMes().AddDays(-1)
      Using dt = sql.Ejercicio_GetFechaMaxima()
         If dt.Rows.Count > 0 Then
            val = dt.Rows(0).Field(Of Date?)("maxima").IfNull(val)
         End If
      End Using
      Return val
   End Function

   Public Function TieneAsientosAsociados(IdEjercicio As Integer) As Boolean
      Return New SqlServer.ContabilidadEjercicios(da).TieneAsientosAsociados(IdEjercicio)
   End Function

   Public Sub CompletaFechasSegunEjercicio(ByRef fechaDesde As Date?, ByRef fechaHasta As Date?)
      If Not fechaHasta.HasValue Then
         Dim fecha = Today
         If fechaDesde.HasValue Then fecha = fechaDesde.Value
         Dim ejercicioVigente = GetUna(fecha, False)
         fechaHasta = ejercicioVigente.FechaHasta
      End If
      If Not fechaDesde.HasValue Then
         Dim ejercicioVigente = GetUna(fechaHasta.Value, False)
         fechaDesde = ejercicioVigente.FechaDesde
      End If
   End Sub

   Public Sub FechasMismoEfercicio(fechaDesde As Date, fechaHasta As Date)
      Dim ejercicioVigente = GetUna(fechaDesde, False)
      If fechaHasta.Date > ejercicioVigente.FechaHasta Or fechaHasta.Date < ejercicioVigente.FechaDesde Then
         Throw New ContabilidadException(String.Format("Las fecha {0:dd/MM/yyyy} y la fecha {1:dd/MM/yyyy} pertenecen a diferentes ejercicios contables.",
                                                       fechaDesde, fechaHasta))
      End If
   End Sub

#End Region

End Class