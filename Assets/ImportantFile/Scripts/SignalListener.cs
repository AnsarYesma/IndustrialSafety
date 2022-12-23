using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//В этом коде мы выполняем наши Евенты, чтобы включить и выключить объект в ContextClue.
//OnEnable срабатывает тогда когда объект Enable()
//OnDisable срабатывает тогда когда объект Disable()
//Затем мы отправляем this => (то есть player) в LetGo
//Где уже опять добавляться объект в listener если он есть а если нет то удаляется
public class SignalListener : MonoBehaviour
{
    public LetGo signal;
    public UnityEvent signalEvent;

    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }

    private void OnEnable()
    {
        signal.RegisterListener(this);
    }

    private void OnDisable()
    {
        signal.DeRegisterListener(this);
    }
}
