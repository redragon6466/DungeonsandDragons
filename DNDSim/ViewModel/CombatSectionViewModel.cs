using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Characters.EventArgs;
using DNDSim.Main.Enumerations;
using Microsoft.Practices.Prism.Commands;

namespace DNDSim.UI.ViewModel
{
    public class CombatSectionViewModel : ViewModelBase
    {


        public CombatSectionViewModel()
        {
            StartButtons();
        }

        #region events
        public event EventHandler<MessageEventArgs> Message = delegate { };

        public void MessageHandler(String msg)
        {
            Task.Factory.StartNew(() => Message(this, new MessageEventArgs(msg)));
        }

        public event EventHandler<PlayerActionEventArgs> Action = delegate { };

        public void ActionHandler(PlayerActionEnum action)
        {
            Task.Factory.StartNew(() => Action(this, new PlayerActionEventArgs(action)));
        }

        #endregion

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
            ActionHandler(PlayerActionEnum.Attack);
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
            ActionHandler(PlayerActionEnum.Attack);
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
            ActionHandler(PlayerActionEnum.EndTurn);
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
            ActionHandler(PlayerActionEnum.DisplayItems);

        }
        #endregion


        public void StartButtons()
        {
            CreateAttack();
            CreateFullRoundAttack();
            CreateEndTurn();
            CreateItem();
        }
    }
}
