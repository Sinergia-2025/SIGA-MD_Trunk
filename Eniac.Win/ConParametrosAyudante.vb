Public Class ConParametrosAyudante

#Region "Singleton"
   Private Shared _instancia As ConParametrosAyudante
   Private Shared _lock As Object = New Object()
   Private Shared ReadOnly Property Instancia As ConParametrosAyudante
      Get
         If _instancia Is Nothing Then
            SyncLock _lock
               If _instancia Is Nothing Then
                  _instancia = New ConParametrosAyudante()
               End If
            End SyncLock
         End If
         Return _instancia
      End Get
   End Property
   Private Sub New()

   End Sub
#End Region


   Public Shared Sub Parse(par As String, permitidos As Type, parametros As ParametrosFuncion)
      Parse(par, permitidos, parametros, Function(key, value, h) value)
   End Sub
   Public Shared Sub Parse(par As String, permitidos As Type, parametros As ParametrosFuncion,  'accion As Action(Of String, String, ConParametrosAyudante),
                           convertirDato As Func(Of System.Enum, String, ConParametrosAyudante, Object))
      For Each p As String In par.Split(";"c)
         Dim keyValue As String() = p.Split("="c)
         Dim e As [Enum] = DirectCast([Enum].Parse(permitidos, keyValue(0)), [Enum])

         Dim v = convertirDato(e, If(keyValue.Length > 0, keyValue(1), Nothing), Instancia)
         parametros.SetValor(e, v)

         'accion(keyValue(0), If(keyValue.Length > 0, keyValue(1), Nothing), Instancia)
      Next
   End Sub

   Public Shared Function ParametrosDisponiblesAyuda(permitidos As Type) As String
      Dim stb = New StringBuilder("Lista separada por ';' de pares clave valor separados por '='").AppendLine().AppendLine()
      Dim enumArray = [Enum].GetValues(permitidos).OfType(Of [Enum]).ToList()
      enumArray.ForEach(
         Sub(e)
            stb.AppendFormatLine("{0} - {1} - {2}", e.ToString(), e.GetDescription(), e.GetDefaultValue())
         End Sub)

      Return stb.ToString()
   End Function

   Public Function ToType(Of T)(valor As String, defaultIfNull As T) As T
      Return ToType(valor, defaultIfNull, AccionIfFail.DefaultValue)
   End Function

   Public Function ToType(Of T)(valor As String, defaultIfNull As T, accion As AccionIfFail) As T
      Return ToType(valor, defaultIfNull, accion, customConvertion:=Nothing)
   End Function
   Private Function ToType(Of T)(valor As String, defaultIfNull As T, accion As AccionIfFail,
                                 customConvertion As Func(Of String, Tuple(Of Boolean, T))) As T
      If valor Is Nothing Then
         Return defaultIfNull
      End If
      Try
         If customConvertion IsNot Nothing Then
            Dim r = customConvertion(valor)
            If r.Item1 Then
               Return r.Item2
            End If
         End If
         Return DirectCast(Convert.ChangeType(valor, GetType(T)), T)
      Catch ex As Exception
         If accion = AccionIfFail.DefaultValue Then
            Return defaultIfNull
         Else
            Throw New Exception(String.Format("El valor '{0}' no pudo parsearse a {1}.", valor, GetType(T).Name))
         End If
      End Try
   End Function

   Public Function ToInteger(valor As String) As Integer
      Return ToType(valor, 0I)
   End Function

   Public Function ToBoolean(valor As String) As Boolean
      Return ToBoolean(valor, False)
   End Function
   Public Function ToBoolean(valor As String, defaultIfNull As Boolean) As Boolean
      Return ToBoolean(valor, defaultIfNull, AccionIfFail.DefaultValue)
   End Function
   Public Function ToBoolean(valor As String, defaultIfNull As Boolean, accion As AccionIfFail) As Boolean
      Return ToType(valor, defaultIfNull, accion,
                    customConvertion:=
                    Function(v)
                       Dim result As Boolean = False
                       Dim resolved As Boolean = False

                       If valor = Boolean.TrueString Or valor = "SI" Or valor = "YES" Or valor = "1" Then
                          result = True
                          resolved = True
                       ElseIf valor = Boolean.FalseString Or valor = "NO" Or valor = "0" Then
                          result = False
                          resolved = True
                       End If

                       Return New Tuple(Of Boolean, Boolean)(resolved, result)
                    End Function)
   End Function

End Class
Public Enum AccionIfFail
   Exception
   DefaultValue
End Enum
Public Class ParametrosFuncion
   Private _valores As Dictionary(Of String, Object) = New Dictionary(Of String, Object)()

   Public Sub SetValor(key As System.Enum, valor As Object)
      SetValor(key.ToString(), valor)
   End Sub
   Public Sub SetValor(key As String, valor As Object)
      If _valores.ContainsKey(key) Then
         _valores(key) = valor
      Else
         _valores.Add(key, valor)
      End If
   End Sub

   Public Function GetValor(Of T)(key As System.Enum) As T
      Return GetValor(key, DirectCast(Convert.ChangeType(key.GetDefaultValue(), GetType(T)), T))
   End Function
   Public Function GetValor(Of T)(key As System.Enum, defaultIfNull As T) As T
      Return GetValor(key.ToString(), defaultIfNull)
   End Function
   Public Function GetValor(Of T)(key As String, defaultIfNull As T) As T
      Return GetValor(key, defaultIfNull, AccionIfFail.DefaultValue)
   End Function
   Public Function GetValor(Of T)(key As String, defaultIfNull As T, accion As AccionIfFail) As T
      If _valores.ContainsKey(key) Then
         Return DirectCast(_valores(key), T)
      Else
         If accion = AccionIfFail.DefaultValue Then
            Return defaultIfNull
         Else
            Throw New Exception(String.Format("No se encontró valor para el parámetro '{0}'", key))
         End If
      End If
   End Function

   Public Function Existe(key As System.Enum) As Boolean
      Return Existe(key.ToString())
   End Function
   Public Function Existe(key As String) As Boolean
      Return _valores.ContainsKey(key)
   End Function

End Class