#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinDataSource
#End Region
Public Class ActivacionesOCABM

   Private _publicos As Publicos

   Private _OC As Entidades.PedidoProveedor

   Private _Producto As String

   Private _Orden As Integer

   Private _tit As Dictionary(Of String, String)

   Private _oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

#Region "Constructores"
   Public Sub New(OC As Entidades.PedidoProveedor, Orden As Integer, IdProducto As String)
      InitializeComponent()
      _OC = OC
      _Producto = IdProducto
      _Orden = Orden
   End Sub

#End Region

   '#Region "Propiedades"

   '   Public Property OrdenCompra() As Entidades.PedidoProductoProveedor

   '#End Region

#Region "Overrides"


   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False

      AgregarFiltroEnLinea(dgvDatos, {})

      Me.dgvDatos.DisplayLayout.Bands(0).ColumnFilters("IdTipoComprobante").FilterConditions.Add(FilterComparisionOperator.Equals, _OC.IdTipoComprobante)
      Me.dgvDatos.DisplayLayout.Bands(0).ColumnFilters("NumeroPedido").FilterConditions.Add(FilterComparisionOperator.Equals, _OC.NumeroPedido)
      Me.dgvDatos.DisplayLayout.Bands(0).ColumnFilters("Orden").FilterConditions.Add(FilterComparisionOperator.Equals, _Orden)


      tstColumnas.Text = "Numero"
      'tstBuscar.Text = _OC.NumeroPedido.ToString()
      'tsbFiltrar.PerformClick()

      Me.dgvDatos.DisplayLayout.Bands(0).SortedColumns.Add("FechaActivacion", True)

      If _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ActivacionesOC_DeshabEliminar") Then
         Me.tsbBorrar.Enabled = False
      End If

      If _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ActivacionesOC_SoloConsulta") Then
         Me.tsbBorrar.Enabled = False
         Me.tsbEditar.Enabled = False
         Me.tsbNuevo.Enabled = False
      End If

      tsbEditar.Enabled = False

   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ActivacionesOCDetalle(DirectCast(Me.GetEntidad(), Entidades.ActivacionOC), _OC, _Producto, _Orden)
      End If
      Return New ActivacionesOCDetalle(New Entidades.ActivacionOC(), _OC, _Producto, _Orden)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ActivacionesOC()
   End Function

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.ActiveCell Is Nothing Then
            If Me.dgvDatos.ActiveRow IsNot Nothing Then
               Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
            End If
         End If
         If Me.dgvDatos.ActiveCell IsNot Nothing Then
            Me._entidad = Me.GetEntidad()

            If DirectCast(Me._entidad, Entidades.ActivacionOC).IdUsuario <> Eniac.Ayudantes.Common.usuario Then
               MessageBox.Show("No tiene permiso para eliminar Activaciones de otro Usuario.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If

            If Not ValidaBorrado(_entidad) Then Exit Sub

            If ConfirmarBorrado() = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.Base = Me.GetReglas()
               cl.Borrar(Me._entidad)
               Me.RefreshGrid()
            End If

         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("El registro NO se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim en As Entidades.ActivacionOC = New Entidades.ActivacionOC()
      With Me.dgvDatos.ActiveCell.Row
         en.NumeroPedido = Integer.Parse(.Cells(Entidades.ActivacionOC.Columnas.NumeroPedido.ToString()).Value.ToString())
         en.IdSucursal = Integer.Parse(.Cells(Entidades.ActivacionOC.Columnas.IdSucursal.ToString()).Value.ToString())
         en.TipoComprobante = New Reglas.TiposComprobantes().GetUno(.Cells(Entidades.ActivacionOC.Columnas.IdTipoComprobante.ToString()).Value.ToString())
         en.Letra = .Cells(Entidades.ActivacionOC.Columnas.Letra.ToString()).Value.ToString()
         en.Orden = Integer.Parse(.Cells(Entidades.ActivacionOC.Columnas.Orden.ToString()).Value.ToString())
         en.OrdenActivacion = Integer.Parse(.Cells(Entidades.ActivacionOC.Columnas.OrdenActivacion.ToString()).Value.ToString())
         en.Producto = New Reglas.Productos().GetUno(.Cells(Entidades.ActivacionOC.Columnas.IdProducto.ToString()).Value.ToString(), ,, Reglas.Base.AccionesSiNoExisteRegistro.Vacio)

         en = New Reglas.ActivacionesOC().GetUno(en.IdSucursal, en.TipoComprobante.IdTipoComprobante, en.Letra, en.CentroEmisor,
                                                  en.NumeroPedido, en.IdProducto, en.Orden, en.OrdenActivacion, Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
      End With
      Return en
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)

         Dim pos As Integer = 0
         .Columns(Entidades.ActivacionOC.Columnas.IdSucursal.ToString()).FormatearColumna("Emisor", pos, 80, HAlign.Right, True)
         .Columns(Entidades.ActivacionOC.Columnas.IdTipoComprobante.ToString()).FormatearColumna("Comprobante", pos, 60, HAlign.Right)
         .Columns(Entidades.ActivacionOC.Columnas.Letra.ToString()).FormatearColumna("Letra", pos, 50, HAlign.Center, True)
         .Columns(Entidades.ActivacionOC.Columnas.CentroEmisor.ToString()).FormatearColumna("Emisor", pos, 50, HAlign.Center, True)
         .Columns(Entidades.ActivacionOC.Columnas.NumeroPedido.ToString()).FormatearColumna("Numero", pos, 60, HAlign.Right)
         .Columns(Entidades.ActivacionOC.Columnas.IdProducto.ToString()).FormatearColumna("Item", pos, 80, HAlign.Right)
         .Columns(Entidades.ActivacionOC.Columnas.Orden.ToString()).FormatearColumna("Orden", pos, 50, HAlign.Right)
         .Columns(Entidades.ActivacionOC.Columnas.OrdenActivacion.ToString()).FormatearColumna("Orden Activacion", pos, 50, HAlign.Right)
         .Columns(Entidades.ActivacionOC.Columnas.FechaActivacion.ToString()).FormatearColumna("Fecha Activación", pos, 120, HAlign.Center, , "dd/MM/yyyy HH:mm:ss")
         .Columns(Entidades.ActivacionOC.Columnas.FechaReprogEntrega.ToString()).FormatearColumna("Fecha Reprogración Entrega", pos, 120, HAlign.Center, , "dd/MM/yyyy HH:mm:ss")
         .Columns(Entidades.ActivacionOC.Columnas.Contacto.ToString()).FormatearColumna("Contacto", pos, 80, HAlign.Left)
         .Columns(Entidades.ActivacionOC.Columnas.Observacion.ToString()).FormatearColumna("Situación", pos, 250, HAlign.Left)
         .Columns("DetalleObservacion").FormatearColumna("Observaciones", pos, 250, HAlign.Left)
         .Columns(Entidades.ActivacionOC.Columnas.IdUsuario.ToString()).FormatearColumna("Usuario", pos, 80, HAlign.Left)
         .Columns(Entidades.ActivacionOC.Columnas.IdObservacion.ToString()).FormatearColumna("IdObservacion", pos, 50, HAlign.Center, True)
         .Columns(Entidades.ActivacionOC.Columnas.TelefonoProveedor.ToString()).FormatearColumna("Teléfono Proveedor", pos, 100, HAlign.Center)
         .Columns(Entidades.ActivacionOC.Columnas.CorreoElectronico.ToString()).FormatearColumna("Correo Electrónico", pos, 100, HAlign.Center)
         .Columns(Entidades.ActivacionOC.Columnas.Items.ToString()).FormatearColumna("Ok Items", pos, 100, HAlign.Center)
         .Columns(Entidades.ActivacionOC.Columnas.Cantidades.ToString()).FormatearColumna("Ok Cantidades", pos, 100, HAlign.Center)
         .Columns(Entidades.ActivacionOC.Columnas.Precio.ToString()).FormatearColumna("Ok Precio", pos, 100, HAlign.Center)
         .Columns(Entidades.ActivacionOC.Columnas.FechaE.ToString()).FormatearColumna("Ok Fecha Entrega", pos, 100, HAlign.Center)

      End With
   End Sub

   Private Sub dgvDatos_BeforeCellActivate(sender As Object, e As CancelableCellEventArgs) Handles dgvDatos.BeforeCellActivate

      If (e.Cell.IsFilterRowCell) Then
         e.Cancel = True
         tsbEditar.Enabled = False
      Else
         If Me.dgvDatos.Rows.FilteredInRowCount = 0 Then
            tsbEditar.Enabled = False
         Else
            tsbEditar.Enabled = True
         End If

      End If

   End Sub


#End Region

End Class