Public Class GruposCamas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "GruposCamas"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.GrupoCama), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.GrupoCama), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.GrupoCama), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.GruposCamas(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.GruposCamas(da).GruposCamas_GA()
   End Function
   Public Function GetCodigoMaximo() As Short
      Return GetCodigoMaximo(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString()).ToShort()
   End Function
   Public Function GetCodigoMaximo(campo As String) As Long
      Return New SqlServer.GruposCamas(da).GetCodigoMaximo(campo)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.GrupoCama, tipo As TipoSP)
      Dim sqlC = New SqlServer.GruposCamas(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.GruposCamas_I(en)
         Case TipoSP._U
            sqlC.GruposCamas_U(en)
         Case TipoSP._D
            sqlC.GruposCamas_D(en.IdGrupoCama)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.GrupoCama, dr As DataRow)
      With o
         .IdGrupoCama = dr.Field(Of Integer)(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString())
         .NombreGrupoCama = dr.Field(Of String)(Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(idGrupoCama As Integer) As Entidades.GrupoCama
      Return GetUno(idGrupoCama, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idGrupoCama As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.GrupoCama
      Return CargaEntidad(New SqlServer.GruposCamas(da).GruposCamas_G1(idGrupoCama),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.GrupoCama(),
                          accion, String.Format("No existe Grupo de Camas con ID {0}", idGrupoCama))
   End Function
   Public Function GetTodas() As List(Of Entidades.GrupoCama)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.GrupoCama())
   End Function

#End Region

End Class