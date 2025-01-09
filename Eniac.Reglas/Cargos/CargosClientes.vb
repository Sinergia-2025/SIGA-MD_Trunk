#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports System.Text
Imports Eniac.Datos
#End Region
Public Class CargosClientes
   Inherits Eniac.Reglas.Base

   Public Sub New()
      Me.NombreEntidad = "CargosClientes"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CargosClientes"
      da = accesoDatos
   End Sub

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll()
   End Function
   Public Overloads Function GetAll(datosRelacionados As Boolean, idSucursal As Integer, idtipoLiquidacion As Integer, crossJoin As Boolean) As System.Data.DataTable
      Return New SqlServer.CargosClientes(Me.da).CargosClientes_GA(datosRelacionados, idSucursal, idtipoLiquidacion, crossJoin)
   End Function

   Public Overloads Function GetCargosClientes(idSucursal As Integer, idtipoLiquidacion As Integer, idCategoria As Integer?,
                                               idZonaGeografica As String, IdCobrador As Integer,
                                               FiltroPcs As String, CantidadPcs As Integer, crossJoin As Boolean, idCliente As Long, idTipoCliente As Integer) As System.Data.DataTable
      Dim dt As DataTable = New SqlServer.CargosClientes(Me.da).CargosClientes_GetAsignacion(idSucursal, idtipoLiquidacion, idCategoria,
                                                                                             idZonaGeografica, IdCobrador,
                                                                                             FiltroPcs, CantidadPcs,
                                                                                             crossJoin, idCliente, idTipoCliente)
      For Each dr As DataRow In dt.Select("FechaUltimoCambioPrecio IS NOT NULL")
         Dim fecha As DateTime = DateTime.Parse(dr("FechaUltimoCambioPrecio").ToString()).PrimerDiaMes
         dr("meses") = ((Today.Year - fecha.Year) * 12) + (Today.Month - fecha.Month)
      Next
      Return dt
   End Function

   Public Function [Get](idCliente As Long?, idCargo As Integer?, datosRelacionados As Boolean, idSucursal As Integer,
                         idtipoLiquidacion As Integer, idCobrador As Integer) As System.Data.DataTable
      Return New SqlServer.CargosClientes(Me.da).CargosClientes_G(idCliente, idCargo, Nothing, Nothing, datosRelacionados, idSucursal, idtipoLiquidacion, idCobrador)
   End Function

   Public Function [Get](idCliente As Long?, idCargo As Integer?,
                         idCategoria As Integer?, datosRelacionados As Boolean, idSucursal As Integer, idtipoLiquidacion As Integer, idCobrador As Integer) As System.Data.DataTable
      Return New SqlServer.CargosClientes(Me.da).CargosClientes_G(idCliente, idCargo, idCategoria, Nothing, datosRelacionados, idSucursal, idtipoLiquidacion, idCobrador)
   End Function

   Public Function [Get](idCliente As Long?, idCargo As Integer?, idCategoria As Integer?, idZonaGeografica As String,
                         datorRelacionados As Boolean, idSucursal As Integer, idTipoLiquidacion As Integer, idCobrador As Integer) As System.Data.DataTable
      Return New SqlServer.CargosClientes(Me.da).CargosClientes_G(idCliente, idCargo, idCategoria, idZonaGeografica, datorRelacionados, idSucursal, idTipoLiquidacion, idCobrador)
   End Function

#End Region

#Region "Metodos privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.CargoCliente = DirectCast(entidad, Entidades.CargoCliente)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.CargosClientes = New SqlServer.CargosClientes(Me.da)

         Select Case tipo

            Case TipoSP._I
               sql.CargosClientes_I(en.IdCargo, en.IdSucursal, en.IdCliente, en.PrecioLista, en.DescuentoRecargoPorc1, en.DescuentoRecargoPorcGral, en.Monto, en.Cantidad, en.Observacion, en.IdTipoLiquidacion)

            Case TipoSP._U
               sql.CargosClientes_U(en.IdCargo, en.IdSucursal, en.IdCliente, en.PrecioLista, en.DescuentoRecargoPorc1, en.DescuentoRecargoPorcGral, en.Monto, en.Cantidad, en.Observacion, en.IdTipoLiquidacion)

            Case TipoSP._D
               sql.CargosClientes_D(en.IdCargo, en.IdSucursal, en.IdCliente, en.IdTipoLiquidacion)

         End Select

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CargoCliente, ByVal dr As DataRow)
      With o
         .IdCliente = Long.Parse(dr(Entidades.CargoCliente.Columnas.IdCliente.ToString()).ToString())
         .IdCargo = Integer.Parse(dr(Entidades.CargoCliente.Columnas.IdCargo.ToString()).ToString())
         .IdTipoLiquidacion = Integer.Parse(dr(Entidades.CargoCliente.Columnas.IdTipoLiquidacion.ToString()).ToString())
         .Monto = Decimal.Parse(dr(Entidades.CargoCliente.Columnas.Monto.ToString()).ToString())
         .Cantidad = Decimal.Parse(dr(Entidades.CargoCliente.Columnas.Cantidad.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Overloads Sub Actualizar(drActualizar As DataRow())
      Try
         da.OpenConection()
         da.BeginTransaction()

         _Actualizar(drActualizar)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overloads Sub _Actualizar(drActualizar As DataRow())
      Dim sql As SqlServer.CargosClientes = New SqlServer.CargosClientes(Me.da)

      For Each dr As DataRow In drActualizar
         sql.CargosClientes_U(CInt(dr(Entidades.CargoCliente.Columnas.IdCargo.ToString())),
                              CInt(dr(Entidades.CargoCliente.Columnas.IdSucursal.ToString())),
                              CLng(dr(Entidades.CargoCliente.Columnas.IdCliente.ToString())),
                              CDec(dr(Entidades.CargoCliente.Columnas.PrecioLista.ToString())),
                              CDec(dr(Entidades.CargoCliente.Columnas.DescuentoRecargoPorc1.ToString())),
                              CDec(dr(Entidades.CargoCliente.Columnas.DescuentoRecargoPorcGral.ToString())),
                              CDec(dr(Entidades.CargoCliente.Columnas.Monto.ToString())),
                              CDec(dr(Entidades.CargoCliente.Columnas.Cantidad.ToString())),
                              dr(Entidades.CargoCliente.Columnas.Observacion.ToString()).ToString(),
                              CInt(dr(Entidades.CargoCliente.Columnas.IdTipoLiquidacion.ToString())))
      Next

   End Sub

   Public Function GetUno(ByVal idInmueble As Integer, ByVal idAdicional As Integer, ByVal IdSucursal As Integer,
                          ByVal IdTipoLiquidacion As Integer, ByVal IdCobrador As Integer) As Entidades.CargoCliente
      Dim sql As SqlServer.CargosClientes = New SqlServer.CargosClientes(Me.da)
      Dim dt As DataTable = sql.CargosClientes_G1(idInmueble, idAdicional, IdSucursal, IdTipoLiquidacion, IdCobrador)
      Dim o As Entidades.CargoCliente = New Entidades.CargoCliente()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Sub GrabarCargosClientes(idSucursal As Integer, listado As DataTable, colObservaciones As List(Of Entidades.CargoClienteObservacion), idTipoLiquidacion As Integer,
                                   idcliente As Long, idCategoria As Integer, idZonaGeografica As String, idCobrador As Integer, filtroPcs As String, cantidadPcs As Integer)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sqlCargosClientes As SqlServer.CargosClientes = New SqlServer.CargosClientes(Me.da)
         Dim sqlCargosClientesObserv As SqlServer.CargosClientesObservaciones = New SqlServer.CargosClientesObservaciones(Me.da)
         Dim reglasObservaciones As Reglas.CargosClientesObservaciones = New CargosClientesObservaciones(da)

         Dim decDescuentoRecargo As Decimal = 0

         sqlCargosClientes.CargosClientes_D(idSucursal, idTipoLiquidacion,
                                            idcliente, idCategoria, idZonaGeografica, idCobrador, filtroPcs, cantidadPcs)

         For Each dr As DataRow In listado.Select("Selec")
            If Decimal.Parse(dr("PrecioListaNuevo").ToString()) > 0 Then
               Dim precioLista As Decimal = Decimal.Parse(dr("PrecioListaNuevo").ToString())
               precioLista = precioLista * (1 + (Decimal.Parse(dr("descuentoRecargoPorcGral").ToString()) / 100))
               decDescuentoRecargo = Decimal.Round((Decimal.Parse(dr("MontoNuevo").ToString()) / precioLista * 100) - 100, 4)
            Else
               dr("PrecioListaNuevo") = dr("MontoNuevo")
               decDescuentoRecargo = 0
            End If


            sqlCargosClientes.CargosClientes_I(Integer.Parse(dr(Entidades.CargoCliente.Columnas.IdCargo.ToString()).ToString()),
                                               Integer.Parse(dr(Entidades.CargoCliente.Columnas.IdSucursal.ToString()).ToString()),
                                               Long.Parse(dr(Entidades.CargoCliente.Columnas.IdCliente.ToString()).ToString()),
                                               Decimal.Parse(dr("PrecioListaNuevo").ToString()),
                                               decDescuentoRecargo,
                                               Decimal.Parse(dr("descuentoRecargoPorcGral").ToString()),
                                               Decimal.Parse(dr("MontoNuevo").ToString()),
                                               Decimal.Parse(dr(Entidades.CargoCliente.Columnas.Cantidad.ToString()).ToString()),
                                               dr(Entidades.CargoCliente.Columnas.Observacion.ToString()).ToString(),
                                               idTipoLiquidacion)
         Next

         reglasObservaciones._Borrar(idSucursal, idTipoLiquidacion)
         '# Solo se guardan las observaciones si el cliente tiene tildado algún Cargo
         For Each CargoClienteOperacionActual As Entidades.CargoClienteObservacion In colObservaciones
            If listado.Select(String.Format("Selec AND IdCliente = {0}", CargoClienteOperacionActual.IdCliente)).Count > 0 Then
               reglasObservaciones.Inserta(CargoClienteOperacionActual)
            End If
         Next

         Me.da.CommitTransaction()

      Catch
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

#End Region

End Class