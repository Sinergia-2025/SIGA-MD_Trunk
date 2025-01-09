Imports Eniac.Datos.DataAccess

Public Class Parametros
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.Parametro.NombreTabla
      If accesoDatos Is Nothing Then
         da = New Datos.DataAccess()
      Else
         da = accesoDatos
      End If
   End Sub

#End Region

#Region "Overrides/Overloads"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Parametro)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Parametro)))
   End Sub
   Public Overloads Sub Actualizar(entidades As List(Of Entidades.Parametro))
      EjecutaConTransaccion(Sub() _Actualizar(entidades))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Parametro)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Parametros(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Parametros(da).Parametros_GA(actual.Sucursal.IdEmpresa)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.Parametro, tipo As TipoSP)
      Dim sql As SqlServer.Parametros = New SqlServer.Parametros(da)

      Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
      Dim OperacAudit As Entidades.OperacionesAuditorias
      Dim clavePrimariaAuditoria As String = String.Format("{0} = {1} AND {2} = '{3}'",
                                                           Entidades.Parametro.Columnas.IdEmpresa.ToString(), en.IdEmpresa,
                                                           Entidades.Parametro.Columnas.IdParametro.ToString(), en.IdParametro)

      If tipo = TipoSP._I Or tipo = TipoSP._U Then
         If sql.Existe(en.IdEmpresa, en.IdParametro) Then
            sql.Parametros_U(en.IdEmpresa, en.IdParametro, en.ValorParametro, en.CategoriaParametro, en.DescripcionParametro, en.UbicacionParametro)
            OperacAudit = rAudit.OperacionSegunAuditoria(Entidades.Parametro.NombreTabla, clavePrimariaAuditoria)

         Else
            sql.Parametros_I(en.IdEmpresa, en.IdParametro, en.ValorParametro, en.CategoriaParametro, en.DescripcionParametro, en.UbicacionParametro)
            OperacAudit = Entidades.OperacionesAuditorias.Alta

         End If
      ElseIf tipo = TipoSP._D Then
         sql.Parametros_D(en.IdEmpresa, en.IdParametro)
         OperacAudit = Entidades.OperacionesAuditorias.Baja

      End If

      rAudit.Insertar(Entidades.Parametro.NombreTabla, OperacAudit, actual.Nombre, clavePrimariaAuditoria, conMilisegundos:=False)

   End Sub

#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.Parametro)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Parametro)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Actualizar(entidades As List(Of Entidades.Parametro))
      For Each ent In entidades
         _Actualizar(ent)
      Next
   End Sub
   Public Sub _Borrar(entidad As Entidades.Parametro)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetPorCodigoEntidades(idEmpresa As Integer, idParametro As Entidades.Parametro.Parametros) As List(Of Entidades.Parametro)
      Return CargaLista(GetPorCodigo(idEmpresa, idParametro.ToString()),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Parametro())
   End Function

   Public Function GetPorCodigo(idEmpresa As Integer, idParametro As Entidades.Parametro.Parametros) As DataTable
      Return GetPorCodigo(idEmpresa, idParametro.ToString())
   End Function

   Public Function GetPorCodigo(idEmpresa As Integer, idParametro As String) As DataTable
      Dim dtResult As DataTable = New SqlServer.Parametros(da).Parametros_GA(idEmpresa, idParametro, True)
      If dtResult.Rows.Count = 0 Then
         dtResult = New SqlServer.Parametros(da).Parametros_GA(idEmpresa, idParametro, False)
      End If
      Return dtResult
   End Function

   'GET POR NOMBRE
   Public Function GetPorNombre(idEmpresa As Integer, idParametro As String) As DataTable
      Return New SqlServer.Parametros(da).Parametros_GA(idEmpresa, idParametro)
   End Function

   Private Sub CargarUno(o As Entidades.Parametro, dr As DataRow)
      o.IdEmpresa = dr.Field(Of Integer)("IdEmpresa")
      o.IdParametro = dr.Field(Of String)("IdParametro")
      o.ValorParametro = dr.Field(Of String)("ValorParametro")
      o.DescripcionParametro = dr.Field(Of String)("DescripcionParametro")
      o.CategoriaParametro = dr.Field(Of String)("CategoriaParametro")
      o.UbicacionParametro = dr.Field(Of String)("UbicacionParametro")
   End Sub

   Public Function GetUno(idEmpresa As Integer, idParametro As String, acciones As AccionesSiNoExisteRegistro) As Entidades.Parametro
      Return CargaEntidad(New SqlServer.Parametros(da).Parametros_G1(idEmpresa, idParametro),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Parametro(),
                          acciones, Function() String.Format("No se encontró el parámetro {0}", idParametro))
   End Function
   Public Function GetTodos(idEmpresa As Integer, idParametros As IEnumerable(Of String)) As IEnumerable(Of Entidades.Parametro)
      Return CargaLista(New SqlServer.Parametros(da).Parametros_GA(idEmpresa, idParametros),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Parametro())
   End Function


   <Obsolete("Por favor no utilizar. Se eliminará el método. Usar GetValorPD.", False)>
   Public Overloads Function _GetValor(idParametro As Entidades.Parametro.Parametros) As String
      Return _GetValor(idParametro.ToString())
   End Function

   <Obsolete("Por favor no utilizar. Se eliminará el método. Usar GetValorPD.", False)>
   Public Overloads Function GetValor(idParametro As Entidades.Parametro.Parametros) As String
      Try
         da.OpenConection()
         Return _GetValor(idParametro)
      Catch ex As Exception
         Throw
      Finally
         da.CloseConection()
      End Try
   End Function

   <Obsolete("Por favor no utilizar. Se eliminará el método. Usar GetValorPD.", False)>
   Public Overloads Function _GetValor(idParametro As String) As String
      Dim sql As SqlServer.Parametros = New SqlServer.Parametros(da)
      Return sql.GetValor(actual.Sucursal.IdEmpresa, idParametro)
   End Function

   <Obsolete("Por favor no utilizar. Se eliminará el método. Usar GetValorPD.", False)>
   Public Overloads Function GetValor(idParametro As String) As String
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Parametros = New SqlServer.Parametros(da)
         Return sql.GetValor(actual.Sucursal.IdEmpresa, idParametro)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   <Obsolete("Por favor no utilizar. Se eliminó el método. Usar GetValorPD pasando String.Empty como valor por defecto.", True)>
   Public Function GetValor2(idParametro As String) As String
      Throw New NotImplementedException("Function GetValor2(String) As String - Se eliminó el método. Usar GetValorPD pasando String.Empty como valor por defecto.")
   End Function

   Public Overloads Function GetValorPD(idParametro As String, porDefecto As String) As String
      Return ParametrosCache.Instancia.GetValorPD(idParametro, porDefecto)
   End Function

   Public Overloads Function GetValorPD(idParametro As Entidades.Parametro.Parametros, porDefecto As String) As String
      Return ParametrosCache.Instancia.GetValorPD(idParametro, porDefecto)
   End Function
   Public Overloads Shared Function GetValorPD(Of T)(idParametro As Entidades.Parametro.Parametros, porDefecto As T) As T
      Return ParametrosCache.Instancia.GetValorPD(idParametro, porDefecto)
   End Function

   Public Sub SetValor(idEmpresa As Integer, idParametro As String, valorParametro As String, Optional ubicacionParametro As String = "")
      EjecutaConTransaccion(Sub() _SetValor(idEmpresa, idParametro, valorParametro, ubicacionParametro))
   End Sub

   Public Sub _SetValor(idEmpresa As Integer, idParametro As String, valorParametro As String, ubicacionParametro As String)
      Dim sql = New SqlServer.Parametros(da)
      sql.Parametros_M1(idEmpresa, idParametro, valorParametro, ubicacionParametro)
   End Sub

   Public Function GetSistema(idEmpresa As Integer) As Entidades.Sistema
      Return EjecutaConConexion(Function() _GetSistema(idEmpresa))
   End Function
   Public Function _GetSistema(idEmpresa As Integer) As Entidades.Sistema
      Dim sistema = New Entidades.Sistema()
      Dim parametro = ParametrosCache.Instancia.GetValorPD(idEmpresa, actual.Sucursal.Id, Entidades.Parametro.Parametros.VENCIMIENTOSISTEMA.ToString(), String.Empty)

      sistema.ClaveActual = parametro

      My.Application.Log.WriteEntry("Parametros - Obtengo parametro de fecha de vencimiento del sistema : " + parametro, TraceEventType.Verbose)
      parametro = New Ayudantes.Criptografia().DecryptString128Bit(parametro, "clave")
      Dim valores = parametro.Split(";"c)
      My.Application.Log.WriteEntry("Parametros - Obtengo fecha de la base.", TraceEventType.Verbose)
      Dim fechaServidor = New Generales(da)._GetServerDBFechaHora()
      My.Application.Log.WriteEntry("Parametros - Fecha de la base = " + fechaServidor.ToString(), TraceEventType.Verbose)
      My.Application.Log.WriteEntry("Parametros - Fecha de vencimiento = " + valores(0), TraceEventType.Verbose)

      Dim Fecha() As String = valores(0).Split("/"c)     'Por ahora !!, porque se pierde la configuracion regional y da error en la conversion de fechas
      'Tomo la fecha de vencimiento de la licencia
      sistema.FechaVencimiento = New DateTime(Integer.Parse(Fecha(2)), Integer.Parse(Fecha(1)), Integer.Parse(Fecha(0))) ''   DateTime.Parse(Fecha(2) & "-" & Fecha(1) & "-" & Fecha(0))
      'Tomo el nombre de la empresa de la licencia
      sistema.NombreEmpresa = valores(1)
      sistema.Habilitado = True

      'Si en la licencia hay 3 o más entradas, tomo la Cantidad de Empresas Contratadas de la tercer entrada (2), caso contrario asumo una sola contratada
      sistema.CantidadEmpresasContratadas = If(valores.Count > 2 AndAlso IsNumeric(valores(2)), Integer.Parse(valores(2)), 1)

      'Si no coincide el nombre de la empresa, la licencia es inválida
      If sistema.NombreEmpresa <> ParametrosCache.Instancia.GetValorPD(idEmpresa, actual.Sucursal.Id, Entidades.Parametro.Parametros.NOMBREEMPRESA.ToString(), String.Empty) Then
         sistema.Habilitado = False
         _SetValor(idEmpresa, Entidades.Parametro.Parametros.FACTURACIONUTILIZAMONEDADOLAR.ToString(), Boolean.TrueString, String.Empty)
         Return sistema
      End If
      My.Application.Log.WriteEntry("Parametros - Controlo fecha contra vencimiento del sistema.", TraceEventType.Verbose)
      'Si la fecha de vencimiento es 31/12/9999, significa que la licencia no tiene vencimiento
      If sistema.FechaVencimiento = New DateTime(9999, 12, 31) Then
         sistema.Habilitado = True
      Else
         'Si vence hoy o ya pasó la fecha de vencimiento, significa que la licencia está vencida
         If sistema.FechaVencimiento.Subtract(fechaServidor).Days <= 0 Then
            sistema.Habilitado = False
            _SetValor(idEmpresa, Entidades.Parametro.Parametros.FACTURACIONUTILIZAMONEDADOLAR.ToString(), Boolean.TrueString, String.Empty)
         End If
         'Me fijo en el parámetro DIASAVISOVENCIMIENTOSISTEMA, si quedan menos de esos días para que venza la licencia, le doy un AlertaAlCliente para que avise con tiempo antes de que se venza la licencia
         If sistema.FechaVencimiento.Subtract(fechaServidor).Days < Integer.Parse(ParametrosCache.Instancia.GetValorPD(idEmpresa, actual.Sucursal.Id, Entidades.Parametro.Parametros.DIASAVISOVENCIMIENTOSISTEMA.ToString(), "0")) Then
            sistema.AvisarAlCliente = True
         End If
      End If

         '-- REQ-41757.- ------------------------------------------------------------------------------------------------------------------------------------------
         'Si en la licencia 4 o más entradas, tomo la Cantidad de Depositos Contratados de la cuarta entrada (3), caso contrario asumo un solo deposito contratado
         If valores.Count > 3 Then
            For Each tipoDep In valores(3).Split("_"c)
               Dim tipoSplit = tipoDep.Split("="c)
               If tipoSplit.Length = 2 Then
                  Select Case tipoSplit(0)
                     Case "O"
                        sistema.CantidadDepositosTipoOperativo = tipoSplit(1).ValorNumericoPorDefecto(1I)
                     Case "R"
                        sistema.CantidadDepositosTipoReserva = tipoSplit(1).ValorNumericoPorDefecto(1I)
                     Case "T"
                        sistema.CantidadDepositosTipoEnTransito = tipoSplit(1).ValorNumericoPorDefecto(0I)
                     Case "D"
                        sistema.CantidadDepositosTipoDefectuoso = tipoSplit(1).ValorNumericoPorDefecto(0I)
                  End Select
               End If
            Next
         End If
         'Si en la licencia hay 5 o más entradas, tomo la Cantidad de Usuarios de la quinta entrada (4), caso contrario asumo un solo usuario contratado
         If valores.Count > 4 Then
            sistema.CantidadUsuariosContratados = Integer.Parse(valores(4).Split("="c)(1))
         Else
            sistema.CantidadUsuariosContratados = 1
         End If
         '----------------------------------------------------------------------------------------------------------------------------------------------------------

         If Not Publicos.UtilizaVencimientoSistema.Equals(Publicos.ValorDefaultParaUtilizaVencimientoSistema) Then
            sistema.Habilitado = False
         End If

      If Not Publicos.UtilizaVencimientoSistema.Equals(Publicos.ValorDefaultParaUtilizaVencimientoSistema) Then
         sistema.Habilitado = False
      End If

      Return sistema
   End Function

   Public Function GetParametrosDeOrganizarEntregasv2() As DataTable

      Dim sql As SqlServer.Parametros
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Parametros(da)

         dt = sql.GetParametrosDeOrganizarEntregasv2(actual.Sucursal.IdEmpresa)

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetMailGenerico() As Entidades.MailConfig

      Dim sql As SqlServer.Parametros
      Dim dt As DataTable
      Dim mcon As Entidades.MailConfig
      Try
         Me.da.OpenConection()
         mcon = New Entidades.MailConfig()

         sql = New SqlServer.Parametros(da)


         dt = sql.GetMailGenerico(actual.Sucursal.IdEmpresa, "'MAILUSUARIO','MAILSERVIDOR','MAILREQUIERESSL','MAILREQUIEREAUTENTICACION','MAILPUERTOSALIDA','MAILPASSWORD','MAILDIRECCION','CANTEMAILSPORMINUTO','CANTEMAILSPORHORA'")

         mcon = New Entidades.MailConfig()
         For Each dr As DataRow In dt.Rows
            Select Case dr("IdParametro").ToString()
               Case "MAILUSUARIO"
                  mcon.UsuarioMail = dr("ValorParametro").ToString()
               Case "MAILSERVIDOR"
                  mcon.ServidorSMTP = dr("ValorParametro").ToString()
               Case "MAILREQUIERESSL"
                  mcon.RequiereSSL = Boolean.Parse(dr("ValorParametro").ToString())
               Case "MAILREQUIEREAUTENTICACION"
                  mcon.RequiereAutenticacion = Boolean.Parse(dr("ValorParametro").ToString())
               Case "MAILPUERTOSALIDA"
                  mcon.PuertoSalida = Int32.Parse(dr("ValorParametro").ToString())
               Case "MAILPASSWORD"
                  mcon.Clave = dr("ValorParametro").ToString()
               Case "MAILDIRECCION"
                  mcon.Direccion = dr("ValorParametro").ToString()
               Case "CANTEMAILSPORMINUTO"
                  mcon.CantidadXMinuto = Int32.Parse(dr("ValorParametro").ToString())
               Case "CANTEMAILSPORHORA"
                  mcon.CantidadXHora = Int32.Parse(dr("ValorParametro").ToString())
               Case Else
            End Select
         Next

         Return mcon

      Catch
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function CopiarEntreEmpresas(idEmpresaOrigen As Integer, idEmpresaDestino As Integer) As Integer
      Return New SqlServer.Parametros(da).Parametros_M(idEmpresaOrigen, idEmpresaDestino)
   End Function

   Public Overloads Sub Borrar(idEmpresa As Integer)
      Dim sql As SqlServer.Parametros = New SqlServer.Parametros(da)
      sql.Parametros_D(idEmpresa, idParametro:=String.Empty)
   End Sub

   Public Function GetAuditoriasParametros(fechaDesde As Date,
                                           fechaHasta As Date,
                                           idParametro As String,
                                           tipoOperacion As String) As DataTable

      Return New SqlServer.Parametros(da).GetAuditoriasParametros(fechaDesde, fechaHasta, idParametro, tipoOperacion)

   End Function

#End Region

#Region "Metodos Publicos Convertir Parametros"
   Public Sub ConvertirParametros()
      EjecutaConTransaccion(
         Sub()
            Dim rEmpresas = New Empresas(da).GetTodos()
            rEmpresas.ForEach(Sub(e) ConvertirParametros(e.IdEmpresa))
         End Sub)
   End Sub
   Private Sub ConvertirParametros(idEmpresa As Integer)
      ConvertirParametroTieneModulo(idEmpresa)
   End Sub
   Private Sub ConvertirParametroTieneModulo(idEmpresa As Integer)
      If GetUno(idEmpresa, Entidades.Parametro.Parametros.TIENEMODULOS.ToString(), AccionesSiNoExisteRegistro.Nulo) Is Nothing Then
         Dim parms = New ParametrosModulos()

         Dim ps = GetTodos(idEmpresa,
                           {"MODULOFACTURACIONELECTRONICA", "MODULOCUENTACORRIENTECLIENTES", "MODULOCUENTACORRIENTEPROVEEDORES",
                            "MODULOCAJA", "MODULOBANCO", "MODULOPEDIDOS", "MODULOPEDIDOSPROV", "MODULOPRODUCCION", "MODULOCONTABILIDAD",
                            "MODULOCARGOS", "MODULOCONTROLDELICENCIAS", "MODULOFICHAS", "MODULOSUELDOS", "MODULOEXPENSAS",
                            "MODULOCONTRATISTAS", "MODULOALQUILER", "EXTRASSINERGIA"}).ToList()
         ps.ForEach(Sub(p)
                       Select Case p.IdParametro
                          Case "MODULOFACTURACIONELECTRONICA"
                             parms.TieneModuloFacturacionElectronica = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOCUENTACORRIENTECLIENTES"
                             parms.TieneModuloCuentaCorrienteClientes = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOCUENTACORRIENTEPROVEEDORES"
                             parms.TieneModuloCuentaCorrienteProveedores = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOCAJA"
                             parms.TieneModuloCaja = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOBANCO"
                             parms.TieneModuloBanco = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOPEDIDOS"
                             parms.TieneModuloPedidos = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOPEDIDOSPROV"
                             parms.TieneModuloPedidosProv = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOPRODUCCION"
                             parms.TieneModuloProduccion = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOCONTABILIDAD"
                             parms.TieneModuloContabilidad = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOCARGOS"
                             parms.TieneModuloCargos = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOCONTROLDELICENCIAS"
                             parms.TieneModuloControlDeLicencias = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOFICHAS"
                             parms.TieneModuloFichas = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOSUELDOS"
                             parms.TieneModuloSueldos = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOEXPENSAS"
                             parms.TieneModuloExpensas = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOCONTRATISTAS"
                             parms.TieneModuloContratistas = Convert.ToBoolean(p.ValorParametro)
                          Case "MODULOALQUILER"
                             parms.TieneModuloAlquiler = Convert.ToBoolean(p.ValorParametro)
                          Case "EXTRASSINERGIA"
                             parms.ExtrasSinergia = Convert.ToBoolean(p.ValorParametro)
                          Case Else

                       End Select
                    End Sub)
         Dim valor = New ParametrosModulosConverter().ConvertToString(parms)
         _Insertar(New Entidades.Parametro() With
                     {
                        .IdEmpresa = idEmpresa,
                        .IdParametro = Entidades.Parametro.Parametros.TIENEMODULOS.ToString(),
                        .DescripcionParametro = String.Empty,
                        .ValorParametro = valor,
                        .CategoriaParametro = String.Empty,
                        .UbicacionParametro = String.Empty
                     })
         'ps.ForEach(Sub(p) _Borrar(p))
      End If
   End Sub

#End Region

End Class