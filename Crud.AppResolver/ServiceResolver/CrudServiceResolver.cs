using System;
using System.Threading.Tasks;
using Crud.AppResolver.CommonResolver.Model;
using Crud.AppResolver.RepositoryResolver;

namespace Crud.AppResolver.ServiceResolver
{
    public class CrudServiceResolver : ICrudServiceResolver
    {
        public readonly ICrudRepositoryResolver _crudRepositoryResolver;

        public CrudServiceResolver(ICrudRepositoryResolver crudRepositoryResolver)
        {
            _crudRepositoryResolver = crudRepositoryResolver;
        }

        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            return await _crudRepositoryResolver.CreateRecord(request);
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            return await _crudRepositoryResolver.ReadRecord();
        }

        public async Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            return await _crudRepositoryResolver.UpdateRecord(request);
        }

        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            return await _crudRepositoryResolver.DeleteRecord(request);
        }
    }
}
