using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNDSim.Mechanics;
using DNDSim.Characters.Classes.Interfaces;
using DNDSim.Mechanics.Enumerations;
using DNDSim.Characters.Classes;
using DNDSim.Items.Weapons;
using DNDSim.Items.Weapons.Interfaces;
using DNDSim.Characters.Enumerations;
using DNDSim.Items.Enumerations;
using DNDSim.Items.Armor;
using DNDSim.Items.Armor.Interfaces;
using System.Diagnostics;
using DNDSim.Characters.EventArgs;

namespace DNDSim.Characters
{
    public class Character
    {
        private string _firstName;
        private string _lastName;
        private string _name;
        private string _playerName;
        private byte _level;
        private MoralAllignment _morals;
        private EthicalAllignment _ethics;
        private Alignment _alignment;
        private IClassBase _class;
        private Size _size;
        private int _experiencePoints;
        private byte _baseStrength;
        private byte _baseDexterity;
        private byte _baseConstitution;
        private byte _baseIntelligence;
        private byte _baseWisdom;
        private byte _baseCharisma;
        private byte _strengthModifier;
        private byte _dexterityModifier;
        private byte _constitutionModifier;
        private byte _intelligenceModifier;
        private byte _wisdomModifier;
        private byte _charismaModifier;
        private ushort _armorClass;
        private int _maxHeathPoints;
        private int _currentHealthPoints;
        private int _temporaryHealthPoints;
        private int _nonLeathalDamageTaken;
        private ushort _miscInitativeBonus;
        private byte _baseAttackBonus;
        private byte _attacksPerFullRound;
        private byte _baseFortitudeSave;
        private byte _baseReflexSave;
        private byte _baseWillSave;
        private IWeaponBase _equipedWeapon;
        private IArmorBase _equipedArmor;
        private byte _melee;
        private bool _badworkaround;
        
        //private IArmorBase _equipedArmor;


        public byte Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }


        public Character()
        {
            CreateDefaultCharacter();
        }

        public Character(string name)
        {
            CreateDefaultCharacter(name);
        }

        public bool Dead { get; private set; }

        public bool Unconscious { get; private set; }

        public bool Stable { get; private set; }

        public bool StandardAction { get; private set; }

        public bool MoveAction { get; private set; }

        public bool InCombat { get; private set; }

        public byte Melee
        {
            get
            {
                _melee = (byte)(BaseAttackBonus + StrengthModifier);
                return _melee;
            }
        }
        public Alignment Alignment
        {
            get
            {
                if (_alignment!=null)
                {
                    return _alignment;
                }
                if (_morals != null && _ethics != null)
                {
                    _alignment = new Alignment(_morals, _ethics);
                    return _alignment;
                }
                return new Alignment(MoralAllignment.Lawful, EthicalAllignment.Evil);
            }
        }

        public IClassBase Class
        {
            get
            {
                if (_class != null)
                {
                    return _class;
                }
                _class = new Fighter();
                return _class;
            }

            
        }

        public Size Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
            }
        }

        public int ExperiencePoints
        {
            get
            {
                return _experiencePoints;
            }

            set
            {
                _experiencePoints = value;
            }
        }

        public byte Strength
        {
            get
            {
                return _baseStrength;
            }

            set
            {
                _baseStrength = value;
            }
        }

        public byte Dexterity
        {
            get
            {
                return _baseDexterity;
            }

            set
            {
                _baseDexterity = value;
            }
        }

        public byte Constitution
        {
            get
            {
                return _baseConstitution;
            }

            set
            {
                _baseConstitution = value;
            }
        }

        public byte Intelligence
        {
            get
            {
                return _baseIntelligence;
            }

            set
            {
                _baseIntelligence = value;
            }
        }

        public byte Wisdom
        {
            get
            {
                return _baseWisdom;
            }

            set
            {
                _baseWisdom = value;
            }
        }

        public byte Charisma
        {
            get
            {
                return _baseCharisma;
            }

            set
            {
                _baseCharisma = value;
            }
        }

        public byte StrengthModifier
        {
            get
            {
                _strengthModifier = CalculateModifier(Strength);
                return _strengthModifier;
            }
        }

        public byte DexterityModifier
        {
            get
            {
                _dexterityModifier = CalculateModifier(Dexterity);
                return _dexterityModifier;
            }
        }

        public byte ConstitutionModifier
        {
            get
            {
                _constitutionModifier = CalculateModifier(Constitution);
                return _constitutionModifier;
            }
        }

        public byte IntelligenceModifer
        {
            get
            {
                _intelligenceModifier = CalculateModifier(Intelligence);
                return _intelligenceModifier;
            }
        }

        public byte WisdomModier
        {
            get
            {
                _wisdomModifier = CalculateModifier(Wisdom);
                return _wisdomModifier;
            }

        }

        public byte CharismaModifier
        {
            get
            {
                _charismaModifier = CalculateModifier(Charisma);
                return _charismaModifier;
            }
        }

        public ushort ArmorClass
        {
            get
            {
                return (ushort)(10+Armor.ArmorBonus);
            }
        }

        public int MaxHeathPoints
        {
            get
            {
                return _maxHeathPoints;
            }

            set
            {
                _maxHeathPoints = value;
            }
        }

        public int CurrentHealthPoints
        {
            get
            {
                return _currentHealthPoints;
            }

            set
            {
                _currentHealthPoints = value;
            }
        }

        public int TemporaryHealthPoints
        {
            get
            {
                return _temporaryHealthPoints;
            }

            set
            {
                _temporaryHealthPoints = value;
            }
        }

        public int NonLeathalDamageTaken
        {
            get
            {
                return _nonLeathalDamageTaken;
            }

            set
            {
                _nonLeathalDamageTaken = value;
            }
        }

        public ushort MiscInitativeBonus
        {
            get
            { 
                _miscInitativeBonus = 0;
                return _miscInitativeBonus;
            }

            set
            {
                _miscInitativeBonus = value;
            }
        }

        public byte BaseAttackBonus
        {
            get
            {
                BaseAttackBonusProgressionEnum babType = _class.BaseAttackBonusProgression;
                switch (babType)
                {
                    case BaseAttackBonusProgressionEnum.High:
                        _baseAttackBonus = Level;
                        break;
                    case BaseAttackBonusProgressionEnum.Medium:
                        _baseAttackBonus = (byte)(Level * .75);
                        break;
                    case BaseAttackBonusProgressionEnum.Low:
                        _baseAttackBonus = (byte)(Level * .5);
                        break;
                    default:
                        _baseAttackBonus = 0;
                        break;
                }
                return _baseAttackBonus;
            }

            set
            {
                _baseAttackBonus = value;
            }
        }

        public byte AttacksPerFullRound
        {
            get
            {

                _attacksPerFullRound = (byte)(((BaseAttackBonus) - 1)/5);
                if (_attacksPerFullRound == 0)
                {
                    _attacksPerFullRound = 1;
                }
                return _attacksPerFullRound;
            }
        }

        public byte FortitudeSave
        {
            get
            {
                return _baseFortitudeSave;
            }

            set
            {
                _baseFortitudeSave = value;
            }
        }

        public byte ReflexSave
        {
            get
            {
                return _baseReflexSave;
            }

            set
            {
                _baseReflexSave = value;
            }
        }

        public byte WillSave
        {
            get
            {
                return (byte)(_baseWillSave + _baseWisdom);
            }

            set
            {
                _baseWillSave = value;
            }

        }

        public IWeaponBase Weapon
        {
            get
            {
                return _equipedWeapon;
            }
            set
            {
                _equipedWeapon = value;
            }
        }

        public IArmorBase Armor
        {
            get
            {
                return _equipedArmor;
            }
            set
            {
                _equipedArmor = value;
            }
        }

        public string Name
        {
            get
            {
                if (_name != string.Empty)
                {
                    return _name;
                }
                if ((_firstName != string.Empty) && (_lastName != string.Empty))
                {
                    _name = _firstName + _lastName;
                }
                return "no name";
            }

            set
            {
                _name = value;
            }
        }

        public event EventHandler<MessageEventArgs> CharacterMessage = delegate { };

        /*
        public void MessageHandler(object sender, MessageEventArgs args)
        {
            MessageEventArgs arg = new MessageEventArgs(args.Message);
            Task.Factory.StartNew(() => Message(this, arg));
        }
        */
        public void CreateDefaultCharacter()
        {
            Greatsword greatSword = new Greatsword();
            ScaleMail scaleMail = new ScaleMail();
            Level = 1;
            _firstName = "Test";
            _lastName = "Character";
            _class = new Fighter();
            Weapon = greatSword;
            Armor = scaleMail;
            Strength = 16;
            Dexterity = 14;
            Constitution = 12;
            Intelligence = 8;
            Wisdom = 10;
            Charisma = 11;
            MaxHeathPoints = (byte)(_class.hitDie + ConstitutionModifier);
            CurrentHealthPoints = MaxHeathPoints;

        }

        public void CreateDefaultCharacter(string name)
        {
            Greatsword greatSword = new Greatsword();
            ScaleMail scaleMail = new ScaleMail();
            Level = 1;
            Name = name;
            _class = new Fighter();
            Weapon = greatSword;
            Armor = scaleMail;
            Strength = 16;
            Dexterity = 14;
            Constitution = 12;
            Intelligence = 8;
            Wisdom = 10;
            Charisma = 11;
            MaxHeathPoints = (byte)(_class.hitDie + ConstitutionModifier);
            CurrentHealthPoints = MaxHeathPoints;
        }

        public byte CalculateModifier(byte abilityScore)
        {
            return (byte)(((abilityScore) / 2) - 5);
        }

        public void Attack(Character target)
        {
            if (!StandardAction)
            {
                MessageEvent("\nyou have already taken a standard action this round");
                return;
            }
            StandardAction = false;
            MessageEvent("\n" + Name + " strikes.");
            /* restrict dealing damage to dead people
            if (target.CurrentHealthPoints < (-1*((int)target.Constitution)))
            {
                Debug.WriteLine("he is dead....");
                return;
            }
            */
            int damage = 0;
            int result = Dice.RollTheDice(1, 20);
            
            if (result==1)
            {
                return;
                MessageEvent("Critical Failure");
            }
            int attack = result + Melee;
            MessageEvent(Name + " rolls a " + result + "+" + Melee + "=" + attack + " agaisnt AC: " + target.ArmorClass);
            if ((attack>=target.ArmorClass || result ==20) && Weapon.WeaponType != WeaponTypeEnum.TwoHandedMelee)
            {
                MessageEvent(Name + " succesfully hits");
                damage += Weapon.Damange() + StrengthModifier;
                
            }
            if ((attack >= target.ArmorClass || result == 20) && Weapon.WeaponType == WeaponTypeEnum.TwoHandedMelee)
            {
                MessageEvent(Name + " succesfully hits");
                damage += Weapon.Damange() + Convert.ToInt32(StrengthModifier*1.5);

            }
            if (result == 20)
            {
                MessageEvent("Critical Hit");
                int confirm = Dice.RollTheDice(1, 20);
                if (confirm == 20)
                {
                    MessageEvent("Critical Confirmed");
                    //placeholder for event crit confirmed
                    for (int i = 1; i < Weapon.CriticalMultiplier; i++)
                    {
                        damage += Weapon.Damange() + StrengthModifier;
                    }
                   
                }
            }
            //event placeholder player name dealth damage
            //BadSubscribeWorkaround(target);
            target.TakeDamage(damage);
        }

        //holy hell this is bad find a way to fix it
        public void BadSubscribeWorkaround(Character tar)
        {
            if (_badworkaround==false)
            {
                tar.CharacterMessage += TargetMessageHandler;
                _badworkaround = true;
            }
            
        }

        public void FullRoundAttack(Character target)
        {
            
            for (int i = 0; i < AttacksPerFullRound; i++)
            {
                Attack(target);
            }
            StandardAction = false;
            MoveAction = false;
        }

        public void TargetMessageHandler(object sender, MessageEventArgs args)
        {
            //MessageEvent(args.Message);
        }

        public void TakeDamage(int damage)
        {
            CurrentHealthPoints = (CurrentHealthPoints - damage);
            MessageEvent(Name + " takes " + damage + " points of damage.");
            MessageEvent(Name + " has " + CurrentHealthPoints + " health points.");
            if (CurrentHealthPoints < (-1 * ((int)Constitution)))
            {
                MessageEvent(Name + " is dead.");
                Dead = true;
                //MessageEvent("\n");
                return;
            }

            if (CurrentHealthPoints <= 0)
            {
                Stable = false;
                Unconscious = true;
                MessageEvent(Name+ " is unconscious.");
            }
            //MessageEvent("\n");
        }

        public void MyTurn()
        {
            StandardAction = true;
            MoveAction = true;
        }

        public void MessageEvent(string msg)
        {
            MessageEventArgs arg = new MessageEventArgs(msg);
            Task.Factory.StartNew(() => CharacterMessage(this, arg));
        }
        
        public void TakeTurn(Character target)
        {
            MoveAction = true;
            StandardAction = true;
            FullRoundAttack(target);
        }

        
    }
}

