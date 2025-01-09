Imports System.Reflection
Imports System.ComponentModel
Imports Microsoft.Win32
Partial Public Class Publicos

#Region "Enumeradores"

   Public Enum TipoEmpleado
      COMPRADOR
      VENDEDOR
   End Enum

#End Region


#Region "CargaCombos"
   Public Sub OcultaColumnas(uGrilla As UltraGrid)
      Dim pos As Integer = 0
      With uGrilla.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next
      End With
   End Sub
   '-- REQ-32944.- ----------------------------------------------------------------------
   Public Sub CargaComboTiposDashBoard(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.DashBoardTipo.Columnas.Descripcion.ToString()
         .ValueMember = Entidades.DashBoardTipo.Columnas.IdDashTipos.ToString()
         .DataSource = New Reglas.DashBordsTipos().GetAll()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboModelosDashBoard(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.DashBoardModelo.Columnas.Descripcion.ToString()
         .ValueMember = Entidades.DashBoardModelo.Columnas.IdModelo.ToString()
         .DataSource = New Reglas.DashBordsModelos().GetAll()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboRefreshDashBoard(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.DashBoardRefresh.Columnas.Descripcion.ToString()
         .ValueMember = Entidades.DashBoardRefresh.Columnas.IdDashRefresh.ToString()
         .DataSource = New Reglas.DashBoardsRefresh().GetAll()
         .SelectedIndex = -1
      End With
   End Sub
   '--------------------------------------------------------------------------------------
   Public Sub CargaComboProyectosEstados(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.ProyectoEstado.Columnas.NombreEstado.ToString()
         .ValueMember = Entidades.ProyectoEstado.Columnas.IdEstado.ToString()
         .DataSource = New Reglas.ProyectosEstados().GetAll()
         '.SelectedIndex = 0
      End With
   End Sub

   Public Sub CargaComboClasificaciones(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.Clasificacion.Columnas.NombreClasificacion.ToString()
         .ValueMember = Entidades.Clasificacion.Columnas.IdClasificacion.ToString()
         .DataSource = New Reglas.Clasificaciones().GetAll()
         '.SelectedIndex = 0
      End With
   End Sub

   Public Sub CargaComboEstadoUbicaciones(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreEstado"
         .ValueMember = "IdEstado"
         .DataSource = New Reglas.SucursalesUbicacionesEstados().GetAll()
      End With
   End Sub

   Public Sub CargaComboUbicaciones(combo As Controles.ComboBox, idDeposito As Integer, idSucursal As Integer)
      With combo
         .DisplayMember = "NombreUbicacion"
         .ValueMember = "IdUbicacion"
         .DataSource = New Reglas.SucursalesUbicaciones().GetSucursalDeposito(idDeposito, idSucursal)
      End With
   End Sub
   <Obsolete("Usar CargaComboUbicaciones")>
   Public Sub CargaComboUbicacionesMultiples(combo As Controles.ComboBox, sucursales As Entidades.Sucursal(), depositos As Entidades.SucursalDeposito())
      With combo
         .DisplayMember = "NombreUbicacion"
         .ValueMember = "IdUbicacion"
         .DataSource = New Reglas.SucursalesUbicaciones().GetSucursalDepositoMultiples(sucursales, depositos)
      End With
   End Sub
   Public Sub CargaComboUbicaciones(combo As Controles.ComboBox, sucursales As Entidades.Sucursal(), depositos As Entidades.SucursalDeposito())
      With combo
         .DisplayMember = "NombreUbicacion"
         .ValueMember = "IdUbicacion"
         .DataSource = New Reglas.SucursalesUbicaciones().GetTodosSucursalDeposito(sucursales, depositos)
      End With
   End Sub

   Public Sub CargaComboUbicaciones(combo As Infragistics.Win.UltraWinEditors.UltraComboEditor, idDeposito As Integer, idSucursal As Integer)
      With combo
         .DisplayMember = "NombreUbicacion"
         .ValueMember = "IdUbicacion"
         .DataSource = New Reglas.SucursalesUbicaciones().GetSucursalDeposito(idDeposito, idSucursal)
      End With
   End Sub

   Public Sub CargaComboUbicacionesProductos(combo As Controles.ComboBox, idDeposito As Integer, idSucursal As Integer, idUbicacion As Integer, idProducto As String)
      With combo
         .DisplayMember = "NombreUbicacion"
         .ValueMember = "IdUbicacion"
         .DataSource = New Reglas.ProductosUbicaciones().GetSucursalDepositoProducto(idSucursal, idDeposito, idUbicacion, idProducto)
      End With
   End Sub

   'Public Sub CargaComboDepositos(combo As Controles.ComboBox, idSucursal As Integer, miraUsuario As Boolean, PermiteEscritura As Boolean, disponibleventa As Boolean,
   '                               Optional tipos As IEnumerable(Of Entidades.SucursalDeposito.TiposDepositos) = Nothing)
   '   CargaComboDepositos(combo, idSucursal, miraUsuario, PermiteEscritura, disponibleventa, Entidades.Publicos.SiNoTodos.TODOS, tipos)
   'End Sub

   Public Sub CargaComboDepositos(combo As Controles.ComboBox, idSucursal As Integer, miraUsuario As Boolean, permiteEscritura As Boolean,
                                  Optional activos As Entidades.Publicos.SiNoTodos = Entidades.Publicos.SiNoTodos.TODOS,
                                  Optional disponibleventa As Boolean = False,
                                  Optional tipos As IEnumerable(Of Entidades.SucursalDeposito.TiposDepositos) = Nothing)
      _CargaComboDepositos(combo, idSucursal, miraUsuario, permiteEscritura, disponibleventa, activos, tipos)
   End Sub

   Private Sub _CargaComboDepositos(combo As Controles.ComboBox, idSucursal As Integer, miraUsuario As Boolean, PermiteEscritura As Boolean, disponibleVenta As Boolean, activos As Entidades.Publicos.SiNoTodos,
                                    tipos As IEnumerable(Of Entidades.SucursalDeposito.TiposDepositos))
      With combo
         .DisplayMember = "NombreDeposito"
         .ValueMember = "IdDeposito"
         .DataSource = New Reglas.SucursalesDepositos().GetSucursalesDepositos(idSucursal, If(miraUsuario, actual.Nombre, String.Empty), PermiteEscritura, disponibleVenta, activos, tipos)
      End With
   End Sub

   Public Sub CargaComboDepositos(combo As Controles.ComboBox,
                                  seleccionMultiple As Boolean, seleccionTodos As Boolean,
                                  sucursales As Entidades.Sucursal())
      With combo
         .DisplayMember = Entidades.SucursalDeposito.Columnas.NombreDeposito.ToString()
         .ValueMember = Entidades.SucursalDeposito.Columnas.IdDeposito.ToString()
         Dim lst = New Reglas.SucursalesDepositos().GetTodos(sucursales)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim eDepo = New Entidades.SucursalDeposito()
            eDepo.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            eDepo.IdDeposito = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            eDepo.NombreDeposito = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, eDepo)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim eDepo = New Entidades.SucursalDeposito()
            eDepo.IdDeposito = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            eDepo.NombreDeposito = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, eDepo)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboMRPCategoriasEmpleados(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "IdCategoriaEmpleado"
         .DataSource = New Reglas.MRPCategoriasEmpleados()._GetAll(Entidades.Publicos.SiNoTodos.SI)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboSucursales(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "Nombre"
         .ValueMember = "IdSucursal"
         .DataSource = New Reglas.Sucursales().GetAll()
         .SelectedIndex = 0
      End With
   End Sub
   Public Sub CargaComboSucursales(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String)
      CargaComboSucursales(combo, idEmpresa:=Nothing, seleccionMultiple, seleccionTodos, idFuncion)
   End Sub
   Public Sub CargaComboSucursales(combo As Controles.ComboBox, idEmpresa As Integer?, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String)
      With combo
         .DisplayMember = "Nombre"
         .ValueMember = "IdSucursal"
         Dim lst As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetTodas(idFuncion, idEmpresa, False)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim suc As Entidades.Sucursal = New Entidades.Sucursal()
            suc.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            suc.Id = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            suc.Nombre = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, suc)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim suc As Entidades.Sucursal = New Entidades.Sucursal()
            suc.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            suc.Id = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            suc.Nombre = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, suc)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
         '.SelectedValue = Entidades.Usuario.Actual.Sucursal.IdSucursal
      End With
   End Sub

   Public Sub CargaComboEmpresas(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.Empresa.Columnas.NombreEmpresa.ToString()
         .ValueMember = Entidades.Empresa.Columnas.IdEmpresa.ToString()
         .DataSource = New Reglas.Empresas().GetAll()
         .SelectedIndex = 0
      End With
   End Sub


   Public Sub CargaComboEmpresas(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String)
      With combo
         .DisplayMember = Entidades.Empresa.Columnas.NombreEmpresa.ToString()
         .ValueMember = Entidades.Empresa.Columnas.IdEmpresa.ToString()
         Dim lst = New Reglas.Empresas().GetTodos(idFuncion)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim suc = New Entidades.Empresa()
            suc.IdEmpresa = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            suc.NombreEmpresa = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, suc)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim suc = New Entidades.Empresa()
            suc.IdEmpresa = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            suc.NombreEmpresa = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, suc)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboContabilidadPlan(combo As Controles.ComboBox)
      CargaComboContabilidadPlan(combo, False)
   End Sub
   Public Sub CargaComboContabilidadPlan(combo As Controles.ComboBox, todos As Boolean)
      With combo
         .DisplayMember = Entidades.ContabilidadPlan.Columnas.NombrePlanCuenta.ToString()
         .ValueMember = Entidades.ContabilidadPlan.Columnas.IdPlanCuenta.ToString()
         .DataSource = New Reglas.ContabilidadPlanes().GetAll(todos)
         '.SelectedIndex = 0
      End With
   End Sub

   Public Sub CargaComboContabilidadEjercicio(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.ContabilidadEjercicio.ReadOnlyColumnas.DescripcionEjercicio.ToString()
         .ValueMember = Entidades.ContabilidadEjercicio.Columnas.IdEjercicio.ToString()
         .DataSource = New Reglas.ContabilidadEjercicios().GetTodos()
         '.SelectedIndex = 0
      End With
   End Sub


   Public Sub CargaComboPlazosEntrega(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.PlazoEntrega.Columnas.DescripcionPlazoEntrega.ToString()
         .ValueMember = Entidades.PlazoEntrega.Columnas.IdPlazoEntrega.ToString()
         .DataSource = New Reglas.PlazosEntregas().GetTodos()
         .SelectedIndex = 0
      End With
   End Sub

   Public Sub CargaComboCajas(combo As Controles.ComboBox, idSucursal As Integer,
                              miraUsuario As Boolean, miraPC As Boolean, cajasModificables As Boolean)

      Dim priorizaNombrePC = False
      Dim asignaCajaUsuario = False

      With combo
         .DisplayMember = "NombreCaja"
         .ValueMember = "IdCaja"
         .DataSource = New Reglas.CajasUsuarios().GetCajas(idSucursal, If(miraUsuario, actual.Nombre, String.Empty),
                                                           If(miraPC, My.Computer.Name, String.Empty), cajasModificables)
         'En caso de no tener registros, es porque puede no coincidir exacto con la PC, entonces traigo todas las asignadas.
         If .Items.Count = 0 Then
            .DataSource = New Reglas.CajasUsuarios().GetCajas(idSucursal, If(miraUsuario, actual.Nombre, String.Empty),
                                                              String.Empty, cajasModificables)
         ElseIf miraPC Then
            priorizaNombrePC = True
         End If

         If .Items.Count = 0 Then
            Throw New Exception("ATENCION: El Usuario NO tiene Caja Asociada y NO podrá continuar." & vbCrLf & vbCrLf & "Por favor contáctese con Sistemas.")
         End If

         If Not priorizaNombrePC Then
            'Si el IdUsuario existe en alguna de las Cajas, se posiciona el combo en dicha Caja
            Dim i As Integer
            For i = 0 To .Items.Count - 1
               If DirectCast(combo.Items(i), DataRowView).Row.Item("IdUsuario").ToString().ToLower() = actual.Nombre.ToLower() Then
                  .SelectedIndex = i
                  asignaCajaUsuario = True
                  Exit For
               End If
            Next

         End If

         If Not asignaCajaUsuario Then
            .SelectedIndex = 0
         End If
      End With

   End Sub

   Public Sub CargaComboCajas(combo As Controles.ComboBox,
                              sucursales As Entidades.Sucursal(),
                              MiraUsuario As Boolean,
                              MiraPC As Boolean,
                              CajasModificables As Boolean)

      Dim priorizaNombrePC As Boolean = False
      Dim asignaCajaUsuario As Boolean = False

      Dim dt As DataTable
      With combo
         .DisplayMember = "NombreCaja"
         .ValueMember = "IdCaja"
         dt = New Reglas.CajasUsuarios().GetCajas(sucursales,
                                                           IIf(MiraUsuario, Eniac.Entidades.Usuario.Actual.Nombre, "").ToString(),
                                                           IIf(MiraPC, My.Computer.Name, "").ToString(), CajasModificables)
         'En caso de no tener registros, es porque puede no coincidir exacto con la PC, entonces traigo todas las asignadas.
         If .Items.Count = 0 Then
            dt = New Reglas.CajasUsuarios().GetCajas(sucursales,
                                                              IIf(MiraUsuario, Eniac.Entidades.Usuario.Actual.Nombre, "").ToString(),
                                                              "", CajasModificables)
         ElseIf MiraPC Then
            priorizaNombrePC = True
         End If

         For Each dr As DataRow In dt.Rows
            dr("NombreCaja") = String.Format("{0} (Suc: {1})", dr("NombreCaja"), dr("IdSucursal"))
         Next

         .DataSource = dt

         If .Items.Count = 0 Then
            Throw New Exception("ATENCION: El Usuario NO tiene Caja Asociada y NO podrá continuar." & vbCrLf & vbCrLf & "Por favor contáctese con Sistemas.")
         End If

         If Not priorizaNombrePC Then
            'Si el IdUsuario existe en alguna de las Cajas, se posiciona el combo en dicha Caja
            Dim i As Integer
            For i = 0 To .Items.Count - 1
               If DirectCast(combo.Items(i), System.Data.DataRowView).Row.Item("IdUsuario").ToString().ToLower() = Eniac.Entidades.Usuario.Actual.Nombre.ToLower() Then
                  .SelectedIndex = i
                  asignaCajaUsuario = True
                  Exit For
               End If
            Next

         End If

         If Not asignaCajaUsuario Then
            .SelectedIndex = 0
         End If
      End With

   End Sub

   Public Sub CargaComboCajas(combo As Controles.ComboBox,
                           sucursales As Entidades.Sucursal(),
                           MiraUsuario As Boolean,
                           MiraPC As Boolean,
                           CajasModificables As Boolean,
                           seleccionMultiple As Boolean, seleccionTodos As Boolean)

      Dim priorizaNombrePC As Boolean = False
      Dim asignaCajaUsuario As Boolean = False

      Dim lst As List(Of Entidades.CajaNombre)
      With combo
         .DisplayMember = "NombreCaja"
         .ValueMember = "IdCaja"
         lst = New Reglas.CajasUsuarios().GetCajasTodas(sucursales,
                                                           IIf(MiraUsuario, Eniac.Entidades.Usuario.Actual.Nombre, "").ToString(),
                                                           IIf(MiraPC, My.Computer.Name, "").ToString(), CajasModificables)
         ''En caso de no tener registros, es porque puede no coincidir exacto con la PC, entonces traigo todas las asignadas.
         'If .Items.Count = 0 Then
         '   lis = New Reglas.CajasUsuarios().GetCajasTodas(sucursales,
         '                                                     IIf(MiraUsuario, Eniac.Entidades.Usuario.Actual.Nombre, "").ToString(), _
         '                                                     "", CajasModificables)
         'ElseIf MiraPC Then
         '   priorizaNombrePC = True
         'End If

         For Each cn As Entidades.CajaNombre In lst
            cn.NombreCaja = String.Format("{0} (Suc: {1})", cn.NombreCaja, cn.IdSucursal)
         Next

         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.CajaNombre = New Entidades.CajaNombre()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdCaja = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreCaja = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.CajaNombre = New Entidades.CajaNombre()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.IdCaja = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreCaja = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If


         .DataSource = lst

         If .Items.Count = 0 Then
            Throw New Exception("ATENCION: El Usuario NO tiene Caja Asociada y NO podrá continuar." & vbCrLf & vbCrLf & "Por favor contáctese con Sistemas.")
         End If

         'If Not priorizaNombrePC Then
         '   'Si el IdUsuario existe en alguna de las Cajas, se posiciona el combo en dicha Caja
         '   Dim i As Integer
         '   For i = 0 To .Items.Count - 1
         '      If DirectCast(combo.Items(i), System.Data.DataRowView).Row.Item("IdUsuario").ToString().ToLower() = Eniac.Entidades.Usuario.Actual.Nombre.ToLower() Then
         '         .SelectedIndex = i
         '         asignaCajaUsuario = True
         '         Exit For
         '      End If
         '   Next

         'End If

         If Not asignaCajaUsuario Then
            .SelectedIndex = 0
         End If
      End With

   End Sub


   Public Sub CargaComboCriticidades(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "IdCriticidad"
         .ValueMember = "IdCriticidad"
         .DataSource = New Reglas.PedidosCriticidades().GetTodosPorOrden()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboCriticidades(combo As UltraWinEditors.UltraComboEditor)
      With combo
         .DisplayMember = "IdCriticidad"
         .ValueMember = "IdCriticidad"
         .DataSource = New Reglas.PedidosCriticidades().GetTodos().OrderBy(Function(c) c.Orden).ToList()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCriticidadesOP(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "IdCriticidad"
         .ValueMember = "IdCriticidad"
         .DataSource = New Reglas.CriticidadesOrdenesProduccion().GetTodosPorOrden()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboLocalidades(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreLocalidad"
         .ValueMember = "IdLocalidad"
         .DataSource = New Reglas.Localidades().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTipoUsuarios(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreTipoUsuario"
         .ValueMember = "IdTipoUsuario"
         .DataSource = New Reglas.TiposUsuarios().GetAll()
         .SelectedIndex = -1
      End With
   End Sub


   Public Sub CargaComboCategorias(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreCategoria"
         .ValueMember = "IdCategoria"
         .DataSource = New Reglas.Categorias().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   'Nuevos PE-31183
   Public Sub CargaComboPideEmbarcacion(combo As Controles.ComboBox)

      With combo
         .DisplayMember = "NombrePideEmbarcacion"
         .ValueMember = "PideEmbarcacion"

         Dim dt As New DataTable
         dt.Columns.Add("PideEmbarcacion")
         dt.Columns.Add("NombrePideEmbarcacion")

         Dim dr As DataRow = dt.NewRow
         dr(0) = "S"
         dr(1) = "SI"
         dt.Rows.Add(dr)

         dr = dt.NewRow
         dr(0) = "N"
         dr(1) = "NO"
         dt.Rows.Add(dr)

         dr = dt.NewRow
         dr(0) = "O"
         dr(1) = "Opcional"
         dt.Rows.Add(dr)

         .DataSource = dt
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboAdquiereCamas(combo As Controles.ComboBox)

      With combo
         .DisplayMember = "NombreAdquiereCama"
         .ValueMember = "AdquiereCama"

         Dim dt As New DataTable
         dt.Columns.Add("AdquiereCama")
         dt.Columns.Add("NombreAdquiereCama")

         Dim dr As DataRow = dt.NewRow
         dr(0) = "S"
         dr(1) = "SI"
         dt.Rows.Add(dr)

         dr = dt.NewRow
         dr(0) = "N"
         dr(1) = "NO"
         dt.Rows.Add(dr)

         dr = dt.NewRow
         dr(0) = "O"
         dr(1) = "Opcional"
         dt.Rows.Add(dr)

         .DataSource = dt
         .SelectedIndex = -1
      End With

   End Sub

   Public Sub CargaComboAdquiereAcciones(combo As Controles.ComboBox)

      With combo
         .DisplayMember = "NombreAdquiereAccion"
         .ValueMember = "AdquiereAccion"

         Dim dt As New DataTable
         dt.Columns.Add("AdquiereAccion")
         dt.Columns.Add("NombreAdquiereAccion")

         Dim dr As DataRow = dt.NewRow
         dr(0) = "S"
         dr(1) = "SI"
         dt.Rows.Add(dr)

         dr = dt.NewRow
         dr(0) = "N"
         dr(1) = "NO"
         dt.Rows.Add(dr)

         dr = dt.NewRow
         dr(0) = "O"
         dr(1) = "Opcional"
         dt.Rows.Add(dr)

         .DataSource = dt
         .SelectedIndex = -1
      End With

   End Sub
   '----------------------------------------------------------


   Public Sub CargaComboTiposImpresionesFiscales(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString()
         .ValueMember = Entidades.TipoImpresionFiscal.Columnas.IdTipoImpresionFiscal.ToString()
         .DataSource = New Reglas.TiposImpresionesFiscales().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCategorias(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean)
      With combo
         .DisplayMember = "NombreCategoria"
         .ValueMember = "IdCategoria"
         Dim lst As List(Of Entidades.Categoria) = New Reglas.Categorias().GetTodas()
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.Categoria = New Entidades.Categoria()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdCategoria = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreCategoria = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.Categoria = New Entidades.Categoria()
            categ.IdCategoria = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreCategoria = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
         '.SelectedValue = Entidades.Usuario.Actual.Sucursal.IdSucursal
      End With
   End Sub


   Public Sub CargaComboClientesContactos(combo As Controles.ComboBox, idCliente As Long, activo As Boolean?)
      With combo
         .DisplayMember = Entidades.ClienteContacto.Columnas.NombreContacto.ToString()
         .ValueMember = Entidades.ClienteContacto.Columnas.IdContacto.ToString()
         .DataSource = New Reglas.ClientesContactos().GetTodos(idCliente, activo)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCategoriasProveedores(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreCategoria"
         .ValueMember = "IdCategoria"
         .DataSource = New Reglas.CategoriasProveedores().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCuentasBancarias(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreCuenta"
         .ValueMember = "IdCuentaBancaria"
         .DataSource = New Reglas.CuentasBancarias().GetTodas()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboCategoriasFiscales(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreCategoriaFiscal"
         .ValueMember = "IdCategoriaFiscal"
         .DataSource = New Reglas.CategoriasFiscales().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCategoriasFiscales(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean)
      With combo
         .DisplayMember = "NombreCategoriaFiscal"
         .ValueMember = "IdCategoriaFiscal"
         Dim lst As List(Of Entidades.CategoriaFiscal) = New Reglas.CategoriasFiscales().GetTodos()
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdCategoriaFiscal = Short.Parse(Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.Todos).ToString())
            categ.NombreCategoriaFiscal = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
            categ.IdCategoriaFiscal = Short.Parse(Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple).ToString())
            categ.NombreCategoriaFiscal = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
         '.SelectedValue = Entidades.Usuario.Actual.Sucursal.IdSucursal
      End With
   End Sub

   'Public Sub CargaComboCategFiscales(combo As Controles.ComboBox)
   '   With combo
   '      .DisplayMember = "NombreCategoriaFiscal"
   '      .ValueMember = "IdCategoriaFiscal"
   '      .DataSource = New Reglas.CategoriasFiscales().GetAll()
   '      .SelectedIndex = -1
   '   End With
   'End Sub
   Public Sub CargaComboTiposContactos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreTipoContacto"
         .ValueMember = "IdTipoContacto"
         .DataSource = New Reglas.TiposContactos().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposObservaciones(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.TipoObservacion.Columnas.Descripcion.ToString()
         .ValueMember = Entidades.TipoObservacion.Columnas.IdObservaciones.ToString()
         .DataSource = New Reglas.TiposObservaciones().GetTodos()
         .SelectedIndex = 0
      End With
   End Sub

   Public Sub CargaComboEstadoVisita(combo As Controles.ComboBox, admitePedidoSinLineas As Boolean?, admintePedidoConLineas As Boolean?)
      With combo
         .DisplayMember = Entidades.EstadoVisita.Columnas.NombreEstadoVisita.ToString()
         .ValueMember = Entidades.EstadoVisita.Columnas.IdEstadoVisita.ToString()
         .DataSource = New Reglas.EstadosVisitas().GetTodos(admitePedidoSinLineas, admintePedidoConLineas)
         If .Items.Count = 1 Then
            .SelectedIndex = 0
         Else
            .SelectedIndex = -1
         End If
      End With
   End Sub

   Public Sub CargaComboEstadosClientes(combo As Controles.ComboBox)
      Dim o As Reglas.EstadosClientes = New Reglas.EstadosClientes()
      With combo
         .DisplayMember = Entidades.EstadoCliente.Columnas.NombreEstadoCliente.ToString()
         .ValueMember = Entidades.EstadoCliente.Columnas.IdEstadoCliente.ToString()
         .DataSource = o.GetTodos()
      End With
   End Sub

   Public Sub CargaComboEstadosTurismo(combo As Controles.ComboBox)
      Dim o As Reglas.EstadosTurismo = New Reglas.EstadosTurismo()
      With combo
         .DisplayMember = Entidades.EstadoTurismo.Columnas.NombreEstadoTurismo.ToString()
         .ValueMember = Entidades.EstadoTurismo.Columnas.IdEstadoTurismo.ToString()
         .DataSource = o.GetTodos()
      End With
   End Sub

   Public Sub CargaComboTiposVehiculos(combo As Controles.ComboBox)
      Dim o As Reglas.TiposVehiculos = New Reglas.TiposVehiculos()
      With combo
         .DisplayMember = Entidades.TipoVehiculo.Columnas.NombreTipoVehiculo.ToString()
         .ValueMember = Entidades.TipoVehiculo.Columnas.IdTipoVehiculo.ToString()
         .DataSource = o.GetTodos()
      End With
   End Sub
   Public Sub CargaComboTipoEmbarcacion(combo As Controles.ComboBox)
      Dim o As Reglas.TiposEmbarcaciones = New Reglas.TiposEmbarcaciones()
      With combo
         .DisplayMember = Entidades.TipoEmbarcacion.Columnas.NombreTipoEmbarcacion.ToString()
         .ValueMember = Entidades.TipoEmbarcacion.Columnas.IdTipoEmbarcacion.ToString()
         .DataSource = o.GetTodas()
      End With
   End Sub
   Public Sub CargaComboMarcasVehiculos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.MarcaVehiculo.Columnas.NombreMarcaVehiculo.ToString()
         .ValueMember = Entidades.MarcaVehiculo.Columnas.IdMarcaVehiculo.ToString()
         .DataSource = New Reglas.MarcasVehiculos().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboMarcasEmbarcaciones(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreMarcaEmbarcacion"
         .ValueMember = "IdMarcaEmbarcacion"
         .DataSource = New Reglas.MarcasEmbarcaciones().GetAll()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboMarcasMotores(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreMarcaMotor"
         .ValueMember = "IdMarcaMotor"
         .DataSource = New Reglas.MarcasMotores().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTurnosTurismo(combo As Controles.ComboBox)
      Dim o As Reglas.TurismoTurnos = New Reglas.TurismoTurnos()
      With combo
         .DisplayMember = Entidades.TurismoTurno.Columnas.NombreTurno.ToString()
         .ValueMember = Entidades.TurismoTurno.Columnas.IdTurno.ToString()
         .DataSource = o.GetTodos()
      End With
   End Sub
   Public Sub CargaComboTiposViajesTurismo(combo As Controles.ComboBox)
      Dim r = New Reglas.TurismoTiposViajes()
      With combo
         .DisplayMember = Entidades.TurismoTipoViaje.Columnas.DescripcionTipoViaje.ToString()
         .ValueMember = Entidades.TurismoTipoViaje.Columnas.IdTipoViaje.ToString()
         .DataSource = r.GetTodos()
      End With
   End Sub

   Public Sub CargaComboCursosTurismo(combo As Controles.ComboBox)
      Dim o As Reglas.TurismoCursos = New Reglas.TurismoCursos()
      With combo
         .DisplayMember = Entidades.TurismoCurso.Columnas.NombreCurso.ToString()
         .ValueMember = Entidades.TurismoCurso.Columnas.IdCurso.ToString()
         .DataSource = o.GetTodos()
      End With
   End Sub
   Public Sub CargaComboTipoDocumento(combo As Controles.ComboBox, Optional validoAFIP As Entidades.Publicos.SiNoTodos = Entidades.Publicos.SiNoTodos.TODOS)
      Dim oTipoDoc As Reglas.TiposDocumento = New Reglas.TiposDocumento()
      With combo
         .DisplayMember = "TipoDocumento"
         .ValueMember = "TipoDocumento"
         .DataSource = oTipoDoc.GetAll(validoAFIP)
         .Text = Reglas.Publicos.TipoDocumentoCliente() '"DNI"
      End With
   End Sub

   Public Sub CargaComboCategoriasEmpleados(combo As Controles.ComboBox, Optional activas As Entidades.Publicos.SiNoTodos = Entidades.Publicos.SiNoTodos.SI)
      Dim oCatEmp = New Reglas.MRPCategoriasEmpleados()
      With combo
         .DisplayMember = Entidades.MRPCategoriaEmpleado.Columnas.Descripcion.ToString()
         .ValueMember = Entidades.MRPCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString()
         .DataSource = oCatEmp._GetAll(activas)
      End With
   End Sub

   Public Sub CargaComboSecciones(combo As Controles.ComboBox, Optional activas As Entidades.Publicos.SiNoTodos = Entidades.Publicos.SiNoTodos.SI)
      Dim rSeccion = New Reglas.MRPSecciones()
      With combo
         .DisplayMember = Entidades.MRPSeccion.Columnas.Descripcion.ToString()
         .ValueMember = Entidades.MRPSeccion.Columnas.IdSeccion.ToString()
         .DataSource = rSeccion._GetAll(activas)
      End With
   End Sub

   Public Sub CargaComboTarjetas(combo As Controles.ComboBox, Optional activas As Boolean = False)
      Dim oTar As Reglas.Tarjetas = New Reglas.Tarjetas()
      With combo
         .DisplayMember = Entidades.Tarjeta.Columnas.NombreTarjeta.ToString()
         .ValueMember = Entidades.Tarjeta.Columnas.IdTarjeta.ToString()
         .DataSource = oTar.GetAll(activas)
      End With
   End Sub
   Public Sub CargaComboTarjetasE(combo As Controles.ComboBox, activas As Boolean)
      Dim oTar = New Reglas.Tarjetas()
      With combo
         .DisplayMember = Entidades.Tarjeta.Columnas.NombreTarjeta.ToString()
         .ValueMember = Entidades.Tarjeta.Columnas.IdTarjeta.ToString()
         .DataSource = oTar.GetTodos(activas)
      End With
   End Sub

   Public Sub CargaComboSituacion(combo As Controles.ComboBox, Optional activas As Boolean = False)
      Dim oSit = New Reglas.SituacionCupones()
      With combo
         .DisplayMember = Entidades.SituacionCupon.Columnas.NombreSituacionCupon.ToString()
         .ValueMember = Entidades.SituacionCupon.Columnas.IdSituacionCupon.ToString()
         .DataSource = oSit.GetAll()
      End With
   End Sub

   Public Sub CargaComboCuentasBancariasClase(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.CuentaBancariaClase.Columnas.NombreCuentaBancariaClase.ToString()
         .ValueMember = Entidades.CuentaBancariaClase.Columnas.IdCuentaBancariaClase.ToString()
         .DataSource = New Reglas.CuentasBancariasClase().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposImpuestos(combo As Controles.ComboBox, tipo As String)
      CargaComboTiposImpuestos(combo, tipo, String.Empty)
   End Sub
   Public Sub CargaComboTiposImpuestos(combo As Controles.ComboBox, tipo As Entidades.TipoImpuesto.Tipos)
      CargaComboTiposImpuestos(combo, String.Empty, tipo.ToString())
   End Sub
   Public Sub CargaComboTiposImpuestos(combo As Controles.ComboBox, tipo As String, tipoImpuesto As String)
      With combo
         .DisplayMember = "NombreTipoImpuesto"
         .ValueMember = "IdTipoImpuesto"
         If String.IsNullOrEmpty(tipoImpuesto) Then
            .DataSource = New Reglas.TiposImpuestos().GetAll2(tipo)
         Else
            .DataSource = New Reglas.TiposImpuestos().Get1(tipoImpuesto)
         End If
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboAplicativoAfip(combo As Controles.ComboBox, Optional tipoTipoImpuesto As String = "")
      With combo
         .DisplayMember = "AplicativoAfip"
         .ValueMember = "AplicativoAfip"
         .DataSource = New Reglas.TiposImpuestos().GetAplicativoAfip(tipoTipoImpuesto)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboImpuestos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "Alicuota"
         .ValueMember = "Alicuota"
         .DataSource = New Reglas.Impuestos().GetIVAs()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboImpuestos(combo As Controles.ComboBox, tipo As Entidades.TipoImpuesto.Tipos)
      CargaComboImpuestos(combo, tipo.ToString())
   End Sub
   Public Sub CargaComboImpuestos(combo As Controles.ComboBox, tipo As String)
      With combo
         .DisplayMember = "Alicuota"
         .ValueMember = "Alicuota"
         .DataSource = New Reglas.Impuestos().GetTodos(tipo)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboConceptosNoProductivo(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreConceptoNoProductivo"
         .ValueMember = "IdConceptoNoProductivo"
         .DataSource = New Reglas.MRPConceptosNoProductivos().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboEmpleados(combo As Controles.ComboBox, tipo As Entidades.Publicos.TiposEmpleados,
                                 Optional IdUsuario As String = "", Optional conDebitoTarjeta As Boolean = False)
      With combo
         .DisplayMember = "NombreEmpleado"
         .ValueMember = "IdEmpleado"
         .DataSource = New Reglas.Empleados().GetPorTipo(tipo, IdUsuario, conDebitoTarjeta)
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub
   Public Sub CargaComboEmpleados(combo As UltraWinEditors.UltraComboEditor, tipo As Entidades.Publicos.TiposEmpleados,
                                  Optional IdUsuario As String = "", Optional conDebitoTarjeta As Boolean = False)
      With combo
         .DisplayMember = "NombreEmpleado"
         .ValueMember = "IdEmpleado"
         .DataSource = New Reglas.Empleados().GetPorTipo(tipo, IdUsuario, conDebitoTarjeta)
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub

   Public Sub CargaComboOrdenesProducto(combo As Controles.ComboBox, activos As Boolean?)
      With combo
         .DisplayMember = "Orden"
         .ValueMember = "Orden"
         .DataSource = New Reglas.Productos().GetOrdenProductos(activos)
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub

   Public Sub CargaComboEmisor(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "CentroEmisor"
         .ValueMember = "CentroEmisor"
         .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboEmisor(combo As Controles.ComboBox,
                               idSucursal As Integer,
                               IdTipoComprobante As String,
                               miraPC As Boolean)
      Dim lImpresoras As List(Of Entidades.Impresora) = New Reglas.Impresoras().
                                                                  GetPorSucursalPCTipoComprobanteMultiples(idSucursal,
                                                                                                           IIf(miraPC, My.Computer.Name, "").ToString(),
                                                                                                           IdTipoComprobante)
      With combo
         .DisplayMember = "CentroEmisor"
         .ValueMember = "IdImpresora"
         .DataSource = lImpresoras
         If lImpresoras.Count = 1 Then
            .SelectedIndex = 0
         Else
            .SelectedIndex = -1
         End If
      End With
   End Sub

   Public Sub CargaComboTiposComprobantesRecibo(combo As Controles.ComboBox,
                                                miraPC As Boolean, tipo1 As String,
                                                esReciboClienteVinculado As Boolean?)
      CargaComboTiposComprobantes(combo,
                                  miraPC,
                                  tipo1,
                                  Tipo2:="", AfectaCaja:="", UsaFacturacionRapida:="",
                                  UsaFacturacion:=False, seleccionMultiple:=False, seleccionTodos:=False, IgnoraSucursal:=False,
                                  esRecibo:=True, esReciboClienteVinculado:=esReciboClienteVinculado)

   End Sub

   Public Sub CargaComboLetrasFiscales(combo As Controles.ComboBox, tipo As Entidades.TipoComprobante.Tipos?)
      With combo
         .DisplayMember = Entidades.VentaNumero.Columnas.LetraFiscal.ToString()
         .ValueMember = Entidades.VentaNumero.Columnas.LetraFiscal.ToString()
         .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales(tipo)
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboCentrosEmisores(combo As Controles.ComboBox, tipo As Entidades.TipoComprobante.Tipos?)
      With combo
         .DisplayMember = Entidades.VentaNumero.Columnas.CentroEmisor.ToString()
         .ValueMember = Entidades.VentaNumero.Columnas.CentroEmisor.ToString()
         .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores(tipo)
         .SelectedIndex = -1
      End With
   End Sub


   Public Sub CargaComboTiposComprobantes(combo As Controles.ComboBox,
                                          MiraPC As Boolean,
                                          Tipo1 As String,
                                          Optional Tipo2 As String = "",
                                          Optional AfectaCaja As String = "",
                                          Optional UsaFacturacionRapida As String = "",
                                          Optional UsaFacturacion As Boolean = False,
                                          Optional seleccionMultiple As Boolean = False,
                                          Optional seleccionTodos As Boolean = False,
                                          Optional IgnoraSucursal As Boolean = False,
                                          Optional esRecibo As Boolean? = Nothing,
                                          Optional coeficionesStock As Integer? = Nothing,
                                          Optional grabaLibro As Boolean? = Nothing,
                                          Optional esReciboClienteVinculado As Boolean? = Nothing,
                                          Optional coeficienteValor As Integer? = Nothing,
                                          Optional importeComprobante As Decimal? = Nothing,
                                          Optional tipoComprobantesList As String = "",
                                          Optional esElectronico As Boolean? = Nothing,
                                          Optional Clase As String = "")

      Dim oTiposComprobantes As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      Dim lis As List(Of Entidades.TipoComprobante) = oTiposComprobantes.GetHabilitados(actual.Sucursal.Id,
                                                         IIf(MiraPC, My.Computer.Name, "").ToString(),
                                                         Tipo1,
                                                         Tipo2,
                                                         AfectaCaja,
                                                         UsaFacturacionRapida,
                                                         UsaFacturacion,
                                                         IgnoraSucursal,
                                                         esRecibo,
                                                         coeficionesStock,
                                                         grabaLibro,
                                                         esReciboClienteVinculado,
                                                         coeficienteValor, importeComprobante,
                                                         esElectronico,
                                                         Clase)

      Dim indexPredefinidos As Integer = 0

      If seleccionTodos Then
         Dim suc As Entidades.TipoComprobante = New Entidades.TipoComprobante()
         suc.IdTipoComprobante = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         suc.Descripcion = Publicos.GetEnumString(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos)
         lis.Insert(indexPredefinidos, suc)
         indexPredefinidos += 1
      End If

      If seleccionMultiple Then
         Dim suc As Entidades.TipoComprobante = New Entidades.TipoComprobante()
         suc.IdTipoComprobante = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.SeleccionMultiple).ToString()
         suc.Descripcion = Publicos.GetEnumString(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.SeleccionMultiple)
         lis.Insert(indexPredefinidos, suc)
         indexPredefinidos += 1
      End If
      '-- REQ-37995.----------------------------------------------
      If Not String.IsNullOrEmpty(tipoComprobantesList) Then
         Dim arrays As String() = tipoComprobantesList.Split(","c)
         lis = lis.Where(Function(x) x.IdTipoComprobante.Contains(arrays(0).ToString()) Or x.IdTipoComprobante.Contains(arrays(1).ToString())).ToList()
      End If
      '-----------------------------------------------------------
      CargaComboTiposComprobantes(combo, lis)

   End Sub
   Public Sub CargaComboTiposComprobantes(combo As Controles.ComboBox,
                                          lis As List(Of Entidades.TipoComprobante))
      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"

         .DataSource = lis
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposComprobantesReemplazar(combo As Controles.ComboBox,
                                                    miraPC As Boolean,
                                                    tipo1 As String,
                                                    tipo2 As String,
                                                    afectaCaja As String,
                                                    usaFacturacion As Boolean,
                                                    permiteElectronicos As Boolean,
                                                    permiteFiscales As Boolean,
                                                    idSucursal As Integer,
                                                    grabaLibro As Boolean?,
                                                    esComercial As Boolean?,
                                                    coeficienteValor As Integer?,
                                                    incluyePreElectronicas As Boolean?)
      Dim oTiposComprobantes As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()

      With combo
         .DisplayMember = Entidades.TipoComprobante.Columnas.Descripcion.ToString()
         .ValueMember = Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString()

         .DataSource = oTiposComprobantes.GetParaReemplazar(idSucursal,
                                                            If(miraPC, My.Computer.Name, String.Empty),
                                                            tipo1,
                                                            tipo2,
                                                            afectaCaja,
                                                            usaFacturacion,
                                                            permiteElectronicos,
                                                            permiteFiscales,
                                                            grabaLibro,
                                                            esComercial,
                                                            coeficienteValor,
                                                            incluyePreElectronicas)

         .SelectedIndex = -1
      End With
   End Sub


   Public Sub CargaComboTiposComprobantesElectronicos(combo As Controles.ComboBox, UsaFacturacion As String)
      Dim oTiposComprobantes As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DisplayMember = Entidades.TipoComprobante.Columnas.Descripcion.ToString()
         .ValueMember = Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString()
         .DataSource = oTiposComprobantes.GetElectronicos(UsaFacturacion)
         .SelectedIndex = -1
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub

   Public Sub CargaComboTiposComprobantesFacturables(combo As Controles.ComboBox, comprobantesAsociados As String, miraPC As Boolean)
      Dim oTiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
         .DataSource = oTiposComprobantes.GetFacturables(comprobantesAsociados, miraPC)
         .SelectedIndex = -1
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub

   Public Sub CargaListaTiposComprobantesFacturables(combo As Eniac.Controles.CheckedListBox, comprobantesAsociados As String, miraPC As Boolean)
      Dim oTiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DataSource = oTiposComprobantes.GetFacturables(comprobantesAsociados, miraPC)
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
      End With
   End Sub

   Public Sub CargaListaTiposComprobantesFacturablesCom(combo As Eniac.Controles.CheckedListBox, Optional ComprobantesAsociados As String = "")
      Dim oTiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DataSource = oTiposComprobantes.GetFacturablesCom(ComprobantesAsociados)
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
      End With
   End Sub

   Public Sub CargaListaTiposComprobantesCompras(combo As Eniac.Controles.CheckedListBox)
      Dim oTiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DataSource = oTiposComprobantes.GetComprobantesCompras()
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
      End With
   End Sub

   Public Sub CargaListaTiposComprobantesPedidos(combo As Eniac.Controles.CheckedListBox)
      Dim oTiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DataSource = oTiposComprobantes.GetFacturablesPedidos()
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
      End With
   End Sub

   Public Sub CargaListaTiposComprobantesPedidosProveedores(combo As Controles.CheckedListBox)
      Dim oTiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DataSource = oTiposComprobantes.GetFacturablesPedidosProveedores(comprobantesAsociados:=String.Empty)
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
      End With
   End Sub

   Public Sub CargaComboTiposComprobantesFacturablesReales(combo As Controles.ComboBox, MiraPC As Boolean, Tipo1 As String, Optional Tipo2 As String = "")
      Dim oTiposComprobantes As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
         .DataSource = oTiposComprobantes.GetFacturablesReales(Eniac.Entidades.Usuario.Actual.Sucursal.Id, IIf(MiraPC, My.Computer.Name, "").ToString(), Tipo1, Tipo2)
         .SelectedIndex = -1
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub

   Public Sub CargaComboTiposComprobantesCtaCteClientes(combo As Controles.ComboBox)
      Dim oTiposComprobantes As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
         .DataSource = oTiposComprobantes.GetUsadosCtaCteClientes()
         .SelectedIndex = -1
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub

   Public Sub CargaComboTiposComprobantesCtaCteProveedoresPag(combo As Controles.ComboBox)
      Dim oTiposComprobantes As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
         .DataSource = oTiposComprobantes.GetCtaCteProveedoresPag()
         .SelectedIndex = -1
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub

   Public Sub CargaComboTiposComprobantesCtaCteProveedores(combo As Controles.ComboBox)
      Dim oTiposComprobantes As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
         .DataSource = oTiposComprobantes.GetUsadosCtaCteProveedores()
         .SelectedIndex = -1
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub

   Public Sub CargaComboTiposComprobantesBorrables(combo As Controles.ComboBox, Tipo As String)
      Dim oTiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
         .DataSource = oTiposComprobantes.GetBorrables(Tipo)
         .SelectedIndex = -1
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub

   Public Sub CargaComboFormasDePago(combo As Controles.ComboBox, tipo As String, Optional contado As Boolean? = Nothing)
      With combo
         .DisplayMember = "DescripcionFormasPago"
         .ValueMember = "IdFormasPago"
         .DataSource = New Reglas.VentasFormasPago().GetTodas(tipo, contado).ToArray()
         .SelectedIndex = 0
      End With
   End Sub
   Public Sub CargaComboFormasDePago(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString()
         .ValueMember = Entidades.VentaFormaPago.Columnas.IdFormasPago.ToString()
         .DataSource = New Reglas.VentasFormasPago().GetAll()
         .SelectedIndex = 0
      End With
   End Sub
   Public Sub CargaComboFormaDePago(combo As Controles.ComboBox, tipo As String, Optional esContado As Boolean? = Nothing,
                                    Optional seleccionMultiple As Boolean = False,
                                    Optional seleccionTodos As Boolean = False)

      Dim oTipos As Reglas.VentasFormasPago = New Reglas.VentasFormasPago()
      Dim lis As List(Of Entidades.VentaFormaPago) = oTipos.GetTodas(tipo, esContado)

      Dim indexPredefinidos As Integer = 0

      If seleccionTodos Then
         Dim suc As Entidades.VentaFormaPago = New Entidades.VentaFormaPago()
         suc.IdFormasPago = Convert.ToInt32(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.Todos)
         suc.DescripcionFormasPago = Publicos.GetEnumString(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.Todos)
         lis.Insert(indexPredefinidos, suc)
         indexPredefinidos += 1
      End If

      If seleccionMultiple Then
         Dim suc As Entidades.VentaFormaPago = New Entidades.VentaFormaPago()
         suc.IdFormasPago = Convert.ToInt32(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.SeleccionMultiple)
         suc.DescripcionFormasPago = Publicos.GetEnumString(Entidades.VentaFormaPago.ValoresFijosIdFormasPago.SeleccionMultiple)
         lis.Insert(indexPredefinidos, suc)
         indexPredefinidos += 1
      End If

      CargaComboFormasDePago(combo, lis)

   End Sub
   Public Sub CargaComboFormasDePago(combo As Controles.ComboBox, lis As List(Of Entidades.VentaFormaPago))
      With combo
         .DisplayMember = "DescripcionFormasPago"
         .ValueMember = "IdFormasPago"

         .DataSource = lis
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboListaDePrecios2(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()
         .ValueMember = Entidades.ListaDePrecios.Columnas.IdListaPrecios.ToString()
         .DataSource = New Reglas.ListasDePrecios().GetAll(True, Entidades.ListaDePrecios.Columnas.Orden)
         .SelectedIndex = 0
      End With
   End Sub

   Public Sub CargaComboTiposDeExension(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreTipoDeExension"
         .ValueMember = "IdTipoDeExension"
         .DataSource = New Reglas.TiposDeExension().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboCategoriasEmbarcaciones(combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = Eniac.Entidades.CategoriaEmbarcacion.Columnas.NombreCategoriaEmbarcacion.ToString()
         .ValueMember = Eniac.Entidades.CategoriaEmbarcacion.Columnas.IdCategoriaEmbarcacion.ToString()
         .DataSource = New Eniac.Reglas.CategoriasEmbarcaciones().GetAll()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboListaDePrecios(combo As Controles.ComboBox, activa As Boolean?, insertarEnPosicionCero As Entidades.ListaDePrecios)
      Dim li As List(Of Entidades.ListaDePrecios) = New Reglas.ListasDePrecios().GetTodos(activa)
      Dim l As Entidades.ListaDePrecios = New Entidades.ListaDePrecios()
      'Se agrego en la Base para poder agregar FK.
      'l.IdListaPrecios = 0
      'l.NombreListaPrecios = "Lista de Venta 1"
      'li.Insert(0, l)

      If insertarEnPosicionCero IsNot Nothing Then
         li.Insert(0, insertarEnPosicionCero)
      End If

      CargaComboListaDePrecios(combo, li)
      'With combo
      '   .DisplayMember = "NombreListaPrecios"
      '   .ValueMember = "IdListaPrecios"
      '   .DataSource = li
      '   'seteo por defecto la lista de precios predeterminada
      '   .SelectedValue = Publicos.ListaPreciosPredeterminada
      'End With
   End Sub
   Public Sub CargaComboListaDePrecios(combo As Controles.ComboBox, li As List(Of Entidades.ListaDePrecios))
      With combo
         .DisplayMember = "NombreListaPrecios"
         .ValueMember = "IdListaPrecios"
         .DataSource = li
         'seteo por defecto la lista de precios predeterminada
         .SelectedValue = Reglas.Publicos.ListaPreciosPredeterminada
      End With
   End Sub
   Public Sub CargaComboListaDePrecios(combo As Controles.ComboBox, Optional insertarEnPosicionCero As Entidades.ListaDePrecios = Nothing)
      Me.CargaComboListaDePrecios(combo, activa:=Nothing, insertarEnPosicionCero:=insertarEnPosicionCero)
   End Sub

   'Public Sub CargaComboCobradores(combo As Controles.ComboBox)
   '   With combo
   '      .DisplayMember = "NombreCobrador"
   '      .ValueMember = "IdCobrador"
   '      .DataSource = New Eniac.Reglas.Cobradores().GetAll()
   '      .SelectedIndex = -1
   '   End With
   'End Sub

   'Public Sub CargaComboCobradores2(combo As Controles.ComboBox)
   '   With combo
   '      .DisplayMember = "NombreCobrador"
   '      .ValueMember = "IdCobrador"
   '      .DataSource = New Eniac.Reglas.Cobradores().GetTodos()
   '      .SelectedIndex = -1
   '   End With
   'End Sub

   Public Sub CargaComboTipoClientes(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreTipoCliente"
         .ValueMember = "IdTipoCliente"
         .DataSource = New Eniac.Reglas.TiposClientes().GetAll()
         .SelectedIndex = -1

      End With
   End Sub

   Public Sub CargaComboModeloVehiculo(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreModeloVehiculo"
         .ValueMember = "IdModeloVehiculo"
         .DataSource = New Eniac.Reglas.ModelosVehiculos().GetTodos()
         .SelectedIndex = -1

      End With
   End Sub

   Public Sub CargaComboModeloVehiculo(combo As Controles.ComboBox, idMarca As Integer)
      With combo
         .DisplayMember = "NombreModeloVehiculo"
         .ValueMember = "IdModeloVehiculo"
         .DataSource = New Eniac.Reglas.ModelosVehiculos().GetTodosPorMarca(idMarca).OrderBy(Function(x) x.NombreModeloVehiculo).ToList()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboMarcaVehiculo(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.MarcaVehiculo.Columnas.NombreMarcaVehiculo.ToString()
         .ValueMember = Entidades.MarcaVehiculo.Columnas.IdMarcaVehiculo.ToString()
         .DataSource = New Eniac.Reglas.MarcasVehiculos().GetTodos().OrderBy(Function(x) x.NombreMarcaVehiculo).ToList()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboEstadoVehiculo(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.EstadoVehiculo.Columnas.NombreEstadoVehiculo.ToString()
         .ValueMember = Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculo.ToString()
         .DataSource = New Reglas.EstadosVehiculos().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTipoClientes(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean, idFuncion As String)
      With combo
         .DisplayMember = "NombreTipoCliente"
         .ValueMember = "IdTipoCliente"
         Dim lst As List(Of Entidades.TipoCliente) = New Reglas.TiposClientes().GetTodos()
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.TipoCliente = New Entidades.TipoCliente()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdTipoCliente = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreTipoCliente = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.TipoCliente = New Entidades.TipoCliente()
            categ.IdTipoCliente = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreTipoCliente = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboListasDePrecios(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean)
      With combo
         .DisplayMember = Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()
         .ValueMember = Entidades.ListaDePrecios.Columnas.IdListaPrecios.ToString()
         Dim lst As List(Of Entidades.ListaDePrecios) = New Reglas.ListasDePrecios().GetTodos()
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.ListaDePrecios = New Entidades.ListaDePrecios()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdListaPrecios = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreListaPrecios = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.ListaDePrecios = New Entidades.ListaDePrecios()
            categ.IdListaPrecios = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreListaPrecios = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposAtributos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.TipoAtributoProducto.Columnas.Descripcion.ToString()
         .ValueMember = Entidades.TipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString()
         .DataSource = New Reglas.TiposAtributosProductos().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposAdjuntos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.TipoAdjunto.Columnas.NombreTipoAdjunto.ToString()
         .ValueMember = Entidades.TipoAdjunto.Columnas.IdTipoAdjunto.ToString()
         .DataSource = New Eniac.Reglas.TiposAdjuntos().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposTurnos(combo As Controles.ComboBox)
      CargaComboTiposTurnos(combo, idTipoCalendario:=0S)
   End Sub
   Public Sub CargaComboTiposTurnos(combo As Controles.ComboBox, idTipoCalendario As Short)
      With combo
         .DisplayMember = Entidades.TipoTurno.Columnas.NombreTipoTurno.ToString()
         .ValueMember = Entidades.TipoTurno.Columnas.IdTipoTurno.ToString()
         .DataSource = New Eniac.Reglas.TiposTurnos().GetTodos(idTipoCalendario)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposCalendarios(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.TipoCalendario.Columnas.NombreTipoCalendario.ToString()
         .ValueMember = Entidades.TipoCalendario.Columnas.IdTipoCalendario.ToString()
         .DataSource = New Eniac.Reglas.TiposCalendarios().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboEstadosTurnos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.EstadoTurno.Columnas.NombreEstadoTurno.ToString()
         .ValueMember = Entidades.EstadoTurno.Columnas.IdEstadoTurno.ToString()
         .DataSource = New Eniac.Reglas.EstadosTurnos().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboDestinos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreDestino"
         .ValueMember = "IdDestino"
         .DataSource = New Reglas.Destinos().GetTodas()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboNaves(combo As Controles.ComboBox, MiraPC As Boolean)
      With combo
         .DisplayMember = Entidades.Nave.Columnas.NombreNave.ToString()
         .ValueMember = Entidades.Nave.Columnas.IdNave.ToString()
         .DataSource = New Reglas.Naves().GetHabilitadas(If(MiraPC, My.Computer.Name, String.Empty))
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboTipoNave(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.TipoNave.Columnas.NombreTipoNave.ToString()
         .ValueMember = Entidades.TipoNave.Columnas.IdTipoNave.ToString()
         .DataSource = New Reglas.TiposNaves().GetTodas()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboSector(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.Sector.Columnas.NombreSector.ToString()
         .ValueMember = Entidades.Sector.Columnas.IdSector.ToString()
         .DataSource = New Reglas.Sectores().GetTodas()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboListaPreciosVentas(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreListaPrecios"
         .ValueMember = "IdListaPrecios"
         .DataSource = New Reglas.VentasProductos().GetListasPreciosVentasProductos()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboListaPreciosVentasDescripcion(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreListaPrecios"
         .ValueMember = "NombreListaPrecios"
         .DataSource = New Reglas.VentasProductos().GetListasPreciosVentasProductosDescripcion()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboListaPreciosPedidos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreListaPrecios"
         .ValueMember = "NombreListaPrecios"
         .DataSource = New Reglas.PedidosProductos().GetListasPreciosPedidosProductos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboBancos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "Nombrebanco"
         .ValueMember = "IdBanco"
         .DataSource = New Reglas.Bancos().GetAll()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboBancosE(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "Nombrebanco"
         .ValueMember = "IdBanco"
         .DataSource = New Reglas.Bancos().GetTodosE()
         .SelectedIndex = -1
      End With
   End Sub

   'PE-31207
   Public Sub CargaComboSituacionCheques(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreSituacionCheque"
         .ValueMember = "IdSituacionCheque"
         .DataSource = New Reglas.SituacionCheques().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposCheques(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.TiposCheques.Columnas.NombreTipoCheque.ToString()
         .ValueMember = Entidades.TiposCheques.Columnas.IdTipoCheque.ToString()
         .DataSource = New Reglas.TiposCheques().GetTodos()
         .SelectedValue = "F"
      End With
   End Sub

   Public Sub CargaComboChequeras(combo As Controles.ComboBox, idCuentaBancaria As Integer)
      With combo
         .DisplayMember = Entidades.Chequera.Columnas.NombreChequera.ToString()
         .ValueMember = Entidades.Chequera.Columnas.IdChequera.ToString()
         .DataSource = New Reglas.Chequeras().GetTodos(idCuentaBancaria)
         .SelectedIndex = If(.Items.Count = 1, 0, -1)
      End With
   End Sub

   Public Sub CargaComboAplicaciones(combo As Controles.ComboBox)
      CargaComboAplicaciones(combo, propietarioAplicacion:=Nothing)
   End Sub
   Public Sub CargaComboAplicaciones(combo As Controles.ComboBox, propietarioAplicacion As Entidades.AplicacionPropietario?)
      With combo
         .DisplayMember = "NombreAplicacion"
         .ValueMember = "IdAplicacion"
         .DataSource = New Reglas.Aplicaciones().GetAll(propietarioAplicacion)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCalidadListaControlItemGrupo(combo As Controles.ComboBox)
      With combo
         .DataSource = New Reglas.CalidadListaControlItemGrupo().GetAll()
         .DisplayMember = Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString()
         .ValueMember = Entidades.CalidadListaControlItemGrupo.Columnas.IdListaControlItemGrupo.ToString()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCalidadListasControlItemSubGrupos(combo As Controles.ComboBox, idListaControlItemGrupo As String)
      With combo
         .DataSource = New Reglas.CalidadListasControlItemsSubGrupos().GetTodos(idListaControlItemGrupo)
         .DisplayMember = Entidades.CalidadListaControlItemSubGrupo.Columnas.NombreListaControlItemSubGrupo.ToString()
         .ValueMember = Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemSubGrupo.ToString()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCalidadListasControl(combo As Controles.ComboBox)
      Dim reg = New Reglas.CalidadListasControl()
      combo.DataSource = reg.GetTodos()
      combo.DisplayMember = Entidades.CalidadListaControl.Columnas.NombreListaControl.ToString()
      combo.ValueMember = Entidades.CalidadListaControl.Columnas.IdListaControl.ToString()
      combo.SelectedIndex = -1
   End Sub
   Public Sub CargaComboCalidadListasControlItem(combo As Controles.ComboBox, idListaControl As Integer)
      Dim reg = New Reglas.CalidadListasControlConfig()
      combo.DataSource = reg.GetAll(idListaControl)
      combo.DisplayMember = Entidades.CalidadListaControlItem.Columnas.NombreListaControlItem.ToString()
      combo.ValueMember = Entidades.CalidadListaControlItem.Columnas.IdListaControlItem.ToString()
      combo.SelectedIndex = -1
   End Sub


   Public Sub CargaComboTiposListasControl(combo As Controles.ComboBox)
      combo.DataSource = New Reglas.CalidadListasControlTipos().GetTodos()
      combo.ValueMember = Entidades.CalidadListaControlTipo.Columnas.IdListaControlTipo.ToString()
      combo.DisplayMember = Entidades.CalidadListaControlTipo.Columnas.NombreListaControlTipo.ToString()
      combo.SelectedIndex = -1
   End Sub
   Public Sub CargaComboEstadosOrdenCalidad(combo As Controles.ComboBox)
      Dim rEstadosOC = New Reglas.EstadosOrdenesCalidad()
      With combo
         .ValueMember = Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString()
         .DisplayMember = Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString()
         combo.DataSource = rEstadosOC.GetTodos()
         combo.SelectedIndex = -1
      End With

   End Sub
   Public Sub CargaComboEstadosOrdenCalidad(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean)
      With combo
         .DisplayMember = Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString()
         .ValueMember = Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString()
         Dim lst = New Reglas.EstadosOrdenesCalidad().GetTodos()
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim suc = New Entidades.EstadoOrdenCalidad()
            suc.IdEstadoCalidad = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, suc)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim suc = New Entidades.EstadoOrdenCalidad()
            suc.IdEstadoCalidad = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, suc)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   ''Public Sub CargaComboTiposModelosMultiple(combo As Controles.ComboBox,
   ''                                       Optional seleccionMultiple As Boolean = False,
   ''                                       Optional seleccionTodos As Boolean = False)

   ''   Dim oTiposModelos As Reglas.ProductosModelosTipos = New Reglas.ProductosModelosTipos()
   ''   Dim lis As List(Of Entidades.ProductoModeloTipo) = oTiposModelos.GetTodos()

   ''   Dim indexPredefinidos As Integer = 0

   ''   If seleccionTodos Then
   ''      Dim suc As Entidades.ProductoModeloTipo = New Entidades.ProductoModeloTipo()
   ''      suc.IdProductoModeloTipo = Entidades.ProductoModeloTipo.ValoresFijosIdProductoModeloTipo.Todos
   ''      suc.NombreProductoModeloTipo = Publicos.GetEnumString(Entidades.ProductoModeloTipo.ValoresFijosIdProductoModeloTipo.Todos)
   ''      lis.Insert(indexPredefinidos, suc)
   ''      indexPredefinidos += 1
   ''   End If

   ''   If seleccionMultiple Then
   ''      Dim suc As Entidades.ProductoModeloTipo = New Entidades.ProductoModeloTipo()
   ''      suc.IdProductoModeloTipo = Entidades.ProductoModeloTipo.ValoresFijosIdProductoModeloTipo.SeleccionMultiple
   ''      suc.NombreProductoModeloTipo = Publicos.GetEnumString(Entidades.ProductoModeloTipo.ValoresFijosIdProductoModeloTipo.SeleccionMultiple)
   ''      lis.Insert(indexPredefinidos, suc)
   ''      indexPredefinidos += 1
   ''   End If

   ''   CargaComboTiposModelosMul(combo, lis)

   ''End Sub
   ''Public Sub CargaComboTiposModelosMul(combo As Controles.ComboBox,
   ''                                       lis As List(Of Entidades.ProductoModeloTipo))
   ''   With combo
   ''      .DisplayMember = "NombreProductoModeloTipo"
   ''      .ValueMember = "IdProductoModeloTipo"

   ''      .DataSource = lis
   ''      .SelectedIndex = -1
   ''   End With
   ''End Sub

   ''Public Sub CargaComboTiposModelos(combo As Controles.ComboBox)
   ''   combo.DataSource = New Reglas.ProductosModelosTipos().GetTodos()
   ''   combo.ValueMember = Entidades.ProductoModeloTipo.Columnas.IdProductoModeloTipo.ToString()
   ''   combo.DisplayMember = Entidades.ProductoModeloTipo.Columnas.NombreProductoModeloTipo.ToString()
   ''   combo.SelectedIndex = -1
   ''End Sub

   ''Public Sub CargaComboSubTiposModelos(combo As Controles.ComboBox, IdProductoModeloTipo As Integer)
   ''   combo.DataSource = New Reglas.ProductosModelosSubTipos().GetxTipoModelo(IdProductoModeloTipo)
   ''   combo.ValueMember = Entidades.ProductoModeloSubTipo.Columnas.IdProductoModeloSubTipo.ToString()
   ''   combo.DisplayMember = Entidades.ProductoModeloSubTipo.Columnas.NombreProductoModeloSubTipo.ToString()
   ''   combo.SelectedIndex = -1
   ''End Sub

   'Public Sub CargaComboObservaciones(combo As Controles.ComboBox, Tipo As String)
   '   combo.DataSource = New Reglas.Observaciones().GetTodos(Tipo)
   '   combo.ValueMember = Entidades.Observacion.Columnas.IdObservacion.ToString()
   '   combo.DisplayMember = Entidades.Observacion.Columnas.DetalleObservacion.ToString()
   '   combo.SelectedIndex = -1
   'End Sub

   'Public Sub CargaComboTiposExcepciones(combo As Controles.ComboBox)
   '   combo.DataSource = New Reglas.ExcepcionesTipos().GetTodos()
   '   combo.ValueMember = Entidades.ExcepcionTipo.Columnas.IdExcepcionTipo.ToString()
   '   combo.DisplayMember = Entidades.ExcepcionTipo.Columnas.NombreExcepcionTipo.ToString()
   '   combo.SelectedIndex = -1
   'End Sub

   'Public Sub CargaComboTiposServiciosProducto(combo As Controles.ComboBox)
   '   combo.DataSource = New Reglas.ProductosTiposServicios().GetTodos()
   '   combo.ValueMember = Entidades.ProductoTipoServicio.Columnas.IdProductoTipoServicio.ToString()
   '   combo.DisplayMember = Entidades.ProductoTipoServicio.Columnas.NombreProductoTipoServicio.ToString()
   '   combo.SelectedIndex = -1
   'End Sub
   'Public Sub CargaComboTiposServiciosProductoCalidad(combo As Controles.ComboBox)
   '   combo.DataSource = New Reglas.ProductosTiposServicios().GetABMProdCalidad()
   '   combo.ValueMember = Entidades.ProductoTipoServicio.Columnas.IdProductoTipoServicio.ToString()
   '   combo.DisplayMember = Entidades.ProductoTipoServicio.Columnas.NombreProductoTipoServicio.ToString()
   '   combo.SelectedIndex = -1
   'End Sub
   Public Sub CargaComboUbicacionCalidad(combo As Controles.ComboBox)
      Dim reg As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
      combo.DataSource = reg.GetUbicacionesCalidad()
      combo.ValueMember = Entidades.ProductoSucursal.Columnas.Ubicacion.ToString()
      combo.DisplayMember = Entidades.ProductoSucursal.Columnas.Ubicacion.ToString()
      combo.SelectedIndex = -1
   End Sub

   Public Sub CargaComboAplicacionesEntidad(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreAplicacion"
         .ValueMember = "IdAplicacion"
         .DataSource = New Reglas.Aplicaciones().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboModulos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreModulo"
         .ValueMember = "IdModulo"
         .DataSource = New Reglas.AplicacionesModulos().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboAplicacionesEdiciones(combo As Controles.ComboBox, IdAplicacion As String)
      With combo
         .DisplayMember = "NombreEdicion"
         .ValueMember = "IdEdicion"
         .DataSource = New Reglas.AplicacionesEdiciones().GetEdiciones(IdAplicacion)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboPais(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.Pais.Columnas.NombrePais.ToString()
         .ValueMember = Entidades.Pais.Columnas.IdPais.ToString()
         .DataSource = New Reglas.Paises().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   '-- REQ-31198.- -Factura de Exportacion.- 
   Public Sub CargaComboClausulaVentas(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.AFIPIncoterm.Columnas.NombreIncoterm.ToString()
         .ValueMember = Entidades.AFIPIncoterm.Columnas.IdIncoterm.ToString()
         .DataSource = New Reglas.AFIPIncoterms().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboDestinosExportacion(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.Pais.Columnas.NombrePais.ToString()
         .ValueMember = Entidades.Pais.Columnas.IdPais.ToString()
         .DataSource = New Reglas.Paises().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub
   '----------------------------------------

   Public Sub CargaComboTiposLiquidacion(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreTipoLiquidacion"
         .ValueMember = "IdTipoLiquidacion"
         .DataSource = New Reglas.Cargos().GetTiposLiquidacion()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposMovimientos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoMovimiento"
         .DataSource = New Reglas.TiposMovimientos().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboColaImpresion(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreColaImpresion"
         .ValueMember = "IdVentaColaImpresion"
         .DataSource = New Reglas.VentasColasImpresion().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboPlantillas(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombrePlantilla"
         .ValueMember = "IdPlantilla"
         .DataSource = New Reglas.Plantillas().GetAll()
         .SelectedIndex = -1
      End With
   End Sub


   Public Sub CargaComboConcesionarioTipoUnidad(combo As Controles.ComboBox, ceroKM As Entidades.Publicos.SiNoTodos)
      With combo
         .DisplayMember = Entidades.ConcesionarioTipoUnidad.columnas.NombreTipoUnidad.ToString()
         .ValueMember = Entidades.ConcesionarioTipoUnidad.columnas.IdTipoUnidad.ToString()
         .DataSource = New Reglas.ConcesionarioTiposUnidades().GetTodos(ceroKM)
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboConcesionarioDistribucionEjes(combo As Controles.ComboBox, idTipoUnidad As Integer)
      With combo
         .DisplayMember = Entidades.ConcesionarioDistribucionEje.columnas.NombreEje.ToString()
         .ValueMember = Entidades.ConcesionarioDistribucionEje.columnas.IdEje.ToString()
         .DataSource = New Reglas.ConcesionarioDistribucionEjes().GetTodos(idTipoUnidad)
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboConcesionarioTipoUnidad(combo As Controles.ComboBox, idTipoUnidad As Integer)
      With combo
         .DisplayMember = Entidades.ConcesionarioSubTipoUnidad.columnas.NombreSubTipoUnidad.ToString()
         .ValueMember = Entidades.ConcesionarioSubTipoUnidad.columnas.IdSubTipoUnidad.ToString()
         .DataSource = New Reglas.ConcesionarioSubTiposUnidades().GetTodos(idTipoUnidad)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboMarcas(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreMarca"
         .ValueMember = "IdMarca"
         .DataSource = New Reglas.Marcas().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboMarcas(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean)
      With combo
         .DisplayMember = "NombreMarca"
         .ValueMember = "IdMarca"
         Dim lst As List(Of Entidades.Marca) = New Reglas.Marcas().GetTodas()
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.Marca = New Entidades.Marca()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdMarca = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreMarca = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.Marca = New Entidades.Marca()
            categ.IdMarca = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreMarca = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboEmpleados(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean)
      With combo
         .DisplayMember = "NombreEmpleado"
         .ValueMember = "IdEmpleado"
         Dim lst As List(Of Entidades.Empleado) = New Reglas.Empleados().GetTodos(False)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ = New Entidades.Empleado()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdEmpleado = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreEmpleado = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ = New Entidades.Empleado()
            categ.IdEmpleado = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreEmpleado = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboModelos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreModelo"
         .ValueMember = "IdModelo"
         .DataSource = New Reglas.Modelos().GetAll()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboModelos(combo As Controles.ComboBox,
                                displayMember As String,
                                seleccionMultiple As Boolean, seleccionTodos As Boolean,
                                marcas As Entidades.Marca())
      With combo
         .DisplayMember = displayMember
         .ValueMember = "IdModelo"
         Dim lst = New Reglas.Modelos().GetTodos(marcas)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ = New Entidades.Modelo()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdModelo = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreModelo = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ = New Entidades.Modelo()
            categ.IdModelo = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreModelo = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboObservacionesCalidad(combo As Controles.ComboBox, Tipo As String)
      With combo
         .DisplayMember = Entidades.Observacion.Columnas.DetalleObservacion.ToString()
         .ValueMember = Entidades.Observacion.Columnas.IdObservacion.ToString()
         .DataSource = New Reglas.Observaciones().GetTodos(Tipo)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboRubros(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreRubro"
         .ValueMember = "IdRubro"
         .DataSource = New Reglas.Rubros().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboRubros(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean)
      With combo
         .DisplayMember = "NombreRubro"
         .ValueMember = "IdRubro"
         Dim lst As List(Of Entidades.Rubro) = New Reglas.Rubros().GetTodos()
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.Rubro = New Entidades.Rubro()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdRubro = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreRubro = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.Rubro = New Entidades.Rubro()
            categ.IdRubro = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreRubro = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboSubRubros(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreCompleto"
         .ValueMember = "IdSubRubro"
         '.DataSource = New Reglas.SubRubros().GetAll()
         .DataSource = New Reglas.SubRubros().GetNombreUnido()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboSubRubros(combo As Controles.ComboBox,
                                  seleccionMultiple As Boolean, seleccionTodos As Boolean,
                                  rubros As Entidades.Rubro())
      CargaComboSubRubros(combo, "NombreSubRubro", seleccionMultiple, seleccionTodos, rubros)
   End Sub

   Public Sub CargaComboSubRubros(combo As Controles.ComboBox,
                                  displayMember As String,
                                  seleccionMultiple As Boolean, seleccionTodos As Boolean,
                                  rubros As Entidades.Rubro())
      With combo
         .DisplayMember = displayMember
         .ValueMember = "IdSubRubro"
         Dim lst As List(Of Entidades.SubRubro) = New Reglas.SubRubros().GetTodos(rubros)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.SubRubro = New Entidades.SubRubro()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdSubRubro = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreSubRubro = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.SubRubro = New Entidades.SubRubro()
            categ.IdSubRubro = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreSubRubro = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboSubSubRubros(combo As Controles.ComboBox,
                                     displayMember As String,
                                     seleccionMultiple As Boolean, seleccionTodos As Boolean,
                                     subRubros As Entidades.SubRubro())

      With combo
         .DisplayMember = displayMember
         .ValueMember = "IdSubSubRubro"
         Dim lst As List(Of Entidades.SubSubRubro) = New Reglas.SubSubRubros().GetTodos(subRubros)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.SubSubRubro = New Entidades.SubSubRubro()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdSubSubRubro = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreSubSubRubro = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.SubSubRubro = New Entidades.SubSubRubro()
            categ.IdSubSubRubro = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreSubSubRubro = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboSubSubRubros(combo As Controles.ComboBox,
                                     seleccionMultiple As Boolean, seleccionTodos As Boolean,
                                     idSubRubro As Integer)
      With combo
         .DisplayMember = "NombreSubSubRubro"
         .ValueMember = "IdSubSubRubro"
         Dim lst As List(Of Entidades.SubSubRubro) = New Reglas.SubSubRubros().GetTodos(idSubRubro)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.SubSubRubro = New Entidades.SubSubRubro()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdSubSubRubro = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreSubSubRubro = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.SubSubRubro = New Entidades.SubSubRubro()
            categ.IdSubSubRubro = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreSubSubRubro = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboUnidadesDeMedidas(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreUnidadDeMedida"
         .ValueMember = "IdUnidadDeMedida"
         .DataSource = New Reglas.UnidadesDeMedidas().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboEstadosCheques(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "IdEstadoCheque"
         .ValueMember = "IdEstadoCheque"
         .DataSource = New Reglas.EstadosCheques().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboEstadosCheques(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean)
      With combo
         .DisplayMember = "NombreEstadoCheque"
         .ValueMember = "IdEstadoCheque"
         Dim lst As List(Of Entidades.EstadoCheque) = New Reglas.EstadosCheques().GetTodos()
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim estado As Entidades.EstadoCheque = New Entidades.EstadoCheque()
            '  estado.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            estado.IdEstadoCheque = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            estado.NombreEstadoCheque = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, estado)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim estado As Entidades.EstadoCheque = New Entidades.EstadoCheque()
            estado.IdEstadoCheque = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            estado.NombreEstadoCheque = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, estado)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = 0
      End With
   End Sub
   Public Sub CargaComboZonasGeograficas(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreZonaGeografica"
         .ValueMember = "IdZonaGeografica"
         .DataSource = New Reglas.ZonasGeograficas().GetTodas()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboAntiguedadSaldoConfigCliente(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreAntiguedadSaldoConfig"
         .ValueMember = "IdAntiguedadSaldoConfig"
         .DataSource = New Reglas.CuentasCorrientesAntiguedadesSaldosConfig().GetTodos(Entidades.CuentaCorrienteAntiguedadSaldoConfig.TipoAntiguedadSaldo.AntiguedadSaldosClientes)

         '.DataSource = {New Entidades.CuentaCorrienteAntiguedadSaldoConfig() With
         '                     {
         '                        .IdAntiguedadSaldoConfig = 1,
         '                        .NombreAntiguedadSaldoConfig = "Por defecto",
         '                        .PorDefecto = True,
         '                        .Rangos = New List(Of Entidades.CuentaCorrienteAntiguedadSaldoRangos)() From
         '                           {
         '                              New Entidades.CuentaCorrienteAntiguedadSaldoRangos() With
         '                                    {.IdAntiguedadSaldoConfig = 1, .DiasDesde = 121, .DiasHasta = 50000, .EtiquetaColumna = "MOROSO", .Orden = 1},
         '                              New Entidades.CuentaCorrienteAntiguedadSaldoRangos() With
         '                                    {.IdAntiguedadSaldoConfig = 1, .DiasDesde = 91, .DiasHasta = 120, .EtiquetaColumna = "-120 días", .Orden = 2},
         '                              New Entidades.CuentaCorrienteAntiguedadSaldoRangos() With
         '                                    {.IdAntiguedadSaldoConfig = 1, .DiasDesde = 61, .DiasHasta = 90, .EtiquetaColumna = "-90 días", .Orden = 3},
         '                              New Entidades.CuentaCorrienteAntiguedadSaldoRangos() With
         '                                    {.IdAntiguedadSaldoConfig = 1, .DiasDesde = 31, .DiasHasta = 60, .EtiquetaColumna = "-60 días", .Orden = 4},
         '                              New Entidades.CuentaCorrienteAntiguedadSaldoRangos() With
         '                                    {.IdAntiguedadSaldoConfig = 1, .DiasDesde = 1, .DiasHasta = 30, .EtiquetaColumna = "-30 días", .Orden = 5},
         '                              New Entidades.CuentaCorrienteAntiguedadSaldoRangos() With
         '                                    {.IdAntiguedadSaldoConfig = 1, .DiasDesde = 0, .DiasHasta = 0, .EtiquetaColumna = "AL DIA", .Orden = 6},
         '                              New Entidades.CuentaCorrienteAntiguedadSaldoRangos() With
         '                                    {.IdAntiguedadSaldoConfig = 1, .DiasDesde = -30, .DiasHasta = -1, .EtiquetaColumna = "a 30 días", .Orden = 7},
         '                              New Entidades.CuentaCorrienteAntiguedadSaldoRangos() With
         '                                    {.IdAntiguedadSaldoConfig = 1, .DiasDesde = -60, .DiasHasta = -31, .EtiquetaColumna = "a 60 días", .Orden = 8},
         '                              New Entidades.CuentaCorrienteAntiguedadSaldoRangos() With
         '                                    {.IdAntiguedadSaldoConfig = 1, .DiasDesde = -90, .DiasHasta = -61, .EtiquetaColumna = "a 90 días", .Orden = 9},
         '                              New Entidades.CuentaCorrienteAntiguedadSaldoRangos() With
         '                                    {.IdAntiguedadSaldoConfig = 1, .DiasDesde = -50000, .DiasHasta = -91, .EtiquetaColumna = "+ 120 días", .Orden = 10}
         '                           }}}

         .SelectedIndex = 0
      End With
   End Sub
   Public Sub CargaComboAntiguedadSaldoConfigProveedor(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreAntiguedadSaldoConfig"
         .ValueMember = "IdAntiguedadSaldoConfig"
         .DataSource = New Reglas.CuentasCorrientesAntiguedadesSaldosConfig().GetTodos(Entidades.CuentaCorrienteAntiguedadSaldoConfig.TipoAntiguedadSaldo.AntiguedadSaldosProveedores)
         .SelectedIndex = 0
      End With
   End Sub
   Public Sub CargaComboTiposDirecciones(combo As Controles.ComboBox)
      CargaComboTiposDirecciones(combo, 0, Nothing)
   End Sub
   Public Sub CargaComboTiposDirecciones(combo As Controles.ComboBox, posicion As Integer, adicional As Entidades.TipoDireccion)
      With combo
         .DisplayMember = "NombreTipoDireccion"
         .ValueMember = "IdTipoDireccion"

         Dim lst As List(Of Entidades.TipoDireccion) = New Reglas.TiposDirecciones().GetTodas()
         If adicional IsNot Nothing Then
            lst.Insert(posicion, adicional)
         End If

         .DataSource = lst
         .SelectedIndex = 0
      End With
   End Sub

   Public Sub CargaComboMonedas(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreMoneda"
         .ValueMember = "IdMoneda"
         .DataSource = New Reglas.Monedas().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboMonedas1(combo As Controles.ComboBox)
      CargaComboMonedas1(combo, {}, {})
   End Sub
   Public Sub CargaComboMonedas1(combo As Controles.ComboBox,
                                 agregarAlPrincipio As Entidades.Moneda(),
                                 agregarAlFinal As Entidades.Moneda())
      With combo
         .DisplayMember = "NombreMoneda"
         .ValueMember = "IdMoneda"

         Dim list As List(Of Entidades.Moneda) = New List(Of Entidades.Moneda)(agregarAlPrincipio)
         list.AddRange(New Reglas.Monedas().GetTodos())
         list.AddRange(agregarAlFinal)

         .DataSource = list
         .SelectedIndex = -1
      End With
   End Sub

   '-.PE-31629.-
   Public Sub CargaComboNombrePC(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombrePC"
         .ValueMember = "NombrePC"
         .DataSource = New Reglas.UsuariosAccesos().GetNombresPC()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboUsuarios(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "Nombre"
         .ValueMember = "Usuario"
         .DataSource = New Reglas.Usuarios().GetTodos(toLowerId:=False)
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboRoles(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.Rol.Columnas.Nombre.ToString()
         .ValueMember = Entidades.Rol.Columnas.Id.ToString()
         .DataSource = New Reglas.Roles().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   'Public Sub CargaComboUsuariosWebCalidad(combo As Eniac.Controles.ComboBox)
   '   With combo
   '      .DisplayMember = "nombre_usuario"
   '      .ValueMember = "nombre_usuario"
   '      .DataSource = New Reglas.AuditoriaLoginWeb().GetUsuariosAuditorias()
   '      .SelectedIndex = -1
   '   End With
   'End Sub
   Public Sub CargaComboUsuariosActivos(combo As Controles.ComboBox, Optional usuarioActual As String = "")
      With combo
         .DisplayMember = "Nombre"
         .ValueMember = "Usuario"
         .DataSource = New Reglas.Usuarios().GetActivos(toLowerId:=False, usuarioActual)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboRegimenes(combo As Controles.ComboBox, idTipoImpuesto As String)
      With combo
         .DisplayMember = Entidades.Regimen.Columnas.ConceptoRegimen.ToString()
         .ValueMember = Entidades.Regimen.Columnas.IdRegimen.ToString()
         .DataSource = New Reglas.Regimenes().GetTodos(idTipoImpuesto)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboSemaforoVentasUtilidades(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "PorcentajeHasta"
         .ValueMember = "PorcentajeHasta"
         .DataSource = New Reglas.SemaforoVentasUtilidades().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboRubrosCompras(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreRubro"
         .ValueMember = "IdRubro"
         .DataSource = New Reglas.RubrosCompras().GetAll()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboRubrosCompras(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean)
      With combo
         .DisplayMember = "NombreRubro"
         .ValueMember = "IdRubro"
         Dim lst As List(Of Entidades.RubroCompra) = New Reglas.RubrosCompras().GetTodos()
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.RubroCompra = New Entidades.RubroCompra()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdRubro = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreRubro = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.RubroCompra = New Entidades.RubroCompra()
            categ.IdRubro = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreRubro = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboPeriodosFiscales(combo As Controles.ComboBox, idEmpresa As Integer, Estado As String)
      With combo
         .DisplayMember = "PeriodoFiscal"
         .ValueMember = "PeriodoFiscal"
         .DataSource = New Reglas.PeriodosFiscales().GetAll2(idEmpresa, Estado)
         .SelectedIndex = -1
      End With
   End Sub


   Public Sub CargaComboModalidadCodigoDeBarras(combo As Controles.ComboBox)
      Dim col As List(Of String) = New List(Of String)()

      col.Add(Entidades.Producto.Modalidades.PESO.ToString())
      col.Add(Entidades.Producto.Modalidades.PRECIO.ToString())

      combo.DataSource = col
      combo.SelectedIndex = -1

   End Sub

   '-- REQ-30521.- --
   '--- Mercado Libre - Categorias.- --------------------------
   Public Sub CargaComboCategoriasMercadoLibre(combo As Controles.ComboBox)
      Dim ActivoSiNo As Entidades.Publicos.SiNoTodos = Entidades.Publicos.SiNoTodos.SI
      Dim oCat As Eniac.Reglas.CategoriasMercadoLibre = New Eniac.Reglas.CategoriasMercadoLibre

      With combo
         .DisplayMember = "NombreCategoria"
         .ValueMember = "IdCategoria"
         .DataSource = oCat.GetAll(ActivoSiNo)
         .SelectedIndex = -1
      End With
   End Sub

   '-----------------------------------------------------------
   '-- REQ-38948.- -Procesos Productivos-

   Public Sub CargaComboProcesosProductivos(combo As Controles.ComboBox, idProducto As String, activoSiNo As Entidades.Publicos.SiNoTodos)
      Dim rProcProd = New Reglas.MRPProcesosProductivos
      With combo
         .DisplayMember = "DescripcionProceso"
         .ValueMember = "IdProcesoProductivo"
         .DataSource = rProcProd._GetAll(idProducto, activoSiNo)
         .SelectedIndex = -1
      End With
   End Sub


   'Alquileres ------------------------------------------------

   Public Sub CargaComboEstadosContratos(combo As Controles.ComboBox)
      Dim oEC As Eniac.Reglas.AlquileresEstadosContratos = New Eniac.Reglas.AlquileresEstadosContratos
      With combo
         .DisplayMember = "NombreEstado"
         .ValueMember = "IdEstado"
         .DataSource = oEC.GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   '------------------------------------------------
   Public Sub CargaComboEstadosPedidos(combo As Controles.ComboBox,
                                       agregarTODOS As Boolean, agregarSOLOPendientes As Boolean,
                                       agregarSOLOEnProceso As Boolean, agregarAnulado As Boolean, agregarEstadosPendientes As Boolean,
                                       tipoTipoComprobante As String)
      CargaComboEstadosPedidos(combo,
                               agregarTODOS, agregarSOLOPendientes,
                               agregarSOLOEnProceso, agregarAnulado, agregarEstadosPendientes,
                               tipoTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.TODOS)
   End Sub
   Public Sub CargaComboEstadosPedidos(combo As Controles.ComboBox,
                                       agregarTODOS As Boolean, agregarSOLOPendientes As Boolean,
                                       agregarSOLOEnProceso As Boolean, agregarAnulado As Boolean, agregarEstadosPendientes As Boolean,
                                       tipoTipoComprobante As String, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos)
      Dim oEstados As Reglas.EstadosPedidos = New Reglas.EstadosPedidos
      With combo
         .DisplayMember = "IdEstado"
         .ValueMember = "IdEstado"
         If agregarTODOS Or agregarSOLOPendientes Or agregarSOLOEnProceso Or agregarAnulado Or agregarEstadosPendientes Then
            .DataSource = oEstados.GetEstados(agregarTODOS, agregarSOLOPendientes, agregarSOLOEnProceso, agregarAnulado, agregarEstadosPendientes, tipoTipoComprobante, seguridadRol)
         Else
            .DataSource = oEstados.GetAll(tipoTipoComprobante, seguridadRol, activos:=Entidades.Publicos.SiNoTodos.SI)
         End If
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboEstadosOrdenesProduccion(combo As Controles.ComboBox,
                                     AgregarTODOS As Boolean, AgregarSOLOPendientes As Boolean,
                                     AgregarSOLOEnProceso As Boolean, AgregarAnulado As Boolean,
                                     tipoEstado As String)
      Dim oEstados As Reglas.EstadosOrdenesProduccion = New Reglas.EstadosOrdenesProduccion
      With combo
         .DisplayMember = "IdEstado"
         .ValueMember = "IdEstado"
         If AgregarTODOS Or AgregarSOLOPendientes Or AgregarSOLOEnProceso Or AgregarAnulado Then
            .DataSource = oEstados.GetEstados(AgregarTODOS, AgregarSOLOPendientes, AgregarSOLOEnProceso, AgregarAnulado, tipoEstado)
         Else
            .DataSource = oEstados.GetAll()
         End If
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposEstadosPedidos(combo As Controles.ComboBox, tipoTipoComprobante As String)
      Dim oEstados As Reglas.EstadosPedidos = New Reglas.EstadosPedidos
      With combo
         .DisplayMember = "IdTipoEstado"
         .ValueMember = "IdTipoEstado"
         .DataSource = oEstados.GetTiposEstados(tipoTipoComprobante)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposEstadosOrdenesProduccion(combo As Controles.ComboBox)
      Dim oEstados As Reglas.EstadosOrdenesProduccion = New Reglas.EstadosOrdenesProduccion
      With combo
         .DisplayMember = "IdTipoEstado"
         .ValueMember = "IdTipoEstado"
         .DataSource = oEstados.GetTiposEstados()
         .SelectedIndex = -1
      End With
   End Sub

   <Obsolete("Agregar parámetro Entidades.Publicos.LecturaEscrituraTodos.TODOS")>
   Public Sub CargaComboEstadosPedidosProv(combo As Controles.ComboBox,
                                           agregarTODOS As Boolean, agregarSOLOPendientes As Boolean, agregarSOLOEnProceso As Boolean, agregarAnulado As Boolean,
                                           agregarEstadosPendientes As Boolean,
                                           tipoEstadoPedido As String)
      CargaComboEstadosPedidosProv(combo,
                                   agregarTODOS, agregarSOLOPendientes, agregarSOLOEnProceso, agregarAnulado,
                                   agregarEstadosPendientes,
                                   tipoEstadoPedido,
                                   Entidades.Publicos.LecturaEscrituraTodos.TODOS)
   End Sub
   Public Sub CargaComboEstadosPedidosProv(combo As Controles.ComboBox,
                                           agregarTODOS As Boolean, agregarSOLOPendientes As Boolean, agregarSOLOEnProceso As Boolean, agregarAnulado As Boolean,
                                           agregarEstadosPendientes As Boolean,
                                           tipoEstadoPedido As String,
                                           seguridadRol As Entidades.Publicos.LecturaEscrituraTodos)
      Dim oEstados As Reglas.EstadosPedidosProveedores = New Reglas.EstadosPedidosProveedores
      With combo
         .DisplayMember = "IdEstado"
         .ValueMember = "IdEstado"

         If agregarTODOS Or agregarSOLOPendientes Or agregarSOLOEnProceso Or agregarAnulado Or agregarEstadosPendientes Then
            .DataSource = oEstados.GetEstados(agregarTODOS, agregarSOLOPendientes, agregarSOLOEnProceso, agregarAnulado, agregarEstadosPendientes, tipoEstadoPedido, seguridadRol)
         Else
            .DataSource = oEstados.GetAll(tipoEstadoPedido, seguridadRol, activos:=Entidades.Publicos.SiNoTodos.SI)
         End If

         '.DataSource = oEstados.GetEstados(AgregarTODOS, AgregarSOLOPendientes, AgregarSOLOEnProceso, AgregarAnulado, AgregarEstadosPendientes, TipoEstadoPedido)
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboAreaComun(combo As Controles.ComboBox, Optional esNave As Boolean? = Nothing)
      With combo
         .DisplayMember = Entidades.AreaComun.Columnas.NombreAreaComun.ToString()
         .ValueMember = Entidades.AreaComun.Columnas.IdAreaComun.ToString()
         .DataSource = New Reglas.AreasComunes().GetAll(esNave)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboEstadosPedidosProvCalidad(combo As Controles.ComboBox,
                                           AgregarTODOS As Boolean, AgregarSOLOPendientes As Boolean, AgregarSOLOEnProceso As Boolean, AgregarAnulado As Boolean,
                                           AgregarEstadosPendientes As Boolean,
                                           TipoEstadoPedido As String)
      Dim oEstados As Reglas.EstadosPedidosProveedores = New Reglas.EstadosPedidosProveedores
      With combo
         .DisplayMember = "IdEstado"
         .ValueMember = "IdEstado"

         If AgregarTODOS Or AgregarSOLOPendientes Or AgregarSOLOEnProceso Or AgregarAnulado Or AgregarEstadosPendientes Then
            .DataSource = oEstados.GetEstadosCalidad(AgregarTODOS, AgregarSOLOPendientes, AgregarSOLOEnProceso, AgregarAnulado, AgregarEstadosPendientes, TipoEstadoPedido)
         Else
            .DataSource = oEstados.GetAll(TipoEstadoPedido)
         End If

         '.DataSource = oEstados.GetEstados(AgregarTODOS, AgregarSOLOPendientes, AgregarSOLOEnProceso, AgregarAnulado, AgregarEstadosPendientes, TipoEstadoPedido)
         .SelectedIndex = -1
      End With
   End Sub

   'Public Sub CargaComboEstadosCalidad(combo As Controles.ComboBox)
   '   Dim oEC As Eniac.Reglas.EstadosListasControl = New Eniac.Reglas.EstadosListasControl
   '   With combo
   '      .DisplayMember = "NombreEstadoCalidad"
   '      .ValueMember = "IdEstadoCalidad"
   '      .DataSource = oEC.GetAll()
   '      .SelectedIndex = -1
   '   End With
   'End Sub

   Public Sub CargaComboTiposEstadosPedidosProv(combo As Controles.ComboBox, TipoEstadoPedido As String)
      Dim oEstados As Reglas.EstadosPedidosProveedores = New Reglas.EstadosPedidosProveedores
      With combo
         .DisplayMember = "IdTipoEstado"
         .ValueMember = "IdTipoEstado"
         .DataSource = oEstados.GetTiposEstados(TipoEstadoPedido)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboGruposDeCuentas(combo As Controles.ComboBox)
      Dim oCdC As Eniac.Reglas.CuentasDeCajas = New Eniac.Reglas.CuentasDeCajas
      With combo
         .DisplayMember = "IdGrupoCuenta"
         .ValueMember = "IdGrupoCuenta"
         .DataSource = oCdC.GetGruposDeCuentas()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboFormulasDeProductos(combo As Controles.ComboBox, IdProducto As String)
      With combo
         .DisplayMember = "NombreFormula"
         .ValueMember = "IdFormula"
         .DataSource = New Reglas.ProductosFormulas().GetFormulas(actual.Sucursal.IdSucursal, IdProducto)
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboFormulasDeProductosE(combo As Controles.ComboBox, IdProducto As String)
      With combo
         .DisplayMember = "NombreFormula"
         .ValueMember = "IdFormula"
         .DataSource = New Reglas.ProductosFormulas().GetTodas(actual.Sucursal.IdSucursal, IdProducto)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboProduccionModeloForma(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.ProduccionModeloForma.Columnas.NombreProduccionModeloForma.ToString()
         .ValueMember = Entidades.ProduccionModeloForma.Columnas.IdProduccionModeloForma.ToString()
         .DataSource = New Reglas.ProduccionModelosFormas().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboProduccionModeloFormaVariable(combo As Controles.ComboBox)
      With combo
         .Items.Clear()
         For Each inter In New Reglas.ProduccionModelosFormasVariables().GetDistinctCodigos()
            .Items.Add(inter)
         Next
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposComprobantesMinutas(combo As Controles.ComboBox,
                                       Tipo1 As String,
                                       Optional Tipo2 As String = "",
                                       Optional IdTipoComprobante As String = "")

      Dim oTiposComprobantes As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "IdTipoComprobante"
         .DataSource = oTiposComprobantes.GetMinutas(Eniac.Entidades.Usuario.Actual.Sucursal.Id,
                                                     Tipo1, Tipo2, {IdTipoComprobante}, True)
         .SelectedIndex = -1

      End With

   End Sub

   Public Sub CargaComboGrupos(combo As Controles.ComboBox)
      Dim oRegla As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      With combo
         .DisplayMember = "NombreGrupo"
         .ValueMember = "IdGrupo"
         .DataSource = oRegla.GetGrupos(String.Empty, String.Empty)
         .SelectedIndex = -1
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub
   Public Sub CargaComboGrupos(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean)
      With combo
         .DisplayMember = "NombreGrupo"
         .ValueMember = "IdGrupo"
         Dim lst As List(Of Entidades.Grupo) = New Reglas.TiposComprobantes().GetGruposTodos()
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim oGrupo As Entidades.Grupo = New Entidades.Grupo()
            oGrupo.IdGrupo = Convert.ToInt32(Entidades.Grupo.ValoresFijosGrupos.Todos).ToString()
            oGrupo.NombreGrupo = Publicos.GetEnumString(Entidades.Grupo.ValoresFijosGrupos.Todos)
            lst.Insert(indexPredefinidos, oGrupo)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim oGrupo As Entidades.Grupo = New Entidades.Grupo()
            oGrupo.IdGrupo = Convert.ToInt32(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple).ToString()
            oGrupo.NombreGrupo = Publicos.GetEnumString(Entidades.Grupo.ValoresFijosGrupos.SeleccionMultiple)
            lst.Insert(indexPredefinidos, oGrupo)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboIntereses(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreInteres"
         .ValueMember = "IdInteres"
         .DataSource = New Reglas.Intereses().GetTodos()
         .SelectedIndex = -1
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub

   Public Sub CargaComboProvincias(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreProvincia"
         .ValueMember = "IdProvincia"
         .DataSource = New Reglas.Provincias().GetAll()
         .SelectedIndex = -1
         'If .Items.Count > 0 Then
         '   .SelectedIndex = 0
         'End If
      End With
   End Sub

   Public Sub CargaComboRubrosConceptos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "NombreRubroConcepto"
         .ValueMember = "IdRubroConcepto"
         .DataSource = New Reglas.RubrosConceptos().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboConceptos(combo As Controles.ComboBox, IdProducto As String)
      With combo
         .DisplayMember = "NombreConcepto"
         .ValueMember = "IdConcepto"
         .DataSource = New Reglas.ProductosConceptos().GetConceptos(IdProducto)
         If combo.Items.Count <> 0 Then
            .SelectedIndex = 0
         End If

      End With
   End Sub

   Public Sub CargaComboAdjuntos(combo As Controles.ComboBox, IdProducto As String)
      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "ItemLink"
         .DataSource = New Reglas.ProductosLinks().GetAll(IdProducto)
         If combo.Items.Count <> 0 Then
            .SelectedIndex = 0
         End If

      End With
   End Sub

   Public Sub CargaComboTransportistas(combo As Controles.ComboBox, Optional activos As Boolean? = Nothing)
      With combo
         .DisplayMember = Eniac.Entidades.Transportista.Columnas.NombreTransportista.ToString()
         .ValueMember = Eniac.Entidades.Transportista.Columnas.IdTransportista.ToString()
         Dim lst As List(Of Entidades.Transportista) = New Eniac.Reglas.Transportistas().GetTodos(activos)
         .DataSource = lst
         If lst.Count > 0 Then
            .SelectedIndex = 0
         Else
            .SelectedIndex = -1
         End If
      End With
   End Sub

   Public Sub CargaComboTablerosControlPaneles(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Eniac.Entidades.TableroControlPanel.Columnas.NombrePanel.ToString()
         .ValueMember = Eniac.Entidades.TableroControlPanel.Columnas.IdTableroControlPanel.ToString()
         Dim lst = New Eniac.Reglas.TablerosControlPaneles().GetTodos()
         .DataSource = lst
         If lst.Count > 0 Then
            .SelectedIndex = 0
         Else
            .SelectedIndex = -1
         End If
      End With
   End Sub

   Public Sub CargaComboVersiones(combo As Controles.ComboBox, IdAplicacion As String)
      With combo
         .DisplayMember = Eniac.Entidades.Version.Columnas.NroVersion.ToString()
         .ValueMember = Eniac.Entidades.Version.Columnas.NroVersion.ToString()
         Dim lst As List(Of Entidades.Version) = New Eniac.Reglas.Versiones().GetTodos(IdAplicacion, True)
         .DataSource = lst
         If lst.Count > 0 Then
            .SelectedIndex = 0
         Else
            .SelectedIndex = -1
         End If
      End With
   End Sub

   Public Function CargaComboRangoEnteros(combo As Controles.ComboBox, hasta As Integer) As Eniac.Controles.ComboBox
      Return CargaComboRangoEnteros(combo, desde:=1, hasta:=hasta)
   End Function
   Public Function CargaComboRangoEnteros(combo As Controles.ComboBox, desde As Integer, hasta As Integer) As Eniac.Controles.ComboBox
      Return CargaComboRangoEnteros(combo, desde, hasta, salto:=1)
   End Function

   Public Function CargaComboRangoEnteros(combo As Controles.ComboBox, desde As Integer, hasta As Integer, salto As Integer) As Eniac.Controles.ComboBox

      Dim list As List(Of KeyValuePair(Of Object, String)) = New List(Of KeyValuePair(Of Object, String))()
      For i As Integer = desde To hasta Step salto
         list.Add(New KeyValuePair(Of Object, String)(i, i.ToString()))
      Next

      combo.DataSource = list
      combo.DisplayMember = "Value"
      combo.ValueMember = "Key"

      Return combo
   End Function

   Public Function CargaComboDesdeEnum(combo As Controles.ComboBox, valores As Type,
                                       defaultValue As Object) As Eniac.Controles.ComboBox
      CargaComboDesdeEnum(combo, valores)
      If defaultValue IsNot Nothing Then
         combo.SelectedValue = defaultValue
      End If
      Return combo
   End Function

   Public Function CargaComboDesdeEnum(combo As Controles.ComboBox, defaultValue As [Enum],
                                       Optional ordenar As Boolean = False,
                                       Optional valueAsString As Boolean = False,
                                       Optional hideBrowsable As Boolean = True,
                                       Optional category As String = "") As Eniac.Controles.ComboBox
      Dim type = defaultValue.GetType()
      CargaComboDesdeEnum(combo, type, ordenar, valueAsString, hideBrowsable, category)
      combo.SelectedValue = defaultValue
      Return combo
   End Function
   Public Function CargaComboDesdeEnum(combo As Controles.ComboBox, valores As Type,
                                       Optional ordenar As Boolean = False,
                                       Optional valueAsString As Boolean = False,
                                       Optional hideBrowsable As Boolean = True,
                                       Optional category As String = "") As Eniac.Controles.ComboBox

      Dim enumArray As Array = System.Enum.GetValues(valores)
      If ordenar Then
         Array.Sort(System.Enum.GetNames(valores), enumArray)
      End If

      CargaComboDesdeEnum(combo, enumArray, ordenar, valueAsString, hideBrowsable, category)

      Return combo
   End Function

   Public Sub CargaComboDesdeEnum(combo As Controles.ComboBox, enumArray As Array)
      CargaComboDesdeEnum(combo, enumArray, ordenar:=False, valueAsString:=False, hideBrowsable:=False, category:=String.Empty)
   End Sub
   Public Sub CargaComboDesdeEnum(combo As Controles.ComboBox, enumArray As Array,
                                  ordenar As Boolean, valueAsString As Boolean, hideBrowsable As Boolean,
                                  category As String)
      Dim list As List(Of KeyValuePair(Of Object, String)) = New List(Of KeyValuePair(Of Object, String))()
      For Each item As System.Enum In enumArray
         If String.IsNullOrWhiteSpace(category) Or CheckCategory(item, category) Then
            If CheckBrowsable(item) Or Not hideBrowsable Then
               If valueAsString Then
                  list.Add(New KeyValuePair(Of Object, String)(item.ToString(), GetEnumString(item)))
               Else
                  list.Add(New KeyValuePair(Of Object, String)(item, GetEnumString(item)))
               End If
            End If
         End If
      Next

      combo.DataSource = list
      combo.DisplayMember = "Value"
      combo.ValueMember = "Key"
   End Sub

   Public Sub CargaListBoxDesdeEnum(combo As CheckedListBox, valores As Type, Optional ordenar As Boolean = False, Optional valueAsString As Boolean = False)

      Dim enumArray As Array = System.Enum.GetValues(valores)
      If ordenar Then
         Array.Sort(System.Enum.GetNames(valores), enumArray)
      End If

      Dim list As List(Of KeyValuePair(Of Object, String)) = New List(Of KeyValuePair(Of Object, String))()
      For Each item As System.Enum In enumArray
         If CheckBrowsable(item) Then
            If valueAsString Then
               list.Add(New KeyValuePair(Of Object, String)(item.ToString(), GetEnumString(item)))
            Else
               list.Add(New KeyValuePair(Of Object, String)(item, GetEnumString(item)))
            End If
         End If
      Next

      combo.DataSource = list
      combo.DisplayMember = "Value"
      combo.ValueMember = "Key"
   End Sub

   Public Shared Function EnumToDictionary(valores As Type, Optional ordenar As Boolean = False, Optional valueAsString As Boolean = False) As Dictionary(Of Object, String)
      Dim dict As Dictionary(Of Object, String) = New Dictionary(Of Object, String)()

      Dim enumArray As Array = System.Enum.GetValues(valores)
      If ordenar Then
         Array.Sort(System.Enum.GetNames(valores), enumArray)
      End If

      For Each item As System.Enum In enumArray
         If valueAsString Then
            If CheckBrowsable(item) Then
               dict.Add(item.ToString(), GetEnumString(item))
            Else
               dict.Add(item.ToString(), item.ToString())
            End If
         Else
            If CheckBrowsable(item) Then
               dict.Add(item, GetEnumString(item))
            Else
               dict.Add(item, item.ToString())
            End If
         End If
      Next

      Return dict
   End Function

   Public Sub CargaComboCRMTiposNovedades(combo As Controles.ComboBox, conDinamicos As Entidades.CRMTipoNovedad.TipoDinamico())
      CargaComboCRMTiposNovedades(combo, aplicaSeguridad:=False, idTipoNovedad:=String.Empty, conDinamicos)
   End Sub

   Public Sub CargaComboCRMTiposNovedades(combo As Controles.ComboBox, Optional idTipoNovedad As String = "")
      CargaComboCRMTiposNovedades(combo, aplicaSeguridad:=False, idTipoNovedad:=idTipoNovedad, conDinamicos:={})
   End Sub

   Public Sub CargaComboCRMTiposNovedades(combo As Controles.ComboBox, aplicaSeguridad As Boolean, Optional idTipoNovedad As String = "",
                                          Optional conDinamicos As Entidades.CRMTipoNovedad.TipoDinamico() = Nothing)
      If conDinamicos Is Nothing Then conDinamicos = {}
      With combo
         .DisplayMember = "NombreTipoNovedad"
         .ValueMember = "IdTipoNovedad"
         .DataSource = New Reglas.CRMTiposNovedades().GetTodos(idTipoNovedad, aplicaSeguridad, conDinamicos)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCRMTiposCategoriasNovedades(combo As Controles.ComboBox, idTipoNovedad As String)
      With combo
         .DisplayMember = "NombreTipoCategoriaNovedad"
         .ValueMember = "IdTipoCategoriaNovedad"
         .DataSource = New Reglas.CRMTiposCategoriasNovedades().GetTodos(idTipoNovedad)
         .SelectedIndex = If(combo.Items.Count = 1, 0, -1)
      End With
   End Sub

   Public Sub CargaComboCRMTiposEstadosNovedades(combo As Controles.ComboBox, idTipoNovedad As String)
      With combo
         .DisplayMember = "NombreTipoEstadoNovedad"
         .ValueMember = "IdTipoEstadoNovedad"
         .DataSource = New Reglas.CRMTiposEstadosNovedades().GetTodos(idTipoNovedad)
         .SelectedIndex = If(combo.Items.Count = 1, 0, -1)
      End With
   End Sub

   Public Sub CargaComboCRMMotivosNovedades(combo As Controles.ComboBox, idTipoNovedad As String)
      With combo
         .DisplayMember = Entidades.CRMMotivoNovedad.Columnas.NombreMotivoNovedad.ToString()
         .ValueMember = Entidades.CRMMotivoNovedad.Columnas.IdMotivoNovedad.ToString()
         .DataSource = New Reglas.CRMMotivosNovedades().GetTodos(idTipoNovedad)
         .SelectedIndex = If(combo.Items.Count = 1, 0, -1)
      End With
   End Sub

   Public Sub CargaComboCRMTiposNovedades(combo As ComboBox)
      With combo
         .DisplayMember = Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()
         .ValueMember = Entidades.CRMTipoNovedad.Columnas.IdTipoNovedad.ToString()
         .DataSource = New Reglas.CRMTiposNovedades().GetTodos("")
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCRMMetodoResolucionNovedad(combo As Controles.ComboBox, Optional idTipoNovedad As String = "")
      With combo
         .DisplayMember = Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()
         .ValueMember = Entidades.CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString()
         .DataSource = Reglas.Cache.CRMCacheHandler.Instancia.Metodos.GetTodos(idTipoNovedad).OrderBy(Function(x) x.Posicion).ToList()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboCRMMetodoResolucionNovedad(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean, Optional idTipoNovedad As String = "")
      With combo
         .DisplayMember = "NombreMetodoResolucionNovedad"
         .ValueMember = "IdMetodoResolucionNovedad"
         Dim lst As List(Of Entidades.CRMMetodoResolucionNovedad) = New Reglas.CRMMetodosResolucionesNovedades().GetTodos(idTipoNovedad:=idTipoNovedad, ordenarPosicion:=False)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.CRMMetodoResolucionNovedad = New Entidades.CRMMetodoResolucionNovedad()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdMetodoResolucionNovedad = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreMetodoResolucionNovedad = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.CRMMetodoResolucionNovedad = New Entidades.CRMMetodoResolucionNovedad()
            categ.IdMetodoResolucionNovedad = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreMetodoResolucionNovedad = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboGrupoCategoria(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "IdGrupoCategoria"
         .DataSource = New Reglas.Categorias().GetGrupoCategoria()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboCRMPrioridadesNovedades(combo As Controles.ComboBox, Optional idTipoNovedad As String = "")
      With combo
         .DisplayMember = Entidades.CRMPrioridadNovedad.Columnas.NombrePrioridadNovedad.ToString()
         .ValueMember = Entidades.CRMPrioridadNovedad.Columnas.IdPrioridadNovedad.ToString()
         .DataSource = Reglas.Cache.CRMCacheHandler.Instancia.Prioridades.GetTodos(idTipoNovedad).OrderBy(Function(x) x.Posicion).ToList()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCRMEstadosNovedades(combo As Controles.ComboBox, Optional idTipoNovedad As String = "")
      With combo
         .DisplayMember = Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()
         .ValueMember = Entidades.CRMEstadoNovedad.Columnas.IdEstadoNovedad.ToString()
         .DataSource = Reglas.Cache.CRMCacheHandler.Instancia.Estados.GetTodos(idTipoNovedad).OrderBy(Function(x) x.Posicion).ToList()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboCRMEstadosNovedades(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean, Optional idTipoNovedad As String = "")
      With combo
         .DisplayMember = "NombreEstadoNovedad"
         .ValueMember = "IdEstadoNovedad"
         Dim lst As List(Of Entidades.CRMEstadoNovedad) = New Reglas.CRMEstadosNovedades().GetTodos(idTipoNovedad:=idTipoNovedad, ordenarPosicion:=False)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.CRMEstadoNovedad = New Entidades.CRMEstadoNovedad()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdEstadoNovedad = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreEstadoNovedad = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.CRMEstadoNovedad = New Entidades.CRMEstadoNovedad()
            categ.IdEstadoNovedad = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreEstadoNovedad = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboCRMCategoriasNovedades(combo As Controles.ComboBox, Optional idTipoNovedad As String = "")
      With combo
         .DisplayMember = Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()
         .ValueMember = Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString()
         .DataSource = Reglas.Cache.CRMCacheHandler.Instancia.Categorias.GetTodos(idTipoNovedad).OrderBy(Function(x) x.Posicion).ToList()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboCRMCategoriasNovedades(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean, Optional idTipoNovedad As String = "")
      With combo
         .DisplayMember = "NombreCategoriaNovedad"
         .ValueMember = "IdCategoriaNovedad"
         Dim lst As List(Of Entidades.CRMCategoriaNovedad) = New Reglas.CRMCategoriasNovedades().GetTodos(idTipoNovedad:=idTipoNovedad, ordenarPosicion:=False)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.CRMCategoriaNovedad = New Entidades.CRMCategoriaNovedad()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdCategoriaNovedad = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreCategoriaNovedad = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.CRMCategoriaNovedad = New Entidades.CRMCategoriaNovedad()
            categ.IdCategoriaNovedad = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreCategoriaNovedad = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboCRMMediosComunicacionesNovedades(combo As Controles.ComboBox, Optional idTipoNovedad As String = "")
      With combo
         .DisplayMember = Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString()
         .ValueMember = Entidades.CRMMedioComunicacionNovedad.Columnas.IdMedioComunicacionNovedad.ToString()
         .DataSource = Reglas.Cache.CRMCacheHandler.Instancia.Medios.GetTodos(idTipoNovedad).OrderBy(Function(x) x.Posicion).ToList()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboCRMMediosComunicacionesNovedades(combo As Controles.ComboBox, seleccionMultiple As Boolean, seleccionTodos As Boolean, Optional idTipoNovedad As String = "")
      With combo
         .DisplayMember = "NombreMedioComunicacionNovedad"
         .ValueMember = "IdMedioComunicacionNovedad"
         Dim lst As List(Of Entidades.CRMMedioComunicacionNovedad) = New Reglas.CRMMediosComunicacionesNovedades().GetTodos(idTipoNovedad:=idTipoNovedad, ordenarPosicion:=False)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.CRMMedioComunicacionNovedad = New Entidades.CRMMedioComunicacionNovedad()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdMedioComunicacionNovedad = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreMedioComunicacionNovedad = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.CRMMedioComunicacionNovedad = New Entidades.CRMMedioComunicacionNovedad()
            categ.IdMedioComunicacionNovedad = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreMedioComunicacionNovedad = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCRMClientesInterlocutores(combo As Controles.ComboBox, Optional idCliente As Long = 0)
      With combo
         .Items.Clear()
         For Each inter As Entidades.CRMClienteInterlocutor In New Reglas.CRMClientesInterlocutores().GetTodos(idCliente)
            .Items.Add(inter.Interlocutor)
         Next

         '.DisplayMember = Entidades.CRMClienteInterlocutor.Columnas.Interlocutor.ToString()
         '.ValueMember = Entidades.CRMClienteInterlocutor.Columnas.Interlocutor.ToString()
         '.DataSource = New Reglas.CRMClientesInterlocutores().GetTodos(idCliente)

         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCRMProveedoresInterlocutores(combo As Controles.ComboBox, Optional idProveedor As Long = 0)
      With combo
         .Items.Clear()
         For Each inter As Entidades.CRMProveedorInterlocutor In New Reglas.CRMProveedoresInterlocutores().GetTodos(idProveedor)
            .Items.Add(inter.Interlocutor)
         Next

         '.DisplayMember = Entidades.CRMProveedorInterlocutor.Columnas.Interlocutor.ToString()
         '.ValueMember = Entidades.CRMProveedorInterlocutor.Columnas.Interlocutor.ToString()
         '.DataSource = New Reglas.CRMProveedoresInterlocutores().GetTodos(idCliente)

         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCRMProspectosInterlocutores(combo As Controles.ComboBox, Optional idProspecto As Long = 0)
      With combo
         .Items.Clear()
         For Each inter As Entidades.CRMProspectoInterlocutor In New Reglas.CRMProspectosInterlocutores().GetTodos(idProspecto)
            .Items.Add(inter.Interlocutor)
         Next

         '.DisplayMember = Entidades.CRMProveedorInterlocutor.Columnas.Interlocutor.ToString()
         '.ValueMember = Entidades.CRMProveedorInterlocutor.Columnas.Interlocutor.ToString()
         '.DataSource = New Reglas.CRMProveedoresInterlocutores().GetTodos(idCliente)

         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboProduccionFormas(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.ProduccionForma.Columnas.NombreProduccionForma.ToString()
         .ValueMember = Entidades.ProduccionForma.Columnas.IdProduccionForma.ToString()
         .DataSource = New Reglas.ProduccionFormas().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboProduccionProcesos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.ProduccionProceso.Columnas.NombreProduccionProceso.ToString()
         .ValueMember = Entidades.ProduccionProceso.Columnas.IdProduccionProceso.ToString()
         .DataSource = New Reglas.ProduccionProcesos().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboMotoresDeBaseDeDatos(combo As Controles.ComboBox, ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto)
      With combo
         .DisplayMember = "MotorBaseDatos"
         .ValueMember = "MotorBaseDatos"
         .DataSource = New Reglas.Clientes(ModoClienteProspecto).GetMotoresDeBaseDeDatos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboAFIPTipoDocumento(combo As Controles.ComboBox)
      With combo
         .DisplayMember = "IdNombre"
         .ValueMember = Entidades.AFIPTipoDocumento.Columnas.IdAFIPTipoDocumento.ToString()
         .DataSource = New Reglas.AFIPTiposDocumentos().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub
   Public Sub CargaComboAFIPConceptoCM05(combo As Controles.ComboBox, tipo As Entidades.AFIPConceptoCM05.TiposConceptosCM05?)
      With combo
         .DataSource = New Reglas.AFIPConceptosCM05().GetTodos(tipo)
         .DisplayMember = Entidades.AFIPConceptoCM05.Columnas.DescripcionConceptoCM05.ToString()
         .ValueMember = Entidades.AFIPConceptoCM05.Columnas.IdConceptoCM05.ToString()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboAFIPWSReferenciaTransferencia(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.AFIPReferenciaTransferencia.Columnas.NombreReferenciaTransferencia.ToString()
         .ValueMember = Entidades.AFIPReferenciaTransferencia.Columnas.IdAFIPReferenciaTransferencia.ToString()
         .DataSource = New Reglas.AFIPReferenciasTransferencias().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCalendarios(combo As Controles.ComboBox, idSucursal As Integer)
      With combo
         .DisplayMember = Entidades.Calendario.Columnas.NombreCalendario.ToString()
         .ValueMember = Entidades.Calendario.Columnas.IdCalendario.ToString()
         .DataSource = New Reglas.Calendarios().GetTodos(idSucursal)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCalendariosActivos(combo As Controles.ComboBox, idSucursal As Integer, idUsuario As String)
      With combo
         .DisplayMember = Entidades.Calendario.Columnas.NombreCalendario.ToString()
         .ValueMember = Entidades.Calendario.Columnas.IdCalendario.ToString()
         .DataSource = New Reglas.Calendarios().GetTodosActivos(idSucursal, idUsuario)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCalendariosxUsuario(combo As Controles.ComboBox, idSucursal As Integer, idUsuario As String)
      With combo
         .DisplayMember = "NombreCalendario"
         .ValueMember = "IdCalendario"
         .DataSource = New Reglas.Calendarios().GetCalendariosxUsuario(idSucursal, idUsuario)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboObservaciones(combo As Controles.ComboBox, tipoOperacion As Entidades.Producto.TiposOperaciones)
      Dim tipo As String = ""
      Select Case tipoOperacion
         Case Entidades.Producto.TiposOperaciones.NORMAL
            tipo = "NOTA"
         Case Entidades.Producto.TiposOperaciones.BONIFICACION
            tipo = "BONIF"
         Case Entidades.Producto.TiposOperaciones.CAMBIO
            tipo = "CAMBIO"
         Case Else
      End Select
      If Not String.IsNullOrWhiteSpace(tipo) Then
         CargaComboObservaciones(combo, tipo)
      Else
         combo.Items.Clear()
      End If
   End Sub
   Public Sub CargaComboObservaciones(combo As Controles.ComboBox, tipo As String)
      With combo
         .Items.Clear()
         For Each obs As Entidades.Observacion In New Reglas.Observaciones().GetTodos(tipo)
            .Items.Add(obs.DetalleObservacion)
         Next
         .ValueMember = Entidades.Observacion.Columnas.IdObservacion.ToString()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboRutas(combo As Controles.ComboBox, activa As Boolean?, seleccionMultiple As Boolean, seleccionTodos As Boolean, cargarListaPrecios As Boolean)
      With combo
         .DisplayMember = Entidades.MovilRuta.Columnas.NombreRuta.ToString()
         .ValueMember = Entidades.MovilRuta.Columnas.IdRuta.ToString()
         Dim lst As List(Of Entidades.MovilRuta) = New Reglas.MovilRutas().GetTodos(activa, cargarListaPrecios)
         Dim indexPredefinidos As Integer = 0
         If seleccionTodos Then
            Dim categ As Entidades.MovilRuta = New Entidades.MovilRuta()
            categ.IdSucursal = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.IdRuta = Entidades.Sucursal.ValoresFijosIdSucursal.Todos
            categ.NombreRuta = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         If seleccionMultiple Then
            Dim categ As Entidades.MovilRuta = New Entidades.MovilRuta()
            categ.IdRuta = Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple
            categ.NombreRuta = Publicos.GetEnumString(Entidades.Sucursal.ValoresFijosIdSucursal.SeleccionMultiple)
            lst.Insert(indexPredefinidos, categ)
            indexPredefinidos += 1
         End If
         .DataSource = lst
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargarComboTiposAntecedentes(combo As Controles.ComboBox)
      Dim reg As Reglas.TiposAntecedentes = New Reglas.TiposAntecedentes()
      combo.DataSource = reg.GetTodos()
      combo.ValueMember = Entidades.TipoAntecedente.Columnas.IdTipoAntecedente.ToString()
      combo.DisplayMember = Entidades.TipoAntecedente.Columnas.NombreTipoAntecedente.ToString()
   End Sub



   Public Sub CargaComboVendedoresDelCliente(combo As Controles.ComboBox, idCliente As Long)
      With combo
         .DisplayMember = "NombreEmpleado"
         .ValueMember = "NroDocEmpleado"
         .DataSource = New Reglas.Empleados().GetVendedoresDelCliente(idCliente)
         If .Items.Count > 0 Then
            .SelectedIndex = 0
         End If
      End With
   End Sub

   Public Sub CargaComboEstadosVenta(combo As Controles.ComboBox)
      Dim oRegPagos As Reglas.RegistracionPagos = New Reglas.RegistracionPagos

      With combo
         .DisplayMember = "NombreEstadoVenta"
         .ValueMember = "idEstadoVenta"
         .DataSource = oRegPagos.getMotivos()
         .SelectedIndex = 0
      End With

   End Sub

   Public Sub CargaComboEstadosVehiculo(combo As Controles.ComboBox)
      Dim regla = New Reglas.EstadosVehiculos()
      With combo
         .DisplayMember = Entidades.EstadoVehiculo.Columnas.NombreEstadoVehiculo.ToString()
         .ValueMember = Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculo.ToString()
         .DataSource = regla.GetTodos()
         .SelectedIndex = 0

         Dim estados = regla.GetTodos()
         Dim defEsta = estados.FirstOrDefault(Function(e) e.Predeterminado)
         'If defEsta IsNot Nothing Then
         '   .SelectedItem = defEsta
         'Else
         '   .SelectedIndex = 0
         'End If
      End With
   End Sub

   '-.PE-31892.-
   Public Sub CargaComboNacionalidades(combo As Controles.ComboBox)
      Dim oNac As Reglas.Nacionalidades = New Reglas.Nacionalidades

      With combo
         .DisplayMember = "NombreNacionalidad"
         .ValueMember = "IdNacionalidad"
         .DataSource = oNac.GetTodas()
         .SelectedIndex = 0
      End With
   End Sub
#End Region

#Region "Metodos Publicos"

   Public Sub ValidaCarpetaEniac()
      If Not System.IO.Directory.Exists(Entidades.Publicos.CarpetaEniac) Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.CarpetaEniac)
      End If
      If Not System.IO.Directory.Exists(Entidades.Publicos.CarpetaLOGs) Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.CarpetaLOGs)
      End If
      If Not System.IO.Directory.Exists(Entidades.Publicos.CarpetaEniac + "eFact\") Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.CarpetaEniac + "eFact\")
      End If
      If Not System.IO.Directory.Exists(Entidades.Publicos.CarpetaEniac + "eFact\Exportaciones\") Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.CarpetaEniac + "eFact\Exportaciones\")
      End If
      If Not System.IO.Directory.Exists(Entidades.Publicos.CarpetaEniac + "Correos\") Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.CarpetaEniac + "Correos\")
      End If

      'Los PDFs de Factura Electronica.
      Dim PathPDFs As String = New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.UBICACIONPDFSFE.ToString(), "C:\ENIAC\AFIP\COMPROBANTES")
      If Not String.IsNullOrEmpty(PathPDFs) AndAlso Not System.IO.Directory.Exists(PathPDFs) Then
         Try
            System.IO.Directory.CreateDirectory(PathPDFs)
         Catch ex As Exception
            MessageBox.Show("ATENCION: No se puede leer o crear la carpeta de los PDFs: " & PathPDFs, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End Try
      End If

   End Sub

   Public Function GetCodigoBarrasFE(cuit As Decimal,
                                    idTipoComprobanteAFIP As Integer,
                                    puntoDeVenta As Integer,
                                    CAE As String,
                                    CAEFechaVencimiento As DateTime) As String
      Dim cadenaPura As String = String.Empty
      Dim inicioError As String = "Error en la obtención del Código de Barras. "

      Dim cuitSTR As String = cuit.ToString()
      If cuitSTR.Length <> 11 Then
         Throw New Exception(inicioError + "El CUIT no es valido.")
      End If
      Dim idTipoComprobanteAFIPSTR As String = idTipoComprobanteAFIP.ToString("00")
      Dim puntoDeVentaSTR As String = puntoDeVenta.ToString("0000")
      If CAE.Length <> 14 Then
         Throw New Exception(inicioError + "El CAE no es valido.")
      End If
      Dim CAEFechaVencimientoSTR As String = CAEFechaVencimiento.ToString("ddMMyyyy")

      cadenaPura = cuitSTR + idTipoComprobanteAFIPSTR + puntoDeVentaSTR + CAE + CAEFechaVencimientoSTR

      Dim digitoVerificador As Integer = 0
      Dim resultadoFinal As Integer = 0

      'Suma Impares y Pares 
      Dim cara() As Char = cadenaPura.ToCharArray()
      Dim res As Integer = 0
      Dim pares As Integer = 0
      Dim impares As Integer = 0
      Dim numero As Integer = 0
      Dim posicion_1 As Integer = 0
      For posicion As Integer = 0 To 38
         numero = Integer.Parse(cara(posicion))
         posicion_1 += 1
         Math.DivRem(posicion_1, 2, res)
         If res = 0 Then
            pares += numero
         Else
            impares += numero
         End If
      Next

      resultadoFinal = (pares * 3) + impares

      Dim ultimoDigito As Integer = Integer.Parse(resultadoFinal.ToString().Substring(resultadoFinal.ToString().Length - 1, 1))

      If ultimoDigito < 5 Then
         digitoVerificador = ultimoDigito
      Else
         digitoVerificador = 10 - ultimoDigito
      End If

      cadenaPura += Math.Abs(digitoVerificador).ToString()

      Return cadenaPura

   End Function

   Public Shared Function NormalizarNombreArchivo(textoOriginal As String) As String
      Return Reglas.Publicos.NormalizarNombreArchivo(textoOriginal)
   End Function
   Public Shared Function NormalizarDescripcion(textoOriginal As String) As String
      Return Reglas.Publicos.NormalizarDescripcion(textoOriginal)
   End Function

   Public Shared Function EsCuitValido(CUIT As String) As Boolean
      Return Reglas.Publicos.EsCuitValido(CUIT)
   End Function

   Public Shared Function EsCBUValido(cbu As Decimal) As Boolean
      'Las cuentas bancarias en Argentina se identifican por un número de CBU 
      '(Clave Bancaria Uniforme), formado por 22 dígitos, divididos en dos bloques. 
      'El primer bloque, formado por 8 dígitos, identifica al banco y sucursal, 
      'mientras que el segundo bloque, formado por los restantes 13 dígitos, 
      'identifica la cuenta bancaria. 
      'El último dígito de cada bloque es el dígito verificador del mismo según el 
      'algoritmo clave 10 con ponderador 9713. 

      Dim strCBU As String = cbu.ToString()

      Do While strCBU.Length < 22
         strCBU = "0" + strCBU
      Loop

      'Validación 1º bloque 
      Dim suma As Integer = 0
      Dim diferencia As Integer = 0

      suma = (Integer.Parse(strCBU.Chars(0)) * 7) +
               (Integer.Parse(strCBU.Chars(1)) * 1) +
               (Integer.Parse(strCBU.Chars(2)) * 3) +
               (Integer.Parse(strCBU.Chars(3)) * 9) +
               (Integer.Parse(strCBU.Chars(4)) * 7) +
               (Integer.Parse(strCBU.Chars(5)) * 1) +
               (Integer.Parse(strCBU.Chars(6)) * 3)

      diferencia = 10 - Integer.Parse(suma.ToString().Substring(suma.ToString().Length - 1))
      If diferencia <> Integer.Parse(strCBU.Chars(7)) Then
         Return False
      End If

      suma = 0
      suma = (Integer.Parse(strCBU.Chars(8)) * 3) +
               (Integer.Parse(strCBU.Chars(9)) * 9) +
               (Integer.Parse(strCBU.Chars(10)) * 7) +
               (Integer.Parse(strCBU.Chars(11)) * 1) +
               (Integer.Parse(strCBU.Chars(12)) * 3) +
               (Integer.Parse(strCBU.Chars(13)) * 9) +
               (Integer.Parse(strCBU.Chars(14)) * 7) +
               (Integer.Parse(strCBU.Chars(15)) * 1) +
               (Integer.Parse(strCBU.Chars(16)) * 3) +
               (Integer.Parse(strCBU.Chars(17)) * 9) +
               (Integer.Parse(strCBU.Chars(18)) * 7) +
               (Integer.Parse(strCBU.Chars(19)) * 1) +
               (Integer.Parse(strCBU.Chars(20)) * 3)

      diferencia = 10 - Integer.Parse(suma.ToString().Substring(suma.ToString().Length - 1))
      If diferencia <> Integer.Parse(strCBU.Chars(21)) Then
         Return False
      End If

      Return True
   End Function

   Public Class InformacionPC
      ''' <summary>
      ''' Obtiene el Numero de Serie de la Placa Madre.-
      ''' </summary>
      ''' <returns></returns>
      Public Shared Function GetSerialMotherboard() As String
         Dim serial As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_BaseBoard")
         Dim serialBoard As String = ""
         For Each serialB As ManagementObject In serial.Get()
            serialBoard = (serialB.GetPropertyValue("SerialNumber").ToString)
         Next
         Return serialBoard
      End Function
      ''' <summary>
      ''' Obtiene el numero de Serie del Disco Principal.
      ''' </summary>
      ''' <returns></returns>
      Public Shared Function GetSerialNumberDiscosPrimario() As String
         Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
         Return serialDD.Properties("SerialNumber").Value.ToString
      End Function
      ''' <summary>
      ''' Obtiene la resolucion de la pantalla principal(devuelve Ancho * Alto).
      ''' </summary>
      ''' <returns></returns>
      Public Shared Function GetResolucionPantalla() As String
         Dim pantalla As System.Windows.Forms.Screen = System.Windows.Forms.Screen.PrimaryScreen
         Return pantalla.Bounds.Width.ToString() + " x " + pantalla.Bounds.Height.ToString()
      End Function

      Public Shared Function GetVersionFramework() As String
         Dim subkey = "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"
         Dim ndpKey = Registry.LocalMachine.OpenSubKey(subkey)
         Return ndpKey.GetValue("Version").ToString()
      End Function


      Public Shared Function GetMACPCLocal() As String
         Dim nics() As Net.NetworkInformation.NetworkInterface = Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
         Dim stb As StringBuilder = New StringBuilder()
         Dim ctrl As Dictionary(Of String, String) = New Dictionary(Of String, String)()
         For Each nic As System.Net.NetworkInformation.NetworkInterface In nics
            Dim valor As String = nic.GetPhysicalAddress().ToString()
            If Not String.IsNullOrWhiteSpace(valor) Then
               If Not ctrl.ContainsKey(valor) Then
                  stb.AppendFormat("{0};", valor)
                  ctrl.Add(valor, valor)
               End If
            End If
         Next
         Return stb.ToString().Trim(";"c)
      End Function

      Public Shared Function GetSerialNumberDiscos() As String
         Dim query As New Management.ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")
         Dim queryCollection As Management.ManagementObjectCollection = query.Get()
         Dim mo As Management.ManagementObject

         Dim strSN As StringBuilder = New StringBuilder()
         For Each mo In queryCollection
            Dim dato As Object = mo("SerialNumber")
            If dato IsNot Nothing Then
               strSN.AppendFormat("{0};", dato.ToString().Trim())
            End If
         Next
         Return strSN.ToString().Trim(";"c)
      End Function

      Public Shared Function GetSistemaOperativo() As String
         Dim query As New Management.ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")
         Dim queryCollection As Management.ManagementObjectCollection = query.Get()
         Dim mo As Management.ManagementObject

         Dim strSN As StringBuilder = New StringBuilder()
         For Each mo In queryCollection
            Dim caption As String = mo("Caption").ToString()
            If caption Is Nothing Then
               caption = String.Empty
            Else
               caption = caption.Replace("Microsoft Windows", "")
               caption = caption.Replace("Server", "")
            End If
            'Dim version As String = mo("Version").ToString()
            'If version Is Nothing Then version = String.Empty
            'strSN.AppendFormat("{0} ({1});", caption.Trim(), Version.Trim())
            strSN.AppendFormat("{0};", caption.Trim())

         Next
         Return strSN.ToString().Trim(";"c)
      End Function


      Public Shared Function GetArquitecturaSistemaOperativo() As String
         Return If(Environment.Is64BitOperatingSystem, "64 b", "32 b")
      End Function
   End Class

   Public Sub CargarSucursalesACheckListBox(clb As Eniac.Controles.CheckedListBox)
      Dim lis As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetTodas(False)

      clb.Items.Clear()

      For Each suc As Entidades.Sucursal In lis
         clb.Items.Add(suc)
         'Marco en forma predeterminada la Sucursal donde estoy parado. 
         'Ahorra trabajo, sobre todo si solo hay 1, tiene mas sentido.
         If suc.Id = Eniac.Entidades.Usuario.Actual.Sucursal.Id Then
            clb.SetItemChecked(clb.Items.Count - 1, True)
         End If
      Next
   End Sub

   Public Shared Function CheckBrowsable(value As System.Enum) As Boolean
      Dim fi As FieldInfo = value.GetType().GetField(value.ToString())
      Dim attributes As BrowsableAttribute() = DirectCast(fi.GetCustomAttributes(GetType(BrowsableAttribute), False), BrowsableAttribute())
      If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
         Return attributes(0).Browsable
      Else
         Return True
      End If
   End Function
   Public Shared Function CheckCategory(value As System.Enum, category As String) As Boolean
      Dim fi As FieldInfo = value.GetType().GetField(value.ToString())
      Dim attributes = DirectCast(fi.GetCustomAttributes(GetType(CategoryAttribute), False), CategoryAttribute())
      If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
         Return attributes(0).Category = category
      Else
         Return True
      End If
   End Function

   Public Shared Function GetEnumString(value As System.Enum) As String
      Dim fi As FieldInfo = value.GetType().GetField(value.ToString())
      Dim attributes As DescriptionAttribute() = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
      If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
         Return attributes(0).Description
      Else
         Return value.ToString()
      End If
   End Function
#End Region

#Region "Propiedades Shared ReadOnly"

   Public Shared ReadOnly Property VersionDB() As String
      Get
         Return Reglas.Publicos.VersionDB
      End Get
   End Property

   <Obsolete("Usar el de la regla.")>
   Public Shared ReadOnly Property PreciosConIVA() As Boolean
      Get
         Return Reglas.Publicos.PreciosConIVA
      End Get
   End Property

   <Obsolete("Usar el de la regla.")>
   Public Shared ReadOnly Property ConsultarPreciosConIVA() As Boolean
      Get
         Return Reglas.Publicos.ConsultarPreciosConIVA   ' Boolean.Parse(New Reglas.Parametros().GetValorPD("ConsultarPreciosConIVA", Boolean.TrueString))
      End Get
   End Property

   <Obsolete("Usar el de Reglas.Publicos.NombreEmpresaImpresion")>
   Public Shared ReadOnly Property NombreEmpresaImpresion() As String
      Get
         Return Reglas.Publicos.NombreEmpresaImpresion
      End Get
   End Property

   Public Shared ReadOnly Property NombreBaseARBA() As String
      Get
         Dim val As String = New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.NOMBREBASEARBA.ToString(), "")
         If String.IsNullOrEmpty(val) Then
            Return Ayudantes.Conexiones.Base
         Else
            Return val
         End If
      End Get
   End Property

   Public Shared ReadOnly Property CalidadBaseExternaClientes() As String
      Get
         Return Reglas.Publicos.CalidadBaseExternaClientes()
      End Get
   End Property

   <Obsolete("Usar el de reglas")>
   Public Shared ReadOnly Property CategoriaFiscalEmpresa() As Short
      Get
         Return Reglas.Publicos.CategoriaFiscalEmpresa
      End Get
   End Property

   <Obsolete("Usar el de reglas")>
   Public Shared ReadOnly Property CuitEmpresa() As String
      Get
         Return Reglas.Publicos.CuitEmpresa ' New Reglas.Parametros().GetValorPD("CUITEMPRESA", "")
      End Get
   End Property

   Public Shared ReadOnly Property LocalidadEmpresa() As Integer
      Get
         Return New Reglas.Sucursales().GetSoyLaCentral(False).Localidad.IdLocalidad
      End Get
   End Property

   Public Shared Property NroHojaLibroIvaVentas() As Integer
      Get
         Return Integer.Parse(New Reglas.Parametros().GetValorPD("NroHojaLibroIvaVentas", "0"))
      End Get
      Set(value As Integer)
         Dim oParam As New Reglas.Parametros()
         oParam.SetValor(actual.Sucursal.IdEmpresa, "NroHojaLibroIvaVentas", value.ToString())
      End Set
   End Property

   Public Shared Function GetSistema() As Entidades.Sistema
      Return GetSistema(actual.Sucursal.IdEmpresa)
   End Function
   Public Shared Function GetSistema(idEmpresa As Integer) As Entidades.Sistema
      Return New Reglas.Parametros().GetSistema(idEmpresa)
   End Function

   <Obsolete("Usar el de la regla.")>
   Public Shared ReadOnly Property IdTicketFiscal() As String
      Get
         Return Reglas.Publicos.IdTicketFiscal
      End Get
   End Property

   Public Shared ReadOnly Property IdNotaDebitoChequeRechazado(IdTipoComprobante As String) As Boolean
      Get

         Dim strComprobantesNDCheqRechazado As String
         Dim blnComprobantesNDCheqRechazado As Boolean = False

         strComprobantesNDCheqRechazado = New Reglas.Parametros().GetValorPD("NDebCheqRech", "COTIZCHEQRECH,NDEBCHEQRECH,ePRE-NDEBCHEQR,eNDEBCHEQRECH")
         Dim arrComprobantes() As String = {}

         arrComprobantes = strComprobantesNDCheqRechazado.Split(","c)

         For i As Integer = 0 To arrComprobantes.Length - 1
            If arrComprobantes(i) = IdTipoComprobante Then
               blnComprobantesNDCheqRechazado = True
               Exit For
            End If
         Next

         Return blnComprobantesNDCheqRechazado

      End Get
   End Property


   Public Shared ReadOnly Property IdNotaDebitoGrabaLibro() As String
      Get
         Return New Reglas.Parametros().GetValorPD("IDNDEBGL", "NDEB")
      End Get
   End Property

   Public Shared ReadOnly Property IdNotaDebitoNoGrabaLibro() As String
      Get
         Return New Reglas.Parametros().GetValorPD("IDNDEBNOGL", "NDEB-COTIZACION")
      End Get
   End Property

   Public Shared ReadOnly Property IdNotaCreditoGrabaLibro() As String
      Get
         Return New Reglas.Parametros().GetValorPD("IDNCREDGL", "NCRED")
      End Get
   End Property

   Public Shared ReadOnly Property IdNotaCreditoNoGrabaLibro() As String
      Get
         Return New Reglas.Parametros().GetValorPD("IDNCREDNOGL", "DEV-COTIZACION")
      End Get
   End Property

   Public Shared ReadOnly Property CodigoAutorizacionWS() As String
      Get
         Return New Reglas.Parametros().GetValorPD("CodigoAutorizaWS", String.Empty)
      End Get
   End Property

   Public Shared ReadOnly Property VisualizaComprobantesDeVenta() As Boolean
      Get
         Return (New Reglas.Parametros().GetValorPD("VisualizaComprobantesDeVenta", "SI").ToUpper() = "SI")
      End Get
   End Property

   Public Shared ReadOnly Property VisualizaComprobantesDeCompra() As Boolean
      Get
         Return (New Reglas.Parametros().GetValorPD("VisualizaComprobantesDeCompra", "NO").ToUpper() = "SI")
      End Get
   End Property
   <Obsolete("Usar de las Reglas")>
   Public Shared ReadOnly Property LoteSolicitaFechaVencimiento() As Boolean
      Get
         Return Reglas.Publicos.LoteSolicitaFechaVencimiento
      End Get
   End Property

   Public Shared ReadOnly Property LoteSolicitaDespachoImportacion() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.LOTESOLICITADESPACHOIMPORTACION.ToString(), Boolean.FalseString))
      End Get
   End Property

   Public Shared ReadOnly Property ActualizarPreciosCalculo() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.ACTUALIZARPRECIOSCALCULO.ToString(), "VENTA")
      End Get
   End Property

   Public Shared ReadOnly Property ValorPorDefectoEnResumenDeVentas() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.VALORPORDEFECTOENRESUMENDEVENTAS.ToString(), "PorPeriodoFiscal")
      End Get
   End Property

   Public Shared ReadOnly Property ComprasPermiteFechaMayorHoy() As Boolean
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.COMPRASPERMITEFECHAMAYORHOY.ToString(), Boolean.FalseString).ToUpper() = Boolean.TrueString.ToUpper()
      End Get
   End Property

   Public Shared ReadOnly Property FacturacionMantieneElCliente() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMANTIENECLIENTE.ToString(), "False"))
      End Get
   End Property

   Public Shared ReadOnly Property FacturacionMantieneElClienteDefault() As Long
      Get
         Return Long.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMANTIENEELCLIENTEDEFAULT.ToString(), "0"))
      End Get
   End Property

   Public Shared ReadOnly Property FacturacionMantieneElComprobante() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONMANTIENECOMPROBANTE.ToString(), "False"))
      End Get
   End Property
   Public Shared ReadOnly Property PermitirMovimientoCajasSinSaldo() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CAJAPERMITIRMOVSINSALDO.ToString(), "False"))
      End Get
   End Property

   Public Shared ReadOnly Property PagoProvConciliaAutomaticamenteTransferencias() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PAGOPROVCONCILIAAUTOMATICAMENTETRANSFERENCIAS.ToString(), Boolean.FalseString))
      End Get
   End Property

   <Obsolete("Usar el de reglas")>
   Public Shared ReadOnly Property ExtrasSinergia() As Boolean
      Get
         Return Reglas.Publicos.ExtrasSinergia
      End Get
   End Property

   Public Shared ReadOnly Property ClienteDRporGrabaLibro() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD("CLIENTEDRGRABALIBRO", "True"))
      End Get
   End Property
   <Obsolete("Usar el de reglas")>
   Public Shared ReadOnly Property ClienteUtilizaCBU() As Boolean
      Get
         Return Reglas.Publicos.ClienteUtilizaCBU
      End Get
   End Property

   Public Shared ReadOnly Property ClientesCantidadVisitasPordefecto() As Integer
      Get
         Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CLIENTESCANTIDADVISITASPORDEFECTO, "0"))
      End Get
   End Property

   Public Shared ReadOnly Property ClienteTieneGarante() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD("ClienteTieneGarante", Boolean.FalseString))
      End Get
   End Property

   Public Shared ReadOnly Property ProductoTieneModelo() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD("ProductoTieneModelo", "False"))
      End Get
   End Property

   Public Shared ReadOnly Property ProductoIVA() As Decimal
      Get
         Return Decimal.Parse(New Reglas.Parametros().GetValorPD("ProductoIVA", "21"))
      End Get
   End Property

   <Obsolete("Usar el de reglas")>
   Public Shared ReadOnly Property ProductoUtilizaAlicuota2() As Boolean
      Get
         Return Reglas.Publicos.ProductoUtilizaAlicuota2
      End Get
   End Property

   Public Shared ReadOnly Property ProductoUtilizaCodigoDeBarras() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD("ProductoUtilizaCodigoDeBarras", "True"))
      End Get
   End Property

   Public Shared ReadOnly Property ProductoCodigoBarraPrecioRespetaEtiqueta() As Boolean
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PRODUCTOCODIGOBARRAPRECIORESPETAETIQUETA.ToString(), Boolean.FalseString) = Boolean.TrueString
      End Get
   End Property

   <Obsolete("Usar el de reglas")>
   Public Shared ReadOnly Property UtilizaPrecioDeCompra() As Boolean
      Get
         Return Reglas.Publicos.UtilizaPrecioDeCompra
      End Get
   End Property

   Public Shared ReadOnly Property UnificaLibrosDeBanco() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.UNIFICALIBROSDEBANCO.ToString(), Boolean.FalseString))
      End Get
   End Property

   '<Obsolete("Usar el de reglas")>
   'Public Shared ReadOnly Property TareasPorUsuario() As Boolean
   '   Get
   '      Return Reglas.Publicos.TareasPorUsuario
   '   End Get
   'End Property

   'Public Shared ReadOnly Property ControlaLimiteDeCreditoDeClientes() As Boolean
   '   Get
   '      Return Boolean.Parse(New Reglas.Parametros().GetValor("CONTROLALIMITEDECREDITODECLIENTES"))
   '   End Get
   'End Property
   Public Shared ReadOnly Property ControlaEventosdeLimiteDeCreditoDeClientes() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONTROLAEVENTOSDELIMITEDECREDITODECLIENTES.ToString, "Avisar y Permitir")
      End Get
   End Property
   Public Shared ReadOnly Property ControlaDiasVtoDeCreditoDeClientes() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONTROLADIASVTODECREDITODECLIENTES, "Avisar y Permitir")
      End Get
   End Property

   Public Shared ReadOnly Property PedidosControlaEventosdeLimiteDeCreditoDeClientes() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSCONTROLAEVENTOSDELIMITEDECREDITODECLIENTES.ToString, "Avisar y Permitir")
      End Get
   End Property
   Public Shared ReadOnly Property PedidosControlaDiasVtoDeCreditoDeClientes() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSCONTROLADIASVTODECREDITODECLIENTES, "Avisar y Permitir")
      End Get
   End Property

   Public Shared ReadOnly Property ServiceImprime1copiaNR() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD("SERVICEIMPRIMEUNACOPIANR", "False"))
      End Get
   End Property

   Public Shared ReadOnly Property VentasPrecioCosto() As String
      Get
         Return New Reglas.Parametros().GetValorPD("VENTASPRECIOCOSTO", "ACTUAL")
      End Get
   End Property

   Public Shared ReadOnly Property VentasPrecioVenta() As String
      Get
         Return New Reglas.Parametros().GetValorPD("VENTASPRECIOVENTA", "ACTUAL")
      End Get
   End Property

   <Obsolete("Usar el de reglas")>
   Public Shared ReadOnly Property TieneModuloContabilidad() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.MODULOCONTABILIDAD.ToString(), Boolean.FalseString))
      End Get
   End Property

   Public Shared ReadOnly Property FacturacionIgnorarPCdeCaja() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONIGNORARPCDECAJA.ToString(), "False"))
      End Get
   End Property

   Public Shared ReadOnly Property FacturacionInformeVentasAfectaCajaSI() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONINFORMEVENTASSI.ToString(), "False"))
      End Get
   End Property

   ''Public Shared ReadOnly Property ComprasIgnorarPCdeCaja() As Boolean
   ''   Get
   ''      Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.COMPRASIGNORARPCDECAJA.ToString(), "False"))
   ''   End Get
   ''End Property

   ''Public Shared ReadOnly Property PagoImprimeSaldo() As Boolean
   ''   Get
   ''      Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PAGOIMPRIMESALDO.ToString(), "True"))
   ''   End Get
   ''End Property

   'Public Shared ReadOnly Property ProduccionRecetaUnica() As Boolean
   '   Get
   '      Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PRODUCCIONRECETAUNICA.ToString(), "False"))
   '   End Get
   'End Property

   ''Public Shared ReadOnly Property ConsultarPreciosConEmbalaje() As Boolean
   ''   Get
   ''      Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONSULTARPRECIOSCONEMBALAJE.ToString(), "False"))
   ''   End Get
   ''End Property

   ''Public Shared ReadOnly Property ImportarProductosGeneraHistorialPrecios() As Boolean
   ''   Get
   ''      Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.IMPORTARPRODUCTOSGENERAHISTORIALPRECIOS.ToString(), "False"))
   ''   End Get
   ''End Property

   'Public Shared ReadOnly Property MercaderiaDespachada() As Boolean
   '   Get
   '      Return Boolean.Parse(New Reglas.Parametros().GetValor("TILDEMERCDESPACHADA"))
   '   End Get
   'End Property

   'Public Shared ReadOnly Property FactPorCtaOrden() As Boolean
   '   Get
   '      Return Boolean.Parse(New Reglas.Parametros().GetValor("FACTURACIONPORCUENTAYORDEN"))
   '   End Get
   'End Property

   'Public Shared ReadOnly Property FacturacionRemitoTranspUtilizaLote() As Boolean
   '   Get
   '      Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONREMITOTRANSPUTILIZALOTE.ToString(), "True"))
   '   End Get
   'End Property

   'Public Shared ReadOnly Property FacturacionRemitoTranspCalculaBultos() As Boolean
   '   Get
   '      Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONREMITOTRANSPCALCULABULTOS.ToString(), "True"))
   '   End Get
   'End Property

   <Obsolete("Usar el método de reglas")>
   Public Shared ReadOnly Property DescuentoMaximo() As Decimal
      Get
         Return Reglas.Publicos.Facturacion.DescuentoMaximo ' Decimal.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.DESCUENTOMAXIMO.ToString(), "0"))
      End Get
   End Property

   Public Shared ReadOnly Property PedidosVisualiza() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSVISUALIZA.ToString(), "True"))
      End Get
   End Property

   <Obsolete("Usar las Reglas")>
   Public Shared ReadOnly Property PedidosPermiteFechaEntregaDistintas() As Boolean
      Get
         Return Reglas.Publicos.PedidosPermiteFechaEntregaDistintas
      End Get
   End Property


   <Obsolete("Usar las Reglas", True)>
   Public Shared ReadOnly Property GenerarPedidosStockSeleccionaTrue() As Boolean
      Get
         Return Reglas.Publicos.GenerarPedidosStockSeleccionaTrue    ' New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.GENERARPEDIDOSSTOCKSELECCIONATRUE.ToString(), Boolean.TrueString) = Boolean.TrueString
      End Get
   End Property
   Public Shared ReadOnly Property GenerarPedidosProveedorDesdeStockModificaPrecioCosto() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.GENERAPEDIDOPROVEEDORDESDESTOCKMODIFICAPRECIOCOSTO.ToString(), Boolean.FalseString))
      End Get
   End Property

   Public Shared ReadOnly Property ProductoEmbalajeHaciaArriba() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PRODUCTOUTILIZAEMBALAJEARRIBA.ToString(), "False"))
      End Get
   End Property
   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property ProductoPermiteEsCambiable() As Boolean
      Get
         Return Reglas.Publicos.ProductoPermiteEsCambiable
      End Get
   End Property
   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property ProductoPermiteEsBonificable() As Boolean
      Get
         Return Reglas.Publicos.ProductoPermiteEsBonificable
      End Get
   End Property

   Public Shared ReadOnly Property ProductoCodigoNumerico() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PRODUCTOCODIGONUMERICO.ToString(), "False"))
      End Get
   End Property

   Public Shared ReadOnly Property VisualizaPagoAProveedor() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.VISUALIZAPAGOAPROVEEDOR.ToString(), "True"))
      End Get
   End Property

   <Obsolete("Usar la propiedad de reglas")>
   Public Shared ReadOnly Property FacturacionPermiteCantidadNegativa() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONPERMITECANTIDADNEGATIVA.ToString(), "False"))
      End Get
   End Property

   <Obsolete("Usar la propiedad de reglas")>
   Public Shared ReadOnly Property FacturacionPermitePosicionarNombreProducto() As Boolean
      Get
         Return Reglas.Publicos.Facturacion.FacturacionPermitePosicionarNombreProducto
      End Get
   End Property

   Public Shared ReadOnly Property FacturacionAvisaProductosEnCero() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONAVISAPRODUCTOSENCERO.ToString(), "True"))
      End Get
   End Property

   Public Shared ReadOnly Property FacturacionCargarReciboLuegoNC() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONCARGARECIBOLUEGONC.ToString(), "True"))
      End Get
   End Property

   <Obsolete("Usar el de reglas")>
   Public Shared ReadOnly Property FacturacionSeleccionManualLoteProducto() As Boolean
      Get
         Return Reglas.Publicos.Facturacion.FacturacionSeleccionManualLoteProducto
      End Get
   End Property

   Public Shared ReadOnly Property FacturacionDiasInvocacionComprobantes() As Integer
      Get
         Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDIASINVOCACIONCOMPROBANTES.ToString(), "7"))
      End Get
   End Property

   Public Shared ReadOnly Property FacturacionGrabaLibroNoFuerzaConsFinal() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONGRABALIBRONOFUERZACONSFINAL.ToString(), "False"))
      End Get
   End Property

   Public Shared ReadOnly Property EstadoPedidoPendiente() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSESTADOAREMITIR.ToString(), "PENDIENTE")
      End Get
   End Property

   Public Shared ReadOnly Property ProductoUtilizaNombreCorto() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PRODUCTOUTILIZANOMBRECORTO.ToString(), "False"))
      End Get
   End Property

   Public Shared ReadOnly Property ProduccionDescStockComponentesFormulasFacturacion() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PRODUCCIONDESCUENTAPRODFORMULAFACTURAR.ToString(), "False"))
      End Get
   End Property

   Public Shared ReadOnly Property NombreLogo() As String
      Get
         Return Reglas.Publicos.NombreLogo
      End Get
   End Property

   Public Shared ReadOnly Property Logo(sucursal As Entidades.Sucursal) As System.Drawing.Image
      Get
         Return Reglas.Publicos.Logo(sucursal)
      End Get
   End Property

   Public Shared ReadOnly Property VisualizarComprobanteVentaAsumeImpresion() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.VisualizarComprobanteVentaAsumeImpresion.ToString(), "True"))
      End Get
   End Property

   Public Shared ReadOnly Property PedidosPendientesFacturaAutomaticamente() As Boolean
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSFACTURARAUTOMATICO.ToString(), Boolean.FalseString) = Boolean.TrueString
      End Get
   End Property

   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property EnviaMailComprobanteElectronico() As Boolean
      Get
         Return Reglas.Publicos.EnviaMailComprobanteElectronico
      End Get
   End Property

   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property TieneModuloExpensas() As Boolean
      Get
         Return Reglas.Publicos.TieneModuloExpensas
      End Get
   End Property

   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property PasajeComprasIncluyeImpuestos() As Boolean
      Get
         Return CBool(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.EXPENSASPASAJECOMPRASINCLUYEIMPUESTOS, Boolean.TrueString))
      End Get
   End Property

   <Obsolete("Usar el de reglas")>
   Public Shared ReadOnly Property PreciosDecimalesEnVenta() As Integer
      Get
         Return Reglas.Publicos.PreciosDecimalesEnVenta
      End Get
   End Property

   <Obsolete("Usar el método de Reglas")>
   Public Shared ReadOnly Property MinutosTableroComando As Decimal
      Get
         Return Reglas.Publicos.MinutosTableroComando
      End Get
   End Property

   ''''Public Shared ReadOnly Property URLActualizacion() As String
   ''''   Get
   ''''      Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.URLACTUALIZADOR.ToString(), "http://www.sinergiatest.com.ar/WSActualizador.svc")
   ''''   End Get
   ''''End Property

   '''''-- REQ-33689.- ------------------------------------------------------------------------------------------------------------------
   ''''Public Shared ReadOnly Property URLPathDescargaMSI() As String
   ''''   Get
   ''''      Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.UBICACIONMSI.ToString(), "D:\Eniac\Instaladores")
   ''''   End Get
   ''''End Property
   '''''---------------------------------------------------------------------------------------------------------------------------------

   Public Shared ReadOnly Property CodigoClienteSinergia() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CODIGOCLIENTESINERGIA.ToString(), "")
      End Get
   End Property

   Public Shared ReadOnly Property PoliticasSeguridadClaves() As Boolean
      Get
         Return Boolean.Parse(New Eniac.Reglas.Parametros().GetValorPD("POLITICASSEGURIDADCLAVES", "False"))
      End Get
   End Property

   Public Shared ReadOnly Property ClaveClienteSinergia() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CLAVECLIENTESINERGIA.ToString(), "")
      End Get
   End Property

   Public Shared ReadOnly Property IDAplicacionSinergia() As String
      Get
         Return Reglas.Publicos.IDAplicacionSinergia
      End Get
   End Property

   Public Shared ReadOnly Property CantidadBasesARBAaGuardar() As Integer
      Get
         Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CANTIDADPADRONESARBA.ToString(), "3"))
      End Get
   End Property

   Public Shared ReadOnly Property MaximoTamanioFoto() As Integer
      Get
         Return Int32.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.MaximoTamanioFoto.ToString(), "50")) * 1024
      End Get
   End Property

   <Obsolete("Usar el de Reglas", False)>
   Public Class DetallePedido
      Public Shared ReadOnly Property PedidosMostrarTamano() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARTAMANO.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarUM() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARUM.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarCosto() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARCOSTO.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarPrecioVentaPorTamano() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRECIOVENTAPORTAMANO.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMonedaPrecioVentaPorTamano() As Integer
         Get
            Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMONEDAPRECIOVENTAPORTAMANO.ToString(), "1"))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarMoneda() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARMONEDA.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarSemaforoRentabilidadDetalle() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARSEMAFORORENTABILIDADDETALLE.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarUrlPlanoDetalle() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARURLPLANODETALLE.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarFormula() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARFORMULA.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarNota() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARNOTA.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarProductoEspmm() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOESPMM.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarProductoEspPulgadas() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOESPPULGADAS.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PedidosMostrarProductoSAE() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOSAE.ToString(), Boolean.FalseString))
         End Get
      End Property
      Public Shared ReadOnly Property PedidosMostrarProductoProduccionProceso() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOPRODUCCIONPROCESO.ToString(), Boolean.FalseString))
         End Get
      End Property
      Public Shared ReadOnly Property PedidosMostrarProductoProduccionForma() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOPRODUCCIONFORMA.ToString(), Boolean.FalseString))
         End Get
      End Property
      Public Shared ReadOnly Property PedidosMostrarProductoLargoExtAlto() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOLARGOEXTALTO.ToString(), Boolean.FalseString))
         End Get
      End Property
      Public Shared ReadOnly Property PedidosMostrarProductoAnchoIntBase() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PEDIDOSMOSTRARPRODUCTOANCHOINTBASE.ToString(), Boolean.FalseString))
         End Get
      End Property

   End Class


   Public Shared ReadOnly Property FTPServidor() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FTPSERVIDOR.ToString(), "")
      End Get
   End Property

   Public Shared ReadOnly Property FTPUsuario() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FTPUSUARIO.ToString(), "")
      End Get
   End Property

   Public Shared ReadOnly Property FTPPassword() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FTPPASSWORD.ToString(), "")
      End Get
   End Property

   Public Shared ReadOnly Property FTPConexionPasiva() As Boolean
      Get
         Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FTPCONEXIONPASIVA, "True"))
      End Get
   End Property

   Public Shared ReadOnly Property FTPFormato() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FTPFORMATO.ToString(), "WebExperto")
      End Get
   End Property

   Public Shared ReadOnly Property FTPNombreArchivo() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FTPNOMBREARCHIVO.ToString(), "")
      End Get
   End Property

   Public Shared ReadOnly Property FTPCarpetaRemota() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FTPCARPETAREMOTA.ToString(), "")
      End Get
   End Property

   <Obsolete("Usar la de Reglas")>
   Public Shared ReadOnly Property ConfiguraciónMail() As String
      Get
         Return Reglas.Publicos.ConfiguraciónMail
      End Get
   End Property

   Public Shared ReadOnly Property URLTeleprom() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.URLTELEPROM.ToString(), String.Empty)
      End Get
   End Property

   ''Public Shared ReadOnly Property ConsolidadoCargaOrdenIdProducto() As Boolean
   ''   Get
   ''      Return New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONSOLIDADOCARGAORDENIDPRODUCTO.ToString(), Boolean.FalseString) = Boolean.TrueString
   ''   End Get
   ''End Property

   'Public Shared ReadOnly Property ExportarPreciosConIVA() As Boolean
   '   Get
   '      Return New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.EXPORTARPRECIOSCONIVA1.ToString(), Boolean.TrueString) = Boolean.TrueString
   '   End Get
   'End Property

   Public Shared ReadOnly Property LogisticaFormatoExportacionDefault As String
      Get
         Return New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.LOGISTICAFORMATOEXPORTACIONDEFAULT.ToString(), Entidades.GenerarArchivo.FormatosExportacion.Sync.ToString())
      End Get
   End Property

   Public Shared ReadOnly Property OrganizarEntregaFiltraFechaEnvio() As Boolean
      Get
         Return New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.ORGANIZARENTREGAFILTRAFECHAENVIO.ToString(), Boolean.TrueString) = Boolean.TrueString
      End Get
   End Property

   Public Shared ReadOnly Property PreventaV2RespetaListaPreciosCliente() As Boolean
      Get
         Return Boolean.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PREVENTAV2RESPETALISTAPRECIOSCLIENTE.ToString(), Boolean.TrueString))
      End Get
   End Property

   Public Shared ReadOnly Property IncluirEsCambiableEsBonificable() As Boolean
      Get
         Return Boolean.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.INCLUIRESCAMBIABLEESBONIFICABLE.ToString(), Boolean.FalseString))
      End Get
   End Property

   Public Shared ReadOnly Property RegistracionPagosTipoMovimiento() As String
      Get
         Return New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.REGISTRACIONPAGOSTIPOMOVIMIENTO.ToString(), "")
      End Get
   End Property

   '--------------

#End Region

   'Nuevos campos SiSeN de Categorias
   Public Shared ReadOnly Property CargosCalcularPor() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CargosCalcularPor.ToString(), "ACCION")
      End Get
   End Property


End Class