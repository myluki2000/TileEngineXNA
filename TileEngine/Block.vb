Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Block

    Public Position As Vector2 = Vector2.Zero
    Public BlockWidth As Integer = 100
    Public rect As Rectangle
    Public Solid As Boolean = True
    Public SpriteTexture As Texture2D
    Public BoundingBox As Rectangle

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        If SpriteTexture Is Nothing Then
            DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(BlockWidth * Position.X), CInt(BlockWidth * Position.Y), BlockWidth, BlockWidth), New Color(160, 160, 180)) ' Top Face
            DrawRectangle.Draw(theSpriteBatch, rect, New Color(130, 130, 150)) ' Side Face
        Else
            Dim scale As Double = BlockWidth / SpriteTexture.Width

            theSpriteBatch.Draw(SpriteTexture, New Rectangle(rect.X, CInt(rect.Bottom - SpriteTexture.Height * scale), rect.Width, CInt(SpriteTexture.Height * scale)), Color.White)

            'DrawRectangle.Draw(theSpriteBatch, BoundingBox, Color.Red) ' Draw Bounding Box
        End If
    End Sub

    Public Sub DrawShadow(theSpriteBatch As SpriteBatch)
        If SpriteTexture Is Nothing Then
            DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(Position.X * BlockWidth + BlockWidth), CInt(Position.Y * BlockWidth + BlockWidth), BlockWidth, BlockWidth),
            Nothing, Nothing, ToRad(45), Color.Black) ' Top Shadow
            DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(Position.X * BlockWidth), CInt(Position.Y * BlockWidth) + BlockWidth * 2, BlockWidth, BlockWidth),
            Nothing, New Vector2(0, 1), ToRad(45), Color.Black) ' Bottom Shadow

            DrawRectangle.Draw(theSpriteBatch, New Rectangle(CInt(Position.X * BlockWidth + Math.Sqrt(BlockWidth ^ 2 / 2)), CInt(Position.Y * BlockWidth + BlockWidth + Math.Sqrt(BlockWidth ^ 2 / 2)), BlockWidth, BlockWidth), Color.Black)

        Else
            Dim diagonal As Integer = CInt(Math.Sqrt(BoundingBox.Width ^ 2 + BoundingBox.Height ^ 2))
            DrawRectangle.Draw(theSpriteBatch, New Rectangle(BoundingBox.Left, BoundingBox.Bottom, 60, diagonal), Nothing, New Vector2(0, 1), ToRad(45), Color.Black)
        End If
    End Sub

    Public Sub New(_position As Vector2)
        Position = _position
        rect = New Rectangle(CInt(Position.X * BlockWidth), CInt(Position.Y * BlockWidth) + BlockWidth, BlockWidth, BlockWidth)
        BoundingBox = rect
    End Sub

    Public Sub New(_position As Vector2, _solid As Boolean)
        Position = _position
        Solid = _solid
        rect = New Rectangle(CInt(Position.X * BlockWidth), CInt(Position.Y * BlockWidth) + BlockWidth, BlockWidth, BlockWidth)
        BoundingBox = rect
    End Sub

    Public Sub New(_position As Vector2, _solid As Boolean, _texture As Texture2D)
        Position = _position
        Solid = _solid
        SpriteTexture = _texture
        rect = New Rectangle(CInt(Position.X * BlockWidth), CInt(Position.Y * BlockWidth) + BlockWidth, BlockWidth, BlockWidth)
        BoundingBox = rect
    End Sub

    Public Sub New(_position As Vector2, _solid As Boolean, _texture As Texture2D, _boundingbox As Rectangle)
        Position = _position
        Solid = _solid
        SpriteTexture = _texture
        rect = New Rectangle(CInt(Position.X * BlockWidth), CInt(Position.Y * BlockWidth) + BlockWidth, BlockWidth, BlockWidth)
        BoundingBox = AddRects(rect, _boundingbox)

    End Sub
End Class
