using Framework.Core.CommandHandling;
using Sales.SalesManagement.Domain.Factor;
using System;
using System.Collections.Generic;

namespace Sales.SalesManagement.ApplicationService.Contract.Factor
{
    public class CreateFactorCommand : Command
    {
        public CreateFactorCommand(DateTime issueDate, string title, string description, IEnumerable<FactorItem> factorItems)
        {
            IssueDate = issueDate;
            Title = title;
            Description = description;
            FactorItems = factorItems;
        }

        public DateTime IssueDate { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IEnumerable<FactorItem> FactorItems { get; private set; }
    }
}