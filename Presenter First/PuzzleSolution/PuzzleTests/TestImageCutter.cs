using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace org.Puzzle.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class TestImageCutter
    {
        private ImageCutter cutter;

        [SetUp]
        public void SetUp()
        {
            cutter = new ImageCutter();
        }

        [TearDown]
        public void TearDown()
        {
        }

        //
        // Helpers
        //

        //
        // Tests
        //
        [Test]
        public void test_CutImage()
        {
            var dllPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var outPutDirectory = Path.GetDirectoryName(dllPath);
            var imagePath = Path.Combine(outPutDirectory, @"Images\USS Enterprise.jpg");
            Image wholeImage = Image.FromFile(imagePath);

            Image[][] got = cutter.CutImage(wholeImage);
            Assert.AreEqual(3, got.Length);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(3, got[i].Length);
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(new Size(100, 100), got[i][j].Size);
                }
            }
        }
    }
}
