Option Explicit On
Option Strict On
#Region "Imports"
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class Cargos
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = "Cargos"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Cargos"
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return TiparDataTable(New SqlServer.Cargos(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString()))
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return TiparDataTable(New SqlServer.Cargos(Me.da).Cargos_GA())
   End Function

  

#End Region

#Region "Metodos Privados"

   Private Function TiparDataTable(dtOrigen As DataTable) As DataTable
      Dim dtResult As DataTable = New DataTable()

      With dtResult
         .Columns.Add(Entidades.Cargo.Columnas.IdCargo.ToString(), GetType(Int32))
         .Columns.Add(Entidades.Cargo.Columnas.IdTipoLiquidacion.ToString(), GetType(Int32))
         .Columns.Add(Entidades.Cargo.Columnas.NombreCargo.ToString(), GetType(String))
         .Columns.Add(Entidades.Cargo.Columnas.Monto.ToString(), GetType(Decimal))
         .Columns.Add(Entidades.Cargo.Columnas.Activo.ToString(), GetType(Boolean))
         .Columns.Add(Entidades.Cargo.Columnas.ImprimeVoucher.ToString(), GetType(Boolean))
         .Columns.Add(Entidades.Cargo.Columnas.CantidadMeses.ToString(), GetType(Int32))
         .Columns.Add(Entidades.Cargo.Columnas.ModificaImporte.ToString(), GetType(Boolean))
         .Columns.Add(Entidades.Cargo.Columnas.CantidadCuotas.ToString(), GetType(Int32))
         .Columns.Add(Entidades.Cargo.Columnas.CuotaActual.ToString(), GetType(Int32))
         .Columns.Add(Entidades.Cargo.ColumnasCargos.MontoOriginal.ToString(), GetType(Decimal))
         .Columns.Add(Entidades.Cargo.Columnas.ModificaCantidad.ToString(), GetType(Boolean))
         .Columns.Add(Entidades.Cargo.Columnas.IdProducto.ToString(), GetType(String))
         .Columns.Add(Eniac.Entidades.Producto.Columnas.NombreProducto.ToString(), GetType(String))
         .Columns.Add("NombreTipoLiquidacion", GetType(String))
         .Columns.Add(Entidades.Cargo.Columnas.CargoTemporal.ToString(), GetType(Boolean))
      End With

      Dim drResult As DataRow
      For Each drOrigen As DataRow In dtOrigen.Rows

         drResult = dtResult.NewRow()

         drResult(Entidades.Cargo.Columnas.IdCargo.ToString()) = Integer.Parse(drOrigen(Entidades.Cargo.Columnas.IdCargo.ToString()).ToString())
         drResult(Entidades.Cargo.Columnas.IdTipoLiquidacion.ToString()) = Integer.Parse(drOrigen(Entidades.Cargo.Columnas.IdTipoLiquidacion.ToString()).ToString())
         drResult(Entidades.Cargo.Columnas.NombreCargo.ToString()) = drOrigen(Entidades.Cargo.Columnas.NombreCargo.ToString()).ToString()
         drResult(Entidades.Cargo.Columnas.Monto.ToString()) = Decimal.Parse(drOrigen(Entidades.Cargo.Columnas.Monto.ToString()).ToString())
         drResult(Entidades.Cargo.Columnas.Activo.ToString()) = Boolean.Parse(drOrigen(Entidades.Cargo.Columnas.Activo.ToString()).ToString())
         drResult(Entidades.Cargo.Columnas.ImprimeVoucher.ToString()) = Boolean.Parse(drOrigen(Entidades.Cargo.Columnas.ImprimeVoucher.ToString()).ToString())
         If Not IsDBNull(drOrigen(Entidades.Cargo.Columnas.CantidadMeses.ToString())) Then
            drResult(Entidades.Cargo.Columnas.CantidadMeses.ToString()) = Integer.Parse(drOrigen(Entidades.Cargo.Columnas.CantidadMeses.ToString()).ToString())
         Else
            drResult(Entidades.Cargo.Columnas.CantidadMeses.ToString()) = DBNull.Value
         End If

         drResult(Entidades.Cargo.Columnas.ModificaImporte.ToString()) = Boolean.Parse(drOrigen(Entidades.Cargo.Columnas.ModificaImporte.ToString()).ToString())
         drResult(Entidades.Cargo.Columnas.ModificaCantidad.ToString()) = Boolean.Parse(drOrigen(Entidades.Cargo.Columnas.ModificaCantidad.ToString()).ToString())

         If IsDBNull(drOrigen(Entidades.Cargo.Columnas.CantidadCuotas.ToString())) Then
            drResult(Entidades.Cargo.Columnas.CantidadCuotas.ToString()) = DBNull.Value
            drResult(Entidades.Cargo.Columnas.CuotaActual.ToString()) = DBNull.Value
         Else
            drResult(Entidades.Cargo.Columnas.CantidadCuotas.ToString()) = Integer.Parse(drOrigen(Entidades.Cargo.Columnas.CantidadCuotas.ToString()).ToString())
            If IsDBNull(drOrigen(Entidades.Cargo.Columnas.CuotaActual.ToString())) Then
               drResult(Entidades.Cargo.Columnas.CuotaActual.ToString()) = Nothing
            Else
               drResult(Entidades.Cargo.Columnas.CuotaActual.ToString()) = Integer.Parse(drOrigen(Entidades.Cargo.Columnas.CuotaActual.ToString()).ToString())
            End If
         End If

         drResult(Entidades.Cargo.ColumnasCargos.MontoOriginal.ToString()) = Decimal.Parse(drOrigen(Entidades.Cargo.Columnas.Monto.ToString()).ToString())

         drResult(Entidades.Cargo.Columnas.IdProducto.ToString()) = drOrigen(Entidades.Cargo.Columnas.IdProducto.ToString())
         drResult(Eniac.Entidades.Producto.Columnas.NombreProducto.ToString()) = drOrigen(Eniac.Entidades.Producto.Columnas.NombreProducto.ToString())
         drResult("NombreTipoLiquidacion") = drOrigen("NombreTipoLiquidacion")

         drResult(Entidades.Cargo.Columnas.CargoTemporal.ToString()) = Boolean.Parse(drOrigen(Entidades.Cargo.Columnas.CargoTemporal.ToString()).ToString())

         dtResult.Rows.Add(drResult)
      Next


      Return dtResult
   End Function

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim cargo As Entidades.Cargo = DirectCast(entidad, Entidades.Cargo)
      Dim sql As SqlServer.Cargos = New SqlServer.Cargos(Me.da)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Select Case tipo
            Case TipoSP._I
               sql.Cargos_I(cargo)

            Case TipoSP._U
               sql.Cargos_U(cargo)

               If Not cargo.ModificaImporte Then
                  Dim rCargosClientes As CargosClientes = New CargosClientes(da)
                  Dim dtCargosClientes As DataTable = rCargosClientes.Get(Nothing, cargo.IdCargo, True, actual.Sucursal.IdSucursal, cargo.IdTipoLiquidacion, idCobrador:=0)

                  For Each dr As DataRow In dtCargosClientes.Rows
                     dr("PrecioLista") = cargo.Monto
                     dr("Monto") = cargo.Monto * (1 + ((If(IsNumeric(dr("DescuentoRecargoPorc1")), Decimal.Parse(dr("DescuentoRecargoPorc1").ToString()), 0D)) / 100))
                     dr("Importe") = cargo.Monto * If(IsNumeric(dr("Cantidad")), Decimal.Parse(dr("Cantidad").ToString()), 0)
                  Next
                  rCargosClientes._Actualizar(dtCargosClientes.Select())
               End If

            Case TipoSP._D
               sql.Cargos_D(cargo)
         End Select

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Cargo, ByVal dr As DataRow)
      With o
         .IdCargo = Integer.Parse(dr(Entidades.Cargo.Columnas.IdCargo.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.Cargo.Columnas.IdTipoLiquidacion.ToString()).ToString()) Then
            .IdTipoLiquidacion = Integer.Parse(dr(Entidades.Cargo.Columnas.IdTipoLiquidacion.ToString()).ToString())
         End If
         .NombreCargo = dr(Entidades.Cargo.Columnas.NombreCargo.ToString()).ToString()
         .Monto = Decimal.Parse(dr(Entidades.Cargo.Columnas.Monto.ToString()).ToString())
         .Activo = Boolean.Parse(dr(Entidades.Cargo.Columnas.Activo.ToString()).ToString())
         .ImprimeVoucher = Boolean.Parse(dr(Entidades.Cargo.Columnas.ImprimeVoucher.ToString()).ToString())

         If IsDBNull(dr(Entidades.Cargo.Columnas.CantidadMeses.ToString())) Then
            .CantidadMeses = Nothing
         Else
            .CantidadMeses = Integer.Parse(dr(Entidades.Cargo.Columnas.IdCargo.ToString()).ToString())
         End If

         .ModificaImporte = Boolean.Parse(dr(Entidades.Cargo.Columnas.ModificaImporte.ToString()).ToString())
         .ModificaCantidad = Boolean.Parse(dr(Entidades.Cargo.Columnas.ModificaCantidad.ToString()).ToString())

         If IsDBNull(dr(Entidades.Cargo.Columnas.CantidadCuotas.ToString())) Then
            .CantidadCuotas = Nothing
         Else
            .CantidadCuotas = Integer.Parse(dr(Entidades.Cargo.Columnas.CantidadCuotas.ToString()).ToString())
            If IsDBNull(dr(Entidades.Cargo.Columnas.CuotaActual.ToString())) Then
               .CuotaActual = Nothing
            Else
               .CuotaActual = Integer.Parse(dr(Entidades.Cargo.Columnas.CuotaActual.ToString()).ToString())
            End If
         End If

         If Not IsDBNull(dr(Entidades.Cargo.Columnas.IdProducto.ToString())) Then
            .Producto = New Eniac.Reglas.Productos(Me.da).GetUno(dr(Entidades.Cargo.Columnas.IdProducto.ToString()).ToString())
         End If

         .CargoTemporal = Boolean.Parse(dr(Entidades.Cargo.Columnas.CargoTemporal.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Function GetPorCodigoNombre(idCargo As Integer?, nombreCargo As String) As DataTable
      Return New SqlServer.Cargos(Me.da).Cargos_G(idCargo, nombreCargo)
   End Function

   Public Function GetCargosPorPeriodo(ByVal Periodo As Integer, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable

      Dim sql As SqlServer.Cargos = New SqlServer.Cargos(Me.da)

      Dim dt As DataTable

      dt = sql.GetCargosPorPeriodo(Periodo, IdSucursal, IdTipoLiquidacion)

      Return dt

   End Function

   Public Function GetCargosPorTipoLiquidacion(ByVal IdtipoLiquidacion As Integer) As DataTable

      Return TiparDataTable(New SqlServer.Cargos(Me.da).Cargos_GxTipoLiquidacion(IdtipoLiquidacion))

   End Function

   Public Function GetTiposLiquidacion() As DataTable

      Dim sql As SqlServer.Cargos = New SqlServer.Cargos(Me.da)

      Dim dt As DataTable

      dt = sql.GetTiposLiquidacion()

      Return dt

   End Function

   Public Sub ActualizarComprobante(IdCargo As Integer, ByVal Periodo As Integer, ByVal IdCliente As Long, _
                                     ByVal idSucursal As Integer, ByVal idTipoComprobante As String, _
                                    ByVal letra As String, ByVal centroEmisor As Integer, ByVal numeroComprobante As Long,
                                    ByVal ImporteTotal As Decimal, ByVal IdTipoLiquidacion As Integer)

      Dim blnConexionAbierta As Boolean = Me.da.Connection IsNot Nothing AndAlso Me.da.Connection.State = ConnectionState.Open

      Try
         If Not blnConexionAbierta Then
            Me.da.OpenConection()
            Me.da.BeginTransaction()
         End If

         Dim sqlC As SqlServer.LiquidacionesCargos = New SqlServer.LiquidacionesCargos(da)
         sqlC.ActualizarComprobante(IdCargo, Periodo, IdCliente, idSucursal, idTipoComprobante,
                                    letra, centroEmisor, numeroComprobante, 0, IdTipoLiquidacion)

         If Not blnConexionAbierta Then Me.da.CommitTransaction()

      Catch ex As Exception
         If Not blnConexionAbierta Then Me.da.RollbakTransaction()
         Throw
      Finally
         If Not blnConexionAbierta Then Me.da.CloseConection()
      End Try

   End Sub

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Cargos(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetUno(ByVal idCargo As Integer, ByVal IdTipoLiquidacion As Integer) As Entidades.Cargo
      Dim sql As SqlServer.Cargos = New SqlServer.Cargos(Me.da)
      Dim dt As DataTable = sql.Cargos_G1(idCargo)
      Dim o As Entidades.Cargo = New Entidades.Cargo()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetCargosModificaImporte(idCargo As Integer, nombreCargo As String, IdTipoLiquidacion As Integer) As DataTable
      Dim sql As SqlServer.Cargos = New SqlServer.Cargos(Me.da)
      Dim dt As DataTable = sql.CargosModificaImporte(idCargo, nombreCargo, IdTipoLiquidacion)
      Return dt
   End Function

   Public Function GetFiltradoPorCodigoNombre(IdCargo As Integer?, nombreCargo As String, idTipoLiquidacion As Integer) As DataTable
      Try
         da.OpenConection()
         Dim dt As DataTable = New SqlServer.Cargos(da).GetFiltradoPorCodigo(IdCargo, nombreCargo)
         If dt.Rows.Count = 0 Then
            dt = New SqlServer.Cargos(da).GetFiltradoPorCodigo(IdCargo, nombreCargo)
            'verificar como es esto
         End If
         Return dt

      Finally
         da.CloseConection()
      End Try

   End Function

#End Region

End Class
