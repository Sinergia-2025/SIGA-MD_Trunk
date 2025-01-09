#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class PedidosAdminDividir

#Region "Campos/Constantes"
   Private Const CantidadEstadoAColumnName As String = "Cantidad_EstadoA"
   Private Const CantidadEstadoBColumnName As String = "Cantidad_EstadoB"

   Private _publicos As Publicos
   Private _tipoTipoComprobante As String
   Private _dtTablaGrabar As DataTable
   Private _dtTablaGrabarResult As DataTable
   Private _estadoSeleccionado As Entidades.EstadoPedido
   Private _tit As Dictionary(Of String, String)
   Private _cache As Reglas.BusquedasCacheadas

   Private _sucursalActual As Entidades.Sucursal
#End Region

#Region "Propiedades ReadOnly"
   Private ReadOnly Property EstadoA As Entidades.EstadoPedido
      Get
         If cmbEstadoA.SelectedIndex < 0 Then Return Nothing
         Return _cache.BuscaEstadosPedido(cmbEstadoA.SelectedValue.ToString(), _tipoTipoComprobante)
      End Get
   End Property

   Private ReadOnly Property EstadoB As Entidades.EstadoPedido
      Get
         If cmbEstadoB.SelectedIndex < 0 Then Return Nothing
         Return _cache.BuscaEstadosPedido(cmbEstadoB.SelectedValue.ToString(), _tipoTipoComprobante)
      End Get
   End Property

   Public ReadOnly Property TablaGrabar As DataTable
      Get
         Return _dtTablaGrabarResult
      End Get
   End Property
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(idFuncion As String, tipoTipoComprobante As String)
      Me.New()
      Me.IdFuncion = idFuncion
      _tipoTipoComprobante = tipoTipoComprobante
   End Sub
#End Region

#Region "Overrides/Overloads"
   Protected Overrides Sub OnLoad(e As EventArgs)
      _cache = New Reglas.BusquedasCacheadas()

      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSCLIE"

         _sucursalActual = New Reglas.Sucursales().GetUna(actual.Sucursal.Id, False)

         _publicos.CargaComboEstadosPedidos(cmbEstadoA, False, False, False, False, False, _tipoTipoComprobante)
         _publicos.CargaComboEstadosPedidos(cmbEstadoB, False, False, False, False, False, _tipoTipoComprobante)
         _publicos.CargaComboSucursales(cmbSucursalA, False, False, String.Empty)
         _publicos.CargaComboSucursales(cmbSucursalB, False, False, String.Empty)

         cmbEstadoA.SelectedValue = _estadoSeleccionado.IdEstadoDivideA
         cmbEstadoB.SelectedValue = _estadoSeleccionado.IdEstadoDivideB
         txtPorcA.Text = _estadoSeleccionado.PorcDivideA.ToString()
         txtPorcB.Text = _estadoSeleccionado.PorcDivideB.ToString()

         _tit = GetColumnasVisiblesGrilla(ugDetalle)
         ugDetalle.DataSource = _dtTablaGrabar
         AjustarColumnasGrilla(ugDetalle, _tit)

         Dividir()

         ugDetalle.AgregarTotalesSuma({"Cantidad", CantidadEstadoAColumnName, CantidadEstadoBColumnName})
         ugDetalle.AgregarFiltroEnLinea({"NombreProducto"})

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Public Overloads Function ShowDialog(estadoSeleccionado As Entidades.EstadoPedido, _dt As DataTable, owner As Form) As DialogResult
      _dtTablaGrabar = _dt.Clone()
      _dtTablaGrabar.Columns.Add(CantidadEstadoAColumnName, GetType(Decimal)).DefaultValue = 0
      _dtTablaGrabar.Columns.Add(CantidadEstadoBColumnName, GetType(Decimal)).DefaultValue = 0
      _dtTablaGrabar.ImportRowRange(_dt.Select("masivo"))
      _dtTablaGrabar.AcceptChanges()

      _estadoSeleccionado = estadoSeleccionado

      Return ShowDialog(owner)
   End Function
#End Region

#Region "Eventos"
   Private Sub btnDividir_Click(sender As Object, e As EventArgs)
      Try
         Dividir()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbCerrar_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Close()
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         If Validar() Then
            Guardar()

            DialogResult = Windows.Forms.DialogResult.OK
            Close()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Controles"
   Private Sub txtPorcOrigen_Leave(sender As Object, e As EventArgs) Handles txtPorcA.Leave
      Try
         txtPorcB.Text = (100 - CDec(txtPorcA.Text)).ToString()
         Dividir()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtPorcDestino_Leave(sender As Object, e As EventArgs) Handles txtPorcB.Leave
      Try
         txtPorcA.Text = (100 - CDec(txtPorcB.Text)).ToString()
         Dividir()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbEstadoA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoA.SelectedIndexChanged
      ugDetalle.DisplayLayout.Bands(0).Columns(CantidadEstadoAColumnName).Header.Caption = cmbEstadoA.Text
      If EstadoA IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(EstadoA.IdTipoComprobante) Then
         lblTipoComprobanteA.Text = _cache.BuscaTipoComprobante(EstadoA.IdTipoComprobante).Descripcion
         cmbSucursalA.Visible = EstadoA.SolicitaSucursalParaTipoComprobante
      Else
         lblTipoComprobanteA.Text = String.Empty
         cmbSucursalA.Visible = False
      End If
      If cmbSucursalA.Visible Then
         cmbSucursalA.SelectedValue = _sucursalActual.IdSucursalAsociada
      Else
         cmbSucursalA.SelectedIndex = -1
      End If
   End Sub
   Private Sub cmbEstadoB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoB.SelectedIndexChanged
      ugDetalle.DisplayLayout.Bands(0).Columns(CantidadEstadoBColumnName).Header.Caption = cmbEstadoB.Text
      If EstadoB IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(EstadoB.IdTipoComprobante) Then
         lblTipoComprobanteB.Text = _cache.BuscaTipoComprobante(EstadoB.IdTipoComprobante).Descripcion
         cmbSucursalB.Visible = EstadoB.SolicitaSucursalParaTipoComprobante
      Else
         lblTipoComprobanteB.Text = String.Empty
         cmbSucursalB.Visible = False
      End If
      If cmbSucursalB.Visible Then
         cmbSucursalB.SelectedValue = _sucursalActual.IdSucursalAsociada
      Else
         cmbSucursalB.SelectedIndex = -1
      End If
   End Sub
#End Region
#End Region

#Region "Metodos"
   Private Sub Dividir()
      Dim coefEstadoA As Decimal = Decimal.Parse(txtPorcA.Text) / 100
      Dim coefEstadoB As Decimal = Decimal.Parse(txtPorcB.Text) / 100
      For Each drTablaGrabar As DataRow In _dtTablaGrabar.Rows
         Dim cantidad As Decimal = Decimal.Parse(drTablaGrabar("CantEntregada").ToString())

         drTablaGrabar(CantidadEstadoAColumnName) = Math.Round(cantidad * coefEstadoA, 2)
         drTablaGrabar(CantidadEstadoBColumnName) = Math.Round(cantidad * coefEstadoB, 2)
      Next
      _dtTablaGrabar.AcceptChanges()
   End Sub

   Private Function Validar() As Boolean
      If Not ValidarEstado(EstadoA, cmbSucursalA, cmbEstadoA) Then
         Return False
      End If
      If Not ValidarEstado(EstadoB, cmbSucursalB, cmbEstadoB) Then
         Return False
      End If

      Return True
   End Function

   Private Function ValidarEstado(estado As Entidades.EstadoPedido, cmbSucursal As ComboBox, cmbEstado As ComboBox) As Boolean
      If estado.SolicitaSucursalParaTipoComprobante AndAlso cmbSucursal.SelectedIndex < 0 Then
         ShowMessage(String.Format("El estado {0} requiere que se seleccione una sucursal. Por favor seleccione una sucursal.", estado.IdEstado))
         cmbSucursal.Focus()
         Return False
      End If
      If estado.SolicitaSucursalParaTipoComprobante AndAlso Integer.Parse(cmbSucursal.SelectedValue.ToString()) = actual.Sucursal.Id Then
         ShowMessage(String.Format("La Sucursal Seleccionada debe ser diferente a la Sucursal Actual.", estado.IdEstado))
         cmbSucursal.Focus()
         Return False
      End If
      If estado.SolicitaSucursalParaTipoComprobante AndAlso cmbSucursal.SelectedIndex < 0 Then
         ShowMessage(String.Format("El estado {0} requiere que se seleccione una sucursal. Por favor seleccione una sucursal.", estado.IdEstado))
         cmbSucursal.Focus()
         Return False
      End If
      If estado.Divide Then
         ShowMessage(String.Format("No se puede seleccionar un estado que ´Divide´. Por favor cambie el estado {0}.", estado.IdEstado))
         cmbEstado.Focus()
         Return False
      End If
      Return True
   End Function

   Private Sub Guardar()
      _dtTablaGrabarResult = _dtTablaGrabar.Clone()
      For Each drTablaGrabar As DataRow In _dtTablaGrabar.Rows
         Dim drResult As DataRow = _dtTablaGrabarResult.NewRow()
         drResult.ItemArray = drTablaGrabar.ItemArray
         drResult("CantEntregada") = drTablaGrabar(CantidadEstadoAColumnName)
         drResult("IdEstadoNuevo") = cmbEstadoA.Text
         If EstadoA.SolicitaSucursalParaTipoComprobante Then
            drResult("IdSucursalTipoComprobanteDestino") = cmbSucursalA.SelectedValue
         End If
         _dtTablaGrabarResult.Rows.Add(drResult)

         drResult = _dtTablaGrabarResult.NewRow()
         drResult.ItemArray = drTablaGrabar.ItemArray
         drResult("CantEntregada") = drTablaGrabar(CantidadEstadoBColumnName)
         drResult("IdEstadoNuevo") = cmbEstadoB.Text
         If EstadoB.SolicitaSucursalParaTipoComprobante Then
            drResult("IdSucursalTipoComprobanteDestino") = cmbSucursalB.SelectedValue
         End If
         _dtTablaGrabarResult.Rows.Add(drResult)
      Next
   End Sub
#End Region

End Class