using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPoker2.Business;

namespace VideoPoker2.Tests
{
    [TestClass]
    public class JacksOrBetterTest
    {
        [TestMethod]
        public void RoyalFlush()
        {
            int[] suits = { 0, 0, 0, 5 };
            int[] faces = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 };
            var result = HandValue.RoyalFlush(suits, faces);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void StraightFlush()
        {
            int[] suits = { 0, 0, 0, 5 };
            int[] faces = { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0 };
            var result = HandValue.StraightFlush(suits, faces);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void Straight()
        {
            int[] faces = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };
            var result = HandValue.Straight(faces);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Flush()
        {
            int[] suits = { 5, 0, 0, 0 };
            var result = HandValue.Flush(suits);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Quads()
        {
            int[] faces = { 1, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0 };
            var result = HandValue.Quads(faces);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Trips()
        {
            int[] faces = { 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0 };
            var result = HandValue.Trips(faces);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TwoPair()
        {
            int[] faces = { 2, 2, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };
            var result = HandValue.TwoPair(faces);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void JacksOrBetter()
        {
            int[] faces = { 2, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0 };
            var result = HandValue.JacksOrBetter(faces);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void JacksOrBetter1()
        {
            int[] faces = { 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 2, 0, 0 };
            var result = HandValue.JacksOrBetter(faces);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void AnyPair()
        {
            int[] faces = { 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 2, 0, 0 };
            var result = HandValue.JacksOrBetter(faces);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void FullHouse()
        {
            int[] faces = { 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 };
            var result = HandValue.FullHouse(faces);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void BroadwayStraight()
        {
            int[] faces = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 };
            var result = HandValue.BroadwayStraight(faces);
            Assert.AreEqual(true, result);
        }
    }
}
