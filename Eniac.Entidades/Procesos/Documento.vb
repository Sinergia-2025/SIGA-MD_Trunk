
Public Class Documento
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idDocumento
      Nombre
      Grupo
      Version
      Documento
   End Enum

   Public Enum Grupos
      Documentos
   End Enum

#Region "Propiedades"

   Private _idDocumento As Integer

   Public Property idDocumento() As Integer
      Get
         Return _idDocumento
      End Get
      Set(ByVal value As Integer)
         _idDocumento = value
      End Set
   End Property

   Private _Nombre As String

   Public Property Nombre() As String
      Get
         Return _Nombre
      End Get
      Set(ByVal value As String)
         _Nombre = value
      End Set
   End Property

   Private _Grupo As String

   Public Property Grupo() As String
      Get
         Return _Grupo
      End Get
      Set(ByVal value As String)
         _Grupo = value
      End Set
   End Property

   Private _Version As Decimal

   Public Property Version() As Decimal
      Get
         Return _Version
      End Get
      Set(ByVal value As Decimal)
         _Version = value
      End Set
   End Property

   Private _documento As Byte()

   Public Property Documento() As Byte()
      Get
         Return _documento
      End Get
      Set(ByVal value As Byte())
         _documento = value
         'Array.Copy(value, _documento, value.Length)
      End Set
   End Property

#End Region

End Class
