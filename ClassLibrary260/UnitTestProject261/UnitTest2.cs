using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary260;
using Moq;

namespace UnitTestProject261
{

    [TestClass]
    public class UnitTest2 : ResourceManager
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
        // call the tests from the code (without stubs)////////////////////////////////////////////////////////////////////////////////////////
       
                [TestMethod]
                public void EmptyTrue() //empty - true (empty dictionary value or not)
                {
                    Resource r1 = new Resource(new Dictionary<ResourceType, float>
                            {
                                {ResourceType.Gold, 4.3f },
                                {ResourceType.Stone, 8 },
                                {ResourceType.Wood, 0 }
                            });
                    Assert.AreEqual(IsEmpty(r1), false);
                }

                [TestMethod]
                public void EmptyFalse()
                {
                    Resource r1 = new Resource(new Dictionary<ResourceType, float>
                {
                    {ResourceType.Gold, 4.3f },
                    {ResourceType.Stone, 8 },
                    {ResourceType.Wood, 0 }
                });
                    Assert.AreNotEqual(IsEmpty(r1), true);
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
                    Assert.AreEqual(IsEnough(r1,rNeed), true);
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
                    Assert.AreNotEqual(IsEnough(r1,rNeed), false);
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
                    Assert.AreEqual<Resource>(r1, r2);    //before truncate r1=r2
                    Assert.AreNotEqual(Truncate(r1,rNeed), r2);    //after truncatw r1!=r2
                }
        
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
