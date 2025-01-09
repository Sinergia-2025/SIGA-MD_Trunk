#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class TiposListasProductosProgramacion
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TipoListaProductoProgramacion"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TipoListaProductoProgramacion"
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
   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sExcepciones As SqlServer.TiposListasProductosProgramacion = New SqlServer.TiposListasProductosProgramacion(da)
      Return sExcepciones.TiposListasProductosProgramacion_GA()
   End Function



#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.TipoListaProductoProgramacion = DirectCast(entidad, Entidades.TipoListaProductoProgramacion)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.TiposListasProductosProgramacion = New SqlServer.TiposListasProductosProgramacion(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.TiposListasProductosProgramacion_I(en.IdListaControlTipo, en.Dia, en.IdProducto, en.IdUsuario, en.FechaModificacion)
            Case TipoSP._U
               sqlC.TiposListasProductosProgramacion_U(en.IdListaControlTipo, en.Dia, en.IdProducto, en.IdUsuario, en.FechaModificacion)
            Case TipoSP._D
               sqlC.TiposListasProductosProgramacion_D(en.IdListaControlTipo, en.Dia, en.IdProducto)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TipoListaProductoProgramacion, ByVal dr As DataRow)
      With o
         .IdListaControlTipo = Integer.Parse(dr(Entidades.TipoListaProductoProgramacion.Columnas.IdListaControlTipo.ToString()).ToString())
         .Dia = Date.Parse(dr(Entidades.TipoListaProductoProgramacion.Columnas.Dia.ToString()).ToString())
         .IdProducto = dr(Entidades.TipoListaProductoProgramacion.Columnas.IdProducto.ToString()).ToString()
         .IdUsuario = dr(Entidades.TipoListaProductoProgramacion.Columnas.IdUsuario.ToString()).ToString()
         .FechaModificacion = DateTime.Parse(dr(Entidades.TipoListaProductoProgramacion.Columnas.FechaModificacion.ToString()).ToString())
         .NombreProducto = dr(Entidades.TipoListaProductoProgramacion.Columnas.NombreProducto.ToString()).ToString()
         .NombreProductoModeloTipo = dr(Entidades.TipoListaProductoProgramacion.Columnas.NombreProductoModeloTipo.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Function GetUno(IdListaControlTipo As Integer, Dia As Date, IdProducto As String) As Entidades.TipoListaProductoProgramacion
      Dim sMetas As SqlServer.TiposListasProductosProgramacion = New SqlServer.TiposListasProductosProgramacion(da)
      Return CargaEntidad(sMetas.TiposListasProductosProgramacion_G1(IdListaControlTipo, Dia, IdProducto),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoListaProductoProgramacion(),
                    AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existe la Meta {0}", Dia))
   End Function

   Public Function _GetUno(IdListaControlTipo As Integer, Dia As Date, IdProducto As String) As DataTable
      Dim sMetas As SqlServer.TiposListasProductosProgramacion = New SqlServer.TiposListasProductosProgramacion(da)
      Return sMetas.TiposListasProductosProgramacion_G1(IdListaControlTipo, Dia, IdProducto)
   End Function


   Public Function GetTodas() As List(Of Entidades.TipoListaProductoProgramacion)
      Dim dt As DataTable = New SqlServer.TiposListasProductosProgramacion(da).TiposListasProductosProgramacion_GA()
      Dim o As Entidades.TipoListaProductoProgramacion
      Dim oLis As List(Of Entidades.TipoListaProductoProgramacion) = New List(Of Entidades.TipoListaProductoProgramacion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoListaProductoProgramacion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetProgramacionSeccion(IdListaControlTipo As Integer, Dia As Date) As List(Of Entidades.TipoListaProductoProgramacion)
      Dim dt As DataTable = New SqlServer.TiposListasProductosProgramacion(da).TiposListasProductosProgramacion_GProgramacionTipoLista(IdListaControlTipo, Dia)
      Dim o As Entidades.TipoListaProductoProgramacion
      Dim oLis As List(Of Entidades.TipoListaProductoProgramacion) = New List(Of Entidades.TipoListaProductoProgramacion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoListaProductoProgramacion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function



   Public Function GetMetas(fechaDesde As Date, fechaHasta As Date) As System.Data.DataTable
      Dim sExcepciones As SqlServer.TiposListasMetas = New SqlServer.TiposListasMetas(da)
      Return sExcepciones.TiposListasMetas_GMetas(fechaDesde, fechaHasta)
   End Function

   Public Function GetTotalMetasPorDia(IdListaControlTipo As Integer, fechaDesde As Date, IdProductoModeloTipo As Integer) As DataTable
      Dim sExcepciones As SqlServer.TiposListasProductosProgramacion = New SqlServer.TiposListasProductosProgramacion(da)
      Return sExcepciones.TiposListasProductosProgramacion_GxTipoModelo(IdListaControlTipo, fechaDesde, IdProductoModeloTipo)
   End Function

   Public Function GetTotalMetasPorMes(IdListaControlTipo As Integer, fechaDesde As Date, fechaHasta As Date, IdProductoModeloTipo As Integer) As Integer
      Dim sExcepciones As SqlServer.TiposListasProductosProgramacion = New SqlServer.TiposListasProductosProgramacion(da)
      Return sExcepciones.TiposListasProductosProgramacion_GMetasTotalPorMes(IdListaControlTipo, fechaDesde, fechaHasta, IdProductoModeloTipo)
   End Function

   Public Sub Guardar(dtProductosExcepciones As Entidades.ListConBorrados(Of Entidades.TipoListaProductoProgramacion))
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql As SqlServer.TiposListasProductosProgramacion = New SqlServer.TiposListasProductosProgramacion(da)
         Dim Productos As DataTable
         Dim oLC As Reglas.TiposListasProductosProgramacion = New Reglas.TiposListasProductosProgramacion(da)

         If dtProductosExcepciones IsNot Nothing Then

            'BAJAS
            For Each lista As Entidades.TipoListaProductoProgramacion In dtProductosExcepciones.Borrados

               sql.TiposListasProductosProgramacion_D(lista.IdListaControlTipo, lista.Dia, lista.IdProducto)
            Next

            'ALTAS
            For Each lista As Entidades.TipoListaProductoProgramacion In dtProductosExcepciones

               'controlar si la lista ya existe no hace nada!!!

               Productos = oLC._GetUno(lista.IdListaControlTipo, lista.Dia, lista.IdProducto)

               If Productos.Rows.Count = 0 Then

                  'OperacAudit = Entidades.OperacionesAuditorias.Alta
                  'Lista NUEVA
                  sql.TiposListasProductosProgramacion_I(lista.IdListaControlTipo, lista.Dia, lista.IdProducto,
                                                         lista.IdUsuario, lista.FechaModificacion)

               End If

            Next

         End If


         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub
   Public Class GetPanelProgramacionProduccionPivotInfo
      Public Property dtColumnas As DataTable
      Public Property dtResult As DataTable
   End Class
   Public Function GetPanelProgramacionProduccion(idProducto As String, fechaDesde As DateTime?, fechaHasta As DateTime?,
                                                     fechaDesdeLiberado As DateTime?, fechaHastaLiberado As DateTime?,
                                                    idestadoCalidad As Integer, idCliente As Long, ubicacion As String,
                                                    liberados As Entidades.Publicos.SiNoTodos,
                                                    entregados As Entidades.Publicos.SiNoTodos,
                                                    liberadosPDI As Entidades.Publicos.SiNoTodos,
                                                     IdProductoModeloTipo As Integer) As GetPanelProgramacionProduccionPivotInfo

      Dim sql As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)

      Dim pivotcolName As StringBuilder = New StringBuilder()
      Dim sumPivot As StringBuilder = New StringBuilder()
      Dim pivotcolName2 As StringBuilder = New StringBuilder()
      Dim sumPivot2 As StringBuilder = New StringBuilder()
      Dim pivotcolName3 As StringBuilder = New StringBuilder()
      Dim sumPivot3 As StringBuilder = New StringBuilder()

      Dim dtColumnas As DataTable = sql.GetEstadosPorListasControlTipo_ColumnasPivot(idProducto)
      Dim dtColumnas2 As DataTable = sql.GetEstadosPorListasControlTipoEstado_ColumnasPivot(idProducto)
      Dim dtColumnas3 As DataTable = sql.GetLeadTimePorListasControlTipo_ColumnasPivot(idProducto)


      If dtColumnas.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Tipos de Listas para estos filtros.")
      End If


      If dtColumnas2.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Estados para estos filtros.")
      End If

      Dim primero As Boolean = True
      For Each drColumna As DataRow In dtColumnas.Rows
         If Not primero Then
            pivotcolName.Append(",")
            sumPivot.Append(",")
         End If
         pivotcolName.AppendFormat("[{0}]", drColumna("NombreColumma"))
         sumPivot.AppendFormat("MIN([{0}]) as [{0}]", drColumna("NombreColumma"))
         primero = False
      Next
      Return New GetPanelProgramacionProduccionPivotInfo() _
          With {.dtColumnas = dtColumnas,
          .dtResult = New SqlServer.TiposListasProductosProgramacion(da).GetPanelProgramacionProduccion(idProducto, fechaDesde, fechaHasta,
                                                                                            fechaDesdeLiberado, fechaHastaLiberado,
                                                                                              idestadoCalidad, idCliente, ubicacion,
                                                                                              liberados, entregados, liberadosPDI, IdProductoModeloTipo,
                                                                                              pivotcolName.ToString(), sumPivot.ToString(),
                                                                                              pivotcolName2.ToString(), sumPivot2.ToString(),
                                                                                              pivotcolName3.ToString(), sumPivot3.ToString())}
   End Function

   Public Function GetPanelProgramacionProduccionxFechas(idProducto As String, fechaDesde As DateTime?, fechaHasta As DateTime?,
                                                    fechaDesdeLiberado As DateTime?, fechaHastaLiberado As DateTime?,
                                                   idestadoCalidad As Integer, idCliente As Long, ubicacion As String,
                                                   liberados As Entidades.Publicos.SiNoTodos,
                                                   entregados As Entidades.Publicos.SiNoTodos,
                                                   liberadosPDI As Entidades.Publicos.SiNoTodos,
                                                    IdProductoModeloTipo As Integer) As GetPanelProgramacionProduccionPivotInfo

      Dim sql As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)

      Dim pivotcolName As StringBuilder = New StringBuilder()
      Dim sumPivot As StringBuilder = New StringBuilder()
      Dim pivotcolName2 As StringBuilder = New StringBuilder()
      Dim sumPivot2 As StringBuilder = New StringBuilder()
      Dim pivotcolName3 As StringBuilder = New StringBuilder()
      Dim sumPivot3 As StringBuilder = New StringBuilder()

      Dim dtColumnas As DataTable = sql.GetEstadosPorListasControlTipo_ColumnasPivot(idProducto)
      Dim dtColumnas2 As DataTable = sql.GetEstadosPorListasControlTipoEstado_ColumnasPivot(idProducto)
      Dim dtColumnas3 As DataTable = sql.GetLeadTimePorListasControlTipo_ColumnasPivot(idProducto)


      If dtColumnas.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Tipos de Listas para estos filtros.")
      End If


      If dtColumnas2.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Estados para estos filtros.")
      End If

      Dim primero As Boolean = True
      For Each drColumna As DataRow In dtColumnas.Rows
         If Not primero Then
            pivotcolName.Append(",")
            sumPivot.Append(",")
         End If
         pivotcolName.AppendFormat("[{0}]", drColumna("NombreColumma"))
         sumPivot.AppendFormat("MIN([{0}]) as [{0}]", drColumna("NombreColumma"))
         primero = False
      Next

      'Dim primero1 As Boolean = True
      'For Each drColumna As DataRow In dtColumnas2.Rows
      '   If Not primero1 Then
      '      pivotcolName2.Append(",")
      '      sumPivot2.Append(",")
      '   End If
      '   pivotcolName2.AppendFormat("[{0}]", drColumna("NombreColumma"))
      '   sumPivot2.AppendFormat("AVG([{0}]) as [{0}]", drColumna("NombreColumma"))
      '   primero1 = False
      'Next

      'Dim primero2 As Boolean = True
      'For Each drColumna As DataRow In dtColumnas3.Rows
      '   If Not primero2 Then
      '      pivotcolName3.Append(",")
      '      sumPivot3.Append(",")
      '   End If
      '   pivotcolName3.AppendFormat("[{0}]", drColumna("NombreColumma"))
      '   sumPivot3.AppendFormat("'' as [{0}]", drColumna("NombreColumma"))
      '   primero2 = False
      'Next

      Return New GetPanelProgramacionProduccionPivotInfo() _
          With {.dtColumnas = dtColumnas,
          .dtResult = New SqlServer.TiposListasProductosProgramacion(da).GetPanelProgramacionProduccionxFechas(idProducto, fechaDesde, fechaHasta,
                                                                                            fechaDesdeLiberado, fechaHastaLiberado,
                                                                                              idestadoCalidad, idCliente, ubicacion,
                                                                                              liberados, entregados, liberadosPDI, IdProductoModeloTipo,
                                                                                              pivotcolName.ToString(), sumPivot.ToString(),
                                                                                              pivotcolName2.ToString(), sumPivot2.ToString(),
                                                                                              pivotcolName3.ToString(), sumPivot3.ToString())}
   End Function

#End Region

End Class