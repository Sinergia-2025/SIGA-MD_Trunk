Imports Eniac.Reglas.ServiciosRest.Sincronizacion
Public Class Clientes
   Inherits BaseSync(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte, Entidades.JSonEntidades.Archivos.ClienteJSon)
   Implements IRestServices
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte, Entidades.JSonEntidades.Archivos.ClienteJSon)

   Private Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

#Region "Constructores"

   Public Sub New(accesoDatos As Datos.DataAccess, modo As Entidades.Cliente.ModoClienteProspecto)
      Me.New(accesoDatos)
      ModoClienteProspecto = modo
      Me.NombreEntidad = modo.ToString() + "s"
   End Sub

   Public Sub New(modo As Entidades.Cliente.ModoClienteProspecto)
      Me.New()
      ModoClienteProspecto = modo
      Me.NombreEntidad = modo.ToString() + "s"
   End Sub

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente
      Me.NombreEntidad = "Clientes"
      da = accesoDatos
      _puedeVerDetalleValoracionEstrellas = New Usuarios().TienePermisos("PuedeVerDetalleEstrellas")
      _recalculaValoracionesEstrellas = Reglas.Publicos.RecalculaValoracionesEstrellas
   End Sub

#End Region

#Region "Overrides"

   Public Shadows Sub InsertarLIVE(entidad As Entidades.Entidad, listado As DataSet)
      Me.EjecutaSPLIVE(entidad, TipoSP._I, listado)
   End Sub


   Public Shadows Sub ActualizarLIVE(entidad As Entidades.Entidad, descuento As DataSet)
      Me.EjecutaSPLIVE(entidad, TipoSP._U, descuento)
   End Sub

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Inserta(entidad As Eniac.Entidades.Entidad)
      Inserta(entidad, soloTransaccion:=False)
   End Sub

   Public Sub Inserta(entidad As Eniac.Entidades.Entidad, soloTransaccion As Boolean)
      If soloTransaccion Then
         Me.EjecutaSoloConTransaccion(Function()
                                         Me.EjecutaSP(entidad, TipoSP._I)
                                         Return True
                                      End Function)
      Else
         Me.EjecutaSP(entidad, TipoSP._I)
      End If
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Actualiza(entidad As Eniac.Entidades.Entidad)
      Me.Actualiza(entidad, False)
   End Sub

   Public Sub Actualiza(entidad As Eniac.Entidades.Entidad, soloTransaccion As Boolean)
      If soloTransaccion Then
         Me.EjecutaSoloConTransaccion(Function()
                                         Me.EjecutaSP(entidad, TipoSP._U)
                                         Return True
                                      End Function)
      Else
         Me.EjecutaSP(entidad, TipoSP._U)
      End If

   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).Buscar(entidad.Columna, entidad.Valor.ToString(), Nothing, _puedeVerDetalleValoracionEstrellas)
   End Function

   Public Overloads Function Buscar(entidad As Eniac.Entidades.Buscar, filtro As Entidades.Filtros.ClientesABMFiltros) As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).Buscar(entidad.Columna, entidad.Valor.ToString(), filtro, _puedeVerDetalleValoracionEstrellas)
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).Clientes_GA(Nothing, _puedeVerDetalleValoracionEstrellas)
   End Function

   Public Overloads Function GetAll(filtro As Entidades.Filtros.ClientesABMFiltros) As System.Data.DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).Clientes_GA(filtro, _puedeVerDetalleValoracionEstrellas)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim en As Entidades.Cliente = DirectCast(entidad, Entidades.Cliente)
      Dim blnConexionAbierta As Boolean = Me.da.Connection.State = ConnectionState.Open

      Try

         If Not blnConexionAbierta Then
            da.OpenConection()
            da.BeginTransaction()
         End If

         Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
         Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
         Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
         Dim sqlCliActividades As SqlServer.ClientesActividades = New SqlServer.ClientesActividades(da)
         Dim sqlCliDirecciones As SqlServer.ClientesDirecciones = New SqlServer.ClientesDirecciones(da, ModoClienteProspecto)
         Dim sqlCliContactos As SqlServer.ClientesContactos = New SqlServer.ClientesContactos(da, ModoClienteProspecto)
         Dim sqlCliModulos As SqlServer.ClientesAplicacionesModulos = New SqlServer.ClientesAplicacionesModulos(da, ModoClienteProspecto)
         Dim dtAudit As DataTable = New DataTable()
         Dim OperacAudit As Entidades.OperacionesAuditorias

         Dim rAdjuntos As Reglas.ClientesAdjuntos = New ClientesAdjuntos(da)

         'GAR: 09/10/2017 - Hago esto hasta definir si cambiamos los campos y/o los controles.

         If IsDate(en.HoraInicio) AndAlso Date.Parse(en.HoraInicio).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraInicio = en.HoraInicio.Substring(11, 5)
         Else
            en.HoraInicio = ""
         End If
         If IsDate(en.HoraFin) AndAlso Date.Parse(en.HoraFin).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraFin = en.HoraFin.Substring(11, 5)
         Else
            en.HoraFin = ""
         End If
         If IsDate(en.HoraInicio2) AndAlso Date.Parse(en.HoraInicio2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraInicio2 = en.HoraInicio2.Substring(11, 5)
         Else
            en.HoraInicio2 = ""
         End If
         If IsDate(en.HoraFin2) AndAlso Date.Parse(en.HoraFin2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraFin2 = en.HoraFin2.Substring(11, 5)
         Else
            en.HoraFin2 = ""
         End If

         If IsDate(en.HoraSabInicio) AndAlso Date.Parse(en.HoraSabInicio).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraSabInicio = en.HoraSabInicio.Substring(11, 5)
         Else
            en.HoraSabInicio = ""
         End If
         If IsDate(en.HoraSabFin) AndAlso Date.Parse(en.HoraSabFin).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraSabFin = en.HoraSabFin.Substring(11, 5)
         Else
            en.HoraSabFin = ""
         End If
         If IsDate(en.HoraSabInicio2) AndAlso Date.Parse(en.HoraSabInicio2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraSabInicio2 = en.HoraSabInicio2.Substring(11, 5)
         Else
            en.HoraSabInicio2 = ""
         End If
         If IsDate(en.HoraSabFin2) AndAlso Date.Parse(en.HoraSabFin2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraSabFin2 = en.HoraSabFin2.Substring(11, 5)
         Else
            en.HoraSabFin2 = ""
         End If


         If IsDate(en.HoraDomInicio) AndAlso Date.Parse(en.HoraDomInicio).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraDomInicio = en.HoraDomInicio.Substring(11, 5)
         Else
            en.HoraDomInicio = ""
         End If
         If IsDate(en.HoraDomFin) AndAlso Date.Parse(en.HoraDomFin).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraDomFin = en.HoraDomFin.Substring(11, 5)
         Else
            en.HoraDomFin = ""
         End If
         If IsDate(en.HoraDomInicio2) AndAlso Date.Parse(en.HoraDomInicio2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraDomInicio2 = en.HoraDomInicio2.Substring(11, 5)
         Else
            en.HoraDomInicio2 = ""
         End If
         If IsDate(en.HoraDomFin2) AndAlso Date.Parse(en.HoraDomFin2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraDomFin2 = en.HoraDomFin2.Substring(11, 5)
         Else
            en.HoraDomFin2 = ""
         End If

         If Publicos.ClienteUtilizaCalle Then
            en.Direccion = en.Calle.NombreCalle & " " & en.Altura.ToString() & " " & en.DireccionAdicional
         End If

         Select Case tipo

            Case TipoSP._I

               en.IdCliente = Me.GetCodigoMaximo("Id" + ModoClienteProspecto.ToString()) + 1
               If en.CodigoCliente = 0 Then
                  en.CodigoCliente = GetCodigoClienteMaximo(Entidades.Cliente.Columnas.CodigoCliente.ToString()) + 1
               End If

               If String.IsNullOrWhiteSpace(en.SiMovilIdUsuario) Then en.SiMovilIdUsuario = If(Not String.IsNullOrWhiteSpace(en.Cuit.Replace("0", "")), en.Cuit, If(en.NroDocCliente > 0, en.NroDocCliente.ToString(), en.CodigoCliente.ToString()))
               If String.IsNullOrWhiteSpace(en.SiMovilClave) Then en.SiMovilClave = en.CodigoCliente.ToString()

               sql.Clientes_I(en.IdCliente, en.CodigoCliente, en.NombreCliente, en.NombreDeFantasia, en.Direccion, en.DireccionAdicional,
                           en.IdLocalidad, en.Telefono, en.FechaNacimiento, en.NroOperacion, en.CorreoElectronico,
                           en.Celular, en.NombreTrabajo, en.DireccionTrabajo, en.TelefonoTrabajo, en.CorreoTrabajo,
                           en.IdLocalidadTrabajo, en.FechaIngresoTrabajo, en.FechaAlta, en.SaldoPendiente, en.IdClienteGarante,
                           en.IdCategoria, en.CategoriaFiscal.IdCategoriaFiscal, en.Cuit, en.Vendedor.IdEmpleado,
                           en.Observacion, en.IdListaPrecios, en.ZonaGeografica.IdZonaGeografica, en.LimiteDeCredito, en.SaldoLimiteDeCredito, en.IdSucursalAsociada,
                           en.DescuentoRecargoPorc, en.Activo, en.IdTipoComprobante, en.IdFormasPago, en.IdTransportista,
                           en.IngresosBrutos, en.InscriptoIBStaFe, en.LocalIB, en.ConvMultilateralIB, en.NumeroLote,
                           en.IdCaja, en.GeoLocalizacionLat, en.GeoLocalizacionLng, en.IdTipoDeExension, en.AnioExension,
                           en.NroCertExension, en.NroCertPropio, en.TipoDocCliente, en.NroDocCliente, en.DescuentoRecargoPorc2,
                           en.IdClienteCtaCte, en.PaginaWeb, en.LimiteDiasVtoFactura, en.ModificarDatos, en.EsResidente,
                           en.CorreoAdministrativo, en.EstadoCliente.IdEstadoCliente, en.TipoCliente.IdTipoCliente, en.HoraInicio,
                           en.HoraFin, en.HoraInicio2, en.HoraFin2, en.HoraSabInicio, en.HoraSabFin,
                           en.HoraSabInicio2, en.HoraSabFin2, en.HoraDomInicio, en.HoraDomFin, en.HoraDomInicio2,
                           en.HoraDomFin2, en.HorarioCorrido, en.HorarioCorridoSab, en.HorarioCorridoDom, en.NroVersion, en.FechaActualizacionVersion, en.FechaInicio, en.FechaInicioReal,
                           en.VencimientoLicencia, en.BackupAutoCuenta, en.BackupAutoConfig, en.TienePreciosConIVA, en.ConsultaPreciosConIVA, en.TieneServidorDedicado,
                           en.MotorBaseDatos, en.CantidadDePCs, en.HorasCapacitacionPactadas, en.HorasCapacitacionRealizadas,
                           en.CBU, en.Banco.IdBanco, en.CuentaBancariaClase.IdCuentaBancariaClase, en.NumeroCuentaBancaria, en.CuitCtaBancaria,
                           en.UsaArchivoAImprimir2, en.CantidadVisitas, en.BackupNroVersion, en.Facebook, en.Instagram, en.Twitter,
                           en.IdAplicacion, en.Edicion, en.RecibeNotificaciones,
                           en.Contacto, en.FechaBaja, en.VerEnConsultas, en.Calle.IdCalle, en.Altura, en.Calle2.IdCalle, en.Altura2,
                           en.DireccionAdicional2, en.TelefonosParticulares, en.Fax, en.FechaSUS, en.DadoAltaPor.IdEmpleado, en.HabilitarVisita,
                           en.Direccion2, en.IdLocalidad2, en.ObservacionWeb, en.RepartoIndependiente, en.NivelAutorizacion, en.IdCuentaContable, en.EsClienteGenerico,
                           en.URLWebmovilPropio, en.URLWebmovilAdminPropio, en.URLSimovilGestionPropio, en.URLActualizadorPropio, en.NroVersionWebmovilPropio, en.NroVersionWebmovilAdminPropio, en.NroVersionSimovilGestionPropio, en.NroVersionActualizadorPropio,
                           en.UtilizaAppSoporte, en.CantidadLocal, en.CantidadRemota, en.CantidadMovil, en.ObservacionAdministrativa, en.CodigoClienteLetras, en.SiMovilIdUsuario, en.SiMovilClave,
                           en.Alicuota2deProducto.ToString(), en.CertificadoMiPyme, en.FechaDesdeCertificado, en.FechaHastaCertificado, en.Cobrador.IdEmpleado,
                           en.Sexo.ToString(), en.ValorizacionFacturacionMensual, en.ValorizacionCoeficienteFacturacion, en.ValorizacionImporteAdeudado, en.ValorizacionCoeficienteDeuda, en.ValorizacionProyecto, en.ValorizacionProyectoObservacion,
                           en.PublicarEnWeb, en.HorarioClienteCompleto,
                           en.IdClienteTiendaNube, en.IdClienteMercadoLibre, en.IdClienteArborea, en.FechaCambioCategoria, en.ObservacionCambioCategoria, en.IdCategoriaCambio,
                           en.ActualizadorAptoParaInstalar, en.ActualizadorFunciona, en.ActualizadorFechaInstalacion, en.ActualizadorVersion, en.IdImpositivoOtroPais, en.IdConceptoCM05,
                           en.EsExentoPercIVARes53292023, en.IdEstadoCivil, en.VarPesosCotizDolar,
                           en.MonedaCredito, en.PublicarEnTiendaNube, en.PublicarEnMercadoLibre, en.PublicarEnArborea,
                           en.PublicarEnGestion, en.PublicarEnEmpresarial, en.PublicarEnSincronizacionSucursal)
               ReCalcularValoracionCliente(en.IdCliente)

               sql.GrabarFoto(en.Foto, en.IdCliente)

               ActualizarDescuentosVarios(en.IdCliente, en.DescuentosDataSet)

               rAudit.Insertar(ModoClienteProspecto.ToString() + "s", Entidades.OperacionesAuditorias.Alta, en.Usuario,
                               String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), en.IdCliente), conMilisegundos:=False)

               If en.Actividades IsNot Nothing Then
                  For Each dr As DataRow In en.Actividades.Rows
                     If dr.RowState <> DataRowState.Deleted Then

                        sqlCliActividades.ClientesActividades_I(en.IdCliente,
                                                (dr("IdProvincia").ToString()),
                                                Integer.Parse(dr("IdActividad").ToString()))
                     End If
                  Next
               End If

               Dim dtDir = sqlCliDirecciones.GetClientesDirecciones(en.IdCliente, idDireccion:=0)
               Dim lst = New List(Of DataRow)()
               If en.Direcciones IsNot Nothing Then
                  en.Direcciones.AcceptChanges()
                  en.Direcciones.AsEnumerable().ToList().ForEach(
                     Sub(dr)
                        Dim idDireccion = dr.Field(Of Integer?)("IdDireccion").IfNull()
                        Dim drDB = dtDir.AsEnumerable().FirstOrDefault(Function(dr1) dr1.Field(Of Integer)("IdDireccion") = idDireccion)
                        If drDB IsNot Nothing Then
                           sqlCliDirecciones.ClientesDirecciones_U(en.IdCliente, idDireccion, dr.Field(Of String)("Direccion"),
                                                                   dr.Field(Of Integer)("IdLocalidad"), dr.Field(Of Integer)("IdTipoDireccion"),
                                                                   dr.Field(Of String)("DireccionAdicional"), dr.Field(Of String)("Descripcion"), dr.Field(Of String)("Observacion"))
                           lst.Add(drDB)
                        Else
                           idDireccion = sqlCliDirecciones.GetCodigoMaximo(en.IdCliente) + 1
                           sqlCliDirecciones.ClientesDirecciones_I(en.IdCliente, idDireccion, dr.Field(Of String)("Direccion"),
                                                                   dr.Field(Of Integer)("IdLocalidad"), dr.Field(Of Integer)("IdTipoDireccion"),
                                                                   dr.Field(Of String)("DireccionAdicional"), dr.Field(Of String)("Descripcion"), dr.Field(Of String)("Observacion"))
                        End If
                     End Sub)

                  dtDir.Rows.RemoveRowRange(lst.ToArray())
                  dtDir.AcceptChanges()
                  dtDir.AsEnumerable().ToList().ForEach(
                     Sub(dr)
                        Dim idDireccion = dr.Field(Of Integer)("IdDireccion")
                        sqlCliDirecciones.ClientesDirecciones_D(en.IdCliente, idDireccion)
                     End Sub)
               End If


               ''Elimino y grabo las direcciones
               'sqlCliDirecciones.ClientesDirecciones_D(en.IdCliente)
               'Dim codigo As Integer = 1
               'If en.Direcciones IsNot Nothing Then
               'For Each dr As DataRow In en.Direcciones.Rows
               '   If dr.RowState <> DataRowState.Deleted Then

               '      sqlCliDirecciones.ClientesDirecciones_I(en.IdCliente,
               '                              codigo, dr("Direccion").ToString(),
               '                              Integer.Parse(dr("IdLocalidad").ToString()), Integer.Parse(dr("IdTipoDireccion").ToString()), dr("DireccionAdicional").ToString())
               '      codigo += 1
               '   End If
               'Next
               'End If

               Dim codigoContacto As Integer = 1
               If en.Contactos IsNot Nothing Then
                  For Each dr As DataRow In en.Contactos.Rows
                     If dr.RowState <> DataRowState.Deleted Then

                        sqlCliContactos.ClientesContactos_I(en.IdCliente, codigoContacto, dr("NombreContacto").ToString(),
                                                            dr("Direccion").ToString(), Integer.Parse(dr("IdLocalidad").ToString()),
                                                             dr("Telefono").ToString(), dr("CorreoElectronico").ToString(),
                                                             dr("Celular").ToString(), dr("Observacion").ToString(),
                                                             Boolean.Parse(dr("Activo").ToString()), dr("IdUsuario").ToString(),
                                                              Integer.Parse(dr("IdTipoContacto").ToString()))
                        codigoContacto += 1
                     End If
                  Next
               End If


               'Elimino y grabo los Modulos Adicionales
               sqlCliModulos.ClientesAplicacionesModulos_D(en.IdCliente)
               If en.ModulosAdic IsNot Nothing Then
                  For Each dr As DataRow In en.ModulosAdic.Rows
                     If dr.RowState <> DataRowState.Deleted Then
                        sqlCliModulos.ClientesAplicacionesModulos_I(en.IdCliente, Integer.Parse(dr("IdModulo").ToString()))
                     End If
                  Next
               End If

               rAdjuntos.ActualizaDesdeCliente(en)

            Case TipoSP._U
               en.SaldoLimiteDeCredito += en.LimiteDeCredito + en.LimiteDeCredito_Original

               sql.Clientes_U(en.IdCliente, en.CodigoCliente, en.NombreCliente, en.NombreDeFantasia, en.Direccion, en.DireccionAdicional,
                              en.IdLocalidad, en.Telefono, en.FechaNacimiento, en.NroOperacion, en.CorreoElectronico,
                              en.Celular, en.NombreTrabajo, en.DireccionTrabajo, en.TelefonoTrabajo,
                              en.CorreoTrabajo, en.IdLocalidadTrabajo, en.FechaIngresoTrabajo, en.FechaAlta,
                              en.SaldoPendiente, en.IdClienteGarante, en.IdCategoria,
                              en.CategoriaFiscal.IdCategoriaFiscal, en.Cuit, en.Vendedor.IdEmpleado,
                              en.Observacion, en.IdListaPrecios, en.ZonaGeografica.IdZonaGeografica, en.LimiteDeCredito, en.SaldoLimiteDeCredito,
                              en.IdSucursalAsociada, en.DescuentoRecargoPorc, en.Activo, en.IdTipoComprobante, en.IdFormasPago,
                              en.IdTransportista, en.IngresosBrutos, en.InscriptoIBStaFe, en.LocalIB, en.ConvMultilateralIB, en.NumeroLote,
                              en.IdCaja, en.GeoLocalizacionLat, en.GeoLocalizacionLng, en.IdTipoDeExension, en.AnioExension,
                              en.NroCertExension, en.NroCertPropio, en.TipoDocCliente, en.NroDocCliente, en.DescuentoRecargoPorc2,
                              en.IdClienteCtaCte, en.PaginaWeb, en.LimiteDiasVtoFactura, en.ModificarDatos, en.EsResidente, en.CorreoAdministrativo, en.EstadoCliente.IdEstadoCliente,
                              en.TipoCliente.IdTipoCliente, en.HoraInicio,
                              en.HoraFin, en.HoraInicio2, en.HoraFin2, en.HoraSabInicio, en.HoraSabFin,
                              en.HoraSabInicio2, en.HoraSabFin2, en.HoraDomInicio, en.HoraDomFin, en.HoraDomInicio2,
                              en.HoraDomFin2, en.HorarioCorrido, en.HorarioCorridoSab, en.HorarioCorridoDom, en.NroVersion, en.FechaActualizacionVersion, en.FechaInicio, en.FechaInicioReal,
                              en.VencimientoLicencia, en.BackupAutoCuenta, en.BackupAutoConfig, en.TienePreciosConIVA, en.ConsultaPreciosConIVA, en.TieneServidorDedicado,
                              en.MotorBaseDatos, en.CantidadDePCs, en.HorasCapacitacionPactadas, en.HorasCapacitacionRealizadas,
                              en.CBU, en.Banco.IdBanco, en.CuentaBancariaClase.IdCuentaBancariaClase, en.NumeroCuentaBancaria, en.CuitCtaBancaria,
                              en.UsaArchivoAImprimir2, en.CantidadVisitas, en.BackupNroVersion, en.Facebook, en.Instagram, en.Twitter,
                              en.IdAplicacion, en.Edicion, en.RecibeNotificaciones, en.Contacto, en.FechaBaja, en.VerEnConsultas, en.Calle.IdCalle, en.Altura, en.Calle2.IdCalle, en.Altura2,
                              en.DireccionAdicional2, en.TelefonosParticulares, en.Fax, en.FechaSUS, en.DadoAltaPor.IdEmpleado, en.HabilitarVisita,
                              en.Direccion2, en.IdLocalidad2, en.ObservacionWeb, en.RepartoIndependiente, en.NivelAutorizacion, en.IdCuentaContable, en.EsClienteGenerico,
                              en.URLWebmovilPropio, en.URLWebmovilAdminPropio, en.URLSimovilGestionPropio, en.URLActualizadorPropio, en.NroVersionWebmovilPropio, en.NroVersionWebmovilAdminPropio, en.NroVersionSimovilGestionPropio, en.NroVersionActualizadorPropio,
                              en.UtilizaAppSoporte, en.CantidadLocal, en.CantidadRemota, en.CantidadMovil, en.ObservacionAdministrativa, en.CodigoClienteLetras, en.SiMovilIdUsuario, en.SiMovilClave,
                              en.Alicuota2deProducto.ToString(), en.CertificadoMiPyme, en.FechaDesdeCertificado, en.FechaHastaCertificado,
                              en.Cobrador.IdEmpleado, en.Sexo.ToString(), en.ValorizacionFacturacionMensual, en.ValorizacionCoeficienteFacturacion, en.ValorizacionImporteAdeudado, en.ValorizacionCoeficienteDeuda, en.ValorizacionProyecto, en.ValorizacionProyectoObservacion,
                              en.PublicarEnWeb, en.HorarioClienteCompleto,
                              en.IdClienteTiendaNube, en.IdClienteMercadoLibre, en.IdClienteArborea, en.FechaCambioCategoria, en.ObservacionCambioCategoria, en.IdCategoriaCambio,
                              en.ActualizadorAptoParaInstalar, en.ActualizadorFunciona, en.ActualizadorFechaInstalacion, en.ActualizadorVersion, en.IdImpositivoOtroPais, en.IdConceptoCM05, en.IdTipoComprobanteInvocacionMasiva,
                           en.EsExentoPercIVARes53292023, en.IdEstadoCivil, en.VarPesosCotizDolar,
                              en.MonedaCredito, en.PublicarEnTiendaNube, en.PublicarEnMercadoLibre, en.PublicarEnArborea,
                           en.PublicarEnGestion, en.PublicarEnEmpresarial, en.PublicarEnSincronizacionSucursal)

               ReCalcularValoraciones(en.IdCliente)

               sql.GrabarFoto(en.Foto, en.IdCliente)

               ActualizarDescuentosVarios(en.IdCliente, en.DescuentosDataSet)

               dtAudit = sqlAudit.Auditorias_G1(ModoClienteProspecto.ToString() + "s", String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), en.IdCliente))

               'Si no tiene registro es porque se borro el alta en la auditoria (podria pasar en la implementacion inicial)
               If dtAudit.Rows.Count > 0 Then

                  Select Case True
                     Case Not en.Activo And Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
                        'Lo inactivo
                        OperacAudit = Entidades.OperacionesAuditorias.Inactivar
                     Case en.Activo And Not Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
                        'Lo activo
                        OperacAudit = Entidades.OperacionesAuditorias.Alta
                     Case Else
                        OperacAudit = Entidades.OperacionesAuditorias.Modificacion
                  End Select

               Else

                  OperacAudit = Entidades.OperacionesAuditorias.Alta

               End If

               rAudit.Insertar(ModoClienteProspecto.ToString() + "s", OperacAudit, en.Usuario,
                               String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), en.IdCliente), conMilisegundos:=True)

               'Elimino y grabo las actividades
               sqlCliActividades.ClientesActividades_D(en.IdCliente, "", 0)
               If en.Actividades IsNot Nothing Then
                  For Each dr As DataRow In en.Actividades.Rows
                     If dr.RowState <> DataRowState.Deleted Then

                        sqlCliActividades.ClientesActividades_I(en.IdCliente,
                                                (dr("IdProvincia").ToString()),
                                                Integer.Parse(dr("IdActividad").ToString()))
                     End If
                  Next
               End If

               Dim dtDir = sqlCliDirecciones.GetClientesDirecciones(en.IdCliente, idDireccion:=0)
               Dim lst = New List(Of DataRow)()
               If en.Direcciones IsNot Nothing Then
                  en.Direcciones.AcceptChanges()
                  en.Direcciones.AsEnumerable().ToList().ForEach(
                     Sub(dr)
                        Dim idDireccion = dr.Field(Of Integer?)("IdDireccion").IfNull()
                        Dim drDB = dtDir.AsEnumerable().FirstOrDefault(Function(dr1) dr1.Field(Of Integer)("IdDireccion") = idDireccion)
                        If drDB IsNot Nothing Then
                           sqlCliDirecciones.ClientesDirecciones_U(en.IdCliente, idDireccion, dr.Field(Of String)("Direccion"),
                                                                   dr.Field(Of Integer)("IdLocalidad"), dr.Field(Of Integer)("IdTipoDireccion"),
                                                                   dr.Field(Of String)("DireccionAdicional"), dr.Field(Of String)("Descripcion"), dr.Field(Of String)("Observacion"))
                           lst.Add(drDB)
                        Else
                           idDireccion = sqlCliDirecciones.GetCodigoMaximo(en.IdCliente) + 1
                           sqlCliDirecciones.ClientesDirecciones_I(en.IdCliente, idDireccion, dr.Field(Of String)("Direccion"),
                                                                   dr.Field(Of Integer)("IdLocalidad"), dr.Field(Of Integer)("IdTipoDireccion"),
                                                                   dr.Field(Of String)("DireccionAdicional"), dr.Field(Of String)("Descripcion"), dr.Field(Of String)("Observacion"))
                        End If
                     End Sub)

                  dtDir.Rows.RemoveRowRange(lst.ToArray())
                  dtDir.AcceptChanges()
                  dtDir.AsEnumerable().ToList().ForEach(
                     Sub(dr)
                        Dim idDireccion = dr.Field(Of Integer)("IdDireccion")
                        sqlCliDirecciones.ClientesDirecciones_D(en.IdCliente, idDireccion)
                     End Sub)
               End If

               ''Elimino y grabo las direcciones
               'sqlCliDirecciones.ClientesDirecciones_D(en.IdCliente)
               'Dim codigo As Integer = 1
               'If en.Direcciones IsNot Nothing Then

               '   For Each dr As DataRow In en.Direcciones.Rows
               '      If dr.RowState <> DataRowState.Deleted Then

               '         sqlCliDirecciones.ClientesDirecciones_I(en.IdCliente,
               '                                 codigo, dr("Direccion").ToString(),
               '                                 Integer.Parse(dr("IdLocalidad").ToString()), Integer.Parse(dr("IdTipoDireccion").ToString()), dr("DireccionAdicional").ToString())
               '         codigo += 1
               '      End If
               '   Next
               'End If

               If en.ContactosBorrados IsNot Nothing Then
                  'Primero elimino los contactos que se hayan eliminado en la pantalla.
                  For Each drBorrado As DataRow In en.ContactosBorrados.Rows
                     Dim idContacto As Integer = Integer.Parse(drBorrado(Entidades.ClienteContacto.Columnas.IdContacto.ToString()).ToString())
                     If idContacto > 0 Then
                        sqlCliContactos.ClientesContactos_D(en.IdCliente, idContacto)
                     End If
                  Next
               End If

               If en.Contactos IsNot Nothing Then
                  'Luego actualizo los contactos que se modificaron (tienen un IdContacto que se recuperó cuando se cargó la pantalla)
                  For Each drExistentes As DataRow In en.Contactos.Select(String.Format("IdContacto > 0"))
                     Dim idContacto As Integer = Integer.Parse(drExistentes(Entidades.ClienteContacto.Columnas.IdContacto.ToString()).ToString())
                     sqlCliContactos.ClientesContactos_U(en.IdCliente, idContacto, drExistentes("NombreContacto").ToString(),
                                                         drExistentes("Direccion").ToString(), Integer.Parse(drExistentes("IdLocalidad").ToString()),
                                                         drExistentes("Telefono").ToString(), drExistentes("CorreoElectronico").ToString(),
                                                         drExistentes("Celular").ToString(), drExistentes("Observacion").ToString(),
                                                         Boolean.Parse(drExistentes("Activo").ToString()), drExistentes("IdUsuario").ToString(),
                                                         Integer.Parse(drExistentes("IdTipoContacto").ToString()))
                  Next
                  Dim codigoContacto As Integer = sqlCliContactos.GetCodigoMaximo(en.IdCliente) + 1
                  'Por último agrego los contactos que se agregaron (no tiene IdContacto ya que la pantalla no se lo pone)
                  For Each drNuevos As DataRow In en.Contactos.Select(String.Format("IdContacto IS NULL OR IdContacto = 0"))
                     sqlCliContactos.ClientesContactos_I(en.IdCliente, codigoContacto, drNuevos("NombreContacto").ToString(),
                                                         drNuevos("Direccion").ToString(), Integer.Parse(drNuevos("IdLocalidad").ToString()),
                                                         drNuevos("Telefono").ToString(), drNuevos("CorreoElectronico").ToString(),
                                                         drNuevos("Celular").ToString(), drNuevos("Observacion").ToString(),
                                                         Boolean.Parse(drNuevos("Activo").ToString()), drNuevos("IdUsuario").ToString(),
                                                         Integer.Parse(drNuevos("IdTipoContacto").ToString()))
                     codigoContacto += 1
                  Next
               End If

               'Elimino y grabo los Modulos Adicionales
               sqlCliModulos.ClientesAplicacionesModulos_D(en.IdCliente)
               If en.ModulosAdic IsNot Nothing Then
                  For Each dr As DataRow In en.ModulosAdic.Rows
                     If dr.RowState <> DataRowState.Deleted Then
                        sqlCliModulos.ClientesAplicacionesModulos_I(en.IdCliente, Integer.Parse(dr("IdModulo").ToString()))
                     End If
                  Next
               End If

               rAdjuntos.ActualizaDesdeCliente(en)

            Case TipoSP._D

               BorraDescuentosVarios(en.IdCliente)

               sqlCliModulos.ClientesAplicacionesModulos_D(en.IdCliente)

               sqlCliActividades.ClientesActividades_D(en.IdCliente, "", 0)

               sqlCliDirecciones.ClientesDirecciones_D(en.IdCliente)

               sqlCliContactos.ClientesContactos_D(en.IdCliente, 0)

               rAudit.Insertar(ModoClienteProspecto.ToString() + "s", Entidades.OperacionesAuditorias.Baja, en.Usuario,
                               String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), en.IdCliente), conMilisegundos:=False)

               sql.Clientes_D(en.IdCliente)

               ReCalcularValoracionEstrellas()

         End Select

         If Not blnConexionAbierta Then da.CommitTransaction()
      Catch
         If Not blnConexionAbierta Then da.RollbakTransaction()
         Throw
      Finally
         If Not blnConexionAbierta Then da.CloseConection()
      End Try

   End Sub

   Private Sub EjecutaSPLIVE(entidad As Eniac.Entidades.Entidad, tipo As TipoSP, listado As DataSet)

      Dim en As Entidades.Cliente = DirectCast(entidad, Entidades.Cliente)
      Dim blnConexionAbierta As Boolean = Me.da.Connection.State = ConnectionState.Open

      Try

         If Not blnConexionAbierta Then
            da.OpenConection()
            da.BeginTransaction()
         End If

         Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
         Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
         Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
         Dim sqlCliActividades As SqlServer.ClientesActividades = New SqlServer.ClientesActividades(da)
         Dim sqlCliDirecciones As SqlServer.ClientesDirecciones = New SqlServer.ClientesDirecciones(da, ModoClienteProspecto)
         Dim sqlCliContactos As SqlServer.ClientesContactos = New SqlServer.ClientesContactos(da, ModoClienteProspecto)
         Dim dtAudit As DataTable = New DataTable()
         Dim OperacAudit As Entidades.OperacionesAuditorias
         Dim sqlEmpleados As SqlServer.Empleados = New SqlServer.Empleados(da)

         Dim rAdjuntos As Reglas.ClientesAdjuntos = New ClientesAdjuntos(da)

         'GAR: 09/10/2017 - Hago esto hasta definir si cambiamos los campos y/o los controles.

         If IsDate(en.HoraInicio) AndAlso Date.Parse(en.HoraInicio).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraInicio = en.HoraInicio.Substring(11, 5)
         Else
            en.HoraInicio = ""
         End If
         If IsDate(en.HoraFin) AndAlso Date.Parse(en.HoraFin).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraFin = en.HoraFin.Substring(11, 5)
         Else
            en.HoraFin = ""
         End If
         If IsDate(en.HoraInicio2) AndAlso Date.Parse(en.HoraInicio2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraInicio2 = en.HoraInicio2.Substring(11, 5)
         Else
            en.HoraInicio2 = ""
         End If
         If IsDate(en.HoraFin2) AndAlso Date.Parse(en.HoraFin2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraFin2 = en.HoraFin2.Substring(11, 5)
         Else
            en.HoraFin2 = ""
         End If

         If IsDate(en.HoraSabInicio) AndAlso Date.Parse(en.HoraSabInicio).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraSabInicio = en.HoraSabInicio.Substring(11, 5)
         Else
            en.HoraSabInicio = ""
         End If
         If IsDate(en.HoraSabFin) AndAlso Date.Parse(en.HoraSabFin).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraSabFin = en.HoraSabFin.Substring(11, 5)
         Else
            en.HoraSabFin = ""
         End If
         If IsDate(en.HoraSabInicio2) AndAlso Date.Parse(en.HoraSabInicio2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraSabInicio2 = en.HoraSabInicio2.Substring(11, 5)
         Else
            en.HoraSabInicio2 = ""
         End If
         If IsDate(en.HoraSabFin2) AndAlso Date.Parse(en.HoraSabFin2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraSabFin2 = en.HoraSabFin2.Substring(11, 5)
         Else
            en.HoraSabFin2 = ""
         End If


         If IsDate(en.HoraDomInicio) AndAlso Date.Parse(en.HoraDomInicio).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraDomInicio = en.HoraDomInicio.Substring(11, 5)
         Else
            en.HoraDomInicio = ""
         End If
         If IsDate(en.HoraDomFin) AndAlso Date.Parse(en.HoraDomFin).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraDomFin = en.HoraDomFin.Substring(11, 5)
         Else
            en.HoraDomFin = ""
         End If
         If IsDate(en.HoraDomInicio2) AndAlso Date.Parse(en.HoraDomInicio2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraDomInicio2 = en.HoraDomInicio2.Substring(11, 5)
         Else
            en.HoraDomInicio2 = ""
         End If
         If IsDate(en.HoraDomFin2) AndAlso Date.Parse(en.HoraDomFin2).TimeOfDay.ToString <> "00:00:00" Then
            en.HoraDomFin2 = en.HoraDomFin2.Substring(11, 5)
         Else
            en.HoraDomFin2 = ""
         End If

         '------------------------------------------



         Select Case tipo

            Case TipoSP._I

               en.IdCliente = Me.GetCodigoMaximo("Id" + ModoClienteProspecto.ToString()) + 1
               '# Si de pantalla viene el Código de Cliente 0 (tildado el check de Automático)
               '# Es la regla la encargada de asignar el nuevo código de cliente.
               If en.CodigoCliente = 0 Then
                  en.CodigoCliente = GetCodigoClienteMaximo(Entidades.Cliente.Columnas.CodigoCliente.ToString()) + 1
               End If

               Try
                  Dim Cobrador As DataTable = sqlEmpleados.GetUnCobrador()

                  en.Cobrador.IdEmpleado = Integer.Parse(Cobrador.Rows(0).Item("IdEmpleado").ToString())
               Catch ex As Exception
                  Throw New Exception("No existe ningún cobrador.")
               End Try

               'Live no tiene cobrador en la pantalla y se estaba forzando 1 en el sql para que siempre siguiera andando


               If String.IsNullOrWhiteSpace(en.SiMovilIdUsuario) Then en.SiMovilIdUsuario = If(Not String.IsNullOrWhiteSpace(en.Cuit.Replace("0", "")), en.Cuit, If(en.NroDocCliente > 0, en.NroDocCliente.ToString(), en.CodigoCliente.ToString()))
               If String.IsNullOrWhiteSpace(en.SiMovilClave) Then en.SiMovilClave = en.CodigoCliente.ToString()

               sql.Clientes_I(en.IdCliente, en.CodigoCliente, en.NombreCliente, en.NombreDeFantasia, en.Calle.NombreCalle & " " & en.Altura.ToString() & " " & en.DireccionAdicional, en.DireccionAdicional,
                           en.Calle.Localidad.IdLocalidad, en.Telefono, en.FechaNacimiento, en.NroOperacion, en.CorreoElectronico,
                           en.Celular, en.NombreTrabajo, en.DireccionTrabajo, en.TelefonoTrabajo, en.CorreoTrabajo,
                           en.IdLocalidadTrabajo, en.FechaIngresoTrabajo, en.FechaAlta, en.SaldoPendiente, en.IdClienteGarante,
                           en.IdCategoria, en.CategoriaFiscal.IdCategoriaFiscal, en.Cuit, en.Vendedor.IdEmpleado,
                           en.Observacion, en.IdListaPrecios, en.ZonaGeografica.IdZonaGeografica, en.LimiteDeCredito, en.SaldoLimiteDeCredito, en.IdSucursalAsociada,
                           en.DescuentoRecargoPorc, en.Activo, en.IdTipoComprobante, en.IdFormasPago, en.IdTransportista,
                           en.IngresosBrutos, en.InscriptoIBStaFe, en.LocalIB, en.ConvMultilateralIB, en.NumeroLote,
                           en.IdCaja, en.GeoLocalizacionLat, en.GeoLocalizacionLng, en.IdTipoDeExension, en.AnioExension,
                           en.NroCertExension, en.NroCertPropio, en.TipoDocCliente, en.NroDocCliente, en.DescuentoRecargoPorc2,
                           en.IdClienteCtaCte, en.PaginaWeb, en.LimiteDiasVtoFactura, en.ModificarDatos, en.EsResidente,
                           en.CorreoAdministrativo, en.EstadoCliente.IdEstadoCliente, en.TipoCliente.IdTipoCliente, en.HoraInicio,
                           en.HoraFin, en.HoraInicio2, en.HoraFin2, en.HoraSabInicio, en.HoraSabFin,
                           en.HoraSabInicio2, en.HoraSabFin2, en.HoraDomInicio, en.HoraDomFin, en.HoraDomInicio2,
                           en.HoraDomFin2, en.HorarioCorrido, en.HorarioCorridoSab, en.HorarioCorridoDom, en.NroVersion, en.FechaActualizacionVersion, en.FechaInicio, en.FechaInicioReal,
                           en.VencimientoLicencia, en.BackupAutoCuenta, en.BackupAutoConfig, en.TienePreciosConIVA, en.ConsultaPreciosConIVA, en.TieneServidorDedicado,
                           en.MotorBaseDatos, en.CantidadDePCs, en.HorasCapacitacionPactadas, en.HorasCapacitacionRealizadas,
                           en.CBU, en.Banco.IdBanco, en.CuentaBancariaClase.IdCuentaBancariaClase, en.NumeroCuentaBancaria, en.CuitCtaBancaria,
                           en.UsaArchivoAImprimir2, en.CantidadVisitas, en.BackupNroVersion, en.Facebook, en.Instagram, en.Twitter,
                           en.IdAplicacion, en.Edicion, en.RecibeNotificaciones, en.Contacto, en.FechaBaja, en.VerEnConsultas, en.Calle.IdCalle, en.Altura, en.Calle2.IdCalle, en.Altura2,
                           en.DireccionAdicional2, en.TelefonosParticulares, en.Fax, en.FechaSUS, en.DadoAltaPor.IdEmpleado, en.HabilitarVisita,
                           en.Direccion2, en.Calle2.Localidad.IdLocalidad, en.ObservacionWeb, en.RepartoIndependiente, en.NivelAutorizacion, en.IdCuentaContable, en.EsClienteGenerico,
                           en.URLWebmovilPropio, en.URLWebmovilAdminPropio, en.URLSimovilGestionPropio, en.URLActualizadorPropio, en.NroVersionWebmovilPropio, en.NroVersionWebmovilAdminPropio, en.NroVersionSimovilGestionPropio, en.NroVersionActualizadorPropio,
                           en.UtilizaAppSoporte, en.CantidadLocal, en.CantidadRemota, en.CantidadMovil, en.ObservacionAdministrativa, en.CodigoClienteLetras, en.SiMovilIdUsuario, en.SiMovilClave,
                           en.Alicuota2deProducto.ToString(), en.CertificadoMiPyme, en.FechaDesdeCertificado, en.FechaHastaCertificado, en.Cobrador.IdEmpleado, en.Sexo.ToString(),
                           en.ValorizacionFacturacionMensual, en.ValorizacionCoeficienteFacturacion, en.ValorizacionImporteAdeudado, en.ValorizacionCoeficienteDeuda, en.ValorizacionProyecto, en.ValorizacionProyectoObservacion,
                           en.PublicarEnWeb, en.HorarioClienteCompleto,
                           en.IdClienteTiendaNube, en.IdClienteMercadoLibre, en.IdClienteArborea, en.FechaCambioCategoria, en.ObservacionCambioCategoria, en.IdCategoriaCambio,
                           en.ActualizadorAptoParaInstalar, en.ActualizadorFunciona, en.ActualizadorFechaInstalacion, en.ActualizadorVersion, en.IdImpositivoOtroPais, en.IdConceptoCM05,
                           en.EsExentoPercIVARes53292023, en.IdEstadoCivil, en.VarPesosCotizDolar,
                           en.MonedaCredito, en.PublicarEnTiendaNube, en.PublicarEnMercadoLibre, en.PublicarEnArborea,
                           en.PublicarEnGestion, en.PublicarEnEmpresarial, en.PublicarEnSincronizacionSucursal)

               ReCalcularValoracionCliente(en.IdCliente)

               sql.GrabarFoto(en.Foto, en.IdCliente)

               Me.ActualizarDescuentosVarios(en.IdCliente, listado)

               rAudit.Insertar(ModoClienteProspecto.ToString() + "s", Entidades.OperacionesAuditorias.Alta, en.Usuario,
                               String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), en.IdCliente), conMilisegundos:=False)

               If en.Actividades IsNot Nothing Then
                  For Each dr As DataRow In en.Actividades.Rows
                     If dr.RowState <> DataRowState.Deleted Then

                        sqlCliActividades.ClientesActividades_I(en.IdCliente,
                                                (dr("IdProvincia").ToString()),
                                                Integer.Parse(dr("IdActividad").ToString()))
                     End If
                  Next
               End If

               'Elimino y grabo las direcciones
               sqlCliDirecciones.ClientesDirecciones_D(en.IdCliente)
               Dim codigo As Integer = 1
               If en.Direcciones IsNot Nothing Then
                  For Each dr As DataRow In en.Direcciones.Rows
                     If dr.RowState <> DataRowState.Deleted Then

                        sqlCliDirecciones.ClientesDirecciones_I(en.IdCliente,
                                                codigo, dr("Direccion").ToString(),
                                                Integer.Parse(dr("IdLocalidad").ToString()), Integer.Parse(dr("IdTipoDireccion").ToString()),
                                                dr("DireccionAdicional").ToString(), dr.Field(Of String)("Descripcion"), dr.Field(Of String)("Observacion"))
                        codigo += 1
                     End If
                  Next
               End If

               Dim codigoContacto As Integer = 1
               If en.Contactos IsNot Nothing Then
                  For Each dr As DataRow In en.Contactos.Rows
                     If dr.RowState <> DataRowState.Deleted Then

                        sqlCliContactos.ClientesContactos_I(en.IdCliente, codigoContacto, dr("NombreContacto").ToString(),
                                                            dr("Direccion").ToString(), Integer.Parse(dr("IdLocalidad").ToString()),
                                                             dr("Telefono").ToString(), dr("CorreoElectronico").ToString(),
                                                             dr("Celular").ToString(), dr("Observacion").ToString(),
                                                             Boolean.Parse(dr("Activo").ToString()), dr("IdUsuario").ToString(),
                                                              Integer.Parse(dr("IdTipoContacto").ToString()))
                        codigoContacto += 1
                     End If
                  Next
               End If

               rAdjuntos.ActualizaDesdeCliente(en)

            Case TipoSP._U
               sql.Clientes_U(en.IdCliente, en.CodigoCliente, en.NombreCliente, en.NombreDeFantasia, en.Calle.NombreCalle & " " & en.Altura.ToString() & " " & en.DireccionAdicional, en.DireccionAdicional,
                              en.Calle.Localidad.IdLocalidad, en.Telefono, en.FechaNacimiento, en.NroOperacion, en.CorreoElectronico,
                              en.Celular, en.NombreTrabajo, en.DireccionTrabajo, en.TelefonoTrabajo,
                              en.CorreoTrabajo, en.IdLocalidadTrabajo, en.FechaIngresoTrabajo, en.FechaAlta,
                              en.SaldoPendiente, en.IdClienteGarante, en.IdCategoria,
                              en.CategoriaFiscal.IdCategoriaFiscal, en.Cuit, en.Vendedor.IdEmpleado,
                              en.Observacion, en.IdListaPrecios, en.ZonaGeografica.IdZonaGeografica, en.LimiteDeCredito, en.SaldoLimiteDeCredito,
                              en.IdSucursalAsociada, en.DescuentoRecargoPorc, en.Activo, en.IdTipoComprobante, en.IdFormasPago,
                              en.IdTransportista, en.IngresosBrutos, en.InscriptoIBStaFe, en.LocalIB, en.ConvMultilateralIB, en.NumeroLote,
                              en.IdCaja, en.GeoLocalizacionLat, en.GeoLocalizacionLng, en.IdTipoDeExension, en.AnioExension,
                              en.NroCertExension, en.NroCertPropio, en.TipoDocCliente, en.NroDocCliente, en.DescuentoRecargoPorc2,
                              en.IdClienteCtaCte, en.PaginaWeb, en.LimiteDiasVtoFactura, en.ModificarDatos, en.EsResidente, en.CorreoAdministrativo, en.EstadoCliente.IdEstadoCliente,
                              en.TipoCliente.IdTipoCliente, en.HoraInicio,
                              en.HoraFin, en.HoraInicio2, en.HoraFin2, en.HoraSabInicio, en.HoraSabFin,
                              en.HoraSabInicio2, en.HoraSabFin2, en.HoraDomInicio, en.HoraDomFin, en.HoraDomInicio2,
                              en.HoraDomFin2, en.HorarioCorrido, en.HorarioCorridoSab, en.HorarioCorridoDom, en.NroVersion, en.FechaActualizacionVersion, en.FechaInicio, en.FechaInicioReal,
                              en.VencimientoLicencia, en.BackupAutoCuenta, en.BackupAutoConfig, en.TienePreciosConIVA, en.ConsultaPreciosConIVA, en.TieneServidorDedicado,
                              en.MotorBaseDatos, en.CantidadDePCs, en.HorasCapacitacionPactadas, en.HorasCapacitacionRealizadas,
                              en.CBU, en.Banco.IdBanco, en.CuentaBancariaClase.IdCuentaBancariaClase, en.NumeroCuentaBancaria, en.CuitCtaBancaria,
                              en.UsaArchivoAImprimir2, en.CantidadVisitas, en.BackupNroVersion, en.Facebook, en.Instagram, en.Twitter,
                              en.IdAplicacion, en.Edicion, en.RecibeNotificaciones, en.Contacto, en.FechaBaja, en.VerEnConsultas, en.Calle.IdCalle, en.Altura, en.Calle2.IdCalle, en.Altura2,
                              en.DireccionAdicional2, en.TelefonosParticulares, en.Fax, en.FechaSUS, en.DadoAltaPor.IdEmpleado, en.HabilitarVisita,
                              en.Direccion2, en.Calle2.Localidad.IdLocalidad, en.ObservacionWeb, en.RepartoIndependiente, en.NivelAutorizacion, en.IdCuentaContable, en.EsClienteGenerico,
                              en.URLWebmovilPropio, en.URLWebmovilAdminPropio, en.URLSimovilGestionPropio, en.URLActualizadorPropio, en.NroVersionWebmovilPropio, en.NroVersionWebmovilAdminPropio, en.NroVersionSimovilGestionPropio, en.NroVersionActualizadorPropio,
                              en.UtilizaAppSoporte, en.CantidadLocal, en.CantidadRemota, en.CantidadMovil, en.ObservacionAdministrativa, en.CodigoClienteLetras, en.SiMovilIdUsuario, en.SiMovilClave,
                              en.Alicuota2deProducto.ToString(), en.CertificadoMiPyme, en.FechaDesdeCertificado, en.FechaHastaCertificado,
                              en.Cobrador.IdEmpleado, en.Sexo.ToString(),
                              en.ValorizacionFacturacionMensual, en.ValorizacionCoeficienteFacturacion, en.ValorizacionImporteAdeudado, en.ValorizacionCoeficienteDeuda, en.ValorizacionProyecto, en.ValorizacionProyectoObservacion,
                              en.PublicarEnWeb, en.HorarioClienteCompleto,
                              en.IdClienteTiendaNube, en.IdClienteMercadoLibre, en.IdClienteArborea, en.FechaCambioCategoria, en.ObservacionCambioCategoria, en.IdCategoriaCambio,
                              en.ActualizadorAptoParaInstalar, en.ActualizadorFunciona, en.ActualizadorFechaInstalacion, en.ActualizadorVersion, en.IdImpositivoOtroPais, en.IdConceptoCM05, en.IdTipoComprobanteInvocacionMasiva,
                              en.EsExentoPercIVARes53292023, en.IdEstadoCivil, en.VarPesosCotizDolar,
                              en.MonedaCredito, en.PublicarEnTiendaNube, en.PublicarEnMercadoLibre, en.PublicarEnArborea,
                              en.PublicarEnGestion, en.PublicarEnEmpresarial, en.PublicarEnSincronizacionSucursal)

               ReCalcularValoraciones(en.IdCliente)

               sql.GrabarFoto(en.Foto, en.IdCliente)

               Me.ActualizarDescuentosVarios(en.IdCliente, listado)

               dtAudit = sqlAudit.Auditorias_G1(ModoClienteProspecto.ToString() + "s", String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), en.IdCliente))

               'Si no tiene registro es porque se borro el alta en la auditoria (podria pasar en la implementacion inicial)
               If dtAudit.Rows.Count > 0 Then

                  Select Case True
                     Case Not en.Activo And Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
                        'Lo inactivo
                        OperacAudit = Entidades.OperacionesAuditorias.Inactivar
                     Case en.Activo And Not Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
                        'Lo activo
                        OperacAudit = Entidades.OperacionesAuditorias.Alta
                     Case Else
                        OperacAudit = Entidades.OperacionesAuditorias.Modificacion
                  End Select

               Else

                  OperacAudit = Entidades.OperacionesAuditorias.Alta

               End If

               rAudit.Insertar(ModoClienteProspecto.ToString() + "s", OperacAudit, en.Usuario,
                               String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), en.IdCliente), conMilisegundos:=False)

               'Elimino y grabo las actividades
               sqlCliActividades.ClientesActividades_D(en.IdCliente, "", 0)
               If en.Actividades IsNot Nothing Then
                  For Each dr As DataRow In en.Actividades.Rows
                     If dr.RowState <> DataRowState.Deleted Then

                        sqlCliActividades.ClientesActividades_I(en.IdCliente,
                                                (dr("IdProvincia").ToString()),
                                                Integer.Parse(dr("IdActividad").ToString()))
                     End If
                  Next
               End If


               'Elimino y grabo las direcciones
               sqlCliDirecciones.ClientesDirecciones_D(en.IdCliente)
               Dim codigo As Integer = 1
               If en.Direcciones IsNot Nothing Then

                  For Each dr As DataRow In en.Direcciones.Rows
                     If dr.RowState <> DataRowState.Deleted Then

                        sqlCliDirecciones.ClientesDirecciones_I(en.IdCliente,
                                                codigo, dr("Direccion").ToString(),
                                                Integer.Parse(dr("IdLocalidad").ToString()), Integer.Parse(dr("IdTipoDireccion").ToString()),
                                                dr("DireccionAdicional").ToString(), dr.Field(Of String)("Descripcion"), dr.Field(Of String)("Observacion"))
                        codigo += 1
                     End If
                  Next
               End If

               If en.ContactosBorrados IsNot Nothing Then
                  'Primero elimino los contactos que se hayan eliminado en la pantalla.
                  For Each drBorrado As DataRow In en.ContactosBorrados.Rows
                     Dim idContacto As Integer = Integer.Parse(drBorrado(Entidades.ClienteContacto.Columnas.IdContacto.ToString()).ToString())
                     If idContacto > 0 Then
                        sqlCliContactos.ClientesContactos_D(en.IdCliente, idContacto)
                     End If
                  Next
               End If

               If en.Contactos IsNot Nothing Then
                  'Luego actualizo los contactos que se modificaron (tienen un IdContacto que se recuperó cuando se cargó la pantalla)
                  For Each drExistentes As DataRow In en.Contactos.Select(String.Format("IdContacto > 0"))
                     Dim idContacto As Integer = Integer.Parse(drExistentes(Entidades.ClienteContacto.Columnas.IdContacto.ToString()).ToString())
                     sqlCliContactos.ClientesContactos_U(en.IdCliente, idContacto, drExistentes("NombreContacto").ToString(),
                                                         drExistentes("Direccion").ToString(), Integer.Parse(drExistentes("IdLocalidad").ToString()),
                                                         drExistentes("Telefono").ToString(), drExistentes("CorreoElectronico").ToString(),
                                                         drExistentes("Celular").ToString(), drExistentes("Observacion").ToString(),
                                                         Boolean.Parse(drExistentes("Activo").ToString()), drExistentes("IdUsuario").ToString(),
                                                         Integer.Parse(drExistentes("IdTipoContacto").ToString()))
                  Next
                  Dim codigoContacto As Integer = sqlCliContactos.GetCodigoMaximo(en.IdCliente) + 1
                  'Por último agrego los contactos que se agregaron (no tiene IdContacto ya que la pantalla no se lo pone)
                  For Each drNuevos As DataRow In en.Contactos.Select(String.Format("IdContacto IS NULL OR IdContacto = 0"))
                     sqlCliContactos.ClientesContactos_I(en.IdCliente, codigoContacto, drNuevos("NombreContacto").ToString(),
                                                         drNuevos("Direccion").ToString(), Integer.Parse(drNuevos("IdLocalidad").ToString()),
                                                         drNuevos("Telefono").ToString(), drNuevos("CorreoElectronico").ToString(),
                                                         drNuevos("Celular").ToString(), drNuevos("Observacion").ToString(),
                                                         Boolean.Parse(drNuevos("Activo").ToString()), drNuevos("IdUsuario").ToString(),
                                                         Integer.Parse(drNuevos("IdTipoContacto").ToString()))
                     codigoContacto += 1
                  Next
               End If

               rAdjuntos.ActualizaDesdeCliente(en)

            Case TipoSP._D

               sqlCliActividades.ClientesActividades_D(en.IdCliente, "", 0)

               sqlCliDirecciones.ClientesDirecciones_D(en.IdCliente)

               sqlCliContactos.ClientesContactos_D(en.IdCliente, 0)

               rAudit.Insertar(ModoClienteProspecto.ToString() + "s", Entidades.OperacionesAuditorias.Baja, en.Usuario,
                               String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), en.IdCliente), conMilisegundos:=False)

               sql.Clientes_D(en.IdCliente)
               ReCalcularValoracionEstrellas()

         End Select

         If Not blnConexionAbierta Then
            da.CommitTransaction()
         End If

      Catch ex As Exception

         If Not blnConexionAbierta Then
            da.RollbakTransaction()
         End If

         Throw ex

      Finally

         If Not blnConexionAbierta Then
            da.CloseConection()
         End If

      End Try

   End Sub


   Public Sub ActualizarGarante(idCliente As Long, idClienteGarante As Long)

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendFormat("UPDATE {0}s SET ", ModoClienteProspecto.ToString())
         .AppendFormat("  id{0}Garante = {1}", ModoClienteProspecto.ToString(), idClienteGarante.ToString())
         .AppendFormat(" WHERE id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString())
      End With

      Try
         da.OpenConection()
         da.BeginTransaction()

         da.Command.Connection = da.Connection
         da.Command.Transaction = da.Transaction
         da.Command.CommandText = stbQuery.ToString()
         da.Command.CommandType = CommandType.Text

         da.Command.ExecuteNonQuery()

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()

      End Try

   End Sub

   Public Sub ActualizarObservacion(idCliente As Long, Observacion As String)
      Try

         Dim cli As SqlServer.Clientes = New SqlServer.Clientes(Me.da, Entidades.Cliente.ModoClienteProspecto.Cliente)

         cli.ActualizarObservacion(idCliente, Observacion)

      Catch ex As Exception
         Throw ex
      End Try

   End Sub
   Public Sub ActualizarGeolocalizacion(idCliente As Long, Lat As Double, lng As Double)

      Dim stbQuery As StringBuilder = New StringBuilder("")
      Try
         da.OpenConection()
         da.BeginTransaction()
         da.Command.Connection = da.Connection
         da.Command.Transaction = da.Transaction
         da.Command.CommandType = CommandType.Text

         With stbQuery
            .Length = 0
            .AppendFormat("UPDATE {0}s  SET ", ModoClienteProspecto.ToString())
            .AppendFormat("  GeoLocalizacionLat = {0},", Lat)
            .AppendFormat("  GeoLocalizacionLng = {0} ", lng)
            .AppendFormat(" WHERE id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.ToString())
         End With
         da.Command.CommandText = stbQuery.ToString

         da.Command.ExecuteNonQuery()

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub ActualizarEnvioCarta(IdCliente As Long, pTipoCarta As String, pOperaciones As String, pUsuario As String, pIdSucursal As Integer)

      Dim stbQuery As StringBuilder = New StringBuilder("")

      Dim idClienteGarante As Long = 0

      If pTipoCarta = "Garante" Then
         Dim oCliente As Entidades.Cliente = Me._GetUno(IdCliente)
         idClienteGarante = oCliente.IdClienteGarante
      End If

      Dim cont As Integer

      Dim arrOperaciones() As String = Split(pOperaciones, "|")

      Try

         da.OpenConection()
         da.BeginTransaction()
         da.Command.Connection = da.Connection
         da.Command.Transaction = da.Transaction
         da.Command.CommandType = CommandType.Text

         For cont = 1 To arrOperaciones.Length - 1

            With stbQuery
               .Length = 0

               .Append("INSERT INTO CartasAClientes ( ")
               .Append("IdSucursal, FechaEnvio, IdCliente, NroOperacion, ")
               .Append("TipoCarta, Usuario, IdClienteGarante) ")
               .Append("VALUES ( ")
               .Append(pIdSucursal.ToString() & ", ")
               .Append("'" & DateTime.Now.ToString("yyyyMMdd HH:mm:ss") & "',")
               .Append(IdCliente.ToString() & ", ")
               .Append(arrOperaciones(cont - 1).ToString() & ", ")
               .Append("'" & pTipoCarta & "', ")
               .Append("'" & pUsuario & "', ")
               If idClienteGarante > 0 Then
                  .Append(idClienteGarante.ToString() & ")")
               Else
                  .Append("NULL )")
               End If

            End With

            da.Command.CommandText = stbQuery.ToString

            da.Command.ExecuteNonQuery()

         Next

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()

      End Try

   End Sub

   Private Sub CargarUnoLiviano(o As Entidades.ClienteLiviano, dr As DataRow)
      o.IdCliente = dr.Field(Of Long)(String.Format("Id{0}", ModoClienteProspecto.ToString()))
      o.CodigoCliente = dr.Field(Of Long)(String.Format("Codigo{0}", ModoClienteProspecto.ToString()))
      o.NombreCliente = dr.Field(Of String)(String.Format("Nombre{0}", ModoClienteProspecto.ToString()))
      o.IdCategoria = dr.Field(Of Integer)(String.Format("IdCategoria")) '-.PE-32189.-
      o.NombreCategoria = dr.Field(Of String)(String.Format("NombreCategoria"))

      o.IdCategoriaFiscal = dr.Field(Of Short)(String.Format("IdCategoriaFiscal"))

      Dim nroDoc = dr.Field(Of Long?)("NroDoc" + ModoClienteProspecto.ToString())
      If nroDoc.HasValue Then
         o.TipoDocCliente = dr.Field(Of String)("TipoDoc" + ModoClienteProspecto.ToString())
         o.NroDocCliente = nroDoc.Value
      End If
      o.Cuit = dr.Field(Of String)("Cuit")

      o.Telefono = dr("Telefono").ToString()
      o.Celular = dr("Celular").ToString()
      o.LimiteDeCredito = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.LimiteDeCredito.ToString())
      o.SaldoLimiteDeCredito = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.SaldoLimiteDeCredito.ToString())

   End Sub

   Private Sub CargarUno(o As Entidades.Cliente, dr As DataRow, incluirAdjuntos As Entidades.ModoCargaAdjunto)
      With o
         .FechaAlta = Date.Parse(dr("FechaAlta").ToString())
         .IdCliente = Long.Parse(dr("Id" + ModoClienteProspecto.ToString()).ToString())
         .CodigoCliente = Long.Parse(dr("Codigo" + ModoClienteProspecto.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr("NroDoc" + ModoClienteProspecto.ToString()).ToString()) Then
            .TipoDocCliente = dr("TipoDoc" + ModoClienteProspecto.ToString()).ToString()
            .NroDocCliente = Long.Parse(dr("NroDoc" + ModoClienteProspecto.ToString()).ToString())
         End If
         .NombreCliente = dr("Nombre" + ModoClienteProspecto.ToString()).ToString()
         .NombreDeFantasia = dr("NombreDeFantasia").ToString()
         .Direccion = dr("Direccion").ToString()
         .DireccionAdicional = dr("DireccionAdicional").ToString()
         .Localidad = New Reglas.Localidades(da).GetUna(Integer.Parse(dr("IdLocalidad").ToString()))
         .Telefono = dr("Telefono").ToString()
         .Celular = dr("Celular").ToString()
         .CorreoElectronico = dr("CorreoElectronico").ToString()
         .FechaNacimiento = Date.Parse(dr("FechaNacimiento").ToString())

         .NombreTrabajo = dr("NombreTrabajo").ToString()
         .DireccionTrabajo = dr("DireccionTrabajo").ToString()
         If Not String.IsNullOrEmpty(dr("IdLocalidadTrabajo").ToString()) Then
            .IdLocalidadTrabajo = Integer.Parse(dr("IdLocalidadTrabajo").ToString())
         End If
         .TelefonoTrabajo = dr("TelefonoTrabajo").ToString()
         .CorreoTrabajo = dr("CorreoTrabajo").ToString()

         If Not String.IsNullOrEmpty(dr("FechaIngresoTrabajo").ToString()) Then
            .FechaIngresoTrabajo = Date.Parse(dr("FechaIngresoTrabajo").ToString())
         End If

         If Not String.IsNullOrEmpty(dr("Id" + ModoClienteProspecto.ToString() + "Garante").ToString()) Then
            .IdClienteGarante = Long.Parse(dr("Id" + ModoClienteProspecto.ToString() + "Garante").ToString())
         End If

         .IdCategoria = Integer.Parse(dr("IdCategoria").ToString())
         .NombreCategoria = dr("NombreCategoria").ToString()

         Dim cf As Reglas.CategoriasFiscales = New Reglas.CategoriasFiscales(da)
         .CategoriaFiscal = cf._GetUno(Short.Parse(dr("IdCategoriaFiscal").ToString()))

         .Cuit = dr("Cuit").ToString()

         Dim Vend As Reglas.Empleados = New Reglas.Empleados(da)
         Try
            .Vendedor = Vend.GetUno(Integer.Parse(dr("IdVendedor").ToString()))
         Catch ex As Exception
            Throw New Exception(String.Format("Vendedor: {0}", ex.Message), ex)
         End Try
         .Observacion = dr("Observacion").ToString()
         .IdListaPrecios = Integer.Parse(dr("IdListaPrecios").ToString())
         .ZonaGeografica = New Reglas.ZonasGeograficas(Me.da).GetUno(dr("IdZonaGeografica").ToString())

         .LimiteDeCredito = Decimal.Parse(dr("LimiteDeCredito").ToString())
         .SaldoLimiteDeCredito = dr.Field(Of Decimal)("SaldoLimiteDeCredito")

         If Not String.IsNullOrEmpty(dr("IdSucursalAsociada").ToString()) Then
            .IdSucursalAsociada = Integer.Parse(dr("IdSucursalAsociada").ToString())
         End If

         If Not String.IsNullOrEmpty(dr("IdCaja").ToString()) Then
            .IdCaja = Integer.Parse(dr("IdCaja").ToString())
         End If

         .DescuentoRecargoPorc = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())

         If Not String.IsNullOrEmpty(dr("IdTipoComprobante").ToString()) Then
            .IdTipoComprobante = dr("IdTipoComprobante").ToString()
         End If

         If Not String.IsNullOrEmpty(dr("IdTipoComprobanteInvocacionMasiva").ToString()) Then
            .IdTipoComprobanteInvocacionMasiva = dr("IdTipoComprobanteInvocacionMasiva").ToString()
         End If

         If Not String.IsNullOrEmpty(dr("IdFormasPago").ToString()) Then
            .IdFormasPago = Integer.Parse(dr("IdFormasPago").ToString())
         End If

         If Not String.IsNullOrEmpty(dr("IdTransportista").ToString()) Then
            .IdTransportista = Integer.Parse(dr("IdTransportista").ToString())
            .NombreTransportista = dr("NombreTransportista").ToString()
         End If

         If dr.Table.Columns.Contains("Foto") Then
            If Not String.IsNullOrEmpty(dr("Foto").ToString()) Then
               Dim content() As Byte = CType(dr("Foto"), Byte())
               Using stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
                  .Foto = New System.Drawing.Bitmap(stream)
               End Using
            End If
         End If

         .Activo = Boolean.Parse(dr("Activo").ToString())
         If Not String.IsNullOrEmpty(dr("IngresosBrutos").ToString()) Then
            .IngresosBrutos = dr("IngresosBrutos").ToString()
         End If
         .InscriptoIBStaFe = Boolean.Parse(dr("InscriptoIBStaFe").ToString())
         .LocalIB = Boolean.Parse(dr("LocalIB").ToString())
         .ConvMultilateralIB = Boolean.Parse(dr("ConvMultilateralIB").ToString())
         If Not String.IsNullOrEmpty(dr("NumeroLote").ToString()) Then
            .NumeroLote = Long.Parse(dr("NumeroLote").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("GeoLocalizacionLat").ToString()) Then
            .GeoLocalizacionLat = Double.Parse(dr("GeoLocalizacionLat").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("GeoLocalizacionLng").ToString()) Then
            .GeoLocalizacionLng = Double.Parse(dr("GeoLocalizacionLng").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("IdTipoDeExension").ToString()) Then
            .IdTipoDeExension = Short.Parse(dr("IdTipoDeExension").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("AnioExension").ToString()) Then
            .AnioExension = Integer.Parse(dr("AnioExension").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("NroCertExension").ToString()) Then
            .NroCertExension = dr("NroCertExension").ToString()
         End If
         If Not String.IsNullOrEmpty(dr("NroCertPropio").ToString()) Then
            .NroCertPropio = dr("NroCertPropio").ToString()
         End If

         .DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())

         If Not String.IsNullOrEmpty(dr("Id" + ModoClienteProspecto.ToString() + "CtaCte").ToString()) Then
            .IdClienteCtaCte = Long.Parse(dr("Id" + ModoClienteProspecto.ToString() + "CtaCte").ToString())
         End If

         .PaginaWeb = dr("PaginaWeb").ToString()
         .LimiteDiasVtoFactura = Integer.Parse(dr("LimiteDiasVtoFactura").ToString())
         .ModificarDatos = Boolean.Parse(dr("ModificarDatos").ToString())
         .EsResidente = Boolean.Parse(dr("EsResidente").ToString())
         .CorreoAdministrativo = dr("CorreoAdministrativo").ToString()
         .EstadoCliente = New Reglas.EstadosClientes(Me.da)._GetUno(Integer.Parse(dr("IdEstado").ToString()))

         Dim Cob As Reglas.Empleados = New Reglas.Empleados(da)
         Try
            .Cobrador = Cob.GetUno(Integer.Parse(dr("IdCobrador").ToString()))
         Catch ex As Exception
            Throw New Exception(String.Format("Cobrador: {0}", ex.Message), ex)
         End Try
         '   .Cobrador = New Reglas.Empleados(Me.da).GetUno(Integer.Parse(dr("IdCobrador").ToString()))

         .TipoCliente = New Reglas.TiposClientes(Me.da)._GetUno(Integer.Parse(dr("IdTipoCliente").ToString()))

         'Agrego la fecha para que el control del ABM de Clientes funcione. En la base solo debe estar la hora.
         Dim FechaActual As String = Date.Today.ToString("dd/MM/yyyy")

         .HoraInicio = FechaActual & " " & dr("HoraInicio").ToString()
         .HoraFin = FechaActual & " " & dr("HoraFin").ToString()
         .HoraInicio2 = FechaActual & " " & dr("HoraInicio2").ToString()
         .HoraFin2 = FechaActual & " " & dr("HoraFin2").ToString()
         .HoraSabInicio = FechaActual & " " & dr("HoraSabInicio").ToString()
         .HoraSabFin = FechaActual & " " & dr("HoraSabFin").ToString()
         .HoraSabInicio2 = FechaActual & " " & dr("HoraSabInicio2").ToString()
         .HoraSabFin2 = FechaActual & " " & dr("HoraSabFin2").ToString()
         .HoraDomInicio = FechaActual & " " & dr("HoraDomInicio").ToString()
         .HoraDomFin = FechaActual & " " & dr("HoraDomFin").ToString()
         .HoraDomInicio2 = FechaActual & " " & dr("HoraDomInicio2").ToString()
         .HoraDomFin2 = FechaActual & " " & dr("HoraDomFin2").ToString()

         If Not String.IsNullOrEmpty(dr("HorarioCorrido").ToString()) Then
            .HorarioCorrido = Boolean.Parse(dr("HorarioCorrido").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("HorarioCorridoSab").ToString()) Then
            .HorarioCorridoSab = Boolean.Parse(dr("HorarioCorridoSab").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("HorarioCorridoDom").ToString()) Then
            .HorarioCorridoDom = Boolean.Parse(dr("HorarioCorridoDom").ToString())
         End If
         .NroVersion = dr("NroVersion").ToString()
         If Not String.IsNullOrEmpty(dr("FechaActualizacionVersion").ToString()) Then
            .FechaActualizacionVersion = DateTime.Parse(dr("FechaActualizacionVersion").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("FechaActualizacionWeb").ToString()) Then
            .FechaActualizacionWeb = DateTime.Parse(dr("FechaActualizacionWeb").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("FechaInicio").ToString()) Then
            .FechaInicio = DateTime.Parse(dr("FechaInicio").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("FechaInicioReal").ToString()) Then
            .FechaInicioReal = DateTime.Parse(dr("FechaInicioReal").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("VencimientoLicencia").ToString()) Then
            .VencimientoLicencia = DateTime.Parse(dr("VencimientoLicencia").ToString())
         End If
         .BackupAutoCuenta = dr("BackupAutoCuenta").ToString()
         If Not String.IsNullOrEmpty(dr("BackupAutoConfig").ToString()) Then
            .BackupAutoConfig = Boolean.Parse(dr("BackupAutoConfig").ToString())
         Else
            .BackupAutoConfig = Nothing
         End If
         .BackupNroVersion = dr("BackupNroVersion").ToString()
         If Not String.IsNullOrEmpty(dr("TienePreciosConIVA").ToString()) Then
            .TienePreciosConIVA = Boolean.Parse(dr("TienePreciosConIVA").ToString())
         Else
            .TienePreciosConIVA = Nothing
         End If
         If Not String.IsNullOrEmpty(dr("ConsultaPreciosConIVA").ToString()) Then
            .ConsultaPreciosConIVA = Boolean.Parse(dr("ConsultaPreciosConIVA").ToString())
         Else
            .ConsultaPreciosConIVA = Nothing
         End If
         If Not String.IsNullOrEmpty(dr("TieneServidorDedicado").ToString()) Then
            .TieneServidorDedicado = Boolean.Parse(dr("TieneServidorDedicado").ToString())
         Else
            .TieneServidorDedicado = Nothing
         End If
         .MotorBaseDatos = dr("MotorBaseDatos").ToString()
         If Not String.IsNullOrEmpty(dr("CantidadDePCs").ToString()) Then
            .CantidadDePCs = Int32.Parse(dr("CantidadDePCs").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("HorasCapacitacionPactadas").ToString()) Then
            .HorasCapacitacionPactadas = Int32.Parse(dr("HorasCapacitacionPactadas").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("HorasCapacitacionRealizadas").ToString()) Then
            .HorasCapacitacionRealizadas = Int32.Parse(dr("HorasCapacitacionRealizadas").ToString())
         End If

         .CBU = dr(Entidades.Cliente.Columnas.CBU.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Entidades.Cliente.Columnas.IdBanco.ToString()).ToString()) Then
            .Banco = New Eniac.Reglas.Bancos().GetUno(Integer.Parse(dr(Entidades.Cliente.Columnas.IdBanco.ToString()).ToString()))
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Cliente.Columnas.IdCuentaBancariaClase.ToString()).ToString()) Then
            .CuentaBancariaClase = New Eniac.Reglas.CuentasBancariasClase().GetUna(Integer.Parse(dr(Entidades.Cliente.Columnas.IdCuentaBancariaClase.ToString()).ToString()))
         End If
         .NumeroCuentaBancaria = dr(Entidades.Cliente.Columnas.NumeroCuentaBancaria.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Entidades.Cliente.Columnas.CuitCtaBancaria.ToString()).ToString()) Then
            .CuitCtaBancaria = dr(Entidades.Cliente.Columnas.CuitCtaBancaria.ToString()).ToString()
         End If

         .UsaArchivoAImprimir2 = Boolean.Parse(dr(Entidades.Cliente.Columnas.UsaArchivoAImprimir2.ToString()).ToString())

         .CantidadVisitas = Integer.Parse(dr(Entidades.Cliente.Columnas.CantidadVisitas.ToString()).ToString())

         .Facebook = dr(Entidades.Cliente.Columnas.Facebook.ToString()).ToString()
         .Instagram = dr(Entidades.Cliente.Columnas.Instagram.ToString()).ToString()
         .Twitter = dr(Entidades.Cliente.Columnas.Twitter.ToString()).ToString()
         .IdAplicacion = dr(Entidades.Cliente.Columnas.IdAplicacion.ToString()).ToString()
         .Edicion = dr(Entidades.Cliente.Columnas.Edicion.ToString()).ToString()
         .RecibeNotificaciones = Boolean.Parse(dr("RecibeNotificaciones").ToString())

         If incluirAdjuntos <> Entidades.ModoCargaAdjunto.NoCargar Then
            Dim lista As List(Of Entidades.ClienteAdjunto) = New Reglas.ClientesAdjuntos(da).GetTodos(.IdCliente, incluirAdjuntos = Entidades.ModoCargaAdjunto.Cargar)
            .Adjuntos = New Entidades.ListConBorrados(Of Entidades.ClienteAdjunto)(lista)
         End If

         If Not String.IsNullOrWhiteSpace(dr("VerEnConsultas").ToString()) Then
            .VerEnConsultas = Boolean.Parse(dr("VerEnConsultas").ToString())
         Else
            .VerEnConsultas = True
         End If
         .Contacto = dr("Contacto").ToString()
         If IsNumeric(dr("IdCalle")) And Integer.Parse(dr("IdCalle").ToString()) > 0 Then
            .Calle = New Reglas.Calles(Me.da)._GetUna(Integer.Parse(dr("IdCalle").ToString()))
         End If
         If IsNumeric(dr("Altura")) Then
            .Altura = Integer.Parse(dr("Altura").ToString())
         End If
         If IsNumeric(dr("IdCalle2")) And Integer.Parse(dr("IdCalle2").ToString()) > 0 Then
            .Calle2 = New Reglas.Calles(Me.da)._GetUna(Integer.Parse(dr("IdCalle2").ToString()))
         End If
         If IsNumeric(dr("Altura2")) Then
            .Altura2 = Integer.Parse(dr("Altura2").ToString())
         End If
         .DireccionAdicional2 = dr("DireccionAdicional2").ToString()
         .TelefonosParticulares = dr("TelefonosParticulares").ToString()
         .Fax = dr("Fax").ToString()
         If Not String.IsNullOrEmpty(dr("FechaBaja").ToString()) Then
            .FechaBaja = DateTime.Parse(dr("FechaBaja").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("HabilitarVisita").ToString()) Then
            .HabilitarVisita = Boolean.Parse(dr("HabilitarVisita").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("RepartoIndependiente").ToString()) Then
            .RepartoIndependiente = Boolean.Parse(dr("RepartoIndependiente").ToString())
         End If

         If IsNumeric(dr(Entidades.Cliente.Columnas.NivelAutorizacion.ToString()).ToString()) Then
            .NivelAutorizacion = Short.Parse(dr(Entidades.Cliente.Columnas.NivelAutorizacion.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.Cliente.Columnas.IdCuentaContable.ToString()).ToString()) Then
            .CuentaContable = New Reglas.ContabilidadCuentas(da)._GetUna(Long.Parse(dr(Entidades.Cliente.Columnas.IdCuentaContable.ToString()).ToString()))
         End If

         If Not String.IsNullOrEmpty(dr("IdDadoAltaPor").ToString().Replace("0", "")) Then
            Try
               .DadoAltaPor = New Eniac.Reglas.Empleados().GetUno(Integer.Parse(dr("IdDadoAltaPor").ToString()))
            Catch ex As Exception
               Throw New Exception(String.Format("Dado de Alta Por: {0}", ex.Message), ex)
            End Try
         End If
         If Not String.IsNullOrEmpty(dr("FechaSUS").ToString()) Then
            .FechaSUS = DateTime.Parse(dr("FechaSUS").ToString())
         End If
         .ObservacionWeb = dr("ObservacionWeb").ToString()
         .EsClienteGenerico = Boolean.Parse(dr("EsClienteGenerico").ToString())

         .URLWebmovilPropio = dr(Entidades.Cliente.Columnas.URLWebmovilPropio.ToString()).ToString()
         .URLWebmovilAdminPropio = dr(Entidades.Cliente.Columnas.URLWebmovilAdminPropio.ToString()).ToString()
         .URLSimovilGestionPropio = dr(Entidades.Cliente.Columnas.URLSimovilGestionPropio.ToString()).ToString()
         .URLActualizadorPropio = dr(Entidades.Cliente.Columnas.URLActualizadorPropio.ToString()).ToString()

         .NroVersionWebmovilPropio = dr(Entidades.Cliente.Columnas.NroVersionWebmovilPropio.ToString()).ToString()
         .NroVersionWebmovilAdminPropio = dr(Entidades.Cliente.Columnas.NroVersionWebmovilAdminPropio.ToString()).ToString()
         .NroVersionSimovilGestionPropio = dr(Entidades.Cliente.Columnas.NroVersionSimovilGestionPropio.ToString()).ToString()
         .NroVersionActualizadorPropio = dr(Entidades.Cliente.Columnas.NroVersionActualizadorPropio.ToString()).ToString()

         If Not String.IsNullOrEmpty(dr(Entidades.Categoria.Columnas.ActualizarAplicacion.ToString()).ToString()) Then
            .ActualizarAplicacion = Boolean.Parse(dr(Entidades.Categoria.Columnas.ActualizarAplicacion.ToString()).ToString()) 'Campo de la Entidad Categoria
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Categoria.Columnas.ControlaBackup.ToString()).ToString()) Then
            .ControlaBackup = Boolean.Parse(dr(Entidades.Categoria.Columnas.ControlaBackup.ToString()).ToString()) 'Campo de la Entidad Categoria
         End If

         If Not String.IsNullOrEmpty(dr(Entidades.Cliente.Columnas.UtilizaAppSoporte.ToString()).ToString()) Then
            .UtilizaAppSoporte = Boolean.Parse(dr(Entidades.Cliente.Columnas.UtilizaAppSoporte.ToString()).ToString())
         End If

         If Not String.IsNullOrEmpty(dr(Entidades.Cliente.Columnas.CantidadLocal.ToString()).ToString()) Then
            .CantidadLocal = Int32.Parse(dr(Entidades.Cliente.Columnas.CantidadLocal.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Cliente.Columnas.CantidadRemota.ToString()).ToString()) Then
            .CantidadRemota = Int32.Parse(dr(Entidades.Cliente.Columnas.CantidadRemota.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Cliente.Columnas.CantidadMovil.ToString()).ToString()) Then
            .CantidadMovil = Int32.Parse(dr(Entidades.Cliente.Columnas.CantidadMovil.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Cliente.Columnas.ObservacionAdministrativa.ToString()).ToString()) Then
            .ObservacionAdministrativa = dr(Entidades.Cliente.Columnas.ObservacionAdministrativa.ToString()).ToString()
         End If

         .CodigoClienteLetras = dr("Codigo" + ModoClienteProspecto.ToString() + "Letras").ToString()

         .SiMovilIdUsuario = dr(Entidades.Cliente.Columnas.SiMovilIdUsuario.ToString()).ToString()
         .SiMovilClave = dr(Entidades.Cliente.Columnas.SiMovilClave.ToString()).ToString()

         Try
            .Alicuota2deProducto = DirectCast([Enum].Parse(GetType(Entidades.Cliente.Alicuota2DeProductoSegun), dr(Entidades.Cliente.Columnas.Alicuota2deProducto.ToString()).ToString()), Entidades.Cliente.Alicuota2DeProductoSegun)
         Catch ex As Exception
            .Alicuota2deProducto = Entidades.Cliente.Alicuota2DeProductoSegun.SEGUNCATEGORIAFISCAL
         End Try

         .CertificadoMiPyme = Boolean.Parse(dr("CertificadoMiPyme").ToString())

         If Not String.IsNullOrEmpty(dr("FechaDesdeCertificado").ToString()) Then
            .FechaDesdeCertificado = DateTime.Parse(dr("FechaDesdeCertificado").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("FechaHastaCertificado").ToString()) Then
            .FechaHastaCertificado = DateTime.Parse(dr("FechaHastaCertificado").ToString())
         End If

         Try
            .Sexo = DirectCast([Enum].Parse(GetType(Entidades.Cliente.SexoOpciones), dr(Entidades.Cliente.Columnas.Sexo.ToString()).ToString()), Entidades.Cliente.SexoOpciones)
         Catch ex As Exception
            .Sexo = Entidades.Cliente.SexoOpciones.NoAplica
         End Try

         .HorarioClienteCompleto = dr.Field(Of String)(Entidades.Cliente.Columnas.HorarioClienteCompleto.ToString())
         .IdClienteTiendaNube = dr.Field(Of String)(String.Format("Id{0}TiendaNube", ModoClienteProspecto.ToString()))
         .IdClienteMercadoLibre = dr.Field(Of String)(String.Format("Id{0}MercadoLibre", ModoClienteProspecto.ToString()))
         .IdClienteArborea = dr.Field(Of String)(String.Format("Id{0}Arborea", ModoClienteProspecto.ToString()))

         .ValorizacionFacturacionMensual = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionFacturacionMensual.ToString())
         .ValorizacionCoeficienteFacturacion = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionCoeficienteFacturacion.ToString())
         .ValorizacionFacturacion = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionFacturacion.ToString())
         .ValorizacionImporteAdeudado = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionImporteAdeudado.ToString())
         .ValorizacionCoeficienteDeuda = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionCoeficienteDeuda.ToString())
         .ValorizacionDeuda = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionDeuda.ToString())
         .ValorizacionProyecto = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionProyecto.ToString())
         .ValorizacionProyectoObservacion = dr.Field(Of String)(Entidades.Cliente.Columnas.ValorizacionProyectoObservacion.ToString())
         .ValorizacionCliente = dr.Field(Of Decimal)("Valorizacion" + ModoClienteProspecto.ToString())
         .ValorizacionEstrellas = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString())

         .PublicarEnWeb = Boolean.Parse(dr("PublicarEnWeb").ToString())

         'PE-30972
         If Not String.IsNullOrEmpty(dr("IdCategoriaCambio").ToString()) Then
            .IdCategoriaCambio = dr.Field(Of Integer)(Entidades.Cliente.Columnas.IdCategoriaCambio.ToString())
         End If

         If Not String.IsNullOrEmpty(dr("FechaCambioCategoria").ToString()) Then
            .FechaCambioCategoria = dr.Field(Of Date)(Entidades.Cliente.Columnas.FechaCambioCategoria.ToString())
         End If

         If Not String.IsNullOrEmpty(dr("ObservacionCambioCategoria").ToString()) Then
            .ObservacionCambioCategoria = dr.Field(Of String)(Entidades.Cliente.Columnas.ObservacionCambioCategoria.ToString())
         End If

         .ActualizadorAptoParaInstalar = dr.Field(Of Boolean)("ActualizadorAptoParaInstalar")
         .ActualizadorFunciona = dr.Field(Of String)("ActualizadorFunciona").StringToEnum(Entidades.Cliente.FuncionaActualizador.PENDIENTE)
         .ActualizadorFechaInstalacion = dr.Field(Of Date?)("ActualizadorFechaInstalacion")
         .ActualizadorVersion = dr.Field(Of String)("ActualizadorVersion").IfNull()

         .IdImpositivoOtroPais = dr.Field(Of String)("IdImpositivoOtroPais")
         .IdConceptoCM05 = dr.Field(Of Integer?)("IdConceptoCM05")
         .EsExentoPercIVARes53292023 = dr.Field(Of Boolean)("EsExentoPercIVARes53292023")
         .IdEstadoCivil = dr.Field(Of Integer)("IdEstadoCivil")
         .MonedaCredito = dr.Field(Of Integer)("MonedaCredito")

         If Not String.IsNullOrEmpty(dr("VarPesosCotizDolar").ToString()) Then
            .VarPesosCotizDolar = dr.Field(Of Decimal)(Entidades.Cliente.Columnas.VarPesosCotizDolar.ToString())
         End If

         .PublicarEnTiendaNube = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnTiendaNube.ToString())
         .PublicarEnMercadoLibre = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnMercadoLibre.ToString())
         .PublicarEnArborea = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnArborea.ToString())
         .PublicarEnGestion = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnGestion.ToString())
         .PublicarEnEmpresarial = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnEmpresarial.ToString())
         .PublicarEnSincronizacionSucursal = dr.Field(Of Boolean)(Entidades.Producto.Columnas.PublicarEnSincronizacionSucursal.ToString())

      End With

   End Sub

   Private Sub BorraDescuentosVarios(idCliente As Long)
      Dim sqlMarcas = New SqlServer.ClientesDescuentosMarcas(da)
      Dim sqlRubros = New SqlServer.ClientesDescuentosRubros(da)
      Dim sqlProductos = New SqlServer.ClientesDescuentosProductos(da)

      sqlMarcas.ClientesDescuentosMarcas_D(idCliente, IdMarca:=0)
      sqlRubros.ClientesDescuentosRubros_D(idCliente, IdRubro:=0)
      sqlProductos.ClientesDescuentosProductos_D(idCliente, idProducto:=String.Empty)
   End Sub
   Private Sub ActualizarDescuentosVarios(idCliente As Long, listado As DataSet)
      If listado Is Nothing Then Exit Sub
      For Each rd As DataTable In listado.Tables
         If rd.TableName = "DescuentosMarcas" Then
            Dim sqlMarcas = New SqlServer.ClientesDescuentosMarcas(da)
            If rd.GetChanges(DataRowState.Deleted) IsNot Nothing Then
               For Each dr As DataRow In rd.GetChanges(DataRowState.Deleted).Rows
                  If dr.RowState = DataRowState.Deleted Then
                     sqlMarcas.ClientesDescuentosMarcas_D(idCliente, dr.Field(Of Integer)("IdMarca", DataRowVersion.Original))
                  End If
               Next
            End If
            For Each dr As DataRow In rd.Rows
               If dr.RowState = DataRowState.Added Then
                  sqlMarcas.ClientesDescuentosMarcas_I(idCliente,
                                                       dr.Field(Of Integer)("IdMarca"),
                                                       dr.Field(Of Decimal)("DescuentoRecargoPorc1"),
                                                       dr.Field(Of Decimal)("DescuentoRecargoPorc2"))
               End If
            Next
         End If

         If rd.TableName = "DescuentosRubros" Then
            Dim sqlRubros = New SqlServer.ClientesDescuentosRubros(da)
            If rd.GetChanges(DataRowState.Deleted) IsNot Nothing Then
               For Each dr As DataRow In rd.GetChanges(DataRowState.Deleted).Rows
                  If dr.RowState = DataRowState.Deleted Then
                     sqlRubros.ClientesDescuentosRubros_D(idCliente, dr.Field(Of Integer)("IdRubro", DataRowVersion.Original))
                  End If
               Next
            End If
            For Each dr As DataRow In rd.Rows
               If dr.RowState = DataRowState.Added Then
                  sqlRubros.ClientesDescuentosRubros_I(idCliente,
                                                       dr.Field(Of Integer)("IdRubro"),
                                                       dr.Field(Of Decimal)("DescuentoRecargoPorc1"),
                                                       dr.Field(Of Decimal)("DescuentoRecargoPorc2"))
               End If
            Next
         End If

         If rd.TableName = "DescuentosProductos" Then
            Dim sqlProductos = New SqlServer.ClientesDescuentosProductos(da)
            If rd.GetChanges(DataRowState.Deleted) IsNot Nothing Then
               For Each dr As DataRow In rd.GetChanges(DataRowState.Deleted).Rows
                  If dr.RowState = DataRowState.Deleted Then
                     sqlProductos.ClientesDescuentosProductos_D(idCliente, dr.Field(Of String)("IdProducto", DataRowVersion.Original))
                  End If
               Next
            End If
            For Each dr As DataRow In rd.Rows
               If dr.RowState = DataRowState.Added Then
                  sqlProductos.ClientesDescuentosProductos_I(idCliente,
                                                             dr.Field(Of String)("IdProducto"),
                                                             dr.Field(Of Decimal)("DescuentoRecargoPorc1"),
                                                             dr.Field(Of Decimal)("DescuentoRecargoPorc2"))
               End If
            Next
         End If
      Next
   End Sub
#End Region

#Region "Metodos Publicos"

   Public Sub ActualizarVersiones(versiones As List(Of Entidades.VersionCliente))
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.Clientes
         sql = New SqlServer.Clientes(Me.da, Entidades.Cliente.ModoClienteProspecto.Cliente)

         For Each vc As Entidades.VersionCliente In versiones
            sql.ActualizarVersion(vc.CodigoCliente, vc.NroVersion)
         Next

         Me.da.CommitTransaction()
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Sub ActualizaSaldoLimiteDeCredito(idCliente As Long?, estadoSituacionResult As Entidades.CalculoSaldoLimiteCreditoResultado)
      EjecutaConTransaccion(Sub() _ActualizaSaldoLimiteDeCredito(idCliente, estadoSituacionResult))
   End Sub
   Public Sub _ActualizaSaldoLimiteDeCredito(idCliente As Long?, estadoSituacionResult As Entidades.CalculoSaldoLimiteCreditoResultado)
      If idCliente Is Nothing Then
         Throw New ArgumentNullException(NameOf(idCliente))
      End If

      Dim sql = New SqlServer.Clientes(da, ModoClienteProspecto)
      sql.Clientes_U_SaldoLimiteDeCredito(idCliente.Value, estadoSituacionResult.LimiteDeCreditoNuevo, estadoSituacionResult.SaldoLimiteDeCreditoNuevo)

      Dim rAudit = New Auditorias(da)
      rAudit.Insertar(ModoClienteProspecto.ToString() + "s", Entidades.OperacionesAuditorias.Modificacion, actual.Nombre,
                      String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), idCliente.Value), conMilisegundos:=False)

   End Sub

   Public Function Get1(IdCliente As Long, incluirFoto As Boolean, puedeVerDetalleValoracionEstrellas As Boolean) As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).Clientes_G1(IdCliente, incluirFoto, puedeVerDetalleValoracionEstrellas, porCodigo:=False)
   End Function

   Public Function Get1PorCodigo(codCliente As Long, incluirFoto As Boolean, puedeVerDetalleValoracionEstrellas As Boolean) As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).Clientes_G1(codCliente, incluirFoto, puedeVerDetalleValoracionEstrellas, porCodigo:=True)
   End Function

   Public Function GetAll_Ids() As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).Clientes_GA_Ids()
   End Function

   Public Function GetCodigoMaximo(Campo As String) As Long

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendFormat("SELECT MAX(" & Campo & ") AS Maximo FROM {0}s", ModoClienteProspecto.ToString())
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Dim val As Long = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Long.Parse(dt.Rows(0)("Maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Function GetFiltradoPorVendedor(IdVendedor As Integer) As DataTable
      Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
      Dim dt As DataTable = sql.GetFiltradoPorVendedor(IdVendedor)
      Return dt
   End Function

   Public Function GetFiltradoPorCodigo(codigoCliente As Long, busquedaParcial As Boolean, soloActivos As Boolean) As DataTable
      Return GetFiltradoPorCodigo(codigoCliente, busquedaParcial, soloActivos, idCategoria:=0)
   End Function

   Public Function GetFiltradoPorCodigo(codigoCliente As Long, busquedaParcial As Boolean, soloActivos As Boolean, idCategoria As Integer) As DataTable
      Dim codigoYDocumento As Boolean = Publicos.ClienteBuscarPorCodigoYNroDocumento

      Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
      Dim dt As DataTable = sql.GetFiltradoPorCodigo(codigoCliente, False, String.Empty, soloActivos, codigoYDocumento, actual.NivelAutorizacion, idCategoria)

      If dt.Rows.Count = 0 And busquedaParcial Then
         dt = sql.GetFiltradoPorCodigo(codigoCliente, True, String.Empty, soloActivos, codigoYDocumento, actual.NivelAutorizacion, idCategoria)
      End If
      Return dt
   End Function

   Public Function GetFiltradoPorTipoYNroDocumento(tipoDocCliente As String, nroDocCliente As Long) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.Clientes(da, ModoClienteProspecto).GetFiltradoPorTipoYNroDocumento(tipoDocCliente, nroDocCliente))
   End Function

   Public Function GetClientesLiviando(tipoDocCliente As String, nroDocCliente As Long) As List(Of Entidades.ClienteLiviano)
      Return CargaLista(GetFiltradoPorTipoYNroDocumento(tipoDocCliente, nroDocCliente),
                        Sub(o, dr) CargarUnoLiviano(o, dr), Function() New Entidades.ClienteLiviano())
   End Function
   Public Function GetTodosClientesLiviando() As List(Of Entidades.ClienteLiviano)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUnoLiviano(o, dr), Function() New Entidades.ClienteLiviano())
   End Function
   Public Function GetUnoLiviando(idCliente As Long) As Entidades.ClienteLiviano
      Return GetUnoLiviando(idCliente, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUnoLiviando(idCliente As Long, accion As AccionesSiNoExisteRegistro) As Entidades.ClienteLiviano
      Dim sql = New SqlServer.Clientes(da, ModoClienteProspecto)
      Dim dt = sql.Clientes_G1(idCliente, incluirFoto:=False, _puedeVerDetalleValoracionEstrellas, porCodigo:=False)
      Return CargaEntidad(dt,
                          Sub(o, dr) CargarUnoLiviano(o, dr), Function() New Entidades.ClienteLiviano(),
                          accion, Function() String.Format("No existe cliente con Id: {0} (GetUnoLiviano)", idCliente))
   End Function
   Public Function GetUnoLivianoPorCodigo(codigoCliente As Long, accion As AccionesSiNoExisteRegistro) As Entidades.ClienteLiviano
      Dim dt As DataTable = New SqlServer.Clientes(da, ModoClienteProspecto).GetFiltradoPorCodigo(codigoCliente, False, String.Empty, False, False, actual.NivelAutorizacion, idCategoria:=0)
      Return CargaEntidad(dt,
                          Sub(o, dr) CargarUnoLiviano(o, dr), Function() New Entidades.ClienteLiviano(),
                          accion, Function() String.Format("No existe cliente con Id: {0} (GetUnoLiviano)", codigoCliente))
   End Function

   Public Function GetFiltradoPorCodigoClienteLetras(codigoClienteLetras As String) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.Clientes(da, ModoClienteProspecto).GetFiltradoPorCodigoClienteLetras(codigoClienteLetras, True))
   End Function

   Public Function GetAsignacionCargos(idCategoria As Integer?, idZonaGeografica As String,
                                       idCobrador As Integer,
                                       filtroPcs As String, cantidadPcs As Integer,
                                       idcliente As Long, filtroActivo As Entidades.Publicos.SiNoTodos, idTipoCliente As Integer) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.Clientes(da, ModoClienteProspecto).
                                                   Clientes_GetAsignacionCargos(idCategoria, idZonaGeografica, filtroPcs, cantidadPcs, idcliente, idCobrador, filtroActivo, idTipoCliente))
   End Function

   Public Function GetFiltradoPorCodigoTodos(CodigoCliente As Long, Optional busquedaParcial As Boolean = True) As DataTable
      Return GetFiltradoPorCodigo(CodigoCliente, busquedaParcial, False)
   End Function

   Public Function GetUnoPorCodigo(codigoCliente As Long,
                                   Optional incluirFoto As Boolean = False,
                                   Optional soloActivos As Boolean = True,
                                   Optional incluirAdjuntos As Entidades.ModoCargaAdjunto = Entidades.ModoCargaAdjunto.NoCargar) As Entidades.Cliente
      Dim dt As DataTable = New SqlServer.Clientes(da, ModoClienteProspecto).GetFiltradoPorCodigo(codigoCliente, False, String.Empty, soloActivos, False, actual.NivelAutorizacion, idCategoria:=0)
      Dim oCli As Entidades.Cliente = Nothing
      If dt.Rows.Count > 0 Then
         oCli = New Entidades.Cliente()
         Me.CargarUno(oCli, dt.Rows(0), incluirAdjuntos)
      End If

      Return oCli
   End Function

   Public Function GetUnoPorCodigoLetras(codigoClienteLetras As String) As Entidades.Cliente
      Return GetUnoPorCodigoLetras(codigoClienteLetras, incluirFoto:=False, soloActivos:=True, incluirAdjuntos:=Entidades.ModoCargaAdjunto.NoCargar)
   End Function

   Public Function GetUnoPorCodigoLetras(codigoClienteLetras As String,
                                         incluirFoto As Boolean, soloActivos As Boolean, incluirAdjuntos As Entidades.ModoCargaAdjunto) As Entidades.Cliente
      Dim dt = New SqlServer.Clientes(da, ModoClienteProspecto).GetFiltradoPorCodigoClienteLetras(codigoClienteLetras, False)
      Dim oCli As Entidades.Cliente = Nothing
      If dt.Rows.Count > 0 Then
         oCli = New Entidades.Cliente()
         CargarUno(oCli, dt.Rows(0), incluirAdjuntos)
      End If

      Return oCli
   End Function

   Public Function GetFiltradoPorNombre(nombre As String) As DataTable
      Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
      Dim dt As DataTable = sql.GetFiltradoPorNombre(nombre)
      Return dt
   End Function

   Public Function GetUno(idCliente As Long, Optional incluirFoto As Boolean = False, Optional incluirAdjuntos As Entidades.ModoCargaAdjunto = Entidades.ModoCargaAdjunto.NoCargar) As Entidades.Cliente
      Return EjecutaConConexion(Function() _GetUno(idCliente, incluirFoto, incluirAdjuntos))
   End Function

   Public Function _GetUno(idCliente As Long, Optional incluirFoto As Boolean = False, Optional incluirAdjuntos As Entidades.ModoCargaAdjunto = Entidades.ModoCargaAdjunto.NoCargar) As Entidades.Cliente
      Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
      Dim dt As DataTable = sql.Clientes_G1(idCliente, incluirFoto, _puedeVerDetalleValoracionEstrellas, porCodigo:=False)
      Dim oCli As Entidades.Cliente = New Entidades.Cliente()
      If dt.Rows.Count > 0 Then
         CargarUno(oCli, dt.Rows(0), incluirAdjuntos)
      End If
      Return oCli
   End Function

   Public Function GetUnoPorTipoYNroDocumento(tipoDocCliente As String, nroDocCliente As Long) As Entidades.Cliente
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
         Dim dt As DataTable = sql.GetUnoPorTipoYNroDocumento(tipoDocCliente, nroDocCliente)
         Dim oCli As Entidades.Cliente = New Entidades.Cliente()
         If dt.Rows.Count > 0 Then
            Me.CargarUno(oCli, dt.Rows(0), incluirAdjuntos:=Entidades.ModoCargaAdjunto.NoCargar)
         Else
            oCli = Nothing
         End If
         Return oCli
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetUnoPorCUIT(cuit As String) As Entidades.Cliente
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
         Dim dt As DataTable = sql.GetUnoPorCUIT(cuit)
         Dim oCli As Entidades.Cliente = New Entidades.Cliente()
         If dt.Rows.Count > 0 Then
            Me.CargarUno(oCli, dt.Rows(0), incluirAdjuntos:=Entidades.ModoCargaAdjunto.NoCargar)
         Else
            oCli = Nothing
         End If
         Return oCli
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetFiltradoPorNombre(NombreCliente As String, soloActivos As Boolean, idCategoria As Integer) As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).GetFiltradoPorCodigo(Nothing, False, NombreCliente, soloActivos, False, actual.NivelAutorizacion, idCategoria:=idCategoria)
   End Function
   Public Function GetFiltradoPorNombre(NombreCliente As String, soloActivos As Boolean) As DataTable
      Return GetFiltradoPorNombre(NombreCliente, soloActivos, idCategoria:=0)
   End Function

   Public Function GetFiltradoPorDireccion(Direccion As String) As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).GetFiltradoPorDireccion(Direccion, actual.NivelAutorizacion)
   End Function

   Public Function GetFiltradoPorNombreFantasia(NombreFantasia As String, busquedaParcial As Boolean) As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).GetFiltradoPorNombrefantasia(NombreFantasia, busquedaParcial)
   End Function

   Public Function GetFiltradoPorCUIT(CUIT As String) As DataTable
      Return GetFiltradoPorCUIT(CUIT, True)
   End Function
   Public Function GetFiltradoPorCUIT(CUIT As String, estado As Boolean) As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).GetFiltradoPorCUIT(CUIT, actual.NivelAutorizacion, estado)
   End Function

   Public Function GetPorFiltrosVarios(idVendedor As Integer,
                                       idCliente As Long,
                                       idZonaGeografica As String,
                                       idCategoria As Integer,
                                       idListaDePrecios As Integer,
                                       idFormaPago As Integer,
                                       descPorRecargo As Decimal?,
                                       activo As String,
                                       idTipoComprobante As String,
                                       idCobrador As Integer,
                                       idEstado As Integer,
                                       recibeNotificaciones As String,
                                       nivelAutorizacion As Short?,
                                       alicuota2deProducto As String,
                                       tiposCliente As Entidades.TipoCliente(),
                                       publicarEnWeb As String,
                                       idCategoriaFiscal As Integer) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.Clientes(da, ModoClienteProspecto)
            Return sql.GetPorFiltrosVarios(idVendedor,
                                           idCliente,
                                           idZonaGeografica,
                                           idCategoria,
                                           idListaDePrecios,
                                           idFormaPago,
                                           descPorRecargo,
                                           activo, idTipoComprobante,
                                           idEstado,
                                           recibeNotificaciones, nivelAutorizacion,
                                           alicuota2deProducto, idCobrador,
                                           tiposCliente, publicarEnWeb,
                                           idCategoriaFiscal)
         End Function)
   End Function

   Public Function GetContactosClientes() As DataTable

      Dim sql As SqlServer.Clientes
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Clientes(da, ModoClienteProspecto)

         dt = sql.GetContactosClientes()

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function GetProspectoSinCRM() As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).GetProspectoSinCRM()
   End Function
   Public Function GetCantidadProspectoSinCRM() As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).GetCantidadProspectoSinCRM()
   End Function

   Public Function GetParaEnvioMasivoCorreo(IdVendedor As Integer,
                                            idCliente As Long,
                                            idZonaGeografica As String,
                                            idCategoria As Integer,
                                            idListaDePrecios As Integer,
                                            idFormaPago As Integer,
                                            descPorRecargo As Decimal?,
                                            activo As String,
                                            idTipoComprobante As String,
                                            configMail As String,
                                            RecibeNotificaciones As String,
                                            FiltrarPorEmbarcaciones As String) As DataTable
      Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
      Return sql.GetParaEnvioMasivoCorreo(IdVendedor,
                                          idCliente,
                                          idZonaGeografica,
                                          idCategoria,
                                          idListaDePrecios,
                                          idFormaPago,
                                          descPorRecargo,
                                          activo, idTipoComprobante, configMail, RecibeNotificaciones,
                                          FiltrarPorEmbarcaciones)
   End Function

   Public Function GetCodigoClienteMaximo(CodigoCliente As String) As Long

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0

         If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Prospecto Then
            CodigoCliente = "Codigo" + ModoClienteProspecto.ToString()
         End If

         .AppendFormat("SELECT MAX(CAST(Codigo{0} as bigint)) AS maximo FROM {0}s WHERE Codigo{0} = {1}", ModoClienteProspecto.ToString(), CodigoCliente)
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Dim val As Long = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Long.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Sub ActualizacionMasiva(listaClientes As List(Of Entidades.Cliente))
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
         Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
         Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
         Dim OperacAudit As Entidades.OperacionesAuditorias

         For Each cliente As Entidades.Cliente In listaClientes

            sql.Clientes_UVarios(cliente.IdCliente,
                                 cliente.Vendedor.IdEmpleado,
                                 cliente.IdCategoria, cliente.IdListaPrecios,
                                 cliente.ZonaGeografica.IdZonaGeografica,
                                 cliente.IdFormasPago, cliente.CambioDescuentoRecargoPorc,
                                 cliente.DescuentoRecargoPorc, cliente.Activo, cliente.IdTipoComprobante,
                                 cliente.EstadoCliente.IdEstadoCliente,
                                 cliente.CantidadVisitas, cliente.Localidad.IdLocalidad, cliente.RecibeNotificaciones, cliente.NivelAutorizacion,
                                 cliente.IdTransportista, cliente.Alicuota2deProducto.ToString(), cliente.Cobrador.IdEmpleado, cliente.TipoCliente.IdTipoCliente,
                                 cliente.PublicarEnWeb, cliente.LimiteDiasVtoFactura, cliente.LimiteDeCredito, cliente.IdCategoriaFiscal)

            Using dtAudit As DataTable = sqlAudit.Auditorias_G1(ModoClienteProspecto.ToString() + "s", String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), cliente.IdCliente))
               'Si no tiene registro es porque se borro el alta en la auditoria (podria pasar en la implementacion inicial)
               If dtAudit.Rows.Count > 0 Then
                  Select Case True
                     Case Not cliente.Activo And Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
                        'Lo inactivo
                        OperacAudit = Entidades.OperacionesAuditorias.Inactivar
                     Case cliente.Activo And Not Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
                        'Lo activo
                        OperacAudit = Entidades.OperacionesAuditorias.Alta
                     Case Else
                        OperacAudit = Entidades.OperacionesAuditorias.Modificacion
                  End Select
               Else
                  OperacAudit = Entidades.OperacionesAuditorias.Alta
               End If
            End Using

            rAudit.Insertar(ModoClienteProspecto.ToString() + "s", OperacAudit, actual.Nombre,
                            String.Format("Id{0} = {1}", ModoClienteProspecto.ToString(), cliente.IdCliente), conMilisegundos:=False)
         Next

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub ImportarClientes(idSucursal As Integer,
                               datos As DataTable,
                               tipoNovedad As Entidades.CRMTipoNovedad,
                               usuario As String,
                               ByRef BarraProg As Windows.Forms.ProgressBar)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim dt As DataTable = datos

         Dim rCRM = New CRMNovedades(da)

         Dim oCategorias = New Categorias(da)
         Dim dtCategorias = New DataTable()
         Dim Categoria = New Entidades.Categoria()

         Dim oCategoriasFiscales = New CategoriasFiscales(da)
         Dim dtCategoriasFiscales = New DataTable()
         Dim CategoriaFiscal = New Entidades.CategoriaFiscal()

         Dim oZonasGeograficas = New ZonasGeograficas(da)
         Dim dtZonasGeograficas = New DataTable()
         Dim ZonaGeografica = New Entidades.ZonaGeografica()

         Dim oListasDePrecios = New ListasDePrecios(da)
         Dim dtListasDePrecios = New DataTable()
         Dim ListaDePrecio = New Entidades.ListaDePrecios()

         Dim oVendedores = New Empleados(da)
         Dim dtVendedores = New DataTable()
         Dim Vendedor = New Entidades.Empleado()

         'Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes(da)
         Dim ExisteCliente As Boolean

         Dim rTipoCliente = New Reglas.TiposClientes(da)
         Dim dtTiposClientes = New DataTable

         Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)

         'Dim AnchoNombreCliente As Integer = New Reglas.Publicos().GetAnchoCampo("Clientes", "NombreCliente")
         'Dim AnchoTelefono As Integer = New Reglas.Publicos().GetAnchoCampo("Clientes", "Telefono")

         Dim rPublicos = New Reglas.Publicos()
         Dim tabla = String.Format("{0}s", ModoClienteProspecto.ToString())
         Dim AnchoNombreCliente = rPublicos.GetAnchoCampo(tabla, String.Format("Nombre{0}", ModoClienteProspecto.ToString()))
         Dim AnchoTelefono = rPublicos.GetAnchoCampo(tabla, "Telefono")


         Dim i As Integer = 0

         BarraProg.Maximum = dt.Rows.Count
         BarraProg.Minimum = 0
         BarraProg.Value = 0

         For Each dr As DataRow In dt.Rows

            i += 1
            BarraProg.Value = i

            'If i = 150 Then
            '   Stop
            'End If

            If Boolean.Parse(dr("Importa").ToString()) Then

               ExisteCliente = ExisteCodigo(Long.Parse(dr("CodigoCliente").ToString()))
               Dim Cliente As Entidades.Cliente
               If ExisteCliente Then

                  Cliente = GetUnoPorCodigo(Long.Parse(dr("CodigoCliente").ToString()), False, False)
               Else
                  Cliente = New Entidades.Cliente()
                  Cliente.IdCliente = 0
                  Cliente.CodigoCliente = Long.Parse(dr("CodigoCliente").ToString.Trim())
               End If

               dtCategorias = oCategorias.GetPorNombreExacto(dr("NombreCategoria").ToString())
               'El Vendedor Debe existir, no se pueden crear en la importacion.
               'If dtCategorias.Rows.Count = 0 Then
               '   Categoria.IdCategoria = oCategorias.GetIdMaximo() + 1
               '   Categoria.NombreCategoria = dr("NombreCategoria").ToString.Trim()
               '   oCategorias.Inserta(Categoria)
               '   Cliente.IdCategoria = Categoria.IdCategoria
               'Else
               Cliente.IdCategoria = Integer.Parse(dtCategorias.Rows(0)("IdCategoria").ToString())
               'End If

               dtCategoriasFiscales = oCategoriasFiscales.GetPorNombreExacto(dr("NombreCategoriaFiscal").ToString())
               Cliente.CategoriaFiscal.IdCategoriaFiscal = Short.Parse(dtCategoriasFiscales.Rows(0)("IdCategoriaFiscal").ToString())

               dtZonasGeograficas = oZonasGeograficas.GetPorNombreExacto(dr("NombreZonaGeografica").ToString())
               'El Vendedor Debe existir, no se pueden crear en la importacion.
               'If dtZonasGeograficas.Rows.Count = 0 Then
               '   ZonaGeografica.IdZonaGeografica = dr("NombreZonaGeografica").ToString.Trim()
               '   ZonaGeografica.NombreZonaGeografica = dr("NombreZonaGeografica").ToString.Trim()
               '   oZonasGeograficas.Inserta(ZonaGeografica)
               '   Cliente.ZonaGeografica.IdZonaGeografica = ZonaGeografica.IdZonaGeografica
               'Else
               Cliente.ZonaGeografica.IdZonaGeografica = dtZonasGeograficas.Rows(0)("IdZonaGeografica").ToString()
               'End If

               dtListasDePrecios = oListasDePrecios.GetPorNombreExacto(dr("NombreListaPrecios").ToString())
               'La Lista Debe existir, no se pueden crear en la importacion.
               'If dtListasDePrecios.Rows.Count = 0 Then
               '   ListaDePrecio.IdListaPrecios = Integer.Parse((oListasDePrecios.GetCodigoMaximo() + 1).ToString())
               '   ListaDePrecio.NombreListaPrecios = dr("NombreListaPrecios").ToString.Trim()
               '   oListasDePrecios.Inserta(ListaDePrecio)
               '   Cliente.IdListaPrecios = ListaDePrecio.IdListaPrecios
               'Else
               Cliente.IdListaPrecios = Integer.Parse(dtListasDePrecios.Rows(0)("IdListaPrecios").ToString())
               'End If

               dtVendedores = oVendedores.GetPorNombreExacto(dr("NombreVendedor").ToString())
               'El Vendedor Debe existir, no se pueden crear en la importacion.
               'If dtVendedores.Rows.Count = 0 Then
               '   Vendedor.TipoDocEmpleado = "COD"
               '   Vendedor.NroDocEmpleado = (oVendedores.GetIdMaximo() + 1).ToString()
               '   Vendedor.NombreEmpleado = dr("NombreVendedor").ToString()
               '   Vendedor.EsVendedor = True
               '   oVendedores.Inserta(Vendedor)
               '   Cliente.Vendedor.TipoDocEmpleado = Vendedor.TipoDocEmpleado
               '   Cliente.Vendedor.NroDocEmpleado = Vendedor.NroDocEmpleado
               'Else
               '   Cliente.Vendedor = New Reglas.Empleados().GetUno(dtVendedores.Rows(0)("TipoDocEmpleado").ToString(), dtVendedores.Rows(0)("NroDocEmpleado").ToString())
               Cliente.Vendedor.TipoDocEmpleado = dtVendedores.Rows(0)("TipoDocEmpleado").ToString()
               Cliente.Vendedor.NroDocEmpleado = dtVendedores.Rows(0)("NroDocEmpleado").ToString()
               Cliente.Vendedor.IdEmpleado = Integer.Parse(dtVendedores.Rows(0)("IdEmpleado").ToString())
               'End If


               If Not String.IsNullOrEmpty(dr("TipoDocCliente").ToString.Trim()) And Not String.IsNullOrEmpty(dr("NroDocCliente").ToString.Trim()) Then
                  Cliente.TipoDocCliente = dr("TipoDocCliente").ToString.Trim()
                  Cliente.NroDocCliente = Long.Parse(dr("NroDocCliente").ToString.Trim())
               Else
                  Cliente.TipoDocCliente = ""
                  Cliente.NroDocCliente = 0
               End If

               Cliente.NombreCliente = dr("NombreCliente").ToString.Trim().Truncar(AnchoNombreCliente).Replace("'", "´")

               Cliente.Direccion = dr("Direccion").ToString().Truncar(100).Replace("'", "´")
               If dr.Table.Columns.Contains("DireccionAdicional") Then
                  Cliente.DireccionAdicional = dr("DireccionAdicional").ToString().Replace("'", "´")
               End If

               Cliente.Localidad.IdLocalidad = Integer.Parse(dr("IdLocalidad").ToString())

               Cliente.Telefono = dr("Telefono").ToString().Trim().Truncar(AnchoTelefono).Replace("'", "´")

               Cliente.CorreoElectronico = dr("CorreoElectronico").ToString()

               Cliente.Celular = dr("Celular").ToString()
               Cliente.Usuario = usuario

               If Not String.IsNullOrEmpty(Strings.Trim(dr("CUIT").ToString.Trim())) Then
                  Cliente.Cuit = Strings.Trim(dr("CUIT").ToString.Trim()).Replace("-", "")
               Else
                  Cliente.Cuit = String.Empty
               End If

               Cliente.Observacion = dr("Observacion").ToString().Replace("'", "´")

               Cliente.FechaAlta = Date.Parse(dr("FechaAlta").ToString())

               Cliente.NombreDeFantasia = dr("NombreDeFantasia").ToString().Replace("'", "´")

               Cliente.Twitter = dr("Twitter").ToString()

               Cliente.UtilizaAppSoporte = False

               Cliente.Sexo = DirectCast([Enum].Parse(GetType(Entidades.Cliente.SexoOpciones), dr("Sexo").ToString()), Entidades.Cliente.SexoOpciones)

               '-.PE-32498.-
               dtTiposClientes = rTipoCliente.GetAllPorNombre(dr("TipoCliente").ToString(), nombreExacto:=True)
               Cliente.TipoCliente.IdTipoCliente = Integer.Parse(dtTiposClientes.Rows(0)("IdTipoCliente").ToString())

               If Not ExisteCliente Then

                  Cliente.IdSucursal = idSucursal
                  Cliente.Activo = True
                  Cliente.FechaNacimiento = Date.Now
                  Cliente.NroOperacion = 0
                  Cliente.NombreTrabajo = ""
                  Cliente.DireccionTrabajo = ""
                  Cliente.IdLocalidadTrabajo = 0
                  Cliente.TelefonoTrabajo = ""
                  Cliente.CorreoTrabajo = ""
                  Cliente.FechaIngresoTrabajo = Date.Now

                  Cliente.MonedaCredito = 1

                  Cliente.SaldoPendiente = 0
                  Cliente.TipoDocumentoGarante = ""
                  Cliente.IdClienteGarante = 0
                  Cliente.LimiteDeCredito = 0
                  Cliente.SaldoLimiteDeCredito = 0
                  Cliente.IdSucursalAsociada = 0

                  Cliente.DescuentoRecargoPorc = 0
                  Cliente.IdTipoComprobante = ""
                  Cliente.IdFormasPago = 0
                  ' Cliente.Foto = Nothing
                  Cliente.IdTransportista = 0
                  Cliente.IngresosBrutos = ""
                  Cliente.InscriptoIBStaFe = False
                  Cliente.LocalIB = False
                  Cliente.ConvMultilateralIB = False
                  Cliente.NumeroLote = 0
                  Cliente.PaginaWeb = ""

                  Cliente.Calle.IdCalle = 1
                  Cliente.Calle2.IdCalle = 1

                  'van fijo por ahora-----------
                  Cliente.EstadoCliente.IdEstadoCliente = 1
                  Cliente.Cobrador.IdEmpleado = 1
                  '   Cliente.Cobrador.NroDocEmpleado = "1"

                  'Cliente.TipoCliente.IdTipoCliente = 1
                  '-----------------------------
                  Cliente.ModificarDatos = True
                  Cliente.EsClienteGenerico = False
                  Cliente.UsaArchivoAImprimir2 = False
                  Cliente.CantidadVisitas = 0

                  Cliente.NivelAutorizacion = 0
                  Cliente.DadoAltaPor = Cliente.Vendedor

                  Cliente.ValorizacionFacturacionMensual = 0
                  Cliente.ValorizacionCoeficienteFacturacion = 0
                  Cliente.ValorizacionFacturacion = 0
                  Cliente.ValorizacionImporteAdeudado = 0
                  Cliente.ValorizacionCoeficienteDeuda = 0
                  Cliente.ValorizacionDeuda = 0
                  Cliente.ValorizacionProyecto = 0
                  Cliente.ValorizacionProyectoObservacion = ""
                  Cliente.ValorizacionCliente = 0
                  Cliente.ValorizacionEstrellas = 0
                  Cliente.PublicarEnWeb = True

                  Cliente.IdEstadoCivil = New Reglas.EstadosCiviles().GetUnoNombre("A Definir").IdEstadoCivil

                  Inserta(Cliente)

                  If tipoNovedad IsNot Nothing Then
                     Dim crm = rCRM.GetNewEntityWithDefaults(tipoNovedad, usuario)

                     crm.Descripcion = String.Format("Alta automática por Importación de {0}", ModoClienteProspecto.ToString())
                     crm.IdSistema = Cliente.ZonaGeografica.IdZonaGeografica
                     crm.IdProspecto = Cliente.IdCliente

                     rCRM.Inserta(crm)
                  End If

               Else
                  Actualiza(Cliente)

               End If

            End If
         Next

         da.CommitTransaction()

      Catch
         BarraProg.Value = 0
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub ImportarClientesBejerman(IdSucursal As Integer,
                             datos As DataTable,
                             usuario As String,
                             ByRef BarraProg As System.Windows.Forms.ProgressBar)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim dt As DataTable = datos

         Dim oCategorias As Eniac.Reglas.Categorias = New Eniac.Reglas.Categorias(da)
         Dim dtCategorias As DataTable = New DataTable
         Dim Categoria As Entidades.Categoria = New Entidades.Categoria

         Dim oCategoriasFiscales As Eniac.Reglas.CategoriasFiscales = New Eniac.Reglas.CategoriasFiscales(da)
         Dim dtCategoriasFiscales As DataTable = New DataTable
         Dim CategoriaFiscal As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal

         Dim oZonasGeograficas As Eniac.Reglas.ZonasGeograficas = New Eniac.Reglas.ZonasGeograficas(da)
         Dim dtZonasGeograficas As DataTable = New DataTable
         Dim ZonaGeografica As Entidades.ZonaGeografica = New Entidades.ZonaGeografica

         Dim oListasDePrecios As Eniac.Reglas.ListasDePrecios = New Eniac.Reglas.ListasDePrecios(da)
         Dim dtListasDePrecios As DataTable = New DataTable
         Dim ListaDePrecio As Entidades.ListaDePrecios = New Entidades.ListaDePrecios

         Dim oVendedores As Eniac.Reglas.Empleados = New Eniac.Reglas.Empleados(da)
         Dim dtVendedores As DataTable = New DataTable
         Dim Vendedor As Entidades.Empleado = New Entidades.Empleado

         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes(da)
         Dim ExisteCliente As Boolean
         Dim Cliente As Entidades.Cliente = New Entidades.Cliente

         Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)

         Dim AnchoNombreCliente As Integer = New Reglas.Publicos().GetAnchoCampo("Clientes", "NombreCliente")
         Dim AnchoTelefono As Integer = New Reglas.Publicos().GetAnchoCampo("Clientes", "Telefono")


         Dim i As Integer = 0

         BarraProg.Maximum = dt.Rows.Count
         BarraProg.Minimum = 0
         BarraProg.Value = 0

         For Each dr As DataRow In dt.Rows

            i += 1
            BarraProg.Value = i

            If Boolean.Parse(dr("Importa").ToString()) Then

               Cliente = New Entidades.Cliente
               'ExisteCliente = oClientes.ExisteCodigo(Long.Parse(dr("CodigoCliente").ToString()))

               'If ExisteCliente Then

               '   Cliente = oClientes.GetUnoPorCodigo(Long.Parse(dr("CodigoCliente").ToString()), False, False)
               'Else
               Cliente.IdCliente = 0
               '   Cliente.CodigoCliente = Long.Parse(dr("CodigoCliente").ToString.Trim())
               'End If

               dtCategorias = oCategorias.GetPorNombreExacto(dr("NombreCategoria").ToString())
               Cliente.IdCategoria = Integer.Parse(dtCategorias.Rows(0)("IdCategoria").ToString())

               dtCategoriasFiscales = oCategoriasFiscales.GetPorNombreExacto(dr("NombreCategoriaFiscal").ToString())
               Cliente.CategoriaFiscal.IdCategoriaFiscal = Short.Parse(dtCategoriasFiscales.Rows(0)("IdCategoriaFiscal").ToString())

               dtZonasGeograficas = oZonasGeograficas.GetPorNombreExacto(dr("NombreZonaGeografica").ToString())

               Cliente.ZonaGeografica.IdZonaGeografica = dtZonasGeograficas.Rows(0)("IdZonaGeografica").ToString()

               dtListasDePrecios = oListasDePrecios.GetPorNombreExacto(dr("NombreListaPrecios").ToString())
               Cliente.IdListaPrecios = Integer.Parse(dtListasDePrecios.Rows(0)("IdListaPrecios").ToString())


               dtVendedores = oVendedores.GetPorNombreExacto(dr("NombreVendedor").ToString())
               Cliente.Vendedor.TipoDocEmpleado = dtVendedores.Rows(0)("TipoDocEmpleado").ToString()
               Cliente.Vendedor.NroDocEmpleado = dtVendedores.Rows(0)("NroDocEmpleado").ToString()
               Cliente.Vendedor.IdEmpleado = Integer.Parse(dtVendedores.Rows(0)("IdEmpleado").ToString())

               If Not String.IsNullOrEmpty(dr("TipoDocCliente").ToString.Trim()) And Not String.IsNullOrEmpty(dr("NroDocCliente").ToString.Trim()) Then
                  Cliente.TipoDocCliente = dr("TipoDocCliente").ToString.Trim()
                  Cliente.NroDocCliente = Long.Parse(dr("NroDocCliente").ToString.Trim())
               Else
                  Cliente.TipoDocCliente = ""
                  Cliente.NroDocCliente = 0
               End If

               If Strings.Trim(dr("NombreCliente").ToString.Trim()).Length > AnchoNombreCliente Then
                  Cliente.NombreCliente = Strings.Trim(dr("NombreCliente").ToString.Trim()).Remove(AnchoNombreCliente)
               Else
                  Cliente.NombreCliente = Strings.Trim(dr("NombreCliente").ToString.Trim())
               End If
               Cliente.Direccion = dr("Direccion").ToString()
               If dr.Table.Columns.Contains("DireccionAdicional") Then
                  Cliente.DireccionAdicional = dr("DireccionAdicional").ToString()
               End If

               Cliente.Localidad.IdLocalidad = Integer.Parse(dr("IdLocalidad").ToString())

               If Strings.Trim(dr("Telefono").ToString.Trim()).Length > AnchoTelefono Then
                  Cliente.Telefono = Strings.Trim(dr("Telefono").ToString().Trim()).Remove(AnchoTelefono)
               Else
                  Cliente.Telefono = Strings.Trim(dr("Telefono").ToString().Trim())
               End If

               Cliente.CorreoElectronico = dr("CorreoElectronico").ToString()

               Cliente.Celular = dr("Celular").ToString()
               Cliente.Usuario = usuario

               If Not String.IsNullOrEmpty(Strings.Trim(dr("CUIT").ToString.Trim())) Then
                  Cliente.Cuit = Strings.Trim(dr("CUIT").ToString.Trim()).Replace("-", "")
               Else
                  Cliente.Cuit = String.Empty
               End If

               Cliente.Observacion = dr("Observacion").ToString()

               Cliente.FechaAlta = Date.Parse(dr("FechaAlta").ToString())

               Cliente.NombreDeFantasia = dr("NombreDeFantasia").ToString()

               Cliente.Twitter = dr("Twitter").ToString()

               Cliente.UtilizaAppSoporte = False

               Cliente.CodigoClienteLetras = dr("CodigoClienteLetras").ToString()


               If Not ExisteCliente Then

                  Cliente.IdSucursal = IdSucursal
                  Cliente.Activo = True
                  Cliente.FechaNacimiento = Date.Now
                  Cliente.NroOperacion = 0
                  Cliente.NombreTrabajo = ""
                  Cliente.DireccionTrabajo = ""
                  Cliente.IdLocalidadTrabajo = 0
                  Cliente.TelefonoTrabajo = ""
                  Cliente.CorreoTrabajo = ""
                  Cliente.FechaIngresoTrabajo = Date.Now

                  Cliente.SaldoPendiente = 0
                  Cliente.TipoDocumentoGarante = ""
                  Cliente.IdClienteGarante = 0
                  Cliente.LimiteDeCredito = 0
                  Cliente.SaldoLimiteDeCredito = 0
                  Cliente.IdSucursalAsociada = 0

                  Cliente.DescuentoRecargoPorc = 0
                  Cliente.IdTipoComprobante = ""
                  Cliente.IdFormasPago = 0
                  ' Cliente.Foto = Nothing
                  Cliente.IdTransportista = 0
                  Cliente.IngresosBrutos = ""
                  Cliente.InscriptoIBStaFe = False
                  Cliente.LocalIB = False
                  Cliente.ConvMultilateralIB = False
                  Cliente.NumeroLote = 0
                  Cliente.PaginaWeb = ""
                  'van fijo por ahora-----------
                  Cliente.EstadoCliente.IdEstadoCliente = 1

                  'Cliente.Cobrador.TipoDocEmpleado = "DNI"
                  'Cliente.Cobrador.NroDocEmpleado = "1"

                  Cliente.Cobrador.IdEmpleado = 1

                  Cliente.TipoCliente.IdTipoCliente = 1
                  '-----------------------------
                  Cliente.EsClienteGenerico = False
                  Cliente.UsaArchivoAImprimir2 = False
                  Cliente.CantidadVisitas = 0

                  Cliente.NivelAutorizacion = 0

                  Cliente.DadoAltaPor = Cliente.Vendedor
                  Cliente.ValorizacionFacturacionMensual = 0
                  Cliente.ValorizacionCoeficienteFacturacion = 0
                  Cliente.ValorizacionFacturacion = 0
                  Cliente.ValorizacionImporteAdeudado = 0
                  Cliente.ValorizacionCoeficienteDeuda = 0
                  Cliente.ValorizacionDeuda = 0
                  Cliente.ValorizacionProyecto = 0
                  Cliente.ValorizacionProyectoObservacion = ""
                  Cliente.ValorizacionCliente = 0
                  Cliente.ValorizacionEstrellas = 0
                  Cliente.PublicarEnWeb = True

                  oClientes.Inserta(Cliente)
                  'Else
                  '   oClientes.Actualiza(Cliente)

               End If

            End If
         Next

         da.CommitTransaction()

      Catch ex As Exception
         BarraProg.Value = 0
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub ImportarClientesLIVE(IdSucursal As Integer,
                            datos As DataTable,
                            usuario As String,
                            ByRef BarraProg As System.Windows.Forms.ProgressBar)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim dt As DataTable = datos

         Dim oCategorias As Eniac.Reglas.Categorias = New Eniac.Reglas.Categorias()
         Dim dtCategorias As DataTable = New DataTable
         Dim Categoria As Eniac.Entidades.Categoria = New Eniac.Entidades.Categoria

         Dim oCategoriasFiscales As Eniac.Reglas.CategoriasFiscales = New Eniac.Reglas.CategoriasFiscales(da)
         Dim dtCategoriasFiscales As DataTable = New DataTable
         Dim CategoriaFiscal As Eniac.Entidades.CategoriaFiscal = New Eniac.Entidades.CategoriaFiscal

         Dim oZonasGeograficas As Eniac.Reglas.ZonasGeograficas = New Eniac.Reglas.ZonasGeograficas()
         Dim dtZonasGeograficas As DataTable = New DataTable
         Dim ZonaGeografica As Eniac.Entidades.ZonaGeografica = New Eniac.Entidades.ZonaGeografica

         Dim oListasDePrecios As Eniac.Reglas.ListasDePrecios = New Eniac.Reglas.ListasDePrecios()
         Dim dtListasDePrecios As DataTable = New DataTable
         Dim ListaDePrecio As Eniac.Entidades.ListaDePrecios = New Eniac.Entidades.ListaDePrecios

         Dim oVendedores As Eniac.Reglas.Empleados = New Eniac.Reglas.Empleados(da)
         Dim dtVendedores As DataTable = New DataTable
         Dim Vendedor As Eniac.Entidades.Empleado = New Eniac.Entidades.Empleado

         Dim oClientesSIGA As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes(da)
         Dim oClientes As Reglas.Clientes
         Dim ExisteCliente As Boolean
         Dim Cliente As Entidades.Cliente

         Dim AnchoNombreCliente As Integer = New Reglas.Publicos().GetAnchoCampo("Clientes", "NombreCliente")
         Dim AnchoTelefono As Integer = New Reglas.Publicos().GetAnchoCampo("Clientes", "Telefono")

         'vml 15/04/15
         Dim oCalles As Reglas.Calles = New Reglas.Calles()
         Dim dtCalles As DataTable
         Dim oTransportistas As Eniac.Reglas.Transportistas = New Eniac.Reglas.Transportistas
         Dim dtTransp As DataTable
         Dim estadoCli As Reglas.EstadosClientes = New Reglas.EstadosClientes(da)
         Dim empleado As Eniac.Reglas.Empleados = New Eniac.Reglas.Empleados(da)
         Dim dtemple As DataTable
         Dim tipoComprobante As Eniac.Reglas.TiposComprobantes = New Eniac.Reglas.TiposComprobantes(da)
         Dim fPago As Eniac.Reglas.VentasFormasPago = New Eniac.Reglas.VentasFormasPago(da)

         Dim oTiposClientes As Eniac.Reglas.TiposClientes = New Eniac.Reglas.TiposClientes()

         Dim i As Integer = 0

         BarraProg.Maximum = dt.Rows.Count
         BarraProg.Minimum = 0
         BarraProg.Value = 0

         For Each dr As DataRow In dt.Rows

            i += 1
            BarraProg.Value = i

            'If i = 150 Then
            '   Stop
            'End If

            If Boolean.Parse(dr("Importa").ToString()) Then

               ExisteCliente = oClientesSIGA.ExisteCodigo(Long.Parse(dr("CodigoCliente").ToString()))

               oClientes = New Reglas.Clientes()
               Cliente = New Entidades.Cliente

               If ExisteCliente Then
                  Cliente = oClientes.GetUnoPorCodigo(Long.Parse(dr("CodigoCliente").ToString()), False)
               Else
                  Cliente.IdCliente = 0
                  Cliente.CodigoCliente = Long.Parse(dr("CodigoCliente").ToString.Trim())
               End If

               dtCategorias = oCategorias.GetPorNombreExacto(dr("NombreCategoria").ToString())
               Cliente.IdCategoria = Integer.Parse(dtCategorias.Rows(0)("IdCategoria").ToString())

               dtCategoriasFiscales = oCategoriasFiscales.GetPorNombreExacto(dr("NombreCategoriaFiscal").ToString())
               Cliente.CategoriaFiscal.IdCategoriaFiscal = Short.Parse(dtCategoriasFiscales.Rows(0)("IdCategoriaFiscal").ToString())

               dtZonasGeograficas = oZonasGeograficas.GetPorNombreExacto(dr("NombreZonaGeografica").ToString())
               Cliente.ZonaGeografica.IdZonaGeografica = dtZonasGeograficas.Rows(0)("IdZonaGeografica").ToString()

               dtListasDePrecios = oListasDePrecios.GetPorNombreExacto(dr("NombreListaPrecios").ToString())
               Cliente.IdListaPrecios = Integer.Parse(dtListasDePrecios.Rows(0)("IdListaPrecios").ToString())

               dtVendedores = oVendedores.GetPorNombreExacto(dr("NombreVendedor").ToString())
               Cliente.Vendedor.TipoDocEmpleado = dtVendedores.Rows(0)("TipoDocEmpleado").ToString()
               Cliente.Vendedor.NroDocEmpleado = dtVendedores.Rows(0)("NroDocEmpleado").ToString()
               Cliente.Vendedor.IdEmpleado = Integer.Parse(dtVendedores.Rows(0)("IdEmpleado").ToString())

               If Not String.IsNullOrEmpty(dr("TipoDocCliente").ToString.Trim()) And Not String.IsNullOrEmpty(dr("NroDocCliente").ToString.Trim()) Then
                  Cliente.TipoDocCliente = dr("TipoDocCliente").ToString.Trim()
                  Cliente.NroDocCliente = Long.Parse(dr("NroDocCliente").ToString.Trim())
               Else
                  Cliente.TipoDocCliente = Nothing
                  Cliente.NroDocCliente = 0
               End If

               If Strings.Trim(dr("NombreCliente").ToString.Trim()).Length > AnchoNombreCliente Then
                  Cliente.NombreCliente = Strings.Trim(dr("NombreCliente").ToString.Trim()).Remove(AnchoNombreCliente)
               Else
                  Cliente.NombreCliente = Strings.Trim(dr("NombreCliente").ToString.Trim())
               End If

               'Reemplazar con CALLE, Numero y Adicional (x 2) @@@@@@
               'vml
               dtCalles = oCalles.GetPorNombre(dr("NombreCalle").ToString.Trim)
               Cliente.Localidad.IdLocalidad = Integer.Parse(dr("IdLocalidad").ToString())
               Cliente.Calle.Localidad.IdLocalidad = Integer.Parse(dr("IdLocalidad").ToString())
               If dtCalles.Rows.Count = 0 Then ' no existe la calle
                  Cliente.Calle.IdCalle = oCalles.GetCodigoMaximo + 1
                  Cliente.Calle.NombreCalle = dr("NombreCalle").ToString.Trim


                  oCalles.Insertar(Cliente.Calle)
                  oCalles = New Reglas.Calles()   'Se pierde luego del insert
               Else
                  Cliente.Calle.IdCalle = Integer.Parse(dtCalles.Rows(0)("IdCalle").ToString)
                  Cliente.Calle.NombreCalle = dtCalles.Rows(0)("NombreCalle").ToString()
               End If

               Cliente.Altura = Integer.Parse(dr("AlturaCalle").ToString)
               Cliente.DireccionAdicional = dr("DireccionAdicional").ToString()


               'vml
               dtCalles = oCalles.GetPorNombre(dr("NombreCalle2").ToString.Trim)
               Cliente.IdLocalidad2 = Integer.Parse(dr("IdLocalidad2").ToString())
               Cliente.Calle2.Localidad.IdLocalidad = Integer.Parse(dr("IdLocalidad2").ToString())
               If dtCalles.Rows.Count = 0 Then ' no existe la calle
                  Cliente.Calle2.IdCalle = oCalles.GetCodigoMaximo + 1
                  Cliente.Calle2.NombreCalle = dr("NombreCalle2").ToString.Trim

                  'oCalles = New SiLIVE.Reglas.Calles()
                  oCalles.Insertar(Cliente.Calle2)
               Else
                  Cliente.Calle2.IdCalle = Integer.Parse(dtCalles.Rows(0)("IdCalle").ToString)
                  Cliente.Calle2.NombreCalle = dtCalles.Rows(0)("NombreCalle").ToString()
               End If

               Cliente.Altura2 = Integer.Parse(dr("AlturaCalle2").ToString)
               Cliente.DireccionAdicional2 = dr("DireccionAdicional2").ToString()
               'vml

               Cliente.Direccion = Cliente.Calle.NombreCalle & " " & Cliente.Altura & " " & Cliente.DireccionAdicional
               Cliente.Direccion2 = Cliente.Calle2.NombreCalle & " " & Cliente.Altura2 & " " & Cliente.DireccionAdicional2

               Cliente.IdTipoComprobante = dr("CompFact").ToString.Trim.ToUpper

               Cliente.EstadoCliente = estadoCli.GetXNombre(dr("Estado").ToString.Trim.ToUpper, AccionesSiNoExisteRegistro.Nulo)
               Cliente.IdFormasPago = fPago.GetUna(Integer.Parse(dr("FormaPago").ToString())).IdFormasPago
               dtemple = empleado.GetPorNombreExacto(dr("Alta").ToString.Trim)

               Cliente.DadoAltaPor = empleado.GetUno(Integer.Parse(dtemple.Rows(0)("Idempleado").ToString))

               dtTransp = oTransportistas.GetFiltradoPorNombre(dr("Transportista").ToString)
               Cliente.IdTransportista = oTransportistas.GetUno(Long.Parse(dtTransp.Rows(0)("idTransportista").ToString)).idTransportista

               If Strings.Trim(dr("Telefono").ToString.Trim()).Length > AnchoTelefono Then
                  Cliente.Telefono = Strings.Trim(dr("Telefono").ToString().Trim()).Remove(AnchoTelefono)
               Else
                  Cliente.Telefono = Strings.Trim(dr("Telefono").ToString().Trim())
               End If

               Cliente.CorreoElectronico = dr("CorreoElectronico").ToString()

               Cliente.Celular = dr("Celular").ToString()
               Cliente.Usuario = usuario

               If Not String.IsNullOrEmpty(Strings.Trim(dr("CUIT").ToString.Trim())) Then
                  Cliente.Cuit = Strings.Trim(dr("CUIT").ToString.Trim()).Replace("-", "")
               Else
                  Cliente.Cuit = ""
               End If

               Cliente.Observacion = dr("Observacion").ToString()

               Cliente.TipoCliente = oTiposClientes.GetUnoXNombre(dr("TipoCliente").ToString)
               Cliente.UtilizaAppSoporte = False

               If Not ExisteCliente Then

                  Cliente.IdSucursal = IdSucursal
                  Cliente.Activo = True
                  Cliente.FechaNacimiento = Date.Now
                  Cliente.NroOperacion = 0
                  Cliente.NombreTrabajo = ""
                  Cliente.DireccionTrabajo = ""
                  Cliente.IdLocalidadTrabajo = 0
                  Cliente.TelefonoTrabajo = ""
                  Cliente.CorreoTrabajo = ""
                  Cliente.FechaIngresoTrabajo = Date.Now
                  Cliente.SaldoPendiente = 0
                  Cliente.TipoDocumentoGarante = ""
                  Cliente.IdClienteGarante = 0
                  Cliente.LimiteDeCredito = 0
                  Cliente.SaldoLimiteDeCredito = 0
                  Cliente.IdSucursalAsociada = 0
                  Cliente.NombreDeFantasia = ""
                  Cliente.DescuentoRecargoPorc = 0
                  ' Cliente.IdTipoComprobante = ""
                  'Cliente.IdFormasPago = 0
                  ' Cliente.Foto = Nothing
                  ' Cliente.IdTransportista = 0
                  Cliente.IngresosBrutos = ""
                  Cliente.InscriptoIBStaFe = False
                  Cliente.LocalIB = False
                  Cliente.ConvMultilateralIB = False
                  Cliente.NumeroLote = 0
                  Cliente.PaginaWeb = ""
                  'van fijo por ahora-----------
                  Cliente.EstadoCliente.IdEstadoCliente = 1
                  Cliente.Cobrador.IdEmpleado = 1
                  'Cliente.Cobrador.TipoDocEmpleado = "COD"
                  'Cliente.Cobrador.NroDocEmpleado = "1"

                  Cliente.TipoCliente.IdTipoCliente = 1
                  '-----------------------------

                  Cliente.UsaArchivoAImprimir2 = False
                  Cliente.CantidadVisitas = 0
                  Cliente.EsClienteGenerico = False
                  Cliente.HabilitarVisita = True
                  Cliente.CantidadVisitas = 1
                  Cliente.NivelAutorizacion = 0

                  Cliente.ValorizacionFacturacionMensual = 0
                  Cliente.ValorizacionCoeficienteFacturacion = 0
                  Cliente.ValorizacionFacturacion = 0
                  Cliente.ValorizacionImporteAdeudado = 0
                  Cliente.ValorizacionCoeficienteDeuda = 0
                  Cliente.ValorizacionDeuda = 0
                  Cliente.ValorizacionProyecto = 0
                  Cliente.ValorizacionProyectoObservacion = ""
                  Cliente.ValorizacionCliente = 0
                  Cliente.ValorizacionEstrellas = 0
                  Cliente.PublicarEnWeb = True

                  oClientes.Insertar(Cliente)
               Else
                  oClientes.Actualizar(Cliente)

               End If

            End If
         Next

         da.CommitTransaction()

      Catch ex As Exception
         BarraProg.Value = 0
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub


   Public Function GetAuditoriaClientes(fechaDesde As Date, fechaHasta As Date, idCliente As Long, tipoOperacion As String) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.Clientes(da, ModoClienteProspecto).
                                                   GetAuditoriaClientes(fechaDesde, fechaHasta, idCliente, tipoOperacion, _puedeVerDetalleValoracionEstrellas))
   End Function

   Public Function GetClientesExternos(Base As String) As DataTable
      Dim sql As SqlServer.Clientes
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Clientes(da, ModoClienteProspecto)

         dt = sql.GetClientesExternos(Base)

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function Existe(IdCliente As Long) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendFormat("SELECT COUNT(Id{1}) AS Existe FROM {1}s WHERE Id{1} = {0}", IdCliente, ModoClienteProspecto.ToString())
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

   Public Function ExisteClienteTiendaWeb(idClienteTiendaWeb As String, sTipoTienda As String) As Boolean
      Return New SqlServer.Clientes(da, Entidades.Cliente.ModoClienteProspecto.Cliente).ExisteClienteTiendaWeb(idClienteTiendaWeb, sTipoTienda)
   End Function

   Public Function ExisteCodigo(codigoCliente As Long) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendFormat("SELECT COUNT(Codigo{1}) AS Existe FROM {1}s WHERE Codigo{1} = {0}", codigoCliente, ModoClienteProspecto.ToString())
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

   Public Function ExisteCodigoLetras(codigoClienteLetras As String) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendFormat("SELECT COUNT(Codigo{1}Letras) AS Existe FROM {1}s WHERE Codigo{1}Letras = '{0}'", codigoClienteLetras, ModoClienteProspecto.ToString())
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

   Public Function GetMotoresDeBaseDeDatos() As DataTable

      Dim sql As SqlServer.Clientes
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Clientes(da, ModoClienteProspecto)

         dt = sql.GetMotoresDeBaseDeDatos()

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetParaSincronizacionMovil(tipoDireccion As Entidades.TipoDireccion, incluirClientes As String, incluidoEnRuta As Boolean, idCategoria As Integer) As DataTable
      Return EjecutaConConexion(Function() _GetParaSincronizacionMovil(tipoDireccion, incluirClientes, incluidoEnRuta, idCategoria))
   End Function
   Public Function _GetParaSincronizacionMovil(tipoDireccion As Entidades.TipoDireccion, incluirClientes As String, incluidoEnRuta As Boolean, idCategoria As Integer) As DataTable
      Dim Sql = New SqlServer.Clientes(da, ModoClienteProspecto)
      Return Sql.GetParaSincronizacionMovil(tipoDireccion, incluirClientes, incluidoEnRuta, idCategoria)
   End Function

   Public Sub ActualizaCampoDireccion(idCalle As Integer)
      Dim sClientes As SqlServer.Clientes = New SqlServer.Clientes(da, Entidades.Cliente.ModoClienteProspecto.Cliente)
      sClientes.ActualizaCampoDireccion(idCalle)
   End Sub

   Public Function GetClienteTiendaWeb(idClienteTiendaWeb As String, sTipoTienda As String) As Entidades.Cliente
      Return CargaEntidad(New SqlServer.Clientes(da, Entidades.Cliente.ModoClienteProspecto.Cliente).GetClienteTiendaWeb(idClienteTiendaWeb, sTipoTienda),
                   Sub(o, dr) CargarUno(o, dr, Entidades.ModoCargaAdjunto.NoCargar), Function() New Entidades.Cliente,
                     AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existe el cliente con ID {1} : {0}", idClienteTiendaWeb, UCase(sTipoTienda)))
   End Function

   Public Function GetClientesConVersionApi() As DataTable
      Return New SqlServer.Clientes(da, ModoClienteProspecto).GetClientesConVersionApi()
   End Function

   Public Sub ActualizaClientesConVersionApi(dt As DataTable)
      EjecutaConTransaccion(Sub()
                               Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
                               For Each dr As DataRow In dt.Rows
                                  Dim idCliente As Long = Long.Parse(dr("IdCliente").ToString())
                                  sql.ActualizaClientesConVersionApi(idCliente,
                                                                       dr("NroVersionWebmovilPropio").ToString(),
                                                                       dr("NroVersionWebmovilAdminPropio").ToString(),
                                                                       dr("NroVersionSimovilGestionPropio").ToString(),
                                                                       dr("NroVersionActualizadorPropio").ToString())
                               Next
                            End Sub)
   End Sub

   Public Function GetEmisionEtiquetasParaBultos(fechaDesde As Date?, fechaHasta As Date?,
                                                 sucursales As Entidades.Sucursal(),
                                                 tiposComprobantes As Entidades.TipoComprobante(),
                                                 letra As String, emisor As Short,
                                                 numeroComprobanteDesde As Long, numeroComprobanteHasta As Long,
                                                 idCliente As Long,
                                                 idTipoDireccion As Integer,
                                                 nombreComienzaPor As String,
                                                 idCategoria As Integer, origenCategoria As Entidades.OrigenFK,
                                                 idTransportista As Integer, origenTransportista As Entidades.OrigenFK,
                                                 idVendedor As Integer, origenVendedor As Entidades.OrigenFK) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.Clientes(da, ModoClienteProspecto).
                                                   GetEmisionEtiquetasParaBultos(fechaDesde, fechaHasta,
                                                                                 sucursales,
                                                                                 tiposComprobantes, letra, emisor, numeroComprobanteDesde, numeroComprobanteHasta,
                                                                                 idCliente, idTipoDireccion, nombreComienzaPor,
                                                                                 idCategoria, origenCategoria,
                                                                                 idTransportista, origenTransportista,
                                                                                 idVendedor, origenVendedor))
   End Function

   'PE-30973
   Public Function GetClientesCambioCategoriaVencidas() As DataTable
      Return GetFormatData(New SqlServer.Clientes(Me.da, ModoClienteProspecto).GetClientesPorVencimientoCambioCategoria("FechaCambioCategoria", Nothing, Today))
   End Function

   Private Function GetFormatData(dt As DataTable) As DataTable
      'Mostrar Codigo Cliente, Nombre, Categoria, Zona Geografica, Fecha Cambio, Nueva Categoria y Observacion.
      dt.Columns("CodigoCliente").Caption = "Código"
      dt.Columns("NombreCliente").Caption = "Cliente"
      dt.Columns("NombreCategoria").Caption = "Categoría"
      dt.Columns("NombreZonaGeografica").Caption = "Zona Geográfica"
      dt.Columns("FechaCambioCategoria").Caption = "Fecha Cambio Categoría"
      dt.Columns("ObservacionCambioCategoria").Caption = "Observación Cambio Categoría"
      'dt.Columns("IdCategoriaCambio").Caption = "IdCategoriaCambio"
      Return dt
   End Function

   Public Function GetInformeDescuentosClientesPMR(idProducto As String,
                                                   idMarca As Integer,
                                                   idRubro As Integer,
                                                   idSubRubro As Integer,
                                                   idCliente As Long,
                                                   maxRegistros As Integer) As DataTable
      Try
         Me.da.OpenConection()

         Dim sql = New SqlServer.Clientes(da, ModoClienteProspecto)

         Dim dt As DataTable = sql.GetInformeClientesDescuentosPMR(idProducto, idMarca, idRubro, idSubRubro, idCliente, maxRegistros)

         Return dt

      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetMaxFechaActualizacionWeb() As DateTime
      Dim dr As DataRow = New SqlServer.Clientes(da, ModoClienteProspecto).GetMaxFechaActualizacionWeb().Rows(0)
      If Not IsDBNull(dr("FechaActualizacionWeb")) Then Return dr.Field(Of DateTime)("FechaActualizacionWeb")
      Return Nothing
   End Function

   Public Function GetClientesTiendaWeb(reenviarTodo As Boolean, TipoTienda As Entidades.TiendasWeb) As DataTable
      Dim fechaUltimaSincronizacion As Date?

      fechaUltimaSincronizacion = If(reenviarTodo, Nothing, New Reglas.FechasSincronizaciones().GetFechaUltimaSincronizacion(Entidades.JSonEntidades.TiendasWeb.SistemasDestino.SistemasDestino.ARBOREA.ToString(),
                                                                                                                   Entidades.Cliente.NombreTabla))
      '-- Trae todos los clientes para Arborea.- --
      Return New SqlServer.Clientes(da, ModoClienteProspecto).GetClientesTiendaWeb(fechaUltimaSincronizacion, TipoTienda)

   End Function


   Public Sub GuardarIdClienteTiendaWeb(idTiendaWeb As String, idCliente As String, idClienteTiendaWeb As String)
      Dim sql = New SqlServer.Clientes(da, ModoClienteProspecto)
      Me.EjecutaSoloConTransaccion(Function()
                                      sql.GuardarIdClienteTiendaWeb(idTiendaWeb, idCliente, idClienteTiendaWeb)
                                      Return True
                                   End Function)
   End Sub
#End Region

End Class
Public Interface IRestServices
   Event AvanceValidarDatos(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs)
   Event AvanceImportarDatos(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs)

   Sub ImportarDesdeWebSiga(dtClientes As DataTable)
   Sub ImportarDesdeWebSiga(Of T)(dtClientes As List(Of T))
End Interface