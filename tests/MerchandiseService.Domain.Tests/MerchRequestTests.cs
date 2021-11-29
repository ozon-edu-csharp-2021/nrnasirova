using System;
using System.Collections.Generic;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using MerchandiseService.Domain.Exceptions;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class MerchRequestTests
    {
        [Fact]
        public void CreateMerchRequestReturnsMerchRequestCreated()
        {
            //Arrange
            var email = "test@gmail.com";
            
            //Act
            var merchRequest = MerchRequest.Create(new Employee(new Email(email)), MerchPackType.StarterPack,
                DateTimeOffset.Now);
            
            //Assert
            Assert.Equal(merchRequest.Employee.Email,new Email(email));
            Assert.Equal(merchRequest.MerchPackType, MerchPackType.StarterPack);
            Assert.Equal(merchRequest.Status, Status.New);
        }
        
        [Fact]
        public void CreateMerchRequestReturnsException()
        {
            //Arrange
            var email = "test";
            
            //Act

            //Assert
            Assert.Throws<InvalidEmployeeInfromationException>( () => MerchRequest.Create(new Employee(new Email(email)), MerchPackType.StarterPack,
                DateTimeOffset.Now));
        }
        
        [Fact]
        public void MerchRequestGiveOutChangesStatusToGivenOut()
        {
            //Arrange
            var merchRequest = MerchRequest.Create(new Employee(new Email("test@gmail.com")), MerchPackType.StarterPack,
                DateTimeOffset.Now, new List<MerchRequest>());
            
            //Act
            merchRequest.GiveOut(DateTimeOffset.Now);
            
            //Assert
            Assert.Equal(merchRequest.Status, Status.GivenOut);
        }
    }
}