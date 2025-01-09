Option Strict On
Option Explicit On

Imports Eniac.Entidades.Usuario

Public Class TiposMovimientosDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.TipoMovimiento)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me._publicos.CargaComboDesdeEnum(Me.cmbCargaPrecio, GetType(Entidades.TipoMovimiento.CargaPrecios), , True)

      Me.cmbCoeficienteStock.Items.Insert(0, -1)
      Me.cmbCoeficienteStock.Items.Insert(1, 0)
      Me.cmbCoeficienteStock.Items.Insert(2, 1)
      Me.cmbCoeficienteStock.SelectedIndex = -1

      Me._publicos.CargaComboTiposMovimientos(Me.cmbContraTipoMovimiento)

      Me.CargarmovimientosHabilitados()

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Win.StateForm.Actualizar Then
         If DirectCast(Me._entidad, Entidades.TipoMovimiento).comprobantesAsociados IsNot Nothing Then
            Me.CargarCampos()
         End If

      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposMovimientos()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      Dim vacio As String = ""

      If Me.cmbCargaPrecio.SelectedIndex = -1 Then
         Me.cmbCargaPrecio.Focus()
         Return "ATENCIÓN: NO selecciono ninguna opción de Carga de Precio"
      End If

      If Me.cmbCoeficienteStock.SelectedIndex = -1 Then
         Me.cmbCoeficienteStock.Focus()
         Return "ATENCIÓN: NO selecciono ninguna opción de Coeficiente de Stock"
      End If

      If Not Me.cmbContraTipoMovimiento.SelectedIndex = -1 Then
         If Me.txtIdTipoMovimiento.Text = Me.cmbContraTipoMovimiento.SelectedValue.ToString() Then
            Me.cmbContraTipoMovimiento.Focus()
            Return "ATENCIÓN: NO puede seleccionar un Contra Tipo Movimiento igual al Movimiento"
         End If
      End If


      Return vacio

   End Function

   Protected Overrides Sub Aceptar()

      Dim cmp As String = String.Empty
      For Each val As String In Me.clbcomprobantesAsociados.CheckedItems
         cmp += String.Format("{0},", val)
         'cmp += String.Format("''{0}'',", val)    ASI VENIA DE TIPO DE COMPROBANTES PARA QUE APAREZCAN ENTRE COMILLAS
      Next
      If cmp <> "" Then
         DirectCast(Me._entidad, Entidades.TipoMovimiento).comprobantesAsociados = cmp.Trim(","c)
      Else
         DirectCast(Me._entidad, Entidades.TipoMovimiento).comprobantesAsociados = String.Empty
      End If


      MyBase.Aceptar()
   End Sub


#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdTipoMovimiento.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oCateg As Reglas.Categorias = New Reglas.Categorias()
      Me.txtIdTipoMovimiento.Text = (oCateg.GetIdMaximo() + 1).ToString()
   End Sub

   Private Sub CargarmovimientosHabilitados()
      'Dim re As Reglas.Tiposmovimientos = New Reglas.Tiposmovimientos()
      'Dim cms As List(Of Eniac.Entidades.Tipomovimiento) = re.GetTodos()
      'For Each cm As Eniac.Entidades.Tipomovimiento In cms
      '   Me.clbcomprobantesAsociados.Items.Add(cm.IdTipomovimiento)
      'Next
      Dim re As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      Dim cms As List(Of Eniac.Entidades.TipoComprobante) = re.GetHabilitados(Actual.Sucursal.Id,
                                                                              nombrePC:="",
                                                                              Tipo1:="COMPRAS",
                                                                              Tipo2:="", AfectaCaja:="", UsaFacturacionRapida:="", UsaFacturacion:=False,
                                                                              IgnoraSucursal:=True, esRecibo:=Nothing, coeficionesStock:=Nothing, grabaLibro:=Nothing,
                                                                              esReciboClienteVinculado:=Nothing, coeficienteValor:=Nothing, importeComprobante:=Nothing,
                                                                              esElectronico:=Nothing, clase:=String.Empty)

      For Each cm As Eniac.Entidades.TipoComprobante In cms
         Me.clbComprobantesAsociados.Items.Add(cm.IdTipoComprobante)
      Next
   End Sub

   Private Sub CargarCampos()
      'cargo los movimientos
      Dim comp() As String
      comp = DirectCast(Me._entidad, Entidades.Tipomovimiento).comprobantesAsociados.Split(","c)

      For i As Integer = 0 To comp.Length - 1

         For j As Integer = 0 To Me.clbComprobantesAsociados.Items.Count - 1
            'If Me.clbComprobantesAsociados.Items(j).ToString().Trim() = comp(i).Trim().Replace("'", "") Then    ACA SACA LAS COMILLAS AL MOMENTO DE COMPARAR LOS ELEMENTOS
            If Me.clbComprobantesAsociados.Items(j).ToString().Trim() = comp(i).Trim() Then
               Me.clbComprobantesAsociados.SetItemChecked(j, True)
            End If
         Next
      Next

   End Sub

#End Region

End Class