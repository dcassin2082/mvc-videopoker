using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoPoker.Services;
using System.Collections.Generic;

namespace VideoPoker.Tests
{
    [TestClass]
    public class JacksOrBetterTests
    {
        [TestMethod]
        public void RoyalFlush()
        {
            List<int[]> suits = new List<int[]>();
            int[] faces = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1 };
            int counter = 0;
            while (counter < 4)
            {
                int[] arr = { 0, 0, 0, 0 };
                arr[counter] = 5;
                suits.Add(arr);
                counter++;
            }
            for(int i = 0; i < suits.Count; i++)
            {
                var result = HandValue.RoyalFlush(suits[i], faces);
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod]
        public void StraightFlush()
        {
            int counter = 0;
            List<int[]> suits = new List<int[]>();
            while (counter < 4)
            {
                int[] arr = { 0, 0, 0, 0 };
                arr[counter] = 5;
                suits.Add(arr);
                counter++;
            }
            counter = 0;
            List<int[]> ranks = new List<int[]>();
            while (counter < 9)
            {
                int[] arr = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                arr[counter] = 1;
                arr[counter + 1] = 1;
                arr[counter + 2] = 1;
                arr[counter + 3] = 1;
                arr[counter + 4] = 1;
                ranks.Add(arr);
                counter++;
            }
            for(int i = 0; i < suits.Count; i++)
            {
                for(int j = 0; j < ranks.Count; j++)
                {
                    var result = HandValue.StraightFlush(suits[i], ranks[j]);
                    Assert.AreEqual(true, result);
                }
            }
        }

        [TestMethod]
        public void Quads()
        {
            List<int[]> quads = new List<int[]>();
            int counter = 0;
            while(counter < 13)
            {
                int[] arr = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                arr[counter] = 4;
                quads.Add(arr);
                counter++;
            }
            for(int i = 0; i < quads.Count; i++)
            {
                var result = HandValue.Quads(quads[i]);
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod]
        public void Trips()
        {
            List<int[]> trips = new List<int[]>();
            int counter = 0;
            while(counter < 13)
            {
                int[] arr = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                arr[counter] = 3;
                trips.Add(arr);
                counter++;
            }
            for (int i = 0; i < trips.Count; i++)
            {
                var result = HandValue.Trips(trips[i]);
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod]
        public void TwoPair()
        {
            List<int[]> twoPair = new List<int[]>();
            int counter = 0;
            while(counter < 13)
            {
                Random r = new Random();
                int next = r.Next(0, 13);
                if(next == counter)
                {
                    if(counter < 12)
                    {
                        next = counter + 1;
                    }
                    else
                    {
                        next = counter - 1;
                    }
                }
                int[] arr = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                arr[counter] = 2;
                arr[next] = 2;
                twoPair.Add(arr);
                counter++;
            }
            for(int i = 0; i < twoPair.Count; i++)
            {
                var result = HandValue.TwoPair(twoPair[i]);
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod]
        public void JacksOrBetter()
        {
            List<int[]> ranks = new List<int[]>();
            int counter = 0;
            while(counter < 13)
            {
                int[] arr = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                if(counter == 0 || counter == 10 || counter == 11 || counter == 12)
                {
                    arr[counter] = 2;
                    ranks.Add(arr);
                }
                counter++;
            }
            for(int i = 0; i < ranks.Count; i++)
            {
                var result = HandValue.JacksOrBetter(ranks[i]);
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod]
        public void Straight()
        {
            List<int[]> ranks = new List<int[]>();
            int counter = 0;
            while (counter < 9)
            {
                int[] arr = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                arr[counter] = 1;
                arr[counter + 1] = 1;
                arr[counter + 2] = 1;
                arr[counter + 3] = 1;
                arr[counter + 4] = 1;
                ranks.Add(arr);
                counter++;
            }
            for(int i = 0; i < ranks.Count; i++)
            {
                var result = HandValue.Straight(ranks[i]);
                Assert.AreEqual(true, result);
            }
        }

        [TestMethod]
        public void Flush()
        {
            List<int[]> suits = new List<int[]>();
            int counter = 0;
            while (counter < 4)
            {
                int[] arr = { 0, 0, 0, 0 };
                arr[counter] = 5;
                suits.Add(arr);
                counter++;
            }
            for(int i = 0; i < suits.Count; i++)
            {
                var result = HandValue.Flush(suits[i]);
                Assert.AreEqual(true, result);
            }
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
