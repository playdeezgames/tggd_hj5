Imports Shouldly
Imports Xunit

Namespace TBDOS.Business.Tests
    Public Class World_should
        <Fact>
        Sub have_appropriate_initial_values()
            Dim sut As IWorld = New World
            sut.Avatar.ShouldBeNull
            sut.IsGameOver.ShouldBeTrue
        End Sub
        <Fact>
        Sub start_a_game()
            Dim sut As IWorld = New World
            sut.Start()
            sut.Avatar.ShouldNotBeNull
            sut.IsGameOver.ShouldBeFalse
        End Sub
        <Fact>
        Sub abandon_a_game()
            Dim sut As IWorld = New World
            sut.Start()
            sut.Abandon()
            sut.Avatar.ShouldBeNull
            sut.IsGameOver.ShouldBeTrue
        End Sub
    End Class
End Namespace

