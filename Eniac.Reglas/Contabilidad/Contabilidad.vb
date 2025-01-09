#Region "Option"
Option Explicit On
Option Strict On
#End Region
Public Class Contabilidad
   Private da As Datos.DataAccess

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Genericos"
   Public Sub AnularAsiento(idEjercicio As Integer, idPlanCuenta As Integer, idCuenta As Integer, fecha As DateTime)
      Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
      Dim codEjeVigente As Integer = New Reglas.ContabilidadEjercicios(da).GetEjercicioVigente(fecha)
      Dim idAsiento As Integer = New SqlServer.ContabilidadAsientosTmp(da).Asiento_GetIdMaximo_Tmp(codEjeVigente, idPlanCuenta) + 1
      sql.AnularAsiento(idEjercicio, idPlanCuenta, idCuenta, fecha, codEjeVigente, idAsiento)
      sql.AnularAsientoCuenta(idEjercicio, idPlanCuenta, idCuenta, codEjeVigente, idAsiento)
   End Sub

   Public Function AsientoProcesadoComoDefinitivo(idEjercicio As Integer?, idPlanCuenta As Integer?, idCuenta As Integer?) As Boolean
      If idEjercicio.HasValue AndAlso idPlanCuenta.HasValue AndAlso idCuenta.HasValue Then
         Dim sql As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
         Dim dt As DataTable = sql.Asientos_G1_Tmp(idEjercicio.Value, idPlanCuenta.Value, idCuenta.Value)

         If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            If dt.Rows(0).ValorNumericoPorDefecto("IdEjercicioDefinitivo", 0I) <> 0 Or
               dt.Rows(0).ValorNumericoPorDefecto("IdPlanCuentaDefinitivo", 0I) <> 0 Or
               dt.Rows(0).ValorNumericoPorDefecto("IdAsientoDefinitivo", 0I) <> 0 Then
               Return True
            End If
         End If
      End If

      Return False
   End Function

   Private Function ObtenerDescCuenta(filaCuenta As Entidades.ContabilidadCuenta) As String
      Return String.Format("{0}-{1}", filaCuenta.IdCuenta, filaCuenta.NombreCuenta)
   End Function

   Friend Shared Function CrearTablaDetalle() As DataTable
      Dim datosDetalle As New DataTable

      datosDetalle.Columns.Add("Cuenta", GetType(String)) 'Cuentas.CodCuenta
      datosDetalle.Columns.Add("debe", GetType(Decimal))
      datosDetalle.Columns.Add("haber", GetType(Decimal))
      datosDetalle.Columns.Add("idAsiento", GetType(Integer))
      datosDetalle.Columns.Add("idRenglon", GetType(Integer))
      datosDetalle.Columns.Add("IdCuenta", GetType(Integer))
      datosDetalle.Columns.Add("IdTipoReferencia", GetType(String)) 'Cuentas.CodCuenta
      datosDetalle.Columns.Add("Referencia", GetType(String)) 'Cuentas.CodCuenta

      datosDetalle.Columns.Add("IdCentroCosto", GetType(Integer)) 'Centro de Costos

      Return datosDetalle

   End Function

   Friend Shared Sub AgregarFila(ByRef dtDet As DataTable,
                                 dscCuenta As String,
                                 debe As Decimal,
                                 haber As Decimal,
                                 idAsiento As Integer,
                                 idCuenta As Long,
                                 idTipoReferencia As String,
                                 referencia As String,
                                 idCentroCosto As Integer?)

      Dim fila As DataRow = dtDet.NewRow
      dtDet.Rows.Add(fila)

      fila("Cuenta") = dscCuenta
      fila("debe") = debe
      fila("haber") = haber
      fila("idAsiento") = idAsiento
      fila("idRenglon") = 0
      fila("IdCuenta") = idCuenta
      fila("idTipoReferencia") = idTipoReferencia
      fila("referencia") = referencia
      If (idCentroCosto.HasValue) Then
         fila("idCentroCosto") = idCentroCosto.Value
      End If
   End Sub

   Friend Shared Sub AgregarFila(ByRef dtDet As DataTable,
                              dscCuenta As String,
                              debe As Decimal,
                              haber As Decimal,
                              idAsiento As Integer,
                              idCuenta As Long,
                              idCentroCosto As Integer?)
      AgregarFila(dtDet, dscCuenta, debe, haber, idAsiento, idCuenta, String.Empty, String.Empty, idCentroCosto)
   End Sub

   Friend Shared Sub AgregarFila(ByRef dtDet As DataTable,
                                 ByVal dscCuenta As String,
                                 ByVal debe As Decimal,
                                 ByVal haber As Decimal,
                                 ByVal idAsiento As Integer,
                                 ByVal idCuenta As Long,
                                 ByVal idTipoReferencia As String,
                                 ByVal referencia As String)
      AgregarFila(dtDet, dscCuenta, debe, haber, idAsiento, idCuenta, idTipoReferencia, referencia, Nothing)
   End Sub
   Friend Shared Sub AgregarFila(ByRef dtDet As DataTable,
                                 ByVal dscCuenta As String,
                                 ByVal debe As Decimal,
                                 ByVal haber As Decimal,
                                 ByVal idAsiento As Integer,
                                 ByVal idCuenta As Long)
      AgregarFila(dtDet, dscCuenta, debe, haber, idAsiento, idCuenta, String.Empty, String.Empty, Nothing)
   End Sub

   Private Function AgruparAsiento(dt As DataTable) As DataTable
      Dim dtTemp As DataTable = dt.Clone()
      Dim dtResult As DataTable = dt.Clone()
      Dim IdRenglon As Integer = 0

      Dim totalDebe As Decimal = 0
      Dim totalHaber As Decimal = 0

      For Each dr As DataRow In dt.Rows
         Dim where As String = "IdCuenta = " + dr("IdCuenta").ToString()
         If Not IsDBNull(dr("IdCentroCosto")) Then
            where += " AND IdCentroCosto = " + dr("IdCentroCosto").ToString()
         Else
            where += " AND IdCentroCosto IS NULL"
         End If

         Dim drCol() As DataRow = dtTemp.Select(where)
         Dim drTemp As DataRow
         If drCol.Length > 0 Then
            drTemp = drCol(0)
         Else
            drTemp = dtTemp.NewRow
            dtTemp.Rows.Add(drTemp)

            IdRenglon += 1
            drTemp("IdCuenta") = dr("IdCuenta")
            drTemp("Cuenta") = dr("Cuenta")
            drTemp("idAsiento") = dr("idAsiento")
            drTemp("idRenglon") = IdRenglon
            drTemp("debe") = 0
            drTemp("haber") = 0
            drTemp("IdTipoReferencia") = dr("IdTipoReferencia")
            drTemp("Referencia") = dr("Referencia")
            drTemp("IdCentroCosto") = dr("IdCentroCosto")
         End If

         'redondeo los valores del debe y haber
         dr("debe") = Decimal.Round(Decimal.Parse(dr("debe").ToString()), 2)
         dr("haber") = Decimal.Round(Decimal.Parse(dr("haber").ToString()), 2)

         drTemp("debe") = Decimal.Parse(drTemp("debe").ToString()) + Decimal.Parse(dr("debe").ToString())
         drTemp("haber") = Decimal.Parse(drTemp("haber").ToString()) + Decimal.Parse(dr("haber").ToString())

         totalDebe = totalDebe + Decimal.Parse(dr("debe").ToString())
         totalHaber = totalHaber + Decimal.Parse(dr("haber").ToString())
      Next

      If Math.Round(totalDebe, 2) <> Math.Round(totalHaber, 2) Then
         Dim diferencia As Decimal = Math.Round(totalDebe, 2) - Math.Round(totalHaber, 2)
         If Math.Abs(diferencia) < ContabilidadPublicos.ContabilidadRedondeoImporteMaximo(da) Then
            Dim cuentaDiferencia As Entidades.ContabilidadCuenta = New Reglas.ContabilidadCuentas(da)._GetUna(ContabilidadPublicos.ContabilidadCuentaRedondeo(da))
            AgregarFila(dtTemp,
                        ObtenerDescCuenta(cuentaDiferencia),
                        CDec(IIf(diferencia < 0, Math.Abs(diferencia), 0)),
                        CDec(IIf(diferencia > 0, Math.Abs(diferencia), 0)),
                        CInt(dtTemp.Rows(0)("IdAsiento")),
                        cuentaDiferencia.IdCuenta)
         Else
            Throw New Exception(String.Format("No se pudo balancear el asiento contable. Debe: {0:N2} - Haber: {1:N2}. Por favor verifique la configuración contable.", totalDebe, totalHaber))
         End If
      End If

      For Each drTemp As DataRow In dtTemp.Select("debe <> 0 AND haber <> 0")
         If Decimal.Parse(drTemp("debe").ToString()) > Decimal.Parse(drTemp("haber").ToString()) Then
            drTemp("debe") = Decimal.Parse(drTemp("debe").ToString()) - Decimal.Parse(drTemp("haber").ToString())
            drTemp("haber") = 0
         Else
            drTemp("haber") = Decimal.Parse(drTemp("haber").ToString()) - Decimal.Parse(drTemp("debe").ToString())
            drTemp("debe") = 0
         End If
      Next

      IdRenglon = 0
      For Each drTemp As DataRow In dtTemp.Select("debe <> 0")
         IdRenglon += 1
         drTemp("idRenglon") = IdRenglon
         dtResult.ImportRow(drTemp)
      Next

      For Each drTemp As DataRow In dtTemp.Select("haber <> 0")
         IdRenglon += 1
         drTemp("idRenglon") = IdRenglon
         dtResult.ImportRow(drTemp)
      Next

      If dtResult.Rows.Count = 0 Then
         Return dt
      End If

      Return dtResult
   End Function
#End Region

End Class