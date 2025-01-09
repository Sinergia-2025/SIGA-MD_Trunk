Namespace Extensiones
   Public Module SiNoTodosExtensions
      <Extension()>
      Public Function ToBoolean(value As Publicos.SiNoTodos) As Boolean?
         If value = Publicos.SiNoTodos.TODOS Then
            Return Nothing
         Else
            Return value = Publicos.SiNoTodos.SI
         End If
      End Function
   End Module
End Namespace