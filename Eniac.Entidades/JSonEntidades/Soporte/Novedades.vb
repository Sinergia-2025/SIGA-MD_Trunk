Namespace JSonEntidades.Soporte
   Public Class CRMNovedad
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
         Seguimientos = New List(Of NovedadesSeguimiento)()
      End Sub

      Public Property IdTipoNovedad As String
      Public Property NombreTipoNovedad As String
      Public Property Letra As String
      Public Property CentroEmisor As Short
      Public Property IdNovedad As Long
      Public Property FechaNovedad As Date
      Public Property Descripcion As String
      Public Property IdPrioridadNovedad As Integer
      Public Property IdCategoriaNovedad As Integer
      Public Property IdEstadoNovedad As Integer
      Public Property FechaEstadoNovedad As Date
      Public Property IdUsuarioEstadoNovedad As String
      Public Property FechaAlta As Date
      Public Property IdUsuarioAlta As String
      Public Property IdUsuarioAsignado As String
      Public Property Avance As Decimal
      Public Property IdMedioComunicacionNovedad As Nullable(Of Integer)
      Public Property IdCliente As Nullable(Of Long)
      Public Property CodigoCliente As Nullable(Of Long)
      Public Property IdProspecto As Nullable(Of Long)
      Public Property IdFuncion As String
      Public Property IdSistema As String
      Public Property FechaProximoContacto As Nullable(Of Date)
      Public Property BanderaColor As Nullable(Of Integer)
      Public Property Interlocutor As String
      Public Property IdMetodoResolucionNovedad As Nullable(Of Integer)
      Public Property IdProveedor As Nullable(Of Long)
      Public Property IdProyecto As Nullable(Of Integer)
      Public Property RevisionAdministrativa As Boolean
      Public Property Priorizado As Boolean
      Public Property IdTipoNovedadPadre As String
      Public Property LetraPadre As String
      Public Property CentroEmisorPadre As Nullable(Of Short)
      Public Property IdNovedadPadre As Nullable(Of Long)
      Public Property Version As String
      Public Property VersionFecha As Nullable(Of Date)
      Public Property FechaInicioPlan As Nullable(Of Date)
      Public Property FechaFinPlan As Nullable(Of Date)
      Public Property TiempoEstimado As Nullable(Of Decimal)
      Public Property IdUsuarioResponsable As String
      Public Property Cantidad As Decimal
      Public Property Comentario As String

      Public Property Seguimientos As List(Of NovedadesSeguimiento)

      Public Shared Function Parse(idEmpresa As Integer, dr As DataRow) As CRMNovedad
         Dim result As CRMNovedad = New CRMNovedad(idEmpresa)
         With result

            .IdTipoNovedad = dr.Field(Of String)("IdTipoNovedad")
            .NombreTipoNovedad = dr.Field(Of String)("NombreTipoNovedad")
            .Letra = dr.Field(Of String)("Letra")
            .CentroEmisor = dr.Field(Of Short)("CentroEmisor")
            .IdNovedad = dr.Field(Of Long)("IdNovedad")

            .FechaNovedad = dr.Field(Of DateTime)("FechaNovedad")
            .Descripcion = dr.Field(Of String)("Descripcion")
            .IdPrioridadNovedad = dr.Field(Of Integer)("IdPrioridadNovedad")
            .IdCategoriaNovedad = dr.Field(Of Integer)("IdCategoriaNovedad")
            .IdEstadoNovedad = dr.Field(Of Integer)("IdEstadoNovedad")
            .FechaEstadoNovedad = dr.Field(Of DateTime)("FechaEstadoNovedad")
            .IdUsuarioEstadoNovedad = dr.Field(Of String)("IdUsuarioEstadoNovedad")
            .FechaAlta = dr.Field(Of DateTime)("FechaAlta")
            .IdUsuarioAlta = dr.Field(Of String)("IdUsuarioAlta")
            .IdUsuarioAsignado = dr.Field(Of String)("IdUsuarioAsignado")
            .IdUsuarioResponsable = dr.Field(Of String)("IdUsuarioResponsable")

            Dim valorDecimalNull As Decimal?

            valorDecimalNull = dr.Field(Of Decimal?)("Avance")
            If valorDecimalNull.HasValue Then
               .Avance = valorDecimalNull.Value
            End If
            .IdMedioComunicacionNovedad = dr.Field(Of Integer?)("IdMedioComunicacionNovedad")

            .IdMetodoResolucionNovedad = dr.Field(Of Integer?)("IdMetodoResolucionNovedad")

            .IdCliente = dr.Field(Of Long?)("IdCliente")
            .IdProspecto = dr.Field(Of Long?)("IdProspecto")
            .IdProveedor = dr.Field(Of Long?)("IdProveedor")

            .IdProyecto = dr.Field(Of Integer?)("IdProyecto")

            .IdFuncion = dr.Field(Of String)("IdFuncion")
            .IdSistema = dr.Field(Of String)("IdSistema")

            .FechaProximoContacto = dr.Field(Of DateTime?)("FechaProximoContacto")

            .BanderaColor = dr.Field(Of Integer?)("BanderaColor")

            .Interlocutor = dr.Field(Of String)("Interlocutor")

            .RevisionAdministrativa = dr.Field(Of Boolean)("RevisionAdministrativa")

            .Priorizado = dr.Field(Of Boolean)("Priorizado")

            .IdTipoNovedadPadre = dr.Field(Of String)("IdTipoNovedadPadre")
            .LetraPadre = dr.Field(Of String)("LetraPadre")
            .CentroEmisorPadre = dr.Field(Of Short?)("CentroEmisorPadre")
            .IdNovedadPadre = dr.Field(Of Long?)("IdNovedadPadre")

            .Version = dr.Field(Of String)("Version")

            .FechaInicioPlan = dr.Field(Of DateTime?)("FechaInicioPlan")
            .FechaFinPlan = dr.Field(Of DateTime?)("FechaFinPlan")
            .VersionFecha = dr.Field(Of DateTime?)("VersionFecha")
            .TiempoEstimado = dr.Field(Of Decimal?)("TiempoEstimado")

            valorDecimalNull = dr.Field(Of Decimal?)("Cantidad")
            If valorDecimalNull.HasValue Then
               .Cantidad = valorDecimalNull.Value
            End If

            .CodigoCliente = dr.Field(Of Long?)("CodigoCliente")
            .Comentario = dr.Field(Of String)("Comentario")
            If .Comentario Is Nothing Then
               .Comentario = String.Empty
            End If

         End With
         Return result
      End Function


   End Class
End Namespace