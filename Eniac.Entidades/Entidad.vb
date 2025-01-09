Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Reflection
Imports System.Xml.Serialization

<Serializable()> _
Public Class Entidad

   Private _usuario As String
   Private _password As String
   Private _idSucursal As Integer
   Private _persistencia As Dictionary(Of String, Object)

   Public Property Usuario() As String
      Get
         Return Me._usuario
      End Get
      Set(value As String)
         Me._usuario = value
      End Set
   End Property

   Public Property Password() As String
      Get
         Return Me._password
      End Get
      Set(value As String)
         Me._password = value
      End Set
   End Property

   Public Overridable Property IdSucursal() As Integer
      Get
         Return _idSucursal
      End Get
      Set(value As Integer)
         Me._idSucursal = value
      End Set
   End Property



   Public Sub PersistoValoresPropiedades()

      Me._persistencia = New Dictionary(Of String, Object)()

      Dim propiedad As String
      Dim valor As Object
      Dim obj() As Object = Nothing

      For Each prop As PropertyInfo In Me.GetType().GetProperties()
         propiedad = prop.Name

         valor = prop.GetValue(Me, Nothing)

         If prop.PropertyType IsNot Nothing Then

            If prop.PropertyType.IsClass And prop.PropertyType.IsByRef Then
               If Not prop.PropertyType.IsGenericType Then
                  DirectCast(prop.GetValue(Me, Nothing), Entidades.Entidad).PersistoValoresPropiedades()
               End If
            End If
         End If

         If prop.PropertyType.Name = "List`1" Then
            Dim col3 As ParameterInfo = DirectCast(prop.GetValue(Me, obj), ParameterInfo)
            obj(0) = 1
            prop = DirectCast(prop.GetValue(Me, obj), PropertyInfo)
            'For Each cl In col
            '   C()
            'Next
         End If

         Me._persistencia.Add(propiedad, valor)
      Next

   End Sub

   Public Sub RecuperoValoresPropiedades()
      If Me._persistencia IsNot Nothing Then

         For Each prop As PropertyInfo In Me.GetType().GetProperties()
            If prop.CanWrite Then
               prop.SetValue(Me, Me._persistencia.Item(prop.Name), BindingFlags.SetProperty, Nothing, Nothing, Nothing)
            End If
         Next
      End If
   End Sub

   Public Function Clonar(Of T)(source As T) As T
      Using strm As MemoryStream = New MemoryStream()
         Dim serializer As XmlSerializer = New XmlSerializer(source.GetType())
         serializer.Serialize(strm, source)
         strm.Position = 0
         Dim serializer2 As XmlSerializer = New XmlSerializer(source.GetType())
         Return DirectCast(serializer2.Deserialize(strm), T)
      End Using
   End Function

   Public Enum MetodoGrabacion
      Manual
      Automatico
   End Enum

   Public Shared Function ParseMetodoGrabacion(valor As String) As MetodoGrabacion
      If valor = "M" Then
         Return MetodoGrabacion.Manual
      ElseIf valor = "A" Then
         Return MetodoGrabacion.Automatico
      End If
      Return Nothing
   End Function

End Class
