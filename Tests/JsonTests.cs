using NUnit.Framework;
using SM_Programming_Exercise.Library;
using SM_Programming_Exercise.Library.Data;
using System;
using System.IO;

namespace UnitTests
{
    internal class JsonTests
    {
        private string _json;

        [Test]
        public void ExampleCase()
        {
            _json =
                "{TableWidth : 4, TableHeight: 4, TileStartX: 2, TileStartY: 2, " +
                "Commands: [1, 4, 1, 3, 2, 3, 2, 4, 1, 0]}";

            Assert.AreEqual("0, 1", _simulationResult);
        }

        [Test]
        public void ExampleCaseModifiedToFallOfTable()
        {
            _json =
                "{TableWidth : 4, TableHeight: 4, TileStartX: 2, TileStartY: 2, " +
                "Commands: [1, 4, 1, 3, 2, 3, 2, 4, 1, 1, 1, 1, 1, 0]}";

            Assert.AreEqual("-1, -1", _simulationResult);
        }

        /// <summary>
        /// A case with a different sized table
        /// </summary>
        [Test]
        public void LargerTable()
        {
            _json =
                "{TableWidth : 5, TableHeight: 7, TileStartX: 4, TileStartY: 3, " +
                "Commands: [1, 3, 3, 3, 1, 1, 4, 1, 2, 2, 0]}";

            // Should be (2, 1)
            Assert.AreEqual("2, 1", _simulationResult);
        }

        /// <summary>
        /// Case to test if correct answer is given if a quit command
        /// in the middle of the command sequence
        /// </summary>
        [Test]
        public void ObeysQuitCommand()
        {
            _json =
                "{TableWidth : 5, TableHeight: 7, TileStartX: 4, TileStartY: 3, " +
                "Commands: [1, 3, 3, 3, 1, 0, 1, 4, 1, 2, 2, 0]}";

            // Should be (3, 2)
            Assert.AreEqual("3, 2", _simulationResult);
        }

        /// <summary>
        /// Checks for compliance if first command is to quit
        /// </summary>
        [Test]
        public void CorrectIfQuitCommandIsFirstCommand()
        {
            _json =
                "{TableWidth : 3, TableHeight: 7, TileStartX: 1, TileStartY: 3, " +
                "Commands: [0, 1, 3, 4, 3, 1, 4, 1, 4, 1, 2, 2, 0]}";

            // Should be (1, 3)
            Assert.AreEqual("1, 3", _simulationResult);
        }

        /// <summary>
        /// Checks for compliance if starting position is already off the table
        /// </summary>
        [Test]
        public void CorrectIfStartingPositionIsOffTable()
        {
            _json =
                "{TableWidth : 3, TableHeight: 7, TileStartX: 4, TileStartY: 8, " +
                "Commands: [0, 1, 3, 4, 3, 1, 4, 1, 4, 1, 2, 2, 0]}";

            // Should be (-1, -1)
            Assert.AreEqual("-1, -1", _simulationResult);
        }

        /// <summary>
        /// Checks for compliance if there is just one command
        /// </summary>
        [Test]
        public void CorrectIfJustOneCommand()
        {
            _json =
                "{TableWidth : 3, TableHeight: 7, TileStartX: 1, TileStartY: 2, " +
                "Commands: [0]}";

            // Should be (1, 2)
            Assert.AreEqual("1, 2", _simulationResult);
        }

        [Test]
        public void CorrectForSmallestTable()
        {
            _json = "{TableWidth : 1, TableHeight: 1, TileStartX: 0, TileStartY: 0, " +
                "Commands: [3]}";

            // Should be (0, 0)
            Assert.AreEqual("0, 0", _simulationResult);
        }

        /// <summary>
        /// The case from the example, modified to add an invalid int (6)
        /// </summary>
        [Test]
        public void IgnoresInvalidIntCommands()
        {
            _json = "{TableWidth : 4, TableHeight: 4, TileStartX: 2, TileStartY: 2, " +
                "Commands: [1, 6, 4, 1, 3, 2, 3, 2, 4, 1, 0]}";

            // Should be (0, 1)
            Assert.AreEqual("0, 1", _simulationResult);
        }

        [Test]
        public void CorrectWhenMoreComplex()
        {
            _json = "{TableWidth : 11, TableHeight: 12, TileStartX: 2, TileStartY: 11, " +
                "Commands: [1,1,1,1,3,3,3,2,2,3,1,1,1,4,1,2,2,3,3,1,1,1,1,1,0]}";

            Assert.AreEqual("10, 4", _simulationResult);
        }

        [Test]
        public void CorrectWhenMoreComplexAndFallsOff()
        {
            _json = "{TableWidth : 11, TableHeight: 12, TileStartX: 5, TileStartY: 5, " +
                "Commands: [3,1,4,1,1,1,4,2,2,2,4,1,1,1,1,1,3,1,1,3,2,2,2,2,2,1,1,0]}";

            Assert.AreEqual("-1, -1", _simulationResult);
        }

        private string _simulationResult
        {
            get
            {
                Console.SetIn(new StringReader(_json));
                var data = new JsonData();
                var sim = new Simulation(data);
                sim.Run();
                return sim.ResultData;
            }
        }
    }
}