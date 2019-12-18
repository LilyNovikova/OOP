using System;
using NUnit.Framework;
using kurs_part3;

namespace NUnitTestProject1
{
    [TestFixture]
    public class NUnitTest1
    {
        [Test]
        public void example_from_task()
        {
            Web web = new Web();
            web.SourceName = "s";
            web.SinkName = "t";
            web.AddEdge("s", "o", 3);
            web.AddEdge("s", "p", 3);
            web.AddEdge("o", "p", 2);
            web.AddEdge("o", "q", 3);
            web.AddEdge("p", "r", 2);
            web.AddEdge("q", "r", 4);
            web.AddEdge("q", "t", 2);
            web.AddEdge("r", "t", 3);

            web.FordFulkersonAlgorithm();
            Assert.AreEqual(5, web.SummFlow());
        }

        [Test]
        public void example_wiki()
        {
            Web web = new Web();
            web.SourceName = "s";
            web.SinkName = "t";
            web.AddEdge("s", "a", 5);
            web.AddEdge("s", "b", 2);
            web.AddEdge("a", "b", 2);
            web.AddEdge("a", "c", 3);
            web.AddEdge("b", "d", 4);
            web.AddEdge("c", "d", 1);
            web.AddEdge("d", "t", 5);
            web.AddEdge("c", "t", 2);

            web.FordFulkersonAlgorithm();
            Assert.AreEqual(7, web.SummFlow());
        }

        [Test]
        public void no_source()
        {
            try
            {
                Web web = new Web();
                web.SourceName = "s";
                web.SinkName = "t";
                web.AddEdge("o", "p", 2);
                web.AddEdge("o", "q", 3);
                web.AddEdge("p", "r", 2);
                web.AddEdge("q", "r", 4);
                web.AddEdge("q", "t", 2);
                web.AddEdge("r", "t", 3);

                web.FordFulkersonAlgorithm();
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(NullReferenceException), e.GetType(), "Wrong exception");
            }
        }

        [Test]
        public void no_sink()
        {
            try
            {
                Web web = new Web();
                web.SourceName = "s";
                web.SinkName = "t";
                web.AddEdge("s", "a", 5);
                web.AddEdge("s", "b", 2);
                web.AddEdge("o", "p", 2);
                web.AddEdge("o", "q", 3);
                web.AddEdge("p", "r", 2);
                web.AddEdge("q", "r", 4);

                web.FordFulkersonAlgorithm();
            }
            catch (Exception e)
            {
                Assert.AreEqual(typeof(NullReferenceException), e.GetType(), "Wrong exception");
            }
        }

        [Test]
        public void no_way()
        {
            Web web = new Web();
            web.SourceName = "s";
            web.SinkName = "t";
            web.AddEdge("s", "a", 5);
            web.AddEdge("b", "t", 2);
            try
            {
                web.FordFulkersonAlgorithm();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Can't find way from source to sink", e.Message, "Wrong exception");
            }
        }

        [Test]
        public void existing_edge()
        {
            Web web = new Web();
            web.SourceName = "s";
            web.SinkName = "t";
            web.AddEdge("s", "a", 5);
            try
            {
                web.AddEdge("s", "a", 5);
            }
            catch (Exception e)
            {
                Assert.AreEqual( "Trying add an existing edge", e.Message, "Wrong exception");
            }
        }

        [Test]
        public void zero_bandwidth()
        {
            Web web = new Web();
            web.SourceName = "s";
            web.SinkName = "t";
            web.AddEdge("s", "a", 5);
            try
            {
                web.AddEdge("s", "b", 0);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Trying to add edge with bandwidth less 1", e.Message, "Wrong exception");
            }
        }

        [Test]
        public void loop_edge()
        {
            Web web = new Web();
            web.SourceName = "s";
            web.SinkName = "t";
            web.AddEdge("s", "a", 5);
            try
            {
                web.AddEdge("s", "s", 5);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Trying to add loop edge", e.Message, "Wrong exception");
            }
        }
    }
}