using TDL.DAL.Entities;
using TDL.Interfaces;

namespace TDL.BLL
{
    public class TodoService<T>(IRepository<TodoEntity> repository) : IEntityService<T> where T : class, IEntity, new()
    {
        private readonly IRepository<TodoEntity> _repository = repository;
        public async Task<IResponse<T>> CreateAsync(T dto)
        {
            var response = new BaseResponse<T>();

            try
            {
                var entity = new TodoEntity { Id = dto.Id, Content = dto.Content, IsCompleted = dto.IsCompleted };
                var result = await _repository.CreateAsync(entity);
                response.Value = new T { Id = result.Id, Content = result.Content, IsCompleted = result.IsCompleted };
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<IResponse<T>> DeleteAsync(T dto)
        {
            var response = new BaseResponse<T>();

            try
            {
                var entity = await _repository.GetByIdAsync(dto.Id);
                var result = await _repository.DeleteAsync(entity);
                response.Value = new T { Id = result.Id, Content = result.Content, IsCompleted = result.IsCompleted };
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<IResponse<List<T>>> GetAllAsync()
        {
            BaseResponse<List<T>> response = new() { Value = [] };

            try
            {
                var list = await _repository.GetAllAsync().ConfigureAwait(false);
                //response.Value = Enumerable.Select(list, item => new T { Id = item.Id, Content = item.Content, IsCompleted = item.IsCompleted }).ToList();
                foreach(var item in list)
                {
                    response.Value.Add(new T { Id = item.Id, Content = item.Content, IsCompleted = item.IsCompleted });
                }
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<List<T>> GetAll()
        {
            List<T> list = [];

            var entities = await _repository.GetAllAsync();
            foreach (var entity in entities)
            {
                list.Add(new T { Id = entity.Id, Content = entity.Content, IsCompleted = entity.IsCompleted });
            }

            return list;
        }

        public async Task<IResponse<T>> GetByIdAsync(int id)
        {
            var response = new BaseResponse<T>();

            try
            {
                var entity = await _repository.GetByIdAsync(id);
                response.Value = new T { Id = entity.Id, Content = entity.Content, IsCompleted = entity.IsCompleted };
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<IResponse<T>> UpdateAsync(T dto)
        {
            var response = new BaseResponse<T>();

            try
            {
                var entity = await _repository.GetByIdAsync(dto.Id);

                entity = entity.Update(dto);

                var result = await _repository.UpdateAsync(entity);
                response.Value = new T { Id = result.Id, Content = result.Content, IsCompleted = result.IsCompleted };
            }
            catch(Exception ex)
            { 
                response.Message = ex.Message;
            }

            return response;
        }
    }
}