Public Class ReservasTurismoPasajeros
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ReservasTurismoPasajeros_I(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                                         idPasajero As Integer,
                                         idResponsablePasajero As Long,
                                         idTipoComprobante As String, letraComprobante As String, centroEmisorComprobante As Integer, numeroComprobante As Long,
                                         porcentajeLiberado As Decimal,
                                         costo As Decimal,
                                         idClientePasajero As Long,
                                         idSucursalFact As Integer, idTipoComprobanteFact As String, letraComprobanteFact As String, centroEmisorComprobanteFact As Integer, numeroComprobanteFact As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO {0} ", Entidades.ReservaTurismoPasajero.NombreTabla)
         .AppendFormatLine(" ({0} ", Entidades.ReservaTurismoPasajero.Columnas.IdSucursal.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.IdTipoReserva.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.Letra.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisor.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroReserva.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.IdPasajero.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.IdResponsablePasajero.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.LetraComprobante.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisorComprobante.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.PorcentajeLiberado.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.Costo.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.IdClientePasajero.ToString())

         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.IdSucursalComprobanteFact.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.IdTipoComprobanteFact.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.LetraComprobanteFact.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisorComprobanteFact.ToString())
         .AppendFormatLine(" ,{0} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroComprobanteFact.ToString())

         .AppendFormatLine(" )")
         .AppendFormatLine(" VALUES")
         .AppendFormatLine(" ({0}", idSucursal)
         .AppendFormatLine(" ,'{0}'", idTipoReserva)
         .AppendFormatLine(" ,'{0}'", letra)
         .AppendFormatLine(" , {0} ", centroEmisor)
         .AppendFormatLine(" , {0} ", numeroReserva)
         .AppendFormatLine(" , {0}", idPasajero)
         If idResponsablePasajero > 0 Then
            .AppendFormatLine(" , {0}", idResponsablePasajero)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine(" , '{0}' ", idTipoComprobante)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrEmpty(letra) Then
            .AppendFormatLine(" , '{0}' ", letraComprobante)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If centroEmisorComprobante > 0 Then
            .AppendFormatLine(" , {0} ", centroEmisorComprobante)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If centroEmisorComprobante > 0 Then
            .AppendFormatLine(" , {0} ", numeroComprobante)
         Else
            .AppendFormatLine(" , NULL")
         End If
         If porcentajeLiberado > 0 Then
            .AppendFormatLine(" , {0} ", porcentajeLiberado)
         Else
            .AppendFormatLine(" , NULL")
         End If

         .AppendFormatLine(" , {0} ", costo)
         .AppendFormatLine(" , {0} ", idClientePasajero)

         .AppendFormatLine(" ,  {0} ", GetStringFromNumber(idSucursalFact))
         .AppendFormatLine(" ,  {0} ", GetStringParaQueryConComillas(idTipoComprobanteFact))
         .AppendFormatLine(" ,  {0} ", GetStringParaQueryConComillas(letraComprobanteFact))
         .AppendFormatLine(" ,  {0} ", GetStringFromNumber(centroEmisorComprobanteFact))
         .AppendFormatLine(" ,  {0} ", GetStringFromNumber(numeroComprobanteFact))

         .AppendFormatLine(")")
      End With
      Execute(stb)
   End Sub
   Public Sub ReservasTurismoPasajeros_U(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                                         idPasajero As Integer,
                                         idResponsablePasajero As Long,
                                         idTipoComprobante As String, letraComprobante As String, centroEmisorComprobante As Integer, numeroComprobante As Long, porcentajeLiberado As Decimal,
                                         costo As Decimal,
                                         idClientePasajero As Long,
                                         idSucursalFact As Integer, idTipoComprobanteFact As String, letraComprobanteFact As String, centroEmisorComprobanteFact As Integer, numeroComprobanteFact As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ReservasTurismoPasajeros ")
         If idResponsablePasajero > 0 Then
            .AppendFormatLine("   SET {0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.IdResponsablePasajero.ToString(), idResponsablePasajero)
         Else
            .AppendFormatLine("   SET {0} = Null", Entidades.ReservaTurismoPasajero.Columnas.IdResponsablePasajero.ToString())
         End If
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.PorcentajeLiberado.ToString(), porcentajeLiberado)
         .AppendFormatLine("     , {0} = {1} ", Entidades.ReservaTurismoPasajero.Columnas.Costo.ToString(), costo)
         .AppendFormatLine("     , {0} = {1} ", Entidades.ReservaTurismoPasajero.Columnas.IdClientePasajero.ToString(), idClientePasajero)

         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ReservaTurismoPasajero.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroReserva.ToString(), numeroReserva)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.IdPasajero.ToString(), idPasajero)
      End With
      Execute(stb)
   End Sub

   Public Sub ReservasTurismoPasajeros_D(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                                         idPasajero As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ReservasTurismoPasajeros")
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ReservaTurismoPasajero.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroReserva.ToString(), numeroReserva)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.IdPasajero.ToString(), idPasajero)
      End With
      Execute(stb)
   End Sub

   Public Sub ReservasTurismoPasajeros_DxReserva(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ReservasTurismoPasajeros")
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ReservaTurismoPasajero.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroReserva.ToString(), numeroReserva)
      End With
      Execute(stb)
   End Sub
   Private Sub SelectTexto(stb As StringBuilder, campoCalculado As Action(Of StringBuilder), joinCamposCalculados As Action(Of StringBuilder))
      With stb
         .AppendFormatLine("SELECT RP.*, C1.NombreCliente AS NombrePasajero, C2.NombreCliente AS NombreResponsable, C1.CodigoCliente")
         .AppendFormatLine("     , RP.Costo - CASE WHEN RP.PorcentajeLiberado is not null THEN ((RP.Costo * RP.PorcentajeLiberado) / 100) ELSE 0 END  As Importe")

         If campoCalculado IsNot Nothing Then
            campoCalculado(stb)
         End If

         .AppendFormatLine(" FROM ReservasTurismoPasajeros RP ")
         .AppendFormatLine(" INNER JOIN ReservasTurismo R ON R.IdSucursal = RP.IdSucursal ")
         .AppendFormatLine("        AND R.IdTipoReserva = RP.IdTipoReserva ")
         .AppendFormatLine("        AND R.Letra = RP.Letra ")
         .AppendFormatLine("        AND R.CentroEmisor = RP.CentroEmisor ")
         .AppendFormatLine("        AND R.NumeroReserva = RP.NumeroReserva ")
         .AppendFormatLine("  LEFT JOIN Clientes C1 ON C1.IdCliente = RP.IdClientePasajero ")
         .AppendFormatLine("  LEFT JOIN Clientes C2 ON C2.IdCliente = RP.IdResponsablePasajero  ")

         If joinCamposCalculados IsNot Nothing Then
            joinCamposCalculados(stb)
         End If
      End With
   End Sub

   Public Function ReservaPasajeros_G1(idSucursal As Integer, idTipoReservaPasajero As String, letra As String, centroEmisor As Short, numero As Long,
                                       idPasajero As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, campoCalculado:=Nothing, joinCamposCalculados:=Nothing)
         .AppendFormatLine(" WHERE S.{0} = {1}", Entidades.ReservaTurismoPasajero.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND S.{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.IdTipoReserva.ToString(), idTipoReservaPasajero)
         .AppendFormatLine("   AND S.{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND S.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND S.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroReserva.ToString(), numero)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.IdPasajero.ToString(), idPasajero)

      End With
      Return GetDataTable(stb)
   End Function

   Public Function ReservaPasajeros_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, campoCalculado:=Nothing, joinCamposCalculados:=Nothing)
      End With
      Return GetDataTable(stb)
   End Function

   'Public Overloads Function Buscar(columna As String, valor As String) As DataTable
   '   Return Buscar(columna, valor, String.Empty, Nothing, String.Empty)
   'End Function

   'Private Sub PreparaColumnaParaBuscar(ByRef columna As String)
   '   If columna = "NombreTipoNovedad" Then
   '      columna = "TN." + columna
   '   ElseIf columna = "NombrePrioridadNovedad" Then
   '      columna = "PN." + columna
   '   ElseIf columna = "NombreCategoriaNovedad" Then
   '      columna = "CN." + columna
   '   ElseIf columna = "NombreEstadoNovedad" Then
   '      columna = "EN." + columna
   '   ElseIf columna = "NombreMedioComunicacionNovedad" Then
   '      columna = "MN." + columna
   '   ElseIf columna = "NombreMetodoResolucionNovedad" Then
   '      columna = "MRN." + columna
   '   ElseIf columna = "CodigoCliente" Or columna = "NombreCliente" Then
   '      columna = "C." + columna
   '   ElseIf columna = "CodigoProspecto" Or columna = "NombreProspecto" Then
   '      columna = "P." + columna
   '   ElseIf columna = "CodigoProveedor" Or columna = "NombreProveedor" Then
   '      columna = "PR." + columna
   '   ElseIf columna = "NombreUsuarioEstadoNovedad" Then
   '      columna = "UE." + columna
   '   ElseIf columna = "NombreUsuarioAlta" Then
   '      columna = "UA." + columna
   '   ElseIf columna = "NombreUsuarioAsignado" Then
   '      columna = "UG." + columna
   '   ElseIf columna = "NombreUsuarioResponsable" Then
   '      columna = "UR." + columna
   '   ElseIf columna = "NombreFuncion" Then
   '      columna = "FN." + columna
   '   ElseIf columna = "NombreDeFantasia" Then
   '      columna = "C." + columna
   '   ElseIf columna = "NombreDeFantasiaProspecto" Then
   '      columna = "P.NombreDeFantasia"
   '   ElseIf columna = "NombreProyecto" Then
   '      columna = "PR.NombreProyecto"
   '   Else
   '      columna = "N." + columna
   '   End If
   'End Sub

   'Public Overloads Function Buscar(columna As String, valor As String, idTipoNovedad As String,
   '                                 finalizado As Boolean?, usuarioAsignado As String) As DataTable

   '   Dim esFecha As Boolean = columna = Entidades.ReservaPasajero.Columnas.FechaNovedad.ToString() Or
   '                            columna = Entidades.ReservaPasajero.Columnas.FechaProximoContacto.ToString() Or
   '                            columna = Entidades.ReservaPasajero.Columnas.FechaEstadoNovedad.ToString() Or
   '                            columna = Entidades.ReservaPasajero.Columnas.FechaAlta.ToString()

   '   PreparaColumnaParaBuscar(columna)

   '   Dim stb = New StringBuilder()
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
   '         .AppendFormat(" AND N.{0} = '{1}'", Entidades.ReservaPasajero.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
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
   '   Return MyBase.GetCodigoMaximo(Entidades.ReservaPasajero.Columnas.IdNovedad.ToString(), "ReservaPasajeros",
   '                                 String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5}",
   '                                               Entidades.ReservaPasajero.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
   '                                               Entidades.ReservaPasajero.Columnas.Letra.ToString(), letra,
   '                                               Entidades.ReservaPasajero.Columnas.CentroEmisor.ToString(), centroEmisor))
   'End Function


   Public Function GetReservaPasajeros(idsucursal As Integer, idTipoReserva As String, letra As String, centroemisor As Short, numeroReserva As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, campoCalculado:=Nothing, joinCamposCalculados:=Nothing)
         .AppendFormatLine(" WHERE RP.{0} = {1}", Entidades.ReservaTurismoPasajero.Columnas.IdSucursal.ToString(), idsucursal)
         .AppendFormatLine("   AND RP.{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormatLine("   AND RP.{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND RP.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisor.ToString(), centroemisor)
         .AppendFormatLine("   AND RP.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroReserva.ToString(), numeroReserva)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetParaCuentaCorriente(idsucursal As Integer, idTipoReserva As String, letra As String, centroemisor As Short, NumeroReserva As Long,
                                          generacion As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb,
                     campoCalculado:=
                     Sub(stb1)
                        With stb1
                           .AppendFormatLine("     , CONVERT(BIT, 0) Selec")
                           .AppendFormatLine("     , CCP.PrimerVencimiento")
                           .AppendFormatLine("     , CONVERT(DECIMAL(12,2), ISNULL(CCP.Anticipo, 0)) Anticipo")
                           .AppendFormatLine("     , CCP.CantidadCuotas")
                           .AppendFormatLine("     , CCP.ImportePrimerCuota")
                           .AppendFormatLine("     , CCP.ImporteUltimaCuota")
                           .AppendFormatLine("     , R.FechaViaje")
                        End With
                     End Sub,
                     joinCamposCalculados:=
                     Sub(stb1)
                        With stb1
                           .AppendFormatLine("  LEFT JOIN ")
                           .AppendFormatLine("            (SELECT CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante")
                           .AppendFormatLine("                  , MIN(CASE WHEN CCP.CuotaNumero > 0 THEN CCP.FechaVencimiento ELSE NULL END)            AS PrimerVencimiento")
                           .AppendFormatLine("                  , SUM(CASE WHEN CCP.CuotaNumero = 0 THEN CCP.ImporteCuota ELSE 0 END)                   AS Anticipo")
                           .AppendFormatLine("                  , SUM(CASE WHEN CCP.CuotaNumero = 0 THEN 0 ELSE 1 END)                                  AS CantidadCuotas")
                           .AppendFormatLine("                  , MAX(CASE WHEN CCP.CuotaNumero > 0 THEN CCP.ImporteCuota ELSE NULL END)                AS ImportePrimerCuota")
                           .AppendFormatLine("                  , MAX(CASE WHEN CCP.CuotaNumero = CCP1.UltimaCuota THEN CCP.ImporteCuota ELSE NULL END) AS ImporteUltimaCuota")
                           .AppendFormatLine("               FROM (")
                           .AppendFormatLine("                     SELECT CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante, MAX(CCP.CuotaNumero) UltimaCuota")
                           .AppendFormatLine("                       FROM CuentasCorrientesPagos CCP")
                           .AppendFormatLine("                      INNER JOIN ReservasTurismoPasajeros RTP ")
                           .AppendFormatLine("                              ON RTP.IdSucursalComprobante = CCP.IdSucursal")
                           .AppendFormatLine("                             AND RTP.IdTipoComprobante = CCP.IdTipoComprobante")
                           .AppendFormatLine("                             AND RTP.Letra = CCP.Letra")
                           .AppendFormatLine("                             AND RTP.CentroEmisor = CCP.CentroEmisor")
                           .AppendFormatLine("                             AND RTP.NumeroComprobante = CCP.NumeroComprobante")
                           .AppendFormatLine("                      WHERE RTP.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.IdSucursal.ToString(), idsucursal)
                           .AppendFormatLine("                        AND RTP.{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.IdTipoReserva.ToString(), idTipoReserva)
                           .AppendFormatLine("                        AND RTP.{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.Letra.ToString(), letra)
                           .AppendFormatLine("                        AND RTP.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisor.ToString(), centroemisor)
                           .AppendFormatLine("                        AND RTP.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroReserva.ToString(), NumeroReserva)
                           .AppendFormatLine("                      GROUP BY CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante")
                           .AppendFormatLine("                     ) CCP1")
                           .AppendFormatLine("              INNER JOIN CuentasCorrientesPagos CCP")
                           .AppendFormatLine("                      ON CCP.IdSucursal = CCP1.IdSucursal")
                           .AppendFormatLine("                     AND CCP.IdTipoComprobante = CCP1.IdTipoComprobante")
                           .AppendFormatLine("                     AND CCP.Letra = CCP1.Letra")
                           .AppendFormatLine("                     AND CCP.CentroEmisor = CCP1.CentroEmisor")
                           .AppendFormatLine("                     AND CCP.NumeroComprobante = CCP1.NumeroComprobante")
                           .AppendFormatLine("              GROUP BY CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante) CCP")
                           .AppendFormatLine("         ON RP.IdSucursalComprobante = CCP.IdSucursal")
                           .AppendFormatLine("        AND RP.IdTipoComprobante = CCP.IdTipoComprobante")
                           .AppendFormatLine("        AND RP.Letra = CCP.Letra")
                           .AppendFormatLine("        AND RP.CentroEmisor = CCP.CentroEmisor")
                           .AppendFormatLine("        AND RP.NumeroComprobante = CCP.NumeroComprobante")
                        End With
                     End Sub)

         .AppendFormatLine(" WHERE RP.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.IdSucursal.ToString(), idsucursal)
         .AppendFormatLine("   AND RP.{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormatLine("   AND RP.{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND RP.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisor.ToString(), centroemisor)
         .AppendFormatLine("   AND RP.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroReserva.ToString(), NumeroReserva)
         If generacion <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND RP.{0} IS {1} NULL ", Entidades.ReservaTurismoPasajero.Columnas.IdTipoComprobante.ToString(),
                              If(generacion = Entidades.Publicos.SiNoTodos.SI, "NOT", ""))
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetParaFacturacion(idsucursal As Integer, idTipoReserva As String, letra As String, centroemisor As Short, NumeroReserva As Long,
                                      generacion As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb,
                     campoCalculado:=
                     Sub(stb1)
                        With stb1
                           .AppendFormatLine("     , CONVERT(BIT, 0) Selec")
                           .AppendFormatLine("     , V.IdFormasPago IdFormasPagoFact")
                        End With
                     End Sub,
                     joinCamposCalculados:=
                     Sub(stb1)
                        With stb1
                           .AppendFormatLine("  LEFT JOIN Ventas V")
                           .AppendFormatLine("         ON V.IdSucursal = RP.IdSucursalComprobanteFact")
                           .AppendFormatLine("        AND V.IdTipoComprobante = RP.IdTipoComprobanteFact")
                           .AppendFormatLine("        AND V.Letra = RP.LetraComprobanteFact")
                           .AppendFormatLine("        AND V.CentroEmisor = RP.CentroEmisorComprobanteFact")
                           .AppendFormatLine("        AND V.NumeroComprobante = RP.NumeroComprobanteFact")
                        End With
                     End Sub)

         .AppendFormatLine(" WHERE RP.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.IdSucursal.ToString(), idsucursal)
         .AppendFormatLine("   AND RP.{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormatLine("   AND RP.{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND RP.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisor.ToString(), centroemisor)
         .AppendFormatLine("   AND RP.{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroReserva.ToString(), NumeroReserva)
         If generacion <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND RP.{0} IS {1} NULL ", Entidades.ReservaTurismoPasajero.Columnas.IdTipoComprobante.ToString(),
                              If(generacion = Entidades.Publicos.SiNoTodos.SI, "NOT", ""))
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo(idsucursal As Integer, idTipoReserva As String, letra As String,
                                          centroemisor As Short, NumeroReserva As Long) As Long
      Return GetCodigoMaximo(Entidades.ReservaTurismoPasajero.Columnas.IdPasajero.ToString(), "ReservasTurismoPasajeros",
                             String.Format("{0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9}",
                                           Entidades.ReservaTurismoPasajero.Columnas.IdSucursal.ToString(), idsucursal,
                                           Entidades.ReservaTurismoPasajero.Columnas.IdTipoReserva.ToString(), idTipoReserva,
                                           Entidades.ReservaTurismoPasajero.Columnas.Letra.ToString(), letra,
                                           Entidades.ReservaTurismoPasajero.Columnas.CentroEmisor.ToString(), centroemisor,
                                           Entidades.ReservaTurismoPasajero.Columnas.NumeroReserva.ToString(), NumeroReserva))
   End Function

   Public Sub ActualizarComprobante(idSucursal As Integer,
                                    idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                                    idCliente As Long,
                                    idSucursalComprobante As Integer,
                                    idTipoComprobante As String, letraComprobante As String, centroEmisorComprobante As Integer, numeroComprobante As Long,
                                    modo As String)

      Dim stb = New StringBuilder()

      With stb
         .AppendLine("UPDATE ReservasTurismoPasajeros")
         If numeroComprobante > 0 Then
            .AppendFormatLine("   SET IdSucursalComprobante{1}    =  {0} ", idSucursalComprobante, modo)
            .AppendFormatLine("      ,IdTipoComprobante{1}        = '{0}'", idTipoComprobante, modo)
            .AppendFormatLine("      ,LetraComprobante{1}         = '{0}'", letraComprobante, modo)
            .AppendFormatLine("      ,CentroEmisorComprobante{1}  =  {0} ", centroEmisorComprobante, modo)
            .AppendFormatLine("      ,NumeroComprobante{1}        =  {0} ", numeroComprobante, modo)
         Else
            .AppendFormatLine("   SET IdTipoComprobante{1}        = NULL", 0, modo)
            .AppendFormatLine("      ,LetraComprobante{1}         = NULL", 0, modo)
            .AppendFormatLine("      ,CentroEmisorComprobante{1}  = NULL", 0, modo)
            .AppendFormatLine("      ,NumeroComprobante{1}        = NULL", 0, modo)

         End If
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoReserva = '{0}'", idTipoReserva)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroReserva = {0}", numeroReserva)
         If idCliente <> 0 Then
            .AppendFormatLine("   AND IdClientePasajero = {0}", idCliente)
         End If
      End With

      Execute(stb)
   End Sub

   Public Sub ActualizarReservasTurismoPasajeros(idSucursal As Integer,
                                                 idTipoComprobante As String, letra As String,
                                                 centroEmisor As Integer, numeroComprobante As Long)

      Dim stb = New StringBuilder()

      With stb
         .AppendLine("UPDATE ReservasTurismoPasajeros")
         .AppendFormatLine("   SET IdSucursalComprobante = NULL")
         .AppendFormatLine("      ,IdTipoComprobante        = NULL")
         .AppendFormatLine("      ,LetraComprobante         = NULL")
         .AppendFormatLine("      ,CentroEmisorComprobante  = NULL")
         .AppendFormatLine("      ,NumeroComprobante        = NULL")

         .AppendFormatLine(" WHERE IdSucursalComprobante    =  {0} ", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante        = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND LetraComprobante         = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisorComprobante  =  {0} ", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante        =  {0} ", numeroComprobante)

      End With

      Execute(stb)
   End Sub
   Public Sub ActualizarReservasTurismoPasajerosFact(idSucursal As Integer,
                                                     idTipoComprobante As String, letra As String,
                                                     centroEmisor As Integer, numeroComprobante As Long)

      Dim stb = New StringBuilder()

      With stb
         .AppendLine("UPDATE ReservasTurismoPasajeros")
         .AppendFormatLine("   SET IdSucursalComprobanteFact   = NULL")
         .AppendFormatLine("      ,IdTipoComprobanteFact       = NULL")
         .AppendFormatLine("      ,LetraComprobanteFact        = NULL")
         .AppendFormatLine("      ,CentroEmisorComprobanteFact = NULL")
         .AppendFormatLine("      ,NumeroComprobanteFact       = NULL")

         .AppendFormatLine(" WHERE IdSucursalComprobanteFact   =  {0} ", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobanteFact       = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND LetraComprobanteFact        = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisorComprobanteFact =  {0} ", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobanteFact       =  {0} ", numeroComprobante)

      End With

      Execute(stb)
   End Sub

   Public Sub ActualizarComprobantePorComprobante(idSucursalActual As Integer,
                                                  idTipoComprobanteActual As String, letraActual As String, centroEmisorActual As Integer, numeroComprobanteActual As Long,
                                                  idSucursalNuevo As Integer,
                                                  idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Integer, numeroComprobanteNuevo As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.ReservaTurismoPasajero.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.IdSucursalComprobanteFact.ToString(), idSucursalNuevo)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.IdTipoComprobanteFact.ToString(), idTipoComprobanteNuevo)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.LetraComprobanteFact.ToString(), letraNuevo)
         .AppendFormatLine("      ,{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisorComprobanteFact.ToString(), centroEmisorNuevo)
         .AppendFormatLine("      ,{0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroComprobanteFact.ToString(), numeroComprobanteNuevo)

         .AppendFormatLine("   WHERE {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.IdSucursalComprobanteFact.ToString(), idSucursalActual)
         .AppendFormatLine("     AND {0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.IdTipoComprobanteFact.ToString(), idTipoComprobanteActual)
         .AppendFormatLine("     AND {0} = '{1}'", Entidades.ReservaTurismoPasajero.Columnas.LetraComprobanteFact.ToString(), letraActual)
         .AppendFormatLine("     AND {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.CentroEmisorComprobanteFact.ToString(), centroEmisorActual)
         .AppendFormatLine("     AND {0} =  {1} ", Entidades.ReservaTurismoPasajero.Columnas.NumeroComprobanteFact.ToString(), numeroComprobanteActual)
      End With
      Execute(myQuery)
   End Sub

End Class