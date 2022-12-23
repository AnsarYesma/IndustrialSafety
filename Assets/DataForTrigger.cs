using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Сохранение тригеров
[CreateAssetMenu(fileName = "DataTrigger")]
public class DataForTrigger : ScriptableObject
{
    public Vector3 target;

    public Vector3 target2;

    public GameObject trig;

    public bool music = false;

    public int[] page;

    public string[] scene;

    public bool[] way;

    public int numdays = -1;

    public int DeleteRock = -1;

    public string[] QuestionText = new string []
        {
            "Зачем нужно проходить регистрацию?",
            "В каком виде нельзя приходить на работу?",
            "Что должен иметь при себе каждый работник?",
            "Как не нужно вести себя с перфоратором?",
            "Что не запрещено делать сотруднику без проф. подготовки",
            "Какой аппарат определяет уровень газа?",
            "Зачем нужен респиратор?",
            "Как оказать помощь пострадавшему от угарного газа?",

        };
    
}
