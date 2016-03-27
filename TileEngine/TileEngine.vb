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
    Dim renderTarget As RenderTarget2D

    Public Shared Blocks As New List(Of Block)

    Public Player As New Character

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

        renderTarget = New RenderTarget2D(GraphicsDevice, GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight)


        Blocks.Add(New Block(New Vector2(0, 0)))
        Blocks.Add(New Block(New Vector2(1, 0)))
        Blocks.Add(New Block(New Vector2(2, 0)))
        Blocks.Add(New Block(New Vector2(3, 0)))
        Blocks.Add(New Block(New Vector2(3, 1)))
        Blocks.Add(New Block(New Vector2(3, 2)))
        Blocks.Add(New Block(New Vector2(2, 2)))


        Player.rect.Location = New Vector2(500, 300).ToPoint
        MyBase.Initialize()
    End Sub

    ''' <summary>
    ''' LoadContent will be called once per game and is the place to load
    ''' all of your content.
    ''' </summary>
    Protected Overrides Sub LoadContent()
        ' Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = New SpriteBatch(GraphicsDevice)

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


        spriteBatch.Begin(Nothing, BlendState.AlphaBlend, Nothing, Nothing, Nothing, Nothing, Nothing)


        graphics.GraphicsDevice.SetRenderTarget(Nothing)
        GraphicsDevice.Clear(Color.CornflowerBlue)


        spriteBatch.Draw(renderTarget, New Vector2(0, 0), Color.Black * 0.3F) ' Draw shadows


        For Each Block In Blocks ' Draw blocks behind player
            If Block.rect.Y <= Player.rect.Y Then
                Block.Draw(spriteBatch)
            End If
        Next

        Player.Draw(spriteBatch)

        For Each Block In Blocks ' Draw blocks in front of player
            If Block.rect.Y > Player.rect.Y Then
                Block.Draw(spriteBatch)
            End If
        Next
        spriteBatch.End()


        graphics.GraphicsDevice.SetRenderTarget(renderTarget)
        GraphicsDevice.Clear(Color.Transparent)
        spriteBatch.Begin()
        For Each Block In Blocks
            Block.DrawShadow(spriteBatch)
        Next
        spriteBatch.End()

        MyBase.Draw(gameTime)
    End Sub
End Class
