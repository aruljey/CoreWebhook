﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebhook.Core
{
    public interface IUnitOfWork
    {
        
        Task CompleteAsync();
        void Dispose();
    }
}
