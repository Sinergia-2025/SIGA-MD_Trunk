Public Class FechasSincronizaciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.FechaSincronizacion.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Inserta(DirectCast(entidad, Entidades.FechaSincronizacion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualiza(DirectCast(entidad, Entidades.FechaSincronizacion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borra(DirectCast(entidad, Entidades.FechaSincronizacion)))
   End Sub
   Public Sub Merger(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Merge(DirectCast(entidad, Entidades.FechaSincronizacion)))
   End Sub


   '# Inserta Solo Con Transacción
   Public Sub _Inserta(entidad As Entidades.FechaSincronizacion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualiza(entidad As Entidades.FechaSincronizacion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borra(entidad As Entidades.FechaSincronizacion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Merge(entidad As Entidades.FechaSincronizacion)
      EjecutaSoloConTransaccion(Function()
                                   EjecutaSP(entidad, TipoSP._M)
                                   Return True
                                End Function)
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return Nothing
   End Function
   Public Overrides Function GetAll() As DataTable
      Dim sFechasSincronizaciones = New SqlServer.FechasSincronizaciones(da)
      Return sFechasSincronizaciones.FechasSincronizaciones_GA()
   End Function

#End Region

#Region "Métodos Públicos"
   Public Function Get1(sistemaDestino As String, tabla As String) As DataTable
      Return New SqlServer.FechasSincronizaciones(da).FechasSincronizaciones_G1(sistemaDestino, tabla)
   End Function
   Public Function GetUno(sistemaDestino As String, tabla As String) As Entidades.FechaSincronizacion
      Return CargaEntidad(Get1(sistemaDestino, tabla), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.FechaSincronizacion(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el registro de Fechas Sincronizaciones: {0} {1}", sistemaDestino, tabla))
   End Function
   Public Function GetTodos() As List(Of Entidades.FechaSincronizacion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.FechaSincronizacion)
   End Function

   Public Function GetFechaUltimaSincronizacion(sistemaDestino As String, tabla As String) As Date?
      Using dt = New SqlServer.FechasSincronizaciones(da).GetFechaUltimaSincronizacion(sistemaDestino, tabla)
         If dt.Any() Then
            Return dt.First().Field(Of Date?)("FechaActualizacion")
         Else
            Return Nothing
         End If
      End Using
   End Function

#End Region
#Region "Métodos Privados"
   Private Sub EjecutaSP(en As Entidades.FechaSincronizacion, tipo As TipoSP)
      Dim sFechasSincronizaciones As SqlServer.FechasSincronizaciones = New SqlServer.FechasSincronizaciones(da)
      Select Case tipo
         Case TipoSP._I
            sFechasSincronizaciones.FechasSincronizaciones_I(en.SistemaDestino, en.Tabla, en.FechaInicioSubida, en.FechaInicioBajada, en.FechaSubida, en.FechaBajada,
                                                             en.IdUsuario, en.FechaActualizacion.IfNull(New Date(1900, 1, 1)), en.NroVersionAplicacion, en.MetodoGrabacionActual, en.IdFuncion)
         Case TipoSP._U
            sFechasSincronizaciones.FechasSincronizaciones_U(en.SistemaDestino, en.Tabla, en.FechaInicioSubida, en.FechaInicioBajada, en.FechaSubida, en.FechaBajada,
                                                             en.IdUsuario, en.FechaActualizacion.IfNull(New Date(1900, 1, 1)), en.NroVersionAplicacion, en.MetodoGrabacionActual, en.IdFuncion)
         Case TipoSP._M
            sFechasSincronizaciones.FechasSincronizaciones_M(en.SistemaDestino, en.Tabla, en.FechaInicioSubida, en.FechaInicioBajada, en.FechaSubida, en.FechaBajada,
                                                             en.IdUsuario, en.FechaActualizacion, en.NroVersionAplicacion, en.MetodoGrabacionActual, en.IdFuncion)
         Case TipoSP._D
            sFechasSincronizaciones.FechasSincronizaciones_D(en.SistemaDestino, en.Tabla)
      End Select
   End Sub

   Private Sub CargarUno(eFechaSincronizacion As Entidades.FechaSincronizacion, dr As DataRow)
      With eFechaSincronizacion
         .SistemaDestino = dr.Field(Of String)(Entidades.FechaSincronizacion.Columnas.SistemaDestino.ToString())
         .Tabla = dr.Field(Of String)(Entidades.FechaSincronizacion.Columnas.Tabla.ToString())
         .FechaActualizacion = dr.Field(Of Date)(Entidades.FechaSincronizacion.Columnas.FechaActualizacion.ToString())
         .FechaInicioSubida = dr.Field(Of Date?)(Entidades.FechaSincronizacion.Columnas.FechaInicioSubida.ToString())
         .FechaInicioBajada = dr.Field(Of Date?)(Entidades.FechaSincronizacion.Columnas.FechaInicioBajada.ToString())
         .FechaSubida = dr.Field(Of Date?)(Entidades.FechaSincronizacion.Columnas.FechaSubida.ToString())
         .FechaBajada = dr.Field(Of Date?)(Entidades.FechaSincronizacion.Columnas.FechaBajada.ToString())
         .NroVersionAplicacion = dr.Field(Of String)(Entidades.FechaSincronizacion.Columnas.NroVersionAplicacion.ToString())
         .IdUsuario = dr.Field(Of String)(Entidades.FechaSincronizacion.Columnas.IdUsuario.ToString())

         Dim mg = dr.Field(Of String)(Entidades.FechaSincronizacion.Columnas.MetodoGrabacion.ToString())
         .MetodoGrabacionActual = If(mg = "M", Entidades.Entidad.MetodoGrabacion.Manual, Entidades.Entidad.MetodoGrabacion.Automatico)
         .IdFuncion = dr.Field(Of String)(Entidades.FechaSincronizacion.Columnas.IdFuncion.ToString())

      End With
   End Sub

   Public Sub ActualizaFechaSubida(sistemaDestino As String, tabla As String, fecha As Date?)
      Dim sql = New SqlServer.FechasSincronizaciones(da)
      sql.FechasSincronizaciones_U_FechaFinalizacion(sistemaDestino, tabla, Entidades.FechaSincronizacion.Columnas.FechaSubida, fecha, Date.Now)
   End Sub
   Public Sub ActualizaFechaBajada(sistemaDestino As String, tabla As String, fecha As Date?)
      Dim sql = New SqlServer.FechasSincronizaciones(da)
      sql.FechasSincronizaciones_U_FechaFinalizacion(sistemaDestino, tabla, Entidades.FechaSincronizacion.Columnas.FechaBajada, fecha, Date.Now)
   End Sub

   Public Sub EvaluaProcesoEnEjecucion(sistemaDestino As String)
      Using dt = GetProcesoEnEjecucion(sistemaDestino)
         If dt.Any() Then
            Dim stb = New StringBuilder()
            stb.AppendFormatLine("El sistema {0} está en ejecución en este momento. No es posible iniciar una nueva ejecución.", sistemaDestino).AppendLine()
            stb.AppendFormatLine("Procesos ejecutando actualmente:")
            Dim fechas = CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.FechaSincronizacion())
            For Each f In fechas
               stb.AppendFormatLine("  - Sistema: {0}", f.SistemaDestino)
               stb.AppendFormatLine("  - Tabla: {0}", f.Tabla)
               If f.FechaInicioBajada.HasValue And Not f.FechaBajada.HasValue Then
                  stb.AppendFormatLine("  - Inicio Bajada: {0}", f.FechaInicioBajada.Value)
               End If
               If f.FechaInicioSubida.HasValue And Not f.FechaSubida.HasValue Then
                  stb.AppendFormatLine("  - Inicio Subida: {0}", f.FechaInicioSubida.Value)
               End If
               stb.AppendFormatLine("  - Usuario: {0}", f.IdUsuario)
               stb.AppendFormatLine("  - Metodo: {0}", f.MetodoGrabacionActual.ToString())
               stb.AppendFormatLine("  - Función: {0}", f.IdFuncion)
            Next
            Throw New Exception(stb.ToString())
         End If
      End Using
   End Sub
   Private Function GetProcesoEnEjecucion(sistemaDestino As String) As DataTable
      Return New SqlServer.FechasSincronizaciones(da).FechasSincronizaciones_GA_EnEjecucion(sistemaDestino)
   End Function

#End Region

End Class