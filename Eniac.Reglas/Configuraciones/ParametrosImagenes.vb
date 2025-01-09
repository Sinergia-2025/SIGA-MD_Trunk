Option Explicit On
Option Strict On

Public Class ParametrosImagenes
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ParametrosImagen"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.ParametrosImagenes(da).Buscar(entidad.Columna, entidad.Valor.ToString(), actual.Sucursal.IdEmpresa)
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Parametros(Me.da).Parametros_GA(actual.Sucursal.IdEmpresa)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim en As Entidades.ParametroImagen = DirectCast(entidad, Entidades.ParametroImagen)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ParametrosImagenes = New SqlServer.ParametrosImagenes(Me.da)

         Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
         Dim OperacAudit As Entidades.OperacionesAuditorias
         Dim clavePrimariaAuditoria As String = String.Format("{0} = {1} AND {2} = '{3}'",
                                                              Entidades.ParametroImagen.Columnas.IdEmpresa.ToString(), en.IdEmpresa,
                                                              Entidades.ParametroImagen.Columnas.IdParametroImagen.ToString(), en.IdParametroImagenes)

         Select Case tipo
            Case TipoSP._I
               If sql.Existe(en.IdEmpresa, en.IdParametroImagenes) Then
                  sql.ParametrosImagenes_U(en.IdEmpresa, en.IdParametroImagenes)
                  sql.GrabarFoto(en.ValorParametroImagenes, en.IdEmpresa, en.IdParametroImagenes)
                  OperacAudit = rAudit.OperacionSegunAuditoria(Entidades.ParametroImagen.NombreTabla, clavePrimariaAuditoria)

               Else
                  sql.ParametrosImagenes_I(en.IdEmpresa, en.IdParametroImagenes)
                  sql.GrabarFoto(en.ValorParametroImagenes, en.IdEmpresa, en.IdParametroImagenes)
                  OperacAudit = Entidades.OperacionesAuditorias.Alta

               End If
            Case TipoSP._U

            Case TipoSP._D
               sql.ParametrosImagenes_D(en.IdEmpresa, en.IdParametroImagenes)
               OperacAudit = Entidades.OperacionesAuditorias.Baja

         End Select

         rAudit.Insertar(Entidades.ParametroImagen.NombreTabla, OperacAudit, actual.Nombre, clavePrimariaAuditoria, conMilisegundos:=False)

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Overloads Function GetValor(idParametroImagenes As Entidades.ParametroImagen.Parametros) As System.Drawing.Image
      Return Me.GetValor(idParametroImagenes.ToString())
   End Function

   Public Overloads Function GetValor(idParametroImagenes As String) As System.Drawing.Image
      Dim idEmpresa As Integer = actual.Sucursal.IdEmpresa
      Dim stb As StringBuilder = New StringBuilder()
      Dim logo As System.Drawing.Image = Nothing
      With stb
         .AppendLine("SELECT ValorParametroImagen")
         .AppendLine("  FROM ParametrosImagenes")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND IdParametroImagen = '{0}'", idParametroImagenes.ToUpper.Trim())
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("ValorParametroImagen").ToString()) Then
            Dim content() As Byte = CType(dt.Rows(0)("ValorParametroImagen"), Byte())
            Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
            logo = New System.Drawing.Bitmap(stream)
         End If

         Return logo
      Else
         Throw New Exception(String.Format("ATENCION: NO existe el Parametro '{0}' para la empresa {1} y NO podrá continuar." & vbCrLf & vbCrLf & "Por favor contáctese con Sistemas.",
                                           idParametroImagenes.ToUpper.Trim(), idEmpresa))
      End If
   End Function

   Public Function GetValor2(idParametroImagenes As String) As Byte()
      Dim idEmpresa As Integer = actual.Sucursal.IdEmpresa
      Dim stb As StringBuilder = New StringBuilder()
      Dim logo As System.Drawing.Image = Nothing
      With stb
         .AppendLine("SELECT ValorParametroImagen ")
         .AppendLine("  FROM ParametrosImagenes")
         .AppendFormat(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormat("   AND IdParametroImagen = '{0}'", idParametroImagenes.ToUpper.Trim())
      End With
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("ValorParametroImagen").ToString()) Then
            Return CType(dt.Rows(0)("ValorParametroImagen"), Byte())
         Else
            Return Nothing
         End If
      Else
         Throw New Exception(String.Format("ATENCION: NO existe el Parametro '{0}' para la empresa {1} y NO podrá continuar." & vbCrLf & vbCrLf & "Por favor contáctese con Sistemas.",
                                           idParametroImagenes.ToUpper.Trim(), idEmpresa))
      End If
   End Function

   Public Sub GrabarParametroImagen(path As String, idEmpresa As Integer, idParametroImagen As String)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ParametrosImagenes = New SqlServer.ParametrosImagenes(Me.da)

         Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
         Dim OperacAudit As Entidades.OperacionesAuditorias
         Dim clavePrimariaAuditoria As String = String.Format("{0} = {1} AND {2} = '{3}'",
                                                              Entidades.ParametroImagen.Columnas.IdEmpresa.ToString(), idEmpresa,
                                                              Entidades.ParametroImagen.Columnas.IdParametroImagen.ToString(), idParametroImagen)

         sql.GrabarParametroImagen(path, idEmpresa, idParametroImagen)

         OperacAudit = rAudit.OperacionSegunAuditoria(Entidades.ParametroImagen.NombreTabla, clavePrimariaAuditoria)

         rAudit.Insertar(Entidades.ParametroImagen.NombreTabla, OperacAudit, actual.Nombre, clavePrimariaAuditoria, conMilisegundos:=False)

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub


#End Region

   Public Function CopiarEntreEmpresas(idEmpresaOrigen As Integer, idEmpresaDestino As Integer) As Integer
      Return New SqlServer.ParametrosImagenes(da).ParametrosImagenes_M(idEmpresaOrigen, idEmpresaDestino)
   End Function
   Public Overloads Sub Borrar(idEmpresa As Integer)
      Dim sql As SqlServer.ParametrosImagenes = New SqlServer.ParametrosImagenes(da)
      sql.ParametrosImagenes_D(idEmpresa, idParametro:=String.Empty)
   End Sub

End Class