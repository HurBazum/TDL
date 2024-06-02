using System.Runtime.CompilerServices;
using TDL.DAL.Entities;
using TDL.Interfaces;

namespace TDL.BLL
{
    public static class EntityTransformer
    {
        public static TodoDTO ToDTO(TodoEntity entity) => new() { Id = entity.Id, Content = entity.Content, IsCompleted = entity.IsCompleted };
        public static TodoEntity ToEntity(TodoDTO todoDTO) => new() { Id = todoDTO.Id, Content = todoDTO.Content, IsCompleted = todoDTO.IsCompleted };
        public static IEnumerable<TodoDTO> ToDTO(IEnumerable<TodoEntity> entities) => Enumerable.Select(entities, ToDTO);
        public static IEnumerable<TodoEntity> ToEntity(IEnumerable<TodoDTO> todoDTOs) => Enumerable.Select(todoDTOs, ToEntity);

        public static TodoEntity Update(this TodoEntity todo, IEntity entity)
        {
            todo.Content = entity.Content;
            todo.IsCompleted = entity.IsCompleted;

            return todo;
        }
    }
}