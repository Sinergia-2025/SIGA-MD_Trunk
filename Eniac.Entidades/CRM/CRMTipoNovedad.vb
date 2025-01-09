Public Class CRMTipoNovedad
   Inherits Entidad

   Public Enum Columnas
      IdTipoNovedad
      NombreTipoNovedad
      UnidadDeMedida
      UsuarioRequerido
      UsuarioPorDefecto
      ProximoContactoRequerido
      PrimerOrdenGrilla
      SegundoOrdenGrilla
      UsaSegundoOrden
      PrimerOrdenDesc
      SegundoOrdenDesc
      VisualizaOtrasNovedades
      VisualizaRevisionAdministrativa
      PermiteBorrarComentarios
      DiasProximoContacto
      PermiteIngresarNumero
      ReportaAvance
      ReportaCantidad
      LetrasHabilitadas
      VerCambios
      RequierePadre
      Reporte
      Embebido
      CantidadCopias
      SolapaPorDefecto
      VisualizaSucursal
   End Enum

   Public Sub New()
      Dinamicos = New List(Of CRMTipoNovedadDinamico)()
   End Sub

   Public Property IdTipoNovedad() As String
   Public Property NombreTipoNovedad() As String
   Public Property UnidadDeMedida() As String
   Public Property Dinamicos() As List(Of CRMTipoNovedadDinamico)
   Public Property UsuarioRequerido() As Boolean
   Public Property UsuarioPorDefecto() As Boolean
   Public Property ProximoContactoRequerido() As Boolean
   Public Property PrimerOrdenGrilla() As String
   Public Property SegundoOrdenGrilla() As String
   Public Property UsaSegundoOrden() As Boolean
   Public Property PrimerOrdenDesc() As Boolean
   Public Property SegundoOrdenDesc() As Boolean
   Public Property VisualizaOtrasNovedades() As Boolean
   Public Property VisualizaRevisionAdministrativa() As Boolean
   Public Property PermiteBorrarComentarios As Boolean
   Public Property DiasProximoContacto As Integer
   Public Property PermiteIngresarNumero As Boolean
   Public Property ReportaAvance As Boolean
   Public Property ReportaCantidad As Boolean
   Public Property LetrasHabilitadas As String
   Public Property VerCambios As Boolean
   Public Property RequierePadre As Boolean
   Public Property Reporte As String
   Public Property Embebido As Boolean
   Public Property CantidadCopias As Integer
   Public Property SolapaPorDefecto As SolapaPorDef
   Public Property VisualizaSucursal As String
   Public Function BuscarDinamico(dinamico As TipoDinamico) As CRMTipoNovedadDinamico
      For Each din As Entidades.CRMTipoNovedadDinamico In Dinamicos
         If din.IdNombreDinamico.ToLower().Equals(dinamico.ToString().ToLower()) Then
            Return din
         End If
      Next
      Return Nothing
   End Function

   Public Function TieneDinamico(dinamico As TipoDinamico) As Boolean
      Return BuscarDinamico(dinamico) IsNot Nothing
   End Function

   Public Function DinamicoRequerido(dinamico As TipoDinamico) As Boolean
      Return BuscarDinamico(dinamico).EsRequerido
   End Function

   Public Enum TipoDinamico
      CLIENTES
      PROSPECTOS
      PROVEEDORES
      VEHICULO
      SISTEMAS
      METODORESOLUCION
      FUNCIONES
      PROYECTOS
      PRODUCTOS
      SERVICE
      SERVICELUGARCOMPRA
      OBSERVACION
      MOTIVOS
      APLICACIONTERCERO
   End Enum

   Public Enum SolapaPorDef
      Comentarios
      <Description("Mas Info")> MasInfo
      <Browsable(False)> Sinergia
   End Enum

   Public Enum ColVisualizaSucursalNovedades
      <Description("No Visible")> NoVisible
      <Description("Compartida")> Compartida
      <Description("Exclusiva")> Exclusiva
   End Enum

End Class