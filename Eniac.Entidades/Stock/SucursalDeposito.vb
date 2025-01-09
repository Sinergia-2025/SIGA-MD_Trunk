Public Class SucursalDeposito
   Inherits Entidad

   Public Const NombreTabla As String = "SucursalesDepositos"
   Public Enum Columnas
      IdDeposito
      NombreDeposito
      IdSucursal
      NombreSucursal
      SucursalAsociada
      DepositoAsociado
      CodigoDeposito
      DisponibleVenta
      Activo
      TipoDeposito
   End Enum
   Public Enum TiposDepositos
      <Description("Operativo")> OPERATIVO = 1
      <Description("Reservado")> RESERVADO = 2
      <Description("En Transito")> ENTRANSITO = 3
      <Description("Defectuoso")> DEFECTUOSO = 4
   End Enum

   Public Sub New()
      IdSucursal = actual.Sucursal.Id
      Activo = True
      DisponibleVenta = True
      TipoDeposito = TiposDepositos.OPERATIVO
      Usuarios = New List(Of SucursalDepositoUsuario)()
   End Sub

   Public Property IdDeposito As Integer
   Public Property IdSucursal As Integer
   Public Property NombreDeposito As String
   Public Property NombreSucursal As String
   Public Property SucursalAsociada As Integer
   Public Property DepositoAsociado As Integer
   Public Property CodigoDeposito As String
   Public Property DisponibleVenta As Boolean
   Public Property Activo As Boolean
   Public Property TipoDeposito As TiposDepositos

   Public Property Usuarios As List(Of SucursalDepositoUsuario)

End Class