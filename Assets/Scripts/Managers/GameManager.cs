using Core;
using GamePlay.Data;
using GamePlay.Entity;

namespace Managers
{
    public class GameManager : SingletonBehaviour<GameManager>
    {
        void Update()
        {

        }

        public string CurrentMapId { get; set; }
        public PlayerData[] CurrentPlayers { get; set; }
    }
}
