using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTypeSelect : MonoBehaviour
{
    // Make it so when LevelManager.Instance.sceneLevel == 0-4, 0 is level 1, 4 is level 5
    // it selects the correct wall type, maybe make multiple
    // arrays for each wall type, check LevelGenerationManager
    // for example maybe, or make it your
    // own way

    private WallLogic cs_wallLogic;
    [SerializeField] private bool childChosen = false;
    [SerializeField] private WallType wallType;

    [SerializeField] private GameObject[] typeOne; // 4
    [SerializeField] private GameObject[] typeTwo; // 4
    [SerializeField] private GameObject[] typeThree; // 4
    [SerializeField] private GameObject[] typeFour; // 4
    [SerializeField] private GameObject typeFive; // 1
    [SerializeField] private GameObject[] typeSix; // 2
    [SerializeField] private GameObject[] typeSeven; // 4
    [SerializeField] private GameObject[] typeEight; // 4
    [SerializeField] private GameObject[] typeNine; // 4
    [SerializeField] private GameObject[] typeTen; // 4
    [SerializeField] private GameObject[] typeEleven; // 4
    [SerializeField] private GameObject[] typeTwelve; // 4
    [SerializeField] private GameObject[] typeThirteen; // 2

    private void Awake()
    {
        cs_wallLogic = gameObject.GetComponent<WallLogic>();
    }
    public void TypeCheck()
    {
        #region TYPE FIVE
        if ((cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Wall &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Wall &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Wall &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Wall))
            TypeFive();

        #endregion
        #region TYPE ELEVEN:
        else if ((cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] != Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[2] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] != Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[4] != Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] != Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Wall &&
            cs_wallLogic.spaceChecks[2] == Space.Wall))
            TypeEleven();
        #endregion
        #region TYPE NINE:
        else if ((cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] != Space.Chunk &&
            cs_wallLogic.spaceChecks[6] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] != Space.Chunk &&
            cs_wallLogic.spaceChecks[5] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] != Space.Chunk &&
            cs_wallLogic.spaceChecks[5] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] != Space.Chunk &&
            cs_wallLogic.spaceChecks[4] != Space.Chunk))
            TypeNine();
        #endregion
        #region TYPE THIRTEEN :
        else if ((cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall &&
            cs_wallLogic.spaceChecks[4] != Space.Chunk &&
            cs_wallLogic.spaceChecks[6] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall &&
            cs_wallLogic.spaceChecks[5] != Space.Chunk &&
            cs_wallLogic.spaceChecks[7] != Space.Chunk))
            TypeThirteen();
        #endregion
        #region TYPE ONE :
        else if (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk)
            TypeOne();
        #endregion
        #region TYPE SIX:
        else if ((cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk))
            TypeSix();

        #endregion
        #region TYPE TEN:
        else if ((cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk))
            TypeTen();
        #endregion     
        #region TYPE SEVEN:
        else if ((cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall))
            TypeSeven();
        #endregion
        #region TYPE EIGHT:
        else if ((cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall))
            TypeEight();
        #endregion
        #region TYPE TWO:
        else if ((cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[7] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[6] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[4] != Space.Chunk &&
            cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[5] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[5] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[6] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[4] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[7] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk))
            TypeTwo();
        #endregion
        #region TYPE FOUR:
        else if ((cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk))
            TypeFour();

        #endregion
        #region TYPE TWELVE:

        else if ((cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[0] != Space.Chunk))
            TypeTwelve();
        #endregion
        #region TYPE THREE:
        else if ((cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk))
            TypeThree();
        #endregion
        #region TYPE STRANDED TWO:
        else if ((cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[4] != Space.Chunk &&
            cs_wallLogic.spaceChecks[5] != Space.Chunk &&
            cs_wallLogic.spaceChecks[6] != Space.Chunk &&
            cs_wallLogic.spaceChecks[7] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[4] != Space.Chunk &&
            cs_wallLogic.spaceChecks[5] != Space.Chunk &&
            cs_wallLogic.spaceChecks[6] != Space.Chunk &&
            cs_wallLogic.spaceChecks[7] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[4] != Space.Chunk &&
            cs_wallLogic.spaceChecks[5] != Space.Chunk &&
            cs_wallLogic.spaceChecks[6] != Space.Chunk &&
            cs_wallLogic.spaceChecks[7] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] != Space.Chunk &&
            cs_wallLogic.spaceChecks[5] != Space.Chunk &&
            cs_wallLogic.spaceChecks[6] != Space.Chunk &&
            cs_wallLogic.spaceChecks[7] != Space.Chunk))
            TypeTwo();
        #endregion
    }

    private void TypeOne()
    {
        wallType = WallType.One;

        if (cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk)
            EdgeChange(typeOne[0]);

        else if (cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk)
            EdgeChange(typeOne[1]);

        else if (cs_wallLogic.spaceChecks[3] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk)
            EdgeChange(typeOne[2]);

        else if (cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk)
            EdgeChange(typeOne[3]);
    }

    private void TypeTwo()
    {
        wallType = WallType.Two;

        if (cs_wallLogic.spaceChecks[0] == Space.Chunk)
            EdgeChange(typeTwo[0]);
        else if (cs_wallLogic.spaceChecks[1] == Space.Chunk)
            EdgeChange(typeTwo[1]);
        else if (cs_wallLogic.spaceChecks[2] == Space.Chunk)
            EdgeChange(typeTwo[2]);
        else if (cs_wallLogic.spaceChecks[3] == Space.Chunk)
            EdgeChange(typeTwo[3]);
    }

    private void TypeThree()
    {
        wallType = WallType.Three;

        if (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk)
            EdgeChange(typeThree[0]);
        else if (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk)
            EdgeChange(typeThree[1]);
        else if (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk)
            EdgeChange(typeThree[2]);
        else if (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk)
            EdgeChange(typeThree[3]);
    }

    private void TypeFour()
    {
        wallType = WallType.Four;

        if (cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk)
            EdgeChange(typeFour[0]);
        else if (cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk)
            EdgeChange(typeFour[1]);
        else if (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk)
            EdgeChange(typeFour[2]);
        else if (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk)
            EdgeChange(typeFour[3]);
    }

    private void TypeFive()
    {
        wallType = WallType.Five;

        EdgeChange(typeFive);
    }

    private void TypeSix()
    {
        wallType = WallType.Six;

        if (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall)
            EdgeChange(typeSix[0]);
        else if (cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk)
            EdgeChange(typeSix[1]);

    }

    private void TypeSeven()
    {
        wallType = WallType.Seven;

        if (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall)
            EdgeChange(typeSeven[0]);
        else if (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall)
            EdgeChange(typeSeven[1]);
        else if (cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall)
            EdgeChange(typeSeven[2]);
        else if (cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall)
            EdgeChange(typeSeven[3]);

    }

    private void TypeEight()
    {
        wallType = WallType.Eight;

        if (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall)
            EdgeChange(typeEight[0]);
        else if (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall)
            EdgeChange(typeEight[1]);
        else if (cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall)
            EdgeChange(typeEight[2]);
        else if (cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall)
            EdgeChange(typeEight[3]);

    }

    private void TypeNine()
    {
        wallType = WallType.Nine;

        if (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk)
            EdgeChange(typeNine[0]);
        else if (cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk)
            EdgeChange(typeNine[1]);
        else if (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk)
            EdgeChange(typeNine[2]);
        else if (cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk)
            EdgeChange(typeNine[3]);
    }

    private void TypeTen()
    {
        wallType = WallType.Ten;

        if (cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Chunk)
            EdgeChange(typeTen[0]);
        else if (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk)
            EdgeChange(typeTen[1]);
        else if (cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk)
            EdgeChange(typeTen[2]);
        else if (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk)
            EdgeChange(typeTen[3]);
    }

    private void TypeEleven()
    {
        wallType = WallType.Eleven;

        if (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk)
            EdgeChange(typeEleven[0]);
        else if (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk)
            EdgeChange(typeEleven[1]);
        else if (cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk)
            EdgeChange(typeEleven[2]);
        else if (cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk)
            EdgeChange(typeEleven[3]);
    }

    private void TypeTwelve()
    {
        wallType = WallType.Twelve;

        if (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk)
            EdgeChange(typeTwelve[0]);
        else if (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk)
            EdgeChange(typeTwelve[1]);
        else if (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk)
            EdgeChange(typeTwelve[2]);
        else if (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk)
            EdgeChange(typeTwelve[3]);
    }

    private void TypeThirteen()
    {
        wallType = WallType.Thirteen;

        if (cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk)
            EdgeChange(typeThirteen[0]);
        else if (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk)
            EdgeChange(typeThirteen[1]);

    }
    private void EdgeChange(GameObject edge) // change when done prototyping into instantiating instead of sprite change
    {
        if (!childChosen)
        {
            if (transform.childCount == 2)
            {
                childChosen = true;
            }

            Instantiate(edge, transform, false);
        }
        else if (childChosen && transform.childCount >= 2)
        {
            Destroy(transform.GetChild(0).gameObject);
        }


    }
    private enum WallType
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Eleven,
        Twelve,
        Thirteen
    }
}
