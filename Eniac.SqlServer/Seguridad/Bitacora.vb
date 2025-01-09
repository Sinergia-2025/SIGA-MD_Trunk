Public Class Bitacora
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Bitacora_I(idSucursal As Integer,
                         idBitacora As Integer,
                         fechaBitacora As DateTime,
                         idFuncion As String,
                         idUsuario As String,
                         nombrePC As String,
                         tipo As String,
                         descripcion As String)

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO Bitacora (")
         .AppendFormatLine("      IdSucursal")
         .AppendFormatLine("    , IdBitacora")
         .AppendFormatLine("    , FechaBitacora")
         .AppendFormatLine("    , IdFuncion")
         .AppendFormatLine("    , IdUsuario")
         .AppendFormatLine("    , NombrePC")
         .AppendFormatLine("    , Tipo")
         .AppendFormatLine("    , Descripcion")
         .AppendFormatLine("    ) VALUES (")
         .AppendFormatLine("      {0} ", idSucursal)
         If idBitacora < 0 Then
            .AppendFormatLine("    , (SELECT MAX(IdBitacora) + 1 FROM Bitacora WHERE IdSucursal = {0}) ", idSucursal)
         Else
            .AppendFormatLine("    , {0} ", idBitacora)
         End If
         .AppendFormatLine("    ,'{0}'", ObtenerFecha(fechaBitacora, True, True))
         .AppendFormatLine("    ,'{0}'", idFuncion)
         .AppendFormatLine("    ,'{0}'", idUsuario)
         .AppendFormatLine("    ,'{0}'", nombrePC)
         .AppendFormatLine("    ,'{0}'", tipo)
         .AppendFormatLine("    ,'{0}'", descripcion)
         .AppendFormatLine("    )")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub Bitacora_D(IdSucursal As Integer, idBitacora As Integer)
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Append("DELETE FROM Bitacora")
         .AppendFormat(" WHERE IdSucursal = {0}", IdSucursal)
         .AppendFormat(" AND IdBitacora = {0}", idBitacora)
      End With

      Me.Execute(stb.ToString())
   End Sub
   Public Sub Bitacora_D_PorFechaTipo(fechaBitacoraDesde As DateTime?, fechaBitacoraHasta As DateTime?, tipoBitacora As String)
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormatLine("DELETE FROM Bitacora")
         .AppendFormatLine(" WHERE Tipo = '{0}'", tipoBitacora)
         If fechaBitacoraDesde.HasValue Then
            .AppendFormatLine("   AND FechaBitacora >= '{0}'", ObtenerFecha(fechaBitacoraDesde.Value, True))
         End If
         If fechaBitacoraHasta.HasValue Then
            .AppendFormatLine("   AND FechaBitacora <= '{0}'", ObtenerFecha(fechaBitacoraHasta.Value, True))
         End If
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT IdSucursal")
         .AppendLine("     ,B.IdBitacora")
         .AppendLine("     ,B.FechaBitacora")
         .AppendLine("     ,B.IdFuncion")
         .AppendLine("     ,F.Nombre")
         .AppendLine("     ,B.IdUsuario")
         .AppendLine("     ,B.NombrePC")
         .AppendLine("     ,B.Tipo")
         .AppendLine("     ,B.Descripcion")
         .AppendLine("  FROM Bitacora B")
         .AppendLine("  INNER JOIN Funciones F ON F.Id = B.IdFuncion")
      End With
   End Sub

   Public Function Bitacora_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY IdSucursal, IdBitacora")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Bitacora_GA(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date,
                               idUsuario As String, idFuncion As String, descripcion As String,
                               nombrePC As String, tipoBitacora As Entidades.Bitacora.TipoBitacora?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("   WHERE B.{0} = {1}", Entidades.Bitacora.Columnas.IdSucursal.ToString(), idSucursal)

         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendFormatLine("   AND B.{0} >= '{1}'", Entidades.Bitacora.Columnas.FechaBitacora.ToString(), ObtenerFecha(fechaDesde, True))
            .AppendFormatLine("   AND B.{0} <= '{1}'", Entidades.Bitacora.Columnas.FechaBitacora.ToString(), ObtenerFecha(fechaHasta, True))
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormat("   AND B.{0} = '{1}'", Entidades.Bitacora.Columnas.IdUsuario.ToString(), idUsuario)
         End If

         If Not String.IsNullOrEmpty(idFuncion) Then
            .AppendFormat("   AND B.{0} = '{1}'", Entidades.Bitacora.Columnas.IdFuncion.ToString(), idFuncion)
         End If

         If Not String.IsNullOrEmpty(Descripcion) Then
            .AppendFormat("   AND B.{0} LIKE '%{1}%'", Entidades.Bitacora.Columnas.Descripcion.ToString(), Descripcion)
         End If

         If Not String.IsNullOrEmpty(nombrePC) Then
            .AppendFormat("   AND B.{0} = '{1}'", Entidades.Bitacora.Columnas.NombrePC.ToString(), nombrePC)
         End If

         If tipoBitacora.HasValue Then
            .AppendFormat("   AND B.{0} = '{1}'", Entidades.Bitacora.Columnas.Tipo.ToString(), tipoBitacora.ToString())
         End If

         .Append("  ORDER BY B.FechaBitacora")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function


   Public Function Bitacora_G1(idSucursal As Integer, idBitacora As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE IdSucursal = {0}", IdSucursal)
         .AppendFormat("   AND IdBitacora = {0}", idBitacora)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      columna = "U." + columna
      'If columna = "D.NombreLocalidad" Then columna = columna.Replace("D.", "L.")
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Protected Overrides Sub GrabarErrorEnBitacora(mensaje As String)
      'Si me da error al querer actualizar una bitacora me va a querer grabar en bitacora volviendo a dar el error.
      'No es tan relevante grabar error de bitacora cuando da error la bitacora.
      'MyBase.GrabarErrorEnBitacora(mensaje)
   End Sub

End Class