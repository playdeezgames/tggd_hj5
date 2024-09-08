Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Public Class Root
    Inherits Game
    Private Const CellWidth = 8
    Private Const CellHeight = 12
    Private Const CellColumns = 32
    Private Const CellRows = 16
    Private Const ViewWidth = CellColumns * CellWidth
    Private Const ViewHeight = CellRows * CellHeight
    Private Const ScreenWidth = 320
    Private Const ScreenHeight = 240
    Private Const OffsetX = (ScreenWidth - ViewWidth) \ 2
    Private Const OffsetY = (ScreenHeight - ViewHeight) \ 2
    Private uiScale As Integer = 3

    Private ReadOnly graphics As GraphicsDeviceManager
    Private spriteBatch As SpriteBatch
    Private texture As Texture2D
    Private sourceRectangles As Rectangle()
    Private destinationRectangles As Rectangle()
    Private oldKeyboardState As New KeyboardState
    Private keyboardState As New KeyboardState
    Private ReadOnly _uiController As UIController
    Sub New()
        _uiController = New UIController(AddressOf SetUIScale)
        graphics = New GraphicsDeviceManager(Me)
    End Sub
    Private Sub ResizeScreen()
        graphics.PreferredBackBufferWidth = ScreenWidth * uiScale
        graphics.PreferredBackBufferHeight = ScreenHeight * uiScale
        graphics.ApplyChanges()
    End Sub
    Private Sub SetUIScale(newScale As Integer)
        uiScale = newScale
        ResizeScreen()
        ResizeDestinationRectangles()
    End Sub
    Protected Overrides Sub Initialize()
        MyBase.Initialize()
        Window.Title = "TBD of SPLORR!!"
        Content.RootDirectory = "Content"
        ResizeScreen()
    End Sub
    Private Sub ResizeDestinationRectangles()
        For row = 0 To CellRows - 1
            For column = 0 To CellColumns - 1
                destinationRectangles(column + row * CellColumns) = New Rectangle((column * CellWidth + OffsetX) * uiScale, (row * CellHeight + OffsetY) * uiScale, CellWidth * uiScale, CellHeight * uiScale)
            Next
        Next
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
        ResizeDestinationRectangles()
    End Sub
    Protected Overrides Sub Update(gameTime As GameTime)
        oldKeyboardState = keyboardState
        keyboardState = Keyboard.GetState()
        For Each key In keyboardState.GetPressedKeys()
            If Not oldKeyboardState.IsKeyDown(key) Then
                _uiController.HandleKeyDown(key)
            End If
        Next
        _uiController.Update(gameTime.ElapsedGameTime.Ticks)
        If _uiController.UIState = UIStates.Quit Then
            [Exit]()
        End If
        MyBase.Update(gameTime)
    End Sub
    Protected Overrides Sub Draw(gameTime As GameTime)
        GraphicsDevice.Clear(Color.Black)
        spriteBatch.Begin(samplerState:=SamplerState.PointClamp)
        Dim index = 0
        For Each cell In _uiController.ScreenBuffer
            spriteBatch.Draw(texture, destinationRectangles(index), sourceRectangles(cell), Color.White)
            index += 1
        Next
        spriteBatch.End()
        MyBase.Draw(gameTime)
    End Sub
End Class
