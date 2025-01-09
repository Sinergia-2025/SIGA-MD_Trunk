Namespace Extensiones
   Public Module BytesExtensions
      <Extension>
      Public Function Tamaño(valor As Byte()) As TamañoArchivo
         Return New TamañoArchivo(valor.LongLength)
      End Function

   End Module
   Public Class TamañoArchivo
      Private _Unidades As String() = {"B", "KB", "MB", "GB"}

      Private _Bytes As Long
      Public ReadOnly Property Bytes As Long
         Get
            Return _Bytes
         End Get
      End Property
      Private _Tamaño As Decimal
      Public ReadOnly Property Tamaño As Decimal
         Get
            Return _Tamaño
         End Get
      End Property
      Private _Etiqueta As String
      Public ReadOnly Property Etiqueta As String
         Get
            Return _Etiqueta
         End Get
      End Property

      Public Sub New(bytes As Long)
         Me._Bytes = bytes
         Me._Tamaño = bytes
         Me._Etiqueta = _Unidades(0)
         Procesar(index:=0)
      End Sub

      Private Sub Procesar(index As Integer)
         If _Tamaño > 1024 Then
            index += 1
            _Tamaño = _Tamaño / 1024
            _Etiqueta = _Unidades(index)
            Procesar(index)
         End If
      End Sub

      Public Overrides Function ToString() As String
         Return String.Format("{0:N2} {1}", Tamaño, Etiqueta)
      End Function

   End Class
End Namespace