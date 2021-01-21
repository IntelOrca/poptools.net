Module modColour

    Const Mapscale = 3

    Public Structure RGB
        Public Red As Integer
        Public Green As Integer
        Public Blue As Integer
    End Structure

    Public Structure HSL
        Public Hue As Integer
        Public Saturation As Integer
        Public Luminance As Integer
    End Structure

    Public Function HSLtoRGB(ByVal Hue As Integer, _
                             ByVal Saturation As Integer, _
                             ByVal Luminance As Integer) As RGB

        Dim pHue As Single
        Dim pSat As Single
        Dim pLum As Single
        Dim RetVal As RGB
        Dim pRed As Single
        Dim pGreen As Single
        Dim pBlue As Single
        Dim temp2 As Single
        Dim temp3() As Single
        Dim temp1 As Single
        Dim n As Integer

        ReDim temp3(0 To 2)

        pHue = Hue / 239
        pSat = Saturation / 239
        pLum = Luminance / 239

        If pSat = 0 Then
            pRed = pLum!
            pGreen = pLum
            pBlue = pLum
        Else
            If pLum < 0.5 Then
                temp2 = pLum * (1 + pSat)
            Else
                temp2 = pLum + pSat - pLum * pSat
            End If
            temp1! = 2 * pLum! - temp2!

            temp3(0) = pHue + 1 / 3
            temp3(1) = pHue
            temp3(2) = pHue - 1 / 3

            For n = 0 To 2
                If temp3(n) < 0 Then temp3(n) = temp3(n) + 1
                If temp3(n) > 1 Then temp3(n) = temp3(n) - 1

                If 6 * temp3(n) < 1 Then
                    temp3(n) = temp1 + (temp2 - temp1) * 6 * temp3(n)
                Else
                    If 2 * temp3(n) < 1 Then
                        temp3(n) = temp2
                    Else
                        If 3 * temp3(n%) < 2 Then
                            temp3(n%) = temp1 + (temp2 - temp1) _
                                  * ((2 / 3) - temp3(n%)) * 6
                        Else
                            temp3(n%) = temp1
                        End If
                    End If
                End If
            Next n%

            pRed = temp3(0)
            pGreen = temp3(1)
            pBlue = temp3(2)
        End If

        RetVal.Red = Int(pRed * 255)
        RetVal.Green = Int(pGreen * 255)
        RetVal.Blue = Int(pBlue * 255)

        HSLtoRGB = RetVal
    End Function

    Public Function RGBtoHSL(ByVal Red As Integer, _
                             ByVal Green As Integer, _
                             ByVal Blue As Integer) As HSL

        Dim pRed As Single
        Dim pGreen As Single
        Dim pBlue As Single
        Dim RetVal As HSL
        Dim pMax As Single
        Dim pMin As Single
        Dim pLum As Single
        Dim pSat As Single
        Dim pHue As Single

        pRed = Red / 255
        pGreen = Green / 255
        pBlue = Blue / 255

        If pRed > pGreen Then
            If pRed > pBlue Then
                pMax = pRed
            Else
                pMax = pBlue
            End If
        ElseIf pGreen > pBlue Then
            pMax = pGreen
        Else
            pMax = pBlue
        End If

        If pRed < pGreen Then
            If pRed < pBlue Then
                pMin = pRed
            Else
                pMin = pBlue
            End If
        ElseIf pGreen < pBlue Then
            pMin = pGreen
        Else
            pMin = pBlue
        End If

        pLum = (pMax + pMin) / 2

        If pMax = pMin Then
            pSat = 0
            pHue = 0
        Else
            If pLum < 0.5 Then
                pSat = (pMax - pMin) / (pMax + pMin)
            Else
                pSat = (pMax - pMin) / (2 - pMax - pMin)
            End If

            Select Case pMax!
                Case pRed
                    pHue = (pGreen - pBlue) / (pMax - pMin)
                Case pGreen
                    pHue = 2 + (pBlue - pRed) / (pMax - pMin)
                Case pBlue
                    pHue = 4 + (pRed - pGreen) / (pMax - pMin)
            End Select
        End If

        RetVal.Hue = pHue * 239 \ 6
        If RetVal.Hue < 0 Then RetVal.Hue = RetVal.Hue + 240

        RetVal.Saturation = Int(pSat * 239)
        RetVal.Luminance = Int(pLum * 239)

        RGBtoHSL = RetVal
    End Function

    Public Function GetLandColour(ByVal Height As Short, ByVal Shade As Boolean) As Color
        Dim Colour As Color, Shading As Byte
        If Shade Then Shading = 50
        Select Case Height
            Case 0
                Colour = Color.FromArgb(ByteSize(135 + Shading), ByteSize(156 + Shading), ByteSize(227 + Shading))
            Case Is < 8
                Colour = Color.FromArgb(ByteSize(HSLtoRGB(24, 224, 200).Red + Shading), ByteSize(HSLtoRGB(24, 224, 200).Green + Shading), ByteSize(HSLtoRGB(24, 224, 200).Blue + Shading))
            Case Is > 1023
                Colour = Color.FromArgb(ByteSize(HSLtoRGB(24, 224, 40).Red + Shading), ByteSize(HSLtoRGB(24, 224, 40).Green + Shading), ByteSize(HSLtoRGB(24, 224, 40).Blue + Shading))
            Case Else
                Height = 178 - (Height / 8)
                Colour = Color.FromArgb(ByteSize(HSLtoRGB(24, 224, Height).Red + Shading), ByteSize(HSLtoRGB(24, 224, Height).Green + Shading), ByteSize(HSLtoRGB(24, 224, Height).Blue + Shading))
        End Select
        Return Colour
    End Function

    Function ByteSize(ByVal Number As Integer)
        If Number > 255 Then
            Return 255
        Else
            Return Number
        End If
    End Function

End Module
