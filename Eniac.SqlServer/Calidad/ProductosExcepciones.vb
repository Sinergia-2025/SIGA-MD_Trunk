Public Class ProductosExcepciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosExcepciones_I(IdProducto As String,
                                     IdExcepcion As Integer,
                                     fecha As DateTime,
                                     IdUsuario As String)


      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO CalidadProductosExcepciones ({0}, {1}, {2}, {3})",
                       Entidades.ProductoExcepcion.Columnas.IdProducto.ToString(),
                       Entidades.ProductoExcepcion.Columnas.IdExcepcion.ToString(),
                       Entidades.ProductoExcepcion.Columnas.fecha.ToString(),
                       Entidades.ProductoExcepcion.Columnas.IdUsuario.ToString()).AppendLine()
         .AppendFormat("     VALUES ('{0}', {1},'{2}' ,'{3}')",
                       IdProducto, IdExcepcion, ObtenerFecha(fecha, True), IdUsuario)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProductosExcepciones_U(IdProducto As String,
                                     IdExcepcion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      'With myQuery
      '   .AppendLine("UPDATE CalidadListasControlProductosModelos ")
      '   .AppendFormat("   SET {0} = '{1}'", Entidades.ListaControlModelo.Columnas.IdRol.ToString(), idUsuario).AppendLine()
      '   .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlModelo.Columnas.IdListaControl.ToString(), idListaControl)

      'End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProductosExcepciones_D(idExcepcion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadProductosExcepciones ")
         .AppendFormat(" WHERE {0} = {1}", Entidades.ProductoExcepcion.Columnas.IdExcepcion.ToString(), idExcepcion)

      End With

      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ProductosExcepciones_D(idProducto As String, idExcepcion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadProductosExcepciones ")
         .AppendFormat(" WHERE {0} = {1}", Entidades.ProductoExcepcion.Columnas.IdExcepcion.ToString(), idExcepcion)
         .AppendFormat(" AND {0} = '{1}'", Entidades.ProductoExcepcion.Columnas.IdProducto.ToString(), idProducto)
      End With

      Me.Execute(myQuery.ToString())
   End Sub
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT CPE.IdProducto,  CPE.IdUsuario AS Responsable, CPE.fecha,CE.*, LCT.NombreListaControlTipo, ET.NombreExcepcionTipo, P.NombreProducto
                        FROM CalidadProductosExcepciones AS CPE
                        LEFT JOIN CalidadExcepciones AS CE ON CE.IdExcepcion = CPE.IdExcepcion  
                        LEFT JOIN Productos AS P ON P.IdProducto = CPE.IdProducto  
                        LEFT JOIN CalidadListasControlTipos AS LCT ON LCT.IdListaControlTipo = CE.IdListaControlTipo 
                        LEFT JOIN CalidadExcepcionesTipos AS ET ON ET.IdExcepcionTipo = CE.IdExcepcionTipo ")
      End With
   End Sub

   Public Function ProductosExcepciones_GA(idExcepcion As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE CPE.{0} = {1}", Entidades.ProductoExcepcion.Columnas.IdExcepcion.ToString(), idExcepcion)
         .AppendFormat(" ORDER BY CPE.IdProducto")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ProductosExcepciones_GxProducto(idProducto As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE CPE.{0} = '{1}'", Entidades.ProductoExcepcion.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormat(" ORDER BY CPE.IdProducto")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ProductosExcepciones_G1(IdProducto As String, idExcepcion As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE CPE.{0} = {1}", Entidades.ProductoExcepcion.Columnas.IdProducto.ToString(), IdProducto)
         .AppendFormat(" AND CPE.{0} = '{1}'", Entidades.ProductoExcepcion.Columnas.IdExcepcion.ToString(), idExcepcion)

         .AppendFormat(" ORDER BY CPE.IdProducto")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ProductosExcepciones_GInforme(Idproducto As String, Responsable As String, FechaDesde As DateTime?, FechaHasta As DateTime?,
                                                 IdExcepcion As Integer, IdListaControTipo As Integer, IdExcepcionTipo As Integer,
                                                 Departamento As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery

         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE 1= 1")

         If Not String.IsNullOrEmpty(Idproducto) Then
            .AppendFormat(" AND CPE.{0} = '{1}'", Entidades.ProductoExcepcion.Columnas.IdProducto.ToString(), Idproducto)
         End If

         If Not String.IsNullOrEmpty(Responsable) Then
            .AppendFormat(" AND CPE.{0} = '{1}'", Entidades.Excepcion.Columnas.IdUsuario.ToString(), Responsable)
         End If

         If FechaDesde.HasValue Then
            .AppendFormat("	   AND  CPE.fecha >= '{0}'", ObtenerFecha(FechaDesde.Value, False))
         End If
         If FechaHasta.HasValue Then
            .AppendFormat("      AND  CPE.fecha <= '{0}'", ObtenerFecha(FechaHasta.Value.UltimoSegundoDelDia, True))
         End If

         If IdExcepcion > 0 Then
            .AppendFormat(" AND CPE.{0} = {1}", Entidades.Excepcion.Columnas.IdExcepcion.ToString(), IdExcepcion)
         End If

         If IdListaControTipo > 0 Then
            .AppendFormat(" AND CE.{0} = {1}", Entidades.Excepcion.Columnas.IdListaControlTipo.ToString(), IdListaControTipo)
         End If

         If IdExcepcionTipo > 0 Then
            .AppendFormat(" AND CE.{0} = {1}", Entidades.Excepcion.Columnas.IdExcepcionTipo.ToString(), IdExcepcionTipo)
         End If

         If Not String.IsNullOrEmpty(Departamento) Then
            .AppendFormat(" AND CE.{0} = '{1}'", Entidades.Excepcion.Columnas.Dpto.ToString(), Departamento)
         End If

         '.AppendFormat(" ORDER BY U.NombreProductoModelo, LC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


End Class