Module modLevel

    Public Structure TriggerReference
        Public Reference As Short
        Public CopyRef1 As Short
        Public CopyRef2 As Short
        Public CopyRef3 As Short
    End Structure

    Public Const PopDir = "C:\Program Files\Bullfrog\Populous\Levels\"

    Public Land(128, 128) As Short
    Public Objects(2000, 55) As Byte

    Public CPLand(11, 128, 128) As Short
    Public CPObjects(11, 2000, 55) As Byte
    Public UndoCount As Byte
    Public RedoCount As Byte
    Public CPIndex As Byte

    Public Enum Direction
        Up
        Down
        Right
        Left
    End Enum

    Public Sub OpenLevel(ByVal Filename As String)
        Try
            Dim x, y As Integer, passbyte As Byte
            FileOpen(1, Filename, OpenMode.Binary)
            For y = 0 To 127
                For x = 0 To 127
                    FileGet(1, Land(x, y))
                Next
            Next
            For x = 0 To 49152 + 64 + 2
                FileGet(1, passbyte)
            Next
            For x = 0 To 2000
                For y = 0 To 54
                    FileGet(1, Objects(x, y))
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            FileClose(1)
        End Try
    End Sub

    Public Sub SaveLevel(ByVal Filename As String)
        'SortMap()
        Try
            Dim x, y As Integer, passbyte As Byte
            FileOpen(1, Filename, OpenMode.Output)
            FileClose(1)
            FileOpen(1, Filename, OpenMode.Binary)
            For y = 0 To 127
                For x = 0 To 127
                    FilePut(1, Land(x, y))
                Next
            Next
            For x = 0 To 49152 + 64 + 2
                FilePut(1, passbyte)
            Next
            For x = 0 To 2000
                For y = 0 To 54
                    FilePut(1, Objects(x, y))
                Next
            Next
            For x = 1 To 95
                FilePut(1, passbyte)
            Next
        Catch ex As Exception
        Finally
            FileClose(1)
        End Try
    End Sub

    Public Sub SortMap()
        Dim ObjectsDone(2000) As Boolean
        Dim SortObjects(2000, 55) As Byte
        Dim NewObjectID(2000), lastid As Short
        Dim i, j, k As Integer

        For j = 1 To 255
            For i = 1 To 255
                For k = 0 To 1999
                    If Objects(k, 0) = i And Objects(k, 1) = j And Not ObjectsDone(k) Then
                        NewObjectID(k) = lastid + 1
                        ObjectsDone(k) = True
                        lastid += 1
                    End If
                Next
            Next
        Next
        'Re-Write Objects
        For i = 0 To 2000
            For j = 0 To 2000
                If NewObjectID(j) = i Then
                    k = j
                    Exit For
                End If
            Next
            For j = 0 To 55
                SortObjects(i, j) = Objects(k, j)
            Next
        Next
        For i = 0 To 2000
            For j = 0 To 55
                Objects(i, j) = SortObjects(i, j)
            Next
        Next
        Exit Sub

        'Wildmen
        For i = 0 To 2000
            If Objects(i, 0) = 1 And Objects(i, 1) = 1 And Objects(i, 2) = 255 And Not ObjectsDone(i) Then
                NewObjectID(i) = lastid + 1
                ObjectsDone(i) = True
                lastid += 1
            End If
        Next
        'Trees
        For i = 0 To 2000
            If Objects(i, 0) < 7 And Objects(i, 1) = 5 And Objects(i, 2) = 255 And Not ObjectsDone(i) Then
                NewObjectID(i) = lastid + 1
                ObjectsDone(i) = True
                lastid += 1
            End If
        Next
        'Any other wild stuff
        For i = 0 To 2000
            If Objects(i, 2) = 255 And Not ObjectsDone(i) Then
                NewObjectID(i) = lastid + 1
                ObjectsDone(i) = True
                lastid += 1
            End If
        Next
        'Blue followers, buildings, other
        'Red -
        'Yellow -
        'Green -
        'Discoverys
        'Triggers

        'Re-Write Objects
        For i = 0 To 2000
            For j = 0 To 55
                Objects(i, j) = Objects(NewObjectID(i), j)
            Next
        Next
    End Sub

    Public Sub MoveMap(ByVal Amount As Byte, ByVal Direction As Direction)
        Dim copymap(128, 128) As Short, X As Long, Y As Long
        Call Checkpoint() 'take checkpoint for undo
        For X = 0 To 127
            For Y = 0 To 127
                copymap(X, Y) = Land(X, Y)
            Next
        Next
        Select Case Direction
            Case modLevel.Direction.Up
                If frmMain.MirrorRotateLandToolStripMenuItem.Checked Then
                    For Y = 0 To 127
                        For X = 0 To 127
                            Land(X, Y) = copymap(X, (Y - Amount + 128) Mod 128)
                        Next
                    Next
                End If
                If frmMain.MirrorRotateObjectsToolStripMenuItem.Checked Then
                    For X = 0 To 2000
                        Objects(X, 6) = (Objects(X, 6) + Amount * 2) Mod 256
                        If Objects(X, 0) = 24 And Objects(X, 1) = 7 Then
                            Objects(X, 12) = (Objects(X, 12) + Amount * 2) Mod 256
                        End If
                    Next
                End If
            Case modLevel.Direction.Down
                If frmMain.MirrorRotateLandToolStripMenuItem.Checked Then
                    For Y = 0 To 127
                        For X = 0 To 127
                            Land(X, Y) = copymap(X, (Y + Amount + 128) Mod 128)
                        Next
                    Next
                End If
                If frmMain.MirrorRotateObjectsToolStripMenuItem.Checked Then
                    For X = 0 To 2000
                        Objects(X, 6) = (Objects(X, 6) + 256 - Amount * 2) Mod 256
                        If Objects(X, 0) = 24 And Objects(X, 1) = 7 Then
                            Objects(X, 12) = (Objects(X, 12) + 256 - Amount * 2) Mod 256
                        End If
                    Next
                End If
            Case modLevel.Direction.Left
                If frmMain.MirrorRotateLandToolStripMenuItem.Checked Then
                    For X = 0 To 127
                        For Y = 0 To 127
                            Land(X, Y) = copymap((X + Amount + 128) Mod 128, Y)
                        Next
                    Next
                End If
                If frmMain.MirrorRotateObjectsToolStripMenuItem.Checked Then
                    For X = 0 To 2000
                        Objects(X, 4) = (Objects(X, 4) + 256 - Amount * 2) Mod 256
                        If Objects(X, 0) = 24 And Objects(X, 1) = 7 Then
                            Objects(X, 8) = (Objects(X, 8) + 256 - Amount * 2) Mod 256
                        End If
                    Next
                End If
            Case modLevel.Direction.Right
                If frmMain.MirrorRotateLandToolStripMenuItem.Checked Then
                    For X = 0 To 127
                        For Y = 0 To 127
                            Land(X, Y) = copymap((X - Amount + 128) Mod 128, Y)
                        Next
                    Next
                End If
                If frmMain.MirrorRotateObjectsToolStripMenuItem.Checked Then
                    For X = 0 To 2000
                        Objects(X, 4) = (Objects(X, 4) + Amount * 2) Mod 256
                        If Objects(X, 0) = 24 And Objects(X, 1) = 7 Then
                            Objects(X, 8) = (Objects(X, 8) + Amount * 2) Mod 256
                        End If
                    Next
                End If
        End Select
    End Sub

    Public Sub RotateMap()
        Dim x, y As Integer, copymap(128, 128) As Short
        Call Checkpoint() 'take checkpoint for undo
        For x = 0 To 127
            For y = 0 To 127
                copymap(x, y) = Land(x, y)
            Next
        Next
        For x = 0 To 127
            For y = 0 To 127
                Land(x, y) = copymap(127 - y, x)    'Rotate clockwise
            Next
        Next
        For x = 0 To 2000
            If Objects(x, 0) <> 0 Or Objects(x, 1) <> 0 Then
                y = Objects(x, 4)
                Objects(x, 4) = Objects(x, 6)
                Objects(x, 6) = 255 - y
                If Objects(x, 1) = 5 Then
                    Objects(x, 11) = (Objects(x, 11) + 2) Mod 8 'Angle (Scenery)
                ElseIf Objects(x, 1) = 2 Then
                    Objects(x, 8) = (Objects(x, 8) + 2) Mod 8   'Angle (Buildings)
                End If
                If Objects(x, 0) = 24 And Objects(x, 1) = 7 Then
                    'Landbridge Effect
                    y = Objects(x, 8)
                    Objects(x, 8) = Objects(x, 12)
                    Objects(x, 12) = 255 - y
                End If
            End If
        Next
    End Sub

    Public Sub MirrorMap()
        Dim x, y, z, slot As Integer, copies, refnumber, nextref, copymap(128, 128) As Short, lastcolour, preX As Byte
        Dim Refs(2000) As TriggerReference
        Call Checkpoint() 'take checkpoint for undo
        For x = 0 To 127
            For y = 0 To 127
                copymap(x, y) = Land(x, y)
            Next
        Next
        If frmMain.rdbVerticalAxis.Checked Then
            '-------------------------------------------------------------------------------------
            '---------------------------------|-VERTICAL AXIS-------------------------------------
            '-------------------------------------------------------------------------------------
            If frmMain.MirrorRotateLandToolStripMenuItem.Checked Then
                'Mirror Land
                For y = 0 To 127
                    For x = 64 To 127
                        Land(x, y) = copymap(127 - x, y)
                    Next
                Next
            End If
            If frmMain.MirrorRotateObjectsToolStripMenuItem.Checked Then
                'Before Mirror Objects
                'Keep trigger references
                nextref = 0 'To be safe doesn't really matter beacause it's local!
                For x = 0 To 2000
                    If Objects(x, 0) = 6 And Objects(x, 1) = 6 Then
                        For z = 13 To 31 Step 2
                            refnumber = ToShort(Objects(x, z), Objects(x, z + 1))
                            If refnumber > 0 Then
                                Refs(nextref).Reference = refnumber
                                nextref += 1
                            End If
                        Next
                    End If
                Next
                'Mirror Objects
                For x = 0 To 2000
                    If Objects(x, 4) > 127 Then
                        DeleteObject(x)             'Delete objects
                        If x > 0 Then
                            For y = 0 To 2000
                                If Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                                    For z = 13 To 31 Step 2    'Remove references to deleted objects
                                        If ToShort(Objects(y, z), Objects(y, z + 1)) = x + 1 Then
                                            Objects(y, z) = 0
                                            Objects(y, z + 1) = 0
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    End If
                Next
                For x = 0 To 2000
                    If Objects(x, 4) < 128 Then
                        slot = SpareSlot()
                        For y = 0 To 55
                            'Create a new object in a spare slot
                            Objects(slot, y) = Objects(x, y)
                        Next
                        'Add reference for copied object
                        For z = 0 To nextref
                            If x + 1 = Refs(z).Reference Then
                                Refs(z).CopyRef1 = slot + 1
                            End If
                        Next
                        'Change of object Colour
                        If Objects(slot, 0) <> 6 Or Objects(slot, 1) <> 6 Then
                            Objects(slot, 2) = NextObjectColour(Objects(slot, 2))
                        End If
                        'Change x of object
                        Objects(slot, 4) = 255 - Objects(slot, 4)
                        'Angle of Objects
                        If Objects(slot, 1) = 5 Then
                            y = 11  'Angle (Scenery)
                            Objects(slot, y) = (8 - Objects(slot, y)) Mod 8
                        ElseIf Objects(slot, 1) = 2 Then
                            y = 8   'Angle (Buildings)
                            Objects(slot, y) = (8 - Objects(slot, y)) Mod 8
                        End If
                        'Landbridge Effect
                        If Objects(slot, 0) = 24 And Objects(slot, 1) = 7 Then
                            'Landbridge Effect
                            Objects(slot, 8) = 255 - Objects(slot, 8)
                        End If
                    End If
                Next
                'Adjust any references to created mirrored object
                For y = 0 To 2000
                    If Objects(y, 4) > 127 And Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                        For z = 13 To 31 Step 2    'Amend references to mirrored objects
                            refnumber = ToShort(Objects(y, z), Objects(y, z + 1))
                            For x = 0 To nextref
                                If Refs(x).Reference = refnumber Then
                                    ToByte(Objects(y, z), Objects(y, z + 1), Refs(x).CopyRef1)
                                End If
                            Next
                        Next
                    End If
                Next
            End If
        ElseIf frmMain.rdbHorizontalAxis.Checked Then
            '-------------------------------------------------------------------------------------
            '----------------------------------HORIZONTAL AXIS------------------------------------
            '-------------------------------------------------------------------------------------
            If frmMain.MirrorRotateLandToolStripMenuItem.Checked Then
                'Mirror Land
                For x = 0 To 127
                    For y = 64 To 127
                        Land(x, y) = copymap(x, 127 - y)
                    Next
                Next
            End If
            If frmMain.MirrorRotateObjectsToolStripMenuItem.Checked Then
                'Before Mirror Objects
                'Keep trigger references
                nextref = 0 'To be safe doesn't really matter beacause it's local!
                For x = 0 To 2000
                    If Objects(x, 0) = 6 And Objects(x, 1) = 6 Then
                        For z = 13 To 31 Step 2
                            refnumber = ToShort(Objects(x, z), Objects(x, z + 1))
                            If refnumber > 0 Then
                                Refs(nextref).Reference = refnumber
                                nextref += 1
                            End If
                        Next
                    End If
                Next
                'Mirror Objects
                For x = 0 To 2000
                    If Objects(x, 6) > 127 Then
                        DeleteObject(x)             'Delete objects
                        If x > 0 Then
                            For y = 0 To 2000
                                If Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                                    For z = 13 To 31 Step 2    'Remove references to deleted objects
                                        If ToShort(Objects(y, z), Objects(y, z + 1)) = x + 1 Then
                                            Objects(y, z) = 0
                                            Objects(y, z + 1) = 0
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    End If
                Next
                For x = 0 To 2000
                    If Objects(x, 6) < 128 Then
                        slot = SpareSlot()
                        For y = 0 To 55
                            'Create a new object in a spare slot
                            Objects(slot, y) = Objects(x, y)
                        Next
                        'Add reference for copied object
                        For z = 0 To nextref
                            If x + 1 = Refs(z).Reference Then
                                Refs(z).CopyRef1 = slot + 1
                            End If
                        Next
                        'Change of object Colour
                        If Objects(slot, 0) <> 6 Or Objects(slot, 1) <> 6 Then
                            Objects(slot, 2) = NextObjectColour(Objects(slot, 2))
                        End If
                        'Change y of object
                        Objects(slot, 6) = 255 - Objects(slot, 6)
                        'Angle of Objects
                        If Objects(slot, 1) = 5 Then
                            y = 11  'Angle (Scenery)
                            Objects(slot, y) = ((8 - Objects(slot, y)) + 4) Mod 8
                        ElseIf Objects(slot, 1) = 2 Then
                            y = 8   'Angle (Buildings)
                            Objects(slot, y) = ((8 - Objects(slot, y)) + 4) Mod 8
                        End If
                        'Landbridge Effect
                        If Objects(slot, 0) = 24 And Objects(slot, 1) = 7 Then
                            'Landbridge Effect
                            Objects(slot, 12) = 255 - Objects(slot, 12)
                        End If
                    End If
                Next
                'Adjust any references to created mirrored object
                For y = 0 To 2000
                    If Objects(y, 6) > 127 And Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                        For z = 13 To 31 Step 2    'Amend references to mirrored objects
                            refnumber = ToShort(Objects(y, z), Objects(y, z + 1))
                            For x = 0 To nextref
                                If Refs(x).Reference = refnumber Then
                                    ToByte(Objects(y, z), Objects(y, z + 1), Refs(x).CopyRef1)
                                End If
                            Next
                        Next
                    End If
                Next
            End If
        ElseIf frmMain.rdbBothAxis.Checked Then
            '-------------------------------------------------------------------------------------
            '-----------------------------------+-BOTH AXIS---------------------------------------
            '-------------------------------------------------------------------------------------
            If frmMain.MirrorRotateLandToolStripMenuItem.Checked Then
                'Mirror Land
                'Quadrant - Top, Left
                For x = 0 To 64
                    For y = 64 To 127
                        Land(x, y) = copymap(x, 127 - y)
                    Next
                Next
                'Quadrant - Top, Right
                For x = 64 To 127
                    For y = 64 To 127
                        Land(x, y) = Land(127 - x, y)
                    Next
                Next
                'Quadrant - Bottom, Right
                For x = 64 To 127
                    For y = 0 To 64
                        Land(x, y) = Land(x, 127 - y)
                    Next
                Next
            End If
            If frmMain.MirrorRotateObjectsToolStripMenuItem.Checked Then
                'Before Mirror Objects
                'Keep trigger references
                nextref = 0 'To be safe doesn't really matter beacause it's local!
                For x = 0 To 2000
                    If Objects(x, 0) = 6 And Objects(x, 1) = 6 Then
                        For z = 13 To 31 Step 2
                            refnumber = ToShort(Objects(x, z), Objects(x, z + 1))
                            If refnumber > 0 Then
                                Refs(nextref).Reference = refnumber
                                nextref += 1
                            End If
                        Next
                    End If
                Next
                'Mirror Objects
                For x = 0 To 2000
                    If Not (Objects(x, 4) < 128 And Objects(x, 6) < 128) Then
                        DeleteObject(x)             'Delete objects
                        If x > 0 Then
                            For y = 0 To 2000
                                If Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                                    For z = 13 To 31 Step 2    'Remove references to deleted objects
                                        If ToShort(Objects(y, z), Objects(y, z + 1)) = x + 1 Then
                                            Objects(y, z) = 0
                                            Objects(y, z + 1) = 0
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    End If
                Next
                For x = 0 To 2000
                    If Objects(x, 4) < 128 And Objects(x, 6) < 128 Then
                        For copies = 2 To 4
                            slot = SpareSlot()
                            For y = 0 To 55
                                'Create a new object in a spare slot
                                Objects(slot, y) = Objects(x, y)
                            Next
                            'Add reference for copied object
                            For z = 0 To nextref
                                If x + 1 = Refs(z).Reference Then
                                    Select Case copies
                                        Case 2
                                            Refs(z).CopyRef1 = slot + 1
                                        Case 3
                                            Refs(z).CopyRef2 = slot + 1
                                        Case 4
                                            Refs(z).CopyRef3 = slot + 1
                                    End Select
                                End If
                            Next
                            'Change of object Colour
                            If Objects(slot, 0) <> 6 Or Objects(slot, 1) <> 6 Then
                                If copies = 2 Then
                                    lastcolour = NextObjectColour(Objects(slot, 2))
                                    Objects(slot, 2) = lastcolour
                                Else
                                    Objects(slot, 2) = NextObjectColour(lastcolour)
                                    lastcolour = Objects(slot, 2)
                                End If
                            End If
                            'Change x & y of object
                            Select Case copies
                                Case 2
                                    Objects(slot, 6) = 255 - Objects(slot, 6)
                                Case 3
                                    Objects(slot, 4) = 255 - Objects(slot, 4)
                                    Objects(slot, 6) = 255 - Objects(slot, 6)
                                Case 4
                                    Objects(slot, 4) = 255 - Objects(slot, 4)
                            End Select
                            'Angle of Objects
                            If Objects(slot, 1) = 5 Then
                                y = 11  'Angle (Scenery)
                                Select Case copies
                                    Case 2 'Horizontal
                                        Objects(slot, y) = ((8 - Objects(slot, y)) + 4) Mod 8
                                    Case 3 'Both
                                        Objects(slot, y) = (Objects(slot, y) + 4) Mod 8
                                    Case 4 'Vertical
                                        Objects(slot, y) = (8 - Objects(slot, y)) Mod 8
                                End Select
                            ElseIf Objects(slot, 1) = 2 Then
                                y = 8   'Angle (Buildings)
                                Select Case copies
                                    Case 2 'Horizontal
                                        Objects(slot, y) = ((8 - Objects(slot, y)) + 4) Mod 8
                                    Case 3 'Both
                                        Objects(slot, y) = (Objects(slot, y) + 4) Mod 8
                                    Case 4 'Vertical
                                        Objects(slot, y) = (8 - Objects(slot, y)) Mod 8
                                End Select
                            End If
                            'Landbridge Effect
                            If Objects(slot, 0) = 24 And Objects(slot, 1) = 7 Then
                                'Landbridge Effect
                                Select Case copies
                                    Case 2
                                        Objects(slot, 12) = 255 - Objects(slot, 12)
                                    Case 3
                                        Objects(slot, 8) = 255 - Objects(slot, 8)
                                        Objects(slot, 12) = 255 - Objects(slot, 12)
                                    Case 4
                                        Objects(slot, 8) = 255 - Objects(slot, 8)
                                End Select
                            End If
                        Next
                    End If
                Next
                'Adjust any references to created mirrored object
                For y = 0 To 2000
                    If Not (Objects(y, 4) < 128 And Objects(y, 6) < 128) Then
                        If Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                            For z = 13 To 31 Step 2    'Amend references to mirrored objects
                                refnumber = ToShort(Objects(y, z), Objects(y, z + 1))
                                For x = 0 To nextref
                                    If Refs(x).Reference = refnumber Then
                                        If Objects(y, 4) < 128 And Objects(y, 6) > 127 Then
                                            ToByte(Objects(y, z), Objects(y, z + 1), Refs(x).CopyRef1)
                                        ElseIf Objects(y, 4) > 127 And Objects(y, 6) > 127 Then
                                            ToByte(Objects(y, z), Objects(y, z + 1), Refs(x).CopyRef2)
                                        ElseIf Objects(y, 4) > 127 And Objects(y, 6) < 128 Then
                                            ToByte(Objects(y, z), Objects(y, z + 1), Refs(x).CopyRef3)
                                        End If
                                    End If
                                Next
                            Next
                        End If
                    End If
                Next
            End If
        ElseIf frmMain.rdbDiagonalAxis1.Checked Then
            '-------------------------------------------------------------------------------------
            '---------------------------------\-DIAGONAL AXIS-------------------------------------
            '-------------------------------------------------------------------------------------
            If frmMain.MirrorRotateLandToolStripMenuItem.Checked Then
                'Mirror Land
                For x = 0 To 127
                    For y = 0 To 127
                        If y + x >= 127 Then
                            Land(x, y) = copymap(127 - y, 127 - x)
                        End If
                    Next
                Next
            End If
            If frmMain.MirrorRotateObjectsToolStripMenuItem.Checked Then
                'Before Mirror Objects
                'Keep trigger references
                nextref = 0 'To be safe doesn't really matter beacause it's local!
                For x = 0 To 2000
                    If Objects(x, 0) = 6 And Objects(x, 1) = 6 Then
                        For z = 13 To 31 Step 2
                            refnumber = ToShort(Objects(x, z), Objects(x, z + 1))
                            If refnumber > 0 Then
                                Refs(nextref).Reference = refnumber
                                nextref += 1
                            End If
                        Next
                    End If
                Next
                'Mirror Objects
                For x = 0 To 2000
                    If CInt(Objects(x, 4)) + CInt(Objects(x, 6)) >= 255 Then
                        DeleteObject(x)             'Delete objects
                        If x > 0 Then
                            For y = 0 To 2000
                                If Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                                    For z = 13 To 31 Step 2    'Remove references to deleted objects
                                        If ToShort(Objects(y, z), Objects(y, z + 1)) = x + 1 Then
                                            Objects(y, z) = 0
                                            Objects(y, z + 1) = 0
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    End If
                Next
                For x = 0 To 2000
                    If CInt(Objects(x, 4)) + CInt(Objects(x, 6)) < 255 Then
                        slot = SpareSlot()
                        For y = 0 To 55
                            'Create a new object in a spare slot
                            Objects(slot, y) = Objects(x, y)
                        Next
                        'Add reference for copied object
                        For z = 0 To nextref
                            If x + 1 = Refs(z).Reference Then
                                Refs(z).CopyRef1 = slot + 1
                            End If
                        Next
                        'Change of object Colour
                        If Objects(slot, 0) <> 6 Or Objects(slot, 1) <> 6 Then
                            Objects(slot, 2) = NextObjectColour(Objects(slot, 2))
                        End If
                        'Change x & y of object
                        preX = Objects(slot, 4)
                        Objects(slot, 4) = 255 - Objects(slot, 6)
                        Objects(slot, 6) = 255 - preX
                        'Angle of Objects
                        If Objects(slot, 1) = 5 Then
                            y = 11  'Angle (Scenery)
                            Objects(slot, y) = (14 - Objects(slot, y)) Mod 8
                        ElseIf Objects(slot, 1) = 2 Then
                            y = 8   'Angle (Buildings)
                            Objects(slot, y) = (14 - Objects(slot, y)) Mod 8
                        End If
                        'Landbridge Effect
                        If Objects(slot, 0) = 24 And Objects(slot, 1) = 7 Then
                            'Landbridge Effect
                            preX = Objects(slot, 8)
                            Objects(slot, 8) = 255 - Objects(slot, 12)
                            Objects(slot, 12) = 255 - preX
                        End If
                    End If
                Next
                'Adjust any references to created mirrored object
                For y = 0 To 2000
                    If CInt(Objects(y, 4)) + CInt(Objects(y, 6)) >= 255 And Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                        For z = 13 To 31 Step 2    'Amend references to mirrored objects
                            refnumber = ToShort(Objects(y, z), Objects(y, z + 1))
                            For x = 0 To nextref
                                If Refs(x).Reference = refnumber Then
                                    ToByte(Objects(y, z), Objects(y, z + 1), Refs(x).CopyRef1)
                                End If
                            Next
                        Next
                    End If
                Next
            End If
        ElseIf frmMain.rdbDiagonalAxis2.Checked Then
            '-------------------------------------------------------------------------------------
            '---------------------------------/-DIAGONAL AXIS-------------------------------------
            '-------------------------------------------------------------------------------------
            If frmMain.MirrorRotateLandToolStripMenuItem.Checked Then
                'Mirror Land
                For x = 0 To 127
                    For y = 0 To 127
                        If x >= y Then
                            Land(x, y) = copymap(y, x)
                        End If
                    Next
                Next
            End If
            If frmMain.MirrorRotateObjectsToolStripMenuItem.Checked Then
                'Before Mirror Objects
                'Keep trigger references
                nextref = 0 'To be safe doesn't really matter beacause it's local!
                For x = 0 To 2000
                    If Objects(x, 0) = 6 And Objects(x, 1) = 6 Then
                        For z = 13 To 31 Step 2
                            refnumber = ToShort(Objects(x, z), Objects(x, z + 1))
                            If refnumber > 0 Then
                                Refs(nextref).Reference = refnumber
                                nextref += 1
                            End If
                        Next
                    End If
                Next
                'Mirror Objects
                For x = 0 To 2000
                    If Objects(x, 4) >= Objects(x, 6) Then
                        DeleteObject(x)             'Delete objects
                        If x > 0 Then
                            For y = 0 To 2000
                                If Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                                    For z = 13 To 31 Step 2    'Remove references to deleted objects
                                        If ToShort(Objects(y, z), Objects(y, z + 1)) = x + 1 Then
                                            Objects(y, z) = 0
                                            Objects(y, z + 1) = 0
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    End If
                Next
                For x = 0 To 2000
                    If Objects(x, 4) < Objects(x, 6) Then
                        slot = SpareSlot()
                        For y = 0 To 55
                            'Create a new object in a spare slot
                            Objects(slot, y) = Objects(x, y)
                        Next
                        'Add reference for copied object
                        For z = 0 To nextref
                            If x + 1 = Refs(z).Reference Then
                                Refs(z).CopyRef1 = slot + 1
                            End If
                        Next
                        'Change of object Colour
                        If Objects(slot, 0) <> 6 Or Objects(slot, 1) <> 6 Then
                            Objects(slot, 2) = NextObjectColour(Objects(slot, 2))
                        End If
                        'Change x & y of object
                        preX = Objects(slot, 4)
                        Objects(slot, 4) = Objects(slot, 6)
                        Objects(slot, 6) = preX
                        'Angle of Objects
                        If Objects(slot, 1) = 5 Then
                            y = 11  'Angle (Scenery)
                            Objects(slot, y) = (10 - Objects(slot, y)) Mod 8
                        ElseIf Objects(slot, 1) = 2 Then
                            y = 8   'Angle (Buildings)
                            Objects(slot, y) = (10 - Objects(slot, y)) Mod 8
                        End If
                        'Landbridge Effect
                        If Objects(slot, 0) = 24 And Objects(slot, 1) = 7 Then
                            'Landbridge Effect
                            preX = Objects(slot, 8)
                            Objects(slot, 8) = Objects(slot, 12)
                            Objects(slot, 12) = preX
                        End If
                    End If
                Next
                'Adjust any references to created mirrored object
                For y = 0 To 2000
                    If Objects(y, 4) >= Objects(y, 6) And Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                        For z = 13 To 31 Step 2    'Amend references to mirrored objects
                            refnumber = ToShort(Objects(y, z), Objects(y, z + 1))
                            For x = 0 To nextref
                                If Refs(x).Reference = refnumber Then
                                    ToByte(Objects(y, z), Objects(y, z + 1), Refs(x).CopyRef1)
                                End If
                            Next
                        Next
                    End If
                Next
            End If
        ElseIf frmMain.rdbCrossAxis.Checked Then
            '-------------------------------------------------------------------------------------
            '-----------------------------------X-CROSS AXIS--------------------------------------
            '-------------------------------------------------------------------------------------
            If frmMain.MirrorRotateLandToolStripMenuItem.Checked Then
                'Mirror Land
                'Apply diagonal \ symmetry to create quadrant 2 
                For x = 0 To 127
                    For y = 0 To 127
                        If y + x >= 127 Then
                            Land(x, y) = copymap(127 - y, 127 - x)
                        End If
                    Next
                Next
                'Apply diagonal / symmetry to create quadrants 3 & 4 
                For x = 0 To 127
                    For y = 0 To 127
                        If x >= y Then
                            Land(x, y) = Land(y, x)
                        End If
                    Next
                Next
            End If

            If frmMain.MirrorRotateObjectsToolStripMenuItem.Checked Then
                'Before Mirror Objects
                'Keep trigger references
                nextref = 0
                For x = 0 To 2000
                    If Objects(x, 0) = 6 And Objects(x, 1) = 6 Then
                        For z = 13 To 31 Step 2
                            refnumber = ToShort(Objects(x, z), Objects(x, z + 1))
                            If refnumber > 0 Then
                                Refs(nextref).Reference = refnumber
                                nextref += 1
                            End If
                        Next
                    End If
                Next
                'Mirror Objects
                For x = 0 To 2000
                    If Not ((Objects(x, 6) >= Objects(x, 4) And (CInt(Objects(x, 4)) + CInt(Objects(x, 6)) < 255))) Then
                        DeleteObject(x)             'Delete objects
                        If x > 0 Then
                            For y = 0 To 2000
                                If Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                                    For z = 13 To 31 Step 2    'Remove references to deleted objects
                                        If ToShort(Objects(y, z), Objects(y, z + 1)) = x + 1 Then
                                            Objects(y, z) = 0
                                            Objects(y, z + 1) = 0
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    End If
                Next
                For x = 0 To 2000
                    If Objects(x, 6) >= Objects(x, 4) And CInt(Objects(x, 4)) + CInt(Objects(x, 6)) < 255 Then
                        For copies = 2 To 4
                            slot = SpareSlot()
                            For y = 0 To 55
                                'Create a new object in a spare slot
                                Objects(slot, y) = Objects(x, y)
                            Next
                            'Add reference for copied object
                            For z = 0 To nextref
                                If x + 1 = Refs(z).Reference Then
                                    Select Case copies
                                        Case 2
                                            Refs(z).CopyRef1 = slot + 1
                                        Case 3
                                            Refs(z).CopyRef2 = slot + 1
                                        Case 4
                                            Refs(z).CopyRef3 = slot + 1
                                    End Select
                                End If
                            Next
                            'Change of object Colour
                            If Objects(slot, 0) <> 6 Or Objects(slot, 1) <> 6 Then
                                If copies = 2 Then
                                    lastcolour = NextObjectColour(Objects(slot, 2))
                                    Objects(slot, 2) = lastcolour
                                Else
                                    Objects(slot, 2) = NextObjectColour(lastcolour)
                                    lastcolour = Objects(slot, 2)
                                End If
                            End If
                            'Change x & y of object
                            Select Case copies
                                Case 2
                                    preX = Objects(slot, 4)
                                    Objects(slot, 4) = 255 - Objects(slot, 6)
                                    Objects(slot, 6) = 255 - preX
                                Case 3
                                    Objects(slot, 4) = 255 - Objects(slot, 4)
                                    Objects(slot, 6) = 255 - Objects(slot, 6)
                                Case 4
                                    preX = Objects(slot, 4)
                                    Objects(slot, 4) = Objects(slot, 6)
                                    Objects(slot, 6) = preX
                            End Select
                            'Angle of Objects
                            If Objects(slot, 1) = 5 Then
                                y = 11  'Angle (Scenery)
                                Select Case copies
                                    Case 2
                                        Objects(slot, y) = (14 - Objects(slot, y)) Mod 8
                                    Case 3
                                        Objects(slot, y) = (8 - Objects(slot, y)) Mod 8
                                    Case 4
                                        Objects(slot, y) = (10 - Objects(slot, y)) Mod 8
                                End Select

                            ElseIf Objects(slot, 1) = 2 Then
                                y = 8   'Angle (Buildings)
                                Select Case copies
                                    Case 2
                                        Objects(slot, y) = (14 - Objects(slot, y)) Mod 8
                                    Case 3
                                        Objects(slot, y) = (8 - Objects(slot, y)) Mod 8
                                    Case 4
                                        Objects(slot, y) = (10 - Objects(slot, y)) Mod 8
                                End Select
                            End If
                            'Landbridge Effect
                            If Objects(slot, 0) = 24 And Objects(slot, 1) = 7 Then
                                'Landbridge Effect
                                Select Case copies
                                    Case 2
                                        preX = Objects(slot, 8)
                                        Objects(slot, 8) = 255 - Objects(slot, 12)
                                        Objects(slot, 12) = 255 - preX
                                    Case 3
                                        Objects(slot, 8) = 255 - Objects(slot, 8)
                                        Objects(slot, 12) = 255 - Objects(slot, 12)
                                    Case 4
                                        preX = Objects(slot, 8)
                                        Objects(slot, 8) = Objects(slot, 12)
                                        Objects(slot, 12) = preX
                                End Select
                            End If
                        Next
                    End If
                Next
                'Adjust any references to created mirrored object
                For y = 0 To 2000
                    If Not ((Objects(y, 6) >= Objects(y, 4) And (CInt(Objects(y, 4)) + CInt(Objects(y, 6)) < 255))) Then
                        If Objects(y, 0) = 6 And Objects(y, 1) = 6 Then
                            For z = 13 To 31 Step 2    'Amend references to mirrored objects
                                refnumber = ToShort(Objects(y, z), Objects(y, z + 1))
                                For x = 0 To nextref
                                    If Refs(x).Reference = refnumber Then
                                        If Objects(y, 6) >= Objects(y, 4) Then
                                            ToByte(Objects(y, z), Objects(y, z + 1), Refs(x).CopyRef1)
                                        ElseIf CInt(Objects(y, 4)) + CInt(Objects(y, 6)) >= 255 Then
                                            ToByte(Objects(y, z), Objects(y, z + 1), Refs(x).CopyRef2)
                                        Else
                                            ToByte(Objects(y, z), Objects(y, z + 1), Refs(x).CopyRef3)
                                        End If
                                    End If
                                Next
                            Next
                        End If
                    End If
                Next
            End If
        End If

    End Sub

    Sub ToByte(ByRef Byte1 As Byte, ByVal Byte2 As Byte, ByVal Word As Short)
        Byte1 = Word Mod 256
        Byte2 = Word \ 256
    End Sub

    Function ToShort(ByVal Byte1 As Byte, ByVal Byte2 As Byte) As Short
        Dim i As Short
        i = CShort(Byte2) * 256 + CShort(Byte1)
        Return i
    End Function

    Function NextObjectColour(ByVal objColour As Byte)
        Select Case objColour
            Case 0
                If frmReplicateObjects.rdbBB.Checked Then objColour = 0
                If frmReplicateObjects.rdbBR.Checked Then objColour = 1
                If frmReplicateObjects.rdbBY.Checked Then objColour = 2
                If frmReplicateObjects.rdbBG.Checked Then objColour = 3
            Case 1
                If frmReplicateObjects.rdbRB.Checked Then objColour = 0
                If frmReplicateObjects.rdbRR.Checked Then objColour = 1
                If frmReplicateObjects.rdbRY.Checked Then objColour = 2
                If frmReplicateObjects.rdbRG.Checked Then objColour = 3
            Case 2
                If frmReplicateObjects.rdbYB.Checked Then objColour = 0
                If frmReplicateObjects.rdbYR.Checked Then objColour = 1
                If frmReplicateObjects.rdbYY.Checked Then objColour = 2
                If frmReplicateObjects.rdbYG.Checked Then objColour = 3
            Case 3
                If frmReplicateObjects.rdbGB.Checked Then objColour = 0
                If frmReplicateObjects.rdbGR.Checked Then objColour = 1
                If frmReplicateObjects.rdbGY.Checked Then objColour = 2
                If frmReplicateObjects.rdbGG.Checked Then objColour = 3
        End Select
        Return objColour
    End Function

    Function SpareSlot() As Integer
        Dim x As Integer
        For x = 0 To 2000
            If Objects(x, 0) = 0 And Objects(x, 1) = 0 Then
                Return x
            End If
        Next
    End Function

    Sub DeleteObject(ByVal Index As Integer)
        Dim x As Integer
        For x = 0 To 55
            Objects(Index, x) = 0
        Next
    End Sub

    Public Sub CopyMap(ByVal FromIndex As Integer, ByVal ToIndex As Integer)
        Dim i, j As Integer
        If ToIndex = -1 Then
            For i = 0 To 127
                For j = 0 To 127
                    Land(i, j) = CPLand(FromIndex, i, j)
                Next
            Next
            For i = 0 To 2000
                For j = 0 To 54
                    Objects(i, j) = CPObjects(FromIndex, i, j)
                Next
            Next
        Else
            If FromIndex = -1 Then
                For i = 0 To 127
                    For j = 0 To 127
                        CPLand(ToIndex, i, j) = Land(i, j)
                    Next
                Next
                For i = 0 To 2000
                    For j = 0 To 54
                        CPObjects(ToIndex, i, j) = Objects(i, j)
                    Next
                Next
            Else
                For i = 0 To 127
                    For j = 0 To 127
                        CPLand(ToIndex, i, j) = CPLand(FromIndex, i, j)
                    Next
                Next
                For i = 0 To 2000
                    For j = 0 To 54
                        CPObjects(ToIndex, i, j) = CPObjects(FromIndex, i, j)
                    Next
                Next
            End If
        End If
    End Sub

    Public Sub Checkpoint()
        'Update indexes
        CPIndex = (CPIndex + 1) Mod 11
        UndoCount += 1
        'Copy map
        CopyMap(-1, CPIndex)
        'Disable redo item
        frmMain.RedoToolStripMenuItem.Enabled = False
        'Enable undo item
        frmMain.UndoToolStripMenuItem.Enabled = True
        RedoCount = 0
    End Sub

    Public Sub CheckpointUndo()
        'Update indexes
        CPIndex = (CPIndex + 1) Mod 11
        UndoCount += 1
        'Copy map
        CopyMap(-1, CPIndex)
        'Resinstate indexes
        CPIndex = (CPIndex + 10) Mod 11
        UndoCount -= 1
    End Sub

    Public Sub Undo()
        'Keep latest change state
        CheckpointUndo()
        'Undo to the last map
        CopyMap(CPIndex, -1)
        'Update indexes
        CPIndex = (CPIndex + 10) Mod 11
        UndoCount -= 1
        RedoCount += 1
        'Enable redo item
        frmMain.RedoToolStripMenuItem.Enabled = True
        'Disable undo item
        If UndoCount = 0 Then
            frmMain.UndoToolStripMenuItem.Enabled = False
        End If

    End Sub

    Public Sub Redo()
        'Update indexes
        CPIndex = (CPIndex + 1) Mod 11
        UndoCount += 1
        RedoCount -= 1
        'Redo to the map ahead
        CopyMap(CPIndex, -1)
        If RedoCount = 0 Then
            'Disable redo item
            frmMain.RedoToolStripMenuItem.Enabled = False
        End If
        'Enable undo item
        frmMain.UndoToolStripMenuItem.Enabled = True
    End Sub

End Module
