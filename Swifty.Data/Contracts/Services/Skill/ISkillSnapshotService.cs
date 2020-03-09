﻿using Swifty.Core.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swifty.Data.Contracts.Services
{
    public interface ISkillSnapshotService<TEntity> : IEntityService<TEntity> where TEntity : class, IEntityBase
    {
    }
}
