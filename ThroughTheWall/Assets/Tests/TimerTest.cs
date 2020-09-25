using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TimerTest
    {
        [Test]
        public void SecondsToMinutesTest()
        {
            float secondsCount = 0f;
            int minuteCount = 0;

            while (secondsCount < 60)
            {
                ++secondsCount;
                if (secondsCount >= 60)
                {
                    minuteCount++;
                }
            }

            Assert.AreEqual(1, minuteCount);
        }

        [Test]
        public void MinutesToHoursTest()
        {
            int minuteCount = 0;
            int hourCount = 0;

            while (minuteCount < 60)
            {
                ++minuteCount;
                if (minuteCount >= 60)
                {
                    hourCount++;
                }
            }

            Assert.AreEqual(1, hourCount);
        }
    }
}
