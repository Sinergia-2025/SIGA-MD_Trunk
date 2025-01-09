Public Class Reservas
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Reservas_I(idReserva As Long,
                         idEmbarcacion As Long,
                         idCliente As Long,
                         idTurnoUnico As String,
                         cantidadPasajeros As Integer,
                         fechaHoraSalida As DateTime,
                         fechaHoraLlegada As DateTime,
                         idDestino As Integer,
                         destinoLibre As String,
                         idNave As Short,
                         idTimonel As Long,
                         fechaSolicitud As DateTime,
                         esEfectiva As Boolean,
                         estado As String,
                         activo As Boolean,
                         usuarioSolicitud As String)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO Reservas (")
         .AppendFormatLine("       IdReserva")
         .AppendFormatLine("     , IdEmbarcacion")
         .AppendFormatLine("     , IdCliente")
         .AppendFormatLine("     , IdTurnoUnico")
         .AppendFormatLine("     , CantidadPasajeros")
         .AppendFormatLine("     , FechaHoraSalida")
         .AppendFormatLine("     , FechaHoraLlegada")
         .AppendFormatLine("     , IdDestino")
         .AppendFormatLine("     , DestinoLibre")
         .AppendFormatLine("     , EsEfectiva")
         .AppendFormatLine("     , Estado")
         .AppendFormatLine("     , Activo")
         .AppendFormatLine("     , IdTimonel")
         .AppendFormatLine("     , FechaSolicitud")
         .AppendFormatLine("     , IdNave")
         .AppendFormatLine("     , UsuarioSolicitud")
         .AppendFormatLine("     ) VALUES (")
         .AppendFormat("            {0} ", idReserva)
         .AppendFormat("         ,  {0} ", idEmbarcacion)
         .AppendFormat("         ,  {0} ", idCliente)
         .AppendFormat("         , '{0}'", idTurnoUnico)
         .AppendFormat("         ,  {0} ", cantidadPasajeros)
         .AppendFormat("         , '{0}'", ObtenerFecha(fechaHoraSalida, True))
         .AppendFormat("         , '{0}'", ObtenerFecha(fechaHoraLlegada, True))
         .AppendFormat("         ,  {0} ", idDestino)
         .AppendFormat("         , '{0}'", destinoLibre)
         .AppendFormat("         ,  {0} ", Me.GetStringFromBoolean(esEfectiva))
         .AppendFormat("         , '{0}'", estado)
         .AppendFormat("         ,  {0} ", Me.GetStringFromBoolean(activo))
         .AppendFormat("         ,  {0} ", idTimonel)
         .AppendFormat("         , '{0}'", ObtenerFecha(fechaSolicitud, True))
         .AppendFormat("         ,  {0} ", idNave)
         .AppendFormat("         , '{0}'", usuarioSolicitud)
         .Append("           )")
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "Reservas")
   End Sub

   Public Sub Reservas_U_Estado(idReserva As Long, estado As String, idNave As Short)
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormatLine("UPDATE Reservas")
         .AppendFormatLine("  SET Estado = '{0}'", estado)
         .AppendFormatLine("    , IdNave =  {0} ", idNave)
         .AppendFormatLine(" WHERE IdReserva = {0}", idReserva)
      End With

      Me.Execute(stb.ToString())

      'Dim reservaEstado As New Eniac.SiSeN.Entidades.ReservaEstado
      'reservaEstado.IdReserva = res.IdReserva
      'reservaEstado.Estado = res.Estado
      'reservaEstado.IdClienteOperacion = res.Cliente.IdCliente
      'reservaEstado.Usuario = res.Usuario

      'Me.InsertarReservasEstados(reservaEstado)

   End Sub


   Public Sub ReservaEstado_I(idReserva As Long, fecha As DateTime, estado As String, usuario As String, idCliente As Long)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO ReservasEstados (")
         .AppendFormatLine("       IdReserva")
         .AppendFormatLine("     , Fecha")
         .AppendFormatLine("     , Estado")
         .AppendFormatLine("     , IdUsuario")
         .AppendFormatLine("     , IdClienteOperacion")
         .AppendFormatLine("     ) VALUES (")
         .AppendFormatLine("        {0} ", idReserva)
         .AppendFormatLine("     , '{0}'", ObtenerFecha(fecha, True))
         .AppendFormatLine("     , '{0}'", estado)
         .AppendFormatLine("     , '{0}'", usuario)
         .AppendFormatLine("     ,  {0} ", idCliente)
         .AppendFormatLine("     )")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Function Reservas_GA() As DataTable
      Return Reservas_G(idReserva:=0, idTurnoUnico:=String.Empty)
   End Function
   Public Function Reservas_G1(idReserva As Long) As DataTable
      Return Reservas_G(idReserva:=idReserva, idTurnoUnico:=String.Empty)
   End Function
   Public Function Reservas_G1(idTurnoUnico As String) As DataTable
      Return Reservas_G(idReserva:=0, idTurnoUnico:=idTurnoUnico)
   End Function
   Private Function Reservas_G(idReserva As Long, idTurnoUnico As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT R.*")
         .AppendFormatLine("  FROM Reservas R")
         .AppendFormatLine(" WHERE 1 = 1")
         If idReserva > 0 Then
            .AppendFormatLine("   AND R.IdReserva = {0}", idReserva)
         End If
         If Not String.IsNullOrWhiteSpace(idTurnoUnico) Then
            .AppendFormatLine("   AND R.IdTurnoUnico = '{0}'", idTurnoUnico)
         End If
      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Long
      Return GetCodigoMaximo("IdReserva", "Reservas")
   End Function

End Class