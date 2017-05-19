﻿using System.Threading.Tasks;
using VGtime.Models;
using VGtime.Models.Games;

namespace VGtime.Services
{
    public interface IGameService
    {
        Task<ServerBase<AlbumList>> GetAlbumListAsync(int gameId);

        Task<ServerBase<GameData>> GetDetailAsync(int gameId, int? userId = null);

        Task<ServerBase<GameList>> GetScoreListAsync(int gameId, int page = 1, int pageSize = 20);

        Task<ServerBase<StrategyList>> GetStrategyMenuListAsync(int gameId);

        Task<ServerBase<SearchList<GameBase>>> SearchAsync(string text, int? userId = null, int page = 1, int pageSize = 20);
    }
}