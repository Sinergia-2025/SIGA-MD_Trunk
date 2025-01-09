Public Class VersionScript
   Inherits Eniac.Entidades.Entidad

   Public Sub New()
      MyBase.New()
   End Sub
   Public Enum Columnas
      IdAplicacion
      NroVersion
      Orden
      Nombre
      Script
      Obligatorio
      CodigoCliente
   End Enum

   Private _aplicacion As Entidades.Aplicacion
   Public Property Aplicacion() As Entidades.Aplicacion
      Get
         If Me._aplicacion Is Nothing Then
            Me._aplicacion = New Entidades.Aplicacion()
         End If
         Return _aplicacion
      End Get
      Set(ByVal value As Entidades.Aplicacion)
         _aplicacion = value
      End Set
   End Property

   Private _version As Entidades.Version
   Public Property Version() As Entidades.Version
      Get
         If Me._version Is Nothing Then
            Me._version = New Entidades.Version()
         End If
         Return _version
      End Get
      Set(ByVal value As Entidades.Version)
         _version = value
      End Set
   End Property

   Public Property Orden As Integer

   Public Property Nombre As String

   Public Property Script As String

   Public Property Obligatorio As Boolean

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

End Class