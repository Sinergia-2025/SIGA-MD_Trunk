Namespace Extensiones
   Public Module EnumExtensions

      <Extension>
      Public Function CheckBrowsable(value As [Enum]) As Boolean
         Dim fi = value.GetType().GetField(value.ToString())
         Dim attributes = DirectCast(fi.GetCustomAttributes(GetType(BrowsableAttribute), False), BrowsableAttribute())
         If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
            Return attributes(0).Browsable
         Else
            Return True
         End If
      End Function
      <Extension>
      Public Function CheckCategory(value As [Enum], category As String) As Boolean
         Dim fi = value.GetType().GetField(value.ToString())
         Dim attributes = DirectCast(fi.GetCustomAttributes(GetType(CategoryAttribute), False), CategoryAttribute())
         If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
            Return attributes(0).Category = category
         Else
            Return True
         End If
      End Function
      <Extension>
      Public Function GetDescription(value As [Enum]) As String
         Dim fi = value.GetType().GetField(value.ToString())
         Dim attributes = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
         If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
            Return attributes(0).Description
         Else
            Return value.ToString()
         End If
      End Function
      <Extension>
      Public Function GetDefaultValue(value As [Enum]) As Object
         Dim fi = value.GetType().GetField(value.ToString())
         Dim attributes = DirectCast(fi.GetCustomAttributes(GetType(DefaultValueAttribute), False), DefaultValueAttribute())
         If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
            Return attributes(0).Value
         Else
            Return Nothing
         End If
      End Function

   End Module
End Namespace