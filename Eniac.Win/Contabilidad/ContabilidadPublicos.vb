Option Infer On
Imports Eniac.Reglas

Public Class ContabilidadPublicos

#Region "Constantes"
    Public Class ConstantesCompra
        'para compras
        Public Const IvaCompra = "Iva Compra"
        Public Const ImporteTotalCompra = "Imp Total"
        Public Const SubTotal = "Sub Total"
    End Class
    Public Class ConstantesVenta
        'para ventas
        Public Const ImporteTotal = "Imp. Total"
        Public Const IvaTotal = "IVA Total"
        Public Const ImporteBruto = "Imp. Bruto"
        Public Const Iva10 = "IVA 10%"
        Public Const Iva21 = "IVA 21%"
    End Class

   'Public Const ImporteTotal = "Iva Compra"
#End Region
   'Public Sub CargaComboTipoDocumento(combo As Eniac.Controles.ComboBox, tipoDocumento As String)
   '   Dim oTipoDoc As Eniac.Reglas.TiposDocumento = New Eniac.Reglas.TiposDocumento()
   '   With combo
   '      .DisplayMember = "TipoDocumento"
   '      .ValueMember = "TipoDocumento"
   '      .DataSource = oTipoDoc.GetAll()
   '      If Not String.IsNullOrEmpty(tipoDocumento) Then
   '         .Text = tipoDocumento
   '      End If
   '   End With
   'End Sub

   Public Sub CargaComboCuentas(combo As Eniac.Controles.ComboBox)
      Dim oCuentas As Eniac.Reglas.ContabilidadCuentas = New Eniac.Reglas.ContabilidadCuentas
      With combo
         .DisplayMember = Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()
         .ValueMember = Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()
         .DataSource = oCuentas.GetAll()
         'If .Items.Count > 0 Then
         '   .SelectedIndex = 0
         'End If
      End With
   End Sub

   Public Sub CargaComboFechasExportacion(combo As Eniac.Controles.ComboBox)
      Dim oFechas As Eniac.Reglas.ContabilidadAsientos = New Eniac.Reglas.ContabilidadAsientos
      With combo
         .DisplayMember = Entidades.ContabilidadAsiento.Columnas.FechaExportacion.ToString()
         .ValueMember = Entidades.ContabilidadAsiento.Columnas.FechaExportacion.ToString()
         .DataSource = oFechas.GetFechasExportacion()

      End With
   End Sub

   Public Sub CargaComboCC(combo As Eniac.Controles.ComboBox)
      Dim oCC As Eniac.Reglas.ContabilidadCentrosCostos = New Eniac.Reglas.ContabilidadCentrosCostos
      With combo
         .DisplayMember = Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()
         .ValueMember = Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString()
         .DataSource = oCC.GetAll()
         'If .Items.Count > 0 Then
         '   .SelectedIndex = 0
         'End If
      End With
   End Sub

   Public Sub CargaComboRubros(combo As Eniac.Controles.ComboBox, traerTodos As Boolean)
      Dim orubro As Eniac.Reglas.Rubros = New Eniac.Reglas.Rubros
      With combo
         .DisplayMember = Entidades.Rubro.Columnas.NombreRubro.ToString()
         .ValueMember = Entidades.Rubro.Columnas.IdRubro.ToString()
         .DataSource = orubro.GetAll()
         'If .Items.Count > 0 Then
         '   .SelectedIndex = 0
         'End If
      End With
   End Sub

   Public Sub CargaComboContabilidadEjerciciosAbiertos(combo As Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.ContabilidadEjercicio.ReadOnlyColumnas.DescripcionEjercicio.ToString()
         .ValueMember = Entidades.ContabilidadEjercicio.Columnas.IdEjercicio.ToString()
         .DataSource = New Reglas.ContabilidadEjercicios().GetTodosAbiertos()
         '.SelectedIndex = 0
      End With
   End Sub

   Public Sub CargaComboPlanes(combo As Eniac.Controles.ComboBox, traerTodos As Boolean)
      Dim oplan As Eniac.Reglas.ContabilidadPlanes = New Eniac.Reglas.ContabilidadPlanes
      With combo
         .DisplayMember = Entidades.ContabilidadPlan.Columnas.NombrePlanCuenta.ToString()
         .ValueMember = Entidades.ContabilidadPlan.Columnas.IdPlanCuenta.ToString()
         .DataSource = oplan.GetAll(traerTodos)
         'If .Items.Count > 0 Then
         '   .SelectedIndex = 0
         'End If
      End With
   End Sub
   Public Sub CargaComboEstadosAsientos(combo As Controles.ComboBox)
      Dim rEstado = New Reglas.ContabilidadEstadosAsientos()
      With combo
         .DisplayMember = Entidades.ContabilidadEstadoAsiento.Columnas.NombreEstadoAsiento.ToString()
         .ValueMember = Entidades.ContabilidadEstadoAsiento.Columnas.IdEstadoAsiento.ToString()
         .DataSource = rEstado.GetTodos()
      End With
   End Sub

   Public Sub CargaComboTipo(combo As Eniac.Controles.ComboBox, traerTodos As Boolean)

      Dim orubro As Eniac.Reglas.ContabilidadCuentasRubros = New Eniac.Reglas.ContabilidadCuentasRubros
      With combo
         .DisplayMember = Entidades.ContabilidadCuentaRubro.Columnas.Tipo.ToString()
         .ValueMember = Entidades.ContabilidadCuentaRubro.Columnas.Tipo.ToString()
         .DataSource = orubro.GetTipoComprobante(traerTodos)
         'If .Items.Count > 0 Then
         '   .SelectedIndex = 0
         'End If
      End With

   End Sub

   Public Sub CargaComboCuentasXNivel(combo As Eniac.Controles.ComboBox, nivel As Integer)
      Dim oCuentas As Eniac.Reglas.ContabilidadCuentas = New Eniac.Reglas.ContabilidadCuentas()
      With combo
         .DisplayMember = Eniac.Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()
         .ValueMember = Eniac.Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()
         .DataSource = oCuentas.GetCuentasXNivel(nivel)
      End With
   End Sub

   Public Shared ReadOnly Property ContabilidadCuentaVentas() As Long
      Get
         Return Long.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CONTABILIDADCUENTAVENTAS, "0"))
      End Get
   End Property

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
   Public Sub RefrescaSucursalesACheckListBox(clb As Controles.CheckedListBox)
      Dim c = 0I
      For Each s In clb.Items.OfType(Of Entidades.Sucursal).ToArray()
         clb.SetItemChecked(c, s.Id = actual.Sucursal.Id)
         c += 1
      Next
   End Sub
   Public Function GetIdSucursalesACheckListBox(clb As Controles.CheckedListBox) As Integer()
      Return clb.CheckedItems.OfType(Of Entidades.Sucursal).ToList().ConvertAll(Function(s) s.Id).ToArray()
   End Function
   Public Function GetNombreSucursalesACheckListBox(clb As Controles.CheckedListBox) As String()
      Return clb.CheckedItems.OfType(Of Entidades.Sucursal).ToList().ConvertAll(Function(s) s.Nombre).ToArray()
   End Function

   Public Sub PreparaGrillaCuentas(buscador As Eniac.Controles.Buscador)
      With buscador
         .Titulo = "Cuentas Contables"
         .ColumnasOcultas = New String() {""}
         .ColumnasTitulos = New String() {"Cuenta", "Descripción"}
         .ColumnasFormato = New String() {"", ""}
         .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleLeft}
         .ColumnasAncho = New Integer() {75, 250}
         .AyudaAncho = 361
      End With
   End Sub
   Public Sub PreparaGrillaAsientosContables(buscador As Controles.Buscador2)
      Publicos.PreparaGrillaAutomatico(buscador, "Asientos Contables")
   End Sub

   Public Sub ConfigurarArbol(tv As TreeView)
      Dim oCuentas As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()

      Dim cuentas As DataTable

      cuentas = oCuentas.GetAll_PorCodigo()
      Dim nodoNivel1 As TreeNode
      Dim nodoNivel2 As TreeNode
      Dim nodoNivel3 As TreeNode
      Dim nodoNivel4 As TreeNode
      Dim nodoNivel5 As TreeNode
      Dim nodoNivel6 As TreeNode

      Dim n1 = From cuen As DataRow In cuentas.AsEnumerable() Where cuen.Field(Of Integer)("Nivel") = 1 Select cuen

      For Each cu As DataRow In n1
         nodoNivel1 = New TreeNode()
         nodoNivel1.ForeColor = Color.Green
         nodoNivel1.Text = cu("IdCuenta").ToString() + " - " + cu("NombreCuenta").ToString()
         nodoNivel1.Tag = cu
         tv.Nodes.Add(nodoNivel1)
         Dim n2 = From cuen2 As DataRow In cuentas.AsEnumerable()
                  Where cuen2.Field(Of Integer)("Nivel") = 2 Select cuen2

         For Each cu2 As DataRow In n2
            If cu2("IdCuentaPadre").ToString() = cu("IdCuenta").ToString() Then
               nodoNivel2 = New TreeNode()
               nodoNivel2.Text = cu2("IdCuenta").ToString() + " - " + cu2("NombreCuenta").ToString()
               nodoNivel2.Tag = cu2
               nodoNivel1.Nodes.Add(nodoNivel2)
               Dim n3 = From cuen3 As DataRow In cuentas.AsEnumerable()
                        Where cuen3.Field(Of Integer)("Nivel") = 3 Select cuen3
               For Each cu3 As DataRow In n3
                  If cu3("IdCuentaPadre").ToString() = cu2("IdCuenta").ToString() Then
                     nodoNivel3 = New TreeNode()
                     nodoNivel3.Text = cu3("IdCuenta").ToString() + " - " + cu3("NombreCuenta").ToString()
                     nodoNivel3.Tag = cu3
                     nodoNivel2.Nodes.Add(nodoNivel3)
                     Dim n4 = From cuen4 As DataRow In cuentas.AsEnumerable()
                              Where cuen4.Field(Of Integer)("Nivel") = 4 Select cuen4
                     For Each cu4 As DataRow In n4
                        If cu4("IdCuentaPadre").ToString() = cu3("IdCuenta").ToString() Then
                           nodoNivel4 = New TreeNode()
                           nodoNivel4.Text = cu4("IdCuenta").ToString() + " - " + cu4("NombreCuenta").ToString()
                           nodoNivel4.Tag = cu4
                           nodoNivel3.Nodes.Add(nodoNivel4)
                           Dim n5 = From cuen5 As DataRow In cuentas.AsEnumerable()
                                    Where cuen5.Field(Of Integer)("Nivel") = 5 Select cuen5
                           For Each cu5 As DataRow In n5
                              If cu5("IdCuentaPadre").ToString() = cu4("IdCuenta").ToString() Then
                                 nodoNivel5 = New TreeNode()
                                 nodoNivel5.Text = cu5("IdCuenta").ToString() + " - " + cu5("NombreCuenta").ToString()
                                 nodoNivel5.Tag = cu5
                                 nodoNivel4.Nodes.Add(nodoNivel5)
                                 Dim n6 = From cuen6 As DataRow In cuentas.AsEnumerable()
                                          Where cuen6.Field(Of Integer)("Nivel") = 6 Select cuen6
                                 For Each cu6 As DataRow In n6
                                    If cu6("IdCuentaPadre").ToString() = cu5("IdCuenta").ToString() Then
                                       nodoNivel6 = New TreeNode()
                                       nodoNivel6.Text = cu6("IdCuenta").ToString() + " - " + cu6("NombreCuenta").ToString()
                                       nodoNivel5.Tag = cu6
                                       nodoNivel5.Nodes.Add(nodoNivel6)
                                    End If
                                 Next
                              End If

                           Next
                        End If

                     Next
                  End If

               Next
            End If

         Next
      Next

      tv.ExpandAll()
      tv.PathSeparator = " -> "

      If cuentas.Rows.Count > 0 And tv.Nodes.Count > 0 Then
         tv.SelectedNode = tv.Nodes(0)
         If tv.Nodes(0).Nodes.Count > 0 Then tv.SelectedNode = tv.Nodes(0).Nodes(0)
      End If

   End Sub

   Public Sub CargaComboTiposAsiento(combo As Eniac.Controles.ComboBox)
      Dim dt As DataTable = New DataTable()
      dt.Columns.Add("Descripcion")
      dt.Columns.Add("Tipo")
      Dim dr As DataRow
      dr = dt.NewRow()
      dr("Descripcion") = "Normal"
      dr("Tipo") = Entidades.ContabilidadAsiento.TiposAsiento.NORMAL.ToString()
      dt.Rows.Add(dr)
      dr = dt.NewRow()
      dr("Descripcion") = "Ajuste por Inflación"
      dr("Tipo") = Entidades.ContabilidadAsiento.TiposAsiento.AJUSTEPORINFLACION.ToString()
      dt.Rows.Add(dr)
      dr = dt.NewRow()
      dr("Descripcion") = "Refundición de Resultados"
      dr("Tipo") = Entidades.ContabilidadAsiento.TiposAsiento.REFUNDICIONDERESULTADOS.ToString()
      dt.Rows.Add(dr)
      dr = dt.NewRow()
      dr("Descripcion") = "Cierre de Patrimonio"
      dr("Tipo") = Entidades.ContabilidadAsiento.TiposAsiento.CIERREDEPATRIMONIO.ToString()
      dt.Rows.Add(dr)
      dr = dt.NewRow()
      dr("Descripcion") = "Apertura de Ejercicio"
      dr("Tipo") = Entidades.ContabilidadAsiento.TiposAsiento.APERTURADEEJERCICIO.ToString()
      dt.Rows.Add(dr)


      With combo
         .DisplayMember = "Descripcion"
         .ValueMember = "Tipo"
         .DataSource = dt
         .SelectedIndex = 0
      End With
   End Sub

End Class
