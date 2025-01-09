Public Class RepartosGastos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#Region "Insert/Update/Merge/Delete"
   Public Sub RepartosGastos_I(idSucursal As Integer,
                               idReparto As Integer,
                               idGasto As Integer,
                               idCuentaCaja As Integer,
                               importePesos As Decimal,
                               observacion As String,
                               idCaja As Integer,
                               numeroPlanilla As Integer,
                               numeroMovimiento As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO  {0}  (", Entidades.RepartoGasto.NombreTabla)
         .AppendFormatLine("             {0} ", Entidades.RepartoGasto.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoGasto.Columnas.IdReparto.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoGasto.Columnas.IdGasto.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoGasto.Columnas.IdCuentaCaja.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoGasto.Columnas.ImportePesos.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoGasto.Columnas.Observacion.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoGasto.Columnas.IdCaja.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoGasto.Columnas.NumeroPlanilla.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoGasto.Columnas.NumeroMovimiento.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idSucursal)
         .AppendFormatLine("           , {0} ", idReparto)
         .AppendFormatLine("           , {0} ", idGasto)
         .AppendFormatLine("           , {0} ", idCuentaCaja)
         .AppendFormatLine("           , {0} ", importePesos)
         .AppendFormatLine("           ,'{0}'", observacion)
         .AppendFormatLine("           , {0} ", idCaja)
         .AppendFormatLine("           , {0} ", numeroPlanilla)
         .AppendFormatLine("           , {0} ", numeroMovimiento)

         .AppendFormatLine("           )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosGastos_U(idSucursal As Integer,
                               idReparto As Integer,
                               idGasto As Integer,
                               idCuentaCaja As Integer,
                               importePesos As Decimal,
                               observacion As String,
                               idCaja As Integer,
                               numeroPlanilla As Integer,
                               numeroMovimiento As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.RepartoGasto.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.RepartoGasto.Columnas.IdCuentaCaja.ToString(), idCuentaCaja)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoGasto.Columnas.ImportePesos.ToString(), importePesos)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RepartoGasto.Columnas.Observacion.ToString(), observacion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoGasto.Columnas.IdCaja.ToString(), idCaja)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoGasto.Columnas.NumeroPlanilla.ToString(), numeroPlanilla)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoGasto.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoGasto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoGasto.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoGasto.Columnas.IdGasto.ToString(), idGasto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosGastos_D(idSucursal As Integer,
                               idReparto As Integer,
                               idGasto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.RepartoGasto.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoGasto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoGasto.Columnas.IdReparto.ToString(), idReparto)
         If idGasto <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoGasto.Columnas.IdGasto.ToString(), idGasto)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub
#End Region

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RG.*")
         .AppendFormatLine("     , CJ.NombreCuentaCaja")
         .AppendFormatLine("  FROM {0} AS RG", Entidades.RepartoGasto.NombreTabla)
         .AppendFormatLine(" INNER JOIN CuentasDeCajas AS CJ ON CJ.IdCuentaCaja = RG.IdCuentaCaja")
      End With
   End Sub

#Region "GetAll"
   Public Function RepartosGastos_GA(idSucursal As Integer) As DataTable
      Return RepartosGastos_G(idSucursal, idReparto:=0, idGasto:=0)
   End Function
   Public Function RepartosGastos_GA(idSucursal As Integer, idReparto As Integer) As DataTable
      Return RepartosGastos_G(idSucursal, idReparto:=idReparto, idGasto:=0)
   End Function
   Private Function RepartosGastos_G(idSucursal As Integer,
                                     idReparto As Integer,
                                     idGasto As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND RG.{0} =  {1} ", Entidades.RepartoGasto.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idReparto <> 0 Then
            .AppendFormatLine("   AND  RG.{0} =  {1} ", Entidades.RepartoGasto.Columnas.IdReparto.ToString(), idReparto)
         End If
         If idGasto <> 0 Then
            .AppendFormatLine("   AND  RCP.{0} =  {1} ", Entidades.RepartoGasto.Columnas.IdGasto.ToString(), idGasto)
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function RepartosGastos_G1(idSucursal As Integer,
                                     idReparto As Integer,
                                     idGasto As Integer) As DataTable
      Return RepartosGastos_G(idSucursal, idReparto, idGasto)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'If columna = "CategoriaParametro" Or columna = "DescripcionParametro" Then
      '   columna = "P." + columna
      'Else
      columna = "RG." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
#End Region

   Public Overloads Function GetCodigoMaximo(idSucursal As Integer, idReparto As Integer) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.RepartoGasto.Columnas.IdGasto.ToString(),
                                             Entidades.RepartoGasto.NombreTabla,
                                             String.Format("{0} = {1} AND {2} = {3}",
                                                           Entidades.RepartoGasto.Columnas.IdSucursal.ToString(), idSucursal,
                                                           Entidades.RepartoGasto.Columnas.IdReparto.ToString(), idReparto)))
   End Function

End Class