﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AutoMapper;
using NUnit.Framework;
using Should;

namespace FunWithAutomapper.Tests.AutoMapperSamples.Mappers
{
	namespace IListSources
	{
		[TestFixture]
		public class Example
		{
			private class CustomCollection : IListSource, IEnumerable<int>
			{
				private List<int> _customList = new List<int>();

				public IList GetList()
				{
					return _customList;
				}

				public bool ContainsListCollection
				{
					get { return true; }
				}

				IEnumerator<int> IEnumerable<int>.GetEnumerator()
				{
					return _customList.GetEnumerator();
				}

				public IEnumerator GetEnumerator()
				{
					return _customList.GetEnumerator();
				}
			}

			private class Source
			{
				public int[] Values { get; set; }
			}

			private class Destination
			{
				public CustomCollection Values { get; set; }
			}

			[Test]
			public void Should_use_the_underlying_list_to_add_values()
			{
				Mapper.Initialize(cfg =>
				{
					cfg.CreateMap<Source, Destination>();
				});

				var destination = Mapper.Map<Source, Destination>(new Source { Values = new[] { 1, 2, 3 } });

				destination.Values.Count().ShouldEqual(3);
			}
		}
	}
}