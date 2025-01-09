Option Explicit On
Option Strict On

Imports System.Text

Public Class VentasCheques
   Inherits Eniac.Reglas.Base


#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "VentasCheques"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "VentasCheques"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim oVentas As Entidades.VentaProducto = DirectCast(entidad, Entidades.VentaProducto)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(oVentas, TipoSP._I)

         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos"

   Friend Sub EjecutaSP(ByVal ent As Entidades.VentaProducto, ByVal tipo As TipoSP)
      Try

         Dim sql As SqlServer.VentasCheques = New SqlServer.VentasCheques(Me.da)

         Select Case tipo

            Case TipoSP._D

               sql.VentasCheques_D2(ent.IdSucursal, ent.TipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante)

         End Select

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   'Public Function GetUna(ByVal idSucursal As Integer, _
   '                       ByVal idTipoComprobante As String, _
   '                       ByVal letra As String, _
   '                       ByVal centroEmisor As Integer, _
   '                       ByVal numeroComprobante As Long, _
   '                       ByVal orden As Long, _
   '                       ByVal idProducto As String) As Entidades.VentaProducto

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Length = 0
   '      .Append("SELECT VP.IdSucursal")
   '      .Append("      ,VP.IdTipoComprobante")
   '      .Append("      ,VP.Letra")
   '      .Append("      ,VP.CentroEmisor")
   '      .Append("      ,VP.NumeroComprobante")
   '      .Append("      ,VP.Orden")
   '      .Append("      ,VP.IdProducto")
   '      .Append("	   ,P.NombreProducto")
   '      .Append("	   ,PS.Stock")
   '      .Append("      ,VP.Cantidad")
   '      .Append("      ,VP.PrecioLista")
   '      .Append("      ,VP.Precio")
   '      .Append("      ,VP.Costo")
   '      .Append("      ,VP.DescRecGeneral")
   '      .Append("      ,VP.DescuentoRecargo")
   '      .Append("      ,VP.DescuentoRecargoProducto")
   '      .Append("      ,VP.DescuentoRecargoPorc ")
   '      .Append("      ,VP.DescuentoRecargoPorc2 ")
   '      .Append("      ,VP.DescRecGeneralProducto ")
   '      .Append("      ,VP.PrecioNeto")
   '      .Append("      ,VP.Utilidad")
   '      .Append("      ,VP.ImporteTotal")
   '      .Append("      ,VP.ImporteTotalNeto")

   '      .Append("  FROM VentasCheques VP")
   '      .Append(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
   '      .Append(" INNER JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto AND PS.IdSucursal = " & idSucursal.ToString())
   '      .Append(" WHERE VP.IdSucursal = " & idSucursal.ToString())
   '      .Append("   AND VP.IdTipoComprobante = '" & idTipoComprobante & "'")
   '      .Append("   AND VP.Letra = '" & letra & "'")
   '      .Append("   AND VP.CentroEmisor = " & centroEmisor.ToString())
   '      .Append("   AND VP.NumeroComprobante = " & numeroComprobante.ToString())
   '      .Append("   AND VP.Orden = " & orden.ToString())
   '      .Append("   AND VP.IdProducto = '" & idProducto.ToString() & "'")
   '   End With

   '   Dim dtPro As DataTable = Me.DataServer.GetDataTable(stb.ToString())
   '   Dim oVP As Entidades.VentaProducto

   '   If dtPro.Rows.Count > 0 Then

   '      'Solo tiene a encontrar 1.
   '      oVP = New Entidades.VentaProducto()
   '      With oVP

   '         .IdSucursal = Int32.Parse(dtPro.Rows(0)("IdSucursal").ToString())
   '         .TipoComprobante = dtPro.Rows(0)("IdTipoComprobante").ToString()
   '         .Letra = dtPro.Rows(0)("Letra").ToString()
   '         .CentroEmisor = Short.Parse(dtPro.Rows(0)("CentroEmisor").ToString())
   '         .NumeroComprobante = Long.Parse(dtPro.Rows(0)("NumeroComprobante").ToString())
   '         .Orden = Long.Parse(dtPro.Rows(0)("Orden").ToString())
   '         .Producto = dtPro.Rows(0)("IdProducto").ToString()
   '         .ProductoDesc = dtPro.Rows(0)("NombreProducto").ToString()
   '         .Cantidad = Decimal.Parse(dtPro.Rows(0)("Cantidad").ToString())
   '         .Costo = Decimal.Parse(dtPro.Rows(0)("Costo").ToString())
   '         .PrecioLista = Decimal.Parse(dtPro.Rows(0)("PrecioLista").ToString())
   '         .Precio = Decimal.Parse(dtPro.Rows(0)("Precio").ToString())
   '         .DescuentoRecargoPorc1 = Decimal.Parse(dtPro.Rows(0)("DescuentoRecargoPorc").ToString())
   '         .DescuentoRecargoPorc2 = Decimal.Parse(dtPro.Rows(0)("DescuentoRecargoPorc2").ToString())
   '         .DescuentoRecargo = Decimal.Parse(dtPro.Rows(0)("DescuentoRecargo").ToString())
   '         .DescuentoRecargoProducto = Decimal.Parse(dtPro.Rows(0)("DescuentoRecargoProducto").ToString())
   '         .DescRecGeneral = Decimal.Parse(dtPro.Rows(0)("DescRecGeneral").ToString())
   '         .DescRecGeneralProducto = Decimal.Parse(dtPro.Rows(0)("DescRecGeneralProducto").ToString())
   '         .PrecioNeto = Decimal.Parse(dtPro.Rows(0)("PrecioNeto").ToString())
   '         .Utilidad = Decimal.Parse(dtPro.Rows(0)("Utilidad").ToString())
   '         .ImporteTotal = Decimal.Parse(dtPro.Rows(0)("ImporteTotal").ToString())
   '         .ImporteTotalNeto = Decimal.Parse(dtPro.Rows(0)("ImporteTotalNeto").ToString())
   '         If Not String.IsNullOrEmpty(dtPro.Rows(0)("Stock").ToString()) Then
   '            .Stock = Decimal.Parse(dtPro.Rows(0)("Stock").ToString())
   '         End If
   '      End With

   '   Else
   '      Throw New Exception("No existe este comprobante de venta.")
   '   End If

   '   Return oVP

   'End Function

#End Region

End Class
