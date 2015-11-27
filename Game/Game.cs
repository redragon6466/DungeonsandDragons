using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Characters;
using DNDSim.Main.Enumerations;
using DNDSim.Characters.EventArgs;
using System.Collections.ObjectModel;

namespace DNDSim.Main
{
    public class Game
    {

        private List<Character> _nonPlayerCharactersList;

        private ObservableCollection<Character> _nonPlayerCharactersInInstanceList;

        private Character _player;

        private bool _inCombat;

        public void Play()
        {
            _nonPlayerCharactersList = new List<Character>();
            _player = new Character("test player");
            _player.CharacterMessage += MessageHandler;
            _nonPlayerCharactersInInstanceList = new ObservableCollection<Character>();
            Character enemy = new Character("test enemy");
            Character fritz = new Character("fritz");
            enemy.CharacterMessage += MessageHandler;
            fritz.CharacterMessage += MessageHandler;
            _nonPlayerCharactersInInstanceList.Add(enemy);
            _nonPlayerCharactersInInstanceList.Add(fritz);
            _player.MyTurn();
        }

        public event EventHandler<MessageEventArgs> Message = delegate { };
        

        public bool InCombat
        {
            get
            {
                return _inCombat;
            }

            set
            {
                _inCombat = value;
            }
        }

        public void MessageHandler(object sender, MessageEventArgs args)
        {
            Task.Factory.StartNew(() => Message(this, args));
        }

        public void PlayerAction(PlayerActionEnum action, Character target = null)
        {
            switch (action)
            {
                default:
                    break;
                case PlayerActionEnum.Attack:
                    if (target != null)
                    {
                        _player.Attack(target);
                    }
                    break;
                case PlayerActionEnum.FullAttack:
                    if (target != null)
                    {
                        _player.FullRoundAttack(target);
                    }
                    break;
            }
        }

        public void EndTurn()
        {
            for (int i = 0; i < _nonPlayerCharactersInInstanceList.Count; i++)
            {
                _nonPlayerCharactersInInstanceList[i].TakeTurn(_player);
            }
            _player.MyTurn();
        }

        public ObservableCollection<Character> AvailableTargets()
        {
            return _nonPlayerCharactersInInstanceList;
        }

    }
}
