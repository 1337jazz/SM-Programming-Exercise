namespace SM_Programming_Exercise.Library.Data
{
    /// <summary>
    /// This class exists purely to make the StdinData class testable
    /// </summary>
    public class TestStdinData : StdinData
    {
        /// <summary>
        /// This constructor exists in order to set the read argument of the
        /// base class's constructor to 'false' so Unit Tests can feed in their
        /// own strings for header data
        /// </summary>
        /// <param name="read"></param>
        public TestStdinData(bool read) : base(read)
        {
        }

        public string FirstHeader { get; set; }
        public string SecondHeader { get; set; }

        /// <summary>
        /// Main read method, a clone of the Stdin class, so this
        /// could probably be implemented by wrapping the Console.ReadLine()
        /// method, however it is implemented this way for future flexibility,
        /// and also to demonstrate child/parent class relationships
        /// </summary>
        protected override void Read()
        {
            int[] arrFirstHeader = ToIntArray(FirstHeader);
            int[] arrSecondHeader = ToIntArray(SecondHeader);

            TableWidth = arrFirstHeader[0];
            TableHeight = arrFirstHeader[1];
            TileStartX = arrFirstHeader[2];
            TileStartY = arrFirstHeader[3];
            CommandList = TranslateCommands(arrSecondHeader);
        }

        /// <summary>
        /// Calls the private method - again this practice is just for testing purposes
        /// </summary>
        public void TestRead()
        {
            Read();
        }
    }
}