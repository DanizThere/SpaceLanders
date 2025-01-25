using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayChange : MonoBehaviour
{
    public int counts = 15;
    public static int localCounts = 15;

    public int Days = 1;

    public TMPro.TMP_Text day;

    public TMPro.TMP_Text day2;
    public TMPro.TMP_Text description;
    public string[] des = {"Вот и первый день...", "Экипаж вроде хороший. Прорвёмся.", "Командование сообщило, что следующие несколько дней связи не будет.", "Странно, что роботов не дали.", "Скоротать вечера помогает игра в карты с Вт.Пилотом", "Стрелок из мусора сделал самопал и сломал очки Учёному. Потешно.", "Учёный хороший паренек. Наивный только.", "Второй Пилот порой выдает интересные мысли. Их бы только уловить.", "Я собрал впервые кубик Крубика!", "Учёный с Стрелком постоянно цапаются друг с другом. Надо что-то сделать...", "Механик милая, но только немного грубовата, на мой взгляд.", "За стенами корабля что-то есть? Я постоянно слышу неизвестный звук.", "Чтобы не умереть от скуки, постоянно соревнуюсь с Стрелком в меткости в стрельбище.", "Учёный дал почитать книгу, <Мы>, называется. Занятная штука.", "Механик сегодня выглядит усталой. Может помочь ей? Не знаю.", "Поговорил с Вторым Пилотом по душам. Оказался вполне интересным человеком, только ему не везёт постоянно.", "Я позволил Стрелку включить свой плейлист через систему оповещения корабля."};

    public Animator anim;
    public GameObject fading;

    private void Start()
    {
        StartCoroutine(ActiveFading());
        description.text = des[(Random.Range(0, des.Length))];
    }

    void Update()
    {
        
        day.text = "День: " + Days.ToString() + " / 30";
        day2.text = "День " + Days.ToString();
        if (localCounts < 1)
        {
            Fade();
            Days++;
            description.text = des[Random.Range(0, des.Length)];
            counts += 5;
            localCounts = counts;
            anim.SetTrigger("NewDay");
            StartCoroutine(ActiveFading());
        }
        if (Days > 30)
        {
            SceneManager.LoadScene(3);
        }
    }

    IEnumerator ActiveFading()
    {
        yield return new WaitForSeconds(5);
        fading.SetActive(false);
    }
    void Fade()
    {
        fading.SetActive(true);
    }
}
