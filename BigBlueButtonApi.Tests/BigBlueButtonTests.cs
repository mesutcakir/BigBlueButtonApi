﻿using FluentAssertions;
using NUnit.Framework;

namespace BigBlueButtonApi.Tests
{
    [TestFixture]
    public class BigBlueButtonTests
    {
        private readonly BigBlueButton _bbb = new BigBlueButton("http://test-install.blindsidenetworks.com/bigbluebutton/api",
            "8cd8ef52e8e101574e400365b55e11a6");

        [Test]
        public void BigBlueButtonTests_GetVersionTest()
        {
            /* Arrange */

            /* Act */
            var response = _bbb.GetVersion();

            /* Assert */
            response.ReturnCode.Should().Be("SUCCESS");
            response.Version.Should().Be("1.0");
        }

        [Test]
        public void BigBlueButtonTests_CreateTest()
        {
            /* Arrange */

            /* Act */
            var response = _bbb.Create("Test", "Test", "ap", "mp");

            /* Assert */
            response.ReturnCode.Should().Be("SUCCESS");
            response.MeetingId.Should().Be("Test");
        }

        [Test]
        public void BigBlueButtonTests_JoinTest()
        {
            /* Arrange */

            /* Act */
            var userId = "3";
            var response = _bbb.Join("random-606821", "User 7561069", userId, "mp");

            /* Assert */
            response.Should().Be("http://test-install.blindsidenetworks.com/bigbluebutton/api/join?fullName=User+7561069&meetingID=random-606821&password=mp&redirect=true&checksum=8691f92d8e4bb148adab2ebe73fcdb1de9af8535");
        }

        [Test]
        public void BigBlueButtonTests_IsMeetingRunningTest()
        {
            /* Arrange */

            /* Act */
            var response = _bbb.IsMeetingRunning("Test");

            /* Assert */
            response.ReturnCode.Should().Be("SUCCESS");
            response.Running.Should().BeFalse();
        }

        [Test]
        public void BigBlueButtonTests_GetMeetingInfoTest()
        {
            /* Arrange */

            /* Act */
            _bbb.Create("Test", "Test", "ap", "mp");
            var response = _bbb.GetMeetingInfo("Test", "mp");

            /* Assert */
            response.ReturnCode.Should().Be("SUCCESS");
            response.MeetingID.Should().Be("Test");
        }

        [Test]
        public void BigBlueButtonTests_EndTest()
        {
            /* Arrange */

            /* Act */
            _bbb.Create("Test", "Test", "ap", "mp");
            var response = _bbb.End("Test", "mp");

            /* Assert */
            response.ReturnCode.Should().Be("SUCCESS");
            response.MessageKey.Should().Be("sentEndMeetingRequest");
        }

        [Test]
        public void BigBlueButtonTests_GetMeetings()
        {
            _bbb.Create("Test1", "Test1", "ap", "mp");
            _bbb.Create("Test2", "Test2", "ap", "mp");
            var response = _bbb.GetMeetings();
            Assert.AreEqual(response.ReturnCode, "SUCCESS");
        }
    }
}
