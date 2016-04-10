Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Character
    Public Shared rect As New Rectangle(0, 0, 10, 10)
    Public Shared PositionZ As Integer = 1 'Z Position (Height) of the player in Blocks
    Public SpriteTexture As Texture2D


    Public Sub New()

    End Sub

    Public Sub Draw(theSpriteBatch As SpriteBatch)


        DrawRectangle.Draw(theSpriteBatch, rect, Color.Green) ' Draw Bounding Box
        theSpriteBatch.Draw(SpriteTexture, New Rectangle(rect.X, rect.Y - SpriteTexture.Height + rect.Height, SpriteTexture.Width, SpriteTexture.Height), Color.White)
        rect.Width = SpriteTexture.Width - 6
    End Sub

    Public Sub Update(gameTime As GameTime)
        If Keyboard.GetState.IsKeyDown(Keys.W) Then
            Movement.MoveUp()
        End If

        If Keyboard.GetState.IsKeyDown(Keys.A) Then
            Movement.MoveLeft()
        End If

        If Keyboard.GetState.IsKeyDown(Keys.S) Then
            Movement.MoveDown()
        End If

        If Keyboard.GetState.IsKeyDown(Keys.D) Then
            Movement.MoveRight()
        End If
    End Sub
End Class
