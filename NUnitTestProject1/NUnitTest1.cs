using System;
using NUnit.Framework;
using kurs_part2;

namespace NUnitTestProject1
{
    [TestFixture]
    public class TestSet
    {
        [Test]
        public void TestLess()
        {
            string s1 = "90,80,60,70,20";
            string s2 = "50,50,60,30,20";
            Set S1 = new Set("1", Utils.ToIntArray(s1.Split(','), ",")[0]);
            Set S2 = new Set("2", Utils.ToIntArray(s2.Split(','), ",")[0]);
            Assert.IsTrue(S2.Less(S1), "S2 is not less than S1");
        }
    }

    [TestFixture]
    public class TestTable
    {
        [Test]
        public void TestOptimize()
        {
            string[] names = { "1", "2", "3", "4", "5", "6", "7", "8" };
            int[][] data = Utils.ToIntArray(FileUtils.ReadText("input.txt"), " ,\n");
            Table table = new Table(names, data);

            table.Optimize();
            int i = 1;
            foreach(Set S in table)
            {
                Assert.IsTrue(int.Parse(S.name) < 7,string.Format( "Row #{0} wasn't deleted", S.name));
                Assert.IsTrue(i == int.Parse(S.name), string.Format("Row #{0} was deleted", S.name));
                i++;
            }

            
        }
    }
}