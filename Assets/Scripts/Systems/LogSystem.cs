using System;
using System.IO;
using TMPro;
using UnityEngine;

public class LogSystem : Singleton<LogSystem> {

    [SerializeField] TextMeshProUGUI _pathText;

    string _logFilePath;

    void Awake() {
        _logFilePath = Path.Combine(Application.persistentDataPath, "SlotMachine_logs.txt");
        InitializeLogFile();
    }  

    void InitializeLogFile() {
        if (File.Exists(_logFilePath)) File.Delete(_logFilePath);
        File.WriteAllText(_logFilePath, $"Log started at: {DateTime.Now}\n\n");

        _pathText.text = _logFilePath;
        Debug.Log($"Local Log file saved in: {Application.persistentDataPath}");
    }

    // Basic logging method
    void Log(string message) {
        string timestamp = DateTime.Now.ToString("HH:mm:ss");
        string formattedMessage = $"[{timestamp}] {message}";

        // Write to file
        File.AppendAllText(_logFilePath, formattedMessage + "\n");

        Debug.Log(formattedMessage);
    }

    #region Event Logs Methods

    public void LogCreditInsertion(int amount)
    {
        Log($"Inserted credits: +{amount}");
    }

    public void LogSpinStart(int amount)
    {
        Log($"Spin started (bet: {amount} credit)");
    }

    public void LogSpinResult(int payout)
    {
        Log($"Center match! | Gain: {payout} credits");
    }

    public void LogJackpotWin(int value)
    {
        Log($"JACKPOT! Amount Paid: {value} credits");
    }

    public void LogCashout(int amount)
    {
        Log($"Cashout | Credits: {amount}");
    }

    #endregion
}