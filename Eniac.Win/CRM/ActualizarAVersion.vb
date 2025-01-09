Imports Eniac.Win.Ayudante

Public Class ActualizarAVersion

#Region "Campos"

   Private _clientes As DataTable
   Private _publicos As Publicos
   Private _idAplicacion As String
   Private _ws As WSActualiza.WSActualizador

#End Region

#Region "Constructores"

   Public Sub New(clientes As DataTable,
                  IdAplicacion As String,
                  ws As WSActualiza.WSActualizador,
                  baseDeDatos As String)
      Me.InitializeComponent()
      Me._clientes = clientes
      Me.lblTexto.Text = String.Format("Se va a actualizar la versión a {0} clientes", clientes.Rows.Count)

      Me._idAplicacion = IdAplicacion

      Me._ws = ws

      Me.txtBaseDeDatos.Text = baseDeDatos

      Me.tslPie.Text = ws.Url
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()
      Me._publicos.CargaComboVersiones(Me.cmbVersion, Me._idAplicacion)

   End Sub

#End Region

#Region "Metodos Privados"

   Private Function GetVersionesClientes(listado As WSActualiza.VersionCliente()) As List(Of Entidades.VersionCliente)
      Dim versiones As List(Of Entidades.VersionCliente)
      versiones = New List(Of Entidades.VersionCliente)()
      If listado Is Nothing Then
         Return versiones
      End If
      Dim vcN As Entidades.VersionCliente

      For Each vc As WSActualiza.VersionCliente In listado
         vcN = New Entidades.VersionCliente()

         vcN.CodigoCliente = vc.Cliente.CodigoCliente
         vcN.NroVersion = vc.NroVersionHabilitada
         vcN.NombreCliente = vc.Cliente.NombreCliente

         versiones.Add(vcN)
      Next
      Return versiones
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbActualizarVersion_Click(sender As Object, e As EventArgs) Handles tsbActualizarVersion.Click
      Try
         If MessageBox.Show("Realmente esta seguro de enviar la información a la web?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            'no hago nada y salgo
            Exit Sub
         End If

         Dim versionesClientes As List(Of WSActualiza.VersionCliente)
         versionesClientes = New List(Of WSActualiza.VersionCliente)()

         Dim verCli As WSActualiza.VersionCliente

         For Each dr As DataRow In Me._clientes.Rows
            verCli = New WSActualiza.VersionCliente()
            verCli.Cliente = New WSActualiza.Cliente()
            verCli.Cliente.CodigoCliente = Long.Parse(dr("CodigoCliente").ToString())
            verCli.Cliente.CodigoClienteSpecified = True
            verCli.Aplicacion = New WSActualiza.Aplicacion()
            verCli.Aplicacion.IdAplicacion = Me._idAplicacion
            verCli.NombreBase = Me.txtBaseDeDatos.Text
            verCli.NroVersionHabilitada = Me.cmbVersion.Text
            verCli.Cliente.ClaveCliente = dr("CodigoCliente").ToString()
            verCli.PermiteActualizar = True
            verCli.PermiteActualizarSpecified = True
            versionesClientes.Add(verCli)
         Next

         'actualizar las versiones de los clientes.
         Me._ws.ActualizarVersionesClientes(versionesClientes.ToArray())

         MessageBox.Show(String.Format("Fueron actualizadas {0} versiones en la Web.", versionesClientes.Count.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Dim versiones As List(Of Entidades.VersionCliente)

         Dim lis As WSActualiza.VersionCliente() = Me._ws.GetVersionesClientes(Me._idAplicacion, True, True)
         versiones = Me.GetVersionesClientes(lis)

         If versiones.Count > 0 Then
            'luego de actualizar la web actualizo los datos locales
            Dim reg As Reglas.Clientes
            reg = New Reglas.Clientes()

            reg.ActualizarVersiones(versiones)

            MessageBox.Show("Fueron actualizadas actualizaciones locales.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

End Class