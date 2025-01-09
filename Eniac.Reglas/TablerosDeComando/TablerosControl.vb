Public Class TablerosControl
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.TableroControl.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TableroControl), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TableroControl), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TableroControl), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.TablerosControl(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TablerosControl(Me.da).TablerosControl_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.TableroControl, tipo As TipoSP)
      Dim sqlC As SqlServer.TablerosControl = New SqlServer.TablerosControl(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.TablerosControl_I(en.IdTableroControl, en.NombreTableroControl,
                                   en.IdTableroControlPanel1, en.IdTableroControlPanel2, en.IdTableroControlPanel3,
                                   en.IdTableroControlPanel4, en.IdTableroControlPanel5, en.IdTableroControlPanel6,
                                   en.IdControllerFiltro)
         Case TipoSP._U
            sqlC.TablerosControl_U(en.IdTableroControl, en.NombreTableroControl,
                                   en.IdTableroControlPanel1, en.IdTableroControlPanel2, en.IdTableroControlPanel3,
                                   en.IdTableroControlPanel4, en.IdTableroControlPanel5, en.IdTableroControlPanel6,
                                   en.IdControllerFiltro)
         Case TipoSP._D
            sqlC.TablerosControl_D(en.IdTableroControl)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.TableroControl, dr As DataRow)
      With o
         .IdTableroControl = dr.Field(Of Integer)(Entidades.TableroControl.Columnas.IdTableroControl.ToString())
         .NombreTableroControl = dr.Field(Of String)(Entidades.TableroControl.Columnas.NombreTableroControl.ToString())

         Dim rPanel = New TablerosControlPaneles(da)

         .TableroControlPanel1 = rPanel.GetUno(dr.Field(Of Integer?)(Entidades.TableroControl.Columnas.IdTableroControlPanel1.ToString()).IfNull(-1), AccionesSiNoExisteRegistro.Nulo)
         .TableroControlPanel2 = rPanel.GetUno(dr.Field(Of Integer?)(Entidades.TableroControl.Columnas.IdTableroControlPanel2.ToString()).IfNull(-1), AccionesSiNoExisteRegistro.Nulo)
         .TableroControlPanel3 = rPanel.GetUno(dr.Field(Of Integer?)(Entidades.TableroControl.Columnas.IdTableroControlPanel3.ToString()).IfNull(-1), AccionesSiNoExisteRegistro.Nulo)
         .TableroControlPanel4 = rPanel.GetUno(dr.Field(Of Integer?)(Entidades.TableroControl.Columnas.IdTableroControlPanel4.ToString()).IfNull(-1), AccionesSiNoExisteRegistro.Nulo)
         .TableroControlPanel5 = rPanel.GetUno(dr.Field(Of Integer?)(Entidades.TableroControl.Columnas.IdTableroControlPanel5.ToString()).IfNull(-1), AccionesSiNoExisteRegistro.Nulo)
         .TableroControlPanel6 = rPanel.GetUno(dr.Field(Of Integer?)(Entidades.TableroControl.Columnas.IdTableroControlPanel6.ToString()).IfNull(-1), AccionesSiNoExisteRegistro.Nulo)

         .IdControllerFiltro = dr.Field(Of String)(Entidades.TableroControl.Columnas.IdControllerFiltro.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idTableroControl As Integer) As Entidades.TableroControl
      Return GetUno(idTableroControl, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTableroControl As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TableroControl
      Return CargaEntidad(New SqlServer.TablerosControl(Me.da).TablerosControl_G1(idTableroControl),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TableroControl(),
                          accion, Function() String.Format("No existe un Tablero de Control con Código {0}", idTableroControl))
   End Function

   Public Function GetTodos() As List(Of Entidades.TableroControl)
      Return CargaLista(New SqlServer.TablerosControl(Me.da).TablerosControl_GA(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TableroControl())
   End Function

   Public Function GetCodigoMaximo(ByVal idTableroControl As Integer) As Integer
      Return New SqlServer.TablerosControl(Me.da).GetCodigoMaximo()
   End Function

#End Region
End Class