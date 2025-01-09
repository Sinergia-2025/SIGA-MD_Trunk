#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace ServiciosRest.Sincronizacion
   Partial Class SyncBase(Of T, E)

      Protected Event NotificarEstadoVerbose(sender As Object, e As NotificarEstadoEventDetalladoArgs) Implements ISyncBase.NotificarEstadoVerbose
      Protected Event NotificarEstadoInformation(sender As Object, e As NotificarEstadoEventDetalladoArgs) Implements ISyncBase.NotificarEstadoInformation

      Protected Event ObteniendoFechaUltimaActualizacion(sender As Object, e As EnviarDatosEventArgs)
      Protected Event LuegoObteniendoFechaUltimaActualizacion(sender As Object, e As FechaUltimaActualizacionEventArgs)

      Protected Event ObtenerCantidadRegistros(sender As Object, e As EnviarDatosEventArgs)
      Protected Event LuegoObtenerCantidadRegistros(sender As Object, e As CantidadRegistrosEventArgs) Implements ISyncBase.LuegoObtenerCantidadRegistros

      Protected Event AntesGet(sender As Object, e As SyncEventArgs)
      Protected Event DespuesGet(sender As Object, e As DespuesGetEventArgs)

      Protected Event AntesPaginar(sender As Object, e As DespuesGetEventArgs)
      Protected Event DespuesPaginar(sender As Object, e As DespuesPaginarEventArgs)

      Protected Event AntesEnviarDatos(sender As Object, e As EnviarDatosPaginaInicialEventArgs)
      Protected Event EnviandoDatos(sender As Object, e As EnviarDatosPaginaEventArgs)
      Protected Event EnvioDatosFinalizado(sender As Object, e As EnviarDatosPaginaEventArgs)
      Protected Event DespuesEnviarDatos(sender As Object, e As EnviarDatosEventArgs)

      Protected Event AntesBorrarDatos(sender As Object, e As EnviarDatosEventArgs)
      Protected Event LuegoBorrarDatos(sender As Object, e As EnviarDatosEventArgs)


      Protected Sub OnNotificarEstadoVerbose(estado As String)
         RaiseEvent NotificarEstadoVerbose(Me, New NotificarEstadoEventDetalladoArgs(GetType(T), estado))
      End Sub
      Protected Sub OnNotificarEstadoInformation(estado As String)
         OnNotificarEstadoVerbose(estado)
         RaiseEvent NotificarEstadoInformation(Me, New NotificarEstadoEventDetalladoArgs(GetType(T), estado))
      End Sub



      Protected Sub OnObteniendoFechaUltimaActualizacion(url As String)
         OnNotificarEstadoVerbose(String.Format("Antes de Obtener Fecha última actualización. URL: {0}", url))
         RaiseEvent ObteniendoFechaUltimaActualizacion(Me, New EnviarDatosEventArgs(GetType(T), url))
      End Sub
      Protected Sub OnLuegoObteniendoFechaUltimaActualizacion(url As String, fechaUltimaActualizacion As DateTime?)
         OnNotificarEstadoInformation(String.Format("Luego de Obtener Fecha última actualización. Fecha: {1} - URL: {0}", url, fechaUltimaActualizacion.ToStringValue("(null)")))
         RaiseEvent LuegoObteniendoFechaUltimaActualizacion(Me, New FechaUltimaActualizacionEventArgs(GetType(T), url, fechaUltimaActualizacion))
      End Sub

      Protected Sub OnObtenerCantidadRegistros(url As String)
         OnNotificarEstadoVerbose(String.Format("Antes de Obtener cantidad de registros. URL: {0}", url))
         RaiseEvent ObtenerCantidadRegistros(Me, New EnviarDatosEventArgs(GetType(T), url))
      End Sub
      Protected Sub OnLuegoObtenerCantidadRegistros(url As String, cantidadRegistros As Long)
         OnNotificarEstadoInformation(String.Format("Luego de Obtener cantidad de registros. Cantidad: {1} - URL: {0}", url, cantidadRegistros))
         RaiseEvent LuegoObtenerCantidadRegistros(Me, New CantidadRegistrosEventArgs(GetType(T), url, cantidadRegistros))
      End Sub


      Protected Sub OnAntesGet()
         OnNotificarEstadoVerbose(String.Format("Antes de Obtener Información"))
         RaiseEvent AntesGet(Me, New SyncEventArgs(GetType(T)))
      End Sub
      Protected Sub OnDespuesGet(datos As IList)
         OnNotificarEstadoInformation(String.Format("Luego de Obtener Información. Count: {0}", datos.Count))
         RaiseEvent DespuesGet(Me, New DespuesGetEventArgs(GetType(T), datos))
      End Sub

      Protected Sub OnAntesPaginar(datos As IList)
         OnNotificarEstadoVerbose(String.Format("Antes de paginar. Count datos: {0}", datos.Count))
         RaiseEvent AntesPaginar(Me, New DespuesGetEventArgs(GetType(T), datos))
      End Sub
      Protected Sub OnDespuesPaginar(datos As IList, paginas As IList)
         OnNotificarEstadoInformation(String.Format("Luego de paginar. Count datos: {0}. Count paginas: {1}", datos.Count, paginas.Count))
         RaiseEvent DespuesPaginar(Me, New DespuesPaginarEventArgs(GetType(T), datos, paginas))
      End Sub

      Protected Sub OnAntesBorrarDatos(url As String)
         OnNotificarEstadoInformation(String.Format("Antes de borrar para reenviar. URL: {0}", url))
         RaiseEvent AntesBorrarDatos(Me, New EnviarDatosEventArgs(GetType(T), url))
      End Sub
      Protected Sub OnLuegoBorrarDatos(url As String)
         OnNotificarEstadoVerbose(String.Format("Luego de borrar para reenviar. URL: {0}", url))
         RaiseEvent LuegoBorrarDatos(Me, New EnviarDatosEventArgs(GetType(T), url))
      End Sub

      Protected Sub OnAntesEnviarDatos(url As String, paginaInicial As Integer)
         OnNotificarEstadoInformation(String.Format("Antes de enviar información. URL: {0} - Inicia en página: {1}", url, paginaInicial))
         RaiseEvent AntesEnviarDatos(Me, New EnviarDatosPaginaInicialEventArgs(GetType(T), url, paginaInicial))
      End Sub

      Protected Sub OnEnviandoDatos(url As String, paginaInicial As Integer, paginaActual As Integer, totalPaginas As Integer)
         paginaActual += 1
         OnNotificarEstadoVerbose(String.Format("Antes de enviar página: {2}/{3}. URL: {0} - Inicia en página: {1}", url, paginaInicial, paginaActual, totalPaginas))
         RaiseEvent EnviandoDatos(Me, New EnviarDatosPaginaEventArgs(GetType(T), url, paginaInicial, paginaActual, totalPaginas))
      End Sub
      Protected Sub OnEnvioDatosFinalizado(url As String, paginaInicial As Integer, paginaActual As Integer, totalPaginas As Integer)
         paginaActual += 1
         OnNotificarEstadoInformation(String.Format("Luego de enviar página: {2}/{3}. URL: {0} - Inicia en página: {1}", url, paginaInicial, paginaActual, totalPaginas))
         RaiseEvent EnviandoDatos(Me, New EnviarDatosPaginaEventArgs(GetType(T), url, paginaInicial, paginaActual, totalPaginas))
      End Sub
      Protected Sub OnDespuesEnviarDatos(url As String)
         OnNotificarEstadoVerbose(String.Format("Luego de enviar información. URL: {0}", url))
         RaiseEvent DespuesEnviarDatos(Me, New EnviarDatosEventArgs(GetType(T), url))
      End Sub


      Public Event AntesRecibirDatos(sender As Object, e As EnviarDatosPaginaInicialEventArgs)
      Public Event RecibiendoDatos(sender As Object, e As RecibiendoDatosPaginaInicialEventArgs) Implements ISyncBase.RecibiendoDatos
      Public Event RecibiendoDatosFinalizado(sender As Object, e As RecibiendoDatosPaginaInicialEventArgs) Implements ISyncBase.RecibiendoDatosFinalizado
      Public Event DespuesRecibiendoDatos(sender As Object, e As DatosRecibidosEventArgs) Implements ISyncBase.DespuesRecibiendoDatos

      Protected Sub OnAntesRecibirDatos(url As String, paginaInicial As Integer)
         OnNotificarEstadoInformation(String.Format("Antes de recibir información. URL: {0} - Inicia en página: {1}", url, paginaInicial))
         RaiseEvent AntesRecibirDatos(Me, New EnviarDatosPaginaInicialEventArgs(GetType(T), url, paginaInicial))
      End Sub
      Protected Sub OnRecibiendoDatos(url As String, paginaActual As Integer, registrosRecibidos As Integer)
         paginaActual += 1
         OnNotificarEstadoVerbose(String.Format("Antes de recibir página actual: {1}. URL: {0}", url, paginaActual))
         RaiseEvent RecibiendoDatos(Me, New RecibiendoDatosPaginaInicialEventArgs(GetType(T), url, paginaActual, registrosRecibidos))
      End Sub
      Protected Sub OnRecibiendoDatosFinalizado(url As String, paginaActual As Integer, registrosRecibidos As Integer)
         paginaActual += 1
         OnNotificarEstadoInformation(String.Format("Luego de recibir página: {1}. URL: {0}", url, paginaActual))
         RaiseEvent RecibiendoDatosFinalizado(Me, New RecibiendoDatosPaginaInicialEventArgs(GetType(T), url, paginaActual, registrosRecibidos))
      End Sub
      Protected Sub OnDespuesRecibiendoDatos(url As String, datos As IList, totalPaginas As Integer)
         OnNotificarEstadoVerbose(String.Format("Luego de recibir datos - Cantidad Recibida: {1}. URL: {0}", url, datos.Count))
         RaiseEvent DespuesRecibiendoDatos(Me, New DatosRecibidosEventArgs(GetType(T), url, datos, totalPaginas))
      End Sub


      Protected Event AntesValidarDatos(sender As Object, e As SyncEventArgs)
      Protected Event AvanceValidarDatos(sender As Object, e As SyncAvanceEventArgs)
      Protected Event DespuesValidarDatos(sender As Object, e As SyncEventArgs)
      Public Sub OnAntesValidarDatos()
         OnNotificarEstadoInformation(String.Format("Antes de validar registro"))
         RaiseEvent AntesValidarDatos(Me, New SyncEventArgs(GetType(T)))
      End Sub
      Protected Sub OnAvanceValidarDatos(registroActual As Long, totalRegistros As Long, estado As String)
         OnNotificarEstadoVerbose(String.Format("Validando registro {0}/{1}: {2}", registroActual, totalRegistros, estado))
         RaiseEvent AvanceValidarDatos(Me, New SyncAvanceEventArgs(GetType(T), registroActual, totalRegistros, estado))
      End Sub
      Public Sub OnDespuesValidarDatos()
         OnNotificarEstadoVerbose(String.Format("Después de validar registro"))
         RaiseEvent DespuesValidarDatos(Me, New SyncEventArgs(GetType(T)))
      End Sub

      Protected Event AntesImportarDatos(sender As Object, e As SyncEventArgs)
      Protected Event AvanceImportarDatos(sender As Object, e As SyncAvanceEventArgs)
      Protected Event DespuesImportarDatos(sender As Object, e As SyncEventArgs)
      Protected Sub OnAntesImportarDatos()
         OnNotificarEstadoInformation(String.Format("Antes de importar registro"))
         RaiseEvent AntesImportarDatos(Me, New SyncEventArgs(GetType(T)))
      End Sub
      Protected Sub OnAvanceImportarDatos(registroActual As Long, totalRegistros As Long, estado As String)
         OnNotificarEstadoVerbose(String.Format("Importar registro {0}/{1}: {2}", registroActual, totalRegistros, estado))
         RaiseEvent AvanceImportarDatos(Me, New SyncAvanceEventArgs(GetType(T), registroActual, totalRegistros, estado))
      End Sub
      Protected Sub OnDespuesImportarDatos()
         OnNotificarEstadoVerbose(String.Format("Después de importar registro"))
         RaiseEvent DespuesImportarDatos(Me, New SyncEventArgs(GetType(T)))
      End Sub

   End Class

#Region "EventArgs"
   Public Class SyncEventArgs
      Inherits EventArgs
      Public Property Tipo As Type
      Public Sub New(tipo As Type)
         Me.Tipo = tipo
      End Sub
   End Class

   Public Class SyncAvanceEventArgs
      Inherits SyncEventArgs
      Public Property RegistroActual As Long
      Public Property TotalRegistros As Long
      Public Property Estado As String
      Public Sub New(tipo As Type, registroActual As Long, totalRegistros As Long, estado As String)
         MyBase.New(tipo)
         Me.RegistroActual = registroActual
         Me.TotalRegistros = totalRegistros
         Me.Estado = estado
      End Sub

   End Class


   Public Class NotificarEstadoEventDetalladoArgs
      Inherits SyncEventArgs
      Public Property Estado As String
      Public Sub New(tipo As Type, estado As String)
         MyBase.New(tipo)
         Me.Estado = estado
      End Sub
   End Class

   Public Class DespuesGetEventArgs
      Inherits SyncEventArgs
      Public Property Datos As IList
      Public ReadOnly Property Count As Integer
         Get
            Return Datos.Count
         End Get
      End Property

      Public Sub New(tipo As Type, datos As IList)
         MyBase.New(tipo)
         Me.Datos = datos
      End Sub
   End Class

   Public Class DespuesPaginarEventArgs
      Inherits SyncEventArgs
      Public Property Datos As IList
      Public ReadOnly Property Count As Integer
         Get
            Return Datos.Count
         End Get
      End Property
      Public Property Paginas As IList
      Public ReadOnly Property CountPaginas As Integer
         Get
            Return Paginas.Count
         End Get
      End Property

      Public Sub New(tipo As Type, datos As IList, paginas As IList)
         MyBase.New(tipo)
         Me.Datos = datos
         Me.Paginas = paginas
      End Sub
   End Class

   Public Class EnviarDatosEventArgs
      Inherits SyncEventArgs
      Public Property Url As String
      Public Sub New(tipo As Type, url As String)
         MyBase.New(tipo)
         Me.Url = url
      End Sub

   End Class

   Public Class FechaUltimaActualizacionEventArgs
      Inherits EnviarDatosEventArgs
      Public Property FechaUltimaActualizacion As DateTime?
      Public Sub New(tipo As Type, url As String, fechaUltimaActualziacion As DateTime?)
         MyBase.New(tipo, url)
         Me.FechaUltimaActualizacion = FechaUltimaActualizacion
      End Sub

   End Class
   Public Class CantidadRegistrosEventArgs
      Inherits EnviarDatosEventArgs
      Public Property CantidadRegistros As Long
      Public Sub New(tipo As Type, url As String, cantidadRegistros As Long)
         MyBase.New(tipo, url)
         Me.CantidadRegistros = cantidadRegistros
      End Sub

   End Class

   Public Class EnviarDatosPaginaInicialEventArgs
      Inherits EnviarDatosEventArgs
      Public Property PaginaInicial As Integer
      Public Sub New(tipo As Type, url As String, paginaInicial As Integer)
         MyBase.New(tipo, url)
         Me.PaginaInicial = paginaInicial
      End Sub

   End Class

   Public Class RecibiendoDatosPaginaInicialEventArgs
      Inherits EnviarDatosEventArgs
      Public Property PaginaActual As Integer
      Public Property RegistrosRecibidos As Integer
      Public Sub New(tipo As Type, url As String, paginaActual As Integer, registrosRecibidos As Integer)
         MyBase.New(tipo, url)
         Me.PaginaActual = paginaActual
         Me.RegistrosRecibidos = registrosRecibidos
      End Sub

   End Class

   Public Class DatosRecibidosEventArgs
      Inherits EnviarDatosEventArgs
      Public Property Datos As IList
      Public Property TotalPaginas As Integer
      Public ReadOnly Property Count As Integer
         Get
            Return Datos.Count
         End Get
      End Property
      Public Sub New(tipo As Type, url As String, datos As IList, totalPaginas As Integer)
         MyBase.New(tipo, url)
         Me.Datos = datos
         Me.TotalPaginas = totalPaginas
      End Sub

   End Class


   Public Class EnviarDatosPaginaEventArgs
      Inherits EnviarDatosPaginaInicialEventArgs
      Public Property PaginaActual As Integer
      Public Property TotalPaginas As Integer
      Public Sub New(tipo As Type, url As String, paginaInicial As Integer, paginaActual As Integer, totalPaginas As Integer)
         MyBase.New(tipo, url, paginaInicial)
         Me.PaginaActual = paginaActual
         Me.TotalPaginas = totalPaginas
      End Sub

   End Class
#End Region

End Namespace