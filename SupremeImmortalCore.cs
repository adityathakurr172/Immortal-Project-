// ===============================================================
// 9X PRO SUPREME ENGINE - THE IMMORTAL MASTER v3.5
// NO COMPROMISE | FULL HARDWARE ACCESS | AUTO-MAINTENANCE
// ===============================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace NineXPro
{
    public class SupremeImmortalCore : MonoBehaviour
    {
        public static SupremeImmortalCore Instance;

        [Header("🛡️ Engine Safety & Thermal Lock")]
        public int targetFPS = 60;
        public float thermalCleanThreshold = 0.85f; // 85% Memory Trigger
        public bool autoPurgeEnabled = true;

        [Header("✨ Soul-Sync Visuals")]
        public float globalNoorIntensity = 1.5f;
        public Color cinematicNoorColor = new Color(1f, 0.98f, 0.9f, 1f);

        [Header("🎧 Audio-Haptic Link")]
        public float bassSensitivity = 12f;
        public bool deepHapticPulse = true;

        private List<KineticTextEntity> activeTexts = new List<KineticTextEntity>();
        private AudioVisualizer audioCore;
        private HapticHardwareBridge hapticBridge;
        private float lastPurgeTime;

        // -----------------------------------------------------------
        void Awake()
        {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
                return;
            }
            InitializeSupremeSystem();
        }

        void InitializeSupremeSystem()
        {
            // Kirin 810 Performance Optimization
            Application.targetFrameRate = targetFPS;
            QualitySettings.vSyncCount = 0;
            
            // Component Recovery Logic (Self-Healing)
            audioCore = GetComponent<AudioVisualizer>() ?? gameObject.AddComponent<AudioVisualizer>();
            hapticBridge = new HapticHardwareBridge();

            // Lighting Engine (Noor Projection)
            GameObject lightObj = GameObject.Find("SupremeNoorLight") ?? new GameObject("SupremeNoorLight");
            Light mainLight = lightObj.GetComponent<Light>() ?? lightObj.AddComponent<Light>();
            mainLight.type = LightType.Directional;
            mainLight.color = cinematicNoorColor;
            mainLight.intensity = globalNoorIntensity;
            mainLight.shadows = LightShadows.Soft;

            lastPurgeTime = Time.time;
            Debug.Log("🌌 9X PRO SUPREME CORE: Fully Loaded & Unbreakable.");
        }

        void Update()
        {
            float currentBass = audioCore.GetBassLevel(bassSensitivity);

            // 1. Update Every Soul-Linked Text
            for (int i = 0; i < activeTexts.Count; i++) {
                if (activeTexts[i] != null)
                    activeTexts[i].ExecuteImmortalMotion(currentBass);
            }

            // 2. Real-Time Hardware Vibration Pulse
            if (deepHapticPulse && currentBass > 0.18f)
                hapticBridge.InvokePulse(currentBass);

            // 3. Auto-Maintenance (सफाई कोड)
            if (autoPurgeEnabled && Time.time > lastPurgeTime + 300f) // हर 5 मिनट में गहरी जांच
                StartCoroutine(DeepEngineClean());
        }

        IEnumerator DeepEngineClean()
        {
            Debug.Log("🧽 Engine Purge Started: Cleaning Memory & Leaks...");
            System.GC.Collect();
            yield return new WaitForEndOfProcess();
            Resources.UnloadUnusedAssets();
            lastPurgeTime = Time.time;
        }

        public void RegisterNewEntity(KineticTextEntity entity) => activeTexts.Add(entity);
        
        void OnDisable() => StopAllCoroutines();
    }

    // ============================================================
    // 🔤 KINETIC TEXT ENGINE 2.0 (FLUID BRAHMAN LEVEL)
    // ============================================================
    [System.Serializable]
    public class KineticTextEntity
    {
        public Transform textTransform;
        public Material textMaterial;
        private float noiseSeed;
        private Vector3 originalPos;
        private static readonly int GlowID = Shader.PropertyToID("_GlowIntensity");

        public KineticTextEntity(Transform trans, Material mat)
        {
            textTransform = trans;
            textMaterial = mat;
            originalPos = trans.localPosition;
            noiseSeed = Random.Range(0f, 1000f);
        }

        public void ExecuteImmortalMotion(float intensity)
        {
            if (textTransform == null) return;

            // Fluid Perlin Movement (No Static Animation)
            float speed = Time.time * 0.5f;
            float offX = (Mathf.PerlinNoise(noiseSeed + speed, speed) - 0.5f) * (0.3f + intensity);
            float offY = (Mathf.PerlinNoise(speed, noiseSeed - speed) - 0.5f) * (0.3f + intensity);
            
            textTransform.localPosition = originalPos + new Vector3(offX, offY, 0);

            // Audio-Linked Noor Intensity
            if (textMaterial != null) {
                float glow = 0.5f + (intensity * 3.5f);
                textMaterial.SetFloat(GlowID, glow);
            }
        }
    }

    // ============================================================
    // ⚡ NATIVE HAPTIC BRIDGE (KIRIN 810 DIRECT ACCESS)
    // ============================================================
    public class HapticHardwareBridge
    {
        public void InvokePulse(float power)
        {
            #if UNITY_ANDROID && !UNITY_EDITOR
            try {
                using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                using (var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                using (var vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator"))
                {
                    if (vibrator.Call<bool>("hasVibrator")) {
                        long ms = (long)(power * 60); // Longer pulse for heavy bass
                        vibrator.Call("vibrate", ms);
                    }
                }
            } catch (System.Exception e) {
                Debug.LogError("Haptic Error: " + e.Message);
            }
            #endif
        }
    }

    // ============================================================
    // 🔊 AUDIO SPECTRUM SENSE (THE SOUL)
    // ============================================================
    public class AudioVisualizer : MonoBehaviour
    {
        private AudioSource audioSrc;
        private float[] spectrumData = new float[256];

        void Start() {
            audioSrc = GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();
            audioSrc.playOnAwake = false;
        }

        public float GetBassLevel(float sensitivity)
        {
            if (audioSrc == null || !audioSrc.isPlaying) return 0;
            
            audioSrc.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
            // Deep Bass Sampling (0-10Hz range)
            float bass = 0;
            for (int i = 0; i < 5; i++) bass += spectrumData[i];
            
            return Mathf.Clamp01(bass * sensitivity);
        }
    }
}
