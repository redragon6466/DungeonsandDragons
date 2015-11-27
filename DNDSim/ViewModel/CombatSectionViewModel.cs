using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;

namespace DNDSim.UI.ViewModel
{
    public class CombatSectionViewModel : ViewModelBase
    {




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
            /*
            if (SelectedCharacter != null)
            {
                _game.PlayerAction(PlayerActionEnum.Attack, SelectedCharacter);
                return;
            }
            WriteToOutputString("Select a target");
            */
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
            /*
            //Character target = SelectTaget();
            if (SelectedCharacter != null)
            {
                _game.PlayerAction(PlayerActionEnum.FullAttack, SelectedCharacter);
                return;
            }
            WriteToOutputString("Select a target");
            */
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
            /*
            WriteToOutputString("\nYou end your turn.");
            _game.EndTurn();
            */
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

    }
}
