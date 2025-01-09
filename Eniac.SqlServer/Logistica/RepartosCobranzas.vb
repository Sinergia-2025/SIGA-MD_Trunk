Public Class RepartosCobranzas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RepartosCobranzas_I(idSucursal As Integer,
                                  idReparto As Integer,
                                  idCobranza As Integer,
                                  fechaRendicion As DateTime,
                                  idCaja As Integer,
                                  fechaAlta As DateTime,
                                  idUsuarioAlta As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.RepartoCobranza.NombreTabla)
         .AppendFormatLine("            {0}", Entidades.RepartoCobranza.Columnas.IdSucursal.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranza.Columnas.IdReparto.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranza.Columnas.IdCobranza.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranza.Columnas.FechaRendicion.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranza.Columnas.IdCaja.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranza.Columnas.FechaAlta.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranza.Columnas.IdUsuarioAlta.ToString())
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("            {0} ", idSucursal)
         .AppendFormatLine("          , {0} ", idReparto)
         .AppendFormatLine("          , {0} ", idCobranza)
         .AppendFormatLine("          ,'{0}'", ObtenerFecha(fechaRendicion, False))
         .AppendFormatLine("          , {0} ", idCaja)
         .AppendFormatLine("          ,'{0}'", ObtenerFecha(fechaAlta, True))
         .AppendFormatLine("          ,'{0}'", idUsuarioAlta)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosCobranzas_U(idSucursal As Integer,
                                  idReparto As Integer,
                                  idCobranza As Integer,
                                  fechaRendicion As DateTime,
                                  idCaja As Integer,
                                  fechaAlta As DateTime,
                                  idUsuarioAlta As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.RepartoCobranza.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.RepartoCobranza.Columnas.FechaRendicion.ToString(), ObtenerFecha(fechaRendicion, False))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranza.Columnas.IdCaja.ToString(), idCaja)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RepartoCobranza.Columnas.FechaAlta.ToString(), ObtenerFecha(fechaAlta, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RepartoCobranza.Columnas.IdUsuarioAlta.ToString(), idUsuarioAlta)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoCobranza.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranza.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranza.Columnas.IdCobranza.ToString(), idCobranza)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosCobranzas_D(idSucursal As Integer, idReparto As Integer, idCobranza As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.RepartoCobranza.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoCobranza.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranza.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranza.Columnas.IdCobranza.ToString(), idCobranza)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RB.*")
         .AppendFormatLine("  FROM {0} AS RB", Entidades.RepartoCobranza.NombreTabla)
      End With
   End Sub

   Public Function RepartosCobranzas_GA() As DataTable
      Return RepartosCobranzas_G(idSucursal:=0, idReparto:=0, idCobranza:=0)
   End Function
   Private Function RepartosCobranzas_G(idSucursal As Integer, idReparto As Integer, idCobranza As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")

         If idSucursal <> 0 Then
            .AppendFormatLine("   AND RB.{0} =  {1} ", Entidades.RepartoCobranza.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idReparto <> 0 Then
            .AppendFormatLine("   AND RB.{0} =  {1} ", Entidades.RepartoCobranza.Columnas.IdReparto.ToString(), idReparto)
         End If
         If idCobranza <> 0 Then
            .AppendFormatLine("   AND RB.{0} =  {1} ", Entidades.RepartoCobranza.Columnas.IdCobranza.ToString(), idCobranza)
         End If

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function RepartosCobranzas_G1(idSucursal As Integer, idReparto As Integer, idCobranza As Integer) As DataTable
      Return RepartosCobranzas_G(idSucursal, idReparto, idCobranza)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      'If columna = "NombreTipoNovedad" Then
      '   columna = "TN." + columna
      'ElseIf columna = "PorDefecto_SN" Then
      '   columna = "CASE WHEN TCN.PorDefecto = 0 THEN 'NO' ELSE 'SI' END"
      'ElseIf columna = "VisibleParaCliente_SN" Then
      '   columna = "CASE WHEN TCN.VisibleParaCliente = 0 THEN 'NO' ELSE 'SI' END"
      'ElseIf columna = "VisibleParaRepresentante_SN" Then
      '   columna = "CASE WHEN TCN.VisibleParaRepresentante = 0 THEN 'NO' ELSE 'SI' END"
      'Else
      columna = "RB." + columna
      ''End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetMaximoIdCobranza(idSucursal As Integer, idReparto As Integer) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.RepartoCobranza.Columnas.IdCobranza.ToString, Entidades.RepartoCobranza.NombreTabla,
                                             String.Format("{0} = {1} AND {2} = {3} AND {4} > 0",
                                                           Entidades.RepartoCobranza.Columnas.IdSucursal.ToString(), idSucursal,
                                                           Entidades.RepartoCobranza.Columnas.IdReparto.ToString(), idReparto,
                                                           Entidades.RepartoCobranza.Columnas.IdCobranza.ToString())))
   End Function

End Class