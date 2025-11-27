namespace HumanResources.Application.Handlers.Commands.BankAccount;

//public class AddBankAccountAsyncCommandHandler : IRequestHandler<AddBankAccountAsyncCommand, ResultStatus>
//{
//    private readonly IBankAccountRepository _repo;

//    public AddBankAccountAsyncCommandHandler(IBankAccountRepository repo)
//    {
//        _repo = repo;
//    }

//    public async Task<ResultStatus> Handle(AddBankAccountAsyncCommand request, CancellationToken cancellationToken)
//    {
//        return await _repo.AddAsync(request.BankAccount, cancellationToken);
//    }
//}
