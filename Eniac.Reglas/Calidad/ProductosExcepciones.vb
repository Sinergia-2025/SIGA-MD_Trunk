#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class ProductosExcepciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ProductosExcepciones"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ProductosExcepciones"
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
         Dim en As Entidades.ProductoExcepcion = DirectCast(entidad, Entidades.ProductoExcepcion)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ProductosExcepciones = New SqlServer.ProductosExcepciones(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.ProductosExcepciones_I(en.IdProducto, en.IdExcepcion, en.fecha, en.IdUsuario)
            Case TipoSP._U
               sqlC.ProductosExcepciones_U(en.IdProducto, en.IdExcepcion)
            Case TipoSP._D
               sqlC.ProductosExcepciones_D(en.IdExcepcion)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ProductoExcepcion, ByVal dr As DataRow)
      With o
         .IdProducto = dr(Entidades.ProductoExcepcion.Columnas.IdProducto.ToString()).ToString()
         .IdExcepcion = Integer.Parse(dr(Entidades.ProductoExcepcion.Columnas.IdExcepcion.ToString()).ToString())
         .NombreProducto = dr(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString()
         .IdUsuario = dr(Entidades.ListaControlModelo.Columnas.Idusuario.ToString()).ToString()
         .fecha = Date.Parse(dr(Entidades.ListaControlModelo.Columnas.fecha.ToString()).ToString())
         '.Orden = Integer.Parse(dr(Entidades.ListaControl.Columnas.Orden.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Overloads Sub Borrar(IdExcepcion As Integer)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ProductosExcepciones = New SqlServer.ProductosExcepciones(da)
         sqlC.ProductosExcepciones_D(IdExcepcion)

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Overloads Sub Insertar(ProductosExcepciones As List(Of Entidades.ProductoExcepcion))
      For Each Item As Entidades.ProductoExcepcion In ProductosExcepciones
         Me.EjecutaSP(Item, TipoSP._I)
      Next
   End Sub


   Public Function GetTodas(IdExcepcion As Integer) As List(Of Entidades.ProductoExcepcion)
      Dim dt As DataTable = New SqlServer.ProductosExcepciones(da).ProductosExcepciones_GA(IdExcepcion)
      Dim o As Entidades.ProductoExcepcion
      Dim oLis As List(Of Entidades.ProductoExcepcion) = New List(Of Entidades.ProductoExcepcion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ProductoExcepcion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetExcepcionesxProducto(IdProducto As String) As DataTable
      Dim dt As DataTable = New SqlServer.ProductosExcepciones(da).ProductosExcepciones_GxProducto(IdProducto)
      Return dt
   End Function


   Public Sub Guardar(dtProductosExcepciones As Entidades.ListConBorrados(Of Entidades.ProductoExcepcion))
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql As SqlServer.ProductosExcepciones = New SqlServer.ProductosExcepciones(da)
         'Dim sql2 As SqlServer.ListasControlProductosItems = New SqlServer.ListasControlProductosItems(da)
         'Dim sql3 As Reglas.ListasControlConfig = New Reglas.ListasControlConfig(da)
         'Dim ListaItems As List(Of Entidades.ListaControlConfig) = New List(Of Entidades.ListaControlConfig)
         ' Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
         'Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
         ' Dim dtAudit As DataTable = New DataTable()
         ' Dim OperacAudit As Entidades.OperacionesAuditorias
         'Dim ListaControlItems As DataTable
         Dim Productos As DataTable
         ' Dim oCal As Reglas.ListasControlProductosItems = New Reglas.ListasControlProductosItems(da)
         Dim oLC As Reglas.ProductosExcepciones = New Reglas.ProductosExcepciones(da)

         If dtProductosExcepciones IsNot Nothing Then

            'BAJAS
            For Each lista As Entidades.ProductoExcepcion In dtProductosExcepciones.Borrados

               ' ListaControlItems = oCal.GetListasControlxProductoListaControl(lista.IdProductoModelo, lista.IdListaControl)

               'If ListaControlItems.Rows.Count <> 0 Then
               '   OperacAudit = Entidades.OperacionesAuditorias.Baja

               '   rAudit.Insertar("CalidadListasControlProductos", OperacAudit, actual.Nombre,
               '                                    String.Format("{0} = '{1}' AND {2} = {3} ",
               '                                   Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
               '                                  lista.IdProducto, Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
               '                                   lista.IdListaControl))

               '   For Each dr As DataRow In ListaControlItems.Rows

               '      rAudit.Insertar("CalidadListasControlProductosItems", OperacAudit, actual.Nombre,
               '                 String.Format("{0} = '{1}' AND {2} = {3} AND {4} = {5} ",
               '                Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
               '               dr(Entidades.ListaControlProducto.Columnas.IdProducto.ToString()).ToString(),
               '                Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
               '               dr("IdListaControl").ToString(),
               '                Entidades.ListaControlProductoItem.Columnas.Item.ToString(),
               '                 dr("Item").ToString()))

               '   Next
               'End If

               'sql2.ListasControlProductosItems_D(lista.IdProducto, lista.IdListaControl)

               sql.ProductosExcepciones_D(lista.IdProducto, lista.IdExcepcion)
            Next

            'ALTAS
            For Each lista As Entidades.ProductoExcepcion In dtProductosExcepciones

               'controlar si la lista ya existe no hace nada!!!

               Productos = oLC.GetProductoxExcepcion(lista.IdProducto, lista.IdExcepcion)

               If Productos.Rows.Count = 0 Then

                  'OperacAudit = Entidades.OperacionesAuditorias.Alta
                  'Lista NUEVA
                  sql.ProductosExcepciones_I(lista.IdProducto, lista.IdExcepcion, lista.fecha, lista.IdUsuario)


                  'rAudit.Insertar("CalidadListasControlProductos", OperacAudit, actual.Nombre,
                  '            String.Format("{0} = '{1}' AND {2} = {3} ",
                  '           Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                  '          lista.IdProducto, Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                  '           lista.IdListaControl))


                  'ListaItems = sql3.GetTodas(lista.IdListaControl)


                  'For Each item As Entidades.ListaControlConfig In ListaItems

                  '   sql2.ListasControlProductosItems_I(lista.IdProducto,
                  '                                       item.IdListaControl, item.Item, item.IdListaControlItem, False, False, False, False, False, "",
                  '                                       item.Orden, actual.Nombre, DateTime.Now(), False, False, False, False, False, "", actual.Nombre, DateTime.Now())



                  '   rAudit.Insertar("CalidadListasControlProductosItems", OperacAudit, actual.Nombre,
                  '              String.Format("{0} = '{1}' AND {2} = {3} AND {4} = {5} ",
                  '             Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                  '           lista.IdProducto, Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                  '            item.IdListaControl,
                  '             Entidades.ListaControlProductoItem.Columnas.Item.ToString(),
                  '             item.Item))

                  'Next
                  'Else

                  'ListaControlItems = oCal.GetListasControlxProductoListaControl(lista.IdProducto, lista.IdListaControl)

                  'If ListaControlItems.Rows.Count = 0 Then


                  '   OperacAudit = Entidades.OperacionesAuditorias.Alta

                  '   ListaItems = sql3.GetTodas(lista.IdListaControl)


                  'For Each item As Entidades.ListaControlConfig In ListaItems

                  '   sql2.ListasControlProductosItems_I(lista.IdProducto,
                  '                                       item.IdListaControl, item.Item, item.IdListaControlItem, False, False, False, False, False, "",
                  '                                       item.Orden, actual.Nombre, DateTime.Now(), False, False, False, False, False, "", actual.Nombre, DateTime.Now())



                  '   rAudit.Insertar("CalidadListasControlProductosItems", OperacAudit, actual.Nombre,
                  '              String.Format("{0} = '{1}' AND {2} = {3} AND {4} = {5} ",
                  '             Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                  '           lista.IdProducto, Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                  '            item.IdListaControl,
                  '             Entidades.ListaControlProductoItem.Columnas.Item.ToString(),
                  '             item.Item))

                  'Next

                  'End If

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

   Public Function GetProductoxExcepcion(IdProducto As String, idExcepcion As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ProductosExcepciones(da).ProductosExcepciones_G1(IdProducto, idExcepcion)
      Return dt
   End Function

   Public Function GetListasControlInforme(Idproducto As String, Responsable As String, FechaDesde As DateTime?, FechaHasta As DateTime?,
                                                 IdExcepcion As Integer, IdListaControTipo As Integer, IdExcepcionTipo As Integer,
                                                 Departamento As String) As DataTable
      Dim dt As DataTable = New SqlServer.ProductosExcepciones(da).ProductosExcepciones_GInforme(Idproducto, Responsable, FechaDesde, FechaHasta,
                                                   IdExcepcion, IdListaControTipo, IdExcepcionTipo, Departamento)
      Return dt
   End Function

#End Region

End Class