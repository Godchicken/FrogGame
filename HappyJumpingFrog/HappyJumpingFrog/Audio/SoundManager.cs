using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace HappyJumpingFrog
{
    // รายชื่อเสียงเอฟเฟกต์ทั้งหมดในเกม
    public enum Sfx { Jump, Splash, GameOver, NextLevel, Win, Heal, Time, Coin, Horn }

    public static class SoundManager
    {
        private const double MusicVolume = 0.30;   // เพลงดังกว่าเอฟเฟกต์ จึงลดเสียงลง
        private const double SfxVolume = 1.00;
        private const int PoolSize = 4;            // เสียงเดียวกันเล่นซ้อนกันได้ 4 ชุด

        private static readonly string SoundsFolder =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");

        // เสียงแต่ละชนิดใช้ไฟล์ไหน
        private static readonly Dictionary<Sfx, string> files = new Dictionary<Sfx, string>
        {
            { Sfx.Jump,      "jump.wav"     },
            { Sfx.Splash,    "splash.wav"   },
            { Sfx.GameOver,  "gameover.wav" },
            { Sfx.NextLevel, "next.wav"     },
            { Sfx.Win,       "win.wav"      },
            { Sfx.Heal,      "heal.wav"     },
            { Sfx.Time,      "time.wav"     },
            { Sfx.Coin,      "coin.wav"     },
            { Sfx.Horn,      "horn.wav"     },
        };

        private static readonly Dictionary<Sfx, MediaPlayer[]> pools = new Dictionary<Sfx, MediaPlayer[]>();
        private static readonly Dictionary<Sfx, int> nextSlot = new Dictionary<Sfx, int>();
        private static MediaPlayer music;


        // สร้างตัวเล่นเสียงจากชื่อไฟล์ (loop = true คือเล่นวนซ้ำ)
        private static MediaPlayer CreatePlayer(string fileName, double volume, bool loop)
        {
            string path = Path.Combine(SoundsFolder, fileName);
            if (!File.Exists(path)) return null;      // ไม่มีไฟล์ = ข้าม ไม่ให้เกมพัง

            MediaPlayer p = new MediaPlayer();
            p.MediaFailed += (s, e) => { };           // เปิดไฟล์ไม่ได้ก็เงียบไป ไม่ให้โปรแกรมเด้ง
            if (loop)
            {
                // เมื่อเพลงเล่นจบ ให้กลับไปต้นเพลงแล้วเล่นใหม่
                p.MediaEnded += (s, e) =>
                {
                    p.Position = TimeSpan.Zero;
                    p.Play();
                };
            }
            p.Open(new Uri(path, UriKind.Absolute));
            p.Volume = volume;
            return p;
        }
        // true = เล่นเอฟเฟกต์ได้, false = ปิดเสียงเอฟเฟกต์
        public static bool SoundEnabled { get; set; } = true;

        private static bool musicEnabled = true;
        public static bool MusicEnabled
        {
            get { return musicEnabled; }
            set
            {
                musicEnabled = value;
                if (!value) PauseMusic();   // ปิดเพลงแล้วหยุดทันที
            }
        }

        public static void PlayMusic()
        {
            if (!MusicEnabled) return;
            if (music == null) music = CreatePlayer("bgm.wav", MusicVolume, true);
            if (music != null) music.Play();   // ถ้าพักไว้ด้วย Pause จะเล่นต่อจากเดิม
        }

        public static void PauseMusic()
        {
            if (music != null) music.Pause();
        }

        public static void StopMusic()
        {
            if (music != null) music.Stop();   // Stop = กลับไปต้นเพลง
        }
        public static void Play(Sfx sfx)
        {
            if (!SoundEnabled) return;

            int slot;
            if (!nextSlot.TryGetValue(sfx, out slot)) slot = 0;
            nextSlot[sfx] = (slot + 1) % PoolSize;   // ครั้งหน้าใช้ตัวถัดไป วนครบ 4 ตัวแล้วกลับมาตัวแรก

            MediaPlayer p = GetPlayer(sfx, slot);
            if (p == null) return;                    // ไม่มีไฟล์เสียง = เงียบ
            p.Stop();
            p.Play();
        }

        private static MediaPlayer GetPlayer(Sfx sfx, int slot)
        {
            MediaPlayer[] pool;
            if (!pools.TryGetValue(sfx, out pool))
            {
                pool = new MediaPlayer[PoolSize];
                pools[sfx] = pool;
            }
            if (pool[slot] == null)
            {
                pool[slot] = CreatePlayer(files[sfx], SfxVolume, false);
            }
            return pool[slot];
        }
        // เรียกครั้งเดียวตอนเปิดโปรแกรม โหลดไฟล์รอไว้ เสียงแรกจะได้ไม่หน่วง
        public static void Preload()
        {
            if (music == null) music = CreatePlayer("bgm.wav", MusicVolume, true);
            foreach (Sfx sfx in files.Keys)
            {
                GetPlayer(sfx, 0);
            }
        }

        // เรียกตอนปิดโปรแกรม
        public static void Shutdown()
        {
            if (music != null) { music.Close(); music = null; }
            foreach (MediaPlayer[] pool in pools.Values)
            {
                foreach (MediaPlayer p in pool)
                {
                    if (p != null) p.Close();
                }
            }
            pools.Clear();
            nextSlot.Clear();
        }
    }
}
