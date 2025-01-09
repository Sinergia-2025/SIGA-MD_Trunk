Option Explicit On
Option Strict On

#Region "Imports"

Imports Eniac.Entidades
Imports System.Text

#End Region

Public Class ProductosRecepcionF
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ProductosRecepcionF"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)

      Try
         da.OpenConection()
         da.BeginTransaction()

         'Me.GrabaFichaPagos(ficha)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetProductosVendidos(ByVal idSucursal As Integer, _
                                         ByVal IdCliente As Long, _
                                         ByVal Desde As Date, _
                                         ByVal Hasta As Date) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT F.FechaOperacion, ")
         .AppendLine("		F.NroOperacion, ")
         .AppendLine("		P.IdProducto,")
         .AppendLine("		P.NombreProducto,")
         .AppendLine("		FP.Cantidad, ")
         .AppendLine("		P.Tamano, ")
         '.Append("		P.IdUnidadDeMedida, ")
         .AppendLine("		P.IdMarca, ")
         .AppendLine("		M.NombreMarca, ")
         .AppendLine("		P.IdRubro,")
         .AppendLine("		R.NombreRubro, ")
         .AppendLine("		P.MesesGarantia, ")
         .AppendLine("		FP.IdSucursal ")
         .AppendLine(" FROM FichasProductos FP")
         .AppendLine("	INNER JOIN Fichas F ON F.NroOperacion = FP.NroOperacion")
         .AppendLine("						AND F.IdCliente = FP.IdCliente")
         .AppendLine("						AND F.IdSucursal = FP.IdSucursal")
         .AppendLine("	INNER JOIN Productos P ON FP.IdProducto = P.IdProducto")
         .AppendLine("	INNER JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .AppendLine("	INNER JOIN Rubros R ON P.IdRubro = R.IdRubro ")
         .AppendFormat(" WHERE F.IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND FP.IdCliente = {0}", IdCliente)
         .Append("	   AND CONVERT(varchar(11), F.FechaOperacion, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
         .Append("	   AND CONVERT(varchar(11), F.FechaOperacion, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")
         .Append("      AND F.IdEstado <> 'INACTIVO' ") 'Para Fichas Anuladas
         .AppendLine(" ORDER BY F.FechaOperacion Desc ")
      End With

      Return Me.DataServer().GetDataTable(stbQuery.ToString())
   End Function

   Public Function GetProductosEnReparacion(ByVal idSucursal As Integer, _
                                            ByVal idEstado As Integer, _
                                            ByVal fechaEnvioDesde As Date, _
                                            ByVal fechaEnvioHasta As Date, _
                                            ByVal IdCliente As Long) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Append("SELECT RN.NroNota")
         .Append("      ,RN.FechaNota")
         .Append("	  ,RNE.FechaEstado")
         .Append("      ,RE.IdEstado")
         .Append("	  ,RE.NombreEstado")
         .Append("	  ,RN.IdProducto")
         .Append("	  ,P.NombreProducto")
         .Append("      ,RN.CantidadProductos")
         .Append("      ,RN.DefectoProducto")
         .Append("      ,RN.CostoReparacion")
         .Append("      ,RN.IdCliente")
         .Append("      ,C.CodigoCliente")
         .Append("	  ,C.NombreCliente")
         .Append("      ,RN.Observacion")
         .Append("      ,RN.IdSucursal")
         .Append("      ,RN.NroOperacion")
         .Append("      ,RN.IdProductoPrestado")
         .Append("      ,P1.NombreProducto NombreProductoPrestado")
         .Append("      ,RN.CantidadPrestada")
         .Append("      ,RN.ObservacionPrestamo")
         .Append("      ,RN.EstaPrestado")
         .Append("      ,RNP.IdProveedor")
         .Append("      ,PV.NombreProveedor")
         .Append("  FROM RecepcionNotasF RN")
         .Append(" LEFT JOIN RecepcionNotasProveedoresF RNP ON RNP.NroNota = RN.NroNota AND RNP.FechaEntrega =   ")
         .Append(" (SELECT MAX(RNP1.FechaEntrega) FROM RecepcionNotasProveedoresF RNP1 ")
         .Append("	WHERE RNP1.NroNota = RN.NroNota GROUP BY RNP1.NroNota)")
         .Append("	INNER JOIN RecepcionNotasEstadosF RNE ON RNE.FechaEstado = ")
         .Append("				(SELECT MAX(RNE.FechaEstado) FROM RecepcionNotasEstadosF RNE ")
         .Append("				WHERE RNE.NroNota = RN.NroNota GROUP BY RNE.NroNota)")
         .Append(" LEFT JOIN Proveedores PV ON PV.IdProveedor = RNP.IdProveedor ")
         .Append("	INNER JOIN RecepcionEstadosF RE ON RE.IdEstado = ")
         .Append("				(SELECT RNE1.IdEstado FROM RecepcionNotasEstadosF RNE1 ")
         .Append("				WHERE RNE1.NroNota = RN.NroNota AND RNE1.FechaEstado =")
         .Append("				(SELECT MAX(RNE.FechaEstado) FROM RecepcionNotasEstadosF RNE ")
         .Append("				WHERE RNE.NroNota = RN.NroNota GROUP BY RNE.NroNota))")
         .Append("	INNER JOIN Clientes C ON C.IdCliente = RN.IdCliente")
         .Append("	INNER JOIN Productos P ON P.IdProducto = RN.IdProducto")
         .Append("	LEFT JOIN Productos P1 ON P1.IdProducto = RN.IdProductoPrestado")
         .Append("  WHERE RN.IdSucursal = " & idSucursal.ToString())
         If idEstado <> 0 Then
            .AppendFormat(" AND	RNE.IdEstado = {0}", idEstado)
         End If
         If fechaEnvioDesde <> Nothing Then
            .AppendFormat("  AND RN.FechaNota >= '{0} 00:00:00'", fechaEnvioDesde.ToString("yyyyMMdd"))
         End If
         If fechaEnvioHasta <> Nothing Then
            .AppendFormat("  AND RN.FechaNota <= '{0} 23:59:59'", fechaEnvioHasta.ToString("yyyyMMdd"))
         End If
         If IdCliente > 0 Then
            .AppendFormat("  AND RN.IdCliente = {0}", IdCliente)
         End If
         .Append("   ORDER BY RN.FechaNota Desc")
      End With

      Return Me.DataServer().GetDataTable(stbQuery.ToString())

   End Function

#End Region

End Class
