﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Swifty.Core.Contracts.Entities;
using Swifty.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swifty.Data.Extensions
{
    public static class IBaseRepositoryExtensions
    {
        public static async Task<SelectList> BuildSelectListAsync<T>(this IBaseRepository<T> repository, string dataTextField, string dataGroupField = null) where T : class, IEntityBase
        {
            var list = await repository.ListAllAsync();

            SelectList selectListItems = new SelectList(list, nameof(IEntityBase.Id), dataTextField, null, dataGroupField);

            return selectListItems;
        }

        public static async Task<SelectList> BuildFilteredSelectListAsync<T>(this IBaseRepository<T> repository, Func<T, bool> filterExpression, string dataTextField, string dataGroupField = null) where T : class, IEntityBase
        {
            var list = await repository.ListAllAsync();

            SelectList selectListItems = new SelectList(list.Where(filterExpression), nameof(IEntityBase.Id), dataTextField, null, dataGroupField);

            return selectListItems;
        }
    }
}
