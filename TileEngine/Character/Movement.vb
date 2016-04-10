Imports Microsoft.Xna.Framework

Public Class Movement
    Public Shared Function MoveUp() As Boolean

        For Each Block In TileEngine.Blocks
            If Block.Position.Z = Character.PositionZ AndAlso Block.BoundingBox.Intersects(New Rectangle(Character.rect.X, Character.rect.Y - 1, Character.rect.Width, Character.rect.Height)) AndAlso Block.Solid = True Then
                Return False
            End If
        Next

        If Character.PositionZ > 0 Then
            For Each Block In TileEngine.Blocks
                If Block.TopIsWalkable = True AndAlso Block.Position.Z = Character.PositionZ - 1 AndAlso RectIntersects(New Rectangle(Block.rect.X, Block.rect.Y - Block.BlockWidth, Block.rect.Width, Block.rect.Height), AddRects(Character.rect, New Rectangle(0, -1, 0, 0))) Then
                    Character.rect.Y -= 1
                    Return True
                End If
            Next
        Else
            Character.rect.Y -= 1
            Return True
        End If
        Return False
    End Function

    Public Shared Function MoveLeft() As Boolean
        For Each Block In TileEngine.Blocks
            If Block.Position.Z = Character.PositionZ AndAlso Block.BoundingBox.Intersects(New Rectangle(Character.rect.X - 1, Character.rect.Y, Character.rect.Width, Character.rect.Height)) AndAlso Block.Solid = True Then
                Return False
            End If
        Next

        If Character.PositionZ > 0 Then
            For Each Block In TileEngine.Blocks
                If Block.TopIsWalkable = True AndAlso Block.Position.Z = Character.PositionZ - 1 AndAlso RectIntersects(New Rectangle(Block.rect.X, Block.rect.Y - Block.BlockWidth, Block.rect.Width, Block.rect.Height), AddRects(Character.rect, New Rectangle(-1, 0, 0, 0))) Then
                    Character.rect.X -= 1
                    Return True
                End If
            Next
        Else
            Character.rect.X -= 1
            Return True
        End If
        Return False
    End Function

    Public Shared Function MoveDown() As Boolean
        For Each Block In TileEngine.Blocks
            If Block.TopIsWalkable = True AndAlso Block.Position.Z = Character.PositionZ AndAlso Block.BoundingBox.Intersects(New Rectangle(Character.rect.X, Character.rect.Y + 1, Character.rect.Width, Character.rect.Height)) AndAlso Block.Solid = True Then
                Return False
            End If
        Next

        If Character.PositionZ > 0 Then
            For Each Block In TileEngine.Blocks
                If Block.TopIsWalkable = True AndAlso Block.Position.Z = Character.PositionZ - 1 AndAlso RectIntersects(New Rectangle(Block.rect.X, Block.rect.Y - Block.BlockWidth, Block.rect.Width, Block.rect.Height), AddRects(Character.rect, New Rectangle(0, 1, 0, 0))) Then
                    Character.rect.Y += 1
                    Return True
                End If
            Next
        Else
            Character.rect.Y += 1
            Return True
        End If
        Return False
    End Function

    Public Shared Function MoveRight() As Boolean
        For Each Block In TileEngine.Blocks
            If Block.Position.Z = Character.PositionZ AndAlso Block.BoundingBox.Intersects(New Rectangle(Character.rect.X + 1, Character.rect.Y, Character.rect.Width, Character.rect.Height)) AndAlso Block.Solid = True Then
                Return False
            End If
        Next

        If Character.PositionZ > 0 Then
            For Each Block In TileEngine.Blocks
                If Block.TopIsWalkable = True AndAlso Block.Position.Z = Character.PositionZ - 1 AndAlso RectIntersects(New Rectangle(Block.rect.X, Block.rect.Y - Block.BlockWidth, Block.rect.Width, Block.rect.Height), AddRects(Character.rect, New Rectangle(1, 0, 0, 0))) Then
                    Character.rect.X += 1
                    Return True
                End If
            Next
        Else
            Character.rect.X += 1
            Return True
        End If
        Return False
    End Function
End Class
