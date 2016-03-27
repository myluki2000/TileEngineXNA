Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Block

    Public Position As Vector2 = Vector2.Zero
    Public BlockWidth As Integer = 100

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(BlockWidth * Position.X), CInt(BlockWidth * Position.Y), BlockWidth, BlockWidth), New Color(160, 160, 180)) ' Top Face
        DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(BlockWidth * Position.X), CInt(BlockWidth * Position.Y) + BlockWidth, BlockWidth, BlockWidth), New Color(130, 130, 150)) ' Side Face


    End Sub

    Public Sub DrawShadow(theSpriteBatch As SpriteBatch)
        DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(Position.X * BlockWidth + BlockWidth), CInt(Position.Y * BlockWidth + BlockWidth), BlockWidth, BlockWidth),
            Nothing, Nothing, ToRad(45), Color.Black) ' Top Shadow
        DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(Position.X * BlockWidth), CInt(Position.Y * BlockWidth) + BlockWidth * 2, BlockWidth, BlockWidth),
            Nothing, New Vector2(0, 1), ToRad(45), Color.Black) ' Bottom Shadow

        DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(Position.X * BlockWidth + Math.Sqrt(BlockWidth ^ 2 / 2)), CInt(Position.Y * BlockWidth + BlockWidth + Math.Sqrt(BlockWidth ^ 2 / 2)), BlockWidth, BlockWidth), Color.Black)
    End Sub

    Public Sub New(_position As Vector2)
        Position = _position
    End Sub
End Class
