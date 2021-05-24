using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestStore.Data.Interfaces;
using TestStore.Models;
using Microsoft.EntityFrameworkCore;

namespace TestStore.Data.Repository
{
    /*public class GameRepository : IGames
    {
        private readonly ApplicationContext appContext;
        
        public GameRepository(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }
        public IEnumerable<Game> AllGames => appContext.Games.Include(c => c.Category);
        public Game getObjectGame(int id) => appContext.Games.FirstOrDefault(p => p.Id == id);
    }*/
}
