Module GlobalVariables
#Region "Colors"
    Public ColorDarkerGray As New Microsoft.Xna.Framework.Color(90, 90, 90)
    Public ColorDarkererGray As New Microsoft.Xna.Framework.Color(70, 70, 70)
#End Region

    Public Function ToRad(degrees As Single) As Single
        Return CSng(degrees * Math.PI / 180)
    End Function
End Module
