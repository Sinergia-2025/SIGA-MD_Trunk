Public Class LiquidacionesCargos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "Cargos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

#End Region

#Region "Metodos Privados"

   Public Overloads Sub Insertar(Periodo As Integer, IdSucursal As Integer)
      EjecutaConTransaccion(Sub() EjecutaSP(Periodo, TipoSP._I, IdSucursal))
   End Sub

   Public Overloads Sub Actualizar(Periodo As Integer, IdSucursal As Integer)
      EjecutaConTransaccion(Sub() EjecutaSP(Periodo, TipoSP._U, IdSucursal))
   End Sub

   Public Overloads Sub Borrar(Periodo As Integer, IdSucursal As Integer)
      EjecutaConTransaccion(Sub() EjecutaSP(Periodo, TipoSP._D, IdSucursal))
   End Sub

   Private Sub EjecutaSP(Periodo As Integer, tipo As TipoSP, IdSucursal As Integer)
      Dim sqlC = New SqlServer.LiquidacionesCargos(da)
      Select Case tipo
         Case TipoSP._D
            sqlC.LiquidacionesCargos_D(Periodo, Nothing, IdSucursal)
      End Select
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub ActualizarComprobante(IdCargo As Integer, Periodo As Integer, IdCliente As Long,
                                   idSucursal As Integer, idTipoComprobante As String,
                                   letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                   ImporteTotal As Decimal, IdTipoLiquidacion As Integer)

      Dim blnConexionAbierta As Boolean = Me.da.Connection IsNot Nothing AndAlso Me.da.Connection.State = ConnectionState.Open

      Try
         If Not blnConexionAbierta Then
            Me.da.OpenConection()
            Me.da.BeginTransaction()
         End If

         Dim sqlC As SqlServer.LiquidacionesCargos = New SqlServer.LiquidacionesCargos(da)
         sqlC.ActualizarComprobante(IdCargo, Periodo, IdCliente, idSucursal, idTipoComprobante, letra,
                                    centroEmisor, numeroComprobante, ImporteTotal, IdTipoLiquidacion)

         If Not blnConexionAbierta Then Me.da.CommitTransaction()

      Catch ex As Exception
         If Not blnConexionAbierta Then Me.da.RollbakTransaction()
         Throw
      Finally
         If Not blnConexionAbierta Then Me.da.CloseConection()
      End Try

   End Sub

   Public Sub ActualizarComprobantePorComprobante(vtaActual As Eniac.Entidades.Venta, vtaNueva As Eniac.Entidades.Venta)

      Try

         Dim sqlC As SqlServer.LiquidacionesCargos = New SqlServer.LiquidacionesCargos(da)

         sqlC.ActualizarComprobantePorComprobante(vtaActual.IdSucursal, vtaActual.IdTipoComprobante,
                                                 vtaActual.LetraComprobante, vtaActual.CentroEmisor,
                                                 vtaActual.NumeroComprobante, vtaNueva.IdTipoComprobante,
                                                 vtaNueva.LetraComprobante, vtaNueva.CentroEmisor, vtaNueva.NumeroComprobante)

      Catch ex As Exception
         Throw
      Finally
      End Try

   End Sub

   Public Function GetPorRangoFechas(sucursales As Entidades.Sucursal(),
                                     periodoDesde As Integer, periodoHasta As Integer,
                                     nombreCategoria As String, codigoCliente As Long,
                                     idTipoLiquidacion As Integer,
                                     numeroComprobante As Long,
                                     letraFiscal As String,
                                     centroEmisor As Integer,
                                     listaComprobantes As List(Of Entidades.TipoComprobante),
                                     liquidado As Entidades.Publicos.SiNoTodos) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.LiquidacionesCargos(da).
                                                         GetInforme(sucursales,
                                                                    periodoDesde,
                                                                    periodoHasta,
                                                                    nombreCategoria,
                                                                    codigoCliente,
                                                                    idTipoLiquidacion,
                                                                    numeroComprobante,
                                                                    letraFiscal,
                                                                    centroEmisor,
                                                                    listaComprobantes,
                                                                    liquidado))
   End Function

   Public Function GetInformeDetalle(sucursales As Entidades.Sucursal(),
                                     periodoDesde As Integer, periodoHasta As Integer,
                                     codigoCliente As Long,
                                     idTipoLiquidacion As Integer) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.LiquidacionesCargos(da).
                                                         GetInformeDetalle(sucursales,
                                                                           periodoDesde,
                                                                           periodoHasta,
                                                                           codigoCliente,
                                                                           idTipoLiquidacion))
   End Function

#End Region
End Class