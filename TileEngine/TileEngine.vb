#Region "Using Statements"
Imports System.Collections.Generic
Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Content
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input
Imports Microsoft.Xna.Framework.Storage
#End Region

''' <summary>
''' This is the main type for your game
''' </summary>
Public Class TileEngine
    Inherits Game
    Public Shared graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Dim shadowTarget As RenderTarget2D

    Public Shared Blocks As New List(Of Block) ' Blocks layer 1

    Public Shared Tiles As New List(Of Tile)

    Public Player As New Character

    Public grassTexture As Texture2D

    Public Shared ShadowTexture As Texture2D

    Public Sub New()
        MyBase.New()
        graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
    End Sub

    ''' <summary>
    ''' Allows the game to perform any initialization it needs to before starting to run.
    ''' This is where it can query for any required services and load any non-graphic
    ''' related content.  Calling base.Initialize will enumerate through any components
    ''' and initialize them as well.
    ''' </summary>
    Protected Overrides Sub Initialize()
        ' TODO: Add your initialization logic here

        shadowTarget = New RenderTarget2D(GraphicsDevice, GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight)


        Player.rect.Location = New Point(180, 180)
        MyBase.Initialize()
    End Sub

    ''' <summary>
    ''' LoadContent will be called once per game and is the place to load
    ''' all of your content.
    ''' </summary>
    Protected Overrides Sub LoadContent()
        ' Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = New SpriteBatch(GraphicsDevice)

        ShadowTexture = Content.Load(Of Texture2D)("shadow")

        Block.BlockWidth = 70

        Blocks.Add(New Block(New Vector3(0, 0, 0)))



        Blocks.Add(New Block(New Vector3(1, 0, 0)))
        Blocks.Add(New Block(New Vector3(2, 0, 0), True, Content.Load(Of Texture2D)("stone_broken"), True))
        Blocks.Add(New Block(New Vector3(3, 0, 0), True, Content.Load(Of Texture2D)("stone_broken"), True))
        Blocks.Add(New Block(New Vector3(3, 1, 0), True, Content.Load(Of Texture2D)("stone_broken"), True))
        Blocks.Add(New Block(New Vector3(3, 2, 0), True, Content.Load(Of Texture2D)("wood"), True))
        Blocks.Add(New Block(New Vector3(2, 2, 0), True, Content.Load(Of Texture2D)("tree"),
          New Rectangle(CInt(0.25 * Block.BlockWidth), CInt(0.7 * Block.BlockWidth), CInt(-0.5 * Block.BlockWidth), CInt(-0.7 * Block.BlockWidth)), True))


        Blocks.Add(New Block(New Vector3(0, 0, 1)))


        Tile.TileWidth = 70

        grassTexture = Content.Load(Of Texture2D)("grass")

        Tiles.Add(New Tile(New Vector2(0, 2), grassTexture))



        Player.SpriteTexture = Content.Load(Of Texture2D)("character")
        ' TODO: use this.Content to load your game content here
    End Sub

    ''' <summary>
    ''' UnloadContent will be called once per game and is the place to unload
    ''' all content.
    ''' </summary>
    Protected Overrides Sub UnloadContent()
        ' TODO: Unload any non ContentManager content here
    End Sub

    ''' <summary>
    ''' Allows the game to run logic such as updating the world,
    ''' checking for collisions, gathering input, and playing audio.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Update(gameTime As GameTime)
        If GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed OrElse Keyboard.GetState().IsKeyDown(Keys.Escape) Then
            [Exit]()
        End If

        Player.Update(gameTime)

        MyBase.Update(gameTime)
    End Sub

    ''' <summary>
    ''' This is called when the game should draw itself.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Draw(gameTime As GameTime)

        graphics.GraphicsDevice.SetRenderTarget(Nothing)
        GraphicsDevice.Clear(Color.CornflowerBlue)

        spriteBatch.Begin(Nothing, BlendState.AlphaBlend, SamplerState.LinearWrap, Nothing, Nothing, Nothing, Nothing)
        ' Draw default floor tile
        spriteBatch.Draw(grassTexture, New Vector2(0, 0), New Rectangle(0, 0, 100000, 50000), Color.White)
        spriteBatch.End()

        spriteBatch.Begin(Nothing, BlendState.AlphaBlend, Nothing, Nothing, Nothing, Nothing, Nothing)
        ' Draw floor tiles
        For Each Tile In Tiles
            Tile.Draw(spriteBatch)
        Next


        ' Draw render target with shadows
        spriteBatch.Draw(shadowTarget, New Vector2(0, 0), Color.Black * 0.3F)


        ' Draw blocks behind player
        For Each Block In Blocks
            If Block.Position.Z < Character.PositionZ OrElse Block.rect.Y + Block.BlockWidth <= Player.rect.Y Then
                Block.Draw(spriteBatch)
            End If
        Next



        For Each Block In TileEngine.Blocks
            If Block.Position.Z = Character.PositionZ - 1 Then
                DrawRectangle.Draw(spriteBatch, New Rectangle(Block.rect.X, Block.rect.Y - Block.BlockWidth, Block.rect.Width, Block.rect.Height), Color.Red)
            End If
        Next




        ' Draw player
        Player.Draw(spriteBatch)

        ' Draw blocks in front of player
        For Each Block In Blocks
            If Not Block.Position.Z < Character.PositionZ AndAlso Block.rect.Y + Block.BlockWidth > Player.rect.Y Then
                Block.Draw(spriteBatch)
            End If
        Next


        spriteBatch.End()

        If gameTime.TotalGameTime.TotalSeconds < 5 Then
            ' Draw shadows which will be saved to a render target
            graphics.GraphicsDevice.SetRenderTarget(shadowTarget)
            GraphicsDevice.Clear(Color.Transparent)
            spriteBatch.Begin()
            For Each Block In Blocks
                Block.DrawShadow(spriteBatch)
            Next
            spriteBatch.End()
        End If
        MyBase.Draw(gameTime)
    End Sub
End Class
