using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
	public class BossEnemyShould
	{
		private readonly ITestOutputHelper _output;

		public BossEnemyShould(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		[Trait("Category", "Boss")]
		public void EnemyHaveCorrectPower()
		{
			// Arr
			_output.WriteLine("Creating Boss Enemy");
			BossEnemy sut = new BossEnemy();

			// Assert
			Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
		}

	}
}
