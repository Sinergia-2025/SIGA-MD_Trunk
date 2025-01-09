Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports Eniac.Entidades
Imports Eniac.Entidades.JSonEntidades.Concesionarios.Alcorta
Imports Eniac.Reglas.ServiciosRest.TiendasWeb
Imports Eniac.SqlServer

Namespace ServiciosRest.Concesionarios
   Public Class SincronizacionMovil
      Inherits Base

#Region "Propiedades"
      Private Property ConcesionariosURLBase As Uri
      Private Property RestResponse As String
      Private Property _reenviarTodo As Boolean
      Private Property _rebajarTodo As Boolean

      Public serializer As New JavaScriptSerializer()
      'Private _logger As SincronizacionArboreaExporter
      Private Property _itemsNuevos As Integer
      Private Property _itemsActualizados As Integer

      Private Property _endpointActualizados As Integer
      Private Property _endpointConError As Integer

      Public Event Avance(sender As Object, e As SincronizacionMovilEventArgs)
      Public Event Estado(sender As Object, e As SincronizacionMovilEstadoEventArgs)
      Public Event ProcesoFinalizado(sender As Object, e As SincronizacionMovilProcesoFinalizadoEventArgs)
      Public Event InformarError(sender As Object, e As SincronizacionMovilErrorEventArgs)

#End Region

#Region "Constructors"
      Private Sub New(accesoDatos As Datos.DataAccess)
         da = accesoDatos
      End Sub
      Public Sub New()
         Me.New(New Datos.DataAccess())
         If Not String.IsNullOrEmpty(Reglas.Publicos.Concesionarios.SincronizacionMovil.URLConcesionarios) Then
            ConcesionariosURLBase = New Uri(Reglas.Publicos.Concesionarios.SincronizacionMovil.URLConcesionarios)
         Else
            Throw New Exception("ATENCIÓN: La URL Base para Sincronizacion Movil no se encuentra configurada.")
         End If
      End Sub
#End Region

#Region "Metodos"
      '----------------------------------------------------------------------------------------------------------------------------------------------
      Private Sub TriggerEvent(sincroEstado As SincroMovilEstados, verb As SincroMovilMetodos, totalRegistros As Integer, nroRegistroSubiendo As Integer, queEstoySubiendo As String, countExitosos As Integer, countError As Integer)
         RaiseEvent Estado(Me, New SincronizacionMovilEstadoEventArgs(Entidades.ConcesionarioMovil.ALCORTA, sincroEstado, verb, totalRegistros, nroRegistroSubiendo, queEstoySubiendo, countExitosos, countError))
      End Sub

      Protected Sub OnInformarError(elementoTransmitido As String, mensaje As String)
         RaiseEvent InformarError(Me, New SincronizacionMovilErrorEventArgs(Entidades.ConcesionarioMovil.ALCORTA, elementoTransmitido, mensaje))
      End Sub
      Public Sub SubirInformacion(reenviarTodo As Boolean, sincronizaCategorias As Boolean, sincronizaProductos As Boolean)
         '--------------------------
         _reenviarTodo = reenviarTodo
         _endpointActualizados = 0
         _endpointConError = 0
         '-- Bancos.- --------------
         SubirBancos()
         '-- Provincias.-
         SubirProvincias()
         '-- Localidades.-
         SubirLocalidades()
         '-- Estados Civiles.-
         SubirEstadosCiviles()
         '-- Tipos de Unidades.-
         SubirTiposUnidades()
         '-- Sub Tipos de Unidades.-
         SubirSubTiposUnidades()
         '-- Tipos Unidades Ejes.-
         SubirTiposUnidadesEjes()
         '-----------------------------------------------------------------------------------------------------------------------------------------
         RaiseEvent ProcesoFinalizado(Me, New SincronizacionMovilProcesoFinalizadoEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Proceso de Sincronizacion, finalizado correctamente !!!", _endpointActualizados, _endpointConError))
         '-----------------------------------------------------------------------------------------------------------------------------------------
      End Sub
#End Region

#Region "Métodos Privados"
      '-- TIPOS UNIDADES EJES.- ------------------------------------------------------------------------------------------------------------------
      Private Sub SubirTiposUnidadesEjes()
         EjecutaConConexion(Sub() _SubirTiposUnidadesEjes())
      End Sub
      Private Sub _SubirTiposUnidadesEjes()
         '-----------------------------------------------------------------------------------------------------------------------------------------
         _itemsNuevos = 0
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Dim rTipUniEje = New ConcesionarioDistribucionEjes(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones.EvaluaProcesoEnEjecucion(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString())
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {
                                       .SistemaDestino = Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(),
                                       .Tabla = Entidades.ConcesionarioTipoUnidadEje.NombreTabla,
                                       .FechaActualizacion = Nothing,
                                       .FechaInicioSubida = Date.Now,
                                       .FechaSubida = Nothing,
                                       .IdUsuario = actual.Nombre,
                                       .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)
                                  })
         '-----------------------------------------------------------------------------------------------------------------------------------------
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Obteniendo información de los Tipos de Unidades Ejes..."))
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil  - Comenzando la Subida de Tipos de Unidades Ejes."), TraceEventType.Information)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Using dt = rTipUniEje.GetAll()
            '--------------------------------------------------------------------------------------------------------------------------------------
            My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - {0} Tipos de Unidades Ejes por subir.", dt.Rows.Count), TraceEventType.Verbose)
            '--------------------------------------------------------------------------------------------------------------------------------------
            Try
               Dim lTipUniEje = New List(Of Entidades.ConcesionarioTipoUnidadEje)()
               '-- Sub Tipos Unidades.- -------------------------------------------------------------------------------------------------------------------
               For Each dr As DataRow In dt.Rows
                  Try
                     Dim eTipUniEje = New Entidades.ConcesionarioTipoUnidadEje With
                     {
                        .IdTipoUnidadDistribucionEje = dr.Field(Of Integer)("IdEje"),
                        .IdTipoUnidad = dr.Field(Of Integer)("IdTipoUnidad"),
                        .Nombre = dr.Field(Of String)("NombreEje"),
                        .Descripcion = dr.Field(Of String)("DescripcionEje")
                     }
                     lTipUniEje.Add(eTipUniEje)
                     '-- Incrementa Contador de Items Nuevos.- --------------------------------------------------------------------------------------
                     _itemsNuevos += 1
                     '-------------------------------------------------------------------------------------------------------------------------------
                     TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "TiposUnidadesEjes", _itemsNuevos, 0)
                     '-------------------------------------------------------------------------------------------------------------------------------
                  Catch ex As Exception
                     OnInformarError(String.Format("IdEje='{0}'", dr.Field(Of String)("IdEje")), ex.Message)
                     _endpointConError += 1
                  End Try
               Next
               If lTipUniEje.Count > 0 Then
                  Dim data = serializer.Serialize(lTipUniEje)
                  '-- Carga Lista de Tipos Unidades Ejes.- --------------------------------------------------------------------------------------------------------
                  CargaNuevoTipoUnidadEje(data, _itemsNuevos, dt.Rows.Count())
                  _endpointActualizados += 1
                  '-----------------------------------------------------------------------------------------------------------------------------------
                  My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - JSON: {0}", data), TraceEventType.Verbose)
               Else
                  '-------------------------------------------------------------------------------------------------------------------------------
                  TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "TiposUnidadesEjes", _itemsNuevos, 0)
                  '-------------------------------------------------------------------------------------------------------------------------------
               End If
            Finally
               '# Informo y Guardo la fecha de sincronización 
               My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.ConcesionarioTipoUnidadEje.NombreTabla), TraceEventType.Information)
               rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(), Entidades.ConcesionarioTipoUnidadEje.NombreTabla, Date.Now)
            End Try
         End Using
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Tipos de Unidades Ejes subidos correctamente."))
      End Sub
      Private Sub CargaNuevoTipoUnidadEje(data As String, nroRegActual As Integer, CantidadReg As Integer)
         '-- Si es nuevo Cargo todos sus datos a ML-
         Dim response = Enviar(Of Entidades.JSonEntidades.Concesionarios.Alcorta.TipoUnidadEje)(data, SincroMovilMetodos.POST, Me.GetHeaders(), "TiposUnidadesDistribucionEjes")
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - Cargando Tipos de Unidades Ejes {0} de {1}.", nroRegActual, CantidadReg), TraceEventType.Verbose)
      End Sub
      '-- SUB TIPOS UNIDADES.- ------------------------------------------------------------------------------------------------------------------
      Private Sub SubirSubTiposUnidades()
         EjecutaConConexion(Sub() _SubirSubTiposUnidades())
      End Sub
      Private Sub _SubirSubTiposUnidades()
         '-----------------------------------------------------------------------------------------------------------------------------------------
         _itemsNuevos = 0
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Dim rSubTipUni = New ConcesionarioSubTiposUnidades(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones.EvaluaProcesoEnEjecucion(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString())
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {
                                       .SistemaDestino = Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(),
                                       .Tabla = Entidades.ConcesionariosSubTipoUnidad.NombreTabla,
                                       .FechaActualizacion = Nothing,
                                       .FechaInicioSubida = Date.Now,
                                       .FechaSubida = Nothing,
                                       .IdUsuario = actual.Nombre,
                                       .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)
                                  })
         '-----------------------------------------------------------------------------------------------------------------------------------------
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Obteniendo información de los Sub Tipos de Unidades..."))
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil  - Comenzando la Subida de Sub Tipos de Unidades."), TraceEventType.Information)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Using dt = rSubTipUni.GetAll()
            '--------------------------------------------------------------------------------------------------------------------------------------
            My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - {0} Sub Tipos de Unidades por subir.", dt.Rows.Count), TraceEventType.Verbose)
            '--------------------------------------------------------------------------------------------------------------------------------------
            Try
               Dim lSubTipUni = New List(Of Entidades.ConcesionariosSubTipoUnidad)()
               '-- Sub Tipos Unidades.- -------------------------------------------------------------------------------------------------------------------
               For Each dr As DataRow In dt.Rows
                  Try
                     Dim eSubTipUni = New Entidades.ConcesionariosSubTipoUnidad With
                     {
                        .IdTipoUnidadSubTipo = dr.Field(Of Integer)("IdSubTipoUnidad"),
                        .IdTipoUnidad = dr.Field(Of Integer)("IdTipoUnidad"),
                        .Nombre = dr.Field(Of String)("NombreSubTipoUnidad"),
                        .Descripcion = dr.Field(Of String)("DescripcionSubTipoUnidad"),
                        .SolicitaNumeroDePurtasLaterales = dr.Field(Of Boolean)("SolicitaCantPuertasLaterales"),
                        .SolicitaCantPisos = dr.Field(Of Boolean)("SolicitaCantPisos"),
                        .SolicitaVolumen = dr.Field(Of Boolean)("SolicitaVolumen")
                     }
                     lSubTipUni.Add(eSubTipUni)
                     '-- Incrementa Contador de Items Nuevos.- --------------------------------------------------------------------------------------
                     _itemsNuevos += 1
                     '-------------------------------------------------------------------------------------------------------------------------------
                     TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "SubTiposUnidades", _itemsNuevos, 0)
                     '-------------------------------------------------------------------------------------------------------------------------------
                  Catch ex As Exception
                     OnInformarError(String.Format("IdSubTipoUnidad='{0}'", dr.Field(Of String)("IdSubTipoUnidad")), ex.Message)
                     _endpointConError += 1
                  End Try
               Next
               If lSubTipUni.Count > 0 Then
                  Dim data = serializer.Serialize(lSubTipUni)
                  '-- Carga Lista de Sub Tipos Unidades.- --------------------------------------------------------------------------------------------------------
                  CargaNuevoSubTipoUnidad(data, _itemsNuevos, dt.Rows.Count())
                  _endpointActualizados += 1
                  '-----------------------------------------------------------------------------------------------------------------------------------
                  My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - JSON: {0}", data), TraceEventType.Verbose)
               Else
                  TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "SubTiposUnidades", _itemsNuevos, 0)
               End If
            Finally
               '# Informo y Guardo la fecha de sincronización 
               My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.ConcesionariosSubTipoUnidad.NombreTabla), TraceEventType.Information)
               rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(), Entidades.ConcesionariosSubTipoUnidad.NombreTabla, Date.Now)
            End Try
         End Using
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Sub Tipos de Unidades subidos correctamente."))
      End Sub
      Private Sub CargaNuevoSubTipoUnidad(data As String, nroRegActual As Integer, CantidadReg As Integer)
         '-- Si es nuevo Cargo todos sus datos a ML-
         Dim response = Enviar(Of Entidades.JSonEntidades.Concesionarios.Alcorta.TipoUnidad)(data, SincroMovilMetodos.POST, Me.GetHeaders(), "TiposUnidadesSubTipos")
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - Cargando Sub Tipos de Unidades {0} de {1}.", nroRegActual, CantidadReg), TraceEventType.Verbose)
      End Sub
      '-- TIPOS UNIDADES.- ------------------------------------------------------------------------------------------------------------------
      Private Sub SubirTiposUnidades()
         EjecutaConConexion(Sub() _SubirTiposUnidades())
      End Sub
      Private Sub _SubirTiposUnidades()
         '-----------------------------------------------------------------------------------------------------------------------------------------
         _itemsNuevos = 0
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Dim rTiposUnid = New ConcesionarioTiposUnidades(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones.EvaluaProcesoEnEjecucion(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString())
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {
                                       .SistemaDestino = Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(),
                                       .Tabla = Entidades.ConcesionariosTipoUnidad.NombreTabla,
                                       .FechaActualizacion = Nothing,
                                       .FechaInicioSubida = Date.Now,
                                       .FechaSubida = Nothing,
                                       .IdUsuario = actual.Nombre,
                                       .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)
                                  })
         '-----------------------------------------------------------------------------------------------------------------------------------------
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Obteniendo información de los Tipos de Unidades..."))
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil  - Comenzando la Subida de Tipos de Unidades."), TraceEventType.Information)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Using dt = rTiposUnid.GetAll()
            '--------------------------------------------------------------------------------------------------------------------------------------
            My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - {0} Tipos de Unidades por subir.", dt.Rows.Count), TraceEventType.Verbose)
            '--------------------------------------------------------------------------------------------------------------------------------------
            Try
               Dim lTipoUnidad = New List(Of Entidades.ConcesionariosTipoUnidad)()
               '-- Estados Civiles.- -------------------------------------------------------------------------------------------------------------------
               For Each dr As DataRow In dt.Rows
                  Try
                     Dim eTipoUnidad = New Entidades.ConcesionariosTipoUnidad With
                     {
                        .IdTipoUnidad = dr.Field(Of Integer)("IdTipoUnidad"),
                        .Nombre = dr.Field(Of String)("NombreTipoUnidad"),
                        .Descripcion = dr.Field(Of String)("DescripcionTipoUnidad"),
                        .SolicitaDistribucionEje = dr.Field(Of Boolean)("SolicitaDistribucionEje"),
                        .MuestraEnCerokm = dr.Field(Of Boolean)("MuestraEnCerokm"),
                        .MuestraEnUsado = dr.Field(Of Boolean)("MuestraEnUsado")
                     }
                     lTipoUnidad.Add(eTipoUnidad)
                     '-- Incrementa Contador de Items Nuevos.- --------------------------------------------------------------------------------------
                     _itemsNuevos += 1
                     '-------------------------------------------------------------------------------------------------------------------------------
                     TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "TiposUnidades", _itemsNuevos, 0)
                     '-------------------------------------------------------------------------------------------------------------------------------
                  Catch ex As Exception
                     OnInformarError(String.Format("IdTipoUnidad='{0}'", dr.Field(Of String)("IdTipoUnidad")), ex.Message)
                     _endpointConError += 1
                  End Try
               Next
               If lTipoUnidad.Count > 0 Then
                  Dim data = serializer.Serialize(lTipoUnidad)
                  '-- Carga Lista de Tipos Unidades.- --------------------------------------------------------------------------------------------------------
                  CargaNuevoTipoUnidad(data, _itemsNuevos, dt.Rows.Count())
                  _endpointActualizados += 1
                  '-----------------------------------------------------------------------------------------------------------------------------------
                  My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - JSON: {0}", data), TraceEventType.Verbose)
               Else
                  '-------------------------------------------------------------------------------------------------------------------------------
                  TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "TiposUnidades", _itemsNuevos, 0)
                  '-------------------------------------------------------------------------------------------------------------------------------
               End If
            Finally
               '# Informo y Guardo la fecha de sincronización 
               My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.ConcesionariosTipoUnidad.NombreTabla), TraceEventType.Information)
               rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(), Entidades.ConcesionariosTipoUnidad.NombreTabla, Date.Now)
            End Try
         End Using
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Tipos de Unidades subidos correctamente."))
      End Sub
      Private Sub CargaNuevoTipoUnidad(data As String, nroRegActual As Integer, CantidadReg As Integer)
         '-- Si es nuevo Cargo todos sus datos a ML-
         Dim response = Enviar(Of Entidades.JSonEntidades.Concesionarios.Alcorta.TipoUnidad)(data, SincroMovilMetodos.POST, Me.GetHeaders(), "TiposUnidades")
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - Cargando Tipos de Unidades {0} de {1}.", nroRegActual, CantidadReg), TraceEventType.Verbose)
      End Sub
      '-- ESTADOS CIVILES.- ------------------------------------------------------------------------------------------------------------------
      Private Sub SubirEstadosCiviles()
         EjecutaConConexion(Sub() _SubirEstadosCiviles())
      End Sub
      Private Sub _SubirEstadosCiviles()
         '-----------------------------------------------------------------------------------------------------------------------------------------
         _itemsNuevos = 0
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Dim rEstCivil = New EstadosCiviles(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones.EvaluaProcesoEnEjecucion(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString())
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {
                                       .SistemaDestino = Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(),
                                       .Tabla = Entidades.ConcesionarioEstadoCivil.NombreTabla,
                                       .FechaActualizacion = Nothing,
                                       .FechaInicioSubida = Date.Now,
                                       .FechaSubida = Nothing,
                                       .IdUsuario = actual.Nombre,
                                       .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)
                                  })
         '-----------------------------------------------------------------------------------------------------------------------------------------
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Obteniendo información de los Estados Civiles..."))
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil  - Comenzando la Subida de Estados Civiles."), TraceEventType.Information)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Using dt = rEstCivil.GetAll()
            '--------------------------------------------------------------------------------------------------------------------------------------
            My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - {0} Estados Civiles por subir.", dt.Rows.Count), TraceEventType.Verbose)
            '--------------------------------------------------------------------------------------------------------------------------------------
            Try
               Dim lEstCivil = New List(Of Entidades.ConcesionarioEstadoCivil)()
               '-- Estados Civiles.- -------------------------------------------------------------------------------------------------------------------
               For Each dr As DataRow In dt.Rows
                  Try
                     Dim eEstCivil = New Entidades.ConcesionarioEstadoCivil With
                     {
                        .IdEstadoCivil = dr.Field(Of Integer)("IdEstadoCivil"),
                        .NombreEstadoCivil = dr.Field(Of String)("NombreEstadoCivil").ToString()
                     }
                     lEstCivil.Add(eEstCivil)
                     '-- Incrementa Contador de Items Nuevos.- --------------------------------------------------------------------------------------
                     _itemsNuevos += 1
                     '-------------------------------------------------------------------------------------------------------------------------------
                     TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "EstadosCiviles", _itemsNuevos, 0)
                     '-------------------------------------------------------------------------------------------------------------------------------
                  Catch ex As Exception
                     OnInformarError(String.Format("IdEstadoCivil='{0}'", dr.Field(Of String)("IdEstadoCivil")), ex.Message)
                     _endpointConError += 1
                  End Try
               Next
               If lEstCivil.Count > 0 Then
                  Dim data = serializer.Serialize(lEstCivil)
                  '-- Carga Lista de Estados Civiles.- --------------------------------------------------------------------------------------------------------
                  CargaNuevoEstadoCivil(data, _itemsNuevos, dt.Rows.Count())
                  _endpointActualizados += 1
                  '-----------------------------------------------------------------------------------------------------------------------------------
                  My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - JSON: {0}", data), TraceEventType.Verbose)
               Else
                  '-------------------------------------------------------------------------------------------------------------------------------
                  TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "EstadosCiviles", _itemsNuevos, 0)
                  '-------------------------------------------------------------------------------------------------------------------------------
               End If
            Finally
               '# Informo y Guardo la fecha de sincronización 
               My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.ConcesionarioEstadoCivil.NombreTabla), TraceEventType.Information)
               rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(), Entidades.ConcesionarioEstadoCivil.NombreTabla, Date.Now)
            End Try
         End Using
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Estados Civiles subidos correctamente."))
      End Sub
      Private Sub CargaNuevoEstadoCivil(data As String, nroRegActual As Integer, CantidadReg As Integer)
         '-- Si es nuevo Cargo todos sus datos a ML-
         Dim response = Enviar(Of Entidades.JSonEntidades.Concesionarios.Alcorta.EstadoCivil)(data, SincroMovilMetodos.POST, Me.GetHeaders(), "EstadosCiviles")
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - Cargando Localidades {0} de {1}.", nroRegActual, CantidadReg), TraceEventType.Verbose)
      End Sub
      '-- LOCALIDADES.- ----------------------------------------------------------------------------------------------------------------------
      Private Sub SubirLocalidades()
         EjecutaConConexion(Sub() _SubirLocalidades())
      End Sub
      Private Sub _SubirLocalidades()
         '-----------------------------------------------------------------------------------------------------------------------------------------
         _itemsNuevos = 0
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Dim rLocalidad = New Localidades(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones.EvaluaProcesoEnEjecucion(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString())
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {
                                       .SistemaDestino = Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(),
                                       .Tabla = Entidades.ConcesionarioLocalidad.NombreTabla,
                                       .FechaActualizacion = Nothing,
                                       .FechaInicioSubida = Date.Now,
                                       .FechaSubida = Nothing,
                                       .IdUsuario = actual.Nombre,
                                       .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)
                                  })
         '-----------------------------------------------------------------------------------------------------------------------------------------
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Obteniendo información de las Localidades..."))
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil  - Comenzando la Subida de Localidades."), TraceEventType.Information)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Using dt = rLocalidad.GetAll()
            '--------------------------------------------------------------------------------------------------------------------------------------
            My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - {0} Localidades por subir.", dt.Rows.Count), TraceEventType.Verbose)
            '--------------------------------------------------------------------------------------------------------------------------------------
            Try
               Dim lLocalidad = New List(Of Entidades.ConcesionarioLocalidad)()
               '-- Provincias.- -------------------------------------------------------------------------------------------------------------------
               For Each dr As DataRow In dt.Rows
                  Try
                     Dim eLocalidad = New Entidades.ConcesionarioLocalidad With
                     {
                        .IdLocalidad = dr.Field(Of Integer)("IdLocalidad"),
                        .NombreLocalidad = dr.Field(Of String)("NombreLocalidad").ToString(),
                        .IdPronvicia = dr.Field(Of String)("IdProvincia")
                     }
                     lLocalidad.Add(eLocalidad)
                     '-- Incrementa Contador de Items Nuevos.- --------------------------------------------------------------------------------------
                     _itemsNuevos += 1
                     '-------------------------------------------------------------------------------------------------------------------------------
                     TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "Localidades", _itemsNuevos, 0)
                     '-------------------------------------------------------------------------------------------------------------------------------
                  Catch ex As Exception
                     OnInformarError(String.Format("IdLocalidad='{0}'", dr.Field(Of String)("IdLocalidad")), ex.Message)
                     _endpointConError += 1
                  End Try
               Next
               If lLocalidad.Count > 0 Then
                  Dim data = serializer.Serialize(lLocalidad)
                  '-- Carga Lista de Localidades.- --------------------------------------------------------------------------------------------------------
                  CargarNuevasLocalidades(data, _itemsNuevos, dt.Rows.Count())
                  _endpointActualizados += 1
                  '-----------------------------------------------------------------------------------------------------------------------------------
                  My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - JSON: {0}", data), TraceEventType.Verbose)
               Else
                  '-------------------------------------------------------------------------------------------------------------------------------
                  TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "EstadosCiviles", _itemsNuevos, 0)
                  '-------------------------------------------------------------------------------------------------------------------------------
               End If
            Finally
               '# Informo y Guardo la fecha de sincronización 
               My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.ConcesionarioLocalidad.NombreTabla), TraceEventType.Information)
               rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(), Entidades.ConcesionarioLocalidad.NombreTabla, Date.Now)
            End Try
         End Using
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Localidades subidas correctamente."))
      End Sub
      Private Sub CargarNuevasLocalidades(data As String, nroRegActual As Integer, CantidadReg As Integer)
         '-- Si es nuevo Cargo todos sus datos a ML-
         Dim response = Enviar(Of Entidades.JSonEntidades.Concesionarios.Alcorta.Localidad)(data, SincroMovilMetodos.POST, Me.GetHeaders(), "Localidades")
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - Cargando Localidades {0} de {1}.", nroRegActual, CantidadReg), TraceEventType.Verbose)
      End Sub
      '-- PROVINCIAS.- --------------------------------------------------------------------------------------------------------------------------
      Private Sub SubirProvincias()
         EjecutaConConexion(Sub() _SubirProvincias())
      End Sub
      Private Sub _SubirProvincias()
         '-----------------------------------------------------------------------------------------------------------------------------------------
         _itemsNuevos = 0
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Dim rProvincia = New Provincias(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones.EvaluaProcesoEnEjecucion(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString())
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {
                                       .SistemaDestino = Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(),
                                       .Tabla = Entidades.ConcesionarioProvincia.NombreTabla,
                                       .FechaActualizacion = Nothing,
                                       .FechaInicioSubida = Date.Now,
                                       .FechaSubida = Nothing,
                                       .IdUsuario = actual.Nombre,
                                       .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)
                                  })
         '-----------------------------------------------------------------------------------------------------------------------------------------
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Obteniendo información de las Provincias..."))
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil  - Comenzando la Subida de Provincias."), TraceEventType.Information)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Using dt = rProvincia.GetAll()
            '--------------------------------------------------------------------------------------------------------------------------------------
            My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - {0} Provincias por subir.", dt.Rows.Count), TraceEventType.Verbose)
            '--------------------------------------------------------------------------------------------------------------------------------------
            Try
               Dim lProvincias = New List(Of Entidades.ConcesionarioProvincia)()
               '-- Provincias.- -------------------------------------------------------------------------------------------------------------------
               For Each dr As DataRow In dt.Rows
                  Try
                     Dim eProvincia = New Entidades.ConcesionarioProvincia With
                     {
                        .IdProvincia = dr.Field(Of String)("IdProvincia"),
                        .Nombre = dr.Field(Of String)("NombreProvincia").ToString()
                     }
                     lProvincias.Add(eProvincia)
                     '-- Incrementa Contador de Items Nuevos.- --------------------------------------------------------------------------------------
                     _itemsNuevos += 1
                     '-------------------------------------------------------------------------------------------------------------------------------
                     TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "Provincias", _itemsNuevos, 0)
                     '-------------------------------------------------------------------------------------------------------------------------------
                  Catch ex As Exception
                     OnInformarError(String.Format("IdProvincia='{0}'", dr.Field(Of String)("IdProvincia")), ex.Message)
                     _endpointConError += 1
                  End Try
               Next
               If lProvincias.Count > 0 Then
                  Dim data = serializer.Serialize(lProvincias)
                  '-- Carga Lista de Provincias.- --------------------------------------------------------------------------------------------------------
                  CargaNuevasProvincias(data, _itemsNuevos, dt.Rows.Count())
                  _endpointActualizados += 1
                  '-----------------------------------------------------------------------------------------------------------------------------------
                  My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - JSON: {0}", data), TraceEventType.Verbose)
               Else
                  '-------------------------------------------------------------------------------------------------------------------------------
                  TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "Provincias", _itemsNuevos, 0)
                  '-------------------------------------------------------------------------------------------------------------------------------
               End If
            Finally
               '# Informo y Guardo la fecha de sincronización 
               My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.ConcesionarioProvincia.NombreTabla), TraceEventType.Information)
               rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(), Entidades.ConcesionarioProvincia.NombreTabla, Date.Now)
            End Try
         End Using
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Provincias subidas correctamente."))
      End Sub
      Private Sub CargaNuevasProvincias(data As String, nroRegActual As Integer, CantidadReg As Integer)
         '-- Si es nuevo Cargo todos sus datos a ML-
         Dim response = Enviar(Of Entidades.JSonEntidades.Concesionarios.Alcorta.Provincia)(data, SincroMovilMetodos.POST, Me.GetHeaders(), "Provincias")
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - Cargando Provincias {0} de {1}.", nroRegActual, CantidadReg), TraceEventType.Verbose)
      End Sub
      '-- BANCOS.- ----------------------------------------------------------------------------------------------------------------------------------
      Private Sub SubirBancos()
         EjecutaConConexion(Sub() _SubirBancos())
      End Sub
      Private Sub _SubirBancos()
         '-----------------------------------------------------------------------------------------------------------------------------------------
         _itemsNuevos = 0
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Dim rBancos = New Bancos(da)
         Dim rSincronizaciones = New FechasSincronizaciones(da)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones.EvaluaProcesoEnEjecucion(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString())
         '-----------------------------------------------------------------------------------------------------------------------------------------
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {
                                       .SistemaDestino = Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(),
                                       .Tabla = Entidades.ConcesionarioBanco.NombreTabla,
                                       .FechaActualizacion = Nothing,
                                       .FechaInicioSubida = Date.Now,
                                       .FechaSubida = Nothing,
                                       .IdUsuario = actual.Nombre,
                                       .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)
                                  })
         '-----------------------------------------------------------------------------------------------------------------------------------------
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Obteniendo información de los Bancos..."))
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil  - Comenzando la Subida de Bancos."), TraceEventType.Information)
         '-----------------------------------------------------------------------------------------------------------------------------------------
         Using dt = rBancos.GetAll()
            '--------------------------------------------------------------------------------------------------------------------------------------
            My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - {0} Bancos por subir.", dt.Rows.Count), TraceEventType.Verbose)
            '--------------------------------------------------------------------------------------------------------------------------------------
            Try
               Dim lBancos = New List(Of Entidades.ConcesionarioBanco)()
               '-- Bancos.- -----------------------------------------------------------------------------------------------------------------------
               For Each dr As DataRow In dt.Rows
                  Try
                     Dim eBanco = New Entidades.ConcesionarioBanco With
                     {
                        .IdBanco = dr.Field(Of Integer)("IdBanco"),
                        .NombreBanco = dr.Field(Of String)("NombreBanco").ToString(),
                        .DebitoDirecto = dr.Field(Of Boolean)("DebitoDirecto"),
                        .Convenio = If(String.IsNullOrEmpty(dr("Convenio").ToString()), 0, dr.Field(Of Integer)("Convenio")),
                        .Servicio = If(String.IsNullOrEmpty(dr("Servicio").ToString()), String.Empty, dr.Field(Of String)("Servicio").ToString()),
                        .IdEmpresa = actual.Sucursal.IdEmpresa
                     }
                     lBancos.Add(eBanco)
                     '-- Incrementa Contador de Items Nuevos.- --------------------------------------------------------------------------------------
                     _itemsNuevos += 1
                     '-------------------------------------------------------------------------------------------------------------------------------
                     TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "Bancos", _itemsNuevos, 0)
                     '-------------------------------------------------------------------------------------------------------------------------------
                  Catch ex As Exception
                     OnInformarError(String.Format("IdBanco='{0}'", dr.Field(Of String)("IdBanco")), ex.Message)
                     _endpointConError += 1
                  End Try
               Next
               If lBancos.Count > 0 Then
                  Dim data = serializer.Serialize(lBancos)
                  '-- Carga Lista de Bancos.- --------------------------------------------------------------------------------------------------------
                  CargaNuevosBancos(data, _itemsNuevos, dt.Rows.Count())
                  _endpointActualizados += 1
                  '-----------------------------------------------------------------------------------------------------------------------------------
                  My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - JSON: {0}", data), TraceEventType.Verbose)
               Else
                  '-------------------------------------------------------------------------------------------------------------------------------
                  TriggerEvent(SincroMovilEstados.Subiendo, SincroMovilMetodos.POST, dt.Rows.Count, _itemsNuevos, "Bancos", _itemsNuevos, 0)
                  '-------------------------------------------------------------------------------------------------------------------------------
               End If
            Finally
               '# Informo y Guardo la fecha de sincronización 
               My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil.Ejecutar - Grabando Fecha de Ult. Sincronización - Tabla {0}.", Entidades.ConcesionarioBanco.NombreTabla), TraceEventType.Information)
               rSincronizaciones.ActualizaFechaSubida(Entidades.JSonEntidades.Concesionarios.SistemasDestino.SistemasDestino.ALCORTA.ToString(), Entidades.ConcesionarioBanco.NombreTabla, Date.Now)
            End Try
         End Using
         RaiseEvent Avance(Me, New SincronizacionMovilEventArgs(Entidades.ConcesionarioMovil.ALCORTA, "Bancos subidos correctamente."))
      End Sub
      Private Sub CargaNuevosBancos(data As String, nroRegActual As Integer, CantidadReg As Integer)
         '-- Si es nuevo Cargo todos sus datos a ML-
         Dim response = Enviar(Of Entidades.JSonEntidades.Concesionarios.Alcorta.Banco)(data, SincroMovilMetodos.POST, Me.GetHeaders(), "Bancos")
         '-- Informo del avance.- --
         My.Application.Log.WriteEntry(String.Format("SubidaConcesionariosMovil - Cargando Bancos {0} de {1}.", nroRegActual, CantidadReg), TraceEventType.Verbose)
      End Sub
      '----------------------------------------------------------------------------------------------------------------------------------------------
#End Region

#Region "Web Methods"
      Private Function Enviar(Of T)(data As String, method As SincroMovilMetodos, headers As HeadersDictionary, relativeUri As String) As T
         Dim uri = New Uri(ConcesionariosURLBase, relativeUri)
         '--------------------------------------------------------------------------------------
         GetPOSTResponse(uri, method.ToString(), data, headers, Sub(x)
                                                                   RestResponse = x
                                                                End Sub)
         Return DirectCast(New JavaScriptSerializer().Deserialize(RestResponse, GetType(T)), T)
         '--------------------------------------------------------------------------------------
      End Function
      Public Function GETResponse(Of T)(headers As HeadersDictionary, relativeUri As String) As T
         Dim uri = New Uri(ConcesionariosURLBase, relativeUri)
         Dim wc = New WebClient()
         wc.Headers.Add("ContentType", "application/json; charset=utf-8")
         wc.Headers.Add("User-Agent", "SIGA(info@sinergiasoftware.com.ar)")
         Try
            If headers IsNot Nothing Then
               For Each header As KeyValuePair(Of String, String) In headers
                  If Not String.IsNullOrWhiteSpace(header.Key) Then
                     wc.Headers.Add(header.Key, header.Value)
                  End If
               Next
            End If

            Using orResult As System.IO.Stream = wc.OpenRead(uri)
               Using reader As StreamReader = New StreamReader(orResult, New System.Text.UTF8Encoding())
                  Dim responseString As String = reader.ReadToEnd()
                  Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

                  Dim datos As T = DirectCast(serializer.Deserialize(responseString, GetType(T)), T)
                  Return datos
               End Using
            End Using

         Catch ex As WebException
            MercadoLibreExceptionHelper.MercadoLibreExceptionHandler(ex)
         End Try
      End Function
      Private Sub GetPOSTResponse(uri As Uri, metodo As String, data As String, headers As HeadersDictionary, callback As Action(Of String))

         Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(uri), HttpWebRequest)
         request.Method = metodo
         request.ContentType = "application/json"
         request.UserAgent = "SIGA(info@sinergiasoftware.com.ar)"

         '# Add headers
         If headers IsNot Nothing Then
            For Each header As KeyValuePair(Of String, String) In headers
               If Not String.IsNullOrWhiteSpace(header.Key) Then
                  request.Headers.Add(header.Key, header.Value)
               End If
            Next
         End If

         Try

            Dim encoding As New System.Text.UTF8Encoding()
            Dim bytes As Byte() = encoding.GetBytes(data)
            request.ContentLength = bytes.Length
            Using requestStream As Stream = request.GetRequestStream()
               ' Send the data.
               requestStream.Write(bytes, 0, bytes.Length)
            End Using

            request.BeginGetResponse(
             Function(x)
                Using response As HttpWebResponse = DirectCast(request.EndGetResponse(x), HttpWebResponse)
                   If callback IsNot Nothing Then
                      Using stream As Stream = response.GetResponseStream()
                         Dim reader As StreamReader = New StreamReader(stream, encoding)
                         Dim responseString As String = reader.ReadToEnd()
                         callback(responseString)
                      End Using
                   End If
                End Using
                Return 0
             End Function, Nothing)

         Catch ex As WebException
            ArboreaExceptionHelper.ArboreaExceptionHandler(ex)
         End Try
      End Sub

      '-- Obtiene el Token.- --
      Private Function GetHeaders() As HeadersDictionary
         Dim headers = New HeadersDictionary()
         headers.AgregarAuthorization(String.Format("Basic {0}",
                                                    String.Format("{0}:{1}",
                                                                  Publicos.ConcesionarioMovilUsuario,
                                                                  Publicos.ConcesionarioMovilClave).ConvertToBase64String)).AgregarEmpresa(actual.Sucursal.IdEmpresa)
         Return headers
      End Function
      Private Function GetEndpoint(control As String, id As String) As String
         Dim stb = New StringBuilder(control)
         If id IsNot Nothing Then stb.AppendFormat("/{0}", id)
         Return stb.ToString()
      End Function
      Private Function SetURLParameters(url As String, param As Dictionary(Of String, String)) As String
         For Each kv As KeyValuePair(Of String, String) In param
            If Not url.Contains("?") Then
               url += String.Format("?{0}={1}", kv.Key, kv.Value)
            Else
               url += String.Format("&{0}={1}", kv.Key, kv.Value)
            End If
         Next
         Return url
      End Function
#End Region

   End Class
End Namespace
