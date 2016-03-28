Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics

Public Class Tile
    Public Position As Vector2
    Public Shared TileWidth As Integer = 100
    Public SpriteTexture As Texture2D
    Public rect As Rectangle
    Public Color As Color

    Public Sub New(_position As Vector2, _color As Color)
        Position = _position
        Color = _color
        rect = New Rectangle(CInt(Position.X * TileWidth), CInt(Position.Y * TileWidth), TileWidth, TileWidth)
    End Sub

    Public Sub New(_position As Vector2, _texture As Texture2D)
        Position = _position
        SpriteTexture = _texture
        rect = New Rectangle(CInt(Position.X * TileWidth), CInt(Position.Y * TileWidth), TileWidth, TileWidth)
    End Sub

    Public Sub Draw(theSpriteBatch As SpriteBatch)
        If SpriteTexture Is Nothing Then

        Else
            theSpriteBatch.Draw(SpriteTexture, rect, Color.White)
        End If
    End Sub
End Class
