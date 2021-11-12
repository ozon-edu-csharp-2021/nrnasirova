using System.Collections.Generic;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using MerchandiseService.Domain.Exceptions;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class MerchRequestTests
    {
        [Fact]
        public void CanSetStatusFromNewToProcessing()
        {
            //Arrange
            var merchRequest = new MerchRequest(new Employee(new Identifier(1), new Email("test@gmail.com")),
                new List<MerchItem>(), MerchPackType.NoMerchPack);
            
            //Act
            merchRequest.SetStatus(Status.Processing);
            
            //Assert
            Assert.Equal(Status.Processing, merchRequest.Status);
        }
        
        [Fact]
        public void CanNotSetStatusFromNew()
        {
            //Arrange
            var merchRequest = new MerchRequest(new Employee(new Identifier(2), new Email("test@gmail.com")),
                new List<MerchItem>(), MerchPackType.NoMerchPack);
            
            //Act
            
            //Assert
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.Denied));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.GivenOut));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.WaitingSupply));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.ReadyToGiveOut));
        }
        
        [Fact]
        public void CanNotSetStatusFromNewToWaitingSupplyOrDeniedOrGivenOutOrRedyToGiveOut()
        {
            //Arrange
            var merchRequest = new MerchRequest(new Employee(new Identifier(2), new Email("test@gmail.com")),
                new List<MerchItem>(), MerchPackType.NoMerchPack);
            
            //Act
            
            //Assert
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.Denied));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.GivenOut));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.WaitingSupply));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.ReadyToGiveOut));
        }
        
        [Fact]
        public void CanNotSetStatusFromProcessingToGivenOut()
        {
            //Arrange
            var merchRequest = new MerchRequest(new Employee(new Identifier(2), new Email("test@gmail.com")),
                new List<MerchItem>(), MerchPackType.NoMerchPack);
            merchRequest.SetStatus(Status.Processing);
            
            //Act
            
            //Assert
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.GivenOut));
        }
        
        [Fact]
        public void CanNotSetStatusFromGivenOut()
        {
            //Arrange
            var merchRequest = new MerchRequest(new Employee(new Identifier(2), new Email("test@gmail.com")),
                new List<MerchItem>(), MerchPackType.NoMerchPack);
            merchRequest.SetStatus(Status.Processing);
            merchRequest.SetStatus(Status.ReadyToGiveOut);
            merchRequest.SetStatus(Status.GivenOut);
            
            //Act
            
            //Assert
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.Denied));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.ReadyToGiveOut));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.WaitingSupply));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.Processing));
        }
        
        [Fact]
        public void CanNotSetStatusFromDenied()
        {
            //Arrange
            var merchRequest = new MerchRequest(new Employee(new Identifier(2), new Email("test@gmail.com")),
                new List<MerchItem>(), MerchPackType.NoMerchPack);
            merchRequest.SetStatus(Status.Processing);
            merchRequest.SetStatus(Status.ReadyToGiveOut);
            merchRequest.SetStatus(Status.Denied);
            
            //Act
            
            //Assert
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.GivenOut));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.ReadyToGiveOut));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.WaitingSupply));
            Assert.Throws<MerchRequestStatusException>(() => merchRequest.SetStatus(Status.Processing));
        }
    }
}