using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleProject.Tests
{
    [TestFixture]
    internal class Tests
    {
        People p;
        [SetUp]
        public void Setup()
        {
            p = new People();
        }

        [Test]

        public void AddNegativeAge()
        {
            Assert.That(() => p.UjSzemely(-4), Throws.TypeOf<ArgumentException>());
        }

        [Test]

        public void AddAge()
        {
            p.UjSzemely(10);
            Assert.That(p.Eletkorok[0], Is.EqualTo(10));
        }

        [Test]

        public void AverageWhenEmptyList()
        {
            Assert.That(() => p.AtlagEletkor(1, 10), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Average()
        {
            p.UjSzemely(10);
            p.UjSzemely(20);
            p.UjSzemely(30);
            p.UjSzemely(40);

            Assert.That(p.AtlagEletkor(1, 25), Is.EqualTo(15));
        }

        [Test]

        public void WrongMinEletkor()
        {
            p.UjSzemely(10);

            Assert.That(() => p.AtlagEletkor(-1, 10), Throws.TypeOf<ArgumentException>());

        }

        [Test]

        public void WrongMaxEletkor()
        {
            p.UjSzemely(10);

            Assert.That(() => p.AtlagEletkor(1, -20), Throws.TypeOf<ArgumentException>());

        }

        [Test]

        public void SmallerMaxThanMin()
        {
            p.UjSzemely(10);
            Assert.That(() => p.AtlagEletkor(10, 1), Throws.TypeOf<ArgumentException>());

        }

        [Test]

        public void NoItemsInAverageRange()
        {
            p.UjSzemely(10);
            Assert.That(() => p.AtlagEletkor(1, 2), Throws.TypeOf<ArgumentException>());

        }

        [Test]
        public void AverageAllAdult()
        {
            p.UjSzemely(10);
            p.UjSzemely(20);
            p.UjSzemely(30);
            Assert.That(p.KategoriaAtlagOsszesbol(), Is.EqualTo("Felnőtt"));

        }
        [Test]
        public void AverageAllChild()
        {
            p.UjSzemely(10);
            p.UjSzemely(20);

            Assert.That(p.KategoriaAtlagOsszesbol(), Is.EqualTo("Gyerek"));

        }
        [Test]
        public void AverageAllOld()
        {
            p.UjSzemely(60);

            p.UjSzemely(70);
            p.UjSzemely(80);
            p.UjSzemely(90);
            Assert.That(p.KategoriaAtlagOsszesbol(), Is.EqualTo("Nyugdíjas"));

        }

        [Test]
        public void AverageAllWithNoItems()
        {
            Assert.That(() => p.KategoriaAtlagOsszesbol(), Throws.TypeOf<InvalidOperationException>());

        }

    }
}
