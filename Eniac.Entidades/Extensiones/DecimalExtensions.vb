Namespace Extensiones
   Public Module DecimalExtensions
      <Extension>
      Public Function IfNull(valor As Integer?) As Integer
         Return valor.IfNull(0)
      End Function
      <Extension>
      Public Function IfNull(valor As Integer?, valueIfNull As Integer) As Integer
         If valor.HasValue Then
            Return valor.Value
         End If
         Return valueIfNull
      End Function
      <Extension>
      Public Function NullIf(valor As Integer, valueIfNull As Integer) As Integer?
         If valor = valueIfNull Then
            Return Nothing
         End If
         Return valor
      End Function
      <Extension>
      Public Function ToStringAFIP(valor As Decimal, cantidadEntera As Integer, cantidadDecimales As Integer) As String
         'El formato AFIP es todos números sin separador decimal
         'Multiplico el valor por 10 ^ cantidadDecimales para mover los decimales como entero: 1234.567 pasa a ser 123456.7
         'Al formatear tomo solo la parte entera, por lo que no importa la parte decimal resultante
         'La cantidad de posiciones que va a ocupar en el archivo es la cantidad de posiciones enteras más las decimales
         'Si son 13 enteras y 2 decimales el formato son 15 caracteres 0
         'Si el valor es negativo, le saco una posición al formato para que entre el signo negativo
         Return (valor * 10 ^ cantidadDecimales).ToString(New String("0"c, cantidadEntera + cantidadDecimales - If(valor < 0, 1, 0)))
      End Function
      <Extension>
      Public Function ToStringLog(valor As Decimal?) As String
         Return valor.ToStringLog(format:=Nothing)
      End Function
      <Extension>
      Public Function ToStringLog(valor As Decimal?, format As String) As String
         If valor.HasValue Then
            Return valor.Value.ToString(format)
         Else
            Return "NULL"
         End If
      End Function

   End Module
End Namespace