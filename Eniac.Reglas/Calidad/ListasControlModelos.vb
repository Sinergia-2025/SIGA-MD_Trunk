﻿#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class ListasControlModelos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ListasControlModelos"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ListasControlModelos"
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
         Dim en As Entidades.ListaControlModelo = DirectCast(entidad, Entidades.ListaControlModelo)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ListasControlModelos = New SqlServer.ListasControlModelos(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.ListasControlModelos_I(en.IdProductoModelo, en.IdListaControl, en.fecha, en.IdUsuario)
            Case TipoSP._U
               sqlC.ListasControlModelos_U(en.IdProductoModelo, en.IdListaControl)
            Case TipoSP._D
               sqlC.ListasControlModelos_D(en.IdListaControl)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ListaControlModelo, ByVal dr As DataRow)
      With o
         .IdProductoModelo = Integer.Parse(dr(Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString()).ToString())
         .IdListaControl = Integer.Parse(dr(Entidades.ListaControlModelo.Columnas.IdListaControl.ToString()).ToString())
         .NombreListaControl = dr(Entidades.ListaControl.Columnas.NombreListaControl.ToString()).ToString()
         .IdUsuario = dr(Entidades.ListaControlModelo.Columnas.Idusuario.ToString()).ToString()
         .fecha = Date.Parse(dr(Entidades.ListaControlModelo.Columnas.fecha.ToString()).ToString())
         .Orden = Integer.Parse(dr(Entidades.ListaControl.Columnas.Orden.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Overloads Sub Borrar(IdListaControl As Integer)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ListasControlModelos = New SqlServer.ListasControlModelos(da)
         sqlC.ListasControlModelos_D(IdListaControl)

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Overloads Sub Insertar(ListasControlModelos As List(Of Entidades.ListaControlModelo))
      For Each Item As Entidades.ListaControlModelo In ListasControlModelos
         Me.EjecutaSP(Item, TipoSP._I)
      Next
   End Sub


   Public Function GetTodas(IdModelo As Integer) As List(Of Entidades.ListaControlModelo)
      Dim dt As DataTable = New SqlServer.ListasControlModelos(da).ListasControlModelos_GA(IdModelo)
      Dim o As Entidades.ListaControlModelo
      Dim oLis As List(Of Entidades.ListaControlModelo) = New List(Of Entidades.ListaControlModelo)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ListaControlModelo()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetRolesxListaControl(IdListaControl As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlRoles(da).ListasControlRoles_GA(IdListaControl)
      Return dt
   End Function

   'Public Sub Guardar(ListaControl As Entidades.ListaControl, dtListasControlRoles As DataTable)
   '   Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
   '   Try
   '      If blnAbreConexion Then da.OpenConection()
   '      If blnAbreConexion Then da.BeginTransaction()

   '      Dim sql As SqlServer.ListasControlRoles = New SqlServer.ListasControlRoles(da)
   '      sql.ListasControlRoles_D(ListaControl.IdListaControl)

   '      For Each drListaControlRol As DataRow In dtListasControlRoles.Rows
   '         sql.ListasControlRoles_I(Integer.Parse(drListaControlRol(Entidades.ListaControlRol.Columnas.IdListaControl.ToString()).ToString()),
   '                                  drListaControlRol(Entidades.ListaControlRol.Columnas.IdRol.ToString()).ToString())
   '      Next

   '      If blnAbreConexion Then da.CommitTransaction()
   '   Catch
   '      If blnAbreConexion Then da.RollbakTransaction()
   '      Throw
   '   Finally
   '      If blnAbreConexion Then da.CloseConection()
   '   End Try
   'End Sub

   Public Sub Guardar(dtListasControlModelos As Entidades.ListConBorrados(Of Entidades.ListaControlModelo))
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql As SqlServer.ListasControlModelos = New SqlServer.ListasControlModelos(da)
         'Dim sql2 As SqlServer.ListasControlProductosItems = New SqlServer.ListasControlProductosItems(da)
         'Dim sql3 As Reglas.ListasControlConfig = New Reglas.ListasControlConfig(da)
         'Dim ListaItems As List(Of Entidades.ListaControlConfig) = New List(Of Entidades.ListaControlConfig)
         ' Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
         'Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
         ' Dim dtAudit As DataTable = New DataTable()
         ' Dim OperacAudit As Entidades.OperacionesAuditorias
         'Dim ListaControlItems As DataTable
         Dim ListaControl As DataTable
         ' Dim oCal As Reglas.ListasControlProductosItems = New Reglas.ListasControlProductosItems(da)
         Dim oLC As Reglas.ListasControlModelos = New Reglas.ListasControlModelos(da)

         If dtListasControlModelos IsNot Nothing Then

            'BAJAS
            For Each lista As Entidades.ListaControlModelo In dtListasControlModelos.Borrados

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

               sql.ListasControlModelos_D(lista.IdProductoModelo, lista.IdListaControl)



            Next

            'ALTAS
            For Each lista As Entidades.ListaControlModelo In dtListasControlModelos


               'controlar si la lista ya existe no hace nada!!!

               ListaControl = oLC.GetListasControlxModelo(lista.IdProductoModelo, lista.IdListaControl)

               If ListaControl.Rows.Count = 0 Then

                  'OperacAudit = Entidades.OperacionesAuditorias.Alta
                  'Lista NUEVA
                  sql.ListasControlModelos_I(lista.IdProductoModelo, lista.IdListaControl, lista.fecha, lista.IdUsuario)


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

   Public Function GetListasControlxModelo(IdProductoModelo As Integer, idListaControl As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlModelos(da).ListasControlModelos_G1(IdProductoModelo, idListaControl)
      Return dt
   End Function

   Public Function GetListasControlInforme(IdProductoModelo As Integer, idListaControl As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlModelos(da).ListasControlModelos_GInforme(IdProductoModelo, idListaControl)
      Return dt
   End Function

#End Region

End Class