Public Class Categorias
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("Categorias", accesoDatos)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Categoria)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Categoria)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Categoria)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Categorias(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Categorias(da).Categorias_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.Categoria, tipo As TipoSP)
      Dim sqlC = New SqlServer.Categorias(da)

      Dim idCuenta = If(en.Cuenta Is Nothing, 0L, en.Cuenta.IdCuenta)
      Dim idCuentaSecundaria = If(en.CuentaSecundaria Is Nothing, 0L, en.CuentaSecundaria.IdCuenta)

      Select Case tipo
         Case TipoSP._I
            sqlC.Categorias_I(en.IdCategoria, en.NombreCategoria, en.IdGrupoCategoria,
                              en.DescuentoRecargo, en.IdCaja, en.IdTipoComprobante, idCuenta,
                              en.IdInteres, idCuentaSecundaria, en.IdProducto, en.IdInteresCuotas,
                              en.RequiereRevisionAdministrativa, en.ControlaBackup, en.NivelAutorizacion,
                              en.ActualizarAplicacion, en.Comisiones, en.PerteneceAlComplejo,
                              en.FirmaMandato, en.AdquiereAcciones, en.PideConyuge, en.TPFisicaDatosAdicionales,
                              en.PideEmbarcacion, en.PagaAlquiler, en.PagaExpensas, en.ImporteGastosAdmin,
                              en.AdquiereCamas, en.IdCategoriaInversionista, en.LimiteMesesDeudaBotado, en.BackColor, en.ForeColor)

            ActualizarComisionesVarios(en)
         Case TipoSP._U
            sqlC.Categorias_U(en.IdCategoria, en.NombreCategoria, en.IdGrupoCategoria,
                              en.DescuentoRecargo, en.IdCaja, en.IdTipoComprobante, idCuenta,
                              en.IdInteres, idCuentaSecundaria, en.IdProducto, en.IdInteresCuotas,
                              en.RequiereRevisionAdministrativa, en.ControlaBackup, en.NivelAutorizacion,
                              en.ActualizarAplicacion, en.Comisiones, en.PerteneceAlComplejo,
                              en.FirmaMandato, en.AdquiereAcciones, en.PideConyuge, en.TPFisicaDatosAdicionales,
                              en.PideEmbarcacion, en.PagaAlquiler, en.PagaExpensas, en.ImporteGastosAdmin,
                              en.AdquiereCamas, en.IdCategoriaInversionista, en.LimiteMesesDeudaBotado, en.BackColor, en.ForeColor)

            ActualizarComisionesVarios(en)
         Case TipoSP._D
            BorrarComisionesVarios(en)
            sqlC.Categorias_D(en.IdCategoria)
      End Select
   End Sub

   Private Sub ActualizarComisionesVarios(categoria As Entidades.Categoria)
      Dim listado As DataSet = categoria.DescuentoRecargoPorc1

      If listado Is Nothing Then Exit Sub

      Dim sql1 As SqlServer.CategoriasDescuentosRubros = New SqlServer.CategoriasDescuentosRubros(da)
      Dim sql2 As SqlServer.CategoriasDescuentosSubRubros = New SqlServer.CategoriasDescuentosSubRubros(da)
      Dim sql3 As SqlServer.CategoriasDescuentosSubSubRubros = New SqlServer.CategoriasDescuentosSubSubRubros(da)


      For Each rd As DataTable In listado.Tables
         '**************************************Comisiones Rubros**********************************************************************
         If rd.TableName = Entidades.Categoria.DescuentosRubrosTableName Then
            If rd.GetChanges(DataRowState.Deleted) IsNot Nothing Then
               For Each dr As DataRow In rd.GetChanges(DataRowState.Deleted).Rows
                  sql1.CategoriasDescuentosRubros_D(categoria.IdCategoria, Int32.Parse(dr("IdRubro", DataRowVersion.Original).ToString()))
               Next
            End If

            For Each dr As DataRow In rd.Rows
               If dr.RowState = DataRowState.Added Then
                  sql1.CategoriasDescuentosRubros_I(categoria.IdCategoria, Int32.Parse(dr("IdRubro").ToString()), Decimal.Parse(dr("DescuentoRecargoPorc1").ToString()))
               End If

            Next
         End If
         '**************************************Comisiones SubRubros**********************************************************************
         If rd.TableName = Entidades.Categoria.DescuentosSubRubrosTableName Then
            If rd.GetChanges(DataRowState.Deleted) IsNot Nothing Then
               For Each dr As DataRow In rd.GetChanges(DataRowState.Deleted).Rows
                  sql2.CategoriasDescuentosSubRubros_D(categoria.IdCategoria, Int32.Parse(dr("IdSubRubro", DataRowVersion.Original).ToString()),
                                                        Int32.Parse(dr("IdRubro", DataRowVersion.Original).ToString()))
               Next
            End If

            For Each dr As DataRow In rd.Rows
               If dr.RowState = DataRowState.Added Then
                  sql2.CategoriasDescuentosSubRubros_I(categoria.IdCategoria, Int32.Parse(dr("IdSubRubro").ToString()),
                                                       Int32.Parse(dr("IdRubro").ToString()), Decimal.Parse(dr("DescuentoRecargoPorc1").ToString()))
               End If

            Next
         End If
         '**************************************Comisiones SubSubRubros**********************************************************************
         If rd.TableName = Entidades.Categoria.DescuentosSubSubRubrosTableName Then
            If rd.GetChanges(DataRowState.Deleted) IsNot Nothing Then
               For Each dr As DataRow In rd.GetChanges(DataRowState.Deleted).Rows
                  sql3.CategoriasDescuentosSubSubRubros_D(categoria.IdCategoria, Int32.Parse(dr("IdSubSubRubro", DataRowVersion.Original).ToString()),
                                                        Int32.Parse(dr("IdSubRubro", DataRowVersion.Original).ToString()),
                                                        Int32.Parse(dr("IdRubro", DataRowVersion.Original).ToString()))
               Next
            End If

            For Each dr As DataRow In rd.Rows
               If dr.RowState = DataRowState.Added Then
                  sql3.CategoriasDescuentosSubSubRubros_I(categoria.IdCategoria, Int32.Parse(dr("IdSubSubRubro").ToString()),
                                                          Int32.Parse(dr("IdSubRubro").ToString()), Int32.Parse(dr("IdRubro").ToString()),
                                                          Decimal.Parse(dr("DescuentoRecargoPorc1").ToString()))
               End If

            Next
         End If
      Next

   End Sub

   Private Sub CargaComisiones(categoria As Entidades.Categoria)
      If categoria.DescuentoRecargoPorc1.Tables.Contains(Entidades.Categoria.DescuentosRubrosTableName) Then
         categoria.DescuentoRecargoPorc1.Tables.Remove(Entidades.Categoria.DescuentosRubrosTableName)
      End If
      If categoria.DescuentoRecargoPorc1.Tables.Contains(Entidades.Categoria.DescuentosSubRubrosTableName) Then
         categoria.DescuentoRecargoPorc1.Tables.Remove(Entidades.Categoria.DescuentosSubRubrosTableName)
      End If
      If categoria.DescuentoRecargoPorc1.Tables.Contains(Entidades.Categoria.DescuentosSubSubRubrosTableName) Then
         categoria.DescuentoRecargoPorc1.Tables.Remove(Entidades.Categoria.DescuentosSubSubRubrosTableName)
      End If

      'Dim dt As DataTable

      categoria.DescuentoRecargoPorc1.Tables.Add(New SqlServer.CategoriasDescuentosRubros(da).GetAllCategoriasDescuentosRubros(categoria.IdCategoria))
      categoria.DescuentoRecargoPorc1.Tables.Add(New SqlServer.CategoriasDescuentosSubRubros(da).GetAllCategoriasDescuentosSubRubros(categoria.IdCategoria))
      categoria.DescuentoRecargoPorc1.Tables.Add(New SqlServer.CategoriasDescuentosSubSubRubros(da).GetAllCategoriasDescuentosSubSubRubros(categoria.IdCategoria))
   End Sub

   Public Sub BorrarComisionesVarios(categoria As Entidades.Categoria)
      Dim sql1 = New SqlServer.CategoriasDescuentosRubros(da)
      Dim sql2 = New SqlServer.CategoriasDescuentosSubRubros(da)
      Dim sql3 = New SqlServer.CategoriasDescuentosSubSubRubros(da)
      sql1.CategoriasDescuentosRubros_D(categoria.IdCategoria, 0)
      sql2.CategoriasDescuentosSubRubros_D(categoria.IdCategoria, 0, 0)
      sql3.CategoriasDescuentosSubSubRubros_D(categoria.IdCategoria, 0, 0, 0)
   End Sub

   Private Sub CargarUno(o As Entidades.Categoria, dr As DataRow)
      With o
         .IdCategoria = dr.Field(Of Integer)(Entidades.Categoria.Columnas.IdCategoria.ToString())
         .NombreCategoria = dr.Field(Of String)(Entidades.Categoria.Columnas.NombreCategoria.ToString())
         .IdGrupoCategoria = dr.Field(Of String)(Entidades.Categoria.Columnas.IdGrupoCategoria.ToString())
         .DescuentoRecargo = dr.Field(Of Decimal)(Entidades.Categoria.Columnas.DescuentoRecargo.ToString())
         .IdCaja = dr.Field(Of Integer?)(Entidades.Categoria.Columnas.IdCaja.ToString()).IfNull()
         .IdTipoComprobante = dr.Field(Of String)(Entidades.Categoria.Columnas.IdTipoComprobante.ToString()).IfNull()
         .Cuenta = New ContabilidadCuentas(da)._GetUna(dr.Field(Of Long?)(Entidades.Categoria.Columnas.IdCuenta.ToString()).IfNull(), AccionesSiNoExisteRegistro.Nulo)
         .CuentaSecundaria = New ContabilidadCuentas(da)._GetUna(dr.Field(Of Long?)(Entidades.Categoria.Columnas.IdCuentaSecundaria.ToString()).IfNull(), AccionesSiNoExisteRegistro.Nulo)
         .Interes = New Intereses().GetUno(dr.Field(Of Integer?)(Entidades.Categoria.Columnas.IdInteres.ToString()).IfNull(), AccionesSiNoExisteRegistro.Nulo)
         .InteresCuotas = New Intereses().GetUno(dr.Field(Of Integer?)(Entidades.Categoria.Columnas.IdInteresCuotas.ToString()).IfNull(), AccionesSiNoExisteRegistro.Nulo)
         .IdProducto = dr.Field(Of String)(Entidades.Categoria.Columnas.IdProducto.ToString()).IfNull()
         .NombreProducto = dr.Field(Of String)(Entidades.Categoria.Columnas.NombreProducto.ToString()).IfNull()
         .RequiereRevisionAdministrativa = dr.Field(Of Boolean)(Entidades.Categoria.Columnas.RequiereRevisionAdministrativa.ToString())
         .ControlaBackup = dr.Field(Of Boolean?)(Entidades.Categoria.Columnas.ControlaBackup.ToString()).IfNull()
         .NivelAutorizacion = dr.Field(Of Short?)(Entidades.Categoria.Columnas.NivelAutorizacion.ToString()).IfNull()
         .ActualizarAplicacion = dr.Field(Of Boolean?)(Entidades.Categoria.Columnas.ActualizarAplicacion.ToString()).IfNull()
         .Comisiones = dr.Field(Of Decimal)(Entidades.Categoria.Columnas.Comisiones.ToString())
         'Nuevos campos sisen
         .PerteneceAlComplejo = dr.Field(Of Boolean?)(Entidades.Categoria.Columnas.PerteneceAlComplejo.ToString()).IfNull()
         .FirmaMandato = dr.Field(Of Boolean?)(Entidades.Categoria.Columnas.FirmaMandato.ToString()).IfNull()
         .AdquiereAcciones = dr.Field(Of String)(Entidades.Categoria.Columnas.AdquiereAcciones.ToString()).IfNull()
         .AdquiereCamas = dr.Field(Of String)(Entidades.Categoria.Columnas.AdquiereCamas.ToString()).IfNull()
         .PideConyuge = dr.Field(Of Boolean?)(Entidades.Categoria.Columnas.PideConyuge.ToString()).IfNull()
         .PideEmbarcacion = dr.Field(Of String)(Entidades.Categoria.Columnas.PideEmbarcacion.ToString()).IfNull()
         .PagaAlquiler = dr.Field(Of Boolean?)(Entidades.Categoria.Columnas.PagaAlquiler.ToString()).IfNull()
         .PagaExpensas = dr.Field(Of Boolean?)(Entidades.Categoria.Columnas.PagaExpensas.ToString()).IfNull()
         .TPFisicaDatosAdicionales = dr.Field(Of Boolean?)(Entidades.Categoria.Columnas.TPFisicaDatosAdicionales.ToString()).IfNull()
         .ImporteGastosAdmin = dr.Field(Of Decimal?)(Entidades.Categoria.Columnas.ImporteGastosAdmin.ToString()).IfNull()
         .IdCategoriaInversionista = dr.Field(Of Integer?)(Entidades.Categoria.Columnas.IdCategoriaInversionista.ToString())
         .LimiteMesesDeudaBotado = dr.Field(Of Integer?)(Entidades.Categoria.Columnas.LimiteMesesDeudaBotado.ToString())
         .BackColor = dr.Field(Of Integer?)(Entidades.Categoria.Columnas.BackColor.ToString())
         .ForeColor = dr.Field(Of Integer?)(Entidades.Categoria.Columnas.ForeColor.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.Categoria)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.Categoria)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.Categoria)
      EjecutaSP(entidad, TipoSP._D)
   End Sub


   Public Function GetGrupoCategoria() As DataTable
      Return New SqlServer.Categorias(da).GetGrupoCategoria()
   End Function
   Public Function GetPorId(idCategoria As Integer) As DataTable
      Return New SqlServer.Categorias(da).Categorias_G1(idCategoria, ceroTodos:=True)
   End Function

   Public Function GetPorNombreLike(nombre As String) As DataTable
      Return New SqlServer.Categorias(da).Categorias_G_PorNombre(nombre, False)
   End Function

   Public Function GetUno(idCategoria As Integer) As Entidades.Categoria
      Return GetUno(idCategoria, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idCategoria As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Categoria
      Return CargaEntidad(New SqlServer.Categorias(da).Categorias_G1(idCategoria, ceroTodos:=False),
                          Sub(o, dr)
                             CargarUno(o, dr)
                             CargaComisiones(o)
                          End Sub, Function() New Entidades.Categoria(),
                          accion, Function() String.Format("No existe Categoría con Id: {0}", idCategoria))
   End Function

   Public Function GetTodas() As List(Of Entidades.Categoria)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Categoria())
   End Function

   Public Function GetIdMaximo() As Integer
      Return New SqlServer.Categorias(da).Categorias_GetIdMaximo()
   End Function

   Public Function GetPorNombreExacto(nombre As String) As DataTable
      Return New SqlServer.Categorias(da).Categorias_G_PorNombre(nombre, True)
   End Function

   Public Function CategoriasConInteres() As List(Of Entidades.Categoria)
      Return CargaLista(New SqlServer.Categorias(da).Categorias_ConInteres(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Categoria())
   End Function

   Public Function GetPrimerIdCategoria() As Integer
      Return New SqlServer.Categorias(da).Categorias_GetPrimerIdCategoria()
   End Function
#End Region

End Class