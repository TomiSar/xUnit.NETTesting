using System;
using Xunit;

namespace GameEngine.Tests
{
	[Trait("Category", "Enemy")]
	public class EnemyFactoryShould
	{
		private readonly EnemyFactory _sut;
		public EnemyFactoryShould()
		{
			_sut = new EnemyFactory();
		}

		[Fact]
		public void CreateNormalEnemyByDefault()
		{
			// Act
			Enemy enemy = _sut.Create("Zombie");

			// Assert
			Assert.IsType<NormalEnemy>(enemy);
		}

		// Skip test [Fact(Skip = "No need to test this")]
		[Fact]
		public void CreateNormalEnemyByDefault_NotType()
		{
			// Act
			Enemy enemy = _sut.Create("Zombie");

			// Assert
			Assert.IsNotType<DateTime>(enemy);
		}

		[Fact]
		public void CreateBossEnemy()
		{
			// Act
			Enemy enemy = _sut.Create("Zombie King", true);

			// Assert
			Assert.IsType<BossEnemy>(enemy);
		}

		[Fact]
		public void CreateBossEnemy_CastReturnedTypeExample()
		{
			// Act
			Enemy enemy = _sut.Create("Zombie King", true);

			// Assert and cast result
			BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

			// Assert
			Assert.Equal("Zombie King", boss.Name);
		}

		[Fact]
		public void CreateBossEnemy_AssertAssignableTypes()
		{
			// Act
			Enemy enemy = _sut.Create("Zombie King", true);

			// Assert
			Assert.IsAssignableFrom<Enemy>(enemy);
		}

		[Fact]
		public void CreateSeparateIntances()
		{
			// Act
			Enemy enemy1 = _sut.Create("Zombie");
			Enemy enemy2 = _sut.Create("Zombie");

			// Assert
			Assert.NotSame(enemy1, enemy2);
		}

		[Fact]
		public void NotAllowNullName()
		{
			// Act
			//Enemy enemy = _sut.Create(null);

			// Assert
			Assert.Throws<ArgumentNullException>(() => _sut.Create(null));
		}

		[Fact]
		public void OnlyAllowKingOrQueenBossEnemies()
		{
			// Assert
			EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => _sut.Create("Zombie", true));
			Assert.Equal("Zombie", ex.RequestedEnemyName);
		}
	}
}
