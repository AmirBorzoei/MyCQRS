using Framework.Core.CommandHandling;
using Framework.Core.Persistence;
using Sales.SalesManagement.ApplicationService.Contract.Factor;
using Sales.SalesManagement.Domain.Factor.Services;

namespace Sales.SalesManagement.ApplicationService.Factor
{
    public class CreateFactorCommandHandler : CommandHandler<CreateFactorCommand>
    {
        private readonly IFactorRepository factorRepository;

        public CreateFactorCommandHandler(IDbContext dbContext, IFactorRepository factorRepository) : base(dbContext)
        {
            this.factorRepository = factorRepository;
        }

        public override void Handle(CreateFactorCommand command)
        {
            var newFactor = Domain.Factor.Factor.CreateFactor(command.IssueDate, command.Title, command.Description, command.FactorItems);
            factorRepository.Create(newFactor);
        }
    }
}