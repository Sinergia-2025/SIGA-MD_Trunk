<Serializable()>
Public Class SueldosPersonal
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdLegajo
      NombrePersonal
      Domicilio
      Localidad
      TipoDocPersonal
      NroDocPersonal
      idNacionalidad
      Sexo
      IdEstadoCivil
      Cuil
      LegajoMinTrabajo
      idObraSocial
      CodObraSocial
      FechaNacimiento
      FechaIngreso
      FechaBaja
      idCategoria
      CentroCosto
      SueldoBasico
      MejorSueldo
      AcumuladoAnual
      AcumuladoSalarioFamiliar
      SueldoActual
      SalarioFamiliarActual
      AFJP
      AnteriorAcumuladoAnual
      AnteriorMejorSueldo
      AnteriorSalarioFamiliar
      IdMotivoBaja
      IdLugarActividad
      DatosFamiliares
      IdBancoCtaBancaria
      IdCuentasBancariasClaseCtaBancaria
      NumeroCuentaBancaria
      CBU
      Hijos
      Familiares
   End Enum

#Region "Campos"

   Private _idLegajo As Integer
   Private _NombrePersonal As String
   Private _Domicilio As String
   Private _Localidad As Integer
   Private _TipoDocPersonal As String
   Private _NroDocPersonal As Long
   Private _idNacionalidad As Integer
   Private _Sexo As String
   Private _IdEstadoCivil As Integer
   Private _Cuil As Long
   Private _LegajoMinTrabajo As Long
   Private _idObraSocial As Integer
   Private _CodObraSocial As Integer
   Private _FechaNacimiento As DateTime
   Private _FechaIngreso As DateTime
   Private _fechaBaja As DateTime
   Private _idCategoria As Integer
   Private _CentroCosto As Integer
   Private _SueldoBasico As System.Decimal
   Private _MejorSueldo As System.Decimal
   Private _AcumuladoAnual As System.Decimal
   Private _AcumuladoSalarioFamiliar As System.Decimal
   Private _SueldoActual As System.Decimal
   Private _SalarioFamiliarActual As System.Decimal
   Private _AFJP As String
   Private _AnteriorAcumuladoAnual As System.Decimal
   Private _AnteriorMejorSueldo As System.Decimal
   Private _AnteriorSalarioFamiliar As System.Decimal
   Private _Hijos As DataTable
   Private _motivoBaja As Entidades.SueldosMotivoBaja
   Private _lugarActividad As Entidades.SueldosLugarActividad
   Private _datosFamiliares As String
   Private _banco As Eniac.Entidades.Banco
   Private _cuentaBancariaClase As Eniac.Entidades.CuentaBancariaClase
   Private _numeroCuentaBancaria As String
   Private _cbu As String
   Private _Familiares As DataTable

#End Region

#Region "Propiedades"

   Public Property idLegajo() As Integer
      Get
         Return Me._idLegajo
      End Get
      Set(ByVal value As Integer)
         Me._idLegajo = value
      End Set
   End Property

   Public Property NombrePersonal() As String
      Get
         Return Me._NombrePersonal
      End Get
      Set(ByVal value As String)
         Me._NombrePersonal = value
      End Set
   End Property

   Public Property Domicilio() As String
      Get
         Return Me._Domicilio
      End Get
      Set(ByVal value As String)
         Me._Domicilio = value
      End Set
   End Property

   Public Property idLocalidad() As Integer
      Get
         Return Me._Localidad
      End Get
      Set(ByVal value As Integer)
         Me._Localidad = value
      End Set
   End Property

   Public Property TipoDocPersonal() As String
      Get
         Return Me._TipoDocPersonal
      End Get
      Set(ByVal value As String)
         Me._TipoDocPersonal = value
      End Set
   End Property

   Public Property NroDocPersonal() As Long
      Get
         Return Me._NroDocPersonal
      End Get
      Set(ByVal value As Long)
         Me._NroDocPersonal = value
      End Set
   End Property

   Public Property idNacionalidad() As Integer
      Get
         Return Me._idNacionalidad
      End Get
      Set(ByVal value As Integer)
         Me._idNacionalidad = value
      End Set
   End Property

   Public Property Sexo() As String
      Get
         Return Me._Sexo
      End Get
      Set(ByVal value As String)
         Me._Sexo = value
      End Set
   End Property

   Public Property IdEstadoCivil() As Integer
      Get
         Return Me._IdEstadoCivil
      End Get
      Set(ByVal value As Integer)
         Me._IdEstadoCivil = value
      End Set
   End Property

   Public Property Cuil() As Long
      Get
         Return Me._Cuil
      End Get
      Set(ByVal value As Long)
         Me._Cuil = value
      End Set
   End Property

   Public Property LegajoMinTrabajo() As Long
      Get
         Return Me._LegajoMinTrabajo
      End Get
      Set(ByVal value As Long)
         Me._LegajoMinTrabajo = value
      End Set
   End Property

   Public Property idObraSocial() As Integer
      Get
         Return Me._idObraSocial
      End Get
      Set(ByVal value As Integer)
         Me._idObraSocial = value
      End Set
   End Property

   Public Property CodObraSocial() As Integer
      Get
         Return Me._CodObraSocial
      End Get
      Set(ByVal value As Integer)
         Me._CodObraSocial = value
      End Set
   End Property

   Public Property FechaNacimiento() As DateTime
      Get
         Return Me._FechaNacimiento
      End Get
      Set(ByVal value As DateTime)
         Me._FechaNacimiento = value
      End Set
   End Property

   Public Property FechaIngreso() As DateTime
      Get
         Return Me._FechaIngreso
      End Get
      Set(ByVal value As DateTime)
         Me._FechaIngreso = value
      End Set
   End Property

   Public Property FechaBaja() As DateTime
      Get
         Return Me._fechaBaja
      End Get
      Set(ByVal value As DateTime)
         Me._fechaBaja = value
      End Set
   End Property

   Public Property idCategoria() As Integer
      Get
         Return Me._idCategoria
      End Get
      Set(ByVal value As Integer)
         Me._idCategoria = value
      End Set
   End Property

   Public Property CentroCosto() As Integer
      Get
         Return Me._CentroCosto
      End Get
      Set(ByVal value As Integer)
         Me._CentroCosto = value
      End Set
   End Property

   Public Property SueldoBasico() As System.Decimal
      Get
         Return Me._SueldoBasico
      End Get
      Set(ByVal value As System.Decimal)
         Me._SueldoBasico = value
      End Set
   End Property

   Public Property MejorSueldo() As System.Decimal
      Get
         Return Me._MejorSueldo
      End Get
      Set(ByVal value As System.Decimal)
         Me._MejorSueldo = value
      End Set
   End Property

   Public Property AcumuladoAnual() As System.Decimal
      Get
         Return Me._AcumuladoAnual
      End Get
      Set(ByVal value As System.Decimal)
         Me._AcumuladoAnual = value
      End Set
   End Property

   Public Property AcumuladoSalarioFamiliar() As System.Decimal
      Get
         Return Me._AcumuladoSalarioFamiliar
      End Get
      Set(ByVal value As System.Decimal)
         Me._AcumuladoSalarioFamiliar = value
      End Set
   End Property

   Public Property SueldoActual() As System.Decimal
      Get
         Return Me._SueldoActual
      End Get
      Set(ByVal value As System.Decimal)
         Me._SueldoActual = value
      End Set
   End Property

   Public Property SalarioFamiliarActual() As System.Decimal
      Get
         Return Me._SalarioFamiliarActual
      End Get
      Set(ByVal value As System.Decimal)
         Me._SalarioFamiliarActual = value
      End Set
   End Property

   Public Property AFJP() As String
      Get
         Return Me._AFJP
      End Get
      Set(ByVal value As String)
         Me._AFJP = value
      End Set
   End Property

   Public Property AnteriorAcumuladoAnual() As System.Decimal
      Get
         Return Me._AnteriorAcumuladoAnual
      End Get
      Set(ByVal value As System.Decimal)
         Me._AnteriorAcumuladoAnual = value
      End Set
   End Property

   Public Property AnteriorMejorSueldo() As System.Decimal
      Get
         Return Me._AnteriorMejorSueldo
      End Get
      Set(ByVal value As System.Decimal)
         Me._AnteriorMejorSueldo = value
      End Set
   End Property

   Public Property AnteriorSalarioFamiliar() As System.Decimal
      Get
         Return Me._AnteriorSalarioFamiliar
      End Get
      Set(ByVal value As System.Decimal)
         Me._AnteriorSalarioFamiliar = value
      End Set
   End Property

   Public Property MotivoBaja() As Entidades.SueldosMotivoBaja
      Get
         If Me._motivoBaja Is Nothing Then
            Me._motivoBaja = New Entidades.SueldosMotivoBaja()
         End If
         Return _motivoBaja
      End Get
      Set(ByVal value As Entidades.SueldosMotivoBaja)
         _motivoBaja = value
      End Set
   End Property

   Public Property LugarActividad() As Entidades.SueldosLugarActividad
      Get
         If Me._lugarActividad Is Nothing Then
            Me._lugarActividad = New Entidades.SueldosLugarActividad()
         End If
         Return _lugarActividad
      End Get
      Set(ByVal value As Entidades.SueldosLugarActividad)
         _lugarActividad = value
      End Set
   End Property


   Public Property DatosFamiliares() As String
      Get
         Return _datosFamiliares
      End Get
      Set(ByVal value As String)
         _datosFamiliares = value
      End Set
   End Property

   Public Property Banco() As Eniac.Entidades.Banco
      Get
         If Me._banco Is Nothing Then
            Me._banco = New Eniac.Entidades.Banco()
         End If
         Return _banco
      End Get
      Set(ByVal value As Eniac.Entidades.Banco)
         _banco = value
      End Set
   End Property

   Public Property CuentaBancariaClase() As Eniac.Entidades.CuentaBancariaClase
      Get
         If Me._cuentaBancariaClase Is Nothing Then
            Me._cuentaBancariaClase = New Eniac.Entidades.CuentaBancariaClase()
         End If
         Return _cuentaBancariaClase
      End Get
      Set(ByVal value As Eniac.Entidades.CuentaBancariaClase)
         _cuentaBancariaClase = value
      End Set
   End Property

   Public Property NumeroCuentaBancaria() As String
      Get
         Return _numeroCuentaBancaria
      End Get
      Set(ByVal value As String)
         _numeroCuentaBancaria = value
      End Set
   End Property

   Public Property CBU() As String
      Get
         Return _cbu
      End Get
      Set(ByVal value As String)
         _cbu = value
      End Set
   End Property

   Public Property Hijos() As DataTable
      Get
         If Me._Hijos Is Nothing Then
            Me._Hijos = New DataTable()
         End If
         Return Me._Hijos
      End Get
      Set(ByVal value As DataTable)
         Me._Hijos = value
      End Set
   End Property

   Public Property Familiares() As DataTable
      Get
         If Me._Familiares Is Nothing Then
            Me._Familiares = New DataTable()
         End If
         Return Me._Familiares
      End Get
      Set(ByVal value As DataTable)
         Me._Familiares = value
      End Set
   End Property

#End Region

End Class