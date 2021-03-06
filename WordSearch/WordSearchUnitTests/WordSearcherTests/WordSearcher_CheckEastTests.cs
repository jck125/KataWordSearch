using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSearchApplication;
using WordSearchApplication.Models;

namespace WordSearchUnitTests.WordSearcherTests
{
    [TestClass]
    public class WordSearcherCheckEastTests
    {
        private WordSearcher _searcher;
        private WordSearchBoard _board;
        private List<string> _lines;

        private List<Coordinate> _results;

        [TestInitialize]
        public void Setup()
        {
            _results = new List<Coordinate>();
            
            _lines = new List<string>();
            _lines.Add("A,B,C");
            _lines.Add("D,E,F");
            _lines.Add("G,H,I");
            
            _board = new WordSearchBoard(_lines);
        }

        [TestMethod]
        public void TestWithWordToTheEastReturnCoordinates()
        {
            Coordinate coordinate = new Coordinate(1,1);
            string word = "EF";

            _searcher = new WordSearcher();
            _results = _searcher.CheckEast(_board, coordinate, word);
            
            Assert.AreEqual(2, _results.Count);
            Assert.AreEqual(1,_results[0].X);
            Assert.AreEqual(1,_results[0].Y);
            Assert.AreEqual(2,_results[1].X);
            Assert.AreEqual(1,_results[1].Y);
        }

        [TestMethod]
        public void TestWithoutWordToTheEastReturnNull()
        {
            Coordinate coordinate = new Coordinate(1,1);
            string word = "AB";

            _searcher = new WordSearcher();
            
            Assert.IsNull(_searcher.CheckEast(_board, coordinate, word));
        }

        [TestMethod]
        public void TestWithCoordinateOnEastEdgeReturnNull()
        {
            Coordinate coordinate = new Coordinate(0,1);
            string word = "DBC";

            _searcher = new WordSearcher();
            
            Assert.IsNull(_searcher.CheckEast(_board, coordinate, word));
        }

        [TestMethod]
        public void TestWithPartialWordReturnNull()
        {
            Coordinate coordinate = new Coordinate(2,1);
            string word = "FEA";

            _searcher = new WordSearcher();
            
            Assert.IsNull(_searcher.CheckEast(_board, coordinate, word));
        }

        [TestMethod]
        public void TestWithPartialWordAgainstEastEdgeReturnNull()
        {
            Coordinate coordinate = new Coordinate(1,1);
            string word = "EDA";

            _searcher = new WordSearcher();
            
            Assert.IsNull(_searcher.CheckEast(_board, coordinate, word));
        }
    }
}