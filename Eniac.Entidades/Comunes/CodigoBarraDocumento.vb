Imports System.Text

Public Structure CodigoBarraDocumento

   Private _codigoBarraParseado As String

   Private _numeroTramite As Long
   Public ReadOnly Property NumeroTramite As Long
      Get
         Return _numeroTramite
      End Get
   End Property

   Private _apellidos As String
   Public ReadOnly Property Apellidos() As String
      Get
         Return _apellidos
      End Get
   End Property

   Private _nombres As String
   Public ReadOnly Property Nombres() As String
      Get
         Return _nombres
      End Get
   End Property

   Private _sexo As String
   Public ReadOnly Property Sexo() As String
      Get
         Return _sexo
      End Get
   End Property

   Private _numeroDocumento As Long
   Public ReadOnly Property NumeroDocumento() As Long
      Get
         Return _numeroDocumento
      End Get
   End Property

   Private _ejemplar As String
   Public ReadOnly Property Ejemplar() As String
      Get
         Return _ejemplar
      End Get
   End Property

   Private _fechaNacimiento As DateTime
   Public ReadOnly Property FechaNacimiento() As DateTime
      Get
         Return _fechaNacimiento
      End Get
   End Property

   Private _fechaEmision As DateTime
   Public ReadOnly Property FechaEmision() As DateTime
      Get
         Return _fechaEmision
      End Get
   End Property

   Private _prefSufCuil As String
   Public ReadOnly Property PrefSufCuil() As String
      Get
         Return _prefSufCuil
      End Get
   End Property


   Private Sub New(codigoBarraParseado As String, numeroTramite As Long, apellidos As String, nombres As String, sexo As String, numeroDocumento As Long, ejemplar As String, fechaNacimiento As DateTime, fechaEmision As DateTime, prefSufCuil As String)
      _codigoBarraParseado = codigoBarraParseado
      _numeroTramite = numeroTramite
      _apellidos = apellidos
      _nombres = nombres
      _sexo = sexo
      _numeroDocumento = numeroDocumento
      _ejemplar = ejemplar
      _fechaNacimiento = fechaNacimiento
      _fechaEmision = fechaEmision
      _prefSufCuil = prefSufCuil
   End Sub

   Public Overloads Function ToString(original As Boolean) As String
      If original Then
         Return _codigoBarraParseado
      Else
         Dim stb As StringBuilder = New StringBuilder()
         Const toStringAppendFormat As String = """{0}"
         Const toStringAppendFormatForDateTime As String = """{0:dd-MM-yyyy}"
         With stb
            .AppendFormat("{0:00000000000}", NumeroTramite)
            .AppendFormat(toStringAppendFormat, Apellidos)
            .AppendFormat(toStringAppendFormat, Nombres)
            .AppendFormat(toStringAppendFormat, Sexo)
            .AppendFormat(toStringAppendFormat, NumeroDocumento)
            .AppendFormat(toStringAppendFormat, Ejemplar)
            .AppendFormat(toStringAppendFormatForDateTime, FechaNacimiento)
            .AppendFormat(toStringAppendFormatForDateTime, FechaEmision)
            If Not String.IsNullOrEmpty(PrefSufCuil) Then
               .AppendFormat(toStringAppendFormat, PrefSufCuil)
            End If
         End With
         Return stb.ToString()
      End If
   End Function

   Public Overrides Function ToString() As String
      Return ToString(False)
   End Function

   Private Const FormatExceptionFormat As String = "No se puede convertir el valor '{0}' a CodigoBarraDocumento"
   Public Shared Function Parse(s As String) As CodigoBarraDocumento
      Dim numeroTramite As Long
      Dim apellidos As String
      Dim nombres As String
      Dim sexo As String
      Dim numeroDocumento As Long
      Dim strNumeroDocumento As String
      Dim ejemplar As String
      Dim fechaNacimiento As DateTime
      Dim fechaEmision As DateTime
      Dim prefSufCuil As String


      Dim split As String() = s.Split(""""c)
      If split.Length < 8 Then
         Throw New FormatException(String.Format(FormatExceptionFormat, s))
      End If
      'Si el DNI tiene 13+ posiciones pertenece a los DNI viejos que tienen un orden diferente.
      If split.Length < 13 Then
         If IsNumeric(split(0)) Then
            numeroTramite = Long.Parse(split(0))
         Else
            Throw New FormatException(String.Format(FormatExceptionFormat, s))
         End If
         apellidos = split(1)
         nombres = split(2)
         sexo = split(3)
         strNumeroDocumento = split(4).DejarSoloNumeros()
         If IsNumeric(strNumeroDocumento) Then
            numeroDocumento = Long.Parse(strNumeroDocumento)
         Else
            Throw New FormatException(String.Format(FormatExceptionFormat, s))
         End If
         ejemplar = split(5)
         If Not DateTime.TryParseExact(split(6), "dd-MM-yyyy", Nothing, Globalization.DateTimeStyles.None, fechaNacimiento) Then
            Throw New FormatException(String.Format(FormatExceptionFormat, s))
         End If
         If Not DateTime.TryParseExact(split(7), "dd-MM-yyyy", Nothing, Globalization.DateTimeStyles.None, fechaEmision) Then
            Throw New FormatException(String.Format(FormatExceptionFormat, s))
         End If

         'Los DNI anteriores a 2015 tienen 8 posiciones
         If split.Length > 8 Then
            prefSufCuil = split(8)
         Else
            prefSufCuil = ""
         End If

      ElseIf split.Length >= 13 Then
         'Datos propios de este formato
         Dim nacionalidad As String
         Dim oficinaIdentificacion As Integer
         Dim fechaVencimiento As DateTime


         If IsNumeric(split(1)) Then
            numeroDocumento = Long.Parse(split(1))
         Else
            Throw New FormatException(String.Format(FormatExceptionFormat, s))
         End If
         ejemplar = split(2)
         apellidos = split(4)
         nombres = split(5)

         nacionalidad = split(6)

         If Not DateTime.TryParseExact(split(7), "dd-MM-yyyy", Nothing, Globalization.DateTimeStyles.None, fechaNacimiento) Then
            Throw New FormatException(String.Format(FormatExceptionFormat, s))
         End If

         sexo = split(8)

         If Not DateTime.TryParseExact(split(9), "dd-MM-yyyy", Nothing, Globalization.DateTimeStyles.None, fechaEmision) Then
            Throw New FormatException(String.Format(FormatExceptionFormat, s))
         End If

         If IsNumeric(split(10)) Then
            numeroTramite = Long.Parse(split(10))
         Else
            Throw New FormatException(String.Format(FormatExceptionFormat, s))
         End If

         If IsNumeric(split(11)) Then
            oficinaIdentificacion = Integer.Parse(split(11))
         Else
            Throw New FormatException(String.Format(FormatExceptionFormat, s))
         End If
         If Not DateTime.TryParseExact(split(12), "dd-MM-yyyy", Nothing, Globalization.DateTimeStyles.None, fechaVencimiento) Then
            Throw New FormatException(String.Format(FormatExceptionFormat, s))
         End If

         prefSufCuil = ""

      Else
         Throw New FormatException(String.Format(FormatExceptionFormat, s))
      End If

      Return New CodigoBarraDocumento(s,
                                      numeroTramite, apellidos, nombres, sexo,
                                      numeroDocumento, ejemplar, fechaNacimiento, fechaEmision,
                                      prefSufCuil)
   End Function

   Public Shared Function TryParse(s As String, ByRef result As CodigoBarraDocumento) As Boolean
      Try
         Dim tempResult As CodigoBarraDocumento = Parse(s)
         result = tempResult
         Return True
      Catch ex As Exception
         Return False
      End Try
   End Function

End Structure