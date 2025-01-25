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
    public string[] des = {"��� � ������ ����...", "������ ����� �������. ��������.", "������������ ��������, ��� ��������� ��������� ���� ����� �� �����.", "�������, ��� ������� �� ����.", "��������� ������ �������� ���� � ����� � ��.�������", "������� �� ������ ������ ������� � ������ ���� �������. �������.", "������ ������� �������. ������� ������.", "������ ����� ����� ������ ���������� �����. �� �� ������ �������.", "� ������ ������� ����� �������!", "������ � �������� ��������� �������� ���� � ������. ���� ���-�� �������...", "������� �����, �� ������ ������� ���������, �� ��� ������.", "�� ������� ������� ���-�� ����? � ��������� ����� ����������� ����.", "����� �� ������� �� �����, ��������� ���������� � �������� � �������� � ����������.", "������ ��� �������� �����, <��>, ����������. �������� �����.", "������� ������� �������� �������. ����� ������ ��? �� ����.", "��������� � ������ ������� �� �����. �������� ������ ���������� ���������, ������ ��� �� ���� ���������.", "� �������� ������� �������� ���� �������� ����� ������� ���������� �������."};

    public Animator anim;
    public GameObject fading;

    private void Start()
    {
        StartCoroutine(ActiveFading());
        description.text = des[(Random.Range(0, des.Length))];
    }

    void Update()
    {
        
        day.text = "����: " + Days.ToString() + " / 30";
        day2.text = "���� " + Days.ToString();
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
