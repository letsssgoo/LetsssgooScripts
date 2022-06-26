//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/Glacera.cs
using RBot;

public class FrostSpiritReaver
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();
    public CoreAdvanced Adv = new CoreAdvanced();
    public CoreStory Story = new CoreStory();
    public CoreDailies Daily = new();
    public GlaceraStory Glacera = new();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        GetFSR();

        Core.SetOptions(false);
    }
    public void GetFSR()
    {
        if (Core.CheckInventory("Frost SpiritReaver"))
            return;
            
        Story.PreLoad();
        Glacera.DoAll();
        ColdHearted();
        ColdBlooded();
        IceSeeYou();
    }

    public void ColdHearted(int IceNinthQuant = 9)
    {
        while (!Bot.ShouldExit() && Core.CheckInventory("Ice-Ninth", IceNinthQuant) & Core.isCompletedBefore(7921))
            return;

        Core.AddDrop("Flame of Courage", "Ice-Ninth", "Ice Diamond");

        Core.EnsureAccept(7920);

        if (!Core.CheckInventory("Fallen Scythe of Vengeance"))
        {
            if (!Core.CheckInventory("Frigid Scythe of Vengeance"))
            {
                if (!Core.CheckInventory("Cold Scythe of Vengeance"))
                {
                    if (!Core.CheckInventory("Scythe of Vengeance"))
                    {
                        while (!Bot.ShouldExit() && !Core.CheckInventory("Flame of Courage", 25))
                        {
                            Core.EnsureAccept(3955);
                            Core.HuntMonster("frozenruins", "Frost Invader", "Spark of Courage");
                            Core.EnsureComplete(3955);
                        }
                        if (!Core.CheckInventory("Karok's Glaceran Gem"))
                        {
                            Core.HuntMonster("Northstar", "Karok the Fallen", "Karok's Glaceran Gem", isTemp: false);
                        }
                        Core.BuyItem("Glacera", 1055, "Scythe of Vengeance");
                        Bot.Wait.ForItemBuy();
                    }
                    Core.BuyItem("Glacera", 1055, "Cold Scythe of Vengeance");
                    Bot.Wait.ForItemBuy();
                }
                Core.BuyItem("Glacera", 1055, "Frigid Scythe of Vengeance");
                Bot.Wait.ForItemBuy();
            }
            Core.BuyItem("Glacera", 1055, "Fallen Scythe of Vengeance");
            Bot.Wait.ForItemBuy();
        }
        Core.HuntMonster("icestormarena", "Arctic Wolf", "Ice Needle", 30, isTemp: false);
        Core.HuntMonster("Snowmore", "Jon S'Nooooooo", "Northern Crown", isTemp: false);
        while (!Bot.ShouldExit() && !Core.CheckInventory("Ice Diamond", 3))
        {
            Core.EnsureAccept(7279);
            Core.HuntMonster("kingcoal", "Snow Golem", "Frozen Coal", 10, log: false);
            Core.EnsureComplete(7279);
            Bot.Wait.ForPickup("Ice Diamond");
        }
        Core.EnsureComplete(7920);
        Bot.Wait.ForPickup("Ice-Ninth");
    }

    public void ColdBlooded(int AttunementQuant = 15)
    {
        while (!Bot.ShouldExit() && Core.CheckInventory("Glaceran Attunement", AttunementQuant) & Core.isCompletedBefore(7921))
            return;

        Core.AddDrop("Glaceran Attunement");
        Core.EnsureAccept(7921);
        if (!Core.CheckInventory("IceBreaker Mage"))
        {
            Core.HuntMonster("iceplane", "Enfield", "IceBreaker Mage", isTemp: false);
        }
        if (!Core.CheckInventory("FrostSlayer"))
        {
            Core.HuntMonster("iceplane", "Enfield", "FrostSlayer", isTemp: false);
        }
        Core.HuntMonster("cryowar", "Super-Charged Karok", "Glacial Crystal", 100, isTemp: false);
        Core.HuntMonster("frozenlair", "Frozen Legionnaire", "Ice Spike", 20, isTemp: false);
        Core.HuntMonster("frozenlair", "Frozen Legionnaire", "Ice Splinter", 20, isTemp: false);
        Core.HuntMonster("frozenlair", "Legion Lich Lord", "Sapphire Orb", 20, isTemp: false);
        Core.EnsureComplete(7921);
    }

    public void IceSeeYou()
    {
        if (Core.isCompletedBefore(7922) && Core.CheckInventory("Frost SpiritReaver"))
            return;

        Core.EnsureAccept(7922);

        if (!Core.CheckInventory("Envoy of Kyanos"))
        {
            Farm.Gold(50000);
            Tokens(50, 30, 20, 10);

            if (!Core.CheckInventory("Favored of Kyanos"))
            {
                Farm.Gold(50000);
                Tokens(25, 15, 10, 5);
                if (!Core.CheckInventory("Warrior of Kyanos"))
                {
                    Core.HuntMonster("IceDungeon", "Shade of Kyanos", "Warrior of Kyanos", isTemp: false);
                    Bot.Wait.ForPickup("Warrior of Kyanos");
                }
                Core.BuyItem("icedungeon", 1948, "Warrior of Kyanos");
                Bot.Wait.ForItemBuy();
            }
            Core.BuyItem("icedungeon", 1948, "Favored of Kyanos");
            Bot.Wait.ForItemBuy();
        }
        Core.BuyItem("icedungeon", 1948, "Envoy of Kyanos");
        Bot.Wait.ForItemBuy();
        Core.EnsureComplete(7922);
        Bot.Wait.ForPickup("Frost SpiritReaver");
    }

    public void Tokens(int Token1 = 300, int Token2 = 300, int Token3 = 300, int Token4 = 300)
    {
        if (Core.CheckInventory("Icy Token I", Token1) && Core.CheckInventory("Icy Token II", Token2) && Core.CheckInventory("Icy Token III", Token3) && Core.CheckInventory("Icy Token IV", Token4))
            return;

        Core.AddDrop("Icy Token I", "Icy Token II", "Icy Token III", "Icy Token IV");

        if (Token1 > 0)
        {
            Core.Logger($"Getting Token I x {Token1}");
            Core.EquipClass(ClassType.Farm);
            while (!Bot.ShouldExit() && !Core.CheckInventory("Icy Token I", Token1))
            {
                Core.EnsureAccept(7838);
                Core.HuntMonster("icedungeon", "Frosted Banshee", "Frosted Banshee Defeated", 10, log: false);
                Core.HuntMonster("icedungeon", "Frozen Undead", "Frozen Undead Defeated", 10, log: false);
                Core.HuntMonster("icedungeon", "Ice Symbiote", "Ice Symbiote Defeated", 10, log: false);
                Core.EnsureComplete(7838);
            }
        }
        if (Token2 > 0)
        {
            Core.EquipClass(ClassType.Farm);
            Core.Logger($"Getting Token II x {Token2}");
            Core.EquipClass(ClassType.Farm);
            while (!Bot.ShouldExit() && !Core.CheckInventory("Icy Token II", Token2))
            {
                Core.EnsureAccept(7839);
                Core.HuntMonster("icedungeon", "Spirit of Ice", "Spirit of Ice Defeated", 10, log: false);
                Core.HuntMonster("icedungeon", "Ice Crystal", "Ice Crystal Defeated", 10, log: false);
                Core.HuntMonster("icedungeon", "Frigid Spirit", "Frigid Spirit Defeated", 10, log: false);
                Core.EnsureComplete(7839);
            }
        }
        if (Token3 > 0)
        {
            Core.Logger($"Getting Token III x {Token3}");
            Core.EquipClass(ClassType.Farm);
            while (!Bot.ShouldExit() && !Core.CheckInventory("Icy Token III", Token3))
            {
                Core.EnsureAccept(7840);
                Core.HuntMonster("icedungeon", "Living Ice", "Living Ice Defeated", 5, log: false);
                Core.HuntMonster("icedungeon", "Crystallized Elemental", "Crystallized Elemental Defeated", 5, log: false);
                Core.HuntMonster("icedungeon", "Frozen Demon", "Frozen Demon Defeated", 5, log: false);
                Core.EnsureComplete(7840);
            }

        }
        if (Token4 > 0)
        {
            Core.Logger($"Getting Token IV x {Token4}");
            Core.EquipClass(ClassType.Solo);
            while (!Bot.ShouldExit() && !Core.CheckInventory("Icy Token IV", Token4))
            {
                Core.EnsureAccept(7841);
                Core.HuntMonster("icedungeon", "Image of Glace", "Glace's Approval");
                Core.HuntMonster("icedungeon", "Abel", "Abel's Approval");
                Core.HuntMonster("icedungeon", "Shade of Kyanos", "Kyanos' Approval");
                Core.EnsureComplete(7841);
            }
        }
    }
}
