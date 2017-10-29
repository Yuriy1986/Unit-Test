using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary260;
using System.Collections.Generic;
using System.Collections;

namespace UnitTestProject261
{
    [TestClass]
    public class UnitTest1
    {
        Dictionary<ResourceType, float> DicRes1 = new Dictionary<ResourceType, float>();    

        [TestMethod]
        public void AdditionSuccess()
        {
            DicRes1.Add(ResourceType.Gold, 74.6f);
            DicRes1.Add(ResourceType.Stone, 4.6f);
            DicRes1.Add(ResourceType.Wood, 414.6f);
            Resource r1 = new Resource(DicRes1);    
            DicRes1.Clear();

            DicRes1.Add(ResourceType.Stone, 4.6f);
            DicRes1.Add(ResourceType.Gold, 74.6f);
            DicRes1.Add(ResourceType.Wood, 414.6f);
            Resource r2 = new Resource(DicRes1);   
            DicRes1.Clear();

            Resource r5 = r1 + r2;
            DicRes1.Add(ResourceType.Stone, 9.2f);
            DicRes1.Add(ResourceType.Gold, 149.2f);
            DicRes1.Add(ResourceType.Wood, 829.2f);
            Resource rCheck = new Resource(DicRes1);
            DicRes1.Clear();

            Assert.AreEqual<Resource>(r5, rCheck);
            //      Assert.IsTrue(r5 == rCheck);
            //     Assert.IsFalse(r5 != rCheck);

            //Assert.IsTrue(r5 != r1);

            /*            var obj1 = new Resource(new Dictionary<ResourceType, float>
                        {
                            {ResourceType.Gold, 4.3f },
                            {ResourceType.Stone, 8 },
                            {ResourceType.Wood, 0 }
                        });
                        var obj2 = new Resource(new Dictionary<ResourceType, float>
                        {
                            {ResourceType.Gold, 3 },
                            {ResourceType.Stone, 2.8f },
                            {ResourceType.Wood, 7 }
                        });
                        var obj3 = new Resource(new Dictionary<ResourceType, float>
                        {
                            {ResourceType.Gold, 7.3f },
                            {ResourceType.Stone, 10.8f },
                            {ResourceType.Wood, 7 }
                        });

                        Assert.AreEqual<Resource>(obj1 + obj2, obj3);*/
        }

        [TestMethod]
        public void AdditionFail()
        {
            DicRes1.Add(ResourceType.Gold, 74);
            DicRes1.Add(ResourceType.Stone, 4);
            DicRes1.Add(ResourceType.Wood, 414);

            Resource r1 = new Resource(DicRes1);    
            DicRes1.Clear();

            DicRes1.Add(ResourceType.Gold, 5);
            DicRes1.Add(ResourceType.Stone, 14);
            Resource r2 = new Resource(DicRes1);    
            DicRes1.Clear();

            Resource r5 = r1 + r2;
            DicRes1.Clear();

            Assert.AreNotEqual<Resource>(r5, r1);
        }

        [TestMethod]
        public void MinusSuccess()
        {
            DicRes1.Add(ResourceType.Gold, 74);
            DicRes1.Add(ResourceType.Stone, 4);
            DicRes1.Add(ResourceType.Wood, 414);

            Resource r1 = new Resource(DicRes1);    
            DicRes1.Clear();

            DicRes1.Add(ResourceType.Gold, 5);
            DicRes1.Add(ResourceType.Stone, 14);
            Resource r2 = new Resource(DicRes1);    
            DicRes1.Clear();

            Resource r5 = r1 - r2;
            DicRes1.Clear();

            DicRes1.Add(ResourceType.Wood, 414);
            DicRes1.Add(ResourceType.Stone, -10);
            DicRes1.Add(ResourceType.Gold, 69);
            Resource rCheck = new Resource(DicRes1);      
            DicRes1.Clear();

            Assert.IsTrue(r5 == rCheck);
            Assert.AreEqual<Resource>(r5, rCheck);
        }

        [TestMethod]
        public void MinusFail()
        {
            DicRes1.Add(ResourceType.Gold, 74);
            DicRes1.Add(ResourceType.Stone, 4);
            DicRes1.Add(ResourceType.Wood, 414);

            Resource r1 = new Resource(DicRes1);    
            DicRes1.Clear();

            DicRes1.Add(ResourceType.Gold, 5);
            DicRes1.Add(ResourceType.Stone, 14);
            Resource r2 = new Resource(DicRes1);    
            DicRes1.Clear();

            Resource r5 = r1 - r2;
            DicRes1.Clear();

            DicRes1.Add(ResourceType.Wood, 414);
            DicRes1.Add(ResourceType.Stone, -10);
            DicRes1.Add(ResourceType.Gold, 69);
            Resource rCheck = new Resource(DicRes1);      
            DicRes1.Clear();

            Assert.IsFalse(r5 != rCheck);
            Assert.AreNotEqual<Resource>(r5, r1);
        }

        [TestMethod]
        public void CompareSuccess()
        {
            DicRes1.Add(ResourceType.Gold, 74);
            DicRes1.Add(ResourceType.Stone, 4);
            DicRes1.Add(ResourceType.Wood, 414);

            Resource r1 = new Resource(DicRes1);    
            DicRes1.Clear();

            DicRes1.Add(ResourceType.Gold, 74);
            DicRes1.Add(ResourceType.Stone, 4);
            DicRes1.Add(ResourceType.Wood, 414);
            Resource r2 = new Resource(DicRes1);    
            DicRes1.Clear();

            Assert.IsTrue(r1 == r2);
            Assert.AreEqual(r1, r2);
        }

        [TestMethod]
        public void CompareFail()
        {
            DicRes1.Add(ResourceType.Gold, 74);
            DicRes1.Add(ResourceType.Stone, 4);
            DicRes1.Add(ResourceType.Wood, 414);

            Resource r1 = new Resource(DicRes1);    
            DicRes1.Clear();

            DicRes1.Add(ResourceType.Gold, 74);
            DicRes1.Add(ResourceType.Stone, 4);
            DicRes1.Add(ResourceType.Wood, 414);
            Resource r2 = new Resource(DicRes1);    
            DicRes1.Clear();

            Resource r3 = new Resource();

            Assert.IsFalse(r1 != r2);
            Assert.AreNotEqual(r1, r3);
        }

        [TestMethod]
        public void MyltiplyFSuccess()
        {
            DicRes1.Add(ResourceType.Gold, 4);
            DicRes1.Add(ResourceType.Stone, 4);
            DicRes1.Add(ResourceType.Wood, 4);

            Resource r1 = new Resource(DicRes1);    
            DicRes1.Clear();

            DicRes1.Add(ResourceType.Gold, 4.4f);
            DicRes1.Add(ResourceType.Stone, 4.4f);
            DicRes1.Add(ResourceType.Wood, 4.4f);
            Resource rCheck = new Resource(DicRes1);    
            DicRes1.Clear();

            Assert.IsTrue(r1 * 1.1f == rCheck);
            Assert.AreEqual(r1 * 1.1f, rCheck);
        }

        [TestMethod]
        public void MyltiplyFFail()
        {
            DicRes1.Add(ResourceType.Gold, 4);
            DicRes1.Add(ResourceType.Stone, 4);
            DicRes1.Add(ResourceType.Wood, 4);

            Resource r1 = new Resource(DicRes1);    
            DicRes1.Clear();

            DicRes1.Add(ResourceType.Gold, 4.4f);
            DicRes1.Add(ResourceType.Stone, 4.4f);
            DicRes1.Add(ResourceType.Wood, 4.4f);
            Resource rCheck = new Resource(DicRes1);    
            DicRes1.Clear();

            Assert.IsFalse(r1 * 1.1f != rCheck);
            Assert.AreNotEqual(r1*1.1f,rCheck*2f);
        }
    }
}
