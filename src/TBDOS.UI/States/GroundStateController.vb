Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Class GroundStateController
    Inherits MessageStateController
    Private itemStack As ILocationItemStack
    Public Sub New(screen As CoCoScreen, world As IWorld)
        MyBase.New(screen, world, UIStates.Ground)
        itemStack = Nothing
    End Sub
    Private Function HandleKeyDownSpecific(key As Keys) As UIStates
        Select Case key
            Case Keys.Escape
                itemStack = Nothing
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
        itemStack.Remove(amount)
        _world.Avatar.Inventory.Stack(itemStack.ItemType).Add(amount)
        _world.Avatar.Messages.Add($"You take {amount} {_world.ItemTypeName(itemStack.ItemType)}.")
        If ItemCount <= 0 Then
            itemStack = Nothing
        End If
    End Sub

    Private Function HandleKeyDownGeneral(key As Keys) As UIStates
        Select Case key
            Case Keys.Escape
                Return UIStates.InPlay
            Case Else
                If _world.AllItemTypes.Any(Function(x) x.ShortcutKey = key) Then
                    Dim itemType = _world.AllItemTypes.Single(Function(x) x.ShortcutKey = key)
                    If _world.Avatar.Location.Inventory.Stack(itemType).Has Then
                        itemStack = _world.Avatar.Location.Inventory.Stack(itemType)
                    End If
                End If
        End Select
        Return UIStates.Ground
    End Function
    Private ReadOnly Property ItemCount As Integer
        Get
            If itemStack IsNot Nothing Then
                Return _world.Avatar.Location.Inventory.Stack(itemStack.ItemType).Quantity
            End If
            Return 0
        End Get
    End Property

    Private Function UpdateSpecific() As UIStates
        _screen.WriteLine($"{_world.ItemTypeName(itemStack.ItemType)}(x{itemStack.Quantity})")
        _screen.WriteLine("[Esc] Go Back")
        _screen.WriteLine("Take [O]ne")
        If ItemCount > 1 Then
            _screen.WriteLine("Take [H]alf")
            _screen.WriteLine("Take [A]ll")
        End If
        Return UIStates.Ground
    End Function

    Private Function UpdateGeneral() As UIStates
        If _world.Avatar.Location.Inventory.Stacks.Any Then
            _screen.WriteLine("On the ground:")
            _screen.WriteLine(String.Join(", ", _world.Avatar.Location.Inventory.Stacks.Select(Function(x) $"{x.InventoryName}(x{x.Quantity})")))
            _screen.WriteLine("[esc] Go Back")
            Return UIStates.Ground
        Else
            Return UIStates.InPlay
        End If
    End Function

    Protected Overrides Function HandleKeyDownNonMessage(key As Keys) As UIStates
        If itemStack IsNot Nothing Then
            Return HandleKeyDownSpecific(key)
        Else
            Return HandleKeyDownGeneral(key)
        End If
        Return _state
    End Function

    Protected Overrides Function UpdateNonMessage(ticks As Long) As UIStates
        If itemStack IsNot Nothing Then
            Return UpdateSpecific()
        Else
            Return UpdateGeneral()
        End If
    End Function
End Class
