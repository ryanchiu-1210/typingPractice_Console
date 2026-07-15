# ⌨️ typingPractice (C# 打字練習)

<p align="center">
  <img src="https://img.shields.io/badge/Language-C%23-blue.svg" alt="Language C#">
  <img src="https://img.shields.io/badge/.NET-9.0-purple.svg" alt=".NET 9.0">
  <img src="https://img.shields.io/badge/License-MIT-green.svg" alt="License MIT">
  <img src="https://img.shields.io/badge/Release-v1.0.0-orange.svg" alt="Release v1.0.0">
</p>

---

## 📖 專案簡介 | Project Overview

`typingPractice` 是一個使用 C# (.NET) 撰寫的輕量化主控台（Console）打字練習程式。本專案靈感來自於知名打字網站 **Monkeytype** 的 "10 Words" 挑戰模式。

特別的是，本專案內建了 **200 個 C# 程式開發中最常用的核心單字**（包含關鍵字、物件導向概念、LINQ、非同步語法等）。讓你在練習盲打、提升打字速度的同時，還能將 C# 的專業術語深深烙印在肌肉記憶中，非常適合程式初學者與開發者練手！

A lightweight command-line typing speed test built with C# (.NET), inspired by the popular typing website **Monkeytype**. Featuring a curated bank of **200 essential C# programming keywords and terms**, it helps you improve your typing speed and muscle memory for coding simultaneously!

---

## ✨ 專案特色 | Features

* **🧩 200 個 C# 專業字庫 (C# Developer Word Bank)**
  * 精選語法、OOP、記憶體管理、LINQ、執行緒與非同步等高頻率專業單字，拒絕無意義的英文字彙。
* **⏳ 智慧起算計時 (Smart Timer Start)**
  * 題目顯示後，計時器不會立刻啟動。直到你按下**第一個英文字母**時才開始倒數，讓你毫無壓力的先看清題目再動手。
* **🃏 費雪-葉茲洗牌演算法 (Zero-Duplicate Shuffling)**
  * 採用經典的 `Fisher-Yates Shuffle` 演算法，保證每次挑戰隨機抽出的 10 個單字**絕對不重複**。
* **📊 精準數據統計 (Detailed Results)**
  * 挑戰結束後，即時計算並顯示**花費秒數**、**正確字元數**、**精準度 (Accuracy)**、以及標準的 **WPM (Words Per Minute)**。
  * *註：WPM 依國際標準，以「5 個正確字元算作 1 個字（Word）」進行精準換算。*
* **🔁 循環挑戰 (Play Again)**
  * 挑戰結束後，可直接在 Console 輸入 `Y` 或 `N` 決定是否繼續下一輪，不需重複開啟程式。

---

## 🎮 如何遊玩 | How to Play

### 1. 快速遊玩（免安裝開發環境）
如果你只想直接玩遊戲，請依照以下步驟：
1. 前往本專案右側的 **[Releases](https://github.com/ryanchiu-1210/typingPractice_Console/releases/tag/v1.0.0)** 頁面。
2. 下載最新版本的 typingGame-v1.0.0.zip` 壓縮檔。
3. 在電腦中將其**解壓縮**。
4. 雙擊執行資料夾中的 `typingPractice_Console.exe` 即可開始挑戰！

> ⚠️ **環境需求**：執行時若跳出提示，請確保電腦已安裝 [.NET 9.0 Runtime](https://dotnet.microsoft.com/download)。

---

## 📸 遊戲畫面示範 | Gameplay Demo

<img width="612" height="173" alt="Screenshot 2026-07-15 202018" src="https://github.com/user-attachments/assets/dcaae384-5783-405f-a2e3-cb626246aaf3" />
<img width="988" height="369" alt="Screenshot 2026-07-15 202113" src="https://github.com/user-attachments/assets/156744eb-7eda-4689-8878-5aebac61129d" />

