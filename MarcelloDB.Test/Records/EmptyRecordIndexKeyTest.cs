﻿using System;
using NUnit.Framework;
using MarcelloDB.Serialization;
using MarcelloDB.Records;

namespace MarcelloDB.Test.Records
{
    [TestFixture]
    public class EmptyRecordIndexKeyTest
    {
        [SetUp]
        public void Initialize()
        {
        }

        [Test]
        public void Can_Be_Serialized()
        {
            var key = new EmptyRecordIndexKey{A = 10, S = 20 };
            var serializer = new BsonSerializer<EmptyRecordIndexKey>();
            var deserialized = serializer.Deserialize(
                                   serializer.Serialize(key)
                               );
            Assert.AreEqual(key.A, deserialized.A);
            Assert.AreEqual(key.S, deserialized.S);
        }

        [Test]
        public void Compares_On_Size_First()
        {
            var key1 = new EmptyRecordIndexKey{S = 1, A = 2 };
            var key2 = new EmptyRecordIndexKey{S = 2, A = 1 };
            Assert.IsTrue(key1.CompareTo(key2) < 0);
        }

        [Test]
        public void Compares_On_Address_When_Size_Is_Equal()
        {
            var key1 = new EmptyRecordIndexKey{S = 1, A = 1 };
            var key2 = new EmptyRecordIndexKey{S = 1, A = 2 };
            Assert.IsTrue(key1.CompareTo(key2) < 0);
        }            
    }
}

