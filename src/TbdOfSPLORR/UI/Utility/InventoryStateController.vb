Friend Class InventoryStateController
    Inherits MessageStateController
    Private _itemType As ItemTypes?

    Public Sub New(screen As CoCoScreen, world As World)
        MyBase.New(screen, world, UIStates.Inventory)
        _itemType = Nothing
    End Sub

    Protected Overrides Function HandleKeyDownNonMessage(key As Keys) As UIStates
        If _itemType.HasValue Then
            Return HandleKeyDownSpecific(key)
        Else
            Return HandleKeyDownGeneral(key)
        End If
    End Function

    Private Function HandleKeyDownGeneral(key As Keys) As UIStates
        Select Case key
            Case Keys.Escape
                Return UIStates.InPlay
            Case Else
                If AllItemTypes.Any(Function(x) x.ShortcutKey = key) Then
                    Dim itemType = AllItemTypes.Single(Function(x) x.ShortcutKey = key)
                    If _world.PlayerCharacter.HasItem(itemType) Then
                        _itemType = itemType
                    End If
                End If
                Return _state
        End Select
    End Function

    Private Function HandleKeyDownSpecific(key As Keys) As UIStates
        Select Case key
            Case Keys.Escape
                _itemType = Nothing
            Case Keys.O
                DropItems(1)
            Case Keys.H
                DropItems(ItemCount \ 2)
            Case Keys.A
                DropItems(ItemCount)
        End Select
        Return _state
    End Function

    Private Sub DropItems(amount As Integer)
        _world.PlayerCharacter.Location.AddItems(_itemType.Value, amount)
        _world.PlayerCharacter.RemoveItems(_itemType.Value, amount)
        _world.PlayerCharacter.AddMessage($"You drop {amount} {_itemType.Value.Name}.")
        If ItemCount <= 0 Then
            _itemType = Nothing
        End If
    End Sub

    Protected Overrides Function UpdateNonMessage(ticks As Long) As UIStates
        If _itemType.HasValue Then
            Return UpdateSpecific()
        Else
            Return UpdateGeneral()
        End If
    End Function

    Private Function UpdateGeneral() As UIStates
        If _world.PlayerCharacter.HasItems Then
            _screen.WriteLine("Inventory:")
            _screen.WriteLine(String.Join(", ", _world.PlayerCharacter.Items.Select(Function(x) $"{x.Key.InventoryName}(x{x.Value})")))
            _screen.WriteLine("[esc] Go Back")
            Return _state
        Else
            Return UIStates.InPlay
        End If
    End Function
    Private ReadOnly Property ItemCount As Integer
        Get
            If _itemType.HasValue Then
                Return _world.PlayerCharacter.ItemCount(_itemType.Value)
            End If
            Return 0
        End Get
    End Property
    Private Function UpdateSpecific() As UIStates
        _screen.WriteLine($"{_itemType.Value.Name}(x{ItemCount})")
        _screen.WriteLine("[Esc] Go Back")
        _screen.WriteLine("Drop [O]ne")
        If ItemCount > 1 Then
            _screen.WriteLine("Drop [H]alf")
            _screen.WriteLine("Drop [A]ll")
        End If
        Return UIStates.Inventory
    End Function
End Class
