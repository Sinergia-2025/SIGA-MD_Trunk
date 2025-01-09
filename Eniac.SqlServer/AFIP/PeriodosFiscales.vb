Public Class PeriodosFiscales
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PeriodosFiscales_I(idEmpresa As Integer, periodoFiscal As Integer,
                                 totalNetoVentas As Decimal, totalImpuestosVentas As Decimal, totalVentas As Decimal,
                                 totalNetoCompras As Decimal, totalImpuestosCompras As Decimal, totalCompras As Decimal,
                                 posicion As Decimal,
                                 totalRetenciones As Decimal, totalPercepciones As Decimal,
                                 posicionFinal As Decimal,
                                 fechaCierre As Date, usuarioCierre As String, ventasHabilitadas As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO PeriodosFiscales")
         .AppendFormatLine("   (IdEmpresa")
         .AppendFormatLine("   ,PeriodoFiscal")
         .AppendFormatLine("   ,TotalNetoVentas")
         .AppendFormatLine("   ,TotalImpuestosVentas")
         .AppendFormatLine("   ,TotalVentas")
         .AppendFormatLine("   ,TotalNetoCompras")
         .AppendFormatLine("   ,TotalImpuestosCompras")
         .AppendFormatLine("   ,TotalCompras")
         .AppendFormatLine("   ,Posicion")
         .AppendFormatLine("   ,TotalRetenciones")
         .AppendFormatLine("   ,TotalPercepciones")
         .AppendFormatLine("   ,PosicionFinal")
         .AppendFormatLine("   ,FechaCierre")
         .AppendFormatLine("   ,UsuarioCierre")
         .AppendFormatLine("   ,VentasHabilitadas")
         .AppendFormatLine("  ) VALUES (")
         .AppendFormatLine("    {0}", idEmpresa)
         .AppendFormatLine("   ,{0}", periodoFiscal)
         .AppendFormatLine("   ,{0}", totalNetoVentas)
         .AppendFormatLine("   ,{0}", totalImpuestosVentas)
         .AppendFormatLine("   ,{0}", totalVentas)
         .AppendFormatLine("   ,{0}", totalNetoCompras)
         .AppendFormatLine("   ,{0}", totalImpuestosCompras)
         .AppendFormatLine("   ,{0}", totalCompras)
         .AppendFormatLine("   ,{0}", posicion)
         .AppendFormatLine("   ,{0}", totalRetenciones)
         .AppendFormatLine("   ,{0}", totalPercepciones)
         .AppendFormatLine("   ,{0}", posicionFinal)

         If Not String.IsNullOrEmpty(usuarioCierre) Then
            .AppendFormatLine("   ,'{0}'", ObtenerFecha(fechaCierre, False))
            .AppendFormatLine("   ,'{0}'", usuarioCierre)
         Else
            .AppendFormatLine("   ,NULL")
            .AppendFormatLine("   ,NULL")
         End If

         .AppendFormatLine("   ,{0}", GetStringFromBoolean(ventasHabilitadas))

         .AppendFormatLine("   )")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "PeriodosFiscales")
   End Sub

   Public Sub PeriodosFiscales_U(idEmpresa As Integer, periodoFiscal As Integer,
                                 totalNetoVentas As Decimal, totalImpuestosVentas As Decimal, totalVentas As Decimal,
                                 totalNetoCompras As Decimal, totalImpuestosCompras As Decimal, totalCompras As Decimal,
                                 posicion As Decimal,
                                 totalRetenciones As Decimal, totalPercepciones As Decimal,
                                 posicionFinal As Decimal,
                                 fechaCierre As Date, usuarioCierre As String, ventasHabilitadas As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE PeriodosFiscales ")
         .AppendFormatLine("   SET TotalNetoVentas = {0}", totalNetoVentas)
         .AppendFormatLine("      ,TotalImpuestosVentas = {0}", totalImpuestosVentas)
         .AppendFormatLine("      ,TotalVentas = {0}", totalVentas)
         .AppendFormatLine("      ,TotalNetoCompras = {0}", totalNetoCompras)
         .AppendFormatLine("      ,TotalImpuestosCompras = {0}", totalImpuestosCompras)
         .AppendFormatLine("      ,TotalCompras = {0}", totalCompras)
         .AppendFormatLine("      ,Posicion = {0}", posicion)
         .AppendFormatLine("      ,TotalRetenciones = {0}", totalRetenciones)
         .AppendFormatLine("      ,TotalPercepciones = {0}", totalPercepciones)
         .AppendFormatLine("      ,PosicionFinal = {0}", posicionFinal)

         If Not String.IsNullOrEmpty(usuarioCierre) Then
            .AppendFormatLine("      ,FechaCierre = '{0}'", ObtenerFecha(fechaCierre, False))
            .AppendFormatLine("      ,UsuarioCierre = '{0}'", usuarioCierre)
         Else
            .AppendFormatLine("      ,FechaCierre = NULL")
            .AppendFormatLine("      ,UsuarioCierre = NULL")
         End If

         .AppendFormatLine("      ,VentasHabilitadas = {0}", GetStringFromBoolean(ventasHabilitadas))

         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND PeriodoFiscal = {0}", periodoFiscal)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "PeriodosFiscales")

   End Sub

   Public Sub PeriodosFiscales_D(idEmpresa As Integer, periodoFiscal As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM PeriodosFiscales")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", periodoFiscal)
         .AppendFormatLine("   AND PeriodoFiscal = {0}", periodoFiscal)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "PeriodosFiscales")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT PF.*")
         .AppendLine("  FROM PeriodosFiscales PF")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "PF.")
   End Function

   Public Function PeriodosFiscales_GA(idEmpresa As Integer) As DataTable
      Return PeriodosFiscales_GA(idEmpresa, estado:="TODOS")
   End Function

   Public Function PeriodosFiscales_GA(idEmpresa As Integer, estado As String) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE PF.IdEmpresa = {0}", idEmpresa)
         If estado <> "TODOS" Then
            .AppendFormatLine("   AND PF.FechaCierre IS {0} NULL", If(estado = "ABIERTO", "", "NOT"))
         End If
         .AppendLine("  ORDER BY PF.PeriodoFiscal DESC")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function PeriodosFiscales_G1(idEmpresa As Integer, periodoFiscal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine("  WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("    AND PeriodoFiscal = {0}", periodoFiscal)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function PeriodosFiscales_GetPeriodoMaximo(idEmpresa As Integer) As Integer
      Return Convert.ToInt32(GetCodigoMaximo("PeriodoFiscal", "PeriodosFiscales", String.Format("IdEmpresa = {0}", idEmpresa)))
   End Function

   Public Sub PeriodosFiscales_UPosicion(idEmpresa As Integer, periodoFiscal As Integer,
                                         importeNetoVentas As Decimal, importeImpuestosVentas As Decimal, importeVentas As Decimal,
                                         importeNetoCompras As Decimal, importeImpuestosCompras As Decimal, importeCompras As Decimal,
                                         importeRetenciones As Decimal, importePercepciones As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE PeriodosFiscales")
         .AppendFormatLine("   SET TotalNetoVentas = TotalNetoVentas + {0}", importeNetoVentas)
         .AppendFormatLine("     , TotalImpuestosVentas = TotalImpuestosVentas + {0}", importeImpuestosVentas)
         .AppendFormatLine("     , TotalVentas = TotalVentas + {0}", importeVentas)
         .AppendFormatLine("     , TotalNetoCompras = TotalNetoCompras + {0}", importeNetoCompras)
         .AppendFormatLine("     , TotalImpuestosCompras = TotalImpuestosCompras + {0}", importeImpuestosCompras)
         .AppendFormatLine("     , TotalCompras = TotalCompras + {0}", importeCompras)
         .AppendFormatLine("     , TotalRetenciones = TotalRetenciones + {0}", importeRetenciones)
         .AppendFormatLine("     , TotalPercepciones = TotalPercepciones + {0}", importePercepciones)
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND PeriodoFiscal = {0}", periodoFiscal)
      End With
      Dim cantidadRegistros = Execute(myQuery)
      If cantidadRegistros = 0 Then
         Throw New Exception(String.Format("La Fecha del Comprobante pertenece a un Periodo Fiscal ({0}) que aún NO esta habilitado.", periodoFiscal))
      End If

      Sincroniza_I(myQuery.ToString(), "PeriodosFiscales")

      With myQuery
         .Length = 0
         .AppendFormatLine("UPDATE PeriodosFiscales SET")
         .AppendFormatLine("       Posicion = TotalImpuestosVentas - TotalImpuestosCompras")
         .AppendFormatLine("      ,PosicionFinal = TotalImpuestosVentas - TotalImpuestosCompras - TotalRetenciones - TotalPercepciones")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND PeriodoFiscal = {0}", periodoFiscal)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "PeriodosFiscales")

   End Sub

End Class