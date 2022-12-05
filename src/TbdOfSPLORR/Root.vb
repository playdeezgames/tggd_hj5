Public Class Root
    Inherits Game
    Private Const CellWidth = 16
    Private Const CellHeight = 24
    Private Const CellColumns = 32
    Private Const CellRows = 16
    Private Const ViewWidth = CellColumns * CellWidth
    Private Const ViewHeight = CellRows * CellHeight
    Private Const ScreenWidth = 640
    Private Const ScreenHeight = 480
    Private Const OffsetX = (ScreenWidth - ViewWidth) \ 2
    Private Const OffsetY = (ScreenHeight - ViewHeight) \ 2

    Private graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Private texture As Texture2D
    Private sourceRectangles As Rectangle()
    Private destinationRectangles As Rectangle()
    Private oldKeyboardState As New KeyboardState
    Private keyboardState As New KeyboardState
    Private world As World
    Sub New(world As World)
        Me.world = world
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
        texture = Texture2D.FromFile(GraphicsDevice, "Content/CoCoFont.png")
        Dim rows = texture.Height \ CellHeight
        Dim columns = texture.Width \ CellWidth
        ReDim sourceRectangles(rows * columns)
        For row = 0 To rows - 1
            For column = 0 To columns - 1
                sourceRectangles(row * columns + column) = New Rectangle(column * CellWidth, row * CellHeight, CellWidth, CellHeight)
            Next
        Next
        ReDim destinationRectangles(CellColumns * CellRows)
        For row = 0 To CellRows - 1
            For column = 0 To CellColumns - 1
                destinationRectangles(column + row * CellColumns) = New Rectangle(column * CellWidth + OffsetX, row * CellHeight + OffsetY, CellWidth, CellHeight)
            Next
        Next
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)
        oldKeyboardState = keyboardState
        keyboardState = Keyboard.GetState()
        For Each key In keyboardState.GetPressedKeys()
            If Not oldKeyboardState.IsKeyDown(key) Then
                world.HandleKeyDown(key)
            End If
        Next
        For Each key In oldKeyboardState.GetPressedKeys()
            If Not keyboardState.IsKeyDown(key) Then
                world.HandleKeyUp(key)
            End If
        Next
        world.Update(gameTime.ElapsedGameTime.Ticks)
        MyBase.Update(gameTime)
    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        GraphicsDevice.Clear(Color.Black)
        spriteBatch.Begin()
        Dim index = 0
        For Each cell In world.ScreenBuffer
            spriteBatch.Draw(texture, destinationRectangles(index), sourceRectangles(cell), Color.White)
            index += 1
        Next
        spriteBatch.End()
        MyBase.Draw(gameTime)
    End Sub
End Class
