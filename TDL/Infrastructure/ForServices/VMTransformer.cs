using TDL.BLL;
using TDL.ViewModels;

namespace TDL.Infrastructure.ForServices
{
    public static class VMTransformer
    {
        public static TodoDTO ToDTO(TodoViewModel entity) => new() { Id = entity.Id, Content = entity.Content, IsCompleted = entity.IsCompleted };
        public static TodoViewModel ToVM(TodoDTO todoDTO) => new() { Id = todoDTO.Id, Content = todoDTO.Content, IsCompleted = todoDTO.IsCompleted };
        public static IEnumerable<TodoDTO> ToDTO(IEnumerable<TodoViewModel> entities) => Enumerable.Select(entities, ToDTO);
        public static IEnumerable<TodoViewModel> ToVM(IEnumerable<TodoDTO> todoDTOs) => Enumerable.Select(todoDTOs, ToVM);
    }
}