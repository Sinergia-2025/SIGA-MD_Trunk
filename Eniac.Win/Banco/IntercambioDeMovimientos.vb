Option Explicit On
Option Strict Off

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Win
Imports Eniac.Reglas
Imports Eniac.Entidades
Imports System.Windows.Forms

Public Class IntercambioDeMovimientos

    Private _IdCuentaBancariaOrigen As Integer
    Private _IdCuentaBancariaDestino As Integer

#Region "Propiedades"

   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Eniac.Win.Publicos()

         '# Filtros en Linea
         AgregarFiltroEnLinea(Me.ugDetalle, {})

         '# Lectura de Preferencias
         Me.PreferenciasLeer(grid:=ugDetalle, sufijoXML:=ugDetalle.Name.ToString(), tsbPreferencias:=tsbPreferencias)

         Me.SetearFechasDeFiltro()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Me.PreferenciasCargar(Me.ugDetalle, Me.ugDetalle.Name, tsbPreferencias)
         PreferenciasLeer(Me.ugDetalle, Me.ugDetalle.Name, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click

      Try

         Me.Cursor = Cursors.WaitCursor
         Me.RefrescarDatosGrilla()
         'Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscCuentaBancariaOrigen_BuscadorClick() Handles bscCuentaBancariaOrigen.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaOrigen)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancariaOrigen.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaOrigen.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaOrigen_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaOrigen.BuscadorSeleccion

      Try

         If Not Me.bscCuentaBancariaOrigen.FilaDevuelta Is Nothing Then

            Me._IdCuentaBancariaOrigen = Integer.Parse(Me.bscCuentaBancariaOrigen.FilaDevuelta.Cells("idCuentaBancaria").Value)

            If ValidarCuentas() Then

               Me.bscCuentaBancariaOrigen.Text = Me.bscCuentaBancariaOrigen.FilaDevuelta.Cells("NombreCuenta").Value

               Me.bscCuentaBancariaOrigen.Enabled = False

            End If

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaDestino_BuscadorClick() Handles bscCuentaBancariaDestino.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaDestino)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancariaDestino.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaDestino.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaDestino_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaDestino.BuscadorSeleccion
      Try

         If Not Me.bscCuentaBancariaDestino.FilaDevuelta Is Nothing Then

            Me._IdCuentaBancariaDestino = Integer.Parse(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("idCuentaBancaria").Value.ToString())

            If ValidarCuentas() Then

               Me.bscCuentaBancariaDestino.Text = Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("NombreCuenta").Value

               Me.bscCuentaBancariaDestino.Enabled = False

            End If

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try
         If Me.bscCuentaBancariaOrigen.Text <> String.Empty Then
            Me.CargarMovimientos(CInt(Me._IdCuentaBancariaOrigen))
         Else
            ShowMessage("Por favor seleccione la Cuenta Origen.")
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnProceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceder.Click

      Try

         If Me.ValidarOperacion() Then

            Dim CuentaBancariaOrigen As Integer = Convert.ToInt32(Me.bscCuentaBancariaOrigen.FilaDevuelta.Cells("idCuentaBancaria").Value)
            Dim CuentaBancariaDestino As Integer = Convert.ToInt32(Me.bscCuentaBancariaDestino.FilaDevuelta.Cells("idCuentaBancaria").Value)
            Dim NumeroMovimiento As Integer = Convert.ToInt32(Me.ugDetalle.ActiveRow.Cells("NumeroMovimiento").Value)

            Dim rLibrosBancos As Reglas.LibroBancos = New Reglas.LibroBancos()
            rLibrosBancos.IntercambiarMovimiento(actual.Sucursal.Id, CuentaBancariaOrigen, CuentaBancariaDestino, NumeroMovimiento)

            MessageBox.Show("El intercambio de movimiento se ha completado con exito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub IntercambioDeMovimientos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub


#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.bscCuentaBancariaOrigen.Enabled = True
      Me.bscCuentaBancariaOrigen.Text = ""
      Me._IdCuentaBancariaOrigen = -1
      Me.bscCuentaBancariaDestino.Enabled = True
      Me.bscCuentaBancariaDestino.Text = ""
      Me._IdCuentaBancariaDestino = -1

      ugDetalle.ClearFilas()

      Me.SetearFechasDeFiltro()

      Me.bscCuentaBancariaOrigen.Focus()

   End Sub

   Public Sub CargarMovimientos(ByVal IdCuentaBancaria As Integer)

      Dim oLibroBancos As Reglas.LibroBancos = New Reglas.LibroBancos()
      Me.ugDetalle.DataSource = oLibroBancos.GetTodos(actual.Sucursal.Id, IdCuentaBancaria, Me.dpFechaDesde.Value, Me.dpFechaHasta.Value, True, Entidades.Publicos.SiNoTodos.TODOS)

   End Sub

   Public Function ValidarOperacion() As Boolean

      If Me.bscCuentaBancariaOrigen.FilaDevuelta Is Nothing Then
         MessageBox.Show("Por favor seleccione la Cuenta Origen.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
         Me.bscCuentaBancariaOrigen.Focus()
         Return False
      End If

      If Me.ugDetalle.ActiveRow Is Nothing Then
         MessageBox.Show("Por favor seleccione el movimiento a intercambiar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
         Return False
      End If

      If Me.bscCuentaBancariaDestino.FilaDevuelta Is Nothing Then
         MessageBox.Show("Por favor seleccione la Cuenta Destino.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
         Me.bscCuentaBancariaDestino.Focus()
         Return False
      End If

      Return True

   End Function

   Public Function ValidarCuentas() As Boolean

      If Me.bscCuentaBancariaOrigen.FilaDevuelta IsNot Nothing And Me.bscCuentaBancariaDestino.FilaDevuelta IsNot Nothing Then
         If Me._IdCuentaBancariaOrigen = Me._IdCuentaBancariaDestino Then
            MessageBox.Show("La Cuenta Origen coincide con la Cuenta Destino.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.bscCuentaBancariaDestino.Enabled = True
            Me.bscCuentaBancariaDestino.Text = ""
            Me._IdCuentaBancariaDestino = -1
            Me.bscCuentaBancariaDestino.Focus()
            Return False
         End If
      End If

      Return True

   End Function

   Private Sub SetearFechasDeFiltro()

      Me.dpFechaDesde.Value = System.DateTime.Now.AddDays(-7)
      Me.dpFechaHasta.Value = System.DateTime.Now

   End Sub

#End Region

End Class