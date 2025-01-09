Public Class Nacionalidades
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = Entidades.Nacionalidad.NombreTabla
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.Nacionalidad.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.Nacionalidad), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.Nacionalidad), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.Nacionalidad), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Nacionalidades = New SqlServer.Nacionalidades(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Nacionalidades(Me.da).Nacionalidades_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.Nacionalidad, tipo As TipoSP)

      Dim sNacionalidad As SqlServer.Nacionalidades = New SqlServer.Nacionalidades(da)
      Select Case tipo
         Case TipoSP._I
            sNacionalidad.Nacionalidades_I(en.IdNacionalidad, en.NombreNacionalidad)
         Case TipoSP._U
            sNacionalidad.Nacionalidades_U(en.IdNacionalidad, en.NombreNacionalidad)
         Case TipoSP._D
            sNacionalidad.Nacionalidades_D(en.IdNacionalidad)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Nacionalidad, dr As DataRow)
      With o
         .IdNacionalidad = dr.Field(Of Integer)(Entidades.Nacionalidad.Columnas.IdNacionalidad.ToString())
         .NombreNacionalidad = dr.Field(Of String)(Entidades.Nacionalidad.Columnas.NombreNacionalidad.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idNacionalidad As Integer) As Entidades.Nacionalidad
      Return GetUno(idNacionalidad, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idNacionalidad As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Nacionalidad
      Return CargaEntidad(New SqlServer.Nacionalidades(Me.da).Nacionalidades_G1(idNacionalidad),
         Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.Nacionalidad(),
         accion, Function() String.Format("No existe la Nacionalidad con Id: {0}", idNacionalidad))
   End Function

   Public Function GetTodas() As List(Of Entidades.Nacionalidad)
      Return CargaLista(New SqlServer.Nacionalidades(Me.da).Nacionalidades_GA(),
         Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.Nacionalidad())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Nacionalidades(Me.da).GetCodigoMaximo()
   End Function

   'Public Function GetPorNombreExacto(ByVal nombre As String) As DataTable

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Length = 0
   '      .AppendLine("SELECT N.IdNacionalidad")
   '      .AppendLine("      ,N.NombreNacionalidad")
   '      .AppendLine("  FROM Nacionalidades N")
   '      .AppendLine(" WHERE N.NombreNacionalidad = '" & nombre & "' ")
   '   End With

   '   Return Me.da.GetDataTable(stb.ToString())

   'End Function
#End Region
End Class
