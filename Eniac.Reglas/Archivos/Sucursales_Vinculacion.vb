Imports Eniac.Entidades

Partial Class Sucursales

   Public Property idSucursalOrigen As Integer
   Public Property idDepositoOrigen As Integer
   Public Property idUbicacionOrigen As Integer

   Public Property idSucursalAsociada As Integer
   Public Property idDepositoAsociada As Integer
   Public Property idUbicacionAsociada As Integer

   Public Sub VincularSucDepUbi(vincular As Boolean)
      EjecutaConTransaccion(Sub()
                               If vincular Then
                                  _VincularSucDepUbi()
                               Else
                                  _DesVincularSucDepUbi()
                               End If
                            End Sub)
   End Sub
   Public Function GetVinculaciones(idSucusal As Integer) As DataTable
      Dim sql = New SqlServer.Sucursales(da)
      Return sql.GetVinculaciones(idSucusal)
   End Function
   Private Sub _VincularSucDepUbi()
      Dim rDep = New SucursalesDepositos(da)
      Dim rUbi = New SucursalesUbicaciones(da)

      '-- Vincula Depositos.- ----------------------------------------------------------------------------------------------------------------
      Dim deposito = rDep.GetUno(idDepositoOrigen, idSucursalOrigen)
      With deposito
         .SucursalAsociada = idSucursalAsociada
         .DepositoAsociado = idDepositoAsociada
         '-- Actualiza los Depositos.- -------------------------------------------------------------------------------------------------------
         rDep._ActualizaDepositoAsociado(.IdDeposito, .IdSucursal, .DepositoAsociado, .SucursalAsociada)
         rDep._ActualizaDepositoAsociado(.DepositoAsociado, .SucursalAsociada, .IdDeposito, .IdSucursal)
      End With
      '-- Vincula las Ubicaciones.- ----------------------------------------------------------------------------------------------------------
      Dim ubicacion = rUbi.GetUno(idDepositoOrigen, idSucursalOrigen, idUbicacionOrigen)
      With ubicacion
         .SucursalAsociada = idSucursalAsociada
         .DepositoAsociado = idDepositoAsociada
         .UbicacionAsociada = idUbicacionAsociada
         '-- Actualiza las Ubicaciones.- -------------------------------------------------------------------------------------------------------
         rUbi._ActualizaUbicacionAsociada(.IdDeposito, .IdSucursal, .IdUbicacion, .DepositoAsociado, .SucursalAsociada, .UbicacionAsociada)
         rUbi._ActualizaUbicacionAsociada(.DepositoAsociado, .SucursalAsociada, .UbicacionAsociada, .IdDeposito, .IdSucursal, .IdUbicacion)
      End With
      '-- Vincula Sucursales.- -----------------------------------------------------------------------------------------------------------------
      _ActualizaSucursalAsociada(idSucursalOrigen, idSucursalAsociada)
      _ActualizaSucursalAsociada(idSucursalAsociada, idSucursalOrigen)
      '-- Recalcula Stock.- --------------------------------------------------------------------------------------------------------------------
      _RecualculoStockParaRepararInconsistencias({idSucursalOrigen, idSucursalAsociada})
      '-----------------------------------------------------------------------------------------------------------------------------------------
   End Sub
   Private Sub _DesVincularSucDepUbi()
      Dim rDep = New SucursalesDepositos(da)
      '-- Actualiza los Depositos.- -------------------------------------------------------------------------------------------------------
      rDep._ActualizaDepositoAsociado(idDepositoOrigen, idSucursalOrigen, idDepositoAsociada, sucursalAsociada:=0)
      rDep._ActualizaDepositoAsociado(idDepositoAsociada, idSucursalAsociada, idDepositoOrigen, sucursalAsociada:=0)

      Dim rUbi = New SucursalesUbicaciones(da)
      '-- Actualiza las Ubicaciones.- -------------------------------------------------------------------------------------------------------
      rUbi._ActualizaUbicacionAsociada(idDepositoOrigen, idSucursalOrigen, idUbicacionOrigen, idDepositoAsociada, sucursalAsociada:=0, idUbicacionAsociada)
      rUbi._ActualizaUbicacionAsociada(idDepositoAsociada, idSucursalAsociada, idUbicacionAsociada, idDepositoOrigen, sucursalAsociada:=0, idUbicacionOrigen)

      '-- Vincula Sucursales.- -----------------------------------------------------------------------------------------------------------------
      _ActualizaSucursalAsociada(idSucursalOrigen, sucursalAsociada:=0)
      _ActualizaSucursalAsociada(idSucursalAsociada, sucursalAsociada:=0)

      '-- Recalcula Stock.- --------------------------------------------------------------------------------------------------------------------
      _RecualculoStockParaRepararInconsistencias({idSucursalOrigen})
      _RecualculoStockParaRepararInconsistencias({idSucursalAsociada})
      '-----------------------------------------------------------------------------------------------------------------------------------------
   End Sub


   Public Function ComparaSucDepUbicaciones(ubiOrigen As SucursalUbicacion, ubiAsocia As SucursalUbicacion) As String
      '-- Carga la Entidad Origen.- --------------------------------------------------------------------------------------
      Dim ePosOrigen As New eSucursalDepositoUbicacion
      With ePosOrigen
         .PosOrigen = (ubiOrigen.IdSucursal * 1000000) + (ubiOrigen.IdDeposito * 1000) + ubiOrigen.IdUbicacion
         .PosAsigna = (ubiOrigen.SucursalAsociada * 1000000) + (ubiOrigen.DepositoAsociado * 1000) + ubiOrigen.UbicacionAsociada
      End With
      '-- Carga la Entidad Origen.- --------------------------------------------------------------------------------------
      Dim ePosAsigna As New eSucursalDepositoUbicacion
      With ePosAsigna
         .PosOrigen = (ubiAsocia.IdSucursal * 1000000) + (ubiAsocia.IdDeposito * 1000) + ubiAsocia.IdUbicacion
         .PosAsigna = (ubiAsocia.SucursalAsociada * 1000000) + (ubiAsocia.DepositoAsociado * 1000) + ubiAsocia.UbicacionAsociada
      End With
      '--
      If ePosOrigen.PosAsigna = 0 AndAlso ePosAsigna.PosAsigna = 0 Then
         Return String.Empty
      End If
      If ePosOrigen.PosAsigna = ePosAsigna.PosOrigen AndAlso ePosAsigna.PosAsigna = ePosOrigen.PosOrigen Then
         Return "Posición de Origen y de Destino ya fueron previamente Vinculadas"
      End If
      If ePosOrigen.PosAsigna <> 0 AndAlso ePosAsigna.PosAsigna = 0 Then
         Return "Posición de Origen ya Vinculada a otro Destino"
      End If
      If ePosOrigen.PosAsigna = 0 AndAlso ePosAsigna.PosAsigna <> 0 Then
         Return "Posición de Destino ya Vinculada a otro Destino"
      End If
      If ePosOrigen.PosOrigen <> ePosAsigna.PosAsigna AndAlso ePosOrigen.PosAsigna <> ePosAsigna.PosOrigen Then
         Return "Las Posiciones de Origen y Destino no pueden ser Vinculadas"
      End If
      '--
      Return String.Empty
   End Function

End Class

Public Class eSucursalDepositoUbicacion
   Public Property PosOrigen As Long
   Public Property PosAsigna As Long

End Class