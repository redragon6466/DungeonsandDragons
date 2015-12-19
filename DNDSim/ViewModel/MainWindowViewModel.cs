using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Main.Enumerations;
using DNDSim.Main;
using Microsoft.Practices.Prism.Commands;
using DNDSim.Characters;
using DNDSim.Characters.EventArgs;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows;

namespace DNDSim.UI.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private readonly StringBuilder _outputString;

        private string _writeToOutputWindow;

        private Character _player;

        private Character _target;

        private  Game _game;

        private Character _selectedCharacter;

        private Visibility _fullAttackVisibility;

        private MenuStateEnum _menuState;

        private CombatSectionViewModel _combatSectionViewModel;

        private MenuStateEnum _previousState;

        public MainWindowViewModel()
        {
           
            _game = new Game();
            _game.Message += MessageHandler;
            _menuState = MenuStateEnum.Combat;
            _game.Play();
            _outputString = new StringBuilder();
            WriteToOutputString("Hello, Welcome to Dungeons and Dragons");
            
        }

        public string WriteToOutputWindow
        {
            get
            {
                return _writeToOutputWindow;
            }
            set
            {
                _writeToOutputWindow = value;
                OnPropertyChanged(() => WriteToOutputWindow);
            }
        }
    

        public void MessageHandler(object sender, MessageEventArgs args)
        {
            WriteToOutputString(args.Message);
        }

        public void ActionHandler(object sender, PlayerActionEventArgs args)
        {
            if (SelectedCharacter == null)
            {
                WriteToOutputString("Please Select a target to attack.");
            }
            else
            {
                _game.PlayerAction(args.Action, SelectedCharacter);
            }

            switch (args.Action)
            {
                case PlayerActionEnum.Attack:
                    if (SelectedCharacter == null)
                    {
                        WriteToOutputString("Please Select a target to attack.");
                    }
                    else
                    {
                        _game.PlayerAction(args.Action, SelectedCharacter);
                    }
                    break;
                case PlayerActionEnum.FullAttack:
                    if (SelectedCharacter == null)
                    {
                        WriteToOutputString("Please Select a target to attack.");
                    }
                    else
                    {
                        _game.PlayerAction(args.Action, SelectedCharacter);
                    }
                    break;
                case PlayerActionEnum.EndTurn:
                    _game.PlayerAction(args.Action, SelectedCharacter);
                    break;
                case PlayerActionEnum.DisplayItems:
                    _previousState = MenuState;
                    MenuState = MenuStateEnum.Items;
                    break;
            }

        }

        public void WriteToOutputString(string myString)
        {
            _outputString.Append(Environment.NewLine + myString);
            try
            {
                WriteToOutputWindow = _outputString.ToString();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
        }

        public ObservableCollection<Character> CharactersList
        {
            get
            {
                return _game.AvailableTargets();
            }
        }

        public Character SelectedCharacter
        {
            get
            {
                return _selectedCharacter;
            }
            set
            {
                _selectedCharacter = value;
                OnPropertyChanged(() => SelectedCharacter);
            }
        }

        public MenuStateEnum MenuState
        {
            get
            {
                return _menuState;
            }

            set
            {
                _menuState = value;
            }
        }
        
        public ViewModelBase GetSection
        {
            get
            {
                switch (MenuState)
                {
                    case MenuStateEnum.Combat:
                        return CombatSection;
                    case MenuStateEnum.Items:
                        return CombatSection;
                    default:
                        return CombatSection;
                }
            }
        }

        public CombatSectionViewModel CombatSection
        {
            get
            {
                if (_combatSectionViewModel == null)
                {
                    _combatSectionViewModel = new CombatSectionViewModel();
                    _combatSectionViewModel.Action += ActionHandler;
                }
                return _combatSectionViewModel;
            }
        }

        
    
    }
}
