Imports Microsoft.Xna.Framework

Module GlobalVariables
#Region "Colors"
    Public ColorDarkerGray As New Microsoft.Xna.Framework.Color(90, 90, 90)
    Public ColorDarkererGray As New Microsoft.Xna.Framework.Color(70, 70, 70)
#End Region

    Public Function ToRad(degrees As Single) As Single
        Return CSng(degrees * Math.PI / 180)
    End Function

    Public Function AddRects(rect1 As Rectangle, rect2 As Rectangle) As Rectangle
        Return New Rectangle(rect1.X + rect2.X, rect1.Y + rect2.Y, rect1.Width + rect2.Width, rect1.Height + rect2.Height)
    End Function
End Module
