﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV20T1080053.DataLayers.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns>A list of all records of type T</returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Get record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The record with the specified ID, or null if not found</returns>
        Task<T> GetByIdAsync(int? id);

        /// <summary>
        /// Create a new record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateAsync(T entity);

        /// <summary>
        /// Update a existing record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(T entity);

        /// <summary>
        /// Delete a record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(T entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
    }
}
