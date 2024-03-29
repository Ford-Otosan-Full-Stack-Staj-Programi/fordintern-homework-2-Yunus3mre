﻿namespace hw2.Core.Services
{
    public interface IService<T> where T : class
    {
        

        Task<IEnumerable<T>> GetAllAsync();
        
        Task<T> GetByIdAsync(int id);
        
        Task<T> AddAsync(T entity);
   
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        


    }
}
