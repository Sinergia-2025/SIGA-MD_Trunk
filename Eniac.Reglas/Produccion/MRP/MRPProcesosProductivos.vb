Imports Eniac.Entidades

Public Class MRPProcesosProductivos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = MRPProcesoProductivo.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- -----------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivo), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivo), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivo), TipoSP._D))
   End Sub
   '-- Sin transacciones.- ---------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivo), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivo), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivo), TipoSP._D)
   End Sub
   '-------------------------------------------------------------------------------------------------

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MRPProcesosProductivos(Me.da).ProcesosProductivos_GA()
   End Function

   Public Overrides Function GetAll(idProductoProceso As String) As System.Data.DataTable
      Return New SqlServer.MRPProcesosProductivos(Me.da).ProcesosProductivos_GA(idProductoProceso, Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Function _GetAll(idProductoProceso As String, activosSiNo As Entidades.Publicos.SiNoTodos) As System.Data.DataTable
      Return New SqlServer.MRPProcesosProductivos(Me.da).ProcesosProductivos_GA(idProductoProceso, activosSiNo)
   End Function

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPProcesoProductivo, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPProcesosProductivos(da)
      Select Case tipo
         Case TipoSP._I
            '-- Obtengo el ultimo Id de Proceso Productivo.- --------------------------------------------------------------------------------------------
            en.IdProcesoProductivo = GetCodigoMaximo() + 1
            '-- Informa las Fechas.- --------------------------------------------------------------------------------------------------------------------
            en.FechaAltaProceso = Now
            en.FechaModificaProceso = Now
            en.FechaActualizaCostos = Now
            '-- Inserto el Proceso Productivo.- ---------------------------------------------------------------------------------------------------------
            sqlC.ProcesosProductivos_I(en.IdProcesoProductivo, en.IdProductoProceso, en.CodigoProcesoProductivo, en.DescripcionProceso,
                                       en.CostoManoObraInterna, en.CostoManoObraExterna, en.CostoMateriaPrima, en.CostoTotalProceso, en.FechaAltaProceso,
                                       en.FechaModificaProceso, en.FechaActualizaCostos, en.TiempoTotalProceso, en.IdArchivoAdjunto,
                                       en.RespetaOrden, en.Activo)
            '-- Llamo a la regla para insertar las Operaciones del Proceso Productivo.- -----------------------------------------------------------------
            Dim rOperacionesPP = New Reglas.MRPProcesosProductivosOperaciones(da)
            rOperacionesPP.ActualizaDesdeProcesosProductivos(en)
            '-- Actualiza Precio Producto si esta activo.- ----------------------------------------------------------------------------------------------
            If en.Activo Then
               '-- Actualizo Costo - Id Proceso Productivo.- --------------------------------------------------------------------------------------------
               Dim rProducto = New Reglas.Productos(da)
               Dim eProd = rProducto.GetUno(en.IdProductoProceso, False, True)
               If eProd.IdProcesoProductivoDefecto Is Nothing Then
                  eProd.IdProcesoProductivoDefecto = en.IdProcesoProductivo
               Else
                  Dim eProcProd = New Reglas.MRPProcesosProductivos(da).GetUno(CLng(eProd.IdProcesoProductivoDefecto), eProd.IdProducto)
                  If eProcProd.IdProcesoProductivo = 0 Then
                     eProd.IdProcesoProductivoDefecto = en.IdProcesoProductivo
                  End If
               End If
               rProducto.ActualizarPrecioProcesoProd(eProd, en.CostoTotalProceso)
            End If
            '--------------------------------------------------------------------------------------------------------------------------------------------
         Case TipoSP._U
            '-- Informa las Fechas.- --------------------------------------------------------------------------------------------------------------------
            en.FechaModificaProceso = Now
            '-- Llamo a la regla para insertar las Operaciones del Proceso Productivo.- -----------------------------------------------------------------
            Dim rOperacionesPP = New Reglas.MRPProcesosProductivosOperaciones(da)
            rOperacionesPP.ActualizaDesdeProcesosProductivos(en)
            '-- Actualizo el Proceso Productivo.- -------------------------------------------------------------------------------------------------------
            sqlC.ProcesosProductivos_U(en.IdProcesoProductivo, en.IdProductoProceso, en.CodigoProcesoProductivo, en.DescripcionProceso,
                                       en.CostoManoObraInterna, en.CostoManoObraExterna, en.CostoMateriaPrima, en.CostoTotalProceso, en.FechaAltaProceso,
                                       en.FechaModificaProceso, en.FechaActualizaCostos, en.TiempoTotalProceso, en.IdArchivoAdjunto, en.RespetaOrden, en.Activo)
            '-- Actualiza Precio Producto si esta activo.- ----------------------------------------------------------------------------------------------
            If en.Activo Then
               '-- Actualizo Costo - Id Proceso Productivo.- --------------------------------------------------------------------------------------------
               Dim rProducto = New Reglas.Productos(da)
               Dim eProd = rProducto.GetUno(en.IdProductoProceso, False, True)
               If eProd.IdProcesoProductivoDefecto Is Nothing Then
                  eProd.IdProcesoProductivoDefecto = en.IdProcesoProductivo
               Else
                  Dim eProcProd = New Reglas.MRPProcesosProductivos(da).GetUno(CLng(eProd.IdProcesoProductivoDefecto), eProd.IdProducto)
                  If eProcProd.IdProcesoProductivo = 0 Then
                     eProd.IdProcesoProductivoDefecto = en.IdProcesoProductivo
                  End If
               End If
               rProducto.ActualizarPrecioProcesoProd(eProd, en.CostoTotalProceso)
            End If
            '--------------------------------------------------------------------------------------------------------------------------------------------
         Case TipoSP._D
            '-- Elimina Procesos Productivos - Operaciones.- ------
            Dim rOperaciones = New Reglas.MRPProcesosProductivosOperaciones(da)
            '-- Desmarca Envios y Recepciones.-  -----------------------------------
            rOperaciones._ActualizaOperEnvioRecepcion(0, en.IdProcesoProductivo, 0)
            '-----------------------------------------------------------------------
            For Each eOperac In en.Operaciones
               rOperaciones._Borrar(eOperac)
            Next
            '-- Elimina Procesos Productivos.- --------------------
            sqlC.ProcesosProductivos_D(en.IdProcesoProductivo, en.IdProductoProceso)
      End Select
   End Sub
   Private Sub CargarUno(o As MRPProcesoProductivo, dr As DataRow)
      With o
         .IdProcesoProductivo = dr.Field(Of Long)(MRPProcesoProductivo.Columnas.IdProcesoProductivo.ToString())
         .IdProductoProceso = dr.Field(Of String)(MRPProcesoProductivo.Columnas.IdProductoProceso.ToString())
         .NombreProducto = dr.Field(Of String)("NombreProducto")
         .CodigoProcesoProductivo = dr.Field(Of String)(MRPProcesoProductivo.Columnas.CodigoProcesoProductivo.ToString())
         .DescripcionProceso = dr.Field(Of String)(MRPProcesoProductivo.Columnas.DescripcionProceso.ToString())

         .CostoManoObraInterna = dr.Field(Of Decimal)(MRPProcesoProductivo.Columnas.CostoManoObraInterna.ToString())
         .CostoManoObraExterna = dr.Field(Of Decimal)(MRPProcesoProductivo.Columnas.CostoManoObraExterna.ToString())
         .CostoMateriaPrima = dr.Field(Of Decimal)(MRPProcesoProductivo.Columnas.CostoMateriaPrima.ToString())
         .CostoTotalProceso = dr.Field(Of Decimal)(MRPProcesoProductivo.Columnas.CostoTotalProceso.ToString())

         .FechaAltaProceso = dr.Field(Of Date)(MRPProcesoProductivo.Columnas.FechaAltaProceso.ToString())
         .FechaModificaProceso = dr.Field(Of Date)(MRPProcesoProductivo.Columnas.FechaModificaProceso.ToString())
         .FechaActualizaCostos = dr.Field(Of Date)(MRPProcesoProductivo.Columnas.FechaActualizaCostos.ToString())

         .TiempoTotalProceso = dr.Field(Of Decimal)(MRPProcesoProductivo.Columnas.TiempoTotalProceso.ToString())

         .TotalTiempoProceso = TimeSpan.FromHours(dr.Field(Of Decimal)(MRPProcesoProductivo.Columnas.TiempoTotalProceso.ToString()))

         .IdArchivoAdjunto = dr.Field(Of Integer?)(MRPProcesoProductivo.Columnas.IdArchivoAdjunto.ToString())

         .RespetaOrden = dr.Field(Of Boolean)(MRPProcesoProductivo.Columnas.RespetaOrden.ToString())
         .Activo = dr.Field(Of Boolean)(MRPProcesoProductivo.Columnas.Activo.ToString())

         .Operaciones = New Reglas.MRPProcesosProductivosOperaciones(da).GetTodas(dr.Field(Of Long)(MRPProcesoProductivo.Columnas.IdProcesoProductivo.ToString()))
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idProcesoProductivo As Long, idProductoProceso As String) As MRPProcesoProductivo
      Return GetUno(idProcesoProductivo, idProductoProceso, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idProcesoProductivo As Long, idProductoProceso As String, accion As AccionesSiNoExisteRegistro) As Entidades.MRPProcesoProductivo
      Return CargaEntidad(New SqlServer.MRPProcesosProductivos(Me.da).ProcesosProductivos_G1(idProcesoProductivo, idProductoProceso),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPProcesoProductivo(),
                          accion, Function() String.Format("No existe Proceso Productivo con Id: {0} para Producto {1}", idProcesoProductivo, idProductoProceso))
   End Function
   Public Function GetTodos() As List(Of Entidades.MRPProcesoProductivo)
      Return CargaLista(New SqlServer.MRPProcesosProductivos(Me.da).ProcesosProductivos_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPProcesoProductivo())
   End Function

   Public Function GetPorCodigoPP(codigoProcesoProductivo As String) As DataTable
      Return New SqlServer.MRPProcesosProductivos(Me.da).ProcesosProductivos_GAC(codigoProcesoProductivo, codigoProcesoProductivoExacto:=True)
   End Function
   Public Function GetCodigoMaximo() As Long
      Return New SqlServer.MRPProcesosProductivos(Me.da).GetCodigoMaximo()
   End Function

   Public Function ExisteAdjunto(idProductoProceso As String, idItemAdjunto As Integer) As Boolean
      Return New SqlServer.MRPProcesosProductivos(Me.da).ExisteAdjunto(idProductoProceso, idItemAdjunto)
   End Function

   Public Function GetProcesosProductivosCostos(idProducto As String,
                                                marcas As Entidades.Marca(), rubros As Entidades.Rubro(),
                                                subrubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro()) As DataTable

      Return New SqlServer.MRPProcesosProductivos(da).GetProcesosProductivosCostos(idProducto, marcas, rubros, subrubros, subSubRubros)

   End Function


   Public Function GetPorCodigo(codigoProcesoProductivo As String) As DataTable
      Return New SqlServer.MRPProcesosProductivos(da).ProcesosProductivos_GAC(codigoProcesoProductivo, codigoProcesoProductivoExacto:=False)
   End Function
   Public Function GetPorDescripcion(descripcionProcesoProductivo As String) As DataTable
      Return New SqlServer.MRPProcesosProductivos(da).ProcesosProductivos_GA_PorDescripcionBusqueda(descripcionProcesoProductivo, descripcionProcesoProductivoExacto:=False)
   End Function


#End Region

End Class