using Framework.Core.Domain;
using System;
using System.Collections.Generic;

namespace Sales.SalesManagement.Domain.Factor
{
    public class Factor : AggregateRoot
    {
        private Factor(DateTime issueDate, string title, string description)
        {
            FactorItems = new List<FactorItem>();

            SetIssueDate(issueDate);
            SetTitle(title);
            SetDescription(description);
        }

        private Factor(DateTime issueDate, string title, string description, IEnumerable<FactorItem> factorItems) : this(issueDate, title, description)
        {
            SetFactorItems(factorItems);
        }

        public DateTime IssueDate { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public List<FactorItem> FactorItems { get; private set; }

        public void SetFactorItems(IEnumerable<FactorItem> factorItems)
        {
            foreach (var item in factorItems)
            {
                item.SetFactorId(Id);
                FactorItems.Add(item);
            }
        }

        private void SetIssueDate(DateTime issueDate)
        {
            IssueDate = issueDate;
        }

        private void SetTitle(string title)
        {
            Title = title;
        }

        private void SetDescription(string description)
        {
            Description = description;
        }

        public static Factor CreateFactor(DateTime issueDate, string title, string description, IEnumerable<FactorItem> factorItems)
        {
            var factor = new Factor(issueDate, title, description, factorItems);
            return factor;
        }
    }
}