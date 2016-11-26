using UnityEngine;
using System.Collections;

static public class ArenaInfo
{
    private static int enemyHealth;
    private static int heroHealth;
    //private static int award;

    /// <summary>
    /// Do some actions (after gamme) if it needs. If the bool is true, the gold += award && updating the top UI.
    /// </summary>
    /// <param name="firstNumber">First border random number</param>
    /// <param name="secondNumber">Second border random number </param>
    /// <param name="isEndOfGame">Should we update UI and give to Hero gold</param>
    /// <returns>The number between first and second numbers.</returns>
    public static int RandomAward(int firstNumber, int secondNumber, bool isEndOfGame)
    {
        int award = Random.Range(firstNumber, secondNumber) * MainHero.Level;

        if (isEndOfGame)
        {
            ActinsAfterGame(award);
        }

        return award;
    }




    static void ActinsAfterGame(int award)
    {
        MainHero.Gold += award;
        MainHero.Level++;
        TopUI.SyncTopUi();
    }

    public static int AfterGame { get; set; }

}


public enum StatusAfterGame : int
{
    nothing = 0,
    won = 1,
    lose = 2
}

