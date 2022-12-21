using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PowerupManager : ScriptableObject
{
    [SerializeField] Battery _battery;
    [SerializeField] Magnet _magnet;

    public Battery Battery
    {
        get { return _battery; }
        set
        {
            _battery = value;
            // When setting powerup, save it's config file name to PlayerPrefs
            PlayerPrefs.SetString("BatteryLevel", _battery.name);
            Debug.Log(_battery.name + " has been saved in PlayerPrefs");
        }
    }
    public Magnet Magnet
    {
        get { return _magnet; }
        set
        {
            _magnet = value;
            PlayerPrefs.SetString("MagnetLevel", _magnet.name);
            Debug.Log(_magnet.name + " has been saved in PlayerPrefs");
        }
    }

    private void Awake()
    {
        //Read current powerup level from PlayerPrefs on startup
        // Stay at default if not found
        Battery tmp = Resources.Load<Battery>("Config/" + PlayerPrefs.GetString("BatteryLevel"));
        if (tmp != null)
        {
            _battery = tmp;
            Debug.Log("Battery: " + tmp.name + " has been loaded!");
        }

        Magnet tmp2 = Resources.Load<Magnet>("Config/" + PlayerPrefs.GetString("MagnetLevel"));
        if (tmp2 != null)
        {
            _magnet = tmp2;
            Debug.Log("Magnet: " + tmp2.name + " has been loaded!");
        }
    }

    // This function must be enabled to initialise powerups in PlayerPrefs before Build
    //private void OnValidate()
    //{
    //    Battery = _battery;
    //    Magnet = _magnet;
    //}
}
