using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredSolution.Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void ElsoTest()
        {

        } 

        [Test]
        public void Osszeadas_1es_2_eseten_3mat_eredmenyez()
        {
            //Arrange: Környezet beállítása
            int a = 1, b = 2;
            //Act: Teszt végrehajtása
            int result = a + b;
            //Assert: Eredmény kiértékelése
            Assert.AreEqual(3, result, "Összeadásnak működnie kell.");
        }

        [Test]
        public void AssertTesztek()
        {
            Assert.AreEqual(1, 1);
            Assert.Contains("A", new[] { "A", "B", "C" });
            Assert.AreNotEqual(1, 2);
            Assert.AreNotSame(new object(), new object());
            var o = new object();
            var i = o;
            Assert.AreSame(o, i);
            Assert.Catch(typeof(NotImplementedException), () => { throw new NotImplementedException(); });
            Assert.DoesNotThrow(() => { Console.WriteLine("Hello"); });
            Assert.True(1 == 1);
            Assert.False(1 == 2);
            Assert.IsInstanceOf(typeof(IEnumerable<int>), new List<int>());
            StringAssert.IsMatch("^a.*", "abc");
        }

        [Test]
        public void FluentAssertions()
        {
            var result = "";
            result.Should().BeEmpty();

        }


    }
}
