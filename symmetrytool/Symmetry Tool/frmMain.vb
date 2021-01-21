Imports System.Runtime.InteropServices
Public Class frmMain
    Dim CurrentFilename As String
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstMoveMap.SelectedIndex = 0
        HSLtoRGB(24, 224, 115)
    End Sub

    Private Sub ReplicateObjectsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplicateObjectsToolStripMenuItem.Click
        frmReplicateObjects.ShowDialog()
    End Sub

    Private Sub imgMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles imgMap.MouseMove
        Me.Text = "Populous Symmetry Tool - " & e.X \ 3 & " x " & 128 - (e.Y \ 3)
    End Sub

    Private Sub imgMap_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles imgMap.Paint
        Dim x, y As Integer, Shade As Boolean
        Dim BrushColour As New SolidBrush(Color.Black)
        Dim TreePnts(2) As Point
        For y = 0 To 127
            For x = 0 To 127
                If ShowSouceToolStripMenuItem.Checked Then
                    'Light up source portion
                    Shade = True
                    If rdbVerticalAxis.Checked Then
                        If x > 63 Then Shade = False
                    ElseIf rdbHorizontalAxis.Checked Then
                        If y < 64 Then Shade = False
                    ElseIf rdbBothAxis.Checked Then
                        If x > 63 Then Shade = False
                        If y < 64 Then Shade = False
                    ElseIf rdbDiagonalAxis1.Checked Then
                        If x >= y Then Shade = False
                    ElseIf rdbDiagonalAxis2.Checked Then
                        If x + y > 126 Then Shade = False
                    ElseIf rdbCrossAxis.Checked Then
                        If x >= y Then Shade = False
                        If x + y > 126 Then Shade = False
                    End If
                End If
                BrushColour.Color = GetLandColour(Land(x, 127 - y), Shade)
                e.Graphics.FillRectangle(BrushColour, x * 3, y * 3, 3, 3)
            Next
        Next
        If ShowObjectsToolStripMenuItem.Checked Then
            For x = 0 To 2000
                If Objects(x, 0) <> 0 Or Objects(x, 1) <> 0 Then
                    Select Case Objects(x, 2)
                        Case 0
                            BrushColour.Color = Color.Blue
                        Case 1
                            BrushColour.Color = Color.Red
                        Case 2
                            BrushColour.Color = Color.Yellow
                        Case 3
                            BrushColour.Color = Color.Green
                        Case Else
                            BrushColour.Color = Color.White
                    End Select
                    e.Graphics.DrawRectangle(Pens.Black, (Objects(x, 4) \ 2) * 3, ((255 - Objects(x, 6)) \ 2) * 3, 3, 3)
                    e.Graphics.FillRectangle(BrushColour, (Objects(x, 4) \ 2) * 3 + 1, ((255 - Objects(x, 6)) \ 2) * 3 + 1, 2, 2)
                End If
            Next
        End If
        If ShowSymmetryLinesToolStripMenuItem.Checked Then
            'Draw axis lines
            If rdbVerticalAxis.Checked Then
                e.Graphics.DrawLine(Pens.Black, 0, 0, 0, 383)
                e.Graphics.DrawLine(Pens.Black, 191, 0, 191, 383)
                e.Graphics.DrawLine(Pens.Black, 383, 0, 383, 383)
            ElseIf rdbHorizontalAxis.Checked Then
                e.Graphics.DrawLine(Pens.Black, 0, 0, 383, 0)
                e.Graphics.DrawLine(Pens.Black, 0, 191, 383, 191)
                e.Graphics.DrawLine(Pens.Black, 0, 383, 383, 383)
            ElseIf rdbBothAxis.Checked Then
                e.Graphics.DrawLine(Pens.Black, 0, 0, 0, 383)
                e.Graphics.DrawLine(Pens.Black, 191, 0, 191, 383)
                e.Graphics.DrawLine(Pens.Black, 383, 0, 383, 383)
                e.Graphics.DrawLine(Pens.Black, 0, 0, 383, 0)
                e.Graphics.DrawLine(Pens.Black, 0, 191, 383, 191)
                e.Graphics.DrawLine(Pens.Black, 0, 383, 383, 383)
            ElseIf rdbDiagonalAxis1.Checked Then
                e.Graphics.DrawLine(Pens.Black, 0, 0, 383, 383)
            ElseIf rdbDiagonalAxis2.Checked Then
                e.Graphics.DrawLine(Pens.Black, 0, 383, 383, 0)
            ElseIf rdbCrossAxis.Checked Then
                e.Graphics.DrawLine(Pens.Black, 0, 0, 383, 383)
                e.Graphics.DrawLine(Pens.Black, 0, 383, 383, 0)
            End If
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim OpenBox As New OpenFileDialog
        OpenBox.InitialDirectory = PopDir
        OpenBox.Filter = "Populous Level Files (levl2*.dat)|levl2*.dat|Populous Level Files (*.dat)|*.dat"
        If OpenBox.ShowDialog = Windows.Forms.DialogResult.OK Then
            OpenLevel(OpenBox.FileName)
            CurrentFilename = OpenBox.FileName
            imgMap.Refresh()
        End If
    End Sub

    Private Sub btnMoveMapUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveMapUp.Click
        Dim Amount As Byte
        Select Case lstMoveMap.SelectedIndex
            Case 0
                Amount = 1
            Case 1
                Amount = 2
            Case 2
                Amount = 4
            Case 3
                Amount = 8
            Case 4
                Amount = 16
            Case 5
                Amount = 32
            Case 6
                Amount = 64
        End Select
        MoveMap(Amount, Direction.Up)
        imgMap.Refresh()
    End Sub

    Private Sub btnMoveMapDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveMapDown.Click
        Dim Amount As Byte
        Select Case lstMoveMap.SelectedIndex
            Case 0
                Amount = 1
            Case 1
                Amount = 2
            Case 2
                Amount = 4
            Case 3
                Amount = 8
            Case 4
                Amount = 16
            Case 5
                Amount = 32
            Case 6
                Amount = 64
        End Select
        MoveMap(Amount, Direction.Down)
        imgMap.Refresh()
    End Sub

    Private Sub btnMoveMapLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveMapLeft.Click
        Dim Amount As Byte
        Select Case lstMoveMap.SelectedIndex
            Case 0
                Amount = 1
            Case 1
                Amount = 2
            Case 2
                Amount = 4
            Case 3
                Amount = 8
            Case 4
                Amount = 16
            Case 5
                Amount = 32
            Case 6
                Amount = 64
        End Select
        MoveMap(Amount, Direction.Left)
        imgMap.Refresh()
    End Sub

    Private Sub btnMoveMapRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveMapRight.Click
        Dim Amount As Byte
        Select Case lstMoveMap.SelectedIndex
            Case 0
                Amount = 1
            Case 1
                Amount = 2
            Case 2
                Amount = 4
            Case 3
                Amount = 8
            Case 4
                Amount = 16
            Case 5
                Amount = 32
            Case 6
                Amount = 64
        End Select
        MoveMap(Amount, Direction.Right)
        imgMap.Refresh()
    End Sub

    Private Sub btnRotateMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotateMap.Click
        RotateMap()
        imgMap.Refresh()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim SaveBox As New SaveFileDialog
        SaveBox.FileName = CurrentFilename
        SaveBox.Filter = "Populous Level Files (levl2*.dat)|levl2*.dat|Populous Level Files (*.dat)|*.dat"
        If SaveBox.ShowDialog = Windows.Forms.DialogResult.OK Then
            SaveLevel(SaveBox.FileName)
            CurrentFilename = SaveBox.FileName
            imgMap.Refresh()
        End If
    End Sub

    Private Sub RefreshMap(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowObjectsToolStripMenuItem.Click _
                                                                                             , ShowSouceToolStripMenuItem.Click _
                                                                                             , ShowSymmetryLinesToolStripMenuItem.Click _
                                                                                             , rdbVerticalAxis.Click _
                                                                                             , rdbHorizontalAxis.Click _
                                                                                             , rdbBothAxis.Click _
                                                                                             , rdbDiagonalAxis1.Click _
                                                                                             , rdbDiagonalAxis2.Click _
                                                                                             , rdbCrossAxis.Click
        imgMap.Refresh()
    End Sub

    Private Sub btnMirrorMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMirrorMap.Click
        MirrorMap()
        imgMap.Refresh()
    End Sub

    Private Sub SaveHeightMapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveHeightMapToolStripMenuItem.Click
        Dim SaveBox As New SaveFileDialog
        SaveBox.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        SaveBox.Filter = "24-bit Bitmap (*.bmp)|*.bmp"
        If SaveBox.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Bmp As New Bitmap(380, 380)
            imgMap.DrawToBitmap(Bmp, New System.Drawing.Rectangle(0, 0, 380, 380))
            Bmp.Save(SaveBox.FileName)
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        Undo()
        imgMap.Refresh()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        Redo()
        imgMap.Refresh()
    End Sub

    Private Sub Help2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Help2ToolStripMenuItem.Click
        Dim helpfile As String = My.Application.Info.DirectoryPath & "\help.chm"
        If My.Computer.FileSystem.FileExists(helpfile) Then
            Dim objProcess As New System.Diagnostics.Process
            objProcess.StartInfo.FileName = helpfile
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            objProcess.Start()
        Else
            MsgBox("Could not find '" & helpfile & "'.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    <DllImport("C:\Users\Ted\Documents\Visual Studio 2008\Projects\Populous\Random Map Generator\C++\Release\PopulousRMG.dll", ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall, _
    CharSet:=CharSet.Ansi)> _
    Shared Sub GenerateMap(ByVal dat As IntPtr, ByVal hdr As IntPtr, ByRef rms As Byte, ByVal players As Integer, ByVal seed As Integer)
        'Shared Sub GenerateMap(ByVal dat As IntPtr, ByVal hdr As IntPtr, ByVal rms As IntPtr, ByVal players As Integer, ByVal seed As Integer)
    End Sub
    Const DatSize = 192137
    Const HdrSize = 616
    Const RmsSize = 6100

    Private Sub RandomMapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomMapToolStripMenuItem.Click
        Dim DatPtr As IntPtr = Marshal.AllocCoTaskMem(DatSize)
        Dim HdrPtr As IntPtr = Marshal.AllocCoTaskMem(HdrSize)

        Dim MapRms(RmsSize - 1) As Byte
        FileOpen(1, "C:\Users\Ted\Documents\Populous\rmg\scripts\Completed Scripts\Migration (4).rms", OpenMode.Binary)
        FileGet(1, MapRms)
        FileClose(1)


        Dim RmsPtr As IntPtr
        'Marshal.StructureToPtr(MapRms, RmsPtr, False)


        'GenerateMap(DatPtr, HdrPtr, RmsPtr, 4, 2423)
        GenerateMap(DatPtr, HdrPtr, MapRms(0), 4, 2423)

        Dim MapDat(DatSize) As Byte
        Dim MapHdr(HdrSize) As Byte

        Marshal.Copy(DatPtr, MapDat, 0, DatSize - 1)
        Marshal.Copy(HdrPtr, MapHdr, 0, HdrSize - 1)
        Marshal.FreeCoTaskMem(DatPtr)
        Marshal.FreeCoTaskMem(HdrPtr)

        'Set level to file memory
        For y As Integer = 0 To 127
            For x As Integer = 0 To 127
                Land(x, y) = MapDat(y * 127 + x)
            Next
        Next
        For x As Integer = 0 To 2000
            For y As Integer = 0 To 54
                Objects(x, y) = MapDat(x * 55 + y + 49152 + 64 + 2)
            Next
        Next
        imgMap.Refresh()
    End Sub
End Class
