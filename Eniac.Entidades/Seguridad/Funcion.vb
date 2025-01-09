<Serializable()>
Public Class Funcion
   Inherits Entidad

   Public Const NombreTabla As String = "Funciones"

   Public Enum Columnas
      Id
      Nombre
      Descripcion
      EsMenu
      EsBoton
      Enabled
      Visible
      IdPadre
      Posicion
      Archivo
      Pantalla
      Parametros
      Icono
      PermiteMultiplesInstancias
      Plus
      Express
      Basica
      PV
      IdModulo
      EsMDIChild

   End Enum

   Public Enum ComboEdicion
      S
      N
      O
   End Enum

   Public Sub New()
      Documentos = New List(Of FuncionesDocumentos)()
      FuncionesVinculadas = New List(Of FuncionVinculada)()
   End Sub

#Region "Propiedades"

   Public Property Id As String = ""
   Public Property Nombre As String = ""
   Public Property Descripcion As String = ""
   Public Property EsMenu As Boolean = False
   Public Property EsBoton As Boolean = False
   Public Property Enabled As Boolean = False
   Public Property Visible As Boolean = False
   Public Property IdPadre As String = ""
   Public Property Posicion As Integer = 0
   Public Property Archivo As String = ""
   Public Property Pantalla As String = ""
   Public Property Icono As Byte()

   Public Property Parametros As String
   Public Property PermiteMultiplesInstancias As Boolean
   Public Property Plus As String = ""
   Public Property Express As String = ""
   Public Property Basica As String = ""
   Public Property PV As String = ""
   Public Property IdModulo As Integer = 0
   Public Property EsMDIChild As Boolean

   Public Property Documentos As List(Of FuncionesDocumentos)

   Public Property FuncionesVinculadas As List(Of FuncionVinculada)

#End Region

End Class