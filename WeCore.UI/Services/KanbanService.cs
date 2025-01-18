using System.Net.Http.Json;
using WeCore.UI.Models;

namespace WeCore.UI.Services
{
    public class KanbanService : IKanbanService
    {
        private readonly HttpClient _httpClient;

        public KanbanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Board>> GetBoardsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Board>>("api/boards") 
                ?? new List<Board>();
        }

        public async Task<Board> GetBoardAsync(int id)
        {
            var board = await _httpClient.GetFromJsonAsync<Board>($"api/boards/{id}");
            if (board == null)
                throw new KeyNotFoundException($"Board with id {id} not found");
            return board;
        }

        public async Task<Board> GetBoard(string boardId)
        {
            if (!int.TryParse(boardId, out int id))
                throw new ArgumentException("Invalid board ID format");

            return await GetBoardAsync(id);
        }

        public async Task SaveBoardAsync(Board board)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            if (board.Id == 0)
                await _httpClient.PostAsJsonAsync("api/boards", board);
            else
                await _httpClient.PutAsJsonAsync($"api/boards/{board.Id}", board);
        }
    }
}
