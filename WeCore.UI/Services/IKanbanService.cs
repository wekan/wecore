using WeCore.UI.Models;

namespace WeCore.UI.Services
{
    public interface IKanbanService
    {
        Task<List<Board>> GetBoardsAsync();
        Task<Board> GetBoardAsync(int id);
        Task<Board> GetBoard(string boardId);
        Task SaveBoardAsync(Board board);
        Task UpdateSwimlaneOrder(int swimlaneId, int order);
        Task UpdateListOrder(int listId, int order);
        Task UpdateCardOrder(int cardId, int order);
    }
}