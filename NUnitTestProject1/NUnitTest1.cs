using System;
using NUnit.Framework;
using kurs_part2;

namespace NUnitTestProject1
{
    [TestFixture]
    public class TestSet
    {
        [TestCase("90,80,60,70,20", "50,50,60,30,20")]
        public void TestLess(string input1, string input2)
        {
            Set S1 = new Set("1", Utils.ToIntArray(input1.Split(','), ",")[0]);
            Set S2 = new Set("2", Utils.ToIntArray(input2.Split(','), ",")[0]);
            Assert.IsTrue(S2.Less(S1), "S2 is not less than S1");
        }
    }

    [TestFixture]
    public class TestTable
    {
        [TestCase ("input.txt", " ,\n")]
        public void TestOptimize(string InputFile, string SplitSymbols)
        {

            int[][] data = Utils.ToIntArray(FileUtils.ReadText(InputFile), SplitSymbols);
            string[] names = new string[data.Length];
            for (int k = 0; k < names.Length; k++)
            {
                names[k] = (k + 1).ToString();
            }
            Table table = new Table(names, data);

            table.Optimize();
            int i = 1;
            foreach (Set S in table)
            {
                Assert.IsTrue(int.Parse(S.name) < 7, string.Format("Row #{0} wasn't deleted", S.name));
                Assert.IsTrue(i == int.Parse(S.name), string.Format("Row #{0} was deleted", S.name));
                i++;
            }


        }
    }
}