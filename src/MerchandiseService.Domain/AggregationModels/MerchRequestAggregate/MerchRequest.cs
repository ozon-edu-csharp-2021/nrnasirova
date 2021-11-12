using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Events;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchRequest: Entity
    {
        public Employee Employee { get; private set; }
        public List<MerchItem> MerchItems { get; }
        public Status Status { get; private set; }
        
        public MerchPackType MerchPackType { get; }


        public MerchRequest(Employee employee, List<MerchItem> merchItems, MerchPackType merchPackType)
        {
            MerchItems = merchItems;
            MerchPackType = merchPackType;
            SetEmployee(employee);
            Status = Status.New;
        }

        private void SetEmployee(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Email.Value))
            {
                throw new ArgumentNullException("No email was given");
            }

            if (employee.ExternalId.Value <= 0)
            {
                throw new ArgumentNullException("No external id was given");
            } 
            
            var validateEmail = new Regex("^[\\W]*([\\w+\\-.%]+@[\\w\\-.]+\\.[A-Za-z] {2,4}[\\W]*,{1}[\\W]*)*([\\w+\\-.%]+@[\\w\\-.]+\\.[A-Za-z]{2,4})[\\W]*$");
            if (!validateEmail.IsMatch(employee.Email.Value))
            {
                throw new InvalidIdentifierException($"Wrong email has been given");
            }

            Employee = employee;
        }

        public void SetStatus(Status status)
        {
            //can change new status only to processing
            if (Status.Equals(Status.New) && 
                (status.Equals(Status.GivenOut) || status.Equals(Status.WaitingSupply) || status.Equals(Status.ReadyToGiveOut) || status.Equals(Status.Denied)))
                throw new MerchRequestStatusException($"Request should be processed. Change status unavailable");

            //can not change status processing to given out
            if (Status.Equals(Status.Processing) && status.Equals(Status.GivenOut))
                throw new MerchRequestStatusException($"Request should be processed. Change status unavailable");
            
            //can not change status to new
            if (status.Equals(Status.New))
                throw new MerchRequestStatusException($"Can not change status to new");

            //can not change status from given out
            if (Status.Equals(Status.GivenOut))
                throw new MerchRequestStatusException($"Merch is given out. Change status unavailable");
            
            //can not change status from denied
            if (Status.Equals(Status.Denied))
                throw new MerchRequestStatusException($"Merch request is denied. Change status unavailable");
            
            Status = status;
        }
        
        private void AddMerchSupplyDomainEvent(List<Sku> sku)
        {
            var orderStartedDomainEvent = new MerchSupplyArrivedDomainEvent(sku);

            AddDomainEvent(orderStartedDomainEvent);
        }
    }
}