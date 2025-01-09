Public Class ClientesDescuentosSubRubros
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.ClienteDescuentoSubRubro.NombreTabla, accesoDatos)
   End Sub
#End Region

   Public Sub GrabarClientesDescuentosSubRubros(idCliente As Long, listado As DataTable)
      EjecutaConTransaccion(Sub() _GrabarClientesDescuentosSubRubros(idCliente, listado))
   End Sub
   Public Sub _GrabarClientesDescuentosSubRubros(idCliente As Long, dt As DataTable)
      Dim sql = New SqlServer.ClientesDescuentosSubRubros(da)
      sql.ClientesDescuentosSubRubros_D(idCliente, idSubRubro:=0)
      dt.AsEnumerable().ToList().ForEach(
      Sub(dr)
         sql.ClientesDescuentosSubRubros_I(idCliente, dr.Field(Of Integer)("IdSubRubro"), dr.Field(Of Decimal)("DescuentoRecargo"))
      End Sub)
   End Sub
   Public Function GetClientesDescuentosSubRubros(idCliente As Long) As DataTable
      Return EjecutaConConexion(Function() _GetClientesDescuentosSubRubros(idCliente))
   End Function
   Public Function _GetClientesDescuentosSubRubros(idCliente As Long) As DataTable
      Return New SqlServer.ClientesDescuentosSubRubros(da).GetClientesDescuentosSubRubros(idCliente)
   End Function
   Private Sub CargarUno(o As Entidades.ClienteDescuentoSubRubro, dr As DataRow)
      With o
         .IdCliente = dr.Field(Of Long)(Entidades.ClienteDescuentoSubRubro.Columnas.IdCliente.ToString())
         .IdSubRubro = dr.Field(Of Integer)(Entidades.ClienteDescuentoSubRubro.Columnas.IdSubRubro.ToString())
         .DescuentoRecargo = dr.Field(Of Decimal)(Entidades.ClienteDescuentoSubRubro.Columnas.DescuentoRecargo.ToString())
      End With
   End Sub
   Public Function GetTodos(idCliente As Long) As List(Of Entidades.ClienteDescuentoSubRubro)
      Return CargaLista(New SqlServer.ClientesDescuentosSubRubros(da).GetClientesDescuentosSubRubros(idCliente),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ClienteDescuentoSubRubro())
   End Function

   Public Function GetUno(idCliente As Long, idSubRubro As Integer) As Entidades.SubRubro
      Dim sql = New SqlServer.ClientesDescuentosSubRubros(da)
      Dim dt = sql.Get1(idCliente, idSubRubro)
      Dim o = New Entidades.SubRubro()
      If dt.Rows.Count > 0 Then
         Dim dr = dt.First()
         With o
            .IdRubro = Integer.Parse(dr("IdRubro").ToString())
            .IdSubRubro = Integer.Parse(dr("IdSubRubro").ToString())
            .NombreSubRubro = dr("NombreSubRubro").ToString()
            .DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargo").ToString())
         End With
      Else
         With o
            .IdRubro = 0
            .IdSubRubro = 0
            .NombreSubRubro = ""
            .DescuentoRecargoPorc1 = 0
         End With
      End If
      Return o
   End Function
End Class