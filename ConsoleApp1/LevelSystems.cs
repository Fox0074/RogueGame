using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame.LevelSystems
{
    class LevelSystem
    {
        public int level { get; set; }
        private int _mCurrentExperience;
        public int currentExperience { get { return _mCurrentExperience; } private set { _mCurrentExperience = value; CheckExperience(); } }
        public int maxExperience { get; set; }

        private Player player;

        public LevelSystem(Player player)
        {
            level = 1;
            _mCurrentExperience = 0;
            maxExperience = level * level * 100;
            this.player = player;
        }

        public void AddExperience(int experience)
        {
            currentExperience += experience;
        }
        
        private void CheckExperience()
        {
            while (currentExperience >= maxExperience)
            {
                level++;               
                _mCurrentExperience = currentExperience - maxExperience; 
                maxExperience = (int)(level * 1.5f * 100);
                
                LevelUp();
            }
        }


        private void LevelUp()
        {
            
            player.stamina += 1;
            player.agility += 1;
            player.strength += 1;
            

            //player.freeStats++;
        }
        
    }
}
