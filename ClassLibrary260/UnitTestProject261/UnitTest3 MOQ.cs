using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary260;
using Moq;

namespace UnitTestProject261
{
    //Testing throught Mock-objects 
    [TestClass]
    public class UnitTest3_MOQ
    {
        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        //call tests using stubs

        [TestMethod]
        public void EmptyTrue()
        {
            Resource r1 = new Resource(new Dictionary<ResourceType, float>
                            {
                                {ResourceType.Gold, 4.3f },
                                {ResourceType.Stone, 8 },
                                {ResourceType.Wood, 0 }
                            });
            var mock = new Mock<IResourceManager>();
            mock.Setup(a => a.IsEmpty(r1)).Returns(false);  // stub (IsEmpty) return false
            IResourceManager Rm = mock.Object;
            Assert.AreEqual(Rm.IsEmpty(r1), false);
        }

        [TestMethod]
        public void EmptyFalse()
        {
            Resource r1 = new Resource();
            var mock = new Mock<IResourceManager>();
            mock.Setup(a => a.IsEmpty(r1)).Returns(true);  // stub (IsEmpty) return true
            IResourceManager Rm = mock.Object;
            Assert.AreNotEqual(Rm.IsEmpty(r1), false);
        }

        [TestMethod]
        public void EnoughtTrue()   //will the user have enough resusov (resources need more or equal)
        {
            Resource r1 = new Resource(new Dictionary<ResourceType, float>
                {
                    {ResourceType.Gold, 27 },
                    {ResourceType.Stone, 755 },
                    {ResourceType.Wood, 758 }
                });
            Resource rNeed = new Resource(new Dictionary<ResourceType, float>
                {
                    {ResourceType.Gold, 5 },
                    {ResourceType.Stone, 85 },
                    {ResourceType.Wood, 6 }
                });
            var mock = new Mock<IResourceManager>();
            mock.Setup(a => a.IsEnough(r1,rNeed)).Returns(true);  // stub (IsEnough) return true
            IResourceManager Rm = mock.Object;
            Assert.AreEqual(Rm.IsEnough(r1, rNeed), true);
        }

        [TestMethod]
        public void EnoughtFalse()
        {
            Resource r1 = new Resource(new Dictionary<ResourceType, float>
                {
                    {ResourceType.Gold, 27 },
                    {ResourceType.Stone, 755 },
                    {ResourceType.Wood, 758 }
                });
            Resource rNeed = new Resource(new Dictionary<ResourceType, float>
                {
                    {ResourceType.Gold, 5 },
                    {ResourceType.Stone, 85 },
                    {ResourceType.Wood, 6 }
                });
            var mock = new Mock<IResourceManager>();
            mock.Setup(a => a.IsEnough(r1, rNeed)).Returns(true);  // stub (IsEnough) return true
            IResourceManager Rm = mock.Object;
            Assert.AreNotEqual(Rm.IsEnough(r1, rNeed), false);
        }

        [TestMethod]
        public void TruncateSuccess()   //truncate resources to the required size
        {
            Resource r1 = new Resource(new Dictionary<ResourceType, float>
                {
                    {ResourceType.Gold, 27 },
                    {ResourceType.Stone, 755 },
                    {ResourceType.Wood, 758 }
                });
            Resource r2 = new Resource(new Dictionary<ResourceType, float>
                {
                    {ResourceType.Gold, 27 },
                    {ResourceType.Stone, 755 },
                    {ResourceType.Wood, 758 }
                });
            Resource rNeed = new Resource(new Dictionary<ResourceType, float>
                {
                    {ResourceType.Gold, 5 },
                    {ResourceType.Stone, 85 },
                    {ResourceType.Wood, 6 }
                });

            var mock = new Mock<IResourceManager>();
            mock.Setup(a => a.Truncate(r1, rNeed)).Returns(rNeed);  // stub (Truncate) return rNeed
            IResourceManager Rm = mock.Object;
            Assert.AreEqual(r1, r2);    //before truncate r1=r2
            Assert.AreNotEqual(Rm.Truncate(r1, rNeed), r2);    //after truncatw r1!=r2
        }
    }
}
