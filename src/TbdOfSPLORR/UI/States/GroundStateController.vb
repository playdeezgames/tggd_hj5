Friend Class GroundStateController
    Implements IUIStateController
    Private _screen As CoCoScreen
    Private _world As World
    Private _itemType As ItemTypes?
    Public Sub New(screen As CoCoScreen, world As World)
        _screen = screen
        _world = world
        _itemType = Nothing
    End Sub
    Private Sub HandleKeyDownMessage()
        _world.PlayerCharacter.DismissMessage()
    End Sub

    Public Function HandleKeyDown(key As Keys) As UIStates Implements IUIStateController.HandleKeyDown
        If _world.PlayerCharacter.HasMessages Then
            HandleKeyDownMessage()
            Return UIStates.Ground
        ElseIf _itemType IsNot Nothing Then
            Return HandleKeyDownSpecific(key)
        Else
            Return HandleKeyDownNeutral(key)
        End If
    End Function

    Private Function HandleKeyDownSpecific(key As Keys) As UIStates
        Select Case key
            Case Keys.Escape
                _itemType = Nothing
            Case Keys.O
                TakeItems(1)
            Case Keys.A
                TakeItems(ItemCount)
            Case Keys.H
                TakeItems(ItemCount \ 2)
        End Select
        Return UIStates.Ground
    End Function

    Private Sub TakeItems(amount As Integer)
        _world.PlayerCharacter.Location.RemoveItems(_itemType.Value, amount)
        _world.PlayerCharacter.AddItems(_itemType.Value, amount)
        _world.PlayerCharacter.AddMessage($"You take {amount} {_itemType.Value.Name}.")
        If ItemCount <= 0 Then
            _itemType = Nothing
        End If
    End Sub

    Private Function HandleKeyDownNeutral(key As Keys) As UIStates
        Select Case key
            Case Keys.Escape
                Return UIStates.InPlay
            Case Else
                If AllItemTypes.Any(Function(x) x.ShortcutKey = key) Then
                    Dim itemType = AllItemTypes.Single(Function(x) x.ShortcutKey = key)
                    If _world.PlayerCharacter.Location.HasItem(itemType) Then
                        _itemType = itemType
                    End If
                End If
        End Select
        Return UIStates.Ground
    End Function

    Public Function Update(ticks As Long) As UIStates Implements IUIStateController.Update
        _screen.Clear(96)
        _screen.GoToXY(0, 0)
        If _world.PlayerCharacter.HasMessages Then
            UpdateMessage()
        ElseIf _itemType IsNot Nothing Then
            UpdateSpecific()
        Else
            Return UpdateNeutral()
        End If
        Return UIStates.Ground
    End Function
    Private Sub UpdateMessage()
        Dim message = _world.PlayerCharacter.NextMessage
        For Each line In message
            _screen.WriteLine(line)
        Next
        _screen.WriteLine("Press any key.")
    End Sub


    Private ReadOnly Property ItemCount As Integer
        Get
            If _itemType.HasValue Then
                Return _world.PlayerCharacter.Location.ItemCount(_itemType.Value)
            End If
            Return 0
        End Get
    End Property

    Private Sub UpdateSpecific()
        _screen.WriteLine($"{_itemType.Value.Name}(x{ItemCount})")
        _screen.WriteLine("[Esc] Go Back")
        _screen.WriteLine("Take [O]ne")
        If itemCount > 1 Then
            _screen.WriteLine("Take [H]alf")
            _screen.WriteLine("Take [A]ll")
        End If
    End Sub

    Private Function UpdateNeutral() As UIStates
        If _world.PlayerCharacter.Location.Items.Any Then
            _screen.WriteLine("On the ground:")
            _screen.WriteLine(String.Join(", ", _world.PlayerCharacter.Location.Items.Select(Function(x) $"{x.Key.InventoryName}(x{x.Value})")))
            _screen.WriteLine("[esc] Go Back")
            Return UIStates.Ground
        Else
            Return UIStates.InPlay
        End If
    End Function
End Class
