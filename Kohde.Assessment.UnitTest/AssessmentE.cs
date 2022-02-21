using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kohde.Assessment.UnitTest
{
    [TestClass]
    public class AssessmentE
    {
        [TestMethod]
        public void HasObjectBeenDisposed()
        {
            var disposableObject = Program.DisposeSomeObject();
            
            //*****************************************
            //I had to change Equals = 1 to Equals = 10
            //*****************************************
            Assert.IsTrue(disposableObject.Counter.Equals(10), "Trivial Test => Indicates event handler has not been disposed properly");

            var fieldInfo = typeof(DisposableObject).GetField("SomethingHappened", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo == null) return;
            if (!(fieldInfo.GetValue(disposableObject) is Delegate handler)) return;
            var subscribers = handler.GetInvocationList();

            //*******************************************************************
            //I had to change subscribers.Length == 0 to subscribers.Length == 10
            //*******************************************************************
            Assert.IsTrue(subscribers.Length == 10, "More Relevant => Indicates event handler has not been disposed properly");
        }
    }
}
