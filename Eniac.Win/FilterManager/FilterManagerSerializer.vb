#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On

Imports System.Web.Script.Serialization

#End Region
Namespace FilterManager
   Public Class FilterManagerSerializer
      Private _serializer As JavaScriptSerializer = New JavaScriptSerializer(New SimpleTypeResolver())

      Private Shared _instancia As FilterManagerSerializer
      Private Shared _lockObject As New Object()
      Friend Shared Function Instancia() As FilterManagerSerializer
         If _instancia Is Nothing Then
            SyncLock _lockObject
               If _instancia Is Nothing Then
                  _instancia = New FilterManagerSerializer()
               End If
            End SyncLock
         End If
         Return _instancia
      End Function

      Private Sub New()
      End Sub

      Public Function Serialize(valor As Object) As String
         If TypeOf (valor) Is [Enum] Then
            Return EnumToReflection(DirectCast(valor, [Enum]))
         ElseIf TypeOf (valor) Is DateTime Then
            Return _serializer.Serialize(New SerializedDateTime(DirectCast(valor, DateTime).ToString("yyyy-MM-dd HH:mm:ss")))
         Else
            Return _serializer.Serialize(valor)
         End If
      End Function
      Public Function Deserialize(valor As String) As Object
         Dim result = _serializer.Deserialize(Of Object)(valor)
         If TypeOf (result) Is SerializedEnum Then
            result = EnumFromReflection(DirectCast(result, SerializedEnum).Valor)
         ElseIf TypeOf (result) Is SerializedDateTime Then
            Return DateTime.Parse(DirectCast(result, SerializedDateTime).Valor)
         End If
         Return result
      End Function

      Private Function EnumToReflection(valor As [Enum]) As String
         Return _serializer.Serialize(New SerializedEnum(String.Format("{0}/{1}/{2}", valor.GetType().Assembly().GetName().Name, valor.GetType().FullName, valor.ToString())))
      End Function
      Private Function EnumFromReflection(valor As String) As [Enum]
         Dim valores = valor.Split("/"c)

         Dim ass = Reflection.Assembly.Load(valores(0))
         Dim a = ass.CreateInstance(valores(1))
         Dim t = a.GetType()
         Dim v = [Enum].Parse(t, valores(2))

         Return CType(v, [Enum])
      End Function

   End Class
End Namespace