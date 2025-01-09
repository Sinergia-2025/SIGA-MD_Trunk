Public Class Impuestos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Impuestos_I(idTipoImpuesto As String, alicuota As Decimal, activo As Boolean,
                          idTipoImpuestoPIVA As String, alicuotaPIVA As Decimal?,
                          idCuentaCompras As Long?, idCuentaVentas As Long?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Impuestos ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                       Entidades.Impuesto.Columnas.IdTipoImpuesto.ToString(),
                       Entidades.Impuesto.Columnas.Alicuota.ToString(),
                       Entidades.Impuesto.Columnas.Activo.ToString(),
                       Entidades.Impuesto.Columnas.IdTipoImpuestoPIVA.ToString(),
                       Entidades.Impuesto.Columnas.AlicuotaPIVA.ToString(),
                       Entidades.Impuesto.Columnas.IdCuentaCompras.ToString(),
                       Entidades.Impuesto.Columnas.IdCuentaVentas.ToString())
         .AppendFormatLine(" VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6})",
                       idTipoImpuesto,
                       alicuota,
                       GetStringFromBoolean(activo),
                       GetStringParaQueryConComillas(idTipoImpuestoPIVA),
                       GetStringFromDecimal(alicuotaPIVA),
                       GetStringFromNumber(idCuentaCompras),
                       GetStringFromNumber(idCuentaVentas))
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Impuestos")
   End Sub
   Public Sub Impuestos_U(idTipoImpuesto As String, alicuota As Decimal, activo As Boolean,
                          idTipoImpuestoPIVA As String, alicuotaPIVA As Decimal?,
                          idCuentaCompras As Long?, idCuentaVentas As Long?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Impuestos ").AppendLine()
         .AppendFormatLine("   SET Activo = '{0}'", GetStringFromBoolean(activo))
         .AppendFormatLine("     , IdTipoImpuestoPIVA = {0}", GetStringParaQueryConComillas(idTipoImpuestoPIVA))
         .AppendFormatLine("     , AlicuotaPIVA = {0}", GetStringFromDecimal(alicuotaPIVA))
         .AppendFormatLine("     , IdCuentaCompras = {0}", GetStringFromNumber(idCuentaCompras))
         .AppendFormatLine("     , IdCuentaVentas = {0}", GetStringFromNumber(idCuentaVentas))
         .AppendFormatLine("  WHERE IdTipoImpuesto = '{0}'", idTipoImpuesto)
         .AppendFormatLine("    AND Alicuota = {0}", alicuota)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Impuestos")
   End Sub
   Public Sub Impuestos_D(idTipoImpuesto As String, alicuota As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM Impuestos ")
         .AppendFormatLine("  WHERE IdTipoImpuesto = '{0}'", idTipoImpuesto)
         .AppendFormatLine("    AND Alicuota = {0}", alicuota)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Impuestos")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT I.*")
         .AppendFormatLine("     , TI.NombreTipoImpuesto")
         .AppendFormatLine("     , TIPIVA.NombreTipoImpuesto NombreTipoImpuestoPIVA")
         .AppendFormatLine("     , CC.{0} {1}", Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString(), Entidades.Impuesto.ColumnasDescripcion.NombreCuentaCompras.ToString())
         .AppendFormatLine("     , CV.{0} {1}", Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString(), Entidades.Impuesto.ColumnasDescripcion.NombreCuentaVentas.ToString())
         .AppendFormatLine("  FROM Impuestos I")
         .AppendFormatLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = I.IdTipoImpuesto")
         .AppendFormatLine("  LEFT JOIN ContabilidadCuentas CC ON CC.IdCuenta = I.IdCuentaCompras")
         .AppendFormatLine("  LEFT JOIN ContabilidadCuentas CV ON CV.IdCuenta = I.IdCuentaVentas")
         .AppendFormatLine("  LEFT JOIN TiposImpuestos TIPIVA ON TIPIVA.IdTipoImpuesto = I.IdTipoImpuestoPIVA")
      End With
   End Sub

   Public Function Impuestos_GA(idTipoImpuesto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         If Not String.IsNullOrWhiteSpace(idTipoImpuesto) Then
            .AppendFormatLine(" WHERE I.IdTipoImpuesto = '{0}'", idTipoImpuesto)
         End If
         .AppendFormatLine(" ORDER BY TI.NombreTipoImpuesto, I.Alicuota")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function Impuestos_G1(idTipoImpuesto As String, alicuota As Decimal) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE I.IdTipoImpuesto = '{0}'", idTipoImpuesto)
         .AppendFormatLine("   AND I.Alicuota = {0}", alicuota)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetIVAs() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE I.IdTipoImpuesto = '{0}' AND I.Activo = 'True' ", Entidades.TipoImpuesto.Tipos.IVA.ToString())
         .AppendFormatLine(" ORDER BY I.Alicuota ")
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "I.",
                    New Dictionary(Of String, String) From {{"NombreTipoImpuesto", "TI.NombreTipoImpuesto"},
                                                            {"NombreCuentaCompras", "CC.NombreCuenta"},
                                                            {"NombreCuentaVentas", "CV.NombreCuenta"},
                                                            {"NombreTipoImpuestoPIVA", "TIPIVA.NombreTipoImpuesto"}})
   End Function
End Class