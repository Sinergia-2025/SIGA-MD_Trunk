Option Explicit On
Option Strict On

#Region "Imports"

Imports Eniac.Entidades
Imports System.Text

#End Region

Public Class ProductosRecepcion
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ProductosRecepcionV"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ProductosRecepcionV"
      '   Me.New()
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
         .Append("SELECT VP.IdTipoComprobante, ")
         .Append("		VP.Letra, ")
         .Append("		VP.CentroEmisor, ")
         .Append("		VP.NumeroComprobante, ")
         .Append("		V.Fecha, ")
         .Append("		P.IdProducto,")
         .Append("		P.NombreProducto,")
         .Append("		VP.Cantidad, ")
         .Append("		P.Tamano, ")
         .Append("		P.IdUnidadDeMedida, ")
         .Append("		P.IdMarca, ")
         .Append("		M.NombreMarca, ")
         .Append("		P.IdRubro,")
         .Append("		R.NombreRubro, ")
         .Append("		P.MesesGarantia ")
         .Append(" FROM VentasProductos VP")
         .Append("	INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal")
         .Append("						AND V.IdTipoComprobante = VP.IdTipoComprobante")
         .Append("						AND V.Letra = VP.Letra")
         .Append("						AND V.CentroEmisor = VP.CentroEmisor")
         .Append("						AND V.NumeroComprobante = VP.NumeroComprobante")
         .Append("	INNER JOIN Productos P ON VP.IdProducto = P.IdProducto")
         .Append("	INNER JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .Append("	INNER JOIN Rubros R ON P.IdRubro = R.IdRubro ")
         .Append("	INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VP.IdTipoComprobante ")
         .Append("		 ")
         .AppendFormat(" WHERE V.IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND V.IdCliente = {0}", IdCliente)
         .Append("	   AND CONVERT(varchar(11), V.fecha, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
         .Append("	   AND CONVERT(varchar(11), V.fecha, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")
         .Append("   AND TC.AfectaCaja = 1") 'Para Evitar los Presupuestos y Remitos
         .Append("   AND TC.CoeficienteValores = 1") 'Para Evitar NCRED
         .Append(" ORDER BY V.Fecha Desc ")
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
         .Length = 0
         .AppendLine("SELECT RN.NroNota")
         .AppendLine("      ,RN.FechaNota")
         .AppendLine("	    ,RNE.FechaEstado")
         .AppendLine("      ,RE.IdEstado")
         .AppendLine("	    ,RE.NombreEstado")
         .AppendLine("	    ,RN.IdProducto")
         .AppendLine("	    ,P.NombreProducto")
         .AppendLine("      ,RN.CantidadProductos")
         .AppendLine("      ,RN.DefectoProducto")
         .AppendLine("      ,RN.CostoReparacion")
         .AppendLine("      ,RN.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("	    ,C.NombreCliente")
         .AppendLine("      ,RN.Observacion")
         .AppendLine("      ,RN.IdSucursal")
         .AppendLine("      ,RN.IdTipoComprobante")
         .AppendLine("      ,RN.Letra")
         .AppendLine("      ,RN.CentroEmisor")
         .AppendLine("      ,RN.NumeroComprobante")
         .AppendLine("      ,RN.IdProductoPrestado")
         .AppendLine("      ,P1.NombreProducto AS NombreProductoPrestado")
         .AppendLine("      ,RN.CantidadPrestada")
         .AppendLine("      ,RN.ObservacionPrestamo")
         .AppendLine("      ,RN.EstaPrestado")
         .AppendLine("      ,RNP.IdProveedor")
         .AppendLine("      ,PV.CodigoProveedor")
         .AppendLine("      ,PV.NombreProveedor")
         .AppendLine("  FROM RecepcionNotas RN")
         .AppendLine(" LEFT JOIN RecepcionNotasProveedores RNP ON RNP.IdSucursal = RN.IdSucursal AND RNP.NroNota = RN.NroNota AND RNP.FechaEntrega =   ")
         .AppendLine(" (SELECT MAX(RNP1.FechaEntrega) FROM RecepcionNotasProveedores RNP1 ")
         .AppendLine("	WHERE RNP1.NroNota = RN.NroNota GROUP BY RNP1.NroNota)")
         .AppendLine("	INNER JOIN RecepcionNotasEstados RNE ON RNE.FechaEstado = ")
         .AppendLine("				(SELECT MAX(RNE.FechaEstado) FROM RecepcionNotasEstados RNE ")
         .AppendLine("				WHERE RNE.NroNota = RN.NroNota GROUP BY RNE.NroNota)")
         .AppendLine(" LEFT JOIN Proveedores PV ON PV.IdProveedor = RNP.IdProveedor ")
         .AppendLine("	INNER JOIN RecepcionEstados RE ON RE.IdEstado = ")
         .AppendLine("				(SELECT RNE1.IdEstado FROM RecepcionNotasEstados RNE1 ")
         .AppendLine("				WHERE RNE1.NroNota = RN.NroNota AND RNE1.FechaEstado =")
         .AppendLine("				(SELECT MAX(RNE.FechaEstado) FROM RecepcionNotasEstados RNE ")
         .AppendLine("				WHERE RNE.IdSucursal = RN.IdSucursal AND RNE.NroNota = RN.NroNota GROUP BY RNE.NroNota))")
         .AppendLine("	INNER JOIN Clientes C ON C.IdCliente = RN.IdCliente")
         .AppendLine("	INNER JOIN Productos P ON P.IdProducto = RN.IdProducto")
         .AppendLine("	LEFT JOIN Productos P1 ON P1.IdProducto = RN.IdProductoPrestado")
         .AppendFormat("  WHERE RN.IdSucursal = {0}", idSucursal)
         If idEstado > 0 Then
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

         .AppendLine("   ORDER BY RN.FechaNota Desc")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

#End Region

End Class
