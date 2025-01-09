Option Strict On
Option Explicit On
Public Class TarjetasCuponesHistorial
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TarjetasCuponesHistorial"
      da = accesoDatos
   End Sub
#End Region


#Region "Metodos Publicos"

   Public Function GetInformeCupones(idSucursal As Integer,
                                      idTarjetaCupon As Integer,
                                      fechaIngresoDesde As Date?, _
                                      fechaIngresoHasta As Date?,
                                      idEstadoTarjeta As String,
                                      fechaLiquidacionDesde As Date?, _
                                      fechaLiquidacionHasta As Date?,
                                      numeroCupon As Integer,
                                      numeroLote As Integer,
                                      fechaEnCarteraAl As Date?,
                                      idCaja As Integer,
                                      idBanco As Integer,
                                      idCliente As Long,
                                      orden As String) As DataTable

      Return New SqlServer.TarjetasCuponesHistorial(da).TarjetasCupones_GA(idSucursal,
                                                                  idTarjetaCupon,
                                                                  fechaIngresoDesde,
                                                                  fechaIngresoHasta,
                                                                  idEstadoTarjeta,
                                                                  fechaLiquidacionDesde,
                                                                  fechaLiquidacionHasta,
                                                                  numeroCupon,
                                                                  numeroLote,
                                                                  fechaEnCarteraAl,
                                                                  idCaja,
                                                                  idBanco,
                                                                  idCliente,
                                                                  orden)

   End Function
#End Region
End Class
