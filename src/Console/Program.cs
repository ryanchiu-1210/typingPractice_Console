using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using typingPractice_Console.Properties;

namespace MonkeyTypeConsole
{
    class Program
    {
        static readonly string[] WordBank = Resources.WordBank.Split('\n');

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    RunTypingTest();

                    Console.WriteLine("\n-----------------------------------");
                    Console.Write("想再挑戰一次嗎？ (Y/N): ");

                    do
                    {
                        string response = Console.ReadLine()?.Trim().ToUpper();

                        if (response != "Y" && response != "N") continue;
                        if (response == "N") return;
                        if (response == "Y") break;
                    } while (true);
                }
            }
            finally
            {
                Console.WriteLine("感謝遊玩！再見！");
            }
        }

        static void RunTypingTest()
        {
            Console.Clear();
            Console.WriteLine("=== 歡迎來到 10 字盲打挑戰 ===");
            Console.WriteLine("請在看到題目後直接開始打字，按下 Enter 鍵結束。");
            Console.WriteLine("按下任意鍵顯示題目...");
            Console.ReadKey(true);

            // 1. 生成 10 個隨機單字
            string TargetText = GenerateRandomText(10);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            /* 我要狡辯，這裡用Write的話，跟下面同為五個全形字體的「你的輸入：」會齊平，能更好的確認輸入是否正確 */
            Console.Write("題目如下：");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(TargetText);
            Console.ResetColor();
            Console.WriteLine("-----------------------------------");
            Console.Write("你的輸入：");

            StringBuilder userTyped = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();
            bool isTimerStarted = false;

            // 2. 核心輸入邏輯
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // 在使用者輸入第一個字元時才開始計時，避免準備時間被算進去
                if (!isTimerStarted && !char.IsControl(keyInfo.KeyChar))
                {
                    stopwatch.Start();
                    isTimerStarted = true;
                }

                // 偵測到 Enter 鍵代表打完結束
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }

                // 處理退格鍵 (Backspace)
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (userTyped.Length > 0)
                    {
                        userTyped.Remove(userTyped.Length - 1, 1);
                        Console.Write("\b \b"); // 在畫面上往回刪除一格
                    }
                }
                // 正常字元輸入
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    userTyped.Append(keyInfo.KeyChar);
                    Console.Write(keyInfo.KeyChar); // 顯示輸入字元
                }
            }

            stopwatch.Stop();
            double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

            Console.WriteLine("\n\n=== 挑戰結束！ ===");

            // 3. 計算並顯示 WPM 結果
            string finalInput = userTyped.ToString();
            CalculateResults(TargetText, finalInput, elapsedSeconds);
        }

        static string GenerateRandomText(int wordCount)
        {
            Random rand = new Random();

            // 1. 複製一份單字庫，避免破壞原本的 WordBank 陣列
            List<string> shuffledWords = new List<string>(WordBank);

            // 2. 費雪-葉茲洗牌演算法 (Fisher-Yates Shuffle)
            // 把整袋單字徹底打亂
            int n = shuffledWords.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                string value = shuffledWords[k];
                shuffledWords[k] = shuffledWords[n];
                shuffledWords[n] = value;
            }

            // 3. 直接取出打亂後的前 10 個（wordCount）單字
            List<string> chosenWords = shuffledWords.GetRange(0, Math.Min(wordCount, shuffledWords.Count));

            return string.Join(" ", chosenWords);
        }

        static void CalculateResults(string target, string input, double elapsedSeconds)
        {
            // 防呆：如果使用者一字未打就按 Enter
            if (elapsedSeconds <= 0 || input.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("你沒有輸入任何字元喔！");
                Console.ResetColor();
                return;
            }

            // 比對輸入與題目，計算正確字元數
            int correctChars = 0;
            int minLength = Math.Min(target.Length, input.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (target[i] == input[i])
                {
                    correctChars++;
                }
            }

            // 計算精準度
            double accuracy = ((double)correctChars / input.Length) * 100;

            // 計算 WPM (Words Per Minute)
            // 標準定義：5個正確字元算一個 Word
            double minutes = elapsedSeconds / 60.0;
            double wpm = (correctChars / 5.0) / minutes;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"花費時間: {elapsedSeconds:F2} 秒");
            Console.WriteLine($"你打的總字元數: {input.Length}");
            Console.WriteLine($"正確字元數: {correctChars}");
            Console.WriteLine($"精準度 (Accuracy): {accuracy:F2}%");
            Console.WriteLine($"打字速度 (WPM): {wpm:F0} WPM");
            Console.ResetColor();
        }
    }
}