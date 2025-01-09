Option Explicit On
Option Strict On
Public Class ContabilidadAsientosModelos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ContabilidadAsientosModelos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region


   Private Sub CargarUna(ByVal o As Entidades.ContabilidadAsientoModelo, ByVal dr As DataRow, ByVal dtDetalle As DataTable)
      'IdPlanCuenta()
      'NombrePlanCuenta()
      'IdAsiento()
      'NombreAsiento()
      'idCuenta()
      'NombreCuenta()
      With o
         .IdPlanCuenta = Integer.Parse(dr(Entidades.ContabilidadAsientoModelo.Columnas.IdPlanCuenta.ToString()).ToString())
         .NombrePlanCuenta = dr(Entidades.ContabilidadAsientoModelo.Columnas.NombrePlanCuenta.ToString()).ToString()
         .IdAsiento = Integer.Parse(dr(Entidades.ContabilidadAsientoModelo.Columnas.IdAsiento.ToString()).ToString())
         .NombreAsiento = dr(Entidades.ContabilidadAsientoModelo.Columnas.NombreAsiento.ToString()).ToString()
         .idCuenta = Integer.Parse(dr(Entidades.ContabilidadAsientoModelo.Columnas.idCuenta.ToString()).ToString())
         .NombreCuenta = dr(Entidades.ContabilidadAsientoModelo.Columnas.NombreCuenta.ToString()).ToString
         .DetallesAsiento = dtDetalle
      End With
   End Sub

   Public Function GetTodos() As List(Of Entidades.ContabilidadAsientoModelo)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ContabilidadAsientoModelo
      Dim dtDetalle As DataTable = Nothing ' no cargo los detalles del asiento cuando muestro la grilla de busqueda
      Dim oLis As List(Of Entidades.ContabilidadAsientoModelo) = New List(Of Entidades.ContabilidadAsientoModelo)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ContabilidadAsientoModelo
         Me.CargarUna(o, dr, dtDetalle)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUna(ByVal idPlan As Integer, ByVal idAsiento As Integer) As Entidades.ContabilidadAsientoModelo
      Dim sql As SqlServer.ContabilidadAsientosModelos = New SqlServer.ContabilidadAsientosModelos(Me.da)
      Dim dt As DataTable = sql.Asientos_G1(idPlan, idAsiento)
      Dim dtDetalle As DataTable = sql.Asiento_GetDetalle(idPlan, idAsiento)
      Dim o As Entidades.ContabilidadAsientoModelo = New Entidades.ContabilidadAsientoModelo
      If dt.Rows.Count > 0 Then
         Me.CargarUna(o, dt.Rows(0), dtDetalle)
      Else
         Throw New Exception("No existe el asiento modelo")
      End If
      Return o
   End Function

   Public Function Get1(ByVal idPlan As Integer, ByVal idAsiento As Integer) As DataTable
      Dim sql As SqlServer.ContabilidadAsientosModelos = New SqlServer.ContabilidadAsientosModelos(Me.da)
      Return sql.Asientos_G1(idPlan, idAsiento)
   End Function

   Public Function GetPorNombre(ByVal dscAsiento As String) As DataTable
      Dim sql As SqlServer.ContabilidadAsientosModelos = New SqlServer.ContabilidadAsientosModelos(Me.da)
      Return sql.GetPorNombre(dscAsiento)
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ContabilidadAsientosModelos(Me.da).Asientos_GA()
   End Function

   Public Function GetIdMaximo(ByVal idPlan As Integer) As Integer

      Dim sql As SqlServer.ContabilidadAsientosModelos = New SqlServer.ContabilidadAsientosModelos(Me.da)
      Dim dt As DataTable = sql.Asiento_GetIdMaximo(idPlan)
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As System.Data.DataTable
      Dim sql As SqlServer.ContabilidadAsientosModelos = New SqlServer.ContabilidadAsientosModelos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function



#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.ContabilidadAsientoModelo = DirectCast(entidad, Entidades.ContabilidadAsientoModelo)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ContabilidadAsientosModelos = New SqlServer.ContabilidadAsientosModelos(Me.da)

         Select Case tipo

            Case TipoSP._I
               For Each fila As DataRow In en.DetallesAsiento.Rows
                  sql.Asiento_I(CInt(fila("IdAsiento")) _
                            , en.NombreAsiento _
                            , CInt(fila("IdPlanCuenta")) _
                            , CInt(fila("idCuenta")))

               Next



            Case TipoSP._U

               sql.Asiento_D(en.IdPlanCuenta, en.IdAsiento)

               For Each fila As DataRow In en.DetallesAsiento.Rows
                  sql.Asiento_I(CInt(fila("IdAsiento")) _
                           , en.NombreAsiento _
                           , CInt(fila("IdPlanCuenta")) _
                           , CInt(fila("idCuenta")))

                  'sql.Asiento_U(CInt(fila("IdAsiento")) _
                  '              , en.NombreAsiento _
                  '              , CInt(fila("IdPlanCuenta")) _
                  '              , CInt(fila("idCuenta")))


               Next

            Case TipoSP._D
               sql.Asiento_D(en.IdPlanCuenta, en.IdAsiento)


         End Select

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

#End Region

   Public Function GetAllDistinct() As DataTable
      Return New SqlServer.ContabilidadAsientosModelos(Me.da).Asientos_GAD()
   End Function

End Class
