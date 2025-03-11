using SharpModbus;
using SharpModbus.Serial;

namespace Test_ModbusRTU
{
    public class Tests
    {
        public const string MasterCOM = "COM3";

        private SerialSettings ss(string portName)
        {
            return new SerialSettings { PortName = portName, BaudRate = 4800 };
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void RtuOverSerialTest()
        {
            var model = new ModbusModel();
            var scanner = new ModbusRTUScanner();
            using (var master = ModbusMaster.RTU(ss(MasterCOM)))
            {
                // master.WriteCoil(1, 2, true);
                var str = master.ReadHoldingRegister(1, 2);
                Assert.AreEqual(0, str);
            }
        }
    }
}