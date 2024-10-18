using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SelectDirector : MonoBehaviour
{
    // ボタンの配列を宣言します。
    public Button[] buttons;

    // 選択中のボタンのインデックスを保持する変数を宣言します。
    private int selectedIndex = 0;

    // サウンドエフェクト (SE) 用のオーディオソースを宣言します。
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip selectSE;

    void Start()
    {
        SelectButton(buttons[selectedIndex]); // 最初にボタン1が選択された状態にします。
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // 十字キーで選択を移動します。
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Button3"))
        {
            selectedIndex = (selectedIndex - 1 + buttons.Length) % buttons.Length;
            UpdateSelection();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetButtonDown("Button0"))
        {
            selectedIndex = (selectedIndex + 1) % buttons.Length;
            UpdateSelection();
        }

        // スペースキーで選択を決定します。
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Button1"))
        {
            PlaySelectSEAndLoadScene();
        }
    }

    // 選択中のボタンを更新する関数です。
    void UpdateSelection()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = (i == selectedIndex);
        }
    }

    // ボタンを選択状態にする関数です。
    void SelectButton(Button selectedButton)
    {
        foreach (Button button in buttons)
        {
            button.interactable = (button == selectedButton);
        }
    }

    // SEを再生してシーンを変更する関数です。
    void PlaySelectSEAndLoadScene()
    {
        if (audioSource != null && selectSE != null)
        {
            audioSource.PlayOneShot(selectSE);
            StartCoroutine(WaitForSEAndLoadScene());
        }
        else
        {
            LoadSceneImmediately();
        }
    }

    // SEが鳴り終わってからシーンを変更するコルーチンです。
    IEnumerator WaitForSEAndLoadScene()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);

        switch (selectedIndex)
        {
            case 0:
                SceneManager.LoadScene("EasyScene");
                break;
            case 1:
                SceneManager.LoadScene("HardScene");
                break;
            case 2:
                SceneManager.LoadScene("RuleScene");
                break;
        }
    }

    // SEがない場合に即座にシーンを変更する関数です。
    void LoadSceneImmediately()
    {
        switch (selectedIndex)
        {
            case 0:
                SceneManager.LoadScene("EasyScene");
                break;
            case 1:
                SceneManager.LoadScene("HardScene");
                break;
            case 2:
                SceneManager.LoadScene("RuleScene");
                break;
        }
    }
}
