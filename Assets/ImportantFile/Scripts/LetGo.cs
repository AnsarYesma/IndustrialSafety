using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//В этом коде listener это тот объект у кого есть скрипт SignalListener
//Raise() запускает SignalListener если размер listener - 1 не меньше нуля
//RegisterListener добавление объекта
//DeRegisterListener удаление объекта
[CreateAssetMenu]
public class LetGo : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
