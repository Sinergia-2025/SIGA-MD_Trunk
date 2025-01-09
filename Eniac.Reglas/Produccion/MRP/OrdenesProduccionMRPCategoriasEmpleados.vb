#Region "Option"
Option Strict On
Option Explicit On
#End Region
Imports Eniac.Entidades
Imports Eniac.Entidades.ContabilidadProceso

Public Class OrdenesProduccionMRPCategoriasEmpleados
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = OrdenProduccionMRPCategoriaEmpleado.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- --------------------------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPCategoriaEmpleado), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPCategoriaEmpleado), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPCategoriaEmpleado), TipoSP._D))
   End Sub
   '-- Sin transacciones.- ------------------------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPCategoriaEmpleado), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPCategoriaEmpleado), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPCategoriaEmpleado), TipoSP._D)
   End Sub
   '-----------------------------------------------------------------------------------------------------------------
   Public Function _GetAll(idSucursal As Integer,
                           idTipoComprobante As String,
                           letra As String,
                           centroEmisor As Integer,
                           numeroOrdenProduccion As Long,
                           orden As Integer,
                           idProducto As String,
                           idProcesosProductivos As Long,
                           idOperacion As Integer) As System.Data.DataTable

      Return New SqlServer.OrdenesProduccionMRPCategoriasEmpleados(Me.da).OrdenesProduccionMRPCategoriaE_GA(idSucursal:=idSucursal,
                                                                                                            idTipoComprobante:=idTipoComprobante,
                                                                                                            letra:=letra,
                                                                                                            centroEmisor:=centroEmisor,
                                                                                                            numeroOrdenProduccion:=numeroOrdenProduccion,
                                                                                                            orden:=orden,
                                                                                                            idProducto:=idProducto,
                                                                                                            idProcesosProductivos:=idProcesosProductivos,
                                                                                                            idOperacion:=idOperacion)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.OrdenProduccionMRPCategoriaEmpleado, tipo As TipoSP)
      Dim sqlC = New SqlServer.OrdenesProduccionMRPCategoriasEmpleados(da)
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Orden de Produccion MRP Categorias Empleados.- --------
            sqlC.OrdenesProduccionMRPCategoriasE_I(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden,
                                                   en.IdProducto, en.MRPCategoriaEmpleado.IdProcesoProductivo, en.MRPCategoriaEmpleado.IdOperacion, en.MRPCategoriaEmpleado.IdCategoriaEmpleado,
                                                   en.MRPCategoriaEmpleado.CantidadCategoria, en.MRPCategoriaEmpleado.ValorHoraCategoria)
         Case TipoSP._U
            '-- Modifica Orden de Produccion MRP Categorias Empleados.- --------
            sqlC.OrdenesProduccionMRPCategoriasE_U(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden,
                                                   en.IdProducto, en.MRPCategoriaEmpleado.IdProcesoProductivo, en.MRPCategoriaEmpleado.IdOperacion, en.MRPCategoriaEmpleado.IdCategoriaEmpleado,
                                                   en.MRPCategoriaEmpleado.CantidadCategoria, en.MRPCategoriaEmpleado.ValorHoraCategoria)
         Case TipoSP._D
            '-- Elimina Orden de Produccion MRP Categorias Empleados.- --------------------
            sqlC.OrdenesProduccionMRPCategoriasE_D(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto,
                                                   en.MRPCategoriaEmpleado.IdProcesoProductivo, en.MRPCategoriaEmpleado.IdOperacion, en.MRPCategoriaEmpleado.IdCategoriaEmpleado)
      End Select
   End Sub

   Private Sub CargarUno(o As OrdenProduccionMRPCategoriaEmpleado, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(OrdenProduccionMRPCategoriaEmpleado.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(OrdenProduccionMRPCategoriaEmpleado.Columnas.IdTipoComprobante.ToString())
         .LetraComprobante = dr.Field(Of String)(OrdenProduccionMRPCategoriaEmpleado.Columnas.LetraComprobante.ToString())
         .CentroEmisor = dr.Field(Of Integer)(OrdenProduccionMRPCategoriaEmpleado.Columnas.CentroEmisor.ToString())
         .NumeroOrdenProduccion = dr.Field(Of Integer)(OrdenProduccionMRPCategoriaEmpleado.Columnas.NumeroOrdenProduccion.ToString())
         .Orden = dr.Field(Of Integer)(OrdenProduccionMRPCategoriaEmpleado.Columnas.Orden.ToString())
         .IdProducto = dr.Field(Of String)(OrdenProduccionMRPCategoriaEmpleado.Columnas.IdProducto.ToString())
         With .MRPCategoriaEmpleado
            .IdOperacion = dr.Field(Of Integer)(OrdenProduccionMRPCategoriaEmpleado.Columnas.IdOperacion.ToString())
            .IdProcesoProductivo = dr.Field(Of Long)(OrdenProduccionMRPCategoriaEmpleado.Columnas.IdProcesoProductivo.ToString())
            .IdCategoriaEmpleado = dr.Field(Of Integer)(OrdenProduccionMRPCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString())
            .CantidadCategoria = dr.Field(Of Decimal)(OrdenProduccionMRPCategoriaEmpleado.Columnas.CantidadCategoria.ToString())
            .ValorHoraCategoria = dr.Field(Of Decimal)(OrdenProduccionMRPCategoriaEmpleado.Columnas.ValorHoraCategoria.ToString())
            .NombreCategoriaEmpleado = dr.Field(Of String)(MRPCategoriaEmpleado.Columnas.Descripcion.ToString())
         End With
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetTodas(idSucursal As Integer,
                            idTipoComprobante As String,
                            letra As String,
                            centroEmisor As Integer,
                            numeroOrdenProduccion As Long,
                            orden As Integer,
                            idProducto As String,
                            idProcesosProductivos As Long,
                            idOperacion As Integer) As ListConBorrados(Of OrdenProduccionMRPCategoriaEmpleado)
      Dim dt = _GetAll(idSucursal:=idSucursal,
                       idTipoComprobante:=idTipoComprobante,
                       letra:=letra,
                       centroEmisor:=centroEmisor,
                       numeroOrdenProduccion:=
                       numeroOrdenProduccion,
                       orden:=orden,
                       idProducto:=idProducto,
                       idProcesosProductivos:=idProcesosProductivos,
                       idOperacion:=idOperacion)
      Dim o As OrdenProduccionMRPCategoriaEmpleado
      Dim oLis = New ListConBorrados(Of OrdenProduccionMRPCategoriaEmpleado)
      For Each dr As DataRow In dt.Rows
         o = New OrdenProduccionMRPCategoriaEmpleado
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Sub ActualizaDesdeOrdenesProduccionMRPOperaciones(entidad As OrdenProduccionMRPOperacion)
      If entidad.CategoriasEmpleados IsNot Nothing Then
         For Each oCE In entidad.CategoriasEmpleados
            '-- Elimina los Borrados.- --------------------------------------------------
            For Each ent In entidad.CategoriasEmpleados.Borrados
               _Borrar(ent)
            Next
            '----------------------------------------------------------------------------
            If oCE.NumeroOrdenProduccion > 0 Then
               _Actualizar(oCE)
            Else
               With oCE
                  .IdSucursal = entidad.IdSucursal
                  .IdTipoComprobante = entidad.IdTipoComprobante
                  .LetraComprobante = entidad.LetraComprobante
                  .CentroEmisor = entidad.CentroEmisor
                  .NumeroOrdenProduccion = entidad.NumeroOrdenProduccion
                  .Orden = entidad.Orden
                  .IdProducto = entidad.IdProducto
               End With
               _Insertar(oCE)
            End If
         Next
         '----------------------------------------------------------------------------
      End If
   End Sub

   Public Function CopiaOrdenProduccionMRPCategoriasEmpleado(operacion As MRPProcesoProductivoOperacion, cantidad As Decimal, idSucursal As Integer, idProducto As String) As ListConBorrados(Of OrdenProduccionMRPCategoriaEmpleado)
      Dim eOPMrpCEs = New ListConBorrados(Of OrdenProduccionMRPCategoriaEmpleado)()

      For Each eProcProdCE In operacion.CategoriasEmpleados
         Dim eOPMrpCE = New Entidades.OrdenProduccionMRPCategoriaEmpleado()
         With eOPMrpCE
            .IdSucursal = idSucursal
            .IdProducto = idProducto

            .MRPCategoriaEmpleado.IdOperacion = eProcProdCE.IdOperacion
            .MRPCategoriaEmpleado.IdProcesoProductivo = eProcProdCE.IdProcesoProductivo
            .MRPCategoriaEmpleado.IdCategoriaEmpleado = eProcProdCE.IdCategoriaEmpleado
            .MRPCategoriaEmpleado.CantidadCategoria = eProcProdCE.CantidadCategoria
            .MRPCategoriaEmpleado.ValorHoraCategoria = eProcProdCE.ValorHoraCategoria
         End With
         eOPMrpCEs.Add(eOPMrpCE)
      Next
      Return eOPMrpCEs
   End Function
#End Region

End Class
