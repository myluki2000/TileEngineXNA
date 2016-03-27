Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class DrawRectangle

    Shared dummyTexture As Texture2D = New Texture2D(TileEngine.graphics.GraphicsDevice, 1, 1)

    Shared Sub New()
        dummyTexture.SetData(New Color() {Color.White})
    End Sub

    Public Shared Sub Draw(theSpriteBatch As SpriteBatch, destRect As Rectangle, color As Color)
        theSpriteBatch.Draw(dummyTexture, destRect, color)
    End Sub

    Public Shared Sub Draw(theSpriteBatch As SpriteBatch, destRect As Rectangle, color As Color, colorOutline As Color, thicknessOutline As Integer)
        Draw(theSpriteBatch, destRect, color) ' Main Rect
        Draw(theSpriteBatch, New Rectangle(destRect.X, destRect.Y, destRect.Width, thicknessOutline), colorOutline) ' Outline Top
        Draw(theSpriteBatch, New Rectangle(destRect.X, destRect.Y + destRect.Height - thicknessOutline, destRect.Width, thicknessOutline), colorOutline) ' Outline Bottom
        Draw(theSpriteBatch, New Rectangle(destRect.X, destRect.Y, thicknessOutline, destRect.Height), colorOutline) ' Outline Left
        Draw(theSpriteBatch, New Rectangle(destRect.X + destRect.Width - thicknessOutline, destRect.Y, thicknessOutline, destRect.Height), colorOutline) ' Outline Right
    End Sub

    Public Shared Sub Draw(theSpriteBatch As SpriteBatch, destRect As Rectangle, sourceRect As Rectangle, origin As Vector2, Rotation As Single, Color As Color)
        theSpriteBatch.Draw(dummyTexture, destRect, sourceRect, Color, Rotation, origin, Nothing, 0)
    End Sub
End Class
