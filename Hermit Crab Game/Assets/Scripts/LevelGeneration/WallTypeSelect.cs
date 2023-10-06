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

    private void Awake()
    {
        cs_wallLogic = gameObject.GetComponent<WallLogic>();
    }
    public void TypeCheck()
    {

        #region TYPE THREE:
        if ((cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk) ||
            (cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk))
            TypeThree();
        #endregion

        #region TYPE FOUR:
        if ((cs_wallLogic.spaceChecks[2] == Space.Chunk &&
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

        #region TYPE TWO:
        if ((cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk) ||
            (cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk))
            TypeTwo();
        #endregion

        #region TYPE ONE:
        if (cs_wallLogic.spaceChecks[0] != Space.Chunk &&
            cs_wallLogic.spaceChecks[1] != Space.Chunk &&
            cs_wallLogic.spaceChecks[2] != Space.Chunk &&
            cs_wallLogic.spaceChecks[3] != Space.Chunk)
            TypeOne();
        #endregion

        #region TYPE FIVE:
        if (cs_wallLogic.spaceChecks[0] == Space.Chunk &&
            cs_wallLogic.spaceChecks[1] == Space.Chunk &&
            cs_wallLogic.spaceChecks[2] == Space.Chunk &&
            cs_wallLogic.spaceChecks[3] == Space.Chunk &&
            cs_wallLogic.spaceChecks[4] == Space.Chunk &&
            cs_wallLogic.spaceChecks[5] == Space.Chunk &&
            cs_wallLogic.spaceChecks[6] == Space.Chunk &&
            cs_wallLogic.spaceChecks[7] == Space.Chunk)
            TypeFive();
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
        Six
    }
}
