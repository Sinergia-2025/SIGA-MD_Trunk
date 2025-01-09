Option Strict On
Public Class Auditorias
   Protected da As Datos.DataAccess
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      da = accesoDatos
   End Sub

   <Obsolete("Empezar a reemplazar por el Insertar(String, Auditorias.Operaciones, String, String, Boolean)")>
   Public Sub Insertar(tabla As String,
                       operacion As Entidades.OperacionesAuditorias,
                       usuario As String,
                       clavePrimaria As String)
      Insertar(tabla, operacion, usuario, clavePrimaria, False)
   End Sub

   Public Function GetUno(tabla As String, clavePrimaria As String) As DataTable
      Return New SqlServer.Auditorias(da).Auditorias_G1(tabla, clavePrimaria)
   End Function

   Public Sub Insertar(tabla As String,
                       operacion As Entidades.OperacionesAuditorias,
                       usuario As String,
                       clavePrimaria As String,
                       conMilisegundos As Boolean)
      Insertar(tabla, operacion, usuario, clavePrimaria, conMilisegundos, {})
   End Sub
   Public Sub Insertar(tabla As String,
                       operacion As Entidades.OperacionesAuditorias,
                       usuario As String,
                       clavePrimaria As String,
                       conMilisegundos As Boolean,
                       camposIgnorarComparar As IEnumerable(Of String))
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()
         Dim sqlAudit = New SqlServer.Auditorias(da)

         Dim fechaHora As DateTime = Now
         'Recupero los string con los campos de la tabla a auditar.
         Dim campos = sqlAudit.Campos_G(tabla, camposIgnorarComparar)

         'Inserto el registro de auditoría.
         sqlAudit.Auditorias_I(tabla, campos.CamposInsertSelect, operacion, usuario, clavePrimaria, fechaHora, conMilisegundos)

         'Si estoy modificando ...
         If operacion = Entidades.OperacionesAuditorias.Modificacion Then
            '... y el registro está duplicado (todos los campos de la tabla auditoría (salvo los propios) son iguales)
            If sqlAudit.Auditorias_Duplicado(tabla, campos.CamposComparar, clavePrimaria) Then
               'Borro el registro que ingresé de modo de no duplicar registros innecesarios ya que no cambió el registro origen.
               sqlAudit.Auditorias_D(tabla, clavePrimaria, fechaHora)
            End If
         End If

         If blnAbreConexion Then da.CommitTransaction()
      Catch ex As Exception
         If blnAbreConexion Then da.RollbakTransaction()
         Throw New Exception(ex.Message, ex)
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Function OperacionSegunAuditoria(tabla As String, clavePrimaria As String) As Entidades.OperacionesAuditorias
      Return OperacionSegunAuditoria(tabla, clavePrimaria, activoNuevoRegistro:=Nothing)
   End Function
   Public Function OperacionSegunAuditoria(tabla As String, clavePrimaria As String, activoNuevoRegistro As Boolean?) As Entidades.OperacionesAuditorias
      Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
      Dim dtAudit As DataTable = sqlAudit.Auditorias_G1(tabla, clavePrimaria)

      'Si no tiene registro es porque se borro el alta en la auditoria (podria pasar en la implementacion inicial)
      If dtAudit.Rows.Count > 0 Then
         If activoNuevoRegistro.HasValue Then
            If Not activoNuevoRegistro.Value And Boolean.Parse(dtAudit.Rows(0)("Activo").ToString()) Then
               Return Entidades.OperacionesAuditorias.Inactivar
            ElseIf activoNuevoRegistro.Value And Not Boolean.Parse(dtAudit.Rows(0)("Activo").ToString()) Then
               Return Entidades.OperacionesAuditorias.Alta
            End If
         Else
            Return Entidades.OperacionesAuditorias.Modificacion
         End If
      Else
         Return Entidades.OperacionesAuditorias.Alta
      End If
   End Function

End Class