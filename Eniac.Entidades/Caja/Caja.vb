<Serializable()>
Public Class Caja
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      IdCaja
      NumeroPlanilla
      FechaPlanilla
      PesosSaldoInicial
      PesosSaldoFinal
      DolaresSaldoInicial
      DolaresSaldoFinal
      EurosSaldoInicial
      EurosSaldoFinal
      ChequesSaldoInicial
      ChequesSaldoFinal
      TarjetasSaldoInicial
      TarjetasSaldoFinal
      TicketsSaldoInicial
      TicketsSaldoFinal
      PesosSaldoFinalDigit
      DolaresSaldoFinalDigit
      ChequesSaldoFinalDigit
      TarjetasSaldoFinalDigit
      TicketsSaldoFinalDigit
      BancosSaldoInicial
      BancosSaldoFinal
      BancosSaldoFinalDigit
      RetencionesSaldoInicial
      RetencionesSaldoFinal
      RetencionesSaldoFinalDigit
      BancosDolaresSaldoInicial
      BancosDolaresSaldoFinal
      BancosDolaresSaldoFinalDigit
      FechaCierrePlanilla

   End Enum

#Region "Constructores"

   Public Sub New()
   End Sub

   Public Sub New(idSucursal As Integer, usuario As String, pwd As String)
      Me.New()
      Me.IdSucursal = idSucursal
      Me.Usuario = usuario
      Password = pwd
   End Sub

#End Region

#Region "Propiedades"


   Public Property IdCaja As Integer
   Public Property NumeroPlanilla As Integer
   Public Property FechaPlanilla As Date
   Public Property PesosSaldoInicial As Decimal
   Public Property PesosSaldoFinal As Decimal
   Public Property DolaresSaldoInicial As Decimal
   Public Property DolaresSaldoFinal As Decimal
   Public Property ChequesSaldoInicial As Decimal
   Public Property ChequesSaldoFinal As Decimal
   Public Property TarjetasSaldoInicial As Decimal
   Public Property TarjetasSaldoFinal As Decimal
   Public Property TicketsSaldoInicial As Decimal
   Public Property TicketsSaldoFinal As Decimal
   Public Property RetencionesSaldoInicial As Decimal
   Public Property RetencionesSaldoFinal As Decimal
   Public Property BancosSaldoInicial As Decimal
   Public Property BancosSaldoFinal As Decimal
   Public Property BancosDolaresSaldoInicial As Decimal
   Public Property BancosDolaresSaldoFinal As Decimal

   Public Property PesosSaldoFinalDigit As Decimal
   Public Property DolaresSaldoFinalDigit As Decimal
   Public Property TicketsSaldoFinalDigit As Decimal
   Public Property ChequesSaldoFinalDigit As Decimal
   Public Property TarjetasSaldoFinalDigit As Decimal
   Public Property RetencionesSaldoFinalDigit As Decimal
   Public Property BancosSaldoFinalDigit As Decimal
   Public Property BancosDolaresSaldoFinalDigit As Decimal

   Public Property FechaCierrePlanilla As Date?
#End Region

End Class