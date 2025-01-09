Public Class MFEmpresas

   Public Const TipoFiltroKey As String = "EMPRESAS"

#Region "Campos"
   Private _idFuncion As String
   Private _filtros As List(Of Entidades.Empresa)
   Public ReadOnly Property Filtros() As List(Of Entidades.Empresa)
      Get
         Return _filtros
      End Get
   End Property

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(permiteSinSeleccion:=True, String.Empty)
   End Sub

   Public Sub New(permiteSinSeleccion As Boolean, idFuncion As String)
      MyBase.New(permiteSinSeleccion)
      InitializeComponent()
      _idFuncion = idFuncion
      _tipoFiltro = TipoFiltroKey
      _filtros = New List(Of Entidades.Empresa)()
      _columnasAMostrar = {Entidades.Empresa.Columnas.IdEmpresa.ToString(), Entidades.Empresa.Columnas.NombreEmpresa.ToString()}.ToList()
      _permiteSinSeleccion = True
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      dgvDatos.DataSource = _filtros.ToArray()

      dgvDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
      With dgvDatos.DisplayLayout.Bands(0)
         For Each col In .Columns
            col.Hidden = True
         Next
         Dim pos = 0I
         .Columns(Entidades.Empresa.Columnas.IdEmpresa.ToString()).FormatearColumna("Código", pos, 50, HAlign.Left, False)
         .Columns(Entidades.Empresa.Columnas.NombreEmpresa.ToString()).FormatearColumna("Nombre", pos, 275, , False)
      End With

   End Sub

   Protected Overrides Sub AgregarTodos()
      _filtros = GetTodas(_idFuncion)
      RefrescoDatosGrilla()
   End Sub

   Public Shared Function GetTodas(idFuncion As String) As List(Of Entidades.Empresa)
      Dim rEmpresas = New Reglas.Empresas()
      Return rEmpresas.GetTodos(idFuncion)
   End Function

   Protected Overrides Sub RefrescoDatosGrilla()
      dgvDatos.DataSource = _filtros.ToArray()
      MyBase.RefrescoDatosGrilla()
   End Sub

   Protected Overrides Sub CargarClase()
      Dim filtros = New Reglas.FiltrosValores().GetTodosPorTipoNombre(_tipoFiltro, _nombreFiltro)
      'Dim ma As Entidades.Empresa
      Dim i As Integer = 0
      Dim Empresas As List(Of Entidades.Empresa) = GetTodas(_idFuncion)
      Me.Filtros.Clear()
      Dim col As IEnumerable(Of Entidades.FiltroValor) = From filt In filtros Where filt.IdRegistro = i
      While col.Count() > 0
         Dim ma = New Entidades.Empresa()
         For Each c As Entidades.FiltroValor In col
            Select Case c.IdColumna
               Case Entidades.Empresa.Columnas.IdEmpresa.ToString()
                  ma.IdEmpresa = Integer.Parse(c.Valor)
               Case Entidades.Empresa.Columnas.NombreEmpresa.ToString()
                  ma.NombreEmpresa = c.Valor
            End Select
         Next
         If Empresas.Exists(Function(x) x.IdEmpresa = ma.IdEmpresa) Then
            Me.Filtros.Add(ma)
         End If
         i += 1
         col = From filt In filtros Where filt.IdRegistro = i
      End While
   End Sub

   Protected Overrides Sub LimpiarFiltros()
      _filtros.Clear()
      RefrescoDatosGrilla()
   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCodigo_BuscadorClick() Handles bscCodigo.BuscadorClick
      TryCatched(
         Sub()
            Dim rEmpresa = New Reglas.Empresas()
            _publicos.PreparaGrillaEmpresas(bscCodigo)

            Dim cod = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            bscCodigo.Datos = rEmpresa.GetPorCodigo(cod, _idFuncion)
         End Sub)
   End Sub
   Private Sub bscNombre_BuscadorClick() Handles bscNombre.BuscadorClick
      TryCatched(
         Sub()
            Dim rEmpresa = New Reglas.Empresas()
            _publicos.PreparaGrillaEmpresas(bscNombre)
            bscNombre.Datos = rEmpresa.GetPorNombre(bscNombre.Text.Trim(), _idFuncion)
         End Sub)
   End Sub

   Private Sub bscCodigo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigo.BuscadorSeleccion, bscNombre.BuscadorSeleccion
      TryCatched(Sub() CargarEmpresa(e.FilaDevuelta))
   End Sub


   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(
         Sub()
            If Not (bscCodigo.Selecciono Or bscNombre.Selecciono) Then
               Exit Sub
            End If
            Dim ep = New Entidades.Empresa()
            ep.IdEmpresa = bscCodigo.Text.ValorNumericoPorDefecto(0I)
            ep.NombreEmpresa = Me.bscNombre.Text
            _filtros.Add(ep)
            RefrescoDatosGrilla()
            bscCodigo.Text = String.Empty
            bscNombre.Text = String.Empty
            bscCodigo.Focus()
         End Sub)
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(
         Sub()
            Dim dr = dgvDatos.FilaSeleccionada(Of Entidades.Empresa)()
            If dr IsNot Nothing Then
               _filtros.Remove(dr)

               RefrescoDatosGrilla()
               bscCodigo.Text = String.Empty
               bscNombre.Text = String.Empty
               bscCodigo.Focus()
            End If
         End Sub)
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarEmpresa(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigo.Text = dr.Cells(Entidades.Empresa.Columnas.IdEmpresa.ToString()).Value.ToString.Trim()
         bscNombre.Text = dr.Cells(Entidades.Empresa.Columnas.NombreEmpresa.ToString()).Value.ToString()
         btnInsertar.PerformClick()
      End If
   End Sub

#End Region
End Class