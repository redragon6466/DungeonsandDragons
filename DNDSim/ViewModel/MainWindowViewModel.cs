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

        public MainWindowViewModel()
        {
            StartButtons();
            _game = new Game();
            _game.Message += MessageHandler;
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
    

        #region Attack button
        public DelegateCommand AttackCommand { get; internal set; }

        private bool CanExecuteAttack()
        {
            return true;
        }

        private void CreateAttack()
        {
            AttackCommand = new DelegateCommand(AttackExecute, CanExecuteAttack);
        }

        public void AttackExecute()
        {
            if (SelectedCharacter != null)
            {
                _game.PlayerAction(PlayerActionEnum.Attack, SelectedCharacter);
                return;
            }
            WriteToOutputString("Select a target");

        }
        #endregion

        #region Full Attack Button
        public DelegateCommand FullRoundAttackCommand { get; internal set; }

        private bool CanExecuteFullRoundAttack()
        {
            return true;
        }

        private void CreateFullRoundAttack()
        {
            FullRoundAttackCommand = new DelegateCommand(FullRoundAttackExecute, CanExecuteFullRoundAttack);
        }

        public void FullRoundAttackExecute()
        {
            //Character target = SelectTaget();
            if (SelectedCharacter!=null)
            {
                _game.PlayerAction(PlayerActionEnum.FullAttack, SelectedCharacter);
                return;
            }
            WriteToOutputString("Select a target");
            
        }
        #endregion

        #region End Turn Button
        public DelegateCommand EndTurnCommand { get; internal set; }

        private bool CanExecuteEndTurn()
        {
            return true;
        }

        private void CreateEndTurn()
        {
            EndTurnCommand = new DelegateCommand(EndTurnExecute, CanExecuteEndTurn);
        }

        public void EndTurnExecute()
        {
            WriteToOutputString("\nYou end your turn.");
            _game.EndTurn();
            
        }
        #endregion

        #region Item Button
        public DelegateCommand ItemCommand { get; internal set; }

        private bool CanExecuteItem()
        {
            return true;
        }

        private void CreateItem()
        {
            ItemCommand = new DelegateCommand(ItemExecute, CanExecuteItem);
        }

        public void ItemExecute()
        {
            /*
            FullAttackVisibility = Visibility.Hidden;
            */

        }
        #endregion

        public void MessageHandler(object sender, MessageEventArgs args)
        {
            WriteToOutputString(args.Message);
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

        public void StartButtons()
        {
            CreateAttack();
            CreateFullRoundAttack();
            CreateEndTurn();
            CreateItem();
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
        /*
        public ViewModelBase GetSection
        {
            get
            {
                switch (MenuState)
                {
                    case MenuStateEnum.Combat:
                        break;
                    case MenuStateEnum.Items:
                        break;
                    default:
                        break;
                }
            }
        }
        
        */
    }
}
