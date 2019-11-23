using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TennisKataLibrary;

namespace TennisKata.UnitTest
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void TryingToAdd3Player()
        {
            Player jean = new Player("Jean", "Sebastien");
            Player marc = new Player("Marc", "Antoine");
            Player frank = new Player("franck", "DeLoite");
            Game game = new Game(jean, marc, 2);

            NUnit.Framework.Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                game.AddPlayer(frank);
            });
        }


        [Test]
        public void WhenGameNotBeginNotPlayerHasWin()
        {
            Player jean = new Player("Jean", "Sebastien");
            Player marc = new Player("Marc", "Antoine");

            Game game = new Game(jean, marc, 2);

            game.Begin();

            game.GetWinningPlayer().Should().BeNull();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddPointTopPlayerNotInTheGame()
        {
            Player jean = new Player("Jean", "Sebastien");
            Player marc = new Player("Marc", "Antoine");
            Player frank = new Player("franck", "DeLoite");

            Game game = new Game(jean, marc, 2);

            game.Begin();

            NUnit.Framework.Assert.Throws<InvalidOperationException>(() =>
           {
               game.AddPoint(frank);
           });
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddPointBeforeTheStart()
        {
            Player jean = new Player("Jean", "Sebastien");
            Player marc = new Player("Marc", "Antoine");

            Game game = new Game(jean, marc, 2);


            NUnit.Framework.Assert.Throws<InvalidOperationException>(() =>
            {
                game.AddPoint(marc);
            });
            
        }

        [Test]
        public void FullGameOneWinningTest()
        {
            Player jean = new Player("Jean", "Sebastien");
            Player marc = new Player("Marc", "Antoine");

            Game game = new Game(jean, marc, 2);

            game.Begin();

            game.HasBegin.Should().BeTrue();

            game.AddPoint(jean);

            game.AddPoint(jean);

            game.AddPoint(jean);

            game.AddPoint(jean);

            game.FirstPlayer.NumberOfSetWin.Should().Be(1);
            game.SecondPlayer.NumberOfSetWin.Should().Be(0);

            game.AddPoint(jean);

            game.AddPoint(jean);

            game.AddPoint(jean);

            game.AddPoint(jean);

            game.FirstPlayer.NumberOfSetWin.Should().Be(2);
            game.SecondPlayer.NumberOfSetWin.Should().Be(0);
            game.GetWinningPlayer().Should().Be(jean);
        }

        [Test]
        public void FullGameOneEqualityTest()
        {
            Player jean = new Player("Jean", "Sebastien");
            Player marc = new Player("Marc", "Antoine");

            Game game = new Game(jean, marc, 2);

            game.Begin();

            game.HasBegin.Should().BeTrue();

            game.AddPoint(jean);

            game.AddPoint(jean);

            game.AddPoint(jean);

            game.AddPoint(marc);

            game.AddPoint(marc);

            game.AddPoint(marc);

            game.FirstPlayer.Score.Should().Be(Score.Forty);
            game.SecondPlayer.Score.Should().Be(Score.Forty);
            game.FirstPlayer.NumberOfSetWin.Should().Be(0);
            game.SecondPlayer.NumberOfSetWin.Should().Be(0);

            game.AddPoint(jean);

            game.FirstPlayer.Score.Should().Be(Score.Advantage);
            game.SecondPlayer.Score.Should().Be(Score.Forty);
            game.FirstPlayer.NumberOfSetWin.Should().Be(0);
            game.SecondPlayer.NumberOfSetWin.Should().Be(0);

            game.AddPoint(marc);

            game.FirstPlayer.Score.Should().Be(Score.Forty);
            game.SecondPlayer.Score.Should().Be(Score.Advantage);
            game.FirstPlayer.NumberOfSetWin.Should().Be(0);
            game.SecondPlayer.NumberOfSetWin.Should().Be(0);

            game.AddPoint(jean);

            game.FirstPlayer.Score.Should().Be(Score.Advantage);
            game.SecondPlayer.Score.Should().Be(Score.Forty);
            game.FirstPlayer.NumberOfSetWin.Should().Be(0);
            game.SecondPlayer.NumberOfSetWin.Should().Be(0);

            game.AddPoint(marc);

            game.FirstPlayer.Score.Should().Be(Score.Forty);
            game.SecondPlayer.Score.Should().Be(Score.Advantage);
            game.FirstPlayer.NumberOfSetWin.Should().Be(0);
            game.SecondPlayer.NumberOfSetWin.Should().Be(0);

            game.AddPoint(marc);
            game.FirstPlayer.NumberOfSetWin.Should().Be(0);
            game.SecondPlayer.NumberOfSetWin.Should().Be(1);

            game.AddPoint(marc);

            game.AddPoint(marc);

            game.AddPoint(marc);

            game.AddPoint(marc);

            game.FirstPlayer.NumberOfSetWin.Should().Be(0);
            game.SecondPlayer.NumberOfSetWin.Should().Be(2);
            game.GetWinningPlayer().Should().Be(marc);
        }
    }
}
