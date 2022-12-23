using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Accuracy", menuName = "ScriptableObjects/Accuracy", order = 1)]
public class Accuracy : ScriptableObject
{
    public string playerName = "ArcellorMittal";
    public double alcotesterPoints = 0;
    public int perforatorPoints = 0;
    public double firstAidPoints = 0;
    public double testPoints = 0;
    public int language = 0;
    
    public Dictionary<string, string[]> text = new Dictionary<string, string[]>()
    {
        {"Default", new string[] {"МысалТекст", "ПримерныйТекст"} },
        {"FirstAid", new string[] {"Алғашқы көмек", "Первая помощь"} },
        {"Alcotester", new string[] {"Алкотестер", "Алкотестер"} },
        {"Test", new string[] {"Тест", "Тест"} },
        {"FirstAidTutorial1", new string[] { "Попадайте в круги с помощью SPACE", "SPACE көмегімен шеңберледі тиіңіз"} },
        {"FirstAidTutorial2", new string[] { "Зеленые круги это компрессии грудной-клетки", "Тест"} },
        {"FirstAidTutorial3", new string[] { "А фиолетовые это искусственное дыхание, нужно зажать Space", "Тест"} },
        {"PeforatorTutorial", new string[] { "Нажимайте Space пока шкала не дойдёт до конца", "IDK" } },
        {"Ready", new string[] { "Готово", "Дайын" } },
        {"Placeholder", new string[] { "Введите ваше имя", "Есіміңізді енгізіңіз" } },
        {"ReturnToMain", new string[] { "Вернуться на глвную", "Басты бетке қайту" } },
        {"SwitchLanguage", new string[] { "Тіл ауыстыру(KZ)", "Сменить язык(RU)" } },
        {"Proceed", new string[] { "Начать игру", "Ойын бастау" } },


        //{"IDK", new string[] { "IDK", "IDK" } },
        {"Q11", new string[] { "посещяемость/в случае беды знали где ты", "IDK"} },
        {"Q21", new string[] { "Пьяном", "IDK"} },
        {"Q31", new string[] { "Самоспасатель", "IDK"} },
        {"Q41", new string[] { "Руки должны находиться на расстоянии от движущихся деталей", "IDK"} },
        {"Q51", new string[] { "Проводить работы с электричеством", "IDK"} },
        {"Q61", new string[] { "Газоанализатор", "IDK"} },
        {"Q71", new string[] { "Для красоты", "IDK"} },
        {"Q81", new string[] { "Самоспасатель", "IDK"} },

        {"Q12", new string[] { "Туго завязать одежду", "IDK"} },
        {"Q22", new string[] { "Чистом", "IDK"} },
        {"Q32", new string[] { "Стационарный фонарь", "IDK"} },
        {"Q42", new string[] { "Включать инструмент только тогда, когда он находится в руках", "IDK"} },
        {"Q52", new string[] { "Трогать оголённые провода", "IDK"} },
        {"Q62", new string[] { "Перфоратор", "IDK"} },
        {"Q72", new string[] { "Не вдыхать вредные для здоровья частицы", "IDK"} },
        {"Q82", new string[] { "Закрыть ему рот", "IDK"} },

        {"Q13", new string[] { "Получать зарплату", "IDK"} },
        {"Q23", new string[] { "Трезвом", "IDK"} },
        {"Q33", new string[] { "Маску", "IDK"} },
        {"Q43", new string[] { "Направлять инструмент на людей", "IDK"} },
        {"Q53", new string[] { "Сообщать вышестоящим сотрудникам", "IDK"} },
        {"Q63", new string[] { "Самоспасатель", "IDK"} },
        {"Q73", new string[] { "Защита от радиации", "IDK"} },
        {"Q83", new string[] { "Сделать искусственную вентиляцию лёгких", "IDK"} },

        {"A1", new string[] { "зачем нужно проходить регистрацию?", "IDK"} },
        {"A2", new string[] { "В каком виде нельзя приходить на работу?", "IDK"} },
        {"A3", new string[] { "Что должен иметь при себе каждый работник?", "IDK"} },
        {"A4", new string[] { "Как не нужно вести себя с перфоратором?", "IDK"} },
        {"A5", new string[] { "Что должен делать сотрудник без проф. подготовки?", "IDK"} },
        {"A6", new string[] { "Какой аппарат определяет уровень газа?", "IDK"} },
        {"A7", new string[] { "Зачем нужен респиратор?", "IDK"} },
        {"A8", new string[] { "Как оказать помощь пострадавшему от угарного газа?", "IDK"} },
    };

    //"Зачем нужно проходить регистрацию?",
    //"В каком виде нельзя приходить на работу?",
    //"Что должен иметь при себе каждый работник?",
    //"Как не нужно вести себя с перфоратором?",
    //"Что не запрещено делать сотруднику без проф. подготовки",
    //"Какой аппарат определяет уровень газа?",
    //"Зачем нужен респиратор?",
    //"Как оказать помощь пострадавшему от угарного газа?",

    //{"Посещаемость/Знать где вы", "Потому что все проходят", "Получать зарплату"},
    //{"Пьяном", "Чистом", "Трезвом"},
    //{"Стационарный фонарь", "Самоспасатель", "Маску"},
    //{"Руки должны находиться на расстоянии от движущихся деталей", "Включать инструмент только тогда, когда он находится в руках", "Направлять инструмент на людей"},
    //{"Проводить работы с электричеством", "Трогать оголённые провода", "Сообщать вышестоящим сотрудникам"},
    //{"Газоанализатор", "Перфоратор", "Самоспасатель"},
    //{"Для красоты", "Не вдыхать вредные для здоровья частицы", "Защита от радиации"},
    //{"Туго завязать одежду", "Закрыть ему рот", "Сделать искусственную вентиляцию лёгких"},
}
