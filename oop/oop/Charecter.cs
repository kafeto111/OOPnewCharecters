using oop;
using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public enum ItemSet
{//Mage
    MysticRelicsn,
    Ethereal ,
    Shadow , 
    Celestial,
    //tank
    Dragon ,
    Ancient ,
    Stormbringer,
    Phoenix ,
    //warrior
    Timeless ,
   Frostbound,
    Vanguard ,
    Arcane  


}
//item setove za razli4nite geroi + 10% ako sa ot edin set
public abstract class Item
{
    public string Name { get; set; }
    public double AP { get; set; }
    public double AD { get; set; }
    public double Health { get; set; }
    public double Defense { get; set; }
    public double Mana { get; set; }
    public double CritChance { get; set; }
    public double MR { get; set; }
    public ItemSet Set { get; set; }

    public Item(string name, double ap, double ad, double health, double defense, double mana, double critChance, double mr, ItemSet set)
    {
        Name = name;
        AP = ap;
        AD = ad;
        Health = health;
        Defense = defense;
        Mana = mana;
        CritChance = critChance;
        MR = mr;
        Set = set;
    }
}

public class Helmet : Item
{
    public Helmet(string name, double ap, double ad, double health, double defense, double mana, double critChance, double mr, ItemSet set)
        : base(name, ap, ad, health, defense, mana, critChance, mr, set) { }
}

public class Chestplate : Item
{
    public Chestplate(string name, double ap, double ad, double health, double defense, double mana, double critChance, double mr, ItemSet set)
        : base(name, ap, ad, health, defense, mana, critChance, mr, set) { }
}

public class Panths : Item
{
    public Panths(string name, double ap, double ad, double health, double defense, double mana, double critChance, double mr, ItemSet set)
        : base(name, ap, ad, health, defense, mana, critChance, mr, set) { }
}

public class Boots : Item
{
    public Boots(string name, double ap, double ad, double health, double defense, double mana, double critChance, double mr, ItemSet set)
        : base(name, ap, ad, health, defense, mana, critChance, mr, set) { }
}

public class Weapon : Item
{
    public double DmgBoost { get; set; }
    public Weapon(string name, double ap, double ad, double health, double defense, double mana, double critChance, double mr, ItemSet set, double DmgBoost)
        : base(name, ap, ad, health, defense, mana, critChance, mr, set) {

        this.DmgBoost = DmgBoost;

    }
    public virtual double ApplySpecialAbility(double baseDamage)
    {
        return baseDamage + DmgBoost;
    }
}


public abstract class Character
{
    public string Name { get; set; }    
    public string Class { get; set; }
    public double AP { get; set; }
    public double AD { get; set; }
    public double Health { get; set; }
    public double Defense { get; set; }
    public double Mana { get; set; }
    public double CritChance { get; set; }
    public double MR { get; set; }
    public Helmet EquippedHelmet { get; set; }
    public Chestplate EquippedChestplate { get; set; }
    public Panths EquippedPanths { get; set; }
    public Boots EquippedBoots { get; set; }
    public Weapon EquippedWeapon { get; set; }
    public abstract double Attack();
    public abstract void ReceiveDamage(double damage);

    public Character(string @class, double ap, double ad, double health, double defense, double mana, double critChance, double mr,string name)
    {
        Class = @class;
        AP = ap;
        AD = ad;
        Health = health;
        Defense = defense;
        Mana = mana;
        CritChance = critChance;
        MR = mr;
        Name = name;
    }

    public abstract void EquipItem(Item item);
}

public class Warrior : Character
{
    public Warrior(string @class, double ap, double ad, double health, double defense, double mana, double critChance, double mr,string name)
        : base(@class, ap, ad, health, defense, mana, critChance, mr,name) {
    }
    public override double Attack()
    {
        
        return EquippedWeapon.ApplySpecialAbility(AD);
    }
    public override void ReceiveDamage(double damage)
    {
       

        Health -= damage;
        if (Health <= 0)
        {
            // Mage is defeated
            Console.WriteLine($"{Name} has been defeated!");
        }
    }



    public override void EquipItem(Item item)
    {
        // Implement equipment logic for Warrior
        // For example:
        if (item is Helmet)
        {
            EquippedHelmet = item as Helmet;
        }
        else if (item is Chestplate)
        {
            EquippedChestplate = item as Chestplate;
        }
        else if(item is Panths)
        {
            EquippedPanths = item as Panths;
        }
        else if (item is Boots)
        {
            EquippedBoots = item as Boots;
        }
        else if (item is Weapon)
        {
            EquippedWeapon = item as Weapon;
        }

    }
}

public class Mage : Character
{
    public Mage(string @class, double ap, double ad, double health, double defense, double mana, double critChance, double mr,string name)
        : base(@class, ap, ad, health, defense, mana, critChance, mr,name) { }
    public override double Attack()
    {
        // Implement Mage's attack logic here
        // For example:
        return EquippedWeapon.ApplySpecialAbility(AD);
    }

    public override void ReceiveDamage(double damage)
    {
        // Implement Mage's receiving damage logic here
        // For example:
        Health -= damage;
        if (Health <= 0)
        {
            // Mage is defeated
            Console.WriteLine($"{Name} has been defeated!");
        }
    }
    public override void EquipItem(Item item)
    {
        if (item is Helmet)
        {
            EquippedHelmet = item as Helmet;
        }
        else if (item is Chestplate)
        {
            EquippedChestplate = item as Chestplate;
        }
        else if (item is Panths)
        {
            EquippedPanths = item as Panths;
        }
        else if (item is Boots)
        {
            EquippedBoots = item as Boots;
        }
        else if (item is Weapon)
        {
            EquippedWeapon = item as Weapon;
        }
    }
}

public class Tank : Character
{
    public Tank(string @class, double ap, double ad, double health, double defense, double mana, double critChance, double mr, string name)
        : base(@class, ap, ad, health, defense, mana, critChance, mr,name) { }
    public override double Attack()
    {
        // Implement Mage's attack logic here
        // For example:
        return EquippedWeapon.ApplySpecialAbility(AD);
    }

    public override void ReceiveDamage(double damage)
    {
        // Implement Mage's receiving damage logic here
        // For example:
        Health -= damage;
        if (Health <= 0)
        {
            // Mage is defeated
            Console.WriteLine($"{Name} has been defeated!");
        }
    }
    public override void EquipItem(Item item)
    {
        if (item is Helmet)
        {
            EquippedHelmet = item as Helmet;
        }
        else if (item is Chestplate)
        {
            EquippedChestplate = item as Chestplate;
        }
        else if (item is Panths)
        {
            EquippedPanths = item as Panths;
        }
        else if (item is Boots)
        {
            EquippedBoots = item as Boots;
        }
        else if (item is Weapon)
        {
            EquippedWeapon = item as Weapon;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of battles:");
        int rounds = Int32.Parse(Console.ReadLine());
        int oneWins = 0, twoWins = 0;
        for (int i = 0; i < rounds; i++)
        {
            Character character = ChooseCharacter();

            EquipItems(character);
            ItemStatsCalculator.CalculateTotalStats(character);
            Character character2 = ChooseCharacter(); ;
            EquipItems(character2);
            ItemStatsCalculator.CalculateTotalStats(character2);


            Console.WriteLine($"Arena fight between: {character.Name} and {character2.Name}");
            Arena arena = new Arena(character, character2);
            arena.StartFight();


        }
        static Character ChooseCharacter()
        {
            Console.WriteLine("Choose your character:");
            Console.WriteLine("1. Mage");
            Console.WriteLine("2. Warrior");
            Console.WriteLine("3. Tank");

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose your character name");
            string name = Console.ReadLine();
            switch (choice)
            {
                case 1:
                    return new Mage("Mage", 1, 10, 100, 5, 200, 10, 0, name);
                case 2:
                    return new Warrior("Warrior", 10, 50, 150, 10, 50, 15, 10, name);
                case 3:
                    return new Tank("Tank", 5, 20, 200, 50, 30, 5, 10, name);
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Mage.");
                    return new Mage("Mage", 50, 10, 100, 5, 200, 10, 10, name);
            }
        }
    }
    public class ItemStatsCalculator
    {
        public static void CalculateTotalStats(Character character)
        {
            double totalAP = character.AP;
            double totalAD = character.AD;
            double totalHealth = character.Health;
            double totalDefense = character.Defense;
            double totalMana = character.Mana;
            double totalCritChance = character.CritChance;
            double totalMR = character.MR;

            List<Item> equippedItems = new List<Item>
        {
            character.EquippedHelmet,
            character.EquippedChestplate,
            character.EquippedPanths,
            character.EquippedBoots,
            character.EquippedWeapon
        };

            ItemSet? commonSet = equippedItems[0].Set;
            bool allItemsSameSet = true;


            foreach (var item in equippedItems)
            {
                if (item != null)
                {
                    totalAP += item.AP;
                    totalAD += item.AD;
                    totalHealth += item.Health;
                    totalDefense += item.Defense;
                    totalMana += item.Mana;
                    totalCritChance += item.CritChance;
                    totalMR += item.MR;

                    if (item.Set != commonSet)
                    {
                        allItemsSameSet = false;
                    }
                }
            }

            if (allItemsSameSet && commonSet != null)
            {//mage
                if (commonSet == ItemSet.MysticRelicsn)
                {
                    totalAP *= 2;
                   
                    
                }
                if (commonSet == ItemSet.Ethereal)
                {
                    totalMana *= 2;
                }
                if (commonSet == ItemSet.Shadow)
                {
                    totalHealth += 100;
                    
                }

                if (commonSet == ItemSet.Celestial)
                {
                    totalCritChance *= 0.5;
                   
                }
                //tank
                if (commonSet == ItemSet.Dragon)
                {
                    totalAP -= 10;
                    totalMR *= 3;
                }
                if (commonSet == ItemSet.Ancient)
                {
                    totalHealth *= 2;
                    totalDefense *= 2;
                    totalMR /= 2;
                    totalAD /= 2;
                }
                if (commonSet == ItemSet.Stormbringer)
                {
                    totalAD += 30;
                    totalMR *= 3;
                    totalHealth += 100;

                }
                if (commonSet == ItemSet.Phoenix)
                {
                    totalAD *= 2;
                    totalDefense += 30;
                }
                //warrior
                if (commonSet == ItemSet.Timeless)
                {
                    totalAD += 30;
                    totalHealth += 100;
                    totalDefense -= 10;
                }
                if (commonSet == ItemSet.Frostbound)
                {
                    totalMana *= 2;
                    totalAD += 10;
                    totalMR += 100;
                }
                if (commonSet == ItemSet.Vanguard)
                {
                    totalHealth /= 2;
                    totalAD *= 6;
                    totalMR /= 2;
                    totalDefense /= 2;

                }
                if (commonSet == ItemSet.Arcane)
                {
                    totalCritChance *= 2;
                    totalAP += 10;
                    totalHealth *= 1;


                }



            }
            Console.WriteLine($"Name of the character{ character.Name}");

            Console.WriteLine($"Total Stats for {character.Class}:");
            Console.WriteLine($"AP: {totalAP}");
            Console.WriteLine($"AD: {totalAD}");
            Console.WriteLine($"Health: {totalHealth}");
            Console.WriteLine($"Defense: {totalDefense}");
            Console.WriteLine($"Mana: {totalMana}");
            Console.WriteLine($"Crit Chance: {totalCritChance}");
            Console.WriteLine($"MR: {totalMR}");
        }
    }

   
    static void EquipItems(Character character)
    {
        if (character.Class == "Mage")
        {
            List<Item> helmets = new List<Item>
        {
            new Helmet("Helmet A", 1, 0, 10, 5, 0, 2, 5,ItemSet.MysticRelicsn),
            new Helmet("Helmet B", 4, 0, 8, 6, 0, 2.5, 4,ItemSet.Ethereal),
            new Helmet("Helmet C", 6, 0, 12, 4, 0, 1.5, 2,ItemSet.Shadow),
            new Helmet("Helmet D", 7, 0, 9, 7, 0, 3, 5,ItemSet.Celestial),

        };

            List<Item> chestplates = new List<Item>
        {
            new Chestplate("Chestplate A", 1, 10, 30, 10, 0, 2, 4,ItemSet.MysticRelicsn),
            new Chestplate("Chestplate B", 0, 12, 25, 12, 0, 1.8, 5,ItemSet.Ethereal),
            new Chestplate("Chestplate C", 0, 8, 35, 8, 0, 2.5, 5,ItemSet.Shadow),
            new Chestplate("Chestplate D", 0, 9, 40, 9, 0, 2.2, 2,ItemSet.Celestial),

        };

            List<Item> pants = new List<Item>
        {
            new Panths("Pants A", 1, 5, 20, 5, 0, 1, 2,ItemSet.MysticRelicsn),
            new Panths("Pants B", 6, 4, 18, 6, 0, 1.2, 3,ItemSet.Ethereal),
            new Panths("Pants C", 4, 6, 22, 4, 0, 0.8, 5,ItemSet.Shadow),
            new Panths("Pants D", 5, 7, 19, 5, 0, 1.5, 4,ItemSet.Celestial),

        };

            List<Item> boots = new List<Item>
        {
            new Boots("Boots A", 1, 3, 15, 3, 0, 0.5, 1,ItemSet.MysticRelicsn),
            new Boots("Boots B", 4, 2, 13, 4, 0, 0.7, 2,ItemSet.Ethereal),
            new Boots("Boots C", 2, 4, 17, 2, 0, 0.3, 1,ItemSet.Shadow),
            new Boots("Boots D", 3, 5, 16, 3, 0, 0.9, 5,ItemSet.Celestial),

        };

            List<Item> weapons = new List<Item>
        {
            new Weapon("Weapon A", 1, 10, 0, 0, 10, 1, 2,ItemSet.MysticRelicsn,0),
            new Weapon("Weapon B", 12, 8, 0, 0, 12, 1.2, 3,ItemSet.Ethereal,0),
            new Weapon("Weapon C", 8, 12, 0, 0, 8, 0.8, 2,ItemSet.Shadow,0),
            new Weapon("Weapon D", 11, 11, 0, 0, 11, 1.1, 0,ItemSet.Celestial,0),

        };
            character.EquippedHelmet = (Helmet)ChooseItem("helmet", helmets);
            character.EquippedChestplate = (Chestplate)ChooseItem("chestplate", chestplates);
            character.EquippedPanths = (Panths)ChooseItem("pants", pants);
            character.EquippedBoots = (Boots)ChooseItem("boots", boots);
            character.EquippedWeapon = (Weapon)ChooseItem("weapon", weapons);

            character.EquipItem(character.EquippedHelmet);
            character.EquipItem(character.EquippedChestplate);
            character.EquipItem(character.EquippedPanths);
            character.EquipItem(character.EquippedBoots);
            character.EquipItem(character.EquippedWeapon);
        }
        if (character.Class == "Warrior")
        {
            List<Item> helmets = new List<Item>
        {
            new Helmet("Helmet A", 5, 0, 10, 5, 0, 2, 3,ItemSet.Timeless),
            new Helmet("Helmet B", 4, 0, 8, 6, 0, 2.5, 4,ItemSet.Frostbound),
            new Helmet("Helmet C", 6, 0, 12, 4, 0, 1.5, 2,ItemSet.Vanguard),
            new Helmet("Helmet D", 7, 0, 9, 7, 0, 3, 5,ItemSet.Arcane),

        };

            List<Item> chestplates = new List<Item>
        {
            new Chestplate("Chestplate A", 0, 10, 30, 10, 0, 2, 4,ItemSet.Timeless),
            new Chestplate("Chestplate B", 0, 12, 25, 12, 0, 1.8, 3,ItemSet.Frostbound),
            new Chestplate("Chestplate C", 0, 8, 35, 8, 0, 2.5, 5,ItemSet.Vanguard),
            new Chestplate("Chestplate D", 0, 9, 40, 9, 0, 2.2, 2,ItemSet.Arcane),

        };

            List<Item> pants = new List<Item>
        {
            new Panths("Pants A", 5, 5, 20, 5, 0, 1, 2,ItemSet.Timeless),
            new Panths("Pants B", 6, 4, 18, 6, 0, 1.2, 3,ItemSet.Frostbound),
            new Panths("Pants C", 4, 6, 22, 4, 0, 0.8, 2,ItemSet.Vanguard),
            new Panths("Pants D", 5, 7, 19, 5, 0, 1.5, 4,ItemSet.Arcane),

        };

            List<Item> boots = new List<Item>
        {
            new Boots("Boots A", 3, 3, 15, 3, 0, 0.5, 1,ItemSet.Timeless),
            new Boots("Boots B", 4, 2, 13, 4, 0, 0.7, 2,ItemSet.Frostbound),
            new Boots("Boots C", 2, 4, 17, 2, 0, 0.3, 1,ItemSet.Vanguard),
            new Boots("Boots D", 3, 5, 16, 3, 0, 0.9, 2,ItemSet.Arcane),

        };

            List<Item> weapons = new List<Item>
        {
            new Weapon("Weapon A", 10, 10, 0, 0, 10, 1, 2,ItemSet.Timeless,0),
            new Weapon("Weapon B", 12, 8, 0, 0, 12, 1.2, 3,ItemSet.Frostbound,0),
            new Weapon("Weapon C", 8, 12, 0, 0, 8, 0.8, 2,ItemSet.Vanguard,0),
            new Weapon("Weapon D", 11, 11, 0, 0, 11, 1.1, 4,ItemSet.Arcane,0),

        };
            character.EquippedHelmet = (Helmet)ChooseItem("helmet", helmets);
            character.EquippedChestplate = (Chestplate)ChooseItem("chestplate", chestplates);
            character.EquippedPanths = (Panths)ChooseItem("pants", pants);
            character.EquippedBoots = (Boots)ChooseItem("boots", boots);
            character.EquippedWeapon = (Weapon)ChooseItem("weapon", weapons);

            character.EquipItem(character.EquippedHelmet);
            character.EquipItem(character.EquippedChestplate);
            character.EquipItem(character.EquippedPanths);
            character.EquipItem(character.EquippedBoots);
            character.EquipItem(character.EquippedWeapon);
        }
        if (character.Class == "Tank")
        {
            List<Item> helmets = new List<Item>
        {
            new Helmet("Test A", 5, 0, 10, 5, 0, 2, 5,ItemSet.Dragon),
            new Helmet("Helmet B", 4, 0, 8, 6, 0, 2.5, 4,ItemSet.Ancient),
            new Helmet("Helmet C", 6, 0, 12, 4, 0, 1.5, 2,ItemSet.Stormbringer),
            new Helmet("Helmet D", 7, 0, 9, 7, 0, 3, 5,ItemSet.Phoenix),

        };

            List<Item> chestplates = new List<Item>
        {
            new Chestplate("Chestplate A", 0, 10, 30, 10, 0, 2, 4,ItemSet.Dragon),
            new Chestplate("Chestplate B", 0, 12, 25, 12, 0, 1.8, 5,ItemSet.Ancient),
            new Chestplate("Chestplate C", 0, 8, 35, 8, 0, 2.5, 5,ItemSet.Stormbringer),
            new Chestplate("Chestplate D", 0, 9, 40, 9, 0, 2.2, 2,ItemSet.Phoenix),

        };

            List<Item> pants = new List<Item>
        {
            new Panths("Pants A", 5, 5, 20, 5, 0, 1, 2,ItemSet.Dragon),
            new Panths("Pants B", 6, 4, 18, 6, 0, 1.2, 3,ItemSet.Ancient),
            new Panths("Pants C", 4, 6, 22, 4, 0, 0.8, 5,ItemSet.Stormbringer),
            new Panths("Pants D", 5, 7, 19, 5, 0, 1.5, 4,ItemSet.Phoenix),

        };

            List<Item> boots = new List<Item>
        {
            new Boots("Boots A", 3, 3, 15, 3, 0, 0.5, 1,ItemSet.Dragon),
            new Boots("Boots B", 4, 2, 13, 4, 0, 0.7, 2,ItemSet.Ancient),
            new Boots("Boots C", 2, 4, 17, 2, 0, 0.3, 1,ItemSet.Stormbringer),
            new Boots("Boots D", 3, 5, 16, 3, 0, 0.9, 5,ItemSet.Phoenix),

        };

            List<Item> weapons = new List<Item>
        {
            new Weapon("Weapon A", 10, 10, 0, 0, 10, 1, 2,ItemSet.Dragon,0),
            new Weapon("Weapon B", 12, 8, 0, 0, 12, 1.2, 3,ItemSet.Ancient,0),
            new Weapon("Weapon C", 8, 12, 0, 0, 8, 0.8, 2,ItemSet.Stormbringer,0),
            new Weapon("Weapon D", 11, 11, 0, 0, 11, 1.1, 0,ItemSet.Phoenix,0),

        };
            character.EquippedHelmet = (Helmet)ChooseItem("helmet", helmets);
            character.EquippedChestplate = (Chestplate)ChooseItem("chestplate", chestplates);
            character.EquippedPanths = (Panths)ChooseItem("pants", pants);
            character.EquippedBoots = (Boots)ChooseItem("boots", boots);
            character.EquippedWeapon = (Weapon)ChooseItem("weapon", weapons);

            character.EquipItem(character.EquippedHelmet);
            character.EquipItem(character.EquippedChestplate);
            character.EquipItem(character.EquippedPanths);
            character.EquipItem(character.EquippedBoots);
            character.EquipItem(character.EquippedWeapon);
        }




        static T ChooseItem<T>(string itemType, List<T> items) where T : Item
        {
            Console.WriteLine($"Choose your {itemType}:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].Name}");
            }

            int choice = int.Parse(Console.ReadLine());
            return items[Math.Max(0, Math.Min(choice - 1, items.Count - 1))];
        }





    }
    public class Arena
    {
        public Character FighterA { get; }
        public Character FighterB { get; }

        public Arena(Character a, Character b)
        {
            FighterA = a;
            FighterB = b;
        }

        public void StartFight()
        {
            while (FighterA.Health > 0 && FighterB.Health > 0)
            {
                // Fighter A attacks Fighter B
                double damageDealtByA = FighterA.Attack();
                FighterB.ReceiveDamage(damageDealtByA);

                // Check if Fighter B is defeated
                if (FighterB.Health <= 0)
                {
                    Console.WriteLine($"{FighterA.Name} wins!");
                    break;
                }

                // Fighter B attacks Fighter A
                double damageDealtByB = FighterB.Attack();
                FighterA.ReceiveDamage(damageDealtByB);

                // Check if Fighter A is defeated
                if (FighterA.Health <= 0)
                {
                    Console.WriteLine($"{FighterB.Name} wins!");
                    break;
                }
            }
        }
    }
}

