using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace LayeredSolution.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void ElsoTest()
        {
            
        }

        [Test]
        public void Osszeadas_1es2_eseten_3mat_eredmenyez()
        {
            //Arrange: Környezet beállítása 
            var a = 1;
            var b = 2;
            //Act: Teszt végrehajtása
            var result = a + b;
            //Assert: Eredmények kiértékelése
            Assert.AreEqual(3, result, "Összeadásnak működnie kell.");
        }

        [Test]
        public void BassertTesztek()
        {
            Assert.AreEqual(1,1);
            Assert.Contains("A", new [] {"A", "B", "C"});
            Assert.AreNotEqual(1,2);
            Assert.AreNotSame(new object(), new object());
            var o = new object();
            var i = o;
            Assert.AreSame(o,i);
            Assert.Catch(typeof (NotImplementedException), () =>
                {
                    throw new NotImplementedException();
                });
            Assert.DoesNotThrow(() =>
            {
                Console.WriteLine("Helo");
            });
            Assert.True(1 == 1);
            Assert.False(1 != 1);
            Assert.IsInstanceOf(typeof(IEnumerable<int>), 
                new List<int>());
            StringAssert.IsMatch("^a.*", "abc");
            CollectionAssert.AllItemsAreUnique(new [] {1,2,3});
        }

        [Test]
        public void FluentAssertions()
        {
            var result = "";
            //Mindig ŰShould-al kezdünk.
            result.Should().BeEmpty();
        }
    }
}
