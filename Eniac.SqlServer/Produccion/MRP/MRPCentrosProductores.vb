Imports Eniac.Entidades

Public Class MRPCentrosProductores
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CentrosProductores_I(idCentroProductor As Integer,
                                   codigoCentroProductor As String,
                                   descripcion As String,
                                   idSeccion As Integer,
                                   claseCentroProductor As String,
                                   dotacion As Integer,
                                   horasLunes As Decimal,
                                   horasMartes As Decimal,
                                   horasMiercoles As Decimal,
                                   horasJueves As Decimal,
                                   horasViernes As Decimal,
                                   horasSabado As Decimal,
                                   horasDomingo As Decimal,
                                   tiempoPAP As Decimal,
                                   tiempoProductivo As Decimal,
                                   tiempoNoProductivo As Decimal,
                                   horasHombrePAP As Decimal,
                                   horasHombreProductivo As Decimal,
                                   horasHombreNoProductivo As Decimal,
                                   activo As Boolean,
                                   idProveedor As Long,
                                   IdNormaFab As Integer,
                                   mantenimientoAutonomo As Boolean,
                                   cantidadControles As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ( {1},  {2},  {3},  {4},  {5},  {6},  {7},  {8},  {9}, {10},
                                         {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20},
                                         {21}, {22}, {23}, {24})",
                                    MRPCentroProductor.NombreTabla,
                                    MRPCentroProductor.Columnas.IdCentroProductor.ToString(),
                                    MRPCentroProductor.Columnas.CodigoCentroProductor.ToString(),
                                    MRPCentroProductor.Columnas.Descripcion.ToString(),
                                    MRPCentroProductor.Columnas.IdSeccion.ToString(),
                                    MRPCentroProductor.Columnas.ClaseCentroProductor.ToString(),
                                    MRPCentroProductor.Columnas.Dotacion.ToString(),
                                    MRPCentroProductor.Columnas.HorasLunes.ToString(),
                                    MRPCentroProductor.Columnas.HorasMartes.ToString(),
                                    MRPCentroProductor.Columnas.HorasMiercoles.ToString(),
                                    MRPCentroProductor.Columnas.HorasJueves.ToString(),
                                    MRPCentroProductor.Columnas.HorasViernes.ToString(),
                                    MRPCentroProductor.Columnas.HorasSabado.ToString(),
                                    MRPCentroProductor.Columnas.HorasDomingo.ToString(),
                                    MRPCentroProductor.Columnas.TiempoPAP.ToString(),
                                    MRPCentroProductor.Columnas.TiempoProductivo.ToString(),
                                    MRPCentroProductor.Columnas.TiempoNoProductivo.ToString(),
                                    MRPCentroProductor.Columnas.HorasHombrePAP.ToString(),
                                    MRPCentroProductor.Columnas.HorasHombreProductivo.ToString(),
                                    MRPCentroProductor.Columnas.HorasHombreNoProductivo.ToString(),
                                    MRPCentroProductor.Columnas.Activo.ToString(),
                                    MRPCentroProductor.Columnas.IdProveedor.ToString(),
                                    MRPCentroProductor.Columnas.IdNormaFabricacion.ToString(),
                                    MRPCentroProductor.Columnas.MantenimientoAutonomo.ToString(),
                                    MRPCentroProductor.Columnas.CantidadControles.ToString()
                                    ).AppendLine()
         .AppendFormat("  VALUES ({0}, '{1}','{2}',  {3}, '{4}', {5},  {6},  {7},  {8},  {9}, 
                                 {10}, {11}, {12},  {13}, {14}, {15}, {16}, {17}, {18}, {19}, 
                                 {20}, {21}, {22}, {23}",
                                           idCentroProductor,
                                           codigoCentroProductor,
                                           descripcion,
                                           IIf(idSeccion = 0, "NULL", idSeccion),
                                           claseCentroProductor,
                                           dotacion,
                                           horasLunes,
                                           horasMartes,
                                           horasMiercoles,
                                           horasJueves,
                                           horasViernes,
                                           horasSabado,
                                           horasDomingo,
                                           tiempoPAP,
                                           tiempoProductivo,
                                           tiempoNoProductivo,
                                           horasHombrePAP,
                                           horasHombreProductivo,
                                           horasHombreNoProductivo,
                                           GetStringFromBoolean(activo),
                                           IIf(idProveedor = 0, "NULL", idProveedor),
                                           IIf(IdNormaFab = 0, "NULL", IdNormaFab),
                                           GetStringFromBoolean(mantenimientoAutonomo),
                                           cantidadControles)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CentrosProductores_U(idCentroProductor As Integer,
                                   codigoCentroProductor As String,
                                   descripcion As String,
                                   idSeccion As Integer,
                                   claseCentroProductor As String,
                                   dotacion As Integer,
                                   horasLunes As Decimal,
                                   horasMartes As Decimal,
                                   horasMiercoles As Decimal,
                                   horasJueves As Decimal,
                                   horasViernes As Decimal,
                                   horasSabado As Decimal,
                                   horasDomingo As Decimal,
                                   tiempoPAP As Decimal,
                                   tiempoProductivo As Decimal,
                                   tiempoNoProductivo As Decimal,
                                   horasHombrePAP As Decimal,
                                   horasHombreProductivo As Decimal,
                                   horasHombreNoProductivo As Decimal,
                                   activo As Boolean,
                                   idProveedor As Long,
                                   IdNormaFab As Integer,
                                   mantenimientoAutonomo As Boolean,
                                   cantidadControles As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", MRPCentroProductor.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}' ", MRPCentroProductor.Columnas.CodigoCentroProductor.ToString(), codigoCentroProductor).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", MRPCentroProductor.Columnas.Descripcion.ToString(), descripcion).AppendLine()
         If idSeccion > 0 Then
            .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.IdSeccion.ToString(), idSeccion).AppendLine()
         Else
            .AppendFormat("      ,{0} =  NULL ", MRPCentroProductor.Columnas.IdSeccion.ToString()).AppendLine()
         End If
         .AppendFormat("      ,{0} = '{1}' ", MRPCentroProductor.Columnas.ClaseCentroProductor.ToString(), claseCentroProductor).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.Dotacion.ToString(), dotacion).AppendLine()

         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.HorasLunes.ToString(), horasLunes).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.HorasMartes.ToString(), horasMartes).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.HorasMiercoles.ToString(), horasMiercoles).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.HorasJueves.ToString(), horasJueves).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.HorasViernes.ToString(), horasViernes).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.HorasSabado.ToString(), horasSabado).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.HorasDomingo.ToString(), horasDomingo).AppendLine()

         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.TiempoPAP.ToString(), tiempoPAP).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.TiempoProductivo.ToString(), tiempoProductivo).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.TiempoNoProductivo.ToString(), tiempoNoProductivo).AppendLine()

         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.HorasHombrePAP.ToString(), horasHombrePAP).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.HorasHombreProductivo.ToString(), horasHombreProductivo).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.HorasHombreNoProductivo.ToString(), horasHombreNoProductivo).AppendLine()

         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.Activo.ToString(), GetStringFromBoolean(activo)).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.MantenimientoAutonomo.ToString(), GetStringFromBoolean(mantenimientoAutonomo)).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.CantidadControles.ToString(), cantidadControles).AppendLine()

         If idProveedor > 0 Then
            .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.IdProveedor.ToString(), idProveedor).AppendLine()
         Else
            .AppendFormat("      ,{0} =  NULL ", MRPCentroProductor.Columnas.IdProveedor.ToString()).AppendLine()
         End If

         If IdNormaFab > 0 Then
            .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductor.Columnas.IdNormaFabricacion.ToString(), IdNormaFab).AppendLine()
         Else
            .AppendFormat("      ,{0} =  NULL ", MRPCentroProductor.Columnas.IdNormaFabricacion.ToString()).AppendLine()
         End If

         .AppendFormat(" WHERE {0} =  {1}  ", MRPCentroProductor.Columnas.IdCentroProductor.ToString(), idCentroProductor).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CentrosProductores_D(idCentroProductor As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.MRPCentroProductor.NombreTabla, Entidades.MRPCentroProductor.Columnas.IdCentroProductor.ToString(), idCentroProductor)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("Select CP.*, SC.Descripcion As DescripSeccion, PV.NombreProveedor, NF.Descripcion As DescripNorma FROM {0} AS CP", Entidades.MRPCentroProductor.NombreTabla).AppendLine()
         .AppendFormat("   LEFT JOIN {0} AS SC ON CP.IdSeccion = SC.IdSeccion ", Entidades.MRPSeccion.NombreTabla).AppendLine()
         .AppendFormat("   LEFT JOIN {0} AS PV ON CP.IdProveedor = PV.IdProveedor ", Entidades.Proveedor.NombreTabla).AppendLine()
         .AppendFormat("   LEFT JOIN {0} AS NF ON CP.IdNormaFabricacion = NF.IdNormaFab ", Entidades.MRPNormaFabricacion.NombreTabla).AppendLine()
      End With
   End Sub

   Private Function CentrosProductores_G(idCentroProd As Integer, codigoCentroProd As String, descripcion As String, valorExacto As Boolean, activos As Entidades.Publicos.SiNoTodos, internos As Entidades.Publicos.SiNoTodos) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCentroProd > 0 Then
            .AppendFormat("   And CP.IdCentroProductor = {0}", idCentroProd).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(codigoCentroProd) Then
            If valorExacto Then
               .AppendFormat("   And CP.CodigoCentroproductor = '{0}'", codigoCentroProd).AppendLine()
            Else
               .AppendFormat("   AND CP.CodigoCentroProductor LIKE '%{0}%'", codigoCentroProd).AppendLine()
            End If
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            If valorExacto Then
               .AppendFormat("   AND CP.Descripcion = '{0}'", descripcion).AppendLine()
            Else
               .AppendFormat("   AND CP.Descripcion LIKE '%{0}%'", descripcion).AppendLine()
            End If
         End If
         Select Case activos
            Case Entidades.Publicos.SiNoTodos.SI
               .AppendFormat(" AND CP.Activo = {0}", GetStringFromBoolean(True))
            Case Entidades.Publicos.SiNoTodos.NO
               .AppendFormat(" AND CP.Activo = {0}", GetStringFromBoolean(False))
         End Select
         Select Case internos
            Case Entidades.Publicos.SiNoTodos.SI
               .AppendFormat(" AND CP.ClaseCentroProductor = 'INT'")
            Case Entidades.Publicos.SiNoTodos.NO
               .AppendFormat(" AND CP.ClaseCentroProductor = 'EXT'")
         End Select

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


   Public Function CentrosProductores_G1(idCentroProductor As Integer) As DataTable
      Return CentrosProductores_G(idCentroProd:=idCentroProductor, codigoCentroProd:=String.Empty, descripcion:=String.Empty, valorExacto:=False, activos:=Publicos.SiNoTodos.TODOS, internos:=Publicos.SiNoTodos.TODOS)
   End Function
   Public Function CentrosProductores_G1_Nombre(nombreCentroProd As String, codigoExacto As Boolean, activos As Publicos.SiNoTodos, internos As Publicos.SiNoTodos) As DataTable
      Return CentrosProductores_G(idCentroProd:=0, codigoCentroProd:=String.Empty, descripcion:=nombreCentroProd, valorExacto:=codigoExacto, activos, internos)
   End Function

   Public Function CentrosProductores_G1_Codigo(codigoCentroProd As String, codigoExacto As Boolean, internos As Publicos.SiNoTodos) As DataTable
      Return CentrosProductores_G(idCentroProd:=0, codigoCentroProd:=codigoCentroProd, descripcion:=String.Empty, valorExacto:=codigoExacto, activos:=Publicos.SiNoTodos.TODOS, internos)
   End Function


   Public Function CentrosProductores_GA() As DataTable
      Return CentrosProductores_G(idCentroProd:=0, codigoCentroProd:=String.Empty, descripcion:=String.Empty, valorExacto:=False, activos:=Publicos.SiNoTodos.TODOS, internos:=Publicos.SiNoTodos.TODOS)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "CP.",
                    New Dictionary(Of String, String) From {{"DescripSeccion", "SC.Descripcion"},
                                                            {"NombreProveedor", "PV.NombreProveedor"},
                                                            {"DescripNorma", "NF.Descripcion"}})
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.MRPCentroProductor.Columnas.IdCentroProductor.ToString(), MRPCentroProductor.NombreTabla))
   End Function

   Public Function Existe(codigoCentroProd As String) As Boolean
      Dim stb = New StringBuilder("")
      With stb
         .AppendFormat("SELECT * FROM {0} AS CP", MRPCentroProductor.NombreTabla)
         .AppendFormat("   WHERE  CP.{0} = '{1}'", MRPCentroProductor.Columnas.CodigoCentroProductor.ToString(), codigoCentroProd)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Return dt.Rows.Count > 0
   End Function

End Class
