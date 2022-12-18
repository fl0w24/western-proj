using System;
using UnityEngine;
using FMODUnity;

public class TimeOfDay : MonoBehaviour
{
    public bool showTime;

    static float correctedTime;
    
    string correctedTime_str;
    [HideInInspector] public static string hours_str;
    [HideInInspector] public static string minutes_str;

    private void Update()
    {
        // Передаем глобальному параметру timeOfDay скорректированное время
        FMODUtil.SetGlobalParameter("timeOfDay", get());

        // Подготовка строки времени вида HH:MM для вывода на экран
        hours_str = ((int)Math.Truncate(correctedTime)).ToString();
        minutes_str = ((int)((correctedTime - Math.Truncate(correctedTime)) * 60f)).ToString();
        if (minutes_str.Length == 1) minutes_str = "0" + minutes_str;
        correctedTime_str = hours_str + ":" + minutes_str;
    }

    public static float get()
    {
        // Приведение времени вида 0..1 к виду 0..24 со смещением вперед на 2 часа
        correctedTime = DayAndNightControl.currentTime * 24f + 2f;
        if (correctedTime >= 24) correctedTime -= 24f;
        return correctedTime;
    }

    private void OnGUI()
    {
        if (showTime)
        {
            // Настройка и вывод времени на экран
            GUIStyle gui = GUI.skin.box;
            gui.alignment = TextAnchor.MiddleCenter;
            gui.clipping = TextClipping.Clip;
            gui.fontSize = 40;
            GUILayout.BeginArea(new Rect(10, Screen.height - 10 - 50, 120f, 50f));
            GUILayout.Box(correctedTime_str, gui, GUILayout.MaxHeight(50f), GUILayout.MaxWidth(120f));
            GUILayout.EndArea();
        }
    }
}
