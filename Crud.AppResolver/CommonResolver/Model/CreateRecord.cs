﻿using System;
namespace Crud.AppResolver.CommonResolver.Model
{
    public class CreateRecordRequest
    {
        public string UserName { get; set; }
        public int Age { get; set; }
    }

    public class CreateRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
