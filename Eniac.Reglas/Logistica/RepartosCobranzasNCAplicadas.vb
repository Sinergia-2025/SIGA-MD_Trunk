Public Class RepartosCobranzasNCAplicadas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.RepartoCobranzaNCAplicada.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.RepartoCobranzaNCAplicada)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.RepartoCobranzaNCAplicada)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.RepartoCobranzaNCAplicada)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.RepartosCobranzasNCAplicadas(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.RepartosCobranzasNCAplicadas(Me.da).RepartosCobranzasNCAplicadas_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.RepartoCobranzaNCAplicada, tipo As TipoSP)
      Dim sqlC As SqlServer.RepartosCobranzasNCAplicadas = New SqlServer.RepartosCobranzasNCAplicadas(da)

      Select Case tipo
         Case TipoSP._I
            sqlC.RepartosCobranzasNCAplicadas_I(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                                en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp,
                                                en.IdSucursalNC, en.IdTipoComprobanteNC, en.LetraNC, en.CentroEmisorNC, en.NumeroComprobanteNC,
                                                en.SaldoComprobante, en.ImporteAplicado)
         Case TipoSP._U
            sqlC.RepartosCobranzasNCAplicadas_U(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                                en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp,
                                                en.IdSucursalNC, en.IdTipoComprobanteNC, en.LetraNC, en.CentroEmisorNC, en.NumeroComprobanteNC,
                                                en.SaldoComprobante, en.ImporteAplicado)
         Case TipoSP._D
            sqlC.RepartosCobranzasNCAplicadas_D(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                                en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp,
                                                en.IdSucursalNC, en.IdTipoComprobanteNC, en.LetraNC, en.CentroEmisorNC, en.NumeroComprobanteNC)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.RepartoCobranzaNCAplicada, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursal.ToString())
         .IdReparto = dr.Field(Of Integer)(Entidades.RepartoCobranzaNCAplicada.Columnas.IdReparto.ToString())
         .IdCobranza = dr.Field(Of Integer)(Entidades.RepartoCobranzaNCAplicada.Columnas.IdCobranza.ToString())

         .IdSucursalComp = dr.Field(Of Integer)(Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursalComp.ToString())
         .IdTipoComprobanteComp = dr.Field(Of String)(Entidades.RepartoCobranzaNCAplicada.Columnas.IdTipoComprobanteComp.ToString())
         .LetraComp = dr.Field(Of String)(Entidades.RepartoCobranzaNCAplicada.Columnas.LetraComp.ToString())
         .CentroEmisorComp = Convert.ToInt16(dr.Field(Of Integer)(Entidades.RepartoCobranzaNCAplicada.Columnas.CentroEmisorComp.ToString()))
         .NumeroComprobanteComp = dr.Field(Of Long)(Entidades.RepartoCobranzaNCAplicada.Columnas.NumeroComprobanteComp.ToString())

         .IdSucursalNC = dr.Field(Of Integer)(Entidades.RepartoCobranzaNCAplicada.Columnas.IdSucursalNC.ToString())
         .IdTipoComprobanteNC = dr.Field(Of String)(Entidades.RepartoCobranzaNCAplicada.Columnas.IdTipoComprobanteNC.ToString())
         .LetraNC = dr.Field(Of String)(Entidades.RepartoCobranzaNCAplicada.Columnas.LetraNC.ToString())
         .CentroEmisorNC = Convert.ToInt16(dr.Field(Of Integer)(Entidades.RepartoCobranzaNCAplicada.Columnas.CentroEmisorNC.ToString()))
         .NumeroComprobanteNC = dr.Field(Of Long)(Entidades.RepartoCobranzaNCAplicada.Columnas.NumeroComprobanteNC.ToString())

         .SaldoComprobante = dr.Field(Of Decimal)(Entidades.RepartoCobranzaNCAplicada.Columnas.SaldoComprobante.ToString())
         .ImporteAplicado = dr.Field(Of Decimal)(Entidades.RepartoCobranzaNCAplicada.Columnas.ImporteAplicado.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.RepartoCobranzaNCAplicada)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Insertar(entidad As Entidades.RepartoCobranzaComprobante)
      entidad.NCAplicadas.All(Function(x)
                                 x.IdSucursal = entidad.IdSucursal
                                 x.IdReparto = entidad.IdReparto
                                 x.IdCobranza = entidad.IdCobranza
                                 _Insertar(x)
                                 Return True
                              End Function)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.RepartoCobranzaNCAplicada)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.RepartoCobranzaNCAplicada)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Function _Borrar(en As Entidades.RepartoCobranzaComprobante) As RepartosCobranzasNCAplicadas
      _Borrar(New Entidades.RepartoCobranzaNCAplicada() _
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
                          idSucursalNC As Integer,
                          idTipoComprobanteNC As String,
                          letraNC As String,
                          centroEmisorNC As Short,
                          numeroComprobanteNC As Long) As Entidades.RepartoCobranzaNCAplicada
      Return GetUno(idSucursal, idReparto, idCobranza, idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp, idSucursalNC, idTipoComprobanteNC, letraNC, centroEmisorNC, numeroComprobanteNC, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer,
                          idReparto As Integer,
                          idCobranza As Integer,
                          idSucursalComp As Integer,
                          idTipoComprobanteComp As String,
                          letraComp As String,
                          centroEmisorComp As Short,
                          numeroComprobanteComp As Long,
                          idSucursalNC As Integer,
                          idTipoComprobanteNC As String,
                          letraNC As String,
                          centroEmisorNC As Short,
                          numeroComprobanteNC As Long,
                          accion As AccionesSiNoExisteRegistro) As Entidades.RepartoCobranzaNCAplicada
      Return CargaEntidad(New SqlServer.RepartosCobranzasNCAplicadas(Me.da).RepartosCobranzasNCAplicadas_G1(idSucursal, idReparto, idCobranza,
                                                                                                            idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp,
                                                                                                            idSucursalNC, idTipoComprobanteNC, letraNC, centroEmisorNC, numeroComprobanteNC),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaNCAplicada(),
                          accion, Function()
                                     Dim stb = New StringBuilder("No existe NC Aplicada de Cobranza de Reparto con ")
                                     stb.AppendFormat("IdSucursal: {0}, IdReparto: {1}, IdCobranza: {2} ", idSucursal, idReparto, idCobranza)
                                     stb.AppendFormat("IdSucursalComp: {0}, IdTipoComprobanteComp: {1}, LetraComp: {2}, CentroEmisorComp: {3}, NumeroComprobanteComp: {4} ", idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp)
                                     stb.AppendFormat("IdSucursalNC: {0}, IdTipoComprobanteNC: {1}, LetraNC: {2}, CentroEmisorNC: {3}, NumeroComprobanteNC: {4} ", idSucursalNC, idTipoComprobanteNC, letraNC, centroEmisorNC, numeroComprobanteNC)
                                     Return stb.ToString()
                                  End Function)
   End Function

   Public Function GetTodos(idSucursal As Integer, idReparto As Integer, idCobranza As Integer,
                            idSucursalComp As Integer, idTipoComprobanteComp As String, letraComp As String, centroEmisorComp As Short, numeroComprobanteComp As Long) As List(Of Entidades.RepartoCobranzaNCAplicada)
      Return CargaLista(New SqlServer.RepartosCobranzasNCAplicadas(Me.da).RepartosCobranzasNCAplicadas_GA(idSucursal, idReparto, idCobranza,
                                                                                                          idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaNCAplicada())
   End Function

   Public Function GetTodos() As List(Of Entidades.RepartoCobranzaNCAplicada)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaNCAplicada())
   End Function

#End Region

   Public Shared Function Parse(drCol As IEnumerable(Of Entidades.dtsRegistracionPagosV2.NCAplicadasRow)) As List(Of Entidades.RepartoCobranzaNCAplicada)
      Dim result = New List(Of Entidades.RepartoCobranzaNCAplicada)()
      drCol.All(Function(dr)
                   result.Add(Parse(dr))
                   Return True
                End Function)
      Return result
   End Function
   Public Shared Function Parse(dr As Entidades.dtsRegistracionPagosV2.NCAplicadasRow) As Entidades.RepartoCobranzaNCAplicada
      Dim nc = New Entidades.RepartoCobranzaNCAplicada()
      nc.IdSucursalComp = dr.IdSucursal
      nc.IdTipoComprobanteComp = dr.IdTipoComprobante
      nc.LetraComp = dr.Letra
      nc.CentroEmisorComp = Convert.ToInt16(dr.CentroEmisor)
      nc.NumeroComprobanteComp = dr.NumeroComprobante

      nc.IdSucursalNC = dr.IdSucursalNC
      nc.IdTipoComprobanteNC = dr.IdTipoComprobanteNC
      nc.LetraNC = dr.LetraNC
      nc.CentroEmisorNC = Convert.ToInt16(dr.CentroEmisorNC)
      nc.NumeroComprobanteNC = dr.NumeroComprobanteNC

      nc.SaldoComprobante = dr.SaldoComprobante
      nc.ImporteAplicado = dr.ImporteAplicado

      Return nc

   End Function

End Class