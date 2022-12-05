Public Class Root
    Inherits Game
    Private graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Sub New()
        graphics = New GraphicsDeviceManager(Me)
        graphics.PreferredBackBufferWidth = 640
        graphics.PreferredBackBufferHeight = 480
        graphics.ApplyChanges()
        Content.RootDirectory = "Content"
    End Sub
    Protected Overrides Sub Initialize()
        MyBase.Initialize()
    End Sub
    Protected Overrides Sub LoadContent()
        MyBase.LoadContent()
        spriteBatch = New SpriteBatch(GraphicsDevice)
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)
        If Keyboard.GetState().IsKeyDown(Keys.Escape) Then
            [Exit]()
        End If
        MyBase.Update(gameTime)
    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        GraphicsDevice.Clear(Color.CornflowerBlue)
        MyBase.Draw(gameTime)
    End Sub
End Class
