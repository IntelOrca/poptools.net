<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.grpMirrorMap = New System.Windows.Forms.GroupBox
        Me.rdbCrossAxis = New System.Windows.Forms.RadioButton
        Me.rdbDiagonalAxis2 = New System.Windows.Forms.RadioButton
        Me.rdbBothAxis = New System.Windows.Forms.RadioButton
        Me.rdbDiagonalAxis1 = New System.Windows.Forms.RadioButton
        Me.rdbVerticalAxis = New System.Windows.Forms.RadioButton
        Me.rdbHorizontalAxis = New System.Windows.Forms.RadioButton
        Me.btnMirrorMap = New System.Windows.Forms.Button
        Me.btnMoveMapLeft = New System.Windows.Forms.Button
        Me.btnMoveMapUp = New System.Windows.Forms.Button
        Me.btnMoveMapDown = New System.Windows.Forms.Button
        Me.btnMoveMapRight = New System.Windows.Forms.Button
        Me.lstMoveMap = New System.Windows.Forms.ListBox
        Me.grpMoveRotateMap = New System.Windows.Forms.GroupBox
        Me.btnRotateMap = New System.Windows.Forms.Button
        Me.grpPreviewMap = New System.Windows.Forms.GroupBox
        Me.imgMap = New System.Windows.Forms.PictureBox
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.SaveHeightMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowSymmetryLinesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowSouceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowObjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.MirrorRotateLandToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MirrorRotateObjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ReplicateObjectsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Help2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RandomMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.grpMirrorMap.SuspendLayout()
        Me.grpMoveRotateMap.SuspendLayout()
        Me.grpPreviewMap.SuspendLayout()
        CType(Me.imgMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpMirrorMap
        '
        Me.grpMirrorMap.Controls.Add(Me.rdbCrossAxis)
        Me.grpMirrorMap.Controls.Add(Me.rdbDiagonalAxis2)
        Me.grpMirrorMap.Controls.Add(Me.rdbBothAxis)
        Me.grpMirrorMap.Controls.Add(Me.rdbDiagonalAxis1)
        Me.grpMirrorMap.Controls.Add(Me.rdbVerticalAxis)
        Me.grpMirrorMap.Controls.Add(Me.rdbHorizontalAxis)
        Me.grpMirrorMap.Controls.Add(Me.btnMirrorMap)
        Me.grpMirrorMap.Location = New System.Drawing.Point(9, 27)
        Me.grpMirrorMap.Name = "grpMirrorMap"
        Me.grpMirrorMap.Size = New System.Drawing.Size(188, 193)
        Me.grpMirrorMap.TabIndex = 0
        Me.grpMirrorMap.TabStop = False
        Me.grpMirrorMap.Text = "Mirror Map"
        '
        'rdbCrossAxis
        '
        Me.rdbCrossAxis.AutoSize = True
        Me.rdbCrossAxis.Location = New System.Drawing.Point(6, 134)
        Me.rdbCrossAxis.Name = "rdbCrossAxis"
        Me.rdbCrossAxis.Size = New System.Drawing.Size(87, 17)
        Me.rdbCrossAxis.TabIndex = 7
        Me.rdbCrossAxis.Text = "X Cross Axes"
        Me.rdbCrossAxis.UseVisualStyleBackColor = True
        '
        'rdbDiagonalAxis2
        '
        Me.rdbDiagonalAxis2.AutoSize = True
        Me.rdbDiagonalAxis2.Location = New System.Drawing.Point(6, 111)
        Me.rdbDiagonalAxis2.Name = "rdbDiagonalAxis2"
        Me.rdbDiagonalAxis2.Size = New System.Drawing.Size(97, 17)
        Me.rdbDiagonalAxis2.TabIndex = 6
        Me.rdbDiagonalAxis2.Text = "/ Diagonal Axis"
        Me.rdbDiagonalAxis2.UseVisualStyleBackColor = True
        '
        'rdbBothAxis
        '
        Me.rdbBothAxis.AutoSize = True
        Me.rdbBothAxis.Checked = True
        Me.rdbBothAxis.Location = New System.Drawing.Point(6, 65)
        Me.rdbBothAxis.Name = "rdbBothAxis"
        Me.rdbBothAxis.Size = New System.Drawing.Size(82, 17)
        Me.rdbBothAxis.TabIndex = 5
        Me.rdbBothAxis.TabStop = True
        Me.rdbBothAxis.Text = "+ Both Axes"
        Me.rdbBothAxis.UseVisualStyleBackColor = True
        '
        'rdbDiagonalAxis1
        '
        Me.rdbDiagonalAxis1.AutoSize = True
        Me.rdbDiagonalAxis1.Location = New System.Drawing.Point(6, 88)
        Me.rdbDiagonalAxis1.Name = "rdbDiagonalAxis1"
        Me.rdbDiagonalAxis1.Size = New System.Drawing.Size(97, 17)
        Me.rdbDiagonalAxis1.TabIndex = 4
        Me.rdbDiagonalAxis1.Text = "\ Diagonal Axis"
        Me.rdbDiagonalAxis1.UseVisualStyleBackColor = True
        '
        'rdbVerticalAxis
        '
        Me.rdbVerticalAxis.AutoSize = True
        Me.rdbVerticalAxis.Location = New System.Drawing.Point(6, 19)
        Me.rdbVerticalAxis.Name = "rdbVerticalAxis"
        Me.rdbVerticalAxis.Size = New System.Drawing.Size(87, 17)
        Me.rdbVerticalAxis.TabIndex = 3
        Me.rdbVerticalAxis.Text = "| Vertical Axis"
        Me.rdbVerticalAxis.UseVisualStyleBackColor = True
        '
        'rdbHorizontalAxis
        '
        Me.rdbHorizontalAxis.AutoSize = True
        Me.rdbHorizontalAxis.Location = New System.Drawing.Point(6, 42)
        Me.rdbHorizontalAxis.Name = "rdbHorizontalAxis"
        Me.rdbHorizontalAxis.Size = New System.Drawing.Size(100, 17)
        Me.rdbHorizontalAxis.TabIndex = 2
        Me.rdbHorizontalAxis.Text = "- Horizontal Axis"
        Me.rdbHorizontalAxis.UseVisualStyleBackColor = True
        '
        'btnMirrorMap
        '
        Me.btnMirrorMap.Location = New System.Drawing.Point(6, 157)
        Me.btnMirrorMap.Name = "btnMirrorMap"
        Me.btnMirrorMap.Size = New System.Drawing.Size(174, 29)
        Me.btnMirrorMap.TabIndex = 1
        Me.btnMirrorMap.Text = "Mirror Map"
        Me.btnMirrorMap.UseVisualStyleBackColor = True
        '
        'btnMoveMapLeft
        '
        Me.btnMoveMapLeft.Location = New System.Drawing.Point(11, 79)
        Me.btnMoveMapLeft.Name = "btnMoveMapLeft"
        Me.btnMoveMapLeft.Size = New System.Drawing.Size(54, 54)
        Me.btnMoveMapLeft.TabIndex = 1
        Me.btnMoveMapLeft.Text = "Left"
        Me.btnMoveMapLeft.UseVisualStyleBackColor = True
        '
        'btnMoveMapUp
        '
        Me.btnMoveMapUp.Location = New System.Drawing.Point(66, 19)
        Me.btnMoveMapUp.Name = "btnMoveMapUp"
        Me.btnMoveMapUp.Size = New System.Drawing.Size(54, 54)
        Me.btnMoveMapUp.TabIndex = 2
        Me.btnMoveMapUp.Text = "Up"
        Me.btnMoveMapUp.UseVisualStyleBackColor = True
        '
        'btnMoveMapDown
        '
        Me.btnMoveMapDown.Location = New System.Drawing.Point(66, 133)
        Me.btnMoveMapDown.Name = "btnMoveMapDown"
        Me.btnMoveMapDown.Size = New System.Drawing.Size(54, 54)
        Me.btnMoveMapDown.TabIndex = 3
        Me.btnMoveMapDown.Text = "Down"
        Me.btnMoveMapDown.UseVisualStyleBackColor = True
        '
        'btnMoveMapRight
        '
        Me.btnMoveMapRight.Location = New System.Drawing.Point(123, 79)
        Me.btnMoveMapRight.Name = "btnMoveMapRight"
        Me.btnMoveMapRight.Size = New System.Drawing.Size(54, 54)
        Me.btnMoveMapRight.TabIndex = 4
        Me.btnMoveMapRight.Text = "Right"
        Me.btnMoveMapRight.UseVisualStyleBackColor = True
        '
        'lstMoveMap
        '
        Me.lstMoveMap.FormattingEnabled = True
        Me.lstMoveMap.Items.AddRange(New Object() {"1/128", "1/64", "1/32", "1/16", "1/8", "1/4", "1/2"})
        Me.lstMoveMap.Location = New System.Drawing.Point(67, 75)
        Me.lstMoveMap.Name = "lstMoveMap"
        Me.lstMoveMap.Size = New System.Drawing.Size(54, 56)
        Me.lstMoveMap.TabIndex = 1
        '
        'grpMoveRotateMap
        '
        Me.grpMoveRotateMap.Controls.Add(Me.btnRotateMap)
        Me.grpMoveRotateMap.Controls.Add(Me.lstMoveMap)
        Me.grpMoveRotateMap.Controls.Add(Me.btnMoveMapUp)
        Me.grpMoveRotateMap.Controls.Add(Me.btnMoveMapRight)
        Me.grpMoveRotateMap.Controls.Add(Me.btnMoveMapLeft)
        Me.grpMoveRotateMap.Controls.Add(Me.btnMoveMapDown)
        Me.grpMoveRotateMap.Location = New System.Drawing.Point(15, 226)
        Me.grpMoveRotateMap.Name = "grpMoveRotateMap"
        Me.grpMoveRotateMap.Size = New System.Drawing.Size(185, 229)
        Me.grpMoveRotateMap.TabIndex = 1
        Me.grpMoveRotateMap.TabStop = False
        Me.grpMoveRotateMap.Text = "Move && Rotate Map"
        '
        'btnRotateMap
        '
        Me.btnRotateMap.Location = New System.Drawing.Point(11, 189)
        Me.btnRotateMap.Name = "btnRotateMap"
        Me.btnRotateMap.Size = New System.Drawing.Size(166, 34)
        Me.btnRotateMap.TabIndex = 5
        Me.btnRotateMap.Text = "Rotate Map Clockwise"
        Me.btnRotateMap.UseVisualStyleBackColor = True
        '
        'grpPreviewMap
        '
        Me.grpPreviewMap.Controls.Add(Me.imgMap)
        Me.grpPreviewMap.Location = New System.Drawing.Point(203, 27)
        Me.grpPreviewMap.Name = "grpPreviewMap"
        Me.grpPreviewMap.Size = New System.Drawing.Size(417, 428)
        Me.grpPreviewMap.TabIndex = 2
        Me.grpPreviewMap.TabStop = False
        Me.grpPreviewMap.Text = "Preview Map"
        '
        'imgMap
        '
        Me.imgMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgMap.Location = New System.Drawing.Point(15, 25)
        Me.imgMap.Name = "imgMap"
        Me.imgMap.Size = New System.Drawing.Size(386, 386)
        Me.imgMap.TabIndex = 0
        Me.imgMap.TabStop = False
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(630, 24)
        Me.MenuStrip.TabIndex = 3
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ToolStripSeparator1, Me.RandomMapToolStripMenuItem, Me.SaveHeightMapToolStripMenuItem, Me.ToolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.OpenToolStripMenuItem.Text = "&Open Map"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SaveToolStripMenuItem.Text = "Save Map As..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(187, 6)
        '
        'SaveHeightMapToolStripMenuItem
        '
        Me.SaveHeightMapToolStripMenuItem.Name = "SaveHeightMapToolStripMenuItem"
        Me.SaveHeightMapToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SaveHeightMapToolStripMenuItem.Text = "Save Height Map As..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(187, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        Me.EditToolStripMenuItem.Visible = False
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Enabled = False
        Me.UndoToolStripMenuItem.Image = CType(resources.GetObject("UndoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UndoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UndoToolStripMenuItem.Text = "&Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Enabled = False
        Me.RedoToolStripMenuItem.Image = CType(resources.GetObject("RedoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RedoToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RedoToolStripMenuItem.Text = "&Redo"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowSymmetryLinesToolStripMenuItem, Me.ShowSouceToolStripMenuItem, Me.ShowObjectsToolStripMenuItem, Me.ToolStripSeparator5, Me.MirrorRotateLandToolStripMenuItem, Me.MirrorRotateObjectsToolStripMenuItem, Me.ToolStripSeparator4, Me.ReplicateObjectsToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ShowSymmetryLinesToolStripMenuItem
        '
        Me.ShowSymmetryLinesToolStripMenuItem.Checked = True
        Me.ShowSymmetryLinesToolStripMenuItem.CheckOnClick = True
        Me.ShowSymmetryLinesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowSymmetryLinesToolStripMenuItem.Name = "ShowSymmetryLinesToolStripMenuItem"
        Me.ShowSymmetryLinesToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ShowSymmetryLinesToolStripMenuItem.Text = "Show Symmetry Lines"
        '
        'ShowSouceToolStripMenuItem
        '
        Me.ShowSouceToolStripMenuItem.Checked = True
        Me.ShowSouceToolStripMenuItem.CheckOnClick = True
        Me.ShowSouceToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowSouceToolStripMenuItem.Name = "ShowSouceToolStripMenuItem"
        Me.ShowSouceToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ShowSouceToolStripMenuItem.Text = "Show Source"
        '
        'ShowObjectsToolStripMenuItem
        '
        Me.ShowObjectsToolStripMenuItem.Checked = True
        Me.ShowObjectsToolStripMenuItem.CheckOnClick = True
        Me.ShowObjectsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowObjectsToolStripMenuItem.Name = "ShowObjectsToolStripMenuItem"
        Me.ShowObjectsToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ShowObjectsToolStripMenuItem.Text = "Show Objects"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(187, 6)
        '
        'MirrorRotateLandToolStripMenuItem
        '
        Me.MirrorRotateLandToolStripMenuItem.Checked = True
        Me.MirrorRotateLandToolStripMenuItem.CheckOnClick = True
        Me.MirrorRotateLandToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MirrorRotateLandToolStripMenuItem.Name = "MirrorRotateLandToolStripMenuItem"
        Me.MirrorRotateLandToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.MirrorRotateLandToolStripMenuItem.Text = "Mirror/Rotate Land"
        '
        'MirrorRotateObjectsToolStripMenuItem
        '
        Me.MirrorRotateObjectsToolStripMenuItem.Checked = True
        Me.MirrorRotateObjectsToolStripMenuItem.CheckOnClick = True
        Me.MirrorRotateObjectsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MirrorRotateObjectsToolStripMenuItem.Name = "MirrorRotateObjectsToolStripMenuItem"
        Me.MirrorRotateObjectsToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.MirrorRotateObjectsToolStripMenuItem.Text = "Mirror/Rotate Objects"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(187, 6)
        '
        'ReplicateObjectsToolStripMenuItem
        '
        Me.ReplicateObjectsToolStripMenuItem.Name = "ReplicateObjectsToolStripMenuItem"
        Me.ReplicateObjectsToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ReplicateObjectsToolStripMenuItem.Text = "Replicate Objects"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Help2ToolStripMenuItem, Me.ToolStripSeparator3, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'Help2ToolStripMenuItem
        '
        Me.Help2ToolStripMenuItem.Image = CType(resources.GetObject("Help2ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.Help2ToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.Help2ToolStripMenuItem.Name = "Help2ToolStripMenuItem"
        Me.Help2ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F1), System.Windows.Forms.Keys)
        Me.Help2ToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.Help2ToolStripMenuItem.Text = "&Help"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(142, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.AboutToolStripMenuItem.Text = "About..."
        '
        'RandomMapToolStripMenuItem
        '
        Me.RandomMapToolStripMenuItem.Name = "RandomMapToolStripMenuItem"
        Me.RandomMapToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.RandomMapToolStripMenuItem.Text = "Random Map"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 463)
        Me.Controls.Add(Me.grpPreviewMap)
        Me.Controls.Add(Me.grpMoveRotateMap)
        Me.Controls.Add(Me.grpMirrorMap)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Populous Symmetry Tool"
        Me.grpMirrorMap.ResumeLayout(False)
        Me.grpMirrorMap.PerformLayout()
        Me.grpMoveRotateMap.ResumeLayout(False)
        Me.grpPreviewMap.ResumeLayout(False)
        CType(Me.imgMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpMirrorMap As System.Windows.Forms.GroupBox
    Friend WithEvents btnMoveMapRight As System.Windows.Forms.Button
    Friend WithEvents btnMoveMapDown As System.Windows.Forms.Button
    Friend WithEvents btnMoveMapUp As System.Windows.Forms.Button
    Friend WithEvents btnMoveMapLeft As System.Windows.Forms.Button
    Friend WithEvents btnMirrorMap As System.Windows.Forms.Button
    Friend WithEvents lstMoveMap As System.Windows.Forms.ListBox
    Friend WithEvents grpMoveRotateMap As System.Windows.Forms.GroupBox
    Friend WithEvents grpPreviewMap As System.Windows.Forms.GroupBox
    Friend WithEvents btnRotateMap As System.Windows.Forms.Button
    Friend WithEvents rdbVerticalAxis As System.Windows.Forms.RadioButton
    Friend WithEvents rdbHorizontalAxis As System.Windows.Forms.RadioButton
    Friend WithEvents imgMap As System.Windows.Forms.PictureBox
    Friend WithEvents rdbCrossAxis As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDiagonalAxis2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbBothAxis As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDiagonalAxis1 As System.Windows.Forms.RadioButton
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveHeightMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowSymmetryLinesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowObjectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowSouceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Help2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ReplicateObjectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MirrorRotateLandToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MirrorRotateObjectsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RandomMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
