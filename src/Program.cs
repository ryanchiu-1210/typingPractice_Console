using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MonkeyTypeConsole
{
    class Program
    {
        // 英文隨機字庫
        // 100 個 C# 常用單字庫
        // 200 個 C# 常用專業單字庫
        static readonly string[] WordBank = {
            // --- 基礎與流程控制 ---
            "using", "namespace", "class", "program", "main", "void", "static", "return", "args", "true",
            "false", "if", "else", "switch", "case", "break", "continue", "for", "foreach", "while",
            "do", "new", "var", "const", "readonly", "null", "nullable", "dynamic", "value", "type",

            // --- 資料型態與轉換 ---
            "string", "int", "double", "float", "bool", "char", "byte", "long", "decimal", "array",
            "convert", "parse", "tuple", "implicit", "explicit", "operator", "indexer", "param", "params", "yield",

            // --- 物件導向程式設計 (OOP) ---
            "object", "public", "private", "protected", "internal", "property", "method", "constructor", "struct", "event",
            "base", "this", "interface", "abstract", "virtual", "override", "sealed", "enum", "delegate", "lambda",
            "generic", "attribute", "record", "init", "pattern", "matching", "instance", "lifetime", "scope", "context",

            // --- 記憶體與生命週期 ---
            "garbage", "collector", "heap", "stack", "allocation", "destructor", "dispose", "initialize", "unsafe", "fixed",
            "pointer", "reference",

            // --- 集合與 LINQ ---
            "console", "write", "read", "input", "output", "line", "key", "list", "dictionary", "format",
            "clear", "count", "length", "index", "add", "remove", "contains", "find", "sort", "split",
            "enumerable", "enumerator", "collection", "queue", "hashset", "capacity", "range", "sequence", "query", "order",
            "by", "group", "join", "first", "last", "single", "any", "all", "skip", "take", "aggregate",

            // --- 系統、執行緒與非同步 ---
            "system", "exception", "try", "catch", "finally", "project", "solution", "reference", "assembly", "debug",
            "throw", "task", "async", "await", "thread", "linq", "select", "where", "get", "set",
            "lock", "monitor", "mutex", "semaphore", "cancel", "token", "progress", "delay", "run", "start",
            "complete", "status", "result", "parallel", "factory", "scheduler",

            // --- I/O、網路、資料與框架 ---
            "stream", "buffer", "file", "directory", "path", "writer", "reader", "client", "server", "request",
            "response", "header", "json", "xml", "serialize", "deserialize", "host", "port", "builder", "service",
            "dependency", "injection", "provider", "singleton", "observer", "test", "assert", "mock", "unit", "middleware",
            "controller", "action", "filter", "logger", "config"
        };

        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    RunTypingTest();

                    Console.WriteLine("\n-----------------------------------");
                    Console.Write("想再挑戰一次嗎？ (Y/N): ");

                    while (true)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Y)
                            break;
                        if (key.Key == ConsoleKey.N)
                            return;
                    }
                }
            }
            finally
            {
                Console.WriteLine();
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
            Console.WriteLine("題目如下：");
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