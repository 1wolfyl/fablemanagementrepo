using UnityEngine;

public class DialogueManager1 : MonoBehaviour
{
    DialogueBaseState CurrentState;
    DialogueStartState StartState = new DialogueStartState();  
    DialogueChoicesState ChoiceState = new DialogueChoicesState();
    DialogueEndState EndState = new DialogueEndState();
    DialogueNextState NextState = new DialogueNextState();
   
    void Start()
    {
        // Set the initial state to StartState
        CurrentState = StartState;
        // "this" is a refernces to the conext (this script) that is being used in the state machine, so we can use it to call the functions in the states
        CurrentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }

  public  void SwitchState(DialogueBaseState newState) { 
        CurrentState = newState;
        CurrentState.EnterState(this);
    }
}
