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
                Return _state
        End Select
    End Function

    Private Function HandleKeyDownSpecific(key As Keys) As UIStates
        Throw New NotImplementedException()
    End Function

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
            _screen.WriteLine("[esc] Go Back")
            Return _state
        Else
            Return UIStates.InPlay
        End If
    End Function

    Private Function UpdateSpecific() As UIStates
        Throw New NotImplementedException()
    End Function
End Class
