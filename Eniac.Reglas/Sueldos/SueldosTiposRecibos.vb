Public Class SueldosTiposRecibos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosTiposRecibos"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "SueldosTiposRecibos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._U)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.SueldosTiposRecibos = New SqlServer.SueldosTiposRecibos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosTiposRecibos(Me.da).SueldosTiposRecibos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.SueldosTipoRecibo = DirectCast(entidad, Entidades.SueldosTipoRecibo)

      Dim sql As SqlServer.SueldosTiposRecibos = New SqlServer.SueldosTiposRecibos(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.SueldosTiposRecibos_I(en.IdTipoRecibo,
                                      en.NombreTipoRecibo,
                                      en.PeriodoLiquidacion,
                                      en.NumeroLiquidacion,
                                      en.ImprimeRecibo,
                                      en.CantidadLiquid,
                                      en.CantidadLiquidPeriodo,
                                      en.FechaPago,
                                      en.LiquidacionEventual)
         Case TipoSP._U
            sql.SueldosTiposRecibos_U(en.IdTipoRecibo,
                                      en.NombreTipoRecibo,
                                      en.PeriodoLiquidacion,
                                      en.NumeroLiquidacion,
                                      en.ImprimeRecibo,
                                      en.CantidadLiquid,
                                      en.CantidadLiquidPeriodo,
                                      en.FechaPago,
                                      en.LiquidacionEventual)
         Case TipoSP._D
            sql.SueldosTiposRecibos_D(en.IdTipoRecibo)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.SueldosTipoRecibo, ByVal dr As DataRow)
      With o
         .IdTipoRecibo = Int32.Parse(dr(Entidades.SueldosTipoRecibo.Columnas.IdTipoRecibo.ToString()).ToString())
         .NombreTipoRecibo = dr(Entidades.SueldosTipoRecibo.Columnas.NombreTipoRecibo.ToString()).ToString()
         .PeriodoLiquidacion = Int32.Parse(dr(Entidades.SueldosTipoRecibo.Columnas.PeriodoLiquidacion.ToString()).ToString())
         .NumeroLiquidacion = Int32.Parse(dr(Entidades.SueldosTipoRecibo.Columnas.NumeroLiquidacion.ToString()).ToString())
         .ImprimeRecibo = Boolean.Parse(dr(Entidades.SueldosTipoRecibo.Columnas.ImprimeRecibo.ToString()).ToString())
         .CantidadLiquid = Int32.Parse(dr(Entidades.SueldosTipoRecibo.Columnas.CantidadLiquid.ToString()).ToString())
         .CantidadLiquidPeriodo = Int32.Parse(dr(Entidades.SueldosTipoRecibo.Columnas.CantidadLiquidPeriodo.ToString()).ToString())
         .FechaPago = Date.Parse(dr(Entidades.SueldosTipoRecibo.Columnas.FechaPago.ToString()).ToString())
         .LiquidacionEventual = Boolean.Parse(dr(Entidades.SueldosTipoRecibo.Columnas.LiquidacionEventual.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.SueldosTipoRecibo)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.SueldosTipoRecibo
         Dim oLis As List(Of Entidades.SueldosTipoRecibo) = New List(Of Entidades.SueldosTipoRecibo)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.SueldosTipoRecibo()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next

         Me.da.CommitTransaction()
         Return oLis

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetUno(ByVal idTipoRecibo As Integer) As Entidades.SueldosTipoRecibo
      Try
         Me.da.OpenConection()

         Return Me._GetUno(idTipoRecibo)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Friend Function _GetUno(ByVal idTipoRecibo As Integer) As Entidades.SueldosTipoRecibo

      Dim sql As SqlServer.SueldosTiposRecibos = New SqlServer.SueldosTiposRecibos(Me.da)

      Dim dt As DataTable = sql.SueldosTiposRecibos_G1(idTipoRecibo)

      Dim o As Entidades.SueldosTipoRecibo = New Entidades.SueldosTipoRecibo()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la SueldosTipoRecibo.")
      End If

      Return o

   End Function

#End Region

End Class
