﻿Imports Microsoft.Xna.Framework.Input
Imports TBDOS.Business

Friend Class GroundStateController
    Inherits MessageStateController
    Private _itemType As String
    Public Sub New(screen As CoCoScreen, world As IWorld)
        MyBase.New(screen, world, UIStates.Ground)
        _itemType = Nothing
    End Sub
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
        _world.PlayerCharacter.Location.RemoveItems(_itemType, amount)
        _world.PlayerCharacter.AddItems(_itemType, amount)
        _world.PlayerCharacter.Messages.Add($"You take {amount} {_world.ItemTypeName(_itemType)}.")
        If ItemCount <= 0 Then
            _itemType = Nothing
        End If
    End Sub

    Private Function HandleKeyDownGeneral(key As Keys) As UIStates
        Select Case key
            Case Keys.Escape
                Return UIStates.InPlay
            Case Else
                If _world.AllItemTypes.Any(Function(x) x.ShortcutKey = key) Then
                    Dim itemType = _world.AllItemTypes.Single(Function(x) x.ShortcutKey = key)
                    If _world.PlayerCharacter.Location.HasItem(itemType) Then
                        _itemType = itemType
                    End If
                End If
        End Select
        Return UIStates.Ground
    End Function
    Private ReadOnly Property ItemCount As Integer
        Get
            If _itemType IsNot Nothing Then
                Return _world.PlayerCharacter.Location.ItemCount(_itemType)
            End If
            Return 0
        End Get
    End Property

    Private Function UpdateSpecific() As UIStates
        _screen.WriteLine($"{_world.ItemTypeName(_itemType)}(x{ItemCount})")
        _screen.WriteLine("[Esc] Go Back")
        _screen.WriteLine("Take [O]ne")
        If ItemCount > 1 Then
            _screen.WriteLine("Take [H]alf")
            _screen.WriteLine("Take [A]ll")
        End If
        Return UIStates.Ground
    End Function

    Private Function UpdateGeneral() As UIStates
        If _world.PlayerCharacter.Location.Items.Any Then
            _screen.WriteLine("On the ground:")
            _screen.WriteLine(String.Join(", ", _world.PlayerCharacter.Location.Items.Select(Function(x) $"{_world.InventoryName(x.Key)}(x{x.Value})")))
            _screen.WriteLine("[esc] Go Back")
            Return UIStates.Ground
        Else
            Return UIStates.InPlay
        End If
    End Function

    Protected Overrides Function HandleKeyDownNonMessage(key As Keys) As UIStates
        If _itemType IsNot Nothing Then
            Return HandleKeyDownSpecific(key)
        Else
            Return HandleKeyDownGeneral(key)
        End If
        Return _state
    End Function

    Protected Overrides Function UpdateNonMessage(ticks As Long) As UIStates
        If _itemType IsNot Nothing Then
            Return UpdateSpecific()
        Else
            Return UpdateGeneral()
        End If
    End Function
End Class
