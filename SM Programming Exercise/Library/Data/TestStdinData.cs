namespace SM_Programming_Exercise.Library.Data
{
    /// <summary>
    /// This class exists purely to make the StdinData class testable
    /// by having a different constructor, and overriding the Read() method
    /// </summary>
    public class TestStdinData : StdinData
    {
        public string firstHeaderTest { get; set; }
        public string secondHeaderTest { get; set; }

        public TestStdinData(string firstData, string secondData)
        {
            firstHeaderTest = firstData;
            secondHeaderTest = secondData;
        }

        public override void Read()
        {
            firstHeader = firstHeaderTest;
            secondHeader = secondHeaderTest;
        }
    }
}