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
            var saveParse = new SaveParse(Path.Combine(TestContext.CurrentContext.TestDirectory, savePath)).ExtractSaveData();
            var _styles = new List<Style>();

            switch (savePath)
            {
                case BN1: //BN1 save has Heat equipped and Aqua, Wood, and Heat added
                    {
                        saveParse.LoadStyles(ref _styles);
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
                        saveParse.LoadStyles(ref _styles);
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
                        saveParse.LoadStyles(ref _styles);
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
        [TestCase(BN2)]
        [TestCase(BN3)]
        public void RegChipLoad(string savePath)
        {
            var saveParse = new SaveParse(Path.Combine(TestContext.CurrentContext.TestDirectory, savePath)).ExtractSaveData();
            
            switch (savePath)
            {
                case BN2:
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.IsTrue(saveParse.RegChip1 == 26);
                            Assert.IsTrue(saveParse.RegChip2 == 4);
                            Assert.IsTrue(saveParse.RegChip3 == 255);
                        });
                        break;
                    }
                case BN3:
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.IsTrue(saveParse.RegChip1 == 21);
                            Assert.IsTrue(saveParse.RegChip2 == 7);
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
        public void StyleChange(string savePath)
        {
            var saveParse = new SaveParse(Path.Combine(TestContext.CurrentContext.TestDirectory, savePath)).ExtractSaveData();

            var _styles = new List<Style>();

            switch (savePath)
            {
                case BN1: //BN1 save has Heat equipped and Aqua, Wood, and Heat added
                    {
                        saveParse.LoadStyles(ref _styles);
                        _styles.FirstOrDefault(x => x.Name == Style.Value.Aqua).Equip = true;
                        _styles.FirstOrDefault(x => x.Name == Style.Value.Heat).Equip = false;
                        _styles.FirstOrDefault(x => x.Name == Style.Value.Wood).Add = false;
                        saveParse.UpdateStyles(ref _styles);
                        Assert.Multiple(() =>
                        {
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.Heat).Equip.Value == false);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.Aqua).Equip.Value == true);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.Heat).Add.Value == true);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.Aqua).Add.Value == true);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.Wood).Add.Value == false);
                        });
                        break;
                    }
                case BN2: //BN2 save has WoodGuts equipped and WoodGuts lvl 2, and AquaShield lvl 1 added
                    {
                        saveParse.LoadStyles(ref _styles);
                        _styles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Equip = true;
                        _styles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Version = 3;
                        _styles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Equip = false;
                        saveParse.UpdateStyles(ref _styles);
                        Assert.Multiple(() =>
                        {
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Equip.Value == true);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Version.Value == 3);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.WoodGuts).Equip.Value == false);
                        });
                        break;
                    }
                case BN3: //BN3 save has ElecShield lvl 3 equipped and added
                    {
                        saveParse.LoadStyles(ref _styles);
                        _styles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Equip = false;
                        _styles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Add = false;
                        _styles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Equip = true;
                        _styles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Version = 3;
                        saveParse.UpdateStyles(ref _styles);
                        saveParse.UpdateStyles(ref _styles);
                        Assert.Multiple(() =>
                        {
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Equip.Value == true);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Equip.Value == false);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.ElecShield).Add.Value == false);
                            Assert.IsTrue(_styles.FirstOrDefault(x => x.Name == Style.Value.AquaShield).Version.Value == 3);
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
    }
}