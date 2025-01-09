Public Class RepartosCobranzasCheques
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.RepartoCobranzaCheque.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.RepartoCobranzaCheque)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.RepartoCobranzaCheque)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.RepartoCobranzaCheque)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.RepartosCobranzasCheques(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.RepartosCobranzasCheques(Me.da).RepartosCobranzasCheques_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.RepartoCobranzaCheque, tipo As TipoSP)
      Dim sqlC As SqlServer.RepartosCobranzasCheques = New SqlServer.RepartosCobranzasCheques(da)

      Select Case tipo
         Case TipoSP._I
            sqlC.RepartosCobranzasCheques_I(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                            en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp,
                                            en.IdBanco, en.IdBancoSucursal, en.IdLocalidad, en.NumeroCheque, en.NroOperacion,
                                            en.IdTipoCheque, en.FechaEmision, en.FechaCobro, en.Titular, en.Importe, en.Cuit)
         Case TipoSP._U
            sqlC.RepartosCobranzasCheques_U(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                            en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp,
                                            en.IdBanco, en.IdBancoSucursal, en.IdLocalidad, en.NumeroCheque, en.NroOperacion,
                                            en.IdTipoCheque, en.FechaEmision, en.FechaCobro, en.Titular, en.Importe, en.Cuit)
         Case TipoSP._D
            sqlC.RepartosCobranzasCheques_D(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                            en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp,
                                            en.IdBanco, en.IdBancoSucursal, en.IdLocalidad, en.NumeroCheque)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.RepartoCobranzaCheque, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.RepartoCobranzaCheque.Columnas.IdSucursal.ToString())
         .IdReparto = dr.Field(Of Integer)(Entidades.RepartoCobranzaCheque.Columnas.IdReparto.ToString())
         .IdCobranza = dr.Field(Of Integer)(Entidades.RepartoCobranzaCheque.Columnas.IdCobranza.ToString())

         .IdSucursalComp = dr.Field(Of Integer)(Entidades.RepartoCobranzaCheque.Columnas.IdSucursalComp.ToString())
         .IdTipoComprobanteComp = dr.Field(Of String)(Entidades.RepartoCobranzaCheque.Columnas.IdTipoComprobanteComp.ToString())
         .LetraComp = dr.Field(Of String)(Entidades.RepartoCobranzaCheque.Columnas.LetraComp.ToString())
         .CentroEmisorComp = Convert.ToInt16(dr.Field(Of Integer)(Entidades.RepartoCobranzaCheque.Columnas.CentroEmisorComp.ToString()))
         .NumeroComprobanteComp = dr.Field(Of Long)(Entidades.RepartoCobranzaCheque.Columnas.NumeroComprobanteComp.ToString())

         .IdBanco = dr.Field(Of Integer)(Entidades.RepartoCobranzaCheque.Columnas.IdBanco.ToString())
         .IdBancoSucursal = dr.Field(Of Integer)(Entidades.RepartoCobranzaCheque.Columnas.IdBancoSucursal.ToString())
         .IdLocalidad = dr.Field(Of Integer)(Entidades.RepartoCobranzaCheque.Columnas.IdLocalidad.ToString())
         .NumeroCheque = dr.Field(Of Integer)(Entidades.RepartoCobranzaCheque.Columnas.NumeroCheque.ToString())
         .Cuit = dr.Field(Of String)(Entidades.RepartoCobranzaCheque.Columnas.Cuit.ToString())

         .NroOperacion = dr.Field(Of String)(Entidades.RepartoCobranzaCheque.Columnas.NroOperacion.ToString())
         .IdTipoCheque = dr.Field(Of String)(Entidades.RepartoCobranzaCheque.Columnas.IdTipoCheque.ToString())
         .FechaEmision = dr.Field(Of DateTime)(Entidades.RepartoCobranzaCheque.Columnas.FechaEmision.ToString())
         .FechaCobro = dr.Field(Of DateTime)(Entidades.RepartoCobranzaCheque.Columnas.FechaCobro.ToString())
         .Titular = dr.Field(Of String)(Entidades.RepartoCobranzaCheque.Columnas.Titular.ToString())
         .Importe = dr.Field(Of Decimal)(Entidades.RepartoCobranzaCheque.Columnas.Importe.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.RepartoCobranzaCheque)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Insertar(entidad As Entidades.RepartoCobranzaComprobante)
      entidad.Cheques.All(Function(x)
                             x.IdSucursal = entidad.IdSucursal
                             x.IdReparto = entidad.IdReparto
                             x.IdCobranza = entidad.IdCobranza
                             _Insertar(x)
                             Return True
                          End Function)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.RepartoCobranzaCheque)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.RepartoCobranzaCheque)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Function _Borrar(en As Entidades.RepartoCobranzaComprobante) As RepartosCobranzasCheques
      _Borrar(New Entidades.RepartoCobranzaCheque() _
               With {.IdSucursal = en.IdSucursal, .IdReparto = en.IdReparto, .IdCobranza = en.IdCobranza,
                     .IdSucursalComp = en.IdSucursalComp, .IdTipoComprobanteComp = en.IdTipoComprobanteComp, .LetraComp = en.LetraComp, .CentroEmisorComp = en.CentroEmisorComp, .NumeroComprobanteComp = en.NumeroComprobanteComp})
      Return Me
   End Function

   Public Function GetUno(idSucursal As Integer,
                          idReparto As Integer,
                          idCobranza As Integer,
                          idSucursalComp As Integer,
                          idTipoComprobanteComp As String,
                          letraComp As String,
                          centroEmisorComp As Short,
                          numeroComprobanteComp As Long,
                          idBanco As Integer,
                          idBancoSucursal As Integer,
                          idLocalidad As Integer,
                          numeroCheque As Integer,
                          cuit As String) As Entidades.RepartoCobranzaCheque
      Return GetUno(idSucursal, idReparto, idCobranza, idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp, idBanco, idBancoSucursal, idLocalidad, numeroCheque, cuit, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer,
                          idReparto As Integer,
                          idCobranza As Integer,
                          idSucursalComp As Integer,
                          idTipoComprobanteComp As String,
                          letraComp As String,
                          centroEmisorComp As Short,
                          numeroComprobanteComp As Long,
                          idBanco As Integer,
                          idBancoSucursal As Integer,
                          idLocalidad As Integer,
                          numeroCheque As Integer,
                          cuit As String,
                          accion As AccionesSiNoExisteRegistro) As Entidades.RepartoCobranzaCheque
      Return CargaEntidad(New SqlServer.RepartosCobranzasCheques(Me.da).RepartosCobranzasCheques_G1(idSucursal, idReparto, idCobranza,
                                                                                                    idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp,
                                                                                                    idBanco, idBancoSucursal, idLocalidad, numeroCheque, cuit),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaCheque(),
                          accion, Function()
                                     Dim stb = New StringBuilder("No existe Cheque de Cobranza de Reparto con ")
                                     stb.AppendFormat("IdSucursal: {0}, IdReparto: {1}, IdCobranza: {2} ", idSucursal, idReparto, idCobranza)
                                     stb.AppendFormat("IdSucursalComp: {0}, IdTipoComprobanteComp: {1}, LetraComp: {2}, CentroEmisorComp: {3}, NumeroComprobanteComp: {4} ", idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp)
                                     Return stb.ToString()
                                  End Function)
   End Function

   Public Function GetTodos(idSucursal As Integer, idReparto As Integer, idCobranza As Integer,
                            idSucursalComp As Integer, idTipoComprobanteComp As String, letraComp As String, centroEmisorComp As Short, numeroComprobanteComp As Long) As List(Of Entidades.RepartoCobranzaCheque)
      Return CargaLista(New SqlServer.RepartosCobranzasCheques(Me.da).RepartosCobranzasCheques_GA(idSucursal, idReparto, idCobranza,
                                                                                                  idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaCheque())
   End Function

   Public Function GetTodos() As List(Of Entidades.RepartoCobranzaCheque)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaCheque())
   End Function

#End Region

   Public Shared Function Parse(drCol As IEnumerable(Of Entidades.dtsRegistracionPagosV2.ChequesRow)) As List(Of Entidades.RepartoCobranzaCheque)
      Dim result = New List(Of Entidades.RepartoCobranzaCheque)()
      drCol.All(Function(dr)
                   result.Add(Parse(dr))
                   Return True
                End Function)
      Return result
   End Function
   Public Shared Function Parse(dr As Entidades.dtsRegistracionPagosV2.ChequesRow) As Entidades.RepartoCobranzaCheque
      Dim cheque = New Entidades.RepartoCobranzaCheque()
      cheque.IdSucursalComp = dr.IdSucursal
      cheque.IdTipoComprobanteComp = dr.IdTipoComprobante
      cheque.LetraComp = dr.Letra
      cheque.CentroEmisorComp = Convert.ToInt16(dr.CentroEmisor)
      cheque.NumeroComprobanteComp = dr.NumeroComprobante

      cheque.IdBanco = dr.IdBanco
      cheque.IdBancoSucursal = dr.IdBancoSucursal
      cheque.IdLocalidad = dr.IdLocalidad
      cheque.NumeroCheque = dr.NumeroCheque
      cheque.Cuit = dr.Cuit

      cheque.NroOperacion = dr.NroOperacion
      cheque.IdTipoCheque = dr.IdTipoCheque
      cheque.FechaEmision = dr.FechaEmision
      cheque.FechaCobro = dr.FechaCobro
      cheque.Titular = dr.Titular
      cheque.Importe = dr.Importe

      Return cheque

   End Function

End Class