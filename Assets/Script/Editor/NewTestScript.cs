using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
 
namespace Tests
{
    public class BoardSizeTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void BoardSizeTest1()
        {
            Assert.AreEqual(BoardManager.GetInstance.BoardWidth, BoardManager.GetInstance.Board.Length);
            Assert.AreEqual(BoardManager.GetInstance.BoardHeight, BoardManager.GetInstance.Board[0].Length);
        }
 
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator BoardSizeTest2()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            
            Assert.AreEqual(BoardManager.GetInstance.BoardWidth, BoardManager.GetInstance.Board.Length);
            Assert.AreEqual(BoardManager.GetInstance.BoardHeight, BoardManager.GetInstance.Board[0].Length);
            
            yield return null;
        }
    }
}