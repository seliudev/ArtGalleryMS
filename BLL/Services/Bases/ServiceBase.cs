﻿using BLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Bases
{
    public abstract class ServiceBase
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; } = string.Empty;

        protected readonly Db _db;

        protected ServiceBase(Db db)
        {
            _db = db;
        }

        public ServiceBase Success(string message = "") //Success() or Success("Record created successfully.")
        {
            IsSuccessful = true;
            Message = message;
            return this;
        }

        public ServiceBase Error(string message = "") //Success() or Success("Record created successfully.")
        {
            IsSuccessful = false;
            Message = message;
            return this;
        }
        
    }
}

