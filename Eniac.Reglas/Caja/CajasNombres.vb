Public Class CajasNombres

   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CajaNombre"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CajaNombre"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub InsertarUna(entidad As Eniac.Entidades.Entidad, usuarios As DataTable)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Inserta(entidad, usuarios)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub ActualizarUna(entidad As Eniac.Entidades.Entidad, usuarios As DataTable)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Actualiza(entidad, usuarios)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub BorrarUna(entidad As Eniac.Entidades.Entidad, usuarios As DataTable)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D, usuarios)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(args As Entidades.Buscar) As DataTable
      Return Buscar(args, actual.Sucursal.Id)
   End Function

   Public Overloads Function Buscar(entidad As Eniac.Entidades.Buscar, idSucursal As Integer) As DataTable
      Return New SqlServer.CajasNombres(da).Buscar(entidad.Columna, entidad.Valor.ToString(), idSucursal)
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CajasNombres(Me.da).CajasNombres_GA(actual.Sucursal.Id)
   End Function

   Public Overloads Function GetAll(idSucursal As Integer) As System.Data.DataTable
      Return New SqlServer.CajasNombres(Me.da).CajasNombres_GA(idSucursal)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP, usuarios As DataTable)

      Dim cajas As Entidades.CajaNombre = DirectCast(entidad, Entidades.CajaNombre)
      Dim sql As SqlServer.CajasNombres = New SqlServer.CajasNombres(Me.da)
      Dim sql1 As SqlServer.CajasUsuarios = New SqlServer.CajasUsuarios(Me.da)
      Dim pl As SqlServer.Cajas = New SqlServer.Cajas(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.CajasNombres_I(cajas.IdSucursal, cajas.IdCaja, cajas.NombreCaja,
                               cajas.NombrePC, cajas.IdUsuario, cajas.IdPlanCuenta,
                               cajas.TopeAviso, cajas.TopeBloqueo, cajas.IdCuentaContable,
                               cajas.Color, cajas.IdTipoComprobanteF3, cajas.IdTipoComprobanteF4,
                               cajas.IdTipoComprobanteF10Origen, cajas.IdTipoComprobanteF10Destino)

            If cajas.IdPlanCuenta = 0 Then cajas.IdPlanCuenta = 1 ' si no trae nada, le pongo un plan por defecto.
            pl.Cajas_I(cajas.IdSucursal, cajas.IdCaja, 1, Date.Now, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Nothing)

            sql1.CajasUsuarios_D(cajas.IdSucursal, cajas.IdCaja)

            If usuarios IsNot Nothing Then
               For Each dr As DataRow In usuarios.Rows

                  sql1.CajasUsuarios_I(Integer.Parse(dr("IdSucursal").ToString()), Integer.Parse(cajas.IdCaja.ToString()),
                                       dr("IdUsuario").ToString(), Boolean.Parse(dr("PermitirEscritura").ToString()))

               Next
            End If

         Case TipoSP._U
            sql.CajasNombres_U(cajas.IdSucursal, cajas.IdCaja, cajas.NombreCaja,
                               cajas.NombrePC, cajas.IdUsuario, cajas.IdPlanCuenta,
                               cajas.TopeAviso, cajas.TopeBloqueo, cajas.IdCuentaContable,
                               cajas.Color, cajas.IdTipoComprobanteF3, cajas.IdTipoComprobanteF4,
                               cajas.IdTipoComprobanteF10Origen, cajas.IdTipoComprobanteF10Destino)

            sql1.CajasUsuarios_D(cajas.IdSucursal, cajas.IdCaja)

            For Each dr As DataRow In usuarios.Rows

               sql1.CajasUsuarios_I(Integer.Parse(dr("IdSucursal").ToString()), Integer.Parse(dr("IdCaja").ToString()),
                                    dr("IdUsuario").ToString(), Boolean.Parse(dr("PermitirEscritura").ToString()))
            Next

         Case TipoSP._D

            sql1.CajasUsuarios_D(cajas.IdSucursal, cajas.IdCaja)

            pl.Cajas_D(cajas.IdSucursal, cajas.IdCaja)

            sql.CajasNombres_D(cajas.IdSucursal, cajas.IdCaja)

      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.CajaNombre, dr As DataRow)

      With o
         .IdSucursal = Integer.Parse(dr(Entidades.CajaNombre.Columnas.IdSucursal.ToString()).ToString())
         .IdCaja = Integer.Parse(dr(Entidades.CajaNombre.Columnas.IdCaja.ToString()).ToString())
         .NombreCaja = dr(Entidades.CajaNombre.Columnas.NombreCaja.ToString()).ToString()
         .NombrePC = dr(Entidades.CajaNombre.Columnas.NombrePC.ToString()).ToString()
         .IdUsuario = dr(Entidades.CajaNombre.Columnas.IdUsuario.ToString()).ToString()
         .NombreSucursal = dr("Nombre").ToString()
         .TopeAviso = Decimal.Parse(dr(Entidades.CajaNombre.Columnas.TopeAviso.ToString()).ToString())
         .TopeBloqueo = Decimal.Parse(dr(Entidades.CajaNombre.Columnas.TopeBloqueo.ToString()).ToString())

         If Not String.IsNullOrEmpty(dr(Entidades.CajaNombre.Columnas.IdPlanCuenta.ToString()).ToString()) Then
            .IdPlanCuenta = Integer.Parse(dr(Entidades.CajaNombre.Columnas.IdPlanCuenta.ToString()).ToString())
         End If

         If Not String.IsNullOrEmpty(dr(Entidades.CajaNombre.Columnas.IdCuentaContable.ToString()).ToString()) Then
            .IdCuentaContable = Long.Parse(dr(Entidades.CajaNombre.Columnas.IdCuentaContable.ToString()).ToString())
         End If

         If IsNumeric(dr(Entidades.CajaNombre.Columnas.Color.ToString()).ToString()) Then
            .Color = Integer.Parse(dr(Entidades.CajaNombre.Columnas.Color.ToString()).ToString())
         End If

         .IdTipoComprobanteF3 = dr(Entidades.CajaNombre.Columnas.IdTipoComprobanteF3.ToString()).ToString()
         .IdTipoComprobanteF4 = dr(Entidades.CajaNombre.Columnas.IdTipoComprobanteF4.ToString()).ToString()

         .IdTipoComprobanteF10Origen = dr(Entidades.CajaNombre.Columnas.IdTipoComprobanteF10Origen.ToString()).ToString()
         .IdTipoComprobanteF10Destino = dr(Entidades.CajaNombre.Columnas.IdTipoComprobanteF10Destino.ToString()).ToString()

      End With

   End Sub

   Friend Overloads Function CargaLista(dt As DataTable) As List(Of Entidades.CajaNombre)
      Dim o As Entidades.CajaNombre
      Dim oLis As List(Of Entidades.CajaNombre) = New List(Of Entidades.CajaNombre)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CajaNombre()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
#End Region

#Region "Metodos Publicos"

   Public Sub Inserta(entidad As Eniac.Entidades.Entidad, usuarios As DataTable)
      Me.EjecutaSP(entidad, TipoSP._I, usuarios)
   End Sub

   Public Sub Actualiza(entidad As Eniac.Entidades.Entidad, usuarios As DataTable)
      Me.EjecutaSP(entidad, TipoSP._U, usuarios)
   End Sub

   Public Function GetTodas(idSucursal As Integer) As List(Of Entidades.CajaNombre)
      Try
         Me.da.OpenConection()
         Return CargaLista(Me.GetAll(idSucursal))
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetTodas(sucursales As Entidades.Sucursal(), usuario As String, nombrePC As String, cajasModificables As Boolean) As List(Of Entidades.CajaNombre)
      Return EjecutaConConexion(Function() _GetTodas(sucursales, usuario, nombrePC, cajasModificables))
   End Function

   Public Function _GetTodas(sucursales As Entidades.Sucursal(), usuario As String, nombrePC As String, cajasModificables As Boolean) As List(Of Entidades.CajaNombre)
      Return CargaLista(New SqlServer.CajasNombres(da).CajasNombres_GA(sucursales, usuario, nombrePC, cajasModificables))
   End Function

   Public Function GetUna(IdSucursal As Integer, IdCaja As Integer) As Entidades.CajaNombre
      Dim sql As SqlServer.CajasNombres = New SqlServer.CajasNombres(Me.da)
      Dim dt As DataTable = sql.CajasNombres_G1(IdSucursal, IdCaja)
      Dim o As Entidades.CajaNombre = New Entidades.CajaNombre()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la Caja.")
      End If
      Return o
   End Function

   Public Function GetCodigoMaximo(IdSucursal As Integer) As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT")
         .Append(" MAX(IdCaja) as maximo ")
         .Append(" from CajasNombres")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Function GetPorNombre(nombre As String, IdSucursal As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT IdCaja,")
         .Append("	    NombreCaja")
         .Append("  FROM CajasNombres")
         .Append("	WHERE NombreCaja LIKE '%")
         .Append(nombre)
         .Append("%' ")
         .Append(" AND IdSucursal = " & IdSucursal)
         .Append("	ORDER BY NombreCaja")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

#End Region

End Class