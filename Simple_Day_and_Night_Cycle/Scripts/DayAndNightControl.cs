//2016 Spyblood Games

using UnityEngine;
using System.Collections;

[System.Serializable]
public class ColorsByTime
{
    public Color skyColor;
    public Color equatorColor;
    public Color horizonColor;
    public Color fogColor;
}

public class DayAndNightControl : MonoBehaviour
{
    public bool StartDay; //start game as day time
    public GameObject StarDome;
    public GameObject moonState;
    public GameObject moon;
    public ColorsByTime dawnColors;
    public ColorsByTime dayColors;
    public ColorsByTime nightColors;
    public int currentDay = 0; //day 8287... still stuck in this grass prison... no esacape... no freedom...
    public Light directionalLight; //the directional light in the scene we're going to work with
    public float SecondsInAFullDay = 120f; //in realtime, this is about two minutes by default. (every 1 minute/60 seconds is day in game)
    public static float currentTime = 0; //at default when you press play, it will be nightTime. (0 = night, 1 = day)
    [Range(0, 1)]
    public float setCurrentTime = 0;
    [HideInInspector]
    public float timeMultiplier = 1f; //how fast the day goes by regardless of the secondsInAFullDay var. lower values will make the days go by longer, while higher values make it go faster. This may be useful if you're siumulating seasons where daylight and night times are altered.
    public bool showUI;
    float lightIntensity; //static variable to see what the current light's insensity is in the inspector
    Material starMat;

    Camera targetCam;

    public bool activeCycle;
    [Range(0f, 180f)] public float sunAngleY = 170f;

    // test


    // Use this for initialization
    void Start()
    {
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;
        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = 0f;
        RenderSettings.fogEndDistance = 256f;
        foreach (Camera c in GameObject.FindObjectsOfType<Camera>())
        {
            if (c.isActiveAndEnabled)
            {
                targetCam = c;
            }
        }
        lightIntensity = directionalLight.intensity; //what's the current intensity of the light
        starMat = StarDome.GetComponentInChildren<MeshRenderer>().material;
        if (StartDay)
        {
            setCurrentTime = 0.1667f; //start at morning
            starMat.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLight();
        if (activeCycle) setCurrentTime += (Time.deltaTime / SecondsInAFullDay) * timeMultiplier;
        if (setCurrentTime >= 1)
        {
            setCurrentTime = 0; //once we hit "midnight"; any time after that sunrise will begin.
            currentDay++; //make the day counter go up
        }
        currentTime = setCurrentTime;
    }

    void UpdateLight()
    {
        StarDome.transform.Rotate(new Vector3(0, 2f * Time.deltaTime, 0));
        moon.transform.LookAt(targetCam.transform);
        directionalLight.transform.localRotation = Quaternion.Euler((currentTime * 360f) - 90f, sunAngleY, 0f);
        moonState.transform.localRotation = Quaternion.Euler((currentTime * 360f) - 100f, sunAngleY, 0f);

        //^^ we rotate the sun 360 degrees around the x axis, or one full rotation times the current time variable. we subtract 90 from this to make it go up
        //in increments of 0.25.

        //the 170 is where the sun will sit on the horizon line. if it were at 180, or completely flat, it would be hard to see. Tweak this value to what you find comfortable.

        float intensityMultiplier = 1;

        if (currentTime <= 0.23f || currentTime >= 0.75f)
        {
            intensityMultiplier = 0; //when the sun is below the horizon, or setting, the intensity needs to be 0 or else it'll look weird
            starMat.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, Time.deltaTime));
        }
        else if (currentTime <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTime - 0.23f) * (1 / 0.02f));
            starMat.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, Time.deltaTime));
        }
        else if (currentTime <= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTime - 0.73f) * (1 / 0.02f)));
        }

        if (directionalLight.transform.eulerAngles.x <= 180f) intensityMultiplier = 1f;
        else intensityMultiplier = 0f;

        //change env colors to add mood

        if (currentTime > 0.72f || (currentTime > 0f && currentTime < 0.2f))
            changeRenderColors(nightColors, 0.24f);

        if (currentTime > 0.2f && currentTime < 0.4f)
            changeRenderColors(dawnColors, 0.1f);

        if (currentTime > 0.4f && currentTime < 0.72f)
            changeRenderColors(dayColors, 0.16f);

        directionalLight.intensity = lightIntensity * intensityMultiplier;
    }

    public string TimeOfDay()
    {
        string dayState = "";
        if (currentTime > 0f && currentTime < 0.1f)
        {
            dayState = "Midnight";
        }
        if (currentTime < 0.5f && currentTime > 0.1f)
        {
            dayState = "Morning";

        }
        if (currentTime > 0.5f && currentTime < 0.6f)
        {
            dayState = "Mid Noon";
        }
        if (currentTime > 0.6f && currentTime < 0.8f)
        {
            dayState = "Evening";

        }
        if (currentTime > 0.8f && currentTime < 1f)
        {
            dayState = "Night";
        }
        return dayState;
    }

    void OnGUI()
    {
        //debug GUI on screen visuals
        if (showUI)
        {
            GUILayout.Box("Day: " + currentDay);
            GUILayout.Box(TimeOfDay());
            GUILayout.Box("Time slider");
            GUILayout.VerticalSlider(currentTime, 0f, 1f);
        }
    }

    void changeRenderColors(ColorsByTime colorsByTime, float lerpDuration)
    {
        RenderSettings.ambientSkyColor = Color.Lerp(RenderSettings.ambientSkyColor, colorsByTime.skyColor, Time.deltaTime * lerpDuration);
        RenderSettings.ambientEquatorColor = Color.Lerp(RenderSettings.ambientEquatorColor, colorsByTime.equatorColor, Time.deltaTime * lerpDuration);
        RenderSettings.ambientGroundColor = Color.Lerp(RenderSettings.ambientGroundColor, colorsByTime.horizonColor, Time.deltaTime * lerpDuration);
        RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, colorsByTime.fogColor, Time.deltaTime * lerpDuration);
    }
}
