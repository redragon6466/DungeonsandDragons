using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Characters.Classes.Interfaces;
using DNDSim.Characters.Enumerations;
using DNDSim.Items.Enumerations;

namespace DNDSim.Characters.Classes
{
    public class Fighter : IFighter
    {
        private WeaponProficienciesEnum[] _weaponProficiencies;

        private ArmorProficienciesEnum[] _armorProficiencies;

        private BaseAttackBonusProgressionEnum _baseAttackBonusProgression;

        private BaseSaveProgressionEnum _fortitudeSaveProgression;
        
        private BaseSaveProgressionEnum _reflexSaveProgression;

        private BaseSaveProgressionEnum _willSaveProgression;

        private byte _hitDie;
        

        public WeaponProficienciesEnum[] WeaponProficiencies
        {
            get
            {
                if (_weaponProficiencies != null || _armorProficiencies.Length != 0)
                {
                    return _weaponProficiencies;
                }
                _weaponProficiencies = new WeaponProficienciesEnum[] { WeaponProficienciesEnum.Greatsword };
                return _weaponProficiencies;
            }
        }

        public ArmorProficienciesEnum[] ArmorProficiencies
        {
            get
            {
                if (_armorProficiencies != null || _armorProficiencies.Length != 0)
                {
                    return _armorProficiencies;
                }
                _armorProficiencies = new ArmorProficienciesEnum[]{ ArmorProficienciesEnum.Light, ArmorProficienciesEnum.Medium, ArmorProficienciesEnum.Heavy, ArmorProficienciesEnum.Sheild};
                return _armorProficiencies;
            }
        }

        public BaseAttackBonusProgressionEnum BaseAttackBonusProgression
        {
            get
            {
                _baseAttackBonusProgression = BaseAttackBonusProgressionEnum.High;
                return _baseAttackBonusProgression;
            }
        }

        public BaseSaveProgressionEnum FortitudeSaveProgression
        {
            get
            {
                _fortitudeSaveProgression = BaseSaveProgressionEnum.High;
                return _fortitudeSaveProgression;
            }
        }

        public BaseSaveProgressionEnum ReflexSaveProgression
        {
            get
            {
                _reflexSaveProgression = BaseSaveProgressionEnum.Low;
                return _reflexSaveProgression;
            }
        }

        public BaseSaveProgressionEnum WillSaveProgression
        {
            get
            {
                _willSaveProgression = BaseSaveProgressionEnum.Low;
                return _willSaveProgression;
            }
        }

        public byte hitDie
        {
            get
            {
                if (_hitDie != 0)
                {
                    return _hitDie;
                }
                _hitDie = 10;
                return _hitDie;
            }
        }
        
        
    }
}
