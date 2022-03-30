using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
	public class NonPlayerCharacterShould
	{
		[Theory]
		//[MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
		//[MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
		[HealthDamageData]
		public void TakeDamage(int amountOfDamage, int expectedHealth)
		{
			NonPlayerCharacter sut = new NonPlayerCharacter();
			sut.TakeDamage(amountOfDamage);
			Assert.Equal(expectedHealth, sut.Health);
		}
	}
}
