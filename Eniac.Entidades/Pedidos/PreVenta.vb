Imports System.ComponentModel

Public Class PreVenta
   Inherits Eniac.Entidades.Entidad

   Public Enum FormatoWebPeridos
      SiWeb
      SiGA
      <Description("SiMovil.Pedidos")> SiMovilPedidos
   End Enum

   Public Enum Columnas
      Id
      FileNamePed
      IdEmpleado
      Fecha
   End Enum

   Public Property IdPreVenta As Integer
   Public Property Fecha As Date
   Public Property FileNamePed As String

   Private _vendedor As Eniac.Entidades.Empleado
   Public Property Vendedor() As Eniac.Entidades.Empleado
      Get
         If Me._vendedor Is Nothing Then
            Me._vendedor = New Eniac.Entidades.Empleado()
         End If
         Return _vendedor
      End Get
      Set(ByVal value As Eniac.Entidades.Empleado)
         _vendedor = value
      End Set
   End Property

#Region "Propiedades ReadOnly"
   Public ReadOnly Property NombreVendedor As String
      Get
         Return Vendedor.NombreEmpleado
      End Get
   End Property
   Public ReadOnly Property IdVendedor As Integer
      Get
         Return Vendedor.IdEmpleado
      End Get
   End Property
 
#End Region

   Public Enum PreventaFormatoArchivo
      Estandar
      PDA_CocaCola
      Web
   End Enum
   Public Enum PreventaEstadoPedido
      Normal
      ConError
      Advertencia
      Corregible
   End Enum

   Public Enum PreventaEstadoGrabacionPedido
      PENDIENTE
      GRABADO
      CONERROR
      MARCADO
      PROCESANDO
      EXISTE
   End Enum

   Public Enum AccionSinListaPrecios
      CargaManual
      Ruta
      Cliente
      Predeterminada
   End Enum

End Class