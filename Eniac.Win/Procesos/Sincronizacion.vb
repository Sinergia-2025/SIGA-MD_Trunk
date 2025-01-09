Option Strict Off
Public Class Sincronizacion

   Private _registrosAEnviar As List(Of Entidades.SincronizaRegistro)

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._registrosAEnviar = New Reglas.Sincronizaciones().GetTodos()
         Me.txtSucursalOrigen.Text = New Reglas.Sucursales().GetEstoyAca(False).Nombre
         Me.txtDatosAEnviar.Text = Me._registrosAEnviar.Count.ToString()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Function GetRegistroWS(ByVal registro As Entidades.SincronizaRegistro) As Sincroniza.SincronizaRegistro
      Dim re As Sincroniza.SincronizaRegistro = New Sincroniza.SincronizaRegistro()
      With registro
         re.Estado = .Estado
         re.FechaHora = .FechaHora
         re.FechaHoraProceso = .FechaHoraProceso
         re.Id = .Id
         re.IdSucursal = .IdSucursal
         re.Password = .Password
         re.Query = .Query
         re.SucursalDestino = .SucursalDestino
         re.SucursalOrigen = .SucursalOrigen
         re.Tabla = .Tabla
         re.Usuario = .Usuario
      End With
      Return re
   End Function
   Private Function GetRegistroLocal(ByVal registro As Sincroniza.SincronizaRegistro) As Entidades.SincronizaRegistro
      Dim re As Entidades.SincronizaRegistro = New Entidades.SincronizaRegistro()
      With registro
         re.Estado = .Estado
         re.FechaHora = .FechaHora
         re.FechaHoraProceso = .FechaHoraProceso
         re.Id = .Id
         re.IdSucursal = .IdSucursal
         re.Password = .Password
         re.Query = .Query
         re.SucursalDestino = .SucursalDestino
         re.SucursalOrigen = .SucursalOrigen
         re.Tabla = .Tabla
         re.Usuario = .Usuario
      End With
      Return re
   End Function

   Private cancel As Boolean = False
   Private Sub btnSincronizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSincronizar.Click
      Try
         Me.prbProgreso.Minimum = 0
         Me.prbProgreso.Value = 0

         Me.btnSincronizar.Text = "Presione ESC para cancelar"
         Me.btnSincronizar.Enabled = False

         cancel = False

         'envia todos los datos al servidor web
         Dim sincroLocal As Reglas.Sincronizaciones = New Reglas.Sincronizaciones()

         Me.lblHaciendo.Text = "Obteniendo registros..."
         Dim lisDes As List(Of Entidades.SincronizaRegistro)
         lisDes = sincroLocal.GetDistintoALaSucursal(actual.Sucursal.Id)

         Me.prbProgreso.Maximum = lisDes.Count + 1

         Dim sincroWS As Sincroniza.Sincronizacion = New Sincroniza.Sincronizacion()

         Me.lblHaciendo.Text = "Enviando datos..."

         For Each reg As Entidades.SincronizaRegistro In lisDes
            sincroWS.CargaRegistro(Me.GetRegistroWS(reg), Publicos.CodigoAutorizacionWS)
            sincroLocal.BorraRegistro(reg.Id)
            Me.prbProgreso.Value = +1
            Me.prbProgreso.Refresh()
            Me.Refresh()

            Application.DoEvents()
            If cancel Then
               Exit For
            End If

            'Dim oReglas As Reglas.Sincronizaciones = New Reglas.Sincronizaciones()
            'oReglas.InsertaRegistro(reg)
         Next

         Me.txtDatosAEnviar.Text = "0"
         Me.prbProgreso.Value = 0

         If MessageBox.Show("Desea recuperar los datos ahora?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If

         Me.lblHaciendo.Text = "Recuperando datos..."

         'recupera todos los datos de la sucursal origen
         Dim datos() As Sincroniza.SincronizaRegistro
         datos = sincroWS.ObtenerRegistros(actual.Sucursal.Id, Publicos.CodigoAutorizacionWS)

         Me.lblHaciendo.Text = "Cargando datos..."

         Me.prbProgreso.Maximum = datos.Length + 1

         Dim lisOri As List(Of Entidades.SincronizaRegistro) = New List(Of Entidades.SincronizaRegistro)
         For Each dat As Sincroniza.SincronizaRegistro In datos
            lisOri.Add(Me.GetRegistroLocal(dat))
            Me.prbProgreso.Value += 1
         Next

         Me.txtDatosRecibidos.Text = lisOri.Count.ToString()

         If MessageBox.Show("Desea cargar la información ahora?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If

         Me.lblHaciendo.Text = "Cargando la información..."

         Me.prbProgreso.Value = 0

         'Ejecutar todos los sp
         For Each reg As Entidades.SincronizaRegistro In lisOri
            sincroLocal.EjecutaSPyEliminaRegistros(reg)
            Me.prbProgreso.Value += 1
         Next

         Me.lblHaciendo.Text = "Sincronización Finaliza."
         Me.txtDatosRecibidos.Text = "0"
         Me.prbProgreso.Value = 0


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.btnSincronizar.Text = "Sincronizar"
         Me.btnSincronizar.Enabled = True
      End Try
   End Sub

   Private Sub Sincronizacion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
      If e.KeyCode = Keys.Escape Then
         cancel = True
      End If
   End Sub
End Class