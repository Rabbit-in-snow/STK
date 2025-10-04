using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HashCheck : MonoBehaviour
{
    public string Version;
    private bool ok;
    async void Start()
    {
#if UNITY_STANDALONE_WIN
        ok = await CheckBuildHash(Version);
#elif UNITY_EDITOR
        ok=true;
#endif
        StartCoroutine(run());
    }
    IEnumerator run()
    {
        yield return new WaitForSecondsRealtime(1f);
        if (ok)
        {
            GetComponent<TextMeshProUGUI>().text = "무결성 검증 성공!";
        }
        else
        {
            GetComponent<TextMeshProUGUI>().color = Color.red;
            GetComponent<TextMeshProUGUI>().text = "무결성 검증 실패!";
        }
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("Loby");
    }

#if UNITY_STANDALONE_WIN
    public async Task<bool> CheckBuildHash(string versionName)
    {
        try
        {
            string exePath = GetExecutablePathWindows();
            if (string.IsNullOrEmpty(exePath) || !File.Exists(exePath))
                return false;

            string localHash = await ComputeFileSHA256Async(exePath);

            string url = $"https://raw.githubusercontent.com/Rabbit-in-snow/STK/refs/heads/web/{versionName}";

            string remoteContent = await TryDownloadStringAsync(url);
            if (remoteContent == null)
                return true; // 인터넷 없음 -> true

            string remoteHash = remoteContent.Trim();

            return string.Equals(localHash, remoteHash, StringComparison.OrdinalIgnoreCase);
        }
        catch
        {
            return false;
        }
    }


    string GetExecutablePathWindows()
    {
        try
        {
            using Process proc = Process.GetCurrentProcess();
            return proc.MainModule?.FileName;
        }
        catch
        {
            // 예외시 Application.dataPath에서 추정
            return Path.Combine(Application.dataPath, Path.GetFileName(Application.dataPath) + ".exe");
        }
    }

    async Task<string> ComputeFileSHA256Async(string path)
    {
        using var sha256 = SHA256.Create();
        using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 81920, useAsync: true);
        using var ms = new MemoryStream();
        await fs.CopyToAsync(ms).ConfigureAwait(false);
        ms.Position = 0;
        byte[] hash = sha256.ComputeHash(ms);
        StringBuilder sb = new(64);
        foreach (byte b in hash) sb.Append(b.ToString("x2"));
        return sb.ToString();
    }


    async Task<string> TryDownloadStringAsync(string url, int timeoutSeconds = 10)
    {
        using UnityWebRequest uwr = UnityWebRequest.Get(url);
        uwr.timeout = timeoutSeconds;
        var op = uwr.SendWebRequest();
        while (!op.isDone) await Task.Yield();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            UnityEngine.Debug.LogWarning($"UnityWebRequest failed: {uwr.error} (URL: {url})");
            return null;
        }

        return uwr.downloadHandler.text;
    }
#endif
}
