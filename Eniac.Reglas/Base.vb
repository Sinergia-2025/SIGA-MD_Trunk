Public Class Base
   Inherits MarshalByRefObject
   Implements IEntidad

#Region "Constantes"

   Public Const CadenaSegura As String = "CadenaSegura"
   Public Const CadenaMaster As String = "CadenaMaster"

   Public Const PrefijoInsert As String = "_I"
   Public Const PrefijoUpdate As String = "_U"
   Public Const PrefijoDelete As String = "_D"
   Public Const PrefijoObtenerTodo As String = "_GA"

#End Region

#Region "Campos"

   Private _nombreEntidad As String
   Private _dataServer As Datos.DataAccess
   Private _dataBase As String
   Private _servidor As String
   Protected da As Datos.DataAccess

#End Region

#Region "Enumeradores"

   Public Enum TipoSP
      'Insertar
      _I = 0
      'Actualizar
      _U = 1
      'Borrar
      _D = 2
      'InsertarOActualiza (Merge)
      _M = 3
   End Enum

   Public Enum AccionesSiNoExisteRegistro As Integer
      Excepcion = 0
      Nulo = 1
      Vacio = 2
   End Enum

#End Region

#Region "Constructores"

   Public Sub New()
   End Sub
   Public Sub New(entidad As String)
      Me.NombreEntidad = entidad
   End Sub
   Public Sub New(entidad As String, accesoDatos As Datos.DataAccess)
      Me.New(entidad)
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

   <Obsolete("No usar")>
   Protected Overloads Function DataServer() As Datos.DataAccess
      If _dataServer Is Nothing Then
         Me._dataServer = New Datos.DataAccess()
         Return _dataServer
      Else
         Return _dataServer
      End If
   End Function

   <Obsolete("No usar")>
   Protected Overloads Function DataServer(ByVal cadena As String) As Datos.DataAccess
      If _dataServer Is Nothing Then
         Me._dataServer = New Datos.DataAccess(cadena)
         Return _dataServer
      Else
         Return _dataServer
      End If
   End Function
   ''' <summary>
   ''' Obtiene un DataSet con todas las columnas de la entidad que lo llama
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Overridable Function GetAll() As System.Data.DataTable Implements IEntidad.GetAll
      Return da.GetDataTable(Me.NombreEntidad & "_GA")
   End Function
   Public Overridable Function GetAll(ByVal cadenaConexion As String) As System.Data.DataTable
      Return GetAll() ' Me.DataServer(cadenaConexion).GetDataTable(Me.NombreEntidad & "_GA")
   End Function
   ''' <summary>
   ''' Obtiene un DataSet de la entidad que lo llama
   ''' </summary>
   ''' <param name="filter">Es el filtro que se va a aplicar al WHERE del query
   ''' por ejemplo "nombre = 'Jaime'"</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   <Obsolete>
   Public Function GetFilter(ByVal filter As String) As System.Data.DataSet Implements IEntidad.GetFilter
      Return Me.DataServer().GetDataSet("SELECT * FROM " & Me.NombreEntidad & " WHERE " & filter)
   End Function
   Public Function GetFilter(ByVal filter As String, ByVal args() As Object) As Object Implements IEntidad.GetFilter
      Return New Object
   End Function
   Public Function GetValue(ByVal que As String, ByVal args() As Object) As Object Implements IEntidad.GetValue
      Return New Object
   End Function

   'Public Delegate Sub CargarUnoDelegate(Of T)(o As T, dr As DataRow)
   'Public Delegate Function NuevaInstanciaDelegate(Of T)() As T
   Protected Function CargaLista(Of T As Entidades.Entidad,
                                    L As ICollection(Of T))(dt As DataTable,
                                                            cargarUno As Action(Of T, DataRow),
                                                            nuevaInstancia As Func(Of T),
                                                            newCollectionAction As Func(Of L)) As L
      Return CargaLista({dt}, cargarUno, nuevaInstancia, newCollectionAction)
   End Function
   Protected Function CargaLista(Of T As Entidades.Entidad,
                                    L As ICollection(Of T))(dts As IEnumerable(Of DataTable),
                                                            cargarUno As Action(Of T, DataRow),
                                                            nuevaInstancia As Func(Of T),
                                                            newCollectionAction As Func(Of L)) As L
      Dim o As T
      Dim oLis = newCollectionAction()
      For Each dt In dts
         For Each dr As DataRow In dt.Rows
            o = nuevaInstancia()
            cargarUno(o, dr)
            oLis.Add(o)
         Next
      Next
      Return oLis
   End Function
   Protected Function CargaLista(Of T As Entidades.Entidad)(dt As DataTable,
                                                            cargarUno As Action(Of T, DataRow),
                                                            nuevaInstancia As Func(Of T)) As List(Of T)
      Return CargaLista(dt, cargarUno, nuevaInstancia, Function() New List(Of T)())
   End Function

   Protected Function CargaEntidad(Of T As Entidades.Entidad)(dt As DataTable,
                                                              cargarUno As Action(Of T, DataRow),
                                                              nuevaInstancia As Func(Of T),
                                                              accion As AccionesSiNoExisteRegistro,
                                                              mensajeExcepcionSiNoExiste As String) As T
      Return CargaEntidad(dt, cargarUno, nuevaInstancia, accion, Function() mensajeExcepcionSiNoExiste)
   End Function
   Protected Function CargaEntidad(Of T As Entidades.Entidad)(dt As DataTable,
                                                              cargarUno As Action(Of T, DataRow),
                                                              nuevaInstancia As Func(Of T),
                                                              accion As AccionesSiNoExisteRegistro,
                                                              mensajeExcepcion As Func(Of String)) As T
      Dim o As T = nuevaInstancia()
      If dt.Rows.Count > 0 Then
         cargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Dim msj As String = If(mensajeExcepcion IsNot Nothing, mensajeExcepcion(), "")
            If String.IsNullOrWhiteSpace(msj) Then
               Throw New Exception("No se encontró el registro")
            Else
               Throw New Exception(msj)
            End If
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If
      Return o
   End Function

   Protected Sub EjecutaConTransaccion(accion As Action)
      EjecutaConTransaccion(Function()
                               accion()
                               Return True
                            End Function)
   End Sub
   Protected Function EjecutaConTransaccion(Of TResult)(accion As Func(Of TResult)) As TResult
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim result = accion()

         da.CommitTransaction()

         Return result
      Catch ex As Exception
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Function

   Public Sub EjecutaSoloConTransaccion(accion As Action)
      EjecutaSoloConTransaccion(Function()
                                   accion()
                                   Return True
                                End Function)
   End Sub
   Public Function EjecutaSoloConTransaccion(Of TResult)(accion As Func(Of TResult)) As TResult
      Try
         da.BeginTransaction()

         Dim result = accion()

         da.CommitTransaction()

         Return result
      Catch
         da.RollbakTransaction()
         Throw
      End Try
   End Function

   Protected Sub EjecutaConConexion(accion As Action)
      EjecutaConConexion(Function()
                            accion()
                            Return True
                         End Function)
   End Sub
   Protected Function EjecutaConConexion(Of T)(accion As Func(Of T)) As T
      Try
         da.OpenConection()
         Return accion()
      Finally
         da.CloseConection()
      End Try
   End Function

#End Region

#Region "Overridable"

   Public Overridable Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Throw New Exception("Falta sobreescribir el Borrar")
   End Sub
   Public Overridable Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Throw New Exception("Falta sobreescribir el Insertar")
   End Sub
   Public Overridable Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Throw New Exception("Falta sobreescribir el Actualizar")
   End Sub
   Public Overridable Function Buscar(ByVal args As Eniac.Entidades.Buscar) As DataTable
      Throw New Exception("Falta sobreescribir el Buscar")
      Return Nothing
   End Function

#End Region

#Region "Propiedades"

   Public Property DataBase() As String Implements IEntidad.DataBase
      Get
         Return Me._dataBase
      End Get
      Set(ByVal value As String)
         Me._dataBase = value
      End Set
   End Property
   Public Property Id() As Integer Implements IEntidad.Id
      Get

      End Get
      Set(ByVal value As Integer)

      End Set
   End Property
   Public Property NombreEntidad() As String Implements IEntidad.NombreEntidad
      Get
         Return Me._nombreEntidad
      End Get
      Set(ByVal value As String)
         Me._nombreEntidad = value
      End Set
   End Property
   Public Property Servidor() As String Implements IEntidad.Servidor
      Get
         Return Me._servidor
      End Get
      Set(ByVal value As String)
         Me._servidor = value
      End Set
   End Property

#End Region

#Region "Trace"
   Protected Sub LogV(mensaje As String)
      My.Application.Log.WriteEntry(String.Concat(mensaje, String.Format(" {0:dd/MM/yyyy HH:mm:ss.fff}", Now)), TraceEventType.Verbose)
   End Sub


   Dim log As Eniac.Ayudantes.EniacTrace
   Public Sub LogAbrir(ByVal file As String, ByVal nombreTrace As String)
      Dim tracea As String = New Eniac.Reglas.Parametros().GetValorPD("TRACEA", "")
      Dim bal As Boolean = False
      If Not String.IsNullOrEmpty(tracea) Then
         bal = Boolean.Parse(tracea)
      End If
      log = New Eniac.Ayudantes.EniacTrace(bal)
      log.LogAbrir(file, nombreTrace)
   End Sub

   Public Sub LogAgregarMensaje(ByVal mensaje As String)
      log.LogAgregarMensaje(mensaje)
   End Sub

   Public Sub LogCerrar(ByVal nombreTrace As String)
      log.LogCerrar(nombreTrace)
   End Sub

#End Region

End Class

Public MustInherit Class BaseSync(Of T, E)
   Inherits Base
   Implements ServiciosRest.Sincronizacion.ISyncRegla(Of T, E)
#Region "Constructores"

   Public Sub New()
      MyBase.New()
   End Sub
   Public Sub New(entidad As String)
      MyBase.New(entidad)
   End Sub
   Public Sub New(entidad As String, accesoDatos As Datos.DataAccess)
      MyBase.New(entidad, accesoDatos)
   End Sub

#End Region

   Public Event AvanceValidarDatos(sender As Object, e As ServiciosRest.Sincronizacion.AvanceProcesoEventArgs) Implements ServiciosRest.Sincronizacion.ISyncRegla(Of T, E).AvanceValidarDatos
   Public Event AvanceImportarDatos(sender As Object, e As ServiciosRest.Sincronizacion.AvanceProcesoEventArgs) Implements ServiciosRest.Sincronizacion.ISyncRegla(Of T, E).AvanceImportarDatos

   Protected Overridable Sub OnAvanceValidarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceValidarDatos(Me, New ServiciosRest.Sincronizacion.AvanceProcesoEventArgs(eventArgs.RegistroActual, eventArgs.TotalRegistros, DirectCast(eventArgs.Datos, Entidades.JSonEntidades.Archivos.IValidable)))
   End Sub

   Protected Overridable Sub OnAvanceImportarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceImportarDatos(Me, New ServiciosRest.Sincronizacion.AvanceProcesoEventArgs(eventArgs.RegistroActual, eventArgs.TotalRegistros, DirectCast(eventArgs.Datos, Entidades.JSonEntidades.Archivos.IValidable)))
   End Sub

   Protected Function SetErrorMessage(stb As StringBuilder, entidad As Entidades.JSonEntidades.Archivos.IValidable, mensaje As String) As Boolean
      Return SetErrorMessage(stb, entidad, mensaje, columnName:=String.Empty)
   End Function
   Protected Function SetErrorMessage(stb As StringBuilder, entidad As Entidades.JSonEntidades.Archivos.IValidable, mensaje As String, columnName As String) As Boolean
      stb.AppendFormat(mensaje)
      If entidad.drOrigen IsNot Nothing Then entidad.drOrigen.SetColumnError(columnName, mensaje)
      Return True
   End Function

   Protected Sub SetEstadoRow(en As Entidades.JSonEntidades.Archivos.IValidable, stb As StringBuilder, existe As Func(Of E, Boolean))
      If en.ConErrores Then
         en.___Estado = "E"
         en.___MensajeError = stb.ToString()
         If en.drOrigen IsNot Nothing Then
            en.drOrigen("___estado") = "E"
            en.drOrigen("___mensajeError") = en.___MensajeError
         End If
      Else
         If existe(DirectCast(en, E)) Then
            en.___Estado = "M"
            If en.drOrigen IsNot Nothing Then en.drOrigen("___estado") = "M"
         Else
            en.___Estado = "A"
            If en.drOrigen IsNot Nothing Then en.drOrigen("___estado") = "A"
         End If
      End If

   End Sub

   Protected Function CheckAlgunError(Of TVal As Entidades.JSonEntidades.Archivos.IValidable)(col As IList(Of TVal)) As Boolean
      Return Not col.Any(Function(x) x.___Estado = "E")
   End Function

   Public Function ValidarDatos(transporteList As List(Of T), syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean Implements ServiciosRest.Sincronizacion.ISyncRegla(Of T, E).ValidarDatos
      Return ValidarDatos(Convertir(transporteList), syncs)
   End Function
   Public Function ImportarDatos(transporte As List(Of T)) As Boolean Implements ServiciosRest.Sincronizacion.ISyncRegla(Of T, E).ImportarDatos
      Return ImportarDatos(Convertir(transporte))
   End Function
   Protected Function GetCollection(Of TCol)(syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As List(Of TCol)
      Return DirectCast(If(syncs Is Nothing, Nothing, syncs.DatosRecibidosCustom(GetType(TCol))), List(Of TCol))
   End Function


   Public MustOverride Function Convertir(transporte As List(Of T)) As List(Of E) Implements ServiciosRest.Sincronizacion.ISyncRegla(Of T, E).Convertir
   Public MustOverride Function ValidarDatos(col As List(Of E), syncs As Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean Implements ServiciosRest.Sincronizacion.ISyncRegla(Of T, E).ValidarDatos
   Public MustOverride Function ImportarDatos(transporte As List(Of E)) As Boolean Implements ServiciosRest.Sincronizacion.ISyncRegla(Of T, E).ImportarDatos

End Class