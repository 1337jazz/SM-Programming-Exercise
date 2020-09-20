using NUnit.Framework;
using SM_Programming_Exercise.Library;
using SM_Programming_Exercise.Library.Data;
using SM_Programming_Exercise.Library.Interfaces;

namespace UnitTests
{
    public class GeneralTests
    {
        private string _head1;
        private string _head2;

        /// <summary>
        /// The case from the example
        /// </summary>
        [Test]
        public void ExampleCase()
        {
            _head1 = "4, 4, 2, 2";
            _head2 = "1, 4, 1, 3, 2, 3, 2, 4, 1, 0";

            // Should be (0, 1)
            Assert.AreEqual("0, 1", SimulationResult(_head1, _head2));
        }

        /// <summary>
        /// The case from the example, but with extra "forward"
        /// commands to force the tile off the table
        /// </summary>
        [Test]
        public void ExampleCaseModifiedToFallOfTable()
        {
            _head1 = "4, 4, 2, 2";
            _head2 = "1, 4, 1, 3, 2, 3, 2, 4, 1, 1, 1, 1, 1, 0";

            // Should be (-1, -1)
            Assert.AreEqual("-1, -1", SimulationResult(_head1, _head2));
        }

        /// <summary>
        /// A case with a different sized table
        /// </summary>
        [Test]
        public void LargerTable()
        {
            _head1 = "5, 7, 4, 3";
            _head2 = "1, 3, 3, 3, 1, 1, 4, 1, 2, 2, 0";

            // Should be (2, 1)
            Assert.AreEqual("2, 1", SimulationResult(_head1, _head2));
        }

        /// <summary>
        /// Case to test if correct answer is given if a quit command
        /// in the middle of the command sequence
        /// </summary>
        [Test]
        public void ObeysQuitCommand()
        {
            _head1 = "5, 7, 4, 3";
            _head2 = "1, 3, 3, 3, 1, 0, 1, 4, 1, 2, 2, 0";

            // Should be (3, 2)
            Assert.AreEqual("3, 2", SimulationResult(_head1, _head2));
        }

        /// <summary>
        /// Checks for compliance if first command is to quit
        /// </summary>
        [Test]
        public void CorrectIfQuitCommandIsFirstCommand()
        {
            _head1 = "3, 7, 1, 3";
            _head2 = "0, 1, 3, 4, 3, 1, 4, 1, 4, 1, 2, 2, 0";

            // Should be (1, 3)
            Assert.AreEqual("1, 3", SimulationResult(_head1, _head2));
        }

        /// <summary>
        /// Checks for compliance if starting position is already off the table
        /// </summary>
        [Test]
        public void CorrectIfStartingPositionIsOffTable()
        {
            _head1 = "3, 7, 4, 8";
            _head2 = "0, 1, 3, 4, 3, 1, 4, 1, 4, 1, 2, 2, 0";

            // Should be (-1, -1)
            Assert.AreEqual("-1, -1", SimulationResult(_head1, _head2));
        }

        /// <summary>
        /// Checks for compliance if there is just one command
        /// </summary>
        [Test]
        public void CorrectIfJustOneCommand()
        {
            _head1 = "3, 7, 1, 2";
            _head2 = "0";

            // Should be (1, 2)
            Assert.AreEqual("1, 2", SimulationResult(_head1, _head2));
        }

        /// <summary>
        /// Private method to get a simulation result based on provided data
        /// </summary>
        /// <param name="firstHeader">The first header (table dimensions and starting position)</param>
        /// <param name="secondHeader">The second header (list of commands)</param>
        /// <returns>String in the format "x, y" representing coordinates on a 2D plane</returns>
        private string SimulationResult(string firstHeader, string secondHeader)
        {
            var data = new TestStdinData(firstHeader, secondHeader);
            data.Read();
            data.Populate();

            var simulation = new Simulation(data);
            simulation.Run();
            return simulation.ResultData;
        }
    }
}