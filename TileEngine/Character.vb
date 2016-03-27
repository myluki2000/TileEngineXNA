Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Character
    Public rect As New Rectangle(0, 0, 10, 10)
    Public SpriteTexture As Texture2D


    Public Sub New()

    End Sub

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        DrawRectangle.Draw(theSpriteBatch, rect, Color.Red)
        theSpriteBatch.Draw(SpriteTexture, New Rectangle(rect.X, rect.Y - SpriteTexture.Height + rect.Height, SpriteTexture.Width, SpriteTexture.Height), Color.White)
        rect.Width = SpriteTexture.Width
    End Sub

    Public Sub Update(gameTime As GameTime)
        If Keyboard.GetState.IsKeyDown(Keys.W) Then
            For Each Block In TileEngine.Blocks
                If Block.rect.Intersects(New Rectangle(rect.X, rect.Y - 1, rect.Width, rect.Height)) Then
                    Return
                End If
            Next

            rect.Y -= 1
        End If

        If Keyboard.GetState.IsKeyDown(Keys.A) Then
            For Each Block In TileEngine.Blocks
                If Block.rect.Intersects(New Rectangle(rect.X - 1, rect.Y, rect.Width, rect.Height)) Then
                    Return
                End If
            Next

            rect.X -= 1
        End If

        If Keyboard.GetState.IsKeyDown(Keys.S) Then
            For Each Block In TileEngine.Blocks
                If Block.rect.Intersects(New Rectangle(rect.X, rect.Y + 1, rect.Width, rect.Height)) Then
                    Return
                End If
            Next

            rect.Y += 1
        End If

        If Keyboard.GetState.IsKeyDown(Keys.D) Then
            For Each Block In TileEngine.Blocks
                If Block.rect.Intersects(New Rectangle(rect.X + 1, rect.Y, rect.Width, rect.Height)) Then
                    Return
                End If
            Next

            rect.X += 1
        End If
    End Sub
End Class
