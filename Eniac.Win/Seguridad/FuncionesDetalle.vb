Imports System.IO
Public Class FuncionesDetalle
   Inherits BaseDetalle
   Private _publicos As Publicos

#Region "Campos"
   ' Creo una instancia de la entidad
   'Private ListaFuncionesDocumentos As List(Of Entidades.FuncionesDocumentos) = New List(Of Entidades.FuncionesDocumentos)
   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _solapaInicial As TabPage

   Public ReadOnly Property FuncionDocumento() As Entidades.Funcion
      Get
         Return DirectCast(_entidad, Entidades.Funcion)
      End Get
   End Property
#End Region

#Region "Métodos"

   Private Function ActiveDocumento() As Entidades.FuncionesDocumentos
      If ugLinksItems.ActiveRow IsNot Nothing AndAlso
         ugLinksItems.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugLinksItems.ActiveRow.ListObject) Is Entidades.FuncionesDocumentos Then
         Return DirectCast(ugLinksItems.ActiveRow.ListObject, Entidades.FuncionesDocumentos)
      End If
      Return Nothing
   End Function

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      _solapaInicial = tbpDatos
   End Sub
   Public Sub New(entidad As Entidades.Funcion)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides/Overloads"
   Public Overloads Function ShowDialog(owner As IWin32Window, keySolopaInicial As String) As DialogResult
      If tbcFunciones.TabPages.ContainsKey(keySolopaInicial) Then
         _solapaInicial = tbcFunciones.TabPages(keySolopaInicial)
      End If
      Return ShowDialog(owner)
   End Function
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbPlus, GetType(Entidades.Funcion.ComboEdicion), , True)
         _publicos.CargaComboDesdeEnum(cmbExpress, GetType(Entidades.Funcion.ComboEdicion), , True)
         _publicos.CargaComboDesdeEnum(cmbBasica, GetType(Entidades.Funcion.ComboEdicion), , True)
         _publicos.CargaComboDesdeEnum(cmbPV, GetType(Entidades.Funcion.ComboEdicion), , True)
         _publicos.CargaComboTiposDocumentosFunciones(cmbTiposLinks)
         _publicos.CargaComboModulos(cmbModulos)

         If Reglas.Publicos.ExtrasSinergia Then
            'If Publicos.CuitEmpresa = "33711345499" Then
            grpEdiciones.Visible = True
         End If

         tbcFunciones.SelectedTab = tbpVinculadas
         tbcFunciones.SelectedTab = _solapaInicial ' tbpDatos

         BindearControles(_entidad)

         ugLinksItems.DataSource = DirectCast(_entidad, Entidades.Funcion).Documentos

         SetFuncionesVinculadasDataSource()

         If StateForm = Win.StateForm.Insertar Then
            cmbPlus.SelectedIndex = 1
            cmbExpress.SelectedIndex = 1
            cmbBasica.SelectedIndex = 1
            cmbPV.SelectedIndex = 1
            If cmbModulos.Items.Count > 0 Then
               cmbModulos.SelectedIndex = 0
            End If

         Else
            If bscCodigoFuncion.Text <> "" Then
               bscCodigoFuncion.PresionarBoton()
            End If
         End If

         SetFuncionesSistemaDataSource()
         QuitarFuncionesVinculadasDeFuncionesSistema()

         'Aplico por defecto estos ordenamientos porque queremos por defecto no solo que venga ordenado por nombre sino que también
         'al agregar o quitar se mantenga el orden y no lo envie siempre al final.
         ugFuncionesSistema.DisplayLayout.Bands(0).SortedColumns.Add("Nombre", descending:=False)
         ugFuncionesVinculadas.DisplayLayout.Bands(0).SortedColumns.Add("NombreFuncionVinculada", descending:=False)

         ugFuncionesSistema.AgregarFiltroEnLinea({"Nombre"})
         ugFuncionesVinculadas.AgregarFiltroEnLinea({"NombreFuncionVinculada"})

         ' El combo de Tipo de Links por defecto inicia vacio
         cmbTiposLinks.SelectedIndex = -1
      End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = (Keys.Control Or Keys.Add) AndAlso tbcFunciones.SelectedTab.Equals(tbpVinculadas) Then
         btnAgregarFuncionesVinculadas.PerformClick()
      ElseIf keyData = (Keys.Control Or Keys.Subtract) AndAlso tbcFunciones.SelectedTab.Equals(tbpVinculadas) Then
         btnQuitarFuncionesVinculadas.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Funciones()
   End Function
   Protected Overrides Function ValidarDetalle() As String
      If Not String.IsNullOrWhiteSpace(bscCodigoFuncion.Text) And Not bscCodigoFuncion.Selecciono And Not bscFuncion.Selecciono Then
         bscCodigoFuncion.Focus()
         Return "Debe seleccionar una función"
      End If
      Return String.Empty
   End Function

   Protected Overrides Sub Aceptar()
      DirectCast(_entidad, Entidades.Funcion).IdPadre = bscCodigoFuncion.Text
      MyBase.Aceptar()
   End Sub

#End Region

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      txtId.Focus()
   End Sub

#Region "Busqueda Función Padre"
   Private Sub bscCodigoFuncion_BuscadorClick() Handles bscCodigoFuncion.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaFunciones2(bscCodigoFuncion)
         bscCodigoFuncion.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(bscCodigoFuncion.Text, String.Empty)
      End Sub)
   End Sub
   Private Sub bscFuncion_BuscadorClick() Handles bscFuncion.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaFunciones2(bscFuncion)
         bscFuncion.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(String.Empty, bscFuncion.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoFuncion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoFuncion.BuscadorSeleccion, bscFuncion.BuscadorSeleccion
      TryCatched(Sub() CargarDatosFuncion(e.FilaDevuelta))
   End Sub

   Private Sub CargarDatosFuncion(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscFuncion.Text = dr.Cells("Nombre").Value.ToString()
         bscCodigoFuncion.Text = dr.Cells("Id").Value.ToString().Trim()
      End If
   End Sub
#End Region

   Private Sub btnBuscarLink_Click(sender As Object, e As EventArgs) Handles btnBuscarLink.Click
      TryCatched(
      Sub()
         DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
         If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim fileInfo = New FileInfo(DialogoAbrirArchivo.FileName)
            If fileInfo.Exists Then

               'Si bien aca lo pude abrir, solo es para obtener el path.
               txtNombreLink.Text = DialogoAbrirArchivo.FileName
               txtNombreLink.Focus()

               ' Sugiero el nombre del documento como descripción
               If String.IsNullOrEmpty(txtDescripcionLink.Text) Then
                  txtDescripcionLink.Text = fileInfo.Name.Truncar(50)
               End If
            Else
               ShowMessage(String.Format("No se puede acceder al archivo '{0}'.", DialogoAbrirArchivo.FileName))
            End If
         End If
      End Sub)
   End Sub

   Private Sub btnInsertarLinkItem_Click(sender As Object, e As EventArgs) Handles btnInsertarLinkItem.Click
      TryCatched(
      Sub()
         ' Guardo el titulo de las columnas visibles en la grilla
         _tit = GetColumnasVisiblesGrilla(ugLinksItems)

         ' Almaceno el orden por el que está actualmente la grilla
         Dim orden As Integer = Me.ugLinksItems.Rows.Count + 1

         ' Verificaciones
         If Me.cmbTiposLinks.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar un Tipo de Link.")
            Me.cmbTiposLinks.Focus()
            Exit Sub
         End If

         If String.IsNullOrEmpty(Me.txtNombreLink.Text) Then
            ShowMessage("ATENCION: Debe ingresar un Link.")
            Me.txtNombreLink.Focus()
            Exit Sub
         End If
         '
         '
         '
         '
         '
         '
         ' Verifico si el link ingresado por el usuario de verdad existe
         Dim myLink As String = Entidades.Ayudante.MappedDriveResolver.Instancia.ResolveToUNC(Me.txtNombreLink.Text)
         Dim fileInfo As FileInfo = New FileInfo(myLink)

         If fileInfo.Exists Then
            '
            '
            '
            ' Si el archivo existe verifico que no se haya agregado ya el MISMO TIPO de archivo asociado al MISMO link
            Dim existe As Boolean = False

            Dim col As List(Of Entidades.FuncionesDocumentos) = DirectCast(_entidad, Entidades.Funcion).Documentos
            Dim valorCombo As Entidades.TipoDocumentoFuncion = cmbTiposLinks.ItemSeleccionado(Of Entidades.TipoDocumentoFuncion)()
            existe = col.LongCount(Function(x) x.Link = txtNombreLink.Text And x.IdTipoLink = valorCombo.IdTipoLink) > 0

            If existe Then
               ShowMessage("ATENCIÓN: El link ingresado ya se encuentra en la grilla.")
               Me.txtNombreLink.Focus()
               Exit Sub
            End If
            '
            '##########################################################
            '# Si el link ingresado no se encuentra repetido continúa #
            '##########################################################
            '

            ' Creo una instancia de la entidad
            Dim en As New Entidades.FuncionesDocumentos
            With en
               '.IdFuncion = Me.txtId.Text
               .TipoDocumentoFuncion = cmbTiposLinks.ItemSeleccionado(Of Entidades.TipoDocumentoFuncion)()
               .Orden = orden
               .Link = myLink
               .Descripcion = Me.txtDescripcionLink.Text
            End With

            DirectCast(_entidad, Entidades.Funcion).Documentos.Add(en)
            Me.ugLinksItems.Rows.Refresh(RefreshRow.ReloadData)

            AjustarColumnasGrilla(ugLinksItems, _tit)
            '
            '
            '
            '
            ' Limpio los campos
            Me.txtNombreLink.Clear()
            Me.txtDescripcionLink.Clear()
            Me.cmbTiposLinks.SelectedIndex = -1
            Me.txtDescripcionLink.Clear()

            ' Focus a la descripciom
            Me.txtDescripcionLink.Focus()

         Else
            ShowMessage("ATENCIÓN: El link ingresado no corresponde a una ruta válida.")
            Me.txtNombreLink.Focus()
            Exit Sub
         End If
      End Sub)
   End Sub

   Private Sub btnEliminarLinkItem_Click(sender As Object, e As EventArgs) Handles btnEliminarLinkItem.Click
      TryCatched(
      Sub()
         If Me.ugLinksItems.ActiveRow IsNot Nothing Then
            Try
               Dim row As Entidades.FuncionesDocumentos = ActiveDocumento()
               FuncionDocumento.Documentos.Remove(row)
               ugLinksItems.Rows.Refresh(RefreshRow.ReloadData)
               cmbTiposLinks.Focus()
            Catch ex As Exception
               ShowMessage("No se ha podido eliminar la fila seleccionada.")
            End Try
         End If
      End Sub)
   End Sub

   Private Sub ugLinksItems_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugLinksItems.ClickCellButton
      TryCatched(
      Sub()
         ' Fila seleccionada
         Dim dr As Entidades.FuncionesDocumentos = ugLinksItems.FilaSeleccionada(Of Entidades.FuncionesDocumentos)()
         Dim fileInfo As FileInfo = New FileInfo(dr.Link)

         ' Si el usuario presiona el botón Ver
         If e.Cell.Row.Index <> -1 Then
            Dim header As String = Me.ugLinksItems.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Header.Caption
            If header = "Ver" Then
               Process.Start(fileInfo.FullName)
            End If
         End If
      End Sub)
   End Sub

   Private Sub ugLinksItems_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugLinksItems.DoubleClickRow
      TryCatched(
      Sub()
         Dim dr As Entidades.FuncionesDocumentos = ugLinksItems.FilaSeleccionada(Of Entidades.FuncionesDocumentos)()
         If dr IsNot Nothing Then
            txtNombreLink.Text = dr.Link
            cmbTiposLinks.SelectedValue = dr.IdTipoLink
            txtDescripcionLink.Text = dr.Descripcion

            ' Lo elimino de la grilla
            btnEliminarLinkItem.PerformClick()
         End If
      End Sub)
   End Sub

   Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
      TryCatched(
      Sub()
         cmbTiposLinks.SelectedIndex = -1
         txtNombreLink.Clear()
         txtDescripcionLink.Clear()
      End Sub)
   End Sub

   Private Sub btnAyudaParametros_Click(sender As Object, e As EventArgs) Handles btnAyudaParametros.Click
      Dim mensajeTooltip As String = String.Empty
      TryCatched(
      Sub()
         Dim nombreClase As String = txtArchivo.Text + "." + txtPantalla.Text
         Dim nombreAssembly As String = GetNombreAssembly(txtArchivo.Text)

         Dim obj = Activator.CreateInstanceFrom(nombreAssembly, nombreClase)
         Dim frm = obj.Unwrap()
         If TypeOf (frm) Is IConParametros Then
            mensajeTooltip = DirectCast(frm, IConParametros).GetParametrosDisponibles()
         Else
            mensajeTooltip = String.Format("La pantalla {0} no recibe Parámetros", txtPantalla.Text)
         End If
      End Sub,
      onErrorAction:=
      Sub(owner, ex)
         mensajeTooltip = String.Format("Error cargando formulario: {0}", ex.Message)
      End Sub,
      onFinallyAction:=
      Sub(owner)
         If Not String.IsNullOrWhiteSpace(mensajeTooltip) Then
            Using frm = New VisorTexto()
               frm.ShowDialog(Me, String.Format("Parametros para la función {0}", txtDescripcion.Text), mensajeTooltip)
            End Using
         End If
      End Sub)
   End Sub
   Private Function GetNombreAssembly(clase As String) As String
      Dim nom = Application.StartupPath + "\" + clase
      Dim archExe = String.Format("{0}.exe", nom)
      Return If(File.Exists(archExe), archExe, String.Format("{0}.dll", nom))
   End Function

   Private Sub SetFuncionesSistemaDataSource()
      SetFuncinesSistemaDataSource(New Reglas.Funciones().GetTodas())
   End Sub
   Private Sub SetFuncinesSistemaDataSource(funcionesSistema As List(Of Entidades.Funcion))
      Dim titFunciones = GetColumnasVisiblesGrilla(ugFuncionesSistema)
      ugFuncionesSistema.DataSource = funcionesSistema
      AjustarColumnasGrilla(ugFuncionesSistema, titFunciones)
   End Sub

   Private Sub SetFuncionesVinculadasDataSource()
      SetFuncionesVinculadasDataSource(DirectCast(_entidad, Entidades.Funcion).FuncionesVinculadas)
   End Sub
   Private Sub SetFuncionesVinculadasDataSource(funcionesVinculadas As Object)
      Dim titVinculadas = GetColumnasVisiblesGrilla(ugFuncionesVinculadas)
      ugFuncionesVinculadas.DataSource = funcionesVinculadas
      AjustarColumnasGrilla(ugFuncionesVinculadas, titVinculadas)
   End Sub

   Public Sub QuitarFuncionesVinculadasDeFuncionesSistema()
      Dim lstFuncSistema = ugFuncionesSistema.DataSource(Of List(Of Entidades.Funcion))
      For Each funcVinc In ugFuncionesVinculadas.DataSource(Of List(Of Entidades.FuncionVinculada))
         lstFuncSistema.RemoveAll(Function(x) x.Id = funcVinc.IdFuncionVinculada)
      Next
      RefrescarGrillas()
   End Sub

   Private Sub btnAgregarFuncionesVinculadas_Click(sender As Object, e As EventArgs) Handles btnAgregarFuncionesVinculadas.Click
      TryCatched(Sub() AgregarFuncionesVinculadas())
   End Sub
   Private Sub btnQuitarFuncionesVinculadas_Click(sender As Object, e As EventArgs) Handles btnQuitarFuncionesVinculadas.Click
      TryCatched(Sub() QuitarFuncionesVinculadas())
   End Sub
   Private Sub AgregarFuncionesVinculadas()
      Dim lstSistema = ugFuncionesSistema.DataSource(Of List(Of Entidades.Funcion))
      Dim lstVinculadas = ugFuncionesVinculadas.DataSource(Of List(Of Entidades.FuncionVinculada))

      Dim selec = ugFuncionesSistema.FilasSeleccionadas(Of Entidades.Funcion)()
      For Each funcSistema In selec
         If Not lstVinculadas.Any(Function(fv) fv.IdFuncionVinculada = funcSistema.Id) Then
            Dim vinc = New Entidades.FuncionVinculada() With {.FuncionVinculada = funcSistema}
            lstVinculadas.Add(vinc)
         End If

         lstSistema.Remove(funcSistema)
      Next
      RefrescarGrillas()
   End Sub
   Private Sub QuitarFuncionesVinculadas()
      Dim lstSistema = ugFuncionesSistema.DataSource(Of List(Of Entidades.Funcion))
      Dim lstVinculadas = ugFuncionesVinculadas.DataSource(Of List(Of Entidades.FuncionVinculada))

      Dim selec = ugFuncionesVinculadas.FilasSeleccionadas(Of Entidades.FuncionVinculada)()
      For Each funcVinculada In selec
         If Not lstSistema.Any(Function(fs) fs.Id = funcVinculada.IdFuncionVinculada) Then
            lstSistema.Add(funcVinculada.FuncionVinculada)
         End If
         lstVinculadas.Remove(funcVinculada)
      Next
      RefrescarGrillas()
   End Sub
   Private Sub RefrescarGrillas()
      ugFuncionesSistema.DisplayLayout.Bands(0).SortedColumns.RefreshSort(regroupBy:=False)
      ugFuncionesVinculadas.DisplayLayout.Bands(0).SortedColumns.RefreshSort(regroupBy:=False)
      ugFuncionesSistema.RowsRefresh(RefreshRow.ReloadData)
      ugFuncionesVinculadas.RowsRefresh(RefreshRow.ReloadData)
      ugFuncionesSistema.Selected.Rows.Clear()
      ugFuncionesVinculadas.Selected.Rows.Clear()
   End Sub
End Class