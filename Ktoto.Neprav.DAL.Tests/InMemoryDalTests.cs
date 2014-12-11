using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ktoto.Neprav.DAL.Tests
{
    public class Person
    {
        public long Id { get; set; }
    }

    public class Student : Person
    {
        
    }

    public class Teacher : Person
    {
        
    }

    [TestFixture]
    public class InMemoryDalTests
    {
        public class __gwtgwrth
        {
            public int field;
        }

        [Test]
        public void Test()
        {
            var funcs = new List<Func<int>>();
            {
                for (var i = 0; i < 3; i++)
                {
                    funcs.Add(() => i);
                }
            }
            foreach (var ir in funcs)
            {
                Debug.Print(ir().ToString());
            }
        }

        public Func<int> GetIntReturningFunction(int value)
        {
            return () => value;
        }

        public void AttachedEntityIsAvailable()
        {
            var dal = new InMemoryDal();
            var p = new Person();
            dal.Attach(p);
            var p2 = new Person();
            dal.Attach(p2);
            var s = new Student();
            dal.Attach(s);
            var s2 = new Student();
            dal.Attach(s2);


            CollectionAssert.AreEqual(new []{p, p2}, dal.Query<Person>());
            CollectionAssert.AreEqual(new []{s, s2}, dal.Query<Student>());
        }
    }
}
