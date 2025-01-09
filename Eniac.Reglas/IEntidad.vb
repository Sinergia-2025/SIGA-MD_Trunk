Public Interface IEntidad

    Property NombreEntidad() As String
    Property Servidor() As String
    Property DataBase() As String
    Property Id() As Integer

   Function GetAll() As DataTable
    Function GetFilter(ByVal filter As String) As DataSet
   Function GetFilter(ByVal filter As String, ByVal args() As Object) As Object
   Function GetValue(ByVal que As String, ByVal args() As Object) As Object

End Interface
