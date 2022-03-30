using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
	public class GameStateShould : IClassFixture<GameStateFixture>
	{
		private readonly GameStateFixture _gameStateFixture;
		private readonly ITestOutputHelper _output;
		public GameStateShould(GameStateFixture gameStateFixture, ITestOutputHelper output)
		{
			_gameStateFixture = gameStateFixture;
			_output = output;
		}

		[Fact]
		public void DamageAllPlayersIfEarthquakeOccurs()
		{
			// Arr
			_output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
			var player1 = new PlayerCharacter();
			var player2 = new PlayerCharacter();

			// Act
			_gameStateFixture.State.Players.Add(player1);
			_gameStateFixture.State.Players.Add(player2);
			player2.Health = 200;
			var expectedHealthAfterEarthquakePlayer1 = player1.Health - GameState.EarthquakeDamage;
			var expectedHealthAfterEarthquakePlayer2 = player2.Health - GameState.EarthquakeDamage;
			_gameStateFixture.State.Earthquake();

			// Assert
			Assert.Equal(expectedHealthAfterEarthquakePlayer1, player1.Health);
			Assert.Equal(expectedHealthAfterEarthquakePlayer2, player2.Health);
		}

		[Fact]
		public void Reset()
		{
			// Arr
			_output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
			var player1 = new PlayerCharacter();
			var player2 = new PlayerCharacter();

			// Act
			_gameStateFixture.State.Players.Add(player1);
			_gameStateFixture.State.Players.Add(player2);
			_gameStateFixture.State.ClearAllPlayers();

			// Assert
			Assert.Empty(_gameStateFixture.State.Players);
		}
	}
}
