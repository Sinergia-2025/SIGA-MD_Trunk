Public Class ReservasTurismoProductos
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ReservasTurismoProductos_I(idSucursal As Integer,
                                         idTipoReserva As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numeroReserva As Long,
                                         idProducto As String,
                                         idProductoComponente As String,
                                         idFormula As Integer,
                                         orden As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO ReservasTurismoProductos")
         .AppendFormat(" ({0} ", Entidades.ReservaTurismoProducto.Columnas.IdSucursal.ToString())
         .AppendFormat(" ,{0} ", Entidades.ReservaTurismoProducto.Columnas.IdTipoReserva.ToString())
         .AppendFormat(" ,{0} ", Entidades.ReservaTurismoProducto.Columnas.Letra.ToString())
         .AppendFormat(" ,{0} ", Entidades.ReservaTurismoProducto.Columnas.CentroEmisor.ToString())
         .AppendFormat(" ,{0} ", Entidades.ReservaTurismoProducto.Columnas.NumeroReserva.ToString())
         .AppendFormat(" ,{0} ", Entidades.ReservaTurismoProducto.Columnas.IdProducto.ToString())
         .AppendFormat(" ,{0} ", Entidades.ReservaTurismoProducto.Columnas.IdProductoComponente.ToString())
         .AppendFormat(" ,{0} ", Entidades.ReservaTurismoProducto.Columnas.IdFormula.ToString())
         .AppendFormat(" ,{0} ", Entidades.ReservaTurismoProducto.Columnas.Orden.ToString())
         .Append(")")
         .AppendFormat(" VALUES")
         .AppendFormat(" ({0}", idSucursal)
         .AppendFormat(" ,'{0}'", IdTipoReserva)
         .AppendFormat(" ,'{0}'", Letra)
         .AppendFormat(" , {0} ", CentroEmisor)
         .AppendFormat(" , {0} ", NumeroReserva)
         .AppendFormat(" ,'{0}'", IdProducto)
         If Not String.IsNullOrEmpty(IdProductoComponente) Then
            .AppendFormat(" ,'{0}'", IdProductoComponente)
         Else
            .AppendLine(" ,NULL")
         End If

         .AppendFormat(" , {0} ", IdFormula)
         .AppendFormat(" , {0} ", Orden)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ReservasTurismoProductos_D(idSucursal As Integer,
                                         idTipoReserva As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numeroReserva As Long)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM ReservasTurismoProductos")
         .AppendFormat(" WHERE {0} = {1}", Entidades.ReservaTurismoProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormat("   AND {0} = '{1}'", Entidades.ReservaTurismoProducto.Columnas.IdTipoReserva.ToString(), IdTipoReserva)
         .AppendFormat("   AND {0} = '{1}'", Entidades.ReservaTurismoProducto.Columnas.Letra.ToString(), Letra)
         .AppendFormat("   AND {0} =  {1} ", Entidades.ReservaTurismoProducto.Columnas.CentroEmisor.ToString(), CentroEmisor)
         .AppendFormat("   AND {0} =  {1} ", Entidades.ReservaTurismoProducto.Columnas.NumeroReserva.ToString(), NumeroReserva)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, Optional campoCalculado As String = "")
      With stb
         .AppendLine("SELECT  RP.*, P0.NombreProducto , P1.NombreProducto AS NombreProducto1 ,  SR.NombreSubRubro  ")
         .AppendLine(" FROM ReservasTurismoProductos RP ")
         .AppendLine(" INNER JOIN ReservasTurismo R ON R.IdSucursal = RP.IdSucursal ")
         .AppendLine(" AND R.IdTipoReserva = RP.IdTipoReserva ")
         .AppendLine(" AND R.Letra = RP.Letra ")
         .AppendLine(" AND R.CentroEmisor = RP.CentroEmisor ")
         .AppendLine(" AND R.NumeroReserva = RP.NumeroReserva ")
         .AppendLine(" INNER JOIN Productos P0 ON P0.IdProducto = RP.IdProducto")
         .AppendLine(" LEFT JOIN Productos P1 ON P1.IdProducto = RP.IdProductoComponente  ")
         .AppendLine("LEFT JOIN Rubros RU ON RU.IdRubro = P1.IdRubro ")
         .AppendLine(" LEFT JOIN Subrubros SR ON SR.IdRubro = P1.IdRubro AND SR.IdSubRubro = P1.IdSubRubro")
      End With
   End Sub

   Public Function ReservasTurismoProductos_G1(idSucursal As Integer, idTipoReservaProducto As String, letra As String, centroEmisor As Short, Numero As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE S.{0} = {1}", Entidades.ReservaTurismoProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormat("   AND S.{0} = '{1}'", Entidades.ReservaTurismoProducto.Columnas.IdTipoReserva.ToString(), idTipoReservaProducto)
         .AppendFormat("   AND S.{0} = '{1}'", Entidades.ReservaTurismoProducto.Columnas.Letra.ToString(), letra)
         .AppendFormat("   AND S.{0} =  {1} ", Entidades.ReservaTurismoProducto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormat("   AND S.{0} =  {1} ", Entidades.ReservaTurismoProducto.Columnas.NumeroReserva.ToString(), Numero)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ReservasTurismoProductos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   'Public Overloads Function Buscar(columna As String, valor As String) As DataTable
   '   Return Buscar(columna, valor, String.Empty, Nothing, String.Empty)
   'End Function

   Private Sub PreparaColumnaParaBuscar(ByRef columna As String)
      If columna = "NombreTipoNovedad" Then
         columna = "TN." + columna
      ElseIf columna = "NombrePrioridadNovedad" Then
         columna = "PN." + columna
      ElseIf columna = "NombreCategoriaNovedad" Then
         columna = "CN." + columna
      ElseIf columna = "NombreEstadoNovedad" Then
         columna = "EN." + columna
      ElseIf columna = "NombreMedioComunicacionNovedad" Then
         columna = "MN." + columna
      ElseIf columna = "NombreMetodoResolucionNovedad" Then
         columna = "MRN." + columna
      ElseIf columna = "CodigoCliente" Or columna = "NombreCliente" Then
         columna = "C." + columna
      ElseIf columna = "CodigoProspecto" Or columna = "NombreProspecto" Then
         columna = "P." + columna
      ElseIf columna = "CodigoProveedor" Or columna = "NombreProveedor" Then
         columna = "PR." + columna
      ElseIf columna = "NombreUsuarioEstadoNovedad" Then
         columna = "UE." + columna
      ElseIf columna = "NombreUsuarioAlta" Then
         columna = "UA." + columna
      ElseIf columna = "NombreUsuarioAsignado" Then
         columna = "UG." + columna
      ElseIf columna = "NombreUsuarioResponsable" Then
         columna = "UR." + columna
      ElseIf columna = "NombreFuncion" Then
         columna = "FN." + columna
      ElseIf columna = "NombreDeFantasia" Then
         columna = "C." + columna
      ElseIf columna = "NombreDeFantasiaProspecto" Then
         columna = "P.NombreDeFantasia"
      ElseIf columna = "NombreProyecto" Then
         columna = "PR.NombreProyecto"
      Else
         columna = "N." + columna
      End If
   End Sub

   'Public Overloads Function Buscar(columna As String, valor As String, idTipoNovedad As String,
   '                                 finalizado As Boolean?, usuarioAsignado As String) As DataTable

   '   Dim esFecha As Boolean = columna = Entidades.ReservaProducto.Columnas.FechaNovedad.ToString() Or
   '                            columna = Entidades.ReservaProducto.Columnas.FechaProximoContacto.ToString() Or
   '                            columna = Entidades.ReservaProducto.Columnas.FechaEstadoNovedad.ToString() Or
   '                            columna = Entidades.ReservaProducto.Columnas.FechaAlta.ToString()

   '   PreparaColumnaParaBuscar(columna)

   '   Dim stb As StringBuilder = New StringBuilder()
   '   With stb
   '      Me.SelectTexto(stb)
   '      Dim fecha As DateTime = Nothing
   '      Dim valorFecha As String = valor
   '      If esFecha Then
   '         If valorFecha.Split("/"c).Length < 2 Then
   '            valorFecha = String.Concat(valorFecha, Today.ToString("/MM"))
   '         End If
   '         If valorFecha.Split("/"c).Length < 3 Then
   '            valorFecha = String.Concat(valorFecha, Today.ToString("/yyyy"))
   '         End If

   '         Try
   '            fecha = DateTime.Parse(valorFecha)
   '         Catch ex As Exception
   '            esFecha = False
   '         End Try
   '      End If
   '      If esFecha Then
   '         .AppendFormatLine(" WHERE {0} BETWEEN '{1}' AND '{2}' ", columna, ObtenerFecha(fecha.Date, True), ObtenerFecha(fecha.Date.AddDays(1).AddSeconds(-1), True))
   '      Else
   '         .AppendFormatLine(FormatoBuscar, columna, valor)
   '      End If

   '      If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
   '         .AppendFormat(" AND N.{0} = '{1}'", Entidades.ReservaProducto.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
   '      End If
   '      If finalizado.HasValue Then
   '         .AppendFormat(" AND EN.Finalizado = {0}", GetStringFromBoolean(finalizado.Value))
   '      End If
   '      If Not String.IsNullOrWhiteSpace(usuarioAsignado) Then
   '         .AppendFormat(" AND N.IdUsuarioAsignado = '{0}'", usuarioAsignado).AppendLine()
   '      End If
   '   End With
   '   Return Me.GetDataTable(stb.ToString())
   'End Function

   'Public Overloads Function GetCodigoMaximo(idTipoNovedad As String, letra As String, centroEmisor As Short) As Long
   '   Return MyBase.GetCodigoMaximo(Entidades.ReservaProducto.Columnas.IdNovedad.ToString(), "ReservasTurismoProductos",
   '                                 String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5}",
   '                                               Entidades.ReservaProducto.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
   '                                               Entidades.ReservaProducto.Columnas.Letra.ToString(), letra,
   '                                               Entidades.ReservaProducto.Columnas.CentroEmisor.ToString(), centroEmisor))
   'End Function


   Public Function GetReservaProductos(idsucursal As Integer, idTipoReserva As String, letra As String,
                                          centroemisor As Short, NumeroReserva As Long, IdFormula As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE RP.{0} = {1}", Entidades.ReservaTurismoProducto.Columnas.IdSucursal.ToString(), idsucursal)
         .AppendFormat("   AND RP.{0} = '{1}'", Entidades.ReservaTurismoProducto.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormat("   AND RP.{0} = '{1}'", Entidades.ReservaTurismoProducto.Columnas.Letra.ToString(), letra)
         .AppendFormat("   AND RP.{0} =  {1} ", Entidades.ReservaTurismoProducto.Columnas.CentroEmisor.ToString(), centroemisor)
         .AppendFormat("   AND RP.{0} =  {1} ", Entidades.ReservaTurismoProducto.Columnas.NumeroReserva.ToString(), NumeroReserva)
         .AppendLine("  AND RP.IdFormula = " & IdFormula)
      End With
      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function ExisteReservaProducto(idsucursal As Integer, idTipoReserva As String, letra As String,
                                           centroemisor As Short, NumeroReserva As Long, IdProducto As String) As Boolean

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE RP.{0} = {1}", Entidades.ReservaTurismoProducto.Columnas.IdSucursal.ToString(), idsucursal)
         .AppendFormat("   AND RP.{0} = '{1}'", Entidades.ReservaTurismoProducto.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormat("   AND RP.{0} = '{1}'", Entidades.ReservaTurismoProducto.Columnas.Letra.ToString(), letra)
         .AppendFormat("   AND RP.{0} =  {1} ", Entidades.ReservaTurismoProducto.Columnas.CentroEmisor.ToString(), centroemisor)
         .AppendFormat("   AND RP.{0} =  {1} ", Entidades.ReservaTurismoProducto.Columnas.NumeroReserva.ToString(), NumeroReserva)
         .AppendFormat("  AND RP.IdProducto = '{0}' ", IdProducto)
      End With

      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      If dt.Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If

   End Function

End Class