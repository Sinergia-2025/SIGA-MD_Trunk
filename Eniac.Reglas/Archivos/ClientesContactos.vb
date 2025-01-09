Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class ClientesContactos
   Inherits Eniac.Reglas.Base

   Private Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

   Public Sub New(modo As Entidades.Cliente.ModoClienteProspecto)
      Me.New()
      ModoClienteProspecto = modo
      Me.NombreEntidad = modo.ToString() + "s"
   End Sub

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ClientesContactos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ClientesContactos"
      da = accesoDatos
   End Sub

#End Region

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteContacto), TipoSP._I)
   End Sub

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteContacto), TipoSP._I)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteContacto), TipoSP._D)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteContacto), TipoSP._U)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ClienteContacto), TipoSP._U)
   End Sub

   Public Sub EjecutaSP(ByVal en As Eniac.Entidades.ClienteContacto, ByVal tipo As TipoSP)
      Dim sql As SqlServer.ClientesContactos = New SqlServer.ClientesContactos(da)

      Select Case tipo
         Case TipoSP._I
            sql.ClientesContactos_I(en.IdCliente, en.IdContacto, en.NombreContacto, en.Direccion, en.Localidad.IdLocalidad,
                                    en.Telefono, en.CorreoElectronico, en.Celular, en.Observacion, en.Activo, en.IdUsuario, en.TipoContacto.IdTipoContacto)
         Case TipoSP._U
            sql.ClientesContactos_U(en.IdCliente, en.IdContacto, en.NombreContacto, en.Direccion, en.Localidad.IdLocalidad,
                                    en.Telefono, en.CorreoElectronico, en.Celular, en.Observacion, en.Activo, en.IdUsuario, en.TipoContacto.IdTipoContacto)
      End Select
   End Sub


   'Public Sub GrabarClientesContactos(ByVal IdCliente As Long, _
   '                                        ByVal listado As DataTable)
   '   Try
   '      Me.da.OpenConection()
   '      Me.da.BeginTransaction()

   '      Dim sql As SqlServer.ClientesActividades = New SqlServer.ClientesActividades(Me.da)

   '      sql.ClientesActividades_D(IdCliente, "", 0)

   '      For Each dr As DataRow In listado.Rows
   '         If dr.RowState <> DataRowState.Deleted AndAlso _
   '             (Decimal.Parse(dr("DescuentoRecargoPorc1").ToString()) <> 0 Or Decimal.Parse(dr("DescuentoRecargoPorc2").ToString()) <> 0) Then

   '            sql.ClientesActividades_I(Long.Parse(dr("IdCliente").ToString()), _
   '                                           dr("IdProvincia").ToString(), _
   '                                           Integer.Parse(dr("IdActividad").ToString()))
   '         End If
   '      Next

   '      Me.da.CommitTransaction()

   '   Catch ex As Exception
   '      Me.da.RollbakTransaction()
   '      Throw ex
   '   Finally
   '      Me.da.CloseConection()
   '   End Try
   'End Sub

   Public Function GetClientesContactos(ByVal IdCliente As Long) As DataTable
      Return GetClientesContactos(IdCliente, 0, Nothing)
   End Function
   Public Function GetClientesContactos(ByVal IdCliente As Long, activo As Boolean?) As DataTable
      Return GetClientesContactos(IdCliente, 0, activo)
   End Function

   Public Function GetClientesContactos(ByVal IdCliente As Long, idContacto As Integer, activo As Boolean?) As DataTable

      Dim sql As SqlServer.ClientesContactos
      Dim dt As DataTable

      Try

         sql = New SqlServer.ClientesContactos(Me.da, ModoClienteProspecto)
         dt = sql.GetClientesContactos(IdCliente, idContacto, activo)

         Return dt
      Catch ex As Exception
         Throw
      End Try

   End Function

   Public Function GetDireccionCliente(ByVal IdCliente As Long, ByVal IdContacto As Integer) As DataTable

      Dim sql As SqlServer.ClientesContactos
      Dim dt As DataTable

      Try

         sql = New SqlServer.ClientesContactos(Me.da)
         dt = sql.GetContactoCliente(IdCliente, IdContacto)

         Return dt
      Catch ex As Exception
         Throw
      End Try

   End Function

   'Public Function GetContactos(ByVal IdCliente As Long) As DataTable

   '   'Dim sql As SqlServer.ClientesContactos
   '   'Dim dt As DataTable

   '   'Try

   '   '   sql = New SqlServer.ClientesContactos(Me.da)
   '   '   dt = sql.GetContactos(IdCliente)

   '   '   Return dt
   '   'Catch ex As Exception
   '   '   Throw
   '   'End Try

   'End Function

   Public Function GetCodigoMaximo(idCliente As Long) As Long
      Dim sql As SqlServer.ClientesContactos = New SqlServer.ClientesContactos(da)

      Return sql.GetCodigoMaximo(idCliente)
   End Function

   Private Function GetCodigoPorContactoNombre(nombreContacto As String, idCliente As Long) As Integer
      Dim sql As SqlServer.ClientesContactos = New SqlServer.ClientesContactos(da)
      Dim dt As DataTable = sql.GetCodigoPorContactoNombre(nombreContacto, idCliente)
      Dim dr As DataRow = dt.Rows(0)

      Return dr.Field(Of Integer)(Entidades.ClienteContacto.Columnas.IdContacto.ToString())
   End Function

   Private Sub CargarUno(ByVal o As Entidades.ClienteContacto, ByVal dr As DataRow)
      With o
         .IdCliente = Long.Parse(dr(Entidades.ClienteContacto.Columnas.IdCliente.ToString()).ToString())
         .IdContacto = Integer.Parse(dr(Entidades.ClienteContacto.Columnas.IdContacto.ToString()).ToString())
         .NombreContacto = dr(Entidades.ClienteContacto.Columnas.NombreContacto.ToString()).ToString()
         .Direccion = dr(Entidades.ClienteContacto.Columnas.NombreContacto.ToString()).ToString()
         .Localidad = New Reglas.Localidades(da).GetUna(Integer.Parse(dr(Entidades.ClienteContacto.Columnas.IdLocalidad.ToString()).ToString()))
         .Telefono = dr(Entidades.ClienteContacto.Columnas.Telefono.ToString()).ToString()
         .CorreoElectronico = dr(Entidades.ClienteContacto.Columnas.CorreoElectronico.ToString()).ToString()
         .Celular = dr(Entidades.ClienteContacto.Columnas.Celular.ToString()).ToString()
         .Observacion = dr(Entidades.ClienteContacto.Columnas.Observacion.ToString()).ToString()
         .Activo = Boolean.Parse(dr(Entidades.ClienteContacto.Columnas.Activo.ToString()).ToString())
         .IdUsuario = dr(Entidades.ClienteContacto.Columnas.IdUsuario.ToString()).ToString()
         .TipoContacto = New Reglas.TiposContactos(da).GetUna(Integer.Parse(dr(Entidades.ClienteContacto.Columnas.IdTipoContacto.ToString()).ToString()))
      End With
   End Sub

   Public Function GetTodos(idCliente As Long, activo As Boolean?) As List(Of Entidades.ClienteContacto)
      Dim dt As DataTable = Me.GetClientesContactos(idCliente, activo)
      Dim oLis As List(Of Entidades.ClienteContacto) = New List(Of Entidades.ClienteContacto)
      For Each dr As DataRow In dt.Rows
         Dim o As Entidades.ClienteContacto = New Entidades.ClienteContacto()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(idCliente As Long, idContacto As Integer) As Entidades.ClienteContacto
      Dim dt As DataTable = Me.GetClientesContactos(idCliente, idContacto, Nothing)
      Dim oLis As List(Of Entidades.ClienteContacto) = New List(Of Entidades.ClienteContacto)

      If dt.Rows.Count > 0 Then
         Dim o As Entidades.ClienteContacto = New Entidades.ClienteContacto()
         Me.CargarUno(o, dt.Rows(0))
         Return o
      Else
         Throw New Exception(String.Format("No se encontró Contacto de Cliente.", idCliente, idContacto))
      End If
   End Function

   Public Function Existe(nombreContacto As String) As Boolean
      Return Existe(nombreContacto:=nombreContacto, idCliente:=0)
   End Function

   Public Function Existe(idCliente As Long) As Boolean
      Return Existe(nombreContacto:=Nothing, idCliente:=idCliente)
   End Function

   Public Function Existe(nombreContacto As String, idCliente As Long) As Boolean
      Dim sql As SqlServer.ClientesContactos = New SqlServer.ClientesContactos(da)
      Return If(sql.Existe(nombreContacto, idCliente).Rows.Count > 0, True, False)
   End Function

   Public Sub ImportarContactos(idSucursal As Integer,
                                     datos As DataTable,
                                     usuario As String,
                                     barraProg As System.Windows.Forms.ProgressBar)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim enContacto As Entidades.ClienteContacto = New Entidades.ClienteContacto
         Dim i As Integer = 0
         Dim codigoContacto As Integer = 0
         Dim idCliente As Long = 0

         barraProg.Maximum = datos.Rows.Count
         barraProg.Minimum = 0
         barraProg.Value = 0

         For Each dr As DataRow In datos.Rows
            i += 1
            barraProg.Value = i

            If dr.Field(Of Boolean)("Importa") Then

               idCliente = dr.Field(Of Long)(Entidades.ClienteContacto.Columnas.IdCliente.ToString())

               ' # Si el registro es para actualizar, busco el IdContacto del registro
               ' # Caso contrario le asigno uno nuevo
               If dr.Field(Of String)("Accion") = "A" Then
                  codigoContacto = Integer.Parse(GetCodigoMaximo(dr.Field(Of Long)(Entidades.ClienteContacto.Columnas.IdCliente.ToString())).ToString()) + 1
               Else
                  codigoContacto = GetCodigoPorContactoNombre(dr.Field(Of String)(Entidades.ClienteContacto.Columnas.NombreContacto.ToString()), idCliente)
               End If

               ' Seteo la entidad
               With enContacto

                  .IdCliente = idCliente
                  .IdContacto = codigoContacto
                  .NombreContacto = dr.Field(Of String)(Entidades.ClienteContacto.Columnas.NombreContacto.ToString())
                  .TipoContacto.IdTipoContacto = dr.Field(Of Integer)(Entidades.ClienteContacto.Columnas.IdTipoContacto.ToString())
                  .Direccion = dr.Field(Of String)(Entidades.ClienteContacto.Columnas.Direccion.ToString())
                  .Localidad.IdLocalidad = dr.Field(Of Integer)(Entidades.ClienteContacto.Columnas.IdLocalidad.ToString())
                  .Telefono = dr.Field(Of String)(Entidades.ClienteContacto.Columnas.Telefono.ToString())
                  .Celular = dr.Field(Of String)(Entidades.ClienteContacto.Columnas.Celular.ToString())
                  .CorreoElectronico = dr.Field(Of String)(Entidades.ClienteContacto.Columnas.CorreoElectronico.ToString())
                  .Observacion = dr.Field(Of String)(Entidades.ClienteContacto.Columnas.Observacion.ToString())
                  .Activo = True
                  .IdUsuario = usuario

               End With


               If dr.Field(Of String)("Accion") = "A" Then
                  ' I
                  Inserta(enContacto)
               Else
                  ' U
                  Actualiza(enContacto)
               End If

            End If
         Next

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
End Class