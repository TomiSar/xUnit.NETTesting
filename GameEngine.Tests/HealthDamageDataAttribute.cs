using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace GameEngine.Tests
{
	public class HealthDamageDataAttribute : DataAttribute
	{
		public override IEnumerable<object[]> GetData(MethodInfo testMethod)
		{
			string[] csvLines = File.ReadAllLines("TestData.csv");
			var testCases = new List<object[]>();

			foreach (var csvline in csvLines)
			{
				IEnumerable<int> values = csvline.Split(",").Select(int.Parse);
				object[] testCase = values.Cast<object>().ToArray();
				testCases.Add(testCase);
			}

			return testCases;
		}
		
	}
}
