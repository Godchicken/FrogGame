# Happy Jumping Frog — โครงโปรเจกต์ของทีม

เกมกบข้ามถนน-ข้ามแม่น้ำ (C# WinForms, .NET Framework 4.7.2)
โครงนี้ **build ผ่านและรันได้แล้ว** แต่ยังเล่นจนจบไม่ได้ เพราะส่วนของ B, C, D ยังเป็นตัวหลอก (stub)

## วิธีเปิดโปรเจกต์
1. ต้องมี Visual Studio 2019/2022 พร้อม workload **".NET desktop development"**
   (และ ".NET Framework 4.7.2 targeting pack" ซึ่งมากับ workload นั้นอยู่แล้ว)
2. เปิดไฟล์ `HappyJumpingFrog.sln` → กด **F5**
3. ควรเห็นหน้าเมนู → กด Play → เห็นกบสีเขียว เดินด้วย WASD / ลูกศร
   (ตอนนี้ยังไม่มีรถ/ซุง และถ้าลงน้ำกบจะตาย เป็นเรื่องปกติ จนกว่า B จะทำเสร็จ)

## ใครทำอะไร (1 โฟลเดอร์ = 1 เจ้าของ)

| คน | โฟลเดอร์/ไฟล์ | หน้าที่ |
|---|---|---|
| **A** | `Core/`, `Forms/FormGame*`, `Program.cs`, ไฟล์ตั้งค่าโปรเจกต์ | แกนเกม, ลูปเกม, รวมโค้ดทีม, ดูแล repo |
| **B** | `World/` (รวม `Monsters/`) | สนาม, ถนน, แม่น้ำ, รถ, ซุง, วางของในด่าน, สุ่มไอเท็ม |
| **C** | `Logic/` | ด่าน, คะแนน, เวลา, ดอกบัว, ไอเท็ม, ไฟล์ High Score |
| **D** | `Forms/` (ยกเว้น `FormGame*`) | เมนู, Pause, Game Over, ชนะ, ใส่ชื่อ, ตารางคะแนน + จัดหน้าตา |

**กฎทอง: ห้ามแก้ไฟล์ที่เป็นของคนอื่น** ถ้าอยากให้เขาเปลี่ยนอะไร ให้บอกในกลุ่ม

## หางานของตัวเอง
กด **Ctrl+Shift+F** ค้นหาในทั้งโซลูชัน:
`TODO(B)` · `TODO(C)` · `TODO(D)`
แต่ละ TODO มี pseudocode บอกว่าต้องทำอะไร ทำจนไม่เหลือ TODO ของตัวเองคืองานเสร็จ

## สัญญากลาง (ห้ามเปลี่ยนชื่อโดยไม่แจ้งทีม)

| คลาส | สมาชิกที่คนอื่นเรียกใช้ |
|---|---|
| `GameObject` | `X, Y, Width, Height, IsActive`, `Bounds`, `Intersects(other)`, `Draw(g)`, `Update()`, `OnHit(frog)`, `Reset()` |
| `PlayerFrog` | `Die()`, `Carry(dx)`, `AddScore(n)`, `AddLife()`, `ResetPosition()`, `Move(dx,dy)`, `Score`, `Lives`, `OnLog` |
| `JumpingField` | `Items`, `Water`, `Road`, `Draw(g)`, `UpdateSpawn()` |
| `GameController` | `MainLevel`, `SubLevel`, `TimeLimit`, `CalculateScore(sec)`, `NextLevel()`, `ResetLevel()`, `CreateField()`, `LevelText()` |
| `GameTimer` | `SecondsLeft`, `ElapsedSecond`, `IsTimeUp`, `Tick(ms)`, `Reset(sec)`, `ResetElapsed()`, `AddSeconds(n)` |
| `Item` | `Type` (`ItemType.Heart` / `ItemType.Time`) |
| `HighScoreManager` | `Load()` → `List<ScoreEntry>`, `Add(name, score)` |
| `FormGameOver`, `FormCongratulations` | ตั้ง `FinalScore` ก่อน `ShowDialog()`; ผลลัพธ์ `Retry` = เล่นใหม่, `OK` = บันทึกคะแนน |
| `FormName` | อ่าน `PlayerName` หลังได้ `DialogResult.OK` |
| `PauseDialog` | `SoundOn`, `MusicOn`; ผลลัพธ์ `Abort` = กลับเมนู, อื่นๆ = เล่นต่อ |

## วิธีทำงานร่วมกันด้วย Git

```
git checkout main
git pull                              # ดึงของล่าสุดก่อนเริ่มงานทุกครั้ง
git checkout -b feature/<งานของคุณ>   # เช่น feature/enemies, feature/scoring, feature/menus
# ... เขียนโค้ด, รันเทสต์ ...
git add .
git commit -m "ข้อความบอกว่าทำอะไร"
git push -u origin feature/<งานของคุณ>
# แล้วเปิด Pull Request บน GitHub ให้ A รวมเข้า main
```

- ห้าม push ตรงเข้า `main`
- merge เข้า `main` เฉพาะเมื่อ **build ผ่านและรันได้**
- commit บ่อยๆ ครั้งละงานเล็กๆ
- ห้าม commit โฟลเดอร์ `bin/`, `obj/`, `.vs/` (ตั้ง `.gitignore` ไว้ให้แล้ว)
- **ห้ามสองคนเปิดแก้ฟอร์มเดียวกันใน Designer พร้อมกัน** (ไฟล์ `*.Designer.cs` merge ยาก)

## ข้อควรรู้
- ชื่อคลาส `JumpingField` (สะกดถูก) ต่างจากโปรเจกต์ตัวอย่างของเพื่อนที่สะกดเป็น `JumpingFiled`
- ตอนนี้จะมี warning CS0414 ที่ `JumpingField` เรื่องตัวแปรที่ยังไม่ถูกใช้ จะหายไปเองเมื่อ B ทำ TODO เสร็จ
