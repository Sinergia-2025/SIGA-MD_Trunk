Public Class TablerosControlPaneles
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.TableroControlPanel.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TableroControlPanel), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TableroControlPanel), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TableroControlPanel), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.TablerosControlPaneles(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TablerosControlPaneles(Me.da).TablerosControlPaneles_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.TableroControlPanel, tipo As TipoSP)
      Dim sqlC As SqlServer.TablerosControlPaneles = New SqlServer.TablerosControlPaneles(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.TablerosControlPaneles_I(en.IdTableroControlPanel, en.NombrePanel, en.Parametros, en.IdController,
                                          en.BackColor1, en.ForeColor1, en.BackColor2, en.ForeColor2)
         Case TipoSP._U
            sqlC.TablerosControlPaneles_U(en.IdTableroControlPanel, en.NombrePanel, en.Parametros, en.IdController,
                                          en.BackColor1, en.ForeColor1, en.BackColor2, en.ForeColor2)
         Case TipoSP._D
            sqlC.TablerosControlPaneles_D(en.IdTableroControlPanel)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.TableroControlPanel, dr As DataRow)
      With o
         .IdTableroControlPanel = dr.Field(Of Integer)(Entidades.TableroControlPanel.Columnas.IdTableroControlPanel.ToString())
         .NombrePanel = dr.Field(Of String)(Entidades.TableroControlPanel.Columnas.NombrePanel.ToString())
         .Parametros = dr.Field(Of String)(Entidades.TableroControlPanel.Columnas.Parametros.ToString())
         .IdController = dr.Field(Of String)(Entidades.TableroControlPanel.Columnas.IdController.ToString())

         .BackColor1 = dr.Field(Of Integer?)(Entidades.TableroControlPanel.Columnas.BackColor1.ToString())
         .ForeColor1 = dr.Field(Of Integer?)(Entidades.TableroControlPanel.Columnas.ForeColor1.ToString())
         .BackColor2 = dr.Field(Of Integer?)(Entidades.TableroControlPanel.Columnas.BackColor2.ToString())
         .ForeColor2 = dr.Field(Of Integer?)(Entidades.TableroControlPanel.Columnas.ForeColor2.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idTableroControlPanel As Integer) As Entidades.TableroControlPanel
      Return GetUno(idTableroControlPanel, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTableroControlPanel As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TableroControlPanel
      Return CargaEntidad(New SqlServer.TablerosControlPaneles(Me.da).TablerosControlPaneles_G1(idTableroControlPanel),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TableroControlPanel(),
                          accion, Function() String.Format("No existe un Panel para Tablero de Control con Código {0}", idTableroControlPanel))
   End Function

   Public Function GetTodos() As List(Of Entidades.TableroControlPanel)
      Return CargaLista(New SqlServer.TablerosControlPaneles(Me.da).TablerosControlPaneles_GA(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TableroControlPanel())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.TablerosControlPaneles(Me.da).GetCodigoMaximo()
   End Function

   'GET POR CODIGO
   Public Function GetPorCodigo(idTableroControlPanel As Integer) As DataTable
      Return New SqlServer.TablerosControlPaneles(da).TablerosControlPaneles_G1(idTableroControlPanel)
   End Function
   'GET POR NOMBRE
   Public Function GetPorNombre(nombrePanel As String) As DataTable
      Return New SqlServer.TablerosControlPaneles(da).TablerosControlPaneles_GA(nombrePanel)
   End Function

#End Region
End Class