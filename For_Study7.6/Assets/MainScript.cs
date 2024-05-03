using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using UnityEngine.UI;
using System.Timers;


public class MainScript : MonoBehaviour
{

    [SerializeField] private Text villagers_show;
    [SerializeField] private Text villagers_eat_show;
    [SerializeField] private Text wheat_show;
    [SerializeField] private Text wheat_Shange_show;
    [SerializeField] private Text warriors_show;
    [SerializeField] private Text warriors_eat_show;
    [SerializeField] private Text next_wave;
    [SerializeField] private Text time_show;
    [SerializeField] private Text day_show;
    [SerializeField] private Image villager_show_icon;
    [SerializeField] private Image warrior_show_icon;
    [SerializeField] private Text text_for_vill_spawn;
    [SerializeField] private Text text_for_warr_spawn;
    [SerializeField] private Image enemys_path_to_show;
    [SerializeField] private AudioSource audioSource_vill;
    [SerializeField] private AudioSource audioSource_warr;
    [SerializeField] private AudioSource audioSource_main;
    [SerializeField] private AudioClip sound_vill_one;
    [SerializeField] private AudioClip sound_vill_two;
    [SerializeField] private AudioClip sound_vill_three;
    [SerializeField] private AudioClip sound_warr_one;
    [SerializeField] private AudioClip sound_warr_two;
    [SerializeField] private AudioClip sound_battle;
    [SerializeField] private AudioSource audioSource_battle;
    [SerializeField] private Text show_time_enemys;
    [SerializeField] private GameObject win_window;
    [SerializeField] private GameObject loose_window;
    [SerializeField] private Text reason;
    [SerializeField] private Text count_win_attacks;
    [SerializeField] private Text vill_spawns;

    // ���������
    bool vill_start = false;
    bool warr_start = false; 


    //������� ��� �������
    float timer_for_vill_null = 0f;
    float timer_for_vill_interval = 180f;

    // ������� ��� ������
    float timer_for_warr_null = 0f;
    float timer_for_warr_interval = 240f;


    //������� ��� ���� �������
    float tickTimer = 0f;
    float tickInterval = 60f; // ����� �� ���� ������

    //������� ��� ������
    float timer_for_enemys_null = 0f;
    float timer_for_enemys_interval = 2880f;

    //���������
    int enemys = 2; // ���-�� ������
    int villagers = 3; //��������� ����� ��������
    int warriors = 0; //��������� ����� ������
    int wheat = 10; //��������� ����� �������
    int timer_h = 6; //�� ������� ���������� ����
    int timer_min = 00;
    int day = 0;
    float time = 0f;
    int previous_timer_h = -1; // �������� �������, ��� � ������ ��� �� �� 500 ����������� ����� ��� � ���� ���� 0 ������������� 450+����
    int wheat_change; // ���� �������
    int villagers_feed; // ���� ��������
    int warriors_feed; // ���� ������
    string reason_const;
    int count_win;
    int vill_count;
    
    void Start()
    {
        
        Time.timeScale = 0f;
        villagers_feed = -(villagers); 
        warriors_feed = -(warriors * 2); 
        text_for_vill_spawn.text = "������ ����������� \n -5 �������";
        text_for_warr_spawn.text = "������ ����� \n - 20 ������� -1 ����������";


    }


    void Update()
    {
        Villager_spawn();
        Timeline();
        Warrior_Spawn();
        Enemys_path();
        villagers_feed = -(villagers);
        warriors_feed = -(warriors * 2);
        wheat_change = villagers * 3 - villagers - warriors * 2;
        next_wave.text = "� ��� ������ " + enemys.ToString() + " ������";
        if (day == 31)
        {
            Win();
        }


        if (wheat <= 0)
        {
            reason_const = "���� ������� ������ �� ������";
            Loose();
        }

        count_win_attacks.text ="�������� �������: " + count_win.ToString();
        vill_spawns.text = "������� �������: " + vill_count.ToString();

        

    }

    private void Win()
    {
        Time.timeScale = 0;
        win_window.SetActive(true);
    }
    private void Loose()
    {
        Time.timeScale = 0;
        loose_window.SetActive(true);
        reason.text = reason_const;
    }

    public void Pause_Button()
    {
        Time.timeScale = 0;
    }


    private void Enemys_path() // ������ ��� ���������
    {
        timer_for_enemys_null += Time.deltaTime * Time.timeScale;
        enemys_path_to_show.fillAmount = timer_for_enemys_null / timer_for_enemys_interval;
        

        
            float time_to_attack = timer_for_enemys_interval - timer_for_enemys_null;
            if (time_to_attack > 0)
            {

                int minutes = Mathf.FloorToInt(time_to_attack / 60);
                int seconds = Mathf.FloorToInt(time_to_attack % 60);
                show_time_enemys.text = string.Format("�� �������� ��������: {0:00} ����� {1:00} �����", minutes, seconds);
            }

            else
            {
                show_time_enemys.text = "";
            }
        


        if (timer_for_enemys_null >= timer_for_enemys_interval) 
        {
            audioSource_battle.Play();
            Battle();
            timer_for_enemys_null = 0f;
        }
    }
    public void Escape_button() // ������ ������
    {
        Application.Quit();
    }

    public void Harvest() // ����� �������� ����� ����� ����� ������/���
    {
        wheat += villagers * 3 - villagers - warriors * 2;
    } 

    private void Timeline() // ����� ������� 
    {
        time += Time.deltaTime * Time.timeScale;
        tickTimer += Time.deltaTime * Time.timeScale; // �� ����� ��� ���� ����, �� � ��� ���� ���������, ��� ��� ��� 
        if (tickTimer >= tickInterval)
        {
            Harvest();
            tickTimer -= tickInterval;
        }


        timer_min = (int)time;
        timer_h = (timer_min / 60) + 6;
        timer_min %= 60;
        timer_h %= 24;


        if (timer_h < previous_timer_h) //������� ���
        {
            day++;
        }
        previous_timer_h = timer_h;

        //����� ������ � �������� �������
        time_show.text = string.Format("{0:D2}:{1:D2}", timer_h, timer_min);
        day_show.text = "����:" + day.ToString();
        wheat_show.text = "= " + wheat.ToString();
        villagers_show.text = "= " + villagers.ToString();
        warriors_show.text = "= " + warriors.ToString();
        villagers_eat_show.text = villagers_feed.ToString() + "/�";
        warriors_eat_show.text = warriors_feed.ToString() + "/�";
        wheat_Shange_show.text = wheat_change.ToString() + "/�";
        

       


    }

    public void Time_Faster_Button() //��������� �������
    {
        Time.timeScale = 15f;
        
    }

    public void Time_Normal() //��������� �������
    {
        Time.timeScale = 3f;
    }  

    public void Villager_Button() //������ ������ + ��������
    {
        if (wheat >= 5)
        {
            vill_start = true;
        }
    }

    public void Mute_button() // ������ ����
    {
        
        if (audioSource_main.mute == true)
        {
            audioSource_main.mute = false;
            audioSource_vill.mute = false;
            audioSource_warr.mute = false;
            audioSource_battle.mute = false;
        }
        else
        {
            audioSource_main.mute = true;
            audioSource_vill.mute = true;
            audioSource_warr.mute = true;
            audioSource_battle.mute = true;
        }
    }

    public void Warrior_Button() // ������ + �������� �������
    {
        if (wheat >= 20 && villagers >= 1)
        {
            warr_start = true;
        }
    } 

    private void Villager_spawn() // � �� ���� ��� ��������� ����� � ��� ���� ���� �������� ��� �� ������, ��� ��� �������� ������� ��� "�������"
    {

        if (vill_start == true )  // ��, � ��� ��������� ��� ��� ���� � Update() , �� ����� ��� ���� �� ��� ���� ��������
        {
            timer_for_vill_null += Time.deltaTime * Time.timeScale;
            villager_show_icon.fillAmount = timer_for_vill_null / timer_for_vill_interval;
            villager_show_icon.color = Color.red;

            if (timer_for_vill_null < 60)
            {
                text_for_vill_spawn.text = "��������� ������ �������";
            }
            else if (timer_for_vill_null > 60 && timer_for_vill_null < 120)
            {
                text_for_vill_spawn.text = "���������� �� ����";
            }
            else
            {
                text_for_vill_spawn.text = "������� ������ � ����";
            }
            if (timer_for_vill_null >= timer_for_vill_interval)
            {
                
                wheat -= 5;
                villagers++;
                vill_start = false;
                timer_for_vill_null = 0f;
                text_for_vill_spawn.text = "������ ����������� \n -5 �������";
                villager_show_icon.color = new Color(0.9372f, 0.8941f, 0.6901f, 1f);
                int randomNumber = UnityEngine.Random.Range(1, 4);
                if(randomNumber == 1)
                {
                    audioSource_vill.clip = sound_vill_one;
                }
                else if(randomNumber == 2)
                {
                    audioSource_vill.clip = sound_vill_two;
                }
                else
                {
                    audioSource_vill.clip = sound_vill_three;
                }
                
                audioSource_vill.Play();
                vill_count++;

            }
        }
    }

    private void Warrior_Spawn() 
    {
        if (warr_start == true) 
        {
            
            timer_for_warr_null += Time.deltaTime * Time.timeScale;
            warrior_show_icon.fillAmount = timer_for_warr_null / timer_for_warr_interval;
            warrior_show_icon.color = Color.red;
            if (timer_for_warr_null < 80)
            {
                text_for_warr_spawn.text = "���� ���� ������";
            }
            else if (timer_for_warr_null > 80 && timer_for_warr_null < 160)
            {
                text_for_warr_spawn.text = "���� �� �������� ������";
            }
            else
            {
                text_for_warr_spawn.text = "���� ������ �� ������";
            }
            if (timer_for_warr_null >= timer_for_warr_interval)
            {
                wheat -= 20;
                villagers--;
                warriors++;
                warr_start = false;
                timer_for_warr_null = 0f;
                text_for_warr_spawn.text = "������ ����� \n - 20 ������� -1 ����������";
                warrior_show_icon.color = new Color(0.9372f, 0.8941f, 0.6901f, 1f);
                int randomNumber = UnityEngine.Random.Range(1, 3);
                if (randomNumber == 1)
                {
                    audioSource_warr.clip = sound_warr_one;
                }
                else 
                {
                    audioSource_warr.clip = sound_warr_two;
                }
               

                audioSource_warr.Play();


            }
        }
        
    }

    private void Battle() // ����� ������������ ���
    {
        
        if (warriors < enemys)
        {
            int enemys_to_war = enemys;
            enemys_to_war -= warriors;
            warriors = 0;
            villagers = villagers - enemys_to_war*2;
        }
        else
        {
            warriors -= enemys;
        }

        if (villagers <= 0 && warriors <= 0) //�������� ���������
        {
            reason_const = "���� ������� ����������";
            count_win--;
            Loose();
        }
        count_win++;
        enemys ++;
        


    }
}
