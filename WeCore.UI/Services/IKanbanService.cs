using WeCore.UI.Models;

namespace WeCore.UI.Services
{
    public interface IKanbanService
    {
        Task<List<Board>> GetBoardsAsync();
        Task<Board> GetBoardAsync(int id);
        Task<Board> GetBoard(string boardId);
        Task SaveBoardAsync(Board board);
    }
}