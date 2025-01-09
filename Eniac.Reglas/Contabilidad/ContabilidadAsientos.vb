Public Class ContabilidadAsientos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ContabilidadAsientos"
      da = accesoDatos
   End Sub

#End Region

   Private Sub CargarUna(o As Entidades.ContabilidadAsiento, dr As DataRow, dtDetalle As DataTable)
      With o
         .IdEjercicio = dr.Field(Of Integer)(Entidades.ContabilidadAsiento.Columnas.IdEjercicio.ToString())
         .IdEjercicioNuevo = dr.Field(Of Integer)(Entidades.ContabilidadAsiento.Columnas.IdEjercicio.ToString())
         .IdPlanCuenta = dr.Field(Of Integer)(Entidades.ContabilidadAsiento.Columnas.IdPlanCuenta.ToString())
         .IdAsiento = dr.Field(Of Integer)(Entidades.ContabilidadAsiento.Columnas.IdAsiento.ToString())
         .FechaAsiento = dr.Field(Of Date)(Entidades.ContabilidadAsiento.Columnas.FechaAsiento.ToString())
         .NombreAsiento = dr.Field(Of String)(Entidades.ContabilidadAsiento.Columnas.NombreAsiento.ToString())
         .IdTipoDoc = dr.Field(Of Integer)(Entidades.ContabilidadAsiento.Columnas.IdTipoDoc.ToString())
         .IdSucursal = dr.Field(Of Integer)(Entidades.ContabilidadAsiento.Columnas.idSucursal.ToString())
         .SubsiAsiento = dr.Field(Of String)(Entidades.ContabilidadAsiento.Columnas.SubsiAsiento.ToString()).IfNull().Trim()
         .EsManual = dr.Field(Of Boolean)(Entidades.ContabilidadAsiento.Columnas.EsManual.ToString())
         .FechaExportacion = dr.Field(Of Date?)(Entidades.ContabilidadAsiento.Columnas.FechaExportacion.ToString()).IfNull(New Date())
         .IdEstadoAsiento = dr.Field(Of Integer)(Entidades.ContabilidadAsiento.Columnas.IdEstadoAsiento.ToString())
         .TipoAsiento = dr.Field(Of String)(Entidades.ContabilidadAsiento.Columnas.TipoAsiento.ToString())
         .DetallesAsiento = dtDetalle
      End With
   End Sub

   Public Function GetTodos() As List(Of Entidades.ContabilidadAsiento)
      ' no cargo los detalles del asiento cuando muestro la grilla de busqueda
      Return CargaLista(GetAll(), Sub(o, dr) CargarUna(o, dr, dtDetalle:=Nothing), Function() New Entidades.ContabilidadAsiento())
   End Function

   Public Function GetUna(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer) As Entidades.ContabilidadAsiento
      Dim sql As SqlServer.ContabilidadAsientos = New SqlServer.ContabilidadAsientos(da)
      Return CargaEntidad(sql.Asientos_G1(idEjercicio, idPlanCuenta, idAsiento),
                          Sub(o, dr) CargarUna(o, dr, sql.Asiento_GetDetalle(idEjercicio, idPlanCuenta, idAsiento)),
                          Function() New Entidades.ContabilidadAsiento(),
                          AccionesSiNoExisteRegistro.Excepcion,
                          Function() String.Format("No existe el asiento con Ejercicio {0}, Plan {1} y Asiento {2}", idEjercicio, idPlanCuenta, idAsiento))
   End Function

   Public Function Get1(idEjercicio As Integer, idPlan As Integer, idAsiento As Integer) As DataTable
      Return New SqlServer.ContabilidadAsientos(da).Asientos_G1(idEjercicio, idPlan, idAsiento)
   End Function

   Public Function GetPorIdASiento(idPlanCuenta As Integer, idAsiento As Integer) As DataTable
      Dim idAsientoNull As Integer? = Nothing
      If idAsiento > 0 Then
         idAsientoNull = idAsiento
      End If
      Return New SqlServer.ContabilidadAsientos(da).Asientos_GA(idEjercicio:=Nothing, idPlanCuenta:=idPlanCuenta, idAsiento:=idAsientoNull)
   End Function

   Public Function GetPorNombre(dscAsiento As String) As DataTable
      Return New SqlServer.ContabilidadAsientos(da).GetPorNombre(dscAsiento)
   End Function

   Public Function GetManualesSinVincular(idPlanCuenta As Integer?, idAsiento As Integer?, nombreAsiento As String) As DataTable
      Return New SqlServer.ContabilidadAsientos(da).Asientos_GA(idPlanCuenta, idAsiento, nombreAsiento, manual:=True, vinculado:=False)
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ContabilidadAsientos(da).Asientos_GA()
   End Function

   Public Overloads Function GetAll(meses As Integer, idEstadoAsiento As Integer) As DataTable
      Return New SqlServer.ContabilidadAsientos(da).Asientos_GA(meses, idEstadoAsiento)
   End Function

   Public Function GetIdMaximo(idEjercicio As Integer, idPlan As Integer) As Integer
      Return New SqlServer.ContabilidadAsientos(da).Asiento_GetIdMaximo(idEjercicio, idPlan)
   End Function

   Public Function GetModelos(idPlanCuenta As Integer, dscmodelo As String) As DataTable
      Return New SqlServer.ContabilidadAsientosModelos(da).Asientos_GAD(idPlanCuenta, dscmodelo)
   End Function

   Public Function GetFechasExportacion() As DataTable
      Return New SqlServer.ContabilidadAsientos(da).GetFechasExportacion()
   End Function

#Region "Renumarar Asientos"
   Public Sub EjecutaRenumerarAsientos(idEjercicio As Integer)
      EjecutaConTransaccion(Sub() _EjecutaRenumerarAsientos(idEjercicio))
   End Sub

   Public Sub EjecutaRenumerarAsientos(idEjercicio As Integer, idPlanCuenta As Integer)
      EjecutaConTransaccion(Sub() _EjecutaRenumerarAsientos(idEjercicio, idPlanCuenta))
   End Sub

   Private Sub _EjecutaRenumerarAsientos(idEjercicio As Integer)
      Dim planes As List(Of Entidades.ContabilidadPlan)
      planes = New ContabilidadPlanes(da).GetTodos()

      'Ejecuto la renumeración para todos los planes del ejercicio
      For Each plan As Entidades.ContabilidadPlan In planes
         OnAvanceRenumerarAsientos(String.Format("Procesando Plan de Cuentas: {0}", plan.NombrePlanCuenta))
         _EjecutaRenumerarAsientos(idEjercicio, plan.IdPlanCuenta)
      Next
   End Sub

   Private Sub _EjecutaRenumerarAsientos(idEjercicio As Integer, idPlanCuenta As Integer)
      Dim sql As SqlServer.ContabilidadAsientos = New SqlServer.ContabilidadAsientos(da)
      sql.EjecutaRenumerarAsientos(idEjercicio, idPlanCuenta)
   End Sub

   Protected Sub OnAvanceRenumerarAsientos(estado As String)
      OnAvanceRenumerarAsientos(New EstadoRenumerarAsientos(estado))
   End Sub
   Protected Sub OnAvanceRenumerarAsientos(e As EstadoRenumerarAsientos)
      RaiseEvent AvanceRenumerarAsientos(Me, e)
   End Sub

   Public Event AvanceRenumerarAsientos(sender As Object, e As EstadoRenumerarAsientos)
   Public Class EstadoRenumerarAsientos
      Inherits EventArgs
      Private _estado As String
      Public ReadOnly Property Estado As String
         Get
            Return _estado
         End Get
      End Property
      Public Sub New(estado As String)
         _estado = estado
      End Sub
   End Class

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ContabilidadAsiento)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ContabilidadAsiento)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ContabilidadAsiento)))
   End Sub

   Public Overrides Function Buscar(args As Entidades.Buscar) As DataTable
      Return Buscar(args, idEstadoAsiento:=0)
   End Function

   Public Overloads Function Buscar(entidad As Entidades.Buscar, idEstadoAsiento As Integer) As DataTable
      Return New SqlServer.ContabilidadAsientos(da).Buscar(entidad.Columna, entidad.Valor.ToString(), idEstadoAsiento)
   End Function


   Public Sub _Insertar(entidad As Entidades.ContabilidadAsiento)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.ContabilidadAsiento)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.ContabilidadAsiento)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ContabilidadAsiento, tipo As TipoSP)
      Dim sql = New SqlServer.ContabilidadAsientos(da)

      If tipo = TipoSP._U AndAlso en.IdEjercicio <> 0 AndAlso en.IdEjercicio <> en.IdEjercicioNuevo Then
         Dim ejercicioOriginal = en.IdEjercicio
         Dim asientoOriginal = en.IdAsiento
         en.IdEjercicio = en.IdEjercicioNuevo
         en.IdAsiento = 0
         tipo = TipoSP._I
         _Borrar(New Entidades.ContabilidadAsiento() With
                  {
                     .IdEjercicio = ejercicioOriginal,
                     .IdAsiento = asientoOriginal,
                     .IdPlanCuenta = en.IdPlanCuenta
                  })
      End If

      Select Case tipo
         Case TipoSP._I
            If en.IdAsiento <= 0 Then
               en.IdAsiento = GetIdMaximo(en.IdEjercicio, en.IdPlanCuenta) + 1
            End If
            sql.Asiento_I(en.IdEjercicio,
                          en.IdPlanCuenta,
                          en.IdAsiento,
                          en.FechaAsiento,
                          en.NombreAsiento,
                          en.IdTipoDoc,
                          en.IdSucursal,
                          en.SubsiAsiento,
                          en.EsManual,
                          en.FechaExportacion,
                          en.IdEstadoAsiento,
                          en.TipoAsiento)
            sql.Asiento_I_Detalle(en.IdEjercicio, en.IdPlanCuenta, en.IdAsiento, en.DetallesAsiento)

         Case TipoSP._U
            sql.Asiento_U(en.IdEjercicio,
                          en.IdPlanCuenta,
                          en.IdAsiento,
                          en.FechaAsiento,
                          en.NombreAsiento,
                          en.IdTipoDoc,
                          en.IdSucursal,
                          en.SubsiAsiento,
                          en.EsManual,
                          en.FechaExportacion,
                          en.IdEstadoAsiento,
                          en.TipoAsiento)
            sql.Asiento_U_Detalle(en.IdEjercicio, en.IdPlanCuenta, en.IdAsiento, en.DetallesAsiento)

         Case TipoSP._D
            sql.Asiento_D_Detalle(en.IdEjercicio, en.IdPlanCuenta, en.IdAsiento)
            sql.Asiento_D(en.IdEjercicio, en.IdPlanCuenta, en.IdAsiento)

      End Select
   End Sub

   Public Function GetAsientosAExportar(idPlanCuenta As Integer, fechaDesde As Date, fechaHasta As Date,
                                        exportados As String, fechaExport As Date, subsistemas As IList) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ContabilidadAsientos(da).GetAsientosAExportar(idPlanCuenta, fechaDesde, fechaHasta, exportados, fechaExport, subsistemas))
   End Function

   Public Sub ActualizarFechaExportacion(asientos As DataTable, fechaExportacion As Date)
      EjecutaConTransaccion(
         Sub()
            Dim sql = New SqlServer.ContabilidadAsientos(da)
            asientos.AsEnumerable().ToList().
               ForEach(
                  Sub(dr)
                     sql.Asiento_UFechaExportacion(dr.Field(Of Integer)("IdEjercicio"),
                                                   dr.Field(Of Integer)("IdPlanCuenta"),
                                                   dr.Field(Of Integer)("IdAsiento"),
                                                   fechaExportacion)
                  End Sub)
         End Sub)
   End Sub

#End Region

End Class