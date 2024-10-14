Imports TBDOS.Business

Friend MustInherit Class WorldStateController
    Inherits BaseStateController
    Protected ReadOnly _world As IWorld
    Public Sub New(screen As CoCoScreen, world As IWorld)
        MyBase.New(screen)
        _world = world
    End Sub
End Class
