Imports System.Collections.ObjectModel

Namespace Extensiones
   Public Module ListExtensions
      <Extension>
      Public Function Paginar(Of T)(datos As List(Of T), registrosPorPagina As Integer) As List(Of T())
         Dim result = New List(Of T())(Convert.ToInt32((datos.Count / registrosPorPagina) * 1.1))
         Dim posicion As Integer = 0
         While posicion < datos.Count
            Dim pagina(Math.Min(datos.Count - posicion, registrosPorPagina) - 1) As T
            datos.CopyTo(posicion, pagina, 0, Math.Min(datos.Count - posicion, registrosPorPagina))
            result.Add(pagina)
            posicion += registrosPorPagina
         End While
         Return result
      End Function

      <Extension>
      Public Function ToConBorrados(Of T)(datos As List(Of T)) As ListConBorrados(Of T)
         Return New ListConBorrados(Of T)(datos)
      End Function

      <Extension>
      Public Function MaxSecure(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Integer)) As Integer?
         If source.Count = 0 Then
            Return Nothing
         Else
            Return source.Max(selector)
         End If
      End Function
      <Extension>
      Public Function MinSecure(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Integer)) As Integer?
         If source.Count = 0 Then
            Return Nothing
         Else
            Return source.Min(selector)
         End If
      End Function
      <Extension>
      Public Function MinSecure(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Date)) As Date?
         If source.Count = 0 Then
            Return Nothing
         Else
            Return source.Min(selector)
         End If
      End Function
      <Extension>
      Public Function SumSecure(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Integer)) As Integer?
         If source.Count = 0 Then
            Return Nothing
         Else
            Return source.Sum(selector)
         End If
      End Function
      <Extension>
      Public Function SumSecure(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Decimal)) As Decimal?
         If source.Count = 0 Then
            Return Nothing
         Else
            Return source.Sum(selector)
         End If
      End Function
      <Extension>
      Public Function SumSecure(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Double)) As Double?
         If source.Count = 0 Then
            Return Nothing
         Else
            Return source.Sum(selector)
         End If
      End Function
      <Extension>
      Public Function AnySecure(Of TSource)(source As IEnumerable(Of TSource)) As Boolean
         If source Is Nothing Then
            Return False
         Else
            Return source.Any()
         End If
      End Function
      <Extension>
      Public Function AnySecure(Of TSource)(source As IEnumerable(Of TSource), selector As Func(Of TSource, Boolean)) As Boolean
         If source Is Nothing Then
            Return False
         Else
            Return source.Any(selector)
         End If
      End Function
      <Extension>
      Public Function ContainsSecure(Of TSource)(source As IEnumerable(Of TSource), value As TSource) As Boolean
         If source Is Nothing Then
            Return False
         Else
            Return source.Contains(value)
         End If
      End Function

      <Extension>
      Public Sub ForEachSecure(Of TSource)(source As IEnumerable(Of TSource), accion As Action(Of TSource))
         If source IsNot Nothing Then source.ToList().ForEach(accion)
      End Sub
      <Extension>
      Public Sub ForEachSecure(Of TSource)(source As List(Of TSource), accion As Action(Of TSource))
         If source IsNot Nothing Then source.ForEach(accion)
      End Sub


      Private _ser As JavaScriptSerializer = New JavaScriptSerializer()
      <Extension()>
      Public Function ClonarColeccion(Of T)(coleccion As List(Of T)) As List(Of T)
         'Dim ser = New JavaScriptSerializer()
         Return DirectCast(_ser.Deserialize(_ser.Serialize(coleccion), GetType(List(Of T))), List(Of T))
      End Function
      <Extension()>
      Public Function ClonarColeccion(coleccion As ProduccionFormasVariablesList) As ProduccionFormasVariablesList
         'Dim ser = New JavaScriptSerializer()
         Return New ProduccionFormasVariablesList(_ser.Deserialize(Of List(Of ProduccionFormasVariables))(_ser.Serialize(coleccion)))
      End Function
      <Extension>
      Public Function ClonarColeccion(Of TSource)(source As ObservableCollection(Of TSource)) As ObservableCollection(Of TSource)
         'Dim ser = New JavaScriptSerializer()
         Return _ser.Deserialize(Of ObservableCollection(Of TSource))(_ser.Serialize(source))
      End Function

   End Module
End Namespace