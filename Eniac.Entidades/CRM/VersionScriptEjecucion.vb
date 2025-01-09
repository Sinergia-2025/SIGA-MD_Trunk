Public Class VersionScriptEjecucion
   Inherits Eniac.Entidades.Entidad

   Public Sub New()
      MyBase.New()
   End Sub
   Public Enum Columnas
      IdAplicacion
      NroVersion
      Orden
      CodigoCliente
      Base
      Nombre
      Script
      Obligatorio
      FechaEjecucion
      Exitoso
      Mensaje
   End Enum

   Private _versionScript As Entidades.VersionScript
   Public Property VersionScript() As Entidades.VersionScript
      Get
         If Me._versionScript Is Nothing Then
            Me._versionScript = New Entidades.VersionScript()
         End If
         Return _versionScript
      End Get
      Set(ByVal value As Entidades.VersionScript)
         _versionScript = value
      End Set
   End Property

   Private _cliente As Entidades.Cliente
   Public Property Cliente() As Entidades.Cliente
      Get
         If Me._cliente Is Nothing Then
            Me._cliente = New Entidades.Cliente()
         End If
         Return _cliente
      End Get
      Set(ByVal value As Entidades.Cliente)
         _cliente = value
      End Set
   End Property

   Public Property Base As String
   Public Property FechaEjecucion As DateTime
   Public Property Exitoso As Boolean
   Public Property Mensaje As String


   Public Function GetAplicacionVersion() As String
      Return String.Format("{0} - {1}", Me.VersionScript.Aplicacion.IdAplicacion, Me.VersionScript.Version.NroVersion)
   End Function

   Public Function GetOrdenNombre() As String
      Return String.Format("{0} - {1}", Me.VersionScript.Orden, Me.VersionScript.Nombre)
   End Function

   Public Function GetResultado() As String
      If Me.Exitoso Then
         Return "EXITOSO"
      Else
         Return String.Format("CON ERROR - {0}", Me.Mensaje)
      End If
   End Function

   Public Function GetInfoCompleta() As String

      Return New System.Web.Script.Serialization.JavaScriptSerializer().Serialize(New With {.NombreScript = Me.VersionScript.Nombre,
                                                                                            .Orden = Me.VersionScript.Orden,
                                                                                            .Script = Me.VersionScript.Script,
                                                                                            .Mensaje = Me.Mensaje})

      'Return String.Format("{0} - {1} - {2} - {3}", Me.VersionScript.Nombre, Me.VersionScript.Orden, Me.VersionScript.Script, Me.Mensaje)
   End Function

End Class