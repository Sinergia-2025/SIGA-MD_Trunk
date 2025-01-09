#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class ListasControlProductosItems
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ListasControlProductosItems"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ListasControlProductosItems"
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


#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.ListaControlProductoItem = DirectCast(entidad, Entidades.ListaControlProductoItem)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ListasControlProductosItems = New SqlServer.ListasControlProductosItems(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.ListasControlProductosItems_I(en.IdProducto, en.IdListaControl, en.Item, en.IdListaControlItem,
                                                  en.Ok, en.NoOk, en.Obs, en.Mat, en.NA, en.Observ, en.Orden, en.Usuario,
                                                  en.FechaMod, en.OkCalidad, en.NoOkCalidad, en.ObsCalidad, en.MatCalidad,
                                                  en.NACalidad, en.ObservCalidad, en.UsuarioCalidad, en.FechaModCalidad)
            Case TipoSP._U
               sqlC.ListasControlProductosItems_U(en.IdProducto, en.IdListaControl, en.Item, en.IdListaControlItem,
                                                  en.Ok, en.NoOk, en.Obs, en.Mat, en.NA, en.Observ, en.Orden, en.Usuario,
                                                  en.FechaMod, en.OkCalidad, en.NoOkCalidad, en.ObsCalidad, en.MatCalidad,
                                                  en.NACalidad, en.ObservCalidad, en.UsuarioCalidad, en.FechaModCalidad)
            Case TipoSP._D
               sqlC.ListasControlProductosItems_D(en.IdProducto)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ListaControlProductoItem, ByVal dr As DataRow)
      With o
         .IdProducto = dr(Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString()).ToString()
         .IdListaControl = Integer.Parse(dr(Entidades.ListaControlProductoItem.Columnas.IdListaControl.ToString()).ToString())

         ' .IdUsuario = dr(Entidades.ListaControlProductoItem.Columnas.Idusuario.ToString()).ToString()


      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Overloads Sub Borrar(idProducto As String, IdListaControl As Integer)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ListasControlProductosItems = New SqlServer.ListasControlProductosItems(da)
         sqlC.ListasControlProductosItems_D(idProducto)

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Overloads Sub Insertar(ListasControlProductosItems As List(Of Entidades.ListaControlProductoItem))
      For Each Item As Entidades.ListaControlProductoItem In ListasControlProductosItems
         Me.EjecutaSP(Item, TipoSP._I)
      Next
   End Sub


   Public Function GetTodas(IdProducto As String) As List(Of Entidades.ListaControlProductoItem)
      Dim dt As DataTable = New SqlServer.ListasControlProductosItems(da).ListasControlProductosItems_GA(IdProducto)
      Dim o As Entidades.ListaControlProductoItem
      Dim oLis As List(Of Entidades.ListaControlProductoItem) = New List(Of Entidades.ListaControlProductoItem)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ListaControlProductoItem()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetListasControlxProducto(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                                IdestadoCalidad As Integer, Liberado As Boolean,
                                                Entregado As Boolean) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductosItems(da).ListasControlProductosItems_GItemsxProducto(idProducto, FechaDesde, FechaHasta, IdestadoCalidad, Liberado, Entregado)
      Return dt
   End Function

   Public Function GetListasControlxProductoPendientes(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                              IdListaControl As Integer, Liberado As Boolean,
                                              Entregado As Boolean, IdCliente As Long, Situacion As String,
                                              IdEstado As Integer, Ubicacion As String, Items As List(Of String),
                                              IdListaControlTipo As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductosItems(da).ListasControlProductosItems_GItemsxProductoPendientes(idProducto, FechaDesde, FechaHasta,
                                                                                                                                IdListaControl, Liberado, Entregado,
                                                                                                                                IdCliente, Situacion, IdEstado, Ubicacion,
                                                                                                                                Items, IdListaControlTipo)
      Return dt
   End Function

   Public Function GetListasControlxProductoPendientesAuditoria(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                            IdListaControl As Integer, Liberado As Boolean,
                                            Entregado As Boolean, IdCliente As Long, Situacion As String, IdEstado As Integer, Ubicacion As String, itemSeleccionado As String) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductosItems(da).ListasControlProductosItems_GItemsxProductoPendientesAuditoria(idProducto, FechaDesde, FechaHasta,
                                                                                                                                IdListaControl, Liberado, Entregado,
                                                                                                                                IdCliente, Situacion, IdEstado, Ubicacion, itemSeleccionado)
      Return dt
   End Function

   Public Function GetInformeDeMaterialesFaltantes(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                            IdListaControl As Integer, Liberado As Boolean,
                                            Entregado As Boolean, IdCliente As Long, Situacion As String, IdEstado As Integer, Ubicacion As String, itemSeleccionado As String) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductosItems(da).ListasControlProductosItems_GInformeDeMaterialesFaltantes(idProducto, FechaDesde, FechaHasta,
                                                                                                                                IdListaControl, Liberado, Entregado,
                                                                                                                                IdCliente, Situacion, IdEstado, Ubicacion, itemSeleccionado)
      Return dt
   End Function

   Public Function GetListasControlxProductoRoles(IdProducto As String, Roles As DataTable) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductosItems(da).ListasControlProductosItems_GxRoles(IdProducto, Roles)
      Return dt
   End Function

   Public Function GetListasControlxProducto_Auditoria(IdProducto As String) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductosItems(da).ListasControlProductosItems_GetAuditoria(IdProducto)
      Return dt
   End Function

   Public Function GetListasControlxProducto_InformeAuditoria(IdProducto As String, IdListaControl As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductosItems(da).ListasControlProductosItems_GetInformeAuditoria(IdProducto, IdListaControl)
      Return dt
   End Function

   Public Function GetListasControlxProductoListaControl(IdProducto As String, IdListaControl As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductosItems(da).ListasControlProductosItems_GxProductoListaControl(IdProducto, IdListaControl)
      Return dt
   End Function
   Public Function GetListaControlProductoItemsOK(IdProducto As String, IdListaControl As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductosItems(da).ListasControlProductosItems_GListaControlProductoItemsOK(IdProducto, IdListaControl)
      Return dt
   End Function
   Public Function GetListaControlProductoItemsOKProd(IdProducto As String, IdListaControl As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductosItems(da).ListasControlProductosItems_GListaControlProductoItemsOKProd(IdProducto, IdListaControl)
      Return dt
   End Function

   Public Sub Guardar(Producto As Entidades.Producto, dtListasControlProductosItems As DataTable, ListasControl As Entidades.ListaControlProducto, ListaControlSiguiente As Entidades.ListaControlProducto)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlPro As Reglas.Productos = New Reglas.Productos(da)
         Dim sql As SqlServer.ListasControlProductosItems = New SqlServer.ListasControlProductosItems(da)
         Dim sql2 As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)
         Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
         Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
         Dim dtAudit As DataTable = New DataTable()
         Dim OperacAudit As Entidades.OperacionesAuditorias

         '    sqlPro.ActualizaCalidad(Producto, 0)

         sql2.ListasControlProductos_U(Producto.IdProducto, ListasControl.IdListaControl, ListasControl.FecIngreso,
                                       ListasControl.FecEgreso, ListasControl.CincoS, ListasControl.CincoSComment, ListasControl.CincoSC,
                                       ListasControl.CincoSCommentC, ListasControl.CincoSUsr, ListasControl.CincoSFecha, ListasControl.CincoSUsrC,
                                       ListasControl.CincoSFechaC, ListasControl.IdUsuario, True, ListasControl.IdEstadoCalidad,
                                       ListasControl.Observacion)

         If ListaControlSiguiente IsNot Nothing Then
            sql2.ListasControlProductos_U(Producto.IdProducto, ListaControlSiguiente.IdListaControl, ListaControlSiguiente.FecIngreso,
                                      ListaControlSiguiente.FecEgreso, ListaControlSiguiente.CincoS, ListaControlSiguiente.CincoSComment, ListaControlSiguiente.CincoSC,
                                      ListaControlSiguiente.CincoSCommentC, ListaControlSiguiente.CincoSUsr, ListaControlSiguiente.CincoSFecha, ListaControlSiguiente.CincoSUsrC,
                                      ListaControlSiguiente.CincoSFechaC, ListaControlSiguiente.IdUsuario, True, ListaControlSiguiente.IdEstadoCalidad,
                                      ListaControlSiguiente.Observacion)
         End If

         dtAudit = sqlAudit.Auditorias_G1("CalidadListasControlProductos", String.Format("{0} = '{1}' AND {2} = {3} ",
                                                                                    Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                                                                                 Producto.IdProducto,
                                                                                 Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                                                                                 ListasControl.IdListaControl))

         'Si no tiene registro es porque se borro el alta en la auditoria (podria pasar en la implementacion inicial)
         If dtAudit.Rows.Count > 0 Then
            OperacAudit = Entidades.OperacionesAuditorias.Modificacion
         Else
            OperacAudit = Entidades.OperacionesAuditorias.Alta
         End If

         rAudit.Insertar("CalidadListasControlProductos", OperacAudit, actual.Nombre,
                         String.Format("{0} = '{1}' AND {2} = {3} ",
                        Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                        Producto.IdProducto,
                        Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                        ListasControl.IdListaControl))



         For Each drListaControlProductoItem As DataRow In dtListasControlProductosItems.Rows

            If Not String.IsNullOrEmpty(drListaControlProductoItem("Modif").ToString()) Then


               sql.ListasControlProductosItems_U(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString()).ToString(),
                                                Integer.Parse(drListaControlProductoItem(Entidades.ListaControlProducto.Columnas.IdListaControl.ToString()).ToString()),
                                                Integer.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.Item.ToString()).ToString()),
                                                 Integer.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.IdListaControlItem.ToString()).ToString()),
                                                 Boolean.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.Ok.ToString()).ToString()),
                                                 Boolean.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.NoOk.ToString()).ToString()),
                                                 Boolean.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.Obs.ToString()).ToString()),
                                                 Boolean.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.Mat.ToString()).ToString()),
                                                 Boolean.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.NA.ToString()).ToString()),
                                                 drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.Observ.ToString()).ToString(),
                                                 Integer.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.Orden.ToString()).ToString()),
                                                  drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.Usuario.ToString()).ToString(),
                                               DateTime.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.FechaMod.ToString()).ToString()),
                                                 Boolean.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.OkCalidad.ToString()).ToString()),
                                                Boolean.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.NoOkCalidad.ToString()).ToString()),
                                                 Boolean.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.ObsCalidad.ToString()).ToString()),
                                                Boolean.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.MatCalidad.ToString()).ToString()),
                                                Boolean.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.NACalidad.ToString()).ToString()),
                                                drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.ObservCalidad.ToString()).ToString(),
                                                drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.Usuario.ToString()).ToString(),
                                                DateTime.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.FechaMod.ToString()).ToString()))


               dtAudit = sqlAudit.Auditorias_G1("CalidadListasControlProductosItems", String.Format("{0} = '{1}' AND {2} = {3} AND {4} = {5}",
                                                                                          Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                                                                                       drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString()).ToString(),
                                                                                       Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                                                                                       Integer.Parse(drListaControlProductoItem(Entidades.ListaControlProducto.Columnas.IdListaControl.ToString()).ToString()),
                                                                                       Entidades.ListaControlProductoItem.Columnas.Item.ToString(),
                                                                                       Integer.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.Item.ToString()).ToString())))

               'Si no tiene registro es porque se borro el alta en la auditoria (podria pasar en la implementacion inicial)
               If dtAudit.Rows.Count > 0 Then
                  OperacAudit = Entidades.OperacionesAuditorias.Modificacion
               Else
                  OperacAudit = Entidades.OperacionesAuditorias.Alta
               End If

               rAudit.Insertar("CalidadListasControlProductosItems", OperacAudit, actual.Nombre,
                               String.Format("{0} = '{1}' AND {2} = {3} AND {4} = {5}",
                              Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                              drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString()).ToString(),
                              Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                              Integer.Parse(drListaControlProductoItem(Entidades.ListaControlProducto.Columnas.IdListaControl.ToString()).ToString()),
                              Entidades.ListaControlProductoItem.Columnas.Item.ToString(),
                              Integer.Parse(drListaControlProductoItem(Entidades.ListaControlProductoItem.Columnas.Item.ToString()).ToString())))

            End If
         Next

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Sub GuardarListaControl(Producto As Entidades.Producto, ListasControl As Entidades.ListaControlProducto)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlPro As Reglas.Productos = New Reglas.Productos(da)
         Dim sql As SqlServer.ListasControlProductosItems = New SqlServer.ListasControlProductosItems(da)
         Dim sql2 As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)
         Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
         Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
         Dim dtAudit As DataTable = New DataTable()
         Dim OperacAudit As Entidades.OperacionesAuditorias

         '    sqlPro.ActualizaCalidad(Producto, 0)

         sql2.ListasControlProductos_U(Producto.IdProducto, ListasControl.IdListaControl, ListasControl.FecIngreso,
                                       ListasControl.FecEgreso, ListasControl.CincoS, ListasControl.CincoSComment, ListasControl.CincoSC,
                                       ListasControl.CincoSCommentC, ListasControl.CincoSUsr, ListasControl.CincoSFecha, ListasControl.CincoSUsrC,
                                       ListasControl.CincoSFechaC, ListasControl.IdUsuario, True, ListasControl.IdEstadoCalidad,
                                       ListasControl.Observacion)


         dtAudit = sqlAudit.Auditorias_G1("CalidadListasControlProductos", String.Format("{0} = '{1}' AND {2} = {3} ",
                                                                                    Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                                                                                 Producto.IdProducto,
                                                                                 Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                                                                                 ListasControl.IdListaControl))

         'Si no tiene registro es porque se borro el alta en la auditoria (podria pasar en la implementacion inicial)
         If dtAudit.Rows.Count > 0 Then
            OperacAudit = Entidades.OperacionesAuditorias.Modificacion
         Else
            OperacAudit = Entidades.OperacionesAuditorias.Alta
         End If

         rAudit.Insertar("CalidadListasControlProductos", OperacAudit, actual.Nombre,
                         String.Format("{0} = '{1}' AND {2} = {3} ",
                        Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                        Producto.IdProducto,
                        Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                        ListasControl.IdListaControl))


         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub
#End Region

End Class