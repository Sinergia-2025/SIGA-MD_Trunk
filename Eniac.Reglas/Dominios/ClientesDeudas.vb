Option Strict Off
Public Class ClientesDeudas
   Inherits Base

   Private Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto
   Private _codigo As Long = 0
   Private _contactos As DataTable
#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ClientesDeudas"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "ClientesDeudas"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Inserta(entidad As Eniac.Entidades.Entidad)
      Try
         Me.EjecutaSP(entidad, TipoSP._I)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Sub Actualiza(entidad As Eniac.Entidades.Entidad)
      Try
         Me.EjecutaSP(entidad, TipoSP._U)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._U)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append(" SELECT ")
         .Append(" * ")
         .Append("FROM  ")
         .Append(Me.NombreEntidad)
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ClientesDeudas(Me.da).ClientesDeudas_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)
      Dim en As Entidades.ClienteDeuda = DirectCast(entidad, Entidades.ClienteDeuda)
      Dim en2 As Entidades.Cliente = DirectCast(entidad, Entidades.ClienteDeuda).Cliente

      Dim sql As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)
      Dim sql2 As SqlServer.Clientes = New SqlServer.Clientes(Me.da, Entidades.Cliente.ModoClienteProspecto.Cliente)
      Dim sqlCliContactos As SqlServer.ClientesContactos = New SqlServer.ClientesContactos(da, ModoClienteProspecto)

      Select Case tipo
         Case TipoSP._I
            sql.ClientesDeudas_I(en.IdCliente, en.nro_prestamo, en.fecha_corte, en.tipo_cobro,
                                 en.convenio, en.linea, en.fecha_emision, en.cantidad_cuotas,
                                 en.cuotas_pagas, en.cuotas_adeudadas, en.capital_total, en.deuda_exigible,
                                 en.fecha_ult_cobranza, en.dias_mora, en.deuda_exigible_con_quita, en.empresa,
                                 en.vendedor, en.monto_cuota, en.Activo)
         Case TipoSP._U

            If IsDate(en2.HoraInicio) AndAlso Date.Parse(en2.HoraInicio).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraInicio = en2.HoraInicio.Substring(11, 5)
            Else
               en2.HoraInicio = ""
            End If
            If IsDate(en2.HoraFin) AndAlso Date.Parse(en2.HoraFin).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraFin = en2.HoraFin.Substring(11, 5)
            Else
               en2.HoraFin = ""
            End If
            If IsDate(en2.HoraInicio2) AndAlso Date.Parse(en2.HoraInicio2).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraInicio2 = en2.HoraInicio2.Substring(11, 5)
            Else
               en2.HoraInicio2 = ""
            End If
            If IsDate(en2.HoraFin2) AndAlso Date.Parse(en2.HoraFin2).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraFin2 = en2.HoraFin2.Substring(11, 5)
            Else
               en2.HoraFin2 = ""
            End If

            If IsDate(en2.HoraSabInicio) AndAlso Date.Parse(en2.HoraSabInicio).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraSabInicio = en2.HoraSabInicio.Substring(11, 5)
            Else
               en2.HoraSabInicio = ""
            End If
            If IsDate(en2.HoraSabFin) AndAlso Date.Parse(en2.HoraSabFin).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraSabFin = en2.HoraSabFin.Substring(11, 5)
            Else
               en2.HoraSabFin = ""
            End If
            If IsDate(en2.HoraSabInicio2) AndAlso Date.Parse(en2.HoraSabInicio2).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraSabInicio2 = en2.HoraSabInicio2.Substring(11, 5)
            Else
               en2.HoraSabInicio2 = ""
            End If
            If IsDate(en2.HoraSabFin2) AndAlso Date.Parse(en2.HoraSabFin2).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraSabFin2 = en2.HoraSabFin2.Substring(11, 5)
            Else
               en2.HoraSabFin2 = ""
            End If


            If IsDate(en2.HoraDomInicio) AndAlso Date.Parse(en2.HoraDomInicio).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraDomInicio = en2.HoraDomInicio.Substring(11, 5)
            Else
               en2.HoraDomInicio = ""
            End If
            If IsDate(en2.HoraDomFin) AndAlso Date.Parse(en2.HoraDomFin).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraDomFin = en2.HoraDomFin.Substring(11, 5)
            Else
               en2.HoraDomFin = ""
            End If
            If IsDate(en2.HoraDomInicio2) AndAlso Date.Parse(en2.HoraDomInicio2).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraDomInicio2 = en2.HoraDomInicio2.Substring(11, 5)
            Else
               en2.HoraDomInicio2 = ""
            End If
            If IsDate(en2.HoraDomFin2) AndAlso Date.Parse(en2.HoraDomFin2).TimeOfDay.ToString <> "00:00:00" Then
               en2.HoraDomFin2 = en2.HoraDomFin2.Substring(11, 5)
            Else
               en2.HoraDomFin2 = ""
            End If

            sql2.Clientes_U(en2.IdCliente, en2.CodigoCliente, en2.NombreCliente, en2.NombreDeFantasia, en2.Direccion, en2.DireccionAdicional,
                      en2.IdLocalidad, en2.Telefono, en2.FechaNacimiento, en2.NroOperacion, en2.CorreoElectronico,
                      en2.Celular, en2.NombreTrabajo, en2.DireccionTrabajo, en2.TelefonoTrabajo, en2.CorreoTrabajo,
                      en2.IdLocalidadTrabajo, en2.FechaIngresoTrabajo, en2.FechaAlta, en2.SaldoPendiente, en2.IdClienteGarante,
                      en2.IdCategoria, en2.CategoriaFiscal.IdCategoriaFiscal, en2.Cuit, en2.Vendedor.IdEmpleado,
                      en2.Observacion, en2.IdListaPrecios, en2.ZonaGeografica.IdZonaGeografica, en2.LimiteDeCredito, en2.SaldoLimiteDeCredito, en2.IdSucursalAsociada,
                      en2.DescuentoRecargoPorc, en2.Activo, en2.IdTipoComprobante, en2.IdFormasPago, en2.IdTransportista,
                      en2.IngresosBrutos, en2.InscriptoIBStaFe, en2.LocalIB, en2.ConvMultilateralIB, en2.NumeroLote,
                      en2.IdCaja, en2.GeoLocalizacionLat, en2.GeoLocalizacionLng, en2.IdTipoDeExension, en2.AnioExension,
                      en2.NroCertExension, en2.NroCertPropio, en2.TipoDocCliente, en2.NroDocCliente, en2.DescuentoRecargoPorc2,
                      en2.IdClienteCtaCte, en2.PaginaWeb, en2.LimiteDiasVtoFactura, en2.ModificarDatos, en2.EsResidente,
                      en2.CorreoAdministrativo, en2.EstadoCliente.IdEstadoCliente, en2.TipoCliente.IdTipoCliente, en2.HoraInicio,
                      en2.HoraFin, en2.HoraInicio2, en2.HoraFin2, en2.HoraSabInicio, en2.HoraSabFin,
                      en2.HoraSabInicio2, en2.HoraSabFin2, en2.HoraDomInicio, en2.HoraDomFin, en2.HoraDomInicio2,
                      en2.HoraDomFin2, en2.HorarioCorrido, en2.HorarioCorridoSab, en2.HorarioCorridoDom, en2.NroVersion, en2.FechaActualizacionVersion, en2.FechaInicio, en2.FechaInicioReal,
                      en2.VencimientoLicencia, en2.BackupAutoCuenta, en2.BackupAutoConfig, en2.TienePreciosConIVA, en2.ConsultaPreciosConIVA, en2.TieneServidorDedicado,
                      en2.MotorBaseDatos, en2.CantidadDePCs, en2.HorasCapacitacionPactadas, en2.HorasCapacitacionRealizadas,
                      en2.CBU, en2.Banco.IdBanco, en2.CuentaBancariaClase.IdCuentaBancariaClase, en2.NumeroCuentaBancaria, en2.CuitCtaBancaria,
                      en2.UsaArchivoAImprimir2, en2.CantidadVisitas, en2.BackupNroVersion, en2.Facebook, en2.Instagram, en2.Twitter,
                      en2.IdAplicacion, en2.Edicion, en2.RecibeNotificaciones,
                      en2.Contacto, en2.FechaBaja, en2.VerEnConsultas, en2.Calle.IdCalle, en2.Altura, en2.Calle2.IdCalle, en2.Altura2,
                      en2.DireccionAdicional2, en2.TelefonosParticulares, en2.Fax, en2.FechaSUS, en2.DadoAltaPor.IdEmpleado, en2.HabilitarVisita,
                      en2.Direccion2, en2.IdLocalidad2, en2.ObservacionWeb, en2.RepartoIndependiente, en2.NivelAutorizacion, en2.IdCuentaContable, en2.EsClienteGenerico,
                      en2.URLWebmovilPropio, en2.URLWebmovilAdminPropio, en2.URLSimovilGestionPropio, en2.URLActualizadorPropio, en2.NroVersionWebmovilPropio, en2.NroVersionWebmovilAdminPropio, en2.NroVersionSimovilGestionPropio, en2.NroVersionActualizadorPropio,
                      en2.UtilizaAppSoporte, en2.CantidadLocal, en2.CantidadRemota, en2.CantidadMovil, en2.ObservacionAdministrativa, en2.CodigoClienteLetras, en2.SiMovilIdUsuario, en2.SiMovilClave,
                      en2.Alicuota2deProducto, en2.CertificadoMiPyme, en2.FechaDesdeCertificado, en2.FechaHastaCertificado,
                      en2.Cobrador.IdEmpleado, en2.Sexo, en2.ValorizacionFacturacionMensual, en2.ValorizacionCoeficienteFacturacion, en2.ValorizacionImporteAdeudado, en2.ValorizacionCoeficienteDeuda, en2.ValorizacionProyecto, en2.ValorizacionProyectoObservacion,
                      en2.PublicarEnWeb, en2.HorarioClienteCompleto,
                      en2.IdClienteTiendaNube, en2.IdClienteMercadoLibre, en2.IdClienteArborea, en2.FechaCambioCategoria, en2.ObservacionCambioCategoria, en2.IdCategoriaCambio,
                      en2.ActualizadorAptoParaInstalar, en2.ActualizadorFunciona, en2.ActualizadorFechaInstalacion, en2.ActualizadorVersion, en2.IdImpositivoOtroPais, en2.IdConceptoCM05, en2.IdTipoComprobanteInvocacionMasiva,
                      en2.EsExentoPercIVARes53292023, en2.IdEstadoCivil, en2.VarPesosCotizDolar,
                      en2.MonedaCredito, en2.PublicarEnTiendaNube, en2.PublicarEnMercadoLibre, en2.PublicarEnArborea,
                           en2.PublicarEnGestion, en2.PublicarEnEmpresarial, en2.PublicarEnSincronizacionSucursal)

            If en.Cliente.ContactosBorrados IsNot Nothing Then
               'Primero elimino los contactos que se hayan eliminado en la pantalla.
               For Each drBorrado As DataRow In en.Cliente.ContactosBorrados.Rows
                  Dim idContacto As Integer = Integer.Parse(drBorrado(Entidades.ClienteContacto.Columnas.IdContacto.ToString()).ToString())
                  If idContacto > 0 Then
                     sqlCliContactos.ClientesContactos_D(en.Cliente.IdCliente, idContacto)
                  End If
               Next
            End If

            If en.Cliente.Contactos IsNot Nothing Then
               'Luego actualizo los contactos que se modificaron (tienen un IdContacto que se recuperó cuando se cargó la pantalla)
               For Each drExistentes As DataRow In en.Cliente.Contactos.Select(String.Format("IdContacto > 0"))
                  Dim idContacto As Integer = Integer.Parse(drExistentes(Entidades.ClienteContacto.Columnas.IdContacto.ToString()).ToString())
                  sqlCliContactos.ClientesContactos_U(en.Cliente.IdCliente, idContacto, drExistentes("NombreContacto").ToString(),
                                                      drExistentes("Direccion").ToString(), Integer.Parse(drExistentes("IdLocalidad").ToString()),
                                                      drExistentes("Telefono").ToString(), drExistentes("CorreoElectronico").ToString(),
                                                      drExistentes("Celular").ToString(), drExistentes("Observacion").ToString(),
                                                      Boolean.Parse(drExistentes("Activo").ToString()), drExistentes("IdUsuario").ToString(),
                                                      Integer.Parse(drExistentes("IdTipoContacto").ToString()))
               Next
               Dim codigoContacto As Integer = sqlCliContactos.GetCodigoMaximo(en.Cliente.IdCliente) + 1
               'Por último agrego los contactos que se agregaron (no tiene IdContacto ya que la pantalla no se lo pone)
               For Each drNuevos As DataRow In en.Cliente.Contactos.Select(String.Format("IdContacto IS NULL OR IdContacto = 0"))
                  sqlCliContactos.ClientesContactos_I(en.Cliente.IdCliente, codigoContacto, drNuevos("NombreContacto").ToString(),
                                                      drNuevos("Direccion").ToString(), Integer.Parse(drNuevos("IdLocalidad").ToString()),
                                                      drNuevos("Telefono").ToString(), drNuevos("CorreoElectronico").ToString(),
                                                      drNuevos("Celular").ToString(), drNuevos("Observacion").ToString(),
                                                      Boolean.Parse(drNuevos("Activo").ToString()), drNuevos("IdUsuario").ToString(),
                                                      Integer.Parse(drNuevos("IdTipoContacto").ToString()))
                  codigoContacto += 1
               Next
            End If
            'sql.ClientesDeudas_U(en.Partida, en.IdTipoImpuesto, en.IdMunicipio, en.Periodo, en.Deuda, en.FechaCobro, en.FechaPago, _
            '             en.ImporteAproximado, en.ImporteCobrado, en.DarDeBaja, en.FechaActualizadoAl,
            '             DateTime.Now, en.FechaCarta1, en.FechaCarta2, en.FechaCarta3, en.FechaLiquidacion, en.Importa)



            'Actualiza la cuota en la Acuerdos De Pagos, si es que hay una (le coloca Fecha de Cobro)
            'If en.ImporteCobrado > 0 Then
            '   Dim sqlD As New SqlServer.AcuerdosDetalles(Me.da)
            '   Dim idPromesaDePago As Long
            '   ' idPromesaDePago = sqlD.AcuerdosDetalles_U(en.Cuenta, en.IdTipoImpuesto, en.IdMunicipio, en.Periodo, en.FechaCobro)

            '   If idPromesaDePago > 0 Then
            '      'Aca controlar si el acuerdo esta CUMPLIDO!!!
            '      '   sqlD.ControlarCumplida(idPromesaDePago, en.Cuenta, en.IdTipoImpuesto, en.IdMunicipio)
            '   Else
            '      'No encontro promesa de Pago activa con esta cuota.
            '   End If
            'End If

         Case TipoSP._D
            sql.ClientesDeudas_D(en.IdCliente, en.nro_prestamo)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.ClienteDeuda, dr As DataRow)
      With o
         .Cliente = New Reglas.Clientes().GetUno(Long.Parse(dr(Entidades.ClienteDeuda.Columnas.IdCliente.ToString()).ToString()))
         .nro_prestamo = Long.Parse(dr(Entidades.ClienteDeuda.Columnas.nro_prestamo.ToString()).ToString())
         .fecha_corte = DateTime.Parse(dr(Entidades.ClienteDeuda.Columnas.fecha_corte.ToString()).ToString())
         .tipo_cobro = dr(Entidades.ClienteDeuda.Columnas.tipo_cobro.ToString()).ToString()
         .convenio = dr(Entidades.ClienteDeuda.Columnas.convenio.ToString()).ToString()
         .linea = dr(Entidades.ClienteDeuda.Columnas.linea.ToString()).ToString()
         .fecha_emision = DateTime.Parse(dr(Entidades.ClienteDeuda.Columnas.fecha_emision.ToString()).ToString())
         .cantidad_cuotas = Integer.Parse(dr(Entidades.ClienteDeuda.Columnas.cantidad_cuotas.ToString()).ToString())
         .cuotas_pagas = Integer.Parse(dr(Entidades.ClienteDeuda.Columnas.cuotas_pagas.ToString()).ToString())
         .cuotas_adeudadas = Integer.Parse(dr(Entidades.ClienteDeuda.Columnas.cuotas_adeudadas.ToString()).ToString())
         .capital_total = Decimal.Parse(dr(Entidades.ClienteDeuda.Columnas.capital_total.ToString()).ToString())
         .deuda_exigible = Decimal.Parse(dr(Entidades.ClienteDeuda.Columnas.deuda_exigible.ToString()).ToString())
         .deuda_exigible_con_quita = Decimal.Parse(dr(Entidades.ClienteDeuda.Columnas.deuda_exigible_con_quita.ToString()).ToString())
         .empresa = dr(Entidades.ClienteDeuda.Columnas.empresa.ToString()).ToString()
         .dias_mora = Integer.Parse(dr(Entidades.ClienteDeuda.Columnas.dias_mora.ToString()).ToString())
         .fecha_ult_cobranza = DateTime.Parse(dr(Entidades.ClienteDeuda.Columnas.fecha_ult_cobranza.ToString()).ToString())
         .vendedor = dr(Entidades.ClienteDeuda.Columnas.vendedor.ToString()).ToString()
         .monto_cuota = Decimal.Parse(dr(Entidades.ClienteDeuda.Columnas.monto_cuota.ToString()).ToString())
         'ImporteAproximado
         If Not String.IsNullOrEmpty(dr(Entidades.ClienteDeuda.Columnas.ImporteAcordado.ToString()).ToString()) Then
            .ImporteAcordado = Decimal.Parse(dr(Entidades.ClienteDeuda.Columnas.ImporteAcordado.ToString()).ToString())
         End If
         'FechaCarta1
         If Not String.IsNullOrEmpty(dr(Entidades.ClienteDeuda.Columnas.FechaCarta1.ToString()).ToString()) Then
            .FechaCarta1 = DateTime.Parse(dr(Entidades.ClienteDeuda.Columnas.FechaCarta1.ToString()).ToString())
         End If
         'FechaCarta2
         If Not String.IsNullOrEmpty(dr(Entidades.ClienteDeuda.Columnas.FechaCarta2.ToString()).ToString()) Then
            .FechaCarta2 = DateTime.Parse(dr(Entidades.ClienteDeuda.Columnas.FechaCarta2.ToString()).ToString())
         End If
         'FechaLiquidacion
         If Not String.IsNullOrEmpty(dr(Entidades.ClienteDeuda.Columnas.FechaLiquidacion.ToString()).ToString()) Then
            .FechaLiquidacion = DateTime.Parse(dr(Entidades.ClienteDeuda.Columnas.FechaLiquidacion.ToString()).ToString())
         End If

         If Not String.IsNullOrEmpty(dr(Entidades.ClienteDeuda.Columnas.IdSucursal.ToString()).ToString()) Then
            .IdSucursal = Decimal.Parse(dr(Entidades.ClienteDeuda.Columnas.IdSucursal.ToString()).ToString())
         End If

         If Not String.IsNullOrEmpty(dr(Entidades.ClienteDeuda.Columnas.IdTipoComprobante.ToString()).ToString()) Then
            .TipoComprobante = New Reglas.TiposComprobantes().GetUno(dr(Entidades.ClienteDeuda.Columnas.IdTipoComprobante.ToString()).ToString())
         End If

         If Not String.IsNullOrEmpty(dr(Entidades.ClienteDeuda.Columnas.Letra.ToString()).ToString()) Then
            .Letra = dr(Entidades.ClienteDeuda.Columnas.Letra.ToString()).ToString()
         End If

         If Not String.IsNullOrEmpty(dr(Entidades.ClienteDeuda.Columnas.CentroEmisor.ToString()).ToString()) Then
            .CentroEmisor = Integer.Parse(dr(Entidades.ClienteDeuda.Columnas.CentroEmisor.ToString()).ToString())
         End If

         If Not String.IsNullOrEmpty(dr(Entidades.ClienteDeuda.Columnas.NumeroComprobante.ToString()).ToString()) Then
            .NumeroComprobante = Long.Parse(dr(Entidades.ClienteDeuda.Columnas.NumeroComprobante.ToString()).ToString())
         End If

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.ClienteDeuda)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ClienteDeuda
      Dim oLis As List(Of Entidades.ClienteDeuda) = New List(Of Entidades.ClienteDeuda)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ClienteDeuda()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(IdCliente As Long, NroPrestamo As Integer) As Entidades.ClienteDeuda
      Dim sql As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)

      Dim dt As DataTable = sql.ClientesDeudas_G1(IdCliente, NroPrestamo)

      Dim o As Entidades.ClienteDeuda = New Entidades.ClienteDeuda()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la Deuda.")
      End If
      Return o
   End Function

   Public Function GetDeuda(Cuenta As Long, IdTipoImpuesto As Integer, IdMunicipio As Integer, Periodo As String) As DataTable
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()
         Return New SqlServer.ClientesDeudas(da).ClientesDeudas_GetDeuda(Cuenta, IdTipoImpuesto, IdMunicipio, Periodo)
         Me.da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Function

   Public Function GetDeudas() As DataTable
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()
         Return New SqlServer.ClientesDeudas(da).ClientesDeudas_GetDeudas()
         Me.da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Function

   Public Function GetDeudaExportacion(FechaDesde As Date, FechaHasta As Date,
                              IdTipoImpuesto As Integer, IdMunicipio As Integer,
                              Titular As String) As DataTable
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()
         Return New SqlServer.ClientesDeudas(da).ClientesDeudas_GetDeudaExportacion(FechaDesde, FechaHasta, IdTipoImpuesto, IdMunicipio,
                                                                            Titular)
         Me.da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Function

   'Public Function GetMultaxDeuda(IdOrigen As String, NumeroActa As Integer) As DataTable
   '   Try
   '      Me.da.OpenConection()
   '      Me.da.BeginTransaction()
   '      '    Return New SqlServer.ClientesDeudas(da).ClientesDeudas_GetMultaxPago(IdOrigen, NumeroActa)
   '      Me.da.CommitTransaction()
   '   Catch ex As Exception
   '      da.RollbakTransaction()
   '      Throw ex
   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Function

   Public Sub ImportarClientesDeudas(IdSucursal As Integer,
                              datos As DataTable,
                              usuario As String,
                              ByRef BarraProg As System.Windows.Forms.ProgressBar)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim dt As DataTable = datos

         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes(da)
         Dim ExisteCliente As Boolean
         Dim Cliente As Entidades.Cliente = New Entidades.Cliente

         Dim oClientesDeudas As Eniac.Reglas.ClientesDeudas = New Eniac.Reglas.ClientesDeudas(da)
         Dim ExisteClienteDeuda As Boolean
         Dim TieneAcuerdoActivo As Boolean

         Dim Deuda As Entidades.ClienteDeuda = New Entidades.ClienteDeuda

         Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)

         Dim AnchoNombreCliente As Integer = New Reglas.Publicos().GetAnchoCampo("Clientes", "NombreCliente")
         Dim AnchoTelefono As Integer = New Reglas.Publicos().GetAnchoCampo("Clientes", "Telefono")

         Me.ChequeaEstructuraContactos()

         Dim i As Integer = 0

         BarraProg.Maximum = dt.Rows.Count
         BarraProg.Minimum = 0
         BarraProg.Value = 0
         Dim dr1 As DataRow

         oClientesDeudas.ActualizarPrestamosActivos(Date.Parse(dt.Rows(0).Item("fecha_corte").ToString()))

         For Each dr As DataRow In dt.Rows

            i += 1
            BarraProg.Value = i

            Me._contactos.Clear()

            If Boolean.Parse(dr("Importa").ToString()) Then

               ExisteCliente = oClientes.ExisteCodigo(Long.Parse(dr("CodigoCliente").ToString()))

               If ExisteCliente Then

                  Cliente = oClientes.GetUnoPorCodigo(Long.Parse(dr("CodigoCliente").ToString()), False, False)
               Else
                  Cliente.IdCliente = 0
                  Cliente.CodigoCliente = Long.Parse(dr("CodigoCliente").ToString.Trim())
               End If

               Cliente.IdCategoria = 1
               Cliente.CategoriaFiscal.IdCategoriaFiscal = 1
               Cliente.ZonaGeografica.IdZonaGeografica = "General"
               Cliente.IdListaPrecios = 0
               Cliente.Vendedor.IdEmpleado = 1

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

               If Not String.IsNullOrEmpty(dr("Telefono").ToString()) Then
                  dr1 = _contactos.NewRow()
                  dr1("IdCliente") = ""
                  Dim tipoCont As Entidades.TipoContacto = New Reglas.TiposContactos().GetUna(1)
                  dr1("IdTipoContacto") = tipoCont.IdTipoContacto
                  dr1("NombreTipoContacto") = tipoCont.NombreTipoContacto
                  dr1("Activo") = True
                  dr1("NombreContacto") = "."
                  dr1("Telefono") = dr("Telefono").ToString().Trim()
                  dr1("Celular") = ""
                  dr1("CorreoElectronico") = ""
                  dr1("Direccion") = "."
                  dr1("IdLocalidad") = 2000
                  dr1("NombreLocalidad") = "Rosario"
                  dr1("NombreProvincia") = "Santa Fe"
                  dr1("Observacion") = ""
                  dr1("IdUsuario") = actual.Nombre

                  Me._contactos.Rows.Add(dr1)
               End If


               Cliente.CorreoElectronico = dr("CorreoElectronico").ToString()

               If Not String.IsNullOrEmpty(dr("Celular").ToString()) Then
                  dr1 = _contactos.NewRow()
                  dr1("IdCliente") = ""
                  Dim tipoCont As Entidades.TipoContacto = New Reglas.TiposContactos().GetUna(2)
                  dr1("IdTipoContacto") = tipoCont.IdTipoContacto
                  dr1("NombreTipoContacto") = tipoCont.NombreTipoContacto
                  dr1("Activo") = True
                  dr1("NombreContacto") = "."
                  dr1("Telefono") = dr("Celular").ToString().Trim()
                  dr1("Celular") = ""
                  dr1("CorreoElectronico") = ""
                  dr1("Direccion") = "."
                  dr1("IdLocalidad") = 2000
                  dr1("NombreLocalidad") = "Rosario"
                  dr1("NombreProvincia") = "Santa Fe"
                  dr1("Observacion") = ""
                  dr1("IdUsuario") = actual.Nombre

                  Me._contactos.Rows.Add(dr1)
               End If


               If Not String.IsNullOrEmpty(dr("TelefonoLaboral").ToString()) Then
                  dr1 = _contactos.NewRow()
                  dr1("IdCliente") = ""
                  Dim tipoCont As Entidades.TipoContacto = New Reglas.TiposContactos().GetUna(1)
                  dr1("IdTipoContacto") = tipoCont.IdTipoContacto
                  dr1("NombreTipoContacto") = tipoCont.NombreTipoContacto
                  dr1("Activo") = True
                  dr1("NombreContacto") = "."
                  dr1("Telefono") = dr("TelefonoLaboral").ToString().Trim()
                  dr1("Celular") = ""
                  dr1("CorreoElectronico") = ""
                  dr1("Direccion") = "."
                  dr1("IdLocalidad") = 2000
                  dr1("NombreLocalidad") = "Rosario"
                  dr1("NombreProvincia") = "Santa Fe"
                  dr1("Observacion") = ""
                  dr1("IdUsuario") = actual.Nombre

                  Me._contactos.Rows.Add(dr1)
               End If

               Cliente.Usuario = usuario

               If Not String.IsNullOrEmpty(Strings.Trim(dr("CUIT").ToString.Trim())) Then
                  Cliente.Cuit = Strings.Trim(dr("CUIT").ToString.Trim()).Replace("-", "")
               Else
                  Cliente.Cuit = String.Empty
               End If

               Cliente.Observacion = dr("Observacion").ToString()

               If Not ExisteCliente Then

                  Cliente.IdSucursal = IdSucursal
                  Cliente.Activo = True
                  Cliente.FechaNacimiento = Date.Now
                  Cliente.NroOperacion = 0
                  Cliente.NombreTrabajo = ""
                  Cliente.DireccionTrabajo = ""
                  Cliente.IdLocalidadTrabajo = 0
                  '  Cliente.TelefonoTrabajo = ""
                  Cliente.CorreoTrabajo = ""
                  Cliente.FechaIngresoTrabajo = Date.Now
                  Cliente.FechaAlta = Date.Now
                  Cliente.SaldoPendiente = 0
                  Cliente.TipoDocumentoGarante = ""
                  Cliente.IdClienteGarante = 0
                  Cliente.LimiteDeCredito = 0
                  Cliente.SaldoLimiteDeCredito = 0
                  Cliente.IdSucursalAsociada = 0
                  Cliente.NombreDeFantasia = ""
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
                  Cliente.Cobrador.IdEmpleado = 1

                  Cliente.TipoCliente.IdTipoCliente = 1
                  '-----------------------------
                  Cliente.DadoAltaPor = New Reglas.Empleados().GetUno(1)
                  Cliente.UsaArchivoAImprimir2 = False
                  Cliente.CantidadVisitas = 0
                  Cliente.Contactos = _contactos

                  Me._codigo = Cliente.CodigoCliente

                  oClientes.Inserta(Cliente)
               Else
                  ' oClientes.ActualizarObservacion(Cliente.IdCliente, Cliente.Observacion)
               End If

               ExisteClienteDeuda = oClientesDeudas.ExisteCodigo(Cliente.IdCliente, Long.Parse(dr("nro_prestamo").ToString.Trim()))

               If ExisteClienteDeuda Then
                  oClientesDeudas.ActualizarMontoCuota(Cliente.IdCliente, Long.Parse(dr("nro_prestamo").ToString.Trim()), dr("monto_cuota").ToString())
                  TieneAcuerdoActivo = oClientesDeudas.TieneAcuerdoActivo(Cliente.IdCliente, Long.Parse(dr("nro_prestamo").ToString.Trim()))

                  Dim Fecha As Date = Nothing

                  If Not String.IsNullOrEmpty(dr("fecha_ult_cobranza").ToString()) Then
                     Fecha = Date.Parse(dr("fecha_ult_cobranza").ToString())
                  End If

                  If Not TieneAcuerdoActivo Then
                     oClientesDeudas.ActualizarDatos(Cliente.IdCliente, Long.Parse(dr("nro_prestamo").ToString.Trim()), Integer.Parse(dr("cuotas_pagas").ToString()),
                                                    Integer.Parse(dr("cuotas_adeudadas").ToString()), Decimal.Parse(dr("deuda_exigible").ToString()),
                                                    Fecha, Integer.Parse(dr("dias_mora").ToString()),
                                                    Decimal.Parse(dr("deuda_exigible_con_quita").ToString()))

                  End If

               Else
                  Deuda.IdCliente = Cliente.IdCliente
                  Deuda.nro_prestamo = Long.Parse(dr("nro_prestamo").ToString.Trim())
                  Deuda.fecha_corte = Date.Parse(dr("fecha_corte").ToString())
                  Deuda.tipo_cobro = dr("tipo_cobro").ToString()
                  Deuda.convenio = dr("convenio").ToString()
                  Deuda.linea = dr("linea").ToString()
                  If Not String.IsNullOrEmpty(dr("fecha_emision").ToString()) Then
                     Deuda.fecha_emision = Date.Parse(dr("fecha_emision").ToString())
                  End If
                  Deuda.cantidad_cuotas = Integer.Parse(dr("cantidad_cuotas").ToString())
                  Deuda.cuotas_pagas = Integer.Parse(dr("cuotas_pagas").ToString())
                  Deuda.cuotas_adeudadas = Integer.Parse(dr("cuotas_adeudadas").ToString())
                  Deuda.capital_total = Decimal.Parse(dr("capital_total").ToString())
                  Deuda.deuda_exigible = Decimal.Parse(dr("deuda_exigible").ToString())
                  If Not String.IsNullOrEmpty(dr("fecha_ult_cobranza").ToString()) Then
                     Deuda.fecha_ult_cobranza = Date.Parse(dr("fecha_ult_cobranza").ToString())
                  End If
                  Deuda.dias_mora = Integer.Parse(dr("dias_mora").ToString())
                  Deuda.deuda_exigible_con_quita = Decimal.Parse(dr("deuda_exigible_con_quita").ToString())
                  Deuda.empresa = dr("empresa").ToString()
                  Deuda.vendedor = dr("vendedor").ToString()
                  Deuda.monto_cuota = Decimal.Parse(dr("monto_cuota").ToString())
                  Deuda.Activo = True
                  oClientesDeudas.Inserta(Deuda)
               End If



            End If
         Next

         da.CommitTransaction()

      Catch ex As Exception
         BarraProg.Value = 0
         da.RollbakTransaction()
         Throw New Exception(ex.Message & "  " & _codigo)
      Finally
         da.CloseConection()
      End Try

   End Sub

   'Public Sub GrabarClientesDeudas(IdSucursal As Integer,
   '                            datos As DataTable,
   '                            usuario As String,
   '                            ByRef BarraProg As System.Windows.Forms.ProgressBar)
   '   Try

   '      Me.da.OpenConection()
   '      Me.da.BeginTransaction()
   '      Dim sql As SqlServer.Clientes = New SqlServer.Clientes(Me.da, ModoClienteProspecto)
   '      Dim sql2 As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)

   '      Dim i As Integer = 0

   '      BarraProg.Maximum = datos.Rows.Count
   '      BarraProg.Minimum = 0
   '      BarraProg.Value = 0

   '      For Each Deuda As DataRow In datos.Rows
   '         i += 1
   '         BarraProg.Value = i


   '         If Deuda("Accion") = "A" Then

   '            'sql.Clientes_I()

   '            'sql.ClientesDeudas_I(Deuda.Partida,
   '            '             Deuda.IdTipoImpuesto,
   '            '             Deuda.IdMunicipio,
   '            '             Deuda.Periodo, Deuda.Deuda)

   '         Else
   '            'sql.ClientesDeudas_U(Deuda.Cuenta,
   '            '             Deuda.IdTipoImpuesto,
   '            '             Deuda.IdMunicipio,
   '            '             Deuda.Periodo,
   '            '             Deuda.Actualizacion1, Deuda.Importe1, Deuda.Actualizacion2, Deuda.Importe2,
   '            '             Deuda.Actualizacion3, Deuda.Importe3, Deuda.Actualizacion4, Deuda.Importe4,
   '            '             Deuda.Actualizacion5, Deuda.Importe5, Deuda.Actualizacion6, Deuda.Importe6,
   '            '             Deuda.Actualizacion7, Deuda.Importe7, Deuda.Actualizacion8, Deuda.Importe8,
   '            '             Deuda.Actualizacion9, Deuda.Importe9, Deuda.Actualizacion10, Deuda.Importe10,
   '            '             Deuda.Actualizacion11, Deuda.Importe11, Deuda.Actualizacion12, Deuda.Importe1,
   '            '             Deuda.FechaCobro, Deuda.FechaPago, Deuda.ImporteAproximado, Deuda.ImporteCobrado,
   '            '             Deuda.DarDeBaja, Deuda.FechaActualizadoAl, Deuda.FechaUltimaModificacion,
   '            '             Deuda.FechaCarta1, Deuda.FechaCarta2, Deuda.FechaCarta3, Deuda.FechaLiquidacion, Deuda.Importa)

   '         End If
   '      Next

   '      Me.da.CommitTransaction()

   '   Catch ex As Exception
   '      BarraProg.Value = 0
   '      da.RollbakTransaction()
   '      Throw ex
   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Sub

   Public Sub ActualizaInformeClientesDeudas(ClientesDeudas As List(Of Entidades.ClienteDeuda))
      '   Try

      '      Me.da.OpenConection()
      '      Me.da.BeginTransaction()
      '      Dim sqlDe As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)
      '      Dim ImporteClientesDeudas As DataTable
      '      Dim sqlAl As SqlServer.AlertasCuentas = New SqlServer.AlertasCuentas(Me.da)
      '      For Each deuda As Entidades.ClienteDeuda In ClientesDeudas
      '         sqlDe.ClientesDeudas_UInforme(deuda.Partida, deuda.IdTipoImpuesto, deuda.IdMunicipio, deuda.Periodo,
      '                               deuda.ImporteCobrado, deuda.FechaPago)

      '         'Controla si la deuda es 0 desactiva las alertas
      '         ImporteClientesDeudas = sqlDe.ClientesDeudas_GTotalDeuda(deuda.Partida, deuda.IdTipoImpuesto, deuda.IdMunicipio)

      '         If ImporteClientesDeudas.Rows.Count = 0 Then

      '            Dim dtA As DataTable = sqlAl.AlertasCuentas_GDeUnaCuentaActivas(deuda.Partida, deuda.IdTipoImpuesto, deuda.IdMunicipio)
      '            For Each drA As DataRow In dtA.Rows
      '               If drA("MotivoAlerta").ToString().Length >= 12 Then
      '                  If Not Boolean.Parse(drA("Desactivar").ToString()) Then
      '                     sqlAl.AlertasCuentas_UDesactivar(Long.Parse(drA("IdAlerta").ToString()))
      '                  End If
      '               End If
      '            Next
      '         End If

      '         'Dim sqlD As New SqlServer.AcuerdosDetalles(Me.da)
      '         'Dim idPromesaDePago As Long
      '         'idPromesaDePago = sqlD.AcuerdosDetalles_U(deuda.Partida, deuda.IdTipoImpuesto, deuda.IdMunicipio, deuda.Periodo, deuda.FechaPago)

      '         'If idPromesaDePago > 0 Then
      '         '   'Aca controlar si el acuerdo esta CUMPLIDO!!!
      '         '   sqlD.ControlarCumplida(idPromesaDePago, deuda.Partida, deuda.IdTipoImpuesto, deuda.IdMunicipio)
      '         'End If

      '      Next

      '      Me.da.CommitTransaction()

      '   Catch ex As Exception
      '      da.RollbakTransaction()
      '      Throw ex
      '   Finally
      '      da.CloseConection()
      '   End Try
   End Sub

   Public Function ConsultarClientesDeudas(IdTipoImpuesto As Integer, IdMunicipio As Integer, Pagos As String, FechaPagoDesde As Date,
                              FechaPagoHasta As Date) As DataTable
      Try

         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim Deuda As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(da)
         Return Deuda.GetClientesDeudas(IdTipoImpuesto, IdMunicipio, Pagos, FechaPagoDesde, FechaPagoHasta)

         Me.da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Function

   Public Function GetTotalDeuda(IdCliente As Long) As List(Of Entidades.ClienteDeuda)
      Dim sql As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)
      Dim dt As DataTable = sql.ClientesDeudas_GTotalDeuda(IdCliente)
      Dim o As Entidades.ClienteDeuda
      Dim oLis As List(Of Entidades.ClienteDeuda) = New List(Of Entidades.ClienteDeuda)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ClienteDeuda()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function _GetTotalDeuda(IdCliente As Long) As DataTable
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)
         Dim dt As DataTable = sql.ClientesDeudas_GTotalDeuda(IdCliente)

         Return dt

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Function

   Public Function _GetPendientes(IdCliente As Long) As DataTable
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)
         Dim dt As DataTable = sql.ClientesDeudas_GPendientes(IdCliente)

         Return dt

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Function
   'Public Function ConsultarClientesDeudasCartas(FechaDesde As Date, FechaHasta As Date, Origen As String, _
   '                         NroActa As Integer, Rebeldia As Integer, Dominio As String,
   '                         Infractor As String) As DataTable
   '   Try

   '      Me.da.OpenConection()
   '      Me.da.BeginTransaction()

   '      Dim mul As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(da)
   '      '   Return mul.GetClientesDeudasCartas(FechaDesde, FechaHasta, Origen, NroActa, Rebeldia, Dominio, Infractor)

   '      Me.da.CommitTransaction()

   '   Catch ex As Exception
   '      da.RollbakTransaction()
   '      Throw ex
   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Function

   Public Function GetDeUnPrestamo(IdCliente As Long,
                  NroPrestamo As Long) As List(Of Entidades.ClienteDeuda)
      Dim sql As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)
      Dim dt As DataTable = sql.ClientesDeudas_GDesdePrestamo(IdCliente, NroPrestamo)
      Dim o As Entidades.ClienteDeuda
      Dim oLis As List(Of Entidades.ClienteDeuda) = New List(Of Entidades.ClienteDeuda)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ClienteDeuda()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function Existe(Cuenta As Long, IdTipoImpuesto As Integer,
                  IdMunicipio As Integer, Periodo As String) As Long

      Try
         'Me.da.OpenConection()

         Dim sql As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)

         Return sql.ClientesDeudas_Existe(Cuenta, IdTipoImpuesto, IdMunicipio, Periodo)

      Catch ex As Exception
         Throw
      Finally
         'Me.da.CloseConection()
      End Try

   End Function

   'Public Function GetPeriodosDeDeuda(Localidad As Integer) As DataTable

   '   'Dim sql As SqlServer.Pagos = New SqlServer.Pagos(Me.da)

   '   'Return sql.Pagos_GPeriodosDeDeuda(Localidad)

   'End Function

   'Public Function GetPrimerPeriodoPendiente(Cuenta As Long, IdTipoImpuesto As Integer, _
   '               IdMunicipio As Integer) As String
   '   Try
   '      Me.da.OpenConection()
   '      Dim ret As String = "No existe Periodo pendiente de Cobro."
   '      '  Dim sql As SqlServer.Pagos = New SqlServer.Pagos(Me.da)
   '      '   Dim dt As DataTable = sql.Pagos_GPeriodosPendientes(Cuenta)

   '      'If dt.Rows.Count > 0 Then
   '      '   Dim dr As DataRow = dt.Rows(0)

   '      'If Not String.IsNullOrEmpty(dr(Entidades.Pago.Columnas.Periodo.ToString()).ToString()) Then
   '      '   ret = dr(Entidades.Pago.Columnas.Periodo.ToString()).ToString()
   '      'End If

   '      'Return ret
   '      'Else
   '      'Throw New Exception("No existe Periodo pendiente de Cobro.")
   '      'End If

   '   Catch ex As Exception
   '      Throw
   '   Finally
   '      Me.da.CloseConection()
   '   End Try
   'End Function

   Public Sub EliminarPagos(Cuenta As Long,
                  IdTipoImpuesto As Integer,
                  IdMunicipio As Integer,
                  Periodo As String)

      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)

         sql.ClientesDeudas_DPagos(Cuenta, IdTipoImpuesto, IdMunicipio, Periodo)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Sub

   Private Sub ChequeaEstructuraContactos()
      If Me._contactos Is Nothing Then
         Me._contactos = New DataTable()
         If ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Prospecto Then
            Me._contactos.Columns.Add("IdProspecto", System.Type.GetType("System.String"))
         Else
            Me._contactos.Columns.Add("IdCliente", System.Type.GetType("System.String"))
         End If
         Me._contactos.Columns.Add("IdTipoContacto", System.Type.GetType("System.Int32"))
         Me._contactos.Columns.Add("NombreTipoContacto", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("IdContacto", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("NombreContacto", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Telefono", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Celular", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Observacion", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("CorreoElectronico", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Direccion", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("IdLocalidad", System.Type.GetType("System.Int32"))
         Me._contactos.Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("NombreProvincia", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("Activo", System.Type.GetType("System.Boolean"))
         Me._contactos.Columns.Add("IdUsuario", System.Type.GetType("System.String"))
         Me._contactos.Columns.Add("EnUso", System.Type.GetType("System.Boolean"))
      End If

   End Sub

   Public Function ExisteCodigo(IdCliente As Long, NroPrestamo As Long) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendFormat("SELECT COUNT(IdCliente) AS Existe FROM ClientesDeudas WHERE IdCLiente = {0} AND nro_prestamo = {1}", IdCliente, NroPrestamo)
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

   Public Function TieneAcuerdoActivo(IdCliente As Long, NroPrestamo As Long) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendFormat("SELECT COUNT(IdCliente) AS Existe FROM ClientesDeudas WHERE IdCLiente = {0} AND nro_prestamo = {1} AND ImporteAcordado is not null ", IdCliente, NroPrestamo)
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Return Integer.Parse(dt.Rows(0)("Existe").ToString()) > 0
   End Function

   Public Sub ActualizarDatos(idCliente As Long, NroPrestamo As Long, cuotas_pagas As Integer, cuotas_adeudadas As Integer,
                              deuda_exigible As Decimal, fecha_ult_cobranza As Date, dias_mora As Integer, deuda_exigible_con_quita As Decimal)
      Try

         Dim cli As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)

         cli.ActualizarDatos(idCliente, NroPrestamo, cuotas_pagas, cuotas_adeudadas, deuda_exigible, fecha_ult_cobranza, dias_mora, deuda_exigible_con_quita)

      Catch ex As Exception
         Throw ex
      End Try

   End Sub

   Public Sub ActualizarPrestamosActivos(Fecha_corte As Date)
      Try

         Dim cli As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)

         cli.ActualizarPrestamosActivos(Fecha_corte)

      Catch ex As Exception
         Throw ex
      End Try

   End Sub

   Public Sub ActualizarMontoCuota(idCliente As Long, NroPrestamo As Long, monto_cuota As Decimal)
      Try

         Dim cli As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)

         cli.ActualizarMontoCuota(idCliente, NroPrestamo, monto_cuota)

      Catch ex As Exception
         Throw ex
      End Try

   End Sub

   Public Sub ActualizarDatosCtaCte(CC As Entidades.CuentaCorriente)
      Try

         Dim cli As SqlServer.ClientesDeudas = New SqlServer.ClientesDeudas(Me.da)

         cli.ClientesDeudas_UCtaCteEliminacion(CC)

      Catch ex As Exception
         Throw ex
      End Try

   End Sub

#End Region

End Class
