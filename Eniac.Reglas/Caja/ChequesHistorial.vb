Option Explicit On
Option Strict On

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Reglas
Imports Eniac.Entidades
Imports Eniac.Reglas.Publicos

Public Class ChequesHistorial
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ChequesHistorial"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ChequesHistorial"
      da = accesoDatos
   End Sub

#End Region

   Public Enum OrdenadoPor
      FechaCobro
      FechaEmision
      NumeroCheque
      Proveedor
   End Enum

#Region "Metodos Publicos"

    Public Function GetInformeHistoriaCheques(ByVal idSucursal As Integer, _
                                              ByVal fechaActDesde As Date, ByVal fechaActHasta As Date, _
                                              ByVal idCaja As Integer, _
                                              ByVal idEstado As Entidades.Cheque.Estados, _
                                              ByVal fechaCobroDesde As Date, _
                                              ByVal fechaCobroHasta As Date, _
                                              ByVal numero As Long, _
                                              ByVal idBanco As Integer, _
                                              ByVal idLocalidad As Integer, _
                                              ByVal esPropio As Boolean, _
                                              ByVal idCliente As Long, _
                                              ByVal idProveedor As Long, _
                                              ByVal titular As String, _
                                              ByVal fechaIngresoDesde As Date, _
                                              ByVal fechaIngresoHasta As Date, _
                                              ByVal idCuentaBancaria As Integer, _
                                              ByVal orden As String) As DataTable

        Dim stbQuery As StringBuilder = New StringBuilder("")

        With stbQuery
            .Length = 0
            .AppendLine("SELECT CH.IdSucursal")
         .AppendLine("      ,CH.FechaActualizacion")
         .AppendLine("      ,CH.IdCheque")
         .AppendLine("      ,CH.Orden")
            .AppendLine("      ,CH.IdBanco")
            .AppendLine("      ,B.NombreBanco")
            .AppendLine("      ,CH.IdBancoSucursal")
            .AppendLine("      ,CH.IdLocalidad")
            .AppendLine("      ,L.NombreLocalidad")
            .AppendLine("      ,CH.NumeroCheque")
            .AppendLine("      ,CONVERT(date, CH.FechaEmision) as FechaEmision")
            .AppendLine("      ,CONVERT(date, CH.FechaCobro) as FechaCobro")
            .AppendLine("      ,CH.Titular")
            .AppendLine("      ,CH.Importe")
            .AppendLine("      ,CH.IdEstadoCheque")
            .AppendLine("      ,CH.IdEstadoChequeAnt")
            .AppendLine("      ,CH.IdCliente")
            .AppendLine("      ,Cl.NombreCliente")
            .AppendLine("      ,Cl.IdCliente")
            .AppendLine("      ,Cl.CodigoCliente")
            .AppendLine("      ,CH.IdCajaIngreso")
            .AppendLine("      ,CNI.NombreCaja NombreCajaIngreso")
            .AppendLine("      ,CH.NroPlanillaIngreso")
            .AppendLine("      ,CH.NroMovimientoIngreso")
            .AppendLine("      ,CI.Observacion as ObservacionIngreso")
            .AppendLine("      ,CONVERT(date, CI.FechaMovimiento) as FechaIngreso")
            .AppendLine("      ,CH.IdProveedor")
            .AppendLine("      ,P.CodigoProveedor")
            .AppendLine("      ,P.NombreProveedor")
            .AppendLine("      ,CH.IdCajaEgreso")
            .AppendLine("      ,CNe.NombreCaja NombreCajaEgreso")
            .AppendLine("      ,CH.NroPlanillaEgreso")
            .AppendLine("      ,CH.NroMovimientoEgreso")
            .AppendLine("      ,CE.Observacion as ObservacionEgreso")
            .AppendLine("      ,CONVERT(date, CE.FechaMovimiento) as FechaEgreso")
            .AppendLine("      ,CH.Cuit")
            .AppendLine("      ,CH.IdCuentaBancaria")
            .AppendLine("      ,CB.NombreCuenta")
            .AppendLine("      ,CH.IdProveedorPreasignado")
            .AppendLine("      ,PA.CodigoProveedor AS CodigoProveedorPreasignado")
            .AppendLine("      ,PA.NombreProveedor AS ProveedorPreasignado")
         .AppendLine("      ,CH.Observacion")

         .AppendLine(" FROM ChequesHistorial CH INNER JOIN Bancos B ON CH.IdBanco = B.IdBanco ")
            .AppendLine(" INNER JOIN Localidades L ON CH.IdLocalidad = L.IdLocalidad ")
            .AppendLine(" LEFT OUTER JOIN Clientes Cl ON CH.IdCliente = Cl.IdCliente ")
            .AppendLine(" LEFT OUTER JOIN Proveedores P ON CH.IdProveedor = P.IdProveedor ")
            .AppendLine(" LEFT OUTER JOIN Proveedores PA ON CH.IdProveedorPreasignado = PA.IdProveedor ")
            .AppendLine(" LEFT OUTER JOIN CuentasBancarias CB ON CB.idCuentaBancaria = CH.IdCuentaBancaria")
            .AppendLine(" LEFT JOIN CajasDetalle CI ON CH.NroPlanillaIngreso = CI.NumeroPlanilla AND CH.NroMovimientoIngreso = CI.NumeroMovimiento  AND CH.IdCajaIngreso = CI.IdCaja AND CI.IdSucursal = " & idSucursal.ToString())
            .AppendLine(" LEFT JOIN CajasDetalle CE ON CH.NroPlanillaEgreso = CE.NumeroPlanilla AND CH.NroMovimientoEgreso = CE.NumeroMovimiento AND CH.IdCajaEgreso = CE.IdCaja AND CE.IdSucursal = " & idSucursal.ToString())
            .AppendLine(" LEFT JOIN CajasNombres CNI ON CH.IdSucursal = CNI.IdSucursal AND CH.IdCajaIngreso = CNI.IdCaja")
            .AppendLine(" LEFT JOIN CajasNombres CNE ON CH.IdSucursal = CNE.IdSucursal AND CH.IdCajaEgreso = CNE.IdCaja")

            .AppendLine(" WHERE CH.IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND CH.EsPropio = '" & esPropio.ToString() & "'")

            .AppendLine("   AND CONVERT(date, FechaActualizacion) >= '" & fechaActDesde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("   AND CONVERT(date, FechaActualizacion) <= '" & fechaActHasta.ToString("yyyy-MM-dd") & "'")

            If idCuentaBancaria > 0 Then
                .AppendLine("   AND CH.IdCuentaBancaria = " & idCuentaBancaria.ToString())
            End If

            If idCaja > 0 Then
                If esPropio Then
                    .AppendLine("   AND CH.IdCajaEgreso = " & idCaja.ToString())
                Else
                    .AppendLine("   AND CH.IdCajaIngreso = " & idCaja.ToString())
                End If
            End If

            If idEstado <> Cheque.Estados.NINGUNO Then
                .AppendLine("   AND CH.IdEstadoCheque = '" & idEstado.ToString() & "'")
            End If

            If fechaCobroDesde > Date.Parse("01/01/1990") Then
                .AppendLine("   AND CONVERT(date, FechaCobro) >= '" & fechaCobroDesde.ToString("yyyy-MM-dd") & "'")
                .AppendLine("   AND CONVERT(date, FechaCobro) <= '" & fechaCobroHasta.ToString("yyyy-MM-dd") & "'")
            End If


            If numero > 0 Then
                .AppendLine("   AND CH.NumeroCheque = " & numero.ToString())
            End If

            If idBanco > 0 Then
                .AppendLine("   AND CH.IdBanco = " & idBanco.ToString())
            End If

            If idLocalidad > 0 Then
                .AppendLine("   AND CH.IdLocalidad = " & idLocalidad.ToString())
            End If

            If idCliente <> 0 Then
                .AppendLine("	AND Cl.IdCliente = " & idCliente)
            End If

            If idProveedor > 0 Then
                .AppendLine("	AND P.IdProveedor = " & idProveedor.ToString())
            End If

            If Not String.IsNullOrEmpty(titular) Then
                .AppendLine("	AND CH.Titular LIKE '%" & titular & "%'")
            End If


            If fechaIngresoDesde > Date.Parse("01/01/1990") Then
                If esPropio Then
                    .AppendLine("   AND CONVERT(date, CH.FechaEmision) >= '" & fechaIngresoDesde.ToString("yyyy-MM-dd") & "'")
                    .AppendLine("   AND CONVERT(date, CH.FechaEmision) <= '" & fechaIngresoHasta.ToString("yyyy-MM-dd") & "'")
                Else
                    .AppendLine("   AND CONVERT(date, CI.FechaMovimiento) >= '" & fechaIngresoDesde.ToString("yyyy-MM-dd") & "'")
                    .AppendLine("   AND CONVERT(date, CI.FechaMovimiento) <= '" & fechaIngresoHasta.ToString("yyyy-MM-dd") & "'")
                End If
            End If

            If orden = Entidades.Cheque.Ordenamiento.FECHAACTUALIZACION.ToString() Then
                .AppendLine("   ORDER BY CH.FechaActualizacion")
            ElseIf orden = Entidades.Cheque.Ordenamiento.NOMBREYFECHAACTUALIZACION.ToString() Then
                .AppendLine("   ORDER BY Cl.NombreCliente, CH.FechaActualizacion")
            End If

        End With

        Return da.GetDataTable(stbQuery.ToString())

    End Function


#End Region

#Region "Metodos Privados"

    Private Sub CargarUno(ByVal o As Entidades.Cheque, ByVal dr As DataRow)

        With o
            .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
            '.Sucursal = New Reglas.Sucursales(da).GetUna(integer.Parse(dr("idSucursal").ToString()))
            .NumeroCheque = Integer.Parse(dr("NumeroCheque").ToString())
            .Banco = New Reglas.Bancos(da).GetUno(Integer.Parse(dr("IdBanco").ToString()))
            .IdBancoSucursal = Integer.Parse(dr("IdBancoSucursal").ToString())
            .Localidad = New Reglas.Localidades(da).GetUna(Integer.Parse(dr("IdLocalidad").ToString()))
            .FechaEmision = DateTime.Parse(dr("FechaEmision").ToString())
            .FechaCobro = DateTime.Parse(dr("FechaCobro").ToString())
            .Titular = dr("Titular").ToString()
            .Importe = Decimal.Parse(dr("Importe").ToString())

            If Not String.IsNullOrEmpty(dr("NroPlanillaIngreso").ToString()) Then
                .IdCajaIngreso = Integer.Parse(dr("IdCajaIngreso").ToString())
                .NroPlanillaIngreso = Integer.Parse(dr("NroPlanillaIngreso").ToString())
                .NroMovimientoIngreso = Integer.Parse(dr("NroMovimientoIngreso").ToString())
            Else
                .IdCajaIngreso = 0
                .NroPlanillaIngreso = 0
                .NroMovimientoIngreso = 0
            End If

            If Not String.IsNullOrEmpty(dr("IdCliente").ToString()) Then
                .Cliente = New Reglas.Clientes(Me.da)._GetUno(Long.Parse(dr("IdCliente").ToString()), False)
            End If

            If Not String.IsNullOrEmpty(dr("NroPlanillaEgreso").ToString()) Then
                .IdCajaEgreso = Integer.Parse(dr("IdCajaEgreso").ToString())
                .NroPlanillaEgreso = Integer.Parse(dr("NroPlanillaEgreso").ToString())
                .NroMovimientoEgreso = Integer.Parse(dr("NroMovimientoEgreso").ToString())
            Else
                .IdCajaEgreso = 0
                .NroPlanillaEgreso = 0
                .NroMovimientoEgreso = 0
            End If

            If Not String.IsNullOrEmpty(dr("IdProveedor").ToString()) Then
                .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(dr("IdProveedor").ToString()))
            End If

            .EsPropio = Boolean.Parse(dr("EsPropio").ToString())

            If Not String.IsNullOrEmpty(dr("IdCuentaBancaria").ToString()) Then
                .CuentaBancaria = New Reglas.CuentasBancarias(da).GetUna(Integer.Parse(dr("IdCuentaBancaria").ToString()))
            End If

            .IdEstadoCheque = DirectCast([Enum].Parse(GetType(Eniac.Entidades.Cheque.Estados), dr("IdEstadoCheque").ToString()), Entidades.Cheque.Estados)

            If Not String.IsNullOrEmpty(dr("IdEstadoChequeAnt").ToString()) Then
                .IdEstadoChequeAnt = DirectCast([Enum].Parse(GetType(Entidades.Cheque.Estados), dr("IdEstadoChequeAnt").ToString()), Entidades.Cheque.Estados)
            End If
            .Cuit = dr("Cuit").ToString()

            If dr.Table.Columns.Contains("FotoFrente") Then
                If Not String.IsNullOrEmpty(dr("FotoFrente").ToString()) Then
                    Dim content() As Byte = CType(dr("FotoFrente"), Byte())
                    Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
                    .FotoFrente = New System.Drawing.Bitmap(stream)
                End If
            End If

            If dr.Table.Columns.Contains("FotoDorso") Then
                If Not String.IsNullOrEmpty(dr("FotoDorso").ToString()) Then
                    Dim content() As Byte = CType(dr("FotoDorso"), Byte())
                    Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
                    .FotoDorso = New System.Drawing.Bitmap(stream)
                End If
            End If

            If IsNumeric(dr("IdProveedorPreasignado")) Then
                .IdProveedorPreasignado = Long.Parse(dr("IdProveedorPreasignado").ToString())
            End If
            If dr.Table.Columns.Contains("CodigoProveedorPreasignado") AndAlso IsNumeric(dr("CodigoProveedorPreasignado")) Then
                .CodigoProveedorPreasignado = Long.Parse(dr("CodigoProveedorPreasignado").ToString())
            End If

         If dr.Table.Columns.Contains("ProveedorPreasignado") Then
            .ProveedorPreasignado = dr("ProveedorPreasignado").ToString()
         End If

         .IdCheque = dr.Field(Of Long)(Entidades.Cheque.Columnas.IdCheque.ToString())
         .Observacion = dr("Observacion").ToString()

      End With

    End Sub


#End Region


End Class