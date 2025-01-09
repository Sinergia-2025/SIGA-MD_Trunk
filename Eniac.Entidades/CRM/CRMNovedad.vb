Imports System.Drawing
Public Class CRMNovedad
   Inherits CRMEntidad

   Public Enum Columnas
      IdTipoNovedad
      Letra
      CentroEmisor
      IdNovedad
      FechaNovedad
      Descripcion
      IdPrioridadNovedad
      IdCategoriaNovedad
      IdEstadoNovedad
      FechaEstadoNovedad
      IdUsuarioEstadoNovedad
      FechaAlta
      IdUsuarioAlta
      IdUsuarioAsignado
      Avance
      IdMedioComunicacionNovedad
      IdCliente
      IdProspecto
      IdProveedor
      IdFuncion
      IdSistema
      FechaProximoContacto
      BanderaColor
      Interlocutor
      IdMetodoResolucionNovedad
      IdProyecto
      RevisionAdministrativa
      Priorizado
      IdTipoNovedadPadre
      LetraPadre
      CentroEmisorPadre
      IdNovedadPadre
      Version
      VersionFecha
      FechaInicioPlan
      FechaFinPlan
      TiempoEstimado
      IdUsuarioResponsable
      Cantidad
      IdSucursalService
      '-- REQ-31656.- --
      IdSucursalNovedad
      '-----------------
      IdTipoComprobanteService
      LetraService
      CentroEmisorService
      NumeroComprobanteService
      IdProducto
      NombreProducto
      CantidadProducto
      CostoReparacion
      IdProductoPrestado
      CantidadProductoPrestado
      NroSerieProductoPrestado
      ProductoPrestadoDevuelto
      IdProveedorService
      Contador1
      Contador2
      FechaActualizacionWeb
      IdProductoNovedad
      EtiquetaNovedad
      NroDeSerie
      TieneGarantiaService
      UbicacionService
      IdSucursalFact
      IdTipoComprobanteFact
      LetraFact
      CentroEmisorFact
      NumeroComprobanteFact
      RequiereTesteo
      FechaEntregado
      FechaFinalizado
      IdEstadoNovedadEntregado
      IdEstadoNovedadFinalizado
      IdUsuarioEntregado
      IdUsuarioFinalizado
      IdEstadoNovedadAnterior
      AvanceAnterior
      Observacion
      ClienteValorizacionEstrellas
      MarcaCRMFecha
      '-- REQ-31756/31871/31988 - Carga Domicilios de Entrega-Retiro - Proveedor Garantia.- --
      FechaHoraRetiro
      IdDomicilioRetiro
      FechaHoraEntrega
      IdDomicilioEntrega
      IdProveedorGarantia
      NombreProveedor
      FechaHoraEnvioGarantia
      FechaHoraRetiroGarantia
      AnticipoNovedad
      '-- REQ-31825.- --
      idMarcaProducto
      NombreMarcaProducto
      idModeloProducto
      NombreModeloProducto
      '-- REQ-31709.- --
      AjustarStock

      ServiceLugarCompra
      ServiceLugarCompraFecha
      ServiceLugarCompraTipoComprobante
      ServiceLugarCompraNumeroComprobante

      IdAplicacionTerceros
      IdMotivoNovedad
      ComentarioPrincipal

      PatenteVehiculo

   End Enum

   Enum ColInformeDeNovedades As Integer
      <Description("Avance")> N__Avance
      <Description("Categoría")> CN_NombreCategoriaNovedad
      <Description("Cliente")> C__NombreCliente
      <Description("Estado Novedad")> EN__NombreEstadoNovedad
      <Description("Fecha Estado Novedad")> N__FechaEstadoNovedad
      <Description("Fecha Novedad")> N__FechaNovedad
      <Description("Fecha Próximo Contacto")> N__FechaProximoContacto
      <Description("Id Novedad")> N__IdNovedad
      <Description("Interlocutor")> N__Interlocutor
      <Description("Medio Comunicación")> MN__NombreMedioComunicacionNovedad
      <Description("Prioridad")> PN__NombrePrioridadNovedad
      <Description("Prospecto")> P__NombreProspecto
      <Description("Proveedor")> PR__NombreProveedor
      <Description("Usuario Asignado")> UG__Nombre

   End Enum

   Public Enum ColumnasAdicionales
      NuevoComentario
      NuevoAdjunto
   End Enum

   Public Enum TipoFechaFiltro
      <Description("Fecha")> FechaNovedad
      <Description("Fecha Estado")> FechaEstadoNovedad
      <Description("Fecha Alta")> FechaAlta
      <Description("Fecha Prox. Contacto")> FechaProximoContacto
      <Description("Fecha Versión")> VersionFecha
      <Description("Fecha Inicio Plan")> FechaInicioPlan
      <Description("Fecha Fin Plan")> FechaFinPlan
      <Description("Fecha Act. Web")> FechaActualizacionWeb
      <Description("Fecha Reparado")> FechaEntregado
      <Description("Fecha Entregado")> FechaFinalizado
      <Description("Fecha de Entrega Garantia")> FechaHoraEnvioGarantia
      <Description("Fecha de Retiro Garantia")> FechaHoraRetiroGarantia
      <Description("Fecha de Entrega ")> FechaHoraEntrega
      <Description("Fecha de Retiro ")> FechaHoraRetiro


      <Category("Seguimiento"), Browsable(False), Description("Fecha Seguimiento")> FechaSeguimiento
      <Category("CambioEstado"), Browsable(False), Description("Fecha Cambio Estado")> FechaCambioEstado
   End Enum

   Public Enum TipoUsuarioFiltro
      <Description("Usuario Asigando")> N___IdUsuarioAsignado
      <Description("Usuario Estado Actual")> N___IdUsuarioEstadoNovedad
      <Description("Usuario Responsable")> N___IdUsuarioResponsable
      <Description("Usuario Reparado")> N___IdUsuarioEntregado
      <Description("Usuario Entregado")> N___IdUsuarioFinalizado
      <Description("Usuario Alta")> N___IdUsuarioAlta
      <Browsable(False), Description("Usuario Comentario")> NS___UsuarioSeguimiento
      <Browsable(False), Description("Usuario Asignado Comentario")> NS___UsuarioAsignado
   End Enum

   Public Enum EstadosProductosPrestados
      TODOS
      DEVUELTO
      PENDIENTE
   End Enum

   Public Enum ComentarioPrincipalOptiones
      <Description("Ninguno")> Ninguno
      <Description("Primero")> Primero
      <Description("Último")> Ultimo
      <Description("Manual")> Manual
   End Enum

   Public Sub New()
      PrioridadNovedad = New CRMPrioridadNovedad()
      CategoriaNovedad = New CRMCategoriaNovedad()
      MedioComunicacionNovedad = New CRMMedioComunicacionNovedad()
      EstadoNovedad = New CRMEstadoNovedad()
      UsuarioAsignado = New Usuario()
      UsuarioEstadoNovedad = New Usuario()
      UsuarioAlta = New Usuario()
      Seguimientos = New List(Of CRMNovedadSeguimiento)()
      ProductosNovedad = New List(Of CRMNovedadProducto)()
      SeguimientosBorrados = New List(Of CRMNovedadSeguimiento)()
      CambiosEstados = New List(Of CRMNovedadCambioEstado)()
      CambiosEstadosAgrupado = New List(Of CRMNovedadCambioEstado)()
      FechaNovedad = Now
      CentroEmisor = 1
      ComentarioPrincipal = ComentarioPrincipalOptiones.Primero
   End Sub

   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property IdNovedad As Long
   Public Property FechaNovedad As Date
   Public Property Descripcion As String
   Public Property PrioridadNovedad As CRMPrioridadNovedad
   Public Property CategoriaNovedad As CRMCategoriaNovedad
   Public Property MedioComunicacionNovedad As CRMMedioComunicacionNovedad
   Public Property MetodoResolucionNovedad As CRMMetodoResolucionNovedad
   Public Property EstadoNovedad As CRMEstadoNovedad
   Public Property FechaEstadoNovedad As Date?
   Public Property UsuarioEstadoNovedad As Usuario
   Public Property FechaAlta As Date
   Public Property UsuarioAlta As Usuario
   Public Property UsuarioAsignado As Usuario
   Public Property UsuarioResponsable As Usuario
   Public Property Avance As Decimal

   Public Property NuevoComentario As String                      'Para pasar de pantalla un nuevo comentario y que lo agregue en la colección la regla
   Public Property NuevoAdjunto As String                         'Para pasar de pantalla un nuevo comentario y que lo agregue en la colección la regla
   Public Property NuevoIdTipoComentarioNovedad As Integer        'Para pasar de pantalla un nuevo comentario y que lo agregue en la colección la regla

   Public Property IdCliente As Long
   Public Property ClienteValorizacionEstrellas As Decimal?
   Public Property MarcaCRMFecha As Boolean
   Public Property IdProyecto As Integer
   Public Property IdProspecto As Long
   Public Property IdProveedor As Long
   Public Property IdFuncion As String
   Public Property IdSistema As String

   Public Property FechaProximoContacto As Date?
   Public Property BanderaColor As Color?

   Private _interlocutor As String = String.Empty
   Public Property Interlocutor As String
      Get
         Return Me._interlocutor
      End Get
      Set(value As String)
         Me._interlocutor = value
      End Set
   End Property

   Public Property ProductosNovedad As List(Of CRMNovedadProducto)
   Public Property Seguimientos As List(Of CRMNovedadSeguimiento)
   Public Property SeguimientosBorrados As List(Of CRMNovedadSeguimiento)
   Public Property CambiosEstados As List(Of CRMNovedadCambioEstado)
   Public Property CambiosEstadosAgrupado As List(Of CRMNovedadCambioEstado)

   Public Property RevisionAdministrativa As Boolean
   Public Property Priorizado As Boolean
   Public Property IdTipoNovedadPadre As String
   Public Property LetraPadre As String
   Public Property CentroEmisorPadre As Short
   Public Property IdNovedadPadre As Long
   Public Property DescripcionPadre As String '# Esta propiedad no se guarda en bd
   Public Property Version As String
   Public Property VersionFecha As Date?
   Public Property FechaInicioPlan As Date?
   Public Property FechaFinPlan As Date?

   Public Property TiempoEstimado As Decimal

   Public Property Cantidad As Decimal

   Public Property IdSucursalService As Integer
   Public Property IdTipoComprobanteService As String
   Public Property LetraService As String
   Public Property CentroEmisorService As Short
   Public Property NumeroComprobanteService As Long
   Public Property IdProducto As String
   Public Property NombreProducto As String
   Public Property CantidadProducto As Decimal
   Public Property CostoReparacion As Decimal
   Public Property IdProductoPrestado As String
   Public Property NombreProductoPrestado As String '# Esta propiedad no se persiste. Se utiliza solo para visualización.
   Public Property CantidadProductoPrestado As Decimal
   Public Property NroSerieProductoPrestado As String
   Public Property ProductoPrestadoDevuelto As Boolean
   Public Property IdProveedorService As Long
   Public Property Contador1 As Integer
   Public Property Contador2 As Integer
   Public Property FechaActualizacionWeb As DateTime
   Public Property IdProductoNovedad As String
   Public Property EtiquetaNovedad As String
   Public Property NroDeSerie As String
   Public Property TieneGarantiaService As Boolean?
   Public Property UbicacionService As String
   Public Property IdSucursalFact As Integer?
   Public Property IdTipoComprobanteFact As String
   Public Property LetraFact As String
   Public Property CentroEmisorFact As Integer?
   Public Property NumeroComprobanteFact As Long?

   Public Property FechaEntregado As Date?
   Public Property FechaFinalizado As Date?
   Public Property IdEstadoNovedadEntregado As Integer?
   Public Property IdEstadoNovedadFinalizado As Integer?

   Public Property IdUsuarioEntregado As String
   Public Property IdUsuarioFinalizado As String
   Public Property IdEstadoNovedadAnterior As Integer?
   Public Property AvanceAnterior As Decimal?

   Public Property RequiereTesteo As Boolean
   Public Property Observacion As String


   '-- REQ-31756/31871/31988 - Carga Domicilios de Entrega-Retiro - Proveedor Garantia.- --
   Public Property AnticipoNovedad As Decimal
   Public Property FechaHoraRetiro As Date?
   Public Property IdDomicilioRetiro As Integer?
   Public Property FechaHoraEntrega As Date?
   Public Property IdDomicilioEntrega As Integer?
   Public Property IdProveedorGarantia As Long?
   Public Property FechaHoraEnvioGarantia As Date?
   Public Property FechaHoraRetiroGarantia As Date?
   '-- REQ-31756/31871/31988 - Carga Domicilios de Entrega-Retiro - Proveedor Garantia.- --
   Public Property IdMarcaProducto As Integer?
   Public Property NombreMarcaProducto As String
   Public Property IdModeloProducto As Integer?
   Public Property NombreModeloProducto As String
   '-- REQ-31656.- --
   Public Property IdSucursalNovedad As Integer?
   '-----------------------------------------------------------------------------------------
   '-- REQ-31709.- --
   Public Property AjustarStock As Publicos.AjustaStock = Publicos.AjustaStock.NOAJUSTA
   '-----------------------------------------------------------------------------------------

   Public Property ServiceLugarCompra As String
   Public Property ServiceLugarCompraFecha As Date?
   Public Property ServiceLugarCompraTipoComprobante As String
   Public Property ServiceLugarCompraNumeroComprobante As String

   Public Property IdAplicacionTerceros As String
   Public Property MotivoNovedad As CRMMotivoNovedad
   Public Property ComentarioPrincipal As ComentarioPrincipalOptiones

   Public Property PatenteVehiculo As String

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdPrioridadNovedad() As Integer
      Get
         If PrioridadNovedad Is Nothing Then Return 0
         Return PrioridadNovedad.IdPrioridadNovedad
      End Get
   End Property
   Public ReadOnly Property IdCategoriaNovedad() As Integer
      Get
         If CategoriaNovedad Is Nothing Then Return 0
         Return CategoriaNovedad.IdCategoriaNovedad
      End Get
   End Property
   Public ReadOnly Property IdMedioComunicacionNovedad() As Integer
      Get
         If MedioComunicacionNovedad Is Nothing Then Return 0
         Return MedioComunicacionNovedad.IdMedioComunicacionNovedad
      End Get
   End Property
   Public Property IdMetodoResolucionNovedad() As Integer
      Get
         If MetodoResolucionNovedad Is Nothing Then Return 0
         Return MetodoResolucionNovedad.IdMetodoResolucionNovedad
      End Get
      Set(value As Integer)
         If MetodoResolucionNovedad Is Nothing Then MetodoResolucionNovedad = New CRMMetodoResolucionNovedad()
         MetodoResolucionNovedad.IdMetodoResolucionNovedad = value
      End Set
   End Property

   Public ReadOnly Property IdEstadoNovedad() As Integer
      Get
         If EstadoNovedad Is Nothing Then Return 0
         Return EstadoNovedad.IdEstadoNovedad
      End Get
   End Property

   Public Property IdMotivoNovedad() As Integer
      Get
         If MotivoNovedad Is Nothing Then Return 0
         Return MotivoNovedad.IdMotivoNovedad
      End Get
      Set(value As Integer)
         If MotivoNovedad Is Nothing Then MotivoNovedad = New CRMMotivoNovedad()
         MotivoNovedad.IdMotivoNovedad = value
      End Set
   End Property

   Public ReadOnly Property IdUsuarioEstadoNovedad() As String
      Get
         If UsuarioEstadoNovedad Is Nothing Then Return String.Empty
         Return UsuarioEstadoNovedad.Usuario
      End Get
   End Property
   Public ReadOnly Property IdUsuarioAlta() As String
      Get
         If UsuarioAlta Is Nothing Then Return String.Empty
         Return UsuarioAlta.Usuario
      End Get
   End Property
   Public ReadOnly Property IdUsuarioAsignado() As String
      Get
         If UsuarioAsignado Is Nothing Then Return String.Empty
         Return UsuarioAsignado.Usuario
      End Get
   End Property

   Public ReadOnly Property IdUsuarioResponsable() As String
      Get
         If UsuarioResponsable Is Nothing Then Return String.Empty
         Return UsuarioResponsable.Usuario
      End Get
   End Property
#End Region


   Public Shared Function NombreBanderaColor(banderaColor As Color?) As String
      If banderaColor.HasValue Then
         If banderaColor.Value.ToArgb().Equals(Color.Red.ToArgb()) Then
            Return "Rojo"
         ElseIf banderaColor.Value.ToArgb().Equals(Color.Yellow.ToArgb()) Then
            Return "Amarillo"
         ElseIf banderaColor.Value.ToArgb().Equals(Color.Green.ToArgb()) Then
            Return "Verde"
         End If
      End If
      Return String.Empty
   End Function

   Public Enum AccionEtiquetaNovedad
      AGREGAR
      QUITAR
      CAMBIAR
   End Enum

   Public Class CambioMasivo

      Public Property Prioridad As CRMPrioridadNovedad
      Public Property PrioridadDelta As Integer = 0
      Public Property Priorizado As Boolean?
      Public Property RequiereTesteo As Boolean?
      Public Property UsuarioAsignado As Usuario
      Public Property GrabaResponsableEnAsignado As Boolean
      Public Property EstadoNovedad As CRMEstadoNovedad
      Public Property Avance As Decimal?
      Public Property Version As NullableString
      Public Property VersionFecha As Date?
      Public Property FechaProximoContacto As Date?
      Public Property MedioNovedad As CRMMedioComunicacionNovedad
      Public Property MetodoNovedad As CRMMetodoResolucionNovedad
      Public Property BanderaColor As Color?
      Public Property Categoria As CRMCategoriaNovedad
      Public Property Aplicacion As ZonaGeografica
      Public Property IdFuncion As String
      Public Property IdCliente As Long
      Public Property IdProyecto As Integer

      Public Property AccionEtiquetaNovedad As AccionEtiquetaNovedad
      Public Property EtiquetaNovedad As String

      Public Property NuevoComentario As String
      Public Property NuevoAdjunto As String
      Public Property NuevoIdTipoComentarioNovedad As Integer
      Public Property ComentarioPrincipal As ComentarioPrincipalOptiones

      Public Property EstadosPadres As Dictionary(Of String, Integer)

      Public Sub New()
         Version = New NullableString()
         GrabaResponsableEnAsignado = False
         EstadosPadres = New Dictionary(Of String, Integer)()
      End Sub

      Private Sub AgregarPropiedad(stb As StringBuilder, ByRef primero As Boolean, valor As String)
         Dim formato As String = If(primero, "{0}", " / {0}")
         stb.AppendFormat(formato, valor)
         primero = False
      End Sub

      Public Overrides Function ToString() As String
         Dim primero As Boolean = True
         Dim stb As New StringBuilder()
         If EstadoNovedad IsNot Nothing Then
            AgregarPropiedad(stb, primero, EstadoNovedad.NombreEstadoNovedad)
         End If
         If UsuarioAsignado IsNot Nothing Then
            AgregarPropiedad(stb, primero, UsuarioAsignado.Nombre)
         End If
         If MedioNovedad IsNot Nothing Then
            AgregarPropiedad(stb, primero, MedioNovedad.NombreMedioComunicacionNovedad)
         End If
         If Prioridad IsNot Nothing Then
            AgregarPropiedad(stb, primero, String.Concat("P-", Prioridad.NombrePrioridadNovedad))
         End If

         'Public Property PrioridadDelta As Integer = 0
         'Public Property Priorizado As Boolean?
         'Public Property GrabaResponsableEnAsignado As Boolean
         'Public Property Avance As Decimal?
         'Public Property Version As NullableString
         'Public Property VersionFecha As Date?
         'Public Property FechaProximoContacto As Date?
         'Public Property BanderaColor As Color?
         'Public Property Categoria As CRMCategoriaNovedad
         'Public Property Aplicacion As ZonaGeografica
         'Public Property IdFuncion As String
         'Public Property IdCliente As Long

         Return stb.ToString()
      End Function

      Public Class NullableString
         Private _interno As Boolean
         Private _EsNull As Boolean
         Public Property EsNull As Boolean
            Get
               Return _EsNull
            End Get
            Set(value As Boolean)
               If Not _interno Then
                  _interno = True
                  _EsNull = value
                  If value Then
                     _Valor = Nothing
                  End If
                  _interno = False
               End If
            End Set
         End Property
         Private _Valor As String
         Public Property Valor As String
            Get
               If EsNull Then Return Nothing
               Return _Valor
            End Get
            Set(value As String)
               If Not _interno Then
                  _interno = True
                  _Valor = value
                  _EsNull = value Is Nothing
                  _interno = False
               End If
            End Set
         End Property
         Public Sub New()
            EsNull = True
         End Sub
         Public Sub New(valor As String)
            Me.New()
            Me.Valor = valor
         End Sub
      End Class
   End Class

End Class