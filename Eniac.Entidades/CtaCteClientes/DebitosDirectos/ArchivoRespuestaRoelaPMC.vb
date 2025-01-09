Public Class ArchivoRespuestaRoelaPMC

   Public Sub New()
      Datos = New List(Of ArchivoRespuestaRoelaPMCDatos)()
   End Sub

   Public Property FecharArchivo As Date
   Public Property Datos As List(Of ArchivoRespuestaRoelaPMCDatos)
   Public ReadOnly Property TotalImporte As Decimal
      Get
         Return Datos.SumSecure(Function(d) d.ImportePagado).IfNull()
      End Get
   End Property

End Class

Public Class ArchivoRespuestaRoelaPMCDatos

   Public Property Proceso As Boolean = True
   Public Property Accion As String = String.Empty
   Public Property FechaDePago As Date
   Public Property FechaDeAcreditacion As Date
   Public Property FechaDeVencimiento As Date
   Public Property ImportePagado As Decimal
   Public Property IdentificadorDelUsuario As Long
   Public Property IdentificadorDeConcepto As Long
   Public Property CodigoDeBarra As String
   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property Cuota As Integer
   Public Property SaldoCuota As Decimal
   Public Property IdentificadorDeComprobante As String
   Public Property CanalDeCobro As String
   Public Property NombreCliente As String
   Public Property Mensaje As String = String.Empty

   Public ReadOnly Property CanalDeCobroResuelto As String
      Get
         Select Case CanalDeCobro.Trim().ToUpper()
            Case "PC"
               Return "PAGO MIS CUENTAS"
            Case "HB"
               Return "HOME BANKING"
            Case "S1"
               Return "CAGERO AUTOMATICO (ATM)"
            Case Else
               Return CanalDeCobro
         End Select
      End Get
   End Property

   Public ReadOnly Property CanalDeCobroResueltoSIRPLUS As String
      Get
         Select Case CanalDeCobro.Trim().ToUpper()
            Case "1"
               Return "LINK PAGOS"
            Case "2"
               Return "PUNTA DE CAJA BMR"
            Case "3"
               Return "DEBITOS AUTOMATICOS"
            Case "4"
               Return "BANELCO"
            Case "5"
               Return "SANTA FE SERVICIOS"
            Case Else
               Return CanalDeCobro
         End Select
      End Get
   End Property

End Class