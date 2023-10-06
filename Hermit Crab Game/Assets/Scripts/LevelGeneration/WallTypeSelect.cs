using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class WallTypeSelect : MonoBehaviour
{
    private WallLogic cs_wallLogic;
    [SerializeField] private WallType wallType;

    [SerializeField] private Sprite[] typeOne; // 4
    [SerializeField] private Sprite[] typeTwo; // 4
    [SerializeField] private Sprite[] typeThree; // 4
    [SerializeField] private Sprite[] typeFour; // 4
    [SerializeField] private Sprite typeFive; // 1
    [SerializeField] private Sprite[] typeSix; // 2
    [SerializeField] private Sprite[] typeSeven; // 4
    [SerializeField] private Sprite[] typeEight; // 4
    [SerializeField] private Sprite[] typeNine; // 4
    [SerializeField] private Sprite[] typeTen; // 4
    [SerializeField] private Sprite[] typeEleven; // 4
    [SerializeField] private Sprite[] typeTwelve; // 4

    private void Awake()
    {
        cs_wallLogic = gameObject.GetComponent<WallLogic>();
    }
    public void TypeCheck()
    {
        #region TYPE FIVE 38:
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
        #region TYPE ELEVEN 14:
        else if ((cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Empty &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[2] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Empty &&
            cs_wallLogic.spaceChecks[0] == Space.Wall &&
            cs_wallLogic.spaceChecks[3] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[4] == Space.Empty &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Wall &&
            cs_wallLogic.spaceChecks[1] == Space.Wall) ||
            (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Empty &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Wall &&
            cs_wallLogic.spaceChecks[2] == Space.Wall))
            TypeEleven();
        #endregion
        #region TYPE NINE 22:
        else if ((cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk))
            TypeNine();
        #endregion
        #region TYPE ONE 3:
        else if (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk)
            TypeOne();
        #endregion
        #region TYPE SIX 6:
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
        #region TYPE TEN 14:
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
        #region TYPE SEVEN 14:
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
        #region TYPE EIGHT 14:
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
        #region TYPE TWO 14:
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
        #region TYPE FOUR 10:
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
        #region TYPE TWELVE 14:

        else if ((cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk))
            TypeTwelve();
        #endregion
        #region TYPE THREE 6:
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
            cs_wallLogic.spaceChecks[6] == Space.Chunk)
            EdgeChange(typeTen[0]);
        else if (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk)
            EdgeChange(typeTen[1]);
        else if (cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk)
            EdgeChange(typeTen[2]);
        else if (cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk)
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

    private void EdgeChange(Sprite edge) // change when done prototyping into instantiating instead of sprite change
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = edge;
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
        Twelve
    }
}
