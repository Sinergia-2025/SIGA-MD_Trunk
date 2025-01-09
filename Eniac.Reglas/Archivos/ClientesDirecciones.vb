Public Class ClientesDirecciones
   Inherits Base

   Private Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

#Region "Constructores"

   Public Sub New()
      Me.New(Entidades.Cliente.ModoClienteProspecto.Cliente)
   End Sub
   Public Sub New(modo As Entidades.Cliente.ModoClienteProspecto)
      ModoClienteProspecto = modo
      NombreEntidad = modo.ToString() + "sDirecciones"
      da = New Datos.DataAccess()
   End Sub

#End Region

   Public Function GetClientesDirecciones(idCliente As Long) As DataTable
      Dim sql = New SqlServer.ClientesDirecciones(da, ModoClienteProspecto)
      Return sql.GetClientesDirecciones(idCliente, idDireccion:=0)
   End Function
   Public Function GetDireccionCliente(idCliente As Long, idDireccion As Integer) As DataTable
      Dim sql = New SqlServer.ClientesDirecciones(da, ModoClienteProspecto)
      Return sql.GetClientesDirecciones(idCliente, idDireccion)
   End Function
   Public Function GetDirecciones(idCliente As Long) As DataTable
      Dim sql = New SqlServer.ClientesDirecciones(da, ModoClienteProspecto)
      Dim buscaDireccion2 = New Funciones(da).ExisteFuncionPorPantalla("ClientesLIVEABM") Or Publicos.ExtrasSinergia
      Return sql.GetDirecciones(idCliente, buscaDireccion2)
   End Function

   Public Sub PuedoBorrarDireccion(idCliente As Long, idDireccion As Integer)
      EjecutaConConexion(
         Sub()
            Dim dr As DataRow
            dr = da.GetDataTable(String.Format("SELECT IdTipoNovedad FROM CRMNovedades WHERE Id{2} = {0} AND IdDomicilioRetiro = {1}",
                                               idCliente, idDireccion, ModoClienteProspecto.ToString())).
                    AsEnumerable().FirstOrDefault()
            If dr IsNot Nothing Then
               Throw New Exception(String.Format("La dirección que desea eliminar fue utilizada como Domicilio de Retiro en {0}", dr.Field(Of String)("IdTipoNovedad")))
            End If
            dr = da.GetDataTable(String.Format("SELECT IdTipoNovedad FROM CRMNovedades WHERE Id{2} = {0} AND IdDomicilioEntrega = {1}",
                                               idCliente, idDireccion, ModoClienteProspecto.ToString())).
                    AsEnumerable().FirstOrDefault()
            If dr IsNot Nothing Then
               Throw New Exception(String.Format("La dirección que desea eliminar fue utilizada como Domicilio de Entrega en {0}", dr.Field(Of String)("IdTipoNovedad")))
            End If
         End Sub)
   End Sub

End Class