Option Explicit On
Option Strict On

Imports System.Text
Imports Eniac.Entidades
Public Class ComprasLiquidacion
   Inherits Eniac.Reglas.Base

   Public Sub New()
      Me.NombreEntidad = "ComprasLiquidacion"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

   Public Sub GrabaMovimientosLiquidaciones(ByVal movimientos As List(Of Entidades.ComprasLiquidacion))

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ComprasLiquidacion = New SqlServer.ComprasLiquidacion(da)
         Dim oMovimientosConceptos As Reglas.ComprasProductos = New Reglas.ComprasProductos(da)
         Dim rCompras As Reglas.Compras = New Reglas.Compras(da)

         For Each ent As Entidades.ComprasLiquidacion In movimientos

            '# Por cada compra, vuelvo a validar que no se haya excluido
            If rCompras.Excluido(ent.Sucursal,
                                 ent.IdTipoComprobante,
                                 ent.Letra,
                                 ent.CentroEmisor,
                                 ent.NumeroComprobante,
                                 ent.IdProveedor) Then
               Dim mensaje As StringBuilder = New StringBuilder
               With mensaje
                  .AppendFormatLine("El comprobante {0} {1} {2} {3} Proveedor: {4} está EXCLUIDO.",
                                                      ent.IdTipoComprobante,
                                                      ent.Letra,
                                                      ent.CentroEmisor,
                                                      ent.NumeroComprobante,
                                                      ent.IdProveedor)
                  .AppendLine()
                  .AppendFormatLine("No se puede realizar el pasaje de movimientos con comprobantes Excluidos. Debe Incluirlos para poder pasarlos.")
               End With
               Throw New Exception(mensaje.ToString())
            End If

            sql.ComprasLiquidaciones_I(ent.Sucursal,
                                       ent.IdTipoComprobante,
                                       ent.Letra,
                                       ent.CentroEmisor,
                                       ent.NumeroComprobante,
                                       ent.IdProveedor,
                                       ent.IdConcepto,
                                       ent.Orden,
                                       ent.ImporteALiquidar,
                                       ent.Liquidado)

            Dim oMovCon As Eniac.Entidades.CompraProducto = New Eniac.Entidades.CompraProducto()
            oMovCon = oMovimientosConceptos.GetUnaParaPasaje(ent.Sucursal,
                                                             ent.IdTipoComprobante,
                                                             ent.Letra, ent.CentroEmisor,
                                                             ent.NumeroComprobante,
                                                             ent.IdProveedor,
                                                             ent.Orden,
                                                             ent.IdConcepto)
            With oMovCon
               .PasajeMovimientos = True
               .MontoAplicado = .MontoAplicado + ent.ImporteALiquidar
               .MontoSaldo = .MontoSaldo - ent.ImporteALiquidar
            End With

            oMovimientosConceptos._ModificarMontoAplicar(oMovCon)
         Next
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw New Exception(ex.Message, ex)
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Function GetLiquidacionDetallada(Periodo As Integer,
                                           IdConcepto As Integer,
                                           IdProveedor As Long,
                                           IdTipoComprobante As String,
                                           Letra As String,
                                           EmisorComprobante As Integer,
                                           NumeroComprobante As Long) As DataTable

      Dim sql As SqlServer.ComprasLiquidacion
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.ComprasLiquidacion(Me.da)
         dt = sql.GetLiquidacionDetallada(Periodo, IdConcepto, IdProveedor, IdTipoComprobante, Letra, EmisorComprobante, NumeroComprobante)

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw New Exception(ex.Message, ex)
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Sub RevierteMovimientosLiquidaciones(ByVal movimientos As List(Of Entidades.ComprasLiquidacion))
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ComprasLiquidacion = New SqlServer.ComprasLiquidacion(da)
         Dim oMovCon As Eniac.Entidades.CompraProducto = New Eniac.Entidades.CompraProducto()
         Dim oMovimientosConceptos As Reglas.ComprasProductos = New Reglas.ComprasProductos(Me.da)

         For Each ent As Entidades.ComprasLiquidacion In movimientos

            oMovCon = New Eniac.Entidades.CompraProducto()

            oMovCon = oMovimientosConceptos.GetUnaParaPasaje(ent.Sucursal,
                                                             ent.IdTipoComprobante,
                                                             ent.Letra,
                                                             ent.CentroEmisor,
                                                             ent.NumeroComprobante,
                                                             ent.IdProveedor,
                                                             ent.Orden,
                                                             ent.IdConcepto)
            With oMovCon
               .PasajeMovimientos = True
               .MontoAplicado = .MontoAplicado - ent.ImporteALiquidar
               .MontoSaldo = .MontoSaldo + ent.ImporteALiquidar
            End With

            oMovimientosConceptos._ModificarMontoAplicar(oMovCon)

            sql.ComprasLiquidaciones_D(ent.Sucursal, ent.TipoComprobante.IdTipoComprobante,
                                       ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                       ent.Proveedor.IdProveedor, ent.IdConcepto,
                                       ent.Orden, ent.OrdenLiquidacion)
         Next

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw New Exception(ex.Message, ex)
      Finally
         da.CloseConection()
      End Try
   End Sub

End Class
