Imports System.Text
Imports System.IO

Public Class SICOSS

#Region "Metodos Privados"


#End Region

#Region "Propiedades"

   Private _lineas As List(Of SICOSSLinea)
   Public ReadOnly Property Lineas() As List(Of SICOSSLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of SICOSSLinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As SICOSSLinea In Me.Lineas
            If li.Procesar Then
               cant += 1
            End If
         Next
         Return cant
      End Get
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(ByVal destino As String)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         For Each linea As SICOSSLinea In Lineas
            If linea.Procesar Then
               stb.Append(linea.GetLinea()).AppendLine()
            End If
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class SICOSSLinea

#Region "Campos"

   Private _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetLinea() As String
      With Me._stb
         .Length = 0
         'CUIL / 1 /11
         .AppendFormat(Me.CUIL.ToString(New String("0"c, 11)))
         'Apellido y Nombre / 12 /30
         .AppendFormat(Me.ApellidoYNombre)
         'Conyuge / 42 / 1
         If Me.Conyuge Then
            .AppendFormat("1")
         Else
            .AppendFormat("0")
         End If
         'Cantidad de Hijos / 43 / 2
         .AppendFormat(Me.CantidadDeHijos.ToString("00"))
         'Codigo de situación / 45 / 2
         .AppendFormat(Me.CodigoDeSituacion.ToString("00"))
         'Codigo de condicion / 47 / 2
         .AppendFormat(Me.CodigoDeCondicion.ToString("00"))
         'Codigo de actividad / 49 / 3
         .AppendFormat(Me.CodigoDeActividad.ToString("000"))
         'Codigo de zona / 52 / 2
         .AppendFormat(Me.CodigoDeZona.ToString("00"))
         'Porcentaje de aporte adicional SS / 54 / 5
         .AppendFormat(Me.PorcentajeDeAporteAdicionalSS.ToString("00.00"))
         'Código de Modalidad de Contratación / 59 / 3
         .AppendFormat(Me.CodigoDeModalidadDeContratacion.ToString("000"))
         'Código de Obra Social  / 62 / 6
         .AppendFormat(Me.CodigoDeObraSocial.ToString("000000"))
         'Cantidad de Adherentes   / 68 / 2
         .AppendFormat(Me.CantidadDeAdherentes.ToString("000000"))
         'Remuneración Total / 70 / 12
         .AppendFormat(Me.RemuneracionTotal.ToString("000000000.00"))
         'Remuneración Imponible 1 / 82 / 12
         .AppendFormat(Me.RemuneracionImponible1.ToString("000000000.00"))
         'Asignaciones Familiares Pagadas / 94 / 9
         .AppendFormat(Me.AsignacionesFamiliaresPagadas.ToString("000000.00"))
         'Importe Aporte Voluntario  / 103 / 9
         .AppendFormat(Me.ImporteAporteVoluntario.ToString("000000.00"))
         'Importe Adicional OS  / 112 / 9
         .AppendFormat(Me.ImporteAdicionalOS.ToString("000000.00"))
         'Importe Excedentes Aportes SS  / 121 / 9
         .AppendFormat(Me.ImporteExcedentesAportesSS.ToString("000000.00"))
         'Importe Excedentes Aportes OS  / 130 / 9
         .AppendFormat(Me.ImporteExcedentesAportesOS.ToString("000000.00"))
         'Provincia Localidad  / 139 / 50
         .AppendFormat(Me.ProvinciaLocalidad)
         'Remuneración Imponible 2 / 189 / 12
         .AppendFormat(Me.RemuneracionImponible2.ToString("000000000.00"))
         'Remuneración Imponible 3 / 201 / 12
         .AppendFormat(Me.RemuneracionImponible3.ToString("000000000.00"))
         'Remuneración Imponible 4 / 213 / 12
         .AppendFormat(Me.RemuneracionImponible4.ToString("000000000.00"))
         'Código de Siniestrado / 225 / 2
         .AppendFormat(Me.CodigoDeSiniestrado.ToString("00"))
         'Marca de Corresponde Reducción / 227 / 1
         .AppendFormat(Me.MarcaDeCorrespondeReduccion.ToString("0"))
         'Capital de Recomposición de LRT / 228 / 9
         .AppendFormat(Me.CapitalDeRecomposicionDeLRT.ToString("000000.00"))
         'Tipo de empresa / 237 / 1
         .AppendFormat(Me.TipoDeEmpresa.ToString("0"))
         'Aporte Adicional de Obra Social / 238 / 9
         .AppendFormat(Me.AporteAdicionalDeObraSocial.ToString("000000.00"))
         'Regimen / 247 / 1
         .AppendFormat(Me.Regimen.ToString("0"))
         'Situación de Revista 1 / 248 / 2
         .AppendFormat(Me.SituacionDeRevista1.ToString("00"))
         'Dia inicio Situación de Revista 1 / 250 / 2
         .AppendFormat(Me.DiaInicioSituacionDeRevista1.ToString("00"))
         'Situación de Revista 2 / 252 / 2
         .AppendFormat(Me.SituacionDeRevista2.ToString("00"))
         'Dia inicio Situación de Revista 2 / 254 / 2
         .AppendFormat(Me.DiaInicioSituacionDeRevista2.ToString("00"))
         'Situación de Revista 3 / 256 / 2
         .AppendFormat(Me.SituacionDeRevista3.ToString("00"))
         'Dia inicio Situación de Revista 3 / 258 / 2
         .AppendFormat(Me.DiaInicioSituacionDeRevista3.ToString("00"))
         'Sueldo + Adicionales  / 260 / 12
         .AppendFormat(Me.SueldosMasAdicionales.ToString("000000000.00"))
         'SAC  / 272 / 12
         .AppendFormat(Me.SAC.ToString("000000000.00"))
         'Horas Extra  / 284 / 12
         .AppendFormat(Me.HorasExtras.ToString("000000000.00"))
         'Zona desfavorable / 296 / 12
         .AppendFormat(Me.ZonaDesfavorable.ToString("000000000.00"))
         'Vacaciones / 308 / 12
         .AppendFormat(Me.Vacaciones.ToString("000000000.00"))
         'Cantidad de días trabajados  / 320 / 9
         .AppendFormat(Me.CantidadDeDiasTrabajados.ToString("000000.00"))
         'Remuneración Imponible 5  / 329 / 12
         .AppendFormat(Me.RemuneracionImponible5.ToString("000000000.00"))
         'Trabajador Convencionado / 341 / 1
         If Me.TrabajadorConvencionado Then
            .AppendFormat("1")
         Else
            .AppendFormat("0")
         End If
         'Remuneración Imponible 6  / 342 / 12
         .AppendFormat(Me.RemuneracionImponible6.ToString("000000000.00"))
         'Tipo de Operación  / 354 / 1
         If Me.TipoDeOperacion Then
            .AppendFormat("1")
         Else
            .AppendFormat("0")
         End If
         'Adicionales / 355 / 12
         .AppendFormat(Me.Adicionales.ToString("000000000.00"))
         'Premios / 367 / 12
         .AppendFormat(Me.Premios.ToString("000000000.00"))
         'Rem.Dec.788/05 - Rem Impon. 8  / 379 / 12
         .AppendFormat(Me.RemDec78805RempImp8.ToString("000000000.00"))
         'Remuneración Imponible 7  / 391 / 12
         .AppendFormat(Me.RemuneracionImponible7.ToString("000000000.00"))
         'Cantidad de Horas Extras / 403 / 3
         .AppendFormat(Me.CantidadDeHorasExtras.ToString("000"))
         'Conceptos no remunerativos / 406 / 12
         .AppendFormat(Me.ConceptosNoRemunerativos.ToString("000000000.00"))
         'Maternidad / 418 / 12
         .AppendFormat(Me.Maternidad.ToString("000000000.00"))
         'Rectificación de remuneración  / 430 / 9
         .AppendFormat(Me.RectificacionDeRemuneracion.ToString("000000.00"))
         'Remuneración Imponible 9 / 439 / 12
         .AppendFormat(Me.RemuneracionImponible9.ToString("000000000.00"))
         'Contribucion tarea diferencial (%) / 451 / 9
         .AppendFormat(Me.ContribucionTareaDiferencial.ToString("000000.00"))
         'Horas trabajadas / 460 / 3
         .AppendFormat(Me.HorasTrabajadas.ToString("000"))
         'Seguro Colectivo de Vida Obligatorio / 463 / 1
         .AppendFormat(Me.SeguroColectivoDeVidaObligatorio.ToString("0"))

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"

   Private _procesar As Boolean = False
   Public Property Procesar() As Boolean
      Get
         Return _procesar
      End Get
      Set(ByVal value As Boolean)
         _procesar = value
      End Set
   End Property

   Private _linea As Integer = 0
   Public Property Linea() As Integer
      Get
         Return _linea
      End Get
      Set(ByVal value As Integer)
         _linea = value
      End Set
   End Property

   Private _cuil As Long
   Public Property CUIL() As Long
      Private Get
         Return _cuil
      End Get
      Set(ByVal value As Long)
         _cuil = value
      End Set
   End Property

   Private _apellidoYNombre As String
   Public Property ApellidoYNombre() As String
      Private Get
         If Me._apellidoYNombre.Length < 30 Then
            Me._apellidoYNombre = Me._apellidoYNombre.PadRight(30) 'agrego vacios
         End If
         Return _apellidoYNombre
      End Get
      Set(ByVal value As String)
         If value.Length > 30 Then
            _apellidoYNombre = value.Substring(0, 30)
         Else
            _apellidoYNombre = value
         End If
      End Set
   End Property

   Private _conyuge As Boolean
   Public Property Conyuge() As Boolean
      Private Get
         Return _conyuge
      End Get
      Set(ByVal value As Boolean)
         _conyuge = value
      End Set
   End Property

   Private _cantidadDeHijos As Short
   Public Property CantidadDeHijos() As Short
      Private Get
         Return _cantidadDeHijos
      End Get
      Set(ByVal value As Short)
         _cantidadDeHijos = value
      End Set
   End Property

   Private _codigoDeSituacion As Short
   Public Property CodigoDeSituacion() As Short
      Private Get
         Return _codigoDeSituacion
      End Get
      Set(ByVal value As Short)
         _codigoDeSituacion = value
      End Set
   End Property

   Private _codigoDeCondicion As Short
   Public Property CodigoDeCondicion() As Short
      Private Get
         Return _codigoDeCondicion
      End Get
      Set(ByVal value As Short)
         _codigoDeCondicion = value
      End Set
   End Property

   Private _codigoDeActividad As Short
   Public Property CodigoDeActividad() As Short
      Private Get
         Return _codigoDeActividad
      End Get
      Set(ByVal value As Short)
         _codigoDeActividad = value
      End Set
   End Property

   Private _codigoDeZona As Short
   Public Property CodigoDeZona() As Short
      Private Get
         Return _codigoDeZona
      End Get
      Set(ByVal value As Short)
         _codigoDeZona = value
      End Set
   End Property

   Private _porcentajeDeAporteAdicionalSS As Decimal
   Public Property PorcentajeDeAporteAdicionalSS() As Decimal
      Private Get
         Return _porcentajeDeAporteAdicionalSS
      End Get
      Set(ByVal value As Decimal)
         _porcentajeDeAporteAdicionalSS = value
      End Set
   End Property

   Private _codigoDeModalidadDeContratacion As Short
   Public Property CodigoDeModalidadDeContratacion() As Short
      Private Get
         Return _codigoDeModalidadDeContratacion
      End Get
      Set(ByVal value As Short)
         _codigoDeModalidadDeContratacion = value
      End Set
   End Property

   Private _codigoDeObraSocial As Integer
   Public Property CodigoDeObraSocial() As Integer
      Private Get
         Return _codigoDeObraSocial
      End Get
      Set(ByVal value As Integer)
         _codigoDeObraSocial = value
      End Set
   End Property

   Private _cantidadDeAdherentes As Short
   Public Property CantidadDeAdherentes() As Short
      Private Get
         Return _cantidadDeAdherentes
      End Get
      Set(ByVal value As Short)
         _cantidadDeAdherentes = value
      End Set
   End Property

   Private _remuneracionTotal As Decimal
   Public Property RemuneracionTotal() As Decimal
      Private Get
         Return _remuneracionTotal
      End Get
      Set(ByVal value As Decimal)
         _remuneracionTotal = value
      End Set
   End Property

   Private _remuneracionImponible1 As Decimal
   Public Property RemuneracionImponible1() As Decimal
      Private Get
         Return _remuneracionImponible1
      End Get
      Set(ByVal value As Decimal)
         _remuneracionImponible1 = value
      End Set
   End Property

   Private _asignacionesFamiliaresPagadas As Decimal
   Public Property AsignacionesFamiliaresPagadas() As Decimal
      Private Get
         Return _asignacionesFamiliaresPagadas
      End Get
      Set(ByVal value As Decimal)
         _asignacionesFamiliaresPagadas = value
      End Set
   End Property

   Private _importeAporteVoluntario As Decimal
   Public Property ImporteAporteVoluntario() As Decimal
      Private Get
         Return _importeAporteVoluntario
      End Get
      Set(ByVal value As Decimal)
         _importeAporteVoluntario = value
      End Set
   End Property

   Private _importeAdicionalOS As Decimal
   Public Property ImporteAdicionalOS() As Decimal
      Private Get
         Return _importeAdicionalOS
      End Get
      Set(ByVal value As Decimal)
         _importeAdicionalOS = value
      End Set
   End Property

   Private _importeExcedentesAportesSS As Decimal
   Public Property ImporteExcedentesAportesSS() As Decimal
      Private Get
         Return _importeExcedentesAportesSS
      End Get
      Set(ByVal value As Decimal)
         _importeExcedentesAportesSS = value
      End Set
   End Property

   Private _importeExcedentesAportesOS As Decimal
   Public Property ImporteExcedentesAportesOS() As Decimal
      Private Get
         Return _importeExcedentesAportesOS
      End Get
      Set(ByVal value As Decimal)
         _importeExcedentesAportesOS = value
      End Set
   End Property

   Private _provinciaLocalidad As String
   Public Property ProvinciaLocalidad() As String
      Private Get
         If Me._provinciaLocalidad.Length < 50 Then
            Me._provinciaLocalidad = Me._provinciaLocalidad.PadRight(50) 'agrego vacios
         End If
         Return _provinciaLocalidad
      End Get
      Set(ByVal value As String)
         If value.Length > 50 Then
            _provinciaLocalidad = value.Substring(0, 50)
         Else
            _provinciaLocalidad = value
         End If
      End Set
   End Property

   Private _remuneracionImponible2 As Decimal
   Public Property RemuneracionImponible2() As Decimal
      Private Get
         Return _remuneracionImponible2
      End Get
      Set(ByVal value As Decimal)
         _remuneracionImponible2 = value
      End Set
   End Property

   Private _remuneracionImponible3 As Decimal
   Public Property RemuneracionImponible3() As Decimal
      Private Get
         Return _remuneracionImponible3
      End Get
      Set(ByVal value As Decimal)
         _remuneracionImponible3 = value
      End Set
   End Property

   Private _remuneracionImponible4 As Decimal
   Public Property RemuneracionImponible4() As Decimal
      Private Get
         Return _remuneracionImponible4
      End Get
      Set(ByVal value As Decimal)
         _remuneracionImponible4 = value
      End Set
   End Property

   Private _codigoDeSiniestrado As Short
   Public Property CodigoDeSiniestrado() As Short
      Private Get
         Return _codigoDeSiniestrado
      End Get
      Set(ByVal value As Short)
         _codigoDeSiniestrado = value
      End Set
   End Property

   Private _marcaDeCorrespondeReduccion As Short
   Public Property MarcaDeCorrespondeReduccion() As Short
      Private Get
         Return _marcaDeCorrespondeReduccion
      End Get
      Set(ByVal value As Short)
         _marcaDeCorrespondeReduccion = value
      End Set
   End Property

   Private _capitalDeRecomposicionDeLRT As Decimal
   Public Property CapitalDeRecomposicionDeLRT() As Decimal
      Private Get
         Return _capitalDeRecomposicionDeLRT
      End Get
      Set(ByVal value As Decimal)
         _capitalDeRecomposicionDeLRT = value
      End Set
   End Property

   Private _tipoDeEmpresa As Short
   Public Property TipoDeEmpresa() As Short
      Private Get
         Return _tipoDeEmpresa
      End Get
      Set(ByVal value As Short)
         _tipoDeEmpresa = value
      End Set
   End Property

   Private _aporteAdicionalDeObraSocial As Decimal
   Public Property AporteAdicionalDeObraSocial() As Decimal
      Private Get
         Return _aporteAdicionalDeObraSocial
      End Get
      Set(ByVal value As Decimal)
         _aporteAdicionalDeObraSocial = value
      End Set
   End Property

   Private _regimen As Short
   Public Property Regimen() As Short
      Private Get
         Return _regimen
      End Get
      Set(ByVal value As Short)
         _regimen = value
      End Set
   End Property

   Private _situacionDeRevista1 As Short
   Public Property SituacionDeRevista1() As Short
      Private Get
         Return _situacionDeRevista1
      End Get
      Set(ByVal value As Short)
         _situacionDeRevista1 = value
      End Set
   End Property

   Private _diaInicioSituacionDeRevista1 As Short
   Public Property DiaInicioSituacionDeRevista1() As Short
      Private Get
         Return _diaInicioSituacionDeRevista1
      End Get
      Set(ByVal value As Short)
         _diaInicioSituacionDeRevista1 = value
      End Set
   End Property

   Private _situacionDeRevista2 As Short
   Public Property SituacionDeRevista2() As Short
      Private Get
         Return _situacionDeRevista2
      End Get
      Set(ByVal value As Short)
         _situacionDeRevista2 = value
      End Set
   End Property

   Private _diaInicioSituacionDeRevista2 As Short
   Public Property DiaInicioSituacionDeRevista2() As Short
      Private Get
         Return _diaInicioSituacionDeRevista2
      End Get
      Set(ByVal value As Short)
         _diaInicioSituacionDeRevista2 = value
      End Set
   End Property

   Private _situacionDeRevista3 As Short
   Public Property SituacionDeRevista3() As Short
      Private Get
         Return _situacionDeRevista3
      End Get
      Set(ByVal value As Short)
         _situacionDeRevista3 = value
      End Set
   End Property

   Private _diaInicioSituacionDeRevista3 As Short
   Public Property DiaInicioSituacionDeRevista3() As Short
      Private Get
         Return _diaInicioSituacionDeRevista3
      End Get
      Set(ByVal value As Short)
         _diaInicioSituacionDeRevista3 = value
      End Set
   End Property

   Private _sueldosMasAdicionales As Decimal
   Public Property SueldosMasAdicionales() As Decimal
      Private Get
         Return _sueldosMasAdicionales
      End Get
      Set(ByVal value As Decimal)
         _sueldosMasAdicionales = value
      End Set
   End Property

   Private _sac As Decimal
   Public Property SAC() As Decimal
      Private Get
         Return _sac
      End Get
      Set(ByVal value As Decimal)
         _sac = value
      End Set
   End Property

   Private _horasExtras As Decimal
   Public Property HorasExtras() As Decimal
      Private Get
         Return _horasExtras
      End Get
      Set(ByVal value As Decimal)
         _horasExtras = value
      End Set
   End Property

   Private _zonaDesfavorable As Decimal
   Public Property ZonaDesfavorable() As Decimal
      Private Get
         Return _zonaDesfavorable
      End Get
      Set(ByVal value As Decimal)
         _zonaDesfavorable = value
      End Set
   End Property

   Private _vacaciones As Decimal
   Public Property Vacaciones() As Decimal
      Private Get
         Return _vacaciones
      End Get
      Set(ByVal value As Decimal)
         _vacaciones = value
      End Set
   End Property

   Private _cantidadDeDiasTrabajados As Decimal
   Public Property CantidadDeDiasTrabajados() As Decimal
      Private Get
         Return _cantidadDeDiasTrabajados
      End Get
      Set(ByVal value As Decimal)
         _cantidadDeDiasTrabajados = value
      End Set
   End Property

   Private _remuneracionImponible5 As Decimal
   Public Property RemuneracionImponible5() As Decimal
      Private Get
         Return _remuneracionImponible5
      End Get
      Set(ByVal value As Decimal)
         _remuneracionImponible5 = value
      End Set
   End Property

   Private _trabajadorConvencionado As Boolean
   Public Property TrabajadorConvencionado() As Boolean
      Private Get
         Return _trabajadorConvencionado
      End Get
      Set(ByVal value As Boolean)
         _trabajadorConvencionado = value
      End Set
   End Property

   Private _remuneracionImponible6 As Decimal
   Public Property RemuneracionImponible6() As Decimal
      Private Get
         Return _remuneracionImponible6
      End Get
      Set(ByVal value As Decimal)
         _remuneracionImponible6 = value
      End Set
   End Property

   Private _tipoDeOperacion As Boolean
   Public Property TipoDeOperacion() As Boolean
      Private Get
         Return _tipoDeOperacion
      End Get
      Set(ByVal value As Boolean)
         _tipoDeOperacion = value
      End Set
   End Property

   Private _adicionales As Decimal
   Public Property Adicionales() As Decimal
      Private Get
         Return _adicionales
      End Get
      Set(ByVal value As Decimal)
         _adicionales = value
      End Set
   End Property

   Private _premios As Decimal
   Public Property Premios() As Decimal
      Private Get
         Return _premios
      End Get
      Set(ByVal value As Decimal)
         _premios = value
      End Set
   End Property

   Private _remDec78805RempImp8 As Decimal
   Public Property RemDec78805RempImp8() As Decimal
      Private Get
         Return _remDec78805RempImp8
      End Get
      Set(ByVal value As Decimal)
         _remDec78805RempImp8 = value
      End Set
   End Property

   Private _remuneracionImponible7 As Decimal
   Public Property RemuneracionImponible7() As Decimal
      Private Get
         Return _remuneracionImponible7
      End Get
      Set(ByVal value As Decimal)
         _remuneracionImponible7 = value
      End Set
   End Property

   Private _cantidadDeHorasExtras As Short
   Public Property CantidadDeHorasExtras() As Short
      Private Get
         Return _cantidadDeHorasExtras
      End Get
      Set(ByVal value As Short)
         _cantidadDeHorasExtras = value
      End Set
   End Property

   Private _conceptosNoRemunerativos As Decimal
   Public Property ConceptosNoRemunerativos() As Decimal
      Private Get
         Return _conceptosNoRemunerativos
      End Get
      Set(ByVal value As Decimal)
         _conceptosNoRemunerativos = value
      End Set
   End Property

   Private _maternidad As Decimal
   Public Property Maternidad() As Decimal
      Private Get
         Return _maternidad
      End Get
      Set(ByVal value As Decimal)
         _maternidad = value
      End Set
   End Property

   Private _rectificacionDeRemuneracion As Decimal
   Public Property RectificacionDeRemuneracion() As Decimal
      Private Get
         Return _rectificacionDeRemuneracion
      End Get
      Set(ByVal value As Decimal)
         _rectificacionDeRemuneracion = value
      End Set
   End Property

   Private _remuneracionImponible9 As Decimal
   Public Property RemuneracionImponible9() As Decimal
      Private Get
         Return _remuneracionImponible9
      End Get
      Set(ByVal value As Decimal)
         _remuneracionImponible9 = value
      End Set
   End Property

   Private _contribucionTareaDiferencial As Decimal
   Public Property ContribucionTareaDiferencial() As Decimal
      Private Get
         Return _contribucionTareaDiferencial
      End Get
      Set(ByVal value As Decimal)
         _contribucionTareaDiferencial = value
      End Set
   End Property

   Private _horasTrabajadas As Short
   Public Property HorasTrabajadas() As Short
      Private Get
         Return _horasTrabajadas
      End Get
      Set(ByVal value As Short)
         _horasTrabajadas = value
      End Set
   End Property

   Private _seguroColectivoDeVidaObligatorio As Short
   Public Property SeguroColectivoDeVidaObligatorio() As Short
      Private Get
         Return _seguroColectivoDeVidaObligatorio
      End Get
      Set(ByVal value As Short)
         _seguroColectivoDeVidaObligatorio = value
      End Set
   End Property

   Private _tieneError As Boolean = False
   Public ReadOnly Property TieneError() As Boolean
      Get
         Me.SeteaErrores()
         Return _tieneError
      End Get
   End Property

   Private _tipoError As String = String.Empty
   Public ReadOnly Property TipoError() As String
      Get
         Me.SeteaErrores()
         Return _tipoError
      End Get
   End Property



#End Region

#Region "Metodos Privados"

   Private Sub SeteaErrores()
      Dim errores As String = String.Empty

      'If Not Me.EstaBienElCodigoDeDocumento(_codigoDeDocumentoIdentificatorioDelComprador) Then
      '   errores += "Para este Tipo de Comprobante el Código de Documento del comprador no puede ser distinto a CUIT (80). "
      'End If

      Me._tieneError = (Not String.IsNullOrEmpty(errores))
      Me._tipoError = errores
   End Sub

   'Private Function EstaBienElCodigoDeDocumento(ByVal codigoDeDocumento As Integer) As Boolean
   '   If codigoDeDocumento = 80 Then
   '      Return True
   '   Else
   '      If codigoDeDocumento = 0 Then
   '         Return False
   '      Else
   '         'si el codigo del documento es distinto a 80 (CUIT) entonces tengo que verificar el tipo de comprobante
   '         If Me._tipoDeComprobante = 6 Or _
   '               Me._tipoDeComprobante = 7 Or _
   '               Me._tipoDeComprobante = 8 Or _
   '               Me._tipoDeComprobante = 9 Or _
   '               Me._tipoDeComprobante = 10 Or _
   '               Me._tipoDeComprobante = 35 Or _
   '               Me._tipoDeComprobante = 40 Or _
   '               Me._tipoDeComprobante = 61 Or _
   '               Me._tipoDeComprobante = 62 Or _
   '               Me._tipoDeComprobante = 82 Then
   '            Return True
   '         Else
   '            Return False
   '         End If
   '      End If
   '   End If
   'End Function

   'Private Function EsUnTipoDeComprobanteM() As Boolean
   '   If Me._tipoDeComprobante = 51 Or _
   '         Me._tipoDeComprobante = 52 Or _
   '         Me._tipoDeComprobante = 53 Or _
   '         Me._tipoDeComprobante = 54 Or _
   '         Me._tipoDeComprobante = 55 Or _
   '         Me._tipoDeComprobante = 58 Or _
   '         Me._tipoDeComprobante = 59 Then
   '      Return True
   '   Else
   '      Return False
   '   End If
   'End Function

#End Region

End Class

