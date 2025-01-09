Public Class Embarcaciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Eniac.Datos.DataAccess())
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "Embarcaciones"
      da = accesoDatos
   End Sub

#End Region

   Public Function GetParaMovil() As DataTable
      If Not New Reglas.Generales().ExisteTabla("Embarcaciones") Then
         Return Nothing
      End If

      Return New SqlServer.Embarcaciones(da).GetParaMovil()

   End Function

   Public Function GetClientesParaMovil() As DataTable
      If Not New Reglas.Generales().ExisteTabla("EmbarcacionesClientes") Then
         Return Nothing
      End If

      Return New SqlServer.Embarcaciones(da).GetClientesParaMovil()
   End Function

   Public Function GetFiltradoPorNombre(ByVal nombre As String) As DataTable
      Return New SqlServer.Embarcaciones(Me.da).GetFiltradoPorNombre(nombre)
   End Function

   Public Function GetPorCodigoCliente(ByVal codigoCliente As Long, ByVal Situacion As String, activo As Boolean?) As DataTable
      Return EjecutaConConexion(Function() Me._GetPorCodigoCliente(codigoCliente, Situacion, activo))
   End Function

   Friend Function _GetPorCodigoCliente(ByVal codigoCliente As Long, ByVal Situacion As String, activo As Boolean?) As DataTable
      Dim sql = New SqlServer.Embarcaciones(Me.da)

      Return sql.GetPorCodigoCliente(codigoCliente, Situacion, activo)
   End Function

   Public Function GetPorCodigoEmbarcacion(codigoEmbarcacion As Long) As DataTable
      Return New SqlServer.Embarcaciones(da).GetFiltradoPorEmbarcacion(codigoEmbarcacion)
   End Function

   Public Function GetUnoLiviano(idEmbarcacion As Long) As Entidades.EmbarcacionLiviano
      Return CargaEntidad(New SqlServer.Embarcaciones(da).Embarcaciones_G1_Liviano(idEmbarcacion),
                          Sub(o, dr)
                             o.IdEmbarcacion = dr.Field(Of Long)("IdEmbarcacion")
                             o.CodigoEmbarcacion = dr.Field(Of Long)("CodigoEmbarcacion")
                             o.NombreEmbarcacion = dr.Field(Of String)("NombreEmbarcacion")
                          End Sub,
                          Function() New Entidades.EmbarcacionLiviano(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe embarcación con id {0}", idEmbarcacion))

   End Function

End Class