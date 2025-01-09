Public Class EscalasRetGanancias
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "EscalasRetGanancias"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "EscalasRetGanancias"
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
      Dim sql As SqlServer.EscalasRetGanancias = New SqlServer.EscalasRetGanancias(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EscalasRetGanancias(Me.da).EscalasRetGanancias_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.EscalaRetGanancias = DirectCast(entidad, Entidades.EscalaRetGanancias)

      Dim sql As SqlServer.EscalasRetGanancias = New SqlServer.EscalasRetGanancias(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.EscalasRetGanancias_I(en.IdEscala, en.MontoMasDe, en.MontoA, en.Importe, en.MasPorcentaje, en.SobreExcedente)
                            
         Case TipoSP._U
            sql.EscalasRetGanancias_U(en.IdEscala, en.MontoMasDe, en.MontoA, en.Importe, en.MasPorcentaje, en.SobreExcedente)

         Case TipoSP._D
            sql.EscalasRetGanancias_D(en.IdEscala)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.EscalaRetGanancias, ByVal dr As DataRow)
      With o
         .IdEscala = Int32.Parse(dr(Entidades.EscalaRetGanancias.Columnas.IdEscala.ToString()).ToString())
         .MontoMasDe = Decimal.Parse(dr(Entidades.EscalaRetGanancias.Columnas.MontoMasDe.ToString()).ToString())
         .MontoA = Decimal.Parse(dr(Entidades.EscalaRetGanancias.Columnas.MontoA.ToString()).ToString())
         .Importe = Decimal.Parse(dr(Entidades.EscalaRetGanancias.Columnas.Importe.ToString()).ToString())
         .MasPorcentaje = Decimal.Parse(dr(Entidades.EscalaRetGanancias.Columnas.MasPorcentaje.ToString()).ToString())
         .SobreExcedente = Decimal.Parse(dr(Entidades.EscalaRetGanancias.Columnas.SobreExcedente.ToString()).ToString())

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.EscalaRetGanancias)
      Try
         Me.da.OpenConection()

         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.EscalaRetGanancias
         Dim oLis As List(Of Entidades.EscalaRetGanancias) = New List(Of Entidades.EscalaRetGanancias)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.EscalaRetGanancias()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next

         Return oLis

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetUno(ByVal idEscala As Integer) As Entidades.EscalaRetGanancias
      Try
         Me.da.OpenConection()

         Return Me._GetUno(idEscala)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Friend Function _GetUno(ByVal idEscala As Integer) As Entidades.EscalaRetGanancias

      Dim sql As SqlServer.EscalasRetGanancias = New SqlServer.EscalasRetGanancias(Me.da)

      Dim dt As DataTable = sql.EscalasRetGanancias_G1(idEscala)

      Dim o As Entidades.EscalaRetGanancias = New Entidades.EscalaRetGanancias()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la Escala.")
      End If

      Return o

   End Function

#End Region




End Class
