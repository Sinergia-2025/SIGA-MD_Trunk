Namespace ServiciosRest
   Public MustInherit Class BaseRest(Of T As Entidades.JSonEntidades.JSonEntidad)

      Protected MustOverride Function [Get](idEmpresa As Integer, dt As DataTable) As List(Of T)
      Protected MustOverride Sub CargarUno(o As T, dr As DataRow)

      Protected Delegate Sub CargarUnoDelegate(o As T, dr As DataRow)
      Protected Delegate Function NuevaInstanciaDelegate() As T

      Protected Function CargaLista(dt As DataTable,
                                    cargarUno As CargarUnoDelegate,
                                    nuevaInstancia As NuevaInstanciaDelegate) As List(Of T)
         Dim o As T
         Dim oLis As List(Of T) = New List(Of T)(Convert.ToInt32(dt.Rows.Count * 1.1))
         For Each dr As DataRow In dt.Rows
            o = nuevaInstancia()
            cargarUno(o, dr)
            oLis.Add(o)
         Next
         Return oLis
      End Function

   End Class

   Public MustInherit Class BaseRest(Of T As Entidades.JSonEntidades.JSonEntidad, E As Entidades.Entidad)

      Protected MustOverride Overloads Function [Get](idEmpresa As Integer, col As IEnumerable(Of E)) As List(Of T)
      Protected MustOverride Overloads Sub CargarUno(o As T, ent As E)

      Protected Delegate Sub CargarUnoDelegate(o As T, ent As E)
      Protected Delegate Function NuevaInstanciaDelegate() As T

      Protected Overloads Function CargaLista(col As IEnumerable(Of E),
                                    cargarUno As CargarUnoDelegate,
                                    nuevaInstancia As NuevaInstanciaDelegate) As List(Of T)
         Dim o As T
         Dim oLis As List(Of T) = New List(Of T)(Convert.ToInt32(col.Count * 1.1))
         For Each ent As E In col
            o = nuevaInstancia()
            cargarUno(o, ent)
            oLis.Add(o)
         Next
         Return oLis
      End Function

   End Class
End Namespace