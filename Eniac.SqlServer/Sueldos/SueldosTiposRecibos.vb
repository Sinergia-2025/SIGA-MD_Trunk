Public Class SueldosTiposRecibos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SueldosTiposRecibos_I(idTipoRecibo As Integer,
                                    nombreTipoRecibo As String,
                                    periodoLiquidacion As Integer,
                                    numeroLiquidacion As Integer,
                                    imprimeRecibo As Boolean,
                                    cantidadLiquid As Integer,
                                    cantidadLiquidPeriodo As Integer,
                                    fechaPago As Date,
                                    liquidacionEventual As Boolean)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("INSERT INTO SueldosTiposRecibos (")
         .Append("           IdTipoRecibo")
         .Append("           ,NombreTipoRecibo")
         .Append("           ,PeriodoLiquidacion")
         .Append("           ,NumeroLiquidacion")
         .Append("           ,ImprimeRecibo")
         .Append("           ,CantidadLiquid")
         .Append("           ,CantidadLiquidPeriodo")
         .Append("           ,FechaPago")
         .Append("           ,LiquidacionEventual")
         .Append(")     VALUES(")
         .AppendFormat("           {0}", idTipoRecibo)
         .AppendFormat("           ,'{0}'", nombreTipoRecibo)
         .AppendFormat("           ,{0}", periodoLiquidacion)
         .AppendFormat("           ,{0}", numeroLiquidacion)
         .AppendFormat("            ,{0}", Me.GetStringFromBoolean(imprimeRecibo))
         .AppendFormat("           ,{0}", cantidadLiquid)
         .AppendFormat("           ,{0}", cantidadLiquidPeriodo)
         .AppendFormat("           ,'{0}'", fechaPago.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("            ,{0}", Me.GetStringFromBoolean(liquidacionEventual))
         .Append(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosTiposRecibos")
   End Sub

   Public Sub SueldosTiposRecibos_U(IdTipoRecibo As Integer,
                                    NombreTipoRecibo As String,
                                    PeriodoLiquidacion As Integer,
                                    NumeroLiquidacion As Integer,
                                    ImprimeRecibo As Boolean,
                                    CantidadLiquid As Integer,
                                       CantidadLiquidPeriodo As Integer,
                                       FechaPago As Date,
                                       liquidacionEventual As Boolean)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE SueldosTiposRecibos SET ")
         .AppendFormat("      NombreTipoRecibo = '{0}'", NombreTipoRecibo)
         .AppendFormat("      ,PeriodoLiquidacion = {0}", PeriodoLiquidacion)
         .AppendFormat("      ,NumeroLiquidacion = {0}", NumeroLiquidacion)
         .AppendFormat("      ,ImprimeRecibo = {0}", Me.GetStringFromBoolean(ImprimeRecibo))
         .AppendFormat("      ,CantidadLiquid = {0}", CantidadLiquid)
         .AppendFormat("      ,CantidadLiquidPeriodo = {0}", CantidadLiquidPeriodo)
         .AppendFormat("      ,FechaPago = '{0}'", FechaPago.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("      ,LiquidacionEventual = {0}", Me.GetStringFromBoolean(liquidacionEventual))
         .Append(" WHERE ")
         .AppendFormat("      IdTipoRecibo = {0}", IdTipoRecibo)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosTiposRecibos")
   End Sub

   Public Sub SueldosTiposRecibos_U_PeriodoYNumeroLiquidacion(
                           idTipoRecibo As Integer,
                           periodoLiquidacion As Integer, numeroLiquidacion As Integer,
                           cantidadLiqPeriodo As Integer, fechaPago As Date)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("UPDATE SueldosTiposRecibos")
         .AppendFormatLine("   SET PeriodoLiquidacion    = {0}", periodoLiquidacion)
         .AppendFormatLine("     , NumeroLiquidacion     = {0}", numeroLiquidacion)
         .AppendFormatLine("     , CantidadLiquidPeriodo = {0}", cantidadLiqPeriodo)
         .AppendFormatLine("     , FechaPago             = '{0}'", ObtenerFecha(fechaPago, True))
         .AppendFormatLine(" WHERE IdTipoRecibo = {0}", idTipoRecibo)
      End With

      Execute(qry)
      Sincroniza_I(qry.ToString(), "SueldosTiposRecibos")
   End Sub

   Public Sub SueldosTiposRecibos_U_CantidadLiquidacionesPeriodo(IdTipoRecibo As Integer)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE SueldosTiposRecibos SET ")
         .AppendFormat("      CantidadLiquidPeriodo = 0")
         .Append(" WHERE ")
         .AppendFormat("      IdTipoRecibo = {0}", IdTipoRecibo)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosTiposRecibos")
   End Sub

   Public Sub SueldosTiposRecibos_D(IdTipoRecibo As Integer)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("DELETE FROM SueldosTiposRecibos WHERE ")
         .AppendFormat("      IdTipoRecibo = {0}", IdTipoRecibo)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosTiposRecibos")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT STR.IdTipoRecibo")
         .AppendFormatLine("     , STR.NombreTipoRecibo")
         .AppendFormatLine("     , STR.PeriodoLiquidacion")
         .AppendFormatLine("     , STR.NumeroLiquidacion")
         .AppendFormatLine("     , STR.ImprimeRecibo")
         .AppendFormatLine("     , STR.CantidadLiquid")
         .AppendFormatLine("     , STR.CantidadLiquidPeriodo")
         .AppendFormatLine("     , STR.FechaPago")
         .AppendFormatLine("     , STR.LiquidacionEventual")
         .AppendFormatLine("  FROM SueldosTiposRecibos STR")
      End With
   End Sub


   Public Function SueldosTiposRecibos_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function SueldosTiposRecibos_G1(IdTipoRecibo As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append(" WHERE ")
         .AppendFormat("      STR.IdTipoRecibo = {0}", IdTipoRecibo)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "STR.")
   End Function

End Class