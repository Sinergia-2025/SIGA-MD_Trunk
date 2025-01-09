Public Class VersionesScripts
   Inherits Base

   Public Event EjecutandoScript(vse As Entidades.VersionScriptEjecucion)

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "VersionesScripts"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.VersionScript)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.VersionScript)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(DirectCast(entidad, Entidades.VersionScript)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.VersionesScripts(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.VersionesScripts(da).Versiones_GA()
   End Function

   Public Function GetXAplicationVersion(idAplication As String, idVersionDesde As String, idVersionHasta As String) As DataTable
      Return New SqlServer.VersionesScripts(da).GetxAplicacionVersion(idAplication, idVersionDesde, idVersionHasta)
   End Function
   Public Function GetTodosXAplicationVersion(idAplication As String, idVersionDesde As String, idVersionHasta As String) As List(Of Entidades.VersionScript)
      Return CargaLista(New SqlServer.VersionesScripts(da).GetxAplicacionVersion(idAplication, idVersionDesde, idVersionHasta),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VersionScript())
   End Function
   Public Function GetOrdenMaximo(idAplication As String, idVersion As String) As Integer
      Return New SqlServer.VersionesScripts(da).GetOrdenMaximo(idAplication, idVersion)
   End Function
   Public Sub Inserta(entidad As Entidades.VersionScript)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Private Sub Actualiza(entidad As Entidades.Entidad)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overloads Sub Borrar(idAplication As String, idVersionDesde As String, order As Integer)
      Dim vs = New Entidades.VersionScript()
      vs.Aplicacion.IdAplicacion = idAplication
      vs.Version.NroVersion = idVersionDesde
      vs.Orden = order
      Borrar(vs)
   End Sub

   Private Sub Borra(entidad As Entidades.Entidad)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub BorraRango(aplicacion As String, versionDesde As String, versionHasta As String)
      Dim sql = New SqlServer.VersionesScripts(da)
      sql.VersionesScripts_D_Rango(aplicacion, versionDesde, versionHasta)
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Entidades.Entidad, tipo As TipoSP)
      Dim en = DirectCast(entidad, Entidades.VersionScript)
      Dim sql = New SqlServer.VersionesScripts(da)
      Dim validaExisteNombre = ExisteNombre(en.Aplicacion.IdAplicacion, en.Nombre)
      Select Case tipo
         Case TipoSP._I

            If Not String.IsNullOrWhiteSpace(validaExisteNombre) Then
               Throw New Exception(validaExisteNombre)
            End If
            If ExisteOrden(en.Aplicacion.IdAplicacion, en.Version.NroVersion, en.Orden) Then
               Throw New Exception(String.Format("El Orden {0} ya existe en la versión {1}", en.Orden, en.Aplicacion.IdAplicacion))
            End If

            sql.VersionesScripts_I(en.Aplicacion.IdAplicacion, en.Version.NroVersion, en.Orden,
                                   en.Nombre, en.Script, en.Obligatorio, en.Cliente.CodigoCliente)
         Case TipoSP._U
            sql.VersionesScripts_U(en.Aplicacion.IdAplicacion, en.Version.NroVersion, en.Orden,
                                   en.Nombre, en.Script, en.Obligatorio, en.Cliente.CodigoCliente)
         Case TipoSP._D
            sql.VersionesScripts_D(en.Aplicacion.IdAplicacion, en.Version.NroVersion, en.Orden)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.VersionScript, dr As DataRow)
      With o
         .Aplicacion = New Reglas.Aplicaciones(da).GetUno(dr.Field(Of String)(Entidades.VersionScript.Columnas.IdAplicacion.ToString()))
         .Version.IdAplicacion = .Aplicacion.IdAplicacion
         .Version.NroVersion = dr.Field(Of String)(Entidades.VersionScript.Columnas.NroVersion.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.VersionScript.Columnas.Orden.ToString())
         .Nombre = dr.Field(Of String)(Entidades.VersionScript.Columnas.Nombre.ToString())
         .Script = dr.Field(Of String)(Entidades.VersionScript.Columnas.Script.ToString())
         .Obligatorio = dr.Field(Of Boolean)(Entidades.VersionScript.Columnas.Obligatorio.ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.VersionScript.Columnas.CodigoCliente.ToString()).ToString()) Then
            .Cliente = New Reglas.Clientes(da).GetUnoPorCodigo(dr.Field(Of Long)(Entidades.VersionScript.Columnas.CodigoCliente.ToString()))
         End If

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idAplicacion As String, nroVersion As String, orden As Integer,
                          Optional accion As AccionesSiNoExisteRegistro = AccionesSiNoExisteRegistro.Vacio) As Entidades.VersionScript
      Dim dt = New SqlServer.VersionesScripts(da).Versiones_G1(idAplicacion, nroVersion, orden)
      Dim o = New Entidades.VersionScript()
      If dt.Rows.Count > 0 Then
         CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No se encontro la versión {1} de la Aplicación {0}.", idAplicacion, nroVersion))
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If
      Return o
   End Function

   Private Overloads Function CargaLista(dt As DataTable) As List(Of Entidades.VersionScript)
      Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VersionScript())
   End Function

   Public Function GetTodos() As List(Of Entidades.VersionScript)
      Return CargaLista(GetAll())
   End Function

   Public Function GetTodos(idAplicacion As String) As List(Of Entidades.VersionScript)
      Return CargaLista(New SqlServer.VersionesScripts(da).Versiones_GA(idAplicacion))
   End Function

   Public Function GetUltimaPorAplicacion(idAplicacion As String) As DataTable
      Return New SqlServer.VersionesScripts(da).GetUltimaPorAplicacion(idAplicacion)
   End Function

   Public Function ExisteNombre(idAplicacion As String, nombre As String) As String
      Dim existe As String = String.Empty
      Dim dt = New SqlServer.VersionesScripts(da).ExisteScriptPorNombre(idAplicacion, nombre)
      If dt.Rows.Count > 0 Then
         For Each dr As DataRow In dt.Rows
            existe = String.Format("El Script {0} de {1}; ya existe en la versión {2}",
                                   dr.Field(Of String)("Nombre"),
                                   dr.Field(Of String)("IdAplicacion"),
                                   dr.Field(Of String)("NroVersion"))
         Next
      End If
      Return existe
   End Function
   Public Function ExisteOrden(idAplicacion As String, nroVersion As String, orden As Integer) As Boolean
      Dim dt = New SqlServer.VersionesScripts(da).ExisteScriptPorOrden(idAplicacion, nroVersion, orden)
      If dt.Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If
   End Function
   Public Function TestearScripts(versionScripts As List(Of Entidades.VersionScript),
                                   idAplicacion As String,
                                   codigoCliente As Long,
                                   base As String) As List(Of Entidades.VersionScriptEjecucion)
      'Este metodo es solo de testeo
      'NUNCA VA A COMMITEAR NADA
      Try
         da.OpenConection()
         'Me.da.BeginTransaction()

         Return EjecutaScripts(versionScripts, idAplicacion, codigoCliente, base)
         'hago ROLLBACK de todo (la idea de esta ejecución es para ver si NO falla ningun scripts)
      Catch ex As Exception
         Throw
      Finally
         ' Me.da.RollbakTransaction()
         da.CloseConection()
      End Try

   End Function

   Public Function EjecutarScripts(idAplicacion As String,
                                   codigoCliente As Long,
                                   base As String,
                                   versionScripts As List(Of Entidades.VersionScript)) As List(Of Entidades.VersionScriptEjecucion)

      Dim scriptEjecutados As List(Of Entidades.VersionScriptEjecucion)
      Dim sql As SqlServer.VersionesScriptsEjecuciones
      Dim versAEli As List(Of String)

      Try
         da.OpenConection()

         'actualizar la tabla de Scripts Ejecutados
         'tengo que eliminar todos los scripts ejecutados de esa versión

         '------
         sql = New SqlServer.VersionesScriptsEjecuciones(da)
         versAEli = New List(Of String)()
         For Each ve As Entidades.VersionScript In versionScripts
            'If versAEli.Count = 0 OrElse Not versAEli.Contains(ve.Version.NroVersion) Then
            If Not versAEli.Contains(ve.Version.NroVersion) Then
               versAEli.Add(ve.Version.NroVersion)
            End If
         Next
         sql.EliminarTodaLaVersion(idAplicacion, versAEli.ToArray(), codigoCliente)
         '------

         'ejecuta todos los scripts pero no falla nunca, siempre va a retornar los scripts ejecutados
         scriptEjecutados = EjecutaScripts(versionScripts, idAplicacion, codigoCliente, base)

         Return scriptEjecutados

      Catch
         Throw
      Finally
         da.CloseConection()
      End Try

   End Function

   Public Function GetScriptsAEjecutar(idAplicacion As String, desde As Version, hasta As Version) As List(Of Entidades.VersionScript)
      Try
         da.OpenConection()

         Dim sql = New SqlServer.VersionesScripts(da)
         'cargar los objetos para enviarlos.
         Dim scripts = CargaLista(sql.GetScriptsAEjecutar(idAplicacion, desde, hasta),
                                  Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VersionScript())

         Return scripts
      Catch
         Throw
      Finally
         da.CloseConection()
      End Try

   End Function

   Private Function EjecutaScripts(versionScripts As List(Of Entidades.VersionScript),
                                   idAplicacion As String,
                                   codigoCliente As Long,
                                   base As String) As List(Of Entidades.VersionScriptEjecucion)
      'No tengo que abrir ninguna conexión NI transacción ya que es interno el metodo
      'este metodo se va a utilizar del cliente cuando corra la actualización
      Dim cadena As List(Of String)
      Dim sql As SqlServer.VersionesScripts
      Dim sqlSE As SqlServer.VersionesScriptsEjecuciones
      sql = New SqlServer.VersionesScripts(Me.da)
      sqlSE = New SqlServer.VersionesScriptsEjecuciones(Me.da)
      Dim vse As List(Of Entidades.VersionScriptEjecucion)
      vse = New List(Of Entidades.VersionScriptEjecucion)()
      Dim eje As Entidades.VersionScriptEjecucion
      Dim exitoso As Boolean = True
      Dim codigoClie As Long = Convert.ToInt64(Publicos.CodigoClienteSinergia)
      Dim mensajeError As String
      cadena = New List(Of String)()

      For Each sc As Entidades.VersionScript In versionScripts
         cadena.Clear()
         'por cada script lo ejecuto pero primero controlo que no se haya ejecutado antes
         If sqlSE.ElScriptYaFueEjecutado(sc.Aplicacion.IdAplicacion, sc.Version.ToString(), sc.Orden) Then
            Continue For
         End If
         exitoso = True
         mensajeError = String.Empty
         'parseo el script para ver si en uno hay mas de un script

         For Each ss As String In ScriptsAdmin.SplitSqlStatements(sc.Script)
            cadena.Add(ss)
         Next
         eje = New Entidades.VersionScriptEjecucion()

         'por cada script lo ejecuto pero primero controlo que no se haya ejecutado antes
         Try
            For Each cad As String In cadena
               sql.EjecutarScript(cad)
            Next
         Catch ex As Exception
            'si falla no haga nada ya que tengo que mostrar que no se ejecuto bien.
            mensajeError = ex.Message
            exitoso = False
         End Try
         eje.VersionScript = sc
         eje.FechaEjecucion = DateTime.Now()
         eje.Exitoso = exitoso
         eje.Cliente.IdCliente = codigoClie
         eje.Mensaje = mensajeError
         eje.Base = Ayudantes.Conexiones.Base

         Try
            'si no puedo grabar el log de ejecuciones automaticamente tiro todo para atras
            sqlSE.VersionesScriptsEjecuciones_I(idAplicacion,
                                              eje.VersionScript.Version.NroVersion.ToString(),
                                              eje.VersionScript.Orden,
                                              codigoCliente,
                                              base,
                                              eje.VersionScript.Nombre,
                                              eje.VersionScript.Script,
                                              eje.VersionScript.Obligatorio,
                                              eje.Exitoso,
                                              eje.Mensaje)
         Catch ex As Exception
            eje.Mensaje += "ERROR - " + ex.Message
            'si falla algo del log no hago nada y sigo con el proximo!!! TEMA A VER QUE HACEMOS ACA...
         End Try

         vse.Add(eje)

         RaiseEvent EjecutandoScript(eje)
      Next

      Return vse
   End Function

   Private Sub EliminarScriptsDeVersiones(idAplicacion As String, versiones As String())
      Dim sql As SqlServer.VersionesScripts
      sql = New SqlServer.VersionesScripts(Me.da)
      sql.EliminarScriptsVersion(idAplicacion, versiones)
   End Sub

   Public Sub ProcesarBajadasDeScripts(idAplicacion As String, listadoScripts As List(Of Entidades.VersionScript))
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim lis As List(Of String)
         lis = New List(Of String)()

         'elimino todos los scripts de la versión
         For Each vs As Entidades.VersionScript In listadoScripts
            lis.Add(vs.Version.NroVersion)
         Next
         Me.EliminarScriptsDeVersiones(idAplicacion, lis.ToArray())

         Dim rVersion As Reglas.Versiones = New Versiones(da)
         'inserto todos los scripts
         For Each vs As Entidades.VersionScript In listadoScripts
            rVersion._Merge(vs.Version)
            Me.Inserta(vs)
         Next


         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Sub InsertarSeleccionMultiple(aplicacion As String, versionDesde As String, versionHasta As String, archivos As IEnumerable(Of String),
                                        avanceCallback As Action(Of Entidades.AvanceProceso))
      EjecutaConTransaccion(
         Sub()
            If versionDesde <> versionHasta Then
               BorraRango(aplicacion, versionDesde, versionHasta)
            End If
            Dim versionAnterior = String.Empty
            Dim orden = 0I

            Dim actual = 0I
            For Each arch In archivos.OrderBy(Function(a) a).ToArray()
               'Threading.Thread.Sleep(500)
               If avanceCallback IsNot Nothing Then
                  actual += 1
                  avanceCallback(New Entidades.AvanceProceso(actual, archivos.Count, arch))
               End If
               Dim versionScript = New Entidades.VersionScript()
               Dim fi = New IO.FileInfo(arch)
               Dim nroVersion As String
               Try
                  nroVersion = fi.Name.Split("_"c)(1).Replace("v", "")
               Catch ex As Exception
                  Throw New Exception(String.Format("El script {0} no tiene el formato de nombre correcto.", arch))
               End Try

               If versionAnterior <> nroVersion Then
                  orden = 1
               End If

               versionScript.Script = IO.File.ReadAllText(fi.FullName)
               versionScript.Nombre = fi.Name
               versionScript.Orden = orden
               versionScript.Aplicacion.IdAplicacion = aplicacion
               versionScript.Version.NroVersion = nroVersion
               versionScript.Obligatorio = True
               Try
                  Inserta(versionScript)
               Catch ex As Exception
                  Throw
               End Try
               orden += 1
               versionAnterior = nroVersion
            Next
         End Sub)
   End Sub

   Public Function Sincronizar(aplicacion As String, versionDesde As String, versionHasta As String,
                               avanceCallback As Action(Of Entidades.AvanceProceso)) As Integer
      Return EjecutaConTransaccion(
         Function()
            Dim versiones = New Versiones(da).GetTodos(aplicacion, versionDesde, versionHasta).OrderBy(Function(sv) sv.NroVersion)
            Dim cantidad = 0I
            Dim actual = 0I
            For Each ver In versiones
               Dim nroVersion = ver.NroVersion

               Dim oSincronizar = New SubirScriptVersion()
               'elimino todos los scripts de la version
               oSincronizar.EliminarScriptsdeVersion(aplicacion, nroVersion)

               Dim reg = New Reglas.VersionesScripts(da)
               Dim scripts = reg.GetTodosXAplicationVersion(aplicacion, nroVersion, nroVersion)

               If avanceCallback IsNot Nothing Then
                  actual += 1
                  avanceCallback(New Entidades.AvanceProceso(actual, versiones.Count, String.Format("Sincronizando {0} scripts para la versión {1}",
                                                                                                    scripts.Count, nroVersion)))
               End If

               If scripts.Count > 0 Then
                  oSincronizar.SincronizarScriptsdeVersion(scripts)
               End If

               cantidad += scripts.Count
            Next
            Return cantidad
         End Function)
   End Function

#End Region

End Class