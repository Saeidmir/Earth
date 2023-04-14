using Earth.Core.Contracts.ApplicationServices.Common;
using Earth.Core.Contracts.ApplicationService.Queries;
using Earth.Utilities;

namespace Earth.Core.ApplicationServices.Queries;

public abstract class QueryHandler<TQuery, TData> : IQueryHandler<TQuery, TData>
    where TQuery : class, IQuery<TData>
{
    protected readonly EarthAttachedServices _services;
    protected readonly QueryResult<TData> result = new();

    #region Constructor
    public QueryHandler(EarthAttachedServices services)
    {
        _services = services;
    }
    #endregion 
    public abstract Task<QueryResult<TData>> Handle(TQuery request);

    protected virtual Task<QueryResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return Task.FromResult(result);
    }

    protected virtual QueryResult<TData> Result(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return result;
    }


    protected virtual Task<QueryResult<TData>> ResultAsync(TData data)
    {
        var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
        return ResultAsync(data, status);
    }


    protected virtual QueryResult<TData> Result(TData data)
    {
        var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
        return Result(data, status);
    }

}