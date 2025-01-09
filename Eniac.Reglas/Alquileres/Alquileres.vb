Option Strict On
Option Explicit On

Imports Eniac.Entidades

Public Class Alquileres
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Alquileres"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

   'Public Function GetDocs(ByVal nrodoc As String) As DataTable
   '   Dim sql As SqlServer.Alquileres = New SqlServer.Alquileres(Me.da)
   '   Return sql.GetDocs(nrodoc)
   'End Function

   'Public Function GetNombre(ByVal nombre As String) As DataTable
   '   Dim sql As SqlServer.Alquileres = New SqlServer.Alquileres(Me.da)
   '   Return sql.GetNombre(nombre)
   'End Function

   Private Sub CargarUna(ByVal o As Entidades.Alquiler, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.Alquiler.Columnas.IdSucursal.ToString()).ToString())
         .NumeroContrato = Long.Parse(dr(Entidades.Alquiler.Columnas.NumeroContrato.ToString()).ToString())
         .FechaContrato = Date.Parse(dr(Entidades.Alquiler.Columnas.FechaContrato.ToString()).ToString())
         .IdProducto = dr(Entidades.Alquiler.Columnas.IdProducto.ToString()).ToString()
         .FechaDesde = Date.Parse(dr(Entidades.Alquiler.Columnas.FechaDesde.ToString()).ToString())
         .FechaHasta = Date.Parse(dr(Entidades.Alquiler.Columnas.FechaHasta.ToString()).ToString())
         .IdCliente = Long.Parse(dr(Entidades.Alquiler.Columnas.IdCliente.ToString()).ToString())
         .esRenovable = Boolean.Parse(dr(Entidades.Alquiler.Columnas.esRenovable.ToString()).ToString())
         .LocatarioNroDocumento = Long.Parse(dr(Entidades.Alquiler.Columnas.LocatarioNroDocumento.ToString()).ToString())
         .LocatarioNombre = dr(Entidades.Alquiler.Columnas.LocatarioNombre.ToString()).ToString()
         .LocatarioCargo = dr(Entidades.Alquiler.Columnas.LocatarioCargo.ToString()).ToString()
         .ImporteAlquiler = Decimal.Parse(dr(Entidades.Alquiler.Columnas.ImporteAlquiler.ToString()).ToString())
         .ImporteTraslado = Decimal.Parse(dr(Entidades.Alquiler.Columnas.ImporteTraslado.ToString()).ToString())
         .ImporteTotal = Decimal.Parse(dr(Entidades.Alquiler.Columnas.ImporteTotal.ToString()).ToString())
         .PersonalCapacitado = dr(Entidades.Alquiler.Columnas.PersonalCapacitado.ToString()).ToString()
         .LugarER = dr(Entidades.Alquiler.Columnas.LugarER.ToString()).ToString()
         .horaE = dr(Entidades.Alquiler.Columnas.horaE.ToString()).ToString()
         .horaR = dr(Entidades.Alquiler.Columnas.horaR.ToString()).ToString()
         .NombreProducto = dr(Entidades.Alquiler.Columnas.NombreProducto.ToString()).ToString()
         .FechaRealFin = Date.Parse(dr(Entidades.Alquiler.Columnas.FechaRealFin.ToString()).ToString())
         .IdEstado = Integer.Parse(dr(Entidades.Alquiler.Columnas.IdEstado.ToString()).ToString())
         .IdUsuario = dr(Entidades.Alquiler.Columnas.IdUsuario.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Entidades.Alquiler.Columnas.IdTipoComprobante.ToString()).ToString()) Then
            .IdTipoComprobante = dr(Entidades.Alquiler.Columnas.IdTipoComprobante.ToString()).ToString()
            .Letra = dr(Entidades.Alquiler.Columnas.Letra.ToString()).ToString()
            .CentroEmisor = Short.Parse(dr(Entidades.Alquiler.Columnas.CentroEmisor.ToString()).ToString())
            .NumeroComprobante = Long.Parse(dr(Entidades.Alquiler.Columnas.NumeroComprobante.ToString()).ToString())
         End If
      End With
   End Sub

   Public Function GetTodos() As List(Of Entidades.Alquiler)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.Alquiler

      Dim oLis As List(Of Entidades.Alquiler) = New List(Of Entidades.Alquiler)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Alquiler
         Me.CargarUna(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUna(ByVal idSucursal As Integer,
                          ByVal numeroContrato As Long) As Entidades.Alquiler

      'ByVal IdProducto As String, _
      'ByVal FechaDesde As Date, _
      'ByVal FechaHasta As Date) As Entidades.Alquiler

      Dim sql As SqlServer.Alquileres = New SqlServer.Alquileres(Me.da)
      Dim dt As DataTable = sql.Alquiler_G1(idSucursal, numeroContrato)
      Dim o As Entidades.Alquiler = New Entidades.Alquiler()
      If dt.Rows.Count > 0 Then
         Me.CargarUna(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Contrato de Alquiler")
      End If
      Return o
   End Function

   Public Function Get1(ByVal idSucursal As Integer,
                        ByVal numeroContrato As Long) As DataTable
      'ByVal IdProducto As String, _
      'ByVal FechaDesde As Date, _
      'ByVal FechaHasta As Date) As DataTable
      Dim sql As SqlServer.Alquileres = New SqlServer.Alquileres(Me.da)
      Return sql.Alquiler_G1(idSucursal, numeroContrato)
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Alquileres(Me.da).Alquiler_GA(1)
   End Function

   Public Function GetAll2(ByVal idSucursal As Integer) As System.Data.DataTable
      Return New SqlServer.Alquileres(Me.da).Alquiler_GA(idSucursal)
   End Function

   Public Function validarFechaReal(ByVal idSucursal As Integer,
                                    ByVal IdProducto As String,
                                    ByVal fechaReal As Date) As Boolean
      Return New SqlServer.Alquileres(Me.da).validarFechaReal(idSucursal, IdProducto, fechaReal)
   End Function

   Public Function GetIDMaximo() As Long

      Dim sql As SqlServer.Alquileres = New SqlServer.Alquileres(Me.da)
      Dim dt As DataTable = sql.Alquiler_GetIDMaximo()
      Dim val As Long = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Long.Parse(dt.Rows(0)("Maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Function GetContratos(ByVal IdSucursal As Integer _
                                 , ByVal fechaDesde As Date _
                                 , ByVal fechaHasta As Date _
                                 , ByVal idEstado As Integer _
                                 , ByVal SoloActivos As Boolean _
                                 , ByVal esRenovable As String _
                                 , ByVal idProducto As String) As DataTable

      Dim sql As SqlServer.Alquileres = New SqlServer.Alquileres(Me.da)

      Return sql.GetContratos(IdSucursal _
                            , fechaDesde _
                            , fechaHasta _
                            , idEstado _
                            , SoloActivos _
                            , esRenovable _
                            , idProducto)

   End Function

   Public Sub ActualizarEstadoContrato(ByVal IdSucursal As Integer,
                                       ByVal NumeroContrato As Long,
                                       ByVal IdEstado As Integer,
                                       ByVal FechaRealFin As Date,
                                       ByVal MetodoGrabacion As Entidad.MetodoGrabacion,
                                       ByVal IdFuncion As String)

      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Alquileres = New SqlServer.Alquileres(da)
         sql.ActualizarEstadoContrato(IdSucursal, NumeroContrato, IdEstado, FechaRealFin)

         Dim oAlquiler As Entidades.Alquiler = New Entidades.Alquiler
         oAlquiler = Me.GetUna(IdSucursal, NumeroContrato)

         Dim oProducto As Entidades.Producto = New Entidades.Producto
         oProducto = New Reglas.Productos().GetUno(oAlquiler.IdProducto)

         Dim _ventasObservaciones As List(Of Entidades.VentaObservacion) = New List(Of Entidades.VentaObservacion)()
         Dim oLineaObservacion As Entidades.VentaObservacion

         oLineaObservacion = New Entidades.VentaObservacion()
         With oLineaObservacion
            .IdSucursal = oAlquiler.IdSucursal
            .Usuario = oAlquiler.IdUsuario
            .Linea = 1
            .Observacion = "Equipo Marca: " & oProducto.EquipoMarca
         End With
         _ventasObservaciones.Add(oLineaObservacion)

         oLineaObservacion = New Entidades.VentaObservacion()
         With oLineaObservacion
            .IdSucursal = oAlquiler.IdSucursal
            .Usuario = oAlquiler.IdUsuario
            .Linea = 2
            .Observacion = "Modelo: " & oProducto.EquipoModelo & ", Año: " & oProducto.Anio
         End With
         _ventasObservaciones.Add(oLineaObservacion)

         oLineaObservacion = New Entidades.VentaObservacion()
         With oLineaObservacion
            .IdSucursal = oAlquiler.IdSucursal
            .Usuario = oAlquiler.IdUsuario
            .Linea = 3
            .Observacion = "Serie N°: " & oProducto.NumeroSerie
         End With
         _ventasObservaciones.Add(oLineaObservacion)

         oLineaObservacion = New Entidades.VentaObservacion()
         With oLineaObservacion
            .IdSucursal = oAlquiler.IdSucursal
            .Usuario = oAlquiler.IdUsuario
            .Linea = 4
            .Observacion = ""
         End With
         _ventasObservaciones.Add(oLineaObservacion)

         oLineaObservacion = New Entidades.VentaObservacion()
         With oLineaObservacion
            .IdSucursal = oAlquiler.IdSucursal
            .Usuario = oAlquiler.IdUsuario
            .Linea = 5
            .Observacion = "Vigengcia: " & oAlquiler.FechaDesde.ToString("dd/MM/yyyy") & " al " & oAlquiler.FechaRealFin.ToString("dd/MM/yyyy")
         End With
         _ventasObservaciones.Add(oLineaObservacion)

         oLineaObservacion = New Entidades.VentaObservacion()
         With oLineaObservacion
            .IdSucursal = oAlquiler.IdSucursal
            .Usuario = oAlquiler.IdUsuario
            .Linea = 6
            .Observacion = ""
         End With
         _ventasObservaciones.Add(oLineaObservacion)

         oLineaObservacion = New Entidades.VentaObservacion()
         With oLineaObservacion
            .IdSucursal = oAlquiler.IdSucursal
            .Usuario = oAlquiler.IdUsuario
            .Linea = 7
            .Observacion = "Lugar de Entrega: " & oAlquiler.LugarER
         End With
         _ventasObservaciones.Add(oLineaObservacion)


         '----------------------------------------------------------------------------------------------------

         Dim regClientes As Reglas.Clientes = New Reglas.Clientes(da)
         Dim oCliente As Entidades.Cliente

         oCliente = regClientes.GetUno(oAlquiler.IdCliente, False)

         'Corregir para que no habra conexion.
         Dim oReglaVentas As Reglas.Ventas = New Reglas.Ventas(da)

         Dim oComprobante As Entidades.Venta
         Dim IdCliente As Long = oCliente.IdCliente
         Dim fecha As Date = Date.Now        'oAlquiler.FechaContrato 
         Dim Ven As Empleado = oCliente.Vendedor
         Dim Observacion As String
         Dim idProducto As String = oAlquiler.IdProducto

         Dim idFormaDePagoCtaCte As Integer = New Reglas.VentasFormasPago().GetUna("VENTAS", False).IdFormasPago


         Observacion = Strings.Left("Generado por Alquiler: " & oAlquiler.NumeroContrato.ToString() & ". Emision: " & oAlquiler.FechaContrato.ToString("dd/MM/yyyy") & ". Monto: " & oAlquiler.ImporteTotal.ToString("#,##0.00") & ".", 100)

         If IdEstado = 20 Then 'En Vigencia

            Dim IdTipoComprobante As String = "REMITO"

            oComprobante = oReglaVentas.GrabarComprobante(IdSucursal,
                                                          IdTipoComprobante,
                                                          IdCliente,
                                                          0,
                                                          fecha,
                                                          Ven,
                                                          idFormaDePagoCtaCte,
                                                          Observacion,
                                                          oAlquiler.ImporteTotal,
                                                          idProducto,
                                                          1,
                                                          _ventasObservaciones,
                                                          Nothing,
                                                          contactos:=Nothing,
                                                          nombreProducto:=String.Empty,
                                                          cobrador:=Nothing,
                                                          comprobantesAsociados:={},
                                                          idEmbarcacion:=0,
                                                          metodoGrabacion:=MetodoGrabacion,
                                                          idFuncion:=IdFuncion)

            sql.ActualizarRemitoContrato(IdSucursal, NumeroContrato, oComprobante.IdTipoComprobante, oComprobante.LetraComprobante, oComprobante.CentroEmisor, oComprobante.NumeroComprobante)


         Else  'Renovado / Finalizado

            Dim sql2 As SqlServer.Ventas = New SqlServer.Ventas(da)
            sql2.Ventas_ActualizaEstadoComprobante(IdSucursal, oAlquiler.IdTipoComprobante, oAlquiler.Letra, oAlquiler.CentroEmisor, oAlquiler.NumeroComprobante, "PENDIENTE")

            Dim VentasObserv As Reglas.VentasObservaciones = New Reglas.VentasObservaciones(da)

            For Each Observ As Entidades.VentaObservacion In _ventasObservaciones

               Observ.IdTipoComprobante = oAlquiler.IdTipoComprobante
               Observ.Letra = oAlquiler.Letra
               Observ.CentroEmisor = oAlquiler.CentroEmisor
               Observ.NumeroComprobante = oAlquiler.NumeroComprobante

               'Borro las anteriores
               If Observ.Linea = 1 Then
                  VentasObserv.EjecutaSP(Observ, TipoSP._D)
               End If

               VentasObserv.EjecutaSP(Observ, TipoSP._I)
            Next

            If IdEstado = 40 Then  'Finalizado
               Dim IdTipoComprobante As String = "DEV-REMITO"

               oComprobante = oReglaVentas.GrabarComprobante(IdSucursal,
                                                             IdTipoComprobante,
                                                             IdCliente,
                                                             0,
                                                             fecha,
                                                             Ven,
                                                             idFormaDePagoCtaCte,
                                                             Observacion,
                                                             oAlquiler.ImporteTotal,
                                                             idProducto,
                                                             1,
                                                             _ventasObservaciones,
                                                             Nothing,
                                                             contactos:=Nothing,
                                                             nombreProducto:=String.Empty,
                                                             cobrador:=Nothing,
                                                             comprobantesAsociados:={},
                                                             idEmbarcacion:=0,
                                                             metodoGrabacion:=MetodoGrabacion,
                                                             idFuncion:=IdFuncion)

            End If

         End If

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As System.Data.DataTable
      Dim sql As SqlServer.Alquileres = New SqlServer.Alquileres(Me.da)
      Return sql.Buscar(entidad.IdSucursal, entidad.Columna, entidad.Valor.ToString())
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.Alquiler = DirectCast(entidad, Entidades.Alquiler)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Alquileres = New SqlServer.Alquileres(Me.da)

         Select Case tipo

            Case TipoSP._I

               sql.Alquiler_I(en.IdSucursal, en.NumeroContrato, en.FechaContrato, en.IdProducto, en.FechaDesde, en.FechaHasta, en.esRenovable,
                              en.LocatarioNroDocumento, en.LocatarioNombre, en.LocatarioCargo, en.ImporteTotal,
                              en.PersonalCapacitado, en.LugarER, en.horaE, en.horaR, en.FechaRealFin, en.IdUsuario, en.ImporteAlquiler, en.ImporteTraslado, en.IdCliente)

            Case TipoSP._U
               sql.Alquiler_U(en.IdSucursal, en.NumeroContrato, en.FechaContrato, en.IdProducto, en.FechaDesde, en.FechaHasta, en.esRenovable,
                              en.LocatarioNroDocumento, en.LocatarioNombre, en.LocatarioCargo, en.ImporteTotal,
                              en.PersonalCapacitado, en.LugarER, en.horaE, en.horaR, en.FechaRealFin, en.IdUsuario, en.ImporteAlquiler, en.ImporteTraslado, en.IdCliente)

            Case TipoSP._D
               sql.Alquiler_D(en.IdSucursal, en.NumeroContrato)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

#End Region

End Class
