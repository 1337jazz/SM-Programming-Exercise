using System;
using System.Collections.Generic;
using System.Text;

namespace SM_Programming_Exercise.Library.Data
{
    /// <summary>
    /// This class exists purely to make the BinaryData class testable
    /// </summary>
    public class TBinaryData : StdinData
    {
        public string firstHeaderTest { get; set; }
        public string secondHeaderTest { get; set; }

        public TBinaryData(string firstData, string secondData)
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