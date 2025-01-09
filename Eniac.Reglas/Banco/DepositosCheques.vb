Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class DepositosCheques
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      MyBase.New()
      Me.NombreEntidad = "DepositosCheques"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

   Friend Sub GrabaDepositoCheque(ByVal deposito As Entidades.Deposito, ByVal cheque As Entidades.Cheque)

      Dim sql As SqlServer.DepositosCheques = New SqlServer.DepositosCheques(Me.da)

      With deposito
         sql.DepositosCheques_I(.IdSucursal, .NumeroDeposito,
                                cheque.IdCheque,
                                .TipoComprobante.IdTipoComprobante)
      End With

   End Sub

   Friend Sub EliminaDepositoCheque(ByVal deposito As Entidades.Deposito, ByVal cheque As Entidades.Cheque)

      Dim sql As SqlServer.DepositosCheques = New SqlServer.DepositosCheques(Me.da)

      With deposito
         sql.DepositosCheques_D(.IdSucursal, .NumeroDeposito,
                                cheque.IdCheque,
                                .TipoComprobante.IdTipoComprobante)
      End With

   End Sub


#End Region

End Class
