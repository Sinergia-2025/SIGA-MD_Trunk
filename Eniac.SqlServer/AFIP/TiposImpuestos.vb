Public Class TiposImpuestos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposImpuestos_I(idtipoImpuesto As Entidades.TipoImpuesto.Tipos,
                               nombreTipoImpuesto As String,
                               tipo As String,
                               idCuentaDebe As Long,
                               idCuentaHaber As Long,
                               idCuentaCaja As Integer,
                               aplicativoAfip As String,
                               codigoArticuloInciso As String,
                               articuloInciso As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO TiposImpuestos")
         .AppendFormatLine("  (IdTipoImpuesto")
         .AppendFormatLine("  ,NombreTipoImpuesto")
         .AppendFormatLine("  ,Tipo")
         .AppendFormatLine("  ,idCuentaDebe")
         .AppendFormatLine("  ,idCuentaHaber")
         .AppendFormatLine("  ,idCuentaDeCaja")
         .AppendFormatLine("  ,AplicativoAfip")
         .AppendFormatLine("  ,CodigoArticuloInciso")
         .AppendFormatLine("  ,ArticuloInciso")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("  '{0}'", idtipoImpuesto)
         .AppendFormatLine(" ,'{0}'", nombreTipoImpuesto)
         .AppendFormatLine(" ,'{0}'", tipo)

         .AppendFormatLine(" , {0} ", GetStringFromNumber(idCuentaDebe))
         .AppendFormatLine(" , {0} ", GetStringFromNumber(idCuentaHaber))
         .AppendFormatLine(" , {0} ", GetStringFromNumber(idCuentaCaja))

         .AppendFormatLine(" , {0} ", GetStringParaQueryConComillas(aplicativoAfip))

         .AppendFormatLine(" ,'{0}'", codigoArticuloInciso)
         .AppendFormatLine(" ,'{0}'", articuloInciso)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "TiposImpuestos")
   End Sub

   Public Sub TiposImpuestos_U(idtipoImpuesto As Entidades.TipoImpuesto.Tipos,
                               nombreTipoImpuesto As String,
                               tipo As String,
                               idCuentaDebe As Long,
                               idCuentaHaber As Long,
                               idCuentaCaja As Integer,
                               aplicativoAfip As String,
                               codigoArticuloInciso As String,
                               articuloInciso As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE TiposImpuestos SET ")
         .AppendFormatLine("     NombreTipoImpuesto = '{0}'", nombreTipoImpuesto)
         .AppendFormatLine("   , Tipo = '{0}'", tipo)

         .AppendFormatLine("   , IdCuentaDebe = {0}", GetStringFromNumber(idCuentaDebe))
         .AppendFormatLine("   , IdCuentaHaber = {0}", GetStringFromNumber(idCuentaHaber))

         .AppendFormatLine("   , IdCuentaCaja = {0}", GetStringFromNumber(idCuentaCaja))

         .AppendFormatLine("   , AplicativoAfip = {0}", GetStringParaQueryConComillas(aplicativoAfip))
         .AppendFormatLine("   , CodigoArticuloInciso = {0}", GetStringParaQueryConComillas(codigoArticuloInciso))
         .AppendFormatLine("   , ArticuloInciso = {0}", GetStringParaQueryConComillas(articuloInciso))

         .AppendFormatLine(" WHERE IdTipoImpuesto = '{0}'", idtipoImpuesto)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "TiposImpuestos")
   End Sub

   Public Sub TiposImpuestos_D(idtipoImpuestos As Entidades.TipoImpuesto.Tipos)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM TiposImpuestos")
         .AppendFormatLine(" WHERE IdTipoImpuesto = '{0}'", idtipoImpuestos)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "TiposImpuestos")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT TI.*")
         .AppendFormatLine("     , (SELECT CC.NombreCuenta FROM ContabilidadCuentas CC WHERE CC.idCuenta = TI.idCuentaDebe) AS NombreCuentaDebe")
         .AppendFormatLine("     , (SELECT CC.NombreCuenta FROM ContabilidadCuentas CC where CC.idCuenta = TI.idCuentaHaber) AS NombreCuentaHaber")
         .AppendFormatLine("     , (SELECT CDC.NombreCuentaCaja FROM CuentasDeCajas CDC where CDC.idCuentaCaja = TI.idCuentaCaja) AS NombreCuentaCaja")
         .AppendFormatLine("  FROM TiposImpuestos TI")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), "TI.",
                    New Dictionary(Of String, String) From
                    {{"NombreCuentaDebe", "(SELECT CC.NombreCuenta FROM ContabilidadCuentas CC WHERE CC.idCuenta = TI.idCuentaDebe)"},
                     {"NombreCuentaHaber", "(SELECT CC.NombreCuenta FROM ContabilidadCuentas CC where CC.idCuenta = TI.idCuentaHaber)"},
                     {"NombreCuentaCaja", "(SELECT CDC.NombreCuentaCaja FROM CuentasDeCajas CDC where CDC.idCuentaCaja = TI.idCuentaCaja)"}})
   End Function

   Public Function TiposImpuestos_GA() As DataTable
      Dim myQuery = New StringBuilder()
      SelectTexto(myQuery)
      Return GetDataTable(myQuery)
   End Function

   Public Function TiposImpuestos_GA(Tipo As String) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         If Not String.IsNullOrEmpty(Tipo) And Tipo <> "TODOS" Then
            .AppendFormatLine(" WHERE TI.Tipo = '{0}'", Tipo)
         End If
         .AppendFormatLine(" ORDER BY TI.NombreTipoImpuesto DESC")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetAplicativosAfip(tipoTipoImpuesto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT  TI.AplicativoAfip ")
         .AppendFormatLine("   FROM TiposImpuestos TI")
         .AppendFormatLine(" WHERE TI.AplicativoAfip <> '' ")
         If Not String.IsNullOrWhiteSpace(tipoTipoImpuesto) Then
            .AppendFormat("   AND TI.Tipo = '{0}' ", tipoTipoImpuesto)
         End If
      End With
      Return GetDataTable(stb)
   End Function
   Public Function TiposImpuestos_G1(idTipoImpuesto As String) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine("  WHERE IdTipoImpuesto = '{0}'", idTipoImpuesto)
      End With
      Return GetDataTable(stb)
   End Function
End Class