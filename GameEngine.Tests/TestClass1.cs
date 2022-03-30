using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
	[Collection("GameState collection")]
	[Trait("Category", "Collection")]
	public class TestClass1
	{
		private readonly GameStateFixture _gameStateFixture;
		private readonly ITestOutputHelper _output;

		public TestClass1(GameStateFixture gameStateFixture, ITestOutputHelper output)
		{
			_gameStateFixture = gameStateFixture;
			_output = output;
		}

		[Fact(Skip = "Dummy test1 no need to run this")]
		public void Test1()
		{
			_output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
		}

		[Fact(Skip = "Dummy test2 no need to run this")]
		public void Test2()
		{
			_output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
		}
	}
}
