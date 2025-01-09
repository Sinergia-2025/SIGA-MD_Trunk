Imports System.Web.Script.Serialization

Partial Class Publicos

   Private Shared ReadOnly Property TieneModulos As ParametrosModulos
      Get
         Return ParametrosCache.Instancia.GetValorObject(actual.Sucursal, Entidades.Parametro.Parametros.TIENEMODULOS, New ParametrosModulosConverter())
      End Get
   End Property


   Public Shared ReadOnly Property TieneModuloFacturacionElectronica() As Boolean
      Get
         Return TieneModulos.TieneModuloFacturacionElectronica
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloCuentaCorrienteClientes() As Boolean
      Get
         Return TieneModulos.TieneModuloCuentaCorrienteClientes
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloCuentaCorrienteProveedores() As Boolean
      Get
         Return TieneModulos.TieneModuloCuentaCorrienteProveedores
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloCaja() As Boolean
      Get
         Return TieneModulos.TieneModuloCaja
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloBanco() As Boolean
      Get
         Return TieneModulos.TieneModuloBanco
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloPedidos() As Boolean
      Get
         Return TieneModulos.TieneModuloPedidos
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloPedidosProv() As Boolean
      Get
         Return TieneModulos.TieneModuloPedidosProv
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloProduccion() As Boolean
      Get
         Return TieneModulos.TieneModuloProduccion
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloContabilidad() As Boolean
      Get
         Return TieneModulos.TieneModuloContabilidad
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloCargos() As Boolean
      Get
         Return TieneModulos.TieneModuloCargos
      End Get
   End Property


   Public Shared ReadOnly Property TieneModuloControlDeLicencias() As Boolean
      Get
         Return TieneModulos.TieneModuloControlDeLicencias
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloFichas() As Boolean
      Get
         Return TieneModulos.TieneModuloFichas
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloSueldos() As Boolean
      Get
         Return TieneModulos.TieneModuloSueldos
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloExpensas() As Boolean
      Get
         Return TieneModulos.TieneModuloExpensas
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloContratistas() As Boolean
      Get
         Return TieneModulos.TieneModuloContratistas
      End Get
   End Property
   Public Shared ReadOnly Property TieneModuloAlquiler() As Boolean
      Get
         Return TieneModulos.TieneModuloAlquiler
      End Get
   End Property


   Public Shared ReadOnly Property ExtrasSinergia() As Boolean
      Get
         Return TieneModulos.ExtrasSinergia
      End Get
   End Property

   Public Shared ReadOnly Property TieneModuloMRP() As Boolean
      Get
         Return TieneModulos.TieneModuloMRP
      End Get
   End Property

End Class
Public Class ParametrosModulos
   Public Property TieneModuloFacturacionElectronica As Boolean

   Public Property TieneModuloCuentaCorrienteClientes As Boolean

   Public Property TieneModuloCuentaCorrienteProveedores As Boolean

   Public Property TieneModuloCaja As Boolean

   Public Property TieneModuloBanco As Boolean

   Public Property TieneModuloPedidos As Boolean

   Public Property TieneModuloPedidosProv As Boolean

   Public Property TieneModuloProduccion As Boolean

   Public Property TieneModuloContabilidad As Boolean

   Public Property TieneModuloCargos As Boolean


   Public Property TieneModuloControlDeLicencias As Boolean

   Public Property TieneModuloFichas As Boolean

   Public Property TieneModuloSueldos As Boolean

   Public Property TieneModuloExpensas As Boolean

   Public Property TieneModuloContratistas As Boolean

   Public Property TieneModuloAlquiler As Boolean


   Public Property ExtrasSinergia As Boolean

   Public Property TieneModuloMRP As Boolean

End Class
Public Class ParametrosModulosConverter
   Implements IParameterConverter(Of ParametrosModulos)
   Private _serializer As New JavaScriptSerializer()
   Private _onErrorAccion As Base.AccionesSiNoExisteRegistro

   Public Sub New()
      Me.New(Base.AccionesSiNoExisteRegistro.Excepcion)
   End Sub

   Public Sub New(onErrorAccion As Base.AccionesSiNoExisteRegistro)
      _onErrorAccion = onErrorAccion
   End Sub

   Public Function ConvertFromString(value As String) As ParametrosModulos Implements IParameterConverter(Of ParametrosModulos).ConvertFromString
      value = New Ayudantes.Criptografia().DecryptString128Bit(value, "clave")
      Return _serializer.Deserialize(Of ParametrosModulos)(value)
   End Function

   Public Function ConvertToString(obj As ParametrosModulos) As String Implements IParameterConverter(Of ParametrosModulos).ConvertToString
      Dim valor = _serializer.Serialize(obj)
      Return New Ayudantes.Criptografia().EncryptString128Bit(valor, "clave")
   End Function

   Public Function [Default]() As ParametrosModulos Implements IParameterConverter(Of ParametrosModulos).Default
      Return New ParametrosModulos()
   End Function

   Public Function HandleException(ex As Exception) As ParametrosModulos Implements IParameterConverter(Of ParametrosModulos).HandleException
      If _onErrorAccion = Base.AccionesSiNoExisteRegistro.Excepcion Then
         Throw New Exception(String.Format("Error convirtiendo parámetro: {0}", ex.Message), ex)
      ElseIf _onErrorAccion = Base.AccionesSiNoExisteRegistro.Nulo Then
         Return Nothing
      Else
         Return [Default]()
      End If
   End Function

End Class
Public Interface IParameterConverter(Of T)
   Function ConvertFromString(value As String) As T
   Function ConvertToString(obj As T) As String
   Function [Default]() As T
   Function HandleException(ex As Exception) As T
End Interface