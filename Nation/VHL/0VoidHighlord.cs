//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Nation/AssistingCragAndBamboozle[Mem].cs
//cs_include Scripts/Nation/VHL/CoreVHL.cs
using Skua.Core.Interfaces;

public class VoidHighlord
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreVHL VHL = new();
    public static CoreVHL sVHL = new();
    public CoreNation Nation = new();

    public string OptionsStorage = sVHL.OptionsStorage;
    public bool DontPreconfigure = true;
    public List<IOption> Options = sVHL.Options;

    public void ScriptMain(IScriptInterface bot)
    {
        if (!Bot.Config.Get<bool>("SkipOption"))
            Bot.Config.Configure();
        Core.BankingBlackList.AddRange(Nation.bagDrops);
        Core.SetOptions();

        VHL.GetVHL();

        Core.SetOptions(false);
    }
}