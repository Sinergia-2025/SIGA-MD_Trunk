Imports System.ComponentModel

Partial Class CuentasCorrientes
   Public Function EstadoSituacionCrediticia(sucursales As Entidades.Sucursal(), idCliente As Long,
                                             fechaVencimientos As Date?, fechaCobro As Date?, desdeEmision As Date?, hastaEmision As Date?,
                                             desdePedido As Date?, hastaPedido As Date?,
                                             totalesSuma As EstadoSituacionCrediticia_TotalesSuma) As DataSet
      Return EjecutaConConexion(Function() _EstadoSituacionCrediticia(sucursales, idCliente, fechaVencimientos, fechaCobro, desdeEmision, hastaEmision,
                                                                      desdePedido, hastaPedido, totalesSuma))
   End Function
   Public Function _EstadoSituacionCrediticia(sucursales As Entidades.Sucursal(), idCliente As Long,
                                              fechaVencimientos As Date?, fechaCobro As Date?, desdeEmision As Date?, hastaEmision As Date?,
                                              desdePedido As Date?, hastaPedido As Date?,
                                              totalesSuma As EstadoSituacionCrediticia_TotalesSuma) As DataSet
      '-- Define DataSet.- --

      Dim dtTotales = New DataTable()
      With dtTotales
         .Columns.Add(EstadoSituacionCrediticia_Columns.Grupo.ToString(), GetType(String))
         .Columns.Add(EstadoSituacionCrediticia_Columns.Orden.ToString(), GetType(Integer))
         .Columns.Add(EstadoSituacionCrediticia_Columns.Detalle.ToString(), GetType(String))
         .Columns.Add(EstadoSituacionCrediticia_Columns.Importe.ToString(), GetType(Decimal))
      End With

      Dim sqlCuentasCorrientes = New SqlServer.CuentasCorrientes(da)

      '-- Obtiene Cuentas Corrientes.- -----------------------------------------------------------------
      Dim dtCuentasCorrientes = sqlCuentasCorrientes.GetEstadoSituacionCrediticia(sucursales, idCliente, desdeEmision, hastaEmision, fechaVencimientos, True)
      If totalesSuma.SumaCuentasCorrientes Then
         dtTotales.Rows.Add("Creditos", 1, "Cuentas Corrientes", SituacionCrediticia_CalculoCuentaCorriente(dtCuentasCorrientes))
      End If

      '-- Obtiene Anticipos.- --------------------------------------------------------------------------
      Dim dtAnticipos = sqlCuentasCorrientes.GetEstadoSituacionCrediticia(sucursales, idCliente, desdeEmision, hastaEmision, fechaVencimientos, False)
      If totalesSuma.SumaAnticipos Then
         dtTotales.Rows.Add("Debitos", 1, "Anticipos", SituacionCrediticia_CalculoAnticipos(dtAnticipos))
      End If

      '-- Obtiene Cheques.- ----------------------------------------------------------------------------
      Dim dtCheques = sqlCuentasCorrientes.GetChequesSituacionCrediticia(sucursales, idCliente,
                                                                         estadosSinFechaCobro:={Entidades.Cheque.Estados.ENCARTERA},
                                                                         estadosConFechaCobro:={Entidades.Cheque.Estados.EGRESOCAJA, Entidades.Cheque.Estados.DEPOSITADO, Entidades.Cheque.Estados.PROVEEDOR},
                                                                         fechaCobroDesde:=fechaCobro, fechaCobroHasta:=Nothing)

      If totalesSuma.SumaCheques Then
         '-- Obtiene Totales de Cheques.- -----------------------------------------------------------------
         Dim GrupoSuma = From Rows In dtCheques
                         Group Rows By Situacion = Rows.Field(Of String)("NombreSituacionCheque") Into Group
                         Select Detalle = Situacion, Importe = Group.Sum(Function(p) Decimal.Parse(p("Importe").ToString()))

         GrupoSuma.ToList().ForEach(Function(col) dtTotales.Rows.Add("Creditos", 2, String.Format("Cheques: {0}", col.Detalle), col.Importe))
         '-------------------------------------------------------------------------------------------------
      End If

      '-- Obtiene Pedidos.- ----------------------------------------------------------------------------
      Dim dtPedidos = sqlCuentasCorrientes.GetPedidosSituacionCrediticia(sucursales, idCliente, desdePedido, hastaPedido)
      dtPedidos.AsEnumerable().ToList().
         ForEach(Sub(dr) dr("ImporteTotal") = dr.Field(Of Decimal)("ImporteTotal"))

      If totalesSuma.SumaPedidosPendientes Then
         dtTotales.Rows.Add("Creditos", 3, "Pedidos", SituacionCrediticia_CalculoPedidos(dtPedidos, totalesSuma.SumaAnticipos))
      End If


      '-- Carga DataSet.- --
      Dim dsSituacion = New DataSet()
      With dsSituacion.Tables
         .Add(EstadoSituacionCrediticia_Totales.Totales.ToString(), dtTotales)
         .Add(EstadoSituacionCrediticia_Totales.CtasCtes.ToString(), dtCuentasCorrientes)
         .Add(EstadoSituacionCrediticia_Totales.Anticipos.ToString(), dtAnticipos)
         .Add(EstadoSituacionCrediticia_Totales.Cheques.ToString(), dtCheques)
         .Add(EstadoSituacionCrediticia_Totales.Pedidos.ToString(), dtPedidos)
      End With
      '-- Devuelve DataSet.- ---------------------------------------------------------------------------
      Return dsSituacion
   End Function

   Private Function SituacionCrediticia_CalculoCuentaCorriente(dsSituacion As DataSet) As Decimal
      Return SituacionCrediticia_CalculoCuentaCorriente(dsSituacion.Tables(EstadoSituacionCrediticia_Totales.CtasCtes.ToString()))
   End Function
   Private Function SituacionCrediticia_CalculoAnticipos(dtAnticipos As DataSet) As Decimal
      Return SituacionCrediticia_CalculoAnticipos(dtAnticipos.Tables(EstadoSituacionCrediticia_Totales.Anticipos.ToString()))
   End Function
   Private Function SituacionCrediticia_CalculoPedidos(dtPedidos As DataSet, sumaAnticipos As Boolean) As Decimal
      Return SituacionCrediticia_CalculoPedidos(dtPedidos.Tables(EstadoSituacionCrediticia_Totales.Pedidos.ToString()), sumaAnticipos)
   End Function
   Private Function SituacionCrediticia_CalculoTotalCheques(dtPedidos As DataSet) As Decimal
      Return SituacionCrediticia_CalculoTotalCheques(dtPedidos.Tables(EstadoSituacionCrediticia_Totales.Cheques.ToString()))
   End Function

   Private Function SituacionCrediticia_CalculoCuentaCorriente(dtCuentasCorrientes As DataTable) As Decimal
      Return dtCuentasCorrientes.AsEnumerable().Sum(Function(t) t.Field(Of Decimal)("SaldoCuota"))
   End Function
   Private Function SituacionCrediticia_CalculoAnticipos(dtAnticipos As DataTable) As Decimal
      Return dtAnticipos.AsEnumerable().Sum(Function(t) t.Field(Of Decimal)("SaldoCuota"))
   End Function
   Private Function SituacionCrediticia_CalculoPedidos(dtPedidos As DataTable, sumaAnticipos As Boolean) As Decimal
      Return dtPedidos.AsEnumerable().Where(Function(t) sumaAnticipos Or Not t.Field(Of Boolean?)("Anticipado").IfNull()).Sum(Function(t) t.Field(Of Decimal)("ImporteTotal"))
   End Function
   Private Function SituacionCrediticia_CalculoTotalCheques(dtCheques As DataTable) As Decimal
      Return dtCheques.AsEnumerable().Where(Function(t) t.Field(Of String)("ChequeDeAnticipo") = "NO").Sum(Function(t) t.Field(Of Decimal)("Importe"))
   End Function


   Public Function CalculoSaldoLimiteCredito(idCliente As Long, dsSituacion As DataSet) As Entidades.CalculoSaldoLimiteCreditoResultado
      Return EjecutaConConexion(Function() _CalculoSaldoLimiteCredito(idCliente, dsSituacion))
   End Function
   Public Function _CalculoSaldoLimiteCredito(idCliente As Long, dsSituacion As DataSet) As Entidades.CalculoSaldoLimiteCreditoResultado
      Return _CalculoSaldoLimiteCredito(New Clientes(da).GetUnoLiviando(idCliente), dsSituacion)
   End Function
   Public Function _CalculoSaldoLimiteCredito(cliente As Entidades.ClienteLiviano, dsSituacion As DataSet) As Entidades.CalculoSaldoLimiteCreditoResultado
      Dim result = New Entidades.CalculoSaldoLimiteCreditoResultado(cliente,
                                                                    Publicos.CtaCte.SaldoLimiteDeCreditoContemplaPedidos,
                                                                    Publicos.CtaCte.SaldoLimiteDeCreditoContemplaAnticipos)


      result.SituacionCrediticia += SituacionCrediticia_CalculoCuentaCorriente(dsSituacion)
      result.SituacionCrediticia += SituacionCrediticia_CalculoTotalCheques(dsSituacion)
      If result.SaldoLimiteCreditoContemplaAnticipos Then
         result.SituacionCrediticia += SituacionCrediticia_CalculoAnticipos(dsSituacion)
      End If
      If result.SaldoLimiteCreditoContemplaPedidos Then
         result.SituacionCrediticia += SituacionCrediticia_CalculoPedidos(dsSituacion, result.SaldoLimiteCreditoContemplaAnticipos)
      End If

      result.SituacionCrediticia = Math.Round(result.SituacionCrediticia, 2)
      result.LimiteDeCreditoNuevo = cliente.LimiteDeCredito

      Return result
   End Function

   Public Function CalculoSituacionCrediticiaMasivo() As CalculoSituacionCrediticiaMasivoResult
      Return CalculoSituacionCrediticiaMasivo(avance:=Function(e) e, error:=Function(e) e, continuarConError:=False)
   End Function
   Public Function CalculoSituacionCrediticiaMasivo(avance As Func(Of CalculoSituacionCrediticiaMasivoEventArgs, CalculoSituacionCrediticiaMasivoEventArgs)) As CalculoSituacionCrediticiaMasivoResult
      Return CalculoSituacionCrediticiaMasivo(avance, error:=Function(e) e, continuarConError:=False)
   End Function
   Public Function CalculoSituacionCrediticiaMasivo(avance As Func(Of CalculoSituacionCrediticiaMasivoEventArgs, CalculoSituacionCrediticiaMasivoEventArgs),
                                                    [error] As Func(Of CalculoSituacionCrediticiaMasivoErrorEventArgs, CalculoSituacionCrediticiaMasivoErrorEventArgs),
                                                    continuarConError As Boolean) As CalculoSituacionCrediticiaMasivoResult
      Return EjecutaConTransaccion(Function() _CalculoSituacionCrediticiaMasivo(avance, [error], continuarConError))
   End Function
   Public Function _CalculoSituacionCrediticiaMasivo(avance As Func(Of CalculoSituacionCrediticiaMasivoEventArgs, CalculoSituacionCrediticiaMasivoEventArgs),
                                                     [error] As Func(Of CalculoSituacionCrediticiaMasivoErrorEventArgs, CalculoSituacionCrediticiaMasivoErrorEventArgs),
                                                     continuarConError As Boolean) As CalculoSituacionCrediticiaMasivoResult
      If avance Is Nothing Then
         Throw New ArgumentNullException(NameOf(avance))
      End If
      If [error] Is Nothing Then
         Throw New ArgumentNullException(NameOf([error]))
      End If

      Dim rClientes = New Clientes(da, Entidades.Cliente.ModoClienteProspecto.Cliente)
      Dim rSucursales = New Sucursales(da)
      Dim sucursales = rSucursales.GetTodas(incluirLogo:=False)
      Dim clientes = rClientes.GetTodosClientesLiviando()
      Dim swGeneral = New Stopwatch()
      Dim swIndivid = New Stopwatch()

      Dim resultList = New List(Of CalculoSituacionCrediticiaMasivoEventArgs)()

      swGeneral.Start()
      For Each clte In clientes
         Using ds = _EstadoSituacionCrediticia(sucursales.ToArray(), clte.IdCliente,
                                               fechaVencimientos:=Nothing, fechaCobro:=Nothing, desdeEmision:=Nothing, hastaEmision:=Nothing,
                                               desdePedido:=Nothing, hastaPedido:=Nothing,
                                               New EstadoSituacionCrediticia_TotalesSuma(sumaAnticipos:=True, sumaPedidosPendientes:=True))

            swIndivid.Restart()

            avance(New CalculoSituacionCrediticiaMasivoEventArgs(clte, 0, CalculoSituacionCrediticiaMasivoEventArgs.Etapas.PreCalculo, swIndivid.Elapsed))
            Dim result = _CalculoSaldoLimiteCredito(clte, ds)
            avance(New CalculoSituacionCrediticiaMasivoEventArgs(clte, result.SaldoLimiteDeCreditoNuevo, CalculoSituacionCrediticiaMasivoEventArgs.Etapas.PostCalculo, swIndivid.Elapsed))
            Try
               avance(New CalculoSituacionCrediticiaMasivoEventArgs(clte, result.SaldoLimiteDeCreditoNuevo, CalculoSituacionCrediticiaMasivoEventArgs.Etapas.PreActualizacion, swIndivid.Elapsed))
               rClientes._ActualizaSaldoLimiteDeCredito(result.IdCliente, result)
               avance(New CalculoSituacionCrediticiaMasivoEventArgs(clte, result.SaldoLimiteDeCreditoNuevo, CalculoSituacionCrediticiaMasivoEventArgs.Etapas.PostActualizacion, swIndivid.Elapsed))
               resultList.Add(New CalculoSituacionCrediticiaMasivoEventArgs(clte, result.SaldoLimiteDeCreditoNuevo, CalculoSituacionCrediticiaMasivoEventArgs.Etapas.PostActualizacion, swIndivid.Elapsed))
            Catch ex As Exception
               [error](New CalculoSituacionCrediticiaMasivoErrorEventArgs(clte, result.SaldoLimiteDeCreditoNuevo, CalculoSituacionCrediticiaMasivoEventArgs.Etapas.PostActualizacion, ex, swIndivid.Elapsed))
               resultList.Add(New CalculoSituacionCrediticiaMasivoErrorEventArgs(clte, result.SaldoLimiteDeCreditoNuevo, CalculoSituacionCrediticiaMasivoEventArgs.Etapas.PostActualizacion, ex, swIndivid.Elapsed))
               If Not continuarConError Then
                  Throw
               End If
            End Try
         End Using
      Next
      swIndivid.Stop()
      swGeneral.Stop()
      Return New CalculoSituacionCrediticiaMasivoResult(resultList, swGeneral.Elapsed)
   End Function
#Region "Clases CalculoSituacionCrediticiaMasivo"
   Public Class CalculoSituacionCrediticiaMasivoResult
      Public Property TiempoTotal As TimeSpan
      Public ReadOnly Property Avances As IEnumerable(Of CalculoSituacionCrediticiaMasivoEventArgs)

      Public Sub New(avances As IEnumerable(Of CalculoSituacionCrediticiaMasivoEventArgs), tiempoTotal As TimeSpan)
         Me.TiempoTotal = tiempoTotal
         Me.Avances = avances
      End Sub
   End Class
   Public Class CalculoSituacionCrediticiaMasivoEventArgs
      Inherits EventArgs
      Public Property Cliente As Entidades.ClienteLiviano
      Public Property SaldoNuevo As Decimal
      Public Property Etapa As Etapas
      Public Property Tiempo As TimeSpan

      Public Sub New(cliente As Entidades.ClienteLiviano, saldoNuevo As Decimal, etapa As Etapas, tiempo As TimeSpan)
         Me.Cliente = cliente
         Me.SaldoNuevo = saldoNuevo
         Me.Etapa = etapa
         Me.Tiempo = tiempo
      End Sub

      Public Enum Etapas
         <Description("Antes Cálculo")> PreCalculo
         <Description("Después Cálculo")> PostCalculo
         <Description("Antes Actualización")> PreActualizacion
         <Description("Después Actualización")> PostActualizacion
      End Enum
   End Class
   Public Class CalculoSituacionCrediticiaMasivoErrorEventArgs
      Inherits CalculoSituacionCrediticiaMasivoEventArgs
      Public Property Ex As Exception

      Public Sub New(cliente As Entidades.ClienteLiviano, saldoNuevo As Decimal, etapa As Etapas, ex As Exception, tiempo As TimeSpan)
         MyBase.New(cliente, saldoNuevo, etapa, tiempo)
         Me.Ex = ex
      End Sub
   End Class
#End Region
#Region "Clases EstadoSituacionCrediticia"
   Public Enum EstadoSituacionCrediticia_Columns
      Grupo
      Orden
      Detalle
      Importe
   End Enum
   Public Enum EstadoSituacionCrediticia_Totales
      Totales
      CtasCtes
      Anticipos
      Cheques
      Pedidos
   End Enum
   Public Structure EstadoSituacionCrediticia_TotalesSuma
      Public Property SumaCuentasCorrientes As Boolean
      Public Property SumaAnticipos As Boolean
      Public Property SumaCheques As Boolean
      Public Property SumaPedidosPendientes As Boolean

      Public Sub New(Optional sumaCuentasCorrientes As Boolean = True, Optional sumaAnticipos As Boolean = True, Optional sumaCheques As Boolean = True, Optional sumaPedidosPendientes As Boolean = True)
         Me.SumaCuentasCorrientes = sumaCuentasCorrientes
         Me.SumaAnticipos = sumaAnticipos
         Me.SumaCheques = sumaCheques
         Me.SumaPedidosPendientes = sumaPedidosPendientes
      End Sub
   End Structure
#End Region

End Class
