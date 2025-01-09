Option Explicit On
Option Strict On

Imports Eniac.Reglas.ServiciosRest.Sincronizacion

Public Class Localidades
   Inherits Eniac.Reglas.BaseSync(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte, Entidades.JSonEntidades.Archivos.LocalidadJSon)
   Implements IRestServices
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte, Entidades.JSonEntidades.Archivos.LocalidadJSon)

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Localidades"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Localidades"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Localidad)))
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Localidad)))
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Localidad)))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      If entidad.Columna = "NombreProvincia" Then
         entidad.Columna = "P." + entidad.Columna
      Else
         entidad.Columna = "L." + entidad.Columna
      End If
      With stbQuery
         .Append("SELECT  ")
         .Append("L.IdLocalidad, ")
         .Append("L.NombreLocalidad, ")
         .Append("P.IdProvincia, ")
         .Append("P.NombreProvincia ")
         .Append("FROM Localidades L ")
         .Append("  INNER JOIN Provincias P ON L.IdProvincia = P.IdProvincia ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Localidades(Me.da).Localidades_GA(Nothing)
   End Function

   Public Function GetTodas() As List(Of Entidades.Localidad)
      Try
         Me.da.OpenConection()
         Return _GetTodas()
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function _GetTodas() As List(Of Entidades.Localidad)
      Try
         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.Localidad
         Dim oLis As List(Of Entidades.Localidad) = New List(Of Entidades.Localidad)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.Localidad()
            Me.CargarUna(o, dr)
            oLis.Add(o)
         Next
         Return oLis
      Catch
         Throw
      End Try
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(loca As Entidades.Localidad, tipo As TipoSP)
      Dim sqlLocalidades = New SqlServer.Localidades(da)
      Select Case tipo
         Case TipoSP._I
            sqlLocalidades.Localidades_I(loca.IdLocalidad, loca.IdProvincia, loca.NombreLocalidad)
         Case TipoSP._U
            sqlLocalidades.Localidades_U(loca.IdLocalidad, loca.IdProvincia, loca.NombreLocalidad)
         Case TipoSP._D
            sqlLocalidades.Localidades_D(loca.IdLocalidad)
      End Select
   End Sub
   Private Sub CargarUna(o As Entidades.Localidad, dr As DataRow)
      With o
         .IdLocalidad = dr.Field(Of Integer)(Entidades.Localidad.Columnas.IdLocalidad.ToString())
         .NombreLocalidad = dr.Field(Of String)(Entidades.Localidad.Columnas.NombreLocalidad.ToString())
         .IdProvincia = dr.Field(Of String)(Entidades.Localidad.Columnas.IdProvincia.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Function _Insertar(entidad As Entidades.Localidad) As Entidades.Localidad
      Me.EjecutaSP(entidad, TipoSP._I)
      Return entidad
   End Function

   Public Sub _Actualizar(entidad As Entidades.Localidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.Localidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUna(idLocalidad As Integer) As Entidades.Localidad
      Return GetUna(idLocalidad, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idLocalidad As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Localidad
      Return CargaEntidad(New SqlServer.Localidades(Me.da).Localidades_G1(idLocalidad),
                          Sub(o, dr)
                             o.IdLocalidad = dr.Field(Of Integer?)("IdLocalidad").IfNull()
                             o.IdProvincia = dr.Field(Of String)("IdProvincia")
                             o.NombreLocalidad = dr.Field(Of String)("NombreLocalidad")
                             o.NombreProvincia = dr.Field(Of String)("NombreProvincia")
                          End Sub,
                          Function() New Entidades.Localidad,
                          accion, Function() String.Format("No existe localidad con Id '{0}'", idLocalidad))
   End Function

   Public Function GetPorCodigo(ByVal IdLocalidad As Integer) As DataTable

      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.Localidades = New SqlServer.Localidades(Me.da)
         Dim dt As DataTable
         dt = sql.Localidades_GPorCodigoUnico(IdLocalidad)
         If dt.Rows.Count = 0 Then
            dt = sql.Localidades_GPorCodigo(IdLocalidad)
         End If
         Return dt
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetPorNombre(ByVal Nombre As String) As DataTable

      Try
         Me.da.OpenConection()
         Return _GetPorNombre(Nombre)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function
   Public Function _GetPorNombre(nombre As String) As DataTable
      Return New SqlServer.Localidades(Me.da).Localidades_GPorNombre(Nombre)
   End Function

   Public Function GetPorNombreEntidad(nombre As String, accion As AccionesSiNoExisteRegistro) As Entidades.Localidad
      Return CargaEntidad(_GetPorNombre(nombre),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.Localidad,
                          accion, Function() String.Format("No se encuentró una localidad con nombre {0}", nombre))
   End Function

   Public Function Existe(ByVal cp As Integer) As Boolean
      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.Localidades = New SqlServer.Localidades(Me.da)

         Return sql.Existe(cp)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function
#End Region

End Class