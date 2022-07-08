using System;
using System.Collections.Generic;

namespace Crud.AppResolver.CommonResolver.Model
{
    public class ReadRecordResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public List<ReadRecordData> readRecordData { get; set; }
    }

    public class ReadRecordData
    {
        public string UserName { get; set; }
        public int Age { get; set; }
    }
}
