Imports System.Globalization

Public Class Formatos
   Public Class Format
      Public Shared ReadOnly Property Decimales2 As String
         Get
            Return CustomDecimales(2)
         End Get
      End Property
      Public Shared Function CustomDecimales(decimales As Integer) As String
         Return String.Format("N{0}", decimales)
      End Function

      Public Shared ReadOnly Property FechaSinHora As String
         Get
            Return "dd/MM/yyyy"
         End Get
      End Property
      Public Shared ReadOnly Property FechaCompleta As String
         Get
            Return "dd/MM/yyyy HH:mm:ss"
         End Get
      End Property
      Public Shared ReadOnly Property HoraSinFecha As String
         Get
            Return "HH:mm:ss"
         End Get
      End Property
   End Class
   Public Class MaskInput
      Private Const _maskInputTemplate As String = "{double:-{0}.{1}}"

      Public Shared ReadOnly Property Decimales9_2 As String
         Get
            Return CustomMaskInput(9, 2)
         End Get
      End Property

      Public Shared ReadOnly Property Decimales3_2 As String
         Get
            Return CustomMaskInput(3, 2)
         End Get
      End Property

      Public Shared ReadOnly Property Decimales5_2 As String
         Get
            Return CustomMaskInput(5, 2)
         End Get
      End Property

      Public Shared Function CustomMaskInput(enteros As Integer, decimales As Integer) As String
         Return _maskInputTemplate.Replace("{0}", enteros.ToString()).Replace("{1}", decimales.ToString()) '' String.Format(_maskInputTemplate, enteros, decimales)
      End Function

      Public Shared ReadOnly Property FechaSinHora As String
         Get
            Return "{LOC}dd/mm/yyyy"
         End Get
      End Property
   End Class

   Public Class Culturas
      Private Shared _argentina As CultureInfo = New CultureInfo("es-AR")

      Public Shared ReadOnly Property Invariant As CultureInfo
         Get
            Return CultureInfo.InvariantCulture
         End Get
      End Property
      Public Shared ReadOnly Property Argentina As CultureInfo
         Get
            Return _argentina
         End Get
      End Property

   End Class
End Class
