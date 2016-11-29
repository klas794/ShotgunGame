using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Soldier
    {
        public int AmmunitionCount { get; set; }
        public Actions Action { get; set; }
        const int InitialAmmunitionCount = 0;

        public Soldier()
        {
            Reset();
        }

        public void GenerateRandomAction()
        {
            var random = new Random();
            var availableActionsCount = AmmunitionCount == 0 ? 2 : AmmunitionCount < 3 ? 3 : 4;
            var choice = random.Next(availableActionsCount);
            
            switch(choice)
            {
                case 0:
                    Action = Actions.Load;
                    break;
                case 1:
                    Action = Actions.Block;
                    break;
                case 2:
                    Action = Actions.Shoot;
                    break;
                case 3:
                    Action = Actions.Shotgun;
                    break;
                default:
                    Action = Actions.DoNothing;
                    break;
            }
        }

        public void Reset()
        {
            AmmunitionCount = InitialAmmunitionCount;
            Action = Actions.DoNothing;
        }
    }
}