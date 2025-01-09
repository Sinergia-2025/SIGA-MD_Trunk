Option Strict Off

Public Class SueldosPersonalABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SueldosPersonalDetalle(Me.GetEntidad())
      End If
      Return New SueldosPersonalDetalle(New Entidades.SueldosPersonal)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosPersonal()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Clientes.rdlc", "SistemaDataSet_Clientes", Me.dtDatos, parm, True, 1) '# 1 = Cantidad de Copias

         frmImprime.Text = "Clientes"
         frmImprime.Show()
         'Dim imp As Imprimir = New Imprimir()
         '        Dim path As String = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\") + 1) + "Clientes.rdlc"
         'Dim path As String = "Eniac.Sueldos.Win.Clientes.rdlc"
         'imp.Run(path, "SistemaDataSet_Clientes", Me.dtDatos)
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim sp As Entidades.SueldosPersonal = New Entidades.SueldosPersonal

      With Me.dgvDatos.ActiveCell.Row
         sp.idLegajo = .Cells("idLegajo").Value.ToString()
         sp = New Reglas.SueldosPersonal().GetUno(sp.idLegajo)
         sp.Usuario = actual.Nombre
      End With

      Return sp

   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.SueldosPersonal.Columnas.IdLegajo.ToString()).FormatearColumna("Legajo", col, 50, HAlign.Right)
         .Columns(Entidades.SueldosPersonal.Columnas.NombrePersonal.ToString()).FormatearColumna("Nombre Personal", col, 150)
         .Columns(Entidades.SueldosPersonal.Columnas.Domicilio.ToString()).FormatearColumna("Domicilio", col, 150)
         .Columns(Entidades.Localidad.Columnas.IdLocalidad.ToString()).FormatearColumna("IdLocalidad", col, 150).Hidden = True
         .Columns(Entidades.Localidad.Columnas.NombreLocalidad.ToString()).FormatearColumna("Localidad", col, 150)

         Visible = True

         .Columns(Entidades.Localidad.Columnas.NombreLocalidad.ToString()).FormatearColumna("Localidad", col, 150)
         .Columns(Entidades.SueldosPersonal.Columnas.TipoDocPersonal.ToString()).FormatearColumna("Tipo Doc.", col, 50)
         .Columns(Entidades.SueldosPersonal.Columnas.NroDocPersonal.ToString()).FormatearColumna("Documento", col, 100, HAlign.Right)
         .Columns(Entidades.SueldosPersonal.Columnas.idNacionalidad.ToString()).FormatearColumna("Nacionalidad", col, 150).Hidden = True
         .Columns(Entidades.SueldosPersonal.Columnas.Sexo.ToString()).FormatearColumna("Sexo", col, 50)
         .Columns(Entidades.SueldosPersonal.Columnas.IdEstadoCivil.ToString()).FormatearColumna("Estado Civil", col, 150).Hidden = True
         .Columns(Entidades.SueldosEstadoCivil.Columnas.NombreEstadoCivil.ToString()).FormatearColumna("E. Civil", col, 150)
         .Columns(Entidades.SueldosPersonal.Columnas.Cuil.ToString()).FormatearColumna("CUIL", col, 100, HAlign.Right)
         .Columns(Entidades.SueldosPersonal.Columnas.LegajoMinTrabajo.ToString()).FormatearColumna("Legajo Min. Trabajo", col, 100, HAlign.Right)
         .Columns(Entidades.SueldosPersonal.Columnas.idCategoria.ToString()).FormatearColumna("Categoria", col, 150).Hidden = True
         .Columns(Entidades.SueldosCategoria.Columnas.NombreCategoria.ToString()).FormatearColumna("Categoría", col, 150)
         .Columns(Entidades.SueldosPersonal.Columnas.idObraSocial.ToString()).FormatearColumna("Id Obra Social", col, 150).Hidden = True
         .Columns(Entidades.SueldosPersonal.Columnas.CodObraSocial.ToString()).FormatearColumna("Cod. Obra Social", col, 100, HAlign.Right)
         .Columns(Entidades.SueldosObraSocial.Columnas.NombreObraSocial.ToString()).FormatearColumna("Nombre Obra Social", col, 150)
         .Columns(Entidades.SueldosPersonal.Columnas.FechaNacimiento.ToString()).FormatearColumna("Nacimiento", col, 100, HAlign.Center)
         .Columns(Entidades.SueldosPersonal.Columnas.FechaIngreso.ToString()).FormatearColumna("Fecha", col, 100, HAlign.Center)
         .Columns(Entidades.SueldosPersonal.Columnas.FechaBaja.ToString()).FormatearColumna("Fecha Baja", col, 100, HAlign.Center)
         .Columns(Entidades.SueldosPersonal.Columnas.CentroCosto.ToString()).FormatearColumna("Centro Costo", col, 70, HAlign.Right)
         .Columns(Entidades.SueldosPersonal.Columnas.SueldoBasico.ToString()).FormatearColumna("Sueldo Básico", col, 150, HAlign.Right).Format = "N2"
         .Columns(Entidades.SueldosPersonal.Columnas.MejorSueldo.ToString()).FormatearColumna("Mejor Sueldo", col, 150, HAlign.Right).Hidden = True
         .Columns(Entidades.SueldosPersonal.Columnas.AcumuladoAnual.ToString()).FormatearColumna("Acumulado Anual", col, 150, HAlign.Right).Hidden = True
         .Columns(Entidades.SueldosPersonal.Columnas.AcumuladoSalarioFamiliar.ToString()).FormatearColumna("Acum. Salario Familiar", col, 150, HAlign.Right).Hidden = True
         .Columns(Entidades.SueldosPersonal.Columnas.SueldoActual.ToString()).FormatearColumna("Sueldo Actual", col, 150, HAlign.Right).Format = "N2"
         .Columns(Entidades.SueldosPersonal.Columnas.SalarioFamiliarActual.ToString()).FormatearColumna("SalarioFamiliarActual", col, 150, HAlign.Right).Hidden = True
         .Columns(Entidades.SueldosPersonal.Columnas.AFJP.ToString()).FormatearColumna("AFJP", col, 150)
         .Columns(Entidades.SueldosPersonal.Columnas.AnteriorAcumuladoAnual.ToString()).FormatearColumna("AnteriorAcumuladoAnual", col, 150, HAlign.Right).Hidden = True
         .Columns(Entidades.SueldosPersonal.Columnas.AnteriorMejorSueldo.ToString()).FormatearColumna("AnteriorMejorSueldo", col, 150, HAlign.Right).Hidden = True
         .Columns(Entidades.SueldosPersonal.Columnas.AnteriorSalarioFamiliar.ToString()).FormatearColumna("AnteriorSalarioFamiliar", col, 150, HAlign.Right).Hidden = True
         '-.PE-31892.-
         .Columns(Entidades.Nacionalidad.Columnas.NombreNacionalidad.ToString()).FormatearColumna("Nacionalidad", col, 150)
      End With

   End Sub

   Protected Overrides Sub Borrar()
      MyBase.Borrar()
   End Sub

#End Region

End Class