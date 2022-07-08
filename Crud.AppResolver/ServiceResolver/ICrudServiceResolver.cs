﻿using System;
using System.Threading.Tasks;
using Crud.AppResolver.CommonResolver.Model;

namespace Crud.AppResolver.ServiceResolver
{
    public interface ICrudServiceResolver
    {
        public Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);

        public Task<ReadRecordResponse> ReadRecord();

        public Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request);

        public Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);
    }
}
