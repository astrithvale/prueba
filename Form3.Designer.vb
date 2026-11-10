<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Id_usuarioLabel As System.Windows.Forms.Label
        Dim Nombre_usuarioLabel As System.Windows.Forms.Label
        Dim ClaveLabel As System.Windows.Forms.Label
        Dim Nombre_completoLabel As System.Windows.Forms.Label
        Dim EstadoLabel As System.Windows.Forms.Label
        Dim Fecha_registroLabel As System.Windows.Forms.Label
        Dim RolLabel1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbRol = New System.Windows.Forms.ComboBox()
        Me.USUARIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SICEIDataSet1 = New SICEI_principal.SICEIDataSet()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Id_usuarioTextBox = New System.Windows.Forms.TextBox()
        Me.Nombre_usuarioTextBox = New System.Windows.Forms.TextBox()
        Me.ClaveTextBox = New System.Windows.Forms.TextBox()
        Me.Nombre_completoTextBox = New System.Windows.Forms.TextBox()
        Me.Fecha_registroDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.USUARIOBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.USUARIOBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.TableAdapterManager1 = New SICEI_principal.SICEIDataSetTableAdapters.TableAdapterManager()
        Me.USUARIOTableAdapter1 = New SICEI_principal.SICEIDataSetTableAdapters.USUARIOTableAdapter()
        Me.USUARIODataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Id_usuarioLabel = New System.Windows.Forms.Label()
        Nombre_usuarioLabel = New System.Windows.Forms.Label()
        ClaveLabel = New System.Windows.Forms.Label()
        Nombre_completoLabel = New System.Windows.Forms.Label()
        EstadoLabel = New System.Windows.Forms.Label()
        Fecha_registroLabel = New System.Windows.Forms.Label()
        RolLabel1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.USUARIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SICEIDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USUARIOBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.USUARIOBindingNavigator.SuspendLayout()
        CType(Me.USUARIODataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Id_usuarioLabel
        '
        Id_usuarioLabel.AutoSize = True
        Id_usuarioLabel.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Id_usuarioLabel.ForeColor = System.Drawing.Color.White
        Id_usuarioLabel.Location = New System.Drawing.Point(18, 37)
        Id_usuarioLabel.Name = "Id_usuarioLabel"
        Id_usuarioLabel.Size = New System.Drawing.Size(101, 25)
        Id_usuarioLabel.TabIndex = 2
        Id_usuarioLabel.Text = "id usuario:"
        '
        'Nombre_usuarioLabel
        '
        Nombre_usuarioLabel.AutoSize = True
        Nombre_usuarioLabel.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Nombre_usuarioLabel.ForeColor = System.Drawing.Color.White
        Nombre_usuarioLabel.Location = New System.Drawing.Point(18, 108)
        Nombre_usuarioLabel.Name = "Nombre_usuarioLabel"
        Nombre_usuarioLabel.Size = New System.Drawing.Size(151, 25)
        Nombre_usuarioLabel.TabIndex = 4
        Nombre_usuarioLabel.Text = "nombre usuario:"
        '
        'ClaveLabel
        '
        ClaveLabel.AutoSize = True
        ClaveLabel.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ClaveLabel.ForeColor = System.Drawing.Color.White
        ClaveLabel.Location = New System.Drawing.Point(27, 185)
        ClaveLabel.Name = "ClaveLabel"
        ClaveLabel.Size = New System.Drawing.Size(61, 25)
        ClaveLabel.TabIndex = 6
        ClaveLabel.Text = "clave:"
        '
        'Nombre_completoLabel
        '
        Nombre_completoLabel.AutoSize = True
        Nombre_completoLabel.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Nombre_completoLabel.ForeColor = System.Drawing.Color.White
        Nombre_completoLabel.Location = New System.Drawing.Point(393, 108)
        Nombre_completoLabel.Name = "Nombre_completoLabel"
        Nombre_completoLabel.Size = New System.Drawing.Size(168, 25)
        Nombre_completoLabel.TabIndex = 8
        Nombre_completoLabel.Text = "nombre completo:"
        '
        'EstadoLabel
        '
        EstadoLabel.AutoSize = True
        EstadoLabel.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        EstadoLabel.ForeColor = System.Drawing.Color.White
        EstadoLabel.Location = New System.Drawing.Point(383, 185)
        EstadoLabel.Name = "EstadoLabel"
        EstadoLabel.Size = New System.Drawing.Size(74, 25)
        EstadoLabel.TabIndex = 12
        EstadoLabel.Text = "estado:"
        '
        'Fecha_registroLabel
        '
        Fecha_registroLabel.AutoSize = True
        Fecha_registroLabel.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Fecha_registroLabel.ForeColor = System.Drawing.Color.White
        Fecha_registroLabel.Location = New System.Drawing.Point(750, 27)
        Fecha_registroLabel.Name = "Fecha_registroLabel"
        Fecha_registroLabel.Size = New System.Drawing.Size(135, 25)
        Fecha_registroLabel.TabIndex = 14
        Fecha_registroLabel.Text = "fecha registro:"
        AddHandler Fecha_registroLabel.Click, AddressOf Me.Fecha_registroLabel_Click
        '
        'RolLabel1
        '
        RolLabel1.AutoSize = True
        RolLabel1.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        RolLabel1.ForeColor = System.Drawing.Color.White
        RolLabel1.Location = New System.Drawing.Point(393, 27)
        RolLabel1.Name = "RolLabel1"
        RolLabel1.Size = New System.Drawing.Size(40, 25)
        RolLabel1.TabIndex = 29
        RolLabel1.Text = "rol:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(RolLabel1)
        Me.GroupBox1.Controls.Add(Me.cmbRol)
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Controls.Add(Me.Id_usuarioTextBox)
        Me.GroupBox1.Controls.Add(Me.Nombre_usuarioTextBox)
        Me.GroupBox1.Controls.Add(Me.ClaveTextBox)
        Me.GroupBox1.Controls.Add(Me.Nombre_completoTextBox)
        Me.GroupBox1.Controls.Add(Me.Fecha_registroDateTimePicker)
        Me.GroupBox1.Controls.Add(Id_usuarioLabel)
        Me.GroupBox1.Controls.Add(Fecha_registroLabel)
        Me.GroupBox1.Controls.Add(EstadoLabel)
        Me.GroupBox1.Controls.Add(Nombre_completoLabel)
        Me.GroupBox1.Controls.Add(ClaveLabel)
        Me.GroupBox1.Controls.Add(Nombre_usuarioLabel)
        Me.GroupBox1.Font = New System.Drawing.Font("Constantia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(60, 370)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(1123, 270)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Usuario"
        '
        'cmbRol
        '
        Me.cmbRol.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "rol", True))
        Me.cmbRol.FormattingEnabled = True
        Me.cmbRol.Items.AddRange(New Object() {"ADMIN", "RECEPCIONISTA", "TECNICO", "VENDEDOR"})
        Me.cmbRol.Location = New System.Drawing.Point(398, 64)
        Me.cmbRol.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbRol.Name = "cmbRol"
        Me.cmbRol.Size = New System.Drawing.Size(331, 32)
        Me.cmbRol.TabIndex = 30
        '
        'USUARIOBindingSource
        '
        Me.USUARIOBindingSource.DataMember = "USUARIO"
        Me.USUARIOBindingSource.DataSource = Me.SICEIDataSet1
        '
        'SICEIDataSet1
        '
        Me.SICEIDataSet1.DataSetName = "SICEIDataSet"
        Me.SICEIDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmbEstado
        '
        Me.cmbEstado.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.USUARIOBindingSource, "estado", True))
        Me.cmbEstado.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "estado", True))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.cmbEstado.Location = New System.Drawing.Point(388, 212)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(341, 32)
        Me.cmbEstado.TabIndex = 29
        '
        'Id_usuarioTextBox
        '
        Me.Id_usuarioTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "id_usuario", True))
        Me.Id_usuarioTextBox.Location = New System.Drawing.Point(22, 64)
        Me.Id_usuarioTextBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Id_usuarioTextBox.Name = "Id_usuarioTextBox"
        Me.Id_usuarioTextBox.ReadOnly = True
        Me.Id_usuarioTextBox.Size = New System.Drawing.Size(342, 32)
        Me.Id_usuarioTextBox.TabIndex = 15
        '
        'Nombre_usuarioTextBox
        '
        Me.Nombre_usuarioTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "nombre_usuario", True))
        Me.Nombre_usuarioTextBox.Location = New System.Drawing.Point(23, 151)
        Me.Nombre_usuarioTextBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Nombre_usuarioTextBox.Name = "Nombre_usuarioTextBox"
        Me.Nombre_usuarioTextBox.Size = New System.Drawing.Size(341, 32)
        Me.Nombre_usuarioTextBox.TabIndex = 17
        '
        'ClaveTextBox
        '
        Me.ClaveTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "clave", True))
        Me.ClaveTextBox.Location = New System.Drawing.Point(23, 212)
        Me.ClaveTextBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ClaveTextBox.Name = "ClaveTextBox"
        Me.ClaveTextBox.Size = New System.Drawing.Size(341, 32)
        Me.ClaveTextBox.TabIndex = 19
        '
        'Nombre_completoTextBox
        '
        Me.Nombre_completoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "nombre_completo", True))
        Me.Nombre_completoTextBox.Location = New System.Drawing.Point(398, 151)
        Me.Nombre_completoTextBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Nombre_completoTextBox.Name = "Nombre_completoTextBox"
        Me.Nombre_completoTextBox.Size = New System.Drawing.Size(331, 32)
        Me.Nombre_completoTextBox.TabIndex = 21
        '
        'Fecha_registroDateTimePicker
        '
        Me.Fecha_registroDateTimePicker.CalendarFont = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha_registroDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.USUARIOBindingSource, "fecha_registro", True))
        Me.Fecha_registroDateTimePicker.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha_registroDateTimePicker.Location = New System.Drawing.Point(755, 64)
        Me.Fecha_registroDateTimePicker.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Fecha_registroDateTimePicker.Name = "Fecha_registroDateTimePicker"
        Me.Fecha_registroDateTimePicker.Size = New System.Drawing.Size(341, 31)
        Me.Fecha_registroDateTimePicker.TabIndex = 27
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(83, 673)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(133, 43)
        Me.btnGuardar.TabIndex = 18
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.ForeColor = System.Drawing.Color.White
        Me.btnNuevo.Location = New System.Drawing.Point(236, 672)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(133, 43)
        Me.btnNuevo.TabIndex = 19
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditar.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.ForeColor = System.Drawing.Color.White
        Me.btnEditar.Location = New System.Drawing.Point(387, 673)
        Me.btnEditar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(151, 42)
        Me.btnEditar.TabIndex = 20
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = False
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Posición"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(49, 27)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Posición actual"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(48, 24)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Número total de elementos"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'USUARIOBindingNavigator
        '
        Me.USUARIOBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.USUARIOBindingNavigator.BindingSource = Me.USUARIOBindingSource
        Me.USUARIOBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.USUARIOBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.USUARIOBindingNavigator.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.USUARIOBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.USUARIOBindingNavigatorSaveItem})
        Me.USUARIOBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.USUARIOBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.USUARIOBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.USUARIOBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.USUARIOBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.USUARIOBindingNavigator.Name = "USUARIOBindingNavigator"
        Me.USUARIOBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.USUARIOBindingNavigator.Size = New System.Drawing.Size(1205, 27)
        Me.USUARIOBindingNavigator.TabIndex = 23
        Me.USUARIOBindingNavigator.Text = "BindingNavigator1"
        Me.USUARIOBindingNavigator.Visible = False
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorAddNewItem.Text = "Agregar nuevo"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorDeleteItem.Text = "Eliminar"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorMoveFirstItem.Text = "Mover primero"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorMovePreviousItem.Text = "Mover anterior"
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorMoveNextItem.Text = "Mover siguiente"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(29, 24)
        Me.BindingNavigatorMoveLastItem.Text = "Mover último"
        '
        'USUARIOBindingNavigatorSaveItem
        '
        Me.USUARIOBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.USUARIOBindingNavigatorSaveItem.Image = CType(resources.GetObject("USUARIOBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.USUARIOBindingNavigatorSaveItem.Name = "USUARIOBindingNavigatorSaveItem"
        Me.USUARIOBindingNavigatorSaveItem.Size = New System.Drawing.Size(29, 24)
        Me.USUARIOBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.CATEGORIA_PRODUCTOTableAdapter = Nothing
        Me.TableAdapterManager1.CLIENTETableAdapter = Nothing
        Me.TableAdapterManager1.COTIZACION_DETALLETableAdapter = Nothing
        Me.TableAdapterManager1.COTIZACIONTableAdapter = Nothing
        Me.TableAdapterManager1.DEVOLUCIONTableAdapter = Nothing
        Me.TableAdapterManager1.DIAGNOSTICOTableAdapter = Nothing
        Me.TableAdapterManager1.EQUIPOTableAdapter = Nothing
        Me.TableAdapterManager1.MATERIAL_UTILIZADOTableAdapter = Nothing
        Me.TableAdapterManager1.PAGO_SERVICIOTableAdapter = Nothing
        Me.TableAdapterManager1.PRODUCTOTableAdapter = Nothing
        Me.TableAdapterManager1.SERVICIOTableAdapter = Nothing
        Me.TableAdapterManager1.TECNICOTableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = SICEI_principal.SICEIDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager1.USUARIOTableAdapter = Me.USUARIOTableAdapter1
        Me.TableAdapterManager1.VENDEDORTableAdapter = Nothing
        Me.TableAdapterManager1.VENTA_DETALLETableAdapter = Nothing
        Me.TableAdapterManager1.VENTATableAdapter = Nothing
        '
        'USUARIOTableAdapter1
        '
        Me.USUARIOTableAdapter1.ClearBeforeFill = True
        '
        'USUARIODataGridView
        '
        Me.USUARIODataGridView.AllowUserToAddRows = False
        Me.USUARIODataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.USUARIODataGridView.AutoGenerateColumns = False
        Me.USUARIODataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.USUARIODataGridView.BackgroundColor = System.Drawing.Color.White
        Me.USUARIODataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.USUARIODataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.USUARIODataGridView.ColumnHeadersHeight = 40
        Me.USUARIODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.USUARIODataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14})
        Me.USUARIODataGridView.DataSource = Me.USUARIOBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.USUARIODataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.USUARIODataGridView.EnableHeadersVisualStyles = False
        Me.USUARIODataGridView.Location = New System.Drawing.Point(60, 87)
        Me.USUARIODataGridView.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.USUARIODataGridView.MultiSelect = False
        Me.USUARIODataGridView.Name = "USUARIODataGridView"
        Me.USUARIODataGridView.RowHeadersVisible = False
        Me.USUARIODataGridView.RowHeadersWidth = 51
        Me.USUARIODataGridView.RowTemplate.Height = 33
        Me.USUARIODataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.USUARIODataGridView.Size = New System.Drawing.Size(1610, 235)
        Me.USUARIODataGridView.TabIndex = 23
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "id_usuario"
        Me.DataGridViewTextBoxColumn8.HeaderText = "id_usuario"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "nombre_usuario"
        Me.DataGridViewTextBoxColumn9.HeaderText = "nombre_usuario"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "clave"
        Me.DataGridViewTextBoxColumn10.HeaderText = "clave"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "nombre_completo"
        Me.DataGridViewTextBoxColumn11.HeaderText = "nombre_completo"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "rol"
        Me.DataGridViewTextBoxColumn12.HeaderText = "rol"
        Me.DataGridViewTextBoxColumn12.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "estado"
        Me.DataGridViewTextBoxColumn13.HeaderText = "estado"
        Me.DataGridViewTextBoxColumn13.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "fecha_registro"
        Me.DataGridViewTextBoxColumn14.HeaderText = "fecha_registro"
        Me.DataGridViewTextBoxColumn14.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Firebrick
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Location = New System.Drawing.Point(726, 672)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(151, 42)
        Me.btnEliminar.TabIndex = 24
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.ForeColor = System.Drawing.Color.White
        Me.btnActualizar.Location = New System.Drawing.Point(558, 672)
        Me.btnActualizar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(151, 43)
        Me.btnActualizar.TabIndex = 30
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(14, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1485, 747)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.USUARIODataGridView)
        Me.Controls.Add(Me.USUARIOBindingNavigator)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestión de Usuarios - SICEI"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.USUARIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SICEIDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USUARIOBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.USUARIOBindingNavigator.ResumeLayout(False)
        Me.USUARIOBindingNavigator.PerformLayout()
        CType(Me.USUARIODataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SICEIDataSet As SICEIDataSet
    Friend WithEvents USUARIOTableAdapter As SICEIDataSetTableAdapters.USUARIOTableAdapter
    Friend WithEvents TableAdapterManager As SICEIDataSetTableAdapters.TableAdapterManager
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEditar As Button
    Friend WithEvents SICEIDataSet1 As SICEIDataSet
    Friend WithEvents USUARIOBindingSource As BindingSource
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents USUARIOBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents USUARIOBindingNavigator As BindingNavigator
    Friend WithEvents TableAdapterManager1 As SICEIDataSetTableAdapters.TableAdapterManager
    Friend WithEvents USUARIOTableAdapter1 As SICEIDataSetTableAdapters.USUARIOTableAdapter
    Friend WithEvents USUARIODataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents Id_usuarioTextBox As TextBox
    Friend WithEvents Nombre_usuarioTextBox As TextBox
    Friend WithEvents ClaveTextBox As TextBox
    Friend WithEvents Nombre_completoTextBox As TextBox
    Friend WithEvents Fecha_registroDateTimePicker As DateTimePicker
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents cmbRol As ComboBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnActualizar As Button
End Class
