using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SelectDirector : MonoBehaviour
{
    // �{�^���̔z���錾���܂��B
    public Button[] buttons;

    // �I�𒆂̃{�^���̃C���f�b�N�X��ێ�����ϐ���錾���܂��B
    private int selectedIndex = 0;

    // �T�E���h�G�t�F�N�g (SE) �p�̃I�[�f�B�I�\�[�X��錾���܂��B
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip selectSE;

    void Start()
    {
        SelectButton(buttons[selectedIndex]); // �ŏ��Ƀ{�^��1���I�����ꂽ��Ԃɂ��܂��B
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // �\���L�[�őI�����ړ����܂��B
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

        // �X�y�[�X�L�[�őI�������肵�܂��B
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Button1"))
        {
            PlaySelectSEAndLoadScene();
        }
    }

    // �I�𒆂̃{�^�����X�V����֐��ł��B
    void UpdateSelection()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = (i == selectedIndex);
        }
    }

    // �{�^����I����Ԃɂ���֐��ł��B
    void SelectButton(Button selectedButton)
    {
        foreach (Button button in buttons)
        {
            button.interactable = (button == selectedButton);
        }
    }

    // SE���Đ����ăV�[����ύX����֐��ł��B
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

    // SE����I����Ă���V�[����ύX����R���[�`���ł��B
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

    // SE���Ȃ��ꍇ�ɑ����ɃV�[����ύX����֐��ł��B
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
