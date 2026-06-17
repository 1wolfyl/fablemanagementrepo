using UnityEngine;

public class ArenaStatManager1 : MonoBehaviour
{
    ArenaBaseState CurrentState;
    ArenaOpenState OpenState = new ArenaOpenState;
    ArenaCloseState CloseState = new ArenaCloseState;
    ArenaWinningState WinningState = new ArenaWinningState;
    ArenaLosingState LosingState = new ArenaLosingState;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
