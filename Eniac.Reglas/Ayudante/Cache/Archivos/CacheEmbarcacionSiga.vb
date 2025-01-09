Namespace Ayudante.Cache.Archivos
   Public Class CacheEmbarcacionSiga
      Inherits BusquedaCacheadaCommon(Of EmbarcacionSiga)

#Region "Singleton"
      Private Shared _instancia As CacheEmbarcacionSiga = New CacheEmbarcacionSiga()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As CacheEmbarcacionSiga
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New EmbarcacionesSiga().GetTodos())
      End Sub

      Public Overloads Function Buscar(id As Long) As EmbarcacionSiga
         Return MyBase.Buscar(Function(x) x.IdEmbarcacion = id)
      End Function
      Public Function Existe(id As Long) As Boolean
         Return Buscar(id) IsNot Nothing
      End Function

   End Class
   Public Class EmbarcacionSiga
      Inherits Entidades.Entidad
      Public Property IdEmbarcacion As Long
      Public Property CodigoEmbarcacion As Long
      Public Property NombreEmbarcacion As String
   End Class

   Public Class EmbarcacionesSiga
      Inherits Base

#Region "Constructores"
      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub
      Public Sub New(accesoDatos As Datos.DataAccess)
         Me.NombreEntidad = "Embarcaciones"
         da = accesoDatos
      End Sub
#End Region

      Public Overrides Function GetAll() As DataTable
         Dim stb = New StringBuilder()

         With stb
            .AppendFormatLine("SELECT IdEmbarcacion, CodigoEmbarcacion, NombreEmbarcacion FROM Embarcaciones")
         End With

         Return da.GetDataTable(stb.ToString())
      End Function

      Public Function GetTodos() As List(Of EmbarcacionSiga)
         Return CargaLista(GetAll(),
                           Sub(o, dr)
                              With o
                                 o.IdEmbarcacion = dr.Field(Of Long)("IdEmbarcacion")
                                 o.CodigoEmbarcacion = dr.Field(Of Long)("CodigoEmbarcacion")
                                 o.NombreEmbarcacion = dr.Field(Of String)("NombreEmbarcacion")
                              End With
                           End Sub,
                           Function() New EmbarcacionSiga())
      End Function

   End Class

End Namespace