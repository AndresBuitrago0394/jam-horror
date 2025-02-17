using UnityEngine;

namespace Ilumisoft.GraphicsControl
{
    /// <summary>
    /// Default settings storage using PlayerPrefs. You can write your own storage class by extending the <see cref="GraphicSettingsStorage"/>
    /// </summary>
    [DisallowMultipleComponent()]
    public class DefaultGraphicSettingsStorage : GraphicSettingsStorage
    {
        public override void SetFloat(string key, float value) => PlayerPrefs.SetFloat(key, value);
        public override void SetInt(string key, int value) => PlayerPrefs.SetInt(key, value);
        public override void SetString(string key, string value) => PlayerPrefs.SetString(key, value);
        public override void SetBool(string key, bool value) => PlayerPrefs.SetInt(key, value ? 1 : 0);
        public override float GetFloat(string key, float defaultValue) => PlayerPrefs.GetFloat(key, defaultValue);
        public override int GetInt(string key, int defaultValue) => PlayerPrefs.GetInt(key, defaultValue);
        public override string GetString(string key, string defaultValue) => PlayerPrefs.GetString(key, defaultValue);
        public override bool GetBool(string key, bool defaultValue)
        {
            int value = PlayerPrefs.GetInt(key, defaultValue ? 1 : 0);

            return value != 0;
        }

        private void OnDisable()
        {
            PlayerPrefs.Save();
        }

        private void OnApplicationFocus(bool focus)
        {
            if(!focus)
            {
                PlayerPrefs.Save();
            }
        }

        private void OnApplicationPause(bool pause)
        {
            PlayerPrefs.Save();
        }
    }
}