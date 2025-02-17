﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Dapper;
using NUnit.Framework;

namespace Moq.Dapper.Test
{
    [TestFixture]
    public class DapperQueryAsyncTest
    {
        [Test]
        public void QueryAsyncGeneric()
        {
            var connection = new Mock<DbConnection>();

            var expected = new[] { 7, 77, 777 };

            connection.SetupDapperAsync(c => c.QueryAsync<int>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QueryAsync<int>("").GetAwaiter().GetResult().ToList();

            Assert.That(actual.Count, Is.EqualTo(expected.Length));
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void QueryAsyncGenericUsingDbConnectionInterface()
        {
            var connection = new Mock<IDbConnection>();

            var expected = new[] { 7, 77, 777 };

            connection.SetupDapperAsync(c => c.QueryAsync<int>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QueryAsync<int>("").GetAwaiter().GetResult().ToList();

            Assert.That(actual.Count, Is.EqualTo(expected.Length));
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void QuerySingleAsyncGeneric()
        {
            var connection = new Mock<DbConnection>();

            var expected = 7;

            connection.SetupDapperAsync(c => c.QuerySingleAsync<int>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QuerySingleAsync<int>("").GetAwaiter().GetResult();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void QuerySingleAsyncGenericUsingDbConnectionInterface()
        {
            var connection = new Mock<IDbConnection>();

            var expected = 7;

            connection.SetupDapperAsync(c => c.QuerySingleAsync<int>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QuerySingleAsync<int>("").GetAwaiter().GetResult();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void QuerySingleOrDefaultAsyncGeneric()
        {
            var connection = new Mock<DbConnection>();

            var expected = 7;

            connection.SetupDapperAsync(c => c.QuerySingleOrDefaultAsync<int>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QuerySingleOrDefaultAsync<int>("").GetAwaiter().GetResult();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void QuerySingleOrDefaultAsyncGenericUsingDbConnectionInterface()
        {
            var connection = new Mock<IDbConnection>();

            var expected = 7;

            connection.SetupDapperAsync(c => c.QuerySingleOrDefaultAsync<int>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QuerySingleOrDefaultAsync<int>("").GetAwaiter().GetResult();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void QueryFirstAsyncGeneric()
        {
            var connection = new Mock<DbConnection>();

            var expected = 7;

            connection.SetupDapperAsync(c => c.QueryFirstAsync<int>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QueryFirstAsync<int>("").GetAwaiter().GetResult();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void QueryFirstAsyncGenericUsingDbConnectionInterface()
        {
            var connection = new Mock<DbConnection>();

            var expected = 7;

            connection.SetupDapperAsync(c => c.QueryFirstAsync<int>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QueryFirstAsync<int>("").GetAwaiter().GetResult();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void QueryFirstOrDefaultAsyncGeneric()
        {
            var connection = new Mock<DbConnection>();

            var expected = 7;

            connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<int>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QueryFirstOrDefaultAsync<int>("").GetAwaiter().GetResult();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void QueryFirstOrDefaultAsyncGenericUsingDbConnectionInterface()
        {
            var connection = new Mock<DbConnection>();

            var expected = 7;

            connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<int>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QueryFirstOrDefaultAsync<int>("").GetAwaiter().GetResult();

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void QueryAsyncGenericComplexType()
        {
            var connection = new Mock<DbConnection>();

            var expected = new[]
            {
                new ComplexType
                {
                    StringProperty = "String1",
                    IntegerProperty = 7,
                    LongProperty = 70,
                    BigIntegerProperty = 700,
                    GuidProperty = Guid.Parse("CF01F32D-A55B-4C4A-9B33-AAC1C20A85BB"),
                    DateTimeProperty = new DateTime(2000, 1, 1),
                    NullableDateTimeProperty = new DateTime(2000, 1, 1),
                    NullableIntegerProperty = 9,
                    ByteArrayPropery = new byte[] { 7 },
                    EnumProperty = ComplexType.EnumType.First
                },
                new ComplexType
                {
                    StringProperty = "String2",
                    IntegerProperty = 77,
                    LongProperty = 770,
                    BigIntegerProperty = 7700,
                    GuidProperty = Guid.Parse("FBECE122-6E2E-4791-B781-C30843DFE343"),
                    DateTimeProperty = new DateTime(2000, 1, 2),
                    NullableDateTimeProperty = new DateTime(2000, 1, 2),
                    NullableIntegerProperty = 99,
                    ByteArrayPropery = new byte[] { 7, 7 },
                    EnumProperty = ComplexType.EnumType.Second
                },
                new ComplexType
                {
                    StringProperty = "String3",
                    IntegerProperty = 777,
                    LongProperty = 7770,
                    BigIntegerProperty = 77700,
                    GuidProperty = Guid.Parse("712B6DA1-71D8-4D60-8FEF-3F4800A6B04F"),
                    DateTimeProperty = new DateTime(2000, 1, 3),
                    NullableDateTimeProperty = null,
                    NullableIntegerProperty = null,
                    ByteArrayPropery = new byte[] { 7, 7, 7 },
                    EnumProperty = ComplexType.EnumType.Third
                }
            };

            connection.SetupDapperAsync(c => c.QueryAsync<ComplexType>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object
                                   .QueryAsync<ComplexType>("")
                                   .GetAwaiter()
                                   .GetResult()
                                   .ToList();

            Assert.That(actual.Count, Is.EqualTo(expected.Length));

            foreach (var complexObject in expected)
            {
                var match = actual.Where(co => co.StringProperty == complexObject.StringProperty &&
                                               co.IntegerProperty == complexObject.IntegerProperty &&
                                               co.LongProperty == complexObject.LongProperty &&
                                               co.BigIntegerProperty == complexObject.BigIntegerProperty &&
                                               co.GuidProperty == complexObject.GuidProperty &&
                                               co.DateTimeProperty == complexObject.DateTimeProperty &&
                                               co.NullableIntegerProperty == complexObject.NullableIntegerProperty &&
                                               co.NullableDateTimeProperty == complexObject.NullableDateTimeProperty &&
                                               co.ByteArrayPropery == complexObject.ByteArrayPropery);

                Assert.That(match.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void QuerySingleOrDefaultAsyncWithComplexType()
        {
            var connection = new Mock<IDbConnection>();

            var expected = new ComplexType
            {
                StringProperty = "String1",
                IntegerProperty = 7,
                LongProperty = 70,
                BigIntegerProperty = 700,
                GuidProperty = Guid.Parse("CF01F32D-A55B-4C4A-9B33-AAC1C20A85BB"),
                DateTimeProperty = new DateTime(2000, 1, 1),
                NullableDateTimeProperty = new DateTime(2000, 1, 1),
                NullableIntegerProperty = 9,
                ByteArrayPropery = new byte[] { 1, 2, 4, 8 },
                EnumProperty = ComplexType.EnumType.First
            };

            connection.SetupDapperAsync(c => c.QuerySingleOrDefaultAsync<ComplexType>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QuerySingleOrDefaultAsync<ComplexType>("")
                                          .GetAwaiter()
                                          .GetResult();

            Assert.That(actual.StringProperty, Is.EqualTo(expected.StringProperty));
        }

        [Test]
        public void QuerySingleOrDefaultAsyncWithComplexTypeAsNull()
        {
            var connection = new Mock<IDbConnection>();

            connection.SetupDapperAsync(c => c.QuerySingleOrDefaultAsync<ComplexType>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync((ComplexType)null);

            var actual = connection.Object.QuerySingleOrDefaultAsync<ComplexType>("")
                                          .GetAwaiter()
                                          .GetResult();

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void QueryFirstOrDefaultAsyncWithComplexType()
        {
            var connection = new Mock<IDbConnection>();

            var expected = new ComplexType
            {
                StringProperty = "String1",
                IntegerProperty = 7,
                LongProperty = 70,
                BigIntegerProperty = 700,
                GuidProperty = Guid.Parse("CF01F32D-A55B-4C4A-9B33-AAC1C20A85BB"),
                DateTimeProperty = new DateTime(2000, 1, 1),
                NullableDateTimeProperty = new DateTime(2000, 1, 1),
                NullableIntegerProperty = 9,
                ByteArrayPropery = new byte[] { 1, 2, 4, 8 },
                EnumProperty = ComplexType.EnumType.First
            };

            connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<ComplexType>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync(expected);

            var actual = connection.Object.QueryFirstOrDefaultAsync<ComplexType>("")
                                          .GetAwaiter()
                                          .GetResult();

            Assert.That(actual.StringProperty, Is.EqualTo(expected.StringProperty));
        }

        [Test]
        public void QueryFirstOrDefaultAsyncWithComplexTypeAsNull()
        {
            var connection = new Mock<IDbConnection>();

            connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<ComplexType>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync((ComplexType)null);

            var actual = connection.Object.QueryFirstOrDefaultAsync<ComplexType>("")
                                          .GetAwaiter()
                                          .GetResult();

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void QuerySingleOrDefaultAsyncString()
        {
            var connection = new Mock<IDbConnection>();

            connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<string>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync((string)null);

            var actual = connection.Object.QueryFirstOrDefaultAsync<string>("")
                                          .GetAwaiter()
                                          .GetResult();

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void QueryFirstOrDefaultAsyncString()
        {
            var connection = new Mock<IDbConnection>();

            connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<string>(It.IsAny<string>(), null, null, null, null))
                      .ReturnsAsync((string)null);

            var actual = connection.Object.QueryFirstOrDefaultAsync<string>("")
                                          .GetAwaiter()
                                          .GetResult();

            Assert.That(actual, Is.Null);
        }

        public class ComplexType
        {
            public enum EnumType
            {
                First,
                Second,
                Third
            }
            public BigInteger BigIntegerProperty { get; set; }
            public long LongProperty { get; set; }
            public int IntegerProperty { get; set; }
            public string StringProperty { get; set; }
            public Guid GuidProperty { get; set; }
            public DateTime DateTimeProperty { get; set; }
            public DateTime? NullableDateTimeProperty { get; set; }
            public int? NullableIntegerProperty { get; set; }
            public byte[] ByteArrayPropery { get; set; }
            public EnumType EnumProperty { get; set; }
        }
    }
}