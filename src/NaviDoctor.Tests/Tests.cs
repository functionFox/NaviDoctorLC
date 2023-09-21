using NaviDoctor.models;

namespace NaviDoctor.Tests
{
    public class Tests
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
        public void SaveLoad(string savePath)
        {
            var saveParse = new SaveParse(Path.Combine(TestContext.CurrentContext.TestDirectory, savePath));
            Assert.NotNull(saveParse.ExtractSaveData());
        }

        [Test]
        [TestCase(BN1)]
        [TestCase(BN2)]
        [TestCase(BN3)]
        public void StyleLoad(string savePath)
        {
            var saveParse = new SaveParse(Path.Combine(TestContext.CurrentContext.TestDirectory, savePath));
            var extractedSaveParse = saveParse.ExtractSaveData();
            var _styles = new List<Style>();

            switch (savePath)
            {
                case BN1: //BN1 save has Heat equipped and Aqua, Wood, and Heat added
                    {
                        extractedSaveParse.LoadStyles(ref _styles);
                        Assert.Multiple(() =>
                        {
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.Heat).Equip.Value == true);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.Heat).Add.Value == true);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.Aqua).Add.Value == true);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.Wood).Add.Value == true);
                        });
                        break;
                    }
                case BN2: //BN2 save has WoodGuts equipped and WoodGuts lvl 2, and AquaShield lvl 1 added
                    {
                        extractedSaveParse.LoadStyles(ref _styles);
                        Assert.Multiple(() =>
                        {
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Equip.Value == true);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Version.Value == 2);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Add.Value == true);
                        });
                        break;
                    }
                case BN3: //BN3 save has ElecShield lvl 3 equipped and added
                    {
                        extractedSaveParse.LoadStyles(ref _styles);
                        Assert.Multiple(() =>
                        {
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Equip.Value == true);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Add.Value == true);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Version.Value == 3);
                        });
                        break;
                    }
                default:
                    {
                        Assert.IsTrue(false);
                        break;
                    }
            }
        }

        [Test]
        [TestCase(BN1)]
        [TestCase(BN2)]
        [TestCase(BN3)]
        public void RegChipLoad(string savePath)
        {
            var saveParse = new SaveParse(Path.Combine(TestContext.CurrentContext.TestDirectory, savePath));
            switch (savePath)
            {
                case BN1:
                    {
                        break;
                    }
                case BN2:
                    {
                        break;
                    }
                case BN3:
                    {
                        break;
                    }
                default:
                    {
                        Assert.IsTrue(false);
                        break;
                    }
            }
        }

        [Test]
        [TestCase(BN1)]
        [TestCase(BN2)]
        [TestCase(BN3)]
        public void StyleChangeAndSave(string savePath)
        {
            var saveParse = new SaveParse(Path.Combine(TestContext.CurrentContext.TestDirectory, savePath));
            switch (savePath)
            {
                case BN1:
                    {
                        break;
                    }
                case BN2:
                    {
                        break;
                    }
                case BN3:
                    {
                        break;
                    }
                default:
                    {
                        Assert.IsTrue(false);
                        break;
                    }
            }
        }

        [Test]
        [TestCase(BN1)]
        [TestCase(BN2)]
        [TestCase(BN3)]
        public void RegChipChangeAndSave(string savePath)
        {
            var saveParse = new SaveParse(Path.Combine(TestContext.CurrentContext.TestDirectory, savePath));
            switch (savePath)
            {
                case BN1:
                    {
                        break;
                    }
                case BN2:
                    {
                        break;
                    }
                case BN3:
                    {
                        break;
                    }
                default:
                    {
                        Assert.IsTrue(false);
                        break;
                    }
            }
        }
    }
}