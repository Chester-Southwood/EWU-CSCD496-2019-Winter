using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Api.Controllers;
using SecretSanta.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SecretSanta.Api.Tests
{
    [TestClass]
    public class GiftControllerTests
    {
        private Gift CreateGift()
        {
            return new Gift
            {
                Id = 3,
                Title = "Gift Tile",
                Description = "Gift Description",
                Url = "http://www.gift.url",
                OrderOfImportance = 1
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GiftController_RequiresGiftService()
        {
            new GiftController(null);
        }

        [TestMethod]
        public void GetGiftForUser_ReturnsUsersFromService()
        {
            Gift gift = CreateGift();
            TestableGiftService testService = new TestableGiftService
            {
                GetGiftsForUser_Return = new List<Gift>
                {
                    gift
                }
            };
            GiftController controller = new GiftController(testService);

            ActionResult<List<DTO.Gift>> result = controller.GetGiftForUser(4);

            Assert.AreEqual(4, testService.GetGiftsForUser_UserId);

            DTO.Gift resultGift = result.Value.Single();
            Assert.AreEqual(gift.Id, resultGift.Id);
            Assert.AreEqual(gift.Title, resultGift.Title);
            Assert.AreEqual(gift.Url, resultGift.Url);
            Assert.AreEqual(gift.OrderOfImportance, resultGift.OrderOfImportance);
        }

        [TestMethod]
        public void GetGiftForUser_RequiresPositiveUserId()
        {
            TestableGiftService testService = new TestableGiftService();
            GiftController controller = new GiftController(testService);

            ActionResult<List<DTO.Gift>> result = controller.GetGiftForUser(-1);

            Assert.IsTrue(result.Result is NotFoundResult);
            Assert.AreEqual(0, testService.GetGiftsForUser_UserId);
        }

        [TestMethod]
        public void AddGiftForUser_RequiresGift()
        {
            TestableGiftService testService = new TestableGiftService();
            GiftController controller = new GiftController(testService);

            ActionResult<DTO.Gift> result = controller.AddGiftToUser(null, 1);

            Assert.IsTrue(result.Result is BadRequestResult);
            Assert.AreEqual(0, testService.AddGiftToUser_UserId);
            Assert.IsNull(testService.AddGiftToUser_Return);
        }

        [TestMethod]
        public void AddGiftForUser_RequiresPositiveUserId()
        {
            TestableGiftService testService = new TestableGiftService();
            GiftController controller = new GiftController(testService);

            ActionResult<DTO.Gift> result = controller.AddGiftToUser(new DTO.Gift(CreateGift()), -1);

            Assert.IsTrue(result.Result is NotFoundResult);
            Assert.AreEqual(0, testService.AddGiftToUser_UserId);
            Assert.IsNull(testService.AddGiftToUser_Gift);
        }

        [TestMethod]
        public void DeleteGiftForUser_RequiresGift()
        {
            TestableGiftService testService = new TestableGiftService();
            GiftController controller = new GiftController(testService);

            ActionResult<DTO.Gift> result = controller.DeleteGiftFromUser(null, 9);

            Assert.IsTrue(result.Result is BadRequestResult);
            Assert.IsNull(testService.RemoveGiftToUser_Gift);
        }



        [TestMethod]
        public void UpdateGiftForUser_RequiresPosId()
        {
            TestableGiftService service = new TestableGiftService();
            GiftController controller = new GiftController(service);


            ActionResult<List<DTO.Gift>> result = controller.UpdateGiftFromUser(-1, new DTO.Gift());

            Assert.IsTrue(result.Result is NotFoundResult);
            //This check ensures that the service was not called
            Assert.AreEqual(0, service.GetGiftsForUser_UserId);
            Assert.IsNull(service.UpdateGiftToUser_Gift);
        }

        [TestMethod]
        public void DeleteGiftForUser_ReturnDelete()
        {
            TestableGiftService service = new TestableGiftService();
            GiftController controller = new GiftController(service);
            Gift gift = CreateGift();
            controller.DeleteGiftFromUser(new DTO.Gift(gift), 8);
            Gift removedGift = service.RemoveGiftToUser_Gift;

            Assert.AreEqual(removedGift.Id, gift.Id);
            Assert.AreEqual(removedGift.OrderOfImportance, gift.OrderOfImportance);
            Assert.AreEqual(removedGift.Title, gift.Title);
            Assert.AreEqual(removedGift.User, gift.User);
            Assert.AreEqual(removedGift.UserId, gift.UserId);
        }

        [TestMethod]
        public void AddGiftForUser_ReturnAdd()
        {
            TestableGiftService service = new TestableGiftService();
            GiftController controller = new GiftController(service);
            Gift gift = CreateGift();
            controller.AddGiftToUser(new DTO.Gift(gift), 8);

            Assert.AreEqual(service.AddGiftToUser_Gift.Id, gift.Id);
            Assert.AreEqual(service.AddGiftToUser_Gift.OrderOfImportance, gift.OrderOfImportance);
            Assert.AreEqual(service.AddGiftToUser_Gift.Title, gift.Title);
            Assert.AreEqual(service.AddGiftToUser_Gift.User, gift.User);
            Assert.AreEqual(service.AddGiftToUser_Gift.UserId, gift.UserId);
        }

        [TestMethod]
        public void UpdateGiftForUser_RequiresGift()
        {
            TestableGiftService service = new TestableGiftService();
            GiftController controller = new GiftController(service);


            ActionResult<List<DTO.Gift>> result = controller.UpdateGiftFromUser(1, null);

            Assert.IsTrue(result.Result is BadRequestResult);
            //This check ensures that the service was not called
            Assert.AreEqual(0, service.GetGiftsForUser_UserId);
            Assert.IsNull(service.UpdateGiftToUser_Gift);
        }

        [TestMethod]
        public void UpdateGiftForUser_ReturnUpdate()
        {
            TestableGiftService service = new TestableGiftService();
            GiftController controller = new GiftController(service);
            Gift gift = CreateGift();
            ActionResult<List<DTO.Gift>> updateGift = controller.UpdateGiftFromUser(2, new DTO.Gift(gift));
            Assert.IsTrue(updateGift.Result is OkObjectResult);
        }
    }
}
