using System;
using AutoMapper.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;

namespace FunWithAutomapper.Tests
{
	public class Source
	{
		public int SomeValue { get; set; }
	}

	public class Destination
	{
		public int SomeValuefff { get; set; }
	}
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			// Arrange
			//Mapper.CreateMap<Source, Destination>();

			Mapper.CreateMap<Source, Destination>()
	.ForMember(dest => dest.SomeValuefff, opt => opt.Ignore());
			// Act

			// Assert
			Mapper.AssertConfigurationIsValid();

		}


		[TestMethod]
		public void TestMethod2()
		{
			// Arrange
			//Mapper.CreateMap<Source, Destination>();

			Mapper.CreateMap<Source, Destination>()
	.ForMember(dest => dest.SomeValuefff, opt => opt.Ignore());
			// Act

			// Assert
			Mapper.AssertConfigurationIsValid();

		}


	}


}
