namespace NaviDoctor.Tests
{
    public class Shared
    {
        private const string BN1 = "saves\\exe1_save_0.bin";
        private const string BN2 = "saves\\exe2j_save_0.bin";
        private const string BN3 = "saves\\exe3w_save_0.bin";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(BN1)]
        [TestCase(BN2)]
        [TestCase(BN3)]
        public void LoadSaves(string savePath)
        {
            var saveParse = new SaveParse(Path.Combine(TestContext.CurrentContext.TestDirectory, savePath));
            Assert.NotNull(saveParse.ExtractSaveData());
        }
    }
}