Public Class CajasUsuarios

   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CajaUsuario"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CajaUsuario"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Inserta(entidad)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Actualiza(entidad)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)

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

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CajasUsuarios(da).CajasUsuarios_GA()
   End Function

   Public Function GetCajas(idSucursal As Integer, usuario As String, nombrePC As String, cajasModificables As Boolean) As System.Data.DataTable
      Try
         da.OpenConection()
         Dim sucursal As Entidades.Sucursal = New Sucursales(da).GetUna(idSucursal, False)
         Return _GetCajas({sucursal}, usuario, nombrePC, cajasModificables)
      Catch ex As Exception
         Throw
      Finally
         da.CloseConection()
      End Try
   End Function

   Public Function GetCajasTodas(sucursales As Entidades.Sucursal(), usuario As String, nombrePC As String, cajasModificables As Boolean) As List(Of Entidades.CajaNombre)
      Return New CajasNombres(da).CargaLista(_GetCajas(sucursales, usuario, nombrePC, cajasModificables))
   End Function

   Public Function GetCajas(sucursales As Entidades.Sucursal(), usuario As String, nombrePC As String, cajasModificables As Boolean) As System.Data.DataTable
      Return EjecutaConConexion(Function() _GetCajas(sucursales, usuario, nombrePC, cajasModificables))
   End Function

   Friend Function _GetCajas(sucursales As Entidades.Sucursal(), usuario As String, nombrePC As String, cajasModificables As Boolean) As System.Data.DataTable
      Return New SqlServer.CajasUsuarios(da).GetCajas(sucursales, usuario, nombrePC, cajasModificables)
   End Function

   Public Function GetCajasxNombre(Nombre As String, sucursales As Entidades.Sucursal(), usuario As String, nombrePC As String, cajasModificables As Boolean) As System.Data.DataTable
      Return EjecutaConConexion(Function() _GetCajasxNombre(Nombre, sucursales, usuario, nombrePC, cajasModificables))
   End Function
   Friend Function _GetCajasxNombre(Nombre As String, sucursales As Entidades.Sucursal(), usuario As String, nombrePC As String, cajasModificables As Boolean) As System.Data.DataTable
      Return New SqlServer.CajasUsuarios(da).GetCajasxNombre(Nombre, sucursales, usuario, nombrePC, cajasModificables)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim cajas As Entidades.CajaNombre = DirectCast(entidad, Entidades.CajaNombre)
      Dim sql As SqlServer.CajasNombres = New SqlServer.CajasNombres(da)

      Select Case tipo
         Case TipoSP._I
            sql.CajasNombres_I(cajas.IdSucursal, cajas.IdCaja, cajas.NombreCaja,
                               cajas.NombrePC, cajas.IdUsuario, cajas.IdPlanCuenta,
                               cajas.TopeAviso, cajas.TopeBloqueo, cajas.IdCuentaContable,
                               cajas.Color, cajas.IdTipoComprobanteF3, cajas.IdTipoComprobanteF4,
                               cajas.IdTipoComprobanteF10Origen, cajas.IdTipoComprobanteF10Destino)
         Case TipoSP._U
            sql.CajasNombres_U(cajas.IdSucursal, cajas.IdCaja, cajas.NombreCaja,
                               cajas.NombrePC, cajas.IdUsuario, cajas.IdPlanCuenta,
                               cajas.TopeAviso, cajas.TopeBloqueo, cajas.IdCuentaContable,
                               cajas.Color, cajas.IdTipoComprobanteF3, cajas.IdTipoComprobanteF4,
                               cajas.IdTipoComprobanteF10Origen, cajas.IdTipoComprobanteF10Destino)
         Case TipoSP._D
            sql.CajasNombres_D(cajas.IdSucursal, cajas.IdCaja)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.CajaNombre, dr As DataRow)

      With o
         .IdSucursal = Integer.Parse(dr(Entidades.CajaNombre.Columnas.IdSucursal).ToString())
         .IdCaja = Int32.Parse(dr(Entidades.CajaNombre.Columnas.IdCaja).ToString())
         .NombreCaja = dr(Entidades.CajaNombre.Columnas.NombreCaja).ToString()
         .IdPlanCuenta = Int32.Parse(dr(Entidades.CajaNombre.Columnas.IdPlanCuenta).ToString())
      End With

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub Inserta(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Function GetTodas() As List(Of Entidades.CajaNombre)
      Try
         Me.da.OpenConection()

         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.CajaNombre
         Dim oLis As List(Of Entidades.CajaNombre) = New List(Of Entidades.CajaNombre)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.CajaNombre()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next
         Return oLis
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetUna(IdSucursal As Integer, IdCaja As Integer) As Entidades.CajaNombre
      Dim sql As SqlServer.CajasNombres = New SqlServer.CajasNombres(da)
      Dim dt As DataTable = sql.CajasNombres_G1(IdSucursal, IdCaja)
      Dim o As Entidades.CajaNombre = New Entidades.CajaNombre()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la Caja.")
      End If
      Return o
   End Function

   Public Function GetUsuariosPorCaja(caja As String, sucursal As Integer) As DataTable
      Try
         Me.da.OpenConection()

         Dim stb As StringBuilder = New StringBuilder("")
         With stb
            .Append(" SELECT CU.IdSucursal, CU.IdCaja, CU.IdUsuario, U.Nombre, CU.PermitirEscritura  ")
            .Append(" FROM CajasUsuarios CU  ")
            .AppendLine(" INNER JOIN Usuarios U ON U.Id = CU.IdUsuario")
            .Append(" WHERE IdCaja = " & caja)
            .Append(" AND IdSucursal = " & sucursal)
            .Append(" ORDER BY IdCaja")
         End With

         Return Me.da.GetDataTable(stb.ToString())

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function GetCajaPorUsuario(caja As Integer, idSucursal As Integer, IdUsuario As String) As DataTable

      Return New SqlServer.CajasUsuarios(da).GetCajaPorUsuario(caja,
                                                               idSucursal,
                                                               IdUsuario)
   End Function

#End Region

End Class
