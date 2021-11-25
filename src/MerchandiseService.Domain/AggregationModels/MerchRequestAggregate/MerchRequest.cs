using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MerchandiseService.Domain.Events;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchRequest: Entity
    {
        public Identifier Id { get; set; }
        public Employee Employee { get; private set; }
        public Status Status { get; private set; }
        public MerchPackType MerchPackType { get; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? GiveOutAt { get; set; }
        


        private MerchRequest(Employee employee, MerchPackType merchPackType, DateTimeOffset createdAt)
        {
            MerchPackType = merchPackType;
            SetEmployee(employee);
            Status = Status.New;
            CreatedAt = createdAt;
        }

        private void SetEmployee(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Email.Value))
            {
                throw new ArgumentNullException("No email was given");
            }

            var validateEmail = new Regex("^[\\W]*([\\w+\\-.%]+@[\\w\\-.]+\\.[A-Za-z] {2,4}[\\W]*,{1}[\\W]*)*([\\w+\\-.%]+@[\\w\\-.]+\\.[A-Za-z]{2,4})[\\W]*$");
            if (!validateEmail.IsMatch(employee.Email.Value))
            {
                throw new InvalidEmployeeInfromationException($"Wrong email has been given");
            }

            Employee = employee;
        }

        public static MerchRequest Create(Employee employee, MerchPackType merchPackType, DateTimeOffset createdAt, IReadOnlyCollection<MerchRequest> existingRequests = null)
        {
            //check if merch pack type has been already given to an employee

            return new (employee, merchPackType, createdAt);
        }

        public void GiveOut(DateTimeOffset givenOutAt)
        {
            if (Equals(Status, Status.Denied))
            {
                throw new FailToGiveOutException("Merch request was denied");
            }
            
            if (Equals(Status, Status.GivenOut))
            {
                throw new FailToGiveOutException("Merch request was already given out");
            }
            
            Status = Status.GivenOut;
            AddDomainEvent(new MerchToGiveOut(MerchPackType, Employee));
        }
    }
}