using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
	[Trait("Category", "Player")]
	public class PlayerCharacterShould : IDisposable
	{
		private readonly PlayerCharacter _sut;
		private readonly ITestOutputHelper _output; 

		public PlayerCharacterShould(ITestOutputHelper output)
		{
			_sut = new PlayerCharacter();
			_output = output;
			_output.WriteLine("Creating new PlayerCharacter");
		}

		public void Dispose()
		{
			_output.WriteLine($"Disposing PlayerCharacter {_sut.FullName}");
			//_sut.Dispose();
		}

		[Fact]
		public void BeInexperiencedWhenNew()
		{
			// Assert
			Assert.True(_sut.IsNoob);
		}

		[Fact]
		public void BeExperiencedAfterSetup()
		{
			// Act
			_sut.IsNoob = false;

			// Assert
			Assert.False(_sut.IsNoob);
		}

		[Fact]
		public void CalculateFullName()
		{
			// Act
			_sut.FirstName = "Sarah";
			_sut.LastName = "Smith";

			// Assert
			Assert.Equal("Sarah Smith", _sut.FullName);
		}

		[Fact]
		public void HaveFullNameStartingWithFirstName()
		{
			// Act
			_sut.FirstName = "Chuck";
			_sut.LastName = "Norris";

			// Assert
			Assert.StartsWith("Chuck", _sut.FullName);
		}

		[Fact]
		public void HaveFullNameEndingWithLastName()
		{
			// Act
			_sut.FirstName = "Chuck";
			_sut.LastName = "Norris";

			// Assert
			Assert.EndsWith("Norris", _sut.FullName);
		}

		[Fact]
		public void CalculateFullName_IgnoreCaseAssertExample()
		{
			// Act
			_sut.FirstName = "SARAH";
			_sut.LastName = "SMITH";

			// Assert
			Assert.Equal("Sarah Smith".ToLower(), _sut.FullName, ignoreCase: true);
		}

		[Fact]
		public void CalculateFullName_SubstringAssertExample()
		{
			// Act
			_sut.FirstName = "Chuck";
			_sut.LastName = "Norris";

			// Assert
			Assert.Contains("uck Nor", _sut.FullName);
		}

		[Fact]
		public void CalculateFullNameWitTitleCase()
		{
			// Act
			_sut.FirstName = "Chuck";
			_sut.LastName = "Norris";

			// Assert Checks that 1. letter of firtname and lastname is uppercase
			Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
		}

		[Fact]
		public void StartsWithDefaultHealth()
		{
			// Assert
			Assert.Equal(100, _sut.Health);
		}

		[Fact]
		public void StartsWithDefaultHealth_NotEqual()
		{
			// Assert
			Assert.NotEqual(99, _sut.Health);
		}

		[Fact]
		public void IncreaseHealthAfterSleeping()
		{
			// Act
			_sut.Sleep();
			Console.WriteLine(_sut.Health);

			// Assert Assert.True(_sut.Health >= 101 && _sut.Health <= 200);
			Assert.InRange(_sut.Health, 101, 200);
		}

		[Fact]
		public void DefaultNicknameIsNull()
		{
			// Assert
			Assert.Null(_sut.Nickname);
		}

		[Fact]
		public void StartingWeaponsContainsLongBow()
		{
			// Assert
			Assert.Contains("Long Bow", _sut.Weapons);
		}

		[Fact]
		public void StartingWeaponsContainsShortBow()
		{
			// Assert
			Assert.Contains("Short Bow", _sut.Weapons);
		}

		[Fact]
		public void StartingWeaponsContainsShortSword()
		{
			// Assert
			Assert.Contains("Short Sword", _sut.Weapons);
		}

		[Fact]
		public void StartingWeaponsDoesNotContainCocaCola()
		{
			// Assert
			Assert.DoesNotContain("Coca Cola", _sut.Weapons);
		}

		[Fact]
		public void StartingWeaponsContainsAtLeastOneKindSword()
		{
			// Assert
			Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
		}

		[Fact]
		public void HaveAllExpectedWeapons()
		{
			var expectedWeapons = new[]
			{
				"Long Bow",
				"Short Bow",
				"Short Sword",
			};

			// Assert
			Assert.Equal(expectedWeapons, _sut.Weapons);
		}

		[Fact]
		public void HaveNoEmptyStartingWeapons()
		{
			// Assert
			Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrEmpty(weapon)));
		}

		[Fact]
		public void ShouldRaiseSleptEvent()
		{
			// Assert
			Assert.Raises<EventArgs>(
				handler => _sut.PlayerSlept += handler,
				handler => _sut.PlayerSlept -= handler,
				() => _sut.Sleep());
		}

		[Fact]
		public void ShouldPropertyChangedEvent()
		{
			// Assert
			Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
		}

		[Theory]
		//[InlineData(0, 100)]
		//[InlineData(1, 99)]
		//[InlineData(50, 50)]
		//[InlineData(99, 1)]
		//[InlineData(101, 1)]
		//[MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
		//[MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
		[HealthDamageData]
		public void TakeDamage(int amountOfDamage, int expectedHealth)
		{
			_sut.TakeDamage(amountOfDamage);
			Assert.Equal(expectedHealth, _sut.Health);
		}
	}
}
