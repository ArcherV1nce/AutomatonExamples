namespace AutomatonExamples
{
    using AutomatonExamples.Moore_Machine;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Task1_LastThirdInputOutput test = new Task1_LastThirdInputOutput();

            test.OperateInputs();
        }
    }
}