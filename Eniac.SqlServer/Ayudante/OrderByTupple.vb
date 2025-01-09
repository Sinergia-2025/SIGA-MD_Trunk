Imports System.ComponentModel

Public Class OrderByList
   Inherits List(Of OrderByTupple)
   Public Sub New()
   End Sub
   Public Sub New(capacity As Integer)
      MyBase.New(capacity)
   End Sub
   Public Sub New(collection As IEnumerable(Of OrderByTupple))
      MyBase.New(collection)
   End Sub
   Public Sub New(collection As IEnumerable(Of String))
      MyBase.New(collection.ToList().ConvertAll(Function(c) New OrderByTupple(c)))
   End Sub
   Public Shadows Function Add(orden As OrderByTupple) As OrderByList
      Add(orden)
      Return Me
   End Function
   Public Shadows Function Add(nombreTabla As String, nombreColumna As [Enum], orientacion As OrderByOrientaciones) As OrderByList
      Return Add(nombreTabla, nombreColumna.ToString(), orientacion)
   End Function
   Public Shadows Function Add(nombreTabla As String, nombreColumna As String, orientacion As OrderByOrientaciones) As OrderByList
      If Not String.IsNullOrWhiteSpace(nombreTabla) Then
         nombreColumna = String.Format("{0}.{1}", nombreTabla.Trim("."c), nombreColumna)
      End If
      Return Add(New OrderByTupple(nombreColumna, orientacion))
   End Function
   Public Shadows Function Add(nombreColumna As [Enum], orientacion As OrderByOrientaciones) As OrderByList
      Return Add(nombreColumna.ToString(), orientacion)
   End Function
   Public Shadows Function Add(nombreColumna As String, orientacion As OrderByOrientaciones) As OrderByList
      Return Add(New OrderByTupple(nombreColumna, orientacion))
   End Function
   Public Shadows Function Add(nombreColumna As String) As OrderByList
      Return Add(New OrderByTupple(nombreColumna))
   End Function

   Public Overrides Function ToString() As String
      If Any() Then
         Return String.Format(" ORDER BY {0}", String.Join(", ", ConvertAll(Function(o) String.Format("{0} {1}", o.NombreColumna, o.Orientacion.GetDescription()))))
      Else
         Return String.Empty
      End If
   End Function

End Class
Public Structure OrderByTupple
   Public Property NombreColumna As String
   Public Property Orientacion As OrderByOrientaciones

   Public Sub New(nombreColumna As String, orientacion As OrderByOrientaciones)
      Me.NombreColumna = nombreColumna
      Me.Orientacion = orientacion
   End Sub
   Public Sub New(nombreColumna As String)
      Me.New(nombreColumna, OrderByOrientaciones.Ascendente)
   End Sub
End Structure
Public Enum OrderByOrientaciones
   <Description("")> Ascendente
   <Description("DESC")> Descendente
End Enum
